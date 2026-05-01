using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Xml;
using Android.Runtime;
using Java.Lang;
using Microsoft.CodeAnalysis;
using Mono.CodeGeneration;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyCopyright("Xamarin Inc.")]
[assembly: AssemblyTrademark("Xamarin")]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: TargetFramework("MonoAndroid,Version=v1.0", FrameworkDisplayName = "Xamarin.Android Base Class Libraries")]
[assembly: AssemblyCompany("Mono.Android.Export")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Mono.Android.Export")]
[assembly: AssemblyTitle("Mono.Android.Export")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: RefSafetyRules(11)]
namespace Microsoft.CodeAnalysis
{
	[CompilerGenerated]
	[Embedded]
	internal sealed class EmbeddedAttribute : Attribute
	{
	}
}
namespace System.Runtime.CompilerServices
{
	[CompilerGenerated]
	[Embedded]
	[AttributeUsage(AttributeTargets.Module, AllowMultiple = false, Inherited = false)]
	internal sealed class RefSafetyRulesAttribute : Attribute
	{
		public readonly int Version;

		public RefSafetyRulesAttribute(int P_0)
		{
			Version = P_0;
		}
	}
}
namespace Mono.CodeGeneration
{
	internal class CodeAnd : CodeConditionExpression
	{
		private CodeExpression exp1;

		private CodeExpression exp2;

		private Type t1;

		private Type t2;

		public CodeAnd(CodeExpression exp1, CodeExpression exp2)
		{
			this.exp1 = exp1;
			this.exp2 = exp2;
			if ((exp1.GetResultType() != typeof(bool) || exp1.GetResultType() != typeof(bool)) && t1 != t2)
			{
				throw new InvalidOperationException("Can't compare values of different primitive types");
			}
		}

		public override void Generate(ILGenerator gen)
		{
			Label label = gen.DefineLabel();
			Label label2 = gen.DefineLabel();
			if (exp1 is CodeConditionExpression)
			{
				((CodeConditionExpression)exp1).GenerateForBranch(gen, label, jumpCase: false);
			}
			else
			{
				exp1.Generate(gen);
				gen.Emit(OpCodes.Brfalse, label);
			}
			exp2.Generate(gen);
			gen.Emit(OpCodes.Br, label2);
			gen.MarkLabel(label);
			gen.Emit(OpCodes.Ldc_I4_0);
			gen.MarkLabel(label2);
		}

		public override void GenerateForBranch(ILGenerator gen, Label label, bool branchCase)
		{
			Label label2 = gen.DefineLabel();
			exp1.Generate(gen);
			if (exp1 is CodeConditionExpression)
			{
				if (branchCase)
				{
					((CodeConditionExpression)exp1).GenerateForBranch(gen, label2, jumpCase: false);
				}
				else
				{
					((CodeConditionExpression)exp1).GenerateForBranch(gen, label, jumpCase: false);
				}
			}
			else
			{
				exp1.Generate(gen);
				if (branchCase)
				{
					gen.Emit(OpCodes.Brfalse, label2);
				}
				else
				{
					gen.Emit(OpCodes.Brfalse, label);
				}
			}
			if (exp2 is CodeConditionExpression)
			{
				if (branchCase)
				{
					((CodeConditionExpression)exp2).GenerateForBranch(gen, label, jumpCase: true);
				}
				else
				{
					((CodeConditionExpression)exp2).GenerateForBranch(gen, label, jumpCase: false);
				}
			}
			else
			{
				exp2.Generate(gen);
				if (branchCase)
				{
					gen.Emit(OpCodes.Brtrue, label);
				}
				else
				{
					gen.Emit(OpCodes.Brfalse, label);
				}
			}
			gen.MarkLabel(label2);
		}

		public override void PrintCode(CodeWriter cp)
		{
			exp1.PrintCode(cp);
			cp.Write(" && ");
			exp2.PrintCode(cp);
		}

		public override Type GetResultType()
		{
			return typeof(bool);
		}
	}
	internal class CodeArgument : CodeExpression
	{
		private int argument;

		public int Argument => argument;

		public CodeArgument(int arg, Type type)
		{
			argument = arg;
		}

		public override void Generate(ILGenerator gen)
		{
			gen.Emit(OpCodes.Ldloc, var.LocalBuilder);
		}

		public override void PrintCode(CodeWriter cp)
		{
			cp.Write("arg" + argument);
		}

		public override Type GetResultType()
		{
			return var.Type;
		}
	}
	internal class CodeArgumentReference : CodeValueReference
	{
		private Type type;

		private int argNum;

		private string name;

		public CodeArgumentReference(Type type, int argNum, string name)
		{
			this.type = type;
			this.argNum = argNum;
			this.name = name;
		}

		public override void Generate(ILGenerator gen)
		{
			switch (argNum)
			{
			case 0:
				gen.Emit(OpCodes.Ldarg_0);
				break;
			case 1:
				gen.Emit(OpCodes.Ldarg_1);
				break;
			case 2:
				gen.Emit(OpCodes.Ldarg_2);
				break;
			case 3:
				gen.Emit(OpCodes.Ldarg_3);
				break;
			default:
				gen.Emit(OpCodes.Ldarg, argNum);
				break;
			}
			if (type.IsByRef)
			{
				CodeGenerationHelper.LoadFromPtr(gen, type.GetElementType());
			}
		}

		public override void GenerateSet(ILGenerator gen, CodeExpression value)
		{
			if (type.IsByRef)
			{
				gen.Emit(OpCodes.Ldarg, argNum);
				value.Generate(gen);
				CodeGenerationHelper.GenerateSafeConversion(gen, type.GetElementType(), value.GetResultType());
				CodeGenerationHelper.SaveToPtr(gen, type.GetElementType());
			}
			else
			{
				value.Generate(gen);
				CodeGenerationHelper.GenerateSafeConversion(gen, type, value.GetResultType());
				gen.Emit(OpCodes.Starg, argNum);
			}
		}

		public override void PrintCode(CodeWriter cp)
		{
			cp.Write(name);
		}

		public override Type GetResultType()
		{
			if (!type.IsByRef)
			{
				return type;
			}
			return type.GetElementType();
		}
	}
	internal abstract class CodeArithmeticOperation : CodeExpression
	{
		protected CodeExpression exp1;

		protected CodeExpression exp2;

		protected Type t1;

		protected Type t2;

		protected string symbol;

		protected CodeArithmeticOperation()
		{
		}

		public CodeArithmeticOperation(CodeExpression exp1, CodeExpression exp2, string symbol)
		{
			this.symbol = symbol;
			this.exp1 = exp1;
			this.exp2 = exp2;
			t1 = exp1.GetResultType();
			t2 = exp2.GetResultType();
			if (!t1.IsPrimitive || !t2.IsPrimitive || t1 != t2)
			{
				throw new InvalidOperationException("Operator " + GetType().Name + " cannot be applied to operands of type '" + t1.Name + " and " + t2.Name);
			}
		}

		public override void PrintCode(CodeWriter cp)
		{
			exp1.PrintCode(cp);
			cp.Write(" " + symbol + " ");
			exp2.PrintCode(cp);
		}

		public override Type GetResultType()
		{
			return exp1.GetResultType();
		}
	}
	internal class CodeAdd : CodeArithmeticOperation
	{
		public CodeAdd(CodeExpression exp1, CodeExpression exp2)
		{
			symbol = "+";
			base.exp1 = exp1;
			base.exp2 = exp2;
			t1 = exp1.GetResultType();
			t2 = exp2.GetResultType();
			if ((!t1.IsPrimitive || !t2.IsPrimitive || t1 != t2) && (t1 != typeof(string) || t2 != typeof(string)))
			{
				throw new InvalidOperationException("Operator " + GetType().Name + " cannot be applied to operands of type '" + t1.Name + " and " + t2.Name);
			}
		}

		public override void Generate(ILGenerator gen)
		{
			if (exp1.GetResultType() == typeof(string))
			{
				MethodInfo method = typeof(string).GetMethod("Concat", new Type[2]
				{
					typeof(string),
					typeof(string)
				});
				CodeGenerationHelper.GenerateMethodCall(gen, null, method, exp1, exp2);
			}
			else
			{
				exp1.Generate(gen);
				exp2.Generate(gen);
				gen.Emit(OpCodes.Add);
			}
		}
	}
	internal class CodeMul : CodeArithmeticOperation
	{
		public CodeMul(CodeExpression exp1, CodeExpression exp2)
			: base(exp1, exp2, "*")
		{
		}

		public override void Generate(ILGenerator gen)
		{
			exp1.Generate(gen);
			exp2.Generate(gen);
			gen.Emit(OpCodes.Mul);
		}
	}
	internal class CodeDiv : CodeArithmeticOperation
	{
		public CodeDiv(CodeExpression exp1, CodeExpression exp2)
			: base(exp1, exp2, "*")
		{
		}

		public override void Generate(ILGenerator gen)
		{
			exp1.Generate(gen);
			exp2.Generate(gen);
			gen.Emit(OpCodes.Div);
		}
	}
	internal class CodeSub : CodeArithmeticOperation
	{
		public CodeSub(CodeExpression exp1, CodeExpression exp2)
			: base(exp1, exp2, "-")
		{
		}

		public override void Generate(ILGenerator gen)
		{
			exp1.Generate(gen);
			exp2.Generate(gen);
			gen.Emit(OpCodes.Sub);
		}
	}
	internal class CodeArrayItem : CodeValueReference
	{
		private CodeExpression array;

		private CodeExpression index;

		public CodeArrayItem(CodeExpression array, CodeExpression index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			if (index == null)
			{
				throw new ArgumentNullException("index");
			}
			this.array = array;
			this.index = index;
		}

		public override void Generate(ILGenerator gen)
		{
			array.Generate(gen);
			index.Generate(gen);
			Type type = array.GetResultType().GetElementType();
			if (type.IsEnum && type != typeof(System.Enum))
			{
				type = type.UnderlyingSystemType;
			}
			switch (Type.GetTypeCode(type))
			{
			case TypeCode.Byte:
				gen.Emit(OpCodes.Ldelem_U1);
				return;
			case TypeCode.Double:
				gen.Emit(OpCodes.Ldelem_R8);
				return;
			case TypeCode.Int16:
				gen.Emit(OpCodes.Ldelem_I2);
				return;
			case TypeCode.UInt32:
				gen.Emit(OpCodes.Ldelem_U4);
				return;
			case TypeCode.Int32:
				gen.Emit(OpCodes.Ldelem_I4);
				return;
			case TypeCode.Int64:
			case TypeCode.UInt64:
				gen.Emit(OpCodes.Ldelem_I8);
				return;
			case TypeCode.SByte:
				gen.Emit(OpCodes.Ldelem_I1);
				return;
			case TypeCode.Single:
				gen.Emit(OpCodes.Ldelem_R4);
				return;
			case TypeCode.UInt16:
				gen.Emit(OpCodes.Ldelem_U2);
				return;
			}
			if (type.IsValueType)
			{
				gen.Emit(OpCodes.Ldelema, type);
				CodeGenerationHelper.LoadFromPtr(gen, type);
			}
			else
			{
				gen.Emit(OpCodes.Ldelem_Ref);
			}
		}

		public override void GenerateSet(ILGenerator gen, CodeExpression value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			Type type = array.GetResultType().GetElementType();
			if (type.IsEnum && type != typeof(System.Enum))
			{
				type = type.UnderlyingSystemType;
			}
			array.Generate(gen);
			index.Generate(gen);
			switch (Type.GetTypeCode(type))
			{
			case TypeCode.SByte:
			case TypeCode.Byte:
				value.Generate(gen);
				gen.Emit(OpCodes.Stelem_I1);
				return;
			case TypeCode.Double:
				value.Generate(gen);
				gen.Emit(OpCodes.Stelem_R8);
				return;
			case TypeCode.Int16:
			case TypeCode.UInt16:
				value.Generate(gen);
				gen.Emit(OpCodes.Stelem_I2);
				return;
			case TypeCode.Int32:
			case TypeCode.UInt32:
				value.Generate(gen);
				gen.Emit(OpCodes.Stelem_I4);
				return;
			case TypeCode.Int64:
			case TypeCode.UInt64:
				value.Generate(gen);
				gen.Emit(OpCodes.Stelem_I8);
				return;
			case TypeCode.Single:
				value.Generate(gen);
				gen.Emit(OpCodes.Stelem_R4);
				return;
			}
			if (type.IsValueType)
			{
				gen.Emit(OpCodes.Ldelema, type);
				value.Generate(gen);
				gen.Emit(OpCodes.Stobj, type);
			}
			else
			{
				value.Generate(gen);
				gen.Emit(OpCodes.Stelem_Ref);
			}
		}

		public override void PrintCode(CodeWriter cp)
		{
			array.PrintCode(cp);
			cp.Write("[");
			index.PrintCode(cp);
			cp.Write("]");
		}

		public override Type GetResultType()
		{
			return array.GetResultType().GetElementType();
		}
	}
	internal class CodeArrayLength : CodeExpression
	{
		private CodeExpression array;

		public CodeArrayLength(CodeExpression array)
		{
			if (!array.GetResultType().IsArray)
			{
				throw new InvalidOperationException("CodeArrayLength can only be applied to array expressions");
			}
			this.array = array;
		}

		public override void Generate(ILGenerator gen)
		{
			array.Generate(gen);
			gen.Emit(OpCodes.Ldlen);
		}

		public override void PrintCode(CodeWriter cp)
		{
			array.PrintCode(cp);
			cp.Write(".Length");
		}

		public override Type GetResultType()
		{
			return typeof(int);
		}
	}
	internal class CodeAssignment : CodeExpression
	{
		private new CodeValueReference var;

		private CodeExpression exp;

		public CodeAssignment(CodeValueReference var, CodeExpression exp)
		{
			if (var == null)
			{
				throw new ArgumentNullException("var");
			}
			if (exp == null)
			{
				throw new ArgumentNullException("exp");
			}
			this.exp = exp;
			this.var = var;
		}

		public override void Generate(ILGenerator gen)
		{
			var.GenerateSet(gen, exp);
			exp.Generate(gen);
		}

		public override void GenerateAsStatement(ILGenerator gen)
		{
			_ = exp;
			if (var.GetResultType() == typeof(object) && exp.GetResultType().IsValueType)
			{
				var.GenerateSet(gen, new CodeCast(typeof(object), exp));
			}
			else
			{
				var.GenerateSet(gen, exp);
			}
		}

		public override void PrintCode(CodeWriter cp)
		{
			var.PrintCode(cp);
			cp.Write(" = ");
			exp.PrintCode(cp);
		}

		public override Type GetResultType()
		{
			return var.GetResultType();
		}
	}
	internal abstract class CodeBinaryComparison : CodeConditionExpression
	{
		protected CodeExpression exp1;

		protected CodeExpression exp2;

		protected Type t1;

		protected Type t2;

		private string symbol;

		public CodeBinaryComparison(CodeExpression exp1, CodeExpression exp2, string symbol)
		{
			this.symbol = symbol;
			this.exp1 = exp1;
			this.exp2 = exp2;
			t1 = exp1.GetResultType();
			t2 = exp2.GetResultType();
			if (!t1.IsPrimitive || !t2.IsPrimitive || t1 != t2)
			{
				throw new InvalidOperationException("Operator " + GetType().Name + " cannot be applied to operands of type '" + t1.Name + " and " + t2.Name);
			}
		}

		public override void PrintCode(CodeWriter cp)
		{
			exp1.PrintCode(cp);
			cp.Write(" " + symbol + " ");
			exp2.PrintCode(cp);
		}

		public override Type GetResultType()
		{
			return typeof(bool);
		}
	}
	internal class CodeGreaterThan : CodeBinaryComparison
	{
		public CodeGreaterThan(CodeExpression exp1, CodeExpression exp2)
			: base(exp1, exp2, ">")
		{
		}

		public override void Generate(ILGenerator gen)
		{
			exp1.Generate(gen);
			exp2.Generate(gen);
			gen.Emit(OpCodes.Cgt);
		}

		public override void GenerateForBranch(ILGenerator gen, Label label, bool branchCase)
		{
			exp1.Generate(gen);
			exp2.Generate(gen);
			if (branchCase)
			{
				gen.Emit(OpCodes.Bgt, label);
			}
			else
			{
				gen.Emit(OpCodes.Ble, label);
			}
		}
	}
	internal class CodeGreaterEqualThan : CodeBinaryComparison
	{
		public CodeGreaterEqualThan(CodeExpression exp1, CodeExpression exp2)
			: base(exp1, exp2, ">=")
		{
		}

		public override void Generate(ILGenerator gen)
		{
			exp1.Generate(gen);
			exp2.Generate(gen);
			gen.Emit(OpCodes.Clt);
			gen.Emit(OpCodes.Ldc_I4_0);
			gen.Emit(OpCodes.Ceq);
		}

		public override void GenerateForBranch(ILGenerator gen, Label label, bool branchCase)
		{
			exp1.Generate(gen);
			exp2.Generate(gen);
			if (branchCase)
			{
				gen.Emit(OpCodes.Bge, label);
			}
			else
			{
				gen.Emit(OpCodes.Blt, label);
			}
		}
	}
	internal class CodeLessThan : CodeBinaryComparison
	{
		public CodeLessThan(CodeExpression exp1, CodeExpression exp2)
			: base(exp1, exp2, "<")
		{
		}

		public override void Generate(ILGenerator gen)
		{
			exp1.Generate(gen);
			exp2.Generate(gen);
			gen.Emit(OpCodes.Clt);
		}

		public override void GenerateForBranch(ILGenerator gen, Label label, bool branchCase)
		{
			exp1.Generate(gen);
			exp2.Generate(gen);
			if (branchCase)
			{
				gen.Emit(OpCodes.Blt, label);
			}
			else
			{
				gen.Emit(OpCodes.Bge, label);
			}
		}
	}
	internal class CodeLessEqualThan : CodeBinaryComparison
	{
		public CodeLessEqualThan(CodeExpression exp1, CodeExpression exp2)
			: base(exp1, exp2, "<=")
		{
		}

		public override void Generate(ILGenerator gen)
		{
			exp1.Generate(gen);
			exp2.Generate(gen);
			gen.Emit(OpCodes.Cgt);
			gen.Emit(OpCodes.Ldc_I4_0);
			gen.Emit(OpCodes.Ceq);
		}

		public override void GenerateForBranch(ILGenerator gen, Label label, bool branchCase)
		{
			exp1.Generate(gen);
			exp2.Generate(gen);
			if (branchCase)
			{
				gen.Emit(OpCodes.Ble, label);
			}
			else
			{
				gen.Emit(OpCodes.Bgt, label);
			}
		}
	}
	internal abstract class CodeBinaryOperation : CodeConditionExpression
	{
		protected CodeExpression exp1;

		protected CodeExpression exp2;

		protected Type t1;

		protected Type t2;

		private string symbol;

		public CodeBinaryOperation(CodeExpression exp1, CodeExpression exp2, string symbol)
		{
			this.symbol = symbol;
			this.exp1 = exp1;
			this.exp2 = exp2;
			t1 = exp1.GetResultType();
			t2 = exp2.GetResultType();
			if (!t1.IsPrimitive || !t2.IsPrimitive || t1 != t2)
			{
				throw new InvalidOperationException("Operator " + GetType().Name + " cannot be applied to operands of type '" + t1.Name + " and " + t2.Name);
			}
		}

		public override void PrintCode(CodeWriter cp)
		{
			exp1.PrintCode(cp);
			cp.Write(" " + symbol + " ");
			exp2.PrintCode(cp);
		}
	}
	internal class CodeBlock : CodeItem
	{
		private ArrayList statements = new ArrayList();

		public bool IsEmpty => statements.Count == 0;

		public void Add(CodeItem code)
		{
			statements.Add(code);
		}

		public static CodeBlock operator +(CodeBlock cb, CodeExpression e)
		{
			cb.Add(e);
			return cb;
		}

		public CodeItem GetLastItem()
		{
			return (CodeItem)statements[statements.Count - 1];
		}

		public override void Generate(ILGenerator gen)
		{
			foreach (CodeItem statement in statements)
			{
				if (statement is CodeExpression)
				{
					((CodeExpression)statement).GenerateAsStatement(gen);
				}
				else
				{
					statement.Generate(gen);
				}
			}
		}

		public override void PrintCode(CodeWriter cp)
		{
			foreach (CodeItem statement in statements)
			{
				cp.BeginLine();
				statement.PrintCode(cp);
				cp.Write(";");
				cp.EndLine();
			}
		}
	}
	internal class CodePop : CodeStatement
	{
		public override void Generate(ILGenerator gen)
		{
			gen.Emit(OpCodes.Pop);
		}

		public override void PrintCode(CodeWriter cp)
		{
		}
	}
	internal class CodeBuilder
	{
		private CodeBlock mainBlock;

		private CodeBlock currentBlock;

		private Stack blockStack = new Stack();

		private int varId;

		private Label returnLabel;

		private ArrayList nestedIfs = new ArrayList();

		private int currentIfSerie = -1;

		private CodeClass codeClass;

		public CodeBlock CurrentBlock => currentBlock;

		public CodeClass OwnerClass => codeClass;

		internal Label ReturnLabel
		{
			get
			{
				return returnLabel;
			}
			set
			{
				returnLabel = value;
			}
		}

		public CodeBuilder(CodeClass codeClass)
		{
			this.codeClass = codeClass;
			mainBlock = new CodeBlock();
			currentBlock = mainBlock;
		}

		private CodeBuilder(CodeBlock block)
		{
			currentBlock = block;
		}

		public void Generate(ILGenerator gen)
		{
			mainBlock.Generate(gen);
		}

		public string PrintCode()
		{
			StringWriter stringWriter = new StringWriter();
			CodeWriter cp = new CodeWriter(stringWriter);
			PrintCode(cp);
			return stringWriter.ToString();
		}

		public void PrintCode(CodeWriter cp)
		{
			mainBlock.PrintCode(cp);
		}

		public CodeVariableReference DeclareVariable(Type type)
		{
			return DeclareVariable(type, null);
		}

		public CodeVariableReference DeclareVariable(Type type, object ob)
		{
			return DeclareVariable(type, Exp.Literal(ob));
		}

		public CodeVariableReference DeclareVariable(CodeExpression initValue)
		{
			return DeclareVariable(initValue.GetResultType(), initValue);
		}

		public CodeVariableReference DeclareVariable(Type type, CodeExpression initValue)
		{
			string name = "v" + varId++;
			CodeVariableDeclaration codeVariableDeclaration = new CodeVariableDeclaration(type, name);
			currentBlock.Add(codeVariableDeclaration);
			if (initValue != null)
			{
				Assign(codeVariableDeclaration.Variable, initValue);
			}
			return codeVariableDeclaration.Variable;
		}

		public void Assign(CodeValueReference var, CodeExpression val)
		{
			currentBlock.Add(new CodeAssignment(var, val));
		}

		public void If(CodeExpression condition)
		{
			currentBlock.Add(new CodeIf(condition));
			PushNewBlock();
			nestedIfs.Add(0);
		}

		public void ElseIf(CodeExpression condition)
		{
			if (nestedIfs.Count == 0)
			{
				throw new InvalidOperationException("'Else' not allowed here");
			}
			Else();
			currentBlock.Add(new CodeIf(condition));
			PushNewBlock();
			nestedIfs[nestedIfs.Count - 1] = 1 + (int)nestedIfs[nestedIfs.Count - 1];
		}

		public void Else()
		{
			CodeBlock trueBlock = PopBlock();
			if (!(currentBlock.GetLastItem() is CodeIf { TrueBlock: null } codeIf))
			{
				throw new InvalidOperationException("'Else' not allowed here");
			}
			codeIf.TrueBlock = trueBlock;
			PushNewBlock();
		}

		public void EndIf()
		{
			CodeBlock codeBlock = PopBlock();
			if (!(currentBlock.GetLastItem() is CodeIf { FalseBlock: null } codeIf) || nestedIfs.Count == 0)
			{
				throw new InvalidOperationException("'EndIf' not allowed here");
			}
			if (codeIf.TrueBlock == null)
			{
				codeIf.TrueBlock = codeBlock;
			}
			else
			{
				codeIf.FalseBlock = codeBlock;
			}
			int num = (int)nestedIfs[nestedIfs.Count - 1];
			if (num > 0)
			{
				nestedIfs[nestedIfs.Count - 1] = --num;
				EndIf();
			}
			else
			{
				nestedIfs.RemoveAt(nestedIfs.Count - 1);
			}
		}

		public void Select()
		{
			currentBlock.Add(new CodeSelect());
			PushNewBlock();
		}

		public void Case(CodeExpression condition)
		{
			PopBlock();
			CodeSelect obj = (currentBlock.GetLastItem() as CodeSelect) ?? throw new InvalidOperationException("'Case' not allowed here");
			PushNewBlock();
			obj.AddCase(condition, currentBlock);
		}

		public void EndSelect()
		{
			PopBlock();
			if (!(currentBlock.GetLastItem() is CodeSelect))
			{
				throw new InvalidOperationException("'EndSelect' not allowed here");
			}
		}

		public void While(CodeExpression condition)
		{
			currentBlock.Add(new CodeWhile(condition));
			PushNewBlock();
		}

		public void EndWhile()
		{
			CodeBlock whileBlock = PopBlock();
			if (!(currentBlock.GetLastItem() is CodeWhile { WhileBlock: null } codeWhile))
			{
				throw new InvalidOperationException("'EndWhile' not allowed here");
			}
			codeWhile.WhileBlock = whileBlock;
		}

		public void Foreach(Type type, out CodeExpression item, CodeExpression array)
		{
			CodeForeach codeForeach = new CodeForeach(array, type);
			item = codeForeach.ItemExpression;
			currentBlock.Add(codeForeach);
			PushNewBlock();
		}

		public void EndForeach()
		{
			CodeBlock forBlock = PopBlock();
			if (!(currentBlock.GetLastItem() is CodeForeach { ForBlock: null } codeForeach))
			{
				throw new InvalidOperationException("'EndForeach' not allowed here");
			}
			codeForeach.ForBlock = forBlock;
		}

		public void For(CodeExpression initExp, CodeExpression conditionExp, CodeExpression nextExp)
		{
			currentBlock.Add(new CodeFor(initExp, conditionExp, nextExp));
			PushNewBlock();
		}

		public void EndFor()
		{
			CodeBlock forBlock = PopBlock();
			if (!(currentBlock.GetLastItem() is CodeFor { ForBlock: null } codeFor))
			{
				throw new InvalidOperationException("'EndFor' not allowed here");
			}
			codeFor.ForBlock = forBlock;
		}

		public void Call(CodeExpression target, string name, params CodeExpression[] parameters)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			currentBlock.Add(new CodeMethodCall(target, name, parameters));
		}

		public void Call(CodeExpression target, MethodBase method, params CodeExpression[] parameters)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			currentBlock.Add(new CodeMethodCall(target, method, parameters));
		}

		public void Call(CodeExpression target, CodeMethod method, params CodeExpression[] parameters)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			currentBlock.Add(new CodeMethodCall(target, method, parameters));
		}

		public void Call(Type type, string name, params CodeExpression[] parameters)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			currentBlock.Add(new CodeMethodCall(type, name, parameters));
		}

		public void Call(MethodInfo method, params CodeExpression[] parameters)
		{
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			currentBlock.Add(new CodeMethodCall(method, parameters));
		}

		public void Call(CodeMethod method, params CodeExpression[] parameters)
		{
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			currentBlock.Add(new CodeMethodCall(method, parameters));
		}

		public CodeExpression CallFunc(CodeExpression target, string name, params CodeExpression[] parameters)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			return new CodeMethodCall(target, name, parameters);
		}

		public CodeExpression CallFunc(CodeExpression target, MethodInfo method, params CodeExpression[] parameters)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			return new CodeMethodCall(target, method, parameters);
		}

		public CodeExpression CallFunc(CodeExpression target, CodeMethod method, params CodeExpression[] parameters)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			return new CodeMethodCall(target, method, parameters);
		}

		public CodeExpression CallFunc(Type type, string name, params CodeExpression[] parameters)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			return new CodeMethodCall(type, name, parameters);
		}

		public CodeExpression CallFunc(MethodInfo method, params CodeExpression[] parameters)
		{
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			return new CodeMethodCall(method, parameters);
		}

		public CodeExpression CallFunc(CodeMethod method, params CodeExpression[] parameters)
		{
			if (method == null)
			{
				throw new ArgumentNullException("method");
			}
			return new CodeMethodCall(method, parameters);
		}

		public void Inc(CodeValueReference val)
		{
			Assign(val, new CodeIncrement(val));
		}

		public void Dec(CodeValueReference val)
		{
			Assign(val, new CodeDecrement(val));
		}

		public CodeExpression When(CodeExpression condition, CodeExpression trueResult, CodeExpression falseResult)
		{
			return new CodeWhen(condition, trueResult, falseResult);
		}

		public void ConsoleWriteLine(params CodeExpression[] parameters)
		{
			Call(typeof(Console), "WriteLine", parameters);
		}

		public void ConsoleWriteLine(params object[] parameters)
		{
			CodeExpression[] array = new CodeExpression[parameters.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = Exp.Literal(parameters[i]);
			}
			ConsoleWriteLine(array);
		}

		public void Return(CodeExpression exp)
		{
			currentBlock.Add(new CodeReturn(this, exp));
		}

		public void Return()
		{
			currentBlock.Add(new CodeReturn(this));
		}

		public static CodeBuilder operator +(CodeBuilder cb, CodeItem e)
		{
			cb.currentBlock.Add(e);
			return cb;
		}

		private void PushNewBlock()
		{
			blockStack.Push(currentBlock);
			currentBlock = new CodeBlock();
		}

		private CodeBlock PopBlock()
		{
			CodeBlock result = currentBlock;
			currentBlock = (CodeBlock)blockStack.Pop();
			return result;
		}
	}
	internal class CodeCast : CodeExpression
	{
		private Type type;

		private CodeExpression exp;

		public CodeCast(Type type, CodeExpression exp)
		{
			this.type = type;
			this.exp = exp;
		}

		public override void Generate(ILGenerator gen)
		{
			exp.Generate(gen);
			Type resultType = exp.GetResultType();
			if (type.IsAssignableFrom(resultType))
			{
				if (resultType.IsValueType)
				{
					gen.Emit(OpCodes.Box, resultType);
				}
				return;
			}
			if (type.IsValueType && resultType == typeof(object))
			{
				gen.Emit(OpCodes.Unbox, type);
				CodeGenerationHelper.LoadFromPtr(gen, type);
				return;
			}
			if (resultType.IsAssignableFrom(type))
			{
				gen.Emit(OpCodes.Castclass, type);
				return;
			}
			if (CodeGenerationHelper.IsNumber(type) && CodeGenerationHelper.IsNumber(resultType))
			{
				switch (Type.GetTypeCode(type))
				{
				case TypeCode.Byte:
					gen.Emit(OpCodes.Conv_U1);
					return;
				case TypeCode.Double:
					gen.Emit(OpCodes.Conv_R8);
					return;
				case TypeCode.Int16:
					gen.Emit(OpCodes.Conv_I2);
					return;
				case TypeCode.Int32:
					gen.Emit(OpCodes.Conv_I4);
					return;
				case TypeCode.Int64:
					gen.Emit(OpCodes.Conv_I8);
					return;
				case TypeCode.SByte:
					gen.Emit(OpCodes.Conv_I1);
					return;
				case TypeCode.Single:
					gen.Emit(OpCodes.Conv_R4);
					return;
				case TypeCode.UInt16:
					gen.Emit(OpCodes.Conv_U2);
					return;
				case TypeCode.UInt32:
					gen.Emit(OpCodes.Conv_U4);
					return;
				case TypeCode.UInt64:
					gen.Emit(OpCodes.Conv_U8);
					return;
				}
			}
			MethodInfo method = type.GetMethod("op_Implicit", new Type[1] { resultType });
			if (method != null)
			{
				gen.Emit(OpCodes.Call, method);
				return;
			}
			MemberInfo[] member = resultType.GetMember("op_Explicit");
			for (int i = 0; i < member.Length; i++)
			{
				MethodInfo methodInfo = (MethodInfo)member[i];
				if (methodInfo.ReturnType == type)
				{
					gen.Emit(OpCodes.Call, methodInfo);
					return;
				}
			}
			throw new InvalidOperationException("Can't cast from " + resultType?.ToString() + " to " + type);
		}

		public override void PrintCode(CodeWriter cp)
		{
			Type resultType = exp.GetResultType();
			if (type.IsAssignableFrom(resultType))
			{
				exp.PrintCode(cp);
				return;
			}
			cp.Write("((" + type.FullName + ") ");
			exp.PrintCode(cp);
			cp.Write(")");
		}

		public override Type GetResultType()
		{
			return type;
		}
	}
	internal class CodeClass
	{
		private TypeBuilder typeBuilder;

		private ArrayList customAttributes = new ArrayList();

		private ArrayList methods = new ArrayList();

		private ArrayList properties = new ArrayList();

		private ArrayList fields = new ArrayList();

		private Hashtable fieldAttributes = new Hashtable();

		private Type baseType;

		private Type[] interfaces;

		private CodeMethod ctor;

		private CodeMethod cctor;

		private CodeBuilder instanceInit;

		private CodeBuilder classInit;

		private int varId;

		public TypeBuilder TypeBuilder => typeBuilder;

		public CodeClass(ModuleBuilder mb, string name)
			: this(mb, name, TypeAttributes.Public, typeof(object))
		{
		}

		public CodeClass(ModuleBuilder mb, string name, Type baseType, params Type[] interfaces)
			: this(mb, name, TypeAttributes.Public, baseType, interfaces)
		{
		}

		public CodeClass(ModuleBuilder mb, string name, TypeAttributes attr, Type baseType, params Type[] interfaces)
		{
			typeBuilder = mb.DefineType(name, attr, baseType, interfaces);
			this.baseType = baseType;
			this.interfaces = interfaces;
		}

		public CodeCustomAttribute CreateCustomAttribute(Type attributeType)
		{
			return CreateCustomAttribute(attributeType, Type.EmptyTypes, Array.Empty<object>(), Array.Empty<string>(), Array.Empty<object>());
		}

		public CodeCustomAttribute CreateCustomAttribute(Type attributeType, Type[] ctorArgTypes, object[] ctorArgs, string[] namedArgFieldNames, object[] namedArgValues)
		{
			CodeCustomAttribute codeCustomAttribute = CodeCustomAttribute.Create(attributeType, ctorArgTypes, ctorArgs, namedArgFieldNames, namedArgValues);
			typeBuilder.SetCustomAttribute(codeCustomAttribute.Builder);
			customAttributes.Add(codeCustomAttribute);
			return codeCustomAttribute;
		}

		public CodeCustomAttribute CreateCustomAttribute(Type attributeType, Type[] ctorArgTypes, CodeLiteral[] ctorArgs, FieldInfo[] fields, CodeLiteral[] fieldValues)
		{
			CodeCustomAttribute codeCustomAttribute = CodeCustomAttribute.Create(attributeType, ctorArgTypes, ctorArgs, fields, fieldValues);
			typeBuilder.SetCustomAttribute(codeCustomAttribute.Builder);
			customAttributes.Add(codeCustomAttribute);
			return codeCustomAttribute;
		}

		public CodeProperty CreateProperty(string name, Type returnType, params Type[] parameterTypes)
		{
			return CreateProperty(name, returnType, MethodAttributes.Private, parameterTypes);
		}

		public CodeProperty CreateProperty(string name, Type returnType, MethodAttributes methodAttributes, params Type[] parameterTypes)
		{
			CodeProperty codeProperty = new CodeProperty(this, GetPropertyName(name), PropertyAttributes.None, methodAttributes, returnType, parameterTypes);
			properties.Add(codeProperty);
			return codeProperty;
		}

		public CodeMethod CreateMethod(string name, Type returnType, params Type[] parameterTypes)
		{
			CodeMethod codeMethod = new CodeMethod(this, GetMethodName(name), MethodAttributes.Public, returnType, parameterTypes);
			methods.Add(codeMethod);
			return codeMethod;
		}

		public CodeMethod CreateVirtualMethod(string name, Type returnType, params Type[] parameterTypes)
		{
			CodeMethod codeMethod = new CodeMethod(this, GetMethodName(name), MethodAttributes.Public | MethodAttributes.Virtual, returnType, parameterTypes);
			methods.Add(codeMethod);
			return codeMethod;
		}

		public CodeMethod CreateStaticMethod(string name, Type returnType, params Type[] parameterTypes)
		{
			CodeMethod codeMethod = new CodeMethod(this, GetMethodName(name), MethodAttributes.Public | MethodAttributes.Static, returnType, parameterTypes);
			methods.Add(codeMethod);
			return codeMethod;
		}

		public CodeMethod CreateMethod(string name, MethodAttributes attributes, Type returnType, params Type[] parameterTypes)
		{
			CodeMethod codeMethod = new CodeMethod(this, GetMethodName(name), attributes, returnType, parameterTypes);
			methods.Add(codeMethod);
			return codeMethod;
		}

		public CodeMethod GetDefaultConstructor()
		{
			if (ctor != null)
			{
				return ctor;
			}
			ctor = CreateConstructor(MethodAttributes.Public, Type.EmptyTypes);
			return ctor;
		}

		public CodeMethod CreateConstructor(params Type[] parameters)
		{
			return CreateConstructor(MethodAttributes.Private, parameters);
		}

		public CodeMethod CreateConstructor(MethodAttributes attributes, params Type[] parameters)
		{
			if (ctor != null)
			{
				return ctor;
			}
			ctor = CodeMethod.DefineConstructor(this, attributes, parameters);
			methods.Add(ctor);
			CodeBuilder instanceInitBuilder = GetInstanceInitBuilder();
			ctor.CodeBuilder.CurrentBlock.Add(instanceInitBuilder.CurrentBlock);
			return ctor;
		}

		public CodeMethod GetStaticConstructor()
		{
			if (cctor != null)
			{
				return cctor;
			}
			cctor = CodeMethod.DefineConstructor(this, MethodAttributes.Public | MethodAttributes.Static, Type.EmptyTypes);
			methods.Add(cctor);
			CodeBuilder classInitBuilder = GetClassInitBuilder();
			cctor.CodeBuilder.CurrentBlock.Add(classInitBuilder.CurrentBlock);
			return cctor;
		}

		public CodeMethod ImplementMethod(Type baseType, string methodName)
		{
			MethodInfo method = baseType.GetMethod(methodName);
			return ImplementMethod(baseType, method);
		}

		public CodeMethod ImplementMethod(MethodInfo basem)
		{
			return ImplementMethod(basem.DeclaringType, basem);
		}

		public CodeMethod ImplementMethod(Type baseType, MethodInfo basem)
		{
			ParameterInfo[] parameters = basem.GetParameters();
			Type[] array = new Type[parameters.Length];
			for (int i = 0; i < parameters.Length; i++)
			{
				array[i] = parameters[i].ParameterType;
			}
			CodeMethod codeMethod = CodeMethod.DefineMethod(this, basem.Name, MethodAttributes.Public | MethodAttributes.Virtual, basem.ReturnType, array);
			typeBuilder.DefineMethodOverride(codeMethod.MethodInfo, basem);
			methods.Add(codeMethod);
			return codeMethod;
		}

		public CodeFieldReference DefineField(string name, Type type, params CodeCustomAttribute[] customAttributes)
		{
			return DefineField(GetFieldName(name), type, FieldAttributes.Public, null, customAttributes);
		}

		public CodeFieldReference DefineStaticField(CodeExpression initialValue, params CodeCustomAttribute[] customAttributes)
		{
			return DefineField(GetFieldName(null), initialValue.GetResultType(), FieldAttributes.Public | FieldAttributes.Static, initialValue, customAttributes);
		}

		public CodeFieldReference DefineStaticField(string name, Type type, CodeExpression initialValue, params CodeCustomAttribute[] customAttributes)
		{
			return DefineField(GetFieldName(name), type, FieldAttributes.Public | FieldAttributes.Static, initialValue, customAttributes);
		}

		public CodeFieldReference DefineField(string name, Type type, FieldAttributes attrs, CodeExpression initialValue, params CodeCustomAttribute[] customAttributes)
		{
			FieldBuilder fieldBuilder = typeBuilder.DefineField(GetFieldName(name), type, attrs);
			foreach (CodeCustomAttribute codeCustomAttribute in customAttributes)
			{
				fieldBuilder.SetCustomAttribute(codeCustomAttribute.Builder);
			}
			fieldAttributes[fieldBuilder] = new ArrayList(customAttributes);
			fields.Add(fieldBuilder);
			CodeFieldReference codeFieldReference = (((attrs & FieldAttributes.Static) == 0) ? new CodeFieldReference(new CodeArgumentReference(TypeBuilder, 0, "this"), fieldBuilder) : new CodeFieldReference(fieldBuilder));
			if (initialValue != null)
			{
				(((attrs & FieldAttributes.Static) == 0) ? GetInstanceInitBuilder() : GetClassInitBuilder()).Assign(codeFieldReference, initialValue);
			}
			return codeFieldReference;
		}

		private CodeBuilder GetInstanceInitBuilder()
		{
			if (instanceInit != null)
			{
				return instanceInit;
			}
			instanceInit = new CodeBuilder(this);
			return instanceInit;
		}

		private CodeBuilder GetClassInitBuilder()
		{
			if (classInit != null)
			{
				return classInit;
			}
			classInit = new CodeBuilder(this);
			return classInit;
		}

		private string GetFieldName(string name)
		{
			if (name == null)
			{
				return "__field_" + varId++;
			}
			return name;
		}

		private string GetMethodName(string name)
		{
			if (name == null)
			{
				return "__Method_" + varId++;
			}
			return name;
		}

		private string GetPropertyName(string name)
		{
			if (name == null)
			{
				return "__Property_" + varId++;
			}
			return name;
		}

		public string PrintCode()
		{
			StringWriter stringWriter = new StringWriter();
			CodeWriter cw = new CodeWriter(stringWriter);
			PrintCode(cw);
			return stringWriter.ToString();
		}

		public void PrintCode(CodeWriter cw)
		{
			for (int i = 0; i < customAttributes.Count; i++)
			{
				CodeCustomAttribute obj = customAttributes[i] as CodeCustomAttribute;
				if (i > 0)
				{
					cw.WriteLine("");
				}
				obj.PrintCode(cw);
			}
			if ((typeBuilder.Attributes & TypeAttributes.Public) != TypeAttributes.NotPublic)
			{
				cw.Write("public ");
			}
			cw.Write("class ").Write(typeBuilder.Name);
			bool flag = false;
			if (baseType != null && baseType != typeof(object))
			{
				cw.Write(" : " + baseType);
				flag = true;
			}
			if (interfaces != null && interfaces.Length != 0)
			{
				if (!flag)
				{
					cw.Write(" : ");
				}
				else
				{
					cw.Write(", ");
				}
				for (int j = 0; j < interfaces.Length; j++)
				{
					if (j > 0)
					{
						cw.Write(", ");
					}
					cw.Write(interfaces[j].ToString());
				}
			}
			cw.EndLine().WriteLineInd("{");
			foreach (FieldInfo field in fields)
			{
				cw.BeginLine();
				foreach (CodeCustomAttribute item in (ArrayList)fieldAttributes[field])
				{
					item.PrintCode(cw);
				}
				if ((field.Attributes & FieldAttributes.Static) != FieldAttributes.PrivateScope)
				{
					cw.Write("static ");
				}
				cw.Write(field.FieldType.Name + " ");
				cw.Write(field.Name + ";");
				cw.EndLine();
				cw.WriteLine("");
			}
			for (int k = 0; k < properties.Count; k++)
			{
				CodeProperty obj2 = properties[k] as CodeProperty;
				if (k > 0)
				{
					cw.WriteLine("");
				}
				obj2.PrintCode(cw);
			}
			for (int l = 0; l < methods.Count; l++)
			{
				CodeMethod obj3 = methods[l] as CodeMethod;
				if (l > 0)
				{
					cw.WriteLine("");
				}
				obj3.PrintCode(cw);
			}
			cw.WriteLineUnind("}");
		}

		public Type CreateType()
		{
			if (ctor == null)
			{
				ctor = GetDefaultConstructor();
			}
			foreach (CodeProperty property in properties)
			{
				property.Generate();
			}
			foreach (CodeMethod method in methods)
			{
				method.Generate();
			}
			Type type = typeBuilder.CreateType();
			foreach (CodeMethod method2 in methods)
			{
				method2.UpdateMethodBase(type);
			}
			foreach (CodeProperty property2 in properties)
			{
				property2.UpdatePropertyInfo(type);
			}
			return type;
		}
	}
	internal class CodeCustomAttribute
	{
		private CustomAttributeBuilder customAttributeBuilder;

		private Type type;

		private ConstructorInfo constructor;

		private CodeLiteral[] ctorArgs;

		private MemberInfo[] members;

		private CodeLiteral[] namedArgValues;

		public CustomAttributeBuilder Builder => customAttributeBuilder;

		public static CodeCustomAttribute Create(Type attributeType)
		{
			return Create(attributeType, Type.EmptyTypes, Array.Empty<object>(), Array.Empty<string>(), Array.Empty<object>());
		}

		public static CodeCustomAttribute Create(Type attributeType, Type[] ctorArgTypes, object[] ctorArgs, string[] namedArgNames, object[] namedArgValues)
		{
			MemberInfo[] array = new MemberInfo[namedArgNames.Length];
			for (int i = 0; i < namedArgNames.Length; i++)
			{
				array[i] = attributeType.GetField(namedArgNames[i]);
				if (array[i] == null)
				{
					array[i] = attributeType.GetProperty(namedArgNames[i]);
				}
				if (array[i] == null)
				{
					throw new ArgumentException($"Named argument {namedArgNames[i]} was not found in attribute type {attributeType}");
				}
			}
			CodeLiteral[] array2 = new CodeLiteral[ctorArgs.Length];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = new CodeLiteral(ctorArgs[j]);
			}
			CodeLiteral[] array3 = new CodeLiteral[namedArgValues.Length];
			for (int k = 0; k < array3.Length; k++)
			{
				array3[k] = new CodeLiteral(namedArgValues[k]);
			}
			return Create(attributeType, ctorArgTypes, array2, array, array3);
		}

		public static CodeCustomAttribute Create(Type attributeType, Type[] ctorArgTypes, CodeLiteral[] ctorArgs, MemberInfo[] members, CodeLiteral[] values)
		{
			ArrayList arrayList = new ArrayList();
			ArrayList arrayList2 = new ArrayList();
			ArrayList arrayList3 = new ArrayList();
			ArrayList arrayList4 = new ArrayList();
			for (int i = 0; i < members.Length; i++)
			{
				if (members[i] == null)
				{
					throw new ArgumentException($"MemberInfo at {i} was null for type {attributeType}.");
				}
				if (members[i] is PropertyInfo)
				{
					arrayList.Add((PropertyInfo)members[i]);
					arrayList2.Add(values[i].Value);
				}
				else
				{
					arrayList3.Add((FieldInfo)members[i]);
					arrayList4.Add(values[i].Value);
				}
			}
			ConstructorInfo con = attributeType.GetConstructor(ctorArgTypes);
			return new CodeCustomAttribute(new CustomAttributeBuilder(con, ctorArgs, (PropertyInfo[])arrayList.ToArray(typeof(PropertyInfo)), arrayList2.ToArray(), (FieldInfo[])arrayList3.ToArray(typeof(FieldInfo)), arrayList4.ToArray()), attributeType, con, ctorArgs, members, values);
		}

		public CodeCustomAttribute(CustomAttributeBuilder attributeBuilder, Type type, ConstructorInfo constructor, CodeLiteral[] ctorArgs, MemberInfo[] namedArgMembers, CodeLiteral[] namedArgValues)
		{
			this.type = type;
			this.constructor = constructor;
			customAttributeBuilder = attributeBuilder;
			this.ctorArgs = ctorArgs;
			members = namedArgMembers;
			this.namedArgValues = namedArgValues;
		}

		public string PrintCode()
		{
			StringWriter stringWriter = new StringWriter();
			CodeWriter cw = new CodeWriter(stringWriter);
			PrintCode(cw);
			return stringWriter.ToString();
		}

		public void PrintCode(CodeWriter cw)
		{
			cw.Write("[").Write(type.Name).Write("(");
			if (ctorArgs.Length != 0)
			{
				for (int i = 0; i < ctorArgs.Length - 1; i++)
				{
					ctorArgs[i].PrintCode(cw);
					cw.Write(", ");
				}
				ctorArgs[ctorArgs.Length - 1].PrintCode(cw);
			}
			if (members.Length != 0)
			{
				if (ctorArgs.Length != 0)
				{
					cw.Write(", ");
				}
				for (int j = 0; j < members.Length; j++)
				{
					cw.Write(members[j].Name).Write(" = ");
					namedArgValues[j].PrintCode(cw);
					if (j < members.Length - 1)
					{
						cw.Write(", ");
					}
				}
			}
			cw.Write(" )]");
			cw.EndLine();
		}
	}
	internal class CodeDecrement : CodeValueReference
	{
		private CodeValueReference exp;

		public CodeDecrement(CodeValueReference exp)
		{
			this.exp = exp;
		}

		public override void Generate(ILGenerator gen)
		{
			exp.GenerateSet(gen, new CodeSubstractOne(exp));
			exp.Generate(gen);
		}

		public override void GenerateSet(ILGenerator gen, CodeExpression value)
		{
			exp.GenerateSet(gen, value);
		}

		public override void PrintCode(CodeWriter cp)
		{
			exp.PrintCode(cp);
			cp.Write("--");
		}

		public override Type GetResultType()
		{
			return exp.GetResultType();
		}
	}
	internal class CodeSubstractOne : CodeExpression
	{
		private CodeExpression exp;

		private MethodInfo decMet;

		public CodeSubstractOne(CodeExpression exp)
		{
			this.exp = exp;
			if (!exp.IsNumber)
			{
				decMet = exp.GetResultType().GetMethod("op_Decrement");
				if (decMet == null)
				{
					throw new InvalidOperationException("Operator '--' cannot be applied to operand of type '" + exp.GetResultType().FullName + "'");
				}
			}
		}

		public override void Generate(ILGenerator gen)
		{
			if (decMet != null)
			{
				CodeGenerationHelper.GenerateMethodCall(gen, null, decMet, exp);
				return;
			}
			exp.Generate(gen);
			switch (Type.GetTypeCode(exp.GetResultType()))
			{
			case TypeCode.Byte:
				gen.Emit(OpCodes.Ldc_I4_1);
				gen.Emit(OpCodes.Sub);
				gen.Emit(OpCodes.Conv_U1);
				break;
			case TypeCode.Double:
				gen.Emit(OpCodes.Ldc_R8, 1);
				gen.Emit(OpCodes.Sub);
				break;
			case TypeCode.Int16:
				gen.Emit(OpCodes.Ldc_I4_1);
				gen.Emit(OpCodes.Sub);
				gen.Emit(OpCodes.Conv_I2);
				break;
			case TypeCode.Int32:
			case TypeCode.UInt32:
				gen.Emit(OpCodes.Ldc_I4_1);
				gen.Emit(OpCodes.Sub);
				break;
			case TypeCode.Int64:
			case TypeCode.UInt64:
				gen.Emit(OpCodes.Ldc_I4_1);
				gen.Emit(OpCodes.Conv_U8);
				gen.Emit(OpCodes.Sub);
				break;
			case TypeCode.SByte:
				gen.Emit(OpCodes.Ldc_I4_1);
				gen.Emit(OpCodes.Sub);
				gen.Emit(OpCodes.Conv_I1);
				break;
			case TypeCode.Single:
				gen.Emit(OpCodes.Ldc_R4, 1);
				gen.Emit(OpCodes.Sub);
				break;
			case TypeCode.UInt16:
				gen.Emit(OpCodes.Ldc_I4_1);
				gen.Emit(OpCodes.Sub);
				gen.Emit(OpCodes.Conv_U2);
				break;
			}
		}

		public override void PrintCode(CodeWriter cp)
		{
			exp.PrintCode(cp);
			cp.Write("--");
		}

		public override Type GetResultType()
		{
			return exp.GetResultType();
		}
	}
	internal class CodeEquals : CodeConditionExpression
	{
		private CodeExpression exp1;

		private CodeExpression exp2;

		private Type t1;

		private Type t2;

		public CodeEquals(CodeExpression exp1, CodeExpression exp2)
		{
			this.exp1 = exp1;
			this.exp2 = exp2;
			t1 = exp1.GetResultType();
			t2 = exp2.GetResultType();
			if (t1.IsValueType && t2.IsValueType && t1 != t2)
			{
				throw new InvalidOperationException("Can't compare values of different primitive types");
			}
		}

		public override void Generate(ILGenerator gen)
		{
			if (t1.IsPrimitive)
			{
				exp1.Generate(gen);
				exp2.Generate(gen);
				gen.Emit(OpCodes.Ceq);
			}
			else
			{
				exp1.Generate(gen);
				exp2.Generate(gen);
				gen.EmitCall(OpCodes.Callvirt, t1.GetMethod("Equals", new Type[1] { t2 }), null);
			}
		}

		public override void GenerateForBranch(ILGenerator gen, Label label, bool branchCase)
		{
			if (t1.IsPrimitive)
			{
				exp1.Generate(gen);
				exp2.Generate(gen);
				if (branchCase)
				{
					gen.Emit(OpCodes.Beq, label);
				}
				else
				{
					gen.Emit(OpCodes.Bne_Un, label);
				}
			}
			else
			{
				Generate(gen);
				if (branchCase)
				{
					gen.Emit(OpCodes.Brtrue, label);
				}
				else
				{
					gen.Emit(OpCodes.Brfalse, label);
				}
			}
		}

		public override void PrintCode(CodeWriter cp)
		{
			exp1.PrintCode(cp);
			cp.Write(" == ");
			exp2.PrintCode(cp);
		}

		public override Type GetResultType()
		{
			return typeof(bool);
		}
	}
	internal abstract class CodeExpression : CodeItem
	{
		internal CodeVariableReference var;

		public CodeValueReference this[CodeExpression index] => new CodeArrayItem(this, index);

		public CodeValueReference this[string name] => MemGet(name);

		public CodeValueReference this[FieldInfo field] => new CodeFieldReference(this, field);

		public CodeValueReference this[PropertyInfo prop] => new CodePropertyReference(this, prop);

		public CodeExpression ArrayLength => new CodeArrayLength(this);

		public CodeExpression IsNull => new CodeEquals(this, new CodeLiteral(null, GetResultType()));

		public bool IsNumber => CodeGenerationHelper.IsNumber(GetResultType());

		public abstract Type GetResultType();

		public virtual void GenerateAsStatement(ILGenerator gen)
		{
			Generate(gen);
			gen.Emit(OpCodes.Pop);
		}

		public CodeExpression CallToString()
		{
			return new CodeMethodCall(this, "ToString");
		}

		public static CodeExpression AreEqual(CodeExpression e1, CodeExpression e2)
		{
			return new CodeEquals(e1, e2);
		}

		public static CodeExpression AreNotEqual(CodeExpression e1, CodeExpression e2)
		{
			return new CodeNotEquals(e1, e2);
		}

		public static CodeExpression IsGreaterThan(CodeExpression e1, CodeExpression e2)
		{
			return new CodeGreaterThan(e1, e2);
		}

		public static CodeExpression IsSmallerThan(CodeExpression e1, CodeExpression e2)
		{
			return new CodeLessThan(e1, e2);
		}

		public static CodeExpression IsGreaterEqualThan(CodeExpression e1, CodeExpression e2)
		{
			return new CodeGreaterEqualThan(e1, e2);
		}

		public static CodeExpression IsSmallerEqualThan(CodeExpression e1, CodeExpression e2)
		{
			return new CodeLessEqualThan(e1, e2);
		}

		public static CodeExpression Not(CodeExpression e)
		{
			return new CodeNot(e);
		}

		public static CodeExpression Add(CodeExpression e1, CodeExpression e2)
		{
			return new CodeAdd(e1, e2);
		}

		public static CodeExpression Subtract(CodeExpression e1, CodeExpression e2)
		{
			return new CodeSub(e1, e2);
		}

		public static CodeExpression Multiply(CodeExpression e1, CodeExpression e2)
		{
			return new CodeMul(e1, e2);
		}

		public static CodeExpression Divide(CodeExpression e1, CodeExpression e2)
		{
			return new CodeDiv(e1, e2);
		}

		public CodeExpression CastTo(Type type)
		{
			return new CodeCast(type, this);
		}

		public CodeExpression And(CodeExpression other)
		{
			return new CodeAnd(this, other);
		}

		public CodeExpression Is(Type type)
		{
			return new CodeIs(type, this);
		}

		public CodeExpression Call(string name, params CodeExpression[] parameters)
		{
			return new CodeMethodCall(this, name, parameters);
		}

		public CodeExpression Call(MethodInfo method, params CodeExpression[] parameters)
		{
			return new CodeMethodCall(this, method, parameters);
		}

		public CodeValueReference MemGet(string name)
		{
			MemberInfo[] member = GetResultType().GetMember(name, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
			if (member.Length == 0)
			{
				throw new InvalidOperationException("Field '" + name + "' not found in " + GetResultType());
			}
			return MemGet(member[0]);
		}

		public CodeValueReference MemGet(MemberInfo member)
		{
			if (member is FieldInfo)
			{
				return new CodeFieldReference(this, (FieldInfo)member);
			}
			if (member is PropertyInfo)
			{
				return new CodePropertyReference(this, (PropertyInfo)member);
			}
			throw new InvalidOperationException(member.Name + " is not either a field or a property");
		}

		public static CodeExpression NullValue(Type type)
		{
			return new CodeLiteral(null, type);
		}
	}
	internal abstract class CodeConditionExpression : CodeExpression
	{
		public virtual void GenerateForBranch(ILGenerator gen, Label label, bool jumpCase)
		{
			Generate(gen);
			if (jumpCase)
			{
				gen.Emit(OpCodes.Brtrue, label);
			}
			else
			{
				gen.Emit(OpCodes.Brfalse, label);
			}
		}
	}
	internal class CodeFieldReference : CodeValueReference
	{
		private CodeExpression target;

		private FieldInfo field;

		public CodeFieldReference(CodeExpression target, FieldInfo field)
		{
			if (field.IsStatic)
			{
				throw new InvalidOperationException("Static member '" + field.Name + "' cannot be accessed with an instance reference.");
			}
			this.target = target;
			this.field = field;
		}

		public CodeFieldReference(FieldInfo field)
		{
			if (!field.IsStatic)
			{
				throw new InvalidOperationException("An object reference is required for the non-static field '" + field.Name + "'.");
			}
			this.field = field;
		}

		public override void Generate(ILGenerator gen)
		{
			if (field.IsStatic)
			{
				gen.Emit(OpCodes.Ldsfld, field);
				return;
			}
			target.Generate(gen);
			gen.Emit(OpCodes.Ldfld, field);
		}

		public override void GenerateSet(ILGenerator gen, CodeExpression value)
		{
			if (field.IsStatic)
			{
				value.Generate(gen);
				CodeGenerationHelper.GenerateSafeConversion(gen, field.FieldType, value.GetResultType());
				gen.Emit(OpCodes.Stsfld, field);
			}
			else
			{
				target.Generate(gen);
				value.Generate(gen);
				CodeGenerationHelper.GenerateSafeConversion(gen, field.FieldType, value.GetResultType());
				gen.Emit(OpCodes.Stfld, field);
			}
		}

		public override void PrintCode(CodeWriter cp)
		{
			if (!field.IsStatic)
			{
				target.PrintCode(cp);
			}
			else
			{
				cp.Write(field.DeclaringType.Name);
			}
			cp.Write(".");
			cp.Write(field.Name);
		}

		public override Type GetResultType()
		{
			return field.FieldType;
		}
	}
	internal class CodeFor : CodeStatement
	{
		private CodeExpression initExp;

		private CodeExpression conditionExp;

		private CodeExpression nextExp;

		private CodeBlock forBlock;

		public CodeBlock ForBlock
		{
			get
			{
				return forBlock;
			}
			set
			{
				forBlock = value;
			}
		}

		public CodeFor(CodeExpression initExp, CodeExpression conditionExp, CodeExpression nextExp)
		{
			this.initExp = initExp;
			this.conditionExp = conditionExp;
			this.nextExp = nextExp;
			if (conditionExp.GetResultType() != typeof(bool))
			{
				throw new InvalidOperationException("Condition expression is not boolean");
			}
		}

		public override void Generate(ILGenerator gen)
		{
			CodeBlock codeBlock = new CodeBlock();
			codeBlock.Add(initExp);
			CodeWhile codeWhile;
			codeBlock.Add(codeWhile = new CodeWhile(conditionExp));
			CodeBlock codeBlock2 = new CodeBlock();
			codeBlock2.Add(forBlock);
			codeBlock2.Add(nextExp);
			codeWhile.WhileBlock = codeBlock2;
			codeBlock.Generate(gen);
		}

		public override void PrintCode(CodeWriter cp)
		{
			cp.Write("for (");
			initExp.PrintCode(cp);
			cp.Write(";");
			conditionExp.PrintCode(cp);
			cp.Write(";");
			nextExp.PrintCode(cp);
			cp.Write(") {");
			cp.EndLine();
			cp.Indent();
			forBlock.PrintCode(cp);
			cp.Unindent();
			cp.BeginLine().Write("}");
		}
	}
	internal class CodeForeach : CodeStatement
	{
		private Type itemType;

		private CodeExpression array;

		private CodeBlock forBlock;

		private CodeVariableDeclaration itemDec;

		public CodeValueReference ItemExpression => itemDec.Variable;

		public CodeBlock ForBlock
		{
			get
			{
				return forBlock;
			}
			set
			{
				forBlock = value;
			}
		}

		public CodeForeach(CodeExpression array, Type itemType)
		{
			this.array = array;
			this.itemType = itemType;
			Type resultType = array.GetResultType();
			if (!resultType.IsArray && resultType.GetMethod("GetEnumerator", Type.EmptyTypes) == null)
			{
				throw new InvalidOperationException("foreach statement cannot operate on variables of type `" + resultType?.ToString() + "' because that class does not provide a GetEnumerator method or it is inaccessible");
			}
			itemDec = new CodeVariableDeclaration(itemType, "item");
		}

		public override void Generate(ILGenerator gen)
		{
			if (array.GetResultType().IsArray)
			{
				CodeBlock codeBlock = new CodeBlock();
				codeBlock.Add(itemDec);
				CodeValueReference variable = itemDec.Variable;
				CodeVariableDeclaration codeVariableDeclaration;
				codeBlock.Add(codeVariableDeclaration = new CodeVariableDeclaration(typeof(int), "n"));
				CodeValueReference variable2 = codeVariableDeclaration.Variable;
				codeBlock.Add(new CodeAssignment(variable2, new CodeLiteral(0)));
				CodeWhile codeWhile;
				codeBlock.Add(codeWhile = new CodeWhile(CodeExpression.IsSmallerThan(variable2, array.ArrayLength)));
				CodeBlock codeBlock2 = new CodeBlock();
				codeBlock2.Add(new CodeAssignment(variable, array[variable2]));
				codeBlock2.Add(new CodeIncrement(variable2));
				codeBlock2.Add(forBlock);
				codeWhile.WhileBlock = codeBlock2;
				codeBlock.Generate(gen);
			}
			else
			{
				CodeBlock codeBlock3 = new CodeBlock();
				codeBlock3.Add(itemDec);
				CodeValueReference variable3 = itemDec.Variable;
				CodeVariableDeclaration codeVariableDeclaration2;
				codeBlock3.Add(codeVariableDeclaration2 = new CodeVariableDeclaration(typeof(IEnumerator), "e"));
				CodeValueReference variable4 = codeVariableDeclaration2.Variable;
				codeBlock3.Add(new CodeAssignment(variable4, array.Call("GetEnumerator")));
				CodeWhile codeWhile2;
				codeBlock3.Add(codeWhile2 = new CodeWhile(variable4.Call("MoveNext")));
				CodeBlock codeBlock4 = new CodeBlock();
				codeBlock4.Add(new CodeAssignment(variable3, variable4["Current"]));
				codeBlock4.Add(forBlock);
				codeWhile2.WhileBlock = codeBlock4;
				codeBlock3.Generate(gen);
			}
		}

		public override void PrintCode(CodeWriter cp)
		{
			cp.Write("foreach (" + itemType?.ToString() + " item in ");
			array.PrintCode(cp);
			cp.Write(") {");
			cp.EndLine();
			cp.Indent();
			forBlock.PrintCode(cp);
			cp.Unindent();
			cp.BeginLine().Write("}");
		}
	}
	internal class CodeGenerationHelper
	{
		public static void GenerateMethodCall(ILGenerator gen, CodeExpression target, MethodBase method, params CodeExpression[] parameters)
		{
			Type[] array = Type.EmptyTypes;
			if (parameters.Length != 0)
			{
				ParameterInfo[] parameters2 = method.GetParameters();
				array = new Type[parameters2.Length];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = parameters2[i].ParameterType;
				}
			}
			GenerateMethodCall(gen, target, method, array, parameters);
		}

		public static void GenerateMethodCall(ILGenerator gen, CodeExpression target, CodeMethod method, params CodeExpression[] parameters)
		{
			GenerateMethodCall(gen, target, method.MethodBase, method.ParameterTypes, parameters);
		}

		private static void GenerateMethodCall(ILGenerator gen, CodeExpression target, MethodBase method, Type[] parameterTypes, params CodeExpression[] parameters)
		{
			if (parameterTypes.Length != parameters.Length)
			{
				throw GetMethodException(method, "Invalid number of parameters, expected " + parameterTypes.Length + ", found " + parameters.Length + ".");
			}
			OpCode opcode;
			if (target != null)
			{
				target.Generate(gen);
				Type resultType = target.GetResultType();
				if (resultType.IsValueType)
				{
					LocalBuilder local = gen.DeclareLocal(resultType);
					gen.Emit(OpCodes.Stloc, local);
					gen.Emit(OpCodes.Ldloca, local);
					opcode = OpCodes.Call;
				}
				else
				{
					opcode = OpCodes.Callvirt;
				}
			}
			else
			{
				opcode = OpCodes.Call;
			}
			for (int i = 0; i < parameterTypes.Length; i++)
			{
				try
				{
					CodeExpression codeExpression = parameters[i];
					codeExpression.Generate(gen);
					GenerateSafeConversion(gen, parameterTypes[i], codeExpression.GetResultType());
				}
				catch (InvalidOperationException ex)
				{
					throw GetMethodException(method, "Parameter " + i + ". " + ex.Message);
				}
			}
			if (method is MethodInfo)
			{
				gen.Emit(opcode, (MethodInfo)method);
			}
			else if (method is ConstructorInfo)
			{
				gen.Emit(opcode, (ConstructorInfo)method);
			}
		}

		public static System.Exception GetMethodException(MethodBase method, string msg)
		{
			return new InvalidOperationException("Call to method " + method.DeclaringType?.ToString() + "." + method.Name + ": " + msg);
		}

		public static void GenerateSafeConversion(ILGenerator gen, Type targetType, Type sourceType)
		{
			if (!targetType.IsAssignableFrom(sourceType))
			{
				throw new InvalidOperationException("Invalid type conversion. Found '" + sourceType?.ToString() + "', expected '" + targetType?.ToString() + "'.");
			}
			if (targetType == typeof(object) && sourceType.IsValueType)
			{
				gen.Emit(OpCodes.Box, sourceType);
			}
		}

		public static void LoadFromPtr(ILGenerator ig, Type t)
		{
			if (t == typeof(int))
			{
				ig.Emit(OpCodes.Ldind_I4);
			}
			else if (t == typeof(uint))
			{
				ig.Emit(OpCodes.Ldind_U4);
			}
			else if (t == typeof(short))
			{
				ig.Emit(OpCodes.Ldind_I2);
			}
			else if (t == typeof(ushort))
			{
				ig.Emit(OpCodes.Ldind_U2);
			}
			else if (t == typeof(char))
			{
				ig.Emit(OpCodes.Ldind_U2);
			}
			else if (t == typeof(byte))
			{
				ig.Emit(OpCodes.Ldind_U1);
			}
			else if (t == typeof(sbyte))
			{
				ig.Emit(OpCodes.Ldind_I1);
			}
			else if (t == typeof(ulong))
			{
				ig.Emit(OpCodes.Ldind_I8);
			}
			else if (t == typeof(long))
			{
				ig.Emit(OpCodes.Ldind_I8);
			}
			else if (t == typeof(float))
			{
				ig.Emit(OpCodes.Ldind_R4);
			}
			else if (t == typeof(double))
			{
				ig.Emit(OpCodes.Ldind_R8);
			}
			else if (t == typeof(bool))
			{
				ig.Emit(OpCodes.Ldind_I1);
			}
			else if (t == typeof(IntPtr))
			{
				ig.Emit(OpCodes.Ldind_I);
			}
			else if (t.IsEnum)
			{
				if (t == typeof(System.Enum))
				{
					ig.Emit(OpCodes.Ldind_Ref);
				}
				else
				{
					LoadFromPtr(ig, System.Enum.GetUnderlyingType(t));
				}
			}
			else if (t.IsValueType)
			{
				ig.Emit(OpCodes.Ldobj, t);
			}
			else
			{
				ig.Emit(OpCodes.Ldind_Ref);
			}
		}

		public static void SaveToPtr(ILGenerator ig, Type t)
		{
			if (t == typeof(int))
			{
				ig.Emit(OpCodes.Stind_I4);
			}
			else if (t == typeof(uint))
			{
				ig.Emit(OpCodes.Stind_I4);
			}
			else if (t == typeof(short))
			{
				ig.Emit(OpCodes.Stind_I2);
			}
			else if (t == typeof(ushort))
			{
				ig.Emit(OpCodes.Stind_I2);
			}
			else if (t == typeof(char))
			{
				ig.Emit(OpCodes.Stind_I2);
			}
			else if (t == typeof(byte))
			{
				ig.Emit(OpCodes.Stind_I1);
			}
			else if (t == typeof(sbyte))
			{
				ig.Emit(OpCodes.Stind_I1);
			}
			else if (t == typeof(ulong))
			{
				ig.Emit(OpCodes.Stind_I8);
			}
			else if (t == typeof(long))
			{
				ig.Emit(OpCodes.Stind_I8);
			}
			else if (t == typeof(float))
			{
				ig.Emit(OpCodes.Stind_R4);
			}
			else if (t == typeof(double))
			{
				ig.Emit(OpCodes.Stind_R8);
			}
			else if (t == typeof(bool))
			{
				ig.Emit(OpCodes.Stind_I1);
			}
			else if (t == typeof(IntPtr))
			{
				ig.Emit(OpCodes.Stind_I);
			}
			else if (t.IsEnum)
			{
				if (t == typeof(System.Enum))
				{
					ig.Emit(OpCodes.Stind_Ref);
				}
				else
				{
					SaveToPtr(ig, System.Enum.GetUnderlyingType(t));
				}
			}
			else if (t.IsValueType)
			{
				ig.Emit(OpCodes.Stobj, t);
			}
			else
			{
				ig.Emit(OpCodes.Stind_Ref);
			}
		}

		public static bool IsNumber(Type t)
		{
			TypeCode typeCode = Type.GetTypeCode(t);
			if ((uint)(typeCode - 5) <= 9u)
			{
				return true;
			}
			return false;
		}

		public static void GeneratePrimitiveValue()
		{
		}
	}
	internal class CodeIf : CodeStatement
	{
		private CodeExpression condition;

		private CodeBlock trueBlock;

		private CodeBlock falseBlock;

		public CodeBlock TrueBlock
		{
			get
			{
				return trueBlock;
			}
			set
			{
				trueBlock = value;
			}
		}

		public CodeBlock FalseBlock
		{
			get
			{
				return falseBlock;
			}
			set
			{
				falseBlock = value;
			}
		}

		public CodeIf(CodeExpression condition)
		{
			this.condition = condition;
			if (condition.GetResultType() != typeof(bool))
			{
				throw new InvalidOperationException("Condition expression is not boolean");
			}
		}

		public override void Generate(ILGenerator gen)
		{
			if (trueBlock == null)
			{
				throw new InvalidOperationException("Incomplete If statement");
			}
			Label label = gen.DefineLabel();
			Label label2 = gen.DefineLabel();
			if (falseBlock == null)
			{
				GenerateCondition(gen, label2);
				trueBlock.Generate(gen);
			}
			else
			{
				GenerateCondition(gen, label);
				trueBlock.Generate(gen);
				gen.Emit(OpCodes.Br, label2);
				gen.MarkLabel(label);
				falseBlock.Generate(gen);
			}
			gen.MarkLabel(label2);
		}

		private void GenerateCondition(ILGenerator gen, Label falseLabel)
		{
			if (condition is CodeConditionExpression)
			{
				((CodeConditionExpression)condition).GenerateForBranch(gen, falseLabel, jumpCase: false);
				return;
			}
			condition.Generate(gen);
			gen.Emit(OpCodes.Brfalse, falseLabel);
		}

		public override void PrintCode(CodeWriter cp)
		{
			if (trueBlock != null)
			{
				cp.Write("if (");
				condition.PrintCode(cp);
				cp.Write(") {");
				cp.EndLine();
				cp.Indent();
				trueBlock.PrintCode(cp);
				cp.Unindent();
				cp.BeginLine().Write("}");
				if (falseBlock != null)
				{
					cp.EndLine();
					cp.WriteLineInd("else {");
					falseBlock.PrintCode(cp);
					cp.Unindent();
					cp.BeginLine().Write("}");
				}
			}
		}
	}
	internal class CodeIncrement : CodeValueReference
	{
		private CodeValueReference exp;

		public CodeIncrement(CodeValueReference exp)
		{
			this.exp = exp;
		}

		public override void Generate(ILGenerator gen)
		{
			exp.GenerateSet(gen, new CodeAddOne(exp));
			exp.Generate(gen);
		}

		public override void GenerateAsStatement(ILGenerator gen)
		{
			exp.GenerateSet(gen, new CodeAddOne(exp));
		}

		public override void GenerateSet(ILGenerator gen, CodeExpression value)
		{
			exp.GenerateSet(gen, value);
		}

		public override void PrintCode(CodeWriter cp)
		{
			exp.PrintCode(cp);
			cp.Write("++");
		}

		public override Type GetResultType()
		{
			return exp.GetResultType();
		}
	}
	internal class CodeAddOne : CodeExpression
	{
		private CodeValueReference exp;

		private MethodInfo incMet;

		public CodeAddOne(CodeValueReference exp)
		{
			this.exp = exp;
			if (!exp.IsNumber)
			{
				incMet = exp.GetResultType().GetMethod("op_Increment");
				if (incMet == null)
				{
					throw new InvalidOperationException("Operator '++' cannot be applied to operand of type '" + exp.GetResultType().FullName + "'");
				}
			}
		}

		public override void Generate(ILGenerator gen)
		{
			if (incMet != null)
			{
				CodeGenerationHelper.GenerateMethodCall(gen, null, incMet, exp);
				return;
			}
			exp.Generate(gen);
			switch (Type.GetTypeCode(exp.GetResultType()))
			{
			case TypeCode.Byte:
				gen.Emit(OpCodes.Ldc_I4_1);
				gen.Emit(OpCodes.Add);
				gen.Emit(OpCodes.Conv_U1);
				break;
			case TypeCode.Double:
				gen.Emit(OpCodes.Ldc_R8, 1);
				gen.Emit(OpCodes.Add);
				break;
			case TypeCode.Int16:
				gen.Emit(OpCodes.Ldc_I4_1);
				gen.Emit(OpCodes.Add);
				gen.Emit(OpCodes.Conv_I2);
				break;
			case TypeCode.Int32:
			case TypeCode.UInt32:
				gen.Emit(OpCodes.Ldc_I4_1);
				gen.Emit(OpCodes.Add);
				break;
			case TypeCode.Int64:
			case TypeCode.UInt64:
				gen.Emit(OpCodes.Ldc_I4_1);
				gen.Emit(OpCodes.Add);
				gen.Emit(OpCodes.Conv_U8);
				break;
			case TypeCode.SByte:
				gen.Emit(OpCodes.Ldc_I4_1);
				gen.Emit(OpCodes.Add);
				gen.Emit(OpCodes.Conv_I1);
				break;
			case TypeCode.Single:
				gen.Emit(OpCodes.Ldc_R4, 1);
				gen.Emit(OpCodes.Add);
				break;
			case TypeCode.UInt16:
				gen.Emit(OpCodes.Ldc_I4_1);
				gen.Emit(OpCodes.Add);
				gen.Emit(OpCodes.Conv_U2);
				break;
			}
		}

		public override void PrintCode(CodeWriter cp)
		{
			exp.PrintCode(cp);
			cp.Write(" + 1");
		}

		public override Type GetResultType()
		{
			return exp.GetResultType();
		}
	}
	internal class CodeIs : CodeConditionExpression
	{
		private Type type;

		private CodeExpression exp;

		public CodeIs(Type type, CodeExpression exp)
		{
			this.type = type;
			this.exp = exp;
		}

		public override void Generate(ILGenerator gen)
		{
			Type resultType = exp.GetResultType();
			if (type.IsAssignableFrom(resultType))
			{
				gen.Emit(OpCodes.Ldc_I4_1);
				return;
			}
			if (!resultType.IsAssignableFrom(type))
			{
				gen.Emit(OpCodes.Ldc_I4_0);
				return;
			}
			exp.Generate(gen);
			gen.Emit(OpCodes.Isinst, type);
			gen.Emit(OpCodes.Ldnull);
			gen.Emit(OpCodes.Cgt_Un);
		}

		public override void GenerateForBranch(ILGenerator gen, Label label, bool branchCase)
		{
			Type resultType = exp.GetResultType();
			if (type.IsAssignableFrom(resultType))
			{
				if (branchCase)
				{
					gen.Emit(OpCodes.Br, label);
				}
				return;
			}
			if (!resultType.IsAssignableFrom(type))
			{
				if (!branchCase)
				{
					gen.Emit(OpCodes.Br, label);
				}
				return;
			}
			exp.Generate(gen);
			gen.Emit(OpCodes.Isinst, type);
			if (branchCase)
			{
				gen.Emit(OpCodes.Brtrue, label);
			}
			else
			{
				gen.Emit(OpCodes.Brfalse, label);
			}
		}

		public override void PrintCode(CodeWriter cp)
		{
			exp.PrintCode(cp);
			cp.Write(" is ");
			cp.Write(type.FullName);
		}

		public override Type GetResultType()
		{
			return typeof(bool);
		}
	}
	internal abstract class CodeItem
	{
		public abstract void Generate(ILGenerator gen);

		public abstract void PrintCode(CodeWriter cp);
	}
	internal abstract class CodeStatement : CodeItem
	{
	}
	internal class CodeLiteral : CodeExpression
	{
		private object value;

		private Type type;

		public object Value => value;

		public CodeLiteral(object value)
		{
			this.value = value;
			if (value != null)
			{
				type = value.GetType();
			}
			else
			{
				type = typeof(object);
			}
		}

		public CodeLiteral(object value, Type type)
		{
			this.value = value;
			this.type = type;
		}

		public override void Generate(ILGenerator gen)
		{
			object obj = value;
			if (obj == null)
			{
				gen.Emit(OpCodes.Ldnull);
				return;
			}
			if (obj is System.Enum)
			{
				obj = Convert.ChangeType(obj, obj.GetType().UnderlyingSystemType, CultureInfo.InvariantCulture);
			}
			if (obj is Type)
			{
				gen.Emit(OpCodes.Ldtoken, (Type)obj);
				gen.Emit(OpCodes.Call, typeof(Type).GetMethod("GetTypeFromHandle"));
				return;
			}
			switch (Type.GetTypeCode(type))
			{
			case TypeCode.String:
				gen.Emit(OpCodes.Ldstr, (string)obj);
				break;
			case TypeCode.SByte:
			case TypeCode.Byte:
			case TypeCode.Int16:
			case TypeCode.UInt16:
			case TypeCode.Int32:
			case TypeCode.UInt32:
			{
				int num = (int)obj;
				switch (num)
				{
				case 0:
					gen.Emit(OpCodes.Ldc_I4_0);
					break;
				case 1:
					gen.Emit(OpCodes.Ldc_I4_1);
					break;
				case 2:
					gen.Emit(OpCodes.Ldc_I4_2);
					break;
				case 3:
					gen.Emit(OpCodes.Ldc_I4_3);
					break;
				case 4:
					gen.Emit(OpCodes.Ldc_I4_4);
					break;
				case 5:
					gen.Emit(OpCodes.Ldc_I4_5);
					break;
				case 6:
					gen.Emit(OpCodes.Ldc_I4_6);
					break;
				case 7:
					gen.Emit(OpCodes.Ldc_I4_7);
					break;
				case 8:
					gen.Emit(OpCodes.Ldc_I4_8);
					break;
				case -1:
					gen.Emit(OpCodes.Ldc_I4_M1);
					break;
				default:
					gen.Emit(OpCodes.Ldc_I4, num);
					break;
				}
				break;
			}
			case TypeCode.Int64:
			case TypeCode.UInt64:
				gen.Emit(OpCodes.Ldc_I8, (long)obj);
				break;
			case TypeCode.Single:
				gen.Emit(OpCodes.Ldc_R4, (float)obj);
				break;
			case TypeCode.Double:
				gen.Emit(OpCodes.Ldc_R8, (double)obj);
				break;
			case TypeCode.Boolean:
				if ((bool)obj)
				{
					gen.Emit(OpCodes.Ldc_I4_1);
				}
				else
				{
					gen.Emit(OpCodes.Ldc_I4_0);
				}
				break;
			default:
				throw new InvalidOperationException("Literal type " + obj.GetType()?.ToString() + " not supported");
			}
		}

		public override void PrintCode(CodeWriter cp)
		{
			if (value is string)
			{
				cp.Write("\"").Write(value.ToString()).Write("\"");
			}
			else if (value == null)
			{
				cp.Write("null");
			}
			else if (value is Type)
			{
				cp.Write("typeof(" + ((Type)value).Name + ")");
			}
			else if (value is System.Enum)
			{
				cp.Write(value.GetType().Name + "." + value);
			}
			else
			{
				cp.Write(value.ToString());
			}
		}

		public override Type GetResultType()
		{
			return type;
		}
	}
	internal class CodeMethod
	{
		private MethodBase methodBase;

		private CodeBuilder builder;

		private string name;

		private MethodAttributes attributes;

		private Type returnType;

		private TypeBuilder typeBuilder;

		private Type[] parameterTypes;

		private ArrayList customAttributes = new ArrayList();

		private CodeClass cls;

		public TypeBuilder DeclaringType => typeBuilder;

		public MethodInfo MethodInfo => methodBase as MethodInfo;

		public MethodBase MethodBase => methodBase;

		public string Name => name;

		public MethodAttributes Attributes => attributes;

		public Type ReturnType => returnType;

		public Type[] ParameterTypes => parameterTypes;

		public CodeBuilder CodeBuilder => builder;

		public bool IsStatic => (attributes & MethodAttributes.Static) != 0;

		internal static CodeMethod DefineMethod(CodeClass cls, string name, MethodAttributes attributes, Type returnType, Type[] parameterTypes)
		{
			return new CodeMethod(cls, name, attributes, returnType, parameterTypes);
		}

		public static CodeMethod DefineConstructor(CodeClass cls, MethodAttributes attributes, Type[] parameterTypes)
		{
			return new CodeMethod(cls, attributes, parameterTypes);
		}

		internal CodeMethod(CodeClass cls, string name, MethodAttributes attributes, Type returnType, Type[] parameterTypes)
		{
			this.cls = cls;
			typeBuilder = cls.TypeBuilder;
			this.name = name;
			this.attributes = attributes;
			this.returnType = returnType;
			this.parameterTypes = parameterTypes;
			methodBase = typeBuilder.DefineMethod(name, attributes, returnType, parameterTypes);
			builder = new CodeBuilder(cls);
		}

		private CodeMethod(CodeClass cls, MethodAttributes attributes, Type[] parameterTypes)
		{
			this.cls = cls;
			typeBuilder = cls.TypeBuilder;
			this.attributes = attributes;
			this.parameterTypes = parameterTypes;
			name = typeBuilder.Name;
			methodBase = typeBuilder.DefineConstructor(attributes, CallingConventions.Standard, parameterTypes);
			builder = new CodeBuilder(cls);
		}

		public CodeCustomAttribute CreateCustomAttribute(Type attributeType)
		{
			return CreateCustomAttribute(attributeType, Type.EmptyTypes, Array.Empty<object>());
		}

		public CodeCustomAttribute CreateCustomAttribute(Type attributeType, Type[] ctorArgTypes, object[] ctorArgs)
		{
			return CreateCustomAttribute(attributeType, ctorArgTypes, ctorArgs, Array.Empty<string>(), Array.Empty<object>());
		}

		public CodeCustomAttribute CreateCustomAttribute(Type attributeType, Type[] ctorArgTypes, object[] ctorArgs, string[] namedArgFieldNames, object[] namedArgValues)
		{
			CodeCustomAttribute codeCustomAttribute = CodeCustomAttribute.Create(attributeType, ctorArgTypes, ctorArgs, namedArgFieldNames, namedArgValues);
			SetCustomAttribute(codeCustomAttribute);
			return codeCustomAttribute;
		}

		public CodeCustomAttribute CreateCustomAttribute(Type attributeType, Type[] ctorArgTypes, CodeLiteral[] ctorArgs, FieldInfo[] fields, CodeLiteral[] fieldValues)
		{
			CodeCustomAttribute codeCustomAttribute = CodeCustomAttribute.Create(attributeType, ctorArgTypes, ctorArgs, fields, fieldValues);
			SetCustomAttribute(codeCustomAttribute);
			return codeCustomAttribute;
		}

		private void SetCustomAttribute(CodeCustomAttribute cca)
		{
			if (methodBase is MethodBuilder)
			{
				((MethodBuilder)methodBase).SetCustomAttribute(cca.Builder);
			}
			else if (methodBase is ConstructorBuilder)
			{
				((ConstructorBuilder)methodBase).SetCustomAttribute(cca.Builder);
			}
			customAttributes.Add(cca);
		}

		public string PrintCode()
		{
			StringWriter stringWriter = new StringWriter();
			CodeWriter cp = new CodeWriter(stringWriter);
			PrintCode(cp);
			return stringWriter.ToString();
		}

		public virtual void PrintCode(CodeWriter cp)
		{
			cp.BeginLine();
			foreach (CodeCustomAttribute customAttribute in customAttributes)
			{
				customAttribute.PrintCode(cp);
			}
			if ((methodBase.Attributes & MethodAttributes.Static) != MethodAttributes.PrivateScope)
			{
				cp.Write("static ");
			}
			if ((methodBase.Attributes & MethodAttributes.Public) != MethodAttributes.PrivateScope)
			{
				cp.Write("public ");
			}
			if (returnType != null)
			{
				cp.Write(returnType?.ToString() + " ");
			}
			cp.Write(name + " (");
			for (int i = 0; i < parameterTypes.Length; i++)
			{
				if (i > 0)
				{
					cp.Write(", ");
				}
				cp.Write(parameterTypes[i]?.ToString() + " arg" + i);
			}
			cp.Write(")");
			cp.EndLine();
			cp.WriteLineInd("{");
			builder.PrintCode(cp);
			cp.WriteLineUnind("}");
		}

		public CodeArgumentReference GetArg(int n)
		{
			if (n < 0 || n >= parameterTypes.Length)
			{
				throw new InvalidOperationException("Invalid argument number");
			}
			int argNum = (IsStatic ? n : (n + 1));
			return new CodeArgumentReference(parameterTypes[n], argNum, "arg" + n);
		}

		public CodeArgumentReference GetThis()
		{
			if (IsStatic)
			{
				throw new InvalidOperationException("'this' not available in static methods");
			}
			return new CodeArgumentReference(DeclaringType, 0, "this");
		}

		public void Generate()
		{
			ILGenerator gen = ((methodBase is MethodInfo) ? ((MethodBuilder)methodBase).GetILGenerator() : ((ConstructorBuilder)methodBase).GetILGenerator());
			Generate(gen);
		}

		internal void Generate(ILGenerator gen)
		{
			Label label = gen.DefineLabel();
			builder.ReturnLabel = label;
			builder.Generate(gen);
			gen.MarkLabel(label);
			gen.Emit(OpCodes.Ret);
		}

		public void UpdateMethodBase(Type type)
		{
			if (methodBase is MethodInfo)
			{
				methodBase = type.GetMethod(methodBase.Name, parameterTypes);
			}
			else
			{
				methodBase = type.GetConstructor(parameterTypes);
			}
		}
	}
	internal class CodeMethodCall : CodeExpression
	{
		private CodeExpression target;

		private CodeExpression[] parameters;

		private MethodBase method;

		private CodeMethod codeMethod;

		public CodeMethodCall(CodeExpression target, string name, params CodeExpression[] parameters)
		{
			this.target = target;
			this.parameters = parameters;
			Type[] parameterTypes = GetParameterTypes(parameters);
			method = target.GetResultType().GetMethod(name, parameterTypes);
			if (method == null)
			{
				throw new InvalidOperationException("Method " + GetSignature(target.GetResultType(), name, parameters) + " not found");
			}
		}

		public CodeMethodCall(CodeExpression target, MethodBase method, params CodeExpression[] parameters)
		{
			this.target = target;
			this.parameters = parameters;
			this.method = method;
		}

		public CodeMethodCall(CodeExpression target, CodeMethod method, params CodeExpression[] parameters)
		{
			this.target = target;
			this.parameters = parameters;
			codeMethod = method;
		}

		public CodeMethodCall(Type type, string name, params CodeExpression[] parameters)
		{
			this.parameters = parameters;
			method = type.GetMethod(name, BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic, null, GetParameterTypes(parameters), null);
			if (method == null)
			{
				throw new InvalidOperationException("Method " + GetSignature(type, name, parameters) + " not found");
			}
		}

		public CodeMethodCall(MethodInfo method, params CodeExpression[] parameters)
		{
			this.parameters = parameters;
			this.method = method;
		}

		public CodeMethodCall(CodeMethod method, params CodeExpression[] parameters)
		{
			this.parameters = parameters;
			codeMethod = method;
		}

		private Type[] GetParameterTypes(CodeExpression[] parameters)
		{
			Type[] array = new Type[parameters.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = parameters[i].GetResultType();
			}
			return array;
		}

		private string GetSignature(Type type, string name, params CodeExpression[] parameters)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append(type.FullName).Append(".").Append(name);
			Type[] parameterTypes = GetParameterTypes(parameters);
			stringBuilder.Append("(");
			for (int i = 0; i < parameterTypes.Length; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(", ");
				}
				stringBuilder.Append(parameterTypes[i].FullName);
			}
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}

		public override void Generate(ILGenerator gen)
		{
			if (codeMethod != null)
			{
				CodeGenerationHelper.GenerateMethodCall(gen, target, codeMethod, parameters);
			}
			else
			{
				CodeGenerationHelper.GenerateMethodCall(gen, target, method, parameters);
			}
		}

		public override void GenerateAsStatement(ILGenerator gen)
		{
			Generate(gen);
			if (GetResultType() != typeof(void))
			{
				gen.Emit(OpCodes.Pop);
			}
		}

		public override void PrintCode(CodeWriter cp)
		{
			MethodBase methodBase = ((method != null) ? method : codeMethod.MethodInfo);
			if (target != null)
			{
				target.PrintCode(cp);
			}
			else
			{
				cp.Write(methodBase.DeclaringType.FullName);
			}
			cp.Write(".");
			cp.Write(methodBase.Name).Write(" (");
			for (int i = 0; i < parameters.Length; i++)
			{
				if (i > 0)
				{
					cp.Write(", ");
				}
				parameters[i].PrintCode(cp);
			}
			cp.Write(")");
		}

		public override Type GetResultType()
		{
			if (codeMethod != null)
			{
				return codeMethod.ReturnType;
			}
			if (method is MethodInfo)
			{
				return ((MethodInfo)method).ReturnType;
			}
			return typeof(void);
		}
	}
	internal class CodeModule
	{
		private ModuleBuilder module;

		private static CodeModule sharedModule;

		public static CodeModule Shared
		{
			get
			{
				if (sharedModule == null)
				{
					sharedModule = new CodeModule("SharedModule");
				}
				return sharedModule;
			}
		}

		public ModuleBuilder ModuleBuilder => module;

		public CodeModule(string name)
		{
			System.Threading.Thread.GetDomain();
			AssemblyBuilder assemblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName
			{
				Name = name
			}, AssemblyBuilderAccess.Run);
			module = assemblyBuilder.DefineDynamicModule(name);
		}

		public CodeClass CreateClass(string name)
		{
			return CreateClass(name, TypeAttributes.Public, typeof(object));
		}

		public CodeClass CreateClass(string name, Type baseType, params Type[] interfaces)
		{
			return CreateClass(name, TypeAttributes.Public, baseType, interfaces);
		}

		public CodeClass CreateClass(string name, TypeAttributes attr, Type baseType, params Type[] interfaces)
		{
			return new CodeClass(module, name, attr, baseType, interfaces);
		}
	}
	internal class CodeNew : CodeExpression
	{
		private object value;

		private Type type;

		private ConstructorInfo ctor;

		private CodeExpression[] parameters;

		public CodeNew(Type type, params CodeExpression[] parameters)
		{
			this.type = type;
			Type[] array = new Type[parameters.Length];
			for (int i = 0; i < parameters.Length; i++)
			{
				array[i] = parameters[i].GetResultType();
			}
			ctor = type.GetConstructor(array);
			if (ctor == null)
			{
				throw new InvalidOperationException("Constructor not found");
			}
			this.parameters = parameters;
		}

		public override void Generate(ILGenerator gen)
		{
			CodeExpression[] array = parameters;
			for (int i = 0; i < array.Length; i++)
			{
				array[i].Generate(gen);
			}
			gen.Emit(OpCodes.Newobj, ctor);
		}

		public override void PrintCode(CodeWriter cp)
		{
			cp.Write("new " + type.Name + " (");
			for (int i = 0; i < parameters.Length; i++)
			{
				if (i > 0)
				{
					cp.Write(", ");
				}
				parameters[i].PrintCode(cp);
			}
			cp.Write(")");
		}

		public override Type GetResultType()
		{
			return type;
		}
	}
	internal class CodeNewArray : CodeExpression
	{
		private Type elemType;

		private CodeExpression size;

		public CodeNewArray(Type type, CodeExpression size)
		{
			elemType = type;
			this.size = size;
			if (size.GetResultType() != typeof(int))
			{
				throw new InvalidOperationException("Array size must be an Int32");
			}
		}

		public override void Generate(ILGenerator gen)
		{
			size.Generate(gen);
			gen.Emit(OpCodes.Newarr, elemType);
		}

		public override void PrintCode(CodeWriter cp)
		{
			cp.Write("new " + elemType.Name + " [");
			size.PrintCode(cp);
			cp.Write("]");
		}

		public override Type GetResultType()
		{
			return Type.GetType(elemType.FullName + "[]");
		}
	}
	internal class CodeNotEquals : CodeConditionExpression
	{
		private CodeExpression exp1;

		private CodeExpression exp2;

		private Type t1;

		private Type t2;

		public CodeNotEquals(CodeExpression exp1, CodeExpression exp2)
		{
			this.exp1 = exp1;
			this.exp2 = exp2;
			t1 = exp1.GetResultType();
			t2 = exp2.GetResultType();
			if (t1.IsValueType && t2.IsValueType && t1 != t2)
			{
				throw new InvalidOperationException("Can't compare values of different primitive types");
			}
		}

		public override void Generate(ILGenerator gen)
		{
			if (t1.IsPrimitive)
			{
				exp1.Generate(gen);
				exp2.Generate(gen);
				gen.Emit(OpCodes.Ceq);
				gen.Emit(OpCodes.Ldc_I4_0);
				gen.Emit(OpCodes.Ceq);
			}
			else
			{
				exp1.Generate(gen);
				exp2.Generate(gen);
				gen.Emit(OpCodes.Ceq);
				gen.Emit(OpCodes.Ldc_I4_0);
				gen.Emit(OpCodes.Ceq);
			}
		}

		public override void GenerateForBranch(ILGenerator gen, Label label, bool branchCase)
		{
			if (t1.IsPrimitive)
			{
				exp1.Generate(gen);
				exp2.Generate(gen);
				if (branchCase)
				{
					gen.Emit(OpCodes.Bne_Un, label);
				}
				else
				{
					gen.Emit(OpCodes.Beq, label);
				}
				return;
			}
			exp1.Generate(gen);
			exp2.Generate(gen);
			gen.Emit(OpCodes.Ceq);
			gen.Emit(OpCodes.Ldc_I4_0);
			if (branchCase)
			{
				gen.Emit(OpCodes.Beq, label);
			}
			else
			{
				gen.Emit(OpCodes.Bne_Un, label);
			}
		}

		public override void PrintCode(CodeWriter cp)
		{
			if (t1.IsPrimitive)
			{
				exp1.PrintCode(cp);
				cp.Write(" != ");
				exp2.PrintCode(cp);
			}
			else
			{
				cp.Write("!(");
				exp1.PrintCode(cp);
				cp.Write(".Equals (");
				exp2.PrintCode(cp);
				cp.Write("))");
			}
		}

		public override Type GetResultType()
		{
			return typeof(bool);
		}
	}
	internal class CodeOr : CodeConditionExpression
	{
		private CodeExpression exp1;

		private CodeExpression exp2;

		private Type t1;

		private Type t2;

		public CodeOr(CodeExpression exp1, CodeExpression exp2)
		{
			this.exp1 = exp1;
			this.exp2 = exp2;
			if ((exp1.GetResultType() != typeof(bool) || exp1.GetResultType() != typeof(bool)) && t1 != t2)
			{
				throw new InvalidOperationException("Can't compare values of different primitive types");
			}
		}

		public override void Generate(ILGenerator gen)
		{
			Label label = gen.DefineLabel();
			Label label2 = gen.DefineLabel();
			if (exp1 is CodeConditionExpression)
			{
				((CodeConditionExpression)exp1).GenerateForBranch(gen, label, jumpCase: true);
			}
			else
			{
				exp1.Generate(gen);
				gen.Emit(OpCodes.Brtrue, label);
			}
			exp2.Generate(gen);
			gen.Emit(OpCodes.Br, label2);
			gen.MarkLabel(label);
			gen.Emit(OpCodes.Ldc_I4_1);
			gen.MarkLabel(label2);
		}

		public override void GenerateForBranch(ILGenerator gen, Label label, bool branchCase)
		{
			Label label2 = gen.DefineLabel();
			exp1.Generate(gen);
			if (exp1 is CodeConditionExpression)
			{
				if (branchCase)
				{
					((CodeConditionExpression)exp1).GenerateForBranch(gen, label, jumpCase: true);
				}
				else
				{
					((CodeConditionExpression)exp1).GenerateForBranch(gen, label2, jumpCase: true);
				}
			}
			else
			{
				exp1.Generate(gen);
				if (branchCase)
				{
					gen.Emit(OpCodes.Brtrue, label);
				}
				else
				{
					gen.Emit(OpCodes.Brtrue, label2);
				}
			}
			if (exp2 is CodeConditionExpression)
			{
				if (branchCase)
				{
					((CodeConditionExpression)exp2).GenerateForBranch(gen, label, jumpCase: true);
				}
				else
				{
					((CodeConditionExpression)exp2).GenerateForBranch(gen, label, jumpCase: false);
				}
			}
			else
			{
				exp2.Generate(gen);
				if (branchCase)
				{
					gen.Emit(OpCodes.Brtrue, label);
				}
				else
				{
					gen.Emit(OpCodes.Brfalse, label);
				}
			}
			gen.MarkLabel(label2);
		}

		public override void PrintCode(CodeWriter cp)
		{
			cp.Write("(");
			exp1.PrintCode(cp);
			cp.Write(" || ");
			exp2.PrintCode(cp);
			cp.Write(")");
		}

		public override Type GetResultType()
		{
			return typeof(bool);
		}
	}
	internal class CodeProperty
	{
		private PropertyInfo propertyInfo;

		private CodeBuilder get_builder;

		private CodeBuilder set_builder;

		private string name;

		private PropertyAttributes attributes;

		private MethodAttributes methodAttributes;

		private Type returnType;

		private TypeBuilder typeBuilder;

		private Type[] parameterTypes;

		private ArrayList customAttributes = new ArrayList();

		private CodeClass cls;

		public TypeBuilder DeclaringType => typeBuilder;

		public PropertyBuilder PropertyBuilder => propertyInfo as PropertyBuilder;

		public string Name => name;

		public PropertyAttributes Attributes => attributes;

		public Type ReturnType => returnType;

		public Type[] ParameterTypes => parameterTypes;

		public CodeBuilder CodeBuilderGet => get_builder;

		public CodeBuilder CodeBuilderSet => set_builder;

		public bool IsStatic => (methodAttributes & MethodAttributes.Static) != 0;

		public bool IsPublic => (methodAttributes & MethodAttributes.Public) != 0;

		internal static CodeProperty DefineProperty(CodeClass cls, string name, PropertyAttributes attributes, MethodAttributes methodAttributes, Type returnType, Type[] parameterTypes)
		{
			return new CodeProperty(cls, name, attributes, methodAttributes, returnType, parameterTypes);
		}

		internal CodeProperty(CodeClass cls, string name, PropertyAttributes attributes, MethodAttributes methodAttributes, Type returnType, Type[] parameterTypes)
		{
			this.cls = cls;
			typeBuilder = cls.TypeBuilder;
			this.name = name;
			this.attributes = attributes;
			this.methodAttributes = methodAttributes;
			this.returnType = returnType;
			this.parameterTypes = parameterTypes;
			PropertyBuilder propertyBuilder = typeBuilder.DefineProperty(name, attributes, returnType, parameterTypes);
			propertyBuilder.SetGetMethod(typeBuilder.DefineMethod("get_" + name, methodAttributes, CallingConventions.Standard, returnType, Type.EmptyTypes));
			propertyBuilder.SetSetMethod(typeBuilder.DefineMethod("set_" + name, methodAttributes, CallingConventions.Standard, typeof(void), new Type[1] { returnType }));
			get_builder = new CodeBuilder(cls);
			set_builder = new CodeBuilder(cls);
			propertyInfo = propertyBuilder;
		}

		public CodeCustomAttribute CreateCustomAttribute(Type attributeType)
		{
			return CreateCustomAttribute(attributeType, Type.EmptyTypes, Array.Empty<object>());
		}

		public CodeCustomAttribute CreateCustomAttribute(Type attributeType, Type[] ctorArgTypes, object[] ctorArgs)
		{
			return CreateCustomAttribute(attributeType, ctorArgTypes, ctorArgs, Array.Empty<string>(), Array.Empty<object>());
		}

		public CodeCustomAttribute CreateCustomAttribute(Type attributeType, Type[] ctorArgTypes, object[] ctorArgs, string[] namedArgFieldNames, object[] namedArgValues)
		{
			CodeCustomAttribute codeCustomAttribute = CodeCustomAttribute.Create(attributeType, ctorArgTypes, ctorArgs, namedArgFieldNames, namedArgValues);
			SetCustomAttribute(codeCustomAttribute);
			return codeCustomAttribute;
		}

		public CodeCustomAttribute CreateCustomAttribute(Type attributeType, Type[] ctorArgTypes, CodeLiteral[] ctorArgs, FieldInfo[] fields, CodeLiteral[] fieldValues)
		{
			CodeCustomAttribute codeCustomAttribute = CodeCustomAttribute.Create(attributeType, ctorArgTypes, ctorArgs, fields, fieldValues);
			SetCustomAttribute(codeCustomAttribute);
			return codeCustomAttribute;
		}

		private void SetCustomAttribute(CodeCustomAttribute cca)
		{
			PropertyBuilder.SetCustomAttribute(cca.Builder);
			customAttributes.Add(cca);
		}

		public string PrintCode()
		{
			StringWriter stringWriter = new StringWriter();
			CodeWriter cp = new CodeWriter(stringWriter);
			PrintCode(cp);
			return stringWriter.ToString();
		}

		public void PrintCode(CodeWriter cp)
		{
			cp.BeginLine();
			foreach (CodeCustomAttribute customAttribute in customAttributes)
			{
				customAttribute.PrintCode(cp);
			}
			cp.BeginLine();
			if (IsStatic)
			{
				cp.Write("static ");
			}
			if (IsPublic)
			{
				cp.Write("public ");
			}
			if (returnType != null)
			{
				cp.Write(returnType?.ToString() + " ");
			}
			cp.Write(name);
			if (parameterTypes.Length != 0)
			{
				cp.Write(name + " [");
				for (int i = 0; i < parameterTypes.Length; i++)
				{
					if (i > 0)
					{
						cp.Write(", ");
					}
					cp.Write(parameterTypes[i]?.ToString() + " arg" + i);
				}
				cp.Write("]");
			}
			cp.Write(" {");
			cp.EndLine();
			cp.Indent();
			cp.WriteLineInd("get {");
			get_builder.PrintCode(cp);
			cp.WriteLineUnind("}");
			cp.WriteLine("set {");
			set_builder.PrintCode(cp);
			cp.WriteLine("}");
			cp.WriteLineUnind("}");
		}

		public CodeArgumentReference GetArg(int n)
		{
			if (n < 0 || n >= parameterTypes.Length)
			{
				throw new InvalidOperationException("Invalid argument number");
			}
			int argNum = (IsStatic ? n : (n + 1));
			return new CodeArgumentReference(parameterTypes[n], argNum, "arg" + n);
		}

		public CodeArgumentReference GetThis()
		{
			if (IsStatic)
			{
				throw new InvalidOperationException("'this' not available in static methods");
			}
			return new CodeArgumentReference(DeclaringType, 0, "this");
		}

		public void Generate()
		{
			MethodBuilder methodBuilder = (MethodBuilder)propertyInfo.GetGetMethod();
			if (methodBuilder != null)
			{
				ILGenerator iLGenerator = methodBuilder.GetILGenerator();
				Label label = iLGenerator.DefineLabel();
				get_builder.ReturnLabel = label;
				get_builder.Generate(iLGenerator);
				iLGenerator.MarkLabel(label);
				iLGenerator.Emit(OpCodes.Ret);
			}
			methodBuilder = (MethodBuilder)propertyInfo.GetSetMethod();
			if (methodBuilder != null)
			{
				ILGenerator iLGenerator = methodBuilder.GetILGenerator();
				Label label = iLGenerator.DefineLabel();
				set_builder.ReturnLabel = label;
				set_builder.Generate(iLGenerator);
				iLGenerator.MarkLabel(label);
				iLGenerator.Emit(OpCodes.Ret);
			}
		}

		public void UpdatePropertyInfo(Type type)
		{
			propertyInfo = type.GetProperty(propertyInfo.Name, parameterTypes);
		}
	}
	internal class CodePropertyReference : CodeValueReference
	{
		private CodeExpression target;

		private PropertyInfo property;

		public CodePropertyReference(CodeExpression target, PropertyInfo property)
		{
			this.target = target;
			this.property = property;
		}

		public override void Generate(ILGenerator gen)
		{
			CodeGenerationHelper.GenerateMethodCall(gen, target, property.GetGetMethod());
		}

		public override void GenerateSet(ILGenerator gen, CodeExpression value)
		{
			CodeGenerationHelper.GenerateMethodCall(gen, target, property.GetSetMethod(), value);
		}

		public override void PrintCode(CodeWriter cp)
		{
			target.PrintCode(cp);
			cp.Write(".");
			cp.Write(property.Name);
		}

		public override Type GetResultType()
		{
			return property.PropertyType;
		}
	}
	internal class CodeReturn : CodeStatement
	{
		private CodeExpression retValue;

		private CodeBuilder codeBuilder;

		internal CodeReturn(CodeBuilder codeBuilder, CodeExpression retValue)
		{
			this.codeBuilder = codeBuilder;
			this.retValue = retValue;
		}

		internal CodeReturn(CodeBuilder codeBuilder)
		{
			this.codeBuilder = codeBuilder;
		}

		public override void Generate(ILGenerator gen)
		{
			if (retValue != null)
			{
				retValue.Generate(gen);
			}
			gen.Emit(OpCodes.Br, codeBuilder.ReturnLabel);
		}

		public override void PrintCode(CodeWriter cp)
		{
			if (retValue == null)
			{
				cp.Write("return");
				return;
			}
			cp.Write("return ");
			retValue.PrintCode(cp);
		}
	}
	internal class CodeSelect : CodeStatement
	{
		private ArrayList conditions = new ArrayList();

		private ArrayList blocks = new ArrayList();

		public void AddCase(CodeExpression condition, CodeBlock block)
		{
			conditions.Add(condition);
			blocks.Add(block);
		}

		public override void Generate(ILGenerator gen)
		{
			if (blocks.Count != 0)
			{
				CodeIf codeIf = new CodeIf((CodeExpression)conditions[0]);
				codeIf.TrueBlock = (CodeBlock)blocks[0];
				CodeIf codeIf2 = codeIf;
				for (int i = 1; i < blocks.Count; i++)
				{
					CodeIf codeIf3 = new CodeIf((CodeExpression)conditions[i]);
					codeIf3.TrueBlock = (CodeBlock)blocks[i];
					CodeBlock codeBlock = new CodeBlock();
					codeBlock.Add(codeIf3);
					codeIf2.FalseBlock = codeBlock;
					codeIf2 = codeIf3;
				}
				codeIf.Generate(gen);
			}
		}

		public override void PrintCode(CodeWriter cp)
		{
			for (int i = 0; i < blocks.Count; i++)
			{
				if (i == 0)
				{
					cp.Write("if (");
				}
				else
				{
					cp.Write("else if (");
				}
				((CodeExpression)conditions[i]).PrintCode(cp);
				cp.Write(") {");
				cp.EndLine();
				cp.Indent();
				((CodeBlock)blocks[i]).PrintCode(cp);
				cp.Unindent();
				cp.BeginLine().Write("}");
				if (i < blocks.Count - 1)
				{
					cp.EndLine();
					cp.BeginLine();
				}
			}
		}
	}
	internal class CodeSelfIncrement : CodeExpression
	{
		private CodeValueReference exp;

		public CodeSelfIncrement(CodeValueReference exp)
		{
			this.exp = exp;
			if (!exp.IsNumber)
			{
				throw new InvalidOperationException("Operator '++' cannot be applied to operand of type '" + exp.GetResultType().FullName + "'");
			}
		}

		public override void Generate(ILGenerator gen)
		{
			exp.Generate(gen);
			switch (Type.GetTypeCode(exp.GetResultType()))
			{
			case TypeCode.Byte:
				gen.Emit(OpCodes.Ldc_I4_1);
				gen.Emit(OpCodes.Add);
				gen.Emit(OpCodes.Conv_U1);
				break;
			case TypeCode.Decimal:
			{
				MethodInfo method = typeof(decimal).GetMethod("op_Increment");
				CodeGenerationHelper.GenerateMethodCall(gen, null, method, exp);
				break;
			}
			case TypeCode.Double:
				gen.Emit(OpCodes.Ldc_R8, 1);
				gen.Emit(OpCodes.Add);
				break;
			case TypeCode.Int16:
				gen.Emit(OpCodes.Ldc_I4_1);
				gen.Emit(OpCodes.Add);
				gen.Emit(OpCodes.Conv_I2);
				break;
			case TypeCode.Int32:
			case TypeCode.UInt32:
				gen.Emit(OpCodes.Ldc_I4_1);
				gen.Emit(OpCodes.Add);
				break;
			case TypeCode.Int64:
			case TypeCode.UInt64:
				gen.Emit(OpCodes.Ldc_I4_1);
				gen.Emit(OpCodes.Add);
				gen.Emit(OpCodes.Conv_U8);
				break;
			case TypeCode.SByte:
				gen.Emit(OpCodes.Ldc_I4_1);
				gen.Emit(OpCodes.Add);
				gen.Emit(OpCodes.Conv_I1);
				break;
			case TypeCode.Single:
				gen.Emit(OpCodes.Ldc_R4, 1);
				gen.Emit(OpCodes.Add);
				break;
			case TypeCode.UInt16:
				gen.Emit(OpCodes.Ldc_I4_1);
				gen.Emit(OpCodes.Add);
				gen.Emit(OpCodes.Conv_U2);
				break;
			}
			exp.GenerateSet(gen, exp);
		}

		public override void PrintCode(CodeWriter cp)
		{
			exp.PrintCode(cp);
			cp.Write("++");
		}

		public override Type GetResultType()
		{
			return exp.GetResultType();
		}
	}
	internal class CodeTry : CodeStatement
	{
		private CodeExpression condition;

		private CodeBlock tryBlock;

		private CodeBlock finallyBlock;

		private ArrayList catchBlocks = new ArrayList();

		public CodeBlock TryBlock
		{
			get
			{
				return tryBlock;
			}
			set
			{
				tryBlock = value;
			}
		}

		public ArrayList CatchBlocks => catchBlocks;

		public CodeBlock FinallyBlock
		{
			get
			{
				return finallyBlock;
			}
			set
			{
				finallyBlock = value;
			}
		}

		public CodeTry()
		{
			tryBlock = new CodeBlock();
			catchBlocks = new ArrayList();
			finallyBlock = new CodeBlock();
		}

		public override void Generate(ILGenerator gen)
		{
			gen.BeginExceptionBlock();
			tryBlock.Generate(gen);
			foreach (DictionaryEntry catchBlock in catchBlocks)
			{
				CodeVariableDeclaration codeVariableDeclaration = (CodeVariableDeclaration)catchBlock.Key;
				gen.BeginCatchBlock(codeVariableDeclaration.Variable.Type);
				if (codeVariableDeclaration.Variable.Name.Length > 0)
				{
					codeVariableDeclaration.Generate(gen);
				}
				((CodeBlock)catchBlock.Value).Generate(gen);
			}
			if (!finallyBlock.IsEmpty)
			{
				gen.BeginFinallyBlock();
				finallyBlock.Generate(gen);
			}
			gen.EndExceptionBlock();
		}

		public override void PrintCode(CodeWriter cp)
		{
			if (tryBlock == null)
			{
				return;
			}
			cp.Write("try {");
			cp.Indent();
			condition.PrintCode(cp);
			cp.Unindent();
			foreach (DictionaryEntry catchBlock in catchBlocks)
			{
				CodeVariableDeclaration codeVariableDeclaration = (CodeVariableDeclaration)catchBlock.Key;
				cp.Write("} catch (");
				if (codeVariableDeclaration.Variable.Name.Length > 0)
				{
					codeVariableDeclaration.PrintCode(cp);
				}
				else
				{
					cp.Write(codeVariableDeclaration.Variable.Type.FullName);
				}
				cp.Write(") {");
				cp.Indent();
				((CodeBlock)catchBlock.Value).PrintCode(cp);
				cp.Unindent();
			}
			if (!finallyBlock.IsEmpty)
			{
				cp.Write("} finally {");
				cp.Indent();
				finallyBlock.PrintCode(cp);
				cp.Unindent();
			}
			cp.Write("}");
		}
	}
	internal class CodeNeg : CodeExpression
	{
		private CodeExpression exp;

		public CodeNeg(CodeExpression exp)
		{
			this.exp = exp;
			if (!exp.IsNumber)
			{
				throw new InvalidOperationException("Operator '-' cannot be applied to operand of type '" + exp.GetResultType().FullName + "'");
			}
		}

		public override void Generate(ILGenerator gen)
		{
			exp.Generate(gen);
			gen.Emit(OpCodes.Neg);
		}

		public override void PrintCode(CodeWriter cp)
		{
			cp.Write("-");
			exp.PrintCode(cp);
		}

		public override Type GetResultType()
		{
			return exp.GetResultType();
		}
	}
	internal class CodeNot : CodeConditionExpression
	{
		private CodeExpression exp;

		public CodeNot(CodeExpression exp)
		{
			this.exp = exp;
			if (exp.GetResultType() != typeof(bool))
			{
				throw new InvalidOperationException("Operator '!' cannot be applied to operand of type '" + exp.GetResultType().FullName + "'");
			}
		}

		public override void Generate(ILGenerator gen)
		{
			exp.Generate(gen);
			gen.Emit(OpCodes.Ldc_I4_0);
			gen.Emit(OpCodes.Ceq);
		}

		public override void GenerateForBranch(ILGenerator gen, Label label, bool branchCase)
		{
			if (exp is CodeConditionExpression)
			{
				((CodeConditionExpression)exp).GenerateForBranch(gen, label, !branchCase);
				return;
			}
			exp.Generate(gen);
			if (branchCase)
			{
				gen.Emit(OpCodes.Brfalse, label);
			}
			else
			{
				gen.Emit(OpCodes.Brtrue, label);
			}
		}

		public override void PrintCode(CodeWriter cp)
		{
			cp.Write("!");
			exp.PrintCode(cp);
		}

		public override Type GetResultType()
		{
			return typeof(bool);
		}
	}
	internal abstract class CodeValueReference : CodeExpression
	{
		public abstract void GenerateSet(ILGenerator gen, CodeExpression value);
	}
	internal class CodeVariableDeclaration : CodeStatement
	{
		private CodeVariableReference var;

		public CodeVariableReference Variable => var;

		public CodeVariableDeclaration(Type type, string name)
		{
			var = new CodeVariableReference(type, name);
		}

		public override void Generate(ILGenerator gen)
		{
			var.LocalBuilder = gen.DeclareLocal(var.Type);
		}

		public override void PrintCode(CodeWriter cp)
		{
			cp.Write(var.Type.FullName + " " + var.Name);
		}
	}
	internal class CodeVariableReference : CodeValueReference
	{
		private LocalBuilder localBuilder;

		private Type type;

		private string name;

		public Type Type => type;

		public string Name => name;

		internal LocalBuilder LocalBuilder
		{
			get
			{
				return localBuilder;
			}
			set
			{
				localBuilder = value;
			}
		}

		public CodeVariableReference(Type type, string name)
		{
			this.type = type;
			this.name = name;
		}

		public override void Generate(ILGenerator gen)
		{
			gen.Emit(OpCodes.Ldloc, localBuilder);
		}

		public override void GenerateSet(ILGenerator gen, CodeExpression value)
		{
			value.Generate(gen);
			CodeGenerationHelper.GenerateSafeConversion(gen, type, value.GetResultType());
			gen.Emit(OpCodes.Stloc, localBuilder);
		}

		public override void PrintCode(CodeWriter cp)
		{
			cp.Write(name);
		}

		public override Type GetResultType()
		{
			return type;
		}
	}
	internal class CodeWhen : CodeExpression
	{
		private CodeExpression condition;

		private CodeExpression trueBlock;

		private CodeExpression falseBlock;

		public CodeWhen(CodeExpression condition, CodeExpression trueResult, CodeExpression falseResult)
		{
			this.condition = condition;
			if (condition.GetResultType() != typeof(bool))
			{
				throw new InvalidOperationException("Condition expression is not boolean");
			}
			if (trueResult.GetResultType() != falseResult.GetResultType())
			{
				throw new InvalidOperationException("The types of the true and false expressions must be the same");
			}
			trueBlock = trueResult;
			falseBlock = falseResult;
		}

		public override void Generate(ILGenerator gen)
		{
			Label label = gen.DefineLabel();
			Label label2 = gen.DefineLabel();
			GenerateCondition(gen, label);
			trueBlock.Generate(gen);
			gen.Emit(OpCodes.Br, label2);
			gen.MarkLabel(label);
			falseBlock.Generate(gen);
			gen.MarkLabel(label2);
		}

		private void GenerateCondition(ILGenerator gen, Label falseLabel)
		{
			if (condition is CodeConditionExpression)
			{
				((CodeConditionExpression)condition).GenerateForBranch(gen, falseLabel, jumpCase: false);
				return;
			}
			condition.Generate(gen);
			gen.Emit(OpCodes.Brfalse, falseLabel);
		}

		public override void PrintCode(CodeWriter cp)
		{
			cp.Write("(");
			condition.PrintCode(cp);
			cp.Write(") ? ");
			trueBlock.PrintCode(cp);
			cp.Write(" : ");
			falseBlock.PrintCode(cp);
		}

		public override Type GetResultType()
		{
			return trueBlock.GetResultType();
		}
	}
	internal class CodeWhile : CodeStatement
	{
		private CodeExpression condition;

		private CodeBlock whileBlock;

		public CodeBlock WhileBlock
		{
			get
			{
				return whileBlock;
			}
			set
			{
				whileBlock = value;
			}
		}

		public CodeWhile(CodeExpression condition)
		{
			this.condition = condition;
			if (condition.GetResultType() != typeof(bool))
			{
				throw new InvalidOperationException("Condition expression is not boolean");
			}
		}

		public override void Generate(ILGenerator gen)
		{
			Label label = gen.DefineLabel();
			Label label2 = gen.DefineLabel();
			gen.Emit(OpCodes.Br, label2);
			gen.MarkLabel(label);
			whileBlock.Generate(gen);
			gen.MarkLabel(label2);
			if (condition is CodeConditionExpression)
			{
				((CodeConditionExpression)condition).GenerateForBranch(gen, label, jumpCase: true);
				return;
			}
			condition.Generate(gen);
			gen.Emit(OpCodes.Brtrue, label);
		}

		public override void PrintCode(CodeWriter cp)
		{
			cp.Write("while (");
			condition.PrintCode(cp);
			cp.Write(") {");
			cp.EndLine();
			cp.Indent();
			whileBlock.PrintCode(cp);
			cp.Unindent();
			cp.BeginLine().Write("}");
		}
	}
	internal class CodeWriter
	{
		private TextWriter writer;

		private int indent;

		public CodeWriter(TextWriter tw)
		{
			writer = tw;
		}

		public CodeWriter BeginLine()
		{
			writer.Write(new string(' ', indent * 4));
			return this;
		}

		public CodeWriter Write(string s)
		{
			writer.Write(s);
			return this;
		}

		public CodeWriter EndLine()
		{
			writer.WriteLine();
			return this;
		}

		public CodeWriter WriteLine(string s)
		{
			BeginLine();
			Write(s);
			EndLine();
			return this;
		}

		public CodeWriter WriteLineInd(string s)
		{
			WriteLine(s);
			indent++;
			return this;
		}

		public CodeWriter WriteLineUnind(string s)
		{
			indent--;
			WriteLine(s);
			return this;
		}

		public void Indent()
		{
			indent++;
		}

		public void Unindent()
		{
			indent--;
		}
	}
	internal class Exp
	{
		private Exp()
		{
		}

		public static CodeExpression Literal(object ob)
		{
			return new CodeLiteral(ob);
		}

		public static CodeExpression Literal(string ob)
		{
			return new CodeLiteral(ob, typeof(string));
		}

		public static CodeExpression New(Type type, params CodeExpression[] pars)
		{
			return new CodeNew(type, pars);
		}

		public static CodeExpression NewArray(Type type, CodeExpression size)
		{
			return new CodeNewArray(type, size);
		}

		public static CodeExpression And(CodeExpression e1, CodeExpression e2)
		{
			return new CodeAnd(e1, e2);
		}

		public static CodeExpression And(CodeExpression e1, CodeExpression e2, CodeExpression e3)
		{
			return new CodeAnd(new CodeAnd(e1, e2), e3);
		}

		public static CodeExpression Or(CodeExpression e1, CodeExpression e2)
		{
			return new CodeOr(e1, e2);
		}

		public static CodeValueReference Inc(CodeValueReference e)
		{
			return new CodeIncrement(e);
		}

		public static CodeExpression Call(CodeExpression target, string name, params CodeExpression[] parameters)
		{
			return new CodeMethodCall(target, name, parameters);
		}

		public static CodeExpression Call(CodeExpression target, MethodInfo method, params CodeExpression[] parameters)
		{
			return new CodeMethodCall(target, method, parameters);
		}

		public static CodeExpression Call(CodeExpression target, CodeMethod method, params CodeExpression[] parameters)
		{
			return new CodeMethodCall(target, method, parameters);
		}

		public static CodeExpression Call(Type type, string name, params CodeExpression[] parameters)
		{
			return new CodeMethodCall(type, name, parameters);
		}

		public static CodeExpression Call(MethodInfo method, params CodeExpression[] parameters)
		{
			return new CodeMethodCall(method, parameters);
		}

		public static CodeExpression Call(CodeMethod method, params CodeExpression[] parameters)
		{
			return new CodeMethodCall(method, parameters);
		}
	}
}
namespace Java.Interop
{
	internal abstract class CallbackCodeGenerator<TDelegateSpec>
	{
		public abstract TDelegateSpec GetDelegateType();

