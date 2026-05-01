using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Threading;
using Microsoft.CSharp.RuntimeBinder.Errors;
using Microsoft.CSharp.RuntimeBinder.Semantics;
using Microsoft.CSharp.RuntimeBinder.Syntax;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("Microsoft.CSharp.dll")]
[assembly: AssemblyDescription("Microsoft.CSharp.dll")]
[assembly: AssemblyDefaultAlias("Microsoft.CSharp.dll")]
[assembly: AssemblyCompany("Mono development team")]
[assembly: AssemblyProduct("Mono Common Language Infrastructure")]
[assembly: AssemblyCopyright("(c) Various Mono authors")]
[assembly: SatelliteContractVersion("2.0.5.0")]
[assembly: AssemblyInformationalVersion("4.0.50524.0")]
[assembly: AssemblyFileVersion("4.0.50524.0")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: CLSCompliant(true)]
[assembly: AssemblyDelaySign(true)]
[assembly: SecurityCritical]
[assembly: ComVisible(false)]
[assembly: AssemblyVersion("2.0.5.0")]
internal static class Consts
{
	public const string MonoCorlibVersion = "1A5E0066-58DC-428A-B21C-0AD6CDAE2789";

	public const string MonoVersion = "6.12.0.0";

	public const string MonoCompany = "Mono development team";

	public const string MonoProduct = "Mono Common Language Infrastructure";

	public const string MonoCopyright = "(c) Various Mono authors";

	public const string FxVersion = "2.0.5.0";

	public const string VsVersion = "9.0.0.0";

	public const string FxFileVersion = "4.0.50524.0";

	public const string EnvironmentVersion = "4.0.50524.0";

	public const string VsFileVersion = "9.0.50727.42";

	private const string PublicKeyToken = "7cec85d7bea7798e";

	public const string AssemblyI18N = "I18N, Version=2.0.5.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756";

	public const string AssemblyMicrosoft_JScript = "Microsoft.JScript, Version=2.0.5.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";

	public const string AssemblyMicrosoft_VisualStudio = "Microsoft.VisualStudio, Version=2.0.5.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";

	public const string AssemblyMicrosoft_VisualStudio_Web = "Microsoft.VisualStudio.Web, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";

	public const string AssemblyMicrosoft_VSDesigner = "Microsoft.VSDesigner, Version=9.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";

	public const string AssemblyMono_Http = "Mono.Http, Version=2.0.5.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756";

	public const string AssemblyMono_Posix = "Mono.Posix, Version=2.0.5.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756";

	public const string AssemblyMono_Security = "Mono.Security, Version=2.0.5.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756";

	public const string AssemblyMono_Messaging_RabbitMQ = "Mono.Messaging.RabbitMQ, Version=2.0.5.0, Culture=neutral, PublicKeyToken=0738eb9f132ed756";

	public const string AssemblyCorlib = "mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e";

	public const string AssemblySystem = "System, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e";

	public const string AssemblySystem_Data = "System.Data, Version=2.0.5.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";

	public const string AssemblySystem_Design = "System.Design, Version=2.0.5.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";

	public const string AssemblySystem_DirectoryServices = "System.DirectoryServices, Version=2.0.5.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";

	public const string AssemblySystem_Drawing = "System.Drawing, Version=2.0.5.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";

	public const string AssemblySystem_Drawing_Design = "System.Drawing.Design, Version=2.0.5.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";

	public const string AssemblySystem_Messaging = "System.Messaging, Version=2.0.5.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";

	public const string AssemblySystem_Security = "System.Security, Version=2.0.5.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";

	public const string AssemblySystem_ServiceProcess = "System.ServiceProcess, Version=2.0.5.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";

	public const string AssemblySystem_Web = "System.Web, Version=2.0.5.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a";

	public const string AssemblySystem_Windows_Forms = "System.Windows.Forms, Version=2.0.5.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";

	public const string AssemblySystem_2_0 = "System, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";

	public const string AssemblySystemCore_3_5 = "System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";

	public const string AssemblySystem_Core = "System.Core, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e";

	public const string WindowsBase_3_0 = "WindowsBase, Version=3.0.0.0, PublicKeyToken=31bf3856ad364e35";

	public const string AssemblyWindowsBase = "WindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35";

	public const string AssemblyPresentationCore_3_5 = "PresentationCore, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35";

	public const string AssemblyPresentationCore_4_0 = "PresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35";

	public const string AssemblyPresentationFramework_3_5 = "PresentationFramework, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35";

	public const string AssemblySystemServiceModel_3_0 = "System.ServiceModel, Version=3.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089";
}
internal static class SR
{
	public const string InternalCompilerError = "An unexpected exception occurred while binding a dynamic operation";

	public const string BindPropertyFailedMethodGroup = "The name '{0}' is bound to a method and cannot be used like a property";

	public const string BindPropertyFailedEvent = "The event '{0}' can only appear on the left hand side of +";

	public const string BindInvokeFailedNonDelegate = "Cannot invoke a non-delegate type";

	public const string NullReferenceOnMemberException = "Cannot perform runtime binding on a null reference";

	public const string BindCallToConditionalMethod = "Cannot dynamically invoke method '{0}' because it has a Conditional attribute";

	public const string BindToVoidMethodButExpectResult = "Cannot implicitly convert type 'void' to 'object'";

	public const string BadBinaryOps = "Operator '{0}' cannot be applied to operands of type '{1}' and '{2}'";

	public const string BadIndexLHS = "Cannot apply indexing with [] to an expression of type '{0}'";

	public const string BadIndexCount = "Wrong number of indices inside []; expected '{0}'";

	public const string BadUnaryOp = "Operator '{0}' cannot be applied to operand of type '{1}'";

	public const string NoImplicitConv = "Cannot implicitly convert type '{0}' to '{1}'";

	public const string NoExplicitConv = "Cannot convert type '{0}' to '{1}'";

	public const string ConstOutOfRange = "Constant value '{0}' cannot be converted to a '{1}'";

	public const string AmbigBinaryOps = "Operator '{0}' is ambiguous on operands of type '{1}' and '{2}'";

	public const string AmbigUnaryOp = "Operator '{0}' is ambiguous on an operand of type '{1}'";

	public const string ValueCantBeNull = "Cannot convert null to '{0}' because it is a non-nullable value type";

	public const string WrongNestedThis = "Cannot access a non-static member of outer type '{0}' via nested type '{1}'";

	public const string NoSuchMember = "'{0}' does not contain a definition for '{1}'";

	public const string ObjectRequired = "An object reference is required for the non-static field, method, or property '{0}'";

	public const string AmbigCall = "The call is ambiguous between the following methods or properties: '{0}' and '{1}'";

	public const string BadAccess = "'{0}' is inaccessible due to its protection level";

	public const string AssgLvalueExpected = "The left-hand side of an assignment must be a variable, property or indexer";

	public const string NoConstructors = "The type '{0}' has no constructors defined";

	public const string PropertyLacksGet = "The property or indexer '{0}' cannot be used in this context because it lacks the get accessor";

	public const string ObjectProhibited = "Member '{0}' cannot be accessed with an instance reference; qualify it with a type name instead";

	public const string AssgReadonly = "A readonly field cannot be assigned to (except in a constructor or a variable initializer)";

	public const string AssgReadonlyStatic = "A static readonly field cannot be assigned to (except in a static constructor or a variable initializer)";

	public const string AssgReadonlyProp = "Property or indexer '{0}' cannot be assigned to -- it is read only";

	public const string UnsafeNeeded = "Dynamic calls cannot be used in conjunction with pointers";

	public const string BadBoolOp = "In order to be applicable as a short circuit operator a user-defined logical operator ('{0}') must have the same return type as the type of its 2 parameters";

	public const string MustHaveOpTF = "The type ('{0}') must contain declarations of operator true and operator false";

	public const string ConstOutOfRangeChecked = "Constant value '{0}' cannot be converted to a '{1}' (use 'unchecked' syntax to override)";

	public const string AmbigMember = "Ambiguity between '{0}' and '{1}'";

	public const string NoImplicitConvCast = "Cannot implicitly convert type '{0}' to '{1}'. An explicit conversion exists (are you missing a cast?)";

	public const string InaccessibleGetter = "The property or indexer '{0}' cannot be used in this context because the get accessor is inaccessible";

	public const string InaccessibleSetter = "The property or indexer '{0}' cannot be used in this context because the set accessor is inaccessible";

	public const string BadArity = "Using the generic {1} '{0}' requires '{2}' type arguments";

	public const string TypeArgsNotAllowed = "The {1} '{0}' cannot be used with type arguments";

	public const string HasNoTypeVars = "The non-generic {1} '{0}' cannot be used with type arguments";

	public const string NewConstraintNotSatisfied = "'{2}' must be a non-abstract type with a public parameterless constructor in order to use it as parameter '{1}' in the generic type or method '{0}'";

	public const string GenericConstraintNotSatisfiedRefType = "The type '{3}' cannot be used as type parameter '{2}' in the generic type or method '{0}'. There is no implicit reference conversion from '{3}' to '{1}'.";

	public const string GenericConstraintNotSatisfiedNullableEnum = "The type '{3}' cannot be used as type parameter '{2}' in the generic type or method '{0}'. The nullable type '{3}' does not satisfy the constraint of '{1}'.";

	public const string GenericConstraintNotSatisfiedNullableInterface = "The type '{3}' cannot be used as type parameter '{2}' in the generic type or method '{0}'. The nullable type '{3}' does not satisfy the constraint of '{1}'. Nullable types can not satisfy any interface constraints.";

	public const string GenericConstraintNotSatisfiedValType = "The type '{3}' cannot be used as type parameter '{2}' in the generic type or method '{0}'. There is no boxing conversion from '{3}' to '{1}'.";

	public const string CantInferMethTypeArgs = "The type arguments for method '{0}' cannot be inferred from the usage. Try specifying the type arguments explicitly.";

	public const string RefConstraintNotSatisfied = "The type '{2}' must be a reference type in order to use it as parameter '{1}' in the generic type or method '{0}'";

	public const string ValConstraintNotSatisfied = "The type '{2}' must be a non-nullable value type in order to use it as parameter '{1}' in the generic type or method '{0}'";

	public const string AmbigUDConv = "Ambiguous user defined conversions '{0}' and '{1}' when converting from '{2}' to '{3}'";

	public const string BindToBogus = "'{0}' is not supported by the language";

	public const string CantCallSpecialMethod = "'{0}': cannot explicitly call operator or accessor";

	public const string ConvertToStaticClass = "Cannot convert to static type '{0}'";

	public const string IncrementLvalueExpected = "The operand of an increment or decrement operator must be a variable, property or indexer";

	public const string BadArgCount = "No overload for method '{0}' takes {1} arguments";

	public const string BadArgTypes = "The best overloaded method match for '{0}' has some invalid arguments";

	public const string BadProtectedAccess = "Cannot access protected member '{0}' via a qualifier of type '{1}'; the qualifier must be of type '{2}' (or derived from it)";

	public const string BindToBogusProp2 = "Property, indexer, or event '{0}' is not supported by the language; try directly calling accessor methods '{1}' or '{2}'";

	public const string BindToBogusProp1 = "Property, indexer, or event '{0}' is not supported by the language; try directly calling accessor method '{1}'";

	public const string BadDelArgCount = "Delegate '{0}' does not take '{1}' arguments";

	public const string BadDelArgTypes = "Delegate '{0}' has some invalid arguments";

	public const string ReturnNotLValue = "Cannot modify the return value of '{0}' because it is not a variable";

	public const string AssgReadonly2 = "Members of readonly field '{0}' cannot be modified (except in a constructor or a variable initializer)";

	public const string AssgReadonlyStatic2 = "Fields of static readonly field '{0}' cannot be assigned to (except in a static constructor or a variable initializer)";

	public const string BadCtorArgCount = "'{0}' does not contain a constructor that takes '{1}' arguments";

	public const string NonInvocableMemberCalled = "Non-invocable member '{0}' cannot be used like a method.";

	public const string BadNamedArgument = "The best overload for '{0}' does not have a parameter named '{1}'";

	public const string BadNamedArgumentForDelegateInvoke = "The delegate '{0}' does not have a parameter named '{1}'";

	public const string DuplicateNamedArgument = "Named argument '{0}' cannot be specified multiple times";

	public const string NamedArgumentUsedInPositional = "Named argument '{0}' specifies a parameter for which a positional argument has already been given";

	public const string TypeArgumentRequiredForStaticCall = "The first argument to dynamically-bound static or constructor call must be a Type";

	public const string DynamicArgumentNeedsValue = "The runtime binder cannot bind a metaobject without a value";

	public const string BindingNameCollision = "More than one type in the binding has the same full name.";

	public const string BadNonTrailingNamedArgument = "Named argument '{0}' is used out-of-position but is followed by an unnamed argument";

	internal static string GetString(string name, params object[] args)
	{
		return GetString(CultureInfo.InvariantCulture, name, args);
	}

	internal static string GetString(CultureInfo culture, string name, params object[] args)
	{
		return string.Format(culture, name, args);
	}

	internal static string GetString(string name)
	{
		return name;
	}

	internal static string GetString(CultureInfo culture, string name)
	{
		return name;
	}

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

	internal static string Format(CultureInfo ci, string resourceFormat, object p1, object p2)
	{
		return string.Format(ci, resourceFormat, p1, p2);
	}

	internal static string Format(string resourceFormat, object p1, object p2, object p3)
	{
		return string.Format(CultureInfo.InvariantCulture, resourceFormat, p1, p2, p3);
	}

	internal static string GetResourceString(string str)
	{
		return str;
	}
}
namespace System.Runtime.CompilerServices
{
	internal class FriendAccessAllowedAttribute : Attribute
	{
	}
}
namespace Microsoft.CSharp.RuntimeBinder
{
	internal readonly struct ArgumentObject(object value, CSharpArgumentInfo info, Type type)
	{
		internal readonly object Value = value;

		internal readonly CSharpArgumentInfo Info = info;

		internal readonly Type Type = type;
	}
	[EditorBrowsable(EditorBrowsableState.Never)]
	public static class Binder
	{
		public static CallSiteBinder BinaryOperation(CSharpBinderFlags flags, ExpressionType operation, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
		{
			bool isChecked = (flags & CSharpBinderFlags.CheckedContext) != 0;
			bool num = (flags & CSharpBinderFlags.BinaryOperationLogical) != 0;
			CSharpBinaryOperationFlags cSharpBinaryOperationFlags = CSharpBinaryOperationFlags.None;
			if (num)
			{
				cSharpBinaryOperationFlags |= CSharpBinaryOperationFlags.LogicalOperation;
			}
			return new CSharpBinaryOperationBinder(operation, isChecked, cSharpBinaryOperationFlags, context, argumentInfo);
		}

		public static CallSiteBinder Convert(CSharpBinderFlags flags, Type type, Type context)
		{
			CSharpConversionKind conversionKind = (((flags & CSharpBinderFlags.ConvertExplicit) != CSharpBinderFlags.None) ? CSharpConversionKind.ExplicitConversion : (((flags & CSharpBinderFlags.ConvertArrayIndex) != CSharpBinderFlags.None) ? CSharpConversionKind.ArrayCreationConversion : CSharpConversionKind.ImplicitConversion));
			bool isChecked = (flags & CSharpBinderFlags.CheckedContext) != 0;
			return new CSharpConvertBinder(type, conversionKind, isChecked, context);
		}

		public static CallSiteBinder GetIndex(CSharpBinderFlags flags, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
		{
			return new CSharpGetIndexBinder(context, argumentInfo);
		}

		public static CallSiteBinder GetMember(CSharpBinderFlags flags, string name, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
		{
			bool resultIndexed = (flags & CSharpBinderFlags.ResultIndexed) != 0;
			return new CSharpGetMemberBinder(name, resultIndexed, context, argumentInfo);
		}

		public static CallSiteBinder Invoke(CSharpBinderFlags flags, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
		{
			bool num = (flags & CSharpBinderFlags.ResultDiscarded) != 0;
			CSharpCallFlags cSharpCallFlags = CSharpCallFlags.None;
			if (num)
			{
				cSharpCallFlags |= CSharpCallFlags.ResultDiscarded;
			}
			return new CSharpInvokeBinder(cSharpCallFlags, context, argumentInfo);
		}

		public static CallSiteBinder InvokeMember(CSharpBinderFlags flags, string name, IEnumerable<Type> typeArguments, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
		{
			bool num = (flags & CSharpBinderFlags.InvokeSimpleName) != 0;
			bool flag = (flags & CSharpBinderFlags.InvokeSpecialName) != 0;
			bool flag2 = (flags & CSharpBinderFlags.ResultDiscarded) != 0;
			CSharpCallFlags cSharpCallFlags = CSharpCallFlags.None;
			if (num)
			{
				cSharpCallFlags |= CSharpCallFlags.SimpleNameCall;
			}
			if (flag)
			{
				cSharpCallFlags |= CSharpCallFlags.EventHookup;
			}
			if (flag2)
			{
				cSharpCallFlags |= CSharpCallFlags.ResultDiscarded;
			}
			return new CSharpInvokeMemberBinder(cSharpCallFlags, name, context, typeArguments, argumentInfo);
		}

		public static CallSiteBinder InvokeConstructor(CSharpBinderFlags flags, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
		{
			return new CSharpInvokeConstructorBinder(CSharpCallFlags.None, context, argumentInfo);
		}

		public static CallSiteBinder IsEvent(CSharpBinderFlags flags, string name, Type context)
		{
			return new CSharpIsEventBinder(name, context);
		}

		public static CallSiteBinder SetIndex(CSharpBinderFlags flags, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
		{
			bool isCompoundAssignment = (flags & CSharpBinderFlags.ValueFromCompoundAssignment) != 0;
			bool isChecked = (flags & CSharpBinderFlags.CheckedContext) != 0;
			return new CSharpSetIndexBinder(isCompoundAssignment, isChecked, context, argumentInfo);
		}

		public static CallSiteBinder SetMember(CSharpBinderFlags flags, string name, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
		{
			bool isCompoundAssignment = (flags & CSharpBinderFlags.ValueFromCompoundAssignment) != 0;
			bool isChecked = (flags & CSharpBinderFlags.CheckedContext) != 0;
			return new CSharpSetMemberBinder(name, isCompoundAssignment, isChecked, context, argumentInfo);
		}

		public static CallSiteBinder UnaryOperation(CSharpBinderFlags flags, ExpressionType operation, Type context, IEnumerable<CSharpArgumentInfo> argumentInfo)
		{
			bool isChecked = (flags & CSharpBinderFlags.CheckedContext) != 0;
			return new CSharpUnaryOperationBinder(operation, isChecked, context, argumentInfo);
		}
	}
	internal static class BinderHelper
	{
		private static MethodInfo s_DoubleIsNaN;

		private static MethodInfo s_SingleIsNaN;

		internal static DynamicMetaObject Bind(ICSharpBinder action, RuntimeBinder binder, DynamicMetaObject[] args, IEnumerable<CSharpArgumentInfo> arginfos, DynamicMetaObject onBindingError)
		{
			Expression[] array = new Expression[args.Length];
			BindingRestrictions bindingRestrictions = BindingRestrictions.Empty;
			ICSharpInvokeOrInvokeMemberBinder callPayload = action as ICSharpInvokeOrInvokeMemberBinder;
			ParameterExpression parameterExpression = null;
			IEnumerator<CSharpArgumentInfo> enumerator = (arginfos ?? Array.Empty<CSharpArgumentInfo>()).GetEnumerator();
			for (int i = 0; i < args.Length; i++)
			{
				DynamicMetaObject dynamicMetaObject = args[i];
				CSharpArgumentInfo cSharpArgumentInfo = (enumerator.MoveNext() ? enumerator.Current : null);
				if (i == 0 && IsIncrementOrDecrementActionOnLocal(action))
				{
					object value = dynamicMetaObject.Value;
					parameterExpression = (ParameterExpression)(array[0] = Expression.Variable((value != null) ? value.GetType() : typeof(object), "t0"));
				}
				else
				{
					array[i] = dynamicMetaObject.Expression;
				}
				BindingRestrictions restrictions = DeduceArgumentRestriction(i, callPayload, dynamicMetaObject, cSharpArgumentInfo);
				bindingRestrictions = bindingRestrictions.Merge(restrictions);
				if (cSharpArgumentInfo != null && cSharpArgumentInfo.LiteralConstant)
				{
					if (dynamicMetaObject.Value is double && double.IsNaN((double)dynamicMetaObject.Value))
					{
						MethodInfo method = s_DoubleIsNaN ?? (s_DoubleIsNaN = typeof(double).GetMethod("IsNaN"));
						Expression expression = Expression.Call(null, method, dynamicMetaObject.Expression);
						bindingRestrictions = bindingRestrictions.Merge(BindingRestrictions.GetExpressionRestriction(expression));
					}
					else if (dynamicMetaObject.Value is float && float.IsNaN((float)dynamicMetaObject.Value))
					{
						MethodInfo method2 = s_SingleIsNaN ?? (s_SingleIsNaN = typeof(float).GetMethod("IsNaN"));
						Expression expression2 = Expression.Call(null, method2, dynamicMetaObject.Expression);
						bindingRestrictions = bindingRestrictions.Merge(BindingRestrictions.GetExpressionRestriction(expression2));
					}
					else
					{
						restrictions = BindingRestrictions.GetExpressionRestriction(Expression.Equal(dynamicMetaObject.Expression, Expression.Constant(dynamicMetaObject.Value, dynamicMetaObject.Expression.Type)));
						bindingRestrictions = bindingRestrictions.Merge(restrictions);
					}
				}
			}
			try
			{
				Expression expression3 = binder.Bind(action, array, args, out var deferredBinding);
				if (deferredBinding != null)
				{
					expression3 = ConvertResult(deferredBinding.Expression, action);
					bindingRestrictions = deferredBinding.Restrictions.Merge(bindingRestrictions);
					return new DynamicMetaObject(expression3, bindingRestrictions);
				}
				if (parameterExpression != null)
				{
					DynamicMetaObject dynamicMetaObject2 = args[0];
					expression3 = Expression.Block(new ParameterExpression[1] { parameterExpression }, Expression.Assign(parameterExpression, Expression.Convert(dynamicMetaObject2.Expression, dynamicMetaObject2.Value.GetType())), expression3, Expression.Assign(dynamicMetaObject2.Expression, Expression.Convert(parameterExpression, dynamicMetaObject2.Expression.Type)));
				}
				expression3 = ConvertResult(expression3, action);
				return new DynamicMetaObject(expression3, bindingRestrictions);
			}
			catch (RuntimeBinderException ex)
			{
				if (onBindingError != null)
				{
					return onBindingError;
				}
				return new DynamicMetaObject(Expression.Throw(Expression.New(typeof(RuntimeBinderException).GetConstructor(new Type[1] { typeof(string) }), Expression.Constant(ex.Message)), GetTypeForErrorMetaObject(action, args)), bindingRestrictions);
			}
		}

		public static void ValidateBindArgument(DynamicMetaObject argument, string paramName)
		{
			if (argument == null)
			{
				throw Error.ArgumentNull(paramName);
			}
			if (!argument.HasValue)
			{
				throw Error.DynamicArgumentNeedsValue(paramName);
			}
		}

		public static void ValidateBindArgument(DynamicMetaObject[] arguments, string paramName)
		{
			if (arguments != null)
			{
				for (int i = 0; i != arguments.Length; i++)
				{
					ValidateBindArgument(arguments[i], $"{paramName}[{i}]");
				}
			}
		}

		private static bool IsTypeOfStaticCall(int parameterIndex, ICSharpInvokeOrInvokeMemberBinder callPayload)
		{
			if (parameterIndex == 0 && callPayload != null)
			{
				return callPayload.StaticCall;
			}
			return false;
		}

		private static bool IsComObject(object obj)
		{
			if (obj != null)
			{
				return Marshal.IsComObject(obj);
			}
			return false;
		}

		private static bool IsTransparentProxy(object obj)
		{
			return false;
		}

		private static bool IsDynamicallyTypedRuntimeProxy(DynamicMetaObject argument, CSharpArgumentInfo info)
		{
			if (info != null && !info.UseCompileTimeType)
			{
				if (!IsComObject(argument.Value))
				{
					return IsTransparentProxy(argument.Value);
				}
				return true;
			}
			return false;
		}

		private static BindingRestrictions DeduceArgumentRestriction(int parameterIndex, ICSharpInvokeOrInvokeMemberBinder callPayload, DynamicMetaObject argument, CSharpArgumentInfo info)
		{
			if (argument.Value != null && !IsTypeOfStaticCall(parameterIndex, callPayload) && !IsDynamicallyTypedRuntimeProxy(argument, info))
			{
				return BindingRestrictions.GetTypeRestriction(argument.Expression, argument.RuntimeType);
			}
			return BindingRestrictions.GetInstanceRestriction(argument.Expression, argument.Value);
		}

		private static Expression ConvertResult(Expression binding, ICSharpBinder action)
		{
			if (action is CSharpInvokeConstructorBinder)
			{
				return binding;
			}
			if (binding.Type == typeof(void))
			{
				if (action is ICSharpInvokeOrInvokeMemberBinder { ResultDiscarded: not false })
				{
					return Expression.Block(binding, Expression.Default(action.ReturnType));
				}
				throw Error.BindToVoidMethodButExpectResult();
			}
			if (binding.Type.IsValueType && !action.ReturnType.IsValueType)
			{
				return Expression.Convert(binding, action.ReturnType);
			}
			return binding;
		}

		private static Type GetTypeForErrorMetaObject(ICSharpBinder action, DynamicMetaObject[] args)
		{
			if (action is CSharpInvokeConstructorBinder)
			{
				return args[0].Value as Type;
			}
			return action.ReturnType;
		}

		private static bool IsIncrementOrDecrementActionOnLocal(ICSharpBinder action)
		{
			if (action is CSharpUnaryOperationBinder cSharpUnaryOperationBinder)
			{
				if (cSharpUnaryOperationBinder.Operation != ExpressionType.Increment)
				{
					return cSharpUnaryOperationBinder.Operation == ExpressionType.Decrement;
				}
				return true;
			}
			return false;
		}

		internal static T[] Cons<T>(T sourceHead, T[] sourceTail)
		{
			if (sourceTail == null || sourceTail.Length != 0)
			{
				T[] array = new T[sourceTail.Length + 1];
				array[0] = sourceHead;
				sourceTail.CopyTo(array, 1);
				return array;
			}
			return new T[1] { sourceHead };
		}

		internal static T[] Cons<T>(T sourceHead, T[] sourceMiddle, T sourceLast)
		{
			if (sourceMiddle == null || sourceMiddle.Length != 0)
			{
				T[] array = new T[sourceMiddle.Length + 2];
				array[0] = sourceHead;
				array[array.Length - 1] = sourceLast;
				sourceMiddle.CopyTo(array, 1);
				return array;
			}
			return new T[2] { sourceHead, sourceLast };
		}

		internal static T[] ToArray<T>(IEnumerable<T> source)
		{
			if (source != null)
			{
				return source.ToArray();
			}
			return Array.Empty<T>();
		}

		internal static CallInfo CreateCallInfo(ref IEnumerable<CSharpArgumentInfo> argInfos, int discard)
		{
			int num = 0;
			List<string> list = new List<string>();
			CSharpArgumentInfo[] array = (CSharpArgumentInfo[])(argInfos = ToArray(argInfos));
			foreach (CSharpArgumentInfo cSharpArgumentInfo in array)
			{
				if (cSharpArgumentInfo.NamedArgument)
				{
					list.Add(cSharpArgumentInfo.Name);
				}
				num++;
			}
			return new CallInfo(num - discard, list);
		}

		internal static string GetCLROperatorName(this ExpressionType p)
		{
			return p switch
			{
				ExpressionType.Add => "op_Addition", 
				ExpressionType.Subtract => "op_Subtraction", 
				ExpressionType.Multiply => "op_Multiply", 
				ExpressionType.Divide => "op_Division", 
				ExpressionType.Modulo => "op_Modulus", 
				ExpressionType.LeftShift => "op_LeftShift", 
				ExpressionType.RightShift => "op_RightShift", 
				ExpressionType.LessThan => "op_LessThan", 
				ExpressionType.GreaterThan => "op_GreaterThan", 
				ExpressionType.LessThanOrEqual => "op_LessThanOrEqual", 
				ExpressionType.GreaterThanOrEqual => "op_GreaterThanOrEqual", 
				ExpressionType.Equal => "op_Equality", 
				ExpressionType.NotEqual => "op_Inequality", 
				ExpressionType.And => "op_BitwiseAnd", 
				ExpressionType.ExclusiveOr => "op_ExclusiveOr", 
				ExpressionType.Or => "op_BitwiseOr", 
				ExpressionType.AddAssign => "op_Addition", 
				ExpressionType.SubtractAssign => "op_Subtraction", 
				ExpressionType.MultiplyAssign => "op_Multiply", 
				ExpressionType.DivideAssign => "op_Division", 
				ExpressionType.ModuloAssign => "op_Modulus", 
				ExpressionType.AndAssign => "op_BitwiseAnd", 
				ExpressionType.ExclusiveOrAssign => "op_ExclusiveOr", 
				ExpressionType.OrAssign => "op_BitwiseOr", 
				ExpressionType.LeftShiftAssign => "op_LeftShift", 
				ExpressionType.RightShiftAssign => "op_RightShift", 
				ExpressionType.Negate => "op_UnaryNegation", 
				ExpressionType.UnaryPlus => "op_UnaryPlus", 
				ExpressionType.Not => "op_LogicalNot", 
				ExpressionType.OnesComplement => "op_OnesComplement", 
				ExpressionType.IsTrue => "op_True", 
				ExpressionType.IsFalse => "op_False", 
				ExpressionType.Increment => "op_Increment", 
				ExpressionType.Decrement => "op_Decrement", 
				_ => null, 
			};
		}
	}
	[EditorBrowsable(EditorBrowsableState.Never)]
	public sealed class CSharpArgumentInfo
	{
		internal static readonly CSharpArgumentInfo None = new CSharpArgumentInfo(CSharpArgumentInfoFlags.None, null);

		private CSharpArgumentInfoFlags Flags { get; }

		internal string Name { get; }

		internal bool UseCompileTimeType => (Flags & CSharpArgumentInfoFlags.UseCompileTimeType) != 0;

		internal bool LiteralConstant => (Flags & CSharpArgumentInfoFlags.Constant) != 0;

		internal bool NamedArgument => (Flags & CSharpArgumentInfoFlags.NamedArgument) != 0;

		internal bool IsByRefOrOut => (Flags & (CSharpArgumentInfoFlags.IsRef | CSharpArgumentInfoFlags.IsOut)) != 0;

		internal bool IsOut => (Flags & CSharpArgumentInfoFlags.IsOut) != 0;

		internal bool IsStaticType => (Flags & CSharpArgumentInfoFlags.IsStaticType) != 0;

		private CSharpArgumentInfo(CSharpArgumentInfoFlags flags, string name)
		{
			Flags = flags;
			Name = name;
		}

		public static CSharpArgumentInfo Create(CSharpArgumentInfoFlags flags, string name)
		{
			return new CSharpArgumentInfo(flags, name);
		}
	}
	[Flags]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum CSharpArgumentInfoFlags
	{
		None = 0,
		UseCompileTimeType = 1,
		Constant = 2,
		NamedArgument = 4,
		IsRef = 8,
		IsOut = 0x10,
		IsStaticType = 0x20
	}
	internal sealed class CSharpBinaryOperationBinder : BinaryOperationBinder, ICSharpBinder
	{
		private readonly CSharpBinaryOperationFlags _binopFlags;

		private readonly CSharpArgumentInfo[] _argumentInfo;

		private readonly RuntimeBinder _binder;

		[ExcludeFromCodeCoverage]
		public string Name => null;

		public BindingFlag BindingFlags => (BindingFlag)0;

		public bool IsBinderThatCanHaveRefReceiver => false;

		internal bool IsLogicalOperation => (_binopFlags & CSharpBinaryOperationFlags.LogicalOperation) != 0;

		public Expr DispatchPayload(RuntimeBinder runtimeBinder, ArgumentObject[] arguments, LocalVariableSymbol[] locals)
		{
			return runtimeBinder.BindBinaryOperation(this, arguments, locals);
		}

		public void PopulateSymbolTableWithName(Type callingType, ArgumentObject[] arguments)
		{
			string cLROperatorName = base.Operation.GetCLROperatorName();
			SymbolTable.PopulateSymbolTableWithName(cLROperatorName, null, arguments[0].Type);
			SymbolTable.PopulateSymbolTableWithName(cLROperatorName, null, arguments[1].Type);
		}

		CSharpArgumentInfo ICSharpBinder.GetArgumentInfo(int index)
		{
			return _argumentInfo[index];
		}

		public CSharpBinaryOperationBinder(ExpressionType operation, bool isChecked, CSharpBinaryOperationFlags binaryOperationFlags, Type callingContext, IEnumerable<CSharpArgumentInfo> argumentInfo)
			: base(operation)
		{
			_binopFlags = binaryOperationFlags;
			_argumentInfo = BinderHelper.ToArray(argumentInfo);
			_binder = new RuntimeBinder(callingContext, isChecked);
		}

		public override DynamicMetaObject FallbackBinaryOperation(DynamicMetaObject target, DynamicMetaObject arg, DynamicMetaObject errorSuggestion)
		{
			BinderHelper.ValidateBindArgument(target, "target");
			BinderHelper.ValidateBindArgument(arg, "arg");
			return BinderHelper.Bind(this, _binder, new DynamicMetaObject[2] { target, arg }, _argumentInfo, errorSuggestion);
		}
	}
	[Flags]
	internal enum CSharpBinaryOperationFlags
	{
		None = 0,
		MemberAccess = 1,
		LogicalOperation = 2
	}
	[Flags]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public enum CSharpBinderFlags
	{
		None = 0,
		CheckedContext = 1,
		InvokeSimpleName = 2,
		InvokeSpecialName = 4,
		BinaryOperationLogical = 8,
		ConvertExplicit = 0x10,
		ConvertArrayIndex = 0x20,
		ResultIndexed = 0x40,
		ValueFromCompoundAssignment = 0x80,
		ResultDiscarded = 0x100
	}
	[Flags]
	internal enum CSharpCallFlags
	{
		None = 0,
		SimpleNameCall = 1,
		EventHookup = 2,
		ResultDiscarded = 4
	}
	internal enum CSharpConversionKind
	{
		ImplicitConversion,
		ExplicitConversion,
		ArrayCreationConversion
	}
	internal sealed class CSharpConvertBinder : ConvertBinder, ICSharpBinder
	{
		private readonly RuntimeBinder _binder;

		[ExcludeFromCodeCoverage]
		public string Name => null;

		public BindingFlag BindingFlags => (BindingFlag)0;

		public bool IsBinderThatCanHaveRefReceiver => false;

		private CSharpConversionKind ConversionKind { get; }

		public Expr DispatchPayload(RuntimeBinder runtimeBinder, ArgumentObject[] arguments, LocalVariableSymbol[] locals)
		{
			if (!base.Explicit)
			{
				return runtimeBinder.BindImplicitConversion(arguments, base.Type, locals, ConversionKind == CSharpConversionKind.ArrayCreationConversion);
			}
			return runtimeBinder.BindExplicitConversion(arguments, base.Type, locals);
		}

		public void PopulateSymbolTableWithName(Type callingType, ArgumentObject[] arguments)
		{
		}

		CSharpArgumentInfo ICSharpBinder.GetArgumentInfo(int index)
		{
			return CSharpArgumentInfo.None;
		}

		public CSharpConvertBinder(Type type, CSharpConversionKind conversionKind, bool isChecked, Type callingContext)
			: base(type, conversionKind == CSharpConversionKind.ExplicitConversion)
		{
			ConversionKind = conversionKind;
			_binder = new RuntimeBinder(callingContext, isChecked);
		}

		public override DynamicMetaObject FallbackConvert(DynamicMetaObject target, DynamicMetaObject errorSuggestion)
		{
			BinderHelper.ValidateBindArgument(target, "target");
			return BinderHelper.Bind(this, _binder, new DynamicMetaObject[1] { target }, null, errorSuggestion);
		}
	}
	internal sealed class CSharpGetIndexBinder : GetIndexBinder, ICSharpBinder
	{
		private readonly CSharpArgumentInfo[] _argumentInfo;

		private readonly RuntimeBinder _binder;

		public string Name => "$Item$";

		public BindingFlag BindingFlags => BindingFlag.BIND_RVALUEREQUIRED;

		public bool IsBinderThatCanHaveRefReceiver => true;

		public Expr DispatchPayload(RuntimeBinder runtimeBinder, ArgumentObject[] arguments, LocalVariableSymbol[] locals)
		{
			Expr optionalIndexerArguments = runtimeBinder.CreateArgumentListEXPR(arguments, locals, 1, arguments.Length);
			return runtimeBinder.BindProperty(this, arguments[0], locals[0], optionalIndexerArguments);
		}

		public void PopulateSymbolTableWithName(Type callingType, ArgumentObject[] arguments)
		{
			SymbolTable.PopulateSymbolTableWithName("$Item$", null, arguments[0].Type);
		}

		CSharpArgumentInfo ICSharpBinder.GetArgumentInfo(int index)
		{
			return _argumentInfo[index];
		}

		public CSharpGetIndexBinder(Type callingContext, IEnumerable<CSharpArgumentInfo> argumentInfo)
			: base(BinderHelper.CreateCallInfo(ref argumentInfo, 1))
		{
			_argumentInfo = argumentInfo as CSharpArgumentInfo[];
			_binder = new RuntimeBinder(callingContext);
		}

		public override DynamicMetaObject FallbackGetIndex(DynamicMetaObject target, DynamicMetaObject[] indexes, DynamicMetaObject errorSuggestion)
		{
			BinderHelper.ValidateBindArgument(target, "target");
			BinderHelper.ValidateBindArgument(indexes, "indexes");
			return BinderHelper.Bind(this, _binder, BinderHelper.Cons(target, indexes), _argumentInfo, errorSuggestion);
		}
	}
	internal sealed class CSharpGetMemberBinder : GetMemberBinder, IInvokeOnGetBinder, ICSharpBinder
	{
		private readonly CSharpArgumentInfo[] _argumentInfo;

		private readonly RuntimeBinder _binder;

		public BindingFlag BindingFlags => BindingFlag.BIND_RVALUEREQUIRED;

		public bool IsBinderThatCanHaveRefReceiver => false;

		bool IInvokeOnGetBinder.InvokeOnGet => !ResultIndexed;

		private bool ResultIndexed { get; }

		public Expr DispatchPayload(RuntimeBinder runtimeBinder, ArgumentObject[] arguments, LocalVariableSymbol[] locals)
		{
			return runtimeBinder.BindProperty(this, arguments[0], locals[0], null);
		}

		public void PopulateSymbolTableWithName(Type callingType, ArgumentObject[] arguments)
		{
			SymbolTable.PopulateSymbolTableWithName(base.Name, null, arguments[0].Type);
		}

		CSharpArgumentInfo ICSharpBinder.GetArgumentInfo(int index)
		{
			return _argumentInfo[index];
		}

		public CSharpGetMemberBinder(string name, bool resultIndexed, Type callingContext, IEnumerable<CSharpArgumentInfo> argumentInfo)
			: base(name, ignoreCase: false)
		{
			ResultIndexed = resultIndexed;
			_argumentInfo = BinderHelper.ToArray(argumentInfo);
			_binder = new RuntimeBinder(callingContext);
		}

		public override DynamicMetaObject FallbackGetMember(DynamicMetaObject target, DynamicMetaObject errorSuggestion)
		{
			BinderHelper.ValidateBindArgument(target, "target");
			return BinderHelper.Bind(this, _binder, new DynamicMetaObject[1] { target }, _argumentInfo, errorSuggestion);
		}
	}
	internal sealed class CSharpInvokeBinder : InvokeBinder, ICSharpInvokeOrInvokeMemberBinder, ICSharpBinder
	{
		private readonly CSharpCallFlags _flags;

		private readonly CSharpArgumentInfo[] _argumentInfo;

		private readonly RuntimeBinder _binder;

		public BindingFlag BindingFlags => (BindingFlag)0;

		public bool IsBinderThatCanHaveRefReceiver => true;

		bool ICSharpInvokeOrInvokeMemberBinder.StaticCall
		{
			get
			{
				if (_argumentInfo[0] != null)
				{
					return _argumentInfo[0].IsStaticType;
				}
				return false;
			}
		}

		string ICSharpBinder.Name => "Invoke";

		Type[] ICSharpInvokeOrInvokeMemberBinder.TypeArguments => Array.Empty<Type>();

		CSharpCallFlags ICSharpInvokeOrInvokeMemberBinder.Flags => _flags;

		bool ICSharpInvokeOrInvokeMemberBinder.ResultDiscarded => (_flags & CSharpCallFlags.ResultDiscarded) != 0;

		public Expr DispatchPayload(RuntimeBinder runtimeBinder, ArgumentObject[] arguments, LocalVariableSymbol[] locals)
		{
			return runtimeBinder.DispatchPayload(this, arguments, locals);
		}

		public void PopulateSymbolTableWithName(Type callingType, ArgumentObject[] arguments)
		{
			RuntimeBinder.PopulateSymbolTableWithPayloadInformation(this, callingType, arguments);
		}

		CSharpArgumentInfo ICSharpBinder.GetArgumentInfo(int index)
		{
			return _argumentInfo[index];
		}

		public CSharpInvokeBinder(CSharpCallFlags flags, Type callingContext, IEnumerable<CSharpArgumentInfo> argumentInfo)
			: base(BinderHelper.CreateCallInfo(ref argumentInfo, 1))
		{
			_flags = flags;
			_argumentInfo = argumentInfo as CSharpArgumentInfo[];
			_binder = new RuntimeBinder(callingContext);
		}

		public override DynamicMetaObject FallbackInvoke(DynamicMetaObject target, DynamicMetaObject[] args, DynamicMetaObject errorSuggestion)
		{
			BinderHelper.ValidateBindArgument(target, "target");
			BinderHelper.ValidateBindArgument(args, "args");
			return BinderHelper.Bind(this, _binder, BinderHelper.Cons(target, args), _argumentInfo, errorSuggestion);
		}
	}
	internal sealed class CSharpInvokeConstructorBinder : DynamicMetaObjectBinder, ICSharpInvokeOrInvokeMemberBinder, ICSharpBinder
	{
		private readonly CSharpArgumentInfo[] _argumentInfo;

		private readonly RuntimeBinder _binder;

		public BindingFlag BindingFlags => (BindingFlag)0;

		public bool IsBinderThatCanHaveRefReceiver => true;

		public CSharpCallFlags Flags { get; }

		public bool StaticCall => true;

		public Type[] TypeArguments => Array.Empty<Type>();

		public string Name => ".ctor";

		bool ICSharpInvokeOrInvokeMemberBinder.ResultDiscarded => false;

		public Expr DispatchPayload(RuntimeBinder runtimeBinder, ArgumentObject[] arguments, LocalVariableSymbol[] locals)
		{
			return runtimeBinder.DispatchPayload(this, arguments, locals);
		}

		public void PopulateSymbolTableWithName(Type callingType, ArgumentObject[] arguments)
		{
			RuntimeBinder.PopulateSymbolTableWithPayloadInformation(this, callingType, arguments);
		}

		CSharpArgumentInfo ICSharpBinder.GetArgumentInfo(int index)
		{
			return _argumentInfo[index];
		}

		public CSharpInvokeConstructorBinder(CSharpCallFlags flags, Type callingContext, IEnumerable<CSharpArgumentInfo> argumentInfo)
		{
			Flags = flags;
			_argumentInfo = BinderHelper.ToArray(argumentInfo);
			_binder = new RuntimeBinder(callingContext);
		}

		public override DynamicMetaObject Bind(DynamicMetaObject target, DynamicMetaObject[] args)
		{
			BinderHelper.ValidateBindArgument(target, "target");
			BinderHelper.ValidateBindArgument(args, "args");
			return BinderHelper.Bind(this, _binder, BinderHelper.Cons(target, args), _argumentInfo, null);
		}
	}
	internal sealed class CSharpInvokeMemberBinder : InvokeMemberBinder, ICSharpInvokeOrInvokeMemberBinder, ICSharpBinder
	{
		private readonly CSharpArgumentInfo[] _argumentInfo;

		private readonly RuntimeBinder _binder;

		public BindingFlag BindingFlags => (BindingFlag)0;

		public bool IsBinderThatCanHaveRefReceiver => true;

		bool ICSharpInvokeOrInvokeMemberBinder.StaticCall => _argumentInfo[0]?.IsStaticType ?? false;

		public CSharpCallFlags Flags { get; }

		public Type CallingContext { get; }

		public Type[] TypeArguments { get; }

		bool ICSharpInvokeOrInvokeMemberBinder.ResultDiscarded => (Flags & CSharpCallFlags.ResultDiscarded) != 0;

		public Expr DispatchPayload(RuntimeBinder runtimeBinder, ArgumentObject[] arguments, LocalVariableSymbol[] locals)
		{
			return runtimeBinder.DispatchPayload(this, arguments, locals);
		}

		public void PopulateSymbolTableWithName(Type callingType, ArgumentObject[] arguments)
		{
			RuntimeBinder.PopulateSymbolTableWithPayloadInformation(this, callingType, arguments);
		}

		public CSharpArgumentInfo GetArgumentInfo(int index)
		{
			return _argumentInfo[index];
		}

		public CSharpArgumentInfo[] ArgumentInfoArray()
		{
			CSharpArgumentInfo[] array = new CSharpArgumentInfo[_argumentInfo.Length];
			_argumentInfo.CopyTo(array, 0);
			return array;
		}

		public CSharpInvokeMemberBinder(CSharpCallFlags flags, string name, Type callingContext, IEnumerable<Type> typeArguments, IEnumerable<CSharpArgumentInfo> argumentInfo)
			: base(name, ignoreCase: false, BinderHelper.CreateCallInfo(ref argumentInfo, 1))
		{
			Flags = flags;
			CallingContext = callingContext;
			TypeArguments = BinderHelper.ToArray(typeArguments);
			_argumentInfo = BinderHelper.ToArray(argumentInfo);
			_binder = new RuntimeBinder(callingContext);
		}

		public override DynamicMetaObject FallbackInvokeMember(DynamicMetaObject target, DynamicMetaObject[] args, DynamicMetaObject errorSuggestion)
		{
			BinderHelper.ValidateBindArgument(target, "target");
			BinderHelper.ValidateBindArgument(args, "args");
			return BinderHelper.Bind(this, _binder, BinderHelper.Cons(target, args), _argumentInfo, errorSuggestion);
		}

		public override DynamicMetaObject FallbackInvoke(DynamicMetaObject target, DynamicMetaObject[] args, DynamicMetaObject errorSuggestion)
		{
			return new CSharpInvokeBinder(Flags, CallingContext, _argumentInfo).Defer(target, args);
		}
	}
	internal sealed class CSharpIsEventBinder : DynamicMetaObjectBinder, ICSharpBinder
	{
		private readonly RuntimeBinder _binder;

		public BindingFlag BindingFlags => (BindingFlag)0;

		public bool IsBinderThatCanHaveRefReceiver => false;

		public string Name { get; }

		public override Type ReturnType => typeof(bool);

		public Expr DispatchPayload(RuntimeBinder runtimeBinder, ArgumentObject[] arguments, LocalVariableSymbol[] locals)
		{
			return runtimeBinder.BindIsEvent(this, arguments, locals);
		}

		public void PopulateSymbolTableWithName(Type callingType, ArgumentObject[] arguments)
		{
			SymbolTable.PopulateSymbolTableWithName(Name, null, arguments[0].Info.IsStaticType ? (arguments[0].Value as Type) : arguments[0].Type);
		}

		CSharpArgumentInfo ICSharpBinder.GetArgumentInfo(int index)
		{
			return CSharpArgumentInfo.None;
		}

		public CSharpIsEventBinder(string name, Type callingContext)
		{
			Name = name;
			_binder = new RuntimeBinder(callingContext);
		}

		public override DynamicMetaObject Bind(DynamicMetaObject target, DynamicMetaObject[] args)
		{
			BinderHelper.ValidateBindArgument(target, "target");
			return BinderHelper.Bind(this, _binder, new DynamicMetaObject[1] { target }, null, null);
		}
	}
	internal sealed class CSharpSetIndexBinder : SetIndexBinder, ICSharpBinder
	{
		private readonly CSharpArgumentInfo[] _argumentInfo;

		private readonly RuntimeBinder _binder;

		public string Name => "$Item$";

		public BindingFlag BindingFlags => (BindingFlag)0;

		public bool IsBinderThatCanHaveRefReceiver => true;

		internal bool IsCompoundAssignment { get; }

		public Expr DispatchPayload(RuntimeBinder runtimeBinder, ArgumentObject[] arguments, LocalVariableSymbol[] locals)
		{
			return runtimeBinder.BindAssignment(this, arguments, locals);
		}

		public void PopulateSymbolTableWithName(Type callingType, ArgumentObject[] arguments)
		{
			SymbolTable.PopulateSymbolTableWithName("$Item$", null, arguments[0].Type);
		}

		CSharpArgumentInfo ICSharpBinder.GetArgumentInfo(int index)
		{
			return _argumentInfo[index];
		}

		public CSharpSetIndexBinder(bool isCompoundAssignment, bool isChecked, Type callingContext, IEnumerable<CSharpArgumentInfo> argumentInfo)
			: base(BinderHelper.CreateCallInfo(ref argumentInfo, 2))
		{
			IsCompoundAssignment = isCompoundAssignment;
			_argumentInfo = argumentInfo as CSharpArgumentInfo[];
			_binder = new RuntimeBinder(callingContext, isChecked);
		}

		public override DynamicMetaObject FallbackSetIndex(DynamicMetaObject target, DynamicMetaObject[] indexes, DynamicMetaObject value, DynamicMetaObject errorSuggestion)
		{
			BinderHelper.ValidateBindArgument(target, "target");
			BinderHelper.ValidateBindArgument(indexes, "indexes");
			BinderHelper.ValidateBindArgument(value, "value");
			return BinderHelper.Bind(this, _binder, BinderHelper.Cons(target, indexes, value), _argumentInfo, errorSuggestion);
		}
	}
	internal sealed class CSharpSetMemberBinder : SetMemberBinder, ICSharpBinder
	{
		private readonly CSharpArgumentInfo[] _argumentInfo;

		private readonly RuntimeBinder _binder;

		public BindingFlag BindingFlags => (BindingFlag)0;

		public bool IsBinderThatCanHaveRefReceiver => false;

		internal bool IsCompoundAssignment { get; }

		public Expr DispatchPayload(RuntimeBinder runtimeBinder, ArgumentObject[] arguments, LocalVariableSymbol[] locals)
		{
			return runtimeBinder.BindAssignment(this, arguments, locals);
		}

		public void PopulateSymbolTableWithName(Type callingType, ArgumentObject[] arguments)
		{
			SymbolTable.PopulateSymbolTableWithName(base.Name, null, arguments[0].Type);
		}

		CSharpArgumentInfo ICSharpBinder.GetArgumentInfo(int index)
		{
			return _argumentInfo[index];
		}

		public CSharpSetMemberBinder(string name, bool isCompoundAssignment, bool isChecked, Type callingContext, IEnumerable<CSharpArgumentInfo> argumentInfo)
			: base(name, ignoreCase: false)
		{
			IsCompoundAssignment = isCompoundAssignment;
			_argumentInfo = BinderHelper.ToArray(argumentInfo);
			_binder = new RuntimeBinder(callingContext, isChecked);
		}

		public override DynamicMetaObject FallbackSetMember(DynamicMetaObject target, DynamicMetaObject value, DynamicMetaObject errorSuggestion)
		{
			BinderHelper.ValidateBindArgument(target, "target");
			BinderHelper.ValidateBindArgument(value, "value");
			return BinderHelper.Bind(this, _binder, new DynamicMetaObject[2] { target, value }, _argumentInfo, errorSuggestion);
		}
	}
	internal sealed class CSharpUnaryOperationBinder : UnaryOperationBinder, ICSharpBinder
	{
		private readonly CSharpArgumentInfo[] _argumentInfo;

		private readonly RuntimeBinder _binder;

		[ExcludeFromCodeCoverage]
		public string Name => null;

		public BindingFlag BindingFlags => (BindingFlag)0;

		public bool IsBinderThatCanHaveRefReceiver => false;

		public Expr DispatchPayload(RuntimeBinder runtimeBinder, ArgumentObject[] arguments, LocalVariableSymbol[] locals)
		{
			return runtimeBinder.BindUnaryOperation(this, arguments, locals);
		}

		public void PopulateSymbolTableWithName(Type callingType, ArgumentObject[] arguments)
		{
			SymbolTable.PopulateSymbolTableWithName(base.Operation.GetCLROperatorName(), null, arguments[0].Type);
		}

		CSharpArgumentInfo ICSharpBinder.GetArgumentInfo(int index)
		{
			return _argumentInfo[index];
		}

		public CSharpUnaryOperationBinder(ExpressionType operation, bool isChecked, Type callingContext, IEnumerable<CSharpArgumentInfo> argumentInfo)
			: base(operation)
		{
			_argumentInfo = BinderHelper.ToArray(argumentInfo);
			_binder = new RuntimeBinder(callingContext, isChecked);
		}

		public override DynamicMetaObject FallbackUnaryOperation(DynamicMetaObject target, DynamicMetaObject errorSuggestion)
		{
			BinderHelper.ValidateBindArgument(target, "target");
			return BinderHelper.Bind(this, _binder, new DynamicMetaObject[1] { target }, _argumentInfo, errorSuggestion);
		}
	}
	internal static class Error
	{
		internal static Exception InternalCompilerError()
		{
			return new RuntimeBinderInternalCompilerException("An unexpected exception occurred while binding a dynamic operation");
		}

		internal static Exception BindPropertyFailedMethodGroup(object p0)
		{
			return new RuntimeBinderException(global::SR.Format("The name '{0}' is bound to a method and cannot be used like a property", p0));
		}

		internal static Exception BindPropertyFailedEvent(object p0)
		{
			return new RuntimeBinderException(global::SR.Format("The event '{0}' can only appear on the left hand side of +", p0));
		}

		internal static Exception BindInvokeFailedNonDelegate()
		{
			return new RuntimeBinderException("Cannot invoke a non-delegate type");
		}

		internal static Exception BindStaticRequiresType(string paramName)
		{
			return new ArgumentException("The first argument to dynamically-bound static or constructor call must be a Type", paramName);
		}

		internal static Exception NullReferenceOnMemberException()
		{
			return new RuntimeBinderException("Cannot perform runtime binding on a null reference");
		}

		internal static Exception BindCallToConditionalMethod(object p0)
		{
			return new RuntimeBinderException(global::SR.Format("Cannot dynamically invoke method '{0}' because it has a Conditional attribute", p0));
		}

		internal static Exception BindToVoidMethodButExpectResult()
		{
			return new RuntimeBinderException("Cannot implicitly convert type 'void' to 'object'");
		}

		internal static Exception ArgumentNull(string paramName)
		{
			return new ArgumentNullException(paramName);
		}

		internal static Exception DynamicArgumentNeedsValue(string paramName)
		{
			return new ArgumentException("The runtime binder cannot bind a metaobject without a value", paramName);
		}
	}
	internal sealed class ExpressionTreeCallRewriter : ExprVisitorBase
	{
		private sealed class ExpressionExpr : Expr
		{
			public readonly Expression Expression;

			public ExpressionExpr(Expression e)
				: base(ExpressionKind.NoOp)
			{
				Expression = e;
			}
		}

		private readonly Dictionary<ExprCall, Expression> _DictionaryOfParameters;

		private readonly Expression[] _ListOfParameters;

		private int _currentParameterIndex;

		private ExpressionTreeCallRewriter(Expression[] listOfParameters)
		{
			_DictionaryOfParameters = new Dictionary<ExprCall, Expression>();
			_ListOfParameters = listOfParameters;
		}

		public static Expression Rewrite(ExprBinOp binOp, Expression[] listOfParameters)
		{
			ExpressionTreeCallRewriter expressionTreeCallRewriter = new ExpressionTreeCallRewriter(listOfParameters);
			expressionTreeCallRewriter.Visit(binOp.OptionalLeftChild);
			ExprCall pExpr = (ExprCall)binOp.OptionalRightChild;
			return (expressionTreeCallRewriter.Visit(pExpr) as ExpressionExpr).Expression;
		}

		protected override Expr VisitSAVE(ExprBinOp pExpr)
		{
			ExprCall key = (ExprCall)pExpr.OptionalLeftChild;
			Expression value = _ListOfParameters[_currentParameterIndex++];
			_DictionaryOfParameters.Add(key, value);
			return null;
		}

		protected override Expr VisitCALL(ExprCall pExpr)
		{
			if (pExpr.PredefinedMethod == PREDEFMETH.PM_COUNT)
			{
				return pExpr;
			}
			Expression e;
			switch (pExpr.PredefinedMethod)
			{
			case PREDEFMETH.PM_EXPRESSION_LAMBDA:
				return GenerateLambda(pExpr);
			case PREDEFMETH.PM_EXPRESSION_CALL:
				e = GenerateCall(pExpr);
				break;
			case PREDEFMETH.PM_EXPRESSION_ARRAYINDEX:
			case PREDEFMETH.PM_EXPRESSION_ARRAYINDEX2:
				e = GenerateArrayIndex(pExpr);
				break;
			case PREDEFMETH.PM_EXPRESSION_CONVERT:
			case PREDEFMETH.PM_EXPRESSION_CONVERT_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_CONVERTCHECKED:
			case PREDEFMETH.PM_EXPRESSION_CONVERTCHECKED_USER_DEFINED:
				e = GenerateConvert(pExpr);
				break;
			case PREDEFMETH.PM_EXPRESSION_PROPERTY:
				e = GenerateProperty(pExpr);
				break;
			case PREDEFMETH.PM_EXPRESSION_FIELD:
				e = GenerateField(pExpr);
				break;
			case PREDEFMETH.PM_EXPRESSION_INVOKE:
				e = GenerateInvoke(pExpr);
				break;
			case PREDEFMETH.PM_EXPRESSION_NEW:
				e = GenerateNew(pExpr);
				break;
			case PREDEFMETH.PM_EXPRESSION_ADD:
			case PREDEFMETH.PM_EXPRESSION_ADDCHECKED:
			case PREDEFMETH.PM_EXPRESSION_AND:
			case PREDEFMETH.PM_EXPRESSION_ANDALSO:
			case PREDEFMETH.PM_EXPRESSION_DIVIDE:
			case PREDEFMETH.PM_EXPRESSION_EQUAL:
			case PREDEFMETH.PM_EXPRESSION_EXCLUSIVEOR:
			case PREDEFMETH.PM_EXPRESSION_GREATERTHAN:
			case PREDEFMETH.PM_EXPRESSION_GREATERTHANOREQUAL:
			case PREDEFMETH.PM_EXPRESSION_LEFTSHIFT:
			case PREDEFMETH.PM_EXPRESSION_LESSTHAN:
			case PREDEFMETH.PM_EXPRESSION_LESSTHANOREQUAL:
			case PREDEFMETH.PM_EXPRESSION_MODULO:
			case PREDEFMETH.PM_EXPRESSION_MULTIPLY:
			case PREDEFMETH.PM_EXPRESSION_MULTIPLYCHECKED:
			case PREDEFMETH.PM_EXPRESSION_NOTEQUAL:
			case PREDEFMETH.PM_EXPRESSION_OR:
			case PREDEFMETH.PM_EXPRESSION_ORELSE:
			case PREDEFMETH.PM_EXPRESSION_RIGHTSHIFT:
			case PREDEFMETH.PM_EXPRESSION_SUBTRACT:
			case PREDEFMETH.PM_EXPRESSION_SUBTRACTCHECKED:
				e = GenerateBinaryOperator(pExpr);
				break;
			case PREDEFMETH.PM_EXPRESSION_ADD_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_ADDCHECKED_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_AND_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_ANDALSO_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_DIVIDE_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_EQUAL_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_EXCLUSIVEOR_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_GREATERTHAN_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_GREATERTHANOREQUAL_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_LEFTSHIFT_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_LESSTHAN_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_LESSTHANOREQUAL_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_MODULO_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_MULTIPLY_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_MULTIPLYCHECKED_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_NOTEQUAL_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_OR_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_ORELSE_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_RIGHTSHIFT_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_SUBTRACT_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_SUBTRACTCHECKED_USER_DEFINED:
				e = GenerateUserDefinedBinaryOperator(pExpr);
				break;
			case PREDEFMETH.PM_EXPRESSION_NEGATE:
			case PREDEFMETH.PM_EXPRESSION_NEGATECHECKED:
			case PREDEFMETH.PM_EXPRESSION_NOT:
				e = GenerateUnaryOperator(pExpr);
				break;
			case PREDEFMETH.PM_EXPRESSION_UNARYPLUS_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_NEGATE_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_NEGATECHECKED_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_NOT_USER_DEFINED:
				e = GenerateUserDefinedUnaryOperator(pExpr);
				break;
			case PREDEFMETH.PM_EXPRESSION_CONSTANT_OBJECT_TYPE:
				e = GenerateConstantType(pExpr);
				break;
			case PREDEFMETH.PM_EXPRESSION_ASSIGN:
				e = GenerateAssignment(pExpr);
				break;
			default:
				throw Error.InternalCompilerError();
			}
			return new ExpressionExpr(e);
		}

		protected override Expr VisitWRAP(ExprWrap pExpr)
		{
			return new ExpressionExpr(GetExpression(pExpr));
		}

		private Expr GenerateLambda(ExprCall pExpr)
		{
			return Visit(((ExprList)pExpr.OptionalArguments).OptionalElement);
		}

		private Expression GenerateCall(ExprCall pExpr)
		{
			ExprList exprList = (ExprList)pExpr.OptionalArguments;
			ExprMethodInfo exprMethodInfo;
			ExprArrayInit arrinit;
			if (exprList.OptionalNextListNode is ExprList exprList2)
			{
				exprMethodInfo = (ExprMethodInfo)exprList2.OptionalElement;
				arrinit = (ExprArrayInit)exprList2.OptionalNextListNode;
			}
			else
			{
				exprMethodInfo = (ExprMethodInfo)exprList.OptionalNextListNode;
				arrinit = null;
			}
			Expression instance = null;
			MethodInfo methodInfo = exprMethodInfo.MethodInfo;
			Expression[] argumentsFromArrayInit = GetArgumentsFromArrayInit(arrinit);
			if (methodInfo == null)
			{
				throw Error.InternalCompilerError();
			}
			if (!methodInfo.IsStatic)
			{
				instance = GetExpression(((ExprList)pExpr.OptionalArguments).OptionalElement);
			}
			return Expression.Call(instance, methodInfo, argumentsFromArrayInit);
		}

		private Expression GenerateArrayIndex(ExprCall pExpr)
		{
			ExprList exprList = (ExprList)pExpr.OptionalArguments;
			Expression expression = GetExpression(exprList.OptionalElement);
			Expression[] indexes = ((pExpr.PredefinedMethod != PREDEFMETH.PM_EXPRESSION_ARRAYINDEX) ? GetArgumentsFromArrayInit((ExprArrayInit)exprList.OptionalNextListNode) : new Expression[1] { GetExpression(exprList.OptionalNextListNode) });
			return Expression.ArrayAccess(expression, indexes);
		}

		private Expression GenerateConvert(ExprCall pExpr)
		{
			PREDEFMETH predefinedMethod = pExpr.PredefinedMethod;
			Expression expression;
			Type associatedSystemType;
			if (predefinedMethod == PREDEFMETH.PM_EXPRESSION_CONVERT_USER_DEFINED || predefinedMethod == PREDEFMETH.PM_EXPRESSION_CONVERTCHECKED_USER_DEFINED)
			{
				ExprList exprList = (ExprList)pExpr.OptionalArguments;
				ExprList exprList2 = (ExprList)exprList.OptionalNextListNode;
				expression = GetExpression(exprList.OptionalElement);
				associatedSystemType = ((ExprTypeOf)exprList2.OptionalElement).SourceType.AssociatedSystemType;
				if (expression.Type.MakeByRefType() == associatedSystemType)
				{
					return expression;
				}
				MethodInfo methodInfo = ((ExprMethodInfo)exprList2.OptionalNextListNode).MethodInfo;
				if (predefinedMethod == PREDEFMETH.PM_EXPRESSION_CONVERT_USER_DEFINED)
				{
					return Expression.Convert(expression, associatedSystemType, methodInfo);
				}
				return Expression.ConvertChecked(expression, associatedSystemType, methodInfo);
			}
			ExprList exprList3 = (ExprList)pExpr.OptionalArguments;
			expression = GetExpression(exprList3.OptionalElement);
			associatedSystemType = ((ExprTypeOf)exprList3.OptionalNextListNode).SourceType.AssociatedSystemType;
			if (expression.Type.MakeByRefType() == associatedSystemType)
			{
				return expression;
			}
			if ((pExpr.Flags & EXPRFLAG.EXF_USERCALLABLE) != 0)
			{
				return Expression.Unbox(expression, associatedSystemType);
			}
			if (predefinedMethod == PREDEFMETH.PM_EXPRESSION_CONVERT)
			{
				return Expression.Convert(expression, associatedSystemType);
			}
			return Expression.ConvertChecked(expression, associatedSystemType);
		}

		private Expression GenerateProperty(ExprCall pExpr)
		{
			ExprList obj = (ExprList)pExpr.OptionalArguments;
			Expr optionalElement = obj.OptionalElement;
			Expr optionalNextListNode = obj.OptionalNextListNode;
			ExprPropertyInfo exprPropertyInfo;
			ExprArrayInit exprArrayInit;
			if (optionalNextListNode is ExprList exprList)
			{
				exprPropertyInfo = exprList.OptionalElement as ExprPropertyInfo;
				exprArrayInit = exprList.OptionalNextListNode as ExprArrayInit;
			}
			else
			{
				exprPropertyInfo = optionalNextListNode as ExprPropertyInfo;
				exprArrayInit = null;
			}
			PropertyInfo propertyInfo = exprPropertyInfo.PropertyInfo;
			if (propertyInfo == null)
			{
				throw Error.InternalCompilerError();
			}
			if (exprArrayInit == null)
			{
				return Expression.Property(GetExpression(optionalElement), propertyInfo);
			}
			return Expression.Property(GetExpression(optionalElement), propertyInfo, GetArgumentsFromArrayInit(exprArrayInit));
		}

		private Expression GenerateField(ExprCall pExpr)
		{
			ExprList exprList = (ExprList)pExpr.OptionalArguments;
			ExprFieldInfo obj = (ExprFieldInfo)exprList.OptionalNextListNode;
			Type type = obj.FieldType.AssociatedSystemType;
			FieldInfo fieldInfo = obj.Field.AssociatedFieldInfo;
			if (!type.IsGenericType && !type.IsNested)
			{
				type = fieldInfo.DeclaringType;
			}
			if (type.IsGenericType)
			{
				fieldInfo = type.GetField(fieldInfo.Name, BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
			}
			return Expression.Field(GetExpression(exprList.OptionalElement), fieldInfo);
		}

		private Expression GenerateInvoke(ExprCall pExpr)
		{
			ExprList exprList = (ExprList)pExpr.OptionalArguments;
			return Expression.Invoke(GetExpression(exprList.OptionalElement), GetArgumentsFromArrayInit(exprList.OptionalNextListNode as ExprArrayInit));
		}

		private Expression GenerateNew(ExprCall pExpr)
		{
			ExprList exprList = (ExprList)pExpr.OptionalArguments;
			ConstructorInfo constructorInfo = ((ExprMethodInfo)exprList.OptionalElement).ConstructorInfo;
			Expression[] argumentsFromArrayInit = GetArgumentsFromArrayInit(exprList.OptionalNextListNode as ExprArrayInit);
			return Expression.New(constructorInfo, argumentsFromArrayInit);
		}

		private static Expression GenerateConstantType(ExprCall pExpr)
		{
			ExprList exprList = (ExprList)pExpr.OptionalArguments;
			return Expression.Constant(exprList.OptionalElement.Object, ((ExprTypeOf)exprList.OptionalNextListNode).SourceType.AssociatedSystemType);
		}

		private Expression GenerateAssignment(ExprCall pExpr)
		{
			ExprList exprList = (ExprList)pExpr.OptionalArguments;
			return Expression.Assign(GetExpression(exprList.OptionalElement), GetExpression(exprList.OptionalNextListNode));
		}

		private Expression GenerateBinaryOperator(ExprCall pExpr)
		{
			ExprList exprList = (ExprList)pExpr.OptionalArguments;
			Expression expression = GetExpression(exprList.OptionalElement);
			Expression expression2 = GetExpression(exprList.OptionalNextListNode);
			return pExpr.PredefinedMethod switch
			{
				PREDEFMETH.PM_EXPRESSION_ADD => Expression.Add(expression, expression2), 
				PREDEFMETH.PM_EXPRESSION_AND => Expression.And(expression, expression2), 
				PREDEFMETH.PM_EXPRESSION_DIVIDE => Expression.Divide(expression, expression2), 
				PREDEFMETH.PM_EXPRESSION_EQUAL => Expression.Equal(expression, expression2), 
				PREDEFMETH.PM_EXPRESSION_EXCLUSIVEOR => Expression.ExclusiveOr(expression, expression2), 
				PREDEFMETH.PM_EXPRESSION_GREATERTHAN => Expression.GreaterThan(expression, expression2), 
				PREDEFMETH.PM_EXPRESSION_GREATERTHANOREQUAL => Expression.GreaterThanOrEqual(expression, expression2), 
				PREDEFMETH.PM_EXPRESSION_LEFTSHIFT => Expression.LeftShift(expression, expression2), 
				PREDEFMETH.PM_EXPRESSION_LESSTHAN => Expression.LessThan(expression, expression2), 
				PREDEFMETH.PM_EXPRESSION_LESSTHANOREQUAL => Expression.LessThanOrEqual(expression, expression2), 
				PREDEFMETH.PM_EXPRESSION_MODULO => Expression.Modulo(expression, expression2), 
				PREDEFMETH.PM_EXPRESSION_MULTIPLY => Expression.Multiply(expression, expression2), 
				PREDEFMETH.PM_EXPRESSION_NOTEQUAL => Expression.NotEqual(expression, expression2), 
				PREDEFMETH.PM_EXPRESSION_OR => Expression.Or(expression, expression2), 
				PREDEFMETH.PM_EXPRESSION_RIGHTSHIFT => Expression.RightShift(expression, expression2), 
				PREDEFMETH.PM_EXPRESSION_SUBTRACT => Expression.Subtract(expression, expression2), 
				PREDEFMETH.PM_EXPRESSION_ORELSE => Expression.OrElse(expression, expression2), 
				PREDEFMETH.PM_EXPRESSION_ANDALSO => Expression.AndAlso(expression, expression2), 
				PREDEFMETH.PM_EXPRESSION_ADDCHECKED => Expression.AddChecked(expression, expression2), 
				PREDEFMETH.PM_EXPRESSION_MULTIPLYCHECKED => Expression.MultiplyChecked(expression, expression2), 
				PREDEFMETH.PM_EXPRESSION_SUBTRACTCHECKED => Expression.SubtractChecked(expression, expression2), 
				_ => throw Error.InternalCompilerError(), 
			};
		}

		private Expression GenerateUserDefinedBinaryOperator(ExprCall pExpr)
		{
			ExprList exprList = (ExprList)pExpr.OptionalArguments;
			Expression expression = GetExpression(exprList.OptionalElement);
			Expression expression2 = GetExpression(((ExprList)exprList.OptionalNextListNode).OptionalElement);
			exprList = (ExprList)exprList.OptionalNextListNode;
			bool liftToNull = false;
			MethodInfo methodInfo;
			if (exprList.OptionalNextListNode is ExprList exprList2)
			{
				liftToNull = ((ExprConstant)exprList2.OptionalElement).Val.Int32Val == 1;
				methodInfo = ((ExprMethodInfo)exprList2.OptionalNextListNode).MethodInfo;
			}
			else
			{
				methodInfo = ((ExprMethodInfo)exprList.OptionalNextListNode).MethodInfo;
			}
			return pExpr.PredefinedMethod switch
			{
				PREDEFMETH.PM_EXPRESSION_ADD_USER_DEFINED => Expression.Add(expression, expression2, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_AND_USER_DEFINED => Expression.And(expression, expression2, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_DIVIDE_USER_DEFINED => Expression.Divide(expression, expression2, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_EQUAL_USER_DEFINED => Expression.Equal(expression, expression2, liftToNull, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_EXCLUSIVEOR_USER_DEFINED => Expression.ExclusiveOr(expression, expression2, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_GREATERTHAN_USER_DEFINED => Expression.GreaterThan(expression, expression2, liftToNull, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_GREATERTHANOREQUAL_USER_DEFINED => Expression.GreaterThanOrEqual(expression, expression2, liftToNull, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_LEFTSHIFT_USER_DEFINED => Expression.LeftShift(expression, expression2, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_LESSTHAN_USER_DEFINED => Expression.LessThan(expression, expression2, liftToNull, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_LESSTHANOREQUAL_USER_DEFINED => Expression.LessThanOrEqual(expression, expression2, liftToNull, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_MODULO_USER_DEFINED => Expression.Modulo(expression, expression2, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_MULTIPLY_USER_DEFINED => Expression.Multiply(expression, expression2, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_NOTEQUAL_USER_DEFINED => Expression.NotEqual(expression, expression2, liftToNull, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_OR_USER_DEFINED => Expression.Or(expression, expression2, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_RIGHTSHIFT_USER_DEFINED => Expression.RightShift(expression, expression2, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_SUBTRACT_USER_DEFINED => Expression.Subtract(expression, expression2, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_ORELSE_USER_DEFINED => Expression.OrElse(expression, expression2, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_ANDALSO_USER_DEFINED => Expression.AndAlso(expression, expression2, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_ADDCHECKED_USER_DEFINED => Expression.AddChecked(expression, expression2, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_MULTIPLYCHECKED_USER_DEFINED => Expression.MultiplyChecked(expression, expression2, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_SUBTRACTCHECKED_USER_DEFINED => Expression.SubtractChecked(expression, expression2, methodInfo), 
				_ => throw Error.InternalCompilerError(), 
			};
		}

		private Expression GenerateUnaryOperator(ExprCall pExpr)
		{
			PREDEFMETH predefinedMethod = pExpr.PredefinedMethod;
			Expression expression = GetExpression(pExpr.OptionalArguments);
			return predefinedMethod switch
			{
				PREDEFMETH.PM_EXPRESSION_NOT => Expression.Not(expression), 
				PREDEFMETH.PM_EXPRESSION_NEGATE => Expression.Negate(expression), 
				PREDEFMETH.PM_EXPRESSION_NEGATECHECKED => Expression.NegateChecked(expression), 
				_ => throw Error.InternalCompilerError(), 
			};
		}

		private Expression GenerateUserDefinedUnaryOperator(ExprCall pExpr)
		{
			PREDEFMETH predefinedMethod = pExpr.PredefinedMethod;
			ExprList exprList = (ExprList)pExpr.OptionalArguments;
			Expression expression = GetExpression(exprList.OptionalElement);
			MethodInfo methodInfo = ((ExprMethodInfo)exprList.OptionalNextListNode).MethodInfo;
			return predefinedMethod switch
			{
				PREDEFMETH.PM_EXPRESSION_NOT_USER_DEFINED => Expression.Not(expression, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_NEGATE_USER_DEFINED => Expression.Negate(expression, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_UNARYPLUS_USER_DEFINED => Expression.UnaryPlus(expression, methodInfo), 
				PREDEFMETH.PM_EXPRESSION_NEGATECHECKED_USER_DEFINED => Expression.NegateChecked(expression, methodInfo), 
				_ => throw Error.InternalCompilerError(), 
			};
		}

		private Expression GetExpression(Expr pExpr)
		{
			if (pExpr is ExprWrap exprWrap)
			{
				return _DictionaryOfParameters[(ExprCall)exprWrap.OptionalExpression];
			}
			if (pExpr is ExprConstant)
			{
				return null;
			}
			ExprCall exprCall = (ExprCall)pExpr;
			switch (exprCall.PredefinedMethod)
			{
			case PREDEFMETH.PM_EXPRESSION_CALL:
				return GenerateCall(exprCall);
			case PREDEFMETH.PM_EXPRESSION_CONVERT:
			case PREDEFMETH.PM_EXPRESSION_CONVERT_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_CONVERTCHECKED:
			case PREDEFMETH.PM_EXPRESSION_CONVERTCHECKED_USER_DEFINED:
				return GenerateConvert(exprCall);
			case PREDEFMETH.PM_EXPRESSION_NEWARRAYINIT:
			{
				ExprList exprList = (ExprList)exprCall.OptionalArguments;
				return Expression.NewArrayInit(((ExprTypeOf)exprList.OptionalElement).SourceType.AssociatedSystemType, GetArgumentsFromArrayInit((ExprArrayInit)exprList.OptionalNextListNode));
			}
			case PREDEFMETH.PM_EXPRESSION_ARRAYINDEX:
			case PREDEFMETH.PM_EXPRESSION_ARRAYINDEX2:
				return GenerateArrayIndex(exprCall);
			case PREDEFMETH.PM_EXPRESSION_NEW:
				return GenerateNew(exprCall);
			case PREDEFMETH.PM_EXPRESSION_PROPERTY:
				return GenerateProperty(exprCall);
			case PREDEFMETH.PM_EXPRESSION_FIELD:
				return GenerateField(exprCall);
			case PREDEFMETH.PM_EXPRESSION_CONSTANT_OBJECT_TYPE:
				return GenerateConstantType(exprCall);
			case PREDEFMETH.PM_EXPRESSION_ASSIGN:
				return GenerateAssignment(exprCall);
			case PREDEFMETH.PM_EXPRESSION_ADD:
			case PREDEFMETH.PM_EXPRESSION_ADDCHECKED:
			case PREDEFMETH.PM_EXPRESSION_AND:
			case PREDEFMETH.PM_EXPRESSION_ANDALSO:
			case PREDEFMETH.PM_EXPRESSION_DIVIDE:
			case PREDEFMETH.PM_EXPRESSION_EQUAL:
			case PREDEFMETH.PM_EXPRESSION_EXCLUSIVEOR:
			case PREDEFMETH.PM_EXPRESSION_GREATERTHAN:
			case PREDEFMETH.PM_EXPRESSION_GREATERTHANOREQUAL:
			case PREDEFMETH.PM_EXPRESSION_LEFTSHIFT:
			case PREDEFMETH.PM_EXPRESSION_LESSTHAN:
			case PREDEFMETH.PM_EXPRESSION_LESSTHANOREQUAL:
			case PREDEFMETH.PM_EXPRESSION_MODULO:
			case PREDEFMETH.PM_EXPRESSION_MULTIPLY:
			case PREDEFMETH.PM_EXPRESSION_MULTIPLYCHECKED:
			case PREDEFMETH.PM_EXPRESSION_NOTEQUAL:
			case PREDEFMETH.PM_EXPRESSION_OR:
			case PREDEFMETH.PM_EXPRESSION_ORELSE:
			case PREDEFMETH.PM_EXPRESSION_RIGHTSHIFT:
			case PREDEFMETH.PM_EXPRESSION_SUBTRACT:
			case PREDEFMETH.PM_EXPRESSION_SUBTRACTCHECKED:
				return GenerateBinaryOperator(exprCall);
			case PREDEFMETH.PM_EXPRESSION_ADD_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_ADDCHECKED_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_AND_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_ANDALSO_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_DIVIDE_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_EQUAL_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_EXCLUSIVEOR_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_GREATERTHAN_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_GREATERTHANOREQUAL_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_LEFTSHIFT_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_LESSTHAN_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_LESSTHANOREQUAL_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_MODULO_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_MULTIPLY_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_MULTIPLYCHECKED_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_NOTEQUAL_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_OR_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_ORELSE_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_RIGHTSHIFT_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_SUBTRACT_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_SUBTRACTCHECKED_USER_DEFINED:
				return GenerateUserDefinedBinaryOperator(exprCall);
			case PREDEFMETH.PM_EXPRESSION_NEGATE:
			case PREDEFMETH.PM_EXPRESSION_NEGATECHECKED:
			case PREDEFMETH.PM_EXPRESSION_NOT:
				return GenerateUnaryOperator(exprCall);
			case PREDEFMETH.PM_EXPRESSION_UNARYPLUS_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_NEGATE_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_NEGATECHECKED_USER_DEFINED:
			case PREDEFMETH.PM_EXPRESSION_NOT_USER_DEFINED:
				return GenerateUserDefinedUnaryOperator(exprCall);
			default:
				throw Error.InternalCompilerError();
			}
		}

		private Expression[] GetArgumentsFromArrayInit(ExprArrayInit arrinit)
		{
			List<Expression> list = new List<Expression>();
			if (arrinit != null)
			{
				Expr expr = arrinit.OptionalArguments;
				while (expr != null)
				{
					Expr pExpr;
					if (expr is ExprList exprList)
					{
						pExpr = exprList.OptionalElement;
						expr = exprList.OptionalNextListNode;
					}
					else
					{
						pExpr = expr;
						expr = null;
					}
					list.Add(GetExpression(pExpr));
				}
			}
			return list.ToArray();
		}
	}
	internal interface ICSharpBinder
	{
		bool IsBinderThatCanHaveRefReceiver { get; }

		BindingFlag BindingFlags { get; }

		string Name { get; }

		Type ReturnType { get; }

		CSharpArgumentInfo GetArgumentInfo(int index);

		void PopulateSymbolTableWithName(Type callingType, ArgumentObject[] arguments);

		Expr DispatchPayload(RuntimeBinder runtimeBinder, ArgumentObject[] arguments, LocalVariableSymbol[] locals);
	}
	internal interface ICSharpInvokeOrInvokeMemberBinder : ICSharpBinder
	{
		bool StaticCall { get; }

		bool ResultDiscarded { get; }

		CSharpCallFlags Flags { get; }

		Type[] TypeArguments { get; }
	}
	internal readonly struct RuntimeBinder
	{
		private static readonly object s_bindLock = new object();

		private readonly ExpressionBinder _binder;

		public RuntimeBinder(Type contextType, bool isChecked = false)
		{
			AggregateSymbol context;
			if (contextType != null)
			{
				lock (s_bindLock)
				{
					context = ((AggregateType)SymbolTable.GetCTypeFromType(contextType)).OwningAggregate;
				}
			}
			else
			{
				context = null;
			}
			_binder = new ExpressionBinder(new BindingContext(context, isChecked));
		}

		public Expression Bind(ICSharpBinder payload, Expression[] parameters, DynamicMetaObject[] args, out DynamicMetaObject deferredBinding)
		{
			lock (s_bindLock)
			{
				return BindCore(payload, parameters, args, out deferredBinding);
			}
		}

		private Expression BindCore(ICSharpBinder payload, Expression[] parameters, DynamicMetaObject[] args, out DynamicMetaObject deferredBinding)
		{
			ArgumentObject[] array = CreateArgumentArray(payload, parameters, args);
			payload.PopulateSymbolTableWithName(array[0].Type, array);
			AddConversionsForArguments(array);
			Scope pScope = SymFactory.CreateScope();
			LocalVariableSymbol[] locals = PopulateLocalScope(payload, pScope, array, parameters);
			if (DeferBinding(payload, array, args, locals, out deferredBinding))
			{
				return null;
			}
			Expr pResult = payload.DispatchPayload(this, array, locals);
			return CreateExpressionTreeFromResult(parameters, pScope, pResult);
		}

		[Conditional("DEBUG")]
		internal static void EnsureLockIsTaken()
		{
		}

		private bool DeferBinding(ICSharpBinder payload, ArgumentObject[] arguments, DynamicMetaObject[] args, LocalVariableSymbol[] locals, out DynamicMetaObject deferredBinding)
		{
			if (payload is CSharpInvokeMemberBinder cSharpInvokeMemberBinder)
			{
				Type[] typeArguments = cSharpInvokeMemberBinder.TypeArguments;
				int arity = ((typeArguments != null) ? typeArguments.Length : 0);
				MemberLookup mem = new MemberLookup();
				Expr callingObject = CreateCallingObjectForCall(cSharpInvokeMemberBinder, arguments, locals);
				SymWithType symWithType = SymbolTable.LookupMember(cSharpInvokeMemberBinder.Name, callingObject, _binder.Context.ContextForMemberLookup, arity, mem, (cSharpInvokeMemberBinder.Flags & CSharpCallFlags.EventHookup) != 0, requireInvocable: true);
				if (symWithType != null && symWithType.Sym.getKind() != SYMKIND.SK_MethodSymbol)
				{
					CSharpGetMemberBinder cSharpGetMemberBinder = new CSharpGetMemberBinder(cSharpInvokeMemberBinder.Name, resultIndexed: false, cSharpInvokeMemberBinder.CallingContext, new CSharpArgumentInfo[1] { cSharpInvokeMemberBinder.GetArgumentInfo(0) });
					CSharpArgumentInfo[] array = cSharpInvokeMemberBinder.ArgumentInfoArray();
					array[0] = CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null);
					CSharpInvokeBinder cSharpInvokeBinder = new CSharpInvokeBinder(cSharpInvokeMemberBinder.Flags, cSharpInvokeMemberBinder.CallingContext, array);
					DynamicMetaObject[] array2 = new DynamicMetaObject[args.Length - 1];
					Array.Copy(args, 1, array2, 0, args.Length - 1);
					deferredBinding = cSharpInvokeBinder.Defer(cSharpGetMemberBinder.Defer(args[0]), array2);
					return true;
				}
			}
			deferredBinding = null;
			return false;
		}

		private static Expression CreateExpressionTreeFromResult(Expression[] parameters, Scope pScope, Expr pResult)
		{
			return ExpressionTreeCallRewriter.Rewrite(ExpressionTreeRewriter.Rewrite(GenerateBoundLambda(pScope, pResult)), parameters);
		}

		private Type GetArgumentType(ICSharpBinder p, CSharpArgumentInfo argInfo, Expression param, DynamicMetaObject arg, int index)
		{
			Type type = (argInfo.UseCompileTimeType ? param.Type : arg.LimitType);
			if (argInfo.IsByRefOrOut)
			{
				if (index != 0 || !p.IsBinderThatCanHaveRefReceiver)
				{
					type = type.MakeByRefType();
				}
			}
			else if (!argInfo.UseCompileTimeType)
			{
				CType cTypeFromType = SymbolTable.GetCTypeFromType(type);
				type = TypeManager.GetBestAccessibleType(_binder.Context.ContextForMemberLookup, cTypeFromType).AssociatedSystemType;
			}
			return type;
		}

		private ArgumentObject[] CreateArgumentArray(ICSharpBinder payload, Expression[] parameters, DynamicMetaObject[] args)
		{
			ArgumentObject[] array = new ArgumentObject[parameters.Length];
			for (int i = 0; i < parameters.Length; i++)
			{
				CSharpArgumentInfo argumentInfo = payload.GetArgumentInfo(i);
				array[i] = new ArgumentObject(args[i].Value, argumentInfo, GetArgumentType(payload, argumentInfo, parameters[i], args[i], i));
			}
			return array;
		}

		internal static void PopulateSymbolTableWithPayloadInformation(ICSharpInvokeOrInvokeMemberBinder callOrInvoke, Type callingType, ArgumentObject[] arguments)
		{
			Type type;
			if (callOrInvoke.StaticCall)
			{
				type = arguments[0].Value as Type;
				if (type == null)
				{
					throw Error.BindStaticRequiresType(arguments[0].Info.Name);
				}
			}
			else
			{
				type = callingType;
			}
			SymbolTable.PopulateSymbolTableWithName(callOrInvoke.Name, callOrInvoke.TypeArguments, type);
			if (callOrInvoke.Name.StartsWith("set_", StringComparison.Ordinal) || callOrInvoke.Name.StartsWith("get_", StringComparison.Ordinal))
			{
				SymbolTable.PopulateSymbolTableWithName(callOrInvoke.Name.Substring(4), callOrInvoke.TypeArguments, type);
			}
		}

		private static void AddConversionsForArguments(ArgumentObject[] arguments)
		{
			for (int i = 0; i < arguments.Length; i++)
			{
				SymbolTable.AddConversionsForType(arguments[i].Type);
			}
		}

		internal ExprWithArgs DispatchPayload(ICSharpInvokeOrInvokeMemberBinder payload, ArgumentObject[] arguments, LocalVariableSymbol[] locals)
		{
			return BindCall(payload, CreateCallingObjectForCall(payload, arguments, locals), arguments, locals);
		}

		private static LocalVariableSymbol[] PopulateLocalScope(ICSharpBinder payload, Scope pScope, ArgumentObject[] arguments, Expression[] parameterExpressions)
		{
			LocalVariableSymbol[] array = new LocalVariableSymbol[parameterExpressions.Length];
			for (int i = 0; i < parameterExpressions.Length; i++)
			{
				Expression expression = parameterExpressions[i];
				CType cType = SymbolTable.GetCTypeFromType(expression.Type);
				if ((i != 0 || !payload.IsBinderThatCanHaveRefReceiver) && expression is ParameterExpression { IsByRef: not false })
				{
					CSharpArgumentInfo info = arguments[i].Info;
					if (info.IsByRefOrOut)
					{
						cType = TypeManager.GetParameterModifier(cType, info.IsOut);
					}
				}
				LocalVariableSymbol localVariableSymbol = SymFactory.CreateLocalVar(NameManager.Add("p" + i), pScope, cType);
				array[i] = localVariableSymbol;
			}
			return array;
		}

		private static ExprBoundLambda GenerateBoundLambda(Scope pScope, Expr call)
		{
			return ExprFactory.CreateAnonymousMethod(SymbolLoader.GetPredefindType(PredefinedType.PT_FUNC), pScope, call);
		}

		private Expr CreateLocal(Type type, bool isOut, LocalVariableSymbol local)
		{
			CType dest = ((!isOut) ? SymbolTable.GetCTypeFromType(type) : TypeManager.GetParameterModifier(SymbolTable.GetCTypeFromType(type.GetElementType()), isOut: true));
			ExprLocal expr = ExprFactory.CreateLocal(local);
			Expr obj = _binder.tryConvert(expr, dest) ?? _binder.mustCast(expr, dest);
			obj.Flags |= EXPRFLAG.EXF_LVALUE;
			return obj;
		}

		internal Expr CreateArgumentListEXPR(ArgumentObject[] arguments, LocalVariableSymbol[] locals, int startIndex, int endIndex)
		{
			Expr first = null;
			Expr last = null;
			if (arguments != null)
			{
				for (int i = startIndex; i < endIndex; i++)
				{
					ArgumentObject argument = arguments[i];
					Expr expr = CreateArgumentEXPR(argument, locals[i]);
					if (first == null)
					{
						first = expr;
						last = first;
					}
					else
					{
						ExprFactory.AppendItemToList(expr, ref first, ref last);
					}
				}
			}
			return first;
		}

		private Expr CreateArgumentEXPR(ArgumentObject argument, LocalVariableSymbol local)
		{
			Expr expr = (argument.Info.LiteralConstant ? ((argument.Value != null) ? ExprFactory.CreateConstant(SymbolTable.GetCTypeFromType(argument.Type), ConstVal.Get(argument.Value)) : ((!argument.Info.UseCompileTimeType) ? ExprFactory.CreateNull() : ExprFactory.CreateConstant(SymbolTable.GetCTypeFromType(argument.Type), default(ConstVal)))) : ((argument.Info.UseCompileTimeType || argument.Value != null) ? CreateLocal(argument.Type, argument.Info.IsOut, local) : ExprFactory.CreateNull()));
			if (argument.Info.NamedArgument)
			{
				expr = ExprFactory.CreateNamedArgumentSpecification(NameManager.Add(argument.Info.Name), expr);
			}
			if (!argument.Info.UseCompileTimeType && argument.Value != null)
			{
				expr.RuntimeObject = argument.Value;
				expr.RuntimeObjectActualType = SymbolTable.GetCTypeFromType(argument.Value.GetType());
			}
			return expr;
		}

		private static ExprMemberGroup CreateMemberGroupExpr(string Name, Type[] typeArguments, Expr callingObject, SYMKIND kind)
		{
			Name name = NameManager.Add(Name);
			CType type = callingObject.Type;
			AggregateType aggregateType = ((type is ArrayType) ? SymbolLoader.GetPredefindType(PredefinedType.PT_ARRAY) : ((!(type is NullableType nullableType)) ? ((AggregateType)type) : nullableType.GetAts()));
			HashSet<CType> hashSet = new HashSet<CType>();
			List<CType> list = new List<CType>();
			symbmask_t mask = symbmask_t.MASK_MethodSymbol;
			switch (kind)
			{
			case SYMKIND.SK_PropertySymbol:
			case SYMKIND.SK_IndexerSymbol:
				mask = symbmask_t.MASK_PropertySymbol;
				break;
			case SYMKIND.SK_MethodSymbol:
				mask = symbmask_t.MASK_MethodSymbol;
				break;
			}
			bool flag = name == NameManager.GetPredefinedName(PredefinedName.PN_CTOR);
			foreach (AggregateType item in aggregateType.TypeHierarchy)
			{
				if (SymbolTable.AggregateContainsMethod(item.OwningAggregate, Name, mask) && hashSet.Add(item))
				{
					list.Add(item);
				}
				if (flag)
				{
					break;
				}
			}
			if (aggregateType.IsWindowsRuntimeType)
			{
				CType[] items = aggregateType.WinRTCollectionIfacesAll.Items;
				for (int i = 0; i < items.Length; i++)
				{
					AggregateType aggregateType2 = (AggregateType)items[i];
					if (SymbolTable.AggregateContainsMethod(aggregateType2.OwningAggregate, Name, mask) && hashSet.Add(aggregateType2))
					{
						list.Add(aggregateType2);
					}
				}
			}
			EXPRFLAG eXPRFLAG = EXPRFLAG.EXF_USERCALLABLE;
			if (Name == "Invoke" && callingObject.Type.IsDelegateType)
			{
				eXPRFLAG |= EXPRFLAG.EXF_GOTONOTBLOCKED;
			}
			if (Name == ".ctor")
			{
				eXPRFLAG |= EXPRFLAG.EXF_CTOR;
			}
			if (Name == "$Item$")
			{
				eXPRFLAG |= EXPRFLAG.EXF_INDEXER;
			}
			TypeArray typeArgs = ((typeArguments != null && typeArguments.Length != 0) ? TypeArray.Allocate(SymbolTable.GetCTypeArrayFromTypes(typeArguments)) : TypeArray.Empty);
			ExprMemberGroup exprMemberGroup = ExprFactory.CreateMemGroup(eXPRFLAG, name, typeArgs, kind, aggregateType, null, new CMemberLookupResults(TypeArray.Allocate(list.ToArray()), name));
			if (callingObject is ExprClass)
			{
				exprMemberGroup.OptionalLHS = callingObject;
			}
			else
			{
				exprMemberGroup.OptionalObject = callingObject;
			}
			return exprMemberGroup;
		}

		private Expr CreateProperty(SymWithType swt, Expr callingObject, BindingFlag flags)
		{
			PropertySymbol propertySymbol = swt.Prop();
			AggregateType type = swt.GetType();
			PropWithType pwt = new PropWithType(propertySymbol, type);
			ExprMemberGroup pMemGroup = CreateMemberGroupExpr(propertySymbol.name.Text, null, callingObject, SYMKIND.SK_PropertySymbol);
			return _binder.BindToProperty((callingObject is ExprClass) ? null : callingObject, pwt, flags, null, pMemGroup);
		}

		private ExprWithArgs CreateIndexer(SymWithType swt, Expr callingObject, Expr arguments, BindingFlag bindFlags)
		{
			ExprMemberGroup grp = CreateMemberGroupExpr((swt.Sym as IndexerSymbol).name.Text, null, callingObject, SYMKIND.SK_PropertySymbol);
			ExprWithArgs result = _binder.BindMethodGroupToArguments(bindFlags, grp, arguments);
			ReorderArgumentsForNamedAndOptional(callingObject, result);
			return result;
		}

		private Expr CreateArray(Expr callingObject, Expr optionalIndexerArguments)
		{
			return _binder.BindArrayIndexCore(callingObject, optionalIndexerArguments);
		}

		private Expr CreateField(SymWithType swt, Expr callingObject)
		{
			FieldSymbol field = swt.Field();
			AggregateType type = swt.GetType();
			FieldWithType fwt = new FieldWithType(field, type);
			return _binder.BindToField((callingObject is ExprClass) ? null : callingObject, fwt, (BindingFlag)0);
		}

		private Expr CreateCallingObjectForCall(ICSharpInvokeOrInvokeMemberBinder payload, ArgumentObject[] arguments, LocalVariableSymbol[] locals)
		{
			Expr expr;
			if (payload.StaticCall)
			{
				expr = ExprFactory.CreateClass(SymbolTable.GetCTypeFromType(arguments[0].Value as Type));
			}
			else
			{
				if (!arguments[0].Info.UseCompileTimeType && arguments[0].Value == null)
				{
					throw Error.NullReferenceOnMemberException();
				}
				expr = _binder.mustConvert(CreateArgumentEXPR(arguments[0], locals[0]), SymbolTable.GetCTypeFromType(arguments[0].Type));
				if (arguments[0].Type.IsValueType && expr is ExprCast)
				{
					expr.Flags |= EXPRFLAG.EXF_USERCALLABLE;
				}
			}
			return expr;
		}

		private ExprWithArgs BindCall(ICSharpInvokeOrInvokeMemberBinder payload, Expr callingObject, ArgumentObject[] arguments, LocalVariableSymbol[] locals)
		{
			if (payload is InvokeBinder && !callingObject.Type.IsDelegateType)
			{
				throw Error.BindInvokeFailedNonDelegate();
			}
			Type[] typeArguments = payload.TypeArguments;
			int arity = ((typeArguments != null) ? typeArguments.Length : 0);
			MemberLookup memberLookup = new MemberLookup();
			SymWithType symWithType = SymbolTable.LookupMember(payload.Name, callingObject, _binder.Context.ContextForMemberLookup, arity, memberLookup, (payload.Flags & CSharpCallFlags.EventHookup) != 0, requireInvocable: true);
			if (symWithType == null)
			{
				throw memberLookup.ReportErrors();
			}
			if (symWithType.Sym.getKind() != SYMKIND.SK_MethodSymbol)
			{
				throw Error.InternalCompilerError();
			}
			ExprMemberGroup exprMemberGroup = CreateMemberGroupExpr(payload.Name, payload.TypeArguments, callingObject, symWithType.Sym.getKind());
			if ((payload.Flags & CSharpCallFlags.SimpleNameCall) != CSharpCallFlags.None)
			{
				callingObject.Flags |= EXPRFLAG.EXF_UNREALIZEDGOTO;
			}
			if ((payload.Flags & CSharpCallFlags.EventHookup) != CSharpCallFlags.None)
			{
				memberLookup = new MemberLookup();
				SymWithType symWithType2 = SymbolTable.LookupMember(payload.Name.Split('_')[1], callingObject, _binder.Context.ContextForMemberLookup, arity, memberLookup, (payload.Flags & CSharpCallFlags.EventHookup) != 0, requireInvocable: true);
				if (symWithType2 == null)
				{
					throw memberLookup.ReportErrors();
				}
				CType typeSrc = null;
				if (symWithType2.Sym.getKind() == SYMKIND.SK_FieldSymbol)
				{
					typeSrc = symWithType2.Field().GetType();
				}
				else if (symWithType2.Sym.getKind() == SYMKIND.SK_EventSymbol)
				{
					typeSrc = symWithType2.Event().type;
				}
				Type associatedSystemType = TypeManager.SubstType(typeSrc, symWithType2.Ats).AssociatedSystemType;
				if (associatedSystemType != null)
				{
					BindImplicitConversion(new ArgumentObject[1] { arguments[1] }, associatedSystemType, locals, bIsArrayCreationConversion: false);
				}
				exprMemberGroup.Flags &= ~EXPRFLAG.EXF_USERCALLABLE;
				if (symWithType2.Sym.getKind() == SYMKIND.SK_EventSymbol && symWithType2.Event().IsWindowsRuntimeEvent)
				{
					return BindWinRTEventAccessor(new EventWithType(symWithType2.Event(), symWithType2.Ats), callingObject, arguments, locals, payload.Name.StartsWith("add_", StringComparison.Ordinal));
				}
			}
			if ((payload.Name.StartsWith("set_", StringComparison.Ordinal) && ((MethodSymbol)symWithType.Sym).Params.Count > 1) || (payload.Name.StartsWith("get_", StringComparison.Ordinal) && ((MethodSymbol)symWithType.Sym).Params.Count > 0))
			{
				exprMemberGroup.Flags &= ~EXPRFLAG.EXF_USERCALLABLE;
			}
			ExprCall exprCall = _binder.BindMethodGroupToArguments(BindingFlag.BIND_RVALUEREQUIRED | BindingFlag.BIND_STMTEXPRONLY, exprMemberGroup, CreateArgumentListEXPR(arguments, locals, 1, arguments.Length)) as ExprCall;
			CheckForConditionalMethodError(exprCall);
			ReorderArgumentsForNamedAndOptional(callingObject, exprCall);
			return exprCall;
		}

		private ExprWithArgs BindWinRTEventAccessor(EventWithType ewt, Expr callingObject, ArgumentObject[] arguments, LocalVariableSymbol[] locals, bool isAddAccessor)
		{
			Type associatedSystemType = ewt.Event().type.AssociatedSystemType;
			MethPropWithInst method = new MethPropWithInst(ewt.Event().methRemove, ewt.Ats);
			ExprMemberGroup exprMemberGroup = ExprFactory.CreateMemGroup(callingObject, method);
			exprMemberGroup.Flags &= ~EXPRFLAG.EXF_USERCALLABLE;
			Type eventRegistrationTokenType = SymbolTable.EventRegistrationTokenType;
			Type actionType = Expression.GetActionType(eventRegistrationTokenType);
			Expr expr = _binder.mustConvert(exprMemberGroup, SymbolTable.GetCTypeFromType(actionType));
			Expr expr2 = CreateArgumentEXPR(arguments[1], locals[1]);
			ExprList args;
			string text;
			if (isAddAccessor)
			{
				MethPropWithInst method2 = new MethPropWithInst(ewt.Event().methAdd, ewt.Ats);
				ExprMemberGroup exprMemberGroup2 = ExprFactory.CreateMemGroup(callingObject, method2);
				exprMemberGroup2.Flags &= ~EXPRFLAG.EXF_USERCALLABLE;
				Type funcType = Expression.GetFuncType(associatedSystemType, eventRegistrationTokenType);
				args = ExprFactory.CreateList(_binder.mustConvert(exprMemberGroup2, SymbolTable.GetCTypeFromType(funcType)), expr, expr2);
				text = NameManager.GetPredefinedName(PredefinedName.PN_ADDEVENTHANDLER).Text;
			}
			else
			{
				args = ExprFactory.CreateList(expr, expr2);
				text = NameManager.GetPredefinedName(PredefinedName.PN_REMOVEEVENTHANDLER).Text;
			}
			Type windowsRuntimeMarshalType = SymbolTable.WindowsRuntimeMarshalType;
			SymbolTable.PopulateSymbolTableWithName(text, new List<Type> { associatedSystemType }, windowsRuntimeMarshalType);
			ExprClass callingObject2 = ExprFactory.CreateClass(SymbolTable.GetCTypeFromType(windowsRuntimeMarshalType));
			ExprMemberGroup grp = CreateMemberGroupExpr(text, new Type[1] { associatedSystemType }, callingObject2, SYMKIND.SK_MethodSymbol);
			return _binder.BindMethodGroupToArguments(BindingFlag.BIND_RVALUEREQUIRED | BindingFlag.BIND_STMTEXPRONLY, grp, args);
		}

		private static void CheckForConditionalMethodError(ExprCall call)
		{
			MethodSymbol methodSymbol = call.MethWithInst.Meth();
			if (methodSymbol.AssociatedMemberInfo.GetCustomAttributes(typeof(ConditionalAttribute), inherit: true).Length != 0)
			{
				throw Error.BindCallToConditionalMethod(methodSymbol.name);
			}
		}

		private void ReorderArgumentsForNamedAndOptional(Expr callingObject, ExprWithArgs result)
		{
			Expr optionalArguments = result.OptionalArguments;
			AggregateType ats;
			ExprMemberGroup memberGroup;
			TypeArray typeArgsMeth;
			MethodOrPropertySymbol methodOrPropertySymbol;
			if (result is ExprCall exprCall)
			{
				ats = exprCall.MethWithInst.Ats;
				methodOrPropertySymbol = exprCall.MethWithInst.Meth();
				memberGroup = exprCall.MemberGroup;
				typeArgsMeth = exprCall.MethWithInst.TypeArgs;
			}
			else
			{
				ExprProperty obj = result as ExprProperty;
				ats = obj.PropWithTypeSlot.Ats;
				methodOrPropertySymbol = obj.PropWithTypeSlot.Prop();
				memberGroup = obj.MemberGroup;
				typeArgsMeth = null;
			}
			ArgInfos argInfos = new ArgInfos
			{
				carg = ExpressionBinder.CountArguments(optionalArguments)
			};
			ExpressionBinder.FillInArgInfoFromArgList(argInfos, optionalArguments);
			TypeArray typeArray = TypeManager.SubstTypeArray(methodOrPropertySymbol.Params, ats, typeArgsMeth);
			methodOrPropertySymbol = ExpressionBinder.GroupToArgsBinder.FindMostDerivedMethod(methodOrPropertySymbol, callingObject.Type);
			ExpressionBinder.GroupToArgsBinder.ReOrderArgsForNamedArguments(methodOrPropertySymbol, typeArray, ats, memberGroup, argInfos);
			Expr expr = null;
			for (int num = argInfos.carg - 1; num >= 0; num--)
			{
				Expr pArg = argInfos.prgexpr[num];
				pArg = StripNamedArgument(pArg);
				pArg = _binder.tryConvert(pArg, typeArray[num]);
				expr = ((expr == null) ? pArg : ExprFactory.CreateList(pArg, expr));
			}
			result.OptionalArguments = expr;
		}

		private Expr StripNamedArgument(Expr pArg)
		{
			if (pArg is ExprNamedArgumentSpecification exprNamedArgumentSpecification)
			{
				pArg = exprNamedArgumentSpecification.Value;
			}
			else if (pArg is ExprArrayInit exprArrayInit)
			{
				exprArrayInit.OptionalArguments = StripNamedArguments(exprArrayInit.OptionalArguments);
			}
			return pArg;
		}

		private Expr StripNamedArguments(Expr pArg)
		{
			ExprList exprList = pArg as ExprList;
			if (exprList != null)
			{
				while (true)
				{
					exprList.OptionalElement = StripNamedArgument(exprList.OptionalElement);
					if (!(exprList.OptionalNextListNode is ExprList exprList2))
					{
						break;
					}
					exprList = exprList2;
				}
				exprList.OptionalNextListNode = StripNamedArgument(exprList.OptionalNextListNode);
			}
			return StripNamedArgument(pArg);
		}

		internal Expr BindUnaryOperation(CSharpUnaryOperationBinder payload, ArgumentObject[] arguments, LocalVariableSymbol[] locals)
		{
			OperatorKind operatorKind = GetOperatorKind(payload.Operation);
			Expr expr = CreateArgumentEXPR(arguments[0], locals[0]);
			expr.ErrorString = Operators.GetDisplayName(GetOperatorKind(payload.Operation));
			if (operatorKind == OperatorKind.OP_TRUE || operatorKind == OperatorKind.OP_FALSE)
			{
				Expr expr2 = _binder.tryConvert(expr, SymbolLoader.GetPredefindType(PredefinedType.PT_BOOL));
				if (expr2 != null && operatorKind == OperatorKind.OP_FALSE)
				{
					expr2 = _binder.BindStandardUnaryOperator(OperatorKind.OP_LOGNOT, expr2);
				}
				return expr2 ?? _binder.bindUDUnop((operatorKind == OperatorKind.OP_TRUE) ? ExpressionKind.True : ExpressionKind.False, expr) ?? _binder.mustConvert(expr, SymbolLoader.GetPredefindType(PredefinedType.PT_BOOL));
			}
			return _binder.BindStandardUnaryOperator(operatorKind, expr);
		}

		internal Expr BindBinaryOperation(CSharpBinaryOperationBinder payload, ArgumentObject[] arguments, LocalVariableSymbol[] locals)
		{
			ExpressionKind expressionKind = Operators.GetExpressionKind(GetOperatorKind(payload.Operation, payload.IsLogicalOperation));
			Expr expr = CreateArgumentEXPR(arguments[0], locals[0]);
			Expr expr2 = CreateArgumentEXPR(arguments[1], locals[1]);
			expr.ErrorString = Operators.GetDisplayName(GetOperatorKind(payload.Operation, payload.IsLogicalOperation));
			expr2.ErrorString = Operators.GetDisplayName(GetOperatorKind(payload.Operation, payload.IsLogicalOperation));
			if (expressionKind > ExpressionKind.MultiOffset)
			{
				expressionKind -= 71;
			}
			return _binder.BindStandardBinop(expressionKind, expr, expr2);
		}

		private static OperatorKind GetOperatorKind(ExpressionType p)
		{
			return GetOperatorKind(p, bIsLogical: false);
		}

		private static OperatorKind GetOperatorKind(ExpressionType p, bool bIsLogical)
		{
			switch (p)
			{
			default:
				throw Error.InternalCompilerError();
			case ExpressionType.Add:
				return OperatorKind.OP_ADD;
			case ExpressionType.Subtract:
				return OperatorKind.OP_SUB;
			case ExpressionType.Multiply:
				return OperatorKind.OP_MUL;
			case ExpressionType.Divide:
				return OperatorKind.OP_DIV;
			case ExpressionType.Modulo:
				return OperatorKind.OP_MOD;
			case ExpressionType.LeftShift:
				return OperatorKind.OP_LSHIFT;
			case ExpressionType.RightShift:
				return OperatorKind.OP_RSHIFT;
			case ExpressionType.LessThan:
				return OperatorKind.OP_LT;
			case ExpressionType.GreaterThan:
				return OperatorKind.OP_GT;
			case ExpressionType.LessThanOrEqual:
				return OperatorKind.OP_LE;
			case ExpressionType.GreaterThanOrEqual:
				return OperatorKind.OP_GE;
			case ExpressionType.Equal:
				return OperatorKind.OP_EQ;
			case ExpressionType.NotEqual:
				return OperatorKind.OP_NEQ;
			case ExpressionType.And:
				if (!bIsLogical)
				{
					return OperatorKind.OP_BITAND;
				}
				return OperatorKind.OP_LOGAND;
			case ExpressionType.ExclusiveOr:
				return OperatorKind.OP_BITXOR;
			case ExpressionType.Or:
				if (!bIsLogical)
				{
					return OperatorKind.OP_BITOR;
				}
				return OperatorKind.OP_LOGOR;
			case ExpressionType.AddAssign:
				return OperatorKind.OP_ADDEQ;
			case ExpressionType.SubtractAssign:
				return OperatorKind.OP_SUBEQ;
			case ExpressionType.MultiplyAssign:
				return OperatorKind.OP_MULEQ;
			case ExpressionType.DivideAssign:
				return OperatorKind.OP_DIVEQ;
			case ExpressionType.ModuloAssign:
				return OperatorKind.OP_MODEQ;
			case ExpressionType.AndAssign:
				return OperatorKind.OP_ANDEQ;
			case ExpressionType.ExclusiveOrAssign:
				return OperatorKind.OP_XOREQ;
			case ExpressionType.OrAssign:
				return OperatorKind.OP_OREQ;
			case ExpressionType.LeftShiftAssign:
				return OperatorKind.OP_LSHIFTEQ;
			case ExpressionType.RightShiftAssign:
				return OperatorKind.OP_RSHIFTEQ;
			case ExpressionType.Negate:
				return OperatorKind.OP_NEG;
			case ExpressionType.UnaryPlus:
				return OperatorKind.OP_UPLUS;
			case ExpressionType.Not:
				return OperatorKind.OP_LOGNOT;
			case ExpressionType.OnesComplement:
				return OperatorKind.OP_BITNOT;
			case ExpressionType.IsTrue:
				return OperatorKind.OP_TRUE;
			case ExpressionType.IsFalse:
				return OperatorKind.OP_FALSE;
			case ExpressionType.Increment:
				return OperatorKind.OP_PREINC;
			case ExpressionType.Decrement:
				return OperatorKind.OP_PREDEC;
			}
		}

		internal Expr BindProperty(ICSharpBinder payload, ArgumentObject argument, LocalVariableSymbol local, Expr optionalIndexerArguments)
		{
			Expr expr = (argument.Info.IsStaticType ? ExprFactory.CreateClass(SymbolTable.GetCTypeFromType(argument.Value as Type)) : CreateLocal(argument.Type, argument.Info.IsOut, local));
			if (!argument.Info.UseCompileTimeType && argument.Value == null)
			{
				throw Error.NullReferenceOnMemberException();
			}
			if (argument.Type.IsValueType && expr is ExprCast)
			{
				expr.Flags |= EXPRFLAG.EXF_USERCALLABLE;
			}
			string name = payload.Name;
			BindingFlag bindingFlags = payload.BindingFlags;
			MemberLookup memberLookup = new MemberLookup();
			SymWithType symWithType = SymbolTable.LookupMember(name, expr, _binder.Context.ContextForMemberLookup, 0, memberLookup, allowSpecialNames: false, requireInvocable: false);
			if (symWithType == null)
			{
				if (optionalIndexerArguments != null)
				{
					int num = ExpressionIterator.Count(optionalIndexerArguments);
					Type type = argument.Type;
					if (type.IsArray)
					{
						if (type.IsArray && type.GetArrayRank() != num)
						{
							throw ErrorHandling.Error(ErrorCode.ERR_BadIndexCount, type.GetArrayRank());
						}
						return CreateArray(expr, optionalIndexerArguments);
					}
				}
				throw memberLookup.ReportErrors();
			}
			switch (symWithType.Sym.getKind())
			{
			case SYMKIND.SK_MethodSymbol:
				throw Error.BindPropertyFailedMethodGroup(name);
			case SYMKIND.SK_PropertySymbol:
				if (symWithType.Sym is IndexerSymbol)
				{
					return CreateIndexer(symWithType, expr, optionalIndexerArguments, bindingFlags);
				}
				expr.Flags |= EXPRFLAG.EXF_LVALUE;
				return CreateProperty(symWithType, expr, payload.BindingFlags);
			case SYMKIND.SK_FieldSymbol:
				return CreateField(symWithType, expr);
			case SYMKIND.SK_EventSymbol:
				throw Error.BindPropertyFailedEvent(name);
			default:
				throw Error.InternalCompilerError();
			}
		}

		internal Expr BindImplicitConversion(ArgumentObject[] arguments, Type returnType, LocalVariableSymbol[] locals, bool bIsArrayCreationConversion)
		{
			SymbolTable.AddConversionsForType(returnType);
			Expr expr = CreateArgumentEXPR(arguments[0], locals[0]);
			CType cTypeFromType = SymbolTable.GetCTypeFromType(returnType);
			if (bIsArrayCreationConversion)
			{
				CType dest = _binder.ChooseArrayIndexType(expr);
				return _binder.mustCast(_binder.mustConvert(expr, dest), cTypeFromType, CONVERTTYPE.NOUDC | CONVERTTYPE.CHECKOVERFLOW);
			}
			return _binder.mustConvert(expr, cTypeFromType);
		}

		internal Expr BindExplicitConversion(ArgumentObject[] arguments, Type returnType, LocalVariableSymbol[] locals)
		{
			SymbolTable.AddConversionsForType(returnType);
			Expr expr = CreateArgumentEXPR(arguments[0], locals[0]);
			CType cTypeFromType = SymbolTable.GetCTypeFromType(returnType);
			return _binder.mustCast(expr, cTypeFromType);
		}

		internal Expr BindAssignment(ICSharpBinder payload, ArgumentObject[] arguments, LocalVariableSymbol[] locals)
		{
			string name = payload.Name;
			Expr optionalIndexerArguments;
			bool isCompoundAssignment;
			if (payload is CSharpSetIndexBinder cSharpSetIndexBinder)
			{
				optionalIndexerArguments = CreateArgumentListEXPR(arguments, locals, 1, arguments.Length - 1);
				isCompoundAssignment = cSharpSetIndexBinder.IsCompoundAssignment;
			}
			else
			{
				optionalIndexerArguments = null;
				isCompoundAssignment = (payload as CSharpSetMemberBinder).IsCompoundAssignment;
			}
			SymbolTable.PopulateSymbolTableWithName(name, null, arguments[0].Type);
			Expr op = BindProperty(payload, arguments[0], locals[0], optionalIndexerArguments);
			int num = arguments.Length - 1;
			Expr op2 = CreateArgumentEXPR(arguments[num], locals[num]);
			return _binder.BindAssignment(op, op2, isCompoundAssignment);
		}

		internal Expr BindIsEvent(CSharpIsEventBinder binder, ArgumentObject[] arguments, LocalVariableSymbol[] locals)
		{
			Expr callingObject = CreateLocal(arguments[0].Type, isOut: false, locals[0]);
			MemberLookup mem = new MemberLookup();
			AggregateType predefindType = SymbolLoader.GetPredefindType(PredefinedType.PT_BOOL);
			bool value = false;
			if (arguments[0].Value == null)
			{
				throw Error.NullReferenceOnMemberException();
			}
			SymWithType symWithType = SymbolTable.LookupMember(binder.Name, callingObject, _binder.Context.ContextForMemberLookup, 0, mem, allowSpecialNames: false, requireInvocable: false);
			if (symWithType != null)
			{
				if (symWithType.Sym.getKind() == SYMKIND.SK_EventSymbol)
				{
					value = true;
				}
				else if (symWithType.Sym is FieldSymbol { isEvent: not false })
				{
					value = true;
				}
			}
			return ExprFactory.CreateConstant(predefindType, ConstVal.Get(value));
		}
	}
	[Serializable]
	public class RuntimeBinderException : Exception
	{
		public RuntimeBinderException()
		{
		}

		public RuntimeBinderException(string message)
			: base(message)
		{
		}

		public RuntimeBinderException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected RuntimeBinderException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
	internal static class RuntimeBinderExtensions
	{
		private static Func<MemberInfo, MemberInfo, bool> s_MemberEquivalence = delegate(MemberInfo m1, MemberInfo m2)
		{
			try
			{
				Type typeFromHandle = typeof(MemberInfo);
				MethodInfo method = typeFromHandle.GetMethod("HasSameMetadataDefinitionAs", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public | BindingFlags.ExactBinding, null, new Type[1] { typeof(MemberInfo) }, null);
				if (method != null)
				{
					Func<MemberInfo, MemberInfo, bool> func = (Func<MemberInfo, MemberInfo, bool>)method.CreateDelegate(typeof(Func<MemberInfo, MemberInfo, bool>));
					try
					{
						bool result = func(m1, m2);
						s_MemberEquivalence = func;
						return result;
					}
					catch
					{
					}
				}
				PropertyInfo property = typeFromHandle.GetProperty("MetadataToken", typeof(int), Array.Empty<Type>());
				if ((object)property != null && property.CanRead)
				{
					ParameterExpression parameterExpression = Expression.Parameter(typeFromHandle);
					ParameterExpression parameterExpression2 = Expression.Parameter(typeFromHandle);
					Func<MemberInfo, MemberInfo, bool> func2 = Expression.Lambda<Func<MemberInfo, MemberInfo, bool>>(Expression.Equal(Expression.Property(parameterExpression, property), Expression.Property(parameterExpression2, property)), new ParameterExpression[2] { parameterExpression, parameterExpression2 }).Compile();
					bool result2 = func2(m1, m2);
					s_MemberEquivalence = func2;
					return result2;
				}
			}
			catch
			{
			}
			return (s_MemberEquivalence = (MemberInfo m1param, MemberInfo m2param) => m1param.IsEquivalentTo(m2param))(m1, m2);
		};

		public static bool IsNullableType(this Type type)
		{
			if (type.IsConstructedGenericType)
			{
				return type.GetGenericTypeDefinition() == typeof(Nullable<>);
			}
			return false;
		}

		public static bool IsEquivalentTo(this MemberInfo mi1, MemberInfo mi2)
		{
			if (mi1 == null || mi2 == null)
			{
				if (mi1 == null)
				{
					return mi2 == null;
				}
				return false;
			}
			if (mi1.Equals(mi2))
			{
				return true;
			}
			MethodInfo methodInfo = mi1 as MethodInfo;
			if ((object)methodInfo != null)
			{
				MethodInfo methodInfo2 = mi2 as MethodInfo;
				if ((object)methodInfo2 == null || methodInfo.IsGenericMethod != methodInfo2.IsGenericMethod)
				{
					return false;
				}
				if (methodInfo.IsGenericMethod)
				{
					methodInfo = methodInfo.GetGenericMethodDefinition();
					methodInfo2 = methodInfo2.GetGenericMethodDefinition();
					if (methodInfo.GetGenericArguments().Length != methodInfo2.GetGenericArguments().Length)
					{
						return false;
					}
				}
				if (methodInfo != methodInfo2 && methodInfo.CallingConvention == methodInfo2.CallingConvention && methodInfo.Name == methodInfo2.Name && methodInfo.DeclaringType.IsGenericallyEqual(methodInfo2.DeclaringType) && methodInfo.ReturnType.IsGenericallyEquivalentTo(methodInfo2.ReturnType, methodInfo, methodInfo2))
				{
					return methodInfo.AreParametersEquivalent(methodInfo2);
				}
				return false;
			}
			if (mi1 is ConstructorInfo constructorInfo)
			{
				if (mi2 is ConstructorInfo constructorInfo2 && constructorInfo != constructorInfo2 && constructorInfo.CallingConvention == constructorInfo2.CallingConvention && constructorInfo.DeclaringType.IsGenericallyEqual(constructorInfo2.DeclaringType))
				{
					return constructorInfo.AreParametersEquivalent(constructorInfo2);
				}
				return false;
			}
			if (mi1 is PropertyInfo propertyInfo && mi2 is PropertyInfo propertyInfo2 && propertyInfo != propertyInfo2 && propertyInfo.Name == propertyInfo2.Name && propertyInfo.DeclaringType.IsGenericallyEqual(propertyInfo2.DeclaringType) && propertyInfo.PropertyType.IsGenericallyEquivalentTo(propertyInfo2.PropertyType, propertyInfo, propertyInfo2) && propertyInfo.GetGetMethod(nonPublic: true).IsEquivalentTo(propertyInfo2.GetGetMethod(nonPublic: true)))
			{
				return propertyInfo.GetSetMethod(nonPublic: true).IsEquivalentTo(propertyInfo2.GetSetMethod(nonPublic: true));
			}
			return false;
		}

		private static bool AreParametersEquivalent(this MethodBase method1, MethodBase method2)
		{
			ParameterInfo[] parameters = method1.GetParameters();
			ParameterInfo[] parameters2 = method2.GetParameters();
			if (parameters.Length != parameters2.Length)
			{
				return false;
			}
			for (int i = 0; i < parameters.Length; i++)
			{
				if (!parameters[i].IsEquivalentTo(parameters2[i], method1, method2))
				{
					return false;
				}
			}
			return true;
		}

		private static bool IsEquivalentTo(this ParameterInfo pi1, ParameterInfo pi2, MethodBase method1, MethodBase method2)
		{
			if (pi1 == null || pi2 == null)
			{
				if (pi1 == null)
				{
					return pi2 == null;
				}
				return false;
			}
			if (pi1.Equals(pi2))
			{
				return true;
			}
			return pi1.ParameterType.IsGenericallyEquivalentTo(pi2.ParameterType, method1, method2);
		}

		private static bool IsGenericallyEqual(this Type t1, Type t2)
		{
			if (t1 == null || t2 == null)
			{
				if (t1 == null)
				{
					return t2 == null;
				}
				return false;
			}
			if (t1.Equals(t2))
			{
				return true;
			}
			if (t1.IsConstructedGenericType || t2.IsConstructedGenericType)
			{
				Type obj = (t1.IsConstructedGenericType ? t1.GetGenericTypeDefinition() : t1);
				Type o = (t2.IsConstructedGenericType ? t2.GetGenericTypeDefinition() : t2);
				return obj.Equals(o);
			}
			return false;
		}

		private static bool IsGenericallyEquivalentTo(this Type t1, Type t2, MemberInfo member1, MemberInfo member2)
		{
			if (t1.Equals(t2))
			{
				return true;
			}
			if (t1.IsGenericParameter)
			{
				if (t2.IsGenericParameter)
				{
					if (t1.DeclaringMethod == null && member1.DeclaringType.Equals(t1.DeclaringType))
					{
						if (!(t2.DeclaringMethod == null) || !member2.DeclaringType.Equals(t2.DeclaringType))
						{
							return t1.IsTypeParameterEquivalentToTypeInst(t2, member2);
						}
					}
					else if (t2.DeclaringMethod == null && member2.DeclaringType.Equals(t2.DeclaringType))
					{
						return t2.IsTypeParameterEquivalentToTypeInst(t1, member1);
					}
					return false;
				}
				return t1.IsTypeParameterEquivalentToTypeInst(t2, member2);
			}
			if (t2.IsGenericParameter)
			{
				return t2.IsTypeParameterEquivalentToTypeInst(t1, member1);
			}
			if (t1.IsGenericType && t2.IsGenericType)
			{
				Type[] genericArguments = t1.GetGenericArguments();
				Type[] genericArguments2 = t2.GetGenericArguments();
				if (genericArguments.Length == genericArguments2.Length)
				{
					if (t1.IsGenericallyEqual(t2))
					{
						return genericArguments.Zip(genericArguments2, (Type ta1, Type ta2) => ta1.IsGenericallyEquivalentTo(ta2, member1, member2)).All((bool x) => x);
					}
					return false;
				}
			}
			if (t1.IsArray && t2.IsArray)
			{
				if (t1.GetArrayRank() == t2.GetArrayRank())
				{
					return t1.GetElementType().IsGenericallyEquivalentTo(t2.GetElementType(), member1, member2);
				}
				return false;
			}
			if ((t1.IsByRef && t2.IsByRef) || (t1.IsPointer && t2.IsPointer))
			{
				return t1.GetElementType().IsGenericallyEquivalentTo(t2.GetElementType(), member1, member2);
			}
			return false;
		}

		private static bool IsTypeParameterEquivalentToTypeInst(this Type typeParam, Type typeInst, MemberInfo member)
		{
			if (typeParam.DeclaringMethod != null)
			{
				if (!(member is MethodBase))
				{
					return false;
				}
				MethodBase methodBase = (MethodBase)member;
				int genericParameterPosition = typeParam.GenericParameterPosition;
				Type[] array = (methodBase.IsGenericMethod ? methodBase.GetGenericArguments() : null);
				if (array != null && array.Length > genericParameterPosition)
				{
					return array[genericParameterPosition].Equals(typeInst);
				}
				return false;
			}
			return member.DeclaringType.GetGenericArguments()[typeParam.GenericParameterPosition].Equals(typeInst);
		}

		public static bool HasSameMetadataDefinitionAs(this MemberInfo mi1, MemberInfo mi2)
		{
			if (mi1.Module.Equals(mi2.Module))
			{
				return s_MemberEquivalence(mi1, mi2);
			}
			return false;
		}

		public static string GetIndexerName(this Type type)
		{
			string typeIndexerName = GetTypeIndexerName(type);
			if (typeIndexerName == null && type.IsInterface)
			{
				Type[] interfaces = type.GetInterfaces();
				for (int i = 0; i < interfaces.Length; i++)
				{
					typeIndexerName = GetTypeIndexerName(interfaces[i]);
					if (typeIndexerName != null)
					{
						break;
					}
				}
			}
			return typeIndexerName;
		}

		private static string GetTypeIndexerName(Type type)
		{
			string name = type.GetCustomAttribute<DefaultMemberAttribute>()?.MemberName;
			if (name != null && type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic).Any((PropertyInfo p) => p.Name == name && p.GetIndexParameters().Length != 0))
			{
				return name;
			}
			return null;
		}
	}
	[Serializable]
	public class RuntimeBinderInternalCompilerException : Exception
	{
		public RuntimeBinderInternalCompilerException()
		{
		}

		public RuntimeBinderInternalCompilerException(string message)
			: base(message)
		{
		}

		public RuntimeBinderInternalCompilerException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected RuntimeBinderInternalCompilerException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
	internal static class SpecialNames
	{
		public const string ImplicitConversion = "op_Implicit";

		public const string ExplicitConversion = "op_Explicit";

		public const string Invoke = "Invoke";

		public const string Constructor = ".ctor";

		public const string Indexer = "$Item$";

		public const string CLR_Add = "op_Addition";

		public const string CLR_Subtract = "op_Subtraction";

		public const string CLR_Multiply = "op_Multiply";

		public const string CLR_Division = "op_Division";

		public const string CLR_Modulus = "op_Modulus";

		public const string CLR_LShift = "op_LeftShift";

		public const string CLR_RShift = "op_RightShift";

		public const string CLR_LT = "op_LessThan";

		public const string CLR_GT = "op_GreaterThan";

		public const string CLR_LTE = "op_LessThanOrEqual";

		public const string CLR_GTE = "op_GreaterThanOrEqual";

		public const string CLR_Equality = "op_Equality";

		public const string CLR_Inequality = "op_Inequality";

		public const string CLR_BitwiseAnd = "op_BitwiseAnd";

		public const string CLR_ExclusiveOr = "op_ExclusiveOr";

		public const string CLR_BitwiseOr = "op_BitwiseOr";

		public const string CLR_LogicalNot = "op_LogicalNot";

		public const string CLR_InPlaceAdd = "op_Addition";

		public const string CLR_InPlaceSubtract = "op_Subtraction";

		public const string CLR_InPlaceMultiply = "op_Multiply";

		public const string CLR_InPlaceDivide = "op_Division";

		public const string CLR_InPlaceModulus = "op_Modulus";

		public const string CLR_InPlaceBitwiseAnd = "op_BitwiseAnd";

		public const string CLR_InPlaceExclusiveOr = "op_ExclusiveOr";

		public const string CLR_InPlaceBitwiseOr = "op_BitwiseOr";

		public const string CLR_InPlaceLShift = "op_LeftShift";

		public const string CLR_InPlaceRShift = "op_RightShift";

		public const string CLR_UnaryNegation = "op_UnaryNegation";

		public const string CLR_UnaryPlus = "op_UnaryPlus";

		public const string CLR_OnesComplement = "op_OnesComplement";

		public const string CLR_True = "op_True";

		public const string CLR_False = "op_False";

		public const string CLR_Increment = "op_Increment";

		public const string CLR_Decrement = "op_Decrement";
	}
	internal static class SymbolTable
	{
		private readonly struct NameHashKey : IEquatable<NameHashKey>
		{
			internal Type Type { get; }

			internal string Name { get; }

			public NameHashKey(Type type, string name)
			{
				Type = type;
				Name = name;
			}

			public bool Equals(NameHashKey other)
			{
				if (Type.Equals(other.Type))
				{
					return Name.Equals(other.Name);
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj is NameHashKey other)
				{
					return Equals(other);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return Type.GetHashCode() ^ Name.GetHashCode();
			}
		}

		private static readonly HashSet<Type> s_typesWithConversionsLoaded = new HashSet<Type>();

		private static readonly HashSet<NameHashKey> s_namesLoadedForEachType = new HashSet<NameHashKey>();

		private static readonly Type s_Sentinel = typeof(SymbolTable);

		private static Type s_EventRegistrationTokenType = s_Sentinel;

		private static Type s_WindowsRuntimeMarshal = s_Sentinel;

		private static Type s_EventRegistrationTokenTable = s_Sentinel;

		internal static Type EventRegistrationTokenType => GetTypeByName(ref s_EventRegistrationTokenType, "System.Runtime.InteropServices.WindowsRuntime.EventRegistrationToken, System.Runtime.InteropServices.WindowsRuntime, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");

		internal static Type WindowsRuntimeMarshalType => GetTypeByName(ref s_WindowsRuntimeMarshal, "System.Runtime.InteropServices.WindowsRuntime.WindowsRuntimeMarshal, System.Runtime.InteropServices.WindowsRuntime, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");

		private static Type EventRegistrationTokenTableType => GetTypeByName(ref s_EventRegistrationTokenTable, "System.Runtime.InteropServices.WindowsRuntime.EventRegistrationTokenTable`1, System.Runtime.InteropServices.WindowsRuntime, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a");

		internal static void PopulateSymbolTableWithName(string name, IEnumerable<Type> typeArguments, Type callingType)
		{
			if (callingType.IsGenericType)
			{
				callingType = callingType.GetGenericTypeDefinition();
			}
			if (name == "$Item$")
			{
				name = callingType.GetIndexerName() ?? "$Item$";
			}
			NameHashKey nameHashKey = new NameHashKey(callingType, name);
			if (s_namesLoadedForEachType.Contains(nameHashKey))
			{
				return;
			}
			AddNamesOnType(nameHashKey);
			if (typeArguments == null)
			{
				return;
			}
			foreach (Type typeArgument in typeArguments)
			{
				AddConversionsForType(typeArgument);
			}
		}

		internal static SymWithType LookupMember(string name, Expr callingObject, ParentSymbol context, int arity, MemberLookup mem, bool allowSpecialNames, bool requireInvocable)
		{
			CType cType = callingObject.Type;
			if (cType is ArrayType)
			{
				cType = SymbolLoader.GetPredefindType(PredefinedType.PT_ARRAY);
			}
			if (cType is NullableType nullableType)
			{
				cType = nullableType.GetAts();
			}
			if (!mem.Lookup(cType, callingObject, context, GetName(name), arity, (MemLookFlags)(((!allowSpecialNames) ? 256 : 0) | ((name == "$Item$") ? 4 : 0) | ((name == ".ctor") ? 2 : 0) | (requireInvocable ? 536870912 : 0))))
			{
				return null;
			}
			return mem.SwtFirst();
		}

		private static void AddParameterConversions(MethodBase method)
		{
			ParameterInfo[] parameters = method.GetParameters();
			for (int i = 0; i < parameters.Length; i++)
			{
				AddConversionsForType(parameters[i].ParameterType);
			}
		}

		private static void AddNamesOnType(NameHashKey key)
		{
			List<Type> inheritance = CreateInheritanceHierarchyList(key.Type);
			AddNamesInInheritanceHierarchy(key.Name, inheritance);
		}

		private static void AddNamesInInheritanceHierarchy(string name, List<Type> inheritance)
		{
			for (int num = inheritance.Count - 1; num >= 0; num--)
			{
				Type type = inheritance[num];
				if (type.IsGenericType)
				{
					type = type.GetGenericTypeDefinition();
				}
				if (s_namesLoadedForEachType.Add(new NameHashKey(type, name)))
				{
					IEnumerator<MemberInfo> enumerator = (from member in type.GetMembers(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic)
						where member.DeclaringType == type && member.Name == name
						select member).GetEnumerator();
					if (enumerator.MoveNext())
					{
						List<EventInfo> list = null;
						if (GetCTypeFromType(type) is AggregateType { OwningAggregate: var owningAggregate })
						{
							FieldSymbol addedField = null;
							do
							{
								MemberInfo current = enumerator.Current;
								if (current is MethodInfo methodInfo)
								{
									AddMethodToSymbolTable(methodInfo, owningAggregate, current.Name switch
									{
										"Invoke" => MethodKindEnum.Invoke, 
										"op_Implicit" => MethodKindEnum.ImplicitConv, 
										"op_Explicit" => MethodKindEnum.ExplicitConv, 
										_ => MethodKindEnum.Actual, 
									});
									AddParameterConversions(methodInfo);
								}
								else if (current is ConstructorInfo constructorInfo)
								{
									AddMethodToSymbolTable(constructorInfo, owningAggregate, MethodKindEnum.Constructor);
									AddParameterConversions(constructorInfo);
								}
								else if (current is PropertyInfo property)
								{
									AddPropertyToSymbolTable(property, owningAggregate);
								}
								else if (current is FieldInfo fieldInfo)
								{
									addedField = AddFieldToSymbolTable(fieldInfo, owningAggregate);
								}
								else if (current is EventInfo item)
								{
									List<EventInfo> obj = list ?? new List<EventInfo>();
									list = obj;
									obj.Add(item);
								}
							}
							while (enumerator.MoveNext());
							if (list != null)
							{
								foreach (EventInfo item2 in list)
								{
									AddEventToSymbolTable(item2, owningAggregate, addedField);
								}
							}
						}
					}
				}
			}
		}

		private static List<Type> CreateInheritanceHierarchyList(Type type)
		{
			List<Type> list;
			if (type.IsInterface)
			{
				list = new List<Type>(type.GetInterfaces().Length + 2) { type };
				Type[] interfaces = type.GetInterfaces();
				foreach (Type type2 in interfaces)
				{
					LoadSymbolsFromType(type2);
					list.Add(type2);
				}
				Type typeFromHandle = typeof(object);
				LoadSymbolsFromType(typeFromHandle);
				list.Add(typeFromHandle);
			}
			else
			{
				list = new List<Type> { type };
				Type baseType = type.BaseType;
				while (baseType != null)
				{
					LoadSymbolsFromType(baseType);
					list.Add(baseType);
					baseType = baseType.BaseType;
				}
			}
			CType cTypeFromType = GetCTypeFromType(type);
			if (cTypeFromType.IsWindowsRuntimeType)
			{
				CType[] items = ((AggregateType)cTypeFromType).WinRTCollectionIfacesAll.Items;
				foreach (CType cType in items)
				{
					list.Add(cType.AssociatedSystemType);
				}
			}
			return list;
		}

		private static Name GetName(string p)
		{
			return NameManager.Add(p ?? "");
		}

		private static Name GetName(Type type)
		{
			string name = type.Name;
			if (type.IsGenericType)
			{
				int num = name.IndexOf('`');
				if (num >= 0)
				{
					return NameManager.Add(name, num);
				}
			}
			return NameManager.Add(name);
		}

		private static TypeArray GetMethodTypeParameters(MethodInfo method, MethodSymbol parent)
		{
			if (method.IsGenericMethod)
			{
				Type[] genericArguments = method.GetGenericArguments();
				CType[] array = new CType[genericArguments.Length];
				for (int i = 0; i < genericArguments.Length; i++)
				{
					Type t = genericArguments[i];
					array[i] = LoadMethodTypeParameter(parent, t);
				}
				for (int j = 0; j < genericArguments.Length; j++)
				{
					Type type = genericArguments[j];
					((TypeParameterType)array[j]).Symbol.SetBounds(TypeArray.Allocate(GetCTypeArrayFromTypes(type.GetGenericParameterConstraints())));
				}
				return TypeArray.Allocate(array);
			}
			return TypeArray.Empty;
		}

		private static TypeArray GetAggregateTypeParameters(Type type, AggregateSymbol agg)
		{
			if (type.IsGenericType)
			{
				Type genericTypeDefinition = type.GetGenericTypeDefinition();
				Type[] genericArguments = genericTypeDefinition.GetGenericArguments();
				List<CType> list = new List<CType>();
				int num = (agg.isNested() ? agg.GetOuterAgg().GetTypeVarsAll().Count : 0);
				foreach (Type type2 in genericArguments)
				{
					if (type2.GenericParameterPosition >= num)
					{
						CType cType = ((!type2.IsGenericParameter || !(type2.DeclaringType == genericTypeDefinition)) ? GetCTypeFromType(type2) : LoadClassTypeParameter(agg, type2));
						if (((TypeParameterType)cType).OwningSymbol == agg)
						{
							list.Add(cType);
						}
					}
				}
				return TypeArray.Allocate(list.ToArray());
			}
			return TypeArray.Empty;
		}

		private static TypeParameterType LoadClassTypeParameter(AggregateSymbol parent, Type t)
		{
			for (AggregateSymbol aggregateSymbol = parent; aggregateSymbol != null; aggregateSymbol = aggregateSymbol.parent as AggregateSymbol)
			{
				for (TypeParameterSymbol typeParameterSymbol = SymbolStore.LookupSym(GetName(t), aggregateSymbol, symbmask_t.MASK_TypeParameterSymbol) as TypeParameterSymbol; typeParameterSymbol != null; typeParameterSymbol = typeParameterSymbol.LookupNext(symbmask_t.MASK_TypeParameterSymbol) as TypeParameterSymbol)
				{
					if (AreTypeParametersEquivalent(typeParameterSymbol.GetTypeParameterType().AssociatedSystemType, t))
					{
						return typeParameterSymbol.GetTypeParameterType();
					}
				}
			}
			return AddTypeParameterToSymbolTable(parent, null, t, bIsAggregate: true);
		}

		private static bool AreTypeParametersEquivalent(Type t1, Type t2)
		{
			if (t1 == t2)
			{
				return true;
			}
			Type originalTypeParameterType = GetOriginalTypeParameterType(t1);
			Type originalTypeParameterType2 = GetOriginalTypeParameterType(t2);
			return originalTypeParameterType == originalTypeParameterType2;
		}

		private static Type GetOriginalTypeParameterType(Type t)
		{
			int genericParameterPosition = t.GenericParameterPosition;
			Type type = t.DeclaringType;
			if (type != null && type.IsGenericType)
			{
				type = type.GetGenericTypeDefinition();
			}
			if (t.DeclaringMethod != null && (type.GetGenericArguments() == null || genericParameterPosition >= type.GetGenericArguments().Length))
			{
				return t;
			}
			while (type.GetGenericArguments().Length > genericParameterPosition)
			{
				Type type2 = type.DeclaringType;
				if (type2 != null && type2.IsGenericType)
				{
					type2 = type2.GetGenericTypeDefinition();
				}
				if ((object)type2 == null || !(type2.GetGenericArguments()?.Length > genericParameterPosition))
				{
					break;
				}
				type = type2;
			}
			return type.GetGenericArguments()[genericParameterPosition];
		}

		private static TypeParameterType LoadMethodTypeParameter(MethodSymbol parent, Type t)
		{
			for (Symbol symbol = parent.firstChild; symbol != null; symbol = symbol.nextChild)
			{
				if (symbol is TypeParameterSymbol typeParameterSymbol)
				{
					TypeParameterType typeParameterType = typeParameterSymbol.GetTypeParameterType();
					if (AreTypeParametersEquivalent(typeParameterType.AssociatedSystemType, t))
					{
						return typeParameterType;
					}
				}
			}
			return AddTypeParameterToSymbolTable(null, parent, t, bIsAggregate: false);
		}

		private static TypeParameterType AddTypeParameterToSymbolTable(AggregateSymbol agg, MethodSymbol meth, Type t, bool bIsAggregate)
		{
			TypeParameterSymbol typeParameterSymbol = ((!bIsAggregate) ? SymFactory.CreateMethodTypeParameter(GetName(t), meth, t.GenericParameterPosition, t.GenericParameterPosition) : SymFactory.CreateClassTypeParameter(GetName(t), agg, t.GenericParameterPosition, t.GenericParameterPosition));
			if ((t.GenericParameterAttributes & GenericParameterAttributes.Covariant) != GenericParameterAttributes.None)
			{
				typeParameterSymbol.Covariant = true;
			}
			if ((t.GenericParameterAttributes & GenericParameterAttributes.Contravariant) != GenericParameterAttributes.None)
			{
				typeParameterSymbol.Contravariant = true;
			}
			SpecCons specCons = SpecCons.None;
			if ((t.GenericParameterAttributes & GenericParameterAttributes.DefaultConstructorConstraint) != GenericParameterAttributes.None)
			{
				specCons |= SpecCons.New;
			}
			if ((t.GenericParameterAttributes & GenericParameterAttributes.ReferenceTypeConstraint) != GenericParameterAttributes.None)
			{
				specCons |= SpecCons.Ref;
			}
			if ((t.GenericParameterAttributes & GenericParameterAttributes.NotNullableValueTypeConstraint) != GenericParameterAttributes.None)
			{
				specCons |= SpecCons.Val;
			}
			typeParameterSymbol.SetConstraints(specCons);
			typeParameterSymbol.SetAccess(ACCESS.ACC_PUBLIC);
			return TypeManager.GetTypeParameter(typeParameterSymbol);
		}

		private static CType LoadSymbolsFromType(Type type)
		{
			List<object> list = BuildDeclarationChain(type);
			NamespaceOrAggregateSymbol namespaceOrAggregateSymbol = NamespaceSymbol.Root;
			for (int i = 0; i < list.Count; i++)
			{
				object obj = list[i];
				if (obj is Type type2)
				{
					if (type2.IsNullableType())
					{
						return TypeManager.GetNullable(GetCTypeFromType(type2.GetGenericArguments()[0]));
					}
					AggregateSymbol aggregateSymbol = FindSymForType(SymbolStore.LookupSym(GetName(type2), namespaceOrAggregateSymbol, symbmask_t.MASK_AggregateSymbol), type2);
					if (aggregateSymbol == null)
					{
						CType cType = ProcessSpecialTypeInChain(namespaceOrAggregateSymbol, type2);
						if (cType != null)
						{
							return cType;
						}
						aggregateSymbol = AddAggregateToSymbolTable(namespaceOrAggregateSymbol, type2);
					}
					if (type2 == type)
					{
						return GetConstructedType(type, aggregateSymbol);
					}
					namespaceOrAggregateSymbol = aggregateSymbol;
				}
				else
				{
					if (obj is MethodInfo methinfo)
					{
						return ProcessMethodTypeParameter(methinfo, list[++i] as Type, namespaceOrAggregateSymbol as AggregateSymbol);
					}
					namespaceOrAggregateSymbol = AddNamespaceToSymbolTable(namespaceOrAggregateSymbol, obj as string);
				}
			}
			return null;
		}

		private static TypeParameterType ProcessMethodTypeParameter(MethodInfo methinfo, Type t, AggregateSymbol parent)
		{
			MethodSymbol methodSymbol = FindMatchingMethod(methinfo, parent);
			if (methodSymbol == null)
			{
				methodSymbol = AddMethodToSymbolTable(methinfo, parent, MethodKindEnum.Actual);
			}
			return LoadMethodTypeParameter(methodSymbol, t);
		}

		private static CType GetConstructedType(Type type, AggregateSymbol agg)
		{
			if (type.IsGenericType)
			{
				List<CType> list = new List<CType>();
				Type[] genericArguments = type.GetGenericArguments();
				foreach (Type type2 in genericArguments)
				{
					list.Add(GetCTypeFromType(type2));
				}
				TypeArray typeArgsAll = TypeArray.Allocate(list.ToArray());
				return TypeManager.GetAggregate(agg, typeArgsAll);
			}
			return agg.getThisType();
		}

		private static CType ProcessSpecialTypeInChain(NamespaceOrAggregateSymbol parent, Type t)
		{
			if (t.IsGenericParameter)
			{
				return LoadClassTypeParameter(parent as AggregateSymbol, t);
			}
			if (t.IsArray)
			{
				return TypeManager.GetArray(GetCTypeFromType(t.GetElementType()), t.GetArrayRank(), t.GetElementType().MakeArrayType() == t);
			}
			if (t.IsPointer)
			{
				return TypeManager.GetPointer(GetCTypeFromType(t.GetElementType()));
			}
			return null;
		}

		private static List<object> BuildDeclarationChain(Type callingType)
		{
			if (callingType.IsByRef)
			{
				callingType = callingType.GetElementType();
			}
			List<object> list = new List<object>();
			Type type = callingType;
			while (type != null)
			{
				list.Add(type);
				if (type.IsGenericParameter && type.DeclaringMethod != null)
				{
					MethodBase methodBase = type.DeclaringMethod;
					foreach (MethodInfo item in from m in type.DeclaringType.GetRuntimeMethods()
						where m.HasSameMetadataDefinitionAs(methodBase)
						select m)
					{
						if (item.IsGenericMethod)
						{
							list.Add(item);
						}
					}
				}
				type = type.DeclaringType;
			}
			list.Reverse();
			if (callingType.Namespace != null)
			{
				list.InsertRange(0, callingType.Namespace.Split('.'));
			}
			return list;
		}

		private static AggregateSymbol FindSymForType(Symbol sym, Type t)
		{
			while (sym != null)
			{
				if (sym is AggregateSymbol aggregateSymbol && aggregateSymbol.AssociatedSystemType.IsEquivalentTo(t.IsGenericType ? t.GetGenericTypeDefinition() : t))
				{
					return aggregateSymbol;
				}
				sym = sym.nextSameName;
			}
			return null;
		}

		private static NamespaceSymbol AddNamespaceToSymbolTable(NamespaceOrAggregateSymbol parent, string sz)
		{
			Name name = GetName(sz);
			return (SymbolStore.LookupSym(name, parent, symbmask_t.MASK_NamespaceSymbol) as NamespaceSymbol) ?? SymFactory.CreateNamespace(name, parent as NamespaceSymbol);
		}

		internal static CType[] GetCTypeArrayFromTypes(Type[] types)
		{
			int num = types.Length;
			if (num == 0)
			{
				return Array.Empty<CType>();
			}
			CType[] array = new CType[num];
			for (int i = 0; i < types.Length; i++)
			{
				Type type = types[i];
				array[i] = GetCTypeFromType(type);
			}
			return array;
		}

		internal static CType GetCTypeFromType(Type type)
		{
			if (!type.IsByRef)
			{
				return LoadSymbolsFromType(type);
			}
			return TypeManager.GetParameterModifier(LoadSymbolsFromType(type.GetElementType()), isOut: false);
		}

		private static AggregateSymbol AddAggregateToSymbolTable(NamespaceOrAggregateSymbol parent, Type type)
		{
			AggregateSymbol aggregateSymbol = SymFactory.CreateAggregate(GetName(type), parent);
			aggregateSymbol.AssociatedSystemType = (type.IsGenericType ? type.GetGenericTypeDefinition() : type);
			aggregateSymbol.AssociatedAssembly = type.Assembly;
			AggKindEnum aggKind;
			if (type.IsInterface)
			{
				aggKind = AggKindEnum.Interface;
			}
			else if (!type.IsEnum)
			{
				aggKind = (type.IsValueType ? AggKindEnum.Struct : ((!(type.BaseType != null) || (!(type.BaseType.FullName == "System.MulticastDelegate") && !(type.BaseType.FullName == "System.Delegate")) || !(type.FullName != "System.MulticastDelegate")) ? AggKindEnum.Class : AggKindEnum.Delegate));
			}
			else
			{
				aggKind = AggKindEnum.Enum;
				aggregateSymbol.SetUnderlyingType((AggregateType)GetCTypeFromType(Enum.GetUnderlyingType(type)));
			}
			aggregateSymbol.SetAggKind(aggKind);
			aggregateSymbol.SetTypeVars(TypeArray.Empty);
			ACCESS access = (type.IsPublic ? ACCESS.ACC_PUBLIC : ((!type.IsNested) ? ACCESS.ACC_INTERNAL : (type.IsNestedAssembly ? ACCESS.ACC_INTERNAL : (type.IsNestedFamORAssem ? ACCESS.ACC_INTERNALPROTECTED : (type.IsNestedPrivate ? ACCESS.ACC_PRIVATE : (type.IsNestedFamily ? ACCESS.ACC_PROTECTED : ((!type.IsNestedFamANDAssem) ? ACCESS.ACC_PUBLIC : ACCESS.ACC_INTERNAL_AND_PROTECTED)))))));
			aggregateSymbol.SetAccess(access);
			if (!type.IsGenericParameter)
			{
				aggregateSymbol.SetTypeVars(GetAggregateTypeParameters(type, aggregateSymbol));
			}
			if (type.IsGenericType)
			{
				Type[] genericArguments = type.GetGenericTypeDefinition().GetGenericArguments();
				for (int i = 0; i < aggregateSymbol.GetTypeVars().Count; i++)
				{
					Type type2 = genericArguments[i];
					if (aggregateSymbol.GetTypeVars()[i] is TypeParameterType typeParameterType)
					{
						typeParameterType.Symbol.SetBounds(TypeArray.Allocate(GetCTypeArrayFromTypes(type2.GetGenericParameterConstraints())));
					}
				}
			}
			aggregateSymbol.SetAbstract(type.IsAbstract);
			string fullName = type.FullName;
			if (type.IsGenericType)
			{
				fullName = type.GetGenericTypeDefinition().FullName;
			}
			if (fullName != null)
			{
				PredefinedType predefinedType = PredefinedTypeFacts.TryGetPredefTypeIndex(fullName);
				if (predefinedType != PredefinedType.PT_UNDEFINEDINDEX)
				{
					PredefinedTypes.InitializePredefinedType(aggregateSymbol, predefinedType);
				}
			}
			aggregateSymbol.SetSealed(type.IsSealed);
			if (type.BaseType != null)
			{
				Type type3 = type.BaseType;
				if (type3.IsGenericType)
				{
					type3 = type3.GetGenericTypeDefinition();
				}
				aggregateSymbol.SetBaseClass((AggregateType)GetCTypeFromType(type3));
			}
			aggregateSymbol.SetFirstUDConversion(null);
			SetInterfacesOnAggregate(aggregateSymbol, type);
			aggregateSymbol.SetHasPubNoArgCtor(type.GetConstructor(Type.EmptyTypes) != null);
			if (aggregateSymbol.IsDelegate())
			{
				PopulateSymbolTableWithName(".ctor", null, type);
				PopulateSymbolTableWithName("Invoke", null, type);
			}
			return aggregateSymbol;
		}

		private static void SetInterfacesOnAggregate(AggregateSymbol aggregate, Type type)
		{
			if (type.IsGenericType)
			{
				type = type.GetGenericTypeDefinition();
			}
			Type[] interfaces = type.GetInterfaces();
			aggregate.SetIfaces(TypeArray.Allocate(GetCTypeArrayFromTypes(interfaces)));
			aggregate.SetIfacesAll(aggregate.GetIfaces());
		}

		private static FieldSymbol AddFieldToSymbolTable(FieldInfo fieldInfo, AggregateSymbol aggregate)
		{
			if (SymbolStore.LookupSym(GetName(fieldInfo.Name), aggregate, symbmask_t.MASK_FieldSymbol) is FieldSymbol result)
			{
				return result;
			}
			FieldSymbol fieldSymbol = SymFactory.CreateMemberVar(GetName(fieldInfo.Name), aggregate);
			fieldSymbol.AssociatedFieldInfo = fieldInfo;
			fieldSymbol.isStatic = fieldInfo.IsStatic;
			ACCESS access = (fieldInfo.IsPublic ? ACCESS.ACC_PUBLIC : (fieldInfo.IsPrivate ? ACCESS.ACC_PRIVATE : (fieldInfo.IsFamily ? ACCESS.ACC_PROTECTED : (fieldInfo.IsAssembly ? ACCESS.ACC_INTERNAL : ((!fieldInfo.IsFamilyOrAssembly) ? ACCESS.ACC_INTERNAL_AND_PROTECTED : ACCESS.ACC_INTERNALPROTECTED)))));
			fieldSymbol.SetAccess(access);
			fieldSymbol.isReadOnly = fieldInfo.IsInitOnly;
			fieldSymbol.isEvent = false;
			fieldSymbol.SetType(GetCTypeFromType(fieldInfo.FieldType));
			return fieldSymbol;
		}

		private static Type GetTypeByName(ref Type cachedResult, string name)
		{
			if ((object)cachedResult == s_Sentinel)
			{
				Interlocked.CompareExchange(ref cachedResult, Type.GetType(name, throwOnError: false), s_Sentinel);
			}
			return cachedResult;
		}

		private static void AddEventToSymbolTable(EventInfo eventInfo, AggregateSymbol aggregate, FieldSymbol addedField)
		{
			EventSymbol eventSymbol = SymbolStore.LookupSym(GetName(eventInfo.Name), aggregate, symbmask_t.MASK_EventSymbol) as EventSymbol;
			if (eventSymbol != null)
			{
				return;
			}
			eventSymbol = SymFactory.CreateEvent(GetName(eventInfo.Name), aggregate);
			eventSymbol.AssociatedEventInfo = eventInfo;
			ACCESS access = ACCESS.ACC_PRIVATE;
			if (eventInfo.AddMethod != null)
			{
				eventSymbol.methAdd = AddMethodToSymbolTable(eventInfo.AddMethod, aggregate, MethodKindEnum.EventAccessor);
				eventSymbol.methAdd.SetEvent(eventSymbol);
				eventSymbol.isOverride = eventSymbol.methAdd.IsOverride();
				access = eventSymbol.methAdd.GetAccess();
			}
			if (eventInfo.RemoveMethod != null)
			{
				eventSymbol.methRemove = AddMethodToSymbolTable(eventInfo.RemoveMethod, aggregate, MethodKindEnum.EventAccessor);
				eventSymbol.methRemove.SetEvent(eventSymbol);
				eventSymbol.isOverride = eventSymbol.methRemove.IsOverride();
				access = eventSymbol.methRemove.GetAccess();
			}
			eventSymbol.isStatic = false;
			eventSymbol.type = GetCTypeFromType(eventInfo.EventHandlerType);
			eventSymbol.SetAccess(access);
			Type eventRegistrationTokenType = EventRegistrationTokenType;
			if ((object)eventRegistrationTokenType != null && (object)WindowsRuntimeMarshalType != null && eventSymbol.methAdd.RetType.AssociatedSystemType == eventRegistrationTokenType && eventSymbol.methRemove.Params[0].AssociatedSystemType == eventRegistrationTokenType)
			{
				eventSymbol.IsWindowsRuntimeEvent = true;
			}
			CType cType = addedField?.GetType();
			if (cType == null)
			{
				return;
			}
			if (cType == eventSymbol.type)
			{
				addedField.isEvent = true;
				return;
			}
			Type associatedSystemType = cType.AssociatedSystemType;
			if (associatedSystemType.IsConstructedGenericType && associatedSystemType.GetGenericTypeDefinition() == EventRegistrationTokenTableType && associatedSystemType.GenericTypeArguments[0] == eventSymbol.type.AssociatedSystemType)
			{
				addedField.isEvent = true;
			}
		}

		internal static void AddPredefinedPropertyToSymbolTable(AggregateSymbol type, Name property)
		{
			foreach (PropertyInfo item in from x in type.getThisType().AssociatedSystemType.GetRuntimeProperties()
				where x.Name == property.Text
				select x)
			{
				AddPropertyToSymbolTable(item, type);
			}
		}

		private static void AddPropertyToSymbolTable(PropertyInfo property, AggregateSymbol aggregate)
		{
			bool flag = property.GetIndexParameters().Length != 0 && property.DeclaringType?.GetCustomAttribute<DefaultMemberAttribute>()?.MemberName == property.Name;
			Name name = ((!flag) ? GetName(property.Name) : GetName("$Item$"));
			PropertySymbol propertySymbol = SymbolStore.LookupSym(name, aggregate, symbmask_t.MASK_PropertySymbol) as PropertySymbol;
			if (propertySymbol != null)
			{
				PropertySymbol propertySymbol2 = null;
				while (propertySymbol != null)
				{
					if (propertySymbol.AssociatedPropertyInfo.IsEquivalentTo(property))
					{
						return;
					}
					propertySymbol2 = propertySymbol;
					propertySymbol = propertySymbol.LookupNext(symbmask_t.MASK_PropertySymbol) as PropertySymbol;
				}
				propertySymbol = propertySymbol2;
				if (flag)
				{
					propertySymbol = null;
				}
			}
			if (propertySymbol == null)
			{
				if (flag)
				{
					propertySymbol = SymFactory.CreateIndexer(name, aggregate);
					propertySymbol.Params = CreateParameterArray(null, property.GetIndexParameters());
				}
				else
				{
					propertySymbol = SymFactory.CreateProperty(GetName(property.Name), aggregate);
					propertySymbol.Params = TypeArray.Empty;
				}
			}
			propertySymbol.AssociatedPropertyInfo = property;
			propertySymbol.isStatic = ((property.GetGetMethod(nonPublic: true) != null) ? property.GetGetMethod(nonPublic: true).IsStatic : property.GetSetMethod(nonPublic: true).IsStatic);
			propertySymbol.isParamArray = DoesMethodHaveParameterArray(property.GetIndexParameters());
			propertySymbol.swtSlot = null;
			propertySymbol.RetType = GetCTypeFromType(property.PropertyType);
			propertySymbol.isOperator = flag;
			if (property.GetMethod != null || property.SetMethod != null)
			{
				MethodInfo methodInfo = property.GetMethod ?? property.SetMethod;
				propertySymbol.isOverride = methodInfo.IsVirtual && methodInfo.IsHideBySig && methodInfo.GetRuntimeBaseDefinition() != methodInfo;
				propertySymbol.isHideByName = !methodInfo.IsHideBySig;
			}
			SetParameterDataForMethProp(propertySymbol, property.GetIndexParameters());
			MethodInfo getMethod = property.GetMethod;
			MethodInfo setMethod = property.SetMethod;
			ACCESS aCCESS = ACCESS.ACC_PRIVATE;
			if (getMethod != null)
			{
				propertySymbol.GetterMethod = AddMethodToSymbolTable(getMethod, aggregate, MethodKindEnum.PropAccessor);
				if (flag || propertySymbol.GetterMethod.Params.Count == 0)
				{
					propertySymbol.GetterMethod.SetProperty(propertySymbol);
				}
				else
				{
					propertySymbol.Bogus = true;
					propertySymbol.GetterMethod.SetMethKind(MethodKindEnum.Actual);
				}
				if (propertySymbol.GetterMethod.GetAccess() > aCCESS)
				{
					aCCESS = propertySymbol.GetterMethod.GetAccess();
				}
			}
			if (setMethod != null)
			{
				propertySymbol.SetterMethod = AddMethodToSymbolTable(setMethod, aggregate, MethodKindEnum.PropAccessor);
				if (flag || propertySymbol.SetterMethod.Params.Count == 1)
				{
					propertySymbol.SetterMethod.SetProperty(propertySymbol);
				}
				else
				{
					propertySymbol.Bogus = true;
					propertySymbol.SetterMethod.SetMethKind(MethodKindEnum.Actual);
				}
				if (propertySymbol.SetterMethod.GetAccess() > aCCESS)
				{
					aCCESS = propertySymbol.SetterMethod.GetAccess();
				}
			}
			propertySymbol.SetAccess(aCCESS);
		}

		internal static void AddPredefinedMethodToSymbolTable(AggregateSymbol type, Name methodName)
		{
			Type t = type.getThisType().AssociatedSystemType;
			if (methodName == NameManager.GetPredefinedName(PredefinedName.PN_CTOR))
			{
				ConstructorInfo[] constructors = t.GetConstructors();
				for (int i = 0; i < constructors.Length; i++)
				{
					AddMethodToSymbolTable(constructors[i], type, MethodKindEnum.Constructor);
				}
				return;
			}
			foreach (MethodInfo item in from m in t.GetRuntimeMethods()
				where m.Name == methodName.Text && m.DeclaringType == t
				select m)
			{
				AddMethodToSymbolTable(item, type, (item.Name == "Invoke") ? MethodKindEnum.Invoke : MethodKindEnum.Actual);
			}
		}

		private static MethodSymbol AddMethodToSymbolTable(MethodBase member, AggregateSymbol callingAggregate, MethodKindEnum kind)
		{
			MethodInfo methodInfo = member as MethodInfo;
			if (kind == MethodKindEnum.Actual && (methodInfo == null || (!methodInfo.IsStatic && methodInfo.IsSpecialName)))
			{
				return null;
			}
			MethodSymbol methodSymbol = FindMatchingMethod(member, callingAggregate);
			if (methodSymbol != null)
			{
				return methodSymbol;
			}
			ParameterInfo[] parameters = member.GetParameters();
			methodSymbol = SymFactory.CreateMethod(GetName(member.Name), callingAggregate);
			methodSymbol.AssociatedMemberInfo = member;
			methodSymbol.SetMethKind(kind);
			if (kind == MethodKindEnum.ExplicitConv || kind == MethodKindEnum.ImplicitConv)
			{
				callingAggregate.SetHasConversion();
				methodSymbol.SetConvNext(callingAggregate.GetFirstUDConversion());
				callingAggregate.SetFirstUDConversion(methodSymbol);
			}
			ACCESS access = (member.IsPublic ? ACCESS.ACC_PUBLIC : (member.IsPrivate ? ACCESS.ACC_PRIVATE : (member.IsFamily ? ACCESS.ACC_PROTECTED : (member.IsFamilyOrAssembly ? ACCESS.ACC_INTERNALPROTECTED : ((!member.IsAssembly) ? ACCESS.ACC_INTERNAL_AND_PROTECTED : ACCESS.ACC_INTERNAL)))));
			methodSymbol.SetAccess(access);
			methodSymbol.isVirtual = member.IsVirtual;
			methodSymbol.isStatic = member.IsStatic;
			if (methodInfo != null)
			{
				methodSymbol.typeVars = GetMethodTypeParameters(methodInfo, methodSymbol);
				methodSymbol.isOverride = methodInfo.IsVirtual && methodInfo.IsHideBySig && methodInfo.GetRuntimeBaseDefinition() != methodInfo;
				methodSymbol.isOperator = IsOperator(methodInfo);
				methodSymbol.swtSlot = GetSlotForOverride(methodInfo);
				methodSymbol.RetType = GetCTypeFromType(methodInfo.ReturnType);
			}
			else
			{
				methodSymbol.typeVars = TypeArray.Empty;
				methodSymbol.isOverride = false;
				methodSymbol.isOperator = false;
				methodSymbol.swtSlot = null;
				methodSymbol.RetType = VoidType.Instance;
			}
			methodSymbol.modOptCount = GetCountOfModOpts(parameters);
			methodSymbol.isParamArray = DoesMethodHaveParameterArray(parameters);
			methodSymbol.isHideByName = false;
			methodSymbol.Params = CreateParameterArray(methodSymbol.AssociatedMemberInfo, parameters);
			SetParameterDataForMethProp(methodSymbol, parameters);
			return methodSymbol;
		}

		private static void SetParameterDataForMethProp(MethodOrPropertySymbol methProp, ParameterInfo[] parameters)
		{
			if (parameters.Length != 0)
			{
				if (parameters[parameters.Length - 1].GetCustomAttribute(typeof(ParamArrayAttribute), inherit: false) != null)
				{
					methProp.isParamArray = true;
				}
				for (int i = 0; i < parameters.Length; i++)
				{
					SetParameterAttributes(methProp, parameters, i);
					methProp.ParameterNames.Add(GetName(parameters[i].Name));
				}
			}
		}

		private static void SetParameterAttributes(MethodOrPropertySymbol methProp, ParameterInfo[] parameters, int i)
		{
			ParameterInfo parameterInfo = parameters[i];
			if ((parameterInfo.Attributes & ParameterAttributes.Optional) != ParameterAttributes.None && !parameterInfo.ParameterType.IsByRef)
			{
				methProp.SetOptionalParameter(i);
				PopulateSymbolTableWithName("Value", new Type[1] { typeof(Missing) }, typeof(Missing));
			}
			if ((parameterInfo.Attributes & ParameterAttributes.HasFieldMarshal) != ParameterAttributes.None)
			{
				MarshalAsAttribute customAttribute = parameterInfo.GetCustomAttribute<MarshalAsAttribute>(inherit: false);
				if (customAttribute != null)
				{
					methProp.SetMarshalAsParameter(i, customAttribute.Value);
				}
			}
			DateTimeConstantAttribute customAttribute2 = parameterInfo.GetCustomAttribute<DateTimeConstantAttribute>(inherit: false);
			if (customAttribute2 != null)
			{
				ConstVal cv = ConstVal.Get(((DateTime)customAttribute2.Value).Ticks);
				CType predefindType = SymbolLoader.GetPredefindType(PredefinedType.PT_DATETIME);
				methProp.SetDefaultParameterValue(i, predefindType, cv);
				return;
			}
			DecimalConstantAttribute customAttribute3 = parameterInfo.GetCustomAttribute<DecimalConstantAttribute>();
			if (customAttribute3 != null)
			{
				ConstVal cv2 = ConstVal.Get(customAttribute3.Value);
				CType predefindType2 = SymbolLoader.GetPredefindType(PredefinedType.PT_DECIMAL);
				methProp.SetDefaultParameterValue(i, predefindType2, cv2);
			}
			else
			{
				if ((parameterInfo.Attributes & ParameterAttributes.HasDefault) == 0 || parameterInfo.ParameterType.IsByRef)
				{
					return;
				}
				ConstVal cv3 = default(ConstVal);
				CType predefindType3 = SymbolLoader.GetPredefindType(PredefinedType.PT_OBJECT);
				if (parameterInfo.DefaultValue != null)
				{
					object defaultValue = parameterInfo.DefaultValue;
					switch (Type.GetTypeCode(defaultValue.GetType()))
					{
					case TypeCode.Byte:
						cv3 = ConstVal.Get((byte)defaultValue);
						predefindType3 = SymbolLoader.GetPredefindType(PredefinedType.PT_BYTE);
						break;
					case TypeCode.Int16:
						cv3 = ConstVal.Get((short)defaultValue);
						predefindType3 = SymbolLoader.GetPredefindType(PredefinedType.PT_SHORT);
						break;
					case TypeCode.Int32:
						cv3 = ConstVal.Get((int)defaultValue);
						predefindType3 = SymbolLoader.GetPredefindType(PredefinedType.PT_INT);
						break;
					case TypeCode.Int64:
						cv3 = ConstVal.Get((long)defaultValue);
						predefindType3 = SymbolLoader.GetPredefindType(PredefinedType.PT_LONG);
						break;
					case TypeCode.Single:
						cv3 = ConstVal.Get((float)defaultValue);
						predefindType3 = SymbolLoader.GetPredefindType(PredefinedType.PT_FLOAT);
						break;
					case TypeCode.Double:
						cv3 = ConstVal.Get((double)defaultValue);
						predefindType3 = SymbolLoader.GetPredefindType(PredefinedType.PT_DOUBLE);
						break;
					case TypeCode.Char:
						cv3 = ConstVal.Get((char)defaultValue);
						predefindType3 = SymbolLoader.GetPredefindType(PredefinedType.PT_CHAR);
						break;
					case TypeCode.Boolean:
						cv3 = ConstVal.Get((bool)defaultValue);
						predefindType3 = SymbolLoader.GetPredefindType(PredefinedType.PT_BOOL);
						break;
					case TypeCode.SByte:
						cv3 = ConstVal.Get((sbyte)defaultValue);
						predefindType3 = SymbolLoader.GetPredefindType(PredefinedType.PT_SBYTE);
						break;
					case TypeCode.UInt16:
						cv3 = ConstVal.Get((ushort)defaultValue);
						predefindType3 = SymbolLoader.GetPredefindType(PredefinedType.PT_USHORT);
						break;
					case TypeCode.UInt32:
						cv3 = ConstVal.Get((uint)defaultValue);
						predefindType3 = SymbolLoader.GetPredefindType(PredefinedType.PT_UINT);
						break;
					case TypeCode.UInt64:
						cv3 = ConstVal.Get((ulong)defaultValue);
						predefindType3 = SymbolLoader.GetPredefindType(PredefinedType.PT_ULONG);
						break;
					case TypeCode.String:
						cv3 = ConstVal.Get((string)defaultValue);
						predefindType3 = SymbolLoader.GetPredefindType(PredefinedType.PT_STRING);
						break;
					}
				}
				methProp.SetDefaultParameterValue(i, predefindType3, cv3);
			}
		}

		private static MethodSymbol FindMatchingMethod(MemberInfo method, AggregateSymbol callingAggregate)
		{
			for (MethodSymbol methodSymbol = SymbolStore.LookupSym(GetName(method.Name), callingAggregate, symbmask_t.MASK_MethodSymbol) as MethodSymbol; methodSymbol != null; methodSymbol = methodSymbol.LookupNext(symbmask_t.MASK_MethodSymbol) as MethodSymbol)
			{
				if (methodSymbol.AssociatedMemberInfo.IsEquivalentTo(method))
				{
					return methodSymbol;
				}
			}
			return null;
		}

		private static uint GetCountOfModOpts(ParameterInfo[] parameters)
		{
			return 0u;
		}

		private static TypeArray CreateParameterArray(MemberInfo associatedInfo, ParameterInfo[] parameters)
		{
			bool flag = associatedInfo is MethodBase methodBase && (methodBase.CallingConvention & CallingConventions.VarArgs) != 0;
			CType[] array = new CType[flag ? (parameters.Length + 1) : parameters.Length];
			for (int i = 0; i < parameters.Length; i++)
			{
				array[i] = GetTypeOfParameter(parameters[i], associatedInfo);
			}
			if (flag)
			{
				array[array.Length - 1] = ArgumentListType.Instance;
			}
			return TypeArray.Allocate(array);
		}

		private static CType GetTypeOfParameter(ParameterInfo p, MemberInfo m)
		{
			Type parameterType = p.ParameterType;
			CType cType = ((!parameterType.IsGenericParameter || !(parameterType.DeclaringMethod != null) || !(parameterType.DeclaringMethod == m)) ? GetCTypeFromType(parameterType) : LoadMethodTypeParameter(FindMethodFromMemberInfo(m), parameterType));
			if (cType is ParameterModifierType parameterModifierType && p.IsOut && !p.IsIn)
			{
				cType = TypeManager.GetParameterModifier(parameterModifierType.ParameterType, isOut: true);
			}
			return cType;
		}

		private static bool DoesMethodHaveParameterArray(ParameterInfo[] parameters)
		{
			if (parameters.Length == 0)
			{
				return false;
			}
			object[] customAttributes = parameters[parameters.Length - 1].GetCustomAttributes(inherit: false);
			for (int i = 0; i < customAttributes.Length; i++)
			{
				if (customAttributes[i] is ParamArrayAttribute)
				{
					return true;
				}
			}
			return false;
		}

		private static SymWithType GetSlotForOverride(MethodInfo method)
		{
			if (method.IsVirtual && method.IsHideBySig)
			{
				MethodInfo runtimeBaseDefinition = method.GetRuntimeBaseDefinition();
				if (runtimeBaseDefinition == method)
				{
					return null;
				}
				AggregateSymbol owningAggregate = ((AggregateType)GetCTypeFromType(runtimeBaseDefinition.DeclaringType)).OwningAggregate;
				return new SymWithType(FindMethodFromMemberInfo(runtimeBaseDefinition), owningAggregate.getThisType());
			}
			return null;
		}

		private static MethodSymbol FindMethodFromMemberInfo(MemberInfo baseMemberInfo)
		{
			AggregateSymbol owningAggregate = ((AggregateType)GetCTypeFromType(baseMemberInfo.DeclaringType)).OwningAggregate;
			MethodSymbol methodSymbol = SymbolLoader.LookupAggMember(GetName(baseMemberInfo.Name), owningAggregate, symbmask_t.MASK_MethodSymbol) as MethodSymbol;
			while (methodSymbol != null && !methodSymbol.AssociatedMemberInfo.IsEquivalentTo(baseMemberInfo))
			{
				methodSymbol = methodSymbol.LookupNext(symbmask_t.MASK_MethodSymbol) as MethodSymbol;
			}
			return methodSymbol;
		}

		internal static bool AggregateContainsMethod(AggregateSymbol agg, string szName, symbmask_t mask)
		{
			return SymbolLoader.LookupAggMember(GetName(szName), agg, mask) != null;
		}

		internal static void AddConversionsForType(Type type)
		{
			if (type.IsInterface)
			{
				AddConversionsForOneType(type);
			}
			Type type2 = type;
			while (type2.BaseType != null)
			{
				AddConversionsForOneType(type2);
				type2 = type2.BaseType;
			}
		}

		private static void AddConversionsForOneType(Type type)
		{
			if (type.IsGenericType)
			{
				type = type.GetGenericTypeDefinition();
			}
			if (!s_typesWithConversionsLoaded.Add(type))
			{
				return;
			}
			CType cType = GetCTypeFromType(type);
			if (!(cType is AggregateType))
			{
				CType baseOrParameterOrElementType;
				while ((baseOrParameterOrElementType = cType.BaseOrParameterOrElementType) != null)
				{
					cType = baseOrParameterOrElementType;
				}
			}
			if (cType is TypeParameterType typeParameterType)
			{
				CType[] items = typeParameterType.Bounds.Items;
				for (int i = 0; i < items.Length; i++)
				{
					AddConversionsForType(items[i].AssociatedSystemType);
				}
				return;
			}
			AggregateSymbol owningAggregate = ((AggregateType)cType).OwningAggregate;
			foreach (MethodInfo runtimeMethod in type.GetRuntimeMethods())
			{
				if (!runtimeMethod.IsPublic || !runtimeMethod.IsStatic || !(runtimeMethod.DeclaringType == type) || !runtimeMethod.IsSpecialName || runtimeMethod.IsGenericMethod)
				{
					continue;
				}
				string name = runtimeMethod.Name;
				MethodKindEnum kind;
				if (!(name == "op_Implicit"))
				{
					if (!(name == "op_Explicit"))
					{
						continue;
					}
					kind = MethodKindEnum.ExplicitConv;
				}
				else
				{
					kind = MethodKindEnum.ImplicitConv;
				}
				AddMethodToSymbolTable(runtimeMethod, owningAggregate, kind);
			}
		}

		private static bool IsOperator(MethodInfo method)
		{
			if (method.IsSpecialName && method.IsStatic)
			{
				switch (method.Name)
				{
				case "op_Implicit":
				case "op_Explicit":
				case "op_Addition":
				case "op_Subtraction":
				case "op_Multiply":
				case "op_Division":
				case "op_Modulus":
				case "op_LeftShift":
				case "op_RightShift":
				case "op_LessThan":
				case "op_GreaterThan":
				case "op_LessThanOrEqual":
				case "op_GreaterThanOrEqual":
				case "op_Equality":
				case "op_Inequality":
				case "op_BitwiseAnd":
				case "op_ExclusiveOr":
				case "op_BitwiseOr":
				case "op_LogicalNot":
				case "op_UnaryNegation":
				case "op_UnaryPlus":
				case "op_OnesComplement":
				case "op_True":
				case "op_False":
				case "op_Increment":
				case "op_Decrement":
					return true;
				}
			}
			return false;
		}
	}
}
namespace Microsoft.CSharp.RuntimeBinder.Syntax
{
	internal static class NameManager
	{
		private static readonly Name[] s_predefinedNames = new Name[121]
		{
			new Name(".ctor"),
			new Name("Finalize"),
			new Name(".cctor"),
			new Name("*"),
			new Name("?*"),
			new Name("#"),
			new Name("&"),
			new Name("[X\001"),
			new Name("[X\002"),
			new Name("[X\003"),
			new Name("[G\001"),
			new Name("[G\002"),
			new Name("[G\003"),
			new Name("Invoke"),
			new Name("Length"),
			new Name("Item"),
			new Name("$Item$"),
			new Name("Combine"),
			new Name("Remove"),
			new Name("op_Explicit"),
			new Name("op_Implicit"),
			new Name("op_UnaryPlus"),
			new Name("op_UnaryNegation"),
			new Name("op_OnesComplement"),
			new Name("op_Increment"),
			new Name("op_Decrement"),
			new Name("op_Addition"),
			new Name("op_Subtraction"),
			new Name("op_Multiply"),
			new Name("op_Division"),
			new Name("op_Modulus"),
			new Name("op_ExclusiveOr"),
			new Name("op_BitwiseAnd"),
			new Name("op_BitwiseOr"),
			new Name("op_LeftShift"),
			new Name("op_RightShift"),
			new Name("op_Equals"),
			new Name("op_Compare"),
			new Name("op_Equality"),
			new Name("op_Inequality"),
			new Name("op_GreaterThan"),
			new Name("op_LessThan"),
			new Name("op_GreaterThanOrEqual"),
			new Name("op_LessThanOrEqual"),
			new Name("op_True"),
			new Name("op_False"),
			new Name("op_LogicalNot"),
			new Name("Concat"),
			new Name("Add"),
			new Name("get_Length"),
			new Name("get_Chars"),
			new Name("CreateDelegate"),
			new Name("FixedElementField"),
			new Name("HasValue"),
			new Name("get_HasValue"),
			new Name("Value"),
			new Name("get_Value"),
			new Name("GetValueOrDefault"),
			new Name("?"),
			new Name("<?>"),
			new Name("Lambda"),
			new Name("Parameter"),
			new Name("Constant"),
			new Name("Convert"),
			new Name("ConvertChecked"),
			new Name("AddChecked"),
			new Name("Divide"),
			new Name("Modulo"),
			new Name("Multiply"),
			new Name("MultiplyChecked"),
			new Name("Subtract"),
			new Name("SubtractChecked"),
			new Name("And"),
			new Name("Or"),
			new Name("ExclusiveOr"),
			new Name("LeftShift"),
			new Name("RightShift"),
			new Name("AndAlso"),
			new Name("OrElse"),
			new Name("Equal"),
			new Name("NotEqual"),
			new Name("GreaterThanOrEqual"),
			new Name("GreaterThan"),
			new Name("LessThan"),
			new Name("LessThanOrEqual"),
			new Name("ArrayIndex"),
			new Name("Assign"),
			new Name("Condition"),
			new Name("Field"),
			new Name("Call"),
			new Name("New"),
			new Name("Quote"),
			new Name("ArrayLength"),
			new Name("UnaryPlus"),
			new Name("Negate"),
			new Name("NegateChecked"),
			new Name("Not"),
			new Name("NewArrayInit"),
			new Name("Property"),
			new Name("AddEventHandler"),
			new Name("RemoveEventHandler"),
			new Name("InvocationList"),
			new Name("GetOrCreateEventRegistrationTokenTable"),
			new Name("void"),
			new Name(""),
			new Name("true"),
			new Name("false"),
			new Name("null"),
			new Name("base"),
			new Name("this"),
			new Name("explicit"),
			new Name("implicit"),
			new Name("__arglist"),
			new Name("__makeref"),
			new Name("__reftype"),
			new Name("__refvalue"),
			new Name("as"),
			new Name("checked"),
			new Name("is"),
			new Name("typeof"),
			new Name("unchecked")
		};

		private static readonly NameTable s_names = GetKnownNames();

		private static NameTable GetKnownNames()
		{
			NameTable nameTable = new NameTable();
			Name[] array = s_predefinedNames;
			foreach (Name name in array)
			{
				nameTable.Add(name);
			}
			return nameTable;
		}

		internal static Name Add(string key)
		{
			if (key == null)
			{
				throw Error.InternalCompilerError();
			}
			return s_names.Add(key);
		}

		internal static Name Add(string key, int length)
		{
			return s_names.Add(key, length);
		}

		internal static Name GetPredefinedName(PredefinedName id)
		{
			return s_predefinedNames[(int)id];
		}
	}
	internal sealed class NameTable
	{
		private sealed class Entry
		{
			public readonly Name Name;

			public readonly int HashCode;

			public Entry Next;

			public Entry(Name name, int hashCode, Entry next)
			{
				Name = name;
				HashCode = hashCode;
				Next = next;
			}
		}

		private Entry[] _entries;

		private int _count;

		private int _mask;

		internal NameTable()
		{
			_mask = 31;
			_entries = new Entry[_mask + 1];
		}

		public Name Add(string key)
		{
			int num = ComputeHashCode(key);
			for (Entry entry = _entries[num & _mask]; entry != null; entry = entry.Next)
			{
				if (entry.HashCode == num && entry.Name.Text.Equals(key))
				{
					return entry.Name;
				}
			}
			return AddEntry(new Name(key), num);
		}

		public Name Add(string key, int length)
		{
			int num = ComputeHashCode(key, length);
			for (Entry entry = _entries[num & _mask]; entry != null; entry = entry.Next)
			{
				if (entry.HashCode == num && Equals(entry.Name.Text, key, length))
				{
					return entry.Name;
				}
			}
			return AddEntry(new Name(key.Substring(0, length)), num);
		}

		internal void Add(Name name)
		{
			int hashCode = ComputeHashCode(name.Text);
			AddEntry(name, hashCode);
		}

		private static int ComputeHashCode(string key)
		{
			int num = key.Length;
			for (int i = 0; i < key.Length; i++)
			{
				num += (num << 7) ^ key[i];
			}
			num -= num >> 17;
			num -= num >> 11;
			return num - (num >> 5);
		}

		private static int ComputeHashCode(string key, int length)
		{
			int num = length;
			for (int i = 0; i < length; i++)
			{
				num += (num << 7) ^ key[i];
			}
			num -= num >> 17;
			num -= num >> 11;
			return num - (num >> 5);
		}

		private static bool Equals(string candidate, string key, int length)
		{
			if (candidate.Length != length)
			{
				return false;
			}
			for (int i = 0; i < candidate.Length; i++)
			{
				if (candidate[i] != key[i])
				{
					return false;
				}
			}
			return true;
		}

		private Name AddEntry(Name name, int hashCode)
		{
			int num = hashCode & _mask;
			Entry entry = new Entry(name, hashCode, _entries[num]);
			_entries[num] = entry;
			if (_count++ == _mask)
			{
				Grow();
			}
			return entry.Name;
		}

		private void Grow()
		{
			int num = _mask * 2 + 1;
			Entry[] entries = _entries;
			Entry[] array = new Entry[num + 1];
			for (int i = 0; i < entries.Length; i++)
			{
				Entry entry = entries[i];
				while (entry != null)
				{
					int num2 = entry.HashCode & num;
					Entry next = entry.Next;
					entry.Next = array[num2];
					array[num2] = entry;
					entry = next;
				}
			}
			_entries = array;
			_mask = num;
		}
	}
	internal sealed class Name
	{
		public string Text { get; }

		public Name(string text)
		{
			Text = text;
		}

		public override string ToString()
		{
			return Text;
		}
	}
	internal enum OperatorKind : uint
	{
		OP_NONE,
		OP_ASSIGN,
		OP_ADDEQ,
		OP_SUBEQ,
		OP_MULEQ,
		OP_DIVEQ,
		OP_MODEQ,
		OP_ANDEQ,
		OP_XOREQ,
		OP_OREQ,
		OP_LSHIFTEQ,
		OP_RSHIFTEQ,
		OP_QUESTION,
		OP_VALORDEF,
		OP_LOGOR,
		OP_LOGAND,
		OP_BITOR,
		OP_BITXOR,
		OP_BITAND,
		OP_EQ,
		OP_NEQ,
		OP_LT,
		OP_LE,
		OP_GT,
		OP_GE,
		OP_IS,
		OP_AS,
		OP_LSHIFT,
		OP_RSHIFT,
		OP_ADD,
		OP_SUB,
		OP_MUL,
		OP_DIV,
		OP_MOD,
		OP_NOP,
		OP_UPLUS,
		OP_NEG,
		OP_BITNOT,
		OP_LOGNOT,
		OP_PREINC,
		OP_PREDEC,
		OP_TYPEOF,
		OP_CHECKED,
		OP_UNCHECKED,
		OP_MAKEREFANY,
		OP_REFVALUE,
		OP_REFTYPE,
		OP_ARGS,
		OP_CAST,
		OP_INDIR,
		OP_ADDR,
		OP_COLON,
		OP_THIS,
		OP_BASE,
		OP_NULL,
		OP_TRUE,
		OP_FALSE,
		OP_CALL,
		OP_DEREF,
		OP_PAREN,
		OP_POSTINC,
		OP_POSTDEC,
		OP_DOT,
		OP_IMPLICIT,
		OP_EXPLICIT,
		OP_EQUALS,
		OP_COMPARE,
		OP_DEFAULT,
		OP_LAST
	}
	internal enum PredefinedName
	{
		PN_CTOR,
		PN_DTOR,
		PN_STATCTOR,
		PN_PTR,
		PN_NUB,
		PN_OUTPARAM,
		PN_REFPARAM,
		PN_ARRAY0,
		PN_ARRAY1,
		PN_ARRAY2,
		PN_GARRAY0,
		PN_GARRAY1,
		PN_GARRAY2,
		PN_INVOKE,
		PN_LENGTH,
		PN_INDEXER,
		PN_INDEXERINTERNAL,
		PN_COMBINE,
		PN_REMOVE,
		PN_OPEXPLICITMN,
		PN_OPIMPLICITMN,
		PN_OPUNARYPLUS,
		PN_OPUNARYMINUS,
		PN_OPCOMPLEMENT,
		PN_OPINCREMENT,
		PN_OPDECREMENT,
		PN_OPPLUS,
		PN_OPMINUS,
		PN_OPMULTIPLY,
		PN_OPDIVISION,
		PN_OPMODULUS,
		PN_OPXOR,
		PN_OPBITWISEAND,
		PN_OPBITWISEOR,
		PN_OPLEFTSHIFT,
		PN_OPRIGHTSHIFT,
		PN_OPEQUALS,
		PN_OPCOMPARE,
		PN_OPEQUALITY,
		PN_OPINEQUALITY,
		PN_OPGREATERTHAN,
		PN_OPLESSTHAN,
		PN_OPGREATERTHANOREQUAL,
		PN_OPLESSTHANOREQUAL,
		PN_OPTRUE,
		PN_OPFALSE,
		PN_OPNEGATION,
		PN_CONCAT,
		PN_ADD,
		PN_GETLENGTH,
		PN_GETCHARS,
		PN_CREATEDELEGATE,
		PN_FIXEDELEMENT,
		PN_HASVALUE,
		PN_GETHASVALUE,
		PN_CAP_VALUE,
		PN_GETVALUE,
		PN_GET_VALUE_OR_DEF,
		PN_MISSING,
		PN_MISSINGSYM,
		PN_LAMBDA,
		PN_PARAMETER,
		PN_CONSTANT,
		PN_CONVERT,
		PN_CONVERTCHECKED,
		PN_ADDCHECKED,
		PN_DIVIDE,
		PN_MODULO,
		PN_MULTIPLY,
		PN_MULTIPLYCHECKED,
		PN_SUBTRACT,
		PN_SUBTRACTCHECKED,
		PN_AND,
		PN_OR,
		PN_EXCLUSIVEOR,
		PN_LEFTSHIFT,
		PN_RIGHTSHIFT,
		PN_ANDALSO,
		PN_ORELSE,
		PN_EQUAL,
		PN_NOTEQUAL,
		PN_GREATERTHANOREQUAL,
		PN_GREATERTHAN,
		PN_LESSTHAN,
		PN_LESSTHANOREQUAL,
		PN_ARRAYINDEX,
		PN_ASSIGN,
		PN_CONDITION,
		PN_CAP_FIELD,
		PN_CALL,
		PN_NEW,
		PN_QUOTE,
		PN_ARRAYLENGTH,
		PN_PLUS,
		PN_NEGATE,
		PN_NEGATECHECKED,
		PN_NOT,
		PN_NEWARRAYINIT,
		PN_EXPRESSION_PROPERTY,
		PN_ADDEVENTHANDLER,
		PN_REMOVEEVENTHANDLER,
		PN_INVOCATIONLIST,
		PN_GETORCREATEEVENTREGISTRATIONTOKENTABLE,
		PN_VOID,
		PN_EMPTY,
		PN_COUNT
	}
	internal enum PredefinedType : uint
	{
		PT_BYTE = 0u,
		PT_SHORT = 1u,
		PT_INT = 2u,
		PT_LONG = 3u,
		PT_FLOAT = 4u,
		PT_DOUBLE = 5u,
		PT_DECIMAL = 6u,
		PT_CHAR = 7u,
		PT_BOOL = 8u,
		PT_SBYTE = 9u,
		PT_USHORT = 10u,
		PT_UINT = 11u,
		PT_ULONG = 12u,
		FirstNonSimpleType = 13u,
		PT_INTPTR = 13u,
		PT_UINTPTR = 14u,
		PT_OBJECT = 15u,
		PT_STRING = 16u,
		PT_DELEGATE = 17u,
		PT_MULTIDEL = 18u,
		PT_ARRAY = 19u,
		PT_TYPE = 20u,
		PT_VALUE = 21u,
		PT_ENUM = 22u,
		PT_DATETIME = 23u,
		PT_IENUMERABLE = 24u,
		PT_G_IENUMERABLE = 25u,
		PT_G_OPTIONAL = 26u,
		PT_G_IQUERYABLE = 27u,
		PT_G_ICOLLECTION = 28u,
		PT_G_ILIST = 29u,
		PT_G_EXPRESSION = 30u,
		PT_EXPRESSION = 31u,
		PT_BINARYEXPRESSION = 32u,
		PT_UNARYEXPRESSION = 33u,
		PT_CONSTANTEXPRESSION = 34u,
		PT_PARAMETEREXPRESSION = 35u,
		PT_MEMBEREXPRESSION = 36u,
		PT_METHODCALLEXPRESSION = 37u,
		PT_NEWEXPRESSION = 38u,
		PT_NEWARRAYEXPRESSION = 39u,
		PT_INVOCATIONEXPRESSION = 40u,
		PT_FIELDINFO = 41u,
		PT_METHODINFO = 42u,
		PT_CONSTRUCTORINFO = 43u,
		PT_PROPERTYINFO = 44u,
		PT_MISSING = 45u,
		PT_G_IREADONLYLIST = 46u,
		PT_G_IREADONLYCOLLECTION = 47u,
		PT_FUNC = 48u,
		PT_COUNT = 49u,
		PT_VOID = 50u,
		PT_UNDEFINEDINDEX = 4294967295u
	}
	internal static class TokenFacts
	{
		internal static string GetText(TokenKind kind)
		{
			return kind switch
			{
				TokenKind.ArgList => "__arglist", 
				TokenKind.MakeRef => "__makeref", 
				TokenKind.RefType => "__reftype", 
				TokenKind.RefValue => "__refvalue", 
				TokenKind.As => "as", 
				TokenKind.Base => "base", 
				TokenKind.Checked => "checked", 
				TokenKind.Explicit => "explicit", 
				TokenKind.False => "false", 
				TokenKind.Implicit => "implicit", 
				TokenKind.Is => "is", 
				TokenKind.Null => "null", 
				TokenKind.This => "this", 
				TokenKind.True => "true", 
				TokenKind.TypeOf => "typeof", 
				TokenKind.Unchecked => "unchecked", 
				TokenKind.Void => "void", 
				TokenKind.Equal => "=", 
				TokenKind.PlusEqual => "+=", 
				TokenKind.MinusEqual => "-=", 
				TokenKind.SplatEqual => "*=", 
				TokenKind.SlashEqual => "/=", 
				TokenKind.PercentEqual => "%=", 
				TokenKind.AndEqual => "&=", 
				TokenKind.HatEqual => "^=", 
				TokenKind.BarEqual => "|=", 
				TokenKind.LeftShiftEqual => "<<=", 
				TokenKind.RightShiftEqual => ">>=", 
				TokenKind.Question => "?", 
				TokenKind.Colon => ":", 
				TokenKind.ColonColon => "::", 
				TokenKind.LogicalOr => "||", 
				TokenKind.LogicalAnd => "&&", 
				TokenKind.Bar => "|", 
				TokenKind.Hat => "^", 
				TokenKind.Ampersand => "&", 
				TokenKind.EqualEqual => "==", 
				TokenKind.NotEqual => "!=", 
				TokenKind.LessThan => "<", 
				TokenKind.LessThanEqual => "<=", 
				TokenKind.GreaterThan => ">", 
				TokenKind.GreaterThanEqual => ">=", 
				TokenKind.LeftShift => "<<", 
				TokenKind.RightShift => ">>", 
				TokenKind.Plus => "+", 
				TokenKind.Minus => "-", 
				TokenKind.Splat => "*", 
				TokenKind.Slash => "/", 
				TokenKind.Percent => "%", 
				TokenKind.Tilde => "~", 
				TokenKind.Bang => "!", 
				TokenKind.PlusPlus => "++", 
				TokenKind.MinusMinus => "--", 
				TokenKind.Dot => ".", 
				TokenKind.QuestionQuestion => "??", 
				_ => throw Error.InternalCompilerError(), 
			};
		}
	}
	internal enum TokenKind : byte
	{
		ArgList,
		MakeRef,
		RefType,
		RefValue,
		As,
		Base,
		Checked,
		Explicit,
		False,
		Implicit,
		Is,
		Null,
		This,
		True,
		TypeOf,
		Unchecked,
		Void,
		Equal,
		PlusEqual,
		MinusEqual,
		SplatEqual,
		SlashEqual,
		PercentEqual,
		AndEqual,
		HatEqual,
		BarEqual,
		LeftShiftEqual,
		RightShiftEqual,
		Question,
		Colon,
		ColonColon,
		LogicalOr,
		LogicalAnd,
		Bar,
		Hat,
		Ampersand,
		EqualEqual,
		NotEqual,
		LessThan,
		LessThanEqual,
		GreaterThan,
		GreaterThanEqual,
		LeftShift,
		RightShift,
		Plus,
		Minus,
		Splat,
		Slash,
		Percent,
		Tilde,
		Bang,
		PlusPlus,
		MinusMinus,
		Dot,
		QuestionQuestion,
		Unknown
	}
}
namespace Microsoft.CSharp.RuntimeBinder.Semantics
{
	internal readonly struct ExpressionBinder
	{
		private sealed class BinOpArgInfo
		{
			public Expr arg1;

			public Expr arg2;

			public PredefinedType pt1;

			public PredefinedType pt2;

			public PredefinedType ptRaw1;

			public PredefinedType ptRaw2;

			public CType type1;

			public CType type2;

			public CType typeRaw1;

			public CType typeRaw2;

			public BinOpKind binopKind;

			public BinOpMask mask;

			public BinOpArgInfo(Expr op1, Expr op2)
			{
				arg1 = op1;
				arg2 = op2;
				type1 = arg1.Type;
				type2 = arg2.Type;
				typeRaw1 = type1.StripNubs();
				typeRaw2 = type2.StripNubs();
				pt1 = (type1.IsPredefined ? type1.PredefinedType : PredefinedType.PT_COUNT);
				pt2 = (type2.IsPredefined ? type2.PredefinedType : PredefinedType.PT_COUNT);
				ptRaw1 = (typeRaw1.IsPredefined ? typeRaw1.PredefinedType : PredefinedType.PT_COUNT);
				ptRaw2 = (typeRaw2.IsPredefined ? typeRaw2.PredefinedType : PredefinedType.PT_COUNT);
			}

			public bool ValidForDelegate()
			{
				return (mask & BinOpMask.Delegate) != 0;
			}

			public bool ValidForEnumAndUnderlyingType()
			{
				return (mask & BinOpMask.EnumUnder) != 0;
			}

			public bool ValidForUnderlyingTypeAndEnum()
			{
				return (mask & BinOpMask.Add) != 0;
			}

			public bool ValidForEnum()
			{
				return (mask & BinOpMask.Enum) != 0;
			}
		}

		private class BinOpSig
		{
			public PredefinedType pt1;

			public PredefinedType pt2;

			public BinOpMask mask;

			public int cbosSkip;

			public PfnBindBinOp pfn;

			public OpSigFlags grfos;

			public BinOpFuncKind fnkind;

			protected BinOpSig()
			{
			}

			public BinOpSig(PredefinedType pt1, PredefinedType pt2, BinOpMask mask, int cbosSkip, PfnBindBinOp pfn, OpSigFlags grfos, BinOpFuncKind fnkind)
			{
				this.pt1 = pt1;
				this.pt2 = pt2;
				this.mask = mask;
				this.cbosSkip = cbosSkip;
				this.pfn = pfn;
				this.grfos = grfos;
				this.fnkind = fnkind;
			}

			public bool ConvertOperandsBeforeBinding()
			{
				return (grfos & OpSigFlags.Convert) != 0;
			}

			public bool CanLift()
			{
				return (grfos & OpSigFlags.CanLift) != 0;
			}

			public bool AutoLift()
			{
				return (grfos & OpSigFlags.AutoLift) != 0;
			}
		}

		private sealed class BinOpFullSig : BinOpSig
		{
			private readonly LiftFlags _grflt;

			private readonly CType _type1;

			private readonly CType _type2;

			public BinOpFullSig(CType type1, CType type2, PfnBindBinOp pfn, OpSigFlags grfos, LiftFlags grflt, BinOpFuncKind fnkind)
			{
				pt1 = PredefinedType.PT_UNDEFINEDINDEX;
				pt2 = PredefinedType.PT_UNDEFINEDINDEX;
				mask = BinOpMask.None;
				cbosSkip = 0;
				base.pfn = pfn;
				base.grfos = grfos;
				_type1 = type1;
				_type2 = type2;
				_grflt = grflt;
				base.fnkind = fnkind;
			}

			public BinOpFullSig(ExpressionBinder fnc, BinOpSig bos)
			{
				pt1 = bos.pt1;
				pt2 = bos.pt2;
				mask = bos.mask;
				cbosSkip = bos.cbosSkip;
				pfn = bos.pfn;
				grfos = bos.grfos;
				fnkind = bos.fnkind;
				_type1 = ((pt1 != PredefinedType.PT_UNDEFINEDINDEX) ? GetPredefindType(pt1) : null);
				_type2 = ((pt2 != PredefinedType.PT_UNDEFINEDINDEX) ? GetPredefindType(pt2) : null);
				_grflt = LiftFlags.None;
			}

			public bool FPreDef()
			{
				return pt1 != PredefinedType.PT_UNDEFINEDINDEX;
			}

			public bool isLifted()
			{
				if (_grflt == LiftFlags.None)
				{
					return false;
				}
				return true;
			}

			public bool ConvertFirst()
			{
				return (_grflt & LiftFlags.Convert1) != 0;
			}

			public bool ConvertSecond()
			{
				return (_grflt & LiftFlags.Convert2) != 0;
			}

			public CType Type1()
			{
				return _type1;
			}

			public CType Type2()
			{
				return _type2;
			}
		}

		private delegate bool ConversionFunc(Expr pSourceExpr, CType pSourceType, CType pDestinationType, bool needsExprDest, out Expr ppDestinationExpr, CONVERTTYPE flags);

		private sealed class ExplicitConversion
		{
			private readonly ExpressionBinder _binder;

			private Expr _exprSrc;

			private readonly CType _typeSrc;

			private readonly CType _typeDest;

			private Expr _exprDest;

			private readonly bool _needsExprDest;

			private readonly CONVERTTYPE _flags;

			public Expr ExprDest => _exprDest;

			public ExplicitConversion(ExpressionBinder binder, Expr exprSrc, CType typeSrc, CType typeDest, bool needsExprDest, CONVERTTYPE flags)
			{
				_binder = binder;
				_exprSrc = exprSrc;
				_typeSrc = typeSrc;
				_typeDest = typeDest;
				_needsExprDest = needsExprDest;
				_flags = flags;
				_exprDest = null;
			}

			public bool Bind()
			{
				if (_binder.BindImplicitConversion(_exprSrc, _typeSrc, _typeDest, _needsExprDest, out _exprDest, _flags | CONVERTTYPE.ISEXPLICIT))
				{
					return true;
				}
				if (_typeSrc == null || _typeDest == null || _typeDest is MethodGroupType)
				{
					return false;
				}
				if (_typeDest is NullableType)
				{
					return false;
				}
				if (_typeSrc is NullableType)
				{
					return bindExplicitConversionFromNub();
				}
				if (bindExplicitConversionFromArrayToIList())
				{
					return true;
				}
				switch (_typeDest.TypeKind)
				{
				default:
					return false;
				case TypeKind.TK_VoidType:
					return false;
				case TypeKind.TK_NullType:
					return false;
				case TypeKind.TK_ArrayType:
					if (bindExplicitConversionToArray((ArrayType)_typeDest))
					{
						return true;
					}
					break;
				case TypeKind.TK_PointerType:
					if (bindExplicitConversionToPointer())
					{
						return true;
					}
					break;
				case TypeKind.TK_AggregateType:
					switch (bindExplicitConversionToAggregate(_typeDest as AggregateType))
					{
					case AggCastResult.Success:
						return true;
					case AggCastResult.Abort:
						return false;
					}
					break;
				}
				if ((_flags & CONVERTTYPE.NOUDC) == 0)
				{
					return _binder.bindUserDefinedConversion(_exprSrc, _typeSrc, _typeDest, _needsExprDest, out _exprDest, fImplicitOnly: false);
				}
				return false;
			}

			private bool bindExplicitConversionFromNub()
			{
				if (_typeDest.IsValueType && _binder.BindExplicitConversion(null, _typeSrc.StripNubs(), _typeDest, _flags | CONVERTTYPE.NOUDC))
				{
					if (_needsExprDest)
					{
						Expr expr = _exprSrc;
						if (expr.Type is NullableType)
						{
							expr = BindNubValue(expr);
						}
						if (!_binder.BindExplicitConversion(expr, expr.Type, _typeDest, _needsExprDest, out _exprDest, _flags | CONVERTTYPE.NOUDC))
						{
							return false;
						}
						if (_exprDest is ExprUserDefinedConversion exprUserDefinedConversion)
						{
							exprUserDefinedConversion.Argument = _exprSrc;
						}
					}
					return true;
				}
				if ((_flags & CONVERTTYPE.NOUDC) == 0)
				{
					return _binder.bindUserDefinedConversion(_exprSrc, _typeSrc, _typeDest, _needsExprDest, out _exprDest, fImplicitOnly: false);
				}
				return false;
			}

			private bool bindExplicitConversionFromArrayToIList()
			{
				if (!(_typeSrc is ArrayType { IsSZArray: not false } arrayType) || !(_typeDest is AggregateType { IsInterfaceType: not false } aggregateType) || aggregateType.TypeArgsAll.Count != 1)
				{
					return false;
				}
				AggregateSymbol predefAgg = SymbolLoader.GetPredefAgg(PredefinedType.PT_G_ILIST);
				AggregateSymbol predefAgg2 = SymbolLoader.GetPredefAgg(PredefinedType.PT_G_IREADONLYLIST);
				if ((predefAgg == null || !SymbolLoader.IsBaseAggregate(predefAgg, aggregateType.OwningAggregate)) && (predefAgg2 == null || !SymbolLoader.IsBaseAggregate(predefAgg2, aggregateType.OwningAggregate)))
				{
					return false;
				}
				CType elementType = arrayType.ElementType;
				CType typeDst = aggregateType.TypeArgsAll[0];
				if (!CConversions.FExpRefConv(elementType, typeDst))
				{
					return false;
				}
				if (_needsExprDest)
				{
					_binder.bindSimpleCast(_exprSrc, _typeDest, out _exprDest, EXPRFLAG.EXF_OPERATOR);
				}
				return true;
			}

			private bool bindExplicitConversionFromIListToArray(ArrayType arrayDest)
			{
				if (!arrayDest.IsSZArray || !(_typeSrc is AggregateType { IsInterfaceType: not false } aggregateType) || aggregateType.TypeArgsAll.Count != 1)
				{
					return false;
				}
				AggregateSymbol predefAgg = SymbolLoader.GetPredefAgg(PredefinedType.PT_G_ILIST);
				AggregateSymbol predefAgg2 = SymbolLoader.GetPredefAgg(PredefinedType.PT_G_IREADONLYLIST);
				if ((predefAgg == null || !SymbolLoader.IsBaseAggregate(predefAgg, aggregateType.OwningAggregate)) && (predefAgg2 == null || !SymbolLoader.IsBaseAggregate(predefAgg2, aggregateType.OwningAggregate)))
				{
					return false;
				}
				CType elementType = arrayDest.ElementType;
				CType cType = aggregateType.TypeArgsAll[0];
				if (elementType != cType && !CConversions.FExpRefConv(elementType, cType))
				{
					return false;
				}
				if (_needsExprDest)
				{
					_binder.bindSimpleCast(_exprSrc, _typeDest, out _exprDest, EXPRFLAG.EXF_OPERATOR);
				}
				return true;
			}

			private bool bindExplicitConversionFromArrayToArray(ArrayType arraySrc, ArrayType arrayDest)
			{
				if (arraySrc.Rank != arrayDest.Rank || arraySrc.IsSZArray != arrayDest.IsSZArray)
				{
					return false;
				}
				if (CConversions.FExpRefConv(arraySrc.ElementType, arrayDest.ElementType))
				{
					if (_needsExprDest)
					{
						_binder.bindSimpleCast(_exprSrc, _typeDest, out _exprDest, EXPRFLAG.EXF_OPERATOR);
					}
					return true;
				}
				return false;
			}

			private bool bindExplicitConversionToArray(ArrayType arrayDest)
			{
				if (_typeSrc is ArrayType arraySrc)
				{
					return bindExplicitConversionFromArrayToArray(arraySrc, arrayDest);
				}
				if (bindExplicitConversionFromIListToArray(arrayDest))
				{
					return true;
				}
				if (_binder.canConvert(GetPredefindType(PredefinedType.PT_ARRAY), _typeSrc, CONVERTTYPE.NOUDC))
				{
					if (_needsExprDest)
					{
						_binder.bindSimpleCast(_exprSrc, _typeDest, out _exprDest, EXPRFLAG.EXF_OPERATOR);
					}
					return true;
				}
				return false;
			}

			private bool bindExplicitConversionToPointer()
			{
				if (_typeSrc is PointerType || (_typeSrc.FundamentalType <= FUNDTYPE.FT_U8 && _typeSrc.IsNumericType))
				{
					if (_needsExprDest)
					{
						_binder.bindSimpleCast(_exprSrc, _typeDest, out _exprDest);
					}
					return true;
				}
				return false;
			}

			private AggCastResult bindExplicitConversionFromEnumToAggregate(AggregateType aggTypeDest)
			{
				if (!_typeSrc.IsEnumType)
				{
					return AggCastResult.Failure;
				}
				AggregateSymbol owningAggregate = aggTypeDest.OwningAggregate;
				if (owningAggregate.isPredefAgg(PredefinedType.PT_DECIMAL))
				{
					return bindExplicitConversionFromEnumToDecimal(aggTypeDest);
				}
				if (!owningAggregate.getThisType().IsNumericType && !owningAggregate.IsEnum() && (!owningAggregate.IsPredefined() || owningAggregate.GetPredefType() != PredefinedType.PT_CHAR))
				{
					return AggCastResult.Failure;
				}
				if (_exprSrc.GetConst() != null)
				{
					switch (_binder.bindConstantCast(_exprSrc, _typeDest, _needsExprDest, out _exprDest, explicitConversion: true))
					{
					case ConstCastResult.Success:
						return AggCastResult.Success;
					case ConstCastResult.CheckFailure:
						return AggCastResult.Abort;
					}
				}
				if (_needsExprDest)
				{
					_binder.bindSimpleCast(_exprSrc, _typeDest, out _exprDest);
				}
				return AggCastResult.Success;
			}

			private AggCastResult bindExplicitConversionFromDecimalToEnum(AggregateType aggTypeDest)
			{
				if (_exprSrc.GetConst() != null)
				{
					switch (_binder.bindConstantCast(_exprSrc, _typeDest, _needsExprDest, out _exprDest, explicitConversion: true))
					{
					case ConstCastResult.Success:
						return AggCastResult.Success;
					case ConstCastResult.CheckFailure:
						if ((_flags & CONVERTTYPE.CHECKOVERFLOW) == 0)
						{
							return AggCastResult.Abort;
						}
						break;
					}
				}
				bool flag = true;
				if (_needsExprDest)
				{
					CType underlyingEnumType = aggTypeDest.UnderlyingEnumType;
					flag = _binder.bindUserDefinedConversion(_exprSrc, _typeSrc, underlyingEnumType, _needsExprDest, out _exprDest, fImplicitOnly: false);
					if (flag)
					{
						_binder.bindSimpleCast(_exprDest, _typeDest, out _exprDest);
					}
				}
				if (!flag)
				{
					return AggCastResult.Failure;
				}
				return AggCastResult.Success;
			}

			private AggCastResult bindExplicitConversionFromEnumToDecimal(AggregateType aggTypeDest)
			{
				AggregateType underlyingEnumType = _typeSrc.UnderlyingEnumType;
				Expr pexprDest;
				if (_exprSrc == null)
				{
					pexprDest = null;
				}
				else
				{
					_binder.bindSimpleCast(_exprSrc, underlyingEnumType, out pexprDest);
				}
				if (pexprDest.GetConst() != null)
				{
					switch (_binder.bindConstantCast(pexprDest, _typeDest, _needsExprDest, out _exprDest, explicitConversion: true))
					{
					case ConstCastResult.Success:
						return AggCastResult.Success;
					case ConstCastResult.CheckFailure:
						if ((_flags & CONVERTTYPE.CHECKOVERFLOW) == 0)
						{
							return AggCastResult.Abort;
						}
						break;
					}
				}
				if (_needsExprDest)
				{
					_binder.bindUserDefinedConversion(pexprDest, underlyingEnumType, aggTypeDest, _needsExprDest, out _exprDest, fImplicitOnly: false);
				}
				return AggCastResult.Success;
			}

			private AggCastResult bindExplicitConversionToEnum(AggregateType aggTypeDest)
			{
				if (!aggTypeDest.OwningAggregate.IsEnum())
				{
					return AggCastResult.Failure;
				}
				if (_typeSrc.IsPredefType(PredefinedType.PT_DECIMAL))
				{
					return bindExplicitConversionFromDecimalToEnum(aggTypeDest);
				}
				if (_typeSrc.IsNumericType || (_typeSrc.IsPredefined && _typeSrc.PredefinedType == PredefinedType.PT_CHAR))
				{
					if (_exprSrc.GetConst() != null)
					{
						switch (_binder.bindConstantCast(_exprSrc, _typeDest, _needsExprDest, out _exprDest, explicitConversion: true))
						{
						case ConstCastResult.Success:
							return AggCastResult.Success;
						case ConstCastResult.CheckFailure:
							return AggCastResult.Abort;
						}
					}
					if (_needsExprDest)
					{
						_binder.bindSimpleCast(_exprSrc, _typeDest, out _exprDest);
					}
					return AggCastResult.Success;
				}
				if (_typeSrc.IsPredefined && (_typeSrc.IsPredefType(PredefinedType.PT_OBJECT) || _typeSrc.IsPredefType(PredefinedType.PT_VALUE) || _typeSrc.IsPredefType(PredefinedType.PT_ENUM)))
				{
					if (_needsExprDest)
					{
						_binder.bindSimpleCast(_exprSrc, _typeDest, out _exprDest, EXPRFLAG.EXF_INDEXER);
					}
					return AggCastResult.Success;
				}
				return AggCastResult.Failure;
			}

			private AggCastResult bindExplicitConversionBetweenSimpleTypes(AggregateType aggTypeDest)
			{
				if (!_typeSrc.IsSimpleType || !aggTypeDest.IsSimpleType)
				{
					return AggCastResult.Failure;
				}
				AggregateSymbol owningAggregate = aggTypeDest.OwningAggregate;
				PredefinedType predefinedType = _typeSrc.PredefinedType;
				PredefinedType predefType = owningAggregate.GetPredefType();
				if (GetConvKind(predefinedType, predefType) != ConvKind.Explicit)
				{
					return AggCastResult.Failure;
				}
				if (_exprSrc.GetConst() != null)
				{
					switch (_binder.bindConstantCast(_exprSrc, _typeDest, _needsExprDest, out _exprDest, explicitConversion: true))
					{
					case ConstCastResult.Success:
						return AggCastResult.Success;
					case ConstCastResult.CheckFailure:
						if ((_flags & CONVERTTYPE.CHECKOVERFLOW) == 0)
						{
							return AggCastResult.Abort;
						}
						break;
					}
				}
				bool flag = true;
				if (_needsExprDest)
				{
					if (isUserDefinedConversion(predefinedType, predefType))
					{
						flag = _binder.bindUserDefinedConversion(_exprSrc, _typeSrc, aggTypeDest, _needsExprDest, out _exprDest, fImplicitOnly: false);
					}
					else
					{
						_binder.bindSimpleCast(_exprSrc, _typeDest, out _exprDest, ((_flags & CONVERTTYPE.CHECKOVERFLOW) != 0) ? EXPRFLAG.EXF_CHECKOVERFLOW : ((EXPRFLAG)0));
					}
				}
				if (!flag)
				{
					return AggCastResult.Failure;
				}
				return AggCastResult.Success;
			}

			private AggCastResult bindExplicitConversionBetweenAggregates(AggregateType aggTypeDest)
			{
				if (!(_typeSrc is AggregateType { OwningAggregate: var owningAggregate } aggregateType))
				{
					return AggCastResult.Failure;
				}
				AggregateSymbol owningAggregate2 = aggTypeDest.OwningAggregate;
				if (SymbolLoader.HasBaseConversion(aggTypeDest, aggregateType))
				{
					if (_needsExprDest)
					{
						ref readonly ExpressionBinder binder = ref _binder;
						Expr exprSrc = _exprSrc;
						CType typeDest = _typeDest;
						ref Expr exprDest = ref _exprDest;
						int exprFlags;
						if (!owningAggregate2.IsValueType() || owningAggregate.getThisType().FundamentalType != FUNDTYPE.FT_REF)
						{
							Expr exprSrc2 = _exprSrc;
							exprFlags = (int)(EXPRFLAG.EXF_OPERATOR | ((exprSrc2 != null) ? (exprSrc2.Flags & EXPRFLAG.EXF_CANTBENULL) : ((EXPRFLAG)0)));
						}
						else
						{
							exprFlags = 4;
						}
						binder.bindSimpleCast(exprSrc, typeDest, out exprDest, (EXPRFLAG)exprFlags);
					}
					return AggCastResult.Success;
				}
				if ((owningAggregate.IsClass() && !owningAggregate.IsSealed() && owningAggregate2.IsInterface()) || (owningAggregate.IsInterface() && owningAggregate2.IsClass() && !owningAggregate2.IsSealed()) || (owningAggregate.IsInterface() && owningAggregate2.IsInterface()) || CConversions.HasGenericDelegateExplicitReferenceConversion(_typeSrc, aggTypeDest))
				{
					if (_needsExprDest)
					{
						ref readonly ExpressionBinder binder2 = ref _binder;
						Expr exprSrc3 = _exprSrc;
						CType typeDest2 = _typeDest;
						ref Expr exprDest2 = ref _exprDest;
						Expr exprSrc4 = _exprSrc;
						binder2.bindSimpleCast(exprSrc3, typeDest2, out exprDest2, EXPRFLAG.EXF_OPERATOR | ((exprSrc4 != null) ? (exprSrc4.Flags & EXPRFLAG.EXF_CANTBENULL) : ((EXPRFLAG)0)));
					}
					return AggCastResult.Success;
				}
				return AggCastResult.Failure;
			}

			private AggCastResult bindExplicitConversionFromPointerToInt(AggregateType aggTypeDest)
			{
				if (!(_typeSrc is PointerType) || aggTypeDest.FundamentalType > FUNDTYPE.FT_U8 || !aggTypeDest.IsNumericType)
				{
					return AggCastResult.Failure;
				}
				if (_needsExprDest)
				{
					_binder.bindSimpleCast(_exprSrc, _typeDest, out _exprDest);
				}
				return AggCastResult.Success;
			}

			private AggCastResult bindExplicitConversionToAggregate(AggregateType aggTypeDest)
			{
				AggCastResult aggCastResult = bindExplicitConversionFromEnumToAggregate(aggTypeDest);
				if (aggCastResult != AggCastResult.Failure)
				{
					return aggCastResult;
				}
				aggCastResult = bindExplicitConversionToEnum(aggTypeDest);
				if (aggCastResult != AggCastResult.Failure)
				{
					return aggCastResult;
				}
				aggCastResult = bindExplicitConversionBetweenSimpleTypes(aggTypeDest);
				if (aggCastResult != AggCastResult.Failure)
				{
					return aggCastResult;
				}
				aggCastResult = bindExplicitConversionBetweenAggregates(aggTypeDest);
				if (aggCastResult != AggCastResult.Failure)
				{
					return aggCastResult;
				}
				aggCastResult = bindExplicitConversionFromPointerToInt(aggTypeDest);
				if (aggCastResult != AggCastResult.Failure)
				{
					return aggCastResult;
				}
				if (_typeSrc is VoidType)
				{
					return AggCastResult.Abort;
				}
				return AggCastResult.Failure;
			}
		}

		private delegate Expr PfnBindBinOp(ExpressionBinder binder, ExpressionKind ek, EXPRFLAG flags, Expr op1, Expr op2);

		private delegate Expr PfnBindUnaOp(ExpressionBinder binder, ExpressionKind ek, EXPRFLAG flags, Expr op);

		public enum NamedArgumentsKind
		{
			None,
			Positioning,
			NonTrailing
		}

		internal sealed class GroupToArgsBinder
		{
			private enum Result
			{
				Success,
				Failure_SearchForExpanded,
				Failure_NoSearchForExpanded
			}

			private readonly ExpressionBinder _pExprBinder;

			private bool _fCandidatesUnsupported;

			private readonly BindingFlag _fBindFlags;

			private readonly ExprMemberGroup _pGroup;

			private readonly ArgInfos _pArguments;

			private readonly ArgInfos _pOriginalArguments;

			private readonly NamedArgumentsKind _namedArgumentsKind;

			private AggregateType _pCurrentType;

			private MethodOrPropertySymbol _pCurrentSym;

			private TypeArray _pCurrentTypeArgs;

			private TypeArray _pCurrentParameters;

			private int _nArgBest;

			private readonly GroupToArgsBinderResult _results;

			private readonly List<CandidateFunctionMember> _methList;

			private readonly MethPropWithInst _mpwiParamTypeConstraints;

			private readonly MethPropWithInst _mpwiBogus;

			private readonly MethPropWithInst _misnamed;

			private readonly MethPropWithInst _mpwiCantInferInstArg;

			private readonly MethWithType _mwtBadArity;

			private Name _pInvalidSpecifiedName;

			private Name _pNameUsedInPositionalArgument;

			private Name _pDuplicateSpecifiedName;

			private readonly List<CType> _HiddenTypes;

			private bool _bArgumentsChangedForNamedOrOptionalArguments;

			public GroupToArgsBinder(ExpressionBinder exprBinder, BindingFlag bindFlags, ExprMemberGroup grp, ArgInfos args, ArgInfos originalArgs, NamedArgumentsKind namedArgumentsKind)
			{
				_pExprBinder = exprBinder;
				_fCandidatesUnsupported = false;
				_fBindFlags = bindFlags;
				_pGroup = grp;
				_pArguments = args;
				_pOriginalArguments = originalArgs;
				_namedArgumentsKind = namedArgumentsKind;
				_pCurrentType = null;
				_pCurrentSym = null;
				_pCurrentTypeArgs = null;
				_pCurrentParameters = null;
				_nArgBest = -1;
				_results = new GroupToArgsBinderResult();
				_methList = new List<CandidateFunctionMember>();
				_mpwiParamTypeConstraints = new MethPropWithInst();
				_mpwiBogus = new MethPropWithInst();
				_misnamed = new MethPropWithInst();
				_mpwiCantInferInstArg = new MethPropWithInst();
				_mwtBadArity = new MethWithType();
				_HiddenTypes = new List<CType>();
			}

			public void Bind()
			{
				LookForCandidates();
				if (!GetResultOfBind())
				{
					throw ReportErrorsOnFailure();
				}
			}

			public GroupToArgsBinderResult GetResultsOfBind()
			{
				return _results;
			}

			private static CType GetTypeQualifier(ExprMemberGroup pGroup)
			{
				if ((pGroup.Flags & EXPRFLAG.EXF_CTOR) == 0)
				{
					return pGroup.OptionalObject?.Type;
				}
				return pGroup.ParentType;
			}

			private void LookForCandidates()
			{
				bool flag = false;
				bool flag2 = true;
				bool flag3 = true;
				bool flag4 = false;
				symbmask_t mask = (symbmask_t)(1 << (int)_pGroup.SymKind);
				CMemberLookupResults.CMethodIterator methodIterator = _pGroup.MemberLookupResults.GetMethodIterator(GetTypeQualifier(_pGroup), _pExprBinder.ContextForMemberLookup, _pGroup.TypeArgs.Count, _pGroup.Flags, mask, (_namedArgumentsKind == NamedArgumentsKind.NonTrailing) ? _pOriginalArguments : null);
				while (true)
				{
					bool flag5 = false;
					if (flag2 && !flag)
					{
						flag5 = (flag = ConstructExpandedParameters());
					}
					if (!flag5)
					{
						flag = false;
						if (!GetNextSym(methodIterator))
						{
							break;
						}
						_pCurrentParameters = _pCurrentSym.Params;
						flag2 = true;
					}
					if (_bArgumentsChangedForNamedOrOptionalArguments)
					{
						_bArgumentsChangedForNamedOrOptionalArguments = false;
						CopyArgInfos(_pOriginalArguments, _pArguments);
					}
					if (_namedArgumentsKind == NamedArgumentsKind.Positioning)
					{
						if (!ReOrderArgsForNamedArguments())
						{
							continue;
						}
					}
					else if (HasOptionalParameters() && !AddArgumentsForOptionalParameters())
					{
						continue;
					}
					if (!flag5)
					{
						flag4 = true;
						flag3 &= CSemanticChecker.CheckBogus(_pCurrentSym);
						if (_pCurrentParameters.Count != _pArguments.carg)
						{
							flag2 = true;
							continue;
						}
					}
					if (!methodIterator.CanUseCurrentSymbol)
					{
						continue;
					}
					Result result = DetermineCurrentTypeArgs();
					if (result != Result.Success)
					{
						flag2 = result == Result.Failure_SearchForExpanded;
						continue;
					}
					bool flag6 = !methodIterator.IsCurrentSymbolInaccessible;
					if (!flag6 && (!_methList.IsEmpty() || (bool)_results.InaccessibleResult))
					{
						flag2 = false;
						continue;
					}
					bool flag7 = flag6 && methodIterator.IsCurrentSymbolMisnamed;
					if (flag7 && (!_methList.IsEmpty() || (bool)_results.InaccessibleResult || (bool)_misnamed))
					{
						flag2 = false;
						continue;
					}
					bool flag8 = flag6 && !flag7 && methodIterator.IsCurrentSymbolBogus;
					if (flag8 && (!_methList.IsEmpty() || (bool)_results.InaccessibleResult || (bool)_mpwiBogus || (bool)_misnamed))
					{
						flag2 = false;
						continue;
					}
					if (!ArgumentsAreConvertible())
					{
						flag2 = true;
						continue;
					}
					if (!flag6)
					{
						_results.InaccessibleResult.Set(_pCurrentSym, _pCurrentType, _pCurrentTypeArgs);
					}
					else if (flag7)
					{
						_misnamed.Set(_pCurrentSym, _pCurrentType, _pCurrentTypeArgs);
					}
					else if (flag8)
					{
						_mpwiBogus.Set(_pCurrentSym, _pCurrentType, _pCurrentTypeArgs);
					}
					else
					{
						_methList.Add(new CandidateFunctionMember(new MethPropWithInst(_pCurrentSym, _pCurrentType, _pCurrentTypeArgs), _pCurrentParameters, 0, flag));
						if (_pCurrentType.IsInterfaceType)
						{
							CType[] items = _pCurrentType.IfacesAll.Items;
							for (int i = 0; i < items.Length; i++)
							{
								AggregateType item = (AggregateType)items[i];
								_HiddenTypes.Add(item);
							}
							AggregateType predefindType = SymbolLoader.GetPredefindType(PredefinedType.PT_OBJECT);
							_HiddenTypes.Add(predefindType);
						}
					}
					flag2 = false;
				}
				_fCandidatesUnsupported = flag3 && flag4;
				if (_bArgumentsChangedForNamedOrOptionalArguments)
				{
					CopyArgInfos(_pOriginalArguments, _pArguments);
				}
			}

			private static void CopyArgInfos(ArgInfos src, ArgInfos dst)
			{
				dst.carg = src.carg;
				dst.types = src.types;
				dst.prgexpr.Clear();
				for (int i = 0; i < src.prgexpr.Count; i++)
				{
					dst.prgexpr.Add(src.prgexpr[i]);
				}
			}

			private bool GetResultOfBind()
			{
				if (!_methList.IsEmpty())
				{
					CandidateFunctionMember candidateFunctionMember;
					if (_methList.Count == 1)
					{
						candidateFunctionMember = _methList.Head();
					}
					else
					{
						CType pTypeThrough = _pGroup.OptionalObject?.Type;
						candidateFunctionMember = _pExprBinder.FindBestMethod(_methList, pTypeThrough, _pArguments, out var methAmbig, out var methAmbig2);
						if (candidateFunctionMember == null)
						{
							_results.AmbiguousResult = methAmbig2.mpwi;
							if (methAmbig.@params != methAmbig2.@params || methAmbig.mpwi.MethProp().Params.Count != methAmbig2.mpwi.MethProp().Params.Count || methAmbig.mpwi.TypeArgs != methAmbig2.mpwi.TypeArgs || methAmbig.mpwi.GetType() != methAmbig2.mpwi.GetType() || methAmbig.mpwi.MethProp().Params == methAmbig2.mpwi.MethProp().Params)
							{
								throw ErrorHandling.Error(ErrorCode.ERR_AmbigCall, methAmbig.mpwi, methAmbig2.mpwi);
							}
							throw ErrorHandling.Error(ErrorCode.ERR_AmbigCall, methAmbig.mpwi.MethProp(), methAmbig2.mpwi.MethProp());
						}
					}
					_results.BestResult = candidateFunctionMember.mpwi;
					ReportErrorsOnSuccess();
					return true;
				}
				return false;
			}

			private bool ReOrderArgsForNamedArguments()
			{
				MethodOrPropertySymbol methodOrPropertySymbol = FindMostDerivedMethod(_pCurrentSym, _pGroup.OptionalObject);
				if (methodOrPropertySymbol == null)
				{
					return false;
				}
				int count = _pCurrentParameters.Count;
				if (count == 0 || count < _pArguments.carg)
				{
					return false;
				}
				if (!NamedArgumentNamesAppearInParameterList(methodOrPropertySymbol))
				{
					return false;
				}
				_bArgumentsChangedForNamedOrOptionalArguments = ReOrderArgsForNamedArguments(methodOrPropertySymbol, _pCurrentParameters, _pCurrentType, _pGroup, _pArguments);
				return _bArgumentsChangedForNamedOrOptionalArguments;
			}

			internal static bool ReOrderArgsForNamedArguments(MethodOrPropertySymbol methprop, TypeArray pCurrentParameters, AggregateType pCurrentType, ExprMemberGroup pGroup, ArgInfos pArguments)
			{
				int count = pCurrentParameters.Count;
				Expr[] array = new Expr[count];
				int num = 0;
				Expr expr = null;
				TypeArray typeArray = TypeManager.SubstTypeArray(pCurrentParameters, pCurrentType, pGroup.TypeArgs);
				foreach (Name parameterName in methprop.ParameterNames)
				{
					if (num >= pCurrentParameters.Count)
					{
						break;
					}
					if (methprop.isParamArray && num < pArguments.carg && pArguments.prgexpr[num] is ExprArrayInit { GeneratedForParamArray: not false })
					{
						expr = pArguments.prgexpr[num];
					}
					if (num < pArguments.carg && !(pArguments.prgexpr[num] is ExprNamedArgumentSpecification) && !(pArguments.prgexpr[num] is ExprArrayInit { GeneratedForParamArray: not false }))
					{
						array[num] = pArguments.prgexpr[num++];
						continue;
					}
					Expr expr2 = FindArgumentWithName(pArguments, parameterName);
					if (expr2 == null)
					{
						if (methprop.IsParameterOptional(num))
						{
							expr2 = GenerateOptionalArgument(methprop, typeArray[num], num);
						}
						else
						{
							if (expr == null || num != methprop.Params.Count - 1)
							{
								return false;
							}
							expr2 = expr;
						}
					}
					array[num++] = expr2;
				}
				CType[] array2 = new CType[pCurrentParameters.Count];
				for (int i = 0; i < count; i++)
				{
					if (i < pArguments.prgexpr.Count)
					{
						pArguments.prgexpr[i] = array[i];
					}
					else
					{
						pArguments.prgexpr.Add(array[i]);
					}
					array2[i] = pArguments.prgexpr[i].Type;
				}
				pArguments.carg = pCurrentParameters.Count;
				pArguments.types = TypeArray.Allocate(array2);
				return true;
			}

			private static Expr GenerateOptionalArgument(MethodOrPropertySymbol methprop, CType type, int index)
			{
				CType cType = type.StripNubs();
				Expr expr;
				if (methprop.HasDefaultParameterValue(index))
				{
					CType defaultParameterValueConstValType = methprop.GetDefaultParameterValueConstValType(index);
					ConstVal defaultParameterValue = methprop.GetDefaultParameterValue(index);
					expr = ((defaultParameterValueConstValType.IsPredefType(PredefinedType.PT_DATETIME) && (cType.IsPredefType(PredefinedType.PT_DATETIME) || cType.IsPredefType(PredefinedType.PT_OBJECT) || cType.IsPredefType(PredefinedType.PT_VALUE))) ? ExprFactory.CreateConstant(SymbolLoader.GetPredefindType(PredefinedType.PT_DATETIME), ConstVal.Get(DateTime.FromBinary(defaultParameterValue.Int64Val))) : (defaultParameterValueConstValType.IsSimpleOrEnumOrString ? ExprFactory.CreateConstant((cType.IsEnumType && defaultParameterValueConstValType == cType.UnderlyingEnumType) ? cType : defaultParameterValueConstValType, defaultParameterValue) : (((!type.IsReferenceType && !(type is NullableType)) || !defaultParameterValue.IsNullRef) ? ExprFactory.CreateZeroInit(type) : ExprFactory.CreateNull())));
				}
				else if (type.IsPredefType(PredefinedType.PT_OBJECT))
				{
					if (methprop.MarshalAsObject(index))
					{
						expr = ExprFactory.CreateNull();
					}
					else
					{
						AggregateSymbol predefAgg = SymbolLoader.GetPredefAgg(PredefinedType.PT_MISSING);
						FieldWithType field = new FieldWithType(SymbolLoader.LookupAggMember(NameManager.GetPredefinedName(PredefinedName.PN_CAP_VALUE), predefAgg, symbmask_t.MASK_FieldSymbol) as FieldSymbol, predefAgg.getThisType());
						ExprField argument = ExprFactory.CreateField(predefAgg.getThisType(), null, field);
						expr = ExprFactory.CreateCast(type, argument);
					}
				}
				else
				{
					expr = ExprFactory.CreateZeroInit(type);
				}
				expr.IsOptionalArgument = true;
				return expr;
			}

			private static MethodOrPropertySymbol FindMostDerivedMethod(MethodOrPropertySymbol pMethProp, Expr pObject)
			{
				return FindMostDerivedMethod(pMethProp, pObject?.Type);
			}

			public static MethodOrPropertySymbol FindMostDerivedMethod(MethodOrPropertySymbol pMethProp, CType pType)
			{
				bool flag = false;
				MethodSymbol methodSymbol = pMethProp as MethodSymbol;
				if (methodSymbol == null)
				{
					PropertySymbol propertySymbol = (PropertySymbol)pMethProp;
					methodSymbol = propertySymbol.GetterMethod ?? propertySymbol.SetterMethod;
					if (methodSymbol == null)
					{
						return null;
					}
					flag = propertySymbol is IndexerSymbol;
				}
				if (!methodSymbol.isVirtual || pType == null)
				{
					return methodSymbol;
				}
				MethodSymbol methodSymbol2 = methodSymbol.swtSlot?.Meth();
				if (methodSymbol2 != null)
				{
					methodSymbol = methodSymbol2;
				}
				if (!(pType is AggregateType { OwningAggregate: var aggregateSymbol }))
				{
					return methodSymbol;
				}
				while (aggregateSymbol?.GetBaseAgg() != null)
				{
					for (MethodOrPropertySymbol methodOrPropertySymbol = SymbolLoader.LookupAggMember(methodSymbol.name, aggregateSymbol, symbmask_t.MASK_MethodSymbol | symbmask_t.MASK_PropertySymbol) as MethodOrPropertySymbol; methodOrPropertySymbol != null; methodOrPropertySymbol = methodOrPropertySymbol.LookupNext(symbmask_t.MASK_MethodSymbol | symbmask_t.MASK_PropertySymbol) as MethodOrPropertySymbol)
					{
						if (methodOrPropertySymbol.isOverride && methodOrPropertySymbol.swtSlot.Sym != null && methodOrPropertySymbol.swtSlot.Sym == methodSymbol)
						{
							if (flag)
							{
								return ((MethodSymbol)methodOrPropertySymbol).getProperty();
							}
							return methodOrPropertySymbol;
						}
					}
					aggregateSymbol = aggregateSymbol.GetBaseAgg();
				}
				return methodSymbol;
			}

			private bool HasOptionalParameters()
			{
				return FindMostDerivedMethod(_pCurrentSym, _pGroup.OptionalObject)?.HasOptionalParameters() ?? false;
			}

			private bool AddArgumentsForOptionalParameters()
			{
				if (_pCurrentParameters.Count <= _pArguments.carg)
				{
					return true;
				}
				MethodOrPropertySymbol methodOrPropertySymbol = FindMostDerivedMethod(_pCurrentSym, _pGroup.OptionalObject);
				if (methodOrPropertySymbol == null)
				{
					return false;
				}
				int num = _pArguments.carg;
				int num2 = 0;
				TypeArray typeArray = TypeManager.SubstTypeArray(_pCurrentParameters, _pCurrentType, _pGroup.TypeArgs);
				Expr[] array = new Expr[_pCurrentParameters.Count - num];
				while (num < typeArray.Count)
				{
					if (!methodOrPropertySymbol.IsParameterOptional(num))
					{
						return false;
					}
					array[num2] = GenerateOptionalArgument(methodOrPropertySymbol, typeArray[num], num);
					num++;
					num2++;
				}
				for (int i = 0; i < num2; i++)
				{
					_pArguments.prgexpr.Add(array[i]);
				}
				CType[] array2 = new CType[typeArray.Count];
				for (int j = 0; j < typeArray.Count; j++)
				{
					array2[j] = _pArguments.prgexpr[j].Type;
				}
				_pArguments.types = TypeArray.Allocate(array2);
				_pArguments.carg = typeArray.Count;
				_bArgumentsChangedForNamedOrOptionalArguments = true;
				return true;
			}

			private static Expr FindArgumentWithName(ArgInfos pArguments, Name pName)
			{
				List<Expr> prgexpr = pArguments.prgexpr;
				for (int i = 0; i < pArguments.carg; i++)
				{
					Expr expr = prgexpr[i];
					if (expr is ExprNamedArgumentSpecification exprNamedArgumentSpecification && exprNamedArgumentSpecification.Name == pName)
					{
						return expr;
					}
				}
				return null;
			}

			private bool NamedArgumentNamesAppearInParameterList(MethodOrPropertySymbol methprop)
			{
				List<Name> list = methprop.ParameterNames;
				HashSet<Name> hashSet = new HashSet<Name>();
				for (int i = 0; i < _pArguments.carg; i++)
				{
					if (!(_pArguments.prgexpr[i] is ExprNamedArgumentSpecification { Name: var name }))
					{
						if (!list.IsEmpty())
						{
							list = list.Tail();
						}
						continue;
					}
					if (!methprop.ParameterNames.Contains(name))
					{
						if (_pInvalidSpecifiedName == null)
						{
							_pInvalidSpecifiedName = name;
						}
						return false;
					}
					if (!list.Contains(name))
					{
						if (_pNameUsedInPositionalArgument == null)
						{
							_pNameUsedInPositionalArgument = name;
						}
						return false;
					}
					if (!hashSet.Add(name))
					{
						if (_pDuplicateSpecifiedName == null)
						{
							_pDuplicateSpecifiedName = name;
						}
						return false;
					}
				}
				return true;
			}

			private bool GetNextSym(CMemberLookupResults.CMethodIterator iterator)
			{
				if (!iterator.MoveNext())
				{
					return false;
				}
				_pCurrentSym = iterator.CurrentSymbol;
				AggregateType currentType = iterator.CurrentType;
				if (_pCurrentType != currentType && _pCurrentType != null && !_methList.IsEmpty() && !_methList.Head().mpwi.GetType().IsInterfaceType)
				{
					return false;
				}
				_pCurrentType = currentType;
				while (_HiddenTypes.Contains(_pCurrentType))
				{
					while (iterator.CurrentType == _pCurrentType)
					{
						iterator.MoveNext();
					}
					_pCurrentSym = iterator.CurrentSymbol;
					_pCurrentType = iterator.CurrentType;
					if (iterator.AtEnd)
					{
						return false;
					}
				}
				return true;
			}

			private bool ConstructExpandedParameters()
			{
				if (_pCurrentSym == null || _pArguments == null || _pCurrentParameters == null)
				{
					return false;
				}
				if ((_fBindFlags & BindingFlag.BIND_NOPARAMS) != 0)
				{
					return false;
				}
				if (!_pCurrentSym.isParamArray)
				{
					return false;
				}
				int num = 0;
				for (int i = _pArguments.carg; i < _pCurrentSym.Params.Count; i++)
				{
					if (_pCurrentSym.IsParameterOptional(i))
					{
						num++;
					}
				}
				if (_pArguments.carg + num < _pCurrentParameters.Count - 1)
				{
					return false;
				}
				return TryGetExpandedParams(_pCurrentSym.Params, _pArguments.carg, out _pCurrentParameters);
			}

			private Result DetermineCurrentTypeArgs()
			{
				TypeArray typeArgs = _pGroup.TypeArgs;
				if (_pCurrentSym is MethodSymbol methodSymbol && methodSymbol.typeVars.Count != typeArgs.Count)
				{
					if (typeArgs.Count > 0)
					{
						if (!_mwtBadArity)
						{
							_mwtBadArity.Set(methodSymbol, _pCurrentType);
						}
						return Result.Failure_NoSearchForExpanded;
					}
					if (!MethodTypeInferrer.Infer(_pExprBinder, methodSymbol, _pCurrentParameters, _pArguments, out _pCurrentTypeArgs))
					{
						if (_results.IsBetterUninferableResult(_pCurrentTypeArgs))
						{
							TypeArray typeVars = methodSymbol.typeVars;
							if (typeVars != null && _pCurrentTypeArgs != null && typeVars.Count == _pCurrentTypeArgs.Count)
							{
								_mpwiCantInferInstArg.Set(methodSymbol, _pCurrentType, _pCurrentTypeArgs);
							}
							else
							{
								_mpwiCantInferInstArg.Set(methodSymbol, _pCurrentType, typeVars);
							}
						}
						return Result.Failure_SearchForExpanded;
					}
				}
				else
				{
					_pCurrentTypeArgs = typeArgs;
				}
				return Result.Success;
			}

			private bool ArgumentsAreConvertible()
			{
				bool flag = false;
				if (_pArguments.carg != 0)
				{
					UpdateArguments();
					for (int i = 0; i < _pArguments.carg; i++)
					{
						CType cType = _pCurrentParameters[i];
						if (!TypeBind.CheckConstraints(cType, CheckConstraintsFlags.NoErrors) && !DoesTypeArgumentsContainErrorSym(cType))
						{
							_mpwiParamTypeConstraints.Set(_pCurrentSym, _pCurrentType, _pCurrentTypeArgs);
							return false;
						}
					}
					for (int j = 0; j < _pArguments.carg; j++)
					{
						CType cType2 = _pCurrentParameters[j];
						flag |= DoesTypeArgumentsContainErrorSym(cType2);
						Expr expr = _pArguments.prgexpr[j];
						if (expr is ExprNamedArgumentSpecification exprNamedArgumentSpecification)
						{
							expr = exprNamedArgumentSpecification.Value;
						}
						if (_pExprBinder.canConvert(expr, cType2) || flag)
						{
							continue;
						}
						if (j > _nArgBest)
						{
							_nArgBest = j;
							if (!_results.BestResult)
							{
								_results.BestResult.Set(_pCurrentSym, _pCurrentType, _pCurrentTypeArgs);
							}
						}
						else if (j == _nArgBest && _pArguments.types[j] != cType2)
						{
							CType obj = ((_pArguments.types[j] is ParameterModifierType parameterModifierType) ? parameterModifierType.ParameterType : _pArguments.types[j]);
							CType cType3 = ((cType2 is ParameterModifierType parameterModifierType2) ? parameterModifierType2.ParameterType : cType2);
							if (obj == cType3 && !_results.BestResult)
							{
								_results.BestResult.Set(_pCurrentSym, _pCurrentType, _pCurrentTypeArgs);
							}
						}
						return false;
					}
				}
				if (flag)
				{
					if (_results.IsBetterUninferableResult(_pCurrentTypeArgs) && _pCurrentSym is MethodSymbol mps)
					{
						_results.UninferableResult.Set(mps, _pCurrentType, _pCurrentTypeArgs);
					}
					return false;
				}
				return true;
			}

			private void UpdateArguments()
			{
				_pCurrentParameters = TypeManager.SubstTypeArray(_pCurrentParameters, _pCurrentType, _pCurrentTypeArgs);
				if (_pArguments.prgexpr == null || _pArguments.prgexpr.Count == 0)
				{
					return;
				}
				MethodOrPropertySymbol methodOrPropertySymbol = null;
				for (int i = 0; i < _pCurrentParameters.Count; i++)
				{
					Expr expr = _pArguments.prgexpr[i];
					if (expr.IsOptionalArgument && _pCurrentParameters[i] != expr.Type)
					{
						if (methodOrPropertySymbol == null)
						{
							methodOrPropertySymbol = FindMostDerivedMethod(_pCurrentSym, _pGroup.OptionalObject);
						}
						Expr value = GenerateOptionalArgument(methodOrPropertySymbol, _pCurrentParameters[i], i);
						_pArguments.prgexpr[i] = value;
					}
				}
			}

			private static bool DoesTypeArgumentsContainErrorSym(CType var)
			{
				if (!(var is AggregateType { TypeArgsAll: var typeArgsAll }))
				{
					return false;
				}
				for (int i = 0; i < typeArgsAll.Count; i++)
				{
					CType cType = typeArgsAll[i];
					if (cType == null)
					{
						return true;
					}
					if (cType is AggregateType && DoesTypeArgumentsContainErrorSym(cType))
					{
						return true;
					}
				}
				return false;
			}

			private void ReportErrorsOnSuccess()
			{
				if (_pGroup.SymKind == SYMKIND.SK_MethodSymbol && _results.BestResult.TypeArgs.Count > 0)
				{
					TypeBind.CheckMethConstraints(new MethWithInst(_results.BestResult));
				}
			}

			private RuntimeBinderException ReportErrorsOnFailure()
			{
				if (_pDuplicateSpecifiedName != null)
				{
					return ErrorHandling.Error(ErrorCode.ERR_DuplicateNamedArgument, _pDuplicateSpecifiedName);
				}
				if ((bool)_results.InaccessibleResult)
				{
					return CSemanticChecker.ReportAccessError(_results.InaccessibleResult, _pExprBinder.ContextForMemberLookup, GetTypeQualifier(_pGroup));
				}
				if ((bool)_misnamed)
				{
					List<Name> parameterNames = FindMostDerivedMethod(_misnamed.MethProp(), _pGroup.OptionalObject).ParameterNames;
					for (int i = 0; i != _pOriginalArguments.carg; i++)
					{
						if (_pOriginalArguments.prgexpr[i] is ExprNamedArgumentSpecification { Name: var name } && parameterNames[i] != name)
						{
							if (parameterNames.Contains(name))
							{
								return ErrorHandling.Error(ErrorCode.ERR_BadNonTrailingNamedArgument, name);
							}
							_pInvalidSpecifiedName = name;
							break;
						}
					}
				}
				else if ((bool)_mpwiBogus)
				{
					return ErrorHandling.Error(ErrorCode.ERR_BindToBogus, _mpwiBogus);
				}
				bool flag = false;
				Name name2 = _pGroup.Name;
				if (_pGroup.OptionalObject?.Type != null && _pGroup.OptionalObject.Type.IsDelegateType && _pGroup.Name == NameManager.GetPredefinedName(PredefinedName.PN_INVOKE))
				{
					flag = true;
					name2 = ((AggregateType)_pGroup.OptionalObject.Type).OwningAggregate.name;
				}
				if ((bool)_results.BestResult)
				{
					return ReportErrorsForBestMatching(flag);
				}
				if ((bool)_results.UninferableResult || (bool)_mpwiCantInferInstArg)
				{
					if (!_results.UninferableResult)
					{
						_results.UninferableResult.Set(_mpwiCantInferInstArg.Sym as MethodSymbol, _mpwiCantInferInstArg.GetType(), _mpwiCantInferInstArg.TypeArgs);
					}
					MethWithType methWithType = new MethWithType(_results.UninferableResult.Meth(), _results.UninferableResult.GetType());
					return ErrorHandling.Error(ErrorCode.ERR_CantInferMethTypeArgs, methWithType);
				}
				if ((bool)_mwtBadArity)
				{
					return ErrorHandling.Error((_mwtBadArity.Meth().typeVars.Count > 0) ? ErrorCode.ERR_BadArity : ErrorCode.ERR_HasNoTypeVars, _mwtBadArity, new ErrArgSymKind(_mwtBadArity.Meth()), _pArguments.carg);
				}
				if ((bool)_mpwiParamTypeConstraints)
				{
					TypeBind.CheckMethConstraints(new MethWithInst(_mpwiParamTypeConstraints));
					return null;
				}
				if (_pInvalidSpecifiedName != null)
				{
					if (!(_pGroup.OptionalObject?.Type is AggregateType aggregateType) || !aggregateType.OwningAggregate.IsDelegate())
					{
						return ErrorHandling.Error(ErrorCode.ERR_BadNamedArgument, _pGroup.Name, _pInvalidSpecifiedName);
					}
					return ErrorHandling.Error(ErrorCode.ERR_BadNamedArgumentForDelegateInvoke, aggregateType.OwningAggregate.name, _pInvalidSpecifiedName);
				}
				if (_pNameUsedInPositionalArgument != null)
				{
					return ErrorHandling.Error(ErrorCode.ERR_NamedArgumentUsedInPositional, _pNameUsedInPositionalArgument);
				}
				if (_fCandidatesUnsupported)
				{
					return ErrorHandling.Error(ErrorCode.ERR_BindToBogus, name2);
				}
				if (flag)
				{
					return ErrorHandling.Error(ErrorCode.ERR_BadDelArgCount, name2, _pArguments.carg);
				}
				if ((_pGroup.Flags & EXPRFLAG.EXF_CTOR) != 0)
				{
					return ErrorHandling.Error(ErrorCode.ERR_BadCtorArgCount, _pGroup.ParentType, _pArguments.carg);
				}
				return ErrorHandling.Error(ErrorCode.ERR_BadArgCount, name2, _pArguments.carg);
			}

			private RuntimeBinderException ReportErrorsForBestMatching(bool bUseDelegateErrors)
			{
				if (bUseDelegateErrors)
				{
					return ErrorHandling.Error(ErrorCode.ERR_BadDelArgTypes, _results.BestResult.GetType());
				}
				return ErrorHandling.Error(ErrorCode.ERR_BadArgTypes, _results.BestResult);
			}
		}

		internal sealed class GroupToArgsBinderResult
		{
			public MethPropWithInst BestResult { get; set; }

			public MethPropWithInst AmbiguousResult { get; set; }

			public MethPropWithInst InaccessibleResult { get; }

			public MethPropWithInst UninferableResult { get; }

			public GroupToArgsBinderResult()
			{
				BestResult = new MethPropWithInst();
				AmbiguousResult = new MethPropWithInst();
				InaccessibleResult = new MethPropWithInst();
				UninferableResult = new MethPropWithInst();
			}

			private static int NumberOfErrorTypes(TypeArray pTypeArgs)
			{
				int num = 0;
				for (int i = 0; i < pTypeArgs.Count; i++)
				{
					if (pTypeArgs[i] == null)
					{
						num++;
					}
				}
				return num;
			}

			private static bool IsBetterThanCurrent(TypeArray pTypeArgs1, TypeArray pTypeArgs2)
			{
				int num = NumberOfErrorTypes(pTypeArgs1);
				int num2 = NumberOfErrorTypes(pTypeArgs2);
				if (num == num2)
				{
					int num3 = ((pTypeArgs1.Count > pTypeArgs2.Count) ? pTypeArgs2.Count : pTypeArgs1.Count);
					for (int i = 0; i < num3; i++)
					{
						if (pTypeArgs1[i] is AggregateType aggregateType)
						{
							num += NumberOfErrorTypes(aggregateType.TypeArgsAll);
						}
						if (pTypeArgs2[i] is AggregateType aggregateType2)
						{
							num2 += NumberOfErrorTypes(aggregateType2.TypeArgsAll);
						}
					}
				}
				return num2 < num;
			}

			public bool IsBetterUninferableResult(TypeArray pTypeArguments)
			{
				if (UninferableResult.Sym == null)
				{
					return true;
				}
				if (pTypeArguments == null)
				{
					return false;
				}
				return IsBetterThanCurrent(UninferableResult.TypeArgs, pTypeArguments);
			}
		}

		private sealed class ImplicitConversion
		{
			private Expr _exprDest;

			private readonly ExpressionBinder _binder;

			private readonly Expr _exprSrc;

			private readonly CType _typeSrc;

			private readonly CType _typeDest;

			private readonly bool _needsExprDest;

			private CONVERTTYPE _flags;

			public Expr ExprDest => _exprDest;

			public ImplicitConversion(ExpressionBinder binder, Expr exprSrc, CType typeSrc, CType typeDest, bool needsExprDest, CONVERTTYPE flags)
			{
				_binder = binder;
				_exprSrc = exprSrc;
				_typeSrc = typeSrc;
				_typeDest = typeDest;
				_needsExprDest = needsExprDest;
				_flags = flags;
				_exprDest = null;
			}

			public bool Bind()
			{
				if (_typeSrc == null || _typeDest == null || _typeDest is MethodGroupType)
				{
					return false;
				}
				switch (_typeDest.TypeKind)
				{
				case TypeKind.TK_NullType:
					if (!(_typeSrc is NullType))
					{
						return false;
					}
					if (_needsExprDest)
					{
						_exprDest = _exprSrc;
					}
					return true;
				case TypeKind.TK_ArgumentListType:
					return _typeSrc == _typeDest;
				case TypeKind.TK_VoidType:
					return false;
				default:
				{
					if (_typeSrc == _typeDest && ((_flags & CONVERTTYPE.ISEXPLICIT) == 0 || (!_typeSrc.IsPredefType(PredefinedType.PT_FLOAT) && !_typeSrc.IsPredefType(PredefinedType.PT_DOUBLE))))
					{
						if (_needsExprDest)
						{
							_exprDest = _exprSrc;
						}
						return true;
					}
					if (_typeDest is NullableType nubDst)
					{
						return BindNubConversion(nubDst);
					}
					if (_typeSrc is NullableType nubSrc)
					{
						return bindImplicitConversionFromNullable(nubSrc);
					}
					if ((_flags & CONVERTTYPE.ISEXPLICIT) != 0)
					{
						_flags |= CONVERTTYPE.NOUDC;
					}
					_ = _typeDest.FundamentalType;
					switch (_typeSrc.TypeKind)
					{
					case TypeKind.TK_VoidType:
					case TypeKind.TK_ArgumentListType:
					case TypeKind.TK_ParameterModifierType:
						return false;
					case TypeKind.TK_NullType:
						if (bindImplicitConversionFromNull())
						{
							return true;
						}
						break;
					case TypeKind.TK_ArrayType:
						if (bindImplicitConversionFromArray())
						{
							return true;
						}
						break;
					case TypeKind.TK_PointerType:
						if (bindImplicitConversionFromPointer())
						{
							return true;
						}
						break;
					case TypeKind.TK_AggregateType:
						if (bindImplicitConversionFromAgg(_typeSrc as AggregateType))
						{
							return true;
						}
						break;
					}
					object obj = _exprSrc?.RuntimeObject;
					if (obj != null && _typeDest.AssociatedSystemType.IsInstanceOfType(obj) && CSemanticChecker.CheckTypeAccess(_typeDest, _binder.Context.ContextForMemberLookup))
					{
						if (_needsExprDest)
						{
							_binder.bindSimpleCast(_exprSrc, _typeDest, out _exprDest, _exprSrc.Flags & EXPRFLAG.EXF_CANTBENULL);
						}
						return true;
					}
					if ((_flags & CONVERTTYPE.NOUDC) == 0)
					{
						return _binder.bindUserDefinedConversion(_exprSrc, _typeSrc, _typeDest, _needsExprDest, out _exprDest, fImplicitOnly: true);
					}
					return false;
				}
				}
			}

			private bool BindNubConversion(NullableType nubDst)
			{
				nubDst.GetAts();
				if (SymbolLoader.HasBaseConversion(nubDst.UnderlyingType, _typeSrc) && !CConversions.FWrappingConv(_typeSrc, nubDst))
				{
					if ((_flags & CONVERTTYPE.ISEXPLICIT) == 0)
					{
						return false;
					}
					if (_needsExprDest)
					{
						_binder.bindSimpleCast(_exprSrc, _typeDest, out _exprDest, EXPRFLAG.EXF_INDEXER);
					}
					return true;
				}
				bool wasNullable;
				CType cType = nubDst.StripNubs(out wasNullable);
				bool wasNullable2;
				CType cType2 = _typeSrc.StripNubs(out wasNullable2);
				ConversionFunc conversionFunc = (((_flags & CONVERTTYPE.ISEXPLICIT) != 0) ? new ConversionFunc(_binder.BindExplicitConversion) : new ConversionFunc(_binder.BindImplicitConversion));
				if (!wasNullable2)
				{
					if (_typeSrc is NullType)
					{
						if (_needsExprDest)
						{
							_exprDest = ((_exprSrc is ExprConstant) ? ExprFactory.CreateZeroInit(nubDst) : ExprFactory.CreateCast(_typeDest, _exprSrc));
						}
						return true;
					}
					Expr ppDestinationExpr = _exprSrc;
					if (_typeSrc == cType || conversionFunc(_exprSrc, _typeSrc, cType, _needsExprDest, out ppDestinationExpr, _flags | CONVERTTYPE.NOUDC))
					{
						if (_needsExprDest)
						{
							ExprUserDefinedConversion exprUserDefinedConversion = ppDestinationExpr as ExprUserDefinedConversion;
							if (exprUserDefinedConversion != null)
							{
								ppDestinationExpr = exprUserDefinedConversion.UserDefinedCall;
							}
							if (wasNullable)
							{
								((ExprCall)(ppDestinationExpr = BindNubNew(ppDestinationExpr))).NullableCallLiftKind = NullableCallLiftKind.NullableConversionConstructor;
							}
							if (exprUserDefinedConversion != null)
							{
								exprUserDefinedConversion.UserDefinedCall = ppDestinationExpr;
								ppDestinationExpr = exprUserDefinedConversion;
							}
							_exprDest = ppDestinationExpr;
						}
						return true;
					}
					if ((_flags & CONVERTTYPE.NOUDC) == 0)
					{
						return _binder.bindUserDefinedConversion(_exprSrc, _typeSrc, nubDst, _needsExprDest, out _exprDest, (_flags & CONVERTTYPE.ISEXPLICIT) == 0);
					}
					return false;
				}
				if (cType2 != cType && !conversionFunc(null, cType2, cType, needsExprDest: false, out _exprDest, _flags | CONVERTTYPE.NOUDC))
				{
					if ((_flags & CONVERTTYPE.NOUDC) == 0)
					{
						return _binder.bindUserDefinedConversion(_exprSrc, _typeSrc, nubDst, _needsExprDest, out _exprDest, (_flags & CONVERTTYPE.ISEXPLICIT) == 0);
					}
					return false;
				}
				if (_needsExprDest)
				{
					MethWithInst method = new MethWithInst(null, null);
					ExprMemberGroup memberGroup = ExprFactory.CreateMemGroup(null, method);
					ExprCall exprCall = ExprFactory.CreateCall((EXPRFLAG)0, nubDst, _exprSrc, memberGroup, null);
					Expr ppDestinationExpr2 = _binder.mustCast(_exprSrc, cType2);
					if (!(((_flags & CONVERTTYPE.ISEXPLICIT) != 0) ? _binder.BindExplicitConversion(ppDestinationExpr2, ppDestinationExpr2.Type, cType, out ppDestinationExpr2, _flags | CONVERTTYPE.NOUDC) : _binder.BindImplicitConversion(ppDestinationExpr2, ppDestinationExpr2.Type, cType, out ppDestinationExpr2, _flags | CONVERTTYPE.NOUDC)))
					{
						return false;
					}
					exprCall.CastOfNonLiftedResultToLiftedType = _binder.mustCast(ppDestinationExpr2, nubDst, (CONVERTTYPE)0);
					exprCall.NullableCallLiftKind = NullableCallLiftKind.NullableConversion;
					exprCall.PConversions = exprCall.CastOfNonLiftedResultToLiftedType;
					_exprDest = exprCall;
				}
				return true;
			}

			private bool bindImplicitConversionFromNull()
			{
				FUNDTYPE fundamentalType = _typeDest.FundamentalType;
				if (fundamentalType != FUNDTYPE.FT_REF && fundamentalType != FUNDTYPE.FT_PTR && !_typeDest.IsPredefType(PredefinedType.PT_G_OPTIONAL))
				{
					return false;
				}
				if (_needsExprDest)
				{
					_exprDest = ((_exprSrc is ExprConstant) ? ExprFactory.CreateZeroInit(_typeDest) : ExprFactory.CreateCast(_typeDest, _exprSrc));
				}
				return true;
			}

			private bool bindImplicitConversionFromNullable(NullableType nubSrc)
			{
				if (nubSrc.GetAts() == _typeDest)
				{
					if (_needsExprDest)
					{
						_exprDest = _exprSrc;
					}
					return true;
				}
				if (SymbolLoader.HasBaseConversion(nubSrc.UnderlyingType, _typeDest) && !CConversions.FUnwrappingConv(nubSrc, _typeDest))
				{
					if (_needsExprDest)
					{
						_binder.bindSimpleCast(_exprSrc, _typeDest, out _exprDest, EXPRFLAG.EXF_CTOR);
						if (!_typeDest.IsPredefType(PredefinedType.PT_OBJECT))
						{
							_binder.bindSimpleCast(_exprDest, _typeDest, out _exprDest, EXPRFLAG.EXF_ASFINALLYLEAVE);
						}
					}
					return true;
				}
				if ((_flags & CONVERTTYPE.NOUDC) == 0)
				{
					return _binder.bindUserDefinedConversion(_exprSrc, nubSrc, _typeDest, _needsExprDest, out _exprDest, fImplicitOnly: true);
				}
				return false;
			}

			private bool bindImplicitConversionFromArray()
			{
				if (!SymbolLoader.HasBaseConversion(_typeSrc, _typeDest))
				{
					return false;
				}
				EXPRFLAG exprFlags = (EXPRFLAG)0;
				if ((_typeDest is ArrayType || (_typeDest is AggregateType { IsInterfaceType: not false } aggregateType && aggregateType.TypeArgsAll.Count == 1 && (aggregateType.TypeArgsAll[0] != ((ArrayType)_typeSrc).ElementType || (_flags & CONVERTTYPE.FORCECAST) != 0))) && ((_flags & CONVERTTYPE.FORCECAST) != 0 || TypeManager.TypeContainsTyVars(_typeSrc, null) || TypeManager.TypeContainsTyVars(_typeDest, null)))
				{
					exprFlags = EXPRFLAG.EXF_OPERATOR;
				}
				if (_needsExprDest)
				{
					_binder.bindSimpleCast(_exprSrc, _typeDest, out _exprDest, exprFlags);
				}
				return true;
			}

			private bool bindImplicitConversionFromPointer()
			{
				if (_typeDest is PointerType pointerType && pointerType.ReferentType == VoidType.Instance)
				{
					if (_needsExprDest)
					{
						_binder.bindSimpleCast(_exprSrc, _typeDest, out _exprDest);
					}
					return true;
				}
				return false;
			}

			private bool bindImplicitConversionFromAgg(AggregateType aggTypeSrc)
			{
				AggregateSymbol owningAggregate = aggTypeSrc.OwningAggregate;
				if (owningAggregate.IsEnum())
				{
					return bindImplicitConversionFromEnum(aggTypeSrc);
				}
				if (_typeDest.IsEnumType)
				{
					if (bindImplicitConversionToEnum(aggTypeSrc))
					{
						return true;
					}
				}
				else if (owningAggregate.getThisType().IsSimpleType && _typeDest.IsSimpleType && bindImplicitConversionBetweenSimpleTypes(aggTypeSrc))
				{
					return true;
				}
				return bindImplicitConversionToBase(aggTypeSrc);
			}

			private bool bindImplicitConversionToBase(AggregateType pSource)
			{
				if (!(_typeDest is AggregateType) || !SymbolLoader.HasBaseConversion(pSource, _typeDest))
				{
					return false;
				}
				EXPRFLAG exprFlags = (EXPRFLAG)0;
				if (pSource.OwningAggregate.IsStruct() && _typeDest.FundamentalType == FUNDTYPE.FT_REF)
				{
					exprFlags = EXPRFLAG.EXF_CTOR | EXPRFLAG.EXF_CANTBENULL;
				}
				else if (_exprSrc != null)
				{
					exprFlags = _exprSrc.Flags & EXPRFLAG.EXF_CANTBENULL;
				}
				if (_needsExprDest)
				{
					_binder.bindSimpleCast(_exprSrc, _typeDest, out _exprDest, exprFlags);
				}
				return true;
			}

			private bool bindImplicitConversionFromEnum(AggregateType aggTypeSrc)
			{
				if (_typeDest is AggregateType pDest && SymbolLoader.HasBaseConversion(aggTypeSrc, pDest))
				{
					if (_needsExprDest)
					{
						_binder.bindSimpleCast(_exprSrc, _typeDest, out _exprDest, EXPRFLAG.EXF_CTOR | EXPRFLAG.EXF_CANTBENULL);
					}
					return true;
				}
				return false;
			}

			private bool bindImplicitConversionToEnum(AggregateType aggTypeSrc)
			{
				if (aggTypeSrc.OwningAggregate.GetPredefType() != PredefinedType.PT_BOOL && _exprSrc != null && _exprSrc.IsZero() && _exprSrc.Type.IsNumericType && (_flags & CONVERTTYPE.STANDARD) == 0)
				{
					if (_needsExprDest)
					{
						_exprDest = ExprFactory.CreateConstant(_typeDest, ConstVal.GetDefaultValue(_typeDest.ConstValKind));
					}
					return true;
				}
				return false;
			}

			private bool bindImplicitConversionBetweenSimpleTypes(AggregateType aggTypeSrc)
			{
				PredefinedType predefType = aggTypeSrc.OwningAggregate.GetPredefType();
				PredefinedType predefinedType = _typeDest.PredefinedType;
				ConvKind convKind = ((_exprSrc is ExprConstant exprSrc && ((predefType == PredefinedType.PT_INT && predefinedType != PredefinedType.PT_BOOL && predefinedType != PredefinedType.PT_CHAR) || (predefType == PredefinedType.PT_LONG && predefinedType == PredefinedType.PT_ULONG)) && isConstantInRange(exprSrc, _typeDest)) ? ConvKind.Implicit : ((predefType != predefinedType) ? GetConvKind(predefType, predefinedType) : ConvKind.Implicit));
				if (convKind != ConvKind.Implicit)
				{
					return false;
				}
				if (_exprSrc.GetConst() != null && _binder.bindConstantCast(_exprSrc, _typeDest, _needsExprDest, out _exprDest, explicitConversion: false) == ConstCastResult.Success)
				{
					return true;
				}
				if (isUserDefinedConversion(predefType, predefinedType))
				{
					if (!_needsExprDest)
					{
						return true;
					}
					return _binder.bindUserDefinedConversion(_exprSrc, aggTypeSrc, _typeDest, _needsExprDest, out _exprDest, fImplicitOnly: true);
				}
				if (_needsExprDest)
				{
					_binder.bindSimpleCast(_exprSrc, _typeDest, out _exprDest);
				}
				return true;
			}
		}

		private class UnaOpSig
		{
			public PredefinedType pt;

			public UnaOpMask grfuom;

			public int cuosSkip;

			public PfnBindUnaOp pfn;

			public UnaOpFuncKind fnkind;

			protected UnaOpSig()
			{
			}

			public UnaOpSig(PredefinedType pt, UnaOpMask grfuom, int cuosSkip, PfnBindUnaOp pfn, UnaOpFuncKind fnkind)
			{
				this.pt = pt;
				this.grfuom = grfuom;
				this.cuosSkip = cuosSkip;
				this.pfn = pfn;
				this.fnkind = fnkind;
			}
		}

		private sealed class UnaOpFullSig : UnaOpSig
		{
			private readonly LiftFlags _grflt;

			private readonly CType _type;

			public UnaOpFullSig(CType type, PfnBindUnaOp pfn, LiftFlags grflt, UnaOpFuncKind fnkind)
			{
				pt = PredefinedType.PT_UNDEFINEDINDEX;
				grfuom = UnaOpMask.None;
				cuosSkip = 0;
				base.pfn = pfn;
				_type = type;
				_grflt = grflt;
				base.fnkind = fnkind;
			}

			public UnaOpFullSig(ExpressionBinder fnc, UnaOpSig uos)
			{
				pt = uos.pt;
				grfuom = uos.grfuom;
				cuosSkip = uos.cuosSkip;
				pfn = uos.pfn;
				fnkind = uos.fnkind;
				_type = ((pt != PredefinedType.PT_UNDEFINEDINDEX) ? GetPredefindType(pt) : null);
				_grflt = LiftFlags.None;
			}

			public bool FPreDef()
			{
				return pt != PredefinedType.PT_UNDEFINEDINDEX;
			}

			public bool isLifted()
			{
				if (_grflt == LiftFlags.None)
				{
					return false;
				}
				return true;
			}

			public bool Convert()
			{
				return (_grflt & LiftFlags.Convert1) != 0;
			}

			public new CType GetType()
			{
				return _type;
			}
		}

		private static readonly byte[][] s_betterConversionTable = new byte[16][]
		{
			new byte[16]
			{
				3, 3, 3, 3, 3, 3, 3, 3, 3, 2,
				3, 3, 3, 3, 3, 3
			},
			new byte[16]
			{
				3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
				1, 1, 1, 3, 3, 3
			},
			new byte[16]
			{
				3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
				3, 1, 1, 3, 3, 3
			},
			new byte[16]
			{
				3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
				3, 3, 1, 3, 3, 3
			},
			new byte[16]
			{
				3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
				3, 3, 3, 3, 3, 3
			},
			new byte[16]
			{
				3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
				3, 3, 3, 3, 3, 3
			},
			new byte[16]
			{
				3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
				3, 3, 3, 3, 3, 3
			},
			new byte[16]
			{
				3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
				3, 3, 3, 3, 3, 3
			},
			new byte[16]
			{
				3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
				3, 3, 3, 3, 3, 3
			},
			new byte[16]
			{
				1, 3, 3, 3, 3, 3, 3, 3, 3, 3,
				1, 1, 1, 3, 3, 3
			},
			new byte[16]
			{
				3, 2, 3, 3, 3, 3, 3, 3, 3, 2,
				3, 3, 3, 3, 3, 3
			},
			new byte[16]
			{
				3, 2, 2, 3, 3, 3, 3, 3, 3, 2,
				3, 3, 3, 3, 3, 3
			},
			new byte[16]
			{
				3, 2, 2, 2, 3, 3, 3, 3, 3, 2,
				3, 3, 3, 3, 3, 3
			},
			new byte[16]
			{
				3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
				3, 3, 3, 3, 3, 3
			},
			new byte[16]
			{
				3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
				3, 3, 3, 3, 3, 3
			},
			new byte[16]
			{
				3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
				3, 3, 3, 3, 3, 3
			}
		};

		private const byte ID = 1;

		private const byte IMP = 2;

		private const byte EXP = 3;

		private const byte NO = 5;

		private const byte CONV_KIND_MASK = 15;

		private const byte UDC = 64;

		private const byte XUD = 67;

		private const byte IUD = 66;

		private static readonly byte[][] s_simpleTypeConversions = new byte[13][]
		{
			new byte[13]
			{
				1, 2, 2, 2, 2, 2, 66, 3, 5, 3,
				2, 2, 2
			},
			new byte[13]
			{
				3, 1, 2, 2, 2, 2, 66, 3, 5, 3,
				3, 3, 3
			},
			new byte[13]
			{
				3, 3, 1, 2, 2, 2, 66, 3, 5, 3,
				3, 3, 3
			},
			new byte[13]
			{
				3, 3, 3, 1, 2, 2, 66, 3, 5, 3,
				3, 3, 3
			},
			new byte[13]
			{
				3, 3, 3, 3, 1, 2, 67, 3, 5, 3,
				3, 3, 3
			},
			new byte[13]
			{
				3, 3, 3, 3, 3, 1, 67, 3, 5, 3,
				3, 3, 3
			},
			new byte[13]
			{
				67, 67, 67, 67, 67, 67, 1, 67, 5, 67,
				67, 67, 67
			},
			new byte[13]
			{
				3, 3, 2, 2, 2, 2, 66, 1, 5, 3,
				2, 2, 2
			},
			new byte[13]
			{
				5, 5, 5, 5, 5, 5, 5, 5, 1, 5,
				5, 5, 5
			},
			new byte[13]
			{
				3, 2, 2, 2, 2, 2, 66, 3, 5, 1,
				3, 3, 3
			},
			new byte[13]
			{
				3, 3, 2, 2, 2, 2, 66, 3, 5, 3,
				1, 2, 2
			},
			new byte[13]
			{
				3, 3, 3, 2, 2, 2, 66, 3, 5, 3,
				3, 1, 2
			},
			new byte[13]
			{
				3, 3, 3, 3, 2, 2, 66, 3, 5, 3,
				3, 3, 1
			}
		};

		private const int NUM_SIMPLE_TYPES = 13;

		private const int NUM_EXT_TYPES = 16;

		private const byte same = 0;

		private const byte left = 1;

		private const byte right = 2;

		private const byte neither = 3;

		private static readonly byte[][] s_simpleTypeBetter = new byte[16][]
		{
			new byte[16]
			{
				0, 1, 1, 1, 1, 1, 1, 3, 3, 2,
				1, 1, 1, 3, 3, 1
			},
			new byte[16]
			{
				2, 0, 1, 1, 1, 1, 1, 3, 3, 2,
				1, 1, 1, 3, 3, 1
			},
			new byte[16]
			{
				2, 2, 0, 1, 1, 1, 1, 2, 3, 2,
				2, 1, 1, 3, 3, 1
			},
			new byte[16]
			{
				2, 2, 2, 0, 1, 1, 1, 2, 3, 2,
				2, 2, 1, 3, 3, 1
			},
			new byte[16]
			{
				2, 2, 2, 2, 0, 1, 3, 2, 3, 2,
				2, 2, 2, 3, 3, 1
			},
			new byte[16]
			{
				2, 2, 2, 2, 2, 0, 3, 2, 3, 2,
				2, 2, 2, 3, 3, 1
			},
			new byte[16]
			{
				2, 2, 2, 2, 3, 3, 0, 2, 3, 2,
				2, 2, 2, 3, 3, 1
			},
			new byte[16]
			{
				3, 3, 1, 1, 1, 1, 1, 0, 3, 3,
				1, 1, 1, 3, 3, 1
			},
			new byte[16]
			{
				3, 3, 3, 3, 3, 3, 3, 3, 0, 3,
				3, 3, 3, 3, 3, 1
			},
			new byte[16]
			{
				1, 1, 1, 1, 1, 1, 1, 3, 3, 0,
				1, 1, 1, 3, 3, 1
			},
			new byte[16]
			{
				2, 2, 1, 1, 1, 1, 1, 2, 3, 2,
				0, 1, 1, 3, 3, 1
			},
			new byte[16]
			{
				2, 2, 2, 1, 1, 1, 1, 2, 3, 2,
				2, 0, 1, 3, 3, 1
			},
			new byte[16]
			{
				2, 2, 2, 2, 1, 1, 1, 2, 3, 2,
				2, 2, 0, 3, 3, 1
			},
			new byte[16]
			{
				3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
				3, 3, 3, 0, 3, 1
			},
			new byte[16]
			{
				3, 3, 3, 3, 3, 3, 3, 3, 3, 3,
				3, 3, 3, 3, 0, 1
			},
			new byte[16]
			{
				2, 2, 2, 2, 2, 2, 2, 2, 2, 2,
				2, 2, 2, 2, 2, 0
			}
		};

		private static readonly PredefinedType[] s_rgptIntOp = new PredefinedType[4]
		{
			PredefinedType.PT_INT,
			PredefinedType.PT_UINT,
			PredefinedType.PT_LONG,
			PredefinedType.PT_ULONG
		};

		private static readonly PredefinedName[] s_EK2NAME = new PredefinedName[26]
		{
			PredefinedName.PN_OPEQUALS,
			PredefinedName.PN_OPCOMPARE,
			PredefinedName.PN_OPTRUE,
			PredefinedName.PN_OPFALSE,
			PredefinedName.PN_OPINCREMENT,
			PredefinedName.PN_OPDECREMENT,
			PredefinedName.PN_OPNEGATION,
			PredefinedName.PN_OPEQUALITY,
			PredefinedName.PN_OPINEQUALITY,
			PredefinedName.PN_OPLESSTHAN,
			PredefinedName.PN_OPLESSTHANOREQUAL,
			PredefinedName.PN_OPGREATERTHAN,
			PredefinedName.PN_OPGREATERTHANOREQUAL,
			PredefinedName.PN_OPPLUS,
			PredefinedName.PN_OPMINUS,
			PredefinedName.PN_OPMULTIPLY,
			PredefinedName.PN_OPDIVISION,
			PredefinedName.PN_OPMODULUS,
			PredefinedName.PN_OPUNARYMINUS,
			PredefinedName.PN_OPUNARYPLUS,
			PredefinedName.PN_OPBITWISEAND,
			PredefinedName.PN_OPBITWISEOR,
			PredefinedName.PN_OPXOR,
			PredefinedName.PN_OPCOMPLEMENT,
			PredefinedName.PN_OPLEFTSHIFT,
			PredefinedName.PN_OPRIGHTSHIFT
		};

		private static readonly BinOpSig[] s_binopSignatures = new BinOpSig[20]
		{
			new BinOpSig(PredefinedType.PT_INT, PredefinedType.PT_INT, BinOpMask.Integer, 8, BindIntBinOp, OpSigFlags.Value, BinOpFuncKind.IntBinOp),
			new BinOpSig(PredefinedType.PT_UINT, PredefinedType.PT_UINT, BinOpMask.Integer, 7, BindIntBinOp, OpSigFlags.Value, BinOpFuncKind.IntBinOp),
			new BinOpSig(PredefinedType.PT_LONG, PredefinedType.PT_LONG, BinOpMask.Integer, 6, BindIntBinOp, OpSigFlags.Value, BinOpFuncKind.IntBinOp),
			new BinOpSig(PredefinedType.PT_ULONG, PredefinedType.PT_ULONG, BinOpMask.Integer, 5, BindIntBinOp, OpSigFlags.Value, BinOpFuncKind.IntBinOp),
			new BinOpSig(PredefinedType.PT_ULONG, PredefinedType.PT_LONG, BinOpMask.Integer, 4, null, OpSigFlags.Value, BinOpFuncKind.None),
			new BinOpSig(PredefinedType.PT_LONG, PredefinedType.PT_ULONG, BinOpMask.Integer, 3, null, OpSigFlags.Value, BinOpFuncKind.None),
			new BinOpSig(PredefinedType.PT_FLOAT, PredefinedType.PT_FLOAT, BinOpMask.Real, 1, BindRealBinOp, OpSigFlags.Value, BinOpFuncKind.RealBinOp),
			new BinOpSig(PredefinedType.PT_DOUBLE, PredefinedType.PT_DOUBLE, BinOpMask.Real, 0, BindRealBinOp, OpSigFlags.Value, BinOpFuncKind.RealBinOp),
			new BinOpSig(PredefinedType.PT_DECIMAL, PredefinedType.PT_DECIMAL, BinOpMask.Real, 0, BindDecBinOp, OpSigFlags.Value, BinOpFuncKind.DecBinOp),
			new BinOpSig(PredefinedType.PT_STRING, PredefinedType.PT_STRING, BinOpMask.Equal, 0, BindStrCmpOp, OpSigFlags.Convert, BinOpFuncKind.StrCmpOp),
			new BinOpSig(PredefinedType.PT_STRING, PredefinedType.PT_STRING, BinOpMask.Add, 2, BindStrBinOp, OpSigFlags.Convert, BinOpFuncKind.StrBinOp),
			new BinOpSig(PredefinedType.PT_STRING, PredefinedType.PT_OBJECT, BinOpMask.Add, 1, BindStrBinOp, OpSigFlags.Convert, BinOpFuncKind.StrBinOp),
			new BinOpSig(PredefinedType.PT_OBJECT, PredefinedType.PT_STRING, BinOpMask.Add, 0, BindStrBinOp, OpSigFlags.Convert, BinOpFuncKind.StrBinOp),
			new BinOpSig(PredefinedType.PT_INT, PredefinedType.PT_INT, BinOpMask.Shift, 3, BindShiftOp, OpSigFlags.Value, BinOpFuncKind.ShiftOp),
			new BinOpSig(PredefinedType.PT_UINT, PredefinedType.PT_INT, BinOpMask.Shift, 2, BindShiftOp, OpSigFlags.Value, BinOpFuncKind.ShiftOp),
			new BinOpSig(PredefinedType.PT_LONG, PredefinedType.PT_INT, BinOpMask.Shift, 1, BindShiftOp, OpSigFlags.Value, BinOpFuncKind.ShiftOp),
			new BinOpSig(PredefinedType.PT_ULONG, PredefinedType.PT_INT, BinOpMask.Shift, 0, BindShiftOp, OpSigFlags.Value, BinOpFuncKind.ShiftOp),
			new BinOpSig(PredefinedType.PT_BOOL, PredefinedType.PT_BOOL, BinOpMask.BoolNorm, 0, BindBoolBinOp, OpSigFlags.Value, BinOpFuncKind.BoolBinOp),
			new BinOpSig(PredefinedType.PT_BOOL, PredefinedType.PT_BOOL, BinOpMask.Logical, 0, BindBoolBinOp, OpSigFlags.BoolBit, BinOpFuncKind.BoolBinOp),
			new BinOpSig(PredefinedType.PT_BOOL, PredefinedType.PT_BOOL, BinOpMask.Bitwise, 0, BindLiftedBoolBitwiseOp, OpSigFlags.BoolBit, BinOpFuncKind.BoolBitwiseOp)
		};

		private static readonly UnaOpSig[] s_rguos = new UnaOpSig[16]
		{
			new UnaOpSig(PredefinedType.PT_INT, UnaOpMask.Signed, 7, BindIntUnaOp, UnaOpFuncKind.IntUnaOp),
			new UnaOpSig(PredefinedType.PT_UINT, UnaOpMask.Unsigned, 6, BindIntUnaOp, UnaOpFuncKind.IntUnaOp),
			new UnaOpSig(PredefinedType.PT_LONG, UnaOpMask.Signed, 5, BindIntUnaOp, UnaOpFuncKind.IntUnaOp),
			new UnaOpSig(PredefinedType.PT_ULONG, UnaOpMask.Unsigned, 4, BindIntUnaOp, UnaOpFuncKind.IntUnaOp),
			new UnaOpSig(PredefinedType.PT_ULONG, UnaOpMask.Minus, 3, null, UnaOpFuncKind.None),
			new UnaOpSig(PredefinedType.PT_FLOAT, UnaOpMask.Real, 1, BindRealUnaOp, UnaOpFuncKind.RealUnaOp),
			new UnaOpSig(PredefinedType.PT_DOUBLE, UnaOpMask.Real, 0, BindRealUnaOp, UnaOpFuncKind.RealUnaOp),
			new UnaOpSig(PredefinedType.PT_DECIMAL, UnaOpMask.Real, 0, BindDecUnaOp, UnaOpFuncKind.DecUnaOp),
			new UnaOpSig(PredefinedType.PT_BOOL, UnaOpMask.Bang, 0, BindBoolUnaOp, UnaOpFuncKind.BoolUnaOp),
			new UnaOpSig(PredefinedType.PT_INT, UnaOpMask.IncDec, 6, null, UnaOpFuncKind.None),
			new UnaOpSig(PredefinedType.PT_UINT, UnaOpMask.IncDec, 5, null, UnaOpFuncKind.None),
			new UnaOpSig(PredefinedType.PT_LONG, UnaOpMask.IncDec, 4, null, UnaOpFuncKind.None),
			new UnaOpSig(PredefinedType.PT_ULONG, UnaOpMask.IncDec, 3, null, UnaOpFuncKind.None),
			new UnaOpSig(PredefinedType.PT_FLOAT, UnaOpMask.IncDec, 1, null, UnaOpFuncKind.None),
			new UnaOpSig(PredefinedType.PT_DOUBLE, UnaOpMask.IncDec, 0, null, UnaOpFuncKind.None),
			new UnaOpSig(PredefinedType.PT_DECIMAL, UnaOpMask.IncDec, 0, null, UnaOpFuncKind.None)
		};

		public BindingContext Context { get; }

		private AggregateSymbol ContextForMemberLookup => Context.ContextForMemberLookup;

		private static BetterType WhichMethodIsBetterTieBreaker(CandidateFunctionMember node1, CandidateFunctionMember node2, CType pTypeThrough, ArgInfos args)
		{
			MethPropWithInst mpwi = node1.mpwi;
			MethPropWithInst mpwi2 = node2.mpwi;
			if (node1.ctypeLift != node2.ctypeLift)
			{
				if (node1.ctypeLift >= node2.ctypeLift)
				{
					return BetterType.Right;
				}
				return BetterType.Left;
			}
			if (mpwi.TypeArgs.Count != 0)
			{
				if (mpwi2.TypeArgs.Count == 0)
				{
					return BetterType.Right;
				}
			}
			else if (mpwi2.TypeArgs.Count != 0)
			{
				return BetterType.Left;
			}
			if (node1.fExpanded)
			{
				if (!node2.fExpanded)
				{
					return BetterType.Right;
				}
			}
			else if (node2.fExpanded)
			{
				return BetterType.Left;
			}
			BetterType betterType = CompareTypes(RearrangeNamedArguments(mpwi.MethProp().Params, mpwi, pTypeThrough, args), RearrangeNamedArguments(mpwi2.MethProp().Params, mpwi2, pTypeThrough, args));
			if (betterType == BetterType.Left || betterType == BetterType.Right)
			{
				return betterType;
			}
			if (mpwi.MethProp().modOptCount != mpwi2.MethProp().modOptCount)
			{
				if (mpwi.MethProp().modOptCount >= mpwi2.MethProp().modOptCount)
				{
					return BetterType.Right;
				}
				return BetterType.Left;
			}
			return BetterType.Neither;
		}

		private static BetterType CompareTypes(TypeArray ta1, TypeArray ta2)
		{
			if (ta1 == ta2)
			{
				return BetterType.Same;
			}
			if (ta1.Count != ta2.Count)
			{
				if (ta1.Count <= ta2.Count)
				{
					return BetterType.Right;
				}
				return BetterType.Left;
			}
			BetterType betterType = BetterType.Neither;
			for (int i = 0; i < ta1.Count; i++)
			{
				CType cType = ta1[i];
				CType cType2 = ta2[i];
				BetterType betterType2 = BetterType.Neither;
				while (true)
				{
					if (cType.TypeKind != cType2.TypeKind)
					{
						if (cType is TypeParameterType)
						{
							betterType2 = BetterType.Right;
						}
						else if (cType2 is TypeParameterType)
						{
							betterType2 = BetterType.Left;
						}
					}
					else
					{
						switch (cType.TypeKind)
						{
						case TypeKind.TK_ArrayType:
						case TypeKind.TK_PointerType:
						case TypeKind.TK_ParameterModifierType:
						case TypeKind.TK_NullableType:
							goto IL_00a3;
						case TypeKind.TK_AggregateType:
							betterType2 = CompareTypes(((AggregateType)cType).TypeArgsAll, ((AggregateType)cType2).TypeArgsAll);
							break;
						}
					}
					break;
					IL_00a3:
					cType = cType.BaseOrParameterOrElementType;
					cType2 = cType2.BaseOrParameterOrElementType;
				}
				if (betterType2 == BetterType.Right || betterType2 == BetterType.Left)
				{
					if (betterType == BetterType.Same || betterType == BetterType.Neither)
					{
						betterType = betterType2;
					}
					else if (betterType2 != betterType)
					{
						return BetterType.Neither;
					}
				}
			}
			return betterType;
		}

		private static int FindName(List<Name> names, Name name)
		{
			return names.IndexOf(name);
		}

		private static TypeArray RearrangeNamedArguments(TypeArray pta, MethPropWithInst mpwi, CType pTypeThrough, ArgInfos args)
		{
			if (args.carg == 0 || !(args.prgexpr[args.carg - 1] is ExprNamedArgumentSpecification))
			{
				return pta;
			}
			CType pType = ((pTypeThrough != null) ? pTypeThrough : mpwi.GetType());
			CType[] array = new CType[pta.Count];
			MethodOrPropertySymbol methodOrPropertySymbol = GroupToArgsBinder.FindMostDerivedMethod(mpwi.MethProp(), pType);
			for (int i = 0; i < pta.Count; i++)
			{
				array[i] = pta[i];
			}
			List<Expr> prgexpr = args.prgexpr;
			for (int j = 0; j < args.carg; j++)
			{
				if (prgexpr[j] is ExprNamedArgumentSpecification exprNamedArgumentSpecification)
				{
					int num = FindName(methodOrPropertySymbol.ParameterNames, exprNamedArgumentSpecification.Name);
					CType cType = pta[num];
					for (int k = j; k < num; k++)
					{
						array[k + 1] = array[k];
					}
					array[j] = cType;
				}
			}
			return TypeArray.Allocate(array);
		}

		private BetterType WhichMethodIsBetter(CandidateFunctionMember node1, CandidateFunctionMember node2, CType pTypeThrough, ArgInfos args)
		{
			MethPropWithInst mpwi = node1.mpwi;
			MethPropWithInst mpwi2 = node2.mpwi;
			TypeArray typeArray = RearrangeNamedArguments(node1.@params, mpwi, pTypeThrough, args);
			TypeArray typeArray2 = RearrangeNamedArguments(node2.@params, mpwi2, pTypeThrough, args);
			if (typeArray == typeArray2)
			{
				return WhichMethodIsBetterTieBreaker(node1, node2, pTypeThrough, args);
			}
			BetterType betterType = BetterType.Neither;
			int carg = args.carg;
			for (int i = 0; i < carg; i++)
			{
				Expr expr = args.prgexpr[i];
				CType p = typeArray[i];
				CType p2 = typeArray2[i];
				CType argType = expr?.RuntimeObjectActualType ?? args.types[i];
				BetterType betterType2 = WhichConversionIsBetter(argType, p, p2);
				switch (betterType)
				{
				case BetterType.Right:
					if (betterType2 != BetterType.Left)
					{
						continue;
					}
					betterType = BetterType.Neither;
					break;
				case BetterType.Left:
					if (betterType2 != BetterType.Right)
					{
						continue;
					}
					betterType = BetterType.Neither;
					break;
				default:
					if (betterType2 == BetterType.Right || betterType2 == BetterType.Left)
					{
						betterType = betterType2;
					}
					continue;
				}
				break;
			}
			if (typeArray.Count != typeArray2.Count && betterType == BetterType.Neither)
			{
				if (node1.fExpanded)
				{
					if (!node2.fExpanded)
					{
						return BetterType.Right;
					}
				}
				else if (node2.fExpanded)
				{
					return BetterType.Left;
				}
				if (typeArray.Count == carg)
				{
					return BetterType.Left;
				}
				if (typeArray2.Count == carg)
				{
					return BetterType.Right;
				}
				return BetterType.Neither;
			}
			return betterType;
		}

		private BetterType WhichConversionIsBetter(CType argType, CType p1, CType p2)
		{
			if (p1 == p2)
			{
				return BetterType.Same;
			}
			if (argType == p1)
			{
				return BetterType.Left;
			}
			if (argType == p2)
			{
				return BetterType.Right;
			}
			bool flag = canConvert(p1, p2);
			bool flag2 = canConvert(p2, p1);
			if (flag != flag2)
			{
				if (!flag)
				{
					return BetterType.Right;
				}
				return BetterType.Left;
			}
			if (p1.IsPredefined && p2.IsPredefined)
			{
				PredefinedType predefinedType = p1.PredefinedType;
				if (predefinedType <= PredefinedType.PT_OBJECT)
				{
					PredefinedType predefinedType2 = p2.PredefinedType;
					if (predefinedType2 <= PredefinedType.PT_OBJECT)
					{
						return (BetterType)s_betterConversionTable[(uint)predefinedType][(uint)predefinedType2];
					}
				}
			}
			return BetterType.Neither;
		}

		private CandidateFunctionMember FindBestMethod(List<CandidateFunctionMember> list, CType pTypeThrough, ArgInfos args, out CandidateFunctionMember methAmbig1, out CandidateFunctionMember methAmbig2)
		{
			CandidateFunctionMember candidateFunctionMember = null;
			CandidateFunctionMember candidateFunctionMember2 = null;
			bool flag = false;
			CandidateFunctionMember candidateFunctionMember3 = list[0];
			for (int i = 1; i < list.Count; i++)
			{
				CandidateFunctionMember candidateFunctionMember4 = list[i];
				switch (WhichMethodIsBetter(candidateFunctionMember3, candidateFunctionMember4, pTypeThrough, args))
				{
				case BetterType.Left:
					flag = false;
					continue;
				case BetterType.Right:
					flag = false;
					candidateFunctionMember3 = candidateFunctionMember4;
					continue;
				}
				candidateFunctionMember = candidateFunctionMember3;
				candidateFunctionMember2 = candidateFunctionMember4;
				i++;
				if (i < list.Count)
				{
					candidateFunctionMember4 = list[i];
					candidateFunctionMember3 = candidateFunctionMember4;
				}
				else
				{
					flag = true;
				}
			}
			if (!flag)
			{
				foreach (CandidateFunctionMember item in list)
				{
					if (item == candidateFunctionMember3)
					{
						methAmbig1 = null;
						methAmbig2 = null;
						return candidateFunctionMember3;
					}
					switch (WhichMethodIsBetter(item, candidateFunctionMember3, pTypeThrough, args))
					{
					case BetterType.Same:
					case BetterType.Neither:
						candidateFunctionMember = candidateFunctionMember3;
						candidateFunctionMember2 = item;
						break;
					case BetterType.Right:
						continue;
					case BetterType.Left:
						break;
					}
					break;
				}
			}
			if (candidateFunctionMember != null && candidateFunctionMember2 != null)
			{
				methAmbig1 = candidateFunctionMember;
				methAmbig2 = candidateFunctionMember2;
			}
			else
			{
				methAmbig1 = list.First();
				methAmbig2 = list.Skip(1).First();
			}
			return null;
		}

		private static void RoundToFloat(double d, out float f)
		{
			f = (float)d;
		}

		private static long I64(long x)
		{
			return x;
		}

		private static long I64(ulong x)
		{
			return (long)x;
		}

		private static ConvKind GetConvKind(PredefinedType ptSrc, PredefinedType ptDst)
		{
			if ((int)ptSrc < 13 && (int)ptDst < 13)
			{
				return (ConvKind)(s_simpleTypeConversions[(uint)ptSrc][(uint)ptDst] & 0xF);
			}
			if (ptSrc == ptDst || (ptDst == PredefinedType.PT_OBJECT && ptSrc < PredefinedType.PT_COUNT))
			{
				return ConvKind.Implicit;
			}
			if (ptSrc == PredefinedType.PT_OBJECT && ptDst < PredefinedType.PT_COUNT)
			{
				return ConvKind.Explicit;
			}
			return ConvKind.Unknown;
		}

		private static bool isUserDefinedConversion(PredefinedType ptSrc, PredefinedType ptDst)
		{
			if ((int)ptSrc < 13 && (int)ptDst < 13)
			{
				return (s_simpleTypeConversions[(uint)ptSrc][(uint)ptDst] & 0x40) != 0;
			}
			return false;
		}

		private BetterType WhichSimpleConversionIsBetter(PredefinedType pt1, PredefinedType pt2)
		{
			return (BetterType)s_simpleTypeBetter[(uint)pt1][(uint)pt2];
		}

		private BetterType WhichTypeIsBetter(PredefinedType pt1, PredefinedType pt2, CType typeGiven)
		{
			if (pt1 == pt2)
			{
				return BetterType.Same;
			}
			if (typeGiven.IsPredefType(pt1))
			{
				return BetterType.Left;
			}
			if (typeGiven.IsPredefType(pt2))
			{
				return BetterType.Right;
			}
			if ((int)pt1 < 16 && (int)pt2 < 16)
			{
				return WhichSimpleConversionIsBetter(pt1, pt2);
			}
			if (pt2 == PredefinedType.PT_OBJECT && pt1 < PredefinedType.PT_COUNT)
			{
				return BetterType.Left;
			}
			if (pt1 == PredefinedType.PT_OBJECT && pt2 < PredefinedType.PT_COUNT)
			{
				return BetterType.Right;
			}
			return WhichTypeIsBetter(GetPredefindType(pt1), GetPredefindType(pt2), typeGiven);
		}

		private BetterType WhichTypeIsBetter(CType type1, CType type2, CType typeGiven)
		{
			if (type1 == type2)
			{
				return BetterType.Same;
			}
			if (typeGiven == type1)
			{
				return BetterType.Left;
			}
			if (typeGiven == type2)
			{
				return BetterType.Right;
			}
			bool flag = canConvert(type1, type2);
			bool flag2 = canConvert(type2, type1);
			if (flag != flag2)
			{
				if (!flag)
				{
					return BetterType.Right;
				}
				return BetterType.Left;
			}
			if (!(type1 is NullableType nullableType) || !(type2 is NullableType nullableType2) || !nullableType.UnderlyingType.IsPredefined || !nullableType2.UnderlyingType.IsPredefined)
			{
				return BetterType.Neither;
			}
			PredefinedType predefinedType = (type1 as NullableType).UnderlyingType.PredefinedType;
			PredefinedType predefinedType2 = (type2 as NullableType).UnderlyingType.PredefinedType;
			if ((int)predefinedType < 16 && (int)predefinedType2 < 16)
			{
				return WhichSimpleConversionIsBetter(predefinedType, predefinedType2);
			}
			return BetterType.Neither;
		}

		private bool canConvert(CType src, CType dest, CONVERTTYPE flags)
		{
			return BindImplicitConversion(null, src, dest, flags);
		}

		public bool canConvert(CType src, CType dest)
		{
			return canConvert(src, dest, (CONVERTTYPE)0);
		}

		private bool canConvert(Expr expr, CType dest)
		{
			return canConvert(expr, dest, (CONVERTTYPE)0);
		}

		private bool canConvert(Expr expr, CType dest, CONVERTTYPE flags)
		{
			return BindImplicitConversion(expr, expr.Type, dest, flags);
		}

		private Expr mustConvertCore(Expr expr, CType destExpr)
		{
			return mustConvertCore(expr, destExpr, (CONVERTTYPE)0);
		}

		private Expr mustConvertCore(Expr expr, CType dest, CONVERTTYPE flags)
		{
			if (BindImplicitConversion(expr, expr.Type, dest, out var ppDestinationExpr, flags))
			{
				CheckUnsafe(expr.Type);
				CheckUnsafe(dest);
				return ppDestinationExpr;
			}
			FUNDTYPE fundamentalType = expr.Type.FundamentalType;
			FUNDTYPE fundamentalType2 = dest.FundamentalType;
			if (expr is ExprConstant exprConstant && expr.Type.IsSimpleType && dest.IsSimpleType && ((fundamentalType == FUNDTYPE.FT_I4 && (fundamentalType2 <= FUNDTYPE.FT_U4 || fundamentalType2 == FUNDTYPE.FT_U8)) || (fundamentalType == FUNDTYPE.FT_I8 && fundamentalType2 == FUNDTYPE.FT_U8)))
			{
				string text = exprConstant.Int64Value.ToString(CultureInfo.InvariantCulture);
				throw ErrorHandling.Error(ErrorCode.ERR_ConstOutOfRange, text, dest);
			}
			if (expr.Type is NullType && dest.FundamentalType != FUNDTYPE.FT_REF)
			{
				throw ErrorHandling.Error(ErrorCode.ERR_ValueCantBeNull, dest);
			}
			throw ErrorHandling.Error(canCast(expr.Type, dest, flags) ? ErrorCode.ERR_NoImplicitConvCast : ErrorCode.ERR_NoImplicitConv, new ErrArg(expr.Type, ErrArgFlags.Unique), new ErrArg(dest, ErrArgFlags.Unique));
		}

		public Expr tryConvert(Expr expr, CType dest)
		{
			return tryConvert(expr, dest, (CONVERTTYPE)0);
		}

		private Expr tryConvert(Expr expr, CType dest, CONVERTTYPE flags)
		{
			if (BindImplicitConversion(expr, expr.Type, dest, out var ppDestinationExpr, flags))
			{
				CheckUnsafe(expr.Type);
				CheckUnsafe(dest);
				return ppDestinationExpr;
			}
			return null;
		}

		public Expr mustConvert(Expr expr, CType dest)
		{
			return mustConvert(expr, dest, (CONVERTTYPE)0);
		}

		private Expr mustConvert(Expr expr, CType dest, CONVERTTYPE flags)
		{
			return mustConvertCore(expr, dest, flags);
		}

		private Expr mustCastCore(Expr expr, CType dest, CONVERTTYPE flags)
		{
			CSemanticChecker.CheckForStaticClass(dest);
			if (BindExplicitConversion(expr, expr.Type, dest, out var ppDestinationExpr, flags))
			{
				CheckUnsafe(expr.Type);
				CheckUnsafe(dest);
				return ppDestinationExpr;
			}
			Expr expr2 = expr.GetConst();
			if (expr2 != null && expr.Type.IsSimpleOrEnum && dest.IsSimpleOrEnum)
			{
				FUNDTYPE fundamentalType = expr.Type.FundamentalType;
				if (fundamentalType == FUNDTYPE.FT_STRUCT)
				{
					throw ErrorHandling.Error(ErrorCode.ERR_ConstOutOfRange, ((ExprConstant)expr2).Val.DecimalVal.ToString(CultureInfo.InvariantCulture), dest);
				}
				if (Context.Checked)
				{
					if (!CanExplicitConversionBeBoundInUncheckedContext(expr, expr.Type, dest, flags | CONVERTTYPE.NOUDC))
					{
						throw CantConvert(expr, dest);
					}
					string text;
					switch (fundamentalType)
					{
					case FUNDTYPE.FT_U1:
					case FUNDTYPE.FT_U2:
					case FUNDTYPE.FT_U4:
					case FUNDTYPE.FT_U8:
						text = ((ulong)((ExprConstant)expr2).Int64Value).ToString(CultureInfo.InvariantCulture);
						break;
					case FUNDTYPE.FT_I1:
					case FUNDTYPE.FT_I2:
					case FUNDTYPE.FT_I4:
					case FUNDTYPE.FT_I8:
						text = ((ExprConstant)expr2).Int64Value.ToString(CultureInfo.InvariantCulture);
						break;
					default:
						text = ((ExprConstant)expr2).Val.DoubleVal.ToString(CultureInfo.InvariantCulture);
						break;
					}
					throw ErrorHandling.Error(ErrorCode.ERR_ConstOutOfRangeChecked, text, dest);
				}
			}
			if (expr.Type is NullType && dest.FundamentalType != FUNDTYPE.FT_REF)
			{
				throw ErrorHandling.Error(ErrorCode.ERR_ValueCantBeNull, dest);
			}
			throw CantConvert(expr, dest);
		}

		private static RuntimeBinderException CantConvert(Expr expr, CType dest)
		{
			return ErrorHandling.Error(ErrorCode.ERR_NoExplicitConv, new ErrArg(expr.Type, ErrArgFlags.Unique), new ErrArg(dest, ErrArgFlags.Unique));
		}

		public Expr mustCast(Expr expr, CType dest)
		{
			return mustCast(expr, dest, (CONVERTTYPE)0);
		}

		public Expr mustCast(Expr expr, CType dest, CONVERTTYPE flags)
		{
			return mustCastCore(expr, dest, flags);
		}

		private Expr MustCastInUncheckedContext(Expr expr, CType dest, CONVERTTYPE flags)
		{
			return new ExpressionBinder(new BindingContext(Context)).mustCast(expr, dest, flags);
		}

		private bool canCast(CType src, CType dest, CONVERTTYPE flags)
		{
			return BindExplicitConversion(null, src, dest, flags);
		}

		private bool BindImplicitConversion(Expr pSourceExpr, CType pSourceType, CType destinationType, CONVERTTYPE flags)
		{
			return new ImplicitConversion(this, pSourceExpr, pSourceType, destinationType, needsExprDest: false, flags).Bind();
		}

		private bool BindImplicitConversion(Expr pSourceExpr, CType pSourceType, CType destinationType, out Expr ppDestinationExpr, CONVERTTYPE flags)
		{
			ImplicitConversion implicitConversion = new ImplicitConversion(this, pSourceExpr, pSourceType, destinationType, needsExprDest: true, flags);
			bool result = implicitConversion.Bind();
			ppDestinationExpr = implicitConversion.ExprDest;
			return result;
		}

		private bool BindImplicitConversion(Expr pSourceExpr, CType pSourceType, CType destinationType, bool needsExprDest, out Expr ppDestinationExpr, CONVERTTYPE flags)
		{
			ImplicitConversion implicitConversion = new ImplicitConversion(this, pSourceExpr, pSourceType, destinationType, needsExprDest, flags);
			bool result = implicitConversion.Bind();
			ppDestinationExpr = (needsExprDest ? implicitConversion.ExprDest : null);
			return result;
		}

		private bool BindExplicitConversion(Expr pSourceExpr, CType pSourceType, CType destinationType, bool needsExprDest, out Expr ppDestinationExpr, CONVERTTYPE flags)
		{
			ExplicitConversion explicitConversion = new ExplicitConversion(this, pSourceExpr, pSourceType, destinationType, needsExprDest, flags);
			bool result = explicitConversion.Bind();
			ppDestinationExpr = (needsExprDest ? explicitConversion.ExprDest : null);
			return result;
		}

		private bool BindExplicitConversion(Expr pSourceExpr, CType pSourceType, CType destinationType, out Expr ppDestinationExpr, CONVERTTYPE flags)
		{
			ExplicitConversion explicitConversion = new ExplicitConversion(this, pSourceExpr, pSourceType, destinationType, needsExprDest: true, flags);
			bool result = explicitConversion.Bind();
			ppDestinationExpr = explicitConversion.ExprDest;
			return result;
		}

		private bool BindExplicitConversion(Expr pSourceExpr, CType pSourceType, CType destinationType, CONVERTTYPE flags)
		{
			return new ExplicitConversion(this, pSourceExpr, pSourceType, destinationType, needsExprDest: false, flags).Bind();
		}

		private bool bindUserDefinedConversion(Expr exprSrc, CType typeSrc, CType typeDst, bool needExprDest, out Expr pexprDst, bool fImplicitOnly)
		{
			pexprDst = null;
			if (typeSrc == null || typeDst == null || typeSrc.IsInterfaceType || typeDst.IsInterfaceType)
			{
				return false;
			}
			CType cType = typeSrc.StripNubs();
			CType cType2 = typeDst.StripNubs();
			bool flag = cType != typeSrc;
			bool flag2 = cType2 != typeDst;
			bool flag3 = flag2 || typeDst.IsReferenceType || typeDst is PointerType;
			AggregateType[] array = new AggregateType[2];
			int num = 0;
			bool flag4 = fImplicitOnly;
			bool flag5 = false;
			if (cType is AggregateType aggregateType && aggregateType.OwningAggregate.HasConversion())
			{
				array[num++] = aggregateType;
				flag5 = aggregateType.IsPredefType(PredefinedType.FirstNonSimpleType) || aggregateType.IsPredefType(PredefinedType.PT_UINTPTR);
			}
			if (cType2 is AggregateType aggregateType2)
			{
				if (aggregateType2.OwningAggregate.HasConversion())
				{
					array[num++] = aggregateType2;
				}
				if (flag5 && !cType2.IsPredefType(PredefinedType.PT_LONG) && !cType2.IsPredefType(PredefinedType.PT_ULONG))
				{
					flag5 = false;
				}
			}
			else
			{
				flag5 = false;
			}
			if (num == 0)
			{
				return false;
			}
			List<UdConvInfo> list = new List<UdConvInfo>();
			CType cType3 = null;
			CType cType4 = null;
			bool flag6 = false;
			bool flag7 = false;
			int num2 = -1;
			int num3 = -1;
			CType cType5;
			CType cType6;
			for (int i = 0; i < num; i++)
			{
				AggregateType aggregateType3 = array[i];
				while (aggregateType3 != null && aggregateType3.OwningAggregate.HasConversion())
				{
					AggregateSymbol owningAggregate = aggregateType3.OwningAggregate;
					PredefinedType predefType = owningAggregate.GetPredefType();
					bool flag8 = owningAggregate.IsPredefined() && (predefType == PredefinedType.FirstNonSimpleType || predefType == PredefinedType.PT_UINTPTR || predefType == PredefinedType.PT_DECIMAL);
					for (MethodSymbol methodSymbol = owningAggregate.GetFirstUDConversion(); methodSymbol != null; methodSymbol = methodSymbol.ConvNext())
					{
						if (methodSymbol.Params.Count != 1 || (fImplicitOnly && !methodSymbol.isImplicit()))
						{
							continue;
						}
						cType5 = TypeManager.SubstType(methodSymbol.Params[0], aggregateType3);
						cType6 = TypeManager.SubstType(methodSymbol.RetType, aggregateType3);
						bool flag9 = fImplicitOnly;
						if (flag4 && !flag9 && cType5.StripNubs() != cType)
						{
							if (!methodSymbol.isImplicit())
							{
								continue;
							}
							flag9 = true;
						}
						FUNDTYPE fundamentalType;
						FUNDTYPE fundamentalType2;
						if (((fundamentalType = cType6.FundamentalType) <= FUNDTYPE.FT_R8 && fundamentalType > FUNDTYPE.FT_NONE && (fundamentalType2 = cType5.FundamentalType) <= FUNDTYPE.FT_R8 && fundamentalType2 > FUNDTYPE.FT_NONE) || (flag5 && (cType6.IsPredefType(PredefinedType.PT_INT) || cType6.IsPredefType(PredefinedType.PT_UINT))))
						{
							continue;
						}
						if (flag && (flag3 || !flag9) && cType5.IsNonNullableValueType)
						{
							cType5 = TypeManager.GetNullable(cType5);
						}
						if (flag2 && cType6.IsNonNullableValueType)
						{
							cType6 = TypeManager.GetNullable(cType6);
						}
						bool flag10 = ((exprSrc != null) ? canConvert(exprSrc, cType5, CONVERTTYPE.STANDARDANDNOUDC) : canConvert(typeSrc, cType5, CONVERTTYPE.STANDARDANDNOUDC));
						if (!flag10 && (flag9 || (!canConvert(cType5, typeSrc, CONVERTTYPE.STANDARDANDNOUDC) && (!flag8 || typeSrc is PointerType || cType5 is PointerType || !canCast(typeSrc, cType5, CONVERTTYPE.NOUDC)))))
						{
							continue;
						}
						bool flag11 = canConvert(cType6, typeDst, CONVERTTYPE.STANDARDANDNOUDC);
						if ((!flag11 && (flag9 || (!canConvert(typeDst, cType6, CONVERTTYPE.STANDARDANDNOUDC) && (!flag8 || typeDst is PointerType || cType6 is PointerType || !canCast(cType6, typeDst, CONVERTTYPE.NOUDC))))) || IsConvInTable(list, methodSymbol, aggregateType3, flag10, flag11))
						{
							continue;
						}
						list.Add(new UdConvInfo(new MethWithType(methodSymbol, aggregateType3), flag10, flag11));
						if (!flag6)
						{
							if (cType5 == typeSrc)
							{
								cType3 = cType5;
								num2 = list.Count - 1;
								flag6 = true;
							}
							else if (cType3 == null)
							{
								cType3 = cType5;
								num2 = list.Count - 1;
							}
							else if (cType3 != cType5 && CompareSrcTypesBased(cType3, list[num2].SrcImplicit, cType5, flag10) > 0)
							{
								cType3 = cType5;
								num2 = list.Count - 1;
							}
						}
						if (!flag7)
						{
							if (cType6 == typeDst)
							{
								cType4 = cType6;
								num3 = list.Count - 1;
								flag7 = true;
							}
							else if (cType4 == null)
							{
								cType4 = cType6;
								num3 = list.Count - 1;
							}
							else if (cType4 != cType6 && CompareDstTypesBased(cType4, list[num3].DstImplicit, cType6, flag11) > 0)
							{
								cType4 = cType6;
								num3 = list.Count - 1;
							}
						}
					}
					aggregateType3 = aggregateType3.BaseClass;
				}
			}
			if (cType3 == null)
			{
				return false;
			}
			int num4 = 3;
			int num5 = -1;
			int num6 = -1;
			for (int j = 0; j < list.Count; j++)
			{
				UdConvInfo udConvInfo = list[j];
				cType5 = TypeManager.SubstType(udConvInfo.Meth.Meth().Params[0], udConvInfo.Meth.GetType());
				cType6 = TypeManager.SubstType(udConvInfo.Meth.Meth().RetType, udConvInfo.Meth.GetType());
				int num7 = 0;
				if (flag && cType5.IsNonNullableValueType)
				{
					cType5 = TypeManager.GetNullable(cType5);
					num7++;
				}
				if (flag2 && cType6.IsNonNullableValueType)
				{
					cType6 = TypeManager.GetNullable(cType6);
					num7++;
				}
				if (cType5 == cType3 && cType6 == cType4)
				{
					if (num4 > num7)
					{
						num5 = j;
						num6 = -1;
						num4 = num7;
					}
					else if (num4 >= num7 && num6 < 0)
					{
						num6 = j;
						if (num7 == 0)
						{
							break;
						}
					}
					continue;
				}
				if (!flag6 && cType5 != cType3 && CompareSrcTypesBased(cType3, list[num2].SrcImplicit, cType5, udConvInfo.SrcImplicit) >= 0)
				{
					if (needExprDest)
					{
						throw HandleAmbiguity(typeSrc, typeDst, list, num2, j);
					}
					return true;
				}
				if (!flag7 && cType6 != cType4 && CompareDstTypesBased(cType4, list[num3].DstImplicit, cType6, udConvInfo.DstImplicit) >= 0)
				{
					if (needExprDest)
					{
						throw HandleAmbiguity(typeSrc, typeDst, list, num2, j);
					}
					return true;
				}
			}
			if (!needExprDest)
			{
				return true;
			}
			if (num5 < 0)
			{
				throw HandleAmbiguity(typeSrc, typeDst, list, num2, num3);
			}
			if (num6 >= 0)
			{
				throw HandleAmbiguity(typeSrc, typeDst, list, num5, num6);
			}
			MethWithInst methWithInst = new MethWithInst(list[num5].Meth.Meth(), list[num5].Meth.GetType(), null);
			cType5 = TypeManager.SubstType(methWithInst.Meth().Params[0], methWithInst.GetType());
			cType6 = TypeManager.SubstType(methWithInst.Meth().RetType, methWithInst.GetType());
			Expr ppTransformedArgument = exprSrc;
			Expr call;
			if (num4 > 0 && !(cType5 is NullableType) && flag3)
			{
				ExprMemberGroup memberGroup = ExprFactory.CreateMemGroup(null, methWithInst);
				ExprCall exprCall = ExprFactory.CreateCall((EXPRFLAG)0, typeDst, exprSrc, memberGroup, methWithInst);
				call = exprCall;
				Expr expr = mustCast(exprSrc, cType5);
				MarkAsIntermediateConversion(expr);
				Expr expr2 = BindUDConversionCore(expr, cType5, cType6, typeDst, methWithInst);
				exprCall.CastOfNonLiftedResultToLiftedType = mustCast(expr2, typeDst);
				exprCall.NullableCallLiftKind = NullableCallLiftKind.UserDefinedConversion;
				if (flag)
				{
					Expr expr3;
					if (cType5 == cType)
					{
						expr3 = ((!(cType6 is NullableType)) ? exprSrc : mustCast(exprSrc, cType5));
					}
					else
					{
						NullableType nullable = TypeManager.GetNullable(cType5);
						expr3 = mustCast(exprSrc, nullable);
						MarkAsIntermediateConversion(expr3);
					}
					ExprCall exprCall2 = ExprFactory.CreateCall((EXPRFLAG)0, typeDst, expr3, memberGroup, methWithInst);
					exprCall2.NullableCallLiftKind = NullableCallLiftKind.NotLiftedIntermediateConversion;
					exprCall.PConversions = exprCall2;
				}
				else
				{
					Expr expr4 = BindUDConversionCore(expr, cType5, cType6, typeDst, methWithInst);
					MarkAsIntermediateConversion(expr4);
					exprCall.PConversions = expr4;
				}
			}
			else
			{
				call = BindUDConversionCore(exprSrc, cType5, cType6, typeDst, methWithInst, out ppTransformedArgument);
			}
			pexprDst = ExprFactory.CreateUserDefinedConversion(ppTransformedArgument, call, methWithInst);
			return true;
		}

		private static RuntimeBinderException HandleAmbiguity(CType typeSrc, CType typeDst, List<UdConvInfo> prguci, int iuciBestSrc, int iuciBestDst)
		{
			return ErrorHandling.Error(ErrorCode.ERR_AmbigUDConv, prguci[iuciBestSrc].Meth, prguci[iuciBestDst].Meth, typeSrc, typeDst);
		}

		private static void MarkAsIntermediateConversion(Expr pExpr)
		{
			while (true)
			{
				if (pExpr is ExprCall { NullableCallLiftKind: var nullableCallLiftKind } exprCall)
				{
					switch (nullableCallLiftKind)
					{
					default:
						return;
					case NullableCallLiftKind.NotLifted:
						exprCall.NullableCallLiftKind = NullableCallLiftKind.NotLiftedIntermediateConversion;
						return;
					case NullableCallLiftKind.NullableConversion:
						exprCall.NullableCallLiftKind = NullableCallLiftKind.NullableIntermediateConversion;
						return;
					case NullableCallLiftKind.NullableConversionConstructor:
						pExpr = exprCall.OptionalArguments;
						break;
					}
				}
				else
				{
					if (!(pExpr is ExprUserDefinedConversion exprUserDefinedConversion))
					{
						break;
					}
					pExpr = exprUserDefinedConversion.UserDefinedCall;
				}
			}
		}

		private Expr BindUDConversionCore(Expr pFrom, CType pTypeFrom, CType pTypeTo, CType pTypeDestination, MethWithInst mwiBest)
		{
			Expr ppTransformedArgument;
			return BindUDConversionCore(pFrom, pTypeFrom, pTypeTo, pTypeDestination, mwiBest, out ppTransformedArgument);
		}

		private Expr BindUDConversionCore(Expr pFrom, CType pTypeFrom, CType pTypeTo, CType pTypeDestination, MethWithInst mwiBest, out Expr ppTransformedArgument)
		{
			Expr expr = mustCastCore(pFrom, pTypeFrom, CONVERTTYPE.NOUDC);
			ExprMemberGroup memberGroup = ExprFactory.CreateMemGroup(null, mwiBest);
			ExprCall expr2 = ExprFactory.CreateCall((EXPRFLAG)0, pTypeTo, expr, memberGroup, mwiBest);
			Expr result = mustCastCore(expr2, pTypeDestination, CONVERTTYPE.NOUDC);
			ppTransformedArgument = expr;
			return result;
		}

		private ConstCastResult bindConstantCast(Expr exprSrc, CType typeDest, bool needExprDest, out Expr pexprDest, bool explicitConversion)
		{
			pexprDest = null;
			long num = 0L;
			double num2 = 0.0;
			FUNDTYPE fundamentalType = exprSrc.Type.FundamentalType;
			FUNDTYPE fundamentalType2 = typeDest.FundamentalType;
			bool flag = fundamentalType <= FUNDTYPE.FT_U8;
			bool flag2 = fundamentalType <= FUNDTYPE.FT_R8;
			ExprConstant exprConstant = (ExprConstant)exprSrc.GetConst();
			if (fundamentalType == FUNDTYPE.FT_STRUCT || fundamentalType2 == FUNDTYPE.FT_STRUCT)
			{
				Expr expr = BindDecimalConstCast(typeDest, exprSrc.Type, exprConstant);
				if (expr == null)
				{
					if (explicitConversion)
					{
						return ConstCastResult.CheckFailure;
					}
					return ConstCastResult.Failure;
				}
				if (needExprDest)
				{
					pexprDest = expr;
				}
				return ConstCastResult.Success;
			}
			if (explicitConversion && Context.Checked && !isConstantInRange(exprConstant, typeDest, realsOk: true))
			{
				return ConstCastResult.CheckFailure;
			}
			if (!needExprDest)
			{
				return ConstCastResult.Success;
			}
			if (flag)
			{
				if (exprConstant.Type.FundamentalType == FUNDTYPE.FT_U8)
				{
					if (fundamentalType2 == FUNDTYPE.FT_U8)
					{
						ConstVal constVal = ConstVal.Get(exprConstant.UInt64Value);
						pexprDest = ExprFactory.CreateConstant(typeDest, constVal);
						return ConstCastResult.Success;
					}
					num = (long)exprConstant.UInt64Value & -1L;
				}
				else
				{
					num = exprConstant.Int64Value;
				}
			}
			else
			{
				if (!flag2)
				{
					return ConstCastResult.Failure;
				}
				num2 = exprConstant.Val.DoubleVal;
			}
			switch (fundamentalType2)
			{
			case FUNDTYPE.FT_I1:
				if (!flag)
				{
					num = (long)num2;
				}
				num = (sbyte)(num & 0xFF);
				break;
			case FUNDTYPE.FT_I2:
				if (!flag)
				{
					num = (long)num2;
				}
				num = (short)(num & 0xFFFF);
				break;
			case FUNDTYPE.FT_I4:
				if (!flag)
				{
					num = (long)num2;
				}
				num = (int)(num & 0xFFFFFFFFu);
				break;
			case FUNDTYPE.FT_I8:
				if (!flag)
				{
					num = (long)num2;
				}
				break;
			case FUNDTYPE.FT_U1:
				if (!flag)
				{
					num = (long)num2;
				}
				num &= 0xFF;
				break;
			case FUNDTYPE.FT_U2:
				if (!flag)
				{
					num = (long)num2;
				}
				num &= 0xFFFF;
				break;
			case FUNDTYPE.FT_U4:
				if (!flag)
				{
					num = (long)num2;
				}
				num &= 0xFFFFFFFFu;
				break;
			case FUNDTYPE.FT_U8:
				if (!flag)
				{
					num = (long)(ulong)num2;
					num = ((!(num2 < 9.223372036854776E+18)) ? ((long)(num2 - 9.223372036854776E+18) + I64(9223372036854775808uL)) : ((long)num2));
				}
				break;
			case FUNDTYPE.FT_R4:
			case FUNDTYPE.FT_R8:
				if (flag)
				{
					num2 = ((fundamentalType != FUNDTYPE.FT_U8) ? ((double)num) : ((double)(ulong)num));
				}
				if (fundamentalType2 == FUNDTYPE.FT_R4)
				{
					RoundToFloat(num2, out var f);
					num2 = f;
				}
				break;
			}
			ConstVal constVal2 = ((fundamentalType2 == FUNDTYPE.FT_U4) ? ConstVal.Get((uint)num) : ((fundamentalType2 <= FUNDTYPE.FT_U4) ? ConstVal.Get((int)num) : ((fundamentalType2 > FUNDTYPE.FT_U8) ? ConstVal.Get(num2) : ConstVal.Get(num))));
			ExprConstant exprConstant2 = ExprFactory.CreateConstant(typeDest, constVal2);
			pexprDest = exprConstant2;
			return ConstCastResult.Success;
		}

		private int CompareSrcTypesBased(CType type1, bool fImplicit1, CType type2, bool fImplicit2)
		{
			if (fImplicit1 != fImplicit2)
			{
				if (!fImplicit1)
				{
					return 1;
				}
				return -1;
			}
			bool flag = canConvert(type1, type2, CONVERTTYPE.NOUDC);
			bool flag2 = canConvert(type2, type1, CONVERTTYPE.NOUDC);
			if (flag == flag2)
			{
				return 0;
			}
			if (fImplicit1 != flag)
			{
				return 1;
			}
			return -1;
		}

		private int CompareDstTypesBased(CType type1, bool fImplicit1, CType type2, bool fImplicit2)
		{
			if (fImplicit1 != fImplicit2)
			{
				if (!fImplicit1)
				{
					return 1;
				}
				return -1;
			}
			bool flag = canConvert(type1, type2, CONVERTTYPE.NOUDC);
			bool flag2 = canConvert(type2, type1, CONVERTTYPE.NOUDC);
			if (flag == flag2)
			{
				return 0;
			}
			if (fImplicit1 != flag)
			{
				return -1;
			}
			return 1;
		}

		private static Expr BindDecimalConstCast(CType destType, CType srcType, ExprConstant src)
		{
			CType predefindType = SymbolLoader.GetPredefindType(PredefinedType.PT_DECIMAL);
			if (predefindType == null)
			{
				return null;
			}
			if (destType == predefindType)
			{
				decimal value;
				switch (srcType.FundamentalType)
				{
				case FUNDTYPE.FT_I1:
				case FUNDTYPE.FT_I2:
				case FUNDTYPE.FT_I4:
					value = Convert.ToDecimal(src.Val.Int32Val);
					break;
				case FUNDTYPE.FT_U1:
				case FUNDTYPE.FT_U2:
				case FUNDTYPE.FT_U4:
					value = Convert.ToDecimal(src.Val.UInt32Val);
					break;
				case FUNDTYPE.FT_R4:
					value = Convert.ToDecimal((float)src.Val.DoubleVal);
					break;
				case FUNDTYPE.FT_R8:
					value = Convert.ToDecimal(src.Val.DoubleVal);
					break;
				case FUNDTYPE.FT_U8:
					value = Convert.ToDecimal((ulong)src.Val.Int64Val);
					break;
				case FUNDTYPE.FT_I8:
					value = Convert.ToDecimal(src.Val.Int64Val);
					break;
				default:
					return null;
				}
				ConstVal constVal = ConstVal.Get(value);
				return ExprFactory.CreateConstant(predefindType, constVal);
			}
			if (srcType == predefindType)
			{
				decimal value2 = default(decimal);
				FUNDTYPE fundamentalType = destType.FundamentalType;
				ConstVal constVal;
				try
				{
					if (fundamentalType != FUNDTYPE.FT_R4 && fundamentalType != FUNDTYPE.FT_R8)
					{
						value2 = decimal.Truncate(src.Val.DecimalVal);
					}
					switch (fundamentalType)
					{
					case FUNDTYPE.FT_I1:
						constVal = ConstVal.Get(Convert.ToSByte(value2));
						break;
					case FUNDTYPE.FT_U1:
						constVal = ConstVal.Get((uint)Convert.ToByte(value2));
						break;
					case FUNDTYPE.FT_I2:
						constVal = ConstVal.Get(Convert.ToInt16(value2));
						break;
					case FUNDTYPE.FT_U2:
						constVal = ConstVal.Get((uint)Convert.ToUInt16(value2));
						break;
					case FUNDTYPE.FT_I4:
						constVal = ConstVal.Get(Convert.ToInt32(value2));
						break;
					case FUNDTYPE.FT_U4:
						constVal = ConstVal.Get(Convert.ToUInt32(value2));
						break;
					case FUNDTYPE.FT_I8:
						constVal = ConstVal.Get(Convert.ToInt64(value2));
						break;
					case FUNDTYPE.FT_U8:
						constVal = ConstVal.Get(Convert.ToUInt64(value2));
						break;
					case FUNDTYPE.FT_R4:
						constVal = ConstVal.Get(Convert.ToSingle(src.Val.DecimalVal));
						break;
					case FUNDTYPE.FT_R8:
						constVal = ConstVal.Get(Convert.ToDouble(src.Val.DecimalVal));
						break;
					default:
						return null;
					}
				}
				catch (OverflowException)
				{
					return null;
				}
				return ExprFactory.CreateConstant(destType, constVal);
			}
			return null;
		}

		private bool CanExplicitConversionBeBoundInUncheckedContext(Expr exprSrc, CType typeSrc, CType typeDest, CONVERTTYPE flags)
		{
			return new ExpressionBinder(new BindingContext(Context)).BindExplicitConversion(exprSrc, typeSrc, typeDest, flags);
		}

		public ExpressionBinder(BindingContext context)
		{
			Context = context;
		}

		private static AggregateType GetPredefindType(PredefinedType pt)
		{
			return SymbolLoader.GetPredefindType(pt);
		}

		private Expr GenerateAssignmentConversion(Expr op1, Expr op2, bool allowExplicit)
		{
			if (!allowExplicit)
			{
				return mustConvertCore(op2, op1.Type);
			}
			return mustCastCore(op2, op1.Type, (CONVERTTYPE)0);
		}

		public Expr BindAssignment(Expr op1, Expr op2, bool allowExplicit)
		{
			CheckLvalue(op1, CheckLvalueKind.Assignment);
			op2 = GenerateAssignmentConversion(op1, op2, allowExplicit);
			return GenerateOptimizedAssignment(op1, op2);
		}

		internal Expr BindArrayIndexCore(Expr pOp1, Expr pOp2)
		{
			CType pIntType = GetPredefindType(PredefinedType.PT_INT);
			CType elementType = (pOp1.Type as ArrayType).ElementType;
			CheckUnsafe(elementType);
			CType pDestType = ChooseArrayIndexType(pOp2);
			ExpressionBinder binder = this;
			Expr index = pOp2.Map(delegate(Expr x)
			{
				Expr expr = binder.mustConvert(x, pDestType);
				return (pDestType != pIntType) ? ExprFactory.CreateCast(EXPRFLAG.EXF_LITERALCONST, pDestType, expr) : expr;
			});
			return ExprFactory.CreateArrayIndex(elementType, pOp1, index);
		}

		private void bindSimpleCast(Expr exprSrc, CType typeDest, out Expr pexprDest)
		{
			bindSimpleCast(exprSrc, typeDest, out pexprDest, (EXPRFLAG)0);
		}

		private void bindSimpleCast(Expr exprSrc, CType typeDest, out Expr pexprDest, EXPRFLAG exprFlags)
		{
			Expr expr = exprSrc.GetConst();
			ExprCast exprCast = ExprFactory.CreateCast(exprFlags, typeDest, exprSrc);
			if (Context.Checked)
			{
				exprCast.Flags |= EXPRFLAG.EXF_CHECKOVERFLOW;
			}
			if (expr is ExprConstant exprConstant && exprFlags == (EXPRFLAG)0 && exprSrc.Type.FundamentalType == typeDest.FundamentalType && (!exprSrc.Type.IsPredefType(PredefinedType.PT_STRING) || exprConstant.Val.IsNullRef))
			{
				ExprConstant exprConstant2 = ExprFactory.CreateConstant(typeDest, exprConstant.Val);
				pexprDest = exprConstant2;
			}
			else
			{
				pexprDest = exprCast;
			}
		}

		private ExprCall BindToMethod(MethWithInst mwi, Expr pArguments, ExprMemberGroup pMemGroup, MemLookFlags flags)
		{
			Expr optionalObject = pMemGroup.OptionalObject;
			CType callingObjectType = optionalObject?.Type;
			PostBindMethod(mwi);
			optionalObject = AdjustMemberObject(mwi, optionalObject);
			pMemGroup.OptionalObject = optionalObject;
			CType type = (((flags & (MemLookFlags.Ctor | MemLookFlags.NewObj)) != (MemLookFlags.Ctor | MemLookFlags.NewObj)) ? TypeManager.SubstType(mwi.Meth().RetType, mwi.GetType(), mwi.TypeArgs) : mwi.Ats);
			ExprCall exprCall = ExprFactory.CreateCall((EXPRFLAG)0, type, pArguments, pMemGroup, mwi);
			if ((flags & MemLookFlags.Ctor) != MemLookFlags.None && (flags & MemLookFlags.NewObj) != MemLookFlags.None)
			{
				exprCall.Flags |= EXPRFLAG.EXF_LITERALCONST | EXPRFLAG.EXF_CANTBENULL;
			}
			verifyMethodArgs(exprCall, callingObjectType);
			return exprCall;
		}

		internal Expr BindToField(Expr pOptionalObject, FieldWithType fwt, BindingFlag bindFlags)
		{
			CType cType = TypeManager.SubstType(fwt.Field().GetType(), fwt.GetType());
			pOptionalObject = AdjustMemberObject(fwt, pOptionalObject);
			CheckUnsafe(cType);
			AggregateType aggregateType = null;
			if (fwt.Field().isEvent && fwt.Field().getEvent() != null && fwt.Field().getEvent().IsWindowsRuntimeEvent)
			{
				aggregateType = fwt.Field().GetType() as AggregateType;
				if (aggregateType != null)
				{
					cType = TypeManager.GetParameterModifier(cType, isOut: false);
				}
			}
			ExprField exprField = ExprFactory.CreateField(cType, pOptionalObject, fwt);
			exprField.Flags |= (EXPRFLAG)(bindFlags & BindingFlag.BIND_MEMBERSET);
			if (aggregateType != null)
			{
				Name predefinedName = NameManager.GetPredefinedName(PredefinedName.PN_GETORCREATEEVENTREGISTRATIONTOKENTABLE);
				SymbolTable.PopulateSymbolTableWithName(predefinedName.Text, null, aggregateType.AssociatedSystemType);
				MethPropWithInst methPropWithInst = new MethPropWithInst(SymbolLoader.LookupAggMember(predefinedName, aggregateType.OwningAggregate, symbmask_t.MASK_MethodSymbol) as MethodSymbol, aggregateType);
				ExprMemberGroup pMemGroup = ExprFactory.CreateMemGroup(null, methPropWithInst);
				Expr expr = BindToMethod(new MethWithInst(methPropWithInst), exprField, pMemGroup, MemLookFlags.None);
				AggregateSymbol owningAggregate = aggregateType.OwningAggregate;
				Name predefinedName2 = NameManager.GetPredefinedName(PredefinedName.PN_INVOCATIONLIST);
				SymbolTable.PopulateSymbolTableWithName(predefinedName2.Text, null, aggregateType.AssociatedSystemType);
				PropertySymbol obj = SymbolLoader.LookupAggMember(predefinedName2, owningAggregate, symbmask_t.MASK_PropertySymbol) as PropertySymbol;
				MethPropWithInst method = new MethPropWithInst(obj, aggregateType);
				ExprMemberGroup pMemGroup2 = ExprFactory.CreateMemGroup(expr, method);
				PropWithType pwt = new PropWithType(obj, aggregateType);
				return BindToProperty(expr, pwt, bindFlags, null, pMemGroup2);
			}
			return exprField;
		}

		internal ExprProperty BindToProperty(Expr pObject, PropWithType pwt, BindingFlag bindFlags, Expr args, ExprMemberGroup pMemGroup)
		{
			Expr expr = pObject;
			PostBindProperty(pwt, out var pmwtGet, out var pmwtSet);
			pObject = (((bool)pmwtGet && (!pmwtSet || pmwtSet.GetType() == pmwtGet.GetType() || SymbolLoader.HasBaseConversion(pmwtGet.GetType(), pmwtSet.GetType()))) ? AdjustMemberObject(pmwtGet, pObject) : ((!pmwtSet) ? AdjustMemberObject(pwt, pObject) : AdjustMemberObject(pmwtSet, pObject)));
			pMemGroup.OptionalObject = pObject;
			CType type = TypeManager.SubstType(pwt.Prop().RetType, pwt.GetType());
			if ((bindFlags & BindingFlag.BIND_RVALUEREQUIRED) != 0)
			{
				if (!pmwtGet)
				{
					throw ErrorHandling.Error(ErrorCode.ERR_PropertyLacksGet, pwt);
				}
				CType cType = null;
				if (expr != null)
				{
					cType = expr.Type;
				}
				switch (CSemanticChecker.CheckAccess2(pmwtGet.Meth(), pmwtGet.GetType(), ContextForMemberLookup, cType))
				{
				case ACCESSERROR.ACCESSERROR_NOACCESSTHRU:
					throw ErrorHandling.Error(ErrorCode.ERR_BadProtectedAccess, pwt, cType, ContextForMemberLookup);
				default:
					throw ErrorHandling.Error(ErrorCode.ERR_InaccessibleGetter, pwt);
				case ACCESSERROR.ACCESSERROR_NOERROR:
					break;
				}
			}
			ExprProperty exprProperty = ExprFactory.CreateProperty(type, expr, args, pMemGroup, pwt, pmwtSet);
			if (exprProperty.OptionalArguments != null)
			{
				verifyMethodArgs(exprProperty, expr?.Type);
			}
			return exprProperty;
		}

		internal Expr bindUDUnop(ExpressionKind ek, Expr arg)
		{
			Name name = ExpressionKindName(ek);
			CType cType = arg.Type;
			while (true)
			{
				switch (cType.TypeKind)
				{
				case TypeKind.TK_NullableType:
					break;
				case TypeKind.TK_AggregateType:
				{
					if ((!cType.IsClassType && !cType.IsStructType) || ((AggregateType)cType).OwningAggregate.IsSkipUDOps())
					{
						return null;
					}
					ArgInfos argInfos = new ArgInfos();
					argInfos.carg = 1;
					FillInArgInfoFromArgList(argInfos, arg);
					List<CandidateFunctionMember> list = new List<CandidateFunctionMember>();
					MethodSymbol methodSymbol = null;
					AggregateType aggregateType = (AggregateType)cType;
					while (true)
					{
						methodSymbol = ((methodSymbol == null) ? SymbolLoader.LookupAggMember(name, aggregateType.OwningAggregate, symbmask_t.MASK_MethodSymbol) : methodSymbol.LookupNext(symbmask_t.MASK_MethodSymbol)) as MethodSymbol;
						if (methodSymbol == null)
						{
							if (!list.IsEmpty())
							{
								break;
							}
							aggregateType = aggregateType.BaseClass;
							if (aggregateType == null)
							{
								break;
							}
						}
						else if (methodSymbol.isOperator && methodSymbol.Params.Count == 1)
						{
							TypeArray typeArray = TypeManager.SubstTypeArray(methodSymbol.Params, aggregateType);
							CType cType2 = typeArray[0];
							NullableType nullable;
							if (canConvert(arg, cType2))
							{
								list.Add(new CandidateFunctionMember(new MethPropWithInst(methodSymbol, aggregateType, TypeArray.Empty), typeArray, 0, fExpanded: false));
							}
							else if (cType2.IsNonNullableValueType && TypeManager.SubstType(methodSymbol.RetType, aggregateType).IsNonNullableValueType && canConvert(arg, nullable = TypeManager.GetNullable(cType2)))
							{
								list.Add(new CandidateFunctionMember(new MethPropWithInst(methodSymbol, aggregateType, TypeArray.Empty), TypeArray.Allocate(nullable), 1, fExpanded: false));
							}
						}
					}
					if (list.IsEmpty())
					{
						return null;
					}
					CandidateFunctionMember methAmbig;
					CandidateFunctionMember methAmbig2;
					CandidateFunctionMember candidateFunctionMember = FindBestMethod(list, null, argInfos, out methAmbig, out methAmbig2);
					if (candidateFunctionMember == null)
					{
						throw ErrorHandling.Error(ErrorCode.ERR_AmbigCall, methAmbig.mpwi, methAmbig2.mpwi);
					}
					ExprCall exprCall = ((candidateFunctionMember.ctypeLift == 0) ? BindUDUnopCall(arg, candidateFunctionMember.@params[0], candidateFunctionMember.mpwi) : BindLiftedUDUnop(arg, candidateFunctionMember.@params[0], candidateFunctionMember.mpwi));
					return ExprFactory.CreateUserDefinedUnaryOperator(ek, exprCall.Type, arg, exprCall, candidateFunctionMember.mpwi);
				}
				default:
					return null;
				}
				cType = cType.StripNubs();
			}
		}

		private ExprCall BindLiftedUDUnop(Expr arg, CType typeArg, MethPropWithInst mpwi)
		{
			CType cType = typeArg.StripNubs();
			if (!(arg.Type is NullableType) || !canConvert(arg.Type.StripNubs(), cType, CONVERTTYPE.NOUDC))
			{
				arg = mustConvert(arg, typeArg);
			}
			CType cType2 = TypeManager.SubstType(mpwi.Meth().RetType, mpwi.GetType());
			if (!(cType2 is NullableType))
			{
				cType2 = TypeManager.GetNullable(cType2);
			}
			Expr arg2 = mustCast(arg, cType);
			ExprCall expr = BindUDUnopCall(arg2, cType, mpwi);
			ExprMemberGroup memberGroup = ExprFactory.CreateMemGroup(null, mpwi);
			ExprCall exprCall = ExprFactory.CreateCall((EXPRFLAG)0, cType2, arg, memberGroup, null);
			exprCall.MethWithInst = new MethWithInst(mpwi);
			exprCall.CastOfNonLiftedResultToLiftedType = mustCast(expr, cType2, (CONVERTTYPE)0);
			exprCall.NullableCallLiftKind = NullableCallLiftKind.Operator;
			return exprCall;
		}

		private ExprCall BindUDUnopCall(Expr arg, CType typeArg, MethPropWithInst mpwi)
		{
			CType type = TypeManager.SubstType(mpwi.Meth().RetType, mpwi.GetType());
			CheckUnsafe(type);
			ExprMemberGroup memberGroup = ExprFactory.CreateMemGroup(null, mpwi);
			ExprCall exprCall = ExprFactory.CreateCall((EXPRFLAG)0, type, mustConvert(arg, typeArg), memberGroup, null);
			exprCall.MethWithInst = new MethWithInst(mpwi);
			verifyMethodArgs(exprCall, mpwi.GetType());
			return exprCall;
		}

		private GroupToArgsBinderResult BindMethodGroupToArgumentsCore(BindingFlag bindFlags, ExprMemberGroup grp, Expr args, int carg, NamedArgumentsKind namedArgumentsKind)
		{
			ArgInfos argInfos = new ArgInfos
			{
				carg = carg
			};
			FillInArgInfoFromArgList(argInfos, args);
			ArgInfos argInfos2 = new ArgInfos
			{
				carg = carg
			};
			FillInArgInfoFromArgList(argInfos2, args);
			GroupToArgsBinder groupToArgsBinder = new GroupToArgsBinder(this, bindFlags, grp, argInfos, argInfos2, namedArgumentsKind);
			groupToArgsBinder.Bind();
			return groupToArgsBinder.GetResultsOfBind();
		}

		internal ExprWithArgs BindMethodGroupToArguments(BindingFlag bindFlags, ExprMemberGroup grp, Expr args)
		{
			int carg = CountArguments(args);
			NamedArgumentsKind namedArgumentsKind = FindNamedArgumentsType(args);
			MethPropWithInst bestResult = BindMethodGroupToArgumentsCore(bindFlags, grp, args, carg, namedArgumentsKind).BestResult;
			if (grp.SymKind == SYMKIND.SK_PropertySymbol)
			{
				return BindToProperty(grp.OptionalObject, new PropWithType(bestResult), bindFlags, args, grp);
			}
			return BindToMethod(new MethWithInst(bestResult), args, grp, (MemLookFlags)grp.Flags);
		}

		private static NamedArgumentsKind FindNamedArgumentsType(Expr args)
		{
			Expr expr = args;
			while (expr != null)
			{
				Expr expr2;
				if (expr is ExprList exprList)
				{
					expr2 = exprList.OptionalElement;
					expr = exprList.OptionalNextListNode;
				}
				else
				{
					expr2 = expr;
					expr = null;
				}
				if (!(expr2 is ExprNamedArgumentSpecification))
				{
					continue;
				}
				while (expr != null)
				{
					if (expr is ExprList exprList2)
					{
						expr2 = exprList2.OptionalElement;
						expr = exprList2.OptionalNextListNode;
					}
					else
					{
						expr2 = expr;
						expr = null;
					}
					if (!(expr2 is ExprNamedArgumentSpecification))
					{
						return NamedArgumentsKind.NonTrailing;
					}
				}
				return NamedArgumentsKind.Positioning;
			}
			return NamedArgumentsKind.None;
		}

		private static RuntimeBinderException BadOperatorTypesError(Expr pOperand1, Expr pOperand2)
		{
			string errorString = pOperand1.ErrorString;
			if (pOperand2 != null)
			{
				return ErrorHandling.Error(ErrorCode.ERR_BadBinaryOps, errorString, pOperand1.Type, pOperand2.Type);
			}
			return ErrorHandling.Error(ErrorCode.ERR_BadUnaryOp, errorString, pOperand1.Type);
		}

		private static ErrorCode GetStandardLvalueError(CheckLvalueKind kind)
		{
			if (kind != CheckLvalueKind.Increment)
			{
				return ErrorCode.ERR_AssgLvalueExpected;
			}
			return ErrorCode.ERR_IncrementLvalueExpected;
		}

		private void CheckLvalueProp(ExprProperty prop)
		{
			CType type = null;
			if (prop.OptionalObjectThrough != null)
			{
				type = prop.OptionalObjectThrough.Type;
			}
			CheckPropertyAccess(prop.MethWithTypeSet, prop.PropWithTypeSlot, type);
		}

		private void CheckPropertyAccess(MethWithType mwt, PropWithType pwtSlot, CType type)
		{
			switch (CSemanticChecker.CheckAccess2(mwt.Meth(), mwt.GetType(), ContextForMemberLookup, type))
			{
			case ACCESSERROR.ACCESSERROR_NOACCESSTHRU:
				throw ErrorHandling.Error(ErrorCode.ERR_BadProtectedAccess, pwtSlot, type, ContextForMemberLookup);
			case ACCESSERROR.ACCESSERROR_NOACCESS:
				throw ErrorHandling.Error(mwt.Meth().isSetAccessor() ? ErrorCode.ERR_InaccessibleSetter : ErrorCode.ERR_InaccessibleGetter, pwtSlot);
			}
		}

		private void CheckLvalue(Expr expr, CheckLvalueKind kind)
		{
			if (expr.isLvalue())
			{
				if (expr is ExprProperty prop)
				{
					CheckLvalueProp(prop);
				}
				return;
			}
			switch (expr.Kind)
			{
			case ExpressionKind.Property:
			{
				ExprProperty exprProperty = (ExprProperty)expr;
				throw ErrorHandling.Error(ErrorCode.ERR_AssgReadonlyProp, exprProperty.PropWithTypeSlot);
			}
			case ExpressionKind.Field:
				throw ErrorHandling.Error(((ExprField)expr).FieldWithType.Field().isStatic ? ErrorCode.ERR_AssgReadonlyStatic : ErrorCode.ERR_AssgReadonly);
			default:
				throw ErrorHandling.Error(GetStandardLvalueError(kind));
			}
		}

		private static void PostBindMethod(MethWithInst pMWI)
		{
			MethodSymbol methodSymbol = pMWI.Meth();
			if (methodSymbol.RetType != null)
			{
				CheckUnsafe(methodSymbol.RetType);
				CType[] items = methodSymbol.Params.Items;
				for (int i = 0; i < items.Length; i++)
				{
					CheckUnsafe(items[i]);
				}
			}
		}

		private static void PostBindProperty(PropWithType pwt, out MethWithType pmwtGet, out MethWithType pmwtSet)
		{
			PropertySymbol propertySymbol = pwt.Prop();
			pmwtGet = ((propertySymbol.GetterMethod != null) ? new MethWithType(propertySymbol.GetterMethod, pwt.GetType()) : new MethWithType());
			pmwtSet = ((propertySymbol.SetterMethod != null) ? new MethWithType(propertySymbol.SetterMethod, pwt.GetType()) : new MethWithType());
			if (propertySymbol.RetType != null)
			{
				CheckUnsafe(propertySymbol.RetType);
			}
		}

		private Expr AdjustMemberObject(SymWithType swt, Expr pObject)
		{
			bool num = IsMatchingStatic(swt, pObject);
			bool isStatic = swt.Sym.isStatic;
			if (!num)
			{
				if (isStatic)
				{
					if ((pObject.Flags & EXPRFLAG.EXF_UNREALIZEDGOTO) != 0)
					{
						return null;
					}
					throw ErrorHandling.Error(ErrorCode.ERR_ObjectProhibited, swt);
				}
				throw ErrorHandling.Error(ErrorCode.ERR_ObjectRequired, swt);
			}
			if (isStatic)
			{
				return null;
			}
			if (swt.Sym is MethodSymbol && swt.Meth().IsConstructor())
			{
				return pObject;
			}
			if (pObject == null)
			{
				return null;
			}
			CType cType = pObject.Type;
			CType ats;
			if (cType is NullableType nullableType && (ats = nullableType.GetAts()) != swt.GetType())
			{
				cType = ats;
			}
			if (cType is TypeParameterType || cType is AggregateType)
			{
				_ = swt.Sym.parent;
				pObject = tryConvert(pObject, swt.GetType(), CONVERTTYPE.NOUDC);
			}
			return pObject;
		}

		private static bool IsMatchingStatic(SymWithType swt, Expr pObject)
		{
			if (swt.Sym is MethodSymbol methodSymbol && methodSymbol.IsConstructor())
			{
				return !methodSymbol.isStatic;
			}
			if (swt.Sym.isStatic)
			{
				if (pObject == null)
				{
					return true;
				}
				if ((pObject.Flags & EXPRFLAG.EXF_SAMENAMETYPE) == 0)
				{
					return false;
				}
			}
			else if (pObject == null)
			{
				return false;
			}
			return true;
		}

		[Conditional("DEBUG")]
		private static void AssertObjectIsLvalue(Expr pObject)
		{
		}

		private void verifyMethodArgs(ExprWithArgs call, CType callingObjectType)
		{
			Expr optionalArguments = call.OptionalArguments;
			SymWithType symWithType = call.GetSymWithType();
			MethodOrPropertySymbol mp = symWithType.Sym as MethodOrPropertySymbol;
			TypeArray pTypeArgs = (call as ExprCall)?.MethWithInst.TypeArgs;
			AdjustCallArgumentsForParams(callingObjectType, symWithType.GetType(), mp, pTypeArgs, optionalArguments, out var newArgs);
			call.OptionalArguments = newArgs;
		}

		private void AdjustCallArgumentsForParams(CType callingObjectType, CType type, MethodOrPropertySymbol mp, TypeArray pTypeArgs, Expr argsPtr, out Expr newArgs)
		{
			newArgs = null;
			Expr last = null;
			MethodOrPropertySymbol methodOrPropertySymbol = GroupToArgsBinder.FindMostDerivedMethod(mp, callingObjectType);
			int num = mp.Params.Count;
			TypeArray typeArray = mp.Params;
			int num2 = 0;
			int num3 = ExpressionIterator.Count(argsPtr);
			bool flag = false;
			ExpressionIterator expressionIterator = new ExpressionIterator(argsPtr);
			if (argsPtr == null)
			{
				if (!mp.isParamArray)
				{
					return;
				}
			}
			else
			{
				while (true)
				{
					if (expressionIterator.AtEnd())
					{
						return;
					}
					Expr expr = expressionIterator.Current();
					if (expr.Type is ParameterModifierType)
					{
						if (num != 0)
						{
							num--;
						}
						ExprFactory.AppendItemToList(expr, ref newArgs, ref last);
					}
					else if (num != 0)
					{
						if (num == 1 && mp.isParamArray && num3 > mp.Params.Count)
						{
							break;
						}
						Expr expr2 = expr;
						Expr expr3;
						if (expr2 is ExprNamedArgumentSpecification exprNamedArgumentSpecification)
						{
							int num4 = 0;
							using (List<Name>.Enumerator enumerator = methodOrPropertySymbol.ParameterNames.GetEnumerator())
							{
								while (enumerator.MoveNext() && enumerator.Current != exprNamedArgumentSpecification.Name)
								{
									num4++;
								}
							}
							CType dest = TypeManager.SubstType(typeArray[num4], type, pTypeArgs);
							if (!canConvert(exprNamedArgumentSpecification.Value, dest) && mp.isParamArray && num4 == mp.Params.Count - 1)
							{
								ExprArrayInit exprArrayInit = ExprFactory.CreateArrayInit((ArrayType)TypeManager.SubstType(mp.Params[mp.Params.Count - 1], type, pTypeArgs), null, null, new int[1], 1);
								exprArrayInit.GeneratedForParamArray = true;
								exprArrayInit.OptionalArguments = exprNamedArgumentSpecification.Value;
								exprNamedArgumentSpecification.Value = exprArrayInit;
								flag = true;
							}
							else
							{
								exprNamedArgumentSpecification.Value = tryConvert(exprNamedArgumentSpecification.Value, dest);
							}
							expr3 = expr2;
						}
						else
						{
							CType dest2 = TypeManager.SubstType(typeArray[num2], type, pTypeArgs);
							expr3 = tryConvert(expr, dest2);
						}
						if (expr3 == null)
						{
							if (mp.isParamArray && num == 1 && num3 >= mp.Params.Count)
							{
								break;
							}
							return;
						}
						expr = expr3;
						ExprFactory.AppendItemToList(expr3, ref newArgs, ref last);
						num--;
					}
					num2++;
					if (num != 0 && mp.isParamArray && num2 == num3)
					{
						expr = null;
						expressionIterator.MoveNext();
						break;
					}
					expressionIterator.MoveNext();
				}
			}
			if (flag)
			{
				return;
			}
			CType cType = TypeManager.SubstType(mp.Params[mp.Params.Count - 1], type, pTypeArgs);
			if (!(cType is ArrayType { IsSZArray: not false, ElementType: var elementType }))
			{
				return;
			}
			ExprArrayInit exprArrayInit2 = ExprFactory.CreateArrayInit(cType, null, null, new int[1], 1);
			exprArrayInit2.GeneratedForParamArray = true;
			if (expressionIterator.AtEnd())
			{
				exprArrayInit2.DimensionSize = 0;
				exprArrayInit2.DimensionSizes[0] = 0;
				exprArrayInit2.OptionalArguments = null;
				argsPtr = ((argsPtr != null) ? ((Expr)ExprFactory.CreateList(argsPtr, exprArrayInit2)) : ((Expr)exprArrayInit2));
				ExprFactory.AppendItemToList(exprArrayInit2, ref newArgs, ref last);
				return;
			}
			Expr first = null;
			Expr last2 = null;
			int num5 = 0;
			while (!expressionIterator.AtEnd())
			{
				Expr expr4 = expressionIterator.Current();
				num5++;
				if (expr4 is ExprNamedArgumentSpecification exprNamedArgumentSpecification2)
				{
					exprNamedArgumentSpecification2.Value = tryConvert(exprNamedArgumentSpecification2.Value, elementType);
				}
				else
				{
					expr4 = tryConvert(expr4, elementType);
				}
				ExprFactory.AppendItemToList(expr4, ref first, ref last2);
				expressionIterator.MoveNext();
			}
			exprArrayInit2.DimensionSize = num5;
			exprArrayInit2.DimensionSizes[0] = num5;
			exprArrayInit2.OptionalArguments = first;
			ExprFactory.AppendItemToList(exprArrayInit2, ref newArgs, ref last);
		}

		internal CType ChooseArrayIndexType(Expr args)
		{
			PredefinedType[] array = s_rgptIntOp;
			for (int i = 0; i < array.Length; i++)
			{
				CType predefindType = GetPredefindType(array[i]);
				using IEnumerator<Expr> enumerator = args.ToEnumerable().GetEnumerator();
				Expr current;
				do
				{
					if (enumerator.MoveNext())
					{
						current = enumerator.Current;
						continue;
					}
					return predefindType;
				}
				while (canConvert(current, predefindType));
			}
			return GetPredefindType(PredefinedType.PT_INT);
		}

		internal static void FillInArgInfoFromArgList(ArgInfos argInfo, Expr args)
		{
			CType[] array = new CType[argInfo.carg];
			argInfo.prgexpr = new List<Expr>();
			int num = 0;
			Expr expr = args;
			while (expr != null)
			{
				Expr expr2;
				if (expr is ExprList exprList)
				{
					expr2 = exprList.OptionalElement;
					expr = exprList.OptionalNextListNode;
				}
				else
				{
					expr2 = expr;
					expr = null;
				}
				array[num] = expr2.Type;
				argInfo.prgexpr.Add(expr2);
				num++;
			}
			argInfo.types = TypeArray.Allocate(array);
		}

		private static bool TryGetExpandedParams(TypeArray @params, int count, out TypeArray ppExpandedParams)
		{
			CType[] array;
			if (count < @params.Count - 1)
			{
				array = new CType[@params.Count - 1];
				@params.CopyItems(0, @params.Count - 1, array);
				ppExpandedParams = TypeArray.Allocate(array);
				return true;
			}
			array = new CType[count];
			@params.CopyItems(0, @params.Count - 1, array);
			if (!(@params[@params.Count - 1] is ArrayType { ElementType: var elementType }))
			{
				ppExpandedParams = null;
				return false;
			}
			for (int i = @params.Count - 1; i < count; i++)
			{
				array[i] = elementType;
			}
			ppExpandedParams = TypeArray.Allocate(array);
			return true;
		}

		public static bool IsMethPropCallable(MethodOrPropertySymbol sym, bool requireUC)
		{
			if (!sym.isOverride || sym.isHideByName)
			{
				if (requireUC)
				{
					return sym.isUserCallable();
				}
				return true;
			}
			return false;
		}

		private static bool IsConvInTable(List<UdConvInfo> convTable, MethodSymbol meth, AggregateType ats, bool fSrc, bool fDst)
		{
			foreach (UdConvInfo item in convTable)
			{
				if (item.Meth.Meth() == meth && item.Meth.GetType() == ats && item.SrcImplicit == fSrc && item.DstImplicit == fDst)
				{
					return true;
				}
			}
			return false;
		}

		private static bool isConstantInRange(ExprConstant exprSrc, CType typeDest)
		{
			return isConstantInRange(exprSrc, typeDest, realsOk: false);
		}

		private static bool isConstantInRange(ExprConstant exprSrc, CType typeDest, bool realsOk)
		{
			FUNDTYPE fundamentalType = exprSrc.Type.FundamentalType;
			FUNDTYPE fundamentalType2 = typeDest.FundamentalType;
			if (fundamentalType > FUNDTYPE.FT_U8 || fundamentalType2 > FUNDTYPE.FT_U8)
			{
				if (!realsOk)
				{
					return false;
				}
				if (fundamentalType > FUNDTYPE.FT_R8 || fundamentalType2 > FUNDTYPE.FT_R8)
				{
					return false;
				}
			}
			if (fundamentalType2 > FUNDTYPE.FT_U8)
			{
				return true;
			}
			if (fundamentalType > FUNDTYPE.FT_U8)
			{
				double doubleVal = exprSrc.Val.DoubleVal;
				switch (fundamentalType2)
				{
				case FUNDTYPE.FT_I1:
					if (doubleVal > -129.0 && doubleVal < 128.0)
					{
						return true;
					}
					break;
				case FUNDTYPE.FT_I2:
					if (doubleVal > -32769.0 && doubleVal < 32768.0)
					{
						return true;
					}
					break;
				case FUNDTYPE.FT_I4:
					if (doubleVal > (double)I64(-2147483649L) && doubleVal < (double)I64(2147483648L))
					{
						return true;
					}
					break;
				case FUNDTYPE.FT_I8:
					if (doubleVal >= -9.223372036854776E+18 && doubleVal < 9.223372036854776E+18)
					{
						return true;
					}
					break;
				case FUNDTYPE.FT_U1:
					if (doubleVal > -1.0 && doubleVal < 256.0)
					{
						return true;
					}
					break;
				case FUNDTYPE.FT_U2:
					if (doubleVal > -1.0 && doubleVal < 65536.0)
					{
						return true;
					}
					break;
				case FUNDTYPE.FT_U4:
					if (doubleVal > -1.0 && doubleVal < (double)I64(4294967296L))
					{
						return true;
					}
					break;
				case FUNDTYPE.FT_U8:
					if (doubleVal > -1.0 && doubleVal < 1.8446744073709552E+19)
					{
						return true;
					}
					break;
				}
				return false;
			}
			if (fundamentalType == FUNDTYPE.FT_U8)
			{
				ulong uInt64Value = exprSrc.UInt64Value;
				switch (fundamentalType2)
				{
				case FUNDTYPE.FT_I1:
					if (uInt64Value <= 127)
					{
						return true;
					}
					break;
				case FUNDTYPE.FT_I2:
					if (uInt64Value <= 32767)
					{
						return true;
					}
					break;
				case FUNDTYPE.FT_I4:
					if (uInt64Value <= 2147483647)
					{
						return true;
					}
					break;
				case FUNDTYPE.FT_I8:
					if (uInt64Value <= 9223372036854775807L)
					{
						return true;
					}
					break;
				case FUNDTYPE.FT_U1:
					if (uInt64Value <= 255)
					{
						return true;
					}
					break;
				case FUNDTYPE.FT_U2:
					if (uInt64Value <= 65535)
					{
						return true;
					}
					break;
				case FUNDTYPE.FT_U4:
					if (uInt64Value <= 4294967295u)
					{
						return true;
					}
					break;
				case FUNDTYPE.FT_U8:
					return true;
				}
			}
			else
			{
				long int64Value = exprSrc.Int64Value;
				switch (fundamentalType2)
				{
				case FUNDTYPE.FT_I1:
					if (int64Value >= -128 && int64Value <= 127)
					{
						return true;
					}
					break;
				case FUNDTYPE.FT_I2:
					if (int64Value >= -32768 && int64Value <= 32767)
					{
						return true;
					}
					break;
				case FUNDTYPE.FT_I4:
					if (int64Value >= I64(-2147483648L) && int64Value <= I64(2147483647L))
					{
						return true;
					}
					break;
				case FUNDTYPE.FT_I8:
					return true;
				case FUNDTYPE.FT_U1:
					if (int64Value >= 0 && int64Value <= 255)
					{
						return true;
					}
					break;
				case FUNDTYPE.FT_U2:
					if (int64Value >= 0 && int64Value <= 65535)
					{
						return true;
					}
					break;
				case FUNDTYPE.FT_U4:
					if (int64Value >= 0 && int64Value <= I64(4294967295L))
					{
						return true;
					}
					break;
				case FUNDTYPE.FT_U8:
					if (int64Value >= 0)
					{
						return true;
					}
					break;
				}
			}
			return false;
		}

		private static Name ExpressionKindName(ExpressionKind ek)
		{
			return NameManager.GetPredefinedName(s_EK2NAME[(int)(ek - 29)]);
		}

		private static void CheckUnsafe(CType type)
		{
			if (type == null || type.IsUnsafe())
			{
				throw ErrorHandling.Error(ErrorCode.ERR_UnsafeNeeded);
			}
		}

		private static ExprWrap WrapShortLivedExpression(Expr expr)
		{
			return ExprFactory.CreateWrap(expr);
		}

		private static ExprAssignment GenerateOptimizedAssignment(Expr op1, Expr op2)
		{
			return ExprFactory.CreateAssignment(op1, op2);
		}

		internal static int CountArguments(Expr args)
		{
			int num = 0;
			Expr expr = args;
			while (expr != null)
			{
				if (expr is ExprList exprList)
				{
					_ = exprList.OptionalElement;
					expr = exprList.OptionalNextListNode;
				}
				else
				{
					expr = null;
				}
				num++;
			}
			return num;
		}

		private static bool IsNullableConstructor(Expr expr, out ExprCall call)
		{
			if (expr is ExprCall exprCall && exprCall.MemberGroup.OptionalObject == null)
			{
				MethWithInst methWithInst = exprCall.MethWithInst;
				if ((object)methWithInst != null && methWithInst.Meth().IsNullableConstructor())
				{
					call = exprCall;
					return true;
				}
			}
			call = null;
			return false;
		}

		private static Expr StripNullableConstructor(Expr pExpr)
		{
			ExprCall call;
			while (IsNullableConstructor(pExpr, out call))
			{
				pExpr = call.OptionalArguments;
			}
			return pExpr;
		}

		private static Expr BindNubValue(Expr exprSrc)
		{
			if (IsNullableConstructor(exprSrc, out var call))
			{
				return call.OptionalArguments;
			}
			NullableType obj = (NullableType)exprSrc.Type;
			CType underlyingType = obj.UnderlyingType;
			AggregateType ats = obj.GetAts();
			PropertySymbol property = PredefinedMembers.GetProperty(PREDEFPROP.PP_G_OPTIONAL_VALUE);
			PropWithType property2 = new PropWithType(property, ats);
			MethPropWithInst method = new MethPropWithInst(property, ats);
			ExprMemberGroup memberGroup = ExprFactory.CreateMemGroup(exprSrc, method);
			return ExprFactory.CreateProperty(underlyingType, null, null, memberGroup, property2, null);
		}

		private static ExprCall BindNubNew(Expr exprSrc)
		{
			NullableType nullable = TypeManager.GetNullable(exprSrc.Type);
			AggregateType ats = nullable.GetAts();
			MethWithInst method = new MethWithInst(PredefinedMembers.GetMethod(PREDEFMETH.PM_G_OPTIONAL_CTOR), ats, TypeArray.Empty);
			ExprMemberGroup memberGroup = ExprFactory.CreateMemGroup(null, method);
			return ExprFactory.CreateCall(EXPRFLAG.EXF_LITERALCONST | EXPRFLAG.EXF_CANTBENULL, nullable, exprSrc, memberGroup, method);
		}

		private ExprBinOp BindUserDefinedBinOp(ExpressionKind ek, BinOpArgInfo info)
		{
			if (info.pt1 <= PredefinedType.PT_ULONG && info.pt2 <= PredefinedType.PT_ULONG)
			{
				return null;
			}
			MethPropWithInst ppmpwi;
			Expr expr;
			if (info.binopKind == BinOpKind.Logical)
			{
				ExprCall exprCall = BindUDBinop(ek - 55 + 49, info.arg1, info.arg2, fDontLift: true, out ppmpwi);
				if (exprCall == null)
				{
					return null;
				}
				expr = BindUserBoolOp(ek, exprCall);
			}
			else
			{
				expr = BindUDBinop(ek, info.arg1, info.arg2, fDontLift: false, out ppmpwi);
			}
			if (expr == null)
			{
				return null;
			}
			return ExprFactory.CreateUserDefinedBinop(ek, expr.Type, info.arg1, info.arg2, expr, ppmpwi);
		}

		private bool GetSpecialBinopSignatures(List<BinOpFullSig> prgbofs, BinOpArgInfo info)
		{
			if (info.pt1 <= PredefinedType.PT_ULONG && info.pt2 <= PredefinedType.PT_ULONG)
			{
				return false;
			}
			if (!GetDelBinOpSigs(prgbofs, info) && !GetEnumBinOpSigs(prgbofs, info))
			{
				return GetRefEqualSigs(prgbofs, info);
			}
			return true;
		}

		private bool GetStandardAndLiftedBinopSignatures(List<BinOpFullSig> rgbofs, BinOpArgInfo info)
		{
			int num = 0;
			for (int i = 0; i < s_binopSignatures.Length; i++)
			{
				BinOpSig binOpSig = s_binopSignatures[i];
				if ((binOpSig.mask & info.mask) == 0)
				{
					continue;
				}
				CType cType = GetPredefindType(binOpSig.pt1);
				CType cType2 = GetPredefindType(binOpSig.pt2);
				if (cType == null || cType2 == null)
				{
					continue;
				}
				ConvKind convKind = GetConvKind(info.pt1, binOpSig.pt1);
				ConvKind convKind2 = GetConvKind(info.pt2, binOpSig.pt2);
				LiftFlags liftFlags = LiftFlags.None;
				switch (convKind)
				{
				case ConvKind.Explicit:
					if (!(info.arg1 is ExprConstant expr))
					{
						continue;
					}
					if (!canConvert(expr, cType))
					{
						if (i < num || !binOpSig.CanLift())
						{
							continue;
						}
						cType = TypeManager.GetNullable(cType);
						if (!canConvert(expr, cType))
						{
							continue;
						}
						ConvKind convKind3 = GetConvKind(info.ptRaw1, binOpSig.pt1);
						liftFlags = (((uint)(convKind3 - 1) <= 1u) ? (liftFlags | LiftFlags.Lift1) : (liftFlags | LiftFlags.Convert1));
					}
					break;
				case ConvKind.Unknown:
					if (!canConvert(info.arg1, cType))
					{
						if (i < num || !binOpSig.CanLift())
						{
							continue;
						}
						cType = TypeManager.GetNullable(cType);
						if (!canConvert(info.arg1, cType))
						{
							continue;
						}
						ConvKind convKind3 = GetConvKind(info.ptRaw1, binOpSig.pt1);
						liftFlags = (((uint)(convKind3 - 1) <= 1u) ? (liftFlags | LiftFlags.Lift1) : (liftFlags | LiftFlags.Convert1));
					}
					break;
				case ConvKind.Identity:
					if (convKind2 == ConvKind.Identity)
					{
						BinOpFullSig binOpFullSig = new BinOpFullSig(this, binOpSig);
						if (binOpFullSig.Type1() != null && binOpFullSig.Type2() != null)
						{
							rgbofs.Add(binOpFullSig);
							return true;
						}
					}
					break;
				case ConvKind.Implicit:
					break;
				default:
					continue;
				}
				switch (convKind2)
				{
				case ConvKind.Explicit:
					if (!(info.arg2 is ExprConstant expr2))
					{
						continue;
					}
					if (!canConvert(expr2, cType2))
					{
						if (i < num || !binOpSig.CanLift())
						{
							continue;
						}
						cType2 = TypeManager.GetNullable(cType2);
						if (!canConvert(expr2, cType2))
						{
							continue;
						}
						ConvKind convKind3 = GetConvKind(info.ptRaw2, binOpSig.pt2);
						liftFlags = (((uint)(convKind3 - 1) <= 1u) ? (liftFlags | LiftFlags.Lift2) : (liftFlags | LiftFlags.Convert2));
					}
					break;
				case ConvKind.Unknown:
					if (!canConvert(info.arg2, cType2))
					{
						if (i < num || !binOpSig.CanLift())
						{
							continue;
						}
						cType2 = TypeManager.GetNullable(cType2);
						if (!canConvert(info.arg2, cType2))
						{
							continue;
						}
						ConvKind convKind3 = GetConvKind(info.ptRaw2, binOpSig.pt2);
						liftFlags = (((uint)(convKind3 - 1) <= 1u) ? (liftFlags | LiftFlags.Lift2) : (liftFlags | LiftFlags.Convert2));
					}
					break;
				case ConvKind.Identity:
				case ConvKind.Implicit:
					break;
				default:
					continue;
				}
				if (liftFlags != LiftFlags.None)
				{
					rgbofs.Add(new BinOpFullSig(cType, cType2, binOpSig.pfn, binOpSig.grfos, liftFlags, binOpSig.fnkind));
					num = i + binOpSig.cbosSkip + 1;
				}
				else
				{
					rgbofs.Add(new BinOpFullSig(this, binOpSig));
					i += binOpSig.cbosSkip;
				}
			}
			return false;
		}

		private int FindBestSignatureInList(List<BinOpFullSig> binopSignatures, BinOpArgInfo info)
		{
			if (binopSignatures.Count == 1)
			{
				return 0;
			}
			int num = 0;
			for (int i = 1; i < binopSignatures.Count; i++)
			{
				if (num < 0)
				{
					num = i;
					continue;
				}
				int num2 = WhichBofsIsBetter(binopSignatures[num], binopSignatures[i], info.type1, info.type2);
				if (num2 == 0)
				{
					num = -1;
				}
				else if (num2 > 0)
				{
					num = i;
				}
			}
			if (num == -1)
			{
				return -1;
			}
			for (int i = 0; i < binopSignatures.Count; i++)
			{
				if (i != num && WhichBofsIsBetter(binopSignatures[num], binopSignatures[i], info.type1, info.type2) >= 0)
				{
					return -1;
				}
			}
			return num;
		}

		private static ExprBinOp BindNullEqualityComparison(ExpressionKind ek, BinOpArgInfo info)
		{
			Expr arg = info.arg1;
			Expr expr = info.arg2;
			if (info.binopKind == BinOpKind.Equal)
			{
				CType predefindType = GetPredefindType(PredefinedType.PT_BOOL);
				ExprBinOp exprBinOp = null;
				if (info.type1 is NullableType && info.type2 is NullType)
				{
					expr = ExprFactory.CreateZeroInit(info.type1);
					exprBinOp = ExprFactory.CreateBinop(ek, predefindType, arg, expr);
				}
				if (info.type1 is NullType && info.type2 is NullableType)
				{
					arg = ExprFactory.CreateZeroInit(info.type2);
					exprBinOp = ExprFactory.CreateBinop(ek, predefindType, arg, expr);
				}
				if (exprBinOp != null)
				{
					exprBinOp.IsLifted = true;
					return exprBinOp;
				}
			}
			throw BadOperatorTypesError(info.arg1, info.arg2);
		}

		public Expr BindStandardBinop(ExpressionKind ek, Expr arg1, Expr arg2)
		{
			(BinOpKind, EXPRFLAG) binopKindAndFlags = GetBinopKindAndFlags(ek);
			BinOpKind item = binopKindAndFlags.Item1;
			EXPRFLAG item2 = binopKindAndFlags.Item2;
			BinOpArgInfo binOpArgInfo = new BinOpArgInfo(arg1, arg2)
			{
				binopKind = item
			};
			binOpArgInfo.mask = (BinOpMask)(1 << (int)binOpArgInfo.binopKind);
			List<BinOpFullSig> list = new List<BinOpFullSig>();
			ExprBinOp exprBinOp = BindUserDefinedBinOp(ek, binOpArgInfo);
			if (exprBinOp != null)
			{
				return exprBinOp;
			}
			bool flag = GetSpecialBinopSignatures(list, binOpArgInfo);
			if (!flag)
			{
				flag = GetStandardAndLiftedBinopSignatures(list, binOpArgInfo);
			}
			int num;
			if (flag)
			{
				num = list.Count - 1;
			}
			else
			{
				if (list.Count == 0)
				{
					return BindNullEqualityComparison(ek, binOpArgInfo);
				}
				num = FindBestSignatureInList(list, binOpArgInfo);
				if (num < 0)
				{
					throw AmbiguousOperatorError(arg1, arg2);
				}
			}
			return BindStandardBinopCore(binOpArgInfo, list[num], ek, item2);
		}

		private Expr BindStandardBinopCore(BinOpArgInfo info, BinOpFullSig bofs, ExpressionKind ek, EXPRFLAG flags)
		{
			if (bofs.pfn == null)
			{
				throw BadOperatorTypesError(info.arg1, info.arg2);
			}
			if (!bofs.isLifted() || !bofs.AutoLift())
			{
				Expr expr = info.arg1;
				Expr expr2 = info.arg2;
				if (bofs.ConvertOperandsBeforeBinding())
				{
					expr = mustConvert(expr, bofs.Type1());
					expr2 = mustConvert(expr2, bofs.Type2());
				}
				if (bofs.fnkind == BinOpFuncKind.BoolBitwiseOp)
				{
					return BindBoolBitwiseOp(ek, flags, expr, expr2);
				}
				return bofs.pfn(this, ek, flags, expr, expr2);
			}
			if (IsEnumArithmeticBinOp(ek, info))
			{
				Expr expr3 = info.arg1;
				Expr expr4 = info.arg2;
				if (bofs.ConvertOperandsBeforeBinding())
				{
					expr3 = mustConvert(expr3, bofs.Type1());
					expr4 = mustConvert(expr4, bofs.Type2());
				}
				return BindLiftedEnumArithmeticBinOp(ek, flags, expr3, expr4);
			}
			return BindLiftedStandardBinOp(info, bofs, ek, flags);
		}

		private ExprBinOp BindLiftedStandardBinOp(BinOpArgInfo info, BinOpFullSig bofs, ExpressionKind ek, EXPRFLAG flags)
		{
			Expr arg = info.arg1;
			Expr arg2 = info.arg2;
			Expr expr = null;
			LiftArgument(arg, bofs.Type1(), bofs.ConvertFirst(), out var ppLiftedArgument, out var ppNonLiftedArgument);
			LiftArgument(arg2, bofs.Type2(), bofs.ConvertSecond(), out var ppLiftedArgument2, out var ppNonLiftedArgument2);
			if (!ppNonLiftedArgument.isNull() && !ppNonLiftedArgument2.isNull())
			{
				expr = bofs.pfn(this, ek, flags, ppNonLiftedArgument, ppNonLiftedArgument2);
			}
			CType cType;
			if (info.binopKind == BinOpKind.Compare || info.binopKind == BinOpKind.Equal)
			{
				cType = GetPredefindType(PredefinedType.PT_BOOL);
			}
			else
			{
				cType = ((bofs.fnkind == BinOpFuncKind.EnumBinOp) ? GetEnumBinOpType(ek, ppNonLiftedArgument.Type, ppNonLiftedArgument2.Type, out var _) : ppLiftedArgument.Type);
				if (!(cType is NullableType))
				{
					cType = TypeManager.GetNullable(cType);
				}
			}
			ExprBinOp exprBinOp = ExprFactory.CreateBinop(ek, cType, ppLiftedArgument, ppLiftedArgument2);
			mustCast(expr, cType, (CONVERTTYPE)0);
			exprBinOp.IsLifted = true;
			exprBinOp.Flags |= flags;
			return exprBinOp;
		}

		private void LiftArgument(Expr pArgument, CType pParameterType, bool bConvertBeforeLift, out Expr ppLiftedArgument, out Expr ppNonLiftedArgument)
		{
			Expr expr = mustConvert(pArgument, pParameterType);
			if (expr != pArgument)
			{
				MarkAsIntermediateConversion(expr);
			}
			Expr expr2 = pArgument;
			if (pParameterType is NullableType nullableType)
			{
				if (expr2.isNull())
				{
					expr2 = mustCast(expr2, pParameterType);
				}
				expr2 = mustCast(expr2, nullableType.UnderlyingType);
				if (bConvertBeforeLift)
				{
					MarkAsIntermediateConversion(expr2);
				}
			}
			else
			{
				expr2 = expr;
			}
			ppLiftedArgument = expr;
			ppNonLiftedArgument = expr2;
		}

		private bool GetDelBinOpSigs(List<BinOpFullSig> prgbofs, BinOpArgInfo info)
		{
			if (!info.ValidForDelegate() || (!info.type1.IsDelegateType && !info.type2.IsDelegateType))
			{
				return false;
			}
			if (info.type1 == info.type2)
			{
				prgbofs.Add(new BinOpFullSig(info.type1, info.type2, BindDelBinOp, OpSigFlags.Convert, LiftFlags.None, BinOpFuncKind.DelBinOp));
				return true;
			}
			bool num = info.type2.IsDelegateType && canConvert(info.arg1, info.type2);
			bool flag = info.type1.IsDelegateType && canConvert(info.arg2, info.type1);
			if (num)
			{
				prgbofs.Add(new BinOpFullSig(info.type2, info.type2, BindDelBinOp, OpSigFlags.Convert, LiftFlags.None, BinOpFuncKind.DelBinOp));
			}
			if (flag)
			{
				prgbofs.Add(new BinOpFullSig(info.type1, info.type1, BindDelBinOp, OpSigFlags.Convert, LiftFlags.None, BinOpFuncKind.DelBinOp));
			}
			return false;
		}

		private bool CanConvertArg1(BinOpArgInfo info, CType typeDst, out LiftFlags pgrflt, out CType ptypeSig1, out CType ptypeSig2)
		{
			ptypeSig1 = null;
			ptypeSig2 = null;
			if (canConvert(info.arg1, typeDst))
			{
				pgrflt = LiftFlags.None;
			}
			else
			{
				pgrflt = LiftFlags.None;
				typeDst = TypeManager.GetNullable(typeDst);
				if (!canConvert(info.arg1, typeDst))
				{
					return false;
				}
				pgrflt = LiftFlags.Convert1;
			}
			ptypeSig1 = typeDst;
			if (info.type2 is NullableType)
			{
				pgrflt |= LiftFlags.Lift2;
				ptypeSig2 = TypeManager.GetNullable(info.typeRaw2);
			}
			else
			{
				ptypeSig2 = info.typeRaw2;
			}
			return true;
		}

		private bool CanConvertArg2(BinOpArgInfo info, CType typeDst, out LiftFlags pgrflt, out CType ptypeSig1, out CType ptypeSig2)
		{
			ptypeSig1 = null;
			ptypeSig2 = null;
			if (canConvert(info.arg2, typeDst))
			{
				pgrflt = LiftFlags.None;
			}
			else
			{
				pgrflt = LiftFlags.None;
				typeDst = TypeManager.GetNullable(typeDst);
				if (!canConvert(info.arg2, typeDst))
				{
					return false;
				}
				pgrflt = LiftFlags.Convert2;
			}
			ptypeSig2 = typeDst;
			if (info.type1 is NullableType)
			{
				pgrflt |= LiftFlags.Lift1;
				ptypeSig1 = TypeManager.GetNullable(info.typeRaw1);
			}
			else
			{
				ptypeSig1 = info.typeRaw1;
			}
			return true;
		}

		private static void RecordBinOpSigFromArgs(List<BinOpFullSig> prgbofs, BinOpArgInfo info)
		{
			LiftFlags liftFlags = LiftFlags.None;
			CType type;
			if (info.type1 != info.typeRaw1)
			{
				liftFlags |= LiftFlags.Lift1;
				type = TypeManager.GetNullable(info.typeRaw1);
			}
			else
			{
				type = info.typeRaw1;
			}
			CType type2;
			if (info.type2 != info.typeRaw2)
			{
				liftFlags |= LiftFlags.Lift2;
				type2 = TypeManager.GetNullable(info.typeRaw2);
			}
			else
			{
				type2 = info.typeRaw2;
			}
			prgbofs.Add(new BinOpFullSig(type, type2, BindEnumBinOp, OpSigFlags.Value, liftFlags, BinOpFuncKind.EnumBinOp));
		}

		private bool GetEnumBinOpSigs(List<BinOpFullSig> prgbofs, BinOpArgInfo info)
		{
			if (!info.typeRaw1.IsEnumType && !info.typeRaw2.IsEnumType)
			{
				return false;
			}
			CType ptypeSig = null;
			CType ptypeSig2 = null;
			LiftFlags pgrflt = LiftFlags.None;
			if (info.typeRaw1 == info.typeRaw2)
			{
				if (!info.ValidForEnum())
				{
					return false;
				}
				RecordBinOpSigFromArgs(prgbofs, info);
				return true;
			}
			bool num;
			if (!info.typeRaw1.IsEnumType)
			{
				if (info.typeRaw1 == info.typeRaw2.UnderlyingEnumType)
				{
					num = info.ValidForUnderlyingTypeAndEnum();
					goto IL_008a;
				}
			}
			else if (info.typeRaw2 == info.typeRaw1.UnderlyingEnumType)
			{
				num = info.ValidForEnumAndUnderlyingType();
				goto IL_008a;
			}
			goto IL_0097;
			IL_008a:
			if (num)
			{
				RecordBinOpSigFromArgs(prgbofs, info);
				return true;
			}
			goto IL_0097;
			IL_0097:
			if ((!info.typeRaw1.IsEnumType) ? ((info.ValidForEnum() && CanConvertArg1(info, info.typeRaw2, out pgrflt, out ptypeSig, out ptypeSig2)) || (info.ValidForEnumAndUnderlyingType() && CanConvertArg1(info, info.typeRaw2.UnderlyingEnumType, out pgrflt, out ptypeSig, out ptypeSig2))) : ((info.ValidForEnum() && CanConvertArg2(info, info.typeRaw1, out pgrflt, out ptypeSig, out ptypeSig2)) || (info.ValidForEnumAndUnderlyingType() && CanConvertArg2(info, info.typeRaw1.UnderlyingEnumType, out pgrflt, out ptypeSig, out ptypeSig2))))
			{
				prgbofs.Add(new BinOpFullSig(ptypeSig, ptypeSig2, BindEnumBinOp, OpSigFlags.Value, pgrflt, BinOpFuncKind.EnumBinOp));
			}
			return false;
		}

		private static bool IsEnumArithmeticBinOp(ExpressionKind ek, BinOpArgInfo info)
		{
			return ek switch
			{
				ExpressionKind.Add => info.typeRaw1.IsEnumType ^ info.typeRaw2.IsEnumType, 
				ExpressionKind.Subtract => info.typeRaw1.IsEnumType | info.typeRaw2.IsEnumType, 
				_ => false, 
			};
		}

		private bool GetRefEqualSigs(List<BinOpFullSig> prgbofs, BinOpArgInfo info)
		{
			if (info.mask != BinOpMask.Equal)
			{
				return false;
			}
			if (info.type1 != info.typeRaw1 || info.type2 != info.typeRaw2)
			{
				return false;
			}
			bool result = false;
			CType cType = info.type1;
			CType cType2 = info.type2;
			CType predefindType = GetPredefindType(PredefinedType.PT_OBJECT);
			CType cType3 = null;
			if (cType is NullType && cType2 is NullType)
			{
				cType3 = predefindType;
				result = true;
			}
			else
			{
				CType predefindType2 = GetPredefindType(PredefinedType.PT_DELEGATE);
				if (canConvert(info.arg1, predefindType2) && canConvert(info.arg2, predefindType2) && !cType.IsDelegateType && !cType2.IsDelegateType)
				{
					prgbofs.Add(new BinOpFullSig(predefindType2, predefindType2, BindDelBinOp, OpSigFlags.Convert, LiftFlags.None, BinOpFuncKind.DelBinOp));
				}
				if (cType.FundamentalType != FUNDTYPE.FT_REF)
				{
					return false;
				}
				if (cType2 is NullType)
				{
					result = true;
					cType3 = predefindType;
				}
				else
				{
					if (cType2.FundamentalType != FUNDTYPE.FT_REF)
					{
						return false;
					}
					if (cType is NullType)
					{
						result = true;
						cType3 = predefindType;
					}
					else
					{
						if (!canCast(cType, cType2, CONVERTTYPE.NOUDC) && !canCast(cType2, cType, CONVERTTYPE.NOUDC))
						{
							return false;
						}
						if (cType.IsInterfaceType || cType.IsPredefType(PredefinedType.PT_STRING) || SymbolLoader.HasBaseConversion(cType, predefindType2))
						{
							cType = predefindType;
						}
						else if (cType is ArrayType)
						{
							cType = GetPredefindType(PredefinedType.PT_ARRAY);
						}
						else if (!cType.IsClassType)
						{
							return false;
						}
						if (cType2.IsInterfaceType || cType2.IsPredefType(PredefinedType.PT_STRING) || SymbolLoader.HasBaseConversion(cType2, predefindType2))
						{
							cType2 = predefindType;
						}
						else if (cType2 is ArrayType)
						{
							cType2 = GetPredefindType(PredefinedType.PT_ARRAY);
						}
						else if (!cType2.IsClassType)
						{
							return false;
						}
						if (SymbolLoader.HasBaseConversion(cType2, cType))
						{
							cType3 = cType;
						}
						else if (SymbolLoader.HasBaseConversion(cType, cType2))
						{
							cType3 = cType2;
						}
					}
				}
			}
			prgbofs.Add(new BinOpFullSig(cType3, cType3, BindRefCmpOp, OpSigFlags.None, LiftFlags.None, BinOpFuncKind.RefCmpOp));
			return result;
		}

		private int WhichBofsIsBetter(BinOpFullSig bofs1, BinOpFullSig bofs2, CType type1, CType type2)
		{
			BetterType betterType;
			BetterType betterType2;
			if (bofs1.FPreDef() && bofs2.FPreDef())
			{
				betterType = WhichTypeIsBetter(bofs1.pt1, bofs2.pt1, type1);
				betterType2 = WhichTypeIsBetter(bofs1.pt2, bofs2.pt2, type2);
			}
			else
			{
				betterType = WhichTypeIsBetter(bofs1.Type1(), bofs2.Type1(), type1);
				betterType2 = WhichTypeIsBetter(bofs1.Type2(), bofs2.Type2(), type2);
			}
			int num = betterType switch
			{
				BetterType.Left => -1, 
				BetterType.Right => 1, 
				_ => 0, 
			};
			switch (betterType2)
			{
			case BetterType.Left:
				num--;
				break;
			case BetterType.Right:
				num++;
				break;
			}
			return num;
		}

		private static (ExpressionKind, UnaOpKind, EXPRFLAG) CalculateExprAndUnaryOpKinds(OperatorKind op, bool bChecked)
		{
			EXPRFLAG eXPRFLAG = (EXPRFLAG)0;
			UnaOpKind item;
			ExpressionKind item2;
			switch (op)
			{
			case OperatorKind.OP_UPLUS:
				item = UnaOpKind.Plus;
				item2 = ExpressionKind.UnaryPlus;
				break;
			case OperatorKind.OP_NEG:
				if (bChecked)
				{
					eXPRFLAG = EXPRFLAG.EXF_CHECKOVERFLOW;
				}
				item = UnaOpKind.Minus;
				item2 = ExpressionKind.Negate;
				break;
			case OperatorKind.OP_BITNOT:
				item = UnaOpKind.Tilde;
				item2 = ExpressionKind.BitwiseNot;
				break;
			case OperatorKind.OP_LOGNOT:
				item = UnaOpKind.Bang;
				item2 = ExpressionKind.LogicalNot;
				break;
			case OperatorKind.OP_POSTINC:
				eXPRFLAG = EXPRFLAG.EXF_OPERATOR;
				if (bChecked)
				{
					eXPRFLAG |= EXPRFLAG.EXF_CHECKOVERFLOW;
				}
				item = UnaOpKind.IncDec;
				item2 = ExpressionKind.Add;
				break;
			case OperatorKind.OP_PREINC:
				if (bChecked)
				{
					eXPRFLAG = EXPRFLAG.EXF_CHECKOVERFLOW;
				}
				item = UnaOpKind.IncDec;
				item2 = ExpressionKind.Add;
				break;
			case OperatorKind.OP_POSTDEC:
				eXPRFLAG = EXPRFLAG.EXF_OPERATOR;
				if (bChecked)
				{
					eXPRFLAG |= EXPRFLAG.EXF_CHECKOVERFLOW;
				}
				item = UnaOpKind.IncDec;
				item2 = ExpressionKind.Subtract;
				break;
			case OperatorKind.OP_PREDEC:
				if (bChecked)
				{
					eXPRFLAG = EXPRFLAG.EXF_CHECKOVERFLOW;
				}
				item = UnaOpKind.IncDec;
				item2 = ExpressionKind.Subtract;
				break;
			default:
				throw Error.InternalCompilerError();
			}
			return (item2, item, eXPRFLAG);
		}

		public Expr BindStandardUnaryOperator(OperatorKind op, Expr pArgument)
		{
			CType type = pArgument.Type;
			if (type is NullableType { UnderlyingType: var underlyingType } nullableType && underlyingType.IsEnumType)
			{
				return mustCast(BindStandardUnaryOperator(op, mustCast(pArgument, TypeManager.GetNullable(GetPredefindType(underlyingType.FundamentalType switch
				{
					FUNDTYPE.FT_U4 => PredefinedType.PT_UINT, 
					FUNDTYPE.FT_I8 => PredefinedType.PT_LONG, 
					FUNDTYPE.FT_U8 => PredefinedType.PT_ULONG, 
					_ => PredefinedType.PT_INT, 
				})))), nullableType);
			}
			(ExpressionKind, UnaOpKind, EXPRFLAG) tuple = CalculateExprAndUnaryOpKinds(op, Context.Checked);
			ExpressionKind item = tuple.Item1;
			UnaOpKind item2 = tuple.Item2;
			EXPRFLAG item3 = tuple.Item3;
			UnaOpMask unaryOpMask = (UnaOpMask)(1 << (int)item2);
			List<UnaOpFullSig> list = new List<UnaOpFullSig>();
			Expr ppResult;
			UnaryOperatorSignatureFindResult unaryOperatorSignatureFindResult = PopulateSignatureList(pArgument, item2, unaryOpMask, item, item3, list, out ppResult);
			int num = list.Count - 1;
			switch (unaryOperatorSignatureFindResult)
			{
			case UnaryOperatorSignatureFindResult.Return:
				return ppResult;
			default:
				if (!FindApplicableSignatures(pArgument, unaryOpMask, list))
				{
					if (list.Count == 0)
					{
						throw BadOperatorTypesError(pArgument, null);
					}
					num = 0;
					if (list.Count == 1)
					{
						break;
					}
					for (int i = 1; i < list.Count; i++)
					{
						if (num < 0)
						{
							num = i;
							continue;
						}
						int num2 = WhichUofsIsBetter(list[num], list[i], type);
						if (num2 == 0)
						{
							num = -1;
						}
						else if (num2 > 0)
						{
							num = i;
						}
					}
					if (num < 0)
					{
						throw AmbiguousOperatorError(pArgument, null);
					}
					for (int j = 0; j < list.Count; j++)
					{
						if (j != num && WhichUofsIsBetter(list[num], list[j], type) >= 0)
						{
							throw AmbiguousOperatorError(pArgument, null);
						}
					}
				}
				else
				{
					num = list.Count - 1;
				}
				break;
			case UnaryOperatorSignatureFindResult.Match:
				break;
			}
			UnaOpFullSig unaOpFullSig = list[num];
			if (unaOpFullSig.pfn == null)
			{
				if (item2 == UnaOpKind.IncDec)
				{
					return BindIncOp(item, item3, pArgument, unaOpFullSig);
				}
				throw BadOperatorTypesError(pArgument, null);
			}
			if (unaOpFullSig.isLifted())
			{
				return BindLiftedStandardUnop(item, item3, pArgument, unaOpFullSig);
			}
			if (pArgument is ExprConstant)
			{
				pArgument = ExprFactory.CreateCast(pArgument.Type, pArgument);
			}
			Expr expr = tryConvert(pArgument, unaOpFullSig.GetType());
			if (expr == null)
			{
				expr = mustCast(pArgument, unaOpFullSig.GetType(), CONVERTTYPE.NOUDC);
			}
			return unaOpFullSig.pfn(this, item, item3, expr);
		}

		private UnaryOperatorSignatureFindResult PopulateSignatureList(Expr pArgument, UnaOpKind unaryOpKind, UnaOpMask unaryOpMask, ExpressionKind exprKind, EXPRFLAG flags, List<UnaOpFullSig> pSignatures, out Expr ppResult)
		{
			ppResult = null;
			CType type = pArgument.Type;
			CType cType = type.StripNubs();
			if ((cType.IsPredefined ? cType.PredefinedType : PredefinedType.PT_COUNT) > PredefinedType.PT_ULONG)
			{
				if (cType.IsEnumType)
				{
					if ((unaryOpMask & (UnaOpMask.Tilde | UnaOpMask.IncDec)) != UnaOpMask.None)
					{
						if (unaryOpKind == UnaOpKind.Tilde)
						{
							pSignatures.Add(new UnaOpFullSig(((AggregateType)type).OwningAggregate.GetUnderlyingType(), BindEnumUnaOp, LiftFlags.None, UnaOpFuncKind.EnumUnaOp));
						}
						else
						{
							pSignatures.Add(new UnaOpFullSig(((AggregateType)type).OwningAggregate.GetUnderlyingType(), null, LiftFlags.None, UnaOpFuncKind.None));
						}
						return UnaryOperatorSignatureFindResult.Match;
					}
				}
				else if (unaryOpKind == UnaOpKind.IncDec)
				{
					ExprMultiGet exprMultiGet = ExprFactory.CreateMultiGet((EXPRFLAG)0, type, null);
					Expr expr = bindUDUnop(exprKind - 42 + 33, exprMultiGet);
					if (expr != null)
					{
						if (expr.Type != null && expr.Type != type)
						{
							expr = mustConvert(expr, type);
						}
						ExprMulti exprMulti = (exprMultiGet.OptionalMulti = ExprFactory.CreateMulti(EXPRFLAG.EXF_ASSGOP | flags, type, pArgument, expr));
						CheckLvalue(pArgument, CheckLvalueKind.Increment);
						ppResult = exprMulti;
						return UnaryOperatorSignatureFindResult.Return;
					}
				}
				else
				{
					Expr expr2 = bindUDUnop(exprKind, pArgument);
					if (expr2 != null)
					{
						ppResult = expr2;
						return UnaryOperatorSignatureFindResult.Return;
					}
				}
			}
			return UnaryOperatorSignatureFindResult.Continue;
		}

		private bool FindApplicableSignatures(Expr pArgument, UnaOpMask unaryOpMask, List<UnaOpFullSig> pSignatures)
		{
			long num = 0L;
			CType type = pArgument.Type;
			CType cType = type.StripNubs();
			PredefinedType ptSrc = (type.IsPredefined ? type.PredefinedType : PredefinedType.PT_COUNT);
			PredefinedType ptSrc2 = (cType.IsPredefined ? cType.PredefinedType : PredefinedType.PT_COUNT);
			for (int i = 0; i < s_rguos.Length; i++)
			{
				UnaOpSig unaOpSig = s_rguos[i];
				if ((unaOpSig.grfuom & unaryOpMask) == 0)
				{
					continue;
				}
				ConvKind convKind = GetConvKind(ptSrc, s_rguos[i].pt);
				CType cType2 = null;
				switch (convKind)
				{
				case ConvKind.Explicit:
					if (!(pArgument is ExprConstant))
					{
						continue;
					}
					if (!canConvert(pArgument, cType2 = GetPredefindType(unaOpSig.pt)))
					{
						if (i < num)
						{
							continue;
						}
						cType2 = TypeManager.GetNullable(cType2);
						if (!canConvert(pArgument, cType2))
						{
							continue;
						}
					}
					break;
				case ConvKind.Unknown:
					if (!canConvert(pArgument, cType2 = GetPredefindType(unaOpSig.pt)))
					{
						if (i < num)
						{
							continue;
						}
						cType2 = TypeManager.GetNullable(cType2);
						if (!canConvert(pArgument, cType2))
						{
							continue;
						}
					}
					break;
				case ConvKind.Identity:
				{
					UnaOpFullSig unaOpFullSig = new UnaOpFullSig(this, unaOpSig);
					if (unaOpFullSig.GetType() != null)
					{
						pSignatures.Add(unaOpFullSig);
						return true;
					}
					break;
				}
				case ConvKind.Implicit:
					break;
				default:
					continue;
				}
				if (cType2 is NullableType)
				{
					LiftFlags liftFlags = LiftFlags.None;
					ConvKind convKind2 = GetConvKind(ptSrc2, unaOpSig.pt);
					liftFlags = (((uint)(convKind2 - 1) <= 1u) ? (liftFlags | LiftFlags.Lift1) : (liftFlags | LiftFlags.Convert1));
					pSignatures.Add(new UnaOpFullSig(cType2, unaOpSig.pfn, liftFlags, unaOpSig.fnkind));
					num = i + unaOpSig.cuosSkip + 1;
				}
				else
				{
					UnaOpFullSig unaOpFullSig2 = new UnaOpFullSig(this, unaOpSig);
					if (unaOpFullSig2.GetType() != null)
					{
						pSignatures.Add(unaOpFullSig2);
					}
					i += unaOpSig.cuosSkip;
				}
			}
			return false;
		}

		private ExprOperator BindLiftedStandardUnop(ExpressionKind ek, EXPRFLAG flags, Expr arg, UnaOpFullSig uofs)
		{
			NullableType nullableType = uofs.GetType() as NullableType;
			if (arg.Type is NullType)
			{
				throw BadOperatorTypesError(arg, null);
			}
			LiftArgument(arg, uofs.GetType(), uofs.Convert(), out var ppLiftedArgument, out var ppNonLiftedArgument);
			Expr expr = uofs.pfn(this, ek, flags, ppNonLiftedArgument);
			ExprUnaryOp exprUnaryOp = ExprFactory.CreateUnaryOp(ek, nullableType, ppLiftedArgument);
			mustCast(expr, nullableType, (CONVERTTYPE)0);
			exprUnaryOp.Flags |= flags;
			return exprUnaryOp;
		}

		private int WhichUofsIsBetter(UnaOpFullSig uofs1, UnaOpFullSig uofs2, CType typeArg)
		{
			return ((!uofs1.FPreDef() || !uofs2.FPreDef()) ? WhichTypeIsBetter(uofs1.GetType(), uofs2.GetType(), typeArg) : WhichTypeIsBetter(uofs1.pt, uofs2.pt, typeArg)) switch
			{
				BetterType.Left => -1, 
				BetterType.Right => 1, 
				_ => 0, 
			};
		}

		private static ExprOperator BindIntBinOp(ExpressionBinder binder, ExpressionKind ek, EXPRFLAG flags, Expr arg1, Expr arg2)
		{
			return binder.BindIntOp(ek, flags, arg1, arg2, arg1.Type.PredefinedType);
		}

		private static ExprOperator BindIntUnaOp(ExpressionBinder binder, ExpressionKind ek, EXPRFLAG flags, Expr arg)
		{
			return binder.BindIntOp(ek, flags, arg, null, arg.Type.PredefinedType);
		}

		private static ExprOperator BindRealBinOp(ExpressionBinder binder, ExpressionKind ek, EXPRFLAG _, Expr arg1, Expr arg2)
		{
			return BindFloatOp(ek, arg1, arg2);
		}

		private static ExprOperator BindRealUnaOp(ExpressionBinder binder, ExpressionKind ek, EXPRFLAG _, Expr arg)
		{
			return BindFloatOp(ek, arg, null);
		}

		private Expr BindIncOp(ExpressionKind ek, EXPRFLAG flags, Expr arg, UnaOpFullSig uofs)
		{
			CheckLvalue(arg, CheckLvalueKind.Increment);
			FUNDTYPE fundamentalType = uofs.GetType().StripNubs().FundamentalType;
			if (fundamentalType == FUNDTYPE.FT_R8 || fundamentalType == FUNDTYPE.FT_R4)
			{
				flags &= ~EXPRFLAG.EXF_CHECKOVERFLOW;
			}
			if (uofs.isLifted())
			{
				return BindLiftedIncOp(ek, flags, arg, uofs);
			}
			return BindNonliftedIncOp(ek, flags, arg, uofs);
		}

		private Expr BindIncOpCore(ExpressionKind ek, EXPRFLAG flags, Expr exprVal, CType type)
		{
			if (type.IsEnumType && type.FundamentalType > FUNDTYPE.FT_U8)
			{
				type = GetPredefindType(PredefinedType.PT_INT);
			}
			ConstVal cv;
			switch (type.FundamentalType)
			{
			default:
			{
				PREDEFMETH predefMeth;
				if (ek == ExpressionKind.Add)
				{
					ek = ExpressionKind.DecimalInc;
					predefMeth = PREDEFMETH.PM_DECIMAL_OPINCREMENT;
				}
				else
				{
					ek = ExpressionKind.DecimalDec;
					predefMeth = PREDEFMETH.PM_DECIMAL_OPDECREMENT;
				}
				return CreateUnaryOpForPredefMethodCall(ek, predefMeth, type, exprVal);
			}
			case FUNDTYPE.FT_I1:
			case FUNDTYPE.FT_I2:
			case FUNDTYPE.FT_U1:
			case FUNDTYPE.FT_U2:
				type = GetPredefindType(PredefinedType.PT_INT);
				cv = ConstVal.Get(1);
				break;
			case FUNDTYPE.FT_I4:
			case FUNDTYPE.FT_U4:
				cv = ConstVal.Get(1);
				break;
			case FUNDTYPE.FT_I8:
			case FUNDTYPE.FT_U8:
				cv = ConstVal.Get(1L);
				break;
			case FUNDTYPE.FT_R4:
			case FUNDTYPE.FT_R8:
				cv = ConstVal.Get(1.0);
				break;
			}
			return LScalar(ek, flags, exprVal, type, cv, type);
		}

		private Expr LScalar(ExpressionKind ek, EXPRFLAG flags, Expr exprVal, CType type, ConstVal cv, CType typeTmp)
		{
			CType cType = type;
			if (cType.IsEnumType)
			{
				cType = cType.UnderlyingEnumType;
			}
			ExprBinOp exprBinOp = ExprFactory.CreateBinop(ek, typeTmp, exprVal, ExprFactory.CreateConstant(cType, cv));
			exprBinOp.Flags |= flags;
			if (typeTmp == type)
			{
				return exprBinOp;
			}
			return mustCast(exprBinOp, type, CONVERTTYPE.NOUDC);
		}

		private ExprMulti BindNonliftedIncOp(ExpressionKind ek, EXPRFLAG flags, Expr arg, UnaOpFullSig uofs)
		{
			Expr expr2;
			Expr expr = (expr2 = ExprFactory.CreateMultiGet(EXPRFLAG.EXF_ASSGOP, arg.Type, null));
			CType type = uofs.GetType();
			expr2 = mustCast(expr2, type);
			expr2 = BindIncOpCore(ek, flags, expr2, type);
			return ((ExprMultiGet)expr).OptionalMulti = ExprFactory.CreateMulti(op: mustCast(expr2, arg.Type, CONVERTTYPE.NOUDC), flags: EXPRFLAG.EXF_ASSGOP | flags, type: arg.Type, left: arg);
		}

		private ExprMulti BindLiftedIncOp(ExpressionKind ek, EXPRFLAG flags, Expr arg, UnaOpFullSig uofs)
		{
			NullableType nullableType = uofs.GetType() as NullableType;
			Expr expr2;
			Expr expr = (expr2 = ExprFactory.CreateMultiGet(EXPRFLAG.EXF_ASSGOP, arg.Type, null));
			Expr expr3 = expr2;
			expr3 = mustCast(expr3, nullableType.UnderlyingType);
			Expr expr4 = BindIncOpCore(ek, flags, expr3, nullableType.UnderlyingType);
			ExprUnaryOp exprUnaryOp = ExprFactory.CreateUnaryOp(operand: mustCast(expr2, nullableType), exprKind: (ek == ExpressionKind.Add) ? ExpressionKind.Inc : ExpressionKind.Dec, type: arg.Type);
			mustCast(mustCast(expr4, nullableType), arg.Type);
			exprUnaryOp.Flags |= flags;
			return ((ExprMultiGet)expr).OptionalMulti = ExprFactory.CreateMulti(EXPRFLAG.EXF_ASSGOP | flags, arg.Type, arg, exprUnaryOp);
		}

		private static ExprBinOp BindDecBinOp(ExpressionBinder _, ExpressionKind ek, EXPRFLAG flags, Expr arg1, Expr arg2)
		{
			CType predefindType = GetPredefindType(PredefinedType.PT_DECIMAL);
			CType type;
			switch (ek)
			{
			default:
				type = null;
				break;
			case ExpressionKind.Add:
			case ExpressionKind.Subtract:
			case ExpressionKind.Multiply:
			case ExpressionKind.Divide:
			case ExpressionKind.Modulo:
				type = predefindType;
				break;
			case ExpressionKind.Eq:
			case ExpressionKind.NotEq:
			case ExpressionKind.LessThan:
			case ExpressionKind.LessThanOrEqual:
			case ExpressionKind.GreaterThan:
			case ExpressionKind.GreaterThanOrEqual:
				type = GetPredefindType(PredefinedType.PT_BOOL);
				break;
			}
			return ExprFactory.CreateBinop(ek, type, arg1, arg2);
		}

		private static ExprUnaryOp BindDecUnaOp(ExpressionBinder _, ExpressionKind ek, EXPRFLAG flags, Expr arg)
		{
			CType predefindType = GetPredefindType(PredefinedType.PT_DECIMAL);
			if (ek == ExpressionKind.Negate)
			{
				PREDEFMETH predefMeth = PREDEFMETH.PM_DECIMAL_OPUNARYMINUS;
				return CreateUnaryOpForPredefMethodCall(ExpressionKind.DecimalNegate, predefMeth, predefindType, arg);
			}
			return ExprFactory.CreateUnaryOp(ExpressionKind.UnaryPlus, predefindType, arg);
		}

		private static Expr BindStrBinOp(ExpressionBinder _, ExpressionKind ek, EXPRFLAG flags, Expr arg1, Expr arg2)
		{
			return BindStringConcat(arg1, arg2);
		}

		private static ExprBinOp BindShiftOp(ExpressionBinder _, ExpressionKind ek, EXPRFLAG flags, Expr arg1, Expr arg2)
		{
			PredefinedType predefinedType = arg1.Type.PredefinedType;
			return ExprFactory.CreateBinop(ek, arg1.Type, arg1, arg2);
		}

		private static ExprBinOp BindBoolBinOp(ExpressionBinder _, ExpressionKind ek, EXPRFLAG flags, Expr arg1, Expr arg2)
		{
			return ExprFactory.CreateBinop(ek, GetPredefindType(PredefinedType.PT_BOOL), arg1, arg2);
		}

		private ExprOperator BindBoolBitwiseOp(ExpressionKind ek, EXPRFLAG flags, Expr expr1, Expr expr2)
		{
			if (expr1.Type is NullableType || expr2.Type is NullableType)
			{
				CType nullable = TypeManager.GetNullable(GetPredefindType(PredefinedType.PT_BOOL));
				Expr expr3 = StripNullableConstructor(expr1);
				Expr expr4 = StripNullableConstructor(expr2);
				Expr expr5 = null;
				if (!(expr3.Type is NullableType) && !(expr4.Type is NullableType))
				{
					expr5 = BindBoolBinOp(this, ek, flags, expr3, expr4);
				}
				ExprBinOp exprBinOp = ExprFactory.CreateBinop(ek, nullable, expr1, expr2);
				if (expr5 != null)
				{
					mustCast(expr5, nullable, (CONVERTTYPE)0);
				}
				exprBinOp.IsLifted = true;
				exprBinOp.Flags |= flags;
				return exprBinOp;
			}
			return BindBoolBinOp(this, ek, flags, expr1, expr2);
		}

		private static Expr BindLiftedBoolBitwiseOp(ExpressionBinder _, ExpressionKind ek, EXPRFLAG flags, Expr expr1, Expr expr2)
		{
			return null;
		}

		private static Expr BindBoolUnaOp(ExpressionBinder _, ExpressionKind ek, EXPRFLAG flags, Expr arg)
		{
			CType predefindType = GetPredefindType(PredefinedType.PT_BOOL);
			Expr expr = arg.GetConst();
			if (expr == null)
			{
				return ExprFactory.CreateUnaryOp(ExpressionKind.LogicalNot, predefindType, arg);
			}
			return ExprFactory.CreateConstant(predefindType, ConstVal.Get(((ExprConstant)expr).Val.Int32Val == 0));
		}

		private static ExprBinOp BindStrCmpOp(ExpressionBinder _, ExpressionKind ek, EXPRFLAG flags, Expr arg1, Expr arg2)
		{
			PREDEFMETH predefMeth = ((ek == ExpressionKind.Eq) ? PREDEFMETH.PM_STRING_OPEQUALITY : PREDEFMETH.PM_STRING_OPINEQUALITY);
			ek = ((ek == ExpressionKind.Eq) ? ExpressionKind.StringEq : ExpressionKind.StringNotEq);
			return CreateBinopForPredefMethodCall(ek, predefMeth, GetPredefindType(PredefinedType.PT_BOOL), arg1, arg2);
		}

		private static ExprBinOp BindRefCmpOp(ExpressionBinder binder, ExpressionKind ek, EXPRFLAG flags, Expr arg1, Expr arg2)
		{
			arg1 = binder.mustConvert(arg1, GetPredefindType(PredefinedType.PT_OBJECT), CONVERTTYPE.NOUDC);
			arg2 = binder.mustConvert(arg2, GetPredefindType(PredefinedType.PT_OBJECT), CONVERTTYPE.NOUDC);
			return ExprFactory.CreateBinop(ek, GetPredefindType(PredefinedType.PT_BOOL), arg1, arg2);
		}

		private static Expr BindDelBinOp(ExpressionBinder _, ExpressionKind ek, EXPRFLAG flags, Expr arg1, Expr arg2)
		{
			PREDEFMETH predefMeth = PREDEFMETH.PM_DECIMAL_OPDECREMENT;
			CType retType = null;
			switch (ek)
			{
			case ExpressionKind.Add:
				predefMeth = PREDEFMETH.PM_DELEGATE_COMBINE;
				retType = arg1.Type;
				ek = ExpressionKind.DelegateAdd;
				break;
			case ExpressionKind.Subtract:
				predefMeth = PREDEFMETH.PM_DELEGATE_REMOVE;
				retType = arg1.Type;
				ek = ExpressionKind.DelegateSubtract;
				break;
			case ExpressionKind.Eq:
				predefMeth = PREDEFMETH.PM_DELEGATE_OPEQUALITY;
				retType = GetPredefindType(PredefinedType.PT_BOOL);
				ek = ExpressionKind.DelegateEq;
				break;
			case ExpressionKind.NotEq:
				predefMeth = PREDEFMETH.PM_DELEGATE_OPINEQUALITY;
				retType = GetPredefindType(PredefinedType.PT_BOOL);
				ek = ExpressionKind.DelegateNotEq;
				break;
			}
			return CreateBinopForPredefMethodCall(ek, predefMeth, retType, arg1, arg2);
		}

		private static Expr BindEnumBinOp(ExpressionBinder binder, ExpressionKind ek, EXPRFLAG flags, Expr arg1, Expr arg2)
		{
			AggregateType ppEnumType;
			AggregateType enumBinOpType = GetEnumBinOpType(ek, arg1.Type, arg2.Type, out ppEnumType);
			PredefinedType predefinedType = ppEnumType.FundamentalType switch
			{
				FUNDTYPE.FT_U4 => PredefinedType.PT_UINT, 
				FUNDTYPE.FT_I8 => PredefinedType.PT_LONG, 
				FUNDTYPE.FT_U8 => PredefinedType.PT_ULONG, 
				_ => PredefinedType.PT_INT, 
			};
			CType predefindType = GetPredefindType(predefinedType);
			arg1 = binder.mustCast(arg1, predefindType, CONVERTTYPE.NOUDC);
			arg2 = binder.mustCast(arg2, predefindType, CONVERTTYPE.NOUDC);
			Expr expr = binder.BindIntOp(ek, flags, arg1, arg2, predefinedType);
			if (expr.Type != enumBinOpType)
			{
				expr = binder.mustCast(expr, enumBinOpType, CONVERTTYPE.NOUDC);
			}
			return expr;
		}

		private Expr BindLiftedEnumArithmeticBinOp(ExpressionKind ek, EXPRFLAG flags, Expr arg1, Expr arg2)
		{
			CType cType = ((arg1.Type is NullableType nullableType) ? nullableType.UnderlyingType : arg1.Type);
			CType cType2 = ((arg2.Type is NullableType nullableType2) ? nullableType2.UnderlyingType : arg2.Type);
			if (cType is NullType)
			{
				cType = cType2.UnderlyingEnumType;
			}
			else if (cType2 is NullType)
			{
				cType2 = cType.UnderlyingEnumType;
			}
			AggregateType ppEnumType;
			NullableType nullable = TypeManager.GetNullable(GetEnumBinOpType(ek, cType, cType2, out ppEnumType));
			NullableType nullable2 = TypeManager.GetNullable(GetPredefindType(ppEnumType.FundamentalType switch
			{
				FUNDTYPE.FT_U4 => PredefinedType.PT_UINT, 
				FUNDTYPE.FT_I8 => PredefinedType.PT_LONG, 
				FUNDTYPE.FT_U8 => PredefinedType.PT_ULONG, 
				_ => PredefinedType.PT_INT, 
			}));
			arg1 = mustCast(arg1, nullable2, CONVERTTYPE.NOUDC);
			arg2 = mustCast(arg2, nullable2, CONVERTTYPE.NOUDC);
			ExprBinOp exprBinOp = ExprFactory.CreateBinop(ek, nullable2, arg1, arg2);
			exprBinOp.IsLifted = true;
			exprBinOp.Flags |= flags;
			if (exprBinOp.Type != nullable)
			{
				return mustCast(exprBinOp, nullable, CONVERTTYPE.NOUDC);
			}
			return exprBinOp;
		}

		private static Expr BindEnumUnaOp(ExpressionBinder binder, ExpressionKind ek, EXPRFLAG flags, Expr arg)
		{
			CType type = ((ExprCast)arg).Argument.Type;
			PredefinedType predefinedType = type.FundamentalType switch
			{
				FUNDTYPE.FT_U4 => PredefinedType.PT_UINT, 
				FUNDTYPE.FT_I8 => PredefinedType.PT_LONG, 
				FUNDTYPE.FT_U8 => PredefinedType.PT_ULONG, 
				_ => PredefinedType.PT_INT, 
			};
			CType predefindType = GetPredefindType(predefinedType);
			arg = binder.mustCast(arg, predefindType, CONVERTTYPE.NOUDC);
			Expr expr = binder.BindIntOp(ek, flags, arg, null, predefinedType);
			return binder.MustCastInUncheckedContext(expr, type, CONVERTTYPE.NOUDC);
		}

		private (BinOpKind, EXPRFLAG) GetBinopKindAndFlags(ExpressionKind ek)
		{
			EXPRFLAG eXPRFLAG = (EXPRFLAG)0;
			BinOpKind item;
			switch (ek)
			{
			case ExpressionKind.Add:
				if (Context.Checked)
				{
					eXPRFLAG = EXPRFLAG.EXF_CHECKOVERFLOW;
				}
				item = BinOpKind.Add;
				break;
			case ExpressionKind.Subtract:
				if (Context.Checked)
				{
					eXPRFLAG = EXPRFLAG.EXF_CHECKOVERFLOW;
				}
				item = BinOpKind.Sub;
				break;
			case ExpressionKind.Divide:
			case ExpressionKind.Modulo:
				eXPRFLAG = EXPRFLAG.EXF_ASSGOP;
				if (Context.Checked)
				{
					eXPRFLAG |= EXPRFLAG.EXF_CHECKOVERFLOW;
				}
				item = BinOpKind.Mul;
				break;
			case ExpressionKind.Multiply:
				if (Context.Checked)
				{
					eXPRFLAG = EXPRFLAG.EXF_CHECKOVERFLOW;
				}
				item = BinOpKind.Mul;
				break;
			case ExpressionKind.BitwiseAnd:
			case ExpressionKind.BitwiseOr:
				item = BinOpKind.Bitwise;
				break;
			case ExpressionKind.BitwiseExclusiveOr:
				item = BinOpKind.BitXor;
				break;
			case ExpressionKind.LeftShirt:
			case ExpressionKind.RightShift:
				item = BinOpKind.Shift;
				break;
			case ExpressionKind.LogicalAnd:
			case ExpressionKind.LogicalOr:
				item = BinOpKind.Logical;
				break;
			case ExpressionKind.LessThan:
			case ExpressionKind.LessThanOrEqual:
			case ExpressionKind.GreaterThan:
			case ExpressionKind.GreaterThanOrEqual:
				item = BinOpKind.Compare;
				break;
			case ExpressionKind.Eq:
			case ExpressionKind.NotEq:
				item = BinOpKind.Equal;
				break;
			default:
				throw Error.InternalCompilerError();
			}
			return (item, eXPRFLAG);
		}

		private ExprOperator BindIntOp(ExpressionKind kind, EXPRFLAG flags, Expr op1, Expr op2, PredefinedType ptOp)
		{
			CType predefindType = GetPredefindType(ptOp);
			if (kind == ExpressionKind.Negate)
			{
				return BindIntegerNeg(flags, op1, ptOp);
			}
			CType type = (kind.IsRelational() ? GetPredefindType(PredefinedType.PT_BOOL) : predefindType);
			ExprOperator exprOperator = ExprFactory.CreateOperator(kind, type, op1, op2);
			exprOperator.Flags |= flags;
			return exprOperator;
		}

		private ExprOperator BindIntegerNeg(EXPRFLAG flags, Expr op, PredefinedType ptOp)
		{
			GetPredefindType(ptOp);
			switch (ptOp)
			{
			case PredefinedType.PT_ULONG:
				throw BadOperatorTypesError(op, null);
			case PredefinedType.PT_UINT:
				if (op.Type.FundamentalType == FUNDTYPE.FT_U4)
				{
					op = mustConvertCore(op, GetPredefindType(PredefinedType.PT_LONG), CONVERTTYPE.NOUDC);
				}
				break;
			}
			return ExprFactory.CreateNeg(flags, op);
		}

		private static ExprOperator BindFloatOp(ExpressionKind kind, Expr op1, Expr op2)
		{
			CType type = (kind.IsRelational() ? GetPredefindType(PredefinedType.PT_BOOL) : op1.Type);
			ExprOperator exprOperator = ExprFactory.CreateOperator(kind, type, op1, op2);
			exprOperator.Flags &= ~EXPRFLAG.EXF_CHECKOVERFLOW;
			return exprOperator;
		}

		private static ExprConcat BindStringConcat(Expr op1, Expr op2)
		{
			return ExprFactory.CreateConcat(op1, op2);
		}

		private static RuntimeBinderException AmbiguousOperatorError(Expr op1, Expr op2)
		{
			string errorString = op1.ErrorString;
			if (op2 == null)
			{
				return ErrorHandling.Error(ErrorCode.ERR_AmbigUnaryOp, errorString, op1.Type);
			}
			return ErrorHandling.Error(ErrorCode.ERR_AmbigBinaryOps, errorString, op1.Type, op2.Type);
		}

		private Expr BindUserBoolOp(ExpressionKind kind, ExprCall pCall)
		{
			CType type = pCall.Type;
			if (!TypeManager.SubstEqualTypes(type, pCall.MethWithInst.Meth().Params[0], type) || !TypeManager.SubstEqualTypes(type, pCall.MethWithInst.Meth().Params[1], type))
			{
				throw ErrorHandling.Error(ErrorCode.ERR_BadBoolOp, pCall.MethWithInst);
			}
			ExprList obj = (ExprList)pCall.OptionalArguments;
			ExprWrap exprWrap = (ExprWrap)(obj.OptionalElement = WrapShortLivedExpression(obj.OptionalElement));
			SymbolTable.PopulateSymbolTableWithName("op_True", null, exprWrap.Type.AssociatedSystemType);
			SymbolTable.PopulateSymbolTableWithName("op_False", null, exprWrap.Type.AssociatedSystemType);
			Expr expr2 = bindUDUnop(ExpressionKind.True, exprWrap);
			Expr expr3 = bindUDUnop(ExpressionKind.False, exprWrap);
			if (expr2 == null || expr3 == null)
			{
				throw ErrorHandling.Error(ErrorCode.ERR_MustHaveOpTF, type);
			}
			expr2 = mustConvert(expr2, GetPredefindType(PredefinedType.PT_BOOL));
			expr3 = mustConvert(expr3, GetPredefindType(PredefinedType.PT_BOOL));
			return ExprFactory.CreateUserLogOp(type, (kind == ExpressionKind.LogicalAnd) ? expr3 : expr2, pCall);
		}

		private static AggregateType GetUserDefinedBinopArgumentType(CType type)
		{
			if (type is NullableType nullableType)
			{
				type = nullableType.UnderlyingType;
			}
			if (type is AggregateType aggregateType && (aggregateType.IsClassType || aggregateType.IsStructType) && !aggregateType.OwningAggregate.IsSkipUDOps())
			{
				return aggregateType;
			}
			return null;
		}

		private static int GetUserDefinedBinopArgumentTypes(CType type1, CType type2, AggregateType[] rgats)
		{
			int num = 0;
			rgats[0] = GetUserDefinedBinopArgumentType(type1);
			if (rgats[0] != null)
			{
				num++;
			}
			rgats[num] = GetUserDefinedBinopArgumentType(type2);
			if (rgats[num] != null)
			{
				num++;
			}
			if (num == 2 && rgats[0] == rgats[1])
			{
				num = 1;
			}
			return num;
		}

		private static bool UserDefinedBinaryOperatorCanBeLifted(ExpressionKind ek, MethodSymbol method, AggregateType ats, TypeArray Params)
		{
			if (!Params[0].IsNonNullableValueType || !Params[1].IsNonNullableValueType)
			{
				return false;
			}
			CType cType = TypeManager.SubstType(method.RetType, ats);
			if (!cType.IsNonNullableValueType)
			{
				return false;
			}
			switch (ek)
			{
			case ExpressionKind.Eq:
			case ExpressionKind.NotEq:
				if (!cType.IsPredefType(PredefinedType.PT_BOOL))
				{
					return false;
				}
				if (Params[0] != Params[1])
				{
					return false;
				}
				return true;
			case ExpressionKind.LessThan:
			case ExpressionKind.LessThanOrEqual:
			case ExpressionKind.GreaterThan:
			case ExpressionKind.GreaterThanOrEqual:
				if (!cType.IsPredefType(PredefinedType.PT_BOOL))
				{
					return false;
				}
				return true;
			default:
				return true;
			}
		}

		private bool UserDefinedBinaryOperatorIsApplicable(List<CandidateFunctionMember> candidateList, ExpressionKind ek, MethodSymbol method, AggregateType ats, Expr arg1, Expr arg2, bool fDontLift)
		{
			if (!method.isOperator || method.Params.Count != 2)
			{
				return false;
			}
			TypeArray typeArray = TypeManager.SubstTypeArray(method.Params, ats);
			if (canConvert(arg1, typeArray[0]) && canConvert(arg2, typeArray[1]))
			{
				candidateList.Add(new CandidateFunctionMember(new MethPropWithInst(method, ats, TypeArray.Empty), typeArray, 0, fExpanded: false));
				return true;
			}
			if (fDontLift || !UserDefinedBinaryOperatorCanBeLifted(ek, method, ats, typeArray))
			{
				return false;
			}
			CType[] array = new CType[2]
			{
				TypeManager.GetNullable(typeArray[0]),
				TypeManager.GetNullable(typeArray[1])
			};
			if (!canConvert(arg1, array[0]) || !canConvert(arg2, array[1]))
			{
				return false;
			}
			candidateList.Add(new CandidateFunctionMember(new MethPropWithInst(method, ats, TypeArray.Empty), TypeArray.Allocate(array), 2, fExpanded: false));
			return true;
		}

		private bool GetApplicableUserDefinedBinaryOperatorCandidates(List<CandidateFunctionMember> candidateList, ExpressionKind ek, AggregateType type, Expr arg1, Expr arg2, bool fDontLift)
		{
			Name name = ExpressionKindName(ek);
			bool result = false;
			for (MethodSymbol methodSymbol = SymbolLoader.LookupAggMember(name, type.OwningAggregate, symbmask_t.MASK_MethodSymbol) as MethodSymbol; methodSymbol != null; methodSymbol = methodSymbol.LookupNext(symbmask_t.MASK_MethodSymbol) as MethodSymbol)
			{
				if (UserDefinedBinaryOperatorIsApplicable(candidateList, ek, methodSymbol, type, arg1, arg2, fDontLift))
				{
					result = true;
				}
			}
			return result;
		}

		private AggregateType GetApplicableUserDefinedBinaryOperatorCandidatesInBaseTypes(List<CandidateFunctionMember> candidateList, ExpressionKind ek, AggregateType type, Expr arg1, Expr arg2, bool fDontLift, AggregateType atsStop)
		{
			AggregateType aggregateType = type;
			while (aggregateType != null && aggregateType != atsStop)
			{
				if (GetApplicableUserDefinedBinaryOperatorCandidates(candidateList, ek, aggregateType, arg1, arg2, fDontLift))
				{
					return aggregateType;
				}
				aggregateType = aggregateType.BaseClass;
			}
			return null;
		}

		private ExprCall BindUDBinop(ExpressionKind ek, Expr arg1, Expr arg2, bool fDontLift, out MethPropWithInst ppmpwi)
		{
			List<CandidateFunctionMember> list = new List<CandidateFunctionMember>();
			ppmpwi = null;
			AggregateType[] array = new AggregateType[2];
			switch (GetUserDefinedBinopArgumentTypes(arg1.Type, arg2.Type, array))
			{
			case 0:
				return null;
			case 1:
				GetApplicableUserDefinedBinaryOperatorCandidatesInBaseTypes(list, ek, array[0], arg1, arg2, fDontLift, null);
				break;
			default:
			{
				AggregateType applicableUserDefinedBinaryOperatorCandidatesInBaseTypes = GetApplicableUserDefinedBinaryOperatorCandidatesInBaseTypes(list, ek, array[0], arg1, arg2, fDontLift, null);
				GetApplicableUserDefinedBinaryOperatorCandidatesInBaseTypes(list, ek, array[1], arg1, arg2, fDontLift, applicableUserDefinedBinaryOperatorCandidatesInBaseTypes);
				break;
			}
			}
			if (list.IsEmpty())
			{
				return null;
			}
			ExprList args = ExprFactory.CreateList(arg1, arg2);
			ArgInfos argInfos = new ArgInfos();
			argInfos.carg = 2;
			FillInArgInfoFromArgList(argInfos, args);
			CandidateFunctionMember methAmbig;
			CandidateFunctionMember methAmbig2;
			CandidateFunctionMember candidateFunctionMember = FindBestMethod(list, null, argInfos, out methAmbig, out methAmbig2);
			if (candidateFunctionMember == null)
			{
				throw ErrorHandling.Error(ErrorCode.ERR_AmbigCall, methAmbig.mpwi, methAmbig2.mpwi);
			}
			ppmpwi = candidateFunctionMember.mpwi;
			if (candidateFunctionMember.ctypeLift != 0)
			{
				return BindLiftedUDBinop(ek, arg1, arg2, candidateFunctionMember.@params, candidateFunctionMember.mpwi);
			}
			CType typeRet = TypeManager.SubstType(candidateFunctionMember.mpwi.Meth().RetType, candidateFunctionMember.mpwi.GetType());
			return BindUDBinopCall(arg1, arg2, candidateFunctionMember.@params, typeRet, candidateFunctionMember.mpwi);
		}

		private ExprCall BindUDBinopCall(Expr arg1, Expr arg2, TypeArray Params, CType typeRet, MethPropWithInst mpwi)
		{
			arg1 = mustConvert(arg1, Params[0]);
			arg2 = mustConvert(arg2, Params[1]);
			ExprList arguments = ExprFactory.CreateList(arg1, arg2);
			CheckUnsafe(arg1.Type);
			CheckUnsafe(arg2.Type);
			CheckUnsafe(typeRet);
			ExprMemberGroup memberGroup = ExprFactory.CreateMemGroup(null, mpwi);
			ExprCall exprCall = ExprFactory.CreateCall((EXPRFLAG)0, typeRet, arguments, memberGroup, null);
			exprCall.MethWithInst = new MethWithInst(mpwi);
			verifyMethodArgs(exprCall, mpwi.GetType());
			return exprCall;
		}

		private ExprCall BindLiftedUDBinop(ExpressionKind ek, Expr arg1, Expr arg2, TypeArray Params, MethPropWithInst mpwi)
		{
			Expr expr = arg1;
			Expr expr2 = arg2;
			CType cType = TypeManager.SubstType(mpwi.Meth().RetType, mpwi.GetType());
			TypeArray typeArray = TypeManager.SubstTypeArray(mpwi.Meth().Params, mpwi.GetType());
			if (!canConvert(arg1.Type.StripNubs(), typeArray[0], CONVERTTYPE.NOUDC))
			{
				expr = mustConvert(arg1, Params[0]);
			}
			if (!canConvert(arg2.Type.StripNubs(), typeArray[1], CONVERTTYPE.NOUDC))
			{
				expr2 = mustConvert(arg2, Params[1]);
			}
			Expr arg3 = mustCast(expr, typeArray[0]);
			Expr arg4 = mustCast(expr2, typeArray[1]);
			CType cType2;
			switch (ek)
			{
			default:
				cType2 = TypeManager.GetNullable(cType);
				break;
			case ExpressionKind.Eq:
			case ExpressionKind.NotEq:
				cType2 = cType;
				break;
			case ExpressionKind.LessThan:
			case ExpressionKind.LessThanOrEqual:
			case ExpressionKind.GreaterThan:
			case ExpressionKind.GreaterThanOrEqual:
				cType2 = cType;
				break;
			}
			ExprCall expr3 = BindUDBinopCall(arg3, arg4, typeArray, cType, mpwi);
			ExprList arguments = ExprFactory.CreateList(expr, expr2);
			ExprMemberGroup memberGroup = ExprFactory.CreateMemGroup(null, mpwi);
			ExprCall exprCall = ExprFactory.CreateCall((EXPRFLAG)0, cType2, arguments, memberGroup, null);
			exprCall.MethWithInst = new MethWithInst(mpwi);
			switch (ek)
			{
			case ExpressionKind.Eq:
				exprCall.NullableCallLiftKind = NullableCallLiftKind.EqualityOperator;
				break;
			case ExpressionKind.NotEq:
				exprCall.NullableCallLiftKind = NullableCallLiftKind.InequalityOperator;
				break;
			default:
				exprCall.NullableCallLiftKind = NullableCallLiftKind.Operator;
				break;
			}
			exprCall.CastOfNonLiftedResultToLiftedType = mustCast(expr3, cType2, (CONVERTTYPE)0);
			return exprCall;
		}

		private static AggregateType GetEnumBinOpType(ExpressionKind ek, CType argType1, CType argType2, out AggregateType ppEnumType)
		{
			AggregateType aggregateType = argType1 as AggregateType;
			AggregateType aggregateType2 = argType2 as AggregateType;
			AggregateType aggregateType3 = (aggregateType.IsEnumType ? aggregateType : aggregateType2);
			AggregateType result = aggregateType3;
			switch (ek)
			{
			case ExpressionKind.Subtract:
				if (aggregateType == aggregateType2)
				{
					result = aggregateType3.UnderlyingEnumType;
				}
				break;
			default:
				result = GetPredefindType(PredefinedType.PT_BOOL);
				break;
			case ExpressionKind.Add:
			case ExpressionKind.BitwiseAnd:
			case ExpressionKind.BitwiseOr:
			case ExpressionKind.BitwiseExclusiveOr:
				break;
			}
			ppEnumType = aggregateType3;
			return result;
		}

		private static ExprBinOp CreateBinopForPredefMethodCall(ExpressionKind ek, PREDEFMETH predefMeth, CType RetType, Expr arg1, Expr arg2)
		{
			MethodSymbol method = PredefinedMembers.GetMethod(predefMeth);
			ExprBinOp exprBinOp = ExprFactory.CreateBinop(ek, RetType, arg1, arg2);
			AggregateType aggregate = TypeManager.GetAggregate(method.getClass(), TypeArray.Empty);
			exprBinOp.PredefinedMethodToCall = new MethWithInst(method, aggregate, null);
			exprBinOp.UserDefinedCallMethod = exprBinOp.PredefinedMethodToCall;
			return exprBinOp;
		}

		private static ExprUnaryOp CreateUnaryOpForPredefMethodCall(ExpressionKind ek, PREDEFMETH predefMeth, CType pRetType, Expr pArg)
		{
			MethodSymbol method = PredefinedMembers.GetMethod(predefMeth);
			ExprUnaryOp exprUnaryOp = ExprFactory.CreateUnaryOp(ek, pRetType, pArg);
			AggregateType aggregate = TypeManager.GetAggregate(method.getClass(), TypeArray.Empty);
			exprUnaryOp.PredefinedMethodToCall = new MethWithInst(method, aggregate, null);
			exprUnaryOp.UserDefinedCallMethod = exprUnaryOp.PredefinedMethodToCall;
			return exprUnaryOp;
		}
	}
	internal enum BinOpKind
	{
		Add,
		Sub,
		Mul,
		Shift,
		Equal,
		Compare,
		Bitwise,
		BitXor,
		Logical,
		Lim
	}
	[Flags]
	internal enum BinOpMask
	{
		None = 0,
		Add = 1,
		Sub = 2,
		Mul = 4,
		Shift = 8,
		Equal = 0x10,
		Compare = 0x20,
		Bitwise = 0x40,
		BitXor = 0x80,
		Logical = 0x100,
		Integer = 0xF7,
		Real = 0x37,
		BoolNorm = 0x90,
		Delegate = 0x13,
		Enum = 0xF2,
		EnumUnder = 3,
		UnderEnum = 1
	}
	internal readonly struct BindingContext
	{
		public AggregateSymbol ContextForMemberLookup { get; }

		public bool Checked { get; }

		public BindingContext(AggregateSymbol context, bool isChecked)
		{
			ContextForMemberLookup = context;
			Checked = isChecked;
		}

		public BindingContext(BindingContext parent)
		{
			ContextForMemberLookup = parent.ContextForMemberLookup;
			Checked = false;
		}
	}
	[Flags]
	internal enum BindingFlag
	{
		BIND_RVALUEREQUIRED = 1,
		BIND_MEMBERSET = 2,
		BIND_FIXEDVALUE = 0x10,
		BIND_ARGUMENTS = 0x20,
		BIND_BASECALL = 0x40,
		BIND_USINGVALUE = 0x80,
		BIND_STMTEXPRONLY = 0x100,
		BIND_TYPEOK = 0x200,
		BIND_MAYBECONFUSEDNEGATIVECAST = 0x400,
		BIND_METHODNOTOK = 0x800,
		BIND_DECLNOTOK = 0x1000,
		BIND_NOPARAMS = 0x2000,
		BIND_SPECULATIVELY = 0x4000
	}
	internal static class Operators
	{
		private sealed class OperatorInfo
		{
			public readonly TokenKind TokenKind;

			public readonly PredefinedName MethodName;

			public readonly ExpressionKind ExpressionKind;

			public OperatorInfo(TokenKind kind, PredefinedName pn, ExpressionKind e)
			{
				TokenKind = kind;
				MethodName = pn;
				ExpressionKind = e;
			}
		}

		private static readonly OperatorInfo[] s_operatorInfos = new OperatorInfo[68]
		{
			new OperatorInfo(TokenKind.Unknown, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.Equal, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.PlusEqual, PredefinedName.PN_COUNT, (ExpressionKind)113),
			new OperatorInfo(TokenKind.MinusEqual, PredefinedName.PN_COUNT, (ExpressionKind)114),
			new OperatorInfo(TokenKind.SplatEqual, PredefinedName.PN_COUNT, (ExpressionKind)115),
			new OperatorInfo(TokenKind.SlashEqual, PredefinedName.PN_COUNT, (ExpressionKind)116),
			new OperatorInfo(TokenKind.PercentEqual, PredefinedName.PN_COUNT, (ExpressionKind)117),
			new OperatorInfo(TokenKind.AndEqual, PredefinedName.PN_COUNT, (ExpressionKind)120),
			new OperatorInfo(TokenKind.HatEqual, PredefinedName.PN_COUNT, (ExpressionKind)122),
			new OperatorInfo(TokenKind.BarEqual, PredefinedName.PN_COUNT, (ExpressionKind)121),
			new OperatorInfo(TokenKind.LeftShiftEqual, PredefinedName.PN_COUNT, (ExpressionKind)124),
			new OperatorInfo(TokenKind.RightShiftEqual, PredefinedName.PN_COUNT, (ExpressionKind)125),
			new OperatorInfo(TokenKind.Question, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.QuestionQuestion, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.LogicalOr, PredefinedName.PN_COUNT, ExpressionKind.LogicalOr),
			new OperatorInfo(TokenKind.LogicalAnd, PredefinedName.PN_COUNT, ExpressionKind.LogicalAnd),
			new OperatorInfo(TokenKind.Bar, PredefinedName.PN_OPBITWISEOR, ExpressionKind.BitwiseOr),
			new OperatorInfo(TokenKind.Hat, PredefinedName.PN_OPXOR, ExpressionKind.BitwiseExclusiveOr),
			new OperatorInfo(TokenKind.Ampersand, PredefinedName.PN_OPBITWISEAND, ExpressionKind.BitwiseAnd),
			new OperatorInfo(TokenKind.EqualEqual, PredefinedName.PN_OPEQUALITY, ExpressionKind.Eq),
			new OperatorInfo(TokenKind.NotEqual, PredefinedName.PN_OPINEQUALITY, ExpressionKind.NotEq),
			new OperatorInfo(TokenKind.LessThan, PredefinedName.PN_OPLESSTHAN, ExpressionKind.LessThan),
			new OperatorInfo(TokenKind.LessThanEqual, PredefinedName.PN_OPLESSTHANOREQUAL, ExpressionKind.LessThanOrEqual),
			new OperatorInfo(TokenKind.GreaterThan, PredefinedName.PN_OPGREATERTHAN, ExpressionKind.GreaterThan),
			new OperatorInfo(TokenKind.GreaterThanEqual, PredefinedName.PN_OPGREATERTHANOREQUAL, ExpressionKind.GreaterThanOrEqual),
			new OperatorInfo(TokenKind.Is, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.As, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.LeftShift, PredefinedName.PN_OPLEFTSHIFT, ExpressionKind.LeftShirt),
			new OperatorInfo(TokenKind.RightShift, PredefinedName.PN_OPRIGHTSHIFT, ExpressionKind.RightShift),
			new OperatorInfo(TokenKind.Plus, PredefinedName.PN_OPPLUS, ExpressionKind.Add),
			new OperatorInfo(TokenKind.Minus, PredefinedName.PN_OPMINUS, ExpressionKind.Subtract),
			new OperatorInfo(TokenKind.Splat, PredefinedName.PN_OPMULTIPLY, ExpressionKind.Multiply),
			new OperatorInfo(TokenKind.Slash, PredefinedName.PN_OPDIVISION, ExpressionKind.Divide),
			new OperatorInfo(TokenKind.Percent, PredefinedName.PN_OPMODULUS, ExpressionKind.Modulo),
			new OperatorInfo(TokenKind.Unknown, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.Plus, PredefinedName.PN_OPUNARYPLUS, ExpressionKind.UnaryPlus),
			new OperatorInfo(TokenKind.Minus, PredefinedName.PN_OPUNARYMINUS, ExpressionKind.Negate),
			new OperatorInfo(TokenKind.Tilde, PredefinedName.PN_OPCOMPLEMENT, ExpressionKind.BitwiseNot),
			new OperatorInfo(TokenKind.Bang, PredefinedName.PN_OPNEGATION, ExpressionKind.LogicalNot),
			new OperatorInfo(TokenKind.PlusPlus, PredefinedName.PN_OPINCREMENT, ExpressionKind.Add),
			new OperatorInfo(TokenKind.MinusMinus, PredefinedName.PN_OPDECREMENT, ExpressionKind.Subtract),
			new OperatorInfo(TokenKind.TypeOf, PredefinedName.PN_COUNT, ExpressionKind.TypeOf),
			new OperatorInfo(TokenKind.Checked, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.Unchecked, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.MakeRef, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.RefValue, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.RefType, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.ArgList, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.Unknown, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.Splat, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.Ampersand, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.Colon, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.This, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.Base, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.Null, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.True, PredefinedName.PN_OPTRUE, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.False, PredefinedName.PN_OPFALSE, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.Unknown, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.Unknown, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.Unknown, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.PlusPlus, PredefinedName.PN_COUNT, ExpressionKind.Add),
			new OperatorInfo(TokenKind.MinusMinus, PredefinedName.PN_COUNT, ExpressionKind.Subtract),
			new OperatorInfo(TokenKind.Dot, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.Implicit, PredefinedName.PN_OPIMPLICITMN, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.Explicit, PredefinedName.PN_OPEXPLICITMN, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.Unknown, PredefinedName.PN_OPEQUALS, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.Unknown, PredefinedName.PN_OPCOMPARE, ExpressionKind.ExpressionKindCount),
			new OperatorInfo(TokenKind.Unknown, PredefinedName.PN_COUNT, ExpressionKind.ExpressionKindCount)
		};

		private static Dictionary<Name, string> s_operatorsByName;

		private static Dictionary<Name, string> GetOperatorByName()
		{
			Dictionary<Name, string> dictionary = new Dictionary<Name, string>(28)
			{
				{
					NameManager.GetPredefinedName(PredefinedName.PN_OPEQUALS),
					"equals"
				},
				{
					NameManager.GetPredefinedName(PredefinedName.PN_OPCOMPARE),
					"compare"
				}
			};
			OperatorInfo[] array = s_operatorInfos;
			foreach (OperatorInfo obj in array)
			{
				PredefinedName methodName = obj.MethodName;
				TokenKind tokenKind = obj.TokenKind;
				if (methodName != PredefinedName.PN_COUNT && tokenKind != TokenKind.Unknown)
				{
					dictionary.Add(NameManager.GetPredefinedName(methodName), TokenFacts.GetText(tokenKind));
				}
			}
			return dictionary;
		}

		private static OperatorInfo GetInfo(OperatorKind op)
		{
			return s_operatorInfos[(uint)op];
		}

		public static string OperatorOfMethodName(Name name)
		{
			return (s_operatorsByName ?? (s_operatorsByName = GetOperatorByName()))[name];
		}

		public static string GetDisplayName(OperatorKind op)
		{
			return TokenFacts.GetText(GetInfo(op).TokenKind);
		}

		public static ExpressionKind GetExpressionKind(OperatorKind op)
		{
			return GetInfo(op).ExpressionKind;
		}
	}
	internal sealed class CandidateFunctionMember
	{
		public MethPropWithInst mpwi;

		public TypeArray @params;

		public byte ctypeLift;

		public bool fExpanded;

		public CandidateFunctionMember(MethPropWithInst mpwi, TypeArray @params, byte ctypeLift, bool fExpanded)
		{
			this.mpwi = mpwi;
			this.@params = @params;
			this.ctypeLift = ctypeLift;
			this.fExpanded = fExpanded;
		}
	}
	internal enum ConstValKind
	{
		Int,
		Double,
		Long,
		String,
		Decimal,
		IntPtr,
		Float,
		Boolean
	}
	internal readonly struct ConstVal(object value)
	{
		private static readonly object s_false = false;

		private static readonly object s_true = true;

		private static readonly object s_zeroInt32 = 0;

		public object ObjectVal { get; } = value;

		public bool BooleanVal => SpecialUnbox<bool>(ObjectVal);

		public sbyte SByteVal => SpecialUnbox<sbyte>(ObjectVal);

		public byte ByteVal => SpecialUnbox<byte>(ObjectVal);

		public short Int16Val => SpecialUnbox<short>(ObjectVal);

		public ushort UInt16Val => SpecialUnbox<ushort>(ObjectVal);

		public int Int32Val => SpecialUnbox<int>(ObjectVal);

		public uint UInt32Val => SpecialUnbox<uint>(ObjectVal);

		public long Int64Val => SpecialUnbox<long>(ObjectVal);

		public ulong UInt64Val => SpecialUnbox<ulong>(ObjectVal);

		public float SingleVal => SpecialUnbox<float>(ObjectVal);

		public double DoubleVal => SpecialUnbox<double>(ObjectVal);

		public decimal DecimalVal => SpecialUnbox<decimal>(ObjectVal);

		public char CharVal => SpecialUnbox<char>(ObjectVal);

		public string StringVal => SpecialUnbox<string>(ObjectVal);

		public bool IsNullRef => ObjectVal == null;

		public bool IsZero(ConstValKind kind)
		{
			return kind switch
			{
				ConstValKind.Decimal => DecimalVal == 0m, 
				ConstValKind.String => false, 
				_ => IsDefault(ObjectVal), 
			};
		}

		private static T SpecialUnbox<T>(object o)
		{
			if (IsDefault(o))
			{
				return default(T);
			}
			return (T)Convert.ChangeType(o, typeof(T), CultureInfo.InvariantCulture);
		}

		private static bool IsDefault(object o)
		{
			if (o == null)
			{
				return true;
			}
			switch (Type.GetTypeCode(o.GetType()))
			{
			case TypeCode.Boolean:
				return false.Equals(o);
			case TypeCode.SByte:
				return ((sbyte)0).Equals(o);
			case TypeCode.Byte:
				return ((byte)0).Equals(o);
			case TypeCode.Int16:
				return ((short)0).Equals(o);
			case TypeCode.UInt16:
				return ((ushort)0).Equals(o);
			case TypeCode.Int32:
				return 0.Equals(o);
			case TypeCode.UInt32:
				return 0u.Equals(o);
			case TypeCode.Int64:
				return 0L.Equals(o);
			case TypeCode.UInt64:
				return 0uL.Equals(o);
			case TypeCode.Single:
				return 0f.Equals(o);
			case TypeCode.Double:
				return 0.0.Equals(o);
			case TypeCode.Decimal:
			{
				decimal num = 0m;
				return num.Equals(o);
			}
			case TypeCode.Char:
				return '\0'.Equals(o);
			default:
				return false;
			}
		}

		public static ConstVal GetDefaultValue(ConstValKind kind)
		{
			return kind switch
			{
				ConstValKind.Int => new ConstVal(s_zeroInt32), 
				ConstValKind.Double => new ConstVal(0.0), 
				ConstValKind.Long => new ConstVal(0L), 
				ConstValKind.Decimal => new ConstVal(0m), 
				ConstValKind.Float => new ConstVal(0f), 
				ConstValKind.Boolean => new ConstVal(s_false), 
				_ => default(ConstVal), 
			};
		}

		public static ConstVal Get(bool value)
		{
			return new ConstVal(value ? s_true : s_false);
		}

		public static ConstVal Get(int value)
		{
			return new ConstVal((value == 0) ? s_zeroInt32 : ((object)value));
		}

		public static ConstVal Get(uint value)
		{
			return new ConstVal(value);
		}

		public static ConstVal Get(decimal value)
		{
			return new ConstVal(value);
		}

		public static ConstVal Get(string value)
		{
			return new ConstVal(value);
		}

		public static ConstVal Get(float value)
		{
			return new ConstVal(value);
		}

		public static ConstVal Get(double value)
		{
			return new ConstVal(value);
		}

		public static ConstVal Get(long value)
		{
			return new ConstVal(value);
		}

		public static ConstVal Get(ulong value)
		{
			return new ConstVal(value);
		}

		public static ConstVal Get(object p)
		{
			return new ConstVal(p);
		}
	}
	internal enum ConvKind
	{
		Identity = 1,
		Implicit,
		Explicit,
		Unknown,
		None
	}
	[Flags]
	internal enum CONVERTTYPE
	{
		NOUDC = 1,
		STANDARD = 2,
		ISEXPLICIT = 4,
		CHECKOVERFLOW = 8,
		FORCECAST = 0x10,
		STANDARDANDNOUDC = 3
	}
	internal enum BetterType
	{
		Same,
		Left,
		Right,
		Neither
	}
	internal static class ListExtensions
	{
		public static bool IsEmpty<T>(this List<T> list)
		{
			if (list != null)
			{
				return list.Count == 0;
			}
			return true;
		}

		public static T Head<T>(this List<T> list)
		{
			return list[0];
		}

		public static List<T> Tail<T>(this List<T> list)
		{
			T[] array = new T[list.Count];
			list.CopyTo(array, 0);
			List<T> list2 = new List<T>(array);
			list2.RemoveAt(0);
			return list2;
		}
	}
	internal static class CConversions
	{
		public static bool FImpRefConv(CType typeSrc, CType typeDst)
		{
			if (typeSrc.IsReferenceType)
			{
				return SymbolLoader.HasIdentityOrImplicitReferenceConversion(typeSrc, typeDst);
			}
			return false;
		}

		public static bool FExpRefConv(CType typeSrc, CType typeDst)
		{
			if (typeSrc.IsReferenceType && typeDst.IsReferenceType)
			{
				if (SymbolLoader.HasIdentityOrImplicitReferenceConversion(typeSrc, typeDst) || SymbolLoader.HasIdentityOrImplicitReferenceConversion(typeDst, typeSrc))
				{
					return true;
				}
				if ((typeSrc.IsInterfaceType && typeDst is TypeParameterType) || (typeSrc is TypeParameterType && typeDst.IsInterfaceType))
				{
					return true;
				}
				if (typeSrc is AggregateType aggregateType && typeDst is AggregateType aggregateType2)
				{
					AggregateSymbol owningAggregate = aggregateType.OwningAggregate;
					AggregateSymbol owningAggregate2 = aggregateType2.OwningAggregate;
					if ((owningAggregate.IsClass() && !owningAggregate.IsSealed() && owningAggregate2.IsInterface()) || (owningAggregate.IsInterface() && owningAggregate2.IsClass() && !owningAggregate2.IsSealed()) || (owningAggregate.IsInterface() && owningAggregate2.IsInterface()))
					{
						return true;
					}
				}
				if (typeSrc is ArrayType arrayType)
				{
					if (typeDst is ArrayType arrayType2)
					{
						if (arrayType.Rank == arrayType2.Rank && arrayType.IsSZArray == arrayType2.IsSZArray)
						{
							return FExpRefConv(arrayType.ElementType, arrayType2.ElementType);
						}
						return false;
					}
					if (!arrayType.IsSZArray || !typeDst.IsInterfaceType)
					{
						return false;
					}
					AggregateType aggregateType3 = (AggregateType)typeDst;
					TypeArray typeArgsAll = aggregateType3.TypeArgsAll;
					if (typeArgsAll.Count != 1)
					{
						return false;
					}
					AggregateSymbol predefAgg = SymbolLoader.GetPredefAgg(PredefinedType.PT_G_ILIST);
					AggregateSymbol predefAgg2 = SymbolLoader.GetPredefAgg(PredefinedType.PT_G_IREADONLYLIST);
					if ((predefAgg == null || !SymbolLoader.IsBaseAggregate(predefAgg, aggregateType3.OwningAggregate)) && (predefAgg2 == null || !SymbolLoader.IsBaseAggregate(predefAgg2, aggregateType3.OwningAggregate)))
					{
						return false;
					}
					return FExpRefConv(arrayType.ElementType, typeArgsAll[0]);
				}
				if (typeDst is ArrayType arrayType3 && typeSrc is AggregateType aggregateType4)
				{
					if (SymbolLoader.HasIdentityOrImplicitReferenceConversion(SymbolLoader.GetPredefindType(PredefinedType.PT_ARRAY), typeSrc))
					{
						return true;
					}
					if (!arrayType3.IsSZArray || !typeSrc.IsInterfaceType || aggregateType4.TypeArgsAll.Count != 1)
					{
						return false;
					}
					AggregateSymbol predefAgg3 = SymbolLoader.GetPredefAgg(PredefinedType.PT_G_ILIST);
					AggregateSymbol predefAgg4 = SymbolLoader.GetPredefAgg(PredefinedType.PT_G_IREADONLYLIST);
					if ((predefAgg3 == null || !SymbolLoader.IsBaseAggregate(predefAgg3, aggregateType4.OwningAggregate)) && (predefAgg4 == null || !SymbolLoader.IsBaseAggregate(predefAgg4, aggregateType4.OwningAggregate)))
					{
						return false;
					}
					CType elementType = arrayType3.ElementType;
					CType cType = aggregateType4.TypeArgsAll[0];
					if (elementType != cType)
					{
						return FExpRefConv(elementType, cType);
					}
					return true;
				}
				if (HasGenericDelegateExplicitReferenceConversion(typeSrc, typeDst))
				{
					return true;
				}
			}
			else
			{
				if (typeSrc.IsReferenceType)
				{
					return SymbolLoader.HasIdentityOrImplicitReferenceConversion(typeSrc, typeDst);
				}
				if (typeDst.IsReferenceType)
				{
					return SymbolLoader.HasIdentityOrImplicitReferenceConversion(typeDst, typeSrc);
				}
			}
			return false;
		}

		public static bool HasGenericDelegateExplicitReferenceConversion(CType source, CType target)
		{
			if (target is AggregateType pTarget)
			{
				return HasGenericDelegateExplicitReferenceConversion(source, pTarget);
			}
			return false;
		}

		public static bool HasGenericDelegateExplicitReferenceConversion(CType pSource, AggregateType pTarget)
		{
			if (!(pSource is AggregateType { IsDelegateType: not false } aggregateType) || !pTarget.IsDelegateType || aggregateType.OwningAggregate != pTarget.OwningAggregate || SymbolLoader.HasIdentityOrImplicitReferenceConversion(aggregateType, pTarget))
			{
				return false;
			}
			TypeArray typeVarsAll = aggregateType.OwningAggregate.GetTypeVarsAll();
			TypeArray typeArgsAll = aggregateType.TypeArgsAll;
			TypeArray typeArgsAll2 = pTarget.TypeArgsAll;
			for (int i = 0; i < typeVarsAll.Count; i++)
			{
				CType cType = typeArgsAll[i];
				CType cType2 = typeArgsAll2[i];
				if (cType == cType2)
				{
					continue;
				}
				TypeParameterType typeParameterType = (TypeParameterType)typeVarsAll[i];
				if (typeParameterType.Invariant)
				{
					return false;
				}
				if (typeParameterType.Covariant)
				{
					if (!FExpRefConv(cType, cType2))
					{
						return false;
					}
				}
				else if (typeParameterType.Contravariant && (!cType.IsReferenceType || !cType2.IsReferenceType))
				{
					return false;
				}
			}
			return true;
		}

		public static bool FWrappingConv(CType typeSrc, CType typeDst)
		{
			if (typeDst is NullableType nullableType)
			{
				return typeSrc == nullableType.UnderlyingType;
			}
			return false;
		}

		public static bool FUnwrappingConv(CType typeSrc, CType typeDst)
		{
			return FWrappingConv(typeDst, typeSrc);
		}
	}
	internal static class EXPRExtensions
	{
		public static Expr Map(this Expr expr, Func<Expr, Expr> f)
		{
			if (expr == null)
			{
				return f(null);
			}
			Expr first = null;
			Expr last = null;
			foreach (Expr item in expr.ToEnumerable())
			{
				ExprFactory.AppendItemToList(f(item), ref first, ref last);
			}
			return first;
		}

		public static IEnumerable<Expr> ToEnumerable(this Expr expr)
		{
			Expr expr2 = expr;
			while (expr2 != null)
			{
				if (expr2 is ExprList list)
				{
					yield return list.OptionalElement;
					expr2 = list.OptionalNextListNode;
					continue;
				}
				yield return expr2;
				break;
			}
		}

		[Conditional("DEBUG")]
		public static void AssertIsBin(this Expr expr)
		{
		}

		public static bool isLvalue(this Expr expr)
		{
			if (expr != null)
			{
				return (expr.Flags & EXPRFLAG.EXF_LVALUE) != 0;
			}
			return false;
		}

		public static bool isChecked(this Expr expr)
		{
			if (expr != null)
			{
				return (expr.Flags & EXPRFLAG.EXF_CHECKOVERFLOW) != 0;
			}
			return false;
		}

		public static bool isNull(this Expr expr)
		{
			if (expr is ExprConstant exprConstant && expr.Type.FundamentalType == FUNDTYPE.FT_REF)
			{
				return exprConstant.Val.IsNullRef;
			}
			return false;
		}

		public static bool IsZero(this Expr expr)
		{
			if (expr is ExprConstant exprConstant)
			{
				return exprConstant.IsZero;
			}
			return false;
		}

		private static Expr GetSeqVal(this Expr expr)
		{
			if (expr == null)
			{
				return null;
			}
			Expr expr2 = expr;
			while (expr2.Kind == ExpressionKind.Sequence)
			{
				expr2 = ((ExprBinOp)expr2).OptionalRightChild;
			}
			return expr2;
		}

		public static Expr GetConst(this Expr expr)
		{
			Expr seqVal = expr.GetSeqVal();
			switch (seqVal?.Kind)
			{
			case ExpressionKind.Constant:
			case ExpressionKind.ZeroInit:
				return seqVal;
			default:
				return null;
			}
		}
	}
	[Flags]
	internal enum EXPRFLAG
	{
		EXF_BINOP = 1,
		EXF_CTOR = 2,
		EXF_NEEDSRET = 2,
		EXF_ASLEAVE = 2,
		EXF_ISFAULT = 2,
		EXF_HASHTABLESWITCH = 2,
		EXF_BOX = 2,
		EXF_ARRAYCONST = 2,
		EXF_MEMBERSET = 2,
		EXF_OPENTYPE = 2,
		EXF_LABELREFERENCED = 2,
		EXF_GENERATEDQMARK = 2,
		EXF_INDEXER = 4,
		EXF_GOTOCASE = 4,
		EXF_REMOVEFINALLY = 4,
		EXF_UNBOX = 4,
		EXF_ARRAYALLCONST = 4,
		EXF_CTORPREAMBLE = 4,
		EXF_USERLABEL = 4,
		EXF_OPERATOR = 8,
		EXF_ISPOSTOP = 8,
		EXF_FINALLYBLOCKED = 8,
		EXF_REFCHECK = 8,
		EXF_WRAPASTEMP = 8,
		EXF_LITERALCONST = 0x10,
		EXF_BADGOTO = 0x10,
		EXF_RETURNISYIELD = 0x10,
		EXF_ISFINALLY = 0x10,
		EXF_NEWOBJCALL = 0x10,
		EXF_INDEXEXPR = 0x10,
		EXF_REPLACEWRAP = 0x10,
		EXF_UNREALIZEDGOTO = 0x20,
		EXF_CONSTRAINED = 0x20,
		EXF_FORCE_BOX = 0x20,
		EXF_SIMPLENAME = 0x20,
		EXF_ASFINALLYLEAVE = 0x40,
		EXF_BASECALL = 0x40,
		EXF_FORCE_UNBOX = 0x40,
		EXF_ADDRNOCONV = 0x40,
		EXF_GOTONOTBLOCKED = 0x80,
		EXF_DELEGATE = 0x80,
		EXF_STATIC_CAST = 0x80,
		EXF_USERCALLABLE = 0x100,
		EXF_UNBOXRUNTIME = 0x100,
		EXF_NEWSTRUCTASSG = 0x200,
		EXF_GENERATEDSTMT = 0x200,
		EXF_IMPLICITSTRUCTASSG = 0x400,
		EXF_MARKING = 0x400,
		EXF_UNREACHABLEBEGIN = 0x800,
		EXF_UNREACHABLEEND = 0x1000,
		EXF_USEORIGDEBUGINFO = 0x2000,
		EXF_LASTBRACEDEBUGINFO = 0x4000,
		EXF_NODEBUGINFO = 0x8000,
		EXF_IMPLICITTHIS = 0x10000,
		EXF_CANTBENULL = 0x20000,
		EXF_CHECKOVERFLOW = 0x40000,
		EXF_PUSH_OP_FIRST = 0x100000,
		EXF_ASSGOP = 0x200000,
		EXF_LVALUE = 0x400000,
		EXF_SAMENAMETYPE = 0x800000,
		EXF_MASK_ANY = 0xF7F800,
		EXF_CAST_ALL = 0xFE
	}
	internal static class ExprFactory
	{
		public static ExprCall CreateCall(EXPRFLAG flags, CType type, Expr arguments, ExprMemberGroup memberGroup, MethWithInst method)
		{
			return new ExprCall(type, flags, arguments, memberGroup, method);
		}

		public static ExprField CreateField(CType type, Expr optionalObject, FieldWithType field)
		{
			return new ExprField(type, optionalObject, field);
		}

		public static ExprArrayInit CreateArrayInit(CType type, Expr arguments, Expr argumentDimensions, int[] dimSizes, int dimSize)
		{
			return new ExprArrayInit(type, arguments, argumentDimensions, dimSizes, dimSize);
		}

		public static ExprProperty CreateProperty(CType type, Expr optionalObjectThrough, Expr arguments, ExprMemberGroup memberGroup, PropWithType property, MethWithType setMethod)
		{
			return new ExprProperty(type, optionalObjectThrough, arguments, memberGroup, property, setMethod);
		}

		public static ExprMemberGroup CreateMemGroup(EXPRFLAG flags, Name name, TypeArray typeArgs, SYMKIND symKind, CType parentType, Expr obj, CMemberLookupResults memberLookupResults)
		{
			return new ExprMemberGroup(flags, name, typeArgs, symKind, parentType, obj, memberLookupResults);
		}

		public static ExprMemberGroup CreateMemGroup(Expr obj, MethPropWithInst method)
		{
			Name name = method.Sym?.name;
			return CreateMemGroup((EXPRFLAG)0, name, method.TypeArgs, method.MethProp()?.getKind() ?? SYMKIND.SK_MethodSymbol, method.GetType(), obj, new CMemberLookupResults(TypeArray.Allocate(method.GetType()), name));
		}

		public static ExprUserDefinedConversion CreateUserDefinedConversion(Expr arg, Expr call, MethWithInst method)
		{
			return new ExprUserDefinedConversion(arg, call, method);
		}

		public static ExprCast CreateCast(CType type, Expr argument)
		{
			return CreateCast((EXPRFLAG)0, type, argument);
		}

		public static ExprCast CreateCast(EXPRFLAG flags, CType type, Expr argument)
		{
			return new ExprCast(flags, type, argument);
		}

		public static ExprLocal CreateLocal(LocalVariableSymbol local)
		{
			return new ExprLocal(local);
		}

		public static ExprBoundLambda CreateAnonymousMethod(AggregateType delegateType, Scope argumentScope, Expr expression)
		{
			return new ExprBoundLambda(delegateType, argumentScope, expression);
		}

		public static ExprMethodInfo CreateMethodInfo(MethPropWithInst mwi)
		{
			return CreateMethodInfo(mwi.Meth(), mwi.GetType(), mwi.TypeArgs);
		}

		public static ExprMethodInfo CreateMethodInfo(MethodSymbol method, AggregateType methodType, TypeArray methodParameters)
		{
			return new ExprMethodInfo(TypeManager.GetPredefAgg(method.IsConstructor() ? PredefinedType.PT_CONSTRUCTORINFO : PredefinedType.PT_METHODINFO).getThisType(), method, methodType, methodParameters);
		}

		public static ExprPropertyInfo CreatePropertyInfo(PropertySymbol prop, AggregateType propertyType)
		{
			return new ExprPropertyInfo(TypeManager.GetPredefAgg(PredefinedType.PT_PROPERTYINFO).getThisType(), prop, propertyType);
		}

		public static ExprFieldInfo CreateFieldInfo(FieldSymbol field, AggregateType fieldType)
		{
			return new ExprFieldInfo(field, fieldType, TypeManager.GetPredefAgg(PredefinedType.PT_FIELDINFO).getThisType());
		}

		public static ExprTypeOf CreateTypeOf(CType sourceType)
		{
			return new ExprTypeOf(TypeManager.GetPredefAgg(PredefinedType.PT_TYPE).getThisType(), sourceType);
		}

		public static ExprUserLogicalOp CreateUserLogOp(CType type, Expr trueFalseCall, ExprCall operatorCall)
		{
			return new ExprUserLogicalOp(type, trueFalseCall, operatorCall);
		}

		public static ExprConcat CreateConcat(Expr first, Expr second)
		{
			return new ExprConcat(first, second);
		}

		public static ExprConstant CreateStringConstant(string str)
		{
			return CreateConstant(TypeManager.GetPredefAgg(PredefinedType.PT_STRING).getThisType(), ConstVal.Get(str));
		}

		public static ExprMultiGet CreateMultiGet(EXPRFLAG flags, CType type, ExprMulti multi)
		{
			return new ExprMultiGet(type, flags, multi);
		}

		public static ExprMulti CreateMulti(EXPRFLAG flags, CType type, Expr left, Expr op)
		{
			return new ExprMulti(type, flags, left, op);
		}

		public static Expr CreateZeroInit(CType type)
		{
			if (type.IsEnumType)
			{
				return CreateConstant(type, ConstVal.Get(Activator.CreateInstance(type.AssociatedSystemType)));
			}
			switch (type.FundamentalType)
			{
			case FUNDTYPE.FT_PTR:
				return CreateCast((EXPRFLAG)0, type, CreateNull());
			case FUNDTYPE.FT_STRUCT:
				if (type.IsPredefType(PredefinedType.PT_DECIMAL))
				{
					break;
				}
				goto case FUNDTYPE.FT_VAR;
			case FUNDTYPE.FT_VAR:
				return new ExprZeroInit(type);
			}
			return CreateConstant(type, ConstVal.GetDefaultValue(type.ConstValKind));
		}

		public static ExprConstant CreateConstant(CType type, ConstVal constVal)
		{
			return new ExprConstant(type, constVal);
		}

		public static ExprConstant CreateIntegerConstant(int x)
		{
			return CreateConstant(TypeManager.GetPredefAgg(PredefinedType.PT_INT).getThisType(), ConstVal.Get(x));
		}

		public static ExprConstant CreateBoolConstant(bool b)
		{
			return CreateConstant(TypeManager.GetPredefAgg(PredefinedType.PT_BOOL).getThisType(), ConstVal.Get(b));
		}

		public static ExprArrayIndex CreateArrayIndex(CType type, Expr array, Expr index)
		{
			return new ExprArrayIndex(type, array, index);
		}

		public static ExprBinOp CreateBinop(ExpressionKind exprKind, CType type, Expr left, Expr right)
		{
			return new ExprBinOp(exprKind, type, left, right);
		}

		public static ExprUnaryOp CreateUnaryOp(ExpressionKind exprKind, CType type, Expr operand)
		{
			return new ExprUnaryOp(exprKind, type, operand);
		}

		public static ExprOperator CreateOperator(ExpressionKind exprKind, CType type, Expr arg1, Expr arg2)
		{
			if (!exprKind.IsUnaryOperator())
			{
				return CreateBinop(exprKind, type, arg1, arg2);
			}
			return CreateUnaryOp(exprKind, type, arg1);
		}

		public static ExprBinOp CreateUserDefinedBinop(ExpressionKind exprKind, CType type, Expr left, Expr right, Expr call, MethPropWithInst userMethod)
		{
			return new ExprBinOp(exprKind, type, left, right, call, userMethod);
		}

		public static ExprUnaryOp CreateUserDefinedUnaryOperator(ExpressionKind exprKind, CType type, Expr operand, ExprCall call, MethPropWithInst userMethod)
		{
			return new ExprUnaryOp(exprKind, type, operand, call, userMethod);
		}

		public static ExprUnaryOp CreateNeg(EXPRFLAG flags, Expr operand)
		{
			ExprUnaryOp exprUnaryOp = CreateUnaryOp(ExpressionKind.Negate, operand.Type, operand);
			exprUnaryOp.Flags |= flags;
			return exprUnaryOp;
		}

		public static ExprBinOp CreateSequence(Expr first, Expr second)
		{
			return CreateBinop(ExpressionKind.Sequence, second.Type, first, second);
		}

		public static ExprAssignment CreateAssignment(Expr left, Expr right)
		{
			return new ExprAssignment(left, right);
		}

		public static ExprNamedArgumentSpecification CreateNamedArgumentSpecification(Name name, Expr value)
		{
			return new ExprNamedArgumentSpecification(name, value);
		}

		public static ExprWrap CreateWrap(Expr expression)
		{
			return new ExprWrap(expression);
		}

		public static ExprBinOp CreateSave(ExprWrap wrap)
		{
			ExprBinOp exprBinOp = CreateBinop(ExpressionKind.Save, wrap.Type, wrap.OptionalExpression, wrap);
			exprBinOp.SetAssignment();
			return exprBinOp;
		}

		public static ExprConstant CreateNull()
		{
			return CreateConstant(NullType.Instance, default(ConstVal));
		}

		public static void AppendItemToList(Expr newItem, ref Expr first, ref Expr last)
		{
			if (newItem != null)
			{
				if (first == null)
				{
					first = newItem;
					last = newItem;
				}
				else if (first.Kind != ExpressionKind.List)
				{
					first = CreateList(first, newItem);
					last = first;
				}
				else
				{
					ExprList exprList = (ExprList)last;
					exprList.OptionalNextListNode = CreateList(exprList.OptionalNextListNode, newItem);
					last = exprList.OptionalNextListNode;
				}
			}
		}

		public static ExprList CreateList(Expr op1, Expr op2)
		{
			return new ExprList(op1, op2);
		}

		public static ExprList CreateList(Expr op1, Expr op2, Expr op3)
		{
			return CreateList(op1, CreateList(op2, op3));
		}

		public static ExprList CreateList(Expr op1, Expr op2, Expr op3, Expr op4)
		{
			return CreateList(op1, CreateList(op2, CreateList(op3, op4)));
		}

		public static ExprClass CreateClass(CType type)
		{
			return new ExprClass(type);
		}
	}
	internal readonly struct UdConvInfo(MethWithType mwt, bool srcImplicit, bool dstImplicit)
	{
		public readonly MethWithType Meth = mwt;

		public readonly bool SrcImplicit = srcImplicit;

		public readonly bool DstImplicit = dstImplicit;
	}
	internal sealed class ArgInfos
	{
		public int carg;

		public TypeArray types;

		public List<Expr> prgexpr;
	}
	internal enum ConstCastResult
	{
		Success,
		Failure,
		CheckFailure
	}
	internal enum AggCastResult
	{
		Success,
		Failure,
		Abort
	}
	internal enum UnaryOperatorSignatureFindResult
	{
		Match,
		Continue,
		Return
	}
	internal enum UnaOpKind
	{
		Plus,
		Minus,
		Tilde,
		Bang,
		IncDec,
		Lim
	}
	[Flags]
	internal enum UnaOpMask
	{
		None = 0,
		Plus = 1,
		Minus = 2,
		Tilde = 4,
		Bang = 8,
		IncDec = 0x10,
		Signed = 7,
		Unsigned = 5,
		Real = 3,
		Bool = 8
	}
	[Flags]
	internal enum OpSigFlags
	{
		None = 0,
		Convert = 1,
		CanLift = 2,
		AutoLift = 4,
		Value = 7,
		Reference = 1,
		BoolBit = 3
	}
	[Flags]
	internal enum LiftFlags
	{
		None = 0,
		Lift1 = 1,
		Lift2 = 2,
		Convert1 = 4,
		Convert2 = 8
	}
	internal enum CheckLvalueKind
	{
		Assignment,
		Increment
	}
	internal enum BinOpFuncKind
	{
		BoolBinOp,
		BoolBitwiseOp,
		DecBinOp,
		DelBinOp,
		EnumBinOp,
		IntBinOp,
		RealBinOp,
		RefCmpOp,
		ShiftOp,
		StrBinOp,
		StrCmpOp,
		None
	}
	internal enum UnaOpFuncKind
	{
		BoolUnaOp,
		DecUnaOp,
		EnumUnaOp,
		IntUnaOp,
		RealUnaOp,
		LiftedIncOpCore,
		None
	}
	internal enum ExpressionKind
	{
		NoOp = 0,
		BinaryOp = 1,
		UnaryOp = 2,
		Assignment = 3,
		List = 4,
		ArrayIndex = 5,
		Call = 6,
		Field = 7,
		Local = 8,
		Constant = 9,
		Class = 10,
		Property = 11,
		Multi = 12,
		MultiGet = 13,
		Wrap = 14,
		Concat = 15,
		ArrayInit = 16,
		Cast = 17,
		UserDefinedConversion = 18,
		TypeOf = 19,
		ZeroInit = 20,
		UserLogicalOp = 21,
		MemberGroup = 22,
		BoundLambda = 23,
		FieldInfo = 24,
		MethodInfo = 25,
		PropertyInfo = 26,
		NamedArgumentSpecification = 27,
		ExpressionKindCount = 28,
		EqualsParam = 29,
		FirstOp = 29,
		Compare = 30,
		True = 31,
		False = 32,
		Inc = 33,
		Dec = 34,
		LogicalNot = 35,
		Eq = 36,
		RelationalMin = 36,
		NotEq = 37,
		LessThan = 38,
		LessThanOrEqual = 39,
		GreaterThan = 40,
		GreaterThanOrEqual = 41,
		RelationalMax = 41,
		Add = 42,
		Subtract = 43,
		Multiply = 44,
		Divide = 45,
		Modulo = 46,
		Negate = 47,
		UnaryPlus = 48,
		BitwiseAnd = 49,
		BitwiseOr = 50,
		BitwiseExclusiveOr = 51,
		BitwiseNot = 52,
		LeftShirt = 53,
		RightShift = 54,
		LogicalAnd = 55,
		LogicalOr = 56,
		Sequence = 57,
		Save = 58,
		Swap = 59,
		Indir = 60,
		Addr = 61,
		StringEq = 62,
		StringNotEq = 63,
		DelegateEq = 64,
		DelegateNotEq = 65,
		DelegateAdd = 66,
		DelegateSubtract = 67,
		DecimalNegate = 68,
		DecimalInc = 69,
		DecimalDec = 70,
		MultiOffset = 71,
		TypeLimit = 28
	}
	internal static class ExpressionKindExtensions
	{
		public static bool IsRelational(this ExpressionKind kind)
		{
			if (ExpressionKind.Eq <= kind)
			{
				return kind <= ExpressionKind.GreaterThanOrEqual;
			}
			return false;
		}

		public static bool IsUnaryOperator(this ExpressionKind kind)
		{
			switch (kind)
			{
			case ExpressionKind.True:
			case ExpressionKind.False:
			case ExpressionKind.Inc:
			case ExpressionKind.Dec:
			case ExpressionKind.LogicalNot:
			case ExpressionKind.Negate:
			case ExpressionKind.UnaryPlus:
			case ExpressionKind.BitwiseNot:
			case ExpressionKind.Addr:
			case ExpressionKind.DecimalNegate:
			case ExpressionKind.DecimalInc:
			case ExpressionKind.DecimalDec:
				return true;
			default:
				return false;
			}
		}
	}
	internal enum FUNDTYPE
	{
		FT_NONE = 0,
		FT_I1 = 1,
		FT_I2 = 2,
		FT_I4 = 3,
		FT_U1 = 4,
		FT_U2 = 5,
		FT_U4 = 6,
		FT_LASTNONLONG = 6,
		FT_I8 = 7,
		FT_U8 = 8,
		FT_LASTINTEGRAL = 8,
		FT_R4 = 9,
		FT_R8 = 10,
		FT_LASTNUMERIC = 10,
		FT_REF = 11,
		FT_STRUCT = 12,
		FT_PTR = 13,
		FT_VAR = 14,
		FT_COUNT = 15
	}
	[Flags]
	internal enum MemLookFlags : uint
	{
		None = 0u,
		Ctor = 2u,
		NewObj = 0x10u,
		Operator = 8u,
		Indexer = 4u,
		UserCallable = 0x100u,
		BaseCall = 0x40u,
		MustBeInvocable = 0x20000000u,
		All = 0x2000015Eu
	}
	internal sealed class MemberLookup
	{
		private CType _typeSrc;

		private CType _typeQual;

		private ParentSymbol _symWhere;

		private Name _name;

		private int _arity;

		private MemLookFlags _flags;

		private readonly List<AggregateType> _rgtypeStart;

		private List<AggregateType> _prgtype;

		private int _csym;

		private readonly SymWithType _swtFirst;

		private readonly List<MethPropWithType> _methPropWithTypeList;

		private readonly SymWithType _swtAmbig;

		private readonly SymWithType _swtInaccess;

		private readonly SymWithType _swtBad;

		private readonly SymWithType _swtBogus;

		private readonly SymWithType _swtBadArity;

		private bool _fMulti;

		private void RecordType(AggregateType type, Symbol sym)
		{
			if (!_prgtype.Contains(type))
			{
				_prgtype.Add(type);
			}
			_csym++;
			if (_swtFirst == null)
			{
				_swtFirst.Set(sym, type);
				_fMulti = sym is MethodSymbol || sym is IndexerSymbol;
			}
		}

		private bool SearchSingleType(AggregateType typeCur, out bool pfHideByName)
		{
			bool result = false;
			pfHideByName = false;
			bool flag = !CSemanticChecker.CheckTypeAccess(typeCur, _symWhere);
			if (flag && (_csym != 0 || _swtInaccess != null))
			{
				return false;
			}
			Symbol symbol = SymbolLoader.LookupAggMember(_name, typeCur.OwningAggregate, symbmask_t.MASK_Member);
			while (true)
			{
				if (symbol != null)
				{
					if (_arity > 0 && (!(symbol is MethodSymbol methodSymbol) || methodSymbol.typeVars.Count != _arity))
					{
						if (!_swtBadArity)
						{
							_swtBadArity.Set(symbol, typeCur);
						}
					}
					else if (!symbol.IsOverride() || symbol.IsHideByName())
					{
						MethodOrPropertySymbol methodOrPropertySymbol = symbol as MethodOrPropertySymbol;
						MethodSymbol methodSymbol2 = symbol as MethodSymbol;
						if (methodOrPropertySymbol != null && (_flags & MemLookFlags.UserCallable) != MemLookFlags.None && !methodOrPropertySymbol.isUserCallable() && (methodSymbol2 == null || !methodSymbol2.isPropertyAccessor() || ((!symbol.name.Text.StartsWith("set_", StringComparison.Ordinal) || methodSymbol2.Params.Count <= 1) && (!symbol.name.Text.StartsWith("get_", StringComparison.Ordinal) || methodSymbol2.Params.Count <= 0))))
						{
							if (!_swtInaccess)
							{
								_swtInaccess.Set(symbol, typeCur);
							}
						}
						else if (flag || !CSemanticChecker.CheckAccess(symbol, typeCur, _symWhere, _typeQual))
						{
							if (!_swtInaccess)
							{
								_swtInaccess.Set(symbol, typeCur);
							}
							if (flag)
							{
								return false;
							}
						}
						else
						{
							PropertySymbol propertySymbol = symbol as PropertySymbol;
							if ((_flags & MemLookFlags.Ctor) == 0 != (methodSymbol2 == null || !methodSymbol2.IsConstructor()) || (_flags & MemLookFlags.Operator) == 0 != (methodSymbol2 == null || !methodSymbol2.isOperator) || (_flags & MemLookFlags.Indexer) == 0 != !(propertySymbol is IndexerSymbol))
							{
								if (!_swtBad)
								{
									_swtBad.Set(symbol, typeCur);
								}
							}
							else if (!(symbol is MethodSymbol) && (_flags & MemLookFlags.Indexer) == 0 && CSemanticChecker.CheckBogus(symbol))
							{
								if (!_swtBogus)
								{
									_swtBogus.Set(symbol, typeCur);
								}
							}
							else if ((_flags & MemLookFlags.MustBeInvocable) != MemLookFlags.None && ((symbol is FieldSymbol fieldSymbol && !IsDelegateType(fieldSymbol.GetType(), typeCur) && !IsDynamicMember(symbol)) || (propertySymbol != null && !IsDelegateType(propertySymbol.RetType, typeCur) && !IsDynamicMember(symbol))))
							{
								if (!_swtBad)
								{
									_swtBad.Set(symbol, typeCur);
								}
							}
							else
							{
								if (methodOrPropertySymbol != null)
								{
									MethPropWithType item = new MethPropWithType(methodOrPropertySymbol, typeCur);
									_methPropWithTypeList.Add(item);
								}
								result = true;
								if ((bool)_swtFirst)
								{
									if (!typeCur.IsInterfaceType)
									{
										if (!_fMulti)
										{
											if ((!(_swtFirst.Sym is FieldSymbol) || !(symbol is EventSymbol) || !_swtFirst.Field().isEvent) && (!(_swtFirst.Sym is FieldSymbol) || !(symbol is EventSymbol)))
											{
												break;
											}
											goto IL_040f;
										}
										if (_swtFirst.Sym.getKind() != symbol.getKind())
										{
											if (typeCur == _prgtype[0])
											{
												break;
											}
											pfHideByName = true;
											goto IL_040f;
										}
									}
									else if (!_fMulti)
									{
										if (!(symbol is MethodSymbol))
										{
											break;
										}
										_prgtype = new List<AggregateType>();
										_csym = 0;
										_swtFirst.Clear();
										_swtAmbig.Clear();
									}
									else if (_swtFirst.Sym.getKind() != symbol.getKind())
									{
										if (!typeCur.DiffHidden && !(_swtFirst.Sym is MethodSymbol))
										{
											break;
										}
										pfHideByName = true;
										goto IL_040f;
									}
								}
								RecordType(typeCur, symbol);
								if (methodOrPropertySymbol != null && methodOrPropertySymbol.isHideByName)
								{
									pfHideByName = true;
								}
							}
						}
					}
					goto IL_040f;
				}
				return result;
				IL_040f:
				symbol = symbol.LookupNext(symbmask_t.MASK_Member);
			}
			if (!_swtAmbig)
			{
				_swtAmbig.Set(symbol, typeCur);
			}
			pfHideByName = true;
			return true;
		}

		private static bool IsDynamicMember(Symbol sym)
		{
			DynamicAttribute dynamicAttribute = null;
			if (sym is FieldSymbol fieldSymbol)
			{
				if (!fieldSymbol.getType().IsPredefType(PredefinedType.PT_OBJECT))
				{
					return false;
				}
				object[] array = fieldSymbol.AssociatedFieldInfo.GetCustomAttributes(typeof(DynamicAttribute), inherit: false).ToArray();
				if (array.Length == 1)
				{
					dynamicAttribute = array[0] as DynamicAttribute;
				}
			}
			else
			{
				PropertySymbol propertySymbol = (PropertySymbol)sym;
				if (!propertySymbol.getType().IsPredefType(PredefinedType.PT_OBJECT))
				{
					return false;
				}
				object[] array2 = propertySymbol.AssociatedPropertyInfo.GetCustomAttributes(typeof(DynamicAttribute), inherit: false).ToArray();
				if (array2.Length == 1)
				{
					dynamicAttribute = array2[0] as DynamicAttribute;
				}
			}
			if (dynamicAttribute == null)
			{
				return false;
			}
			if (dynamicAttribute.TransformFlags.Count != 0)
			{
				if (dynamicAttribute.TransformFlags.Count == 1)
				{
					return dynamicAttribute.TransformFlags[0];
				}
				return false;
			}
			return true;
		}

		private bool LookupInClass(AggregateType typeStart, ref AggregateType ptypeEnd)
		{
			AggregateType aggregateType = ptypeEnd;
			AggregateType aggregateType2 = typeStart;
			while (aggregateType2 != aggregateType && aggregateType2 != null)
			{
				SearchSingleType(aggregateType2, out var pfHideByName);
				if ((bool)_swtFirst && !_fMulti)
				{
					return false;
				}
				if (pfHideByName)
				{
					ptypeEnd = null;
					return true;
				}
				if ((_flags & MemLookFlags.Ctor) != MemLookFlags.None)
				{
					return false;
				}
				aggregateType2 = aggregateType2.BaseClass;
			}
			return true;
		}

		private bool LookupInInterfaces(AggregateType typeStart, TypeArray types)
		{
			if (typeStart != null)
			{
				typeStart.AllHidden = false;
				typeStart.DiffHidden = _swtFirst != null;
			}
			for (int i = 0; i < types.Count; i++)
			{
				AggregateType obj = (AggregateType)types[i];
				obj.AllHidden = false;
				obj.DiffHidden = _swtFirst;
			}
			bool flag = false;
			AggregateType aggregateType = typeStart;
			int num = 0;
			if (aggregateType == null)
			{
				aggregateType = (AggregateType)types[num++];
			}
			while (true)
			{
				if (!aggregateType.AllHidden && SearchSingleType(aggregateType, out var pfHideByName))
				{
					pfHideByName |= !_fMulti;
					CType[] items = aggregateType.IfacesAll.Items;
					for (int j = 0; j < items.Length; j++)
					{
						AggregateType aggregateType2 = (AggregateType)items[j];
						if (pfHideByName)
						{
							aggregateType2.AllHidden = true;
						}
						aggregateType2.DiffHidden = true;
					}
					if (pfHideByName)
					{
						flag = true;
					}
				}
				if (num >= types.Count)
				{
					break;
				}
				aggregateType = types[num++] as AggregateType;
			}
			return !flag;
		}

		private static RuntimeBinderException ReportBogus(SymWithType swt)
		{
			MethodSymbol getterMethod = swt.Prop().GetterMethod;
			MethodSymbol setterMethod = swt.Prop().SetterMethod;
			if (!(getterMethod == null || setterMethod == null))
			{
				return ErrorHandling.Error(ErrorCode.ERR_BindToBogusProp2, swt.Sym.name, new SymWithType(getterMethod, swt.GetType()), new SymWithType(setterMethod, swt.GetType()), new ErrArgRefOnly(swt.Sym));
			}
			return ErrorHandling.Error(ErrorCode.ERR_BindToBogusProp1, swt.Sym.name, new SymWithType(getterMethod ?? setterMethod, swt.GetType()), new ErrArgRefOnly(swt.Sym));
		}

		private static bool IsDelegateType(CType pSrcType, AggregateType pAggType)
		{
			return TypeManager.SubstType(pSrcType, pAggType, pAggType.TypeArgsAll).IsDelegateType;
		}

		public MemberLookup()
		{
			_methPropWithTypeList = new List<MethPropWithType>();
			_rgtypeStart = new List<AggregateType>();
			_swtFirst = new SymWithType();
			_swtAmbig = new SymWithType();
			_swtInaccess = new SymWithType();
			_swtBad = new SymWithType();
			_swtBogus = new SymWithType();
			_swtBadArity = new SymWithType();
		}

		public bool Lookup(CType typeSrc, Expr obj, ParentSymbol symWhere, Name name, int arity, MemLookFlags flags)
		{
			_prgtype = _rgtypeStart;
			_typeSrc = typeSrc;
			_symWhere = symWhere;
			_name = name;
			_arity = arity;
			_flags = flags;
			_typeQual = (((_flags & MemLookFlags.Ctor) != MemLookFlags.None) ? _typeSrc : obj?.Type);
			AggregateType aggregateType;
			AggregateType aggregateType2;
			TypeArray typeArray;
			if (typeSrc.IsInterfaceType)
			{
				aggregateType = null;
				aggregateType2 = (AggregateType)typeSrc;
				typeArray = aggregateType2.IfacesAll;
			}
			else
			{
				aggregateType = (AggregateType)typeSrc;
				aggregateType2 = null;
				typeArray = (aggregateType.IsWindowsRuntimeType ? aggregateType.WinRTCollectionIfacesAll : TypeArray.Empty);
			}
			AggregateType ptypeEnd = ((aggregateType2 != null || typeArray.Count > 0) ? SymbolLoader.GetPredefindType(PredefinedType.PT_OBJECT) : null);
			if ((aggregateType == null || LookupInClass(aggregateType, ref ptypeEnd)) && (aggregateType2 != null || typeArray.Count > 0) && LookupInInterfaces(aggregateType2, typeArray) && ptypeEnd != null)
			{
				AggregateType ptypeEnd2 = null;
				LookupInClass(ptypeEnd, ref ptypeEnd2);
			}
			return !FError();
		}

		private bool FError()
		{
			if ((bool)_swtFirst)
			{
				return _swtAmbig;
			}
			return true;
		}

		public SymWithType SwtFirst()
		{
			return _swtFirst;
		}

		public Exception ReportErrors()
		{
			if ((bool)_swtFirst)
			{
				return ErrorHandling.Error(ErrorCode.ERR_AmbigMember, _swtFirst, _swtAmbig);
			}
			if ((bool)_swtInaccess)
			{
				if (_swtInaccess.Sym.isUserCallable() || (_flags & MemLookFlags.UserCallable) == 0)
				{
					return CSemanticChecker.ReportAccessError(_swtInaccess, _symWhere, _typeQual);
				}
				return ErrorHandling.Error(ErrorCode.ERR_CantCallSpecialMethod, _swtInaccess);
			}
			if ((_flags & MemLookFlags.Ctor) != MemLookFlags.None)
			{
				if (_arity <= 0)
				{
					return ErrorHandling.Error(ErrorCode.ERR_NoConstructors, ((AggregateType)_typeSrc).OwningAggregate);
				}
				return ErrorHandling.Error(ErrorCode.ERR_BadCtorArgCount, ((AggregateType)_typeSrc).OwningAggregate, _arity);
			}
			if ((_flags & MemLookFlags.Operator) != MemLookFlags.None)
			{
				return ErrorHandling.Error(ErrorCode.ERR_NoSuchMember, _typeSrc, _name);
			}
			if ((_flags & MemLookFlags.Indexer) != MemLookFlags.None)
			{
				return ErrorHandling.Error(ErrorCode.ERR_BadIndexLHS, _typeSrc);
			}
			if ((bool)_swtBad)
			{
				return ErrorHandling.Error(((_flags & MemLookFlags.MustBeInvocable) != MemLookFlags.None) ? ErrorCode.ERR_NonInvocableMemberCalled : ErrorCode.ERR_CantCallSpecialMethod, _swtBad);
			}
			if ((bool)_swtBogus)
			{
				return ReportBogus(_swtBogus);
			}
			if ((bool)_swtBadArity)
			{
				if (_swtBadArity.Sym is MethodSymbol methodSymbol)
				{
					int count = methodSymbol.typeVars.Count;
					return ErrorHandling.Error((count > 0) ? ErrorCode.ERR_BadArity : ErrorCode.ERR_HasNoTypeVars, _swtBadArity, new ErrArgSymKind(_swtBadArity.Sym), count);
				}
				return ErrorHandling.Error(ErrorCode.ERR_TypeArgsNotAllowed, _swtBadArity, new ErrArgSymKind(_swtBadArity.Sym));
			}
			return ErrorHandling.Error(ErrorCode.ERR_NoSuchMember, _typeSrc, _name);
		}
	}
	internal class CMemberLookupResults
	{
		public class CMethodIterator
		{
			private readonly AggregateSymbol _context;

			private readonly TypeArray _containingTypes;

			private readonly CType _qualifyingType;

			private readonly Name _name;

			private readonly int _arity;

			private readonly symbmask_t _mask;

			private readonly EXPRFLAG _flags;

			private readonly ArgInfos _nonTrailingNamedArguments;

			private int _currentTypeIndex;

			public MethodOrPropertySymbol CurrentSymbol { get; private set; }

			public AggregateType CurrentType { get; private set; }

			public bool IsCurrentSymbolInaccessible { get; private set; }

			public bool IsCurrentSymbolBogus { get; private set; }

			public bool IsCurrentSymbolMisnamed { get; private set; }

			public bool AtEnd => CurrentSymbol == null;

			public bool CanUseCurrentSymbol
			{
				get
				{
					if ((_mask == symbmask_t.MASK_MethodSymbol && ((_flags & EXPRFLAG.EXF_CTOR) == 0 != !((MethodSymbol)CurrentSymbol).IsConstructor() || (_flags & EXPRFLAG.EXF_OPERATOR) == 0 != !((MethodSymbol)CurrentSymbol).isOperator)) || (_mask == symbmask_t.MASK_PropertySymbol && !(CurrentSymbol is IndexerSymbol)))
					{
						return false;
					}
					if (((_arity > 0) & (_mask == symbmask_t.MASK_MethodSymbol)) && ((MethodSymbol)CurrentSymbol).typeVars.Count != _arity)
					{
						return false;
					}
					if (!ExpressionBinder.IsMethPropCallable(CurrentSymbol, (_flags & EXPRFLAG.EXF_USERCALLABLE) != 0))
					{
						return false;
					}
					IsCurrentSymbolInaccessible = !CSemanticChecker.CheckAccess(CurrentSymbol, CurrentType, _context, _qualifyingType);
					IsCurrentSymbolBogus = CSemanticChecker.CheckBogus(CurrentSymbol);
					IsCurrentSymbolMisnamed = CheckArgumentNames();
					return true;
				}
			}

			public CMethodIterator(Name name, TypeArray containingTypes, CType qualifyingType, AggregateSymbol context, int arity, EXPRFLAG flags, symbmask_t mask, ArgInfos nonTrailingNamedArguments)
			{
				_name = name;
				_containingTypes = containingTypes;
				_qualifyingType = qualifyingType;
				_context = context;
				_arity = arity;
				_flags = flags;
				_mask = mask;
				_nonTrailingNamedArguments = nonTrailingNamedArguments;
			}

			public bool MoveNext()
			{
				if (CurrentType != null || FindNextTypeForInstanceMethods())
				{
					return FindNextMethod();
				}
				return false;
			}

			private bool CheckArgumentNames()
			{
				ArgInfos nonTrailingNamedArguments = _nonTrailingNamedArguments;
				if (nonTrailingNamedArguments != null)
				{
					List<Name> parameterNames = ExpressionBinder.GroupToArgsBinder.FindMostDerivedMethod(CurrentSymbol, _qualifyingType).ParameterNames;
					List<Expr> prgexpr = nonTrailingNamedArguments.prgexpr;
					for (int i = 0; i < nonTrailingNamedArguments.carg; i++)
					{
						if (prgexpr[i] is ExprNamedArgumentSpecification exprNamedArgumentSpecification && (parameterNames[i] != exprNamedArgumentSpecification.Name || (i == parameterNames.Count - 1 && i != nonTrailingNamedArguments.carg - 1)))
						{
							return true;
						}
					}
				}
				return false;
			}

			private bool FindNextMethod()
			{
				while (true)
				{
					CurrentSymbol = ((CurrentSymbol == null) ? SymbolLoader.LookupAggMember(_name, CurrentType.OwningAggregate, _mask) : CurrentSymbol.LookupNext(_mask)) as MethodOrPropertySymbol;
					if (CurrentSymbol != null)
					{
						break;
					}
					if (!FindNextTypeForInstanceMethods())
					{
						return false;
					}
				}
				return true;
			}

			private bool FindNextTypeForInstanceMethods()
			{
				if (_currentTypeIndex >= _containingTypes.Count)
				{
					CurrentType = null;
					return false;
				}
				CurrentType = _containingTypes[_currentTypeIndex++] as AggregateType;
				return true;
			}
		}

		private readonly Name _pName;

		private TypeArray ContainingTypes { get; }

		public CMemberLookupResults(TypeArray containingTypes, Name name)
		{
			_pName = name;
			ContainingTypes = containingTypes;
		}

		public CMethodIterator GetMethodIterator(CType qualifyingType, AggregateSymbol context, int arity, EXPRFLAG flags, symbmask_t mask, ArgInfos nonTrailingNamedArguments)
		{
			return new CMethodIterator(_pName, ContainingTypes, qualifyingType, context, arity, flags, mask, nonTrailingNamedArguments);
		}
	}
	internal enum MethodKindEnum
	{
		None,
		Constructor,
		Destructor,
		PropAccessor,
		EventAccessor,
		ExplicitConv,
		ImplicitConv,
		Anonymous,
		Invoke,
		BeginInvoke,
		EndInvoke,
		AnonymousTypeToString,
		AnonymousTypeEquals,
		AnonymousTypeGetHashCode,
		IteratorDispose,
		IteratorReset,
		IteratorGetEnumerator,
		IteratorGetEnumeratorDelegating,
		IteratorMoveNext,
		Latent,
		Actual,
		IteratorFinally
	}
	internal sealed class MethodTypeInferrer
	{
		private enum NewInferenceResult
		{
			InferenceFailed,
			MadeProgress,
			NoProgress,
			Success
		}

		[Flags]
		private enum Dependency
		{
			Unknown = 0,
			NotDependent = 1,
			DependsMask = 0x10,
			Indirect = 0x12
		}

		private readonly ExpressionBinder _binder;

		private readonly TypeArray _pMethodTypeParameters;

		private readonly TypeArray _pMethodFormalParameterTypes;

		private readonly ArgInfos _pMethodArguments;

		private readonly List<CType>[] _pExactBounds;

		private readonly List<CType>[] _pUpperBounds;

		private readonly List<CType>[] _pLowerBounds;

		private readonly CType[] _pFixedResults;

		private Dependency[][] _ppDependencies;

		private bool _dependenciesDirty;

		public static bool Infer(ExpressionBinder binder, MethodSymbol pMethod, TypeArray pMethodFormalParameterTypes, ArgInfos pMethodArguments, out TypeArray ppInferredTypeArguments)
		{
			ppInferredTypeArguments = null;
			if (pMethodFormalParameterTypes.Count == 0 || pMethod.InferenceMustFail())
			{
				return false;
			}
			MethodTypeInferrer methodTypeInferrer = new MethodTypeInferrer(binder, pMethodFormalParameterTypes, pMethodArguments, pMethod.typeVars);
			bool result = methodTypeInferrer.InferTypeArgs();
			ppInferredTypeArguments = methodTypeInferrer.GetResults();
			return result;
		}

		private MethodTypeInferrer(ExpressionBinder exprBinder, TypeArray pMethodFormalParameterTypes, ArgInfos pMethodArguments, TypeArray pMethodTypeParameters)
		{
			_binder = exprBinder;
			_pMethodFormalParameterTypes = pMethodFormalParameterTypes;
			_pMethodArguments = pMethodArguments;
			_pMethodTypeParameters = pMethodTypeParameters;
			_pFixedResults = new CType[pMethodTypeParameters.Count];
			_pLowerBounds = new List<CType>[pMethodTypeParameters.Count];
			_pUpperBounds = new List<CType>[pMethodTypeParameters.Count];
			_pExactBounds = new List<CType>[pMethodTypeParameters.Count];
			for (int i = 0; i < pMethodTypeParameters.Count; i++)
			{
				_pLowerBounds[i] = new List<CType>();
				_pUpperBounds[i] = new List<CType>();
				_pExactBounds[i] = new List<CType>();
			}
			_ppDependencies = null;
		}

		private TypeArray GetResults()
		{
			return TypeArray.Allocate(_pFixedResults);
		}

		private bool IsUnfixed(int iParam)
		{
			return _pFixedResults[iParam] == null;
		}

		private bool IsUnfixed(TypeParameterType pParam)
		{
			int indexInTotalParameters = pParam.IndexInTotalParameters;
			return IsUnfixed(indexInTotalParameters);
		}

		private bool AllFixed()
		{
			for (int i = 0; i < _pMethodTypeParameters.Count; i++)
			{
				if (IsUnfixed(i))
				{
					return false;
				}
			}
			return true;
		}

		private void AddLowerBound(TypeParameterType pParam, CType pBound)
		{
			int indexInTotalParameters = pParam.IndexInTotalParameters;
			if (!_pLowerBounds[indexInTotalParameters].Contains(pBound))
			{
				_pLowerBounds[indexInTotalParameters].Add(pBound);
			}
		}

		private void AddUpperBound(TypeParameterType pParam, CType pBound)
		{
			int indexInTotalParameters = pParam.IndexInTotalParameters;
			if (!_pUpperBounds[indexInTotalParameters].Contains(pBound))
			{
				_pUpperBounds[indexInTotalParameters].Add(pBound);
			}
		}

		private void AddExactBound(TypeParameterType pParam, CType pBound)
		{
			int indexInTotalParameters = pParam.IndexInTotalParameters;
			if (!_pExactBounds[indexInTotalParameters].Contains(pBound))
			{
				_pExactBounds[indexInTotalParameters].Add(pBound);
			}
		}

		private bool HasBound(int iParam)
		{
			if (_pLowerBounds[iParam].IsEmpty() && _pExactBounds[iParam].IsEmpty())
			{
				return !_pUpperBounds[iParam].IsEmpty();
			}
			return true;
		}

		private bool InferTypeArgs()
		{
			InferTypeArgsFirstPhase();
			return InferTypeArgsSecondPhase();
		}

		private static bool IsReallyAType(CType pType)
		{
			if (!(pType is NullType) && !(pType is VoidType))
			{
				return !(pType is MethodGroupType);
			}
			return false;
		}

		private void InferTypeArgsFirstPhase()
		{
			for (int i = 0; i < _pMethodArguments.carg; i++)
			{
				Expr expr = _pMethodArguments.prgexpr[i];
				if (expr.IsOptionalArgument)
				{
					continue;
				}
				CType cType = _pMethodFormalParameterTypes[i];
				CType cType2 = expr.RuntimeObjectActualType ?? _pMethodArguments.types[i];
				bool flag = false;
				if (cType is ParameterModifierType parameterModifierType)
				{
					cType = parameterModifierType.ParameterType;
					flag = true;
				}
				if (cType2 is ParameterModifierType parameterModifierType2)
				{
					cType2 = parameterModifierType2.ParameterType;
				}
				if (IsReallyAType(cType2))
				{
					if (flag)
					{
						ExactInference(cType2, cType);
					}
					else
					{
						LowerBoundInference(cType2, cType);
					}
				}
			}
		}

		private bool InferTypeArgsSecondPhase()
		{
			InitializeDependencies();
			while (true)
			{
				switch (DoSecondPhase())
				{
				case NewInferenceResult.InferenceFailed:
					return false;
				case NewInferenceResult.Success:
					return true;
				}
			}
		}

		private NewInferenceResult DoSecondPhase()
		{
			if (AllFixed())
			{
				return NewInferenceResult.Success;
			}
			NewInferenceResult newInferenceResult = FixNondependentParameters();
			if (newInferenceResult != NewInferenceResult.NoProgress)
			{
				return newInferenceResult;
			}
			newInferenceResult = FixDependentParameters();
			if (newInferenceResult != NewInferenceResult.NoProgress)
			{
				return newInferenceResult;
			}
			return NewInferenceResult.InferenceFailed;
		}

		private NewInferenceResult FixNondependentParameters()
		{
			bool[] array = new bool[_pMethodTypeParameters.Count];
			NewInferenceResult result = NewInferenceResult.NoProgress;
			for (int i = 0; i < _pMethodTypeParameters.Count; i++)
			{
				if (IsUnfixed(i) && HasBound(i) && !DependsOnAny(i))
				{
					array[i] = true;
					result = NewInferenceResult.MadeProgress;
				}
			}
			for (int i = 0; i < _pMethodTypeParameters.Count; i++)
			{
				if (array[i] && !Fix(i))
				{
					result = NewInferenceResult.InferenceFailed;
				}
			}
			return result;
		}

		private NewInferenceResult FixDependentParameters()
		{
			bool[] array = new bool[_pMethodTypeParameters.Count];
			NewInferenceResult result = NewInferenceResult.NoProgress;
			for (int i = 0; i < _pMethodTypeParameters.Count; i++)
			{
				if (IsUnfixed(i) && HasBound(i) && AnyDependsOn(i))
				{
					array[i] = true;
					result = NewInferenceResult.MadeProgress;
				}
			}
			for (int i = 0; i < _pMethodTypeParameters.Count; i++)
			{
				if (array[i] && !Fix(i))
				{
					result = NewInferenceResult.InferenceFailed;
				}
			}
			return result;
		}

		private void InitializeDependencies()
		{
			_ppDependencies = new Dependency[_pMethodTypeParameters.Count][];
			for (int i = 0; i < _pMethodTypeParameters.Count; i++)
			{
				_ppDependencies[i] = new Dependency[_pMethodTypeParameters.Count];
			}
			DeduceAllDependencies();
		}

		private bool DependsOn(int iParam, int jParam)
		{
			if (_dependenciesDirty)
			{
				SetIndirectsToUnknown();
				DeduceAllDependencies();
			}
			return (_ppDependencies[iParam][jParam] & Dependency.DependsMask) != 0;
		}

		private bool DependsTransitivelyOn(int iParam, int jParam)
		{
			for (int i = 0; i < _pMethodTypeParameters.Count; i++)
			{
				if ((_ppDependencies[iParam][i] & Dependency.DependsMask) != Dependency.Unknown && (_ppDependencies[i][jParam] & Dependency.DependsMask) != Dependency.Unknown)
				{
					return true;
				}
			}
			return false;
		}

		private void DeduceAllDependencies()
		{
			while (DeduceDependencies())
			{
			}
			SetUnknownsToNotDependent();
			_dependenciesDirty = false;
		}

		private bool DeduceDependencies()
		{
			bool result = false;
			for (int i = 0; i < _pMethodTypeParameters.Count; i++)
			{
				for (int j = 0; j < _pMethodTypeParameters.Count; j++)
				{
					if (_ppDependencies[i][j] == Dependency.Unknown && DependsTransitivelyOn(i, j))
					{
						_ppDependencies[i][j] = Dependency.Indirect;
						result = true;
					}
				}
			}
			return result;
		}

		private void SetUnknownsToNotDependent()
		{
			for (int i = 0; i < _pMethodTypeParameters.Count; i++)
			{
				for (int j = 0; j < _pMethodTypeParameters.Count; j++)
				{
					if (_ppDependencies[i][j] == Dependency.Unknown)
					{
						_ppDependencies[i][j] = Dependency.NotDependent;
					}
				}
			}
		}

		private void SetIndirectsToUnknown()
		{
			for (int i = 0; i < _pMethodTypeParameters.Count; i++)
			{
				for (int j = 0; j < _pMethodTypeParameters.Count; j++)
				{
					if (_ppDependencies[i][j] == Dependency.Indirect)
					{
						_ppDependencies[i][j] = Dependency.Unknown;
					}
				}
			}
		}

		private void UpdateDependenciesAfterFix(int iParam)
		{
			if (_ppDependencies != null)
			{
				for (int i = 0; i < _pMethodTypeParameters.Count; i++)
				{
					_ppDependencies[iParam][i] = Dependency.NotDependent;
					_ppDependencies[i][iParam] = Dependency.NotDependent;
				}
				_dependenciesDirty = true;
			}
		}

		private bool DependsOnAny(int iParam)
		{
			for (int i = 0; i < _pMethodTypeParameters.Count; i++)
			{
				if (DependsOn(iParam, i))
				{
					return true;
				}
			}
			return false;
		}

		private bool AnyDependsOn(int iParam)
		{
			for (int i = 0; i < _pMethodTypeParameters.Count; i++)
			{
				if (DependsOn(i, iParam))
				{
					return true;
				}
			}
			return false;
		}

		private void ExactInference(CType pSource, CType pDest)
		{
			if (!ExactTypeParameterInference(pSource, pDest) && !ExactArrayInference(pSource, pDest) && !ExactNullableInference(pSource, pDest))
			{
				ExactConstructedInference(pSource, pDest);
			}
		}

		private bool ExactTypeParameterInference(CType pSource, CType pDest)
		{
			if (pDest is TypeParameterType { IsMethodTypeParameter: not false } typeParameterType && IsUnfixed(typeParameterType))
			{
				AddExactBound(typeParameterType, pSource);
				return true;
			}
			return false;
		}

		private bool ExactArrayInference(CType pSource, CType pDest)
		{
			if (!(pSource is ArrayType arrayType) || !(pDest is ArrayType arrayType2))
			{
				return false;
			}
			if (arrayType.Rank != arrayType2.Rank || arrayType.IsSZArray != arrayType2.IsSZArray)
			{
				return false;
			}
			ExactInference(arrayType.ElementType, arrayType2.ElementType);
			return true;
		}

		private bool ExactNullableInference(CType pSource, CType pDest)
		{
			if (!(pSource is NullableType nullableType) || !(pDest is NullableType nullableType2))
			{
				return false;
			}
			ExactInference(nullableType.UnderlyingType, nullableType2.UnderlyingType);
			return true;
		}

		private bool ExactConstructedInference(CType pSource, CType pDest)
		{
			if (!(pSource is AggregateType aggregateType) || !(pDest is AggregateType aggregateType2) || aggregateType.OwningAggregate != aggregateType2.OwningAggregate)
			{
				return false;
			}
			ExactTypeArgumentInference(aggregateType, aggregateType2);
			return true;
		}

		private void ExactTypeArgumentInference(AggregateType pSource, AggregateType pDest)
		{
			TypeArray typeArgsAll = pSource.TypeArgsAll;
			TypeArray typeArgsAll2 = pDest.TypeArgsAll;
			for (int i = 0; i < typeArgsAll.Count; i++)
			{
				ExactInference(typeArgsAll[i], typeArgsAll2[i]);
			}
		}

		private void LowerBoundInference(CType pSource, CType pDest)
		{
			if (!LowerBoundTypeParameterInference(pSource, pDest) && !LowerBoundArrayInference(pSource, pDest) && !ExactNullableInference(pSource, pDest))
			{
				LowerBoundConstructedInference(pSource, pDest);
			}
		}

		private bool LowerBoundTypeParameterInference(CType pSource, CType pDest)
		{
			if (pDest is TypeParameterType { IsMethodTypeParameter: not false } typeParameterType && IsUnfixed(typeParameterType))
			{
				AddLowerBound(typeParameterType, pSource);
				return true;
			}
			return false;
		}

		private bool LowerBoundArrayInference(CType pSource, CType pDest)
		{
			if (!(pSource is ArrayType { ElementType: var elementType } arrayType))
			{
				return false;
			}
			CType pDest2;
			if (pDest is ArrayType arrayType2)
			{
				if (arrayType2.Rank != arrayType.Rank || arrayType2.IsSZArray != arrayType.IsSZArray)
				{
					return false;
				}
				pDest2 = arrayType2.ElementType;
			}
			else
			{
				if (!pDest.IsPredefType(PredefinedType.PT_G_IENUMERABLE) && !pDest.IsPredefType(PredefinedType.PT_G_ICOLLECTION) && !pDest.IsPredefType(PredefinedType.PT_G_ILIST) && !pDest.IsPredefType(PredefinedType.PT_G_IREADONLYCOLLECTION) && !pDest.IsPredefType(PredefinedType.PT_G_IREADONLYLIST))
				{
					return false;
				}
				if (!arrayType.IsSZArray)
				{
					return false;
				}
				pDest2 = ((AggregateType)pDest).TypeArgsThis[0];
			}
			if (elementType.IsReferenceType)
			{
				LowerBoundInference(elementType, pDest2);
			}
			else
			{
				ExactInference(elementType, pDest2);
			}
			return true;
		}

		private bool LowerBoundConstructedInference(CType pSource, CType pDest)
		{
			if (!(pDest is AggregateType aggregateType))
			{
				return false;
			}
			if (aggregateType.TypeArgsAll.Count == 0)
			{
				return false;
			}
			if (pSource is AggregateType aggregateType2 && aggregateType2.OwningAggregate == aggregateType.OwningAggregate)
			{
				if (aggregateType2.IsInterfaceType || aggregateType2.IsDelegateType)
				{
					LowerBoundTypeArgumentInference(aggregateType2, aggregateType);
				}
				else
				{
					ExactTypeArgumentInference(aggregateType2, aggregateType);
				}
				return true;
			}
			if (LowerBoundClassInference(pSource, aggregateType))
			{
				return true;
			}
			if (LowerBoundInterfaceInference(pSource, aggregateType))
			{
				return true;
			}
			return false;
		}

		private bool LowerBoundClassInference(CType pSource, AggregateType pDest)
		{
			if (!pDest.IsClassType)
			{
				return false;
			}
			AggregateType aggregateType = null;
			if (pSource.IsClassType)
			{
				aggregateType = (pSource as AggregateType).BaseClass;
			}
			while (aggregateType != null)
			{
				if (aggregateType.OwningAggregate == pDest.OwningAggregate)
				{
					ExactTypeArgumentInference(aggregateType, pDest);
					return true;
				}
				aggregateType = aggregateType.BaseClass;
			}
			return false;
		}

		private bool LowerBoundInterfaceInference(CType pSource, AggregateType pDest)
		{
			if (!pDest.IsInterfaceType)
			{
				return false;
			}
			if (pSource is AggregateType aggregateType && (aggregateType.IsStructType || aggregateType.IsClassType || aggregateType.IsInterfaceType))
			{
				AggregateType aggregateType2 = null;
				CType[] items = aggregateType.IfacesAll.Items;
				for (int i = 0; i < items.Length; i++)
				{
					AggregateType aggregateType3 = (AggregateType)items[i];
					if (aggregateType3.OwningAggregate == pDest.OwningAggregate)
					{
						if (aggregateType2 == null)
						{
							aggregateType2 = aggregateType3;
						}
						else if (aggregateType2 != aggregateType3)
						{
							return false;
						}
					}
				}
				if (aggregateType2 != null)
				{
					LowerBoundTypeArgumentInference(aggregateType2, pDest);
					return true;
				}
			}
			return false;
		}

		private void LowerBoundTypeArgumentInference(AggregateType pSource, AggregateType pDest)
		{
			TypeArray typeVarsAll = pSource.OwningAggregate.GetTypeVarsAll();
			TypeArray typeArgsAll = pSource.TypeArgsAll;
			TypeArray typeArgsAll2 = pDest.TypeArgsAll;
			for (int i = 0; i < typeArgsAll.Count; i++)
			{
				TypeParameterType typeParameterType = (TypeParameterType)typeVarsAll[i];
				CType cType = typeArgsAll[i];
				CType pDest2 = typeArgsAll2[i];
				if (cType.IsReferenceType)
				{
					if (typeParameterType.Covariant)
					{
						LowerBoundInference(cType, pDest2);
						continue;
					}
					if (typeParameterType.Contravariant)
					{
						UpperBoundInference(typeArgsAll[i], typeArgsAll2[i]);
						continue;
					}
				}
				ExactInference(typeArgsAll[i], typeArgsAll2[i]);
			}
		}

		private void UpperBoundInference(CType pSource, CType pDest)
		{
			if (!UpperBoundTypeParameterInference(pSource, pDest) && !UpperBoundArrayInference(pSource, pDest) && !ExactNullableInference(pSource, pDest))
			{
				UpperBoundConstructedInference(pSource, pDest);
			}
		}

		private bool UpperBoundTypeParameterInference(CType pSource, CType pDest)
		{
			if (pDest is TypeParameterType { IsMethodTypeParameter: not false } typeParameterType && IsUnfixed(typeParameterType))
			{
				AddUpperBound(typeParameterType, pSource);
				return true;
			}
			return false;
		}

		private bool UpperBoundArrayInference(CType pSource, CType pDest)
		{
			if (!(pDest is ArrayType { ElementType: var elementType } arrayType))
			{
				return false;
			}
			CType cType;
			if (pSource is ArrayType arrayType2)
			{
				if (arrayType.Rank != arrayType2.Rank || arrayType.IsSZArray != arrayType2.IsSZArray)
				{
					return false;
				}
				cType = arrayType2.ElementType;
			}
			else
			{
				if (!pSource.IsPredefType(PredefinedType.PT_G_IENUMERABLE) && !pSource.IsPredefType(PredefinedType.PT_G_ICOLLECTION) && !pSource.IsPredefType(PredefinedType.PT_G_ILIST) && !pSource.IsPredefType(PredefinedType.PT_G_IREADONLYLIST) && !pSource.IsPredefType(PredefinedType.PT_G_IREADONLYCOLLECTION))
				{
					return false;
				}
				if (!arrayType.IsSZArray)
				{
					return false;
				}
				cType = ((AggregateType)pSource).TypeArgsThis[0];
			}
			if (cType.IsReferenceType)
			{
				UpperBoundInference(cType, elementType);
			}
			else
			{
				ExactInference(cType, elementType);
			}
			return true;
		}

		private bool UpperBoundConstructedInference(CType pSource, CType pDest)
		{
			if (!(pSource is AggregateType aggregateType))
			{
				return false;
			}
			if (aggregateType.TypeArgsAll.Count == 0)
			{
				return false;
			}
			if (pDest is AggregateType aggregateType2 && aggregateType.OwningAggregate == aggregateType2.OwningAggregate)
			{
				if (aggregateType2.IsInterfaceType || aggregateType2.IsDelegateType)
				{
					UpperBoundTypeArgumentInference(aggregateType, aggregateType2);
				}
				else
				{
					ExactTypeArgumentInference(aggregateType, aggregateType2);
				}
				return true;
			}
			if (UpperBoundClassInference(aggregateType, pDest))
			{
				return true;
			}
			if (UpperBoundInterfaceInference(aggregateType, pDest))
			{
				return true;
			}
			return false;
		}

		private bool UpperBoundClassInference(AggregateType pSource, CType pDest)
		{
			if (!pSource.IsClassType || !pDest.IsClassType)
			{
				return false;
			}
			for (AggregateType baseClass = ((AggregateType)pDest).BaseClass; baseClass != null; baseClass = baseClass.BaseClass)
			{
				if (baseClass.OwningAggregate == pSource.OwningAggregate)
				{
					ExactTypeArgumentInference(pSource, baseClass);
					return true;
				}
			}
			return false;
		}

		private bool UpperBoundInterfaceInference(AggregateType pSource, CType pDest)
		{
			if (!pSource.IsInterfaceType)
			{
				return false;
			}
			if (pDest is AggregateType aggregateType && (aggregateType.IsStructType || aggregateType.IsClassType || aggregateType.IsInterfaceType))
			{
				AggregateType aggregateType2 = null;
				CType[] items = aggregateType.IfacesAll.Items;
				for (int i = 0; i < items.Length; i++)
				{
					AggregateType aggregateType3 = (AggregateType)items[i];
					if (aggregateType3.OwningAggregate == pSource.OwningAggregate)
					{
						if (aggregateType2 == null)
						{
							aggregateType2 = aggregateType3;
						}
						else if (aggregateType2 != aggregateType3)
						{
							return false;
						}
					}
				}
				if (aggregateType2 != null)
				{
					UpperBoundTypeArgumentInference(aggregateType2, pDest as AggregateType);
					return true;
				}
			}
			return false;
		}

		private void UpperBoundTypeArgumentInference(AggregateType pSource, AggregateType pDest)
		{
			TypeArray typeVarsAll = pSource.OwningAggregate.GetTypeVarsAll();
			TypeArray typeArgsAll = pSource.TypeArgsAll;
			TypeArray typeArgsAll2 = pDest.TypeArgsAll;
			for (int i = 0; i < typeArgsAll.Count; i++)
			{
				TypeParameterType typeParameterType = (TypeParameterType)typeVarsAll[i];
				CType cType = typeArgsAll[i];
				CType pDest2 = typeArgsAll2[i];
				if (cType.IsReferenceType)
				{
					if (typeParameterType.Covariant)
					{
						UpperBoundInference(cType, pDest2);
						continue;
					}
					if (typeParameterType.Contravariant)
					{
						LowerBoundInference(typeArgsAll[i], typeArgsAll2[i]);
						continue;
					}
				}
				ExactInference(typeArgsAll[i], typeArgsAll2[i]);
			}
		}

		private bool Fix(int iParam)
		{
			if (_pExactBounds[iParam].Count >= 2)
			{
				return false;
			}
			List<CType> list = new List<CType>();
			if (_pExactBounds[iParam].IsEmpty())
			{
				HashSet<CType> hashSet = new HashSet<CType>();
				foreach (CType item in _pLowerBounds[iParam])
				{
					if (hashSet.Add(item))
					{
						list.Add(item);
					}
				}
				foreach (CType item2 in _pUpperBounds[iParam])
				{
					if (hashSet.Add(item2))
					{
						list.Add(item2);
					}
				}
			}
			else
			{
				list.Add(_pExactBounds[iParam].Head());
			}
			if (list.IsEmpty())
			{
				return false;
			}
			foreach (CType item3 in _pLowerBounds[iParam])
			{
				List<CType> list2 = new List<CType>();
				foreach (CType item4 in list)
				{
					if (item3 != item4 && !_binder.canConvert(item3, item4))
					{
						list2.Add(item4);
					}
				}
				foreach (CType item5 in list2)
				{
					list.Remove(item5);
				}
			}
			foreach (CType item6 in _pUpperBounds[iParam])
			{
				List<CType> list3 = new List<CType>();
				foreach (CType item7 in list)
				{
					if (item6 != item7 && !_binder.canConvert(item7, item6))
					{
						list3.Add(item7);
					}
				}
				foreach (CType item8 in list3)
				{
					list.Remove(item8);
				}
			}
			CType cType = null;
			foreach (CType item9 in list)
			{
				foreach (CType item10 in list)
				{
					if (item9 == item10 || _binder.canConvert(item10, item9))
					{
						continue;
					}
					goto IL_02bb;
				}
				if (cType != null)
				{
					return false;
				}
				cType = item9;
				IL_02bb:;
			}
			if (cType == null)
			{
				return false;
			}
			_pFixedResults[iParam] = TypeManager.GetBestAccessibleType(_binder.Context.ContextForMemberLookup, cType);
			UpdateDependenciesAfterFix(iParam);
			return true;
		}
	}
	internal enum NullableCallLiftKind
	{
		NotLifted,
		Operator,
		EqualityOperator,
		InequalityOperator,
		UserDefinedConversion,
		NullableConversion,
		NullableConversionConstructor,
		NullableIntermediateConversion,
		NotLiftedIntermediateConversion
	}
	internal enum PREDEFMETH
	{
		PM_DECIMAL_OPDECREMENT,
		PM_DECIMAL_OPINCREMENT,
		PM_DECIMAL_OPUNARYMINUS,
		PM_DELEGATE_COMBINE,
		PM_DELEGATE_OPEQUALITY,
		PM_DELEGATE_OPINEQUALITY,
		PM_DELEGATE_REMOVE,
		PM_EXPRESSION_ADD,
		PM_EXPRESSION_ADD_USER_DEFINED,
		PM_EXPRESSION_ADDCHECKED,
		PM_EXPRESSION_ADDCHECKED_USER_DEFINED,
		PM_EXPRESSION_AND,
		PM_EXPRESSION_AND_USER_DEFINED,
		PM_EXPRESSION_ANDALSO,
		PM_EXPRESSION_ANDALSO_USER_DEFINED,
		PM_EXPRESSION_ARRAYINDEX,
		PM_EXPRESSION_ARRAYINDEX2,
		PM_EXPRESSION_ASSIGN,
		PM_EXPRESSION_CONSTANT_OBJECT_TYPE,
		PM_EXPRESSION_CONVERT,
		PM_EXPRESSION_CONVERT_USER_DEFINED,
		PM_EXPRESSION_CONVERTCHECKED,
		PM_EXPRESSION_CONVERTCHECKED_USER_DEFINED,
		PM_EXPRESSION_DIVIDE,
		PM_EXPRESSION_DIVIDE_USER_DEFINED,
		PM_EXPRESSION_EQUAL,
		PM_EXPRESSION_EQUAL_USER_DEFINED,
		PM_EXPRESSION_EXCLUSIVEOR,
		PM_EXPRESSION_EXCLUSIVEOR_USER_DEFINED,
		PM_EXPRESSION_FIELD,
		PM_EXPRESSION_GREATERTHAN,
		PM_EXPRESSION_GREATERTHAN_USER_DEFINED,
		PM_EXPRESSION_GREATERTHANOREQUAL,
		PM_EXPRESSION_GREATERTHANOREQUAL_USER_DEFINED,
		PM_EXPRESSION_LAMBDA,
		PM_EXPRESSION_LEFTSHIFT,
		PM_EXPRESSION_LEFTSHIFT_USER_DEFINED,
		PM_EXPRESSION_LESSTHAN,
		PM_EXPRESSION_LESSTHAN_USER_DEFINED,
		PM_EXPRESSION_LESSTHANOREQUAL,
		PM_EXPRESSION_LESSTHANOREQUAL_USER_DEFINED,
		PM_EXPRESSION_MODULO,
		PM_EXPRESSION_MODULO_USER_DEFINED,
		PM_EXPRESSION_MULTIPLY,
		PM_EXPRESSION_MULTIPLY_USER_DEFINED,
		PM_EXPRESSION_MULTIPLYCHECKED,
		PM_EXPRESSION_MULTIPLYCHECKED_USER_DEFINED,
		PM_EXPRESSION_NOTEQUAL,
		PM_EXPRESSION_NOTEQUAL_USER_DEFINED,
		PM_EXPRESSION_OR,
		PM_EXPRESSION_OR_USER_DEFINED,
		PM_EXPRESSION_ORELSE,
		PM_EXPRESSION_ORELSE_USER_DEFINED,
		PM_EXPRESSION_PARAMETER,
		PM_EXPRESSION_RIGHTSHIFT,
		PM_EXPRESSION_RIGHTSHIFT_USER_DEFINED,
		PM_EXPRESSION_SUBTRACT,
		PM_EXPRESSION_SUBTRACT_USER_DEFINED,
		PM_EXPRESSION_SUBTRACTCHECKED,
		PM_EXPRESSION_SUBTRACTCHECKED_USER_DEFINED,
		PM_EXPRESSION_UNARYPLUS_USER_DEFINED,
		PM_EXPRESSION_NEGATE,
		PM_EXPRESSION_NEGATE_USER_DEFINED,
		PM_EXPRESSION_NEGATECHECKED,
		PM_EXPRESSION_NEGATECHECKED_USER_DEFINED,
		PM_EXPRESSION_CALL,
		PM_EXPRESSION_NEW,
		PM_EXPRESSION_NEW_TYPE,
		PM_EXPRESSION_QUOTE,
		PM_EXPRESSION_NOT,
		PM_EXPRESSION_NOT_USER_DEFINED,
		PM_EXPRESSION_NEWARRAYINIT,
		PM_EXPRESSION_PROPERTY,
		PM_EXPRESSION_INVOKE,
		PM_G_OPTIONAL_CTOR,
		PM_G_OPTIONAL_GETVALUE,
		PM_STRING_CONCAT_OBJECT_2,
		PM_STRING_CONCAT_OBJECT_3,
		PM_STRING_CONCAT_STRING_2,
		PM_STRING_OPEQUALITY,
		PM_STRING_OPINEQUALITY,
		PM_COUNT
	}
	internal enum PREDEFPROP
	{
		PP_G_OPTIONAL_VALUE,
		PP_COUNT
	}
	internal enum MethodCallingConventionEnum
	{
		Static,
		Virtual,
		Instance
	}
	internal enum MethodSignatureEnum
	{
		SIG_CLASS_TYVAR = 51,
		SIG_METH_TYVAR,
		SIG_SZ_ARRAY
	}
	internal sealed class PredefinedMethodInfo
	{
		public PREDEFMETH method;

		public PredefinedType type;

		public PredefinedName name;

		public MethodCallingConventionEnum callingConvention;

		public ACCESS access;

		public int cTypeVars;

		public int[] signature;

		public PredefinedMethodInfo(PREDEFMETH method, PredefinedType type, PredefinedName name, MethodCallingConventionEnum callingConvention, ACCESS access, int cTypeVars, int[] signature)
		{
			this.method = method;
			this.type = type;
			this.name = name;
			this.callingConvention = callingConvention;
			this.access = access;
			this.cTypeVars = cTypeVars;
			this.signature = signature;
		}
	}
	internal sealed class PredefinedPropertyInfo
	{
		public PREDEFPROP property;

		public PredefinedName name;

		public PREDEFMETH getter;

		public PredefinedPropertyInfo(PREDEFPROP property, PredefinedName name, PREDEFMETH getter)
		{
			this.property = property;
			this.name = name;
			this.getter = getter;
		}
	}
	internal static class PredefinedMembers
	{
		private static readonly MethodSymbol[] _methods = new MethodSymbol[81];

		private static readonly PropertySymbol[] _properties = new PropertySymbol[1];

		private static readonly PredefinedPropertyInfo[] s_predefinedProperties = new PredefinedPropertyInfo[1]
		{
			new PredefinedPropertyInfo(PREDEFPROP.PP_G_OPTIONAL_VALUE, PredefinedName.PN_CAP_VALUE, PREDEFMETH.PM_G_OPTIONAL_GETVALUE)
		};

		private static readonly PredefinedMethodInfo[] s_predefinedMethods = new PredefinedMethodInfo[81]
		{
			new PredefinedMethodInfo(PREDEFMETH.PM_DECIMAL_OPDECREMENT, PredefinedType.PT_DECIMAL, PredefinedName.PN_OPDECREMENT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[3] { 6, 1, 6 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_DECIMAL_OPINCREMENT, PredefinedType.PT_DECIMAL, PredefinedName.PN_OPINCREMENT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[3] { 6, 1, 6 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_DECIMAL_OPUNARYMINUS, PredefinedType.PT_DECIMAL, PredefinedName.PN_OPUNARYMINUS, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[3] { 6, 1, 6 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_DELEGATE_COMBINE, PredefinedType.PT_DELEGATE, PredefinedName.PN_COMBINE, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 17, 2, 17, 17 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_DELEGATE_OPEQUALITY, PredefinedType.PT_DELEGATE, PredefinedName.PN_OPEQUALITY, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 8, 2, 17, 17 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_DELEGATE_OPINEQUALITY, PredefinedType.PT_DELEGATE, PredefinedName.PN_OPINEQUALITY, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 8, 2, 17, 17 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_DELEGATE_REMOVE, PredefinedType.PT_DELEGATE, PredefinedName.PN_REMOVE, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 17, 2, 17, 17 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_ADD, PredefinedType.PT_EXPRESSION, PredefinedName.PN_ADD, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_ADD_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_ADD, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5] { 32, 3, 31, 31, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_ADDCHECKED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_ADDCHECKED, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_ADDCHECKED_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_ADDCHECKED, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5] { 32, 3, 31, 31, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_AND, PredefinedType.PT_EXPRESSION, PredefinedName.PN_AND, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_AND_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_AND, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5] { 32, 3, 31, 31, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_ANDALSO, PredefinedType.PT_EXPRESSION, PredefinedName.PN_ANDALSO, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_ANDALSO_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_ANDALSO, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5] { 32, 3, 31, 31, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_ARRAYINDEX, PredefinedType.PT_EXPRESSION, PredefinedName.PN_ARRAYINDEX, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_ARRAYINDEX2, PredefinedType.PT_EXPRESSION, PredefinedName.PN_ARRAYINDEX, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5] { 37, 2, 31, 53, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_ASSIGN, PredefinedType.PT_EXPRESSION, PredefinedName.PN_ASSIGN, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_CONSTANT_OBJECT_TYPE, PredefinedType.PT_EXPRESSION, PredefinedName.PN_CONSTANT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 34, 2, 15, 20 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_CONVERT, PredefinedType.PT_EXPRESSION, PredefinedName.PN_CONVERT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 33, 2, 31, 20 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_CONVERT_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_CONVERT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5] { 33, 3, 31, 20, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_CONVERTCHECKED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_CONVERTCHECKED, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 33, 2, 31, 20 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_CONVERTCHECKED_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_CONVERTCHECKED, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5] { 33, 3, 31, 20, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_DIVIDE, PredefinedType.PT_EXPRESSION, PredefinedName.PN_DIVIDE, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_DIVIDE_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_DIVIDE, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5] { 32, 3, 31, 31, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_EQUAL, PredefinedType.PT_EXPRESSION, PredefinedName.PN_EQUAL, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_EQUAL_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_EQUAL, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[6] { 32, 4, 31, 31, 8, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_EXCLUSIVEOR, PredefinedType.PT_EXPRESSION, PredefinedName.PN_EXCLUSIVEOR, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_EXCLUSIVEOR_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_EXCLUSIVEOR, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5] { 32, 3, 31, 31, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_FIELD, PredefinedType.PT_EXPRESSION, PredefinedName.PN_CAP_FIELD, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 36, 2, 31, 41 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_GREATERTHAN, PredefinedType.PT_EXPRESSION, PredefinedName.PN_GREATERTHAN, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_GREATERTHAN_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_GREATERTHAN, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[6] { 32, 4, 31, 31, 8, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_GREATERTHANOREQUAL, PredefinedType.PT_EXPRESSION, PredefinedName.PN_GREATERTHANOREQUAL, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_GREATERTHANOREQUAL_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_GREATERTHANOREQUAL, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[6] { 32, 4, 31, 31, 8, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_LAMBDA, PredefinedType.PT_EXPRESSION, PredefinedName.PN_LAMBDA, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 1, new int[7] { 30, 52, 0, 2, 31, 53, 35 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_LEFTSHIFT, PredefinedType.PT_EXPRESSION, PredefinedName.PN_LEFTSHIFT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_LEFTSHIFT_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_LEFTSHIFT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5] { 32, 3, 31, 31, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_LESSTHAN, PredefinedType.PT_EXPRESSION, PredefinedName.PN_LESSTHAN, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_LESSTHAN_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_LESSTHAN, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[6] { 32, 4, 31, 31, 8, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_LESSTHANOREQUAL, PredefinedType.PT_EXPRESSION, PredefinedName.PN_LESSTHANOREQUAL, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_LESSTHANOREQUAL_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_LESSTHANOREQUAL, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[6] { 32, 4, 31, 31, 8, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_MODULO, PredefinedType.PT_EXPRESSION, PredefinedName.PN_MODULO, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_MODULO_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_MODULO, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5] { 32, 3, 31, 31, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_MULTIPLY, PredefinedType.PT_EXPRESSION, PredefinedName.PN_MULTIPLY, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_MULTIPLY_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_MULTIPLY, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5] { 32, 3, 31, 31, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_MULTIPLYCHECKED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_MULTIPLYCHECKED, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_MULTIPLYCHECKED_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_MULTIPLYCHECKED, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5] { 32, 3, 31, 31, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_NOTEQUAL, PredefinedType.PT_EXPRESSION, PredefinedName.PN_NOTEQUAL, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_NOTEQUAL_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_NOTEQUAL, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[6] { 32, 4, 31, 31, 8, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_OR, PredefinedType.PT_EXPRESSION, PredefinedName.PN_OR, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_OR_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_OR, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5] { 32, 3, 31, 31, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_ORELSE, PredefinedType.PT_EXPRESSION, PredefinedName.PN_ORELSE, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_ORELSE_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_ORELSE, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5] { 32, 3, 31, 31, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_PARAMETER, PredefinedType.PT_EXPRESSION, PredefinedName.PN_PARAMETER, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 35, 2, 20, 16 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_RIGHTSHIFT, PredefinedType.PT_EXPRESSION, PredefinedName.PN_RIGHTSHIFT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_RIGHTSHIFT_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_RIGHTSHIFT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5] { 32, 3, 31, 31, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_SUBTRACT, PredefinedType.PT_EXPRESSION, PredefinedName.PN_SUBTRACT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_SUBTRACT_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_SUBTRACT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5] { 32, 3, 31, 31, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_SUBTRACTCHECKED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_SUBTRACTCHECKED, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 32, 2, 31, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_SUBTRACTCHECKED_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_SUBTRACTCHECKED, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5] { 32, 3, 31, 31, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_UNARYPLUS_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_PLUS, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 33, 2, 31, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_NEGATE, PredefinedType.PT_EXPRESSION, PredefinedName.PN_NEGATE, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[3] { 33, 1, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_NEGATE_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_NEGATE, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 33, 2, 31, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_NEGATECHECKED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_NEGATECHECKED, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[3] { 33, 1, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_NEGATECHECKED_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_NEGATECHECKED, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 33, 2, 31, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_CALL, PredefinedType.PT_EXPRESSION, PredefinedName.PN_CALL, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[6] { 37, 3, 31, 42, 53, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_NEW, PredefinedType.PT_EXPRESSION, PredefinedName.PN_NEW, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5] { 38, 2, 43, 53, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_NEW_TYPE, PredefinedType.PT_EXPRESSION, PredefinedName.PN_NEW, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[3] { 38, 1, 20 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_QUOTE, PredefinedType.PT_EXPRESSION, PredefinedName.PN_QUOTE, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[3] { 33, 1, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_NOT, PredefinedType.PT_EXPRESSION, PredefinedName.PN_NOT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[3] { 33, 1, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_NOT_USER_DEFINED, PredefinedType.PT_EXPRESSION, PredefinedName.PN_NOT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 33, 2, 31, 42 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_NEWARRAYINIT, PredefinedType.PT_EXPRESSION, PredefinedName.PN_NEWARRAYINIT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5] { 39, 2, 20, 53, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_PROPERTY, PredefinedType.PT_EXPRESSION, PredefinedName.PN_EXPRESSION_PROPERTY, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 36, 2, 31, 44 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_EXPRESSION_INVOKE, PredefinedType.PT_EXPRESSION, PredefinedName.PN_INVOKE, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5] { 40, 2, 31, 53, 31 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_G_OPTIONAL_CTOR, PredefinedType.PT_G_OPTIONAL, PredefinedName.PN_CTOR, MethodCallingConventionEnum.Instance, ACCESS.ACC_PUBLIC, 0, new int[4] { 50, 1, 51, 0 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_G_OPTIONAL_GETVALUE, PredefinedType.PT_G_OPTIONAL, PredefinedName.PN_GETVALUE, MethodCallingConventionEnum.Instance, ACCESS.ACC_PUBLIC, 0, new int[3] { 51, 0, 0 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_STRING_CONCAT_OBJECT_2, PredefinedType.PT_STRING, PredefinedName.PN_CONCAT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 16, 2, 15, 15 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_STRING_CONCAT_OBJECT_3, PredefinedType.PT_STRING, PredefinedName.PN_CONCAT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[5] { 16, 3, 15, 15, 15 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_STRING_CONCAT_STRING_2, PredefinedType.PT_STRING, PredefinedName.PN_CONCAT, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 16, 2, 16, 16 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_STRING_OPEQUALITY, PredefinedType.PT_STRING, PredefinedName.PN_OPEQUALITY, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 8, 2, 16, 16 }),
			new PredefinedMethodInfo(PREDEFMETH.PM_STRING_OPINEQUALITY, PredefinedType.PT_STRING, PredefinedName.PN_OPINEQUALITY, MethodCallingConventionEnum.Static, ACCESS.ACC_PUBLIC, 0, new int[4] { 8, 2, 16, 16 })
		};

		private static PropertySymbol LoadProperty(PREDEFPROP property)
		{
			PredefinedPropertyInfo propInfo = GetPropInfo(property);
			return LoadProperty(property, NameManager.GetPredefinedName(propInfo.name), propInfo.getter);
		}

		private static PropertySymbol LoadProperty(PREDEFPROP predefProp, Name propertyName, PREDEFMETH propertyGetter)
		{
			SymbolTable.AddPredefinedPropertyToSymbolTable(GetPredefAgg(GetPropPredefType(predefProp)), propertyName);
			MethodSymbol method = GetMethod(propertyGetter);
			method.SetMethKind(MethodKindEnum.PropAccessor);
			return method.getProperty();
		}

		private static AggregateSymbol GetPredefAgg(PredefinedType pt)
		{
			return SymbolLoader.GetPredefAgg(pt);
		}

		private static CType LoadTypeFromSignature(int[] signature, ref int indexIntoSignatures, TypeArray classTyVars)
		{
			MethodSignatureEnum methodSignatureEnum = (MethodSignatureEnum)signature[indexIntoSignatures];
			indexIntoSignatures++;
			switch (methodSignatureEnum)
			{
			case MethodSignatureEnum.SIG_SZ_ARRAY:
				return TypeManager.GetArray(LoadTypeFromSignature(signature, ref indexIntoSignatures, classTyVars), 1, isSZArray: true);
			case MethodSignatureEnum.SIG_METH_TYVAR:
				return TypeManager.GetStdMethTypeVar(signature[indexIntoSignatures++]);
			case MethodSignatureEnum.SIG_CLASS_TYVAR:
				return classTyVars[signature[indexIntoSignatures++]];
			case (MethodSignatureEnum)50:
				return VoidType.Instance;
			default:
			{
				AggregateSymbol predefAgg = GetPredefAgg((PredefinedType)methodSignatureEnum);
				int count = predefAgg.GetTypeVars().Count;
				if (count == 0)
				{
					return TypeManager.GetAggregate(predefAgg, TypeArray.Empty);
				}
				CType[] array = new CType[count];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = LoadTypeFromSignature(signature, ref indexIntoSignatures, classTyVars);
				}
				return TypeManager.GetAggregate(predefAgg, TypeArray.Allocate(array));
			}
			}
		}

		private static TypeArray LoadTypeArrayFromSignature(int[] signature, ref int indexIntoSignatures, TypeArray classTyVars)
		{
			int num = signature[indexIntoSignatures];
			indexIntoSignatures++;
			CType[] array = new CType[num];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = LoadTypeFromSignature(signature, ref indexIntoSignatures, classTyVars);
			}
			return TypeArray.Allocate(array);
		}

		public static PropertySymbol GetProperty(PREDEFPROP property)
		{
			return _properties[(int)property] ?? (_properties[(int)property] = LoadProperty(property));
		}

		public static MethodSymbol GetMethod(PREDEFMETH method)
		{
			return _methods[(int)method] ?? (_methods[(int)method] = LoadMethod(method));
		}

		private static MethodSymbol LoadMethod(AggregateSymbol type, int[] signature, int cMethodTyVars, Name methodName, ACCESS methodAccess, bool isStatic, bool isVirtual)
		{
			TypeArray typeVarsAll = type.GetTypeVarsAll();
			int indexIntoSignatures = 0;
			CType returnType = LoadTypeFromSignature(signature, ref indexIntoSignatures, typeVarsAll);
			TypeArray argumentTypes = LoadTypeArrayFromSignature(signature, ref indexIntoSignatures, typeVarsAll);
			MethodSymbol methodSymbol = LookupMethodWhileLoading(type, cMethodTyVars, methodName, methodAccess, isStatic, isVirtual, returnType, argumentTypes);
			if (methodSymbol == null)
			{
				SymbolTable.AddPredefinedMethodToSymbolTable(type, methodName);
				methodSymbol = LookupMethodWhileLoading(type, cMethodTyVars, methodName, methodAccess, isStatic, isVirtual, returnType, argumentTypes);
			}
			return methodSymbol;
		}

		private static MethodSymbol LookupMethodWhileLoading(AggregateSymbol type, int cMethodTyVars, Name methodName, ACCESS methodAccess, bool isStatic, bool isVirtual, CType returnType, TypeArray argumentTypes)
		{
			for (Symbol symbol = SymbolLoader.LookupAggMember(methodName, type, symbmask_t.MASK_ALL); symbol != null; symbol = symbol.LookupNext(symbmask_t.MASK_ALL))
			{
				if (symbol is MethodSymbol methodSymbol && (methodSymbol.GetAccess() == methodAccess || methodAccess == ACCESS.ACC_UNKNOWN) && methodSymbol.isStatic == isStatic && methodSymbol.isVirtual == isVirtual && methodSymbol.typeVars.Count == cMethodTyVars && TypeManager.SubstEqualTypes(methodSymbol.RetType, returnType, null, methodSymbol.typeVars, denormMeth: true) && TypeManager.SubstEqualTypeArrays(methodSymbol.Params, argumentTypes, null, methodSymbol.typeVars))
				{
					return methodSymbol;
				}
			}
			return null;
		}

		private static MethodSymbol LoadMethod(PREDEFMETH method)
		{
			PredefinedMethodInfo methInfo = GetMethInfo(method);
			return LoadMethod(GetPredefAgg(methInfo.type), methInfo.signature, methInfo.cTypeVars, NameManager.GetPredefinedName(methInfo.name), methInfo.access, methInfo.callingConvention == MethodCallingConventionEnum.Static, methInfo.callingConvention == MethodCallingConventionEnum.Virtual);
		}

		private static PREDEFMETH GetPropGetter(PREDEFPROP property)
		{
			return GetPropInfo(property).getter;
		}

		private static PredefinedType GetPropPredefType(PREDEFPROP property)
		{
			return GetMethInfo(GetPropGetter(property)).type;
		}

		private static PredefinedPropertyInfo GetPropInfo(PREDEFPROP property)
		{
			return s_predefinedProperties[(int)property];
		}

		private static PredefinedMethodInfo GetMethInfo(PREDEFMETH method)
		{
			return s_predefinedMethods[(int)method];
		}
	}
	internal enum ACCESSERROR
	{
		ACCESSERROR_NOACCESS,
		ACCESSERROR_NOACCESSTHRU,
		ACCESSERROR_NOERROR
	}
	internal static class CSemanticChecker
	{
		public static void CheckForStaticClass(CType type)
		{
			if (type.IsStaticClass)
			{
				throw ErrorHandling.Error(ErrorCode.ERR_ConvertToStaticClass, type);
			}
		}

		public static ACCESSERROR CheckAccess2(Symbol symCheck, AggregateType atsCheck, Symbol symWhere, CType typeThru)
		{
			ACCESSERROR aCCESSERROR = CheckAccessCore(symCheck, atsCheck, symWhere, typeThru);
			if (ACCESSERROR.ACCESSERROR_NOERROR != aCCESSERROR)
			{
				return aCCESSERROR;
			}
			CType cType = symCheck.getType();
			if (cType == null)
			{
				return ACCESSERROR.ACCESSERROR_NOERROR;
			}
			if (atsCheck.TypeArgsAll.Count > 0)
			{
				cType = TypeManager.SubstType(cType, atsCheck);
			}
			if (!CheckTypeAccess(cType, symWhere))
			{
				return ACCESSERROR.ACCESSERROR_NOACCESS;
			}
			return ACCESSERROR.ACCESSERROR_NOERROR;
		}

		public static bool CheckTypeAccess(CType type, Symbol symWhere)
		{
			type = type.GetNakedType(fStripNub: true);
			AggregateType aggregateType = type as AggregateType;
			if (aggregateType == null)
			{
				return true;
			}
			do
			{
				if (ACCESSERROR.ACCESSERROR_NOERROR != CheckAccessCore(aggregateType.OwningAggregate, aggregateType.OuterType, symWhere, null))
				{
					return false;
				}
				aggregateType = aggregateType.OuterType;
			}
			while (aggregateType != null);
			TypeArray typeArgsAll = ((AggregateType)type).TypeArgsAll;
			for (int i = 0; i < typeArgsAll.Count; i++)
			{
				if (!CheckTypeAccess(typeArgsAll[i], symWhere))
				{
					return false;
				}
			}
			return true;
		}

		private static ACCESSERROR CheckAccessCore(Symbol symCheck, AggregateType atsCheck, Symbol symWhere, CType typeThru)
		{
			switch (symCheck.GetAccess())
			{
			default:
				throw Error.InternalCompilerError();
			case ACCESS.ACC_UNKNOWN:
				return ACCESSERROR.ACCESSERROR_NOACCESS;
			case ACCESS.ACC_PUBLIC:
				return ACCESSERROR.ACCESSERROR_NOERROR;
			case ACCESS.ACC_PRIVATE:
			case ACCESS.ACC_PROTECTED:
				if (symWhere == null)
				{
					return ACCESSERROR.ACCESSERROR_NOACCESS;
				}
				break;
			case ACCESS.ACC_INTERNAL:
			case ACCESS.ACC_INTERNALPROTECTED:
				if (symWhere == null)
				{
					return ACCESSERROR.ACCESSERROR_NOACCESS;
				}
				if (symWhere.SameAssemOrFriend(symCheck))
				{
					return ACCESSERROR.ACCESSERROR_NOERROR;
				}
				if (symCheck.GetAccess() == ACCESS.ACC_INTERNAL)
				{
					return ACCESSERROR.ACCESSERROR_NOACCESS;
				}
				break;
			case ACCESS.ACC_INTERNAL_AND_PROTECTED:
				if (symWhere == null || !symWhere.SameAssemOrFriend(symCheck))
				{
					return ACCESSERROR.ACCESSERROR_NOACCESS;
				}
				break;
			}
			AggregateSymbol aggregateSymbol = null;
			for (Symbol symbol = symWhere; symbol != null; symbol = symbol.parent)
			{
				if (symbol is AggregateSymbol aggregateSymbol2)
				{
					aggregateSymbol = aggregateSymbol2;
					break;
				}
			}
			if (aggregateSymbol == null)
			{
				return ACCESSERROR.ACCESSERROR_NOACCESS;
			}
			AggregateSymbol aggregateSymbol3 = symCheck.parent as AggregateSymbol;
			for (AggregateSymbol aggregateSymbol4 = aggregateSymbol; aggregateSymbol4 != null; aggregateSymbol4 = aggregateSymbol4.GetOuterAgg())
			{
				if (aggregateSymbol4 == aggregateSymbol3)
				{
					return ACCESSERROR.ACCESSERROR_NOERROR;
				}
			}
			if (symCheck.GetAccess() == ACCESS.ACC_PRIVATE)
			{
				return ACCESSERROR.ACCESSERROR_NOACCESS;
			}
			AggregateType aggregateType = null;
			if (typeThru != null && !symCheck.isStatic)
			{
				aggregateType = typeThru.GetAts();
			}
			bool flag = false;
			for (AggregateSymbol aggregateSymbol5 = aggregateSymbol; aggregateSymbol5 != null; aggregateSymbol5 = aggregateSymbol5.GetOuterAgg())
			{
				if (aggregateSymbol5.FindBaseAgg(aggregateSymbol3))
				{
					flag = true;
					if (aggregateType == null || aggregateType.OwningAggregate.FindBaseAgg(aggregateSymbol5))
					{
						return ACCESSERROR.ACCESSERROR_NOERROR;
					}
				}
			}
			if (!flag)
			{
				return ACCESSERROR.ACCESSERROR_NOACCESS;
			}
			return ACCESSERROR.ACCESSERROR_NOACCESSTHRU;
		}

		public static bool CheckBogus(Symbol sym)
		{
			return (sym as PropertySymbol)?.Bogus ?? false;
		}

		public static RuntimeBinderException ReportAccessError(SymWithType swtBad, Symbol symWhere, CType typeQual)
		{
			if (CheckAccess2(swtBad.Sym, swtBad.GetType(), symWhere, typeQual) != ACCESSERROR.ACCESSERROR_NOACCESSTHRU)
			{
				return ErrorHandling.Error(ErrorCode.ERR_BadAccess, swtBad);
			}
			return ErrorHandling.Error(ErrorCode.ERR_BadProtectedAccess, swtBad, typeQual, symWhere);
		}

		public static bool CheckAccess(Symbol symCheck, AggregateType atsCheck, Symbol symWhere, CType typeThru)
		{
			return CheckAccess2(symCheck, atsCheck, symWhere, typeThru) == ACCESSERROR.ACCESSERROR_NOERROR;
		}
	}
	internal sealed class SubstContext
	{
		public readonly CType[] ClassTypes;

		public readonly CType[] MethodTypes;

		public readonly bool DenormMeth;

		public bool IsNop => (ClassTypes.Length == 0) & (MethodTypes.Length == 0);

		public SubstContext(TypeArray typeArgsCls, TypeArray typeArgsMeth, bool denormMeth)
		{
			ClassTypes = typeArgsCls?.Items ?? Array.Empty<CType>();
			MethodTypes = typeArgsMeth?.Items ?? Array.Empty<CType>();
			DenormMeth = denormMeth;
		}

		public SubstContext(AggregateType type)
			: this(type, null, denormMeth: false)
		{
		}

		public SubstContext(AggregateType type, TypeArray typeArgsMeth)
			: this(type, typeArgsMeth, denormMeth: false)
		{
		}

		private SubstContext(AggregateType type, TypeArray typeArgsMeth, bool denormMeth)
			: this(type?.TypeArgsAll, typeArgsMeth, denormMeth)
		{
		}
	}
	internal class AggregateSymbol : NamespaceOrAggregateSymbol
	{
		public Type AssociatedSystemType;

		public Assembly AssociatedAssembly;

		private AggregateType _atsInst;

		private AggregateType _pBaseClass;

		private AggregateType _pUnderlyingType;

		private TypeArray _ifaces;

		private TypeArray _ifacesAll;

		private TypeArray _typeVarsThis;

		private TypeArray _typeVarsAll;

		private MethodSymbol _pConvFirst;

		private AggKindEnum _aggKind;

		private bool _isPredefined;

		private PredefinedType _iPredef;

		private bool _isAbstract;

		private bool _isSealed;

		private bool _hasPubNoArgCtor;

		private bool _isSkipUDOps;

		private bool? _hasConversion;

		public NamespaceOrAggregateSymbol Parent => parent as NamespaceOrAggregateSymbol;

		public AggregateSymbol GetBaseAgg()
		{
			return _pBaseClass?.OwningAggregate;
		}

		public AggregateType getThisType()
		{
			if (_atsInst == null)
			{
				AggregateType atsOuter = (isNested() ? GetOuterAgg().getThisType() : null);
				_atsInst = TypeManager.GetAggregate(this, atsOuter, GetTypeVars());
			}
			return _atsInst;
		}

		public bool FindBaseAgg(AggregateSymbol agg)
		{
			for (AggregateSymbol aggregateSymbol = this; aggregateSymbol != null; aggregateSymbol = aggregateSymbol.GetBaseAgg())
			{
				if (aggregateSymbol == agg)
				{
					return true;
				}
			}
			return false;
		}

		public bool isNested()
		{
			return parent is AggregateSymbol;
		}

		public AggregateSymbol GetOuterAgg()
		{
			return parent as AggregateSymbol;
		}

		public bool isPredefAgg(PredefinedType pt)
		{
			if (_isPredefined)
			{
				return _iPredef == pt;
			}
			return false;
		}

		public AggKindEnum AggKind()
		{
			return _aggKind;
		}

		public void SetAggKind(AggKindEnum aggKind)
		{
			_aggKind = aggKind;
			if (aggKind == AggKindEnum.Interface)
			{
				SetAbstract(@abstract: true);
			}
		}

		public bool IsClass()
		{
			return AggKind() == AggKindEnum.Class;
		}

		public bool IsDelegate()
		{
			return AggKind() == AggKindEnum.Delegate;
		}

		public bool IsInterface()
		{
			return AggKind() == AggKindEnum.Interface;
		}

		public bool IsStruct()
		{
			return AggKind() == AggKindEnum.Struct;
		}

		public bool IsEnum()
		{
			return AggKind() == AggKindEnum.Enum;
		}

		public bool IsValueType()
		{
			if (AggKind() != AggKindEnum.Struct)
			{
				return AggKind() == AggKindEnum.Enum;
			}
			return true;
		}

		public bool IsRefType()
		{
			if (AggKind() != AggKindEnum.Class && AggKind() != AggKindEnum.Interface)
			{
				return AggKind() == AggKindEnum.Delegate;
			}
			return true;
		}

		public bool IsStatic()
		{
			if (_isAbstract)
			{
				return _isSealed;
			}
			return false;
		}

		public bool IsAbstract()
		{
			return _isAbstract;
		}

		public void SetAbstract(bool @abstract)
		{
			_isAbstract = @abstract;
		}

		public bool IsPredefined()
		{
			return _isPredefined;
		}

		public void SetPredefined(bool predefined)
		{
			_isPredefined = predefined;
		}

		public PredefinedType GetPredefType()
		{
			return _iPredef;
		}

		public void SetPredefType(PredefinedType predef)
		{
			_iPredef = predef;
		}

		public bool IsSealed()
		{
			return _isSealed;
		}

		public void SetSealed(bool @sealed)
		{
			_isSealed = @sealed;
		}

		public bool HasConversion()
		{
			SymbolTable.AddConversionsForType(AssociatedSystemType);
			if (!_hasConversion.HasValue)
			{
				_hasConversion = GetBaseAgg() != null && GetBaseAgg().HasConversion();
			}
			return _hasConversion.Value;
		}

		public void SetHasConversion()
		{
			_hasConversion = true;
		}

		public bool HasPubNoArgCtor()
		{
			return _hasPubNoArgCtor;
		}

		public void SetHasPubNoArgCtor(bool hasPubNoArgCtor)
		{
			_hasPubNoArgCtor = hasPubNoArgCtor;
		}

		public bool IsSkipUDOps()
		{
			return _isSkipUDOps;
		}

		public void SetSkipUDOps(bool skipUDOps)
		{
			_isSkipUDOps = skipUDOps;
		}

		public TypeArray GetTypeVars()
		{
			return _typeVarsThis;
		}

		public void SetTypeVars(TypeArray typeVars)
		{
			if (typeVars == null)
			{
				_typeVarsThis = null;
				_typeVarsAll = null;
			}
			else
			{
				TypeArray pta = ((GetOuterAgg() == null) ? TypeArray.Empty : GetOuterAgg().GetTypeVarsAll());
				_typeVarsThis = typeVars;
				_typeVarsAll = TypeArray.Concat(pta, typeVars);
			}
		}

		public TypeArray GetTypeVarsAll()
		{
			return _typeVarsAll;
		}

		public AggregateType GetBaseClass()
		{
			return _pBaseClass;
		}

		public void SetBaseClass(AggregateType baseClass)
		{
			_pBaseClass = baseClass;
		}

		public AggregateType GetUnderlyingType()
		{
			return _pUnderlyingType;
		}

		public void SetUnderlyingType(AggregateType underlyingType)
		{
			_pUnderlyingType = underlyingType;
		}

		public TypeArray GetIfaces()
		{
			return _ifaces;
		}

		public void SetIfaces(TypeArray ifaces)
		{
			_ifaces = ifaces;
		}

		public TypeArray GetIfacesAll()
		{
			return _ifacesAll;
		}

		public void SetIfacesAll(TypeArray ifacesAll)
		{
			_ifacesAll = ifacesAll;
		}

		public MethodSymbol GetFirstUDConversion()
		{
			return _pConvFirst;
		}

		public void SetFirstUDConversion(MethodSymbol conv)
		{
			_pConvFirst = conv;
		}

		public bool InternalsVisibleTo(Assembly assembly)
		{
			return TypeManager.InternalsVisibleTo(AssociatedAssembly, assembly);
		}
	}
	internal sealed class EventSymbol : Symbol
	{
		public EventInfo AssociatedEventInfo;

		public new bool isStatic;

		public bool isOverride;

		public CType type;

		public MethodSymbol methAdd;

		public MethodSymbol methRemove;

		public bool IsWindowsRuntimeEvent { get; set; }
	}
	internal class FieldSymbol : VariableSymbol
	{
		public new bool isStatic;

		public bool isReadOnly;

		public bool isEvent;

		public FieldInfo AssociatedFieldInfo;

		public void SetType(CType pType)
		{
			type = pType;
		}

		public new CType GetType()
		{
			return type;
		}

		public AggregateSymbol getClass()
		{
			return parent as AggregateSymbol;
		}

		public EventSymbol getEvent()
		{
			return SymbolLoader.LookupAggMember(name, getClass(), symbmask_t.MASK_EventSymbol) as EventSymbol;
		}
	}
	internal sealed class IndexerSymbol : PropertySymbol
	{
	}
	internal sealed class LocalVariableSymbol : VariableSymbol
	{
		public ExprWrap wrap;

		public void SetType(CType pType)
		{
			type = pType;
		}

		public new CType GetType()
		{
			return type;
		}
	}
	internal abstract class MethodOrPropertySymbol : ParentSymbol
	{
		public uint modOptCount;

		public new bool isStatic;

		public bool isOverride;

		public bool isOperator;

		public bool isParamArray;

		public bool isHideByName;

		private bool[] _optionalParameterIndex;

		private bool[] _defaultParameterIndex;

		private ConstVal[] _defaultParameters;

		private CType[] _defaultParameterConstValTypes;

		private bool[] _marshalAsIndex;

		private UnmanagedType[] _marshalAsBuffer;

		public SymWithType swtSlot;

		public CType RetType;

		private TypeArray _Params;

		public List<Name> ParameterNames { get; private set; }

		public TypeArray Params
		{
			get
			{
				return _Params;
			}
			set
			{
				_Params = value;
				int count = value.Count;
				if (count == 0)
				{
					_optionalParameterIndex = (_defaultParameterIndex = (_marshalAsIndex = Array.Empty<bool>()));
					_defaultParameters = Array.Empty<ConstVal>();
					_defaultParameterConstValTypes = Array.Empty<CType>();
					_marshalAsBuffer = Array.Empty<UnmanagedType>();
				}
				else
				{
					_optionalParameterIndex = new bool[count];
					_defaultParameterIndex = new bool[count];
					_defaultParameters = new ConstVal[count];
					_defaultParameterConstValTypes = new CType[count];
					_marshalAsIndex = new bool[count];
					_marshalAsBuffer = new UnmanagedType[count];
				}
			}
		}

		public MethodOrPropertySymbol()
		{
			ParameterNames = new List<Name>();
		}

		public bool IsParameterOptional(int index)
		{
			if (_optionalParameterIndex == null)
			{
				return false;
			}
			return _optionalParameterIndex[index];
		}

		public void SetOptionalParameter(int index)
		{
			_optionalParameterIndex[index] = true;
		}

		public bool HasOptionalParameters()
		{
			if (_optionalParameterIndex == null)
			{
				return false;
			}
			bool[] optionalParameterIndex = _optionalParameterIndex;
			for (int i = 0; i < optionalParameterIndex.Length; i++)
			{
				if (optionalParameterIndex[i])
				{
					return true;
				}
			}
			return false;
		}

		public bool HasDefaultParameterValue(int index)
		{
			return _defaultParameterIndex[index];
		}

		public void SetDefaultParameterValue(int index, CType type, ConstVal cv)
		{
			_defaultParameterIndex[index] = true;
			_defaultParameters[index] = cv;
			_defaultParameterConstValTypes[index] = type;
		}

		public ConstVal GetDefaultParameterValue(int index)
		{
			return _defaultParameters[index];
		}

		public CType GetDefaultParameterValueConstValType(int index)
		{
			return _defaultParameterConstValTypes[index];
		}

		private bool IsMarshalAsParameter(int index)
		{
			return _marshalAsIndex[index];
		}

		public void SetMarshalAsParameter(int index, UnmanagedType umt)
		{
			_marshalAsIndex[index] = true;
			_marshalAsBuffer[index] = umt;
		}

		private UnmanagedType GetMarshalAsParameterValue(int index)
		{
			return _marshalAsBuffer[index];
		}

		public bool MarshalAsObject(int index)
		{
			if (IsMarshalAsParameter(index))
			{
				UnmanagedType marshalAsParameterValue = GetMarshalAsParameterValue(index);
				if (marshalAsParameterValue != UnmanagedType.Interface && marshalAsParameterValue != UnmanagedType.IUnknown)
				{
					return marshalAsParameterValue == UnmanagedType.IDispatch;
				}
				return true;
			}
			return false;
		}

		public AggregateSymbol getClass()
		{
			return parent as AggregateSymbol;
		}

		public bool IsExpImpl()
		{
			return name == null;
		}
	}
	internal sealed class MethodSymbol : MethodOrPropertySymbol
	{
		private MethodKindEnum _methKind;

		private bool _inferenceMustFail;

		private bool _checkedInfMustFail;

		private MethodSymbol _convNext;

		private PropertySymbol _prop;

		private EventSymbol _evt;

		public bool isVirtual;

		public MemberInfo AssociatedMemberInfo;

		public TypeArray typeVars;

		public MethodKindEnum MethKind => _methKind;

		public bool InferenceMustFail()
		{
			if (_checkedInfMustFail)
			{
				return _inferenceMustFail;
			}
			_checkedInfMustFail = true;
			for (int i = 0; i < typeVars.Count; i++)
			{
				TypeParameterType typeFind = (TypeParameterType)typeVars[i];
				int num = 0;
				while (true)
				{
					if (num >= base.Params.Count)
					{
						_inferenceMustFail = true;
						return true;
					}
					if (TypeManager.TypeContainsType(base.Params[num], typeFind))
					{
						break;
					}
					num++;
				}
			}
			return false;
		}

		public bool IsConstructor()
		{
			return _methKind == MethodKindEnum.Constructor;
		}

		public bool IsNullableConstructor()
		{
			if (getClass().isPredefAgg(PredefinedType.PT_G_OPTIONAL) && base.Params.Count == 1 && base.Params[0] is TypeParameterType)
			{
				return IsConstructor();
			}
			return false;
		}

		public bool isPropertyAccessor()
		{
			return _methKind == MethodKindEnum.PropAccessor;
		}

		public bool isEventAccessor()
		{
			return _methKind == MethodKindEnum.EventAccessor;
		}

		public bool isImplicit()
		{
			return _methKind == MethodKindEnum.ImplicitConv;
		}

		public void SetMethKind(MethodKindEnum mk)
		{
			_methKind = mk;
		}

		public MethodSymbol ConvNext()
		{
			return _convNext;
		}

		public void SetConvNext(MethodSymbol conv)
		{
			_convNext = conv;
		}

		public PropertySymbol getProperty()
		{
			return _prop;
		}

		public void SetProperty(PropertySymbol prop)
		{
			_prop = prop;
		}

		public EventSymbol getEvent()
		{
			return _evt;
		}

		public void SetEvent(EventSymbol evt)
		{
			_evt = evt;
		}

		[Conditional("DEBUG")]
		private void AssertIsConversionOperator()
		{
		}

		public new bool isUserCallable()
		{
			if (!isOperator)
			{
				return !isAnyAccessor();
			}
			return false;
		}

		private bool isAnyAccessor()
		{
			if (!isPropertyAccessor())
			{
				return isEventAccessor();
			}
			return true;
		}

		public bool isSetAccessor()
		{
			if (!isPropertyAccessor())
			{
				return false;
			}
			PropertySymbol property = getProperty();
			if (property == null)
			{
				return false;
			}
			return this == property.SetterMethod;
		}
	}
	internal abstract class NamespaceOrAggregateSymbol : ParentSymbol
	{
	}
	internal sealed class NamespaceSymbol : NamespaceOrAggregateSymbol
	{
		public static readonly NamespaceSymbol Root = GetRootNamespaceSymbol();

		private static NamespaceSymbol GetRootNamespaceSymbol()
		{
			NamespaceSymbol namespaceSymbol = new NamespaceSymbol();
			namespaceSymbol.name = NameManager.GetPredefinedName(PredefinedName.PN_VOID);
			namespaceSymbol.setKind(SYMKIND.SK_NamespaceSymbol);
			return namespaceSymbol;
		}
	}
	internal abstract class ParentSymbol : Symbol
	{
		public Symbol firstChild;

		private Symbol _lastChild;

		public void AddToChildList(Symbol sym)
		{
			if (_lastChild == null)
			{
				firstChild = (_lastChild = sym);
			}
			else
			{
				_lastChild.nextChild = sym;
				_lastChild = sym;
				sym.nextChild = null;
			}
			sym.parent = this;
		}
	}
	internal class PropertySymbol : MethodOrPropertySymbol
	{
		public MethodSymbol GetterMethod { get; set; }

		public MethodSymbol SetterMethod { get; set; }

		public PropertyInfo AssociatedPropertyInfo { get; set; }

		public bool Bogus { get; set; }
	}
	internal sealed class Scope : ParentSymbol
	{
	}
	internal static class SymFactory
	{
		private static Symbol NewBasicSymbol(SYMKIND kind, Name name, ParentSymbol parent)
		{
			Symbol symbol;
			switch (kind)
			{
			case SYMKIND.SK_NamespaceSymbol:
				symbol = new NamespaceSymbol();
				symbol.name = name;
				break;
			case SYMKIND.SK_AggregateSymbol:
				symbol = new AggregateSymbol();
				symbol.name = name;
				break;
			case SYMKIND.SK_TypeParameterSymbol:
				symbol = new TypeParameterSymbol();
				symbol.name = name;
				break;
			case SYMKIND.SK_FieldSymbol:
				symbol = new FieldSymbol();
				symbol.name = name;
				break;
			case SYMKIND.SK_LocalVariableSymbol:
				symbol = new LocalVariableSymbol();
				symbol.name = name;
				break;
			case SYMKIND.SK_MethodSymbol:
				symbol = new MethodSymbol();
				symbol.name = name;
				break;
			case SYMKIND.SK_PropertySymbol:
				symbol = new PropertySymbol();
				symbol.name = name;
				break;
			case SYMKIND.SK_EventSymbol:
				symbol = new EventSymbol();
				symbol.name = name;
				break;
			case SYMKIND.SK_Scope:
				symbol = new Scope();
				symbol.name = name;
				break;
			case SYMKIND.SK_IndexerSymbol:
				symbol = new IndexerSymbol();
				symbol.name = name;
				break;
			default:
				throw Error.InternalCompilerError();
			}
			symbol.setKind(kind);
			if (parent != null)
			{
				parent.AddToChildList(symbol);
				SymbolStore.InsertChild(parent, symbol);
			}
			return symbol;
		}

		public static NamespaceSymbol CreateNamespace(Name name, NamespaceSymbol parent)
		{
			NamespaceSymbol obj = (NamespaceSymbol)NewBasicSymbol(SYMKIND.SK_NamespaceSymbol, name, parent);
			obj.SetAccess(ACCESS.ACC_PUBLIC);
			return obj;
		}

		public static AggregateSymbol CreateAggregate(Name name, NamespaceOrAggregateSymbol parent)
		{
			AggregateSymbol obj = (AggregateSymbol)NewBasicSymbol(SYMKIND.SK_AggregateSymbol, name, parent);
			obj.name = name;
			obj.SetSealed(@sealed: false);
			obj.SetAccess(ACCESS.ACC_UNKNOWN);
			obj.SetIfaces(null);
			obj.SetIfacesAll(null);
			obj.SetTypeVars(null);
			return obj;
		}

		public static FieldSymbol CreateMemberVar(Name name, AggregateSymbol parent)
		{
			return NewBasicSymbol(SYMKIND.SK_FieldSymbol, name, parent) as FieldSymbol;
		}

		public static LocalVariableSymbol CreateLocalVar(Name name, Scope parent, CType type)
		{
			LocalVariableSymbol obj = (LocalVariableSymbol)NewBasicSymbol(SYMKIND.SK_LocalVariableSymbol, name, parent);
			obj.SetType(type);
			obj.SetAccess(ACCESS.ACC_UNKNOWN);
			obj.wrap = null;
			return obj;
		}

		public static MethodSymbol CreateMethod(Name name, AggregateSymbol parent)
		{
			return NewBasicSymbol(SYMKIND.SK_MethodSymbol, name, parent) as MethodSymbol;
		}

		public static PropertySymbol CreateProperty(Name name, AggregateSymbol parent)
		{
			return NewBasicSymbol(SYMKIND.SK_PropertySymbol, name, parent) as PropertySymbol;
		}

		public static EventSymbol CreateEvent(Name name, AggregateSymbol parent)
		{
			return NewBasicSymbol(SYMKIND.SK_EventSymbol, name, parent) as EventSymbol;
		}

		public static TypeParameterSymbol CreateMethodTypeParameter(Name pName, MethodSymbol pParent, int index, int indexTotal)
		{
			TypeParameterSymbol obj = (TypeParameterSymbol)NewBasicSymbol(SYMKIND.SK_TypeParameterSymbol, pName, pParent);
			obj.SetIndexInOwnParameters(index);
			obj.SetIndexInTotalParameters(indexTotal);
			obj.SetIsMethodTypeParameter(b: true);
			obj.SetAccess(ACCESS.ACC_PRIVATE);
			return obj;
		}

		public static TypeParameterSymbol CreateClassTypeParameter(Name pName, AggregateSymbol pParent, int index, int indexTotal)
		{
			TypeParameterSymbol obj = (TypeParameterSymbol)NewBasicSymbol(SYMKIND.SK_TypeParameterSymbol, pName, pParent);
			obj.SetIndexInOwnParameters(index);
			obj.SetIndexInTotalParameters(indexTotal);
			obj.SetIsMethodTypeParameter(b: false);
			obj.SetAccess(ACCESS.ACC_PRIVATE);
			return obj;
		}

		public static Scope CreateScope()
		{
			return (Scope)NewBasicSymbol(SYMKIND.SK_Scope, null, null);
		}

		public static IndexerSymbol CreateIndexer(Name name, ParentSymbol parent)
		{
			IndexerSymbol obj = (IndexerSymbol)NewBasicSymbol(SYMKIND.SK_IndexerSymbol, name, parent);
			obj.setKind(SYMKIND.SK_PropertySymbol);
			obj.isOperator = true;
			return obj;
		}
	}
	internal enum ACCESS
	{
		ACC_UNKNOWN,
		ACC_PRIVATE,
		ACC_INTERNAL_AND_PROTECTED,
		ACC_INTERNAL,
		ACC_PROTECTED,
		ACC_INTERNALPROTECTED,
		ACC_PUBLIC
	}
	internal enum AggKindEnum
	{
		Unknown,
		Class,
		Delegate,
		Interface,
		Struct,
		Enum,
		Lim
	}
	[Flags]
	internal enum SpecCons
	{
		None = 0,
		New = 1,
		Ref = 2,
		Val = 4
	}
	internal abstract class Symbol
	{
		private SYMKIND _kind;

		private ACCESS _access;

		public Name name;

		public ParentSymbol parent;

		public Symbol nextChild;

		public Symbol nextSameName;

		public bool isStatic
		{
			get
			{
				if (this is FieldSymbol fieldSymbol)
				{
					return fieldSymbol.isStatic;
				}
				if (this is EventSymbol eventSymbol)
				{
					return eventSymbol.isStatic;
				}
				if (this is MethodOrPropertySymbol methodOrPropertySymbol)
				{
					return methodOrPropertySymbol.isStatic;
				}
				return this is AggregateSymbol;
			}
		}

		public Symbol LookupNext(symbmask_t kindmask)
		{
			for (Symbol symbol = nextSameName; symbol != null; symbol = symbol.nextSameName)
			{
				if ((kindmask & symbol.mask()) != ~symbmask_t.MASK_ALL)
				{
					return symbol;
				}
			}
			return null;
		}

		public ACCESS GetAccess()
		{
			return _access;
		}

		public void SetAccess(ACCESS access)
		{
			_access = access;
		}

		public SYMKIND getKind()
		{
			return _kind;
		}

		public void setKind(SYMKIND kind)
		{
			_kind = kind;
		}

		public symbmask_t mask()
		{
			return (symbmask_t)(1 << (int)_kind);
		}

		public CType getType()
		{
			if (this is MethodOrPropertySymbol methodOrPropertySymbol)
			{
				return methodOrPropertySymbol.RetType;
			}
			if (this is FieldSymbol fieldSymbol)
			{
				return fieldSymbol.GetType();
			}
			if (this is EventSymbol eventSymbol)
			{
				return eventSymbol.type;
			}
			return null;
		}

		private Assembly GetAssembly()
		{
			switch (_kind)
			{
			case SYMKIND.SK_TypeParameterSymbol:
			case SYMKIND.SK_FieldSymbol:
			case SYMKIND.SK_MethodSymbol:
			case SYMKIND.SK_PropertySymbol:
			case SYMKIND.SK_EventSymbol:
				return ((AggregateSymbol)parent).AssociatedAssembly;
			case SYMKIND.SK_AggregateSymbol:
				return ((AggregateSymbol)this).AssociatedAssembly;
			default:
				return null;
			}
		}

		private bool InternalsVisibleTo(Assembly assembly)
		{
			switch (_kind)
			{
			case SYMKIND.SK_TypeParameterSymbol:
			case SYMKIND.SK_FieldSymbol:
			case SYMKIND.SK_MethodSymbol:
			case SYMKIND.SK_PropertySymbol:
			case SYMKIND.SK_EventSymbol:
				return ((AggregateSymbol)parent).InternalsVisibleTo(assembly);
			case SYMKIND.SK_AggregateSymbol:
				return ((AggregateSymbol)this).InternalsVisibleTo(assembly);
			default:
				return false;
			}
		}

		public bool SameAssemOrFriend(Symbol sym)
		{
			Assembly assembly = GetAssembly();
			if (!(assembly == sym.GetAssembly()))
			{
				return sym.InternalsVisibleTo(assembly);
			}
			return true;
		}

		public bool IsOverride()
		{
			switch (_kind)
			{
			case SYMKIND.SK_MethodSymbol:
			case SYMKIND.SK_PropertySymbol:
				return ((MethodOrPropertySymbol)this).isOverride;
			case SYMKIND.SK_EventSymbol:
				return ((EventSymbol)this).isOverride;
			default:
				return false;
			}
		}

		public bool IsHideByName()
		{
			switch (_kind)
			{
			case SYMKIND.SK_MethodSymbol:
			case SYMKIND.SK_PropertySymbol:
				return ((MethodOrPropertySymbol)this).isHideByName;
			case SYMKIND.SK_EventSymbol:
				return ((EventSymbol)this).methAdd?.isHideByName ?? false;
			default:
				return true;
			}
		}

		public bool isUserCallable()
		{
			if (this is MethodSymbol methodSymbol)
			{
				return methodSymbol.isUserCallable();
			}
			return true;
		}
	}
	internal enum SYMKIND
	{
		SK_NamespaceSymbol,
		SK_AggregateSymbol,
		SK_TypeParameterSymbol,
		SK_FieldSymbol,
		SK_LocalVariableSymbol,
		SK_MethodSymbol,
		SK_PropertySymbol,
		SK_EventSymbol,
		SK_Scope,
		SK_IndexerSymbol
	}
	internal static class SymbolLoader
	{
		public static AggregateSymbol GetPredefAgg(PredefinedType pt)
		{
			return TypeManager.GetPredefAgg(pt);
		}

		public static AggregateType GetPredefindType(PredefinedType pt)
		{
			return GetPredefAgg(pt).getThisType();
		}

		public static Symbol LookupAggMember(Name name, AggregateSymbol agg, symbmask_t mask)
		{
			return SymbolStore.LookupSym(name, agg, mask);
		}

		private static bool IsBaseInterface(AggregateType atsDer, AggregateType pBase)
		{
			if (pBase.IsInterfaceType)
			{
				while (atsDer != null)
				{
					CType[] items = atsDer.IfacesAll.Items;
					for (int i = 0; i < items.Length; i++)
					{
						if (AreTypesEqualForConversion(items[i], pBase))
						{
							return true;
						}
					}
					atsDer = atsDer.BaseClass;
				}
			}
			return false;
		}

		public static bool IsBaseClassOfClass(CType pDerived, CType pBase)
		{
			if (pDerived.IsClassType)
			{
				return IsBaseClass(pDerived, pBase);
			}
			return false;
		}

		private static bool IsBaseClass(CType pDerived, CType pBase)
		{
			if (!(pBase is AggregateType { IsClassType: not false } aggregateType))
			{
				return false;
			}
			AggregateType aggregateType2 = pDerived as AggregateType;
			if (aggregateType2 == null)
			{
				if (!(pDerived is NullableType nullableType))
				{
					return false;
				}
				aggregateType2 = nullableType.GetAts();
			}
			for (AggregateType baseClass = aggregateType2.BaseClass; baseClass != null; baseClass = baseClass.BaseClass)
			{
				if (baseClass == aggregateType)
				{
					return true;
				}
			}
			return false;
		}

		private static bool HasCovariantArrayConversion(ArrayType pSource, ArrayType pDest)
		{
			if (pSource.Rank == pDest.Rank && pSource.IsSZArray == pDest.IsSZArray)
			{
				return HasImplicitReferenceConversion(pSource.ElementType, pDest.ElementType);
			}
			return false;
		}

		public static bool HasIdentityOrImplicitReferenceConversion(CType pSource, CType pDest)
		{
			if (AreTypesEqualForConversion(pSource, pDest))
			{
				return true;
			}
			return HasImplicitReferenceConversion(pSource, pDest);
		}

		private static bool AreTypesEqualForConversion(CType pType1, CType pType2)
		{
			return pType1.Equals(pType2);
		}

		private static bool HasArrayConversionToInterface(ArrayType pSource, CType pDest)
		{
			if (!pSource.IsSZArray || !pDest.IsInterfaceType)
			{
				return false;
			}
			if (pDest.IsPredefType(PredefinedType.PT_IENUMERABLE))
			{
				return true;
			}
			AggregateType aggregateType = (AggregateType)pDest;
			AggregateSymbol owningAggregate = aggregateType.OwningAggregate;
			if (!owningAggregate.isPredefAgg(PredefinedType.PT_G_ILIST) && !owningAggregate.isPredefAgg(PredefinedType.PT_G_ICOLLECTION) && !owningAggregate.isPredefAgg(PredefinedType.PT_G_IENUMERABLE) && !owningAggregate.isPredefAgg(PredefinedType.PT_G_IREADONLYCOLLECTION) && !owningAggregate.isPredefAgg(PredefinedType.PT_G_IREADONLYLIST))
			{
				return false;
			}
			return HasIdentityOrImplicitReferenceConversion(pSource.ElementType, aggregateType.TypeArgsAll[0]);
		}

		private static bool HasImplicitReferenceConversion(CType pSource, CType pDest)
		{
			if (pSource.IsReferenceType && pDest.IsPredefType(PredefinedType.PT_OBJECT))
			{
				return true;
			}
			if (pSource is AggregateType aggregateType)
			{
				if (pDest is AggregateType aggregateType2)
				{
					switch (aggregateType.OwningAggregate.AggKind())
					{
					case AggKindEnum.Class:
						switch (aggregateType2.OwningAggregate.AggKind())
						{
						case AggKindEnum.Class:
							return IsBaseClass(aggregateType, aggregateType2);
						case AggKindEnum.Interface:
							return HasAnyBaseInterfaceConversion(aggregateType, aggregateType2);
						}
						break;
					case AggKindEnum.Interface:
						if (aggregateType2.IsInterfaceType)
						{
							if (!HasAnyBaseInterfaceConversion(aggregateType, aggregateType2))
							{
								return HasInterfaceConversion(aggregateType, aggregateType2);
							}
							return true;
						}
						break;
					case AggKindEnum.Delegate:
						if (aggregateType2.IsPredefType(PredefinedType.PT_MULTIDEL) || aggregateType2.IsPredefType(PredefinedType.PT_DELEGATE) || IsBaseInterface(GetPredefindType(PredefinedType.PT_MULTIDEL), aggregateType2))
						{
							return true;
						}
						if (pDest.IsDelegateType)
						{
							return HasDelegateConversion(aggregateType, aggregateType2);
						}
						return false;
					}
				}
			}
			else if (pSource is ArrayType pSource2)
			{
				if (pDest is ArrayType pDest2)
				{
					return HasCovariantArrayConversion(pSource2, pDest2);
				}
				if (pDest is AggregateType aggregateType3)
				{
					if (aggregateType3.IsPredefType(PredefinedType.PT_ARRAY) || IsBaseInterface(GetPredefindType(PredefinedType.PT_ARRAY), aggregateType3))
					{
						return true;
					}
					return HasArrayConversionToInterface(pSource2, pDest);
				}
			}
			else if (pSource is NullType)
			{
				if (!pDest.IsReferenceType)
				{
					return pDest is NullableType;
				}
				return true;
			}
			return false;
		}

		private static bool HasAnyBaseInterfaceConversion(CType pDerived, CType pBase)
		{
			if (pBase.IsInterfaceType)
			{
				AggregateType aggregateType = pDerived as AggregateType;
				if (aggregateType != null)
				{
					AggregateType pDest = (AggregateType)pBase;
					while (aggregateType != null)
					{
						CType[] items = aggregateType.IfacesAll.Items;
						for (int i = 0; i < items.Length; i++)
						{
							if (HasInterfaceConversion((AggregateType)items[i], pDest))
							{
								return true;
							}
						}
						aggregateType = aggregateType.BaseClass;
					}
					return false;
				}
			}
			return false;
		}

		private static bool HasInterfaceConversion(AggregateType pSource, AggregateType pDest)
		{
			return HasVariantConversion(pSource, pDest);
		}

		private static bool HasDelegateConversion(AggregateType pSource, AggregateType pDest)
		{
			return HasVariantConversion(pSource, pDest);
		}

		private static bool HasVariantConversion(AggregateType pSource, AggregateType pDest)
		{
			if (pSource == pDest)
			{
				return true;
			}
			AggregateSymbol owningAggregate = pSource.OwningAggregate;
			if (owningAggregate != pDest.OwningAggregate)
			{
				return false;
			}
			TypeArray typeVarsAll = owningAggregate.GetTypeVarsAll();
			TypeArray typeArgsAll = pSource.TypeArgsAll;
			TypeArray typeArgsAll2 = pDest.TypeArgsAll;
			for (int i = 0; i < typeVarsAll.Count; i++)
			{
				CType cType = typeArgsAll[i];
				CType cType2 = typeArgsAll2[i];
				if (cType != cType2)
				{
					TypeParameterType typeParameterType = (TypeParameterType)typeVarsAll[i];
					if (typeParameterType.Invariant)
					{
						return false;
					}
					if (typeParameterType.Covariant && !HasImplicitReferenceConversion(cType, cType2))
					{
						return false;
					}
					if (typeParameterType.Contravariant && !HasImplicitReferenceConversion(cType2, cType))
					{
						return false;
					}
				}
			}
			return true;
		}

		private static bool HasImplicitBoxingConversion(CType pSource, CType pDest)
		{
			if (!pDest.IsReferenceType)
			{
				return false;
			}
			if (pSource is NullableType nullableType)
			{
				pSource = nullableType.UnderlyingType;
			}
			else if (!pSource.IsValueType)
			{
				return false;
			}
			if (!IsBaseClass(pSource, pDest))
			{
				return HasAnyBaseInterfaceConversion(pSource, pDest);
			}
			return true;
		}

		public static bool HasBaseConversion(CType pSource, CType pDest)
		{
			if (pSource is AggregateType && pDest.IsPredefType(PredefinedType.PT_OBJECT))
			{
				return true;
			}
			if (!HasIdentityOrImplicitReferenceConversion(pSource, pDest))
			{
				return HasImplicitBoxingConversion(pSource, pDest);
			}
			return true;
		}

		public static bool IsBaseAggregate(AggregateSymbol derived, AggregateSymbol @base)
		{
			if (derived == @base)
			{
				return true;
			}
			if (@base.IsInterface())
			{
				while (derived != null)
				{
					CType[] items = derived.GetIfacesAll().Items;
					for (int i = 0; i < items.Length; i++)
					{
						if (((AggregateType)items[i]).OwningAggregate == @base)
						{
							return true;
						}
					}
					derived = derived.GetBaseAgg();
				}
				return false;
			}
			while (derived.GetBaseClass() != null)
			{
				derived = derived.GetBaseClass().OwningAggregate;
				if (derived == @base)
				{
					return true;
				}
			}
			return false;
		}
	}
	[Flags]
	internal enum symbmask_t : long
	{
		MASK_NamespaceSymbol = 1L,
		MASK_AggregateSymbol = 2L,
		MASK_TypeParameterSymbol = 4L,
		MASK_FieldSymbol = 8L,
		MASK_MethodSymbol = 0x20L,
		MASK_PropertySymbol = 0x40L,
		MASK_EventSymbol = 0x80L,
		MASK_ALL = -1L,
		MASK_Member = 0xE8L
	}
	internal static class SymbolStore
	{
		private readonly struct Key(Name name, ParentSymbol parent) : IEquatable<Key>
		{
			private readonly Name _name = name;

			private readonly ParentSymbol _parent = parent;

			public bool Equals(Key other)
			{
				if (_name == other._name)
				{
					return _parent == other._parent;
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (obj is Key other)
				{
					return Equals(other);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return _name.GetHashCode() ^ _parent.GetHashCode();
			}
		}

		private static readonly Dictionary<Key, Symbol> s_dictionary = new Dictionary<Key, Symbol>();

		public static Symbol LookupSym(Name name, ParentSymbol parent, symbmask_t kindmask)
		{
			if (!s_dictionary.TryGetValue(new Key(name, parent), out var value))
			{
				return null;
			}
			return FindCorrectKind(value, kindmask);
		}

		public static void InsertChild(ParentSymbol parent, Symbol child)
		{
			child.parent = parent;
			InsertChildNoGrow(child);
		}

		private static void InsertChildNoGrow(Symbol child)
		{
			SYMKIND kind = child.getKind();
			if (kind == SYMKIND.SK_LocalVariableSymbol || kind == SYMKIND.SK_Scope)
			{
				return;
			}
			if (s_dictionary.TryGetValue(new Key(child.name, child.parent), out var value))
			{
				while (value?.nextSameName != null)
				{
					value = value.nextSameName;
				}
				value.nextSameName = child;
			}
			else
			{
				s_dictionary.Add(new Key(child.name, child.parent), child);
			}
		}

		private static Symbol FindCorrectKind(Symbol sym, symbmask_t kindmask)
		{
			do
			{
				if ((kindmask & sym.mask()) != ~symbmask_t.MASK_ALL)
				{
					return sym;
				}
				sym = sym.nextSameName;
			}
			while (sym != null);
			return null;
		}
	}
	internal sealed class TypeParameterSymbol : Symbol
	{
		private bool _bIsMethodTypeParameter;

		private SpecCons _constraints;

		private TypeParameterType _pTypeParameterType;

		private int _nIndexInOwnParameters;

		private int _nIndexInTotalParameters;

		private TypeArray _pBounds;

		public bool Covariant;

		public bool Contravariant;

		public bool Invariant
		{
			get
			{
				if (!Covariant)
				{
					return !Contravariant;
				}
				return false;
			}
		}

		public void SetTypeParameterType(TypeParameterType pType)
		{
			_pTypeParameterType = pType;
		}

		public TypeParameterType GetTypeParameterType()
		{
			return _pTypeParameterType;
		}

		public bool IsMethodTypeParameter()
		{
			return _bIsMethodTypeParameter;
		}

		public void SetIsMethodTypeParameter(bool b)
		{
			_bIsMethodTypeParameter = b;
		}

		public int GetIndexInOwnParameters()
		{
			return _nIndexInOwnParameters;
		}

		public void SetIndexInOwnParameters(int index)
		{
			_nIndexInOwnParameters = index;
		}

		public int GetIndexInTotalParameters()
		{
			return _nIndexInTotalParameters;
		}

		public void SetIndexInTotalParameters(int index)
		{
			_nIndexInTotalParameters = index;
		}

		public void SetBounds(TypeArray pBounds)
		{
			_pBounds = pBounds;
		}

		public TypeArray GetBounds()
		{
			return _pBounds;
		}

		public void SetConstraints(SpecCons constraints)
		{
			_constraints = constraints;
		}

		public bool IsValueType()
		{
			return (_constraints & SpecCons.Val) > SpecCons.None;
		}

		public bool IsReferenceType()
		{
			return (_constraints & SpecCons.Ref) > SpecCons.None;
		}

		public bool IsNonNullableValueType()
		{
			return (_constraints & SpecCons.Val) > SpecCons.None;
		}

		public bool HasNewConstraint()
		{
			return (_constraints & SpecCons.New) > SpecCons.None;
		}

		public bool HasRefConstraint()
		{
			return (_constraints & SpecCons.Ref) > SpecCons.None;
		}

		public bool HasValConstraint()
		{
			return (_constraints & SpecCons.Val) > SpecCons.None;
		}
	}
	internal abstract class VariableSymbol : Symbol
	{
		protected CType type;
	}
	internal sealed class ExprArrayIndex : ExprWithType
	{
		public Expr Array { get; set; }

		public Expr Index { get; set; }

		public ExprArrayIndex(CType type, Expr array, Expr index)
			: base(ExpressionKind.ArrayIndex, type)
		{
			Array = array;
			Index = index;
			base.Flags = EXPRFLAG.EXF_ASSGOP | EXPRFLAG.EXF_LVALUE;
		}
	}
	internal sealed class ExprArrayInit : ExprWithType
	{
		public Expr OptionalArguments { get; set; }

		public Expr OptionalArgumentDimensions { get; set; }

		public int[] DimensionSizes { get; }

		public int DimensionSize { get; set; }

		public bool GeneratedForParamArray { get; set; }

		public ExprArrayInit(CType type, Expr arguments, Expr argumentDimensions, int[] dimensionSizes, int dimensionSize)
			: base(ExpressionKind.ArrayInit, type)
		{
			OptionalArguments = arguments;
			OptionalArgumentDimensions = argumentDimensions;
			DimensionSizes = dimensionSizes;
			DimensionSize = dimensionSize;
		}
	}
	internal sealed class ExprAssignment : Expr
	{
		private Expr _lhs;

		public Expr LHS
		{
			get
			{
				return _lhs;
			}
			set
			{
				base.Type = (_lhs = value).Type;
			}
		}

		public Expr RHS { get; set; }

		public ExprAssignment(Expr lhs, Expr rhs)
			: base(ExpressionKind.Assignment)
		{
			LHS = lhs;
			RHS = rhs;
			base.Flags = EXPRFLAG.EXF_ASSGOP;
		}
	}
	internal sealed class ExprBinOp : ExprOperator
	{
		public Expr OptionalLeftChild { get; set; }

		public Expr OptionalRightChild { get; set; }

		public bool IsLifted { get; set; }

		public ExprBinOp(ExpressionKind kind, CType type, Expr left, Expr right)
			: base(kind, type)
		{
			base.Flags = EXPRFLAG.EXF_BINOP;
			OptionalLeftChild = left;
			OptionalRightChild = right;
		}

		public ExprBinOp(ExpressionKind kind, CType type, Expr left, Expr right, Expr call, MethPropWithInst userMethod)
			: base(kind, type, call, userMethod)
		{
			base.Flags = EXPRFLAG.EXF_BINOP;
			OptionalLeftChild = left;
			OptionalRightChild = right;
		}

		public void SetAssignment()
		{
			base.Flags |= EXPRFLAG.EXF_ASSGOP;
		}
	}
	internal sealed class ExprBoundLambda : ExprWithType
	{
		public Expr Expression { get; }

		public AggregateType DelegateType => base.Type as AggregateType;

		public Scope ArgumentScope { get; }

		public ExprBoundLambda(AggregateType type, Scope argumentScope, Expr expression)
			: base(ExpressionKind.BoundLambda, type)
		{
			ArgumentScope = argumentScope;
			Expression = expression;
		}
	}
	internal sealed class ExprCall : ExprWithArgs
	{
		public MethWithInst MethWithInst { get; set; }

		public PREDEFMETH PredefinedMethod { get; set; } = PREDEFMETH.PM_COUNT;

		public NullableCallLiftKind NullableCallLiftKind { get; set; }

		public Expr PConversions { get; set; }

		public Expr CastOfNonLiftedResultToLiftedType { get; set; }

		public ExprCall(CType type, EXPRFLAG flags, Expr arguments, ExprMemberGroup member, MethWithInst method)
			: base(ExpressionKind.Call, type)
		{
			base.Flags = flags;
			base.OptionalArguments = arguments;
			base.MemberGroup = member;
			NullableCallLiftKind = NullableCallLiftKind.NotLifted;
			MethWithInst = method;
		}

		public override SymWithType GetSymWithType()
		{
			return MethWithInst;
		}
	}
	internal sealed class ExprCast : ExprWithType
	{
		public Expr Argument { get; set; }

		public bool IsBoxingCast => (base.Flags & (EXPRFLAG.EXF_CTOR | EXPRFLAG.EXF_UNREALIZEDGOTO)) != 0;

		public override object Object
		{
			get
			{
				Expr argument;
				for (argument = Argument; argument is ExprCast exprCast; argument = exprCast.Argument)
				{
				}
				return argument.Object;
			}
		}

		public ExprCast(EXPRFLAG flags, CType type, Expr argument)
			: base(ExpressionKind.Cast, type)
		{
			Argument = argument;
			base.Flags = flags;
		}
	}
	internal sealed class ExprClass : ExprWithType
	{
		public ExprClass(CType type)
			: base(ExpressionKind.Class, type)
		{
		}
	}
	internal sealed class ExprMultiGet : ExprWithType
	{
		public ExprMulti OptionalMulti { get; set; }

		public ExprMultiGet(CType type, EXPRFLAG flags, ExprMulti multi)
			: base(ExpressionKind.MultiGet, type)
		{
			base.Flags = flags;
			OptionalMulti = multi;
		}
	}
	internal sealed class ExprMulti : ExprWithType
	{
		public Expr Left { get; set; }

		public Expr Operator { get; set; }

		public ExprMulti(CType type, EXPRFLAG flags, Expr left, Expr op)
			: base(ExpressionKind.Multi, type)
		{
			base.Flags = flags;
			Left = left;
			Operator = op;
		}
	}
	internal sealed class ExprConcat : ExprWithType
	{
		public Expr FirstArgument { get; set; }

		public Expr SecondArgument { get; set; }

		public ExprConcat(Expr first, Expr second)
			: base(ExpressionKind.Concat, TypeFromOperands(first, second))
		{
			FirstArgument = first;
			SecondArgument = second;
		}

		private static CType TypeFromOperands(Expr first, Expr second)
		{
			CType type = first.Type;
			if (type.IsPredefType(PredefinedType.PT_STRING))
			{
				return type;
			}
			return second.Type;
		}
	}
	internal sealed class ExprConstant : ExprWithType
	{
		public Expr OptionalConstructorCall { get; set; }

		public bool IsZero => Val.IsZero(base.Type.ConstValKind);

		public ConstVal Val { get; }

		public ulong UInt64Value => Val.UInt64Val;

		public long Int64Value
		{
			get
			{
				switch (base.Type.FundamentalType)
				{
				case FUNDTYPE.FT_I8:
				case FUNDTYPE.FT_U8:
					return Val.Int64Val;
				case FUNDTYPE.FT_U4:
					return Val.UInt32Val;
				default:
					return Val.Int32Val;
				}
			}
		}

		public override object Object
		{
			get
			{
				if (base.Type is NullType)
				{
					return null;
				}
				object obj = System.Type.GetTypeCode(base.Type.AssociatedSystemType) switch
				{
					TypeCode.Boolean => Val.BooleanVal, 
					TypeCode.SByte => Val.SByteVal, 
					TypeCode.Byte => Val.ByteVal, 
					TypeCode.Int16 => Val.Int16Val, 
					TypeCode.UInt16 => Val.UInt16Val, 
					TypeCode.Int32 => Val.Int32Val, 
					TypeCode.UInt32 => Val.UInt32Val, 
					TypeCode.Int64 => Val.Int64Val, 
					TypeCode.UInt64 => Val.UInt64Val, 
					TypeCode.Single => Val.SingleVal, 
					TypeCode.Double => Val.DoubleVal, 
					TypeCode.Decimal => Val.DecimalVal, 
					TypeCode.Char => Val.CharVal, 
					TypeCode.String => Val.StringVal, 
					_ => Val.ObjectVal, 
				};
				if (!base.Type.IsEnumType)
				{
					return obj;
				}
				return Enum.ToObject(base.Type.AssociatedSystemType, obj);
			}
		}

		public ExprConstant(CType type, ConstVal value)
			: base(ExpressionKind.Constant, type)
		{
			Val = value;
		}
	}
	internal abstract class Expr
	{
		private CType _type;

		internal object RuntimeObject { get; set; }

		internal CType RuntimeObjectActualType { get; set; }

		public ExpressionKind Kind { get; }

		public EXPRFLAG Flags { get; set; }

		public bool IsOptionalArgument { get; set; }

		public string ErrorString { get; set; }

		public CType Type
		{
			get
			{
				return _type;
			}
			protected set
			{
				_type = value;
			}
		}

		[ExcludeFromCodeCoverage]
		public virtual object Object
		{
			get
			{
				throw Error.InternalCompilerError();
			}
		}

		protected Expr(ExpressionKind kind)
		{
			Kind = kind;
		}
	}
	internal abstract class ExprOperator : ExprWithType
	{
		public Expr OptionalUserDefinedCall { get; }

		public MethWithInst PredefinedMethodToCall { get; set; }

		public MethPropWithInst UserDefinedCallMethod { get; set; }

		protected ExprOperator(ExpressionKind kind, CType type)
			: base(kind, type)
		{
		}

		protected ExprOperator(ExpressionKind kind, CType type, Expr call, MethPropWithInst userDefinedMethod)
			: this(kind, type)
		{
			OptionalUserDefinedCall = call;
			UserDefinedCallMethod = userDefinedMethod;
		}
	}
	internal abstract class ExprWithArgs : ExprWithType
	{
		public ExprMemberGroup MemberGroup { get; set; }

		public Expr OptionalArguments { get; set; }

		protected ExprWithArgs(ExpressionKind kind, CType type)
			: base(kind, type)
		{
		}

		public abstract SymWithType GetSymWithType();
	}
	internal abstract class ExprWithType : Expr
	{
		protected ExprWithType(ExpressionKind kind, CType type)
			: base(kind)
		{
			base.Type = type;
		}

		protected static bool TypesAreEqual(Type t1, Type t2)
		{
			if (!(t1 == t2))
			{
				return t1.IsEquivalentTo(t2);
			}
			return true;
		}
	}
	internal sealed class ExpressionIterator
	{
		private ExprList _pList;

		private Expr _pCurrent;

		public ExpressionIterator(Expr pExpr)
		{
			Init(pExpr);
		}

		public bool AtEnd()
		{
			if (_pCurrent == null)
			{
				return _pList == null;
			}
			return false;
		}

		public Expr Current()
		{
			return _pCurrent;
		}

		public void MoveNext()
		{
			if (!AtEnd())
			{
				if (_pList == null)
				{
					_pCurrent = null;
				}
				else
				{
					Init(_pList.OptionalNextListNode);
				}
			}
		}

		public static int Count(Expr pExpr)
		{
			int num = 0;
			ExpressionIterator expressionIterator = new ExpressionIterator(pExpr);
			while (!expressionIterator.AtEnd())
			{
				num++;
				expressionIterator.MoveNext();
			}
			return num;
		}

		private void Init(Expr pExpr)
		{
			if (pExpr == null)
			{
				_pList = null;
				_pCurrent = null;
			}
			else if (pExpr is ExprList exprList)
			{
				_pList = exprList;
				_pCurrent = exprList.OptionalElement;
			}
			else
			{
				_pList = null;
				_pCurrent = pExpr;
			}
		}
	}
	internal sealed class ExprField : ExprWithType
	{
		public Expr OptionalObject { get; set; }

		public FieldWithType FieldWithType { get; }

		public ExprField(CType type, Expr optionalObject, FieldWithType field)
			: base(ExpressionKind.Field, type)
		{
			base.Flags = ((!field.Field().isReadOnly) ? EXPRFLAG.EXF_LVALUE : ((EXPRFLAG)0));
			OptionalObject = optionalObject;
			FieldWithType = field;
		}
	}
	internal sealed class ExprFieldInfo : ExprWithType
	{
		public FieldSymbol Field { get; }

		public AggregateType FieldType { get; }

		public ExprFieldInfo(FieldSymbol field, AggregateType fieldType, CType type)
			: base(ExpressionKind.FieldInfo, type)
		{
			Field = field;
			FieldType = fieldType;
		}
	}
	internal sealed class ExprList : Expr
	{
		public Expr OptionalElement { get; set; }

		public Expr OptionalNextListNode { get; set; }

		public ExprList(Expr optionalElement, Expr optionalNextListNode)
			: base(ExpressionKind.List)
		{
			OptionalElement = optionalElement;
			OptionalNextListNode = optionalNextListNode;
		}
	}
	internal sealed class ExprLocal : Expr
	{
		public LocalVariableSymbol Local { get; }

		public ExprLocal(LocalVariableSymbol local)
			: base(ExpressionKind.Local)
		{
			base.Flags = EXPRFLAG.EXF_LVALUE;
			Local = local;
			base.Type = local?.GetType();
		}
	}
	internal sealed class ExprMemberGroup : ExprWithType
	{
		public Name Name { get; }

		public TypeArray TypeArgs { get; }

		public SYMKIND SymKind { get; }

		public Expr OptionalObject { get; set; }

		public Expr OptionalLHS { get; set; }

		public CMemberLookupResults MemberLookupResults { get; }

		public CType ParentType { get; }

		public bool IsDelegate => (base.Flags & EXPRFLAG.EXF_GOTONOTBLOCKED) != 0;

		public ExprMemberGroup(EXPRFLAG flags, Name name, TypeArray typeArgs, SYMKIND symKind, CType parentType, Expr optionalObject, CMemberLookupResults memberLookupResults)
			: base(ExpressionKind.MemberGroup, MethodGroupType.Instance)
		{
			base.Flags = flags;
			Name = name;
			TypeArgs = typeArgs ?? TypeArray.Empty;
			SymKind = symKind;
			ParentType = parentType;
			OptionalObject = optionalObject;
			MemberLookupResults = memberLookupResults;
		}
	}
	internal sealed class ExprMethodInfo : ExprWithType
	{
		public MethWithInst Method { get; }

		public MethodInfo MethodInfo
		{
			get
			{
				AggregateType ats = Method.Ats;
				MethodSymbol methodSymbol = Method.Meth();
				TypeArray typeArray = TypeManager.SubstTypeArray(methodSymbol.Params, ats, methodSymbol.typeVars);
				TypeManager.SubstType(methodSymbol.RetType, ats, methodSymbol.typeVars);
				Type type = ats.AssociatedSystemType;
				MethodInfo methodInfo = methodSymbol.AssociatedMemberInfo as MethodInfo;
				if (!type.IsGenericType && !type.IsNested)
				{
					type = methodInfo.DeclaringType;
				}
				foreach (MethodInfo runtimeMethod in type.GetRuntimeMethods())
				{
					if (!runtimeMethod.HasSameMetadataDefinitionAs(methodInfo))
					{
						continue;
					}
					bool flag = true;
					ParameterInfo[] parameters = runtimeMethod.GetParameters();
					for (int i = 0; i < typeArray.Count; i++)
					{
						if (!ExprWithType.TypesAreEqual(parameters[i].ParameterType, typeArray[i].AssociatedSystemType))
						{
							flag = false;
							break;
						}
					}
					if (!flag)
					{
						continue;
					}
					if (runtimeMethod.IsGenericMethod)
					{
						int num = Method.TypeArgs?.Count ?? 0;
						Type[] array = new Type[num];
						if (num > 0)
						{
							for (int j = 0; j < Method.TypeArgs.Count; j++)
							{
								array[j] = Method.TypeArgs[j].AssociatedSystemType;
							}
						}
						return runtimeMethod.MakeGenericMethod(array);
					}
					return runtimeMethod;
				}
				throw Error.InternalCompilerError();
			}
		}

		public ConstructorInfo ConstructorInfo
		{
			get
			{
				AggregateType ats = Method.Ats;
				MethodSymbol methodSymbol = Method.Meth();
				TypeArray typeArray = TypeManager.SubstTypeArray(methodSymbol.Params, ats);
				Type type = ats.AssociatedSystemType;
				ConstructorInfo constructorInfo = (ConstructorInfo)methodSymbol.AssociatedMemberInfo;
				if (!type.IsGenericType && !type.IsNested)
				{
					type = constructorInfo.DeclaringType;
				}
				ConstructorInfo[] constructors = type.GetConstructors(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (ConstructorInfo constructorInfo2 in constructors)
				{
					if (!constructorInfo2.HasSameMetadataDefinitionAs(constructorInfo))
					{
						continue;
					}
					bool flag = true;
					ParameterInfo[] parameters = constructorInfo2.GetParameters();
					for (int j = 0; j < typeArray.Count; j++)
					{
						if (!ExprWithType.TypesAreEqual(parameters[j].ParameterType, typeArray[j].AssociatedSystemType))
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						return constructorInfo2;
					}
				}
				throw Error.InternalCompilerError();
			}
		}

		public override object Object => MethodInfo;

		public ExprMethodInfo(CType type, MethodSymbol method, AggregateType methodType, TypeArray methodParameters)
			: base(ExpressionKind.MethodInfo, type)
		{
			Method = new MethWithInst(method, methodType, methodParameters);
		}
	}
	internal sealed class ExprNamedArgumentSpecification : Expr
	{
		private Expr _value;

		public Name Name { get; }

		public Expr Value
		{
			get
			{
				return _value;
			}
			set
			{
				base.Type = (_value = value).Type;
			}
		}

		public ExprNamedArgumentSpecification(Name name, Expr value)
			: base(ExpressionKind.NamedArgumentSpecification)
		{
			Name = name;
			Value = value;
		}
	}
	internal sealed class ExprProperty : ExprWithArgs
	{
		public Expr OptionalObjectThrough { get; }

		public PropWithType PropWithTypeSlot { get; }

		public MethWithType MethWithTypeSet { get; }

		public ExprProperty(CType type, Expr pOptionalObjectThrough, Expr pOptionalArguments, ExprMemberGroup pMemberGroup, PropWithType pwtSlot, MethWithType mwtSet)
			: base(ExpressionKind.Property, type)
		{
			OptionalObjectThrough = pOptionalObjectThrough;
			base.OptionalArguments = pOptionalArguments;
			base.MemberGroup = pMemberGroup;
			if (pwtSlot != null)
			{
				PropWithTypeSlot = pwtSlot;
			}
			if (mwtSet != null)
			{
				MethWithTypeSet = mwtSet;
				base.Flags = EXPRFLAG.EXF_LVALUE;
			}
		}

		public override SymWithType GetSymWithType()
		{
			return PropWithTypeSlot;
		}
	}
	internal sealed class ExprPropertyInfo : ExprWithType
	{
		public PropWithType Property { get; }

		public PropertyInfo PropertyInfo
		{
			get
			{
				AggregateType ats = Property.Ats;
				PropertySymbol propertySymbol = Property.Prop();
				TypeArray typeArray = TypeManager.SubstTypeArray(propertySymbol.Params, ats, null);
				Type type = ats.AssociatedSystemType;
				PropertyInfo associatedPropertyInfo = propertySymbol.AssociatedPropertyInfo;
				if (!type.IsGenericType && !type.IsNested)
				{
					type = associatedPropertyInfo.DeclaringType;
				}
				PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
				foreach (PropertyInfo propertyInfo in properties)
				{
					if (!propertyInfo.HasSameMetadataDefinitionAs(associatedPropertyInfo))
					{
						continue;
					}
					bool flag = true;
					ParameterInfo[] array = ((propertyInfo.GetSetMethod(nonPublic: true) != null) ? propertyInfo.GetSetMethod(nonPublic: true).GetParameters() : propertyInfo.GetGetMethod(nonPublic: true).GetParameters());
					for (int j = 0; j < typeArray.Count; j++)
					{
						if (!ExprWithType.TypesAreEqual(array[j].ParameterType, typeArray[j].AssociatedSystemType))
						{
							flag = false;
							break;
						}
					}
					if (flag)
					{
						return propertyInfo;
					}
				}
				throw Error.InternalCompilerError();
			}
		}

		public ExprPropertyInfo(CType type, PropertySymbol propertySymbol, AggregateType propertyType)
			: base(ExpressionKind.PropertyInfo, type)
		{
			Property = new PropWithType(propertySymbol, propertyType);
		}
	}
	internal sealed class ExprWrap : Expr
	{
		public Expr OptionalExpression { get; }

		public ExprWrap(Expr expression)
			: base(ExpressionKind.Wrap)
		{
			OptionalExpression = expression;
			base.Type = expression?.Type;
			base.Flags = EXPRFLAG.EXF_LVALUE;
		}
	}
	internal sealed class ExprTypeOf : ExprWithType
	{
		public CType SourceType { get; }

		public override object Object => SourceType.AssociatedSystemType;

		public ExprTypeOf(CType type, CType sourceType)
			: base(ExpressionKind.TypeOf, type)
		{
			base.Flags = EXPRFLAG.EXF_CANTBENULL;
			SourceType = sourceType;
		}
	}
	internal sealed class ExprUnaryOp : ExprOperator
	{
		public Expr Child { get; set; }

		public ExprUnaryOp(ExpressionKind kind, CType type, Expr operand)
			: base(kind, type)
		{
			Child = operand;
		}

		public ExprUnaryOp(ExpressionKind kind, CType type, Expr operand, Expr call, MethPropWithInst userMethod)
			: base(kind, type, call, userMethod)
		{
			Child = operand;
		}
	}
	internal sealed class ExprUserDefinedConversion : Expr
	{
		private Expr _userDefinedCall;

		public Expr Argument { get; set; }

		public Expr UserDefinedCall
		{
			get
			{
				return _userDefinedCall;
			}
			set
			{
				base.Type = (_userDefinedCall = value).Type;
			}
		}

		public MethWithInst UserDefinedCallMethod { get; }

		public ExprUserDefinedConversion(Expr argument, Expr call, MethWithInst method)
			: base(ExpressionKind.UserDefinedConversion)
		{
			Argument = argument;
			UserDefinedCall = call;
			UserDefinedCallMethod = method;
		}
	}
	internal sealed class ExprUserLogicalOp : ExprWithType
	{
		public Expr TrueFalseCall { get; set; }

		public ExprCall OperatorCall { get; set; }

		public Expr FirstOperandToExamine { get; set; }

		public ExprUserLogicalOp(CType type, Expr trueFalseCall, ExprCall operatorCall)
			: base(ExpressionKind.UserLogicalOp, type)
		{
			base.Flags = EXPRFLAG.EXF_ASSGOP;
			TrueFalseCall = trueFalseCall;
			OperatorCall = operatorCall;
			Expr optionalElement = ((ExprList)operatorCall.OptionalArguments).OptionalElement;
			FirstOperandToExamine = ((optionalElement is ExprWrap exprWrap) ? exprWrap.OptionalExpression : optionalElement);
		}
	}
	internal abstract class ExprVisitorBase
	{
		protected Expr Visit(Expr pExpr)
		{
			if (pExpr != null)
			{
				return Dispatch(pExpr);
			}
			return null;
		}

		protected virtual Expr Dispatch(Expr pExpr)
		{
			return pExpr.Kind switch
			{
				ExpressionKind.BinaryOp => VisitBINOP(pExpr as ExprBinOp), 
				ExpressionKind.UnaryOp => VisitUNARYOP(pExpr as ExprUnaryOp), 
				ExpressionKind.Assignment => VisitASSIGNMENT(pExpr as ExprAssignment), 
				ExpressionKind.List => VisitLIST(pExpr as ExprList), 
				ExpressionKind.ArrayIndex => VisitARRAYINDEX(pExpr as ExprArrayIndex), 
				ExpressionKind.Call => VisitCALL(pExpr as ExprCall), 
				ExpressionKind.Field => VisitFIELD(pExpr as ExprField), 
				ExpressionKind.Local => VisitLOCAL(pExpr as ExprLocal), 
				ExpressionKind.Constant => VisitCONSTANT(pExpr as ExprConstant), 
				ExpressionKind.Class => pExpr, 
				ExpressionKind.Property => VisitPROP(pExpr as ExprProperty), 
				ExpressionKind.Multi => VisitMULTI(pExpr as ExprMulti), 
				ExpressionKind.MultiGet => VisitMULTIGET(pExpr as ExprMultiGet), 
				ExpressionKind.Wrap => VisitWRAP(pExpr as ExprWrap), 
				ExpressionKind.Concat => VisitCONCAT(pExpr as ExprConcat), 
				ExpressionKind.ArrayInit => VisitARRINIT(pExpr as ExprArrayInit), 
				ExpressionKind.Cast => VisitCAST(pExpr as ExprCast), 
				ExpressionKind.UserDefinedConversion => VisitUSERDEFINEDCONVERSION(pExpr as ExprUserDefinedConversion), 
				ExpressionKind.TypeOf => VisitTYPEOF(pExpr as ExprTypeOf), 
				ExpressionKind.ZeroInit => VisitZEROINIT(pExpr as ExprZeroInit), 
				ExpressionKind.UserLogicalOp => VisitUSERLOGOP(pExpr as ExprUserLogicalOp), 
				ExpressionKind.MemberGroup => VisitMEMGRP(pExpr as ExprMemberGroup), 
				ExpressionKind.FieldInfo => VisitFIELDINFO(pExpr as ExprFieldInfo), 
				ExpressionKind.MethodInfo => VisitMETHODINFO(pExpr as ExprMethodInfo), 
				ExpressionKind.EqualsParam => VisitEQUALS(pExpr as ExprBinOp), 
				ExpressionKind.Compare => VisitCOMPARE(pExpr as ExprBinOp), 
				ExpressionKind.NotEq => VisitNE(pExpr as ExprBinOp), 
				ExpressionKind.LessThan => VisitLT(pExpr as ExprBinOp), 
				ExpressionKind.LessThanOrEqual => VisitLE(pExpr as ExprBinOp), 
				ExpressionKind.GreaterThan => VisitGT(pExpr as ExprBinOp), 
				ExpressionKind.GreaterThanOrEqual => VisitGE(pExpr as ExprBinOp), 
				ExpressionKind.Add => VisitADD(pExpr as ExprBinOp), 
				ExpressionKind.Subtract => VisitSUB(pExpr as ExprBinOp), 
				ExpressionKind.Multiply => VisitMUL(pExpr as ExprBinOp), 
				ExpressionKind.Divide => VisitDIV(pExpr as ExprBinOp), 
				ExpressionKind.Modulo => VisitMOD(pExpr as ExprBinOp), 
				ExpressionKind.BitwiseAnd => VisitBITAND(pExpr as ExprBinOp), 
				ExpressionKind.BitwiseOr => VisitBITOR(pExpr as ExprBinOp), 
				ExpressionKind.BitwiseExclusiveOr => VisitBITXOR(pExpr as ExprBinOp), 
				ExpressionKind.LeftShirt => VisitLSHIFT(pExpr as ExprBinOp), 
				ExpressionKind.RightShift => VisitRSHIFT(pExpr as ExprBinOp), 
				ExpressionKind.LogicalAnd => VisitLOGAND(pExpr as ExprBinOp), 
				ExpressionKind.LogicalOr => VisitLOGOR(pExpr as ExprBinOp), 
				ExpressionKind.Sequence => VisitSEQUENCE(pExpr as ExprBinOp), 
				ExpressionKind.Save => VisitSAVE(pExpr as ExprBinOp), 
				ExpressionKind.Swap => VisitSWAP(pExpr as ExprBinOp), 
				ExpressionKind.Indir => VisitINDIR(pExpr as ExprBinOp), 
				ExpressionKind.StringEq => VisitSTRINGEQ(pExpr as ExprBinOp), 
				ExpressionKind.StringNotEq => VisitSTRINGNE(pExpr as ExprBinOp), 
				ExpressionKind.DelegateEq => VisitDELEGATEEQ(pExpr as ExprBinOp), 
				ExpressionKind.DelegateNotEq => VisitDELEGATENE(pExpr as ExprBinOp), 
				ExpressionKind.DelegateAdd => VisitDELEGATEADD(pExpr as ExprBinOp), 
				ExpressionKind.DelegateSubtract => VisitDELEGATESUB(pExpr as ExprBinOp), 
				ExpressionKind.Eq => VisitEQ(pExpr as ExprBinOp), 
				ExpressionKind.True => VisitTRUE(pExpr as ExprUnaryOp), 
				ExpressionKind.False => VisitFALSE(pExpr as ExprUnaryOp), 
				ExpressionKind.Inc => VisitINC(pExpr as ExprUnaryOp), 
				ExpressionKind.Dec => VisitDEC(pExpr as ExprUnaryOp), 
				ExpressionKind.LogicalNot => VisitLOGNOT(pExpr as ExprUnaryOp), 
				ExpressionKind.Negate => VisitNEG(pExpr as ExprUnaryOp), 
				ExpressionKind.UnaryPlus => VisitUPLUS(pExpr as ExprUnaryOp), 
				ExpressionKind.BitwiseNot => VisitBITNOT(pExpr as ExprUnaryOp), 
				ExpressionKind.Addr => VisitADDR(pExpr as ExprUnaryOp), 
				ExpressionKind.DecimalNegate => VisitDECIMALNEG(pExpr as ExprUnaryOp), 
				ExpressionKind.DecimalInc => VisitDECIMALINC(pExpr as ExprUnaryOp), 
				ExpressionKind.DecimalDec => VisitDECIMALDEC(pExpr as ExprUnaryOp), 
				_ => throw Error.InternalCompilerError(), 
			};
		}

		private void VisitChildren(Expr pExpr)
		{
			switch (pExpr.Kind)
			{
			case ExpressionKind.List:
			{
				ExprList exprList = (ExprList)pExpr;
				Expr optionalNextListNode;
				while (true)
				{
					exprList.OptionalElement = Visit(exprList.OptionalElement);
					optionalNextListNode = exprList.OptionalNextListNode;
					if (optionalNextListNode == null)
					{
						return;
					}
					if (!(optionalNextListNode is ExprList exprList2))
					{
						break;
					}
					exprList = exprList2;
				}
				exprList.OptionalNextListNode = Visit(optionalNextListNode);
				break;
			}
			case ExpressionKind.Assignment:
			{
				Expr optionalLeftChild = Visit((pExpr as ExprAssignment).LHS);
				(pExpr as ExprAssignment).LHS = optionalLeftChild;
				optionalLeftChild = Visit((pExpr as ExprAssignment).RHS);
				(pExpr as ExprAssignment).RHS = optionalLeftChild;
				break;
			}
			case ExpressionKind.ArrayIndex:
			{
				Expr optionalLeftChild = Visit((pExpr as ExprArrayIndex).Array);
				(pExpr as ExprArrayIndex).Array = optionalLeftChild;
				optionalLeftChild = Visit((pExpr as ExprArrayIndex).Index);
				(pExpr as ExprArrayIndex).Index = optionalLeftChild;
				break;
			}
			case ExpressionKind.UnaryOp:
			case ExpressionKind.True:
			case ExpressionKind.False:
			case ExpressionKind.Inc:
			case ExpressionKind.Dec:
			case ExpressionKind.LogicalNot:
			case ExpressionKind.Negate:
			case ExpressionKind.UnaryPlus:
			case ExpressionKind.BitwiseNot:
			case ExpressionKind.Addr:
			case ExpressionKind.DecimalNegate:
			case ExpressionKind.DecimalInc:
			case ExpressionKind.DecimalDec:
			{
				Expr optionalLeftChild = Visit((pExpr as ExprUnaryOp).Child);
				(pExpr as ExprUnaryOp).Child = optionalLeftChild;
				break;
			}
			case ExpressionKind.UserLogicalOp:
			{
				Expr optionalLeftChild = Visit((pExpr as ExprUserLogicalOp).TrueFalseCall);
				(pExpr as ExprUserLogicalOp).TrueFalseCall = optionalLeftChild;
				optionalLeftChild = Visit((pExpr as ExprUserLogicalOp).OperatorCall);
				(pExpr as ExprUserLogicalOp).OperatorCall = optionalLeftChild as ExprCall;
				optionalLeftChild = Visit((pExpr as ExprUserLogicalOp).FirstOperandToExamine);
				(pExpr as ExprUserLogicalOp).FirstOperandToExamine = optionalLeftChild;
				break;
			}
			case ExpressionKind.Cast:
			{
				Expr optionalLeftChild = Visit((pExpr as ExprCast).Argument);
				(pExpr as ExprCast).Argument = optionalLeftChild;
				break;
			}
			case ExpressionKind.UserDefinedConversion:
			{
				Expr optionalLeftChild = Visit((pExpr as ExprUserDefinedConversion).UserDefinedCall);
				(pExpr as ExprUserDefinedConversion).UserDefinedCall = optionalLeftChild;
				break;
			}
			case ExpressionKind.MemberGroup:
			{
				Expr optionalLeftChild = Visit((pExpr as ExprMemberGroup).OptionalObject);
				(pExpr as ExprMemberGroup).OptionalObject = optionalLeftChild;
				break;
			}
			case ExpressionKind.Call:
			{
				Expr optionalLeftChild = Visit((pExpr as ExprCall).OptionalArguments);
				(pExpr as ExprCall).OptionalArguments = optionalLeftChild;
				optionalLeftChild = Visit((pExpr as ExprCall).MemberGroup);
				(pExpr as ExprCall).MemberGroup = optionalLeftChild as ExprMemberGroup;
				break;
			}
			case ExpressionKind.Property:
			{
				Expr optionalLeftChild = Visit((pExpr as ExprProperty).OptionalArguments);
				(pExpr as ExprProperty).OptionalArguments = optionalLeftChild;
				optionalLeftChild = Visit((pExpr as ExprProperty).MemberGroup);
				(pExpr as ExprProperty).MemberGroup = optionalLeftChild as ExprMemberGroup;
				break;
			}
			case ExpressionKind.Field:
			{
				Expr optionalLeftChild = Visit((pExpr as ExprField).OptionalObject);
				(pExpr as ExprField).OptionalObject = optionalLeftChild;
				break;
			}
			case ExpressionKind.Constant:
			{
				Expr optionalLeftChild = Visit((pExpr as ExprConstant).OptionalConstructorCall);
				(pExpr as ExprConstant).OptionalConstructorCall = optionalLeftChild;
				break;
			}
			case ExpressionKind.Multi:
			{
				Expr optionalLeftChild = Visit((pExpr as ExprMulti).Left);
				(pExpr as ExprMulti).Left = optionalLeftChild;
				optionalLeftChild = Visit((pExpr as ExprMulti).Operator);
				(pExpr as ExprMulti).Operator = optionalLeftChild;
				break;
			}
			case ExpressionKind.Concat:
			{
				Expr optionalLeftChild = Visit((pExpr as ExprConcat).FirstArgument);
				(pExpr as ExprConcat).FirstArgument = optionalLeftChild;
				optionalLeftChild = Visit((pExpr as ExprConcat).SecondArgument);
				(pExpr as ExprConcat).SecondArgument = optionalLeftChild;
				break;
			}
			case ExpressionKind.ArrayInit:
			{
				Expr optionalLeftChild = Visit((pExpr as ExprArrayInit).OptionalArguments);
				(pExpr as ExprArrayInit).OptionalArguments = optionalLeftChild;
				optionalLeftChild = Visit((pExpr as ExprArrayInit).OptionalArgumentDimensions);
				(pExpr as ExprArrayInit).OptionalArgumentDimensions = optionalLeftChild;
				break;
			}
			default:
			{
				Expr optionalLeftChild = Visit((pExpr as ExprBinOp).OptionalLeftChild);
				(pExpr as ExprBinOp).OptionalLeftChild = optionalLeftChild;
				optionalLeftChild = Visit((pExpr as ExprBinOp).OptionalRightChild);
				(pExpr as ExprBinOp).OptionalRightChild = optionalLeftChild;
				break;
			}
			case ExpressionKind.NoOp:
			case ExpressionKind.Local:
			case ExpressionKind.Class:
			case ExpressionKind.MultiGet:
			case ExpressionKind.Wrap:
			case ExpressionKind.TypeOf:
			case ExpressionKind.ZeroInit:
			case ExpressionKind.FieldInfo:
			case ExpressionKind.MethodInfo:
				break;
			}
		}

		protected virtual Expr VisitEXPR(Expr pExpr)
		{
			VisitChildren(pExpr);
			return pExpr;
		}

		protected virtual Expr VisitBINOP(ExprBinOp pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitLIST(ExprList pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitASSIGNMENT(ExprAssignment pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitARRAYINDEX(ExprArrayIndex pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitUNARYOP(ExprUnaryOp pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitUSERLOGOP(ExprUserLogicalOp pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitTYPEOF(ExprTypeOf pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitCAST(ExprCast pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitUSERDEFINEDCONVERSION(ExprUserDefinedConversion pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitZEROINIT(ExprZeroInit pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitMEMGRP(ExprMemberGroup pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitCALL(ExprCall pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitPROP(ExprProperty pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitFIELD(ExprField pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitLOCAL(ExprLocal pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitCONSTANT(ExprConstant pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitMULTIGET(ExprMultiGet pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitMULTI(ExprMulti pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitWRAP(ExprWrap pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitCONCAT(ExprConcat pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitARRINIT(ExprArrayInit pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitFIELDINFO(ExprFieldInfo pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitMETHODINFO(ExprMethodInfo pExpr)
		{
			return VisitEXPR(pExpr);
		}

		protected virtual Expr VisitEQUALS(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitCOMPARE(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitEQ(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitNE(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitLE(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitGE(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitADD(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitSUB(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitDIV(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitBITAND(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitBITOR(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitLSHIFT(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitLOGAND(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitSEQUENCE(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitSAVE(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitINDIR(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitSTRINGEQ(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitDELEGATEEQ(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitDELEGATEADD(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitLT(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitMUL(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitBITXOR(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitRSHIFT(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitLOGOR(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitSTRINGNE(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitDELEGATENE(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitGT(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitMOD(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitSWAP(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitDELEGATESUB(ExprBinOp pExpr)
		{
			return VisitBINOP(pExpr);
		}

		protected virtual Expr VisitTRUE(ExprUnaryOp pExpr)
		{
			return VisitUNARYOP(pExpr);
		}

		protected virtual Expr VisitINC(ExprUnaryOp pExpr)
		{
			return VisitUNARYOP(pExpr);
		}

		protected virtual Expr VisitLOGNOT(ExprUnaryOp pExpr)
		{
			return VisitUNARYOP(pExpr);
		}

		protected virtual Expr VisitNEG(ExprUnaryOp pExpr)
		{
			return VisitUNARYOP(pExpr);
		}

		protected virtual Expr VisitBITNOT(ExprUnaryOp pExpr)
		{
			return VisitUNARYOP(pExpr);
		}

		protected virtual Expr VisitADDR(ExprUnaryOp pExpr)
		{
			return VisitUNARYOP(pExpr);
		}

		protected virtual Expr VisitDECIMALNEG(ExprUnaryOp pExpr)
		{
			return VisitUNARYOP(pExpr);
		}

		protected virtual Expr VisitDECIMALDEC(ExprUnaryOp pExpr)
		{
			return VisitUNARYOP(pExpr);
		}

		protected virtual Expr VisitFALSE(ExprUnaryOp pExpr)
		{
			return VisitUNARYOP(pExpr);
		}

		protected virtual Expr VisitDEC(ExprUnaryOp pExpr)
		{
			return VisitUNARYOP(pExpr);
		}

		protected virtual Expr VisitUPLUS(ExprUnaryOp pExpr)
		{
			return VisitUNARYOP(pExpr);
		}

		protected virtual Expr VisitDECIMALINC(ExprUnaryOp pExpr)
		{
			return VisitUNARYOP(pExpr);
		}
	}
	internal sealed class ExpressionTreeRewriter : ExprVisitorBase
	{
		public static ExprBinOp Rewrite(ExprBoundLambda expr)
		{
			return new ExpressionTreeRewriter().VisitBoundLambda(expr);
		}

		protected override Expr Dispatch(Expr expr)
		{
			Expr expr2 = base.Dispatch(expr);
			if (expr2 == expr)
			{
				throw Error.InternalCompilerError();
			}
			return expr2;
		}

		protected override Expr VisitASSIGNMENT(ExprAssignment assignment)
		{
			Expr arg;
			if (assignment.LHS is ExprProperty exprProperty)
			{
				if (exprProperty.OptionalArguments == null)
				{
					arg = Visit(exprProperty);
				}
				else
				{
					Expr arg2 = Visit(exprProperty.MemberGroup.OptionalObject);
					Expr arg3 = ExprFactory.CreatePropertyInfo(exprProperty.PropWithTypeSlot.Prop(), exprProperty.PropWithTypeSlot.Ats);
					Expr arg4 = GenerateParamsArray(GenerateArgsList(exprProperty.OptionalArguments), PredefinedType.PT_EXPRESSION);
					arg = GenerateCall(PREDEFMETH.PM_EXPRESSION_PROPERTY, arg2, arg3, arg4);
				}
			}
			else
			{
				arg = Visit(assignment.LHS);
			}
			Expr arg5 = Visit(assignment.RHS);
			return GenerateCall(PREDEFMETH.PM_EXPRESSION_ASSIGN, arg, arg5);
		}

		protected override Expr VisitMULTIGET(ExprMultiGet pExpr)
		{
			return Visit(pExpr.OptionalMulti.Left);
		}

		protected override Expr VisitMULTI(ExprMulti pExpr)
		{
			Expr arg = Visit(pExpr.Operator);
			Expr arg2 = Visit(pExpr.Left);
			return GenerateCall(PREDEFMETH.PM_EXPRESSION_ASSIGN, arg2, arg);
		}

		private ExprBinOp VisitBoundLambda(ExprBoundLambda anonmeth)
		{
			MethodSymbol preDefMethod = GetPreDefMethod(PREDEFMETH.PM_EXPRESSION_LAMBDA);
			AggregateType delegateType = anonmeth.DelegateType;
			TypeArray typeArgs = TypeArray.Allocate(delegateType);
			AggregateType predefindType = SymbolLoader.GetPredefindType(PredefinedType.PT_EXPRESSION);
			MethWithInst methWithInst = new MethWithInst(preDefMethod, predefindType, typeArgs);
			Expr first = CreateWraps(anonmeth);
			Expr op = Visit(anonmeth.Expression);
			Expr op2 = GenerateParamsArray(null, PredefinedType.PT_PARAMETEREXPRESSION);
			Expr arguments = ExprFactory.CreateList(op, op2);
			CType type = TypeManager.SubstType(methWithInst.Meth().RetType, methWithInst.GetType(), methWithInst.TypeArgs);
			ExprMemberGroup memberGroup = ExprFactory.CreateMemGroup(null, methWithInst);
			ExprCall exprCall = ExprFactory.CreateCall((EXPRFLAG)0, type, arguments, memberGroup, methWithInst);
			exprCall.PredefinedMethod = PREDEFMETH.PM_EXPRESSION_LAMBDA;
			return ExprFactory.CreateSequence(first, exprCall);
		}

		protected override Expr VisitCONSTANT(ExprConstant expr)
		{
			return GenerateConstant(expr);
		}

		protected override Expr VisitLOCAL(ExprLocal local)
		{
			return local.Local.wrap;
		}

		protected override Expr VisitFIELD(ExprField expr)
		{
			Expr arg = ((expr.OptionalObject != null) ? Visit(expr.OptionalObject) : ExprFactory.CreateNull());
			ExprFieldInfo arg2 = ExprFactory.CreateFieldInfo(expr.FieldWithType.Field(), expr.FieldWithType.GetType());
			return GenerateCall(PREDEFMETH.PM_EXPRESSION_FIELD, arg, arg2);
		}

		protected override Expr VisitUSERDEFINEDCONVERSION(ExprUserDefinedConversion expr)
		{
			return GenerateUserDefinedConversion(expr, expr.Argument);
		}

		protected override Expr VisitCAST(ExprCast pExpr)
		{
			Expr argument = pExpr.Argument;
			if (argument.Type == pExpr.Type || SymbolLoader.IsBaseClassOfClass(argument.Type, pExpr.Type) || CConversions.FImpRefConv(argument.Type, pExpr.Type))
			{
				return Visit(argument);
			}
			if (pExpr.Type != null && pExpr.Type.IsPredefType(PredefinedType.PT_G_EXPRESSION) && argument is ExprBoundLambda)
			{
				return Visit(argument);
			}
			Expr expr = GenerateConversion(argument, pExpr.Type, pExpr.isChecked());
			if ((pExpr.Flags & EXPRFLAG.EXF_USERCALLABLE) != 0)
			{
				expr.Flags |= EXPRFLAG.EXF_USERCALLABLE;
			}
			return expr;
		}

		protected override Expr VisitCONCAT(ExprConcat expr)
		{
			PREDEFMETH pdm = ((!expr.FirstArgument.Type.IsPredefType(PredefinedType.PT_STRING) || !expr.SecondArgument.Type.IsPredefType(PredefinedType.PT_STRING)) ? PREDEFMETH.PM_STRING_CONCAT_OBJECT_2 : PREDEFMETH.PM_STRING_CONCAT_STRING_2);
			Expr arg = Visit(expr.FirstArgument);
			Expr arg2 = Visit(expr.SecondArgument);
			Expr arg3 = ExprFactory.CreateMethodInfo(GetPreDefMethod(pdm), SymbolLoader.GetPredefindType(PredefinedType.PT_STRING), null);
			return GenerateCall(PREDEFMETH.PM_EXPRESSION_ADD_USER_DEFINED, arg, arg2, arg3);
		}

		protected override Expr VisitBINOP(ExprBinOp expr)
		{
			if (expr.UserDefinedCallMethod != null)
			{
				return GenerateUserDefinedBinaryOperator(expr);
			}
			return GenerateBuiltInBinaryOperator(expr);
		}

		protected override Expr VisitUNARYOP(ExprUnaryOp pExpr)
		{
			if (pExpr.UserDefinedCallMethod != null)
			{
				return GenerateUserDefinedUnaryOperator(pExpr);
			}
			return GenerateBuiltInUnaryOperator(pExpr);
		}

		protected override Expr VisitARRAYINDEX(ExprArrayIndex pExpr)
		{
			Expr arg = Visit(pExpr.Array);
			Expr expr = GenerateIndexList(pExpr.Index);
			if (expr is ExprList)
			{
				Expr arg2 = GenerateParamsArray(expr, PredefinedType.PT_EXPRESSION);
				return GenerateCall(PREDEFMETH.PM_EXPRESSION_ARRAYINDEX2, arg, arg2);
			}
			return GenerateCall(PREDEFMETH.PM_EXPRESSION_ARRAYINDEX, arg, expr);
		}

		protected override Expr VisitCALL(ExprCall expr)
		{
			switch (expr.NullableCallLiftKind)
			{
			case NullableCallLiftKind.NullableConversion:
			case NullableCallLiftKind.NullableConversionConstructor:
			case NullableCallLiftKind.NullableIntermediateConversion:
				return GenerateConversion(expr.OptionalArguments, expr.Type, expr.isChecked());
			case NullableCallLiftKind.UserDefinedConversion:
			case NullableCallLiftKind.NotLiftedIntermediateConversion:
				return GenerateUserDefinedConversion(expr.OptionalArguments, expr.Type, expr.MethWithInst);
			default:
			{
				if (expr.MethWithInst.Meth().IsConstructor())
				{
					return GenerateConstructor(expr);
				}
				if (expr.MemberGroup.IsDelegate)
				{
					return GenerateDelegateInvoke(expr);
				}
				Expr arg;
				if (expr.MethWithInst.Meth().isStatic || expr.MemberGroup.OptionalObject == null)
				{
					arg = ExprFactory.CreateNull();
				}
				else
				{
					arg = expr.MemberGroup.OptionalObject;
					if (arg != null && arg is ExprCast { IsBoxingCast: not false } exprCast)
					{
						arg = exprCast.Argument;
					}
					arg = Visit(arg);
				}
				Expr arg2 = ExprFactory.CreateMethodInfo(expr.MethWithInst);
				Expr arg3 = GenerateParamsArray(GenerateArgsList(expr.OptionalArguments), PredefinedType.PT_EXPRESSION);
				return GenerateCall(PREDEFMETH.PM_EXPRESSION_CALL, arg, arg2, arg3);
			}
			}
		}

		protected override Expr VisitPROP(ExprProperty expr)
		{
			Expr arg = ((!expr.PropWithTypeSlot.Prop().isStatic && expr.MemberGroup.OptionalObject != null) ? Visit(expr.MemberGroup.OptionalObject) : ExprFactory.CreateNull());
			Expr arg2 = ExprFactory.CreatePropertyInfo(expr.PropWithTypeSlot.Prop(), expr.PropWithTypeSlot.GetType());
			if (expr.OptionalArguments != null)
			{
				Expr arg3 = GenerateParamsArray(GenerateArgsList(expr.OptionalArguments), PredefinedType.PT_EXPRESSION);
				return GenerateCall(PREDEFMETH.PM_EXPRESSION_PROPERTY, arg, arg2, arg3);
			}
			return GenerateCall(PREDEFMETH.PM_EXPRESSION_PROPERTY, arg, arg2);
		}

		protected override Expr VisitARRINIT(ExprArrayInit expr)
		{
			Expr arg = CreateTypeOf(((ArrayType)expr.Type).ElementType);
			Expr arg2 = GenerateParamsArray(GenerateArgsList(expr.OptionalArguments), PredefinedType.PT_EXPRESSION);
			return GenerateCall(PREDEFMETH.PM_EXPRESSION_NEWARRAYINIT, arg, arg2);
		}

		protected override Expr VisitZEROINIT(ExprZeroInit expr)
		{
			return GenerateConstant(expr);
		}

		protected override Expr VisitTYPEOF(ExprTypeOf expr)
		{
			return GenerateConstant(expr);
		}

		private Expr GenerateDelegateInvoke(ExprCall expr)
		{
			Expr optionalObject = expr.MemberGroup.OptionalObject;
			Expr arg = Visit(optionalObject);
			Expr arg2 = GenerateParamsArray(GenerateArgsList(expr.OptionalArguments), PredefinedType.PT_EXPRESSION);
			return GenerateCall(PREDEFMETH.PM_EXPRESSION_INVOKE, arg, arg2);
		}

		private Expr GenerateBuiltInBinaryOperator(ExprBinOp expr)
		{
			PREDEFMETH pdm = expr.Kind switch
			{
				ExpressionKind.LeftShirt => PREDEFMETH.PM_EXPRESSION_LEFTSHIFT, 
				ExpressionKind.RightShift => PREDEFMETH.PM_EXPRESSION_RIGHTSHIFT, 
				ExpressionKind.BitwiseExclusiveOr => PREDEFMETH.PM_EXPRESSION_EXCLUSIVEOR, 
				ExpressionKind.BitwiseOr => PREDEFMETH.PM_EXPRESSION_OR, 
				ExpressionKind.BitwiseAnd => PREDEFMETH.PM_EXPRESSION_AND, 
				ExpressionKind.LogicalAnd => PREDEFMETH.PM_EXPRESSION_ANDALSO, 
				ExpressionKind.LogicalOr => PREDEFMETH.PM_EXPRESSION_ORELSE, 
				ExpressionKind.StringEq => PREDEFMETH.PM_EXPRESSION_EQUAL, 
				ExpressionKind.Eq => PREDEFMETH.PM_EXPRESSION_EQUAL, 
				ExpressionKind.StringNotEq => PREDEFMETH.PM_EXPRESSION_NOTEQUAL, 
				ExpressionKind.NotEq => PREDEFMETH.PM_EXPRESSION_NOTEQUAL, 
				ExpressionKind.GreaterThanOrEqual => PREDEFMETH.PM_EXPRESSION_GREATERTHANOREQUAL, 
				ExpressionKind.LessThanOrEqual => PREDEFMETH.PM_EXPRESSION_LESSTHANOREQUAL, 
				ExpressionKind.LessThan => PREDEFMETH.PM_EXPRESSION_LESSTHAN, 
				ExpressionKind.GreaterThan => PREDEFMETH.PM_EXPRESSION_GREATERTHAN, 
				ExpressionKind.Modulo => PREDEFMETH.PM_EXPRESSION_MODULO, 
				ExpressionKind.Divide => PREDEFMETH.PM_EXPRESSION_DIVIDE, 
				ExpressionKind.Multiply => expr.isChecked() ? PREDEFMETH.PM_EXPRESSION_MULTIPLYCHECKED : PREDEFMETH.PM_EXPRESSION_MULTIPLY, 
				ExpressionKind.Subtract => expr.isChecked() ? PREDEFMETH.PM_EXPRESSION_SUBTRACTCHECKED : PREDEFMETH.PM_EXPRESSION_SUBTRACT, 
				ExpressionKind.Add => expr.isChecked() ? PREDEFMETH.PM_EXPRESSION_ADDCHECKED : PREDEFMETH.PM_EXPRESSION_ADD, 
				_ => throw Error.InternalCompilerError(), 
			};
			Expr optionalLeftChild = expr.OptionalLeftChild;
			Expr optionalRightChild = expr.OptionalRightChild;
			CType cType = optionalLeftChild.Type;
			CType cType2 = optionalRightChild.Type;
			Expr arg = Visit(optionalLeftChild);
			Expr expr2 = Visit(optionalRightChild);
			bool flag = false;
			CType cType3 = null;
			CType cType4 = null;
			if (cType.IsEnumType)
			{
				cType3 = TypeManager.GetNullable(cType.UnderlyingEnumType);
				cType = cType3;
				flag = true;
			}
			else if (cType is NullableType nullableType && nullableType.UnderlyingType.IsEnumType)
			{
				cType3 = TypeManager.GetNullable(nullableType.UnderlyingType.UnderlyingEnumType);
				cType = cType3;
				flag = true;
			}
			if (cType2.IsEnumType)
			{
				cType4 = TypeManager.GetNullable(cType2.UnderlyingEnumType);
				cType2 = cType4;
				flag = true;
			}
			else if (cType2 is NullableType nullableType2 && nullableType2.UnderlyingType.IsEnumType)
			{
				cType4 = TypeManager.GetNullable(nullableType2.UnderlyingType.UnderlyingEnumType);
				cType2 = cType4;
				flag = true;
			}
			if (cType is NullableType nullableType3 && nullableType3.UnderlyingType == cType2)
			{
				cType4 = cType;
			}
			if (cType2 is NullableType nullableType4 && nullableType4.UnderlyingType == cType)
			{
				cType3 = cType2;
			}
			if (cType3 != null)
			{
				arg = GenerateCall(PREDEFMETH.PM_EXPRESSION_CONVERT, arg, CreateTypeOf(cType3));
			}
			if (cType4 != null)
			{
				expr2 = GenerateCall(PREDEFMETH.PM_EXPRESSION_CONVERT, expr2, CreateTypeOf(cType4));
			}
			Expr expr3 = GenerateCall(pdm, arg, expr2);
			if (flag && expr.Type.StripNubs().IsEnumType)
			{
				expr3 = GenerateCall(PREDEFMETH.PM_EXPRESSION_CONVERT, expr3, CreateTypeOf(expr.Type));
			}
			return expr3;
		}

		private Expr GenerateBuiltInUnaryOperator(ExprUnaryOp expr)
		{
			PREDEFMETH pdm;
			switch (expr.Kind)
			{
			case ExpressionKind.UnaryPlus:
				return Visit(expr.Child);
			case ExpressionKind.BitwiseNot:
				pdm = PREDEFMETH.PM_EXPRESSION_NOT;
				break;
			case ExpressionKind.LogicalNot:
				pdm = PREDEFMETH.PM_EXPRESSION_NOT;
				break;
			case ExpressionKind.Negate:
				pdm = (expr.isChecked() ? PREDEFMETH.PM_EXPRESSION_NEGATECHECKED : PREDEFMETH.PM_EXPRESSION_NEGATE);
				break;
			default:
				throw Error.InternalCompilerError();
			}
			Expr child = expr.Child;
			return GenerateCall(pdm, Visit(child));
		}

		private Expr GenerateUserDefinedBinaryOperator(ExprBinOp expr)
		{
			PREDEFMETH pdm;
			switch (expr.Kind)
			{
			case ExpressionKind.LogicalOr:
				pdm = PREDEFMETH.PM_EXPRESSION_ORELSE_USER_DEFINED;
				break;
			case ExpressionKind.LogicalAnd:
				pdm = PREDEFMETH.PM_EXPRESSION_ANDALSO_USER_DEFINED;
				break;
			case ExpressionKind.LeftShirt:
				pdm = PREDEFMETH.PM_EXPRESSION_LEFTSHIFT_USER_DEFINED;
				break;
			case ExpressionKind.RightShift:
				pdm = PREDEFMETH.PM_EXPRESSION_RIGHTSHIFT_USER_DEFINED;
				break;
			case ExpressionKind.BitwiseExclusiveOr:
				pdm = PREDEFMETH.PM_EXPRESSION_EXCLUSIVEOR_USER_DEFINED;
				break;
			case ExpressionKind.BitwiseOr:
				pdm = PREDEFMETH.PM_EXPRESSION_OR_USER_DEFINED;
				break;
			case ExpressionKind.BitwiseAnd:
				pdm = PREDEFMETH.PM_EXPRESSION_AND_USER_DEFINED;
				break;
			case ExpressionKind.Modulo:
				pdm = PREDEFMETH.PM_EXPRESSION_MODULO_USER_DEFINED;
				break;
			case ExpressionKind.Divide:
				pdm = PREDEFMETH.PM_EXPRESSION_DIVIDE_USER_DEFINED;
				break;
			case ExpressionKind.Eq:
			case ExpressionKind.NotEq:
			case ExpressionKind.LessThan:
			case ExpressionKind.LessThanOrEqual:
			case ExpressionKind.GreaterThan:
			case ExpressionKind.GreaterThanOrEqual:
			case ExpressionKind.StringEq:
			case ExpressionKind.StringNotEq:
			case ExpressionKind.DelegateEq:
			case ExpressionKind.DelegateNotEq:
				return GenerateUserDefinedComparisonOperator(expr);
			case ExpressionKind.Subtract:
			case ExpressionKind.DelegateSubtract:
				pdm = (expr.isChecked() ? PREDEFMETH.PM_EXPRESSION_SUBTRACTCHECKED_USER_DEFINED : PREDEFMETH.PM_EXPRESSION_SUBTRACT_USER_DEFINED);
				break;
			case ExpressionKind.Add:
			case ExpressionKind.DelegateAdd:
				pdm = (expr.isChecked() ? PREDEFMETH.PM_EXPRESSION_ADDCHECKED_USER_DEFINED : PREDEFMETH.PM_EXPRESSION_ADD_USER_DEFINED);
				break;
			case ExpressionKind.Multiply:
				pdm = (expr.isChecked() ? PREDEFMETH.PM_EXPRESSION_MULTIPLYCHECKED_USER_DEFINED : PREDEFMETH.PM_EXPRESSION_MULTIPLY_USER_DEFINED);
				break;
			default:
				throw Error.InternalCompilerError();
			}
			Expr pExpr = expr.OptionalLeftChild;
			Expr pExpr2 = expr.OptionalRightChild;
			Expr optionalUserDefinedCall = expr.OptionalUserDefinedCall;
			if (optionalUserDefinedCall != null)
			{
				if (optionalUserDefinedCall is ExprCall exprCall)
				{
					ExprList obj = (ExprList)exprCall.OptionalArguments;
					pExpr = obj.OptionalElement;
					pExpr2 = obj.OptionalNextListNode;
				}
				else
				{
					ExprList obj2 = (ExprList)(optionalUserDefinedCall as ExprUserLogicalOp).OperatorCall.OptionalArguments;
					pExpr = ((ExprWrap)obj2.OptionalElement).OptionalExpression;
					pExpr2 = obj2.OptionalNextListNode;
				}
			}
			pExpr = Visit(pExpr);
			pExpr2 = Visit(pExpr2);
			FixLiftedUserDefinedBinaryOperators(expr, ref pExpr, ref pExpr2);
			Expr arg = ExprFactory.CreateMethodInfo(expr.UserDefinedCallMethod);
			Expr expr2 = GenerateCall(pdm, pExpr, pExpr2, arg);
			if (expr.Kind == ExpressionKind.DelegateSubtract || expr.Kind == ExpressionKind.DelegateAdd)
			{
				Expr arg2 = CreateTypeOf(expr.Type);
				return GenerateCall(PREDEFMETH.PM_EXPRESSION_CONVERT, expr2, arg2);
			}
			return expr2;
		}

		private Expr GenerateUserDefinedUnaryOperator(ExprUnaryOp expr)
		{
			Expr pExpr = expr.Child;
			ExprCall exprCall = (ExprCall)expr.OptionalUserDefinedCall;
			if (exprCall != null)
			{
				pExpr = exprCall.OptionalArguments;
			}
			PREDEFMETH pdm;
			switch (expr.Kind)
			{
			case ExpressionKind.True:
			case ExpressionKind.False:
				return Visit(exprCall);
			case ExpressionKind.UnaryPlus:
				pdm = PREDEFMETH.PM_EXPRESSION_UNARYPLUS_USER_DEFINED;
				break;
			case ExpressionKind.BitwiseNot:
				pdm = PREDEFMETH.PM_EXPRESSION_NOT_USER_DEFINED;
				break;
			case ExpressionKind.LogicalNot:
				pdm = PREDEFMETH.PM_EXPRESSION_NOT_USER_DEFINED;
				break;
			case ExpressionKind.Negate:
			case ExpressionKind.DecimalNegate:
				pdm = (expr.isChecked() ? PREDEFMETH.PM_EXPRESSION_NEGATECHECKED_USER_DEFINED : PREDEFMETH.PM_EXPRESSION_NEGATE_USER_DEFINED);
				break;
			case ExpressionKind.Inc:
			case ExpressionKind.Dec:
			case ExpressionKind.DecimalInc:
			case ExpressionKind.DecimalDec:
				pdm = PREDEFMETH.PM_EXPRESSION_CALL;
				break;
			default:
				throw Error.InternalCompilerError();
			}
			Expr expr2 = Visit(pExpr);
			Expr arg = ExprFactory.CreateMethodInfo(expr.UserDefinedCallMethod);
			if (expr.Kind == ExpressionKind.Inc || expr.Kind == ExpressionKind.Dec || expr.Kind == ExpressionKind.DecimalInc || expr.Kind == ExpressionKind.DecimalDec)
			{
				return GenerateCall(pdm, null, arg, GenerateParamsArray(expr2, PredefinedType.PT_EXPRESSION));
			}
			return GenerateCall(pdm, expr2, arg);
		}

		private Expr GenerateUserDefinedComparisonOperator(ExprBinOp expr)
		{
			PREDEFMETH pdm = expr.Kind switch
			{
				ExpressionKind.StringEq => PREDEFMETH.PM_EXPRESSION_EQUAL_USER_DEFINED, 
				ExpressionKind.StringNotEq => PREDEFMETH.PM_EXPRESSION_NOTEQUAL_USER_DEFINED, 
				ExpressionKind.DelegateEq => PREDEFMETH.PM_EXPRESSION_EQUAL_USER_DEFINED, 
				ExpressionKind.DelegateNotEq => PREDEFMETH.PM_EXPRESSION_NOTEQUAL_USER_DEFINED, 
				ExpressionKind.Eq => PREDEFMETH.PM_EXPRESSION_EQUAL_USER_DEFINED, 
				ExpressionKind.NotEq => PREDEFMETH.PM_EXPRESSION_NOTEQUAL_USER_DEFINED, 
				ExpressionKind.LessThanOrEqual => PREDEFMETH.PM_EXPRESSION_LESSTHANOREQUAL_USER_DEFINED, 
				ExpressionKind.LessThan => PREDEFMETH.PM_EXPRESSION_LESSTHAN_USER_DEFINED, 
				ExpressionKind.GreaterThanOrEqual => PREDEFMETH.PM_EXPRESSION_GREATERTHANOREQUAL_USER_DEFINED, 
				ExpressionKind.GreaterThan => PREDEFMETH.PM_EXPRESSION_GREATERTHAN_USER_DEFINED, 
				_ => throw Error.InternalCompilerError(), 
			};
			Expr pExpr = expr.OptionalLeftChild;
			Expr pExpr2 = expr.OptionalRightChild;
			if (expr.OptionalUserDefinedCall != null)
			{
				ExprList obj = (ExprList)((ExprCall)expr.OptionalUserDefinedCall).OptionalArguments;
				pExpr = obj.OptionalElement;
				pExpr2 = obj.OptionalNextListNode;
			}
			pExpr = Visit(pExpr);
			pExpr2 = Visit(pExpr2);
			FixLiftedUserDefinedBinaryOperators(expr, ref pExpr, ref pExpr2);
			Expr arg = ExprFactory.CreateBoolConstant(b: false);
			Expr arg2 = ExprFactory.CreateMethodInfo(expr.UserDefinedCallMethod);
			return GenerateCall(pdm, pExpr, pExpr2, arg, arg2);
		}

		private Expr GenerateConversion(Expr arg, CType CType, bool bChecked)
		{
			return GenerateConversionWithSource(Visit(arg), CType, bChecked || arg.isChecked());
		}

		private static Expr GenerateConversionWithSource(Expr pTarget, CType pType, bool bChecked)
		{
			int pdm = (bChecked ? 21 : 19);
			Expr arg = CreateTypeOf(pType);
			return GenerateCall((PREDEFMETH)pdm, pTarget, arg);
		}

		private Expr GenerateValueAccessConversion(Expr pArgument)
		{
			Expr arg = CreateTypeOf(pArgument.Type.StripNubs());
			return GenerateCall(PREDEFMETH.PM_EXPRESSION_CONVERT, Visit(pArgument), arg);
		}

		private Expr GenerateUserDefinedConversion(Expr arg, CType type, MethWithInst method)
		{
			Expr target = Visit(arg);
			return GenerateUserDefinedConversion(arg, type, target, method);
		}

		private static Expr GenerateUserDefinedConversion(Expr arg, CType CType, Expr target, MethWithInst method)
		{
			if (isEnumToDecimalConversion(arg.Type, CType))
			{
				Expr arg2 = CreateTypeOf(TypeManager.GetNullable(arg.Type.StripNubs().UnderlyingEnumType));
				target = GenerateCall(PREDEFMETH.PM_EXPRESSION_CONVERT, target, arg2);
			}
			CType cType = TypeManager.SubstType(method.Meth().RetType, method.GetType(), method.TypeArgs);
			int num;
			CType type;
			if (cType != CType)
			{
				if (IsNullableValueType(arg.Type))
				{
					num = (IsNullableValueType(CType) ? 1 : 0);
					if (num != 0)
					{
						goto IL_0076;
					}
				}
				else
				{
					num = 0;
				}
				type = cType;
				goto IL_0077;
			}
			num = 1;
			goto IL_0076;
			IL_0077:
			Expr expr = GenerateCall(arg2: CreateTypeOf(type), arg3: ExprFactory.CreateMethodInfo(method), pdm: arg.isChecked() ? PREDEFMETH.PM_EXPRESSION_CONVERTCHECKED_USER_DEFINED : PREDEFMETH.PM_EXPRESSION_CONVERT_USER_DEFINED, arg1: target);
			if (num != 0)
			{
				return expr;
			}
			int pdm = (arg.isChecked() ? 21 : 19);
			Expr arg3 = CreateTypeOf(CType);
			return GenerateCall((PREDEFMETH)pdm, expr, arg3);
			IL_0076:
			type = CType;
			goto IL_0077;
		}

		private Expr GenerateUserDefinedConversion(ExprUserDefinedConversion pExpr, Expr pArgument)
		{
			Expr userDefinedCall = pExpr.UserDefinedCall;
			Expr argument = pExpr.Argument;
			Expr target;
			if (!isEnumToDecimalConversion(pArgument.Type, pExpr.Type) && IsNullableValueAccess(argument, pArgument))
			{
				target = GenerateValueAccessConversion(pArgument);
			}
			else
			{
				ExprCall exprCall = userDefinedCall as ExprCall;
				Expr expr = exprCall?.PConversions;
				if (expr != null)
				{
					if (expr is ExprCall { OptionalArguments: var optionalArguments })
					{
						target = ((!IsNullableValueAccess(optionalArguments, pArgument)) ? Visit(optionalArguments) : GenerateValueAccessConversion(pArgument));
						return GenerateConversionWithSource(target, userDefinedCall.Type, exprCall.isChecked());
					}
					return GenerateUserDefinedConversion((ExprUserDefinedConversion)expr, pArgument);
				}
				target = Visit(argument);
			}
			return GenerateUserDefinedConversion(argument, pExpr.Type, target, pExpr.UserDefinedCallMethod);
		}

		private static Expr GenerateParameter(string name, CType CType)
		{
			SymbolLoader.GetPredefindType(PredefinedType.PT_STRING);
			ExprConstant arg = ExprFactory.CreateStringConstant(name);
			ExprTypeOf arg2 = CreateTypeOf(CType);
			return GenerateCall(PREDEFMETH.PM_EXPRESSION_PARAMETER, arg2, arg);
		}

		private static MethodSymbol GetPreDefMethod(PREDEFMETH pdm)
		{
			return PredefinedMembers.GetMethod(pdm);
		}

		private static ExprTypeOf CreateTypeOf(CType type)
		{
			return ExprFactory.CreateTypeOf(type);
		}

		private static Expr CreateWraps(ExprBoundLambda anonmeth)
		{
			Expr expr = null;
			for (Symbol symbol = anonmeth.ArgumentScope.firstChild; symbol != null; symbol = symbol.nextChild)
			{
				if (symbol is LocalVariableSymbol localVariableSymbol)
				{
					Expr expression = GenerateParameter(localVariableSymbol.name.Text, localVariableSymbol.GetType());
					localVariableSymbol.wrap = ExprFactory.CreateWrap(expression);
					Expr expr2 = ExprFactory.CreateSave(localVariableSymbol.wrap);
					expr = ((expr != null) ? ExprFactory.CreateSequence(expr, expr2) : expr2);
				}
			}
			return expr;
		}

		private Expr GenerateConstructor(ExprCall expr)
		{
			Expr arg = ExprFactory.CreateMethodInfo(expr.MethWithInst);
			Expr arg2 = GenerateParamsArray(GenerateArgsList(expr.OptionalArguments), PredefinedType.PT_EXPRESSION);
			return GenerateCall(PREDEFMETH.PM_EXPRESSION_NEW, arg, arg2);
		}

		private Expr GenerateArgsList(Expr oldArgs)
		{
			Expr first = null;
			Expr last = first;
			ExpressionIterator expressionIterator = new ExpressionIterator(oldArgs);
			while (!expressionIterator.AtEnd())
			{
				Expr pExpr = expressionIterator.Current();
				ExprFactory.AppendItemToList(Visit(pExpr), ref first, ref last);
				expressionIterator.MoveNext();
			}
			return first;
		}

		private Expr GenerateIndexList(Expr oldIndices)
		{
			CType predefindType = SymbolLoader.GetPredefindType(PredefinedType.PT_INT);
			Expr first = null;
			Expr last = first;
			ExpressionIterator expressionIterator = new ExpressionIterator(oldIndices);
			while (!expressionIterator.AtEnd())
			{
				Expr expr = expressionIterator.Current();
				if (expr.Type != predefindType)
				{
					expr = ExprFactory.CreateCast(EXPRFLAG.EXF_LITERALCONST, predefindType, expr);
					expr.Flags |= EXPRFLAG.EXF_CHECKOVERFLOW;
				}
				ExprFactory.AppendItemToList(Visit(expr), ref first, ref last);
				expressionIterator.MoveNext();
			}
			return first;
		}

		private static Expr GenerateConstant(Expr expr)
		{
			EXPRFLAG flags = (EXPRFLAG)0;
			AggregateType predefindType = SymbolLoader.GetPredefindType(PredefinedType.PT_OBJECT);
			if (expr.Type is NullType)
			{
				ExprTypeOf arg = CreateTypeOf(predefindType);
				return GenerateCall(PREDEFMETH.PM_EXPRESSION_CONSTANT_OBJECT_TYPE, expr, arg);
			}
			AggregateType predefindType2 = SymbolLoader.GetPredefindType(PredefinedType.PT_STRING);
			if (expr.Type != predefindType2)
			{
				flags = EXPRFLAG.EXF_CTOR;
			}
			ExprCast arg2 = ExprFactory.CreateCast(flags, predefindType, expr);
			ExprTypeOf arg3 = CreateTypeOf(expr.Type);
			return GenerateCall(PREDEFMETH.PM_EXPRESSION_CONSTANT_OBJECT_TYPE, arg2, arg3);
		}

		private static ExprCall GenerateCall(PREDEFMETH pdm, Expr arg1)
		{
			MethodSymbol preDefMethod = GetPreDefMethod(pdm);
			if (preDefMethod == null)
			{
				return null;
			}
			AggregateType predefindType = SymbolLoader.GetPredefindType(PredefinedType.PT_EXPRESSION);
			MethWithInst methWithInst = new MethWithInst(preDefMethod, predefindType);
			ExprMemberGroup memberGroup = ExprFactory.CreateMemGroup(null, methWithInst);
			ExprCall exprCall = ExprFactory.CreateCall((EXPRFLAG)0, methWithInst.Meth().RetType, arg1, memberGroup, methWithInst);
			exprCall.PredefinedMethod = pdm;
			return exprCall;
		}

		private static ExprCall GenerateCall(PREDEFMETH pdm, Expr arg1, Expr arg2)
		{
			MethodSymbol preDefMethod = GetPreDefMethod(pdm);
			if (preDefMethod == null)
			{
				return null;
			}
			AggregateType predefindType = SymbolLoader.GetPredefindType(PredefinedType.PT_EXPRESSION);
			Expr arguments = ExprFactory.CreateList(arg1, arg2);
			MethWithInst methWithInst = new MethWithInst(preDefMethod, predefindType);
			ExprMemberGroup memberGroup = ExprFactory.CreateMemGroup(null, methWithInst);
			ExprCall exprCall = ExprFactory.CreateCall((EXPRFLAG)0, methWithInst.Meth().RetType, arguments, memberGroup, methWithInst);
			exprCall.PredefinedMethod = pdm;
			return exprCall;
		}

		private static ExprCall GenerateCall(PREDEFMETH pdm, Expr arg1, Expr arg2, Expr arg3)
		{
			MethodSymbol preDefMethod = GetPreDefMethod(pdm);
			if (preDefMethod == null)
			{
				return null;
			}
			AggregateType predefindType = SymbolLoader.GetPredefindType(PredefinedType.PT_EXPRESSION);
			Expr arguments = ExprFactory.CreateList(arg1, arg2, arg3);
			MethWithInst methWithInst = new MethWithInst(preDefMethod, predefindType);
			ExprMemberGroup memberGroup = ExprFactory.CreateMemGroup(null, methWithInst);
			ExprCall exprCall = ExprFactory.CreateCall((EXPRFLAG)0, methWithInst.Meth().RetType, arguments, memberGroup, methWithInst);
			exprCall.PredefinedMethod = pdm;
			return exprCall;
		}

		private static ExprCall GenerateCall(PREDEFMETH pdm, Expr arg1, Expr arg2, Expr arg3, Expr arg4)
		{
			MethodSymbol preDefMethod = GetPreDefMethod(pdm);
			if (preDefMethod == null)
			{
				return null;
			}
			AggregateType predefindType = SymbolLoader.GetPredefindType(PredefinedType.PT_EXPRESSION);
			Expr arguments = ExprFactory.CreateList(arg1, arg2, arg3, arg4);
			MethWithInst methWithInst = new MethWithInst(preDefMethod, predefindType);
			ExprMemberGroup memberGroup = ExprFactory.CreateMemGroup(null, methWithInst);
			ExprCall exprCall = ExprFactory.CreateCall((EXPRFLAG)0, methWithInst.Meth().RetType, arguments, memberGroup, methWithInst);
			exprCall.PredefinedMethod = pdm;
			return exprCall;
		}

		private static ExprArrayInit GenerateParamsArray(Expr args, PredefinedType pt)
		{
			int num = ExpressionIterator.Count(args);
			ArrayType array = TypeManager.GetArray(SymbolLoader.GetPredefindType(pt), 1, isSZArray: true);
			ExprConstant argumentDimensions = ExprFactory.CreateIntegerConstant(num);
			return ExprFactory.CreateArrayInit(array, args, argumentDimensions, new int[1] { num }, num);
		}

		private static void FixLiftedUserDefinedBinaryOperators(ExprBinOp expr, ref Expr pp1, ref Expr pp2)
		{
			MethodSymbol methodSymbol = expr.UserDefinedCallMethod.Meth();
			Expr optionalLeftChild = expr.OptionalLeftChild;
			Expr optionalRightChild = expr.OptionalRightChild;
			Expr expr2 = pp1;
			Expr expr3 = pp2;
			CType cType = methodSymbol.Params[0];
			CType cType2 = methodSymbol.Params[1];
			CType type = optionalLeftChild.Type;
			CType type2 = optionalRightChild.Type;
			if (cType is AggregateType aggregateType && aggregateType.OwningAggregate.IsValueType() && cType2 is AggregateType aggregateType2 && aggregateType2.OwningAggregate.IsValueType())
			{
				CType nullable = TypeManager.GetNullable(cType);
				CType nullable2 = TypeManager.GetNullable(cType2);
				if (type is NullType || (type == cType && (type2 == nullable2 || type2 is NullType)))
				{
					expr2 = GenerateCall(PREDEFMETH.PM_EXPRESSION_CONVERT, expr2, CreateTypeOf(nullable));
				}
				if (type2 is NullType || (type2 == cType2 && (type == nullable || type is NullType)))
				{
					expr3 = GenerateCall(PREDEFMETH.PM_EXPRESSION_CONVERT, expr3, CreateTypeOf(nullable2));
				}
				pp1 = expr2;
				pp2 = expr3;
			}
		}

		private static bool IsNullableValueType(CType pType)
		{
			if (pType is NullableType && pType.StripNubs() is AggregateType aggregateType)
			{
				return aggregateType.OwningAggregate.IsValueType();
			}
			return false;
		}

		private static bool IsNullableValueAccess(Expr pExpr, Expr pObject)
		{
			if (pExpr is ExprProperty exprProperty && exprProperty.MemberGroup.OptionalObject == pObject)
			{
				return pObject.Type is NullableType;
			}
			return false;
		}

		private static bool isEnumToDecimalConversion(CType argtype, CType desttype)
		{
			if (argtype.StripNubs().IsEnumType)
			{
				return desttype.StripNubs().IsPredefType(PredefinedType.PT_DECIMAL);
			}
			return false;
		}
	}
	internal sealed class ExprZeroInit : ExprWithType
	{
		public override object Object => Activator.CreateInstance(base.Type.AssociatedSystemType);

		public ExprZeroInit(CType type)
			: base(ExpressionKind.ZeroInit, type)
		{
		}
	}
	[Flags]
	internal enum CheckConstraintsFlags
	{
		None = 0,
		Outer = 1,
		NoErrors = 4
	}
	internal static class TypeBind
	{
		public static bool CheckConstraints(CType type, CheckConstraintsFlags flags)
		{
			type = type.GetNakedType(fStripNub: false);
			AggregateType aggregateType = type as AggregateType;
			if (aggregateType == null)
			{
				if (!(type is NullableType nullableType))
				{
					return true;
				}
				aggregateType = nullableType.GetAts();
			}
			if (aggregateType.TypeArgsAll.Count == 0)
			{
				aggregateType.ConstraintError = false;
				return true;
			}
			if (aggregateType.ConstraintError.HasValue)
			{
				if (aggregateType.ConstraintError != true)
				{
					return true;
				}
				if ((flags & CheckConstraintsFlags.NoErrors) != CheckConstraintsFlags.None)
				{
					return false;
				}
			}
			TypeArray typeVars = aggregateType.OwningAggregate.GetTypeVars();
			TypeArray typeArgsThis = aggregateType.TypeArgsThis;
			TypeArray typeArgsAll = aggregateType.TypeArgsAll;
			if (aggregateType.OuterType != null && ((flags & CheckConstraintsFlags.Outer) != CheckConstraintsFlags.None || !aggregateType.OuterType.ConstraintError.HasValue) && !CheckConstraints(aggregateType.OuterType, flags))
			{
				aggregateType.ConstraintError = true;
				return false;
			}
			if (typeVars.Count > 0 && !CheckConstraintsCore(aggregateType.OwningAggregate, typeVars, typeArgsThis, typeArgsAll, null, flags & CheckConstraintsFlags.NoErrors))
			{
				aggregateType.ConstraintError = true;
				return false;
			}
			for (int i = 0; i < typeArgsThis.Count; i++)
			{
				if (typeArgsThis[i].GetNakedType(fStripNub: true) is AggregateType aggregateType2 && !aggregateType2.ConstraintError.HasValue)
				{
					CheckConstraints(aggregateType2, flags | CheckConstraintsFlags.Outer);
					if (aggregateType2.ConstraintError == true)
					{
						aggregateType.ConstraintError = true;
						return false;
					}
				}
			}
			aggregateType.ConstraintError = false;
			return true;
		}

		public static void CheckMethConstraints(MethWithInst mwi)
		{
			if (mwi.TypeArgs.Count > 0)
			{
				CheckConstraintsCore(mwi.Meth(), mwi.Meth().typeVars, mwi.TypeArgs, mwi.GetType().TypeArgsAll, mwi.TypeArgs, CheckConstraintsFlags.None);
			}
		}

		private static bool CheckConstraintsCore(Symbol symErr, TypeArray typeVars, TypeArray typeArgs, TypeArray typeArgsCls, TypeArray typeArgsMeth, CheckConstraintsFlags flags)
		{
			for (int i = 0; i < typeVars.Count; i++)
			{
				TypeParameterType var = (TypeParameterType)typeVars[i];
				CType arg = typeArgs[i];
				if (!CheckSingleConstraint(symErr, var, arg, typeArgsCls, typeArgsMeth, flags))
				{
					return false;
				}
			}
			return true;
		}

		private static bool CheckSingleConstraint(Symbol symErr, TypeParameterType var, CType arg, TypeArray typeArgsCls, TypeArray typeArgsMeth, CheckConstraintsFlags flags)
		{
			bool flag = (flags & CheckConstraintsFlags.NoErrors) == 0;
			if (var.HasRefConstraint && !arg.IsReferenceType)
			{
				if (flag)
				{
					throw ErrorHandling.Error(ErrorCode.ERR_RefConstraintNotSatisfied, symErr, new ErrArgNoRef(var), arg);
				}
				return false;
			}
			TypeArray typeArray = TypeManager.SubstTypeArray(var.Bounds, typeArgsCls, typeArgsMeth);
			int num = 0;
			if (var.HasValConstraint)
			{
				if (!arg.IsNonNullableValueType)
				{
					if (flag)
					{
						throw ErrorHandling.Error(ErrorCode.ERR_ValConstraintNotSatisfied, symErr, new ErrArgNoRef(var), arg);
					}
					return false;
				}
				if (typeArray.Count != 0 && typeArray[0].IsPredefType(PredefinedType.PT_VALUE))
				{
					num = 1;
				}
			}
			for (int i = num; i < typeArray.Count; i++)
			{
				CType cType = typeArray[i];
				if (!SatisfiesBound(arg, cType))
				{
					if (flag)
					{
						ErrorCode id = (arg.IsReferenceType ? ErrorCode.ERR_GenericConstraintNotSatisfiedRefType : ((!(arg is NullableType nullableType) || !SymbolLoader.HasBaseConversion(nullableType.UnderlyingType, cType)) ? ErrorCode.ERR_GenericConstraintNotSatisfiedValType : ((!cType.IsPredefType(PredefinedType.PT_ENUM) && nullableType.UnderlyingType != cType) ? ErrorCode.ERR_GenericConstraintNotSatisfiedNullableInterface : ErrorCode.ERR_GenericConstraintNotSatisfiedNullableEnum)));
						throw ErrorHandling.Error(id, new ErrArg(symErr), new ErrArg(cType, ErrArgFlags.Unique), var, new ErrArg(arg, ErrArgFlags.Unique));
					}
					return false;
				}
			}
			if (!var.HasNewConstraint || arg.IsValueType)
			{
				return true;
			}
			if (arg.IsClassType)
			{
				AggregateSymbol owningAggregate = ((AggregateType)arg).OwningAggregate;
				SymbolLoader.LookupAggMember(NameManager.GetPredefinedName(PredefinedName.PN_CTOR), owningAggregate, symbmask_t.MASK_ALL);
				if (owningAggregate.HasPubNoArgCtor() && !owningAggregate.IsAbstract())
				{
					return true;
				}
			}
			if (flag)
			{
				throw ErrorHandling.Error(ErrorCode.ERR_NewConstraintNotSatisfied, symErr, new ErrArgNoRef(var), arg);
			}
			return false;
		}

		private static bool SatisfiesBound(CType arg, CType typeBnd)
		{
			if (typeBnd == arg)
			{
				return true;
			}
			switch (typeBnd.TypeKind)
			{
			default:
				return false;
			case TypeKind.TK_VoidType:
			case TypeKind.TK_PointerType:
				return false;
			case TypeKind.TK_NullableType:
				typeBnd = ((NullableType)typeBnd).GetAts();
				break;
			case TypeKind.TK_AggregateType:
			case TypeKind.TK_ArrayType:
			case TypeKind.TK_TypeParameterType:
				break;
			}
			switch (arg.TypeKind)
			{
			default:
				return false;
			case TypeKind.TK_PointerType:
				return false;
			case TypeKind.TK_NullableType:
				arg = ((NullableType)arg).GetAts();
				break;
			case TypeKind.TK_AggregateType:
			case TypeKind.TK_ArrayType:
			case TypeKind.TK_TypeParameterType:
				break;
			}
			return SymbolLoader.HasBaseConversion(arg, typeBnd);
		}
	}
	internal sealed class AggregateType : CType
	{
		private AggregateType _baseType;

		private TypeArray _ifacesAll;

		private TypeArray _winrtifacesAll;

		private Type _associatedSystemType;

		public bool? ConstraintError;

		public bool AllHidden;

		public bool DiffHidden;

		public AggregateType OuterType { get; }

		public AggregateSymbol OwningAggregate { get; }

		public AggregateType BaseClass
		{
			get
			{
				if (_baseType == null)
				{
					Type baseType = AssociatedSystemType.BaseType;
					if (baseType == null)
					{
						return null;
					}
					AggregateType typeSrc = SymbolTable.GetCTypeFromType(baseType) as AggregateType;
					_baseType = TypeManager.SubstType(typeSrc, TypeArgsAll);
				}
				return _baseType;
			}
		}

		public IEnumerable<AggregateType> TypeHierarchy
		{
			get
			{
				if (IsInterfaceType)
				{
					yield return this;
					CType[] items = IfacesAll.Items;
					for (int i = 0; i < items.Length; i++)
					{
						yield return (AggregateType)items[i];
					}
					yield return PredefinedTypes.GetPredefinedAggregate(PredefinedType.PT_OBJECT).getThisType();
				}
				else
				{
					for (AggregateType agg = this; agg != null; agg = agg.BaseClass)
					{
						yield return agg;
					}
				}
			}
		}

		public TypeArray TypeArgsThis { get; }

		public TypeArray TypeArgsAll { get; }

		public TypeArray IfacesAll => _ifacesAll ?? (_ifacesAll = TypeManager.SubstTypeArray(OwningAggregate.GetIfacesAll(), TypeArgsAll));

		private bool IsCollectionType
		{
			get
			{
				Type associatedSystemType = AssociatedSystemType;
				if (associatedSystemType.IsGenericType)
				{
					Type genericTypeDefinition = associatedSystemType.GetGenericTypeDefinition();
					if (!(genericTypeDefinition == typeof(IList<>)) && !(genericTypeDefinition == typeof(ICollection<>)) && !(genericTypeDefinition == typeof(IEnumerable<>)) && !(genericTypeDefinition == typeof(IReadOnlyList<>)) && !(genericTypeDefinition == typeof(IReadOnlyCollection<>)) && !(genericTypeDefinition == typeof(IDictionary<, >)))
					{
						return genericTypeDefinition == typeof(IReadOnlyDictionary<, >);
					}
					return true;
				}
				if (!(associatedSystemType == typeof(IList)) && !(associatedSystemType == typeof(ICollection)) && !(associatedSystemType == typeof(IEnumerable)) && !(associatedSystemType == typeof(INotifyCollectionChanged)))
				{
					return associatedSystemType == typeof(INotifyPropertyChanged);
				}
				return true;
			}
		}

		public TypeArray WinRTCollectionIfacesAll
		{
			get
			{
				if (_winrtifacesAll == null)
				{
					List<CType> list = new List<CType>();
					CType[] items = IfacesAll.Items;
					for (int i = 0; i < items.Length; i++)
					{
						AggregateType aggregateType = (AggregateType)items[i];
						if (aggregateType.IsCollectionType)
						{
							list.Add(aggregateType);
						}
					}
					_winrtifacesAll = TypeArray.Allocate(list.ToArray());
				}
				return _winrtifacesAll;
			}
		}

		public override bool IsReferenceType => OwningAggregate.IsRefType();

		public override bool IsNonNullableValueType => IsValueType;

		public override bool IsValueType => OwningAggregate.IsValueType();

		public override bool IsStaticClass => OwningAggregate.IsStatic();

		public override bool IsPredefined => OwningAggregate.IsPredefined();

		public override PredefinedType PredefinedType => OwningAggregate.GetPredefType();

		public override bool IsDelegateType => OwningAggregate.IsDelegate();

		public override bool IsSimpleType
		{
			get
			{
				AggregateSymbol owningAggregate = OwningAggregate;
				if (owningAggregate.IsPredefined())
				{
					return PredefinedTypeFacts.IsSimpleType(owningAggregate.GetPredefType());
				}
				return false;
			}
		}

		public override bool IsSimpleOrEnum
		{
			get
			{
				AggregateSymbol owningAggregate = OwningAggregate;
				if (!owningAggregate.IsPredefined())
				{
					return owningAggregate.IsEnum();
				}
				return PredefinedTypeFacts.IsSimpleType(owningAggregate.GetPredefType());
			}
		}

		public override bool IsSimpleOrEnumOrString
		{
			get
			{
				AggregateSymbol owningAggregate = OwningAggregate;
				if (owningAggregate.IsPredefined())
				{
					PredefinedType predefType = owningAggregate.GetPredefType();
					if (!PredefinedTypeFacts.IsSimpleType(predefType))
					{
						return predefType == PredefinedType.PT_STRING;
					}
					return true;
				}
				return owningAggregate.IsEnum();
			}
		}

		public override bool IsNumericType
		{
			get
			{
				AggregateSymbol owningAggregate = OwningAggregate;
				if (owningAggregate.IsPredefined())
				{
					return PredefinedTypeFacts.IsNumericType(owningAggregate.GetPredefType());
				}
				return false;
			}
		}

		public override bool IsStructOrEnum
		{
			get
			{
				AggregateSymbol owningAggregate = OwningAggregate;
				if (!owningAggregate.IsStruct())
				{
					return owningAggregate.IsEnum();
				}
				return true;
			}
		}

		public override bool IsStructType => OwningAggregate.IsStruct();

		public override bool IsEnumType => OwningAggregate.IsEnum();

		public override bool IsInterfaceType => OwningAggregate.IsInterface();

		public override bool IsClassType => OwningAggregate.IsClass();

		public override AggregateType UnderlyingEnumType => OwningAggregate.GetUnderlyingType();

		public override Type AssociatedSystemType => _associatedSystemType ?? (_associatedSystemType = CalculateAssociatedSystemType());

		public override FUNDTYPE FundamentalType
		{
			get
			{
				AggregateSymbol owningAggregate = OwningAggregate;
				if (owningAggregate.IsEnum())
				{
					owningAggregate = owningAggregate.GetUnderlyingType().OwningAggregate;
				}
				else if (!owningAggregate.IsStruct())
				{
					return FUNDTYPE.FT_REF;
				}
				if (!owningAggregate.IsPredefined())
				{
					return FUNDTYPE.FT_STRUCT;
				}
				return PredefinedTypeFacts.GetFundType(owningAggregate.GetPredefType());
			}
		}

		public override ConstValKind ConstValKind
		{
			get
			{
				if (IsPredefType(PredefinedType.FirstNonSimpleType) || IsPredefType(PredefinedType.PT_UINTPTR))
				{
					return ConstValKind.IntPtr;
				}
				switch (FundamentalType)
				{
				case FUNDTYPE.FT_I8:
				case FUNDTYPE.FT_U8:
					return ConstValKind.Long;
				case FUNDTYPE.FT_STRUCT:
					if (!IsPredefined || PredefinedType != PredefinedType.PT_DATETIME)
					{
						return ConstValKind.Decimal;
					}
					return ConstValKind.Long;
				case FUNDTYPE.FT_REF:
					if (!IsPredefined || PredefinedType != PredefinedType.PT_STRING)
					{
						return ConstValKind.IntPtr;
					}
					return ConstValKind.String;
				case FUNDTYPE.FT_R4:
					return ConstValKind.Float;
				case FUNDTYPE.FT_R8:
					return ConstValKind.Double;
				case FUNDTYPE.FT_I1:
					return ConstValKind.Boolean;
				default:
					return ConstValKind.Int;
				}
			}
		}

		public AggregateType(AggregateSymbol parent, TypeArray typeArgsThis, AggregateType outerType)
			: base(TypeKind.TK_AggregateType)
		{
			OuterType = outerType;
			OwningAggregate = parent;
			TypeArgsThis = typeArgsThis;
			TypeArgsAll = ((outerType != null) ? TypeArray.Concat(outerType.TypeArgsAll, typeArgsThis) : typeArgsThis);
		}

		public override bool IsPredefType(PredefinedType pt)
		{
			AggregateSymbol owningAggregate = OwningAggregate;
			if (owningAggregate.IsPredefined())
			{
				return owningAggregate.GetPredefType() == pt;
			}
			return false;
		}

		private Type CalculateAssociatedSystemType()
		{
			Type associatedSystemType = OwningAggregate.AssociatedSystemType;
			if (associatedSystemType.IsGenericType)
			{
				TypeArray typeArgsAll = TypeArgsAll;
				Type[] array = new Type[typeArgsAll.Count];
				for (int i = 0; i < array.Length; i++)
				{
					CType cType = typeArgsAll[i];
					if (cType is TypeParameterType typeParameterType && typeParameterType.Symbol.name == null)
					{
						return null;
					}
					array[i] = cType.AssociatedSystemType;
				}
				try
				{
					return associatedSystemType.MakeGenericType(array);
				}
				catch (ArgumentException)
				{
				}
			}
			return associatedSystemType;
		}

		public override AggregateType GetAts()
		{
			return this;
		}
	}
	internal sealed class ArgumentListType : CType
	{
		public static readonly ArgumentListType Instance = new ArgumentListType();

		private ArgumentListType()
			: base(TypeKind.TK_ArgumentListType)
		{
		}
	}
	internal sealed class ArrayType : CType
	{
		public int Rank { get; }

		public bool IsSZArray { get; }

		public CType ElementType { get; }

		public CType BaseElementType
		{
			get
			{
				CType elementType;
				for (elementType = ElementType; elementType is ArrayType arrayType; elementType = arrayType.ElementType)
				{
				}
				return elementType;
			}
		}

		public override bool IsReferenceType => true;

		public override Type AssociatedSystemType
		{
			get
			{
				Type associatedSystemType = ElementType.AssociatedSystemType;
				if (!IsSZArray)
				{
					return associatedSystemType.MakeArrayType(Rank);
				}
				return associatedSystemType.MakeArrayType();
			}
		}

		public override CType BaseOrParameterOrElementType => ElementType;

		public override FUNDTYPE FundamentalType => FUNDTYPE.FT_REF;

		public override ConstValKind ConstValKind => ConstValKind.IntPtr;

		public ArrayType(CType elementType, int rank, bool isSZArray)
			: base(TypeKind.TK_ArrayType)
		{
			Rank = rank;
			IsSZArray = isSZArray;
			ElementType = elementType;
		}

		public override bool IsUnsafe()
		{
			return BaseElementType is PointerType;
		}

		public override AggregateType GetAts()
		{
			return SymbolLoader.GetPredefindType(PredefinedType.PT_ARRAY);
		}
	}
	internal sealed class MethodGroupType : CType
	{
		public static readonly MethodGroupType Instance = new MethodGroupType();

		private MethodGroupType()
			: base(TypeKind.TK_MethodGroupType)
		{
		}
	}
	internal sealed class NullType : CType
	{
		public static readonly NullType Instance = new NullType();

		public override bool IsReferenceType => true;

		public override FUNDTYPE FundamentalType => FUNDTYPE.FT_REF;

		public override ConstValKind ConstValKind => ConstValKind.IntPtr;

		private NullType()
			: base(TypeKind.TK_NullType)
		{
		}
	}
	internal sealed class NullableType : CType
	{
		private AggregateType _ats;

		public CType UnderlyingType { get; }

		public override bool IsValueType => true;

		public override bool IsStructOrEnum => true;

		public override bool IsStructType => true;

		public override Type AssociatedSystemType => typeof(Nullable<>).MakeGenericType(UnderlyingType.AssociatedSystemType);

		public override CType BaseOrParameterOrElementType => UnderlyingType;

		public override FUNDTYPE FundamentalType => FUNDTYPE.FT_STRUCT;

		[ExcludeFromCodeCoverage]
		public override ConstValKind ConstValKind => ConstValKind.Decimal;

		public NullableType(CType underlyingType)
			: base(TypeKind.TK_NullableType)
		{
			UnderlyingType = underlyingType;
		}

		public override AggregateType GetAts()
		{
			return _ats ?? (_ats = TypeManager.GetAggregate(TypeManager.GetNullable(), TypeArray.Allocate(UnderlyingType)));
		}

		public override CType StripNubs()
		{
			return UnderlyingType;
		}

		public override CType StripNubs(out bool wasNullable)
		{
			wasNullable = true;
			return UnderlyingType;
		}
	}
	internal sealed class ParameterModifierType : CType
	{
		public bool IsOut { get; }

		public CType ParameterType { get; }

		public override Type AssociatedSystemType => ParameterType.AssociatedSystemType.MakeByRefType();

		public override CType BaseOrParameterOrElementType => ParameterType;

		public ParameterModifierType(CType parameterType, bool isOut)
			: base(TypeKind.TK_ParameterModifierType)
		{
			ParameterType = parameterType;
			IsOut = isOut;
		}
	}
	internal sealed class PointerType : CType
	{
		public CType ReferentType { get; }

		public override Type AssociatedSystemType => ReferentType.AssociatedSystemType.MakePointerType();

		public override CType BaseOrParameterOrElementType => ReferentType;

		public override FUNDTYPE FundamentalType => FUNDTYPE.FT_PTR;

		[ExcludeFromCodeCoverage]
		public override ConstValKind ConstValKind => ConstValKind.IntPtr;

		public PointerType(CType referentType)
			: base(TypeKind.TK_PointerType)
		{
			ReferentType = referentType;
		}

		public override bool IsUnsafe()
		{
			return true;
		}
	}
	internal static class PredefinedTypes
	{
		private static readonly AggregateSymbol[] s_predefSymbols = new AggregateSymbol[49];

		private static AggregateSymbol DelayLoadPredefSym(PredefinedType pt)
		{
			return InitializePredefinedType(((AggregateType)SymbolTable.GetCTypeFromType(PredefinedTypeFacts.GetAssociatedSystemType(pt))).OwningAggregate, pt);
		}

		internal static AggregateSymbol InitializePredefinedType(AggregateSymbol sym, PredefinedType pt)
		{
			sym.SetPredefined(predefined: true);
			sym.SetPredefType(pt);
			sym.SetSkipUDOps(pt <= PredefinedType.PT_ENUM && pt != PredefinedType.FirstNonSimpleType && pt != PredefinedType.PT_UINTPTR && pt != PredefinedType.PT_TYPE);
			return sym;
		}

		public static AggregateSymbol GetPredefinedAggregate(PredefinedType pt)
		{
			return s_predefSymbols[(uint)pt] ?? (s_predefSymbols[(uint)pt] = DelayLoadPredefSym(pt));
		}

		private static string GetNiceName(PredefinedType pt)
		{
			return PredefinedTypeFacts.GetNiceName(pt);
		}

		public static string GetNiceName(AggregateSymbol type)
		{
			if (!type.IsPredefined())
			{
				return null;
			}
			return GetNiceName(type.GetPredefType());
		}
	}
	internal static class PredefinedTypeFacts
	{
		private sealed class PredefinedTypeInfo
		{
			public readonly string Name;

			public readonly FUNDTYPE FundType;

			public readonly Type AssociatedSystemType;

			internal PredefinedTypeInfo(PredefinedType type, Type associatedSystemType, string name, FUNDTYPE fundType)
			{
				Name = name;
				FundType = fundType;
				AssociatedSystemType = associatedSystemType;
			}

			internal PredefinedTypeInfo(PredefinedType type, Type associatedSystemType, string name)
				: this(type, associatedSystemType, name, FUNDTYPE.FT_REF)
			{
			}
		}

		private static readonly PredefinedTypeInfo[] s_types = new PredefinedTypeInfo[49]
		{
			new PredefinedTypeInfo(PredefinedType.PT_BYTE, typeof(byte), "System.Byte", FUNDTYPE.FT_U1),
			new PredefinedTypeInfo(PredefinedType.PT_SHORT, typeof(short), "System.Int16", FUNDTYPE.FT_I2),
			new PredefinedTypeInfo(PredefinedType.PT_INT, typeof(int), "System.Int32", FUNDTYPE.FT_I4),
			new PredefinedTypeInfo(PredefinedType.PT_LONG, typeof(long), "System.Int64", FUNDTYPE.FT_I8),
			new PredefinedTypeInfo(PredefinedType.PT_FLOAT, typeof(float), "System.Single", FUNDTYPE.FT_R4),
			new PredefinedTypeInfo(PredefinedType.PT_DOUBLE, typeof(double), "System.Double", FUNDTYPE.FT_R8),
			new PredefinedTypeInfo(PredefinedType.PT_DECIMAL, typeof(decimal), "System.Decimal", FUNDTYPE.FT_STRUCT),
			new PredefinedTypeInfo(PredefinedType.PT_CHAR, typeof(char), "System.Char", FUNDTYPE.FT_U2),
			new PredefinedTypeInfo(PredefinedType.PT_BOOL, typeof(bool), "System.Boolean", FUNDTYPE.FT_I1),
			new PredefinedTypeInfo(PredefinedType.PT_SBYTE, typeof(sbyte), "System.SByte", FUNDTYPE.FT_I1),
			new PredefinedTypeInfo(PredefinedType.PT_USHORT, typeof(ushort), "System.UInt16", FUNDTYPE.FT_U2),
			new PredefinedTypeInfo(PredefinedType.PT_UINT, typeof(uint), "System.UInt32", FUNDTYPE.FT_U4),
			new PredefinedTypeInfo(PredefinedType.PT_ULONG, typeof(ulong), "System.UInt64", FUNDTYPE.FT_U8),
			new PredefinedTypeInfo(PredefinedType.FirstNonSimpleType, typeof(IntPtr), "System.IntPtr", FUNDTYPE.FT_STRUCT),
			new PredefinedTypeInfo(PredefinedType.PT_UINTPTR, typeof(UIntPtr), "System.UIntPtr", FUNDTYPE.FT_STRUCT),
			new PredefinedTypeInfo(PredefinedType.PT_OBJECT, typeof(object), "System.Object"),
			new PredefinedTypeInfo(PredefinedType.PT_STRING, typeof(string), "System.String"),
			new PredefinedTypeInfo(PredefinedType.PT_DELEGATE, typeof(Delegate), "System.Delegate"),
			new PredefinedTypeInfo(PredefinedType.PT_MULTIDEL, typeof(MulticastDelegate), "System.MulticastDelegate"),
			new PredefinedTypeInfo(PredefinedType.PT_ARRAY, typeof(Array), "System.Array"),
			new PredefinedTypeInfo(PredefinedType.PT_TYPE, typeof(Type), "System.Type"),
			new PredefinedTypeInfo(PredefinedType.PT_VALUE, typeof(ValueType), "System.ValueType"),
			new PredefinedTypeInfo(PredefinedType.PT_ENUM, typeof(Enum), "System.Enum"),
			new PredefinedTypeInfo(PredefinedType.PT_DATETIME, typeof(DateTime), "System.DateTime", FUNDTYPE.FT_STRUCT),
			new PredefinedTypeInfo(PredefinedType.PT_IENUMERABLE, typeof(IEnumerable), "System.Collections.IEnumerable"),
			new PredefinedTypeInfo(PredefinedType.PT_G_IENUMERABLE, typeof(IEnumerable<>), "System.Collections.Generic.IEnumerable`1"),
			new PredefinedTypeInfo(PredefinedType.PT_G_OPTIONAL, typeof(Nullable<>), "System.Nullable`1", FUNDTYPE.FT_STRUCT),
			new PredefinedTypeInfo(PredefinedType.PT_G_IQUERYABLE, typeof(IQueryable<>), "System.Linq.IQueryable`1"),
			new PredefinedTypeInfo(PredefinedType.PT_G_ICOLLECTION, typeof(ICollection<>), "System.Collections.Generic.ICollection`1"),
			new PredefinedTypeInfo(PredefinedType.PT_G_ILIST, typeof(IList<>), "System.Collections.Generic.IList`1"),
			new PredefinedTypeInfo(PredefinedType.PT_G_EXPRESSION, typeof(Expression<>), "System.Linq.Expressions.Expression`1"),
			new PredefinedTypeInfo(PredefinedType.PT_EXPRESSION, typeof(Expression), "System.Linq.Expressions.Expression"),
			new PredefinedTypeInfo(PredefinedType.PT_BINARYEXPRESSION, typeof(BinaryExpression), "System.Linq.Expressions.BinaryExpression"),
			new PredefinedTypeInfo(PredefinedType.PT_UNARYEXPRESSION, typeof(UnaryExpression), "System.Linq.Expressions.UnaryExpression"),
			new PredefinedTypeInfo(PredefinedType.PT_CONSTANTEXPRESSION, typeof(ConstantExpression), "System.Linq.Expressions.ConstantExpression"),
			new PredefinedTypeInfo(PredefinedType.PT_PARAMETEREXPRESSION, typeof(ParameterExpression), "System.Linq.Expressions.ParameterExpression"),
			new PredefinedTypeInfo(PredefinedType.PT_MEMBEREXPRESSION, typeof(MemberExpression), "System.Linq.Expressions.MemberExpression"),
			new PredefinedTypeInfo(PredefinedType.PT_METHODCALLEXPRESSION, typeof(MethodCallExpression), "System.Linq.Expressions.MethodCallExpression"),
			new PredefinedTypeInfo(PredefinedType.PT_NEWEXPRESSION, typeof(NewExpression), "System.Linq.Expressions.NewExpression"),
			new PredefinedTypeInfo(PredefinedType.PT_NEWARRAYEXPRESSION, typeof(NewArrayExpression), "System.Linq.Expressions.NewArrayExpression"),
			new PredefinedTypeInfo(PredefinedType.PT_INVOCATIONEXPRESSION, typeof(InvocationExpression), "System.Linq.Expressions.InvocationExpression"),
			new PredefinedTypeInfo(PredefinedType.PT_FIELDINFO, typeof(FieldInfo), "System.Reflection.FieldInfo"),
			new PredefinedTypeInfo(PredefinedType.PT_METHODINFO, typeof(MethodInfo), "System.Reflection.MethodInfo"),
			new PredefinedTypeInfo(PredefinedType.PT_CONSTRUCTORINFO, typeof(ConstructorInfo), "System.Reflection.ConstructorInfo"),
			new PredefinedTypeInfo(PredefinedType.PT_PROPERTYINFO, typeof(PropertyInfo), "System.Reflection.PropertyInfo"),
			new PredefinedTypeInfo(PredefinedType.PT_MISSING, typeof(Missing), "System.Reflection.Missing"),
			new PredefinedTypeInfo(PredefinedType.PT_G_IREADONLYLIST, typeof(IReadOnlyList<>), "System.Collections.Generic.IReadOnlyList`1"),
			new PredefinedTypeInfo(PredefinedType.PT_G_IREADONLYCOLLECTION, typeof(IReadOnlyCollection<>), "System.Collections.Generic.IReadOnlyCollection`1"),
			new PredefinedTypeInfo(PredefinedType.PT_FUNC, typeof(Func<>), "System.Func`1")
		};

		private static readonly Dictionary<string, PredefinedType> s_typesByName = CreatePredefinedTypeFacts();

		internal static FUNDTYPE GetFundType(PredefinedType type)
		{
			return s_types[(uint)type].FundType;
		}

		internal static Type GetAssociatedSystemType(PredefinedType type)
		{
			return s_types[(uint)type].AssociatedSystemType;
		}

		internal static bool IsSimpleType(PredefinedType type)
		{
			return type < PredefinedType.FirstNonSimpleType;
		}

		internal static bool IsNumericType(PredefinedType type)
		{
			if (type <= PredefinedType.PT_DECIMAL || type - 9 <= PredefinedType.PT_LONG)
			{
				return true;
			}
			return false;
		}

		internal static string GetNiceName(PredefinedType type)
		{
			return type switch
			{
				PredefinedType.PT_BYTE => "byte", 
				PredefinedType.PT_SHORT => "short", 
				PredefinedType.PT_INT => "int", 
				PredefinedType.PT_LONG => "long", 
				PredefinedType.PT_FLOAT => "float", 
				PredefinedType.PT_DOUBLE => "double", 
				PredefinedType.PT_DECIMAL => "decimal", 
				PredefinedType.PT_CHAR => "char", 
				PredefinedType.PT_BOOL => "bool", 
				PredefinedType.PT_SBYTE => "sbyte", 
				PredefinedType.PT_USHORT => "ushort", 
				PredefinedType.PT_UINT => "uint", 
				PredefinedType.PT_ULONG => "ulong", 
				PredefinedType.PT_OBJECT => "object", 
				PredefinedType.PT_STRING => "string", 
				_ => null, 
			};
		}

		public static PredefinedType TryGetPredefTypeIndex(string name)
		{
			if (!s_typesByName.TryGetValue(name, out var value))
			{
				return PredefinedType.PT_UNDEFINEDINDEX;
			}
			return value;
		}

		private static Dictionary<string, PredefinedType> CreatePredefinedTypeFacts()
		{
			Dictionary<string, PredefinedType> dictionary = new Dictionary<string, PredefinedType>(49);
			for (int i = 0; i < 49; i++)
			{
				dictionary.Add(s_types[i].Name, (PredefinedType)i);
			}
			return dictionary;
		}
	}
	internal abstract class CType
	{
		public bool IsWindowsRuntimeType => (AssociatedSystemType.Attributes & TypeAttributes.WindowsRuntime) != 0;

		[ExcludeFromCodeCoverage]
		public virtual Type AssociatedSystemType
		{
			get
			{
				throw Error.InternalCompilerError();
			}
		}

		public TypeKind TypeKind { get; }

		public virtual CType BaseOrParameterOrElementType => null;

		public virtual FUNDTYPE FundamentalType => FUNDTYPE.FT_NONE;

		public virtual ConstValKind ConstValKind => ConstValKind.Int;

		public virtual bool IsDelegateType => false;

		public virtual bool IsSimpleType => false;

		public virtual bool IsSimpleOrEnum => false;

		public virtual bool IsSimpleOrEnumOrString => false;

		public virtual bool IsNumericType => false;

		public virtual bool IsStructOrEnum => false;

		public virtual bool IsStructType => false;

		public virtual bool IsEnumType => false;

		public virtual bool IsInterfaceType => false;

		public virtual bool IsClassType => false;

		[ExcludeFromCodeCoverage]
		public virtual AggregateType UnderlyingEnumType
		{
			get
			{
				throw Error.InternalCompilerError();
			}
		}

		public virtual bool IsPredefined => false;

		[ExcludeFromCodeCoverage]
		public virtual PredefinedType PredefinedType
		{
			get
			{
				throw Error.InternalCompilerError();
			}
		}

		public virtual bool IsStaticClass => false;

		public virtual bool IsValueType => false;

		public virtual bool IsNonNullableValueType => false;

		public virtual bool IsReferenceType => false;

		private protected CType(TypeKind kind)
		{
			TypeKind = kind;
		}

		public CType GetNakedType(bool fStripNub)
		{
			CType cType = this;
			while (true)
			{
				TypeKind typeKind = cType.TypeKind;
				if ((uint)(typeKind - 5) > 2u && (typeKind != TypeKind.TK_NullableType || !fStripNub))
				{
					break;
				}
				cType = cType.BaseOrParameterOrElementType;
			}
			return cType;
		}

		public virtual CType StripNubs()
		{
			return this;
		}

		public virtual CType StripNubs(out bool wasNullable)
		{
			wasNullable = false;
			return this;
		}

		public virtual bool IsUnsafe()
		{
			return false;
		}

		public virtual bool IsPredefType(PredefinedType pt)
		{
			return false;
		}

		[ExcludeFromCodeCoverage]
		public virtual AggregateType GetAts()
		{
			return null;
		}
	}
	internal sealed class TypeArray
	{
		private readonly struct TypeArrayKey : IEquatable<TypeArrayKey>
		{
			private readonly CType[] _types;

			private readonly int _hashCode;

			public TypeArrayKey(CType[] types)
			{
				_types = types;
				int num = 371857150;
				foreach (CType cType in types)
				{
					num = (num << 5) - num;
					if (cType != null)
					{
						num ^= cType.GetHashCode();
					}
				}
				_hashCode = num;
			}

			public bool Equals(TypeArrayKey other)
			{
				CType[] types = _types;
				CType[] types2 = other._types;
				if (types2 == types)
				{
					return true;
				}
				if (other._hashCode != _hashCode || types2.Length != types.Length)
				{
					return false;
				}
				for (int i = 0; i < types.Length; i++)
				{
					if (types[i] != types2[i])
					{
						return false;
					}
				}
				return true;
			}

			[ExcludeFromCodeCoverage]
			public override bool Equals(object obj)
			{
				if (obj is TypeArrayKey other)
				{
					return Equals(other);
				}
				return false;
			}

			public override int GetHashCode()
			{
				return _hashCode;
			}
		}

		private static readonly Dictionary<TypeArrayKey, TypeArray> s_tableTypeArrays = new Dictionary<TypeArrayKey, TypeArray>();

		public static readonly TypeArray Empty = new TypeArray(Array.Empty<CType>());

		public int Count => Items.Length;

		public CType[] Items { get; }

		public CType this[int i] => Items[i];

		private TypeArray(CType[] types)
		{
			Items = types;
		}

		[Conditional("DEBUG")]
		public void AssertValid()
		{
		}

		public void CopyItems(int i, int c, CType[] dest)
		{
			Array.Copy(Items, i, dest, 0, c);
		}

		public static TypeArray Allocate(int ctype, TypeArray array, int offset)
		{
			if (ctype == 0)
			{
				return Empty;
			}
			if (ctype == array.Count)
			{
				return array;
			}
			CType[] items = array.Items;
			CType[] array2 = new CType[ctype];
			Array.ConstrainedCopy(items, offset, array2, 0, ctype);
			return Allocate(array2);
		}

		public static TypeArray Allocate(params CType[] types)
		{
			if (types != null && types.Length != 0)
			{
				TypeArrayKey key = new TypeArrayKey(types);
				if (!s_tableTypeArrays.TryGetValue(key, out var value))
				{
					value = new TypeArray(types);
					s_tableTypeArrays.Add(key, value);
				}
				return value;
			}
			return Empty;
		}

		public static TypeArray Concat(TypeArray pta1, TypeArray pta2)
		{
			CType[] items = pta1.Items;
			if (items.Length == 0)
			{
				return pta2;
			}
			CType[] items2 = pta2.Items;
			if (items2.Length == 0)
			{
				return pta1;
			}
			CType[] array = new CType[items.Length + items2.Length];
			Array.Copy(items, 0, array, 0, items.Length);
			Array.Copy(items2, 0, array, items.Length, items2.Length);
			return Allocate(array);
		}
	}
	internal enum TypeKind
	{
		TK_AggregateType,
		TK_VoidType,
		TK_NullType,
		TK_MethodGroupType,
		TK_ArgumentListType,
		TK_ArrayType,
		TK_PointerType,
		TK_ParameterModifierType,
		TK_NullableType,
		TK_TypeParameterType
	}
	internal static class TypeManager
	{
		private sealed class StdTypeVarColl
		{
			private readonly List<TypeParameterType> prgptvs;

			public StdTypeVarColl()
			{
				prgptvs = new List<TypeParameterType>();
			}

			public TypeParameterType GetTypeVarSym(int iv, bool fMeth)
			{
				TypeParameterType typeParameterType;
				if (iv >= prgptvs.Count)
				{
					TypeParameterSymbol typeParameterSymbol = new TypeParameterSymbol();
					typeParameterSymbol.SetIsMethodTypeParameter(fMeth);
					typeParameterSymbol.SetIndexInOwnParameters(iv);
					typeParameterSymbol.SetIndexInTotalParameters(iv);
					typeParameterSymbol.SetAccess(ACCESS.ACC_PRIVATE);
					typeParameterType = GetTypeParameter(typeParameterSymbol);
					prgptvs.Add(typeParameterType);
				}
				else
				{
					typeParameterType = prgptvs[iv];
				}
				return typeParameterType;
			}
		}

		private static readonly Dictionary<(Assembly, Assembly), bool> s_internalsVisibleToCache = new Dictionary<(Assembly, Assembly), bool>();

		private static readonly StdTypeVarColl s_stvcMethod = new StdTypeVarColl();

		public static ArrayType GetArray(CType elementType, int args, bool isSZArray)
		{
			int rankNum = ((!isSZArray) ? args : 0);
			ArrayType arrayType = TypeTable.LookupArray(elementType, rankNum);
			if (arrayType == null)
			{
				arrayType = new ArrayType(elementType, args, isSZArray);
				TypeTable.InsertArray(elementType, rankNum, arrayType);
			}
			return arrayType;
		}

		public static AggregateType GetAggregate(AggregateSymbol agg, AggregateType atsOuter, TypeArray typeArgs)
		{
			if (typeArgs == null)
			{
				typeArgs = TypeArray.Empty;
			}
			AggregateType aggregateType = TypeTable.LookupAggregate(agg, atsOuter, typeArgs);
			if (aggregateType == null)
			{
				aggregateType = new AggregateType(agg, typeArgs, atsOuter);
				TypeTable.InsertAggregate(agg, atsOuter, typeArgs, aggregateType);
			}
			return aggregateType;
		}

		public static AggregateType GetAggregate(AggregateSymbol agg, TypeArray typeArgsAll)
		{
			if (typeArgsAll.Count == 0)
			{
				return agg.getThisType();
			}
			AggregateSymbol outerAgg = agg.GetOuterAgg();
			if (outerAgg == null)
			{
				return GetAggregate(agg, null, typeArgsAll);
			}
			int count = outerAgg.GetTypeVarsAll().Count;
			TypeArray typeArgsAll2 = TypeArray.Allocate(count, typeArgsAll, 0);
			TypeArray typeArgs = TypeArray.Allocate(agg.GetTypeVars().Count, typeArgsAll, count);
			AggregateType aggregate = GetAggregate(outerAgg, typeArgsAll2);
			return GetAggregate(agg, aggregate, typeArgs);
		}

		public static PointerType GetPointer(CType baseType)
		{
			PointerType pointerType = TypeTable.LookupPointer(baseType);
			if (pointerType == null)
			{
				pointerType = new PointerType(baseType);
				TypeTable.InsertPointer(baseType, pointerType);
			}
			return pointerType;
		}

		public static NullableType GetNullable(CType pUnderlyingType)
		{
			NullableType nullableType = TypeTable.LookupNullable(pUnderlyingType);
			if (nullableType == null)
			{
				nullableType = new NullableType(pUnderlyingType);
				TypeTable.InsertNullable(pUnderlyingType, nullableType);
			}
			return nullableType;
		}

		public static ParameterModifierType GetParameterModifier(CType paramType, bool isOut)
		{
			ParameterModifierType parameterModifierType = TypeTable.LookupParameterModifier(paramType, isOut);
			if (parameterModifierType == null)
			{
				parameterModifierType = new ParameterModifierType(paramType, isOut);
				TypeTable.InsertParameterModifier(paramType, isOut, parameterModifierType);
			}
			return parameterModifierType;
		}

		public static AggregateSymbol GetNullable()
		{
			return GetPredefAgg(PredefinedType.PT_G_OPTIONAL);
		}

		private static CType SubstType(CType typeSrc, TypeArray typeArgsCls, TypeArray typeArgsMeth, bool denormMeth)
		{
			SubstContext substContext = new SubstContext(typeArgsCls, typeArgsMeth, denormMeth);
			if (!substContext.IsNop)
			{
				return SubstTypeCore(typeSrc, substContext);
			}
			return typeSrc;
		}

		public static AggregateType SubstType(AggregateType typeSrc, TypeArray typeArgsCls)
		{
			SubstContext substContext = new SubstContext(typeArgsCls, null, denormMeth: false);
			if (!substContext.IsNop)
			{
				return SubstTypeCore(typeSrc, substContext);
			}
			return typeSrc;
		}

		private static CType SubstType(CType typeSrc, TypeArray typeArgsCls, TypeArray typeArgsMeth)
		{
			return SubstType(typeSrc, typeArgsCls, typeArgsMeth, denormMeth: false);
		}

		public static TypeArray SubstTypeArray(TypeArray taSrc, SubstContext ctx)
		{
			if (taSrc != null && taSrc.Count != 0 && ctx != null && !ctx.IsNop)
			{
				CType[] items = taSrc.Items;
				for (int i = 0; i < items.Length; i++)
				{
					CType obj = items[i];
					CType cType = SubstTypeCore(obj, ctx);
					if (obj != cType)
					{
						CType[] array = new CType[items.Length];
						Array.Copy(items, array, i);
						array[i] = cType;
						while (++i < items.Length)
						{
							array[i] = SubstTypeCore(items[i], ctx);
						}
						return TypeArray.Allocate(array);
					}
				}
			}
			return taSrc;
		}

		public static TypeArray SubstTypeArray(TypeArray taSrc, TypeArray typeArgsCls, TypeArray typeArgsMeth)
		{
			if (taSrc != null && taSrc.Count != 0)
			{
				return SubstTypeArray(taSrc, new SubstContext(typeArgsCls, typeArgsMeth, denormMeth: false));
			}
			return taSrc;
		}

		public static TypeArray SubstTypeArray(TypeArray taSrc, TypeArray typeArgsCls)
		{
			return SubstTypeArray(taSrc, typeArgsCls, null);
		}

		private static AggregateType SubstTypeCore(AggregateType type, SubstContext ctx)
		{
			TypeArray typeArgsAll = type.TypeArgsAll;
			if (typeArgsAll.Count > 0)
			{
				TypeArray typeArray = SubstTypeArray(typeArgsAll, ctx);
				if (typeArgsAll != typeArray)
				{
					return GetAggregate(type.OwningAggregate, typeArray);
				}
			}
			return type;
		}

		private static CType SubstTypeCore(CType type, SubstContext pctx)
		{
			switch (type.TypeKind)
			{
			default:
				return type;
			case TypeKind.TK_VoidType:
			case TypeKind.TK_NullType:
			case TypeKind.TK_MethodGroupType:
			case TypeKind.TK_ArgumentListType:
				return type;
			case TypeKind.TK_ParameterModifierType:
			{
				ParameterModifierType parameterModifierType = (ParameterModifierType)type;
				CType underlyingType;
				CType cType = SubstTypeCore(underlyingType = parameterModifierType.ParameterType, pctx);
				if (cType != underlyingType)
				{
					return GetParameterModifier(cType, parameterModifierType.IsOut);
				}
				return type;
			}
			case TypeKind.TK_ArrayType:
			{
				ArrayType arrayType = (ArrayType)type;
				CType underlyingType;
				CType cType = SubstTypeCore(underlyingType = arrayType.ElementType, pctx);
				if (cType != underlyingType)
				{
					return GetArray(cType, arrayType.Rank, arrayType.IsSZArray);
				}
				return type;
			}
			case TypeKind.TK_PointerType:
			{
				CType underlyingType;
				CType cType = SubstTypeCore(underlyingType = ((PointerType)type).ReferentType, pctx);
				if (cType != underlyingType)
				{
					return GetPointer(cType);
				}
				return type;
			}
			case TypeKind.TK_NullableType:
			{
				CType underlyingType;
				CType cType = SubstTypeCore(underlyingType = ((NullableType)type).UnderlyingType, pctx);
				if (cType != underlyingType)
				{
					return GetNullable(cType);
				}
				return type;
			}
			case TypeKind.TK_AggregateType:
				return SubstTypeCore((AggregateType)type, pctx);
			case TypeKind.TK_TypeParameterType:
			{
				TypeParameterSymbol symbol = ((TypeParameterType)type).Symbol;
				int indexInTotalParameters = symbol.GetIndexInTotalParameters();
				if (symbol.IsMethodTypeParameter())
				{
					if (pctx.DenormMeth && symbol.parent != null)
					{
						return type;
					}
					if (indexInTotalParameters < pctx.MethodTypes.Length)
					{
						return pctx.MethodTypes[indexInTotalParameters];
					}
					return type;
				}
				if (indexInTotalParameters >= pctx.ClassTypes.Length)
				{
					return type;
				}
				return pctx.ClassTypes[indexInTotalParameters];
			}
			}
		}

		public static bool SubstEqualTypes(CType typeDst, CType typeSrc, TypeArray typeArgsCls, TypeArray typeArgsMeth, bool denormMeth)
		{
			if (typeDst.Equals(typeSrc))
			{
				return true;
			}
			SubstContext substContext = new SubstContext(typeArgsCls, typeArgsMeth, denormMeth);
			if (!substContext.IsNop)
			{
				return SubstEqualTypesCore(typeDst, typeSrc, substContext);
			}
			return false;
		}

		public static bool SubstEqualTypeArrays(TypeArray taDst, TypeArray taSrc, TypeArray typeArgsCls, TypeArray typeArgsMeth)
		{
			if (taDst == taSrc || (taDst != null && taDst.Equals(taSrc)))
			{
				return true;
			}
			if (taDst.Count != taSrc.Count)
			{
				return false;
			}
			if (taDst.Count == 0)
			{
				return true;
			}
			SubstContext substContext = new SubstContext(typeArgsCls, typeArgsMeth, denormMeth: true);
			if (substContext.IsNop)
			{
				return false;
			}
			for (int i = 0; i < taDst.Count; i++)
			{
				if (!SubstEqualTypesCore(taDst[i], taSrc[i], substContext))
				{
					return false;
				}
			}
			return true;
		}

		private static bool SubstEqualTypesCore(CType typeDst, CType typeSrc, SubstContext pctx)
		{
			while (typeDst != typeSrc && !typeDst.Equals(typeSrc))
			{
				switch (typeSrc.TypeKind)
				{
				default:
					return false;
				case TypeKind.TK_VoidType:
				case TypeKind.TK_NullType:
					return false;
				case TypeKind.TK_ArrayType:
				{
					ArrayType arrayType = (ArrayType)typeSrc;
					if (!(typeDst is ArrayType arrayType2) || arrayType2.Rank != arrayType.Rank || arrayType2.IsSZArray != arrayType.IsSZArray)
					{
						return false;
					}
					break;
				}
				case TypeKind.TK_ParameterModifierType:
					if (!(typeDst is ParameterModifierType parameterModifierType) || parameterModifierType.IsOut != ((ParameterModifierType)typeSrc).IsOut)
					{
						return false;
					}
					break;
				case TypeKind.TK_PointerType:
				case TypeKind.TK_NullableType:
					if (typeDst.TypeKind != typeSrc.TypeKind)
					{
						return false;
					}
					break;
				case TypeKind.TK_AggregateType:
				{
					if (!(typeDst is AggregateType aggregateType))
					{
						return false;
					}
					AggregateType aggregateType2 = (AggregateType)typeSrc;
					if (aggregateType2.OwningAggregate != aggregateType.OwningAggregate)
					{
						return false;
					}
					for (int i = 0; i < aggregateType2.TypeArgsAll.Count; i++)
					{
						if (!SubstEqualTypesCore(aggregateType.TypeArgsAll[i], aggregateType2.TypeArgsAll[i], pctx))
						{
							return false;
						}
					}
					return true;
				}
				case TypeKind.TK_TypeParameterType:
				{
					TypeParameterSymbol symbol = ((TypeParameterType)typeSrc).Symbol;
					int indexInTotalParameters = symbol.GetIndexInTotalParameters();
					if (symbol.IsMethodTypeParameter())
					{
						if (pctx.DenormMeth && symbol.parent != null)
						{
							return false;
						}
						if (indexInTotalParameters < pctx.MethodTypes.Length)
						{
							return typeDst == pctx.MethodTypes[indexInTotalParameters];
						}
					}
					else if (indexInTotalParameters < pctx.ClassTypes.Length)
					{
						return typeDst == pctx.ClassTypes[indexInTotalParameters];
					}
					return false;
				}
				}
				typeSrc = typeSrc.BaseOrParameterOrElementType;
				typeDst = typeDst.BaseOrParameterOrElementType;
			}
			return true;
		}

		public static bool TypeContainsType(CType type, CType typeFind)
		{
			while (type != typeFind && !type.Equals(typeFind))
			{
				switch (type.TypeKind)
				{
				default:
					return false;
				case TypeKind.TK_VoidType:
				case TypeKind.TK_NullType:
					return false;
				case TypeKind.TK_ArrayType:
				case TypeKind.TK_PointerType:
				case TypeKind.TK_ParameterModifierType:
				case TypeKind.TK_NullableType:
					break;
				case TypeKind.TK_AggregateType:
				{
					AggregateType aggregateType = (AggregateType)type;
					for (int i = 0; i < aggregateType.TypeArgsAll.Count; i++)
					{
						if (TypeContainsType(aggregateType.TypeArgsAll[i], typeFind))
						{
							return true;
						}
					}
					return false;
				}
				case TypeKind.TK_TypeParameterType:
					return false;
				}
				type = type.BaseOrParameterOrElementType;
			}
			return true;
		}

		public static bool TypeContainsTyVars(CType type, TypeArray typeVars)
		{
			while (true)
			{
				switch (type.TypeKind)
				{
				default:
					return false;
				case TypeKind.TK_VoidType:
				case TypeKind.TK_NullType:
				case TypeKind.TK_MethodGroupType:
					return false;
				case TypeKind.TK_ArrayType:
				case TypeKind.TK_PointerType:
				case TypeKind.TK_ParameterModifierType:
				case TypeKind.TK_NullableType:
					break;
				case TypeKind.TK_AggregateType:
				{
					AggregateType aggregateType = (AggregateType)type;
					for (int i = 0; i < aggregateType.TypeArgsAll.Count; i++)
					{
						if (TypeContainsTyVars(aggregateType.TypeArgsAll[i], typeVars))
						{
							return true;
						}
					}
					return false;
				}
				case TypeKind.TK_TypeParameterType:
					if (typeVars != null && typeVars.Count > 0)
					{
						int indexInTotalParameters = ((TypeParameterType)type).IndexInTotalParameters;
						if (indexInTotalParameters < typeVars.Count)
						{
							return type == typeVars[indexInTotalParameters];
						}
						return false;
					}
					return true;
				}
				type = type.BaseOrParameterOrElementType;
			}
		}

		public static AggregateSymbol GetPredefAgg(PredefinedType pt)
		{
			return PredefinedTypes.GetPredefinedAggregate(pt);
		}

		public static AggregateType SubstType(AggregateType typeSrc, SubstContext ctx)
		{
			if (ctx != null && !ctx.IsNop)
			{
				return SubstTypeCore(typeSrc, ctx);
			}
			return typeSrc;
		}

		public static CType SubstType(CType typeSrc, SubstContext pctx)
		{
			if (pctx != null && !pctx.IsNop)
			{
				return SubstTypeCore(typeSrc, pctx);
			}
			return typeSrc;
		}

		public static CType SubstType(CType typeSrc, AggregateType atsCls)
		{
			return SubstType(typeSrc, atsCls, null);
		}

		public static CType SubstType(CType typeSrc, AggregateType atsCls, TypeArray typeArgsMeth)
		{
			return SubstType(typeSrc, atsCls?.TypeArgsAll, typeArgsMeth);
		}

		public static CType SubstType(CType typeSrc, CType typeCls, TypeArray typeArgsMeth)
		{
			return SubstType(typeSrc, (typeCls as AggregateType)?.TypeArgsAll, typeArgsMeth);
		}

		public static TypeArray SubstTypeArray(TypeArray taSrc, AggregateType atsCls, TypeArray typeArgsMeth)
		{
			return SubstTypeArray(taSrc, atsCls?.TypeArgsAll, typeArgsMeth);
		}

		public static TypeArray SubstTypeArray(TypeArray taSrc, AggregateType atsCls)
		{
			return SubstTypeArray(taSrc, atsCls, null);
		}

		private static bool SubstEqualTypes(CType typeDst, CType typeSrc, CType typeCls, TypeArray typeArgsMeth)
		{
			return SubstEqualTypes(typeDst, typeSrc, (typeCls as AggregateType)?.TypeArgsAll, typeArgsMeth, denormMeth: false);
		}

		public static bool SubstEqualTypes(CType typeDst, CType typeSrc, CType typeCls)
		{
			return SubstEqualTypes(typeDst, typeSrc, typeCls, null);
		}

		public static TypeParameterType GetStdMethTypeVar(int iv)
		{
			return s_stvcMethod.GetTypeVarSym(iv, fMeth: true);
		}

		public static TypeParameterType GetTypeParameter(TypeParameterSymbol pSymbol)
		{
			return new TypeParameterType(pSymbol);
		}

		internal static CType GetBestAccessibleType(AggregateSymbol context, CType typeSrc)
		{
			if (CSemanticChecker.CheckTypeAccess(typeSrc, context))
			{
				return typeSrc;
			}
			AggregateType aggregateType = typeSrc as AggregateType;
			if (aggregateType != null)
			{
				AggregateType baseClass;
				while (true)
				{
					if ((aggregateType.IsInterfaceType || aggregateType.IsDelegateType) && TryVarianceAdjustmentToGetAccessibleType(context, aggregateType, out var typeDst))
					{
						return typeDst;
					}
					baseClass = aggregateType.BaseClass;
					if (baseClass == null)
					{
						return GetPredefAgg(PredefinedType.PT_OBJECT).getThisType();
					}
					if (CSemanticChecker.CheckTypeAccess(baseClass, context))
					{
						break;
					}
					aggregateType = baseClass;
				}
				return baseClass;
			}
			if (typeSrc is ArrayType typeSrc2)
			{
				if (TryArrayVarianceAdjustmentToGetAccessibleType(context, typeSrc2, out var typeDst2))
				{
					return typeDst2;
				}
				return GetPredefAgg(PredefinedType.PT_ARRAY).getThisType();
			}
			return GetPredefAgg(PredefinedType.PT_VALUE).getThisType();
		}

		private static bool TryVarianceAdjustmentToGetAccessibleType(AggregateSymbol context, AggregateType typeSrc, out CType typeDst)
		{
			typeDst = null;
			AggregateSymbol owningAggregate = typeSrc.OwningAggregate;
			AggregateType thisType = owningAggregate.getThisType();
			if (!CSemanticChecker.CheckTypeAccess(thisType, context))
			{
				return false;
			}
			TypeArray typeArgsThis = typeSrc.TypeArgsThis;
			TypeArray typeArgsThis2 = thisType.TypeArgsThis;
			CType[] array = new CType[typeArgsThis.Count];
			for (int i = 0; i < array.Length; i++)
			{
				CType cType = typeArgsThis[i];
				if (CSemanticChecker.CheckTypeAccess(cType, context))
				{
					array[i] = cType;
					continue;
				}
				if (!cType.IsReferenceType || !((TypeParameterType)typeArgsThis2[i]).Covariant)
				{
					return false;
				}
				array[i] = GetBestAccessibleType(context, cType);
			}
			TypeArray typeArgs = TypeArray.Allocate(array);
			CType aggregate = GetAggregate(owningAggregate, typeSrc.OuterType, typeArgs);
			if (!TypeBind.CheckConstraints(aggregate, CheckConstraintsFlags.NoErrors))
			{
				return false;
			}
			typeDst = aggregate;
			return true;
		}

		private static bool TryArrayVarianceAdjustmentToGetAccessibleType(AggregateSymbol context, ArrayType typeSrc, out CType typeDst)
		{
			CType elementType = typeSrc.ElementType;
			if (elementType.IsReferenceType)
			{
				CType bestAccessibleType = GetBestAccessibleType(context, elementType);
				typeDst = GetArray(bestAccessibleType, typeSrc.Rank, typeSrc.IsSZArray);
				return true;
			}
			typeDst = null;
			return false;
		}

		internal static bool InternalsVisibleTo(Assembly assemblyThatDefinesAttribute, Assembly assemblyToCheck)
		{
			(Assembly, Assembly) key = (assemblyThatDefinesAttribute, assemblyToCheck);
			if (!s_internalsVisibleToCache.TryGetValue(key, out var value))
			{
				try
				{
					AssemblyName assyName = assemblyToCheck.GetName();
					value = (from ivta in assemblyThatDefinesAttribute.GetCustomAttributes().OfType<InternalsVisibleToAttribute>()
						select new AssemblyName(ivta.AssemblyName)).Any((AssemblyName an) => AssemblyName.ReferenceMatchesDefinition(an, assyName));
				}
				catch (SecurityException)
				{
					value = false;
				}
				s_internalsVisibleToCache[key] = value;
			}
			return value;
		}
	}
	internal sealed class TypeParameterType : CType
	{
		public TypeParameterSymbol Symbol { get; }

		public ParentSymbol OwningSymbol => Symbol.parent;

		public Name Name => Symbol.name;

		public bool Covariant => Symbol.Covariant;

		public bool Invariant => Symbol.Invariant;

		public bool Contravariant => Symbol.Contravariant;

		public override bool IsValueType => Symbol.IsValueType();

		public override bool IsReferenceType => Symbol.IsReferenceType();

		public override bool IsNonNullableValueType => Symbol.IsNonNullableValueType();

		public bool HasNewConstraint => Symbol.HasNewConstraint();

		public bool HasRefConstraint => Symbol.HasRefConstraint();

		public bool HasValConstraint => Symbol.HasValConstraint();

		public bool IsMethodTypeParameter => Symbol.IsMethodTypeParameter();

		public int IndexInOwnParameters => Symbol.GetIndexInOwnParameters();

		public int IndexInTotalParameters => Symbol.GetIndexInTotalParameters();

		public TypeArray Bounds => Symbol.GetBounds();

		public override Type AssociatedSystemType => (IsMethodTypeParameter ? ((MethodInfo)((MethodSymbol)OwningSymbol).AssociatedMemberInfo).GetGenericArguments() : ((AggregateSymbol)OwningSymbol).AssociatedSystemType.GetGenericArguments())[IndexInOwnParameters];

		public override FUNDTYPE FundamentalType => FUNDTYPE.FT_VAR;

		public TypeParameterType(TypeParameterSymbol symbol)
			: base(TypeKind.TK_TypeParameterType)
		{
			Symbol = symbol;
			symbol.SetTypeParameterType(this);
		}
	}
	internal static class TypeTable
	{
		private readonly struct KeyPair<TKey1, TKey2>(TKey1 pKey1, TKey2 pKey2) : IEquatable<KeyPair<TKey1, TKey2>>
		{
			private readonly TKey1 _pKey1 = pKey1;

			private readonly TKey2 _pKey2 = pKey2;

			public bool Equals(KeyPair<TKey1, TKey2> other)
			{
				if (EqualityComparer<TKey1>.Default.Equals(_pKey1, other._pKey1))
				{
					return EqualityComparer<TKey2>.Default.Equals(_pKey2, other._pKey2);
				}
				return false;
			}

			public override bool Equals(object obj)
			{
				if (!(obj is KeyPair<TKey1, TKey2>))
				{
					return false;
				}
				return Equals((KeyPair<TKey1, TKey2>)obj);
			}

			public override int GetHashCode()
			{
				int num = ((_pKey1 != null) ? _pKey1.GetHashCode() : 0);
				return (num << 5) - num + ((_pKey2 != null) ? _pKey2.GetHashCode() : 0);
			}
		}

		private static readonly Dictionary<KeyPair<AggregateSymbol, KeyPair<AggregateType, TypeArray>>, AggregateType> s_aggregateTable = new Dictionary<KeyPair<AggregateSymbol, KeyPair<AggregateType, TypeArray>>, AggregateType>();

		private static readonly Dictionary<KeyPair<CType, int>, ArrayType> s_arrayTable = new Dictionary<KeyPair<CType, int>, ArrayType>();

		private static readonly Dictionary<KeyPair<CType, bool>, ParameterModifierType> s_parameterModifierTable = new Dictionary<KeyPair<CType, bool>, ParameterModifierType>();

		private static readonly Dictionary<CType, PointerType> s_pointerTable = new Dictionary<CType, PointerType>();

		private static readonly Dictionary<CType, NullableType> s_nullableTable = new Dictionary<CType, NullableType>();

		private static KeyPair<TKey1, TKey2> MakeKey<TKey1, TKey2>(TKey1 key1, TKey2 key2)
		{
			return new KeyPair<TKey1, TKey2>(key1, key2);
		}

		public static AggregateType LookupAggregate(AggregateSymbol aggregate, AggregateType outer, TypeArray args)
		{
			s_aggregateTable.TryGetValue(MakeKey(aggregate, MakeKey(outer, args)), out var value);
			return value;
		}

		public static void InsertAggregate(AggregateSymbol aggregate, AggregateType outer, TypeArray args, AggregateType ats)
		{
			s_aggregateTable.Add(MakeKey(aggregate, MakeKey(outer, args)), ats);
		}

		public static ArrayType LookupArray(CType elementType, int rankNum)
		{
			s_arrayTable.TryGetValue(new KeyPair<CType, int>(elementType, rankNum), out var value);
			return value;
		}

		public static void InsertArray(CType elementType, int rankNum, ArrayType pArray)
		{
			s_arrayTable.Add(new KeyPair<CType, int>(elementType, rankNum), pArray);
		}

		public static ParameterModifierType LookupParameterModifier(CType elementType, bool isOut)
		{
			s_parameterModifierTable.TryGetValue(new KeyPair<CType, bool>(elementType, isOut), out var value);
			return value;
		}

		public static void InsertParameterModifier(CType elementType, bool isOut, ParameterModifierType parameterModifier)
		{
			s_parameterModifierTable.Add(new KeyPair<CType, bool>(elementType, isOut), parameterModifier);
		}

		public static PointerType LookupPointer(CType elementType)
		{
			s_pointerTable.TryGetValue(elementType, out var value);
			return value;
		}

		public static void InsertPointer(CType elementType, PointerType pointer)
		{
			s_pointerTable.Add(elementType, pointer);
		}

		public static NullableType LookupNullable(CType underlyingType)
		{
			s_nullableTable.TryGetValue(underlyingType, out var value);
			return value;
		}

		public static void InsertNullable(CType underlyingType, NullableType nullable)
		{
			s_nullableTable.Add(underlyingType, nullable);
		}
	}
	internal sealed class VoidType : CType
	{
		public static readonly VoidType Instance = new VoidType();

		private VoidType()
			: base(TypeKind.TK_VoidType)
		{
		}

		public override bool IsPredefType(PredefinedType pt)
		{
			return pt == PredefinedType.PT_VOID;
		}
	}
	internal class SymWithType
	{
		private AggregateType _ats;

		private Symbol _sym;

		public AggregateType Ats => _ats;

		public Symbol Sym => _sym;

		public SymWithType()
		{
		}

		public SymWithType(Symbol sym, AggregateType ats)
		{
			Set(sym, ats);
		}

		public virtual void Clear()
		{
			_sym = null;
			_ats = null;
		}

		public new AggregateType GetType()
		{
			return Ats;
		}

		public static bool operator ==(SymWithType swt1, SymWithType swt2)
		{
			if ((object)swt1 == swt2)
			{
				return true;
			}
			if ((object)swt1 == null)
			{
				return swt2._sym == null;
			}
			if ((object)swt2 == null)
			{
				return swt1._sym == null;
			}
			if (swt1.Sym == swt2.Sym)
			{
				return swt1.Ats == swt2.Ats;
			}
			return false;
		}

		public static bool operator !=(SymWithType swt1, SymWithType swt2)
		{
			return !(swt1 == swt2);
		}

		[ExcludeFromCodeCoverage]
		public override bool Equals(object obj)
		{
			SymWithType symWithType = obj as SymWithType;
			if (symWithType == null)
			{
				return false;
			}
			if (Sym == symWithType.Sym)
			{
				return Ats == symWithType.Ats;
			}
			return false;
		}

		[ExcludeFromCodeCoverage]
		public override int GetHashCode()
		{
			return (Sym?.GetHashCode() ?? 0) + (Ats?.GetHashCode() ?? 0);
		}

		public static implicit operator bool(SymWithType swt)
		{
			return swt != null;
		}

		public MethodOrPropertySymbol MethProp()
		{
			return Sym as MethodOrPropertySymbol;
		}

		public MethodSymbol Meth()
		{
			return Sym as MethodSymbol;
		}

		public PropertySymbol Prop()
		{
			return Sym as PropertySymbol;
		}

		public FieldSymbol Field()
		{
			return Sym as FieldSymbol;
		}

		public EventSymbol Event()
		{
			return Sym as EventSymbol;
		}

		public void Set(Symbol sym, AggregateType ats)
		{
			if (sym == null)
			{
				ats = null;
			}
			_sym = sym;
			_ats = ats;
		}
	}
	internal class MethPropWithType : SymWithType
	{
		public MethPropWithType()
		{
		}

		public MethPropWithType(MethodOrPropertySymbol mps, AggregateType ats)
		{
			Set(mps, ats);
		}
	}
	internal sealed class MethWithType : MethPropWithType
	{
		public MethWithType()
		{
		}

		public MethWithType(MethodSymbol meth, AggregateType ats)
		{
			Set(meth, ats);
		}
	}
	internal sealed class PropWithType : MethPropWithType
	{
		public PropWithType(PropertySymbol prop, AggregateType ats)
		{
			Set(prop, ats);
		}

		public PropWithType(SymWithType swt)
		{
			Set(swt.Sym as PropertySymbol, swt.Ats);
		}
	}
	internal sealed class EventWithType : SymWithType
	{
		public EventWithType(EventSymbol @event, AggregateType ats)
		{
			Set(@event, ats);
		}
	}
	internal sealed class FieldWithType : SymWithType
	{
		public FieldWithType(FieldSymbol field, AggregateType ats)
		{
			Set(field, ats);
		}
	}
	internal class MethPropWithInst : MethPropWithType
	{
		public TypeArray TypeArgs { get; private set; }

		public MethPropWithInst()
		{
			Set(null, null, null);
		}

		public MethPropWithInst(MethodOrPropertySymbol mps, AggregateType ats)
			: this(mps, ats, null)
		{
		}

		public MethPropWithInst(MethodOrPropertySymbol mps, AggregateType ats, TypeArray typeArgs)
		{
			Set(mps, ats, typeArgs);
		}

		public override void Clear()
		{
			base.Clear();
			TypeArgs = null;
		}

		public void Set(MethodOrPropertySymbol mps, AggregateType ats, TypeArray typeArgs)
		{
			if (mps == null)
			{
				ats = null;
				typeArgs = null;
			}
			Set(mps, ats);
			TypeArgs = typeArgs;
		}
	}
	internal sealed class MethWithInst : MethPropWithInst
	{
		public MethWithInst(MethodSymbol meth, AggregateType ats)
			: this(meth, ats, null)
		{
		}

		public MethWithInst(MethodSymbol meth, AggregateType ats, TypeArray typeArgs)
		{
			Set(meth, ats, typeArgs);
		}

		public MethWithInst(MethPropWithInst mpwi)
		{
			Set(mpwi.Sym as MethodSymbol, mpwi.Ats, mpwi.TypeArgs);
		}
	}
}
namespace Microsoft.CSharp.RuntimeBinder.Errors
{
	internal enum ErrorCode
	{
		ERR_BadBinaryOps = 19,
		ERR_BadIndexLHS = 21,
		ERR_BadIndexCount = 22,
		ERR_BadUnaryOp = 23,
		ERR_NoImplicitConv = 29,
		ERR_NoExplicitConv = 30,
		ERR_ConstOutOfRange = 31,
		ERR_AmbigBinaryOps = 34,
		ERR_AmbigUnaryOp = 35,
		ERR_ValueCantBeNull = 37,
		ERR_NoSuchMember = 117,
		ERR_ObjectRequired = 120,
		ERR_AmbigCall = 121,
		ERR_BadAccess = 122,
		ERR_AssgLvalueExpected = 131,
		ERR_NoConstructors = 143,
		ERR_PropertyLacksGet = 154,
		ERR_ObjectProhibited = 176,
		ERR_AssgReadonly = 191,
		ERR_AssgReadonlyStatic = 198,
		ERR_AssgReadonlyProp = 200,
		ERR_UnsafeNeeded = 214,
		ERR_BadBoolOp = 217,
		ERR_MustHaveOpTF = 218,
		ERR_ConstOutOfRangeChecked = 221,
		ERR_AmbigMember = 229,
		ERR_NoImplicitConvCast = 266,
		ERR_InaccessibleGetter = 271,
		ERR_InaccessibleSetter = 272,
		ERR_BadArity = 305,
		ERR_TypeArgsNotAllowed = 307,
		ERR_HasNoTypeVars = 308,
		ERR_NewConstraintNotSatisfied = 310,
		ERR_GenericConstraintNotSatisfiedRefType = 311,
		ERR_GenericConstraintNotSatisfiedNullableEnum = 312,
		ERR_GenericConstraintNotSatisfiedNullableInterface = 313,
		ERR_GenericConstraintNotSatisfiedValType = 315,
		ERR_CantInferMethTypeArgs = 411,
		ERR_RefConstraintNotSatisfied = 452,
		ERR_ValConstraintNotSatisfied = 453,
		ERR_AmbigUDConv = 457,
		ERR_BindToBogus = 570,
		ERR_CantCallSpecialMethod = 571,
		ERR_ConvertToStaticClass = 716,
		ERR_IncrementLvalueExpected = 1059,
		ERR_BadArgCount = 1501,
		ERR_BadArgTypes = 1502,
		ERR_BadProtectedAccess = 1540,
		ERR_BindToBogusProp2 = 1545,
		ERR_BindToBogusProp1 = 1546,
		ERR_BadDelArgCount = 1593,
		ERR_BadDelArgTypes = 1594,
		ERR_BadCtorArgCount = 1729,
		ERR_BadNamedArgument = 1739,
		ERR_DuplicateNamedArgument = 1740,
		ERR_NamedArgumentUsedInPositional = 1744,
		ERR_BadNamedArgumentForDelegateInvoke = 1746,
		ERR_NonInvocableMemberCalled = 1955,
		ERR_BadNonTrailingNamedArgument = 8323
	}
	internal static class ErrorFacts
	{
		public static string GetMessage(ErrorCode code)
		{
			return code switch
			{
				ErrorCode.ERR_BadBinaryOps => "Operator '{0}' cannot be applied to operands of type '{1}' and '{2}'", 
				ErrorCode.ERR_BadIndexLHS => "Cannot apply indexing with [] to an expression of type '{0}'", 
				ErrorCode.ERR_BadIndexCount => "Wrong number of indices inside []; expected '{0}'", 
				ErrorCode.ERR_BadUnaryOp => "Operator '{0}' cannot be applied to operand of type '{1}'", 
				ErrorCode.ERR_NoImplicitConv => "Cannot implicitly convert type '{0}' to '{1}'", 
				ErrorCode.ERR_NoExplicitConv => "Cannot convert type '{0}' to '{1}'", 
				ErrorCode.ERR_ConstOutOfRange => "Constant value '{0}' cannot be converted to a '{1}'", 
				ErrorCode.ERR_AmbigBinaryOps => "Operator '{0}' is ambiguous on operands of type '{1}' and '{2}'", 
				ErrorCode.ERR_AmbigUnaryOp => "Operator '{0}' is ambiguous on an operand of type '{1}'", 
				ErrorCode.ERR_ValueCantBeNull => "Cannot convert null to '{0}' because it is a non-nullable value type", 
				ErrorCode.ERR_NoSuchMember => "'{0}' does not contain a definition for '{1}'", 
				ErrorCode.ERR_ObjectRequired => "An object reference is required for the non-static field, method, or property '{0}'", 
				ErrorCode.ERR_AmbigCall => "The call is ambiguous between the following methods or properties: '{0}' and '{1}'", 
				ErrorCode.ERR_BadAccess => "'{0}' is inaccessible due to its protection level", 
				ErrorCode.ERR_AssgLvalueExpected => "The left-hand side of an assignment must be a variable, property or indexer", 
				ErrorCode.ERR_NoConstructors => "The type '{0}' has no constructors defined", 
				ErrorCode.ERR_PropertyLacksGet => "The property or indexer '{0}' cannot be used in this context because it lacks the get accessor", 
				ErrorCode.ERR_ObjectProhibited => "Member '{0}' cannot be accessed with an instance reference; qualify it with a type name instead", 
				ErrorCode.ERR_AssgReadonly => "A readonly field cannot be assigned to (except in a constructor or a variable initializer)", 
				ErrorCode.ERR_AssgReadonlyStatic => "A static readonly field cannot be assigned to (except in a static constructor or a variable initializer)", 
				ErrorCode.ERR_AssgReadonlyProp => "Property or indexer '{0}' cannot be assigned to -- it is read only", 
				ErrorCode.ERR_UnsafeNeeded => "Dynamic calls cannot be used in conjunction with pointers", 
				ErrorCode.ERR_BadBoolOp => "In order to be applicable as a short circuit operator a user-defined logical operator ('{0}') must have the same return type as the type of its 2 parameters", 
				ErrorCode.ERR_MustHaveOpTF => "The type ('{0}') must contain declarations of operator true and operator false", 
				ErrorCode.ERR_ConstOutOfRangeChecked => "Constant value '{0}' cannot be converted to a '{1}' (use 'unchecked' syntax to override)", 
				ErrorCode.ERR_AmbigMember => "Ambiguity between '{0}' and '{1}'", 
				ErrorCode.ERR_NoImplicitConvCast => "Cannot implicitly convert type '{0}' to '{1}'. An explicit conversion exists (are you missing a cast?)", 
				ErrorCode.ERR_InaccessibleGetter => "The property or indexer '{0}' cannot be used in this context because the get accessor is inaccessible", 
				ErrorCode.ERR_InaccessibleSetter => "The property or indexer '{0}' cannot be used in this context because the set accessor is inaccessible", 
				ErrorCode.ERR_BadArity => "Using the generic {1} '{0}' requires '{2}' type arguments", 
				ErrorCode.ERR_TypeArgsNotAllowed => "The {1} '{0}' cannot be used with type arguments", 
				ErrorCode.ERR_HasNoTypeVars => "The non-generic {1} '{0}' cannot be used with type arguments", 
				ErrorCode.ERR_NewConstraintNotSatisfied => "'{2}' must be a non-abstract type with a public parameterless constructor in order to use it as parameter '{1}' in the generic type or method '{0}'", 
				ErrorCode.ERR_GenericConstraintNotSatisfiedRefType => "The type '{3}' cannot be used as type parameter '{2}' in the generic type or method '{0}'. There is no implicit reference conversion from '{3}' to '{1}'.", 
				ErrorCode.ERR_GenericConstraintNotSatisfiedNullableEnum => "The type '{3}' cannot be used as type parameter '{2}' in the generic type or method '{0}'. The nullable type '{3}' does not satisfy the constraint of '{1}'.", 
				ErrorCode.ERR_GenericConstraintNotSatisfiedNullableInterface => "The type '{3}' cannot be used as type parameter '{2}' in the generic type or method '{0}'. The nullable type '{3}' does not satisfy the constraint of '{1}'. Nullable types can not satisfy any interface constraints.", 
				ErrorCode.ERR_GenericConstraintNotSatisfiedValType => "The type '{3}' cannot be used as type parameter '{2}' in the generic type or method '{0}'. There is no boxing conversion from '{3}' to '{1}'.", 
				ErrorCode.ERR_CantInferMethTypeArgs => "The type arguments for method '{0}' cannot be inferred from the usage. Try specifying the type arguments explicitly.", 
				ErrorCode.ERR_RefConstraintNotSatisfied => "The type '{2}' must be a reference type in order to use it as parameter '{1}' in the generic type or method '{0}'", 
				ErrorCode.ERR_ValConstraintNotSatisfied => "The type '{2}' must be a non-nullable value type in order to use it as parameter '{1}' in the generic type or method '{0}'", 
				ErrorCode.ERR_AmbigUDConv => "Ambiguous user defined conversions '{0}' and '{1}' when converting from '{2}' to '{3}'", 
				ErrorCode.ERR_BindToBogus => "'{0}' is not supported by the language", 
				ErrorCode.ERR_CantCallSpecialMethod => "'{0}': cannot explicitly call operator or accessor", 
				ErrorCode.ERR_ConvertToStaticClass => "Cannot convert to static type '{0}'", 
				ErrorCode.ERR_IncrementLvalueExpected => "The operand of an increment or decrement operator must be a variable, property or indexer", 
				ErrorCode.ERR_BadArgCount => "No overload for method '{0}' takes {1} arguments", 
				ErrorCode.ERR_BadArgTypes => "The best overloaded method match for '{0}' has some invalid arguments", 
				ErrorCode.ERR_BadProtectedAccess => "Cannot access protected member '{0}' via a qualifier of type '{1}'; the qualifier must be of type '{2}' (or derived from it)", 
				ErrorCode.ERR_BindToBogusProp2 => "Property, indexer, or event '{0}' is not supported by the language; try directly calling accessor methods '{1}' or '{2}'", 
				ErrorCode.ERR_BindToBogusProp1 => "Property, indexer, or event '{0}' is not supported by the language; try directly calling accessor method '{1}'", 
				ErrorCode.ERR_BadDelArgCount => "Delegate '{0}' does not take '{1}' arguments", 
				ErrorCode.ERR_BadDelArgTypes => "Delegate '{0}' has some invalid arguments", 
				ErrorCode.ERR_BadCtorArgCount => "'{0}' does not contain a constructor that takes '{1}' arguments", 
				ErrorCode.ERR_NonInvocableMemberCalled => "Non-invocable member '{0}' cannot be used like a method.", 
				ErrorCode.ERR_BadNamedArgument => "The best overload for '{0}' does not have a parameter named '{1}'", 
				ErrorCode.ERR_BadNamedArgumentForDelegateInvoke => "The delegate '{0}' does not have a parameter named '{1}'", 
				ErrorCode.ERR_DuplicateNamedArgument => "Named argument '{0}' cannot be specified multiple times", 
				ErrorCode.ERR_NamedArgumentUsedInPositional => "Named argument '{0}' specifies a parameter for which a positional argument has already been given", 
				ErrorCode.ERR_BadNonTrailingNamedArgument => "Named argument '{0}' is used out-of-position but is followed by an unnamed argument", 
				_ => null, 
			};
		}

		public static string GetMessage(MessageID id)
		{
			return id.ToString();
		}
	}
	internal enum ErrArgKind
	{
		Int,
		SymKind,
		Sym,
		Type,
		Name,
		Str,
		SymWithType,
		MethWithInst
	}
	[Flags]
	internal enum ErrArgFlags
	{
		None = 0,
		NoStr = 2,
		Unique = 4,
		UseGetErrorInfo = 8
	}
	internal sealed class SymWithTypeMemo
	{
		public Symbol sym;

		public AggregateType ats;
	}
	internal sealed class MethPropWithInstMemo
	{
		public Symbol sym;

		public AggregateType ats;

		public TypeArray typeArgs;
	}
	internal class ErrArg
	{
		public ErrArgKind eak;

		public ErrArgFlags eaf;

		internal int n;

		internal SYMKIND sk;

		internal Name name;

		internal Symbol sym;

		internal string psz;

		internal CType pType;

		internal MethPropWithInstMemo mpwiMemo;

		internal SymWithTypeMemo swtMemo;

		public ErrArg()
		{
		}

		public ErrArg(int n)
		{
			eak = ErrArgKind.Int;
			eaf = ErrArgFlags.None;
			this.n = n;
		}

		public ErrArg(Name name)
		{
			eak = ErrArgKind.Name;
			eaf = ErrArgFlags.None;
			this.name = name;
		}

		public ErrArg(string psz)
		{
			eak = ErrArgKind.Str;
			eaf = ErrArgFlags.None;
			this.psz = psz;
		}

		public ErrArg(CType pType)
			: this(pType, ErrArgFlags.None)
		{
		}

		public ErrArg(CType pType, ErrArgFlags eaf)
		{
			eak = ErrArgKind.Type;
			this.eaf = eaf;
			this.pType = pType;
		}

		public ErrArg(Symbol pSym)
			: this(pSym, ErrArgFlags.None)
		{
		}

		private ErrArg(Symbol pSym, ErrArgFlags eaf)
		{
			eak = ErrArgKind.Sym;
			this.eaf = eaf;
			sym = pSym;
		}

		public ErrArg(SymWithType swt)
		{
			eak = ErrArgKind.SymWithType;
			eaf = ErrArgFlags.None;
			swtMemo = new SymWithTypeMemo();
			swtMemo.sym = swt.Sym;
			swtMemo.ats = swt.Ats;
		}

		public ErrArg(MethPropWithInst mpwi)
		{
			eak = ErrArgKind.MethWithInst;
			eaf = ErrArgFlags.None;
			mpwiMemo = new MethPropWithInstMemo();
			mpwiMemo.sym = mpwi.Sym;
			mpwiMemo.ats = mpwi.Ats;
			mpwiMemo.typeArgs = mpwi.TypeArgs;
		}

		public static implicit operator ErrArg(int n)
		{
			return new ErrArg(n);
		}

		public static implicit operator ErrArg(CType type)
		{
			return new ErrArg(type);
		}

		public static implicit operator ErrArg(string psz)
		{
			return new ErrArg(psz);
		}

		public static implicit operator ErrArg(Name name)
		{
			return new ErrArg(name);
		}

		public static implicit operator ErrArg(Symbol pSym)
		{
			return new ErrArg(pSym);
		}

		public static implicit operator ErrArg(SymWithType swt)
		{
			return new ErrArg(swt);
		}

		public static implicit operator ErrArg(MethPropWithInst mpwi)
		{
			return new ErrArg(mpwi);
		}
	}
	internal sealed class ErrArgRefOnly : ErrArg
	{
		public ErrArgRefOnly(Symbol sym)
			: base(sym)
		{
			eaf = ErrArgFlags.NoStr;
		}
	}
	internal sealed class ErrArgNoRef : ErrArg
	{
		public ErrArgNoRef(CType pType)
		{
			eak = ErrArgKind.Type;
			eaf = ErrArgFlags.None;
			base.pType = pType;
		}
	}
	internal sealed class ErrArgSymKind : ErrArg
	{
		public ErrArgSymKind(Symbol sym)
		{
			eak = ErrArgKind.SymKind;
			eaf = ErrArgFlags.None;
			sk = sym.getKind();
		}
	}
	internal static class ErrorHandling
	{
		public static RuntimeBinderException Error(ErrorCode id, params ErrArg[] args)
		{
			string[] array = new string[args.Length];
			int[] array2 = new int[args.Length];
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			UserStringBuilder userStringBuilder = default(UserStringBuilder);
			for (int i = 0; i < args.Length; i++)
			{
				ErrArg errArg = args[i];
				if ((errArg.eaf & ErrArgFlags.NoStr) == 0)
				{
					if (!userStringBuilder.ErrArgToString(out array[num], errArg, out var fUserStrings) && errArg.eak == ErrArgKind.Int)
					{
						array[num] = errArg.n.ToString(CultureInfo.InvariantCulture);
					}
					num++;
					int num4;
					if (!fUserStrings || (errArg.eaf & ErrArgFlags.Unique) == 0)
					{
						num4 = -1;
					}
					else
					{
						num4 = i;
						num3++;
					}
					array2[num2] = num4;
					num2++;
				}
			}
			int num5 = num;
			if (num3 > 1)
			{
				string[] array3 = new string[num5];
				Array.Copy(array, 0, array3, 0, num5);
				for (int j = 0; j < num5; j++)
				{
					if (array2[j] < 0 || array3[j] != array[j])
					{
						continue;
					}
					ErrArg errArg2 = args[array2[j]];
					Symbol symbol = null;
					CType cType = null;
					switch (errArg2.eak)
					{
					case ErrArgKind.Sym:
						symbol = errArg2.sym;
						break;
					case ErrArgKind.Type:
						cType = errArg2.pType;
						break;
					case ErrArgKind.SymWithType:
						symbol = errArg2.swtMemo.sym;
						break;
					case ErrArgKind.MethWithInst:
						symbol = errArg2.mpwiMemo.sym;
						break;
					default:
						continue;
					}
					bool flag = false;
					for (int k = j + 1; k < num5; k++)
					{
						if (array2[k] < 0 || array[j] != array[k])
						{
							continue;
						}
						if (array3[k] != array[k])
						{
							flag = true;
							continue;
						}
						ErrArg errArg3 = args[array2[k]];
						Symbol symbol2 = null;
						CType cType2 = null;
						switch (errArg3.eak)
						{
						case ErrArgKind.Sym:
							symbol2 = errArg3.sym;
							break;
						case ErrArgKind.Type:
							cType2 = errArg3.pType;
							break;
						case ErrArgKind.SymWithType:
							symbol2 = errArg3.swtMemo.sym;
							break;
						case ErrArgKind.MethWithInst:
							symbol2 = errArg3.mpwiMemo.sym;
							break;
						default:
							continue;
						}
						if (symbol2 != symbol || cType2 != cType || flag)
						{
							array3[k] = array[k];
							flag = true;
						}
					}
					if (flag)
					{
						array3[j] = array[j];
					}
				}
				array = array3;
			}
			CultureInfo invariantCulture = CultureInfo.InvariantCulture;
			string message = ErrorFacts.GetMessage(id);
			object[] args2 = array;
			return new RuntimeBinderException(string.Format(invariantCulture, message, args2));
		}
	}
	internal enum MessageID
	{
		SK_METHOD,
		SK_CLASS,
		SK_NAMESPACE,
		SK_FIELD,
		SK_PROPERTY,
		SK_UNKNOWN,
		SK_VARIABLE,
		SK_EVENT,
		SK_TYVAR,
		SK_ALIAS,
		ERRORSYM,
		NULL,
		GlobalNamespace,
		MethodGroup,
		AnonMethod,
		Lambda
	}
	internal struct UserStringBuilder
	{
		private StringBuilder _strBuilder;

		private void BeginString()
		{
			if (_strBuilder == null)
			{
				_strBuilder = new StringBuilder();
			}
		}

		private string EndString()
		{
			string result = _strBuilder.ToString();
			_strBuilder.Clear();
			return result;
		}

		private static string ErrSK(SYMKIND sk)
		{
			return ErrId(sk switch
			{
				SYMKIND.SK_MethodSymbol => MessageID.SK_METHOD, 
				SYMKIND.SK_AggregateSymbol => MessageID.SK_CLASS, 
				SYMKIND.SK_NamespaceSymbol => MessageID.SK_NAMESPACE, 
				SYMKIND.SK_FieldSymbol => MessageID.SK_FIELD, 
				SYMKIND.SK_LocalVariableSymbol => MessageID.SK_VARIABLE, 
				SYMKIND.SK_PropertySymbol => MessageID.SK_PROPERTY, 
				SYMKIND.SK_EventSymbol => MessageID.SK_EVENT, 
				SYMKIND.SK_TypeParameterSymbol => MessageID.SK_TYVAR, 
				_ => MessageID.SK_UNKNOWN, 
			});
		}

		private void ErrAppendParamList(TypeArray @params, bool isParamArray)
		{
			if (@params == null)
			{
				return;
			}
			for (int i = 0; i < @params.Count; i++)
			{
				if (i > 0)
				{
					ErrAppendString(", ");
				}
				if (isParamArray && i == @params.Count - 1)
				{
					ErrAppendString("params ");
				}
				ErrAppendType(@params[i], null);
			}
		}

		private void ErrAppendString(string str)
		{
			_strBuilder.Append(str);
		}

		private void ErrAppendChar(char ch)
		{
			_strBuilder.Append(ch);
		}

		private void ErrAppendPrintf(string format, params object[] args)
		{
			ErrAppendString(string.Format(CultureInfo.InvariantCulture, format, args));
		}

		private void ErrAppendName(Name name)
		{
			if (name == NameManager.GetPredefinedName(PredefinedName.PN_INDEXERINTERNAL))
			{
				ErrAppendString("this");
			}
			else
			{
				ErrAppendString(name.Text);
			}
		}

		private void ErrAppendParentSym(Symbol sym, SubstContext pctx)
		{
			ErrAppendParentCore(sym.parent, pctx);
		}

		private void ErrAppendParentCore(Symbol parent, SubstContext pctx)
		{
			if (parent != null && parent != NamespaceSymbol.Root)
			{
				if (pctx != null && !pctx.IsNop && parent is AggregateSymbol aggregateSymbol && aggregateSymbol.GetTypeVarsAll().Count != 0)
				{
					CType pType = TypeManager.SubstType(aggregateSymbol.getThisType(), pctx);
					ErrAppendType(pType, null);
				}
				else
				{
					ErrAppendSym(parent, null);
				}
				ErrAppendChar('.');
			}
		}

		private void ErrAppendTypeParameters(TypeArray @params, SubstContext pctx)
		{
			if (@params != null && @params.Count != 0)
			{
				ErrAppendChar('<');
				ErrAppendType(@params[0], pctx);
				for (int i = 1; i < @params.Count; i++)
				{
					ErrAppendString(",");
					ErrAppendType(@params[i], pctx);
				}
				ErrAppendChar('>');
			}
		}

		private void ErrAppendMethod(MethodSymbol meth, SubstContext pctx, bool fArgs)
		{
			if (meth.IsExpImpl() && (bool)meth.swtSlot)
			{
				ErrAppendParentSym(meth, pctx);
				SubstContext pctx2 = new SubstContext(TypeManager.SubstType(meth.swtSlot.GetType(), pctx));
				ErrAppendSym(meth.swtSlot.Sym, pctx2, fArgs);
				return;
			}
			MethodKindEnum methKind = meth.MethKind;
			switch (methKind)
			{
			case MethodKindEnum.PropAccessor:
			{
				PropertySymbol property = meth.getProperty();
				ErrAppendSym(property, pctx);
				if (property.GetterMethod == meth)
				{
					ErrAppendString(".get");
				}
				else
				{
					ErrAppendString(".set");
				}
				return;
			}
			case MethodKindEnum.EventAccessor:
			{
				EventSymbol eventSymbol = meth.getEvent();
				ErrAppendSym(eventSymbol, pctx);
				if (eventSymbol.methAdd == meth)
				{
					ErrAppendString(".add");
				}
				else
				{
					ErrAppendString(".remove");
				}
				return;
			}
			}
			ErrAppendParentSym(meth, pctx);
			switch (methKind)
			{
			case MethodKindEnum.Constructor:
				ErrAppendName(meth.getClass().name);
				break;
			case MethodKindEnum.Destructor:
				ErrAppendChar('~');
				goto case MethodKindEnum.Constructor;
			case MethodKindEnum.ExplicitConv:
				ErrAppendString("explicit");
				goto IL_0118;
			case MethodKindEnum.ImplicitConv:
				ErrAppendString("implicit");
				goto IL_0118;
			default:
				{
					if (meth.isOperator)
					{
						ErrAppendString("operator ");
						ErrAppendString(Operators.OperatorOfMethodName(meth.name));
					}
					else if (!meth.IsExpImpl())
					{
						ErrAppendName(meth.name);
					}
					break;
				}
				IL_0118:
				ErrAppendString(" operator ");
				ErrAppendType(meth.RetType, pctx);
				break;
			}
			ErrAppendTypeParameters(meth.typeVars, pctx);
			if (fArgs)
			{
				ErrAppendChar('(');
				ErrAppendParamList(TypeManager.SubstTypeArray(meth.Params, pctx), meth.isParamArray);
				ErrAppendChar(')');
			}
		}

		private void ErrAppendIndexer(IndexerSymbol indexer, SubstContext pctx)
		{
			ErrAppendString("this[");
			ErrAppendParamList(TypeManager.SubstTypeArray(indexer.Params, pctx), indexer.isParamArray);
			ErrAppendChar(']');
		}

		private void ErrAppendProperty(PropertySymbol prop, SubstContext pctx)
		{
			ErrAppendParentSym(prop, pctx);
			if (prop.IsExpImpl())
			{
				if (prop.swtSlot.Sym != null)
				{
					SubstContext pctx2 = new SubstContext(TypeManager.SubstType(prop.swtSlot.GetType(), pctx));
					ErrAppendSym(prop.swtSlot.Sym, pctx2);
				}
				else if (prop is IndexerSymbol indexer)
				{
					ErrAppendChar('.');
					ErrAppendIndexer(indexer, pctx);
				}
			}
			else if (prop is IndexerSymbol indexer2)
			{
				ErrAppendIndexer(indexer2, pctx);
			}
			else
			{
				ErrAppendName(prop.name);
			}
		}

		private void ErrAppendId(MessageID id)
		{
			ErrAppendString(ErrId(id));
		}

		private void ErrAppendSym(Symbol sym, SubstContext pctx)
		{
			ErrAppendSym(sym, pctx, fArgs: true);
		}

		private void ErrAppendSym(Symbol sym, SubstContext pctx, bool fArgs)
		{
			switch (sym.getKind())
			{
			case SYMKIND.SK_AggregateSymbol:
			{
				string niceName = PredefinedTypes.GetNiceName(sym as AggregateSymbol);
				if (niceName != null)
				{
					ErrAppendString(niceName);
					break;
				}
				ErrAppendParentSym(sym, pctx);
				ErrAppendName(sym.name);
				ErrAppendTypeParameters(((AggregateSymbol)sym).GetTypeVars(), pctx);
				break;
			}
			case SYMKIND.SK_MethodSymbol:
				ErrAppendMethod((MethodSymbol)sym, pctx, fArgs);
				break;
			case SYMKIND.SK_PropertySymbol:
				ErrAppendProperty((PropertySymbol)sym, pctx);
				break;
			case SYMKIND.SK_NamespaceSymbol:
				if (sym == NamespaceSymbol.Root)
				{
					ErrAppendId(MessageID.GlobalNamespace);
					break;
				}
				ErrAppendParentSym(sym, null);
				ErrAppendName(sym.name);
				break;
			case SYMKIND.SK_FieldSymbol:
				ErrAppendParentSym(sym, pctx);
				ErrAppendName(sym.name);
				break;
			case SYMKIND.SK_TypeParameterSymbol:
				if (sym.name == null)
				{
					TypeParameterSymbol typeParameterSymbol = (TypeParameterSymbol)sym;
					if (typeParameterSymbol.IsMethodTypeParameter())
					{
						ErrAppendChar('!');
					}
					ErrAppendChar('!');
					ErrAppendPrintf("{0}", typeParameterSymbol.GetIndexInTotalParameters());
				}
				else
				{
					ErrAppendName(sym.name);
				}
				break;
			case SYMKIND.SK_LocalVariableSymbol:
				ErrAppendName(sym.name);
				break;
			case SYMKIND.SK_EventSymbol:
				break;
			}
		}

		private void ErrAppendType(CType pType, SubstContext pctx)
		{
			if (pctx != null && !pctx.IsNop)
			{
				pType = TypeManager.SubstType(pType, pctx);
			}
			switch (pType.TypeKind)
			{
			case TypeKind.TK_AggregateType:
			{
				AggregateType aggregateType = (AggregateType)pType;
				string niceName = PredefinedTypes.GetNiceName(aggregateType.OwningAggregate);
				if (niceName != null)
				{
					ErrAppendString(niceName);
				}
				else
				{
					if (aggregateType.OuterType != null)
					{
						ErrAppendType(aggregateType.OuterType, null);
						ErrAppendChar('.');
					}
					else
					{
						ErrAppendParentSym(aggregateType.OwningAggregate, null);
					}
					ErrAppendName(aggregateType.OwningAggregate.name);
				}
				ErrAppendTypeParameters(aggregateType.TypeArgsThis, null);
				break;
			}
			case TypeKind.TK_TypeParameterType:
			{
				TypeParameterType typeParameterType = (TypeParameterType)pType;
				if (typeParameterType.Name == null)
				{
					if (typeParameterType.IsMethodTypeParameter)
					{
						ErrAppendChar('!');
					}
					ErrAppendChar('!');
					ErrAppendPrintf("{0}", typeParameterType.IndexInTotalParameters);
				}
				else
				{
					ErrAppendName(typeParameterType.Name);
				}
				break;
			}
			case TypeKind.TK_NullType:
				ErrAppendId(MessageID.NULL);
				break;
			case TypeKind.TK_MethodGroupType:
				ErrAppendId(MessageID.MethodGroup);
				break;
			case TypeKind.TK_ArgumentListType:
				ErrAppendString(TokenFacts.GetText(TokenKind.ArgList));
				break;
			case TypeKind.TK_ArrayType:
			{
				CType baseElementType = ((ArrayType)pType).BaseElementType;
				ErrAppendType(baseElementType, null);
				for (baseElementType = pType; baseElementType is ArrayType { Rank: var rank } arrayType; baseElementType = arrayType.ElementType)
				{
					ErrAppendChar('[');
					if (rank == 1)
					{
						if (!arrayType.IsSZArray)
						{
							ErrAppendChar('*');
						}
					}
					else
					{
						for (int num = rank; num > 1; num--)
						{
							ErrAppendChar(',');
						}
					}
					ErrAppendChar(']');
				}
				break;
			}
			case TypeKind.TK_VoidType:
				ErrAppendName(NameManager.GetPredefinedName(PredefinedName.PN_VOID));
				break;
			case TypeKind.TK_ParameterModifierType:
			{
				ParameterModifierType parameterModifierType = (ParameterModifierType)pType;
				ErrAppendString(parameterModifierType.IsOut ? "out " : "ref ");
				ErrAppendType(parameterModifierType.ParameterType, null);
				break;
			}
			case TypeKind.TK_PointerType:
				ErrAppendType(((PointerType)pType).ReferentType, null);
				ErrAppendChar('*');
				break;
			case TypeKind.TK_NullableType:
				ErrAppendType(((NullableType)pType).UnderlyingType, null);
				ErrAppendChar('?');
				break;
			}
		}

		public bool ErrArgToString(out string psz, ErrArg parg, out bool fUserStrings)
		{
			fUserStrings = false;
			psz = null;
			bool result = true;
			switch (parg.eak)
			{
			case ErrArgKind.SymKind:
				psz = ErrSK(parg.sk);
				break;
			case ErrArgKind.Type:
				BeginString();
				ErrAppendType(parg.pType, null);
				psz = EndString();
				fUserStrings = true;
				break;
			case ErrArgKind.Sym:
				BeginString();
				ErrAppendSym(parg.sym, null);
				psz = EndString();
				fUserStrings = true;
				break;
			case ErrArgKind.Name:
				if (parg.name == NameManager.GetPredefinedName(PredefinedName.PN_INDEXERINTERNAL))
				{
					psz = "this";
				}
				else
				{
					psz = parg.name.Text;
				}
				break;
			case ErrArgKind.Str:
				psz = parg.psz;
				break;
			case ErrArgKind.SymWithType:
			{
				SubstContext pctx2 = new SubstContext(parg.swtMemo.ats, null);
				BeginString();
				ErrAppendSym(parg.swtMemo.sym, pctx2, fArgs: true);
				psz = EndString();
				fUserStrings = true;
				break;
			}
			case ErrArgKind.MethWithInst:
			{
				SubstContext pctx = new SubstContext(parg.mpwiMemo.ats, parg.mpwiMemo.typeArgs);
				BeginString();
				ErrAppendSym(parg.mpwiMemo.sym, pctx, fArgs: true);
				psz = EndString();
				fUserStrings = true;
				break;
			}
			default:
				result = false;
				break;
			}
			return result;
		}

		private static string ErrId(MessageID id)
		{
			return ErrorFacts.GetMessage(id);
		}
	}
}
