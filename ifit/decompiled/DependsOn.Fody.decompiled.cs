using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using DependsOnCore;
using Fody;
using Mono.Cecil;
using Mono.Cecil.Cil;
using Mono.Cecil.Rocks;
using Mono.Collections.Generic;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("Ben Bowden")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyFileVersion("1.0.2")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("DependsOn.Fody")]
[assembly: AssemblyTitle("DependsOn.Fody")]
[assembly: AssemblyVersion("1.0.2.0")]
namespace DependsOnCore
{
	public static class CustomAttributeExtensions
	{
		public static bool IsAttributeOfType(this CustomAttribute attributeType, TypeDefinition type)
		{
			return attributeType.Constructor.DeclaringType.FullName.Equals(type.FullName);
		}

		public static IEnumerable<string> GetParentProperties(this CustomAttribute attr)
		{
			foreach (CustomAttributeArgument constructorArgument in attr.ConstructorArguments)
			{
				if (constructorArgument.Type.FullName == typeof(string[]).FullName)
				{
					if (constructorArgument.Value is CustomAttributeArgument[] array)
					{
						CustomAttributeArgument[] array2 = array;
						foreach (CustomAttributeArgument customAttributeArgument in array2)
						{
							yield return customAttributeArgument.Value.ToString();
						}
					}
				}
				else
				{
					yield return constructorArgument.Value.ToString();
				}
			}
		}
	}
	public class DependentElements
	{
		public List<PropertyDefinition> Properties { get; } = new List<PropertyDefinition>();

		public List<MethodDefinition> Methods { get; } = new List<MethodDefinition>();

		private One Property => new Tester();

		public DependentElements(List<PropertyDefinition> properties, List<MethodDefinition> methods)
		{
			Properties = properties;
			Methods = methods;
		}

		public DependentElements()
		{
			two two2 = (two)Property;
		}
	}
	public interface One
	{
	}
	public interface two : One
	{
	}
	public class Tester : two, One
	{
	}
	public static class InstructionExtensions
	{
		public static bool HasInstruction(this IEnumerable<Instruction> instructions, Instruction toFind)
		{
			string wanted = toFind.ToString();
			return instructions?.Any((Instruction x) => x.ToString() == wanted) ?? false;
		}
	}
	public static class MethodDefinitionExtensions
	{
		public static void AddGeneratedCodeAttribute(this MethodDefinition method, MethodReference generatedCodeCtor, TypeReference stringType)
		{
			CustomAttribute customAttribute = new CustomAttribute(generatedCodeCtor);
			customAttribute.ConstructorArguments.Add(new CustomAttributeArgument(stringType, "Processed by DependsOn.Fody"));
			customAttribute.ConstructorArguments.Add(new CustomAttributeArgument(stringType, "1.0"));
			method.CustomAttributes.Add(customAttribute);
		}
	}
	public static class PropertyDefinitionExtensions
	{
		public static bool IsValidChildPropertyType(this PropertyDefinition property, TypeDefinition wantedType)
		{
			TypeDefinition typeDefinition = property.PropertyType.Resolve();
			return typeDefinition == wantedType || typeDefinition.IsSubclassOfType(wantedType);
		}
	}
	public static class TypeDefinitionExtensions
	{
		public static EventDefinition FindEvent(this TypeDefinition currentType, string eventName)
		{
			EventDefinition eventDefinition = currentType.Events.FirstOrDefault((EventDefinition x) => x.Name == eventName);
			TypeDefinition typeDefinition = currentType.BaseType?.Resolve();
			if (eventDefinition == null && typeDefinition != null)
			{
				eventDefinition = typeDefinition.FindEvent(eventName);
			}
			return eventDefinition;
		}

		public static bool IsSubclassOfType(this TypeDefinition currentType, TypeDefinition parentClass)
		{
			if (currentType.IsClass)
			{
				for (TypeDefinition typeDefinition = currentType.BaseType?.Resolve(); typeDefinition != null; typeDefinition = typeDefinition.BaseType?.Resolve())
				{
					if (typeDefinition.FullName == parentClass.FullName)
					{
						return true;
					}
					if (typeDefinition.Interfaces.Any((InterfaceImplementation x) => x.InterfaceType.FullName == parentClass.FullName))
					{
						return true;
					}
				}
			}
			else if (currentType.IsInterface)
			{
				Collection<InterfaceImplementation> interfaces = currentType.Interfaces;
				return interfaces.Any((InterfaceImplementation x) => x.InterfaceType.FullName == parentClass.FullName);
			}
			return false;
		}

