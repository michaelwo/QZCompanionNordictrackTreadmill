using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using AWSSDK.Runtime.Internal.Util;
using Amazon.Auth.AccessControlPolicy.Internal;
using Amazon.Internal;
using Amazon.Runtime;
using Amazon.Runtime.EventStreams.Internal;
using Amazon.Runtime.Internal;
using Amazon.Runtime.Internal.Auth;
using Amazon.Runtime.Internal.Transform;
using Amazon.Runtime.Internal.Util;
using Amazon.Runtime.SharedInterfaces;
using Amazon.Util;
using Amazon.Util.Internal;
using Amazon.Util.Internal.PlatformServices;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Net;
using Android.OS;
using Android.Util;
using PCLCrypto;
using PCLStorage;
using ThirdParty.Ionic.Zlib;
using ThirdParty.Json.LitJson;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("AWSSDK.Core")]
[assembly: AssemblyDescription("The Amazon Web Services SDK for .NET (PCL)- Core Runtime")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyProduct("Amazon Web Services SDK for .NET")]
[assembly: AssemblyCompany("Amazon.com, Inc")]
[assembly: AssemblyCopyright("Copyright 2009-2015 Amazon.com, Inc. or its affiliates. All Rights Reserved.")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: AssemblyFileVersion("3.3.107.28")]
[assembly: CLSCompliant(true)]
[assembly: UsesPermission(Name = "android.permission.INTERNET")]
[assembly: UsesPermission(Name = "android.permission.ACCESS_NETWORK_STATE")]
[assembly: UsesPermission(Name = "android.permission.ACCESS_WIFI_STATE")]
[assembly: UsesPermission(Name = "android.permission.READ_EXTERNAL_STORAGE")]
[assembly: UsesPermission(Name = "android.permission.WRITE_EXTERNAL_STORAGE")]
[assembly: TargetFramework("MonoAndroid,Version=v6.0", FrameworkDisplayName = "Xamarin.Android v6.0 Support")]
[assembly: AssemblyVersion("3.3.0.0")]
namespace ThirdParty.Json.LitJson
{
	public enum JsonType
	{
		None,
		Object,
		Array,
		String,
		Int,
		UInt,
		Long,
		ULong,
		Double,
		Boolean
	}
	public interface IJsonWrapper : IList, ICollection, IEnumerable, IOrderedDictionary, IDictionary
	{
		bool IsArray { get; }

		bool IsBoolean { get; }

		bool IsDouble { get; }

		bool IsInt { get; }

		bool IsUInt { get; }

		bool IsLong { get; }

		bool IsULong { get; }

		bool IsObject { get; }

		bool IsString { get; }

		bool GetBoolean();

		double GetDouble();

		int GetInt();

		uint GetUInt();

		JsonType GetJsonType();

		long GetLong();

		ulong GetULong();

		string GetString();

		void SetBoolean(bool val);

		void SetDouble(double val);

		void SetInt(int val);

		void SetUInt(uint val);

		void SetJsonType(JsonType type);

		void SetLong(long val);

		void SetULong(ulong val);

		void SetString(string val);

		string ToJson();

		void ToJson(JsonWriter writer);
	}
	public class JsonData : IJsonWrapper, IList, ICollection, IEnumerable, IOrderedDictionary, IDictionary, IEquatable<JsonData>
	{
		private IList<JsonData> inst_array;

		private bool inst_boolean;

		private double inst_double;

		private ulong inst_number;

		private IDictionary<string, JsonData> inst_object;

		private string inst_string;

		private string json;

		private JsonType type;

		private IList<KeyValuePair<string, JsonData>> object_list;

		public int Count => EnsureCollection().Count;

		public bool IsArray => type == JsonType.Array;

		public bool IsBoolean => type == JsonType.Boolean;

		public bool IsDouble => type == JsonType.Double;

		public bool IsInt => type == JsonType.Int;

		public bool IsUInt => type == JsonType.UInt;

		public bool IsLong => type == JsonType.Long;

		public bool IsULong => type == JsonType.ULong;

		public bool IsObject => type == JsonType.Object;

		public bool IsString => type == JsonType.String;

		int ICollection.Count => Count;

		bool ICollection.IsSynchronized => EnsureCollection().IsSynchronized;

		object ICollection.SyncRoot => EnsureCollection().SyncRoot;

		bool IDictionary.IsFixedSize => EnsureDictionary().IsFixedSize;

		bool IDictionary.IsReadOnly => EnsureDictionary().IsReadOnly;

		ICollection IDictionary.Keys
		{
			get
			{
				EnsureDictionary();
				IList<string> list = new List<string>();
				foreach (KeyValuePair<string, JsonData> item in object_list)
				{
					list.Add(item.Key);
				}
				return (ICollection)list;
			}
		}

		ICollection IDictionary.Values
		{
			get
			{
				EnsureDictionary();
				IList<JsonData> list = new List<JsonData>();
				foreach (KeyValuePair<string, JsonData> item in object_list)
				{
					list.Add(item.Value);
				}
				return (ICollection)list;
			}
		}

		bool IJsonWrapper.IsArray => IsArray;

		bool IJsonWrapper.IsBoolean => IsBoolean;

		bool IJsonWrapper.IsDouble => IsDouble;

		bool IJsonWrapper.IsInt => IsInt;

		bool IJsonWrapper.IsLong => IsLong;

		bool IJsonWrapper.IsObject => IsObject;

		bool IJsonWrapper.IsString => IsString;

		bool IList.IsFixedSize => EnsureList().IsFixedSize;

		bool IList.IsReadOnly => EnsureList().IsReadOnly;

		object IDictionary.this[object key]
		{
			get
			{
				return EnsureDictionary()[key];
			}
			set
			{
				if (!(key is string))
				{
					throw new ArgumentException("The key has to be a string");
				}
				JsonData value2 = ToJsonData(value);
				this[(string)key] = value2;
			}
		}

		object IOrderedDictionary.this[int idx]
		{
			get
			{
				EnsureDictionary();
				return object_list[idx].Value;
			}
			set
			{
				EnsureDictionary();
				JsonData value2 = ToJsonData(value);
				KeyValuePair<string, JsonData> keyValuePair = object_list[idx];
				inst_object[keyValuePair.Key] = value2;
				KeyValuePair<string, JsonData> value3 = new KeyValuePair<string, JsonData>(keyValuePair.Key, value2);
				object_list[idx] = value3;
			}
		}

		object IList.this[int index]
		{
			get
			{
				return EnsureList()[index];
			}
			set
			{
				EnsureList();
				JsonData value2 = ToJsonData(value);
				this[index] = value2;
			}
		}

		public IEnumerable<string> PropertyNames
		{
			get
			{
				EnsureDictionary();
				return inst_object.Keys;
			}
		}

		public JsonData this[string prop_name]
		{
			get
			{
				EnsureDictionary();
				JsonData value = null;
				inst_object.TryGetValue(prop_name, out value);
				return value;
			}
			set
			{
				EnsureDictionary();
				KeyValuePair<string, JsonData> keyValuePair = new KeyValuePair<string, JsonData>(prop_name, value);
				if (inst_object.ContainsKey(prop_name))
				{
					for (int i = 0; i < object_list.Count; i = checked(i + 1))
					{
						if (object_list[i].Key == prop_name)
						{
							object_list[i] = keyValuePair;
							break;
						}
					}
				}
				else
				{
					object_list.Add(keyValuePair);
				}
				inst_object[prop_name] = value;
				json = null;
			}
		}

		public JsonData this[int index]
		{
			get
			{
				EnsureCollection();
				if (type == JsonType.Array)
				{
					return inst_array[index];
				}
				return object_list[index].Value;
			}
			set
			{
				EnsureCollection();
				if (type == JsonType.Array)
				{
					inst_array[index] = value;
				}
				else
				{
					KeyValuePair<string, JsonData> keyValuePair = object_list[index];
					KeyValuePair<string, JsonData> value2 = new KeyValuePair<string, JsonData>(keyValuePair.Key, value);
					object_list[index] = value2;
					inst_object[keyValuePair.Key] = value;
				}
				json = null;
			}
		}

		public JsonData()
		{
		}

		public JsonData(bool boolean)
		{
			type = JsonType.Boolean;
			inst_boolean = boolean;
		}

		public JsonData(double number)
		{
			type = JsonType.Double;
			inst_double = number;
		}

		public JsonData(int number)
		{
			type = JsonType.Int;
			inst_number = checked((ulong)number);
		}

		public JsonData(uint number)
		{
			type = JsonType.UInt;
			inst_number = number;
		}

		public JsonData(long number)
		{
			type = JsonType.Long;
			inst_number = checked((ulong)number);
		}

		public JsonData(ulong number)
		{
			type = JsonType.ULong;
			inst_number = number;
		}

		public JsonData(object obj)
		{
			if (obj is bool)
			{
				type = JsonType.Boolean;
				inst_boolean = (bool)obj;
				return;
			}
			if (obj is double)
			{
				type = JsonType.Double;
				inst_double = (double)obj;
				return;
			}
			if (obj is int)
			{
				type = JsonType.Int;
				inst_number = (ulong)obj;
				return;
			}
			if (obj is uint)
			{
				type = JsonType.UInt;
				inst_number = (ulong)obj;
				return;
			}
			if (obj is long)
			{
				type = JsonType.Long;
				inst_number = (ulong)obj;
				return;
			}
			if (obj is ulong)
			{
				type = JsonType.ULong;
				inst_number = (ulong)obj;
				return;
			}
			if (obj is string)
			{
				type = JsonType.String;
				inst_string = (string)obj;
				return;
			}
			throw new ArgumentException("Unable to wrap the given object with JsonData");
		}

		public JsonData(string str)
		{
			type = JsonType.String;
			inst_string = str;
		}

		public static implicit operator JsonData(bool data)
		{
			return new JsonData(data);
		}

		public static implicit operator JsonData(double data)
		{
			return new JsonData(data);
		}

		public static implicit operator JsonData(int data)
		{
			return new JsonData(data);
		}

		public static implicit operator JsonData(long data)
		{
			return new JsonData(data);
		}

		public static implicit operator JsonData(string data)
		{
			return new JsonData(data);
		}

		public static explicit operator bool(JsonData data)
		{
			if (data.type != JsonType.Boolean)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold a double");
			}
			return data.inst_boolean;
		}

		public static explicit operator double(JsonData data)
		{
			if (data.type != JsonType.Double)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold a double");
			}
			return data.inst_double;
		}

		public static explicit operator int(JsonData data)
		{
			if (data.type != JsonType.Int)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold an int");
			}
			return (int)data.inst_number;
		}

		public static explicit operator uint(JsonData data)
		{
			if (data.type != JsonType.UInt)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold an int");
			}
			return (uint)data.inst_number;
		}

		public static explicit operator long(JsonData data)
		{
			if (data.type != JsonType.Int && data.type != JsonType.Long)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold an long");
			}
			return (long)data.inst_number;
		}

		[CLSCompliant(false)]
		public static explicit operator ulong(JsonData data)
		{
			if (data.type != JsonType.UInt && data.type != JsonType.ULong)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold an long");
			}
			return data.inst_number;
		}

		public static explicit operator string(JsonData data)
		{
			if (data.type != JsonType.String)
			{
				throw new InvalidCastException("Instance of JsonData doesn't hold a string");
			}
			return data.inst_string;
		}

		void ICollection.CopyTo(Array array, int index)
		{
			EnsureCollection().CopyTo(array, index);
		}

		void IDictionary.Add(object key, object value)
		{
			JsonData value2 = ToJsonData(value);
			EnsureDictionary().Add(key, value2);
			KeyValuePair<string, JsonData> item = new KeyValuePair<string, JsonData>((string)key, value2);
			object_list.Add(item);
			json = null;
		}

		void IDictionary.Clear()
		{
			EnsureDictionary().Clear();
			object_list.Clear();
			json = null;
		}

		bool IDictionary.Contains(object key)
		{
			return EnsureDictionary().Contains(key);
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return ((IOrderedDictionary)this).GetEnumerator();
		}

		void IDictionary.Remove(object key)
		{
			EnsureDictionary().Remove(key);
			for (int i = 0; i < object_list.Count; i = checked(i + 1))
			{
				if (object_list[i].Key == (string)key)
				{
					object_list.RemoveAt(i);
					break;
				}
			}
			json = null;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return EnsureCollection().GetEnumerator();
		}

		bool IJsonWrapper.GetBoolean()
		{
			if (type != JsonType.Boolean)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a boolean");
			}
			return inst_boolean;
		}

		double IJsonWrapper.GetDouble()
		{
			if (type != JsonType.Double)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a double");
			}
			return inst_double;
		}

		int IJsonWrapper.GetInt()
		{
			if (type != JsonType.Int)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold an int");
			}
			return (int)inst_number;
		}

		uint IJsonWrapper.GetUInt()
		{
			if (type != JsonType.UInt)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold an int");
			}
			return (uint)inst_number;
		}

		long IJsonWrapper.GetLong()
		{
			if (type != JsonType.Long)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a long");
			}
			return (long)inst_number;
		}

		ulong IJsonWrapper.GetULong()
		{
			if (type != JsonType.ULong)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a long");
			}
			return inst_number;
		}

		string IJsonWrapper.GetString()
		{
			if (type != JsonType.String)
			{
				throw new InvalidOperationException("JsonData instance doesn't hold a string");
			}
			return inst_string;
		}

		void IJsonWrapper.SetBoolean(bool val)
		{
			type = JsonType.Boolean;
			inst_boolean = val;
			json = null;
		}

		void IJsonWrapper.SetDouble(double val)
		{
			type = JsonType.Double;
			inst_double = val;
			json = null;
		}

		void IJsonWrapper.SetInt(int val)
		{
			type = JsonType.Int;
			inst_number = (ulong)val;
			json = null;
		}

		void IJsonWrapper.SetUInt(uint val)
		{
			type = JsonType.UInt;
			inst_number = val;
			json = null;
		}

		void IJsonWrapper.SetLong(long val)
		{
			type = JsonType.Long;
			inst_number = (ulong)val;
			json = null;
		}

		void IJsonWrapper.SetULong(ulong val)
		{
			type = JsonType.ULong;
			inst_number = val;
			json = null;
		}

		void IJsonWrapper.SetString(string val)
		{
			type = JsonType.String;
			inst_string = val;
			json = null;
		}

		string IJsonWrapper.ToJson()
		{
			return ToJson();
		}

		void IJsonWrapper.ToJson(JsonWriter writer)
		{
			ToJson(writer);
		}

		int IList.Add(object value)
		{
			return Add(value);
		}

		void IList.Clear()
		{
			EnsureList().Clear();
			json = null;
		}

		bool IList.Contains(object value)
		{
			return EnsureList().Contains(value);
		}

		int IList.IndexOf(object value)
		{
			return EnsureList().IndexOf(value);
		}

		void IList.Insert(int index, object value)
		{
			EnsureList().Insert(index, value);
			json = null;
		}

		void IList.Remove(object value)
		{
			EnsureList().Remove(value);
			json = null;
		}

		void IList.RemoveAt(int index)
		{
			EnsureList().RemoveAt(index);
			json = null;
		}

		IDictionaryEnumerator IOrderedDictionary.GetEnumerator()
		{
			EnsureDictionary();
			return new OrderedDictionaryEnumerator(object_list.GetEnumerator());
		}

		void IOrderedDictionary.Insert(int idx, object key, object value)
		{
			string text = (string)key;
			JsonData value2 = (this[text] = ToJsonData(value));
			KeyValuePair<string, JsonData> item = new KeyValuePair<string, JsonData>(text, value2);
			object_list.Insert(idx, item);
		}

		void IOrderedDictionary.RemoveAt(int idx)
		{
			EnsureDictionary();
			inst_object.Remove(object_list[idx].Key);
			object_list.RemoveAt(idx);
		}

		private ICollection EnsureCollection()
		{
			if (type == JsonType.Array)
			{
				return (ICollection)inst_array;
			}
			if (type == JsonType.Object)
			{
				return (ICollection)inst_object;
			}
			throw new InvalidOperationException("The JsonData instance has to be initialized first");
		}

		private IDictionary EnsureDictionary()
		{
			if (type == JsonType.Object)
			{
				return (IDictionary)inst_object;
			}
			if (type != JsonType.None)
			{
				throw new InvalidOperationException("Instance of JsonData is not a dictionary");
			}
			type = JsonType.Object;
			inst_object = new Dictionary<string, JsonData>();
			object_list = new List<KeyValuePair<string, JsonData>>();
			return (IDictionary)inst_object;
		}

		private IList EnsureList()
		{
			if (type == JsonType.Array)
			{
				return (IList)inst_array;
			}
			if (type != JsonType.None)
			{
				throw new InvalidOperationException("Instance of JsonData is not a list");
			}
			type = JsonType.Array;
			inst_array = new List<JsonData>();
			return (IList)inst_array;
		}

		private JsonData ToJsonData(object obj)
		{
			if (obj == null)
			{
				return null;
			}
			if (obj is JsonData)
			{
				return (JsonData)obj;
			}
			return new JsonData(obj);
		}

		private static void WriteJson(IJsonWrapper obj, JsonWriter writer)
		{
			if (obj == null)
			{
				writer.Write(null);
			}
			else if (obj.IsString)
			{
				writer.Write(obj.GetString());
			}
			else if (obj.IsBoolean)
			{
				writer.Write(obj.GetBoolean());
			}
			else if (obj.IsDouble)
			{
				writer.Write(obj.GetDouble());
			}
			else if (obj.IsInt)
			{
				writer.Write(obj.GetInt());
			}
			else if (obj.IsUInt)
			{
				writer.Write(obj.GetUInt());
			}
			else if (obj.IsLong)
			{
				writer.Write(obj.GetLong());
			}
			else if (obj.IsULong)
			{
				writer.Write(obj.GetULong());
			}
			else if (obj.IsArray)
			{
				writer.WriteArrayStart();
				foreach (JsonData item in (IEnumerable)obj)
				{
					WriteJson(item, writer);
				}
				writer.WriteArrayEnd();
			}
			else
			{
				if (!obj.IsObject)
				{
					return;
				}
				writer.WriteObjectStart();
				foreach (DictionaryEntry item2 in (IDictionary)obj)
				{
					writer.WritePropertyName((string)item2.Key);
					WriteJson((JsonData)item2.Value, writer);
				}
				writer.WriteObjectEnd();
			}
		}

		public int Add(object value)
		{
			JsonData value2 = ToJsonData(value);
			json = null;
			return EnsureList().Add(value2);
		}

		public void Clear()
		{
			if (IsObject)
			{
				((IDictionary)this).Clear();
			}
			else if (IsArray)
			{
				((IList)this).Clear();
			}
		}

		public bool Equals(JsonData x)
		{
			if (x == null)
			{
				return false;
			}
			if (x.type != type)
			{
				bool num = type == JsonType.Int || type == JsonType.Long;
				bool flag = type == JsonType.UInt || type == JsonType.ULong;
				bool flag2 = x.type == JsonType.Int || x.type == JsonType.Long;
				bool flag3 = x.type == JsonType.UInt || x.type == JsonType.ULong;
				if (num != flag2 && flag != flag3)
				{
					return false;
				}
			}
			switch (type)
			{
			case JsonType.None:
				return true;
			case JsonType.Object:
				return inst_object.Equals(x.inst_object);
			case JsonType.Array:
				return inst_array.Equals(x.inst_array);
			case JsonType.String:
				return inst_string.Equals(x.inst_string);
			case JsonType.Int:
			case JsonType.UInt:
			case JsonType.Long:
			case JsonType.ULong:
				return inst_number.Equals(x.inst_number);
			case JsonType.Double:
				return inst_double.Equals(x.inst_double);
			case JsonType.Boolean:
				return inst_boolean.Equals(x.inst_boolean);
			default:
				return false;
			}
		}

		public JsonType GetJsonType()
		{
			return type;
		}

		public void SetJsonType(JsonType type)
		{
			if (this.type != type)
			{
				switch (type)
				{
				case JsonType.Object:
					inst_object = new Dictionary<string, JsonData>();
					object_list = new List<KeyValuePair<string, JsonData>>();
					break;
				case JsonType.Array:
					inst_array = new List<JsonData>();
					break;
				case JsonType.String:
					inst_string = null;
					break;
				case JsonType.Int:
					inst_number = 0uL;
					break;
				case JsonType.UInt:
					inst_number = 0uL;
					break;
				case JsonType.Long:
					inst_number = 0uL;
					break;
				case JsonType.ULong:
					inst_number = 0uL;
					break;
				case JsonType.Double:
					inst_double = 0.0;
					break;
				case JsonType.Boolean:
					inst_boolean = false;
					break;
				}
				this.type = type;
			}
		}

		public string ToJson()
		{
			if (json != null)
			{
				return json;
			}
			StringWriter stringWriter = new StringWriter();
			JsonWriter jsonWriter = new JsonWriter(stringWriter);
			jsonWriter.Validate = false;
			WriteJson(this, jsonWriter);
			json = stringWriter.ToString();
			return json;
		}

		public void ToJson(JsonWriter writer)
		{
			bool validate = writer.Validate;
			writer.Validate = false;
			WriteJson(this, writer);
			writer.Validate = validate;
		}

		public override string ToString()
		{
			switch (type)
			{
			case JsonType.Array:
				return "JsonData array";
			case JsonType.Boolean:
				return inst_boolean.ToString();
			case JsonType.Double:
				return inst_double.ToString();
			case JsonType.Int:
				return ((int)inst_number).ToString();
			case JsonType.UInt:
				return ((uint)inst_number).ToString();
			case JsonType.Long:
			{
				long num = (long)inst_number;
				return num.ToString();
			}
			case JsonType.ULong:
				return inst_number.ToString();
			case JsonType.Object:
				return "JsonData object";
			case JsonType.String:
				return inst_string;
			default:
				return "Uninitialized JsonData";
			}
		}
	}
	internal class OrderedDictionaryEnumerator : IDictionaryEnumerator, IEnumerator
	{
		private IEnumerator<KeyValuePair<string, JsonData>> list_enumerator;

		public object Current => Entry;

		public DictionaryEntry Entry
		{
			get
			{
				KeyValuePair<string, JsonData> current = list_enumerator.Current;
				return new DictionaryEntry(current.Key, current.Value);
			}
		}

		public object Key => list_enumerator.Current.Key;

		public object Value => list_enumerator.Current.Value;

		public OrderedDictionaryEnumerator(IEnumerator<KeyValuePair<string, JsonData>> enumerator)
		{
			list_enumerator = enumerator;
		}

		public bool MoveNext()
		{
			return list_enumerator.MoveNext();
		}

		public void Reset()
		{
			list_enumerator.Reset();
		}
	}
	public class JsonException : Exception
	{
		public JsonException()
		{
		}

		internal JsonException(ParserToken token)
			: base($"Invalid token '{token}' in input string")
		{
		}

		internal JsonException(ParserToken token, Exception inner_exception)
			: base($"Invalid token '{token}' in input string", inner_exception)
		{
		}

		internal JsonException(int c)
			: base($"Invalid character '{(char)checked((ushort)c)}' in input string")
		{
		}

		internal JsonException(int c, Exception inner_exception)
			: base($"Invalid character '{(char)checked((ushort)c)}' in input string", inner_exception)
		{
		}

		public JsonException(string message)
			: base(message)
		{
		}

		public JsonException(string message, Exception inner_exception)
			: base(message, inner_exception)
		{
		}
	}
	internal struct PropertyMetadata
	{
		public MemberInfo Info;

		public bool IsField;

		public Type Type;
	}
	internal struct ArrayMetadata
	{
		private Type element_type;

		private bool is_array;

		private bool is_list;

		public Type ElementType
		{
			get
			{
				if (element_type == null)
				{
					return typeof(JsonData);
				}
				return element_type;
			}
			set
			{
				element_type = value;
			}
		}

		public bool IsArray
		{
			get
			{
				return is_array;
			}
			set
			{
				is_array = value;
			}
		}

		public bool IsList
		{
			get
			{
				return is_list;
			}
			set
			{
				is_list = value;
			}
		}
	}
	internal struct ObjectMetadata
	{
		private Type element_type;

		private bool is_dictionary;

		private IDictionary<string, PropertyMetadata> properties;

		public Type ElementType
		{
			get
			{
				if (element_type == null)
				{
					return typeof(JsonData);
				}
				return element_type;
			}
			set
			{
				element_type = value;
			}
		}

		public bool IsDictionary
		{
			get
			{
				return is_dictionary;
			}
			set
			{
				is_dictionary = value;
			}
		}

		public IDictionary<string, PropertyMetadata> Properties
		{
			get
			{
				return properties;
			}
			set
			{
				properties = value;
			}
		}
	}
	internal delegate void ExporterFunc(object obj, JsonWriter writer);
	public delegate void ExporterFunc<T>(T obj, JsonWriter writer);
	internal delegate object ImporterFunc(object input);
	public delegate TValue ImporterFunc<TJson, TValue>(TJson input);
	public delegate IJsonWrapper WrapperFactory();
	public class JsonMapper
	{
		private static int max_nesting_depth;

		private static IFormatProvider datetime_format;

		private static IDictionary<Type, ExporterFunc> base_exporters_table;

		private static IDictionary<Type, ExporterFunc> custom_exporters_table;

		private static IDictionary<Type, IDictionary<Type, ImporterFunc>> base_importers_table;

		private static IDictionary<Type, IDictionary<Type, ImporterFunc>> custom_importers_table;

		private static IDictionary<Type, ArrayMetadata> array_metadata;

		private static readonly object array_metadata_lock;

		private static IDictionary<Type, IDictionary<Type, MethodInfo>> conv_ops;

		private static readonly object conv_ops_lock;

		private static IDictionary<Type, ObjectMetadata> object_metadata;

		private static readonly object object_metadata_lock;

		private static IDictionary<Type, IList<PropertyMetadata>> type_properties;

		private static readonly object type_properties_lock;

		private static JsonWriter static_writer;

		private static readonly object static_writer_lock;

		private static readonly HashSet<string> dictionary_properties_to_ignore;

		static JsonMapper()
		{
			array_metadata_lock = new object();
			conv_ops_lock = new object();
			object_metadata_lock = new object();
			type_properties_lock = new object();
			static_writer_lock = new object();
			dictionary_properties_to_ignore = new HashSet<string>(StringComparer.Ordinal) { "Comparer", "Count", "Keys", "Values" };
			max_nesting_depth = 100;
			array_metadata = new Dictionary<Type, ArrayMetadata>();
			conv_ops = new Dictionary<Type, IDictionary<Type, MethodInfo>>();
			object_metadata = new Dictionary<Type, ObjectMetadata>();
			type_properties = new Dictionary<Type, IList<PropertyMetadata>>();
			static_writer = new JsonWriter();
			datetime_format = DateTimeFormatInfo.InvariantInfo;
			base_exporters_table = new Dictionary<Type, ExporterFunc>();
			custom_exporters_table = new Dictionary<Type, ExporterFunc>();
			base_importers_table = new Dictionary<Type, IDictionary<Type, ImporterFunc>>();
			custom_importers_table = new Dictionary<Type, IDictionary<Type, ImporterFunc>>();
			RegisterBaseExporters();
			RegisterBaseImporters();
		}

		private static void AddArrayMetadata(Type type)
		{
			if (array_metadata.ContainsKey(type))
			{
				return;
			}
			ArrayMetadata value = new ArrayMetadata
			{
				IsArray = type.IsArray
			};
			ITypeInfo typeInfo = TypeFactory.GetTypeInfo(type);
			if (typeInfo.GetInterface("System.Collections.IList") != null)
			{
				value.IsList = true;
			}
			foreach (PropertyInfo property in typeInfo.GetProperties())
			{
				if (!(property.Name != "Item"))
				{
					ParameterInfo[] indexParameters = property.GetIndexParameters();
					if (indexParameters.Length == 1 && indexParameters[0].ParameterType == typeof(int))
					{
						value.ElementType = property.PropertyType;
					}
				}
			}
			lock (array_metadata_lock)
			{
				try
				{
					array_metadata.Add(type, value);
				}
				catch (ArgumentException)
				{
				}
			}
		}

		private static void AddObjectMetadata(Type type)
		{
			if (object_metadata.ContainsKey(type))
			{
				return;
			}
			ObjectMetadata value = default(ObjectMetadata);
			ITypeInfo typeInfo = TypeFactory.GetTypeInfo(type);
			if (typeInfo.GetInterface("System.Collections.IDictionary") != null)
			{
				value.IsDictionary = true;
			}
			value.Properties = new Dictionary<string, PropertyMetadata>();
			foreach (PropertyInfo property in typeInfo.GetProperties())
			{
				if (property.Name == "Item")
				{
					ParameterInfo[] indexParameters = property.GetIndexParameters();
					if (indexParameters.Length == 1 && indexParameters[0].ParameterType == typeof(string))
					{
						value.ElementType = property.PropertyType;
					}
				}
				else if (!value.IsDictionary || !dictionary_properties_to_ignore.Contains(property.Name))
				{
					PropertyMetadata value2 = new PropertyMetadata
					{
						Info = property,
						Type = property.PropertyType
					};
					value.Properties.Add(property.Name, value2);
				}
			}
			foreach (FieldInfo field in typeInfo.GetFields())
			{
				PropertyMetadata value3 = new PropertyMetadata
				{
					Info = field,
					IsField = true,
					Type = field.FieldType
				};
				value.Properties.Add(field.Name, value3);
			}
			lock (object_metadata_lock)
			{
				try
				{
					object_metadata.Add(type, value);
				}
				catch (ArgumentException)
				{
				}
			}
		}

		private static void AddTypeProperties(Type type)
		{
			if (type_properties.ContainsKey(type))
			{
				return;
			}
			ITypeInfo typeInfo = TypeFactory.GetTypeInfo(type);
			IList<PropertyMetadata> list = new List<PropertyMetadata>();
			foreach (PropertyInfo property in typeInfo.GetProperties())
			{
				if (!(property.Name == "Item"))
				{
					list.Add(new PropertyMetadata
					{
						Info = property,
						IsField = false
					});
				}
			}
			foreach (FieldInfo field in typeInfo.GetFields())
			{
				list.Add(new PropertyMetadata
				{
					Info = field,
					IsField = true
				});
			}
			lock (type_properties_lock)
			{
				try
				{
					type_properties.Add(type, list);
				}
				catch (ArgumentException)
				{
				}
			}
		}

		private static MethodInfo GetConvOp(Type t1, Type t2)
		{
			lock (conv_ops_lock)
			{
				if (!conv_ops.ContainsKey(t1))
				{
					conv_ops.Add(t1, new Dictionary<Type, MethodInfo>());
				}
			}
			ITypeInfo typeInfo = TypeFactory.GetTypeInfo(t1);
			ITypeInfo typeInfo2 = TypeFactory.GetTypeInfo(t2);
			if (conv_ops[t1].ContainsKey(t2))
			{
				return conv_ops[t1][t2];
			}
			MethodInfo method = typeInfo.GetMethod("op_Implicit", new ITypeInfo[1] { typeInfo2 });
			lock (conv_ops_lock)
			{
				try
				{
					conv_ops[t1].Add(t2, method);
					return method;
				}
				catch (ArgumentException)
				{
					return conv_ops[t1][t2];
				}
			}
		}

		private static object ReadValue(Type inst_type, JsonReader reader)
		{
			reader.Read();
			ITypeInfo typeInfo = TypeFactory.GetTypeInfo(inst_type);
			if (reader.Token == JsonToken.ArrayEnd)
			{
				return null;
			}
			Type underlyingType = Nullable.GetUnderlyingType(inst_type);
			Type type = underlyingType ?? inst_type;
			if (reader.Token == JsonToken.Null)
			{
				if (typeInfo.IsClass || underlyingType != null)
				{
					return null;
				}
				throw new JsonException($"Can't assign null to an instance of type {inst_type}");
			}
			if (reader.Token == JsonToken.Double || reader.Token == JsonToken.Int || reader.Token == JsonToken.UInt || reader.Token == JsonToken.Long || reader.Token == JsonToken.ULong || reader.Token == JsonToken.String || reader.Token == JsonToken.Boolean)
			{
				Type type2 = reader.Value.GetType();
				ITypeInfo typeInfo2 = TypeFactory.GetTypeInfo(type2);
				if (typeInfo.IsAssignableFrom(typeInfo2))
				{
					return reader.Value;
				}
				if (custom_importers_table.ContainsKey(type2) && custom_importers_table[type2].ContainsKey(type))
				{
					return custom_importers_table[type2][type](reader.Value);
				}
				if (base_importers_table.ContainsKey(type2) && base_importers_table[type2].ContainsKey(type))
				{
					return base_importers_table[type2][type](reader.Value);
				}
				if (typeInfo.IsEnum)
				{
					return Enum.ToObject(type, reader.Value);
				}
				MethodInfo convOp = GetConvOp(type, type2);
				if (convOp != null)
				{
					return convOp.Invoke(null, new object[1] { reader.Value });
				}
				throw new JsonException($"Can't assign value '{reader.Value}' (type {type2}) to type {inst_type}");
			}
			object obj = null;
			if (reader.Token == JsonToken.ArrayStart)
			{
				AddArrayMetadata(inst_type);
				ArrayMetadata arrayMetadata = array_metadata[inst_type];
				if (!arrayMetadata.IsArray && !arrayMetadata.IsList)
				{
					throw new JsonException($"Type {inst_type} can't act as an array");
				}
				IList list;
				Type elementType;
				if (!arrayMetadata.IsArray)
				{
					list = (IList)Activator.CreateInstance(inst_type);
					elementType = arrayMetadata.ElementType;
				}
				else
				{
					list = new List<object>();
					elementType = inst_type.GetElementType();
				}
				while (true)
				{
					object value = ReadValue(elementType, reader);
					if (reader.Token == JsonToken.ArrayEnd)
					{
						break;
					}
					list.Add(value);
				}
				if (arrayMetadata.IsArray)
				{
					int count = list.Count;
					obj = Array.CreateInstance(elementType, count);
					for (int i = 0; i < count; i = checked(i + 1))
					{
						((Array)obj).SetValue(list[i], i);
					}
				}
				else
				{
					obj = list;
				}
			}
			else if (reader.Token == JsonToken.ObjectStart)
			{
				AddObjectMetadata(type);
				ObjectMetadata objectMetadata = object_metadata[type];
				obj = Activator.CreateInstance(type);
				while (true)
				{
					reader.Read();
					if (reader.Token == JsonToken.ObjectEnd)
					{
						break;
					}
					string text = (string)reader.Value;
					if (objectMetadata.Properties.ContainsKey(text))
					{
						PropertyMetadata propertyMetadata = objectMetadata.Properties[text];
						if (propertyMetadata.IsField)
						{
							((FieldInfo)propertyMetadata.Info).SetValue(obj, ReadValue(propertyMetadata.Type, reader));
							continue;
						}
						PropertyInfo propertyInfo = (PropertyInfo)propertyMetadata.Info;
						if (propertyInfo.CanWrite)
						{
							propertyInfo.SetValue(obj, ReadValue(propertyMetadata.Type, reader), null);
						}
						else
						{
							ReadValue(propertyMetadata.Type, reader);
						}
					}
					else
					{
						if (!objectMetadata.IsDictionary)
						{
							throw new JsonException($"The type {inst_type} doesn't have the property '{text}'");
						}
						((IDictionary)obj).Add(text, ReadValue(objectMetadata.ElementType, reader));
					}
				}
			}
			ValidateRequiredFields(obj, inst_type);
			return obj;
		}

		private static void ValidateRequiredFields(object instance, Type inst_type)
		{
			ITypeInfo typeInfo = TypeFactory.GetTypeInfo(inst_type);
			foreach (PropertyInfo property in typeInfo.GetProperties())
			{
				object[] customAttributes = property.GetCustomAttributes(typeof(JsonPropertyAttribute), inherit: false);
				if (customAttributes.Any())
				{
					JsonPropertyAttribute jsonPropertyAttribute = (JsonPropertyAttribute)customAttributes.First();
					if (typeInfo.GetProperty(property.Name).GetValue(instance, null) == null && jsonPropertyAttribute.Required)
					{
						throw new JsonException($"The type {instance.GetType()} doesn't have the required " + $"property '{property}' set");
					}
				}
			}
		}

		private static IJsonWrapper ReadValue(WrapperFactory factory, JsonReader reader)
		{
			reader.Read();
			if (reader.Token == JsonToken.ArrayEnd || reader.Token == JsonToken.Null)
			{
				return null;
			}
			IJsonWrapper jsonWrapper = factory();
			if (reader.Token == JsonToken.String)
			{
				jsonWrapper.SetString((string)reader.Value);
				return jsonWrapper;
			}
			if (reader.Token == JsonToken.Double)
			{
				jsonWrapper.SetDouble((double)reader.Value);
				return jsonWrapper;
			}
			if (reader.Token == JsonToken.Int)
			{
				jsonWrapper.SetInt((int)reader.Value);
				return jsonWrapper;
			}
			if (reader.Token == JsonToken.UInt)
			{
				jsonWrapper.SetUInt((uint)reader.Value);
				return jsonWrapper;
			}
			if (reader.Token == JsonToken.Long)
			{
				jsonWrapper.SetLong((long)reader.Value);
				return jsonWrapper;
			}
			if (reader.Token == JsonToken.ULong)
			{
				jsonWrapper.SetULong((ulong)reader.Value);
				return jsonWrapper;
			}
			if (reader.Token == JsonToken.Boolean)
			{
				jsonWrapper.SetBoolean((bool)reader.Value);
				return jsonWrapper;
			}
			if (reader.Token == JsonToken.ArrayStart)
			{
				jsonWrapper.SetJsonType(JsonType.Array);
				while (true)
				{
					IJsonWrapper jsonWrapper2 = ReadValue(factory, reader);
					if (jsonWrapper2 == null && reader.Token == JsonToken.ArrayEnd)
					{
						break;
					}
					jsonWrapper.Add(jsonWrapper2);
				}
			}
			else if (reader.Token == JsonToken.ObjectStart)
			{
				jsonWrapper.SetJsonType(JsonType.Object);
				while (true)
				{
					reader.Read();
					if (reader.Token == JsonToken.ObjectEnd)
					{
						break;
					}
					string key = (string)reader.Value;
					jsonWrapper[key] = ReadValue(factory, reader);
				}
			}
			return jsonWrapper;
		}

		private static void RegisterBaseExporters()
		{
			base_exporters_table[typeof(byte)] = delegate(object obj, JsonWriter writer)
			{
				writer.Write(Convert.ToInt32((byte)obj));
			};
			base_exporters_table[typeof(char)] = delegate(object obj, JsonWriter writer)
			{
				writer.Write(Convert.ToString((char)obj));
			};
			base_exporters_table[typeof(DateTime)] = delegate(object obj, JsonWriter writer)
			{
				writer.Write(Convert.ToString((DateTime)obj, datetime_format));
			};
			base_exporters_table[typeof(decimal)] = delegate(object obj, JsonWriter writer)
			{
				writer.Write((decimal)obj);
			};
			base_exporters_table[typeof(sbyte)] = delegate(object obj, JsonWriter writer)
			{
				writer.Write(Convert.ToInt32((sbyte)obj));
			};
			base_exporters_table[typeof(short)] = delegate(object obj, JsonWriter writer)
			{
				writer.Write(Convert.ToInt32((short)obj));
			};
			base_exporters_table[typeof(ushort)] = delegate(object obj, JsonWriter writer)
			{
				writer.Write(Convert.ToInt32((ushort)obj));
			};
			base_exporters_table[typeof(uint)] = delegate(object obj, JsonWriter writer)
			{
				writer.Write(Convert.ToUInt64((uint)obj));
			};
			base_exporters_table[typeof(ulong)] = delegate(object obj, JsonWriter writer)
			{
				writer.Write((ulong)obj);
			};
			base_exporters_table[typeof(float)] = delegate(object obj, JsonWriter writer)
			{
				writer.Write(Convert.ToDouble((float)obj));
			};
			base_exporters_table[typeof(long)] = delegate(object obj, JsonWriter writer)
			{
				writer.Write(Convert.ToDouble((long)obj));
			};
		}

		private static void RegisterBaseImporters()
		{
			ImporterFunc importer = (object input) => Convert.ToByte((int)input);
			RegisterImporter(base_importers_table, typeof(int), typeof(byte), importer);
			importer = (object input) => Convert.ToUInt64((int)input);
			RegisterImporter(base_importers_table, typeof(int), typeof(ulong), importer);
			importer = (object input) => Convert.ToSByte((int)input);
			RegisterImporter(base_importers_table, typeof(int), typeof(sbyte), importer);
			importer = (object input) => Convert.ToInt16((int)input);
			RegisterImporter(base_importers_table, typeof(int), typeof(short), importer);
			importer = (object input) => Convert.ToUInt16((int)input);
			RegisterImporter(base_importers_table, typeof(int), typeof(ushort), importer);
			importer = (object input) => Convert.ToUInt32((int)input);
			RegisterImporter(base_importers_table, typeof(int), typeof(uint), importer);
			importer = (object input) => Convert.ToSingle((int)input);
			RegisterImporter(base_importers_table, typeof(int), typeof(float), importer);
			importer = (object input) => Convert.ToDouble((int)input);
			RegisterImporter(base_importers_table, typeof(int), typeof(double), importer);
			importer = (object input) => Convert.ToDecimal((double)input);
			RegisterImporter(base_importers_table, typeof(double), typeof(decimal), importer);
			importer = (object input) => Convert.ToSingle((float)(double)input);
			RegisterImporter(base_importers_table, typeof(double), typeof(float), importer);
			importer = (object input) => Convert.ToUInt32((long)input);
			RegisterImporter(base_importers_table, typeof(long), typeof(uint), importer);
			importer = (object input) => Convert.ToChar((string)input);
			RegisterImporter(base_importers_table, typeof(string), typeof(char), importer);
			importer = (object input) => Convert.ToDateTime((string)input, datetime_format);
			RegisterImporter(base_importers_table, typeof(string), typeof(DateTime), importer);
			importer = (object input) => Convert.ToInt64((int)input);
			RegisterImporter(base_importers_table, typeof(int), typeof(long), importer);
		}

		private static void RegisterImporter(IDictionary<Type, IDictionary<Type, ImporterFunc>> table, Type json_type, Type value_type, ImporterFunc importer)
		{
			if (!table.ContainsKey(json_type))
			{
				table.Add(json_type, new Dictionary<Type, ImporterFunc>());
			}
			table[json_type][value_type] = importer;
		}

		private static void WriteValue(object obj, JsonWriter writer, bool writer_is_private, int depth)
		{
			if (depth > max_nesting_depth)
			{
				throw new JsonException($"Max allowed object depth reached while trying to export from type {obj.GetType()}");
			}
			if (obj == null)
			{
				writer.Write(null);
				return;
			}
			if (obj is IJsonWrapper)
			{
				if (writer_is_private)
				{
					writer.TextWriter.Write(((IJsonWrapper)obj).ToJson());
				}
				else
				{
					((IJsonWrapper)obj).ToJson(writer);
				}
				return;
			}
			if (obj is string)
			{
				writer.Write((string)obj);
				return;
			}
			if (obj is double)
			{
				writer.Write((double)obj);
				return;
			}
			if (obj is int)
			{
				writer.Write((int)obj);
				return;
			}
			if (obj is uint)
			{
				writer.Write((uint)obj);
				return;
			}
			if (obj is bool)
			{
				writer.Write((bool)obj);
				return;
			}
			if (obj is long)
			{
				writer.Write((long)obj);
				return;
			}
			if (obj is ulong)
			{
				writer.Write((ulong)obj);
			}
			checked
			{
				if (obj is Array)
				{
					writer.WriteArrayStart();
					foreach (object item in (Array)obj)
					{
						WriteValue(item, writer, writer_is_private, depth + 1);
					}
					writer.WriteArrayEnd();
					return;
				}
				if (obj is IList)
				{
					writer.WriteArrayStart();
					foreach (object item2 in (IList)obj)
					{
						WriteValue(item2, writer, writer_is_private, depth + 1);
					}
					writer.WriteArrayEnd();
					return;
				}
				if (obj is IDictionary)
				{
					writer.WriteObjectStart();
					foreach (DictionaryEntry item3 in (IDictionary)obj)
					{
						writer.WritePropertyName((string)item3.Key);
						WriteValue(item3.Value, writer, writer_is_private, depth + 1);
					}
					writer.WriteObjectEnd();
					return;
				}
				Type type = obj.GetType();
				if (custom_exporters_table.ContainsKey(type))
				{
					custom_exporters_table[type](obj, writer);
					return;
				}
				if (base_exporters_table.ContainsKey(type))
				{
					base_exporters_table[type](obj, writer);
					return;
				}
				if (obj is Enum)
				{
					Type underlyingType = Enum.GetUnderlyingType(type);
					if (underlyingType == typeof(long) || underlyingType == typeof(uint) || underlyingType == typeof(ulong))
					{
						writer.Write((ulong)obj);
					}
					else
					{
						writer.Write((int)obj);
					}
					return;
				}
				AddTypeProperties(type);
				IList<PropertyMetadata> list = type_properties[type];
				writer.WriteObjectStart();
				foreach (PropertyMetadata item4 in list)
				{
					if (item4.IsField)
					{
						writer.WritePropertyName(item4.Info.Name);
						WriteValue(((FieldInfo)item4.Info).GetValue(obj), writer, writer_is_private, depth + 1);
						continue;
					}
					PropertyInfo propertyInfo = (PropertyInfo)item4.Info;
					if (propertyInfo.CanRead)
					{
						writer.WritePropertyName(item4.Info.Name);
						WriteValue(propertyInfo.GetMethod.Invoke(obj, null), writer, writer_is_private, depth + 1);
					}
				}
				writer.WriteObjectEnd();
			}
		}

		public static string ToJson(object obj)
		{
			lock (static_writer_lock)
			{
				static_writer.Reset();
				WriteValue(obj, static_writer, writer_is_private: true, 0);
				return static_writer.ToString();
			}
		}

		public static void ToJson(object obj, JsonWriter writer)
		{
			WriteValue(obj, writer, writer_is_private: false, 0);
		}

		public static JsonData ToObject(JsonReader reader)
		{
			return (JsonData)ToWrapper(() => new JsonData(), reader);
		}

		public static JsonData ToObject(TextReader reader)
		{
			JsonReader reader2 = new JsonReader(reader);
			return (JsonData)ToWrapper(() => new JsonData(), reader2);
		}

		public static JsonData ToObject(string json)
		{
			return (JsonData)ToWrapper(() => new JsonData(), json);
		}

		public static T ToObject<T>(JsonReader reader)
		{
			return (T)ReadValue(typeof(T), reader);
		}

		public static T ToObject<T>(TextReader reader)
		{
			JsonReader reader2 = new JsonReader(reader);
			return (T)ReadValue(typeof(T), reader2);
		}

		public static T ToObject<T>(string json)
		{
			JsonReader reader = new JsonReader(json);
			return (T)ReadValue(typeof(T), reader);
		}

		public static IJsonWrapper ToWrapper(WrapperFactory factory, JsonReader reader)
		{
			return ReadValue(factory, reader);
		}

		public static IJsonWrapper ToWrapper(WrapperFactory factory, string json)
		{
			JsonReader reader = new JsonReader(json);
			return ReadValue(factory, reader);
		}

		public static void RegisterExporter<T>(ExporterFunc<T> exporter)
		{
			ExporterFunc value = delegate(object obj, JsonWriter writer)
			{
				exporter((T)obj, writer);
			};
			custom_exporters_table[typeof(T)] = value;
		}

		public static void RegisterImporter<TJson, TValue>(ImporterFunc<TJson, TValue> importer)
		{
			ImporterFunc importer2 = (object input) => importer((TJson)input);
			RegisterImporter(custom_importers_table, typeof(TJson), typeof(TValue), importer2);
		}

		public static void UnregisterExporters()
		{
			custom_exporters_table.Clear();
		}

		public static void UnregisterImporters()
		{
			custom_importers_table.Clear();
		}
	}
	[AttributeUsage(AttributeTargets.Property)]
	public class JsonPropertyAttribute : Attribute
	{
		public bool Required { get; set; }
	}
	public enum JsonToken
	{
		None,
		ObjectStart,
		PropertyName,
		ObjectEnd,
		ArrayStart,
		ArrayEnd,
		Int,
		UInt,
		Long,
		ULong,
		Double,
		String,
		Boolean,
		Null
	}
	public class JsonReader
	{
		private Stack<JsonToken> depth = new Stack<JsonToken>();

		private int current_input;

		private int current_symbol;

		private bool end_of_json;

		private bool end_of_input;

		private Lexer lexer;

		private bool parser_in_string;

		private bool parser_return;

		private bool read_started;

		private TextReader reader;

		private bool reader_is_owned;

		private object token_value;

		private JsonToken token;

		public bool AllowComments
		{
			get
			{
				return lexer.AllowComments;
			}
			set
			{
				lexer.AllowComments = value;
			}
		}

		public bool AllowSingleQuotedStrings
		{
			get
			{
				return lexer.AllowSingleQuotedStrings;
			}
			set
			{
				lexer.AllowSingleQuotedStrings = value;
			}
		}

		public bool EndOfInput => end_of_input;

		public bool EndOfJson => end_of_json;

		public JsonToken Token => token;

		public object Value => token_value;

		public JsonReader(string json_text)
			: this(new StringReader(json_text), owned: true)
		{
		}

		public JsonReader(TextReader reader)
			: this(reader, owned: false)
		{
		}

		private JsonReader(TextReader reader, bool owned)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			parser_in_string = false;
			parser_return = false;
			read_started = false;
			lexer = new Lexer(reader);
			end_of_input = false;
			end_of_json = false;
			this.reader = reader;
			reader_is_owned = owned;
		}

		private void ProcessNumber(string number)
		{
			int result2;
			uint result3;
			long result4;
			ulong result5;
			if ((number.IndexOf('.') != -1 || number.IndexOf('e') != -1 || number.IndexOf('E') != -1) && double.TryParse(number, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
			{
				token = JsonToken.Double;
				token_value = result;
			}
			else if (int.TryParse(number, NumberStyles.Any, CultureInfo.InvariantCulture, out result2))
			{
				token = JsonToken.Int;
				token_value = result2;
			}
			else if (uint.TryParse(number, NumberStyles.Any, CultureInfo.InvariantCulture, out result3))
			{
				token = JsonToken.UInt;
				token_value = result3;
			}
			else if (long.TryParse(number, NumberStyles.Any, CultureInfo.InvariantCulture, out result4))
			{
				token = JsonToken.Long;
				token_value = result4;
			}
			else if (ulong.TryParse(number, NumberStyles.Any, CultureInfo.InvariantCulture, out result5))
			{
				token = JsonToken.ULong;
				token_value = result5;
			}
			else
			{
				token = JsonToken.ULong;
				token_value = 0uL;
			}
		}

		private void ProcessSymbol()
		{
			if (current_symbol == 91)
			{
				token = JsonToken.ArrayStart;
				parser_return = true;
			}
			else if (current_symbol == 93)
			{
				token = JsonToken.ArrayEnd;
				parser_return = true;
			}
			else if (current_symbol == 123)
			{
				token = JsonToken.ObjectStart;
				parser_return = true;
			}
			else if (current_symbol == 125)
			{
				token = JsonToken.ObjectEnd;
				parser_return = true;
			}
			else if (current_symbol == 34)
			{
				if (parser_in_string)
				{
					parser_in_string = false;
					parser_return = true;
					return;
				}
				if (token == JsonToken.None)
				{
					token = JsonToken.String;
				}
				parser_in_string = true;
			}
			else if (current_symbol == 65541)
			{
				token_value = lexer.StringValue;
			}
			else if (current_symbol == 65539)
			{
				token = JsonToken.Boolean;
				token_value = false;
				parser_return = true;
			}
			else if (current_symbol == 65540)
			{
				token = JsonToken.Null;
				parser_return = true;
			}
			else if (current_symbol == 65537)
			{
				ProcessNumber(lexer.StringValue);
				parser_return = true;
			}
			else if (current_symbol == 65546)
			{
				token = JsonToken.PropertyName;
			}
			else if (current_symbol == 65538)
			{
				token = JsonToken.Boolean;
				token_value = true;
				parser_return = true;
			}
		}

		private bool ReadToken()
		{
			if (end_of_input)
			{
				return false;
			}
			lexer.NextToken();
			if (lexer.EndOfInput)
			{
				Close();
				return false;
			}
			current_input = lexer.Token;
			return true;
		}

		public void Close()
		{
			if (!end_of_input)
			{
				end_of_input = true;
				end_of_json = true;
				reader = null;
			}
		}

		public bool Read()
		{
			if (end_of_input)
			{
				return false;
			}
			if (end_of_json)
			{
				end_of_json = false;
			}
			token = JsonToken.None;
			parser_in_string = false;
			parser_return = false;
			if (!read_started)
			{
				read_started = true;
				if (!ReadToken())
				{
					return false;
				}
			}
			do
			{
				current_symbol = current_input;
				ProcessSymbol();
				if (!parser_return)
				{
					continue;
				}
				if (token == JsonToken.ObjectStart || token == JsonToken.ArrayStart)
				{
					depth.Push(token);
				}
				else if (token == JsonToken.ObjectEnd || token == JsonToken.ArrayEnd)
				{
					if (depth.Peek() == JsonToken.PropertyName)
					{
						depth.Pop();
					}
					JsonToken jsonToken = depth.Pop();
					if (token == JsonToken.ObjectEnd && jsonToken != JsonToken.ObjectStart)
					{
						throw new JsonException("Error: Current token is ObjectEnd which does not match the opening " + jsonToken);
					}
					if (token == JsonToken.ArrayEnd && jsonToken != JsonToken.ArrayStart)
					{
						throw new JsonException("Error: Current token is ArrayEnd which does not match the opening " + jsonToken);
					}
					if (depth.Count == 0)
					{
						end_of_json = true;
					}
				}
				else if (depth.Count > 0 && depth.Peek() != JsonToken.PropertyName && token == JsonToken.String && depth.Peek() == JsonToken.ObjectStart)
				{
					token = JsonToken.PropertyName;
					depth.Push(token);
				}
				if (token == JsonToken.ObjectEnd || token == JsonToken.ArrayEnd || token == JsonToken.String || token == JsonToken.Boolean || token == JsonToken.Double || token == JsonToken.Int || token == JsonToken.UInt || token == JsonToken.Long || token == JsonToken.ULong || token == JsonToken.Null)
				{
					if (depth.Count == 0)
					{
						if (token != JsonToken.ArrayEnd && token != JsonToken.ObjectEnd)
						{
							throw new JsonException("Value without enclosing object or array");
						}
					}
					else if (depth.Peek() == JsonToken.PropertyName)
					{
						depth.Pop();
					}
				}
				if (!ReadToken() && depth.Count != 0)
				{
					throw new JsonException("Incomplete JSON Document");
				}
				return true;
			}
			while (ReadToken());
			if (depth.Count != 0)
			{
				throw new JsonException("Incomplete JSON Document");
			}
			end_of_input = true;
			return false;
		}
	}
	internal enum Condition
	{
		InArray,
		InObject,
		NotAProperty,
		Property,
		Value
	}
	internal class WriterContext
	{
		public int Count;

		public bool InArray;

		public bool InObject;

		public bool ExpectingValue;

		public int Padding;
	}
	public class JsonWriter
	{
		private static NumberFormatInfo number_format;

		private WriterContext context;

		private Stack<WriterContext> ctx_stack;

		private bool has_reached_end;

		private char[] hex_seq;

		private int indentation;

		private int indent_value;

		private StringBuilder inst_string_builder;

		private bool pretty_print;

		private bool validate;

		private TextWriter writer;

		public int IndentValue
		{
			get
			{
				return indent_value;
			}
			set
			{
				checked
				{
					indentation = unchecked(indentation / indent_value) * value;
					indent_value = value;
				}
			}
		}

		public bool PrettyPrint
		{
			get
			{
				return pretty_print;
			}
			set
			{
				pretty_print = value;
			}
		}

		public TextWriter TextWriter => writer;

		public bool Validate
		{
			get
			{
				return validate;
			}
			set
			{
				validate = value;
			}
		}

		static JsonWriter()
		{
			number_format = NumberFormatInfo.InvariantInfo;
		}

		public JsonWriter()
		{
			inst_string_builder = new StringBuilder();
			writer = new StringWriter(inst_string_builder);
			Init();
		}

		public JsonWriter(StringBuilder sb)
			: this(new StringWriter(sb))
		{
		}

		public JsonWriter(TextWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			this.writer = writer;
			Init();
		}

		private void DoValidation(Condition cond)
		{
			checked
			{
				if (!context.ExpectingValue)
				{
					context.Count++;
				}
				if (!validate)
				{
					return;
				}
				if (has_reached_end)
				{
					throw new JsonException("A complete JSON symbol has already been written");
				}
				switch (cond)
				{
				case Condition.InArray:
					if (!context.InArray)
					{
						throw new JsonException("Can't close an array here");
					}
					break;
				case Condition.InObject:
					if (!context.InObject || context.ExpectingValue)
					{
						throw new JsonException("Can't close an object here");
					}
					break;
				case Condition.NotAProperty:
					if (context.InObject && !context.ExpectingValue)
					{
						throw new JsonException("Expected a property");
					}
					break;
				case Condition.Property:
					if (!context.InObject || context.ExpectingValue)
					{
						throw new JsonException("Can't add a property here");
					}
					break;
				case Condition.Value:
					if (!context.InArray && (!context.InObject || !context.ExpectingValue))
					{
						throw new JsonException("Can't add a value here");
					}
					break;
				}
			}
		}

		private void Init()
		{
			has_reached_end = false;
			hex_seq = new char[4];
			indentation = 0;
			indent_value = 4;
			pretty_print = false;
			validate = true;
			ctx_stack = new Stack<WriterContext>();
			context = new WriterContext();
			ctx_stack.Push(context);
		}

		private static void IntToHex(int n, char[] hex)
		{
			for (int i = 0; i < 4; i = checked(i + 1))
			{
				int num = n % 16;
				if (num < 10)
				{
					hex[checked(3 - i)] = (char)checked((ushort)(48 + num));
				}
				else
				{
					hex[checked(3 - i)] = (char)checked((ushort)(65 + (num - 10)));
				}
				n >>= 4;
			}
		}

		private void Indent()
		{
			checked
			{
				if (pretty_print)
				{
					indentation += indent_value;
				}
			}
		}

		private void Put(string str)
		{
			if (pretty_print && !context.ExpectingValue)
			{
				for (int i = 0; i < indentation; i = checked(i + 1))
				{
					writer.Write(' ');
				}
			}
			writer.Write(str);
		}

		private void PutNewline()
		{
			PutNewline(add_comma: true);
		}

		private void PutNewline(bool add_comma)
		{
			if (add_comma && !context.ExpectingValue && context.Count > 1)
			{
				writer.Write(',');
			}
			if (pretty_print && !context.ExpectingValue)
			{
				writer.Write("\r\n");
			}
		}

		private void PutString(string str)
		{
			Put(string.Empty);
			writer.Write('"');
			int length = str.Length;
			for (int i = 0; i < length; i = checked(i + 1))
			{
				char c = str[i];
				switch (c)
				{
				case '\n':
					writer.Write("\\n");
					continue;
				case '\r':
					writer.Write("\\r");
					continue;
				case '\t':
					writer.Write("\\t");
					continue;
				case '"':
				case '\\':
					writer.Write('\\');
					writer.Write(c);
					continue;
				case '\f':
					writer.Write("\\f");
					continue;
				case '\b':
					writer.Write("\\b");
					continue;
				}
				if (c >= ' ' && c <= '~')
				{
					writer.Write(c);
				}
				else if (c < ' ' || (c >= '\u0080' && c < '\u00a0'))
				{
					IntToHex(c, hex_seq);
					writer.Write("\\u");
					writer.Write(hex_seq);
				}
				else
				{
					writer.Write(c);
				}
			}
			writer.Write('"');
		}

		private void Unindent()
		{
			checked
			{
				if (pretty_print)
				{
					indentation -= indent_value;
				}
			}
		}

		public override string ToString()
		{
			if (inst_string_builder == null)
			{
				return string.Empty;
			}
			return inst_string_builder.ToString();
		}

		public void Reset()
		{
			has_reached_end = false;
			ctx_stack.Clear();
			context = new WriterContext();
			ctx_stack.Push(context);
			if (inst_string_builder != null)
			{
				inst_string_builder.Remove(0, inst_string_builder.Length);
			}
		}

		public void Write(bool boolean)
		{
			DoValidation(Condition.Value);
			PutNewline();
			Put(boolean ? "true" : "false");
			context.ExpectingValue = false;
		}

		public void Write(decimal number)
		{
			DoValidation(Condition.Value);
			PutNewline();
			Put(Convert.ToString(number, number_format));
			context.ExpectingValue = false;
		}

		public void Write(double number)
		{
			DoValidation(Condition.Value);
			PutNewline();
			string text = number.ToString("R", CultureInfo.InvariantCulture);
			Put(text);
			if (text.IndexOf('.') == -1 && text.IndexOf('E') == -1)
			{
				writer.Write(".0");
			}
			context.ExpectingValue = false;
		}

		public void Write(int number)
		{
			DoValidation(Condition.Value);
			PutNewline();
			Put(Convert.ToString(number, number_format));
			context.ExpectingValue = false;
		}

		public void Write(uint number)
		{
			DoValidation(Condition.Value);
			PutNewline();
			Put(Convert.ToString(number, number_format));
			context.ExpectingValue = false;
		}

		public void Write(long number)
		{
			DoValidation(Condition.Value);
			PutNewline();
			Put(Convert.ToString(number, number_format));
			context.ExpectingValue = false;
		}

		public void Write(string str)
		{
			DoValidation(Condition.Value);
			PutNewline();
			if (str == null)
			{
				Put("null");
			}
			else
			{
				PutString(str);
			}
			context.ExpectingValue = false;
		}

		public void WriteRaw(string str)
		{
			DoValidation(Condition.Value);
			PutNewline();
			if (str == null)
			{
				Put("null");
			}
			else
			{
				Put(str);
			}
			context.ExpectingValue = false;
		}

		[CLSCompliant(false)]
		public void Write(ulong number)
		{
			DoValidation(Condition.Value);
			PutNewline();
			Put(Convert.ToString(number, number_format));
			context.ExpectingValue = false;
		}

		public void Write(DateTime date)
		{
			DoValidation(Condition.Value);
			PutNewline();
			Put(AWSSDKUtils.ConvertToUnixEpochSecondsDouble(date).ToString(CultureInfo.InvariantCulture));
			context.ExpectingValue = false;
		}

		public void WriteArrayEnd()
		{
			DoValidation(Condition.InArray);
			PutNewline(add_comma: false);
			ctx_stack.Pop();
			if (ctx_stack.Count == 1)
			{
				has_reached_end = true;
			}
			else
			{
				context = ctx_stack.Peek();
				context.ExpectingValue = false;
			}
			Unindent();
			Put("]");
		}

		public void WriteArrayStart()
		{
			DoValidation(Condition.NotAProperty);
			PutNewline();
			Put("[");
			context = new WriterContext();
			context.InArray = true;
			ctx_stack.Push(context);
			Indent();
		}

		public void WriteObjectEnd()
		{
			DoValidation(Condition.InObject);
			PutNewline(add_comma: false);
			ctx_stack.Pop();
			if (ctx_stack.Count == 1)
			{
				has_reached_end = true;
			}
			else
			{
				context = ctx_stack.Peek();
				context.ExpectingValue = false;
			}
			Unindent();
			Put("}");
		}

		public void WriteObjectStart()
		{
			DoValidation(Condition.NotAProperty);
			PutNewline();
			Put("{");
			context = new WriterContext();
			context.InObject = true;
			ctx_stack.Push(context);
			Indent();
		}

		public void WritePropertyName(string property_name)
		{
			DoValidation(Condition.Property);
			PutNewline();
			PutString(property_name);
			checked
			{
				if (pretty_print)
				{
					if (property_name.Length > context.Padding)
					{
						context.Padding = property_name.Length;
					}
					for (int num = context.Padding - property_name.Length; num >= 0; num--)
					{
						writer.Write(' ');
					}
					writer.Write(": ");
				}
				else
				{
					writer.Write(':');
				}
				context.ExpectingValue = true;
			}
		}
	}
	internal class FsmContext
	{
		public bool Return;

		public int NextState;

		public Lexer L;

		public int StateStack;
	}
	internal class Lexer
	{
		private delegate bool StateHandler(FsmContext ctx);

		private static int[] fsm_return_table;

		private static StateHandler[] fsm_handler_table;

		private bool allow_comments;

		private bool allow_single_quoted_strings;

		private bool end_of_input;

		private FsmContext fsm_context;

		private int input_buffer;

		private int input_char;

		private TextReader reader;

		private int state;

		private StringBuilder string_buffer;

		private string string_value;

		private int token;

		private int unichar;

		public bool AllowComments
		{
			get
			{
				return allow_comments;
			}
			set
			{
				allow_comments = value;
			}
		}

		public bool AllowSingleQuotedStrings
		{
			get
			{
				return allow_single_quoted_strings;
			}
			set
			{
				allow_single_quoted_strings = value;
			}
		}

		public bool EndOfInput => end_of_input;

		public int Token => token;

		public string StringValue => string_value;

		static Lexer()
		{
			PopulateFsmTables();
		}

		public Lexer(TextReader reader)
		{
			allow_comments = true;
			allow_single_quoted_strings = true;
			input_buffer = 0;
			string_buffer = new StringBuilder(128);
			state = 1;
			end_of_input = false;
			this.reader = reader;
			fsm_context = new FsmContext();
			fsm_context.L = this;
		}

		private static int HexValue(int digit)
		{
			switch (digit)
			{
			case 65:
			case 97:
				return 10;
			case 66:
			case 98:
				return 11;
			case 67:
			case 99:
				return 12;
			case 68:
			case 100:
				return 13;
			case 69:
			case 101:
				return 14;
			case 70:
			case 102:
				return 15;
			default:
				return checked(digit - 48);
			}
		}

		private static void PopulateFsmTables()
		{
			fsm_handler_table = new StateHandler[28]
			{
				State1, State2, State3, State4, State5, State6, State7, State8, State9, State10,
				State11, State12, State13, State14, State15, State16, State17, State18, State19, State20,
				State21, State22, State23, State24, State25, State26, State27, State28
			};
			fsm_return_table = new int[28]
			{
				65542, 0, 65537, 65537, 0, 65537, 0, 65537, 0, 0,
				65538, 0, 0, 0, 65539, 0, 0, 65540, 65541, 65542,
				0, 0, 65541, 65542, 0, 0, 0, 0
			};
		}

		private static char ProcessEscChar(int esc_char)
		{
			switch (esc_char)
			{
			case 34:
			case 39:
			case 47:
			case 92:
				return Convert.ToChar(esc_char);
			case 110:
				return '\n';
			case 116:
				return '\t';
			case 114:
				return '\r';
			case 98:
				return '\b';
			case 102:
				return '\f';
			default:
				return '?';
			}
		}

		private static bool State1(FsmContext ctx)
		{
			while (ctx.L.GetChar())
			{
				if (ctx.L.input_char == 32 || (ctx.L.input_char >= 9 && ctx.L.input_char <= 13))
				{
					continue;
				}
				if (ctx.L.input_char >= 49 && ctx.L.input_char <= 57)
				{
					ctx.L.string_buffer.Append((char)checked((ushort)ctx.L.input_char));
					ctx.NextState = 3;
					return true;
				}
				switch (ctx.L.input_char)
				{
				case 34:
					ctx.NextState = 19;
					ctx.Return = true;
					return true;
				case 44:
				case 58:
				case 91:
				case 93:
				case 123:
				case 125:
					ctx.NextState = 1;
					ctx.Return = true;
					return true;
				case 45:
					ctx.L.string_buffer.Append((char)checked((ushort)ctx.L.input_char));
					ctx.NextState = 2;
					return true;
				case 48:
					ctx.L.string_buffer.Append((char)checked((ushort)ctx.L.input_char));
					ctx.NextState = 4;
					return true;
				case 102:
					ctx.NextState = 12;
					return true;
				case 110:
					ctx.NextState = 16;
					return true;
				case 116:
					ctx.NextState = 9;
					return true;
				case 39:
					if (!ctx.L.allow_single_quoted_strings)
					{
						return false;
					}
					ctx.L.input_char = 34;
					ctx.NextState = 23;
					ctx.Return = true;
					return true;
				case 47:
					if (!ctx.L.allow_comments)
					{
						return false;
					}
					ctx.NextState = 25;
					return true;
				default:
					return false;
				}
			}
			return true;
		}

		private static bool State2(FsmContext ctx)
		{
			ctx.L.GetChar();
			if (ctx.L.input_char >= 49 && ctx.L.input_char <= 57)
			{
				ctx.L.string_buffer.Append((char)checked((ushort)ctx.L.input_char));
				ctx.NextState = 3;
				return true;
			}
			int num = ctx.L.input_char;
			if (num == 48)
			{
				ctx.L.string_buffer.Append((char)checked((ushort)ctx.L.input_char));
				ctx.NextState = 4;
				return true;
			}
			return false;
		}

		private static bool State3(FsmContext ctx)
		{
			while (ctx.L.GetChar())
			{
				if (ctx.L.input_char >= 48 && ctx.L.input_char <= 57)
				{
					ctx.L.string_buffer.Append((char)checked((ushort)ctx.L.input_char));
					continue;
				}
				if (ctx.L.input_char == 32 || (ctx.L.input_char >= 9 && ctx.L.input_char <= 13))
				{
					ctx.Return = true;
					ctx.NextState = 1;
					return true;
				}
				switch (ctx.L.input_char)
				{
				case 44:
				case 93:
				case 125:
					ctx.L.UngetChar();
					ctx.Return = true;
					ctx.NextState = 1;
					return true;
				case 46:
					ctx.L.string_buffer.Append((char)checked((ushort)ctx.L.input_char));
					ctx.NextState = 5;
					return true;
				case 69:
				case 101:
					ctx.L.string_buffer.Append((char)checked((ushort)ctx.L.input_char));
					ctx.NextState = 7;
					return true;
				default:
					return false;
				}
			}
			return true;
		}

		private static bool State4(FsmContext ctx)
		{
			ctx.L.GetChar();
			if (ctx.L.input_char == 32 || (ctx.L.input_char >= 9 && ctx.L.input_char <= 13))
			{
				ctx.Return = true;
				ctx.NextState = 1;
				return true;
			}
			switch (ctx.L.input_char)
			{
			case 44:
			case 93:
			case 125:
				ctx.L.UngetChar();
				ctx.Return = true;
				ctx.NextState = 1;
				return true;
			case 46:
				ctx.L.string_buffer.Append((char)checked((ushort)ctx.L.input_char));
				ctx.NextState = 5;
				return true;
			case 69:
			case 101:
				ctx.L.string_buffer.Append((char)checked((ushort)ctx.L.input_char));
				ctx.NextState = 7;
				return true;
			default:
				return false;
			}
		}

		private static bool State5(FsmContext ctx)
		{
			ctx.L.GetChar();
			if (ctx.L.input_char >= 48 && ctx.L.input_char <= 57)
			{
				ctx.L.string_buffer.Append((char)checked((ushort)ctx.L.input_char));
				ctx.NextState = 6;
				return true;
			}
			return false;
		}

		private static bool State6(FsmContext ctx)
		{
			while (ctx.L.GetChar())
			{
				if (ctx.L.input_char >= 48 && ctx.L.input_char <= 57)
				{
					ctx.L.string_buffer.Append((char)checked((ushort)ctx.L.input_char));
					continue;
				}
				if (ctx.L.input_char == 32 || (ctx.L.input_char >= 9 && ctx.L.input_char <= 13))
				{
					ctx.Return = true;
					ctx.NextState = 1;
					return true;
				}
				switch (ctx.L.input_char)
				{
				case 44:
				case 93:
				case 125:
					ctx.L.UngetChar();
					ctx.Return = true;
					ctx.NextState = 1;
					return true;
				case 69:
				case 101:
					ctx.L.string_buffer.Append((char)checked((ushort)ctx.L.input_char));
					ctx.NextState = 7;
					return true;
				default:
					return false;
				}
			}
			return true;
		}

		private static bool State7(FsmContext ctx)
		{
			ctx.L.GetChar();
			if (ctx.L.input_char >= 48 && ctx.L.input_char <= 57)
			{
				ctx.L.string_buffer.Append((char)checked((ushort)ctx.L.input_char));
				ctx.NextState = 8;
				return true;
			}
			int num = ctx.L.input_char;
			if (num == 43 || num == 45)
			{
				ctx.L.string_buffer.Append((char)checked((ushort)ctx.L.input_char));
				ctx.NextState = 8;
				return true;
			}
			return false;
		}

		private static bool State8(FsmContext ctx)
		{
			while (ctx.L.GetChar())
			{
				if (ctx.L.input_char >= 48 && ctx.L.input_char <= 57)
				{
					ctx.L.string_buffer.Append((char)checked((ushort)ctx.L.input_char));
					continue;
				}
				if (ctx.L.input_char == 32 || (ctx.L.input_char >= 9 && ctx.L.input_char <= 13))
				{
					ctx.Return = true;
					ctx.NextState = 1;
					return true;
				}
				int num = ctx.L.input_char;
				if (num == 44 || num == 93 || num == 125)
				{
					ctx.L.UngetChar();
					ctx.Return = true;
					ctx.NextState = 1;
					return true;
				}
				return false;
			}
			return true;
		}

		private static bool State9(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num == 114)
			{
				ctx.NextState = 10;
				return true;
			}
			return false;
		}

		private static bool State10(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num == 117)
			{
				ctx.NextState = 11;
				return true;
			}
			return false;
		}

		private static bool State11(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num == 101)
			{
				ctx.Return = true;
				ctx.NextState = 1;
				return true;
			}
			return false;
		}

		private static bool State12(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num == 97)
			{
				ctx.NextState = 13;
				return true;
			}
			return false;
		}

		private static bool State13(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num == 108)
			{
				ctx.NextState = 14;
				return true;
			}
			return false;
		}

		private static bool State14(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num == 115)
			{
				ctx.NextState = 15;
				return true;
			}
			return false;
		}

		private static bool State15(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num == 101)
			{
				ctx.Return = true;
				ctx.NextState = 1;
				return true;
			}
			return false;
		}

		private static bool State16(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num == 117)
			{
				ctx.NextState = 17;
				return true;
			}
			return false;
		}

		private static bool State17(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num == 108)
			{
				ctx.NextState = 18;
				return true;
			}
			return false;
		}

		private static bool State18(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num == 108)
			{
				ctx.Return = true;
				ctx.NextState = 1;
				return true;
			}
			return false;
		}

		private static bool State19(FsmContext ctx)
		{
			while (ctx.L.GetChar())
			{
				switch (ctx.L.input_char)
				{
				case 34:
					ctx.L.UngetChar();
					ctx.Return = true;
					ctx.NextState = 20;
					return true;
				case 92:
					ctx.StateStack = 19;
					ctx.NextState = 21;
					return true;
				}
				ctx.L.string_buffer.Append((char)checked((ushort)ctx.L.input_char));
			}
			return true;
		}

		private static bool State20(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num == 34)
			{
				ctx.Return = true;
				ctx.NextState = 1;
				return true;
			}
			return false;
		}

		private static bool State21(FsmContext ctx)
		{
			ctx.L.GetChar();
			switch (ctx.L.input_char)
			{
			case 117:
				ctx.NextState = 22;
				return true;
			case 34:
			case 39:
			case 47:
			case 92:
			case 98:
			case 102:
			case 110:
			case 114:
			case 116:
				ctx.L.string_buffer.Append(ProcessEscChar(ctx.L.input_char));
				ctx.NextState = ctx.StateStack;
				return true;
			default:
				return false;
			}
		}

		private static bool State22(FsmContext ctx)
		{
			int num = 0;
			int num2 = 4096;
			ctx.L.unichar = 0;
			while (ctx.L.GetChar())
			{
				if ((ctx.L.input_char >= 48 && ctx.L.input_char <= 57) || (ctx.L.input_char >= 65 && ctx.L.input_char <= 70) || (ctx.L.input_char >= 97 && ctx.L.input_char <= 102))
				{
					checked
					{
						ctx.L.unichar += HexValue(ctx.L.input_char) * num2;
						num++;
					}
					num2 /= 16;
					if (num == 4)
					{
						ctx.L.string_buffer.Append(Convert.ToChar(ctx.L.unichar));
						ctx.NextState = ctx.StateStack;
						return true;
					}
					continue;
				}
				return false;
			}
			return true;
		}

		private static bool State23(FsmContext ctx)
		{
			while (ctx.L.GetChar())
			{
				switch (ctx.L.input_char)
				{
				case 39:
					ctx.L.UngetChar();
					ctx.Return = true;
					ctx.NextState = 24;
					return true;
				case 92:
					ctx.StateStack = 23;
					ctx.NextState = 21;
					return true;
				}
				ctx.L.string_buffer.Append((char)checked((ushort)ctx.L.input_char));
			}
			return true;
		}

		private static bool State24(FsmContext ctx)
		{
			ctx.L.GetChar();
			int num = ctx.L.input_char;
			if (num == 39)
			{
				ctx.L.input_char = 34;
				ctx.Return = true;
				ctx.NextState = 1;
				return true;
			}
			return false;
		}

		private static bool State25(FsmContext ctx)
		{
			ctx.L.GetChar();
			switch (ctx.L.input_char)
			{
			case 42:
				ctx.NextState = 27;
				return true;
			case 47:
				ctx.NextState = 26;
				return true;
			default:
				return false;
			}
		}

		private static bool State26(FsmContext ctx)
		{
			while (ctx.L.GetChar())
			{
				if (ctx.L.input_char == 10)
				{
					ctx.NextState = 1;
					return true;
				}
			}
			return true;
		}

		private static bool State27(FsmContext ctx)
		{
			while (ctx.L.GetChar())
			{
				if (ctx.L.input_char == 42)
				{
					ctx.NextState = 28;
					return true;
				}
			}
			return true;
		}

		private static bool State28(FsmContext ctx)
		{
			while (ctx.L.GetChar())
			{
				if (ctx.L.input_char != 42)
				{
					if (ctx.L.input_char == 47)
					{
						ctx.NextState = 1;
						return true;
					}
					ctx.NextState = 27;
					return true;
				}
			}
			return true;
		}

		private bool GetChar()
		{
			if ((input_char = NextChar()) != -1)
			{
				return true;
			}
			end_of_input = true;
			return false;
		}

		private int NextChar()
		{
			if (input_buffer != 0)
			{
				int result = input_buffer;
				input_buffer = 0;
				return result;
			}
			return reader.Read();
		}

		public bool NextToken()
		{
			fsm_context.Return = false;
			checked
			{
				while (true)
				{
					if (!fsm_handler_table[state - 1](fsm_context))
					{
						throw new JsonException(input_char);
					}
					if (end_of_input)
					{
						return false;
					}
					if (fsm_context.Return)
					{
						break;
					}
					state = fsm_context.NextState;
				}
				string_value = string_buffer.ToString();
				string_buffer.Length = 0;
				token = fsm_return_table[state - 1];
				if (token == 65542)
				{
					token = input_char;
				}
				state = fsm_context.NextState;
				return true;
			}
		}

		private void UngetChar()
		{
			input_buffer = input_char;
		}
	}
	internal enum ParserToken
	{
		None = 65536,
		Number,
		True,
		False,
		Null,
		CharSeq,
		Char,
		Text,
		Object,
		ObjectPrime,
		Pair,
		PairRest,
		Array,
		ArrayPrime,
		Value,
		ValueRest,
		String,
		End,
		Epsilon
	}
}
namespace ThirdParty.Ionic.Zlib
{
	internal class CRC32
	{
		private long _TotalBytesRead;

		private static uint[] crc32Table;

		private const int BUFFER_SIZE = 8192;

		private uint _RunningCrc32Result = 4294967295u;

		public long TotalBytesRead => _TotalBytesRead;

		public int Crc32Result => (int)(~_RunningCrc32Result);

		public int GetCrc32(Stream input)
		{
			return GetCrc32AndCopy(input, null);
		}

		public int GetCrc32AndCopy(Stream input, Stream output)
		{
			byte[] array = new byte[8192];
			int count = 8192;
			_TotalBytesRead = 0L;
			int num = input.Read(array, 0, count);
			output?.Write(array, 0, num);
			_TotalBytesRead += num;
			while (num > 0)
			{
				SlurpBlock(array, 0, num);
				num = input.Read(array, 0, count);
				output?.Write(array, 0, num);
				_TotalBytesRead += num;
			}
			return (int)(~_RunningCrc32Result);
		}

		public int ComputeCrc32(int W, byte B)
		{
			return _InternalComputeCrc32(checked((uint)W), B);
		}

		internal int _InternalComputeCrc32(uint W, byte B)
		{
			return checked((int)(crc32Table[(W ^ B) & 0xFF] ^ (W >> 8)));
		}

		public void SlurpBlock(byte[] block, int offset, int count)
		{
			checked
			{
				for (int i = 0; i < count; i++)
				{
					int num = offset + i;
					_RunningCrc32Result = (_RunningCrc32Result >> 8) ^ crc32Table[block[num] ^ (_RunningCrc32Result & 0xFF)];
				}
				_TotalBytesRead += count;
			}
		}

		static CRC32()
		{
			uint num = 3988292384u;
			crc32Table = new uint[256];
			for (uint num2 = 0u; num2 < 256; num2++)
			{
				uint num3 = num2;
				for (uint num4 = 8u; num4 != 0; num4--)
				{
					num3 = (((num3 & 1) != 1) ? (num3 >> 1) : ((num3 >> 1) ^ num));
				}
				crc32Table[num2] = num3;
			}
		}
	}
	public class CrcCalculatorStream : Stream
	{
		private Stream _InnerStream;

		private CRC32 _Crc32;

		private long _length;

		public long TotalBytesSlurped => _Crc32.TotalBytesRead;

		public int Crc32 => _Crc32.Crc32Result;

		public override bool CanRead => _InnerStream.CanRead;

		public override bool CanSeek => _InnerStream.CanSeek;

		public override bool CanWrite => _InnerStream.CanWrite;

		public override long Length
		{
			get
			{
				if (_length == 0L)
				{
					throw new NotImplementedException();
				}
				return _length;
			}
		}

		public override long Position
		{
			get
			{
				return _Crc32.TotalBytesRead;
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		public CrcCalculatorStream(Stream stream)
		{
			_InnerStream = stream;
			_Crc32 = new CRC32();
		}

		public CrcCalculatorStream(Stream stream, long length)
		{
			_InnerStream = stream;
			_Crc32 = new CRC32();
			_length = length;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int count2 = count;
			checked
			{
				if (_length != 0L)
				{
					if (_Crc32.TotalBytesRead >= _length)
					{
						return 0;
					}
					long num = _length - _Crc32.TotalBytesRead;
					if (num < count)
					{
						count2 = (int)num;
					}
				}
				int num2 = _InnerStream.Read(buffer, offset, count2);
				if (num2 > 0)
				{
					_Crc32.SlurpBlock(buffer, offset, num2);
				}
				return num2;
			}
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			if (count > 0)
			{
				_Crc32.SlurpBlock(buffer, offset, count);
			}
			_InnerStream.Write(buffer, offset, count);
		}

		public override void Flush()
		{
			_InnerStream.Flush();
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotImplementedException();
		}

		public override void SetLength(long value)
		{
			throw new NotImplementedException();
		}
	}
}
namespace AWSSDK.Runtime.Internal.Util
{
	internal static class ExceptionUtils
	{
		internal static HttpStatusCode? DetermineHttpStatusCode(Exception e)
		{
			if ((e as WebException)?.Response is HttpWebResponse httpWebResponse)
			{
				return httpWebResponse.StatusCode;
			}
			if (e is HttpRequestException ex && ex.Data?.Contains("StatusCode") == true)
			{
				return (HttpStatusCode)ex.Data["StatusCode"];
			}
			if (e?.InnerException != null)
			{
				return DetermineHttpStatusCode(e.InnerException);
			}
			return null;
		}

		internal static bool IsInnerException<T>(Exception exception) where T : Exception
		{
			T inner;
			return IsInnerException<T>(exception, out inner);
		}

		internal static bool IsInnerException<T>(Exception exception, out T inner) where T : Exception
		{
			inner = null;
			Queue<Exception> queue = new Queue<Exception>();
			Exception ex = exception;
			do
			{
				if (queue.Count > 0)
				{
					ex = queue.Dequeue();
					inner = ex as T;
					if (inner != null)
					{
						return true;
					}
				}
				if (ex is AggregateException ex2)
				{
					foreach (Exception innerException in ex2.InnerExceptions)
					{
						queue.Enqueue(innerException);
					}
				}
				else if (ex.InnerException != null)
				{
					queue.Enqueue(ex.InnerException);
				}
			}
			while (queue.Count > 0);
			return false;
		}
	}
}
namespace Amazon
{
	public class Arn
	{
		private string _accountId = string.Empty;

		public string Partition { get; set; }

		public string Service { get; set; }

		public string Region { get; set; }

		public string AccountId
		{
			get
			{
				return _accountId;
			}
			set
			{
				if (string.IsNullOrEmpty(value))
				{
					_accountId = string.Empty;
					return;
				}
				if (value.Length != 12 && value.ToCharArray().Any((char x) => !char.IsDigit(x)))
				{
					throw new AmazonClientException("AccountId is invalid. The AccountId length should be 12 and only contain numeric characters with no spaces or periods.");
				}
				_accountId = value;
			}
		}

		public string Resource { get; set; }

		public static bool IsArn(string arn)
		{
			return arn?.StartsWith("arn:") ?? false;
		}

		public static bool TryParse(string arnString, out Arn arn)
		{
			try
			{
				if (IsArn(arnString))
				{
					arn = Parse(arnString);
					return true;
				}
			}
			catch (ArgumentException)
			{
			}
			arn = null;
			return false;
		}

		public static Arn Parse(string arnString)
		{
			if (arnString == null)
			{
				throw new ArgumentNullException("arnString");
			}
			string[] array = arnString.Split(new char[1] { ':' }, 6);
			if (array.Length != 6)
			{
				throw new ArgumentException("ARN is in incorrect format. ARN format is: arn:<partition>:<service>:<region>:<account-id>:<resource>");
			}
			if (array[0] != "arn")
			{
				throw new ArgumentException("ARN is in incorrect format. ARN format is: arn:<partition>:<service>:<region>:<account-id>:<resource>");
			}
			string text = array[1];
			if (string.IsNullOrEmpty(text))
			{
				throw new ArgumentException("Malformed ARN - no partition specified");
			}
			string text2 = array[2];
			if (string.IsNullOrEmpty(text2))
			{
				throw new ArgumentException("Malformed ARN - no service specified");
			}
			string region = array[3];
			string accountId = array[4];
			string text3 = array[5];
			if (string.IsNullOrEmpty(text3))
			{
				throw new ArgumentException("Malformed ARN - no resource specified");
			}
			return new Arn
			{
				Partition = text,
				Service = text2,
				Region = region,
				AccountId = accountId,
				Resource = text3
			};
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("arn:");
			stringBuilder.Append(Partition);
			stringBuilder.Append(":");
			stringBuilder.Append(Service);
			stringBuilder.Append(":");
			stringBuilder.Append(Region);
			stringBuilder.Append(":");
			stringBuilder.Append(AccountId);
			stringBuilder.Append(":");
			stringBuilder.Append(Resource);
			return stringBuilder.ToString();
		}

		public override bool Equals(object o)
		{
			if (this == o)
			{
				return true;
			}
			if (!(o is Arn arn))
			{
				return false;
			}
			if (!Partition.Equals(arn.Partition))
			{
				return false;
			}
			if (!Service.Equals(arn.Service))
			{
				return false;
			}
			if (Region != arn.Region)
			{
				return false;
			}
			if (AccountId != arn.AccountId)
			{
				return false;
			}
			return Resource.Equals(arn.Resource);
		}

		public override int GetHashCode()
		{
			return Hashing.Hash(Partition, Service, Region, AccountId, Resource);
		}
	}
	public static class AWSConfigs
	{
		private static char[] validSeparators = new char[2] { ' ', ',' };

		internal static Func<DateTime> utcNowSource = GetUtcNow;

		internal static string _awsRegion = GetConfig("AWSRegion");

		internal static LoggingOptions _logging = GetLoggingSetting();

		internal static ResponseLoggingOption _responseLogging = GetConfigEnum<ResponseLoggingOption>("AWSResponseLogging");

		internal static bool _logMetrics = GetConfigBool("AWSLogMetrics");

		internal static string _endpointDefinition = GetConfig("AWSEndpointDefinition");

		internal static string _awsProfileName = GetConfig("AWSProfileName");

		internal static string _awsAccountsLocation = GetConfig("AWSProfilesLocation");

		internal static bool _useSdkCache = GetConfigBool("AWSCache", defaultValue: true);

		private static object _lock = new object();

		private static List<string> standardConfigs = new List<string> { "region", "logging", "correctForClockSkew" };

		private static bool configPresent = true;

		private static RootConfig _rootConfig = new RootConfig();

		public const string AWSRegionKey = "AWSRegion";

		public const string AWSProfileNameKey = "AWSProfileName";

		public const string AWSProfilesLocationKey = "AWSProfilesLocation";

		public const string LoggingKey = "AWSLogging";

		public const string ResponseLoggingKey = "AWSResponseLogging";

		public const string LogMetricsKey = "AWSLogMetrics";

		public const string EndpointDefinitionKey = "AWSEndpointDefinition";

		public const string UseSdkCacheKey = "AWSCache";

		internal const string LoggingDestinationProperty = "LogTo";

		internal static PropertyChangedEventHandler mPropertyChanged;

		internal static readonly object propertyChangedLock = new object();

		public static TimeSpan? ManualClockCorrection
		{
			get
			{
				return CorrectClockSkew.GlobalClockCorrection;
			}
			set
			{
				CorrectClockSkew.GlobalClockCorrection = value;
			}
		}

		public static bool CorrectForClockSkew
		{
			get
			{
				return _rootConfig.CorrectForClockSkew;
			}
			set
			{
				_rootConfig.CorrectForClockSkew = value;
			}
		}

		[Obsolete("This value is deprecated in favor of IClientConfig.ClockOffset")]
		public static TimeSpan ClockOffset { get; internal set; }

		public static string AWSRegion
		{
			get
			{
				return _rootConfig.Region;
			}
			set
			{
				_rootConfig.Region = value;
			}
		}

		public static string AWSProfileName
		{
			get
			{
				return _rootConfig.ProfileName;
			}
			set
			{
				_rootConfig.ProfileName = value;
			}
		}

		public static string AWSProfilesLocation
		{
			get
			{
				return _rootConfig.ProfilesLocation;
			}
			set
			{
				_rootConfig.ProfilesLocation = value;
			}
		}

		[Obsolete("This property is obsolete. Use LoggingConfig.LogTo instead.")]
		public static LoggingOptions Logging
		{
			get
			{
				return _rootConfig.Logging.LogTo;
			}
			set
			{
				_rootConfig.Logging.LogTo = value;
			}
		}

		[Obsolete("This property is obsolete. Use LoggingConfig.LogResponses instead.")]
		public static ResponseLoggingOption ResponseLogging
		{
			get
			{
				return _rootConfig.Logging.LogResponses;
			}
			set
			{
				_rootConfig.Logging.LogResponses = value;
			}
		}

		[Obsolete("This property is obsolete. Use LoggingConfig.LogMetrics instead.")]
		public static bool LogMetrics
		{
			get
			{
				return _rootConfig.Logging.LogMetrics;
			}
			set
			{
				_rootConfig.Logging.LogMetrics = value;
			}
		}

		public static string EndpointDefinition
		{
			get
			{
				return _rootConfig.EndpointDefinition;
			}
			set
			{
				_rootConfig.EndpointDefinition = value;
			}
		}

		public static bool UseSdkCache
		{
			get
			{
				return _rootConfig.UseSdkCache;
			}
			set
			{
				_rootConfig.UseSdkCache = value;
			}
		}

		public static LoggingConfig LoggingConfig => _rootConfig.Logging;

		public static ProxyConfig ProxyConfig => _rootConfig.Proxy;

		public static RegionEndpoint RegionEndpoint
		{
			get
			{
				return _rootConfig.RegionEndpoint;
			}
			set
			{
				_rootConfig.RegionEndpoint = value;
			}
		}

		public static CSMConfig CSMConfig
		{
			get
			{
				return _rootConfig.CSMConfig;
			}
			set
			{
				_rootConfig.CSMConfig = value;
			}
		}

		internal static event PropertyChangedEventHandler PropertyChanged
		{
			add
			{
				lock (propertyChangedLock)
				{
					mPropertyChanged = (PropertyChangedEventHandler)Delegate.Combine(mPropertyChanged, value);
				}
			}
			remove
			{
				lock (propertyChangedLock)
				{
					mPropertyChanged = (PropertyChangedEventHandler)Delegate.Remove(mPropertyChanged, value);
				}
			}
		}

		private static LoggingOptions GetLoggingSetting()
		{
			string config = GetConfig("AWSLogging");
			if (string.IsNullOrEmpty(config))
			{
				return LoggingOptions.None;
			}
			string[] array = config.Split(validSeparators, StringSplitOptions.RemoveEmptyEntries);
			if (array == null || array.Length == 0)
			{
				return LoggingOptions.None;
			}
			LoggingOptions loggingOptions = LoggingOptions.None;
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				LoggingOptions loggingOptions2 = ParseEnum<LoggingOptions>(array2[i]);
				loggingOptions |= loggingOptions2;
			}
			return loggingOptions;
		}

		internal static void OnPropertyChanged(string name)
		{
			mPropertyChanged?.Invoke(null, new PropertyChangedEventArgs(name));
		}

		private static bool GetConfigBool(string name, bool defaultValue = false)
		{
			if (bool.TryParse(GetConfig(name), out var result))
			{
				return result;
			}
			return defaultValue;
		}

		private static T GetConfigEnum<T>(string name)
		{
			ITypeInfo typeInfo = TypeFactory.GetTypeInfo(typeof(T));
			if (!typeInfo.IsEnum)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Type {0} must be enum", typeInfo.FullName));
			}
			string config = GetConfig(name);
			if (string.IsNullOrEmpty(config))
			{
				return default(T);
			}
			return ParseEnum<T>(config);
		}

		private static T ParseEnum<T>(string value)
		{
			if (TryParseEnum<T>(value, out var result))
			{
				return result;
			}
			Type typeFromHandle = typeof(T);
			string format = "Unable to parse value {0} as enum of type {1}. Valid values are: {2}";
			string arg = string.Join(", ", Enum.GetNames(typeFromHandle));
			throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, format, value, typeFromHandle.FullName, arg));
		}

		private static bool TryParseEnum<T>(string value, out T result)
		{
			result = default(T);
			if (string.IsNullOrEmpty(value))
			{
				return false;
			}
			try
			{
				T val = (T)Enum.Parse(typeof(T), value, ignoreCase: true);
				result = val;
				return true;
			}
			catch (ArgumentException)
			{
				return false;
			}
		}

		private static DateTime GetUtcNow()
		{
			return DateTime.UtcNow;
		}

		public static string GetConfig(string name)
		{
			return null;
		}

		internal static bool XmlSectionExists(string sectionName)
		{
			return false;
		}
	}
	[Flags]
	public enum LoggingOptions
	{
		None = 0,
		Log4Net = 1,
		SystemDiagnostics = 2,
		Console = 0x10,
		File = 4
	}
	public enum ResponseLoggingOption
	{
		Never,
		OnError,
		Always
	}
	public enum LogMetricsFormatOption
	{
		Standard,
		JSON
	}
	public class RegionEndpoint
	{
		public class Endpoint
		{
			public string Hostname { get; private set; }

			public string AuthRegion { get; private set; }

			public string SignatureVersionOverride { get; private set; }

			internal Endpoint(string hostname, string authregion, string signatureVersionOverride)
			{
				Hostname = hostname;
				AuthRegion = authregion;
				SignatureVersionOverride = signatureVersionOverride;
			}

			public override string ToString()
			{
				return Hostname;
			}
		}

		private static Dictionary<string, RegionEndpoint> _hashBySystemName = new Dictionary<string, RegionEndpoint>(StringComparer.OrdinalIgnoreCase);

		public static readonly RegionEndpoint USEast1 = GetEndpoint("us-east-1", "US East (Virginia)");

		private static readonly RegionEndpoint USEast1Regional = GetEndpoint("us-east-1-regional", "US East (Virginia) regional");

		public static readonly RegionEndpoint USEast2 = GetEndpoint("us-east-2", "US East (Ohio)");

		public static readonly RegionEndpoint USWest1 = GetEndpoint("us-west-1", "US West (N. California)");

		public static readonly RegionEndpoint USWest2 = GetEndpoint("us-west-2", "US West (Oregon)");

		public static readonly RegionEndpoint EUNorth1 = GetEndpoint("eu-north-1", "EU North (Stockholm)");

		public static readonly RegionEndpoint EUWest1 = GetEndpoint("eu-west-1", "EU West (Ireland)");

		public static readonly RegionEndpoint EUWest2 = GetEndpoint("eu-west-2", "EU West (London)");

		public static readonly RegionEndpoint EUWest3 = GetEndpoint("eu-west-3", "EU West (Paris)");

		public static readonly RegionEndpoint EUCentral1 = GetEndpoint("eu-central-1", "EU Central (Frankfurt)");

		public static readonly RegionEndpoint EUSouth1 = GetEndpoint("eu-south-1", "Europe (Milan)");

		public static readonly RegionEndpoint APEast1 = GetEndpoint("ap-east-1", "Asia Pacific (Hong Kong)");

		public static readonly RegionEndpoint APNortheast1 = GetEndpoint("ap-northeast-1", "Asia Pacific (Tokyo)");

		public static readonly RegionEndpoint APNortheast2 = GetEndpoint("ap-northeast-2", "Asia Pacific (Seoul)");

		public static readonly RegionEndpoint APNortheast3 = GetEndpoint("ap-northeast-3", "Asia Pacific (Osaka-Local)");

		public static readonly RegionEndpoint APSouth1 = GetEndpoint("ap-south-1", "Asia Pacific (Mumbai)");

		public static readonly RegionEndpoint APSoutheast1 = GetEndpoint("ap-southeast-1", "Asia Pacific (Singapore)");

		public static readonly RegionEndpoint APSoutheast2 = GetEndpoint("ap-southeast-2", "Asia Pacific (Sydney)");

		public static readonly RegionEndpoint SAEast1 = GetEndpoint("sa-east-1", "South America (Sao Paulo)");

		public static readonly RegionEndpoint USGovCloudEast1 = GetEndpoint("us-gov-east-1", "US GovCloud East (Virginia)");

		public static readonly RegionEndpoint USGovCloudWest1 = GetEndpoint("us-gov-west-1", "US GovCloud West (Oregon)");

		public static readonly RegionEndpoint CNNorth1 = GetEndpoint("cn-north-1", "China (Beijing)");

		public static readonly RegionEndpoint CNNorthWest1 = GetEndpoint("cn-northwest-1", "China (Ningxia)");

		public static readonly RegionEndpoint CACentral1 = GetEndpoint("ca-central-1", "Canada (Central)");

		public static readonly RegionEndpoint MESouth1 = GetEndpoint("me-south-1", "Middle East (Bahrain)");

		public static readonly RegionEndpoint AFSouth1 = GetEndpoint("af-south-1", "Africa (Cape Town)");

		private static Dictionary<RegionEndpoint, RegionEndpoint> _hashRegionEndpointOverride = new Dictionary<RegionEndpoint, RegionEndpoint> { { USEast1Regional, USEast1 } };

		private static IRegionEndpointProvider _regionEndpointProvider;

		public static IEnumerable<RegionEndpoint> EnumerableAllRegions
		{
			get
			{
				List<RegionEndpoint> list = new List<RegionEndpoint>();
				foreach (IRegionEndpoint allRegionEndpoint in RegionEndpointProvider.AllRegionEndpoints)
				{
					list.Add(GetEndpoint(allRegionEndpoint.RegionName, allRegionEndpoint.DisplayName));
				}
				return list;
			}
		}

		private static IRegionEndpointProvider RegionEndpointProvider
		{
			get
			{
				if (_regionEndpointProvider == null)
				{
					if (!string.IsNullOrEmpty(AWSConfigs.EndpointDefinition))
					{
						_regionEndpointProvider = new RegionEndpointProviderV2();
					}
					else
					{
						_regionEndpointProvider = new RegionEndpointProviderV3();
					}
				}
				return _regionEndpointProvider;
			}
		}

		public string SystemName { get; private set; }

		public string DisplayName { get; private set; }

		public string PartitionName => (InternedRegionEndpoint as RegionEndpointV3)?.PartitionName;

		public string PartitionDnsSuffix => (InternedRegionEndpoint as RegionEndpointV3)?.PartitionDnsSuffix;

		private IRegionEndpoint InternedRegionEndpoint => RegionEndpointProvider.GetRegionEndpoint(SystemName);

		public static RegionEndpoint GetBySystemName(string systemName)
		{
			return GetEndpoint(systemName, null);
		}

		public static RegionEndpoint GetRegionEndpointOverride(RegionEndpoint regionEndpoint)
		{
			if (!_hashRegionEndpointOverride.ContainsKey(regionEndpoint))
			{
				return null;
			}
			return _hashRegionEndpointOverride[regionEndpoint];
		}

		private static RegionEndpoint GetEndpoint(string systemName, string displayName)
		{
			RegionEndpoint value = null;
			if (displayName == null)
			{
				lock (_hashBySystemName)
				{
					if (_hashBySystemName.TryGetValue(systemName, out value))
					{
						return value;
					}
				}
				displayName = RegionEndpointProvider.GetRegionEndpoint(systemName).DisplayName;
			}
			lock (_hashBySystemName)
			{
				if (_hashBySystemName.TryGetValue(systemName, out value))
				{
					return value;
				}
				value = new RegionEndpoint(systemName, displayName);
				_hashBySystemName.Add(value.SystemName, value);
				return value;
			}
		}

		private RegionEndpoint(string systemName, string displayName)
		{
			SystemName = systemName;
			DisplayName = displayName;
		}

		public Endpoint GetEndpointForService(string serviceName)
		{
			return GetEndpointForService(serviceName, dualStack: false);
		}

		public Endpoint GetEndpointForService(string serviceName, bool dualStack)
		{
			return InternedRegionEndpoint.GetEndpointForService(serviceName, dualStack);
		}

		public override string ToString()
		{
			return string.Format(CultureInfo.InvariantCulture, "{0} ({1})", DisplayName, SystemName);
		}
	}
}
namespace Amazon.Internal
{
	public interface IRegionEndpoint
	{
		string RegionName { get; }

		string DisplayName { get; }

		RegionEndpoint.Endpoint GetEndpointForService(string serviceName, bool dualStack);
	}
	public interface IRegionEndpointProvider
	{
		IEnumerable<IRegionEndpoint> AllRegionEndpoints { get; }

		IRegionEndpoint GetRegionEndpoint(string regionName);
	}
	public class RegionEndpointProviderV2 : IRegionEndpointProvider
	{
		public class RegionEndpoint : IRegionEndpoint
		{
			private const string REGIONS_FILE = "Amazon.endpoints.json";

			private const string REGIONS_CUSTOMIZATIONS_FILE = "Amazon.endpoints.customizations.json";

			private const string DEFAULT_RULE = "*/*";

			private static Dictionary<string, JsonData> _documentEndpoints;

			private const int MAX_DOWNLOAD_RETRIES = 3;

			private static bool loaded = false;

			private static readonly object LOCK_OBJECT = new object();

			private static Dictionary<string, RegionEndpoint> hashBySystemName = new Dictionary<string, RegionEndpoint>(StringComparer.OrdinalIgnoreCase);

			public static IEnumerable<RegionEndpoint> EnumerableAllRegions
			{
				get
				{
					if (!loaded)
					{
						LoadEndpointDefinitions();
					}
					lock (hashBySystemName)
					{
						return hashBySystemName.Values.ToList();
					}
				}
			}

			public string SystemName { get; private set; }

			public string DisplayName { get; private set; }

			public string RegionName => SystemName;

			public Amazon.RegionEndpoint.Endpoint GetEndpointForService(string serviceName, bool dualStack)
			{
				if (!loaded)
				{
					LoadEndpointDefinitions();
				}
				JsonData endpointRule = GetEndpointRule(serviceName);
				string text = endpointRule["endpoint"].ToString();
				if (dualStack)
				{
					if (serviceName.Equals("s3", StringComparison.OrdinalIgnoreCase))
					{
						if (text.Equals("s3.amazonaws.com", StringComparison.OrdinalIgnoreCase))
						{
							text = "s3.dualstack.us-east-1.amazonaws.com";
						}
						else if (!text.StartsWith("s3-external-", StringComparison.OrdinalIgnoreCase))
						{
							if (text.StartsWith("s3-", StringComparison.OrdinalIgnoreCase))
							{
								text = "s3." + text.Substring(3);
							}
							if (text.StartsWith("s3.", StringComparison.OrdinalIgnoreCase))
							{
								text = text.Replace("s3.", "s3.dualstack.");
							}
						}
					}
					else
					{
						text = text.Replace("{region}", "dualstack.{region}");
					}
				}
				string text2 = text.Replace("{region}", SystemName).Replace("{service}", serviceName);
				string signatureVersionOverride = null;
				if (endpointRule["signature-version"] != null)
				{
					signatureVersionOverride = endpointRule["signature-version"].ToString();
				}
				string text3 = ((endpointRule["auth-region"] == null) ? AWSSDKUtils.DetermineRegion(text2) : endpointRule["auth-region"].ToString());
				if (string.Equals(text3, SystemName, StringComparison.OrdinalIgnoreCase))
				{
					text3 = null;
				}
				return new Amazon.RegionEndpoint.Endpoint(text2, text3, signatureVersionOverride);
			}

			private JsonData GetEndpointRule(string serviceName)
			{
				JsonData value = null;
				if (_documentEndpoints.TryGetValue(string.Format(CultureInfo.InvariantCulture, "{0}/{1}", SystemName, serviceName), out value))
				{
					return value;
				}
				if (_documentEndpoints.TryGetValue(string.Format(CultureInfo.InvariantCulture, "{0}/*", SystemName), out value))
				{
					return value;
				}
				if (_documentEndpoints.TryGetValue(string.Format(CultureInfo.InvariantCulture, "*/{0}", serviceName), out value))
				{
					return value;
				}
				return _documentEndpoints["*/*"];
			}

			private static RegionEndpoint GetEndpoint(string systemName, string displayName)
			{
				RegionEndpoint value = null;
				lock (hashBySystemName)
				{
					if (hashBySystemName.TryGetValue(systemName, out value))
					{
						return value;
					}
					value = new RegionEndpoint(systemName, displayName);
					hashBySystemName.Add(value.SystemName, value);
					return value;
				}
			}

			public static RegionEndpoint GetBySystemName(string systemName)
			{
				if (!loaded)
				{
					LoadEndpointDefinitions();
				}
				RegionEndpoint value = null;
				lock (hashBySystemName)
				{
					if (!hashBySystemName.TryGetValue(systemName, out value))
					{
						Logger.GetLogger(typeof(RegionEndpoint)).InfoFormat("Region system name {0} was not found in region data bundled with SDK; assuming new region.", systemName);
						if (systemName.StartsWith("cn-", StringComparison.Ordinal))
						{
							return GetEndpoint(systemName, "China (Unknown)");
						}
						return GetEndpoint(systemName, "Unknown");
					}
					return value;
				}
			}

			private static void LoadEndpointDefinitions()
			{
				LoadEndpointDefinitions(AWSConfigs.EndpointDefinition);
			}

			public static void LoadEndpointDefinitions(string endpointsPath)
			{
				lock (LOCK_OBJECT)
				{
					if (!loaded)
					{
						_documentEndpoints = new Dictionary<string, JsonData>();
						if (string.IsNullOrEmpty(endpointsPath))
						{
							LoadEndpointDefinitionsFromEmbeddedResource();
						}
						else if (endpointsPath.StartsWith("http", StringComparison.OrdinalIgnoreCase))
						{
							LoadEndpointDefinitionFromWeb(endpointsPath);
						}
						loaded = true;
					}
				}
			}

			private static void ReadEndpointFile(Stream stream)
			{
				using StreamReader reader = new StreamReader(stream);
				JsonData jsonData = JsonMapper.ToObject(reader)["endpoints"];
				foreach (string propertyName in jsonData.PropertyNames)
				{
					_documentEndpoints[propertyName] = jsonData[propertyName];
				}
			}

			private static void LoadEndpointDefinitionsFromEmbeddedResource()
			{
				using (Stream stream = TypeFactory.GetTypeInfo(typeof(RegionEndpoint)).Assembly.GetManifestResourceStream("Amazon.endpoints.json"))
				{
					ReadEndpointFile(stream);
				}
				using Stream stream2 = TypeFactory.GetTypeInfo(typeof(RegionEndpoint)).Assembly.GetManifestResourceStream("Amazon.endpoints.customizations.json");
				ReadEndpointFile(stream2);
			}

			private static void LoadEndpointDefinitionFromWeb(string url)
			{
				int num = 0;
				checked
				{
					while (num < 3)
					{
						try
						{
							using Stream stream = AWSSDKUtils.OpenStream(new System.Uri(url), Proxy);
							ReadEndpointFile(stream);
							break;
						}
						catch (Exception innerException)
						{
							num++;
							if (num == 3)
							{
								throw new AmazonServiceException(string.Format(CultureInfo.InvariantCulture, "Error downloading regions definition file from {0}.", url), innerException);
							}
						}
						AWSSDKUtils.Sleep(Math.Min((int)(Math.Pow(4.0, num) * 100.0), 30000));
					}
				}
			}

			public static void UnloadEndpointDefinitions()
			{
				lock (LOCK_OBJECT)
				{
					_documentEndpoints.Clear();
					loaded = false;
				}
			}

			private RegionEndpoint(string systemName, string displayName)
			{
				SystemName = systemName;
				DisplayName = displayName;
			}

			public override string ToString()
			{
				return string.Format(CultureInfo.InvariantCulture, "{0} ({1})", DisplayName, SystemName);
			}
		}

		public static IWebProxy Proxy { get; set; }

		public IEnumerable<IRegionEndpoint> AllRegionEndpoints => RegionEndpoint.EnumerableAllRegions;

		public IRegionEndpoint GetRegionEndpoint(string regionName)
		{
			return RegionEndpoint.GetBySystemName(regionName);
		}
	}
	public class RegionEndpointV3 : IRegionEndpoint
	{
		private class ServiceMap
		{
			private Dictionary<string, RegionEndpoint.Endpoint> _serviceMap = new Dictionary<string, RegionEndpoint.Endpoint>();

			private Dictionary<string, RegionEndpoint.Endpoint> _dualServiceMap = new Dictionary<string, RegionEndpoint.Endpoint>();

			private Dictionary<string, RegionEndpoint.Endpoint> GetMap(bool dualStack)
			{
				if (!dualStack)
				{
					return _serviceMap;
				}
				return _dualServiceMap;
			}

			public bool ContainsKey(string servicName)
			{
				return _serviceMap.ContainsKey(servicName);
			}

			public void Add(string serviceName, bool dualStack, RegionEndpoint.Endpoint endpoint)
			{
				if (!dualStack)
				{
					_ = _serviceMap;
				}
				else
				{
					_ = _dualServiceMap;
				}
				GetMap(dualStack).Add(serviceName, endpoint);
			}

			public bool TryGetEndpoint(string serviceName, bool dualStack, out RegionEndpoint.Endpoint endpoint)
			{
				return GetMap(dualStack).TryGetValue(serviceName, out endpoint);
			}
		}

		private ServiceMap _serviceMap = new ServiceMap();

		private JsonData _partitionJsonData;

		private JsonData _servicesJsonData;

		private bool _servicesLoaded;

		public string RegionName { get; private set; }

		public string DisplayName { get; private set; }

		public string PartitionName => (string)_partitionJsonData["partition"];

		public string PartitionDnsSuffix => (string)_partitionJsonData["dnsSuffix"];

		public RegionEndpointV3(string regionName, string displayName, JsonData partition, JsonData services)
		{
			RegionName = regionName;
			DisplayName = displayName;
			_partitionJsonData = partition;
			_servicesJsonData = services;
		}

		public RegionEndpoint.Endpoint GetEndpointForService(string serviceName, bool dualStack)
		{
			RegionEndpoint.Endpoint endpoint = null;
			lock (_serviceMap)
			{
				if (!_servicesLoaded)
				{
					ParseAllServices();
					_servicesLoaded = true;
				}
				if (!_serviceMap.TryGetEndpoint(serviceName, dualStack, out endpoint))
				{
					endpoint = CreateUnknownEndpoint(serviceName, dualStack);
				}
			}
			return endpoint;
		}

		private RegionEndpoint.Endpoint CreateUnknownEndpoint(string serviceName, bool dualStack)
		{
			string text = (string)_partitionJsonData["defaults"]["hostname"];
			if (dualStack)
			{
				text = text.Replace("{region}", "dualstack.{region}");
			}
			return new RegionEndpoint.Endpoint(text.Replace("{service}", serviceName).Replace("{region}", RegionName).Replace("{dnsSuffix}", (string)_partitionJsonData["dnsSuffix"]), null, null);
		}

		private void ParseAllServices()
		{
			foreach (string propertyName in _servicesJsonData.PropertyNames)
			{
				if (_servicesJsonData[propertyName] != null && _servicesJsonData[propertyName].Count > 0)
				{
					AddServiceToMap(_servicesJsonData[propertyName], propertyName);
				}
			}
		}

		private void AddServiceToMap(JsonData service, string serviceName)
		{
			string text = ((service["partitionEndpoint"] != null) ? ((string)service["partitionEndpoint"]) : "");
			bool num = service["isRegionalized"] == null || (bool)service["isRegionalized"];
			string prop_name = RegionName;
			if (!num && !string.IsNullOrEmpty(text))
			{
				prop_name = text;
			}
			JsonData jsonData = service["endpoints"][prop_name];
			if (jsonData != null)
			{
				JsonData jsonData2 = new JsonData();
				MergeJsonData(jsonData2, jsonData);
				MergeJsonData(jsonData2, service["defaults"]);
				MergeJsonData(jsonData2, _partitionJsonData["defaults"]);
				CreateEndpointAndAddToServiceMap(jsonData2, RegionName, serviceName);
			}
		}

		private static void MergeJsonData(JsonData target, JsonData source)
		{
			if (source == null || target == null)
			{
				return;
			}
			foreach (string propertyName in source.PropertyNames)
			{
				if (target[propertyName] == null)
				{
					target[propertyName] = source[propertyName];
				}
			}
		}

		private void CreateEndpointAndAddToServiceMap(JsonData result, string regionName, string serviceName)
		{
			CreateEndpointAndAddToServiceMap(result, regionName, serviceName, dualStack: false);
			CreateEndpointAndAddToServiceMap(result, regionName, serviceName, dualStack: true);
		}

		private void CreateEndpointAndAddToServiceMap(JsonData result, string regionName, string serviceName, bool dualStack)
		{
			string text = ((string)result["hostname"]).Replace("{service}", serviceName).Replace("{region}", regionName).Replace("{dnsSuffix}", (string)_partitionJsonData["dnsSuffix"]);
			if (dualStack)
			{
				if (serviceName.Equals("s3", StringComparison.OrdinalIgnoreCase))
				{
					if (text.Equals("s3.amazonaws.com", StringComparison.OrdinalIgnoreCase))
					{
						text = "s3.dualstack.us-east-1.amazonaws.com";
					}
					else if (!text.StartsWith("s3-external-", StringComparison.OrdinalIgnoreCase))
					{
						if (text.StartsWith("s3-", StringComparison.OrdinalIgnoreCase))
						{
							text = "s3." + text.Substring(3);
						}
						if (text.StartsWith("s3.", StringComparison.OrdinalIgnoreCase))
						{
							text = text.Replace("s3.", "s3.dualstack.");
						}
					}
				}
				else if (serviceName.Equals("s3-control", StringComparison.OrdinalIgnoreCase))
				{
					if (text.StartsWith("s3-control", StringComparison.OrdinalIgnoreCase))
					{
						int num = text.IndexOf('.');
						if (num >= 0)
						{
							text = text.Substring(0, num) + ".dualstack." + text.Substring(checked(num + 1));
						}
					}
				}
				else
				{
					text = string.Format(CultureInfo.InvariantCulture, "{0}.{1}.{2}", serviceName, "dualstack." + regionName, (string)_partitionJsonData["dnsSuffix"]);
				}
			}
			string authregion = null;
			string text2 = null;
			JsonData jsonData = result["credentialScope"];
			if (jsonData != null)
			{
				authregion = DetermineAuthRegion(jsonData);
				if (jsonData["service"] != null && string.Compare((string)jsonData["service"], serviceName, StringComparison.OrdinalIgnoreCase) != 0)
				{
					text2 = (string)jsonData["service"];
				}
			}
			string signatureVersionOverride = DetermineSignatureOverride(result, serviceName);
			RegionEndpoint.Endpoint endpoint = new RegionEndpoint.Endpoint(text, authregion, signatureVersionOverride);
			_serviceMap.Add(serviceName, dualStack, endpoint);
			if (!string.IsNullOrEmpty(text2) && !_serviceMap.ContainsKey(text2))
			{
				_serviceMap.Add(text2, dualStack, endpoint);
			}
		}

		private static string DetermineSignatureOverride(JsonData defaults, string serviceName)
		{
			if (string.Equals(serviceName, "s3", StringComparison.OrdinalIgnoreCase))
			{
				bool flag = false;
				foreach (JsonData item in (IEnumerable)defaults["signatureVersions"])
				{
					if (string.Equals((string)item, "s3", StringComparison.OrdinalIgnoreCase))
					{
						flag = true;
						break;
					}
				}
				if (!flag)
				{
					return "4";
				}
				return "2";
			}
			return null;
		}

		private static string DetermineAuthRegion(JsonData credentialScope)
		{
			string result = null;
			if (credentialScope["region"] != null)
			{
				result = (string)credentialScope["region"];
			}
			return result;
		}
	}
	public class RegionEndpointProviderV3 : IRegionEndpointProvider
	{
		private const string ENDPOINT_JSON_RESOURCE = "Amazon.endpoints.json";

		private const string ENDPOINT_JSON = "endpoints.json";

		private JsonData _root;

		private Dictionary<string, IRegionEndpoint> _regionEndpointMap = new Dictionary<string, IRegionEndpoint>();

		private object _regionEndpointMapLock = new object();

		private object _allRegionEndpointsLock = new object();

		private IEnumerable<IRegionEndpoint> _allRegionEndpoints;

		private static JsonData _emptyDictionaryJsonData = JsonMapper.ToObject("{}");

		public IEnumerable<IRegionEndpoint> AllRegionEndpoints
		{
			get
			{
				lock (_allRegionEndpointsLock)
				{
					lock (_regionEndpointMapLock)
					{
						if (_allRegionEndpoints == null)
						{
							JsonData jsonData = _root["partitions"];
							List<IRegionEndpoint> list = new List<IRegionEndpoint>();
							foreach (JsonData item in (IEnumerable)jsonData)
							{
								JsonData jsonData3 = item["regions"];
								foreach (string propertyName in jsonData3.PropertyNames)
								{
									if (!_regionEndpointMap.TryGetValue(propertyName, out var value))
									{
										value = new RegionEndpointV3(propertyName, (string)jsonData3[propertyName]["description"], item, item["services"]);
										_regionEndpointMap.Add(propertyName, value);
									}
									list.Add(value);
								}
							}
							_allRegionEndpoints = list;
						}
					}
				}
				return _allRegionEndpoints;
			}
		}

		public RegionEndpointProviderV3()
		{
			using Stream stream = GetEndpointJsonSourceStream();
			using StreamReader reader = new StreamReader(stream);
			_root = JsonMapper.ToObject(reader);
		}

		public RegionEndpointProviderV3(JsonData root)
		{
			_root = root;
		}

		private static Stream GetEndpointJsonSourceStream()
		{
			return TypeFactory.GetTypeInfo(typeof(RegionEndpointProviderV3)).Assembly.GetManifestResourceStream("Amazon.endpoints.json");
		}

		private static string GetUnknownRegionDescription(string regionName)
		{
			if (regionName.StartsWith("cn-", StringComparison.OrdinalIgnoreCase) || regionName.EndsWith("cn-global", StringComparison.OrdinalIgnoreCase))
			{
				return "China (Unknown)";
			}
			return "Unknown";
		}

		private static bool IsRegionInPartition(string regionName, JsonData partition, out string description)
		{
			JsonData jsonData = partition["regions"];
			string pattern = (string)partition["regionRegex"];
			if (jsonData[regionName] != null)
			{
				description = (string)jsonData[regionName]["description"];
				return true;
			}
			if (regionName.Equals((string)partition["partition"] + "-global", StringComparison.OrdinalIgnoreCase))
			{
				description = "Global";
				return true;
			}
			if (new Regex(pattern).Match(regionName).Success)
			{
				description = GetUnknownRegionDescription(regionName);
				return true;
			}
			description = GetUnknownRegionDescription(regionName);
			return false;
		}

		public IRegionEndpoint GetRegionEndpoint(string regionName)
		{
			try
			{
				lock (_regionEndpointMapLock)
				{
					if (_regionEndpointMap.TryGetValue(regionName, out var value))
					{
						return value;
					}
					foreach (JsonData item in (IEnumerable)_root["partitions"])
					{
						if (IsRegionInPartition(regionName, item, out var description))
						{
							value = new RegionEndpointV3(regionName, description, item, item["services"]);
							_regionEndpointMap.Add(regionName, value);
							return value;
						}
					}
				}
			}
			catch (Exception)
			{
				throw new AmazonClientException("Invalid endpoint.json format.");
			}
			return GetNonstandardRegionEndpoint(regionName);
		}

		private IRegionEndpoint GetNonstandardRegionEndpoint(string regionName)
		{
			JsonData partition = _root["partitions"][0];
			string unknownRegionDescription = GetUnknownRegionDescription(regionName);
			JsonData services = _emptyDictionaryJsonData;
			foreach (JsonData item in (IEnumerable)_root["partitions"])
			{
				JsonData jsonData2 = item["services"];
				foreach (string propertyName in jsonData2.PropertyNames)
				{
					if (jsonData2[propertyName] != null && jsonData2[propertyName].Count > 0)
					{
						JsonData jsonData3 = jsonData2[propertyName];
						if (jsonData3 != null && jsonData3["endpoints"][regionName] != null)
						{
							partition = item;
							services = jsonData2;
							break;
						}
					}
				}
			}
			return new RegionEndpointV3(regionName, unknownRegionDescription, partition, services);
		}
	}
}
namespace Amazon.Util
{
	public class ProxyConfig
	{
		public string Host { get; set; }

		public int? Port { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

		public List<string> BypassList { get; set; }

		public bool BypassOnLocal { get; set; }

		internal ProxyConfig()
		{
		}
	}
	public class LoggingConfig
	{
		public static readonly int DefaultLogResponsesSizeLimit = 1024;

		private LoggingOptions _logTo;

		public LoggingOptions LogTo
		{
			get
			{
				return _logTo;
			}
			set
			{
				_logTo = value;
				AWSConfigs.OnPropertyChanged("LogTo");
			}
		}

		public ResponseLoggingOption LogResponses { get; set; }

		public int LogResponsesSizeLimit { get; set; }

		public bool LogMetrics { get; set; }

		public LogMetricsFormatOption LogMetricsFormat { get; set; }

		public IMetricsFormatter LogMetricsCustomFormatter { get; set; }

		internal LoggingConfig()
		{
			LogTo = AWSConfigs._logging;
			LogResponses = AWSConfigs._responseLogging;
			LogResponsesSizeLimit = DefaultLogResponsesSizeLimit;
			LogMetrics = AWSConfigs._logMetrics;
		}
	}
	public class CSMConfig
	{
		internal const string DEFAULT_HOST = "127.0.0.1";

		internal const int DEFAULT_PORT = 31000;

		public string CSMHost { get; set; } = "127.0.0.1";

		public int CSMPort { get; set; } = 31000;

		public string CSMClientId { get; set; }

		public bool? CSMEnabled { get; set; }
	}
	public class AWSPublicIpAddressRanges
	{
		public const string AmazonServiceKey = "AMAZON";

		public const string EC2ServiceKey = "EC2";

		public const string CloudFrontServiceKey = "CLOUDFRONT";

		public const string Route53ServiceKey = "ROUTE53";

		public const string Route53HealthChecksServiceKey = "ROUTE53_HEALTHCHECKS";

		public const string GlobalRegionIdentifier = "GLOBAL";

		private const string createDateKey = "createDate";

		private const string ipv4PrefixesKey = "prefixes";

		private const string ipv4PrefixKey = "ip_prefix";

		private const string ipv6PrefixesKey = "ipv6_prefixes";

		private const string ipv6PrefixKey = "ipv6_prefix";

		private const string regionKey = "region";

		private const string serviceKey = "service";

		private const string networkBorderGroupKey = "network_border_group";

		private const string createDateFormatString = "yyyy-MM-dd-HH-mm-ss";

		private static readonly System.Uri IpAddressRangeEndpoint = new System.Uri("https://ip-ranges.amazonaws.com/ip-ranges.json");

		public IEnumerable<string> ServiceKeys
		{
			get
			{
				HashSet<string> hashSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
				foreach (AWSPublicIpAddressRange allAddressRange in AllAddressRanges)
				{
					hashSet.Add(allAddressRange.Service);
				}
				return hashSet;
			}
		}

		public DateTime CreateDate { get; private set; }

		public IEnumerable<AWSPublicIpAddressRange> AllAddressRanges { get; private set; }

		public IEnumerable<AWSPublicIpAddressRange> AddressRangesByServiceKey(string serviceKey)
		{
			if (!AllAddressRanges.Any())
			{
				throw new InvalidOperationException("No address range data has been loaded and parsed.");
			}
			return AllAddressRanges.Where((AWSPublicIpAddressRange ar) => ar.Service.Equals(serviceKey, StringComparison.OrdinalIgnoreCase));
		}

		public IEnumerable<AWSPublicIpAddressRange> AddressRangesByRegion(string regionIdentifier)
		{
			if (!AllAddressRanges.Any())
			{
				throw new InvalidOperationException("No address range data has been loaded and parsed.");
			}
			return AllAddressRanges.Where((AWSPublicIpAddressRange ar) => ar.Region.Equals(regionIdentifier, StringComparison.OrdinalIgnoreCase));
		}

		public IEnumerable<AWSPublicIpAddressRange> AddressRangesByNetworkBorderGroup(string networkBorderGroup)
		{
			if (!AllAddressRanges.Any())
			{
				throw new InvalidOperationException("No address range data has been loaded and parsed.");
			}
			return AllAddressRanges.Where((AWSPublicIpAddressRange ar) => ar.NetworkBorderGroup.Equals(networkBorderGroup, StringComparison.OrdinalIgnoreCase));
		}

		public static AWSPublicIpAddressRanges Load()
		{
			return Load(null);
		}

		public static AWSPublicIpAddressRanges Load(IWebProxy proxy)
		{
			int num = 0;
			checked
			{
				while (num < 3)
				{
					try
					{
						return Parse(AWSSDKUtils.DownloadStringContent(IpAddressRangeEndpoint, proxy));
					}
					catch (Exception innerException)
					{
						num++;
						if (num == 3)
						{
							throw new AmazonServiceException(string.Format(CultureInfo.InvariantCulture, "Error downloading public IP address ranges file from {0}.", IpAddressRangeEndpoint), innerException);
						}
					}
					AWSSDKUtils.Sleep(Math.Min((int)(Math.Pow(4.0, num) * 100.0), 30000));
				}
				return null;
			}
		}

		private static AWSPublicIpAddressRanges Parse(string fileContent)
		{
			try
			{
				AWSPublicIpAddressRanges aWSPublicIpAddressRanges = new AWSPublicIpAddressRanges();
				JsonData jsonData = JsonMapper.ToObject(new JsonReader(fileContent));
				DateTime? dateTime = null;
				try
				{
					string s = (string)jsonData["createDate"];
					dateTime = DateTime.ParseExact(s, "yyyy-MM-dd-HH-mm-ss", null);
				}
				catch (FormatException)
				{
				}
				catch (ArgumentNullException)
				{
				}
				aWSPublicIpAddressRanges.CreateDate = dateTime.GetValueOrDefault(AWSSDKUtils.CorrectedUtcNow);
				List<AWSPublicIpAddressRange> list = new List<AWSPublicIpAddressRange>();
				JsonData jsonData2 = jsonData["prefixes"];
				JsonData jsonData3 = jsonData["ipv6_prefixes"];
				if (!jsonData2.IsArray || !jsonData3.IsArray)
				{
					throw new InvalidDataException("Expected array content for ip_prefixes and/or ipv6_prefixes keys.");
				}
				list.AddRange(ParseRange(jsonData2, AWSPublicIpAddressRange.AddressFormat.Ipv4));
				list.AddRange(ParseRange(jsonData3, AWSPublicIpAddressRange.AddressFormat.Ipv6));
				aWSPublicIpAddressRanges.AllAddressRanges = list;
				return aWSPublicIpAddressRanges;
			}
			catch (Exception innerException)
			{
				throw new InvalidDataException("IP address ranges content in unexpected/invalid format.", innerException);
			}
		}

		private static IEnumerable<AWSPublicIpAddressRange> ParseRange(JsonData ranges, AWSPublicIpAddressRange.AddressFormat addressFormat)
		{
			string prefixKey = ((addressFormat == AWSPublicIpAddressRange.AddressFormat.Ipv4) ? "ip_prefix" : "ipv6_prefix");
			List<AWSPublicIpAddressRange> list = new List<AWSPublicIpAddressRange>();
			list.AddRange(from JsonData range in ranges
				select new AWSPublicIpAddressRange
				{
					IpAddressFormat = addressFormat,
					IpPrefix = (string)range[prefixKey],
					Region = (string)range["region"],
					Service = (string)range["service"],
					NetworkBorderGroup = (string)range["network_border_group"]
				});
			return list;
		}

		private AWSPublicIpAddressRanges()
		{
		}
	}
	public class AWSPublicIpAddressRange
	{
		public enum AddressFormat
		{
			Ipv4,
			Ipv6
		}

		public string IpPrefix { get; internal set; }

		public AddressFormat IpAddressFormat { get; internal set; }

		public string Region { get; internal set; }

		public string Service { get; internal set; }

		public string NetworkBorderGroup { get; internal set; }
	}
	public static class AWSSDKUtils
	{
		internal const string DefaultRegion = "us-east-1";

		internal const string DefaultGovRegion = "us-gov-west-1";

		private const char WindowsDirectorySeparatorChar = '\\';

		private const char WindowsAltDirectorySeparatorChar = '/';

		private const char WindowsVolumeSeparatorChar = ':';

		private const char SlashChar = '/';

		private const string Slash = "/";

		private const string EncodedSlash = "%2F";

		internal const int DefaultMaxRetry = 3;

		private const int DefaultConnectionLimit = 50;

		private const int DefaultMaxIdleTime = 50000;

		public static readonly DateTime EPOCH_START = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public const int DefaultBufferSize = 8192;

		public const long DefaultProgressUpdateInterval = 102400L;

		internal static Dictionary<int, string> RFCEncodingSchemes = new Dictionary<int, string>
		{
			{ 3986, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~" },
			{ 1738, "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_." }
		};

		internal const string S3Accelerate = "s3-accelerate";

		internal const string S3Control = "s3-control";

		private const int DefaultMarshallerVersion = 1;

		private static readonly string _userAgent = InternalSDKUtils.BuildUserAgentString(string.Empty);

		public const string UserAgentHeader = "User-Agent";

		public const string ValidUrlCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";

		public const string ValidUrlCharactersRFC1738 = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.";

		private static string ValidPathCharacters = DetermineValidPathCharacters();

		public const string UrlEncodedContent = "application/x-www-form-urlencoded; charset=utf-8";

		public const string GMTDateFormat = "ddd, dd MMM yyyy HH:mm:ss \\G\\M\\T";

		public const string ISO8601DateFormat = "yyyy-MM-dd\\THH:mm:ss.fff\\Z";

		public const string ISO8601DateFormatNoMS = "yyyy-MM-dd\\THH:mm:ss\\Z";

		public const string ISO8601BasicDateTimeFormat = "yyyyMMddTHHmmssZ";

		public const string ISO8601BasicDateFormat = "yyyyMMdd";

		public const string RFC822DateFormat = "ddd, dd MMM yyyy HH:mm:ss \\G\\M\\T";

		private static BackgroundInvoker _dispatcher;

		private static BackgroundInvoker Dispatcher
		{
			get
			{
				if (_dispatcher == null)
				{
					_dispatcher = new BackgroundInvoker();
				}
				return _dispatcher;
			}
		}

		public static string FormattedCurrentTimestampGMT => CorrectedUtcNow.ToString("ddd, dd MMM yyyy HH:mm:ss \\G\\M\\T", CultureInfo.InvariantCulture);

		public static string FormattedCurrentTimestampISO8601 => GetFormattedTimestampISO8601(0);

		public static string FormattedCurrentTimestampRFC822 => GetFormattedTimestampRFC822(0);

		[Obsolete("This property does not account for endpoint specific clock skew.  Use CorrectClockSkew.GetCorrectedUtcNowForEndpoint() instead.")]
		public static DateTime CorrectedUtcNow
		{
			get
			{
				DateTime result = AWSConfigs.utcNowSource();
				if (AWSConfigs.ManualClockCorrection.HasValue)
				{
					result += AWSConfigs.ManualClockCorrection.Value;
				}
				return result;
			}
		}

		private static string DetermineValidPathCharacters()
		{
			StringBuilder stringBuilder = new StringBuilder();
			string text = "/:'()!*[]$";
			for (int i = 0; i < text.Length; i++)
			{
				char c = text[i];
				string text2 = System.Uri.EscapeUriString(c.ToString());
				if (text2.Length == 1 && text2[0] == c)
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		public static string GetExtension(string path)
		{
			if (path == null)
			{
				return null;
			}
			int length = path.Length;
			int num = length;
			checked
			{
				while (--num >= 0)
				{
					char c = path[num];
					if (c == '.')
					{
						if (num != length - 1)
						{
							return path.Substring(num, length - num);
						}
						return string.Empty;
					}
					if (IsPathSeparator(c))
					{
						break;
					}
				}
				return string.Empty;
			}
		}

		private static bool IsPathSeparator(char ch)
		{
			if (ch != '\\' && ch != '/')
			{
				return ch == ':';
			}
			return true;
		}

		internal static string CalculateStringToSignV2(ParameterCollection parameterCollection, string serviceUrl)
		{
			StringBuilder stringBuilder = new StringBuilder("POST\n", 512);
			List<KeyValuePair<string, string>> sortedParametersList = parameterCollection.GetSortedParametersList();
			System.Uri uri = new System.Uri(serviceUrl);
			stringBuilder.Append(uri.Host);
			stringBuilder.Append("\n");
			string text = uri.AbsolutePath;
			if (text == null || text.Length == 0)
			{
				text = "/";
			}
			stringBuilder.Append(UrlEncode(text, path: true));
			stringBuilder.Append("\n");
			foreach (KeyValuePair<string, string> item in sortedParametersList)
			{
				if (item.Value != null)
				{
					stringBuilder.Append(UrlEncode(item.Key, path: false));
					stringBuilder.Append("=");
					stringBuilder.Append(UrlEncode(item.Value, path: false));
					stringBuilder.Append("&");
				}
			}
			string text2 = stringBuilder.ToString();
			return text2.Remove(checked(text2.Length - 1));
		}

		internal static string GetParametersAsString(IRequest request)
		{
			return GetParametersAsString(request.ParameterCollection);
		}

		internal static string GetParametersAsString(ParameterCollection parameterCollection)
		{
			List<KeyValuePair<string, string>> sortedParametersList = parameterCollection.GetSortedParametersList();
			StringBuilder stringBuilder = new StringBuilder(512);
			foreach (KeyValuePair<string, string> item in sortedParametersList)
			{
				string key = item.Key;
				string value = item.Value;
				if (value != null)
				{
					stringBuilder.Append(key);
					stringBuilder.Append('=');
					stringBuilder.Append(UrlEncode(value, path: false));
					stringBuilder.Append('&');
				}
			}
			string text = stringBuilder.ToString();
			if (text.Length == 0)
			{
				return string.Empty;
			}
			return text.Remove(checked(text.Length - 1));
		}

		public static string CanonicalizeResourcePath(System.Uri endpoint, string resourcePath)
		{
			return CanonicalizeResourcePath(endpoint, resourcePath, detectPreEncode: false, null, 1);
		}

		public static string CanonicalizeResourcePath(System.Uri endpoint, string resourcePath, bool detectPreEncode)
		{
			return CanonicalizeResourcePath(endpoint, resourcePath, detectPreEncode, null, 1);
		}

		public static string CanonicalizeResourcePath(System.Uri endpoint, string resourcePath, bool detectPreEncode, IDictionary<string, string> pathResources, int marshallerVersion)
		{
			if (endpoint != null)
			{
				string text = endpoint.AbsolutePath;
				if (string.IsNullOrEmpty(text) || string.Equals(text, "/", StringComparison.Ordinal))
				{
					text = string.Empty;
				}
				if (!string.IsNullOrEmpty(resourcePath) && resourcePath.StartsWith("/", StringComparison.Ordinal))
				{
					resourcePath = resourcePath.Substring(1);
				}
				if (!string.IsNullOrEmpty(resourcePath))
				{
					text = text + "/" + resourcePath;
				}
				resourcePath = text;
			}
			if (string.IsNullOrEmpty(resourcePath))
			{
				return "/";
			}
			IEnumerable<string> enumerable = ((marshallerVersion < 2) ? resourcePath.Split(new char[1] { '/' }, StringSplitOptions.None) : SplitResourcePathIntoSegments(resourcePath, pathResources));
			bool flag = false;
			if (detectPreEncode)
			{
				if (endpoint == null)
				{
					throw new ArgumentNullException("endpoint", "A non-null endpoint is necessary to decide whether or not to pre URL encode.");
				}
				if (!S3Uri.IsS3Uri(endpoint))
				{
					enumerable = ((marshallerVersion < 2) ? enumerable.Select((string segment) => ProtectEncodedSlashUrlEncode(segment, path: true)) : enumerable.Select((string segment) => UrlEncode(segment, path: true).Replace("/", "%2F")));
					flag = true;
				}
			}
			string empty = string.Empty;
			if (marshallerVersion >= 2)
			{
				empty = JoinResourcePathSegments(enumerable, path: false);
			}
			else
			{
				enumerable = enumerable.Select((string segment) => UrlEncode(segment, path: false));
				empty = string.Join("/", enumerable.ToArray());
			}
			Logger.GetLogger(typeof(AWSSDKUtils)).DebugFormat("{0} encoded {1}{2} for canonicalization: {3}", flag ? "Double" : "Single", resourcePath, (endpoint == null) ? "" : (" with endpoint " + endpoint.AbsoluteUri), empty);
			return empty;
		}

		public static IEnumerable<string> SplitResourcePathIntoSegments(string resourcePath, IDictionary<string, string> pathResources)
		{
			char[] separator = new char[1] { '/' };
			string[] array = resourcePath.Split(separator, StringSplitOptions.None);
			if (pathResources == null || pathResources.Count == 0)
			{
				return array;
			}
			List<string> list = new List<string>();
			string[] array2 = array;
			foreach (string text in array2)
			{
				if (!pathResources.ContainsKey(text))
				{
					list.Add(text);
				}
				else if (text.EndsWith("+}", StringComparison.Ordinal))
				{
					list.AddRange(pathResources[text].Split(separator, StringSplitOptions.None));
				}
				else
				{
					list.Add(pathResources[text]);
				}
			}
			return list;
		}

		public static string JoinResourcePathSegments(IEnumerable<string> pathSegments, bool path)
		{
			pathSegments = pathSegments.Select((string segment) => UrlEncode(segment, path));
			if (path)
			{
				pathSegments = pathSegments.Select((string segment) => segment.Replace("/", "%2F"));
			}
			return string.Join("/", pathSegments.ToArray());
		}

		public static string ResolveResourcePath(string resourcePath, IDictionary<string, string> pathResources)
		{
			if (string.IsNullOrEmpty(resourcePath))
			{
				return resourcePath;
			}
			return JoinResourcePathSegments(SplitResourcePathIntoSegments(resourcePath, pathResources), path: true);
		}

		public static string Join(List<string> strings)
		{
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = true;
			foreach (string @string in strings)
			{
				if (!flag)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(@string);
				flag = false;
			}
			return stringBuilder.ToString();
		}

		public static string DetermineRegion(string url)
		{
			int num = url.IndexOf("//", StringComparison.Ordinal);
			checked
			{
				if (num >= 0)
				{
					url = url.Substring(num + 2);
				}
				if (url.EndsWith("/", StringComparison.Ordinal))
				{
					url = url.Substring(0, url.Length - 1);
				}
				int num2 = url.IndexOf(".amazonaws.com", StringComparison.Ordinal);
				if (num2 < 0)
				{
					return "us-east-1";
				}
				string text = url.Substring(0, num2);
				int num3 = url.IndexOf(".cloudsearch.amazonaws.com", StringComparison.Ordinal);
				if (num3 > 0)
				{
					text = url.Substring(0, num3);
				}
				int num4 = text.IndexOf("queue", StringComparison.Ordinal);
				if (num4 == 0)
				{
					return "us-east-1";
				}
				if (num4 > 0)
				{
					return text.Substring(0, num4 - 1);
				}
				if (text.StartsWith("s3-", StringComparison.Ordinal) && !text.StartsWith("s3-control", StringComparison.Ordinal))
				{
					if (text.Equals("s3-accelerate", StringComparison.Ordinal))
					{
						return null;
					}
					text = "s3." + text.Substring(3);
				}
				int num5 = text.LastIndexOf('.');
				if (num5 == -1)
				{
					return "us-east-1";
				}
				string text2 = text.Substring(num5 + 1);
				if (text2.Equals("external-1"))
				{
					return RegionEndpoint.USEast1.SystemName;
				}
				if (string.Equals(text2, "us-gov", StringComparison.Ordinal))
				{
					return "us-gov-west-1";
				}
				return text2;
			}
		}

		public static string DetermineService(string url)
		{
			int num = url.IndexOf("//", StringComparison.Ordinal);
			if (num >= 0)
			{
				url = url.Substring(checked(num + 2));
			}
			string[] array = url.Split(new char[1] { '.' }, StringSplitOptions.RemoveEmptyEntries);
			if (array == null || array.Length == 0)
			{
				return string.Empty;
			}
			string text = array[0];
			int num2 = text.IndexOf('-');
			string text2 = ((num2 >= 0) ? text.Substring(0, num2) : text);
			if (text2.Equals("queue"))
			{
				return "sqs";
			}
			return text2;
		}

		public static DateTime ConvertFromUnixEpochSeconds(int seconds)
		{
			checked
			{
				long num = unchecked((long)seconds) * 10000000L;
				DateTime ePOCH_START = EPOCH_START;
				return new DateTime(num + ePOCH_START.Ticks, DateTimeKind.Utc).ToLocalTime();
			}
		}

		public static int ConvertToUnixEpochSeconds(DateTime dateTime)
		{
			return Convert.ToInt32(GetTimeSpanInTicks(dateTime).TotalSeconds);
		}

		public static string ConvertToUnixEpochSecondsString(DateTime dateTime)
		{
			return Convert.ToInt64(GetTimeSpanInTicks(dateTime).TotalSeconds).ToString(CultureInfo.InvariantCulture);
		}

		[Obsolete("This method isn't named correctly: it returns seconds instead of milliseconds. Use ConvertToUnixEpochSecondsDouble instead.", false)]
		public static double ConvertToUnixEpochMilliSeconds(DateTime dateTime)
		{
			return ConvertToUnixEpochSecondsDouble(dateTime);
		}

		public static double ConvertToUnixEpochSecondsDouble(DateTime dateTime)
		{
			return Math.Round(GetTimeSpanInTicks(dateTime).TotalMilliseconds, 0) / 1000.0;
		}

		public static TimeSpan GetTimeSpanInTicks(DateTime dateTime)
		{
			long ticks = dateTime.ToUniversalTime().Ticks;
			DateTime ePOCH_START = EPOCH_START;
			return new TimeSpan(checked(ticks - ePOCH_START.Ticks));
		}

		public static long ConvertDateTimetoMilliseconds(DateTime dateTime)
		{
			return ConvertTimeSpanToMilliseconds(GetTimeSpanInTicks(dateTime));
		}

		public static long ConvertTimeSpanToMilliseconds(TimeSpan timeSpan)
		{
			return timeSpan.Ticks / 10000;
		}

		public static string ToHex(byte[] data, bool lowercase)
		{
			StringBuilder stringBuilder = new StringBuilder();
			for (int i = 0; i < data.Length; i = checked(i + 1))
			{
				stringBuilder.Append(data[i].ToString(lowercase ? "x2" : "X2", CultureInfo.InvariantCulture));
			}
			return stringBuilder.ToString();
		}

		public static void InvokeInBackground<T>(EventHandler<T> handler, T args, object sender) where T : EventArgs
		{
			if (handler == null)
			{
				return;
			}
			Delegate[] invocationList = handler.GetInvocationList();
			foreach (Delegate obj in invocationList)
			{
				EventHandler<T> eventHandler = (EventHandler<T>)obj;
				if (eventHandler != null)
				{
					Dispatcher.Dispatch(delegate
					{
						eventHandler(sender, args);
					});
				}
			}
		}

		public static Dictionary<string, string> ParseQueryParameters(string url)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			if (!string.IsNullOrEmpty(url))
			{
				int num = url.IndexOf('?');
				if (num >= 0)
				{
					string[] array = url.Substring(checked(num + 1)).Split(new char[1] { '&' }, StringSplitOptions.None);
					foreach (string text in array)
					{
						if (!string.IsNullOrEmpty(text))
						{
							string[] array2 = text.Split(new char[1] { '=' }, 2);
							string key = array2[0];
							string value = ((array2.Length == 1) ? null : array2[1]);
							dictionary[key] = value;
						}
					}
				}
			}
			return dictionary;
		}

		internal static bool AreEqual(object[] itemsA, object[] itemsB)
		{
			if (itemsA == null || itemsB == null)
			{
				return itemsA == itemsB;
			}
			if (itemsA.Length != itemsB.Length)
			{
				return false;
			}
			int num = itemsA.Length;
			for (int i = 0; i < num; i = checked(i + 1))
			{
				object a = itemsA[i];
				object b = itemsB[i];
				if (!AreEqual(a, b))
				{
					return false;
				}
			}
			return true;
		}

		internal static bool AreEqual(object a, object b)
		{
			if (a == null || b == null)
			{
				return a == b;
			}
			if (a == b)
			{
				return true;
			}
			return a.Equals(b);
		}

		internal static bool DictionariesAreEqual<K, V>(Dictionary<K, V> a, Dictionary<K, V> b)
		{
			if (a == null || b == null)
			{
				return a == b;
			}
			if (a == b)
			{
				return true;
			}
			if (a.Count == b.Count)
			{
				return !a.Except(b).Any();
			}
			return false;
		}

		public static MemoryStream GenerateMemoryStreamFromString(string s)
		{
			MemoryStream memoryStream = new MemoryStream();
			StreamWriter streamWriter = new StreamWriter(memoryStream);
			streamWriter.Write(s);
			streamWriter.Flush();
			memoryStream.Position = 0L;
			return memoryStream;
		}

		public static void CopyStream(Stream source, Stream destination)
		{
			CopyStream(source, destination, 8192);
		}

		public static void CopyStream(Stream source, Stream destination, int bufferSize)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (destination == null)
			{
				throw new ArgumentNullException("destination");
			}
			if (bufferSize <= 0)
			{
				throw new ArgumentOutOfRangeException("bufferSize");
			}
			byte[] array = new byte[bufferSize];
			int count;
			while ((count = source.Read(array, 0, array.Length)) != 0)
			{
				destination.Write(array, 0, count);
			}
		}

		public static string GetFormattedTimestampISO8601(int minutesFromNow)
		{
			return GetFormattedTimestampISO8601(CorrectedUtcNow.AddMinutes(minutesFromNow));
		}

		internal static string GetFormattedTimestampISO8601(IClientConfig config)
		{
			return GetFormattedTimestampISO8601(config.CorrectedUtcNow);
		}

		private static string GetFormattedTimestampISO8601(DateTime dateTime)
		{
			return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day, dateTime.Hour, dateTime.Minute, dateTime.Second, dateTime.Millisecond, DateTimeKind.Local).ToString("yyyy-MM-dd\\THH:mm:ss.fff\\Z", CultureInfo.InvariantCulture);
		}

		public static string GetFormattedTimestampRFC822(int minutesFromNow)
		{
			return CorrectedUtcNow.AddMinutes(minutesFromNow).ToString("ddd, dd MMM yyyy HH:mm:ss \\G\\M\\T", CultureInfo.InvariantCulture);
		}

		public static bool IsAbsolutePath(string path)
		{
			if (!IsWindows())
			{
				return Path.IsPathRooted(path);
			}
			return !IsPartiallyQualifiedForWindows(path);
		}

		private static bool IsWindows()
		{
			return true;
		}

		private static bool IsPartiallyQualifiedForWindows(string path)
		{
			if (path.Length < 2)
			{
				return true;
			}
			if (IsWindowsDirectorySeparator(path[0]))
			{
				if (path[1] != '?')
				{
					return !IsWindowsDirectorySeparator(path[1]);
				}
				return false;
			}
			if (path.Length >= 3 && path[1] == ':' && IsWindowsDirectorySeparator(path[2]))
			{
				return !IsValidWindowsDriveChar(path[0]);
			}
			return true;
		}

		private static bool IsWindowsDirectorySeparator(char c)
		{
			if (c != '\\')
			{
				return c == '/';
			}
			return true;
		}

		private static bool IsValidWindowsDriveChar(char value)
		{
			if (value < 'A' || value > 'Z')
			{
				if (value >= 'a')
				{
					return value <= 'z';
				}
				return false;
			}
			return true;
		}

		public static string UrlEncode(string data, bool path)
		{
			return UrlEncode(3986, data, path);
		}

		public static string UrlEncode(int rfcNumber, string data, bool path)
		{
			StringBuilder stringBuilder = new StringBuilder(checked(data.Length * 2));
			if (!RFCEncodingSchemes.TryGetValue(rfcNumber, out var value))
			{
				value = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~";
			}
			string text = value + (path ? ValidPathCharacters : "");
			byte[] bytes = Encoding.UTF8.GetBytes(data);
			for (int i = 0; i < bytes.Length; i++)
			{
				char c = (char)bytes[i];
				if (text.IndexOf(c) != -1)
				{
					stringBuilder.Append(c);
				}
				else
				{
					stringBuilder.Append("%").Append(string.Format(CultureInfo.InvariantCulture, "{0:X2}", (int)c));
				}
			}
			return stringBuilder.ToString();
		}

		internal static string UrlEncodeSlash(string data)
		{
			if (string.IsNullOrEmpty(data))
			{
				return data;
			}
			return data.Replace("/", "%2F");
		}

		public static string ProtectEncodedSlashUrlEncode(string data, bool path)
		{
			if (string.IsNullOrEmpty(data))
			{
				return data;
			}
			int num = 0;
			StringBuilder stringBuilder = new StringBuilder();
			checked
			{
				for (int num2 = data.IndexOf("%2F", num, StringComparison.OrdinalIgnoreCase); num2 != -1; num2 = data.IndexOf("%2F", num, StringComparison.OrdinalIgnoreCase))
				{
					stringBuilder.Append(UrlEncode(data.Substring(num, num2 - num), path));
					stringBuilder.Append("%2F");
					num = num2 + "%2F".Length;
				}
				if (num == 0)
				{
					return UrlEncode(data, path);
				}
				if (data.Length > num)
				{
					stringBuilder.Append(UrlEncode(data.Substring(num), path));
				}
				return stringBuilder.ToString();
			}
		}

		public static void Sleep(TimeSpan ts)
		{
			Sleep(checked((int)ts.TotalMilliseconds));
		}

		public static string BytesToHexString(byte[] value)
		{
			return BitConverter.ToString(value).Replace("-", string.Empty);
		}

		public static byte[] HexStringToBytes(string hex)
		{
			if (string.IsNullOrEmpty(hex) || hex.Length % 2 == 1)
			{
				throw new ArgumentOutOfRangeException("hex");
			}
			int num = 0;
			byte[] array = new byte[hex.Length / 2];
			checked
			{
				for (int i = 0; i < hex.Length; i += 2)
				{
					byte b = Convert.ToByte(hex.Substring(i, 2), 16);
					array[num] = b;
					num++;
				}
				return array;
			}
		}

		public static bool HasBidiControlCharacters(string input)
		{
			if (string.IsNullOrEmpty(input))
			{
				return false;
			}
			for (int i = 0; i < input.Length; i++)
			{
				if (IsBidiControlChar(input[i]))
				{
					return true;
				}
			}
			return false;
		}

		private static bool IsBidiControlChar(char c)
		{
			switch (c)
			{
			default:
				return false;
			case '‐':
			case '‑':
			case '‒':
			case '–':
			case '—':
			case '―':
			case '‖':
			case '‗':
			case '‘':
			case '’':
			case '‚':
			case '‛':
			case '“':
			case '”':
			case '„':
			case '‟':
			case '†':
			case '‡':
			case '•':
			case '‣':
			case '․':
			case '‥':
			case '…':
			case '‧':
			case '\u2028':
			case '\u2029':
			case '\u202e':
				return c == '\u202e';
			case '\u200e':
			case '\u200f':
			case '\u202a':
			case '\u202b':
			case '\u202c':
			case '\u202d':
				return true;
			}
		}

		public static string DownloadStringContent(System.Uri uri)
		{
			return DownloadStringContent(uri, TimeSpan.Zero, null);
		}

		public static string DownloadStringContent(System.Uri uri, TimeSpan timeout)
		{
			return DownloadStringContent(uri, timeout, null);
		}

		public static string DownloadStringContent(System.Uri uri, IWebProxy proxy)
		{
			return DownloadStringContent(uri, TimeSpan.Zero, proxy);
		}

		public static string DownloadStringContent(System.Uri uri, TimeSpan timeout, IWebProxy proxy)
		{
			HttpClient client = CreateClient(uri, timeout, proxy, null);
			try
			{
				return AsyncHelpers.RunSync(() => client.GetStringAsync(uri));
			}
			finally
			{
				if (client != null)
				{
					((IDisposable)client).Dispose();
				}
			}
		}

		public static string ExecuteHttpRequest(System.Uri uri, string requestType, string content, TimeSpan timeout, IWebProxy proxy, IDictionary<string, string> headers)
		{
			HttpClient client = CreateClient(uri, timeout, proxy, headers);
			try
			{
				HttpResponseMessage response = AsyncHelpers.RunSync(delegate
				{
					HttpRequestMessage httpRequestMessage = new HttpRequestMessage(new HttpMethod(requestType), uri);
					if (!string.IsNullOrEmpty(content))
					{
						httpRequestMessage.Content = new StringContent(content);
					}
					return client.SendAsync(httpRequestMessage);
				});
				try
				{
					response.EnsureSuccessStatusCode();
				}
				catch (HttpRequestException ex)
				{
					HttpRequestException obj = new HttpRequestException(ex.Message, ex)
					{
						Data = { 
						{
							(object)"StatusCode",
							(object)response.StatusCode
						} }
					};
					response.Dispose();
					throw obj;
				}
				try
				{
					return AsyncHelpers.RunSync(() => response.Content.ReadAsStringAsync());
				}
				finally
				{
					response.Dispose();
				}
			}
			finally
			{
				if (client != null)
				{
					((IDisposable)client).Dispose();
				}
			}
		}

		private static HttpClient CreateClient(System.Uri uri, TimeSpan timeout, IWebProxy proxy, IDictionary<string, string> headers)
		{
			HttpClient httpClient = new HttpClient(new HttpClientHandler
			{
				Proxy = proxy
			});
			if (timeout > TimeSpan.Zero)
			{
				httpClient.Timeout = timeout;
			}
			httpClient.DefaultRequestHeaders.TryAddWithoutValidation("User-Agent", _userAgent);
			if (headers != null)
			{
				foreach (KeyValuePair<string, string> header in headers)
				{
					httpClient.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
				}
			}
			return httpClient;
		}

		public static Stream OpenStream(System.Uri uri)
		{
			return OpenStream(uri, null);
		}

		public static Stream OpenStream(System.Uri uri, IWebProxy proxy)
		{
			using HttpClient httpClient = new HttpClient(new HttpClientHandler
			{
				Proxy = proxy
			});
			return httpClient.GetStreamAsync(uri).Result;
		}

		public static string CompressSpaces(string data)
		{
			if (data == null)
			{
				return null;
			}
			if (data.Length == 0)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			bool flag = false;
			foreach (char c in data)
			{
				if (!flag | !(flag = char.IsWhiteSpace(c)))
				{
					stringBuilder.Append(flag ? ' ' : c);
				}
			}
			return stringBuilder.ToString();
		}

		internal static void ForceCanonicalPathAndQuery(System.Uri uri)
		{
		}

		internal static void PreserveStackTrace(Exception exception)
		{
		}

		internal static int GetConnectionLimit(int? clientConfigValue)
		{
			if (clientConfigValue.HasValue)
			{
				return clientConfigValue.Value;
			}
			return 50;
		}

		public static void Sleep(int ms)
		{
			new ManualResetEvent(initialState: false).WaitOne(ms);
		}
	}
	public class JitteredDelay
	{
		private TimeSpan _maxDelay;

		private TimeSpan _variance;

		private TimeSpan _baseIncrement;

		private Random _rand;

		private int _count;

		public JitteredDelay(TimeSpan baseIncrement, TimeSpan variance)
			: this(baseIncrement, variance, new TimeSpan(0, 0, 30))
		{
		}

		public JitteredDelay(TimeSpan baseIncrement, TimeSpan variance, TimeSpan maxDelay)
		{
			_baseIncrement = baseIncrement;
			_variance = variance;
			_maxDelay = maxDelay;
			_rand = new Random();
		}

		public TimeSpan GetRetryDelay(int attemptCount)
		{
			return new TimeSpan(checked(_baseIncrement.Ticks * (long)Math.Pow(2.0, attemptCount) + (long)(_rand.NextDouble() * (double)_variance.Ticks)));
		}

		public TimeSpan Next()
		{
			checked
			{
				long ticks = GetRetryDelay(_count + 1).Ticks;
				if (ticks < _maxDelay.Ticks)
				{
					_count++;
				}
				else
				{
					ticks = _maxDelay.Ticks;
				}
				return new TimeSpan(ticks);
			}
		}

		public void Reset()
		{
			_count = 0;
		}
	}
	public static class CryptoUtilFactory
	{
		private class CryptoUtil : ICryptoUtil
		{
			[ThreadStatic]
			private static IHashAlgorithmProvider _hashAlgorithm;

			private static IHashAlgorithmProvider SHA256HashAlgorithmInstance
			{
				get
				{
					if (_hashAlgorithm == null)
					{
						_hashAlgorithm = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(HashAlgorithm.Sha256);
					}
					return _hashAlgorithm;
				}
			}

			internal CryptoUtil()
			{
			}

			public string HMACSign(string data, string key, SigningAlgorithm algorithmName)
			{
				byte[] bytes = Encoding.UTF8.GetBytes(data);
				return HMACSign(bytes, key, algorithmName);
			}

			public string HMACSign(byte[] data, string key, SigningAlgorithm algorithmName)
			{
				IMacAlgorithmProvider macAlgorithmProvider = WinRTCrypto.MacAlgorithmProvider.OpenAlgorithm(Convert(algorithmName));
				if (string.IsNullOrEmpty(key))
				{
					throw new ArgumentNullException("key", "Please specify a Secret Signing Key.");
				}
				if (data == null || data.Length == 0)
				{
					throw new ArgumentNullException("data", "Please specify data to sign.");
				}
				if (macAlgorithmProvider == null)
				{
					throw new ArgumentNullException("algorithm", "Please specify a KeyedHashAlgorithm to use.");
				}
				byte[] data2 = WinRTCrypto.CryptographicBuffer.CreateFromByteArray(data);
				byte[] keyMaterial = WinRTCrypto.CryptographicBuffer.ConvertStringToBinary(key, Encoding.UTF8);
				ICryptographicKey key2 = macAlgorithmProvider.CreateKey(keyMaterial);
				byte[] buffer = WinRTCrypto.CryptographicEngine.Sign(key2, data2);
				return WinRTCrypto.CryptographicBuffer.EncodeToBase64String(buffer);
			}

			public byte[] HMACSignBinary(byte[] data, byte[] key, SigningAlgorithm algorithmName)
			{
				IMacAlgorithmProvider macAlgorithmProvider = WinRTCrypto.MacAlgorithmProvider.OpenAlgorithm(Convert(algorithmName));
				if (key == null || key.Length == 0)
				{
					throw new ArgumentNullException("key", "Please specify a Secret Signing Key.");
				}
				if (data == null || data.Length == 0)
				{
					throw new ArgumentNullException("data", "Please specify data to sign.");
				}
				if (macAlgorithmProvider == null)
				{
					throw new ArgumentNullException("algorithm", "Please specify a KeyedHashAlgorithm to use.");
				}
				byte[] data2 = WinRTCrypto.CryptographicBuffer.CreateFromByteArray(data);
				byte[] keyMaterial = WinRTCrypto.CryptographicBuffer.CreateFromByteArray(key);
				ICryptographicKey key2 = macAlgorithmProvider.CreateKey(keyMaterial);
				byte[] buffer = WinRTCrypto.CryptographicEngine.Sign(key2, data2);
				WinRTCrypto.CryptographicBuffer.CopyToByteArray(buffer, out var value);
				return value;
			}

			public byte[] ComputeSHA256Hash(byte[] data)
			{
				return SHA256HashAlgorithmInstance.HashData(data);
			}

			public byte[] ComputeSHA256Hash(Stream stream)
			{
				using CryptographicHash cryptographicHash = SHA256HashAlgorithmInstance.CreateHash();
				int num = 0;
				byte[] array = new byte[8192];
				while ((num = stream.Read(array, 0, array.Length)) != 0)
				{
					Append(cryptographicHash, num, array);
				}
				return cryptographicHash.GetValueAndReset();
			}

			private static void Append(CryptographicHash hash, int bytesRead, byte[] buffer)
			{
				if (bytesRead == buffer.Length)
				{
					hash.Append(buffer);
					return;
				}
				byte[] array = new byte[bytesRead];
				Array.Copy(buffer, array, bytesRead);
				hash.Append(array);
			}

			public byte[] ComputeMD5Hash(byte[] data)
			{
				using HashingWrapperMD5 hashingWrapperMD = new HashingWrapperMD5();
				return hashingWrapperMD.ComputeHash(data);
			}

			public byte[] ComputeMD5Hash(Stream stream)
			{
				using HashingWrapperMD5 hashingWrapperMD = new HashingWrapperMD5();
				return hashingWrapperMD.ComputeHash(stream);
			}

			private MacAlgorithm Convert(SigningAlgorithm algorithm)
			{
				return algorithm switch
				{
					SigningAlgorithm.HmacSHA256 => MacAlgorithm.HmacSha256, 
					SigningAlgorithm.HmacSHA1 => MacAlgorithm.HmacSha1, 
					_ => throw new Exception("Unknown signing algorithm: " + algorithm), 
				};
			}
		}

		private static CryptoUtil util = new CryptoUtil();

		public static ICryptoUtil CryptoInstance => util;
	}
	public abstract class HeaderKeys
	{
		public const string IfModifiedSinceHeader = "If-Modified-Since";

		public const string IfMatchHeader = "If-Match";

		public const string IfNoneMatchHeader = "If-None-Match";

		public const string IfUnmodifiedSinceHeader = "If-Unmodified-Since";

		public const string ConfirmSelfBucketAccess = "x-amz-confirm-remove-self-bucket-access";

		public const string ContentRangeHeader = "Content-Range";

		public const string ContentTypeHeader = "Content-Type";

		public const string ContentLengthHeader = "Content-Length";

		public const string ContentMD5Header = "Content-MD5";

		public const string ContentEncodingHeader = "Content-Encoding";

		public const string ContentDispositionHeader = "Content-Disposition";

		public const string ETagHeader = "ETag";

		public const string Expires = "Expires";

		public const string AuthorizationHeader = "Authorization";

		public const string HostHeader = "host";

		public const string UserAgentHeader = "User-Agent";

		public const string LocationHeader = "location";

		public const string DateHeader = "Date";

		public const string RangeHeader = "Range";

		public const string ExpectHeader = "Expect";

		public const string AcceptHeader = "Accept";

		public const string ConnectionHeader = "Connection";

		public const string StatusHeader = "Status";

		public const string XHttpMethodOverrideHeader = "X-HTTP-Method-Override";

		public const string TransferEncodingHeader = "transfer-encoding";

		public const string RequestIdHeader = "x-amzn-RequestId";

		public const string XAmzId2Header = "x-amz-id-2";

		public const string XAmzCloudFrontIdHeader = "X-Amz-Cf-Id";

		public const string XAmzRequestIdHeader = "x-amz-request-id";

		public const string XAmzDateHeader = "X-Amz-Date";

		public const string XAmzErrorType = "x-amzn-ErrorType";

		public const string XAmznErrorMessage = "x-amzn-error-message";

		public const string XAmzSignedHeadersHeader = "X-Amz-SignedHeaders";

		public const string XAmzContentSha256Header = "X-Amz-Content-SHA256";

		public const string XAmzDecodedContentLengthHeader = "X-Amz-Decoded-Content-Length";

		public const string XAmzSecurityTokenHeader = "x-amz-security-token";

		public const string XAmzAuthorizationHeader = "X-Amzn-Authorization";

		public const string XAmzNonceHeader = "x-amz-nonce";

		public const string XAmzServerSideEncryptionHeader = "x-amz-server-side-encryption";

		public const string XAmzServerSideEncryptionAwsKmsKeyIdHeader = "x-amz-server-side-encryption-aws-kms-key-id";

		public const string XAmzBucketRegion = "x-amz-bucket-region";

		public const string XAmzAccountId = "x-amz-account-id";

		public const string XAmzApiVersion = "x-amz-api-version";

		public const string XAmzSSECustomerAlgorithmHeader = "x-amz-server-side-encryption-customer-algorithm";

		public const string XAmzSSECustomerKeyHeader = "x-amz-server-side-encryption-customer-key";

		public const string XAmzSSECustomerKeyMD5Header = "x-amz-server-side-encryption-customer-key-MD5";

		public const string XAmzCopySourceSSECustomerAlgorithmHeader = "x-amz-copy-source-server-side-encryption-customer-algorithm";

		public const string XAmzCopySourceSSECustomerKeyHeader = "x-amz-copy-source-server-side-encryption-customer-key";

		public const string XAmzCopySourceSSECustomerKeyMD5Header = "x-amz-copy-source-server-side-encryption-customer-key-MD5";

		public const string XAmzStorageClassHeader = "x-amz-storage-class";

		public const string XAmzWebsiteRedirectLocationHeader = "x-amz-website-redirect-location";

		public const string XAmzContentLengthHeader = "x-amz-content-length";

		public const string XAmzAclHeader = "x-amz-acl";

		public const string XAmzCopySourceHeader = "x-amz-copy-source";

		public const string XAmzCopySourceRangeHeader = "x-amz-copy-source-range";

		public const string XAmzCopySourceIfMatchHeader = "x-amz-copy-source-if-match";

		public const string XAmzCopySourceIfModifiedSinceHeader = "x-amz-copy-source-if-modified-since";

		public const string XAmzCopySourceIfNoneMatchHeader = "x-amz-copy-source-if-none-match";

		public const string XAmzCopySourceIfUnmodifiedSinceHeader = "x-amz-copy-source-if-unmodified-since";

		public const string XAmzMetadataDirectiveHeader = "x-amz-metadata-directive";

		public const string XAmzMfaHeader = "x-amz-mfa";

		public const string XAmzVersionIdHeader = "x-amz-version-id";

		public const string XAmzUserAgentHeader = "x-amz-user-agent";

		public const string XAmzAbortDateHeader = "x-amz-abort-date";

		public const string XAmzAbortRuleIdHeader = "x-amz-abort-rule-id";

		public const string XAmznTraceIdHeader = "x-amzn-trace-id";

		public const string XAwsEc2MetadataTokenTtlSeconds = "x-aws-ec2-metadata-token-ttl-seconds";

		public const string XAwsEc2MetadataToken = "x-aws-ec2-metadata-token";
	}
	public interface ICryptoUtil
	{
		string HMACSign(string data, string key, SigningAlgorithm algorithmName);

		string HMACSign(byte[] data, string key, SigningAlgorithm algorithmName);

		byte[] ComputeSHA256Hash(byte[] data);

		byte[] ComputeSHA256Hash(Stream steam);

		byte[] ComputeMD5Hash(byte[] data);

		byte[] ComputeMD5Hash(Stream steam);

		byte[] HMACSignBinary(byte[] data, byte[] key, SigningAlgorithm algorithmName);
	}
	internal class PaginatedResource<U> : IEnumerable<U>, IEnumerable
	{
		internal Func<string, Marker<U>> fetcher;

		internal PaginatedResource(Func<string, Marker<U>> fetcher)
		{
			this.fetcher = fetcher;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public IEnumerator<U> GetEnumerator()
		{
			return new PaginationEnumerator<U>(this);
		}
	}
	internal class Marker<U>
	{
		private List<U> data;

		private string nextToken;

		internal List<U> Data => data;

		internal string NextToken => nextToken;

		internal Marker(List<U> data, string nextToken)
		{
			this.data = data;
			this.nextToken = nextToken;
		}
	}
	internal class PaginationEnumerator<U> : IEnumerator<U>, IDisposable, IEnumerator
	{
		private PaginatedResource<U> paginatedResource;

		private int position = -1;

		private static Marker<U> blankSpot = new Marker<U>(new List<U>(), null);

		private Marker<U> currentSpot = blankSpot;

		private bool started;

		object IEnumerator.Current => Current;

		public U Current
		{
			get
			{
				try
				{
					return currentSpot.Data[position];
				}
				catch (IndexOutOfRangeException)
				{
					throw new InvalidOperationException();
				}
			}
		}

		internal PaginationEnumerator(PaginatedResource<U> paginatedResource)
		{
			this.paginatedResource = paginatedResource;
		}

		public bool MoveNext()
		{
			checked
			{
				position++;
				while (position == currentSpot.Data.Count)
				{
					if (!started || !string.IsNullOrEmpty(currentSpot.NextToken))
					{
						currentSpot = paginatedResource.fetcher(currentSpot.NextToken);
						position = 0;
						started = true;
					}
					else
					{
						currentSpot = blankSpot;
						position = -1;
					}
				}
				return position != -1;
			}
		}

		public void Reset()
		{
			position = -1;
			currentSpot = new Marker<U>(new List<U>(), null);
			started = false;
		}

		public void Dispose()
		{
		}
	}
	public static class PaginatedResourceFactory
	{
		public static object Create<TItemType, TRequestType, TResponseType>(PaginatedResourceInfo pri)
		{
			pri.Verify();
			return Create<TItemType, TRequestType, TResponseType>(pri.Client, pri.MethodName, pri.Request, pri.TokenRequestPropertyPath, pri.TokenResponsePropertyPath, pri.ItemListPropertyPath);
		}

		private static PaginatedResource<ItemType> Create<ItemType, TRequestType, TResponseType>(object client, string methodName, object request, string tokenRequestPropertyPath, string tokenResponsePropertyPath, string itemListPropertyPath)
		{
			ITypeInfo typeInfo = TypeFactory.GetTypeInfo(client.GetType());
			MethodInfo fetcherMethod = typeInfo.GetMethod(methodName, new ITypeInfo[1] { TypeFactory.GetTypeInfo(typeof(TRequestType)) });
			GetFuncType<TRequestType, TResponseType>();
			return Create<ItemType, TRequestType, TResponseType>((TRequestType req) => (TResponseType)fetcherMethod.Invoke(client, new object[1] { req }), (TRequestType)request, tokenRequestPropertyPath, tokenResponsePropertyPath, itemListPropertyPath);
		}

		private static PaginatedResource<ItemType> Create<ItemType, TRequestType, TResponseType>(Func<TRequestType, TResponseType> call, TRequestType request, string tokenRequestPropertyPath, string tokenResponsePropertyPath, string itemListPropertyPath)
		{
			return new PaginatedResource<ItemType>(delegate(string token)
			{
				SetPropertyValueAtPath(request, tokenRequestPropertyPath, token);
				TResponseType val = call(request);
				return new Marker<ItemType>(nextToken: GetPropertyValueFromPath<string>(val, tokenResponsePropertyPath), data: GetPropertyValueFromPath<List<ItemType>>(val, itemListPropertyPath));
			});
		}

		private static void SetPropertyValueAtPath(object instance, string path, string value)
		{
			string[] array = path.Split(new char[1] { '.' });
			object obj = instance;
			Type type = instance.GetType();
			checked
			{
				int i;
				for (i = 0; i < array.Length - 1; i++)
				{
					string name = array[i];
					PropertyInfo property = TypeFactory.GetTypeInfo(type).GetProperty(name);
					obj = property.GetValue(obj, null);
					type = property.PropertyType;
				}
				TypeFactory.GetTypeInfo(type).GetProperty(array[i]).SetValue(obj, value, null);
			}
		}

		private static T GetPropertyValueFromPath<T>(object instance, string path)
		{
			string[] array = path.Split(new char[1] { '.' });
			object obj = instance;
			Type type = instance.GetType();
			string[] array2 = array;
			foreach (string name in array2)
			{
				PropertyInfo property = TypeFactory.GetTypeInfo(type).GetProperty(name);
				obj = property.GetValue(obj, null);
				type = property.PropertyType;
			}
			return (T)obj;
		}

		internal static Type GetPropertyTypeFromPath(Type start, string path)
		{
			string[] array = path.Split(new char[1] { '.' });
			Type type = start;
			string[] array2 = array;
			foreach (string name in array2)
			{
				type = TypeFactory.GetTypeInfo(type).GetProperty(name).PropertyType;
			}
			return type;
		}

		private static Type GetFuncType<T, U>()
		{
			return typeof(Func<T, U>);
		}

		internal static T Cast<T>(object o)
		{
			return (T)o;
		}
	}
	public class PaginatedResourceInfo
	{
		private string tokenRequestPropertyPath;

		private string tokenResponsePropertyPath;

		internal object Client { get; set; }

		internal string MethodName { get; set; }

		internal object Request { get; set; }

		internal string TokenRequestPropertyPath
		{
			get
			{
				string text = tokenRequestPropertyPath;
				if (string.IsNullOrEmpty(text))
				{
					text = "NextToken";
				}
				return text;
			}
			set
			{
				tokenRequestPropertyPath = value;
			}
		}

		internal string TokenResponsePropertyPath
		{
			get
			{
				string text = tokenResponsePropertyPath;
				if (string.IsNullOrEmpty(text))
				{
					text = "{0}";
					if (Client != null && !string.IsNullOrEmpty(MethodName))
					{
						MethodInfo method = TypeFactory.GetTypeInfo(Client.GetType()).GetMethod(MethodName);
						if (method != null)
						{
							Type returnType = method.ReturnType;
							string text2 = returnType.Name;
							if (text2.EndsWith("Response", StringComparison.Ordinal))
							{
								text2 = text2.Substring(0, checked(text2.Length - 8));
							}
							if (TypeFactory.GetTypeInfo(returnType).GetProperty(string.Format(CultureInfo.InvariantCulture, "{0}Result", text2)) != null)
							{
								text = string.Format(CultureInfo.InvariantCulture, text, string.Format(CultureInfo.InvariantCulture, "{0}Result.{1}", text2, "{0}"));
							}
						}
					}
					text = string.Format(CultureInfo.InvariantCulture, text, "NextToken");
				}
				return text;
			}
			set
			{
				tokenResponsePropertyPath = value;
			}
		}

		internal string ItemListPropertyPath { get; set; }

		public PaginatedResourceInfo WithClient(object client)
		{
			Client = client;
			return this;
		}

		public PaginatedResourceInfo WithMethodName(string methodName)
		{
			MethodName = methodName;
			return this;
		}

		public PaginatedResourceInfo WithRequest(object request)
		{
			Request = request;
			return this;
		}

		public PaginatedResourceInfo WithTokenRequestPropertyPath(string tokenRequestPropertyPath)
		{
			TokenRequestPropertyPath = tokenRequestPropertyPath;
			return this;
		}

		public PaginatedResourceInfo WithTokenResponsePropertyPath(string tokenResponsePropertyPath)
		{
			TokenResponsePropertyPath = tokenResponsePropertyPath;
			return this;
		}

		public PaginatedResourceInfo WithItemListPropertyPath(string itemListPropertyPath)
		{
			ItemListPropertyPath = itemListPropertyPath;
			return this;
		}

		internal void Verify()
		{
			if (Client == null)
			{
				throw new ArgumentException("PaginatedResourceInfo.Client needs to be set.");
			}
			Type type = Client.GetType();
			MethodInfo method = TypeFactory.GetTypeInfo(type).GetMethod(MethodName, new ITypeInfo[1] { TypeFactory.GetTypeInfo(Request.GetType()) });
			if (method == null)
			{
				throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "{0} has no method called {1}", type.Name, MethodName));
			}
			Type parameterType = method.GetParameters()[0].ParameterType;
			try
			{
				Convert.ChangeType(Request, parameterType, CultureInfo.InvariantCulture);
			}
			catch (Exception)
			{
				throw new ArgumentException("PaginatedResourcInfo.Request is an incompatible type.");
			}
			Type returnType = method.ReturnType;
			VerifyProperty("TokenRequestPropertyPath", parameterType, TokenRequestPropertyPath, typeof(string));
			VerifyProperty("TokenResponsePropertyPath", returnType, TokenResponsePropertyPath, typeof(string));
			VerifyProperty("ItemListPropertyPath", returnType, ItemListPropertyPath, typeof(string), skipTypecheck: true);
		}

		private static void VerifyProperty(string propName, Type start, string path, Type expectedType)
		{
			VerifyProperty(propName, start, path, expectedType, skipTypecheck: false);
		}

		private static void VerifyProperty(string propName, Type start, string path, Type expectedType, bool skipTypecheck)
		{
			Type type = null;
			if (string.IsNullOrEmpty(path))
			{
				throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "{0} must contain a value.", propName));
			}
			try
			{
				type = PaginatedResourceFactory.GetPropertyTypeFromPath(start, path);
			}
			catch (Exception)
			{
				throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "{0} does not exist on {1}", path, start.Name));
			}
			if (!skipTypecheck && type != expectedType)
			{
				throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "{0} on {1} is not of type {2}", path, start.Name, expectedType.Name));
			}
		}
	}
	public class ProcessExecutionResult
	{
		public int ExitCode { get; set; }

		public string StandardOutput { get; set; }

		public string StandardError { get; set; }
	}
	public class CircularReferenceTracking
	{
		private class Tracker : IDisposable
		{
			private bool disposed;

			public object Target { get; private set; }

			private CircularReferenceTracking State { get; set; }

			public Tracker(CircularReferenceTracking state, object target)
			{
				State = state;
				Target = target;
			}

			public override string ToString()
			{
				return string.Format(CultureInfo.InvariantCulture, "Tracking {0}", Target);
			}

			protected virtual void Dispose(bool disposing)
			{
				if (!disposed)
				{
					if (disposing)
					{
						State.PopTracker(this);
					}
					disposed = true;
				}
			}

			public void Dispose()
			{
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
			}

			~Tracker()
			{
				Dispose(disposing: false);
			}
		}

		private object referenceTrackersLock = new object();

		private Stack<Tracker> referenceTrackers = new Stack<Tracker>();

		public IDisposable Track(object target)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			lock (referenceTrackersLock)
			{
				if (TrackerExists(target))
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Circular reference detected with object [{0}] of type {1}", target, target.GetType().FullName));
				}
				Tracker tracker = new Tracker(this, target);
				referenceTrackers.Push(tracker);
				return tracker;
			}
		}

		private void PopTracker(Tracker tracker)
		{
			lock (referenceTrackersLock)
			{
				if (referenceTrackers.Peek() != tracker)
				{
					throw new InvalidOperationException("Tracker being released is not the latest one. Make sure to release child trackers before releasing parent.");
				}
				referenceTrackers.Pop();
			}
		}

		private bool TrackerExists(object target)
		{
			foreach (Tracker referenceTracker in referenceTrackers)
			{
				if (referenceTracker.Target == target)
				{
					return true;
				}
			}
			return false;
		}
	}
	public class AWSHttpClient : IDisposable
	{
		private HttpClient _httpClient;

		private bool disposed;

		public System.Uri BaseAddress
		{
			get
			{
				return _httpClient.BaseAddress;
			}
			set
			{
				_httpClient.BaseAddress = value;
			}
		}

		public TimeSpan Timeout
		{
			get
			{
				return _httpClient.Timeout;
			}
			set
			{
				_httpClient.Timeout = value;
			}
		}

		public long MaxResponseContentBufferSize
		{
			get
			{
				return _httpClient.MaxResponseContentBufferSize;
			}
			set
			{
				_httpClient.MaxResponseContentBufferSize = value;
			}
		}

		public AWSHttpClient()
		{
			_httpClient = new HttpClient();
		}

		internal AWSHttpClient(IWebProxy proxy, bool useProxy)
		{
			_httpClient = new HttpClient(new HttpClientHandler
			{
				Proxy = proxy,
				UseProxy = useProxy
			});
		}

		internal AWSHttpClient(HttpMessageHandler handler)
		{
			_httpClient = new HttpClient(handler);
		}

		internal AWSHttpClient(HttpMessageHandler handler, bool disposeHandler)
		{
			_httpClient = new HttpClient(handler, disposeHandler);
		}

		public Task<Stream> GetStreamAsync(string requestUri)
		{
			return _httpClient.GetStreamAsync(requestUri);
		}

		public Task PutRequestUriAsync(string requestUri, AWSStreamContent content, IDictionary<string, string> requestHeaders)
		{
			HttpRequestMessage httpRequestMessage = new HttpRequestMessage(HttpMethod.Put, requestUri);
			httpRequestMessage.Content = content.StreamContent;
			foreach (KeyValuePair<string, string> requestHeader in requestHeaders)
			{
				httpRequestMessage.Headers.TryAddWithoutValidation(requestHeader.Key, requestHeader.Value);
			}
			return _httpClient.SendAsync(httpRequestMessage);
		}

		public async Task<List<Tuple<string, IEnumerable<string>, HttpStatusCode>>> GetResponseHeadersAsync(string httpMethodValue, string url)
		{
			HttpMethod method = new HttpMethod(httpMethodValue);
			List<Tuple<string, IEnumerable<string>, HttpStatusCode>> headers = new List<Tuple<string, IEnumerable<string>, HttpStatusCode>>();
			HttpRequestMessage request = new HttpRequestMessage(method, url);
			HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(request).ConfigureAwait(continueOnCapturedContext: false);
			foreach (KeyValuePair<string, IEnumerable<string>> header in httpResponseMessage.Headers)
			{
				headers.Add(new Tuple<string, IEnumerable<string>, HttpStatusCode>(header.Key, header.Value, httpResponseMessage.StatusCode));
			}
			return headers;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					_httpClient.Dispose();
				}
				disposed = true;
			}
		}

		public static bool IsHttpInnerException(Exception exception)
		{
			return exception is HttpRequestException;
		}
	}
	public class AWSStreamContent : IDisposable
	{
		private bool disposed;

		internal StreamContent StreamContent { get; set; }

		public AWSStreamContent(Stream content)
		{
			StreamContent = new StreamContent(content);
		}

		public AWSStreamContent(Stream content, int bufferSize)
		{
			StreamContent = new StreamContent(content, bufferSize);
		}

		public bool RemoveHttpContentHeader(string name)
		{
			return StreamContent.Headers.Remove(name);
		}

		public void AddHttpContentHeader(string name, string value)
		{
			StreamContent.Headers.Add(name, value);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					StreamContent.Dispose();
				}
				disposed = true;
			}
		}
	}
}
namespace Amazon.Util.Internal
{
	public static class InternalSDKUtils
	{
		internal const string UnknownVersion = "Unknown";

		internal const string UnknownNetFrameworkVersion = ".NET_Runtime/Unknown .NET_Framework/Unknown";

		private static string _versionNumber;

		private static string _customSdkUserAgent;

		private static string _customData;

		internal const string CoreVersionNumber = "3.3.107.28";

		private static string _userAgentBaseName = "aws-sdk-dotnet-pcl";

		private const string UnknownMonoVersion = "Mono/Unknown";

		public static void SetUserAgent(string productName, string versionNumber)
		{
			SetUserAgent(productName, versionNumber, null);
		}

		public static void SetUserAgent(string productName, string versionNumber, string customData)
		{
			_userAgentBaseName = productName;
			_versionNumber = versionNumber;
			_customData = customData;
			BuildCustomUserAgentString();
		}

		private static void BuildCustomUserAgentString()
		{
			if (_versionNumber == null)
			{
				_versionNumber = "3.3.107.28";
			}
			IEnvironmentInfo service = ServiceFactory.Instance.GetService<IEnvironmentInfo>();
			string text = "";
			if (string.IsNullOrEmpty(text))
			{
				_customSdkUserAgent = string.Format(CultureInfo.InvariantCulture, "{0}/{1} {2} OS/{3} {4}", _userAgentBaseName, _versionNumber, service.FrameworkUserAgent, service.PlatformUserAgent, _customData).Trim();
			}
			else
			{
				_customSdkUserAgent = string.Format(CultureInfo.InvariantCulture, "{0}/{1} {2} OS/{3} {4} {5}", _userAgentBaseName, _versionNumber, service.FrameworkUserAgent, service.PlatformUserAgent, text, _customData).Trim();
			}
		}

		public static string BuildUserAgentString(string serviceSdkVersion)
		{
			if (!string.IsNullOrEmpty(_customSdkUserAgent))
			{
				return _customSdkUserAgent;
			}
			IEnvironmentInfo service = ServiceFactory.Instance.GetService<IEnvironmentInfo>();
			return string.Format(CultureInfo.InvariantCulture, "{0}/{1} aws-sdk-dotnet-core/{2} {3} OS/{4} {5} {6}", _userAgentBaseName, serviceSdkVersion, "3.3.107.28", service.FrameworkUserAgent, service.PlatformUserAgent, service.PclPlatform, _customData).Trim();
		}

		public static void ApplyValues(object target, IDictionary<string, object> propertyValues)
		{
			if (propertyValues == null || propertyValues.Count == 0)
			{
				return;
			}
			ITypeInfo typeInfo = TypeFactory.GetTypeInfo(target.GetType());
			foreach (KeyValuePair<string, object> propertyValue in propertyValues)
			{
				PropertyInfo property = typeInfo.GetProperty(propertyValue.Key);
				if (property == null)
				{
					throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Unable to find property {0} on type {1}.", propertyValue.Key, typeInfo.FullName));
				}
				try
				{
					if (TypeFactory.GetTypeInfo(property.PropertyType).IsEnum)
					{
						object value = Enum.Parse(property.PropertyType, propertyValue.Value.ToString(), ignoreCase: true);
						property.SetValue(target, value, null);
					}
					else
					{
						property.SetValue(target, propertyValue.Value, null);
					}
				}
				catch (Exception ex)
				{
					throw new ArgumentException(string.Format(CultureInfo.InvariantCulture, "Unable to set property {0} on type {1}: {2}", propertyValue.Key, typeInfo.FullName, ex.Message));
				}
			}
		}

		public static void AddToDictionary<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key, TValue value)
		{
			if (dictionary.ContainsKey(key))
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Dictionary already contains item with key {0}", key));
			}
			dictionary[key] = value;
		}

		public static void FillDictionary<T, TKey, TValue>(IEnumerable<T> items, Func<T, TKey> keyGenerator, Func<T, TValue> valueGenerator, Dictionary<TKey, TValue> targetDictionary)
		{
			foreach (T item in items)
			{
				TKey key = keyGenerator(item);
				TValue value = valueGenerator(item);
				AddToDictionary(targetDictionary, key, value);
			}
		}

		public static Dictionary<TKey, TValue> ToDictionary<T, TKey, TValue>(IEnumerable<T> items, Func<T, TKey> keyGenerator, Func<T, TValue> valueGenerator)
		{
			return ToDictionary(items, keyGenerator, valueGenerator, null);
		}

		public static Dictionary<TKey, TValue> ToDictionary<T, TKey, TValue>(IEnumerable<T> items, Func<T, TKey> keyGenerator, Func<T, TValue> valueGenerator, IEqualityComparer<TKey> comparer)
		{
			Dictionary<TKey, TValue> dictionary = ((comparer != null) ? new Dictionary<TKey, TValue>(comparer) : new Dictionary<TKey, TValue>());
			FillDictionary(items, keyGenerator, valueGenerator, dictionary);
			return dictionary;
		}

		public static bool TryFindByValue<TKey, TValue>(IDictionary<TKey, TValue> dictionary, TValue value, IEqualityComparer<TValue> valueComparer, out TKey key)
		{
			foreach (KeyValuePair<TKey, TValue> item in dictionary)
			{
				TValue value2 = item.Value;
				if (valueComparer.Equals(value, value2))
				{
					key = item.Key;
					return true;
				}
			}
			key = default(TKey);
			return false;
		}

		public static void SetIsSet<T>(bool isSet, ref T? field) where T : struct
		{
			if (isSet)
			{
				field = default(T);
			}
			else
			{
				field = null;
			}
		}

		public static void SetIsSet<T>(bool isSet, ref List<T> field)
		{
			if (isSet)
			{
				field = new AlwaysSendList<T>(field);
			}
			else
			{
				field = new List<T>();
			}
		}

		public static void SetIsSet<TKey, TValue>(bool isSet, ref Dictionary<TKey, TValue> field)
		{
			if (isSet)
			{
				field = new AlwaysSendDictionary<TKey, TValue>(field);
			}
			else
			{
				field = new Dictionary<TKey, TValue>();
			}
		}

		public static bool GetIsSet<T>(T? field) where T : struct
		{
			return field.HasValue;
		}

		public static bool GetIsSet<T>(List<T> field)
		{
			if (field == null)
			{
				return false;
			}
			if (field.Count > 0)
			{
				return true;
			}
			if (field is AlwaysSendList<T>)
			{
				return true;
			}
			return false;
		}

		public static bool GetIsSet<TKey, TVvalue>(Dictionary<TKey, TVvalue> field)
		{
			if (field == null)
			{
				return false;
			}
			if (field.Count > 0)
			{
				return true;
			}
			if (field is AlwaysSendDictionary<TKey, TVvalue>)
			{
				return true;
			}
			return false;
		}

		public static string GetMonoRuntimeVersion()
		{
			Type type = Type.GetType("Mono.Runtime");
			if (type != null)
			{
				MethodInfo method = type.GetMethod("GetDisplayName");
				if (method != null)
				{
					string text = (string)method.Invoke(null, null);
					text = text.Replace("/", ":").Replace(" ", string.Empty);
					return "Mono/" + text;
				}
			}
			return "Mono/Unknown";
		}
	}
	public class RootConfig
	{
		private const string _rootAwsSectionName = "aws";

		public CSMConfig CSMConfig { get; set; }

		public LoggingConfig Logging { get; private set; }

		public ProxyConfig Proxy { get; private set; }

		public string EndpointDefinition { get; set; }

		public string Region { get; set; }

		public string ProfileName { get; set; }

		public string ProfilesLocation { get; set; }

		public RegionEndpoint RegionEndpoint
		{
			get
			{
				if (string.IsNullOrEmpty(Region))
				{
					return null;
				}
				return RegionEndpoint.GetBySystemName(Region);
			}
			set
			{
				if (value == null)
				{
					Region = null;
				}
				else
				{
					Region = value.SystemName;
				}
			}
		}

		public bool UseSdkCache { get; set; }

		public bool CorrectForClockSkew { get; set; }

		public string ApplicationName { get; set; }

		public bool? CSMEnabled { get; set; }

		public string CSMClientId { get; set; }

		public int? CSMPort { get; set; }

		private IDictionary<string, XElement> ServiceSections { get; set; }

		public RootConfig()
		{
			CSMConfig = new CSMConfig();
			Logging = new LoggingConfig();
			Proxy = new ProxyConfig();
			EndpointDefinition = AWSConfigs._endpointDefinition;
			Region = AWSConfigs._awsRegion;
			ProfileName = AWSConfigs._awsProfileName;
			ProfilesLocation = AWSConfigs._awsAccountsLocation;
			UseSdkCache = AWSConfigs._useSdkCache;
			CorrectForClockSkew = true;
		}

		private static string Choose(string a, string b)
		{
			if (!string.IsNullOrEmpty(a))
			{
				return a;
			}
			return b;
		}

		public XElement GetServiceSection(string service)
		{
			if (ServiceSections.TryGetValue(service, out var value))
			{
				return value;
			}
			return null;
		}
	}
	public interface ITypeInfo
	{
		Type BaseType { get; }

		Type Type { get; }

		Assembly Assembly { get; }

		bool IsArray { get; }

		bool IsEnum { get; }

		bool IsClass { get; }

		bool IsValueType { get; }

		bool IsInterface { get; }

		bool IsAbstract { get; }

		bool IsSealed { get; }

		string FullName { get; }

		string Name { get; }

		bool IsGenericTypeDefinition { get; }

		bool IsGenericType { get; }

		bool ContainsGenericParameters { get; }

		Array ArrayCreateInstance(int length);

		Type GetInterface(string name);

		Type[] GetInterfaces();

		IEnumerable<PropertyInfo> GetProperties();

		IEnumerable<FieldInfo> GetFields();

		FieldInfo GetField(string name);

		MethodInfo GetMethod(string name);

		MethodInfo GetMethod(string name, ITypeInfo[] paramTypes);

		MemberInfo[] GetMembers();

		ConstructorInfo GetConstructor(ITypeInfo[] paramTypes);

		PropertyInfo GetProperty(string name);

		bool IsAssignableFrom(ITypeInfo typeInfo);

		object EnumToObject(object value);

		ITypeInfo EnumGetUnderlyingType();

		object CreateInstance();

		ITypeInfo GetElementType();

		bool IsType(Type type);

		Type GetGenericTypeDefinition();

		Type[] GetGenericArguments();

		object[] GetCustomAttributes(bool inherit);

		object[] GetCustomAttributes(ITypeInfo attributeType, bool inherit);
	}
	public static class TypeFactory
	{
		private abstract class AbstractTypeInfo : ITypeInfo
		{
			protected Type _type;

			public Type Type => _type;

			public abstract Type BaseType { get; }

			public abstract Assembly Assembly { get; }

			public abstract bool IsClass { get; }

			public abstract bool IsInterface { get; }

			public abstract bool IsAbstract { get; }

			public abstract bool IsSealed { get; }

			public abstract bool IsEnum { get; }

			public abstract bool IsValueType { get; }

			public abstract bool ContainsGenericParameters { get; }

			public abstract bool IsGenericTypeDefinition { get; }

			public abstract bool IsGenericType { get; }

			public bool IsArray => _type.IsArray;

			public string FullName => _type.FullName;

			public string Name => _type.Name;

			internal AbstractTypeInfo(Type type)
			{
				_type = type;
			}

			public override int GetHashCode()
			{
				return _type.GetHashCode();
			}

			public override bool Equals(object obj)
			{
				if (!(obj is AbstractTypeInfo abstractTypeInfo))
				{
					return false;
				}
				return _type.Equals(abstractTypeInfo._type);
			}

			public bool IsType(Type type)
			{
				return _type == type;
			}

			public abstract Type GetInterface(string name);

			public abstract Type[] GetInterfaces();

			public abstract IEnumerable<PropertyInfo> GetProperties();

			public abstract IEnumerable<FieldInfo> GetFields();

			public abstract FieldInfo GetField(string name);

			public abstract MethodInfo GetMethod(string name);

			public abstract MethodInfo GetMethod(string name, ITypeInfo[] paramTypes);

			public abstract MemberInfo[] GetMembers();

			public abstract PropertyInfo GetProperty(string name);

			public abstract bool IsAssignableFrom(ITypeInfo typeInfo);

			public abstract ConstructorInfo GetConstructor(ITypeInfo[] paramTypes);

			public abstract object[] GetCustomAttributes(bool inherit);

			public abstract object[] GetCustomAttributes(ITypeInfo attributeType, bool inherit);

			public abstract Type GetGenericTypeDefinition();

			public abstract Type[] GetGenericArguments();

			public object EnumToObject(object value)
			{
				return Enum.ToObject(_type, value);
			}

			public ITypeInfo EnumGetUnderlyingType()
			{
				return GetTypeInfo(Enum.GetUnderlyingType(_type));
			}

			public object CreateInstance()
			{
				return Activator.CreateInstance(_type);
			}

			public Array ArrayCreateInstance(int length)
			{
				return Array.CreateInstance(_type, length);
			}

			public ITypeInfo GetElementType()
			{
				return GetTypeInfo(_type.GetElementType());
			}
		}

		private class TypeInfoWrapper : AbstractTypeInfo
		{
			private TypeInfo _typeInfo;

			private static readonly Type objectType = typeof(object);

			public override Type BaseType => _typeInfo.BaseType;

			public override bool IsClass => _typeInfo.IsClass;

			public override bool IsValueType => _typeInfo.IsValueType;

			public override bool IsInterface => _typeInfo.IsInterface;

			public override bool IsAbstract => _typeInfo.IsAbstract;

			public override bool IsSealed => _typeInfo.IsSealed;

			public override bool IsEnum => _typeInfo.IsEnum;

			public override bool ContainsGenericParameters => _typeInfo.ContainsGenericParameters;

			public override bool IsGenericTypeDefinition => _typeInfo.IsGenericTypeDefinition;

			public override bool IsGenericType => _typeInfo.IsGenericType;

			public override Assembly Assembly => _typeInfo.Assembly;

			internal TypeInfoWrapper(Type type)
				: base(type)
			{
				_typeInfo = type.GetTypeInfo();
			}

			public override Type GetInterface(string name)
			{
				return _typeInfo.ImplementedInterfaces.FirstOrDefault((Type x) => x.Namespace + "." + x.Name == name);
			}

			public override Type[] GetInterfaces()
			{
				return _typeInfo.ImplementedInterfaces.ToArray();
			}

			public override IEnumerable<PropertyInfo> GetProperties()
			{
				return _type.GetRuntimeProperties();
			}

			public override IEnumerable<FieldInfo> GetFields()
			{
				return _type.GetRuntimeFields();
			}

			public override FieldInfo GetField(string name)
			{
				return _type.GetRuntimeField(name);
			}

			public override MemberInfo[] GetMembers()
			{
				return GetMembers_Helper(_typeInfo).Distinct().ToArray();
			}

			private static bool IsBackingField(MemberInfo mi)
			{
				return mi.Name.IndexOf("k__BackingField", StringComparison.Ordinal) >= 0;
			}

			private static IEnumerable<MemberInfo> GetMembers_Helper(TypeInfo ti)
			{
				IEnumerable<MemberInfo> declaredMembers = ti.DeclaredMembers;
				foreach (MemberInfo item in declaredMembers)
				{
					if (!IsBackingField(item))
					{
						yield return item;
					}
				}
				Type baseType = ti.BaseType;
				bool flag = baseType == objectType;
				if (!(baseType != null) || flag)
				{
					yield break;
				}
				List<MemberInfo> list = GetMembers_Helper(baseType.GetTypeInfo()).ToList();
				foreach (MemberInfo item2 in list)
				{
					yield return item2;
				}
			}

			public override MethodInfo GetMethod(string name)
			{
				return _type.GetRuntimeMethods().FirstOrDefault((MethodInfo x) => x.Name == name);
			}

			public override Type GetGenericTypeDefinition()
			{
				return _typeInfo.GetGenericTypeDefinition();
			}

			public override Type[] GetGenericArguments()
			{
				return _typeInfo.GenericTypeArguments;
			}

			public override MethodInfo GetMethod(string name, ITypeInfo[] paramTypes)
			{
				Type[] array = new Type[paramTypes.Length];
				for (int i = 0; i < paramTypes.Length; i = checked(i + 1))
				{
					array[i] = ((AbstractTypeInfo)paramTypes[i]).Type;
				}
				return _type.GetRuntimeMethod(name, array);
			}

			public override PropertyInfo GetProperty(string name)
			{
				return _type.GetRuntimeProperty(name);
			}

			public override bool IsAssignableFrom(ITypeInfo typeInfo)
			{
				return _typeInfo.IsAssignableFrom(((TypeInfoWrapper)typeInfo)._typeInfo);
			}

			public override object[] GetCustomAttributes(bool inherit)
			{
				return _typeInfo.GetCustomAttributes(inherit).ToArray();
			}

			public override object[] GetCustomAttributes(ITypeInfo attributeType, bool inherit)
			{
				return _typeInfo.GetCustomAttributes(((TypeInfoWrapper)attributeType)._type, inherit).ToArray();
			}

			public override ConstructorInfo GetConstructor(ITypeInfo[] paramTypes)
			{
				foreach (ConstructorInfo declaredConstructor in _typeInfo.DeclaredConstructors)
				{
					ParameterInfo[] parameters = declaredConstructor.GetParameters();
					if (parameters.Length != paramTypes.Length)
					{
						continue;
					}
					bool flag = true;
					for (int i = 0; i < parameters.Length; i = checked(i + 1))
					{
						if (parameters[i].ParameterType.FullName != paramTypes[i].FullName)
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						return declaredConstructor;
					}
				}
				return null;
			}
		}

		public static readonly ITypeInfo[] EmptyTypes = new ITypeInfo[0];

		public static ITypeInfo GetTypeInfo(Type type)
		{
			if (type == null)
			{
				return null;
			}
			return new TypeInfoWrapper(type);
		}
	}
}
namespace Amazon.Util.Internal.PlatformServices
{
	public interface IApplicationInfo
	{
		string AppTitle { get; }

		string AppVersionName { get; }

		string AppVersionCode { get; }

		string PackageName { get; }
	}
	public enum ApplicationSettingsMode
	{
		None,
		Local,
		Roaming
	}
	public interface IApplicationSettings
	{
		void SetValue(string key, string value, ApplicationSettingsMode mode);

		string GetValue(string key, ApplicationSettingsMode mode);

		void RemoveValue(string key, ApplicationSettingsMode mode);
	}
	public interface IEnvironmentInfo
	{
		string Platform { get; }

		string PlatformVersion { get; }

		string PclPlatform { get; }

		string PlatformUserAgent { get; }

		string FrameworkUserAgent { get; }

		string Model { get; }

		string Make { get; }

		string Locale { get; }
	}
	public enum NetworkStatus
	{
		NotReachable,
		ReachableViaCarrierDataNetwork,
		ReachableViaWiFiNetwork
	}
	public class NetworkStatusEventArgs : EventArgs
	{
		public NetworkStatus Status { get; private set; }

		public NetworkStatusEventArgs(NetworkStatus status)
		{
			Status = status;
		}
	}
	public interface INetworkReachability
	{
		NetworkStatus NetworkStatus { get; }

		event EventHandler<NetworkStatusEventArgs> NetworkReachabilityChanged;
	}
	public class ServiceFactory
	{
		private enum InstantiationModel
		{
			Singleton,
			InstancePerCall
		}

		internal const string NotImplementedErrorMessage = "This functionality is not implemented in the portable version of this assembly. You should reference the AWSSDK.Core NuGet package from your main application project in order to reference the platform-specific implementation.";

		private static readonly object _lock = new object();

		private static bool _factoryInitialized = false;

		private static IDictionary<Type, Type> _mappings = new Dictionary<Type, Type>
		{
			{
				typeof(IApplicationSettings),
				typeof(ApplicationSettings)
			},
			{
				typeof(INetworkReachability),
				typeof(NetworkReachability)
			},
			{
				typeof(IApplicationInfo),
				typeof(ApplicationInfo)
			},
			{
				typeof(IEnvironmentInfo),
				typeof(EnvironmentInfo)
			}
		};

		private IDictionary<Type, InstantiationModel> _instantationMappings = new Dictionary<Type, InstantiationModel>
		{
			{
				typeof(IApplicationSettings),
				InstantiationModel.InstancePerCall
			},
			{
				typeof(INetworkReachability),
				InstantiationModel.Singleton
			},
			{
				typeof(IApplicationInfo),
				InstantiationModel.Singleton
			},
			{
				typeof(IEnvironmentInfo),
				InstantiationModel.Singleton
			}
		};

		private IDictionary<Type, object> _singletonServices = new Dictionary<Type, object>();

		public static ServiceFactory Instance = new ServiceFactory();

		private ServiceFactory()
		{
			foreach (KeyValuePair<Type, InstantiationModel> instantationMapping in _instantationMappings)
			{
				Type key = instantationMapping.Key;
				if (instantationMapping.Value == InstantiationModel.Singleton)
				{
					object value = Activator.CreateInstance(_mappings[key]);
					_singletonServices.Add(key, value);
				}
			}
			_factoryInitialized = true;
		}

		public static void RegisterService<T>(Type serviceType)
		{
			if (_factoryInitialized)
			{
				throw new InvalidOperationException("New services can only be registered before ServiceFactory is accessed by calling ServiceFactory.Instance .");
			}
			lock (_lock)
			{
				_mappings[typeof(T)] = serviceType;
			}
		}

		public T GetService<T>()
		{
			Type typeFromHandle = typeof(T);
			if (_instantationMappings[typeFromHandle] == InstantiationModel.Singleton)
			{
				return (T)_singletonServices[typeFromHandle];
			}
			return (T)Activator.CreateInstance(GetServiceType<T>());
		}

		private static Type GetServiceType<T>()
		{
			lock (_lock)
			{
				return _mappings[typeof(T)];
			}
		}
	}
	public class ApplicationInfo : IApplicationInfo
	{
		public string AppTitle => Application.Context.ApplicationInfo.LoadLabel(Application.Context.PackageManager).ToString();

		public string AppVersionName => Application.Context.PackageManager.GetPackageInfo(Application.Context.PackageName, (PackageInfoFlags)0).VersionName;

		public string AppVersionCode => Application.Context.PackageManager.GetPackageInfo(Application.Context.PackageName, (PackageInfoFlags)0).VersionCode.ToString();

		public string PackageName => Application.Context.PackageName;

		public string SpecialFolder => System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
	}
	public class ApplicationSettings : IApplicationSettings
	{
		private const string SETTINGS_STORE_NAME = "AWSSDK_SETTINGS";

		public void SetValue(string key, string value, ApplicationSettingsMode mode)
		{
			ISharedPreferencesEditor sharedPreferencesEditor = Application.Context.GetSharedPreferences("AWSSDK_SETTINGS", FileCreationMode.Private).Edit();
			sharedPreferencesEditor.PutString(key, value);
			sharedPreferencesEditor.Commit();
		}

		public string GetValue(string key, ApplicationSettingsMode mode)
		{
			return Application.Context.GetSharedPreferences("AWSSDK_SETTINGS", FileCreationMode.Private).GetString(key, string.Empty);
		}

		public void RemoveValue(string key, ApplicationSettingsMode mode)
		{
			ISharedPreferencesEditor sharedPreferencesEditor = Application.Context.GetSharedPreferences("AWSSDK_SETTINGS", FileCreationMode.Private).Edit();
			sharedPreferencesEditor.Remove(key);
			sharedPreferencesEditor.Commit();
		}
	}
	public class EnvironmentInfo : IEnvironmentInfo
	{
		public string Platform { get; private set; }

		public string PlatformUserAgent { get; private set; }

		public string Model { get; private set; }

		public string Make { get; private set; }

		public string PlatformVersion { get; private set; }

		public string Locale { get; private set; }

		public string FrameworkUserAgent { get; private set; }

		public string PclPlatform { get; private set; }

		public EnvironmentInfo()
		{
			Platform = "ANDROID";
			Model = Build.Model;
			Make = Build.Manufacturer;
			PlatformVersion = Build.VERSION.Release;
			Locale = Application.Context.Resources.Configuration.Locale.ToString();
			FrameworkUserAgent = InternalSDKUtils.GetMonoRuntimeVersion();
			PclPlatform = "PCL/Xamarin.Android";
			PlatformUserAgent = string.Format(CultureInfo.InstalledUICulture, "{0}_{1}", Platform, PlatformVersion);
		}
	}
	public class NetworkReachability : INetworkReachability, IDisposable
	{
		[BroadcastReceiver]
		public class NetworkStatusChangeBroadcastReceiver : BroadcastReceiver
		{
			public event EventHandler<NetworkStatus> ConnectionStatusChanged;

			public override void OnReceive(Context context, Intent intent)
			{
				NetworkInfo activeNetworkInfo = ((ConnectivityManager)context.GetSystemService("connectivity")).ActiveNetworkInfo;
				NetworkStatus e = NetworkStatus.NotReachable;
				if (activeNetworkInfo != null && activeNetworkInfo.IsConnected)
				{
					e = ((activeNetworkInfo.Type != ConnectivityType.Wifi) ? NetworkStatus.ReachableViaCarrierDataNetwork : NetworkStatus.ReachableViaWiFiNetwork);
				}
				if (this.ConnectionStatusChanged != null)
				{
					this.ConnectionStatusChanged(this, e);
				}
			}
		}

		private NetworkStatusChangeBroadcastReceiver _networkBroadcastReceiver;

		private NetworkStatus _networkStatus;

		public NetworkStatus NetworkStatus => _networkStatus;

		public event EventHandler<NetworkStatusEventArgs> NetworkReachabilityChanged;

		public NetworkReachability()
		{
			if (_networkBroadcastReceiver == null)
			{
				Context context = Application.Context;
				_networkBroadcastReceiver = new NetworkStatusChangeBroadcastReceiver();
				_networkBroadcastReceiver.ConnectionStatusChanged += NetworkStatusChanged;
				Application.Context.RegisterReceiver(_networkBroadcastReceiver, new IntentFilter("android.net.conn.CONNECTIVITY_CHANGE"));
				NetworkInfo activeNetworkInfo = ((ConnectivityManager)context.GetSystemService("connectivity")).ActiveNetworkInfo;
				NetworkStatus networkStatus = NetworkStatus.NotReachable;
				if (activeNetworkInfo != null && activeNetworkInfo.IsConnected)
				{
					networkStatus = ((activeNetworkInfo.Type != ConnectivityType.Wifi) ? NetworkStatus.ReachableViaCarrierDataNetwork : NetworkStatus.ReachableViaWiFiNetwork);
				}
				_networkStatus = networkStatus;
			}
		}

		private void NetworkStatusChanged(object sender, NetworkStatus e)
		{
			_networkStatus = e;
			if (this.NetworkReachabilityChanged != null)
			{
				this.NetworkReachabilityChanged(this, new NetworkStatusEventArgs(e));
			}
		}

		public void Dispose()
		{
			throw new NotImplementedException();
		}
	}
}
namespace Amazon.Runtime
{
	public class AmazonClientException : Exception
	{
		public AmazonClientException(string message)
			: base(message)
		{
		}

		public AmazonClientException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
	public class AmazonDateTimeUnmarshallingException : AmazonUnmarshallingException
	{
		public string InvalidDateTimeToken { get; private set; }

		public AmazonDateTimeUnmarshallingException(string requestId, string lastKnownLocation, string invalidDateTimeToken, Exception innerException)
			: base(requestId, lastKnownLocation, innerException)
		{
			InvalidDateTimeToken = invalidDateTimeToken;
		}

		public AmazonDateTimeUnmarshallingException(string requestId, string lastKnownLocation, string responseBody, string invalidDateTimeToken, Exception innerException)
			: base(requestId, lastKnownLocation, responseBody, innerException)
		{
			InvalidDateTimeToken = invalidDateTimeToken;
		}

		public AmazonDateTimeUnmarshallingException(string requestId, string lastKnownLocation, string responseBody, string invalidDateTimeToken, string message, Exception innerException)
			: base(requestId, lastKnownLocation, responseBody, message, innerException)
		{
			InvalidDateTimeToken = invalidDateTimeToken;
		}
	}
	public abstract class AmazonServiceClient : IDisposable
	{
		private bool _disposed;

		private Logger _logger;

		private PreRequestEventHandler mBeforeMarshallingEvent;

		private RequestEventHandler mBeforeRequestEvent;

		private ResponseEventHandler mAfterResponseEvent;

		private ExceptionEventHandler mExceptionEvent;

		protected EndpointDiscoveryResolverBase EndpointDiscoveryResolver { get; private set; }

		protected RuntimePipeline RuntimePipeline { get; set; }

		protected internal AWSCredentials Credentials { get; private set; }

		public IClientConfig Config { get; private set; }

		protected virtual IServiceMetadata ServiceMetadata { get; } = new ServiceMetadata();

		protected virtual bool SupportResponseLogging => true;

		protected AbstractAWSSigner Signer { get; private set; }

		internal event PreRequestEventHandler BeforeMarshallingEvent
		{
			add
			{
				lock (this)
				{
					mBeforeMarshallingEvent = (PreRequestEventHandler)Delegate.Combine(mBeforeMarshallingEvent, value);
				}
			}
			remove
			{
				lock (this)
				{
					mBeforeMarshallingEvent = (PreRequestEventHandler)Delegate.Remove(mBeforeMarshallingEvent, value);
				}
			}
		}

		public event RequestEventHandler BeforeRequestEvent
		{
			add
			{
				lock (this)
				{
					mBeforeRequestEvent = (RequestEventHandler)Delegate.Combine(mBeforeRequestEvent, value);
				}
			}
			remove
			{
				lock (this)
				{
					mBeforeRequestEvent = (RequestEventHandler)Delegate.Remove(mBeforeRequestEvent, value);
				}
			}
		}

		public event ResponseEventHandler AfterResponseEvent
		{
			add
			{
				lock (this)
				{
					mAfterResponseEvent = (ResponseEventHandler)Delegate.Combine(mAfterResponseEvent, value);
				}
			}
			remove
			{
				lock (this)
				{
					mAfterResponseEvent = (ResponseEventHandler)Delegate.Remove(mAfterResponseEvent, value);
				}
			}
		}

		public event ExceptionEventHandler ExceptionEvent
		{
			add
			{
				lock (this)
				{
					mExceptionEvent = (ExceptionEventHandler)Delegate.Combine(mExceptionEvent, value);
				}
			}
			remove
			{
				lock (this)
				{
					mExceptionEvent = (ExceptionEventHandler)Delegate.Remove(mExceptionEvent, value);
				}
			}
		}

		protected AmazonServiceClient(AWSCredentials credentials, ClientConfig config)
		{
			if (config.DisableLogging)
			{
				_logger = Logger.EmptyLogger;
			}
			else
			{
				_logger = Logger.GetLogger(GetType());
			}
			config.Validate();
			Config = config;
			Credentials = credentials;
			Signer = CreateSigner();
			EndpointDiscoveryResolver = new EndpointDiscoveryResolver(config, _logger);
			Initialize();
			BuildRuntimePipeline();
		}

		protected AmazonServiceClient(string awsAccessKeyId, string awsSecretAccessKey, string awsSessionToken, ClientConfig config)
			: this(new SessionAWSCredentials(awsAccessKeyId, awsSecretAccessKey, awsSessionToken), config)
		{
		}

		protected AmazonServiceClient(string awsAccessKeyId, string awsSecretAccessKey, ClientConfig config)
			: this(new BasicAWSCredentials(awsAccessKeyId, awsSecretAccessKey), config)
		{
		}

		protected virtual void Initialize()
		{
		}

		[Obsolete("Invoke taking marshallers is obsolete. Use Invoke taking InvokeOptionsBase instead.")]
		protected TResponse Invoke<TRequest, TResponse>(TRequest request, IMarshaller<IRequest, AmazonWebServiceRequest> marshaller, ResponseUnmarshaller unmarshaller) where TRequest : AmazonWebServiceRequest where TResponse : AmazonWebServiceResponse
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = marshaller;
			invokeOptions.ResponseUnmarshaller = unmarshaller;
			return Invoke<TResponse>(request, invokeOptions);
		}

		protected TResponse Invoke<TResponse>(AmazonWebServiceRequest request, InvokeOptionsBase options) where TResponse : AmazonWebServiceResponse
		{
			ThrowIfDisposed();
			Amazon.Runtime.Internal.ExecutionContext executionContext = new Amazon.Runtime.Internal.ExecutionContext(new RequestContext(Config.LogMetrics, Signer)
			{
				ClientConfig = Config,
				Marshaller = options.RequestMarshaller,
				OriginalRequest = request,
				Unmarshaller = options.ResponseUnmarshaller,
				IsAsync = false,
				ServiceMetaData = ServiceMetadata,
				Options = options
			}, new ResponseContext());
			SetupCSMHandler(executionContext.RequestContext);
			return (TResponse)RuntimePipeline.InvokeSync(executionContext).Response;
		}

		[Obsolete("InvokeAsync taking marshallers is obsolete. Use InvokeAsync taking InvokeOptionsBase instead.")]
		protected Task<TResponse> InvokeAsync<TRequest, TResponse>(TRequest request, IMarshaller<IRequest, AmazonWebServiceRequest> marshaller, ResponseUnmarshaller unmarshaller, CancellationToken cancellationToken) where TRequest : AmazonWebServiceRequest where TResponse : AmazonWebServiceResponse, new()
		{
			InvokeOptions invokeOptions = new InvokeOptions();
			invokeOptions.RequestMarshaller = marshaller;
			invokeOptions.ResponseUnmarshaller = unmarshaller;
			return InvokeAsync<TResponse>(request, invokeOptions, cancellationToken);
		}

		protected Task<TResponse> InvokeAsync<TResponse>(AmazonWebServiceRequest request, InvokeOptionsBase options, CancellationToken cancellationToken) where TResponse : AmazonWebServiceResponse, new()
		{
			ThrowIfDisposed();
			Amazon.Runtime.Internal.ExecutionContext executionContext = new Amazon.Runtime.Internal.ExecutionContext(new RequestContext(Config.LogMetrics, Signer)
			{
				ClientConfig = Config,
				Marshaller = options.RequestMarshaller,
				OriginalRequest = request,
				Unmarshaller = options.ResponseUnmarshaller,
				IsAsync = true,
				CancellationToken = cancellationToken,
				ServiceMetaData = ServiceMetadata,
				Options = options
			}, new ResponseContext());
			SetupCSMHandler(executionContext.RequestContext);
			return RuntimePipeline.InvokeAsync<TResponse>(executionContext);
		}

		protected virtual IEnumerable<DiscoveryEndpointBase> EndpointOperation(EndpointOperationContextBase context)
		{
			return null;
		}

		protected void ProcessPreRequestHandlers(IExecutionContext executionContext)
		{
			if (mBeforeMarshallingEvent != null)
			{
				PreRequestEventArgs e = PreRequestEventArgs.Create(executionContext.RequestContext.OriginalRequest);
				mBeforeMarshallingEvent(this, e);
			}
		}

		protected void ProcessRequestHandlers(IExecutionContext executionContext)
		{
			IRequest request = executionContext.RequestContext.Request;
			WebServiceRequestEventArgs e = WebServiceRequestEventArgs.Create(request);
			if (request.OriginalRequest != null)
			{
				request.OriginalRequest.FireBeforeRequestEvent(this, e);
			}
			if (mBeforeRequestEvent != null)
			{
				mBeforeRequestEvent(this, e);
			}
		}

		protected void ProcessResponseHandlers(IExecutionContext executionContext)
		{
			if (mAfterResponseEvent != null)
			{
				WebServiceResponseEventArgs e = WebServiceResponseEventArgs.Create(executionContext.ResponseContext.Response, executionContext.RequestContext.Request, executionContext.ResponseContext.HttpResponse);
				mAfterResponseEvent(this, e);
			}
		}

		protected virtual void ProcessExceptionHandlers(IExecutionContext executionContext, Exception exception)
		{
			if (mExceptionEvent != null)
			{
				WebServiceExceptionEventArgs e = WebServiceExceptionEventArgs.Create(exception, executionContext.RequestContext.Request);
				mExceptionEvent(this, e);
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed && disposing)
			{
				if (RuntimePipeline != null)
				{
					RuntimePipeline.Dispose();
				}
				_disposed = true;
			}
		}

		private void ThrowIfDisposed()
		{
			if (_disposed)
			{
				throw new ObjectDisposedException(GetType().FullName);
			}
		}

		protected abstract AbstractAWSSigner CreateSigner();

		protected virtual void CustomizeRuntimePipeline(RuntimePipeline pipeline)
		{
		}

		private void BuildRuntimePipeline()
		{
			HttpHandler<HttpContent> item = new HttpHandler<HttpContent>(new HttpRequestMessageFactory(Config), this);
			CallbackHandler callbackHandler = new CallbackHandler();
			callbackHandler.OnPreInvoke = ProcessPreRequestHandlers;
			CallbackHandler callbackHandler2 = new CallbackHandler();
			callbackHandler2.OnPreInvoke = ProcessRequestHandlers;
			CallbackHandler callbackHandler3 = new CallbackHandler();
			callbackHandler3.OnPostInvoke = ProcessResponseHandlers;
			ErrorCallbackHandler errorCallbackHandler = new ErrorCallbackHandler();
			errorCallbackHandler.OnError = ProcessExceptionHandlers;
			RetryPolicy retryPolicy = Config.RetryMode switch
			{
				RequestRetryMode.Adaptive => new AdaptiveRetryPolicy(Config), 
				RequestRetryMode.Standard => new StandardRetryPolicy(Config), 
				RequestRetryMode.Legacy => new DefaultRetryPolicy(Config), 
				_ => throw new InvalidOperationException("Unknown retry mode"), 
			};
			RuntimePipeline = new RuntimePipeline(new List<IPipelineHandler>
			{
				item,
				new Unmarshaller(SupportResponseLogging),
				new ErrorHandler(_logger),
				callbackHandler3,
				new Signer(),
				new EndpointDiscoveryHandler(),
				new CredentialsRetriever(Credentials),
				new RetryHandler(retryPolicy),
				callbackHandler2,
				new EndpointResolver(),
				new Marshaller(),
				callbackHandler,
				errorCallbackHandler,
				new MetricsHandler()
			}, _logger);
			CustomizeRuntimePipeline(RuntimePipeline);
			RuntimePipelineCustomizerRegistry.Instance.ApplyCustomizations(GetType(), RuntimePipeline);
		}

		public static System.Uri ComposeUrl(IRequest iRequest)
		{
			System.Uri endpoint = iRequest.Endpoint;
			string text = iRequest.ResourcePath;
			if (text == null)
			{
				text = string.Empty;
			}
			else
			{
				if (text.StartsWith("/", StringComparison.Ordinal))
				{
					text = text.Substring(1);
				}
				if (iRequest.MarshallerVersion >= 2)
				{
					if (AWSSDKUtils.HasBidiControlCharacters(text) || iRequest.PathResources.Any((KeyValuePair<string, string> v) => AWSSDKUtils.HasBidiControlCharacters(v.Value)))
					{
						text = string.Join("/", AWSSDKUtils.SplitResourcePathIntoSegments(text, iRequest.PathResources).ToArray());
						throw new AmazonClientException(string.Format(CultureInfo.InvariantCulture, "Target resource path [{0}] has bidirectional characters, which are not supportedby System.Uri and thus cannot be handled by the .NET SDK.", text));
					}
					text = AWSSDKUtils.ResolveResourcePath(text, iRequest.PathResources);
				}
			}
			string arg = "?";
			StringBuilder stringBuilder = new StringBuilder();
			if (iRequest.SubResources.Count > 0)
			{
				foreach (KeyValuePair<string, string> subResource in iRequest.SubResources)
				{
					stringBuilder.AppendFormat("{0}{1}", arg, subResource.Key);
					if (subResource.Value != null)
					{
						stringBuilder.AppendFormat("={0}", subResource.Value);
					}
					arg = "&";
				}
			}
			if (iRequest.UseQueryString && iRequest.Parameters.Count > 0)
			{
				string parametersAsString = AWSSDKUtils.GetParametersAsString(iRequest);
				stringBuilder.AppendFormat("{0}{1}", arg, parametersAsString);
			}
			string empty = string.Empty;
			if (iRequest.MarshallerVersion >= 2)
			{
				empty = text + stringBuilder;
			}
			else
			{
				if (AWSSDKUtils.HasBidiControlCharacters(text))
				{
					throw new AmazonClientException(string.Format(CultureInfo.InvariantCulture, "Target resource path [{0}] has bidirectional characters, which are not supportedby System.Uri and thus cannot be handled by the .NET SDK.", text));
				}
				empty = AWSSDKUtils.ProtectEncodedSlashUrlEncode(text, path: true) + stringBuilder;
			}
			System.Uri obj = ((endpoint.AbsoluteUri.EndsWith("/", StringComparison.Ordinal) || empty.StartsWith("/", StringComparison.Ordinal)) ? new System.Uri(endpoint.AbsoluteUri + empty) : new System.Uri(endpoint.AbsoluteUri + "/" + empty));
			DontUnescapePathDotsAndSlashes(obj);
			return obj;
		}

		private static void DontUnescapePathDotsAndSlashes(System.Uri uri)
		{
		}

		internal C CloneConfig<C>() where C : ClientConfig, new()
		{
			C val = new C();
			CloneConfig(val);
			return val;
		}

		internal void CloneConfig(ClientConfig newConfig)
		{
			if (!string.IsNullOrEmpty(Config.ServiceURL))
			{
				RegionEndpoint bySystemName = RegionEndpoint.GetBySystemName(AWSSDKUtils.DetermineRegion(Config.ServiceURL));
				newConfig.RegionEndpoint = bySystemName;
			}
			else
			{
				newConfig.RegionEndpoint = Config.RegionEndpoint;
			}
			newConfig.UseHttp = Config.UseHttp;
			newConfig.ProxyCredentials = Config.ProxyCredentials;
		}

		private static void SetupCSMHandler(IRequestContext requestContext)
		{
		}
	}
	public class AmazonServiceException : Exception
	{
		private ErrorType errorType;

		private string errorCode;

		private string requestId;

		private HttpStatusCode statusCode;

		public ErrorType ErrorType
		{
			get
			{
				return errorType;
			}
			set
			{
				errorType = value;
			}
		}

		public string ErrorCode
		{
			get
			{
				return errorCode;
			}
			set
			{
				errorCode = value;
			}
		}

		public string RequestId
		{
			get
			{
				return requestId;
			}
			set
			{
				requestId = value;
			}
		}

		public HttpStatusCode StatusCode
		{
			get
			{
				return statusCode;
			}
			set
			{
				statusCode = value;
			}
		}

		public virtual RetryableDetails Retryable => null;

		public AmazonServiceException()
		{
		}

		public AmazonServiceException(string message)
			: base(message)
		{
		}

		public AmazonServiceException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		public AmazonServiceException(string message, Exception innerException, HttpStatusCode statusCode)
			: base(message, innerException)
		{
			this.statusCode = statusCode;
		}

		public AmazonServiceException(Exception innerException)
			: base(innerException.Message, innerException)
		{
		}

		public AmazonServiceException(string message, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
			: base(message ?? BuildGenericErrorMessage(errorCode, statusCode))
		{
			this.errorCode = errorCode;
			this.errorType = errorType;
			this.requestId = requestId;
			this.statusCode = statusCode;
		}

		public AmazonServiceException(string message, Exception innerException, ErrorType errorType, string errorCode, string requestId, HttpStatusCode statusCode)
			: base(message ?? BuildGenericErrorMessage(errorCode, statusCode), innerException)
		{
			this.errorCode = errorCode;
			this.errorType = errorType;
			this.requestId = requestId;
			this.statusCode = statusCode;
		}

		private static string BuildGenericErrorMessage(string errorCode, HttpStatusCode statusCode)
		{
			return string.Format(CultureInfo.InvariantCulture, "Error making request with Error Code {0} and Http Status Code {1}. No further error information was returned by the service.", errorCode, statusCode);
		}
	}
	public class RetryableDetails
	{
		public bool Throttling { get; private set; }

		public RetryableDetails(bool throttling)
		{
			Throttling = throttling;
		}
	}
	public class AmazonUnmarshallingException : AmazonServiceException
	{
		public string LastKnownLocation { get; private set; }

		public string ResponseBody { get; private set; }

		public override string Message
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				AppendFormat(stringBuilder, "Request ID: {0}", base.RequestId);
				AppendFormat(stringBuilder, "Response Body: {0}", ResponseBody);
				AppendFormat(stringBuilder, "Last Parsed Path: {0}", LastKnownLocation);
				AppendFormat(stringBuilder, "HTTP Status Code: {0}", (int)base.StatusCode + " " + base.StatusCode.ToString());
				string text = stringBuilder.ToString();
				return base.Message + " " + text;
			}
		}

		public AmazonUnmarshallingException(string requestId, string lastKnownLocation, Exception innerException)
			: base("Error unmarshalling response back from AWS.", innerException)
		{
			base.RequestId = requestId;
			LastKnownLocation = lastKnownLocation;
		}

		public AmazonUnmarshallingException(string requestId, string lastKnownLocation, string responseBody, Exception innerException)
			: base("Error unmarshalling response back from AWS.", innerException)
		{
			base.RequestId = requestId;
			LastKnownLocation = lastKnownLocation;
			ResponseBody = responseBody;
		}

		public AmazonUnmarshallingException(string requestId, string lastKnownLocation, string responseBody, string message, Exception innerException)
			: base("Error unmarshalling response back from AWS. " + message, innerException)
		{
			base.RequestId = requestId;
			LastKnownLocation = lastKnownLocation;
			ResponseBody = responseBody;
		}

		public AmazonUnmarshallingException(string requestId, string lastKnownLocation, Exception innerException, HttpStatusCode statusCode)
			: base("Error unmarshalling response back from AWS.", innerException, statusCode)
		{
			base.RequestId = requestId;
			LastKnownLocation = lastKnownLocation;
		}

		public AmazonUnmarshallingException(string requestId, string lastKnownLocation, string responseBody, Exception innerException, HttpStatusCode statusCode)
			: base("Error unmarshalling response back from AWS.", innerException, statusCode)
		{
			base.RequestId = requestId;
			LastKnownLocation = lastKnownLocation;
			ResponseBody = responseBody;
		}

		private static void AppendFormat(StringBuilder sb, string format, string value)
		{
			if (!string.IsNullOrEmpty(value))
			{
				if (sb.Length > 0)
				{
					sb.Append(", ");
				}
				sb.AppendFormat(format, value);
			}
		}
	}
	public abstract class AmazonWebServiceRequest : IAmazonWebServiceRequest
	{
		internal RequestEventHandler mBeforeRequestEvent;

		private Dictionary<string, object> requestState;

		EventHandler<StreamTransferProgressArgs> IAmazonWebServiceRequest.StreamUploadProgressCallback { get; set; }

		Dictionary<string, object> IAmazonWebServiceRequest.RequestState
		{
			get
			{
				if (requestState == null)
				{
					requestState = new Dictionary<string, object>();
				}
				return requestState;
			}
		}

		bool IAmazonWebServiceRequest.UseSigV4 { get; set; }

		protected virtual bool Expect100Continue => false;

		protected virtual bool IncludeSHA256Header => true;

		internal event RequestEventHandler BeforeRequestEvent
		{
			add
			{
				lock (this)
				{
					mBeforeRequestEvent = (RequestEventHandler)Delegate.Combine(mBeforeRequestEvent, value);
				}
			}
			remove
			{
				lock (this)
				{
					mBeforeRequestEvent = (RequestEventHandler)Delegate.Remove(mBeforeRequestEvent, value);
				}
			}
		}

		void IAmazonWebServiceRequest.AddBeforeRequestHandler(RequestEventHandler handler)
		{
			BeforeRequestEvent += handler;
		}

		void IAmazonWebServiceRequest.RemoveBeforeRequestHandler(RequestEventHandler handler)
		{
			BeforeRequestEvent -= handler;
		}

		internal void FireBeforeRequestEvent(object sender, RequestEventArgs args)
		{
			if (mBeforeRequestEvent != null)
			{
				mBeforeRequestEvent(sender, args);
			}
		}

		internal bool GetExpect100Continue()
		{
			return Expect100Continue;
		}

		internal bool GetIncludeSHA256Header()
		{
			return IncludeSHA256Header;
		}

		protected virtual AbstractAWSSigner CreateSigner()
		{
			return null;
		}

		internal AbstractAWSSigner GetSigner()
		{
			return CreateSigner();
		}
	}
	public class AmazonWebServiceResponse
	{
		private ResponseMetadata responseMetadataField;

		private long contentLength;

		private HttpStatusCode httpStatusCode;

		public ResponseMetadata ResponseMetadata
		{
			get
			{
				return responseMetadataField;
			}
			set
			{
				responseMetadataField = value;
			}
		}

		public long ContentLength
		{
			get
			{
				return contentLength;
			}
			set
			{
				contentLength = value;
			}
		}

		public HttpStatusCode HttpStatusCode
		{
			get
			{
				return httpStatusCode;
			}
			set
			{
				httpStatusCode = value;
			}
		}
	}
	public abstract class AWSRegion
	{
		public RegionEndpoint Region { get; protected set; }

		protected void SetRegionFromName(string regionSystemName)
		{
			Region = RegionEndpoint.GetBySystemName(regionSystemName);
		}
	}
	public class AppConfigAWSRegion : AWSRegion
	{
		public AppConfigAWSRegion()
		{
			RegionEndpoint regionEndpoint = AWSConfigs.RegionEndpoint;
			if (regionEndpoint != null)
			{
				base.Region = regionEndpoint;
				Logger.GetLogger(typeof(AppConfigAWSRegion)).InfoFormat("Region {0} found using {1} setting in application configuration file.", regionEndpoint.SystemName, "AWSRegion");
				return;
			}
			throw new InvalidOperationException("The app.config/web.config files for the application did not contain region information");
		}
	}
	public static class FallbackRegionFactory
	{
		private delegate AWSRegion RegionGenerator();

		private static object _lock;

		private static AWSRegion cachedRegion;

		private static List<RegionGenerator> AllGenerators { get; set; }

		private static List<RegionGenerator> NonMetadataGenerators { get; set; }

		static FallbackRegionFactory()
		{
			_lock = new object();
			Reset();
		}

		public static void Reset()
		{
			cachedRegion = null;
			AllGenerators = new List<RegionGenerator>
			{
				() => new AppConfigAWSRegion()
			};
			NonMetadataGenerators = new List<RegionGenerator>
			{
				() => new AppConfigAWSRegion()
			};
		}

		public static RegionEndpoint GetRegionEndpoint()
		{
			return GetRegionEndpoint(includeInstanceMetadata: true);
		}

		public static RegionEndpoint GetRegionEndpoint(bool includeInstanceMetadata)
		{
			lock (_lock)
			{
				if (cachedRegion != null)
				{
					return cachedRegion.Region;
				}
				List<Exception> list = new List<Exception>();
				foreach (RegionGenerator item2 in (IEnumerable<RegionGenerator>)(includeInstanceMetadata ? AllGenerators : NonMetadataGenerators))
				{
					try
					{
						cachedRegion = item2();
					}
					catch (Exception item)
					{
						cachedRegion = null;
						list.Add(item);
					}
					if (cachedRegion != null)
					{
						break;
					}
				}
				return (cachedRegion != null) ? cachedRegion.Region : null;
			}
		}
	}
	[CLSCompliant(false)]
	public abstract class ClientConfig : IClientConfig
	{
		internal static readonly TimeSpan InfiniteTimeout = TimeSpan.FromMilliseconds(-1.0);

		public static readonly TimeSpan MaxTimeout = TimeSpan.FromMilliseconds(2147483647.0);

		private RegionEndpoint regionEndpoint;

		private bool probeForRegionEndpoint = true;

		private bool throttleRetries = true;

		private bool useHttp;

		private string serviceURL;

		private string authRegion;

		private string authServiceName;

		private string signatureVersion = "4";

		private SigningAlgorithm signatureMethod = SigningAlgorithm.HmacSHA256;

		private bool readEntireResponse;

		private bool logResponse;

		private int bufferSize = 8192;

		private long progressUpdateInterval = 102400L;

		private bool resignRetries;

		private ICredentials proxyCredentials;

		private bool logMetrics = AWSConfigs.LoggingConfig.LogMetrics;

		private bool disableLogging;

		private TimeSpan? timeout;

		private bool allowAutoRedirect = true;

		private bool useDualstackEndpoint;

		private TimeSpan? readWriteTimeout;

		private bool disableHostPrefixInjection;

		private bool? endpointDiscoveryEnabled;

		private int endpointDiscoveryCacheLimit = 1000;

		private RequestRetryMode? retryMode;

		private int? maxRetries;

		private const int MaxRetriesDefault = 2;

		private const int MaxRetriesLegacyDefault = 4;

		private bool cacheHttpClient;

		private int? _httpClientCacheSize;

		private IWebProxy proxy;

		private string proxyHost;

		private int proxyPort = -1;

		public abstract string ServiceVersion { get; }

		public SigningAlgorithm SignatureMethod
		{
			get
			{
				return signatureMethod;
			}
			set
			{
				signatureMethod = value;
			}
		}

		public string SignatureVersion
		{
			get
			{
				return signatureVersion;
			}
			set
			{
				signatureVersion = value;
			}
		}

		public abstract string UserAgent { get; }

		public RegionEndpoint RegionEndpoint
		{
			get
			{
				return regionEndpoint;
			}
			set
			{
				serviceURL = null;
				regionEndpoint = value;
				probeForRegionEndpoint = regionEndpoint == null;
			}
		}

		public abstract string RegionEndpointServiceName { get; }

		public string ServiceURL
		{
			get
			{
				return serviceURL;
			}
			set
			{
				regionEndpoint = null;
				probeForRegionEndpoint = false;
				serviceURL = value;
			}
		}

		public bool UseHttp
		{
			get
			{
				return useHttp;
			}
			set
			{
				useHttp = value;
			}
		}

		public string AuthenticationRegion
		{
			get
			{
				return authRegion;
			}
			set
			{
				authRegion = value;
			}
		}

		public string AuthenticationServiceName
		{
			get
			{
				return authServiceName;
			}
			set
			{
				authServiceName = value;
			}
		}

		public int MaxErrorRetry
		{
			get
			{
				if (!maxRetries.HasValue)
				{
					if (RetryMode == RequestRetryMode.Legacy)
					{
						return 4;
					}
					return checked(FallbackInternalConfigurationFactory.MaxAttempts - 1) ?? 2;
				}
				return maxRetries.Value;
			}
			set
			{
				maxRetries = value;
			}
		}

		public bool IsMaxErrorRetrySet => maxRetries.HasValue;

		public bool LogResponse
		{
			get
			{
				return logResponse;
			}
			set
			{
				logResponse = value;
			}
		}

		[Obsolete("This property does not effect response processing and is deprecated.To enable response logging, the ClientConfig.LogResponse and AWSConfigs.LoggingConfig.LogResponses properties can be used.")]
		public bool ReadEntireResponse
		{
			get
			{
				return readEntireResponse;
			}
			set
			{
				readEntireResponse = value;
			}
		}

		public int BufferSize
		{
			get
			{
				return bufferSize;
			}
			set
			{
				bufferSize = value;
			}
		}

		public long ProgressUpdateInterval
		{
			get
			{
				return progressUpdateInterval;
			}
			set
			{
				progressUpdateInterval = value;
			}
		}

		public bool ResignRetries
		{
			get
			{
				return resignRetries;
			}
			set
			{
				resignRetries = value;
			}
		}

		public bool AllowAutoRedirect
		{
			get
			{
				return allowAutoRedirect;
			}
			set
			{
				allowAutoRedirect = value;
			}
		}

		public bool LogMetrics
		{
			get
			{
				return logMetrics;
			}
			set
			{
				logMetrics = value;
			}
		}

		public bool DisableLogging
		{
			get
			{
				return disableLogging;
			}
			set
			{
				disableLogging = value;
			}
		}

		public ICredentials ProxyCredentials
		{
			get
			{
				if (proxyCredentials == null && (!string.IsNullOrEmpty(AWSConfigs.ProxyConfig.Username) || !string.IsNullOrEmpty(AWSConfigs.ProxyConfig.Password)))
				{
					return new NetworkCredential(AWSConfigs.ProxyConfig.Username, AWSConfigs.ProxyConfig.Password ?? string.Empty);
				}
				return proxyCredentials;
			}
			set
			{
				proxyCredentials = value;
			}
		}

		public TimeSpan? Timeout
		{
			get
			{
				return timeout;
			}
			set
			{
				ValidateTimeout(value);
				timeout = value;
			}
		}

		public bool UseDualstackEndpoint
		{
			get
			{
				return useDualstackEndpoint;
			}
			set
			{
				useDualstackEndpoint = value;
			}
		}

		public bool ThrottleRetries
		{
			get
			{
				return throttleRetries;
			}
			set
			{
				throttleRetries = value;
			}
		}

		[Obsolete("Please use CorrectClockSkew.GetCorrectedUtcNowForEndpoint(string endpoint) instead.", false)]
		public DateTime CorrectedUtcNow => CorrectClockSkew.GetCorrectedUtcNowForEndpoint(DetermineServiceURL());

		public TimeSpan ClockOffset
		{
			get
			{
				if (AWSConfigs.ManualClockCorrection.HasValue)
				{
					return AWSConfigs.ManualClockCorrection.Value;
				}
				return CorrectClockSkew.GetClockCorrectionForEndpoint(DetermineServiceURL());
			}
		}

		public bool DisableHostPrefixInjection
		{
			get
			{
				return disableHostPrefixInjection;
			}
			set
			{
				disableHostPrefixInjection = value;
			}
		}

		public bool EndpointDiscoveryEnabled
		{
			get
			{
				if (!endpointDiscoveryEnabled.HasValue)
				{
					return FallbackInternalConfigurationFactory.EndpointDiscoveryEnabled ?? false;
				}
				return endpointDiscoveryEnabled.Value;
			}
			set
			{
				endpointDiscoveryEnabled = value;
			}
		}

		public int EndpointDiscoveryCacheLimit
		{
			get
			{
				return endpointDiscoveryCacheLimit;
			}
			set
			{
				endpointDiscoveryCacheLimit = value;
			}
		}

		public RequestRetryMode RetryMode
		{
			get
			{
				if (!retryMode.HasValue)
				{
					return FallbackInternalConfigurationFactory.RetryMode ?? RequestRetryMode.Legacy;
				}
				return retryMode.Value;
			}
			set
			{
				retryMode = value;
			}
		}

		public bool FastFailRequests { get; set; }

		public bool CacheHttpClient
		{
			get
			{
				return cacheHttpClient;
			}
			set
			{
				cacheHttpClient = value;
			}
		}

		public int HttpClientCacheSize
		{
			get
			{
				if (_httpClientCacheSize.HasValue)
				{
					return _httpClientCacheSize.Value;
				}
				return 1;
			}
			set
			{
				_httpClientCacheSize = value;
			}
		}

		public TimeSpan? ReadWriteTimeout
		{
			get
			{
				return readWriteTimeout;
			}
			set
			{
				ValidateTimeout(value);
				readWriteTimeout = value;
			}
		}

		public string ProxyHost
		{
			get
			{
				if (string.IsNullOrEmpty(proxyHost))
				{
					return AWSConfigs.ProxyConfig.Host;
				}
				return proxyHost;
			}
			set
			{
				proxyHost = value;
				if (ProxyPort > 0)
				{
					proxy = new Amazon.Runtime.Internal.Util.WebProxy(ProxyHost, ProxyPort);
				}
			}
		}

		public int ProxyPort
		{
			get
			{
				if (proxyPort <= 0)
				{
					return AWSConfigs.ProxyConfig.Port.GetValueOrDefault();
				}
				return proxyPort;
			}
			set
			{
				proxyPort = value;
				if (ProxyHost != null)
				{
					proxy = new Amazon.Runtime.Internal.Util.WebProxy(ProxyHost, ProxyPort);
				}
			}
		}

		public IHttpClientFactory HttpClientFactory { get; set; }

		public virtual string DetermineServiceURL()
		{
			if (ServiceURL != null)
			{
				return ServiceURL;
			}
			return GetUrl(RegionEndpoint, RegionEndpointServiceName, UseHttp, UseDualstackEndpoint);
		}

		internal static string GetUrl(RegionEndpoint regionEndpoint, string regionEndpointServiceName, bool useHttp, bool useDualStack)
		{
			RegionEndpoint.Endpoint endpointForService = regionEndpoint.GetEndpointForService(regionEndpointServiceName, useDualStack);
			return new System.Uri(string.Format(CultureInfo.InvariantCulture, "{0}{1}", useHttp ? "http://" : "https://", endpointForService.Hostname)).AbsoluteUri;
		}

		public ClientConfig()
		{
			Initialize();
		}

		protected virtual void Initialize()
		{
		}

		public void SetUseNagleIfAvailable(bool useNagle)
		{
		}

		public virtual void Validate()
		{
			if (RegionEndpoint == null && string.IsNullOrEmpty(ServiceURL))
			{
				throw new AmazonClientException("No RegionEndpoint or ServiceURL configured");
			}
		}

		public static void ValidateTimeout(TimeSpan? timeout)
		{
			if (!timeout.HasValue)
			{
				throw new ArgumentNullException("timeout");
			}
			if (timeout != InfiniteTimeout && (timeout <= TimeSpan.Zero || timeout > MaxTimeout))
			{
				throw new ArgumentOutOfRangeException("timeout");
			}
		}

		public static TimeSpan? GetTimeoutValue(TimeSpan? clientTimeout, TimeSpan? requestTimeout)
		{
			return requestTimeout ?? clientTimeout ?? ((TimeSpan?)null);
		}

		private static RegionEndpoint GetDefaultRegionEndpoint()
		{
			return FallbackRegionFactory.GetRegionEndpoint();
		}

		public IWebProxy GetWebProxy()
		{
			return proxy;
		}

		public void SetWebProxy(IWebProxy proxy)
		{
			this.proxy = proxy;
		}

		internal static bool CacheHttpClients(IClientConfig clientConfig)
		{
			if (clientConfig.HttpClientFactory == null)
			{
				return clientConfig.CacheHttpClient;
			}
			return false;
		}

		internal static bool DisposeHttpClients(IClientConfig clientConfig)
		{
			if (clientConfig.HttpClientFactory == null)
			{
				return !clientConfig.CacheHttpClient;
			}
			return true;
		}

		internal static string CreateConfigUniqueString(IClientConfig clientConfig)
		{
			string empty = string.Empty;
			empty = "AllowAutoRedirect:" + clientConfig.AllowAutoRedirect.ToString() + "CacheSize:" + clientConfig.HttpClientCacheSize;
			if (clientConfig.Timeout.HasValue)
			{
				empty = empty + "Timeout:" + clientConfig.Timeout.Value;
			}
			return empty;
		}

		internal static bool UseGlobalHttpClientCache(IClientConfig clientConfig)
		{
			return clientConfig.ProxyCredentials == null;
		}
	}
	public class ConstantClass
	{
		private static readonly object staticFieldsLock = new object();

		private static Dictionary<Type, Dictionary<string, ConstantClass>> staticFields = new Dictionary<Type, Dictionary<string, ConstantClass>>();

		public string Value { get; private set; }

		protected ConstantClass(string value)
		{
			Value = value;
		}

		public override string ToString()
		{
			return Intern().Value;
		}

		public string ToString(IFormatProvider provider)
		{
			return Intern().Value;
		}

		public static implicit operator string(ConstantClass value)
		{
			if (value == null)
			{
				return null;
			}
			return value.Intern().Value;
		}

		internal ConstantClass Intern()
		{
			if (!staticFields.ContainsKey(GetType()))
			{
				LoadFields(GetType());
			}
			if (!staticFields[GetType()].TryGetValue(Value, out var value))
			{
				return this;
			}
			return value;
		}

		protected static T FindValue<T>(string value) where T : ConstantClass
		{
			if (value == null)
			{
				return null;
			}
			if (!staticFields.ContainsKey(typeof(T)))
			{
				LoadFields(typeof(T));
			}
			if (!staticFields[typeof(T)].TryGetValue(value, out var value2))
			{
				return TypeFactory.GetTypeInfo(typeof(T)).GetConstructor(new ITypeInfo[1] { TypeFactory.GetTypeInfo(typeof(string)) }).Invoke(new object[1] { value }) as T;
			}
			return value2 as T;
		}

		private static void LoadFields(Type t)
		{
			if (staticFields.ContainsKey(t))
			{
				return;
			}
			lock (staticFieldsLock)
			{
				if (staticFields.ContainsKey(t))
				{
					return;
				}
				Dictionary<string, ConstantClass> dictionary = new Dictionary<string, ConstantClass>(StringComparer.OrdinalIgnoreCase);
				foreach (FieldInfo field in TypeFactory.GetTypeInfo(t).GetFields())
				{
					if (field.IsStatic && field.FieldType == t)
					{
						ConstantClass constantClass = field.GetValue(null) as ConstantClass;
						dictionary[constantClass.Value] = constantClass;
					}
				}
				staticFields = new Dictionary<Type, Dictionary<string, ConstantClass>>(staticFields) { [t] = dictionary };
			}
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
			{
				return false;
			}
			if (this == obj)
			{
				return true;
			}
			ConstantClass obj2 = obj as ConstantClass;
			if (Equals(obj2))
			{
				return true;
			}
			if (obj is string value)
			{
				return Equals(value);
			}
			return false;
		}

		public virtual bool Equals(ConstantClass obj)
		{
			if ((object)obj == null)
			{
				return false;
			}
			return StringComparer.OrdinalIgnoreCase.Equals(Value, obj.Value);
		}

		protected virtual bool Equals(string value)
		{
			return StringComparer.OrdinalIgnoreCase.Equals(Value, value);
		}

		public static bool operator ==(ConstantClass a, ConstantClass b)
		{
			if ((object)a == b)
			{
				return true;
			}
			return a?.Equals(b) ?? false;
		}

		public static bool operator !=(ConstantClass a, ConstantClass b)
		{
			return !(a == b);
		}

		public static bool operator ==(ConstantClass a, string b)
		{
			if ((object)a == null && b == null)
			{
				return true;
			}
			return a?.Equals(b) ?? false;
		}

		public static bool operator ==(string a, ConstantClass b)
		{
			return b == a;
		}

		public static bool operator !=(ConstantClass a, string b)
		{
			return !(a == b);
		}

		public static bool operator !=(string a, ConstantClass b)
		{
			return !(a == b);
		}
	}
	public static class CorrectClockSkew
	{
		private static TimeSpan? manualClockCorrection;

		private static ReaderWriterLockSlim manualClockCorrectionLock = new ReaderWriterLockSlim();

		private static IDictionary<string, TimeSpan> clockCorrectionDictionary = new Dictionary<string, TimeSpan>();

		private static ReaderWriterLockSlim clockCorrectionDictionaryLock = new ReaderWriterLockSlim();

		internal static TimeSpan? GlobalClockCorrection
		{
			get
			{
				manualClockCorrectionLock.EnterReadLock();
				TimeSpan? result = manualClockCorrection;
				manualClockCorrectionLock.ExitReadLock();
				return result;
			}
			set
			{
				manualClockCorrectionLock.EnterWriteLock();
				manualClockCorrection = value;
				manualClockCorrectionLock.ExitWriteLock();
			}
		}

		public static TimeSpan GetClockCorrectionForEndpoint(string endpoint)
		{
			bool flag = false;
			clockCorrectionDictionaryLock.EnterReadLock();
			TimeSpan value;
			try
			{
				flag = clockCorrectionDictionary.TryGetValue(endpoint, out value);
			}
			finally
			{
				clockCorrectionDictionaryLock.ExitReadLock();
			}
			if (!flag)
			{
				return TimeSpan.Zero;
			}
			return value;
		}

		public static DateTime GetCorrectedUtcNowForEndpoint(string endpoint)
		{
			TimeSpan timeSpan = TimeSpan.Zero;
			manualClockCorrectionLock.EnterReadLock();
			try
			{
				if (manualClockCorrection.HasValue)
				{
					timeSpan = manualClockCorrection.Value;
				}
			}
			finally
			{
				manualClockCorrectionLock.ExitReadLock();
			}
			if (AWSConfigs.CorrectForClockSkew && timeSpan == TimeSpan.Zero)
			{
				timeSpan = GetClockCorrectionForEndpoint(endpoint);
			}
			return AWSConfigs.utcNowSource() + timeSpan;
		}

		internal static void SetClockCorrectionForEndpoint(string endpoint, TimeSpan correction)
		{
			clockCorrectionDictionaryLock.EnterWriteLock();
			try
			{
				clockCorrectionDictionary[endpoint] = correction;
				AWSConfigs.ClockOffset = correction;
			}
			finally
			{
				clockCorrectionDictionaryLock.ExitWriteLock();
			}
		}
	}
	[Obsolete("This class has been deprecated in favor of FallbackConfigurationFactory.")]
	public static class FallbackEndpointDiscoveryEnabledFactory
	{
		private delegate bool ConfigGenerator();

		private static object _lock;

		private static bool? endpointDiscoveryEnabled;

		private static List<ConfigGenerator> EnabledGenerators { get; set; }

		static FallbackEndpointDiscoveryEnabledFactory()
		{
			_lock = new object();
			Reset();
		}

		public static void Reset()
		{
			endpointDiscoveryEnabled = null;
			EnabledGenerators = new List<ConfigGenerator>();
		}

		public static bool? GetEnabled()
		{
			lock (_lock)
			{
				if (endpointDiscoveryEnabled.HasValue)
				{
					return endpointDiscoveryEnabled;
				}
				List<Exception> list = new List<Exception>();
				foreach (ConfigGenerator enabledGenerator in EnabledGenerators)
				{
					try
					{
						endpointDiscoveryEnabled = enabledGenerator();
					}
					catch (Exception item)
					{
						list.Add(item);
						continue;
					}
					if (endpointDiscoveryEnabled.HasValue)
					{
						break;
					}
				}
				return endpointDiscoveryEnabled;
			}
		}
	}
	public enum SigningAlgorithm
	{
		HmacSHA1,
		HmacSHA256
	}
	public enum ErrorType
	{
		Sender,
		Receiver,
		Unknown
	}
	public enum StsRegionalEndpointsValue
	{
		Legacy,
		Regional
	}
	public enum S3UsEast1RegionalEndpointValue
	{
		Legacy,
		Regional
	}
	public enum RequestRetryMode
	{
		Legacy,
		Standard,
		Adaptive
	}
	public delegate void ExceptionEventHandler(object sender, ExceptionEventArgs e);
	public class ExceptionEventArgs : EventArgs
	{
		protected ExceptionEventArgs()
		{
		}
	}
	public class WebServiceExceptionEventArgs : ExceptionEventArgs
	{
		public IDictionary<string, string> Headers { get; protected set; }

		public IDictionary<string, string> Parameters { get; protected set; }

		public string ServiceName { get; protected set; }

		public System.Uri Endpoint { get; protected set; }

		public AmazonWebServiceRequest Request { get; protected set; }

		public Exception Exception { get; protected set; }

		protected WebServiceExceptionEventArgs()
		{
		}

		internal static WebServiceExceptionEventArgs Create(Exception exception, IRequest request)
		{
			if (request == null)
			{
				return new WebServiceExceptionEventArgs
				{
					Exception = exception
				};
			}
			return new WebServiceExceptionEventArgs
			{
				Headers = request.Headers,
				Parameters = request.Parameters,
				ServiceName = request.ServiceName,
				Request = request.OriginalRequest,
				Endpoint = request.Endpoint,
				Exception = exception
			};
		}
	}
	public interface IAmazonService
	{
		IClientConfig Config { get; }
	}
	[CLSCompliant(false)]
	public interface IClientConfig
	{
		RegionEndpoint RegionEndpoint { get; }

		string RegionEndpointServiceName { get; }

		string ServiceURL { get; }

		bool UseHttp { get; }

		string ServiceVersion { get; }

		SigningAlgorithm SignatureMethod { get; }

		string SignatureVersion { get; }

		string AuthenticationRegion { get; }

		string AuthenticationServiceName { get; }

		string UserAgent { get; }

		bool DisableLogging { get; }

		bool LogMetrics { get; }

		bool LogResponse { get; }

		bool ReadEntireResponse { get; }

		bool AllowAutoRedirect { get; }

		int BufferSize { get; }

		int MaxErrorRetry { get; }

		bool IsMaxErrorRetrySet { get; }

		long ProgressUpdateInterval { get; }

		bool ResignRetries { get; }

		ICredentials ProxyCredentials { get; }

		TimeSpan? Timeout { get; }

		bool UseDualstackEndpoint { get; }

		bool ThrottleRetries { get; }

		DateTime CorrectedUtcNow { get; }

		TimeSpan ClockOffset { get; }

		bool DisableHostPrefixInjection { get; }

		bool EndpointDiscoveryEnabled { get; }

		int EndpointDiscoveryCacheLimit { get; }

		RequestRetryMode RetryMode { get; }

		bool FastFailRequests { get; }

		bool CacheHttpClient { get; }

		int HttpClientCacheSize { get; }

		string ProxyHost { get; }

		int ProxyPort { get; }

		IHttpClientFactory HttpClientFactory { get; }

		string DetermineServiceURL();

		void Validate();

		IWebProxy GetWebProxy();
	}
	public interface ILogMessage
	{
		string Format { get; }

		object[] Args { get; }

		IFormatProvider Provider { get; }
	}
	public abstract class ParameterValue
	{
	}
	public class StringParameterValue : ParameterValue
	{
		public string Value { get; set; }

		public StringParameterValue(string value)
		{
			Value = value;
		}

		internal StringParameterValue()
		{
		}
	}
	public class StringListParameterValue : ParameterValue
	{
		public List<string> Value { get; set; }

		public StringListParameterValue(List<string> values)
		{
			Value = values;
		}

		internal StringListParameterValue()
		{
		}
	}
	public class PreRequestEventArgs : EventArgs
	{
		public AmazonWebServiceRequest Request { get; protected set; }

		protected PreRequestEventArgs()
		{
		}

		internal static PreRequestEventArgs Create(AmazonWebServiceRequest request)
		{
			return new PreRequestEventArgs
			{
				Request = request
			};
		}
	}
	public delegate void PreRequestEventHandler(object sender, PreRequestEventArgs e);
	public class RequestEventArgs : EventArgs
	{
		protected RequestEventArgs()
		{
		}
	}
	public class WebServiceRequestEventArgs : RequestEventArgs
	{
		public IDictionary<string, string> Headers { get; protected set; }

		[Obsolete("Parameters property has been deprecated in favor of the ParameterCollection property")]
		public IDictionary<string, string> Parameters { get; protected set; }

		public ParameterCollection ParameterCollection { get; protected set; }

		public string ServiceName { get; protected set; }

		public System.Uri Endpoint { get; protected set; }

		public AmazonWebServiceRequest Request { get; protected set; }

		[Obsolete("OriginalRequest property has been deprecated in favor of the Request property")]
		public AmazonWebServiceRequest OriginalRequest => Request;

		protected WebServiceRequestEventArgs()
		{
		}

		internal static WebServiceRequestEventArgs Create(IRequest request)
		{
			return new WebServiceRequestEventArgs
			{
				Headers = request.Headers,
				Parameters = request.Parameters,
				ParameterCollection = request.ParameterCollection,
				ServiceName = request.ServiceName,
				Request = request.OriginalRequest,
				Endpoint = request.Endpoint
			};
		}
	}
	public class HeadersRequestEventArgs : RequestEventArgs
	{
		public IDictionary<string, string> Headers { get; protected set; }

		protected HeadersRequestEventArgs()
		{
		}

		internal static HeadersRequestEventArgs Create(IDictionary<string, string> headers)
		{
			return new HeadersRequestEventArgs
			{
				Headers = headers
			};
		}
	}
	public delegate void RequestEventHandler(object sender, RequestEventArgs e);
	public interface IRequestMetrics
	{
		Dictionary<Metric, List<object>> Properties { get; }

		Dictionary<Metric, List<IMetricsTiming>> Timings { get; }

		Dictionary<Metric, long> Counters { get; }

		bool IsEnabled { get; }

		string ToJSON();
	}
	public interface IMetricsTiming
	{
		bool IsFinished { get; }

		long ElapsedTicks { get; }

		TimeSpan ElapsedTime { get; }
	}
	public interface IMetricsFormatter
	{
		string FormatMetrics(IRequestMetrics metrics);
	}
	public enum Metric
	{
		AWSErrorCode,
		AWSRequestID,
		AmzId2,
		BytesProcessed,
		Exception,
		RedirectLocation,
		ResponseProcessingTime,
		ResponseUnmarshallTime,
		ResponseReadTime,
		StatusCode,
		AttemptCount,
		CredentialsRequestTime,
		HttpRequestTime,
		ProxyHost,
		ProxyPort,
		RequestSigningTime,
		RetryPauseTime,
		StringToSign,
		CanonicalRequest,
		CSMAttemptLatency,
		AsyncCall,
		ClientExecuteTime,
		MethodName,
		ServiceEndpoint,
		ServiceName,
		RequestSize,
		AmzCfId
	}
	public delegate void ResponseEventHandler(object sender, ResponseEventArgs e);
	public class ResponseEventArgs : EventArgs
	{
		protected ResponseEventArgs()
		{
		}
	}
	public class WebServiceResponseEventArgs : ResponseEventArgs
	{
		public IDictionary<string, string> RequestHeaders { get; private set; }

		public IDictionary<string, string> ResponseHeaders { get; private set; }

		public IDictionary<string, string> Parameters { get; private set; }

		public string ServiceName { get; private set; }

		public System.Uri Endpoint { get; private set; }

		public AmazonWebServiceRequest Request { get; private set; }

		public AmazonWebServiceResponse Response { get; private set; }

		protected WebServiceResponseEventArgs()
		{
		}

		internal static WebServiceResponseEventArgs Create(AmazonWebServiceResponse response, IRequest request, IWebResponseData webResponseData)
		{
			WebServiceResponseEventArgs e = new WebServiceResponseEventArgs
			{
				RequestHeaders = request.Headers,
				Parameters = request.Parameters,
				ServiceName = request.ServiceName,
				Request = request.OriginalRequest,
				Endpoint = request.Endpoint,
				Response = response
			};
			e.ResponseHeaders = new Dictionary<string, string>();
			if (webResponseData != null)
			{
				string[] headerNames = webResponseData.GetHeaderNames();
				foreach (string text in headerNames)
				{
					string headerValue = webResponseData.GetHeaderValue(text);
					e.ResponseHeaders[text] = headerValue;
				}
			}
			return e;
		}
	}
	public class ResponseMetadata
	{
		private string requestIdField;

		private IDictionary<string, string> _metadata;

		public string RequestId
		{
			get
			{
				return requestIdField;
			}
			set
			{
				requestIdField = value;
			}
		}

		public IDictionary<string, string> Metadata
		{
			get
			{
				if (_metadata == null)
				{
					_metadata = new Dictionary<string, string>();
				}
				return _metadata;
			}
		}
	}
	public class SignatureException : Amazon.Runtime.Internal.Auth.SignatureException
	{
		public SignatureException(string message)
			: base(message)
		{
		}

		public SignatureException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
	public class StreamTransferProgressArgs : EventArgs
	{
		private long _incrementTransferred;

		private long _total;

		private long _transferred;

		public int PercentDone
		{
			get
			{
				checked
				{
					return (int)unchecked(checked(_transferred * 100) / _total);
				}
			}
		}

		public long IncrementTransferred => _incrementTransferred;

		public long TransferredBytes => _transferred;

		public long TotalBytes => _total;

		public StreamTransferProgressArgs(long incrementTransferred, long transferred, long total)
		{
			_incrementTransferred = incrementTransferred;
			_transferred = transferred;
			_total = total;
		}

		public override string ToString()
		{
			return "Transfer Statistics. Percentage completed: " + PercentDone + ", Bytes transferred: " + _transferred + ", Total bytes to transfer: " + _total;
		}
	}
	public class AnonymousAWSCredentials : AWSCredentials
	{
		public override ImmutableCredentials GetCredentials()
		{
			throw new NotSupportedException("AnonymousAWSCredentials do not support this operation");
		}
	}
	public class AssumeRoleAWSCredentials : RefreshingAWSCredentials
	{
		private RegionEndpoint DefaultSTSClientRegion = RegionEndpoint.USEast1;

		private Logger _logger = Logger.GetLogger(typeof(AssumeRoleAWSCredentials));

		public AWSCredentials SourceCredentials { get; private set; }

		public string RoleArn { get; private set; }

		public string RoleSessionName { get; private set; }

		public AssumeRoleAWSCredentialsOptions Options { get; private set; }

		public AssumeRoleAWSCredentials(AWSCredentials sourceCredentials, string roleArn, string roleSessionName)
			: this(sourceCredentials, roleArn, roleSessionName, new AssumeRoleAWSCredentialsOptions())
		{
		}

		public AssumeRoleAWSCredentials(AWSCredentials sourceCredentials, string roleArn, string roleSessionName, AssumeRoleAWSCredentialsOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			SourceCredentials = sourceCredentials;
			RoleArn = roleArn;
			RoleSessionName = roleSessionName;
			Options = options;
			base.PreemptExpiryTime = TimeSpan.FromMinutes(5.0);
		}

		protected override CredentialsRefreshState GenerateNewCredentials()
		{
			string aWSRegion = AWSConfigs.AWSRegion;
			RegionEndpoint regionEndpoint = (string.IsNullOrEmpty(aWSRegion) ? DefaultSTSClientRegion : RegionEndpoint.GetBySystemName(aWSRegion));
			ICoreAmazonSTS coreAmazonSTS = null;
			try
			{
				ClientConfig clientConfig = ServiceClientHelpers.CreateServiceConfig("AWSSDK.SecurityToken", "Amazon.SecurityToken.AmazonSecurityTokenServiceConfig");
				clientConfig.RegionEndpoint = regionEndpoint;
				coreAmazonSTS = ServiceClientHelpers.CreateServiceFromAssembly<ICoreAmazonSTS>("AWSSDK.SecurityToken", "Amazon.SecurityToken.AmazonSecurityTokenServiceClient", SourceCredentials, clientConfig);
			}
			catch (Exception innerException)
			{
				InvalidOperationException ex = new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Assembly {0} could not be found or loaded. This assembly must be available at runtime to use Amazon.Runtime.AssumeRoleAWSCredentials.", "AWSSDK.SecurityToken"), innerException);
				Logger.GetLogger(typeof(AssumeRoleAWSCredentials)).Error(ex, ex.Message);
				throw ex;
			}
			AssumeRoleImmutableCredentials assumeRoleImmutableCredentials = coreAmazonSTS.CredentialsFromAssumeRoleAuthentication(RoleArn, RoleSessionName, Options);
			_logger.InfoFormat("New credentials created for assume role that expire at {0}", assumeRoleImmutableCredentials.Expiration.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK", CultureInfo.InvariantCulture));
			return new CredentialsRefreshState(assumeRoleImmutableCredentials, assumeRoleImmutableCredentials.Expiration);
		}
	}
	public class AssumeRoleAWSCredentialsOptions
	{
		public string ExternalId { get; set; }

		public string Policy { get; set; }

		public int? DurationSeconds { get; set; }

		public string MfaSerialNumber { get; set; }

		public string MfaTokenCode
		{
			get
			{
				if (string.IsNullOrEmpty(MfaSerialNumber))
				{
					return null;
				}
				if (MfaTokenCodeCallback == null)
				{
					throw new InvalidOperationException("The MfaSerialNumber has been set but the MfaTokenCodeCallback hasn't.  MfaTokenCodeCallback is required in order to determine the MfaTokenCode when MfaSerialNumber is set.");
				}
				return MfaTokenCodeCallback();
			}
		}

		public Func<string> MfaTokenCodeCallback { get; set; }
	}
	public class AssumeRoleImmutableCredentials : ImmutableCredentials
	{
		public DateTime Expiration { get; private set; }

		public AssumeRoleImmutableCredentials(string awsAccessKeyId, string awsSecretAccessKey, string token, DateTime expiration)
			: base(awsAccessKeyId, awsSecretAccessKey, token)
		{
			if (string.IsNullOrEmpty(token))
			{
				throw new ArgumentNullException("token");
			}
			Expiration = expiration;
		}

		public new AssumeRoleImmutableCredentials Copy()
		{
			return new AssumeRoleImmutableCredentials(base.AccessKey, base.SecretKey, base.Token, Expiration);
		}

		public override int GetHashCode()
		{
			return Hashing.Hash(base.AccessKey, base.SecretKey, base.Token, Expiration);
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (!(obj is AssumeRoleImmutableCredentials assumeRoleImmutableCredentials))
			{
				return false;
			}
			return AWSSDKUtils.AreEqual(new object[4] { base.AccessKey, base.SecretKey, base.Token, Expiration }, new object[4] { assumeRoleImmutableCredentials.AccessKey, assumeRoleImmutableCredentials.SecretKey, assumeRoleImmutableCredentials.Token, Expiration });
		}
	}
	public abstract class AWSCredentials
	{
		public abstract ImmutableCredentials GetCredentials();

		protected virtual void Validate()
		{
		}

		public virtual Task<ImmutableCredentials> GetCredentialsAsync()
		{
			return Task.FromResult(GetCredentials());
		}
	}
	public class BasicAWSCredentials : AWSCredentials
	{
		private ImmutableCredentials _credentials;

		public BasicAWSCredentials(string accessKey, string secretKey)
		{
			if (!string.IsNullOrEmpty(accessKey))
			{
				_credentials = new ImmutableCredentials(accessKey, secretKey, null);
			}
		}

		public override ImmutableCredentials GetCredentials()
		{
			if (_credentials == null)
			{
				return null;
			}
			return _credentials.Copy();
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (!(obj is BasicAWSCredentials basicAWSCredentials))
			{
				return false;
			}
			return AWSSDKUtils.AreEqual(new object[1] { _credentials }, new object[1] { basicAWSCredentials._credentials });
		}

		public override int GetHashCode()
		{
			return Hashing.Hash(_credentials);
		}
	}
	public static class FallbackCredentialsFactory
	{
		public delegate AWSCredentials CredentialsGenerator();

		private static AWSCredentials cachedCredentials;

		public static List<CredentialsGenerator> CredentialsGenerators { get; set; }

		static FallbackCredentialsFactory()
		{
			Reset();
		}

		public static void Reset()
		{
			Reset(null);
		}

		public static void Reset(IWebProxy proxy)
		{
			cachedCredentials = null;
			CredentialsGenerators = new List<CredentialsGenerator>();
		}

		public static AWSCredentials GetCredentials()
		{
			return GetCredentials(fallbackToAnonymous: false);
		}

		public static AWSCredentials GetCredentials(bool fallbackToAnonymous)
		{
			if (cachedCredentials != null)
			{
				return cachedCredentials;
			}
			List<Exception> list = new List<Exception>();
			foreach (CredentialsGenerator credentialsGenerator in CredentialsGenerators)
			{
				try
				{
					cachedCredentials = credentialsGenerator();
				}
				catch (Exception item)
				{
					cachedCredentials = null;
					list.Add(item);
				}
				if (cachedCredentials != null)
				{
					break;
				}
			}
			checked
			{
				if (cachedCredentials == null)
				{
					if (fallbackToAnonymous)
					{
						return new AnonymousAWSCredentials();
					}
					using StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
					stringWriter.WriteLine("Unable to find credentials");
					stringWriter.WriteLine();
					for (int i = 0; i < list.Count; i++)
					{
						Exception ex = list[i];
						stringWriter.WriteLine("Exception {0} of {1}:", i + 1, list.Count);
						stringWriter.WriteLine(ex.ToString());
						stringWriter.WriteLine();
					}
					throw new AmazonServiceException(stringWriter.ToString());
				}
				return cachedCredentials;
			}
		}
	}
	public class ImmutableCredentials
	{
		public string AccessKey { get; private set; }

		public string SecretKey { get; private set; }

		public string Token { get; private set; }

		public bool UseToken => !string.IsNullOrEmpty(Token);

		public ImmutableCredentials(string awsAccessKeyId, string awsSecretAccessKey, string token)
		{
			if (string.IsNullOrEmpty(awsAccessKeyId))
			{
				throw new ArgumentNullException("awsAccessKeyId");
			}
			if (string.IsNullOrEmpty(awsSecretAccessKey))
			{
				throw new ArgumentNullException("awsSecretAccessKey");
			}
			AccessKey = awsAccessKeyId;
			SecretKey = awsSecretAccessKey;
			Token = token ?? string.Empty;
		}

		private ImmutableCredentials()
		{
		}

		public virtual ImmutableCredentials Copy()
		{
			return new ImmutableCredentials
			{
				AccessKey = AccessKey,
				SecretKey = SecretKey,
				Token = Token
			};
		}

		public override int GetHashCode()
		{
			return Hashing.Hash(AccessKey, SecretKey, Token);
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (!(obj is ImmutableCredentials immutableCredentials))
			{
				return false;
			}
			return AWSSDKUtils.AreEqual(new object[3] { AccessKey, SecretKey, Token }, new object[3] { immutableCredentials.AccessKey, immutableCredentials.SecretKey, immutableCredentials.Token });
		}
	}
	public abstract class RefreshingAWSCredentials : AWSCredentials, IDisposable
	{
		public class CredentialsRefreshState
		{
			public ImmutableCredentials Credentials { get; set; }

			public DateTime Expiration { get; set; }

			public CredentialsRefreshState()
			{
			}

			public CredentialsRefreshState(ImmutableCredentials credentials, DateTime expiration)
			{
				Credentials = credentials;
				Expiration = expiration;
			}

			internal bool IsExpiredWithin(TimeSpan preemptExpiryTime)
			{
				DateTime correctedUtcNow = AWSSDKUtils.CorrectedUtcNow;
				DateTime dateTime = Expiration.ToUniversalTime();
				return correctedUtcNow > dateTime - preemptExpiryTime;
			}
		}

		private Logger _logger = Logger.GetLogger(typeof(RefreshingAWSCredentials));

		protected CredentialsRefreshState currentState;

		private TimeSpan _preemptExpiryTime = TimeSpan.FromMinutes(0.0);

		private bool _disposed;

		private readonly SemaphoreSlim _updateGeneratedCredentialsSemaphore = new SemaphoreSlim(1, 1);

		public TimeSpan PreemptExpiryTime
		{
			get
			{
				return _preemptExpiryTime;
			}
			set
			{
				if (value < TimeSpan.Zero)
				{
					throw new ArgumentOutOfRangeException("value", "PreemptExpiryTime cannot be negative");
				}
				_preemptExpiryTime = value;
			}
		}

		protected bool ShouldUpdate => ShouldUpdateState(currentState, PreemptExpiryTime);

		public override ImmutableCredentials GetCredentials()
		{
			_updateGeneratedCredentialsSemaphore.Wait();
			try
			{
				CredentialsRefreshState credentialsRefreshState = currentState;
				if (ShouldUpdateState(credentialsRefreshState, PreemptExpiryTime))
				{
					credentialsRefreshState = GenerateNewCredentials();
					UpdateToGeneratedCredentials(credentialsRefreshState, PreemptExpiryTime);
					currentState = credentialsRefreshState;
				}
				return credentialsRefreshState.Credentials.Copy();
			}
			finally
			{
				_updateGeneratedCredentialsSemaphore.Release();
			}
		}

		public override async Task<ImmutableCredentials> GetCredentialsAsync()
		{
			await _updateGeneratedCredentialsSemaphore.WaitAsync().ConfigureAwait(continueOnCapturedContext: false);
			try
			{
				CredentialsRefreshState credentialsRefreshState = currentState;
				if (ShouldUpdateState(credentialsRefreshState, PreemptExpiryTime))
				{
					credentialsRefreshState = await GenerateNewCredentialsAsync().ConfigureAwait(continueOnCapturedContext: false);
					UpdateToGeneratedCredentials(credentialsRefreshState, PreemptExpiryTime);
					currentState = credentialsRefreshState;
				}
				return credentialsRefreshState.Credentials.Copy();
			}
			finally
			{
				_updateGeneratedCredentialsSemaphore.Release();
			}
		}

		private static void UpdateToGeneratedCredentials(CredentialsRefreshState state, TimeSpan preemptExpiryTime)
		{
			if (ShouldUpdateState(state, preemptExpiryTime))
			{
				string message = ((state != null) ? string.Format(CultureInfo.InvariantCulture, "The retrieved credentials have already expired: Now = {0}, Credentials expiration = {1}", AWSSDKUtils.CorrectedUtcNow.ToLocalTime(), state.Expiration) : "Unable to generate temporary credentials");
				throw new AmazonClientException(message);
			}
			state.Expiration -= preemptExpiryTime;
			if (ShouldUpdateState(state, preemptExpiryTime))
			{
				Logger.GetLogger(typeof(RefreshingAWSCredentials)).InfoFormat("The preempt expiry time is set too high: Current time = {0}, Credentials expiry time = {1}, Preempt expiry time = {2}.", AWSSDKUtils.CorrectedUtcNow.ToLocalTime(), state.Expiration, preemptExpiryTime);
			}
		}

		private static bool ShouldUpdateState(CredentialsRefreshState state, TimeSpan preemptExpiryTime)
		{
			bool flag = state?.IsExpiredWithin(TimeSpan.Zero) ?? true;
			if (state != null && flag)
			{
				Logger.GetLogger(typeof(RefreshingAWSCredentials)).InfoFormat("Determined refreshing credentials should update. Expiration time: {0}, Current time: {1}", state.Expiration.Add(preemptExpiryTime).ToUniversalTime().ToString("yyyy-MM-ddTHH:mm:ss.fffffffK", CultureInfo.InvariantCulture), AWSSDKUtils.CorrectedUtcNow.ToString("yyyy-MM-ddTHH:mm:ss.fffffffK", CultureInfo.InvariantCulture));
			}
			return flag;
		}

		protected virtual CredentialsRefreshState GenerateNewCredentials()
		{
			throw new NotImplementedException();
		}

		protected virtual Task<CredentialsRefreshState> GenerateNewCredentialsAsync()
		{
			return Task.Run(() => GenerateNewCredentials());
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					_updateGeneratedCredentialsSemaphore.Dispose();
				}
				_disposed = true;
			}
		}

		public virtual void ClearCredentials()
		{
			currentState = null;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
	public class SAMLImmutableCredentials : ImmutableCredentials
	{
		private const string AccessKeyProperty = "AccessKey";

		private const string SecretKeyProperty = "SecretKey";

		private const string TokenProperty = "Token";

		private const string ExpiresProperty = "Expires";

		private const string SubjectProperty = "Subject";

		public DateTime Expires { get; private set; }

		public string Subject { get; private set; }

		public SAMLImmutableCredentials(string awsAccessKeyId, string awsSecretAccessKey, string token, DateTime expires, string subject)
			: base(awsAccessKeyId, awsSecretAccessKey, token)
		{
			Expires = expires;
			Subject = subject;
		}

		public SAMLImmutableCredentials(ImmutableCredentials credentials, DateTime expires, string subject)
			: base(credentials.AccessKey, credentials.SecretKey, credentials.Token)
		{
			Expires = expires;
			Subject = subject;
		}

		public override int GetHashCode()
		{
			return Hashing.Hash(base.AccessKey, base.SecretKey, base.Token, Subject, Expires);
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (!(obj is SAMLImmutableCredentials sAMLImmutableCredentials))
			{
				return false;
			}
			if (base.Equals(obj))
			{
				if (string.Equals(Subject, sAMLImmutableCredentials.Subject, StringComparison.Ordinal))
				{
					return DateTime.Equals(Expires, sAMLImmutableCredentials.Expires);
				}
				return false;
			}
			return false;
		}

		public override ImmutableCredentials Copy()
		{
			return new SAMLImmutableCredentials(base.AccessKey, base.SecretKey, base.Token, Expires, Subject);
		}

		internal string ToJson()
		{
			return JsonMapper.ToJson(new Dictionary<string, string>
			{
				{ "AccessKey", base.AccessKey },
				{ "SecretKey", base.SecretKey },
				{ "Token", base.Token },
				{
					"Expires",
					Expires.ToString("u", CultureInfo.InvariantCulture)
				},
				{ "Subject", Subject }
			});
		}

		internal static SAMLImmutableCredentials FromJson(string json)
		{
			try
			{
				JsonData jsonData = JsonMapper.ToObject(json);
				DateTime dateTime = DateTime.Parse((string)jsonData["Expires"], CultureInfo.InvariantCulture).ToUniversalTime();
				if (dateTime <= AWSSDKUtils.CorrectedUtcNow)
				{
					Logger.GetLogger(typeof(SAMLImmutableCredentials)).InfoFormat("Skipping serialized credentials due to expiry.");
					return null;
				}
				string awsAccessKeyId = (string)jsonData["AccessKey"];
				string awsSecretAccessKey = (string)jsonData["SecretKey"];
				string token = (string)jsonData["Token"];
				string subject = (string)jsonData["Subject"];
				return new SAMLImmutableCredentials(awsAccessKeyId, awsSecretAccessKey, token, dateTime, subject);
			}
			catch (Exception exception)
			{
				Logger.GetLogger(typeof(SAMLImmutableCredentials)).Error(exception, "Error during deserialization");
			}
			return null;
		}
	}
	public class SessionAWSCredentials : AWSCredentials
	{
		private ImmutableCredentials _lastCredentials;

		public SessionAWSCredentials(string awsAccessKeyId, string awsSecretAccessKey, string token)
		{
			if (string.IsNullOrEmpty(awsAccessKeyId))
			{
				throw new ArgumentNullException("awsAccessKeyId");
			}
			if (string.IsNullOrEmpty(awsSecretAccessKey))
			{
				throw new ArgumentNullException("awsSecretAccessKey");
			}
			if (string.IsNullOrEmpty(token))
			{
				throw new ArgumentNullException("token");
			}
			_lastCredentials = new ImmutableCredentials(awsAccessKeyId, awsSecretAccessKey, token);
		}

		public override ImmutableCredentials GetCredentials()
		{
			return _lastCredentials.Copy();
		}

		public override bool Equals(object obj)
		{
			if (this == obj)
			{
				return true;
			}
			if (!(obj is SessionAWSCredentials sessionAWSCredentials))
			{
				return false;
			}
			return AWSSDKUtils.AreEqual(new object[1] { _lastCredentials }, new object[1] { sessionAWSCredentials._lastCredentials });
		}

		public override int GetHashCode()
		{
			return Hashing.Hash(_lastCredentials);
		}
	}
	public class URIBasedRefreshingCredentialHelper : RefreshingAWSCredentials
	{
		protected class SecurityBase
		{
			public string Code { get; set; }

			public string Message { get; set; }

			public DateTime LastUpdated { get; set; }
		}

		protected class SecurityInfo : SecurityBase
		{
			public string InstanceProfileArn { get; set; }

			public string InstanceProfileId { get; set; }
		}

		protected class SecurityCredentials : SecurityBase
		{
			public string Type { get; set; }

			public string AccessKeyId { get; set; }

			public string SecretAccessKey { get; set; }

			public string Token { get; set; }

			public DateTime Expiration { get; set; }

			public string RoleArn { get; set; }
		}

		private static string SuccessCode = "Success";

		protected static string GetContents(System.Uri uri)
		{
			return GetContents(uri, null);
		}

		protected static string GetContents(System.Uri uri, IWebProxy proxy)
		{
			return GetContents(uri, proxy, null);
		}

		protected static string GetContents(System.Uri uri, IWebProxy proxy, Dictionary<string, string> headers)
		{
			try
			{
				return AWSSDKUtils.ExecuteHttpRequest(uri, "GET", null, TimeSpan.Zero, proxy, headers);
			}
			catch (Exception innerException)
			{
				throw new AmazonServiceException("Unable to reach credentials server", innerException);
			}
		}

		protected static T GetObjectFromResponse<T>(System.Uri uri)
		{
			return GetObjectFromResponse<T>(uri, null, null);
		}

		protected static T GetObjectFromResponse<T>(System.Uri uri, IWebProxy proxy)
		{
			return GetObjectFromResponse<T>(uri, proxy, null);
		}

		protected static T GetObjectFromResponse<T>(System.Uri uri, IWebProxy proxy, Dictionary<string, string> headers)
		{
			return JsonMapper.ToObject<T>(GetContents(uri, proxy, headers));
		}

		protected static void ValidateResponse(SecurityBase response)
		{
			if (!string.Equals(response.Code, SuccessCode, StringComparison.OrdinalIgnoreCase))
			{
				throw new AmazonServiceException(string.Format(CultureInfo.InvariantCulture, "Unable to retrieve credentials. Code = \"{0}\". Message = \"{1}\".", response.Code, response.Message));
			}
		}
	}
	[Obsolete("InstanceProfileAWSCredentials is no longer available on PCL platform", true)]
	public class InstanceProfileAWSCredentials : URIBasedRefreshingCredentialHelper
	{
		[Obsolete("InstanceProfileAWSCredentials is no longer available on PCL platform")]
		public string Role
		{
			get
			{
				throw new NotImplementedException();
			}
			set
			{
				throw new NotImplementedException();
			}
		}

		[Obsolete("InstanceProfileAWSCredentials no longer available on PCL platform", true)]
		protected override CredentialsRefreshState GenerateNewCredentials()
		{
			throw new NotImplementedException();
		}

		[Obsolete("InstanceProfileAWSCredentials no longer available on PCL platform", true)]
		public InstanceProfileAWSCredentials(string role)
		{
			throw new NotImplementedException();
		}

		[Obsolete("InstanceProfileAWSCredentials no longer available on PCL platform", true)]
		public InstanceProfileAWSCredentials()
		{
			throw new NotImplementedException();
		}

		[Obsolete("InstanceProfileAWSCredentials no longer available on PCL platform", true)]
		public static IEnumerable<string> GetAvailableRoles()
		{
			throw new NotImplementedException();
		}
	}
	public interface IRequestContext
	{
		AmazonWebServiceRequest OriginalRequest { get; }

		string RequestName { get; }

		IMarshaller<IRequest, AmazonWebServiceRequest> Marshaller { get; }

		ResponseUnmarshaller Unmarshaller { get; }

		InvokeOptionsBase Options { get; }

		RequestMetrics Metrics { get; }

		AbstractAWSSigner Signer { get; }

		IClientConfig ClientConfig { get; }

		ImmutableCredentials ImmutableCredentials { get; set; }

		IRequest Request { get; set; }

		bool IsSigned { get; set; }

		bool IsAsync { get; }

		int Retries { get; set; }

		CapacityManager.CapacityType LastCapacityType { get; set; }

		int EndpointDiscoveryRetries { get; set; }

		CancellationToken CancellationToken { get; }

		IServiceMetadata ServiceMetaData { get; }

		bool CSMEnabled { get; }

		bool IsLastExceptionRetryable { get; set; }
	}
	public interface IResponseContext
	{
		AmazonWebServiceResponse Response { get; set; }

		IWebResponseData HttpResponse { get; set; }
	}
	public interface IAsyncRequestContext : IRequestContext
	{
		AsyncCallback Callback { get; }

		object State { get; }
	}
	public interface IAsyncResponseContext : IResponseContext
	{
	}
	public interface IExecutionContext
	{
		IResponseContext ResponseContext { get; }

		IRequestContext RequestContext { get; }
	}
	public interface IAsyncExecutionContext
	{
		IAsyncResponseContext ResponseContext { get; }

		IAsyncRequestContext RequestContext { get; }

		object RuntimeState { get; set; }
	}
	public interface IPipelineHandler
	{
		ILogger Logger { get; set; }

		IPipelineHandler InnerHandler { get; set; }

		IPipelineHandler OuterHandler { get; set; }

		void InvokeSync(IExecutionContext executionContext);

		Task<T> InvokeAsync<T>(IExecutionContext executionContext) where T : AmazonWebServiceResponse, new();
	}
	public interface IExceptionHandler
	{
		bool Handle(IExecutionContext executionContext, Exception exception);
	}
	public interface IExceptionHandler<T> : IExceptionHandler where T : Exception
	{
		bool HandleException(IExecutionContext executionContext, T exception);
	}
	public interface IHttpRequestFactory<TRequestContent> : IDisposable
	{
		IHttpRequest<TRequestContent> CreateHttpRequest(System.Uri requestUri);
	}
	public interface IHttpRequest<TRequestContent> : IDisposable
	{
		string Method { get; set; }

		System.Uri RequestUri { get; }

		void ConfigureRequest(IRequestContext requestContext);

		void SetRequestHeaders(IDictionary<string, string> headers);

		TRequestContent GetRequestContent();

		IWebResponseData GetResponse();

		void WriteToRequestBody(TRequestContent requestContent, Stream contentStream, IDictionary<string, string> contentHeaders, IRequestContext requestContext);

		void WriteToRequestBody(TRequestContent requestContent, byte[] content, IDictionary<string, string> contentHeaders);

		Stream SetupProgressListeners(Stream originalStream, long progressUpdateInterval, object sender, EventHandler<StreamTransferProgressArgs> callback);

		void Abort();

		Task<TRequestContent> GetRequestContentAsync();

		Task<IWebResponseData> GetResponseAsync(CancellationToken cancellationToken);
	}
	[CLSCompliant(false)]
	public interface IHttpClientFactory
	{
		HttpClient CreateHttpClient(IClientConfig clientConfig);
	}
	[CLSCompliant(false)]
	public class HttpRequestMessageFactory : IHttpRequestFactory<HttpContent>, IDisposable
	{
		private static readonly ReaderWriterLockSlim _httpClientCacheRWLock = new ReaderWriterLockSlim();

		private static readonly IDictionary<string, HttpClientCache> _httpClientCaches = new Dictionary<string, HttpClientCache>();

		private HttpClientCache _httpClientCache;

		private bool _useGlobalHttpClientCache;

		private IClientConfig _clientConfig;

		public HttpRequestMessageFactory(IClientConfig clientConfig)
		{
			_clientConfig = clientConfig;
		}

		public IHttpRequest<HttpContent> CreateHttpRequest(System.Uri requestUri)
		{
			HttpClient httpClient = null;
			if (ClientConfig.CacheHttpClients(_clientConfig))
			{
				if (_httpClientCache == null)
				{
					if (!ClientConfig.UseGlobalHttpClientCache(_clientConfig))
					{
						_useGlobalHttpClientCache = false;
						_httpClientCacheRWLock.EnterWriteLock();
						try
						{
							if (_httpClientCache == null)
							{
								_httpClientCache = CreateHttpClientCache(_clientConfig);
							}
						}
						finally
						{
							_httpClientCacheRWLock.ExitWriteLock();
						}
					}
					else
					{
						_useGlobalHttpClientCache = true;
						string key = ClientConfig.CreateConfigUniqueString(_clientConfig);
						_httpClientCacheRWLock.EnterReadLock();
						try
						{
							_httpClientCaches.TryGetValue(key, out _httpClientCache);
						}
						finally
						{
							_httpClientCacheRWLock.ExitReadLock();
						}
						if (_httpClientCache == null)
						{
							_httpClientCacheRWLock.EnterWriteLock();
							try
							{
								if (!_httpClientCaches.TryGetValue(key, out _httpClientCache))
								{
									_httpClientCache = CreateHttpClientCache(_clientConfig);
									_httpClientCaches[key] = _httpClientCache;
								}
							}
							finally
							{
								_httpClientCacheRWLock.ExitWriteLock();
							}
						}
					}
				}
				httpClient = _httpClientCache.GetNextClient();
			}
			else
			{
				httpClient = CreateHttpClient(_clientConfig);
			}
			return new HttpWebRequestMessage(httpClient, requestUri, _clientConfig);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing && !_useGlobalHttpClientCache && _httpClientCache != null)
			{
				_httpClientCache.Dispose();
			}
		}

		private static HttpClientCache CreateHttpClientCache(IClientConfig clientConfig)
		{
			HttpClient[] array = new HttpClient[clientConfig.HttpClientCacheSize];
			for (int i = 0; i < array.Length; i = checked(i + 1))
			{
				array[i] = CreateHttpClient(clientConfig);
			}
			return new HttpClientCache(array);
		}

		private static HttpClient CreateHttpClient(IClientConfig clientConfig)
		{
			if (clientConfig.HttpClientFactory == null)
			{
				return CreateManagedHttpClient(clientConfig);
			}
			return clientConfig.HttpClientFactory.CreateHttpClient(clientConfig);
		}

		private static HttpClient CreateManagedHttpClient(IClientConfig clientConfig)
		{
			HttpClientHandler httpClientHandler = new HttpClientHandler();
			httpClientHandler.AllowAutoRedirect = clientConfig.AllowAutoRedirect;
			httpClientHandler.AutomaticDecompression = DecompressionMethods.None;
			IWebProxy webProxy = clientConfig.GetWebProxy();
			if (webProxy != null)
			{
				httpClientHandler.Proxy = webProxy;
			}
			if (httpClientHandler.Proxy != null && clientConfig.ProxyCredentials != null)
			{
				httpClientHandler.Proxy.Credentials = clientConfig.ProxyCredentials;
			}
			HttpClient httpClient = new HttpClient(httpClientHandler);
			if (clientConfig.Timeout.HasValue)
			{
				httpClient.Timeout = clientConfig.Timeout.Value;
			}
			return httpClient;
		}
	}
	public class HttpClientCache : IDisposable
	{
		private HttpClient[] _clients;

		private int count;

		public HttpClientCache(HttpClient[] clients)
		{
			_clients = clients;
		}

		public HttpClient GetNextClient()
		{
			if (_clients.Length == 1)
			{
				return _clients[0];
			}
			int num = Math.Abs(Interlocked.Increment(ref count) % _clients.Length);
			return _clients[num];
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing && _clients != null)
			{
				HttpClient[] clients = _clients;
				for (int i = 0; i < clients.Length; i++)
				{
					clients[i].Dispose();
				}
			}
		}
	}
	[CLSCompliant(false)]
	public class HttpWebRequestMessage : IHttpRequest<HttpContent>, IDisposable
	{
		private static HashSet<string> ContentHeaderNames = new HashSet<string> { "Content-Length", "Content-Type", "Content-Range", "Content-MD5", "Content-Encoding", "Content-Disposition", "Expires" };

		private bool _disposed;

		private HttpRequestMessage _request;

		private HttpClient _httpClient;

		private IClientConfig _clientConfig;

		public HttpClient HttpClient => _httpClient;

		public HttpRequestMessage Request => _request;

		public string Method
		{
			get
			{
				return _request.Method.Method;
			}
			set
			{
				_request.Method = new HttpMethod(value);
			}
		}

		public System.Uri RequestUri => _request.RequestUri;

		public HttpWebRequestMessage(HttpClient httpClient, System.Uri requestUri, IClientConfig config)
		{
			_clientConfig = config;
			_httpClient = httpClient;
			_request = new HttpRequestMessage();
			_request.RequestUri = requestUri;
		}

		public void ConfigureRequest(IRequestContext requestContext)
		{
			if (requestContext != null && requestContext.OriginalRequest != null)
			{
				_request.Headers.ExpectContinue = requestContext.OriginalRequest.GetExpect100Continue();
			}
		}

		public void SetRequestHeaders(IDictionary<string, string> headers)
		{
			foreach (KeyValuePair<string, string> header in headers)
			{
				if (!ContentHeaderNames.Contains(header.Key, StringComparer.OrdinalIgnoreCase))
				{
					_request.Headers.TryAddWithoutValidation(header.Key, header.Value);
				}
			}
		}

		public HttpContent GetRequestContent()
		{
			try
			{
				return GetRequestContentAsync().Result;
			}
			catch (AggregateException ex)
			{
				throw ex.InnerException;
			}
		}

		public IWebResponseData GetResponse()
		{
			try
			{
				return GetResponseAsync(CancellationToken.None).Result;
			}
			catch (AggregateException ex)
			{
				throw ex.InnerException;
			}
		}

		public void Abort()
		{
		}

		public async Task<IWebResponseData> GetResponseAsync(CancellationToken cancellationToken)
		{
			try
			{
				HttpResponseMessage httpResponseMessage = await _httpClient.SendAsync(_request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				bool disposeClient = ClientConfig.DisposeHttpClients(_clientConfig);
				if (!_clientConfig.AllowAutoRedirect && httpResponseMessage.StatusCode >= HttpStatusCode.MultipleChoices && httpResponseMessage.StatusCode < HttpStatusCode.BadRequest)
				{
					return new HttpClientResponseData(httpResponseMessage, _httpClient, disposeClient);
				}
				if (!httpResponseMessage.IsSuccessStatusCode)
				{
					throw new HttpErrorResponseException(new HttpClientResponseData(httpResponseMessage, _httpClient, disposeClient));
				}
				return new HttpClientResponseData(httpResponseMessage, _httpClient, disposeClient);
			}
			catch (HttpRequestException ex)
			{
				if (ex.InnerException != null)
				{
					if (ex.InnerException is IOException)
					{
						throw ex.InnerException;
					}
					if (ex.InnerException is WebException)
					{
						throw ex.InnerException;
					}
				}
				throw;
			}
			catch (System.OperationCanceledException ex2)
			{
				if (!cancellationToken.IsCancellationRequested && ex2.InnerException != null)
				{
					throw ex2.InnerException;
				}
				throw;
			}
		}

		public void WriteToRequestBody(HttpContent requestContent, Stream contentStream, IDictionary<string, string> contentHeaders, IRequestContext requestContext)
		{
			NonDisposingWrapperStream content = new NonDisposingWrapperStream(contentStream);
			_request.Content = new StreamContent(content, requestContext.ClientConfig.BufferSize);
			if (!(contentStream is ChunkedUploadWrapperStream { HasLength: false }))
			{
				_request.Content.Headers.ContentLength = contentStream.Length;
			}
			WriteContentHeaders(contentHeaders);
		}

		public void WriteToRequestBody(HttpContent requestContent, byte[] content, IDictionary<string, string> contentHeaders)
		{
			_request.Content = new ByteArrayContent(content);
			_request.Content.Headers.ContentLength = content.Length;
			WriteContentHeaders(contentHeaders);
		}

		public Task<HttpContent> GetRequestContentAsync()
		{
			return Task.FromResult(_request.Content);
		}

		private void WriteContentHeaders(IDictionary<string, string> contentHeaders)
		{
			_request.Content.Headers.ContentType = MediaTypeHeaderValue.Parse(contentHeaders["Content-Type"]);
			if (contentHeaders.ContainsKey("Content-Range"))
			{
				_request.Content.Headers.TryAddWithoutValidation("Content-Range", contentHeaders["Content-Range"]);
			}
			if (contentHeaders.ContainsKey("Content-MD5"))
			{
				_request.Content.Headers.TryAddWithoutValidation("Content-MD5", contentHeaders["Content-MD5"]);
			}
			if (contentHeaders.ContainsKey("Content-Encoding"))
			{
				_request.Content.Headers.TryAddWithoutValidation("Content-Encoding", contentHeaders["Content-Encoding"]);
			}
			if (contentHeaders.ContainsKey("Content-Disposition"))
			{
				_request.Content.Headers.TryAddWithoutValidation("Content-Disposition", contentHeaders["Content-Disposition"]);
			}
			if (contentHeaders.ContainsKey("Expires") && DateTime.TryParse(contentHeaders["Expires"], CultureInfo.InvariantCulture, DateTimeStyles.None, out var result))
			{
				_request.Content.Headers.Expires = result;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed && disposing)
			{
				if (_request != null)
				{
					_request.Dispose();
				}
				_disposed = true;
			}
		}

		public Stream SetupProgressListeners(Stream originalStream, long progressUpdateInterval, object sender, EventHandler<StreamTransferProgressArgs> callback)
		{
			EventStream eventStream = new EventStream(originalStream, disableClose: true);
			StreamReadTracker streamReadTracker = new StreamReadTracker(sender, callback, originalStream.Length, progressUpdateInterval);
			eventStream.OnRead += streamReadTracker.ReadProgress;
			return eventStream;
		}
	}
	public abstract class RetryPolicy
	{
		private static HashSet<string> clockSkewErrorCodes = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "RequestTimeTooSkewed", "RequestExpired", "InvalidSignatureException", "SignatureDoesNotMatch", "AuthFailure", "RequestExpired", "RequestInTheFuture" };

		private const string clockSkewMessageFormat = "Identified clock skew: local time = {0}, local time with correction = {1}, current clock skew correction = {2}, server time = {3}, service endpoint = {4}.";

		private const string clockSkewUpdatedFormat = "Setting clock skew correction: new clock skew correction = {0}, service endpoint = {1}.";

		private const string clockSkewMessageParen = "(";

		private const string clockSkewMessagePlusSeparator = " + ";

		private const string clockSkewMessageMinusSeparator = " - ";

		private static TimeSpan clockSkewMaxThreshold = TimeSpan.FromMinutes(5.0);

		public int MaxRetries { get; protected set; }

		public ILogger Logger { get; set; }

		public virtual ICollection<string> ThrottlingErrorCodes { get; protected set; } = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
		{
			"Throttling", "ThrottlingException", "ThrottledException", "RequestThrottledException", "TooManyRequestsException", "ProvisionedThroughputExceededException", "TransactionInProgressException", "RequestLimitExceeded", "BandwidthLimitExceeded", "LimitExceededException",
			"RequestThrottled", "SlowDown", "PriorRequestNotComplete"
		};

		public ICollection<string> TimeoutErrorCodesToRetryOn { get; protected set; } = new HashSet<string> { "RequestTimeout", "RequestTimeoutException" };

		public ICollection<string> ErrorCodesToRetryOn { get; protected set; } = new HashSet<string>();

		public ICollection<HttpStatusCode> HttpStatusCodesToRetryOn { get; protected set; } = new HashSet<HttpStatusCode>
		{
			HttpStatusCode.InternalServerError,
			HttpStatusCode.ServiceUnavailable,
			HttpStatusCode.BadGateway,
			HttpStatusCode.GatewayTimeout
		};

		public ICollection<WebExceptionStatus> WebExceptionStatusesToRetryOn { get; protected set; } = new HashSet<WebExceptionStatus>
		{
			WebExceptionStatus.ConnectFailure,
			WebExceptionStatus.ConnectionClosed,
			WebExceptionStatus.KeepAliveFailure,
			WebExceptionStatus.NameResolutionFailure,
			WebExceptionStatus.ReceiveFailure,
			WebExceptionStatus.SendFailure,
			WebExceptionStatus.Timeout
		};

		protected RetryCapacity RetryCapacity { get; set; }

		public bool Retry(IExecutionContext executionContext, Exception exception)
		{
			bool flag = !RetryLimitReached(executionContext) && CanRetry(executionContext);
			if (flag || executionContext.RequestContext.CSMEnabled)
			{
				bool flag2 = IsClockskew(executionContext, exception);
				if (flag2 || RetryForException(executionContext, exception))
				{
					executionContext.RequestContext.IsLastExceptionRetryable = true;
					if (!flag)
					{
						return false;
					}
					executionContext.RequestContext.LastCapacityType = ((!IsServiceTimeoutError(exception)) ? CapacityManager.CapacityType.Retry : CapacityManager.CapacityType.Timeout);
					return OnRetry(executionContext, flag2, IsThrottlingError(exception));
				}
			}
			return false;
		}

		public abstract bool CanRetry(IExecutionContext executionContext);

		public abstract bool RetryForException(IExecutionContext executionContext, Exception exception);

		public abstract bool RetryLimitReached(IExecutionContext executionContext);

		public abstract void WaitBeforeRetry(IExecutionContext executionContext);

		public virtual void NotifySuccess(IExecutionContext executionContext)
		{
		}

		public virtual bool OnRetry(IExecutionContext executionContext)
		{
			return true;
		}

		public virtual bool OnRetry(IExecutionContext executionContext, bool bypassAcquireCapacity)
		{
			return true;
		}

		public virtual bool OnRetry(IExecutionContext executionContext, bool bypassAcquireCapacity, bool isThrottlingError)
		{
			return OnRetry(executionContext, bypassAcquireCapacity);
		}

		public virtual void ObtainSendToken(IExecutionContext executionContext, Exception exception)
		{
		}

		public virtual bool IsThrottlingError(Exception exception)
		{
			AmazonServiceException ex = exception as AmazonServiceException;
			if (ex == null || ex.Retryable?.Throttling != true)
			{
				return ThrottlingErrorCodes.Contains(ex?.ErrorCode);
			}
			return true;
		}

		public virtual bool IsTransientError(IExecutionContext executionContext, Exception exception)
		{
			if (exception is IOException)
			{
				return true;
			}
			if (ExceptionUtils.IsInnerException<IOException>(exception))
			{
				return true;
			}
			if (exception is AmazonServiceException ex)
			{
				if (ex.Retryable != null)
				{
					return true;
				}
				if (HttpStatusCodesToRetryOn.Contains(ex.StatusCode) && !IsThrottlingError(exception))
				{
					return true;
				}
				if (ex.StatusCode == HttpStatusCode.OK && ex is AmazonUnmarshallingException)
				{
					return true;
				}
			}
			if (ExceptionUtils.IsInnerException<WebException>(exception, out var inner) && WebExceptionStatusesToRetryOn.Contains(inner.Status))
			{
				return true;
			}
			return false;
		}

		public virtual bool IsServiceTimeoutError(Exception exception)
		{
			return TimeoutErrorCodesToRetryOn.Contains((exception as AmazonServiceException)?.ErrorCode);
		}

		private bool IsClockskew(IExecutionContext executionContext, Exception exception)
		{
			IClientConfig clientConfig = executionContext.RequestContext.ClientConfig;
			AmazonServiceException ex = exception as AmazonServiceException;
			bool num = executionContext.RequestContext.Request != null && string.Equals(executionContext.RequestContext.Request.HttpMethod, "HEAD", StringComparison.Ordinal);
			bool flag = ex != null && (ex.ErrorCode == null || clockSkewErrorCodes.Contains(ex.ErrorCode));
			if (num || flag)
			{
				string text = executionContext.RequestContext.Request.Endpoint.ToString();
				DateTime dateTime = AWSConfigs.utcNowSource();
				DateTime correctedUtcNowForEndpoint = CorrectClockSkew.GetCorrectedUtcNowForEndpoint(text);
				DateTime serverTime;
				bool flag2 = TryParseDateHeader(ex, out serverTime);
				if (!flag2)
				{
					flag2 = TryParseExceptionMessage(ex, out serverTime);
				}
				if (flag2)
				{
					serverTime = serverTime.ToUniversalTime();
					TimeSpan timeSpan = correctedUtcNowForEndpoint - serverTime;
					if (((timeSpan.Ticks < 0) ? (-timeSpan) : timeSpan) > clockSkewMaxThreshold)
					{
						TimeSpan timeSpan2 = serverTime - dateTime;
						Logger.InfoFormat("Identified clock skew: local time = {0}, local time with correction = {1}, current clock skew correction = {2}, server time = {3}, service endpoint = {4}.", dateTime, correctedUtcNowForEndpoint, clientConfig.ClockOffset, serverTime, text);
						CorrectClockSkew.SetClockCorrectionForEndpoint(text, timeSpan2);
						if (AWSConfigs.CorrectForClockSkew && !AWSConfigs.ManualClockCorrection.HasValue)
						{
							Logger.InfoFormat("Setting clock skew correction: new clock skew correction = {0}, service endpoint = {1}.", timeSpan2, text);
							executionContext.RequestContext.IsSigned = false;
							return true;
						}
					}
				}
			}
			return false;
		}

		private static bool TryParseDateHeader(AmazonServiceException ase, out DateTime serverTime)
		{
			IWebResponseData webData = GetWebData(ase);
			if (webData != null)
			{
				string headerValue = webData.GetHeaderValue("Date");
				if (!string.IsNullOrEmpty(headerValue) && DateTime.TryParseExact(headerValue, "ddd, dd MMM yyyy HH:mm:ss \\G\\M\\T", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out serverTime))
				{
					return true;
				}
			}
			serverTime = DateTime.MinValue;
			return false;
		}

		private static bool TryParseExceptionMessage(AmazonServiceException ase, out DateTime serverTime)
		{
			checked
			{
				if (ase != null && !string.IsNullOrEmpty(ase.Message))
				{
					string message = ase.Message;
					int num = message.IndexOf("(", StringComparison.Ordinal);
					if (num >= 0)
					{
						num++;
						int num2 = message.IndexOf(" + ", num, StringComparison.Ordinal);
						if (num2 < 0)
						{
							num2 = message.IndexOf(" - ", num, StringComparison.Ordinal);
						}
						if (num2 > num && DateTime.TryParseExact(message.Substring(num, num2 - num), "yyyyMMddTHHmmssZ", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out serverTime))
						{
							return true;
						}
					}
				}
				serverTime = DateTime.MinValue;
				return false;
			}
		}

		private static IWebResponseData GetWebData(AmazonServiceException ase)
		{
			if (ase != null)
			{
				Exception ex = ase;
				do
				{
					if (ex is HttpErrorResponseException ex2)
					{
						return ex2.Response;
					}
					ex = ex.InnerException;
				}
				while (ex != null);
			}
			return null;
		}

		protected static bool ContainErrorMessage(Exception exception, HashSet<string> errorMessages)
		{
			if (exception == null)
			{
				return false;
			}
			if (errorMessages.Contains(exception.Message))
			{
				return true;
			}
			return ContainErrorMessage(exception.InnerException, errorMessages);
		}

		public async Task<bool> RetryAsync(IExecutionContext executionContext, Exception exception)
		{
			bool canRetry = !RetryLimitReached(executionContext) && CanRetry(executionContext);
			if (canRetry || executionContext.RequestContext.CSMEnabled)
			{
				bool isClockSkewError = IsClockskew(executionContext, exception);
				bool flag = isClockSkewError;
				if (!flag)
				{
					flag = await RetryForExceptionAsync(executionContext, exception).ConfigureAwait(continueOnCapturedContext: false);
				}
				if (flag)
				{
					executionContext.RequestContext.IsLastExceptionRetryable = true;
					if (!canRetry)
					{
						return false;
					}
					return OnRetry(executionContext, isClockSkewError, IsThrottlingError(exception));
				}
			}
			return false;
		}

		public virtual Task ObtainSendTokenAsync(IExecutionContext executionContext, Exception exception)
		{
			return Task.FromResult(0);
		}

		public abstract Task<bool> RetryForExceptionAsync(IExecutionContext executionContext, Exception exception);

		public abstract Task WaitBeforeRetryAsync(IExecutionContext executionContext);
	}
}
namespace Amazon.Runtime.SharedInterfaces
{
	public interface ICoreAmazonKMS : IDisposable
	{
		GenerateDataKeyResult GenerateDataKey(string keyID, Dictionary<string, string> encryptionContext, string keySpec);

		byte[] Decrypt(byte[] ciphertextBlob, Dictionary<string, string> encryptionContext);

		Task<GenerateDataKeyResult> GenerateDataKeyAsync(string keyID, Dictionary<string, string> encryptionContext, string keySpec);

		Task<byte[]> DecryptAsync(byte[] ciphertextBlob, Dictionary<string, string> encryptionContext);
	}
	public class GenerateDataKeyResult
	{
		public byte[] KeyPlaintext { get; set; }

		public byte[] KeyCiphertext { get; set; }
	}
	public interface ICoreAmazonS3
	{
		string GeneratePreSignedURL(string bucketName, string objectKey, DateTime expiration, IDictionary<string, object> additionalProperties);

		Task<IList<string>> GetAllObjectKeysAsync(string bucketName, string prefix, IDictionary<string, object> additionalProperties);

		Task UploadObjectFromStreamAsync(string bucketName, string objectKey, Stream stream, IDictionary<string, object> additionalProperties, CancellationToken cancellationToken = default(CancellationToken));

		Task DeleteAsync(string bucketName, string objectKey, IDictionary<string, object> additionalProperties, CancellationToken cancellationToken = default(CancellationToken));

		Task DeletesAsync(string bucketName, IEnumerable<string> objectKeys, IDictionary<string, object> additionalProperties, CancellationToken cancellationToken = default(CancellationToken));

		Task<Stream> GetObjectStreamAsync(string bucketName, string objectKey, IDictionary<string, object> additionalProperties, CancellationToken cancellationToken = default(CancellationToken));

		Task UploadObjectFromFilePathAsync(string bucketName, string objectKey, string filepath, IDictionary<string, object> additionalProperties, CancellationToken cancellationToken = default(CancellationToken));

		Task DownloadToFilePathAsync(string bucketName, string objectKey, string filepath, IDictionary<string, object> additionalProperties, CancellationToken cancellationToken = default(CancellationToken));

		Task MakeObjectPublicAsync(string bucketName, string objectKey, bool enable);

		Task EnsureBucketExistsAsync(string bucketName);

		Task<bool> DoesS3BucketExistAsync(string bucketName);
	}
	public interface ICoreAmazonSQS
	{
		Task<Dictionary<string, string>> GetAttributesAsync(string queueUrl);

		Task SetAttributesAsync(string queueUrl, Dictionary<string, string> attributes);
	}
	public interface ICoreAmazonSTS
	{
		AssumeRoleImmutableCredentials CredentialsFromAssumeRoleAuthentication(string roleArn, string roleSessionName, AssumeRoleAWSCredentialsOptions options);
	}
}
namespace Amazon.Runtime.SharedInterfaces.Internal
{
	public class CoreAmazonKMS : ICoreAmazonKMS, IDisposable
	{
		private object wrappedClientLock = new object();

		private ICoreAmazonKMS wrappedClient;

		private AmazonServiceClient existingClient;

		private string feature;

		private bool disposed;

		public CoreAmazonKMS(AmazonServiceClient existingClient, string feature)
		{
			this.existingClient = existingClient;
			this.feature = feature;
		}

		public byte[] Decrypt(byte[] ciphertextBlob, Dictionary<string, string> encryptionContext)
		{
			EnsureWrappedClientIsInstantiated();
			return wrappedClient.Decrypt(ciphertextBlob, encryptionContext);
		}

		public GenerateDataKeyResult GenerateDataKey(string keyID, Dictionary<string, string> encryptionContext, string keySpec)
		{
			EnsureWrappedClientIsInstantiated();
			return wrappedClient.GenerateDataKey(keyID, encryptionContext, keySpec);
		}

		public async Task<byte[]> DecryptAsync(byte[] ciphertextBlob, Dictionary<string, string> encryptionContext)
		{
			EnsureWrappedClientIsInstantiated();
			return await wrappedClient.DecryptAsync(ciphertextBlob, encryptionContext).ConfigureAwait(continueOnCapturedContext: false);
		}

		public async Task<GenerateDataKeyResult> GenerateDataKeyAsync(string keyID, Dictionary<string, string> encryptionContext, string keySpec)
		{
			EnsureWrappedClientIsInstantiated();
			return await wrappedClient.GenerateDataKeyAsync(keyID, encryptionContext, keySpec).ConfigureAwait(continueOnCapturedContext: false);
		}

		private void EnsureWrappedClientIsInstantiated()
		{
			if (wrappedClient != null)
			{
				return;
			}
			lock (wrappedClientLock)
			{
				if (wrappedClient == null)
				{
					wrappedClient = CreateFromExistingClient(existingClient, feature);
				}
			}
		}

		private static ICoreAmazonKMS CreateFromExistingClient(AmazonServiceClient existingClient, string feature)
		{
			ICoreAmazonKMS coreAmazonKMS = null;
			try
			{
				return ServiceClientHelpers.CreateServiceFromAssembly<ICoreAmazonKMS>("AWSSDK.KeyManagementService", "Amazon.KeyManagementService.AmazonKeyManagementServiceClient", existingClient);
			}
			catch (Exception innerException)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, "Error instantiating {0} from assembly {1}.  The assembly and class must be available at runtime in order to use {2}.", "Amazon.KeyManagementService.AmazonKeyManagementServiceClient", "AWSSDK.KeyManagementService", feature), innerException);
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposed || !disposing)
			{
				return;
			}
			lock (wrappedClientLock)
			{
				if (wrappedClient != null)
				{
					wrappedClient.Dispose();
					wrappedClient = null;
				}
			}
			disposed = true;
		}
	}
}
namespace Amazon.Runtime.EventStreams
{
	public sealed class EventStreamErrorCodeException : EventStreamException
	{
		public int ErrorCode
		{
			get
			{
				return (int)Data["ErrorCode"];
			}
			private set
			{
				Data["ErrorCode"] = value;
			}
		}

		public EventStreamErrorCodeException(int errorCode)
			: this(errorCode, null)
		{
		}

		public EventStreamErrorCodeException(int errorCode, string message)
			: base(message)
		{
			ErrorCode = errorCode;
		}
	}
	public class EventStreamEventReceivedArgs<T> : EventArgs where T : IEventStreamEvent
	{
		public T EventStreamEvent { get; }

		public EventStreamEventReceivedArgs(T eventStreamEvent)
		{
			EventStreamEvent = eventStreamEvent;
		}
	}
	public class EventStreamExceptionReceivedArgs<T> : EventArgs where T : EventStreamException
	{
		public T EventStreamException { get; }

		public EventStreamExceptionReceivedArgs(T eventStreamException)
		{
			EventStreamException = eventStreamException;
		}
	}
	public enum EventStreamHeaderType : byte
	{
		BoolTrue,
		BoolFalse,
		Byte,
		Int16,
		Int32,
		Int64,
		ByteBuf,
		String,
		Timestamp,
		UUID
	}
	public interface IEventStreamHeader
	{
		string Name { get; }

		EventStreamHeaderType HeaderType { get; }

		int GetWireSize();

		int WriteToBuffer(byte[] buffer, int offset);

		bool AsBool();

		void SetBool(bool value);

		byte AsByte();

		void SetByte(byte value);

		short AsInt16();

		void SetInt16(short value);

		int AsInt32();

		void SetInt32(int value);

		long AsInt64();

		void SetInt64(long value);

		byte[] AsByteBuf();

		void SetByteBuf(byte[] value);

		string AsString();

		void SetString(string value);

		DateTime AsTimestamp();

		void SetTimestamp(DateTime value);

		Guid AsUUID();

		void SetUUID(Guid value);
	}
	public class EventStreamHeader : IEventStreamHeader
	{
		private static readonly DateTime _unixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		private const int _sizeOfByte = 1;

		private const int _sizeOfInt16 = 2;

		private const int _sizeOfInt32 = 4;

		private const int _sizeOfInt64 = 8;

		private const int _sizeOfGuid = 16;

		public string Name { get; }

		public EventStreamHeaderType HeaderType { get; set; }

		private object HeaderValue { get; set; }

		public EventStreamHeader(string name)
		{
			Name = name;
		}

		public static EventStreamHeader FromBuffer(byte[] buffer, int offset, ref int newOffset)
		{
			newOffset = offset;
			EventStreamHeader eventStreamHeader;
			checked
			{
				byte b = buffer[newOffset++];
				eventStreamHeader = new EventStreamHeader(Encoding.UTF8.GetString(buffer, newOffset, b));
				newOffset += b;
			}
			eventStreamHeader.HeaderType = (EventStreamHeaderType)buffer[checked(newOffset++)];
			short num = 0;
			checked
			{
				switch (eventStreamHeader.HeaderType)
				{
				case EventStreamHeaderType.BoolTrue:
					eventStreamHeader.HeaderValue = true;
					break;
				case EventStreamHeaderType.BoolFalse:
					eventStreamHeader.HeaderValue = false;
					break;
				case EventStreamHeaderType.Byte:
					eventStreamHeader.HeaderValue = buffer[newOffset];
					newOffset++;
					break;
				case EventStreamHeaderType.Int16:
					eventStreamHeader.HeaderValue = EndianConversionUtility.NetworkToHostOrder(BitConverter.ToInt16(buffer, newOffset));
					newOffset += 2;
					break;
				case EventStreamHeaderType.Int32:
					eventStreamHeader.HeaderValue = EndianConversionUtility.NetworkToHostOrder(BitConverter.ToInt32(buffer, newOffset));
					newOffset += 4;
					break;
				case EventStreamHeaderType.Int64:
					eventStreamHeader.HeaderValue = EndianConversionUtility.NetworkToHostOrder(BitConverter.ToInt64(buffer, newOffset));
					newOffset += 8;
					break;
				case EventStreamHeaderType.ByteBuf:
					num = EndianConversionUtility.NetworkToHostOrder(BitConverter.ToInt16(buffer, newOffset));
					newOffset += 2;
					eventStreamHeader.HeaderValue = new byte[num];
					Buffer.BlockCopy(buffer, newOffset, eventStreamHeader.HeaderValue as byte[], 0, num);
					newOffset += num;
					break;
				case EventStreamHeaderType.String:
					num = EndianConversionUtility.NetworkToHostOrder(BitConverter.ToInt16(buffer, newOffset));
					newOffset += 2;
					eventStreamHeader.HeaderValue = Encoding.UTF8.GetString(buffer, newOffset, num);
					newOffset += num;
					break;
				case EventStreamHeaderType.Timestamp:
				{
					long num2 = EndianConversionUtility.NetworkToHostOrder(BitConverter.ToInt64(buffer, newOffset));
					newOffset += 8;
					DateTime unixEpoch = _unixEpoch;
					eventStreamHeader.HeaderValue = unixEpoch.AddMilliseconds(num2);
					break;
				}
				case EventStreamHeaderType.UUID:
				{
					byte[] array = new byte[16];
					num = 16;
					Buffer.BlockCopy(buffer, newOffset, array, 0, num);
					newOffset += num;
					eventStreamHeader.HeaderValue = new Guid(array);
					break;
				}
				default:
					throw new EventStreamParseException(string.Format(CultureInfo.InvariantCulture, "Header Type: {0} is an unknown type.", eventStreamHeader.HeaderType));
				}
				return eventStreamHeader;
			}
		}

		public int WriteToBuffer(byte[] buffer, int offset)
		{
			int num = offset;
			checked
			{
				buffer[num++] = (byte)Name.Length;
				Buffer.BlockCopy(Encoding.UTF8.GetBytes(Name), 0, buffer, num, Name.Length);
				num += Name.Length;
				buffer[num++] = unchecked((byte)HeaderType);
				byte[] array = null;
				int num2 = 0;
				switch (HeaderType)
				{
				case EventStreamHeaderType.Byte:
					buffer[num++] = (byte)HeaderValue;
					break;
				case EventStreamHeaderType.Int16:
					array = BitConverter.GetBytes(EndianConversionUtility.HostToNetworkOrder((short)HeaderValue));
					Buffer.BlockCopy(array, 0, buffer, num, 2);
					num += 2;
					break;
				case EventStreamHeaderType.Int32:
					array = BitConverter.GetBytes(EndianConversionUtility.HostToNetworkOrder((int)HeaderValue));
					Buffer.BlockCopy(array, 0, buffer, num, 4);
					num += 4;
					break;
				case EventStreamHeaderType.Int64:
					array = BitConverter.GetBytes(EndianConversionUtility.HostToNetworkOrder((long)HeaderValue));
					Buffer.BlockCopy(array, 0, buffer, num, 8);
					num += 8;
					break;
				case EventStreamHeaderType.ByteBuf:
					array = HeaderValue as byte[];
					num2 = array.Length;
					Buffer.BlockCopy(BitConverter.GetBytes(EndianConversionUtility.HostToNetworkOrder((short)num2)), 0, buffer, num, 2);
					num += 2;
					Buffer.BlockCopy(array, 0, buffer, num, num2);
					num += num2;
					break;
				case EventStreamHeaderType.String:
					array = Encoding.UTF8.GetBytes(HeaderValue as string);
					num2 = array.Length;
					Buffer.BlockCopy(BitConverter.GetBytes(EndianConversionUtility.HostToNetworkOrder((short)num2)), 0, buffer, num, 2);
					num += 2;
					Buffer.BlockCopy(array, 0, buffer, num, num2);
					num += num2;
					break;
				case EventStreamHeaderType.Timestamp:
					array = BitConverter.GetBytes(EndianConversionUtility.HostToNetworkOrder((long)((DateTime)HeaderValue).Subtract(_unixEpoch).TotalMilliseconds));
					Buffer.BlockCopy(array, 0, buffer, num, 8);
					num += 8;
					break;
				case EventStreamHeaderType.UUID:
					array = ((Guid)HeaderValue).ToByteArray();
					Buffer.BlockCopy(array, 0, buffer, num, array.Length);
					num += array.Length;
					break;
				default:
					throw new EventStreamParseException(string.Format(CultureInfo.InvariantCulture, "Header Type: {0} is an unknown type.", HeaderType));
				case EventStreamHeaderType.BoolTrue:
				case EventStreamHeaderType.BoolFalse:
					break;
				}
				return num;
			}
		}

		public int GetWireSize()
		{
			checked
			{
				int num = 1 + Name.Length + 1;
				switch (HeaderType)
				{
				case EventStreamHeaderType.Byte:
					num++;
					break;
				case EventStreamHeaderType.Int16:
					num += 2;
					break;
				case EventStreamHeaderType.Int32:
					num += 4;
					break;
				case EventStreamHeaderType.Int64:
					num += 8;
					break;
				case EventStreamHeaderType.ByteBuf:
				{
					byte[] array = HeaderValue as byte[];
					num += 2 + array.Length;
					break;
				}
				case EventStreamHeaderType.String:
				{
					int num2 = Encoding.UTF8.GetBytes(HeaderValue as string).Length;
					num += 2 + num2;
					break;
				}
				case EventStreamHeaderType.Timestamp:
					num += 8;
					break;
				case EventStreamHeaderType.UUID:
					num += 16;
					break;
				default:
					throw new EventStreamParseException(string.Format(CultureInfo.InvariantCulture, "Header Type: {0} is an unknown type.", HeaderType));
				case EventStreamHeaderType.BoolTrue:
				case EventStreamHeaderType.BoolFalse:
					break;
				}
				return num;
			}
		}

		public bool AsBool()
		{
			return HeaderType == EventStreamHeaderType.BoolTrue;
		}

		public void SetBool(bool value)
		{
			HeaderValue = value;
			HeaderType = ((!value) ? EventStreamHeaderType.BoolFalse : EventStreamHeaderType.BoolTrue);
		}

		public byte AsByte()
		{
			return (byte)HeaderValue;
		}

		public void SetByte(byte value)
		{
			HeaderValue = value;
			HeaderType = EventStreamHeaderType.Byte;
		}

		public short AsInt16()
		{
			return (short)HeaderValue;
		}

		public void SetInt16(short value)
		{
			HeaderValue = value;
			HeaderType = EventStreamHeaderType.Int16;
		}

		public int AsInt32()
		{
			return (int)HeaderValue;
		}

		public void SetInt32(int value)
		{
			HeaderValue = value;
			HeaderType = EventStreamHeaderType.Int32;
		}

		public long AsInt64()
		{
			return (long)HeaderValue;
		}

		public void SetInt64(long value)
		{
			HeaderValue = value;
			HeaderType = EventStreamHeaderType.Int64;
		}

		public byte[] AsByteBuf()
		{
			return HeaderValue as byte[];
		}

		public void SetByteBuf(byte[] value)
		{
			HeaderValue = value;
			HeaderType = EventStreamHeaderType.ByteBuf;
		}

		public string AsString()
		{
			return HeaderValue as string;
		}

		public void SetString(string value)
		{
			HeaderValue = value;
			HeaderType = EventStreamHeaderType.String;
		}

		public DateTime AsTimestamp()
		{
			return (DateTime)HeaderValue;
		}

		public void SetTimestamp(DateTime value)
		{
			HeaderValue = value;
			HeaderType = EventStreamHeaderType.Timestamp;
		}

		public Guid AsUUID()
		{
			return (Guid)HeaderValue;
		}

		public void SetUUID(Guid value)
		{
			HeaderValue = value;
			HeaderType = EventStreamHeaderType.UUID;
		}
	}
	public class EventStreamParseException : Exception
	{
		public EventStreamParseException(string message)
			: base(message)
		{
		}
	}
	public class EventStreamChecksumFailureException : Exception
	{
		public EventStreamChecksumFailureException(string message)
			: base(message)
		{
		}
	}
	public interface IEventStreamMessage
	{
		Dictionary<string, IEventStreamHeader> Headers { get; set; }

		byte[] Payload { get; set; }

		byte[] ToByteArray();
	}
	public class EventStreamMessage : IEventStreamMessage
	{
		internal const int SizeOfInt32 = 4;

		internal const int PreludeLen = 12;

		internal const int TrailerLen = 4;

		internal const int FramingSize = 16;

		public const string ContentType = "vnd.amazon.eventstream";

		public Dictionary<string, IEventStreamHeader> Headers { get; set; }

		public byte[] Payload { get; set; }

		private EventStreamMessage()
		{
		}

		public EventStreamMessage(List<IEventStreamHeader> headers, byte[] payload)
		{
			Headers = new Dictionary<string, IEventStreamHeader>(headers.Count, StringComparer.Ordinal);
			foreach (IEventStreamHeader header in headers)
			{
				Headers.Add(header.Name, header);
			}
			Payload = payload;
		}

		public static EventStreamMessage FromBuffer(byte[] buffer, int offset, int length)
		{
			int num = offset;
			int network = BitConverter.ToInt32(buffer, num);
			network = EndianConversionUtility.NetworkToHostOrder(network);
			checked
			{
				num += 4;
				int network2 = BitConverter.ToInt32(buffer, num);
				network2 = EndianConversionUtility.NetworkToHostOrder(network2);
				num += 4;
				int network3 = BitConverter.ToInt32(buffer, num);
				network3 = EndianConversionUtility.NetworkToHostOrder(network3);
				EventStreamMessage eventStreamMessage = new EventStreamMessage();
				eventStreamMessage.Headers = new Dictionary<string, IEventStreamHeader>(StringComparer.Ordinal);
				using NullStream stream = new NullStream();
				using CrcCalculatorStream crcCalculatorStream = new CrcCalculatorStream(stream);
				crcCalculatorStream.Write(buffer, offset, num - offset);
				if (network3 != crcCalculatorStream.Crc32)
				{
					throw new EventStreamChecksumFailureException(string.Format(CultureInfo.InvariantCulture, "Message Prelude Checksum failure. Expected {0} but was {1}", network3, crcCalculatorStream.Crc32));
				}
				if (network != length)
				{
					throw new EventStreamChecksumFailureException(string.Format(CultureInfo.InvariantCulture, "Message Total Length didn't match the passed in length. Expected {0} but was {1}", length, network));
				}
				crcCalculatorStream.Write(buffer, num, 4);
				num += 4;
				int num2 = network - network2 - 16;
				if (network2 > 0)
				{
					int num3 = num;
					while (num - 12 < network2)
					{
						EventStreamHeader eventStreamHeader = EventStreamHeader.FromBuffer(buffer, num, ref num);
						eventStreamMessage.Headers.Add(eventStreamHeader.Name, eventStreamHeader);
					}
					crcCalculatorStream.Write(buffer, num3, num - num3);
				}
				eventStreamMessage.Payload = new byte[num2];
				Buffer.BlockCopy(buffer, num, eventStreamMessage.Payload, 0, eventStreamMessage.Payload.Length);
				crcCalculatorStream.Write(buffer, num, eventStreamMessage.Payload.Length);
				num += eventStreamMessage.Payload.Length;
				int network4 = BitConverter.ToInt32(buffer, num);
				network4 = EndianConversionUtility.NetworkToHostOrder(network4);
				if (network4 != crcCalculatorStream.Crc32)
				{
					throw new EventStreamChecksumFailureException(string.Format(CultureInfo.InvariantCulture, "Message Checksum failure. Expected {0} but was {1}", network4, crcCalculatorStream.Crc32));
				}
				return eventStreamMessage;
			}
		}

		public byte[] ToByteArray()
		{
			int num = 0;
			checked
			{
				if (Headers != null)
				{
					foreach (KeyValuePair<string, IEventStreamHeader> header in Headers)
					{
						num += header.Value.GetWireSize();
					}
				}
				byte[] payload = Payload;
				int num2 = ((payload != null) ? payload.Length : 0);
				int num3 = num + num2 + 16;
				byte[] array = new byte[num3];
				int num4 = 0;
				Buffer.BlockCopy(BitConverter.GetBytes(EndianConversionUtility.HostToNetworkOrder(num3)), 0, array, num4, 4);
				num4 += 4;
				Buffer.BlockCopy(BitConverter.GetBytes(EndianConversionUtility.HostToNetworkOrder(num)), 0, array, num4, 4);
				num4 += 4;
				using NullStream stream = new NullStream();
				using CrcCalculatorStream crcCalculatorStream = new CrcCalculatorStream(stream);
				crcCalculatorStream.Write(array, 0, num4);
				Buffer.BlockCopy(BitConverter.GetBytes(EndianConversionUtility.HostToNetworkOrder(crcCalculatorStream.Crc32)), 0, array, num4, 4);
				crcCalculatorStream.Write(array, num4, 4);
				num4 += 4;
				if (Headers != null)
				{
					foreach (KeyValuePair<string, IEventStreamHeader> header2 in Headers)
					{
						num4 = header2.Value.WriteToBuffer(array, num4);
					}
					crcCalculatorStream.Write(array, 12, num4 - 12);
				}
				if (Payload != null)
				{
					Buffer.BlockCopy(Payload, 0, array, num4, Payload.Length);
					crcCalculatorStream.Write(array, num4, Payload.Length);
					num4 += Payload.Length;
				}
				Buffer.BlockCopy(BitConverter.GetBytes(EndianConversionUtility.HostToNetworkOrder(crcCalculatorStream.Crc32)), 0, array, num4, 4);
				return array;
			}
		}
	}
	public sealed class EventStreamValidationException : Exception
	{
		public EventStreamValidationException()
		{
		}

		public EventStreamValidationException(string message)
			: base(message)
		{
		}

		public EventStreamValidationException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
	public sealed class UnknownEventStreamException : EventStreamException
	{
		public string ExceptionType
		{
			get
			{
				return Data["ExceptionType"].ToString();
			}
			private set
			{
				Data["ExceptionType"] = value;
			}
		}

		public UnknownEventStreamException(string exceptionType)
		{
			ExceptionType = exceptionType;
		}
	}
	public sealed class UnknownEventStreamMessageTypeException : Exception
	{
	}
}
namespace Amazon.Runtime.EventStreams.Internal
{
	public interface IEnumerableEventStream<T, TE> : IEventStream<T, TE>, IDisposable, IEnumerable<T>, IEnumerable where T : IEventStreamEvent where TE : EventStreamException, new()
	{
	}
	public abstract class EnumerableEventStream<T, TE> : EventStream<T, TE>, IEnumerableEventStream<T, TE>, IEventStream<T, TE>, IDisposable, IEnumerable<T>, IEnumerable where T : IEventStreamEvent where TE : EventStreamException, new()
	{
		private const string MutuallyExclusiveExceptionMessage = "Stream has already begun processing. Event-driven and Enumerable traversals of the stream are mutually exclusive. You can either use the event driven or enumerable interface, but not both.";

		protected bool IsEnumerated { get; set; }

		protected EnumerableEventStream(Stream stream)
			: this(stream, (IEventStreamDecoder)null)
		{
		}

		protected EnumerableEventStream(Stream stream, IEventStreamDecoder eventStreamDecoder)
			: base(stream, eventStreamDecoder)
		{
		}

		public IEnumerator<T> GetEnumerator()
		{
			if (IsProcessing)
			{
				throw new InvalidOperationException("Stream has already begun processing. Event-driven and Enumerable traversals of the stream are mutually exclusive. You can either use the event driven or enumerable interface, but not both.");
			}
			Queue<T> events = new Queue<T>();
			IsEnumerated = true;
			IsProcessing = true;
			EventReceived += delegate(object sender, EventStreamEventReceivedArgs<T> args)
			{
				events.Enqueue(args.EventStreamEvent);
			};
			byte[] buffer = new byte[BufferSize];
			while (IsProcessing)
			{
				if (events.Count > 0)
				{
					T val = events.Dequeue();
					if (val is IEventStreamTerminalEvent)
					{
						IsProcessing = false;
						Dispose();
					}
					yield return val;
				}
				else
				{
					try
					{
						ReadFromStream(buffer);
					}
					catch (Exception ex)
					{
						IsProcessing = false;
						Dispose();
						throw WrapException(ex);
					}
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public override void StartProcessing()
		{
			if (IsEnumerated)
			{
				throw new InvalidOperationException("Stream has already begun processing. Event-driven and Enumerable traversals of the stream are mutually exclusive. You can either use the event driven or enumerable interface, but not both.");
			}
			base.StartProcessing();
		}
	}
	public interface IEventStream<T, TE> : IDisposable where T : IEventStreamEvent where TE : EventStreamException, new()
	{
		int BufferSize { get; set; }

		event EventHandler<EventStreamEventReceivedArgs<T>> EventReceived;

		event EventHandler<EventStreamExceptionReceivedArgs<TE>> ExceptionReceived;

		void StartProcessing();
	}
	public abstract class EventStream<T, TE> : IEventStream<T, TE>, IDisposable where T : IEventStreamEvent where TE : EventStreamException, new()
	{
		protected const string UnknownEventKey = "===UNKNOWN===";

		private const string HeaderMessageType = ":message-type";

		private const string HeaderEventType = ":event-type";

		private const string HeaderExceptionType = ":exception-type";

		private const string HeaderErrorCode = ":error-code";

		private const string HeaderErrorMessage = ":error-message";

		private const string EventHeaderMessageTypeValue = "event";

		private const string ExceptionHeaderMessageTypeValue = "exception";

		private const string ErrorHeaderMessageTypeValue = "error";

		private const string WrappedErrorMessage = "Error.";

		private bool _disposed;

		public int BufferSize { get; set; } = 8192;

		protected Stream NetworkStream { get; }

		protected IEventStreamDecoder Decoder { get; }

		protected abstract IDictionary<string, Func<IEventStreamMessage, T>> EventMapping { get; }

		protected abstract IDictionary<string, Func<IEventStreamMessage, TE>> ExceptionMapping { get; }

		protected abstract bool IsProcessing { get; set; }

		public virtual event EventHandler<EventStreamEventReceivedArgs<T>> EventReceived;

		public virtual event EventHandler<EventStreamExceptionReceivedArgs<TE>> ExceptionReceived;

		protected EventStream(Stream stream)
			: this(stream, (IEventStreamDecoder)null)
		{
		}

		protected EventStream(Stream stream, IEventStreamDecoder eventStreamDecoder)
		{
			NetworkStream = stream;
			Decoder = eventStreamDecoder ?? new EventStreamDecoder();
		}

		protected T ConvertMessageToEvent(EventStreamMessage eventStreamMessage)
		{
			Dictionary<string, IEventStreamHeader> headers = eventStreamMessage.Headers;
			string text;
			try
			{
				text = headers[":message-type"].AsString();
			}
			catch (KeyNotFoundException innerException)
			{
				throw new EventStreamValidationException("Message type missing from event stream message.", innerException);
			}
			switch (text)
			{
			case "event":
			{
				string key;
				try
				{
					key = headers[":event-type"].AsString();
				}
				catch (KeyNotFoundException innerException3)
				{
					throw new EventStreamValidationException("Event Type not defined for event.", innerException3);
				}
				try
				{
					return EventMapping[key](eventStreamMessage);
				}
				catch (KeyNotFoundException)
				{
					return EventMapping["===UNKNOWN==="](eventStreamMessage);
				}
			}
			case "exception":
			{
				string text2;
				try
				{
					text2 = headers[":exception-type"].AsString();
				}
				catch (KeyNotFoundException innerException4)
				{
					throw new EventStreamValidationException("Exception Type not defined for exception.", innerException4);
				}
				try
				{
					throw ExceptionMapping[text2](eventStreamMessage);
				}
				catch (KeyNotFoundException)
				{
					throw new UnknownEventStreamException(text2);
				}
			}
			case "error":
			{
				int errorCode;
				try
				{
					errorCode = headers[":error-code"].AsInt32();
				}
				catch (KeyNotFoundException innerException2)
				{
					throw new EventStreamValidationException("Error Code not defined for error.", innerException2);
				}
				IEventStreamHeader value = null;
				bool flag = headers.TryGetValue(":error-message", out value);
				throw new EventStreamErrorCodeException(errorCode, flag ? value.AsString() : string.Empty);
			}
			default:
				throw new UnknownEventStreamMessageTypeException();
			}
		}

		protected void Process()
		{
			Task.Run(delegate
			{
				ProcessLoop();
			});
		}

		private void ProcessLoop()
		{
			ProcessLoop(null);
		}

		private void ProcessLoop(object state)
		{
			byte[] buffer = new byte[BufferSize];
			try
			{
				while (IsProcessing)
				{
					ReadFromStream(buffer);
				}
			}
			catch (Exception ex)
			{
				IsProcessing = false;
				TE eventStreamException = WrapException(ex);
				this.ExceptionReceived?.Invoke(this, new EventStreamExceptionReceivedArgs<TE>(eventStreamException));
			}
		}

		protected void ReadFromStream(byte[] buffer)
		{
			int num = NetworkStream.Read(buffer, 0, buffer.Length);
			if (NetworkStream.CanRead)
			{
				if (num > 0)
				{
					Decoder.ProcessData(buffer, 0, num);
				}
			}
			else
			{
				IsProcessing = false;
			}
		}

		protected TE WrapException(Exception ex)
		{
			if (ex is TE result)
			{
				return result;
			}
			object[] args = new object[2] { "Error.", ex };
			return (TE)Activator.CreateInstance(typeof(TE), args);
		}

		public virtual void StartProcessing()
		{
			if (!IsProcessing)
			{
				IsProcessing = true;
				Process();
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed)
			{
				if (disposing)
				{
					IsProcessing = false;
					NetworkStream?.Dispose();
					Decoder?.Dispose();
				}
				_disposed = true;
			}
		}
	}
	public class EventStreamMessageReceivedEventArgs : EventArgs
	{
		public EventStreamMessage Message { get; private set; }

		public object Context { get; private set; }

		public EventStreamMessageReceivedEventArgs(EventStreamMessage message)
		{
			Message = message;
		}

		public EventStreamMessageReceivedEventArgs(EventStreamMessage message, object context)
		{
			Message = message;
			Context = context;
		}
	}
	public class EventStreamDecoderIllegalStateException : Exception
	{
		public EventStreamDecoderIllegalStateException(string message)
			: base(message)
		{
		}
	}
	public interface IEventStreamDecoder : IDisposable
	{
		event EventHandler<EventStreamMessageReceivedEventArgs> MessageReceived;

		void ProcessData(byte[] data, int offset, int length);
	}
	public class EventStreamDecoder : IEventStreamDecoder, IDisposable
	{
		private delegate int ProcessRead(byte[] data, int offset, int length);

		private enum DecoderState
		{
			Start,
			ReadPrelude,
			ProcessPrelude,
			ReadMessage,
			Error
		}

		private ProcessRead[] _stateFns;

		private DecoderState _state;

		private int _currentMessageLength;

		private int _amountBytesRead;

		private byte[] _workingMessage;

		private byte[] _workingBuffer;

		private CrcCalculatorStream _runningChecksumStream;

		private bool disposedValue;

		public object MessageReceivedContext { get; set; }

		public event EventHandler<EventStreamMessageReceivedEventArgs> MessageReceived;

		public EventStreamDecoder()
		{
			_workingBuffer = new byte[12];
			_stateFns = new ProcessRead[5] { Start, ReadPrelude, ProcessPrelude, ReadMessage, Error };
			_state = DecoderState.Start;
		}

		private int Start(byte[] data, int offset, int length)
		{
			_workingMessage = null;
			_amountBytesRead = 0;
			if (_runningChecksumStream != null)
			{
				_runningChecksumStream.Dispose();
			}
			_runningChecksumStream = new CrcCalculatorStream(new NullStream());
			_currentMessageLength = 0;
			_state = DecoderState.ReadPrelude;
			return 0;
		}

		private int ReadPrelude(byte[] data, int offset, int length)
		{
			int num = 0;
			checked
			{
				if (_amountBytesRead < 12)
				{
					num = Math.Min(length - offset, 12 - _amountBytesRead);
					Buffer.BlockCopy(data, offset, _workingBuffer, _amountBytesRead, num);
					_amountBytesRead += num;
				}
				if (_amountBytesRead == 12)
				{
					_state = DecoderState.ProcessPrelude;
				}
				return num;
			}
		}

		private int ProcessPrelude(byte[] data, int offset, int length)
		{
			_runningChecksumStream.Write(_workingBuffer, 0, 8);
			int num = EndianConversionUtility.NetworkToHostOrder(BitConverter.ToInt32(_workingBuffer, 8));
			if (num != _runningChecksumStream.Crc32)
			{
				_state = DecoderState.Error;
				throw new EventStreamChecksumFailureException(string.Format(CultureInfo.InvariantCulture, "Message Prelude Checksum failure. Expected {0} but was {1}", num, _runningChecksumStream.Crc32));
			}
			_runningChecksumStream.Write(_workingBuffer, 8, 4);
			_currentMessageLength = EndianConversionUtility.NetworkToHostOrder(BitConverter.ToInt32(_workingBuffer, 0));
			_workingMessage = new byte[_currentMessageLength];
			Buffer.BlockCopy(_workingBuffer, 0, _workingMessage, 0, 12);
			_state = DecoderState.ReadMessage;
			return 0;
		}

		private int ReadMessage(byte[] data, int offset, int length)
		{
			int num = 0;
			checked
			{
				if (_amountBytesRead < _currentMessageLength)
				{
					num = Math.Min(length - offset, _currentMessageLength - _amountBytesRead);
					Buffer.BlockCopy(data, offset, _workingMessage, _amountBytesRead, num);
					_amountBytesRead += num;
				}
				if (_amountBytesRead == _currentMessageLength)
				{
					ProcessMessage();
				}
				return num;
			}
		}

		private void ProcessMessage()
		{
			try
			{
				EventStreamMessage message = EventStreamMessage.FromBuffer(_workingMessage, 0, _currentMessageLength);
				this.MessageReceived?.Invoke(this, new EventStreamMessageReceivedEventArgs(message, MessageReceivedContext));
				_state = DecoderState.Start;
			}
			catch (Exception)
			{
				_state = DecoderState.Error;
				throw;
			}
		}

		private int Error(byte[] data, int offset, int length)
		{
			throw new EventStreamDecoderIllegalStateException("Event stream decoder is in an error state. Create a new instance, and use a new stream to continue");
		}

		public void ProcessData(byte[] data, int offset, int length)
		{
			checked
			{
				int num = length - offset;
				while (offset < num)
				{
					offset += _stateFns[unchecked((int)_state)](data, offset, length);
				}
			}
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposedValue)
			{
				if (disposing)
				{
					_runningChecksumStream.Dispose();
					_workingMessage = null;
				}
				disposedValue = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
	public abstract class EventStreamException : Exception
	{
		protected EventStreamException()
		{
		}

		protected EventStreamException(string message)
			: base(message)
		{
		}

		protected EventStreamException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
	public interface IEventStreamEvent
	{
	}
	public interface IEventStreamTerminalEvent : IEventStreamEvent
	{
	}
	public class UnknownEventStreamEvent : IEventStreamEvent
	{
		public IEventStreamMessage ReceivedMessage { get; set; }

		public string EventType { get; set; }

		public UnknownEventStreamEvent()
		{
		}

		public UnknownEventStreamEvent(IEventStreamMessage receivedMessage, string eventType)
		{
			ReceivedMessage = receivedMessage;
			EventType = eventType;
		}
	}
}
namespace Amazon.Runtime.Internal
{
	public class CapacityManager : IDisposable
	{
		public enum CapacityType
		{
			Increment,
			Retry,
			Timeout
		}

		private bool _disposed;

		private static Dictionary<string, RetryCapacity> _serviceUrlToCapacityMap = new Dictionary<string, RetryCapacity>();

		private ReaderWriterLockSlim _rwlock = new ReaderWriterLockSlim();

		private readonly int retryCost;

		private readonly int timeoutRetryCost;

		private readonly int initialRetryTokens;

		private readonly int noRetryIncrement;

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed && disposing)
			{
				_rwlock.Dispose();
				_disposed = true;
			}
		}

		public CapacityManager(int throttleRetryCount, int throttleRetryCost, int throttleCost)
			: this(throttleRetryCount, throttleRetryCost, throttleCost, throttleRetryCost)
		{
		}

		public CapacityManager(int throttleRetryCount, int throttleRetryCost, int throttleCost, int timeoutRetryCost)
		{
			retryCost = throttleRetryCost;
			initialRetryTokens = throttleRetryCount;
			noRetryIncrement = throttleCost;
			this.timeoutRetryCost = timeoutRetryCost;
		}

		public bool TryAcquireCapacity(RetryCapacity retryCapacity)
		{
			return TryAcquireCapacity(retryCapacity, CapacityType.Retry);
		}

		public bool TryAcquireCapacity(RetryCapacity retryCapacity, CapacityType capacityType)
		{
			int num = ((capacityType == CapacityType.Timeout) ? timeoutRetryCost : retryCost);
			if (num < 0)
			{
				return false;
			}
			checked
			{
				lock (retryCapacity)
				{
					if (retryCapacity.AvailableCapacity - num >= 0)
					{
						retryCapacity.AvailableCapacity -= num;
						return true;
					}
					return false;
				}
			}
		}

		[Obsolete("This method is no longer used in favor of allowing the caller to specify the type of capacity to release.")]
		public void TryReleaseCapacity(bool isRetryRequest, RetryCapacity retryCapacity)
		{
			ReleaseCapacity(isRetryRequest ? CapacityType.Retry : CapacityType.Increment, retryCapacity);
		}

		public void ReleaseCapacity(CapacityType capacityType, RetryCapacity retryCapacity)
		{
			switch (capacityType)
			{
			case CapacityType.Retry:
				ReleaseCapacity(retryCost, retryCapacity);
				break;
			case CapacityType.Timeout:
				ReleaseCapacity(timeoutRetryCost, retryCapacity);
				break;
			case CapacityType.Increment:
				ReleaseCapacity(noRetryIncrement, retryCapacity);
				break;
			default:
				throw new NotSupportedException($"Unsupported CapacityType {capacityType}");
			}
		}

		public RetryCapacity GetRetryCapacity(string serviceURL)
		{
			if (!TryGetRetryCapacity(serviceURL, out var value))
			{
				return AddNewRetryCapacity(serviceURL);
			}
			return value;
		}

		private bool TryGetRetryCapacity(string key, out RetryCapacity value)
		{
			_rwlock.EnterReadLock();
			try
			{
				if (_serviceUrlToCapacityMap.TryGetValue(key, out value))
				{
					return true;
				}
				return false;
			}
			finally
			{
				_rwlock.ExitReadLock();
			}
		}

		private RetryCapacity AddNewRetryCapacity(string serviceURL)
		{
			_rwlock.EnterUpgradeableReadLock();
			try
			{
				if (!_serviceUrlToCapacityMap.TryGetValue(serviceURL, out var value))
				{
					_rwlock.EnterWriteLock();
					try
					{
						value = new RetryCapacity(checked(retryCost * initialRetryTokens));
						_serviceUrlToCapacityMap.Add(serviceURL, value);
						return value;
					}
					finally
					{
						_rwlock.ExitWriteLock();
					}
				}
				return value;
			}
			finally
			{
				_rwlock.ExitUpgradeableReadLock();
			}
		}

		private static void ReleaseCapacity(int capacity, RetryCapacity retryCapacity)
		{
			if (retryCapacity.AvailableCapacity >= 0 && retryCapacity.AvailableCapacity < retryCapacity.MaxCapacity)
			{
				lock (retryCapacity)
				{
					retryCapacity.AvailableCapacity = Math.Min(checked(retryCapacity.AvailableCapacity + capacity), retryCapacity.MaxCapacity);
				}
			}
		}
	}
	public class RetryCapacity
	{
		private readonly int _maxCapacity;

		public int AvailableCapacity { get; set; }

		public int MaxCapacity => _maxCapacity;

		public RetryCapacity(int maxCapacity)
		{
			_maxCapacity = maxCapacity;
			AvailableCapacity = maxCapacity;
		}
	}
	public class ClientContext
	{
		private const string CLIENT_KEY = "client";

		private const string CLIENT_ID_KEY = "client_id";

		private const string CLIENT_APP_TITLE_KEY = "app_title";

		private const string CLIENT_APP_VERSION_NAME_KEY = "app_version_name";

		private const string CLIENT_APP_VERSION_CODE_KEY = "app_version_code";

		private const string CLIENT_APP_PACKAGE_NAME_KEY = "app_package_name";

		private const string CUSTOM_KEY = "custom";

		private const string ENV_KEY = "env";

		private const string ENV_PLATFORM_KEY = "platform";

		private const string ENV_MODEL_KEY = "model";

		private const string ENV_MAKE_KEY = "make";

		private const string ENV_PLATFORM_VERSION_KEY = "platform_version";

		private const string ENV_LOCALE_KEY = "locale";

		private const string SERVICES_KEY = "services";

		private const string SERVICE_MOBILE_ANALYTICS_KEY = "mobile_analytics";

		private const string SERVICE_MOBILE_ANALYTICS_APP_ID_KEY = "app_id";

		private IDictionary<string, string> _client;

		private IDictionary<string, string> _custom;

		private IDictionary<string, string> _env;

		private IDictionary<string, IDictionary> _services;

		private IDictionary _clientContext;

		private static object _lock = new object();

		private static string _clientID = null;

		private const string APP_ID_KEY = "APP_ID_KEY";

		private const string CLIENT_ID_CACHE_FILENAME = "client-ID-cache";

		private static IApplicationSettings _appSetting = ServiceFactory.Instance.GetService<IApplicationSettings>();

		private static IApplicationInfo _appInfo = ServiceFactory.Instance.GetService<IApplicationInfo>();

		private static IEnvironmentInfo _envInfo = ServiceFactory.Instance.GetService<IEnvironmentInfo>();

		public string AppID { get; set; }

		public void AddCustomAttributes(string key, string value)
		{
			lock (_lock)
			{
				if (_custom == null)
				{
					_custom = new Dictionary<string, string>();
				}
				_custom.Add(key, value);
			}
		}

		public string ToJsonString()
		{
			lock (_lock)
			{
				_client = new Dictionary<string, string>();
				_env = new Dictionary<string, string>();
				_services = new Dictionary<string, IDictionary>();
				_client.Add("client_id", _clientID);
				_client.Add("app_title", _appInfo.AppTitle);
				_client.Add("app_version_name", _appInfo.AppVersionName);
				_client.Add("app_version_code", _appInfo.AppVersionCode);
				_client.Add("app_package_name", _appInfo.PackageName);
				_env.Add("platform", _envInfo.Platform);
				_env.Add("platform_version", _envInfo.PlatformVersion);
				_env.Add("locale", _envInfo.Locale);
				_env.Add("make", _envInfo.Make);
				_env.Add("model", _envInfo.Model);
				if (!string.IsNullOrEmpty(AppID))
				{
					IDictionary dictionary = new Dictionary<string, string>();
					dictionary.Add("app_id", AppID);
					_services.Add("mobile_analytics", dictionary);
				}
				_clientContext = new Dictionary<string, IDictionary>();
				_clientContext.Add("client", _client);
				_clientContext.Add("env", _env);
				_clientContext.Add("custom", _custom);
				_clientContext.Add("services", _services);
				return JsonMapper.ToJson(_clientContext);
			}
		}

		public ClientContext(string appID)
		{
			AppID = appID;
			_custom = new Dictionary<string, string>();
			if (!string.IsNullOrEmpty(_clientID))
			{
				return;
			}
			_clientID = _appSetting.GetValue("APP_ID_KEY", ApplicationSettingsMode.Local);
			if (string.IsNullOrEmpty(_clientID))
			{
				string text = Guid.NewGuid().ToString();
				try
				{
					_appSetting.SetValue("APP_ID_KEY", text, ApplicationSettingsMode.Local);
				}
				catch (Exception ex)
				{
					Logger.GetLogger(typeof(ClientContext)).Error(ex, "Failed to save client id to local application setting");
					throw new Exception("Failed to save client id to local application setting", ex);
				}
				_clientID = text;
			}
		}
	}
	public class ParameterCollection : SortedDictionary<string, ParameterValue>
	{
		public ParameterCollection()
			: base((IComparer<string>)StringComparer.Ordinal)
		{
		}

		public void Add(string key, string value)
		{
			Add(key, new StringParameterValue(value));
		}

		public void Add(string key, List<string> values)
		{
			Add(key, new StringListParameterValue(values));
		}

		public List<KeyValuePair<string, string>> GetSortedParametersList()
		{
			return GetParametersEnumerable().ToList();
		}

		private IEnumerable<KeyValuePair<string, string>> GetParametersEnumerable()
		{
			using Enumerator enumerator = GetEnumerator();
			while (enumerator.MoveNext())
			{
				KeyValuePair<string, ParameterValue> current = enumerator.Current;
				string name = current.Key;
				ParameterValue value = current.Value;
				StringParameterValue stringParameterValue = value as StringParameterValue;
				StringListParameterValue slpv = value as StringListParameterValue;
				if (stringParameterValue != null)
				{
					yield return new KeyValuePair<string, string>(name, stringParameterValue.Value);
					continue;
				}
				if (slpv != null)
				{
					List<string> value2 = slpv.Value;
					value2.Sort(StringComparer.Ordinal);
					foreach (string item in value2)
					{
						yield return new KeyValuePair<string, string>(name, item);
					}
					continue;
				}
				throw new AmazonClientException("Unsupported parameter value type '" + value.GetType().FullName + "'");
			}
		}
	}
	public class TokenBucket
	{
		private const int MaxAttempts = 15;

		private readonly object _bucketLock = new object();

		private readonly double _minFillRate;

		private readonly double _minCapacity;

		private readonly double _beta;

		private readonly double _scaleConstant;

		private readonly double _smooth;

		private static readonly DateTime _epoch = new DateTime(1970, 1, 1);

		protected double? FillRate { get; set; }

		protected double? MaxCapacity { get; set; }

		protected double CurrentCapacity { get; set; }

		protected double? LastTimestamp { get; set; }

		protected double MeasuredTxRate { get; set; }

		protected double LastTxRateBucket { get; set; }

		protected long RequestCount { get; set; }

		protected double LastMaxRate { get; set; }

		protected double LastThrottleTime { get; set; }

		protected double TimeWindow { get; set; }

		protected bool Enabled { get; set; }

		public TokenBucket()
			: this(0.5, 1.0, 0.7, 0.4, 0.8)
		{
		}

		public TokenBucket(double minFillRate, double minCapacity, double beta, double scaleConstant, double smooth)
		{
			_minFillRate = minFillRate;
			_minCapacity = minCapacity;
			_beta = beta;
			_scaleConstant = scaleConstant;
			_smooth = smooth;
			LastTxRateBucket = Math.Floor(GetTimestamp());
			LastThrottleTime = GetTimestamp();
		}

		public bool TryAcquireToken(double amount, bool failFast)
		{
			bool? flag = SetupAcquireToken(amount);
			if (flag.HasValue)
			{
				return flag.Value;
			}
			checked
			{
				for (int i = 0; i < 15; i++)
				{
					int num = ObtainCapacity(amount);
					if (num == 0)
					{
						break;
					}
					if (failFast || i + 1 == 15)
					{
						return false;
					}
					WaitForToken(num);
				}
				return true;
			}
		}

		public async Task<bool> TryAcquireTokenAsync(double amount, bool failFast, CancellationToken cancellationToken)
		{
			bool? flag = SetupAcquireToken(amount);
			if (flag.HasValue)
			{
				return flag.Value;
			}
			checked
			{
				for (int attempt = 0; attempt < 15; attempt++)
				{
					int num = ObtainCapacity(amount);
					if (num == 0)
					{
						break;
					}
					if (failFast || attempt + 1 == 15)
					{
						return false;
					}
					await WaitForTokenAsync(num, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				return true;
			}
		}

		private bool? SetupAcquireToken(double amount)
		{
			if (amount <= 0.0)
			{
				return false;
			}
			lock (_bucketLock)
			{
				if (!Enabled)
				{
					return true;
				}
				TokenBucketRefill();
			}
			return null;
		}

		private int ObtainCapacity(double amount)
		{
			double currentCapacity;
			double value;
			lock (_bucketLock)
			{
				if (amount <= CurrentCapacity)
				{
					CurrentCapacity -= amount;
					return 0;
				}
				currentCapacity = CurrentCapacity;
				value = FillRate.Value;
			}
			return CalculateWait(amount, currentCapacity, value);
		}

		public void UpdateClientSendingRate(bool isThrottlingError)
		{
			lock (_bucketLock)
			{
				UpdateMeasuredRate();
				double val;
				if (isThrottlingError)
				{
					double rateToUse = (LastMaxRate = (Enabled ? Math.Min(MeasuredTxRate, FillRate.Value) : MeasuredTxRate));
					CalculateTimeWindow();
					LastThrottleTime = GetTimestamp();
					val = CUBICThrottle(rateToUse);
					Enabled = true;
				}
				else
				{
					CalculateTimeWindow();
					val = CUBICSuccess(GetTimestamp());
				}
				double newRps = Math.Min(val, 2.0 * MeasuredTxRate);
				TokenBucketUpdateRate(newRps);
			}
		}

		protected virtual void TokenBucketRefill()
		{
			double timestamp = GetTimestamp();
			if (!LastTimestamp.HasValue)
			{
				LastTimestamp = timestamp;
				return;
			}
			double num = (timestamp - LastTimestamp.Value) * FillRate.Value;
			CurrentCapacity = Math.Min(MaxCapacity.Value, CurrentCapacity + num);
			LastTimestamp = timestamp;
		}

		protected virtual void TokenBucketUpdateRate(double newRps)
		{
			TokenBucketRefill();
			FillRate = Math.Max(newRps, _minFillRate);
			MaxCapacity = Math.Max(newRps, _minCapacity);
			CurrentCapacity = Math.Min(CurrentCapacity, MaxCapacity.Value);
		}

		protected virtual void UpdateMeasuredRate()
		{
			double num = Math.Floor(GetTimestamp() * 2.0) / 2.0;
			checked
			{
				RequestCount++;
				if (num > LastTxRateBucket)
				{
					double num2 = (double)RequestCount / (num - LastTxRateBucket);
					MeasuredTxRate = num2 * _smooth + MeasuredTxRate * (1.0 - _smooth);
					RequestCount = 0L;
					LastTxRateBucket = num;
				}
			}
		}

		protected virtual void CalculateTimeWindow()
		{
			TimeWindow = Math.Pow(LastMaxRate * (1.0 - _beta) / _scaleConstant, 1.0 / 3.0);
		}

		protected virtual double CUBICSuccess(double timestamp)
		{
			timestamp -= LastThrottleTime;
			return _scaleConstant * Math.Pow(timestamp - TimeWindow, 3.0) + LastMaxRate;
		}

		protected virtual double CUBICThrottle(double rateToUse)
		{
			return rateToUse * _beta;
		}

		protected virtual int CalculateWait(double amount, double currentCapacity, double fillRate)
		{
			return checked((int)((amount - currentCapacity) / fillRate * 1000.0));
		}

		protected virtual void WaitForToken(int delayMs)
		{
			AWSSDKUtils.Sleep(delayMs);
		}

		protected virtual async Task WaitForTokenAsync(int delayMs, CancellationToken cancellationToken)
		{
			await Task.Delay(delayMs, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		protected virtual double GetTimestamp()
		{
			return GetTimeInSeconds();
		}

		private static double GetTimeInSeconds()
		{
			return (DateTime.UtcNow - _epoch).TotalSeconds;
		}
	}
	public class AutoConstructedList<T> : List<T>
	{
	}
	public class AutoConstructedDictionary<K, V> : Dictionary<K, V>
	{
	}
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public sealed class AWSPropertyAttribute : Attribute
	{
		private long min;

		private long max;

		public bool Required { get; set; }

		public bool IsMinSet { get; private set; }

		public long Min
		{
			get
			{
				if (!IsMinSet)
				{
					return -9223372036854775808L;
				}
				return min;
			}
			set
			{
				IsMinSet = true;
				min = value;
			}
		}

		public bool IsMaxSet { get; private set; }

		public long Max
		{
			get
			{
				if (!IsMaxSet)
				{
					return 9223372036854775807L;
				}
				return max;
			}
			set
			{
				IsMaxSet = true;
				max = value;
			}
		}
	}
	public class DefaultRequest : IRequest
	{
		private readonly ParameterCollection parametersCollection;

		private readonly IDictionary<string, string> parametersFacade;

		private readonly IDictionary<string, string> headers = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

		private readonly IDictionary<string, string> subResources = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

		private readonly IDictionary<string, string> pathResources = new Dictionary<string, string>(StringComparer.Ordinal);

		private System.Uri endpoint;

		private string resourcePath;

		private string serviceName;

		private readonly AmazonWebServiceRequest originalRequest;

		private byte[] content;

		private Stream contentStream;

		private string contentStreamHash;

		private string httpMethod = "POST";

		private bool useQueryString;

		private string requestName;

		private string canonicalResource;

		private RegionEndpoint alternateRegion;

		private long originalStreamLength;

		private int marshallerVersion = 1;

		public string RequestName => requestName;

		public string HttpMethod
		{
			get
			{
				return httpMethod;
			}
			set
			{
				httpMethod = value;
			}
		}

		public bool UseQueryString
		{
			get
			{
				if (HttpMethod == "GET")
				{
					return true;
				}
				return useQueryString;
			}
			set
			{
				useQueryString = value;
			}
		}

		public AmazonWebServiceRequest OriginalRequest => originalRequest;

		public IDictionary<string, string> Headers => headers;

		public IDictionary<string, string> Parameters => parametersFacade;

		public ParameterCollection ParameterCollection => parametersCollection;

		public IDictionary<string, string> SubResources => subResources;

		public System.Uri Endpoint
		{
			get
			{
				return endpoint;
			}
			set
			{
				endpoint = value;
			}
		}

		public string ResourcePath
		{
			get
			{
				return resourcePath;
			}
			set
			{
				resourcePath = value;
			}
		}

		public IDictionary<string, string> PathResources => pathResources;

		public int MarshallerVersion
		{
			get
			{
				return marshallerVersion;
			}
			set
			{
				marshallerVersion = value;
			}
		}

		public string CanonicalResource
		{
			get
			{
				return canonicalResource;
			}
			set
			{
				canonicalResource = value;
			}
		}

		public byte[] Content
		{
			get
			{
				return content;
			}
			set
			{
				content = value;
			}
		}

		public bool SetContentFromParameters { get; set; }

		public Stream ContentStream
		{
			get
			{
				return contentStream;
			}
			set
			{
				contentStream = value;
				OriginalStreamPosition = -1L;
				if (contentStream != null)
				{
					Stream nonWrapperBaseStream = WrapperStream.GetNonWrapperBaseStream(contentStream);
					if (nonWrapperBaseStream.CanSeek)
					{
						OriginalStreamPosition = nonWrapperBaseStream.Position;
					}
				}
			}
		}

		public long OriginalStreamPosition
		{
			get
			{
				return originalStreamLength;
			}
			set
			{
				originalStreamLength = value;
			}
		}

		public string ServiceName => serviceName;

		public RegionEndpoint AlternateEndpoint
		{
			get
			{
				return alternateRegion;
			}
			set
			{
				alternateRegion = value;
			}
		}

		public string HostPrefix { get; set; }

		public bool Suppress404Exceptions { get; set; }

		public AWS4SigningResult AWS4SignerResult { get; set; }

		public bool UseChunkEncoding { get; set; }

		public string CanonicalResourcePrefix { get; set; }

		public bool UseSigV4 { get; set; }

		public string AuthenticationRegion { get; set; }

		public string DeterminedSigningRegion { get; set; }

		public DefaultRequest(AmazonWebServiceRequest request, string serviceName)
		{
			if (request == null)
			{
				throw new ArgumentNullException("request");
			}
			if (string.IsNullOrEmpty(serviceName))
			{
				throw new ArgumentNullException("serviceName");
			}
			this.serviceName = serviceName;
			originalRequest = request;
			requestName = originalRequest.GetType().Name;
			UseSigV4 = ((IAmazonWebServiceRequest)originalRequest).UseSigV4;
			HostPrefix = string.Empty;
			parametersCollection = new ParameterCollection();
			parametersFacade = new ParametersDictionaryFacade(parametersCollection);
		}

		public void AddSubResource(string subResource)
		{
			AddSubResource(subResource, null);
		}

		public void AddSubResource(string subResource, string value)
		{
			SubResources.Add(subResource, value);
		}

		public void AddPathResource(string key, string value)
		{
			PathResources.Add(key, value);
		}

		public string ComputeContentStreamHash()
		{
			if (contentStream == null)
			{
				return null;
			}
			if (contentStreamHash == null)
			{
				Stream stream = WrapperStream.SearchWrappedStream(contentStream, (Stream s) => s.CanSeek);
				if (stream != null)
				{
					long position = stream.Position;
					byte[] data = CryptoUtilFactory.CryptoInstance.ComputeSHA256Hash(stream);
					contentStreamHash = AWSSDKUtils.ToHex(data, lowercase: true);
					stream.Seek(position, SeekOrigin.Begin);
				}
			}
			return contentStreamHash;
		}

		public bool IsRequestStreamRewindable()
		{
			Stream stream = ContentStream;
			if (stream != null)
			{
				stream = WrapperStream.GetNonWrapperBaseStream(stream);
				return stream.CanSeek;
			}
			return true;
		}

		public bool MayContainRequestBody()
		{
			if (!(HttpMethod == "POST") && !(HttpMethod == "PUT"))
			{
				return HttpMethod == "PATCH";
			}
			return true;
		}

		public bool HasRequestBody()
		{
			bool num = HttpMethod == "POST" || HttpMethod == "PUT" || HttpMethod == "PATCH";
			bool flag = this.HasRequestData();
			return num && flag;
		}

		public string GetHeaderValue(string headerName)
		{
			if (headers.TryGetValue(headerName, out var value))
			{
				return value;
			}
			return string.Empty;
		}
	}
	public abstract class DiscoveryEndpointBase
	{
		private DateTime _createdOn;

		private string _address;

		private long _cachePeriodInMinutes;

		private object objectExtendLock = new object();

		public string Address
		{
			get
			{
				return _address;
			}
			protected set
			{
				string text = value;
				if (text != null && !text.StartsWith("http://", StringComparison.OrdinalIgnoreCase) && !text.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
				{
					text = "https://" + text;
				}
				_address = text;
			}
		}

		public long CachePeriodInMinutes
		{
			get
			{
				return _cachePeriodInMinutes;
			}
			protected set
			{
				_cachePeriodInMinutes = value;
			}
		}

		protected DiscoveryEndpointBase(string address, long cachePeriodInMinutes)
		{
			Address = address;
			CachePeriodInMinutes = cachePeriodInMinutes;
			_createdOn = DateTime.UtcNow;
		}

		public bool HasExpired()
		{
			if (!((DateTime.UtcNow - _createdOn).TotalMinutes > (double)CachePeriodInMinutes))
			{
				return false;
			}
			return true;
		}

		public void ExtendExpiration(long minutes)
		{
			lock (objectExtendLock)
			{
				CachePeriodInMinutes = minutes;
				_createdOn = DateTime.UtcNow;
			}
		}
	}
	public class DiscoveryEndpoint : DiscoveryEndpointBase
	{
		public DiscoveryEndpoint(string address, long cachePeriodInMinutes)
			: base(address, cachePeriodInMinutes)
		{
		}
	}
	public abstract class EndpointDiscoveryDataBase
	{
		private bool _required;

		private SortedDictionary<string, string> _identifiers;

		public virtual bool Required
		{
			get
			{
				return _required;
			}
			protected set
			{
				_required = value;
			}
		}

		public virtual SortedDictionary<string, string> Identifiers
		{
			get
			{
				return _identifiers;
			}
			protected set
			{
				_identifiers = value;
			}
		}

		protected EndpointDiscoveryDataBase(bool required)
		{
			_required = required;
			_identifiers = new SortedDictionary<string, string>();
		}
	}
	public class EndpointDiscoveryData : EndpointDiscoveryDataBase
	{
		public EndpointDiscoveryData(bool required)
			: base(required)
		{
		}
	}
	public abstract class EndpointDiscoveryResolverBase
	{
		private IClientConfig _config;

		private Logger _logger;

		private LruCache<string, IList<DiscoveryEndpointBase>> _cache;

		private object objectCacheLock = new object();

		public virtual int CacheCount => _cache.Count;

		protected EndpointDiscoveryResolverBase(IClientConfig config, Logger logger)
		{
			_config = config;
			_logger = logger;
			_cache = new LruCache<string, IList<DiscoveryEndpointBase>>(config.EndpointDiscoveryCacheLimit);
		}

		public virtual IEnumerable<DiscoveryEndpointBase> ResolveEndpoints(EndpointOperationContextBase context, Func<IList<DiscoveryEndpointBase>> InvokeEndpointOperation)
		{
			string cacheKey = BuildEndpointDiscoveryCacheKey(context);
			bool refreshCache = false;
			IEnumerable<DiscoveryEndpointBase> enumerable = ProcessEndpointCache(cacheKey, context.EvictCacheKey, context.EvictUri, out refreshCache);
			if (enumerable != null)
			{
				if (refreshCache)
				{
					Task.Run(delegate
					{
						ProcessInvokeEndpointOperation(cacheKey, InvokeEndpointOperation, endpointRequired: false);
					});
				}
				return enumerable;
			}
			if (context.EvictCacheKey)
			{
				return null;
			}
			if (context.EndpointDiscoveryData.Required)
			{
				enumerable = ProcessInvokeEndpointOperation(cacheKey, InvokeEndpointOperation, endpointRequired: true);
			}
			else if (_config.EndpointDiscoveryEnabled)
			{
				Task.Run(delegate
				{
					ProcessInvokeEndpointOperation(cacheKey, InvokeEndpointOperation, endpointRequired: false);
				});
				return null;
			}
			return enumerable;
		}

		private IEnumerable<DiscoveryEndpointBase> ProcessInvokeEndpointOperation(string cacheKey, Func<IList<DiscoveryEndpointBase>> InvokeEndpointOperation, bool endpointRequired)
		{
			IList<DiscoveryEndpointBase> list = null;
			try
			{
				list = InvokeEndpointOperation();
				if (list != null && list.Count > 0)
				{
					_cache.AddOrUpdate(cacheKey, list);
				}
				else
				{
					list = null;
					if (!endpointRequired)
					{
						List<DiscoveryEndpointBase> list2 = new List<DiscoveryEndpointBase>();
						list2.Add(new DiscoveryEndpoint(null, 1L));
						_cache.AddOrUpdate(cacheKey, list2);
					}
					_logger.InfoFormat("The request to discover endpoints did not return any endpoints.");
				}
			}
			catch (Exception exception)
			{
				_logger.Error(exception, "An unhandled exception occurred while trying to discover endpoints.");
			}
			if (list == null && endpointRequired)
			{
				throw new AmazonClientException("Failed to discover the endpoint for the request. Requests will not succeed until an endpoint can be retrieved or an endpoint is manually specified.");
			}
			return list;
		}

		public virtual IList<DiscoveryEndpointBase> GetDiscoveryEndpointsFromCache(string cacheKey)
		{
			IList<DiscoveryEndpointBase> value = null;
			if (!_cache.TryGetValue(cacheKey, out value))
			{
				return null;
			}
			return value;
		}

		private IEnumerable<DiscoveryEndpointBase> ProcessEndpointCache(string cacheKey, bool evictCacheKey, System.Uri evictUri, out bool refreshCache)
		{
			refreshCache = false;
			IList<DiscoveryEndpointBase> discoveryEndpointsFromCache = GetDiscoveryEndpointsFromCache(cacheKey);
			if (evictCacheKey && discoveryEndpointsFromCache != null)
			{
				string value = evictUri.ToString();
				lock (objectCacheLock)
				{
					for (int i = 0; i < discoveryEndpointsFromCache.Count; i = checked(i + 1))
					{
						DiscoveryEndpointBase discoveryEndpointBase = discoveryEndpointsFromCache[i];
						if (discoveryEndpointBase.Address != null && discoveryEndpointBase.Address.Equals(value, StringComparison.OrdinalIgnoreCase))
						{
							discoveryEndpointsFromCache.RemoveAt(i);
							break;
						}
					}
				}
				if (discoveryEndpointsFromCache.Count == 0)
				{
					_cache.Evict(cacheKey);
					return null;
				}
			}
			if (discoveryEndpointsFromCache != null)
			{
				foreach (DiscoveryEndpointBase item in discoveryEndpointsFromCache)
				{
					if (item.HasExpired())
					{
						refreshCache = true;
						item.ExtendExpiration(1L);
					}
				}
				return discoveryEndpointsFromCache;
			}
			return null;
		}

		private static string BuildEndpointDiscoveryCacheKey(EndpointOperationContextBase context)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(context.CustomerCredentials);
			SortedDictionary<string, string> identifiers = context.EndpointDiscoveryData.Identifiers;
			if (identifiers != null && identifiers.Count > 0)
			{
				stringBuilder.Append(string.Format(CultureInfo.InvariantCulture, ".{0}", context.OperationName));
				foreach (KeyValuePair<string, string> item in identifiers)
				{
					stringBuilder.Append(string.Format(CultureInfo.InvariantCulture, ".{0}", item.Value));
				}
			}
			return stringBuilder.ToString();
		}
	}
	public class EndpointDiscoveryResolver : EndpointDiscoveryResolverBase
	{
		public EndpointDiscoveryResolver(IClientConfig config, Logger logger)
			: base(config, logger)
		{
		}
	}
	public abstract class EndpointOperationContextBase
	{
		private string _customerCredentials;

		private string _operationName;

		private EndpointDiscoveryDataBase _endpointDiscoveryData;

		private bool _evictCacheKey;

		private System.Uri _evictUri;

		public virtual string CustomerCredentials
		{
			get
			{
				return _customerCredentials;
			}
			protected set
			{
				_customerCredentials = value;
			}
		}

		public virtual string OperationName
		{
			get
			{
				return _operationName;
			}
			protected set
			{
				_operationName = value;
			}
		}

		public virtual EndpointDiscoveryDataBase EndpointDiscoveryData
		{
			get
			{
				return _endpointDiscoveryData;
			}
			protected set
			{
				_endpointDiscoveryData = value;
			}
		}

		public virtual bool EvictCacheKey
		{
			get
			{
				return _evictCacheKey;
			}
			protected set
			{
				_evictCacheKey = value;
			}
		}

		public virtual System.Uri EvictUri
		{
			get
			{
				return _evictUri;
			}
			protected set
			{
				_evictUri = value;
			}
		}

		protected EndpointOperationContextBase(string customerCredentials, string operationName, EndpointDiscoveryDataBase endpointDiscoveryData, bool evictCacheKey, System.Uri evictUri)
		{
			if (string.IsNullOrEmpty(customerCredentials))
			{
				throw new ArgumentNullException("customerCredentials");
			}
			_customerCredentials = customerCredentials;
			_operationName = operationName;
			_endpointDiscoveryData = endpointDiscoveryData;
			_evictCacheKey = evictCacheKey;
			_evictUri = evictUri;
		}
	}
	public class EndpointOperationContext : EndpointOperationContextBase
	{
		public EndpointOperationContext(string customerCredentials, string operationName, EndpointDiscoveryDataBase endpointDiscoveryData, bool evictCacheKey, System.Uri evictUri)
			: base(customerCredentials, operationName, endpointDiscoveryData, evictCacheKey, evictUri)
		{
		}
	}
	public class ErrorResponse
	{
		public ErrorType Type { get; set; }

		public string Code { get; set; }

		public string Message { get; set; }

		public string RequestId { get; set; }

		public Exception InnerException { get; set; }

		public HttpStatusCode StatusCode { get; set; }
	}
	public interface IAmazonWebServiceRequest
	{
		EventHandler<StreamTransferProgressArgs> StreamUploadProgressCallback { get; set; }

		Dictionary<string, object> RequestState { get; }

		bool UseSigV4 { get; set; }

		void AddBeforeRequestHandler(RequestEventHandler handler);

		void RemoveBeforeRequestHandler(RequestEventHandler handler);
	}
	public class InternalConfiguration
	{
		public bool? EndpointDiscoveryEnabled { get; set; }

		public RequestRetryMode? RetryMode { get; set; }

		public int? MaxAttempts { get; set; }
	}
	public static class FallbackInternalConfigurationFactory
	{
		private delegate InternalConfiguration ConfigGenerator();

		private static InternalConfiguration _cachedConfiguration;

		public static bool? EndpointDiscoveryEnabled => _cachedConfiguration.EndpointDiscoveryEnabled;

		public static RequestRetryMode? RetryMode => _cachedConfiguration.RetryMode;

		public static int? MaxAttempts => _cachedConfiguration.MaxAttempts;

		static FallbackInternalConfigurationFactory()
		{
			Reset();
		}

		public static void Reset()
		{
			_cachedConfiguration = new InternalConfiguration();
			List<ConfigGenerator> generators = new List<ConfigGenerator>();
			_cachedConfiguration.EndpointDiscoveryEnabled = SeekValue(generators, (InternalConfiguration c) => c.EndpointDiscoveryEnabled);
			_cachedConfiguration.RetryMode = SeekValue(generators, (InternalConfiguration c) => c.RetryMode);
			_cachedConfiguration.MaxAttempts = SeekValue(generators, (InternalConfiguration c) => c.MaxAttempts);
		}

		private static T? SeekValue<T>(List<ConfigGenerator> generators, Func<InternalConfiguration, T?> getValue) where T : struct
		{
			foreach (ConfigGenerator generator in generators)
			{
				InternalConfiguration arg = generator();
				T? result = getValue(arg);
				if (result.HasValue)
				{
					return result;
				}
			}
			return null;
		}
	}
	public delegate IEnumerable<DiscoveryEndpointBase> EndpointOperationDelegate(EndpointOperationContextBase context);
	public abstract class InvokeOptionsBase
	{
		private IMarshaller<IRequest, AmazonWebServiceRequest> _requestMarshaller;

		private ResponseUnmarshaller _responseUnmarshaller;

		private IMarshaller<EndpointDiscoveryDataBase, AmazonWebServiceRequest> _endpointDiscoveryMarshaller;

		private EndpointOperationDelegate _endpointOperation;

		public virtual IMarshaller<IRequest, AmazonWebServiceRequest> RequestMarshaller
		{
			get
			{
				return _requestMarshaller;
			}
			set
			{
				_requestMarshaller = value;
			}
		}

		public virtual ResponseUnmarshaller ResponseUnmarshaller
		{
			get
			{
				return _responseUnmarshaller;
			}
			set
			{
				_responseUnmarshaller = value;
			}
		}

		public virtual IMarshaller<EndpointDiscoveryDataBase, AmazonWebServiceRequest> EndpointDiscoveryMarshaller
		{
			get
			{
				return _endpointDiscoveryMarshaller;
			}
			set
			{
				_endpointDiscoveryMarshaller = value;
			}
		}

		public virtual EndpointOperationDelegate EndpointOperation
		{
			get
			{
				return _endpointOperation;
			}
			set
			{
				_endpointOperation = value;
			}
		}
	}
	public class InvokeOptions : InvokeOptionsBase
	{
	}
	public interface IRequest
	{
		string RequestName { get; }

		IDictionary<string, string> Headers { get; }

		bool UseQueryString { get; set; }

		IDictionary<string, string> Parameters { get; }

		ParameterCollection ParameterCollection { get; }

		IDictionary<string, string> SubResources { get; }

		string HttpMethod { get; set; }

		System.Uri Endpoint { get; set; }

		string ResourcePath { get; set; }

		IDictionary<string, string> PathResources { get; }

		int MarshallerVersion { get; set; }

		byte[] Content { get; set; }

		bool SetContentFromParameters { get; set; }

		Stream ContentStream { get; set; }

		long OriginalStreamPosition { get; set; }

		string ServiceName { get; }

		AmazonWebServiceRequest OriginalRequest { get; }

		RegionEndpoint AlternateEndpoint { get; set; }

		string HostPrefix { get; set; }

		bool Suppress404Exceptions { get; set; }

		AWS4SigningResult AWS4SignerResult { get; set; }

		bool UseChunkEncoding { get; set; }

		string CanonicalResourcePrefix { get; set; }

		bool UseSigV4 { get; set; }

		string AuthenticationRegion { get; set; }

		string DeterminedSigningRegion { get; set; }

		void AddSubResource(string subResource);

		void AddSubResource(string subResource, string value);

		void AddPathResource(string key, string value);

		string GetHeaderValue(string headerName);

		string ComputeContentStreamHash();

		bool IsRequestStreamRewindable();

		bool MayContainRequestBody();

		bool HasRequestBody();
	}
	public interface IRequestData
	{
		ResponseUnmarshaller Unmarshaller { get; }

		RequestMetrics Metrics { get; }

		IRequest Request { get; }

		AbstractAWSSigner Signer { get; }

		int RetriesAttempt { get; }
	}
	public interface IServiceMetadata
	{
		string ServiceId { get; }

		IDictionary<string, string> OperationNameMapping { get; }
	}
	public class ParametersDictionaryFacade : IDictionary<string, string>, ICollection<KeyValuePair<string, string>>, IEnumerable<KeyValuePair<string, string>>, IEnumerable
	{
		private readonly ParameterCollection _parameterCollection;

		public int Count => _parameterCollection.Count;

		public string this[string key]
		{
			get
			{
				return ParameterValueToString(_parameterCollection[key]);
			}
			set
			{
				if (_parameterCollection.TryGetValue(key, out var value2))
				{
					UpdateParameterValue(value2, value);
				}
				else
				{
					value2 = new StringParameterValue(value);
				}
				_parameterCollection[key] = value2;
			}
		}

		public ICollection<string> Keys => _parameterCollection.Keys;

		public ICollection<string> Values
		{
			get
			{
				List<string> list = new List<string>();
				foreach (KeyValuePair<string, ParameterValue> item2 in _parameterCollection)
				{
					string item = ParameterValueToString(item2.Value);
					list.Add(item);
				}
				return list;
			}
		}

		public bool IsReadOnly => ((IDictionary)_parameterCollection).IsReadOnly;

		public ParametersDictionaryFacade(ParameterCollection collection)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			_parameterCollection = collection;
		}

		private static string ParameterValueToString(ParameterValue pv)
		{
			if (pv == null)
			{
				throw new ArgumentNullException("pv");
			}
			StringParameterValue stringParameterValue = pv as StringParameterValue;
			StringListParameterValue stringListParameterValue = pv as StringListParameterValue;
			if (stringParameterValue != null)
			{
				return stringParameterValue.Value;
			}
			if (stringListParameterValue != null)
			{
				return JsonMapper.ToJson(stringListParameterValue.Value);
			}
			throw new AmazonClientException("Unexpected parameter value type " + pv.GetType().FullName);
		}

		private static void UpdateParameterValue(ParameterValue pv, string newValue)
		{
			if (pv == null)
			{
				throw new ArgumentNullException("pv");
			}
			StringParameterValue stringParameterValue = pv as StringParameterValue;
			StringListParameterValue stringListParameterValue = pv as StringListParameterValue;
			if (stringParameterValue != null)
			{
				stringParameterValue.Value = newValue;
				return;
			}
			if (stringListParameterValue != null)
			{
				List<string> value = JsonMapper.ToObject<List<string>>(newValue);
				stringListParameterValue.Value = value;
				return;
			}
			throw new AmazonClientException("Unexpected parameter value type " + pv.GetType().FullName);
		}

		public void Add(string key, string value)
		{
			_parameterCollection.Add(key, value);
		}

		public bool ContainsKey(string key)
		{
			return _parameterCollection.ContainsKey(key);
		}

		public bool Remove(string key)
		{
			return _parameterCollection.Remove(key);
		}

		public bool TryGetValue(string key, out string value)
		{
			if (_parameterCollection.TryGetValue(key, out var value2))
			{
				value = ParameterValueToString(value2);
				return true;
			}
			value = null;
			return false;
		}

		public bool Remove(KeyValuePair<string, string> item)
		{
			if (Contains(item))
			{
				return _parameterCollection.Remove(item.Key);
			}
			return false;
		}

		public void Add(KeyValuePair<string, string> item)
		{
			StringParameterValue value = new StringParameterValue(item.Value);
			_parameterCollection.Add(item.Key, value);
		}

		public bool Contains(KeyValuePair<string, string> item)
		{
			string key = item.Key;
			string value = item.Value;
			if (_parameterCollection.TryGetValue(key, out var value2))
			{
				return string.Equals(ParameterValueToString(value2), value, StringComparison.Ordinal);
			}
			return false;
		}

		public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (arrayIndex < 0 || arrayIndex > array.Length)
			{
				throw new ArgumentOutOfRangeException("arrayIndex");
			}
			checked
			{
				if (array.Length - arrayIndex < _parameterCollection.Count)
				{
					throw new ArgumentOutOfRangeException("arrayIndex", "Not enough space in target array");
				}
				using IEnumerator<KeyValuePair<string, string>> enumerator = GetEnumerator();
				while (enumerator.MoveNext())
				{
					KeyValuePair<string, string> current = enumerator.Current;
					array[arrayIndex++] = current;
				}
			}
		}

		public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
		{
			foreach (KeyValuePair<string, ParameterValue> item in _parameterCollection)
			{
				string key = item.Key;
				string value = ParameterValueToString(item.Value);
				yield return new KeyValuePair<string, string>(key, value);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public void Clear()
		{
			_parameterCollection.Clear();
		}
	}
	public class RuntimePipelineCustomizerRegistry : IDisposable
	{
		private Logger _logger = Logger.GetLogger(typeof(RuntimePipelineCustomizerRegistry));

		private ReaderWriterLockSlim _rwlock = new ReaderWriterLockSlim();

		private IList<IRuntimePipelineCustomizer> _customizers = new List<IRuntimePipelineCustomizer>();

		public static RuntimePipelineCustomizerRegistry Instance { get; } = new RuntimePipelineCustomizerRegistry();

		private RuntimePipelineCustomizerRegistry()
		{
		}

		public void Register(IRuntimePipelineCustomizer customizer)
		{
			_rwlock.EnterWriteLock();
			try
			{
				if (_customizers.FirstOrDefault((IRuntimePipelineCustomizer x) => string.Equals(x.UniqueName, customizer.UniqueName)) != null)
				{
					_logger.InfoFormat("Skipping registration because runtime pipeline customizer {0} already registered", customizer.UniqueName);
				}
				else
				{
					_logger.InfoFormat("Registering runtime pipeline customizer {0}", customizer.UniqueName);
					_customizers.Add(customizer);
				}
			}
			finally
			{
				_rwlock.ExitWriteLock();
			}
		}

		public void Deregister(IRuntimePipelineCustomizer customizer)
		{
			Deregister(customizer.UniqueName);
		}

		public void Deregister(string uniqueName)
		{
			_rwlock.EnterWriteLock();
			try
			{
				int num = -1;
				for (int i = 0; i < _customizers.Count; i = checked(i + 1))
				{
					if (string.Equals(uniqueName, _customizers[i].UniqueName, StringComparison.Ordinal))
					{
						num = i;
						break;
					}
				}
				if (num != -1)
				{
					_logger.InfoFormat("Deregistering runtime pipeline customizer {0}", uniqueName);
					_customizers.RemoveAt(num);
				}
				else
				{
					_logger.InfoFormat("Runtime pipeline customizer {0} not found to deregister", uniqueName);
				}
			}
			finally
			{
				_rwlock.ExitWriteLock();
			}
		}

		internal void ApplyCustomizations(Type type, RuntimePipeline pipeline)
		{
			_rwlock.EnterReadLock();
			try
			{
				foreach (IRuntimePipelineCustomizer customizer in _customizers)
				{
					_logger.InfoFormat("Applying runtime pipeline customization {0}", customizer.UniqueName);
					customizer.Customize(type, pipeline);
				}
			}
			finally
			{
				_rwlock.ExitReadLock();
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing && _rwlock != null)
			{
				_rwlock.Dispose();
				_rwlock = null;
			}
		}
	}
	public interface IRuntimePipelineCustomizer
	{
		string UniqueName { get; }

		void Customize(Type type, RuntimePipeline pipeline);
	}
	public static class ServiceClientHelpers
	{
		public const string S3_ASSEMBLY_NAME = "AWSSDK.S3";

		public const string S3_SERVICE_CLASS_NAME = "Amazon.S3.AmazonS3Client";

		public const string STS_ASSEMBLY_NAME = "AWSSDK.SecurityToken";

		public const string STS_SERVICE_CLASS_NAME = "Amazon.SecurityToken.AmazonSecurityTokenServiceClient";

		public const string STS_SERVICE_CONFIG_NAME = "Amazon.SecurityToken.AmazonSecurityTokenServiceConfig";

		public const string KMS_ASSEMBLY_NAME = "AWSSDK.KeyManagementService";

		public const string KMS_SERVICE_CLASS_NAME = "Amazon.KeyManagementService.AmazonKeyManagementServiceClient";

		public static TClient CreateServiceFromAnother<TClient, TConfig>(AmazonServiceClient originalServiceClient) where TClient : AmazonServiceClient where TConfig : ClientConfig, new()
		{
			AWSCredentials credentials = originalServiceClient.Credentials;
			TConfig val = originalServiceClient.CloneConfig<TConfig>();
			return TypeFactory.GetTypeInfo(typeof(TClient)).GetConstructor(new ITypeInfo[2]
			{
				TypeFactory.GetTypeInfo(typeof(AWSCredentials)),
				TypeFactory.GetTypeInfo(val.GetType())
			}).Invoke(new object[2] { credentials, val }) as TClient;
		}

		public static TClient CreateServiceFromAssembly<TClient>(string assemblyName, string serviceClientClassName, RegionEndpoint region) where TClient : class
		{
			return LoadServiceClientType(assemblyName, serviceClientClassName).GetConstructor(new ITypeInfo[1] { TypeFactory.GetTypeInfo(typeof(RegionEndpoint)) }).Invoke(new object[1] { region }) as TClient;
		}

		public static TClient CreateServiceFromAssembly<TClient>(string assemblyName, string serviceClientClassName, AWSCredentials credentials, RegionEndpoint region) where TClient : class
		{
			return LoadServiceClientType(assemblyName, serviceClientClassName).GetConstructor(new ITypeInfo[2]
			{
				TypeFactory.GetTypeInfo(typeof(AWSCredentials)),
				TypeFactory.GetTypeInfo(typeof(RegionEndpoint))
			}).Invoke(new object[2] { credentials, region }) as TClient;
		}

		public static TClient CreateServiceFromAssembly<TClient>(string assemblyName, string serviceClientClassName, AWSCredentials credentials, ClientConfig config) where TClient : class
		{
			return LoadServiceClientType(assemblyName, serviceClientClassName).GetConstructor(new ITypeInfo[2]
			{
				TypeFactory.GetTypeInfo(typeof(AWSCredentials)),
				TypeFactory.GetTypeInfo(config.GetType())
			}).Invoke(new object[2] { credentials, config }) as TClient;
		}

		public static TClient CreateServiceFromAssembly<TClient>(string assemblyName, string serviceClientClassName, AmazonServiceClient originalServiceClient) where TClient : class
		{
			ITypeInfo typeInfo = LoadServiceClientType(assemblyName, serviceClientClassName);
			ClientConfig clientConfig = CreateServiceConfig(assemblyName, serviceClientClassName.Replace("Client", "Config"));
			originalServiceClient.CloneConfig(clientConfig);
			return typeInfo.GetConstructor(new ITypeInfo[2]
			{
				TypeFactory.GetTypeInfo(typeof(AWSCredentials)),
				TypeFactory.GetTypeInfo(clientConfig.GetType())
			}).Invoke(new object[2] { originalServiceClient.Credentials, clientConfig }) as TClient;
		}

		public static ClientConfig CreateServiceConfig(string assemblyName, string serviceConfigClassName)
		{
			return LoadServiceConfigType(assemblyName, serviceConfigClassName).GetConstructor(new ITypeInfo[0]).Invoke(new object[0]) as ClientConfig;
		}

		private static ITypeInfo LoadServiceClientType(string assemblyName, string serviceClientClassName)
		{
			return TypeFactory.GetTypeInfo(GetSDKAssembly(assemblyName).GetType(serviceClientClassName));
		}

		private static ITypeInfo LoadServiceConfigType(string assemblyName, string serviceConfigClassName)
		{
			return TypeFactory.GetTypeInfo(GetSDKAssembly(assemblyName).GetType(serviceConfigClassName));
		}

		private static Assembly GetSDKAssembly(string assemblyName)
		{
			Assembly assembly = null;
			if (assembly == null)
			{
				assembly = Assembly.Load(new AssemblyName(assemblyName));
			}
			if (assembly == null)
			{
				throw new AmazonClientException(string.Format(CultureInfo.InvariantCulture, "Failed to load assembly. Be sure to include a reference to {0}.", assemblyName));
			}
			return assembly;
		}
	}
	internal class ServiceMetadata : IServiceMetadata
	{
		public string ServiceId { get; }

		public IDictionary<string, string> OperationNameMapping { get; } = new Dictionary<string, string>();
	}
	internal class StreamReadTracker
	{
		private object sender;

		private EventHandler<StreamTransferProgressArgs> callback;

		private long contentLength;

		private long totalBytesRead;

		private long totalIncrementTransferred;

		private long progressUpdateInterval;

		internal StreamReadTracker(object sender, EventHandler<StreamTransferProgressArgs> callback, long contentLength, long progressUpdateInterval)
		{
			this.sender = sender;
			this.callback = callback;
			this.contentLength = contentLength;
			this.progressUpdateInterval = progressUpdateInterval;
		}

		public void ReadProgress(int bytesRead)
		{
			checked
			{
				if (callback != null && bytesRead > 0)
				{
					totalBytesRead += bytesRead;
					totalIncrementTransferred += bytesRead;
					if (totalIncrementTransferred >= progressUpdateInterval || totalBytesRead == contentLength)
					{
						AWSSDKUtils.InvokeInBackground(callback, new StreamTransferProgressArgs(totalIncrementTransferred, totalBytesRead, contentLength), sender);
						totalIncrementTransferred = 0L;
					}
				}
			}
		}

		public void UpdateProgress(float progress)
		{
			int bytesRead = checked((int)((long)(progress * (float)contentLength) - totalBytesRead));
			ReadProgress(bytesRead);
		}
	}
	public static class AsyncRunner
	{
		public static Task Run(Action action, CancellationToken cancellationToken)
		{
			return Run(delegate
			{
				action();
				return (object)null;
			}, cancellationToken);
		}

		public static Task<T> Run<T>(Func<T> action, CancellationToken cancellationToken)
		{
			return Task.Run(action);
		}
	}
	public class RequestContext : IRequestContext
	{
		private IServiceMetadata _serviceMetadata;

		private AbstractAWSSigner clientSigner;

		public IRequest Request { get; set; }

		public RequestMetrics Metrics { get; private set; }

		public IClientConfig ClientConfig { get; set; }

		public int Retries { get; set; }

		public CapacityManager.CapacityType LastCapacityType { get; set; }

		public int EndpointDiscoveryRetries { get; set; }

		public bool IsSigned { get; set; }

		public bool IsAsync { get; set; }

		public AmazonWebServiceRequest OriginalRequest { get; set; }

		public IMarshaller<IRequest, AmazonWebServiceRequest> Marshaller { get; set; }

		public ResponseUnmarshaller Unmarshaller { get; set; }

		public InvokeOptionsBase Options { get; set; }

		public ImmutableCredentials ImmutableCredentials { get; set; }

		public AbstractAWSSigner Signer
		{
			get
			{
				AbstractAWSSigner abstractAWSSigner = ((OriginalRequest == null) ? null : OriginalRequest.GetSigner());
				if (abstractAWSSigner == null)
				{
					return clientSigner;
				}
				return abstractAWSSigner;
			}
		}

		public CancellationToken CancellationToken { get; set; }

		public string RequestName => OriginalRequest.GetType().Name;

		public IServiceMetadata ServiceMetaData
		{
			get
			{
				return _serviceMetadata;
			}
			internal set
			{
				_serviceMetadata = value;
			}
		}

		public bool CSMEnabled { get; private set; }

		public bool IsLastExceptionRetryable { get; set; }

		public RequestContext(bool enableMetrics, AbstractAWSSigner clientSigner)
		{
			if (clientSigner == null)
			{
				throw new ArgumentNullException("clientSigner");
			}
			this.clientSigner = clientSigner;
			Metrics = new RequestMetrics();
			Metrics.IsEnabled = enableMetrics;
		}
	}
	public class AsyncRequestContext : RequestContext, IAsyncRequestContext, IRequestContext
	{
		public AsyncCallback Callback { get; set; }

		public object State { get; set; }

		public AsyncRequestContext(bool enableMetrics, AbstractAWSSigner clientSigner)
			: base(enableMetrics, clientSigner)
		{
		}
	}
	public class ResponseContext : IResponseContext
	{
		public AmazonWebServiceResponse Response { get; set; }

		public IWebResponseData HttpResponse { get; set; }
	}
	public class AsyncResponseContext : ResponseContext, IAsyncResponseContext, IResponseContext
	{
	}
	public class ExecutionContext : IExecutionContext
	{
		public IRequestContext RequestContext { get; private set; }

		public IResponseContext ResponseContext { get; private set; }

		public ExecutionContext(bool enableMetrics, AbstractAWSSigner clientSigner)
		{
			RequestContext = new RequestContext(enableMetrics, clientSigner);
			ResponseContext = new ResponseContext();
		}

		public ExecutionContext(IRequestContext requestContext, IResponseContext responseContext)
		{
			RequestContext = requestContext;
			ResponseContext = responseContext;
		}

		public static IExecutionContext CreateFromAsyncContext(IAsyncExecutionContext asyncContext)
		{
			return new ExecutionContext(asyncContext.RequestContext, asyncContext.ResponseContext);
		}
	}
	public class AsyncExecutionContext : IAsyncExecutionContext
	{
		public IAsyncResponseContext ResponseContext { get; private set; }

		public IAsyncRequestContext RequestContext { get; private set; }

		public object RuntimeState { get; set; }

		public AsyncExecutionContext(bool enableMetrics, AbstractAWSSigner clientSigner)
		{
			RequestContext = new AsyncRequestContext(enableMetrics, clientSigner);
			ResponseContext = new AsyncResponseContext();
		}

		public AsyncExecutionContext(IAsyncRequestContext requestContext, IAsyncResponseContext responseContext)
		{
			RequestContext = requestContext;
			ResponseContext = responseContext;
		}
	}
	public class HttpErrorResponseException : Exception
	{
		public IWebResponseData Response { get; private set; }

		public HttpErrorResponseException(IWebResponseData response)
		{
			Response = response;
		}

		public HttpErrorResponseException(string message, IWebResponseData response)
			: base(message)
		{
			Response = response;
		}

		public HttpErrorResponseException(string message, Exception innerException, IWebResponseData response)
			: base(message, innerException)
		{
			Response = response;
		}
	}
	public abstract class PipelineHandler : IPipelineHandler
	{
		public virtual ILogger Logger { get; set; }

		public IPipelineHandler InnerHandler { get; set; }

		public IPipelineHandler OuterHandler { get; set; }

		public virtual void InvokeSync(IExecutionContext executionContext)
		{
			if (InnerHandler != null)
			{
				InnerHandler.InvokeSync(executionContext);
				return;
			}
			throw new InvalidOperationException("Cannot invoke InnerHandler. InnerHandler is not set.");
		}

		[DebuggerHidden]
		public virtual Task<T> InvokeAsync<T>(IExecutionContext executionContext) where T : AmazonWebServiceResponse, new()
		{
			if (InnerHandler != null)
			{
				return InnerHandler.InvokeAsync<T>(executionContext);
			}
			throw new InvalidOperationException("Cannot invoke InnerHandler. InnerHandler is not set.");
		}

		protected void LogMetrics(IExecutionContext executionContext)
		{
			RequestMetrics metrics = executionContext.RequestContext.Metrics;
			if (executionContext.RequestContext.ClientConfig.LogMetrics)
			{
				string errors = metrics.GetErrors();
				if (!string.IsNullOrEmpty(errors))
				{
					Logger.InfoFormat("Request metrics errors: {0}", errors);
				}
				Logger.InfoFormat("Request metrics: {0}", metrics);
			}
		}
	}
	public class RuntimePipeline : IDisposable
	{
		private bool _disposed;

		private ILogger _logger;

		private IPipelineHandler _handler;

		public IPipelineHandler Handler => _handler;

		public List<IPipelineHandler> Handlers => EnumerateHandlers().ToList();

		public RuntimePipeline(IPipelineHandler handler)
		{
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			Logger logger = Logger.GetLogger(typeof(RuntimePipeline));
			_handler = handler;
			_handler.Logger = logger;
			_logger = logger;
		}

		public RuntimePipeline(IList<IPipelineHandler> handlers)
			: this(handlers, Logger.GetLogger(typeof(RuntimePipeline)))
		{
		}

		public RuntimePipeline(IList<IPipelineHandler> handlers, ILogger logger)
		{
			if (handlers == null || handlers.Count == 0)
			{
				throw new ArgumentNullException("handlers");
			}
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			_logger = logger;
			foreach (IPipelineHandler handler in handlers)
			{
				AddHandler(handler);
			}
		}

		public RuntimePipeline(IPipelineHandler handler, ILogger logger)
		{
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			if (logger == null)
			{
				throw new ArgumentNullException("logger");
			}
			_handler = handler;
			_handler.Logger = logger;
			_logger = logger;
		}

		public IResponseContext InvokeSync(IExecutionContext executionContext)
		{
			ThrowIfDisposed();
			_handler.InvokeSync(executionContext);
			return executionContext.ResponseContext;
		}

		public Task<T> InvokeAsync<T>(IExecutionContext executionContext) where T : AmazonWebServiceResponse, new()
		{
			ThrowIfDisposed();
			return _handler.InvokeAsync<T>(executionContext);
		}

		public void AddHandler(IPipelineHandler handler)
		{
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			ThrowIfDisposed();
			IPipelineHandler innermostHandler = GetInnermostHandler(handler);
			if (_handler != null)
			{
				innermostHandler.InnerHandler = _handler;
				_handler.OuterHandler = innermostHandler;
			}
			_handler = handler;
			SetHandlerProperties(handler);
		}

		public void AddHandlerAfter<T>(IPipelineHandler handler) where T : IPipelineHandler
		{
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			ThrowIfDisposed();
			Type typeFromHandle = typeof(T);
			for (IPipelineHandler pipelineHandler = _handler; pipelineHandler != null; pipelineHandler = pipelineHandler.InnerHandler)
			{
				if (pipelineHandler.GetType() == typeFromHandle)
				{
					InsertHandler(handler, pipelineHandler);
					SetHandlerProperties(handler);
					return;
				}
			}
			throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Cannot find a handler of type {0}", typeFromHandle.Name));
		}

		public void AddHandlerBefore<T>(IPipelineHandler handler) where T : IPipelineHandler
		{
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			ThrowIfDisposed();
			Type typeFromHandle = typeof(T);
			if (_handler.GetType() == typeFromHandle)
			{
				AddHandler(handler);
				SetHandlerProperties(handler);
				return;
			}
			for (IPipelineHandler pipelineHandler = _handler; pipelineHandler != null; pipelineHandler = pipelineHandler.InnerHandler)
			{
				if (pipelineHandler.InnerHandler != null && pipelineHandler.InnerHandler.GetType() == typeFromHandle)
				{
					InsertHandler(handler, pipelineHandler);
					SetHandlerProperties(handler);
					return;
				}
			}
			throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Cannot find a handler of type {0}", typeFromHandle.Name));
		}

		public void RemoveHandler<T>()
		{
			ThrowIfDisposed();
			Type typeFromHandle = typeof(T);
			for (IPipelineHandler pipelineHandler = _handler; pipelineHandler != null; pipelineHandler = pipelineHandler.InnerHandler)
			{
				if (pipelineHandler.GetType() == typeFromHandle)
				{
					if (pipelineHandler == _handler && _handler.InnerHandler == null)
					{
						throw new InvalidOperationException("The pipeline contains a single handler, cannot remove the only handler in the pipeline.");
					}
					if (pipelineHandler == _handler)
					{
						_handler = pipelineHandler.InnerHandler;
					}
					if (pipelineHandler.OuterHandler != null)
					{
						pipelineHandler.OuterHandler.InnerHandler = pipelineHandler.InnerHandler;
					}
					if (pipelineHandler.InnerHandler != null)
					{
						pipelineHandler.InnerHandler.OuterHandler = pipelineHandler.OuterHandler;
					}
					pipelineHandler.InnerHandler = null;
					pipelineHandler.OuterHandler = null;
					return;
				}
			}
			throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Cannot find a handler of type {0}", typeFromHandle.Name));
		}

		public void ReplaceHandler<T>(IPipelineHandler handler) where T : IPipelineHandler
		{
			if (handler == null)
			{
				throw new ArgumentNullException("handler");
			}
			ThrowIfDisposed();
			Type typeFromHandle = typeof(T);
			IPipelineHandler pipelineHandler = null;
			for (IPipelineHandler pipelineHandler2 = _handler; pipelineHandler2 != null; pipelineHandler2 = pipelineHandler2.InnerHandler)
			{
				if (pipelineHandler2.GetType() == typeFromHandle)
				{
					handler.InnerHandler = pipelineHandler2.InnerHandler;
					handler.OuterHandler = pipelineHandler2.OuterHandler;
					if (pipelineHandler != null)
					{
						pipelineHandler.InnerHandler = handler;
					}
					else
					{
						_handler = handler;
					}
					if (pipelineHandler2.InnerHandler != null)
					{
						pipelineHandler2.InnerHandler.OuterHandler = handler;
					}
					pipelineHandler2.InnerHandler = null;
					pipelineHandler2.OuterHandler = null;
					SetHandlerProperties(handler);
					return;
				}
				pipelineHandler = pipelineHandler2;
			}
			throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Cannot find a handler of type {0}", typeFromHandle.Name));
		}

		private static void InsertHandler(IPipelineHandler handler, IPipelineHandler current)
		{
			IPipelineHandler innerHandler = current.InnerHandler;
			current.InnerHandler = handler;
			handler.OuterHandler = current;
			if (innerHandler != null)
			{
				IPipelineHandler innermostHandler = GetInnermostHandler(handler);
				innermostHandler.InnerHandler = innerHandler;
				innerHandler.OuterHandler = innermostHandler;
			}
		}

		private static IPipelineHandler GetInnermostHandler(IPipelineHandler handler)
		{
			IPipelineHandler pipelineHandler = handler;
			while (pipelineHandler.InnerHandler != null)
			{
				pipelineHandler = pipelineHandler.InnerHandler;
			}
			return pipelineHandler;
		}

		private void SetHandlerProperties(IPipelineHandler handler)
		{
			ThrowIfDisposed();
			handler.Logger = _logger;
		}

		public IEnumerable<IPipelineHandler> EnumerateHandlers()
		{
			for (IPipelineHandler handler = Handler; handler != null; handler = handler.InnerHandler)
			{
				yield return handler;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (_disposed || !disposing)
			{
				return;
			}
			IPipelineHandler pipelineHandler = Handler;
			while (pipelineHandler != null)
			{
				IPipelineHandler innerHandler = pipelineHandler.InnerHandler;
				if (pipelineHandler is IDisposable disposable)
				{
					disposable.Dispose();
				}
				pipelineHandler = innerHandler;
			}
			_disposed = true;
		}

		private void ThrowIfDisposed()
		{
			if (_disposed)
			{
				throw new ObjectDisposedException(GetType().FullName);
			}
		}
	}
	public class ErrorHandler : PipelineHandler
	{
		private IDictionary<Type, IExceptionHandler> _exceptionHandlers;

		public IDictionary<Type, IExceptionHandler> ExceptionHandlers => _exceptionHandlers;

		public ErrorHandler(ILogger logger)
		{
			Logger = logger;
			_exceptionHandlers = new Dictionary<Type, IExceptionHandler> { 
			{
				typeof(HttpErrorResponseException),
				new HttpErrorResponseExceptionHandler(Logger)
			} };
		}

		public override void InvokeSync(IExecutionContext executionContext)
		{
			try
			{
				base.InvokeSync(executionContext);
			}
			catch (Exception exception)
			{
				DisposeReponse(executionContext.ResponseContext);
				if (ProcessException(executionContext, exception))
				{
					throw;
				}
			}
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			try
			{
				return await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception exception)
			{
				DisposeReponse(executionContext.ResponseContext);
				if (ProcessException(executionContext, exception))
				{
					throw;
				}
			}
			if (executionContext.ResponseContext != null && executionContext.ResponseContext.Response != null)
			{
				return executionContext.ResponseContext.Response as T;
			}
			return null;
		}

		private static void DisposeReponse(IResponseContext responseContext)
		{
			if (responseContext.HttpResponse != null && responseContext.HttpResponse.ResponseBody != null)
			{
				responseContext.HttpResponse.ResponseBody.Dispose();
			}
		}

		private bool ProcessException(IExecutionContext executionContext, Exception exception)
		{
			Logger.Error(exception, "An exception of type {0} was handled in ErrorHandler.", exception.GetType().Name);
			executionContext.RequestContext.Metrics.AddProperty(Metric.Exception, exception);
			Type type = exception.GetType();
			ITypeInfo typeInfo = TypeFactory.GetTypeInfo(exception.GetType());
			do
			{
				IExceptionHandler value = null;
				if (ExceptionHandlers.TryGetValue(type, out value))
				{
					return value.Handle(executionContext, exception);
				}
				type = typeInfo.BaseType;
				typeInfo = TypeFactory.GetTypeInfo(typeInfo.BaseType);
			}
			while (type != typeof(Exception));
			return true;
		}
	}
	public abstract class ExceptionHandler<T> : IExceptionHandler<T>, IExceptionHandler where T : Exception
	{
		private ILogger _logger;

		protected ILogger Logger => _logger;

		protected ExceptionHandler(ILogger logger)
		{
			_logger = logger;
		}

		public bool Handle(IExecutionContext executionContext, Exception exception)
		{
			return HandleException(executionContext, exception as T);
		}

		public abstract bool HandleException(IExecutionContext executionContext, T exception);
	}
	public class HttpErrorResponseExceptionHandler : ExceptionHandler<HttpErrorResponseException>
	{
		public HttpErrorResponseExceptionHandler(ILogger logger)
			: base(logger)
		{
		}

		public override bool HandleException(IExecutionContext executionContext, HttpErrorResponseException exception)
		{
			IRequestContext requestContext = executionContext.RequestContext;
			IWebResponseData response = exception.Response;
			if (HandleSuppressed404(executionContext, response))
			{
				return false;
			}
			requestContext.Metrics.AddProperty(Metric.StatusCode, response.StatusCode);
			AmazonServiceException ex = null;
			try
			{
				using (response.ResponseBody)
				{
					ResponseUnmarshaller unmarshaller = requestContext.Unmarshaller;
					UnmarshallerContext unmarshallerContext = unmarshaller.CreateContext(response, readEntireResponse: true, response.ResponseBody.OpenResponse(), requestContext.Metrics, isException: true);
					try
					{
						ex = unmarshaller.UnmarshallException(unmarshallerContext, exception, response.StatusCode);
					}
					catch (Exception ex2)
					{
						if (ex2 is AmazonServiceException || ex2 is AmazonClientException)
						{
							throw;
						}
						string headerValue = response.GetHeaderValue("x-amzn-RequestId");
						string responseBody = unmarshallerContext.ResponseBody;
						throw new AmazonUnmarshallingException(headerValue, null, responseBody, ex2, response.StatusCode);
					}
					requestContext.Metrics.AddProperty(Metric.AWSRequestID, ex.RequestId);
					requestContext.Metrics.AddProperty(Metric.AWSErrorCode, ex.ErrorCode);
					if (requestContext.ClientConfig.LogResponse || AWSConfigs.LoggingConfig.LogResponses != ResponseLoggingOption.Never)
					{
						base.Logger.Error(ex, "Received error response: [{0}]", unmarshallerContext.ResponseBody);
					}
				}
			}
			catch (Exception exception2)
			{
				base.Logger.Error(exception2, "Failed to unmarshall a service error response.");
				throw;
			}
			throw ex;
		}

		private bool HandleSuppressed404(IExecutionContext executionContext, IWebResponseData httpErrorResponse)
		{
			IRequestContext requestContext = executionContext.RequestContext;
			IResponseContext responseContext = executionContext.ResponseContext;
			if (httpErrorResponse != null && httpErrorResponse.StatusCode == HttpStatusCode.NotFound && requestContext.Request.Suppress404Exceptions)
			{
				using (httpErrorResponse.ResponseBody)
				{
					ResponseUnmarshaller unmarshaller = requestContext.Unmarshaller;
					bool readEntireResponse = requestContext.ClientConfig.LogResponse || AWSConfigs.LoggingConfig.LogResponses != ResponseLoggingOption.Never;
					UnmarshallerContext input = unmarshaller.CreateContext(httpErrorResponse, readEntireResponse, httpErrorResponse.ResponseBody.OpenResponse(), requestContext.Metrics, isException: true);
					try
					{
						responseContext.Response = unmarshaller.Unmarshall(input);
						responseContext.Response.ContentLength = httpErrorResponse.ContentLength;
						responseContext.Response.HttpStatusCode = httpErrorResponse.StatusCode;
						return true;
					}
					catch (Exception exception)
					{
						base.Logger.Debug(exception, "Failed to unmarshall 404 response when it was supressed.");
					}
				}
			}
			return false;
		}
	}
	public class CallbackHandler : PipelineHandler
	{
		public Action<IExecutionContext> OnPreInvoke { get; set; }

		public Action<IExecutionContext> OnPostInvoke { get; set; }

		public override void InvokeSync(IExecutionContext executionContext)
		{
			PreInvoke(executionContext);
			base.InvokeSync(executionContext);
			PostInvoke(executionContext);
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			PreInvoke(executionContext);
			T result = await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
			PostInvoke(executionContext);
			return result;
		}

		protected void PreInvoke(IExecutionContext executionContext)
		{
			RaiseOnPreInvoke(executionContext);
		}

		protected void PostInvoke(IExecutionContext executionContext)
		{
			RaiseOnPostInvoke(executionContext);
		}

		private void RaiseOnPreInvoke(IExecutionContext context)
		{
			if (OnPreInvoke != null)
			{
				OnPreInvoke(context);
			}
		}

		private void RaiseOnPostInvoke(IExecutionContext context)
		{
			if (OnPostInvoke != null)
			{
				OnPostInvoke(context);
			}
		}
	}
	public class CredentialsRetriever : PipelineHandler
	{
		protected AWSCredentials Credentials { get; private set; }

		public CredentialsRetriever(AWSCredentials credentials)
		{
			Credentials = credentials;
		}

		protected virtual void PreInvoke(IExecutionContext executionContext)
		{
			ImmutableCredentials immutableCredentials = null;
			if (Credentials != null && !(Credentials is AnonymousAWSCredentials))
			{
				using (executionContext.RequestContext.Metrics.StartEvent(Metric.CredentialsRequestTime))
				{
					immutableCredentials = Credentials.GetCredentials();
				}
			}
			executionContext.RequestContext.ImmutableCredentials = immutableCredentials;
		}

		public override void InvokeSync(IExecutionContext executionContext)
		{
			PreInvoke(executionContext);
			base.InvokeSync(executionContext);
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			ImmutableCredentials immutableCredentials = null;
			if (Credentials != null && !(Credentials is AnonymousAWSCredentials))
			{
				using (executionContext.RequestContext.Metrics.StartEvent(Metric.CredentialsRequestTime))
				{
					immutableCredentials = await Credentials.GetCredentialsAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			executionContext.RequestContext.ImmutableCredentials = immutableCredentials;
			return await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
		}
	}
	public class EndpointDiscoveryHandler : PipelineHandler
	{
		private const int INVALID_ENDPOINT_EXCEPTION_STATUSCODE = 421;

		public override void InvokeSync(IExecutionContext executionContext)
		{
			IRequestContext requestContext = executionContext.RequestContext;
			System.Uri endpoint = requestContext.Request.Endpoint;
			PreInvoke(executionContext);
			try
			{
				base.InvokeSync(executionContext);
			}
			catch (Exception exception)
			{
				if (IsInvalidEndpointException(exception))
				{
					EvictCacheKeyForRequest(requestContext, endpoint);
				}
				throw;
			}
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			IRequestContext requestContext = executionContext.RequestContext;
			System.Uri regionalEndpoint = requestContext.Request.Endpoint;
			PreInvoke(executionContext);
			try
			{
				return await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception source)
			{
				ExceptionDispatchInfo exceptionDispatchInfo = ExceptionDispatchInfo.Capture(source);
				if (IsInvalidEndpointException(exceptionDispatchInfo.SourceException))
				{
					EvictCacheKeyForRequest(requestContext, regionalEndpoint);
				}
				exceptionDispatchInfo.Throw();
			}
			throw new AmazonClientException("Neither a response was returned nor an exception was thrown in the Runtime EndpointDiscoveryResolver.");
		}

		protected static void PreInvoke(IExecutionContext executionContext)
		{
			DiscoverEndpoints(executionContext.RequestContext, evictCacheKey: false);
		}

		public static void EvictCacheKeyForRequest(IRequestContext requestContext, System.Uri regionalEndpoint)
		{
			DiscoverEndpoints(requestContext, evictCacheKey: true);
			requestContext.Request.Endpoint = regionalEndpoint;
		}

		public static void DiscoverEndpoints(IRequestContext requestContext, bool evictCacheKey)
		{
			IEnumerable<DiscoveryEndpointBase> enumerable = ProcessEndpointDiscovery(requestContext, evictCacheKey, requestContext.Request.Endpoint);
			if (enumerable == null)
			{
				return;
			}
			foreach (DiscoveryEndpointBase item in enumerable)
			{
				if (item.Address != null)
				{
					requestContext.Request.Endpoint = new System.Uri(item.Address);
					break;
				}
			}
		}

		private static IEnumerable<DiscoveryEndpointBase> ProcessEndpointDiscovery(IRequestContext requestContext, bool evictCacheKey, System.Uri evictUri)
		{
			InvokeOptionsBase options = requestContext.Options;
			if (options.EndpointDiscoveryMarshaller != null && options.EndpointOperation != null && requestContext.ImmutableCredentials != null)
			{
				EndpointDiscoveryDataBase endpointDiscoveryDataBase = options.EndpointDiscoveryMarshaller.Marshall(requestContext.OriginalRequest);
				string operationName = string.Empty;
				if (endpointDiscoveryDataBase.Identifiers != null && endpointDiscoveryDataBase.Identifiers.Count > 0)
				{
					operationName = OperationNameFromRequestName(requestContext.RequestName);
				}
				return options.EndpointOperation(new EndpointOperationContext(requestContext.ImmutableCredentials.AccessKey, operationName, endpointDiscoveryDataBase, evictCacheKey, evictUri));
			}
			return null;
		}

		private static string OperationNameFromRequestName(string requestName)
		{
			if (requestName.EndsWith("Request", StringComparison.Ordinal))
			{
				return requestName.Substring(0, checked(requestName.Length - 7));
			}
			return requestName;
		}

		private static bool IsInvalidEndpointException(Exception exception)
		{
			if (exception is AmazonServiceException { StatusCode: HttpStatusCode.MisdirectedRequest })
			{
				return true;
			}
			return false;
		}
	}
	public class EndpointResolver : PipelineHandler
	{
		public override void InvokeSync(IExecutionContext executionContext)
		{
			PreInvoke(executionContext);
			base.InvokeSync(executionContext);
		}

		public override Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			PreInvoke(executionContext);
			return base.InvokeAsync<T>(executionContext);
		}

		protected void PreInvoke(IExecutionContext executionContext)
		{
			IRequestContext requestContext = executionContext.RequestContext;
			if (requestContext.Request.Endpoint == null)
			{
				requestContext.Request.Endpoint = DetermineEndpoint(executionContext.RequestContext);
			}
		}

		public virtual System.Uri DetermineEndpoint(IRequestContext requestContext)
		{
			return DetermineEndpoint(requestContext.ClientConfig, requestContext.Request);
		}

		public static System.Uri DetermineEndpoint(IClientConfig config, IRequest request)
		{
			System.Uri endpoint = ((request.AlternateEndpoint != null) ? new System.Uri(ClientConfig.GetUrl(request.AlternateEndpoint, config.RegionEndpointServiceName, config.UseHttp, config.UseDualstackEndpoint)) : new System.Uri(config.DetermineServiceURL()));
			return InjectHostPrefix(config, request, endpoint);
		}

		private static System.Uri InjectHostPrefix(IClientConfig config, IRequest request, System.Uri endpoint)
		{
			if (config.DisableHostPrefixInjection || string.IsNullOrEmpty(request.HostPrefix))
			{
				return endpoint;
			}
			UriBuilder uriBuilder = new UriBuilder(endpoint);
			uriBuilder.Host = request.HostPrefix + uriBuilder.Host;
			return uriBuilder.Uri;
		}
	}
	public class ErrorCallbackHandler : PipelineHandler
	{
		public Action<IExecutionContext, Exception> OnError { get; set; }

		public override void InvokeSync(IExecutionContext executionContext)
		{
			try
			{
				base.InvokeSync(executionContext);
			}
			catch (Exception exception)
			{
				HandleException(executionContext, exception);
				throw;
			}
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			try
			{
				return await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch (Exception exception)
			{
				HandleException(executionContext, exception);
				throw;
			}
		}

		protected void HandleException(IExecutionContext executionContext, Exception exception)
		{
			OnError(executionContext, exception);
		}
	}
	public class Marshaller : PipelineHandler
	{
		public override void InvokeSync(IExecutionContext executionContext)
		{
			PreInvoke(executionContext);
			base.InvokeSync(executionContext);
		}

		public override Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			PreInvoke(executionContext);
			return base.InvokeAsync<T>(executionContext);
		}

		protected static void PreInvoke(IExecutionContext executionContext)
		{
			IRequestContext requestContext = executionContext.RequestContext;
			requestContext.Request = requestContext.Marshaller.Marshall(requestContext.OriginalRequest);
			requestContext.Request.AuthenticationRegion = requestContext.ClientConfig.AuthenticationRegion;
			string key = "User-Agent";
			requestContext.Request.Headers[key] = requestContext.ClientConfig.UserAgent + " " + (executionContext.RequestContext.IsAsync ? "ClientAsync" : "ClientSync");
			string text = requestContext.Request.HttpMethod.ToUpper(CultureInfo.InvariantCulture);
			if (text != "GET" && text != "DELETE" && text != "HEAD" && !requestContext.Request.Headers.ContainsKey("Content-Type"))
			{
				if (requestContext.Request.UseQueryString)
				{
					requestContext.Request.Headers["Content-Type"] = "application/x-amz-json-1.0";
				}
				else
				{
					requestContext.Request.Headers["Content-Type"] = "application/x-www-form-urlencoded; charset=utf-8";
				}
			}
		}
	}
	public class MetricsHandler : PipelineHandler
	{
		public override void InvokeSync(IExecutionContext executionContext)
		{
			executionContext.RequestContext.Metrics.AddProperty(Metric.AsyncCall, false);
			try
			{
				executionContext.RequestContext.Metrics.StartEvent(Metric.ClientExecuteTime);
				base.InvokeSync(executionContext);
			}
			finally
			{
				executionContext.RequestContext.Metrics.StopEvent(Metric.ClientExecuteTime);
				LogMetrics(executionContext);
			}
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			executionContext.RequestContext.Metrics.AddProperty(Metric.AsyncCall, true);
			try
			{
				executionContext.RequestContext.Metrics.StartEvent(Metric.ClientExecuteTime);
				return await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
			}
			finally
			{
				executionContext.RequestContext.Metrics.StopEvent(Metric.ClientExecuteTime);
				LogMetrics(executionContext);
			}
		}
	}
	public class RedirectHandler : PipelineHandler
	{
		public override void InvokeSync(IExecutionContext executionContext)
		{
			do
			{
				base.InvokeSync(executionContext);
			}
			while (HandleRedirect(executionContext));
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			T result;
			do
			{
				result = await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
			}
			while (HandleRedirect(executionContext));
			return result;
		}

		private bool HandleRedirect(IExecutionContext executionContext)
		{
			IWebResponseData httpResponse = executionContext.ResponseContext.HttpResponse;
			if (httpResponse.StatusCode >= HttpStatusCode.MultipleChoices && httpResponse.StatusCode < HttpStatusCode.BadRequest)
			{
				if (httpResponse.StatusCode == HttpStatusCode.TemporaryRedirect && httpResponse.IsHeaderPresent("location"))
				{
					IRequestContext requestContext = executionContext.RequestContext;
					string headerValue = httpResponse.GetHeaderValue("location");
					requestContext.Metrics.AddProperty(Metric.RedirectLocation, headerValue);
					if (executionContext.RequestContext.Request.IsRequestStreamRewindable() && !string.IsNullOrEmpty(headerValue))
					{
						FinalizeForRedirect(executionContext, headerValue);
						if (httpResponse.ResponseBody != null)
						{
							httpResponse.ResponseBody.Dispose();
						}
						return true;
					}
				}
				executionContext.ResponseContext.HttpResponse = null;
				throw new HttpErrorResponseException(httpResponse);
			}
			return false;
		}

		protected virtual void FinalizeForRedirect(IExecutionContext executionContext, string redirectedLocation)
		{
			Logger.InfoFormat("Request {0} is being redirected to {1}.", executionContext.RequestContext.RequestName, redirectedLocation);
			System.Uri uri = new System.Uri(redirectedLocation);
			executionContext.RequestContext.Request.Endpoint = new UriBuilder(uri.Scheme, uri.Host).Uri;
			RetryHandler.PrepareForRetry(executionContext.RequestContext);
		}
	}
	public class Signer : PipelineHandler
	{
		public override void InvokeSync(IExecutionContext executionContext)
		{
			PreInvoke(executionContext);
			base.InvokeSync(executionContext);
		}

		public override Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			PreInvoke(executionContext);
			return base.InvokeAsync<T>(executionContext);
		}

		protected static void PreInvoke(IExecutionContext executionContext)
		{
			if (ShouldSign(executionContext.RequestContext))
			{
				SignRequest(executionContext.RequestContext);
				executionContext.RequestContext.IsSigned = true;
			}
		}

		private static bool ShouldSign(IRequestContext requestContext)
		{
			if (requestContext.IsSigned)
			{
				return requestContext.ClientConfig.ResignRetries;
			}
			return true;
		}

		public static void SignRequest(IRequestContext requestContext)
		{
			ImmutableCredentials immutableCredentials = requestContext.ImmutableCredentials;
			if (immutableCredentials == null)
			{
				return;
			}
			using (requestContext.Metrics.StartEvent(Metric.RequestSigningTime))
			{
				if (immutableCredentials.UseToken && !(requestContext.Signer is NullSigner))
				{
					switch (requestContext.Signer.Protocol)
					{
					case ClientProtocol.QueryStringProtocol:
						requestContext.Request.Parameters["SecurityToken"] = immutableCredentials.Token;
						break;
					case ClientProtocol.RestProtocol:
						requestContext.Request.Headers["x-amz-security-token"] = immutableCredentials.Token;
						break;
					default:
						throw new InvalidDataException("Cannot determine protocol");
					}
				}
				requestContext.Signer.Sign(requestContext.Request, requestContext.ClientConfig, requestContext.Metrics, immutableCredentials.AccessKey, immutableCredentials.SecretKey);
			}
		}
	}
	public class Unmarshaller : PipelineHandler
	{
		private bool _supportsResponseLogging;

		public Unmarshaller(bool supportsResponseLogging)
		{
			_supportsResponseLogging = supportsResponseLogging;
		}

		public override void InvokeSync(IExecutionContext executionContext)
		{
			base.InvokeSync(executionContext);
			if (executionContext.ResponseContext.HttpResponse.IsSuccessStatusCode)
			{
				Unmarshall(executionContext);
			}
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
			await UnmarshallAsync(executionContext).ConfigureAwait(continueOnCapturedContext: false);
			return (T)executionContext.ResponseContext.Response;
		}

		private void Unmarshall(IExecutionContext executionContext)
		{
			IRequestContext requestContext = executionContext.RequestContext;
			IResponseContext responseContext = executionContext.ResponseContext;
			using (requestContext.Metrics.StartEvent(Metric.ResponseProcessingTime))
			{
				ResponseUnmarshaller unmarshaller = requestContext.Unmarshaller;
				try
				{
					bool supportsResponseLogging = _supportsResponseLogging;
					UnmarshallerContext unmarshallerContext = unmarshaller.CreateContext(responseContext.HttpResponse, supportsResponseLogging, responseContext.HttpResponse.ResponseBody.OpenResponse(), requestContext.Metrics, isException: false);
					try
					{
						AmazonWebServiceResponse response = UnmarshallResponse(unmarshallerContext, requestContext);
						responseContext.Response = response;
					}
					catch (Exception ex)
					{
						if (ex is AmazonServiceException || ex is AmazonClientException)
						{
							throw;
						}
						string headerValue = responseContext.HttpResponse.GetHeaderValue("x-amzn-RequestId");
						string responseBody = unmarshallerContext.ResponseBody;
						throw new AmazonUnmarshallingException(headerValue, null, responseBody, ex, responseContext.HttpResponse.StatusCode);
					}
				}
				finally
				{
					if (!unmarshaller.HasStreamingProperty)
					{
						responseContext.HttpResponse.ResponseBody.Dispose();
					}
				}
			}
		}

		private async Task UnmarshallAsync(IExecutionContext executionContext)
		{
			IRequestContext requestContext = executionContext.RequestContext;
			IResponseContext responseContext = executionContext.ResponseContext;
			using (requestContext.Metrics.StartEvent(Metric.ResponseProcessingTime))
			{
				ResponseUnmarshaller unmarshaller = requestContext.Unmarshaller;
				try
				{
					bool readEntireResponse = _supportsResponseLogging && (requestContext.ClientConfig.LogResponse || requestContext.ClientConfig.ReadEntireResponse || AWSConfigs.LoggingConfig.LogResponses != ResponseLoggingOption.Never);
					Stream stream = await responseContext.HttpResponse.ResponseBody.OpenResponseAsync().ConfigureAwait(continueOnCapturedContext: false);
					UnmarshallerContext context = unmarshaller.CreateContext(responseContext.HttpResponse, readEntireResponse, stream, requestContext.Metrics, isException: false);
					AmazonWebServiceResponse response = UnmarshallResponse(context, requestContext);
					responseContext.Response = response;
				}
				finally
				{
					if (!unmarshaller.HasStreamingProperty)
					{
						responseContext.HttpResponse.ResponseBody.Dispose();
					}
				}
			}
		}

		private AmazonWebServiceResponse UnmarshallResponse(UnmarshallerContext context, IRequestContext requestContext)
		{
			try
			{
				ResponseUnmarshaller unmarshaller = requestContext.Unmarshaller;
				AmazonWebServiceResponse amazonWebServiceResponse = null;
				using (requestContext.Metrics.StartEvent(Metric.ResponseUnmarshallTime))
				{
					amazonWebServiceResponse = unmarshaller.UnmarshallResponse(context);
				}
				requestContext.Metrics.AddProperty(Metric.StatusCode, amazonWebServiceResponse.HttpStatusCode);
				requestContext.Metrics.AddProperty(Metric.BytesProcessed, amazonWebServiceResponse.ContentLength);
				if (amazonWebServiceResponse.ResponseMetadata != null)
				{
					requestContext.Metrics.AddProperty(Metric.AWSRequestID, amazonWebServiceResponse.ResponseMetadata.RequestId);
				}
				context.ValidateCRC32IfAvailable();
				return amazonWebServiceResponse;
			}
			finally
			{
				if (ShouldLogResponseBody(_supportsResponseLogging, requestContext))
				{
					Logger.DebugFormat("Received response (truncated to {0} bytes): [{1}]", AWSConfigs.LoggingConfig.LogResponsesSizeLimit, context.ResponseBody);
				}
			}
		}

		private static bool ShouldLogResponseBody(bool supportsResponseLogging, IRequestContext requestContext)
		{
			if (supportsResponseLogging)
			{
				if (!requestContext.ClientConfig.LogResponse)
				{
					return AWSConfigs.LoggingConfig.LogResponses == ResponseLoggingOption.Always;
				}
				return true;
			}
			return false;
		}
	}
	public class HttpHandler<TRequestContent> : PipelineHandler, IDisposable
	{
		private bool _disposed;

		private IHttpRequestFactory<TRequestContent> _requestFactory;

		public object CallbackSender { get; private set; }

		public HttpHandler(IHttpRequestFactory<TRequestContent> requestFactory, object callbackSender)
		{
			_requestFactory = requestFactory;
			CallbackSender = callbackSender;
		}

		public override void InvokeSync(IExecutionContext executionContext)
		{
			IHttpRequest<TRequestContent> httpRequest = null;
			try
			{
				SetMetrics(executionContext.RequestContext);
				IRequest request = executionContext.RequestContext.Request;
				httpRequest = CreateWebRequest(executionContext.RequestContext);
				httpRequest.SetRequestHeaders(request.Headers);
				using (executionContext.RequestContext.Metrics.StartEvent(Metric.HttpRequestTime))
				{
					if (request.HasRequestBody())
					{
						try
						{
							TRequestContent requestContent = httpRequest.GetRequestContent();
							WriteContentToRequestBody(requestContent, httpRequest, executionContext.RequestContext);
						}
						catch
						{
							CompleteFailedRequest(httpRequest);
							throw;
						}
					}
					executionContext.ResponseContext.HttpResponse = httpRequest.GetResponse();
				}
			}
			finally
			{
				httpRequest?.Dispose();
			}
		}

		private static void CompleteFailedRequest(IHttpRequest<TRequestContent> httpRequest)
		{
			try
			{
				IWebResponseData webResponseData = null;
				try
				{
					webResponseData = httpRequest.GetResponse();
				}
				catch (WebException ex)
				{
					if (ex.Response != null)
					{
						ex.Response.Dispose();
					}
				}
				catch (HttpErrorResponseException ex2)
				{
					if (ex2.Response != null && ex2.Response.ResponseBody != null)
					{
						ex2.Response.ResponseBody.Dispose();
					}
				}
				finally
				{
					if (webResponseData != null && webResponseData.ResponseBody != null)
					{
						webResponseData.ResponseBody.Dispose();
					}
				}
			}
			catch
			{
			}
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			IHttpRequest<TRequestContent> httpRequest = null;
			try
			{
				SetMetrics(executionContext.RequestContext);
				IRequest request = executionContext.RequestContext.Request;
				httpRequest = CreateWebRequest(executionContext.RequestContext);
				httpRequest.SetRequestHeaders(request.Headers);
				using (executionContext.RequestContext.Metrics.StartEvent(Metric.HttpRequestTime))
				{
					if (request.HasRequestBody())
					{
						ExceptionDispatchInfo edi = null;
						try
						{
							WriteContentToRequestBody(await httpRequest.GetRequestContentAsync().ConfigureAwait(continueOnCapturedContext: false), httpRequest, executionContext.RequestContext);
						}
						catch (Exception source)
						{
							edi = ExceptionDispatchInfo.Capture(source);
						}
						if (edi != null)
						{
							await CompleteFailedRequest(executionContext, httpRequest).ConfigureAwait(continueOnCapturedContext: false);
							edi.Throw();
						}
					}
					IWebResponseData httpResponse = await httpRequest.GetResponseAsync(executionContext.RequestContext.CancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					executionContext.ResponseContext.HttpResponse = httpResponse;
				}
				return null;
			}
			finally
			{
				httpRequest?.Dispose();
			}
		}

		private static async Task CompleteFailedRequest(IExecutionContext executionContext, IHttpRequest<TRequestContent> httpRequest)
		{
			IWebResponseData iwrd = null;
			try
			{
				iwrd = await httpRequest.GetResponseAsync(executionContext.RequestContext.CancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			catch
			{
			}
			finally
			{
				if (iwrd != null && iwrd.ResponseBody != null)
				{
					iwrd.ResponseBody.Dispose();
				}
			}
		}

		private static void SetMetrics(IRequestContext requestContext)
		{
			requestContext.Metrics.AddProperty(Metric.ServiceName, requestContext.Request.ServiceName);
			requestContext.Metrics.AddProperty(Metric.ServiceEndpoint, requestContext.Request.Endpoint);
			requestContext.Metrics.AddProperty(Metric.MethodName, requestContext.Request.RequestName);
		}

		private void WriteContentToRequestBody(TRequestContent requestContent, IHttpRequest<TRequestContent> httpRequest, IRequestContext requestContext)
		{
			IRequest request = requestContext.Request;
			if (request.Content != null && request.Content.Length != 0)
			{
				byte[] content = request.Content;
				requestContext.Metrics.AddProperty(Metric.RequestSize, content.Length);
				httpRequest.WriteToRequestBody(requestContent, content, requestContext.Request.Headers);
				return;
			}
			Stream stream;
			if (request.ContentStream == null)
			{
				stream = new MemoryStream();
				stream.Write(request.Content, 0, request.Content.Length);
				stream.Position = 0L;
			}
			else
			{
				stream = request.ContentStream;
			}
			EventHandler<StreamTransferProgressArgs> streamUploadProgressCallback = ((IAmazonWebServiceRequest)request.OriginalRequest).StreamUploadProgressCallback;
			if (streamUploadProgressCallback != null)
			{
				stream = httpRequest.SetupProgressListeners(stream, requestContext.ClientConfig.ProgressUpdateInterval, CallbackSender, streamUploadProgressCallback);
			}
			Stream inputStream = GetInputStream(requestContext, stream, request);
			httpRequest.WriteToRequestBody(requestContent, inputStream, requestContext.Request.Headers, requestContext);
		}

		protected virtual IHttpRequest<TRequestContent> CreateWebRequest(IRequestContext requestContext)
		{
			IRequest request = requestContext.Request;
			System.Uri requestUri = AmazonServiceClient.ComposeUrl(request);
			IHttpRequest<TRequestContent> httpRequest = _requestFactory.CreateHttpRequest(requestUri);
			httpRequest.ConfigureRequest(requestContext);
			httpRequest.Method = request.HttpMethod;
			if (request.MayContainRequestBody())
			{
				byte[] array = request.Content;
				if (request.SetContentFromParameters || (array == null && request.ContentStream == null))
				{
					if (!request.UseQueryString)
					{
						string parametersAsString = AWSSDKUtils.GetParametersAsString(request);
						array = (request.Content = Encoding.UTF8.GetBytes(parametersAsString));
						request.SetContentFromParameters = true;
					}
					else
					{
						request.Content = new byte[0];
					}
				}
				if (array != null)
				{
					request.Headers["Content-Length"] = array.Length.ToString(CultureInfo.InvariantCulture);
					return httpRequest;
				}
				if (request.ContentStream != null && request.ContentStream.CanSeek && !request.Headers.ContainsKey("Content-Length"))
				{
					request.Headers["Content-Length"] = request.ContentStream.Length.ToString(CultureInfo.InvariantCulture);
				}
			}
			return httpRequest;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed && disposing)
			{
				if (_requestFactory != null)
				{
					_requestFactory.Dispose();
				}
				_disposed = true;
			}
		}

		private static Stream GetInputStream(IRequestContext requestContext, Stream originalStream, IRequest wrappedRequest)
		{
			bool num = wrappedRequest.UseChunkEncoding && wrappedRequest.AWS4SignerResult != null;
			bool flag = wrappedRequest.Headers.ContainsKey("transfer-encoding") && wrappedRequest.Headers["transfer-encoding"] == "chunked";
			if (!(num || flag))
			{
				return originalStream;
			}
			return new ChunkedUploadWrapperStream(originalStream, requestContext.ClientConfig.BufferSize, wrappedRequest.AWS4SignerResult);
		}
	}
	public class AdaptiveRetryPolicy : StandardRetryPolicy
	{
		protected TokenBucket TokenBucket { get; set; } = new TokenBucket();

		public AdaptiveRetryPolicy(int maxRetries)
			: base(maxRetries)
		{
		}

		public AdaptiveRetryPolicy(IClientConfig config)
			: base(config)
		{
		}

		public override bool OnRetry(IExecutionContext executionContext, bool bypassAcquireCapacity, bool isThrottlingError)
		{
			TokenBucket.UpdateClientSendingRate(isThrottlingError);
			return base.OnRetry(executionContext, bypassAcquireCapacity, isThrottlingError);
		}

		public override void ObtainSendToken(IExecutionContext executionContext, Exception exception)
		{
			if (!TokenBucket.TryAcquireToken(1.0, executionContext.RequestContext.ClientConfig.FastFailRequests))
			{
				string arg = ((exception == null) ? "The initial request cannot be attempted because capacity could not be obtained" : "While attempting to retry a request error capacity could not be obtained");
				if (executionContext.RequestContext.ClientConfig.FastFailRequests)
				{
					throw new AmazonClientException($"{arg}. The client is configured to fail fast and there is insufficent capacity to attempt the request.", exception);
				}
				throw new AmazonClientException($"{arg}. There is insufficent capacity to attempt the request after attempting to obtain capacity multiple times.", exception);
			}
		}

		public override void NotifySuccess(IExecutionContext executionContext)
		{
			TokenBucket.UpdateClientSendingRate(isThrottlingError: false);
			base.NotifySuccess(executionContext);
		}

		public override Task<bool> RetryForExceptionAsync(IExecutionContext executionContext, Exception exception)
		{
			return Task.FromResult(RetryForExceptionSync(exception, executionContext));
		}

		public override Task WaitBeforeRetryAsync(IExecutionContext executionContext)
		{
			return Task.Delay(StandardRetryPolicy.CalculateRetryDelay(executionContext.RequestContext.Retries, base.MaxBackoffInMilliseconds), executionContext.RequestContext.CancellationToken);
		}

		public override async Task ObtainSendTokenAsync(IExecutionContext executionContext, Exception exception)
		{
			if (!(await TokenBucket.TryAcquireTokenAsync(1.0, executionContext.RequestContext.ClientConfig.FastFailRequests, executionContext.RequestContext.CancellationToken).ConfigureAwait(continueOnCapturedContext: false)))
			{
				string arg = ((exception == null) ? "The initial request cannot be attempted because capacity could not be obtained" : "While attempting to retry a request error capacity could not be obtained");
				if (executionContext.RequestContext.ClientConfig.FastFailRequests)
				{
					throw new AmazonClientException($"{arg}. The client is configured to fail fast and there is insufficent capacity to attempt the request.", exception);
				}
				throw new AmazonClientException($"{arg}. There is insufficent capacity to attempt the request after attempting to obtain capacity multiple times.", exception);
			}
		}
	}
	public class DefaultRetryPolicy : RetryPolicy
	{
		private const int INVALID_ENDPOINT_EXCEPTION_STATUSCODE = 421;

		private static readonly CapacityManager _capacityManagerInstance = new CapacityManager(100, 5, 1);

		private static readonly HashSet<string> _netStandardRetryErrorMessages = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "The server returned an invalid or unrecognized response", "The connection with the server was terminated abnormally", "An error occurred while sending the request.", "Failed sending data to the peer" };

		public int MaxBackoffInMilliseconds { get; set; } = 30000;

		public DefaultRetryPolicy(int maxRetries)
		{
			base.MaxRetries = maxRetries;
		}

		public DefaultRetryPolicy(IClientConfig config)
		{
			base.MaxRetries = config.MaxErrorRetry;
			if (config.ThrottleRetries)
			{
				string serviceURL = config.DetermineServiceURL();
				base.RetryCapacity = _capacityManagerInstance.GetRetryCapacity(serviceURL);
			}
		}

		public override bool CanRetry(IExecutionContext executionContext)
		{
			return executionContext.RequestContext.Request.IsRequestStreamRewindable();
		}

		public override bool RetryForException(IExecutionContext executionContext, Exception exception)
		{
			return RetryForExceptionSync(exception, executionContext);
		}

		public override bool OnRetry(IExecutionContext executionContext)
		{
			return OnRetry(executionContext, bypassAcquireCapacity: false, isThrottlingError: false);
		}

		public override bool OnRetry(IExecutionContext executionContext, bool bypassAcquireCapacity)
		{
			return OnRetry(executionContext, bypassAcquireCapacity, isThrottlingError: false);
		}

		public override bool OnRetry(IExecutionContext executionContext, bool bypassAcquireCapacity, bool isThrottlingError)
		{
			if (!bypassAcquireCapacity && executionContext.RequestContext.ClientConfig.ThrottleRetries && base.RetryCapacity != null)
			{
				return _capacityManagerInstance.TryAcquireCapacity(base.RetryCapacity, executionContext.RequestContext.LastCapacityType);
			}
			return true;
		}

		public override void NotifySuccess(IExecutionContext executionContext)
		{
			if (executionContext.RequestContext.ClientConfig.ThrottleRetries && base.RetryCapacity != null)
			{
				_capacityManagerInstance.ReleaseCapacity(executionContext.RequestContext.LastCapacityType, base.RetryCapacity);
			}
		}

		private bool RetryForExceptionSync(Exception exception)
		{
			return RetryForExceptionSync(exception, null);
		}

		private bool RetryForExceptionSync(Exception exception, IExecutionContext executionContext)
		{
			AmazonServiceException ex = exception as AmazonServiceException;
			if (IsThrottlingError(exception))
			{
				return true;
			}
			if (IsTransientError(executionContext, exception) || IsServiceTimeoutError(exception))
			{
				return true;
			}
			checked
			{
				if (ex != null && ex.StatusCode == HttpStatusCode.MisdirectedRequest)
				{
					if (executionContext.RequestContext.EndpointDiscoveryRetries < 1)
					{
						executionContext.RequestContext.EndpointDiscoveryRetries++;
						return true;
					}
					return false;
				}
				return false;
			}
		}

		public override bool RetryLimitReached(IExecutionContext executionContext)
		{
			return executionContext.RequestContext.Retries >= base.MaxRetries;
		}

		public override void WaitBeforeRetry(IExecutionContext executionContext)
		{
			WaitBeforeRetry(executionContext.RequestContext.Retries, MaxBackoffInMilliseconds);
		}

		public static void WaitBeforeRetry(int retries, int maxBackoffInMilliseconds)
		{
			AWSSDKUtils.Sleep(CalculateRetryDelay(retries, maxBackoffInMilliseconds));
		}

		private static int CalculateRetryDelay(int retries, int maxBackoffInMilliseconds)
		{
			int num = ((retries >= 12) ? 2147483647 : Convert.ToInt32(Math.Pow(4.0, retries) * 100.0));
			if (retries > 0 && (num > maxBackoffInMilliseconds || num <= 0))
			{
				num = maxBackoffInMilliseconds;
			}
			return num;
		}

		[Obsolete("This method is no longer used within DefaultRetryPolicy")]
		protected static bool ContainErrorMessage(Exception exception)
		{
			return RetryPolicy.ContainErrorMessage(exception, _netStandardRetryErrorMessages);
		}

		[Obsolete("This method has been moved to AWSSDK.Runtime.Internal.Util.ExceptionUtils")]
		protected static bool IsInnerException<T>(Exception exception) where T : Exception
		{
			return ExceptionUtils.IsInnerException<T>(exception);
		}

		[Obsolete("This method has been moved to AWSSDK.Runtime.Internal.Util.ExceptionUtils")]
		protected static bool IsInnerException<T>(Exception exception, out T inner) where T : Exception
		{
			return ExceptionUtils.IsInnerException<T>(exception, out inner);
		}

		public override Task<bool> RetryForExceptionAsync(IExecutionContext executionContext, Exception exception)
		{
			return Task.FromResult(RetryForExceptionSync(exception, executionContext));
		}

		public override Task WaitBeforeRetryAsync(IExecutionContext executionContext)
		{
			return Task.Delay(CalculateRetryDelay(executionContext.RequestContext.Retries, MaxBackoffInMilliseconds), executionContext.RequestContext.CancellationToken);
		}
	}
	public class RetryHandler : PipelineHandler
	{
		private ILogger _logger;

		public override ILogger Logger
		{
			get
			{
				return _logger;
			}
			set
			{
				_logger = value;
				RetryPolicy.Logger = value;
			}
		}

		public RetryPolicy RetryPolicy { get; private set; }

		public RetryHandler(RetryPolicy retryPolicy)
		{
			RetryPolicy = retryPolicy;
		}

		public override void InvokeSync(IExecutionContext executionContext)
		{
			IRequestContext requestContext = executionContext.RequestContext;
			_ = executionContext.ResponseContext;
			bool flag = false;
			RetryPolicy.ObtainSendToken(executionContext, null);
			checked
			{
				do
				{
					try
					{
						base.InvokeSync(executionContext);
						RetryPolicy.NotifySuccess(executionContext);
						break;
					}
					catch (Exception exception)
					{
						flag = RetryPolicy.Retry(executionContext, exception);
						if (!flag)
						{
							LogForError(requestContext, exception);
							throw;
						}
						requestContext.Retries++;
						requestContext.Metrics.SetCounter(Metric.AttemptCount, requestContext.Retries);
						LogForRetry(requestContext, exception);
						RetryPolicy.ObtainSendToken(executionContext, exception);
					}
					PrepareForRetry(requestContext);
					using (requestContext.Metrics.StartEvent(Metric.RetryPauseTime))
					{
						RetryPolicy.WaitBeforeRetry(executionContext);
					}
				}
				while (flag);
			}
		}

		public override async Task<T> InvokeAsync<T>(IExecutionContext executionContext)
		{
			IRequestContext requestContext = executionContext.RequestContext;
			_ = executionContext.ResponseContext;
			bool shouldRetry = false;
			await RetryPolicy.ObtainSendTokenAsync(executionContext, null).ConfigureAwait(continueOnCapturedContext: false);
			checked
			{
				do
				{
					ExceptionDispatchInfo capturedException;
					try
					{
						T result = await base.InvokeAsync<T>(executionContext).ConfigureAwait(continueOnCapturedContext: false);
						RetryPolicy.NotifySuccess(executionContext);
						return result;
					}
					catch (Exception source)
					{
						capturedException = ExceptionDispatchInfo.Capture(source);
					}
					if (capturedException != null)
					{
						shouldRetry = await RetryPolicy.RetryAsync(executionContext, capturedException.SourceException).ConfigureAwait(continueOnCapturedContext: false);
						if (!shouldRetry)
						{
							LogForError(requestContext, capturedException.SourceException);
							capturedException.Throw();
						}
						else
						{
							requestContext.Retries++;
							requestContext.Metrics.SetCounter(Metric.AttemptCount, requestContext.Retries);
							LogForRetry(requestContext, capturedException.SourceException);
						}
						await RetryPolicy.ObtainSendTokenAsync(executionContext, capturedException.SourceException).ConfigureAwait(continueOnCapturedContext: false);
					}
					PrepareForRetry(requestContext);
					using (requestContext.Metrics.StartEvent(Metric.RetryPauseTime))
					{
						await RetryPolicy.WaitBeforeRetryAsync(executionContext).ConfigureAwait(continueOnCapturedContext: false);
					}
				}
				while (shouldRetry);
				throw new AmazonClientException("Neither a response was returned nor an exception was thrown in the Runtime RetryHandler.");
			}
		}

		internal static void PrepareForRetry(IRequestContext requestContext)
		{
			if (requestContext.Request.ContentStream != null && requestContext.Request.OriginalStreamPosition >= 0)
			{
				Stream stream = requestContext.Request.ContentStream;
				if (stream is HashStream hashStream)
				{
					hashStream.Reset();
					stream = hashStream.GetSeekableBaseStream();
				}
				stream.Position = requestContext.Request.OriginalStreamPosition;
			}
		}

		private void LogForRetry(IRequestContext requestContext, Exception exception)
		{
			if (exception is WebException ex)
			{
				Logger.InfoFormat("WebException ({1}) making request {2} to {3}. Attempting retry {4} of {5}.", ex.Status, requestContext.RequestName, requestContext.Request.Endpoint.ToString(), requestContext.Retries, RetryPolicy.MaxRetries);
			}
			else
			{
				Logger.InfoFormat("{0} making request {1} to {2}. Attempting retry {3} of {4}.", exception.GetType().Name, requestContext.RequestName, requestContext.Request.Endpoint.ToString(), requestContext.Retries, RetryPolicy.MaxRetries);
			}
		}

		private void LogForError(IRequestContext requestContext, Exception exception)
		{
			Logger.Error(exception, "{0} making request {1} to {2}. Attempt {3}.", exception.GetType().Name, requestContext.RequestName, requestContext.Request.Endpoint.ToString(), checked(requestContext.Retries + 1));
		}
	}
	public class StandardRetryPolicy : RetryPolicy
	{
		private static Random _randomJitter = new Random();

		private const int INVALID_ENDPOINT_EXCEPTION_STATUSCODE = 421;

		protected static CapacityManager CapacityManagerInstance { get; set; } = new CapacityManager(100, 5, 1, 10);

		public int MaxBackoffInMilliseconds { get; set; } = 20000;

		public StandardRetryPolicy(int maxRetries)
		{
			base.MaxRetries = maxRetries;
		}

		public StandardRetryPolicy(IClientConfig config)
		{
			base.MaxRetries = config.MaxErrorRetry;
			if (config.ThrottleRetries)
			{
				string serviceURL = config.DetermineServiceURL();
				base.RetryCapacity = CapacityManagerInstance.GetRetryCapacity(serviceURL);
			}
		}

		public override bool CanRetry(IExecutionContext executionContext)
		{
			return executionContext.RequestContext.Request.IsRequestStreamRewindable();
		}

		public override bool RetryForException(IExecutionContext executionContext, Exception exception)
		{
			return RetryForExceptionSync(exception, executionContext);
		}

		public override bool OnRetry(IExecutionContext executionContext)
		{
			return OnRetry(executionContext, bypassAcquireCapacity: false, isThrottlingError: false);
		}

		public override bool OnRetry(IExecutionContext executionContext, bool bypassAcquireCapacity)
		{
			return OnRetry(executionContext, bypassAcquireCapacity, isThrottlingError: false);
		}

		public override bool OnRetry(IExecutionContext executionContext, bool bypassAcquireCapacity, bool isThrottlingError)
		{
			if (!bypassAcquireCapacity && executionContext.RequestContext.ClientConfig.ThrottleRetries && base.RetryCapacity != null)
			{
				return CapacityManagerInstance.TryAcquireCapacity(base.RetryCapacity, executionContext.RequestContext.LastCapacityType);
			}
			return true;
		}

		public override void NotifySuccess(IExecutionContext executionContext)
		{
			if (executionContext.RequestContext.ClientConfig.ThrottleRetries && base.RetryCapacity != null)
			{
				IRequestContext requestContext = executionContext.RequestContext;
				CapacityManagerInstance.ReleaseCapacity(requestContext.LastCapacityType, base.RetryCapacity);
			}
		}

		protected bool RetryForExceptionSync(Exception exception)
		{
			return RetryForExceptionSync(exception, null);
		}

		protected bool RetryForExceptionSync(Exception exception, IExecutionContext executionContext)
		{
			AmazonServiceException ex = exception as AmazonServiceException;
			if (IsThrottlingError(exception))
			{
				return true;
			}
			if (IsTransientError(executionContext, exception) || IsServiceTimeoutError(exception))
			{
				return true;
			}
			checked
			{
				if (ex != null && ex.StatusCode == HttpStatusCode.MisdirectedRequest)
				{
					if (executionContext.RequestContext.EndpointDiscoveryRetries < 1)
					{
						executionContext.RequestContext.EndpointDiscoveryRetries++;
						return true;
					}
					return false;
				}
				return false;
			}
		}

		public override bool RetryLimitReached(IExecutionContext executionContext)
		{
			return executionContext.RequestContext.Retries >= base.MaxRetries;
		}

		public override void WaitBeforeRetry(IExecutionContext executionContext)
		{
			WaitBeforeRetry(executionContext.RequestContext.Retries, MaxBackoffInMilliseconds);
		}

		public static void WaitBeforeRetry(int retries, int maxBackoffInMilliseconds)
		{
			AWSSDKUtils.Sleep(CalculateRetryDelay(retries, maxBackoffInMilliseconds));
		}

		protected static int CalculateRetryDelay(int retries, int maxBackoffInMilliseconds)
		{
			double num;
			lock (_randomJitter)
			{
				num = _randomJitter.NextDouble();
			}
			return Convert.ToInt32(Math.Min(num * Math.Pow(2.0, checked(retries - 1)) * 1000.0, maxBackoffInMilliseconds));
		}

		public override Task<bool> RetryForExceptionAsync(IExecutionContext executionContext, Exception exception)
		{
			return Task.FromResult(RetryForExceptionSync(exception, executionContext));
		}

		public override Task WaitBeforeRetryAsync(IExecutionContext executionContext)
		{
			return Task.Delay(CalculateRetryDelay(executionContext.RequestContext.Retries, MaxBackoffInMilliseconds), executionContext.RequestContext.CancellationToken);
		}
	}
}
namespace Amazon.Runtime.Internal.Util
{
	public class CachingWrapperStream : WrapperStream
	{
		private readonly int? _cacheLimit;

		private int _cachedBytes;

		public List<byte> AllReadBytes { get; private set; }

		public List<byte> LoggableReadBytes
		{
			get
			{
				int count = _cacheLimit ?? AWSConfigs.LoggingConfig.LogResponsesSizeLimit;
				return AllReadBytes.Take(count).ToList();
			}
		}

		public override bool CanSeek => false;

		public override long Position
		{
			get
			{
				throw new NotSupportedException("CachingWrapperStream does not support seeking");
			}
			set
			{
				throw new NotSupportedException("CachingWrapperStream does not support seeking");
			}
		}

		public CachingWrapperStream(Stream baseStream, int? cacheLimit = null)
			: base(baseStream)
		{
			_cacheLimit = cacheLimit;
			AllReadBytes = new List<byte>();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int num = base.Read(buffer, offset, count);
			UpdateCacheAfterReading(buffer, offset, num);
			return num;
		}

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			int num = await base.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			UpdateCacheAfterReading(buffer, offset, num);
			return num;
		}

		private void UpdateCacheAfterReading(byte[] buffer, int offset, int numberOfBytesRead)
		{
			checked
			{
				if (_cacheLimit.HasValue)
				{
					if (_cachedBytes < _cacheLimit.Value)
					{
						int val = _cacheLimit.Value - _cachedBytes;
						int num = Math.Min(numberOfBytesRead, val);
						byte[] array = new byte[num];
						Array.Copy(buffer, offset, array, 0, num);
						AllReadBytes.AddRange(array);
						_cachedBytes += num;
					}
				}
				else
				{
					byte[] array2 = new byte[numberOfBytesRead];
					Array.Copy(buffer, offset, array2, 0, numberOfBytesRead);
					AllReadBytes.AddRange(array2);
				}
			}
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("CachingWrapperStream does not support seeking");
		}
	}
	public class ChunkedUploadWrapperStream : WrapperStream
	{
		private enum ReadStrategy
		{
			ReadDirect,
			ReadAndCopy
		}

		public static readonly int DefaultChunkSize = 81920;

		private const string CLRF = "\r\n";

		private const string CHUNK_STRING_TO_SIGN_PREFIX = "AWS4-HMAC-SHA256-PAYLOAD";

		private const string CHUNK_SIGNATURE_HEADER = ";chunk-signature=";

		private const int SIGNATURE_LENGTH = 64;

		private byte[] _inputBuffer;

		private readonly byte[] _outputBuffer;

		private int _outputBufferPos = -1;

		private int _outputBufferDataLen = -1;

		private readonly int _wrappedStreamBufferSize;

		private bool _wrappedStreamConsumed;

		private bool _outputBufferIsTerminatingChunk;

		private readonly ReadStrategy _readStrategy;

		private AWS4SigningResult HeaderSigningResult { get; set; }

		private string PreviousChunkSignature { get; set; }

		public override long Length
		{
			get
			{
				if (base.BaseStream != null)
				{
					return ComputeChunkedContentLength(base.BaseStream.Length);
				}
				return 0L;
			}
		}

		public override bool CanSeek => false;

		internal override bool HasLength => HeaderSigningResult != null;

		internal ChunkedUploadWrapperStream(Stream stream, int wrappedStreamBufferSize, AWS4SigningResult headerSigningResult)
			: base(stream)
		{
			HeaderSigningResult = headerSigningResult;
			PreviousChunkSignature = headerSigningResult?.Signature;
			_wrappedStreamBufferSize = wrappedStreamBufferSize;
			_inputBuffer = new byte[DefaultChunkSize];
			_outputBuffer = new byte[CalculateChunkHeaderLength(DefaultChunkSize)];
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int bytesRead = 0;
			if (_outputBufferPos == -1)
			{
				if (_wrappedStreamConsumed && _outputBufferIsTerminatingChunk)
				{
					return 0;
				}
				bytesRead = FillInputBuffer();
			}
			return AdjustBufferAfterReading(buffer, offset, count, bytesRead);
		}

		private int AdjustBufferAfterReading(byte[] buffer, int offset, int count, int bytesRead)
		{
			if (_outputBufferPos == -1)
			{
				ConstructOutputBufferChunk(bytesRead);
				_outputBufferIsTerminatingChunk = _wrappedStreamConsumed && bytesRead == 0;
			}
			checked
			{
				int num = _outputBufferDataLen - _outputBufferPos;
				if (num < count)
				{
					count = num;
				}
				Buffer.BlockCopy(_outputBuffer, _outputBufferPos, buffer, offset, count);
				_outputBufferPos += count;
				if (_outputBufferPos >= _outputBufferDataLen)
				{
					_outputBufferPos = -1;
				}
				return count;
			}
		}

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			int bytesRead = 0;
			if (_outputBufferPos == -1)
			{
				if (_wrappedStreamConsumed && _outputBufferIsTerminatingChunk)
				{
					return 0;
				}
				bytesRead = await FillInputBufferAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			return AdjustBufferAfterReading(buffer, offset, count, bytesRead);
		}

		private async Task<int> FillInputBufferAsync(CancellationToken cancellationToken)
		{
			if (_wrappedStreamConsumed)
			{
				return 0;
			}
			int inputBufferPos = 0;
			checked
			{
				if (_readStrategy == ReadStrategy.ReadDirect)
				{
					while (inputBufferPos < _inputBuffer.Length && !_wrappedStreamConsumed)
					{
						int num = _inputBuffer.Length - inputBufferPos;
						if (num > _wrappedStreamBufferSize)
						{
							num = _wrappedStreamBufferSize;
						}
						int num2 = await BaseStream.ReadAsync(_inputBuffer, inputBufferPos, num, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
						if (num2 == 0)
						{
							_wrappedStreamConsumed = true;
						}
						else
						{
							inputBufferPos += num2;
						}
					}
				}
				else
				{
					byte[] readBuffer = new byte[_wrappedStreamBufferSize];
					while (inputBufferPos < _inputBuffer.Length && !_wrappedStreamConsumed)
					{
						int num3 = await BaseStream.ReadAsync(readBuffer, 0, _wrappedStreamBufferSize, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
						if (num3 == 0)
						{
							_wrappedStreamConsumed = true;
							continue;
						}
						Buffer.BlockCopy(readBuffer, 0, _inputBuffer, inputBufferPos, num3);
						inputBufferPos += num3;
					}
				}
				return inputBufferPos;
			}
		}

		private void ConstructOutputBufferChunk(int dataLen)
		{
			if (dataLen > 0 && dataLen < _inputBuffer.Length)
			{
				byte[] array = new byte[dataLen];
				Buffer.BlockCopy(_inputBuffer, 0, array, 0, dataLen);
				_inputBuffer = array;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(dataLen.ToString("X", CultureInfo.InvariantCulture));
			if (HeaderSigningResult != null)
			{
				string data = "AWS4-HMAC-SHA256-PAYLOAD\n" + HeaderSigningResult.ISO8601DateTime + "\n" + HeaderSigningResult.Scope + "\n" + PreviousChunkSignature + "\n" + AWSSDKUtils.ToHex(AWS4Signer.ComputeHash(""), lowercase: true) + "\n" + ((dataLen > 0) ? AWSSDKUtils.ToHex(AWS4Signer.ComputeHash(_inputBuffer), lowercase: true) : "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855");
				string text = (PreviousChunkSignature = AWSSDKUtils.ToHex(AWS4Signer.SignBlob(HeaderSigningResult.SigningKey, data), lowercase: true));
				stringBuilder.Append(";chunk-signature=" + text);
			}
			stringBuilder.Append("\r\n");
			checked
			{
				try
				{
					byte[] bytes = Encoding.UTF8.GetBytes(stringBuilder.ToString());
					byte[] bytes2 = Encoding.UTF8.GetBytes("\r\n");
					int num = 0;
					Buffer.BlockCopy(bytes, 0, _outputBuffer, num, bytes.Length);
					num += bytes.Length;
					if (dataLen > 0)
					{
						Buffer.BlockCopy(_inputBuffer, 0, _outputBuffer, num, dataLen);
						num += dataLen;
					}
					Buffer.BlockCopy(bytes2, 0, _outputBuffer, num, bytes2.Length);
					_outputBufferPos = 0;
					_outputBufferDataLen = bytes.Length + dataLen + bytes2.Length;
				}
				catch (Exception ex)
				{
					throw new AmazonClientException("Unable to sign the chunked data. " + ex.Message, ex);
				}
			}
		}

		public static long ComputeChunkedContentLength(long originalLength)
		{
			if (originalLength < 0)
			{
				throw new ArgumentOutOfRangeException("originalLength", "Expected 0 or greater value for originalLength.");
			}
			if (originalLength == 0L)
			{
				return CalculateChunkHeaderLength(0L);
			}
			long num = originalLength / DefaultChunkSize;
			long num2 = originalLength % DefaultChunkSize;
			return checked(num * CalculateChunkHeaderLength(DefaultChunkSize) + ((num2 > 0) ? CalculateChunkHeaderLength(num2) : 0) + CalculateChunkHeaderLength(0L));
		}

		private static long CalculateChunkHeaderLength(long chunkDataSize)
		{
			return checked(chunkDataSize.ToString("X", CultureInfo.InvariantCulture).Length + ";chunk-signature=".Length + 64 + "\r\n".Length + chunkDataSize + "\r\n".Length);
		}

		private int FillInputBuffer()
		{
			if (_wrappedStreamConsumed)
			{
				return 0;
			}
			int num = 0;
			checked
			{
				if (_readStrategy == ReadStrategy.ReadDirect)
				{
					while (num < _inputBuffer.Length && !_wrappedStreamConsumed)
					{
						int num2 = _inputBuffer.Length - num;
						if (num2 > _wrappedStreamBufferSize)
						{
							num2 = _wrappedStreamBufferSize;
						}
						int num3 = base.BaseStream.Read(_inputBuffer, num, num2);
						if (num3 == 0)
						{
							_wrappedStreamConsumed = true;
						}
						else
						{
							num += num3;
						}
					}
				}
				else
				{
					byte[] array = new byte[_wrappedStreamBufferSize];
					while (num < _inputBuffer.Length && !_wrappedStreamConsumed)
					{
						int num4 = base.BaseStream.Read(array, 0, _wrappedStreamBufferSize);
						if (num4 == 0)
						{
							_wrappedStreamConsumed = true;
							continue;
						}
						Buffer.BlockCopy(array, 0, _inputBuffer, num, num4);
						num += num4;
					}
				}
				return num;
			}
		}
	}
	internal class AlwaysSendList<T> : List<T>
	{
		public AlwaysSendList()
		{
		}

		public AlwaysSendList(IEnumerable<T> collection)
			: base(collection ?? new List<T>())
		{
		}
	}
	internal class AlwaysSendDictionary<TKey, TValue> : Dictionary<TKey, TValue>
	{
		public AlwaysSendDictionary()
		{
		}

		public AlwaysSendDictionary(IEqualityComparer<TKey> comparer)
			: base(comparer)
		{
		}

		public AlwaysSendDictionary(IDictionary<TKey, TValue> dictionary)
			: base(dictionary ?? new Dictionary<TKey, TValue>())
		{
		}
	}
	internal class BackgroundDispatcher<T> : IDisposable
	{
		private bool isDisposed;

		private Action<T> action;

		private Queue<T> queue;

		private Task backgroundThread;

		private AutoResetEvent resetEvent;

		private bool shouldStop;

		private const int MAX_QUEUE_SIZE = 100;

		public bool IsRunning { get; private set; }

		public BackgroundDispatcher(Action<T> action)
		{
			if (action == null)
			{
				throw new ArgumentNullException("action");
			}
			queue = new Queue<T>();
			resetEvent = new AutoResetEvent(initialState: false);
			shouldStop = false;
			this.action = action;
			backgroundThread = new Task(Run);
			backgroundThread.Start();
		}

		~BackgroundDispatcher()
		{
			Stop();
			Dispose(disposing: false);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!isDisposed)
			{
				if (disposing && resetEvent != null)
				{
					resetEvent.Dispose();
					resetEvent = null;
				}
				isDisposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		public void Dispatch(T data)
		{
			if (queue.Count < 100)
			{
				lock (queue)
				{
					if (queue.Count < 100)
					{
						queue.Enqueue(data);
					}
				}
			}
			resetEvent.Set();
		}

		public void Stop()
		{
			shouldStop = true;
			resetEvent.Set();
		}

		private void Run()
		{
			IsRunning = true;
			while (!shouldStop)
			{
				HandleInvoked();
				resetEvent.WaitOne();
			}
			HandleInvoked();
			IsRunning = false;
		}

		private void HandleInvoked()
		{
			while (true)
			{
				bool flag = false;
				T obj = default(T);
				lock (queue)
				{
					if (queue.Count > 0)
					{
						obj = queue.Dequeue();
						flag = true;
					}
				}
				if (flag)
				{
					try
					{
						action(obj);
					}
					catch
					{
					}
					continue;
				}
				break;
			}
		}
	}
	internal class BackgroundInvoker : BackgroundDispatcher<Action>
	{
		public BackgroundInvoker()
			: base((Action<Action>)delegate(Action action)
			{
				action();
			})
		{
		}
	}
	public static class EndianConversionUtility
	{
		public static long HostToNetworkOrder(long host)
		{
			return ((HostToNetworkOrder((int)host) & 0xFFFFFFFFu) << 32) | (HostToNetworkOrder((int)(host >> 32)) & 0xFFFFFFFFu);
		}

		public static int HostToNetworkOrder(int host)
		{
			return ((HostToNetworkOrder((short)host) & 0xFFFF) << 16) | (HostToNetworkOrder((short)(host >> 16)) & 0xFFFF);
		}

		public static short HostToNetworkOrder(short host)
		{
			return (short)(((host & 0xFF) << 8) | ((host >> 8) & 0xFF));
		}

		public static long NetworkToHostOrder(long network)
		{
			return HostToNetworkOrder(network);
		}

		public static int NetworkToHostOrder(int network)
		{
			return HostToNetworkOrder(network);
		}

		public static short NetworkToHostOrder(short network)
		{
			return HostToNetworkOrder(network);
		}
	}
	internal class EventStream : WrapperStream
	{
		internal delegate void ReadProgress(int bytesRead);

		private bool disableClose;

		public override bool CanRead => base.BaseStream.CanRead;

		public override bool CanSeek => base.BaseStream.CanSeek;

		public override bool CanTimeout => base.BaseStream.CanTimeout;

		public override bool CanWrite => base.BaseStream.CanWrite;

		public override long Length => base.BaseStream.Length;

		public override long Position
		{
			get
			{
				return base.BaseStream.Position;
			}
			set
			{
				base.BaseStream.Position = value;
			}
		}

		public override int ReadTimeout
		{
			get
			{
				return base.BaseStream.ReadTimeout;
			}
			set
			{
				base.BaseStream.ReadTimeout = value;
			}
		}

		public override int WriteTimeout
		{
			get
			{
				return base.BaseStream.WriteTimeout;
			}
			set
			{
				base.BaseStream.WriteTimeout = value;
			}
		}

		internal event ReadProgress OnRead;

		internal EventStream(Stream stream, bool disableClose)
			: base(stream)
		{
			this.disableClose = disableClose;
		}

		protected override void Dispose(bool disposing)
		{
		}

		public override void Flush()
		{
			base.BaseStream.Flush();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int num = base.BaseStream.Read(buffer, offset, count);
			if (this.OnRead != null)
			{
				this.OnRead(num);
			}
			return num;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return base.BaseStream.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			base.BaseStream.SetLength(value);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotImplementedException();
		}

		public override void WriteByte(byte value)
		{
			throw new NotImplementedException();
		}

		public override Task FlushAsync(CancellationToken cancellationToken)
		{
			return base.BaseStream.FlushAsync(cancellationToken);
		}

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			int num = await BaseStream.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			if (this.OnRead != null)
			{
				this.OnRead(num);
			}
			return num;
		}

		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			throw new NotImplementedException();
		}
	}
	public static class Extensions
	{
		private static readonly long TicksPerSecond = TimeSpan.FromSeconds(1.0).Ticks;

		private static readonly double TickFrequency = (double)TicksPerSecond / (double)Stopwatch.Frequency;

		public static long GetElapsedDateTimeTicks(this Stopwatch self)
		{
			return checked((long)((double)self.ElapsedTicks * TickFrequency));
		}

		public static bool HasRequestData(this IRequest request)
		{
			if (request == null)
			{
				return false;
			}
			if (request.ContentStream != null || request.Content != null)
			{
				return true;
			}
			return request.Parameters.Count > 0;
		}

		public static Type[] GetTypes(this Assembly self)
		{
			List<Type> list = new List<Type>();
			foreach (TypeInfo definedType in self.DefinedTypes)
			{
				Type item = definedType.AsType();
				list.Add(item);
			}
			return list.ToArray();
		}

		public static string ToString(this string self, IFormatProvider formatProvider)
		{
			return self;
		}

		public static string ToLower(this string self, IFormatProvider formatProvider)
		{
			return self.ToLower();
		}

		public static string ToUpper(this string self, IFormatProvider formatProvider)
		{
			return self.ToUpper();
		}

		public static string ToString(this bool self, IFormatProvider formatProvider)
		{
			return self.ToString();
		}

		public static string ToString(this char self, IFormatProvider formatProvider)
		{
			return self.ToString();
		}

		public static string ToString(this Guid self, string format, IFormatProvider formatProvider)
		{
			return self.ToString(format);
		}
	}
	public static class GuidUtils
	{
		public static bool TryParseNullableGuid(string value, out Guid? result)
		{
			if (TryParseGuid(value, out var result2))
			{
				result = result2;
				return true;
			}
			result = null;
			return false;
		}

		public static bool TryParseGuid(string value, out Guid result)
		{
			try
			{
				result = new Guid(value);
				return true;
			}
			catch (Exception)
			{
				result = Guid.Empty;
				return false;
			}
		}
	}
	public static class Hashing
	{
		public static int Hash(params object[] value)
		{
			return CombineHashes(value.Select((object v) => v?.GetHashCode() ?? 0).ToArray());
		}

		public static int CombineHashes(params int[] hashes)
		{
			int num = 0;
			foreach (int b in hashes)
			{
				num = CombineHashesInternal(num, b);
			}
			return num;
		}

		private static int CombineHashesInternal(int a, int b)
		{
			return ((a << 5) + a) ^ b;
		}
	}
	public class HashingWrapper : IHashingWrapper, IDisposable
	{
		private CryptographicHash _hash;

		private IHashAlgorithmProvider _hasher;

		public HashingWrapper(string algorithmName)
		{
			if (string.IsNullOrEmpty(algorithmName))
			{
				throw new ArgumentNullException("algorithmName");
			}
			Init(algorithmName);
		}

		public void AppendBlock(byte[] buffer)
		{
			AppendBlock(buffer, 0, buffer.Length);
		}

		public byte[] AppendLastBlock(byte[] buffer)
		{
			return AppendLastBlock(buffer, 0, buffer.Length);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		private void Init(string algorithmName)
		{
			HashAlgorithm algorithm = (HashAlgorithm)Enum.Parse(typeof(HashAlgorithm), algorithmName);
			_hasher = WinRTCrypto.HashAlgorithmProvider.OpenAlgorithm(algorithm);
			Clear();
		}

		public void Clear()
		{
			_hash = _hasher.CreateHash();
		}

		public byte[] ComputeHash(byte[] buffer)
		{
			_hash.Append(buffer);
			return _hash.GetValueAndReset().ToArray();
		}

		public byte[] ComputeHash(Stream stream)
		{
			int num = 0;
			byte[] array = new byte[8192];
			byte[] array2 = new byte[8192];
			while ((num = stream.Read(array2, 0, array2.Length)) != 0)
			{
				if (num != array.Length)
				{
					array = new byte[num];
				}
				Array.Copy(array2, 0, array, 0, num);
				_hash.Append(array);
			}
			return _hash.GetValueAndReset().ToArray();
		}

		public void AppendBlock(byte[] buffer, int offset, int count)
		{
			if (count > 0)
			{
				byte[] array = new byte[count];
				Array.Copy(buffer, offset, array, 0, count);
				_hash.Append(array);
			}
		}

		public byte[] AppendLastBlock(byte[] buffer, int offset, int count)
		{
			AppendBlock(buffer, offset, count);
			return _hash.GetValueAndReset().ToArray();
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing && _hash != null)
			{
				_hash.Dispose();
				_hash = null;
			}
		}
	}
	public abstract class HashStream : WrapperStream
	{
		protected IHashingWrapper Algorithm { get; set; }

		protected bool FinishedHashing => CalculatedHash != null;

		protected long CurrentPosition { get; private set; }

		public byte[] CalculatedHash { get; protected set; }

		public byte[] ExpectedHash { get; private set; }

		public long ExpectedLength { get; protected set; }

		public override bool CanSeek => false;

		public override long Position
		{
			get
			{
				throw new NotSupportedException("HashStream does not support seeking");
			}
			set
			{
				throw new NotSupportedException("HashStream does not support seeking");
			}
		}

		public override long Length => ExpectedLength;

		protected HashStream(Stream baseStream, byte[] expectedHash, long expectedLength)
			: base(baseStream)
		{
			ExpectedHash = expectedHash;
			ExpectedLength = expectedLength;
			ValidateBaseStream();
			Reset();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int num = base.Read(buffer, offset, count);
			checked
			{
				CurrentPosition += num;
				if (!FinishedHashing)
				{
					Algorithm.AppendBlock(buffer, offset, num);
				}
				return num;
			}
		}

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			int num = await base.ReadAsync(buffer, offset, count, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			checked
			{
				CurrentPosition += num;
				if (!FinishedHashing)
				{
					Algorithm.AppendBlock(buffer, offset, num);
				}
				return num;
			}
		}

		protected override void Dispose(bool disposing)
		{
			try
			{
				CalculateHash();
				if (disposing && Algorithm != null)
				{
					Algorithm.Dispose();
					Algorithm = null;
				}
			}
			finally
			{
				base.Dispose(disposing);
			}
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException("HashStream does not support seeking");
		}

		public virtual void CalculateHash()
		{
			if (!FinishedHashing)
			{
				if (ExpectedLength < 0 || CurrentPosition == ExpectedLength)
				{
					CalculatedHash = Algorithm.AppendLastBlock(new byte[0]);
				}
				else
				{
					CalculatedHash = new byte[0];
				}
				if (CalculatedHash.Length != 0 && ExpectedHash != null && ExpectedHash.Length != 0 && !CompareHashes(ExpectedHash, CalculatedHash))
				{
					throw new AmazonClientException("Expected hash not equal to calculated hash");
				}
			}
		}

		public void Reset()
		{
			CurrentPosition = 0L;
			CalculatedHash = null;
			if (Algorithm != null)
			{
				Algorithm.Clear();
			}
			if (base.BaseStream is HashStream hashStream)
			{
				hashStream.Reset();
			}
		}

		private void ValidateBaseStream()
		{
			if (!base.BaseStream.CanRead && !base.BaseStream.CanWrite)
			{
				throw new InvalidDataException("HashStream does not support base streams that are not capable of reading or writing");
			}
		}

		protected static bool CompareHashes(byte[] expected, byte[] actual)
		{
			if (expected == actual)
			{
				return true;
			}
			if (expected == null || actual == null)
			{
				return expected == actual;
			}
			if (expected.Length != actual.Length)
			{
				return false;
			}
			for (int i = 0; i < expected.Length; i = checked(i + 1))
			{
				if (expected[i] != actual[i])
				{
					return false;
				}
			}
			return true;
		}
	}
	public class HashStream<T> : HashStream where T : IHashingWrapper, new()
	{
		public HashStream(Stream baseStream, byte[] expectedHash, long expectedLength)
			: base(baseStream, expectedHash, expectedLength)
		{
			base.Algorithm = new T();
		}
	}
	public class MD5Stream : HashStream<HashingWrapperMD5>
	{
		private Logger _logger;

		public MD5Stream(Stream baseStream, byte[] expectedHash, long expectedLength)
			: base(baseStream, expectedHash, expectedLength)
		{
			_logger = Logger.GetLogger(GetType());
		}
	}
	public static class HostPrefixUtils
	{
		private static Regex labelValidationRegex = new Regex("^[A-Za-z0-9\\-]+$", RegexOptions.Singleline);

		public static bool IsValidLabelValue(string value)
		{
			if (string.IsNullOrEmpty(value))
			{
				return false;
			}
			if (value.Length < 1 || value.Length > 63)
			{
				return false;
			}
			if (!labelValidationRegex.IsMatch(value))
			{
				return false;
			}
			return true;
		}
	}
	public interface IHashingWrapper : IDisposable
	{
		void Clear();

		byte[] ComputeHash(byte[] buffer);

		byte[] ComputeHash(Stream stream);

		void AppendBlock(byte[] buffer);

		void AppendBlock(byte[] buffer, int offset, int count);

		byte[] AppendLastBlock(byte[] buffer);

		byte[] AppendLastBlock(byte[] buffer, int offset, int count);
	}
	public interface ILogger
	{
		void InfoFormat(string messageFormat, params object[] args);

		void Debug(Exception exception, string messageFormat, params object[] args);

		void DebugFormat(string messageFormat, params object[] args);

		void Error(Exception exception, string messageFormat, params object[] args);

		void Flush();
	}
	internal class InternalConsoleLogger : InternalLogger
	{
		private enum LogLevel
		{
			Verbose = 2,
			Debug,
			Info,
			Warn,
			Error,
			Assert
		}

		public static long _sequanceId;

		public InternalConsoleLogger(Type declaringType)
			: base(declaringType)
		{
		}

		public override void Flush()
		{
		}

		public override void Error(Exception exception, string messageFormat, params object[] args)
		{
			Log(LogLevel.Error, string.Format(CultureInfo.CurrentCulture, messageFormat, args), exception);
		}

		public override void Debug(Exception exception, string messageFormat, params object[] args)
		{
			Log(LogLevel.Debug, string.Format(CultureInfo.CurrentCulture, messageFormat, args), exception);
		}

		public override void DebugFormat(string message, params object[] arguments)
		{
			Log(LogLevel.Debug, string.Format(CultureInfo.CurrentCulture, message, arguments), null);
		}

		public override void InfoFormat(string message, params object[] arguments)
		{
			Log(LogLevel.Info, string.Format(CultureInfo.CurrentCulture, message, arguments), null);
		}

		private void Log(LogLevel logLevel, string message, Exception ex)
		{
			string text = null;
			long num = Interlocked.Increment(ref _sequanceId);
			string text2 = AWSSDKUtils.CorrectedUtcNow.ToLocalTime().ToString("yyyy-MM-dd\\THH:mm:ss.fff\\Z", CultureInfo.InvariantCulture);
			string text3 = logLevel.ToString().ToUpper(CultureInfo.InvariantCulture);
			text = ((ex == null) ? string.Format(CultureInfo.CurrentCulture, "{0}|{1}|{2}|{3}", num, text2, text3, message) : string.Format(CultureInfo.CurrentCulture, "{0}|{1}|{2}|{3} --> {4}", num, text2, text3, message, ex.ToString()));
			switch (logLevel)
			{
			case LogLevel.Warn:
				Android.Util.Log.Warn(base.DeclaringType.Name, text);
				break;
			case LogLevel.Debug:
				Android.Util.Log.Debug(base.DeclaringType.Name, text);
				break;
			case LogLevel.Error:
				Android.Util.Log.Error(base.DeclaringType.Name, text);
				break;
			case LogLevel.Verbose:
				Android.Util.Log.Verbose(base.DeclaringType.Name, text);
				break;
			default:
				Android.Util.Log.Info(base.DeclaringType.Name, text);
				break;
			}
		}
	}
	public class Logger : ILogger
	{
		private static IDictionary<Type, Logger> cachedLoggers = new Dictionary<Type, Logger>();

		private List<InternalLogger> loggers;

		private static Logger emptyLogger = new Logger();

		public static Logger EmptyLogger => emptyLogger;

		private Logger()
		{
			loggers = new List<InternalLogger>();
		}

		private Logger(Type type)
		{
			loggers = new List<InternalLogger>();
			InternalLog4netLogger item = new InternalLog4netLogger(type);
			loggers.Add(item);
			loggers.Add(new InternalConsoleLogger(type));
			InternalFileLogger item2 = new InternalFileLogger(type);
			loggers.Add(item2);
			ConfigureLoggers();
			AWSConfigs.PropertyChanged += ConfigsChanged;
		}

		private void ConfigsChanged(object sender, PropertyChangedEventArgs e)
		{
			if (e != null && string.Equals(e.PropertyName, "LogTo", StringComparison.Ordinal))
			{
				ConfigureLoggers();
			}
		}

		private void ConfigureLoggers()
		{
			LoggingOptions logTo = AWSConfigs.LoggingConfig.LogTo;
			foreach (InternalLogger logger in loggers)
			{
				if (logger is InternalLog4netLogger)
				{
					logger.IsEnabled = (logTo & LoggingOptions.Log4Net) == LoggingOptions.Log4Net;
				}
				if (logger is InternalConsoleLogger)
				{
					logger.IsEnabled = (logTo & LoggingOptions.Console) == LoggingOptions.Console;
				}
				if (logger is InternalConsoleLogger)
				{
					logger.IsEnabled = (logTo & LoggingOptions.SystemDiagnostics) == LoggingOptions.SystemDiagnostics;
				}
				if (logger is InternalFileLogger)
				{
					logger.IsEnabled = (logTo & LoggingOptions.File) == LoggingOptions.File;
				}
			}
		}

		public static Logger GetLogger(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			Logger value;
			lock (cachedLoggers)
			{
				if (!cachedLoggers.TryGetValue(type, out value))
				{
					value = new Logger(type);
					cachedLoggers[type] = value;
				}
			}
			return value;
		}

		public static void ClearLoggerCache()
		{
			lock (cachedLoggers)
			{
				cachedLoggers = new Dictionary<Type, Logger>();
			}
		}

		public void Flush()
		{
			foreach (InternalLogger logger in loggers)
			{
				logger.Flush();
			}
		}

		public void Error(Exception exception, string messageFormat, params object[] args)
		{
			foreach (InternalLogger logger in loggers)
			{
				if (logger.IsEnabled && logger.IsErrorEnabled)
				{
					logger.Error(exception, messageFormat, args);
				}
			}
		}

		public void Debug(Exception exception, string messageFormat, params object[] args)
		{
			foreach (InternalLogger logger in loggers)
			{
				if (logger.IsEnabled && logger.IsDebugEnabled)
				{
					logger.Debug(exception, messageFormat, args);
				}
			}
		}

		public void DebugFormat(string messageFormat, params object[] args)
		{
			foreach (InternalLogger logger in loggers)
			{
				if (logger.IsEnabled && logger.IsDebugEnabled)
				{
					logger.DebugFormat(messageFormat, args);
				}
			}
		}

		public void InfoFormat(string messageFormat, params object[] args)
		{
			foreach (InternalLogger logger in loggers)
			{
				if (logger.IsEnabled && logger.IsInfoEnabled)
				{
					logger.InfoFormat(messageFormat, args);
				}
			}
		}
	}
	internal abstract class InternalLogger
	{
		public Type DeclaringType { get; private set; }

		public bool IsEnabled { get; set; }

		public virtual bool IsErrorEnabled => true;

		public virtual bool IsDebugEnabled => true;

		public virtual bool IsInfoEnabled => true;

		public InternalLogger(Type declaringType)
		{
			DeclaringType = declaringType;
			IsEnabled = true;
		}

		public abstract void Flush();

		public abstract void Error(Exception exception, string messageFormat, params object[] args);

		public abstract void Debug(Exception exception, string messageFormat, params object[] args);

		public abstract void DebugFormat(string message, params object[] arguments);

		public abstract void InfoFormat(string message, params object[] arguments);
	}
	internal class InternalLog4netLogger : InternalLogger
	{
		private enum LoadState
		{
			Uninitialized,
			Failed,
			Loading,
			Success
		}

		private static LoadState loadState = LoadState.Uninitialized;

		private static readonly object LOCK = new object();

		private static Type logMangerType;

		private static ITypeInfo logMangerTypeInfo;

		private static MethodInfo getLoggerWithTypeMethod;

		private static Type logType;

		private static ITypeInfo logTypeInfo;

		private static MethodInfo logMethod;

		private static Type levelType;

		private static ITypeInfo levelTypeInfo;

		private static object debugLevelPropertyValue;

		private static object infoLevelPropertyValue;

		private static object errorLevelPropertyValue;

		private static MethodInfo isEnabledForMethod;

		private static Type systemStringFormatType;

		private static Type loggerType;

		private object internalLogger;

		private bool? isErrorEnabled;

		private bool? isDebugEnabled;

		private bool? isInfoEnabled;

		public override bool IsErrorEnabled
		{
			get
			{
				if (!isErrorEnabled.HasValue)
				{
					if (loadState != LoadState.Success || internalLogger == null || loggerType == null || systemStringFormatType == null || errorLevelPropertyValue == null)
					{
						isErrorEnabled = false;
					}
					else
					{
						isErrorEnabled = Convert.ToBoolean(isEnabledForMethod.Invoke(internalLogger, new object[1] { errorLevelPropertyValue }), CultureInfo.InvariantCulture);
					}
				}
				return isErrorEnabled.Value;
			}
		}

		public override bool IsDebugEnabled
		{
			get
			{
				if (!isDebugEnabled.HasValue)
				{
					if (loadState != LoadState.Success || internalLogger == null || loggerType == null || systemStringFormatType == null || debugLevelPropertyValue == null)
					{
						isDebugEnabled = false;
					}
					else
					{
						isDebugEnabled = Convert.ToBoolean(isEnabledForMethod.Invoke(internalLogger, new object[1] { debugLevelPropertyValue }), CultureInfo.InvariantCulture);
					}
				}
				return isDebugEnabled.Value;
			}
		}

		public override bool IsInfoEnabled
		{
			get
			{
				if (!isInfoEnabled.HasValue)
				{
					if (loadState != LoadState.Success || internalLogger == null || loggerType == null || systemStringFormatType == null || infoLevelPropertyValue == null)
					{
						isInfoEnabled = false;
					}
					else
					{
						isInfoEnabled = Convert.ToBoolean(isEnabledForMethod.Invoke(internalLogger, new object[1] { infoLevelPropertyValue }), CultureInfo.InvariantCulture);
					}
				}
				return isInfoEnabled.Value;
			}
		}

		private static void loadStatics()
		{
			lock (LOCK)
			{
				if (loadState != LoadState.Uninitialized)
				{
					return;
				}
				loadState = LoadState.Loading;
				try
				{
					loggerType = Type.GetType("Amazon.Runtime.Internal.Util.Logger");
					logMangerType = Type.GetType("log4net.Core.LoggerManager, log4net");
					logMangerTypeInfo = TypeFactory.GetTypeInfo(logMangerType);
					if (logMangerType == null)
					{
						loadState = LoadState.Failed;
						return;
					}
					getLoggerWithTypeMethod = logMangerTypeInfo.GetMethod("GetLogger", new ITypeInfo[2]
					{
						TypeFactory.GetTypeInfo(typeof(Assembly)),
						TypeFactory.GetTypeInfo(typeof(Type))
					});
					logType = Type.GetType("log4net.Core.ILogger, log4net");
					logTypeInfo = TypeFactory.GetTypeInfo(logType);
					levelType = Type.GetType("log4net.Core.Level, log4net");
					levelTypeInfo = TypeFactory.GetTypeInfo(levelType);
					debugLevelPropertyValue = levelTypeInfo.GetField("Debug").GetValue(null);
					infoLevelPropertyValue = levelTypeInfo.GetField("Info").GetValue(null);
					errorLevelPropertyValue = levelTypeInfo.GetField("Error").GetValue(null);
					systemStringFormatType = Type.GetType("log4net.Util.SystemStringFormat, log4net");
					logMethod = logTypeInfo.GetMethod("Log", new ITypeInfo[4]
					{
						TypeFactory.GetTypeInfo(typeof(Type)),
						levelTypeInfo,
						TypeFactory.GetTypeInfo(typeof(object)),
						TypeFactory.GetTypeInfo(typeof(Exception))
					});
					isEnabledForMethod = logTypeInfo.GetMethod("IsEnabledFor", new ITypeInfo[1] { levelTypeInfo });
					if (getLoggerWithTypeMethod == null || isEnabledForMethod == null || logType == null || levelType == null || logMethod == null)
					{
						loadState = LoadState.Failed;
						return;
					}
					if (AWSConfigs.XmlSectionExists("log4net") && (AWSConfigs.LoggingConfig.LogTo & LoggingOptions.Log4Net) == LoggingOptions.Log4Net)
					{
						ITypeInfo typeInfo = TypeFactory.GetTypeInfo(Type.GetType("log4net.Config.XmlConfigurator, log4net"));
						if (typeInfo != null)
						{
							MethodInfo method = typeInfo.GetMethod("Configure", new ITypeInfo[0]);
							if (method != null)
							{
								method.Invoke(null, null);
							}
						}
					}
					loadState = LoadState.Success;
				}
				catch
				{
					loadState = LoadState.Failed;
				}
			}
		}

		public InternalLog4netLogger(Type declaringType)
			: base(declaringType)
		{
			if (loadState == LoadState.Uninitialized)
			{
				loadStatics();
			}
			if (!(logMangerType == null))
			{
				internalLogger = getLoggerWithTypeMethod.Invoke(null, new object[2]
				{
					TypeFactory.GetTypeInfo(declaringType).Assembly,
					declaringType
				});
			}
		}

		public override void Flush()
		{
		}

		public override void Error(Exception exception, string messageFormat, params object[] args)
		{
			logMethod.Invoke(internalLogger, new object[4]
			{
				loggerType,
				errorLevelPropertyValue,
				new LogMessage(CultureInfo.InvariantCulture, messageFormat, args),
				exception
			});
		}

		public override void Debug(Exception exception, string messageFormat, params object[] args)
		{
			logMethod.Invoke(internalLogger, new object[4]
			{
				loggerType,
				debugLevelPropertyValue,
				new LogMessage(CultureInfo.InvariantCulture, messageFormat, args),
				exception
			});
		}

		public override void DebugFormat(string message, params object[] arguments)
		{
			logMethod.Invoke(internalLogger, new object[4]
			{
				loggerType,
				debugLevelPropertyValue,
				new LogMessage(CultureInfo.InvariantCulture, message, arguments),
				null
			});
		}

		public override void InfoFormat(string message, params object[] arguments)
		{
			logMethod.Invoke(internalLogger, new object[4]
			{
				loggerType,
				infoLevelPropertyValue,
				new LogMessage(CultureInfo.InvariantCulture, message, arguments),
				null
			});
		}
	}
	public class LogMessage : ILogMessage
	{
		public object[] Args { get; private set; }

		public IFormatProvider Provider { get; private set; }

		public string Format { get; private set; }

		public LogMessage(string message)
			: this(CultureInfo.InvariantCulture, message)
		{
		}

		public LogMessage(string format, params object[] args)
			: this(CultureInfo.InvariantCulture, format, args)
		{
		}

		public LogMessage(IFormatProvider provider, string format, params object[] args)
		{
			Args = args;
			Format = format;
			Provider = provider;
		}

		public override string ToString()
		{
			return string.Format(Provider, Format, Args);
		}
	}
	public class LruCache<TKey, TValue> where TKey : class where TValue : class
	{
		private readonly object cacheLock = new object();

		private Dictionary<TKey, LruListItem<TKey, TValue>> cache;

		private LruList<TKey, TValue> lruList;

		public int MaxEntries { get; private set; }

		public int Count
		{
			get
			{
				lock (cacheLock)
				{
					return cache.Count;
				}
			}
		}

		public LruCache(int maxEntries)
		{
			if (maxEntries < 1)
			{
				throw new ArgumentException("maxEntries must be greater than zero.");
			}
			MaxEntries = maxEntries;
			cache = new Dictionary<TKey, LruListItem<TKey, TValue>>();
			lruList = new LruList<TKey, TValue>();
		}

		public void AddOrUpdate(TKey key, TValue value)
		{
			lock (cacheLock)
			{
				if (cache.TryGetValue(key, out var value2))
				{
					value2.Value = value;
					lruList.Touch(value2);
					return;
				}
				LruListItem<TKey, TValue> lruListItem = new LruListItem<TKey, TValue>(key, value);
				while (cache.Count >= MaxEntries)
				{
					cache.Remove(lruList.EvictOldest());
				}
				lruList.Add(lruListItem);
				cache.Add(key, lruListItem);
			}
		}

		public void Evict(TKey key)
		{
			lock (cacheLock)
			{
				if (cache.TryGetValue(key, out var value))
				{
					lruList.Remove(value);
					cache.Remove(key);
				}
			}
		}

		public bool TryGetValue(TKey key, out TValue value)
		{
			lock (cacheLock)
			{
				if (cache.TryGetValue(key, out var value2))
				{
					lruList.Touch(value2);
					value = value2.Value;
					return true;
				}
				value = null;
				return false;
			}
		}

		public TValue GetOrAdd(TKey key, Func<TKey, TValue> factory)
		{
			if (TryGetValue(key, out var value))
			{
				return value;
			}
			value = factory(key);
			AddOrUpdate(key, value);
			return value;
		}

		public void Clear()
		{
			lock (cacheLock)
			{
				cache.Clear();
				lruList.Clear();
			}
		}
	}
	public class LruList<TKey, TValue>
	{
		public LruListItem<TKey, TValue> Head { get; private set; }

		public LruListItem<TKey, TValue> Tail { get; private set; }

		public void Add(LruListItem<TKey, TValue> item)
		{
			if (Head == null)
			{
				Head = item;
				Tail = item;
				item.Previous = null;
				item.Next = null;
			}
			else
			{
				Head.Previous = item;
				item.Next = Head;
				item.Previous = null;
				Head = item;
			}
		}

		public void Remove(LruListItem<TKey, TValue> item)
		{
			if (Head == item || Tail == item)
			{
				if (Head == item)
				{
					Head = item.Next;
					if (Head != null)
					{
						Head.Previous = null;
					}
				}
				if (Tail == item)
				{
					Tail = item.Previous;
					if (Tail != null)
					{
						Tail.Next = null;
					}
				}
			}
			else
			{
				item.Previous.Next = item.Next;
				item.Next.Previous = item.Previous;
			}
			item.Previous = null;
			item.Next = null;
		}

		public void Touch(LruListItem<TKey, TValue> item)
		{
			Remove(item);
			Add(item);
		}

		public TKey EvictOldest()
		{
			TKey result = default(TKey);
			if (Tail != null)
			{
				result = Tail.Key;
				Remove(Tail);
			}
			return result;
		}

		internal void Clear()
		{
			Head = null;
			Tail = null;
		}
	}
	public class LruListItem<TKey, TValue>
	{
		public TValue Value { get; set; }

		public TKey Key { get; private set; }

		public LruListItem<TKey, TValue> Next { get; set; }

		public LruListItem<TKey, TValue> Previous { get; set; }

		public LruListItem(TKey key, TValue value)
		{
			Key = key;
			Value = value;
		}
	}
	public class RequestMetrics : IRequestMetrics
	{
		private object metricsLock = new object();

		private Stopwatch stopWatch;

		private Dictionary<Metric, Timing> inFlightTimings;

		private List<MetricError> errors = new List<MetricError>();

		private long CurrentTime => stopWatch.GetElapsedDateTimeTicks();

		public Dictionary<Metric, List<object>> Properties { get; set; }

		public Dictionary<Metric, List<IMetricsTiming>> Timings { get; set; }

		public Dictionary<Metric, long> Counters { get; set; }

		public bool IsEnabled { get; internal set; }

		private void LogError_Locked(Metric metric, string messageFormat, params object[] args)
		{
			errors.Add(new MetricError(metric, messageFormat, args));
		}

		private static void Log(StringBuilder builder, Metric metric, object metricValue)
		{
			LogHelper(builder, metric, metricValue);
		}

		private static void Log(StringBuilder builder, Metric metric, List<object> metricValues)
		{
			if (metricValues == null || metricValues.Count == 0)
			{
				LogHelper(builder, metric);
			}
			else
			{
				LogHelper(builder, metric, metricValues.ToArray());
			}
		}

		private static void LogHelper(StringBuilder builder, Metric metric, params object[] metricValues)
		{
			builder.AppendFormat(CultureInfo.InvariantCulture, "{0} = ", metric);
			if (metricValues == null)
			{
				builder.Append(ObjectToString(metricValues));
			}
			else
			{
				for (int i = 0; i < metricValues.Length; i = checked(i + 1))
				{
					string value = ObjectToString(metricValues[i]);
					if (i > 0)
					{
						builder.Append(", ");
					}
					builder.Append(value);
				}
			}
			builder.Append("; ");
		}

		private static string ObjectToString(object data)
		{
			if (data == null)
			{
				return "NULL";
			}
			return data.ToString();
		}

		public RequestMetrics()
		{
			stopWatch = Stopwatch.StartNew();
			Properties = new Dictionary<Metric, List<object>>();
			Timings = new Dictionary<Metric, List<IMetricsTiming>>();
			Counters = new Dictionary<Metric, long>();
			inFlightTimings = new Dictionary<Metric, Timing>();
			IsEnabled = false;
		}

		public TimingEvent StartEvent(Metric metric)
		{
			lock (metricsLock)
			{
				if (inFlightTimings.ContainsKey(metric))
				{
					LogError_Locked(metric, "Starting multiple events for the same metric");
				}
				inFlightTimings[metric] = new Timing(CurrentTime);
			}
			return new TimingEvent(this, metric);
		}

		public Timing StopEvent(Metric metric)
		{
			Timing value;
			lock (metricsLock)
			{
				if (!inFlightTimings.TryGetValue(metric, out value))
				{
					LogError_Locked(metric, "Trying to stop event that has not been started");
					return new Timing();
				}
				inFlightTimings.Remove(metric);
				value.Stop(CurrentTime);
				if (IsEnabled)
				{
					if (!Timings.TryGetValue(metric, out var value2))
					{
						value2 = new List<IMetricsTiming>();
						Timings[metric] = value2;
					}
					value2.Add(value);
				}
			}
			return value;
		}

		public void AddProperty(Metric metric, object property)
		{
			if (!IsEnabled)
			{
				return;
			}
			lock (metricsLock)
			{
				if (!Properties.TryGetValue(metric, out var value))
				{
					value = new List<object>();
					Properties[metric] = value;
				}
				value.Add(property);
			}
		}

		public void SetCounter(Metric metric, long value)
		{
			if (!IsEnabled)
			{
				return;
			}
			lock (metricsLock)
			{
				Counters[metric] = value;
			}
		}

		public void IncrementCounter(Metric metric)
		{
			if (!IsEnabled)
			{
				return;
			}
			lock (metricsLock)
			{
				long value = (Counters.TryGetValue(metric, out value) ? checked(value + 1) : 1);
				Counters[metric] = value;
			}
		}

		public string GetErrors()
		{
			using StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
			lock (metricsLock)
			{
				if (inFlightTimings.Count > 0)
				{
					string arg = string.Join(", ", inFlightTimings.Keys.Select((Metric k) => k.ToString()).ToArray());
					stringWriter.Write("Timings are still in flight: {0}.", arg);
				}
				if (errors.Count > 0)
				{
					stringWriter.Write("Logged {0} metrics errors: ", errors.Count);
					foreach (MetricError error in errors)
					{
						if (error.Exception != null || !string.IsNullOrEmpty(error.Message))
						{
							stringWriter.Write("{0} - {1} - ", error.Time.ToUniversalTime().ToString("yyyy-MM-dd\\THH:mm:ss.fff\\Z", CultureInfo.InvariantCulture), error.Metric);
							if (!string.IsNullOrEmpty(error.Message))
							{
								stringWriter.Write(error.Message);
								stringWriter.Write(";");
							}
							if (error.Exception != null)
							{
								stringWriter.Write(error.Exception);
								stringWriter.Write("; ");
							}
						}
					}
				}
			}
			return stringWriter.ToString();
		}

		public override string ToString()
		{
			if (!IsEnabled)
			{
				return "Metrics logging disabled";
			}
			StringBuilder stringBuilder = new StringBuilder();
			if (AWSConfigs.LoggingConfig.LogMetricsCustomFormatter != null)
			{
				try
				{
					lock (metricsLock)
					{
						stringBuilder.Append(AWSConfigs.LoggingConfig.LogMetricsCustomFormatter.FormatMetrics(this));
					}
					return stringBuilder.ToString();
				}
				catch (Exception ex)
				{
					stringBuilder.Append("[Custom metrics formatter failed: ").Append(ex.Message).Append("] ");
				}
			}
			if (AWSConfigs.LoggingConfig.LogMetricsFormat == LogMetricsFormatOption.JSON)
			{
				lock (metricsLock)
				{
					stringBuilder.Append(ToJSON());
				}
				return stringBuilder.ToString();
			}
			lock (metricsLock)
			{
				foreach (KeyValuePair<Metric, List<object>> property in Properties)
				{
					Metric key = property.Key;
					List<object> value = property.Value;
					Log(stringBuilder, key, value);
				}
				foreach (KeyValuePair<Metric, List<IMetricsTiming>> timing in Timings)
				{
					Metric key2 = timing.Key;
					foreach (IMetricsTiming item in timing.Value)
					{
						if (item.IsFinished)
						{
							Log(stringBuilder, key2, item.ElapsedTime);
						}
					}
				}
				foreach (KeyValuePair<Metric, long> counter in Counters)
				{
					Metric key3 = counter.Key;
					long value2 = counter.Value;
					Log(stringBuilder, key3, value2);
				}
			}
			stringBuilder.Replace("\r", "\\r").Replace("\n", "\\n");
			return stringBuilder.ToString();
		}

		public string ToJSON()
		{
			if (!IsEnabled)
			{
				return "{ }";
			}
			StringBuilder stringBuilder = new StringBuilder();
			JsonWriter jsonWriter = new JsonWriter(stringBuilder);
			jsonWriter.WriteObjectStart();
			jsonWriter.WritePropertyName("properties");
			jsonWriter.WriteObjectStart();
			foreach (KeyValuePair<Metric, List<object>> property in Properties)
			{
				jsonWriter.WritePropertyName(property.Key.ToString());
				List<object> value = property.Value;
				if (value.Count > 1)
				{
					jsonWriter.WriteArrayStart();
				}
				foreach (object item in value)
				{
					if (item == null)
					{
						jsonWriter.Write(null);
					}
					else
					{
						jsonWriter.Write(item.ToString());
					}
				}
				if (value.Count > 1)
				{
					jsonWriter.WriteArrayEnd();
				}
			}
			jsonWriter.WriteObjectEnd();
			jsonWriter.WritePropertyName("timings");
			jsonWriter.WriteObjectStart();
			foreach (KeyValuePair<Metric, List<IMetricsTiming>> timing in Timings)
			{
				jsonWriter.WritePropertyName(timing.Key.ToString());
				List<IMetricsTiming> value2 = timing.Value;
				if (value2.Count > 1)
				{
					jsonWriter.WriteArrayStart();
				}
				foreach (IMetricsTiming item2 in timing.Value)
				{
					if (item2.IsFinished)
					{
						jsonWriter.Write(item2.ElapsedTime.TotalMilliseconds);
					}
				}
				if (value2.Count > 1)
				{
					jsonWriter.WriteArrayEnd();
				}
			}
			jsonWriter.WriteObjectEnd();
			jsonWriter.WritePropertyName("counters");
			jsonWriter.WriteObjectStart();
			foreach (KeyValuePair<Metric, long> counter in Counters)
			{
				jsonWriter.WritePropertyName(counter.Key.ToString());
				jsonWriter.Write(counter.Value);
			}
			jsonWriter.WriteObjectEnd();
			jsonWriter.WriteObjectEnd();
			return stringBuilder.ToString();
		}
	}
	public class Timing : IMetricsTiming
	{
		private long startTime;

		private long endTime;

		public bool IsFinished { get; private set; }

		public long ElapsedTicks
		{
			get
			{
				if (IsFinished)
				{
					return checked(endTime - startTime);
				}
				return 0L;
			}
		}

		public TimeSpan ElapsedTime => TimeSpan.FromTicks(ElapsedTicks);

		public Timing()
		{
			startTime = (endTime = 0L);
			IsFinished = true;
		}

		public Timing(long currentTime)
		{
			startTime = currentTime;
			IsFinished = false;
		}

		public void Stop(long currentTime)
		{
			endTime = currentTime;
			IsFinished = true;
		}
	}
	public class TimingEvent : IDisposable
	{
		private Metric metric;

		private RequestMetrics metrics;

		private bool disposed;

		internal TimingEvent(RequestMetrics metrics, Metric metric)
		{
			this.metrics = metrics;
			this.metric = metric;
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					metrics.StopEvent(metric);
				}
				disposed = true;
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		~TimingEvent()
		{
			Dispose(disposing: false);
		}
	}
	public class MetricError
	{
		public Metric Metric { get; private set; }

		public string Message { get; private set; }

		public Exception Exception { get; private set; }

		public DateTime Time { get; private set; }

		public MetricError(Metric metric, string messageFormat, params object[] args)
			: this(metric, null, messageFormat, args)
		{
		}

		public MetricError(Metric metric, Exception exception, string messageFormat, params object[] args)
		{
			Time = AWSSDKUtils.CorrectedUtcNow;
			try
			{
				Message = string.Format(CultureInfo.InvariantCulture, messageFormat, args);
			}
			catch
			{
				Message = string.Format(CultureInfo.InvariantCulture, "Error message: {0}", messageFormat);
			}
			Exception = exception;
			Metric = metric;
		}
	}
	public class NonDisposingWrapperStream : WrapperStream
	{
		public NonDisposingWrapperStream(Stream baseStream)
			: base(baseStream)
		{
		}

		protected override void Dispose(bool disposing)
		{
		}
	}
	internal class NullStream : Stream
	{
		public override bool CanRead => false;

		public override bool CanSeek => false;

		public override bool CanWrite => true;

		public override long Length => 0L;

		public override long Position
		{
			get
			{
				return 0L;
			}
			set
			{
			}
		}

		public override void Flush()
		{
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return 0;
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return 0L;
		}

		public override void SetLength(long value)
		{
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
		}
	}
	public class PartialWrapperStream : WrapperStream
	{
		private long initialPosition;

		private long partSize;

		private long RemainingPartSize => checked(partSize - Position);

		public override long Length
		{
			get
			{
				long num = checked(base.Length - initialPosition);
				if (num > partSize)
				{
					num = partSize;
				}
				return num;
			}
		}

		public override long Position
		{
			get
			{
				return checked(base.Position - initialPosition);
			}
			set
			{
				base.Position = checked(initialPosition + value);
			}
		}

		public PartialWrapperStream(Stream stream, long partSize)
			: base(stream)
		{
			if (!stream.CanSeek)
			{
				throw new InvalidOperationException("Base stream of PartialWrapperStream must be seekable");
			}
			initialPosition = stream.Position;
			long num = checked(stream.Length - stream.Position);
			if (partSize == 0L || num < partSize)
			{
				this.partSize = num;
			}
			else
			{
				this.partSize = partSize;
			}
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			int num = ((count < RemainingPartSize) ? count : checked((int)RemainingPartSize));
			if (num <= 0)
			{
				return 0;
			}
			return base.Read(buffer, offset, num);
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			long num = 0L;
			checked
			{
				switch (origin)
				{
				case SeekOrigin.Begin:
					num = initialPosition + offset;
					break;
				case SeekOrigin.Current:
					num = base.Position + offset;
					break;
				case SeekOrigin.End:
					num = base.Position + partSize + offset;
					break;
				}
				if (num < initialPosition)
				{
					num = initialPosition;
				}
				else if (num > initialPosition + partSize)
				{
					num = initialPosition + partSize;
				}
				base.Position = num;
				return Position;
			}
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}

		public override void WriteByte(byte value)
		{
			throw new NotSupportedException();
		}

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			int num = ((count < RemainingPartSize) ? count : checked((int)RemainingPartSize));
			if (num <= 0)
			{
				return 0;
			}
			return await base.ReadAsync(buffer, offset, num, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			throw new NotSupportedException();
		}
	}
	public class ReadOnlyWrapperStream : WrapperStream
	{
		public override bool CanRead => true;

		public override bool CanSeek => false;

		public override bool CanWrite => false;

		public override long Length
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public override long Position
		{
			get
			{
				throw new NotSupportedException();
			}
			set
			{
				throw new NotSupportedException();
			}
		}

		public ReadOnlyWrapperStream(Stream baseStream)
			: base(baseStream)
		{
			if (!baseStream.CanRead)
			{
				throw new InvalidOperationException("Base stream must be readable");
			}
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			throw new NotSupportedException();
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			throw new NotSupportedException();
		}

		public override void SetLength(long value)
		{
			throw new NotSupportedException();
		}

		public override void Flush()
		{
			throw new NotSupportedException();
		}

		public override Task FlushAsync(CancellationToken cancellationToken)
		{
			throw new NotSupportedException();
		}

		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			throw new NotSupportedException();
		}
	}
	public class PartialReadOnlyWrapperStream : ReadOnlyWrapperStream
	{
		private long _currentPosition;

		private long _size;

		private long RemainingSize => checked(_size - _currentPosition);

		public override long Length => _size;

		public override long Position => _currentPosition;

		public PartialReadOnlyWrapperStream(Stream baseStream, long size)
			: base(baseStream)
		{
			_currentPosition = 0L;
			_size = size;
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			checked
			{
				int num = ((count < RemainingSize) ? count : ((int)RemainingSize));
				if (num <= 0)
				{
					return 0;
				}
				int num2 = base.Read(buffer, offset, num);
				_currentPosition += num2;
				return num2;
			}
		}

		public override async Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			checked
			{
				int num = ((count < RemainingSize) ? count : ((int)RemainingSize));
				if (num <= 0)
				{
					return 0;
				}
				int num2 = await base.ReadAsync(buffer, offset, num, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				_currentPosition += num2;
				return num2;
			}
		}
	}
	public class S3Uri
	{
		private const string S3EndpointPattern = "^(.+\\.)?s3[.-]([a-z0-9-]+)\\.";

		private const string S3ControlExlusionPattern = "^(.+\\.)?s3-control\\.";

		private static readonly Regex S3EndpointRegex = new Regex("^(.+\\.)?s3[.-]([a-z0-9-]+)\\.");

		private static readonly Regex S3ControlExlusionRegex = new Regex("^(.+\\.)?s3-control\\.");

		public bool IsPathStyle { get; private set; }

		public string Bucket { get; private set; }

		public string Key { get; private set; }

		public RegionEndpoint Region { get; set; }

		public S3Uri(string uri)
			: this(new System.Uri(uri))
		{
		}

		public S3Uri(System.Uri uri)
		{
			if (uri == null)
			{
				throw new ArgumentNullException("uri");
			}
			if (string.IsNullOrEmpty(uri.Host))
			{
				throw new ArgumentException("Invalid URI - no hostname present");
			}
			Match match = S3EndpointRegex.Match(uri.Host);
			if (!match.Success && !S3ControlExlusionRegex.Match(uri.Host).Success)
			{
				throw new ArgumentException("Invalid S3 URI - hostname does not appear to be a valid S3 endpoint");
			}
			Group obj = match.Groups[1];
			checked
			{
				if (string.IsNullOrEmpty(obj.Value))
				{
					IsPathStyle = true;
					string absolutePath = uri.AbsolutePath;
					if (absolutePath.Equals("/"))
					{
						Bucket = null;
						Key = null;
					}
					else
					{
						int num = absolutePath.IndexOf('/', 1);
						if (num == -1)
						{
							Bucket = Decode(absolutePath.Substring(1));
							Key = null;
						}
						else if (num == absolutePath.Length - 1)
						{
							Bucket = Decode(absolutePath.Substring(1, num)).TrimEnd(new char[1] { '/' });
							Key = null;
						}
						else
						{
							Bucket = Decode(absolutePath.Substring(1, num)).TrimEnd(new char[1] { '/' });
							Key = Decode(absolutePath.Substring(num + 1));
						}
					}
				}
				else
				{
					IsPathStyle = false;
					Bucket = obj.Value.TrimEnd(new char[1] { '.' });
					Key = (uri.AbsolutePath.Equals("/") ? null : uri.AbsolutePath.Substring(1));
				}
				if (match.Groups.Count > 2)
				{
					string value = match.Groups[2].Value;
					if (value.Equals("amazonaws", StringComparison.Ordinal) || value.Equals("external-1", StringComparison.Ordinal))
					{
						Region = RegionEndpoint.USEast1;
					}
					else
					{
						Region = RegionEndpoint.GetBySystemName(value);
					}
				}
			}
		}

		public static bool IsS3Uri(System.Uri uri)
		{
			if (S3EndpointRegex.Match(uri.Host).Success)
			{
				return !S3ControlExlusionRegex.Match(uri.Host).Success;
			}
			return false;
		}

		private static string Decode(string s)
		{
			if (s == null)
			{
				return null;
			}
			for (int i = 0; i < s.Length; i = checked(i + 1))
			{
				if (s[i] == '%')
				{
					return Decode(s, i);
				}
			}
			return s;
		}

		private static string Decode(string s, int firstPercent)
		{
			StringBuilder stringBuilder = new StringBuilder(s.Substring(0, firstPercent));
			AppendDecoded(stringBuilder, s, firstPercent);
			checked
			{
				for (int i = firstPercent + 3; i < s.Length; i++)
				{
					if (s[i] == '%')
					{
						AppendDecoded(stringBuilder, s, i);
						i += 2;
					}
					else
					{
						stringBuilder.Append(s[i]);
					}
				}
				return stringBuilder.ToString();
			}
		}

		private static void AppendDecoded(StringBuilder builder, string s, int index)
		{
			char c;
			char c2;
			checked
			{
				if (index > s.Length - 3)
				{
					throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Invalid percent-encoded string '{0}'", s));
				}
				c = s[index + 1];
				c2 = s[index + 2];
			}
			char value = (char)checked((ushort)((FromHex(c) << 4) | FromHex(c2)));
			builder.Append(value);
		}

		private static int FromHex(char c)
		{
			if (c < '0')
			{
				throw new InvalidOperationException("Invalid percent-encoded string: bad character '" + c + "' in escape sequence.");
			}
			checked
			{
				if (c <= '9')
				{
					return c - 48;
				}
				if (c < 'A')
				{
					throw new InvalidOperationException("Invalid percent-encoded string: bad character '" + c + "' in escape sequence.");
				}
				if (c <= 'F')
				{
					return c - 65 + 10;
				}
				if (c < 'a')
				{
					throw new InvalidOperationException("Invalid percent-encoded string: bad character '" + c + "' in escape sequence.");
				}
				if (c <= 'f')
				{
					return c - 97 + 10;
				}
				throw new InvalidOperationException("Invalid percent-encoded string: bad character '" + c + "' in escape sequence.");
			}
		}
	}
	public interface ICache
	{
		TimeSpan MaximumItemLifespan { get; set; }

		TimeSpan CacheClearPeriod { get; set; }

		int ItemCount { get; }

		void Clear();
	}
	public interface ICache<TKey, TValue> : ICache
	{
		List<TKey> Keys { get; }

		TValue GetValue(TKey key, Func<TKey, TValue> creator);

		TValue GetValue(TKey key, Func<TKey, TValue> creator, out bool isStaleItem);

		void Clear(TKey key);

		TOut UseCache<TOut>(TKey key, Func<TOut> operation, Action onError, Predicate<Exception> shouldRetryForException);
	}
	public static class SdkCache
	{
		internal class CacheKey
		{
			public ImmutableCredentials ImmutableCredentials { get; private set; }

			public RegionEndpoint RegionEndpoint { get; private set; }

			public string ServiceUrl { get; private set; }

			public object CacheType { get; private set; }

			private CacheKey()
			{
				ImmutableCredentials = null;
				RegionEndpoint = null;
				ServiceUrl = null;
				CacheType = null;
			}

			public static CacheKey Create(AmazonServiceClient client, object cacheType)
			{
				if (client == null)
				{
					throw new ArgumentNullException("client");
				}
				return new CacheKey
				{
					ImmutableCredentials = client.Credentials?.GetCredentials(),
					RegionEndpoint = client.Config.RegionEndpoint,
					ServiceUrl = client.Config.ServiceURL,
					CacheType = cacheType
				};
			}

			public static CacheKey Create(object cacheType)
			{
				return new CacheKey
				{
					CacheType = cacheType
				};
			}

			public override int GetHashCode()
			{
				return Hashing.Hash(ImmutableCredentials, RegionEndpoint, ServiceUrl, CacheType);
			}

			public override bool Equals(object obj)
			{
				if (this == obj)
				{
					return true;
				}
				if (!(obj is CacheKey cacheKey))
				{
					return false;
				}
				return AWSSDKUtils.AreEqual(new object[4] { ImmutableCredentials, RegionEndpoint, ServiceUrl, CacheType }, new object[4] { cacheKey.ImmutableCredentials, cacheKey.RegionEndpoint, cacheKey.ServiceUrl, cacheKey.CacheType });
			}
		}

		private static object cacheLock = new object();

		private static Cache<CacheKey, ICache> cache = new Cache<CacheKey, ICache>();

		public static void Clear()
		{
			cache.Clear();
		}

		public static void Clear(object cacheType)
		{
			lock (cacheLock)
			{
				foreach (CacheKey key in cache.Keys)
				{
					if (AWSSDKUtils.AreEqual(key.CacheType, cacheType))
					{
						cache.GetValue(key, null).Clear();
					}
				}
			}
		}

		public static ICache<TKey, TValue> GetCache<TKey, TValue>(object client, object cacheIdentifier, IEqualityComparer<TKey> keyComparer)
		{
			return GetCache<TKey, TValue>(client as AmazonServiceClient, cacheIdentifier, keyComparer);
		}

		public static ICache<TKey, TValue> GetCache<TKey, TValue>(AmazonServiceClient client, object cacheIdentifier, IEqualityComparer<TKey> keyComparer)
		{
			CacheKey key = ((client != null) ? CacheKey.Create(client, cacheIdentifier) : CacheKey.Create(cacheIdentifier));
			ICache cache = null;
			lock (cacheLock)
			{
				cache = SdkCache.cache.GetValue(key, (CacheKey k) => new Cache<TKey, TValue>(keyComparer));
			}
			Cache<TKey, TValue> cache2 = cache as Cache<TKey, TValue>;
			if (cache != null && cache2 == null)
			{
				throw new InvalidOperationException(string.Format(CultureInfo.InvariantCulture, "Unable to cast cache of type {0} as cache of type {1}", cache.GetType().FullName, typeof(Cache<TKey, TValue>).FullName));
			}
			return cache2;
		}
	}
	internal class Cache<TKey, TValue> : ICache<TKey, TValue>, ICache
	{
		private class CacheItem<T>
		{
			private T _value;

			public T Value
			{
				get
				{
					LastUseTime = Cache<TKey, TValue>.GetCorrectedLocalTime();
					return _value;
				}
				private set
				{
					_value = value;
				}
			}

			public DateTime LastUseTime { get; private set; }

			public CacheItem(T value)
			{
				Value = value;
				LastUseTime = Cache<TKey, TValue>.GetCorrectedLocalTime();
			}
		}

		private Dictionary<TKey, CacheItem<TValue>> Contents;

		private readonly object CacheLock = new object();

		public static TimeSpan DefaultMaximumItemLifespan = TimeSpan.FromHours(6.0);

		public static TimeSpan DefaultCacheClearPeriod = TimeSpan.FromHours(1.0);

		private TimeSpan maximumItemLifespan;

		private TimeSpan cacheClearPeriod;

		public DateTime LastCacheClean { get; private set; }

		public List<TKey> Keys
		{
			get
			{
				lock (CacheLock)
				{
					return Contents.Keys.ToList();
				}
			}
		}

		public TimeSpan MaximumItemLifespan
		{
			get
			{
				return maximumItemLifespan;
			}
			set
			{
				if (value < TimeSpan.Zero)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				maximumItemLifespan = value;
			}
		}

		public TimeSpan CacheClearPeriod
		{
			get
			{
				return cacheClearPeriod;
			}
			set
			{
				if (value < TimeSpan.Zero)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				cacheClearPeriod = value;
			}
		}

		public int ItemCount
		{
			get
			{
				lock (CacheLock)
				{
					return Contents.Count;
				}
			}
		}

		public Cache(IEqualityComparer<TKey> keyComparer = null)
		{
			Contents = new Dictionary<TKey, CacheItem<TValue>>(keyComparer);
			MaximumItemLifespan = DefaultMaximumItemLifespan;
			CacheClearPeriod = DefaultCacheClearPeriod;
		}

		public TValue GetValue(TKey key, Func<TKey, TValue> creator)
		{
			bool isStaleItem;
			return GetValueHelper(key, out isStaleItem, creator);
		}

		public TValue GetValue(TKey key, Func<TKey, TValue> creator, out bool isStaleItem)
		{
			return GetValueHelper(key, out isStaleItem, creator);
		}

		public void Clear(TKey key)
		{
			lock (CacheLock)
			{
				Contents.Remove(key);
			}
		}

		public void Clear()
		{
			lock (CacheLock)
			{
				Contents.Clear();
				LastCacheClean = GetCorrectedLocalTime();
			}
		}

		public TOut UseCache<TOut>(TKey key, Func<TOut> operation, Action onError, Predicate<Exception> shouldRetryForException)
		{
			TOut val = default(TOut);
			try
			{
				return operation();
			}
			catch (Exception obj)
			{
				if (shouldRetryForException == null || shouldRetryForException(obj))
				{
					Clear(key);
					onError?.Invoke();
					return operation();
				}
				throw;
			}
		}

		private TValue GetValueHelper(TKey key, out bool isStaleItem, Func<TKey, TValue> creator = null)
		{
			isStaleItem = true;
			CacheItem<TValue> value = null;
			if (AWSConfigs.UseSdkCache)
			{
				lock (CacheLock)
				{
					if (!Contents.TryGetValue(key, out value) || !IsValidItem(value))
					{
						if (creator == null)
						{
							throw new InvalidOperationException("Unable to calculate value for key " + key);
						}
						TValue value2 = creator(key);
						isStaleItem = false;
						value = new CacheItem<TValue>(value2);
						Contents[key] = value;
						RemoveOldItems_Locked();
					}
				}
			}
			else
			{
				if (creator == null)
				{
					throw new InvalidOperationException("Unable to calculate value for key " + key);
				}
				value = new CacheItem<TValue>(creator(key));
				isStaleItem = false;
			}
			if (value == null)
			{
				throw new InvalidOperationException("Unable to find value for key " + key);
			}
			return value.Value;
		}

		private bool IsValidItem(CacheItem<TValue> item)
		{
			if (item == null)
			{
				return false;
			}
			DateTime dateTime = GetCorrectedLocalTime() - MaximumItemLifespan;
			if (item.LastUseTime < dateTime)
			{
				return false;
			}
			return true;
		}

		private void RemoveOldItems_Locked()
		{
			if (LastCacheClean + CacheClearPeriod > AWSConfigs.utcNowSource().ToLocalTime())
			{
				return;
			}
			DateTime dateTime = GetCorrectedLocalTime() - MaximumItemLifespan;
			List<TKey> list = new List<TKey>();
			foreach (KeyValuePair<TKey, CacheItem<TValue>> content in Contents)
			{
				TKey key = content.Key;
				CacheItem<TValue> value = content.Value;
				if (value == null || value.LastUseTime < dateTime)
				{
					list.Add(key);
				}
			}
			foreach (TKey item in list)
			{
				Contents.Remove(item);
			}
			LastCacheClean = GetCorrectedLocalTime();
		}

		private static DateTime GetCorrectedLocalTime()
		{
			return AWSSDKUtils.CorrectedUtcNow.ToLocalTime();
		}
	}
	public static class StringUtils
	{
		private static readonly Encoding UTF_8 = Encoding.UTF8;

		public static string FromString(string value)
		{
			return value;
		}

		public static string FromStringWithSlashEncoding(string value)
		{
			return AWSSDKUtils.UrlEncodeSlash(FromString(value));
		}

		public static string FromString(ConstantClass value)
		{
			if (!(value == null))
			{
				return value.Intern().Value;
			}
			return "";
		}

		public static string FromMemoryStream(MemoryStream value)
		{
			return Convert.ToBase64String(value.ToArray());
		}

		public static string FromInt(int value)
		{
			return value.ToString(CultureInfo.InvariantCulture);
		}

		public static string FromInt(int? value)
		{
			if (value.HasValue)
			{
				return value.Value.ToString(CultureInfo.InvariantCulture);
			}
			return null;
		}

		public static string FromLong(long value)
		{
			return value.ToString(CultureInfo.InvariantCulture);
		}

		public static string FromBool(bool value)
		{
			if (!value)
			{
				return "false";
			}
			return "true";
		}

		[Obsolete("This method doesn't handle correctly non-UTC DateTimes. Use FromDateTimeToISO8601 instead.", false)]
		public static string FromDateTime(DateTime value)
		{
			return value.ToString("yyyy-MM-dd\\THH:mm:ss.fff\\Z", CultureInfo.InvariantCulture);
		}

		public static string FromDateTimeToISO8601(DateTime value)
		{
			return value.ToUniversalTime().ToString("yyyy-MM-dd\\THH:mm:ss.fff\\Z", CultureInfo.InvariantCulture);
		}

		public static string FromDateTimeToRFC822(DateTime value)
		{
			return value.ToUniversalTime().ToString("ddd, dd MMM yyyy HH:mm:ss \\G\\M\\T", CultureInfo.InvariantCulture);
		}

		public static string FromDateTimeToUnixTimestamp(DateTime value)
		{
			return AWSSDKUtils.ConvertToUnixEpochSecondsString(value);
		}

		public static string FromDouble(double value)
		{
			return value.ToString(CultureInfo.InvariantCulture);
		}

		public static string FromDecimal(decimal value)
		{
			return value.ToString(CultureInfo.InvariantCulture);
		}

		public static long Utf8ByteLength(string value)
		{
			if (value == null)
			{
				return 0L;
			}
			return UTF_8.GetByteCount(value);
		}
	}
	public class WrapperStream : Stream
	{
		protected Stream BaseStream { get; private set; }

		public override bool CanRead => BaseStream.CanRead;

		public override bool CanSeek => BaseStream.CanSeek;

		public override bool CanWrite => BaseStream.CanWrite;

		public override long Length => BaseStream.Length;

		public override long Position
		{
			get
			{
				return BaseStream.Position;
			}
			set
			{
				BaseStream.Position = value;
			}
		}

		public override int ReadTimeout
		{
			get
			{
				return BaseStream.ReadTimeout;
			}
			set
			{
				BaseStream.ReadTimeout = value;
			}
		}

		public override int WriteTimeout
		{
			get
			{
				return BaseStream.WriteTimeout;
			}
			set
			{
				BaseStream.WriteTimeout = value;
			}
		}

		internal virtual bool HasLength => true;

		public WrapperStream(Stream baseStream)
		{
			if (baseStream == null)
			{
				throw new ArgumentNullException("baseStream");
			}
			BaseStream = baseStream;
		}

		public Stream GetNonWrapperBaseStream()
		{
			Stream stream = this;
			do
			{
				if (stream is PartialWrapperStream result)
				{
					return result;
				}
				stream = (stream as WrapperStream).BaseStream;
			}
			while (stream is WrapperStream);
			return stream;
		}

		public Stream GetSeekableBaseStream()
		{
			Stream stream = this;
			do
			{
				if (stream.CanSeek)
				{
					return stream;
				}
				stream = (stream as WrapperStream).BaseStream;
			}
			while (stream is WrapperStream);
			if (!stream.CanSeek)
			{
				throw new InvalidOperationException("Unable to find seekable stream");
			}
			return stream;
		}

		public static Stream GetNonWrapperBaseStream(Stream stream)
		{
			if (!(stream is WrapperStream wrapperStream))
			{
				return stream;
			}
			return wrapperStream.GetNonWrapperBaseStream();
		}

		public Stream SearchWrappedStream(Func<Stream, bool> condition)
		{
			Stream stream = this;
			do
			{
				if (condition(stream))
				{
					return stream;
				}
				if (!(stream is WrapperStream))
				{
					return null;
				}
				stream = (stream as WrapperStream).BaseStream;
			}
			while (stream != null);
			return stream;
		}

		public static Stream SearchWrappedStream(Stream stream, Func<Stream, bool> condition)
		{
			if (!(stream is WrapperStream wrapperStream))
			{
				if (!condition(stream))
				{
					return null;
				}
				return stream;
			}
			return wrapperStream.SearchWrappedStream(condition);
		}

		protected override void Dispose(bool disposing)
		{
			base.Dispose(disposing);
			BaseStream.Dispose();
		}

		public override void Flush()
		{
			BaseStream.Flush();
		}

		public override int Read(byte[] buffer, int offset, int count)
		{
			return BaseStream.Read(buffer, offset, count);
		}

		public override long Seek(long offset, SeekOrigin origin)
		{
			return BaseStream.Seek(offset, origin);
		}

		public override void SetLength(long value)
		{
			BaseStream.SetLength(value);
		}

		public override void Write(byte[] buffer, int offset, int count)
		{
			BaseStream.Write(buffer, offset, count);
		}

		public override Task FlushAsync(CancellationToken cancellationToken)
		{
			return BaseStream.FlushAsync(cancellationToken);
		}

		public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return BaseStream.ReadAsync(buffer, offset, count, cancellationToken);
		}

		public override Task WriteAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
		{
			return BaseStream.WriteAsync(buffer, offset, count, cancellationToken);
		}
	}
	public static class AsyncHelpers
	{
		private class ExclusiveSynchronizationContext : SynchronizationContext
		{
			private bool done;

			private readonly AutoResetEvent pendingObjects = new AutoResetEvent(initialState: false);

			private readonly Queue<Tuple<SendOrPostCallback, object>> objects = new Queue<Tuple<SendOrPostCallback, object>>();

			public Exception ObjectException { get; set; }

			public override void Send(SendOrPostCallback d, object state)
			{
				throw new NotSupportedException("We cannot send to our same thread");
			}

			public override void Post(SendOrPostCallback d, object state)
			{
				lock (objects)
				{
					objects.Enqueue(Tuple.Create(d, state));
				}
				pendingObjects.Set();
			}

			public void EndMessageLoop()
			{
				Post(delegate
				{
					done = true;
				}, null);
			}

			public void BeginMessageLoop()
			{
				while (!done)
				{
					Tuple<SendOrPostCallback, object> tuple = null;
					lock (objects)
					{
						if (objects.Count > 0)
						{
							tuple = objects.Dequeue();
						}
					}
					if (tuple != null)
					{
						tuple.Item1(tuple.Item2);
						if (ObjectException != null)
						{
							ExceptionDispatchInfo.Capture(ObjectException).Throw();
						}
					}
					else
					{
						pendingObjects.WaitOne();
					}
				}
			}

			public override SynchronizationContext CreateCopy()
			{
				return this;
			}
		}

		public static void RunSync(Func<Task> workItem)
		{
			SynchronizationContext current = SynchronizationContext.Current;
			try
			{
				ExclusiveSynchronizationContext synch = new ExclusiveSynchronizationContext();
				SynchronizationContext.SetSynchronizationContext(synch);
				synch.Post(async delegate
				{
					try
					{
						await workItem().ConfigureAwait(continueOnCapturedContext: false);
					}
					catch (Exception objectException)
					{
						synch.ObjectException = objectException;
						throw;
					}
					finally
					{
						synch.EndMessageLoop();
					}
				}, null);
				synch.BeginMessageLoop();
			}
			finally
			{
				SynchronizationContext.SetSynchronizationContext(current);
			}
		}

		public static T RunSync<T>(Func<Task<T>> workItem)
		{
			SynchronizationContext current = SynchronizationContext.Current;
			try
			{
				ExclusiveSynchronizationContext synch = new ExclusiveSynchronizationContext();
				SynchronizationContext.SetSynchronizationContext(synch);
				T ret = default(T);
				synch.Post(async delegate
				{
					try
					{
						_ = ret;
						ret = await workItem().ConfigureAwait(continueOnCapturedContext: false);
					}
					catch (Exception objectException)
					{
						synch.ObjectException = objectException;
						throw;
					}
					finally
					{
						synch.EndMessageLoop();
					}
				}, null);
				synch.BeginMessageLoop();
				return ret;
			}
			finally
			{
				SynchronizationContext.SetSynchronizationContext(current);
			}
		}
	}
	public class WebProxy : IWebProxy
	{
		public System.Uri ProxyUri { get; set; }

		public ICredentials Credentials { get; set; }

		public WebProxy(string proxyUri)
			: this(new System.Uri(proxyUri))
		{
		}

		public WebProxy(System.Uri proxyUri)
		{
			ProxyUri = proxyUri;
		}

		public WebProxy(string proxyHost, int proxyPort)
			: this(new System.Uri("http://" + proxyHost + ":" + proxyPort))
		{
		}

		public System.Uri GetProxy(System.Uri destination)
		{
			return ProxyUri;
		}

		public bool IsBypassed(System.Uri host)
		{
			return false;
		}
	}
	internal class InternalFileLogger : InternalLogger
	{
		private enum LogLevel
		{
			Verbose,
			Debug,
			Info,
			Error
		}

		private const string DebugMsgFormat = "AWSSDK DEBUG {0} {1}";

		private const string ErrorMsgFormat = "AWSSDK ERROR {0} {1}";

		private const string InfoMsgFormat = "AWSSDK INFO {0} {1}";

		private static object _lock = new object();

		private static StringBuilder _logBuffer = new StringBuilder();

		private const long MAX_BUFFER_SIZE = 51200L;

		private const string LOG_FILE_FORMAT = "awssdk.{0}.log";

		private const string LOG_FILE_PATTERN = "awssdk\\.(?<counter>[0-9]+)\\.log";

		private const string LOGS_FOLDER_NAME = "aws-logs";

		private const string DATE_FORMAT = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'";

		private const int MAX_FILES_COUNT = 5;

		private const long MAX_SIZE = 1048576L;

		public override bool IsErrorEnabled => true;

		public override bool IsDebugEnabled => true;

		public override bool IsInfoEnabled => true;

		public InternalFileLogger(Type declaringType)
			: base(declaringType)
		{
		}

		public override void Flush()
		{
			lock (_lock)
			{
				LogAsync(_logBuffer);
				_logBuffer = new StringBuilder();
			}
		}

		public override void Error(Exception exception, string messageFormat, params object[] args)
		{
			string arg = string.Format(messageFormat, args);
			string message = string.Format("{0} {1}", arg, (exception != null) ? exception.ToString() : "");
			Log(LogLevel.Error, message);
		}

		public override void Debug(Exception exception, string messageFormat, params object[] args)
		{
			string arg = string.Format(messageFormat, args);
			string message = string.Format("{0} {1}", arg, (exception != null) ? exception.ToString() : "");
			Log(LogLevel.Debug, message);
		}

		public override void DebugFormat(string message, params object[] arguments)
		{
			Log(LogLevel.Debug, string.Format(message, arguments));
		}

		public override void InfoFormat(string message, params object[] arguments)
		{
			Log(LogLevel.Info, string.Format(message, arguments));
		}

		private void Log(LogLevel level, string message)
		{
			string text = "";
			text = level switch
			{
				LogLevel.Error => "AWSSDK ERROR {0} {1}", 
				LogLevel.Debug => "AWSSDK DEBUG {0} {1}", 
				_ => "AWSSDK INFO {0} {1}", 
			};
			string text2 = AWSSDKUtils.CorrectedUtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'");
			LogMessage message2 = new LogMessage(CultureInfo.InvariantCulture, text, text2, message);
			Queue(message2);
		}

		private void Queue(LogMessage message)
		{
			lock (_lock)
			{
				_logBuffer.AppendLine(message.ToString());
				if ((long)_logBuffer.Length >= 51200L)
				{
					LogAsync(_logBuffer);
					_logBuffer = new StringBuilder();
				}
			}
		}

		private void LogAsync(StringBuilder buffer)
		{
			Task.Run(async delegate
			{
				IFolder folder = await FileSystem.Current.LocalStorage.CreateFolderAsync("aws-logs", CreationCollisionOption.OpenIfExists).ConfigureAwait(continueOnCapturedContext: false);
				using StreamWriter streamWriter = new StreamWriter(await (await folder.CreateFileAsync(await RollingLogFileNameAsync(folder).ConfigureAwait(continueOnCapturedContext: false), CreationCollisionOption.OpenIfExists).ConfigureAwait(continueOnCapturedContext: false)).OpenAsync(PCLStorage.FileAccess.ReadAndWrite).ConfigureAwait(continueOnCapturedContext: false));
				streamWriter.BaseStream.Seek(0L, SeekOrigin.End);
				streamWriter.WriteLine(buffer.ToString());
			});
		}

		private async Task<string> RollingLogFileNameAsync(IFolder folder)
		{
			IList<IFile> list = await folder.GetFilesAsync().ConfigureAwait(continueOnCapturedContext: false);
			int counter = 0;
			checked
			{
				if (list.Count > 0)
				{
					List<IFile> logFiles = (from f in list
						where Regex.Match(f.Name, "awssdk\\.(?<counter>[0-9]+)\\.log").Success
						orderby f.Name
						select f).ToList();
					if (logFiles.Count > 0)
					{
						while (logFiles.Count > 5)
						{
							await logFiles[0].DeleteAsync().ConfigureAwait(continueOnCapturedContext: false);
							logFiles.RemoveAt(0);
						}
						IFile currentFile = logFiles[logFiles.Count - 1];
						long num = 0L;
						using (Stream stream = await currentFile.OpenAsync(PCLStorage.FileAccess.Read).ConfigureAwait(continueOnCapturedContext: false))
						{
							num = stream.Length;
						}
						if (num < 1048576)
						{
							return currentFile.Name;
						}
						string name = currentFile.Name;
						Match match = new Regex("awssdk\\.(?<counter>[0-9]+)\\.log").Match(name);
						if (match.Success && int.TryParse(match.Groups["counter"].Value, out counter))
						{
							counter++;
						}
					}
				}
				return $"awssdk.{counter}.log";
			}
		}
	}
	[Obsolete("Use InternalConsoleLogger instead")]
	internal class MobileLogger : InternalLogger
	{
		private const string InfoMsg = "[AWSSDK INFO] {0}";

		private const string DebugMsg = "[AWSSDK DEBUG] {0}";

		private const string ErrorMsg = "[AWSSDK ERROR] {0}";

		public override bool IsErrorEnabled => true;

		public override bool IsDebugEnabled => true;

		public override bool IsInfoEnabled => true;

		public MobileLogger(Type declaringType)
			: base(declaringType)
		{
		}

		public override void Flush()
		{
			Console.Out.Flush();
		}

		public override void Error(Exception exception, string messageFormat, params object[] args)
		{
			LogMessage logMessage = new LogMessage(CultureInfo.InvariantCulture, messageFormat, args);
			Log.Error(base.DeclaringType.Name, logMessage.ToString());
			if (exception != null)
			{
				Log.Error(base.DeclaringType.Name, exception.ToString());
			}
		}

		public override void Debug(Exception exception, string messageFormat, params object[] args)
		{
			LogMessage logMessage = new LogMessage(CultureInfo.InvariantCulture, messageFormat, args);
			Log.Debug(base.DeclaringType.Name, logMessage.ToString());
			if (exception != null)
			{
				Log.Debug(base.DeclaringType.Name, exception.ToString());
			}
		}

		public override void DebugFormat(string message, params object[] arguments)
		{
			LogMessage logMessage = new LogMessage(CultureInfo.InvariantCulture, message, arguments);
			Log.Error(base.DeclaringType.Name, logMessage.ToString());
		}

		public override void InfoFormat(string message, params object[] arguments)
		{
			LogMessage logMessage = new LogMessage(CultureInfo.InvariantCulture, message, arguments);
			Log.Info(base.DeclaringType.Name, logMessage.ToString());
		}
	}
	public class HashingWrapperMD5 : HashingWrapper
	{
		public HashingWrapperMD5()
			: base(HashAlgorithm.Md5.ToString())
		{
		}
	}
}
namespace Amazon.Runtime.Internal.Transform
{
	public static class CustomMarshallTransformations
	{
		public static long ConvertDateTimeToEpochMilliseconds(DateTime dateTime)
		{
			long ticks = dateTime.ToUniversalTime().Ticks;
			DateTime ePOCH_START = AWSSDKUtils.EPOCH_START;
			checked
			{
				TimeSpan timeSpan = new TimeSpan(ticks - ePOCH_START.Ticks);
				return (long)timeSpan.TotalMilliseconds;
			}
		}
	}
	public class ErrorResponseUnmarshaller : IUnmarshaller<ErrorResponse, XmlUnmarshallerContext>
	{
		private static ErrorResponseUnmarshaller instance;

		public ErrorResponse Unmarshall(XmlUnmarshallerContext context)
		{
			ErrorResponse errorResponse = new ErrorResponse
			{
				Type = ErrorType.Unknown
			};
			PopulateErrorResponseFromXmlIfPossible(context, errorResponse);
			if (string.IsNullOrEmpty(errorResponse.Message))
			{
				if (string.IsNullOrEmpty(errorResponse.Code))
				{
					if (string.IsNullOrEmpty(context.ResponseBody))
					{
						errorResponse.Message = "The service returned an error. See inner exception for details.";
					}
					else
					{
						errorResponse.Message = "The service returned an error with HTTP Body: " + context.ResponseBody;
					}
				}
				else
				{
					errorResponse.Message = "The service returned an error with Error Code " + errorResponse.Code + " and HTTP Body: " + context.ResponseBody;
				}
			}
			return errorResponse;
		}

		private static void PopulateErrorResponseFromXmlIfPossible(XmlUnmarshallerContext context, ErrorResponse response)
		{
			while (TryReadContext(context))
			{
				if (!context.IsStartElement)
				{
					continue;
				}
				if (context.TestExpression("Error/Type"))
				{
					try
					{
						response.Type = (ErrorType)Enum.Parse(typeof(ErrorType), StringUnmarshaller.GetInstance().Unmarshall(context), ignoreCase: true);
					}
					catch (ArgumentException)
					{
						response.Type = ErrorType.Unknown;
					}
				}
				else if (context.TestExpression("Error/Code"))
				{
					response.Code = StringUnmarshaller.GetInstance().Unmarshall(context);
				}
				else if (context.TestExpression("Error/Message"))
				{
					response.Message = StringUnmarshaller.GetInstance().Unmarshall(context);
				}
				else if (context.TestExpression("RequestId"))
				{
					response.RequestId = StringUnmarshaller.GetInstance().Unmarshall(context);
				}
			}
		}

		private static bool TryReadContext(XmlUnmarshallerContext context)
		{
			try
			{
				return context.Read();
			}
			catch (XmlException)
			{
				return false;
			}
		}

		public static ErrorResponseUnmarshaller GetInstance()
		{
			if (instance == null)
			{
				instance = new ErrorResponseUnmarshaller();
			}
			return instance;
		}
	}
	public interface IErrorResponseUnmarshaller<TUnmarshaller, TUnmarshalleContext> : IUnmarshaller<TUnmarshaller, TUnmarshalleContext>
	{
		TUnmarshaller Unmarshall(TUnmarshalleContext input, ErrorResponse errorResponse);
	}
	public interface IMarshaller<T, R>
	{
		T Marshall(R input);
	}
	public interface IRequestMarshaller<R, T> where T : MarshallerContext
	{
		void Marshall(R requestObject, T context);
	}
	public abstract class MarshallerContext
	{
		public IRequest Request { get; private set; }

		protected MarshallerContext(IRequest request)
		{
			Request = request;
		}
	}
	public class XmlMarshallerContext : MarshallerContext
	{
		public XmlWriter Writer { get; private set; }

		public XmlMarshallerContext(IRequest request, XmlWriter writer)
			: base(request)
		{
			Writer = writer;
		}
	}
	public class JsonMarshallerContext : MarshallerContext
	{
		public JsonWriter Writer { get; private set; }

		public JsonMarshallerContext(IRequest request, JsonWriter writer)
			: base(request)
		{
			Writer = writer;
		}
	}
	public interface IResponseUnmarshaller<T, R> : IUnmarshaller<T, R>
	{
		AmazonServiceException UnmarshallException(R input, Exception innerException, HttpStatusCode statusCode);
	}
	public interface IUnmarshaller<T, R>
	{
		T Unmarshall(R input);
	}
	public interface IWebResponseData
	{
		long ContentLength { get; }

		string ContentType { get; }

		HttpStatusCode StatusCode { get; }

		bool IsSuccessStatusCode { get; }

		IHttpResponseBody ResponseBody { get; }

		string[] GetHeaderNames();

		bool IsHeaderPresent(string headerName);

		string GetHeaderValue(string headerName);
	}
	public interface IHttpResponseBody : IDisposable
	{
		Stream OpenResponse();

		Task<Stream> OpenResponseAsync();
	}
	public class JsonErrorResponseUnmarshaller : IUnmarshaller<ErrorResponse, JsonUnmarshallerContext>
	{
		private static JsonErrorResponseUnmarshaller instance;

		public ErrorResponse Unmarshall(JsonUnmarshallerContext context)
		{
			if (context.Peek() == 60)
			{
				ErrorResponseUnmarshaller errorResponseUnmarshaller = new ErrorResponseUnmarshaller();
				using MemoryStream responseStream = new MemoryStream(context.GetResponseBodyBytes());
				XmlUnmarshallerContext context2 = new XmlUnmarshallerContext(responseStream, maintainResponseBody: false, null);
				return errorResponseUnmarshaller.Unmarshall(context2);
			}
			string requestId = null;
			GetValuesFromJsonIfPossible(context, out var type, out var message, out var code);
			if (string.IsNullOrEmpty(type) && context.ResponseData.IsHeaderPresent("x-amzn-ErrorType"))
			{
				string text = context.ResponseData.GetHeaderValue("x-amzn-ErrorType");
				if (!string.IsNullOrEmpty(text))
				{
					int num = text.IndexOf(":", StringComparison.Ordinal);
					if (num != -1)
					{
						text = text.Substring(0, num);
					}
					type = text;
				}
			}
			if (context.ResponseData.IsHeaderPresent("x-amzn-error-message"))
			{
				string headerValue = context.ResponseData.GetHeaderValue("x-amzn-error-message");
				if (!string.IsNullOrEmpty(headerValue))
				{
					message = headerValue;
				}
			}
			if (string.IsNullOrEmpty(type) && !string.IsNullOrEmpty(code))
			{
				type = code;
			}
			type = type?.Substring(checked(type.LastIndexOf("#", StringComparison.Ordinal) + 1));
			if (string.IsNullOrEmpty(message))
			{
				message = (string.IsNullOrEmpty(type) ? ((!string.IsNullOrEmpty(context.ResponseBody)) ? ("The service returned an error with HTTP Body: " + context.ResponseBody) : "The service returned an error. See inner exception for details.") : ((!string.IsNullOrEmpty(context.ResponseBody)) ? ("The service returned an error with Error Code " + type + " and HTTP Body: " + context.ResponseBody) : ("The service returned an error with Error Code " + type + ".")));
			}
			if (context.ResponseData.IsHeaderPresent("x-amzn-RequestId"))
			{
				requestId = context.ResponseData.GetHeaderValue("x-amzn-RequestId");
			}
			return new ErrorResponse
			{
				Code = type,
				Message = message,
				Type = ErrorType.Unknown,
				RequestId = requestId
			};
		}

		private static void GetValuesFromJsonIfPossible(JsonUnmarshallerContext context, out string type, out string message, out string code)
		{
			code = null;
			type = null;
			message = null;
			while (TryReadContext(context))
			{
				if (context.TestExpression("__type"))
				{
					type = StringUnmarshaller.GetInstance().Unmarshall(context);
				}
				else if (context.TestExpression("message"))
				{
					message = StringUnmarshaller.GetInstance().Unmarshall(context);
				}
				else if (context.TestExpression("code"))
				{
					code = StringUnmarshaller.GetInstance().Unmarshall(context);
				}
			}
		}

		private static bool TryReadContext(JsonUnmarshallerContext context)
		{
			try
			{
				return context.Read();
			}
			catch (JsonException)
			{
				return false;
			}
		}

		public static JsonErrorResponseUnmarshaller GetInstance()
		{
			if (instance == null)
			{
				instance = new JsonErrorResponseUnmarshaller();
			}
			return instance;
		}
	}
	public class JsonUnmarshallerContext : UnmarshallerContext
	{
		private enum PathSegmentType
		{
			Value,
			Delimiter
		}

		private struct PathSegment
		{
			internal PathSegmentType SegmentType { get; set; }

			internal string Value { get; set; }
		}

		private class JsonPathStack
		{
			private Stack<PathSegment> stack = new Stack<PathSegment>();

			private int currentDepth;

			private StringBuilder stackStringBuilder = new StringBuilder(128);

			private string stackString;

			public int CurrentDepth => currentDepth;

			public string CurrentPath
			{
				get
				{
					if (stackString == null)
					{
						stackString = stackStringBuilder.ToString();
					}
					return stackString;
				}
			}

			public int Count => stack.Count;

			internal void Push(PathSegment segment)
			{
				checked
				{
					if (segment.SegmentType == PathSegmentType.Delimiter)
					{
						currentDepth++;
					}
					stackStringBuilder.Append(segment.Value);
					stackString = null;
					stack.Push(segment);
				}
			}

			internal PathSegment Pop()
			{
				PathSegment result = stack.Pop();
				checked
				{
					if (result.SegmentType == PathSegmentType.Delimiter)
					{
						currentDepth--;
					}
					stackStringBuilder.Remove(stackStringBuilder.Length - result.Value.Length, result.Value.Length);
					stackString = null;
					return result;
				}
			}

			internal PathSegment Peek()
			{
				return stack.Peek();
			}
		}

		private const string DELIMITER = "/";

		private StreamReader streamReader;

		private JsonReader jsonReader;

		private JsonPathStack stack = new JsonPathStack();

		private string currentField;

		private JsonToken? currentToken;

		private bool disposed;

		private bool wasPeeked;

		public override bool IsStartOfDocument
		{
			get
			{
				if (CurrentTokenType == JsonToken.None)
				{
					return !streamReader.EndOfStream;
				}
				return false;
			}
		}

		public override bool IsEndElement => CurrentTokenType == JsonToken.ObjectEnd;

		public override bool IsStartElement => CurrentTokenType == JsonToken.ObjectStart;

		public override int CurrentDepth => stack.CurrentDepth;

		public override string CurrentPath => stack.CurrentPath;

		public JsonToken CurrentTokenType => currentToken.Value;

		public Stream Stream => streamReader.BaseStream;

		public JsonUnmarshallerContext(Stream responseStream, bool maintainResponseBody, IWebResponseData responseData, bool isException = false)
		{
			if (isException)
			{
				base.WrappingStream = new CachingWrapperStream(responseStream);
			}
			else if (maintainResponseBody)
			{
				base.WrappingStream = new CachingWrapperStream(responseStream, AWSConfigs.LoggingConfig.LogResponsesSizeLimit);
			}
			if (isException || maintainResponseBody)
			{
				responseStream = base.WrappingStream;
			}
			base.WebResponseData = responseData;
			base.MaintainResponseBody = maintainResponseBody;
			base.IsException = isException;
			if (responseData != null && long.TryParse(responseData.GetHeaderValue("Content-Length"), out var result) && responseData.ContentLength.Equals(result) && string.IsNullOrEmpty(responseData.GetHeaderValue("Content-Encoding")))
			{
				SetupCRCStream(responseData, responseStream, result);
			}
			if (base.CrcStream != null)
			{
				streamReader = new StreamReader(base.CrcStream);
			}
			else
			{
				streamReader = new StreamReader(responseStream);
			}
			jsonReader = new JsonReader(streamReader);
		}

		public override bool Read()
		{
			if (wasPeeked)
			{
				wasPeeked = false;
				return !currentToken.HasValue;
			}
			bool num = jsonReader.Read();
			if (num)
			{
				currentToken = jsonReader.Token;
				UpdateContext();
			}
			else
			{
				currentToken = null;
			}
			wasPeeked = false;
			return num;
		}

		public bool Peek(JsonToken token)
		{
			if (wasPeeked)
			{
				if (currentToken.HasValue)
				{
					return currentToken == token;
				}
				return false;
			}
			if (Read())
			{
				wasPeeked = true;
				return currentToken == token;
			}
			return false;
		}

		public override string ReadText()
		{
			object value = jsonReader.Value;
			switch (currentToken)
			{
			case JsonToken.Null:
				return null;
			case JsonToken.PropertyName:
			case JsonToken.String:
				return value as string;
			case JsonToken.Int:
			case JsonToken.UInt:
			case JsonToken.Long:
			case JsonToken.ULong:
			case JsonToken.Boolean:
				if (value is IFormattable formattable2)
				{
					return formattable2.ToString(null, CultureInfo.InvariantCulture);
				}
				return value.ToString();
			case JsonToken.Double:
				if (value is IFormattable formattable)
				{
					return formattable.ToString("R", CultureInfo.InvariantCulture);
				}
				return value.ToString();
			default:
				throw new AmazonClientException("We expected a VALUE token but got: " + currentToken);
			}
		}

		public int Peek()
		{
			while (char.IsWhiteSpace((char)StreamPeek()))
			{
				streamReader.Read();
			}
			return StreamPeek();
		}

		private int StreamPeek()
		{
			int num = streamReader.Peek();
			if (num == -1)
			{
				streamReader.DiscardBufferedData();
				num = streamReader.Peek();
			}
			return num;
		}

		private void UpdateContext()
		{
			if (!currentToken.HasValue)
			{
				return;
			}
			if (currentToken.Value == JsonToken.ObjectStart || currentToken.Value == JsonToken.ArrayStart)
			{
				stack.Push(new PathSegment
				{
					SegmentType = PathSegmentType.Delimiter,
					Value = "/"
				});
			}
			else if (currentToken.Value == JsonToken.ObjectEnd || currentToken.Value == JsonToken.ArrayEnd)
			{
				if (stack.Peek().SegmentType == PathSegmentType.Delimiter)
				{
					stack.Pop();
					if (stack.Count > 0 && stack.Peek().SegmentType != PathSegmentType.Delimiter)
					{
						stack.Pop();
					}
				}
				currentField = null;
			}
			else if (currentToken.Value == JsonToken.PropertyName)
			{
				string value = ReadText();
				stack.Push(new PathSegment
				{
					SegmentType = PathSegmentType.Value,
					Value = value
				});
			}
			else if (currentToken.Value != JsonToken.None && stack.Peek().SegmentType != PathSegmentType.Delimiter)
			{
				stack.Pop();
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing && streamReader != null)
				{
					streamReader.Dispose();
					streamReader = null;
				}
				disposed = true;
			}
			base.Dispose(disposing);
		}
	}
	public abstract class ResponseUnmarshaller : IResponseUnmarshaller<AmazonWebServiceResponse, UnmarshallerContext>, IUnmarshaller<AmazonWebServiceResponse, UnmarshallerContext>
	{
		public virtual bool HasStreamingProperty => false;

		public virtual UnmarshallerContext CreateContext(IWebResponseData response, bool readEntireResponse, Stream stream, RequestMetrics metrics, bool isException)
		{
			if (response == null)
			{
				throw new AmazonServiceException("The Web Response for a successful request is null!");
			}
			return ConstructUnmarshallerContext(stream, ShouldReadEntireResponse(response, readEntireResponse), response, isException);
		}

		public virtual AmazonServiceException UnmarshallException(UnmarshallerContext input, Exception innerException, HttpStatusCode statusCode)
		{
			throw new NotImplementedException();
		}

		public AmazonWebServiceResponse UnmarshallResponse(UnmarshallerContext context)
		{
			AmazonWebServiceResponse amazonWebServiceResponse = Unmarshall(context);
			amazonWebServiceResponse.ContentLength = context.ResponseData.ContentLength;
			amazonWebServiceResponse.HttpStatusCode = context.ResponseData.StatusCode;
			return amazonWebServiceResponse;
		}

		public abstract AmazonWebServiceResponse Unmarshall(UnmarshallerContext input);

		public static string GetDefaultErrorMessage<T>() where T : Exception
		{
			return string.Format(CultureInfo.InvariantCulture, "An exception of type {0}, please check the error log for mode details.", typeof(T).Name);
		}

		protected abstract UnmarshallerContext ConstructUnmarshallerContext(Stream responseStream, bool maintainResponseBody, IWebResponseData response, bool isException);

		protected virtual bool ShouldReadEntireResponse(IWebResponseData response, bool readEntireResponse)
		{
			return readEntireResponse;
		}
	}
	public abstract class XmlResponseUnmarshaller : ResponseUnmarshaller
	{
		public override AmazonWebServiceResponse Unmarshall(UnmarshallerContext input)
		{
			if (!(input is XmlUnmarshallerContext xmlUnmarshallerContext))
			{
				throw new InvalidOperationException("Unsupported UnmarshallerContext");
			}
			AmazonWebServiceResponse amazonWebServiceResponse = Unmarshall(xmlUnmarshallerContext);
			if (xmlUnmarshallerContext.ResponseData.IsHeaderPresent("x-amzn-RequestId") && !string.IsNullOrEmpty(xmlUnmarshallerContext.ResponseData.GetHeaderValue("x-amzn-RequestId")))
			{
				if (amazonWebServiceResponse.ResponseMetadata == null)
				{
					amazonWebServiceResponse.ResponseMetadata = new ResponseMetadata();
				}
				amazonWebServiceResponse.ResponseMetadata.RequestId = xmlUnmarshallerContext.ResponseData.GetHeaderValue("x-amzn-RequestId");
			}
			else if (xmlUnmarshallerContext.ResponseData.IsHeaderPresent("x-amz-request-id") && !string.IsNullOrEmpty(xmlUnmarshallerContext.ResponseData.GetHeaderValue("x-amz-request-id")))
			{
				if (amazonWebServiceResponse.ResponseMetadata == null)
				{
					amazonWebServiceResponse.ResponseMetadata = new ResponseMetadata();
				}
				amazonWebServiceResponse.ResponseMetadata.RequestId = xmlUnmarshallerContext.ResponseData.GetHeaderValue("x-amz-request-id");
			}
			return amazonWebServiceResponse;
		}

		public override AmazonServiceException UnmarshallException(UnmarshallerContext input, Exception innerException, HttpStatusCode statusCode)
		{
			if (!(input is XmlUnmarshallerContext input2))
			{
				throw new InvalidOperationException("Unsupported UnmarshallerContext");
			}
			return UnmarshallException(input2, innerException, statusCode);
		}

		public abstract AmazonWebServiceResponse Unmarshall(XmlUnmarshallerContext input);

		public abstract AmazonServiceException UnmarshallException(XmlUnmarshallerContext input, Exception innerException, HttpStatusCode statusCode);

		protected override UnmarshallerContext ConstructUnmarshallerContext(Stream responseStream, bool maintainResponseBody, IWebResponseData response, bool isException)
		{
			return new XmlUnmarshallerContext(responseStream, maintainResponseBody, response, isException);
		}
	}
	public abstract class EC2ResponseUnmarshaller : XmlResponseUnmarshaller
	{
		public override AmazonWebServiceResponse Unmarshall(UnmarshallerContext input)
		{
			AmazonWebServiceResponse amazonWebServiceResponse = base.Unmarshall(input);
			if (amazonWebServiceResponse.ResponseMetadata == null)
			{
				amazonWebServiceResponse.ResponseMetadata = new ResponseMetadata();
			}
			if (input is EC2UnmarshallerContext eC2UnmarshallerContext && !string.IsNullOrEmpty(eC2UnmarshallerContext.RequestId))
			{
				amazonWebServiceResponse.ResponseMetadata.RequestId = eC2UnmarshallerContext.RequestId;
			}
			return amazonWebServiceResponse;
		}

		protected override UnmarshallerContext ConstructUnmarshallerContext(Stream responseStream, bool maintainResponseBody, IWebResponseData response, bool isException)
		{
			return new EC2UnmarshallerContext(responseStream, maintainResponseBody, response, isException);
		}
	}
	public abstract class JsonResponseUnmarshaller : ResponseUnmarshaller
	{
		public override AmazonWebServiceResponse Unmarshall(UnmarshallerContext input)
		{
			if (!(input is JsonUnmarshallerContext jsonUnmarshallerContext))
			{
				throw new InvalidOperationException("Unsupported UnmarshallerContext");
			}
			string headerValue = jsonUnmarshallerContext.ResponseData.GetHeaderValue("x-amzn-RequestId");
			try
			{
				AmazonWebServiceResponse amazonWebServiceResponse = Unmarshall(jsonUnmarshallerContext);
				amazonWebServiceResponse.ResponseMetadata = new ResponseMetadata();
				amazonWebServiceResponse.ResponseMetadata.RequestId = headerValue;
				return amazonWebServiceResponse;
			}
			catch (Exception innerException)
			{
				throw new AmazonUnmarshallingException(headerValue, jsonUnmarshallerContext.CurrentPath, innerException, jsonUnmarshallerContext.ResponseData.StatusCode);
			}
		}

		public override AmazonServiceException UnmarshallException(UnmarshallerContext input, Exception innerException, HttpStatusCode statusCode)
		{
			if (!(input is JsonUnmarshallerContext jsonUnmarshallerContext))
			{
				throw new InvalidOperationException("Unsupported UnmarshallerContext");
			}
			AmazonServiceException ex = UnmarshallException(jsonUnmarshallerContext, innerException, statusCode);
			ex.RequestId = jsonUnmarshallerContext.ResponseData.GetHeaderValue("x-amzn-RequestId");
			return ex;
		}

		public abstract AmazonWebServiceResponse Unmarshall(JsonUnmarshallerContext input);

		public abstract AmazonServiceException UnmarshallException(JsonUnmarshallerContext input, Exception innerException, HttpStatusCode statusCode);

		protected override UnmarshallerContext ConstructUnmarshallerContext(Stream responseStream, bool maintainResponseBody, IWebResponseData response, bool isException)
		{
			return new JsonUnmarshallerContext(responseStream, maintainResponseBody, response, isException);
		}

		protected override bool ShouldReadEntireResponse(IWebResponseData response, bool readEntireResponse)
		{
			if (readEntireResponse)
			{
				return response.ContentType != "application/octet-stream";
			}
			return false;
		}
	}
	internal static class SimpleTypeUnmarshaller<T>
	{
		public static T Unmarshall(XmlUnmarshallerContext context)
		{
			return (T)Convert.ChangeType(context.ReadText(), typeof(T), CultureInfo.InvariantCulture);
		}

		public static T Unmarshall(JsonUnmarshallerContext context)
		{
			context.Read();
			string text = context.ReadText();
			if (text == null)
			{
				return default(T);
			}
			return (T)Convert.ChangeType(text, typeof(T), CultureInfo.InvariantCulture);
		}
	}
	public class IntUnmarshaller : IUnmarshaller<int, XmlUnmarshallerContext>, IUnmarshaller<int, JsonUnmarshallerContext>
	{
		private static IntUnmarshaller _instance = new IntUnmarshaller();

		public static IntUnmarshaller Instance => _instance;

		private IntUnmarshaller()
		{
		}

		public static IntUnmarshaller GetInstance()
		{
			return Instance;
		}

		public int Unmarshall(XmlUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<int>.Unmarshall(context);
		}

		public int Unmarshall(JsonUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<int>.Unmarshall(context);
		}
	}
	public class NullableIntUnmarshaller : IUnmarshaller<int?, JsonUnmarshallerContext>
	{
		private static NullableIntUnmarshaller _instance = new NullableIntUnmarshaller();

		public static NullableIntUnmarshaller Instance => _instance;

		private NullableIntUnmarshaller()
		{
		}

		public static NullableIntUnmarshaller GetInstance()
		{
			return Instance;
		}

		public int? Unmarshall(JsonUnmarshallerContext context)
		{
			context.Read();
			string text = context.ReadText();
			if (text == null)
			{
				return null;
			}
			return int.Parse(text, CultureInfo.InvariantCulture);
		}
	}
	public class LongUnmarshaller : IUnmarshaller<long, XmlUnmarshallerContext>, IUnmarshaller<long, JsonUnmarshallerContext>
	{
		private static LongUnmarshaller _instance = new LongUnmarshaller();

		public static LongUnmarshaller Instance => _instance;

		private LongUnmarshaller()
		{
		}

		public static LongUnmarshaller GetInstance()
		{
			return Instance;
		}

		public long Unmarshall(XmlUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<long>.Unmarshall(context);
		}

		public long Unmarshall(JsonUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<long>.Unmarshall(context);
		}
	}
	public class FloatUnmarshaller : IUnmarshaller<float, XmlUnmarshallerContext>, IUnmarshaller<float, JsonUnmarshallerContext>
	{
		private static FloatUnmarshaller _instance = new FloatUnmarshaller();

		public static FloatUnmarshaller Instance => _instance;

		private FloatUnmarshaller()
		{
		}

		public static FloatUnmarshaller GetInstance()
		{
			return Instance;
		}

		public float Unmarshall(XmlUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<float>.Unmarshall(context);
		}

		public float Unmarshall(JsonUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<float>.Unmarshall(context);
		}
	}
	public class DoubleUnmarshaller : IUnmarshaller<double, XmlUnmarshallerContext>, IUnmarshaller<double, JsonUnmarshallerContext>
	{
		private static DoubleUnmarshaller _instance = new DoubleUnmarshaller();

		public static DoubleUnmarshaller Instance => _instance;

		private DoubleUnmarshaller()
		{
		}

		public static DoubleUnmarshaller GetInstance()
		{
			return Instance;
		}

		public double Unmarshall(XmlUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<double>.Unmarshall(context);
		}

		public double Unmarshall(JsonUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<double>.Unmarshall(context);
		}
	}
	public class DecimalUnmarshaller : IUnmarshaller<decimal, XmlUnmarshallerContext>, IUnmarshaller<decimal, JsonUnmarshallerContext>
	{
		private static DecimalUnmarshaller _instance = new DecimalUnmarshaller();

		public static DecimalUnmarshaller Instance => _instance;

		private DecimalUnmarshaller()
		{
		}

		public static DecimalUnmarshaller GetInstance()
		{
			return Instance;
		}

		public decimal Unmarshall(XmlUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<decimal>.Unmarshall(context);
		}

		public decimal Unmarshall(JsonUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<decimal>.Unmarshall(context);
		}
	}
	public class BoolUnmarshaller : IUnmarshaller<bool, XmlUnmarshallerContext>, IUnmarshaller<bool, JsonUnmarshallerContext>
	{
		private static BoolUnmarshaller _instance = new BoolUnmarshaller();

		public static BoolUnmarshaller Instance => _instance;

		private BoolUnmarshaller()
		{
		}

		public static BoolUnmarshaller GetInstance()
		{
			return Instance;
		}

		public bool Unmarshall(XmlUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<bool>.Unmarshall(context);
		}

		public bool Unmarshall(JsonUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<bool>.Unmarshall(context);
		}
	}
	public class StringUnmarshaller : IUnmarshaller<string, XmlUnmarshallerContext>, IUnmarshaller<string, JsonUnmarshallerContext>
	{
		private static StringUnmarshaller _instance = new StringUnmarshaller();

		public static StringUnmarshaller Instance => _instance;

		private StringUnmarshaller()
		{
		}

		public static StringUnmarshaller GetInstance()
		{
			return Instance;
		}

		public string Unmarshall(XmlUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<string>.Unmarshall(context);
		}

		public string Unmarshall(JsonUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<string>.Unmarshall(context);
		}
	}
	public class ByteUnmarshaller : IUnmarshaller<byte, XmlUnmarshallerContext>, IUnmarshaller<byte, JsonUnmarshallerContext>
	{
		private static ByteUnmarshaller _instance = new ByteUnmarshaller();

		public static ByteUnmarshaller Instance => _instance;

		private ByteUnmarshaller()
		{
		}

		public static ByteUnmarshaller GetInstance()
		{
			return Instance;
		}

		public byte Unmarshall(XmlUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<byte>.Unmarshall(context);
		}

		public byte Unmarshall(JsonUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<byte>.Unmarshall(context);
		}
	}
	public class DateTimeUnmarshaller : IUnmarshaller<DateTime, XmlUnmarshallerContext>, IUnmarshaller<DateTime, JsonUnmarshallerContext>
	{
		private static DateTimeUnmarshaller _instance = new DateTimeUnmarshaller();

		public static DateTimeUnmarshaller Instance => _instance;

		private DateTimeUnmarshaller()
		{
		}

		public static DateTimeUnmarshaller GetInstance()
		{
			return Instance;
		}

		public DateTime Unmarshall(XmlUnmarshallerContext context)
		{
			return UnmarshallInternal(context.ReadText(), treatAsNullable: false).Value;
		}

		public DateTime Unmarshall(JsonUnmarshallerContext context)
		{
			context.Read();
			return UnmarshallInternal(context.ReadText(), treatAsNullable: false).Value;
		}

		internal static DateTime? UnmarshallInternal(string text, bool treatAsNullable)
		{
			if (double.TryParse(text, NumberStyles.Any, CultureInfo.InvariantCulture, out var result))
			{
				DateTime ePOCH_START = AWSSDKUtils.EPOCH_START;
				return ePOCH_START.AddSeconds(result);
			}
			if (text == null)
			{
				if (treatAsNullable)
				{
					return null;
				}
				return default(DateTime);
			}
			return DateTime.Parse(text, CultureInfo.InvariantCulture);
		}
	}
	public class NullableDateTimeUnmarshaller : IUnmarshaller<DateTime?, JsonUnmarshallerContext>
	{
		private static NullableDateTimeUnmarshaller _instance = new NullableDateTimeUnmarshaller();

		public static NullableDateTimeUnmarshaller Instance => _instance;

		private NullableDateTimeUnmarshaller()
		{
		}

		public static NullableDateTimeUnmarshaller GetInstance()
		{
			return Instance;
		}

		public DateTime? Unmarshall(JsonUnmarshallerContext context)
		{
			context.Read();
			return DateTimeUnmarshaller.UnmarshallInternal(context.ReadText(), treatAsNullable: true);
		}
	}
	public class DateTimeEpochLongMillisecondsUnmarshaller : IUnmarshaller<DateTime, XmlUnmarshallerContext>, IUnmarshaller<DateTime, JsonUnmarshallerContext>
	{
		private static DateTimeEpochLongMillisecondsUnmarshaller _instance = new DateTimeEpochLongMillisecondsUnmarshaller();

		public static DateTimeEpochLongMillisecondsUnmarshaller Instance => _instance;

		private DateTimeEpochLongMillisecondsUnmarshaller()
		{
		}

		public static DateTimeEpochLongMillisecondsUnmarshaller GetInstance()
		{
			return Instance;
		}

		public DateTime Unmarshall(XmlUnmarshallerContext context)
		{
			return SimpleTypeUnmarshaller<DateTime>.Unmarshall(context);
		}

		public DateTime Unmarshall(JsonUnmarshallerContext context)
		{
			long num = LongUnmarshaller.Instance.Unmarshall(context);
			DateTime ePOCH_START = AWSSDKUtils.EPOCH_START;
			return ePOCH_START.AddMilliseconds(num);
		}
	}
	public class MemoryStreamUnmarshaller : IUnmarshaller<MemoryStream, XmlUnmarshallerContext>, IUnmarshaller<MemoryStream, JsonUnmarshallerContext>
	{
		private static MemoryStreamUnmarshaller _instance = new MemoryStreamUnmarshaller();

		public static MemoryStreamUnmarshaller Instance => _instance;

		private MemoryStreamUnmarshaller()
		{
		}

		public static MemoryStreamUnmarshaller GetInstance()
		{
			return Instance;
		}

		public MemoryStream Unmarshall(XmlUnmarshallerContext context)
		{
			return new MemoryStream(Convert.FromBase64String(context.ReadText()));
		}

		public MemoryStream Unmarshall(JsonUnmarshallerContext context)
		{
			context.Read();
			if (context.CurrentTokenType == JsonToken.Null)
			{
				return null;
			}
			return new MemoryStream(Convert.FromBase64String(context.ReadText()));
		}
	}
	public class ResponseMetadataUnmarshaller : IUnmarshaller<ResponseMetadata, XmlUnmarshallerContext>, IUnmarshaller<ResponseMetadata, JsonUnmarshallerContext>
	{
		private static ResponseMetadataUnmarshaller _instance = new ResponseMetadataUnmarshaller();

		public static ResponseMetadataUnmarshaller Instance => _instance;

		private ResponseMetadataUnmarshaller()
		{
		}

		public static ResponseMetadataUnmarshaller GetInstance()
		{
			return Instance;
		}

		public ResponseMetadata Unmarshall(XmlUnmarshallerContext context)
		{
			ResponseMetadata responseMetadata = new ResponseMetadata();
			int currentDepth = context.CurrentDepth;
			while (currentDepth <= context.CurrentDepth)
			{
				context.Read();
				if (context.IsStartElement)
				{
					if (context.TestExpression("ResponseMetadata/RequestId"))
					{
						responseMetadata.RequestId = StringUnmarshaller.GetInstance().Unmarshall(context);
					}
					else
					{
						responseMetadata.Metadata.Add(context.CurrentPath.Substring(checked(context.CurrentPath.LastIndexOf('/') + 1)), StringUnmarshaller.GetInstance().Unmarshall(context));
					}
				}
			}
			return responseMetadata;
		}

		public ResponseMetadata Unmarshall(JsonUnmarshallerContext context)
		{
			ResponseMetadata responseMetadata = new ResponseMetadata();
			int currentDepth = context.CurrentDepth;
			while (context.CurrentDepth >= currentDepth)
			{
				context.Read();
				if (context.TestExpression("ResponseMetadata/RequestId"))
				{
					responseMetadata.RequestId = StringUnmarshaller.GetInstance().Unmarshall(context);
				}
			}
			return responseMetadata;
		}
	}
	public class KeyValueUnmarshaller<K, V, KUnmarshaller, VUnmarshaller> : IUnmarshaller<KeyValuePair<K, V>, XmlUnmarshallerContext>, IUnmarshaller<KeyValuePair<K, V>, JsonUnmarshallerContext> where KUnmarshaller : IUnmarshaller<K, XmlUnmarshallerContext>, IUnmarshaller<K, JsonUnmarshallerContext> where VUnmarshaller : IUnmarshaller<V, XmlUnmarshallerContext>, IUnmarshaller<V, JsonUnmarshallerContext>
	{
		private KUnmarshaller keyUnmarshaller;

		private VUnmarshaller valueUnmarshaller;

		public KeyValueUnmarshaller(KUnmarshaller keyUnmarshaller, VUnmarshaller valueUnmarshaller)
		{
			this.keyUnmarshaller = keyUnmarshaller;
			this.valueUnmarshaller = valueUnmarshaller;
		}

		public KeyValuePair<K, V> Unmarshall(XmlUnmarshallerContext context)
		{
			K key = default(K);
			V value = default(V);
			int currentDepth = context.CurrentDepth;
			int startingStackDepth = checked(currentDepth + 1);
			while (context.Read())
			{
				if (context.TestExpression("key", startingStackDepth))
				{
					key = keyUnmarshaller.Unmarshall(context);
				}
				else if (context.TestExpression("name", startingStackDepth))
				{
					key = keyUnmarshaller.Unmarshall(context);
				}
				else if (context.TestExpression("value", startingStackDepth))
				{
					value = valueUnmarshaller.Unmarshall(context);
				}
				else if (context.IsEndElement && context.CurrentDepth < currentDepth)
				{
					break;
				}
			}
			return new KeyValuePair<K, V>(key, value);
		}

		public KeyValuePair<K, V> Unmarshall(JsonUnmarshallerContext context)
		{
			K key = keyUnmarshaller.Unmarshall(context);
			V value = valueUnmarshaller.Unmarshall(context);
			return new KeyValuePair<K, V>(key, value);
		}
	}
	public class ListUnmarshaller<I, IUnmarshaller> : IUnmarshaller<List<I>, XmlUnmarshallerContext>, IUnmarshaller<List<I>, JsonUnmarshallerContext> where IUnmarshaller : IUnmarshaller<I, XmlUnmarshallerContext>, IUnmarshaller<I, JsonUnmarshallerContext>
	{
		private IUnmarshaller iUnmarshaller;

		public ListUnmarshaller(IUnmarshaller iUnmarshaller)
		{
			this.iUnmarshaller = iUnmarshaller;
		}

		public List<I> Unmarshall(XmlUnmarshallerContext context)
		{
			int startingStackDepth = checked(context.CurrentDepth + 1);
			List<I> list = new List<I>();
			while (context.Read())
			{
				if (context.IsStartElement && context.TestExpression("member", startingStackDepth))
				{
					I item = iUnmarshaller.Unmarshall(context);
					list.Add(item);
				}
			}
			return list;
		}

		public List<I> Unmarshall(JsonUnmarshallerContext context)
		{
			context.Read();
			if (context.CurrentTokenType == JsonToken.Null)
			{
				return new List<I>();
			}
			List<I> list = new AlwaysSendList<I>();
			while (!context.Peek(JsonToken.ArrayEnd))
			{
				list.Add(iUnmarshaller.Unmarshall(context));
			}
			context.Read();
			return list;
		}
	}
	public class DictionaryUnmarshaller<TKey, TValue, TKeyUnmarshaller, TValueUnmarshaller> : IUnmarshaller<Dictionary<TKey, TValue>, XmlUnmarshallerContext>, IUnmarshaller<Dictionary<TKey, TValue>, JsonUnmarshallerContext> where TKeyUnmarshaller : IUnmarshaller<TKey, XmlUnmarshallerContext>, IUnmarshaller<TKey, JsonUnmarshallerContext> where TValueUnmarshaller : IUnmarshaller<TValue, XmlUnmarshallerContext>, IUnmarshaller<TValue, JsonUnmarshallerContext>
	{
		private KeyValueUnmarshaller<TKey, TValue, TKeyUnmarshaller, TValueUnmarshaller> KVUnmarshaller;

		public DictionaryUnmarshaller(TKeyUnmarshaller kUnmarshaller, TValueUnmarshaller vUnmarshaller)
		{
			KVUnmarshaller = new KeyValueUnmarshaller<TKey, TValue, TKeyUnmarshaller, TValueUnmarshaller>(kUnmarshaller, vUnmarshaller);
		}

		public Dictionary<TKey, TValue> Unmarshall(XmlUnmarshallerContext context)
		{
			int currentDepth = context.CurrentDepth;
			checked
			{
				_ = currentDepth + 1;
				AlwaysSendDictionary<TKey, TValue> alwaysSendDictionary = new AlwaysSendDictionary<TKey, TValue>();
				while (context.Read() && (!context.IsEndElement || context.CurrentDepth >= currentDepth))
				{
					KeyValuePair<TKey, TValue> keyValuePair = KVUnmarshaller.Unmarshall(context);
					alwaysSendDictionary.Add(keyValuePair.Key, keyValuePair.Value);
				}
				return alwaysSendDictionary;
			}
		}

		public Dictionary<TKey, TValue> Unmarshall(JsonUnmarshallerContext context)
		{
			context.Read();
			if (context.CurrentTokenType == JsonToken.Null)
			{
				return new Dictionary<TKey, TValue>();
			}
			Dictionary<TKey, TValue> dictionary = new AlwaysSendDictionary<TKey, TValue>();
			while (!context.Peek(JsonToken.ObjectEnd))
			{
				KeyValuePair<TKey, TValue> keyValuePair = KVUnmarshaller.Unmarshall(context);
				dictionary.Add(keyValuePair.Key, keyValuePair.Value);
			}
			context.Read();
			return dictionary;
		}
	}
	public static class UnmarshallerExtensions
	{
		public static void Add<TKey, TValue>(this Dictionary<TKey, TValue> dict, KeyValuePair<TKey, TValue> item)
		{
			dict.Add(item.Key, item.Value);
		}
	}
	public abstract class UnmarshallerContext : IDisposable
	{
		private bool disposed;

		protected bool MaintainResponseBody { get; set; }

		protected bool IsException { get; set; }

		protected CrcCalculatorStream CrcStream { get; set; }

		protected int Crc32Result { get; set; }

		protected IWebResponseData WebResponseData { get; set; }

		protected CachingWrapperStream WrappingStream { get; set; }

		public string ResponseBody
		{
			get
			{
				byte[] responseBodyBytes = GetResponseBodyBytes();
				return Encoding.UTF8.GetString(responseBodyBytes, 0, responseBodyBytes.Length);
			}
		}

		public IWebResponseData ResponseData => WebResponseData;

		public abstract string CurrentPath { get; }

		public abstract int CurrentDepth { get; }

		public abstract bool IsStartElement { get; }

		public abstract bool IsEndElement { get; }

		public abstract bool IsStartOfDocument { get; }

		public byte[] GetResponseBodyBytes()
		{
			if (IsException)
			{
				return WrappingStream.AllReadBytes.ToArray();
			}
			if (MaintainResponseBody)
			{
				return WrappingStream.LoggableReadBytes.ToArray();
			}
			return new byte[0];
		}

		internal void ValidateCRC32IfAvailable()
		{
			if (CrcStream != null && CrcStream.Crc32 != Crc32Result)
			{
				throw new IOException("CRC value returned with response does not match the computed CRC value for the returned response body.");
			}
		}

		protected void SetupCRCStream(IWebResponseData responseData, Stream responseStream, long contentLength)
		{
			CrcStream = null;
			if (responseData != null && uint.TryParse(responseData.GetHeaderValue("x-amz-crc32"), out var result))
			{
				Crc32Result = (int)result;
				CrcStream = new CrcCalculatorStream(responseStream, contentLength);
			}
		}

		public bool TestExpression(string expression)
		{
			return TestExpression(expression, CurrentPath);
		}

		public bool TestExpression(string expression, int startingStackDepth)
		{
			return TestExpression(expression, startingStackDepth, CurrentPath, CurrentDepth);
		}

		public bool ReadAtDepth(int targetDepth)
		{
			if (Read())
			{
				return CurrentDepth >= targetDepth;
			}
			return false;
		}

		private static bool TestExpression(string expression, string currentPath)
		{
			if (expression.Equals("."))
			{
				return true;
			}
			return currentPath.EndsWith(expression, StringComparison.OrdinalIgnoreCase);
		}

		private static bool TestExpression(string expression, int startingStackDepth, string currentPath, int currentDepth)
		{
			if (expression.Equals("."))
			{
				return true;
			}
			int num = -1;
			checked
			{
				while ((num = expression.IndexOf("/", num + 1, StringComparison.Ordinal)) > -1)
				{
					if (expression[0] != '@')
					{
						startingStackDepth++;
					}
				}
				if (startingStackDepth == currentDepth && currentPath.Length > expression.Length && currentPath[currentPath.Length - expression.Length - 1] == '/')
				{
					return currentPath.EndsWith(expression, StringComparison.OrdinalIgnoreCase);
				}
				return false;
			}
		}

		public abstract bool Read();

		public abstract string ReadText();

		protected virtual void Dispose(bool disposing)
		{
			if (disposed)
			{
				return;
			}
			if (disposing)
			{
				if (CrcStream != null)
				{
					CrcStream.Dispose();
					CrcStream = null;
				}
				if (WrappingStream != null)
				{
					WrappingStream.Dispose();
					WrappingStream = null;
				}
			}
			disposed = true;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}
	}
	public class XmlUnmarshallerContext : UnmarshallerContext
	{
		private static readonly XmlReaderSettings READER_SETTINGS = new XmlReaderSettings
		{
			DtdProcessing = DtdProcessing.Ignore,
			IgnoreWhitespace = true
		};

		private static HashSet<XmlNodeType> nodesToSkip = new HashSet<XmlNodeType>
		{
			XmlNodeType.None,
			XmlNodeType.XmlDeclaration,
			XmlNodeType.Comment,
			XmlNodeType.DocumentType
		};

		private StreamReader streamReader;

		private XmlReader _xmlReader;

		private Stack<string> stack = new Stack<string>();

		private string stackString = "";

		private Dictionary<string, string> attributeValues;

		private List<string> attributeNames;

		private IEnumerator<string> attributeEnumerator;

		private XmlNodeType nodeType;

		private string nodeContent = string.Empty;

		private bool disposed;

		public Stream Stream => streamReader.BaseStream;

		private XmlReader XmlReader
		{
			get
			{
				if (_xmlReader == null)
				{
					_xmlReader = XmlReader.Create(streamReader, READER_SETTINGS);
				}
				return _xmlReader;
			}
		}

		public override string CurrentPath => stackString;

		public override int CurrentDepth => stack.Count;

		public override bool IsStartElement => nodeType == XmlNodeType.Element;

		public override bool IsEndElement => nodeType == XmlNodeType.EndElement;

		public override bool IsStartOfDocument => XmlReader.ReadState == ReadState.Initial;

		public bool IsAttribute => nodeType == XmlNodeType.Attribute;

		public XmlUnmarshallerContext(Stream responseStream, bool maintainResponseBody, IWebResponseData responseData, bool isException = false)
		{
			if (isException)
			{
				base.WrappingStream = new CachingWrapperStream(responseStream);
			}
			else if (maintainResponseBody)
			{
				base.WrappingStream = new CachingWrapperStream(responseStream, AWSConfigs.LoggingConfig.LogResponsesSizeLimit);
			}
			if (isException || maintainResponseBody)
			{
				responseStream = base.WrappingStream;
			}
			streamReader = new StreamReader(responseStream);
			base.WebResponseData = responseData;
			base.MaintainResponseBody = maintainResponseBody;
			base.IsException = isException;
		}

		public override bool Read()
		{
			if (attributeEnumerator != null && attributeEnumerator.MoveNext())
			{
				nodeType = XmlNodeType.Attribute;
				stackString = string.Format(CultureInfo.InvariantCulture, "{0}/@{1}", StackToPath(stack), attributeEnumerator.Current);
			}
			else
			{
				if (nodesToSkip.Contains(XmlReader.NodeType))
				{
					XmlReader.Read();
				}
				while (XmlReader.IsEmptyElement)
				{
					XmlReader.Read();
				}
				switch (XmlReader.NodeType)
				{
				case XmlNodeType.EndElement:
					nodeType = XmlNodeType.EndElement;
					stack.Pop();
					stackString = StackToPath(stack);
					XmlReader.Read();
					break;
				case XmlNodeType.Element:
					nodeType = XmlNodeType.Element;
					stack.Push(XmlReader.LocalName);
					stackString = StackToPath(stack);
					ReadElement();
					break;
				}
			}
			if (XmlReader.ReadState != ReadState.EndOfFile && XmlReader.ReadState != ReadState.Error)
			{
				return XmlReader.ReadState != ReadState.Closed;
			}
			return false;
		}

		public override string ReadText()
		{
			if (nodeType == XmlNodeType.Attribute)
			{
				return attributeValues[attributeEnumerator.Current];
			}
			return nodeContent;
		}

		private static string StackToPath(Stack<string> stack)
		{
			string text = null;
			string[] array = stack.ToArray();
			foreach (string text2 in array)
			{
				text = ((text == null) ? text2 : string.Format(CultureInfo.InvariantCulture, "{0}/{1}", text2, text));
			}
			return "/" + text;
		}

		private void ReadElement()
		{
			if (XmlReader.HasAttributes)
			{
				attributeValues = new Dictionary<string, string>();
				attributeNames = new List<string>();
				while (XmlReader.MoveToNextAttribute())
				{
					attributeValues.Add(XmlReader.LocalName, XmlReader.Value);
					attributeNames.Add(XmlReader.LocalName);
				}
				attributeEnumerator = attributeNames.GetEnumerator();
			}
			XmlReader.MoveToElement();
			XmlReader.Read();
			if (XmlReader.NodeType == XmlNodeType.Text)
			{
				nodeContent = XmlReader.ReadContentAsString();
			}
			else
			{
				nodeContent = string.Empty;
			}
		}

		protected override void Dispose(bool disposing)
		{
			if (!disposed)
			{
				if (disposing)
				{
					if (streamReader != null)
					{
						streamReader.Dispose();
						streamReader = null;
					}
					if (_xmlReader != null)
					{
						_xmlReader.Dispose();
						_xmlReader = null;
					}
				}
				disposed = true;
			}
			base.Dispose(disposing);
		}
	}
	public class EC2UnmarshallerContext : XmlUnmarshallerContext
	{
		public string RequestId { get; private set; }

		public EC2UnmarshallerContext(Stream responseStream, bool maintainResponseBody, IWebResponseData responseData, bool isException = false)
			: base(responseStream, maintainResponseBody, responseData, isException)
		{
		}

		public override bool Read()
		{
			bool result = base.Read();
			if (RequestId == null && IsStartElement && TestExpression("RequestId", 2))
			{
				RequestId = StringUnmarshaller.GetInstance().Unmarshall(this);
			}
			return result;
		}
	}
	public class HttpClientResponseData : IWebResponseData
	{
		private HttpResponseMessageBody _response;

		private string[] _headerNames;

		private Dictionary<string, string> _headers;

		private HashSet<string> _headerNamesSet;

		public HttpStatusCode StatusCode { get; private set; }

		public bool IsSuccessStatusCode { get; private set; }

		public string ContentType { get; private set; }

		public long ContentLength { get; private set; }

		public IHttpResponseBody ResponseBody => _response;

		internal HttpClientResponseData(HttpResponseMessage response)
			: this(response, null, disposeClient: false)
		{
		}

		internal HttpClientResponseData(HttpResponseMessage response, HttpClient httpClient, bool disposeClient)
		{
			_response = new HttpResponseMessageBody(response, httpClient, disposeClient);
			StatusCode = response.StatusCode;
			IsSuccessStatusCode = response.IsSuccessStatusCode;
			ContentLength = response.Content.Headers.ContentLength ?? 0;
			if (response.Content.Headers.ContentType != null)
			{
				ContentType = response.Content.Headers.ContentType.MediaType;
			}
			CopyHeaderValues(response);
		}

		public string GetHeaderValue(string headerName)
		{
			if (_headers.TryGetValue(headerName, out var value))
			{
				return value;
			}
			return string.Empty;
		}

		public bool IsHeaderPresent(string headerName)
		{
			return _headerNamesSet.Contains(headerName);
		}

		public string[] GetHeaderNames()
		{
			return _headerNames;
		}

		private void CopyHeaderValues(HttpResponseMessage response)
		{
			List<string> list = new List<string>();
			_headers = new Dictionary<string, string>(10, StringComparer.OrdinalIgnoreCase);
			foreach (KeyValuePair<string, IEnumerable<string>> header in response.Headers)
			{
				list.Add(header.Key);
				string firstHeaderValue = GetFirstHeaderValue(response.Headers, header.Key);
				_headers.Add(header.Key, firstHeaderValue);
			}
			if (response.Content != null)
			{
				foreach (KeyValuePair<string, IEnumerable<string>> header2 in response.Content.Headers)
				{
					if (!list.Contains(header2.Key))
					{
						list.Add(header2.Key);
						string firstHeaderValue2 = GetFirstHeaderValue(response.Content.Headers, header2.Key);
						_headers.Add(header2.Key, firstHeaderValue2);
					}
				}
			}
			_headerNames = list.ToArray();
			_headerNamesSet = new HashSet<string>(_headerNames, StringComparer.OrdinalIgnoreCase);
		}

		private string GetFirstHeaderValue(HttpHeaders headers, string key)
		{
			IEnumerable<string> values = null;
			if (headers.TryGetValues(key, out values))
			{
				return values.FirstOrDefault();
			}
			return string.Empty;
		}
	}
	[CLSCompliant(false)]
	public class HttpResponseMessageBody : IHttpResponseBody, IDisposable
	{
		private HttpClient _httpClient;

		private HttpResponseMessage _response;

		private bool _disposeClient;

		private bool _disposed;

		public HttpResponseMessageBody(HttpResponseMessage response, HttpClient httpClient, bool disposeClient)
		{
			_httpClient = httpClient;
			_response = response;
			_disposeClient = disposeClient;
		}

		public Stream OpenResponse()
		{
			if (_disposed)
			{
				throw new ObjectDisposedException("HttpWebResponseBody");
			}
			return _response.Content.ReadAsStreamAsync().Result;
		}

		public Task<Stream> OpenResponseAsync()
		{
			if (_disposed)
			{
				throw new ObjectDisposedException("HttpWebResponseBody");
			}
			return _response.Content.ReadAsStreamAsync();
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (!_disposed && disposing)
			{
				if (_response != null)
				{
					_response.Dispose();
				}
				if (_httpClient != null && _disposeClient)
				{
					_httpClient.Dispose();
				}
				_disposed = true;
			}
		}
	}
}
namespace Amazon.Runtime.Internal.Auth
{
	public enum ClientProtocol
	{
		QueryStringProtocol,
		RestProtocol,
		Unknown
	}
	public abstract class AbstractAWSSigner
	{
		private AWS4Signer _aws4Signer;

		private AWS4Signer AWS4SignerInstance
		{
			get
			{
				if (_aws4Signer == null)
				{
					lock (this)
					{
						if (_aws4Signer == null)
						{
							_aws4Signer = new AWS4Signer();
						}
					}
				}
				return _aws4Signer;
			}
		}

		public abstract ClientProtocol Protocol { get; }

		protected static string ComputeHash(string data, string secretkey, SigningAlgorithm algorithm)
		{
			try
			{
				return CryptoUtilFactory.CryptoInstance.HMACSign(data, secretkey, algorithm);
			}
			catch (Exception ex)
			{
				throw new Amazon.Runtime.SignatureException("Failed to generate signature: " + ex.Message, ex);
			}
		}

		protected static string ComputeHash(byte[] data, string secretkey, SigningAlgorithm algorithm)
		{
			try
			{
				return CryptoUtilFactory.CryptoInstance.HMACSign(data, secretkey, algorithm);
			}
			catch (Exception ex)
			{
				throw new Amazon.Runtime.SignatureException("Failed to generate signature: " + ex.Message, ex);
			}
		}

		public abstract void Sign(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, string awsAccessKeyId, string awsSecretAccessKey);

		protected static bool UseV4Signing(bool useSigV4Setting, IRequest request, IClientConfig config)
		{
			if (request.UseSigV4 || config.SignatureVersion == "4" || (useSigV4Setting && config.SignatureVersion != "2"))
			{
				return true;
			}
			RegionEndpoint regionEndpoint = null;
			if (!string.IsNullOrEmpty(request.AuthenticationRegion))
			{
				regionEndpoint = RegionEndpoint.GetBySystemName(request.AuthenticationRegion);
			}
			if (regionEndpoint == null && !string.IsNullOrEmpty(config.ServiceURL))
			{
				string text = AWSSDKUtils.DetermineRegion(config.ServiceURL);
				if (!string.IsNullOrEmpty(text))
				{
					regionEndpoint = RegionEndpoint.GetBySystemName(text);
				}
			}
			if (regionEndpoint == null && config.RegionEndpoint != null)
			{
				regionEndpoint = config.RegionEndpoint;
			}
			if (regionEndpoint != null)
			{
				RegionEndpoint.Endpoint endpointForService = regionEndpoint.GetEndpointForService(config.RegionEndpointServiceName, config.UseDualstackEndpoint);
				if (endpointForService != null && (endpointForService.SignatureVersionOverride == "4" || string.IsNullOrEmpty(endpointForService.SignatureVersionOverride)))
				{
					return true;
				}
			}
			return false;
		}

		protected AbstractAWSSigner SelectSigner(IRequest request, IClientConfig config)
		{
			return SelectSigner(this, useSigV4Setting: false, request, config);
		}

		protected AbstractAWSSigner SelectSigner(AbstractAWSSigner defaultSigner, bool useSigV4Setting, IRequest request, IClientConfig config)
		{
			if (UseV4Signing(useSigV4Setting, request, config))
			{
				return AWS4SignerInstance;
			}
			return defaultSigner;
		}
	}
	public class AWS3Signer : AbstractAWSSigner
	{
		private const string HTTP_SCHEME = "AWS3";

		private const string HTTPS_SCHEME = "AWS3-HTTPS";

		private const string Slash = "/";

		private bool UseAws3Https { get; set; }

		public override ClientProtocol Protocol => ClientProtocol.RestProtocol;

		public AWS3Signer(bool useAws3Https)
		{
			UseAws3Https = useAws3Https;
		}

		public AWS3Signer()
			: this(useAws3Https: false)
		{
		}

		public override void Sign(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, string awsAccessKeyId, string awsSecretAccessKey)
		{
			AbstractAWSSigner abstractAWSSigner = SelectSigner(request, clientConfig);
			if (abstractAWSSigner is AWS4Signer)
			{
				abstractAWSSigner.Sign(request, clientConfig, metrics, awsAccessKeyId, awsSecretAccessKey);
			}
			else if (UseAws3Https)
			{
				SignHttps(request, clientConfig, metrics, awsAccessKeyId, awsSecretAccessKey);
			}
			else
			{
				SignHttp(request, metrics, awsAccessKeyId, awsSecretAccessKey);
			}
		}

		private static void SignHttps(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, string awsAccessKeyId, string awsSecretAccessKey)
		{
			string text = Guid.NewGuid().ToString();
			string formattedCurrentTimestampRFC = AWSSDKUtils.FormattedCurrentTimestampRFC822;
			string text2 = formattedCurrentTimestampRFC + text;
			metrics.AddProperty(Metric.StringToSign, text2);
			string text3 = AbstractAWSSigner.ComputeHash(text2, awsSecretAccessKey, clientConfig.SignatureMethod);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("AWS3-HTTPS").Append(" ");
			stringBuilder.Append("AWSAccessKeyId=" + awsAccessKeyId + ",");
			stringBuilder.Append("Algorithm=" + clientConfig.SignatureMethod.ToString() + ",");
			stringBuilder.Append("SignedHeaders=x-amz-date;x-amz-nonce,");
			stringBuilder.Append("Signature=" + text3);
			request.Headers["X-Amzn-Authorization"] = stringBuilder.ToString();
			request.Headers["x-amz-nonce"] = text;
			request.Headers["X-Amz-Date"] = formattedCurrentTimestampRFC;
		}

		private static void SignHttp(IRequest request, RequestMetrics metrics, string awsAccessKeyId, string awsSecretAccessKey)
		{
			SigningAlgorithm algorithm = SigningAlgorithm.HmacSHA256;
			string text = Guid.NewGuid().ToString();
			string formattedCurrentTimestampRFC = AWSSDKUtils.FormattedCurrentTimestampRFC822;
			bool flag = IsHttpsRequest(request);
			flag = false;
			request.Headers["Date"] = formattedCurrentTimestampRFC;
			request.Headers["X-Amz-Date"] = formattedCurrentTimestampRFC;
			request.Headers.Remove("X-Amzn-Authorization");
			string text2 = request.Endpoint.Host;
			if (!request.Endpoint.IsDefaultPort)
			{
				text2 = text2 + ":" + request.Endpoint.Port;
			}
			request.Headers["host"] = text2;
			byte[] array = null;
			string text3;
			if (flag)
			{
				request.Headers["x-amz-nonce"] = text;
				text3 = formattedCurrentTimestampRFC + text;
				array = Encoding.UTF8.GetBytes(text3);
			}
			else
			{
				text3 = request.HttpMethod + "\n" + GetCanonicalizedResourcePath(request) + "\n" + GetCanonicalizedQueryString(request.Parameters) + "\n" + GetCanonicalizedHeadersForStringToSign(request) + "\n" + GetRequestPayload(request);
				array = CryptoUtilFactory.CryptoInstance.ComputeSHA256Hash(Encoding.UTF8.GetBytes(text3));
			}
			metrics.AddProperty(Metric.StringToSign, text3);
			string text4 = AbstractAWSSigner.ComputeHash(array, awsSecretAccessKey, algorithm);
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(flag ? "AWS3-HTTPS" : "AWS3");
			stringBuilder.Append(" ");
			stringBuilder.Append("AWSAccessKeyId=" + awsAccessKeyId + ",");
			stringBuilder.Append("Algorithm=" + algorithm.ToString() + ",");
			if (!flag)
			{
				stringBuilder.Append(GetSignedHeadersComponent(request) + ",");
			}
			stringBuilder.Append("Signature=" + text4);
			string value = stringBuilder.ToString();
			request.Headers["X-Amzn-Authorization"] = value;
		}

		private static string GetCanonicalizedResourcePath(IRequest request)
		{
			string text = request.ResourcePath;
			if (request.Endpoint != null)
			{
				string text2 = request.Endpoint.AbsolutePath;
				if (string.IsNullOrEmpty(text2) || string.Equals(text2, "/", StringComparison.Ordinal))
				{
					text2 = string.Empty;
				}
				if (text != null && text.StartsWith("/", StringComparison.Ordinal))
				{
					text = text.Substring(1);
				}
				if (!string.IsNullOrEmpty(text))
				{
					text2 = text2 + "/" + text;
				}
				text = text2;
			}
			if (string.IsNullOrEmpty(text))
			{
				return "/";
			}
			if (request.MarshallerVersion >= 2)
			{
				return AWSSDKUtils.ResolveResourcePath(text, request.PathResources);
			}
			return AWSSDKUtils.UrlEncode(text, path: true);
		}

		private static bool IsHttpsRequest(IRequest request)
		{
			string scheme = request.Endpoint.Scheme;
			if (scheme.Equals("http", StringComparison.OrdinalIgnoreCase))
			{
				return false;
			}
			if (scheme.Equals("https", StringComparison.OrdinalIgnoreCase))
			{
				return true;
			}
			throw new AmazonServiceException("Unknown request endpoint protocol encountered while signing request: " + scheme);
		}

		private static string GetCanonicalizedQueryString(IDictionary<string, string> parameters)
		{
			SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>(parameters, StringComparer.Ordinal);
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> item in (IEnumerable<KeyValuePair<string, string>>)sortedDictionary)
			{
				if (item.Value != null)
				{
					string key = item.Key;
					string value = item.Value;
					stringBuilder.Append(AWSSDKUtils.UrlEncode(key, path: false));
					stringBuilder.Append("=");
					stringBuilder.Append(AWSSDKUtils.UrlEncode(value, path: false));
					stringBuilder.Append("&");
				}
			}
			string text = stringBuilder.ToString();
			if (!string.IsNullOrEmpty(text))
			{
				return text.Substring(0, checked(text.Length - 1));
			}
			return string.Empty;
		}

		private static string GetRequestPayload(IRequest request)
		{
			if (request.Content == null)
			{
				return string.Empty;
			}
			return Encoding.UTF8.GetString(request.Content, 0, request.Content.Length);
		}

		private static string GetSignedHeadersComponent(IRequest request)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("SignedHeaders=");
			bool flag = true;
			foreach (string item in GetHeadersForStringToSign(request))
			{
				if (!flag)
				{
					stringBuilder.Append(";");
				}
				stringBuilder.Append(item);
				flag = false;
			}
			return stringBuilder.ToString();
		}

		private static List<string> GetHeadersForStringToSign(IRequest request)
		{
			List<string> list = new List<string>();
			foreach (KeyValuePair<string, string> header in request.Headers)
			{
				string key = header.Key;
				if (key.StartsWith("x-amz", StringComparison.OrdinalIgnoreCase) || key.Equals("content-encoding", StringComparison.OrdinalIgnoreCase) || key.Equals("host", StringComparison.OrdinalIgnoreCase))
				{
					list.Add(key);
				}
			}
			list.Sort(StringComparer.OrdinalIgnoreCase);
			return list;
		}

		private static string GetCanonicalizedHeadersForStringToSign(IRequest request)
		{
			List<string> headersForStringToSign = GetHeadersForStringToSign(request);
			for (int i = 0; i < headersForStringToSign.Count; i = checked(i + 1))
			{
				headersForStringToSign[i] = headersForStringToSign[i].ToLowerInvariant();
			}
			SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>();
			foreach (KeyValuePair<string, string> header in request.Headers)
			{
				if (headersForStringToSign.Contains(header.Key.ToLowerInvariant()))
				{
					sortedDictionary[header.Key] = header.Value;
				}
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> item in sortedDictionary)
			{
				stringBuilder.Append(item.Key.ToLowerInvariant());
				stringBuilder.Append(":");
				stringBuilder.Append(item.Value);
				stringBuilder.Append("\n");
			}
			return stringBuilder.ToString();
		}
	}
	internal class AWS3HTTPSigner : AWS3Signer
	{
		public AWS3HTTPSigner()
			: base(useAws3Https: false)
		{
		}
	}
	public class AWS4Signer : AbstractAWSSigner
	{
		public const string Scheme = "AWS4";

		public const string Algorithm = "HMAC-SHA256";

		public const string AWS4AlgorithmTag = "AWS4-HMAC-SHA256";

		public const string Terminator = "aws4_request";

		public static readonly byte[] TerminatorBytes = Encoding.UTF8.GetBytes("aws4_request");

		public const string Credential = "Credential";

		public const string SignedHeaders = "SignedHeaders";

		public const string Signature = "Signature";

		public const string EmptyBodySha256 = "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855";

		public const string StreamingBodySha256 = "STREAMING-AWS4-HMAC-SHA256-PAYLOAD";

		public const string AWSChunkedEncoding = "aws-chunked";

		public const string UnsignedPayload = "UNSIGNED-PAYLOAD";

		private const SigningAlgorithm SignerAlgorithm = SigningAlgorithm.HmacSHA256;

		private static IEnumerable<string> _headersToIgnoreWhenSigning = new HashSet<string>(StringComparer.OrdinalIgnoreCase) { "x-amzn-trace-id", "transfer-encoding" };

		public bool SignPayload { get; private set; }

		public override ClientProtocol Protocol => ClientProtocol.RestProtocol;

		public AWS4Signer()
			: this(signPayload: true)
		{
		}

		public AWS4Signer(bool signPayload)
		{
			SignPayload = signPayload;
		}

		public override void Sign(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, string awsAccessKeyId, string awsSecretAccessKey)
		{
			AWS4SigningResult aWS4SigningResult = SignRequest(request, clientConfig, metrics, awsAccessKeyId, awsSecretAccessKey);
			request.Headers["Authorization"] = aWS4SigningResult.ForAuthorizationHeader;
		}

		public AWS4SigningResult SignRequest(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, string awsAccessKeyId, string awsSecretAccessKey)
		{
			DateTime signedAt = InitializeHeaders(request.Headers, request.Endpoint);
			string text = DetermineService(clientConfig);
			request.DeterminedSigningRegion = DetermineSigningRegion(clientConfig, text, request.AlternateEndpoint, request);
			string canonicalQueryString = CanonicalizeQueryParameters(GetParametersToCanonicalize(request));
			string precomputedBodyHash = SetRequestBodyHash(request, SignPayload);
			IDictionary<string, string> sortedHeaders = SortAndPruneHeaders(request.Headers);
			string text2 = CanonicalizeRequest(request.Endpoint, request.ResourcePath, request.HttpMethod, sortedHeaders, canonicalQueryString, precomputedBodyHash, request.PathResources, request.MarshallerVersion, text);
			metrics?.AddProperty(Metric.CanonicalRequest, text2);
			return ComputeSignature(awsAccessKeyId, awsSecretAccessKey, request.DeterminedSigningRegion, signedAt, text, CanonicalizeHeaderNames(sortedHeaders), text2, metrics);
		}

		public static DateTime InitializeHeaders(IDictionary<string, string> headers, System.Uri requestEndpoint)
		{
			return InitializeHeaders(headers, requestEndpoint, CorrectClockSkew.GetCorrectedUtcNowForEndpoint(requestEndpoint.ToString()));
		}

		public static DateTime InitializeHeaders(IDictionary<string, string> headers, System.Uri requestEndpoint, DateTime requestDateTime)
		{
			CleanHeaders(headers);
			if (!headers.ContainsKey("host"))
			{
				string text = requestEndpoint.Host;
				if (!requestEndpoint.IsDefaultPort)
				{
					text = text + ":" + requestEndpoint.Port;
				}
				headers.Add("host", text);
			}
			DateTime result = requestDateTime;
			headers["X-Amz-Date"] = result.ToUniversalTime().ToString("yyyyMMddTHHmmssZ", CultureInfo.InvariantCulture);
			return result;
		}

		private static void CleanHeaders(IDictionary<string, string> headers)
		{
			headers.Remove("Authorization");
			headers.Remove("X-Amz-Content-SHA256");
			if (headers.ContainsKey("X-Amz-Decoded-Content-Length"))
			{
				headers["Content-Length"] = headers["X-Amz-Decoded-Content-Length"];
				headers.Remove("X-Amz-Decoded-Content-Length");
			}
		}

		public static AWS4SigningResult ComputeSignature(ImmutableCredentials credentials, string region, DateTime signedAt, string service, string signedHeaders, string canonicalRequest)
		{
			return ComputeSignature(credentials.AccessKey, credentials.SecretKey, region, signedAt, service, signedHeaders, canonicalRequest);
		}

		public static AWS4SigningResult ComputeSignature(string awsAccessKey, string awsSecretAccessKey, string region, DateTime signedAt, string service, string signedHeaders, string canonicalRequest)
		{
			return ComputeSignature(awsAccessKey, awsSecretAccessKey, region, signedAt, service, signedHeaders, canonicalRequest, null);
		}

		public static AWS4SigningResult ComputeSignature(string awsAccessKey, string awsSecretAccessKey, string region, DateTime signedAt, string service, string signedHeaders, string canonicalRequest, RequestMetrics metrics)
		{
			string text = FormatDateTime(signedAt, "yyyyMMdd");
			string text2 = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}/{3}", text, region, service, "aws4_request");
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat(CultureInfo.InvariantCulture, "{0}-{1}\n{2}\n{3}\n", "AWS4", "HMAC-SHA256", FormatDateTime(signedAt, "yyyyMMddTHHmmssZ"), text2);
			byte[] data = ComputeHash(canonicalRequest);
			stringBuilder.Append(AWSSDKUtils.ToHex(data, lowercase: true));
			metrics?.AddProperty(Metric.StringToSign, stringBuilder);
			byte[] array = ComposeSigningKey(awsSecretAccessKey, region, text, service);
			string data2 = stringBuilder.ToString();
			byte[] signature = ComputeKeyedHash(SigningAlgorithm.HmacSHA256, array, data2);
			return new AWS4SigningResult(awsAccessKey, signedAt, signedHeaders, text2, array, signature);
		}

		public static string FormatDateTime(DateTime dt, string formatString)
		{
			return dt.ToUniversalTime().ToString(formatString, CultureInfo.InvariantCulture);
		}

		public static byte[] ComposeSigningKey(string awsSecretAccessKey, string region, string date, string service)
		{
			char[] array = null;
			try
			{
				array = ("AWS4" + awsSecretAccessKey).ToCharArray();
				byte[] key = ComputeKeyedHash(SigningAlgorithm.HmacSHA256, Encoding.UTF8.GetBytes(array), Encoding.UTF8.GetBytes(date));
				byte[] key2 = ComputeKeyedHash(SigningAlgorithm.HmacSHA256, key, Encoding.UTF8.GetBytes(region));
				byte[] key3 = ComputeKeyedHash(SigningAlgorithm.HmacSHA256, key2, Encoding.UTF8.GetBytes(service));
				return ComputeKeyedHash(SigningAlgorithm.HmacSHA256, key3, TerminatorBytes);
			}
			finally
			{
				if (array != null)
				{
					Array.Clear(array, 0, array.Length);
				}
			}
		}

		public static string SetRequestBodyHash(IRequest request)
		{
			return SetRequestBodyHash(request, signPayload: true);
		}

		public static string SetRequestBodyHash(IRequest request, bool signPayload)
		{
			if (!signPayload)
			{
				return SetPayloadSignatureHeader(request, "UNSIGNED-PAYLOAD");
			}
			string value = null;
			if (request.Headers.TryGetValue("X-Amz-Content-SHA256", out value) && !request.UseChunkEncoding)
			{
				return value;
			}
			if (request.UseChunkEncoding)
			{
				value = "STREAMING-AWS4-HMAC-SHA256-PAYLOAD";
				if (request.Headers.ContainsKey("Content-Length"))
				{
					request.Headers["X-Amz-Decoded-Content-Length"] = request.Headers["Content-Length"];
					long originalLength = long.Parse(request.Headers["Content-Length"], CultureInfo.InvariantCulture);
					request.Headers["Content-Length"] = ChunkedUploadWrapperStream.ComputeChunkedContentLength(originalLength).ToString(CultureInfo.InvariantCulture);
				}
				if (request.Headers.ContainsKey("Content-Encoding"))
				{
					string text = request.Headers["Content-Encoding"];
					if (!text.Contains("aws-chunked"))
					{
						request.Headers["Content-Encoding"] = text + ", " + "aws-chunked";
					}
				}
			}
			else if (request.ContentStream != null)
			{
				value = request.ComputeContentStreamHash();
			}
			else
			{
				byte[] requestPayloadBytes = GetRequestPayloadBytes(request);
				value = AWSSDKUtils.ToHex(CryptoUtilFactory.CryptoInstance.ComputeSHA256Hash(requestPayloadBytes), lowercase: true);
			}
			return SetPayloadSignatureHeader(request, value ?? "UNSIGNED-PAYLOAD");
		}

		public static byte[] SignBlob(byte[] key, string data)
		{
			return SignBlob(key, Encoding.UTF8.GetBytes(data));
		}

		public static byte[] SignBlob(byte[] key, byte[] data)
		{
			return CryptoUtilFactory.CryptoInstance.HMACSignBinary(data, key, SigningAlgorithm.HmacSHA256);
		}

		public static byte[] ComputeKeyedHash(SigningAlgorithm algorithm, byte[] key, string data)
		{
			return ComputeKeyedHash(algorithm, key, Encoding.UTF8.GetBytes(data));
		}

		public static byte[] ComputeKeyedHash(SigningAlgorithm algorithm, byte[] key, byte[] data)
		{
			return CryptoUtilFactory.CryptoInstance.HMACSignBinary(data, key, algorithm);
		}

		public static byte[] ComputeHash(string data)
		{
			return ComputeHash(Encoding.UTF8.GetBytes(data));
		}

		public static byte[] ComputeHash(byte[] data)
		{
			return CryptoUtilFactory.CryptoInstance.ComputeSHA256Hash(data);
		}

		private static string SetPayloadSignatureHeader(IRequest request, string payloadHash)
		{
			if (request.Headers.ContainsKey("X-Amz-Content-SHA256"))
			{
				request.Headers["X-Amz-Content-SHA256"] = payloadHash;
			}
			else
			{
				request.Headers.Add("X-Amz-Content-SHA256", payloadHash);
			}
			return payloadHash;
		}

		public static string DetermineSigningRegion(IClientConfig clientConfig, string serviceName, RegionEndpoint alternateEndpoint, IRequest request)
		{
			if (alternateEndpoint != null)
			{
				RegionEndpoint.Endpoint endpointForService = alternateEndpoint.GetEndpointForService(serviceName, clientConfig.UseDualstackEndpoint);
				if (endpointForService.AuthRegion != null)
				{
					return endpointForService.AuthRegion;
				}
				return alternateEndpoint.SystemName;
			}
			string authenticationRegion = clientConfig.AuthenticationRegion;
			if (request != null && request.AuthenticationRegion != null)
			{
				authenticationRegion = request.AuthenticationRegion;
			}
			if (!string.IsNullOrEmpty(authenticationRegion))
			{
				return authenticationRegion.ToLowerInvariant();
			}
			if (!string.IsNullOrEmpty(clientConfig.ServiceURL))
			{
				string text = AWSSDKUtils.DetermineRegion(clientConfig.ServiceURL);
				if (!string.IsNullOrEmpty(text))
				{
					return text.ToLowerInvariant();
				}
			}
			RegionEndpoint regionEndpoint = clientConfig.RegionEndpoint;
			if (regionEndpoint != null)
			{
				RegionEndpoint.Endpoint endpointForService2 = regionEndpoint.GetEndpointForService(serviceName, clientConfig.UseDualstackEndpoint);
				if (!string.IsNullOrEmpty(endpointForService2.AuthRegion))
				{
					return endpointForService2.AuthRegion;
				}
				RegionEndpoint regionEndpointOverride = RegionEndpoint.GetRegionEndpointOverride(regionEndpoint);
				if (regionEndpointOverride != null)
				{
					return regionEndpointOverride.SystemName;
				}
				return regionEndpoint.SystemName;
			}
			return string.Empty;
		}

		internal static string DetermineService(IClientConfig clientConfig)
		{
			if (string.IsNullOrEmpty(clientConfig.AuthenticationServiceName))
			{
				return AWSSDKUtils.DetermineService(clientConfig.DetermineServiceURL());
			}
			return clientConfig.AuthenticationServiceName;
		}

		protected static string CanonicalizeRequest(System.Uri endpoint, string resourcePath, string httpMethod, IDictionary<string, string> sortedHeaders, string canonicalQueryString, string precomputedBodyHash)
		{
			return CanonicalizeRequest(endpoint, resourcePath, httpMethod, sortedHeaders, canonicalQueryString, precomputedBodyHash, null, 1);
		}

		protected static string CanonicalizeRequest(System.Uri endpoint, string resourcePath, string httpMethod, IDictionary<string, string> sortedHeaders, string canonicalQueryString, string precomputedBodyHash, IDictionary<string, string> pathResources, int marshallerVersion)
		{
			return CanonicalizeRequestHelper(endpoint, resourcePath, httpMethod, sortedHeaders, canonicalQueryString, precomputedBodyHash, pathResources, marshallerVersion, detectPreEncode: true);
		}

		protected static string CanonicalizeRequest(System.Uri endpoint, string resourcePath, string httpMethod, IDictionary<string, string> sortedHeaders, string canonicalQueryString, string precomputedBodyHash, IDictionary<string, string> pathResources, int marshallerVersion, string service)
		{
			return CanonicalizeRequestHelper(endpoint, resourcePath, httpMethod, sortedHeaders, canonicalQueryString, precomputedBodyHash, pathResources, marshallerVersion, !(service == "s3"));
		}

		private static string CanonicalizeRequestHelper(System.Uri endpoint, string resourcePath, string httpMethod, IDictionary<string, string> sortedHeaders, string canonicalQueryString, string precomputedBodyHash, IDictionary<string, string> pathResources, int marshallerVersion, bool detectPreEncode)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("{0}\n", httpMethod);
			stringBuilder.AppendFormat("{0}\n", AWSSDKUtils.CanonicalizeResourcePath(endpoint, resourcePath, detectPreEncode, pathResources, marshallerVersion));
			stringBuilder.AppendFormat("{0}\n", canonicalQueryString);
			stringBuilder.AppendFormat("{0}\n", CanonicalizeHeaders(sortedHeaders));
			stringBuilder.AppendFormat("{0}\n", CanonicalizeHeaderNames(sortedHeaders));
			string value;
			if (precomputedBodyHash != null)
			{
				stringBuilder.Append(precomputedBodyHash);
			}
			else if (sortedHeaders.TryGetValue("X-Amz-Content-SHA256", out value))
			{
				stringBuilder.Append(value);
			}
			return stringBuilder.ToString();
		}

		protected static IDictionary<string, string> SortAndPruneHeaders(IEnumerable<KeyValuePair<string, string>> requestHeaders)
		{
			SortedDictionary<string, string> sortedDictionary = new SortedDictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			foreach (KeyValuePair<string, string> requestHeader in requestHeaders)
			{
				if (!_headersToIgnoreWhenSigning.Contains(requestHeader.Key))
				{
					sortedDictionary.Add(requestHeader.Key, requestHeader.Value);
				}
			}
			return sortedDictionary;
		}

		protected static string CanonicalizeHeaders(IEnumerable<KeyValuePair<string, string>> sortedHeaders)
		{
			if (sortedHeaders == null || sortedHeaders.Count() == 0)
			{
				return string.Empty;
			}
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> sortedHeader in sortedHeaders)
			{
				stringBuilder.Append(sortedHeader.Key.ToLowerInvariant());
				stringBuilder.Append(":");
				stringBuilder.Append(AWSSDKUtils.CompressSpaces(sortedHeader.Value));
				stringBuilder.Append("\n");
			}
			return stringBuilder.ToString();
		}

		protected static string CanonicalizeHeaderNames(IEnumerable<KeyValuePair<string, string>> sortedHeaders)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> sortedHeader in sortedHeaders)
			{
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append(";");
				}
				stringBuilder.Append(sortedHeader.Key.ToLowerInvariant());
			}
			return stringBuilder.ToString();
		}

		protected static List<KeyValuePair<string, string>> GetParametersToCanonicalize(IRequest request)
		{
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			if (request.SubResources != null && request.SubResources.Count > 0)
			{
				foreach (KeyValuePair<string, string> subResource in request.SubResources)
				{
					list.Add(new KeyValuePair<string, string>(subResource.Key, subResource.Value));
				}
			}
			if (request.UseQueryString && request.Parameters != null && request.Parameters.Count > 0)
			{
				foreach (KeyValuePair<string, string> item in from queryParameter in request.ParameterCollection.GetSortedParametersList()
					where queryParameter.Value != null
					select queryParameter)
				{
					list.Add(new KeyValuePair<string, string>(item.Key, item.Value));
				}
			}
			return list;
		}

		protected static string CanonicalizeQueryParameters(string queryString)
		{
			return CanonicalizeQueryParameters(queryString, uriEncodeParameters: true);
		}

		protected static string CanonicalizeQueryParameters(string queryString, bool uriEncodeParameters)
		{
			if (string.IsNullOrEmpty(queryString))
			{
				return string.Empty;
			}
			Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			int num = queryString.IndexOf('?');
			checked
			{
				string text = queryString.Substring(++num);
				int num2 = 0;
				int num3 = text.IndexOfAny(new char[2] { '&', ';' }, 0);
				if (num3 == -1 && num2 < text.Length)
				{
					num3 = text.Length;
				}
				while (num3 != -1)
				{
					string text2 = text.Substring(num2, num3 - num2);
					if (num3 + 1 >= text.Length || text[num3 + 1] != ' ')
					{
						int num4 = text2.IndexOf('=');
						if (num4 == -1)
						{
							dictionary.Add(text2, null);
						}
						else
						{
							dictionary.Add(text2.Substring(0, num4), text2.Substring(num4 + 1));
						}
						num2 = num3 + 1;
					}
					if (text.Length <= num3 + 1)
					{
						break;
					}
					num3 = text.IndexOfAny(new char[2] { '&', ';' }, num3 + 1);
					if (num3 == -1 && num2 < text.Length)
					{
						num3 = text.Length;
					}
				}
				return CanonicalizeQueryParameters(dictionary, uriEncodeParameters);
			}
		}

		protected static string CanonicalizeQueryParameters(IEnumerable<KeyValuePair<string, string>> parameters)
		{
			return CanonicalizeQueryParameters(parameters, uriEncodeParameters: true);
		}

		protected static string CanonicalizeQueryParameters(IEnumerable<KeyValuePair<string, string>> parameters, bool uriEncodeParameters)
		{
			if (parameters == null)
			{
				return string.Empty;
			}
			List<KeyValuePair<string, string>> list = parameters.OrderBy((KeyValuePair<string, string> kvp) => kvp.Key, StringComparer.Ordinal).ToList();
			StringBuilder stringBuilder = new StringBuilder();
			foreach (KeyValuePair<string, string> item in list)
			{
				string key = item.Key;
				string value = item.Value;
				if (stringBuilder.Length > 0)
				{
					stringBuilder.Append("&");
				}
				if (uriEncodeParameters)
				{
					if (string.IsNullOrEmpty(value))
					{
						stringBuilder.AppendFormat("{0}=", AWSSDKUtils.UrlEncode(key, path: false));
					}
					else
					{
						stringBuilder.AppendFormat("{0}={1}", AWSSDKUtils.UrlEncode(key, path: false), AWSSDKUtils.UrlEncode(value, path: false));
					}
				}
				else if (string.IsNullOrEmpty(value))
				{
					stringBuilder.AppendFormat("{0}=", key);
				}
				else
				{
					stringBuilder.AppendFormat("{0}={1}", key, value);
				}
			}
			return stringBuilder.ToString();
		}

		private static byte[] GetRequestPayloadBytes(IRequest request)
		{
			if (request.Content != null)
			{
				return request.Content;
			}
			string s = (request.UseQueryString ? string.Empty : AWSSDKUtils.GetParametersAsString(request));
			return Encoding.UTF8.GetBytes(s);
		}
	}
	public class AWS4PreSignedUrlSigner : AWS4Signer
	{
		public const long MaxAWS4PreSignedUrlExpiry = 604800L;

		internal const string XAmzSignature = "X-Amz-Signature";

		internal const string XAmzAlgorithm = "X-Amz-Algorithm";

		internal const string XAmzCredential = "X-Amz-Credential";

		internal const string XAmzExpires = "X-Amz-Expires";

		public override void Sign(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, string awsAccessKeyId, string awsSecretAccessKey)
		{
			throw new InvalidOperationException("PreSignedUrl signature computation is not supported by this method; use SignRequest instead.");
		}

		public new AWS4SigningResult SignRequest(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, string awsAccessKeyId, string awsSecretAccessKey)
		{
			return SignRequest(request, clientConfig, metrics, awsAccessKeyId, awsSecretAccessKey, "s3", null);
		}

		public static AWS4SigningResult SignRequest(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, string awsAccessKeyId, string awsSecretAccessKey, string service, string overrideSigningRegion)
		{
			request.Headers.Remove("Authorization");
			if (!request.Headers.ContainsKey("host"))
			{
				string text = request.Endpoint.Host;
				if (!request.Endpoint.IsDefaultPort)
				{
					text = text + ":" + request.Endpoint.Port;
				}
				request.Headers.Add("host", text);
			}
			DateTime correctedUtcNowForEndpoint = CorrectClockSkew.GetCorrectedUtcNowForEndpoint(request.Endpoint.ToString());
			string text2 = overrideSigningRegion ?? AWS4Signer.DetermineSigningRegion(clientConfig, service, request.AlternateEndpoint, request);
			if (request.Headers.ContainsKey("X-Amz-Content-SHA256"))
			{
				request.Headers.Remove("X-Amz-Content-SHA256");
			}
			IDictionary<string, string> sortedHeaders = AWS4Signer.SortAndPruneHeaders(request.Headers);
			string text3 = AWS4Signer.CanonicalizeHeaderNames(sortedHeaders);
			List<KeyValuePair<string, string>> parametersToCanonicalize = AWS4Signer.GetParametersToCanonicalize(request);
			parametersToCanonicalize.Add(new KeyValuePair<string, string>("X-Amz-Algorithm", "AWS4-HMAC-SHA256"));
			string value = string.Format(CultureInfo.InvariantCulture, "{0}/{1}/{2}/{3}/{4}", awsAccessKeyId, AWS4Signer.FormatDateTime(correctedUtcNowForEndpoint, "yyyyMMdd"), text2, service, "aws4_request");
			parametersToCanonicalize.Add(new KeyValuePair<string, string>("X-Amz-Credential", value));
			parametersToCanonicalize.Add(new KeyValuePair<string, string>("X-Amz-Date", AWS4Signer.FormatDateTime(correctedUtcNowForEndpoint, "yyyyMMddTHHmmssZ")));
			parametersToCanonicalize.Add(new KeyValuePair<string, string>("X-Amz-SignedHeaders", text3));
			string canonicalQueryString = AWS4Signer.CanonicalizeQueryParameters(parametersToCanonicalize);
			string text4 = AWS4Signer.CanonicalizeRequest(request.Endpoint, request.ResourcePath, request.HttpMethod, sortedHeaders, canonicalQueryString, (service == "s3") ? "UNSIGNED-PAYLOAD" : "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855", request.PathResources, request.MarshallerVersion, service);
			metrics?.AddProperty(Metric.CanonicalRequest, text4);
			return AWS4Signer.ComputeSignature(awsAccessKeyId, awsSecretAccessKey, text2, correctedUtcNowForEndpoint, service, text3, text4, metrics);
		}
	}
	public class AWS4SigningResult
	{
		private readonly string _awsAccessKeyId;

		private readonly DateTime _originalDateTime;

		private readonly string _signedHeaders;

		private readonly string _scope;

		private readonly byte[] _signingKey;

		private readonly byte[] _signature;

		public string AccessKeyId => _awsAccessKeyId;

		public string ISO8601DateTime => AWS4Signer.FormatDateTime(_originalDateTime, "yyyyMMddTHHmmssZ");

		public string ISO8601Date => AWS4Signer.FormatDateTime(_originalDateTime, "yyyyMMdd");

		public string SignedHeaders => _signedHeaders;

		public string Scope => _scope;

		public byte[] SigningKey
		{
			get
			{
				byte[] array = new byte[_signingKey.Length];
				_signingKey.CopyTo(array, 0);
				return array;
			}
		}

		public string Signature => AWSSDKUtils.ToHex(_signature, lowercase: true);

		public byte[] SignatureBytes
		{
			get
			{
				byte[] array = new byte[_signature.Length];
				_signature.CopyTo(array, 0);
				return array;
			}
		}

		public string ForAuthorizationHeader
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append("AWS4-HMAC-SHA256");
				stringBuilder.AppendFormat(" {0}={1}/{2},", "Credential", AccessKeyId, Scope);
				stringBuilder.AppendFormat(" {0}={1},", "SignedHeaders", SignedHeaders);
				stringBuilder.AppendFormat(" {0}={1}", "Signature", Signature);
				return stringBuilder.ToString();
			}
		}

		public string ForQueryParameters
		{
			get
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendFormat("{0}={1}", "X-Amz-Algorithm", "AWS4-HMAC-SHA256");
				stringBuilder.AppendFormat("&{0}={1}", "X-Amz-Credential", string.Format(CultureInfo.InvariantCulture, "{0}/{1}", AccessKeyId, Scope));
				stringBuilder.AppendFormat("&{0}={1}", "X-Amz-Date", ISO8601DateTime);
				stringBuilder.AppendFormat("&{0}={1}", "X-Amz-SignedHeaders", SignedHeaders);
				stringBuilder.AppendFormat("&{0}={1}", "X-Amz-Signature", Signature);
				return stringBuilder.ToString();
			}
		}

		public AWS4SigningResult(string awsAccessKeyId, DateTime signedAt, string signedHeaders, string scope, byte[] signingKey, byte[] signature)
		{
			_awsAccessKeyId = awsAccessKeyId;
			_originalDateTime = signedAt;
			_signedHeaders = signedHeaders;
			_scope = scope;
			_signingKey = signingKey;
			_signature = signature;
		}
	}
	public class CloudFrontSigner : AbstractAWSSigner
	{
		public override ClientProtocol Protocol => ClientProtocol.RestProtocol;

		public override void Sign(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, string awsAccessKeyId, string awsSecretAccessKey)
		{
			if (string.IsNullOrEmpty(awsAccessKeyId))
			{
				throw new ArgumentOutOfRangeException("awsAccessKeyId", "The AWS Access Key ID cannot be NULL or a Zero length string");
			}
			string formattedTimestampRFC = AWSSDKUtils.GetFormattedTimestampRFC822(0);
			request.Headers.Add("X-Amz-Date", formattedTimestampRFC);
			string text = AbstractAWSSigner.ComputeHash(formattedTimestampRFC, awsSecretAccessKey, SigningAlgorithm.HmacSHA1);
			request.Headers.Add("Authorization", "AWS " + awsAccessKeyId + ":" + text);
		}
	}
	public class NullSigner : AbstractAWSSigner
	{
		public override ClientProtocol Protocol => ClientProtocol.Unknown;

		public override void Sign(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, string awsAccessKeyId, string awsSecretAccessKey)
		{
		}
	}
	public class QueryStringSigner : AbstractAWSSigner
	{
		private const string SignatureVersion2 = "2";

		public override ClientProtocol Protocol => ClientProtocol.QueryStringProtocol;

		public override void Sign(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, string awsAccessKeyId, string awsSecretAccessKey)
		{
			if (string.IsNullOrEmpty(awsAccessKeyId))
			{
				throw new ArgumentOutOfRangeException("awsAccessKeyId", "The AWS Access Key ID cannot be NULL or a Zero length string");
			}
			request.Parameters["AWSAccessKeyId"] = awsAccessKeyId;
			request.Parameters["SignatureVersion"] = "2";
			request.Parameters["SignatureMethod"] = clientConfig.SignatureMethod.ToString();
			request.Parameters["Timestamp"] = AWSSDKUtils.GetFormattedTimestampISO8601(clientConfig);
			request.Parameters.Remove("Signature");
			string text = AWSSDKUtils.CalculateStringToSignV2(request.ParameterCollection, request.Endpoint.AbsoluteUri);
			metrics.AddProperty(Metric.StringToSign, text);
			string value = AbstractAWSSigner.ComputeHash(text, awsSecretAccessKey, clientConfig.SignatureMethod);
			request.Parameters["Signature"] = value;
		}
	}
	public class S3Signer : AbstractAWSSigner
	{
		public delegate void RegionDetectionUpdater(IRequest request);

		private readonly bool _useSigV4;

		private readonly RegionDetectionUpdater _regionDetector;

		private static readonly HashSet<string> SignableParameters = new HashSet<string>(new string[6] { "response-content-type", "response-content-language", "response-expires", "response-cache-control", "response-content-disposition", "response-content-encoding" }, StringComparer.OrdinalIgnoreCase);

		private static readonly HashSet<string> SubResourcesSigningExclusion = new HashSet<string>(new string[1] { "id" }, StringComparer.OrdinalIgnoreCase);

		public override ClientProtocol Protocol => ClientProtocol.RestProtocol;

		public S3Signer()
			: this(useSigV4: true, null)
		{
		}

		public S3Signer(bool useSigV4, RegionDetectionUpdater regionDetector)
		{
			_useSigV4 = useSigV4;
			_regionDetector = regionDetector;
		}

		public override void Sign(IRequest request, IClientConfig clientConfig, RequestMetrics metrics, string awsAccessKeyId, string awsSecretAccessKey)
		{
			if (SelectSigner(this, _useSigV4, request, clientConfig) is AWS4Signer aWS4Signer)
			{
				_regionDetector?.Invoke(request);
				AWS4SigningResult aWS4SigningResult = aWS4Signer.SignRequest(request, clientConfig, metrics, awsAccessKeyId, awsSecretAccessKey);
				request.Headers["Authorization"] = aWS4SigningResult.ForAuthorizationHeader;
				if (request.UseChunkEncoding)
				{
					request.AWS4SignerResult = aWS4SigningResult;
				}
			}
			else
			{
				SignRequest(request, metrics, awsAccessKeyId, awsSecretAccessKey);
			}
		}

		public static void SignRequest(IRequest request, RequestMetrics metrics, string awsAccessKeyId, string awsSecretAccessKey)
		{
			request.Headers["X-Amz-Date"] = AWSSDKUtils.FormattedCurrentTimestampRFC822;
			string text = BuildStringToSign(request);
			metrics.AddProperty(Metric.StringToSign, text);
			string text2 = CryptoUtilFactory.CryptoInstance.HMACSign(text, awsSecretAccessKey, SigningAlgorithm.HmacSHA1);
			string value = "AWS " + awsAccessKeyId + ":" + text2;
			request.Headers["Authorization"] = value;
		}

		private static string BuildStringToSign(IRequest request)
		{
			StringBuilder stringBuilder = new StringBuilder("", 256);
			stringBuilder.Append(request.HttpMethod);
			stringBuilder.Append("\n");
			IDictionary<string, string> headers = request.Headers;
			IDictionary<string, string> parameters = request.Parameters;
			if (headers != null)
			{
				string text = null;
				if (headers.ContainsKey("Content-MD5") && !string.IsNullOrEmpty(text = headers["Content-MD5"]))
				{
					stringBuilder.Append(text);
				}
				stringBuilder.Append("\n");
				if (parameters.ContainsKey("ContentType"))
				{
					stringBuilder.Append(parameters["ContentType"]);
				}
				else if (headers.ContainsKey("Content-Type"))
				{
					stringBuilder.Append(headers["Content-Type"]);
				}
				stringBuilder.Append("\n");
			}
			else
			{
				stringBuilder.Append("\n\n");
			}
			if (parameters.ContainsKey("Expires"))
			{
				stringBuilder.Append(parameters["Expires"]);
				headers?.Remove("X-Amz-Date");
			}
			IDictionary<string, string> dictionary = new Dictionary<string, string>(headers);
			foreach (KeyValuePair<string, string> item in parameters)
			{
				if (!dictionary.ContainsKey(item.Key))
				{
					dictionary.Add(item.Key, item.Value);
				}
			}
			stringBuilder.Append("\n");
			stringBuilder.Append(BuildCanonicalizedHeaders(dictionary));
			string value = BuildCanonicalizedResource(request);
			if (!string.IsNullOrEmpty(value))
			{
				stringBuilder.Append(value);
			}
			return stringBuilder.ToString();
		}

		private static string BuildCanonicalizedHeaders(IDictionary<string, string> headers)
		{
			StringBuilder stringBuilder = new StringBuilder(256);
			foreach (string item in headers.Keys.OrderBy((string x) => x, StringComparer.OrdinalIgnoreCase))
			{
				string text = item.ToLowerInvariant();
				if (text.StartsWith("x-amz-", StringComparison.Ordinal))
				{
					stringBuilder.Append(text + ":" + headers[item] + "\n");
				}
			}
			return stringBuilder.ToString();
		}

		private static string BuildCanonicalizedResource(IRequest request)
		{
			StringBuilder stringBuilder = new StringBuilder(request.CanonicalResourcePrefix);
			stringBuilder.Append(string.IsNullOrEmpty(request.ResourcePath) ? "/" : ((request.MarshallerVersion >= 2) ? AWSSDKUtils.ResolveResourcePath(request.ResourcePath, request.PathResources) : AWSSDKUtils.UrlEncode(request.ResourcePath, path: true)));
			Dictionary<string, string> dictionary = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);
			if (request.SubResources.Count > 0)
			{
				foreach (KeyValuePair<string, string> subResource in request.SubResources)
				{
					if (!SubResourcesSigningExclusion.Contains(subResource.Key))
					{
						dictionary.Add(subResource.Key, subResource.Value);
					}
				}
			}
			if (request.Parameters.Count > 0)
			{
				foreach (KeyValuePair<string, string> sortedParameters in request.ParameterCollection.GetSortedParametersList())
				{
					if (sortedParameters.Value != null && SignableParameters.Contains(sortedParameters.Key))
					{
						dictionary.Add(sortedParameters.Key, sortedParameters.Value);
					}
				}
			}
			string arg = "?";
			List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>();
			foreach (KeyValuePair<string, string> item in dictionary)
			{
				list.Add(item);
			}
			list.Sort((KeyValuePair<string, string> firstPair, KeyValuePair<string, string> nextPair) => string.CompareOrdinal(firstPair.Key, nextPair.Key));
			foreach (KeyValuePair<string, string> item2 in list)
			{
				stringBuilder.AppendFormat("{0}{1}", arg, item2.Key);
				if (item2.Value != null)
				{
					stringBuilder.AppendFormat("={0}", item2.Value);
				}
				arg = "&";
			}
			return stringBuilder.ToString();
		}
	}
	public class SignatureException : Exception
	{
		public SignatureException(string message)
			: base(message)
		{
		}

		public SignatureException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
namespace Amazon.MissingTypes
{
	public interface ICloneable
	{
		object Clone();
	}
	public interface IOrderedDictionary : IDictionary, ICollection, IEnumerable
	{
		object this[int index] { get; set; }

		new IDictionaryEnumerator GetEnumerator();

		void Insert(int index, object key, object value);

		void RemoveAt(int index);
	}
}
namespace Amazon.Auth.AccessControlPolicy
{
	public class ActionIdentifier
	{
		private string actionName;

		public string ActionName
		{
			get
			{
				return actionName;
			}
			set
			{
				actionName = value;
			}
		}

		public ActionIdentifier(string actionName)
		{
			this.actionName = actionName;
		}
	}
	public class Condition
	{
		private string type;

		private string conditionKey;

		private string[] values;

		public string Type
		{
			get
			{
				return type;
			}
			set
			{
				type = value;
			}
		}

		public string ConditionKey
		{
			get
			{
				return conditionKey;
			}
			set
			{
				conditionKey = value;
			}
		}

		public string[] Values
		{
			get
			{
				return values;
			}
			set
			{
				values = value;
			}
		}

		public Condition()
		{
		}

		public Condition(string type, string conditionKey, params string[] values)
		{
			this.type = type;
			this.conditionKey = conditionKey;
			this.values = values;
		}
	}
	public static class ConditionFactory
	{
		public enum ArnComparisonType
		{
			ArnEquals,
			ArnLike,
			ArnNotEquals,
			ArnNotLike
		}

		public enum DateComparisonType
		{
			DateEquals,
			DateGreaterThan,
			DateGreaterThanEquals,
			DateLessThan,
			DateLessThanEquals,
			DateNotEquals
		}

		public enum IpAddressComparisonType
		{
			IpAddress,
			NotIpAddress
		}

		public enum NumericComparisonType
		{
			NumericEquals,
			NumericGreaterThan,
			NumericGreaterThanEquals,
			NumericLessThan,
			NumericLessThanEquals,
			NumericNotEquals
		}

		public enum StringComparisonType
		{
			StringEquals,
			StringEqualsIgnoreCase,
			StringLike,
			StringNotEquals,
			StringNotEqualsIgnoreCase,
			StringNotLike
		}

		public const string CURRENT_TIME_CONDITION_KEY = "aws:CurrentTime";

		public const string SECURE_TRANSPORT_CONDITION_KEY = "aws:SecureTransport";

		public const string SOURCE_IP_CONDITION_KEY = "aws:SourceIp";

		public const string USER_AGENT_CONDITION_KEY = "aws:UserAgent";

		public const string EPOCH_TIME_CONDITION_KEY = "aws:EpochTime";

		public const string REFERRER_CONDITION_KEY = "aws:Referer";

		public const string SOURCE_ARN_CONDITION_KEY = "aws:SourceArn";

		public const string S3_CANNED_ACL_CONDITION_KEY = "s3:x-amz-acl";

		public const string S3_LOCATION_CONSTRAINT_CONDITION_KEY = "s3:LocationConstraint";

		public const string S3_PREFIX_CONDITION_KEY = "s3:prefix";

		public const string S3_DELIMITER_CONDITION_KEY = "s3:delimiter";

		public const string S3_MAX_KEYS_CONDITION_KEY = "s3:max-keys";

		public const string S3_COPY_SOURCE_CONDITION_KEY = "s3:x-amz-copy-source";

		public const string S3_METADATA_DIRECTIVE_CONDITION_KEY = "s3:x-amz-metadata-directive";

		public const string S3_VERSION_ID_CONDITION_KEY = "s3:VersionId";

		public const string SNS_ENDPOINT_CONDITION_KEY = "sns:Endpoint";

		public const string SNS_PROTOCOL_CONDITION_KEY = "sns:Protocol";

		public static Condition NewCondition(ArnComparisonType type, string key, string value)
		{
			return new Condition(type.ToString(), key, value);
		}

		public static Condition NewCondition(string key, bool value)
		{
			return new Condition("Bool", key, value.ToString().ToLowerInvariant());
		}

		[Obsolete("Invoking this method results in non-UTC DateTimes not being marshalled correctly. Use NewConditionUtc instead.", false)]
		public static Condition NewCondition(DateComparisonType type, DateTime date)
		{
			return new Condition(type.ToString(), "aws:CurrentTime", date.ToString("yyyy-MM-dd\\THH:mm:ss.fff\\Z", CultureInfo.InvariantCulture));
		}

		public static Condition NewConditionUtc(DateComparisonType type, DateTime date)
		{
			return new Condition(type.ToString(), "aws:CurrentTime", date.ToUniversalTime().ToString("yyyy-MM-dd\\THH:mm:ss.fff\\Z", CultureInfo.InvariantCulture));
		}

		public static Condition NewIpAddressCondition(string ipAddressRange)
		{
			return NewCondition(IpAddressComparisonType.IpAddress, ipAddressRange);
		}

		public static Condition NewCondition(IpAddressComparisonType type, string ipAddressRange)
		{
			return new Condition(type.ToString(), "aws:SourceIp", ipAddressRange);
		}

		public static Condition NewCondition(NumericComparisonType type, string key, string value)
		{
			return new Condition(type.ToString(), key, value);
		}

		public static Condition NewCondition(StringComparisonType type, string key, string value)
		{
			return new Condition(type.ToString(), key, value);
		}

		public static Condition NewSourceArnCondition(string arnPattern)
		{
			return NewCondition(ArnComparisonType.ArnLike, "aws:SourceArn", arnPattern);
		}

		public static Condition NewSecureTransportCondition()
		{
			return NewCondition("aws:SecureTransport", value: true);
		}

		public static Condition NewCannedACLCondition(string cannedAcl)
		{
			return NewCondition(StringComparisonType.StringEquals, "s3:x-amz-acl", cannedAcl);
		}

		public static Condition NewEndpointCondition(string endpointPattern)
		{
			return NewCondition(StringComparisonType.StringLike, "sns:Endpoint", endpointPattern);
		}

		public static Condition NewProtocolCondition(string protocol)
		{
			return NewCondition(StringComparisonType.StringEquals, "sns:Protocol", protocol);
		}
	}
	public class Policy
	{
		private const string DEFAULT_POLICY_VERSION = "2012-10-17";

		private string id;

		private string version = "2012-10-17";

		private IList<Statement> statements = new List<Statement>();

		public string Id
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}

		public string Version
		{
			get
			{
				return version;
			}
			set
			{
				version = value;
			}
		}

		public IList<Statement> Statements
		{
			get
			{
				return statements;
			}
			set
			{
				statements = value;
			}
		}

		public Policy()
		{
		}

		public Policy(string id)
		{
			this.id = id;
		}

		public Policy(string id, IList<Statement> statements)
		{
			this.id = id;
			this.statements = statements;
		}

		public Policy WithId(string id)
		{
			Id = id;
			return this;
		}

		public bool CheckIfStatementExists(Statement statement)
		{
			if (Statements == null)
			{
				return false;
			}
			foreach (Statement statement2 in Statements)
			{
				if (statement2.Effect == statement.Effect && StatementContainsResources(statement2, statement.Resources) && StatementContainsActions(statement2, statement.Actions) && StatementContainsConditions(statement2, statement.Conditions) && StatementContainsPrincipals(statement2, statement.Principals))
				{
					return true;
				}
			}
			return false;
		}

		private static bool StatementContainsResources(Statement statement, IList<Resource> resources)
		{
			foreach (Resource resource in resources)
			{
				if (statement.Resources.FirstOrDefault((Resource x) => string.Equals(x.Id, resource.Id)) == null)
				{
					return false;
				}
			}
			return true;
		}

		private static bool StatementContainsActions(Statement statement, IList<ActionIdentifier> actions)
		{
			foreach (ActionIdentifier action in actions)
			{
				if (statement.Actions.FirstOrDefault((ActionIdentifier x) => string.Equals(x.ActionName, action.ActionName)) == null)
				{
					return false;
				}
			}
			return true;
		}

		private static bool StatementContainsConditions(Statement statement, IList<Condition> conditions)
		{
			foreach (Condition condition in conditions)
			{
				if (statement.Conditions.FirstOrDefault((Condition x) => string.Equals(x.Type, condition.Type) && string.Equals(x.ConditionKey, condition.ConditionKey) && x.Values.Intersect(condition.Values).Count() == condition.Values.Count()) == null)
				{
					return false;
				}
			}
			return true;
		}

		private static bool StatementContainsPrincipals(Statement statement, IList<Principal> principals)
		{
			foreach (Principal principal in principals)
			{
				if (statement.Principals.FirstOrDefault((Principal x) => string.Equals(x.Id, principal.Id) && string.Equals(x.Provider, principal.Provider)) == null)
				{
					return false;
				}
			}
			return true;
		}

		public Policy WithStatements(params Statement[] statements)
		{
			if (Statements == null)
			{
				Statements = new List<Statement>();
			}
			foreach (Statement item in statements)
			{
				Statements.Add(item);
			}
			return this;
		}

		public string ToJson()
		{
			return ToJson(prettyPrint: true);
		}

		public string ToJson(bool prettyPrint)
		{
			return JsonPolicyWriter.WritePolicyToString(prettyPrint, this);
		}

		public static Policy FromJson(string json)
		{
			return JsonPolicyReader.ReadJsonStringToPolicy(json);
		}
	}
	public class Principal
	{
		public static readonly Principal AllUsers = new Principal("*");

		public static readonly Principal Anonymous = new Principal("__ANONYMOUS__", "*");

		public const string AWS_PROVIDER = "AWS";

		public const string CANONICAL_USER_PROVIDER = "CanonicalUser";

		public const string FEDERATED_PROVIDER = "Federated";

		public const string SERVICE_PROVIDER = "Service";

		public const string ANONYMOUS_PROVIDER = "__ANONYMOUS__";

		private string id;

		private string provider;

		public string Provider
		{
			get
			{
				return provider;
			}
			set
			{
				provider = value;
			}
		}

		public string Id => id;

		public Principal(string accountId)
			: this("AWS", accountId)
		{
			if (accountId == null)
			{
				throw new ArgumentNullException("accountId");
			}
		}

		public Principal(string provider, string id)
			: this(provider, id, provider == "AWS")
		{
		}

		public Principal(string provider, string id, bool stripHyphen)
		{
			this.provider = provider;
			if (stripHyphen)
			{
				id = id.Replace("-", "");
			}
			this.id = id;
		}
	}
	public class Resource
	{
		private string resource;

		public string Id => resource;

		public Resource(string resource)
		{
			this.resource = resource;
		}
	}
	public static class ResourceFactory
	{
		public static Resource NewS3BucketResource(string bucketName)
		{
			if (bucketName == null)
			{
				throw new ArgumentNullException("bucketName");
			}
			return new Resource("arn:aws:s3:::" + bucketName);
		}

		public static Resource NewS3ObjectResource(string bucketName, string keyPattern)
		{
			if (bucketName == null)
			{
				throw new ArgumentNullException("bucketName");
			}
			if (keyPattern == null)
			{
				throw new ArgumentNullException("keyPattern");
			}
			return new Resource(string.Format(CultureInfo.InvariantCulture, "arn:aws:s3:::{0}/{1}", bucketName, keyPattern));
		}

		public static Resource NewSQSQueueResource(string accountId, string queueName)
		{
			return new Resource("/" + FormatAccountId(accountId) + "/" + queueName);
		}

		private static string FormatAccountId(string accountId)
		{
			if (accountId == null)
			{
				throw new ArgumentNullException("accountId");
			}
			return accountId.Trim().Replace("-", "");
		}
	}
	public class Statement
	{
		public enum StatementEffect
		{
			Allow,
			Deny
		}

		private string id;

		private StatementEffect effect;

		private IList<Principal> principals = new List<Principal>();

		private IList<ActionIdentifier> actions = new List<ActionIdentifier>();

		private IList<Resource> resources = new List<Resource>();

		private IList<Condition> conditions = new List<Condition>();

		public string Id
		{
			get
			{
				return id;
			}
			set
			{
				id = value;
			}
		}

		public StatementEffect Effect
		{
			get
			{
				return effect;
			}
			set
			{
				effect = value;
			}
		}

		public IList<ActionIdentifier> Actions
		{
			get
			{
				return actions;
			}
			set
			{
				actions = value;
			}
		}

		public IList<Resource> Resources
		{
			get
			{
				return resources;
			}
			set
			{
				resources = value;
			}
		}

		public IList<Condition> Conditions
		{
			get
			{
				return conditions;
			}
			set
			{
				conditions = value;
			}
		}

		public IList<Principal> Principals
		{
			get
			{
				return principals;
			}
			set
			{
				principals = value;
			}
		}

		public Statement(StatementEffect effect)
		{
			this.effect = effect;
			id = Guid.NewGuid().ToString().Replace("-", "");
		}

		public Statement WithId(string id)
		{
			Id = id;
			return this;
		}

		public Statement WithActionIdentifiers(params ActionIdentifier[] actions)
		{
			if (this.actions == null)
			{
				this.actions = new List<ActionIdentifier>();
			}
			foreach (ActionIdentifier item in actions)
			{
				this.actions.Add(item);
			}
			return this;
		}

		public Statement WithResources(params Resource[] resources)
		{
			if (this.resources == null)
			{
				this.resources = new List<Resource>();
			}
			foreach (Resource item in resources)
			{
				this.resources.Add(item);
			}
			return this;
		}

		public Statement WithConditions(params Condition[] conditions)
		{
			if (Conditions == null)
			{
				Conditions = new List<Condition>();
			}
			foreach (Condition item in conditions)
			{
				Conditions.Add(item);
			}
			return this;
		}

		public Statement WithPrincipals(params Principal[] principals)
		{
			if (this.principals == null)
			{
				this.principals = new List<Principal>();
			}
			foreach (Principal item in principals)
			{
				this.principals.Add(item);
			}
			return this;
		}
	}
}
namespace Amazon.Auth.AccessControlPolicy.Internal
{
	internal static class JsonDocumentFields
	{
		internal const string VERSION = "Version";

		internal const string POLICY_ID = "Id";

		internal const string STATEMENT = "Statement";

		internal const string STATEMENT_EFFECT = "Effect";

		internal const string EFFECT_VALUE_ALLOW = "Allow";

		internal const string STATEMENT_ID = "Sid";

		internal const string PRINCIPAL = "Principal";

		internal const string ACTION = "Action";

		internal const string RESOURCE = "Resource";

		internal const string CONDITION = "Condition";
	}
	internal static class JsonPolicyReader
	{
		public static Policy ReadJsonStringToPolicy(string jsonString)
		{
			Policy policy = new Policy();
			JsonData jsonData = JsonMapper.ToObject(jsonString);
			if (jsonData["Id"] != null && jsonData["Id"].IsString)
			{
				policy.Id = (string)jsonData["Id"];
			}
			JsonData jsonData2 = jsonData["Statement"];
			if (jsonData2 != null && jsonData2.IsArray)
			{
				foreach (JsonData item in (IEnumerable)jsonData2)
				{
					Statement statement = convertStatement(item);
					if (statement != null)
					{
						policy.Statements.Add(statement);
					}
				}
			}
			return policy;
		}

		private static Statement convertStatement(JsonData jStatement)
		{
			if (jStatement["Effect"] == null || !jStatement["Effect"].IsString)
			{
				return null;
			}
			string value = (string)jStatement["Effect"];
			Statement.StatementEffect effect = ((!"Allow".Equals(value)) ? Statement.StatementEffect.Deny : Statement.StatementEffect.Allow);
			Statement statement = new Statement(effect);
			if (jStatement["Sid"] != null && jStatement["Sid"].IsString)
			{
				statement.Id = (string)jStatement["Sid"];
			}
			convertActions(statement, jStatement);
			convertResources(statement, jStatement);
			convertCondition(statement, jStatement);
			convertPrincipals(statement, jStatement);
			return statement;
		}

		private static void convertPrincipals(Statement statement, JsonData jStatement)
		{
			JsonData jsonData = jStatement["Principal"];
			if (jsonData == null)
			{
				return;
			}
			if (jsonData.IsObject)
			{
				convertPrincipalRecord(statement, jsonData);
				return;
			}
			if (jsonData.IsArray)
			{
				foreach (JsonData item in (IEnumerable)jsonData)
				{
					convertPrincipalRecord(statement, item);
				}
				return;
			}
			if (jsonData.IsString && jsonData.Equals("*"))
			{
				statement.Principals.Add(Principal.Anonymous);
			}
		}

		private static void convertPrincipalRecord(Statement statement, JsonData jPrincipal)
		{
			foreach (KeyValuePair<string, JsonData> item3 in (IEnumerable)jPrincipal)
			{
				if (item3.Value == null)
				{
					continue;
				}
				if (item3.Value.IsArray)
				{
					foreach (JsonData item4 in (IEnumerable)item3.Value)
					{
						if (item4.IsString)
						{
							Principal item = new Principal(item3.Key, (string)item4, stripHyphen: false);
							statement.Principals.Add(item);
						}
					}
				}
				else if (item3.Value.IsString)
				{
					Principal item2 = new Principal(item3.Key, (string)item3.Value, stripHyphen: false);
					statement.Principals.Add(item2);
				}
			}
		}

		private static void convertActions(Statement statement, JsonData jStatement)
		{
			JsonData jsonData = jStatement["Action"];
			if (jsonData == null)
			{
				return;
			}
			if (jsonData.IsString)
			{
				statement.Actions.Add(new ActionIdentifier((string)jsonData));
			}
			else
			{
				if (!jsonData.IsArray)
				{
					return;
				}
				foreach (JsonData item in (IEnumerable)jsonData)
				{
					if (item.IsString)
					{
						statement.Actions.Add(new ActionIdentifier((string)item));
					}
				}
			}
		}

		private static void convertResources(Statement statement, JsonData jStatement)
		{
			JsonData jsonData = jStatement["Resource"];
			if (jsonData == null)
			{
				return;
			}
			if (jsonData.IsString)
			{
				statement.Resources.Add(new Resource((string)jsonData));
			}
			else
			{
				if (!jsonData.IsArray)
				{
					return;
				}
				foreach (JsonData item in (IEnumerable)jsonData)
				{
					if (item.IsString)
					{
						statement.Resources.Add(new Resource((string)item));
					}
				}
			}
		}

		private static void convertCondition(Statement statement, JsonData jStatement)
		{
			JsonData jsonData = jStatement["Condition"];
			if (jsonData == null)
			{
				return;
			}
			if (jsonData.IsObject)
			{
				convertConditionRecord(statement, jsonData);
			}
			else
			{
				if (!jsonData.IsArray)
				{
					return;
				}
				foreach (JsonData item in (IEnumerable)jsonData)
				{
					convertConditionRecord(statement, item);
				}
			}
		}

		private static void convertConditionRecord(Statement statement, JsonData jCondition)
		{
			foreach (KeyValuePair<string, JsonData> item2 in (IEnumerable)jCondition)
			{
				string key = item2.Key;
				foreach (KeyValuePair<string, JsonData> item3 in (IEnumerable)item2.Value)
				{
					string key2 = item3.Key;
					List<string> list = new List<string>();
					if (item3.Value != null)
					{
						if (item3.Value.IsString)
						{
							list.Add((string)item3.Value);
						}
						else if (item3.Value.IsArray)
						{
							foreach (JsonData item4 in (IEnumerable)item3.Value)
							{
								if (item4.IsString)
								{
									list.Add((string)item4);
								}
							}
						}
					}
					Condition item = new Condition(key, key2, list.ToArray());
					statement.Conditions.Add(item);
				}
			}
		}
	}
	internal static class JsonPolicyWriter
	{
		public static string WritePolicyToString(bool prettyPrint, Policy policy)
		{
			if (policy == null)
			{
				throw new ArgumentNullException("policy");
			}
			StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
			try
			{
				JsonWriter jsonWriter = new JsonWriter(stringWriter);
				jsonWriter.IndentValue = 4;
				jsonWriter.PrettyPrint = prettyPrint;
				writePolicy(policy, jsonWriter);
				return stringWriter.ToString().Trim();
			}
			catch (Exception ex)
			{
				throw new ArgumentException("Unable to serialize policy to JSON string: " + ex.Message, ex);
			}
		}

		private static void writePolicy(Policy policy, JsonWriter generator)
		{
			generator.WriteObjectStart();
			writePropertyValue(generator, "Version", policy.Version);
			if (policy.Id != null)
			{
				writePropertyValue(generator, "Id", policy.Id);
			}
			generator.WritePropertyName("Statement");
			generator.WriteArrayStart();
			foreach (Statement statement in policy.Statements)
			{
				generator.WriteObjectStart();
				if (statement.Id != null)
				{
					writePropertyValue(generator, "Sid", statement.Id);
				}
				writePropertyValue(generator, "Effect", statement.Effect.ToString());
				writePrincipals(statement, generator);
				writeActions(statement, generator);
				writeResources(statement, generator);
				writeConditions(statement, generator);
				generator.WriteObjectEnd();
			}
			generator.WriteArrayEnd();
			generator.WriteObjectEnd();
		}

		private static void writePrincipals(Statement statement, JsonWriter generator)
		{
			IList<Principal> principals = statement.Principals;
			if (principals == null || principals.Count == 0)
			{
				return;
			}
			generator.WritePropertyName("Principal");
			if (principals.Count == 1 && principals[0] != null && principals[0].Provider.Equals("__ANONYMOUS__", StringComparison.Ordinal))
			{
				generator.Write("*");
				return;
			}
			generator.WriteObjectStart();
			Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
			foreach (Principal item in principals)
			{
				if (!dictionary.TryGetValue(item.Provider, out var value))
				{
					value = new List<string>();
					dictionary[item.Provider] = value;
				}
				value.Add(item.Id);
			}
			foreach (string key in dictionary.Keys)
			{
				generator.WritePropertyName(key);
				if (dictionary[key].Count > 1)
				{
					generator.WriteArrayStart();
				}
				foreach (string item2 in dictionary[key])
				{
					generator.Write(item2);
				}
				if (dictionary[key].Count > 1)
				{
					generator.WriteArrayEnd();
				}
			}
			generator.WriteObjectEnd();
		}

		private static void writeActions(Statement statement, JsonWriter generator)
		{
			IList<ActionIdentifier> actions = statement.Actions;
			if (actions == null || actions.Count == 0)
			{
				return;
			}
			generator.WritePropertyName("Action");
			if (actions.Count > 1)
			{
				generator.WriteArrayStart();
			}
			foreach (ActionIdentifier item in actions)
			{
				generator.Write(item.ActionName);
			}
			if (actions.Count > 1)
			{
				generator.WriteArrayEnd();
			}
		}

		private static void writeResources(Statement statement, JsonWriter generator)
		{
			IList<Resource> resources = statement.Resources;
			if (resources == null || resources.Count == 0)
			{
				return;
			}
			generator.WritePropertyName("Resource");
			if (resources.Count > 1)
			{
				generator.WriteArrayStart();
			}
			foreach (Resource item in resources)
			{
				generator.Write(item.Id);
			}
			if (resources.Count > 1)
			{
				generator.WriteArrayEnd();
			}
		}

		private static void writeConditions(Statement statement, JsonWriter generator)
		{
			IList<Condition> conditions = statement.Conditions;
			if (conditions == null || conditions.Count == 0)
			{
				return;
			}
			Dictionary<string, Dictionary<string, List<string>>> dictionary = sortConditionsByTypeAndKey(conditions);
			generator.WritePropertyName("Condition");
			generator.WriteObjectStart();
			foreach (KeyValuePair<string, Dictionary<string, List<string>>> item in dictionary)
			{
				generator.WritePropertyName(item.Key);
				generator.WriteObjectStart();
				foreach (KeyValuePair<string, List<string>> item2 in item.Value)
				{
					IList<string> value = item2.Value;
					if (value.Count == 0)
					{
						continue;
					}
					generator.WritePropertyName(item2.Key);
					if (value.Count > 1)
					{
						generator.WriteArrayStart();
					}
					if (value != null && value.Count != 0)
					{
						foreach (string item3 in value)
						{
							generator.Write(item3);
						}
					}
					if (value.Count > 1)
					{
						generator.WriteArrayEnd();
					}
				}
				generator.WriteObjectEnd();
			}
			generator.WriteObjectEnd();
		}

		private static Dictionary<string, Dictionary<string, List<string>>> sortConditionsByTypeAndKey(IList<Condition> conditions)
		{
			Dictionary<string, Dictionary<string, List<string>>> dictionary = new Dictionary<string, Dictionary<string, List<string>>>();
			foreach (Condition condition in conditions)
			{
				string type = condition.Type;
				string conditionKey = condition.ConditionKey;
				if (!dictionary.TryGetValue(type, out var value))
				{
					value = (dictionary[type] = new Dictionary<string, List<string>>());
				}
				if (!value.TryGetValue(conditionKey, out var value2))
				{
					value2 = (value[conditionKey] = new List<string>());
				}
				if (condition.Values != null)
				{
					string[] values = condition.Values;
					foreach (string item in values)
					{
						value2.Add(item);
					}
				}
			}
			return dictionary;
		}

		private static void writePropertyValue(JsonWriter generator, string propertyName, string value)
		{
			generator.WritePropertyName(propertyName);
			generator.Write(value);
		}
	}
}
namespace Amazon.Auth.AccessControlPolicy.ActionIdentifiers
{
	public static class AppStreamActionIdentifiers
	{
		public static readonly ActionIdentifier AllAppStreamActions = new ActionIdentifier("appstream:*");

		public static readonly ActionIdentifier CreateApplication = new ActionIdentifier("appstream:CreateApplication");

		public static readonly ActionIdentifier CreateSession = new ActionIdentifier("appstream:CreateSession");

		public static readonly ActionIdentifier DeleteApplication = new ActionIdentifier("appstream:DeleteApplication");

		public static readonly ActionIdentifier GetApiRoot = new ActionIdentifier("appstream:GetApiRoot");

		public static readonly ActionIdentifier GetApplication = new ActionIdentifier("appstream:GetApplication");

		public static readonly ActionIdentifier GetApplications = new ActionIdentifier("appstream:GetApplications");

		public static readonly ActionIdentifier GetApplicationError = new ActionIdentifier("appstream:GetApplicationError");

		public static readonly ActionIdentifier GetApplicationErrors = new ActionIdentifier("appstream:GetApplicationErrors");

		public static readonly ActionIdentifier GetApplicationStatus = new ActionIdentifier("appstream:GetApplicationStatus");

		public static readonly ActionIdentifier GetSession = new ActionIdentifier("appstream:GetSession");

		public static readonly ActionIdentifier GetSessions = new ActionIdentifier("appstream:GetSessions");

		public static readonly ActionIdentifier GetSessionStatus = new ActionIdentifier("appstream:GetSessionStatus");

		public static readonly ActionIdentifier UpdateApplication = new ActionIdentifier("appstream:UpdateApplication");

		public static readonly ActionIdentifier UpdateApplicationState = new ActionIdentifier("appstream:UpdateApplicationState");

		public static readonly ActionIdentifier UpdateSessionState = new ActionIdentifier("appstream:UpdateSessionState");
	}
	public static class AutoScalingActionIdentifiers
	{
		public static readonly ActionIdentifier AllAutoScalingActions = new ActionIdentifier("autoscaling:*");

		public static readonly ActionIdentifier CreateAutoScalingGroup = new ActionIdentifier("autoscaling:CreateAutoScalingGroup");

		public static readonly ActionIdentifier CreateLaunchConfiguration = new ActionIdentifier("autoscaling:CreateLaunchConfiguration");

		public static readonly ActionIdentifier CreateOrUpdateScalingTrigger = new ActionIdentifier("autoscaling:CreateOrUpdateScalingTrigger");

		public static readonly ActionIdentifier CreateOrUpdateTags = new ActionIdentifier("autoscaling:CreateOrUpdateTags");

		public static readonly ActionIdentifier DeleteAutoScalingGroup = new ActionIdentifier("autoscaling:DeleteAutoScalingGroup");

		public static readonly ActionIdentifier DeleteLaunchConfiguration = new ActionIdentifier("autoscaling:DeleteLaunchConfiguration");

		public static readonly ActionIdentifier DeleteNotificationConfiguration = new ActionIdentifier("autoscaling:DeleteNotificationConfiguration");

		public static readonly ActionIdentifier DeletePolicy = new ActionIdentifier("autoscaling:DeletePolicy");

		public static readonly ActionIdentifier DeleteScheduledAction = new ActionIdentifier("autoscaling:DeleteScheduledAction");

		public static readonly ActionIdentifier DeleteTags = new ActionIdentifier("autoscaling:DeleteTags");

		public static readonly ActionIdentifier DeleteTrigger = new ActionIdentifier("autoscaling:DeleteTrigger");

		public static readonly ActionIdentifier DescribeAdjustmentTypes = new ActionIdentifier("autoscaling:DescribeAdjustmentTypes");

		public static readonly ActionIdentifier DescribeAutoScalingGroups = new ActionIdentifier("autoscaling:DescribeAutoScalingGroups");

		public static readonly ActionIdentifier DescribeAutoScalingInstances = new ActionIdentifier("autoscaling:DescribeAutoScalingInstances");

		public static readonly ActionIdentifier DescribeAutoScalingNotificationTypes = new ActionIdentifier("autoscaling:DescribeAutoScalingNotificationTypes");

		public static readonly ActionIdentifier DescribeLaunchConfigurations = new ActionIdentifier("autoscaling:DescribeLaunchConfigurations");

		public static readonly ActionIdentifier DescribeMetricCollectionTypes = new ActionIdentifier("autoscaling:DescribeMetricCollectionTypes");

		public static readonly ActionIdentifier DescribeNotificationConfigurations = new ActionIdentifier("autoscaling:DescribeNotificationConfigurations");

		public static readonly ActionIdentifier DescribePolicies = new ActionIdentifier("autoscaling:DescribePolicies");

		public static readonly ActionIdentifier DescribeScalingActivities = new ActionIdentifier("autoscaling:DescribeScalingActivities");

		public static readonly ActionIdentifier DescribeScalingProcessTypes = new ActionIdentifier("autoscaling:DescribeScalingProcessTypes");

		public static readonly ActionIdentifier DescribeScheduledActions = new ActionIdentifier("autoscaling:DescribeScheduledActions");

		public static readonly ActionIdentifier DescribeTags = new ActionIdentifier("autoscaling:DescribeTags");

		public static readonly ActionIdentifier DescribeTriggers = new ActionIdentifier("autoscaling:DescribeTriggers");

		public static readonly ActionIdentifier DisableMetricsCollection = new ActionIdentifier("autoscaling:DisableMetricsCollection");

		public static readonly ActionIdentifier EnableMetricsCollection = new ActionIdentifier("autoscaling:EnableMetricsCollection");

		public static readonly ActionIdentifier ExecutePolicy = new ActionIdentifier("autoscaling:ExecutePolicy");

		public static readonly ActionIdentifier PutNotificationConfiguration = new ActionIdentifier("autoscaling:PutNotificationConfiguration");

		public static readonly ActionIdentifier PutScalingPolicy = new ActionIdentifier("autoscaling:PutScalingPolicy");

		public static readonly ActionIdentifier PutScheduledUpdateGroupAction = new ActionIdentifier("autoscaling:PutScheduledUpdateGroupAction");

		public static readonly ActionIdentifier ResumeProcesses = new ActionIdentifier("autoscaling:ResumeProcesses");

		public static readonly ActionIdentifier SetDesiredCapacity = new ActionIdentifier("autoscaling:SetDesiredCapacity");

		public static readonly ActionIdentifier SetInstanceHealth = new ActionIdentifier("autoscaling:SetInstanceHealth");

		public static readonly ActionIdentifier SuspendProcesses = new ActionIdentifier("autoscaling:SuspendProcesses");

		public static readonly ActionIdentifier TerminateInstanceInAutoScalingGroup = new ActionIdentifier("autoscaling:TerminateInstanceInAutoScalingGroup");

		public static readonly ActionIdentifier UpdateAutoScalingGroup = new ActionIdentifier("autoscaling:UpdateAutoScalingGroup");
	}
	public static class BillingActionIdentifiers
	{
		public static readonly ActionIdentifier AllBillingActions = new ActionIdentifier("aws-portal:*");

		public static readonly ActionIdentifier ModifyAccount = new ActionIdentifier("aws-portal:ModifyAccount");

		public static readonly ActionIdentifier ModifyBilling = new ActionIdentifier("aws-portal:ModifyBilling");

		public static readonly ActionIdentifier ModifyPaymentMethods = new ActionIdentifier("aws-portal:ModifyPaymentMethods");

		public static readonly ActionIdentifier ViewAccount = new ActionIdentifier("aws-portal:ViewAccount");

		public static readonly ActionIdentifier ViewBilling = new ActionIdentifier("aws-portal:ViewBilling");

		public static readonly ActionIdentifier ViewPaymentMethods = new ActionIdentifier("aws-portal:ViewPaymentMethods");

		public static readonly ActionIdentifier ViewUsage = new ActionIdentifier("aws-portal:ViewUsage");
	}
	public static class CloudFormationActionIdentifiers
	{
		public static readonly ActionIdentifier AllCloudFormationActions = new ActionIdentifier("cloudformation:*");

		public static readonly ActionIdentifier CreateStack = new ActionIdentifier("cloudformation:CreateStack");

		public static readonly ActionIdentifier DeleteStack = new ActionIdentifier("cloudformation:DeleteStack");

		public static readonly ActionIdentifier DescribeStackEvents = new ActionIdentifier("cloudformation:DescribeStackEvents");

		public static readonly ActionIdentifier DescribeStackResource = new ActionIdentifier("cloudformation:DescribeStackResource");

		public static readonly ActionIdentifier DescribeStackResources = new ActionIdentifier("cloudformation:DescribeStackResources");

		public static readonly ActionIdentifier DescribeStacks = new ActionIdentifier("cloudformation:DescribeStacks");

		public static readonly ActionIdentifier EstimateTemplateCost = new ActionIdentifier("cloudformation:EstimateTemplateCost");

		public static readonly ActionIdentifier GetTemplate = new ActionIdentifier("cloudformation:GetTemplate");

		public static readonly ActionIdentifier ListStacks = new ActionIdentifier("cloudformation:ListStacks");

		public static readonly ActionIdentifier ListStackResources = new ActionIdentifier("cloudformation:ListStackResources");

		public static readonly ActionIdentifier UpdateStack = new ActionIdentifier("cloudformation:UpdateStack");

		public static readonly ActionIdentifier ValidateTemplate = new ActionIdentifier("cloudformation:ValidateTemplate");
	}
	public static class CloudFrontActionIdentifiers
	{
		public static readonly ActionIdentifier AllCloudFrontActions = new ActionIdentifier("cloudfront:*");

		public static readonly ActionIdentifier CreateCloudFrontOriginAccessIdentity = new ActionIdentifier("cloudfront:CreateCloudFrontOriginAccessIdentity");

		public static readonly ActionIdentifier CreateDistribution = new ActionIdentifier("cloudfront:CreateDistribution");

		public static readonly ActionIdentifier CreateInvalidation = new ActionIdentifier("cloudfront:CreateInvalidation");

		public static readonly ActionIdentifier CreateStreamingDistribution = new ActionIdentifier("cloudfront:CreateStreamingDistribution");

		public static readonly ActionIdentifier DeleteCloudFrontOriginAccessIdentity = new ActionIdentifier("cloudfront:DeleteCloudFrontOriginAccessIdentity");

		public static readonly ActionIdentifier DeleteDistribution = new ActionIdentifier("cloudfront:DeleteDistribution");

		public static readonly ActionIdentifier DeleteStreamingDistribution = new ActionIdentifier("cloudfront:DeleteStreamingDistribution");

		public static readonly ActionIdentifier GetCloudFrontOriginAccessIdentity = new ActionIdentifier("cloudfront:GetCloudFrontOriginAccessIdentity");

		public static readonly ActionIdentifier GetCloudFrontOriginAccessIdentityConfig = new ActionIdentifier("cloudfront:GetCloudFrontOriginAccessIdentityConfig");

		public static readonly ActionIdentifier GetDistribution = new ActionIdentifier("cloudfront:GetDistribution");

		public static readonly ActionIdentifier GetDistributionConfig = new ActionIdentifier("cloudfront:GetDistributionConfig");

		public static readonly ActionIdentifier GetInvalidation = new ActionIdentifier("cloudfront:GetInvalidation");

		public static readonly ActionIdentifier GetStreamingDistribution = new ActionIdentifier("cloudfront:GetStreamingDistribution");

		public static readonly ActionIdentifier GetStreamingDistributionConfig = new ActionIdentifier("cloudfront:GetStreamingDistributionConfig");

		public static readonly ActionIdentifier ListCloudFrontOriginAccessIdentities = new ActionIdentifier("cloudfront:ListCloudFrontOriginAccessIdentities");

		public static readonly ActionIdentifier ListDistributions = new ActionIdentifier("cloudfront:ListDistributions");

		public static readonly ActionIdentifier ListInvalidations = new ActionIdentifier("cloudfront:ListInvalidations");

		public static readonly ActionIdentifier ListStreamingDistributions = new ActionIdentifier("cloudfront:ListStreamingDistributions");

		public static readonly ActionIdentifier UpdateCloudFrontOriginAccessIdentity = new ActionIdentifier("cloudfront:UpdateCloudFrontOriginAccessIdentity");

		public static readonly ActionIdentifier UpdateDistribution = new ActionIdentifier("cloudfront:UpdateDistribution");

		public static readonly ActionIdentifier UpdateStreamingDistribution = new ActionIdentifier("cloudfront:UpdateStreamingDistribution");
	}
	public static class CloudSearchActionIdentifiers
	{
		public static readonly ActionIdentifier AllCloudSearchActions = new ActionIdentifier("cloudsearch:*");

		public static readonly ActionIdentifier BuildSuggesters = new ActionIdentifier("cloudsearch:BuildSuggesters");

		public static readonly ActionIdentifier CreateDomain = new ActionIdentifier("cloudsearch:CreateDomain");

		public static readonly ActionIdentifier DefineAnalysisScheme = new ActionIdentifier("cloudsearch:DefineAnalysisScheme");

		public static readonly ActionIdentifier DefineExpression = new ActionIdentifier("cloudsearch:DefineExpression");

		public static readonly ActionIdentifier DefineIndexField = new ActionIdentifier("cloudsearch:DefineIndexField");

		public static readonly ActionIdentifier DefineSuggester = new ActionIdentifier("cloudsearch:DefineSuggester");

		public static readonly ActionIdentifier DeleteAnalysisScheme = new ActionIdentifier("cloudsearch:DeleteAnalysisScheme");

		public static readonly ActionIdentifier DeleteDomain = new ActionIdentifier("cloudsearch:DeleteDomain");

		public static readonly ActionIdentifier DeleteExpression = new ActionIdentifier("cloudsearch:DeleteExpression");

		public static readonly ActionIdentifier DeleteIndexField = new ActionIdentifier("cloudsearch:DeleteIndexField");

		public static readonly ActionIdentifier DeleteSuggester = new ActionIdentifier("cloudsearch:DeleteSuggester");

		public static readonly ActionIdentifier DescribeAnalysisSchemes = new ActionIdentifier("cloudsearch:DescribeAnalysisSchemes");

		public static readonly ActionIdentifier DescribeAvailabilityOptions = new ActionIdentifier("cloudsearch:DescribeAvailabilityOptions");

		public static readonly ActionIdentifier DescribeDomains = new ActionIdentifier("cloudsearch:DescribeDomains");

		public static readonly ActionIdentifier DescribeExpressions = new ActionIdentifier("cloudsearch:DescribeExpressions");

		public static readonly ActionIdentifier DescribeIndexFields = new ActionIdentifier("cloudsearch:DescribeIndexFields");

		public static readonly ActionIdentifier DescribeScalingParameters = new ActionIdentifier("cloudsearch:DescribeScalingParameters");

		public static readonly ActionIdentifier DescribeServiceAccessPolicies = new ActionIdentifier("cloudsearch:DescribeServiceAccessPolicies");

		public static readonly ActionIdentifier DescribeSuggesters = new ActionIdentifier("cloudsearch:DescribeSuggesters");

		public static readonly ActionIdentifier IndexDocuments = new ActionIdentifier("cloudsearch:IndexDocuments");

		public static readonly ActionIdentifier ListDomainNames = new ActionIdentifier("cloudsearch:ListDomainNames");

		public static readonly ActionIdentifier UpdateAvailabilityOptions = new ActionIdentifier("cloudsearch:UpdateAvailabilityOptions");

		public static readonly ActionIdentifier UpdateScalingParameters = new ActionIdentifier("cloudsearch:UpdateScalingParameters");

		public static readonly ActionIdentifier UpdateServiceAccessPolicies = new ActionIdentifier("cloudsearch:UpdateServiceAccessPolicies");
	}
	public static class CloudTrailActionIdentifiers
	{
		public static readonly ActionIdentifier AllCloudTrailActions = new ActionIdentifier("cloudtrail:*");

		public static readonly ActionIdentifier CreateTrail = new ActionIdentifier("cloudtrail:CreateTrail");

		public static readonly ActionIdentifier DeleteTrail = new ActionIdentifier("cloudtrail:DeleteTrail");

		public static readonly ActionIdentifier DescribeTrails = new ActionIdentifier("cloudtrail:DescribeTrails");

		public static readonly ActionIdentifier GetTrailStatus = new ActionIdentifier("cloudtrail:GetTrailStatus");

		public static readonly ActionIdentifier StartLogging = new ActionIdentifier("cloudtrail:StartLogging");

		public static readonly ActionIdentifier StopLogging = new ActionIdentifier("cloudtrail:StopLogging");

		public static readonly ActionIdentifier UpdateTrail = new ActionIdentifier("cloudtrail:UpdateTrail");
	}
	public static class CloudWatchActionIdentifiers
	{
		public static readonly ActionIdentifier AllCloudWatchActions = new ActionIdentifier("cloudwatch:*");

		public static readonly ActionIdentifier DeleteAlarms = new ActionIdentifier("cloudwatch:DeleteAlarms");

		public static readonly ActionIdentifier DescribeAlarmHistory = new ActionIdentifier("cloudwatch:DescribeAlarmHistory");

		public static readonly ActionIdentifier DescribeAlarms = new ActionIdentifier("cloudwatch:DescribeAlarms");

		public static readonly ActionIdentifier DescribeAlarmsForMetric = new ActionIdentifier("cloudwatch:DescribeAlarmsForMetric");

		public static readonly ActionIdentifier DisableAlarmActions = new ActionIdentifier("cloudwatch:DisableAlarmActions");

		public static readonly ActionIdentifier EnableAlarmActions = new ActionIdentifier("cloudwatch:EnableAlarmActions");

		public static readonly ActionIdentifier GetMetricStatistics = new ActionIdentifier("cloudwatch:GetMetricStatistics");

		public static readonly ActionIdentifier ListMetrics = new ActionIdentifier("cloudwatch:ListMetrics");

		public static readonly ActionIdentifier PutMetricAlarm = new ActionIdentifier("cloudwatch:PutMetricAlarm");

		public static readonly ActionIdentifier PutMetricData = new ActionIdentifier("cloudwatch:PutMetricData");

		public static readonly ActionIdentifier SetAlarmState = new ActionIdentifier("cloudwatch:SetAlarmState");
	}
	public static class CloudWatchLogsActionIdentifiers
	{
		public static readonly ActionIdentifier AllCloudWatchLogsActions = new ActionIdentifier("logs:*");

		public static readonly ActionIdentifier CreateLogGroup = new ActionIdentifier("logs:CreateLogGroup");

		public static readonly ActionIdentifier CreateLogStream = new ActionIdentifier("logs:CreateLogStream");

		public static readonly ActionIdentifier DeleteLogGroup = new ActionIdentifier("logs:DeleteLogGroup");

		public static readonly ActionIdentifier DeleteLogStream = new ActionIdentifier("logs:DeleteLogStream");

		public static readonly ActionIdentifier DeleteMetricFilter = new ActionIdentifier("logs:DeleteMetricFilter");

		public static readonly ActionIdentifier DeleteRetentionPolicy = new ActionIdentifier("logs:DeleteRetentionPolicy");

		public static readonly ActionIdentifier DescribeLogGroups = new ActionIdentifier("logs:DescribeLogGroups");

		public static readonly ActionIdentifier DescribeLogStreams = new ActionIdentifier("logs:DescribeLogStreams");

		public static readonly ActionIdentifier DescribeMetricFilters = new ActionIdentifier("logs:DescribeMetricFilters");

		public static readonly ActionIdentifier GetLogEvents = new ActionIdentifier("logs:GetLogEvents");

		public static readonly ActionIdentifier PutLogEvents = new ActionIdentifier("logs:PutLogEvents");

		public static readonly ActionIdentifier PutMetricFilter = new ActionIdentifier("logs:PutMetricFilter");

		public static readonly ActionIdentifier PutRetentionPolicy = new ActionIdentifier("logs:PutRetentionPolicy");

		public static readonly ActionIdentifier TestMetricFilter = new ActionIdentifier("logs:TestMetricFilter");
	}
	public static class CognitoIdentityActionIdentifiers
	{
		public static readonly ActionIdentifier AllCognitoIdentityActions = new ActionIdentifier("cognito-identity:*");

		public static readonly ActionIdentifier CreateIdentityPool = new ActionIdentifier("cognito-identity:CreateIdentityPool");

		public static readonly ActionIdentifier DeleteIdentityPool = new ActionIdentifier("cognito-identity:DeleteIdentityPool");

		public static readonly ActionIdentifier DescribeIdentityPool = new ActionIdentifier("cognito-identity:DescribeIdentityPool");

		public static readonly ActionIdentifier ListIdentities = new ActionIdentifier("cognito-identity:ListIdentities");

		public static readonly ActionIdentifier ListIdentityPools = new ActionIdentifier("cognito-identity:ListIdentityPools");

		public static readonly ActionIdentifier UpdateIdentityPool = new ActionIdentifier("cognito-identity:UpdateIdentityPool");
	}
	public static class CognitoSyncActionIdentifiers
	{
		public static readonly ActionIdentifier AllCognitoSyncActions = new ActionIdentifier("cognito-sync:*");

		public static readonly ActionIdentifier DeleteDataset = new ActionIdentifier("cognito-sync:DeleteDataset");

		public static readonly ActionIdentifier DescribeDataset = new ActionIdentifier("cognito-sync:DescribeDataset");

		public static readonly ActionIdentifier DescribeIdentityUsage = new ActionIdentifier("cognito-sync:DescribeIdentityUsage");

		public static readonly ActionIdentifier DescribeIdentityPoolUsage = new ActionIdentifier("cognito-sync:DescribeIdentityPoolUsage");

		public static readonly ActionIdentifier ListDatasets = new ActionIdentifier("cognito-sync:ListDatasets");

		public static readonly ActionIdentifier ListIdentityPoolUsage = new ActionIdentifier("cognito-sync:ListIdentityPoolUsage");

		public static readonly ActionIdentifier ListRecords = new ActionIdentifier("cognito-sync:ListRecords");

		public static readonly ActionIdentifier UpdateRecords = new ActionIdentifier("cognito-sync:UpdateRecords");
	}
	public static class DirectConnectActionIdentifiers
	{
		public static readonly ActionIdentifier AllDirectConnectActions = new ActionIdentifier("directconnect:*");

		public static readonly ActionIdentifier CreateConnection = new ActionIdentifier("directconnect:CreateConnection");

		public static readonly ActionIdentifier CreatePrivateVirtualInterface = new ActionIdentifier("directconnect:CreatePrivateVirtualInterface");

		public static readonly ActionIdentifier CreatePublicVirtualInterface = new ActionIdentifier("directconnect:CreatePublicVirtualInterface");

		public static readonly ActionIdentifier DeleteConnection = new ActionIdentifier("directconnect:DeleteConnection");

		public static readonly ActionIdentifier DeleteVirtualInterface = new ActionIdentifier("directconnect:DeleteVirtualInterface");

		public static readonly ActionIdentifier DescribeConnectionDetail = new ActionIdentifier("directconnect:DescribeConnectionDetail");

		public static readonly ActionIdentifier DescribeConnections = new ActionIdentifier("directconnect:DescribeConnections");

		public static readonly ActionIdentifier DescribeOfferingDetail = new ActionIdentifier("directconnect:DescribeOfferingDetail");

		public static readonly ActionIdentifier DescribeOfferings = new ActionIdentifier("directconnect:DescribeOfferings");

		public static readonly ActionIdentifier DescribeVirtualGateways = new ActionIdentifier("directconnect:DescribeVirtualGateways");

		public static readonly ActionIdentifier DescribeVirtualInterfaces = new ActionIdentifier("directconnect:DescribeVirtualInterfaces");
	}
	public static class DynamoDBActionIdentifiers
	{
		public static readonly ActionIdentifier AllDynamoDBActions = new ActionIdentifier("dynamodb:*");

		public static readonly ActionIdentifier BatchGetItem = new ActionIdentifier("dynamodb:BatchGetItem");

		public static readonly ActionIdentifier BatchWriteItem = new ActionIdentifier("dynamodb:BatchWriteItem");

		public static readonly ActionIdentifier CreateTable = new ActionIdentifier("dynamodb:CreateTable");

		public static readonly ActionIdentifier DeleteItem = new ActionIdentifier("dynamodb:DeleteItem");

		public static readonly ActionIdentifier DeleteTable = new ActionIdentifier("dynamodb:DeleteTable");

		public static readonly ActionIdentifier DescribeTable = new ActionIdentifier("dynamodb:DescribeTable");

		public static readonly ActionIdentifier GetItem = new ActionIdentifier("dynamodb:GetItem");

		public static readonly ActionIdentifier ListTables = new ActionIdentifier("dynamodb:ListTables");

		public static readonly ActionIdentifier PutItem = new ActionIdentifier("dynamodb:PutItem");

		public static readonly ActionIdentifier Query = new ActionIdentifier("dynamodb:Query");

		public static readonly ActionIdentifier Scan = new ActionIdentifier("dynamodb:Scan");

		public static readonly ActionIdentifier UpdateItem = new ActionIdentifier("dynamodb:UpdateItem");

		public static readonly ActionIdentifier UpdateTable = new ActionIdentifier("dynamodb:UpdateTable");
	}
	public static class EC2ActionIdentifiers
	{
		public static readonly ActionIdentifier AllEC2Actions = new ActionIdentifier("ec2:*");

		public static readonly ActionIdentifier AcceptVpcPeeringConnection = new ActionIdentifier("ec2:AcceptVpcPeeringConnection");

		public static readonly ActionIdentifier ActivateLicense = new ActionIdentifier("ec2:ActivateLicense");

		public static readonly ActionIdentifier AllocateAddress = new ActionIdentifier("ec2:AllocateAddress");

		public static readonly ActionIdentifier AssignPrivateIpAddresses = new ActionIdentifier("ec2:AssignPrivateIpAddresses");

		public static readonly ActionIdentifier AssociateAddress = new ActionIdentifier("ec2:AssociateAddress");

		public static readonly ActionIdentifier AssociateDhcpOptions = new ActionIdentifier("ec2:AssociateDhcpOptions");

		public static readonly ActionIdentifier AssociateRouteTable = new ActionIdentifier("ec2:AssociateRouteTable");

		public static readonly ActionIdentifier AttachInternetGateway = new ActionIdentifier("ec2:AttachInternetGateway");

		public static readonly ActionIdentifier AttachNetworkInterface = new ActionIdentifier("ec2:AttachNetworkInterface");

		public static readonly ActionIdentifier AttachVolume = new ActionIdentifier("ec2:AttachVolume");

		public static readonly ActionIdentifier AttachVpnGateway = new ActionIdentifier("ec2:AttachVpnGateway");

		public static readonly ActionIdentifier AuthorizeSecurityGroupEgress = new ActionIdentifier("ec2:AuthorizeSecurityGroupEgress");

		public static readonly ActionIdentifier AuthorizeSecurityGroupIngress = new ActionIdentifier("ec2:AuthorizeSecurityGroupIngress");

		public static readonly ActionIdentifier BundleInstance = new ActionIdentifier("ec2:BundleInstance");

		public static readonly ActionIdentifier CancelBundleTask = new ActionIdentifier("ec2:CancelBundleTask");

		public static readonly ActionIdentifier CancelConversionTask = new ActionIdentifier("ec2:CancelConversionTask");

		public static readonly ActionIdentifier CancelExportTask = new ActionIdentifier("ec2:CancelExportTask");

		public static readonly ActionIdentifier CancelReservedInstancesListing = new ActionIdentifier("ec2:CancelReservedInstancesListing");

		public static readonly ActionIdentifier CancelSpotInstanceRequests = new ActionIdentifier("ec2:CancelSpotInstanceRequests");

		public static readonly ActionIdentifier ConfirmProductInstance = new ActionIdentifier("ec2:ConfirmProductInstance");

		public static readonly ActionIdentifier CopyImage = new ActionIdentifier("ec2:CopyImage");

		public static readonly ActionIdentifier CopySnapshot = new ActionIdentifier("ec2:CopySnapshot");

		public static readonly ActionIdentifier CreateCustomerGateway = new ActionIdentifier("ec2:CreateCustomerGateway");

		public static readonly ActionIdentifier CreateDhcpOptions = new ActionIdentifier("ec2:CreateDhcpOptions");

		public static readonly ActionIdentifier CreateImage = new ActionIdentifier("ec2:CreateImage");

		public static readonly ActionIdentifier CreateInstanceExportTask = new ActionIdentifier("ec2:CreateInstanceExportTask");

		public static readonly ActionIdentifier CreateInternetGateway = new ActionIdentifier("ec2:CreateInternetGateway");

		public static readonly ActionIdentifier CreateKeyPair = new ActionIdentifier("ec2:CreateKeyPair");

		public static readonly ActionIdentifier CreateNetworkAcl = new ActionIdentifier("ec2:CreateNetworkAcl");

		public static readonly ActionIdentifier CreateNetworkAclEntry = new ActionIdentifier("ec2:CreateNetworkAclEntry");

		public static readonly ActionIdentifier CreateNetworkInterface = new ActionIdentifier("ec2:CreateNetworkInterface");

		public static readonly ActionIdentifier CreatePlacementGroup = new ActionIdentifier("ec2:CreatePlacementGroup");

		public static readonly ActionIdentifier CreateReservedInstancesListing = new ActionIdentifier("ec2:CreateReservedInstancesListing");

		public static readonly ActionIdentifier CreateRoute = new ActionIdentifier("ec2:CreateRoute");

		public static readonly ActionIdentifier CreateRouteTable = new ActionIdentifier("ec2:CreateRouteTable");

		public static readonly ActionIdentifier CreateSecurityGroup = new ActionIdentifier("ec2:CreateSecurityGroup");

		public static readonly ActionIdentifier CreateSnapshot = new ActionIdentifier("ec2:CreateSnapshot");

		public static readonly ActionIdentifier CreateSpotDatafeedSubscription = new ActionIdentifier("ec2:CreateSpotDatafeedSubscription");

		public static readonly ActionIdentifier CreateSubnet = new ActionIdentifier("ec2:CreateSubnet");

		public static readonly ActionIdentifier CreateTags = new ActionIdentifier("ec2:CreateTags");

		public static readonly ActionIdentifier CreateVolume = new ActionIdentifier("ec2:CreateVolume");

		public static readonly ActionIdentifier CreateVpc = new ActionIdentifier("ec2:CreateVpc");

		public static readonly ActionIdentifier CreateVpcPeeringConnection = new ActionIdentifier("ec2:CreateVpcPeeringConnection");

		public static readonly ActionIdentifier CreateVpnConnection = new ActionIdentifier("ec2:CreateVpnConnection");

		public static readonly ActionIdentifier CreateVpnConnectionRoute = new ActionIdentifier("ec2:CreateVpnConnectionRoute");

		public static readonly ActionIdentifier CreateVpnGateway = new ActionIdentifier("ec2:CreateVpnGateway");

		public static readonly ActionIdentifier DeactivateLicense = new ActionIdentifier("ec2:DeactivateLicense");

		public static readonly ActionIdentifier DeleteCustomerGateway = new ActionIdentifier("ec2:DeleteCustomerGateway");

		public static readonly ActionIdentifier DeleteDhcpOptions = new ActionIdentifier("ec2:DeleteDhcpOptions");

		public static readonly ActionIdentifier DeleteInternetGateway = new ActionIdentifier("ec2:DeleteInternetGateway");

		public static readonly ActionIdentifier DeleteKeyPair = new ActionIdentifier("ec2:DeleteKeyPair");

		public static readonly ActionIdentifier DeleteNetworkAcl = new ActionIdentifier("ec2:DeleteNetworkAcl");

		public static readonly ActionIdentifier DeleteNetworkAclEntry = new ActionIdentifier("ec2:DeleteNetworkAclEntry");

		public static readonly ActionIdentifier DeleteNetworkInterface = new ActionIdentifier("ec2:DeleteNetworkInterface");

		public static readonly ActionIdentifier DeletePlacementGroup = new ActionIdentifier("ec2:DeletePlacementGroup");

		public static readonly ActionIdentifier DeleteRoute = new ActionIdentifier("ec2:DeleteRoute");

		public static readonly ActionIdentifier DeleteRouteTable = new ActionIdentifier("ec2:DeleteRouteTable");

		public static readonly ActionIdentifier DeleteSecurityGroup = new ActionIdentifier("ec2:DeleteSecurityGroup");

		public static readonly ActionIdentifier DeleteSnapshot = new ActionIdentifier("ec2:DeleteSnapshot");

		public static readonly ActionIdentifier DeleteSpotDatafeedSubscription = new ActionIdentifier("ec2:DeleteSpotDatafeedSubscription");

		public static readonly ActionIdentifier DeleteSubnet = new ActionIdentifier("ec2:DeleteSubnet");

		public static readonly ActionIdentifier DeleteTags = new ActionIdentifier("ec2:DeleteTags");

		public static readonly ActionIdentifier DeleteVolume = new ActionIdentifier("ec2:DeleteVolume");

		public static readonly ActionIdentifier DeleteVpc = new ActionIdentifier("ec2:DeleteVpc");

		public static readonly ActionIdentifier DeleteVpcPeeringConnection = new ActionIdentifier("ec2:DeleteVpcPeeringConnection");

		public static readonly ActionIdentifier DeleteVpnConnection = new ActionIdentifier("ec2:DeleteVpnConnection");

		public static readonly ActionIdentifier DeleteVpnConnectionRoute = new ActionIdentifier("ec2:DeleteVpnConnectionRoute");

		public static readonly ActionIdentifier DeleteVpnGateway = new ActionIdentifier("ec2:DeleteVpnGateway");

		public static readonly ActionIdentifier DeregisterImage = new ActionIdentifier("ec2:DeregisterImage");

		public static readonly ActionIdentifier DescribeAccountAttributes = new ActionIdentifier("ec2:DescribeAccountAttributes");

		public static readonly ActionIdentifier DescribeAddresses = new ActionIdentifier("ec2:DescribeAddresses");

		public static readonly ActionIdentifier DescribeAvailabilityZones = new ActionIdentifier("ec2:DescribeAvailabilityZones");

		public static readonly ActionIdentifier DescribeBundleTasks = new ActionIdentifier("ec2:DescribeBundleTasks");

		public static readonly ActionIdentifier DescribeConversionTasks = new ActionIdentifier("ec2:DescribeConversionTasks");

		public static readonly ActionIdentifier DescribeCustomerGateways = new ActionIdentifier("ec2:DescribeCustomerGateways");

		public static readonly ActionIdentifier DescribeDhcpOptions = new ActionIdentifier("ec2:DescribeDhcpOptions");

		public static readonly ActionIdentifier DescribeExportTasks = new ActionIdentifier("ec2:DescribeExportTasks");

		public static readonly ActionIdentifier DescribeImageAttribute = new ActionIdentifier("ec2:DescribeImageAttribute");

		public static readonly ActionIdentifier DescribeImages = new ActionIdentifier("ec2:DescribeImages");

		public static readonly ActionIdentifier DescribeInstanceAttribute = new ActionIdentifier("ec2:DescribeInstanceAttribute");

		public static readonly ActionIdentifier DescribeInstanceStatus = new ActionIdentifier("ec2:DescribeInstanceStatus");

		public static readonly ActionIdentifier DescribeInstances = new ActionIdentifier("ec2:DescribeInstances");

		public static readonly ActionIdentifier DescribeInternetGateways = new ActionIdentifier("ec2:DescribeInternetGateways");

		public static readonly ActionIdentifier DescribeKeyPairs = new ActionIdentifier("ec2:DescribeKeyPairs");

		public static readonly ActionIdentifier DescribeLicenses = new ActionIdentifier("ec2:DescribeLicenses");

		public static readonly ActionIdentifier DescribeNetworkAcls = new ActionIdentifier("ec2:DescribeNetworkAcls");

		public static readonly ActionIdentifier DescribeNetworkInterfaceAttribute = new ActionIdentifier("ec2:DescribeNetworkInterfaceAttribute");

		public static readonly ActionIdentifier DescribeNetworkInterfaces = new ActionIdentifier("ec2:DescribeNetworkInterfaces");

		public static readonly ActionIdentifier DescribePlacementGroups = new ActionIdentifier("ec2:DescribePlacementGroups");

		public static readonly ActionIdentifier DescribeRegions = new ActionIdentifier("ec2:DescribeRegions");

		public static readonly ActionIdentifier DescribeReservedInstances = new ActionIdentifier("ec2:DescribeReservedInstances");

		public static readonly ActionIdentifier DescribeReservedInstancesListings = new ActionIdentifier("ec2:DescribeReservedInstancesListings");

		public static readonly ActionIdentifier DescribeReservedInstancesModifications = new ActionIdentifier("ec2:DescribeReservedInstancesModifications");

		public static readonly ActionIdentifier DescribeReservedInstancesOfferings = new ActionIdentifier("ec2:DescribeReservedInstancesOfferings");

		public static readonly ActionIdentifier DescribeRouteTables = new ActionIdentifier("ec2:DescribeRouteTables");

		public static readonly ActionIdentifier DescribeSecurityGroups = new ActionIdentifier("ec2:DescribeSecurityGroups");

		public static readonly ActionIdentifier DescribeSnapshotAttribute = new ActionIdentifier("ec2:DescribeSnapshotAttribute");

		public static readonly ActionIdentifier DescribeSnapshots = new ActionIdentifier("ec2:DescribeSnapshots");

		public static readonly ActionIdentifier DescribeSpotDatafeedSubscription = new ActionIdentifier("ec2:DescribeSpotDatafeedSubscription");

		public static readonly ActionIdentifier DescribeSpotInstanceRequests = new ActionIdentifier("ec2:DescribeSpotInstanceRequests");

		public static readonly ActionIdentifier DescribeSpotPriceHistory = new ActionIdentifier("ec2:DescribeSpotPriceHistory");

		public static readonly ActionIdentifier DescribeSubnets = new ActionIdentifier("ec2:DescribeSubnets");

		public static readonly ActionIdentifier DescribeTags = new ActionIdentifier("ec2:DescribeTags");

		public static readonly ActionIdentifier DescribeVolumeAttribute = new ActionIdentifier("ec2:DescribeVolumeAttribute");

		public static readonly ActionIdentifier DescribeVolumeStatus = new ActionIdentifier("ec2:DescribeVolumeStatus");

		public static readonly ActionIdentifier DescribeVolumes = new ActionIdentifier("ec2:DescribeVolumes");

		public static readonly ActionIdentifier DescribeVpcAttribute = new ActionIdentifier("ec2:DescribeVpcAttribute");

		public static readonly ActionIdentifier DescribeVpcs = new ActionIdentifier("ec2:DescribeVpcs");

		public static readonly ActionIdentifier DescribeVpcPeeringConnection = new ActionIdentifier("ec2:DescribeVpcPeeringConnection");

		public static readonly ActionIdentifier DescribeVpnConnections = new ActionIdentifier("ec2:DescribeVpnConnections");

		public static readonly ActionIdentifier DescribeVpnGateways = new ActionIdentifier("ec2:DescribeVpnGateways");

		public static readonly ActionIdentifier DetachInternetGateway = new ActionIdentifier("ec2:DetachInternetGateway");

		public static readonly ActionIdentifier DetachNetworkInterface = new ActionIdentifier("ec2:DetachNetworkInterface");

		public static readonly ActionIdentifier DetachVolume = new ActionIdentifier("ec2:DetachVolume");

		public static readonly ActionIdentifier DetachVpnGateway = new ActionIdentifier("ec2:DetachVpnGateway");

		public static readonly ActionIdentifier DisableVgwRoutePropagation = new ActionIdentifier("ec2:DisableVgwRoutePropagation");

		public static readonly ActionIdentifier DisassociateAddress = new ActionIdentifier("ec2:DisassociateAddress");

		public static readonly ActionIdentifier DisassociateRouteTable = new ActionIdentifier("ec2:DisassociateRouteTable");

		public static readonly ActionIdentifier EnableVgwRoutePropagation = new ActionIdentifier("ec2:EnableVgwRoutePropagation");

		public static readonly ActionIdentifier EnableVolumeIO = new ActionIdentifier("ec2:EnableVolumeIO");

		public static readonly ActionIdentifier GetConsoleOutput = new ActionIdentifier("ec2:GetConsoleOutput");

		public static readonly ActionIdentifier GetPasswordData = new ActionIdentifier("ec2:GetPasswordData");

		public static readonly ActionIdentifier ImportInstance = new ActionIdentifier("ec2:ImportInstance");

		public static readonly ActionIdentifier ImportKeyPair = new ActionIdentifier("ec2:ImportKeyPair");

		public static readonly ActionIdentifier ImportVolume = new ActionIdentifier("ec2:ImportVolume");

		public static readonly ActionIdentifier ModifyImageAttribute = new ActionIdentifier("ec2:ModifyImageAttribute");

		public static readonly ActionIdentifier ModifyInstanceAttribute = new ActionIdentifier("ec2:ModifyInstanceAttribute");

		public static readonly ActionIdentifier ModifyNetworkInterfaceAttribute = new ActionIdentifier("ec2:ModifyNetworkInterfaceAttribute");

		public static readonly ActionIdentifier ModifyReservedInstances = new ActionIdentifier("ec2:ModifyReservedInstances");

		public static readonly ActionIdentifier ModifySnapshotAttribute = new ActionIdentifier("ec2:ModifySnapshotAttribute");

		public static readonly ActionIdentifier ModifyVolumeAttribute = new ActionIdentifier("ec2:ModifyVolumeAttribute");

		public static readonly ActionIdentifier ModifyVpcAttribute = new ActionIdentifier("ec2:ModifyVpcAttribute");

		public static readonly ActionIdentifier MonitorInstances = new ActionIdentifier("ec2:MonitorInstances");

		public static readonly ActionIdentifier PurchaseReservedInstancesOffering = new ActionIdentifier("ec2:PurchaseReservedInstancesOffering");

		public static readonly ActionIdentifier RebootInstances = new ActionIdentifier("ec2:RebootInstances");

		public static readonly ActionIdentifier RegisterImage = new ActionIdentifier("ec2:RegisterImage");

		public static readonly ActionIdentifier RejectVpcPeeringConnection = new ActionIdentifier("ec2:RejectVpcPeeringConnection");

		public static readonly ActionIdentifier ReleaseAddress = new ActionIdentifier("ec2:ReleaseAddress");

		public static readonly ActionIdentifier ReplaceNetworkAclAssociation = new ActionIdentifier("ec2:ReplaceNetworkAclAssociation");

		public static readonly ActionIdentifier ReplaceNetworkAclEntry = new ActionIdentifier("ec2:ReplaceNetworkAclEntry");

		public static readonly ActionIdentifier ReplaceRoute = new ActionIdentifier("ec2:ReplaceRoute");

		public static readonly ActionIdentifier ReplaceRouteTableAssociation = new ActionIdentifier("ec2:ReplaceRouteTableAssociation");

		public static readonly ActionIdentifier ReportInstanceStatus = new ActionIdentifier("ec2:ReportInstanceStatus");

		public static readonly ActionIdentifier RequestSpotInstances = new ActionIdentifier("ec2:RequestSpotInstances");

		public static readonly ActionIdentifier ResetImageAttribute = new ActionIdentifier("ec2:ResetImageAttribute");

		public static readonly ActionIdentifier ResetInstanceAttribute = new ActionIdentifier("ec2:ResetInstanceAttribute");

		public static readonly ActionIdentifier ResetNetworkInterfaceAttribute = new ActionIdentifier("ec2:ResetNetworkInterfaceAttribute");

		public static readonly ActionIdentifier ResetSnapshotAttribute = new ActionIdentifier("ec2:ResetSnapshotAttribute");

		public static readonly ActionIdentifier RevokeSecurityGroupEgress = new ActionIdentifier("ec2:RevokeSecurityGroupEgress");

		public static readonly ActionIdentifier RevokeSecurityGroupIngress = new ActionIdentifier("ec2:RevokeSecurityGroupIngress");

		public static readonly ActionIdentifier RunInstances = new ActionIdentifier("ec2:RunInstances");

		public static readonly ActionIdentifier StartInstances = new ActionIdentifier("ec2:StartInstances");

		public static readonly ActionIdentifier StopInstances = new ActionIdentifier("ec2:StopInstances");

		public static readonly ActionIdentifier TerminateInstances = new ActionIdentifier("ec2:TerminateInstances");

		public static readonly ActionIdentifier UnassignPrivateIpAddresses = new ActionIdentifier("ec2:UnassignPrivateIpAddresses");

		public static readonly ActionIdentifier UnmonitorInstances = new ActionIdentifier("ec2:UnmonitorInstances");
	}
	public static class ElastiCacheActionIdentifiers
	{
		public static readonly ActionIdentifier AllElastiCacheActions = new ActionIdentifier("elasticache:*");

		public static readonly ActionIdentifier AuthorizeCacheSecurityGroupIngress = new ActionIdentifier("elasticache:AuthorizeCacheSecurityGroupIngress");

		public static readonly ActionIdentifier CreateCacheCluster = new ActionIdentifier("elasticache:CreateCacheCluster");

		public static readonly ActionIdentifier CreateCacheParameterGroup = new ActionIdentifier("elasticache:CreateCacheParameterGroup");

		public static readonly ActionIdentifier CreateCacheSecurityGroup = new ActionIdentifier("elasticache:CreateCacheSecurityGroup");

		public static readonly ActionIdentifier DeleteCacheCluster = new ActionIdentifier("elasticache:DeleteCacheCluster");

		public static readonly ActionIdentifier DeleteCacheParameterGroup = new ActionIdentifier("elasticache:DeleteCacheParameterGroup");

		public static readonly ActionIdentifier DeleteCacheSecurityGroup = new ActionIdentifier("elasticache:DeleteCacheSecurityGroup");

		public static readonly ActionIdentifier DescribeCacheClusters = new ActionIdentifier("elasticache:DescribeCacheClusters");

		public static readonly ActionIdentifier DescribeCacheParameterGroups = new ActionIdentifier("elasticache:DescribeCacheParameterGroups");

		public static readonly ActionIdentifier DescribeCacheParameters = new ActionIdentifier("elasticache:DescribeCacheParameters");

		public static readonly ActionIdentifier DescribeCacheSecurityGroups = new ActionIdentifier("elasticache:DescribeCacheSecurityGroups");

		public static readonly ActionIdentifier DescribeEngineDefaultParameters = new ActionIdentifier("elasticache:DescribeEngineDefaultParameters");

		public static readonly ActionIdentifier DescribeEvents = new ActionIdentifier("elasticache:DescribeEvents");

		public static readonly ActionIdentifier ModifyCacheCluster = new ActionIdentifier("elasticache:ModifyCacheCluster");

		public static readonly ActionIdentifier ModifyCacheParameterGroup = new ActionIdentifier("elasticache:ModifyCacheParameterGroup");

		public static readonly ActionIdentifier RebootCacheCluster = new ActionIdentifier("elasticache:RebootCacheCluster");

		public static readonly ActionIdentifier ResetCacheParameterGroup = new ActionIdentifier("elasticache:ResetCacheParameterGroup");

		public static readonly ActionIdentifier RevokeCacheSecurityGroupIngress = new ActionIdentifier("elasticache:RevokeCacheSecurityGroupIngress");
	}
	public static class ElasticBeanstalkActionIdentifiers
	{
		public static readonly ActionIdentifier AllElasticBeanstalkActions = new ActionIdentifier("elasticbeanstalk:*");

		public static readonly ActionIdentifier CheckDNSAvailability = new ActionIdentifier("elasticbeanstalk:CheckDNSAvailability");

		public static readonly ActionIdentifier CreateApplication = new ActionIdentifier("elasticbeanstalk:CreateApplication");

		public static readonly ActionIdentifier CreateApplicationVersion = new ActionIdentifier("elasticbeanstalk:CreateApplicationVersion");

		public static readonly ActionIdentifier CreateConfigurationTemplate = new ActionIdentifier("elasticbeanstalk:CreateConfigurationTemplate");

		public static readonly ActionIdentifier CreateEnvironment = new ActionIdentifier("elasticbeanstalk:CreateEnvironment");

		public static readonly ActionIdentifier CreateStorageLocation = new ActionIdentifier("elasticbeanstalk:CreateStorageLocation");

		public static readonly ActionIdentifier DeleteApplication = new ActionIdentifier("elasticbeanstalk:DeleteApplication");

		public static readonly ActionIdentifier DeleteApplicationVersion = new ActionIdentifier("elasticbeanstalk:DeleteApplicationVersion");

		public static readonly ActionIdentifier DeleteConfigurationTemplate = new ActionIdentifier("elasticbeanstalk:DeleteConfigurationTemplate");

		public static readonly ActionIdentifier DeleteEnvironmentConfiguration = new ActionIdentifier("elasticbeanstalk:DeleteEnvironmentConfiguration");

		public static readonly ActionIdentifier DescribeApplicationVersions = new ActionIdentifier("elasticbeanstalk:DescribeApplicationVersions");

		public static readonly ActionIdentifier DescribeApplications = new ActionIdentifier("elasticbeanstalk:DescribeApplications");

		public static readonly ActionIdentifier DescribeConfigurationOptions = new ActionIdentifier("elasticbeanstalk:DescribeConfigurationOptions");

		public static readonly ActionIdentifier DescribeConfigurationSettings = new ActionIdentifier("elasticbeanstalk:DescribeConfigurationSettings");

		public static readonly ActionIdentifier DescribeEnvironmentResources = new ActionIdentifier("elasticbeanstalk:DescribeEnvironmentResources");

		public static readonly ActionIdentifier DescribeEnvironments = new ActionIdentifier("elasticbeanstalk:DescribeEnvironments");

		public static readonly ActionIdentifier DescribeEvents = new ActionIdentifier("elasticbeanstalk:DescribeEvents");

		public static readonly ActionIdentifier ListAvailableSolutionStacks = new ActionIdentifier("elasticbeanstalk:ListAvailableSolutionStacks");

		public static readonly ActionIdentifier RebuildEnvironment = new ActionIdentifier("elasticbeanstalk:RebuildEnvironment");

		public static readonly ActionIdentifier RequestEnvironmentInfo = new ActionIdentifier("elasticbeanstalk:RequestEnvironmentInfo");

		public static readonly ActionIdentifier RestartAppServer = new ActionIdentifier("elasticbeanstalk:RestartAppServer");

		public static readonly ActionIdentifier RetrieveEnvironmentInfo = new ActionIdentifier("elasticbeanstalk:RetrieveEnvironmentInfo");

		public static readonly ActionIdentifier SwapEnvironmentCNAMEs = new ActionIdentifier("elasticbeanstalk:SwapEnvironmentCNAMEs");

		public static readonly ActionIdentifier TerminateEnvironment = new ActionIdentifier("elasticbeanstalk:TerminateEnvironment");

		public static readonly ActionIdentifier UpdateApplication = new ActionIdentifier("elasticbeanstalk:UpdateApplication");

		public static readonly ActionIdentifier UpdateApplicationVersion = new ActionIdentifier("elasticbeanstalk:UpdateApplicationVersion");

		public static readonly ActionIdentifier UpdateConfigurationTemplate = new ActionIdentifier("elasticbeanstalk:UpdateConfigurationTemplate");

		public static readonly ActionIdentifier UpdateEnvironment = new ActionIdentifier("elasticbeanstalk:UpdateEnvironment");

		public static readonly ActionIdentifier ValidateConfigurationSettings = new ActionIdentifier("elasticbeanstalk:ValidateConfigurationSettings");
	}
	public static class ElasticLoadBalancingActionIdentifiers
	{
		public static readonly ActionIdentifier AllElasticLoadBalancingActions = new ActionIdentifier("elasticloadbalancing:*");

		public static readonly ActionIdentifier ApplySecurityGroupsToLoadBalancer = new ActionIdentifier("elasticloadbalancing:ApplySecurityGroupsToLoadBalancer");

		public static readonly ActionIdentifier AttachLoadBalancerToSubnets = new ActionIdentifier("elasticloadbalancing:AttachLoadBalancerToSubnets");

		public static readonly ActionIdentifier ConfigureHealthCheck = new ActionIdentifier("elasticloadbalancing:ConfigureHealthCheck");

		public static readonly ActionIdentifier CreateAppCookieStickinessPolicy = new ActionIdentifier("elasticloadbalancing:CreateAppCookieStickinessPolicy");

		public static readonly ActionIdentifier CreateLBCookieStickinessPolicy = new ActionIdentifier("elasticloadbalancing:CreateLBCookieStickinessPolicy");

		public static readonly ActionIdentifier CreateLoadBalancer = new ActionIdentifier("elasticloadbalancing:CreateLoadBalancer");

		public static readonly ActionIdentifier CreateLoadBalancerListeners = new ActionIdentifier("elasticloadbalancing:CreateLoadBalancerListeners");

		public static readonly ActionIdentifier CreateLoadBalancerPolicy = new ActionIdentifier("elasticloadbalancing:CreateLoadBalancerPolicy");

		public static readonly ActionIdentifier DeleteLoadBalancer = new ActionIdentifier("elasticloadbalancing:DeleteLoadBalancer");

		public static readonly ActionIdentifier DeleteLoadBalancerListeners = new ActionIdentifier("elasticloadbalancing:DeleteLoadBalancerListeners");

		public static readonly ActionIdentifier DeleteLoadBalancerPolicy = new ActionIdentifier("elasticloadbalancing:DeleteLoadBalancerPolicy");

		public static readonly ActionIdentifier DeregisterInstancesFromLoadBalancer = new ActionIdentifier("elasticloadbalancing:DeregisterInstancesFromLoadBalancer");

		public static readonly ActionIdentifier DescribeInstanceHealth = new ActionIdentifier("elasticloadbalancing:DescribeInstanceHealth");

		public static readonly ActionIdentifier DescribeLoadBalancerAttributes = new ActionIdentifier("elasticloadbalancing:DescribeLoadBalancerAttributes");

		public static readonly ActionIdentifier DescribeLoadBalancerPolicyTypes = new ActionIdentifier("elasticloadbalancing:DescribeLoadBalancerPolicyTypes");

		public static readonly ActionIdentifier DescribeLoadBalancerPolicies = new ActionIdentifier("elasticloadbalancing:DescribeLoadBalancerPolicies");

		public static readonly ActionIdentifier DescribeLoadBalancers = new ActionIdentifier("elasticloadbalancing:DescribeLoadBalancers");

		public static readonly ActionIdentifier DetachLoadBalancerFromSubnets = new ActionIdentifier("elasticloadbalancing:DetachLoadBalancerFromSubnets");

		public static readonly ActionIdentifier DisableAvailabilityZonesForLoadBalancer = new ActionIdentifier("elasticloadbalancing:DisableAvailabilityZonesForLoadBalancer");

		public static readonly ActionIdentifier EnableAvailabilityZonesForLoadBalancer = new ActionIdentifier("elasticloadbalancing:EnableAvailabilityZonesForLoadBalancer");

		public static readonly ActionIdentifier ModifyLoadBalancerAttributes = new ActionIdentifier("elasticloadbalancing:ModifyLoadBalancerAttributes");

		public static readonly ActionIdentifier RegisterInstancesWithLoadBalancer = new ActionIdentifier("elasticloadbalancing:RegisterInstancesWithLoadBalancer");

		public static readonly ActionIdentifier SetLoadBalancerListenerSSLCertificate = new ActionIdentifier("elasticloadbalancing:SetLoadBalancerListenerSSLCertificate");

		public static readonly ActionIdentifier SetLoadBalancerPoliciesForBackendServer = new ActionIdentifier("elasticloadbalancing:SetLoadBalancerPoliciesForBackendServer");

		public static readonly ActionIdentifier SetLoadBalancerPoliciesOfListener = new ActionIdentifier("elasticloadbalancing:SetLoadBalancerPoliciesOfListener");
	}
	public static class ElasticMapReduceActionIdentifiers
	{
		public static readonly ActionIdentifier AllElasticMapReduceActions = new ActionIdentifier("elasticmapreduce:*");

		public static readonly ActionIdentifier AddInstanceGroups = new ActionIdentifier("elasticmapreduce:AddInstanceGroups");

		public static readonly ActionIdentifier AddTags = new ActionIdentifier("elasticmapreduce:AddTags");

		public static readonly ActionIdentifier AddJobFlowSteps = new ActionIdentifier("elasticmapreduce:AddJobFlowSteps");

		public static readonly ActionIdentifier DescribeCluster = new ActionIdentifier("elasticmapreduce:DescribeCluster");

		public static readonly ActionIdentifier DescribeJobFlows = new ActionIdentifier("elasticmapreduce:DescribeJobFlows");

		public static readonly ActionIdentifier DescribeStep = new ActionIdentifier("elasticmapreduce:DescribeStep");

		public static readonly ActionIdentifier ListBootstrapActions = new ActionIdentifier("elasticmapreduce:ListBootstrapActions");

		public static readonly ActionIdentifier ListClusters = new ActionIdentifier("elasticmapreduce:ListClusters");

		public static readonly ActionIdentifier ListInstanceGroups = new ActionIdentifier("elasticmapreduce:ListInstanceGroups");

		public static readonly ActionIdentifier ListInstances = new ActionIdentifier("elasticmapreduce:ListInstances");

		public static readonly ActionIdentifier ListSteps = new ActionIdentifier("elasticmapreduce:ListSteps");

		public static readonly ActionIdentifier ModifyInstanceGroups = new ActionIdentifier("elasticmapreduce:ModifyInstanceGroups");

		public static readonly ActionIdentifier RemoveTags = new ActionIdentifier("elasticmapreduce:RemoveTags");

		public static readonly ActionIdentifier RunJobFlow = new ActionIdentifier("elasticmapreduce:RunJobFlow");

		public static readonly ActionIdentifier SetTerminationProtection = new ActionIdentifier("elasticmapreduce:SetTerminationProtection");

		public static readonly ActionIdentifier TerminateJobFlows = new ActionIdentifier("elasticmapreduce:TerminateJobFlows");
	}
	public static class ElasticTranscoderActionIdentifiers
	{
		public static readonly ActionIdentifier AllElasticTranscoderActions = new ActionIdentifier("elastictranscoder:*");

		public static readonly ActionIdentifier CancelJob = new ActionIdentifier("elastictranscoder:CancelJob");

		public static readonly ActionIdentifier CreateJob = new ActionIdentifier("elastictranscoder:CreateJob");

		public static readonly ActionIdentifier CreatePipeline = new ActionIdentifier("elastictranscoder:CreatePipeline");

		public static readonly ActionIdentifier CreatePreset = new ActionIdentifier("elastictranscoder:CreatePreset");

		public static readonly ActionIdentifier DeletePipeline = new ActionIdentifier("elastictranscoder:DeletePipeline");

		public static readonly ActionIdentifier DeletePreset = new ActionIdentifier("elastictranscoder:DeletePreset");

		public static readonly ActionIdentifier ListJobsByPipeline = new ActionIdentifier("elastictranscoder:ListJobsByPipeline");

		public static readonly ActionIdentifier ListJobsByStatus = new ActionIdentifier("elastictranscoder:ListJobsByStatus");

		public static readonly ActionIdentifier ListPipelines = new ActionIdentifier("elastictranscoder:ListPipelines");

		public static readonly ActionIdentifier ListPresets = new ActionIdentifier("elastictranscoder:ListPresets");

		public static readonly ActionIdentifier ReadJob = new ActionIdentifier("elastictranscoder:ReadJob");

		public static readonly ActionIdentifier ReadPipeline = new ActionIdentifier("elastictranscoder:ReadPipeline");

		public static readonly ActionIdentifier ReadPreset = new ActionIdentifier("elastictranscoder:ReadPreset");

		public static readonly ActionIdentifier TestRole = new ActionIdentifier("elastictranscoder:TestRole");

		public static readonly ActionIdentifier UpdatePipeline = new ActionIdentifier("elastictranscoder:UpdatePipeline");

		public static readonly ActionIdentifier UpdatePipelineNotifications = new ActionIdentifier("elastictranscoder:UpdatePipelineNotifications");

		public static readonly ActionIdentifier UpdatePipelineStatus = new ActionIdentifier("elastictranscoder:UpdatePipelineStatus");
	}
	public static class GlacierActionIdentifiers
	{
		public static readonly ActionIdentifier AllGlacierActions = new ActionIdentifier("glacier:*");

		public static readonly ActionIdentifier AbortMultipartUpload = new ActionIdentifier("glacier:AbortMultipartUpload");

		public static readonly ActionIdentifier CompleteMultipartUpload = new ActionIdentifier("glacier:CompleteMultipartUpload");

		public static readonly ActionIdentifier CreateVault = new ActionIdentifier("glacier:CreateVault");

		public static readonly ActionIdentifier DeleteArchive = new ActionIdentifier("glacier:DeleteArchive");

		public static readonly ActionIdentifier DeleteVault = new ActionIdentifier("glacier:DeleteVault");

		public static readonly ActionIdentifier DeleteVaultNotifications = new ActionIdentifier("glacier:DeleteVaultNotifications");

		public static readonly ActionIdentifier DescribeJob = new ActionIdentifier("glacier:DescribeJob");

		public static readonly ActionIdentifier DescribeVault = new ActionIdentifier("glacier:DescribeVault");

		public static readonly ActionIdentifier GetJobOutput = new ActionIdentifier("glacier:GetJobOutput");

		public static readonly ActionIdentifier GetVaultNotifications = new ActionIdentifier("glacier:GetVaultNotifications");

		public static readonly ActionIdentifier InitiateMultipartUpload = new ActionIdentifier("glacier:InitiateMultipartUpload");

		public static readonly ActionIdentifier InitiateJob = new ActionIdentifier("glacier:InitiateJob");

		public static readonly ActionIdentifier ListJobs = new ActionIdentifier("glacier:ListJobs");

		public static readonly ActionIdentifier ListMultipartUploads = new ActionIdentifier("glacier:ListMultipartUploads");

		public static readonly ActionIdentifier ListParts = new ActionIdentifier("glacier:ListParts");

		public static readonly ActionIdentifier ListVaults = new ActionIdentifier("glacier:ListVaults");

		public static readonly ActionIdentifier SetVaultNotifications = new ActionIdentifier("glacier:SetVaultNotifications");

		public static readonly ActionIdentifier UploadArchive = new ActionIdentifier("glacier:UploadArchive");

		public static readonly ActionIdentifier UploadMultipartPart = new ActionIdentifier("glacier:UploadMultipartPart");
	}
	public static class IdentityandAccessManagementActionIdentifiers
	{
		public static readonly ActionIdentifier AllIdentityandAccessManagementActions = new ActionIdentifier("iam:*");

		public static readonly ActionIdentifier AddRoleToInstanceProfile = new ActionIdentifier("iam:AddRoleToInstanceProfile");

		public static readonly ActionIdentifier AddUserToGroup = new ActionIdentifier("iam:AddUserToGroup");

		public static readonly ActionIdentifier ChangePassword = new ActionIdentifier("iam:ChangePassword");

		public static readonly ActionIdentifier CreateAccessKey = new ActionIdentifier("iam:CreateAccessKey");

		public static readonly ActionIdentifier CreateAccountAlias = new ActionIdentifier("iam:CreateAccountAlias");

		public static readonly ActionIdentifier CreateGroup = new ActionIdentifier("iam:CreateGroup");

		public static readonly ActionIdentifier CreateInstanceProfile = new ActionIdentifier("iam:CreateInstanceProfile");

		public static readonly ActionIdentifier CreateLoginProfile = new ActionIdentifier("iam:CreateLoginProfile");

		public static readonly ActionIdentifier CreateRole = new ActionIdentifier("iam:CreateRole");

		public static readonly ActionIdentifier CreateSAMLProvider = new ActionIdentifier("iam:CreateSAMLProvider");

		public static readonly ActionIdentifier CreateUser = new ActionIdentifier("iam:CreateUser");

		public static readonly ActionIdentifier CreateVirtualMFADevice = new ActionIdentifier("iam:CreateVirtualMFADevice");

		public static readonly ActionIdentifier DeactivateMFADevice = new ActionIdentifier("iam:DeactivateMFADevice");

		public static readonly ActionIdentifier DeleteAccessKey = new ActionIdentifier("iam:DeleteAccessKey");

		public static readonly ActionIdentifier DeleteAccountAlias = new ActionIdentifier("iam:DeleteAccountAlias");

		public static readonly ActionIdentifier DeleteAccountPasswordPolicy = new ActionIdentifier("iam:DeleteAccountPasswordPolicy");

		public static readonly ActionIdentifier DeleteGroup = new ActionIdentifier("iam:DeleteGroup");

		public static readonly ActionIdentifier DeleteGroupPolicy = new ActionIdentifier("iam:DeleteGroupPolicy");

		public static readonly ActionIdentifier DeleteInstanceProfile = new ActionIdentifier("iam:DeleteInstanceProfile");

		public static readonly ActionIdentifier DeleteLoginProfile = new ActionIdentifier("iam:DeleteLoginProfile");

		public static readonly ActionIdentifier DeleteRole = new ActionIdentifier("iam:DeleteRole");

		public static readonly ActionIdentifier DeleteRolePolicy = new ActionIdentifier("iam:DeleteRolePolicy");

		public static readonly ActionIdentifier DeleteSAMLProvider = new ActionIdentifier("iam:DeleteSAMLProvider");

		public static readonly ActionIdentifier DeleteServerCertificate = new ActionIdentifier("iam:DeleteServerCertificate");

		public static readonly ActionIdentifier DeleteSigningCertificate = new ActionIdentifier("iam:DeleteSigningCertificate");

		public static readonly ActionIdentifier DeleteUser = new ActionIdentifier("iam:DeleteUser");

		public static readonly ActionIdentifier DeleteUserPolicy = new ActionIdentifier("iam:DeleteUserPolicy");

		public static readonly ActionIdentifier DeleteVirtualMFADevice = new ActionIdentifier("iam:DeleteVirtualMFADevice");

		public static readonly ActionIdentifier EnableMFADevice = new ActionIdentifier("iam:EnableMFADevice");

		public static readonly ActionIdentifier GenerateCredentialReport = new ActionIdentifier("iam:GenerateCredentialReport");

		public static readonly ActionIdentifier GetAccountPasswordPolicy = new ActionIdentifier("iam:GetAccountPasswordPolicy");

		public static readonly ActionIdentifier GetAccountSummary = new ActionIdentifier("iam:GetAccountSummary");

		public static readonly ActionIdentifier GetCredentialReport = new ActionIdentifier("iam:GetCredentialReport");

		public static readonly ActionIdentifier GetGroup = new ActionIdentifier("iam:GetGroup");

		public static readonly ActionIdentifier GetGroupPolicy = new ActionIdentifier("iam:GetGroupPolicy");

		public static readonly ActionIdentifier GetInstanceProfile = new ActionIdentifier("iam:GetInstanceProfile");

		public static readonly ActionIdentifier GetLoginProfile = new ActionIdentifier("iam:GetLoginProfile");

		public static readonly ActionIdentifier GetRole = new ActionIdentifier("iam:GetRole");

		public static readonly ActionIdentifier GetRolePolicy = new ActionIdentifier("iam:GetRolePolicy");

		public static readonly ActionIdentifier GetSAMLProvider = new ActionIdentifier("iam:GetSAMLProvider");

		public static readonly ActionIdentifier GetServerCertificate = new ActionIdentifier("iam:GetServerCertificate");

		public static readonly ActionIdentifier GetUser = new ActionIdentifier("iam:GetUser");

		public static readonly ActionIdentifier GetUserPolicy = new ActionIdentifier("iam:GetUserPolicy");

		public static readonly ActionIdentifier ListAccessKeys = new ActionIdentifier("iam:ListAccessKeys");

		public static readonly ActionIdentifier ListAccountAliases = new ActionIdentifier("iam:ListAccountAliases");

		public static readonly ActionIdentifier ListGroupPolicies = new ActionIdentifier("iam:ListGroupPolicies");

		public static readonly ActionIdentifier ListGroups = new ActionIdentifier("iam:ListGroups");

		public static readonly ActionIdentifier ListGroupsForUser = new ActionIdentifier("iam:ListGroupsForUser");

		public static readonly ActionIdentifier ListInstanceProfiles = new ActionIdentifier("iam:ListInstanceProfiles");

		public static readonly ActionIdentifier ListInstanceProfilesForRole = new ActionIdentifier("iam:ListInstanceProfilesForRole");

		public static readonly ActionIdentifier ListMFADevices = new ActionIdentifier("iam:ListMFADevices");

		public static readonly ActionIdentifier ListRolePolicies = new ActionIdentifier("iam:ListRolePolicies");

		public static readonly ActionIdentifier ListRoles = new ActionIdentifier("iam:ListRoles");

		public static readonly ActionIdentifier ListSAMLProviders = new ActionIdentifier("iam:ListSAMLProviders");

		public static readonly ActionIdentifier ListServerCertificates = new ActionIdentifier("iam:ListServerCertificates");

		public static readonly ActionIdentifier ListSigningCertificates = new ActionIdentifier("iam:ListSigningCertificates");

		public static readonly ActionIdentifier ListUserPolicies = new ActionIdentifier("iam:ListUserPolicies");

		public static readonly ActionIdentifier ListUsers = new ActionIdentifier("iam:ListUsers");

		public static readonly ActionIdentifier ListVirtualMFADevices = new ActionIdentifier("iam:ListVirtualMFADevices");

		public static readonly ActionIdentifier PassRole = new ActionIdentifier("iam:PassRole");

		public static readonly ActionIdentifier PutGroupPolicy = new ActionIdentifier("iam:PutGroupPolicy");

		public static readonly ActionIdentifier PutRolePolicy = new ActionIdentifier("iam:PutRolePolicy");

		public static readonly ActionIdentifier PutUserPolicy = new ActionIdentifier("iam:PutUserPolicy");

		public static readonly ActionIdentifier RemoveRoleFromInstanceProfile = new ActionIdentifier("iam:RemoveRoleFromInstanceProfile");

		public static readonly ActionIdentifier RemoveUserFromGroup = new ActionIdentifier("iam:RemoveUserFromGroup");

		public static readonly ActionIdentifier ResyncMFADevice = new ActionIdentifier("iam:ResyncMFADevice");

		public static readonly ActionIdentifier UpdateAccessKey = new ActionIdentifier("iam:UpdateAccessKey");

		public static readonly ActionIdentifier UpdateAccountPasswordPolicy = new ActionIdentifier("iam:UpdateAccountPasswordPolicy");

		public static readonly ActionIdentifier UpdateAssumeRolePolicy = new ActionIdentifier("iam:UpdateAssumeRolePolicy");

		public static readonly ActionIdentifier UpdateGroup = new ActionIdentifier("iam:UpdateGroup");

		public static readonly ActionIdentifier UpdateLoginProfile = new ActionIdentifier("iam:UpdateLoginProfile");

		public static readonly ActionIdentifier UpdateSAMLProvider = new ActionIdentifier("iam:UpdateSAMLProvider");

		public static readonly ActionIdentifier UpdateServerCertificate = new ActionIdentifier("iam:UpdateServerCertificate");

		public static readonly ActionIdentifier UpdateSigningCertificate = new ActionIdentifier("iam:UpdateSigningCertificate");

		public static readonly ActionIdentifier UpdateUser = new ActionIdentifier("iam:UpdateUser");

		public static readonly ActionIdentifier UploadServerCertificate = new ActionIdentifier("iam:UploadServerCertificate");

		public static readonly ActionIdentifier UploadSigningCertificate = new ActionIdentifier("iam:UploadSigningCertificate");
	}
	public static class ImportExportActionIdentifiers
	{
		public static readonly ActionIdentifier AllImportExportActions = new ActionIdentifier("importexport:*");

		public static readonly ActionIdentifier CreateJob = new ActionIdentifier("importexport:CreateJob");

		public static readonly ActionIdentifier UpdateJob = new ActionIdentifier("importexport:UpdateJob");

		public static readonly ActionIdentifier CancelJob = new ActionIdentifier("importexport:CancelJob");

		public static readonly ActionIdentifier ListJobs = new ActionIdentifier("importexport:ListJobs");

		public static readonly ActionIdentifier GetStatus = new ActionIdentifier("importexport:GetStatus");
	}
	public static class KinesisActionIdentifiers
	{
		public static readonly ActionIdentifier AllKinesisActions = new ActionIdentifier("kinesis:*");

		public static readonly ActionIdentifier CreateStream = new ActionIdentifier("kinesis:CreateStream");

		public static readonly ActionIdentifier DeleteStream = new ActionIdentifier("kinesis:DeleteStream");

		public static readonly ActionIdentifier DescribeStream = new ActionIdentifier("kinesis:DescribeStream");

		public static readonly ActionIdentifier ListStreams = new ActionIdentifier("kinesis:ListStreams");

		public static readonly ActionIdentifier PutRecord = new ActionIdentifier("kinesis:PutRecord");

		public static readonly ActionIdentifier GetShardIterator = new ActionIdentifier("kinesis:GetShardIterator");

		public static readonly ActionIdentifier GetRecords = new ActionIdentifier("kinesis:GetRecords");

		public static readonly ActionIdentifier MergeShards = new ActionIdentifier("kinesis:MergeShards");

		public static readonly ActionIdentifier SplitShard = new ActionIdentifier("kinesis:SplitShard");
	}
	public static class MarketplaceActionIdentifiers
	{
		public static readonly ActionIdentifier AllMarketplaceActions = new ActionIdentifier("aws-marketplace:*");

		public static readonly ActionIdentifier Subscribe = new ActionIdentifier("aws-marketplace:Subscribe");

		public static readonly ActionIdentifier Unsubscribe = new ActionIdentifier("aws-marketplace:Unsubscribe");

		public static readonly ActionIdentifier ViewSubscriptions = new ActionIdentifier("aws-marketplace:ViewSubscriptions");
	}
	public static class MarketplaceManagementPortalActionIdentifiers
	{
		public static readonly ActionIdentifier AllMarketplaceManagementPortalActions = new ActionIdentifier("aws-marketplace-management:*");

		public static readonly ActionIdentifier uploadFiles = new ActionIdentifier("aws-marketplace-management:uploadFiles");

		public static readonly ActionIdentifier viewMarketing = new ActionIdentifier("aws-marketplace-management:viewMarketing");

		public static readonly ActionIdentifier viewReports = new ActionIdentifier("aws-marketplace-management:viewReports");

		public static readonly ActionIdentifier viewSupport = new ActionIdentifier("aws-marketplace-management:viewSupport");
	}
	public static class MobileAnalyticsActionIdentifiers
	{
		public static readonly ActionIdentifier AllMobileAnalyticsActions = new ActionIdentifier("mobileanalytics:*");

		public static readonly ActionIdentifier PutEvents = new ActionIdentifier("mobileanalytics:PutEvents");

		public static readonly ActionIdentifier GetReports = new ActionIdentifier("mobileanalytics:GetReports");

		public static readonly ActionIdentifier GetFinancialReports = new ActionIdentifier("mobileanalytics:GetFinancialReports");
	}
	public static class OpsWorksActionIdentifiers
	{
		public static readonly ActionIdentifier AllOpsWorksActions = new ActionIdentifier("opsworks:*");

		public static readonly ActionIdentifier AssignVolume = new ActionIdentifier("opsworks:AssignVolume");

		public static readonly ActionIdentifier AssociateElasticIp = new ActionIdentifier("opsworks:AssociateElasticIp");

		public static readonly ActionIdentifier AttachElasticLoadBalancer = new ActionIdentifier("opsworks:AttachElasticLoadBalancer");

		public static readonly ActionIdentifier CloneStack = new ActionIdentifier("opsworks:CloneStack");

		public static readonly ActionIdentifier CreateApp = new ActionIdentifier("opsworks:CreateApp");

		public static readonly ActionIdentifier CreateDeployment = new ActionIdentifier("opsworks:CreateDeployment");

		public static readonly ActionIdentifier CreateInstance = new ActionIdentifier("opsworks:CreateInstance");

		public static readonly ActionIdentifier CreateLayer = new ActionIdentifier("opsworks:CreateLayer");

		public static readonly ActionIdentifier CreateStack = new ActionIdentifier("opsworks:CreateStack");

		public static readonly ActionIdentifier CreateUserProfile = new ActionIdentifier("opsworks:CreateUserProfile");

		public static readonly ActionIdentifier DeleteApp = new ActionIdentifier("opsworks:DeleteApp");

		public static readonly ActionIdentifier DeleteInstance = new ActionIdentifier("opsworks:DeleteInstance");

		public static readonly ActionIdentifier DeleteLayer = new ActionIdentifier("opsworks:DeleteLayer");

		public static readonly ActionIdentifier DeleteStack = new ActionIdentifier("opsworks:DeleteStack");

		public static readonly ActionIdentifier DeleteUserProfile = new ActionIdentifier("opsworks:DeleteUserProfile");

		public static readonly ActionIdentifier DeregisterElasticIp = new ActionIdentifier("opsworks:DeregisterElasticIp");

		public static readonly ActionIdentifier DeregisterVolume = new ActionIdentifier("opsworks:DeregisterVolume");

		public static readonly ActionIdentifier DescribeApps = new ActionIdentifier("opsworks:DescribeApps");

		public static readonly ActionIdentifier DescribeCommands = new ActionIdentifier("opsworks:DescribeCommands");

		public static readonly ActionIdentifier DescribeDeployments = new ActionIdentifier("opsworks:DescribeDeployments");

		public static readonly ActionIdentifier DescribeElasticIps = new ActionIdentifier("opsworks:DescribeElasticIps");

		public static readonly ActionIdentifier DescribeElasticLoadBalancers = new ActionIdentifier("opsworks:DescribeElasticLoadBalancers");

		public static readonly ActionIdentifier DescribeInstances = new ActionIdentifier("opsworks:DescribeInstances");

		public static readonly ActionIdentifier DescribeLayers = new ActionIdentifier("opsworks:DescribeLayers");

		public static readonly ActionIdentifier DescribeLoadBasedAutoScaling = new ActionIdentifier("opsworks:DescribeLoadBasedAutoScaling");

		public static readonly ActionIdentifier DescribePermissions = new ActionIdentifier("opsworks:DescribePermissions");

		public static readonly ActionIdentifier DescribeRaidArrays = new ActionIdentifier("opsworks:DescribeRaidArrays");

		public static readonly ActionIdentifier DescribeServiceErrors = new ActionIdentifier("opsworks:DescribeServiceErrors");

		public static readonly ActionIdentifier DescribeStacks = new ActionIdentifier("opsworks:DescribeStacks");

		public static readonly ActionIdentifier DescribeTimeBasedAutoScaling = new ActionIdentifier("opsworks:DescribeTimeBasedAutoScaling");

		public static readonly ActionIdentifier DescribeUserProfiles = new ActionIdentifier("opsworks:DescribeUserProfiles");

		public static readonly ActionIdentifier DescribeVolumes = new ActionIdentifier("opsworks:DescribeVolumes");

		public static readonly ActionIdentifier DetachElasticLoadBalancer = new ActionIdentifier("opsworks:DetachElasticLoadBalancer");

		public static readonly ActionIdentifier DisassociateElasticIp = new ActionIdentifier("opsworks:DisassociateElasticIp");

		public static readonly ActionIdentifier GetHostnameSuggestion = new ActionIdentifier("opsworks:GetHostnameSuggestion");

		public static readonly ActionIdentifier RebootInstance = new ActionIdentifier("opsworks:RebootInstance");

		public static readonly ActionIdentifier RegisterElasticIp = new ActionIdentifier("opsworks:RegisterElasticIp");

		public static readonly ActionIdentifier RegisterVolume = new ActionIdentifier("opsworks:RegisterVolume");

		public static readonly ActionIdentifier SetLoadBasedAutoScaling = new ActionIdentifier("opsworks:SetLoadBasedAutoScaling");

		public static readonly ActionIdentifier SetPermission = new ActionIdentifier("opsworks:SetPermission");

		public static readonly ActionIdentifier SetTimeBasedAutoScaling = new ActionIdentifier("opsworks:SetTimeBasedAutoScaling");

		public static readonly ActionIdentifier StartInstance = new ActionIdentifier("opsworks:StartInstance");

		public static readonly ActionIdentifier StartStack = new ActionIdentifier("opsworks:StartStack");

		public static readonly ActionIdentifier StopInstance = new ActionIdentifier("opsworks:StopInstance");

		public static readonly ActionIdentifier StopStack = new ActionIdentifier("opsworks:StopStack");

		public static readonly ActionIdentifier UnassignVolume = new ActionIdentifier("opsworks:UnassignVolume");

		public static readonly ActionIdentifier UpdateApp = new ActionIdentifier("opsworks:UpdateApp");

		public static readonly ActionIdentifier UpdateElasticIp = new ActionIdentifier("opsworks:UpdateElasticIp");

		public static readonly ActionIdentifier UpdateInstance = new ActionIdentifier("opsworks:UpdateInstance");

		public static readonly ActionIdentifier UpdateLayer = new ActionIdentifier("opsworks:UpdateLayer");

		public static readonly ActionIdentifier UpdateStack = new ActionIdentifier("opsworks:UpdateStack");

		public static readonly ActionIdentifier UpdateUserProfile = new ActionIdentifier("opsworks:UpdateUserProfile");

		public static readonly ActionIdentifier UpdateVolume = new ActionIdentifier("opsworks:UpdateVolume");
	}
	public static class RDSActionIdentifiers
	{
		public static readonly ActionIdentifier AllRDSActions = new ActionIdentifier("rds:*");

		public static readonly ActionIdentifier AuthorizeDBSecurityGroupIngress = new ActionIdentifier("rds:AuthorizeDBSecurityGroupIngress");

		public static readonly ActionIdentifier AddTagsToResource = new ActionIdentifier("rds:AddTagsToResource");

		public static readonly ActionIdentifier AddSourceIdentifierToSubscription = new ActionIdentifier("rds:AddSourceIdentifierToSubscription");

		public static readonly ActionIdentifier CopyDBSnapshot = new ActionIdentifier("rds:CopyDBSnapshot");

		public static readonly ActionIdentifier CreateDBInstance = new ActionIdentifier("rds:CreateDBInstance");

		public static readonly ActionIdentifier CreateDBInstanceReadReplica = new ActionIdentifier("rds:CreateDBInstanceReadReplica");

		public static readonly ActionIdentifier CreateDBParameterGroup = new ActionIdentifier("rds:CreateDBParameterGroup");

		public static readonly ActionIdentifier CreateDBSecurityGroup = new ActionIdentifier("rds:CreateDBSecurityGroup");

		public static readonly ActionIdentifier CreateDBSnapshot = new ActionIdentifier("rds:CreateDBSnapshot");

		public static readonly ActionIdentifier CreateDBSubnetGroup = new ActionIdentifier("rds:CreateDBSubnetGroup");

		public static readonly ActionIdentifier CreateEventSubscription = new ActionIdentifier("rds:CreateEventSubscription");

		public static readonly ActionIdentifier CreateOptionGroup = new ActionIdentifier("rds:CreateOptionGroup");

		public static readonly ActionIdentifier DeleteDBInstance = new ActionIdentifier("rds:DeleteDBInstance");

		public static readonly ActionIdentifier DeleteDBParameterGroup = new ActionIdentifier("rds:DeleteDBParameterGroup");

		public static readonly ActionIdentifier DeleteDBSecurityGroup = new ActionIdentifier("rds:DeleteDBSecurityGroup");

		public static readonly ActionIdentifier DeleteDBSnapshot = new ActionIdentifier("rds:DeleteDBSnapshot");

		public static readonly ActionIdentifier DeleteDBSubnetGroup = new ActionIdentifier("rds:DeleteDBSubnetGroup");

		public static readonly ActionIdentifier DeleteEventSubscription = new ActionIdentifier("rds:DeleteEventSubscription");

		public static readonly ActionIdentifier DeleteOptionGroup = new ActionIdentifier("rds:DeleteOptionGroup");

		public static readonly ActionIdentifier DescribeEngineDefaultParameters = new ActionIdentifier("rds:DescribeEngineDefaultParameters");

		public static readonly ActionIdentifier DescribeDBInstances = new ActionIdentifier("rds:DescribeDBInstances");

		public static readonly ActionIdentifier DescribeDBLogFiles = new ActionIdentifier("rds:DescribeDBLogFiles");

		public static readonly ActionIdentifier DescribeDBParameterGroups = new ActionIdentifier("rds:DescribeDBParameterGroups");

		public static readonly ActionIdentifier DescribeDBParameters = new ActionIdentifier("rds:DescribeDBParameters");

		public static readonly ActionIdentifier DescribeDBSecurityGroups = new ActionIdentifier("rds:DescribeDBSecurityGroups");

		public static readonly ActionIdentifier DescribeDBSnapshots = new ActionIdentifier("rds:DescribeDBSnapshots");

		public static readonly ActionIdentifier DescribeDBEngineVersions = new ActionIdentifier("rds:DescribeDBEngineVersions");

		public static readonly ActionIdentifier DescribeDBSubnetGroups = new ActionIdentifier("rds:DescribeDBSubnetGroups");

		public static readonly ActionIdentifier DescribeEventCategories = new ActionIdentifier("rds:DescribeEventCategories");

		public static readonly ActionIdentifier DescribeEvents = new ActionIdentifier("rds:DescribeEvents");

		public static readonly ActionIdentifier DescribeEventSubscriptions = new ActionIdentifier("rds:DescribeEventSubscriptions");

		public static readonly ActionIdentifier DescribeOptionGroups = new ActionIdentifier("rds:DescribeOptionGroups");

		public static readonly ActionIdentifier DescribeOptionGroupOptions = new ActionIdentifier("rds:DescribeOptionGroupOptions");

		public static readonly ActionIdentifier DescribeOrderableDBInstanceOptions = new ActionIdentifier("rds:DescribeOrderableDBInstanceOptions");

		public static readonly ActionIdentifier DescribeReservedDBInstances = new ActionIdentifier("rds:DescribeReservedDBInstances");

		public static readonly ActionIdentifier DescribeReservedDBInstancesOfferings = new ActionIdentifier("rds:DescribeReservedDBInstancesOfferings");

		public static readonly ActionIdentifier DownloadDBLogFilePortion = new ActionIdentifier("rds:DownloadDBLogFilePortion");

		public static readonly ActionIdentifier ListTagsForResource = new ActionIdentifier("rds:ListTagsForResource");

		public static readonly ActionIdentifier ModifyDBInstance = new ActionIdentifier("rds:ModifyDBInstance");

		public static readonly ActionIdentifier ModifyDBParameterGroup = new ActionIdentifier("rds:ModifyDBParameterGroup");

		public static readonly ActionIdentifier ModifyDBSubnetGroup = new ActionIdentifier("rds:ModifyDBSubnetGroup");

		public static readonly ActionIdentifier ModifyEventSubscription = new ActionIdentifier("rds:ModifyEventSubscription");

		public static readonly ActionIdentifier ModifyOptionGroup = new ActionIdentifier("rds:ModifyOptionGroup");

		public static readonly ActionIdentifier PromoteReadReplica = new ActionIdentifier("rds:PromoteReadReplica");

		public static readonly ActionIdentifier PurchaseReservedDBInstancesOffering = new ActionIdentifier("rds:PurchaseReservedDBInstancesOffering");

		public static readonly ActionIdentifier RebootDBInstance = new ActionIdentifier("rds:RebootDBInstance");

		public static readonly ActionIdentifier RemoveSourceIdentifierFromSubscription = new ActionIdentifier("rds:RemoveSourceIdentifierFromSubscription");

		public static readonly ActionIdentifier RemoveTagsFromResource = new ActionIdentifier("rds:RemoveTagsFromResource");

		public static readonly ActionIdentifier RestoreDBInstanceFromDBSnapshot = new ActionIdentifier("rds:RestoreDBInstanceFromDBSnapshot");

		public static readonly ActionIdentifier RestoreDBInstanceToPointInTime = new ActionIdentifier("rds:RestoreDBInstanceToPointInTime");

		public static readonly ActionIdentifier ResetDBParameterGroup = new ActionIdentifier("rds:ResetDBParameterGroup");

		public static readonly ActionIdentifier RevokeDBSecurityGroupIngress = new ActionIdentifier("rds:RevokeDBSecurityGroupIngress");
	}
	public static class RedshiftActionIdentifiers
	{
		public static readonly ActionIdentifier AllRedshiftActions = new ActionIdentifier("redshift:*");

		public static readonly ActionIdentifier AuthorizeClusterSecurityGroupIngress = new ActionIdentifier("redshift:AuthorizeClusterSecurityGroupIngress");

		public static readonly ActionIdentifier AuthorizeSnapshotAccess = new ActionIdentifier("redshift:AuthorizeSnapshotAccess");

		public static readonly ActionIdentifier CopyClusterSnapshot = new ActionIdentifier("redshift:CopyClusterSnapshot");

		public static readonly ActionIdentifier CreateCluster = new ActionIdentifier("redshift:CreateCluster");

		public static readonly ActionIdentifier CreateClusterParameterGroup = new ActionIdentifier("redshift:CreateClusterParameterGroup");

		public static readonly ActionIdentifier CreateClusterSecurityGroup = new ActionIdentifier("redshift:CreateClusterSecurityGroup");

		public static readonly ActionIdentifier CreateClusterSnapshot = new ActionIdentifier("redshift:CreateClusterSnapshot");

		public static readonly ActionIdentifier CreateClusterSubnetGroup = new ActionIdentifier("redshift:CreateClusterSubnetGroup");

		public static readonly ActionIdentifier CreateEventSubscription = new ActionIdentifier("redshift:CreateEventSubscription");

		public static readonly ActionIdentifier CreateHsmClientCertificate = new ActionIdentifier("redshift:CreateHsmClientCertificate");

		public static readonly ActionIdentifier CreateHsmConfiguration = new ActionIdentifier("redshift:CreateHsmConfiguration");

		public static readonly ActionIdentifier DeleteCluster = new ActionIdentifier("redshift:DeleteCluster");

		public static readonly ActionIdentifier DeleteClusterParameterGroup = new ActionIdentifier("redshift:DeleteClusterParameterGroup");

		public static readonly ActionIdentifier DeleteClusterSecurityGroup = new ActionIdentifier("redshift:DeleteClusterSecurityGroup");

		public static readonly ActionIdentifier DeleteClusterSnapshot = new ActionIdentifier("redshift:DeleteClusterSnapshot");

		public static readonly ActionIdentifier DeleteClusterSubnetGroup = new ActionIdentifier("redshift:DeleteClusterSubnetGroup");

		public static readonly ActionIdentifier DeleteEventSubscription = new ActionIdentifier("redshift:DeleteEventSubscription");

		public static readonly ActionIdentifier DeleteHsmClientCertificate = new ActionIdentifier("redshift:DeleteHsmClientCertificate");

		public static readonly ActionIdentifier DeleteHsmConfiguration = new ActionIdentifier("redshift:DeleteHsmConfiguration");

		public static readonly ActionIdentifier DescribeClusterParameterGroups = new ActionIdentifier("redshift:DescribeClusterParameterGroups");

		public static readonly ActionIdentifier DescribeClusterParameters = new ActionIdentifier("redshift:DescribeClusterParameters");

		public static readonly ActionIdentifier DescribeClusterSecurityGroups = new ActionIdentifier("redshift:DescribeClusterSecurityGroups");

		public static readonly ActionIdentifier DescribeClusterSnapshots = new ActionIdentifier("redshift:DescribeClusterSnapshots");

		public static readonly ActionIdentifier DescribeClusterSubnetGroups = new ActionIdentifier("redshift:DescribeClusterSubnetGroups");

		public static readonly ActionIdentifier DescribeClusterVersions = new ActionIdentifier("redshift:DescribeClusterVersions");

		public static readonly ActionIdentifier DescribeClusters = new ActionIdentifier("redshift:DescribeClusters");

		public static readonly ActionIdentifier DescribeDefaultClusterParameters = new ActionIdentifier("redshift:DescribeDefaultClusterParameters");

		public static readonly ActionIdentifier DescribeEventCategories = new ActionIdentifier("redshift:DescribeEventCategories");

		public static readonly ActionIdentifier DescribeEventSubscriptions = new ActionIdentifier("redshift:DescribeEventSubscriptions");

		public static readonly ActionIdentifier DescribeEvents = new ActionIdentifier("redshift:DescribeEvents");

		public static readonly ActionIdentifier DescribeHsmClientCertificates = new ActionIdentifier("redshift:DescribeHsmClientCertificates");

		public static readonly ActionIdentifier DescribeHsmConfigurations = new ActionIdentifier("redshift:DescribeHsmConfigurations");

		public static readonly ActionIdentifier DescribeLoggingStatus = new ActionIdentifier("redshift:DescribeLoggingStatus");

		public static readonly ActionIdentifier DescribeOrderableClusterOptions = new ActionIdentifier("redshift:DescribeOrderableClusterOptions");

		public static readonly ActionIdentifier DescribeReservedNodeOfferings = new ActionIdentifier("redshift:DescribeReservedNodeOfferings");

		public static readonly ActionIdentifier DescribeReservedNodes = new ActionIdentifier("redshift:DescribeReservedNodes");

		public static readonly ActionIdentifier DescribeResize = new ActionIdentifier("redshift:DescribeResize");

		public static readonly ActionIdentifier DisableLogging = new ActionIdentifier("redshift:DisableLogging");

		public static readonly ActionIdentifier DisableSnapshotCopy = new ActionIdentifier("redshift:DisableSnapshotCopy");

		public static readonly ActionIdentifier EnableLogging = new ActionIdentifier("redshift:EnableLogging");

		public static readonly ActionIdentifier EnableSnapshotCopy = new ActionIdentifier("redshift:EnableSnapshotCopy");

		public static readonly ActionIdentifier ModifyCluster = new ActionIdentifier("redshift:ModifyCluster");

		public static readonly ActionIdentifier ModifyClusterParameterGroup = new ActionIdentifier("redshift:ModifyClusterParameterGroup");

		public static readonly ActionIdentifier ModifyClusterSubnetGroup = new ActionIdentifier("redshift:ModifyClusterSubnetGroup");

		public static readonly ActionIdentifier ModifyEventSubscription = new ActionIdentifier("redshift:ModifyEventSubscription");

		public static readonly ActionIdentifier ModifySnapshotCopyRetentionPeriod = new ActionIdentifier("redshift:ModifySnapshotCopyRetentionPeriod");

		public static readonly ActionIdentifier PurchaseReservedNodeOffering = new ActionIdentifier("redshift:PurchaseReservedNodeOffering");

		public static readonly ActionIdentifier RebootCluster = new ActionIdentifier("redshift:RebootCluster");

		public static readonly ActionIdentifier ResetClusterParameterGroup = new ActionIdentifier("redshift:ResetClusterParameterGroup");

		public static readonly ActionIdentifier RestoreFromClusterSnapshot = new ActionIdentifier("redshift:RestoreFromClusterSnapshot");

		public static readonly ActionIdentifier RevokeClusterSecurityGroupIngress = new ActionIdentifier("redshift:RevokeClusterSecurityGroupIngress");

		public static readonly ActionIdentifier RevokeSnapshotAccess = new ActionIdentifier("redshift:RevokeSnapshotAccess");

		public static readonly ActionIdentifier RotateEncryptionKey = new ActionIdentifier("redshift:RotateEncryptionKey");

		public static readonly ActionIdentifier ViewQueriesInConsole = new ActionIdentifier("redshift:ViewQueriesInConsole");
	}
	public static class Route53ActionIdentifiers
	{
		public static readonly ActionIdentifier AllRoute53Actions = new ActionIdentifier("route53:*");

		public static readonly ActionIdentifier ChangeResourceRecordSets = new ActionIdentifier("route53:ChangeResourceRecordSets");

		public static readonly ActionIdentifier CreateHostedZone = new ActionIdentifier("route53:CreateHostedZone");

		public static readonly ActionIdentifier DeleteHostedZone = new ActionIdentifier("route53:DeleteHostedZone");

		public static readonly ActionIdentifier GetChange = new ActionIdentifier("route53:GetChange");

		public static readonly ActionIdentifier GetHostedZone = new ActionIdentifier("route53:GetHostedZone");

		public static readonly ActionIdentifier ListHostedZones = new ActionIdentifier("route53:ListHostedZones");

		public static readonly ActionIdentifier ListResourceRecordSets = new ActionIdentifier("route53:ListResourceRecordSets");
	}
	public static class S3ActionIdentifiers
	{
		public static readonly ActionIdentifier AllS3Actions = new ActionIdentifier("s3:*");

		public static readonly ActionIdentifier AbortMultipartUpload = new ActionIdentifier("s3:AbortMultipartUpload");

		public static readonly ActionIdentifier CreateBucket = new ActionIdentifier("s3:CreateBucket");

		public static readonly ActionIdentifier DeleteBucket = new ActionIdentifier("s3:DeleteBucket");

		public static readonly ActionIdentifier DeleteBucketPolicy = new ActionIdentifier("s3:DeleteBucketPolicy");

		public static readonly ActionIdentifier DeleteBucketWebsite = new ActionIdentifier("s3:DeleteBucketWebsite");

		public static readonly ActionIdentifier DeleteObject = new ActionIdentifier("s3:DeleteObject");

		public static readonly ActionIdentifier DeleteObjectVersion = new ActionIdentifier("s3:DeleteObjectVersion");

		public static readonly ActionIdentifier GetBucketAcl = new ActionIdentifier("s3:GetBucketAcl");

		public static readonly ActionIdentifier GetBucketCORS = new ActionIdentifier("s3:GetBucketCORS");

		public static readonly ActionIdentifier GetBucketLocation = new ActionIdentifier("s3:GetBucketLocation");

		public static readonly ActionIdentifier GetBucketLogging = new ActionIdentifier("s3:GetBucketLogging");

		public static readonly ActionIdentifier GetBucketNotification = new ActionIdentifier("s3:GetBucketNotification");

		public static readonly ActionIdentifier GetBucketPolicy = new ActionIdentifier("s3:GetBucketPolicy");

		public static readonly ActionIdentifier GetBucketRequestPayment = new ActionIdentifier("s3:GetBucketRequestPayment");

		public static readonly ActionIdentifier GetBucketTagging = new ActionIdentifier("s3:GetBucketTagging");

		public static readonly ActionIdentifier GetBucketVersioning = new ActionIdentifier("s3:GetBucketVersioning");

		public static readonly ActionIdentifier GetBucketWebsite = new ActionIdentifier("s3:GetBucketWebsite");

		public static readonly ActionIdentifier GetLifecycleConfiguration = new ActionIdentifier("s3:GetLifecycleConfiguration");

		public static readonly ActionIdentifier GetObject = new ActionIdentifier("s3:GetObject");

		public static readonly ActionIdentifier GetObjectAcl = new ActionIdentifier("s3:GetObjectAcl");

		public static readonly ActionIdentifier GetObjectTorrent = new ActionIdentifier("s3:GetObjectTorrent");

		public static readonly ActionIdentifier GetObjectVersion = new ActionIdentifier("s3:GetObjectVersion");

		public static readonly ActionIdentifier GetObjectVersionAcl = new ActionIdentifier("s3:GetObjectVersionAcl");

		public static readonly ActionIdentifier GetObjectVersionTorrent = new ActionIdentifier("s3:GetObjectVersionTorrent");

		public static readonly ActionIdentifier ListAllMyBuckets = new ActionIdentifier("s3:ListAllMyBuckets");

		public static readonly ActionIdentifier ListBucket = new ActionIdentifier("s3:ListBucket");

		public static readonly ActionIdentifier ListBucketMultipartUploads = new ActionIdentifier("s3:ListBucketMultipartUploads");

		public static readonly ActionIdentifier ListBucketVersions = new ActionIdentifier("s3:ListBucketVersions");

		public static readonly ActionIdentifier ListMultipartUploadParts = new ActionIdentifier("s3:ListMultipartUploadParts");

		public static readonly ActionIdentifier PutBucketAcl = new ActionIdentifier("s3:PutBucketAcl");

		public static readonly ActionIdentifier PutBucketCORS = new ActionIdentifier("s3:PutBucketCORS");

		public static readonly ActionIdentifier PutBucketLogging = new ActionIdentifier("s3:PutBucketLogging");

		public static readonly ActionIdentifier PutBucketNotification = new ActionIdentifier("s3:PutBucketNotification");

		public static readonly ActionIdentifier PutBucketPolicy = new ActionIdentifier("s3:PutBucketPolicy");

		public static readonly ActionIdentifier PutBucketRequestPayment = new ActionIdentifier("s3:PutBucketRequestPayment");

		public static readonly ActionIdentifier PutBucketTagging = new ActionIdentifier("s3:PutBucketTagging");

		public static readonly ActionIdentifier PutBucketVersioning = new ActionIdentifier("s3:PutBucketVersioning");

		public static readonly ActionIdentifier PutBucketWebsite = new ActionIdentifier("s3:PutBucketWebsite");

		public static readonly ActionIdentifier PutLifecycleConfiguration = new ActionIdentifier("s3:PutLifecycleConfiguration");

		public static readonly ActionIdentifier PutObject = new ActionIdentifier("s3:PutObject");

		public static readonly ActionIdentifier PutObjectAcl = new ActionIdentifier("s3:PutObjectAcl");

		public static readonly ActionIdentifier PutObjectVersionAcl = new ActionIdentifier("s3:PutObjectVersionAcl");

		public static readonly ActionIdentifier RestoreObject = new ActionIdentifier("s3:RestoreObject");
	}
	public static class SecurityTokenServiceActionIdentifiers
	{
		public static readonly ActionIdentifier AllSecurityTokenServiceActions = new ActionIdentifier("sts:*");

		public static readonly ActionIdentifier GetFederationToken = new ActionIdentifier("sts:GetFederationToken");

		public static readonly ActionIdentifier AssumeRole = new ActionIdentifier("sts:AssumeRole");
	}
	public static class SESActionIdentifiers
	{
		public static readonly ActionIdentifier AllSESActions = new ActionIdentifier("ses:*");

		public static readonly ActionIdentifier DeleteIdentity = new ActionIdentifier("ses:DeleteIdentity");

		public static readonly ActionIdentifier DeleteVerifiedEmailAddress = new ActionIdentifier("ses:DeleteVerifiedEmailAddress");

		public static readonly ActionIdentifier GetIdentityDkimAttributes = new ActionIdentifier("ses:GetIdentityDkimAttributes");

		public static readonly ActionIdentifier GetIdentityNotificationAttributes = new ActionIdentifier("ses:GetIdentityNotificationAttributes");

		public static readonly ActionIdentifier GetIdentityVerificationAttributes = new ActionIdentifier("ses:GetIdentityVerificationAttributes");

		public static readonly ActionIdentifier GetSendQuota = new ActionIdentifier("ses:GetSendQuota");

		public static readonly ActionIdentifier GetSendStatistics = new ActionIdentifier("ses:GetSendStatistics");

		public static readonly ActionIdentifier ListIdentities = new ActionIdentifier("ses:ListIdentities");

		public static readonly ActionIdentifier ListVerifiedEmailAddresses = new ActionIdentifier("ses:ListVerifiedEmailAddresses");

		public static readonly ActionIdentifier SendEmail = new ActionIdentifier("ses:SendEmail");

		public static readonly ActionIdentifier SendRawEmail = new ActionIdentifier("ses:SendRawEmail");

		public static readonly ActionIdentifier SetIdentityDkimEnabled = new ActionIdentifier("ses:SetIdentityDkimEnabled");

		public static readonly ActionIdentifier SetIdentityNotificationTopic = new ActionIdentifier("ses:SetIdentityNotificationTopic");

		public static readonly ActionIdentifier SetIdentityFeedbackForwardingEnabled = new ActionIdentifier("ses:SetIdentityFeedbackForwardingEnabled");

		public static readonly ActionIdentifier VerifyDomainDkim = new ActionIdentifier("ses:VerifyDomainDkim");

		public static readonly ActionIdentifier VerifyDomainIdentity = new ActionIdentifier("ses:VerifyDomainIdentity");

		public static readonly ActionIdentifier VerifyEmailAddress = new ActionIdentifier("ses:VerifyEmailAddress");

		public static readonly ActionIdentifier VerifyEmailIdentity = new ActionIdentifier("ses:VerifyEmailIdentity");
	}
	public static class SimpleDBActionIdentifiers
	{
		public static readonly ActionIdentifier AllSimpleDBActions = new ActionIdentifier("sdb:*");

		public static readonly ActionIdentifier BatchDeleteAttributes = new ActionIdentifier("sdb:BatchDeleteAttributes");

		public static readonly ActionIdentifier BatchPutAttributes = new ActionIdentifier("sdb:BatchPutAttributes");

		public static readonly ActionIdentifier CreateDomain = new ActionIdentifier("sdb:CreateDomain");

		public static readonly ActionIdentifier DeleteAttributes = new ActionIdentifier("sdb:DeleteAttributes");

		public static readonly ActionIdentifier DeleteDomain = new ActionIdentifier("sdb:DeleteDomain");

		public static readonly ActionIdentifier DomainMetadata = new ActionIdentifier("sdb:DomainMetadata");

		public static readonly ActionIdentifier GetAttributes = new ActionIdentifier("sdb:GetAttributes");

		public static readonly ActionIdentifier ListDomains = new ActionIdentifier("sdb:ListDomains");

		public static readonly ActionIdentifier PutAttributes = new ActionIdentifier("sdb:PutAttributes");

		public static readonly ActionIdentifier Select = new ActionIdentifier("sdb:Select");
	}
	public static class SimpleWorkflowServiceActionIdentifiers
	{
		public static readonly ActionIdentifier AllSimpleWorkflowServiceActions = new ActionIdentifier("swf:*");

		public static readonly ActionIdentifier CancelTimer = new ActionIdentifier("swf:CancelTimer");

		public static readonly ActionIdentifier CancelWorkflowExecution = new ActionIdentifier("swf:CancelWorkflowExecution");

		public static readonly ActionIdentifier CompleteWorkflowExecution = new ActionIdentifier("swf:CompleteWorkflowExecution");

		public static readonly ActionIdentifier ContinueAsNewWorkflowExecution = new ActionIdentifier("swf:ContinueAsNewWorkflowExecution");

		public static readonly ActionIdentifier CountClosedWorkflowExecutions = new ActionIdentifier("swf:CountClosedWorkflowExecutions");

		public static readonly ActionIdentifier CountOpenWorkflowExecutions = new ActionIdentifier("swf:CountOpenWorkflowExecutions");

		public static readonly ActionIdentifier CountPendingActivityTasks = new ActionIdentifier("swf:CountPendingActivityTasks");

		public static readonly ActionIdentifier CountPendingDecisionTasks = new ActionIdentifier("swf:CountPendingDecisionTasks");

		public static readonly ActionIdentifier DeprecateActivityType = new ActionIdentifier("swf:DeprecateActivityType");

		public static readonly ActionIdentifier DeprecateDomain = new ActionIdentifier("swf:DeprecateDomain");

		public static readonly ActionIdentifier DeprecateWorkflowType = new ActionIdentifier("swf:DeprecateWorkflowType");

		public static readonly ActionIdentifier DescribeActivityType = new ActionIdentifier("swf:DescribeActivityType");

		public static readonly ActionIdentifier DescribeDomain = new ActionIdentifier("swf:DescribeDomain");

		public static readonly ActionIdentifier DescribeWorkflowExecution = new ActionIdentifier("swf:DescribeWorkflowExecution");

		public static readonly ActionIdentifier DescribeWorkflowType = new ActionIdentifier("swf:DescribeWorkflowType");

		public static readonly ActionIdentifier FailWorkflowExecution = new ActionIdentifier("swf:FailWorkflowExecution");

		public static readonly ActionIdentifier GetWorkflowExecutionHistory = new ActionIdentifier("swf:GetWorkflowExecutionHistory");

		public static readonly ActionIdentifier ListActivityTypes = new ActionIdentifier("swf:ListActivityTypes");

		public static readonly ActionIdentifier ListClosedWorkflowExecutions = new ActionIdentifier("swf:ListClosedWorkflowExecutions");

		public static readonly ActionIdentifier ListDomains = new ActionIdentifier("swf:ListDomains");

		public static readonly ActionIdentifier ListOpenWorkflowExecutions = new ActionIdentifier("swf:ListOpenWorkflowExecutions");

		public static readonly ActionIdentifier ListWorkflowTypes = new ActionIdentifier("swf:ListWorkflowTypes");

		public static readonly ActionIdentifier PollForActivityTask = new ActionIdentifier("swf:PollForActivityTask");

		public static readonly ActionIdentifier PollForDecisionTask = new ActionIdentifier("swf:PollForDecisionTask");

		public static readonly ActionIdentifier RecordActivityTaskHeartbeat = new ActionIdentifier("swf:RecordActivityTaskHeartbeat");

		public static readonly ActionIdentifier RecordMarker = new ActionIdentifier("swf:RecordMarker");

		public static readonly ActionIdentifier RegisterActivityType = new ActionIdentifier("swf:RegisterActivityType");

		public static readonly ActionIdentifier RegisterDomain = new ActionIdentifier("swf:RegisterDomain");

		public static readonly ActionIdentifier RegisterWorkflowType = new ActionIdentifier("swf:RegisterWorkflowType");

		public static readonly ActionIdentifier RequestCancelActivityTask = new ActionIdentifier("swf:RequestCancelActivityTask");

		public static readonly ActionIdentifier RequestCancelExternalWorkflowExecution = new ActionIdentifier("swf:RequestCancelExternalWorkflowExecution");

		public static readonly ActionIdentifier RequestCancelWorkflowExecution = new ActionIdentifier("swf:RequestCancelWorkflowExecution");

		public static readonly ActionIdentifier RespondActivityTaskCanceled = new ActionIdentifier("swf:RespondActivityTaskCanceled");

		public static readonly ActionIdentifier RespondActivityTaskCompleted = new ActionIdentifier("swf:RespondActivityTaskCompleted");

		public static readonly ActionIdentifier RespondActivityTaskFailed = new ActionIdentifier("swf:RespondActivityTaskFailed");

		public static readonly ActionIdentifier RespondDecisionTaskCompleted = new ActionIdentifier("swf:RespondDecisionTaskCompleted");

		public static readonly ActionIdentifier ScheduleActivityTask = new ActionIdentifier("swf:ScheduleActivityTask");

		public static readonly ActionIdentifier SignalExternalWorkflowExecution = new ActionIdentifier("swf:SignalExternalWorkflowExecution");

		public static readonly ActionIdentifier SignalWorkflowExecution = new ActionIdentifier("swf:SignalWorkflowExecution");

		public static readonly ActionIdentifier StartChildWorkflowExecution = new ActionIdentifier("swf:StartChildWorkflowExecution");

		public static readonly ActionIdentifier StartTimer = new ActionIdentifier("swf:StartTimer");

		public static readonly ActionIdentifier StartWorkflowExecution = new ActionIdentifier("swf:StartWorkflowExecution");

		public static readonly ActionIdentifier TerminateWorkflowExecution = new ActionIdentifier("swf:TerminateWorkflowExecution");
	}
	public static class SNSActionIdentifiers
	{
		public static readonly ActionIdentifier AllSNSActions = new ActionIdentifier("sns:*");

		public static readonly ActionIdentifier AddPermission = new ActionIdentifier("sns:AddPermission");

		public static readonly ActionIdentifier ConfirmSubscription = new ActionIdentifier("sns:ConfirmSubscription");

		public static readonly ActionIdentifier CreatePlatformApplication = new ActionIdentifier("sns:CreatePlatformApplication");

		public static readonly ActionIdentifier CreatePlatformEndpoint = new ActionIdentifier("sns:CreatePlatformEndpoint");

		public static readonly ActionIdentifier CreateTopic = new ActionIdentifier("sns:CreateTopic");

		public static readonly ActionIdentifier DeleteEndpoint = new ActionIdentifier("sns:DeleteEndpoint");

		public static readonly ActionIdentifier DeletePlatformApplication = new ActionIdentifier("sns:DeletePlatformApplication");

		public static readonly ActionIdentifier DeleteTopic = new ActionIdentifier("sns:DeleteTopic");

		public static readonly ActionIdentifier GetEndpointAttributes = new ActionIdentifier("sns:GetEndpointAttributes");

		public static readonly ActionIdentifier GetPlatformApplicationAttributes = new ActionIdentifier("sns:GetPlatformApplicationAttributes");

		public static readonly ActionIdentifier GetSubscriptionAttributes = new ActionIdentifier("sns:GetSubscriptionAttributes");

		public static readonly ActionIdentifier GetTopicAttributes = new ActionIdentifier("sns:GetTopicAttributes");

		public static readonly ActionIdentifier ListEndpointsByPlatformApplication = new ActionIdentifier("sns:ListEndpointsByPlatformApplication");

		public static readonly ActionIdentifier ListPlatformApplications = new ActionIdentifier("sns:ListPlatformApplications");

		public static readonly ActionIdentifier ListSubscriptions = new ActionIdentifier("sns:ListSubscriptions");

		public static readonly ActionIdentifier ListSubscriptionsByTopic = new ActionIdentifier("sns:ListSubscriptionsByTopic");

		public static readonly ActionIdentifier ListTopics = new ActionIdentifier("sns:ListTopics");

		public static readonly ActionIdentifier Publish = new ActionIdentifier("sns:Publish");

		public static readonly ActionIdentifier RemovePermission = new ActionIdentifier("sns:RemovePermission");

		public static readonly ActionIdentifier SetEndpointAttributes = new ActionIdentifier("sns:SetEndpointAttributes");

		public static readonly ActionIdentifier SetPlatformApplicationAttributes = new ActionIdentifier("sns:SetPlatformApplicationAttributes");

		public static readonly ActionIdentifier SetSubscriptionAttributes = new ActionIdentifier("sns:SetSubscriptionAttributes");

		public static readonly ActionIdentifier SetTopicAttributes = new ActionIdentifier("sns:SetTopicAttributes");

		public static readonly ActionIdentifier Subscribe = new ActionIdentifier("sns:Subscribe");

		public static readonly ActionIdentifier Unsubscribe = new ActionIdentifier("sns:Unsubscribe");
	}
	public static class SQSActionIdentifiers
	{
		public static readonly ActionIdentifier AllSQSActions = new ActionIdentifier("sqs:*");

		public static readonly ActionIdentifier AddPermission = new ActionIdentifier("sqs:AddPermission");

		public static readonly ActionIdentifier ChangeMessageVisibility = new ActionIdentifier("sqs:ChangeMessageVisibility");

		public static readonly ActionIdentifier CreateQueue = new ActionIdentifier("sqs:CreateQueue");

		public static readonly ActionIdentifier DeleteMessage = new ActionIdentifier("sqs:DeleteMessage");

		public static readonly ActionIdentifier DeleteQueue = new ActionIdentifier("sqs:DeleteQueue");

		public static readonly ActionIdentifier GetQueueAttributes = new ActionIdentifier("sqs:GetQueueAttributes");

		public static readonly ActionIdentifier GetQueueUrl = new ActionIdentifier("sqs:GetQueueUrl");

		public static readonly ActionIdentifier ListQueues = new ActionIdentifier("sqs:ListQueues");

		public static readonly ActionIdentifier ReceiveMessage = new ActionIdentifier("sqs:ReceiveMessage");

		public static readonly ActionIdentifier RemovePermission = new ActionIdentifier("sqs:RemovePermission");

		public static readonly ActionIdentifier SendMessage = new ActionIdentifier("sqs:SendMessage");

		public static readonly ActionIdentifier SetQueueAttributes = new ActionIdentifier("sqs:SetQueueAttributes");
	}
	public static class StorageGatewayActionIdentifiers
	{
		public static readonly ActionIdentifier AllStorageGatewayActions = new ActionIdentifier("storagegateway:*");

		public static readonly ActionIdentifier ActivateGateway = new ActionIdentifier("storagegateway:ActivateGateway");

		public static readonly ActionIdentifier AddCache = new ActionIdentifier("storagegateway:AddCache");

		public static readonly ActionIdentifier AddUploadBuffer = new ActionIdentifier("storagegateway:AddUploadBuffer");

		public static readonly ActionIdentifier AddWorkingStorage = new ActionIdentifier("storagegateway:AddWorkingStorage");

		public static readonly ActionIdentifier CancelArchival = new ActionIdentifier("storagegateway:CancelArchival");

		public static readonly ActionIdentifier CancelRetrieval = new ActionIdentifier("storagegateway:CancelRetrieval");

		public static readonly ActionIdentifier CreateCachediSCSIVolume = new ActionIdentifier("storagegateway:CreateCachediSCSIVolume");

		public static readonly ActionIdentifier CreateSnapshot = new ActionIdentifier("storagegateway:CreateSnapshot");

		public static readonly ActionIdentifier CreateSnapshotFromVolumeRecoveryPoint = new ActionIdentifier("storagegateway:CreateSnapshotFromVolumeRecoveryPoint");

		public static readonly ActionIdentifier CreateStorediSCSIVolume = new ActionIdentifier("storagegateway:CreateStorediSCSIVolume");

		public static readonly ActionIdentifier CreateTapes = new ActionIdentifier("storagegateway:CreateTapes");

		public static readonly ActionIdentifier DeleteBandwidthRateLimit = new ActionIdentifier("storagegateway:DeleteBandwidthRateLimit");

		public static readonly ActionIdentifier DeleteChapCredentials = new ActionIdentifier("storagegateway:DeleteChapCredentials");

		public static readonly ActionIdentifier DeleteGateway = new ActionIdentifier("storagegateway:DeleteGateway");

		public static readonly ActionIdentifier DeleteSnapshotSchedule = new ActionIdentifier("storagegateway:DeleteSnapshotSchedule");

		public static readonly ActionIdentifier DeleteTape = new ActionIdentifier("storagegateway:DeleteTape");

		public static readonly ActionIdentifier DeleteTapeArchive = new ActionIdentifier("storagegateway:DeleteTapeArchive");

		public static readonly ActionIdentifier DeleteVolume = new ActionIdentifier("storagegateway:DeleteVolume");

		public static readonly ActionIdentifier DescribeBandwidthRateLimit = new ActionIdentifier("storagegateway:DescribeBandwidthRateLimit");

		public static readonly ActionIdentifier DescribeCache = new ActionIdentifier("storagegateway:DescribeCache");

		public static readonly ActionIdentifier DescribeCachediSCSIVolumes = new ActionIdentifier("storagegateway:DescribeCachediSCSIVolumes");

		public static readonly ActionIdentifier DescribeChapCredentials = new ActionIdentifier("storagegateway:DescribeChapCredentials");

		public static readonly ActionIdentifier DescribeGatewayInformation = new ActionIdentifier("storagegateway:DescribeGatewayInformation");

		public static readonly ActionIdentifier DescribeMaintenanceStartTime = new ActionIdentifier("storagegateway:DescribeMaintenanceStartTime");

		public static readonly ActionIdentifier DescribeSnapshotSchedule = new ActionIdentifier("storagegateway:DescribeSnapshotSchedule");

		public static readonly ActionIdentifier DescribeStorediSCSIVolumes = new ActionIdentifier("storagegateway:DescribeStorediSCSIVolumes");

		public static readonly ActionIdentifier DescribeTapeArchives = new ActionIdentifier("storagegateway:DescribeTapeArchives");

		public static readonly ActionIdentifier DescribeTapeRecoveryPoints = new ActionIdentifier("storagegateway:DescribeTapeRecoveryPoints");

		public static readonly ActionIdentifier DescribeTapes = new ActionIdentifier("storagegateway:DescribeTapes");

		public static readonly ActionIdentifier DescribeUploadBuffer = new ActionIdentifier("storagegateway:DescribeUploadBuffer");

		public static readonly ActionIdentifier DescribeVTLDevices = new ActionIdentifier("storagegateway:DescribeVTLDevices");

		public static readonly ActionIdentifier DescribeWorkingStorage = new ActionIdentifier("storagegateway:DescribeWorkingStorage");

		public static readonly ActionIdentifier DisableGateway = new ActionIdentifier("storagegateway:DisableGateway");

		public static readonly ActionIdentifier ListGateways = new ActionIdentifier("storagegateway:ListGateways");

		public static readonly ActionIdentifier ListLocalDisks = new ActionIdentifier("storagegateway:ListLocalDisks");

		public static readonly ActionIdentifier ListVolumeRecoveryPoints = new ActionIdentifier("storagegateway:ListVolumeRecoveryPoints");

		public static readonly ActionIdentifier ListVolumes = new ActionIdentifier("storagegateway:ListVolumes");

		public static readonly ActionIdentifier RetrieveTapeArchive = new ActionIdentifier("storagegateway:RetrieveTapeArchive");

		public static readonly ActionIdentifier RetrieveTapeRecoveryPoint = new ActionIdentifier("storagegateway:RetrieveTapeRecoveryPoint");

		public static readonly ActionIdentifier ShutdownGateway = new ActionIdentifier("storagegateway:ShutdownGateway");

		public static readonly ActionIdentifier StartGateway = new ActionIdentifier("storagegateway:StartGateway");

		public static readonly ActionIdentifier UpdateBandwidthRateLimit = new ActionIdentifier("storagegateway:UpdateBandwidthRateLimit");

		public static readonly ActionIdentifier UpdateChapCredentials = new ActionIdentifier("storagegateway:UpdateChapCredentials");

		public static readonly ActionIdentifier UpdateGatewayInformation = new ActionIdentifier("storagegateway:UpdateGatewayInformation");

		public static readonly ActionIdentifier UpdateGatewaySoftwareNow = new ActionIdentifier("storagegateway:UpdateGatewaySoftwareNow");

		public static readonly ActionIdentifier UpdateMaintenanceStartTime = new ActionIdentifier("storagegateway:UpdateMaintenanceStartTime");

		public static readonly ActionIdentifier UpdateSnapshotSchedule = new ActionIdentifier("storagegateway:UpdateSnapshotSchedule");
	}
	public static class WhispersyncActionIdentifiers
	{
		public static readonly ActionIdentifier AllWhispersyncActions = new ActionIdentifier("whispersync:*");

		public static readonly ActionIdentifier GetDatamapUpdates = new ActionIdentifier("whispersync:GetDatamapUpdates");

		public static readonly ActionIdentifier PatchDatamapUpdates = new ActionIdentifier("whispersync:PatchDatamapUpdates");
	}
	public static class ZocaloActionIdentifiers
	{
		public static readonly ActionIdentifier AllZocaloActions = new ActionIdentifier("zocalo:*");

		public static readonly ActionIdentifier ActivateUser = new ActionIdentifier("zocalo:ActivateUser");

		public static readonly ActionIdentifier AddUserToGroup = new ActionIdentifier("zocalo:AddUserToGroup");

		public static readonly ActionIdentifier CheckAlias = new ActionIdentifier("zocalo:CheckAlias");

		public static readonly ActionIdentifier CreateInstance = new ActionIdentifier("zocalo:CreateInstance");

		public static readonly ActionIdentifier DeactivateUser = new ActionIdentifier("zocalo:DeactivateUser");

		public static readonly ActionIdentifier DeleteInstance = new ActionIdentifier("zocalo:DeleteInstance");

		public static readonly ActionIdentifier DeregisterDirectory = new ActionIdentifier("zocalo:DeregisterDirectory");

		public static readonly ActionIdentifier DescribeAvailableDirectories = new ActionIdentifier("zocalo:DescribeAvailableDirectories");

		public static readonly ActionIdentifier DescribeInstances = new ActionIdentifier("zocalo:DescribeInstances");

		public static readonly ActionIdentifier RegisterDirectory = new ActionIdentifier("zocalo:RegisterDirectory");

		public static readonly ActionIdentifier RemoveUserFromGroup = new ActionIdentifier("zocalo:RemoveUserFromGroup");

		public static readonly ActionIdentifier UpdateInstanceAlias = new ActionIdentifier("zocalo:UpdateInstanceAlias");
	}
}
