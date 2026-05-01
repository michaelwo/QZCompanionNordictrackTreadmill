using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Platform.Core;
using MvvmCross.Platform.Exceptions;
using MvvmCross.Platform.IoC;
using MvvmCross.Platform.Platform;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("MvvmCross.Platform")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("MvvmCross")]
[assembly: AssemblyCopyright("Copyright © 2016")]
[assembly: AssemblyTrademark("")]
[assembly: NeutralResourcesLanguage("en")]
[assembly: AssemblyFileVersion("4.0.0.0")]
[assembly: TargetFramework(".NETPortable,Version=v4.5,Profile=Profile259", FrameworkDisplayName = ".NET Portable Subset")]
[assembly: AssemblyVersion("4.0.0.0")]
namespace MvvmCross.Platform
{
	[Flags]
	public enum BindingFlags
	{
		None = 0,
		Instance = 1,
		Public = 2,
		Static = 4,
		FlattenHierarchy = 8,
		SetProperty = 0x2000
	}
	public static class Mvx
	{
		public static bool CanResolve<TService>() where TService : class
		{
			return MvxSingleton<IMvxIoCProvider>.Instance.CanResolve<TService>();
		}

		public static bool CanResolve(Type serviceType)
		{
			return MvxSingleton<IMvxIoCProvider>.Instance.CanResolve(serviceType);
		}

		public static TService Resolve<TService>() where TService : class
		{
			return MvxSingleton<IMvxIoCProvider>.Instance.Resolve<TService>();
		}

		public static object Resolve(Type serviceType)
		{
			return MvxSingleton<IMvxIoCProvider>.Instance.Resolve(serviceType);
		}

		public static bool TryResolve<TService>(out TService service) where TService : class
		{
			IMvxIoCProvider instance = MvxSingleton<IMvxIoCProvider>.Instance;
			if (instance == null)
			{
				service = null;
				return false;
			}
			return instance.TryResolve<TService>(out service);
		}

		public static bool TryResolve(Type serviceType, out object service)
		{
			IMvxIoCProvider instance = MvxSingleton<IMvxIoCProvider>.Instance;
			if (instance == null)
			{
				service = null;
				return false;
			}
			return instance.TryResolve(serviceType, out service);
		}

		public static T Create<T>() where T : class
		{
			return MvxSingleton<IMvxIoCProvider>.Instance.Create<T>();
		}

		public static T GetSingleton<T>() where T : class
		{
			return MvxSingleton<IMvxIoCProvider>.Instance.GetSingleton<T>();
		}

		public static void RegisterSingleton<TInterface>(Func<TInterface> serviceConstructor) where TInterface : class
		{
			MvxSingleton<IMvxIoCProvider>.Instance.RegisterSingleton(serviceConstructor);
		}

		public static void RegisterSingleton(Type tInterface, Func<object> serviceConstructor)
		{
			MvxSingleton<IMvxIoCProvider>.Instance.RegisterSingleton(tInterface, serviceConstructor);
		}

		public static void RegisterSingleton<TInterface>(TInterface service) where TInterface : class
		{
			MvxSingleton<IMvxIoCProvider>.Instance.RegisterSingleton(service);
		}

		public static void RegisterSingleton(Type tInterface, object service)
		{
			MvxSingleton<IMvxIoCProvider>.Instance.RegisterSingleton(tInterface, service);
		}

		public static void ConstructAndRegisterSingleton<TInterface, TType>() where TInterface : class where TType : TInterface
		{
			MvxSingleton<IMvxIoCProvider>.Instance.RegisterSingleton((TInterface)(object)IocConstruct<TType>());
		}

		public static void LazyConstructAndRegisterSingleton<TInterface, TType>() where TInterface : class where TType : TInterface
		{
			MvxSingleton<IMvxIoCProvider>.Instance.RegisterSingleton(() => (TInterface)(object)IocConstruct<TType>());
		}

		public static void LazyConstructAndRegisterSingleton<TInterface>(Func<TInterface> constructor) where TInterface : class
		{
			MvxSingleton<IMvxIoCProvider>.Instance.RegisterSingleton(constructor);
		}

		public static void LazyConstructAndRegisterSingleton(Type type, Func<object> constructor)
		{
			MvxSingleton<IMvxIoCProvider>.Instance.RegisterSingleton(type, constructor);
		}

		public static void RegisterType<TInterface, TType>() where TInterface : class where TType : class, TInterface
		{
			MvxSingleton<IMvxIoCProvider>.Instance.RegisterType<TInterface, TType>();
		}

		public static void RegisterType<TInterface>(Func<TInterface> constructor) where TInterface : class
		{
			MvxSingleton<IMvxIoCProvider>.Instance.RegisterType(constructor);
		}

		public static void RegisterType(Type type, Func<object> constructor)
		{
			MvxSingleton<IMvxIoCProvider>.Instance.RegisterType(type, constructor);
		}

		public static void RegisterType(Type tInterface, Type tType)
		{
			MvxSingleton<IMvxIoCProvider>.Instance.RegisterType(tInterface, tType);
		}

		public static T IocConstruct<T>()
		{
			return (T)MvxSingleton<IMvxIoCProvider>.Instance.IoCConstruct(typeof(T));
		}

		public static object IocConstruct(Type t)
		{
			return MvxSingleton<IMvxIoCProvider>.Instance.IoCConstruct(t);
		}

		public static void CallbackWhenRegistered<T>(Action<T> action) where T : class
		{
			CallbackWhenRegistered<T>((Action)delegate
			{
				T obj = Resolve<T>();
				action(obj);
			});
		}

		public static void CallbackWhenRegistered<T>(Action action)
		{
			MvxSingleton<IMvxIoCProvider>.Instance.CallbackWhenRegistered<T>(action);
		}

		public static void CallbackWhenRegistered(Type type, Action action)
		{
			MvxSingleton<IMvxIoCProvider>.Instance.CallbackWhenRegistered(type, action);
		}

		public static void TaggedTrace(MvxTraceLevel level, string tag, string message, params object[] args)
		{
			MvxTrace.TaggedTrace(level, tag, message, args);
		}

		public static void Trace(MvxTraceLevel level, string message, params object[] args)
		{
			MvxTrace.Trace(level, message, args);
		}

		public static void TaggedTrace(string tag, string message, params object[] args)
		{
			TaggedTrace(MvxTraceLevel.Diagnostic, tag, message, args);
		}

		public static void TaggedWarning(string tag, string message, params object[] args)
		{
			TaggedTrace(MvxTraceLevel.Warning, tag, message, args);
		}

		public static void TaggedError(string tag, string message, params object[] args)
		{
			TaggedTrace(MvxTraceLevel.Error, tag, message, args);
		}

		public static void Trace(string message, params object[] args)
		{
			Trace(MvxTraceLevel.Diagnostic, message, args);
		}

		public static void Warning(string message, params object[] args)
		{
			Trace(MvxTraceLevel.Warning, message, args);
		}

		public static void Error(string message, params object[] args)
		{
			Trace(MvxTraceLevel.Error, message, args);
		}

		public static MvxException Exception(string message)
		{
			return new MvxException(message);
		}

		public static MvxException Exception(string message, params object[] args)
		{
			return new MvxException(message, args);
		}

		public static MvxException Exception(Exception innerException, string message, params object[] args)
		{
			return new MvxException(innerException, message, args);
		}
	}
	public static class ReflectionExtensions
	{
		public static IEnumerable<Type> GetTypes(this Assembly assembly)
		{
			foreach (TypeInfo definedType in assembly.DefinedTypes)
			{
				yield return definedType.AsType();
			}
		}

		public static EventInfo GetEvent(this Type type, string name)
		{
			return type.GetRuntimeEvent(name);
		}

		public static IEnumerable<Type> GetInterfaces(this Type type)
		{
			return type.GetTypeInfo().ImplementedInterfaces;
		}

		public static bool IsAssignableFrom(this Type type, Type otherType)
		{
			return type.GetTypeInfo().IsAssignableFrom(otherType.GetTypeInfo());
		}

		public static Attribute[] GetCustomAttributes(this Type type, Type attributeType, bool inherit)
		{
			return CustomAttributeExtensions.GetCustomAttributes(type.GetTypeInfo(), attributeType, inherit).ToArray();
		}

		public static IEnumerable<ConstructorInfo> GetConstructors(this Type type)
		{
			IEnumerable<ConstructorInfo> declaredConstructors = type.GetTypeInfo().DeclaredConstructors;
			foreach (ConstructorInfo item in declaredConstructors)
			{
				if (item.IsPublic)
				{
					yield return item;
				}
			}
		}

		public static bool IsInstanceOfType(this Type type, object obj)
		{
			if (!IsAssignableFrom(type, obj.GetType()))
			{
				return obj.IsMarshalByRefObject();
			}
			return true;
		}

		private static bool IsMarshalByRefObject(this object obj)
		{
			if (obj != null)
			{
				return obj.GetType().FullName == "System.MarshalByRefObject";
			}
			return false;
		}

		public static MethodInfo GetAddMethod(this EventInfo eventInfo, bool nonPublic = false)
		{
			if ((object)eventInfo.AddMethod == null || (!nonPublic && !eventInfo.AddMethod.IsPublic))
			{
				return null;
			}
			return eventInfo.AddMethod;
		}

		public static MethodInfo GetRemoveMethod(this EventInfo eventInfo, bool nonPublic = false)
		{
			if ((object)eventInfo.RemoveMethod == null || (!nonPublic && !eventInfo.RemoveMethod.IsPublic))
			{
				return null;
			}
			return eventInfo.RemoveMethod;
		}

		public static MethodInfo GetGetMethod(this PropertyInfo property, bool nonPublic = false)
		{
			if ((object)property.GetMethod == null || (!nonPublic && !property.GetMethod.IsPublic))
			{
				return null;
			}
			return property.GetMethod;
		}

		public static MethodInfo GetSetMethod(this PropertyInfo property, bool nonPublic = false)
		{
			if ((object)property.SetMethod == null || (!nonPublic && !property.SetMethod.IsPublic))
			{
				return null;
			}
			return property.SetMethod;
		}

		public static IEnumerable<PropertyInfo> GetProperties(this Type type)
		{
			return type.GetProperties(BindingFlags.Public | BindingFlags.FlattenHierarchy);
		}

		private static bool NullSafeIsPublic(this MethodInfo info)
		{
			return info?.IsPublic ?? false;
		}

		private static bool NullSafeIsStatic(this MethodInfo info)
		{
			return info?.IsStatic ?? false;
		}

		public static IEnumerable<PropertyInfo> GetProperties(this Type type, BindingFlags flags)
		{
			IEnumerable<PropertyInfo> enumerable = (((flags & BindingFlags.FlattenHierarchy) != BindingFlags.None) ? type.GetRuntimeProperties() : type.GetTypeInfo().DeclaredProperties);
			foreach (PropertyInfo item in enumerable)
			{
				MethodInfo getMethod = item.GetMethod;
				MethodInfo setMethod = item.SetMethod;
				if ((object)getMethod != null || (object)setMethod != null)
				{
					bool num = (flags & BindingFlags.Public) != BindingFlags.Public || getMethod.NullSafeIsPublic() || setMethod.NullSafeIsPublic();
					bool flag = (flags & BindingFlags.Instance) != BindingFlags.Instance || !getMethod.NullSafeIsStatic() || !setMethod.NullSafeIsStatic();
					bool flag2 = (flags & BindingFlags.Static) != BindingFlags.Static || getMethod.NullSafeIsStatic() || setMethod.NullSafeIsStatic();
					if (num && flag && flag2)
					{
						yield return item;
					}
				}
			}
		}

		public static PropertyInfo GetProperty(this Type type, string name, BindingFlags flags)
		{
			foreach (PropertyInfo property in type.GetProperties(flags))
			{
				if (property.Name == name)
				{
					return property;
				}
			}
			return null;
		}

		public static PropertyInfo GetProperty(this Type type, string name)
		{
			foreach (PropertyInfo property in type.GetProperties(BindingFlags.Public | BindingFlags.FlattenHierarchy))
			{
				if (property.Name == name)
				{
					return property;
				}
			}
			return null;
		}

		public static IEnumerable<MethodInfo> GetMethods(this Type type)
		{
			return type.GetMethods(BindingFlags.Public | BindingFlags.FlattenHierarchy);
		}

		public static IEnumerable<MethodInfo> GetMethods(this Type type, BindingFlags flags)
		{
			IEnumerable<MethodInfo> enumerable = type.GetTypeInfo().DeclaredMethods;
			if ((flags & BindingFlags.FlattenHierarchy) == BindingFlags.FlattenHierarchy)
			{
				enumerable = type.GetRuntimeMethods();
			}
			foreach (MethodInfo item in enumerable)
			{
				bool num = (flags & BindingFlags.Public) != BindingFlags.Public || item.IsPublic;
				bool flag = (flags & BindingFlags.Instance) != BindingFlags.Instance || !item.IsStatic;
				bool flag2 = (flags & BindingFlags.Static) != BindingFlags.Static || item.IsStatic;
				if (num && flag && flag2)
				{
					yield return item;
				}
			}
		}

		public static MethodInfo GetMethod(this Type type, string name, BindingFlags flags)
		{
			foreach (MethodInfo method in type.GetMethods(flags))
			{
				if (method.Name == name)
				{
					return method;
				}
			}
			return null;
		}

		public static MethodInfo GetMethod(this Type type, string name)
		{
			foreach (MethodInfo method in type.GetMethods(BindingFlags.Public | BindingFlags.FlattenHierarchy))
			{
				if (method.Name == name)
				{
					return method;
				}
			}
			return null;
		}

		public static IEnumerable<ConstructorInfo> GetConstructors(this Type type, BindingFlags flags)
		{
			IEnumerable<ConstructorInfo> constructors = GetConstructors(type);
			foreach (ConstructorInfo item in constructors)
			{
				bool num = (flags & BindingFlags.Public) != BindingFlags.Public || item.IsPublic;
				bool flag = (flags & BindingFlags.Instance) != BindingFlags.Instance || !item.IsStatic;
				bool flag2 = (flags & BindingFlags.Static) != BindingFlags.Static || item.IsStatic;
				if (num && flag && flag2)
				{
					yield return item;
				}
			}
		}

		public static IEnumerable<FieldInfo> GetFields(this Type type)
		{
			return type.GetFields(BindingFlags.Public | BindingFlags.FlattenHierarchy);
		}