		public static bool HasMethod(this TypeDefinition type, string methodName)
		{
			return type.Methods.FirstOrDefault((MethodDefinition x) => x.Name == methodName) != null;
		}

		public static MethodDefinition FindMethod(this TypeDefinition type, string methodName, params Type[] parameterTypes)
		{
			return type.FindMethod(methodName, parameterTypes.Select((Type x) => x.FullName).ToArray());
		}

		public static MethodDefinition FindMethod(this TypeDefinition type, string methodName, params TypeDefinition[] parameterTypes)
		{
			return type.FindMethod(methodName, parameterTypes.Select((TypeDefinition x) => x.FullName).ToArray());
		}

		public static MethodDefinition FindMethod(this TypeDefinition type, string methodName, params string[] parameterTypes)
		{
			IEnumerable<MethodDefinition> source = type.Methods.Where((MethodDefinition x) => x.Name == methodName);
			MethodDefinition methodDefinition = source.Where((MethodDefinition x) => x.Parameters.Count == parameterTypes.Length).Where(delegate(MethodDefinition x)
			{
				for (int i = 0; i < x.Parameters.Count; i++)
				{
					if (x.Parameters[i].ParameterType.FullName != parameterTypes[i])
					{
						return false;
					}
				}
				return true;
			}).FirstOrDefault();
			if (methodDefinition == null)
			{
				TypeDefinition typeDefinition = type.BaseType?.Resolve();
				if (typeDefinition != null)
				{
					methodDefinition = type.BaseType.Resolve().FindMethod(methodName, parameterTypes);
				}
			}
			return methodDefinition;
		}

		public static bool ParentElementExists(this TypeDefinition viewModelType, string parent)
		{
			FieldDefinition fieldDefinition = viewModelType.Fields.FirstOrDefault((FieldDefinition x) => x.Name == parent);
			bool result = fieldDefinition != null;
			if (fieldDefinition == null)
			{
				PropertyDefinition propertyDefinition = viewModelType.Properties.FirstOrDefault((PropertyDefinition x) => x.Name == parent);
				result = propertyDefinition != null;
			}
			return result;
		}
	}
}
namespace DependsOn
{
	public class ModuleWeaver : BaseModuleWeaver
	{
		protected TypeDefinition shireBaseViewModelType;

		protected TypeDefinition dependsOnAttributeType;

		protected TypeDefinition propertyChangedEventArgsType;

		protected MethodReference propertyNameGetMethod;

		protected TypeDefinition propertyChangedEventHandlerType;

		protected MethodReference propertyChangedEventHandlerCtor;

		protected TypeDefinition generatedCodeAttributeType;

		protected MethodDefinition generatedCodeAttributeCtor;

		private const string ShireBaseViewModel = "Shire.Core.ShireMvx.ShireBaseViewModel";

		private const string DependsOnAttribute = "Shire.Core.PropertyDependency.Attributes.DependsOnAttribute";

		private const string GeneratedCodeAttribute = "System.CodeDom.Compiler.GeneratedCodeAttribute";

		private const string PropertyChangedEventArgs = "PropertyChangedEventArgs";

		private const string PropertyChangedEventHandlerType = "System.ComponentModel.PropertyChangedEventHandler";

		private const string ICommandName = "System.Windows.Input.ICommand";

		protected virtual void LoadRequiredData()
		{
			shireBaseViewModelType = FindTypeDefinition("Shire.Core.ShireMvx.ShireBaseViewModel");
			dependsOnAttributeType = FindTypeDefinition("Shire.Core.PropertyDependency.Attributes.DependsOnAttribute");
			propertyChangedEventArgsType = FindTypeDefinition("PropertyChangedEventArgs");
			propertyChangedEventHandlerType = FindTypeDefinition("System.ComponentModel.PropertyChangedEventHandler");
			generatedCodeAttributeType = FindTypeDefinition("System.CodeDom.Compiler.GeneratedCodeAttribute");
			generatedCodeAttributeCtor = generatedCodeAttributeType.GetConstructors().FirstOrDefault((MethodDefinition x) => x.Parameters.Count == 2);
			PropertyDefinition propertyDefinition = propertyChangedEventArgsType.Properties.FirstOrDefault((PropertyDefinition x) => x.Name == "PropertyName");
			propertyNameGetMethod = base.ModuleDefinition.ImportReference(propertyDefinition.GetMethod);
			propertyChangedEventHandlerCtor = base.ModuleDefinition.ImportReference(propertyChangedEventHandlerType.GetConstructors().FirstOrDefault());
		}