		public abstract void GenerateNativeCallbackDelegate();
	}
	internal class DynamicInvokeTypeInfo
	{
		private enum SymbolKind
		{
			Array,
			CharSequence,
			Class,
			Collection,
			Enum,
			SimpleFormat,
			GenericTypeParameter,
			Interface,
			Stream,
			String,
			XmlReader
		}

		private static readonly MethodInfo jnienv_newarray;

		private static readonly MethodInfo jnienv_getarray;

		private static readonly MethodInfo charsequence_tojnihandle;

		private static readonly MethodInfo jnienv_tojnihandle;

		private static readonly MethodInfo jnienv_newstring;

		private static readonly MethodInfo jnienv_getstring;

		private static readonly MethodInfo object_getobject;

		private static readonly BindingFlags sloppy_flags;

		private static readonly MethodInfo inputstreaminvoker_fromjnihandle;

		private static readonly MethodInfo inputstreamadapter_tojnihandle;

		private static readonly MethodInfo outputstreaminvoker_fromjnihandle;

		private static readonly MethodInfo outputstreamadapter_tojnihandle;

		private static readonly MethodInfo xmlpullparserreader_fromjnihandle;

		private static readonly MethodInfo xmlreaderpullparser_tojnihandle;

		private static readonly MethodInfo xmlresourceparserreader_fromjnihandle;

