using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("Naxam.Jakewharton.Timber")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("NAXAM CO.,LTD")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("Copyright (c) 2017 NAXAM")]
[assembly: AssemblyTrademark("NAXAM")]
[assembly: AssemblyInformationalVersion("4.5.1")]
[assembly: NamespaceMapping(Java = "timber.log", Managed = "Timber.Log")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("4.7.1.0")]
[module: UnverifiableCode]
namespace Timber.Log
{
	[Register("timber/log/Timber", DoNotGenerateAcw = true)]
	public sealed class Timber : Java.Lang.Object
	{
		[Register("timber/log/Timber$DebugTree", DoNotGenerateAcw = true)]
		public class DebugTree : Tree
		{
			internal new static readonly JniPeerMembers _members = new XAPeerMembers("timber/log/Timber$DebugTree", typeof(DebugTree));

			private static Delegate cb_createStackElementTag_Ljava_lang_StackTraceElement_;

			private static Delegate cb_log_ILjava_lang_String_Ljava_lang_String_Ljava_lang_Throwable_;

			internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			protected DebugTree(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe DebugTree()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetCreateStackElementTag_Ljava_lang_StackTraceElement_Handler()
			{
				if ((object)cb_createStackElementTag_Ljava_lang_StackTraceElement_ == null)
				{
					cb_createStackElementTag_Ljava_lang_StackTraceElement_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr>(n_CreateStackElementTag_Ljava_lang_StackTraceElement_));
				}
				return cb_createStackElementTag_Ljava_lang_StackTraceElement_;
			}

			private static IntPtr n_CreateStackElementTag_Ljava_lang_StackTraceElement_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				DebugTree debugTree = Java.Lang.Object.GetObject<DebugTree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				StackTraceElement p = Java.Lang.Object.GetObject<StackTraceElement>(native_p0, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.NewString(debugTree.CreateStackElementTag(p));
			}

			[Register("createStackElementTag", "(Ljava/lang/StackTraceElement;)Ljava/lang/String;", "GetCreateStackElementTag_Ljava_lang_StackTraceElement_Handler")]
			protected unsafe virtual string CreateStackElementTag(StackTraceElement p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				string result = JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("createStackElementTag.(Ljava/lang/StackTraceElement;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				GC.KeepAlive(p0);
				return result;
			}

			private static Delegate GetLog_ILjava_lang_String_Ljava_lang_String_Ljava_lang_Throwable_Handler()
			{
				if ((object)cb_log_ILjava_lang_String_Ljava_lang_String_Ljava_lang_Throwable_ == null)
				{
					cb_log_ILjava_lang_String_Ljava_lang_String_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int, IntPtr, IntPtr, IntPtr>(n_Log_ILjava_lang_String_Ljava_lang_String_Ljava_lang_Throwable_));
				}
				return cb_log_ILjava_lang_String_Ljava_lang_String_Ljava_lang_Throwable_;
			}

			private static void n_Log_ILjava_lang_String_Ljava_lang_String_Ljava_lang_Throwable_(IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
			{
				DebugTree debugTree = Java.Lang.Object.GetObject<DebugTree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string p1 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
				string p2 = JNIEnv.GetString(native_p2, JniHandleOwnership.DoNotTransfer);
				Throwable p3 = Java.Lang.Object.GetObject<Throwable>(native_p3, JniHandleOwnership.DoNotTransfer);
				debugTree.Log(p0, p1, p2, p3);
			}

			[Register("log", "(ILjava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)V", "GetLog_ILjava_lang_String_Ljava_lang_String_Ljava_lang_Throwable_Handler")]
			protected unsafe override void Log(int p0, string p1, string p2, Throwable p3)
			{
				IntPtr intPtr = JNIEnv.NewString(p1);
				IntPtr intPtr2 = JNIEnv.NewString(p2);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
					*ptr = new JniArgumentValue(p0);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(intPtr2);
					ptr[3] = new JniArgumentValue(p3?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeVirtualVoidMethod("log.(ILjava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(p3);
				}
			}
		}

		[Register("timber/log/Timber$Tree", DoNotGenerateAcw = true)]
		public abstract class Tree : Java.Lang.Object
		{
			internal static readonly JniPeerMembers _members = new XAPeerMembers("timber/log/Timber$Tree", typeof(Tree));

			private static Delegate cb_d_Ljava_lang_String_arrayLjava_lang_Object_;

			private static Delegate cb_d_Ljava_lang_Throwable_;

			private static Delegate cb_d_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_;

			private static Delegate cb_e_Ljava_lang_String_arrayLjava_lang_Object_;

			private static Delegate cb_e_Ljava_lang_Throwable_;

			private static Delegate cb_e_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_;

			private static Delegate cb_formatMessage_Ljava_lang_String_arrayLjava_lang_Object_;

			private static Delegate cb_i_Ljava_lang_String_arrayLjava_lang_Object_;

			private static Delegate cb_i_Ljava_lang_Throwable_;

			private static Delegate cb_i_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_;

			private static Delegate cb_isLoggable_I;

			private static Delegate cb_isLoggable_Ljava_lang_String_I;

			private static Delegate cb_log_ILjava_lang_String_arrayLjava_lang_Object_;

			private static Delegate cb_log_ILjava_lang_String_Ljava_lang_String_Ljava_lang_Throwable_;

			private static Delegate cb_log_ILjava_lang_Throwable_;

			private static Delegate cb_log_ILjava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_;

			private static Delegate cb_v_Ljava_lang_String_arrayLjava_lang_Object_;

			private static Delegate cb_v_Ljava_lang_Throwable_;

			private static Delegate cb_v_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_;

			private static Delegate cb_w_Ljava_lang_String_arrayLjava_lang_Object_;

			private static Delegate cb_w_Ljava_lang_Throwable_;

			private static Delegate cb_w_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_;

			private static Delegate cb_wtf_Ljava_lang_String_arrayLjava_lang_Object_;

			private static Delegate cb_wtf_Ljava_lang_Throwable_;

			private static Delegate cb_wtf_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_;

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			public override JniPeerMembers JniPeerMembers => _members;

			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			protected override Type ThresholdType => _members.ManagedPeerType;

			protected Tree(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Tree()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			private static Delegate GetD_Ljava_lang_String_arrayLjava_lang_Object_Handler()
			{
				if ((object)cb_d_Ljava_lang_String_arrayLjava_lang_Object_ == null)
				{
					cb_d_Ljava_lang_String_arrayLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr>(n_D_Ljava_lang_String_arrayLjava_lang_Object_));
				}
				return cb_d_Ljava_lang_String_arrayLjava_lang_Object_;
			}

			private static void n_D_Ljava_lang_String_arrayLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object[] array = (Java.Lang.Object[])JNIEnv.GetArray(native_p1, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Object));
				tree.D(p, array);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_p1);
				}
			}