		public override void Execute()
		{
			LoadRequiredData();
			List<TypeDefinition> list = LoadViewModelTypes();
			foreach (TypeDefinition item in list)
			{
				EventDefinition eventDefinition = item.FindEvent("PropertyChanged");
				MethodDefinition raisePropertyChangedMethod = item.FindMethod("RaisePropertyChanged", base.ModuleDefinition.TypeSystem.String.Resolve());
				DependentElements elements = RetrieveDependentElements(item);
				Dictionary<string, DependentElements> parentChildProperties = CreateParentChildElements(elements);
				MethodReference methodReference = item.Module.ImportReference(generatedCodeAttributeCtor);
				MethodDefinition registerDependenciesMethod = GetRegisterDependenciesMethod(parentChildProperties, item, raisePropertyChangedMethod, methodReference);
				if (eventDefinition != null)
				{
					MethodDefinition methodDefinition = CreateRegisterChangeHandlers(registerDependenciesMethod, eventDefinition, methodReference, item);
					item.Methods.Add(methodDefinition);
					MethodDefinition methodDefinition2 = CreateUnregisterChangeHandlers(registerDependenciesMethod, eventDefinition, methodReference, item);
					item.Methods.Add(methodDefinition2);
					UpdateDisposeMethod(item, methodDefinition2, methodReference);
					MethodDefinition ctor = item.GetConstructors().FirstOrDefault();
					UpdateConstructor(ctor, methodDefinition);
				}
			}
		}

		protected virtual List<TypeDefinition> LoadViewModelTypes()
		{
			return (from x in base.ModuleDefinition.GetTypes()
				where x.IsSubclassOfType(shireBaseViewModelType)
				select x).ToList();
		}

		private void UpdateDisposeMethod(TypeDefinition viewModelType, MethodDefinition unregisterChangeHandlers, MethodReference generatedCodeCtor)
		{
			MethodDefinition methodDefinition = viewModelType.Methods.FirstOrDefault((MethodDefinition x) => x.Name == "Dispose");
			if (methodDefinition == null)
			{
				methodDefinition = new MethodDefinition("Dispose", Mono.Cecil.MethodAttributes.Public | Mono.Cecil.MethodAttributes.Virtual, base.ModuleDefinition.TypeSystem.Void);
				for (TypeDefinition typeDefinition = viewModelType.BaseType?.Resolve(); typeDefinition != null; typeDefinition = typeDefinition.BaseType?.Resolve())
				{
					MethodDefinition methodDefinition2 = typeDefinition.Methods.FirstOrDefault((MethodDefinition x) => x.Name == "Dispose");
					if (methodDefinition2 != null)
					{
						MethodReference method = viewModelType.Module.ImportReference(methodDefinition2.Resolve());
						methodDefinition.Attributes = methodDefinition2.Attributes & ~Mono.Cecil.MethodAttributes.VtableLayoutMask;
						methodDefinition.Attributes |= Mono.Cecil.MethodAttributes.CompilerControlled;
						methodDefinition.ImplAttributes = methodDefinition2.ImplAttributes;
						methodDefinition.SemanticsAttributes = methodDefinition2.SemanticsAttributes;
						List<Instruction> list = new List<Instruction>
						{
							Instruction.Create(OpCodes.Ldarg_0),
							Instruction.Create(OpCodes.Call, method),
							Instruction.Create(OpCodes.Ret)
						};
						foreach (Instruction item in list)
						{
							methodDefinition.Body.Instructions.Add(item);
						}
						break;
					}
				}
				methodDefinition.AddGeneratedCodeAttribute(generatedCodeCtor, base.ModuleDefinition.TypeSystem.String);
				viewModelType.Methods.Add(methodDefinition);
			}
			List<Instruction> list2 = new List<Instruction>(methodDefinition.Body.Instructions);
			methodDefinition.Body.Instructions.Clear();
			Instruction instruction = list2.LastOrDefault();
			if (instruction == null)
			{
				instruction = Instruction.Create(OpCodes.Ret);
			}
			else
			{
				list2.Remove(instruction);
			}
			Instruction instruction2 = Instruction.Create(OpCodes.Callvirt, unregisterChangeHandlers);
			if (!list2.HasInstruction(instruction2))
			{
				list2.Add(Instruction.Create(OpCodes.Ldarg_0));
				list2.Add(instruction2);
			}
			list2.Add(instruction);
			foreach (Instruction item2 in list2)
			{
				methodDefinition.Body.Instructions.Add(item2);
			}
		}