		private static readonly MethodInfo xmlreaderresourceparser_tojnihandle;

		private static readonly CodeLiteral do_not_transfer_literal;

		private Type type;

		private ExportParameterKind parameter_kind;

		public Type NativeType => GetNativeType(type);

		public bool NeedsPrep => NeedsPreparation(type, parameter_kind);

		static DynamicInvokeTypeInfo()
		{
			jnienv_newarray = GetTArrayToIntPtr<int>(JNIEnv.NewArray<int>);
			jnienv_getarray = GetIntPtrToTArray(JNIEnv.GetArray<int>);
			charsequence_tojnihandle = GetEnumerableCharToIntPtrMethodInfo(CharSequence.ToLocalJniHandle);
			jnienv_tojnihandle = GetObjectToIntPtrMethodInfo(JNIEnv.ToLocalJniHandle);
			jnienv_newstring = GetStringToIntPtrMethodInfo(JNIEnv.NewString);
			jnienv_getstring = GetHandleToStringMethodInfo(JNIEnv.GetString);
			object_getobject = typeof(Java.Lang.Object).GetMethod("GetObject", new Type[2]
			{
				typeof(IntPtr),
				typeof(JniHandleOwnership)
			});
			sloppy_flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic;
			inputstreaminvoker_fromjnihandle = GetHandleToStreamMethodInfo(InputStreamInvoker.FromJniHandle);
			inputstreamadapter_tojnihandle = GetStreamToIntPtrMethodInfo(InputStreamAdapter.ToLocalJniHandle);
			outputstreaminvoker_fromjnihandle = GetHandleToStreamMethodInfo(OutputStreamInvoker.FromJniHandle);
			outputstreamadapter_tojnihandle = GetStreamToIntPtrMethodInfo(OutputStreamAdapter.ToLocalJniHandle);
			xmlpullparserreader_fromjnihandle = GetHandleToXmlReaderMethodInfo(XmlPullParserReader.FromJniHandle);
			xmlreaderpullparser_tojnihandle = GetXmlResourceParserReaderToIntPtrMethodInfo(XmlReaderPullParser.ToLocalJniHandle);
			xmlresourceparserreader_fromjnihandle = GetHandleToXmlResourceParserReaderMethodInfo(XmlResourceParserReader.FromJniHandle);
			xmlreaderresourceparser_tojnihandle = GetXmlReaderToIntPtrMethodInfo(XmlReaderResourceParser.ToLocalJniHandle);
			do_not_transfer_literal = new CodeLiteral(JniHandleOwnership.DoNotTransfer);
			CheckReflection(jnienv_newarray, "JNIEnv.NewArray<T>");
			CheckReflection(jnienv_getarray, "JNIEnv.GetArray<T>");
			CheckReflection(charsequence_tojnihandle, "ICharSequence.ToLocalJniHandle");
			CheckReflection(jnienv_tojnihandle, "JNIEnv.ToLocalJniHandle");
			CheckReflection(jnienv_newstring, "JNIEnv.NewString");
			CheckReflection(jnienv_getstring, "JNIEnv.GetString");
			CheckReflection(object_getobject, "Java.Lang.Object.GetObject");
			CheckReflection(xmlpullparserreader_fromjnihandle, "XmlPullParserReader.FromJniHandle");
			CheckReflection(xmlresourceparserreader_fromjnihandle, "XmlResourceParserReader.FromJniHandle");
			CheckReflection(xmlreaderpullparser_tojnihandle, "XmlReaderPullParser.ToLocalJniHandle");
			CheckReflection(xmlreaderresourceparser_tojnihandle, "XmlReaderResourceParser.ToLocalJniHandle");
			CheckReflection(inputstreaminvoker_fromjnihandle, "InputStreamInvoker.FromJniHandle");
			CheckReflection(inputstreamadapter_tojnihandle, "InputStreamAdapter.ToLocalJniHandle");
			CheckReflection(outputstreaminvoker_fromjnihandle, "OutputStreamInvoker.FromJniHandle");
			CheckReflection(outputstreamadapter_tojnihandle, "OutputStreamAdapter.ToLocalJniHandle");
		}