		public static IEnumerable<FieldInfo> GetFields(this Type type, BindingFlags flags)
		{
			IEnumerable<FieldInfo> enumerable = type.GetTypeInfo().DeclaredFields;
			if ((flags & BindingFlags.FlattenHierarchy) == BindingFlags.FlattenHierarchy)
			{
				enumerable = type.GetRuntimeFields();
			}
			foreach (FieldInfo item in enumerable)
			{
				bool num = (flags & BindingFlags.Public) != BindingFlags.Public || item.IsPublic;
				bool flag = (flags & BindingFlags.Instance) != BindingFlags.Instance || !item.IsStatic;
				bool flag2 = (flags & BindingFlags.Static) != BindingFlags.Static || item.IsStatic;
				if (num && flag && flag2)
				{
					yield return item;
				}
			}
		}

		public static FieldInfo GetField(this Type type, string name, BindingFlags flags)
		{
			foreach (FieldInfo field in type.GetFields(flags))
			{
				if (field.Name == name)
				{
					return field;
				}
			}
			return null;
		}

		public static FieldInfo GetField(this Type type, string name)
		{
			foreach (FieldInfo field in type.GetFields(BindingFlags.Public | BindingFlags.FlattenHierarchy))
			{
				if (field.Name == name)
				{
					return field;
				}
			}
			return null;
		}

		public static Type[] GetGenericArguments(this Type type)
		{
			return type.GenericTypeArguments;
		}
	}
}
namespace MvvmCross.Platform.WeakSubscription
{
	public class MvxCanExecuteChangedEventSubscription : MvxWeakEventSubscription<ICommand, EventArgs>
	{
		private static readonly EventInfo CanExecuteChangedEventInfo = ReflectionExtensions.GetEvent(typeof(ICommand), "CanExecuteChanged");

		public MvxCanExecuteChangedEventSubscription(ICommand source, EventHandler<EventArgs> eventHandler)
			: base(source, CanExecuteChangedEventInfo, eventHandler)
		{
		}

		protected override Delegate CreateEventHandler()
		{
			return new EventHandler(base.OnSourceEvent);
		}
	}
	public class MvxGeneralEventSubscription : MvxWeakEventSubscription<object, EventArgs>
	{
		public MvxGeneralEventSubscription(object source, EventInfo eventInfo, EventHandler<EventArgs> eventHandler)
			: base(source, eventInfo, eventHandler)
		{
		}

		protected override Delegate CreateEventHandler()
		{
			return new EventHandler(base.OnSourceEvent);
		}
	}
	public class MvxNamedNotifyPropertyChangedEventSubscription<T> : MvxNotifyPropertyChangedEventSubscription
	{
		private readonly string _propertyName;

		public MvxNamedNotifyPropertyChangedEventSubscription(INotifyPropertyChanged source, Expression<Func<T>> property, EventHandler<PropertyChangedEventArgs> targetEventHandler)
			: this(source, source.GetPropertyNameFromExpression(property), targetEventHandler)
		{
		}

		public MvxNamedNotifyPropertyChangedEventSubscription(INotifyPropertyChanged source, string propertyName, EventHandler<PropertyChangedEventArgs> targetEventHandler)
			: base(source, targetEventHandler)
		{
			_propertyName = propertyName;
		}

		protected override Delegate CreateEventHandler()
		{
			return (PropertyChangedEventHandler)delegate(object sender, PropertyChangedEventArgs e)
			{
				if (string.IsNullOrEmpty(e.PropertyName) || e.PropertyName == _propertyName)
				{
					OnSourceEvent(sender, e);
				}
			};
		}
	}
	public class MvxNotifyCollectionChangedEventSubscription : MvxWeakEventSubscription<INotifyCollectionChanged, NotifyCollectionChangedEventArgs>
	{
		private static readonly EventInfo EventInfo = ReflectionExtensions.GetEvent(typeof(INotifyCollectionChanged), "CollectionChanged");

		public static void LinkerPleaseInclude(INotifyCollectionChanged iNotifyCollectionChanged)
		{
			iNotifyCollectionChanged.CollectionChanged += delegate
			{
			};
		}

		public MvxNotifyCollectionChangedEventSubscription(INotifyCollectionChanged source, EventHandler<NotifyCollectionChangedEventArgs> targetEventHandler)
			: base(source, EventInfo, targetEventHandler)
		{
		}

		protected override Delegate CreateEventHandler()
		{
			return new NotifyCollectionChangedEventHandler(base.OnSourceEvent);
		}
	}
	public class MvxNotifyPropertyChangedEventSubscription : MvxWeakEventSubscription<INotifyPropertyChanged, PropertyChangedEventArgs>
	{
		private static readonly EventInfo PropertyChangedEventInfo = ReflectionExtensions.GetEvent(typeof(INotifyPropertyChanged), "PropertyChanged");

		public static void LinkerPleaseInclude(INotifyPropertyChanged iNotifyPropertyChanged)
		{
			iNotifyPropertyChanged.PropertyChanged += delegate
			{
			};
		}

		public MvxNotifyPropertyChangedEventSubscription(INotifyPropertyChanged source, EventHandler<PropertyChangedEventArgs> targetEventHandler)
			: base(source, PropertyChangedEventInfo, targetEventHandler)
		{
		}

		protected override Delegate CreateEventHandler()
		{
			return new PropertyChangedEventHandler(base.OnSourceEvent);
		}
	}
	public class MvxValueEventSubscription<T> : MvxWeakEventSubscription<object, MvxValueEventArgs<T>>
	{
		public MvxValueEventSubscription(object source, EventInfo eventInfo, EventHandler<MvxValueEventArgs<T>> eventHandler)
			: base(source, eventInfo, eventHandler)
		{
		}

		protected override Delegate CreateEventHandler()
		{
			return new EventHandler<MvxValueEventArgs<T>>(base.OnSourceEvent);
		}
	}
	public class MvxWeakEventSubscription<TSource, TEventArgs> : IDisposable where TSource : class
	{
		private readonly WeakReference _targetReference;

		private readonly WeakReference<TSource> _sourceReference;

		private readonly MethodInfo _eventHandlerMethodInfo;

		private readonly EventInfo _sourceEventInfo;

		private readonly Delegate _ourEventHandler;

		private bool _subscribed;

		public MvxWeakEventSubscription(TSource source, string sourceEventName, EventHandler<TEventArgs> targetEventHandler)
			: this(source, ReflectionExtensions.GetEvent(typeof(TSource), sourceEventName), targetEventHandler)
		{
		}

		protected MvxWeakEventSubscription(TSource source, EventInfo sourceEventInfo, EventHandler<TEventArgs> targetEventHandler)
		{
			if (source == null)
			{
				throw new ArgumentNullException();
			}
			if ((object)sourceEventInfo == null)
			{
				throw new ArgumentNullException("sourceEventInfo", "missing source event info in MvxWeakEventSubscription");
			}
			_eventHandlerMethodInfo = targetEventHandler.GetMethodInfo();
			_targetReference = new WeakReference(targetEventHandler.Target);
			_sourceReference = new WeakReference<TSource>(source);
			_sourceEventInfo = sourceEventInfo;
			_ourEventHandler = CreateEventHandler();
			AddEventHandler();
		}

		protected virtual Delegate CreateEventHandler()
		{
			return new EventHandler<TEventArgs>(OnSourceEvent);
		}

		protected virtual object GetTargetObject()
		{
			return _targetReference.Target;
		}

		protected void OnSourceEvent(object sender, TEventArgs e)
		{
			object targetObject = GetTargetObject();
			if (targetObject != null)
			{
				_eventHandlerMethodInfo.Invoke(targetObject, new object[2] { sender, e });
			}
			else
			{
				RemoveEventHandler();
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				RemoveEventHandler();
			}
		}

		private void RemoveEventHandler()
		{
			if (_subscribed && _sourceReference.TryGetTarget(out var target))
			{
				ReflectionExtensions.GetRemoveMethod(_sourceEventInfo).Invoke(target, new object[1] { _ourEventHandler });
				_subscribed = false;
			}
		}

		private void AddEventHandler()
		{
			if (_subscribed)
			{
				throw new MvxException("Should not call _subscribed twice");
			}
			if (_sourceReference.TryGetTarget(out var target))
			{
				ReflectionExtensions.GetAddMethod(_sourceEventInfo).Invoke(target, new object[1] { _ourEventHandler });
				_subscribed = true;
			}
		}
	}
	public class MvxWeakEventSubscription<TSource> : IDisposable where TSource : class
	{
		private readonly WeakReference _targetReference;

		private readonly WeakReference<TSource> _sourceReference;

		private readonly MethodInfo _eventHandlerMethodInfo;

		private readonly EventInfo _sourceEventInfo;

		private readonly Delegate _ourEventHandler;

		private bool _subscribed;

		public MvxWeakEventSubscription(TSource source, string sourceEventName, EventHandler targetEventHandler)
			: this(source, ReflectionExtensions.GetEvent(typeof(TSource), sourceEventName), targetEventHandler)
		{
		}

		protected MvxWeakEventSubscription(TSource source, EventInfo sourceEventInfo, EventHandler targetEventHandler)
		{
			if (source == null)
			{
				throw new ArgumentNullException();
			}
			if ((object)sourceEventInfo == null)
			{
				throw new ArgumentNullException("sourceEventInfo", "missing source event info in MvxWeakEventSubscription");
			}
			_eventHandlerMethodInfo = targetEventHandler.GetMethodInfo();
			_targetReference = new WeakReference(targetEventHandler.Target);
			_sourceReference = new WeakReference<TSource>(source);
			_sourceEventInfo = sourceEventInfo;
			_ourEventHandler = CreateEventHandler();
			AddEventHandler();
		}

		protected virtual object GetTargetObject()
		{
			return _targetReference.Target;
		}

		protected virtual Delegate CreateEventHandler()
		{
			return new EventHandler(OnSourceEvent);
		}

		protected void OnSourceEvent(object sender, EventArgs e)
		{
			object targetObject = GetTargetObject();
			if (targetObject != null)
			{
				_eventHandlerMethodInfo.Invoke(targetObject, new object[2] { sender, e });
			}
			else
			{
				RemoveEventHandler();
			}
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (disposing)
			{
				RemoveEventHandler();
			}
		}

		private void RemoveEventHandler()
		{
			if (_subscribed && _sourceReference.TryGetTarget(out var target))
			{
				ReflectionExtensions.GetRemoveMethod(_sourceEventInfo).Invoke(target, new object[1] { _ourEventHandler });
				_subscribed = false;
			}
		}

		private void AddEventHandler()
		{
			if (_subscribed)
			{
				throw new MvxException("Should not call _subscribed twice");
			}
			if (_sourceReference.TryGetTarget(out var target))
			{
				ReflectionExtensions.GetAddMethod(_sourceEventInfo).Invoke(target, new object[1] { _ourEventHandler });
				_subscribed = true;
			}
		}
	}
	public static class MvxWeakSubscriptionExtensionMethods
	{
		public static MvxNotifyPropertyChangedEventSubscription WeakSubscribe(this INotifyPropertyChanged source, EventHandler<PropertyChangedEventArgs> eventHandler)
		{
			return new MvxNotifyPropertyChangedEventSubscription(source, eventHandler);
		}

		public static MvxNamedNotifyPropertyChangedEventSubscription<T> WeakSubscribe<T>(this INotifyPropertyChanged source, Expression<Func<T>> property, EventHandler<PropertyChangedEventArgs> eventHandler)
		{
			return new MvxNamedNotifyPropertyChangedEventSubscription<T>(source, property, eventHandler);
		}

		public static MvxNamedNotifyPropertyChangedEventSubscription<T> WeakSubscribe<T>(this INotifyPropertyChanged source, string property, EventHandler<PropertyChangedEventArgs> eventHandler)
		{
			return new MvxNamedNotifyPropertyChangedEventSubscription<T>(source, property, eventHandler);
		}

		public static MvxNotifyCollectionChangedEventSubscription WeakSubscribe(this INotifyCollectionChanged source, EventHandler<NotifyCollectionChangedEventArgs> eventHandler)
		{
			return new MvxNotifyCollectionChangedEventSubscription(source, eventHandler);
		}

		public static MvxGeneralEventSubscription WeakSubscribe(this EventInfo eventInfo, object source, EventHandler<EventArgs> eventHandler)
		{
			return new MvxGeneralEventSubscription(source, eventInfo, eventHandler);
		}

		public static MvxValueEventSubscription<T> WeakSubscribe<T>(this EventInfo eventInfo, object source, EventHandler<MvxValueEventArgs<T>> eventHandler)
		{
			return new MvxValueEventSubscription<T>(source, eventInfo, eventHandler);
		}

		public static MvxCanExecuteChangedEventSubscription WeakSubscribe(this ICommand source, EventHandler<EventArgs> eventHandler)
		{
			return new MvxCanExecuteChangedEventSubscription(source, eventHandler);
		}

		public static MvxWeakEventSubscription<TSource> WeakSubscribe<TSource>(this TSource source, string eventName, EventHandler eventHandler) where TSource : class
		{
			return new MvxWeakEventSubscription<TSource>(source, eventName, eventHandler);
		}

		public static MvxWeakEventSubscription<TSource, TEventArgs> WeakSubscribe<TSource, TEventArgs>(this TSource source, string eventName, EventHandler<TEventArgs> eventHandler) where TSource : class
		{
			return new MvxWeakEventSubscription<TSource, TEventArgs>(source, eventName, eventHandler);
		}
	}
}
namespace MvvmCross.Platform.UI
{
	public interface IMvxNativeVisibility
	{
		object ToNative(MvxVisibility visibility);
	}
	public static class MvxColors
	{
		public static MvxColor Transparent = new MvxColor(16777215);

		public static MvxColor AliceBlue = new MvxColor(4293982463u);

		public static MvxColor AntiqueWhite = new MvxColor(4294634455u);

		public static MvxColor Aqua = new MvxColor(4278255615u);

		public static MvxColor Aquamarine = new MvxColor(4286578644u);

		public static MvxColor Azure = new MvxColor(4293984255u);

		public static MvxColor Beige = new MvxColor(4294309340u);

		public static MvxColor Bisque = new MvxColor(4294960324u);

		public static MvxColor Black = new MvxColor(4278190080u);

		public static MvxColor BlanchedAlmond = new MvxColor(4294962125u);

		public static MvxColor Blue = new MvxColor(4278190335u);

		public static MvxColor BlueViolet = new MvxColor(4287245282u);

		public static MvxColor Brown = new MvxColor(4289014314u);