		private MethodDefinition CreateUnregisterChangeHandlers(MethodDefinition onPropertyChanged, EventDefinition propertyChangedEvent, MethodReference generatedCodeAttrCtor, TypeDefinition viewModelType)
		{
			MethodDefinition methodDefinition = viewModelType.Methods.FirstOrDefault((MethodDefinition x) => x.Name == "UnregisterChangeHandlers");
			if (methodDefinition == null)
			{
				methodDefinition = new MethodDefinition("UnregisterChangeHandlers", Mono.Cecil.MethodAttributes.Private, base.ModuleDefinition.TypeSystem.Void);
				AddGeneratedCodeAttribute(generatedCodeAttrCtor, methodDefinition);
			}
			else
			{
				methodDefinition.Body.Instructions.RemoveAt(methodDefinition.Body.Instructions.Count - 1);
			}
			Collection<Instruction> instructions = methodDefinition.Body.Instructions;
			if (!viewModelType.HasMethod("UnregisterOnPropertyChanged"))
			{
				MethodDefinition method = CreatePropertyChangedUnregisterMethod(onPropertyChanged, propertyChangedEvent, generatedCodeAttrCtor, viewModelType);
				instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
				instructions.Add(Instruction.Create(OpCodes.Call, method));
			}
			instructions.Add(Instruction.Create(OpCodes.Ret));
			return methodDefinition;
		}

		private MethodDefinition CreatePropertyChangedUnregisterMethod(MethodDefinition onPropertyChanged, EventDefinition propertyChangedEvent, MethodReference generatedCodeAttrCtor, TypeDefinition viewModelType)
		{
			MethodReference method = base.ModuleDefinition.ImportReference(propertyChangedEvent.RemoveMethod);
			MethodDefinition methodDefinition = new MethodDefinition("UnregisterOnPropertyChanged", Mono.Cecil.MethodAttributes.Private, base.ModuleDefinition.TypeSystem.Void);
			AddGeneratedCodeAttribute(generatedCodeAttrCtor, methodDefinition);
			Collection<Instruction> instructions = methodDefinition.Body.Instructions;
			instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
			instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
			instructions.Add(Instruction.Create(OpCodes.Ldftn, onPropertyChanged));
			instructions.Add(Instruction.Create(OpCodes.Newobj, propertyChangedEventHandlerCtor));
			instructions.Add(Instruction.Create(OpCodes.Call, method));
			instructions.Add(Instruction.Create(OpCodes.Ret));
			viewModelType.Methods.Add(methodDefinition);
			return methodDefinition;
		}

		private void UpdateConstructor(MethodDefinition ctor, MethodDefinition registerChangeHandlers)
		{
			Collection<Instruction> instructions = ctor.Body.Instructions;
			Collection<Instruction> collection = new Collection<Instruction>(instructions);
			collection.Remove(instructions.Last());
			collection.Add(Instruction.Create(OpCodes.Ldarg_0));
			collection.Add(Instruction.Create(OpCodes.Call, registerChangeHandlers));
			collection.Add(instructions.Last());
			ctor.Body.Instructions.Clear();
			foreach (Instruction item in collection)
			{
				ctor.Body.Instructions.Add(item);
			}
		}