		private static MethodInfo GetEnumerableCharToIntPtrMethodInfo(Func<IEnumerable<char>, IntPtr> func)
		{
			return func.Method;
		}

		private static MethodInfo GetObjectToIntPtrMethodInfo(Func<IJavaObject, IntPtr> func)
		{
			return func.Method;
		}

		private static MethodInfo GetHandleToIntPtrMethodInfo(Func<IntPtr, JniHandleOwnership, IntPtr> func)
		{
			return func.Method;
		}

		private static MethodInfo GetHandleToStreamMethodInfo(Func<IntPtr, JniHandleOwnership, Stream> func)
		{
			return func.Method;
		}

		private static MethodInfo GetHandleToStringMethodInfo(Func<IntPtr, JniHandleOwnership, string> func)
		{
			return func.Method;
		}

		private static MethodInfo GetHandleToXmlReaderMethodInfo(Func<IntPtr, JniHandleOwnership, XmlReader> func)
		{
			return func.Method;
		}

		private static MethodInfo GetHandleToXmlResourceParserReaderMethodInfo(Func<IntPtr, JniHandleOwnership, XmlResourceParserReader> func)
		{
			return func.Method;
		}

		private static MethodInfo GetIntPtrToTArray<T>(Func<IntPtr, T[]> func)
		{
			return func.Method.GetGenericMethodDefinition();
		}