		public static MvxColor BurlyWood = new MvxColor(4292786311u);

		public static MvxColor CadetBlue = new MvxColor(4284456608u);

		public static MvxColor Chartreuse = new MvxColor(4286578432u);

		public static MvxColor Chocolate = new MvxColor(4291979550u);

		public static MvxColor Coral = new MvxColor(4294934352u);

		public static MvxColor CornflowerBlue = new MvxColor(4284782061u);

		public static MvxColor Cornsilk = new MvxColor(4294965468u);

		public static MvxColor Crimson = new MvxColor(4292613180u);

		public static MvxColor Cyan = new MvxColor(4278255615u);

		public static MvxColor DarkBlue = new MvxColor(4278190219u);

		public static MvxColor DarkCyan = new MvxColor(4278225803u);

		public static MvxColor DarkGoldenrod = new MvxColor(4290283019u);

		public static MvxColor DarkGray = new MvxColor(4289309097u);

		public static MvxColor DarkGreen = new MvxColor(4278215680u);

		public static MvxColor DarkKhaki = new MvxColor(4290623339u);

		public static MvxColor DarkMagenta = new MvxColor(4287299723u);

		public static MvxColor DarkOliveGreen = new MvxColor(4283788079u);

		public static MvxColor DarkOrange = new MvxColor(4294937600u);

		public static MvxColor DarkOrchid = new MvxColor(4288230092u);

		public static MvxColor DarkRed = new MvxColor(4287299584u);

		public static MvxColor DarkSalmon = new MvxColor(4293498490u);

		public static MvxColor DarkSeaGreen = new MvxColor(4287609995u);

		public static MvxColor DarkSlateBlue = new MvxColor(4282924427u);

		public static MvxColor DarkSlateGray = new MvxColor(4281290575u);

		public static MvxColor DarkTurquoise = new MvxColor(4278243025u);

		public static MvxColor DarkViolet = new MvxColor(4287889619u);

		public static MvxColor DeepPink = new MvxColor(4294907027u);

		public static MvxColor DeepSkyBlue = new MvxColor(4278239231u);

		public static MvxColor DimGray = new MvxColor(4285098345u);

		public static MvxColor DodgerBlue = new MvxColor(4280193279u);

		public static MvxColor Firebrick = new MvxColor(4289864226u);

		public static MvxColor FloralWhite = new MvxColor(4294966000u);

		public static MvxColor ForestGreen = new MvxColor(4280453922u);

		public static MvxColor Fuchsia = new MvxColor(4294902015u);

		public static MvxColor Gainsboro = new MvxColor(4292664540u);

		public static MvxColor GhostWhite = new MvxColor(4294506751u);

		public static MvxColor Gold = new MvxColor(4294956800u);

		public static MvxColor Goldenrod = new MvxColor(4292519200u);

		public static MvxColor Gray = new MvxColor(4286611584u);

		public static MvxColor Green = new MvxColor(4278222848u);

		public static MvxColor GreenYellow = new MvxColor(4289593135u);

		public static MvxColor Honeydew = new MvxColor(4293984240u);

		public static MvxColor HotPink = new MvxColor(4294928820u);

		public static MvxColor IndianRed = new MvxColor(4291648604u);

		public static MvxColor Indigo = new MvxColor(4283105410u);

		public static MvxColor Ivory = new MvxColor(4294967280u);

		public static MvxColor Khaki = new MvxColor(4293977740u);

		public static MvxColor Lavender = new MvxColor(4293322490u);

		public static MvxColor LavenderBlush = new MvxColor(4294963445u);

		public static MvxColor LawnGreen = new MvxColor(4286381056u);

		public static MvxColor LemonChiffon = new MvxColor(4294965965u);

		public static MvxColor LightBlue = new MvxColor(4289583334u);

		public static MvxColor LightCoral = new MvxColor(4293951616u);

		public static MvxColor LightCyan = new MvxColor(4292935679u);

		public static MvxColor LightGoldenrodYellow = new MvxColor(4294638290u);

		public static MvxColor LightGray = new MvxColor(4292072403u);

		public static MvxColor LightGreen = new MvxColor(4287688336u);

		public static MvxColor LightPink = new MvxColor(4294948545u);

		public static MvxColor LightSalmon = new MvxColor(4294942842u);

		public static MvxColor LightSeaGreen = new MvxColor(4280332970u);

		public static MvxColor LightSkyBlue = new MvxColor(4287090426u);

		public static MvxColor LightSlateGray = new MvxColor(4286023833u);

		public static MvxColor LightSteelBlue = new MvxColor(4289774814u);

		public static MvxColor LightYellow = new MvxColor(4294967264u);

		public static MvxColor Lime = new MvxColor(4278255360u);

		public static MvxColor LimeGreen = new MvxColor(4281519410u);

		public static MvxColor Linen = new MvxColor(4294635750u);

		public static MvxColor Magenta = new MvxColor(4294902015u);

		public static MvxColor Maroon = new MvxColor(4286578688u);

		public static MvxColor MediumAquamarine = new MvxColor(4284927402u);

		public static MvxColor MediumBlue = new MvxColor(4278190285u);

		public static MvxColor MediumOrchid = new MvxColor(4290401747u);

		public static MvxColor MediumPurple = new MvxColor(4287852763u);

		public static MvxColor MediumSeaGreen = new MvxColor(4282168177u);

		public static MvxColor MediumSlateBlue = new MvxColor(4286277870u);

		public static MvxColor MediumSpringGreen = new MvxColor(4278254234u);

		public static MvxColor MediumTurquoise = new MvxColor(4282962380u);

		public static MvxColor MediumVioletRed = new MvxColor(4291237253u);

		public static MvxColor MidnightBlue = new MvxColor(4279834992u);

		public static MvxColor MintCream = new MvxColor(4294311930u);

		public static MvxColor MistyRose = new MvxColor(4294960353u);

		public static MvxColor Moccasin = new MvxColor(4294960309u);

		public static MvxColor NavajoWhite = new MvxColor(4294958765u);

		public static MvxColor Navy = new MvxColor(4278190208u);

		public static MvxColor OldLace = new MvxColor(4294833638u);

		public static MvxColor Olive = new MvxColor(4286611456u);

		public static MvxColor OliveDrab = new MvxColor(4285238819u);

		public static MvxColor Orange = new MvxColor(4294944000u);

		public static MvxColor OrangeRed = new MvxColor(4294919424u);

		public static MvxColor Orchid = new MvxColor(4292505814u);

		public static MvxColor PaleGoldenrod = new MvxColor(4293847210u);

		public static MvxColor PaleGreen = new MvxColor(4288215960u);

		public static MvxColor PaleTurquoise = new MvxColor(4289720046u);

		public static MvxColor PaleVioletRed = new MvxColor(4292571283u);

		public static MvxColor PapayaWhip = new MvxColor(4294963157u);

		public static MvxColor PeachPuff = new MvxColor(4294957753u);

		public static MvxColor Peru = new MvxColor(4291659071u);

		public static MvxColor Pink = new MvxColor(4294951115u);

		public static MvxColor Plum = new MvxColor(4292714717u);

		public static MvxColor PowderBlue = new MvxColor(4289781990u);

		public static MvxColor Purple = new MvxColor(4286578816u);

		public static MvxColor Red = new MvxColor(4294901760u);

		public static MvxColor RosyBrown = new MvxColor(4290547599u);

		public static MvxColor RoyalBlue = new MvxColor(4282477025u);

		public static MvxColor SaddleBrown = new MvxColor(4287317267u);

		public static MvxColor Salmon = new MvxColor(4294606962u);

		public static MvxColor SandyBrown = new MvxColor(4294222944u);

		public static MvxColor SeaGreen = new MvxColor(4281240407u);

		public static MvxColor SeaShell = new MvxColor(4294964718u);

		public static MvxColor Sienna = new MvxColor(4288696877u);

		public static MvxColor Silver = new MvxColor(4290822336u);

		public static MvxColor SkyBlue = new MvxColor(4287090411u);

		public static MvxColor SlateBlue = new MvxColor(4285160141u);

		public static MvxColor SlateGray = new MvxColor(4285563024u);

		public static MvxColor Snow = new MvxColor(4294966010u);

		public static MvxColor SpringGreen = new MvxColor(4278255487u);

		public static MvxColor SteelBlue = new MvxColor(4282811060u);

		public static MvxColor Tan = new MvxColor(4291998860u);

		public static MvxColor Teal = new MvxColor(4278222976u);

		public static MvxColor Thistle = new MvxColor(4292394968u);

		public static MvxColor Tomato = new MvxColor(4294927175u);

		public static MvxColor Turquoise = new MvxColor(4282441936u);

		public static MvxColor Violet = new MvxColor(4293821166u);

		public static MvxColor Wheat = new MvxColor(4294303411u);

		public static MvxColor White = new MvxColor(4294967295u);

		public static MvxColor WhiteSmoke = new MvxColor(4294309365u);

		public static MvxColor Yellow = new MvxColor(4294967040u);

		public static MvxColor YellowGreen = new MvxColor(4288335154u);
	}
	public enum MvxVisibility : byte
	{
		Visible,
		Collapsed
	}
	public interface IMvxNativeColor
	{
		object ToNative(MvxColor mvxColor);
	}
	public class MvxColor
	{
		public int ARGB { get; set; }

		public int R
		{
			get
			{
				return MaskAndShiftRight(ARGB, 16711680u, 16);
			}
			set
			{
				ARGB = ShiftOverwrite(ARGB, 4278255615u, value, 16);
			}
		}

		public int G
		{
			get
			{
				return MaskAndShiftRight(ARGB, 65280u, 8);
			}
			set
			{
				ARGB = ShiftOverwrite(ARGB, 4294902015u, value, 8);
			}
		}

		public int B
		{
			get
			{
				return MaskAndShiftRight(ARGB, 255u, 0);
			}
			set
			{
				ARGB = ShiftOverwrite(ARGB, 4294967040u, value, 0);
			}
		}

		public int A
		{
			get
			{
				return MaskAndShiftRight(ARGB, 4278190080u, 24);
			}
			set
			{
				ARGB = ShiftOverwrite(ARGB, 16777215u, value, 24);
			}
		}

		private static int MaskAndShiftRight(int value, uint mask, int shift)
		{
			return (int)((value & mask) >> shift);
		}

		private static int ShiftOverwrite(int original, uint mask, int value, int shift)
		{
			long num = original & mask;
			int num2 = value << shift;
			return (int)(num | num2);
		}

		public MvxColor(uint argb)
			: this((int)argb)
		{
		}

		public MvxColor(int argb)
		{
			ARGB = argb;
		}

		public MvxColor(uint rgb, int alpha)
			: this((int)rgb, alpha)
		{
		}

		public MvxColor(int rgb, int alpha)
		{
			ARGB = rgb;
			A = alpha;
		}

		public MvxColor(int red, int green, int blue, int alpha = 255)
		{
			R = red;
			G = green;
			B = blue;
			A = alpha;
		}

		public override string ToString()
		{
			return $"argb: #{A:X2}{R:X2}{G:X2}{B:X2}";
		}
	}
}
namespace MvvmCross.Platform.Plugins
{
	public interface IMvxConfigurablePlugin : IMvxPlugin
	{
		void Configure(IMvxPluginConfiguration configuration);
	}
	public interface IMvxConfigurablePluginLoader : IMvxPluginLoader
	{
		void Configure(IMvxPluginConfiguration configuration);
	}
	public interface IMvxPluginConfiguration
	{
	}
	public interface IMvxPluginLoader
	{
		void EnsureLoaded();
	}
	public class MvxLoaderPluginBootstrapAction<TPlugin, TPlatformPlugin> : MvxPluginBootstrapAction<TPlugin> where TPlugin : IMvxPluginLoader where TPlatformPlugin : IMvxPlugin
	{
		protected override void Load(IMvxPluginManager manager)
		{
			PreLoad(manager);
			base.Load(manager);
		}

		protected virtual void PreLoad(IMvxPluginManager manager)
		{
			manager.Registry.Register<TPlugin, TPlatformPlugin>();
		}
	}
	public class MvxPluginBootstrapAction<TPlugin> : IMvxBootstrapAction
	{
		public virtual void Run()
		{
			Mvx.CallbackWhenRegistered<IMvxPluginManager>(RunAction);
		}

		protected virtual void RunAction()
		{
			IMvxPluginManager manager = Mvx.Resolve<IMvxPluginManager>();
			Load(manager);
		}

		protected virtual void Load(IMvxPluginManager manager)
		{
			manager.EnsurePluginLoaded<TPlugin>();
		}
	}
	public interface IMvxPlugin
	{
		void Load();
	}
	public interface IMvxPluginManager
	{
		Func<Type, IMvxPluginConfiguration> ConfigurationSource { get; set; }

		MvxLoaderPluginRegistry Registry { get; }

		bool IsPluginLoaded<T>() where T : IMvxPluginLoader;

		void EnsurePluginLoaded<TType>();

		void EnsurePluginLoaded(Type type);

		void EnsurePlatformAdaptionLoaded<T>() where T : IMvxPluginLoader;

		bool TryEnsurePlatformAdaptionLoaded<T>() where T : IMvxPluginLoader;
	}
	public class MvxPluginManager : IMvxPluginManager
	{
		private readonly Dictionary<Type, IMvxPlugin> _loadedPlugins = new Dictionary<Type, IMvxPlugin>();

		public Func<Type, IMvxPluginConfiguration> ConfigurationSource { get; set; }

		public MvxLoaderPluginRegistry Registry { get; private set; } = new MvxLoaderPluginRegistry();

		public bool IsPluginLoaded<T>() where T : IMvxPluginLoader
		{
			lock (this)
			{
				return _loadedPlugins.ContainsKey(typeof(T));
			}
		}

		public void EnsurePluginLoaded<TType>()
		{
			EnsurePluginLoaded(typeof(TType));
		}

		public virtual void EnsurePluginLoaded(Type type)
		{
			FieldInfo field = type.GetField("Instance", BindingFlags.Public | BindingFlags.Static);
			if ((object)field == null)
			{
				MvxTrace.Trace("Plugin Instance not found - will not autoload {0}", type.FullName);
				return;
			}
			object value = field.GetValue(null);
			if (value == null)
			{
				MvxTrace.Trace("Plugin Instance was empty - will not autoload {0}", type.FullName);
			}
			else if (!(value is IMvxPluginLoader pluginLoader))
			{
				MvxTrace.Trace("Plugin Instance was not a loader - will not autoload {0}", type.FullName);
			}
			else
			{
				EnsurePluginLoaded(pluginLoader);
			}
		}

