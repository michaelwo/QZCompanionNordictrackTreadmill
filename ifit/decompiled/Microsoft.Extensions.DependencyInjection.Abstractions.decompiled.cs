using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.Versioning;
using Microsoft.Extensions.DependencyInjection.Abstractions;
using Microsoft.Extensions.Internal;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: InternalsVisibleTo("Microsoft.Extensions.DependencyInjection.Tests, PublicKey=0024000004800000940000000602000000240000525341310004000001000100f33a29044fa9d740c9b3213a93e57c84b472c84e0b8a0e1ae48e67a9f8f6de9d5f7f3d52ac23e48ac51801f1dc950abe901da34d2a9e3baadb141a17c77ef3c565dd5ee5054b91cf63bb3c6ab83f72ab3aafe93d0fc3c2348b764fafb0b1c0733de51459aeab46580384bf9d74c4e28164b7cde247f891ba07891c9d872ad2bb")]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata("CommitHash", "22b6857cd9892a3d3478ff7a77bafdf6f0efefd3")]
[assembly: AssemblyMetadata("BuildNumber", "30799")]
[assembly: AssemblyCompany("Microsoft Corporation.")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Abstractions for dependency injection.\nCommonly used types:\nMicrosoft.Extensions.DependencyInjection.IServiceCollection")]
[assembly: AssemblyFileVersion("2.1.0.18136")]
[assembly: AssemblyInformationalVersion("2.1.0-rtm-30799")]
[assembly: AssemblyProduct("Microsoft .NET Extensions")]
[assembly: AssemblyTitle("Microsoft.Extensions.DependencyInjection.Abstractions")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: AssemblyVersion("2.1.0.0")]
namespace Microsoft.Extensions.Internal
{
	internal class ParameterDefaultValue
	{
		public static bool TryGetDefaultValue(ParameterInfo parameter, out object defaultValue)
		{
			bool flag = true;
			defaultValue = null;
			bool flag2;
			try
			{
				flag2 = parameter.HasDefaultValue;
			}
			catch (FormatException) when (parameter.ParameterType == typeof(DateTime))
			{
				flag2 = true;
				flag = false;
			}
			if (flag2)
			{
				if (flag)
				{
					defaultValue = parameter.DefaultValue;
				}
				if (defaultValue == null && parameter.ParameterType.IsValueType)
				{
					defaultValue = Activator.CreateInstance(parameter.ParameterType);
				}
			}
			return flag2;
		}
	}
}
namespace Microsoft.Extensions.DependencyInjection
{
	public interface IServiceCollection : IList<ServiceDescriptor>, ICollection<ServiceDescriptor>, IEnumerable<ServiceDescriptor>, IEnumerable
	{
	}
	public interface IServiceProviderFactory<TContainerBuilder>
	{
		TContainerBuilder CreateBuilder(IServiceCollection services);

		IServiceProvider CreateServiceProvider(TContainerBuilder containerBuilder);
	}
	public interface IServiceScope : IDisposable
	{
		IServiceProvider ServiceProvider { get; }
	}
	public interface IServiceScopeFactory
	{
		IServiceScope CreateScope();
	}
	public interface ISupportRequiredService
	{
		object GetRequiredService(Type serviceType);
	}
	public static class ServiceCollectionServiceExtensions
	{
		public static IServiceCollection AddTransient(this IServiceCollection services, Type serviceType, Type implementationType)
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (implementationType == null)
			{
				throw new ArgumentNullException("implementationType");
			}
			return Add(services, serviceType, implementationType, ServiceLifetime.Transient);
		}

		public static IServiceCollection AddTransient(this IServiceCollection services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (implementationFactory == null)
			{
				throw new ArgumentNullException("implementationFactory");
			}
			return Add(services, serviceType, implementationFactory, ServiceLifetime.Transient);
		}

		public static IServiceCollection AddTransient<TService, TImplementation>(this IServiceCollection services) where TService : class where TImplementation : class, TService
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			return services.AddTransient(typeof(TService), typeof(TImplementation));
		}

		public static IServiceCollection AddTransient(this IServiceCollection services, Type serviceType)
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			return services.AddTransient(serviceType, serviceType);
		}

		public static IServiceCollection AddTransient<TService>(this IServiceCollection services) where TService : class
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			return services.AddTransient(typeof(TService));
		}

		public static IServiceCollection AddTransient<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementationFactory) where TService : class
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			if (implementationFactory == null)
			{
				throw new ArgumentNullException("implementationFactory");
			}
			return services.AddTransient(typeof(TService), implementationFactory);
		}

		public static IServiceCollection AddTransient<TService, TImplementation>(this IServiceCollection services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			if (implementationFactory == null)
			{
				throw new ArgumentNullException("implementationFactory");
			}
			return services.AddTransient(typeof(TService), implementationFactory);
		}

		public static IServiceCollection AddScoped(this IServiceCollection services, Type serviceType, Type implementationType)
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (implementationType == null)
			{
				throw new ArgumentNullException("implementationType");
			}
			return Add(services, serviceType, implementationType, ServiceLifetime.Scoped);
		}

		public static IServiceCollection AddScoped(this IServiceCollection services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (implementationFactory == null)
			{
				throw new ArgumentNullException("implementationFactory");
			}
			return Add(services, serviceType, implementationFactory, ServiceLifetime.Scoped);
		}

		public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services) where TService : class where TImplementation : class, TService
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			return services.AddScoped(typeof(TService), typeof(TImplementation));
		}

		public static IServiceCollection AddScoped(this IServiceCollection services, Type serviceType)
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			return services.AddScoped(serviceType, serviceType);
		}

		public static IServiceCollection AddScoped<TService>(this IServiceCollection services) where TService : class
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			return services.AddScoped(typeof(TService));
		}

		public static IServiceCollection AddScoped<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementationFactory) where TService : class
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			if (implementationFactory == null)
			{
				throw new ArgumentNullException("implementationFactory");
			}
			return services.AddScoped(typeof(TService), implementationFactory);
		}

		public static IServiceCollection AddScoped<TService, TImplementation>(this IServiceCollection services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			if (implementationFactory == null)
			{
				throw new ArgumentNullException("implementationFactory");
			}
			return services.AddScoped(typeof(TService), implementationFactory);
		}

		public static IServiceCollection AddSingleton(this IServiceCollection services, Type serviceType, Type implementationType)
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (implementationType == null)
			{
				throw new ArgumentNullException("implementationType");
			}
			return Add(services, serviceType, implementationType, ServiceLifetime.Singleton);
		}

		public static IServiceCollection AddSingleton(this IServiceCollection services, Type serviceType, Func<IServiceProvider, object> implementationFactory)
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (implementationFactory == null)
			{
				throw new ArgumentNullException("implementationFactory");
			}
			return Add(services, serviceType, implementationFactory, ServiceLifetime.Singleton);
		}

		public static IServiceCollection AddSingleton<TService, TImplementation>(this IServiceCollection services) where TService : class where TImplementation : class, TService
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			return services.AddSingleton(typeof(TService), typeof(TImplementation));
		}

		public static IServiceCollection AddSingleton(this IServiceCollection services, Type serviceType)
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			return services.AddSingleton(serviceType, serviceType);
		}

		public static IServiceCollection AddSingleton<TService>(this IServiceCollection services) where TService : class
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			return services.AddSingleton(typeof(TService));
		}

		public static IServiceCollection AddSingleton<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementationFactory) where TService : class
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			if (implementationFactory == null)
			{
				throw new ArgumentNullException("implementationFactory");
			}
			return services.AddSingleton(typeof(TService), implementationFactory);
		}

		public static IServiceCollection AddSingleton<TService, TImplementation>(this IServiceCollection services, Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			if (implementationFactory == null)
			{
				throw new ArgumentNullException("implementationFactory");
			}
			return services.AddSingleton(typeof(TService), implementationFactory);
		}

		public static IServiceCollection AddSingleton(this IServiceCollection services, Type serviceType, object implementationInstance)
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (implementationInstance == null)
			{
				throw new ArgumentNullException("implementationInstance");
			}
			ServiceDescriptor item = new ServiceDescriptor(serviceType, implementationInstance);
			services.Add(item);
			return services;
		}

		public static IServiceCollection AddSingleton<TService>(this IServiceCollection services, TService implementationInstance) where TService : class
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			if (implementationInstance == null)
			{
				throw new ArgumentNullException("implementationInstance");
			}
			return services.AddSingleton(typeof(TService), implementationInstance);
		}

		private static IServiceCollection Add(IServiceCollection collection, Type serviceType, Type implementationType, ServiceLifetime lifetime)
		{
			ServiceDescriptor item = new ServiceDescriptor(serviceType, implementationType, lifetime);
			collection.Add(item);
			return collection;
		}

		private static IServiceCollection Add(IServiceCollection collection, Type serviceType, Func<IServiceProvider, object> implementationFactory, ServiceLifetime lifetime)
		{
			ServiceDescriptor item = new ServiceDescriptor(serviceType, implementationFactory, lifetime);
			collection.Add(item);
			return collection;
		}
	}
	[DebuggerDisplay("Lifetime = {Lifetime}, ServiceType = {ServiceType}, ImplementationType = {ImplementationType}")]
	public class ServiceDescriptor
	{
		public ServiceLifetime Lifetime { get; }

		public Type ServiceType { get; }

		public Type ImplementationType { get; }

		public object ImplementationInstance { get; }

		public Func<IServiceProvider, object> ImplementationFactory { get; }

		public ServiceDescriptor(Type serviceType, Type implementationType, ServiceLifetime lifetime)
			: this(serviceType, lifetime)
		{
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (implementationType == null)
			{
				throw new ArgumentNullException("implementationType");
			}
			ImplementationType = implementationType;
		}

		public ServiceDescriptor(Type serviceType, object instance)
			: this(serviceType, ServiceLifetime.Singleton)
		{
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			ImplementationInstance = instance;
		}

		public ServiceDescriptor(Type serviceType, Func<IServiceProvider, object> factory, ServiceLifetime lifetime)
			: this(serviceType, lifetime)
		{
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (factory == null)
			{
				throw new ArgumentNullException("factory");
			}
			ImplementationFactory = factory;
		}

		private ServiceDescriptor(Type serviceType, ServiceLifetime lifetime)
		{
			Lifetime = lifetime;
			ServiceType = serviceType;
		}

		internal Type GetImplementationType()
		{
			if (ImplementationType != null)
			{
				return ImplementationType;
			}
			if (ImplementationInstance != null)
			{
				return ImplementationInstance.GetType();
			}
			if (ImplementationFactory != null)
			{
				return ImplementationFactory.GetType().GenericTypeArguments[1];
			}
			return null;
		}

		public static ServiceDescriptor Transient<TService, TImplementation>() where TService : class where TImplementation : class, TService
		{
			return Describe<TService, TImplementation>(ServiceLifetime.Transient);
		}

		public static ServiceDescriptor Transient(Type service, Type implementationType)
		{
			if (service == null)
			{
				throw new ArgumentNullException("service");
			}
			if (implementationType == null)
			{
				throw new ArgumentNullException("implementationType");
			}
			return Describe(service, implementationType, ServiceLifetime.Transient);
		}

		public static ServiceDescriptor Transient<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
		{
			if (implementationFactory == null)
			{
				throw new ArgumentNullException("implementationFactory");
			}
			return Describe(typeof(TService), implementationFactory, ServiceLifetime.Transient);
		}

		public static ServiceDescriptor Transient<TService>(Func<IServiceProvider, TService> implementationFactory) where TService : class
		{
			if (implementationFactory == null)
			{
				throw new ArgumentNullException("implementationFactory");
			}
			return Describe(typeof(TService), implementationFactory, ServiceLifetime.Transient);
		}

		public static ServiceDescriptor Transient(Type service, Func<IServiceProvider, object> implementationFactory)
		{
			if (service == null)
			{
				throw new ArgumentNullException("service");
			}
			if (implementationFactory == null)
			{
				throw new ArgumentNullException("implementationFactory");
			}
			return Describe(service, implementationFactory, ServiceLifetime.Transient);
		}

		public static ServiceDescriptor Scoped<TService, TImplementation>() where TService : class where TImplementation : class, TService
		{
			return Describe<TService, TImplementation>(ServiceLifetime.Scoped);
		}

		public static ServiceDescriptor Scoped(Type service, Type implementationType)
		{
			return Describe(service, implementationType, ServiceLifetime.Scoped);
		}

		public static ServiceDescriptor Scoped<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
		{
			if (implementationFactory == null)
			{
				throw new ArgumentNullException("implementationFactory");
			}
			return Describe(typeof(TService), implementationFactory, ServiceLifetime.Scoped);
		}

		public static ServiceDescriptor Scoped<TService>(Func<IServiceProvider, TService> implementationFactory) where TService : class
		{
			if (implementationFactory == null)
			{
				throw new ArgumentNullException("implementationFactory");
			}
			return Describe(typeof(TService), implementationFactory, ServiceLifetime.Scoped);
		}

		public static ServiceDescriptor Scoped(Type service, Func<IServiceProvider, object> implementationFactory)
		{
			if (service == null)
			{
				throw new ArgumentNullException("service");
			}
			if (implementationFactory == null)
			{
				throw new ArgumentNullException("implementationFactory");
			}
			return Describe(service, implementationFactory, ServiceLifetime.Scoped);
		}

		public static ServiceDescriptor Singleton<TService, TImplementation>() where TService : class where TImplementation : class, TService
		{
			return Describe<TService, TImplementation>(ServiceLifetime.Singleton);
		}

		public static ServiceDescriptor Singleton(Type service, Type implementationType)
		{
			if (service == null)
			{
				throw new ArgumentNullException("service");
			}
			if (implementationType == null)
			{
				throw new ArgumentNullException("implementationType");
			}
			return Describe(service, implementationType, ServiceLifetime.Singleton);
		}

		public static ServiceDescriptor Singleton<TService, TImplementation>(Func<IServiceProvider, TImplementation> implementationFactory) where TService : class where TImplementation : class, TService
		{
			if (implementationFactory == null)
			{
				throw new ArgumentNullException("implementationFactory");
			}
			return Describe(typeof(TService), implementationFactory, ServiceLifetime.Singleton);
		}

		public static ServiceDescriptor Singleton<TService>(Func<IServiceProvider, TService> implementationFactory) where TService : class
		{
			if (implementationFactory == null)
			{
				throw new ArgumentNullException("implementationFactory");
			}
			return Describe(typeof(TService), implementationFactory, ServiceLifetime.Singleton);
		}

		public static ServiceDescriptor Singleton(Type serviceType, Func<IServiceProvider, object> implementationFactory)
		{
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (implementationFactory == null)
			{
				throw new ArgumentNullException("implementationFactory");
			}
			return Describe(serviceType, implementationFactory, ServiceLifetime.Singleton);
		}

		public static ServiceDescriptor Singleton<TService>(TService implementationInstance) where TService : class
		{
			if (implementationInstance == null)
			{
				throw new ArgumentNullException("implementationInstance");
			}
			return Singleton(typeof(TService), implementationInstance);
		}

		public static ServiceDescriptor Singleton(Type serviceType, object implementationInstance)
		{
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (implementationInstance == null)
			{
				throw new ArgumentNullException("implementationInstance");
			}
			return new ServiceDescriptor(serviceType, implementationInstance);
		}

		private static ServiceDescriptor Describe<TService, TImplementation>(ServiceLifetime lifetime) where TService : class where TImplementation : class, TService
		{
			return Describe(typeof(TService), typeof(TImplementation), lifetime);
		}

		public static ServiceDescriptor Describe(Type serviceType, Type implementationType, ServiceLifetime lifetime)
		{
			return new ServiceDescriptor(serviceType, implementationType, lifetime);
		}

		public static ServiceDescriptor Describe(Type serviceType, Func<IServiceProvider, object> implementationFactory, ServiceLifetime lifetime)
		{
			return new ServiceDescriptor(serviceType, implementationFactory, lifetime);
		}
	}
	public enum ServiceLifetime
	{
		Singleton,
		Scoped,
		Transient
	}
	public static class ServiceProviderServiceExtensions
	{
		public static T GetService<T>(this IServiceProvider provider)
		{
			if (provider == null)
			{
				throw new ArgumentNullException("provider");
			}
			return (T)provider.GetService(typeof(T));
		}

		public static object GetRequiredService(this IServiceProvider provider, Type serviceType)
		{
			if (provider == null)
			{
				throw new ArgumentNullException("provider");
			}
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			if (provider is ISupportRequiredService supportRequiredService)
			{
				return supportRequiredService.GetRequiredService(serviceType);
			}
			return provider.GetService(serviceType) ?? throw new InvalidOperationException(Resources.FormatNoServiceRegistered(serviceType));
		}

		public static T GetRequiredService<T>(this IServiceProvider provider)
		{
			if (provider == null)
			{
				throw new ArgumentNullException("provider");
			}
			return (T)provider.GetRequiredService(typeof(T));
		}

		public static IEnumerable<T> GetServices<T>(this IServiceProvider provider)
		{
			if (provider == null)
			{
				throw new ArgumentNullException("provider");
			}
			return provider.GetRequiredService<IEnumerable<T>>();
		}

		public static IEnumerable<object> GetServices(this IServiceProvider provider, Type serviceType)
		{
			if (provider == null)
			{
				throw new ArgumentNullException("provider");
			}
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			Type serviceType2 = typeof(IEnumerable<>).MakeGenericType(serviceType);
			return (IEnumerable<object>)provider.GetRequiredService(serviceType2);
		}

		public static IServiceScope CreateScope(this IServiceProvider provider)
		{
			return provider.GetRequiredService<IServiceScopeFactory>().CreateScope();
		}
	}
	public static class ActivatorUtilities
	{
		private class ConstructorMatcher
		{
			private readonly ConstructorInfo _constructor;

			private readonly ParameterInfo[] _parameters;

			private readonly object[] _parameterValues;

			private readonly bool[] _parameterValuesSet;

			public ConstructorMatcher(ConstructorInfo constructor)
			{
				_constructor = constructor;
				_parameters = _constructor.GetParameters();
				_parameterValuesSet = new bool[_parameters.Length];
				_parameterValues = new object[_parameters.Length];
			}

			public int Match(object[] givenParameters)
			{
				int num = 0;
				int result = 0;
				for (int i = 0; i != givenParameters.Length; i++)
				{
					TypeInfo typeInfo = givenParameters[i]?.GetType().GetTypeInfo();
					bool flag = false;
					int num2 = num;
					while (!flag && num2 != _parameters.Length)
					{
						if (!_parameterValuesSet[num2] && _parameters[num2].ParameterType.GetTypeInfo().IsAssignableFrom(typeInfo))
						{
							flag = true;
							_parameterValuesSet[num2] = true;
							_parameterValues[num2] = givenParameters[i];
							if (num == num2)
							{
								num++;
								if (num2 == i)
								{
									result = num2;
								}
							}
						}
						num2++;
					}
					if (!flag)
					{
						return -1;
					}
				}
				return result;
			}

			public object CreateInstance(IServiceProvider provider)
			{
				for (int i = 0; i != _parameters.Length; i++)
				{
					if (_parameterValuesSet[i])
					{
						continue;
					}
					object service = provider.GetService(_parameters[i].ParameterType);
					if (service == null)
					{
						if (!ParameterDefaultValue.TryGetDefaultValue(_parameters[i], out var defaultValue))
						{
							throw new InvalidOperationException($"Unable to resolve service for type '{_parameters[i].ParameterType}' while attempting to activate '{_constructor.DeclaringType}'.");
						}
						_parameterValues[i] = defaultValue;
					}
					else
					{
						_parameterValues[i] = service;
					}
				}
				try
				{
					return _constructor.Invoke(_parameterValues);
				}
				catch (TargetInvocationException ex)
				{
					ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
					throw;
				}
			}
		}

		private static readonly MethodInfo GetServiceInfo = GetMethodInfo<Func<IServiceProvider, Type, Type, bool, object>>((IServiceProvider sp, Type t, Type r, bool c) => GetService(sp, t, r, c));

		public static object CreateInstance(IServiceProvider provider, Type instanceType, params object[] parameters)
		{
			int num = -1;
			bool flag = false;
			ConstructorMatcher constructorMatcher = null;
			if (!instanceType.GetTypeInfo().IsAbstract)
			{
				foreach (ConstructorInfo item in instanceType.GetTypeInfo().DeclaredConstructors.Where((ConstructorInfo c) => !c.IsStatic && c.IsPublic))
				{
					ConstructorMatcher constructorMatcher2 = new ConstructorMatcher(item);
					bool flag2 = item.IsDefined(typeof(ActivatorUtilitiesConstructorAttribute), inherit: false);
					int num2 = constructorMatcher2.Match(parameters);
					if (flag2)
					{
						if (flag)
						{
							ThrowMultipleCtorsMarkedWithAttributeException();
						}
						if (num2 == -1)
						{
							ThrowMarkedCtorDoesNotTakeAllProvidedArguments();
						}
					}
					if (flag2 || num < num2)
					{
						num = num2;
						constructorMatcher = constructorMatcher2;
					}
					flag = flag || flag2;
				}
			}
			if (constructorMatcher == null)
			{
				throw new InvalidOperationException($"A suitable constructor for type '{instanceType}' could not be located. Ensure the type is concrete and services are registered for all parameters of a public constructor.");
			}
			return constructorMatcher.CreateInstance(provider);
		}

		public static ObjectFactory CreateFactory(Type instanceType, Type[] argumentTypes)
		{
			FindApplicableConstructor(instanceType, argumentTypes, out var matchingConstructor, out var parameterMap);
			ParameterExpression parameterExpression = Expression.Parameter(typeof(IServiceProvider), "provider");
			ParameterExpression parameterExpression2 = Expression.Parameter(typeof(object[]), "argumentArray");
			return Expression.Lambda<Func<IServiceProvider, object[], object>>(BuildFactoryExpression(matchingConstructor, parameterMap, parameterExpression, parameterExpression2), new ParameterExpression[2] { parameterExpression, parameterExpression2 }).Compile().Invoke;
		}

		public static T CreateInstance<T>(IServiceProvider provider, params object[] parameters)
		{
			return (T)CreateInstance(provider, typeof(T), parameters);
		}

		public static T GetServiceOrCreateInstance<T>(IServiceProvider provider)
		{
			return (T)GetServiceOrCreateInstance(provider, typeof(T));
		}

		public static object GetServiceOrCreateInstance(IServiceProvider provider, Type type)
		{
			return provider.GetService(type) ?? CreateInstance(provider, type);
		}

		private static MethodInfo GetMethodInfo<T>(Expression<T> expr)
		{
			return ((MethodCallExpression)expr.Body).Method;
		}

		private static object GetService(IServiceProvider sp, Type type, Type requiredBy, bool isDefaultParameterRequired)
		{
			object service = sp.GetService(type);
			if (service == null && !isDefaultParameterRequired)
			{
				throw new InvalidOperationException($"Unable to resolve service for type '{type}' while attempting to activate '{requiredBy}'.");
			}
			return service;
		}

		private static Expression BuildFactoryExpression(ConstructorInfo constructor, int?[] parameterMap, Expression serviceProvider, Expression factoryArgumentArray)
		{
			ParameterInfo[] parameters = constructor.GetParameters();
			Expression[] array = new Expression[parameters.Length];
			for (int i = 0; i < parameters.Length; i++)
			{
				ParameterInfo obj = parameters[i];
				Type parameterType = obj.ParameterType;
				object defaultValue;
				bool flag = ParameterDefaultValue.TryGetDefaultValue(obj, out defaultValue);
				if (parameterMap[i].HasValue)
				{
					array[i] = Expression.ArrayAccess(factoryArgumentArray, Expression.Constant(parameterMap[i]));
				}
				else
				{
					Expression[] arguments = new Expression[4]
					{
						serviceProvider,
						Expression.Constant(parameterType, typeof(Type)),
						Expression.Constant(constructor.DeclaringType, typeof(Type)),
						Expression.Constant(flag)
					};
					array[i] = Expression.Call(GetServiceInfo, arguments);
				}
				if (flag)
				{
					ConstantExpression right = Expression.Constant(defaultValue);
					array[i] = Expression.Coalesce(array[i], right);
				}
				array[i] = Expression.Convert(array[i], parameterType);
			}
			return Expression.New(constructor, array);
		}

		private static void FindApplicableConstructor(Type instanceType, Type[] argumentTypes, out ConstructorInfo matchingConstructor, out int?[] parameterMap)
		{
			matchingConstructor = null;
			parameterMap = null;
			if (!TryFindPreferredConstructor(instanceType, argumentTypes, ref matchingConstructor, ref parameterMap) && !TryFindMatchingConstructor(instanceType, argumentTypes, ref matchingConstructor, ref parameterMap))
			{
				throw new InvalidOperationException($"A suitable constructor for type '{instanceType}' could not be located. Ensure the type is concrete and services are registered for all parameters of a public constructor.");
			}
		}

		private static bool TryFindMatchingConstructor(Type instanceType, Type[] argumentTypes, ref ConstructorInfo matchingConstructor, ref int?[] parameterMap)
		{
			foreach (ConstructorInfo declaredConstructor in instanceType.GetTypeInfo().DeclaredConstructors)
			{
				if (!declaredConstructor.IsStatic && declaredConstructor.IsPublic && TryCreateParameterMap(declaredConstructor.GetParameters(), argumentTypes, out var parameterMap2))
				{
					if (matchingConstructor != null)
					{
						throw new InvalidOperationException($"Multiple constructors accepting all given argument types have been found in type '{instanceType}'. There should only be one applicable constructor.");
					}
					matchingConstructor = declaredConstructor;
					parameterMap = parameterMap2;
				}
			}
			return matchingConstructor != null;
		}

		private static bool TryFindPreferredConstructor(Type instanceType, Type[] argumentTypes, ref ConstructorInfo matchingConstructor, ref int?[] parameterMap)
		{
			bool flag = false;
			foreach (ConstructorInfo declaredConstructor in instanceType.GetTypeInfo().DeclaredConstructors)
			{
				if (!declaredConstructor.IsStatic && declaredConstructor.IsPublic && declaredConstructor.IsDefined(typeof(ActivatorUtilitiesConstructorAttribute), inherit: false))
				{
					if (flag)
					{
						ThrowMultipleCtorsMarkedWithAttributeException();
					}
					if (!TryCreateParameterMap(declaredConstructor.GetParameters(), argumentTypes, out var parameterMap2))
					{
						ThrowMarkedCtorDoesNotTakeAllProvidedArguments();
					}
					matchingConstructor = declaredConstructor;
					parameterMap = parameterMap2;
					flag = true;
				}
			}
			return matchingConstructor != null;
		}

		private static bool TryCreateParameterMap(ParameterInfo[] constructorParameters, Type[] argumentTypes, out int?[] parameterMap)
		{
			parameterMap = new int?[constructorParameters.Length];
			for (int i = 0; i < argumentTypes.Length; i++)
			{
				bool flag = false;
				TypeInfo typeInfo = argumentTypes[i].GetTypeInfo();
				for (int j = 0; j < constructorParameters.Length; j++)
				{
					if (!parameterMap[j].HasValue && constructorParameters[j].ParameterType.GetTypeInfo().IsAssignableFrom(typeInfo))
					{
						flag = true;
						parameterMap[j] = i;
						break;
					}
				}
				if (!flag)
				{
					return false;
				}
			}
			return true;
		}

		private static void ThrowMultipleCtorsMarkedWithAttributeException()
		{
			throw new InvalidOperationException(string.Format("Multiple constructors were marked with {0}.", "ActivatorUtilitiesConstructorAttribute"));
		}

		private static void ThrowMarkedCtorDoesNotTakeAllProvidedArguments()
		{
			throw new InvalidOperationException(string.Format("Constructor marked with {0} does not accept all given argument types.", "ActivatorUtilitiesConstructorAttribute"));
		}
	}
	public class ActivatorUtilitiesConstructorAttribute : Attribute
	{
	}
	public delegate object ObjectFactory(IServiceProvider serviceProvider, object[] arguments);
}
namespace Microsoft.Extensions.DependencyInjection.Abstractions
{
	internal static class Resources
	{
		private static readonly ResourceManager _resourceManager = new ResourceManager("Microsoft.Extensions.DependencyInjection.Abstractions.Resources", typeof(Resources).GetTypeInfo().Assembly);