		private static MethodInfo GetStreamToIntPtrMethodInfo(Func<Stream, IntPtr> func)
		{
			return func.Method;
		}

		private static MethodInfo GetStringToIntPtrMethodInfo(Func<string, IntPtr> func)
		{
			return func.Method;
		}

		private static MethodInfo GetTArrayToIntPtr<T>(Func<T[], IntPtr> func)
		{
			return func.Method.GetGenericMethodDefinition();
		}

		private static MethodInfo GetXmlReaderToIntPtrMethodInfo(Func<XmlReader, IntPtr> func)
		{
			return func.Method;
		}

		private static MethodInfo GetXmlResourceParserReaderToIntPtrMethodInfo(Func<XmlResourceParserReader, IntPtr> func)
		{
			return func.Method;
		}

		private static void CheckReflection(MethodInfo mi, string name)
		{
			if (mi == null)
			{
				throw new InvalidOperationException("Mono for Android bug: JNIEnv type contains incompatible method signatures : " + name);
			}
		}

		public static DynamicInvokeTypeInfo Get(Type type, ExportParameterKind kind)
		{
			return new DynamicInvokeTypeInfo(type, kind);
		}

		private DynamicInvokeTypeInfo(Type type, ExportParameterKind parameterKind)
		{
			this.type = type;
			parameter_kind = parameterKind;
		}

