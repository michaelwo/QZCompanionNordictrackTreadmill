using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.Runtime;
using AndroidX.ConstraintLayout.Solver.Widgets;
using AndroidX.ConstraintLayout.Solver.Widgets.Analyzer;
using Java.Interop;
using Java.Lang;
using Java.Util;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "7e7f264778d957d442c28296ca1e0fea70a60529")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20201215.1")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "12/15/2020 3:19:08 PM")]
[assembly: LinkerSafe]
[assembly: NamespaceMapping(Java = "androidx.constraintlayout.solver", Managed = "AndroidX.ConstraintLayout.Solver")]
[assembly: NamespaceMapping(Java = "androidx.constraintlayout.solver.state", Managed = "AndroidX.ConstraintLayout.Solver.State")]
[assembly: NamespaceMapping(Java = "androidx.constraintlayout.solver.state.helpers", Managed = "AndroidX.ConstraintLayout.Solver.State.Helpers")]
[assembly: NamespaceMapping(Java = "androidx.constraintlayout.solver.widgets", Managed = "AndroidX.ConstraintLayout.Solver.Widgets")]
[assembly: NamespaceMapping(Java = "androidx.constraintlayout.solver.widgets.analyzer", Managed = "AndroidX.ConstraintLayout.Solver.Widgets.Analyzer")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Xamarin.Android bindings for AndroidX - constraintlayout-solver")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.ConstraintLayout.Solver")]
[assembly: AssemblyTitle("Xamarin.AndroidX.ConstraintLayout.Solver")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate float _JniMarshal_PP_F(IntPtr jnienv, IntPtr klass);
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate long _JniMarshal_PP_J(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PPF_V(IntPtr jnienv, IntPtr klass, float p0);
internal delegate IntPtr _JniMarshal_PPFFFLILILILI_L(IntPtr jnienv, IntPtr klass, float p0, float p1, float p2, IntPtr p3, int p4, IntPtr p5, int p6, IntPtr p7, int p8, IntPtr p9, int p10);
internal delegate IntPtr _JniMarshal_PPFFFLLLL_L(IntPtr jnienv, IntPtr klass, float p0, float p1, float p2, IntPtr p3, IntPtr p4, IntPtr p5, IntPtr p6);
internal delegate void _JniMarshal_PPFI_V(IntPtr jnienv, IntPtr klass, float p0, int p1);
internal delegate float _JniMarshal_PPI_F(IntPtr jnienv, IntPtr klass, int p0);
internal delegate int _JniMarshal_PPI_I(IntPtr jnienv, IntPtr klass, int p0);
internal delegate long _JniMarshal_PPI_J(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPI_L(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPI_V(IntPtr jnienv, IntPtr klass, int p0);
internal delegate bool _JniMarshal_PPI_Z(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPII_V(IntPtr jnienv, IntPtr klass, int p0, int p1);
internal delegate void _JniMarshal_PPIII_V(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2);
internal delegate void _JniMarshal_PPIIIF_V(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2, float p3);
internal delegate void _JniMarshal_PPIIII_V(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2, int p3);
internal delegate void _JniMarshal_PPIIIIII_V(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2, int p3, int p4, int p5);
internal delegate long _JniMarshal_PPIIIIIIIII_J(IntPtr jnienv, IntPtr klass, int p0, int p1, int p2, int p3, int p4, int p5, int p6, int p7, int p8);
internal delegate IntPtr _JniMarshal_PPIL_L(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1);
internal delegate void _JniMarshal_PPIL_V(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1);
internal delegate void _JniMarshal_PPILL_V(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1, IntPtr p2);
internal delegate void _JniMarshal_PPIZ_V(IntPtr jnienv, IntPtr klass, int p0, bool p1);
internal delegate float _JniMarshal_PPL_F(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate int _JniMarshal_PPL_I(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPLF_V(IntPtr jnienv, IntPtr klass, IntPtr p0, float p1);
internal delegate void _JniMarshal_PPLFI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, float p1, int p2);
internal delegate void _JniMarshal_PPLFZ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, float p1, bool p2);
internal delegate int _JniMarshal_PPLI_I(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate IntPtr _JniMarshal_PPLI_L(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate void _JniMarshal_PPLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate bool _JniMarshal_PPLI_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate long _JniMarshal_PPLIIIIIIIII_J(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, int p3, int p4, int p5, int p6, int p7, int p8, int p9);
internal delegate bool _JniMarshal_PPLIIZ_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, bool p3);
internal delegate IntPtr _JniMarshal_PPLIL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, IntPtr p2);
internal delegate void _JniMarshal_PPLIL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, IntPtr p2);
internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate bool _JniMarshal_PPLL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLLF_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, float p2);
internal delegate void _JniMarshal_PPLLFI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, float p2, int p3);
internal delegate IntPtr _JniMarshal_PPLLI_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2);
internal delegate void _JniMarshal_PPLLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2);
internal delegate void _JniMarshal_PPLLIFLLII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, float p3, IntPtr p4, IntPtr p5, int p6, int p7);
internal delegate IntPtr _JniMarshal_PPLLII_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, int p3);
internal delegate void _JniMarshal_PPLLII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, int p3);
internal delegate void _JniMarshal_PPLLIZ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, int p2, bool p3);
internal delegate void _JniMarshal_PPLLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate IntPtr _JniMarshal_PPLLLI_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, int p3);
internal delegate void _JniMarshal_PPLLLI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, int p3);
internal delegate void _JniMarshal_PPLLLII_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, int p3, int p4);
internal delegate void _JniMarshal_PPLLLIZ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, int p3, bool p4);
internal delegate IntPtr _JniMarshal_PPLLLLF_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3, float p4);
internal delegate void _JniMarshal_PPLLLLFI_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2, IntPtr p3, float p4, int p5);
internal delegate void _JniMarshal_PPLLZ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, bool p2);
internal delegate float _JniMarshal_PPLZ_F(IntPtr jnienv, IntPtr klass, IntPtr p0, bool p1);
internal delegate void _JniMarshal_PPLZ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, bool p1);
internal delegate void _JniMarshal_PPZ_V(IntPtr jnienv, IntPtr klass, bool p0);
internal delegate bool _JniMarshal_PPZ_Z(IntPtr jnienv, IntPtr klass, bool p0);
internal delegate bool _JniMarshal_PPZI_Z(IntPtr jnienv, IntPtr klass, bool p0, int p1);
internal delegate void _JniMarshal_PPZZ_V(IntPtr jnienv, IntPtr klass, bool p0, bool p1);
internal delegate void _JniMarshal_PPZZZZ_V(IntPtr jnienv, IntPtr klass, bool p0, bool p1, bool p2, bool p3);
namespace AndroidX.ConstraintLayout.Solver
{
	[Register("androidx/constraintlayout/solver/ArrayRow", DoNotGenerateAcw = true)]
	public class ArrayRow : Java.Lang.Object
	{
		[Register("androidx/constraintlayout/solver/ArrayRow$ArrayRowVariables", "", "AndroidX.ConstraintLayout.Solver.ArrayRow/IArrayRowVariablesInvoker")]
		public interface IArrayRowVariables : IJavaObject, IDisposable, IJavaPeerable
		{
			int CurrentSize
			{
				[Register("getCurrentSize", "()I", "GetGetCurrentSizeHandler:AndroidX.ConstraintLayout.Solver.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Solver")]
				get;
			}

			[Register("add", "(Landroidx/constraintlayout/solver/SolverVariable;FZ)V", "GetAdd_Landroidx_constraintlayout_solver_SolverVariable_FZHandler:AndroidX.ConstraintLayout.Solver.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Solver")]
			void Add(SolverVariable p0, float p1, bool p2);

			[Register("clear", "()V", "GetClearHandler:AndroidX.ConstraintLayout.Solver.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Solver")]
			void Clear();

			[Register("contains", "(Landroidx/constraintlayout/solver/SolverVariable;)Z", "GetContains_Landroidx_constraintlayout_solver_SolverVariable_Handler:AndroidX.ConstraintLayout.Solver.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Solver")]
			bool Contains(SolverVariable p0);

			[Register("display", "()V", "GetDisplayHandler:AndroidX.ConstraintLayout.Solver.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Solver")]
			void Display();

			[Register("divideByAmount", "(F)V", "GetDivideByAmount_FHandler:AndroidX.ConstraintLayout.Solver.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Solver")]
			void DivideByAmount(float p0);

			[Register("get", "(Landroidx/constraintlayout/solver/SolverVariable;)F", "GetGet_Landroidx_constraintlayout_solver_SolverVariable_Handler:AndroidX.ConstraintLayout.Solver.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Solver")]
			float Get(SolverVariable p0);

			[Register("getVariable", "(I)Landroidx/constraintlayout/solver/SolverVariable;", "GetGetVariable_IHandler:AndroidX.ConstraintLayout.Solver.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Solver")]
			SolverVariable GetVariable(int p0);

			[Register("getVariableValue", "(I)F", "GetGetVariableValue_IHandler:AndroidX.ConstraintLayout.Solver.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Solver")]
			float GetVariableValue(int p0);

			[Register("indexOf", "(Landroidx/constraintlayout/solver/SolverVariable;)I", "GetIndexOf_Landroidx_constraintlayout_solver_SolverVariable_Handler:AndroidX.ConstraintLayout.Solver.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Solver")]
			int IndexOf(SolverVariable p0);

			[Register("invert", "()V", "GetInvertHandler:AndroidX.ConstraintLayout.Solver.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Solver")]
			void Invert();

			[Register("put", "(Landroidx/constraintlayout/solver/SolverVariable;F)V", "GetPut_Landroidx_constraintlayout_solver_SolverVariable_FHandler:AndroidX.ConstraintLayout.Solver.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Solver")]
			void Put(SolverVariable p0, float p1);

			[Register("remove", "(Landroidx/constraintlayout/solver/SolverVariable;Z)F", "GetRemove_Landroidx_constraintlayout_solver_SolverVariable_ZHandler:AndroidX.ConstraintLayout.Solver.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Solver")]
			float Remove(SolverVariable p0, bool p1);

			[Register("sizeInBytes", "()I", "GetSizeInBytesHandler:AndroidX.ConstraintLayout.Solver.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Solver")]
			int SizeInBytes();

			[Register("use", "(Landroidx/constraintlayout/solver/ArrayRow;Z)F", "GetUse_Landroidx_constraintlayout_solver_ArrayRow_ZHandler:AndroidX.ConstraintLayout.Solver.ArrayRow/IArrayRowVariablesInvoker, Xamarin.AndroidX.ConstraintLayout.Solver")]
			float Use(ArrayRow p0, bool p1);
		}

		[Register("androidx/constraintlayout/solver/ArrayRow$ArrayRowVariables", DoNotGenerateAcw = true)]
		internal class IArrayRowVariablesInvoker : Java.Lang.Object, IArrayRowVariables, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/ArrayRow$ArrayRowVariables", typeof(IArrayRowVariablesInvoker));

			private IntPtr class_ref;

			private static Delegate cb_getCurrentSize;

			private IntPtr id_getCurrentSize;

			private static Delegate cb_add_Landroidx_constraintlayout_solver_SolverVariable_FZ;

			private IntPtr id_add_Landroidx_constraintlayout_solver_SolverVariable_FZ;

			private static Delegate cb_clear;

			private IntPtr id_clear;

			private static Delegate cb_contains_Landroidx_constraintlayout_solver_SolverVariable_;

			private IntPtr id_contains_Landroidx_constraintlayout_solver_SolverVariable_;

			private static Delegate cb_display;

			private IntPtr id_display;

			private static Delegate cb_divideByAmount_F;

			private IntPtr id_divideByAmount_F;

			private static Delegate cb_get_Landroidx_constraintlayout_solver_SolverVariable_;

			private IntPtr id_get_Landroidx_constraintlayout_solver_SolverVariable_;

			private static Delegate cb_getVariable_I;

			private IntPtr id_getVariable_I;

			private static Delegate cb_getVariableValue_I;

			private IntPtr id_getVariableValue_I;

			private static Delegate cb_indexOf_Landroidx_constraintlayout_solver_SolverVariable_;

			private IntPtr id_indexOf_Landroidx_constraintlayout_solver_SolverVariable_;

			private static Delegate cb_invert;

			private IntPtr id_invert;

			private static Delegate cb_put_Landroidx_constraintlayout_solver_SolverVariable_F;

			private IntPtr id_put_Landroidx_constraintlayout_solver_SolverVariable_F;

			private static Delegate cb_remove_Landroidx_constraintlayout_solver_SolverVariable_Z;

			private IntPtr id_remove_Landroidx_constraintlayout_solver_SolverVariable_Z;

			private static Delegate cb_sizeInBytes;

			private IntPtr id_sizeInBytes;

			private static Delegate cb_use_Landroidx_constraintlayout_solver_ArrayRow_Z;

			private IntPtr id_use_Landroidx_constraintlayout_solver_ArrayRow_Z;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => class_ref;

			protected override Type ThresholdType => _members.ManagedPeerType;

			public int CurrentSize
			{
				get
				{
					if (id_getCurrentSize == IntPtr.Zero)
					{
						id_getCurrentSize = JNIEnv.GetMethodID(class_ref, "getCurrentSize", "()I");
					}
					return JNIEnv.CallIntMethod(base.Handle, id_getCurrentSize);
				}
			}

			public static IArrayRowVariables GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IArrayRowVariables>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.constraintlayout.solver.ArrayRow.ArrayRowVariables"));
				}
				return handle;
			}

			protected override void Dispose(bool disposing)
			{
				if (class_ref != IntPtr.Zero)
				{
					JNIEnv.DeleteGlobalRef(class_ref);
				}
				class_ref = IntPtr.Zero;
				base.Dispose(disposing);
			}

			public IArrayRowVariablesInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetGetCurrentSizeHandler()
			{
				if ((object)cb_getCurrentSize == null)
				{
					cb_getCurrentSize = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetCurrentSize));
				}
				return cb_getCurrentSize;
			}

			private static int n_GetCurrentSize(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CurrentSize;
			}

			private static Delegate GetAdd_Landroidx_constraintlayout_solver_SolverVariable_FZHandler()
			{
				if ((object)cb_add_Landroidx_constraintlayout_solver_SolverVariable_FZ == null)
				{
					cb_add_Landroidx_constraintlayout_solver_SolverVariable_FZ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLFZ_V(n_Add_Landroidx_constraintlayout_solver_SolverVariable_FZ));
				}
				return cb_add_Landroidx_constraintlayout_solver_SolverVariable_FZ;
			}

			private static void n_Add_Landroidx_constraintlayout_solver_SolverVariable_FZ(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, float p1, bool p2)
			{
				IArrayRowVariables arrayRowVariables = Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SolverVariable p3 = Java.Lang.Object.GetObject<SolverVariable>(native_p0, JniHandleOwnership.DoNotTransfer);
				arrayRowVariables.Add(p3, p1, p2);
			}

			public unsafe void Add(SolverVariable p0, float p1, bool p2)
			{
				if (id_add_Landroidx_constraintlayout_solver_SolverVariable_FZ == IntPtr.Zero)
				{
					id_add_Landroidx_constraintlayout_solver_SolverVariable_FZ = JNIEnv.GetMethodID(class_ref, "add", "(Landroidx/constraintlayout/solver/SolverVariable;FZ)V");
				}
				JValue* ptr = stackalloc JValue[3];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JValue(p1);
				ptr[2] = new JValue(p2);
				JNIEnv.CallVoidMethod(base.Handle, id_add_Landroidx_constraintlayout_solver_SolverVariable_FZ, ptr);
			}

			private static Delegate GetClearHandler()
			{
				if ((object)cb_clear == null)
				{
					cb_clear = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Clear));
				}
				return cb_clear;
			}

			private static void n_Clear(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
			}

			public void Clear()
			{
				if (id_clear == IntPtr.Zero)
				{
					id_clear = JNIEnv.GetMethodID(class_ref, "clear", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_clear);
			}

			private static Delegate GetContains_Landroidx_constraintlayout_solver_SolverVariable_Handler()
			{
				if ((object)cb_contains_Landroidx_constraintlayout_solver_SolverVariable_ == null)
				{
					cb_contains_Landroidx_constraintlayout_solver_SolverVariable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Contains_Landroidx_constraintlayout_solver_SolverVariable_));
				}
				return cb_contains_Landroidx_constraintlayout_solver_SolverVariable_;
			}

			private static bool n_Contains_Landroidx_constraintlayout_solver_SolverVariable_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IArrayRowVariables arrayRowVariables = Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SolverVariable p = Java.Lang.Object.GetObject<SolverVariable>(native_p0, JniHandleOwnership.DoNotTransfer);
				return arrayRowVariables.Contains(p);
			}

			public unsafe bool Contains(SolverVariable p0)
			{
				if (id_contains_Landroidx_constraintlayout_solver_SolverVariable_ == IntPtr.Zero)
				{
					id_contains_Landroidx_constraintlayout_solver_SolverVariable_ = JNIEnv.GetMethodID(class_ref, "contains", "(Landroidx/constraintlayout/solver/SolverVariable;)Z");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallBooleanMethod(base.Handle, id_contains_Landroidx_constraintlayout_solver_SolverVariable_, ptr);
			}

			private static Delegate GetDisplayHandler()
			{
				if ((object)cb_display == null)
				{
					cb_display = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Display));
				}
				return cb_display;
			}

			private static void n_Display(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Display();
			}

			public void Display()
			{
				if (id_display == IntPtr.Zero)
				{
					id_display = JNIEnv.GetMethodID(class_ref, "display", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_display);
			}

			private static Delegate GetDivideByAmount_FHandler()
			{
				if ((object)cb_divideByAmount_F == null)
				{
					cb_divideByAmount_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_DivideByAmount_F));
				}
				return cb_divideByAmount_F;
			}

			private static void n_DivideByAmount_F(IntPtr jnienv, IntPtr native__this, float p0)
			{
				Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DivideByAmount(p0);
			}

			public unsafe void DivideByAmount(float p0)
			{
				if (id_divideByAmount_F == IntPtr.Zero)
				{
					id_divideByAmount_F = JNIEnv.GetMethodID(class_ref, "divideByAmount", "(F)V");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0);
				JNIEnv.CallVoidMethod(base.Handle, id_divideByAmount_F, ptr);
			}

			private static Delegate GetGet_Landroidx_constraintlayout_solver_SolverVariable_Handler()
			{
				if ((object)cb_get_Landroidx_constraintlayout_solver_SolverVariable_ == null)
				{
					cb_get_Landroidx_constraintlayout_solver_SolverVariable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_F(n_Get_Landroidx_constraintlayout_solver_SolverVariable_));
				}
				return cb_get_Landroidx_constraintlayout_solver_SolverVariable_;
			}

			private static float n_Get_Landroidx_constraintlayout_solver_SolverVariable_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IArrayRowVariables arrayRowVariables = Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SolverVariable p = Java.Lang.Object.GetObject<SolverVariable>(native_p0, JniHandleOwnership.DoNotTransfer);
				return arrayRowVariables.Get(p);
			}

			public unsafe float Get(SolverVariable p0)
			{
				if (id_get_Landroidx_constraintlayout_solver_SolverVariable_ == IntPtr.Zero)
				{
					id_get_Landroidx_constraintlayout_solver_SolverVariable_ = JNIEnv.GetMethodID(class_ref, "get", "(Landroidx/constraintlayout/solver/SolverVariable;)F");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallFloatMethod(base.Handle, id_get_Landroidx_constraintlayout_solver_SolverVariable_, ptr);
			}

			private static Delegate GetGetVariable_IHandler()
			{
				if ((object)cb_getVariable_I == null)
				{
					cb_getVariable_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetVariable_I));
				}
				return cb_getVariable_I;
			}

			private static IntPtr n_GetVariable_I(IntPtr jnienv, IntPtr native__this, int p0)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetVariable(p0));
			}

			public unsafe SolverVariable GetVariable(int p0)
			{
				if (id_getVariable_I == IntPtr.Zero)
				{
					id_getVariable_I = JNIEnv.GetMethodID(class_ref, "getVariable", "(I)Landroidx/constraintlayout/solver/SolverVariable;");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0);
				return Java.Lang.Object.GetObject<SolverVariable>(JNIEnv.CallObjectMethod(base.Handle, id_getVariable_I, ptr), JniHandleOwnership.TransferLocalRef);
			}

			private static Delegate GetGetVariableValue_IHandler()
			{
				if ((object)cb_getVariableValue_I == null)
				{
					cb_getVariableValue_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_F(n_GetVariableValue_I));
				}
				return cb_getVariableValue_I;
			}

			private static float n_GetVariableValue_I(IntPtr jnienv, IntPtr native__this, int p0)
			{
				return Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetVariableValue(p0);
			}

			public unsafe float GetVariableValue(int p0)
			{
				if (id_getVariableValue_I == IntPtr.Zero)
				{
					id_getVariableValue_I = JNIEnv.GetMethodID(class_ref, "getVariableValue", "(I)F");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0);
				return JNIEnv.CallFloatMethod(base.Handle, id_getVariableValue_I, ptr);
			}

			private static Delegate GetIndexOf_Landroidx_constraintlayout_solver_SolverVariable_Handler()
			{
				if ((object)cb_indexOf_Landroidx_constraintlayout_solver_SolverVariable_ == null)
				{
					cb_indexOf_Landroidx_constraintlayout_solver_SolverVariable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_IndexOf_Landroidx_constraintlayout_solver_SolverVariable_));
				}
				return cb_indexOf_Landroidx_constraintlayout_solver_SolverVariable_;
			}

			private static int n_IndexOf_Landroidx_constraintlayout_solver_SolverVariable_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				IArrayRowVariables arrayRowVariables = Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SolverVariable p = Java.Lang.Object.GetObject<SolverVariable>(native_p0, JniHandleOwnership.DoNotTransfer);
				return arrayRowVariables.IndexOf(p);
			}

			public unsafe int IndexOf(SolverVariable p0)
			{
				if (id_indexOf_Landroidx_constraintlayout_solver_SolverVariable_ == IntPtr.Zero)
				{
					id_indexOf_Landroidx_constraintlayout_solver_SolverVariable_ = JNIEnv.GetMethodID(class_ref, "indexOf", "(Landroidx/constraintlayout/solver/SolverVariable;)I");
				}
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				return JNIEnv.CallIntMethod(base.Handle, id_indexOf_Landroidx_constraintlayout_solver_SolverVariable_, ptr);
			}

			private static Delegate GetInvertHandler()
			{
				if ((object)cb_invert == null)
				{
					cb_invert = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Invert));
				}
				return cb_invert;
			}

			private static void n_Invert(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Invert();
			}

			public void Invert()
			{
				if (id_invert == IntPtr.Zero)
				{
					id_invert = JNIEnv.GetMethodID(class_ref, "invert", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_invert);
			}

			private static Delegate GetPut_Landroidx_constraintlayout_solver_SolverVariable_FHandler()
			{
				if ((object)cb_put_Landroidx_constraintlayout_solver_SolverVariable_F == null)
				{
					cb_put_Landroidx_constraintlayout_solver_SolverVariable_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLF_V(n_Put_Landroidx_constraintlayout_solver_SolverVariable_F));
				}
				return cb_put_Landroidx_constraintlayout_solver_SolverVariable_F;
			}

			private static void n_Put_Landroidx_constraintlayout_solver_SolverVariable_F(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, float p1)
			{
				IArrayRowVariables arrayRowVariables = Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SolverVariable p2 = Java.Lang.Object.GetObject<SolverVariable>(native_p0, JniHandleOwnership.DoNotTransfer);
				arrayRowVariables.Put(p2, p1);
			}

			public unsafe void Put(SolverVariable p0, float p1)
			{
				if (id_put_Landroidx_constraintlayout_solver_SolverVariable_F == IntPtr.Zero)
				{
					id_put_Landroidx_constraintlayout_solver_SolverVariable_F = JNIEnv.GetMethodID(class_ref, "put", "(Landroidx/constraintlayout/solver/SolverVariable;F)V");
				}
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JValue(p1);
				JNIEnv.CallVoidMethod(base.Handle, id_put_Landroidx_constraintlayout_solver_SolverVariable_F, ptr);
			}

			private static Delegate GetRemove_Landroidx_constraintlayout_solver_SolverVariable_ZHandler()
			{
				if ((object)cb_remove_Landroidx_constraintlayout_solver_SolverVariable_Z == null)
				{
					cb_remove_Landroidx_constraintlayout_solver_SolverVariable_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLZ_F(n_Remove_Landroidx_constraintlayout_solver_SolverVariable_Z));
				}
				return cb_remove_Landroidx_constraintlayout_solver_SolverVariable_Z;
			}

			private static float n_Remove_Landroidx_constraintlayout_solver_SolverVariable_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
			{
				IArrayRowVariables arrayRowVariables = Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				SolverVariable p2 = Java.Lang.Object.GetObject<SolverVariable>(native_p0, JniHandleOwnership.DoNotTransfer);
				return arrayRowVariables.Remove(p2, p1);
			}

			public unsafe float Remove(SolverVariable p0, bool p1)
			{
				if (id_remove_Landroidx_constraintlayout_solver_SolverVariable_Z == IntPtr.Zero)
				{
					id_remove_Landroidx_constraintlayout_solver_SolverVariable_Z = JNIEnv.GetMethodID(class_ref, "remove", "(Landroidx/constraintlayout/solver/SolverVariable;Z)F");
				}
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JValue(p1);
				return JNIEnv.CallFloatMethod(base.Handle, id_remove_Landroidx_constraintlayout_solver_SolverVariable_Z, ptr);
			}

			private static Delegate GetSizeInBytesHandler()
			{
				if ((object)cb_sizeInBytes == null)
				{
					cb_sizeInBytes = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_SizeInBytes));
				}
				return cb_sizeInBytes;
			}

			private static int n_SizeInBytes(IntPtr jnienv, IntPtr native__this)
			{
				return Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SizeInBytes();
			}

			public int SizeInBytes()
			{
				if (id_sizeInBytes == IntPtr.Zero)
				{
					id_sizeInBytes = JNIEnv.GetMethodID(class_ref, "sizeInBytes", "()I");
				}
				return JNIEnv.CallIntMethod(base.Handle, id_sizeInBytes);
			}

			private static Delegate GetUse_Landroidx_constraintlayout_solver_ArrayRow_ZHandler()
			{
				if ((object)cb_use_Landroidx_constraintlayout_solver_ArrayRow_Z == null)
				{
					cb_use_Landroidx_constraintlayout_solver_ArrayRow_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLZ_F(n_Use_Landroidx_constraintlayout_solver_ArrayRow_Z));
				}
				return cb_use_Landroidx_constraintlayout_solver_ArrayRow_Z;
			}

			private static float n_Use_Landroidx_constraintlayout_solver_ArrayRow_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1)
			{
				IArrayRowVariables arrayRowVariables = Java.Lang.Object.GetObject<IArrayRowVariables>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ArrayRow p2 = Java.Lang.Object.GetObject<ArrayRow>(native_p0, JniHandleOwnership.DoNotTransfer);
				return arrayRowVariables.Use(p2, p1);
			}

			public unsafe float Use(ArrayRow p0, bool p1)
			{
				if (id_use_Landroidx_constraintlayout_solver_ArrayRow_Z == IntPtr.Zero)
				{
					id_use_Landroidx_constraintlayout_solver_ArrayRow_Z = JNIEnv.GetMethodID(class_ref, "use", "(Landroidx/constraintlayout/solver/ArrayRow;Z)F");
				}
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JValue(p1);
				return JNIEnv.CallFloatMethod(base.Handle, id_use_Landroidx_constraintlayout_solver_ArrayRow_Z, ptr);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/ArrayRow", typeof(ArrayRow));

		private static Delegate cb_isEmpty;

		private static Delegate cb_getKey;

		private static Delegate cb_addError_Landroidx_constraintlayout_solver_LinearSystem_I;

		private static Delegate cb_addError_Landroidx_constraintlayout_solver_SolverVariable_;

		private static Delegate cb_clear;

		private static Delegate cb_createRowDimensionRatio_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_F;

		private static Delegate cb_createRowEqualDimension_FFFLandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_I;

		private static Delegate cb_createRowEqualMatchDimensions_FFFLandroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_;

		private static Delegate cb_createRowEquals_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I;

		private static Delegate cb_createRowEquals_Landroidx_constraintlayout_solver_SolverVariable_I;

		private static Delegate cb_createRowGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I;

		private static Delegate cb_createRowGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_;

		private static Delegate cb_createRowLowerThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I;

		private static Delegate cb_createRowWithAngle_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_F;

		private static Delegate cb_getPivotCandidate_Landroidx_constraintlayout_solver_LinearSystem_arrayZ;

		private static Delegate cb_pickPivot_Landroidx_constraintlayout_solver_SolverVariable_;

		private static Delegate cb_reset;

		private static Delegate cb_updateFromFinalVariable_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_Z;

		private static Delegate cb_updateFromRow_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_ArrayRow_Z;

		private static Delegate cb_updateFromSynonymVariable_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_Z;

		private static Delegate cb_updateFromSystem_Landroidx_constraintlayout_solver_LinearSystem_;

		[Register("variables")]
		public IArrayRowVariables Variables
		{
			get
			{
				return Java.Lang.Object.GetObject<IArrayRowVariables>(_members.InstanceFields.GetObjectValue("variables.Landroidx/constraintlayout/solver/ArrayRow$ArrayRowVariables;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("variables.Landroidx/constraintlayout/solver/ArrayRow$ArrayRowVariables;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual bool IsEmpty
		{
			[Register("isEmpty", "()Z", "GetIsEmptyHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isEmpty.()Z", this, null);
			}
		}

		public unsafe virtual SolverVariable Key
		{
			[Register("getKey", "()Landroidx/constraintlayout/solver/SolverVariable;", "GetGetKeyHandler")]
			get
			{
				return Java.Lang.Object.GetObject<SolverVariable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getKey.()Landroidx/constraintlayout/solver/SolverVariable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected ArrayRow(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ArrayRow()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Landroidx/constraintlayout/solver/Cache;)V", "")]
		public unsafe ArrayRow(Cache cache)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cache?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/solver/Cache;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/solver/Cache;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(cache);
			}
		}

		private static Delegate GetIsEmptyHandler()
		{
			if ((object)cb_isEmpty == null)
			{
				cb_isEmpty = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsEmpty));
			}
			return cb_isEmpty;
		}

		private static bool n_IsEmpty(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsEmpty;
		}

		private static Delegate GetGetKeyHandler()
		{
			if ((object)cb_getKey == null)
			{
				cb_getKey = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetKey));
			}
			return cb_getKey;
		}

		private static IntPtr n_GetKey(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Key);
		}

		private static Delegate GetAddError_Landroidx_constraintlayout_solver_LinearSystem_IHandler()
		{
			if ((object)cb_addError_Landroidx_constraintlayout_solver_LinearSystem_I == null)
			{
				cb_addError_Landroidx_constraintlayout_solver_LinearSystem_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_L(n_AddError_Landroidx_constraintlayout_solver_LinearSystem_I));
			}
			return cb_addError_Landroidx_constraintlayout_solver_LinearSystem_I;
		}

		private static IntPtr n_AddError_Landroidx_constraintlayout_solver_LinearSystem_I(IntPtr jnienv, IntPtr native__this, IntPtr native_system, int strength)
		{
			ArrayRow arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayRow.AddError(system, strength));
		}

		[Register("addError", "(Landroidx/constraintlayout/solver/LinearSystem;I)Landroidx/constraintlayout/solver/ArrayRow;", "GetAddError_Landroidx_constraintlayout_solver_LinearSystem_IHandler")]
		public unsafe virtual ArrayRow AddError(LinearSystem system, int strength)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(strength);
				return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("addError.(Landroidx/constraintlayout/solver/LinearSystem;I)Landroidx/constraintlayout/solver/ArrayRow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(system);
			}
		}

		private static Delegate GetAddError_Landroidx_constraintlayout_solver_SolverVariable_Handler()
		{
			if ((object)cb_addError_Landroidx_constraintlayout_solver_SolverVariable_ == null)
			{
				cb_addError_Landroidx_constraintlayout_solver_SolverVariable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddError_Landroidx_constraintlayout_solver_SolverVariable_));
			}
			return cb_addError_Landroidx_constraintlayout_solver_SolverVariable_;
		}

		private static void n_AddError_Landroidx_constraintlayout_solver_SolverVariable_(IntPtr jnienv, IntPtr native__this, IntPtr native_error)
		{
			ArrayRow arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable error = Java.Lang.Object.GetObject<SolverVariable>(native_error, JniHandleOwnership.DoNotTransfer);
			arrayRow.AddError(error);
		}

		[Register("addError", "(Landroidx/constraintlayout/solver/SolverVariable;)V", "GetAddError_Landroidx_constraintlayout_solver_SolverVariable_Handler")]
		public unsafe virtual void AddError(SolverVariable error)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(error?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addError.(Landroidx/constraintlayout/solver/SolverVariable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(error);
			}
		}

		private static Delegate GetClearHandler()
		{
			if ((object)cb_clear == null)
			{
				cb_clear = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Clear));
			}
			return cb_clear;
		}

		private static void n_Clear(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
		}

		[Register("clear", "()V", "GetClearHandler")]
		public unsafe virtual void Clear()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("clear.()V", this, null);
		}

		private static Delegate GetCreateRowDimensionRatio_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_FHandler()
		{
			if ((object)cb_createRowDimensionRatio_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_F == null)
			{
				cb_createRowDimensionRatio_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_F = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLLF_L(n_CreateRowDimensionRatio_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_F));
			}
			return cb_createRowDimensionRatio_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_F;
		}

		private static IntPtr n_CreateRowDimensionRatio_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_F(IntPtr jnienv, IntPtr native__this, IntPtr native_variableA, IntPtr native_variableB, IntPtr native_variableC, IntPtr native_variableD, float ratio)
		{
			ArrayRow arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableA = Java.Lang.Object.GetObject<SolverVariable>(native_variableA, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableB = Java.Lang.Object.GetObject<SolverVariable>(native_variableB, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableC = Java.Lang.Object.GetObject<SolverVariable>(native_variableC, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableD = Java.Lang.Object.GetObject<SolverVariable>(native_variableD, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayRow.CreateRowDimensionRatio(variableA, variableB, variableC, variableD, ratio));
		}

		[Register("createRowDimensionRatio", "(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;F)Landroidx/constraintlayout/solver/ArrayRow;", "GetCreateRowDimensionRatio_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_FHandler")]
		public unsafe virtual ArrayRow CreateRowDimensionRatio(SolverVariable variableA, SolverVariable variableB, SolverVariable variableC, SolverVariable variableD, float ratio)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(variableA?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(variableB?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(variableC?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(variableD?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(ratio);
				return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("createRowDimensionRatio.(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;F)Landroidx/constraintlayout/solver/ArrayRow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(variableA);
				GC.KeepAlive(variableB);
				GC.KeepAlive(variableC);
				GC.KeepAlive(variableD);
			}
		}

		private static Delegate GetCreateRowEqualDimension_FFFLandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_IHandler()
		{
			if ((object)cb_createRowEqualDimension_FFFLandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_I == null)
			{
				cb_createRowEqualDimension_FFFLandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_I = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPFFFLILILILI_L(n_CreateRowEqualDimension_FFFLandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_I));
			}
			return cb_createRowEqualDimension_FFFLandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_I;
		}

		private static IntPtr n_CreateRowEqualDimension_FFFLandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_I(IntPtr jnienv, IntPtr native__this, float currentWeight, float totalWeights, float nextWeight, IntPtr native_variableStartA, int marginStartA, IntPtr native_variableEndA, int marginEndA, IntPtr native_variableStartB, int marginStartB, IntPtr native_variableEndB, int marginEndB)
		{
			ArrayRow arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableStartA = Java.Lang.Object.GetObject<SolverVariable>(native_variableStartA, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableEndA = Java.Lang.Object.GetObject<SolverVariable>(native_variableEndA, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableStartB = Java.Lang.Object.GetObject<SolverVariable>(native_variableStartB, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableEndB = Java.Lang.Object.GetObject<SolverVariable>(native_variableEndB, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayRow.CreateRowEqualDimension(currentWeight, totalWeights, nextWeight, variableStartA, marginStartA, variableEndA, marginEndA, variableStartB, marginStartB, variableEndB, marginEndB));
		}

		[Register("createRowEqualDimension", "(FFFLandroidx/constraintlayout/solver/SolverVariable;ILandroidx/constraintlayout/solver/SolverVariable;ILandroidx/constraintlayout/solver/SolverVariable;ILandroidx/constraintlayout/solver/SolverVariable;I)Landroidx/constraintlayout/solver/ArrayRow;", "GetCreateRowEqualDimension_FFFLandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_IHandler")]
		public unsafe virtual ArrayRow CreateRowEqualDimension(float currentWeight, float totalWeights, float nextWeight, SolverVariable variableStartA, int marginStartA, SolverVariable variableEndA, int marginEndA, SolverVariable variableStartB, int marginStartB, SolverVariable variableEndB, int marginEndB)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[11];
				*ptr = new JniArgumentValue(currentWeight);
				ptr[1] = new JniArgumentValue(totalWeights);
				ptr[2] = new JniArgumentValue(nextWeight);
				ptr[3] = new JniArgumentValue(variableStartA?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(marginStartA);
				ptr[5] = new JniArgumentValue(variableEndA?.Handle ?? IntPtr.Zero);
				ptr[6] = new JniArgumentValue(marginEndA);
				ptr[7] = new JniArgumentValue(variableStartB?.Handle ?? IntPtr.Zero);
				ptr[8] = new JniArgumentValue(marginStartB);
				ptr[9] = new JniArgumentValue(variableEndB?.Handle ?? IntPtr.Zero);
				ptr[10] = new JniArgumentValue(marginEndB);
				return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("createRowEqualDimension.(FFFLandroidx/constraintlayout/solver/SolverVariable;ILandroidx/constraintlayout/solver/SolverVariable;ILandroidx/constraintlayout/solver/SolverVariable;ILandroidx/constraintlayout/solver/SolverVariable;I)Landroidx/constraintlayout/solver/ArrayRow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(variableStartA);
				GC.KeepAlive(variableEndA);
				GC.KeepAlive(variableStartB);
				GC.KeepAlive(variableEndB);
			}
		}

		private static Delegate GetCreateRowEqualMatchDimensions_FFFLandroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Handler()
		{
			if ((object)cb_createRowEqualMatchDimensions_FFFLandroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_ == null)
			{
				cb_createRowEqualMatchDimensions_FFFLandroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPFFFLLLL_L(n_CreateRowEqualMatchDimensions_FFFLandroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_));
			}
			return cb_createRowEqualMatchDimensions_FFFLandroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_;
		}

		private static IntPtr n_CreateRowEqualMatchDimensions_FFFLandroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_(IntPtr jnienv, IntPtr native__this, float currentWeight, float totalWeights, float nextWeight, IntPtr native_variableStartA, IntPtr native_variableEndA, IntPtr native_variableStartB, IntPtr native_variableEndB)
		{
			ArrayRow arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableStartA = Java.Lang.Object.GetObject<SolverVariable>(native_variableStartA, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableEndA = Java.Lang.Object.GetObject<SolverVariable>(native_variableEndA, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableStartB = Java.Lang.Object.GetObject<SolverVariable>(native_variableStartB, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableEndB = Java.Lang.Object.GetObject<SolverVariable>(native_variableEndB, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayRow.CreateRowEqualMatchDimensions(currentWeight, totalWeights, nextWeight, variableStartA, variableEndA, variableStartB, variableEndB));
		}

		[Register("createRowEqualMatchDimensions", "(FFFLandroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;)Landroidx/constraintlayout/solver/ArrayRow;", "GetCreateRowEqualMatchDimensions_FFFLandroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Handler")]
		public unsafe virtual ArrayRow CreateRowEqualMatchDimensions(float currentWeight, float totalWeights, float nextWeight, SolverVariable variableStartA, SolverVariable variableEndA, SolverVariable variableStartB, SolverVariable variableEndB)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[7];
				*ptr = new JniArgumentValue(currentWeight);
				ptr[1] = new JniArgumentValue(totalWeights);
				ptr[2] = new JniArgumentValue(nextWeight);
				ptr[3] = new JniArgumentValue(variableStartA?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(variableEndA?.Handle ?? IntPtr.Zero);
				ptr[5] = new JniArgumentValue(variableStartB?.Handle ?? IntPtr.Zero);
				ptr[6] = new JniArgumentValue(variableEndB?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("createRowEqualMatchDimensions.(FFFLandroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;)Landroidx/constraintlayout/solver/ArrayRow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(variableStartA);
				GC.KeepAlive(variableEndA);
				GC.KeepAlive(variableStartB);
				GC.KeepAlive(variableEndB);
			}
		}

		private static Delegate GetCreateRowEquals_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IHandler()
		{
			if ((object)cb_createRowEquals_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I == null)
			{
				cb_createRowEquals_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_L(n_CreateRowEquals_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I));
			}
			return cb_createRowEquals_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I;
		}

		private static IntPtr n_CreateRowEquals_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I(IntPtr jnienv, IntPtr native__this, IntPtr native_variableA, IntPtr native_variableB, int margin)
		{
			ArrayRow arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableA = Java.Lang.Object.GetObject<SolverVariable>(native_variableA, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableB = Java.Lang.Object.GetObject<SolverVariable>(native_variableB, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayRow.CreateRowEquals(variableA, variableB, margin));
		}

		[Register("createRowEquals", "(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;I)Landroidx/constraintlayout/solver/ArrayRow;", "GetCreateRowEquals_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IHandler")]
		public unsafe virtual ArrayRow CreateRowEquals(SolverVariable variableA, SolverVariable variableB, int margin)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(variableA?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(variableB?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(margin);
				return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("createRowEquals.(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;I)Landroidx/constraintlayout/solver/ArrayRow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(variableA);
				GC.KeepAlive(variableB);
			}
		}

		private static Delegate GetCreateRowEquals_Landroidx_constraintlayout_solver_SolverVariable_IHandler()
		{
			if ((object)cb_createRowEquals_Landroidx_constraintlayout_solver_SolverVariable_I == null)
			{
				cb_createRowEquals_Landroidx_constraintlayout_solver_SolverVariable_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_L(n_CreateRowEquals_Landroidx_constraintlayout_solver_SolverVariable_I));
			}
			return cb_createRowEquals_Landroidx_constraintlayout_solver_SolverVariable_I;
		}

		private static IntPtr n_CreateRowEquals_Landroidx_constraintlayout_solver_SolverVariable_I(IntPtr jnienv, IntPtr native__this, IntPtr native_variable, int value)
		{
			ArrayRow arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable variable = Java.Lang.Object.GetObject<SolverVariable>(native_variable, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayRow.CreateRowEquals(variable, value));
		}

		[Register("createRowEquals", "(Landroidx/constraintlayout/solver/SolverVariable;I)Landroidx/constraintlayout/solver/ArrayRow;", "GetCreateRowEquals_Landroidx_constraintlayout_solver_SolverVariable_IHandler")]
		public unsafe virtual ArrayRow CreateRowEquals(SolverVariable variable, int value)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(variable?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(value);
				return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("createRowEquals.(Landroidx/constraintlayout/solver/SolverVariable;I)Landroidx/constraintlayout/solver/ArrayRow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(variable);
			}
		}

		private static Delegate GetCreateRowGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IHandler()
		{
			if ((object)cb_createRowGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I == null)
			{
				cb_createRowGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLI_L(n_CreateRowGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I));
			}
			return cb_createRowGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I;
		}

		private static IntPtr n_CreateRowGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I(IntPtr jnienv, IntPtr native__this, IntPtr native_variableA, IntPtr native_variableB, IntPtr native_slack, int margin)
		{
			ArrayRow arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableA = Java.Lang.Object.GetObject<SolverVariable>(native_variableA, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableB = Java.Lang.Object.GetObject<SolverVariable>(native_variableB, JniHandleOwnership.DoNotTransfer);
			SolverVariable slack = Java.Lang.Object.GetObject<SolverVariable>(native_slack, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayRow.CreateRowGreaterThan(variableA, variableB, slack, margin));
		}

		[Register("createRowGreaterThan", "(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;I)Landroidx/constraintlayout/solver/ArrayRow;", "GetCreateRowGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IHandler")]
		public unsafe virtual ArrayRow CreateRowGreaterThan(SolverVariable variableA, SolverVariable variableB, SolverVariable slack, int margin)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(variableA?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(variableB?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(slack?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(margin);
				return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("createRowGreaterThan.(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;I)Landroidx/constraintlayout/solver/ArrayRow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(variableA);
				GC.KeepAlive(variableB);
				GC.KeepAlive(slack);
			}
		}

		private static Delegate GetCreateRowGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_Handler()
		{
			if ((object)cb_createRowGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_ == null)
			{
				cb_createRowGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIL_L(n_CreateRowGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_));
			}
			return cb_createRowGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_;
		}

		private static IntPtr n_CreateRowGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_(IntPtr jnienv, IntPtr native__this, IntPtr native_a, int b, IntPtr native_slack)
		{
			ArrayRow arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable a = Java.Lang.Object.GetObject<SolverVariable>(native_a, JniHandleOwnership.DoNotTransfer);
			SolverVariable slack = Java.Lang.Object.GetObject<SolverVariable>(native_slack, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayRow.CreateRowGreaterThan(a, b, slack));
		}

		[Register("createRowGreaterThan", "(Landroidx/constraintlayout/solver/SolverVariable;ILandroidx/constraintlayout/solver/SolverVariable;)Landroidx/constraintlayout/solver/ArrayRow;", "GetCreateRowGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_ILandroidx_constraintlayout_solver_SolverVariable_Handler")]
		public unsafe virtual ArrayRow CreateRowGreaterThan(SolverVariable a, int b, SolverVariable slack)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(b);
				ptr[2] = new JniArgumentValue(slack?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("createRowGreaterThan.(Landroidx/constraintlayout/solver/SolverVariable;ILandroidx/constraintlayout/solver/SolverVariable;)Landroidx/constraintlayout/solver/ArrayRow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(a);
				GC.KeepAlive(slack);
			}
		}

		private static Delegate GetCreateRowLowerThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IHandler()
		{
			if ((object)cb_createRowLowerThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I == null)
			{
				cb_createRowLowerThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLI_L(n_CreateRowLowerThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I));
			}
			return cb_createRowLowerThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I;
		}

		private static IntPtr n_CreateRowLowerThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I(IntPtr jnienv, IntPtr native__this, IntPtr native_variableA, IntPtr native_variableB, IntPtr native_slack, int margin)
		{
			ArrayRow arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableA = Java.Lang.Object.GetObject<SolverVariable>(native_variableA, JniHandleOwnership.DoNotTransfer);
			SolverVariable variableB = Java.Lang.Object.GetObject<SolverVariable>(native_variableB, JniHandleOwnership.DoNotTransfer);
			SolverVariable slack = Java.Lang.Object.GetObject<SolverVariable>(native_slack, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayRow.CreateRowLowerThan(variableA, variableB, slack, margin));
		}

		[Register("createRowLowerThan", "(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;I)Landroidx/constraintlayout/solver/ArrayRow;", "GetCreateRowLowerThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IHandler")]
		public unsafe virtual ArrayRow CreateRowLowerThan(SolverVariable variableA, SolverVariable variableB, SolverVariable slack, int margin)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(variableA?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(variableB?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(slack?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(margin);
				return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("createRowLowerThan.(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;I)Landroidx/constraintlayout/solver/ArrayRow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(variableA);
				GC.KeepAlive(variableB);
				GC.KeepAlive(slack);
			}
		}

		private static Delegate GetCreateRowWithAngle_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_FHandler()
		{
			if ((object)cb_createRowWithAngle_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_F == null)
			{
				cb_createRowWithAngle_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_F = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLLF_L(n_CreateRowWithAngle_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_F));
			}
			return cb_createRowWithAngle_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_F;
		}

		private static IntPtr n_CreateRowWithAngle_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_F(IntPtr jnienv, IntPtr native__this, IntPtr native_at, IntPtr native_ab, IntPtr native_bt, IntPtr native_bb, float angleComponent)
		{
			ArrayRow arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable at = Java.Lang.Object.GetObject<SolverVariable>(native_at, JniHandleOwnership.DoNotTransfer);
			SolverVariable ab = Java.Lang.Object.GetObject<SolverVariable>(native_ab, JniHandleOwnership.DoNotTransfer);
			SolverVariable bt = Java.Lang.Object.GetObject<SolverVariable>(native_bt, JniHandleOwnership.DoNotTransfer);
			SolverVariable bb = Java.Lang.Object.GetObject<SolverVariable>(native_bb, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayRow.CreateRowWithAngle(at, ab, bt, bb, angleComponent));
		}

		[Register("createRowWithAngle", "(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;F)Landroidx/constraintlayout/solver/ArrayRow;", "GetCreateRowWithAngle_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_FHandler")]
		public unsafe virtual ArrayRow CreateRowWithAngle(SolverVariable at, SolverVariable ab, SolverVariable bt, SolverVariable bb, float angleComponent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(at?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(ab?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(bt?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(bb?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(angleComponent);
				return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("createRowWithAngle.(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;F)Landroidx/constraintlayout/solver/ArrayRow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(at);
				GC.KeepAlive(ab);
				GC.KeepAlive(bt);
				GC.KeepAlive(bb);
			}
		}

		private static Delegate GetGetPivotCandidate_Landroidx_constraintlayout_solver_LinearSystem_arrayZHandler()
		{
			if ((object)cb_getPivotCandidate_Landroidx_constraintlayout_solver_LinearSystem_arrayZ == null)
			{
				cb_getPivotCandidate_Landroidx_constraintlayout_solver_LinearSystem_arrayZ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_GetPivotCandidate_Landroidx_constraintlayout_solver_LinearSystem_arrayZ));
			}
			return cb_getPivotCandidate_Landroidx_constraintlayout_solver_LinearSystem_arrayZ;
		}

		private static IntPtr n_GetPivotCandidate_Landroidx_constraintlayout_solver_LinearSystem_arrayZ(IntPtr jnienv, IntPtr native__this, IntPtr native_system, IntPtr native_avoid)
		{
			ArrayRow arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			bool[] array = (bool[])JNIEnv.GetArray(native_avoid, JniHandleOwnership.DoNotTransfer, typeof(bool));
			IntPtr result = JNIEnv.ToLocalJniHandle(arrayRow.GetPivotCandidate(system, array));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_avoid);
			}
			return result;
		}

		[Register("getPivotCandidate", "(Landroidx/constraintlayout/solver/LinearSystem;[Z)Landroidx/constraintlayout/solver/SolverVariable;", "GetGetPivotCandidate_Landroidx_constraintlayout_solver_LinearSystem_arrayZHandler")]
		public unsafe virtual SolverVariable GetPivotCandidate(LinearSystem system, bool[] avoid)
		{
			IntPtr intPtr = JNIEnv.NewArray(avoid);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<SolverVariable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPivotCandidate.(Landroidx/constraintlayout/solver/LinearSystem;[Z)Landroidx/constraintlayout/solver/SolverVariable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (avoid != null)
				{
					JNIEnv.CopyArray(intPtr, avoid);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(system);
				GC.KeepAlive(avoid);
			}
		}

		private static Delegate GetPickPivot_Landroidx_constraintlayout_solver_SolverVariable_Handler()
		{
			if ((object)cb_pickPivot_Landroidx_constraintlayout_solver_SolverVariable_ == null)
			{
				cb_pickPivot_Landroidx_constraintlayout_solver_SolverVariable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_PickPivot_Landroidx_constraintlayout_solver_SolverVariable_));
			}
			return cb_pickPivot_Landroidx_constraintlayout_solver_SolverVariable_;
		}

		private static IntPtr n_PickPivot_Landroidx_constraintlayout_solver_SolverVariable_(IntPtr jnienv, IntPtr native__this, IntPtr native_exclude)
		{
			ArrayRow arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable exclude = Java.Lang.Object.GetObject<SolverVariable>(native_exclude, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(arrayRow.PickPivot(exclude));
		}

		[Register("pickPivot", "(Landroidx/constraintlayout/solver/SolverVariable;)Landroidx/constraintlayout/solver/SolverVariable;", "GetPickPivot_Landroidx_constraintlayout_solver_SolverVariable_Handler")]
		public unsafe virtual SolverVariable PickPivot(SolverVariable exclude)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(exclude?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<SolverVariable>(_members.InstanceMethods.InvokeVirtualObjectMethod("pickPivot.(Landroidx/constraintlayout/solver/SolverVariable;)Landroidx/constraintlayout/solver/SolverVariable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(exclude);
			}
		}

		private static Delegate GetResetHandler()
		{
			if ((object)cb_reset == null)
			{
				cb_reset = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Reset));
			}
			return cb_reset;
		}

		private static void n_Reset(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset();
		}

		[Register("reset", "()V", "GetResetHandler")]
		public unsafe virtual void Reset()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("reset.()V", this, null);
		}

		private static Delegate GetUpdateFromFinalVariable_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_ZHandler()
		{
			if ((object)cb_updateFromFinalVariable_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_Z == null)
			{
				cb_updateFromFinalVariable_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLZ_V(n_UpdateFromFinalVariable_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_Z));
			}
			return cb_updateFromFinalVariable_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_Z;
		}

		private static void n_UpdateFromFinalVariable_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_system, IntPtr native_variable, bool removeFromDefinition)
		{
			ArrayRow arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			SolverVariable variable = Java.Lang.Object.GetObject<SolverVariable>(native_variable, JniHandleOwnership.DoNotTransfer);
			arrayRow.UpdateFromFinalVariable(system, variable, removeFromDefinition);
		}

		[Register("updateFromFinalVariable", "(Landroidx/constraintlayout/solver/LinearSystem;Landroidx/constraintlayout/solver/SolverVariable;Z)V", "GetUpdateFromFinalVariable_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_ZHandler")]
		public unsafe virtual void UpdateFromFinalVariable(LinearSystem system, SolverVariable variable, bool removeFromDefinition)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(variable?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(removeFromDefinition);
				_members.InstanceMethods.InvokeVirtualVoidMethod("updateFromFinalVariable.(Landroidx/constraintlayout/solver/LinearSystem;Landroidx/constraintlayout/solver/SolverVariable;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(system);
				GC.KeepAlive(variable);
			}
		}

		private static Delegate GetUpdateFromRow_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_ArrayRow_ZHandler()
		{
			if ((object)cb_updateFromRow_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_ArrayRow_Z == null)
			{
				cb_updateFromRow_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_ArrayRow_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLZ_V(n_UpdateFromRow_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_ArrayRow_Z));
			}
			return cb_updateFromRow_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_ArrayRow_Z;
		}

		private static void n_UpdateFromRow_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_ArrayRow_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_system, IntPtr native_definition, bool removeFromDefinition)
		{
			ArrayRow arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			ArrayRow definition = Java.Lang.Object.GetObject<ArrayRow>(native_definition, JniHandleOwnership.DoNotTransfer);
			arrayRow.UpdateFromRow(system, definition, removeFromDefinition);
		}

		[Register("updateFromRow", "(Landroidx/constraintlayout/solver/LinearSystem;Landroidx/constraintlayout/solver/ArrayRow;Z)V", "GetUpdateFromRow_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_ArrayRow_ZHandler")]
		public unsafe virtual void UpdateFromRow(LinearSystem system, ArrayRow definition, bool removeFromDefinition)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(definition?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(removeFromDefinition);
				_members.InstanceMethods.InvokeVirtualVoidMethod("updateFromRow.(Landroidx/constraintlayout/solver/LinearSystem;Landroidx/constraintlayout/solver/ArrayRow;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(system);
				GC.KeepAlive(definition);
			}
		}

		private static Delegate GetUpdateFromSynonymVariable_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_ZHandler()
		{
			if ((object)cb_updateFromSynonymVariable_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_Z == null)
			{
				cb_updateFromSynonymVariable_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_Z = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLZ_V(n_UpdateFromSynonymVariable_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_Z));
			}
			return cb_updateFromSynonymVariable_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_Z;
		}

		private static void n_UpdateFromSynonymVariable_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_system, IntPtr native_variable, bool removeFromDefinition)
		{
			ArrayRow arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			SolverVariable variable = Java.Lang.Object.GetObject<SolverVariable>(native_variable, JniHandleOwnership.DoNotTransfer);
			arrayRow.UpdateFromSynonymVariable(system, variable, removeFromDefinition);
		}

		[Register("updateFromSynonymVariable", "(Landroidx/constraintlayout/solver/LinearSystem;Landroidx/constraintlayout/solver/SolverVariable;Z)V", "GetUpdateFromSynonymVariable_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_ZHandler")]
		public unsafe virtual void UpdateFromSynonymVariable(LinearSystem system, SolverVariable variable, bool removeFromDefinition)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(variable?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(removeFromDefinition);
				_members.InstanceMethods.InvokeVirtualVoidMethod("updateFromSynonymVariable.(Landroidx/constraintlayout/solver/LinearSystem;Landroidx/constraintlayout/solver/SolverVariable;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(system);
				GC.KeepAlive(variable);
			}
		}

		private static Delegate GetUpdateFromSystem_Landroidx_constraintlayout_solver_LinearSystem_Handler()
		{
			if ((object)cb_updateFromSystem_Landroidx_constraintlayout_solver_LinearSystem_ == null)
			{
				cb_updateFromSystem_Landroidx_constraintlayout_solver_LinearSystem_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UpdateFromSystem_Landroidx_constraintlayout_solver_LinearSystem_));
			}
			return cb_updateFromSystem_Landroidx_constraintlayout_solver_LinearSystem_;
		}

		private static void n_UpdateFromSystem_Landroidx_constraintlayout_solver_LinearSystem_(IntPtr jnienv, IntPtr native__this, IntPtr native_system)
		{
			ArrayRow arrayRow = Java.Lang.Object.GetObject<ArrayRow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			arrayRow.UpdateFromSystem(system);
		}

		[Register("updateFromSystem", "(Landroidx/constraintlayout/solver/LinearSystem;)V", "GetUpdateFromSystem_Landroidx_constraintlayout_solver_LinearSystem_Handler")]
		public unsafe virtual void UpdateFromSystem(LinearSystem system)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("updateFromSystem.(Landroidx/constraintlayout/solver/LinearSystem;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(system);
			}
		}
	}
	[Register("androidx/constraintlayout/solver/Cache", DoNotGenerateAcw = true)]
	public class Cache : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/Cache", typeof(Cache));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected Cache(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Cache()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}
	}
	[Register("androidx/constraintlayout/solver/LinearSystem", DoNotGenerateAcw = true)]
	public class LinearSystem : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/LinearSystem", typeof(LinearSystem));

		private static Delegate cb_getCache;

		private static Delegate cb_getMemoryUsed;

		private static Delegate cb_getNumEquations;

		private static Delegate cb_getNumVariables;

		private static Delegate cb_addCenterPoint_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_FI;

		private static Delegate cb_addCentering_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IFLandroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II;

		private static Delegate cb_addConstraint_Landroidx_constraintlayout_solver_ArrayRow_;

		private static Delegate cb_addEquality_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II;

		private static Delegate cb_addEquality_Landroidx_constraintlayout_solver_SolverVariable_I;

		private static Delegate cb_addGreaterBarrier_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IZ;

		private static Delegate cb_addGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II;

		private static Delegate cb_addLowerBarrier_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IZ;

		private static Delegate cb_addLowerThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II;

		private static Delegate cb_addRatio_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_FI;

		private static Delegate cb_addSynonym_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I;

		private static Delegate cb_createErrorVariable_ILjava_lang_String_;

		private static Delegate cb_createExtraVariable;

		private static Delegate cb_createObjectVariable_Ljava_lang_Object_;

		private static Delegate cb_createRow;

		private static Delegate cb_createSlackVariable;

		private static Delegate cb_displayReadableRows;

		private static Delegate cb_displayVariablesReadableRows;

		private static Delegate cb_fillMetrics_Landroidx_constraintlayout_solver_Metrics_;

		private static Delegate cb_getObjectVariableValue_Ljava_lang_Object_;

		private static Delegate cb_minimize;

		private static Delegate cb_removeRow_Landroidx_constraintlayout_solver_ArrayRow_;

		private static Delegate cb_reset;

		[Register("ARRAY_ROW_CREATION")]
		public static long ArrayRowCreation
		{
			get
			{
				return _members.StaticFields.GetInt64Value("ARRAY_ROW_CREATION.J");
			}
			set
			{
				_members.StaticFields.SetValue("ARRAY_ROW_CREATION.J", value);
			}
		}

		[Register("OPTIMIZED_ARRAY_ROW_CREATION")]
		public static long OptimizedArrayRowCreation
		{
			get
			{
				return _members.StaticFields.GetInt64Value("OPTIMIZED_ARRAY_ROW_CREATION.J");
			}
			set
			{
				_members.StaticFields.SetValue("OPTIMIZED_ARRAY_ROW_CREATION.J", value);
			}
		}

		[Register("OPTIMIZED_ENGINE")]
		public static bool OptimizedEngine
		{
			get
			{
				return _members.StaticFields.GetBooleanValue("OPTIMIZED_ENGINE.Z");
			}
			set
			{
				_members.StaticFields.SetValue("OPTIMIZED_ENGINE.Z", value);
			}
		}

		[Register("SIMPLIFY_SYNONYMS")]
		public static bool SimplifySynonyms
		{
			get
			{
				return _members.StaticFields.GetBooleanValue("SIMPLIFY_SYNONYMS.Z");
			}
			set
			{
				_members.StaticFields.SetValue("SIMPLIFY_SYNONYMS.Z", value);
			}
		}

		[Register("SKIP_COLUMNS")]
		public static bool SkipColumns
		{
			get
			{
				return _members.StaticFields.GetBooleanValue("SKIP_COLUMNS.Z");
			}
			set
			{
				_members.StaticFields.SetValue("SKIP_COLUMNS.Z", value);
			}
		}

		[Register("USE_BASIC_SYNONYMS")]
		public static bool UseBasicSynonyms
		{
			get
			{
				return _members.StaticFields.GetBooleanValue("USE_BASIC_SYNONYMS.Z");
			}
			set
			{
				_members.StaticFields.SetValue("USE_BASIC_SYNONYMS.Z", value);
			}
		}

		[Register("USE_DEPENDENCY_ORDERING")]
		public static bool UseDependencyOrdering
		{
			get
			{
				return _members.StaticFields.GetBooleanValue("USE_DEPENDENCY_ORDERING.Z");
			}
			set
			{
				_members.StaticFields.SetValue("USE_DEPENDENCY_ORDERING.Z", value);
			}
		}

		[Register("USE_SYNONYMS")]
		public static bool UseSynonyms
		{
			get
			{
				return _members.StaticFields.GetBooleanValue("USE_SYNONYMS.Z");
			}
			set
			{
				_members.StaticFields.SetValue("USE_SYNONYMS.Z", value);
			}
		}

		[Register("graphOptimizer")]
		public bool GraphOptimizer
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("graphOptimizer.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("graphOptimizer.Z", this, value);
			}
		}

		[Register("hasSimpleDefinition")]
		public bool HasSimpleDefinition
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("hasSimpleDefinition.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("hasSimpleDefinition.Z", this, value);
			}
		}

		[Register("newgraphOptimizer")]
		public bool NewgraphOptimizer
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("newgraphOptimizer.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("newgraphOptimizer.Z", this, value);
			}
		}

		[Register("sMetrics")]
		public static Metrics SMetrics
		{
			get
			{
				return Java.Lang.Object.GetObject<Metrics>(_members.StaticFields.GetObjectValue("sMetrics.Landroidx/constraintlayout/solver/Metrics;").Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.StaticFields.SetValue("sMetrics.Landroidx/constraintlayout/solver/Metrics;", new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual Cache Cache
		{
			[Register("getCache", "()Landroidx/constraintlayout/solver/Cache;", "GetGetCacheHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Cache>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCache.()Landroidx/constraintlayout/solver/Cache;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int MemoryUsed
		{
			[Register("getMemoryUsed", "()I", "GetGetMemoryUsedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getMemoryUsed.()I", this, null);
			}
		}

		public unsafe static Metrics Metrics
		{
			[Register("getMetrics", "()Landroidx/constraintlayout/solver/Metrics;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Metrics>(_members.StaticMethods.InvokeObjectMethod("getMetrics.()Landroidx/constraintlayout/solver/Metrics;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int NumEquations
		{
			[Register("getNumEquations", "()I", "GetGetNumEquationsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getNumEquations.()I", this, null);
			}
		}

		public unsafe virtual int NumVariables
		{
			[Register("getNumVariables", "()I", "GetGetNumVariablesHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getNumVariables.()I", this, null);
			}
		}

		protected LinearSystem(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe LinearSystem()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetCacheHandler()
		{
			if ((object)cb_getCache == null)
			{
				cb_getCache = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCache));
			}
			return cb_getCache;
		}

		private static IntPtr n_GetCache(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Cache);
		}

		private static Delegate GetGetMemoryUsedHandler()
		{
			if ((object)cb_getMemoryUsed == null)
			{
				cb_getMemoryUsed = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetMemoryUsed));
			}
			return cb_getMemoryUsed;
		}

		private static int n_GetMemoryUsed(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MemoryUsed;
		}

		private static Delegate GetGetNumEquationsHandler()
		{
			if ((object)cb_getNumEquations == null)
			{
				cb_getNumEquations = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetNumEquations));
			}
			return cb_getNumEquations;
		}

		private static int n_GetNumEquations(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NumEquations;
		}

		private static Delegate GetGetNumVariablesHandler()
		{
			if ((object)cb_getNumVariables == null)
			{
				cb_getNumVariables = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetNumVariables));
			}
			return cb_getNumVariables;
		}

		private static int n_GetNumVariables(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).NumVariables;
		}

		private static Delegate GetAddCenterPoint_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_FIHandler()
		{
			if ((object)cb_addCenterPoint_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_FI == null)
			{
				cb_addCenterPoint_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_FI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLFI_V(n_AddCenterPoint_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_FI));
			}
			return cb_addCenterPoint_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_FI;
		}

		private static void n_AddCenterPoint_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_FI(IntPtr jnienv, IntPtr native__this, IntPtr native_widget, IntPtr native_target, float angle, int radius)
		{
			LinearSystem linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget widget = Java.Lang.Object.GetObject<ConstraintWidget>(native_widget, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget target = Java.Lang.Object.GetObject<ConstraintWidget>(native_target, JniHandleOwnership.DoNotTransfer);
			linearSystem.AddCenterPoint(widget, target, angle, radius);
		}

		[Register("addCenterPoint", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Landroidx/constraintlayout/solver/widgets/ConstraintWidget;FI)V", "GetAddCenterPoint_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_FIHandler")]
		public unsafe virtual void AddCenterPoint(ConstraintWidget widget, ConstraintWidget target, float angle, int radius)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(angle);
				ptr[3] = new JniArgumentValue(radius);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addCenterPoint.(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Landroidx/constraintlayout/solver/widgets/ConstraintWidget;FI)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(widget);
				GC.KeepAlive(target);
			}
		}

		private static Delegate GetAddCentering_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IFLandroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IIHandler()
		{
			if ((object)cb_addCentering_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IFLandroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II == null)
			{
				cb_addCentering_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IFLandroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLIFLLII_V(n_AddCentering_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IFLandroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II));
			}
			return cb_addCentering_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IFLandroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II;
		}

		private static void n_AddCentering_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IFLandroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II(IntPtr jnienv, IntPtr native__this, IntPtr native_a, IntPtr native_b, int m1, float bias, IntPtr native_c, IntPtr native_d, int m2, int strength)
		{
			LinearSystem linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable a = Java.Lang.Object.GetObject<SolverVariable>(native_a, JniHandleOwnership.DoNotTransfer);
			SolverVariable b = Java.Lang.Object.GetObject<SolverVariable>(native_b, JniHandleOwnership.DoNotTransfer);
			SolverVariable c = Java.Lang.Object.GetObject<SolverVariable>(native_c, JniHandleOwnership.DoNotTransfer);
			SolverVariable d = Java.Lang.Object.GetObject<SolverVariable>(native_d, JniHandleOwnership.DoNotTransfer);
			linearSystem.AddCentering(a, b, m1, bias, c, d, m2, strength);
		}

		[Register("addCentering", "(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;IFLandroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;II)V", "GetAddCentering_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IFLandroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IIHandler")]
		public unsafe virtual void AddCentering(SolverVariable a, SolverVariable b, int m1, float bias, SolverVariable c, SolverVariable d, int m2, int strength)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
				*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(m1);
				ptr[3] = new JniArgumentValue(bias);
				ptr[4] = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
				ptr[5] = new JniArgumentValue(d?.Handle ?? IntPtr.Zero);
				ptr[6] = new JniArgumentValue(m2);
				ptr[7] = new JniArgumentValue(strength);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addCentering.(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;IFLandroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(a);
				GC.KeepAlive(b);
				GC.KeepAlive(c);
				GC.KeepAlive(d);
			}
		}

		private static Delegate GetAddConstraint_Landroidx_constraintlayout_solver_ArrayRow_Handler()
		{
			if ((object)cb_addConstraint_Landroidx_constraintlayout_solver_ArrayRow_ == null)
			{
				cb_addConstraint_Landroidx_constraintlayout_solver_ArrayRow_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddConstraint_Landroidx_constraintlayout_solver_ArrayRow_));
			}
			return cb_addConstraint_Landroidx_constraintlayout_solver_ArrayRow_;
		}

		private static void n_AddConstraint_Landroidx_constraintlayout_solver_ArrayRow_(IntPtr jnienv, IntPtr native__this, IntPtr native_row)
		{
			LinearSystem linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ArrayRow row = Java.Lang.Object.GetObject<ArrayRow>(native_row, JniHandleOwnership.DoNotTransfer);
			linearSystem.AddConstraint(row);
		}

		[Register("addConstraint", "(Landroidx/constraintlayout/solver/ArrayRow;)V", "GetAddConstraint_Landroidx_constraintlayout_solver_ArrayRow_Handler")]
		public unsafe virtual void AddConstraint(ArrayRow row)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addConstraint.(Landroidx/constraintlayout/solver/ArrayRow;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(row);
			}
		}

		private static Delegate GetAddEquality_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IIHandler()
		{
			if ((object)cb_addEquality_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II == null)
			{
				cb_addEquality_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLII_L(n_AddEquality_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II));
			}
			return cb_addEquality_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II;
		}

		private static IntPtr n_AddEquality_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II(IntPtr jnienv, IntPtr native__this, IntPtr native_a, IntPtr native_b, int margin, int strength)
		{
			LinearSystem linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable a = Java.Lang.Object.GetObject<SolverVariable>(native_a, JniHandleOwnership.DoNotTransfer);
			SolverVariable b = Java.Lang.Object.GetObject<SolverVariable>(native_b, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(linearSystem.AddEquality(a, b, margin, strength));
		}

		[Register("addEquality", "(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;II)Landroidx/constraintlayout/solver/ArrayRow;", "GetAddEquality_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IIHandler")]
		public unsafe virtual ArrayRow AddEquality(SolverVariable a, SolverVariable b, int margin, int strength)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(margin);
				ptr[3] = new JniArgumentValue(strength);
				return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("addEquality.(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;II)Landroidx/constraintlayout/solver/ArrayRow;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(a);
				GC.KeepAlive(b);
			}
		}

		private static Delegate GetAddEquality_Landroidx_constraintlayout_solver_SolverVariable_IHandler()
		{
			if ((object)cb_addEquality_Landroidx_constraintlayout_solver_SolverVariable_I == null)
			{
				cb_addEquality_Landroidx_constraintlayout_solver_SolverVariable_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_AddEquality_Landroidx_constraintlayout_solver_SolverVariable_I));
			}
			return cb_addEquality_Landroidx_constraintlayout_solver_SolverVariable_I;
		}

		private static void n_AddEquality_Landroidx_constraintlayout_solver_SolverVariable_I(IntPtr jnienv, IntPtr native__this, IntPtr native_a, int value)
		{
			LinearSystem linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable a = Java.Lang.Object.GetObject<SolverVariable>(native_a, JniHandleOwnership.DoNotTransfer);
			linearSystem.AddEquality(a, value);
		}

		[Register("addEquality", "(Landroidx/constraintlayout/solver/SolverVariable;I)V", "GetAddEquality_Landroidx_constraintlayout_solver_SolverVariable_IHandler")]
		public unsafe virtual void AddEquality(SolverVariable a, int value)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addEquality.(Landroidx/constraintlayout/solver/SolverVariable;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(a);
			}
		}

		private static Delegate GetAddGreaterBarrier_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IZHandler()
		{
			if ((object)cb_addGreaterBarrier_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IZ == null)
			{
				cb_addGreaterBarrier_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IZ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLIZ_V(n_AddGreaterBarrier_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IZ));
			}
			return cb_addGreaterBarrier_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IZ;
		}

		private static void n_AddGreaterBarrier_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IZ(IntPtr jnienv, IntPtr native__this, IntPtr native_a, IntPtr native_b, int margin, bool hasMatchConstraintWidgets)
		{
			LinearSystem linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable a = Java.Lang.Object.GetObject<SolverVariable>(native_a, JniHandleOwnership.DoNotTransfer);
			SolverVariable b = Java.Lang.Object.GetObject<SolverVariable>(native_b, JniHandleOwnership.DoNotTransfer);
			linearSystem.AddGreaterBarrier(a, b, margin, hasMatchConstraintWidgets);
		}

		[Register("addGreaterBarrier", "(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;IZ)V", "GetAddGreaterBarrier_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IZHandler")]
		public unsafe virtual void AddGreaterBarrier(SolverVariable a, SolverVariable b, int margin, bool hasMatchConstraintWidgets)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(margin);
				ptr[3] = new JniArgumentValue(hasMatchConstraintWidgets);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addGreaterBarrier.(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;IZ)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(a);
				GC.KeepAlive(b);
			}
		}

		private static Delegate GetAddGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IIHandler()
		{
			if ((object)cb_addGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II == null)
			{
				cb_addGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLII_V(n_AddGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II));
			}
			return cb_addGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II;
		}

		private static void n_AddGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II(IntPtr jnienv, IntPtr native__this, IntPtr native_a, IntPtr native_b, int margin, int strength)
		{
			LinearSystem linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable a = Java.Lang.Object.GetObject<SolverVariable>(native_a, JniHandleOwnership.DoNotTransfer);
			SolverVariable b = Java.Lang.Object.GetObject<SolverVariable>(native_b, JniHandleOwnership.DoNotTransfer);
			linearSystem.AddGreaterThan(a, b, margin, strength);
		}

		[Register("addGreaterThan", "(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;II)V", "GetAddGreaterThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IIHandler")]
		public unsafe virtual void AddGreaterThan(SolverVariable a, SolverVariable b, int margin, int strength)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(margin);
				ptr[3] = new JniArgumentValue(strength);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addGreaterThan.(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(a);
				GC.KeepAlive(b);
			}
		}

		private static Delegate GetAddLowerBarrier_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IZHandler()
		{
			if ((object)cb_addLowerBarrier_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IZ == null)
			{
				cb_addLowerBarrier_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IZ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLIZ_V(n_AddLowerBarrier_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IZ));
			}
			return cb_addLowerBarrier_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IZ;
		}

		private static void n_AddLowerBarrier_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IZ(IntPtr jnienv, IntPtr native__this, IntPtr native_a, IntPtr native_b, int margin, bool hasMatchConstraintWidgets)
		{
			LinearSystem linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable a = Java.Lang.Object.GetObject<SolverVariable>(native_a, JniHandleOwnership.DoNotTransfer);
			SolverVariable b = Java.Lang.Object.GetObject<SolverVariable>(native_b, JniHandleOwnership.DoNotTransfer);
			linearSystem.AddLowerBarrier(a, b, margin, hasMatchConstraintWidgets);
		}

		[Register("addLowerBarrier", "(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;IZ)V", "GetAddLowerBarrier_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IZHandler")]
		public unsafe virtual void AddLowerBarrier(SolverVariable a, SolverVariable b, int margin, bool hasMatchConstraintWidgets)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(margin);
				ptr[3] = new JniArgumentValue(hasMatchConstraintWidgets);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addLowerBarrier.(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;IZ)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(a);
				GC.KeepAlive(b);
			}
		}

		private static Delegate GetAddLowerThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IIHandler()
		{
			if ((object)cb_addLowerThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II == null)
			{
				cb_addLowerThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLII_V(n_AddLowerThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II));
			}
			return cb_addLowerThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II;
		}

		private static void n_AddLowerThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_II(IntPtr jnienv, IntPtr native__this, IntPtr native_a, IntPtr native_b, int margin, int strength)
		{
			LinearSystem linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable a = Java.Lang.Object.GetObject<SolverVariable>(native_a, JniHandleOwnership.DoNotTransfer);
			SolverVariable b = Java.Lang.Object.GetObject<SolverVariable>(native_b, JniHandleOwnership.DoNotTransfer);
			linearSystem.AddLowerThan(a, b, margin, strength);
		}

		[Register("addLowerThan", "(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;II)V", "GetAddLowerThan_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IIHandler")]
		public unsafe virtual void AddLowerThan(SolverVariable a, SolverVariable b, int margin, int strength)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(margin);
				ptr[3] = new JniArgumentValue(strength);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addLowerThan.(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(a);
				GC.KeepAlive(b);
			}
		}

		private static Delegate GetAddRatio_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_FIHandler()
		{
			if ((object)cb_addRatio_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_FI == null)
			{
				cb_addRatio_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_FI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLLFI_V(n_AddRatio_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_FI));
			}
			return cb_addRatio_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_FI;
		}

		private static void n_AddRatio_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_FI(IntPtr jnienv, IntPtr native__this, IntPtr native_a, IntPtr native_b, IntPtr native_c, IntPtr native_d, float ratio, int strength)
		{
			LinearSystem linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable a = Java.Lang.Object.GetObject<SolverVariable>(native_a, JniHandleOwnership.DoNotTransfer);
			SolverVariable b = Java.Lang.Object.GetObject<SolverVariable>(native_b, JniHandleOwnership.DoNotTransfer);
			SolverVariable c = Java.Lang.Object.GetObject<SolverVariable>(native_c, JniHandleOwnership.DoNotTransfer);
			SolverVariable d = Java.Lang.Object.GetObject<SolverVariable>(native_d, JniHandleOwnership.DoNotTransfer);
			linearSystem.AddRatio(a, b, c, d, ratio, strength);
		}

		[Register("addRatio", "(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;FI)V", "GetAddRatio_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_FIHandler")]
		public unsafe virtual void AddRatio(SolverVariable a, SolverVariable b, SolverVariable c, SolverVariable d, float ratio, int strength)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(c?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(d?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(ratio);
				ptr[5] = new JniArgumentValue(strength);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addRatio.(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;FI)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(a);
				GC.KeepAlive(b);
				GC.KeepAlive(c);
				GC.KeepAlive(d);
			}
		}

		private static Delegate GetAddSynonym_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IHandler()
		{
			if ((object)cb_addSynonym_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I == null)
			{
				cb_addSynonym_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_AddSynonym_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I));
			}
			return cb_addSynonym_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I;
		}

		private static void n_AddSynonym_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_I(IntPtr jnienv, IntPtr native__this, IntPtr native_a, IntPtr native_b, int margin)
		{
			LinearSystem linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			SolverVariable a = Java.Lang.Object.GetObject<SolverVariable>(native_a, JniHandleOwnership.DoNotTransfer);
			SolverVariable b = Java.Lang.Object.GetObject<SolverVariable>(native_b, JniHandleOwnership.DoNotTransfer);
			linearSystem.AddSynonym(a, b, margin);
		}

		[Register("addSynonym", "(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;I)V", "GetAddSynonym_Landroidx_constraintlayout_solver_SolverVariable_Landroidx_constraintlayout_solver_SolverVariable_IHandler")]
		public unsafe virtual void AddSynonym(SolverVariable a, SolverVariable b, int margin)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(a?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(b?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(margin);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addSynonym.(Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(a);
				GC.KeepAlive(b);
			}
		}

		private static Delegate GetCreateErrorVariable_ILjava_lang_String_Handler()
		{
			if ((object)cb_createErrorVariable_ILjava_lang_String_ == null)
			{
				cb_createErrorVariable_ILjava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_L(n_CreateErrorVariable_ILjava_lang_String_));
			}
			return cb_createErrorVariable_ILjava_lang_String_;
		}

		private static IntPtr n_CreateErrorVariable_ILjava_lang_String_(IntPtr jnienv, IntPtr native__this, int strength, IntPtr native_prefix)
		{
			LinearSystem linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string prefix = JNIEnv.GetString(native_prefix, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(linearSystem.CreateErrorVariable(strength, prefix));
		}

		[Register("createErrorVariable", "(ILjava/lang/String;)Landroidx/constraintlayout/solver/SolverVariable;", "GetCreateErrorVariable_ILjava_lang_String_Handler")]
		public unsafe virtual SolverVariable CreateErrorVariable(int strength, string prefix)
		{
			IntPtr intPtr = JNIEnv.NewString(prefix);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(strength);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<SolverVariable>(_members.InstanceMethods.InvokeVirtualObjectMethod("createErrorVariable.(ILjava/lang/String;)Landroidx/constraintlayout/solver/SolverVariable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetCreateExtraVariableHandler()
		{
			if ((object)cb_createExtraVariable == null)
			{
				cb_createExtraVariable = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CreateExtraVariable));
			}
			return cb_createExtraVariable;
		}

		private static IntPtr n_CreateExtraVariable(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateExtraVariable());
		}

		[Register("createExtraVariable", "()Landroidx/constraintlayout/solver/SolverVariable;", "GetCreateExtraVariableHandler")]
		public unsafe virtual SolverVariable CreateExtraVariable()
		{
			return Java.Lang.Object.GetObject<SolverVariable>(_members.InstanceMethods.InvokeVirtualObjectMethod("createExtraVariable.()Landroidx/constraintlayout/solver/SolverVariable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetCreateObjectVariable_Ljava_lang_Object_Handler()
		{
			if ((object)cb_createObjectVariable_Ljava_lang_Object_ == null)
			{
				cb_createObjectVariable_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_CreateObjectVariable_Ljava_lang_Object_));
			}
			return cb_createObjectVariable_Ljava_lang_Object_;
		}

		private static IntPtr n_CreateObjectVariable_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_anchor)
		{
			LinearSystem linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object anchor = Java.Lang.Object.GetObject<Java.Lang.Object>(native_anchor, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(linearSystem.CreateObjectVariable(anchor));
		}

		[Register("createObjectVariable", "(Ljava/lang/Object;)Landroidx/constraintlayout/solver/SolverVariable;", "GetCreateObjectVariable_Ljava_lang_Object_Handler")]
		public unsafe virtual SolverVariable CreateObjectVariable(Java.Lang.Object anchor)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(anchor?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<SolverVariable>(_members.InstanceMethods.InvokeVirtualObjectMethod("createObjectVariable.(Ljava/lang/Object;)Landroidx/constraintlayout/solver/SolverVariable;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(anchor);
			}
		}

		private static Delegate GetCreateRowHandler()
		{
			if ((object)cb_createRow == null)
			{
				cb_createRow = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CreateRow));
			}
			return cb_createRow;
		}

		private static IntPtr n_CreateRow(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateRow());
		}

		[Register("createRow", "()Landroidx/constraintlayout/solver/ArrayRow;", "GetCreateRowHandler")]
		public unsafe virtual ArrayRow CreateRow()
		{
			return Java.Lang.Object.GetObject<ArrayRow>(_members.InstanceMethods.InvokeVirtualObjectMethod("createRow.()Landroidx/constraintlayout/solver/ArrayRow;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("createRowDimensionPercent", "(Landroidx/constraintlayout/solver/LinearSystem;Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;F)Landroidx/constraintlayout/solver/ArrayRow;", "")]
		public unsafe static ArrayRow CreateRowDimensionPercent(LinearSystem linearSystem, SolverVariable variableA, SolverVariable variableC, float percent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(linearSystem?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(variableA?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(variableC?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(percent);
				return Java.Lang.Object.GetObject<ArrayRow>(_members.StaticMethods.InvokeObjectMethod("createRowDimensionPercent.(Landroidx/constraintlayout/solver/LinearSystem;Landroidx/constraintlayout/solver/SolverVariable;Landroidx/constraintlayout/solver/SolverVariable;F)Landroidx/constraintlayout/solver/ArrayRow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(linearSystem);
				GC.KeepAlive(variableA);
				GC.KeepAlive(variableC);
			}
		}

		private static Delegate GetCreateSlackVariableHandler()
		{
			if ((object)cb_createSlackVariable == null)
			{
				cb_createSlackVariable = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CreateSlackVariable));
			}
			return cb_createSlackVariable;
		}

		private static IntPtr n_CreateSlackVariable(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateSlackVariable());
		}

		[Register("createSlackVariable", "()Landroidx/constraintlayout/solver/SolverVariable;", "GetCreateSlackVariableHandler")]
		public unsafe virtual SolverVariable CreateSlackVariable()
		{
			return Java.Lang.Object.GetObject<SolverVariable>(_members.InstanceMethods.InvokeVirtualObjectMethod("createSlackVariable.()Landroidx/constraintlayout/solver/SolverVariable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetDisplayReadableRowsHandler()
		{
			if ((object)cb_displayReadableRows == null)
			{
				cb_displayReadableRows = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_DisplayReadableRows));
			}
			return cb_displayReadableRows;
		}

		private static void n_DisplayReadableRows(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisplayReadableRows();
		}

		[Register("displayReadableRows", "()V", "GetDisplayReadableRowsHandler")]
		public unsafe virtual void DisplayReadableRows()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("displayReadableRows.()V", this, null);
		}

		private static Delegate GetDisplayVariablesReadableRowsHandler()
		{
			if ((object)cb_displayVariablesReadableRows == null)
			{
				cb_displayVariablesReadableRows = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_DisplayVariablesReadableRows));
			}
			return cb_displayVariablesReadableRows;
		}

		private static void n_DisplayVariablesReadableRows(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DisplayVariablesReadableRows();
		}

		[Register("displayVariablesReadableRows", "()V", "GetDisplayVariablesReadableRowsHandler")]
		public unsafe virtual void DisplayVariablesReadableRows()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("displayVariablesReadableRows.()V", this, null);
		}

		private static Delegate GetFillMetrics_Landroidx_constraintlayout_solver_Metrics_Handler()
		{
			if ((object)cb_fillMetrics_Landroidx_constraintlayout_solver_Metrics_ == null)
			{
				cb_fillMetrics_Landroidx_constraintlayout_solver_Metrics_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_FillMetrics_Landroidx_constraintlayout_solver_Metrics_));
			}
			return cb_fillMetrics_Landroidx_constraintlayout_solver_Metrics_;
		}

		private static void n_FillMetrics_Landroidx_constraintlayout_solver_Metrics_(IntPtr jnienv, IntPtr native__this, IntPtr native_metrics)
		{
			LinearSystem linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Metrics metrics = Java.Lang.Object.GetObject<Metrics>(native_metrics, JniHandleOwnership.DoNotTransfer);
			linearSystem.FillMetrics(metrics);
		}

		[Register("fillMetrics", "(Landroidx/constraintlayout/solver/Metrics;)V", "GetFillMetrics_Landroidx_constraintlayout_solver_Metrics_Handler")]
		public unsafe virtual void FillMetrics(Metrics metrics)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(metrics?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("fillMetrics.(Landroidx/constraintlayout/solver/Metrics;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(metrics);
			}
		}

		private static Delegate GetGetObjectVariableValue_Ljava_lang_Object_Handler()
		{
			if ((object)cb_getObjectVariableValue_Ljava_lang_Object_ == null)
			{
				cb_getObjectVariableValue_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_GetObjectVariableValue_Ljava_lang_Object_));
			}
			return cb_getObjectVariableValue_Ljava_lang_Object_;
		}

		private static int n_GetObjectVariableValue_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			LinearSystem linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return linearSystem.GetObjectVariableValue(obj);
		}

		[Register("getObjectVariableValue", "(Ljava/lang/Object;)I", "GetGetObjectVariableValue_Ljava_lang_Object_Handler")]
		public unsafe virtual int GetObjectVariableValue(Java.Lang.Object obj)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("getObjectVariableValue.(Ljava/lang/Object;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}

		private static Delegate GetMinimizeHandler()
		{
			if ((object)cb_minimize == null)
			{
				cb_minimize = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Minimize));
			}
			return cb_minimize;
		}

		private static void n_Minimize(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Minimize();
		}

		[Register("minimize", "()V", "GetMinimizeHandler")]
		public unsafe virtual void Minimize()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("minimize.()V", this, null);
		}

		private static Delegate GetRemoveRow_Landroidx_constraintlayout_solver_ArrayRow_Handler()
		{
			if ((object)cb_removeRow_Landroidx_constraintlayout_solver_ArrayRow_ == null)
			{
				cb_removeRow_Landroidx_constraintlayout_solver_ArrayRow_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_RemoveRow_Landroidx_constraintlayout_solver_ArrayRow_));
			}
			return cb_removeRow_Landroidx_constraintlayout_solver_ArrayRow_;
		}

		private static void n_RemoveRow_Landroidx_constraintlayout_solver_ArrayRow_(IntPtr jnienv, IntPtr native__this, IntPtr native_row)
		{
			LinearSystem linearSystem = Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ArrayRow row = Java.Lang.Object.GetObject<ArrayRow>(native_row, JniHandleOwnership.DoNotTransfer);
			linearSystem.RemoveRow(row);
		}

		[Register("removeRow", "(Landroidx/constraintlayout/solver/ArrayRow;)V", "GetRemoveRow_Landroidx_constraintlayout_solver_ArrayRow_Handler")]
		public unsafe virtual void RemoveRow(ArrayRow row)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("removeRow.(Landroidx/constraintlayout/solver/ArrayRow;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(row);
			}
		}

		private static Delegate GetResetHandler()
		{
			if ((object)cb_reset == null)
			{
				cb_reset = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Reset));
			}
			return cb_reset;
		}

		private static void n_Reset(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<LinearSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset();
		}

		[Register("reset", "()V", "GetResetHandler")]
		public unsafe virtual void Reset()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("reset.()V", this, null);
		}
	}
	[Register("androidx/constraintlayout/solver/Metrics", DoNotGenerateAcw = true)]
	public class Metrics : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/Metrics", typeof(Metrics));

		private static Delegate cb_reset;

		[Register("additionalMeasures")]
		public long AdditionalMeasures
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("additionalMeasures.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("additionalMeasures.J", this, value);
			}
		}

		[Register("barrierConnectionResolved")]
		public long BarrierConnectionResolved
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("barrierConnectionResolved.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("barrierConnectionResolved.J", this, value);
			}
		}

		[Register("bfs")]
		public long Bfs
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("bfs.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("bfs.J", this, value);
			}
		}

		[Register("centerConnectionResolved")]
		public long CenterConnectionResolved
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("centerConnectionResolved.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("centerConnectionResolved.J", this, value);
			}
		}

		[Register("chainConnectionResolved")]
		public long ChainConnectionResolved
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("chainConnectionResolved.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("chainConnectionResolved.J", this, value);
			}
		}

		[Register("constraints")]
		public long Constraints
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("constraints.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("constraints.J", this, value);
			}
		}

		[Register("determineGroups")]
		public long DetermineGroups
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("determineGroups.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("determineGroups.J", this, value);
			}
		}

		[Register("errors")]
		public long Errors
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("errors.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("errors.J", this, value);
			}
		}

		[Register("extravariables")]
		public long Extravariables
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("extravariables.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("extravariables.J", this, value);
			}
		}

		[Register("fullySolved")]
		public long FullySolved
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("fullySolved.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("fullySolved.J", this, value);
			}
		}

		[Register("graphOptimizer")]
		public long GraphOptimizer
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("graphOptimizer.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("graphOptimizer.J", this, value);
			}
		}

		[Register("graphSolved")]
		public long GraphSolved
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("graphSolved.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("graphSolved.J", this, value);
			}
		}

		[Register("grouping")]
		public long Grouping
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("grouping.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("grouping.J", this, value);
			}
		}

		[Register("infeasibleDetermineGroups")]
		public long InfeasibleDetermineGroups
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("infeasibleDetermineGroups.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("infeasibleDetermineGroups.J", this, value);
			}
		}

		[Register("iterations")]
		public long Iterations
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("iterations.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("iterations.J", this, value);
			}
		}

		[Register("lastTableSize")]
		public long LastTableSize
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("lastTableSize.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("lastTableSize.J", this, value);
			}
		}

		[Register("layouts")]
		public long Layouts
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("layouts.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("layouts.J", this, value);
			}
		}

		[Register("linearSolved")]
		public long LinearSolved
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("linearSolved.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("linearSolved.J", this, value);
			}
		}

		[Register("matchConnectionResolved")]
		public long MatchConnectionResolved
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("matchConnectionResolved.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("matchConnectionResolved.J", this, value);
			}
		}

		[Register("maxRows")]
		public long MaxRows
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("maxRows.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("maxRows.J", this, value);
			}
		}

		[Register("maxTableSize")]
		public long MaxTableSize
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("maxTableSize.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("maxTableSize.J", this, value);
			}
		}

		[Register("maxVariables")]
		public long MaxVariables
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("maxVariables.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("maxVariables.J", this, value);
			}
		}

		[Register("measuredMatchWidgets")]
		public long MeasuredMatchWidgets
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("measuredMatchWidgets.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("measuredMatchWidgets.J", this, value);
			}
		}

		[Register("measuredWidgets")]
		public long MeasuredWidgets
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("measuredWidgets.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("measuredWidgets.J", this, value);
			}
		}

		[Register("measures")]
		public long Measures
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("measures.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("measures.J", this, value);
			}
		}

		[Register("measuresLayoutDuration")]
		public long MeasuresLayoutDuration
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("measuresLayoutDuration.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("measuresLayoutDuration.J", this, value);
			}
		}

		[Register("measuresWidgetsDuration")]
		public long MeasuresWidgetsDuration
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("measuresWidgetsDuration.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("measuresWidgetsDuration.J", this, value);
			}
		}

		[Register("measuresWrap")]
		public long MeasuresWrap
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("measuresWrap.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("measuresWrap.J", this, value);
			}
		}

		[Register("measuresWrapInfeasible")]
		public long MeasuresWrapInfeasible
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("measuresWrapInfeasible.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("measuresWrapInfeasible.J", this, value);
			}
		}

		[Register("minimize")]
		public long Minimize
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("minimize.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("minimize.J", this, value);
			}
		}

		[Register("minimizeGoal")]
		public long MinimizeGoal
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("minimizeGoal.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("minimizeGoal.J", this, value);
			}
		}

		[Register("nonresolvedWidgets")]
		public long NonresolvedWidgets
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("nonresolvedWidgets.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("nonresolvedWidgets.J", this, value);
			}
		}

		[Register("oldresolvedWidgets")]
		public long OldresolvedWidgets
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("oldresolvedWidgets.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("oldresolvedWidgets.J", this, value);
			}
		}

		[Register("optimize")]
		public long Optimize
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("optimize.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("optimize.J", this, value);
			}
		}

		[Register("pivots")]
		public long Pivots
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("pivots.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("pivots.J", this, value);
			}
		}

		[Register("problematicLayouts")]
		public System.Collections.IList ProblematicLayouts
		{
			get
			{
				return JavaList.FromJniHandle(_members.InstanceFields.GetObjectValue("problematicLayouts.Ljava/util/ArrayList;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JavaList.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("problematicLayouts.Ljava/util/ArrayList;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("resolutions")]
		public long Resolutions
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("resolutions.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("resolutions.J", this, value);
			}
		}

		[Register("resolvedWidgets")]
		public long ResolvedWidgets
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("resolvedWidgets.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("resolvedWidgets.J", this, value);
			}
		}

		[Register("simpleconstraints")]
		public long Simpleconstraints
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("simpleconstraints.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("simpleconstraints.J", this, value);
			}
		}

		[Register("slackvariables")]
		public long Slackvariables
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("slackvariables.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("slackvariables.J", this, value);
			}
		}

		[Register("tableSizeIncrease")]
		public long TableSizeIncrease
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("tableSizeIncrease.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("tableSizeIncrease.J", this, value);
			}
		}

		[Register("variables")]
		public long Variables
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("variables.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("variables.J", this, value);
			}
		}

		[Register("widgets")]
		public long Widgets
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("widgets.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("widgets.J", this, value);
			}
		}

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected Metrics(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Metrics()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetResetHandler()
		{
			if ((object)cb_reset == null)
			{
				cb_reset = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Reset));
			}
			return cb_reset;
		}

		private static void n_Reset(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Metrics>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset();
		}

		[Register("reset", "()V", "GetResetHandler")]
		public unsafe virtual void Reset()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("reset.()V", this, null);
		}
	}
	[Register("androidx/constraintlayout/solver/SolverVariable", DoNotGenerateAcw = true)]
	public class SolverVariable : Java.Lang.Object
	{
		[Register("androidx/constraintlayout/solver/SolverVariable$Type", DoNotGenerateAcw = true)]
		public sealed class Type : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/SolverVariable$Type", typeof(Type));

			[Register("CONSTANT")]
			public static Type Constant => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("CONSTANT.Landroidx/constraintlayout/solver/SolverVariable$Type;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("ERROR")]
			public static Type Error => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("ERROR.Landroidx/constraintlayout/solver/SolverVariable$Type;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("SLACK")]
			public static Type Slack => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("SLACK.Landroidx/constraintlayout/solver/SolverVariable$Type;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("UNKNOWN")]
			public static Type Unknown => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("UNKNOWN.Landroidx/constraintlayout/solver/SolverVariable$Type;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("UNRESTRICTED")]
			public static Type Unrestricted => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("UNRESTRICTED.Landroidx/constraintlayout/solver/SolverVariable$Type;").Handle, JniHandleOwnership.TransferLocalRef);

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override System.Type ThresholdType => _members.ManagedPeerType;

			internal Type(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Landroidx/constraintlayout/solver/SolverVariable$Type;", "")]
			public unsafe static Type ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Type>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/constraintlayout/solver/SolverVariable$Type;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Landroidx/constraintlayout/solver/SolverVariable$Type;", "")]
			public unsafe static Type[] Values()
			{
				return (Type[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/constraintlayout/solver/SolverVariable$Type;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Type));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/SolverVariable", typeof(SolverVariable));

		private static Delegate cb_getName;

		private static Delegate cb_setName_Ljava_lang_String_;

		private static Delegate cb_reset;

		private static Delegate cb_setFinalValue_Landroidx_constraintlayout_solver_LinearSystem_F;

		private static Delegate cb_setSynonym_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_F;

		private static Delegate cb_setType_Landroidx_constraintlayout_solver_SolverVariable_Type_Ljava_lang_String_;

		[Register("computedValue")]
		public float ComputedValue
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("computedValue.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("computedValue.F", this, value);
			}
		}

		[Register("id")]
		public int Id
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("id.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("id.I", this, value);
			}
		}

		[Register("inGoal")]
		public bool InGoal
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("inGoal.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("inGoal.Z", this, value);
			}
		}

		[Register("isFinalValue")]
		public bool IsFinalValue
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("isFinalValue.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("isFinalValue.Z", this, value);
			}
		}

		[Register("strength")]
		public int Strength
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("strength.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("strength.I", this, value);
			}
		}

		[Register("usageInRowCount")]
		public int UsageInRowCount
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("usageInRowCount.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("usageInRowCount.I", this, value);
			}
		}

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override System.Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual string Name
		{
			[Register("getName", "()Ljava/lang/String;", "GetGetNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setName", "(Ljava/lang/String;)V", "GetSetName_Ljava_lang_String_Handler")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setName.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		protected SolverVariable(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroidx/constraintlayout/solver/SolverVariable$Type;Ljava/lang/String;)V", "")]
		public unsafe SolverVariable(Type type, string prefix)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(prefix);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/solver/SolverVariable$Type;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/solver/SolverVariable$Type;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(type);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;Landroidx/constraintlayout/solver/SolverVariable$Type;)V", "")]
		public unsafe SolverVariable(string name, Type type)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Landroidx/constraintlayout/solver/SolverVariable$Type;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Landroidx/constraintlayout/solver/SolverVariable$Type;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(type);
			}
		}

		private static Delegate GetGetNameHandler()
		{
			if ((object)cb_getName == null)
			{
				cb_getName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetName));
			}
			return cb_getName;
		}

		private static IntPtr n_GetName(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<SolverVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name);
		}

		private static Delegate GetSetName_Ljava_lang_String_Handler()
		{
			if ((object)cb_setName_Ljava_lang_String_ == null)
			{
				cb_setName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetName_Ljava_lang_String_));
			}
			return cb_setName_Ljava_lang_String_;
		}

		private static void n_SetName_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_name)
		{
			SolverVariable solverVariable = Java.Lang.Object.GetObject<SolverVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			solverVariable.Name = name;
		}

		[Register("addToRow", "(Landroidx/constraintlayout/solver/ArrayRow;)V", "")]
		public unsafe void AddToRow(ArrayRow row)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("addToRow.(Landroidx/constraintlayout/solver/ArrayRow;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(row);
			}
		}

		[Register("removeFromRow", "(Landroidx/constraintlayout/solver/ArrayRow;)V", "")]
		public unsafe void RemoveFromRow(ArrayRow row)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(row?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("removeFromRow.(Landroidx/constraintlayout/solver/ArrayRow;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(row);
			}
		}

		private static Delegate GetResetHandler()
		{
			if ((object)cb_reset == null)
			{
				cb_reset = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Reset));
			}
			return cb_reset;
		}

		private static void n_Reset(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<SolverVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset();
		}

		[Register("reset", "()V", "GetResetHandler")]
		public unsafe virtual void Reset()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("reset.()V", this, null);
		}

		private static Delegate GetSetFinalValue_Landroidx_constraintlayout_solver_LinearSystem_FHandler()
		{
			if ((object)cb_setFinalValue_Landroidx_constraintlayout_solver_LinearSystem_F == null)
			{
				cb_setFinalValue_Landroidx_constraintlayout_solver_LinearSystem_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLF_V(n_SetFinalValue_Landroidx_constraintlayout_solver_LinearSystem_F));
			}
			return cb_setFinalValue_Landroidx_constraintlayout_solver_LinearSystem_F;
		}

		private static void n_SetFinalValue_Landroidx_constraintlayout_solver_LinearSystem_F(IntPtr jnienv, IntPtr native__this, IntPtr native_system, float value)
		{
			SolverVariable solverVariable = Java.Lang.Object.GetObject<SolverVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			solverVariable.SetFinalValue(system, value);
		}

		[Register("setFinalValue", "(Landroidx/constraintlayout/solver/LinearSystem;F)V", "GetSetFinalValue_Landroidx_constraintlayout_solver_LinearSystem_FHandler")]
		public unsafe virtual void SetFinalValue(LinearSystem system, float value)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setFinalValue.(Landroidx/constraintlayout/solver/LinearSystem;F)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(system);
			}
		}

		private static Delegate GetSetSynonym_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_FHandler()
		{
			if ((object)cb_setSynonym_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_F == null)
			{
				cb_setSynonym_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_F = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLF_V(n_SetSynonym_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_F));
			}
			return cb_setSynonym_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_F;
		}

		private static void n_SetSynonym_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_F(IntPtr jnienv, IntPtr native__this, IntPtr native_system, IntPtr native_synonymVariable, float value)
		{
			SolverVariable solverVariable = Java.Lang.Object.GetObject<SolverVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			SolverVariable synonymVariable = Java.Lang.Object.GetObject<SolverVariable>(native_synonymVariable, JniHandleOwnership.DoNotTransfer);
			solverVariable.SetSynonym(system, synonymVariable, value);
		}

		[Register("setSynonym", "(Landroidx/constraintlayout/solver/LinearSystem;Landroidx/constraintlayout/solver/SolverVariable;F)V", "GetSetSynonym_Landroidx_constraintlayout_solver_LinearSystem_Landroidx_constraintlayout_solver_SolverVariable_FHandler")]
		public unsafe virtual void SetSynonym(LinearSystem system, SolverVariable synonymVariable, float value)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(synonymVariable?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setSynonym.(Landroidx/constraintlayout/solver/LinearSystem;Landroidx/constraintlayout/solver/SolverVariable;F)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(system);
				GC.KeepAlive(synonymVariable);
			}
		}

		private static Delegate GetSetType_Landroidx_constraintlayout_solver_SolverVariable_Type_Ljava_lang_String_Handler()
		{
			if ((object)cb_setType_Landroidx_constraintlayout_solver_SolverVariable_Type_Ljava_lang_String_ == null)
			{
				cb_setType_Landroidx_constraintlayout_solver_SolverVariable_Type_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetType_Landroidx_constraintlayout_solver_SolverVariable_Type_Ljava_lang_String_));
			}
			return cb_setType_Landroidx_constraintlayout_solver_SolverVariable_Type_Ljava_lang_String_;
		}

		private static void n_SetType_Landroidx_constraintlayout_solver_SolverVariable_Type_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_type, IntPtr native_prefix)
		{
			SolverVariable solverVariable = Java.Lang.Object.GetObject<SolverVariable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Type type = Java.Lang.Object.GetObject<Type>(native_type, JniHandleOwnership.DoNotTransfer);
			string prefix = JNIEnv.GetString(native_prefix, JniHandleOwnership.DoNotTransfer);
			solverVariable.SetType(type, prefix);
		}

		[Register("setType", "(Landroidx/constraintlayout/solver/SolverVariable$Type;Ljava/lang/String;)V", "GetSetType_Landroidx_constraintlayout_solver_SolverVariable_Type_Ljava_lang_String_Handler")]
		public unsafe virtual void SetType(Type type, string prefix)
		{
			IntPtr intPtr = JNIEnv.NewString(prefix);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setType.(Landroidx/constraintlayout/solver/SolverVariable$Type;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(type);
			}
		}

		[Register("updateReferencesWithNewDefinition", "(Landroidx/constraintlayout/solver/LinearSystem;Landroidx/constraintlayout/solver/ArrayRow;)V", "")]
		public unsafe void UpdateReferencesWithNewDefinition(LinearSystem system, ArrayRow definition)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(definition?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("updateReferencesWithNewDefinition.(Landroidx/constraintlayout/solver/LinearSystem;Landroidx/constraintlayout/solver/ArrayRow;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(system);
				GC.KeepAlive(definition);
			}
		}
	}
}
namespace AndroidX.ConstraintLayout.Solver.Widgets
{
	[Register("androidx/constraintlayout/solver/widgets/ConstraintWidget", DoNotGenerateAcw = true)]
	public class ConstraintWidget : Java.Lang.Object
	{
		[Register("androidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour", DoNotGenerateAcw = true)]
		public sealed class DimensionBehaviour : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour", typeof(DimensionBehaviour));

			[Register("FIXED")]
			public static DimensionBehaviour Fixed => Java.Lang.Object.GetObject<DimensionBehaviour>(_members.StaticFields.GetObjectValue("FIXED.Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("MATCH_CONSTRAINT")]
			public static DimensionBehaviour MatchConstraint => Java.Lang.Object.GetObject<DimensionBehaviour>(_members.StaticFields.GetObjectValue("MATCH_CONSTRAINT.Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("MATCH_PARENT")]
			public static DimensionBehaviour MatchParent => Java.Lang.Object.GetObject<DimensionBehaviour>(_members.StaticFields.GetObjectValue("MATCH_PARENT.Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("WRAP_CONTENT")]
			public static DimensionBehaviour WrapContent => Java.Lang.Object.GetObject<DimensionBehaviour>(_members.StaticFields.GetObjectValue("WRAP_CONTENT.Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;").Handle, JniHandleOwnership.TransferLocalRef);

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			internal DimensionBehaviour(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;", "")]
			public unsafe static DimensionBehaviour ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<DimensionBehaviour>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;", "")]
			public unsafe static DimensionBehaviour[] Values()
			{
				return (DimensionBehaviour[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(DimensionBehaviour));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/widgets/ConstraintWidget", typeof(ConstraintWidget));

		private static Delegate cb_getAnchors;

		private static Delegate cb_getBaselineDistance;

		private static Delegate cb_setBaselineDistance_I;

		private static Delegate cb_getBottom;

		private static Delegate cb_getCompanionWidget;

		private static Delegate cb_setCompanionWidget_Ljava_lang_Object_;

		private static Delegate cb_getContainerItemSkip;

		private static Delegate cb_setContainerItemSkip_I;

		private static Delegate cb_getDebugName;

		private static Delegate cb_setDebugName_Ljava_lang_String_;

		private static Delegate cb_getDimensionRatio;

		private static Delegate cb_getDimensionRatioSide;

		private static Delegate cb_hasBaseline;

		private static Delegate cb_setHasBaseline_Z;

		private static Delegate cb_hasDependencies;

		private static Delegate cb_getHeight;

		private static Delegate cb_setHeight_I;

		private static Delegate cb_isHeightWrapContent;

		private static Delegate cb_setHeightWrapContent_Z;

		private static Delegate cb_getHorizontalBiasPercent;

		private static Delegate cb_setHorizontalBiasPercent_F;

		private static Delegate cb_getHorizontalChainControlWidget;

		private static Delegate cb_getHorizontalChainStyle;

		private static Delegate cb_setHorizontalChainStyle_I;

		private static Delegate cb_getHorizontalDimensionBehaviour;

		private static Delegate cb_setHorizontalDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_;

		private static Delegate cb_getHorizontalMargin;

		private static Delegate cb_isInPlaceholder;

		private static Delegate cb_setInPlaceholder_Z;

		private static Delegate cb_isInVirtualLayout;

		private static Delegate cb_setInVirtualLayout_Z;

		private static Delegate cb_isInHorizontalChain;

		private static Delegate cb_isInVerticalChain;

		private static Delegate cb_isResolvedHorizontally;

		private static Delegate cb_isResolvedVertically;

		private static Delegate cb_isRoot;

		private static Delegate cb_isSpreadHeight;

		private static Delegate cb_isSpreadWidth;

		private static Delegate cb_getLastHorizontalMeasureSpec;

		private static Delegate cb_getLastVerticalMeasureSpec;

		private static Delegate cb_getLeft;

		private static Delegate cb_getMaxHeight;

		private static Delegate cb_setMaxHeight_I;

		private static Delegate cb_getMaxWidth;

		private static Delegate cb_setMaxWidth_I;

		private static Delegate cb_isMeasureRequested;

		private static Delegate cb_setMeasureRequested_Z;

		private static Delegate cb_getMinHeight;

		private static Delegate cb_setMinHeight_I;

		private static Delegate cb_getMinWidth;

		private static Delegate cb_setMinWidth_I;

		private static Delegate cb_getOptimizerWrapHeight;

		private static Delegate cb_getOptimizerWrapWidth;

		private static Delegate cb_getParent;

		private static Delegate cb_setParent_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_;

		private static Delegate cb_getRight;

		private static Delegate cb_getRootX;

		private static Delegate cb_getRootY;

		private static Delegate cb_getTop;

		private static Delegate cb_getType;

		private static Delegate cb_setType_Ljava_lang_String_;

		private static Delegate cb_getVerticalBiasPercent;

		private static Delegate cb_setVerticalBiasPercent_F;

		private static Delegate cb_getVerticalChainControlWidget;

		private static Delegate cb_getVerticalChainStyle;

		private static Delegate cb_setVerticalChainStyle_I;

		private static Delegate cb_getVerticalDimensionBehaviour;

		private static Delegate cb_setVerticalDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_;

		private static Delegate cb_getVerticalMargin;

		private static Delegate cb_getVisibility;

		private static Delegate cb_setVisibility_I;

		private static Delegate cb_getWidth;

		private static Delegate cb_setWidth_I;

		private static Delegate cb_isWidthWrapContent;

		private static Delegate cb_setWidthWrapContent_Z;

		private static Delegate cb_addChildrenToSolverByDependency_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_solver_LinearSystem_Ljava_util_HashSet_IZ;

		private static Delegate cb_addToSolver_Landroidx_constraintlayout_solver_LinearSystem_Z;

		private static Delegate cb_allowedInBarrier;

		private static Delegate cb_connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_I;

		private static Delegate cb_connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_;

		private static Delegate cb_connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_I;

		private static Delegate cb_connectCircularConstraint_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_FI;

		private static Delegate cb_copy_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Ljava_util_HashMap_;

		private static Delegate cb_createObjectVariables_Landroidx_constraintlayout_solver_LinearSystem_;

		private static Delegate cb_ensureMeasureRequested;

		private static Delegate cb_ensureWidgetRuns;

		private static Delegate cb_getAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_;

		private static Delegate cb_getBiasPercent_I;

		private static Delegate cb_getDimensionBehaviour_I;

		private static Delegate cb_getLength_I;

		private static Delegate cb_getNextChainMember_I;

		private static Delegate cb_getPreviousChainMember_I;

		private static Delegate cb_getRun_I;

		private static Delegate cb_getX;

		private static Delegate cb_getY;

		private static Delegate cb_getHasBaseline;

		private static Delegate cb_hasDanglingDimension_I;

		private static Delegate cb_immediateConnect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_II;

		private static Delegate cb_oppositeDimensionDependsOn_I;

		private static Delegate cb_oppositeDimensionsTied;

		private static Delegate cb_reset;

		private static Delegate cb_resetAllConstraints;

		private static Delegate cb_resetAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_;

		private static Delegate cb_resetAnchors;

		private static Delegate cb_resetFinalResolution;

		private static Delegate cb_resetSolverVariables_Landroidx_constraintlayout_solver_Cache_;

		private static Delegate cb_setDebugSolverName_Landroidx_constraintlayout_solver_LinearSystem_Ljava_lang_String_;

		private static Delegate cb_setDimension_II;

		private static Delegate cb_setDimensionRatio_FI;

		private static Delegate cb_setDimensionRatio_Ljava_lang_String_;

		private static Delegate cb_setFinalBaseline_I;

		private static Delegate cb_setFinalFrame_IIIIII;

		private static Delegate cb_setFinalHorizontal_II;

		private static Delegate cb_setFinalLeft_I;

		private static Delegate cb_setFinalTop_I;

		private static Delegate cb_setFinalVertical_II;

		private static Delegate cb_setFrame_III;

		private static Delegate cb_setFrame_IIII;

		private static Delegate cb_setGoneMargin_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_I;

		private static Delegate cb_setHorizontalDimension_II;

		private static Delegate cb_setHorizontalMatchStyle_IIIF;

		private static Delegate cb_setHorizontalWeight_F;

		private static Delegate cb_setInBarrier_IZ;

		private static Delegate cb_setLastMeasureSpec_II;

		private static Delegate cb_setLength_II;

		private static Delegate cb_setOffset_II;

		private static Delegate cb_setOrigin_II;

		private static Delegate cb_setVerticalDimension_II;

		private static Delegate cb_setVerticalMatchStyle_IIIF;

		private static Delegate cb_setVerticalWeight_F;

		private static Delegate cb_setX_I;

		private static Delegate cb_setY_I;

		private static Delegate cb_setupDimensionRatio_ZZZZ;

		private static Delegate cb_updateFromRuns_ZZ;

		private static Delegate cb_updateFromSolver_Landroidx_constraintlayout_solver_LinearSystem_Z;

		protected IList<ConstraintWidget> MListNextVisibleWidget
		{
			get
			{
				return MNextChainWidget;
			}
			set
			{
				MNextChainWidget = value;
			}
		}

		[Register("DEFAULT_BIAS")]
		public static float DefaultBias
		{
			get
			{
				return _members.StaticFields.GetSingleValue("DEFAULT_BIAS.F");
			}
			set
			{
				_members.StaticFields.SetValue("DEFAULT_BIAS.F", value);
			}
		}

		[Register("horizontalChainRun")]
		public ChainRun HorizontalChainRun
		{
			get
			{
				return Java.Lang.Object.GetObject<ChainRun>(_members.InstanceFields.GetObjectValue("horizontalChainRun.Landroidx/constraintlayout/solver/widgets/analyzer/ChainRun;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("horizontalChainRun.Landroidx/constraintlayout/solver/widgets/analyzer/ChainRun;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("horizontalGroup")]
		public int HorizontalGroup
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("horizontalGroup.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("horizontalGroup.I", this, value);
			}
		}

		[Register("horizontalRun")]
		public HorizontalWidgetRun HorizontalRun
		{
			get
			{
				return Java.Lang.Object.GetObject<HorizontalWidgetRun>(_members.InstanceFields.GetObjectValue("horizontalRun.Landroidx/constraintlayout/solver/widgets/analyzer/HorizontalWidgetRun;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("horizontalRun.Landroidx/constraintlayout/solver/widgets/analyzer/HorizontalWidgetRun;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("isTerminalWidget")]
		public IList<bool> IsTerminalWidget
		{
			get
			{
				return Android.Runtime.JavaArray<bool>.FromJniHandle(_members.InstanceFields.GetObjectValue("isTerminalWidget.[Z", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = Android.Runtime.JavaArray<bool>.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("isTerminalWidget.[Z", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mAnchors")]
		protected System.Collections.IList MAnchors
		{
			get
			{
				return JavaList.FromJniHandle(_members.InstanceFields.GetObjectValue("mAnchors.Ljava/util/ArrayList;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JavaList.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mAnchors.Ljava/util/ArrayList;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mBaseline")]
		public ConstraintAnchor MBaseline
		{
			get
			{
				return Java.Lang.Object.GetObject<ConstraintAnchor>(_members.InstanceFields.GetObjectValue("mBaseline.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mBaseline.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mBottom")]
		public ConstraintAnchor MBottom
		{
			get
			{
				return Java.Lang.Object.GetObject<ConstraintAnchor>(_members.InstanceFields.GetObjectValue("mBottom.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mBottom.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mCenter")]
		public ConstraintAnchor MCenter
		{
			get
			{
				return Java.Lang.Object.GetObject<ConstraintAnchor>(_members.InstanceFields.GetObjectValue("mCenter.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mCenter.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mDimensionRatio")]
		public float MDimensionRatio
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("mDimensionRatio.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mDimensionRatio.F", this, value);
			}
		}

		[Register("mDimensionRatioSide")]
		protected int MDimensionRatioSide
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mDimensionRatioSide.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mDimensionRatioSide.I", this, value);
			}
		}

		[Register("mHorizontalResolution")]
		public int MHorizontalResolution
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mHorizontalResolution.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mHorizontalResolution.I", this, value);
			}
		}

		[Register("mIsHeightWrapContent")]
		public bool MIsHeightWrapContent
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("mIsHeightWrapContent.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mIsHeightWrapContent.Z", this, value);
			}
		}

		[Register("mIsWidthWrapContent")]
		public bool MIsWidthWrapContent
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("mIsWidthWrapContent.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mIsWidthWrapContent.Z", this, value);
			}
		}

		[Register("mLeft")]
		public ConstraintAnchor MLeft
		{
			get
			{
				return Java.Lang.Object.GetObject<ConstraintAnchor>(_members.InstanceFields.GetObjectValue("mLeft.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mLeft.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mListAnchors")]
		public IList<ConstraintAnchor> MListAnchors
		{
			get
			{
				return Android.Runtime.JavaArray<ConstraintAnchor>.FromJniHandle(_members.InstanceFields.GetObjectValue("mListAnchors.[Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = Android.Runtime.JavaArray<ConstraintAnchor>.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mListAnchors.[Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mListDimensionBehaviors")]
		public IList<DimensionBehaviour> MListDimensionBehaviors
		{
			get
			{
				return Android.Runtime.JavaArray<DimensionBehaviour>.FromJniHandle(_members.InstanceFields.GetObjectValue("mListDimensionBehaviors.[Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = Android.Runtime.JavaArray<DimensionBehaviour>.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mListDimensionBehaviors.[Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mListNextMatchConstraintsWidget")]
		protected IList<ConstraintWidget> MListNextMatchConstraintsWidget
		{
			get
			{
				return Android.Runtime.JavaArray<ConstraintWidget>.FromJniHandle(_members.InstanceFields.GetObjectValue("mListNextMatchConstraintsWidget.[Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = Android.Runtime.JavaArray<ConstraintWidget>.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mListNextMatchConstraintsWidget.[Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mMatchConstraintDefaultHeight")]
		public int MMatchConstraintDefaultHeight
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mMatchConstraintDefaultHeight.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mMatchConstraintDefaultHeight.I", this, value);
			}
		}

		[Register("mMatchConstraintDefaultWidth")]
		public int MMatchConstraintDefaultWidth
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mMatchConstraintDefaultWidth.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mMatchConstraintDefaultWidth.I", this, value);
			}
		}

		[Register("mMatchConstraintMaxHeight")]
		public int MMatchConstraintMaxHeight
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mMatchConstraintMaxHeight.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mMatchConstraintMaxHeight.I", this, value);
			}
		}

		[Register("mMatchConstraintMaxWidth")]
		public int MMatchConstraintMaxWidth
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mMatchConstraintMaxWidth.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mMatchConstraintMaxWidth.I", this, value);
			}
		}

		[Register("mMatchConstraintMinHeight")]
		public int MMatchConstraintMinHeight
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mMatchConstraintMinHeight.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mMatchConstraintMinHeight.I", this, value);
			}
		}

		[Register("mMatchConstraintMinWidth")]
		public int MMatchConstraintMinWidth
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mMatchConstraintMinWidth.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mMatchConstraintMinWidth.I", this, value);
			}
		}

		[Register("mMatchConstraintPercentHeight")]
		public float MMatchConstraintPercentHeight
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("mMatchConstraintPercentHeight.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mMatchConstraintPercentHeight.F", this, value);
			}
		}

		[Register("mMatchConstraintPercentWidth")]
		public float MMatchConstraintPercentWidth
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("mMatchConstraintPercentWidth.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mMatchConstraintPercentWidth.F", this, value);
			}
		}

		[Register("mMinHeight")]
		protected int MMinHeight
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mMinHeight.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mMinHeight.I", this, value);
			}
		}

		[Register("mMinWidth")]
		protected int MMinWidth
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mMinWidth.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mMinWidth.I", this, value);
			}
		}

		[Register("mNextChainWidget")]
		protected IList<ConstraintWidget> MNextChainWidget
		{
			get
			{
				return Android.Runtime.JavaArray<ConstraintWidget>.FromJniHandle(_members.InstanceFields.GetObjectValue("mNextChainWidget.[Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = Android.Runtime.JavaArray<ConstraintWidget>.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mNextChainWidget.[Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mOffsetX")]
		protected int MOffsetX
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mOffsetX.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mOffsetX.I", this, value);
			}
		}

		[Register("mOffsetY")]
		protected int MOffsetY
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mOffsetY.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mOffsetY.I", this, value);
			}
		}

		[Register("mParent")]
		public ConstraintWidget MParent
		{
			get
			{
				return Java.Lang.Object.GetObject<ConstraintWidget>(_members.InstanceFields.GetObjectValue("mParent.Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mParent.Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mResolvedMatchConstraintDefault")]
		public IList<int> MResolvedMatchConstraintDefault
		{
			get
			{
				return Android.Runtime.JavaArray<int>.FromJniHandle(_members.InstanceFields.GetObjectValue("mResolvedMatchConstraintDefault.[I", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = Android.Runtime.JavaArray<int>.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mResolvedMatchConstraintDefault.[I", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mRight")]
		public ConstraintAnchor MRight
		{
			get
			{
				return Java.Lang.Object.GetObject<ConstraintAnchor>(_members.InstanceFields.GetObjectValue("mRight.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mRight.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mTop")]
		public ConstraintAnchor MTop
		{
			get
			{
				return Java.Lang.Object.GetObject<ConstraintAnchor>(_members.InstanceFields.GetObjectValue("mTop.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mTop.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mVerticalResolution")]
		public int MVerticalResolution
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mVerticalResolution.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mVerticalResolution.I", this, value);
			}
		}

		[Register("mWeight")]
		public IList<float> MWeight
		{
			get
			{
				return Android.Runtime.JavaArray<float>.FromJniHandle(_members.InstanceFields.GetObjectValue("mWeight.[F", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = Android.Runtime.JavaArray<float>.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mWeight.[F", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mX")]
		protected int MX
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mX.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mX.I", this, value);
			}
		}

		[Register("mY")]
		protected int MY
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mY.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mY.I", this, value);
			}
		}

		[Register("measured")]
		public bool Measured
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("measured.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("measured.Z", this, value);
			}
		}

		[Register("run")]
		public IList<WidgetRun> Run
		{
			get
			{
				return Android.Runtime.JavaArray<WidgetRun>.FromJniHandle(_members.InstanceFields.GetObjectValue("run.[Landroidx/constraintlayout/solver/widgets/analyzer/WidgetRun;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = Android.Runtime.JavaArray<WidgetRun>.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("run.[Landroidx/constraintlayout/solver/widgets/analyzer/WidgetRun;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("verticalChainRun")]
		public ChainRun VerticalChainRun
		{
			get
			{
				return Java.Lang.Object.GetObject<ChainRun>(_members.InstanceFields.GetObjectValue("verticalChainRun.Landroidx/constraintlayout/solver/widgets/analyzer/ChainRun;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("verticalChainRun.Landroidx/constraintlayout/solver/widgets/analyzer/ChainRun;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("verticalGroup")]
		public int VerticalGroup
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("verticalGroup.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("verticalGroup.I", this, value);
			}
		}

		[Register("verticalRun")]
		public VerticalWidgetRun VerticalRun
		{
			get
			{
				return Java.Lang.Object.GetObject<VerticalWidgetRun>(_members.InstanceFields.GetObjectValue("verticalRun.Landroidx/constraintlayout/solver/widgets/analyzer/VerticalWidgetRun;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("verticalRun.Landroidx/constraintlayout/solver/widgets/analyzer/VerticalWidgetRun;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<ConstraintAnchor> Anchors
		{
			[Register("getAnchors", "()Ljava/util/ArrayList;", "GetGetAnchorsHandler")]
			get
			{
				return JavaList<ConstraintAnchor>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getAnchors.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int BaselineDistance
		{
			[Register("getBaselineDistance", "()I", "GetGetBaselineDistanceHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getBaselineDistance.()I", this, null);
			}
			[Register("setBaselineDistance", "(I)V", "GetSetBaselineDistance_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setBaselineDistance.(I)V", this, ptr);
			}
		}

		public unsafe virtual int Bottom
		{
			[Register("getBottom", "()I", "GetGetBottomHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getBottom.()I", this, null);
			}
		}

		public unsafe virtual Java.Lang.Object CompanionWidget
		{
			[Register("getCompanionWidget", "()Ljava/lang/Object;", "GetGetCompanionWidgetHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("getCompanionWidget.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setCompanionWidget", "(Ljava/lang/Object;)V", "GetSetCompanionWidget_Ljava_lang_Object_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setCompanionWidget.(Ljava/lang/Object;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe virtual int ContainerItemSkip
		{
			[Register("getContainerItemSkip", "()I", "GetGetContainerItemSkipHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getContainerItemSkip.()I", this, null);
			}
			[Register("setContainerItemSkip", "(I)V", "GetSetContainerItemSkip_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setContainerItemSkip.(I)V", this, ptr);
			}
		}

		public unsafe virtual string DebugName
		{
			[Register("getDebugName", "()Ljava/lang/String;", "GetGetDebugNameHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getDebugName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setDebugName", "(Ljava/lang/String;)V", "GetSetDebugName_Ljava_lang_String_Handler")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setDebugName.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe virtual float DimensionRatio
		{
			[Register("getDimensionRatio", "()F", "GetGetDimensionRatioHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getDimensionRatio.()F", this, null);
			}
		}

		public unsafe virtual int DimensionRatioSide
		{
			[Register("getDimensionRatioSide", "()I", "GetGetDimensionRatioSideHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getDimensionRatioSide.()I", this, null);
			}
		}

		public unsafe virtual bool HasBaseline
		{
			[Register("hasBaseline", "()Z", "GetHasBaselineHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasBaseline.()Z", this, null);
			}
			[Register("setHasBaseline", "(Z)V", "GetSetHasBaseline_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setHasBaseline.(Z)V", this, ptr);
			}
		}

		public unsafe virtual bool HasDependencies
		{
			[Register("hasDependencies", "()Z", "GetHasDependenciesHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasDependencies.()Z", this, null);
			}
		}

		public unsafe virtual int Height
		{
			[Register("getHeight", "()I", "GetGetHeightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getHeight.()I", this, null);
			}
			[Register("setHeight", "(I)V", "GetSetHeight_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setHeight.(I)V", this, ptr);
			}
		}

		public unsafe virtual bool HeightWrapContent
		{
			[Register("isHeightWrapContent", "()Z", "GetIsHeightWrapContentHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isHeightWrapContent.()Z", this, null);
			}
			[Register("setHeightWrapContent", "(Z)V", "GetSetHeightWrapContent_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setHeightWrapContent.(Z)V", this, ptr);
			}
		}

		public unsafe virtual float HorizontalBiasPercent
		{
			[Register("getHorizontalBiasPercent", "()F", "GetGetHorizontalBiasPercentHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getHorizontalBiasPercent.()F", this, null);
			}
			[Register("setHorizontalBiasPercent", "(F)V", "GetSetHorizontalBiasPercent_FHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalBiasPercent.(F)V", this, ptr);
			}
		}

		public unsafe virtual ConstraintWidget HorizontalChainControlWidget
		{
			[Register("getHorizontalChainControlWidget", "()Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", "GetGetHorizontalChainControlWidgetHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ConstraintWidget>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHorizontalChainControlWidget.()Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int HorizontalChainStyle
		{
			[Register("getHorizontalChainStyle", "()I", "GetGetHorizontalChainStyleHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getHorizontalChainStyle.()I", this, null);
			}
			[Register("setHorizontalChainStyle", "(I)V", "GetSetHorizontalChainStyle_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalChainStyle.(I)V", this, ptr);
			}
		}

		public unsafe virtual DimensionBehaviour HorizontalDimensionBehaviour
		{
			[Register("getHorizontalDimensionBehaviour", "()Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;", "GetGetHorizontalDimensionBehaviourHandler")]
			get
			{
				return Java.Lang.Object.GetObject<DimensionBehaviour>(_members.InstanceMethods.InvokeVirtualObjectMethod("getHorizontalDimensionBehaviour.()Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setHorizontalDimensionBehaviour", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;)V", "GetSetHorizontalDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalDimensionBehaviour.(Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe virtual int HorizontalMargin
		{
			[Register("getHorizontalMargin", "()I", "GetGetHorizontalMarginHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getHorizontalMargin.()I", this, null);
			}
		}

		public unsafe virtual bool InPlaceholder
		{
			[Register("isInPlaceholder", "()Z", "GetIsInPlaceholderHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isInPlaceholder.()Z", this, null);
			}
			[Register("setInPlaceholder", "(Z)V", "GetSetInPlaceholder_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setInPlaceholder.(Z)V", this, ptr);
			}
		}

		public unsafe virtual bool InVirtualLayout
		{
			[Register("isInVirtualLayout", "()Z", "GetIsInVirtualLayoutHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isInVirtualLayout.()Z", this, null);
			}
			[Register("setInVirtualLayout", "(Z)V", "GetSetInVirtualLayout_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setInVirtualLayout.(Z)V", this, ptr);
			}
		}

		public unsafe virtual bool IsInHorizontalChain
		{
			[Register("isInHorizontalChain", "()Z", "GetIsInHorizontalChainHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isInHorizontalChain.()Z", this, null);
			}
		}

		public unsafe virtual bool IsInVerticalChain
		{
			[Register("isInVerticalChain", "()Z", "GetIsInVerticalChainHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isInVerticalChain.()Z", this, null);
			}
		}

		public unsafe virtual bool IsResolvedHorizontally
		{
			[Register("isResolvedHorizontally", "()Z", "GetIsResolvedHorizontallyHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isResolvedHorizontally.()Z", this, null);
			}
		}

		public unsafe virtual bool IsResolvedVertically
		{
			[Register("isResolvedVertically", "()Z", "GetIsResolvedVerticallyHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isResolvedVertically.()Z", this, null);
			}
		}

		public unsafe virtual bool IsRoot
		{
			[Register("isRoot", "()Z", "GetIsRootHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isRoot.()Z", this, null);
			}
		}

		public unsafe virtual bool IsSpreadHeight
		{
			[Register("isSpreadHeight", "()Z", "GetIsSpreadHeightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSpreadHeight.()Z", this, null);
			}
		}

		public unsafe virtual bool IsSpreadWidth
		{
			[Register("isSpreadWidth", "()Z", "GetIsSpreadWidthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSpreadWidth.()Z", this, null);
			}
		}

		public unsafe virtual int LastHorizontalMeasureSpec
		{
			[Register("getLastHorizontalMeasureSpec", "()I", "GetGetLastHorizontalMeasureSpecHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getLastHorizontalMeasureSpec.()I", this, null);
			}
		}

		public unsafe virtual int LastVerticalMeasureSpec
		{
			[Register("getLastVerticalMeasureSpec", "()I", "GetGetLastVerticalMeasureSpecHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getLastVerticalMeasureSpec.()I", this, null);
			}
		}

		public unsafe virtual int Left
		{
			[Register("getLeft", "()I", "GetGetLeftHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getLeft.()I", this, null);
			}
		}

		public unsafe virtual int MaxHeight
		{
			[Register("getMaxHeight", "()I", "GetGetMaxHeightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxHeight.()I", this, null);
			}
			[Register("setMaxHeight", "(I)V", "GetSetMaxHeight_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxHeight.(I)V", this, ptr);
			}
		}

		public unsafe virtual int MaxWidth
		{
			[Register("getMaxWidth", "()I", "GetGetMaxWidthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getMaxWidth.()I", this, null);
			}
			[Register("setMaxWidth", "(I)V", "GetSetMaxWidth_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMaxWidth.(I)V", this, ptr);
			}
		}

		public unsafe virtual bool MeasureRequested
		{
			[Register("isMeasureRequested", "()Z", "GetIsMeasureRequestedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isMeasureRequested.()Z", this, null);
			}
			[Register("setMeasureRequested", "(Z)V", "GetSetMeasureRequested_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMeasureRequested.(Z)V", this, ptr);
			}
		}

		public unsafe virtual int MinHeight
		{
			[Register("getMinHeight", "()I", "GetGetMinHeightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getMinHeight.()I", this, null);
			}
			[Register("setMinHeight", "(I)V", "GetSetMinHeight_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMinHeight.(I)V", this, ptr);
			}
		}

		public unsafe virtual int MinWidth
		{
			[Register("getMinWidth", "()I", "GetGetMinWidthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getMinWidth.()I", this, null);
			}
			[Register("setMinWidth", "(I)V", "GetSetMinWidth_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMinWidth.(I)V", this, ptr);
			}
		}

		public unsafe virtual int OptimizerWrapHeight
		{
			[Register("getOptimizerWrapHeight", "()I", "GetGetOptimizerWrapHeightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getOptimizerWrapHeight.()I", this, null);
			}
		}

		public unsafe virtual int OptimizerWrapWidth
		{
			[Register("getOptimizerWrapWidth", "()I", "GetGetOptimizerWrapWidthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getOptimizerWrapWidth.()I", this, null);
			}
		}

		public unsafe virtual ConstraintWidget Parent
		{
			[Register("getParent", "()Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", "GetGetParentHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ConstraintWidget>(_members.InstanceMethods.InvokeVirtualObjectMethod("getParent.()Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setParent", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)V", "GetSetParent_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setParent.(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe virtual int Right
		{
			[Register("getRight", "()I", "GetGetRightHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getRight.()I", this, null);
			}
		}

		protected unsafe virtual int RootX
		{
			[Register("getRootX", "()I", "GetGetRootXHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getRootX.()I", this, null);
			}
		}

		protected unsafe virtual int RootY
		{
			[Register("getRootY", "()I", "GetGetRootYHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getRootY.()I", this, null);
			}
		}

		public unsafe virtual int Top
		{
			[Register("getTop", "()I", "GetGetTopHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getTop.()I", this, null);
			}
		}

		public unsafe virtual string Type
		{
			[Register("getType", "()Ljava/lang/String;", "GetGetTypeHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getType.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setType", "(Ljava/lang/String;)V", "GetSetType_Ljava_lang_String_Handler")]
			set
			{
				IntPtr intPtr = JNIEnv.NewString(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setType.(Ljava/lang/String;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		public unsafe virtual float VerticalBiasPercent
		{
			[Register("getVerticalBiasPercent", "()F", "GetGetVerticalBiasPercentHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getVerticalBiasPercent.()F", this, null);
			}
			[Register("setVerticalBiasPercent", "(F)V", "GetSetVerticalBiasPercent_FHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalBiasPercent.(F)V", this, ptr);
			}
		}

		public unsafe virtual ConstraintWidget VerticalChainControlWidget
		{
			[Register("getVerticalChainControlWidget", "()Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", "GetGetVerticalChainControlWidgetHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ConstraintWidget>(_members.InstanceMethods.InvokeVirtualObjectMethod("getVerticalChainControlWidget.()Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int VerticalChainStyle
		{
			[Register("getVerticalChainStyle", "()I", "GetGetVerticalChainStyleHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getVerticalChainStyle.()I", this, null);
			}
			[Register("setVerticalChainStyle", "(I)V", "GetSetVerticalChainStyle_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalChainStyle.(I)V", this, ptr);
			}
		}

		public unsafe virtual DimensionBehaviour VerticalDimensionBehaviour
		{
			[Register("getVerticalDimensionBehaviour", "()Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;", "GetGetVerticalDimensionBehaviourHandler")]
			get
			{
				return Java.Lang.Object.GetObject<DimensionBehaviour>(_members.InstanceMethods.InvokeVirtualObjectMethod("getVerticalDimensionBehaviour.()Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setVerticalDimensionBehaviour", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;)V", "GetSetVerticalDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalDimensionBehaviour.(Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe virtual int VerticalMargin
		{
			[Register("getVerticalMargin", "()I", "GetGetVerticalMarginHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getVerticalMargin.()I", this, null);
			}
		}

		public unsafe virtual int Visibility
		{
			[Register("getVisibility", "()I", "GetGetVisibilityHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getVisibility.()I", this, null);
			}
			[Register("setVisibility", "(I)V", "GetSetVisibility_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setVisibility.(I)V", this, ptr);
			}
		}

		public unsafe virtual int Width
		{
			[Register("getWidth", "()I", "GetGetWidthHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getWidth.()I", this, null);
			}
			[Register("setWidth", "(I)V", "GetSetWidth_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setWidth.(I)V", this, ptr);
			}
		}

		public unsafe virtual bool WidthWrapContent
		{
			[Register("isWidthWrapContent", "()Z", "GetIsWidthWrapContentHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isWidthWrapContent.()Z", this, null);
			}
			[Register("setWidthWrapContent", "(Z)V", "GetSetWidthWrapContent_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setWidthWrapContent.(Z)V", this, ptr);
			}
		}

		protected ConstraintWidget(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ConstraintWidget()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(II)V", "")]
		public unsafe ConstraintWidget(int width, int height)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(width);
				ptr[1] = new JniArgumentValue(height);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
			}
		}

		[Register(".ctor", "(IIII)V", "")]
		public unsafe ConstraintWidget(int x, int y, int width, int height)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(x);
				ptr[1] = new JniArgumentValue(y);
				ptr[2] = new JniArgumentValue(width);
				ptr[3] = new JniArgumentValue(height);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(IIII)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(IIII)V", this, ptr);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe ConstraintWidget(string debugName)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(debugName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;II)V", "")]
		public unsafe ConstraintWidget(string debugName, int width, int height)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(debugName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(width);
				ptr[2] = new JniArgumentValue(height);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;II)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;IIII)V", "")]
		public unsafe ConstraintWidget(string debugName, int x, int y, int width, int height)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(debugName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(x);
				ptr[2] = new JniArgumentValue(y);
				ptr[3] = new JniArgumentValue(width);
				ptr[4] = new JniArgumentValue(height);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;IIII)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;IIII)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetGetAnchorsHandler()
		{
			if ((object)cb_getAnchors == null)
			{
				cb_getAnchors = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAnchors));
			}
			return cb_getAnchors;
		}

		private static IntPtr n_GetAnchors(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList<ConstraintAnchor>.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Anchors);
		}

		private static Delegate GetGetBaselineDistanceHandler()
		{
			if ((object)cb_getBaselineDistance == null)
			{
				cb_getBaselineDistance = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetBaselineDistance));
			}
			return cb_getBaselineDistance;
		}

		private static int n_GetBaselineDistance(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BaselineDistance;
		}

		private static Delegate GetSetBaselineDistance_IHandler()
		{
			if ((object)cb_setBaselineDistance_I == null)
			{
				cb_setBaselineDistance_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetBaselineDistance_I));
			}
			return cb_setBaselineDistance_I;
		}

		private static void n_SetBaselineDistance_I(IntPtr jnienv, IntPtr native__this, int baseline)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BaselineDistance = baseline;
		}

		private static Delegate GetGetBottomHandler()
		{
			if ((object)cb_getBottom == null)
			{
				cb_getBottom = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetBottom));
			}
			return cb_getBottom;
		}

		private static int n_GetBottom(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Bottom;
		}

		private static Delegate GetGetCompanionWidgetHandler()
		{
			if ((object)cb_getCompanionWidget == null)
			{
				cb_getCompanionWidget = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCompanionWidget));
			}
			return cb_getCompanionWidget;
		}

		private static IntPtr n_GetCompanionWidget(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CompanionWidget);
		}

		private static Delegate GetSetCompanionWidget_Ljava_lang_Object_Handler()
		{
			if ((object)cb_setCompanionWidget_Ljava_lang_Object_ == null)
			{
				cb_setCompanionWidget_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetCompanionWidget_Ljava_lang_Object_));
			}
			return cb_setCompanionWidget_Ljava_lang_Object_;
		}

		private static void n_SetCompanionWidget_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_companion)
		{
			ConstraintWidget constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object companionWidget = Java.Lang.Object.GetObject<Java.Lang.Object>(native_companion, JniHandleOwnership.DoNotTransfer);
			constraintWidget.CompanionWidget = companionWidget;
		}

		private static Delegate GetGetContainerItemSkipHandler()
		{
			if ((object)cb_getContainerItemSkip == null)
			{
				cb_getContainerItemSkip = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetContainerItemSkip));
			}
			return cb_getContainerItemSkip;
		}

		private static int n_GetContainerItemSkip(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContainerItemSkip;
		}

		private static Delegate GetSetContainerItemSkip_IHandler()
		{
			if ((object)cb_setContainerItemSkip_I == null)
			{
				cb_setContainerItemSkip_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetContainerItemSkip_I));
			}
			return cb_setContainerItemSkip_I;
		}

		private static void n_SetContainerItemSkip_I(IntPtr jnienv, IntPtr native__this, int skip)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContainerItemSkip = skip;
		}

		private static Delegate GetGetDebugNameHandler()
		{
			if ((object)cb_getDebugName == null)
			{
				cb_getDebugName = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDebugName));
			}
			return cb_getDebugName;
		}

		private static IntPtr n_GetDebugName(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DebugName);
		}

		private static Delegate GetSetDebugName_Ljava_lang_String_Handler()
		{
			if ((object)cb_setDebugName_Ljava_lang_String_ == null)
			{
				cb_setDebugName_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetDebugName_Ljava_lang_String_));
			}
			return cb_setDebugName_Ljava_lang_String_;
		}

		private static void n_SetDebugName_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_name)
		{
			ConstraintWidget constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string debugName = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			constraintWidget.DebugName = debugName;
		}

		private static Delegate GetGetDimensionRatioHandler()
		{
			if ((object)cb_getDimensionRatio == null)
			{
				cb_getDimensionRatio = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetDimensionRatio));
			}
			return cb_getDimensionRatio;
		}

		private static float n_GetDimensionRatio(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DimensionRatio;
		}

		private static Delegate GetGetDimensionRatioSideHandler()
		{
			if ((object)cb_getDimensionRatioSide == null)
			{
				cb_getDimensionRatioSide = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetDimensionRatioSide));
			}
			return cb_getDimensionRatioSide;
		}

		private static int n_GetDimensionRatioSide(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DimensionRatioSide;
		}

		private static Delegate GetHasBaselineHandler()
		{
			if ((object)cb_hasBaseline == null)
			{
				cb_hasBaseline = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasBaseline));
			}
			return cb_hasBaseline;
		}

		private static bool n_HasBaseline(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasBaseline;
		}

		private static Delegate GetSetHasBaseline_ZHandler()
		{
			if ((object)cb_setHasBaseline_Z == null)
			{
				cb_setHasBaseline_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetHasBaseline_Z));
			}
			return cb_setHasBaseline_Z;
		}

		private static void n_SetHasBaseline_Z(IntPtr jnienv, IntPtr native__this, bool hasBaseline)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasBaseline = hasBaseline;
		}

		private static Delegate GetHasDependenciesHandler()
		{
			if ((object)cb_hasDependencies == null)
			{
				cb_hasDependencies = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasDependencies));
			}
			return cb_hasDependencies;
		}

		private static bool n_HasDependencies(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasDependencies;
		}

		private static Delegate GetGetHeightHandler()
		{
			if ((object)cb_getHeight == null)
			{
				cb_getHeight = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHeight));
			}
			return cb_getHeight;
		}

		private static int n_GetHeight(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Height;
		}

		private static Delegate GetSetHeight_IHandler()
		{
			if ((object)cb_setHeight_I == null)
			{
				cb_setHeight_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetHeight_I));
			}
			return cb_setHeight_I;
		}

		private static void n_SetHeight_I(IntPtr jnienv, IntPtr native__this, int h)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Height = h;
		}

		private static Delegate GetIsHeightWrapContentHandler()
		{
			if ((object)cb_isHeightWrapContent == null)
			{
				cb_isHeightWrapContent = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsHeightWrapContent));
			}
			return cb_isHeightWrapContent;
		}

		private static bool n_IsHeightWrapContent(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HeightWrapContent;
		}

		private static Delegate GetSetHeightWrapContent_ZHandler()
		{
			if ((object)cb_setHeightWrapContent_Z == null)
			{
				cb_setHeightWrapContent_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetHeightWrapContent_Z));
			}
			return cb_setHeightWrapContent_Z;
		}

		private static void n_SetHeightWrapContent_Z(IntPtr jnienv, IntPtr native__this, bool heightWrapContent)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HeightWrapContent = heightWrapContent;
		}

		private static Delegate GetGetHorizontalBiasPercentHandler()
		{
			if ((object)cb_getHorizontalBiasPercent == null)
			{
				cb_getHorizontalBiasPercent = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetHorizontalBiasPercent));
			}
			return cb_getHorizontalBiasPercent;
		}

		private static float n_GetHorizontalBiasPercent(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalBiasPercent;
		}

		private static Delegate GetSetHorizontalBiasPercent_FHandler()
		{
			if ((object)cb_setHorizontalBiasPercent_F == null)
			{
				cb_setHorizontalBiasPercent_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetHorizontalBiasPercent_F));
			}
			return cb_setHorizontalBiasPercent_F;
		}

		private static void n_SetHorizontalBiasPercent_F(IntPtr jnienv, IntPtr native__this, float horizontalBiasPercent)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalBiasPercent = horizontalBiasPercent;
		}

		private static Delegate GetGetHorizontalChainControlWidgetHandler()
		{
			if ((object)cb_getHorizontalChainControlWidget == null)
			{
				cb_getHorizontalChainControlWidget = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetHorizontalChainControlWidget));
			}
			return cb_getHorizontalChainControlWidget;
		}

		private static IntPtr n_GetHorizontalChainControlWidget(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalChainControlWidget);
		}

		private static Delegate GetGetHorizontalChainStyleHandler()
		{
			if ((object)cb_getHorizontalChainStyle == null)
			{
				cb_getHorizontalChainStyle = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHorizontalChainStyle));
			}
			return cb_getHorizontalChainStyle;
		}

		private static int n_GetHorizontalChainStyle(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalChainStyle;
		}

		private static Delegate GetSetHorizontalChainStyle_IHandler()
		{
			if ((object)cb_setHorizontalChainStyle_I == null)
			{
				cb_setHorizontalChainStyle_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetHorizontalChainStyle_I));
			}
			return cb_setHorizontalChainStyle_I;
		}

		private static void n_SetHorizontalChainStyle_I(IntPtr jnienv, IntPtr native__this, int horizontalChainStyle)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalChainStyle = horizontalChainStyle;
		}

		private static Delegate GetGetHorizontalDimensionBehaviourHandler()
		{
			if ((object)cb_getHorizontalDimensionBehaviour == null)
			{
				cb_getHorizontalDimensionBehaviour = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetHorizontalDimensionBehaviour));
			}
			return cb_getHorizontalDimensionBehaviour;
		}

		private static IntPtr n_GetHorizontalDimensionBehaviour(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalDimensionBehaviour);
		}

		private static Delegate GetSetHorizontalDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_Handler()
		{
			if ((object)cb_setHorizontalDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_ == null)
			{
				cb_setHorizontalDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetHorizontalDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_));
			}
			return cb_setHorizontalDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_;
		}

		private static void n_SetHorizontalDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_(IntPtr jnienv, IntPtr native__this, IntPtr native_behaviour)
		{
			ConstraintWidget constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DimensionBehaviour horizontalDimensionBehaviour = Java.Lang.Object.GetObject<DimensionBehaviour>(native_behaviour, JniHandleOwnership.DoNotTransfer);
			constraintWidget.HorizontalDimensionBehaviour = horizontalDimensionBehaviour;
		}

		private static Delegate GetGetHorizontalMarginHandler()
		{
			if ((object)cb_getHorizontalMargin == null)
			{
				cb_getHorizontalMargin = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHorizontalMargin));
			}
			return cb_getHorizontalMargin;
		}

		private static int n_GetHorizontalMargin(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalMargin;
		}

		private static Delegate GetIsInPlaceholderHandler()
		{
			if ((object)cb_isInPlaceholder == null)
			{
				cb_isInPlaceholder = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsInPlaceholder));
			}
			return cb_isInPlaceholder;
		}

		private static bool n_IsInPlaceholder(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InPlaceholder;
		}

		private static Delegate GetSetInPlaceholder_ZHandler()
		{
			if ((object)cb_setInPlaceholder_Z == null)
			{
				cb_setInPlaceholder_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetInPlaceholder_Z));
			}
			return cb_setInPlaceholder_Z;
		}

		private static void n_SetInPlaceholder_Z(IntPtr jnienv, IntPtr native__this, bool inPlaceholder)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InPlaceholder = inPlaceholder;
		}

		private static Delegate GetIsInVirtualLayoutHandler()
		{
			if ((object)cb_isInVirtualLayout == null)
			{
				cb_isInVirtualLayout = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsInVirtualLayout));
			}
			return cb_isInVirtualLayout;
		}

		private static bool n_IsInVirtualLayout(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InVirtualLayout;
		}

		private static Delegate GetSetInVirtualLayout_ZHandler()
		{
			if ((object)cb_setInVirtualLayout_Z == null)
			{
				cb_setInVirtualLayout_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetInVirtualLayout_Z));
			}
			return cb_setInVirtualLayout_Z;
		}

		private static void n_SetInVirtualLayout_Z(IntPtr jnienv, IntPtr native__this, bool inVirtualLayout)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InVirtualLayout = inVirtualLayout;
		}

		private static Delegate GetIsInHorizontalChainHandler()
		{
			if ((object)cb_isInHorizontalChain == null)
			{
				cb_isInHorizontalChain = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsInHorizontalChain));
			}
			return cb_isInHorizontalChain;
		}

		private static bool n_IsInHorizontalChain(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsInHorizontalChain;
		}

		private static Delegate GetIsInVerticalChainHandler()
		{
			if ((object)cb_isInVerticalChain == null)
			{
				cb_isInVerticalChain = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsInVerticalChain));
			}
			return cb_isInVerticalChain;
		}

		private static bool n_IsInVerticalChain(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsInVerticalChain;
		}

		private static Delegate GetIsResolvedHorizontallyHandler()
		{
			if ((object)cb_isResolvedHorizontally == null)
			{
				cb_isResolvedHorizontally = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsResolvedHorizontally));
			}
			return cb_isResolvedHorizontally;
		}

		private static bool n_IsResolvedHorizontally(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsResolvedHorizontally;
		}

		private static Delegate GetIsResolvedVerticallyHandler()
		{
			if ((object)cb_isResolvedVertically == null)
			{
				cb_isResolvedVertically = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsResolvedVertically));
			}
			return cb_isResolvedVertically;
		}

		private static bool n_IsResolvedVertically(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsResolvedVertically;
		}

		private static Delegate GetIsRootHandler()
		{
			if ((object)cb_isRoot == null)
			{
				cb_isRoot = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsRoot));
			}
			return cb_isRoot;
		}

		private static bool n_IsRoot(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsRoot;
		}

		private static Delegate GetIsSpreadHeightHandler()
		{
			if ((object)cb_isSpreadHeight == null)
			{
				cb_isSpreadHeight = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsSpreadHeight));
			}
			return cb_isSpreadHeight;
		}

		private static bool n_IsSpreadHeight(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsSpreadHeight;
		}

		private static Delegate GetIsSpreadWidthHandler()
		{
			if ((object)cb_isSpreadWidth == null)
			{
				cb_isSpreadWidth = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsSpreadWidth));
			}
			return cb_isSpreadWidth;
		}

		private static bool n_IsSpreadWidth(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsSpreadWidth;
		}

		private static Delegate GetGetLastHorizontalMeasureSpecHandler()
		{
			if ((object)cb_getLastHorizontalMeasureSpec == null)
			{
				cb_getLastHorizontalMeasureSpec = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetLastHorizontalMeasureSpec));
			}
			return cb_getLastHorizontalMeasureSpec;
		}

		private static int n_GetLastHorizontalMeasureSpec(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LastHorizontalMeasureSpec;
		}

		private static Delegate GetGetLastVerticalMeasureSpecHandler()
		{
			if ((object)cb_getLastVerticalMeasureSpec == null)
			{
				cb_getLastVerticalMeasureSpec = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetLastVerticalMeasureSpec));
			}
			return cb_getLastVerticalMeasureSpec;
		}

		private static int n_GetLastVerticalMeasureSpec(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LastVerticalMeasureSpec;
		}

		private static Delegate GetGetLeftHandler()
		{
			if ((object)cb_getLeft == null)
			{
				cb_getLeft = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetLeft));
			}
			return cb_getLeft;
		}

		private static int n_GetLeft(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Left;
		}

		private static Delegate GetGetMaxHeightHandler()
		{
			if ((object)cb_getMaxHeight == null)
			{
				cb_getMaxHeight = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetMaxHeight));
			}
			return cb_getMaxHeight;
		}

		private static int n_GetMaxHeight(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxHeight;
		}

		private static Delegate GetSetMaxHeight_IHandler()
		{
			if ((object)cb_setMaxHeight_I == null)
			{
				cb_setMaxHeight_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetMaxHeight_I));
			}
			return cb_setMaxHeight_I;
		}

		private static void n_SetMaxHeight_I(IntPtr jnienv, IntPtr native__this, int maxHeight)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxHeight = maxHeight;
		}

		private static Delegate GetGetMaxWidthHandler()
		{
			if ((object)cb_getMaxWidth == null)
			{
				cb_getMaxWidth = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetMaxWidth));
			}
			return cb_getMaxWidth;
		}

		private static int n_GetMaxWidth(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxWidth;
		}

		private static Delegate GetSetMaxWidth_IHandler()
		{
			if ((object)cb_setMaxWidth_I == null)
			{
				cb_setMaxWidth_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetMaxWidth_I));
			}
			return cb_setMaxWidth_I;
		}

		private static void n_SetMaxWidth_I(IntPtr jnienv, IntPtr native__this, int maxWidth)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MaxWidth = maxWidth;
		}

		private static Delegate GetIsMeasureRequestedHandler()
		{
			if ((object)cb_isMeasureRequested == null)
			{
				cb_isMeasureRequested = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsMeasureRequested));
			}
			return cb_isMeasureRequested;
		}

		private static bool n_IsMeasureRequested(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MeasureRequested;
		}

		private static Delegate GetSetMeasureRequested_ZHandler()
		{
			if ((object)cb_setMeasureRequested_Z == null)
			{
				cb_setMeasureRequested_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetMeasureRequested_Z));
			}
			return cb_setMeasureRequested_Z;
		}

		private static void n_SetMeasureRequested_Z(IntPtr jnienv, IntPtr native__this, bool measureRequested)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MeasureRequested = measureRequested;
		}

		private static Delegate GetGetMinHeightHandler()
		{
			if ((object)cb_getMinHeight == null)
			{
				cb_getMinHeight = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetMinHeight));
			}
			return cb_getMinHeight;
		}

		private static int n_GetMinHeight(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinHeight;
		}

		private static Delegate GetSetMinHeight_IHandler()
		{
			if ((object)cb_setMinHeight_I == null)
			{
				cb_setMinHeight_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetMinHeight_I));
			}
			return cb_setMinHeight_I;
		}

		private static void n_SetMinHeight_I(IntPtr jnienv, IntPtr native__this, int h)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinHeight = h;
		}

		private static Delegate GetGetMinWidthHandler()
		{
			if ((object)cb_getMinWidth == null)
			{
				cb_getMinWidth = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetMinWidth));
			}
			return cb_getMinWidth;
		}

		private static int n_GetMinWidth(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinWidth;
		}

		private static Delegate GetSetMinWidth_IHandler()
		{
			if ((object)cb_setMinWidth_I == null)
			{
				cb_setMinWidth_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetMinWidth_I));
			}
			return cb_setMinWidth_I;
		}

		private static void n_SetMinWidth_I(IntPtr jnienv, IntPtr native__this, int w)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MinWidth = w;
		}

		private static Delegate GetGetOptimizerWrapHeightHandler()
		{
			if ((object)cb_getOptimizerWrapHeight == null)
			{
				cb_getOptimizerWrapHeight = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetOptimizerWrapHeight));
			}
			return cb_getOptimizerWrapHeight;
		}

		private static int n_GetOptimizerWrapHeight(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OptimizerWrapHeight;
		}

		private static Delegate GetGetOptimizerWrapWidthHandler()
		{
			if ((object)cb_getOptimizerWrapWidth == null)
			{
				cb_getOptimizerWrapWidth = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetOptimizerWrapWidth));
			}
			return cb_getOptimizerWrapWidth;
		}

		private static int n_GetOptimizerWrapWidth(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OptimizerWrapWidth;
		}

		private static Delegate GetGetParentHandler()
		{
			if ((object)cb_getParent == null)
			{
				cb_getParent = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetParent));
			}
			return cb_getParent;
		}

		private static IntPtr n_GetParent(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Parent);
		}

		private static Delegate GetSetParent_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Handler()
		{
			if ((object)cb_setParent_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_ == null)
			{
				cb_setParent_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetParent_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_));
			}
			return cb_setParent_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_;
		}

		private static void n_SetParent_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_(IntPtr jnienv, IntPtr native__this, IntPtr native_widget)
		{
			ConstraintWidget constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget parent = Java.Lang.Object.GetObject<ConstraintWidget>(native_widget, JniHandleOwnership.DoNotTransfer);
			constraintWidget.Parent = parent;
		}

		private static Delegate GetGetRightHandler()
		{
			if ((object)cb_getRight == null)
			{
				cb_getRight = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetRight));
			}
			return cb_getRight;
		}

		private static int n_GetRight(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Right;
		}

		private static Delegate GetGetRootXHandler()
		{
			if ((object)cb_getRootX == null)
			{
				cb_getRootX = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetRootX));
			}
			return cb_getRootX;
		}

		private static int n_GetRootX(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RootX;
		}

		private static Delegate GetGetRootYHandler()
		{
			if ((object)cb_getRootY == null)
			{
				cb_getRootY = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetRootY));
			}
			return cb_getRootY;
		}

		private static int n_GetRootY(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RootY;
		}

		private static Delegate GetGetTopHandler()
		{
			if ((object)cb_getTop == null)
			{
				cb_getTop = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetTop));
			}
			return cb_getTop;
		}

		private static int n_GetTop(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Top;
		}

		private static Delegate GetGetTypeHandler()
		{
			if ((object)cb_getType == null)
			{
				cb_getType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetType));
			}
			return cb_getType;
		}

		private static IntPtr n_GetType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Type);
		}

		private static Delegate GetSetType_Ljava_lang_String_Handler()
		{
			if ((object)cb_setType_Ljava_lang_String_ == null)
			{
				cb_setType_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetType_Ljava_lang_String_));
			}
			return cb_setType_Ljava_lang_String_;
		}

		private static void n_SetType_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_type)
		{
			ConstraintWidget constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string type = JNIEnv.GetString(native_type, JniHandleOwnership.DoNotTransfer);
			constraintWidget.Type = type;
		}

		private static Delegate GetGetVerticalBiasPercentHandler()
		{
			if ((object)cb_getVerticalBiasPercent == null)
			{
				cb_getVerticalBiasPercent = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetVerticalBiasPercent));
			}
			return cb_getVerticalBiasPercent;
		}

		private static float n_GetVerticalBiasPercent(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalBiasPercent;
		}

		private static Delegate GetSetVerticalBiasPercent_FHandler()
		{
			if ((object)cb_setVerticalBiasPercent_F == null)
			{
				cb_setVerticalBiasPercent_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetVerticalBiasPercent_F));
			}
			return cb_setVerticalBiasPercent_F;
		}

		private static void n_SetVerticalBiasPercent_F(IntPtr jnienv, IntPtr native__this, float verticalBiasPercent)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalBiasPercent = verticalBiasPercent;
		}

		private static Delegate GetGetVerticalChainControlWidgetHandler()
		{
			if ((object)cb_getVerticalChainControlWidget == null)
			{
				cb_getVerticalChainControlWidget = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetVerticalChainControlWidget));
			}
			return cb_getVerticalChainControlWidget;
		}

		private static IntPtr n_GetVerticalChainControlWidget(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalChainControlWidget);
		}

		private static Delegate GetGetVerticalChainStyleHandler()
		{
			if ((object)cb_getVerticalChainStyle == null)
			{
				cb_getVerticalChainStyle = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetVerticalChainStyle));
			}
			return cb_getVerticalChainStyle;
		}

		private static int n_GetVerticalChainStyle(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalChainStyle;
		}

		private static Delegate GetSetVerticalChainStyle_IHandler()
		{
			if ((object)cb_setVerticalChainStyle_I == null)
			{
				cb_setVerticalChainStyle_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetVerticalChainStyle_I));
			}
			return cb_setVerticalChainStyle_I;
		}

		private static void n_SetVerticalChainStyle_I(IntPtr jnienv, IntPtr native__this, int verticalChainStyle)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalChainStyle = verticalChainStyle;
		}

		private static Delegate GetGetVerticalDimensionBehaviourHandler()
		{
			if ((object)cb_getVerticalDimensionBehaviour == null)
			{
				cb_getVerticalDimensionBehaviour = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetVerticalDimensionBehaviour));
			}
			return cb_getVerticalDimensionBehaviour;
		}

		private static IntPtr n_GetVerticalDimensionBehaviour(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalDimensionBehaviour);
		}

		private static Delegate GetSetVerticalDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_Handler()
		{
			if ((object)cb_setVerticalDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_ == null)
			{
				cb_setVerticalDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetVerticalDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_));
			}
			return cb_setVerticalDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_;
		}

		private static void n_SetVerticalDimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_(IntPtr jnienv, IntPtr native__this, IntPtr native_behaviour)
		{
			ConstraintWidget constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			DimensionBehaviour verticalDimensionBehaviour = Java.Lang.Object.GetObject<DimensionBehaviour>(native_behaviour, JniHandleOwnership.DoNotTransfer);
			constraintWidget.VerticalDimensionBehaviour = verticalDimensionBehaviour;
		}

		private static Delegate GetGetVerticalMarginHandler()
		{
			if ((object)cb_getVerticalMargin == null)
			{
				cb_getVerticalMargin = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetVerticalMargin));
			}
			return cb_getVerticalMargin;
		}

		private static int n_GetVerticalMargin(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalMargin;
		}

		private static Delegate GetGetVisibilityHandler()
		{
			if ((object)cb_getVisibility == null)
			{
				cb_getVisibility = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetVisibility));
			}
			return cb_getVisibility;
		}

		private static int n_GetVisibility(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visibility;
		}

		private static Delegate GetSetVisibility_IHandler()
		{
			if ((object)cb_setVisibility_I == null)
			{
				cb_setVisibility_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetVisibility_I));
			}
			return cb_setVisibility_I;
		}

		private static void n_SetVisibility_I(IntPtr jnienv, IntPtr native__this, int visibility)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Visibility = visibility;
		}

		private static Delegate GetGetWidthHandler()
		{
			if ((object)cb_getWidth == null)
			{
				cb_getWidth = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetWidth));
			}
			return cb_getWidth;
		}

		private static int n_GetWidth(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Width;
		}

		private static Delegate GetSetWidth_IHandler()
		{
			if ((object)cb_setWidth_I == null)
			{
				cb_setWidth_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetWidth_I));
			}
			return cb_setWidth_I;
		}

		private static void n_SetWidth_I(IntPtr jnienv, IntPtr native__this, int w)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Width = w;
		}

		private static Delegate GetIsWidthWrapContentHandler()
		{
			if ((object)cb_isWidthWrapContent == null)
			{
				cb_isWidthWrapContent = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsWidthWrapContent));
			}
			return cb_isWidthWrapContent;
		}

		private static bool n_IsWidthWrapContent(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WidthWrapContent;
		}

		private static Delegate GetSetWidthWrapContent_ZHandler()
		{
			if ((object)cb_setWidthWrapContent_Z == null)
			{
				cb_setWidthWrapContent_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetWidthWrapContent_Z));
			}
			return cb_setWidthWrapContent_Z;
		}

		private static void n_SetWidthWrapContent_Z(IntPtr jnienv, IntPtr native__this, bool widthWrapContent)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WidthWrapContent = widthWrapContent;
		}

		private static Delegate GetAddChildrenToSolverByDependency_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_solver_LinearSystem_Ljava_util_HashSet_IZHandler()
		{
			if ((object)cb_addChildrenToSolverByDependency_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_solver_LinearSystem_Ljava_util_HashSet_IZ == null)
			{
				cb_addChildrenToSolverByDependency_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_solver_LinearSystem_Ljava_util_HashSet_IZ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLIZ_V(n_AddChildrenToSolverByDependency_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_solver_LinearSystem_Ljava_util_HashSet_IZ));
			}
			return cb_addChildrenToSolverByDependency_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_solver_LinearSystem_Ljava_util_HashSet_IZ;
		}

		private static void n_AddChildrenToSolverByDependency_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_solver_LinearSystem_Ljava_util_HashSet_IZ(IntPtr jnienv, IntPtr native__this, IntPtr native_container, IntPtr native_system, IntPtr native_widgets, int orientation, bool addSelf)
		{
			ConstraintWidget constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidgetContainer container = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(native_container, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			HashSet widgets = Java.Lang.Object.GetObject<HashSet>(native_widgets, JniHandleOwnership.DoNotTransfer);
			constraintWidget.AddChildrenToSolverByDependency(container, system, widgets, orientation, addSelf);
		}

		[Register("addChildrenToSolverByDependency", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;Landroidx/constraintlayout/solver/LinearSystem;Ljava/util/HashSet;IZ)V", "GetAddChildrenToSolverByDependency_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_Landroidx_constraintlayout_solver_LinearSystem_Ljava_util_HashSet_IZHandler")]
		public unsafe virtual void AddChildrenToSolverByDependency(ConstraintWidgetContainer container, LinearSystem system, HashSet widgets, int orientation, bool addSelf)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(widgets?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(orientation);
				ptr[4] = new JniArgumentValue(addSelf);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addChildrenToSolverByDependency.(Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;Landroidx/constraintlayout/solver/LinearSystem;Ljava/util/HashSet;IZ)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(container);
				GC.KeepAlive(system);
				GC.KeepAlive(widgets);
			}
		}

		private static Delegate GetAddToSolver_Landroidx_constraintlayout_solver_LinearSystem_ZHandler()
		{
			if ((object)cb_addToSolver_Landroidx_constraintlayout_solver_LinearSystem_Z == null)
			{
				cb_addToSolver_Landroidx_constraintlayout_solver_LinearSystem_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_V(n_AddToSolver_Landroidx_constraintlayout_solver_LinearSystem_Z));
			}
			return cb_addToSolver_Landroidx_constraintlayout_solver_LinearSystem_Z;
		}

		private static void n_AddToSolver_Landroidx_constraintlayout_solver_LinearSystem_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_system, bool optimize)
		{
			ConstraintWidget constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			constraintWidget.AddToSolver(system, optimize);
		}

		[Register("addToSolver", "(Landroidx/constraintlayout/solver/LinearSystem;Z)V", "GetAddToSolver_Landroidx_constraintlayout_solver_LinearSystem_ZHandler")]
		public unsafe virtual void AddToSolver(LinearSystem system, bool optimize)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(optimize);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addToSolver.(Landroidx/constraintlayout/solver/LinearSystem;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(system);
			}
		}

		private static Delegate GetAllowedInBarrierHandler()
		{
			if ((object)cb_allowedInBarrier == null)
			{
				cb_allowedInBarrier = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_AllowedInBarrier));
			}
			return cb_allowedInBarrier;
		}

		private static bool n_AllowedInBarrier(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AllowedInBarrier();
		}

		[Register("allowedInBarrier", "()Z", "GetAllowedInBarrierHandler")]
		public unsafe virtual bool AllowedInBarrier()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("allowedInBarrier.()Z", this, null);
		}

		private static Delegate GetConnect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_IHandler()
		{
			if ((object)cb_connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_I == null)
			{
				cb_connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLI_V(n_Connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_I));
			}
			return cb_connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_I;
		}

		private static void n_Connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_I(IntPtr jnienv, IntPtr native__this, IntPtr native_from, IntPtr native_to, int margin)
		{
			ConstraintWidget constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor constraintAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(native_from, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor to = Java.Lang.Object.GetObject<ConstraintAnchor>(native_to, JniHandleOwnership.DoNotTransfer);
			constraintWidget.Connect(constraintAnchor, to, margin);
		}

		[Register("connect", "(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;I)V", "GetConnect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_IHandler")]
		public unsafe virtual void Connect(ConstraintAnchor from, ConstraintAnchor to, int margin)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(from?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(to?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(margin);
				_members.InstanceMethods.InvokeVirtualVoidMethod("connect.(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(from);
				GC.KeepAlive(to);
			}
		}

		private static Delegate GetConnect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Handler()
		{
			if ((object)cb_connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_ == null)
			{
				cb_connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_V(n_Connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_));
			}
			return cb_connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_;
		}

		private static void n_Connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_(IntPtr jnienv, IntPtr native__this, IntPtr native_constraintFrom, IntPtr native_target, IntPtr native_constraintTo)
		{
			ConstraintWidget constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor.Type constraintFrom = Java.Lang.Object.GetObject<ConstraintAnchor.Type>(native_constraintFrom, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget target = Java.Lang.Object.GetObject<ConstraintWidget>(native_target, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor.Type constraintTo = Java.Lang.Object.GetObject<ConstraintAnchor.Type>(native_constraintTo, JniHandleOwnership.DoNotTransfer);
			constraintWidget.Connect(constraintFrom, target, constraintTo);
		}

		[Register("connect", "(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;)V", "GetConnect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Handler")]
		public unsafe virtual void Connect(ConstraintAnchor.Type constraintFrom, ConstraintWidget target, ConstraintAnchor.Type constraintTo)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(constraintFrom?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(constraintTo?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("connect.(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(constraintFrom);
				GC.KeepAlive(target);
				GC.KeepAlive(constraintTo);
			}
		}

		private static Delegate GetConnect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_IHandler()
		{
			if ((object)cb_connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_I == null)
			{
				cb_connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_I = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLI_V(n_Connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_I));
			}
			return cb_connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_I;
		}

		private static void n_Connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_I(IntPtr jnienv, IntPtr native__this, IntPtr native_constraintFrom, IntPtr native_target, IntPtr native_constraintTo, int margin)
		{
			ConstraintWidget constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor.Type constraintFrom = Java.Lang.Object.GetObject<ConstraintAnchor.Type>(native_constraintFrom, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget target = Java.Lang.Object.GetObject<ConstraintWidget>(native_target, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor.Type constraintTo = Java.Lang.Object.GetObject<ConstraintAnchor.Type>(native_constraintTo, JniHandleOwnership.DoNotTransfer);
			constraintWidget.Connect(constraintFrom, target, constraintTo, margin);
		}

		[Register("connect", "(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;I)V", "GetConnect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_IHandler")]
		public unsafe virtual void Connect(ConstraintAnchor.Type constraintFrom, ConstraintWidget target, ConstraintAnchor.Type constraintTo, int margin)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(constraintFrom?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(constraintTo?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(margin);
				_members.InstanceMethods.InvokeVirtualVoidMethod("connect.(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(constraintFrom);
				GC.KeepAlive(target);
				GC.KeepAlive(constraintTo);
			}
		}

		private static Delegate GetConnectCircularConstraint_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_FIHandler()
		{
			if ((object)cb_connectCircularConstraint_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_FI == null)
			{
				cb_connectCircularConstraint_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_FI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLFI_V(n_ConnectCircularConstraint_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_FI));
			}
			return cb_connectCircularConstraint_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_FI;
		}

		private static void n_ConnectCircularConstraint_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_FI(IntPtr jnienv, IntPtr native__this, IntPtr native_target, float angle, int radius)
		{
			ConstraintWidget constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget target = Java.Lang.Object.GetObject<ConstraintWidget>(native_target, JniHandleOwnership.DoNotTransfer);
			constraintWidget.ConnectCircularConstraint(target, angle, radius);
		}

		[Register("connectCircularConstraint", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;FI)V", "GetConnectCircularConstraint_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_FIHandler")]
		public unsafe virtual void ConnectCircularConstraint(ConstraintWidget target, float angle, int radius)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(angle);
				ptr[2] = new JniArgumentValue(radius);
				_members.InstanceMethods.InvokeVirtualVoidMethod("connectCircularConstraint.(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;FI)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(target);
			}
		}

		private static Delegate GetCopy_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Ljava_util_HashMap_Handler()
		{
			if ((object)cb_copy_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Ljava_util_HashMap_ == null)
			{
				cb_copy_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Ljava_util_HashMap_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_Copy_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Ljava_util_HashMap_));
			}
			return cb_copy_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Ljava_util_HashMap_;
		}

		private static void n_Copy_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Ljava_util_HashMap_(IntPtr jnienv, IntPtr native__this, IntPtr native_src, IntPtr native_map)
		{
			ConstraintWidget constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget src = Java.Lang.Object.GetObject<ConstraintWidget>(native_src, JniHandleOwnership.DoNotTransfer);
			IDictionary<ConstraintWidget, ConstraintWidget> map = JavaDictionary<ConstraintWidget, ConstraintWidget>.FromJniHandle(native_map, JniHandleOwnership.DoNotTransfer);
			constraintWidget.Copy(src, map);
		}

		[Register("copy", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Ljava/util/HashMap;)V", "GetCopy_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Ljava_util_HashMap_Handler")]
		public unsafe virtual void Copy(ConstraintWidget src, IDictionary<ConstraintWidget, ConstraintWidget> map)
		{
			IntPtr intPtr = JavaDictionary<ConstraintWidget, ConstraintWidget>.ToLocalJniHandle(map);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(src?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("copy.(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Ljava/util/HashMap;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(src);
				GC.KeepAlive(map);
			}
		}

		private static Delegate GetCreateObjectVariables_Landroidx_constraintlayout_solver_LinearSystem_Handler()
		{
			if ((object)cb_createObjectVariables_Landroidx_constraintlayout_solver_LinearSystem_ == null)
			{
				cb_createObjectVariables_Landroidx_constraintlayout_solver_LinearSystem_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_CreateObjectVariables_Landroidx_constraintlayout_solver_LinearSystem_));
			}
			return cb_createObjectVariables_Landroidx_constraintlayout_solver_LinearSystem_;
		}

		private static void n_CreateObjectVariables_Landroidx_constraintlayout_solver_LinearSystem_(IntPtr jnienv, IntPtr native__this, IntPtr native_system)
		{
			ConstraintWidget constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			constraintWidget.CreateObjectVariables(system);
		}

		[Register("createObjectVariables", "(Landroidx/constraintlayout/solver/LinearSystem;)V", "GetCreateObjectVariables_Landroidx_constraintlayout_solver_LinearSystem_Handler")]
		public unsafe virtual void CreateObjectVariables(LinearSystem system)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("createObjectVariables.(Landroidx/constraintlayout/solver/LinearSystem;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(system);
			}
		}

		private static Delegate GetEnsureMeasureRequestedHandler()
		{
			if ((object)cb_ensureMeasureRequested == null)
			{
				cb_ensureMeasureRequested = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_EnsureMeasureRequested));
			}
			return cb_ensureMeasureRequested;
		}

		private static void n_EnsureMeasureRequested(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnsureMeasureRequested();
		}

		[Register("ensureMeasureRequested", "()V", "GetEnsureMeasureRequestedHandler")]
		public unsafe virtual void EnsureMeasureRequested()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("ensureMeasureRequested.()V", this, null);
		}

		private static Delegate GetEnsureWidgetRunsHandler()
		{
			if ((object)cb_ensureWidgetRuns == null)
			{
				cb_ensureWidgetRuns = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_EnsureWidgetRuns));
			}
			return cb_ensureWidgetRuns;
		}

		private static void n_EnsureWidgetRuns(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EnsureWidgetRuns();
		}

		[Register("ensureWidgetRuns", "()V", "GetEnsureWidgetRunsHandler")]
		public unsafe virtual void EnsureWidgetRuns()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("ensureWidgetRuns.()V", this, null);
		}

		private static Delegate GetGetAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Handler()
		{
			if ((object)cb_getAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_ == null)
			{
				cb_getAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_));
			}
			return cb_getAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_;
		}

		private static IntPtr n_GetAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_(IntPtr jnienv, IntPtr native__this, IntPtr native_anchorType)
		{
			ConstraintWidget constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor.Type anchorType = Java.Lang.Object.GetObject<ConstraintAnchor.Type>(native_anchorType, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(constraintWidget.GetAnchor(anchorType));
		}

		[Register("getAnchor", "(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;)Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", "GetGetAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Handler")]
		public unsafe virtual ConstraintAnchor GetAnchor(ConstraintAnchor.Type anchorType)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(anchorType?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ConstraintAnchor>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAnchor.(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;)Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(anchorType);
			}
		}

		private static Delegate GetGetBiasPercent_IHandler()
		{
			if ((object)cb_getBiasPercent_I == null)
			{
				cb_getBiasPercent_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_F(n_GetBiasPercent_I));
			}
			return cb_getBiasPercent_I;
		}

		private static float n_GetBiasPercent_I(IntPtr jnienv, IntPtr native__this, int orientation)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetBiasPercent(orientation);
		}

		[Register("getBiasPercent", "(I)F", "GetGetBiasPercent_IHandler")]
		public unsafe virtual float GetBiasPercent(int orientation)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(orientation);
			return _members.InstanceMethods.InvokeVirtualSingleMethod("getBiasPercent.(I)F", this, ptr);
		}

		private static Delegate GetGetDimensionBehaviour_IHandler()
		{
			if ((object)cb_getDimensionBehaviour_I == null)
			{
				cb_getDimensionBehaviour_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetDimensionBehaviour_I));
			}
			return cb_getDimensionBehaviour_I;
		}

		private static IntPtr n_GetDimensionBehaviour_I(IntPtr jnienv, IntPtr native__this, int orientation)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetDimensionBehaviour(orientation));
		}

		[Register("getDimensionBehaviour", "(I)Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;", "GetGetDimensionBehaviour_IHandler")]
		public unsafe virtual DimensionBehaviour GetDimensionBehaviour(int orientation)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(orientation);
			return Java.Lang.Object.GetObject<DimensionBehaviour>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDimensionBehaviour.(I)Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetLength_IHandler()
		{
			if ((object)cb_getLength_I == null)
			{
				cb_getLength_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_I(n_GetLength_I));
			}
			return cb_getLength_I;
		}

		private static int n_GetLength_I(IntPtr jnienv, IntPtr native__this, int orientation)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetLength(orientation);
		}

		[Register("getLength", "(I)I", "GetGetLength_IHandler")]
		public unsafe virtual int GetLength(int orientation)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(orientation);
			return _members.InstanceMethods.InvokeVirtualInt32Method("getLength.(I)I", this, ptr);
		}

		private static Delegate GetGetNextChainMember_IHandler()
		{
			if ((object)cb_getNextChainMember_I == null)
			{
				cb_getNextChainMember_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetNextChainMember_I));
			}
			return cb_getNextChainMember_I;
		}

		private static IntPtr n_GetNextChainMember_I(IntPtr jnienv, IntPtr native__this, int orientation)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetNextChainMember(orientation));
		}

		[Register("getNextChainMember", "(I)Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", "GetGetNextChainMember_IHandler")]
		public unsafe virtual ConstraintWidget GetNextChainMember(int orientation)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(orientation);
			return Java.Lang.Object.GetObject<ConstraintWidget>(_members.InstanceMethods.InvokeVirtualObjectMethod("getNextChainMember.(I)Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetPreviousChainMember_IHandler()
		{
			if ((object)cb_getPreviousChainMember_I == null)
			{
				cb_getPreviousChainMember_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetPreviousChainMember_I));
			}
			return cb_getPreviousChainMember_I;
		}

		private static IntPtr n_GetPreviousChainMember_I(IntPtr jnienv, IntPtr native__this, int orientation)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetPreviousChainMember(orientation));
		}

		[Register("getPreviousChainMember", "(I)Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", "GetGetPreviousChainMember_IHandler")]
		public unsafe virtual ConstraintWidget GetPreviousChainMember(int orientation)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(orientation);
			return Java.Lang.Object.GetObject<ConstraintWidget>(_members.InstanceMethods.InvokeVirtualObjectMethod("getPreviousChainMember.(I)Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetRun_IHandler()
		{
			if ((object)cb_getRun_I == null)
			{
				cb_getRun_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_GetRun_I));
			}
			return cb_getRun_I;
		}

		private static IntPtr n_GetRun_I(IntPtr jnienv, IntPtr native__this, int orientation)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetRun(orientation));
		}

		[Register("getRun", "(I)Landroidx/constraintlayout/solver/widgets/analyzer/WidgetRun;", "GetGetRun_IHandler")]
		public unsafe virtual WidgetRun GetRun(int orientation)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(orientation);
			return Java.Lang.Object.GetObject<WidgetRun>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRun.(I)Landroidx/constraintlayout/solver/widgets/analyzer/WidgetRun;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetXHandler()
		{
			if ((object)cb_getX == null)
			{
				cb_getX = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetX));
			}
			return cb_getX;
		}

		private static int n_GetX(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetX();
		}

		[Register("getX", "()I", "GetGetXHandler")]
		public unsafe virtual int GetX()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getX.()I", this, null);
		}

		private static Delegate GetGetYHandler()
		{
			if ((object)cb_getY == null)
			{
				cb_getY = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetY));
			}
			return cb_getY;
		}

		private static int n_GetY(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetY();
		}

		[Register("getY", "()I", "GetGetYHandler")]
		public unsafe virtual int GetY()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("getY.()I", this, null);
		}

		private static Delegate GetGetHasBaselineHandler()
		{
			if ((object)cb_getHasBaseline == null)
			{
				cb_getHasBaseline = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_GetHasBaseline));
			}
			return cb_getHasBaseline;
		}

		private static bool n_GetHasBaseline(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHasBaseline();
		}

		[Register("getHasBaseline", "()Z", "GetGetHasBaselineHandler")]
		public unsafe virtual bool GetHasBaseline()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("getHasBaseline.()Z", this, null);
		}

		private static Delegate GetHasDanglingDimension_IHandler()
		{
			if ((object)cb_hasDanglingDimension_I == null)
			{
				cb_hasDanglingDimension_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_Z(n_HasDanglingDimension_I));
			}
			return cb_hasDanglingDimension_I;
		}

		private static bool n_HasDanglingDimension_I(IntPtr jnienv, IntPtr native__this, int orientation)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasDanglingDimension(orientation);
		}

		[Register("hasDanglingDimension", "(I)Z", "GetHasDanglingDimension_IHandler")]
		public unsafe virtual bool HasDanglingDimension(int orientation)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(orientation);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasDanglingDimension.(I)Z", this, ptr);
		}

		private static Delegate GetImmediateConnect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_IIHandler()
		{
			if ((object)cb_immediateConnect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_II == null)
			{
				cb_immediateConnect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_II = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLII_V(n_ImmediateConnect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_II));
			}
			return cb_immediateConnect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_II;
		}

		private static void n_ImmediateConnect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_II(IntPtr jnienv, IntPtr native__this, IntPtr native_startType, IntPtr native_target, IntPtr native_endType, int margin, int goneMargin)
		{
			ConstraintWidget constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor.Type startType = Java.Lang.Object.GetObject<ConstraintAnchor.Type>(native_startType, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget target = Java.Lang.Object.GetObject<ConstraintWidget>(native_target, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor.Type endType = Java.Lang.Object.GetObject<ConstraintAnchor.Type>(native_endType, JniHandleOwnership.DoNotTransfer);
			constraintWidget.ImmediateConnect(startType, target, endType, margin, goneMargin);
		}

		[Register("immediateConnect", "(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;II)V", "GetImmediateConnect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_IIHandler")]
		public unsafe virtual void ImmediateConnect(ConstraintAnchor.Type startType, ConstraintWidget target, ConstraintAnchor.Type endType, int margin, int goneMargin)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(startType?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(endType?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(margin);
				ptr[4] = new JniArgumentValue(goneMargin);
				_members.InstanceMethods.InvokeVirtualVoidMethod("immediateConnect.(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;II)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(startType);
				GC.KeepAlive(target);
				GC.KeepAlive(endType);
			}
		}

		private static Delegate GetOppositeDimensionDependsOn_IHandler()
		{
			if ((object)cb_oppositeDimensionDependsOn_I == null)
			{
				cb_oppositeDimensionDependsOn_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_Z(n_OppositeDimensionDependsOn_I));
			}
			return cb_oppositeDimensionDependsOn_I;
		}

		private static bool n_OppositeDimensionDependsOn_I(IntPtr jnienv, IntPtr native__this, int orientation)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OppositeDimensionDependsOn(orientation);
		}

		[Register("oppositeDimensionDependsOn", "(I)Z", "GetOppositeDimensionDependsOn_IHandler")]
		public unsafe virtual bool OppositeDimensionDependsOn(int orientation)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(orientation);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("oppositeDimensionDependsOn.(I)Z", this, ptr);
		}

		private static Delegate GetOppositeDimensionsTiedHandler()
		{
			if ((object)cb_oppositeDimensionsTied == null)
			{
				cb_oppositeDimensionsTied = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_OppositeDimensionsTied));
			}
			return cb_oppositeDimensionsTied;
		}

		private static bool n_OppositeDimensionsTied(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OppositeDimensionsTied();
		}

		[Register("oppositeDimensionsTied", "()Z", "GetOppositeDimensionsTiedHandler")]
		public unsafe virtual bool OppositeDimensionsTied()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("oppositeDimensionsTied.()Z", this, null);
		}

		private static Delegate GetResetHandler()
		{
			if ((object)cb_reset == null)
			{
				cb_reset = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Reset));
			}
			return cb_reset;
		}

		private static void n_Reset(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset();
		}

		[Register("reset", "()V", "GetResetHandler")]
		public unsafe virtual void Reset()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("reset.()V", this, null);
		}

		private static Delegate GetResetAllConstraintsHandler()
		{
			if ((object)cb_resetAllConstraints == null)
			{
				cb_resetAllConstraints = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ResetAllConstraints));
			}
			return cb_resetAllConstraints;
		}

		private static void n_ResetAllConstraints(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResetAllConstraints();
		}

		[Register("resetAllConstraints", "()V", "GetResetAllConstraintsHandler")]
		public unsafe virtual void ResetAllConstraints()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("resetAllConstraints.()V", this, null);
		}

		private static Delegate GetResetAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Handler()
		{
			if ((object)cb_resetAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_ == null)
			{
				cb_resetAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ResetAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_));
			}
			return cb_resetAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_;
		}

		private static void n_ResetAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_(IntPtr jnienv, IntPtr native__this, IntPtr native_anchor)
		{
			ConstraintWidget constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor anchor = Java.Lang.Object.GetObject<ConstraintAnchor>(native_anchor, JniHandleOwnership.DoNotTransfer);
			constraintWidget.ResetAnchor(anchor);
		}

		[Register("resetAnchor", "(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;)V", "GetResetAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Handler")]
		public unsafe virtual void ResetAnchor(ConstraintAnchor anchor)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(anchor?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("resetAnchor.(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(anchor);
			}
		}

		private static Delegate GetResetAnchorsHandler()
		{
			if ((object)cb_resetAnchors == null)
			{
				cb_resetAnchors = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ResetAnchors));
			}
			return cb_resetAnchors;
		}

		private static void n_ResetAnchors(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResetAnchors();
		}

		[Register("resetAnchors", "()V", "GetResetAnchorsHandler")]
		public unsafe virtual void ResetAnchors()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("resetAnchors.()V", this, null);
		}

		private static Delegate GetResetFinalResolutionHandler()
		{
			if ((object)cb_resetFinalResolution == null)
			{
				cb_resetFinalResolution = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ResetFinalResolution));
			}
			return cb_resetFinalResolution;
		}

		private static void n_ResetFinalResolution(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResetFinalResolution();
		}

		[Register("resetFinalResolution", "()V", "GetResetFinalResolutionHandler")]
		public unsafe virtual void ResetFinalResolution()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("resetFinalResolution.()V", this, null);
		}

		private static Delegate GetResetSolverVariables_Landroidx_constraintlayout_solver_Cache_Handler()
		{
			if ((object)cb_resetSolverVariables_Landroidx_constraintlayout_solver_Cache_ == null)
			{
				cb_resetSolverVariables_Landroidx_constraintlayout_solver_Cache_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ResetSolverVariables_Landroidx_constraintlayout_solver_Cache_));
			}
			return cb_resetSolverVariables_Landroidx_constraintlayout_solver_Cache_;
		}

		private static void n_ResetSolverVariables_Landroidx_constraintlayout_solver_Cache_(IntPtr jnienv, IntPtr native__this, IntPtr native_cache)
		{
			ConstraintWidget constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Cache cache = Java.Lang.Object.GetObject<Cache>(native_cache, JniHandleOwnership.DoNotTransfer);
			constraintWidget.ResetSolverVariables(cache);
		}

		[Register("resetSolverVariables", "(Landroidx/constraintlayout/solver/Cache;)V", "GetResetSolverVariables_Landroidx_constraintlayout_solver_Cache_Handler")]
		public unsafe virtual void ResetSolverVariables(Cache cache)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cache?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("resetSolverVariables.(Landroidx/constraintlayout/solver/Cache;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(cache);
			}
		}

		private static Delegate GetSetDebugSolverName_Landroidx_constraintlayout_solver_LinearSystem_Ljava_lang_String_Handler()
		{
			if ((object)cb_setDebugSolverName_Landroidx_constraintlayout_solver_LinearSystem_Ljava_lang_String_ == null)
			{
				cb_setDebugSolverName_Landroidx_constraintlayout_solver_LinearSystem_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_SetDebugSolverName_Landroidx_constraintlayout_solver_LinearSystem_Ljava_lang_String_));
			}
			return cb_setDebugSolverName_Landroidx_constraintlayout_solver_LinearSystem_Ljava_lang_String_;
		}

		private static void n_SetDebugSolverName_Landroidx_constraintlayout_solver_LinearSystem_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_system, IntPtr native_name)
		{
			ConstraintWidget constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			string name = JNIEnv.GetString(native_name, JniHandleOwnership.DoNotTransfer);
			constraintWidget.SetDebugSolverName(system, name);
		}

		[Register("setDebugSolverName", "(Landroidx/constraintlayout/solver/LinearSystem;Ljava/lang/String;)V", "GetSetDebugSolverName_Landroidx_constraintlayout_solver_LinearSystem_Ljava_lang_String_Handler")]
		public unsafe virtual void SetDebugSolverName(LinearSystem system, string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setDebugSolverName.(Landroidx/constraintlayout/solver/LinearSystem;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(system);
			}
		}

		private static Delegate GetSetDimension_IIHandler()
		{
			if ((object)cb_setDimension_II == null)
			{
				cb_setDimension_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetDimension_II));
			}
			return cb_setDimension_II;
		}

		private static void n_SetDimension_II(IntPtr jnienv, IntPtr native__this, int w, int h)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDimension(w, h);
		}

		[Register("setDimension", "(II)V", "GetSetDimension_IIHandler")]
		public unsafe virtual void SetDimension(int w, int h)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(w);
			ptr[1] = new JniArgumentValue(h);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDimension.(II)V", this, ptr);
		}

		private static Delegate GetSetDimensionRatio_FIHandler()
		{
			if ((object)cb_setDimensionRatio_FI == null)
			{
				cb_setDimensionRatio_FI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPFI_V(n_SetDimensionRatio_FI));
			}
			return cb_setDimensionRatio_FI;
		}

		private static void n_SetDimensionRatio_FI(IntPtr jnienv, IntPtr native__this, float ratio, int dimensionRatioSide)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetDimensionRatio(ratio, dimensionRatioSide);
		}

		[Register("setDimensionRatio", "(FI)V", "GetSetDimensionRatio_FIHandler")]
		public unsafe virtual void SetDimensionRatio(float ratio, int dimensionRatioSide)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(ratio);
			ptr[1] = new JniArgumentValue(dimensionRatioSide);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setDimensionRatio.(FI)V", this, ptr);
		}

		private static Delegate GetSetDimensionRatio_Ljava_lang_String_Handler()
		{
			if ((object)cb_setDimensionRatio_Ljava_lang_String_ == null)
			{
				cb_setDimensionRatio_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetDimensionRatio_Ljava_lang_String_));
			}
			return cb_setDimensionRatio_Ljava_lang_String_;
		}

		private static void n_SetDimensionRatio_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_ratio)
		{
			ConstraintWidget constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string dimensionRatio = JNIEnv.GetString(native_ratio, JniHandleOwnership.DoNotTransfer);
			constraintWidget.SetDimensionRatio(dimensionRatio);
		}

		[Register("setDimensionRatio", "(Ljava/lang/String;)V", "GetSetDimensionRatio_Ljava_lang_String_Handler")]
		public unsafe virtual void SetDimensionRatio(string ratio)
		{
			IntPtr intPtr = JNIEnv.NewString(ratio);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setDimensionRatio.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetSetFinalBaseline_IHandler()
		{
			if ((object)cb_setFinalBaseline_I == null)
			{
				cb_setFinalBaseline_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetFinalBaseline_I));
			}
			return cb_setFinalBaseline_I;
		}

		private static void n_SetFinalBaseline_I(IntPtr jnienv, IntPtr native__this, int baselineValue)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetFinalBaseline(baselineValue);
		}

		[Register("setFinalBaseline", "(I)V", "GetSetFinalBaseline_IHandler")]
		public unsafe virtual void SetFinalBaseline(int baselineValue)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(baselineValue);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFinalBaseline.(I)V", this, ptr);
		}

		private static Delegate GetSetFinalFrame_IIIIIIHandler()
		{
			if ((object)cb_setFinalFrame_IIIIII == null)
			{
				cb_setFinalFrame_IIIIII = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIIIIII_V(n_SetFinalFrame_IIIIII));
			}
			return cb_setFinalFrame_IIIIII;
		}

		private static void n_SetFinalFrame_IIIIII(IntPtr jnienv, IntPtr native__this, int left, int top, int right, int bottom, int baseline, int orientation)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetFinalFrame(left, top, right, bottom, baseline, orientation);
		}

		[Register("setFinalFrame", "(IIIIII)V", "GetSetFinalFrame_IIIIIIHandler")]
		public unsafe virtual void SetFinalFrame(int left, int top, int right, int bottom, int baseline, int orientation)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
			*ptr = new JniArgumentValue(left);
			ptr[1] = new JniArgumentValue(top);
			ptr[2] = new JniArgumentValue(right);
			ptr[3] = new JniArgumentValue(bottom);
			ptr[4] = new JniArgumentValue(baseline);
			ptr[5] = new JniArgumentValue(orientation);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFinalFrame.(IIIIII)V", this, ptr);
		}

		private static Delegate GetSetFinalHorizontal_IIHandler()
		{
			if ((object)cb_setFinalHorizontal_II == null)
			{
				cb_setFinalHorizontal_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetFinalHorizontal_II));
			}
			return cb_setFinalHorizontal_II;
		}

		private static void n_SetFinalHorizontal_II(IntPtr jnienv, IntPtr native__this, int x1, int x2)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetFinalHorizontal(x1, x2);
		}

		[Register("setFinalHorizontal", "(II)V", "GetSetFinalHorizontal_IIHandler")]
		public unsafe virtual void SetFinalHorizontal(int x1, int x2)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(x1);
			ptr[1] = new JniArgumentValue(x2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFinalHorizontal.(II)V", this, ptr);
		}

		private static Delegate GetSetFinalLeft_IHandler()
		{
			if ((object)cb_setFinalLeft_I == null)
			{
				cb_setFinalLeft_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetFinalLeft_I));
			}
			return cb_setFinalLeft_I;
		}

		private static void n_SetFinalLeft_I(IntPtr jnienv, IntPtr native__this, int x1)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetFinalLeft(x1);
		}

		[Register("setFinalLeft", "(I)V", "GetSetFinalLeft_IHandler")]
		public unsafe virtual void SetFinalLeft(int x1)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(x1);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFinalLeft.(I)V", this, ptr);
		}

		private static Delegate GetSetFinalTop_IHandler()
		{
			if ((object)cb_setFinalTop_I == null)
			{
				cb_setFinalTop_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetFinalTop_I));
			}
			return cb_setFinalTop_I;
		}

		private static void n_SetFinalTop_I(IntPtr jnienv, IntPtr native__this, int y1)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetFinalTop(y1);
		}

		[Register("setFinalTop", "(I)V", "GetSetFinalTop_IHandler")]
		public unsafe virtual void SetFinalTop(int y1)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(y1);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFinalTop.(I)V", this, ptr);
		}

		private static Delegate GetSetFinalVertical_IIHandler()
		{
			if ((object)cb_setFinalVertical_II == null)
			{
				cb_setFinalVertical_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetFinalVertical_II));
			}
			return cb_setFinalVertical_II;
		}

		private static void n_SetFinalVertical_II(IntPtr jnienv, IntPtr native__this, int y1, int y2)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetFinalVertical(y1, y2);
		}

		[Register("setFinalVertical", "(II)V", "GetSetFinalVertical_IIHandler")]
		public unsafe virtual void SetFinalVertical(int y1, int y2)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(y1);
			ptr[1] = new JniArgumentValue(y2);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFinalVertical.(II)V", this, ptr);
		}

		private static Delegate GetSetFrame_IIIHandler()
		{
			if ((object)cb_setFrame_III == null)
			{
				cb_setFrame_III = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIII_V(n_SetFrame_III));
			}
			return cb_setFrame_III;
		}

		private static void n_SetFrame_III(IntPtr jnienv, IntPtr native__this, int start, int end, int orientation)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetFrame(start, end, orientation);
		}

		[Register("setFrame", "(III)V", "GetSetFrame_IIIHandler")]
		public unsafe virtual void SetFrame(int start, int end, int orientation)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(start);
			ptr[1] = new JniArgumentValue(end);
			ptr[2] = new JniArgumentValue(orientation);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFrame.(III)V", this, ptr);
		}

		private static Delegate GetSetFrame_IIIIHandler()
		{
			if ((object)cb_setFrame_IIII == null)
			{
				cb_setFrame_IIII = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIIII_V(n_SetFrame_IIII));
			}
			return cb_setFrame_IIII;
		}

		private static void n_SetFrame_IIII(IntPtr jnienv, IntPtr native__this, int left, int top, int right, int bottom)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetFrame(left, top, right, bottom);
		}

		[Register("setFrame", "(IIII)V", "GetSetFrame_IIIIHandler")]
		public unsafe virtual void SetFrame(int left, int top, int right, int bottom)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(left);
			ptr[1] = new JniArgumentValue(top);
			ptr[2] = new JniArgumentValue(right);
			ptr[3] = new JniArgumentValue(bottom);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFrame.(IIII)V", this, ptr);
		}

		private static Delegate GetSetGoneMargin_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_IHandler()
		{
			if ((object)cb_setGoneMargin_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_I == null)
			{
				cb_setGoneMargin_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_V(n_SetGoneMargin_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_I));
			}
			return cb_setGoneMargin_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_I;
		}

		private static void n_SetGoneMargin_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_I(IntPtr jnienv, IntPtr native__this, IntPtr native_type, int goneMargin)
		{
			ConstraintWidget constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor.Type type = Java.Lang.Object.GetObject<ConstraintAnchor.Type>(native_type, JniHandleOwnership.DoNotTransfer);
			constraintWidget.SetGoneMargin(type, goneMargin);
		}

		[Register("setGoneMargin", "(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;I)V", "GetSetGoneMargin_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Type_IHandler")]
		public unsafe virtual void SetGoneMargin(ConstraintAnchor.Type type, int goneMargin)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(goneMargin);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setGoneMargin.(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(type);
			}
		}

		private static Delegate GetSetHorizontalDimension_IIHandler()
		{
			if ((object)cb_setHorizontalDimension_II == null)
			{
				cb_setHorizontalDimension_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetHorizontalDimension_II));
			}
			return cb_setHorizontalDimension_II;
		}

		private static void n_SetHorizontalDimension_II(IntPtr jnienv, IntPtr native__this, int left, int right)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHorizontalDimension(left, right);
		}

		[Register("setHorizontalDimension", "(II)V", "GetSetHorizontalDimension_IIHandler")]
		public unsafe virtual void SetHorizontalDimension(int left, int right)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(left);
			ptr[1] = new JniArgumentValue(right);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalDimension.(II)V", this, ptr);
		}

		private static Delegate GetSetHorizontalMatchStyle_IIIFHandler()
		{
			if ((object)cb_setHorizontalMatchStyle_IIIF == null)
			{
				cb_setHorizontalMatchStyle_IIIF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIIIF_V(n_SetHorizontalMatchStyle_IIIF));
			}
			return cb_setHorizontalMatchStyle_IIIF;
		}

		private static void n_SetHorizontalMatchStyle_IIIF(IntPtr jnienv, IntPtr native__this, int horizontalMatchStyle, int min, int max, float percent)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHorizontalMatchStyle(horizontalMatchStyle, min, max, percent);
		}

		[Register("setHorizontalMatchStyle", "(IIIF)V", "GetSetHorizontalMatchStyle_IIIFHandler")]
		public unsafe virtual void SetHorizontalMatchStyle(int horizontalMatchStyle, int min, int max, float percent)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(horizontalMatchStyle);
			ptr[1] = new JniArgumentValue(min);
			ptr[2] = new JniArgumentValue(max);
			ptr[3] = new JniArgumentValue(percent);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalMatchStyle.(IIIF)V", this, ptr);
		}

		private static Delegate GetSetHorizontalWeight_FHandler()
		{
			if ((object)cb_setHorizontalWeight_F == null)
			{
				cb_setHorizontalWeight_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetHorizontalWeight_F));
			}
			return cb_setHorizontalWeight_F;
		}

		private static void n_SetHorizontalWeight_F(IntPtr jnienv, IntPtr native__this, float horizontalWeight)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetHorizontalWeight(horizontalWeight);
		}

		[Register("setHorizontalWeight", "(F)V", "GetSetHorizontalWeight_FHandler")]
		public unsafe virtual void SetHorizontalWeight(float horizontalWeight)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(horizontalWeight);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setHorizontalWeight.(F)V", this, ptr);
		}

		private static Delegate GetSetInBarrier_IZHandler()
		{
			if ((object)cb_setInBarrier_IZ == null)
			{
				cb_setInBarrier_IZ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIZ_V(n_SetInBarrier_IZ));
			}
			return cb_setInBarrier_IZ;
		}

		private static void n_SetInBarrier_IZ(IntPtr jnienv, IntPtr native__this, int orientation, bool value)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetInBarrier(orientation, value);
		}

		[Register("setInBarrier", "(IZ)V", "GetSetInBarrier_IZHandler")]
		protected unsafe virtual void SetInBarrier(int orientation, bool value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(orientation);
			ptr[1] = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setInBarrier.(IZ)V", this, ptr);
		}

		private static Delegate GetSetLastMeasureSpec_IIHandler()
		{
			if ((object)cb_setLastMeasureSpec_II == null)
			{
				cb_setLastMeasureSpec_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetLastMeasureSpec_II));
			}
			return cb_setLastMeasureSpec_II;
		}

		private static void n_SetLastMeasureSpec_II(IntPtr jnienv, IntPtr native__this, int horizontal, int vertical)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetLastMeasureSpec(horizontal, vertical);
		}

		[Register("setLastMeasureSpec", "(II)V", "GetSetLastMeasureSpec_IIHandler")]
		public unsafe virtual void SetLastMeasureSpec(int horizontal, int vertical)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(horizontal);
			ptr[1] = new JniArgumentValue(vertical);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLastMeasureSpec.(II)V", this, ptr);
		}

		private static Delegate GetSetLength_IIHandler()
		{
			if ((object)cb_setLength_II == null)
			{
				cb_setLength_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetLength_II));
			}
			return cb_setLength_II;
		}

		private static void n_SetLength_II(IntPtr jnienv, IntPtr native__this, int length, int orientation)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetLength(length, orientation);
		}

		[Register("setLength", "(II)V", "GetSetLength_IIHandler")]
		public unsafe virtual void SetLength(int length, int orientation)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(length);
			ptr[1] = new JniArgumentValue(orientation);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLength.(II)V", this, ptr);
		}

		private static Delegate GetSetOffset_IIHandler()
		{
			if ((object)cb_setOffset_II == null)
			{
				cb_setOffset_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetOffset_II));
			}
			return cb_setOffset_II;
		}

		private static void n_SetOffset_II(IntPtr jnienv, IntPtr native__this, int x, int y)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetOffset(x, y);
		}

		[Register("setOffset", "(II)V", "GetSetOffset_IIHandler")]
		public unsafe virtual void SetOffset(int x, int y)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(x);
			ptr[1] = new JniArgumentValue(y);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOffset.(II)V", this, ptr);
		}

		private static Delegate GetSetOrigin_IIHandler()
		{
			if ((object)cb_setOrigin_II == null)
			{
				cb_setOrigin_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetOrigin_II));
			}
			return cb_setOrigin_II;
		}

		private static void n_SetOrigin_II(IntPtr jnienv, IntPtr native__this, int x, int y)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetOrigin(x, y);
		}

		[Register("setOrigin", "(II)V", "GetSetOrigin_IIHandler")]
		public unsafe virtual void SetOrigin(int x, int y)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(x);
			ptr[1] = new JniArgumentValue(y);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setOrigin.(II)V", this, ptr);
		}

		private static Delegate GetSetVerticalDimension_IIHandler()
		{
			if ((object)cb_setVerticalDimension_II == null)
			{
				cb_setVerticalDimension_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_SetVerticalDimension_II));
			}
			return cb_setVerticalDimension_II;
		}

		private static void n_SetVerticalDimension_II(IntPtr jnienv, IntPtr native__this, int top, int bottom)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetVerticalDimension(top, bottom);
		}

		[Register("setVerticalDimension", "(II)V", "GetSetVerticalDimension_IIHandler")]
		public unsafe virtual void SetVerticalDimension(int top, int bottom)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(top);
			ptr[1] = new JniArgumentValue(bottom);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalDimension.(II)V", this, ptr);
		}

		private static Delegate GetSetVerticalMatchStyle_IIIFHandler()
		{
			if ((object)cb_setVerticalMatchStyle_IIIF == null)
			{
				cb_setVerticalMatchStyle_IIIF = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIIIF_V(n_SetVerticalMatchStyle_IIIF));
			}
			return cb_setVerticalMatchStyle_IIIF;
		}

		private static void n_SetVerticalMatchStyle_IIIF(IntPtr jnienv, IntPtr native__this, int verticalMatchStyle, int min, int max, float percent)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetVerticalMatchStyle(verticalMatchStyle, min, max, percent);
		}

		[Register("setVerticalMatchStyle", "(IIIF)V", "GetSetVerticalMatchStyle_IIIFHandler")]
		public unsafe virtual void SetVerticalMatchStyle(int verticalMatchStyle, int min, int max, float percent)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(verticalMatchStyle);
			ptr[1] = new JniArgumentValue(min);
			ptr[2] = new JniArgumentValue(max);
			ptr[3] = new JniArgumentValue(percent);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalMatchStyle.(IIIF)V", this, ptr);
		}

		private static Delegate GetSetVerticalWeight_FHandler()
		{
			if ((object)cb_setVerticalWeight_F == null)
			{
				cb_setVerticalWeight_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetVerticalWeight_F));
			}
			return cb_setVerticalWeight_F;
		}

		private static void n_SetVerticalWeight_F(IntPtr jnienv, IntPtr native__this, float verticalWeight)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetVerticalWeight(verticalWeight);
		}

		[Register("setVerticalWeight", "(F)V", "GetSetVerticalWeight_FHandler")]
		public unsafe virtual void SetVerticalWeight(float verticalWeight)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(verticalWeight);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setVerticalWeight.(F)V", this, ptr);
		}

		private static Delegate GetSetX_IHandler()
		{
			if ((object)cb_setX_I == null)
			{
				cb_setX_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetX_I));
			}
			return cb_setX_I;
		}

		private static void n_SetX_I(IntPtr jnienv, IntPtr native__this, int x)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetX(x);
		}

		[Register("setX", "(I)V", "GetSetX_IHandler")]
		public unsafe virtual void SetX(int x)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(x);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setX.(I)V", this, ptr);
		}

		private static Delegate GetSetY_IHandler()
		{
			if ((object)cb_setY_I == null)
			{
				cb_setY_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetY_I));
			}
			return cb_setY_I;
		}

		private static void n_SetY_I(IntPtr jnienv, IntPtr native__this, int y)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetY(y);
		}

		[Register("setY", "(I)V", "GetSetY_IHandler")]
		public unsafe virtual void SetY(int y)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(y);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setY.(I)V", this, ptr);
		}

		private static Delegate GetSetupDimensionRatio_ZZZZHandler()
		{
			if ((object)cb_setupDimensionRatio_ZZZZ == null)
			{
				cb_setupDimensionRatio_ZZZZ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZZZZ_V(n_SetupDimensionRatio_ZZZZ));
			}
			return cb_setupDimensionRatio_ZZZZ;
		}

		private static void n_SetupDimensionRatio_ZZZZ(IntPtr jnienv, IntPtr native__this, bool hparentWrapContent, bool vparentWrapContent, bool horizontalDimensionFixed, bool verticalDimensionFixed)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetupDimensionRatio(hparentWrapContent, vparentWrapContent, horizontalDimensionFixed, verticalDimensionFixed);
		}

		[Register("setupDimensionRatio", "(ZZZZ)V", "GetSetupDimensionRatio_ZZZZHandler")]
		public unsafe virtual void SetupDimensionRatio(bool hparentWrapContent, bool vparentWrapContent, bool horizontalDimensionFixed, bool verticalDimensionFixed)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(hparentWrapContent);
			ptr[1] = new JniArgumentValue(vparentWrapContent);
			ptr[2] = new JniArgumentValue(horizontalDimensionFixed);
			ptr[3] = new JniArgumentValue(verticalDimensionFixed);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setupDimensionRatio.(ZZZZ)V", this, ptr);
		}

		private static Delegate GetUpdateFromRuns_ZZHandler()
		{
			if ((object)cb_updateFromRuns_ZZ == null)
			{
				cb_updateFromRuns_ZZ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZZ_V(n_UpdateFromRuns_ZZ));
			}
			return cb_updateFromRuns_ZZ;
		}

		private static void n_UpdateFromRuns_ZZ(IntPtr jnienv, IntPtr native__this, bool updateHorizontal, bool updateVertical)
		{
			Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UpdateFromRuns(updateHorizontal, updateVertical);
		}

		[Register("updateFromRuns", "(ZZ)V", "GetUpdateFromRuns_ZZHandler")]
		public unsafe virtual void UpdateFromRuns(bool updateHorizontal, bool updateVertical)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(updateHorizontal);
			ptr[1] = new JniArgumentValue(updateVertical);
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateFromRuns.(ZZ)V", this, ptr);
		}

		private static Delegate GetUpdateFromSolver_Landroidx_constraintlayout_solver_LinearSystem_ZHandler()
		{
			if ((object)cb_updateFromSolver_Landroidx_constraintlayout_solver_LinearSystem_Z == null)
			{
				cb_updateFromSolver_Landroidx_constraintlayout_solver_LinearSystem_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLZ_V(n_UpdateFromSolver_Landroidx_constraintlayout_solver_LinearSystem_Z));
			}
			return cb_updateFromSolver_Landroidx_constraintlayout_solver_LinearSystem_Z;
		}

		private static void n_UpdateFromSolver_Landroidx_constraintlayout_solver_LinearSystem_Z(IntPtr jnienv, IntPtr native__this, IntPtr native_system, bool optimize)
		{
			ConstraintWidget constraintWidget = Java.Lang.Object.GetObject<ConstraintWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			constraintWidget.UpdateFromSolver(system, optimize);
		}

		[Register("updateFromSolver", "(Landroidx/constraintlayout/solver/LinearSystem;Z)V", "GetUpdateFromSolver_Landroidx_constraintlayout_solver_LinearSystem_ZHandler")]
		public unsafe virtual void UpdateFromSolver(LinearSystem system, bool optimize)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(optimize);
				_members.InstanceMethods.InvokeVirtualVoidMethod("updateFromSolver.(Landroidx/constraintlayout/solver/LinearSystem;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(system);
			}
		}
	}
	[Register("androidx/constraintlayout/solver/widgets/ConstraintAnchor", DoNotGenerateAcw = true)]
	public class ConstraintAnchor : Java.Lang.Object
	{
		[Register("androidx/constraintlayout/solver/widgets/ConstraintAnchor$Type", DoNotGenerateAcw = true)]
		public sealed class Type : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/widgets/ConstraintAnchor$Type", typeof(Type));

			[Register("BASELINE")]
			public static Type Baseline => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("BASELINE.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("BOTTOM")]
			public static Type Bottom => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("BOTTOM.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("CENTER")]
			public static Type Center => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("CENTER.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("CENTER_X")]
			public static Type CenterX => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("CENTER_X.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("CENTER_Y")]
			public static Type CenterY => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("CENTER_Y.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("LEFT")]
			public static Type Left => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("LEFT.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("NONE")]
			public static Type None => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("NONE.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("RIGHT")]
			public static Type Right => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("RIGHT.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("TOP")]
			public static Type Top => Java.Lang.Object.GetObject<Type>(_members.StaticFields.GetObjectValue("TOP.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;").Handle, JniHandleOwnership.TransferLocalRef);

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override System.Type ThresholdType => _members.ManagedPeerType;

			internal Type(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;", "")]
			public unsafe static Type ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Type>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;", "")]
			public unsafe static Type[] Values()
			{
				return (Type[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(Type));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/widgets/ConstraintAnchor", typeof(ConstraintAnchor));

		private static Delegate cb_getType;

		private static Delegate cb_getDependents;

		private static Delegate cb_getFinalValue;

		private static Delegate cb_setFinalValue_I;

		private static Delegate cb_hasCenteredDependents;

		private static Delegate cb_hasDependents;

		private static Delegate cb_hasFinalValue;

		private static Delegate cb_isConnected;

		private static Delegate cb_isSideAnchor;

		private static Delegate cb_isVerticalAnchor;

		private static Delegate cb_getMargin;

		private static Delegate cb_setMargin_I;

		private static Delegate cb_getOwner;

		private static Delegate cb_getSolverVariable;

		private static Delegate cb_getTarget;

		private static Delegate cb_connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_I;

		private static Delegate cb_connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_IIZ;

		private static Delegate cb_copyFrom_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Ljava_util_HashMap_;

		private static Delegate cb_findDependents_ILjava_util_ArrayList_Landroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_;

		private static Delegate cb_isConnectionAllowed_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_;

		private static Delegate cb_isConnectionAllowed_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_;

		private static Delegate cb_isSimilarDimensionConnection_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_;

		private static Delegate cb_isValidConnection_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_;

		private static Delegate cb_reset;

		private static Delegate cb_resetFinalResolution;

		private static Delegate cb_resetSolverVariable_Landroidx_constraintlayout_solver_Cache_;

		private static Delegate cb_setGoneMargin_I;

		[Register("mMargin")]
		public int MMargin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mMargin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mMargin.I", this, value);
			}
		}

		[Register("mOwner")]
		public ConstraintWidget MOwner
		{
			get
			{
				return Java.Lang.Object.GetObject<ConstraintWidget>(_members.InstanceFields.GetObjectValue("mOwner.Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mOwner.Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mTarget")]
		public ConstraintAnchor MTarget
		{
			get
			{
				return Java.Lang.Object.GetObject<ConstraintAnchor>(_members.InstanceFields.GetObjectValue("mTarget.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mTarget.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mType")]
		public Type MType
		{
			get
			{
				return Java.Lang.Object.GetObject<Type>(_members.InstanceFields.GetObjectValue("mType.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mType.Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override System.Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual Type AnchorType
		{
			[Register("getType", "()Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;", "GetGetAnchorTypeHandler")]
			get
			{
				return Java.Lang.Object.GetObject<Type>(_members.InstanceMethods.InvokeVirtualObjectMethod("getType.()Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual HashSet Dependents
		{
			[Register("getDependents", "()Ljava/util/HashSet;", "GetGetDependentsHandler")]
			get
			{
				return Java.Lang.Object.GetObject<HashSet>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDependents.()Ljava/util/HashSet;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual int FinalValue
		{
			[Register("getFinalValue", "()I", "GetGetFinalValueHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getFinalValue.()I", this, null);
			}
			[Register("setFinalValue", "(I)V", "GetSetFinalValue_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setFinalValue.(I)V", this, ptr);
			}
		}

		public unsafe virtual bool HasCenteredDependents
		{
			[Register("hasCenteredDependents", "()Z", "GetHasCenteredDependentsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasCenteredDependents.()Z", this, null);
			}
		}

		public unsafe virtual bool HasDependents
		{
			[Register("hasDependents", "()Z", "GetHasDependentsHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasDependents.()Z", this, null);
			}
		}

		public unsafe virtual bool HasFinalValue
		{
			[Register("hasFinalValue", "()Z", "GetHasFinalValueHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasFinalValue.()Z", this, null);
			}
		}

		public unsafe virtual bool IsConnected
		{
			[Register("isConnected", "()Z", "GetIsConnectedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isConnected.()Z", this, null);
			}
		}

		public unsafe virtual bool IsSideAnchor
		{
			[Register("isSideAnchor", "()Z", "GetIsSideAnchorHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSideAnchor.()Z", this, null);
			}
		}

		public unsafe virtual bool IsVerticalAnchor
		{
			[Register("isVerticalAnchor", "()Z", "GetIsVerticalAnchorHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isVerticalAnchor.()Z", this, null);
			}
		}

		public unsafe virtual int Margin
		{
			[Register("getMargin", "()I", "GetGetMarginHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getMargin.()I", this, null);
			}
			[Register("setMargin", "(I)V", "GetSetMargin_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMargin.(I)V", this, ptr);
			}
		}

		public unsafe ConstraintAnchor Opposite
		{
			[Register("getOpposite", "()Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ConstraintAnchor>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getOpposite.()Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual ConstraintWidget Owner
		{
			[Register("getOwner", "()Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", "GetGetOwnerHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ConstraintWidget>(_members.InstanceMethods.InvokeVirtualObjectMethod("getOwner.()Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual SolverVariable SolverVariable
		{
			[Register("getSolverVariable", "()Landroidx/constraintlayout/solver/SolverVariable;", "GetGetSolverVariableHandler")]
			get
			{
				return Java.Lang.Object.GetObject<SolverVariable>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSolverVariable.()Landroidx/constraintlayout/solver/SolverVariable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual ConstraintAnchor Target
		{
			[Register("getTarget", "()Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", "GetGetTargetHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ConstraintAnchor>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTarget.()Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected ConstraintAnchor(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;)V", "")]
		public unsafe ConstraintAnchor(ConstraintWidget owner, Type type)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(owner?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(type?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Landroidx/constraintlayout/solver/widgets/ConstraintAnchor$Type;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(owner);
				GC.KeepAlive(type);
			}
		}

		private static Delegate GetGetAnchorTypeHandler()
		{
			if ((object)cb_getType == null)
			{
				cb_getType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAnchorType));
			}
			return cb_getType;
		}

		private static IntPtr n_GetAnchorType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnchorType);
		}

		private static Delegate GetGetDependentsHandler()
		{
			if ((object)cb_getDependents == null)
			{
				cb_getDependents = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDependents));
			}
			return cb_getDependents;
		}

		private static IntPtr n_GetDependents(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dependents);
		}

		private static Delegate GetGetFinalValueHandler()
		{
			if ((object)cb_getFinalValue == null)
			{
				cb_getFinalValue = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetFinalValue));
			}
			return cb_getFinalValue;
		}

		private static int n_GetFinalValue(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FinalValue;
		}

		private static Delegate GetSetFinalValue_IHandler()
		{
			if ((object)cb_setFinalValue_I == null)
			{
				cb_setFinalValue_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetFinalValue_I));
			}
			return cb_setFinalValue_I;
		}

		private static void n_SetFinalValue_I(IntPtr jnienv, IntPtr native__this, int finalValue)
		{
			Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FinalValue = finalValue;
		}

		private static Delegate GetHasCenteredDependentsHandler()
		{
			if ((object)cb_hasCenteredDependents == null)
			{
				cb_hasCenteredDependents = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasCenteredDependents));
			}
			return cb_hasCenteredDependents;
		}

		private static bool n_HasCenteredDependents(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasCenteredDependents;
		}

		private static Delegate GetHasDependentsHandler()
		{
			if ((object)cb_hasDependents == null)
			{
				cb_hasDependents = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasDependents));
			}
			return cb_hasDependents;
		}

		private static bool n_HasDependents(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasDependents;
		}

		private static Delegate GetHasFinalValueHandler()
		{
			if ((object)cb_hasFinalValue == null)
			{
				cb_hasFinalValue = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasFinalValue));
			}
			return cb_hasFinalValue;
		}

		private static bool n_HasFinalValue(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasFinalValue;
		}

		private static Delegate GetIsConnectedHandler()
		{
			if ((object)cb_isConnected == null)
			{
				cb_isConnected = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsConnected));
			}
			return cb_isConnected;
		}

		private static bool n_IsConnected(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsConnected;
		}

		private static Delegate GetIsSideAnchorHandler()
		{
			if ((object)cb_isSideAnchor == null)
			{
				cb_isSideAnchor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsSideAnchor));
			}
			return cb_isSideAnchor;
		}

		private static bool n_IsSideAnchor(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsSideAnchor;
		}

		private static Delegate GetIsVerticalAnchorHandler()
		{
			if ((object)cb_isVerticalAnchor == null)
			{
				cb_isVerticalAnchor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsVerticalAnchor));
			}
			return cb_isVerticalAnchor;
		}

		private static bool n_IsVerticalAnchor(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsVerticalAnchor;
		}

		private static Delegate GetGetMarginHandler()
		{
			if ((object)cb_getMargin == null)
			{
				cb_getMargin = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetMargin));
			}
			return cb_getMargin;
		}

		private static int n_GetMargin(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Margin;
		}

		private static Delegate GetSetMargin_IHandler()
		{
			if ((object)cb_setMargin_I == null)
			{
				cb_setMargin_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetMargin_I));
			}
			return cb_setMargin_I;
		}

		private static void n_SetMargin_I(IntPtr jnienv, IntPtr native__this, int margin)
		{
			Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Margin = margin;
		}

		private static Delegate GetGetOwnerHandler()
		{
			if ((object)cb_getOwner == null)
			{
				cb_getOwner = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOwner));
			}
			return cb_getOwner;
		}

		private static IntPtr n_GetOwner(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Owner);
		}

		private static Delegate GetGetSolverVariableHandler()
		{
			if ((object)cb_getSolverVariable == null)
			{
				cb_getSolverVariable = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSolverVariable));
			}
			return cb_getSolverVariable;
		}

		private static IntPtr n_GetSolverVariable(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SolverVariable);
		}

		private static Delegate GetGetTargetHandler()
		{
			if ((object)cb_getTarget == null)
			{
				cb_getTarget = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTarget));
			}
			return cb_getTarget;
		}

		private static IntPtr n_GetTarget(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Target);
		}

		private static Delegate GetConnect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_IHandler()
		{
			if ((object)cb_connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_I == null)
			{
				cb_connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_Z(n_Connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_I));
			}
			return cb_connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_I;
		}

		private static bool n_Connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_I(IntPtr jnienv, IntPtr native__this, IntPtr native_toAnchor, int margin)
		{
			ConstraintAnchor constraintAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor toAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(native_toAnchor, JniHandleOwnership.DoNotTransfer);
			return constraintAnchor.Connect(toAnchor, margin);
		}

		[Register("connect", "(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;I)Z", "GetConnect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_IHandler")]
		public unsafe virtual bool Connect(ConstraintAnchor toAnchor, int margin)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(toAnchor?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(margin);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("connect.(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;I)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(toAnchor);
			}
		}

		private static Delegate GetConnect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_IIZHandler()
		{
			if ((object)cb_connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_IIZ == null)
			{
				cb_connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_IIZ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLIIZ_Z(n_Connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_IIZ));
			}
			return cb_connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_IIZ;
		}

		private static bool n_Connect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_IIZ(IntPtr jnienv, IntPtr native__this, IntPtr native_toAnchor, int margin, int goneMargin, bool forceConnection)
		{
			ConstraintAnchor constraintAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor toAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(native_toAnchor, JniHandleOwnership.DoNotTransfer);
			return constraintAnchor.Connect(toAnchor, margin, goneMargin, forceConnection);
		}

		[Register("connect", "(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;IIZ)Z", "GetConnect_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_IIZHandler")]
		public unsafe virtual bool Connect(ConstraintAnchor toAnchor, int margin, int goneMargin, bool forceConnection)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(toAnchor?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(margin);
				ptr[2] = new JniArgumentValue(goneMargin);
				ptr[3] = new JniArgumentValue(forceConnection);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("connect.(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;IIZ)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(toAnchor);
			}
		}

		private static Delegate GetCopyFrom_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Ljava_util_HashMap_Handler()
		{
			if ((object)cb_copyFrom_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Ljava_util_HashMap_ == null)
			{
				cb_copyFrom_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Ljava_util_HashMap_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_CopyFrom_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Ljava_util_HashMap_));
			}
			return cb_copyFrom_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Ljava_util_HashMap_;
		}

		private static void n_CopyFrom_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Ljava_util_HashMap_(IntPtr jnienv, IntPtr native__this, IntPtr native_source, IntPtr native_map)
		{
			ConstraintAnchor constraintAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor source = Java.Lang.Object.GetObject<ConstraintAnchor>(native_source, JniHandleOwnership.DoNotTransfer);
			IDictionary<ConstraintWidget, ConstraintWidget> map = JavaDictionary<ConstraintWidget, ConstraintWidget>.FromJniHandle(native_map, JniHandleOwnership.DoNotTransfer);
			constraintAnchor.CopyFrom(source, map);
		}

		[Register("copyFrom", "(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;Ljava/util/HashMap;)V", "GetCopyFrom_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Ljava_util_HashMap_Handler")]
		public unsafe virtual void CopyFrom(ConstraintAnchor source, IDictionary<ConstraintWidget, ConstraintWidget> map)
		{
			IntPtr intPtr = JavaDictionary<ConstraintWidget, ConstraintWidget>.ToLocalJniHandle(map);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("copyFrom.(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;Ljava/util/HashMap;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(source);
				GC.KeepAlive(map);
			}
		}

		private static Delegate GetFindDependents_ILjava_util_ArrayList_Landroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_Handler()
		{
			if ((object)cb_findDependents_ILjava_util_ArrayList_Landroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_ == null)
			{
				cb_findDependents_ILjava_util_ArrayList_Landroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPILL_V(n_FindDependents_ILjava_util_ArrayList_Landroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_));
			}
			return cb_findDependents_ILjava_util_ArrayList_Landroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_;
		}

		private static void n_FindDependents_ILjava_util_ArrayList_Landroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_(IntPtr jnienv, IntPtr native__this, int orientation, IntPtr native_list, IntPtr native_group)
		{
			ConstraintAnchor constraintAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<WidgetGroup> list = JavaList<WidgetGroup>.FromJniHandle(native_list, JniHandleOwnership.DoNotTransfer);
			WidgetGroup widgetGroup = Java.Lang.Object.GetObject<WidgetGroup>(native_group, JniHandleOwnership.DoNotTransfer);
			constraintAnchor.FindDependents(orientation, list, widgetGroup);
		}

		[Register("findDependents", "(ILjava/util/ArrayList;Landroidx/constraintlayout/solver/widgets/analyzer/WidgetGroup;)V", "GetFindDependents_ILjava_util_ArrayList_Landroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_Handler")]
		public unsafe virtual void FindDependents(int orientation, IList<WidgetGroup> list, WidgetGroup group)
		{
			IntPtr intPtr = JavaList<WidgetGroup>.ToLocalJniHandle(list);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(orientation);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(group?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("findDependents.(ILjava/util/ArrayList;Landroidx/constraintlayout/solver/widgets/analyzer/WidgetGroup;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(list);
				GC.KeepAlive(group);
			}
		}

		private static Delegate GetIsConnectionAllowed_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Handler()
		{
			if ((object)cb_isConnectionAllowed_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_ == null)
			{
				cb_isConnectionAllowed_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_IsConnectionAllowed_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_));
			}
			return cb_isConnectionAllowed_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_;
		}

		private static bool n_IsConnectionAllowed_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_(IntPtr jnienv, IntPtr native__this, IntPtr native_target)
		{
			ConstraintAnchor constraintAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget target = Java.Lang.Object.GetObject<ConstraintWidget>(native_target, JniHandleOwnership.DoNotTransfer);
			return constraintAnchor.IsConnectionAllowed(target);
		}

		[Register("isConnectionAllowed", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)Z", "GetIsConnectionAllowed_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Handler")]
		public unsafe virtual bool IsConnectionAllowed(ConstraintWidget target)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isConnectionAllowed.(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(target);
			}
		}

		private static Delegate GetIsConnectionAllowed_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Handler()
		{
			if ((object)cb_isConnectionAllowed_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_ == null)
			{
				cb_isConnectionAllowed_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_Z(n_IsConnectionAllowed_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_));
			}
			return cb_isConnectionAllowed_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_;
		}

		private static bool n_IsConnectionAllowed_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_(IntPtr jnienv, IntPtr native__this, IntPtr native_target, IntPtr native_anchor)
		{
			ConstraintAnchor constraintAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget target = Java.Lang.Object.GetObject<ConstraintWidget>(native_target, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor anchor = Java.Lang.Object.GetObject<ConstraintAnchor>(native_anchor, JniHandleOwnership.DoNotTransfer);
			return constraintAnchor.IsConnectionAllowed(target, anchor);
		}

		[Register("isConnectionAllowed", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;)Z", "GetIsConnectionAllowed_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Handler")]
		public unsafe virtual bool IsConnectionAllowed(ConstraintWidget target, ConstraintAnchor anchor)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(anchor?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isConnectionAllowed.(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(target);
				GC.KeepAlive(anchor);
			}
		}

		private static Delegate GetIsSimilarDimensionConnection_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Handler()
		{
			if ((object)cb_isSimilarDimensionConnection_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_ == null)
			{
				cb_isSimilarDimensionConnection_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_IsSimilarDimensionConnection_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_));
			}
			return cb_isSimilarDimensionConnection_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_;
		}

		private static bool n_IsSimilarDimensionConnection_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_(IntPtr jnienv, IntPtr native__this, IntPtr native_anchor)
		{
			ConstraintAnchor constraintAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor anchor = Java.Lang.Object.GetObject<ConstraintAnchor>(native_anchor, JniHandleOwnership.DoNotTransfer);
			return constraintAnchor.IsSimilarDimensionConnection(anchor);
		}

		[Register("isSimilarDimensionConnection", "(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;)Z", "GetIsSimilarDimensionConnection_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Handler")]
		public unsafe virtual bool IsSimilarDimensionConnection(ConstraintAnchor anchor)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(anchor?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isSimilarDimensionConnection.(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(anchor);
			}
		}

		private static Delegate GetIsValidConnection_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Handler()
		{
			if ((object)cb_isValidConnection_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_ == null)
			{
				cb_isValidConnection_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_IsValidConnection_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_));
			}
			return cb_isValidConnection_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_;
		}

		private static bool n_IsValidConnection_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_(IntPtr jnienv, IntPtr native__this, IntPtr native_anchor)
		{
			ConstraintAnchor constraintAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor anchor = Java.Lang.Object.GetObject<ConstraintAnchor>(native_anchor, JniHandleOwnership.DoNotTransfer);
			return constraintAnchor.IsValidConnection(anchor);
		}

		[Register("isValidConnection", "(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;)Z", "GetIsValidConnection_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Handler")]
		public unsafe virtual bool IsValidConnection(ConstraintAnchor anchor)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(anchor?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isValidConnection.(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(anchor);
			}
		}

		private static Delegate GetResetHandler()
		{
			if ((object)cb_reset == null)
			{
				cb_reset = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Reset));
			}
			return cb_reset;
		}

		private static void n_Reset(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Reset();
		}

		[Register("reset", "()V", "GetResetHandler")]
		public unsafe virtual void Reset()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("reset.()V", this, null);
		}

		private static Delegate GetResetFinalResolutionHandler()
		{
			if ((object)cb_resetFinalResolution == null)
			{
				cb_resetFinalResolution = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ResetFinalResolution));
			}
			return cb_resetFinalResolution;
		}

		private static void n_ResetFinalResolution(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResetFinalResolution();
		}

		[Register("resetFinalResolution", "()V", "GetResetFinalResolutionHandler")]
		public unsafe virtual void ResetFinalResolution()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("resetFinalResolution.()V", this, null);
		}

		private static Delegate GetResetSolverVariable_Landroidx_constraintlayout_solver_Cache_Handler()
		{
			if ((object)cb_resetSolverVariable_Landroidx_constraintlayout_solver_Cache_ == null)
			{
				cb_resetSolverVariable_Landroidx_constraintlayout_solver_Cache_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ResetSolverVariable_Landroidx_constraintlayout_solver_Cache_));
			}
			return cb_resetSolverVariable_Landroidx_constraintlayout_solver_Cache_;
		}

		private static void n_ResetSolverVariable_Landroidx_constraintlayout_solver_Cache_(IntPtr jnienv, IntPtr native__this, IntPtr native_cache)
		{
			ConstraintAnchor constraintAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Cache cache = Java.Lang.Object.GetObject<Cache>(native_cache, JniHandleOwnership.DoNotTransfer);
			constraintAnchor.ResetSolverVariable(cache);
		}

		[Register("resetSolverVariable", "(Landroidx/constraintlayout/solver/Cache;)V", "GetResetSolverVariable_Landroidx_constraintlayout_solver_Cache_Handler")]
		public unsafe virtual void ResetSolverVariable(Cache cache)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cache?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("resetSolverVariable.(Landroidx/constraintlayout/solver/Cache;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(cache);
			}
		}

		private static Delegate GetSetGoneMargin_IHandler()
		{
			if ((object)cb_setGoneMargin_I == null)
			{
				cb_setGoneMargin_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetGoneMargin_I));
			}
			return cb_setGoneMargin_I;
		}

		private static void n_SetGoneMargin_I(IntPtr jnienv, IntPtr native__this, int margin)
		{
			Java.Lang.Object.GetObject<ConstraintAnchor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGoneMargin(margin);
		}

		[Register("setGoneMargin", "(I)V", "GetSetGoneMargin_IHandler")]
		public unsafe virtual void SetGoneMargin(int margin)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(margin);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setGoneMargin.(I)V", this, ptr);
		}
	}
	[Register("androidx/constraintlayout/solver/widgets/ConstraintWidgetContainer", DoNotGenerateAcw = true)]
	public class ConstraintWidgetContainer : WidgetContainer
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/widgets/ConstraintWidgetContainer", typeof(ConstraintWidgetContainer));

		private static Delegate cb_getHorizontalGuidelines;

		private static Delegate cb_isHeightMeasuredTooSmall;

		private static Delegate cb_isWidthMeasuredTooSmall;

		private static Delegate cb_getMeasurer;

		private static Delegate cb_setMeasurer_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measurer_;

		private static Delegate cb_getOptimizationLevel;

		private static Delegate cb_setOptimizationLevel_I;

		private static Delegate cb_isRtl;

		private static Delegate cb_setRtl_Z;

		private static Delegate cb_getSystem;

		private static Delegate cb_getVerticalGuidelines;

		private static Delegate cb_addChildrenToSolver_Landroidx_constraintlayout_solver_LinearSystem_;

		private static Delegate cb_addHorizontalWrapMaxVariable_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_;

		private static Delegate cb_addHorizontalWrapMinVariable_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_;

		private static Delegate cb_defineTerminalWidgets;

		private static Delegate cb_directMeasure_Z;

		private static Delegate cb_directMeasureSetup_Z;

		private static Delegate cb_directMeasureWithOrientation_ZI;

		private static Delegate cb_fillMetrics_Landroidx_constraintlayout_solver_Metrics_;

		private static Delegate cb_handlesInternalConstraints;

		private static Delegate cb_invalidateGraph;

		private static Delegate cb_invalidateMeasures;

		private static Delegate cb_measure_IIIIIIIII;

		private static Delegate cb_optimizeFor_I;

		private static Delegate cb_setPadding_IIII;

		private static Delegate cb_updateChildrenFromSolver_Landroidx_constraintlayout_solver_LinearSystem_arrayZ;

		private static Delegate cb_updateHierarchy;

		[Register("mDependencyGraph")]
		public DependencyGraph MDependencyGraph
		{
			get
			{
				return Java.Lang.Object.GetObject<DependencyGraph>(_members.InstanceFields.GetObjectValue("mDependencyGraph.Landroidx/constraintlayout/solver/widgets/analyzer/DependencyGraph;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mDependencyGraph.Landroidx/constraintlayout/solver/widgets/analyzer/DependencyGraph;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mGroupsWrapOptimized")]
		public bool MGroupsWrapOptimized
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("mGroupsWrapOptimized.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mGroupsWrapOptimized.Z", this, value);
			}
		}

		[Register("mHorizontalChainsSize")]
		public int MHorizontalChainsSize
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mHorizontalChainsSize.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mHorizontalChainsSize.I", this, value);
			}
		}

		[Register("mHorizontalWrapOptimized")]
		public bool MHorizontalWrapOptimized
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("mHorizontalWrapOptimized.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mHorizontalWrapOptimized.Z", this, value);
			}
		}

		[Register("mMeasure")]
		public BasicMeasure.Measure MMeasure
		{
			get
			{
				return Java.Lang.Object.GetObject<BasicMeasure.Measure>(_members.InstanceFields.GetObjectValue("mMeasure.Landroidx/constraintlayout/solver/widgets/analyzer/BasicMeasure$Measure;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mMeasure.Landroidx/constraintlayout/solver/widgets/analyzer/BasicMeasure$Measure;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mMeasurer")]
		protected BasicMeasure.IMeasurer MMeasurer
		{
			get
			{
				return Java.Lang.Object.GetObject<BasicMeasure.IMeasurer>(_members.InstanceFields.GetObjectValue("mMeasurer.Landroidx/constraintlayout/solver/widgets/analyzer/BasicMeasure$Measurer;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mMeasurer.Landroidx/constraintlayout/solver/widgets/analyzer/BasicMeasure$Measurer;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mMetrics")]
		public Metrics MMetrics
		{
			get
			{
				return Java.Lang.Object.GetObject<Metrics>(_members.InstanceFields.GetObjectValue("mMetrics.Landroidx/constraintlayout/solver/Metrics;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mMetrics.Landroidx/constraintlayout/solver/Metrics;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mSkipSolver")]
		public bool MSkipSolver
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("mSkipSolver.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mSkipSolver.Z", this, value);
			}
		}

		[Register("mSystem")]
		protected LinearSystem MSystem
		{
			get
			{
				return Java.Lang.Object.GetObject<LinearSystem>(_members.InstanceFields.GetObjectValue("mSystem.Landroidx/constraintlayout/solver/LinearSystem;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mSystem.Landroidx/constraintlayout/solver/LinearSystem;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mVerticalChainsSize")]
		public int MVerticalChainsSize
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mVerticalChainsSize.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mVerticalChainsSize.I", this, value);
			}
		}

		[Register("mVerticalWrapOptimized")]
		public bool MVerticalWrapOptimized
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("mVerticalWrapOptimized.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mVerticalWrapOptimized.Z", this, value);
			}
		}

		[Register("mWrapFixedHeight")]
		public int MWrapFixedHeight
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mWrapFixedHeight.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mWrapFixedHeight.I", this, value);
			}
		}

		[Register("mWrapFixedWidth")]
		public int MWrapFixedWidth
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mWrapFixedWidth.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mWrapFixedWidth.I", this, value);
			}
		}

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<Guideline> HorizontalGuidelines
		{
			[Register("getHorizontalGuidelines", "()Ljava/util/ArrayList;", "GetGetHorizontalGuidelinesHandler")]
			get
			{
				return JavaList<Guideline>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getHorizontalGuidelines.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool IsHeightMeasuredTooSmall
		{
			[Register("isHeightMeasuredTooSmall", "()Z", "GetIsHeightMeasuredTooSmallHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isHeightMeasuredTooSmall.()Z", this, null);
			}
		}

		public unsafe virtual bool IsWidthMeasuredTooSmall
		{
			[Register("isWidthMeasuredTooSmall", "()Z", "GetIsWidthMeasuredTooSmallHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isWidthMeasuredTooSmall.()Z", this, null);
			}
		}

		public unsafe virtual BasicMeasure.IMeasurer Measurer
		{
			[Register("getMeasurer", "()Landroidx/constraintlayout/solver/widgets/analyzer/BasicMeasure$Measurer;", "GetGetMeasurerHandler")]
			get
			{
				return Java.Lang.Object.GetObject<BasicMeasure.IMeasurer>(_members.InstanceMethods.InvokeVirtualObjectMethod("getMeasurer.()Landroidx/constraintlayout/solver/widgets/analyzer/BasicMeasure$Measurer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setMeasurer", "(Landroidx/constraintlayout/solver/widgets/analyzer/BasicMeasure$Measurer;)V", "GetSetMeasurer_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measurer_Handler")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((value == null) ? IntPtr.Zero : ((Java.Lang.Object)value).Handle);
					_members.InstanceMethods.InvokeVirtualVoidMethod("setMeasurer.(Landroidx/constraintlayout/solver/widgets/analyzer/BasicMeasure$Measurer;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe virtual int OptimizationLevel
		{
			[Register("getOptimizationLevel", "()I", "GetGetOptimizationLevelHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getOptimizationLevel.()I", this, null);
			}
			[Register("setOptimizationLevel", "(I)V", "GetSetOptimizationLevel_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setOptimizationLevel.(I)V", this, ptr);
			}
		}

		public unsafe virtual bool Rtl
		{
			[Register("isRtl", "()Z", "GetIsRtlHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isRtl.()Z", this, null);
			}
			[Register("setRtl", "(Z)V", "GetSetRtl_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setRtl.(Z)V", this, ptr);
			}
		}

		public unsafe virtual LinearSystem System
		{
			[Register("getSystem", "()Landroidx/constraintlayout/solver/LinearSystem;", "GetGetSystemHandler")]
			get
			{
				return Java.Lang.Object.GetObject<LinearSystem>(_members.InstanceMethods.InvokeVirtualObjectMethod("getSystem.()Landroidx/constraintlayout/solver/LinearSystem;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual IList<Guideline> VerticalGuidelines
		{
			[Register("getVerticalGuidelines", "()Ljava/util/ArrayList;", "GetGetVerticalGuidelinesHandler")]
			get
			{
				return JavaList<Guideline>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getVerticalGuidelines.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected ConstraintWidgetContainer(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ConstraintWidgetContainer()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(II)V", "")]
		public unsafe ConstraintWidgetContainer(int width, int height)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(width);
				ptr[1] = new JniArgumentValue(height);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
			}
		}

		[Register(".ctor", "(IIII)V", "")]
		public unsafe ConstraintWidgetContainer(int x, int y, int width, int height)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(x);
				ptr[1] = new JniArgumentValue(y);
				ptr[2] = new JniArgumentValue(width);
				ptr[3] = new JniArgumentValue(height);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(IIII)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(IIII)V", this, ptr);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;II)V", "")]
		public unsafe ConstraintWidgetContainer(string debugName, int width, int height)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(debugName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(width);
				ptr[2] = new JniArgumentValue(height);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;II)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetGetHorizontalGuidelinesHandler()
		{
			if ((object)cb_getHorizontalGuidelines == null)
			{
				cb_getHorizontalGuidelines = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetHorizontalGuidelines));
			}
			return cb_getHorizontalGuidelines;
		}

		private static IntPtr n_GetHorizontalGuidelines(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList<Guideline>.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HorizontalGuidelines);
		}

		private static Delegate GetIsHeightMeasuredTooSmallHandler()
		{
			if ((object)cb_isHeightMeasuredTooSmall == null)
			{
				cb_isHeightMeasuredTooSmall = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsHeightMeasuredTooSmall));
			}
			return cb_isHeightMeasuredTooSmall;
		}

		private static bool n_IsHeightMeasuredTooSmall(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsHeightMeasuredTooSmall;
		}

		private static Delegate GetIsWidthMeasuredTooSmallHandler()
		{
			if ((object)cb_isWidthMeasuredTooSmall == null)
			{
				cb_isWidthMeasuredTooSmall = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsWidthMeasuredTooSmall));
			}
			return cb_isWidthMeasuredTooSmall;
		}

		private static bool n_IsWidthMeasuredTooSmall(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsWidthMeasuredTooSmall;
		}

		private static Delegate GetGetMeasurerHandler()
		{
			if ((object)cb_getMeasurer == null)
			{
				cb_getMeasurer = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMeasurer));
			}
			return cb_getMeasurer;
		}

		private static IntPtr n_GetMeasurer(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Measurer);
		}

		private static Delegate GetSetMeasurer_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measurer_Handler()
		{
			if ((object)cb_setMeasurer_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measurer_ == null)
			{
				cb_setMeasurer_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measurer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetMeasurer_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measurer_));
			}
			return cb_setMeasurer_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measurer_;
		}

		private static void n_SetMeasurer_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measurer_(IntPtr jnienv, IntPtr native__this, IntPtr native_measurer)
		{
			ConstraintWidgetContainer constraintWidgetContainer = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BasicMeasure.IMeasurer measurer = Java.Lang.Object.GetObject<BasicMeasure.IMeasurer>(native_measurer, JniHandleOwnership.DoNotTransfer);
			constraintWidgetContainer.Measurer = measurer;
		}

		private static Delegate GetGetOptimizationLevelHandler()
		{
			if ((object)cb_getOptimizationLevel == null)
			{
				cb_getOptimizationLevel = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetOptimizationLevel));
			}
			return cb_getOptimizationLevel;
		}

		private static int n_GetOptimizationLevel(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OptimizationLevel;
		}

		private static Delegate GetSetOptimizationLevel_IHandler()
		{
			if ((object)cb_setOptimizationLevel_I == null)
			{
				cb_setOptimizationLevel_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetOptimizationLevel_I));
			}
			return cb_setOptimizationLevel_I;
		}

		private static void n_SetOptimizationLevel_I(IntPtr jnienv, IntPtr native__this, int value)
		{
			Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OptimizationLevel = value;
		}

		private static Delegate GetIsRtlHandler()
		{
			if ((object)cb_isRtl == null)
			{
				cb_isRtl = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsRtl));
			}
			return cb_isRtl;
		}

		private static bool n_IsRtl(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Rtl;
		}

		private static Delegate GetSetRtl_ZHandler()
		{
			if ((object)cb_setRtl_Z == null)
			{
				cb_setRtl_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetRtl_Z));
			}
			return cb_setRtl_Z;
		}

		private static void n_SetRtl_Z(IntPtr jnienv, IntPtr native__this, bool isRtl)
		{
			Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Rtl = isRtl;
		}

		private static Delegate GetGetSystemHandler()
		{
			if ((object)cb_getSystem == null)
			{
				cb_getSystem = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSystem));
			}
			return cb_getSystem;
		}

		private static IntPtr n_GetSystem(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).System);
		}

		private static Delegate GetGetVerticalGuidelinesHandler()
		{
			if ((object)cb_getVerticalGuidelines == null)
			{
				cb_getVerticalGuidelines = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetVerticalGuidelines));
			}
			return cb_getVerticalGuidelines;
		}

		private static IntPtr n_GetVerticalGuidelines(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList<Guideline>.ToLocalJniHandle(Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).VerticalGuidelines);
		}

		private static Delegate GetAddChildrenToSolver_Landroidx_constraintlayout_solver_LinearSystem_Handler()
		{
			if ((object)cb_addChildrenToSolver_Landroidx_constraintlayout_solver_LinearSystem_ == null)
			{
				cb_addChildrenToSolver_Landroidx_constraintlayout_solver_LinearSystem_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_AddChildrenToSolver_Landroidx_constraintlayout_solver_LinearSystem_));
			}
			return cb_addChildrenToSolver_Landroidx_constraintlayout_solver_LinearSystem_;
		}

		private static bool n_AddChildrenToSolver_Landroidx_constraintlayout_solver_LinearSystem_(IntPtr jnienv, IntPtr native__this, IntPtr native_system)
		{
			ConstraintWidgetContainer constraintWidgetContainer = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			return constraintWidgetContainer.AddChildrenToSolver(system);
		}

		[Register("addChildrenToSolver", "(Landroidx/constraintlayout/solver/LinearSystem;)Z", "GetAddChildrenToSolver_Landroidx_constraintlayout_solver_LinearSystem_Handler")]
		public unsafe virtual bool AddChildrenToSolver(LinearSystem system)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("addChildrenToSolver.(Landroidx/constraintlayout/solver/LinearSystem;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(system);
			}
		}

		private static Delegate GetAddHorizontalWrapMaxVariable_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Handler()
		{
			if ((object)cb_addHorizontalWrapMaxVariable_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_ == null)
			{
				cb_addHorizontalWrapMaxVariable_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddHorizontalWrapMaxVariable_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_));
			}
			return cb_addHorizontalWrapMaxVariable_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_;
		}

		private static void n_AddHorizontalWrapMaxVariable_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_(IntPtr jnienv, IntPtr native__this, IntPtr native_right)
		{
			ConstraintWidgetContainer constraintWidgetContainer = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor right = Java.Lang.Object.GetObject<ConstraintAnchor>(native_right, JniHandleOwnership.DoNotTransfer);
			constraintWidgetContainer.AddHorizontalWrapMaxVariable(right);
		}

		[Register("addHorizontalWrapMaxVariable", "(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;)V", "GetAddHorizontalWrapMaxVariable_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Handler")]
		public unsafe virtual void AddHorizontalWrapMaxVariable(ConstraintAnchor right)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(right?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addHorizontalWrapMaxVariable.(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(right);
			}
		}

		private static Delegate GetAddHorizontalWrapMinVariable_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Handler()
		{
			if ((object)cb_addHorizontalWrapMinVariable_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_ == null)
			{
				cb_addHorizontalWrapMinVariable_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddHorizontalWrapMinVariable_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_));
			}
			return cb_addHorizontalWrapMinVariable_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_;
		}

		private static void n_AddHorizontalWrapMinVariable_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_(IntPtr jnienv, IntPtr native__this, IntPtr native_left)
		{
			ConstraintWidgetContainer constraintWidgetContainer = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor left = Java.Lang.Object.GetObject<ConstraintAnchor>(native_left, JniHandleOwnership.DoNotTransfer);
			constraintWidgetContainer.AddHorizontalWrapMinVariable(left);
		}

		[Register("addHorizontalWrapMinVariable", "(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;)V", "GetAddHorizontalWrapMinVariable_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Handler")]
		public unsafe virtual void AddHorizontalWrapMinVariable(ConstraintAnchor left)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(left?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addHorizontalWrapMinVariable.(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(left);
			}
		}

		private static Delegate GetDefineTerminalWidgetsHandler()
		{
			if ((object)cb_defineTerminalWidgets == null)
			{
				cb_defineTerminalWidgets = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_DefineTerminalWidgets));
			}
			return cb_defineTerminalWidgets;
		}

		private static void n_DefineTerminalWidgets(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DefineTerminalWidgets();
		}

		[Register("defineTerminalWidgets", "()V", "GetDefineTerminalWidgetsHandler")]
		public unsafe virtual void DefineTerminalWidgets()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("defineTerminalWidgets.()V", this, null);
		}

		private static Delegate GetDirectMeasure_ZHandler()
		{
			if ((object)cb_directMeasure_Z == null)
			{
				cb_directMeasure_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_Z(n_DirectMeasure_Z));
			}
			return cb_directMeasure_Z;
		}

		private static bool n_DirectMeasure_Z(IntPtr jnienv, IntPtr native__this, bool optimizeWrap)
		{
			return Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DirectMeasure(optimizeWrap);
		}

		[Register("directMeasure", "(Z)Z", "GetDirectMeasure_ZHandler")]
		public unsafe virtual bool DirectMeasure(bool optimizeWrap)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(optimizeWrap);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("directMeasure.(Z)Z", this, ptr);
		}

		private static Delegate GetDirectMeasureSetup_ZHandler()
		{
			if ((object)cb_directMeasureSetup_Z == null)
			{
				cb_directMeasureSetup_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_Z(n_DirectMeasureSetup_Z));
			}
			return cb_directMeasureSetup_Z;
		}

		private static bool n_DirectMeasureSetup_Z(IntPtr jnienv, IntPtr native__this, bool optimizeWrap)
		{
			return Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DirectMeasureSetup(optimizeWrap);
		}

		[Register("directMeasureSetup", "(Z)Z", "GetDirectMeasureSetup_ZHandler")]
		public unsafe virtual bool DirectMeasureSetup(bool optimizeWrap)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(optimizeWrap);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("directMeasureSetup.(Z)Z", this, ptr);
		}

		private static Delegate GetDirectMeasureWithOrientation_ZIHandler()
		{
			if ((object)cb_directMeasureWithOrientation_ZI == null)
			{
				cb_directMeasureWithOrientation_ZI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZI_Z(n_DirectMeasureWithOrientation_ZI));
			}
			return cb_directMeasureWithOrientation_ZI;
		}

		private static bool n_DirectMeasureWithOrientation_ZI(IntPtr jnienv, IntPtr native__this, bool optimizeWrap, int orientation)
		{
			return Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DirectMeasureWithOrientation(optimizeWrap, orientation);
		}

		[Register("directMeasureWithOrientation", "(ZI)Z", "GetDirectMeasureWithOrientation_ZIHandler")]
		public unsafe virtual bool DirectMeasureWithOrientation(bool optimizeWrap, int orientation)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(optimizeWrap);
			ptr[1] = new JniArgumentValue(orientation);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("directMeasureWithOrientation.(ZI)Z", this, ptr);
		}

		private static Delegate GetFillMetrics_Landroidx_constraintlayout_solver_Metrics_Handler()
		{
			if ((object)cb_fillMetrics_Landroidx_constraintlayout_solver_Metrics_ == null)
			{
				cb_fillMetrics_Landroidx_constraintlayout_solver_Metrics_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_FillMetrics_Landroidx_constraintlayout_solver_Metrics_));
			}
			return cb_fillMetrics_Landroidx_constraintlayout_solver_Metrics_;
		}

		private static void n_FillMetrics_Landroidx_constraintlayout_solver_Metrics_(IntPtr jnienv, IntPtr native__this, IntPtr native_metrics)
		{
			ConstraintWidgetContainer constraintWidgetContainer = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Metrics metrics = Java.Lang.Object.GetObject<Metrics>(native_metrics, JniHandleOwnership.DoNotTransfer);
			constraintWidgetContainer.FillMetrics(metrics);
		}

		[Register("fillMetrics", "(Landroidx/constraintlayout/solver/Metrics;)V", "GetFillMetrics_Landroidx_constraintlayout_solver_Metrics_Handler")]
		public unsafe virtual void FillMetrics(Metrics metrics)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(metrics?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("fillMetrics.(Landroidx/constraintlayout/solver/Metrics;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(metrics);
			}
		}

		private static Delegate GetHandlesInternalConstraintsHandler()
		{
			if ((object)cb_handlesInternalConstraints == null)
			{
				cb_handlesInternalConstraints = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HandlesInternalConstraints));
			}
			return cb_handlesInternalConstraints;
		}

		private static bool n_HandlesInternalConstraints(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HandlesInternalConstraints();
		}

		[Register("handlesInternalConstraints", "()Z", "GetHandlesInternalConstraintsHandler")]
		public unsafe virtual bool HandlesInternalConstraints()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("handlesInternalConstraints.()Z", this, null);
		}

		private static Delegate GetInvalidateGraphHandler()
		{
			if ((object)cb_invalidateGraph == null)
			{
				cb_invalidateGraph = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_InvalidateGraph));
			}
			return cb_invalidateGraph;
		}

		private static void n_InvalidateGraph(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvalidateGraph();
		}

		[Register("invalidateGraph", "()V", "GetInvalidateGraphHandler")]
		public unsafe virtual void InvalidateGraph()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("invalidateGraph.()V", this, null);
		}

		private static Delegate GetInvalidateMeasuresHandler()
		{
			if ((object)cb_invalidateMeasures == null)
			{
				cb_invalidateMeasures = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_InvalidateMeasures));
			}
			return cb_invalidateMeasures;
		}

		private static void n_InvalidateMeasures(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvalidateMeasures();
		}

		[Register("invalidateMeasures", "()V", "GetInvalidateMeasuresHandler")]
		public unsafe virtual void InvalidateMeasures()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("invalidateMeasures.()V", this, null);
		}

		[Register("measure", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Landroidx/constraintlayout/solver/widgets/analyzer/BasicMeasure$Measurer;Landroidx/constraintlayout/solver/widgets/analyzer/BasicMeasure$Measure;I)Z", "")]
		public unsafe static bool Measure(ConstraintWidget widget, BasicMeasure.IMeasurer measurer, BasicMeasure.Measure measure, int measureStrategy)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((measurer == null) ? IntPtr.Zero : ((Java.Lang.Object)measurer).Handle);
				ptr[2] = new JniArgumentValue(measure?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(measureStrategy);
				return _members.StaticMethods.InvokeBooleanMethod("measure.(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Landroidx/constraintlayout/solver/widgets/analyzer/BasicMeasure$Measurer;Landroidx/constraintlayout/solver/widgets/analyzer/BasicMeasure$Measure;I)Z", ptr);
			}
			finally
			{
				GC.KeepAlive(widget);
				GC.KeepAlive(measurer);
				GC.KeepAlive(measure);
			}
		}

		private static Delegate GetMeasure_IIIIIIIIIHandler()
		{
			if ((object)cb_measure_IIIIIIIII == null)
			{
				cb_measure_IIIIIIIII = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPIIIIIIIII_J(n_Measure_IIIIIIIII));
			}
			return cb_measure_IIIIIIIII;
		}

		private static long n_Measure_IIIIIIIII(IntPtr jnienv, IntPtr native__this, int optimizationLevel, int widthMode, int widthSize, int heightMode, int heightSize, int lastMeasureWidth, int lastMeasureHeight, int paddingX, int paddingY)
		{
			return Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Measure(optimizationLevel, widthMode, widthSize, heightMode, heightSize, lastMeasureWidth, lastMeasureHeight, paddingX, paddingY);
		}

		[Register("measure", "(IIIIIIIII)J", "GetMeasure_IIIIIIIIIHandler")]
		public unsafe virtual long Measure(int optimizationLevel, int widthMode, int widthSize, int heightMode, int heightSize, int lastMeasureWidth, int lastMeasureHeight, int paddingX, int paddingY)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[9];
			*ptr = new JniArgumentValue(optimizationLevel);
			ptr[1] = new JniArgumentValue(widthMode);
			ptr[2] = new JniArgumentValue(widthSize);
			ptr[3] = new JniArgumentValue(heightMode);
			ptr[4] = new JniArgumentValue(heightSize);
			ptr[5] = new JniArgumentValue(lastMeasureWidth);
			ptr[6] = new JniArgumentValue(lastMeasureHeight);
			ptr[7] = new JniArgumentValue(paddingX);
			ptr[8] = new JniArgumentValue(paddingY);
			return _members.InstanceMethods.InvokeVirtualInt64Method("measure.(IIIIIIIII)J", this, ptr);
		}

		private static Delegate GetOptimizeFor_IHandler()
		{
			if ((object)cb_optimizeFor_I == null)
			{
				cb_optimizeFor_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_Z(n_OptimizeFor_I));
			}
			return cb_optimizeFor_I;
		}

		private static bool n_OptimizeFor_I(IntPtr jnienv, IntPtr native__this, int feature)
		{
			return Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OptimizeFor(feature);
		}

		[Register("optimizeFor", "(I)Z", "GetOptimizeFor_IHandler")]
		public unsafe virtual bool OptimizeFor(int feature)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(feature);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("optimizeFor.(I)Z", this, ptr);
		}

		private static Delegate GetSetPadding_IIIIHandler()
		{
			if ((object)cb_setPadding_IIII == null)
			{
				cb_setPadding_IIII = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIIII_V(n_SetPadding_IIII));
			}
			return cb_setPadding_IIII;
		}

		private static void n_SetPadding_IIII(IntPtr jnienv, IntPtr native__this, int left, int top, int right, int bottom)
		{
			Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetPadding(left, top, right, bottom);
		}

		[Register("setPadding", "(IIII)V", "GetSetPadding_IIIIHandler")]
		public unsafe virtual void SetPadding(int left, int top, int right, int bottom)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(left);
			ptr[1] = new JniArgumentValue(top);
			ptr[2] = new JniArgumentValue(right);
			ptr[3] = new JniArgumentValue(bottom);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setPadding.(IIII)V", this, ptr);
		}

		private static Delegate GetUpdateChildrenFromSolver_Landroidx_constraintlayout_solver_LinearSystem_arrayZHandler()
		{
			if ((object)cb_updateChildrenFromSolver_Landroidx_constraintlayout_solver_LinearSystem_arrayZ == null)
			{
				cb_updateChildrenFromSolver_Landroidx_constraintlayout_solver_LinearSystem_arrayZ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_UpdateChildrenFromSolver_Landroidx_constraintlayout_solver_LinearSystem_arrayZ));
			}
			return cb_updateChildrenFromSolver_Landroidx_constraintlayout_solver_LinearSystem_arrayZ;
		}

		private static void n_UpdateChildrenFromSolver_Landroidx_constraintlayout_solver_LinearSystem_arrayZ(IntPtr jnienv, IntPtr native__this, IntPtr native_system, IntPtr native_flags)
		{
			ConstraintWidgetContainer constraintWidgetContainer = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			bool[] array = (bool[])JNIEnv.GetArray(native_flags, JniHandleOwnership.DoNotTransfer, typeof(bool));
			constraintWidgetContainer.UpdateChildrenFromSolver(system, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_flags);
			}
		}

		[Register("updateChildrenFromSolver", "(Landroidx/constraintlayout/solver/LinearSystem;[Z)V", "GetUpdateChildrenFromSolver_Landroidx_constraintlayout_solver_LinearSystem_arrayZHandler")]
		public unsafe virtual void UpdateChildrenFromSolver(LinearSystem system, bool[] flags)
		{
			IntPtr intPtr = JNIEnv.NewArray(flags);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("updateChildrenFromSolver.(Landroidx/constraintlayout/solver/LinearSystem;[Z)V", this, ptr);
			}
			finally
			{
				if (flags != null)
				{
					JNIEnv.CopyArray(intPtr, flags);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(system);
				GC.KeepAlive(flags);
			}
		}

		private static Delegate GetUpdateHierarchyHandler()
		{
			if ((object)cb_updateHierarchy == null)
			{
				cb_updateHierarchy = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_UpdateHierarchy));
			}
			return cb_updateHierarchy;
		}

		private static void n_UpdateHierarchy(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ConstraintWidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).UpdateHierarchy();
		}

		[Register("updateHierarchy", "()V", "GetUpdateHierarchyHandler")]
		public unsafe virtual void UpdateHierarchy()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("updateHierarchy.()V", this, null);
		}
	}
	[Register("androidx/constraintlayout/solver/widgets/Guideline", DoNotGenerateAcw = true)]
	public class Guideline : ConstraintWidget
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/widgets/Guideline", typeof(Guideline));

		private static Delegate cb_getAnchor;

		private static Delegate cb_isPercent;

		private static Delegate cb_getOrientation;

		private static Delegate cb_setOrientation_I;

		private static Delegate cb_getRelativeBegin;

		private static Delegate cb_getRelativeBehaviour;

		private static Delegate cb_getRelativeEnd;

		private static Delegate cb_getRelativePercent;

		private static Delegate cb_cyclePosition;

		private static Delegate cb_setFinalValue_I;

		private static Delegate cb_setGuideBegin_I;

		private static Delegate cb_setGuideEnd_I;

		private static Delegate cb_setGuidePercent_F;

		private static Delegate cb_setGuidePercent_I;

		private static Delegate cb_setMinimumPosition_I;

		[Register("mRelativeBegin")]
		protected int MRelativeBegin
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mRelativeBegin.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mRelativeBegin.I", this, value);
			}
		}

		[Register("mRelativeEnd")]
		protected int MRelativeEnd
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mRelativeEnd.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mRelativeEnd.I", this, value);
			}
		}

		[Register("mRelativePercent")]
		protected float MRelativePercent
		{
			get
			{
				return _members.InstanceFields.GetSingleValue("mRelativePercent.F", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mRelativePercent.F", this, value);
			}
		}

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual ConstraintAnchor Anchor
		{
			[Register("getAnchor", "()Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", "GetGetAnchorHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ConstraintAnchor>(_members.InstanceMethods.InvokeVirtualObjectMethod("getAnchor.()Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool IsPercent
		{
			[Register("isPercent", "()Z", "GetIsPercentHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isPercent.()Z", this, null);
			}
		}

		public unsafe virtual int Orientation
		{
			[Register("getOrientation", "()I", "GetGetOrientationHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getOrientation.()I", this, null);
			}
			[Register("setOrientation", "(I)V", "GetSetOrientation_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setOrientation.(I)V", this, ptr);
			}
		}

		public unsafe virtual int RelativeBegin
		{
			[Register("getRelativeBegin", "()I", "GetGetRelativeBeginHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getRelativeBegin.()I", this, null);
			}
		}

		public unsafe virtual int RelativeBehaviour
		{
			[Register("getRelativeBehaviour", "()I", "GetGetRelativeBehaviourHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getRelativeBehaviour.()I", this, null);
			}
		}

		public unsafe virtual int RelativeEnd
		{
			[Register("getRelativeEnd", "()I", "GetGetRelativeEndHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getRelativeEnd.()I", this, null);
			}
		}

		public unsafe virtual float RelativePercent
		{
			[Register("getRelativePercent", "()F", "GetGetRelativePercentHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualSingleMethod("getRelativePercent.()F", this, null);
			}
		}

		protected Guideline(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Guideline()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetAnchorHandler()
		{
			if ((object)cb_getAnchor == null)
			{
				cb_getAnchor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetAnchor));
			}
			return cb_getAnchor;
		}

		private static IntPtr n_GetAnchor(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Anchor);
		}

		private static Delegate GetIsPercentHandler()
		{
			if ((object)cb_isPercent == null)
			{
				cb_isPercent = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsPercent));
			}
			return cb_isPercent;
		}

		private static bool n_IsPercent(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsPercent;
		}

		private static Delegate GetGetOrientationHandler()
		{
			if ((object)cb_getOrientation == null)
			{
				cb_getOrientation = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetOrientation));
			}
			return cb_getOrientation;
		}

		private static int n_GetOrientation(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Orientation;
		}

		private static Delegate GetSetOrientation_IHandler()
		{
			if ((object)cb_setOrientation_I == null)
			{
				cb_setOrientation_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetOrientation_I));
			}
			return cb_setOrientation_I;
		}

		private static void n_SetOrientation_I(IntPtr jnienv, IntPtr native__this, int orientation)
		{
			Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Orientation = orientation;
		}

		private static Delegate GetGetRelativeBeginHandler()
		{
			if ((object)cb_getRelativeBegin == null)
			{
				cb_getRelativeBegin = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetRelativeBegin));
			}
			return cb_getRelativeBegin;
		}

		private static int n_GetRelativeBegin(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RelativeBegin;
		}

		private static Delegate GetGetRelativeBehaviourHandler()
		{
			if ((object)cb_getRelativeBehaviour == null)
			{
				cb_getRelativeBehaviour = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetRelativeBehaviour));
			}
			return cb_getRelativeBehaviour;
		}

		private static int n_GetRelativeBehaviour(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RelativeBehaviour;
		}

		private static Delegate GetGetRelativeEndHandler()
		{
			if ((object)cb_getRelativeEnd == null)
			{
				cb_getRelativeEnd = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetRelativeEnd));
			}
			return cb_getRelativeEnd;
		}

		private static int n_GetRelativeEnd(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RelativeEnd;
		}

		private static Delegate GetGetRelativePercentHandler()
		{
			if ((object)cb_getRelativePercent == null)
			{
				cb_getRelativePercent = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_F(n_GetRelativePercent));
			}
			return cb_getRelativePercent;
		}

		private static float n_GetRelativePercent(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RelativePercent;
		}

		private static Delegate GetCyclePositionHandler()
		{
			if ((object)cb_cyclePosition == null)
			{
				cb_cyclePosition = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_CyclePosition));
			}
			return cb_cyclePosition;
		}

		private static void n_CyclePosition(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CyclePosition();
		}

		[Register("cyclePosition", "()V", "GetCyclePositionHandler")]
		public unsafe virtual void CyclePosition()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("cyclePosition.()V", this, null);
		}

		private static Delegate GetSetFinalValue_IHandler()
		{
			if ((object)cb_setFinalValue_I == null)
			{
				cb_setFinalValue_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetFinalValue_I));
			}
			return cb_setFinalValue_I;
		}

		private static void n_SetFinalValue_I(IntPtr jnienv, IntPtr native__this, int position)
		{
			Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetFinalValue(position);
		}

		[Register("setFinalValue", "(I)V", "GetSetFinalValue_IHandler")]
		public unsafe virtual void SetFinalValue(int position)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(position);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setFinalValue.(I)V", this, ptr);
		}

		private static Delegate GetSetGuideBegin_IHandler()
		{
			if ((object)cb_setGuideBegin_I == null)
			{
				cb_setGuideBegin_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetGuideBegin_I));
			}
			return cb_setGuideBegin_I;
		}

		private static void n_SetGuideBegin_I(IntPtr jnienv, IntPtr native__this, int value)
		{
			Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGuideBegin(value);
		}

		[Register("setGuideBegin", "(I)V", "GetSetGuideBegin_IHandler")]
		public unsafe virtual void SetGuideBegin(int value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setGuideBegin.(I)V", this, ptr);
		}

		private static Delegate GetSetGuideEnd_IHandler()
		{
			if ((object)cb_setGuideEnd_I == null)
			{
				cb_setGuideEnd_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetGuideEnd_I));
			}
			return cb_setGuideEnd_I;
		}

		private static void n_SetGuideEnd_I(IntPtr jnienv, IntPtr native__this, int value)
		{
			Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGuideEnd(value);
		}

		[Register("setGuideEnd", "(I)V", "GetSetGuideEnd_IHandler")]
		public unsafe virtual void SetGuideEnd(int value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setGuideEnd.(I)V", this, ptr);
		}

		private static Delegate GetSetGuidePercent_FHandler()
		{
			if ((object)cb_setGuidePercent_F == null)
			{
				cb_setGuidePercent_F = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPF_V(n_SetGuidePercent_F));
			}
			return cb_setGuidePercent_F;
		}

		private static void n_SetGuidePercent_F(IntPtr jnienv, IntPtr native__this, float value)
		{
			Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGuidePercent(value);
		}

		[Register("setGuidePercent", "(F)V", "GetSetGuidePercent_FHandler")]
		public unsafe virtual void SetGuidePercent(float value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setGuidePercent.(F)V", this, ptr);
		}

		private static Delegate GetSetGuidePercent_IHandler()
		{
			if ((object)cb_setGuidePercent_I == null)
			{
				cb_setGuidePercent_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetGuidePercent_I));
			}
			return cb_setGuidePercent_I;
		}

		private static void n_SetGuidePercent_I(IntPtr jnienv, IntPtr native__this, int value)
		{
			Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetGuidePercent(value);
		}

		[Register("setGuidePercent", "(I)V", "GetSetGuidePercent_IHandler")]
		public unsafe virtual void SetGuidePercent(int value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setGuidePercent.(I)V", this, ptr);
		}

		private static Delegate GetSetMinimumPosition_IHandler()
		{
			if ((object)cb_setMinimumPosition_I == null)
			{
				cb_setMinimumPosition_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetMinimumPosition_I));
			}
			return cb_setMinimumPosition_I;
		}

		private static void n_SetMinimumPosition_I(IntPtr jnienv, IntPtr native__this, int minimum)
		{
			Java.Lang.Object.GetObject<Guideline>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SetMinimumPosition(minimum);
		}

		[Register("setMinimumPosition", "(I)V", "GetSetMinimumPosition_IHandler")]
		public unsafe virtual void SetMinimumPosition(int minimum)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(minimum);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setMinimumPosition.(I)V", this, ptr);
		}
	}
	[Register("androidx/constraintlayout/solver/widgets/HelperWidget", DoNotGenerateAcw = true)]
	public class HelperWidget : ConstraintWidget, IHelper, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/widgets/HelperWidget", typeof(HelperWidget));

		private static Delegate cb_add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_;

		private static Delegate cb_addDependents_Ljava_util_ArrayList_ILandroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_;

		private static Delegate cb_findGroupInDependents_I;

		private static Delegate cb_removeAllIds;

		private static Delegate cb_updateConstraints_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_;

		[Register("mWidgets")]
		public IList<ConstraintWidget> MWidgets
		{
			get
			{
				return Android.Runtime.JavaArray<ConstraintWidget>.FromJniHandle(_members.InstanceFields.GetObjectValue("mWidgets.[Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = Android.Runtime.JavaArray<ConstraintWidget>.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mWidgets.[Landroidx/constraintlayout/solver/widgets/ConstraintWidget;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mWidgetsCount")]
		public int MWidgetsCount
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("mWidgetsCount.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("mWidgetsCount.I", this, value);
			}
		}

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected HelperWidget(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe HelperWidget()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetAdd_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Handler()
		{
			if ((object)cb_add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_ == null)
			{
				cb_add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_));
			}
			return cb_add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_;
		}

		private static void n_Add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_(IntPtr jnienv, IntPtr native__this, IntPtr native_widget)
		{
			HelperWidget helperWidget = Java.Lang.Object.GetObject<HelperWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget widget = Java.Lang.Object.GetObject<ConstraintWidget>(native_widget, JniHandleOwnership.DoNotTransfer);
			helperWidget.Add(widget);
		}

		[Register("add", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)V", "GetAdd_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Handler")]
		public unsafe virtual void Add(ConstraintWidget widget)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("add.(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(widget);
			}
		}

		private static Delegate GetAddDependents_Ljava_util_ArrayList_ILandroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_Handler()
		{
			if ((object)cb_addDependents_Ljava_util_ArrayList_ILandroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_ == null)
			{
				cb_addDependents_Ljava_util_ArrayList_ILandroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLIL_V(n_AddDependents_Ljava_util_ArrayList_ILandroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_));
			}
			return cb_addDependents_Ljava_util_ArrayList_ILandroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_;
		}

		private static void n_AddDependents_Ljava_util_ArrayList_ILandroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_(IntPtr jnienv, IntPtr native__this, IntPtr native_dependencyLists, int orientation, IntPtr native_group)
		{
			HelperWidget helperWidget = Java.Lang.Object.GetObject<HelperWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<WidgetGroup> dependencyLists = JavaList<WidgetGroup>.FromJniHandle(native_dependencyLists, JniHandleOwnership.DoNotTransfer);
			WidgetGroup widgetGroup = Java.Lang.Object.GetObject<WidgetGroup>(native_group, JniHandleOwnership.DoNotTransfer);
			helperWidget.AddDependents(dependencyLists, orientation, widgetGroup);
		}

		[Register("addDependents", "(Ljava/util/ArrayList;ILandroidx/constraintlayout/solver/widgets/analyzer/WidgetGroup;)V", "GetAddDependents_Ljava_util_ArrayList_ILandroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_Handler")]
		public unsafe virtual void AddDependents(IList<WidgetGroup> dependencyLists, int orientation, WidgetGroup group)
		{
			IntPtr intPtr = JavaList<WidgetGroup>.ToLocalJniHandle(dependencyLists);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(orientation);
				ptr[2] = new JniArgumentValue(group?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addDependents.(Ljava/util/ArrayList;ILandroidx/constraintlayout/solver/widgets/analyzer/WidgetGroup;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(dependencyLists);
				GC.KeepAlive(group);
			}
		}

		private static Delegate GetFindGroupInDependents_IHandler()
		{
			if ((object)cb_findGroupInDependents_I == null)
			{
				cb_findGroupInDependents_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_I(n_FindGroupInDependents_I));
			}
			return cb_findGroupInDependents_I;
		}

		private static int n_FindGroupInDependents_I(IntPtr jnienv, IntPtr native__this, int orientation)
		{
			return Java.Lang.Object.GetObject<HelperWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).FindGroupInDependents(orientation);
		}

		[Register("findGroupInDependents", "(I)I", "GetFindGroupInDependents_IHandler")]
		public unsafe virtual int FindGroupInDependents(int orientation)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(orientation);
			return _members.InstanceMethods.InvokeVirtualInt32Method("findGroupInDependents.(I)I", this, ptr);
		}

		private static Delegate GetRemoveAllIdsHandler()
		{
			if ((object)cb_removeAllIds == null)
			{
				cb_removeAllIds = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_RemoveAllIds));
			}
			return cb_removeAllIds;
		}

		private static void n_RemoveAllIds(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<HelperWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveAllIds();
		}

		[Register("removeAllIds", "()V", "GetRemoveAllIdsHandler")]
		public unsafe virtual void RemoveAllIds()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeAllIds.()V", this, null);
		}

		private static Delegate GetUpdateConstraints_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_Handler()
		{
			if ((object)cb_updateConstraints_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_ == null)
			{
				cb_updateConstraints_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UpdateConstraints_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_));
			}
			return cb_updateConstraints_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_;
		}

		private static void n_UpdateConstraints_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_(IntPtr jnienv, IntPtr native__this, IntPtr native_container)
		{
			HelperWidget helperWidget = Java.Lang.Object.GetObject<HelperWidget>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidgetContainer container = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(native_container, JniHandleOwnership.DoNotTransfer);
			helperWidget.UpdateConstraints(container);
		}

		[Register("updateConstraints", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;)V", "GetUpdateConstraints_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_Handler")]
		public unsafe virtual void UpdateConstraints(ConstraintWidgetContainer container)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("updateConstraints.(Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(container);
			}
		}
	}
	[Register("androidx/constraintlayout/solver/widgets/Helper", "", "AndroidX.ConstraintLayout.Solver.Widgets.IHelperInvoker")]
	public interface IHelper : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("add", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)V", "GetAdd_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Handler:AndroidX.ConstraintLayout.Solver.Widgets.IHelperInvoker, Xamarin.AndroidX.ConstraintLayout.Solver")]
		void Add(ConstraintWidget p0);

		[Register("removeAllIds", "()V", "GetRemoveAllIdsHandler:AndroidX.ConstraintLayout.Solver.Widgets.IHelperInvoker, Xamarin.AndroidX.ConstraintLayout.Solver")]
		void RemoveAllIds();

		[Register("updateConstraints", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;)V", "GetUpdateConstraints_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_Handler:AndroidX.ConstraintLayout.Solver.Widgets.IHelperInvoker, Xamarin.AndroidX.ConstraintLayout.Solver")]
		void UpdateConstraints(ConstraintWidgetContainer p0);
	}
	[Register("androidx/constraintlayout/solver/widgets/Helper", DoNotGenerateAcw = true)]
	internal class IHelperInvoker : Java.Lang.Object, IHelper, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/widgets/Helper", typeof(IHelperInvoker));

		private IntPtr class_ref;

		private static Delegate cb_add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_;

		private IntPtr id_add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_;

		private static Delegate cb_removeAllIds;

		private IntPtr id_removeAllIds;

		private static Delegate cb_updateConstraints_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_;

		private IntPtr id_updateConstraints_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IHelper GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IHelper>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.constraintlayout.solver.widgets.Helper"));
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IHelperInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetAdd_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Handler()
		{
			if ((object)cb_add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_ == null)
			{
				cb_add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_));
			}
			return cb_add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_;
		}

		private static void n_Add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IHelper helper = Java.Lang.Object.GetObject<IHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget p = Java.Lang.Object.GetObject<ConstraintWidget>(native_p0, JniHandleOwnership.DoNotTransfer);
			helper.Add(p);
		}

		public unsafe void Add(ConstraintWidget p0)
		{
			if (id_add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_ == IntPtr.Zero)
			{
				id_add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_ = JNIEnv.GetMethodID(class_ref, "add", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_, ptr);
		}

		private static Delegate GetRemoveAllIdsHandler()
		{
			if ((object)cb_removeAllIds == null)
			{
				cb_removeAllIds = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_RemoveAllIds));
			}
			return cb_removeAllIds;
		}

		private static void n_RemoveAllIds(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<IHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveAllIds();
		}

		public void RemoveAllIds()
		{
			if (id_removeAllIds == IntPtr.Zero)
			{
				id_removeAllIds = JNIEnv.GetMethodID(class_ref, "removeAllIds", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_removeAllIds);
		}

		private static Delegate GetUpdateConstraints_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_Handler()
		{
			if ((object)cb_updateConstraints_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_ == null)
			{
				cb_updateConstraints_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UpdateConstraints_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_));
			}
			return cb_updateConstraints_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_;
		}

		private static void n_UpdateConstraints_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IHelper helper = Java.Lang.Object.GetObject<IHelper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidgetContainer p = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(native_p0, JniHandleOwnership.DoNotTransfer);
			helper.UpdateConstraints(p);
		}

		public unsafe void UpdateConstraints(ConstraintWidgetContainer p0)
		{
			if (id_updateConstraints_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_ == IntPtr.Zero)
			{
				id_updateConstraints_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_ = JNIEnv.GetMethodID(class_ref, "updateConstraints", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_updateConstraints_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_, ptr);
		}
	}
	[Register("androidx/constraintlayout/solver/widgets/WidgetContainer", DoNotGenerateAcw = true)]
	public class WidgetContainer : ConstraintWidget
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/widgets/WidgetContainer", typeof(WidgetContainer));

		private static Delegate cb_getChildren;

		private static Delegate cb_getRootConstraintContainer;

		private static Delegate cb_add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_;

		private static Delegate cb_add_arrayLandroidx_constraintlayout_solver_widgets_ConstraintWidget_;

		private static Delegate cb_layout;

		private static Delegate cb_remove_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_;

		private static Delegate cb_removeAllChildren;

		[Register("mChildren")]
		public System.Collections.IList MChildren
		{
			get
			{
				return JavaList.FromJniHandle(_members.InstanceFields.GetObjectValue("mChildren.Ljava/util/ArrayList;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JavaList.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mChildren.Ljava/util/ArrayList;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual IList<ConstraintWidget> Children
		{
			[Register("getChildren", "()Ljava/util/ArrayList;", "GetGetChildrenHandler")]
			get
			{
				return JavaList<ConstraintWidget>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getChildren.()Ljava/util/ArrayList;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual ConstraintWidgetContainer RootConstraintContainer
		{
			[Register("getRootConstraintContainer", "()Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;", "GetGetRootConstraintContainerHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ConstraintWidgetContainer>(_members.InstanceMethods.InvokeVirtualObjectMethod("getRootConstraintContainer.()Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected WidgetContainer(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe WidgetContainer()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(II)V", "")]
		public unsafe WidgetContainer(int width, int height)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(width);
				ptr[1] = new JniArgumentValue(height);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(II)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(II)V", this, ptr);
			}
		}

		[Register(".ctor", "(IIII)V", "")]
		public unsafe WidgetContainer(int x, int y, int width, int height)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(x);
				ptr[1] = new JniArgumentValue(y);
				ptr[2] = new JniArgumentValue(width);
				ptr[3] = new JniArgumentValue(height);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(IIII)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(IIII)V", this, ptr);
			}
		}

		private static Delegate GetGetChildrenHandler()
		{
			if ((object)cb_getChildren == null)
			{
				cb_getChildren = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetChildren));
			}
			return cb_getChildren;
		}

		private static IntPtr n_GetChildren(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList<ConstraintWidget>.ToLocalJniHandle(Java.Lang.Object.GetObject<WidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Children);
		}

		private static Delegate GetGetRootConstraintContainerHandler()
		{
			if ((object)cb_getRootConstraintContainer == null)
			{
				cb_getRootConstraintContainer = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetRootConstraintContainer));
			}
			return cb_getRootConstraintContainer;
		}

		private static IntPtr n_GetRootConstraintContainer(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RootConstraintContainer);
		}

		private static Delegate GetAdd_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Handler()
		{
			if ((object)cb_add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_ == null)
			{
				cb_add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_));
			}
			return cb_add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_;
		}

		private static void n_Add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_(IntPtr jnienv, IntPtr native__this, IntPtr native_widget)
		{
			WidgetContainer widgetContainer = Java.Lang.Object.GetObject<WidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget widget = Java.Lang.Object.GetObject<ConstraintWidget>(native_widget, JniHandleOwnership.DoNotTransfer);
			widgetContainer.Add(widget);
		}

		[Register("add", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)V", "GetAdd_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Handler")]
		public unsafe virtual void Add(ConstraintWidget widget)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("add.(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(widget);
			}
		}

		private static Delegate GetAdd_arrayLandroidx_constraintlayout_solver_widgets_ConstraintWidget_Handler()
		{
			if ((object)cb_add_arrayLandroidx_constraintlayout_solver_widgets_ConstraintWidget_ == null)
			{
				cb_add_arrayLandroidx_constraintlayout_solver_widgets_ConstraintWidget_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Add_arrayLandroidx_constraintlayout_solver_widgets_ConstraintWidget_));
			}
			return cb_add_arrayLandroidx_constraintlayout_solver_widgets_ConstraintWidget_;
		}

		private static void n_Add_arrayLandroidx_constraintlayout_solver_widgets_ConstraintWidget_(IntPtr jnienv, IntPtr native__this, IntPtr native_widgets)
		{
			WidgetContainer widgetContainer = Java.Lang.Object.GetObject<WidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget[] array = (ConstraintWidget[])JNIEnv.GetArray(native_widgets, JniHandleOwnership.DoNotTransfer, typeof(ConstraintWidget));
			widgetContainer.Add(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_widgets);
			}
		}

		[Register("add", "([Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)V", "GetAdd_arrayLandroidx_constraintlayout_solver_widgets_ConstraintWidget_Handler")]
		public unsafe virtual void Add(params ConstraintWidget[] widgets)
		{
			IntPtr intPtr = JNIEnv.NewArray(widgets);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("add.([Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)V", this, ptr);
			}
			finally
			{
				if (widgets != null)
				{
					JNIEnv.CopyArray(intPtr, widgets);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(widgets);
			}
		}

		private static Delegate GetLayoutHandler()
		{
			if ((object)cb_layout == null)
			{
				cb_layout = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Layout));
			}
			return cb_layout;
		}

		private static void n_Layout(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<WidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Layout();
		}

		[Register("layout", "()V", "GetLayoutHandler")]
		public unsafe virtual void Layout()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("layout.()V", this, null);
		}

		private static Delegate GetRemove_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Handler()
		{
			if ((object)cb_remove_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_ == null)
			{
				cb_remove_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Remove_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_));
			}
			return cb_remove_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_;
		}

		private static void n_Remove_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_(IntPtr jnienv, IntPtr native__this, IntPtr native_widget)
		{
			WidgetContainer widgetContainer = Java.Lang.Object.GetObject<WidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget widget = Java.Lang.Object.GetObject<ConstraintWidget>(native_widget, JniHandleOwnership.DoNotTransfer);
			widgetContainer.Remove(widget);
		}

		[Register("remove", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)V", "GetRemove_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Handler")]
		public unsafe virtual void Remove(ConstraintWidget widget)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("remove.(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(widget);
			}
		}

		private static Delegate GetRemoveAllChildrenHandler()
		{
			if ((object)cb_removeAllChildren == null)
			{
				cb_removeAllChildren = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_RemoveAllChildren));
			}
			return cb_removeAllChildren;
		}

		private static void n_RemoveAllChildren(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<WidgetContainer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveAllChildren();
		}

		[Register("removeAllChildren", "()V", "GetRemoveAllChildrenHandler")]
		public unsafe virtual void RemoveAllChildren()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("removeAllChildren.()V", this, null);
		}
	}
}
namespace AndroidX.ConstraintLayout.Solver.Widgets.Analyzer
{
	[Register("androidx/constraintlayout/solver/widgets/analyzer/BasicMeasure", DoNotGenerateAcw = true)]
	public class BasicMeasure : Java.Lang.Object
	{
		[Register("androidx/constraintlayout/solver/widgets/analyzer/BasicMeasure$Measure", DoNotGenerateAcw = true)]
		public class Measure : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/widgets/analyzer/BasicMeasure$Measure", typeof(Measure));

			[Register("SELF_DIMENSIONS")]
			public static int SelfDimensions
			{
				get
				{
					return _members.StaticFields.GetInt32Value("SELF_DIMENSIONS.I");
				}
				set
				{
					_members.StaticFields.SetValue("SELF_DIMENSIONS.I", value);
				}
			}

			[Register("TRY_GIVEN_DIMENSIONS")]
			public static int TryGivenDimensions
			{
				get
				{
					return _members.StaticFields.GetInt32Value("TRY_GIVEN_DIMENSIONS.I");
				}
				set
				{
					_members.StaticFields.SetValue("TRY_GIVEN_DIMENSIONS.I", value);
				}
			}

			[Register("USE_GIVEN_DIMENSIONS")]
			public static int UseGivenDimensions
			{
				get
				{
					return _members.StaticFields.GetInt32Value("USE_GIVEN_DIMENSIONS.I");
				}
				set
				{
					_members.StaticFields.SetValue("USE_GIVEN_DIMENSIONS.I", value);
				}
			}

			[Register("horizontalBehavior")]
			public ConstraintWidget.DimensionBehaviour HorizontalBehavior
			{
				get
				{
					return Java.Lang.Object.GetObject<ConstraintWidget.DimensionBehaviour>(_members.InstanceFields.GetObjectValue("horizontalBehavior.Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
					try
					{
						_members.InstanceFields.SetValue("horizontalBehavior.Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("horizontalDimension")]
			public int HorizontalDimension
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("horizontalDimension.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("horizontalDimension.I", this, value);
				}
			}

			[Register("measureStrategy")]
			public int MeasureStrategy
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("measureStrategy.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("measureStrategy.I", this, value);
				}
			}

			[Register("measuredBaseline")]
			public int MeasuredBaseline
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("measuredBaseline.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("measuredBaseline.I", this, value);
				}
			}

			[Register("measuredHasBaseline")]
			public bool MeasuredHasBaseline
			{
				get
				{
					return _members.InstanceFields.GetBooleanValue("measuredHasBaseline.Z", this);
				}
				set
				{
					_members.InstanceFields.SetValue("measuredHasBaseline.Z", this, value);
				}
			}

			[Register("measuredHeight")]
			public int MeasuredHeight
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("measuredHeight.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("measuredHeight.I", this, value);
				}
			}

			[Register("measuredNeedsSolverPass")]
			public bool MeasuredNeedsSolverPass
			{
				get
				{
					return _members.InstanceFields.GetBooleanValue("measuredNeedsSolverPass.Z", this);
				}
				set
				{
					_members.InstanceFields.SetValue("measuredNeedsSolverPass.Z", this, value);
				}
			}

			[Register("measuredWidth")]
			public int MeasuredWidth
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("measuredWidth.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("measuredWidth.I", this, value);
				}
			}

			[Register("verticalBehavior")]
			public ConstraintWidget.DimensionBehaviour VerticalBehavior
			{
				get
				{
					return Java.Lang.Object.GetObject<ConstraintWidget.DimensionBehaviour>(_members.InstanceFields.GetObjectValue("verticalBehavior.Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
					try
					{
						_members.InstanceFields.SetValue("verticalBehavior.Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("verticalDimension")]
			public int VerticalDimension
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("verticalDimension.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("verticalDimension.I", this, value);
				}
			}

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			protected Measure(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Measure()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}
		}

		[Register("androidx/constraintlayout/solver/widgets/analyzer/BasicMeasure$Measurer", "", "AndroidX.ConstraintLayout.Solver.Widgets.Analyzer.BasicMeasure/IMeasurerInvoker")]
		public interface IMeasurer : IJavaObject, IDisposable, IJavaPeerable
		{
			[Register("didMeasures", "()V", "GetDidMeasuresHandler:AndroidX.ConstraintLayout.Solver.Widgets.Analyzer.BasicMeasure/IMeasurerInvoker, Xamarin.AndroidX.ConstraintLayout.Solver")]
			void DidMeasures();

			[Register("measure", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Landroidx/constraintlayout/solver/widgets/analyzer/BasicMeasure$Measure;)V", "GetMeasure_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measure_Handler:AndroidX.ConstraintLayout.Solver.Widgets.Analyzer.BasicMeasure/IMeasurerInvoker, Xamarin.AndroidX.ConstraintLayout.Solver")]
			void Measure(ConstraintWidget p0, Measure p1);
		}

		[Register("androidx/constraintlayout/solver/widgets/analyzer/BasicMeasure$Measurer", DoNotGenerateAcw = true)]
		internal class IMeasurerInvoker : Java.Lang.Object, IMeasurer, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/widgets/analyzer/BasicMeasure$Measurer", typeof(IMeasurerInvoker));

			private IntPtr class_ref;

			private static Delegate cb_didMeasures;

			private IntPtr id_didMeasures;

			private static Delegate cb_measure_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measure_;

			private IntPtr id_measure_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measure_;

			private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => class_ref;

			protected override Type ThresholdType => _members.ManagedPeerType;

			public static IMeasurer GetObject(IntPtr handle, JniHandleOwnership transfer)
			{
				return Java.Lang.Object.GetObject<IMeasurer>(handle, transfer);
			}

			private static IntPtr Validate(IntPtr handle)
			{
				if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
				{
					throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.constraintlayout.solver.widgets.analyzer.BasicMeasure.Measurer"));
				}
				return handle;
			}

			protected override void Dispose(bool disposing)
			{
				if (class_ref != IntPtr.Zero)
				{
					JNIEnv.DeleteGlobalRef(class_ref);
				}
				class_ref = IntPtr.Zero;
				base.Dispose(disposing);
			}

			public IMeasurerInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(Validate(handle), transfer)
			{
				IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
				class_ref = JNIEnv.NewGlobalRef(objectClass);
				JNIEnv.DeleteLocalRef(objectClass);
			}

			private static Delegate GetDidMeasuresHandler()
			{
				if ((object)cb_didMeasures == null)
				{
					cb_didMeasures = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_DidMeasures));
				}
				return cb_didMeasures;
			}

			private static void n_DidMeasures(IntPtr jnienv, IntPtr native__this)
			{
				Java.Lang.Object.GetObject<IMeasurer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DidMeasures();
			}

			public void DidMeasures()
			{
				if (id_didMeasures == IntPtr.Zero)
				{
					id_didMeasures = JNIEnv.GetMethodID(class_ref, "didMeasures", "()V");
				}
				JNIEnv.CallVoidMethod(base.Handle, id_didMeasures);
			}

			private static Delegate GetMeasure_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measure_Handler()
			{
				if ((object)cb_measure_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measure_ == null)
				{
					cb_measure_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measure_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_Measure_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measure_));
				}
				return cb_measure_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measure_;
			}

			private static void n_Measure_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measure_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				IMeasurer measurer = Java.Lang.Object.GetObject<IMeasurer>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				ConstraintWidget p = Java.Lang.Object.GetObject<ConstraintWidget>(native_p0, JniHandleOwnership.DoNotTransfer);
				Measure p2 = Java.Lang.Object.GetObject<Measure>(native_p1, JniHandleOwnership.DoNotTransfer);
				measurer.Measure(p, p2);
			}

			public unsafe void Measure(ConstraintWidget p0, Measure p1)
			{
				if (id_measure_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measure_ == IntPtr.Zero)
				{
					id_measure_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measure_ = JNIEnv.GetMethodID(class_ref, "measure", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;Landroidx/constraintlayout/solver/widgets/analyzer/BasicMeasure$Measure;)V");
				}
				JValue* ptr = stackalloc JValue[2];
				*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
				JNIEnv.CallVoidMethod(base.Handle, id_measure_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measure_, ptr);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/widgets/analyzer/BasicMeasure", typeof(BasicMeasure));

		private static Delegate cb_solverMeasure_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_IIIIIIIII;

		private static Delegate cb_updateHierarchy_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected BasicMeasure(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;)V", "")]
		public unsafe BasicMeasure(ConstraintWidgetContainer constraintWidgetContainer)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(constraintWidgetContainer?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(constraintWidgetContainer);
			}
		}

		private static Delegate GetSolverMeasure_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_IIIIIIIIIHandler()
		{
			if ((object)cb_solverMeasure_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_IIIIIIIII == null)
			{
				cb_solverMeasure_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_IIIIIIIII = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLIIIIIIIII_J(n_SolverMeasure_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_IIIIIIIII));
			}
			return cb_solverMeasure_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_IIIIIIIII;
		}

		private static long n_SolverMeasure_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_IIIIIIIII(IntPtr jnienv, IntPtr native__this, IntPtr native_layout, int optimizationLevel, int paddingX, int paddingY, int widthMode, int widthSize, int heightMode, int heightSize, int lastMeasureWidth, int lastMeasureHeight)
		{
			BasicMeasure basicMeasure = Java.Lang.Object.GetObject<BasicMeasure>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidgetContainer layout = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(native_layout, JniHandleOwnership.DoNotTransfer);
			return basicMeasure.SolverMeasure(layout, optimizationLevel, paddingX, paddingY, widthMode, widthSize, heightMode, heightSize, lastMeasureWidth, lastMeasureHeight);
		}

		[Register("solverMeasure", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;IIIIIIIII)J", "GetSolverMeasure_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_IIIIIIIIIHandler")]
		public unsafe virtual long SolverMeasure(ConstraintWidgetContainer layout, int optimizationLevel, int paddingX, int paddingY, int widthMode, int widthSize, int heightMode, int heightSize, int lastMeasureWidth, int lastMeasureHeight)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[10];
				*ptr = new JniArgumentValue(layout?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(optimizationLevel);
				ptr[2] = new JniArgumentValue(paddingX);
				ptr[3] = new JniArgumentValue(paddingY);
				ptr[4] = new JniArgumentValue(widthMode);
				ptr[5] = new JniArgumentValue(widthSize);
				ptr[6] = new JniArgumentValue(heightMode);
				ptr[7] = new JniArgumentValue(heightSize);
				ptr[8] = new JniArgumentValue(lastMeasureWidth);
				ptr[9] = new JniArgumentValue(lastMeasureHeight);
				return _members.InstanceMethods.InvokeVirtualInt64Method("solverMeasure.(Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;IIIIIIIII)J", this, ptr);
			}
			finally
			{
				GC.KeepAlive(layout);
			}
		}

		private static Delegate GetUpdateHierarchy_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_Handler()
		{
			if ((object)cb_updateHierarchy_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_ == null)
			{
				cb_updateHierarchy_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UpdateHierarchy_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_));
			}
			return cb_updateHierarchy_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_;
		}

		private static void n_UpdateHierarchy_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_(IntPtr jnienv, IntPtr native__this, IntPtr native_layout)
		{
			BasicMeasure basicMeasure = Java.Lang.Object.GetObject<BasicMeasure>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidgetContainer layout = Java.Lang.Object.GetObject<ConstraintWidgetContainer>(native_layout, JniHandleOwnership.DoNotTransfer);
			basicMeasure.UpdateHierarchy(layout);
		}

		[Register("updateHierarchy", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;)V", "GetUpdateHierarchy_Landroidx_constraintlayout_solver_widgets_ConstraintWidgetContainer_Handler")]
		public unsafe virtual void UpdateHierarchy(ConstraintWidgetContainer layout)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(layout?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("updateHierarchy.(Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(layout);
			}
		}
	}
	[Register("androidx/constraintlayout/solver/widgets/analyzer/ChainRun", DoNotGenerateAcw = true)]
	public class ChainRun : WidgetRun
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/widgets/analyzer/ChainRun", typeof(ChainRun));

		private static Delegate cb_applyToWidget;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected ChainRun(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;I)V", "")]
		public unsafe ChainRun(ConstraintWidget widget, int orientation)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(orientation);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(widget);
			}
		}

		private static Delegate GetApplyToWidgetHandler()
		{
			if ((object)cb_applyToWidget == null)
			{
				cb_applyToWidget = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ApplyToWidget));
			}
			return cb_applyToWidget;
		}

		private static void n_ApplyToWidget(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ChainRun>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ApplyToWidget();
		}

		[Register("applyToWidget", "()V", "GetApplyToWidgetHandler")]
		public unsafe virtual void ApplyToWidget()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("applyToWidget.()V", this, null);
		}
	}
	[Register("androidx/constraintlayout/solver/widgets/analyzer/DependencyGraph", DoNotGenerateAcw = true)]
	public class DependencyGraph : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/widgets/analyzer/DependencyGraph", typeof(DependencyGraph));

		private static Delegate cb_buildGraph;

		private static Delegate cb_buildGraph_Ljava_util_ArrayList_;

		private static Delegate cb_defineTerminalWidgets_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_;

		private static Delegate cb_directMeasure_Z;

		private static Delegate cb_directMeasureSetup_Z;

		private static Delegate cb_directMeasureWithOrientation_ZI;

		private static Delegate cb_invalidateGraph;

		private static Delegate cb_invalidateMeasures;

		private static Delegate cb_measureWidgets;

		private static Delegate cb_setMeasurer_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measurer_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected DependencyGraph(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;)V", "")]
		public unsafe DependencyGraph(ConstraintWidgetContainer container)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(container?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/solver/widgets/ConstraintWidgetContainer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(container);
			}
		}

		private static Delegate GetBuildGraphHandler()
		{
			if ((object)cb_buildGraph == null)
			{
				cb_buildGraph = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_BuildGraph));
			}
			return cb_buildGraph;
		}

		private static void n_BuildGraph(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<DependencyGraph>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BuildGraph();
		}

		[Register("buildGraph", "()V", "GetBuildGraphHandler")]
		public unsafe virtual void BuildGraph()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("buildGraph.()V", this, null);
		}

		private static Delegate GetBuildGraph_Ljava_util_ArrayList_Handler()
		{
			if ((object)cb_buildGraph_Ljava_util_ArrayList_ == null)
			{
				cb_buildGraph_Ljava_util_ArrayList_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_BuildGraph_Ljava_util_ArrayList_));
			}
			return cb_buildGraph_Ljava_util_ArrayList_;
		}

		private static void n_BuildGraph_Ljava_util_ArrayList_(IntPtr jnienv, IntPtr native__this, IntPtr native_runs)
		{
			DependencyGraph dependencyGraph = Java.Lang.Object.GetObject<DependencyGraph>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<WidgetRun> runs = JavaList<WidgetRun>.FromJniHandle(native_runs, JniHandleOwnership.DoNotTransfer);
			dependencyGraph.BuildGraph(runs);
		}

		[Register("buildGraph", "(Ljava/util/ArrayList;)V", "GetBuildGraph_Ljava_util_ArrayList_Handler")]
		public unsafe virtual void BuildGraph(IList<WidgetRun> runs)
		{
			IntPtr intPtr = JavaList<WidgetRun>.ToLocalJniHandle(runs);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("buildGraph.(Ljava/util/ArrayList;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(runs);
			}
		}

		private static Delegate GetDefineTerminalWidgets_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_Handler()
		{
			if ((object)cb_defineTerminalWidgets_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_ == null)
			{
				cb_defineTerminalWidgets_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_DefineTerminalWidgets_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_));
			}
			return cb_defineTerminalWidgets_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_;
		}

		private static void n_DefineTerminalWidgets_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_(IntPtr jnienv, IntPtr native__this, IntPtr native_horizontalBehavior, IntPtr native_verticalBehavior)
		{
			DependencyGraph dependencyGraph = Java.Lang.Object.GetObject<DependencyGraph>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget.DimensionBehaviour horizontalBehavior = Java.Lang.Object.GetObject<ConstraintWidget.DimensionBehaviour>(native_horizontalBehavior, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget.DimensionBehaviour verticalBehavior = Java.Lang.Object.GetObject<ConstraintWidget.DimensionBehaviour>(native_verticalBehavior, JniHandleOwnership.DoNotTransfer);
			dependencyGraph.DefineTerminalWidgets(horizontalBehavior, verticalBehavior);
		}

		[Register("defineTerminalWidgets", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;)V", "GetDefineTerminalWidgets_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_DimensionBehaviour_Handler")]
		public unsafe virtual void DefineTerminalWidgets(ConstraintWidget.DimensionBehaviour horizontalBehavior, ConstraintWidget.DimensionBehaviour verticalBehavior)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(horizontalBehavior?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(verticalBehavior?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("defineTerminalWidgets.(Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(horizontalBehavior);
				GC.KeepAlive(verticalBehavior);
			}
		}

		private static Delegate GetDirectMeasure_ZHandler()
		{
			if ((object)cb_directMeasure_Z == null)
			{
				cb_directMeasure_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_Z(n_DirectMeasure_Z));
			}
			return cb_directMeasure_Z;
		}

		private static bool n_DirectMeasure_Z(IntPtr jnienv, IntPtr native__this, bool optimizeWrap)
		{
			return Java.Lang.Object.GetObject<DependencyGraph>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DirectMeasure(optimizeWrap);
		}

		[Register("directMeasure", "(Z)Z", "GetDirectMeasure_ZHandler")]
		public unsafe virtual bool DirectMeasure(bool optimizeWrap)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(optimizeWrap);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("directMeasure.(Z)Z", this, ptr);
		}

		private static Delegate GetDirectMeasureSetup_ZHandler()
		{
			if ((object)cb_directMeasureSetup_Z == null)
			{
				cb_directMeasureSetup_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_Z(n_DirectMeasureSetup_Z));
			}
			return cb_directMeasureSetup_Z;
		}

		private static bool n_DirectMeasureSetup_Z(IntPtr jnienv, IntPtr native__this, bool optimizeWrap)
		{
			return Java.Lang.Object.GetObject<DependencyGraph>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DirectMeasureSetup(optimizeWrap);
		}

		[Register("directMeasureSetup", "(Z)Z", "GetDirectMeasureSetup_ZHandler")]
		public unsafe virtual bool DirectMeasureSetup(bool optimizeWrap)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(optimizeWrap);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("directMeasureSetup.(Z)Z", this, ptr);
		}

		private static Delegate GetDirectMeasureWithOrientation_ZIHandler()
		{
			if ((object)cb_directMeasureWithOrientation_ZI == null)
			{
				cb_directMeasureWithOrientation_ZI = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPZI_Z(n_DirectMeasureWithOrientation_ZI));
			}
			return cb_directMeasureWithOrientation_ZI;
		}

		private static bool n_DirectMeasureWithOrientation_ZI(IntPtr jnienv, IntPtr native__this, bool optimizeWrap, int orientation)
		{
			return Java.Lang.Object.GetObject<DependencyGraph>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DirectMeasureWithOrientation(optimizeWrap, orientation);
		}

		[Register("directMeasureWithOrientation", "(ZI)Z", "GetDirectMeasureWithOrientation_ZIHandler")]
		public unsafe virtual bool DirectMeasureWithOrientation(bool optimizeWrap, int orientation)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(optimizeWrap);
			ptr[1] = new JniArgumentValue(orientation);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("directMeasureWithOrientation.(ZI)Z", this, ptr);
		}

		private static Delegate GetInvalidateGraphHandler()
		{
			if ((object)cb_invalidateGraph == null)
			{
				cb_invalidateGraph = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_InvalidateGraph));
			}
			return cb_invalidateGraph;
		}

		private static void n_InvalidateGraph(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<DependencyGraph>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvalidateGraph();
		}

		[Register("invalidateGraph", "()V", "GetInvalidateGraphHandler")]
		public unsafe virtual void InvalidateGraph()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("invalidateGraph.()V", this, null);
		}

		private static Delegate GetInvalidateMeasuresHandler()
		{
			if ((object)cb_invalidateMeasures == null)
			{
				cb_invalidateMeasures = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_InvalidateMeasures));
			}
			return cb_invalidateMeasures;
		}

		private static void n_InvalidateMeasures(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<DependencyGraph>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InvalidateMeasures();
		}

		[Register("invalidateMeasures", "()V", "GetInvalidateMeasuresHandler")]
		public unsafe virtual void InvalidateMeasures()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("invalidateMeasures.()V", this, null);
		}

		private static Delegate GetMeasureWidgetsHandler()
		{
			if ((object)cb_measureWidgets == null)
			{
				cb_measureWidgets = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_MeasureWidgets));
			}
			return cb_measureWidgets;
		}

		private static void n_MeasureWidgets(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<DependencyGraph>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MeasureWidgets();
		}

		[Register("measureWidgets", "()V", "GetMeasureWidgetsHandler")]
		public unsafe virtual void MeasureWidgets()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("measureWidgets.()V", this, null);
		}

		private static Delegate GetSetMeasurer_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measurer_Handler()
		{
			if ((object)cb_setMeasurer_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measurer_ == null)
			{
				cb_setMeasurer_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measurer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetMeasurer_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measurer_));
			}
			return cb_setMeasurer_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measurer_;
		}

		private static void n_SetMeasurer_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measurer_(IntPtr jnienv, IntPtr native__this, IntPtr native_measurer)
		{
			DependencyGraph dependencyGraph = Java.Lang.Object.GetObject<DependencyGraph>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			BasicMeasure.IMeasurer measurer = Java.Lang.Object.GetObject<BasicMeasure.IMeasurer>(native_measurer, JniHandleOwnership.DoNotTransfer);
			dependencyGraph.SetMeasurer(measurer);
		}

		[Register("setMeasurer", "(Landroidx/constraintlayout/solver/widgets/analyzer/BasicMeasure$Measurer;)V", "GetSetMeasurer_Landroidx_constraintlayout_solver_widgets_analyzer_BasicMeasure_Measurer_Handler")]
		public unsafe virtual void SetMeasurer(BasicMeasure.IMeasurer measurer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((measurer == null) ? IntPtr.Zero : ((Java.Lang.Object)measurer).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setMeasurer.(Landroidx/constraintlayout/solver/widgets/analyzer/BasicMeasure$Measurer;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(measurer);
			}
		}
	}
	[Register("androidx/constraintlayout/solver/widgets/analyzer/DependencyNode", DoNotGenerateAcw = true)]
	public class DependencyNode : Java.Lang.Object, IDependency, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/widgets/analyzer/DependencyNode", typeof(DependencyNode));

		private static Delegate cb_addDependency_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_;

		private static Delegate cb_clear;

		private static Delegate cb_name;

		private static Delegate cb_resolve_I;

		private static Delegate cb_update_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_;

		[Register("delegateToWidgetRun")]
		public bool DelegateToWidgetRun
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("delegateToWidgetRun.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("delegateToWidgetRun.Z", this, value);
			}
		}

		[Register("readyToSolve")]
		public bool ReadyToSolve
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("readyToSolve.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("readyToSolve.Z", this, value);
			}
		}

		[Register("resolved")]
		public bool Resolved
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("resolved.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("resolved.Z", this, value);
			}
		}

		[Register("updateDelegate")]
		public IDependency UpdateDelegate
		{
			get
			{
				return Java.Lang.Object.GetObject<IDependency>(_members.InstanceFields.GetObjectValue("updateDelegate.Landroidx/constraintlayout/solver/widgets/analyzer/Dependency;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("updateDelegate.Landroidx/constraintlayout/solver/widgets/analyzer/Dependency;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("value")]
		public int Value
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("value.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("value.I", this, value);
			}
		}

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected DependencyNode(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroidx/constraintlayout/solver/widgets/analyzer/WidgetRun;)V", "")]
		public unsafe DependencyNode(WidgetRun run)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(run?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/solver/widgets/analyzer/WidgetRun;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/solver/widgets/analyzer/WidgetRun;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(run);
			}
		}

		private static Delegate GetAddDependency_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_Handler()
		{
			if ((object)cb_addDependency_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_ == null)
			{
				cb_addDependency_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AddDependency_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_));
			}
			return cb_addDependency_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_;
		}

		private static void n_AddDependency_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_(IntPtr jnienv, IntPtr native__this, IntPtr native_dependency)
		{
			DependencyNode dependencyNode = Java.Lang.Object.GetObject<DependencyNode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDependency dependency = Java.Lang.Object.GetObject<IDependency>(native_dependency, JniHandleOwnership.DoNotTransfer);
			dependencyNode.AddDependency(dependency);
		}

		[Register("addDependency", "(Landroidx/constraintlayout/solver/widgets/analyzer/Dependency;)V", "GetAddDependency_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_Handler")]
		public unsafe virtual void AddDependency(IDependency dependency)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((dependency == null) ? IntPtr.Zero : ((Java.Lang.Object)dependency).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addDependency.(Landroidx/constraintlayout/solver/widgets/analyzer/Dependency;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(dependency);
			}
		}

		private static Delegate GetClearHandler()
		{
			if ((object)cb_clear == null)
			{
				cb_clear = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Clear));
			}
			return cb_clear;
		}

		private static void n_Clear(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<DependencyNode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
		}

		[Register("clear", "()V", "GetClearHandler")]
		public unsafe virtual void Clear()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("clear.()V", this, null);
		}

		private static Delegate GetNameHandler()
		{
			if ((object)cb_name == null)
			{
				cb_name = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Name));
			}
			return cb_name;
		}

		private static IntPtr n_Name(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<DependencyNode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Name());
		}

		[Register("name", "()Ljava/lang/String;", "GetNameHandler")]
		public unsafe virtual string Name()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("name.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetResolve_IHandler()
		{
			if ((object)cb_resolve_I == null)
			{
				cb_resolve_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_Resolve_I));
			}
			return cb_resolve_I;
		}

		private static void n_Resolve_I(IntPtr jnienv, IntPtr native__this, int value)
		{
			Java.Lang.Object.GetObject<DependencyNode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Resolve(value);
		}

		[Register("resolve", "(I)V", "GetResolve_IHandler")]
		public unsafe virtual void Resolve(int value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			_members.InstanceMethods.InvokeVirtualVoidMethod("resolve.(I)V", this, ptr);
		}

		private static Delegate GetUpdate_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_Handler()
		{
			if ((object)cb_update_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_ == null)
			{
				cb_update_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Update_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_));
			}
			return cb_update_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_;
		}

		private static void n_Update_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_(IntPtr jnienv, IntPtr native__this, IntPtr native_node)
		{
			DependencyNode dependencyNode = Java.Lang.Object.GetObject<DependencyNode>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDependency node = Java.Lang.Object.GetObject<IDependency>(native_node, JniHandleOwnership.DoNotTransfer);
			dependencyNode.Update(node);
		}

		[Register("update", "(Landroidx/constraintlayout/solver/widgets/analyzer/Dependency;)V", "GetUpdate_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_Handler")]
		public unsafe virtual void Update(IDependency node)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((node == null) ? IntPtr.Zero : ((Java.Lang.Object)node).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("update.(Landroidx/constraintlayout/solver/widgets/analyzer/Dependency;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(node);
			}
		}
	}
	[Register("androidx/constraintlayout/solver/widgets/analyzer/HorizontalWidgetRun", DoNotGenerateAcw = true)]
	public class HorizontalWidgetRun : WidgetRun
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/widgets/analyzer/HorizontalWidgetRun", typeof(HorizontalWidgetRun));

		private static Delegate cb_applyToWidget;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected HorizontalWidgetRun(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)V", "")]
		public unsafe HorizontalWidgetRun(ConstraintWidget widget)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(widget);
			}
		}

		private static Delegate GetApplyToWidgetHandler()
		{
			if ((object)cb_applyToWidget == null)
			{
				cb_applyToWidget = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ApplyToWidget));
			}
			return cb_applyToWidget;
		}

		private static void n_ApplyToWidget(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<HorizontalWidgetRun>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ApplyToWidget();
		}

		[Register("applyToWidget", "()V", "GetApplyToWidgetHandler")]
		public unsafe virtual void ApplyToWidget()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("applyToWidget.()V", this, null);
		}
	}
	[Register("androidx/constraintlayout/solver/widgets/analyzer/Dependency", "", "AndroidX.ConstraintLayout.Solver.Widgets.Analyzer.IDependencyInvoker")]
	public interface IDependency : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("update", "(Landroidx/constraintlayout/solver/widgets/analyzer/Dependency;)V", "GetUpdate_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_Handler:AndroidX.ConstraintLayout.Solver.Widgets.Analyzer.IDependencyInvoker, Xamarin.AndroidX.ConstraintLayout.Solver")]
		void Update(IDependency p0);
	}
	[Register("androidx/constraintlayout/solver/widgets/analyzer/Dependency", DoNotGenerateAcw = true)]
	internal class IDependencyInvoker : Java.Lang.Object, IDependency, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/widgets/analyzer/Dependency", typeof(IDependencyInvoker));

		private IntPtr class_ref;

		private static Delegate cb_update_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_;

		private IntPtr id_update_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IDependency GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IDependency>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "androidx.constraintlayout.solver.widgets.analyzer.Dependency"));
			}
			return handle;
		}

		protected override void Dispose(bool disposing)
		{
			if (class_ref != IntPtr.Zero)
			{
				JNIEnv.DeleteGlobalRef(class_ref);
			}
			class_ref = IntPtr.Zero;
			base.Dispose(disposing);
		}

		public IDependencyInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetUpdate_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_Handler()
		{
			if ((object)cb_update_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_ == null)
			{
				cb_update_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Update_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_));
			}
			return cb_update_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_;
		}

		private static void n_Update_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IDependency dependency = Java.Lang.Object.GetObject<IDependency>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDependency p = Java.Lang.Object.GetObject<IDependency>(native_p0, JniHandleOwnership.DoNotTransfer);
			dependency.Update(p);
		}

		public unsafe void Update(IDependency p0)
		{
			if (id_update_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_ == IntPtr.Zero)
			{
				id_update_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_ = JNIEnv.GetMethodID(class_ref, "update", "(Landroidx/constraintlayout/solver/widgets/analyzer/Dependency;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_update_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_, ptr);
		}
	}
	[Register("androidx/constraintlayout/solver/widgets/analyzer/VerticalWidgetRun", DoNotGenerateAcw = true)]
	public class VerticalWidgetRun : WidgetRun
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/widgets/analyzer/VerticalWidgetRun", typeof(VerticalWidgetRun));

		private static Delegate cb_applyToWidget;

		[Register("baseline")]
		public DependencyNode Baseline
		{
			get
			{
				return Java.Lang.Object.GetObject<DependencyNode>(_members.InstanceFields.GetObjectValue("baseline.Landroidx/constraintlayout/solver/widgets/analyzer/DependencyNode;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("baseline.Landroidx/constraintlayout/solver/widgets/analyzer/DependencyNode;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected VerticalWidgetRun(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)V", "")]
		public unsafe VerticalWidgetRun(ConstraintWidget widget)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(widget);
			}
		}

		private static Delegate GetApplyToWidgetHandler()
		{
			if ((object)cb_applyToWidget == null)
			{
				cb_applyToWidget = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ApplyToWidget));
			}
			return cb_applyToWidget;
		}

		private static void n_ApplyToWidget(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<VerticalWidgetRun>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ApplyToWidget();
		}

		[Register("applyToWidget", "()V", "GetApplyToWidgetHandler")]
		public unsafe virtual void ApplyToWidget()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("applyToWidget.()V", this, null);
		}
	}
	[Register("androidx/constraintlayout/solver/widgets/analyzer/WidgetGroup", DoNotGenerateAcw = true)]
	public class WidgetGroup : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/widgets/analyzer/WidgetGroup", typeof(WidgetGroup));

		private static Delegate cb_isAuthoritative;

		private static Delegate cb_setAuthoritative_Z;

		private static Delegate cb_getId;

		private static Delegate cb_getOrientation;

		private static Delegate cb_setOrientation_I;

		private static Delegate cb_add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_;

		private static Delegate cb_apply;

		private static Delegate cb_cleanup_Ljava_util_ArrayList_;

		private static Delegate cb_clear;

		private static Delegate cb_intersectWith_Landroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_;

		private static Delegate cb_measureWrap_Landroidx_constraintlayout_solver_LinearSystem_I;

		private static Delegate cb_moveTo_ILandroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_;

		private static Delegate cb_size;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual bool Authoritative
		{
			[Register("isAuthoritative", "()Z", "GetIsAuthoritativeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAuthoritative.()Z", this, null);
			}
			[Register("setAuthoritative", "(Z)V", "GetSetAuthoritative_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setAuthoritative.(Z)V", this, ptr);
			}
		}

		public unsafe virtual int Id
		{
			[Register("getId", "()I", "GetGetIdHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getId.()I", this, null);
			}
		}

		public unsafe virtual int Orientation
		{
			[Register("getOrientation", "()I", "GetGetOrientationHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getOrientation.()I", this, null);
			}
			[Register("setOrientation", "(I)V", "GetSetOrientation_IHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setOrientation.(I)V", this, ptr);
			}
		}

		protected WidgetGroup(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(I)V", "")]
		public unsafe WidgetGroup(int orientation)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(orientation);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
			}
		}

		private static Delegate GetIsAuthoritativeHandler()
		{
			if ((object)cb_isAuthoritative == null)
			{
				cb_isAuthoritative = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsAuthoritative));
			}
			return cb_isAuthoritative;
		}

		private static bool n_IsAuthoritative(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Authoritative;
		}

		private static Delegate GetSetAuthoritative_ZHandler()
		{
			if ((object)cb_setAuthoritative_Z == null)
			{
				cb_setAuthoritative_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetAuthoritative_Z));
			}
			return cb_setAuthoritative_Z;
		}

		private static void n_SetAuthoritative_Z(IntPtr jnienv, IntPtr native__this, bool isAuthoritative)
		{
			Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Authoritative = isAuthoritative;
		}

		private static Delegate GetGetIdHandler()
		{
			if ((object)cb_getId == null)
			{
				cb_getId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetId));
			}
			return cb_getId;
		}

		private static int n_GetId(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id;
		}

		private static Delegate GetGetOrientationHandler()
		{
			if ((object)cb_getOrientation == null)
			{
				cb_getOrientation = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetOrientation));
			}
			return cb_getOrientation;
		}

		private static int n_GetOrientation(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Orientation;
		}

		private static Delegate GetSetOrientation_IHandler()
		{
			if ((object)cb_setOrientation_I == null)
			{
				cb_setOrientation_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_SetOrientation_I));
			}
			return cb_setOrientation_I;
		}

		private static void n_SetOrientation_I(IntPtr jnienv, IntPtr native__this, int orientation)
		{
			Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Orientation = orientation;
		}

		private static Delegate GetAdd_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Handler()
		{
			if ((object)cb_add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_ == null)
			{
				cb_add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_));
			}
			return cb_add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_;
		}

		private static bool n_Add_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_(IntPtr jnienv, IntPtr native__this, IntPtr native_widget)
		{
			WidgetGroup widgetGroup = Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ConstraintWidget widget = Java.Lang.Object.GetObject<ConstraintWidget>(native_widget, JniHandleOwnership.DoNotTransfer);
			return widgetGroup.Add(widget);
		}

		[Register("add", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)Z", "GetAdd_Landroidx_constraintlayout_solver_widgets_ConstraintWidget_Handler")]
		public unsafe virtual bool Add(ConstraintWidget widget)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("add.(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(widget);
			}
		}

		private static Delegate GetApplyHandler()
		{
			if ((object)cb_apply == null)
			{
				cb_apply = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Apply));
			}
			return cb_apply;
		}

		private static void n_Apply(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Apply();
		}

		[Register("apply", "()V", "GetApplyHandler")]
		public unsafe virtual void Apply()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("apply.()V", this, null);
		}

		private static Delegate GetCleanup_Ljava_util_ArrayList_Handler()
		{
			if ((object)cb_cleanup_Ljava_util_ArrayList_ == null)
			{
				cb_cleanup_Ljava_util_ArrayList_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Cleanup_Ljava_util_ArrayList_));
			}
			return cb_cleanup_Ljava_util_ArrayList_;
		}

		private static void n_Cleanup_Ljava_util_ArrayList_(IntPtr jnienv, IntPtr native__this, IntPtr native_dependencyLists)
		{
			WidgetGroup widgetGroup = Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<WidgetGroup> dependencyLists = JavaList<WidgetGroup>.FromJniHandle(native_dependencyLists, JniHandleOwnership.DoNotTransfer);
			widgetGroup.Cleanup(dependencyLists);
		}

		[Register("cleanup", "(Ljava/util/ArrayList;)V", "GetCleanup_Ljava_util_ArrayList_Handler")]
		public unsafe virtual void Cleanup(IList<WidgetGroup> dependencyLists)
		{
			IntPtr intPtr = JavaList<WidgetGroup>.ToLocalJniHandle(dependencyLists);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("cleanup.(Ljava/util/ArrayList;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(dependencyLists);
			}
		}

		private static Delegate GetClearHandler()
		{
			if ((object)cb_clear == null)
			{
				cb_clear = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Clear));
			}
			return cb_clear;
		}

		private static void n_Clear(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
		}

		[Register("clear", "()V", "GetClearHandler")]
		public unsafe virtual void Clear()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("clear.()V", this, null);
		}

		private static Delegate GetIntersectWith_Landroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_Handler()
		{
			if ((object)cb_intersectWith_Landroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_ == null)
			{
				cb_intersectWith_Landroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_IntersectWith_Landroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_));
			}
			return cb_intersectWith_Landroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_;
		}

		private static bool n_IntersectWith_Landroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_(IntPtr jnienv, IntPtr native__this, IntPtr native_group)
		{
			WidgetGroup widgetGroup = Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WidgetGroup widgetGroup2 = Java.Lang.Object.GetObject<WidgetGroup>(native_group, JniHandleOwnership.DoNotTransfer);
			return widgetGroup.IntersectWith(widgetGroup2);
		}

		[Register("intersectWith", "(Landroidx/constraintlayout/solver/widgets/analyzer/WidgetGroup;)Z", "GetIntersectWith_Landroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_Handler")]
		public unsafe virtual bool IntersectWith(WidgetGroup group)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(group?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("intersectWith.(Landroidx/constraintlayout/solver/widgets/analyzer/WidgetGroup;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(group);
			}
		}

		private static Delegate GetMeasureWrap_Landroidx_constraintlayout_solver_LinearSystem_IHandler()
		{
			if ((object)cb_measureWrap_Landroidx_constraintlayout_solver_LinearSystem_I == null)
			{
				cb_measureWrap_Landroidx_constraintlayout_solver_LinearSystem_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_I(n_MeasureWrap_Landroidx_constraintlayout_solver_LinearSystem_I));
			}
			return cb_measureWrap_Landroidx_constraintlayout_solver_LinearSystem_I;
		}

		private static int n_MeasureWrap_Landroidx_constraintlayout_solver_LinearSystem_I(IntPtr jnienv, IntPtr native__this, IntPtr native_system, int orientation)
		{
			WidgetGroup widgetGroup = Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			LinearSystem system = Java.Lang.Object.GetObject<LinearSystem>(native_system, JniHandleOwnership.DoNotTransfer);
			return widgetGroup.MeasureWrap(system, orientation);
		}

		[Register("measureWrap", "(Landroidx/constraintlayout/solver/LinearSystem;I)I", "GetMeasureWrap_Landroidx_constraintlayout_solver_LinearSystem_IHandler")]
		public unsafe virtual int MeasureWrap(LinearSystem system, int orientation)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(system?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(orientation);
				return _members.InstanceMethods.InvokeVirtualInt32Method("measureWrap.(Landroidx/constraintlayout/solver/LinearSystem;I)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(system);
			}
		}

		private static Delegate GetMoveTo_ILandroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_Handler()
		{
			if ((object)cb_moveTo_ILandroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_ == null)
			{
				cb_moveTo_ILandroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_V(n_MoveTo_ILandroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_));
			}
			return cb_moveTo_ILandroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_;
		}

		private static void n_MoveTo_ILandroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_(IntPtr jnienv, IntPtr native__this, int orientation, IntPtr native_widgetGroup)
		{
			WidgetGroup widgetGroup = Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WidgetGroup widgetGroup2 = Java.Lang.Object.GetObject<WidgetGroup>(native_widgetGroup, JniHandleOwnership.DoNotTransfer);
			widgetGroup.MoveTo(orientation, widgetGroup2);
		}

		[Register("moveTo", "(ILandroidx/constraintlayout/solver/widgets/analyzer/WidgetGroup;)V", "GetMoveTo_ILandroidx_constraintlayout_solver_widgets_analyzer_WidgetGroup_Handler")]
		public unsafe virtual void MoveTo(int orientation, WidgetGroup widgetGroup)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(orientation);
				ptr[1] = new JniArgumentValue(widgetGroup?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("moveTo.(ILandroidx/constraintlayout/solver/widgets/analyzer/WidgetGroup;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(widgetGroup);
			}
		}

		private static Delegate GetSizeHandler()
		{
			if ((object)cb_size == null)
			{
				cb_size = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_Size));
			}
			return cb_size;
		}

		private static int n_Size(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<WidgetGroup>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size();
		}

		[Register("size", "()I", "GetSizeHandler")]
		public unsafe virtual int Size()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("size.()I", this, null);
		}
	}
	[Register("androidx/constraintlayout/solver/widgets/analyzer/WidgetRun", DoNotGenerateAcw = true)]
	public abstract class WidgetRun : Java.Lang.Object, IDependency, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("androidx/constraintlayout/solver/widgets/analyzer/WidgetRun$RunType", DoNotGenerateAcw = true)]
		public sealed class RunType : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/widgets/analyzer/WidgetRun$RunType", typeof(RunType));

			[Register("CENTER")]
			public static RunType Center => Java.Lang.Object.GetObject<RunType>(_members.StaticFields.GetObjectValue("CENTER.Landroidx/constraintlayout/solver/widgets/analyzer/WidgetRun$RunType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("END")]
			public static RunType End => Java.Lang.Object.GetObject<RunType>(_members.StaticFields.GetObjectValue("END.Landroidx/constraintlayout/solver/widgets/analyzer/WidgetRun$RunType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("NONE")]
			public static RunType None => Java.Lang.Object.GetObject<RunType>(_members.StaticFields.GetObjectValue("NONE.Landroidx/constraintlayout/solver/widgets/analyzer/WidgetRun$RunType;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("START")]
			public static RunType Start => Java.Lang.Object.GetObject<RunType>(_members.StaticFields.GetObjectValue("START.Landroidx/constraintlayout/solver/widgets/analyzer/WidgetRun$RunType;").Handle, JniHandleOwnership.TransferLocalRef);

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			internal RunType(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Ljava/lang/Enum;", "")]
			public unsafe static Java.Lang.Enum ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Java.Lang.Enum>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Ljava/lang/Enum;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Landroidx/constraintlayout/solver/widgets/analyzer/WidgetRun$RunType;", "")]
			public unsafe static RunType[] Values()
			{
				return (RunType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/constraintlayout/solver/widgets/analyzer/WidgetRun$RunType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(RunType));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/widgets/analyzer/WidgetRun", typeof(WidgetRun));

		private static Delegate cb_isCenterConnection;

		private static Delegate cb_isDimensionResolved;

		private static Delegate cb_isResolved;

		private static Delegate cb_getWrapDimension;

		private static Delegate cb_update_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_;

		private static Delegate cb_updateRunCenter_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_I;

		private static Delegate cb_updateRunEnd_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_;

		private static Delegate cb_updateRunStart_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_;

		private static Delegate cb_wrapSize_I;

		[Register("dimensionBehavior")]
		protected ConstraintWidget.DimensionBehaviour DimensionBehavior
		{
			get
			{
				return Java.Lang.Object.GetObject<ConstraintWidget.DimensionBehaviour>(_members.InstanceFields.GetObjectValue("dimensionBehavior.Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("dimensionBehavior.Landroidx/constraintlayout/solver/widgets/ConstraintWidget$DimensionBehaviour;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("end")]
		public DependencyNode End
		{
			get
			{
				return Java.Lang.Object.GetObject<DependencyNode>(_members.InstanceFields.GetObjectValue("end.Landroidx/constraintlayout/solver/widgets/analyzer/DependencyNode;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("end.Landroidx/constraintlayout/solver/widgets/analyzer/DependencyNode;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("mRunType")]
		protected RunType MRunType
		{
			get
			{
				return Java.Lang.Object.GetObject<RunType>(_members.InstanceFields.GetObjectValue("mRunType.Landroidx/constraintlayout/solver/widgets/analyzer/WidgetRun$RunType;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("mRunType.Landroidx/constraintlayout/solver/widgets/analyzer/WidgetRun$RunType;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("matchConstraintsType")]
		public int MatchConstraintsType
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("matchConstraintsType.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("matchConstraintsType.I", this, value);
			}
		}

		[Register("orientation")]
		public int Orientation
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("orientation.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("orientation.I", this, value);
			}
		}

		[Register("start")]
		public DependencyNode Start
		{
			get
			{
				return Java.Lang.Object.GetObject<DependencyNode>(_members.InstanceFields.GetObjectValue("start.Landroidx/constraintlayout/solver/widgets/analyzer/DependencyNode;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("start.Landroidx/constraintlayout/solver/widgets/analyzer/DependencyNode;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual bool IsCenterConnection
		{
			[Register("isCenterConnection", "()Z", "GetIsCenterConnectionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isCenterConnection.()Z", this, null);
			}
		}

		public unsafe virtual bool IsDimensionResolved
		{
			[Register("isDimensionResolved", "()Z", "GetIsDimensionResolvedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDimensionResolved.()Z", this, null);
			}
		}

		public unsafe virtual bool IsResolved
		{
			[Register("isResolved", "()Z", "GetIsResolvedHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isResolved.()Z", this, null);
			}
		}

		public unsafe virtual long WrapDimension
		{
			[Register("getWrapDimension", "()J", "GetGetWrapDimensionHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt64Method("getWrapDimension.()J", this, null);
			}
		}

		protected WidgetRun(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)V", "")]
		public unsafe WidgetRun(ConstraintWidget widget)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(widget?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/constraintlayout/solver/widgets/ConstraintWidget;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(widget);
			}
		}

		private static Delegate GetIsCenterConnectionHandler()
		{
			if ((object)cb_isCenterConnection == null)
			{
				cb_isCenterConnection = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsCenterConnection));
			}
			return cb_isCenterConnection;
		}

		private static bool n_IsCenterConnection(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<WidgetRun>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCenterConnection;
		}

		private static Delegate GetIsDimensionResolvedHandler()
		{
			if ((object)cb_isDimensionResolved == null)
			{
				cb_isDimensionResolved = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsDimensionResolved));
			}
			return cb_isDimensionResolved;
		}

		private static bool n_IsDimensionResolved(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<WidgetRun>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsDimensionResolved;
		}

		private static Delegate GetIsResolvedHandler()
		{
			if ((object)cb_isResolved == null)
			{
				cb_isResolved = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsResolved));
			}
			return cb_isResolved;
		}

		private static bool n_IsResolved(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<WidgetRun>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsResolved;
		}

		private static Delegate GetGetWrapDimensionHandler()
		{
			if ((object)cb_getWrapDimension == null)
			{
				cb_getWrapDimension = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_GetWrapDimension));
			}
			return cb_getWrapDimension;
		}

		private static long n_GetWrapDimension(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<WidgetRun>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WrapDimension;
		}

		[Register("addTarget", "(Landroidx/constraintlayout/solver/widgets/analyzer/DependencyNode;Landroidx/constraintlayout/solver/widgets/analyzer/DependencyNode;I)V", "")]
		protected unsafe void AddTarget(DependencyNode node, DependencyNode target, int margin)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(node?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(target?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(margin);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("addTarget.(Landroidx/constraintlayout/solver/widgets/analyzer/DependencyNode;Landroidx/constraintlayout/solver/widgets/analyzer/DependencyNode;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(node);
				GC.KeepAlive(target);
			}
		}

		[Register("getLimitedDimension", "(II)I", "")]
		protected unsafe int GetLimitedDimension(int dimension, int orientation)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(dimension);
			ptr[1] = new JniArgumentValue(orientation);
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("getLimitedDimension.(II)I", this, ptr);
		}

		[Register("getTarget", "(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;)Landroidx/constraintlayout/solver/widgets/analyzer/DependencyNode;", "")]
		protected unsafe DependencyNode GetTarget(ConstraintAnchor anchor)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(anchor?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<DependencyNode>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTarget.(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;)Landroidx/constraintlayout/solver/widgets/analyzer/DependencyNode;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(anchor);
			}
		}

		[Register("getTarget", "(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;I)Landroidx/constraintlayout/solver/widgets/analyzer/DependencyNode;", "")]
		protected unsafe DependencyNode GetTarget(ConstraintAnchor anchor, int orientation)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(anchor?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(orientation);
				return Java.Lang.Object.GetObject<DependencyNode>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTarget.(Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;I)Landroidx/constraintlayout/solver/widgets/analyzer/DependencyNode;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(anchor);
			}
		}

		private static Delegate GetUpdate_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_Handler()
		{
			if ((object)cb_update_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_ == null)
			{
				cb_update_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Update_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_));
			}
			return cb_update_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_;
		}

		private static void n_Update_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_(IntPtr jnienv, IntPtr native__this, IntPtr native_dependency)
		{
			WidgetRun widgetRun = Java.Lang.Object.GetObject<WidgetRun>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDependency dependency = Java.Lang.Object.GetObject<IDependency>(native_dependency, JniHandleOwnership.DoNotTransfer);
			widgetRun.Update(dependency);
		}

		[Register("update", "(Landroidx/constraintlayout/solver/widgets/analyzer/Dependency;)V", "GetUpdate_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_Handler")]
		public unsafe virtual void Update(IDependency dependency)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((dependency == null) ? IntPtr.Zero : ((Java.Lang.Object)dependency).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("update.(Landroidx/constraintlayout/solver/widgets/analyzer/Dependency;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(dependency);
			}
		}

		private static Delegate GetUpdateRunCenter_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_IHandler()
		{
			if ((object)cb_updateRunCenter_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_I == null)
			{
				cb_updateRunCenter_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_I = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLLLI_V(n_UpdateRunCenter_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_I));
			}
			return cb_updateRunCenter_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_I;
		}

		private static void n_UpdateRunCenter_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_I(IntPtr jnienv, IntPtr native__this, IntPtr native_dependency, IntPtr native_startAnchor, IntPtr native_endAnchor, int orientation)
		{
			WidgetRun widgetRun = Java.Lang.Object.GetObject<WidgetRun>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDependency dependency = Java.Lang.Object.GetObject<IDependency>(native_dependency, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor startAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(native_startAnchor, JniHandleOwnership.DoNotTransfer);
			ConstraintAnchor endAnchor = Java.Lang.Object.GetObject<ConstraintAnchor>(native_endAnchor, JniHandleOwnership.DoNotTransfer);
			widgetRun.UpdateRunCenter(dependency, startAnchor, endAnchor, orientation);
		}

		[Register("updateRunCenter", "(Landroidx/constraintlayout/solver/widgets/analyzer/Dependency;Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;I)V", "GetUpdateRunCenter_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_Landroidx_constraintlayout_solver_widgets_ConstraintAnchor_IHandler")]
		protected unsafe virtual void UpdateRunCenter(IDependency dependency, ConstraintAnchor startAnchor, ConstraintAnchor endAnchor, int orientation)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue((dependency == null) ? IntPtr.Zero : ((Java.Lang.Object)dependency).Handle);
				ptr[1] = new JniArgumentValue(startAnchor?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(endAnchor?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(orientation);
				_members.InstanceMethods.InvokeVirtualVoidMethod("updateRunCenter.(Landroidx/constraintlayout/solver/widgets/analyzer/Dependency;Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;Landroidx/constraintlayout/solver/widgets/ConstraintAnchor;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(dependency);
				GC.KeepAlive(startAnchor);
				GC.KeepAlive(endAnchor);
			}
		}

		private static Delegate GetUpdateRunEnd_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_Handler()
		{
			if ((object)cb_updateRunEnd_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_ == null)
			{
				cb_updateRunEnd_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UpdateRunEnd_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_));
			}
			return cb_updateRunEnd_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_;
		}

		private static void n_UpdateRunEnd_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_(IntPtr jnienv, IntPtr native__this, IntPtr native_dependency)
		{
			WidgetRun widgetRun = Java.Lang.Object.GetObject<WidgetRun>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDependency dependency = Java.Lang.Object.GetObject<IDependency>(native_dependency, JniHandleOwnership.DoNotTransfer);
			widgetRun.UpdateRunEnd(dependency);
		}

		[Register("updateRunEnd", "(Landroidx/constraintlayout/solver/widgets/analyzer/Dependency;)V", "GetUpdateRunEnd_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_Handler")]
		protected unsafe virtual void UpdateRunEnd(IDependency dependency)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((dependency == null) ? IntPtr.Zero : ((Java.Lang.Object)dependency).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("updateRunEnd.(Landroidx/constraintlayout/solver/widgets/analyzer/Dependency;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(dependency);
			}
		}

		private static Delegate GetUpdateRunStart_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_Handler()
		{
			if ((object)cb_updateRunStart_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_ == null)
			{
				cb_updateRunStart_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_UpdateRunStart_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_));
			}
			return cb_updateRunStart_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_;
		}

		private static void n_UpdateRunStart_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_(IntPtr jnienv, IntPtr native__this, IntPtr native_dependency)
		{
			WidgetRun widgetRun = Java.Lang.Object.GetObject<WidgetRun>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IDependency dependency = Java.Lang.Object.GetObject<IDependency>(native_dependency, JniHandleOwnership.DoNotTransfer);
			widgetRun.UpdateRunStart(dependency);
		}

		[Register("updateRunStart", "(Landroidx/constraintlayout/solver/widgets/analyzer/Dependency;)V", "GetUpdateRunStart_Landroidx_constraintlayout_solver_widgets_analyzer_Dependency_Handler")]
		protected unsafe virtual void UpdateRunStart(IDependency dependency)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((dependency == null) ? IntPtr.Zero : ((Java.Lang.Object)dependency).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("updateRunStart.(Landroidx/constraintlayout/solver/widgets/analyzer/Dependency;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(dependency);
			}
		}

		private static Delegate GetWrapSize_IHandler()
		{
			if ((object)cb_wrapSize_I == null)
			{
				cb_wrapSize_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_J(n_WrapSize_I));
			}
			return cb_wrapSize_I;
		}

		private static long n_WrapSize_I(IntPtr jnienv, IntPtr native__this, int direction)
		{
			return Java.Lang.Object.GetObject<WidgetRun>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WrapSize(direction);
		}

		[Register("wrapSize", "(I)J", "GetWrapSize_IHandler")]
		public unsafe virtual long WrapSize(int direction)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(direction);
			return _members.InstanceMethods.InvokeVirtualInt64Method("wrapSize.(I)J", this, ptr);
		}
	}
	[Register("androidx/constraintlayout/solver/widgets/analyzer/WidgetRun", DoNotGenerateAcw = true)]
	internal class WidgetRunInvoker : WidgetRun
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/constraintlayout/solver/widgets/analyzer/WidgetRun", typeof(WidgetRunInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public WidgetRunInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
}