		protected virtual void EnsurePluginLoaded(IMvxPluginLoader pluginLoader)
		{
			if (pluginLoader is IMvxConfigurablePluginLoader mvxConfigurablePluginLoader)
			{
				MvxTrace.Trace("Configuring Plugin Loader for {0}", pluginLoader.GetType().FullName);
				IMvxPluginConfiguration configuration = ConfigurationFor(pluginLoader.GetType());
				mvxConfigurablePluginLoader.Configure(configuration);
			}
			MvxTrace.Trace("Ensuring Plugin is loaded for {0}", pluginLoader.GetType().FullName);
			pluginLoader.EnsureLoaded();
		}

		public void EnsurePlatformAdaptionLoaded<T>() where T : IMvxPluginLoader
		{
			lock (this)
			{
				if (!IsPluginLoaded<T>())
				{
					Type typeFromHandle = typeof(T);
					_loadedPlugins[typeFromHandle] = ExceptionWrappedLoadPlugin(typeFromHandle);
				}
			}
		}

		public bool TryEnsurePlatformAdaptionLoaded<T>() where T : IMvxPluginLoader
		{
			lock (this)
			{
				if (IsPluginLoaded<T>())
				{
					return true;
				}
				try
				{
					Type typeFromHandle = typeof(T);
					_loadedPlugins[typeFromHandle] = ExceptionWrappedLoadPlugin(typeFromHandle);
					return true;
				}
				catch (Exception exception)
				{
					Mvx.Warning("Failed to load plugin adaption {0} with exception {1}", typeof(T).FullName, exception.ToLongString());
					return false;
				}
			}
		}

		private IMvxPlugin ExceptionWrappedLoadPlugin(Type toLoad)
		{
			try
			{
				IMvxPlugin mvxPlugin = LoadPlugin(toLoad);
				if (mvxPlugin is IMvxConfigurablePlugin mvxConfigurablePlugin)
				{
					IMvxPluginConfiguration configuration = ConfigurationSource(mvxConfigurablePlugin.GetType());
					mvxConfigurablePlugin.Configure(configuration);
				}
				mvxPlugin.Load();
				return mvxPlugin;
			}
			catch (MvxException)
			{
				throw;
			}
			catch (Exception exception)
			{
				throw exception.MvxWrap();
			}
		}

		private IMvxPlugin LoadFromRegistry(Type toLoad)
		{
			return Registry.FindLoader(toLoad)?.Invoke();
		}

		private IMvxPlugin LoadPlugin(Type toLoad)
		{
			return LoadFromRegistry(toLoad) ?? FindPlugin(toLoad);
		}

		protected IMvxPluginConfiguration ConfigurationFor(Type toLoad)
		{
			return ConfigurationSource?.Invoke(toLoad);
		}

		protected virtual IMvxPlugin FindPlugin(Type toLoad)
		{
			throw new MvxException("Could not find plugin loader for type {0}", toLoad.FullName);
		}
	}
	public class MvxFilePluginManager : MvxPluginManager
	{
		private readonly List<string> _platformDllPostfixes;

		private readonly string _assemblyExtension;

		public MvxFilePluginManager(string platformDllPostfix, string assemblyExtension = "")
		{
			_platformDllPostfixes = new List<string> { platformDllPostfix };
			_assemblyExtension = assemblyExtension;
		}

		public MvxFilePluginManager(List<string> platformDllPostfixes, string assemblyExtension = "")
		{
			_platformDllPostfixes = platformDllPostfixes;
			_assemblyExtension = assemblyExtension;
		}

		protected override IMvxPlugin FindPlugin(Type toLoad)
		{
			return (IMvxPlugin)Activator.CreateInstance(LoadAssembly(toLoad).ExceptionSafeGetTypes().FirstOrDefault((Type x) => ReflectionExtensions.IsAssignableFrom(typeof(IMvxPlugin), x)) ?? throw new MvxException("Could not find plugin type in assembly"));
		}

		protected virtual Assembly LoadAssembly(Type toLoad)
		{
			foreach (string platformDllPostfix in _platformDllPostfixes)
			{
				string pluginAssemblyNameFrom = GetPluginAssemblyNameFrom(toLoad, platformDllPostfix);
				MvxTrace.Trace("Loading plugin assembly: {0}", pluginAssemblyNameFrom);
				try
				{
					return Assembly.Load(new AssemblyName(pluginAssemblyNameFrom));
				}
				catch (Exception)
				{
				}
			}
			throw new MvxException($"could not load plugin assembly for type {toLoad}");
		}

		protected virtual string GetPluginAssemblyNameFrom(Type toLoad, string platformDllPostfix)
		{
			return string.Format("{0}{1}{2}", new object[3] { toLoad.Namespace, platformDllPostfix, _assemblyExtension });
		}
	}
	public class MvxLoaderPluginRegistry
	{
		private readonly IDictionary<string, Func<IMvxPlugin>> _loaders = new Dictionary<string, Func<IMvxPlugin>>();

		public void Register<TPlugin, TPlatformPlugin>() where TPlugin : IMvxPluginLoader where TPlatformPlugin : IMvxPlugin
		{
			Register(typeof(TPlugin), typeof(TPlatformPlugin));
		}

		public void Register(Type plugin, Type platformPlugin)
		{
			Register(plugin, () => (IMvxPlugin)Activator.CreateInstance(platformPlugin));
		}

		public void Register<TPlugin>(Func<IMvxPlugin> loader) where TPlugin : IMvxPlugin
		{
			Register(typeof(TPlugin), loader);
		}

		public void Register(Type plugin, Func<IMvxPlugin> loader)
		{
			string text = plugin.Namespace;
			if (string.IsNullOrEmpty(text))
			{
				throw new MvxException("Invalid plugin type {0}", plugin);
			}
			if (loader == null)
			{
				throw new MvxException("Loader function can not be null");
			}
			_loaders.Add(text, loader);
		}

		public Func<IMvxPlugin> FindLoader(Type plugin)
		{
			Func<IMvxPlugin> value = null;
			_loaders.TryGetValue(plugin.Namespace, out value);
			return value;
		}
	}
}
namespace MvvmCross.Platform.Parse
{
	public abstract class MvxParser
	{
		protected enum AllowNonQuotedText
		{
			Allow,
			DoNotAllow
		}

		protected string FullText { get; private set; }

		protected int CurrentIndex { get; private set; }

		protected bool IsComplete => CurrentIndex >= FullText.Length;

		protected char CurrentChar => FullText[CurrentIndex];

		protected virtual void Reset(string textToParse)
		{
			FullText = textToParse;
			CurrentIndex = 0;
		}

		protected string ReadQuotedString()
		{
			bool flag = false;
			char currentChar = CurrentChar;
			if (currentChar != '\'' && currentChar != '"')
			{
				throw new MvxException("Error parsing string indexer - unexpected quote character {0} in text {1}", currentChar, FullText);
			}
			MoveNext();
			if (IsComplete)
			{
				throw new MvxException("Error parsing string indexer - unterminated in text {0}", FullText);
			}
			StringBuilder stringBuilder = new StringBuilder();
			while (true)
			{
				if (IsComplete)
				{
					throw new MvxException("Error parsing string indexer - unterminated in text {0}", FullText);
				}
				if (flag)
				{
					stringBuilder.Append(ReadEscapedCharacter());
					flag = false;
					continue;
				}
				char currentChar2 = CurrentChar;
				MoveNext();
				if (currentChar2 == '\\')
				{
					flag = true;
					continue;
				}
				if (currentChar2 == currentChar)
				{
					break;
				}
				stringBuilder.Append(currentChar2);
			}
			return stringBuilder.ToString();
		}

		protected uint ReadUnsignedInteger()
		{
			StringBuilder stringBuilder = new StringBuilder();
			while (!IsComplete && char.IsDigit(CurrentChar))
			{
				stringBuilder.Append(CurrentChar);
				MoveNext();
			}
			string text = stringBuilder.ToString();
			if (!uint.TryParse(text, out var result))
			{
				throw new MvxException("Unable to parse integer text from {0} in {1}", text, FullText);
			}
			return result;
		}

		protected char ReadEscapedCharacter()
		{
			char currentChar = CurrentChar;
			MoveNext();
			switch (currentChar)
			{
			case 't':
				return '\t';
			case 'r':
				return '\r';
			case 'n':
				return '\n';
			case '\'':
				return '\'';
			case '"':
				return '"';
			case '\\':
				return '\\';
			case '0':
				return '\0';
			case 'a':
				return '\a';
			case 'b':
				return '\b';
			case 'f':
				return '\f';
			case 'v':
				return '\v';
			case 'x':
				throw new MvxException("We don't support string literals containing \\x - suggest using \\u escaped characters instead");
			case 'u':
				return ReadFourDigitUnicodeCharacter();
			case 'U':
				if (ReadNDigits(4) != "0000")
				{
					throw new MvxException("\\U unicode character does not start with 0000 in {1}", FullText);
				}
				return ReadFourDigitUnicodeCharacter();
			default:
				throw new MvxException("Sorry we don't currently support escaped characters like \\{0}", currentChar);
			}
		}

		private char ReadFourDigitUnicodeCharacter()
		{
			uint num = uint.Parse(ReadNDigits(4), NumberStyles.HexNumber);
			if (num > 65535)
			{
				throw new MvxException("\\u unicode character {0} out of range in {1}", num, FullText);
			}
			return (char)num;
		}

		private string ReadNDigits(int count)
		{
			StringBuilder stringBuilder = new StringBuilder(count);
			for (int i = 0; i < count; i++)
			{
				if (IsComplete)
				{
					throw new MvxException("Error while reading {0} of {1} digits in {2}", i + 1, count, FullText);
				}
				char currentChar = CurrentChar;
				if (!char.IsDigit(currentChar))
				{
					throw new MvxException("Error while reading {0} of {1} digits in {2} - not a char {3}", i + 1, count, FullText, currentChar);
				}
				stringBuilder.Append(currentChar);
				MoveNext();
			}
			return stringBuilder.ToString();
		}

		protected void MoveNext(uint increment = 1u)
		{
			CurrentIndex += (int)increment;
		}

		protected void SkipWhitespaceAndCharacters(params char[] toSkip)
		{
			SkipWhitespaceAndCharacters((IEnumerable<char>)toSkip);
		}

		protected void SkipWhitespaceAndCharacters(IEnumerable<char> toSkip)
		{
			char[] toSkip2 = toSkip.ToArray();
			while (!IsComplete && IsWhiteSpaceOrCharacter(CurrentChar, toSkip2))
			{
				MoveNext();
			}
		}

		protected void SkipWhitespaceAndCharacters(Dictionary<char, bool> toSkip)
		{
			while (!IsComplete && IsWhiteSpaceOrCharacter(CurrentChar, toSkip))
			{
				MoveNext();
			}
		}

		protected void SkipWhitespace()
		{
			while (!IsComplete && char.IsWhiteSpace(CurrentChar))
			{
				MoveNext();
			}
		}

		private static bool IsWhiteSpaceOrCharacter(char charToTest, Dictionary<char, bool> toSkip)
		{
			if (!char.IsWhiteSpace(charToTest))
			{
				return toSkip.ContainsKey(charToTest);
			}
			return true;
		}

		private static bool IsWhiteSpaceOrCharacter(char charToTest, IEnumerable<char> toSkip)
		{
			if (!char.IsWhiteSpace(charToTest))
			{
				return toSkip.Contains(charToTest);
			}
			return true;
		}

		protected object ReadValue()
		{
			if (!TryReadValue(AllowNonQuotedText.Allow, out var value))
			{
				throw new MvxException("Unable to read value");
			}
			return value;
		}

		protected bool TryReadValue(AllowNonQuotedText allowNonQuotedText, out object value)
		{
			SkipWhitespace();
			if (IsComplete)
			{
				throw new MvxException("Unexpected termination while reading value in {0}", FullText);
			}
			char currentChar = CurrentChar;
			if (currentChar == '\'' || currentChar == '"')
			{
				value = ReadQuotedString();
				return true;
			}
			if (char.IsDigit(currentChar) || currentChar == '-')
			{
				value = ReadNumber();
				return true;
			}
			if (TryReadBoolean(out var booleanValue))
			{
				value = booleanValue;
				return true;
			}
			if (TryReadNull())
			{
				value = null;
				return true;
			}
			if (allowNonQuotedText == AllowNonQuotedText.Allow)
			{
				value = ReadTextUntil(',', ';');
				return true;
			}
			value = null;
			return false;
		}

		protected bool TestKeywordInPeekString(string uppercaseKeyword, string peekString)
		{
			if (peekString.Length < uppercaseKeyword.Length)
			{
				return false;
			}
			if (peekString.Length != uppercaseKeyword.Length && IsValidMidCharacterOfCSharpName(peekString[uppercaseKeyword.Length]))
			{
				return false;
			}
			if (!peekString.StartsWith(uppercaseKeyword))
			{
				return false;
			}
			return true;
		}

		protected bool TryReadNull()
		{
			string text = SafePeekString(5);
			text = text.ToUpperInvariant();
			if (TestKeywordInPeekString("NULL", text))
			{
				MoveNext(4u);
				return true;
			}
			return false;
		}

		protected bool TryReadBoolean(out bool booleanValue)
		{
			string text = SafePeekString(6);
			text = text.ToUpperInvariant();
			if (TestKeywordInPeekString("TRUE", text))
			{
				MoveNext(4u);
				booleanValue = true;
				return true;
			}
			if (TestKeywordInPeekString("FALSE", text))
			{
				MoveNext(5u);
				booleanValue = false;
				return true;
			}
			booleanValue = false;
			return false;
		}

		protected string SafePeekString(int length)
		{
			int num = Math.Min(length, FullText.Length - CurrentIndex);
			if (num == 0)
			{
				return string.Empty;
			}
			return FullText.Substring(CurrentIndex, num);
		}

		protected ValueType ReadNumber()
		{
			StringBuilder stringBuilder = new StringBuilder();
			char currentChar = CurrentChar;
			if (currentChar == '-')
			{
				stringBuilder.Append(currentChar);
				MoveNext();
			}
			bool flag = false;
			while (!IsComplete)
			{
				char currentChar2 = CurrentChar;
				if (currentChar2 == '.')
				{
					if (flag)
					{
						throw new MvxException("Multiple decimal places seen in number in {0} at position {1}", FullText, CurrentIndex);
					}
					flag = true;
				}
				else if (!char.IsDigit(currentChar2))
				{
					break;
				}
				stringBuilder.Append(currentChar2);
				MoveNext();
			}
			string numberText = stringBuilder.ToString();
			return NumberFromText(numberText, flag);
		}