		public CodeExpression PrepareCallback(CodeExpression arg)
		{
			return GetCallbackPrep(type, parameter_kind, arg);
		}

		public CodeExpression CleanupCallback(CodeExpression arg, CodeExpression orgArg)
		{
			return GetCallbackCleanup(type, arg, orgArg);
		}

		private static bool NeedsPreparation(Type type, ExportParameterKind pkind)
		{
			SymbolKind kind = GetKind(type);
			if ((uint)kind <= 1u || kind == SymbolKind.String)
			{
				return true;
			}
			return false;
		}

		public static CodeExpression GetCallbackPrep(Type type, ExportParameterKind pkind, CodeExpression arg)
		{
			return GetKind(type) switch
			{
				SymbolKind.Array => new CodeMethodCall(jnienv_getarray, arg, do_not_transfer_literal, new CodeLiteral(type)).CastTo(type), 
				SymbolKind.CharSequence => new CodeMethodCall(object_getobject.MakeGenericMethod(typeof(ICharSequence)), arg, do_not_transfer_literal), 
				SymbolKind.Stream => arg, 
				SymbolKind.String => new CodeMethodCall(jnienv_getstring, arg, do_not_transfer_literal), 
				SymbolKind.XmlReader => arg, 
				_ => arg, 
			};
		}