		private MethodDefinition CreateRegisterChangeHandlers(MethodDefinition onPropertyChanged, EventDefinition propertyChangedEvent, MethodReference generatedCodeAttrCtor, TypeDefinition viewModelType)
		{
			MethodDefinition methodDefinition = viewModelType.Methods.FirstOrDefault((MethodDefinition x) => x.Name == "RegisterChangeHandlers");
			if (methodDefinition == null)
			{
				methodDefinition = new MethodDefinition("RegisterChangeHandlers", Mono.Cecil.MethodAttributes.Private, base.ModuleDefinition.TypeSystem.Void);
				AddGeneratedCodeAttribute(generatedCodeAttrCtor, methodDefinition);
			}
			else
			{
				methodDefinition.Body.Instructions.RemoveAt(methodDefinition.Body.Instructions.Count - 1);
			}
			Collection<Instruction> instructions = methodDefinition.Body.Instructions;
			if (!viewModelType.HasMethod("RegisterOnPropertyChanged"))
			{
				MethodDefinition method = CreatePropertyChangedRegistrationMethod(onPropertyChanged, propertyChangedEvent, generatedCodeAttrCtor, viewModelType);
				instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
				instructions.Add(Instruction.Create(OpCodes.Call, method));
			}
			instructions.Add(Instruction.Create(OpCodes.Ret));
			return methodDefinition;
		}

		private MethodDefinition CreatePropertyChangedRegistrationMethod(MethodDefinition onPropertyChanged, EventDefinition propertyChangedEvent, MethodReference generatedCodeAttrCtor, TypeDefinition viewModelType)
		{
			MethodReference method = base.ModuleDefinition.ImportReference(propertyChangedEvent.AddMethod);
			MethodDefinition methodDefinition = new MethodDefinition("RegisterOnPropertyChanged", Mono.Cecil.MethodAttributes.Private, base.ModuleDefinition.TypeSystem.Void);
			AddGeneratedCodeAttribute(generatedCodeAttrCtor, methodDefinition);
			Collection<Instruction> instructions = methodDefinition.Body.Instructions;
			instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
			instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
			instructions.Add(Instruction.Create(OpCodes.Ldftn, onPropertyChanged));
			instructions.Add(Instruction.Create(OpCodes.Newobj, propertyChangedEventHandlerCtor));
			instructions.Add(Instruction.Create(OpCodes.Call, method));
			instructions.Add(Instruction.Create(OpCodes.Ret));
			viewModelType.Methods.Add(methodDefinition);
			return methodDefinition;
		}

		protected virtual DependentElements RetrieveDependentElements(TypeDefinition viewModelType)
		{
			List<PropertyDefinition> properties = (from x in viewModelType.Properties
				where x.HasCustomAttributes
				where x.CustomAttributes.Any((CustomAttribute y) => y.IsAttributeOfType(dependsOnAttributeType))
				select x).ToList();
			List<MethodDefinition> methods = (from x in viewModelType.Methods
				where x.HasCustomAttributes
				where x.CustomAttributes.Any((CustomAttribute y) => y.IsAttributeOfType(dependsOnAttributeType))
				select x).ToList();
			return new DependentElements(properties, methods);
		}

		private MethodDefinition GetRegisterDependenciesMethod(Dictionary<string, DependentElements> parentChildProperties, TypeDefinition viewModelType, MethodDefinition raisePropertyChangedMethod, MethodReference generatedCodeCtor)
		{
			MethodDefinition methodDefinition = new MethodDefinition("OnPropertyChanged", Mono.Cecil.MethodAttributes.Private, base.ModuleDefinition.TypeSystem.Void);
			methodDefinition.Parameters.Add(new ParameterDefinition("sender", Mono.Cecil.ParameterAttributes.None, base.ModuleDefinition.TypeSystem.Object));
			methodDefinition.Parameters.Add(new ParameterDefinition("args", Mono.Cecil.ParameterAttributes.None, viewModelType.Module.ImportReference(propertyChangedEventArgsType)));
			Collection<Instruction> instructions = methodDefinition.Body.Instructions;
			VariableDefinition variableDefinition = new VariableDefinition(base.ModuleDefinition.TypeSystem.String);
			methodDefinition.Body.Variables.Add(variableDefinition);
			instructions.Add(Instruction.Create(OpCodes.Ldarg_2));
			instructions.Add(Instruction.Create(OpCodes.Callvirt, propertyNameGetMethod));
			instructions.Add(Instruction.Create(OpCodes.Stloc, variableDefinition));
			foreach (KeyValuePair<string, DependentElements> parentChildProperty in parentChildProperties)
			{
				if (ParentElementExists(viewModelType, parentChildProperty))
				{
					WritePropertyNameConditionalCheck(viewModelType, raisePropertyChangedMethod, parentChildProperty, generatedCodeCtor, instructions, variableDefinition, methodDefinition);
				}
			}
			instructions.Add(Instruction.Create(OpCodes.Ret));
			methodDefinition.Body.OptimizeMacros();
			AddGeneratedCodeAttribute(generatedCodeCtor, methodDefinition);
			viewModelType.Methods.Add(methodDefinition);
			return methodDefinition;
		}