		protected ValueType NumberFromText(string numberText)
		{
			return NumberFromText(numberText, numberText.Contains("."));
		}

		protected ValueType NumberFromText(string numberText, bool decimalPeriodSeen)
		{
			if (decimalPeriodSeen)
			{
				if (double.TryParse(numberText, NumberStyles.AllowLeadingSign | NumberStyles.AllowDecimalPoint, CultureInfo.InvariantCulture, out var result))
				{
					return result;
				}
				throw new MvxException("Failed to parse double from {0} in {1}", numberText, FullText);
			}
			if (long.TryParse(numberText, NumberStyles.AllowLeadingSign, CultureInfo.InvariantCulture, out var result2))
			{
				return result2;
			}
			throw new MvxException("Failed to parse Int64 from {0} in {1}", numberText, FullText);
		}

		protected object ReadEnumerationValue(Type enumerationType, bool ignoreCase = true)
		{
			string text = ReadValidCSharpName();
			try
			{
				return Enum.Parse(enumerationType, text, ignoreCase);
			}
			catch (ArgumentException exception)
			{
				throw exception.MvxWrap("Problem parsing {0} from {1} in {2}", enumerationType.Name, text, FullText);
			}
		}

		protected string ReadTextUntilWhitespaceOr(params char[] terminatingCharacters)
		{
			StringBuilder stringBuilder = new StringBuilder();
			while (!IsComplete)
			{
				char currentChar = CurrentChar;
				if (terminatingCharacters.Contains(currentChar) || char.IsWhiteSpace(currentChar))
				{
					break;
				}
				stringBuilder.Append(currentChar);
				MoveNext();
			}
			return stringBuilder.ToString();
		}

		protected string ReadTextUntil(params char[] terminatingCharacters)
		{
			StringBuilder stringBuilder = new StringBuilder();
			while (!IsComplete)
			{
				char currentChar = CurrentChar;
				if (terminatingCharacters.Contains(currentChar))
				{
					break;
				}
				stringBuilder.Append(currentChar);
				MoveNext();
			}
			return stringBuilder.ToString();
		}

		protected string ReadValidCSharpName()
		{
			SkipWhitespace();
			char currentChar = CurrentChar;
			if (!IsValidFirstCharacterOfCSharpName(currentChar))
			{
				throw new MvxException("PropertyName must start with letter - position {0} in {1} - char {2}", CurrentIndex, FullText, currentChar);
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(currentChar);
			MoveNext();
			while (!IsComplete)
			{
				char currentChar2 = CurrentChar;
				if (!char.IsLetterOrDigit(currentChar2) && currentChar2 != '_')
				{
					break;
				}
				stringBuilder.Append(currentChar2);
				MoveNext();
			}
			return stringBuilder.ToString();
		}

		protected bool IsValidFirstCharacterOfCSharpName(char firstChar)
		{
			if (!char.IsLetter(firstChar))
			{
				return firstChar == '_';
			}
			return true;
		}

		protected bool IsValidMidCharacterOfCSharpName(char firstChar)
		{
			if (!char.IsLetterOrDigit(firstChar))
			{
				return firstChar == '_';
			}
			return true;
		}
	}
}
namespace MvvmCross.Platform.Platform
{
	public interface IMvxNamedInstanceRegistry<in T>
	{
		void AddOrOverwrite(string name, T instance);

		void AddOrOverwriteFrom(Assembly assembly);
	}
	public interface IMvxBootstrapAction
	{
		void Run();
	}
	public interface IMvxJsonConverter : IMvxTextSerializer
	{
		T DeserializeObject<T>(Stream stream);
	}
	public interface IMvxResourceLoader
	{
		bool ResourceExists(string resourcePath);

		string GetTextResource(string resourcePath);

		void GetResourceStream(string resourcePath, Action<Stream> streamAction);
	}
	public class MvxBootstrapRunner
	{
		public virtual void Run(Assembly assembly)
		{
			foreach (Type item in assembly.CreatableTypes().Inherits<IMvxBootstrapAction>())
			{
				Run(item);
			}
		}

		protected virtual void Run(Type type)
		{
			try
			{
				if (!(Activator.CreateInstance(type) is IMvxBootstrapAction mvxBootstrapAction))
				{
					Mvx.Warning("Could not run startup task {0} - it's not a startup task", type.Name);
				}
				else
				{
					mvxBootstrapAction.Run();
				}
			}
			catch (Exception exception)
			{
				Mvx.Warning("Error running startup task {0} - error {1}", type.Name, exception.ToLongString());
			}
		}
	}
	public interface IMvxTrace
	{
		void Trace(MvxTraceLevel level, string tag, Func<string> message);

		void Trace(MvxTraceLevel level, string tag, string message);

		void Trace(MvxTraceLevel level, string tag, string message, params object[] args);
	}
	public enum MvxTraceLevel
	{
		Diagnostic,
		Warning,
		Error
	}
	public interface IMvxTextSerializer
	{
		T DeserializeObject<T>(string inputText);

		string SerializeObject(object toSerialise);

		object DeserializeObject(Type type, string inputText);
	}
	public class MvxDebugOnlyTrace : IMvxTrace
	{
		public void Trace(MvxTraceLevel level, string tag, Func<string> message)
		{
		}

		public void Trace(MvxTraceLevel level, string tag, string message)
		{
		}

		public void Trace(MvxTraceLevel level, string tag, string message, params object[] args)
		{
			try
			{
			}
			catch (FormatException)
			{
				Trace(MvxTraceLevel.Error, tag, "Exception during trace of {0} {1} {2}", level, message);
			}
		}
	}
	public class MvxStopWatch : IDisposable
	{
		private readonly string _message;

		private readonly int _startTickCount;

		private readonly string _tag;

		private MvxStopWatch(string tag, string text, params object[] args)
		{
			_tag = tag;
			_startTickCount = Environment.TickCount;
			_message = string.Format(text, args);
		}

		public void Dispose()
		{
			MvxTrace.TaggedTrace(_tag, "{0} - {1}", Environment.TickCount - _startTickCount, _message);
			GC.SuppressFinalize(this);
		}

		public static MvxStopWatch CreateWithTag(string tag, string text, params object[] args)
		{
			return new MvxStopWatch(tag, text, args);
		}

		public static MvxStopWatch Create(string text, params object[] args)
		{
			return CreateWithTag("mvxStopWatch", text, args);
		}
	}
	public class MvxTrace : MvxSingleton<IMvxTrace>, IMvxTrace
	{
		public static readonly DateTime WhenTraceStartedUtc = DateTime.UtcNow;

		private readonly IMvxTrace _realTrace;

		public static string DefaultTag { get; set; }

		public static void Initialize()
		{
			if (MvxSingleton<IMvxTrace>.Instance != null)
			{
				throw new MvxException("MvxTrace already initialized");
			}
			DefaultTag = "mvx";
			new MvxTrace();
		}

		public static void TaggedTrace(MvxTraceLevel level, string tag, string message, params object[] args)
		{
			MvxSingleton<IMvxTrace>.Instance?.Trace(level, tag, PrependWithTime(message), args);
		}

		public static void TaggedTrace(MvxTraceLevel level, string tag, Func<string> message)
		{
			MvxSingleton<IMvxTrace>.Instance?.Trace(level, tag, PrependWithTime(message));
		}

		public static void Trace(MvxTraceLevel level, string message, params object[] args)
		{
			MvxSingleton<IMvxTrace>.Instance?.Trace(level, DefaultTag, PrependWithTime(message), args);
		}

		public static void Trace(MvxTraceLevel level, Func<string> message)
		{
			MvxSingleton<IMvxTrace>.Instance?.Trace(level, DefaultTag, PrependWithTime(message));
		}

		public static void TaggedTrace(string tag, string message, params object[] args)
		{
			TaggedTrace(MvxTraceLevel.Diagnostic, tag, message, args);
		}

		public static void TaggedWarning(string tag, string message, params object[] args)
		{
			TaggedTrace(MvxTraceLevel.Warning, tag, message, args);
		}

		public static void TaggedError(string tag, string message, params object[] args)
		{
			TaggedTrace(MvxTraceLevel.Error, tag, message, args);
		}

		public static void TaggedTrace(string tag, Func<string> message)
		{
			TaggedTrace(MvxTraceLevel.Diagnostic, tag, message);
		}

		public static void TaggedWarning(string tag, Func<string> message)
		{
			TaggedTrace(MvxTraceLevel.Warning, tag, message);
		}

		public static void TaggedError(string tag, Func<string> message)
		{
			TaggedTrace(MvxTraceLevel.Error, tag, message);
		}

		public static void Trace(string message, params object[] args)
		{
			Trace(MvxTraceLevel.Diagnostic, message, args);
		}

		public static void Warning(string message, params object[] args)
		{
			Trace(MvxTraceLevel.Warning, message, args);
		}

		public static void Error(string message, params object[] args)
		{
			Trace(MvxTraceLevel.Error, message, args);
		}

		public static void Trace(Func<string> message)
		{
			Trace(MvxTraceLevel.Diagnostic, message);
		}

		public static void Warning(Func<string> message)
		{
			Trace(MvxTraceLevel.Warning, message);
		}

		public static void Error(Func<string> message)
		{
			Trace(MvxTraceLevel.Error, message);
		}

		public MvxTrace()
		{
			_realTrace = Mvx.Resolve<IMvxTrace>();
			if (_realTrace == null)
			{
				throw new MvxException("No platform trace service available");
			}
		}

		void IMvxTrace.Trace(MvxTraceLevel level, string tag, Func<string> message)
		{
			_realTrace.Trace(level, tag, message);
		}

		void IMvxTrace.Trace(MvxTraceLevel level, string tag, string message)
		{
			_realTrace.Trace(level, tag, message);
		}

		void IMvxTrace.Trace(MvxTraceLevel level, string tag, string message, params object[] args)
		{
			_realTrace.Trace(level, tag, message, args);
		}

		private static string PrependWithTime(string input)
		{
			double totalSeconds = (DateTime.UtcNow - WhenTraceStartedUtc).TotalSeconds;
			return string.Format("{0,6:0.00} {1}", new object[2] { totalSeconds, input });
		}

		private static Func<string> PrependWithTime(Func<string> input)
		{
			return () => PrependWithTime(input());
		}
	}
	public interface IMvxImageHelper<T> : IDisposable where T : class
	{
		string DefaultImagePath { get; set; }

		string ErrorImagePath { get; set; }

		string ImageUrl { get; set; }

		int MaxWidth { get; set; }

		int MaxHeight { get; set; }

		event EventHandler<MvxValueEventArgs<T>> ImageChanged;
	}
}
namespace MvvmCross.Platform.IoC
{
	public interface IMvxIocOptions
	{
		bool TryToDetectSingletonCircularReferences { get; }

		bool TryToDetectDynamicCircularReferences { get; }

		bool CheckDisposeIfPropertyInjectionFails { get; }

		Type PropertyInjectorType { get; }

		IMvxPropertyInjectorOptions PropertyInjectorOptions { get; }
	}
	public interface IMvxPropertyInjectorOptions
	{
		MvxPropertyInjection InjectIntoProperties { get; }

		bool ThrowIfPropertyInjectionFails { get; }
	}
	public interface IMvxPropertyInjector
	{
		void Inject(object target, IMvxPropertyInjectorOptions options = null);
	}
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
	public class MvxInjectAttribute : Attribute
	{
	}
	public class MvxIocOptions : IMvxIocOptions
	{
		private IMvxPropertyInjector _injector;

		public bool TryToDetectSingletonCircularReferences { get; set; }

		public bool TryToDetectDynamicCircularReferences { get; set; }

		public bool CheckDisposeIfPropertyInjectionFails { get; set; }

		public Type PropertyInjectorType { get; set; }

		public IMvxPropertyInjectorOptions PropertyInjectorOptions { get; set; }

		public MvxIocOptions()
		{
			TryToDetectSingletonCircularReferences = true;
			TryToDetectDynamicCircularReferences = true;
			CheckDisposeIfPropertyInjectionFails = true;
			PropertyInjectorType = typeof(MvxPropertyInjector);
			PropertyInjectorOptions = new MvxPropertyInjectorOptions();
		}
	}
	public enum MvxPropertyInjection
	{
		None,
		MvxInjectInterfaceProperties,
		AllInterfaceProperties
	}
	public class MvxPropertyInjectorOptions : IMvxPropertyInjectorOptions
	{
		private static IMvxPropertyInjectorOptions _mvxInjectProperties;

		private static IMvxPropertyInjectorOptions _allProperties;

		public MvxPropertyInjection InjectIntoProperties { get; set; }

		public bool ThrowIfPropertyInjectionFails { get; set; }

		public static IMvxPropertyInjectorOptions MvxInject
		{
			get
			{
				_mvxInjectProperties = _mvxInjectProperties ?? new MvxPropertyInjectorOptions
				{
					InjectIntoProperties = MvxPropertyInjection.MvxInjectInterfaceProperties,
					ThrowIfPropertyInjectionFails = false
				};
				return _mvxInjectProperties;
			}
		}

		public static IMvxPropertyInjectorOptions All
		{
			get
			{
				_allProperties = _allProperties ?? new MvxPropertyInjectorOptions
				{
					InjectIntoProperties = MvxPropertyInjection.AllInterfaceProperties,
					ThrowIfPropertyInjectionFails = false
				};
				return _allProperties;
			}
		}

		public MvxPropertyInjectorOptions()
		{
			InjectIntoProperties = MvxPropertyInjection.None;
			ThrowIfPropertyInjectionFails = false;
		}
	}
	public class MvxPropertyInjector : IMvxPropertyInjector
	{
		public virtual void Inject(object target, IMvxPropertyInjectorOptions options = null)
		{
			options = options ?? MvxPropertyInjectorOptions.All;
			if (options.InjectIntoProperties == MvxPropertyInjection.None)
			{
				return;
			}
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			foreach (PropertyInfo item in FindInjectableProperties(target.GetType(), options))
			{
				InjectProperty(target, item, options);
			}
		}