		public static CodeExpression GetCallbackCleanup(Type type, CodeExpression arg, CodeExpression orgArg)
		{
			switch (GetKind(type))
			{
			case SymbolKind.Array:
			{
				MethodInfo method;
				switch (Type.GetTypeCode(type))
				{
				case TypeCode.Empty:
				case TypeCode.DBNull:
					throw new NotSupportedException("Only primitive types and IJavaObject is supported in array type in callback method parameter or return value");
				case TypeCode.Object:
					if (typeof(IJavaObject).IsAssignableFrom(type))
					{
						method = typeof(JNIEnv).GetMethod("CopyArray", new Type[2]
						{
							typeof(IJavaObject),
							typeof(IntPtr)
						});
						break;
					}
					goto case TypeCode.Empty;
				default:
					method = typeof(JNIEnv).GetMethod("CopyArray", new Type[2]
					{
						type,
						typeof(IntPtr)
					});
					break;
				}
				return new CodeWhen(arg.IsNull, arg, new CodeMethodCall(method, arg, orgArg));
			}
			case SymbolKind.CharSequence:
				return new CodeMethodCall(object_getobject.MakeGenericMethod(typeof(ICharSequence)), arg, do_not_transfer_literal);
			default:
				return arg;
			}
		}

		private static SymbolKind GetKind(Type type)
		{
			if (type.IsArray)
			{
				return SymbolKind.Array;
			}
			if (type.IsEnum)
			{
				return SymbolKind.Enum;
			}
			if (type == typeof(ICharSequence))
			{
				return SymbolKind.CharSequence;
			}
			if (type == typeof(Stream))
			{
				return SymbolKind.Stream;
			}
			if (type == typeof(XmlReader))
			{
				return SymbolKind.XmlReader;
			}
			if (type == typeof(string))
			{
				return SymbolKind.String;
			}
			if (Type.GetTypeCode(type) != TypeCode.Object)
			{
				return SymbolKind.SimpleFormat;
			}
			if (type == typeof(IList) || type == typeof(IDictionary) || type == typeof(ICollection))
			{
				return SymbolKind.Collection;
			}
			if (type.IsGenericParameter)
			{
				return SymbolKind.GenericTypeParameter;
			}
			if (type.IsGenericTypeDefinition)
			{
				throw new NotSupportedException("Dynamic method generation is not supported for generic type definition");
			}
			if (type.IsInterface)
			{
				return SymbolKind.Interface;
			}
			return SymbolKind.Class;
		}

