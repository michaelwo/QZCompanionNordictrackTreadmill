using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using Microsoft.Extensions.Configuration.Binder;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("Microsoft.Extensions.Configuration.Binder.Test, PublicKey=0024000004800000940000000602000000240000525341310004000001000100f33a29044fa9d740c9b3213a93e57c84b472c84e0b8a0e1ae48e67a9f8f6de9d5f7f3d52ac23e48ac51801f1dc950abe901da34d2a9e3baadb141a17c77ef3c565dd5ee5054b91cf63bb3c6ab83f72ab3aafe93d0fc3c2348b764fafb0b1c0733de51459aeab46580384bf9d74c4e28164b7cde247f891ba07891c9d872ad2bb")]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata("CommitHash", "b1d43cf8b49433054e33f4b6ab66cdffb6fa645e")]
[assembly: AssemblyMetadata("BuildNumber", "30799")]
[assembly: AssemblyCompany("Microsoft Corporation.")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Functionality to bind an object to data in configuration providers for Microsoft.Extensions.Configuration.")]
[assembly: AssemblyFileVersion("2.1.0.18136")]
[assembly: AssemblyInformationalVersion("2.1.0-rtm-30799")]
[assembly: AssemblyProduct("Microsoft .NET Extensions")]
[assembly: AssemblyTitle("Microsoft.Extensions.Configuration.Binder")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: AssemblyVersion("2.1.0.0")]
namespace Microsoft.Extensions.Configuration
{
	public class BinderOptions
	{
		public bool BindNonPublicProperties { get; set; }
	}
	public static class ConfigurationBinder
	{
		public static T Get<T>(this IConfiguration configuration)
		{
			return configuration.Get<T>(delegate
			{
			});
		}

		public static T Get<T>(this IConfiguration configuration, Action<BinderOptions> configureOptions)
		{
			if (configuration == null)
			{
				throw new ArgumentNullException("configuration");
			}
			object obj = configuration.Get(typeof(T), configureOptions);
			if (obj == null)
			{
				return default(T);
			}
			return (T)obj;
		}

		public static object Get(this IConfiguration configuration, Type type)
		{
			return configuration.Get(type, delegate
			{
			});
		}

		public static object Get(this IConfiguration configuration, Type type, Action<BinderOptions> configureOptions)
		{
			if (configuration == null)
			{
				throw new ArgumentNullException("configuration");
			}
			BinderOptions binderOptions = new BinderOptions();
			configureOptions?.Invoke(binderOptions);
			return BindInstance(type, null, configuration, binderOptions);
		}

		public static void Bind(this IConfiguration configuration, string key, object instance)
		{
			configuration.GetSection(key).Bind(instance);
		}

		public static void Bind(this IConfiguration configuration, object instance)
		{
			configuration.Bind(instance, delegate
			{
			});
		}

		public static void Bind(this IConfiguration configuration, object instance, Action<BinderOptions> configureOptions)
		{
			if (configuration == null)
			{
				throw new ArgumentNullException("configuration");
			}
			if (instance != null)
			{
				BinderOptions binderOptions = new BinderOptions();
				configureOptions?.Invoke(binderOptions);
				BindInstance(instance.GetType(), instance, configuration, binderOptions);
			}
		}

		public static T GetValue<T>(this IConfiguration configuration, string key)
		{
			return configuration.GetValue(key, default(T));
		}

		public static T GetValue<T>(this IConfiguration configuration, string key, T defaultValue)
		{
			return (T)configuration.GetValue(typeof(T), key, defaultValue);
		}

		public static object GetValue(this IConfiguration configuration, Type type, string key)
		{
			return configuration.GetValue(type, key, null);
		}

		public static object GetValue(this IConfiguration configuration, Type type, string key, object defaultValue)
		{
			string value = configuration.GetSection(key).Value;
			if (value != null)
			{
				return ConvertValue(type, value);
			}
			return defaultValue;
		}

		private static void BindNonScalar(this IConfiguration configuration, object instance, BinderOptions options)
		{
			if (instance == null)
			{
				return;
			}
			foreach (PropertyInfo allProperty in GetAllProperties(instance.GetType().GetTypeInfo()))
			{
				BindProperty(allProperty, instance, configuration, options);
			}
		}

		private static void BindProperty(PropertyInfo property, object instance, IConfiguration config, BinderOptions options)
		{
			if (property.GetMethod == null || (!options.BindNonPublicProperties && !property.GetMethod.IsPublic) || property.GetMethod.GetParameters().Length != 0)
			{
				return;
			}
			object value = property.GetValue(instance);
			bool flag = property.SetMethod != null && (property.SetMethod.IsPublic || options.BindNonPublicProperties);
			if (value != null || flag)
			{
				value = BindInstance(property.PropertyType, value, config.GetSection(property.Name), options);
				if (value != null && flag)
				{
					property.SetValue(instance, value);
				}
			}
		}

		private static object BindToCollection(TypeInfo typeInfo, IConfiguration config, BinderOptions options)
		{
			Type type = typeof(List<>).MakeGenericType(typeInfo.GenericTypeArguments[0]);
			object obj = Activator.CreateInstance(type);
			BindCollection(obj, type, config, options);
			return obj;
		}

		private static object AttemptBindToCollectionInterfaces(Type type, IConfiguration config, BinderOptions options)
		{
			TypeInfo typeInfo = type.GetTypeInfo();
			if (!typeInfo.IsInterface)
			{
				return null;
			}
			Type type2 = FindOpenGenericInterface(typeof(IReadOnlyList<>), type);
			if (type2 != null)
			{
				return BindToCollection(typeInfo, config, options);
			}
			type2 = FindOpenGenericInterface(typeof(IReadOnlyDictionary<, >), type);
			if (type2 != null)
			{
				Type type3 = typeof(Dictionary<, >).MakeGenericType(typeInfo.GenericTypeArguments[0], typeInfo.GenericTypeArguments[1]);
				object obj = Activator.CreateInstance(type3);
				BindDictionary(obj, type3, config, options);
				return obj;
			}
			type2 = FindOpenGenericInterface(typeof(IDictionary<, >), type);
			if (type2 != null)
			{
				object obj2 = Activator.CreateInstance(typeof(Dictionary<, >).MakeGenericType(typeInfo.GenericTypeArguments[0], typeInfo.GenericTypeArguments[1]));
				BindDictionary(obj2, type2, config, options);
				return obj2;
			}
			type2 = FindOpenGenericInterface(typeof(IReadOnlyCollection<>), type);
			if (type2 != null)
			{
				return BindToCollection(typeInfo, config, options);
			}
			type2 = FindOpenGenericInterface(typeof(ICollection<>), type);
			if (type2 != null)
			{
				return BindToCollection(typeInfo, config, options);
			}
			type2 = FindOpenGenericInterface(typeof(IEnumerable<>), type);
			if (type2 != null)
			{
				return BindToCollection(typeInfo, config, options);
			}
			return null;
		}

		private static object BindInstance(Type type, object instance, IConfiguration config, BinderOptions options)
		{
			if (type == typeof(IConfigurationSection))
			{
				return config;
			}
			string text = (config as IConfigurationSection)?.Value;
			if (text != null && TryConvertValue(type, text, out var result, out var error))
			{
				if (error != null)
				{
					throw error;
				}
				return result;
			}
			if (config != null && config.GetChildren().Any())
			{
				if (instance == null)
				{
					instance = AttemptBindToCollectionInterfaces(type, config, options);
					if (instance != null)
					{
						return instance;
					}
					instance = CreateInstance(type);
				}
				Type type2 = FindOpenGenericInterface(typeof(IDictionary<, >), type);
				if (type2 != null)
				{
					BindDictionary(instance, type2, config, options);
				}
				else if (type.IsArray)
				{
					instance = BindArray((Array)instance, config, options);
				}
				else
				{
					type2 = FindOpenGenericInterface(typeof(ICollection<>), type);
					if (type2 != null)
					{
						BindCollection(instance, type2, config, options);
					}
					else
					{
						config.BindNonScalar(instance, options);
					}
				}
			}
			return instance;
		}

		private static object CreateInstance(Type type)
		{
			TypeInfo typeInfo = type.GetTypeInfo();
			if (typeInfo.IsInterface || typeInfo.IsAbstract)
			{
				throw new InvalidOperationException(Resources.FormatError_CannotActivateAbstractOrInterface(type));
			}
			if (type.IsArray)
			{
				if (typeInfo.GetArrayRank() > 1)
				{
					throw new InvalidOperationException(Resources.FormatError_UnsupportedMultidimensionalArray(type));
				}
				return Array.CreateInstance(typeInfo.GetElementType(), 0);
			}
			if (!typeInfo.DeclaredConstructors.Any((ConstructorInfo ctor) => ctor.IsPublic && ctor.GetParameters().Length == 0))
			{
				throw new InvalidOperationException(Resources.FormatError_MissingParameterlessConstructor(type));
			}
			try
			{
				return Activator.CreateInstance(type);
			}
			catch (Exception innerException)
			{
				throw new InvalidOperationException(Resources.FormatError_FailedToActivate(type), innerException);
			}
		}

		private static void BindDictionary(object dictionary, Type dictionaryType, IConfiguration config, BinderOptions options)
		{
			TypeInfo typeInfo = dictionaryType.GetTypeInfo();
			Type type = typeInfo.GenericTypeArguments[0];
			Type type2 = typeInfo.GenericTypeArguments[1];
			bool isEnum = type.GetTypeInfo().IsEnum;
			if (type != typeof(string) && !isEnum)
			{
				return;
			}
			PropertyInfo declaredProperty = typeInfo.GetDeclaredProperty("Item");
			foreach (IConfigurationSection child in config.GetChildren())
			{
				object obj = BindInstance(type2, null, child, options);
				if (obj != null)
				{
					if (type == typeof(string))
					{
						string key = child.Key;
						declaredProperty.SetValue(dictionary, obj, new object[1] { key });
					}
					else if (isEnum)
					{
						int num = Convert.ToInt32(Enum.Parse(type, child.Key));
						declaredProperty.SetValue(dictionary, obj, new object[1] { num });
					}
				}
			}
		}

		private static void BindCollection(object collection, Type collectionType, IConfiguration config, BinderOptions options)
		{
			TypeInfo typeInfo = collectionType.GetTypeInfo();
			Type type = typeInfo.GenericTypeArguments[0];
			MethodInfo declaredMethod = typeInfo.GetDeclaredMethod("Add");
			foreach (IConfigurationSection child in config.GetChildren())
			{
				try
				{
					object obj = BindInstance(type, null, child, options);
					if (obj != null)
					{
						declaredMethod.Invoke(collection, new object[1] { obj });
					}
				}
				catch
				{
				}
			}
		}

		private static Array BindArray(Array source, IConfiguration config, BinderOptions options)
		{
			IConfigurationSection[] array = config.GetChildren().ToArray();
			int length = source.Length;
			Type elementType = source.GetType().GetElementType();
			Array array2 = Array.CreateInstance(elementType, length + array.Length);
			if (length > 0)
			{
				Array.Copy(source, array2, length);
			}
			for (int i = 0; i < array.Length; i++)
			{
				try
				{
					object obj = BindInstance(elementType, null, array[i], options);
					if (obj != null)
					{
						array2.SetValue(obj, length + i);
					}
				}
				catch
				{
				}
			}
			return array2;
		}

		private static bool TryConvertValue(Type type, string value, out object result, out Exception error)
		{
			error = null;
			result = null;
			if (type == typeof(object))
			{
				result = value;
				return true;
			}
			if (type.GetTypeInfo().IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
			{
				if (string.IsNullOrEmpty(value))
				{
					return true;
				}
				return TryConvertValue(Nullable.GetUnderlyingType(type), value, out result, out error);
			}
			TypeConverter converter = TypeDescriptor.GetConverter(type);
			if (converter.CanConvertFrom(typeof(string)))
			{
				try
				{
					result = converter.ConvertFromInvariantString(value);
				}
				catch (Exception innerException)
				{
					error = new InvalidOperationException(Resources.FormatError_FailedBinding(value, type), innerException);
				}
				return true;
			}
			return false;
		}

		private static object ConvertValue(Type type, string value)
		{
			TryConvertValue(type, value, out var result, out var error);
			if (error != null)
			{
				throw error;
			}
			return result;
		}

		private static Type FindOpenGenericInterface(Type expected, Type actual)
		{
			TypeInfo typeInfo = actual.GetTypeInfo();
			if (typeInfo.IsGenericType && actual.GetGenericTypeDefinition() == expected)
			{
				return actual;
			}
			foreach (Type implementedInterface in typeInfo.ImplementedInterfaces)
			{
				if (implementedInterface.GetTypeInfo().IsGenericType && implementedInterface.GetGenericTypeDefinition() == expected)
				{
					return implementedInterface;
				}
			}
			return null;
		}

		private static IEnumerable<PropertyInfo> GetAllProperties(TypeInfo type)
		{
			List<PropertyInfo> list = new List<PropertyInfo>();
			do
			{
				list.AddRange(type.DeclaredProperties);
				type = type.BaseType.GetTypeInfo();
			}
			while (type != typeof(object).GetTypeInfo());
			return list;
		}
	}
}
namespace Microsoft.Extensions.Configuration.Binder
{
	internal static class Resources
	{
		private static readonly ResourceManager _resourceManager = new ResourceManager("Microsoft.Extensions.Configuration.Binder.Resources", typeof(Resources).GetTypeInfo().Assembly);

		internal static string Error_CannotActivateAbstractOrInterface => GetString("Error_CannotActivateAbstractOrInterface");

		internal static string Error_FailedBinding => GetString("Error_FailedBinding");

		internal static string Error_FailedToActivate => GetString("Error_FailedToActivate");

		internal static string Error_MissingParameterlessConstructor => GetString("Error_MissingParameterlessConstructor");

		internal static string Error_UnsupportedMultidimensionalArray => GetString("Error_UnsupportedMultidimensionalArray");

		internal static string FormatError_CannotActivateAbstractOrInterface(object p0)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("Error_CannotActivateAbstractOrInterface"), p0);
		}

		internal static string FormatError_FailedBinding(object p0, object p1)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("Error_FailedBinding"), p0, p1);
		}

		internal static string FormatError_FailedToActivate(object p0)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("Error_FailedToActivate"), p0);
		}

		internal static string FormatError_MissingParameterlessConstructor(object p0)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("Error_MissingParameterlessConstructor"), p0);
		}

		internal static string FormatError_UnsupportedMultidimensionalArray(object p0)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("Error_UnsupportedMultidimensionalArray"), p0);
		}

		private static string GetString(string name, params string[] formatterNames)
		{
			string text = _resourceManager.GetString(name);
			if (formatterNames != null)
			{
				for (int i = 0; i < formatterNames.Length; i++)
				{
					text = text.Replace("{" + formatterNames[i] + "}", "{" + i + "}");
				}
			}
			return text;
		}
	}
}