			[Register("d", "(Ljava/lang/String;[Ljava/lang/Object;)V", "GetD_Ljava_lang_String_arrayLjava_lang_Object_Handler")]
			public unsafe virtual void D(string p0, params Java.Lang.Object[] p1)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				IntPtr intPtr2 = JNIEnv.NewArray(p1);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					_members.InstanceMethods.InvokeVirtualVoidMethod("d.(Ljava/lang/String;[Ljava/lang/Object;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (p1 != null)
					{
						JNIEnv.CopyArray(intPtr2, p1);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
				}
			}

			private static Delegate GetD_Ljava_lang_Throwable_Handler()
			{
				if ((object)cb_d_Ljava_lang_Throwable_ == null)
				{
					cb_d_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_D_Ljava_lang_Throwable_));
				}
				return cb_d_Ljava_lang_Throwable_;
			}

			private static void n_D_Ljava_lang_Throwable_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Throwable p = Java.Lang.Object.GetObject<Throwable>(native_p0, JniHandleOwnership.DoNotTransfer);
				tree.D(p);
			}

			[Register("d", "(Ljava/lang/Throwable;)V", "GetD_Ljava_lang_Throwable_Handler")]
			public unsafe virtual void D(Throwable p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("d.(Ljava/lang/Throwable;)V", this, ptr);
			}

			private static Delegate GetD_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_Handler()
			{
				if ((object)cb_d_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_ == null)
				{
					cb_d_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>(n_D_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_));
				}
				return cb_d_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_;
			}

			private static void n_D_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Throwable p = Java.Lang.Object.GetObject<Throwable>(native_p0, JniHandleOwnership.DoNotTransfer);
				string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object[] array = (Java.Lang.Object[])JNIEnv.GetArray(native_p2, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Object));
				tree.D(p, p2, array);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_p2);
				}
			}

			[Register("d", "(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", "GetD_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_Handler")]
			public unsafe virtual void D(Throwable p0, string p1, params Java.Lang.Object[] p2)
			{
				IntPtr intPtr = JNIEnv.NewString(p1);
				IntPtr intPtr2 = JNIEnv.NewArray(p2);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(intPtr2);
					_members.InstanceMethods.InvokeVirtualVoidMethod("d.(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (p2 != null)
					{
						JNIEnv.CopyArray(intPtr2, p2);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
				}
			}

			private static Delegate GetE_Ljava_lang_String_arrayLjava_lang_Object_Handler()
			{
				if ((object)cb_e_Ljava_lang_String_arrayLjava_lang_Object_ == null)
				{
					cb_e_Ljava_lang_String_arrayLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr>(n_E_Ljava_lang_String_arrayLjava_lang_Object_));
				}
				return cb_e_Ljava_lang_String_arrayLjava_lang_Object_;
			}

			private static void n_E_Ljava_lang_String_arrayLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object[] array = (Java.Lang.Object[])JNIEnv.GetArray(native_p1, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Object));
				tree.E(p, array);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_p1);
				}
			}

			[Register("e", "(Ljava/lang/String;[Ljava/lang/Object;)V", "GetE_Ljava_lang_String_arrayLjava_lang_Object_Handler")]
			public unsafe virtual void E(string p0, params Java.Lang.Object[] p1)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				IntPtr intPtr2 = JNIEnv.NewArray(p1);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					_members.InstanceMethods.InvokeVirtualVoidMethod("e.(Ljava/lang/String;[Ljava/lang/Object;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (p1 != null)
					{
						JNIEnv.CopyArray(intPtr2, p1);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
				}
			}

			private static Delegate GetE_Ljava_lang_Throwable_Handler()
			{
				if ((object)cb_e_Ljava_lang_Throwable_ == null)
				{
					cb_e_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_E_Ljava_lang_Throwable_));
				}
				return cb_e_Ljava_lang_Throwable_;
			}

			private static void n_E_Ljava_lang_Throwable_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Throwable p = Java.Lang.Object.GetObject<Throwable>(native_p0, JniHandleOwnership.DoNotTransfer);
				tree.E(p);
			}

			[Register("e", "(Ljava/lang/Throwable;)V", "GetE_Ljava_lang_Throwable_Handler")]
			public unsafe virtual void E(Throwable p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("e.(Ljava/lang/Throwable;)V", this, ptr);
			}

			private static Delegate GetE_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_Handler()
			{
				if ((object)cb_e_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_ == null)
				{
					cb_e_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>(n_E_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_));
				}
				return cb_e_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_;
			}

			private static void n_E_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Throwable p = Java.Lang.Object.GetObject<Throwable>(native_p0, JniHandleOwnership.DoNotTransfer);
				string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object[] array = (Java.Lang.Object[])JNIEnv.GetArray(native_p2, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Object));
				tree.E(p, p2, array);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_p2);
				}
			}

			[Register("e", "(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", "GetE_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_Handler")]
			public unsafe virtual void E(Throwable p0, string p1, params Java.Lang.Object[] p2)
			{
				IntPtr intPtr = JNIEnv.NewString(p1);
				IntPtr intPtr2 = JNIEnv.NewArray(p2);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(intPtr2);
					_members.InstanceMethods.InvokeVirtualVoidMethod("e.(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (p2 != null)
					{
						JNIEnv.CopyArray(intPtr2, p2);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
				}
			}

			private static Delegate GetFormatMessage_Ljava_lang_String_arrayLjava_lang_Object_Handler()
			{
				if ((object)cb_formatMessage_Ljava_lang_String_arrayLjava_lang_Object_ == null)
				{
					cb_formatMessage_Ljava_lang_String_arrayLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>(n_FormatMessage_Ljava_lang_String_arrayLjava_lang_Object_));
				}
				return cb_formatMessage_Ljava_lang_String_arrayLjava_lang_Object_;
			}

			private static IntPtr n_FormatMessage_Ljava_lang_String_arrayLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object[] array = (Java.Lang.Object[])JNIEnv.GetArray(native_p1, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Object));
				IntPtr result = JNIEnv.NewString(tree.FormatMessage(p, array));
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_p1);
				}
				return result;
			}

			[Register("formatMessage", "(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;", "GetFormatMessage_Ljava_lang_String_arrayLjava_lang_Object_Handler")]
			protected unsafe virtual string FormatMessage(string p0, Java.Lang.Object[] p1)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				IntPtr intPtr2 = JNIEnv.NewArray(p1);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("formatMessage.(Ljava/lang/String;[Ljava/lang/Object;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (p1 != null)
					{
						JNIEnv.CopyArray(intPtr2, p1);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
				}
			}

			private static Delegate GetI_Ljava_lang_String_arrayLjava_lang_Object_Handler()
			{
				if ((object)cb_i_Ljava_lang_String_arrayLjava_lang_Object_ == null)
				{
					cb_i_Ljava_lang_String_arrayLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr>(n_I_Ljava_lang_String_arrayLjava_lang_Object_));
				}
				return cb_i_Ljava_lang_String_arrayLjava_lang_Object_;
			}

			private static void n_I_Ljava_lang_String_arrayLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object[] array = (Java.Lang.Object[])JNIEnv.GetArray(native_p1, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Object));
				tree.I(p, array);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_p1);
				}
			}

			[Register("i", "(Ljava/lang/String;[Ljava/lang/Object;)V", "GetI_Ljava_lang_String_arrayLjava_lang_Object_Handler")]
			public unsafe virtual void I(string p0, params Java.Lang.Object[] p1)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				IntPtr intPtr2 = JNIEnv.NewArray(p1);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					_members.InstanceMethods.InvokeVirtualVoidMethod("i.(Ljava/lang/String;[Ljava/lang/Object;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (p1 != null)
					{
						JNIEnv.CopyArray(intPtr2, p1);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
				}
			}

			private static Delegate GetI_Ljava_lang_Throwable_Handler()
			{
				if ((object)cb_i_Ljava_lang_Throwable_ == null)
				{
					cb_i_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_I_Ljava_lang_Throwable_));
				}
				return cb_i_Ljava_lang_Throwable_;
			}

			private static void n_I_Ljava_lang_Throwable_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Throwable p = Java.Lang.Object.GetObject<Throwable>(native_p0, JniHandleOwnership.DoNotTransfer);
				tree.I(p);
			}

			[Register("i", "(Ljava/lang/Throwable;)V", "GetI_Ljava_lang_Throwable_Handler")]
			public unsafe virtual void I(Throwable p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("i.(Ljava/lang/Throwable;)V", this, ptr);
			}

			private static Delegate GetI_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_Handler()
			{
				if ((object)cb_i_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_ == null)
				{
					cb_i_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>(n_I_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_));
				}
				return cb_i_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_;
			}

			private static void n_I_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Throwable p = Java.Lang.Object.GetObject<Throwable>(native_p0, JniHandleOwnership.DoNotTransfer);
				string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object[] array = (Java.Lang.Object[])JNIEnv.GetArray(native_p2, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Object));
				tree.I(p, p2, array);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_p2);
				}
			}

			[Register("i", "(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", "GetI_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_Handler")]
			public unsafe virtual void I(Throwable p0, string p1, params Java.Lang.Object[] p2)
			{
				IntPtr intPtr = JNIEnv.NewString(p1);
				IntPtr intPtr2 = JNIEnv.NewArray(p2);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(intPtr2);
					_members.InstanceMethods.InvokeVirtualVoidMethod("i.(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (p2 != null)
					{
						JNIEnv.CopyArray(intPtr2, p2);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
				}
			}

			private static Delegate GetIsLoggable_IHandler()
			{
				if ((object)cb_isLoggable_I == null)
				{
					cb_isLoggable_I = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, bool>(n_IsLoggable_I));
				}
				return cb_isLoggable_I;
			}

			private static bool n_IsLoggable_I(IntPtr jnienv, IntPtr native__this, int p0)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return tree.IsLoggable(p0);
			}

			[Obsolete("deprecated")]
			[Register("isLoggable", "(I)Z", "GetIsLoggable_IHandler")]
			protected unsafe virtual bool IsLoggable(int p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isLoggable.(I)Z", this, ptr);
			}

			private static Delegate GetIsLoggable_Ljava_lang_String_IHandler()
			{
				if ((object)cb_isLoggable_Ljava_lang_String_I == null)
				{
					cb_isLoggable_Ljava_lang_String_I = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, int, bool>(n_IsLoggable_Ljava_lang_String_I));
				}
				return cb_isLoggable_Ljava_lang_String_I;
			}

			private static bool n_IsLoggable_Ljava_lang_String_I(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, int p1)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string p2 = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				return tree.IsLoggable(p2, p1);
			}

			[Register("isLoggable", "(Ljava/lang/String;I)Z", "GetIsLoggable_Ljava_lang_String_IHandler")]
			protected unsafe virtual bool IsLoggable(string p0, int p1)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(p1);
					return _members.InstanceMethods.InvokeVirtualBooleanMethod("isLoggable.(Ljava/lang/String;I)Z", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			private static Delegate GetLog_ILjava_lang_String_arrayLjava_lang_Object_Handler()
			{
				if ((object)cb_log_ILjava_lang_String_arrayLjava_lang_Object_ == null)
				{
					cb_log_ILjava_lang_String_arrayLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int, IntPtr, IntPtr>(n_Log_ILjava_lang_String_arrayLjava_lang_Object_));
				}
				return cb_log_ILjava_lang_String_arrayLjava_lang_Object_;
			}

			private static void n_Log_ILjava_lang_String_arrayLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string p1 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object[] array = (Java.Lang.Object[])JNIEnv.GetArray(native_p2, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Object));
				tree.Log(p0, p1, array);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_p2);
				}
			}

			[Register("log", "(ILjava/lang/String;[Ljava/lang/Object;)V", "GetLog_ILjava_lang_String_arrayLjava_lang_Object_Handler")]
			public unsafe virtual void Log(int p0, string p1, params Java.Lang.Object[] p2)
			{
				IntPtr intPtr = JNIEnv.NewString(p1);
				IntPtr intPtr2 = JNIEnv.NewArray(p2);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(p0);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(intPtr2);
					_members.InstanceMethods.InvokeVirtualVoidMethod("log.(ILjava/lang/String;[Ljava/lang/Object;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (p2 != null)
					{
						JNIEnv.CopyArray(intPtr2, p2);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
				}
			}

			private static Delegate GetLog_ILjava_lang_String_Ljava_lang_String_Ljava_lang_Throwable_Handler()
			{
				if ((object)cb_log_ILjava_lang_String_Ljava_lang_String_Ljava_lang_Throwable_ == null)
				{
					cb_log_ILjava_lang_String_Ljava_lang_String_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int, IntPtr, IntPtr, IntPtr>(n_Log_ILjava_lang_String_Ljava_lang_String_Ljava_lang_Throwable_));
				}
				return cb_log_ILjava_lang_String_Ljava_lang_String_Ljava_lang_Throwable_;
			}

			private static void n_Log_ILjava_lang_String_Ljava_lang_String_Ljava_lang_Throwable_(IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string p1 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
				string p2 = JNIEnv.GetString(native_p2, JniHandleOwnership.DoNotTransfer);
				Throwable p3 = Java.Lang.Object.GetObject<Throwable>(native_p3, JniHandleOwnership.DoNotTransfer);
				tree.Log(p0, p1, p2, p3);
			}

			[Register("log", "(ILjava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)V", "GetLog_ILjava_lang_String_Ljava_lang_String_Ljava_lang_Throwable_Handler")]
			protected abstract void Log(int p0, string p1, string p2, Throwable p3);

			private static Delegate GetLog_ILjava_lang_Throwable_Handler()
			{
				if ((object)cb_log_ILjava_lang_Throwable_ == null)
				{
					cb_log_ILjava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int, IntPtr>(n_Log_ILjava_lang_Throwable_));
				}
				return cb_log_ILjava_lang_Throwable_;
			}

			private static void n_Log_ILjava_lang_Throwable_(IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Throwable p1 = Java.Lang.Object.GetObject<Throwable>(native_p1, JniHandleOwnership.DoNotTransfer);
				tree.Log(p0, p1);
			}

			[Register("log", "(ILjava/lang/Throwable;)V", "GetLog_ILjava_lang_Throwable_Handler")]
			public unsafe virtual void Log(int p0, Throwable p1)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("log.(ILjava/lang/Throwable;)V", this, ptr);
			}

			private static Delegate GetLog_ILjava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_Handler()
			{
				if ((object)cb_log_ILjava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_ == null)
				{
					cb_log_ILjava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int, IntPtr, IntPtr, IntPtr>(n_Log_ILjava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_));
				}
				return cb_log_ILjava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_;
			}

			private static void n_Log_ILjava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, int p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Throwable p1 = Java.Lang.Object.GetObject<Throwable>(native_p1, JniHandleOwnership.DoNotTransfer);
				string p2 = JNIEnv.GetString(native_p2, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object[] array = (Java.Lang.Object[])JNIEnv.GetArray(native_p3, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Object));
				tree.Log(p0, p1, p2, array);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_p3);
				}
			}

			[Register("log", "(ILjava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", "GetLog_ILjava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_Handler")]
			public unsafe virtual void Log(int p0, Throwable p1, string p2, params Java.Lang.Object[] p3)
			{
				IntPtr intPtr = JNIEnv.NewString(p2);
				IntPtr intPtr2 = JNIEnv.NewArray(p3);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
					*ptr = new JniArgumentValue(p0);
					ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
					ptr[2] = new JniArgumentValue(intPtr);
					ptr[3] = new JniArgumentValue(intPtr2);
					_members.InstanceMethods.InvokeVirtualVoidMethod("log.(ILjava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (p3 != null)
					{
						JNIEnv.CopyArray(intPtr2, p3);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
				}
			}

			private static Delegate GetV_Ljava_lang_String_arrayLjava_lang_Object_Handler()
			{
				if ((object)cb_v_Ljava_lang_String_arrayLjava_lang_Object_ == null)
				{
					cb_v_Ljava_lang_String_arrayLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr>(n_V_Ljava_lang_String_arrayLjava_lang_Object_));
				}
				return cb_v_Ljava_lang_String_arrayLjava_lang_Object_;
			}

			private static void n_V_Ljava_lang_String_arrayLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object[] array = (Java.Lang.Object[])JNIEnv.GetArray(native_p1, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Object));
				tree.V(p, array);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_p1);
				}
			}

			[Register("v", "(Ljava/lang/String;[Ljava/lang/Object;)V", "GetV_Ljava_lang_String_arrayLjava_lang_Object_Handler")]
			public unsafe virtual void V(string p0, params Java.Lang.Object[] p1)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				IntPtr intPtr2 = JNIEnv.NewArray(p1);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					_members.InstanceMethods.InvokeVirtualVoidMethod("v.(Ljava/lang/String;[Ljava/lang/Object;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (p1 != null)
					{
						JNIEnv.CopyArray(intPtr2, p1);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
				}
			}

			private static Delegate GetV_Ljava_lang_Throwable_Handler()
			{
				if ((object)cb_v_Ljava_lang_Throwable_ == null)
				{
					cb_v_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_V_Ljava_lang_Throwable_));
				}
				return cb_v_Ljava_lang_Throwable_;
			}

			private static void n_V_Ljava_lang_Throwable_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Throwable p = Java.Lang.Object.GetObject<Throwable>(native_p0, JniHandleOwnership.DoNotTransfer);
				tree.V(p);
			}

			[Register("v", "(Ljava/lang/Throwable;)V", "GetV_Ljava_lang_Throwable_Handler")]
			public unsafe virtual void V(Throwable p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("v.(Ljava/lang/Throwable;)V", this, ptr);
			}

			private static Delegate GetV_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_Handler()
			{
				if ((object)cb_v_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_ == null)
				{
					cb_v_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>(n_V_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_));
				}
				return cb_v_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_;
			}

			private static void n_V_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Throwable p = Java.Lang.Object.GetObject<Throwable>(native_p0, JniHandleOwnership.DoNotTransfer);
				string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object[] array = (Java.Lang.Object[])JNIEnv.GetArray(native_p2, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Object));
				tree.V(p, p2, array);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_p2);
				}
			}

			[Register("v", "(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", "GetV_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_Handler")]
			public unsafe virtual void V(Throwable p0, string p1, params Java.Lang.Object[] p2)
			{
				IntPtr intPtr = JNIEnv.NewString(p1);
				IntPtr intPtr2 = JNIEnv.NewArray(p2);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(intPtr2);
					_members.InstanceMethods.InvokeVirtualVoidMethod("v.(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (p2 != null)
					{
						JNIEnv.CopyArray(intPtr2, p2);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
				}
			}

			private static Delegate GetW_Ljava_lang_String_arrayLjava_lang_Object_Handler()
			{
				if ((object)cb_w_Ljava_lang_String_arrayLjava_lang_Object_ == null)
				{
					cb_w_Ljava_lang_String_arrayLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr>(n_W_Ljava_lang_String_arrayLjava_lang_Object_));
				}
				return cb_w_Ljava_lang_String_arrayLjava_lang_Object_;
			}

			private static void n_W_Ljava_lang_String_arrayLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object[] array = (Java.Lang.Object[])JNIEnv.GetArray(native_p1, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Object));
				tree.W(p, array);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_p1);
				}
			}

			[Register("w", "(Ljava/lang/String;[Ljava/lang/Object;)V", "GetW_Ljava_lang_String_arrayLjava_lang_Object_Handler")]
			public unsafe virtual void W(string p0, params Java.Lang.Object[] p1)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				IntPtr intPtr2 = JNIEnv.NewArray(p1);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					_members.InstanceMethods.InvokeVirtualVoidMethod("w.(Ljava/lang/String;[Ljava/lang/Object;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (p1 != null)
					{
						JNIEnv.CopyArray(intPtr2, p1);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
				}
			}

			private static Delegate GetW_Ljava_lang_Throwable_Handler()
			{
				if ((object)cb_w_Ljava_lang_Throwable_ == null)
				{
					cb_w_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_W_Ljava_lang_Throwable_));
				}
				return cb_w_Ljava_lang_Throwable_;
			}

			private static void n_W_Ljava_lang_Throwable_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Throwable p = Java.Lang.Object.GetObject<Throwable>(native_p0, JniHandleOwnership.DoNotTransfer);
				tree.W(p);
			}

			[Register("w", "(Ljava/lang/Throwable;)V", "GetW_Ljava_lang_Throwable_Handler")]
			public unsafe virtual void W(Throwable p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("w.(Ljava/lang/Throwable;)V", this, ptr);
			}

			private static Delegate GetW_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_Handler()
			{
				if ((object)cb_w_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_ == null)
				{
					cb_w_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>(n_W_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_));
				}
				return cb_w_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_;
			}

			private static void n_W_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Throwable p = Java.Lang.Object.GetObject<Throwable>(native_p0, JniHandleOwnership.DoNotTransfer);
				string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object[] array = (Java.Lang.Object[])JNIEnv.GetArray(native_p2, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Object));
				tree.W(p, p2, array);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_p2);
				}
			}

			[Register("w", "(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", "GetW_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_Handler")]
			public unsafe virtual void W(Throwable p0, string p1, params Java.Lang.Object[] p2)
			{
				IntPtr intPtr = JNIEnv.NewString(p1);
				IntPtr intPtr2 = JNIEnv.NewArray(p2);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(intPtr2);
					_members.InstanceMethods.InvokeVirtualVoidMethod("w.(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (p2 != null)
					{
						JNIEnv.CopyArray(intPtr2, p2);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
				}
			}

			private static Delegate GetWtf_Ljava_lang_String_arrayLjava_lang_Object_Handler()
			{
				if ((object)cb_wtf_Ljava_lang_String_arrayLjava_lang_Object_ == null)
				{
					cb_wtf_Ljava_lang_String_arrayLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr>(n_Wtf_Ljava_lang_String_arrayLjava_lang_Object_));
				}
				return cb_wtf_Ljava_lang_String_arrayLjava_lang_Object_;
			}

			private static void n_Wtf_Ljava_lang_String_arrayLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object[] array = (Java.Lang.Object[])JNIEnv.GetArray(native_p1, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Object));
				tree.Wtf(p, array);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_p1);
				}
			}

			[Register("wtf", "(Ljava/lang/String;[Ljava/lang/Object;)V", "GetWtf_Ljava_lang_String_arrayLjava_lang_Object_Handler")]
			public unsafe virtual void Wtf(string p0, params Java.Lang.Object[] p1)
			{
				IntPtr intPtr = JNIEnv.NewString(p0);
				IntPtr intPtr2 = JNIEnv.NewArray(p1);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(intPtr2);
					_members.InstanceMethods.InvokeVirtualVoidMethod("wtf.(Ljava/lang/String;[Ljava/lang/Object;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (p1 != null)
					{
						JNIEnv.CopyArray(intPtr2, p1);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
				}
			}

			private static Delegate GetWtf_Ljava_lang_Throwable_Handler()
			{
				if ((object)cb_wtf_Ljava_lang_Throwable_ == null)
				{
					cb_wtf_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_Wtf_Ljava_lang_Throwable_));
				}
				return cb_wtf_Ljava_lang_Throwable_;
			}

			private static void n_Wtf_Ljava_lang_Throwable_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Throwable p = Java.Lang.Object.GetObject<Throwable>(native_p0, JniHandleOwnership.DoNotTransfer);
				tree.Wtf(p);
			}

			[Register("wtf", "(Ljava/lang/Throwable;)V", "GetWtf_Ljava_lang_Throwable_Handler")]
			public unsafe virtual void Wtf(Throwable p0)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("wtf.(Ljava/lang/Throwable;)V", this, ptr);
			}

			private static Delegate GetWtf_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_Handler()
			{
				if ((object)cb_wtf_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_ == null)
				{
					cb_wtf_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>(n_Wtf_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_));
				}
				return cb_wtf_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_;
			}

			private static void n_Wtf_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
			{
				Tree tree = Java.Lang.Object.GetObject<Tree>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				Throwable p = Java.Lang.Object.GetObject<Throwable>(native_p0, JniHandleOwnership.DoNotTransfer);
				string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
				Java.Lang.Object[] array = (Java.Lang.Object[])JNIEnv.GetArray(native_p2, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Object));
				tree.Wtf(p, p2, array);
				if (array != null)
				{
					JNIEnv.CopyArray(array, native_p2);
				}
			}

			[Register("wtf", "(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", "GetWtf_Ljava_lang_Throwable_Ljava_lang_String_arrayLjava_lang_Object_Handler")]
			public unsafe virtual void Wtf(Throwable p0, string p1, params Java.Lang.Object[] p2)
			{
				IntPtr intPtr = JNIEnv.NewString(p1);
				IntPtr intPtr2 = JNIEnv.NewArray(p2);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(intPtr2);
					_members.InstanceMethods.InvokeVirtualVoidMethod("wtf.(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					if (p2 != null)
					{
						JNIEnv.CopyArray(intPtr2, p2);
						JNIEnv.DeleteLocalRef(intPtr2);
					}
				}
			}
		}

		[Register("timber/log/Timber$Tree", DoNotGenerateAcw = true)]
		internal class TreeInvoker : Tree
		{
			internal new static readonly JniPeerMembers _members = new JniPeerMembers("timber/log/Timber$Tree", typeof(TreeInvoker));

			public override JniPeerMembers JniPeerMembers => _members;

			protected override Type ThresholdType => _members.ManagedPeerType;

			public TreeInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}

			[Register("log", "(ILjava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)V", "GetLog_ILjava_lang_String_Ljava_lang_String_Ljava_lang_Throwable_Handler")]
			protected unsafe override void Log(int p0, string p1, string p2, Throwable p3)
			{
				IntPtr intPtr = JNIEnv.NewString(p1);
				IntPtr intPtr2 = JNIEnv.NewString(p2);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
					*ptr = new JniArgumentValue(p0);
					ptr[1] = new JniArgumentValue(intPtr);
					ptr[2] = new JniArgumentValue(intPtr2);
					ptr[3] = new JniArgumentValue(p3?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("log.(ILjava/lang/String;Ljava/lang/String;Ljava/lang/Throwable;)V", this, ptr);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(p3);
				}
			}
		}

		internal static readonly JniPeerMembers _members = new XAPeerMembers("timber/log/Timber", typeof(Timber));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Timber(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("asTree", "()Ltimber/log/Timber$Tree;", "")]
		public unsafe static Tree AsTree()
		{
			return Java.Lang.Object.GetObject<Tree>(_members.StaticMethods.InvokeObjectMethod("asTree.()Ltimber/log/Timber$Tree;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("d", "(Ljava/lang/String;[Ljava/lang/Object;)V", "")]
		public unsafe static void D(string p0, params Java.Lang.Object[] p1)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewArray(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("d.(Ljava/lang/String;[Ljava/lang/Object;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (p1 != null)
				{
					JNIEnv.CopyArray(intPtr2, p1);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(p1);
				}
			}
		}

		[Register("d", "(Ljava/lang/Throwable;)V", "")]
		public unsafe static void D(Throwable p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("d.(Ljava/lang/Throwable;)V", ptr);
			GC.KeepAlive(p0);
		}

		[Register("d", "(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", "")]
		public unsafe static void D(Throwable p0, string p1, params Java.Lang.Object[] p2)
		{
			IntPtr intPtr = JNIEnv.NewString(p1);
			IntPtr intPtr2 = JNIEnv.NewArray(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("d.(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (p2 != null)
				{
					JNIEnv.CopyArray(intPtr2, p2);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(p0);
					GC.KeepAlive(p2);
				}
			}
		}

		[Register("e", "(Ljava/lang/String;[Ljava/lang/Object;)V", "")]
		public unsafe static void E(string p0, params Java.Lang.Object[] p1)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewArray(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("e.(Ljava/lang/String;[Ljava/lang/Object;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (p1 != null)
				{
					JNIEnv.CopyArray(intPtr2, p1);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(p1);
				}
			}
		}

		[Register("e", "(Ljava/lang/Throwable;)V", "")]
		public unsafe static void E(Throwable p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("e.(Ljava/lang/Throwable;)V", ptr);
			GC.KeepAlive(p0);
		}

		[Register("e", "(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", "")]
		public unsafe static void E(Throwable p0, string p1, params Java.Lang.Object[] p2)
		{
			IntPtr intPtr = JNIEnv.NewString(p1);
			IntPtr intPtr2 = JNIEnv.NewArray(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("e.(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (p2 != null)
				{
					JNIEnv.CopyArray(intPtr2, p2);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(p0);
					GC.KeepAlive(p2);
				}
			}
		}

		[Register("forest", "()Ljava/util/List;", "")]
		public unsafe static IList<Tree> Forest()
		{
			return JavaList<Tree>.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("forest.()Ljava/util/List;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("i", "(Ljava/lang/String;[Ljava/lang/Object;)V", "")]
		public unsafe static void I(string p0, params Java.Lang.Object[] p1)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewArray(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("i.(Ljava/lang/String;[Ljava/lang/Object;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (p1 != null)
				{
					JNIEnv.CopyArray(intPtr2, p1);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(p1);
				}
			}
		}

		[Register("i", "(Ljava/lang/Throwable;)V", "")]
		public unsafe static void I(Throwable p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("i.(Ljava/lang/Throwable;)V", ptr);
			GC.KeepAlive(p0);
		}

		[Register("i", "(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", "")]
		public unsafe static void I(Throwable p0, string p1, params Java.Lang.Object[] p2)
		{
			IntPtr intPtr = JNIEnv.NewString(p1);
			IntPtr intPtr2 = JNIEnv.NewArray(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("i.(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (p2 != null)
				{
					JNIEnv.CopyArray(intPtr2, p2);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(p0);
					GC.KeepAlive(p2);
				}
			}
		}

		[Register("log", "(ILjava/lang/String;[Ljava/lang/Object;)V", "")]
		public unsafe static void Log(int p0, string p1, params Java.Lang.Object[] p2)
		{
			IntPtr intPtr = JNIEnv.NewString(p1);
			IntPtr intPtr2 = JNIEnv.NewArray(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("log.(ILjava/lang/String;[Ljava/lang/Object;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (p2 != null)
				{
					JNIEnv.CopyArray(intPtr2, p2);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(p2);
				}
			}
		}

		[Register("log", "(ILjava/lang/Throwable;)V", "")]
		public unsafe static void Log(int p0, Throwable p1)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("log.(ILjava/lang/Throwable;)V", ptr);
			GC.KeepAlive(p1);
		}

		[Register("log", "(ILjava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", "")]
		public unsafe static void Log(int p0, Throwable p1, string p2, params Java.Lang.Object[] p3)
		{
			IntPtr intPtr = JNIEnv.NewString(p2);
			IntPtr intPtr2 = JNIEnv.NewArray(p3);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(p0);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				ptr[3] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("log.(ILjava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (p3 != null)
				{
					JNIEnv.CopyArray(intPtr2, p3);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(p1);
					GC.KeepAlive(p3);
				}
			}
		}

		[Register("plant", "(Ltimber/log/Timber$Tree;)V", "")]
		public unsafe static void Plant(Tree p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("plant.(Ltimber/log/Timber$Tree;)V", ptr);
			GC.KeepAlive(p0);
		}

		[Register("plant", "([Ltimber/log/Timber$Tree;)V", "")]
		public unsafe static void Plant(params Tree[] p0)
		{
			IntPtr intPtr = JNIEnv.NewArray(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("plant.([Ltimber/log/Timber$Tree;)V", ptr);
			}
			finally
			{
				if (p0 != null)
				{
					JNIEnv.CopyArray(intPtr, p0);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(p0);
				}
			}
		}

		[Register("tag", "(Ljava/lang/String;)Ltimber/log/Timber$Tree;", "")]
		public unsafe static Tree Tag(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Tree>(_members.StaticMethods.InvokeObjectMethod("tag.(Ljava/lang/String;)Ltimber/log/Timber$Tree;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("treeCount", "()I", "")]
		public unsafe static int TreeCount()
		{
			return _members.StaticMethods.InvokeInt32Method("treeCount.()I", null);
		}

		[Register("uproot", "(Ltimber/log/Timber$Tree;)V", "")]
		public unsafe static void Uproot(Tree p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("uproot.(Ltimber/log/Timber$Tree;)V", ptr);
			GC.KeepAlive(p0);
		}

		[Register("uprootAll", "()V", "")]
		public unsafe static void UprootAll()
		{
			_members.StaticMethods.InvokeVoidMethod("uprootAll.()V", null);
		}

		[Register("v", "(Ljava/lang/String;[Ljava/lang/Object;)V", "")]
		public unsafe static void V(string p0, params Java.Lang.Object[] p1)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewArray(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("v.(Ljava/lang/String;[Ljava/lang/Object;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (p1 != null)
				{
					JNIEnv.CopyArray(intPtr2, p1);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(p1);
				}
			}
		}

		[Register("v", "(Ljava/lang/Throwable;)V", "")]
		public unsafe static void V(Throwable p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("v.(Ljava/lang/Throwable;)V", ptr);
			GC.KeepAlive(p0);
		}

		[Register("v", "(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", "")]
		public unsafe static void V(Throwable p0, string p1, params Java.Lang.Object[] p2)
		{
			IntPtr intPtr = JNIEnv.NewString(p1);
			IntPtr intPtr2 = JNIEnv.NewArray(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("v.(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (p2 != null)
				{
					JNIEnv.CopyArray(intPtr2, p2);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(p0);
					GC.KeepAlive(p2);
				}
			}
		}

		[Register("w", "(Ljava/lang/String;[Ljava/lang/Object;)V", "")]
		public unsafe static void W(string p0, params Java.Lang.Object[] p1)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewArray(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("w.(Ljava/lang/String;[Ljava/lang/Object;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (p1 != null)
				{
					JNIEnv.CopyArray(intPtr2, p1);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(p1);
				}
			}
		}

		[Register("w", "(Ljava/lang/Throwable;)V", "")]
		public unsafe static void W(Throwable p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("w.(Ljava/lang/Throwable;)V", ptr);
			GC.KeepAlive(p0);
		}

		[Register("w", "(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", "")]
		public unsafe static void W(Throwable p0, string p1, params Java.Lang.Object[] p2)
		{
			IntPtr intPtr = JNIEnv.NewString(p1);
			IntPtr intPtr2 = JNIEnv.NewArray(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("w.(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (p2 != null)
				{
					JNIEnv.CopyArray(intPtr2, p2);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(p0);
					GC.KeepAlive(p2);
				}
			}
		}

		[Register("wtf", "(Ljava/lang/String;[Ljava/lang/Object;)V", "")]
		public unsafe static void Wtf(string p0, params Java.Lang.Object[] p1)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewArray(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("wtf.(Ljava/lang/String;[Ljava/lang/Object;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (p1 != null)
				{
					JNIEnv.CopyArray(intPtr2, p1);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(p1);
				}
			}
		}

		[Register("wtf", "(Ljava/lang/Throwable;)V", "")]
		public unsafe static void Wtf(Throwable p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.StaticMethods.InvokeVoidMethod("wtf.(Ljava/lang/Throwable;)V", ptr);
			GC.KeepAlive(p0);
		}

		[Register("wtf", "(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", "")]
		public unsafe static void Wtf(Throwable p0, string p1, params Java.Lang.Object[] p2)
		{
			IntPtr intPtr = JNIEnv.NewString(p1);
			IntPtr intPtr2 = JNIEnv.NewArray(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("wtf.(Ljava/lang/Throwable;Ljava/lang/String;[Ljava/lang/Object;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				if (p2 != null)
				{
					JNIEnv.CopyArray(intPtr2, p2);
					JNIEnv.DeleteLocalRef(intPtr2);
					GC.KeepAlive(p0);
					GC.KeepAlive(p2);
				}
			}
		}
	}
}
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[0], new Converter<string, Type>[0]);
		}

		private static Type Lookup(string[] mappings, string javaType)
		{
			string text = TypeManager.LookupTypeMapping(mappings, javaType);
			if (text == null)
			{
				return null;
			}
			return Type.GetType(text);
		}
	}
}