		protected virtual void InjectProperty(object toReturn, PropertyInfo injectableProperty, IMvxPropertyInjectorOptions options)
		{
			if (Mvx.TryResolve(injectableProperty.PropertyType, out var service))
			{
				try
				{
					injectableProperty.SetValue(toReturn, service, null);
					return;
				}
				catch (TargetInvocationException innerException)
				{
					throw new MvxIoCResolveException(innerException, "Failed to inject into {0} on {1}", injectableProperty.Name, toReturn.GetType().Name);
				}
			}
			if (options.ThrowIfPropertyInjectionFails)
			{
				throw new MvxIoCResolveException("IoC property injection failed for {0} on {1}", injectableProperty.Name, toReturn.GetType().Name);
			}
			Mvx.Warning("IoC property injection skipped for {0} on {1}", injectableProperty.Name, toReturn.GetType().Name);
		}

		protected virtual IEnumerable<PropertyInfo> FindInjectableProperties(Type type, IMvxPropertyInjectorOptions options)
		{
			IEnumerable<PropertyInfo> enumerable = from p in type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.FlattenHierarchy)
				where p.PropertyType.GetTypeInfo().IsInterface
				where p.IsConventional()
				where p.CanWrite
				select p;
			switch (options.InjectIntoProperties)
			{
			case MvxPropertyInjection.MvxInjectInterfaceProperties:
				enumerable = enumerable.Where((PropertyInfo p) => CustomAttributeExtensions.GetCustomAttributes(p, typeof(MvxInjectAttribute), inherit: false).Any());
				break;
			case MvxPropertyInjection.None:
				Mvx.Error("Internal error - should not call FindInjectableProperties with MvxPropertyInjection.None");
				enumerable = new PropertyInfo[0];
				break;
			default:
				throw new MvxException("unknown option for InjectIntoProperties {0}", options.InjectIntoProperties);
			case MvxPropertyInjection.AllInterfaceProperties:
				break;
			}
			return enumerable;
		}
	}
	public interface IMvxTypeCache<TType>
	{
		Dictionary<string, Type> LowerCaseFullNameCache { get; }

		Dictionary<string, Type> FullNameCache { get; }

		Dictionary<string, Type> NameCache { get; }

		void AddAssembly(Assembly assembly);
	}
	public class MvxLazySingletonCreator
	{
		private readonly object _lockObject = new object();

		private readonly Type _type;

		private object _instance;

		public object Instance
		{
			get
			{
				if (_instance != null)
				{
					return _instance;
				}
				lock (_lockObject)
				{
					_instance = _instance ?? Mvx.IocConstruct(_type);
					return _instance;
				}
			}
		}

		public MvxLazySingletonCreator(Type type)
		{
			_type = type;
		}
	}
	[Obsolete("This functionality is now moved into MvxSimpleIoCContainer and can be enabled using MvxIocOptions")]
	public class MvxPropertyInjectingIoCContainer : MvxSimpleIoCContainer
	{
		public new static IMvxIoCProvider Initialize(IMvxIocOptions options)
		{
			if (MvxSingleton<IMvxIoCProvider>.Instance != null)
			{
				return MvxSingleton<IMvxIoCProvider>.Instance;
			}
			new MvxPropertyInjectingIoCContainer(options);
			return MvxSingleton<IMvxIoCProvider>.Instance;
		}

		protected MvxPropertyInjectingIoCContainer(IMvxIocOptions options)
			: base(options ?? CreatePropertyInjectionOptions())
		{
		}

		private static MvxIocOptions CreatePropertyInjectionOptions()
		{
			return new MvxIocOptions
			{
				TryToDetectDynamicCircularReferences = true,
				TryToDetectSingletonCircularReferences = true,
				CheckDisposeIfPropertyInjectionFails = true,
				PropertyInjectorType = typeof(MvxPropertyInjector),
				PropertyInjectorOptions = new MvxPropertyInjectorOptions
				{
					ThrowIfPropertyInjectionFails = false,
					InjectIntoProperties = MvxPropertyInjection.AllInterfaceProperties
				}
			};
		}
	}
	public class MvxTypeCache<TType> : IMvxTypeCache<TType>
	{
		public Dictionary<string, Type> LowerCaseFullNameCache { get; private set; }

		public Dictionary<string, Type> FullNameCache { get; private set; }

		public Dictionary<string, Type> NameCache { get; private set; }

		public Dictionary<Assembly, bool> CachedAssemblies { get; private set; }

		public MvxTypeCache()
		{
			LowerCaseFullNameCache = new Dictionary<string, Type>();
			FullNameCache = new Dictionary<string, Type>();
			NameCache = new Dictionary<string, Type>();
			CachedAssemblies = new Dictionary<Assembly, bool>();
		}

		public void AddAssembly(Assembly assembly)
		{
			if (CachedAssemblies.ContainsKey(assembly))
			{
				return;
			}
			Type viewType = typeof(TType);
			foreach (Type item in from type in assembly.ExceptionSafeGetTypes()
				where ReflectionExtensions.IsAssignableFrom(viewType, type)
				select type)
			{
				if (!string.IsNullOrEmpty(item.FullName))
				{
					FullNameCache[item.FullName] = item;
					LowerCaseFullNameCache[item.FullName.ToLowerInvariant()] = item;
				}
				if (!string.IsNullOrEmpty(item.Name))
				{
					NameCache[item.Name] = item;
				}
			}
			CachedAssemblies[assembly] = true;
		}
	}
	public static class MvxTypeExtensions
	{
		public class ServiceTypeAndImplementationTypePair
		{
			public List<Type> ServiceTypes { get; private set; }

			public Type ImplementationType { get; private set; }

			public ServiceTypeAndImplementationTypePair(List<Type> serviceTypes, Type implementationType)
			{
				ImplementationType = implementationType;
				ServiceTypes = serviceTypes;
			}
		}

		public static IEnumerable<Type> ExceptionSafeGetTypes(this Assembly assembly)
		{
			try
			{
				return ReflectionExtensions.GetTypes(assembly);
			}
			catch (ReflectionTypeLoadException exception)
			{
				Mvx.Warning("ReflectionTypeLoadException masked during loading of {0} - error {1}", assembly.FullName, exception.ToLongString());
				return new Type[0];
			}
		}

		public static IEnumerable<Type> CreatableTypes(this Assembly assembly)
		{
			return from t in assembly.ExceptionSafeGetTypes()
				select t.GetTypeInfo() into t
				where !t.IsAbstract
				where t.DeclaredConstructors.Any((ConstructorInfo c) => !c.IsStatic && c.IsPublic)
				select t.AsType();
		}

		public static IEnumerable<Type> EndingWith(this IEnumerable<Type> types, string endingWith)
		{
			return types.Where((Type x) => x.Name.EndsWith(endingWith));
		}

		public static IEnumerable<Type> StartingWith(this IEnumerable<Type> types, string endingWith)
		{
			return types.Where((Type x) => x.Name.StartsWith(endingWith));
		}

		public static IEnumerable<Type> Containing(this IEnumerable<Type> types, string containing)
		{
			return types.Where((Type x) => x.Name.Contains(containing));
		}

		public static IEnumerable<Type> InNamespace(this IEnumerable<Type> types, string namespaceBase)
		{
			return types.Where((Type x) => x.Namespace != null && x.Namespace.StartsWith(namespaceBase));
		}

		public static IEnumerable<Type> WithAttribute(this IEnumerable<Type> types, Type attributeType)
		{
			return types.Where((Type x) => ReflectionExtensions.GetCustomAttributes(x, attributeType, inherit: true).Any());
		}

		public static IEnumerable<Type> WithAttribute<TAttribute>(this IEnumerable<Type> types) where TAttribute : Attribute
		{
			return types.WithAttribute(typeof(TAttribute));
		}

		public static IEnumerable<Type> Inherits(this IEnumerable<Type> types, Type baseType)
		{
			return types.Where((Type x) => ReflectionExtensions.IsAssignableFrom(baseType, x));
		}

		public static IEnumerable<Type> Inherits<TBase>(this IEnumerable<Type> types)
		{
			return types.Inherits(typeof(TBase));
		}

		public static IEnumerable<Type> DoesNotInherit(this IEnumerable<Type> types, Type baseType)
		{
			return types.Where((Type x) => !ReflectionExtensions.IsAssignableFrom(baseType, x));
		}

		public static IEnumerable<Type> DoesNotInherit<TBase>(this IEnumerable<Type> types) where TBase : Attribute
		{
			return types.DoesNotInherit(typeof(TBase));
		}

		public static IEnumerable<Type> Except(this IEnumerable<Type> types, params Type[] except)
		{
			if (except.Length >= 3)
			{
				Dictionary<Type, bool> lookup = except.ToDictionary((Type x) => x, (Type x) => true);
				return types.Where((Type x) => !lookup.ContainsKey(x));
			}
			return types.Where((Type x) => !except.Contains(x));
		}

		public static IEnumerable<ServiceTypeAndImplementationTypePair> AsTypes(this IEnumerable<Type> types)
		{
			return types.Select((Type t) => new ServiceTypeAndImplementationTypePair(new List<Type> { t }, t));
		}

		public static IEnumerable<ServiceTypeAndImplementationTypePair> AsInterfaces(this IEnumerable<Type> types)
		{
			return types.Select((Type t) => new ServiceTypeAndImplementationTypePair(ReflectionExtensions.GetInterfaces(t).ToList(), t));
		}

		public static IEnumerable<ServiceTypeAndImplementationTypePair> AsInterfaces(this IEnumerable<Type> types, params Type[] interfaces)
		{
			if (interfaces.Length >= 3)
			{
				Dictionary<Type, bool> lookup = interfaces.ToDictionary((Type x) => x, (Type x) => true);
				return types.Select((Type t) => new ServiceTypeAndImplementationTypePair((from iface in ReflectionExtensions.GetInterfaces(t)
					where lookup.ContainsKey(iface)
					select iface).ToList(), t));
			}
			return types.Select((Type t) => new ServiceTypeAndImplementationTypePair((from iface in ReflectionExtensions.GetInterfaces(t)
				where interfaces.Contains(iface)
				select iface).ToList(), t));
		}

		public static IEnumerable<ServiceTypeAndImplementationTypePair> ExcludeInterfaces(this IEnumerable<ServiceTypeAndImplementationTypePair> pairs, params Type[] toExclude)
		{
			foreach (ServiceTypeAndImplementationTypePair pair in pairs)
			{
				List<Type> list = pair.ServiceTypes.Where((Type c) => !toExclude.Contains(c)).ToList();
				if (list.Any())
				{
					yield return new ServiceTypeAndImplementationTypePair(list, pair.ImplementationType);
				}
			}
		}

		public static void RegisterAsSingleton(this IEnumerable<ServiceTypeAndImplementationTypePair> pairs)
		{
			foreach (ServiceTypeAndImplementationTypePair pair in pairs)
			{
				if (!pair.ServiceTypes.Any())
				{
					continue;
				}
				object service = Mvx.IocConstruct(pair.ImplementationType);
				foreach (Type serviceType in pair.ServiceTypes)
				{
					Mvx.RegisterSingleton(serviceType, service);
				}
			}
		}

		public static void RegisterAsLazySingleton(this IEnumerable<ServiceTypeAndImplementationTypePair> pairs)
		{
			foreach (ServiceTypeAndImplementationTypePair pair in pairs)
			{
				if (!pair.ServiceTypes.Any())
				{
					continue;
				}
				Type implementationType = pair.ImplementationType;
				MvxLazySingletonCreator creator = new MvxLazySingletonCreator(implementationType);
				Func<object> serviceConstructor = () => creator.Instance;
				foreach (Type serviceType in pair.ServiceTypes)
				{
					Mvx.RegisterSingleton(serviceType, serviceConstructor);
				}
			}
		}

		public static void RegisterAsDynamic(this IEnumerable<ServiceTypeAndImplementationTypePair> pairs)
		{
			foreach (ServiceTypeAndImplementationTypePair pair in pairs)
			{
				foreach (Type serviceType in pair.ServiceTypes)
				{
					Mvx.RegisterType(serviceType, pair.ImplementationType);
				}
			}
		}

		public static object CreateDefault(this Type type)
		{
			if ((object)type == null)
			{
				return null;
			}
			if (!type.GetTypeInfo().IsValueType)
			{
				return null;
			}
			if ((object)Nullable.GetUnderlyingType(type) != null)
			{
				return null;
			}
			return Activator.CreateInstance(type);
		}
	}
	public abstract class MvxConditionalConventionalAttribute : Attribute
	{
		public abstract bool IsConditionSatisfied { get; }
	}
	public static class MvxConventionAttributeExtensionMethods
	{
		public static bool IsConventional(this Type candidateType)
		{
			if (ReflectionExtensions.GetCustomAttributes(candidateType, typeof(MvxUnconventionalAttribute), inherit: true).Length != 0)
			{
				return false;
			}
			return candidateType.SatisfiesConditionalConventions();
		}

		public static bool SatisfiesConditionalConventions(this Type candidateType)
		{
			Attribute[] customAttributes = ReflectionExtensions.GetCustomAttributes(candidateType, typeof(MvxConditionalConventionalAttribute), inherit: true);
			for (int i = 0; i < customAttributes.Length; i++)
			{
				if (!((MvxConditionalConventionalAttribute)customAttributes[i]).IsConditionSatisfied)
				{
					return false;
				}
			}
			return true;
		}

		public static bool IsConventional(this PropertyInfo propertyInfo)
		{
			if (CustomAttributeExtensions.GetCustomAttributes(propertyInfo, typeof(MvxUnconventionalAttribute), inherit: true).Any())
			{
				return false;
			}
			return propertyInfo.SatisfiesConditionalConventions();
		}

		public static bool SatisfiesConditionalConventions(this PropertyInfo propertyInfo)
		{
			foreach (MvxConditionalConventionalAttribute customAttribute in CustomAttributeExtensions.GetCustomAttributes(propertyInfo, typeof(MvxConditionalConventionalAttribute), inherit: true))
			{
				if (!customAttribute.IsConditionSatisfied)
				{
					return false;
				}
			}
			return true;
		}
	}
	public class MvxUnconventionalAttribute : Attribute
	{
	}
	[Obsolete("We prefer to use IoC directly using Mvx.Resolve<T>() now")]
	public static class MvxIoCExtensions
	{
		public static bool IsServiceAvailable<TService>(this IMvxConsumer consumer) where TService : class
		{
			return Mvx.CanResolve<TService>();
		}

		public static TService GetService<TService>(this IMvxConsumer consumer) where TService : class
		{
			return Mvx.Resolve<TService>();
		}