		protected virtual bool ParentElementExists(TypeDefinition viewModelType, KeyValuePair<string, DependentElements> parent)
		{
			FieldDefinition fieldDefinition = viewModelType.Fields.FirstOrDefault((FieldDefinition x) => x.Name == parent.Key);
			bool result = fieldDefinition != null;
			if (fieldDefinition == null)
			{
				PropertyDefinition propertyDefinition = viewModelType.Properties.FirstOrDefault((PropertyDefinition x) => x.Name == parent.Key);
				result = propertyDefinition != null;
			}
			return result;
		}

		private void AddGeneratedCodeAttribute(MethodReference generatedCodeCtor, MethodDefinition method)
		{
			CustomAttribute customAttribute = new CustomAttribute(generatedCodeCtor);
			customAttribute.ConstructorArguments.Add(new CustomAttributeArgument(base.ModuleDefinition.TypeSystem.String, "Processed by DependsOn.Fody"));
			customAttribute.ConstructorArguments.Add(new CustomAttributeArgument(base.ModuleDefinition.TypeSystem.String, "1.0"));
			method.CustomAttributes.Add(customAttribute);
		}

		private void WritePropertyNameConditionalCheck(TypeDefinition viewModelType, MethodDefinition raisePropertyChangedMethod, KeyValuePair<string, DependentElements> parent, MethodReference generatedCodeCtor, Collection<Instruction> methodInstructions, VariableDefinition changedPropertyName, MethodDefinition registerDependsOnMethod)
		{
			MethodDefinition methodDefinition = CreateOnPropertyChangedMethod(parent.Key, parent.Value, raisePropertyChangedMethod, generatedCodeCtor);
			viewModelType.Methods.Add(methodDefinition);
			methodInstructions.Add(Instruction.Create(OpCodes.Ldloc, changedPropertyName));
			methodInstructions.Add(Instruction.Create(OpCodes.Castclass, base.ModuleDefinition.TypeSystem.String));
			methodInstructions.Add(Instruction.Create(OpCodes.Ldstr, parent.Key));
			methodInstructions.Add(Instruction.Create(OpCodes.Ceq));
			Instruction instruction = Instruction.Create(OpCodes.Nop);
			methodInstructions.Add(Instruction.Create(OpCodes.Brfalse, instruction));
			methodInstructions.Add(Instruction.Create(OpCodes.Ldarg_0));
			methodInstructions.Add(Instruction.Create(OpCodes.Call, methodDefinition));
			methodInstructions.Add(Instruction.Create(OpCodes.Ret));
			methodInstructions.Add(instruction);
			methodInstructions.Add(Instruction.Create(OpCodes.Nop));
			registerDependsOnMethod.Body.OptimizeMacros();
		}