		public CodeExpression FromNative(CodeExpression arg)
		{
			return GetKind(type) switch
			{
				SymbolKind.Array => new CodeMethodCall(jnienv_getarray.MakeGenericMethod(type.GetElementType()), arg, do_not_transfer_literal, new CodeLiteral(type)).CastTo(type.GetElementType().MakeArrayType()), 
				SymbolKind.CharSequence => new CodeMethodCall(object_getobject.MakeGenericMethod(type), arg, do_not_transfer_literal), 
				SymbolKind.Class => new CodeMethodCall(object_getobject.MakeGenericMethod(type), arg, do_not_transfer_literal), 
				SymbolKind.Enum => arg.CastTo(type), 
				SymbolKind.SimpleFormat => arg, 
				SymbolKind.GenericTypeParameter => new CodeMethodCall(object_getobject.MakeGenericMethod(type), arg, do_not_transfer_literal).CastTo(type), 
				SymbolKind.Interface => new CodeMethodCall(object_getobject.MakeGenericMethod(type), arg, do_not_transfer_literal), 
				SymbolKind.Stream => parameter_kind switch
				{
					ExportParameterKind.InputStream => new CodeMethodCall(inputstreaminvoker_fromjnihandle, arg, do_not_transfer_literal), 
					ExportParameterKind.OutputStream => new CodeMethodCall(outputstreaminvoker_fromjnihandle, arg, do_not_transfer_literal), 
					_ => throw new NotSupportedException("To use Stream type in callback, ExportParameterAttribute is required on the parameter to indicate its Java appropriate parameter kind"), 
				}, 
				SymbolKind.String => new CodeMethodCall(jnienv_getstring, arg, do_not_transfer_literal), 
				SymbolKind.XmlReader => parameter_kind switch
				{
					ExportParameterKind.XmlPullParser => new CodeMethodCall(xmlpullparserreader_fromjnihandle, arg, do_not_transfer_literal), 
					ExportParameterKind.XmlResourceParser => new CodeMethodCall(xmlresourceparserreader_fromjnihandle, arg, do_not_transfer_literal), 
					_ => throw new NotSupportedException("To use XmlReader type in callback, ExportParameterAttribute is required on the parameter to indicate its Java appropriate parameter kind"), 
				}, 
				_ => throw new InvalidOperationException(), 
			};
		}

		[DynamicDependency("ToLocalJniHandle", "Android.Runtime.JavaArray`1", "Mono.Android")]
		[DynamicDependency("ToLocalJniHandle", "Android.Runtime.JavaCollection", "Mono.Android")]
		[DynamicDependency("ToLocalJniHandle", "Android.Runtime.JavaCollection`1", "Mono.Android")]
		[DynamicDependency("ToLocalJniHandle", "Android.Runtime.JavaDictionary", "Mono.Android")]
		[DynamicDependency("ToLocalJniHandle", "Android.Runtime.JavaDictionary`2", "Mono.Android")]
		[DynamicDependency("ToLocalJniHandle", "Android.Runtime.JavaList", "Mono.Android")]
		[DynamicDependency("ToLocalJniHandle", "Android.Runtime.JavaList`1", "Mono.Android")]
		[DynamicDependency("ToLocalJniHandle", "Android.Runtime.JavaSet", "Mono.Android")]
		[DynamicDependency("ToLocalJniHandle", "Android.Runtime.JavaSet`1", "Mono.Android")]
		public CodeExpression ToNative(CodeExpression arg)
		{
			return GetKind(type) switch
			{
				SymbolKind.Array => new CodeMethodCall(jnienv_newarray.MakeGenericMethod(type.GetElementType()), arg), 
				SymbolKind.CharSequence => new CodeMethodCall(charsequence_tojnihandle, arg), 
				SymbolKind.Class => new CodeMethodCall(jnienv_tojnihandle, arg), 
				SymbolKind.Collection => new CodeMethodCall(type.GetMethod("ToLocalJniHandle"), arg), 
				SymbolKind.Enum => arg.CastTo(typeof(int)), 
				SymbolKind.SimpleFormat => arg, 
				SymbolKind.GenericTypeParameter => new CodeMethodCall(jnienv_tojnihandle, arg), 
				SymbolKind.Interface => new CodeMethodCall(jnienv_tojnihandle, arg), 
				SymbolKind.Stream => parameter_kind switch
				{
					ExportParameterKind.InputStream => new CodeMethodCall(inputstreamadapter_tojnihandle, arg), 
					ExportParameterKind.OutputStream => new CodeMethodCall(outputstreamadapter_tojnihandle, arg), 
					_ => throw new NotSupportedException("To use Stream type in callback, ExportParameterAttribute is required on the parameter to indicate its Java appropriate parameter kind"), 
				}, 
				SymbolKind.String => new CodeMethodCall(jnienv_newstring, arg), 
				SymbolKind.XmlReader => parameter_kind switch
				{
					ExportParameterKind.XmlPullParser => new CodeMethodCall(xmlreaderpullparser_tojnihandle, arg), 
					ExportParameterKind.XmlResourceParser => new CodeMethodCall(xmlreaderresourceparser_tojnihandle, arg), 
					_ => throw new NotSupportedException("To use XmlReader type in callback, ExportParameterAttribute is required on the parameter to indicate its Java appropriate parameter kind"), 
				}, 
				_ => throw new InvalidOperationException(), 
			};
		}

		public static Type GetNativeType(Type type)
		{
			if (type == typeof(void))
			{
				return typeof(void);
			}
			if (type.IsEnum)
			{
				return typeof(int);
			}
			TypeCode typeCode = Type.GetTypeCode(type);
			if ((uint)(typeCode - 1) <= 1u || typeCode == TypeCode.String)
			{
				return typeof(IntPtr);
			}
			return type;
		}
	}
	internal static class DynamicCallbackFactory
	{
		public static ModuleBuilder Module { get; private set; }

		public static CodeClass CodeClass { get; private set; }

		static DynamicCallbackFactory()
		{
			Module = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName("__callback_factory__"), AssemblyBuilderAccess.Run).DefineDynamicModule("__callback_factory__");
			CodeClass = new CodeClass(Module, "__callback_factory__class__");
		}
	}
	internal class DynamicCallbackCodeGenerator : CallbackCodeGenerator<Type>
	{
		private MethodInfo method;

		private Type delegate_type;

		private static int gen_count;

		private static readonly MethodInfo get_object_method = typeof(Java.Lang.Object).GetMethod("GetObject", new Type[3]
		{
			typeof(IntPtr),
			typeof(IntPtr),
			typeof(JniHandleOwnership)
		});

		private static readonly CodeLiteral do_not_transfer_literal = new CodeLiteral(JniHandleOwnership.DoNotTransfer);

		private Delegate result;

		private DynamicInvokeTypeInfo return_type_info;

		private List<DynamicInvokeTypeInfo> parameter_type_infos;

		public static Delegate Create(MethodInfo method)
		{
			return new DynamicCallbackCodeGenerator(method).GetCallback();
		}

		private static ExportParameterKind GetExportKind(ICustomAttributeProvider m)
		{
			object[] customAttributes = m.GetCustomAttributes(typeof(ExportParameterAttribute), inherit: false);
			int num = 0;
			if (num < customAttributes.Length)
			{
				return ((ExportParameterAttribute)customAttributes[num]).Kind;
			}
			return ExportParameterKind.Unspecified;
		}

		public DynamicCallbackCodeGenerator(MethodInfo method)
		{
			this.method = method;
			return_type_info = DynamicInvokeTypeInfo.Get(method.ReturnType, GetExportKind(method.ReturnParameter));
			List<DynamicInvokeTypeInfo> list = new List<DynamicInvokeTypeInfo>();
			ParameterInfo[] parameters = method.GetParameters();
			foreach (ParameterInfo parameterInfo in parameters)
			{
				list.Add(DynamicInvokeTypeInfo.Get(parameterInfo.ParameterType, GetExportKind(parameterInfo)));
			}
			parameter_type_infos = list;
		}

		private static Type GetActionFuncType(int count, bool func)
		{
			if (func)
			{
				return count switch
				{
					1 => typeof(Func<>), 
					2 => typeof(Func<, >), 
					3 => typeof(Func<, , >), 
					4 => typeof(Func<, , , >), 
					5 => typeof(Func<, , , , >), 
					6 => typeof(Func<, , , , , >), 
					7 => typeof(Func<, , , , , , >), 
					8 => typeof(Func<, , , , , , , >), 
					9 => typeof(Func<, , , , , , , , >), 
					10 => typeof(Func<, , , , , , , , , >), 
					11 => typeof(Func<, , , , , , , , , , >), 
					12 => typeof(Func<, , , , , , , , , , , >), 
					13 => typeof(Func<, , , , , , , , , , , , >), 
					_ => throw new NotSupportedException(), 
				};
			}
			return count switch
			{
				1 => typeof(Action<>), 
				2 => typeof(Action<, >), 
				3 => typeof(Action<, , >), 
				4 => typeof(Action<, , , >), 
				5 => typeof(Action<, , , , >), 
				6 => typeof(Action<, , , , , >), 
				7 => typeof(Action<, , , , , , >), 
				8 => typeof(Action<, , , , , , , >), 
				9 => typeof(Action<, , , , , , , , >), 
				10 => typeof(Action<, , , , , , , , , >), 
				11 => typeof(Action<, , , , , , , , , , >), 
				12 => typeof(Action<, , , , , , , , , , , >), 
				13 => typeof(Action<, , , , , , , , , , , , >), 
				_ => throw new NotSupportedException(), 
			};
		}

		public override Type GetDelegateType()
		{
			if (delegate_type == null)
			{
				List<Type> list = new List<Type>();
				list.Add(typeof(IntPtr));
				list.Add(typeof(IntPtr));
				list.AddRange(parameter_type_infos.ConvertAll((DynamicInvokeTypeInfo p) => p.NativeType));
				if (method.ReturnType == typeof(void))
				{
					delegate_type = ((list.Count == 0) ? typeof(Action) : GetActionFuncType(list.Count, func: false).MakeGenericType(list.ToArray()));
				}
				else
				{
					list.Add(return_type_info.NativeType);
					delegate_type = GetActionFuncType(list.Count, func: true).MakeGenericType(list.ToArray());
				}
			}
			return delegate_type;
		}

		public Delegate GetCallback()
		{
			if ((object)result == null)
			{
				GenerateNativeCallbackDelegate();
			}
			return result;
		}

		public override void GenerateNativeCallbackDelegate()
		{
			int num;
			lock (DynamicCallbackFactory.Module)
			{
				num = gen_count++;
			}
			string text = "dynamic_callback_" + num;
			List<Type> list = new List<Type>();
			list.Add(typeof(IntPtr));
			list.Add(typeof(IntPtr));
			list.AddRange(parameter_type_infos.ConvertAll((DynamicInvokeTypeInfo p) => p.NativeType).ToArray());
			CodeMethod codeMethod = GenerateNativeCallbackDelegate(text);
			DynamicMethod dynamicMethod = new DynamicMethod(text, MethodAttributes.Public | MethodAttributes.Static, CallingConventions.Standard, return_type_info.NativeType, list.ToArray(), DynamicCallbackFactory.Module, skipVisibility: true);
			codeMethod.Generate(dynamicMethod.GetILGenerator());
			result = dynamicMethod.CreateDelegate(GetDelegateType());
		}

		private CodeMethod GenerateNativeCallbackDelegate(string generatedMethodName)
		{
			List<Type> list = new List<Type>();
			list.Add(typeof(IntPtr));
			list.Add(typeof(IntPtr));
			list.AddRange(parameter_type_infos.ConvertAll((DynamicInvokeTypeInfo p) => p.NativeType).ToArray());
			CodeMethod codeMethod = DynamicCallbackFactory.CodeClass.CreateMethod(generatedMethodName, MethodAttributes.Static, return_type_info.NativeType, list.ToArray());
			CodeBuilder codeBuilder = codeMethod.CodeBuilder;
			CodeVariableReference target = null;
			if (!method.IsStatic)
			{
				target = codeBuilder.DeclareVariable(method.DeclaringType, new CodeMethodCall(get_object_method.MakeGenericMethod(method.DeclaringType), codeMethod.GetArg(0), codeMethod.GetArg(1), do_not_transfer_literal));
			}
			List<CodeExpression> list2 = new List<CodeExpression>();
			for (int num = 0; num < parameter_type_infos.Count; num++)
			{
				if (parameter_type_infos[num].NeedsPrep)
				{
					list2.Add(parameter_type_infos[num].PrepareCallback(codeMethod.GetArg(num + 2)));
				}
				else
				{
					list2.Add(parameter_type_infos[num].FromNative(codeMethod.GetArg(num + 2)));
				}
			}
			CodeMethodCall codeMethodCall = ((!method.IsStatic) ? new CodeMethodCall(target, method, list2.ToArray()) : new CodeMethodCall(method, list2.ToArray()));
			CodeExpression exp = null;
			if (method.ReturnType == typeof(void))
			{
				codeBuilder.CurrentBlock.Add(codeMethodCall);
			}
			else
			{
				exp = codeBuilder.DeclareVariable(return_type_info.NativeType, return_type_info.ToNative(codeMethodCall));
			}
			new List<CodeStatement>();
			for (int num2 = 0; num2 < parameter_type_infos.Count; num2++)
			{
				codeBuilder.CurrentBlock.Add(parameter_type_infos[num2].CleanupCallback(list2[num2], codeMethod.GetArg(num2)));
			}
			if (method.ReturnType != typeof(void))
			{
				codeBuilder.Return(exp);
			}
			return codeMethod;
		}
	}
}