		public static bool TryGetService<TService>(this IMvxConsumer consumer, out TService service) where TService : class
		{
			return Mvx.TryResolve<TService>(out service);
		}

		public static void RegisterServiceInstance<TInterface>(this IMvxProducer producer, Func<TInterface> serviceConstructor) where TInterface : class
		{
			Mvx.RegisterSingleton(serviceConstructor);
		}

		public static void RegisterServiceInstance<TInterface>(this IMvxProducer producer, TInterface service) where TInterface : class
		{
			Mvx.RegisterSingleton(service);
		}

		public static void RegisterServiceType<TInterface, TType>(this IMvxProducer producer) where TInterface : class where TType : class, TInterface
		{
			Mvx.RegisterType<TInterface, TType>();
		}
	}
	public interface IMvxIoCProvider
	{
		bool CanResolve<T>() where T : class;

		bool CanResolve(Type type);

		T Resolve<T>() where T : class;

		object Resolve(Type type);

		T Create<T>() where T : class;

		object Create(Type type);

		T GetSingleton<T>() where T : class;

		object GetSingleton(Type type);

		bool TryResolve<T>(out T resolved) where T : class;

		bool TryResolve(Type type, out object resolved);

		void RegisterType<TFrom, TTo>() where TFrom : class where TTo : class, TFrom;

		void RegisterType<TInterface>(Func<TInterface> constructor) where TInterface : class;

		void RegisterType(Type t, Func<object> constructor);

		void RegisterType(Type tFrom, Type tTo);

		void RegisterSingleton<TInterface>(TInterface theObject) where TInterface : class;

		void RegisterSingleton(Type tInterface, object theObject);

		void RegisterSingleton<TInterface>(Func<TInterface> theConstructor) where TInterface : class;

		void RegisterSingleton(Type tInterface, Func<object> theConstructor);

		T IoCConstruct<T>() where T : class;

		object IoCConstruct(Type type);

		void CallbackWhenRegistered<T>(Action action);

		void CallbackWhenRegistered(Type type, Action action);
	}
	[Obsolete("Prefer to use Mvx.Resolve<T> static methods now")]
	public interface IMvxConsumer
	{
	}
	[Obsolete("Prefer to use Mvx.Register<T> static methods now")]
	public interface IMvxProducer
	{
	}
	public class MvxSimpleIoCContainer : MvxSingleton<IMvxIoCProvider>, IMvxIoCProvider
	{
		public interface IResolver
		{
			ResolverType ResolveType { get; }

			object Resolve();
		}

		public class ConstructingResolver : IResolver
		{
			private readonly Type _type;

			private readonly MvxSimpleIoCContainer _parent;

			public ResolverType ResolveType => ResolverType.DynamicPerResolve;

			public ConstructingResolver(Type type, MvxSimpleIoCContainer parent)
			{
				_type = type;
				_parent = parent;
			}

			public object Resolve()
			{
				return _parent.IoCConstruct(_type);
			}
		}

		public class FuncConstructingResolver : IResolver
		{
			private readonly Func<object> _constructor;

			public ResolverType ResolveType => ResolverType.DynamicPerResolve;

			public FuncConstructingResolver(Func<object> constructor)
			{
				_constructor = constructor;
			}

			public object Resolve()
			{
				return _constructor();
			}
		}

		public class SingletonResolver : IResolver
		{
			private readonly object _theObject;

			public ResolverType ResolveType => ResolverType.Singleton;

			public SingletonResolver(object theObject)
			{
				_theObject = theObject;
			}

			public object Resolve()
			{
				return _theObject;
			}
		}

		public class ConstructingSingletonResolver : IResolver
		{
			private readonly object _syncObject = new object();

			private readonly Func<object> _constructor;

			private object _theObject;

			public ResolverType ResolveType => ResolverType.Singleton;

			public ConstructingSingletonResolver(Func<object> theConstructor)
			{
				_constructor = theConstructor;
			}

			public object Resolve()
			{
				if (_theObject != null)
				{
					return _theObject;
				}
				lock (_syncObject)
				{
					if (_theObject == null)
					{
						_theObject = _constructor();
					}
				}
				return _theObject;
			}
		}

		public enum ResolverType
		{
			DynamicPerResolve,
			Singleton,
			Unknown
		}

		private readonly Dictionary<Type, IResolver> _resolvers = new Dictionary<Type, IResolver>();

		private readonly Dictionary<Type, List<Action>> _waiters = new Dictionary<Type, List<Action>>();

		private readonly Dictionary<Type, bool> _circularTypeDetection = new Dictionary<Type, bool>();

		private readonly object _lockObject = new object();

		private readonly IMvxIocOptions _options;

		private readonly IMvxPropertyInjector _propertyInjector;

		private static readonly ResolverType? ResolverTypeNoneSpecified;

		protected object LockObject => _lockObject;

		protected IMvxIocOptions Options => _options;

		public static IMvxIoCProvider Initialize(IMvxIocOptions options = null)
		{
			if (MvxSingleton<IMvxIoCProvider>.Instance != null)
			{
				return MvxSingleton<IMvxIoCProvider>.Instance;
			}
			new MvxSimpleIoCContainer(options);
			return MvxSingleton<IMvxIoCProvider>.Instance;
		}

		protected MvxSimpleIoCContainer(IMvxIocOptions options)
		{
			_options = options ?? new MvxIocOptions();
			if ((object)_options.PropertyInjectorType != null)
			{
				_propertyInjector = Activator.CreateInstance(_options.PropertyInjectorType) as IMvxPropertyInjector;
			}
			if (_propertyInjector != null)
			{
				RegisterSingleton(typeof(IMvxPropertyInjector), _propertyInjector);
			}
		}

		public bool CanResolve<T>() where T : class
		{
			return CanResolve(typeof(T));
		}

		public bool CanResolve(Type t)
		{
			lock (_lockObject)
			{
				return _resolvers.ContainsKey(t);
			}
		}

		public bool TryResolve<T>(out T resolved) where T : class
		{
			try
			{
				object resolved2;
				bool result = TryResolve(typeof(T), out resolved2);
				resolved = (T)resolved2;
				return result;
			}
			catch (MvxIoCResolveException)
			{
				resolved = (T)typeof(T).CreateDefault();
				return false;
			}
		}

		public bool TryResolve(Type type, out object resolved)
		{
			lock (_lockObject)
			{
				return InternalTryResolve(type, out resolved);
			}
		}

		public T Resolve<T>() where T : class
		{
			return (T)Resolve(typeof(T));
		}

		public object Resolve(Type t)
		{
			lock (_lockObject)
			{
				if (!InternalTryResolve(t, out var resolved))
				{
					throw new MvxIoCResolveException("Failed to resolve type {0}", t.FullName);
				}
				return resolved;
			}
		}

		public T GetSingleton<T>() where T : class
		{
			return (T)GetSingleton(typeof(T));
		}

		public object GetSingleton(Type t)
		{
			lock (_lockObject)
			{
				if (!InternalTryResolve(t, ResolverType.Singleton, out var resolved))
				{
					throw new MvxIoCResolveException("Failed to resolve type {0}", t.FullName);
				}
				return resolved;
			}
		}

		public T Create<T>() where T : class
		{
			return (T)Create(typeof(T));
		}

		public object Create(Type t)
		{
			lock (_lockObject)
			{
				if (!InternalTryResolve(t, ResolverType.DynamicPerResolve, out var resolved))
				{
					throw new MvxIoCResolveException("Failed to resolve type {0}", t.FullName);
				}
				return resolved;
			}
		}

		public void RegisterType<TInterface, TToConstruct>() where TInterface : class where TToConstruct : class, TInterface
		{
			RegisterType(typeof(TInterface), typeof(TToConstruct));
		}

		public void RegisterType<TInterface>(Func<TInterface> constructor) where TInterface : class
		{
			FuncConstructingResolver resolver = new FuncConstructingResolver(constructor);
			InternalSetResolver(typeof(TInterface), resolver);
		}

		public void RegisterType(Type t, Func<object> constructor)
		{
			FuncConstructingResolver resolver = new FuncConstructingResolver(delegate
			{
				object obj = constructor();
				if (obj != null && !ReflectionExtensions.IsInstanceOfType(t, obj))
				{
					throw new MvxIoCResolveException("Constructor failed to return a compatibly object for type {0}", t.FullName);
				}
				return obj;
			});
			InternalSetResolver(t, resolver);
		}

		public void RegisterType(Type tInterface, Type tConstruct)
		{
			ConstructingResolver resolver = new ConstructingResolver(tConstruct, this);
			InternalSetResolver(tInterface, resolver);
		}

		public void RegisterSingleton<TInterface>(TInterface theObject) where TInterface : class
		{
			RegisterSingleton(typeof(TInterface), theObject);
		}

		public void RegisterSingleton(Type tInterface, object theObject)
		{
			InternalSetResolver(tInterface, new SingletonResolver(theObject));
		}

		public void RegisterSingleton<TInterface>(Func<TInterface> theConstructor) where TInterface : class
		{
			RegisterSingleton(typeof(TInterface), () => theConstructor());
		}

		public void RegisterSingleton(Type tInterface, Func<object> theConstructor)
		{
			InternalSetResolver(tInterface, new ConstructingSingletonResolver(theConstructor));
		}

		public T IoCConstruct<T>() where T : class
		{
			return (T)IoCConstruct(typeof(T));
		}

		public virtual object IoCConstruct(Type type)
		{
			ConstructorInfo constructorInfo = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public).FirstOrDefault();
			if ((object)constructorInfo == null)
			{
				throw new MvxIoCResolveException("Failed to find constructor for type {0}", type.FullName);
			}
			List<object> ioCParameterValues = GetIoCParameterValues(type, constructorInfo);
			object obj;
			try
			{
				obj = constructorInfo.Invoke(ioCParameterValues.ToArray());
			}
			catch (TargetInvocationException innerException)
			{
				throw new MvxIoCResolveException(innerException, "Failed to construct {0}", type.Name);
			}
			try
			{
				InjectProperties(obj);
				return obj;
			}
			catch (Exception)
			{
				if (!Options.CheckDisposeIfPropertyInjectionFails)
				{
					throw;
				}
				obj.DisposeIfDisposable();
				throw;
			}
		}

		public void CallbackWhenRegistered<T>(Action action)
		{
			CallbackWhenRegistered(typeof(T), action);
		}

		public void CallbackWhenRegistered(Type type, Action action)
		{
			lock (_lockObject)
			{
				if (!CanResolve(type))
				{
					if (_waiters.TryGetValue(type, out var value))
					{
						value.Add(action);
						return;
					}
					value = new List<Action> { action };
					_waiters[type] = value;
					return;
				}
			}
			action();
		}

		private bool Supports(IResolver resolver, ResolverType? requiredResolverType)
		{
			if (!requiredResolverType.HasValue)
			{
				return true;
			}
			return resolver.ResolveType == requiredResolverType.Value;
		}

		private bool InternalTryResolve(Type type, out object resolved)
		{
			return InternalTryResolve(type, ResolverTypeNoneSpecified, out resolved);
		}

		private bool InternalTryResolve(Type type, ResolverType? requiredResolverType, out object resolved)
		{
			if (!_resolvers.TryGetValue(type, out var value))
			{
				resolved = type.CreateDefault();
				return false;
			}
			if (!Supports(value, requiredResolverType))
			{
				resolved = type.CreateDefault();
				return false;
			}
			return InternalTryResolve(type, value, out resolved);
		}

		private bool ShouldDetectCircularReferencesFor(IResolver resolver)
		{
			return resolver.ResolveType switch
			{
				ResolverType.DynamicPerResolve => Options.TryToDetectDynamicCircularReferences, 
				ResolverType.Singleton => Options.TryToDetectSingletonCircularReferences, 
				ResolverType.Unknown => throw new MvxException("A resolver must have a known type - error in {0}", resolver.GetType().Name), 
				_ => throw new ArgumentOutOfRangeException("resolver", "unknown resolveType of " + resolver.ResolveType), 
			};
		}

		private bool InternalTryResolve(Type type, IResolver resolver, out object resolved)
		{
			bool flag = ShouldDetectCircularReferencesFor(resolver);
			if (flag)
			{
				try
				{
					_circularTypeDetection.Add(type, value: true);
				}
				catch (ArgumentException)
				{
					Mvx.Error("IoC circular reference detected - cannot currently resolve {0}", type.Name);
					resolved = type.CreateDefault();
					return false;
				}
			}
			try
			{
				object obj = resolver.Resolve();
				if (!ReflectionExtensions.IsInstanceOfType(type, obj))
				{
					throw new MvxException("Resolver returned object type {0} which does not support interface {1}", obj.GetType().FullName, type.FullName);
				}
				resolved = obj;
				return true;
			}
			finally
			{
				if (flag)
				{
					_circularTypeDetection.Remove(type);
				}
			}
		}

		private void InternalSetResolver(Type tInterface, IResolver resolver)
		{
			List<Action> value;
			lock (_lockObject)
			{
				_resolvers[tInterface] = resolver;
				if (_waiters.TryGetValue(tInterface, out value))
				{
					_waiters.Remove(tInterface);
				}
			}
			if (value == null)
			{
				return;
			}
			foreach (Action item in value)
			{
				item();
			}
		}

		protected virtual void InjectProperties(object toReturn)
		{
			_propertyInjector?.Inject(toReturn, _options.PropertyInjectorOptions);
		}

		protected virtual List<object> GetIoCParameterValues(Type type, ConstructorInfo firstConstructor)
		{
			List<object> list = new List<object>();
			ParameterInfo[] parameters = firstConstructor.GetParameters();
			foreach (ParameterInfo parameterInfo in parameters)
			{
				if (!TryResolve(parameterInfo.ParameterType, out var resolved))
				{
					if (!parameterInfo.IsOptional)
					{
						throw new MvxIoCResolveException("Failed to resolve parameter for parameter {0} of type {1} when creating {2}", parameterInfo.Name, parameterInfo.ParameterType.Name, type.FullName);
					}
					resolved = Type.Missing;
				}
				list.Add(resolved);
			}
			return list;
		}
	}
}
namespace MvvmCross.Platform.Exceptions
{
	public class MvxIoCResolveException : MvxException
	{
		public MvxIoCResolveException()
		{
		}

		public MvxIoCResolveException(string message)
			: base(message)
		{
		}

		public MvxIoCResolveException(string messageFormat, params object[] messageFormatArguments)
			: base(messageFormat, messageFormatArguments)
		{
		}