		protected virtual MethodDefinition CreateOnPropertyChangedMethod(string parentPropertyName, DependentElements dependentElements, MethodDefinition raisePropertyChangedMethod, MethodReference generatedCodeCtor)
		{
			MethodDefinition methodDefinition = new MethodDefinition("On" + parentPropertyName + "Changed", Mono.Cecil.MethodAttributes.Private, base.ModuleDefinition.TypeSystem.Void);
			Collection<Instruction> instructions = methodDefinition.Body.Instructions;
			MethodReference method = base.ModuleDefinition.ImportReference(raisePropertyChangedMethod);
			TypeDefinition iCommandType = FindTypeDefinition("System.Windows.Input.ICommand").Resolve();
			foreach (PropertyDefinition property in dependentElements.Properties)
			{
				if (IsValidChildPropertyType(property, iCommandType))
				{
					instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
					instructions.Add(Instruction.Create(OpCodes.Ldstr, property.Name));
					instructions.Add(Instruction.Create(OpCodes.Call, method));
				}
			}
			TypeDefinition typeDefinition = base.ModuleDefinition.TypeSystem.Void.Resolve();
			foreach (MethodDefinition method2 in dependentElements.Methods)
			{
				Instruction instruction = Instruction.Create(OpCodes.Call, method2.Resolve());
				if (!instructions.HasInstruction(instruction))
				{
					instructions.Add(Instruction.Create(OpCodes.Ldarg_0));
					instructions.Add(instruction);
					if (method2.ReturnType.Resolve() != typeDefinition)
					{
						instructions.Add(Instruction.Create(OpCodes.Pop));
					}
				}
			}
			instructions.Add(Instruction.Create(OpCodes.Ret));
			AddGeneratedCodeAttribute(generatedCodeCtor, methodDefinition);
			return methodDefinition;
		}

		protected virtual bool IsValidChildPropertyType(PropertyDefinition childProperty, TypeDefinition iCommandType)
		{
			TypeDefinition typeDefinition = childProperty.PropertyType.Resolve();
			return typeDefinition != iCommandType && !typeDefinition.IsSubclassOfType(iCommandType);
		}

		private Dictionary<string, DependentElements> CreateParentChildElements(DependentElements elements)
		{
			Dictionary<string, DependentElements> dictionary = new Dictionary<string, DependentElements>();
			foreach (PropertyDefinition property in elements.Properties)
			{
				IEnumerable<string> parentProperties = GetParentProperties(property);
				foreach (string item in parentProperties)
				{
					if (!dictionary.ContainsKey(item))
					{
						dictionary.Add(item, new DependentElements());
					}
					dictionary[item].Properties.Add(property);
				}
			}
			foreach (MethodDefinition method in elements.Methods)
			{
				IEnumerable<string> parentProperties2 = GetParentProperties(method);
				foreach (string item2 in parentProperties2)
				{
					if (!dictionary.ContainsKey(item2))
					{
						dictionary.Add(item2, new DependentElements());
					}
					dictionary[item2].Methods.Add(method);
				}
			}
			return dictionary;
		}

		private IEnumerable<string> GetParentProperties(CustomAttribute attr)
		{
			foreach (CustomAttributeArgument constructorArgument in attr.ConstructorArguments)
			{
				if (constructorArgument.Type.FullName == typeof(string[]).FullName)
				{
					if (constructorArgument.Value is CustomAttributeArgument[] array)
					{
						CustomAttributeArgument[] array2 = array;
						foreach (CustomAttributeArgument customAttributeArgument in array2)
						{
							yield return customAttributeArgument.Value.ToString();
						}
					}
				}
				else
				{
					yield return constructorArgument.Value.ToString();
				}
			}
		}

		private IEnumerable<string> GetParentProperties(MethodDefinition dependentMethod)
		{
			CustomAttribute customAttribute = dependentMethod.CustomAttributes.FirstOrDefault((CustomAttribute x) => x.IsAttributeOfType(dependsOnAttributeType));
			if (customAttribute == null)
			{
				WriteWarning("Found no attribute for " + dependentMethod.Name);
				yield break;
			}
			foreach (string parentProperty in GetParentProperties(customAttribute))
			{
				yield return parentProperty;
			}
		}

		private IEnumerable<string> GetParentProperties(PropertyDefinition dependentProperty)
		{
			CustomAttribute customAttribute = dependentProperty.CustomAttributes.FirstOrDefault((CustomAttribute x) => x.IsAttributeOfType(dependsOnAttributeType));
			if (customAttribute == null)
			{
				WriteWarning("Found no attribute for " + dependentProperty.Name);
				yield break;
			}
			foreach (string parentProperty in GetParentProperties(customAttribute))
			{
				yield return parentProperty;
			}
		}

		public override IEnumerable<string> GetAssembliesForScanning()
		{
			yield return "mscorlib";
			yield return "netstandard";
			yield return "Shire.Core";
		}
	}
}