		internal static string AmbiguousConstructorMatch => GetString("AmbiguousConstructorMatch");

		internal static string CannotLocateImplementation => GetString("CannotLocateImplementation");

		internal static string CannotResolveService => GetString("CannotResolveService");

		internal static string NoConstructorMatch => GetString("NoConstructorMatch");

		internal static string NoServiceRegistered => GetString("NoServiceRegistered");

		internal static string TryAddIndistinguishableTypeToEnumerable => GetString("TryAddIndistinguishableTypeToEnumerable");

		internal static string FormatAmbiguousConstructorMatch(object p0)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("AmbiguousConstructorMatch"), p0);
		}

		internal static string FormatCannotLocateImplementation(object p0, object p1)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("CannotLocateImplementation"), p0, p1);
		}

		internal static string FormatCannotResolveService(object p0, object p1)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("CannotResolveService"), p0, p1);
		}

		internal static string FormatNoConstructorMatch(object p0)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("NoConstructorMatch"), p0);
		}

		internal static string FormatNoServiceRegistered(object p0)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("NoServiceRegistered"), p0);
		}

		internal static string FormatTryAddIndistinguishableTypeToEnumerable(object p0, object p1)
		{
			return string.Format(CultureInfo.CurrentCulture, GetString("TryAddIndistinguishableTypeToEnumerable"), p0, p1);
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
namespace Microsoft.Extensions.DependencyInjection.Extensions
{
	public static class ServiceCollectionDescriptorExtensions
	{
		public static IServiceCollection Add(this IServiceCollection collection, ServiceDescriptor descriptor)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (descriptor == null)
			{
				throw new ArgumentNullException("descriptor");
			}
			collection.Add(descriptor);
			return collection;
		}

		public static IServiceCollection Add(this IServiceCollection collection, IEnumerable<ServiceDescriptor> descriptors)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (descriptors == null)
			{
				throw new ArgumentNullException("descriptors");
			}
			foreach (ServiceDescriptor descriptor in descriptors)
			{
				collection.Add(descriptor);
			}
			return collection;
		}

		public static void TryAdd(this IServiceCollection collection, ServiceDescriptor descriptor)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (descriptor == null)
			{
				throw new ArgumentNullException("descriptor");
			}
			if (!collection.Any((ServiceDescriptor d) => d.ServiceType == descriptor.ServiceType))
			{
				collection.Add(descriptor);
			}
		}

		public static void TryAdd(this IServiceCollection collection, IEnumerable<ServiceDescriptor> descriptors)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (descriptors == null)
			{
				throw new ArgumentNullException("descriptors");
			}
			foreach (ServiceDescriptor descriptor in descriptors)
			{
				collection.TryAdd(descriptor);
			}
		}

		public static void TryAddTransient(this IServiceCollection collection, Type service)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (service == null)
			{
				throw new ArgumentNullException("service");
			}
			ServiceDescriptor descriptor = ServiceDescriptor.Transient(service, service);
			collection.TryAdd(descriptor);
		}

		public static void TryAddTransient(this IServiceCollection collection, Type service, Type implementationType)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (service == null)
			{
				throw new ArgumentNullException("service");
			}
			if (implementationType == null)
			{
				throw new ArgumentNullException("implementationType");
			}
			ServiceDescriptor descriptor = ServiceDescriptor.Transient(service, implementationType);
			collection.TryAdd(descriptor);
		}

		public static void TryAddTransient(this IServiceCollection collection, Type service, Func<IServiceProvider, object> implementationFactory)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (service == null)
			{
				throw new ArgumentNullException("service");
			}
			if (implementationFactory == null)
			{
				throw new ArgumentNullException("implementationFactory");
			}
			ServiceDescriptor descriptor = ServiceDescriptor.Transient(service, implementationFactory);
			collection.TryAdd(descriptor);
		}

		public static void TryAddTransient<TService>(this IServiceCollection collection) where TService : class
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			collection.TryAddTransient(typeof(TService), typeof(TService));
		}

		public static void TryAddTransient<TService, TImplementation>(this IServiceCollection collection) where TService : class where TImplementation : class, TService
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			collection.TryAddTransient(typeof(TService), typeof(TImplementation));
		}

		public static void TryAddTransient<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementationFactory) where TService : class
		{
			services.TryAdd(ServiceDescriptor.Transient(implementationFactory));
		}

		public static void TryAddScoped(this IServiceCollection collection, Type service)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (service == null)
			{
				throw new ArgumentNullException("service");
			}
			ServiceDescriptor descriptor = ServiceDescriptor.Scoped(service, service);
			collection.TryAdd(descriptor);
		}

		public static void TryAddScoped(this IServiceCollection collection, Type service, Type implementationType)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (service == null)
			{
				throw new ArgumentNullException("service");
			}
			if (implementationType == null)
			{
				throw new ArgumentNullException("implementationType");
			}
			ServiceDescriptor descriptor = ServiceDescriptor.Scoped(service, implementationType);
			collection.TryAdd(descriptor);
		}

		public static void TryAddScoped(this IServiceCollection collection, Type service, Func<IServiceProvider, object> implementationFactory)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (service == null)
			{
				throw new ArgumentNullException("service");
			}
			if (implementationFactory == null)
			{
				throw new ArgumentNullException("implementationFactory");
			}
			ServiceDescriptor descriptor = ServiceDescriptor.Scoped(service, implementationFactory);
			collection.TryAdd(descriptor);
		}

		public static void TryAddScoped<TService>(this IServiceCollection collection) where TService : class
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			collection.TryAddScoped(typeof(TService), typeof(TService));
		}

		public static void TryAddScoped<TService, TImplementation>(this IServiceCollection collection) where TService : class where TImplementation : class, TService
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			collection.TryAddScoped(typeof(TService), typeof(TImplementation));
		}

		public static void TryAddScoped<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementationFactory) where TService : class
		{
			services.TryAdd(ServiceDescriptor.Scoped(implementationFactory));
		}

		public static void TryAddSingleton(this IServiceCollection collection, Type service)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (service == null)
			{
				throw new ArgumentNullException("service");
			}
			ServiceDescriptor descriptor = ServiceDescriptor.Singleton(service, service);
			collection.TryAdd(descriptor);
		}

		public static void TryAddSingleton(this IServiceCollection collection, Type service, Type implementationType)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (service == null)
			{
				throw new ArgumentNullException("service");
			}
			if (implementationType == null)
			{
				throw new ArgumentNullException("implementationType");
			}
			ServiceDescriptor descriptor = ServiceDescriptor.Singleton(service, implementationType);
			collection.TryAdd(descriptor);
		}

		public static void TryAddSingleton(this IServiceCollection collection, Type service, Func<IServiceProvider, object> implementationFactory)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (service == null)
			{
				throw new ArgumentNullException("service");
			}
			if (implementationFactory == null)
			{
				throw new ArgumentNullException("implementationFactory");
			}
			ServiceDescriptor descriptor = ServiceDescriptor.Singleton(service, implementationFactory);
			collection.TryAdd(descriptor);
		}

		public static void TryAddSingleton<TService>(this IServiceCollection collection) where TService : class
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			collection.TryAddSingleton(typeof(TService), typeof(TService));
		}

		public static void TryAddSingleton<TService, TImplementation>(this IServiceCollection collection) where TService : class where TImplementation : class, TService
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			collection.TryAddSingleton(typeof(TService), typeof(TImplementation));
		}

		public static void TryAddSingleton<TService>(this IServiceCollection collection, TService instance) where TService : class
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (instance == null)
			{
				throw new ArgumentNullException("instance");
			}
			ServiceDescriptor descriptor = ServiceDescriptor.Singleton(typeof(TService), instance);
			collection.TryAdd(descriptor);
		}

		public static void TryAddSingleton<TService>(this IServiceCollection services, Func<IServiceProvider, TService> implementationFactory) where TService : class
		{
			services.TryAdd(ServiceDescriptor.Singleton(implementationFactory));
		}

		public static void TryAddEnumerable(this IServiceCollection services, ServiceDescriptor descriptor)
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			if (descriptor == null)
			{
				throw new ArgumentNullException("descriptor");
			}
			Type implementationType = descriptor.GetImplementationType();
			if (implementationType == typeof(object) || implementationType == descriptor.ServiceType)
			{
				throw new ArgumentException(Resources.FormatTryAddIndistinguishableTypeToEnumerable(implementationType, descriptor.ServiceType), "descriptor");
			}
			if (!services.Any((ServiceDescriptor d) => d.ServiceType == descriptor.ServiceType && d.GetImplementationType() == implementationType))
			{
				services.Add(descriptor);
			}
		}

		public static void TryAddEnumerable(this IServiceCollection services, IEnumerable<ServiceDescriptor> descriptors)
		{
			if (services == null)
			{
				throw new ArgumentNullException("services");
			}
			if (descriptors == null)
			{
				throw new ArgumentNullException("descriptors");
			}
			foreach (ServiceDescriptor descriptor in descriptors)
			{
				services.TryAddEnumerable(descriptor);
			}
		}

		public static IServiceCollection Replace(this IServiceCollection collection, ServiceDescriptor descriptor)
		{
			if (collection == null)
			{
				throw new ArgumentNullException("collection");
			}
			if (descriptor == null)
			{
				throw new ArgumentNullException("descriptor");
			}
			ServiceDescriptor serviceDescriptor = collection.FirstOrDefault((ServiceDescriptor s) => s.ServiceType == descriptor.ServiceType);
			if (serviceDescriptor != null)
			{
				collection.Remove(serviceDescriptor);
			}
			collection.Add(descriptor);
			return collection;
		}

		public static IServiceCollection RemoveAll<T>(this IServiceCollection collection)
		{
			return collection.RemoveAll(typeof(T));
		}

		public static IServiceCollection RemoveAll(this IServiceCollection collection, Type serviceType)
		{
			if (serviceType == null)
			{
				throw new ArgumentNullException("serviceType");
			}
			for (int num = collection.Count - 1; num >= 0; num--)
			{
				if (collection[num].ServiceType == serviceType)
				{
					collection.RemoveAt(num);
				}
			}
			return collection;
		}
	}
}