		public MvxIoCResolveException(Exception innerException, string messageFormat, params object[] formatArguments)
			: base(innerException, messageFormat, formatArguments)
		{
		}
	}
	public class MvxException : Exception
	{
		public MvxException()
		{
		}

		public MvxException(string message)
			: base(message)
		{
		}

		public MvxException(string messageFormat, params object[] messageFormatArguments)
			: base(string.Format(messageFormat, messageFormatArguments))
		{
		}

		public MvxException(Exception innerException, string messageFormat, params object[] formatArguments)
			: base(string.Format(messageFormat, formatArguments), innerException)
		{
		}
	}
	public static class MvxExceptionExtensionMethods
	{
		public static string ToLongString(this Exception exception)
		{
			if (exception == null)
			{
				return "null exception";
			}
			if (exception.InnerException != null)
			{
				string text = exception.InnerException.ToLongString();
				return string.Format("{0}: {1}\n\t{2}\nInnerException was {3}", ((object)exception).GetType().Name, exception.Message ?? "-", exception.StackTrace, text);
			}
			return string.Format("{0}: {1}\n\t{2}", new object[3]
			{
				((object)exception).GetType().Name,
				exception.Message ?? "-",
				exception.StackTrace
			});
		}

		public static Exception MvxWrap(this Exception exception)
		{
			if (exception is MvxException)
			{
				return exception;
			}
			return exception.MvxWrap(exception.Message);
		}

		public static Exception MvxWrap(this Exception exception, string message)
		{
			return new MvxException(exception, message);
		}

		public static Exception MvxWrap(this Exception exception, string messageFormat, params object[] formatArguments)
		{
			return new MvxException(exception, messageFormat, formatArguments);
		}
	}
}
namespace MvvmCross.Platform.Core
{
	public static class MvxDelegateExtensionMethods
	{
		public static void Raise(this EventHandler eventHandler, object sender)
		{
			eventHandler?.Invoke(sender, EventArgs.Empty);
		}

		public static void Raise<T>(this EventHandler<MvxValueEventArgs<T>> eventHandler, object sender, T value)
		{
			eventHandler?.Invoke(sender, new MvxValueEventArgs<T>(value));
		}
	}
	public static class MvxObjectExtensions
	{
		public static void DisposeIfDisposable(this object thing)
		{
			(thing as IDisposable)?.Dispose();
		}
	}
	public interface IMvxApplicable
	{
		void Apply();
	}
	public interface IMvxApplicableTo
	{
		void ApplyTo(object what);
	}
	public interface IMvxApplicableTo<in T>
	{
		void ApplyTo(T what);
	}
	public abstract class MvxAllThreadDispatchingObject : MvxMainThreadDispatchingObject
	{
		private readonly object _lockObject = new object();

		protected void RunSyncWithLock(Action action)
		{
			MvxLockableObjectHelpers.RunSyncWithLock(_lockObject, action);
		}

		protected void RunAsyncWithLock(Action action)
		{
			MvxLockableObjectHelpers.RunAsyncWithLock(_lockObject, action);
		}

		protected void RunSyncOrAsyncWithLock(Action action, Action whenComplete = null)
		{
			MvxLockableObjectHelpers.RunSyncOrAsyncWithLock(_lockObject, action, whenComplete);
		}
	}
	public abstract class MvxApplicable : IMvxApplicable
	{
		private bool _finalizerSuppressed;

		~MvxApplicable()
		{
			Mvx.Trace("Finaliser called on {0} - suggests that  Apply() was never called", GetType().Name);
		}

		protected void SuppressFinalizer()
		{
			if (!_finalizerSuppressed)
			{
				_finalizerSuppressed = true;
				GC.SuppressFinalize(this);
			}
		}

		public virtual void Apply()
		{
			SuppressFinalizer();
		}
	}
	public static class MvxApplicableExtensions
	{
		public static void Apply(this IEnumerable<IMvxApplicable> toApply)
		{
			foreach (IMvxApplicable item in toApply)
			{
				item.Apply();
			}
		}

		public static void ApplyTo(this IEnumerable<IMvxApplicableTo> toApply, object what)
		{
			foreach (IMvxApplicableTo item in toApply)
			{
				item.ApplyTo(what);
			}
		}

		public static void ApplyTo<T>(this IEnumerable<IMvxApplicableTo<T>> toApply, T what)
		{
			foreach (IMvxApplicableTo<T> item in toApply)
			{
				item.ApplyTo(what);
			}
		}
	}
	public abstract class MvxApplicableTo<T> : MvxApplicable, IMvxApplicableTo<T>
	{
		public virtual void ApplyTo(T what)
		{
			SuppressFinalizer();
		}
	}
	public abstract class MvxLockableObject
	{
		private readonly object _lockObject = new object();

		protected void RunSyncWithLock(Action action)
		{
			MvxLockableObjectHelpers.RunSyncWithLock(_lockObject, action);
		}

		protected void RunAsyncWithLock(Action action)
		{
			MvxLockableObjectHelpers.RunAsyncWithLock(_lockObject, action);
		}

		protected void RunSyncOrAsyncWithLock(Action action, Action whenComplete = null)
		{
			MvxLockableObjectHelpers.RunSyncOrAsyncWithLock(_lockObject, action, whenComplete);
		}
	}
	public static class MvxLockableObjectHelpers
	{
		public static void RunSyncWithLock(object lockObject, Action action)
		{
			lock (lockObject)
			{
				action();
			}
		}

		public static void RunAsyncWithLock(object lockObject, Action action)
		{
			MvxAsyncDispatcher.BeginAsync(delegate
			{
				lock (lockObject)
				{
					action();
				}
			});
		}

		public static void RunSyncOrAsyncWithLock(object lockObject, Action action, Action whenComplete = null)
		{
			if (Monitor.TryEnter(lockObject))
			{
				try
				{
					action();
				}
				finally
				{
					Monitor.Exit(lockObject);
				}
				whenComplete?.Invoke();
				return;
			}
			MvxAsyncDispatcher.BeginAsync(delegate
			{
				lock (lockObject)
				{
					action();
				}
				whenComplete?.Invoke();
			});
		}
	}
	public abstract class MvxMainThreadDispatcher : MvxSingleton<IMvxMainThreadDispatcher>
	{
		protected static void ExceptionMaskedAction(Action action)
		{
			try
			{
				action();
			}
			catch (TargetInvocationException ex)
			{
				MvxTrace.Trace("TargetInvocateException masked " + ex.InnerException.ToLongString());
			}
			catch (Exception exception)
			{
				MvxTrace.Warning("Exception masked " + exception.ToLongString());
			}
		}
	}
	public abstract class MvxMainThreadDispatchingObject
	{
		protected IMvxMainThreadDispatcher Dispatcher => MvxSingleton<IMvxMainThreadDispatcher>.Instance;

		protected void InvokeOnMainThread(Action action)
		{
			Dispatcher?.RequestMainThreadAction(action);
		}
	}
	public static class MvxAsyncDispatcher
	{
		public static void BeginAsync(Action action)
		{
			Task.Run(action);
		}

		public static void BeginAsync(Action<object> action, object state)
		{
			Task.Run(delegate
			{
				action(state);
			});
		}
	}
	public static class MvxPropertyNameExtensionMethods
	{
		private const string WrongExpressionMessage = "Wrong expression\nshould be called with expression like\n() => PropertyName";

		private const string WrongUnaryExpressionMessage = "Wrong unary expression\nshould be called with expression like\n() => PropertyName";

		public static string GetPropertyNameFromExpression<T>(this object target, Expression<Func<T>> expression)
		{
			if (expression == null)
			{
				throw new ArgumentNullException("expression");
			}
			if (!((FindMemberExpression(expression) ?? throw new ArgumentException("Wrong expression\nshould be called with expression like\n() => PropertyName", "expression")).Member is PropertyInfo propertyInfo))
			{
				throw new ArgumentException("Wrong expression\nshould be called with expression like\n() => PropertyName", "expression");
			}
			if ((object)propertyInfo.DeclaringType == null)
			{
				throw new ArgumentException("Wrong expression\nshould be called with expression like\n() => PropertyName", "expression");
			}
			if (target != null && !ReflectionExtensions.IsInstanceOfType(propertyInfo.DeclaringType, target))
			{
				throw new ArgumentException("Wrong expression\nshould be called with expression like\n() => PropertyName", "expression");
			}
			if (ReflectionExtensions.GetGetMethod(propertyInfo, nonPublic: true).IsStatic)
			{
				throw new ArgumentException("Wrong expression\nshould be called with expression like\n() => PropertyName", "expression");
			}
			return propertyInfo.Name;
		}

		private static MemberExpression FindMemberExpression<T>(Expression<Func<T>> expression)
		{
			if (expression.Body is UnaryExpression unaryExpression)
			{
				return (unaryExpression.Operand as MemberExpression) ?? throw new ArgumentException("Wrong unary expression\nshould be called with expression like\n() => PropertyName", "expression");
			}
			return expression.Body as MemberExpression;
		}
	}
	public abstract class MvxSingleton : IDisposable
	{
		private static readonly List<MvxSingleton> Singletons = new List<MvxSingleton>();

		~MvxSingleton()
		{
			Dispose(isDisposing: false);
		}

		public void Dispose()
		{
			Dispose(isDisposing: true);
			GC.SuppressFinalize(this);
		}

		protected abstract void Dispose(bool isDisposing);

		protected MvxSingleton()
		{
			lock (Singletons)
			{
				Singletons.Add(this);
			}
		}

		public static void ClearAllSingletons()
		{
			lock (Singletons)
			{
				foreach (MvxSingleton singleton in Singletons)
				{
					singleton.Dispose();
				}
				Singletons.Clear();
			}
		}
	}
	public abstract class MvxSingleton<TInterface> : MvxSingleton where TInterface : class
	{
		public static TInterface Instance { get; private set; }

		protected MvxSingleton()
		{
			if (Instance != null)
			{
				throw new MvxException("You cannot create more than one instance of MvxSingleton");
			}
			Instance = this as TInterface;
		}

		protected override void Dispose(bool isDisposing)
		{
			if (isDisposing)
			{
				Instance = null;
			}
		}
	}
	public class MvxValueEventArgs<T> : EventArgs
	{
		public T Value { get; private set; }

		public MvxValueEventArgs(T value)
		{
			Value = value;
		}
	}
	public interface IMvxDisposeSource
	{
		event EventHandler DisposeCalled;
	}
	public interface IMvxMainThreadDispatcher
	{
		bool RequestMainThreadAction(Action action);
	}
	public interface IMvxDataConsumer
	{
		object DataContext { get; set; }
	}
}
namespace MvvmCross.Platform.Converters
{
	public class MvxBindingConstant
	{
		public static readonly MvxBindingConstant DoNothing = new MvxBindingConstant("DoNothing");

		public static readonly MvxBindingConstant UnsetValue = new MvxBindingConstant("UnsetValue");

		private readonly string _debug;

		private MvxBindingConstant(string debug)
		{
			_debug = debug;
		}

		public override string ToString()
		{
			return "Binding:" + _debug;
		}
	}
	public interface IMvxValueConverterRegistry : IMvxNamedInstanceRegistry<IMvxValueConverter>
	{
	}
	public abstract class MvxValueConverter : IMvxValueConverter
	{
		public virtual object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return MvxBindingConstant.UnsetValue;
		}

		public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			return MvxBindingConstant.UnsetValue;
		}
	}
	public abstract class MvxValueConverter<TFrom, TTo> : IMvxValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
				return Convert((TFrom)value, targetType, parameter, culture);
			}
			catch (Exception)
			{
				return MvxBindingConstant.UnsetValue;
			}
		}

		protected virtual TTo Convert(TFrom value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
				return ConvertBack((TTo)value, targetType, parameter, culture);
			}
			catch (Exception)
			{
				return MvxBindingConstant.UnsetValue;
			}
		}

		protected virtual TFrom ConvertBack(TTo value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
	public abstract class MvxValueConverter<TFrom> : IMvxValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
				return Convert((TFrom)value, targetType, parameter, culture);
			}
			catch (Exception)
			{
				return MvxBindingConstant.UnsetValue;
			}
		}

		protected virtual object Convert(TFrom value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			try
			{
				return TypedConvertBack(value, targetType, parameter, culture);
			}
			catch (Exception)
			{
				return MvxBindingConstant.UnsetValue;
			}
		}

		protected virtual TFrom TypedConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
	public interface IMvxValueConverter
	{
		object Convert(object value, Type targetType, object parameter, CultureInfo culture);

		object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture);
	}
}
namespace MvvmCross.Platform.ExtensionMethods
{
	public static class MvxCrossCoreExtensions
	{
		public static bool ConvertToBooleanCore(this object result)
		{
			if (result == null)
			{
				return false;
			}
			if (result is string value)
			{
				return !string.IsNullOrEmpty(value);
			}
			if (result is bool)
			{
				return (bool)result;
			}
			Type type = result.GetType();
			if (type.GetTypeInfo().IsValueType)
			{
				Type type2 = Nullable.GetUnderlyingType(type) ?? type;
				return !result.Equals(type2.CreateDefault());
			}
			return true;
		}

		public static object MakeSafeValueCore(this Type propertyType, object value)
		{
			if (value == null)
			{
				return propertyType.CreateDefault();
			}
			object result = value;
			if (!ReflectionExtensions.IsInstanceOfType(propertyType, value))
			{
				if ((object)propertyType == typeof(string))
				{
					result = value.ToString();
				}
				else if (propertyType.GetTypeInfo().IsEnum)
				{
					result = ((value is string value2) ? Enum.Parse(propertyType, value2, ignoreCase: true) : Enum.ToObject(propertyType, value));
				}
				else if (propertyType.GetTypeInfo().IsValueType)
				{
					Type type = Nullable.GetUnderlyingType(propertyType) ?? propertyType;
					result = (((object)type == typeof(bool)) ? ((object)value.ConvertToBooleanCore()) : ErrorMaskedConvert(value, type, CultureInfo.CurrentUICulture));
				}
				else
				{
					result = ErrorMaskedConvert(value, propertyType, CultureInfo.CurrentUICulture);
				}
			}
			return result;
		}

		private static object ErrorMaskedConvert(object value, Type type, CultureInfo cultureInfo)
		{
			try
			{
				return Convert.ChangeType(value, type, cultureInfo);
			}
			catch (Exception)
			{
				return value;
			}
		}
	}
}
