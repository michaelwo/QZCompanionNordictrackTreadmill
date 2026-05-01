using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.Content;
using Android.Net;
using Android.Net.Wifi;
using Android.OS;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Java.Net;
using Java.Util;
using Org.Json;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("RouteThisAndroidBinding")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("")]
[assembly: AssemblyTrademark("")]
[assembly: NamespaceMapping(Java = "c.b.a", Managed = "C.B.A")]
[assembly: NamespaceMapping(Java = "com.routethis.androidsdk", Managed = "Com.Routethis.Androidsdk")]
[assembly: NamespaceMapping(Java = "com.routethis.androidsdk.a", Managed = "Com.Routethis.Androidsdk.A")]
[assembly: NamespaceMapping(Java = "com.routethis.androidsdk.a.a", Managed = "Com.Routethis.Androidsdk.A.A")]
[assembly: NamespaceMapping(Java = "com.routethis.androidsdk.helpers", Managed = "Com.Routethis.Androidsdk.Helpers")]
[assembly: TargetFramework("MonoAndroid,Version=v8.0", FrameworkDisplayName = "Xamarin.Android v8.0 Support")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		private static string[] package_com_routethis_androidsdk_helpers_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[1] { "com/routethis/androidsdk/helpers" }, new Converter<string, Type>[1] { lookup_com_routethis_androidsdk_helpers_package });
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

		private static Type lookup_com_routethis_androidsdk_helpers_package(string klass)
		{
			if (package_com_routethis_androidsdk_helpers_mappings == null)
			{
				package_com_routethis_androidsdk_helpers_mappings = new string[4] { "com/routethis/androidsdk/helpers/Ca:Com.Routethis.Androidsdk.Helpers.Ca", "com/routethis/androidsdk/helpers/Ea:Com.Routethis.Androidsdk.Helpers.Ea", "com/routethis/androidsdk/helpers/Ia:Com.Routethis.Androidsdk.Helpers.Ia", "com/routethis/androidsdk/helpers/Ka:Com.Routethis.Androidsdk.Helpers.Ka" };
			}
			return Lookup(package_com_routethis_androidsdk_helpers_mappings, klass);
		}
	}
}
namespace C.B.A
{
	[Register("c/b/a/B", DoNotGenerateAcw = true)]
	public class B : Java.Lang.Object, ISerializable, IJavaObject, IDisposable, IJavaPeerable, Java.Lang.IComparable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("c/b/a/B", typeof(B));

		private static Delegate cb_isAbsolute;

		private static Delegate cb_a;

		private static Delegate cb_a_Z;

		private static Delegate cb_a_Lc_b_a_B_;

		private static Delegate cb_b;

		private static Delegate cb_c;

		private static Delegate cb_compareTo_Ljava_lang_Object_;

		[Register("d")]
		public static B D => Java.Lang.Object.GetObject<B>(_members.StaticFields.GetObjectValue("d.Lc/b/a/B;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual bool IsAbsolute
		{
			[Register("isAbsolute", "()Z", "GetIsAbsoluteHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isAbsolute.()Z", this, null);
			}
		}

		protected B(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lc/b/a/B;I)V", "")]
		public unsafe B(B p0, int p1)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lc/b/a/B;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lc/b/a/B;I)V", this, ptr);
				GC.KeepAlive(p0);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;Lc/b/a/B;)V", "")]
		public unsafe B(string p0, B p1)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Lc/b/a/B;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Lc/b/a/B;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p1);
			}
		}

		private static Delegate GetIsAbsoluteHandler()
		{
			if ((object)cb_isAbsolute == null)
			{
				cb_isAbsolute = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_IsAbsolute));
			}
			return cb_isAbsolute;
		}

		private static bool n_IsAbsolute(IntPtr jnienv, IntPtr native__this)
		{
			B b = Java.Lang.Object.GetObject<B>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return b.IsAbsolute;
		}

		private static Delegate GetAHandler()
		{
			if ((object)cb_a == null)
			{
				cb_a = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_A));
			}
			return cb_a;
		}

		private static int n_A(IntPtr jnienv, IntPtr native__this)
		{
			B b = Java.Lang.Object.GetObject<B>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return b.A();
		}

		[Register("a", "()I", "GetAHandler")]
		public unsafe virtual int A()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("a.()I", this, null);
		}

		private static Delegate GetA_ZHandler()
		{
			if ((object)cb_a_Z == null)
			{
				cb_a_Z = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool, IntPtr>(n_A_Z));
			}
			return cb_a_Z;
		}

		private static IntPtr n_A_Z(IntPtr jnienv, IntPtr native__this, bool p0)
		{
			B b = Java.Lang.Object.GetObject<B>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(b.A(p0));
		}

		[Register("a", "(Z)Ljava/lang/String;", "GetA_ZHandler")]
		public unsafe virtual string A(bool p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("a.(Z)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetA_Lc_b_a_B_Handler()
		{
			if ((object)cb_a_Lc_b_a_B_ == null)
			{
				cb_a_Lc_b_a_B_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, bool>(n_A_Lc_b_a_B_));
			}
			return cb_a_Lc_b_a_B_;
		}

		private static bool n_A_Lc_b_a_B_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			B b = Java.Lang.Object.GetObject<B>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			B p = Java.Lang.Object.GetObject<B>(native_p0, JniHandleOwnership.DoNotTransfer);
			return b.A(p);
		}

		[Register("a", "(Lc/b/a/B;)Z", "GetA_Lc_b_a_B_Handler")]
		public unsafe virtual bool A(B p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			bool result = _members.InstanceMethods.InvokeVirtualBooleanMethod("a.(Lc/b/a/B;)Z", this, ptr);
			GC.KeepAlive(p0);
			return result;
		}

		[Register("a", "(Lc/b/a/B;Lc/b/a/B;)Lc/b/a/B;", "")]
		public unsafe static B A(B p0, B p1)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			B result = Java.Lang.Object.GetObject<B>(_members.StaticMethods.InvokeObjectMethod("a.(Lc/b/a/B;Lc/b/a/B;)Lc/b/a/B;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
			return result;
		}

		[Register("a", "(Ljava/lang/String;)Lc/b/a/B;", "")]
		public unsafe static B A(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<B>(_members.StaticMethods.InvokeObjectMethod("a.(Ljava/lang/String;)Lc/b/a/B;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("a", "(Ljava/lang/String;Lc/b/a/B;)Lc/b/a/B;", "")]
		public unsafe static B A(string p0, B p1)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			B result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				result = Java.Lang.Object.GetObject<B>(_members.StaticMethods.InvokeObjectMethod("a.(Ljava/lang/String;Lc/b/a/B;)Lc/b/a/B;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(p1);
			return result;
		}

		private static Delegate GetInvokeBHandler()
		{
			if ((object)cb_b == null)
			{
				cb_b = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, short>(n_InvokeB));
			}
			return cb_b;
		}

		private static short n_InvokeB(IntPtr jnienv, IntPtr native__this)
		{
			B b = Java.Lang.Object.GetObject<B>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return b.InvokeB();
		}

		[Register("b", "()S", "GetInvokeBHandler")]
		public unsafe virtual short InvokeB()
		{
			return _members.InstanceMethods.InvokeVirtualInt16Method("b.()S", this, null);
		}

		[Register("b", "(Ljava/lang/String;)Lc/b/a/B;", "")]
		public unsafe static B InvokeB(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<B>(_members.StaticMethods.InvokeObjectMethod("b.(Ljava/lang/String;)Lc/b/a/B;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetCHandler()
		{
			if ((object)cb_c == null)
			{
				cb_c = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_C));
			}
			return cb_c;
		}

		private static IntPtr n_C(IntPtr jnienv, IntPtr native__this)
		{
			B b = Java.Lang.Object.GetObject<B>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(b.C());
		}

		[Register("c", "()[B", "GetCHandler")]
		public unsafe virtual byte[] C()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("c.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}

		private static Delegate GetCompareTo_Ljava_lang_Object_Handler()
		{
			if ((object)cb_compareTo_Ljava_lang_Object_ == null)
			{
				cb_compareTo_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, int>(n_CompareTo_Ljava_lang_Object_));
			}
			return cb_compareTo_Ljava_lang_Object_;
		}

		private static int n_CompareTo_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			B b = Java.Lang.Object.GetObject<B>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			return b.CompareTo(p);
		}

		[Register("compareTo", "(Ljava/lang/Object;)I", "GetCompareTo_Ljava_lang_Object_Handler")]
		public unsafe virtual int CompareTo(Java.Lang.Object p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			int result = _members.InstanceMethods.InvokeVirtualInt32Method("compareTo.(Ljava/lang/Object;)I", this, ptr);
			GC.KeepAlive(p0);
			return result;
		}
	}
	[Register("c/b/a/D", DoNotGenerateAcw = true)]
	public class D : L
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("c/b/a/D", typeof(D));

		private static Delegate cb_l;

		private static Delegate cb_m;

		private static Delegate cb_n;

		private static Delegate cb_o;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected D(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetLHandler()
		{
			if ((object)cb_l == null)
			{
				cb_l = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_L));
			}
			return cb_l;
		}

		private static int n_L(IntPtr jnienv, IntPtr native__this)
		{
			D d = Java.Lang.Object.GetObject<D>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return d.L();
		}

		[Register("l", "()I", "GetLHandler")]
		public unsafe virtual int L()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("l.()I", this, null);
		}

		private static Delegate GetMHandler()
		{
			if ((object)cb_m == null)
			{
				cb_m = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_M));
			}
			return cb_m;
		}

		private static int n_M(IntPtr jnienv, IntPtr native__this)
		{
			D d = Java.Lang.Object.GetObject<D>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return d.M();
		}

		[Register("m", "()I", "GetMHandler")]
		public unsafe virtual int M()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("m.()I", this, null);
		}

		private static Delegate GetNHandler()
		{
			if ((object)cb_n == null)
			{
				cb_n = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_N));
			}
			return cb_n;
		}

		private static int n_N(IntPtr jnienv, IntPtr native__this)
		{
			D d = Java.Lang.Object.GetObject<D>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return d.N();
		}

		[Register("n", "()I", "GetNHandler")]
		public unsafe virtual int N()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("n.()I", this, null);
		}

		private static Delegate GetOHandler()
		{
			if ((object)cb_o == null)
			{
				cb_o = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_O));
			}
			return cb_o;
		}

		private static int n_O(IntPtr jnienv, IntPtr native__this)
		{
			D d = Java.Lang.Object.GetObject<D>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return d.O();
		}

		[Register("o", "()I", "GetOHandler")]
		public unsafe virtual int O()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("o.()I", this, null);
		}
	}
	[Register("c/b/a/E", DoNotGenerateAcw = true)]
	public sealed class E : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("c/b/a/E", typeof(E));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal E(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("a", "(I)Ljava/lang/String;", "")]
		public unsafe static string A(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("a.(I)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("c/b/a/F", DoNotGenerateAcw = true)]
	public sealed class F : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("c/b/a/F", typeof(F));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal F(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("a", "()V", "")]
		public unsafe static void A()
		{
			_members.StaticMethods.InvokeVoidMethod("a.()V", null);
		}

		[Register("a", "(Ljava/lang/String;)Z", "")]
		public unsafe static bool A(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.StaticMethods.InvokeBooleanMethod("a.(Ljava/lang/String;)Z", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("a", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe static void A(string p0, string p1)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.StaticMethods.InvokeVoidMethod("a.(Ljava/lang/String;Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		[Register("b", "(Ljava/lang/String;)V", "")]
		public unsafe static void B(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("b.(Ljava/lang/String;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("c/b/a/I", DoNotGenerateAcw = true)]
	public class I : L
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("c/b/a/I", typeof(I));

		private static Delegate cb_l;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected I(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetLHandler()
		{
			if ((object)cb_l == null)
			{
				cb_l = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_L));
			}
			return cb_l;
		}

		private static int n_L(IntPtr jnienv, IntPtr native__this)
		{
			I i = Java.Lang.Object.GetObject<I>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return i.L();
		}

		[Register("l", "()I", "GetLHandler")]
		public unsafe virtual int L()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("l.()I", this, null);
		}
	}
	[Register("c/b/a/H", "", "C.B.A.IHInvoker")]
	public interface IH : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("a", "(Ljava/lang/String;Ljava/net/SocketAddress;Ljava/net/SocketAddress;[B)V", "GetA_Ljava_lang_String_Ljava_net_SocketAddress_Ljava_net_SocketAddress_arrayBHandler:C.B.A.IHInvoker, RouteThisAndroidBinding")]
		void A(string p0, SocketAddress p1, SocketAddress p2, byte[] p3);
	}
	[Register("c/b/a/H", DoNotGenerateAcw = true)]
	internal class IHInvoker : Java.Lang.Object, IH, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("c/b/a/H", typeof(IHInvoker));

		private IntPtr class_ref;

		private static Delegate cb_a_Ljava_lang_String_Ljava_net_SocketAddress_Ljava_net_SocketAddress_arrayB;

		private IntPtr id_a_Ljava_lang_String_Ljava_net_SocketAddress_Ljava_net_SocketAddress_arrayB;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IH GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IH>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "c.b.a.H"));
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

		public IHInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetA_Ljava_lang_String_Ljava_net_SocketAddress_Ljava_net_SocketAddress_arrayBHandler()
		{
			if ((object)cb_a_Ljava_lang_String_Ljava_net_SocketAddress_Ljava_net_SocketAddress_arrayB == null)
			{
				cb_a_Ljava_lang_String_Ljava_net_SocketAddress_Ljava_net_SocketAddress_arrayB = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>(n_A_Ljava_lang_String_Ljava_net_SocketAddress_Ljava_net_SocketAddress_arrayB));
			}
			return cb_a_Ljava_lang_String_Ljava_net_SocketAddress_Ljava_net_SocketAddress_arrayB;
		}

		private static void n_A_Ljava_lang_String_Ljava_net_SocketAddress_Ljava_net_SocketAddress_arrayB(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3)
		{
			IH iH = Java.Lang.Object.GetObject<IH>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			SocketAddress p2 = Java.Lang.Object.GetObject<SocketAddress>(native_p1, JniHandleOwnership.DoNotTransfer);
			SocketAddress p3 = Java.Lang.Object.GetObject<SocketAddress>(native_p2, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_p3, JniHandleOwnership.DoNotTransfer, typeof(byte));
			iH.A(p, p2, p3, array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p3);
			}
		}

		public unsafe void A(string p0, SocketAddress p1, SocketAddress p2, byte[] p3)
		{
			if (id_a_Ljava_lang_String_Ljava_net_SocketAddress_Ljava_net_SocketAddress_arrayB == IntPtr.Zero)
			{
				id_a_Ljava_lang_String_Ljava_net_SocketAddress_Ljava_net_SocketAddress_arrayB = JNIEnv.GetMethodID(class_ref, "a", "(Ljava/lang/String;Ljava/net/SocketAddress;Ljava/net/SocketAddress;[B)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewArray(p3);
			JValue* ptr = stackalloc JValue[4];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(p1?.Handle ?? IntPtr.Zero);
			ptr[2] = new JValue(p2?.Handle ?? IntPtr.Zero);
			ptr[3] = new JValue(intPtr2);
			JNIEnv.CallVoidMethod(base.Handle, id_a_Ljava_lang_String_Ljava_net_SocketAddress_Ljava_net_SocketAddress_arrayB, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			if (p3 != null)
			{
				JNIEnv.CopyArray(intPtr2, p3);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}
	}
	[Register("c/b/a/J", DoNotGenerateAcw = true)]
	public class J : Java.Lang.Object, ISerializable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("c/b/a/J", typeof(J));

		private static Delegate cb_getType;

		private static Delegate cb_a_Lc_b_a_L_;

		private static Delegate cb_b;

		private static Delegate cb_c;

		private static Delegate cb_d;

		private static Delegate cb_e;

		private static Delegate cb_f;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual int Type
		{
			[Register("getType", "()I", "GetGetTypeHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualInt32Method("getType.()I", this, null);
			}
		}

		protected J(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe J()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Lc/b/a/J;)V", "")]
		public unsafe J(J p0)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lc/b/a/J;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lc/b/a/J;)V", this, ptr);
				GC.KeepAlive(p0);
			}
		}

		[Register(".ctor", "(Lc/b/a/L;)V", "")]
		public unsafe J(L p0)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lc/b/a/L;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lc/b/a/L;)V", this, ptr);
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetGetTypeHandler()
		{
			if ((object)cb_getType == null)
			{
				cb_getType = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_GetType));
			}
			return cb_getType;
		}

		private static int n_GetType(IntPtr jnienv, IntPtr native__this)
		{
			J j = Java.Lang.Object.GetObject<J>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return j.Type;
		}

		private static Delegate GetA_Lc_b_a_L_Handler()
		{
			if ((object)cb_a_Lc_b_a_L_ == null)
			{
				cb_a_Lc_b_a_L_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_A_Lc_b_a_L_));
			}
			return cb_a_Lc_b_a_L_;
		}

		private static void n_A_Lc_b_a_L_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			J j = Java.Lang.Object.GetObject<J>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			L p = Java.Lang.Object.GetObject<L>(native_p0, JniHandleOwnership.DoNotTransfer);
			j.A(p);
		}

		[Register("a", "(Lc/b/a/L;)V", "GetA_Lc_b_a_L_Handler")]
		public unsafe virtual void A(L p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("a.(Lc/b/a/L;)V", this, ptr);
			GC.KeepAlive(p0);
		}

		private static Delegate GetBHandler()
		{
			if ((object)cb_b == null)
			{
				cb_b = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_B));
			}
			return cb_b;
		}

		private static IntPtr n_B(IntPtr jnienv, IntPtr native__this)
		{
			J j = Java.Lang.Object.GetObject<J>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(j.B());
		}

		[Register("b", "()Lc/b/a/L;", "GetBHandler")]
		public unsafe virtual L B()
		{
			return Java.Lang.Object.GetObject<L>(_members.InstanceMethods.InvokeVirtualObjectMethod("b.()Lc/b/a/L;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetCHandler()
		{
			if ((object)cb_c == null)
			{
				cb_c = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_C));
			}
			return cb_c;
		}

		private static int n_C(IntPtr jnienv, IntPtr native__this)
		{
			J j = Java.Lang.Object.GetObject<J>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return j.C();
		}

		[Register("c", "()I", "GetCHandler")]
		public unsafe virtual int C()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("c.()I", this, null);
		}

		private static Delegate GetDHandler()
		{
			if ((object)cb_d == null)
			{
				cb_d = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_D));
			}
			return cb_d;
		}

		private static IntPtr n_D(IntPtr jnienv, IntPtr native__this)
		{
			J j = Java.Lang.Object.GetObject<J>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(j.D());
		}

		[Register("d", "()Lc/b/a/B;", "GetDHandler")]
		public unsafe virtual B D()
		{
			return Java.Lang.Object.GetObject<B>(_members.InstanceMethods.InvokeVirtualObjectMethod("d.()Lc/b/a/B;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetEHandler()
		{
			if ((object)cb_e == null)
			{
				cb_e = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, long>(n_E));
			}
			return cb_e;
		}

		private static long n_E(IntPtr jnienv, IntPtr native__this)
		{
			J j = Java.Lang.Object.GetObject<J>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return j.E();
		}

		[Register("e", "()J", "GetEHandler")]
		public unsafe virtual long E()
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("e.()J", this, null);
		}

		private static Delegate GetFHandler()
		{
			if ((object)cb_f == null)
			{
				cb_f = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_F));
			}
			return cb_f;
		}

		private static IntPtr n_F(IntPtr jnienv, IntPtr native__this)
		{
			J j = Java.Lang.Object.GetObject<J>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(j.F());
		}

		[Register("f", "()Ljava/util/Iterator;", "GetFHandler")]
		public unsafe virtual IIterator F()
		{
			return Java.Lang.Object.GetObject<IIterator>(_members.InstanceMethods.InvokeVirtualObjectMethod("f.()Ljava/util/Iterator;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("c/b/a/K", DoNotGenerateAcw = true)]
	public sealed class K : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("c/b/a/K", typeof(K));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal K(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("a", "(I)Ljava/lang/String;", "")]
		public unsafe static string A(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("a.(I)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("b", "(I)Ljava/lang/String;", "")]
		public unsafe static string B(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("b.(I)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("c/b/a/L", DoNotGenerateAcw = true)]
	public abstract class L : Java.Lang.Object, ISerializable, IJavaObject, IDisposable, IJavaPeerable, Java.Lang.ICloneable, Java.Lang.IComparable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("c/b/a/L", typeof(L));

		private static Delegate cb_a_Lc_b_a_L_;

		private static Delegate cb_a_I;

		private static Delegate cb_b;

		private static Delegate cb_c;

		private static Delegate cb_compareTo_Ljava_lang_Object_;

		private static Delegate cb_d;

		private static Delegate cb_f;

		private static Delegate cb_g;

		private static Delegate cb_h;

		private static Delegate cb_i;

		private static Delegate cb_j;

		[Register("e")]
		protected long E
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("e.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("e.J", this, value);
			}
		}

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected L(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		protected unsafe L()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("a", "([B)Ljava/lang/String;", "")]
		protected unsafe static string A(byte[] p0)
		{
			IntPtr intPtr = JNIEnv.NewArray(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("a.([B)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (p0 != null)
				{
					JNIEnv.CopyArray(intPtr, p0);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
		}

		[Register("a", "(Lc/b/a/B;II)Lc/b/a/L;", "")]
		public unsafe static L A(B p0, int p1, int p2)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1);
			ptr[2] = new JniArgumentValue(p2);
			return Java.Lang.Object.GetObject<L>(_members.StaticMethods.InvokeObjectMethod("a.(Lc/b/a/B;II)Lc/b/a/L;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("a", "(Lc/b/a/B;IIJ)Lc/b/a/L;", "")]
		public unsafe static L A(B p0, int p1, int p2, long p3)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1);
			ptr[2] = new JniArgumentValue(p2);
			ptr[3] = new JniArgumentValue(p3);
			return Java.Lang.Object.GetObject<L>(_members.StaticMethods.InvokeObjectMethod("a.(Lc/b/a/B;IIJ)Lc/b/a/L;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetA_Lc_b_a_L_Handler()
		{
			if ((object)cb_a_Lc_b_a_L_ == null)
			{
				cb_a_Lc_b_a_L_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, bool>(n_A_Lc_b_a_L_));
			}
			return cb_a_Lc_b_a_L_;
		}

		private static bool n_A_Lc_b_a_L_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			L l = Java.Lang.Object.GetObject<L>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			L p = Java.Lang.Object.GetObject<L>(native_p0, JniHandleOwnership.DoNotTransfer);
			return l.A(p);
		}

		[Register("a", "(Lc/b/a/L;)Z", "GetA_Lc_b_a_L_Handler")]
		public unsafe virtual bool A(L p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("a.(Lc/b/a/L;)Z", this, ptr);
		}

		private static Delegate GetA_IHandler()
		{
			if ((object)cb_a_I == null)
			{
				cb_a_I = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int, IntPtr>(n_A_I));
			}
			return cb_a_I;
		}

		private static IntPtr n_A_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			L l = Java.Lang.Object.GetObject<L>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(l.A(p0));
		}

		[Register("a", "(I)[B", "GetA_IHandler")]
		public unsafe virtual byte[] A(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("a.(I)[B", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}

		private static Delegate GetBHandler()
		{
			if ((object)cb_b == null)
			{
				cb_b = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_B));
			}
			return cb_b;
		}

		private static IntPtr n_B(IntPtr jnienv, IntPtr native__this)
		{
			L l = Java.Lang.Object.GetObject<L>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(l.B());
		}

		[Register("b", "()Lc/b/a/B;", "GetBHandler")]
		public unsafe virtual B B()
		{
			return Java.Lang.Object.GetObject<B>(_members.InstanceMethods.InvokeVirtualObjectMethod("b.()Lc/b/a/B;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetCHandler()
		{
			if ((object)cb_c == null)
			{
				cb_c = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_C));
			}
			return cb_c;
		}

		private static int n_C(IntPtr jnienv, IntPtr native__this)
		{
			L l = Java.Lang.Object.GetObject<L>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return l.C();
		}

		[Register("c", "()I", "GetCHandler")]
		public unsafe virtual int C()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("c.()I", this, null);
		}

		private static Delegate GetCompareTo_Ljava_lang_Object_Handler()
		{
			if ((object)cb_compareTo_Ljava_lang_Object_ == null)
			{
				cb_compareTo_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, int>(n_CompareTo_Ljava_lang_Object_));
			}
			return cb_compareTo_Ljava_lang_Object_;
		}

		private static int n_CompareTo_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			L l = Java.Lang.Object.GetObject<L>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			return l.CompareTo(p);
		}

		[Register("compareTo", "(Ljava/lang/Object;)I", "GetCompareTo_Ljava_lang_Object_Handler")]
		public unsafe virtual int CompareTo(Java.Lang.Object p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualInt32Method("compareTo.(Ljava/lang/Object;)I", this, ptr);
		}

		private static Delegate GetDHandler()
		{
			if ((object)cb_d == null)
			{
				cb_d = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_D));
			}
			return cb_d;
		}

		private static IntPtr n_D(IntPtr jnienv, IntPtr native__this)
		{
			L l = Java.Lang.Object.GetObject<L>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(l.D());
		}

		[Register("d", "()Lc/b/a/B;", "GetDHandler")]
		public unsafe virtual B D()
		{
			return Java.Lang.Object.GetObject<B>(_members.InstanceMethods.InvokeVirtualObjectMethod("d.()Lc/b/a/B;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetFHandler()
		{
			if ((object)cb_f == null)
			{
				cb_f = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_F));
			}
			return cb_f;
		}

		private static int n_F(IntPtr jnienv, IntPtr native__this)
		{
			L l = Java.Lang.Object.GetObject<L>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return l.F();
		}

		[Register("f", "()I", "GetFHandler")]
		public unsafe virtual int F()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("f.()I", this, null);
		}

		private static Delegate GetGHandler()
		{
			if ((object)cb_g == null)
			{
				cb_g = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, long>(n_G));
			}
			return cb_g;
		}

		private static long n_G(IntPtr jnienv, IntPtr native__this)
		{
			L l = Java.Lang.Object.GetObject<L>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return l.G();
		}

		[Register("g", "()J", "GetGHandler")]
		public unsafe virtual long G()
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("g.()J", this, null);
		}

		private static Delegate GetHHandler()
		{
			if ((object)cb_h == null)
			{
				cb_h = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_H));
			}
			return cb_h;
		}

		private static int n_H(IntPtr jnienv, IntPtr native__this)
		{
			L l = Java.Lang.Object.GetObject<L>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return l.H();
		}

		[Register("h", "()I", "GetHHandler")]
		public unsafe virtual int H()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("h.()I", this, null);
		}

		private static Delegate GetIHandler()
		{
			if ((object)cb_i == null)
			{
				cb_i = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_I));
			}
			return cb_i;
		}

		private static IntPtr n_I(IntPtr jnienv, IntPtr native__this)
		{
			L l = Java.Lang.Object.GetObject<L>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(l.I());
		}

		[Register("i", "()Ljava/lang/String;", "GetIHandler")]
		public unsafe virtual string I()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("i.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetJHandler()
		{
			if ((object)cb_j == null)
			{
				cb_j = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_J));
			}
			return cb_j;
		}

		private static IntPtr n_J(IntPtr jnienv, IntPtr native__this)
		{
			L l = Java.Lang.Object.GetObject<L>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(l.J());
		}

		[Register("j", "()[B", "GetJHandler")]
		public unsafe virtual byte[] J()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("j.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}
	}
	[Register("c/b/a/L", DoNotGenerateAcw = true)]
	internal class LInvoker : L
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("c/b/a/L", typeof(LInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public LInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("c/b/a/M", DoNotGenerateAcw = true)]
	public class M : IllegalArgumentException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("c/b/a/M", typeof(M));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected M(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lc/b/a/B;)V", "")]
		public unsafe M(B p0)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lc/b/a/B;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lc/b/a/B;)V", this, ptr);
			}
		}
	}
	[Register("c/b/a/P", DoNotGenerateAcw = true)]
	public class P : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("c/b/a/P", typeof(P));

		private static Delegate cb_a;

		private static Delegate cb_b;

		private static Delegate cb_b_Landroid_content_Context_;

		private static Delegate cb_c;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected P(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe P(Context p0)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetAHandler()
		{
			if ((object)cb_a == null)
			{
				cb_a = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_A));
			}
			return cb_a;
		}

		private static IntPtr n_A(IntPtr jnienv, IntPtr native__this)
		{
			P p = Java.Lang.Object.GetObject<P>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(p.A());
		}

		[Register("a", "()[Lc/b/a/B;", "GetAHandler")]
		public unsafe virtual B[] A()
		{
			return (B[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("a.()[Lc/b/a/B;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(B));
		}

		[Register("a", "(Landroid/content/Context;)Lc/b/a/P;", "")]
		public unsafe static P A(Context p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			P result = Java.Lang.Object.GetObject<P>(_members.StaticMethods.InvokeObjectMethod("a.(Landroid/content/Context;)Lc/b/a/P;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(p0);
			return result;
		}

		private static Delegate GetBHandler()
		{
			if ((object)cb_b == null)
			{
				cb_b = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_B));
			}
			return cb_b;
		}

		private static IntPtr n_B(IntPtr jnienv, IntPtr native__this)
		{
			P p = Java.Lang.Object.GetObject<P>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(p.B());
		}

		[Register("b", "()Ljava/lang/String;", "GetBHandler")]
		public unsafe virtual string B()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("b.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetB_Landroid_content_Context_Handler()
		{
			if ((object)cb_b_Landroid_content_Context_ == null)
			{
				cb_b_Landroid_content_Context_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_B_Landroid_content_Context_));
			}
			return cb_b_Landroid_content_Context_;
		}

		private static void n_B_Landroid_content_Context_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			P p = Java.Lang.Object.GetObject<P>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context p2 = Java.Lang.Object.GetObject<Context>(native_p0, JniHandleOwnership.DoNotTransfer);
			p.B(p2);
		}

		[Register("b", "(Landroid/content/Context;)V", "GetB_Landroid_content_Context_Handler")]
		public unsafe virtual void B(Context p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("b.(Landroid/content/Context;)V", this, ptr);
			GC.KeepAlive(p0);
		}

		private static Delegate GetCHandler()
		{
			if ((object)cb_c == null)
			{
				cb_c = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_C));
			}
			return cb_c;
		}

		private static IntPtr n_C(IntPtr jnienv, IntPtr native__this)
		{
			P p = Java.Lang.Object.GetObject<P>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(p.C());
		}

		[Register("c", "()[Ljava/lang/String;", "GetCHandler")]
		public unsafe virtual string[] C()
		{
			return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("c.()[Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
		}
	}
	[Register("c/b/a/T", DoNotGenerateAcw = true)]
	public class T : L
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("c/b/a/T", typeof(T));

		private static Delegate cb_l;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected T(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetLHandler()
		{
			if ((object)cb_l == null)
			{
				cb_l = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, int>(n_L));
			}
			return cb_l;
		}

		private static int n_L(IntPtr jnienv, IntPtr native__this)
		{
			T t = Java.Lang.Object.GetObject<T>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return t.L();
		}

		[Register("l", "()I", "GetLHandler")]
		public unsafe virtual int L()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("l.()I", this, null);
		}
	}
	[Register("c/b/a/U", DoNotGenerateAcw = true)]
	public class U : L
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("c/b/a/U", typeof(U));

		private static Delegate cb_l;

		private static Delegate cb_m;

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected U(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lc/b/a/B;IJLc/b/a/B;Lc/b/a/B;JJJJJ)V", "")]
		public unsafe U(B p0, int p1, long p2, B p3, B p4, long p5, long p6, long p7, long p8, long p9)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[10];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1);
				ptr[2] = new JniArgumentValue(p2);
				ptr[3] = new JniArgumentValue(p3?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(p4?.Handle ?? IntPtr.Zero);
				ptr[5] = new JniArgumentValue(p5);
				ptr[6] = new JniArgumentValue(p6);
				ptr[7] = new JniArgumentValue(p7);
				ptr[8] = new JniArgumentValue(p8);
				ptr[9] = new JniArgumentValue(p9);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lc/b/a/B;IJLc/b/a/B;Lc/b/a/B;JJJJJ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lc/b/a/B;IJLc/b/a/B;Lc/b/a/B;JJJJJ)V", this, ptr);
				GC.KeepAlive(p0);
				GC.KeepAlive(p3);
				GC.KeepAlive(p4);
			}
		}

		private static Delegate GetLHandler()
		{
			if ((object)cb_l == null)
			{
				cb_l = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, long>(n_L));
			}
			return cb_l;
		}

		private static long n_L(IntPtr jnienv, IntPtr native__this)
		{
			U u = Java.Lang.Object.GetObject<U>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return u.L();
		}

		[Register("l", "()J", "GetLHandler")]
		public unsafe virtual long L()
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("l.()J", this, null);
		}

		private static Delegate GetMHandler()
		{
			if ((object)cb_m == null)
			{
				cb_m = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, long>(n_M));
			}
			return cb_m;
		}

		private static long n_M(IntPtr jnienv, IntPtr native__this)
		{
			U u = Java.Lang.Object.GetObject<U>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return u.M();
		}

		[Register("m", "()J", "GetMHandler")]
		public unsafe virtual long M()
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("m.()J", this, null);
		}
	}
	[Register("c/b/a/V", DoNotGenerateAcw = true)]
	public class V : L
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("c/b/a/V", typeof(V));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected V(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("c/b/a/W", DoNotGenerateAcw = true)]
	public sealed class W : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("c/b/a/W", typeof(W));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal W(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("a", "(I)Ljava/lang/String;", "")]
		public unsafe static string A(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("a.(I)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("b", "(I)Ljava/lang/String;", "")]
		public unsafe static string B(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("b.(I)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("c", "(I)Ljava/lang/String;", "")]
		public unsafe static string C(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("c.(I)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("c/b/a/X", DoNotGenerateAcw = true)]
	public sealed class X : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("c/b/a/X", typeof(X));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal X(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("a", "(JJ)I", "")]
		public unsafe static int A(long p0, long p1)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1);
			return _members.StaticMethods.InvokeInt32Method("a.(JJ)I", ptr);
		}
	}
	[Register("c/b/a/Y", DoNotGenerateAcw = true)]
	public class Y : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("c/b/a/Y", typeof(Y));

		private static Delegate cb_a;

		private static Delegate cb_d;

		private static Delegate cb_e;

		private static Delegate cb_f;

		private static Delegate cb_g;

		private static Delegate cb_h;

		private static Delegate cb_i;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected Y(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetAHandler()
		{
			if ((object)cb_a == null)
			{
				cb_a = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_A));
			}
			return cb_a;
		}

		private static IntPtr n_A(IntPtr jnienv, IntPtr native__this)
		{
			Y y = Java.Lang.Object.GetObject<Y>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewArray(y.A());
		}

		[Register("a", "()[Lc/b/a/J;", "GetAHandler")]
		public unsafe virtual J[] A()
		{
			return (J[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("a.()[Lc/b/a/J;", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(J));
		}

		private static Delegate GetDHandler()
		{
			if ((object)cb_d == null)
			{
				cb_d = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_D));
			}
			return cb_d;
		}

		private static bool n_D(IntPtr jnienv, IntPtr native__this)
		{
			Y y = Java.Lang.Object.GetObject<Y>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return y.D();
		}

		[Register("d", "()Z", "GetDHandler")]
		public unsafe virtual bool D()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("d.()Z", this, null);
		}

		private static Delegate GetEHandler()
		{
			if ((object)cb_e == null)
			{
				cb_e = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_E));
			}
			return cb_e;
		}

		private static bool n_E(IntPtr jnienv, IntPtr native__this)
		{
			Y y = Java.Lang.Object.GetObject<Y>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return y.E();
		}

		[Register("e", "()Z", "GetEHandler")]
		public unsafe virtual bool E()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("e.()Z", this, null);
		}

		private static Delegate GetFHandler()
		{
			if ((object)cb_f == null)
			{
				cb_f = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_F));
			}
			return cb_f;
		}

		private static bool n_F(IntPtr jnienv, IntPtr native__this)
		{
			Y y = Java.Lang.Object.GetObject<Y>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return y.F();
		}

		[Register("f", "()Z", "GetFHandler")]
		public unsafe virtual bool F()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("f.()Z", this, null);
		}

		private static Delegate GetGHandler()
		{
			if ((object)cb_g == null)
			{
				cb_g = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_G));
			}
			return cb_g;
		}

		private static bool n_G(IntPtr jnienv, IntPtr native__this)
		{
			Y y = Java.Lang.Object.GetObject<Y>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return y.G();
		}

		[Register("g", "()Z", "GetGHandler")]
		public unsafe virtual bool G()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("g.()Z", this, null);
		}

		private static Delegate GetHHandler()
		{
			if ((object)cb_h == null)
			{
				cb_h = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_H));
			}
			return cb_h;
		}

		private static bool n_H(IntPtr jnienv, IntPtr native__this)
		{
			Y y = Java.Lang.Object.GetObject<Y>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return y.H();
		}

		[Register("h", "()Z", "GetHHandler")]
		public unsafe virtual bool H()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("h.()Z", this, null);
		}

		private static Delegate GetIHandler()
		{
			if ((object)cb_i == null)
			{
				cb_i = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_I));
			}
			return cb_i;
		}

		private static bool n_I(IntPtr jnienv, IntPtr native__this)
		{
			Y y = Java.Lang.Object.GetObject<Y>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return y.I();
		}

		[Register("i", "()Z", "GetIHandler")]
		public unsafe virtual bool I()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("i.()Z", this, null);
		}
	}
	[Register("c/b/a/Z", DoNotGenerateAcw = true)]
	public class Z : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("c/b/a/Z", typeof(Z));

		private static Delegate cb_a_I;

		private static Delegate cb_a_II;

		private static Delegate cb_a_Ljava_net_InetAddress_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected Z(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Landroid/content/Context;)V", "")]
		public unsafe Z(string p0, Context p1)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Landroid/content/Context;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p1);
			}
		}

		private static Delegate GetA_IHandler()
		{
			if ((object)cb_a_I == null)
			{
				cb_a_I = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int>(n_A_I));
			}
			return cb_a_I;
		}

		private static void n_A_I(IntPtr jnienv, IntPtr native__this, int p0)
		{
			Z z = Java.Lang.Object.GetObject<Z>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			z.A(p0);
		}

		[Register("a", "(I)V", "GetA_IHandler")]
		public unsafe virtual void A(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			_members.InstanceMethods.InvokeVirtualVoidMethod("a.(I)V", this, ptr);
		}

		private static Delegate GetA_IIHandler()
		{
			if ((object)cb_a_II == null)
			{
				cb_a_II = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int, int>(n_A_II));
			}
			return cb_a_II;
		}

		private static void n_A_II(IntPtr jnienv, IntPtr native__this, int p0, int p1)
		{
			Z z = Java.Lang.Object.GetObject<Z>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			z.A(p0, p1);
		}

		[Register("a", "(II)V", "GetA_IIHandler")]
		public unsafe virtual void A(int p0, int p1)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1);
			_members.InstanceMethods.InvokeVirtualVoidMethod("a.(II)V", this, ptr);
		}

		private static Delegate GetA_Ljava_net_InetAddress_Handler()
		{
			if ((object)cb_a_Ljava_net_InetAddress_ == null)
			{
				cb_a_Ljava_net_InetAddress_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_A_Ljava_net_InetAddress_));
			}
			return cb_a_Ljava_net_InetAddress_;
		}

		private static void n_A_Ljava_net_InetAddress_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			Z z = Java.Lang.Object.GetObject<Z>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			InetAddress p = Java.Lang.Object.GetObject<InetAddress>(native_p0, JniHandleOwnership.DoNotTransfer);
			z.A(p);
		}

		[Register("a", "(Ljava/net/InetAddress;)V", "GetA_Ljava_net_InetAddress_Handler")]
		public unsafe virtual void A(InetAddress p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("a.(Ljava/net/InetAddress;)V", this, ptr);
			GC.KeepAlive(p0);
		}
	}
}
namespace Com.Routethis.Androidsdk
{
	[Register("com/routethis/androidsdk/D", DoNotGenerateAcw = true)]
	public abstract class D : BroadcastReceiver
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/D", typeof(D));

		private static Delegate cb_a_Landroid_content_Context_Landroid_content_Intent_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected D(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe D()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetA_Landroid_content_Context_Landroid_content_Intent_Handler()
		{
			if ((object)cb_a_Landroid_content_Context_Landroid_content_Intent_ == null)
			{
				cb_a_Landroid_content_Context_Landroid_content_Intent_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr>(n_A_Landroid_content_Context_Landroid_content_Intent_));
			}
			return cb_a_Landroid_content_Context_Landroid_content_Intent_;
		}

		private static void n_A_Landroid_content_Context_Landroid_content_Intent_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			D d = Java.Lang.Object.GetObject<D>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context p = Java.Lang.Object.GetObject<Context>(native_p0, JniHandleOwnership.DoNotTransfer);
			Intent p2 = Java.Lang.Object.GetObject<Intent>(native_p1, JniHandleOwnership.DoNotTransfer);
			d.A(p, p2);
		}

		[Register("a", "(Landroid/content/Context;Landroid/content/Intent;)V", "GetA_Landroid_content_Context_Landroid_content_Intent_Handler")]
		public abstract void A(Context p0, Intent p1);

		[Register("onReceive", "(Landroid/content/Context;Landroid/content/Intent;)V", "")]
		public unsafe sealed override void OnReceive(Context p0, Intent p1)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("onReceive.(Landroid/content/Context;Landroid/content/Intent;)V", this, ptr);
		}
	}
	[Register("com/routethis/androidsdk/D", DoNotGenerateAcw = true)]
	internal class DInvoker : D
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/D", typeof(DInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public DInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("a", "(Landroid/content/Context;Landroid/content/Intent;)V", "GetA_Landroid_content_Context_Landroid_content_Intent_Handler")]
		public unsafe override void A(Context p0, Intent p1)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeAbstractVoidMethod("a.(Landroid/content/Context;Landroid/content/Intent;)V", this, ptr);
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}
	}
	[Register("com/routethis/androidsdk/H", DoNotGenerateAcw = true)]
	public abstract class H : Java.Lang.Object, IRunnable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/H", typeof(H));

		private static Delegate cb_a;

		private static Delegate cb_run;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected H(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe H()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetAHandler()
		{
			if ((object)cb_a == null)
			{
				cb_a = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_A));
			}
			return cb_a;
		}

		private static void n_A(IntPtr jnienv, IntPtr native__this)
		{
			H h = Java.Lang.Object.GetObject<H>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			h.A();
		}

		[Register("a", "()V", "GetAHandler")]
		public abstract void A();

		private static Delegate GetRunHandler()
		{
			if ((object)cb_run == null)
			{
				cb_run = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_Run));
			}
			return cb_run;
		}

		private static void n_Run(IntPtr jnienv, IntPtr native__this)
		{
			H h = Java.Lang.Object.GetObject<H>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			h.Run();
		}

		[Register("run", "()V", "GetRunHandler")]
		public unsafe virtual void Run()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("run.()V", this, null);
		}
	}
	[Register("com/routethis/androidsdk/H", DoNotGenerateAcw = true)]
	internal class HInvoker : H
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/H", typeof(HInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public HInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("a", "()V", "GetAHandler")]
		public unsafe override void A()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("a.()V", this, null);
		}
	}
	[Register("com/routethis/androidsdk/I", DoNotGenerateAcw = true)]
	public class I : Thread
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/I", typeof(I));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected I(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe I()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe I(string p0)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
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
	}
	[Register("com/routethis/androidsdk/F", "", "Com.Routethis.Androidsdk.IFInvoker")]
	public interface IF : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("a", "()V", "GetAHandler:Com.Routethis.Androidsdk.IFInvoker, RouteThisAndroidBinding")]
		void A();

		[Register("a", "(Ljava/lang/String;)V", "GetA_Ljava_lang_String_Handler:Com.Routethis.Androidsdk.IFInvoker, RouteThisAndroidBinding")]
		void A(string p0);

		[Register("a", "(Ljava/lang/String;Ljava/lang/String;)V", "GetA_Ljava_lang_String_Ljava_lang_String_Handler:Com.Routethis.Androidsdk.IFInvoker, RouteThisAndroidBinding")]
		void A(string p0, string p1);

		[Register("b", "()V", "GetBHandler:Com.Routethis.Androidsdk.IFInvoker, RouteThisAndroidBinding")]
		void B();

		[Register("c", "()V", "GetCHandler:Com.Routethis.Androidsdk.IFInvoker, RouteThisAndroidBinding")]
		void C();

		[Register("d", "()V", "GetDHandler:Com.Routethis.Androidsdk.IFInvoker, RouteThisAndroidBinding")]
		void D();

		[Register("onConnected", "()V", "GetOnConnectedHandler:Com.Routethis.Androidsdk.IFInvoker, RouteThisAndroidBinding")]
		void OnConnected();

		[Register("onDisconnected", "()V", "GetOnDisconnectedHandler:Com.Routethis.Androidsdk.IFInvoker, RouteThisAndroidBinding")]
		void OnDisconnected();
	}
	[Register("com/routethis/androidsdk/F", DoNotGenerateAcw = true)]
	internal class IFInvoker : Java.Lang.Object, IF, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/F", typeof(IFInvoker));

		private IntPtr class_ref;

		private static Delegate cb_a;

		private IntPtr id_a;

		private static Delegate cb_a_Ljava_lang_String_;

		private IntPtr id_a_Ljava_lang_String_;

		private static Delegate cb_a_Ljava_lang_String_Ljava_lang_String_;

		private IntPtr id_a_Ljava_lang_String_Ljava_lang_String_;

		private static Delegate cb_b;

		private IntPtr id_b;

		private static Delegate cb_c;

		private IntPtr id_c;

		private static Delegate cb_d;

		private IntPtr id_d;

		private static Delegate cb_onConnected;

		private IntPtr id_onConnected;

		private static Delegate cb_onDisconnected;

		private IntPtr id_onDisconnected;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IF GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IF>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.routethis.androidsdk.F"));
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

		public IFInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetAHandler()
		{
			if ((object)cb_a == null)
			{
				cb_a = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_A));
			}
			return cb_a;
		}

		private static void n_A(IntPtr jnienv, IntPtr native__this)
		{
			IF iF = Java.Lang.Object.GetObject<IF>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iF.A();
		}

		public void A()
		{
			if (id_a == IntPtr.Zero)
			{
				id_a = JNIEnv.GetMethodID(class_ref, "a", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_a);
		}

		private static Delegate GetA_Ljava_lang_String_Handler()
		{
			if ((object)cb_a_Ljava_lang_String_ == null)
			{
				cb_a_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_A_Ljava_lang_String_));
			}
			return cb_a_Ljava_lang_String_;
		}

		private static void n_A_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IF iF = Java.Lang.Object.GetObject<IF>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			iF.A(p);
		}

		public unsafe void A(string p0)
		{
			if (id_a_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_a_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "a", "(Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_a_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetA_Ljava_lang_String_Ljava_lang_String_Handler()
		{
			if ((object)cb_a_Ljava_lang_String_Ljava_lang_String_ == null)
			{
				cb_a_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr>(n_A_Ljava_lang_String_Ljava_lang_String_));
			}
			return cb_a_Ljava_lang_String_Ljava_lang_String_;
		}

		private static void n_A_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			IF iF = Java.Lang.Object.GetObject<IF>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			iF.A(p, p2);
		}

		public unsafe void A(string p0, string p1)
		{
			if (id_a_Ljava_lang_String_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_a_Ljava_lang_String_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "a", "(Ljava/lang/String;Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			JNIEnv.CallVoidMethod(base.Handle, id_a_Ljava_lang_String_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
		}

		private static Delegate GetBHandler()
		{
			if ((object)cb_b == null)
			{
				cb_b = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_B));
			}
			return cb_b;
		}

		private static void n_B(IntPtr jnienv, IntPtr native__this)
		{
			IF iF = Java.Lang.Object.GetObject<IF>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iF.B();
		}

		public void B()
		{
			if (id_b == IntPtr.Zero)
			{
				id_b = JNIEnv.GetMethodID(class_ref, "b", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_b);
		}

		private static Delegate GetCHandler()
		{
			if ((object)cb_c == null)
			{
				cb_c = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_C));
			}
			return cb_c;
		}

		private static void n_C(IntPtr jnienv, IntPtr native__this)
		{
			IF iF = Java.Lang.Object.GetObject<IF>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iF.C();
		}

		public void C()
		{
			if (id_c == IntPtr.Zero)
			{
				id_c = JNIEnv.GetMethodID(class_ref, "c", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_c);
		}

		private static Delegate GetDHandler()
		{
			if ((object)cb_d == null)
			{
				cb_d = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_D));
			}
			return cb_d;
		}

		private static void n_D(IntPtr jnienv, IntPtr native__this)
		{
			IF iF = Java.Lang.Object.GetObject<IF>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iF.D();
		}

		public void D()
		{
			if (id_d == IntPtr.Zero)
			{
				id_d = JNIEnv.GetMethodID(class_ref, "d", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_d);
		}

		private static Delegate GetOnConnectedHandler()
		{
			if ((object)cb_onConnected == null)
			{
				cb_onConnected = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_OnConnected));
			}
			return cb_onConnected;
		}

		private static void n_OnConnected(IntPtr jnienv, IntPtr native__this)
		{
			IF iF = Java.Lang.Object.GetObject<IF>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iF.OnConnected();
		}

		public void OnConnected()
		{
			if (id_onConnected == IntPtr.Zero)
			{
				id_onConnected = JNIEnv.GetMethodID(class_ref, "onConnected", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onConnected);
		}

		private static Delegate GetOnDisconnectedHandler()
		{
			if ((object)cb_onDisconnected == null)
			{
				cb_onDisconnected = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_OnDisconnected));
			}
			return cb_onDisconnected;
		}

		private static void n_OnDisconnected(IntPtr jnienv, IntPtr native__this)
		{
			IF iF = Java.Lang.Object.GetObject<IF>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iF.OnDisconnected();
		}

		public void OnDisconnected()
		{
			if (id_onDisconnected == IntPtr.Zero)
			{
				id_onDisconnected = JNIEnv.GetMethodID(class_ref, "onDisconnected", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onDisconnected);
		}
	}
	[Register("com/routethis/androidsdk/G", "", "Com.Routethis.Androidsdk.IGInvoker")]
	public interface IG : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("a", "()V", "GetAHandler:Com.Routethis.Androidsdk.IGInvoker, RouteThisAndroidBinding")]
		void A();

		[Register("a", "(FF)V", "GetA_FFHandler:Com.Routethis.Androidsdk.IGInvoker, RouteThisAndroidBinding")]
		void A(float p0, float p1);

		[Register("a", "(Ljava/lang/String;)V", "GetA_Ljava_lang_String_Handler:Com.Routethis.Androidsdk.IGInvoker, RouteThisAndroidBinding")]
		void A(string p0);

		[Register("b", "()V", "GetBHandler:Com.Routethis.Androidsdk.IGInvoker, RouteThisAndroidBinding")]
		void B();

		[Register("c", "()V", "GetCHandler:Com.Routethis.Androidsdk.IGInvoker, RouteThisAndroidBinding")]
		void C();

		[Register("d", "()V", "GetDHandler:Com.Routethis.Androidsdk.IGInvoker, RouteThisAndroidBinding")]
		void D();

		[Register("e", "()V", "GetEHandler:Com.Routethis.Androidsdk.IGInvoker, RouteThisAndroidBinding")]
		void E();

		[Register("f", "()V", "GetFHandler:Com.Routethis.Androidsdk.IGInvoker, RouteThisAndroidBinding")]
		void F();

		[Register("g", "()V", "GetGHandler:Com.Routethis.Androidsdk.IGInvoker, RouteThisAndroidBinding")]
		void G();

		[Register("h", "()V", "GetHHandler:Com.Routethis.Androidsdk.IGInvoker, RouteThisAndroidBinding")]
		void H();

		[Register("onConnected", "()V", "GetOnConnectedHandler:Com.Routethis.Androidsdk.IGInvoker, RouteThisAndroidBinding")]
		void OnConnected();

		[Register("onDisconnected", "()V", "GetOnDisconnectedHandler:Com.Routethis.Androidsdk.IGInvoker, RouteThisAndroidBinding")]
		void OnDisconnected();
	}
	[Register("com/routethis/androidsdk/G", DoNotGenerateAcw = true)]
	internal class IGInvoker : Java.Lang.Object, IG, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/G", typeof(IGInvoker));

		private IntPtr class_ref;

		private static Delegate cb_a;

		private IntPtr id_a;

		private static Delegate cb_a_FF;

		private IntPtr id_a_FF;

		private static Delegate cb_a_Ljava_lang_String_;

		private IntPtr id_a_Ljava_lang_String_;

		private static Delegate cb_b;

		private IntPtr id_b;

		private static Delegate cb_c;

		private IntPtr id_c;

		private static Delegate cb_d;

		private IntPtr id_d;

		private static Delegate cb_e;

		private IntPtr id_e;

		private static Delegate cb_f;

		private IntPtr id_f;

		private static Delegate cb_g;

		private IntPtr id_g;

		private static Delegate cb_h;

		private IntPtr id_h;

		private static Delegate cb_onConnected;

		private IntPtr id_onConnected;

		private static Delegate cb_onDisconnected;

		private IntPtr id_onDisconnected;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IG GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IG>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.routethis.androidsdk.G"));
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

		public IGInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetAHandler()
		{
			if ((object)cb_a == null)
			{
				cb_a = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_A));
			}
			return cb_a;
		}

		private static void n_A(IntPtr jnienv, IntPtr native__this)
		{
			IG iG = Java.Lang.Object.GetObject<IG>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iG.A();
		}

		public void A()
		{
			if (id_a == IntPtr.Zero)
			{
				id_a = JNIEnv.GetMethodID(class_ref, "a", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_a);
		}

		private static Delegate GetA_FFHandler()
		{
			if ((object)cb_a_FF == null)
			{
				cb_a_FF = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float, float>(n_A_FF));
			}
			return cb_a_FF;
		}

		private static void n_A_FF(IntPtr jnienv, IntPtr native__this, float p0, float p1)
		{
			IG iG = Java.Lang.Object.GetObject<IG>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iG.A(p0, p1);
		}

		public unsafe void A(float p0, float p1)
		{
			if (id_a_FF == IntPtr.Zero)
			{
				id_a_FF = JNIEnv.GetMethodID(class_ref, "a", "(FF)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0);
			ptr[1] = new JValue(p1);
			JNIEnv.CallVoidMethod(base.Handle, id_a_FF, ptr);
		}

		private static Delegate GetA_Ljava_lang_String_Handler()
		{
			if ((object)cb_a_Ljava_lang_String_ == null)
			{
				cb_a_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_A_Ljava_lang_String_));
			}
			return cb_a_Ljava_lang_String_;
		}

		private static void n_A_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IG iG = Java.Lang.Object.GetObject<IG>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			iG.A(p);
		}

		public unsafe void A(string p0)
		{
			if (id_a_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_a_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "a", "(Ljava/lang/String;)V");
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_a_Ljava_lang_String_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetBHandler()
		{
			if ((object)cb_b == null)
			{
				cb_b = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_B));
			}
			return cb_b;
		}

		private static void n_B(IntPtr jnienv, IntPtr native__this)
		{
			IG iG = Java.Lang.Object.GetObject<IG>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iG.B();
		}

		public void B()
		{
			if (id_b == IntPtr.Zero)
			{
				id_b = JNIEnv.GetMethodID(class_ref, "b", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_b);
		}

		private static Delegate GetCHandler()
		{
			if ((object)cb_c == null)
			{
				cb_c = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_C));
			}
			return cb_c;
		}

		private static void n_C(IntPtr jnienv, IntPtr native__this)
		{
			IG iG = Java.Lang.Object.GetObject<IG>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iG.C();
		}

		public void C()
		{
			if (id_c == IntPtr.Zero)
			{
				id_c = JNIEnv.GetMethodID(class_ref, "c", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_c);
		}

		private static Delegate GetDHandler()
		{
			if ((object)cb_d == null)
			{
				cb_d = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_D));
			}
			return cb_d;
		}

		private static void n_D(IntPtr jnienv, IntPtr native__this)
		{
			IG iG = Java.Lang.Object.GetObject<IG>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iG.D();
		}

		public void D()
		{
			if (id_d == IntPtr.Zero)
			{
				id_d = JNIEnv.GetMethodID(class_ref, "d", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_d);
		}

		private static Delegate GetEHandler()
		{
			if ((object)cb_e == null)
			{
				cb_e = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_E));
			}
			return cb_e;
		}

		private static void n_E(IntPtr jnienv, IntPtr native__this)
		{
			IG iG = Java.Lang.Object.GetObject<IG>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iG.E();
		}

		public void E()
		{
			if (id_e == IntPtr.Zero)
			{
				id_e = JNIEnv.GetMethodID(class_ref, "e", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_e);
		}

		private static Delegate GetFHandler()
		{
			if ((object)cb_f == null)
			{
				cb_f = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_F));
			}
			return cb_f;
		}

		private static void n_F(IntPtr jnienv, IntPtr native__this)
		{
			IG iG = Java.Lang.Object.GetObject<IG>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iG.F();
		}

		public void F()
		{
			if (id_f == IntPtr.Zero)
			{
				id_f = JNIEnv.GetMethodID(class_ref, "f", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_f);
		}

		private static Delegate GetGHandler()
		{
			if ((object)cb_g == null)
			{
				cb_g = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_G));
			}
			return cb_g;
		}

		private static void n_G(IntPtr jnienv, IntPtr native__this)
		{
			IG iG = Java.Lang.Object.GetObject<IG>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iG.G();
		}

		public void G()
		{
			if (id_g == IntPtr.Zero)
			{
				id_g = JNIEnv.GetMethodID(class_ref, "g", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_g);
		}

		private static Delegate GetHHandler()
		{
			if ((object)cb_h == null)
			{
				cb_h = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_H));
			}
			return cb_h;
		}

		private static void n_H(IntPtr jnienv, IntPtr native__this)
		{
			IG iG = Java.Lang.Object.GetObject<IG>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iG.H();
		}

		public void H()
		{
			if (id_h == IntPtr.Zero)
			{
				id_h = JNIEnv.GetMethodID(class_ref, "h", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_h);
		}

		private static Delegate GetOnConnectedHandler()
		{
			if ((object)cb_onConnected == null)
			{
				cb_onConnected = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_OnConnected));
			}
			return cb_onConnected;
		}

		private static void n_OnConnected(IntPtr jnienv, IntPtr native__this)
		{
			IG iG = Java.Lang.Object.GetObject<IG>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iG.OnConnected();
		}

		public void OnConnected()
		{
			if (id_onConnected == IntPtr.Zero)
			{
				id_onConnected = JNIEnv.GetMethodID(class_ref, "onConnected", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onConnected);
		}

		private static Delegate GetOnDisconnectedHandler()
		{
			if ((object)cb_onDisconnected == null)
			{
				cb_onDisconnected = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_OnDisconnected));
			}
			return cb_onDisconnected;
		}

		private static void n_OnDisconnected(IntPtr jnienv, IntPtr native__this)
		{
			IG iG = Java.Lang.Object.GetObject<IG>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iG.OnDisconnected();
		}

		public void OnDisconnected()
		{
			if (id_onDisconnected == IntPtr.Zero)
			{
				id_onDisconnected = JNIEnv.GetMethodID(class_ref, "onDisconnected", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onDisconnected);
		}
	}
	[Register("com/routethis/androidsdk/RouteThisAnalysisHandler", "", "Com.Routethis.Androidsdk.IRouteThisAnalysisHandlerInvoker")]
	public interface IRouteThisAnalysisHandler : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onAnalysisComplete", "()V", "GetOnAnalysisCompleteHandler:Com.Routethis.Androidsdk.IRouteThisAnalysisHandlerInvoker, RouteThisAndroidBinding")]
		void OnAnalysisComplete();

		[Register("onAnalysisProgress", "(FI)V", "GetOnAnalysisProgress_FIHandler:Com.Routethis.Androidsdk.IRouteThisAnalysisHandlerInvoker, RouteThisAndroidBinding")]
		void OnAnalysisProgress(float p0, int p1);

		[Register("onAnalysisStarted", "()V", "GetOnAnalysisStartedHandler:Com.Routethis.Androidsdk.IRouteThisAnalysisHandlerInvoker, RouteThisAndroidBinding")]
		void OnAnalysisStarted();

		[Register("onDataPersisted", "()V", "GetOnDataPersistedHandler:Com.Routethis.Androidsdk.IRouteThisAnalysisHandlerInvoker, RouteThisAndroidBinding")]
		void OnDataPersisted();

		[Register("onErrorAnalysisAlreadyRunning", "()V", "GetOnErrorAnalysisAlreadyRunningHandler:Com.Routethis.Androidsdk.IRouteThisAnalysisHandlerInvoker, RouteThisAndroidBinding")]
		void OnErrorAnalysisAlreadyRunning();

		[Register("onErrorInvalidApiKey", "()V", "GetOnErrorInvalidApiKeyHandler:Com.Routethis.Androidsdk.IRouteThisAnalysisHandlerInvoker, RouteThisAndroidBinding")]
		void OnErrorInvalidApiKey();

		[Register("onErrorNoInternetConnection", "()V", "GetOnErrorNoInternetConnectionHandler:Com.Routethis.Androidsdk.IRouteThisAnalysisHandlerInvoker, RouteThisAndroidBinding")]
		void OnErrorNoInternetConnection();

		[Register("onErrorNoWifi", "()V", "GetOnErrorNoWifiHandler:Com.Routethis.Androidsdk.IRouteThisAnalysisHandlerInvoker, RouteThisAndroidBinding")]
		void OnErrorNoWifi();

		[Register("onLocationServicesDisabled", "()Z", "GetOnLocationServicesDisabledHandler:Com.Routethis.Androidsdk.IRouteThisAnalysisHandlerInvoker, RouteThisAndroidBinding")]
		bool OnLocationServicesDisabled();

		[Register("onMissingLocationPermission", "()Z", "GetOnMissingLocationPermissionHandler:Com.Routethis.Androidsdk.IRouteThisAnalysisHandlerInvoker, RouteThisAndroidBinding")]
		bool OnMissingLocationPermission();

		[Register("onWarningBatterySaverOn", "()V", "GetOnWarningBatterySaverOnHandler:Com.Routethis.Androidsdk.IRouteThisAnalysisHandlerInvoker, RouteThisAndroidBinding")]
		void OnWarningBatterySaverOn();
	}
	[Register("com/routethis/androidsdk/RouteThisAnalysisHandler", DoNotGenerateAcw = true)]
	internal class IRouteThisAnalysisHandlerInvoker : Java.Lang.Object, IRouteThisAnalysisHandler, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/RouteThisAnalysisHandler", typeof(IRouteThisAnalysisHandlerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onAnalysisComplete;

		private IntPtr id_onAnalysisComplete;

		private static Delegate cb_onAnalysisProgress_FI;

		private IntPtr id_onAnalysisProgress_FI;

		private static Delegate cb_onAnalysisStarted;

		private IntPtr id_onAnalysisStarted;

		private static Delegate cb_onDataPersisted;

		private IntPtr id_onDataPersisted;

		private static Delegate cb_onErrorAnalysisAlreadyRunning;

		private IntPtr id_onErrorAnalysisAlreadyRunning;

		private static Delegate cb_onErrorInvalidApiKey;

		private IntPtr id_onErrorInvalidApiKey;

		private static Delegate cb_onErrorNoInternetConnection;

		private IntPtr id_onErrorNoInternetConnection;

		private static Delegate cb_onErrorNoWifi;

		private IntPtr id_onErrorNoWifi;

		private static Delegate cb_onLocationServicesDisabled;

		private IntPtr id_onLocationServicesDisabled;

		private static Delegate cb_onMissingLocationPermission;

		private IntPtr id_onMissingLocationPermission;

		private static Delegate cb_onWarningBatterySaverOn;

		private IntPtr id_onWarningBatterySaverOn;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IRouteThisAnalysisHandler GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IRouteThisAnalysisHandler>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.routethis.androidsdk.RouteThisAnalysisHandler"));
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

		public IRouteThisAnalysisHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnAnalysisCompleteHandler()
		{
			if ((object)cb_onAnalysisComplete == null)
			{
				cb_onAnalysisComplete = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_OnAnalysisComplete));
			}
			return cb_onAnalysisComplete;
		}

		private static void n_OnAnalysisComplete(IntPtr jnienv, IntPtr native__this)
		{
			IRouteThisAnalysisHandler routeThisAnalysisHandler = Java.Lang.Object.GetObject<IRouteThisAnalysisHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisAnalysisHandler.OnAnalysisComplete();
		}

		public void OnAnalysisComplete()
		{
			if (id_onAnalysisComplete == IntPtr.Zero)
			{
				id_onAnalysisComplete = JNIEnv.GetMethodID(class_ref, "onAnalysisComplete", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onAnalysisComplete);
		}

		private static Delegate GetOnAnalysisProgress_FIHandler()
		{
			if ((object)cb_onAnalysisProgress_FI == null)
			{
				cb_onAnalysisProgress_FI = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, float, int>(n_OnAnalysisProgress_FI));
			}
			return cb_onAnalysisProgress_FI;
		}

		private static void n_OnAnalysisProgress_FI(IntPtr jnienv, IntPtr native__this, float p0, int p1)
		{
			IRouteThisAnalysisHandler routeThisAnalysisHandler = Java.Lang.Object.GetObject<IRouteThisAnalysisHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisAnalysisHandler.OnAnalysisProgress(p0, p1);
		}

		public unsafe void OnAnalysisProgress(float p0, int p1)
		{
			if (id_onAnalysisProgress_FI == IntPtr.Zero)
			{
				id_onAnalysisProgress_FI = JNIEnv.GetMethodID(class_ref, "onAnalysisProgress", "(FI)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0);
			ptr[1] = new JValue(p1);
			JNIEnv.CallVoidMethod(base.Handle, id_onAnalysisProgress_FI, ptr);
		}

		private static Delegate GetOnAnalysisStartedHandler()
		{
			if ((object)cb_onAnalysisStarted == null)
			{
				cb_onAnalysisStarted = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_OnAnalysisStarted));
			}
			return cb_onAnalysisStarted;
		}

		private static void n_OnAnalysisStarted(IntPtr jnienv, IntPtr native__this)
		{
			IRouteThisAnalysisHandler routeThisAnalysisHandler = Java.Lang.Object.GetObject<IRouteThisAnalysisHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisAnalysisHandler.OnAnalysisStarted();
		}

		public void OnAnalysisStarted()
		{
			if (id_onAnalysisStarted == IntPtr.Zero)
			{
				id_onAnalysisStarted = JNIEnv.GetMethodID(class_ref, "onAnalysisStarted", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onAnalysisStarted);
		}

		private static Delegate GetOnDataPersistedHandler()
		{
			if ((object)cb_onDataPersisted == null)
			{
				cb_onDataPersisted = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_OnDataPersisted));
			}
			return cb_onDataPersisted;
		}

		private static void n_OnDataPersisted(IntPtr jnienv, IntPtr native__this)
		{
			IRouteThisAnalysisHandler routeThisAnalysisHandler = Java.Lang.Object.GetObject<IRouteThisAnalysisHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisAnalysisHandler.OnDataPersisted();
		}

		public void OnDataPersisted()
		{
			if (id_onDataPersisted == IntPtr.Zero)
			{
				id_onDataPersisted = JNIEnv.GetMethodID(class_ref, "onDataPersisted", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onDataPersisted);
		}

		private static Delegate GetOnErrorAnalysisAlreadyRunningHandler()
		{
			if ((object)cb_onErrorAnalysisAlreadyRunning == null)
			{
				cb_onErrorAnalysisAlreadyRunning = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_OnErrorAnalysisAlreadyRunning));
			}
			return cb_onErrorAnalysisAlreadyRunning;
		}

		private static void n_OnErrorAnalysisAlreadyRunning(IntPtr jnienv, IntPtr native__this)
		{
			IRouteThisAnalysisHandler routeThisAnalysisHandler = Java.Lang.Object.GetObject<IRouteThisAnalysisHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisAnalysisHandler.OnErrorAnalysisAlreadyRunning();
		}

		public void OnErrorAnalysisAlreadyRunning()
		{
			if (id_onErrorAnalysisAlreadyRunning == IntPtr.Zero)
			{
				id_onErrorAnalysisAlreadyRunning = JNIEnv.GetMethodID(class_ref, "onErrorAnalysisAlreadyRunning", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onErrorAnalysisAlreadyRunning);
		}

		private static Delegate GetOnErrorInvalidApiKeyHandler()
		{
			if ((object)cb_onErrorInvalidApiKey == null)
			{
				cb_onErrorInvalidApiKey = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_OnErrorInvalidApiKey));
			}
			return cb_onErrorInvalidApiKey;
		}

		private static void n_OnErrorInvalidApiKey(IntPtr jnienv, IntPtr native__this)
		{
			IRouteThisAnalysisHandler routeThisAnalysisHandler = Java.Lang.Object.GetObject<IRouteThisAnalysisHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisAnalysisHandler.OnErrorInvalidApiKey();
		}

		public void OnErrorInvalidApiKey()
		{
			if (id_onErrorInvalidApiKey == IntPtr.Zero)
			{
				id_onErrorInvalidApiKey = JNIEnv.GetMethodID(class_ref, "onErrorInvalidApiKey", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onErrorInvalidApiKey);
		}

		private static Delegate GetOnErrorNoInternetConnectionHandler()
		{
			if ((object)cb_onErrorNoInternetConnection == null)
			{
				cb_onErrorNoInternetConnection = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_OnErrorNoInternetConnection));
			}
			return cb_onErrorNoInternetConnection;
		}

		private static void n_OnErrorNoInternetConnection(IntPtr jnienv, IntPtr native__this)
		{
			IRouteThisAnalysisHandler routeThisAnalysisHandler = Java.Lang.Object.GetObject<IRouteThisAnalysisHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisAnalysisHandler.OnErrorNoInternetConnection();
		}

		public void OnErrorNoInternetConnection()
		{
			if (id_onErrorNoInternetConnection == IntPtr.Zero)
			{
				id_onErrorNoInternetConnection = JNIEnv.GetMethodID(class_ref, "onErrorNoInternetConnection", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onErrorNoInternetConnection);
		}

		private static Delegate GetOnErrorNoWifiHandler()
		{
			if ((object)cb_onErrorNoWifi == null)
			{
				cb_onErrorNoWifi = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_OnErrorNoWifi));
			}
			return cb_onErrorNoWifi;
		}

		private static void n_OnErrorNoWifi(IntPtr jnienv, IntPtr native__this)
		{
			IRouteThisAnalysisHandler routeThisAnalysisHandler = Java.Lang.Object.GetObject<IRouteThisAnalysisHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisAnalysisHandler.OnErrorNoWifi();
		}

		public void OnErrorNoWifi()
		{
			if (id_onErrorNoWifi == IntPtr.Zero)
			{
				id_onErrorNoWifi = JNIEnv.GetMethodID(class_ref, "onErrorNoWifi", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onErrorNoWifi);
		}

		private static Delegate GetOnLocationServicesDisabledHandler()
		{
			if ((object)cb_onLocationServicesDisabled == null)
			{
				cb_onLocationServicesDisabled = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_OnLocationServicesDisabled));
			}
			return cb_onLocationServicesDisabled;
		}

		private static bool n_OnLocationServicesDisabled(IntPtr jnienv, IntPtr native__this)
		{
			IRouteThisAnalysisHandler routeThisAnalysisHandler = Java.Lang.Object.GetObject<IRouteThisAnalysisHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return routeThisAnalysisHandler.OnLocationServicesDisabled();
		}

		public bool OnLocationServicesDisabled()
		{
			if (id_onLocationServicesDisabled == IntPtr.Zero)
			{
				id_onLocationServicesDisabled = JNIEnv.GetMethodID(class_ref, "onLocationServicesDisabled", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_onLocationServicesDisabled);
		}

		private static Delegate GetOnMissingLocationPermissionHandler()
		{
			if ((object)cb_onMissingLocationPermission == null)
			{
				cb_onMissingLocationPermission = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_OnMissingLocationPermission));
			}
			return cb_onMissingLocationPermission;
		}

		private static bool n_OnMissingLocationPermission(IntPtr jnienv, IntPtr native__this)
		{
			IRouteThisAnalysisHandler routeThisAnalysisHandler = Java.Lang.Object.GetObject<IRouteThisAnalysisHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return routeThisAnalysisHandler.OnMissingLocationPermission();
		}

		public bool OnMissingLocationPermission()
		{
			if (id_onMissingLocationPermission == IntPtr.Zero)
			{
				id_onMissingLocationPermission = JNIEnv.GetMethodID(class_ref, "onMissingLocationPermission", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_onMissingLocationPermission);
		}

		private static Delegate GetOnWarningBatterySaverOnHandler()
		{
			if ((object)cb_onWarningBatterySaverOn == null)
			{
				cb_onWarningBatterySaverOn = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_OnWarningBatterySaverOn));
			}
			return cb_onWarningBatterySaverOn;
		}

		private static void n_OnWarningBatterySaverOn(IntPtr jnienv, IntPtr native__this)
		{
			IRouteThisAnalysisHandler routeThisAnalysisHandler = Java.Lang.Object.GetObject<IRouteThisAnalysisHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisAnalysisHandler.OnWarningBatterySaverOn();
		}

		public void OnWarningBatterySaverOn()
		{
			if (id_onWarningBatterySaverOn == IntPtr.Zero)
			{
				id_onWarningBatterySaverOn = JNIEnv.GetMethodID(class_ref, "onWarningBatterySaverOn", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onWarningBatterySaverOn);
		}
	}
	[Register("com/routethis/androidsdk/RouteThisProxyHandler", "", "Com.Routethis.Androidsdk.IRouteThisProxyHandlerInvoker")]
	public interface IRouteThisProxyHandler : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("onConnected", "()V", "GetOnConnectedHandler:Com.Routethis.Androidsdk.IRouteThisProxyHandlerInvoker, RouteThisAndroidBinding")]
		void OnConnected();

		[Register("onConnecting", "()V", "GetOnConnectingHandler:Com.Routethis.Androidsdk.IRouteThisProxyHandlerInvoker, RouteThisAndroidBinding")]
		void OnConnecting();

		[Register("onDisconnected", "()V", "GetOnDisconnectedHandler:Com.Routethis.Androidsdk.IRouteThisProxyHandlerInvoker, RouteThisAndroidBinding")]
		void OnDisconnected();
	}
	[Register("com/routethis/androidsdk/RouteThisProxyHandler", DoNotGenerateAcw = true)]
	internal class IRouteThisProxyHandlerInvoker : Java.Lang.Object, IRouteThisProxyHandler, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/RouteThisProxyHandler", typeof(IRouteThisProxyHandlerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_onConnected;

		private IntPtr id_onConnected;

		private static Delegate cb_onConnecting;

		private IntPtr id_onConnecting;

		private static Delegate cb_onDisconnected;

		private IntPtr id_onDisconnected;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IRouteThisProxyHandler GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IRouteThisProxyHandler>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.routethis.androidsdk.RouteThisProxyHandler"));
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

		public IRouteThisProxyHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetOnConnectedHandler()
		{
			if ((object)cb_onConnected == null)
			{
				cb_onConnected = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_OnConnected));
			}
			return cb_onConnected;
		}

		private static void n_OnConnected(IntPtr jnienv, IntPtr native__this)
		{
			IRouteThisProxyHandler routeThisProxyHandler = Java.Lang.Object.GetObject<IRouteThisProxyHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisProxyHandler.OnConnected();
		}

		public void OnConnected()
		{
			if (id_onConnected == IntPtr.Zero)
			{
				id_onConnected = JNIEnv.GetMethodID(class_ref, "onConnected", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onConnected);
		}

		private static Delegate GetOnConnectingHandler()
		{
			if ((object)cb_onConnecting == null)
			{
				cb_onConnecting = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_OnConnecting));
			}
			return cb_onConnecting;
		}

		private static void n_OnConnecting(IntPtr jnienv, IntPtr native__this)
		{
			IRouteThisProxyHandler routeThisProxyHandler = Java.Lang.Object.GetObject<IRouteThisProxyHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisProxyHandler.OnConnecting();
		}

		public void OnConnecting()
		{
			if (id_onConnecting == IntPtr.Zero)
			{
				id_onConnecting = JNIEnv.GetMethodID(class_ref, "onConnecting", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onConnecting);
		}

		private static Delegate GetOnDisconnectedHandler()
		{
			if ((object)cb_onDisconnected == null)
			{
				cb_onDisconnected = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_OnDisconnected));
			}
			return cb_onDisconnected;
		}

		private static void n_OnDisconnected(IntPtr jnienv, IntPtr native__this)
		{
			IRouteThisProxyHandler routeThisProxyHandler = Java.Lang.Object.GetObject<IRouteThisProxyHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisProxyHandler.OnDisconnected();
		}

		public void OnDisconnected()
		{
			if (id_onDisconnected == IntPtr.Zero)
			{
				id_onDisconnected = JNIEnv.GetMethodID(class_ref, "onDisconnected", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_onDisconnected);
		}
	}
	[Register("com/routethis/androidsdk/RouteThisApi", DoNotGenerateAcw = true)]
	public class RouteThisApi : Java.Lang.Object
	{
		[Register("HEALTH_CHECK_ANALYSIS_RUNNING")]
		public const int HealthCheckAnalysisRunning = 3;

		[Register("HEALTH_CHECK_COMPLETE_SENDING_DATA")]
		public const int HealthCheckCompleteSendingData = 1;

		[Register("HEALTH_CHECK_ERROR_NO_INTERNET_RETRY_REQUIRED")]
		public const int HealthCheckErrorNoInternetRetryRequired = 4;

		[Register("HEALTH_CHECK_ERROR_NO_WIFI")]
		public const int HealthCheckErrorNoWifi = 2;

		[Register("HEALTH_CHECK_SUCCESS")]
		public const int HealthCheckSuccess = 0;

		[Register("SDK_VERSION")]
		public const string SdkVersion = "9.1.1";

		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/RouteThisApi", typeof(RouteThisApi));

		private static Delegate cb_getSelfHelpUrl;

		private static Delegate cb_getUserId;

		private static Delegate cb_addCustomIp_Ljava_lang_String_;

		private static Delegate cb_addStatusObject_Ljava_lang_String_Ljava_lang_String_;

		private static Delegate cb_cancelHealthCheckSubmission;

		private static Delegate cb_checkWiFiPasswordForSpecialCharacters_Ljava_lang_String_;

		private static Delegate cb_clearStatusObjects;

		private static Delegate cb_connectLiveViewClient;

		private static Delegate cb_connectProxyClient;

		private static Delegate cb_connectRemoteControlClient;

		private static Delegate cb_destroy;

		private static Delegate cb_disconnectLiveViewClient;

		private static Delegate cb_disconnectProxyClient;

		private static Delegate cb_disconnectRemoteControlClient;

		private static Delegate cb_generateUsername_Lcom_routethis_androidsdk_RouteThisCallback_;

		private static Delegate cb_getClientConfig_Lcom_routethis_androidsdk_RouteThisCallback_;

		private static Delegate cb_liveViewInitializeRoom;

		private static Delegate cb_liveViewSendState_Ljava_lang_String_;

		private static Delegate cb_remoteControlPause;

		private static Delegate cb_remoteControlResume;

		private static Delegate cb_remoteControlSendFeatures_Ljava_util_List_;

		private static Delegate cb_remotePhotoClosed;

		private static Delegate cb_remotePhotoOpened;

		private static Delegate cb_retryHealthCheckSubmission_Lcom_routethis_androidsdk_RouteThisCallback_;

		private static Delegate cb_runAnalysis_Lcom_routethis_androidsdk_RouteThisAnalysisHandler_;

		private static Delegate cb_runQuickAnalysis_Lcom_routethis_androidsdk_RouteThisAnalysisHandler_;

		private static Delegate cb_setAdditionalHealthCheckConfig_Ljava_lang_String_;

		private static Delegate cb_setCheckForBatterySaver_Z;

		private static Delegate cb_setEmail_Ljava_lang_String_;

		private static Delegate cb_setLiveViewHandler_Lcom_routethis_androidsdk_F_;

		private static Delegate cb_setName_Ljava_lang_String_Ljava_lang_String_;

		private static Delegate cb_setProxyClientHandler_Lcom_routethis_androidsdk_RouteThisProxyHandler_;

		private static Delegate cb_setRemoteControlHandler_Lcom_routethis_androidsdk_G_;

		private static Delegate cb_setSpeedTestCallback_Lcom_routethis_androidsdk_RouteThisCallback_;

		private static Delegate cb_setUsername_Ljava_lang_String_;

		private static Delegate cb_startHealthCheck_Lcom_routethis_androidsdk_RouteThisCallback_Lcom_routethis_androidsdk_RouteThisCallback_;

		private static Delegate cb_trackEvent_Ljava_lang_String_;

		private static Delegate cb_trackPhoto_arrayBLcom_routethis_androidsdk_RouteThisCallback_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual string SelfHelpUrl
		{
			[Register("getSelfHelpUrl", "()Ljava/lang/String;", "GetGetSelfHelpUrlHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getSelfHelpUrl.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string UserId
		{
			[Register("getUserId", "()Ljava/lang/String;", "GetGetUserIdHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getUserId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected RouteThisApi(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetGetSelfHelpUrlHandler()
		{
			if ((object)cb_getSelfHelpUrl == null)
			{
				cb_getSelfHelpUrl = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetSelfHelpUrl));
			}
			return cb_getSelfHelpUrl;
		}

		private static IntPtr n_GetSelfHelpUrl(IntPtr jnienv, IntPtr native__this)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(routeThisApi.SelfHelpUrl);
		}

		private static Delegate GetGetUserIdHandler()
		{
			if ((object)cb_getUserId == null)
			{
				cb_getUserId = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_GetUserId));
			}
			return cb_getUserId;
		}

		private static IntPtr n_GetUserId(IntPtr jnienv, IntPtr native__this)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(routeThisApi.UserId);
		}

		private static Delegate GetAddCustomIp_Ljava_lang_String_Handler()
		{
			if ((object)cb_addCustomIp_Ljava_lang_String_ == null)
			{
				cb_addCustomIp_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_AddCustomIp_Ljava_lang_String_));
			}
			return cb_addCustomIp_Ljava_lang_String_;
		}

		private static void n_AddCustomIp_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			routeThisApi.AddCustomIp(p);
		}

		[Register("addCustomIp", "(Ljava/lang/String;)V", "GetAddCustomIp_Ljava_lang_String_Handler")]
		public unsafe virtual void AddCustomIp(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addCustomIp.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetAddStatusObject_Ljava_lang_String_Ljava_lang_String_Handler()
		{
			if ((object)cb_addStatusObject_Ljava_lang_String_Ljava_lang_String_ == null)
			{
				cb_addStatusObject_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr>(n_AddStatusObject_Ljava_lang_String_Ljava_lang_String_));
			}
			return cb_addStatusObject_Ljava_lang_String_Ljava_lang_String_;
		}

		private static void n_AddStatusObject_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			routeThisApi.AddStatusObject(p, p2);
		}

		[Register("addStatusObject", "(Ljava/lang/String;Ljava/lang/String;)V", "GetAddStatusObject_Ljava_lang_String_Ljava_lang_String_Handler")]
		public unsafe virtual void AddStatusObject(string p0, string p1)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeVirtualVoidMethod("addStatusObject.(Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		private static Delegate GetCancelHealthCheckSubmissionHandler()
		{
			if ((object)cb_cancelHealthCheckSubmission == null)
			{
				cb_cancelHealthCheckSubmission = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_CancelHealthCheckSubmission));
			}
			return cb_cancelHealthCheckSubmission;
		}

		private static void n_CancelHealthCheckSubmission(IntPtr jnienv, IntPtr native__this)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisApi.CancelHealthCheckSubmission();
		}

		[Register("cancelHealthCheckSubmission", "()V", "GetCancelHealthCheckSubmissionHandler")]
		public unsafe virtual void CancelHealthCheckSubmission()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("cancelHealthCheckSubmission.()V", this, null);
		}

		private static Delegate GetCheckWiFiPasswordForSpecialCharacters_Ljava_lang_String_Handler()
		{
			if ((object)cb_checkWiFiPasswordForSpecialCharacters_Ljava_lang_String_ == null)
			{
				cb_checkWiFiPasswordForSpecialCharacters_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_CheckWiFiPasswordForSpecialCharacters_Ljava_lang_String_));
			}
			return cb_checkWiFiPasswordForSpecialCharacters_Ljava_lang_String_;
		}

		private static void n_CheckWiFiPasswordForSpecialCharacters_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			routeThisApi.CheckWiFiPasswordForSpecialCharacters(p);
		}

		[Register("checkWiFiPasswordForSpecialCharacters", "(Ljava/lang/String;)V", "GetCheckWiFiPasswordForSpecialCharacters_Ljava_lang_String_Handler")]
		public unsafe virtual void CheckWiFiPasswordForSpecialCharacters(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("checkWiFiPasswordForSpecialCharacters.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetClearStatusObjectsHandler()
		{
			if ((object)cb_clearStatusObjects == null)
			{
				cb_clearStatusObjects = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_ClearStatusObjects));
			}
			return cb_clearStatusObjects;
		}

		private static void n_ClearStatusObjects(IntPtr jnienv, IntPtr native__this)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisApi.ClearStatusObjects();
		}

		[Register("clearStatusObjects", "()V", "GetClearStatusObjectsHandler")]
		public unsafe virtual void ClearStatusObjects()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("clearStatusObjects.()V", this, null);
		}

		private static Delegate GetConnectLiveViewClientHandler()
		{
			if ((object)cb_connectLiveViewClient == null)
			{
				cb_connectLiveViewClient = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_ConnectLiveViewClient));
			}
			return cb_connectLiveViewClient;
		}

		private static void n_ConnectLiveViewClient(IntPtr jnienv, IntPtr native__this)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisApi.ConnectLiveViewClient();
		}

		[Register("connectLiveViewClient", "()V", "GetConnectLiveViewClientHandler")]
		public unsafe virtual void ConnectLiveViewClient()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("connectLiveViewClient.()V", this, null);
		}

		private static Delegate GetConnectProxyClientHandler()
		{
			if ((object)cb_connectProxyClient == null)
			{
				cb_connectProxyClient = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_ConnectProxyClient));
			}
			return cb_connectProxyClient;
		}

		private static void n_ConnectProxyClient(IntPtr jnienv, IntPtr native__this)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisApi.ConnectProxyClient();
		}

		[Register("connectProxyClient", "()V", "GetConnectProxyClientHandler")]
		public unsafe virtual void ConnectProxyClient()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("connectProxyClient.()V", this, null);
		}

		private static Delegate GetConnectRemoteControlClientHandler()
		{
			if ((object)cb_connectRemoteControlClient == null)
			{
				cb_connectRemoteControlClient = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_ConnectRemoteControlClient));
			}
			return cb_connectRemoteControlClient;
		}

		private static void n_ConnectRemoteControlClient(IntPtr jnienv, IntPtr native__this)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisApi.ConnectRemoteControlClient();
		}

		[Register("connectRemoteControlClient", "()V", "GetConnectRemoteControlClientHandler")]
		public unsafe virtual void ConnectRemoteControlClient()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("connectRemoteControlClient.()V", this, null);
		}

		private static Delegate GetDestroyHandler()
		{
			if ((object)cb_destroy == null)
			{
				cb_destroy = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_Destroy));
			}
			return cb_destroy;
		}

		private static void n_Destroy(IntPtr jnienv, IntPtr native__this)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisApi.Destroy();
		}

		[Register("destroy", "()V", "GetDestroyHandler")]
		public unsafe virtual void Destroy()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("destroy.()V", this, null);
		}

		private static Delegate GetDisconnectLiveViewClientHandler()
		{
			if ((object)cb_disconnectLiveViewClient == null)
			{
				cb_disconnectLiveViewClient = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_DisconnectLiveViewClient));
			}
			return cb_disconnectLiveViewClient;
		}

		private static void n_DisconnectLiveViewClient(IntPtr jnienv, IntPtr native__this)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisApi.DisconnectLiveViewClient();
		}

		[Register("disconnectLiveViewClient", "()V", "GetDisconnectLiveViewClientHandler")]
		public unsafe virtual void DisconnectLiveViewClient()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("disconnectLiveViewClient.()V", this, null);
		}

		private static Delegate GetDisconnectProxyClientHandler()
		{
			if ((object)cb_disconnectProxyClient == null)
			{
				cb_disconnectProxyClient = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_DisconnectProxyClient));
			}
			return cb_disconnectProxyClient;
		}

		private static void n_DisconnectProxyClient(IntPtr jnienv, IntPtr native__this)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisApi.DisconnectProxyClient();
		}

		[Register("disconnectProxyClient", "()V", "GetDisconnectProxyClientHandler")]
		public unsafe virtual void DisconnectProxyClient()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("disconnectProxyClient.()V", this, null);
		}

		private static Delegate GetDisconnectRemoteControlClientHandler()
		{
			if ((object)cb_disconnectRemoteControlClient == null)
			{
				cb_disconnectRemoteControlClient = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_DisconnectRemoteControlClient));
			}
			return cb_disconnectRemoteControlClient;
		}

		private static void n_DisconnectRemoteControlClient(IntPtr jnienv, IntPtr native__this)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisApi.DisconnectRemoteControlClient();
		}

		[Register("disconnectRemoteControlClient", "()V", "GetDisconnectRemoteControlClientHandler")]
		public unsafe virtual void DisconnectRemoteControlClient()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("disconnectRemoteControlClient.()V", this, null);
		}

		private static Delegate GetGenerateUsername_Lcom_routethis_androidsdk_RouteThisCallback_Handler()
		{
			if ((object)cb_generateUsername_Lcom_routethis_androidsdk_RouteThisCallback_ == null)
			{
				cb_generateUsername_Lcom_routethis_androidsdk_RouteThisCallback_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_GenerateUsername_Lcom_routethis_androidsdk_RouteThisCallback_));
			}
			return cb_generateUsername_Lcom_routethis_androidsdk_RouteThisCallback_;
		}

		private static void n_GenerateUsername_Lcom_routethis_androidsdk_RouteThisCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RouteThisCallback p = Java.Lang.Object.GetObject<RouteThisCallback>(native_p0, JniHandleOwnership.DoNotTransfer);
			routeThisApi.GenerateUsername(p);
		}

		[Register("generateUsername", "(Lcom/routethis/androidsdk/RouteThisCallback;)V", "GetGenerateUsername_Lcom_routethis_androidsdk_RouteThisCallback_Handler")]
		public unsafe virtual void GenerateUsername(RouteThisCallback p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("generateUsername.(Lcom/routethis/androidsdk/RouteThisCallback;)V", this, ptr);
			GC.KeepAlive(p0);
		}

		private static Delegate GetGetClientConfig_Lcom_routethis_androidsdk_RouteThisCallback_Handler()
		{
			if ((object)cb_getClientConfig_Lcom_routethis_androidsdk_RouteThisCallback_ == null)
			{
				cb_getClientConfig_Lcom_routethis_androidsdk_RouteThisCallback_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_GetClientConfig_Lcom_routethis_androidsdk_RouteThisCallback_));
			}
			return cb_getClientConfig_Lcom_routethis_androidsdk_RouteThisCallback_;
		}

		private static void n_GetClientConfig_Lcom_routethis_androidsdk_RouteThisCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RouteThisCallback p = Java.Lang.Object.GetObject<RouteThisCallback>(native_p0, JniHandleOwnership.DoNotTransfer);
			routeThisApi.GetClientConfig(p);
		}

		[Register("getClientConfig", "(Lcom/routethis/androidsdk/RouteThisCallback;)V", "GetGetClientConfig_Lcom_routethis_androidsdk_RouteThisCallback_Handler")]
		public unsafe virtual void GetClientConfig(RouteThisCallback p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("getClientConfig.(Lcom/routethis/androidsdk/RouteThisCallback;)V", this, ptr);
			GC.KeepAlive(p0);
		}

		[Register("getInstance", "(Landroid/content/Context;Ljava/lang/String;)Lcom/routethis/androidsdk/RouteThisApi;", "")]
		public unsafe static RouteThisApi GetInstance(Context p0, string p1)
		{
			IntPtr intPtr = JNIEnv.NewString(p1);
			RouteThisApi result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<RouteThisApi>(_members.StaticMethods.InvokeObjectMethod("getInstance.(Landroid/content/Context;Ljava/lang/String;)Lcom/routethis/androidsdk/RouteThisApi;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(p0);
			return result;
		}

		[Register("getInstance", "(Landroid/content/Context;Ljava/lang/String;Ljava/util/UUID;)Lcom/routethis/androidsdk/RouteThisApi;", "")]
		public unsafe static RouteThisApi GetInstance(Context p0, string p1, UUID p2)
		{
			IntPtr intPtr = JNIEnv.NewString(p1);
			RouteThisApi result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
				result = Java.Lang.Object.GetObject<RouteThisApi>(_members.StaticMethods.InvokeObjectMethod("getInstance.(Landroid/content/Context;Ljava/lang/String;Ljava/util/UUID;)Lcom/routethis/androidsdk/RouteThisApi;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
			GC.KeepAlive(p0);
			GC.KeepAlive(p2);
			return result;
		}

		private static Delegate GetLiveViewInitializeRoomHandler()
		{
			if ((object)cb_liveViewInitializeRoom == null)
			{
				cb_liveViewInitializeRoom = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_LiveViewInitializeRoom));
			}
			return cb_liveViewInitializeRoom;
		}

		private static void n_LiveViewInitializeRoom(IntPtr jnienv, IntPtr native__this)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisApi.LiveViewInitializeRoom();
		}

		[Register("liveViewInitializeRoom", "()V", "GetLiveViewInitializeRoomHandler")]
		public unsafe virtual void LiveViewInitializeRoom()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("liveViewInitializeRoom.()V", this, null);
		}

		private static Delegate GetLiveViewSendState_Ljava_lang_String_Handler()
		{
			if ((object)cb_liveViewSendState_Ljava_lang_String_ == null)
			{
				cb_liveViewSendState_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_LiveViewSendState_Ljava_lang_String_));
			}
			return cb_liveViewSendState_Ljava_lang_String_;
		}

		private static void n_LiveViewSendState_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			routeThisApi.LiveViewSendState(p);
		}

		[Register("liveViewSendState", "(Ljava/lang/String;)V", "GetLiveViewSendState_Ljava_lang_String_Handler")]
		public unsafe virtual void LiveViewSendState(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("liveViewSendState.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetRemoteControlPauseHandler()
		{
			if ((object)cb_remoteControlPause == null)
			{
				cb_remoteControlPause = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_RemoteControlPause));
			}
			return cb_remoteControlPause;
		}

		private static void n_RemoteControlPause(IntPtr jnienv, IntPtr native__this)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisApi.RemoteControlPause();
		}

		[Register("remoteControlPause", "()V", "GetRemoteControlPauseHandler")]
		public unsafe virtual void RemoteControlPause()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("remoteControlPause.()V", this, null);
		}

		private static Delegate GetRemoteControlResumeHandler()
		{
			if ((object)cb_remoteControlResume == null)
			{
				cb_remoteControlResume = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_RemoteControlResume));
			}
			return cb_remoteControlResume;
		}

		private static void n_RemoteControlResume(IntPtr jnienv, IntPtr native__this)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisApi.RemoteControlResume();
		}

		[Register("remoteControlResume", "()V", "GetRemoteControlResumeHandler")]
		public unsafe virtual void RemoteControlResume()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("remoteControlResume.()V", this, null);
		}

		private static Delegate GetRemoteControlSendFeatures_Ljava_util_List_Handler()
		{
			if ((object)cb_remoteControlSendFeatures_Ljava_util_List_ == null)
			{
				cb_remoteControlSendFeatures_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_RemoteControlSendFeatures_Ljava_util_List_));
			}
			return cb_remoteControlSendFeatures_Ljava_util_List_;
		}

		private static void n_RemoteControlSendFeatures_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<string> p = JavaList<string>.FromJniHandle(native_p0, JniHandleOwnership.DoNotTransfer);
			routeThisApi.RemoteControlSendFeatures(p);
		}

		[Register("remoteControlSendFeatures", "(Ljava/util/List;)V", "GetRemoteControlSendFeatures_Ljava_util_List_Handler")]
		public unsafe virtual void RemoteControlSendFeatures(IList<string> p0)
		{
			IntPtr intPtr = JavaList<string>.ToLocalJniHandle(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("remoteControlSendFeatures.(Ljava/util/List;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetRemotePhotoClosedHandler()
		{
			if ((object)cb_remotePhotoClosed == null)
			{
				cb_remotePhotoClosed = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_RemotePhotoClosed));
			}
			return cb_remotePhotoClosed;
		}

		private static void n_RemotePhotoClosed(IntPtr jnienv, IntPtr native__this)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisApi.RemotePhotoClosed();
		}

		[Register("remotePhotoClosed", "()V", "GetRemotePhotoClosedHandler")]
		public unsafe virtual void RemotePhotoClosed()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("remotePhotoClosed.()V", this, null);
		}

		private static Delegate GetRemotePhotoOpenedHandler()
		{
			if ((object)cb_remotePhotoOpened == null)
			{
				cb_remotePhotoOpened = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_RemotePhotoOpened));
			}
			return cb_remotePhotoOpened;
		}

		private static void n_RemotePhotoOpened(IntPtr jnienv, IntPtr native__this)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisApi.RemotePhotoOpened();
		}

		[Register("remotePhotoOpened", "()V", "GetRemotePhotoOpenedHandler")]
		public unsafe virtual void RemotePhotoOpened()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("remotePhotoOpened.()V", this, null);
		}

		private static Delegate GetRetryHealthCheckSubmission_Lcom_routethis_androidsdk_RouteThisCallback_Handler()
		{
			if ((object)cb_retryHealthCheckSubmission_Lcom_routethis_androidsdk_RouteThisCallback_ == null)
			{
				cb_retryHealthCheckSubmission_Lcom_routethis_androidsdk_RouteThisCallback_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_RetryHealthCheckSubmission_Lcom_routethis_androidsdk_RouteThisCallback_));
			}
			return cb_retryHealthCheckSubmission_Lcom_routethis_androidsdk_RouteThisCallback_;
		}

		private static void n_RetryHealthCheckSubmission_Lcom_routethis_androidsdk_RouteThisCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RouteThisCallback p = Java.Lang.Object.GetObject<RouteThisCallback>(native_p0, JniHandleOwnership.DoNotTransfer);
			routeThisApi.RetryHealthCheckSubmission(p);
		}

		[Register("retryHealthCheckSubmission", "(Lcom/routethis/androidsdk/RouteThisCallback;)V", "GetRetryHealthCheckSubmission_Lcom_routethis_androidsdk_RouteThisCallback_Handler")]
		public unsafe virtual void RetryHealthCheckSubmission(RouteThisCallback p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("retryHealthCheckSubmission.(Lcom/routethis/androidsdk/RouteThisCallback;)V", this, ptr);
			GC.KeepAlive(p0);
		}

		private static Delegate GetRunAnalysis_Lcom_routethis_androidsdk_RouteThisAnalysisHandler_Handler()
		{
			if ((object)cb_runAnalysis_Lcom_routethis_androidsdk_RouteThisAnalysisHandler_ == null)
			{
				cb_runAnalysis_Lcom_routethis_androidsdk_RouteThisAnalysisHandler_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_RunAnalysis_Lcom_routethis_androidsdk_RouteThisAnalysisHandler_));
			}
			return cb_runAnalysis_Lcom_routethis_androidsdk_RouteThisAnalysisHandler_;
		}

		private static void n_RunAnalysis_Lcom_routethis_androidsdk_RouteThisAnalysisHandler_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRouteThisAnalysisHandler p = Java.Lang.Object.GetObject<IRouteThisAnalysisHandler>(native_p0, JniHandleOwnership.DoNotTransfer);
			routeThisApi.RunAnalysis(p);
		}

		[Register("runAnalysis", "(Lcom/routethis/androidsdk/RouteThisAnalysisHandler;)V", "GetRunAnalysis_Lcom_routethis_androidsdk_RouteThisAnalysisHandler_Handler")]
		public unsafe virtual void RunAnalysis(IRouteThisAnalysisHandler p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("runAnalysis.(Lcom/routethis/androidsdk/RouteThisAnalysisHandler;)V", this, ptr);
			GC.KeepAlive(p0);
		}

		private static Delegate GetRunQuickAnalysis_Lcom_routethis_androidsdk_RouteThisAnalysisHandler_Handler()
		{
			if ((object)cb_runQuickAnalysis_Lcom_routethis_androidsdk_RouteThisAnalysisHandler_ == null)
			{
				cb_runQuickAnalysis_Lcom_routethis_androidsdk_RouteThisAnalysisHandler_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_RunQuickAnalysis_Lcom_routethis_androidsdk_RouteThisAnalysisHandler_));
			}
			return cb_runQuickAnalysis_Lcom_routethis_androidsdk_RouteThisAnalysisHandler_;
		}

		private static void n_RunQuickAnalysis_Lcom_routethis_androidsdk_RouteThisAnalysisHandler_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRouteThisAnalysisHandler p = Java.Lang.Object.GetObject<IRouteThisAnalysisHandler>(native_p0, JniHandleOwnership.DoNotTransfer);
			routeThisApi.RunQuickAnalysis(p);
		}

		[Register("runQuickAnalysis", "(Lcom/routethis/androidsdk/RouteThisAnalysisHandler;)V", "GetRunQuickAnalysis_Lcom_routethis_androidsdk_RouteThisAnalysisHandler_Handler")]
		public unsafe virtual void RunQuickAnalysis(IRouteThisAnalysisHandler p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("runQuickAnalysis.(Lcom/routethis/androidsdk/RouteThisAnalysisHandler;)V", this, ptr);
			GC.KeepAlive(p0);
		}

		private static Delegate GetSetAdditionalHealthCheckConfig_Ljava_lang_String_Handler()
		{
			if ((object)cb_setAdditionalHealthCheckConfig_Ljava_lang_String_ == null)
			{
				cb_setAdditionalHealthCheckConfig_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetAdditionalHealthCheckConfig_Ljava_lang_String_));
			}
			return cb_setAdditionalHealthCheckConfig_Ljava_lang_String_;
		}

		private static void n_SetAdditionalHealthCheckConfig_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string additionalHealthCheckConfig = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			routeThisApi.SetAdditionalHealthCheckConfig(additionalHealthCheckConfig);
		}

		[Register("setAdditionalHealthCheckConfig", "(Ljava/lang/String;)V", "GetSetAdditionalHealthCheckConfig_Ljava_lang_String_Handler")]
		public unsafe virtual void SetAdditionalHealthCheckConfig(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setAdditionalHealthCheckConfig.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetSetCheckForBatterySaver_ZHandler()
		{
			if ((object)cb_setCheckForBatterySaver_Z == null)
			{
				cb_setCheckForBatterySaver_Z = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, bool>(n_SetCheckForBatterySaver_Z));
			}
			return cb_setCheckForBatterySaver_Z;
		}

		private static void n_SetCheckForBatterySaver_Z(IntPtr jnienv, IntPtr native__this, bool p0)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			routeThisApi.SetCheckForBatterySaver(p0);
		}

		[Register("setCheckForBatterySaver", "(Z)V", "GetSetCheckForBatterySaver_ZHandler")]
		public unsafe virtual void SetCheckForBatterySaver(bool p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setCheckForBatterySaver.(Z)V", this, ptr);
		}

		private static Delegate GetSetEmail_Ljava_lang_String_Handler()
		{
			if ((object)cb_setEmail_Ljava_lang_String_ == null)
			{
				cb_setEmail_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetEmail_Ljava_lang_String_));
			}
			return cb_setEmail_Ljava_lang_String_;
		}

		private static void n_SetEmail_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string email = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			routeThisApi.SetEmail(email);
		}

		[Register("setEmail", "(Ljava/lang/String;)V", "GetSetEmail_Ljava_lang_String_Handler")]
		public unsafe virtual void SetEmail(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setEmail.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetSetLiveViewHandler_Lcom_routethis_androidsdk_F_Handler()
		{
			if ((object)cb_setLiveViewHandler_Lcom_routethis_androidsdk_F_ == null)
			{
				cb_setLiveViewHandler_Lcom_routethis_androidsdk_F_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetLiveViewHandler_Lcom_routethis_androidsdk_F_));
			}
			return cb_setLiveViewHandler_Lcom_routethis_androidsdk_F_;
		}

		private static void n_SetLiveViewHandler_Lcom_routethis_androidsdk_F_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IF liveViewHandler = Java.Lang.Object.GetObject<IF>(native_p0, JniHandleOwnership.DoNotTransfer);
			routeThisApi.SetLiveViewHandler(liveViewHandler);
		}

		[Register("setLiveViewHandler", "(Lcom/routethis/androidsdk/F;)V", "GetSetLiveViewHandler_Lcom_routethis_androidsdk_F_Handler")]
		public unsafe virtual void SetLiveViewHandler(IF p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setLiveViewHandler.(Lcom/routethis/androidsdk/F;)V", this, ptr);
			GC.KeepAlive(p0);
		}

		private static Delegate GetSetName_Ljava_lang_String_Ljava_lang_String_Handler()
		{
			if ((object)cb_setName_Ljava_lang_String_Ljava_lang_String_ == null)
			{
				cb_setName_Ljava_lang_String_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr>(n_SetName_Ljava_lang_String_Ljava_lang_String_));
			}
			return cb_setName_Ljava_lang_String_Ljava_lang_String_;
		}

		private static void n_SetName_Ljava_lang_String_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			routeThisApi.SetName(p, p2);
		}

		[Register("setName", "(Ljava/lang/String;Ljava/lang/String;)V", "GetSetName_Ljava_lang_String_Ljava_lang_String_Handler")]
		public unsafe virtual void SetName(string p0, string p1)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setName.(Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		private static Delegate GetSetProxyClientHandler_Lcom_routethis_androidsdk_RouteThisProxyHandler_Handler()
		{
			if ((object)cb_setProxyClientHandler_Lcom_routethis_androidsdk_RouteThisProxyHandler_ == null)
			{
				cb_setProxyClientHandler_Lcom_routethis_androidsdk_RouteThisProxyHandler_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetProxyClientHandler_Lcom_routethis_androidsdk_RouteThisProxyHandler_));
			}
			return cb_setProxyClientHandler_Lcom_routethis_androidsdk_RouteThisProxyHandler_;
		}

		private static void n_SetProxyClientHandler_Lcom_routethis_androidsdk_RouteThisProxyHandler_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRouteThisProxyHandler proxyClientHandler = Java.Lang.Object.GetObject<IRouteThisProxyHandler>(native_p0, JniHandleOwnership.DoNotTransfer);
			routeThisApi.SetProxyClientHandler(proxyClientHandler);
		}

		[Register("setProxyClientHandler", "(Lcom/routethis/androidsdk/RouteThisProxyHandler;)V", "GetSetProxyClientHandler_Lcom_routethis_androidsdk_RouteThisProxyHandler_Handler")]
		public unsafe virtual void SetProxyClientHandler(IRouteThisProxyHandler p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setProxyClientHandler.(Lcom/routethis/androidsdk/RouteThisProxyHandler;)V", this, ptr);
			GC.KeepAlive(p0);
		}

		private static Delegate GetSetRemoteControlHandler_Lcom_routethis_androidsdk_G_Handler()
		{
			if ((object)cb_setRemoteControlHandler_Lcom_routethis_androidsdk_G_ == null)
			{
				cb_setRemoteControlHandler_Lcom_routethis_androidsdk_G_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetRemoteControlHandler_Lcom_routethis_androidsdk_G_));
			}
			return cb_setRemoteControlHandler_Lcom_routethis_androidsdk_G_;
		}

		private static void n_SetRemoteControlHandler_Lcom_routethis_androidsdk_G_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IG remoteControlHandler = Java.Lang.Object.GetObject<IG>(native_p0, JniHandleOwnership.DoNotTransfer);
			routeThisApi.SetRemoteControlHandler(remoteControlHandler);
		}

		[Register("setRemoteControlHandler", "(Lcom/routethis/androidsdk/G;)V", "GetSetRemoteControlHandler_Lcom_routethis_androidsdk_G_Handler")]
		public unsafe virtual void SetRemoteControlHandler(IG p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setRemoteControlHandler.(Lcom/routethis/androidsdk/G;)V", this, ptr);
			GC.KeepAlive(p0);
		}

		private static Delegate GetSetSpeedTestCallback_Lcom_routethis_androidsdk_RouteThisCallback_Handler()
		{
			if ((object)cb_setSpeedTestCallback_Lcom_routethis_androidsdk_RouteThisCallback_ == null)
			{
				cb_setSpeedTestCallback_Lcom_routethis_androidsdk_RouteThisCallback_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetSpeedTestCallback_Lcom_routethis_androidsdk_RouteThisCallback_));
			}
			return cb_setSpeedTestCallback_Lcom_routethis_androidsdk_RouteThisCallback_;
		}

		private static void n_SetSpeedTestCallback_Lcom_routethis_androidsdk_RouteThisCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RouteThisCallback speedTestCallback = Java.Lang.Object.GetObject<RouteThisCallback>(native_p0, JniHandleOwnership.DoNotTransfer);
			routeThisApi.SetSpeedTestCallback(speedTestCallback);
		}

		[Register("setSpeedTestCallback", "(Lcom/routethis/androidsdk/RouteThisCallback;)V", "GetSetSpeedTestCallback_Lcom_routethis_androidsdk_RouteThisCallback_Handler")]
		public unsafe virtual void SetSpeedTestCallback(RouteThisCallback p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setSpeedTestCallback.(Lcom/routethis/androidsdk/RouteThisCallback;)V", this, ptr);
			GC.KeepAlive(p0);
		}

		private static Delegate GetSetUsername_Ljava_lang_String_Handler()
		{
			if ((object)cb_setUsername_Ljava_lang_String_ == null)
			{
				cb_setUsername_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_SetUsername_Ljava_lang_String_));
			}
			return cb_setUsername_Ljava_lang_String_;
		}

		private static void n_SetUsername_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string username = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			routeThisApi.SetUsername(username);
		}

		[Register("setUsername", "(Ljava/lang/String;)V", "GetSetUsername_Ljava_lang_String_Handler")]
		public unsafe virtual void SetUsername(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setUsername.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetStartHealthCheck_Lcom_routethis_androidsdk_RouteThisCallback_Lcom_routethis_androidsdk_RouteThisCallback_Handler()
		{
			if ((object)cb_startHealthCheck_Lcom_routethis_androidsdk_RouteThisCallback_Lcom_routethis_androidsdk_RouteThisCallback_ == null)
			{
				cb_startHealthCheck_Lcom_routethis_androidsdk_RouteThisCallback_Lcom_routethis_androidsdk_RouteThisCallback_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr>(n_StartHealthCheck_Lcom_routethis_androidsdk_RouteThisCallback_Lcom_routethis_androidsdk_RouteThisCallback_));
			}
			return cb_startHealthCheck_Lcom_routethis_androidsdk_RouteThisCallback_Lcom_routethis_androidsdk_RouteThisCallback_;
		}

		private static void n_StartHealthCheck_Lcom_routethis_androidsdk_RouteThisCallback_Lcom_routethis_androidsdk_RouteThisCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RouteThisCallback p = Java.Lang.Object.GetObject<RouteThisCallback>(native_p0, JniHandleOwnership.DoNotTransfer);
			RouteThisCallback p2 = Java.Lang.Object.GetObject<RouteThisCallback>(native_p1, JniHandleOwnership.DoNotTransfer);
			routeThisApi.StartHealthCheck(p, p2);
		}

		[Register("startHealthCheck", "(Lcom/routethis/androidsdk/RouteThisCallback;Lcom/routethis/androidsdk/RouteThisCallback;)V", "GetStartHealthCheck_Lcom_routethis_androidsdk_RouteThisCallback_Lcom_routethis_androidsdk_RouteThisCallback_Handler")]
		public unsafe virtual void StartHealthCheck(RouteThisCallback p0, RouteThisCallback p1)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("startHealthCheck.(Lcom/routethis/androidsdk/RouteThisCallback;Lcom/routethis/androidsdk/RouteThisCallback;)V", this, ptr);
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}

		private static Delegate GetTrackEvent_Ljava_lang_String_Handler()
		{
			if ((object)cb_trackEvent_Ljava_lang_String_ == null)
			{
				cb_trackEvent_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_TrackEvent_Ljava_lang_String_));
			}
			return cb_trackEvent_Ljava_lang_String_;
		}

		private static void n_TrackEvent_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			routeThisApi.TrackEvent(p);
		}

		[Register("trackEvent", "(Ljava/lang/String;)V", "GetTrackEvent_Ljava_lang_String_Handler")]
		public unsafe virtual void TrackEvent(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("trackEvent.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetTrackPhoto_arrayBLcom_routethis_androidsdk_RouteThisCallback_Handler()
		{
			if ((object)cb_trackPhoto_arrayBLcom_routethis_androidsdk_RouteThisCallback_ == null)
			{
				cb_trackPhoto_arrayBLcom_routethis_androidsdk_RouteThisCallback_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr>(n_TrackPhoto_arrayBLcom_routethis_androidsdk_RouteThisCallback_));
			}
			return cb_trackPhoto_arrayBLcom_routethis_androidsdk_RouteThisCallback_;
		}

		private static void n_TrackPhoto_arrayBLcom_routethis_androidsdk_RouteThisCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			RouteThisApi routeThisApi = Java.Lang.Object.GetObject<RouteThisApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_p0, JniHandleOwnership.DoNotTransfer, typeof(byte));
			RouteThisCallback p = Java.Lang.Object.GetObject<RouteThisCallback>(native_p1, JniHandleOwnership.DoNotTransfer);
			routeThisApi.TrackPhoto(array, p);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p0);
			}
		}

		[Register("trackPhoto", "([BLcom/routethis/androidsdk/RouteThisCallback;)V", "GetTrackPhoto_arrayBLcom_routethis_androidsdk_RouteThisCallback_Handler")]
		public unsafe virtual void TrackPhoto(byte[] p0, RouteThisCallback p1)
		{
			IntPtr intPtr = JNIEnv.NewArray(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("trackPhoto.([BLcom/routethis/androidsdk/RouteThisCallback;)V", this, ptr);
			}
			finally
			{
				if (p0 != null)
				{
					JNIEnv.CopyArray(intPtr, p0);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(p0);
					GC.KeepAlive(p1);
				}
			}
		}
	}
	[Register("com/routethis/androidsdk/RouteThisCallback", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "T" })]
	public abstract class RouteThisCallback : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/RouteThisCallback", typeof(RouteThisCallback));

		private static Delegate cb_onResponse_Ljava_lang_Object_;

		private static Delegate cb_postResponse_Landroid_os_Handler_Ljava_lang_Object_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe static Handler Handler
		{
			[Register("getHandler", "()Landroid/os/Handler;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Handler>(_members.StaticMethods.InvokeObjectMethod("getHandler.()Landroid/os/Handler;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected RouteThisCallback(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe RouteThisCallback()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetOnResponse_Ljava_lang_Object_Handler()
		{
			if ((object)cb_onResponse_Ljava_lang_Object_ == null)
			{
				cb_onResponse_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_OnResponse_Ljava_lang_Object_));
			}
			return cb_onResponse_Ljava_lang_Object_;
		}

		private static void n_OnResponse_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			RouteThisCallback routeThisCallback = Java.Lang.Object.GetObject<RouteThisCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p0, JniHandleOwnership.DoNotTransfer);
			routeThisCallback.OnResponse(p);
		}

		[Register("onResponse", "(Ljava/lang/Object;)V", "GetOnResponse_Ljava_lang_Object_Handler")]
		public abstract void OnResponse(Java.Lang.Object p0);

		private static Delegate GetPostResponse_Landroid_os_Handler_Ljava_lang_Object_Handler()
		{
			if ((object)cb_postResponse_Landroid_os_Handler_Ljava_lang_Object_ == null)
			{
				cb_postResponse_Landroid_os_Handler_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr>(n_PostResponse_Landroid_os_Handler_Ljava_lang_Object_));
			}
			return cb_postResponse_Landroid_os_Handler_Ljava_lang_Object_;
		}

		private static void n_PostResponse_Landroid_os_Handler_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			RouteThisCallback routeThisCallback = Java.Lang.Object.GetObject<RouteThisCallback>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Handler p = Java.Lang.Object.GetObject<Handler>(native_p0, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object p2 = Java.Lang.Object.GetObject<Java.Lang.Object>(native_p1, JniHandleOwnership.DoNotTransfer);
			routeThisCallback.PostResponse(p, p2);
		}

		[Register("postResponse", "(Landroid/os/Handler;Ljava/lang/Object;)V", "GetPostResponse_Landroid_os_Handler_Ljava_lang_Object_Handler")]
		public unsafe virtual void PostResponse(Handler p0, Java.Lang.Object p1)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("postResponse.(Landroid/os/Handler;Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("com/routethis/androidsdk/RouteThisCallback", DoNotGenerateAcw = true)]
	internal class RouteThisCallbackInvoker : RouteThisCallback
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/RouteThisCallback", typeof(RouteThisCallbackInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public RouteThisCallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("onResponse", "(Ljava/lang/Object;)V", "GetOnResponse_Ljava_lang_Object_Handler")]
		public unsafe override void OnResponse(Java.Lang.Object p0)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeAbstractVoidMethod("onResponse.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
			}
		}
	}
}
namespace Com.Routethis.Androidsdk.A
{
	[Register("com/routethis/androidsdk/a/P", DoNotGenerateAcw = true)]
	public class P : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/a/P", typeof(P));

		[Register("b")]
		public string B
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("b.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("b.Ljava/lang/String;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("c")]
		public int C
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("c.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("c.I", this, value);
			}
		}

		[Register("d")]
		public bool D
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("d.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("d.Z", this, value);
			}
		}

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected P(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;IZ)V", "")]
		public unsafe P(string p0, string p1, int p2, bool p3)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				ptr[2] = new JniArgumentValue(p2);
				ptr[3] = new JniArgumentValue(p3);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;IZ)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;IZ)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		[Register("a", "(Lorg/json/JSONArray;)Ljava/util/List;", "")]
		public unsafe static IList<P> A(JSONArray p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			IList<P> result = JavaList<P>.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("a.(Lorg/json/JSONArray;)Ljava/util/List;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(p0);
			return result;
		}

		[Register("a", "(Lorg/json/JSONObject;)Lcom/routethis/androidsdk/a/P;", "")]
		public unsafe static P A(JSONObject p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			P result = Java.Lang.Object.GetObject<P>(_members.StaticMethods.InvokeObjectMethod("a.(Lorg/json/JSONObject;)Lcom/routethis/androidsdk/a/P;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(p0);
			return result;
		}
	}
	[Register("com/routethis/androidsdk/a/Q", DoNotGenerateAcw = true)]
	public class Q : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/a/Q", typeof(Q));

		private static Delegate cb_a_Lorg_json_JSONObject_;

		private static Delegate cb_b;

		private static Delegate cb_c;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected Q(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Q()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetA_Lorg_json_JSONObject_Handler()
		{
			if ((object)cb_a_Lorg_json_JSONObject_ == null)
			{
				cb_a_Lorg_json_JSONObject_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_A_Lorg_json_JSONObject_));
			}
			return cb_a_Lorg_json_JSONObject_;
		}

		private static void n_A_Lorg_json_JSONObject_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			Q q = Java.Lang.Object.GetObject<Q>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			JSONObject p = Java.Lang.Object.GetObject<JSONObject>(native_p0, JniHandleOwnership.DoNotTransfer);
			q.A(p);
		}

		[Register("a", "(Lorg/json/JSONObject;)V", "GetA_Lorg_json_JSONObject_Handler")]
		public unsafe virtual void A(JSONObject p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("a.(Lorg/json/JSONObject;)V", this, ptr);
			GC.KeepAlive(p0);
		}

		private static Delegate GetBHandler()
		{
			if ((object)cb_b == null)
			{
				cb_b = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_B));
			}
			return cb_b;
		}

		private static IntPtr n_B(IntPtr jnienv, IntPtr native__this)
		{
			Q q = Java.Lang.Object.GetObject<Q>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaSet<string>.ToLocalJniHandle(q.B());
		}

		[Register("b", "()Ljava/util/Set;", "GetBHandler")]
		public unsafe virtual ICollection<string> B()
		{
			return JavaSet<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("b.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetCHandler()
		{
			if ((object)cb_c == null)
			{
				cb_c = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_C));
			}
			return cb_c;
		}

		private static IntPtr n_C(IntPtr jnienv, IntPtr native__this)
		{
			Q q = Java.Lang.Object.GetObject<Q>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return JavaSet<string>.ToLocalJniHandle(q.C());
		}

		[Register("c", "()Ljava/util/Set;", "GetCHandler")]
		public unsafe virtual ICollection<string> C()
		{
			return JavaSet<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("c.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
}
namespace Com.Routethis.Androidsdk.A.A
{
	[Register("com/routethis/androidsdk/a/a/K", DoNotGenerateAcw = true)]
	public class K : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/a/a/K", typeof(K));

		private static Delegate cb_a;

		private static Delegate cb_a_Lcom_routethis_androidsdk_RouteThisCallback_;

		private static Delegate cb_a_Ljava_lang_String_;

		private static Delegate cb_a_Ljava_lang_String_Ljava_util_UUID_Ljava_lang_String_Lorg_json_JSONObject_Lcom_routethis_androidsdk_RouteThisCallback_;

		private static Delegate cb_a_Ljava_util_UUID_ZLjava_lang_String_;

		private static Delegate cb_a_Ljava_util_UUID_arrayBLcom_routethis_androidsdk_RouteThisCallback_;

		private static Delegate cb_a_Ljava_util_UUID_Lcom_routethis_androidsdk_RouteThisCallback_;

		private static Delegate cb_a_Ljava_util_UUID_Ljava_lang_String_ZZZZZLcom_routethis_androidsdk_RouteThisCallback_;

		private static Delegate cb_a_Ljava_util_UUID_Ljava_lang_String_Lcom_routethis_androidsdk_RouteThisCallback_;

		private static Delegate cb_a_Ljava_util_UUID_Ljava_util_Map_Lcom_routethis_androidsdk_RouteThisCallback_;

		private static Delegate cb_a_Ljava_util_UUID_Ljava_util_Set_ILcom_routethis_androidsdk_RouteThisCallback_;

		private static Delegate cb_b;

		private static Delegate cb_b_Lcom_routethis_androidsdk_RouteThisCallback_;

		private static Delegate cb_b_Ljava_util_UUID_Lcom_routethis_androidsdk_RouteThisCallback_;

		private static Delegate cb_c_Lcom_routethis_androidsdk_RouteThisCallback_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected K(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe K(Context p0, string p1, string p2)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(p1);
			IntPtr intPtr2 = JNIEnv.NewString(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetAHandler()
		{
			if ((object)cb_a == null)
			{
				cb_a = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_A));
			}
			return cb_a;
		}

		private static void n_A(IntPtr jnienv, IntPtr native__this)
		{
			K k = Java.Lang.Object.GetObject<K>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			k.A();
		}

		[Register("a", "()V", "GetAHandler")]
		public unsafe virtual void A()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("a.()V", this, null);
		}

		private static Delegate GetA_Lcom_routethis_androidsdk_RouteThisCallback_Handler()
		{
			if ((object)cb_a_Lcom_routethis_androidsdk_RouteThisCallback_ == null)
			{
				cb_a_Lcom_routethis_androidsdk_RouteThisCallback_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_A_Lcom_routethis_androidsdk_RouteThisCallback_));
			}
			return cb_a_Lcom_routethis_androidsdk_RouteThisCallback_;
		}

		private static void n_A_Lcom_routethis_androidsdk_RouteThisCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			K k = Java.Lang.Object.GetObject<K>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RouteThisCallback p = Java.Lang.Object.GetObject<RouteThisCallback>(native_p0, JniHandleOwnership.DoNotTransfer);
			k.A(p);
		}

		[Register("a", "(Lcom/routethis/androidsdk/RouteThisCallback;)V", "GetA_Lcom_routethis_androidsdk_RouteThisCallback_Handler")]
		public unsafe virtual void A(RouteThisCallback p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("a.(Lcom/routethis/androidsdk/RouteThisCallback;)V", this, ptr);
			GC.KeepAlive(p0);
		}

		private static Delegate GetA_Ljava_lang_String_Handler()
		{
			if ((object)cb_a_Ljava_lang_String_ == null)
			{
				cb_a_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_A_Ljava_lang_String_));
			}
			return cb_a_Ljava_lang_String_;
		}

		private static void n_A_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			K k = Java.Lang.Object.GetObject<K>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			k.A(p);
		}

		[Register("a", "(Ljava/lang/String;)V", "GetA_Ljava_lang_String_Handler")]
		public unsafe virtual void A(string p0)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("a.(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetA_Ljava_lang_String_Ljava_util_UUID_Ljava_lang_String_Lorg_json_JSONObject_Lcom_routethis_androidsdk_RouteThisCallback_Handler()
		{
			if ((object)cb_a_Ljava_lang_String_Ljava_util_UUID_Ljava_lang_String_Lorg_json_JSONObject_Lcom_routethis_androidsdk_RouteThisCallback_ == null)
			{
				cb_a_Ljava_lang_String_Ljava_util_UUID_Ljava_lang_String_Lorg_json_JSONObject_Lcom_routethis_androidsdk_RouteThisCallback_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>(n_A_Ljava_lang_String_Ljava_util_UUID_Ljava_lang_String_Lorg_json_JSONObject_Lcom_routethis_androidsdk_RouteThisCallback_));
			}
			return cb_a_Ljava_lang_String_Ljava_util_UUID_Ljava_lang_String_Lorg_json_JSONObject_Lcom_routethis_androidsdk_RouteThisCallback_;
		}

		private static void n_A_Ljava_lang_String_Ljava_util_UUID_Ljava_lang_String_Lorg_json_JSONObject_Lcom_routethis_androidsdk_RouteThisCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2, IntPtr native_p3, IntPtr native_p4)
		{
			K k = Java.Lang.Object.GetObject<K>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string p = JNIEnv.GetString(native_p0, JniHandleOwnership.DoNotTransfer);
			UUID p2 = Java.Lang.Object.GetObject<UUID>(native_p1, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString(native_p2, JniHandleOwnership.DoNotTransfer);
			JSONObject p4 = Java.Lang.Object.GetObject<JSONObject>(native_p3, JniHandleOwnership.DoNotTransfer);
			RouteThisCallback p5 = Java.Lang.Object.GetObject<RouteThisCallback>(native_p4, JniHandleOwnership.DoNotTransfer);
			k.A(p, p2, p3, p4, p5);
		}

		[Register("a", "(Ljava/lang/String;Ljava/util/UUID;Ljava/lang/String;Lorg/json/JSONObject;Lcom/routethis/androidsdk/RouteThisCallback;)V", "GetA_Ljava_lang_String_Ljava_util_UUID_Ljava_lang_String_Lorg_json_JSONObject_Lcom_routethis_androidsdk_RouteThisCallback_Handler")]
		public unsafe virtual void A(string p0, UUID p1, string p2, JSONObject p3, RouteThisCallback p4)
		{
			IntPtr intPtr = JNIEnv.NewString(p0);
			IntPtr intPtr2 = JNIEnv.NewString(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr2);
				ptr[3] = new JniArgumentValue(p3?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(p4?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("a.(Ljava/lang/String;Ljava/util/UUID;Ljava/lang/String;Lorg/json/JSONObject;Lcom/routethis/androidsdk/RouteThisCallback;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(p1);
				GC.KeepAlive(p3);
				GC.KeepAlive(p4);
			}
		}

		private static Delegate GetA_Ljava_util_UUID_ZLjava_lang_String_Handler()
		{
			if ((object)cb_a_Ljava_util_UUID_ZLjava_lang_String_ == null)
			{
				cb_a_Ljava_util_UUID_ZLjava_lang_String_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, bool, IntPtr>(n_A_Ljava_util_UUID_ZLjava_lang_String_));
			}
			return cb_a_Ljava_util_UUID_ZLjava_lang_String_;
		}

		private static void n_A_Ljava_util_UUID_ZLjava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, bool p1, IntPtr native_p2)
		{
			K k = Java.Lang.Object.GetObject<K>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			UUID p2 = Java.Lang.Object.GetObject<UUID>(native_p0, JniHandleOwnership.DoNotTransfer);
			string p3 = JNIEnv.GetString(native_p2, JniHandleOwnership.DoNotTransfer);
			k.A(p2, p1, p3);
		}

		[Register("a", "(Ljava/util/UUID;ZLjava/lang/String;)V", "GetA_Ljava_util_UUID_ZLjava_lang_String_Handler")]
		public unsafe virtual void A(UUID p0, bool p1, string p2)
		{
			IntPtr intPtr = JNIEnv.NewString(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1);
				ptr[2] = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("a.(Ljava/util/UUID;ZLjava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
			}
		}

		private static Delegate GetA_Ljava_util_UUID_arrayBLcom_routethis_androidsdk_RouteThisCallback_Handler()
		{
			if ((object)cb_a_Ljava_util_UUID_arrayBLcom_routethis_androidsdk_RouteThisCallback_ == null)
			{
				cb_a_Ljava_util_UUID_arrayBLcom_routethis_androidsdk_RouteThisCallback_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>(n_A_Ljava_util_UUID_arrayBLcom_routethis_androidsdk_RouteThisCallback_));
			}
			return cb_a_Ljava_util_UUID_arrayBLcom_routethis_androidsdk_RouteThisCallback_;
		}

		private static void n_A_Ljava_util_UUID_arrayBLcom_routethis_androidsdk_RouteThisCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			K k = Java.Lang.Object.GetObject<K>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			UUID p = Java.Lang.Object.GetObject<UUID>(native_p0, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_p1, JniHandleOwnership.DoNotTransfer, typeof(byte));
			RouteThisCallback p2 = Java.Lang.Object.GetObject<RouteThisCallback>(native_p2, JniHandleOwnership.DoNotTransfer);
			k.A(p, array, p2);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p1);
			}
		}

		[Register("a", "(Ljava/util/UUID;[BLcom/routethis/androidsdk/RouteThisCallback;)V", "GetA_Ljava_util_UUID_arrayBLcom_routethis_androidsdk_RouteThisCallback_Handler")]
		public unsafe virtual void A(UUID p0, byte[] p1, RouteThisCallback p2)
		{
			IntPtr intPtr = JNIEnv.NewArray(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("a.(Ljava/util/UUID;[BLcom/routethis/androidsdk/RouteThisCallback;)V", this, ptr);
			}
			finally
			{
				if (p1 != null)
				{
					JNIEnv.CopyArray(intPtr, p1);
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(p0);
					GC.KeepAlive(p1);
					GC.KeepAlive(p2);
				}
			}
		}

		private static Delegate GetA_Ljava_util_UUID_Lcom_routethis_androidsdk_RouteThisCallback_Handler()
		{
			if ((object)cb_a_Ljava_util_UUID_Lcom_routethis_androidsdk_RouteThisCallback_ == null)
			{
				cb_a_Ljava_util_UUID_Lcom_routethis_androidsdk_RouteThisCallback_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr>(n_A_Ljava_util_UUID_Lcom_routethis_androidsdk_RouteThisCallback_));
			}
			return cb_a_Ljava_util_UUID_Lcom_routethis_androidsdk_RouteThisCallback_;
		}

		private static void n_A_Ljava_util_UUID_Lcom_routethis_androidsdk_RouteThisCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			K k = Java.Lang.Object.GetObject<K>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			UUID p = Java.Lang.Object.GetObject<UUID>(native_p0, JniHandleOwnership.DoNotTransfer);
			RouteThisCallback p2 = Java.Lang.Object.GetObject<RouteThisCallback>(native_p1, JniHandleOwnership.DoNotTransfer);
			k.A(p, p2);
		}

		[Register("a", "(Ljava/util/UUID;Lcom/routethis/androidsdk/RouteThisCallback;)V", "GetA_Ljava_util_UUID_Lcom_routethis_androidsdk_RouteThisCallback_Handler")]
		public unsafe virtual void A(UUID p0, RouteThisCallback p1)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("a.(Ljava/util/UUID;Lcom/routethis/androidsdk/RouteThisCallback;)V", this, ptr);
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}

		private static Delegate GetA_Ljava_util_UUID_Ljava_lang_String_ZZZZZLcom_routethis_androidsdk_RouteThisCallback_Handler()
		{
			if ((object)cb_a_Ljava_util_UUID_Ljava_lang_String_ZZZZZLcom_routethis_androidsdk_RouteThisCallback_ == null)
			{
				cb_a_Ljava_util_UUID_Ljava_lang_String_ZZZZZLcom_routethis_androidsdk_RouteThisCallback_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr, bool, bool, bool, bool, bool, IntPtr>(n_A_Ljava_util_UUID_Ljava_lang_String_ZZZZZLcom_routethis_androidsdk_RouteThisCallback_));
			}
			return cb_a_Ljava_util_UUID_Ljava_lang_String_ZZZZZLcom_routethis_androidsdk_RouteThisCallback_;
		}

		private static void n_A_Ljava_util_UUID_Ljava_lang_String_ZZZZZLcom_routethis_androidsdk_RouteThisCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, bool p2, bool p3, bool p4, bool p5, bool p6, IntPtr native_p7)
		{
			K k = Java.Lang.Object.GetObject<K>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			UUID p7 = Java.Lang.Object.GetObject<UUID>(native_p0, JniHandleOwnership.DoNotTransfer);
			string p8 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			RouteThisCallback p9 = Java.Lang.Object.GetObject<RouteThisCallback>(native_p7, JniHandleOwnership.DoNotTransfer);
			k.A(p7, p8, p2, p3, p4, p5, p6, p9);
		}

		[Register("a", "(Ljava/util/UUID;Ljava/lang/String;ZZZZZLcom/routethis/androidsdk/RouteThisCallback;)V", "GetA_Ljava_util_UUID_Ljava_lang_String_ZZZZZLcom_routethis_androidsdk_RouteThisCallback_Handler")]
		public unsafe virtual void A(UUID p0, string p1, bool p2, bool p3, bool p4, bool p5, bool p6, RouteThisCallback p7)
		{
			IntPtr intPtr = JNIEnv.NewString(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(p2);
				ptr[3] = new JniArgumentValue(p3);
				ptr[4] = new JniArgumentValue(p4);
				ptr[5] = new JniArgumentValue(p5);
				ptr[6] = new JniArgumentValue(p6);
				ptr[7] = new JniArgumentValue(p7?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("a.(Ljava/util/UUID;Ljava/lang/String;ZZZZZLcom/routethis/androidsdk/RouteThisCallback;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
				GC.KeepAlive(p7);
			}
		}

		private static Delegate GetA_Ljava_util_UUID_Ljava_lang_String_Lcom_routethis_androidsdk_RouteThisCallback_Handler()
		{
			if ((object)cb_a_Ljava_util_UUID_Ljava_lang_String_Lcom_routethis_androidsdk_RouteThisCallback_ == null)
			{
				cb_a_Ljava_util_UUID_Ljava_lang_String_Lcom_routethis_androidsdk_RouteThisCallback_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>(n_A_Ljava_util_UUID_Ljava_lang_String_Lcom_routethis_androidsdk_RouteThisCallback_));
			}
			return cb_a_Ljava_util_UUID_Ljava_lang_String_Lcom_routethis_androidsdk_RouteThisCallback_;
		}

		private static void n_A_Ljava_util_UUID_Ljava_lang_String_Lcom_routethis_androidsdk_RouteThisCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			K k = Java.Lang.Object.GetObject<K>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			UUID p = Java.Lang.Object.GetObject<UUID>(native_p0, JniHandleOwnership.DoNotTransfer);
			string p2 = JNIEnv.GetString(native_p1, JniHandleOwnership.DoNotTransfer);
			RouteThisCallback p3 = Java.Lang.Object.GetObject<RouteThisCallback>(native_p2, JniHandleOwnership.DoNotTransfer);
			k.A(p, p2, p3);
		}

		[Register("a", "(Ljava/util/UUID;Ljava/lang/String;Lcom/routethis/androidsdk/RouteThisCallback;)V", "GetA_Ljava_util_UUID_Ljava_lang_String_Lcom_routethis_androidsdk_RouteThisCallback_Handler")]
		public unsafe virtual void A(UUID p0, string p1, RouteThisCallback p2)
		{
			IntPtr intPtr = JNIEnv.NewString(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("a.(Ljava/util/UUID;Ljava/lang/String;Lcom/routethis/androidsdk/RouteThisCallback;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
				GC.KeepAlive(p2);
			}
		}

		private static Delegate GetA_Ljava_util_UUID_Ljava_util_Map_Lcom_routethis_androidsdk_RouteThisCallback_Handler()
		{
			if ((object)cb_a_Ljava_util_UUID_Ljava_util_Map_Lcom_routethis_androidsdk_RouteThisCallback_ == null)
			{
				cb_a_Ljava_util_UUID_Ljava_util_Map_Lcom_routethis_androidsdk_RouteThisCallback_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr, IntPtr>(n_A_Ljava_util_UUID_Ljava_util_Map_Lcom_routethis_androidsdk_RouteThisCallback_));
			}
			return cb_a_Ljava_util_UUID_Ljava_util_Map_Lcom_routethis_androidsdk_RouteThisCallback_;
		}

		private static void n_A_Ljava_util_UUID_Ljava_util_Map_Lcom_routethis_androidsdk_RouteThisCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, IntPtr native_p2)
		{
			K k = Java.Lang.Object.GetObject<K>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			UUID p = Java.Lang.Object.GetObject<UUID>(native_p0, JniHandleOwnership.DoNotTransfer);
			IDictionary<string, string> p2 = JavaDictionary<string, string>.FromJniHandle(native_p1, JniHandleOwnership.DoNotTransfer);
			RouteThisCallback p3 = Java.Lang.Object.GetObject<RouteThisCallback>(native_p2, JniHandleOwnership.DoNotTransfer);
			k.A(p, p2, p3);
		}

		[Register("a", "(Ljava/util/UUID;Ljava/util/Map;Lcom/routethis/androidsdk/RouteThisCallback;)V", "GetA_Ljava_util_UUID_Ljava_util_Map_Lcom_routethis_androidsdk_RouteThisCallback_Handler")]
		public unsafe virtual void A(UUID p0, IDictionary<string, string> p1, RouteThisCallback p2)
		{
			IntPtr intPtr = JavaDictionary<string, string>.ToLocalJniHandle(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("a.(Ljava/util/UUID;Ljava/util/Map;Lcom/routethis/androidsdk/RouteThisCallback;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
			}
		}

		private static Delegate GetA_Ljava_util_UUID_Ljava_util_Set_ILcom_routethis_androidsdk_RouteThisCallback_Handler()
		{
			if ((object)cb_a_Ljava_util_UUID_Ljava_util_Set_ILcom_routethis_androidsdk_RouteThisCallback_ == null)
			{
				cb_a_Ljava_util_UUID_Ljava_util_Set_ILcom_routethis_androidsdk_RouteThisCallback_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr, int, IntPtr>(n_A_Ljava_util_UUID_Ljava_util_Set_ILcom_routethis_androidsdk_RouteThisCallback_));
			}
			return cb_a_Ljava_util_UUID_Ljava_util_Set_ILcom_routethis_androidsdk_RouteThisCallback_;
		}

		private static void n_A_Ljava_util_UUID_Ljava_util_Set_ILcom_routethis_androidsdk_RouteThisCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1, int p2, IntPtr native_p3)
		{
			K k = Java.Lang.Object.GetObject<K>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			UUID p3 = Java.Lang.Object.GetObject<UUID>(native_p0, JniHandleOwnership.DoNotTransfer);
			ICollection<string> p4 = JavaSet<string>.FromJniHandle(native_p1, JniHandleOwnership.DoNotTransfer);
			RouteThisCallback p5 = Java.Lang.Object.GetObject<RouteThisCallback>(native_p3, JniHandleOwnership.DoNotTransfer);
			k.A(p3, p4, p2, p5);
		}

		[Register("a", "(Ljava/util/UUID;Ljava/util/Set;ILcom/routethis/androidsdk/RouteThisCallback;)V", "GetA_Ljava_util_UUID_Ljava_util_Set_ILcom_routethis_androidsdk_RouteThisCallback_Handler")]
		public unsafe virtual void A(UUID p0, ICollection<string> p1, int p2, RouteThisCallback p3)
		{
			IntPtr intPtr = JavaSet<string>.ToLocalJniHandle(p1);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(p2);
				ptr[3] = new JniArgumentValue(p3?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("a.(Ljava/util/UUID;Ljava/util/Set;ILcom/routethis/androidsdk/RouteThisCallback;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
				GC.KeepAlive(p3);
			}
		}

		private static Delegate GetBHandler()
		{
			if ((object)cb_b == null)
			{
				cb_b = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, bool>(n_B));
			}
			return cb_b;
		}

		private static bool n_B(IntPtr jnienv, IntPtr native__this)
		{
			K k = Java.Lang.Object.GetObject<K>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			return k.B();
		}

		[Register("b", "()Z", "GetBHandler")]
		public unsafe virtual bool B()
		{
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("b.()Z", this, null);
		}

		private static Delegate GetB_Lcom_routethis_androidsdk_RouteThisCallback_Handler()
		{
			if ((object)cb_b_Lcom_routethis_androidsdk_RouteThisCallback_ == null)
			{
				cb_b_Lcom_routethis_androidsdk_RouteThisCallback_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_B_Lcom_routethis_androidsdk_RouteThisCallback_));
			}
			return cb_b_Lcom_routethis_androidsdk_RouteThisCallback_;
		}

		private static void n_B_Lcom_routethis_androidsdk_RouteThisCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			K k = Java.Lang.Object.GetObject<K>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RouteThisCallback p = Java.Lang.Object.GetObject<RouteThisCallback>(native_p0, JniHandleOwnership.DoNotTransfer);
			k.B(p);
		}

		[Register("b", "(Lcom/routethis/androidsdk/RouteThisCallback;)V", "GetB_Lcom_routethis_androidsdk_RouteThisCallback_Handler")]
		public unsafe virtual void B(RouteThisCallback p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("b.(Lcom/routethis/androidsdk/RouteThisCallback;)V", this, ptr);
			GC.KeepAlive(p0);
		}

		private static Delegate GetB_Ljava_util_UUID_Lcom_routethis_androidsdk_RouteThisCallback_Handler()
		{
			if ((object)cb_b_Ljava_util_UUID_Lcom_routethis_androidsdk_RouteThisCallback_ == null)
			{
				cb_b_Ljava_util_UUID_Lcom_routethis_androidsdk_RouteThisCallback_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr>(n_B_Ljava_util_UUID_Lcom_routethis_androidsdk_RouteThisCallback_));
			}
			return cb_b_Ljava_util_UUID_Lcom_routethis_androidsdk_RouteThisCallback_;
		}

		private static void n_B_Ljava_util_UUID_Lcom_routethis_androidsdk_RouteThisCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_p1)
		{
			K k = Java.Lang.Object.GetObject<K>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			UUID p = Java.Lang.Object.GetObject<UUID>(native_p0, JniHandleOwnership.DoNotTransfer);
			RouteThisCallback p2 = Java.Lang.Object.GetObject<RouteThisCallback>(native_p1, JniHandleOwnership.DoNotTransfer);
			k.B(p, p2);
		}

		[Register("b", "(Ljava/util/UUID;Lcom/routethis/androidsdk/RouteThisCallback;)V", "GetB_Ljava_util_UUID_Lcom_routethis_androidsdk_RouteThisCallback_Handler")]
		public unsafe virtual void B(UUID p0, RouteThisCallback p1)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("b.(Ljava/util/UUID;Lcom/routethis/androidsdk/RouteThisCallback;)V", this, ptr);
			GC.KeepAlive(p0);
			GC.KeepAlive(p1);
		}

		private static Delegate GetC_Lcom_routethis_androidsdk_RouteThisCallback_Handler()
		{
			if ((object)cb_c_Lcom_routethis_androidsdk_RouteThisCallback_ == null)
			{
				cb_c_Lcom_routethis_androidsdk_RouteThisCallback_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_C_Lcom_routethis_androidsdk_RouteThisCallback_));
			}
			return cb_c_Lcom_routethis_androidsdk_RouteThisCallback_;
		}

		private static void n_C_Lcom_routethis_androidsdk_RouteThisCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			K k = Java.Lang.Object.GetObject<K>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RouteThisCallback p = Java.Lang.Object.GetObject<RouteThisCallback>(native_p0, JniHandleOwnership.DoNotTransfer);
			k.C(p);
		}

		[Register("c", "(Lcom/routethis/androidsdk/RouteThisCallback;)V", "GetC_Lcom_routethis_androidsdk_RouteThisCallback_Handler")]
		public unsafe virtual void C(RouteThisCallback p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("c.(Lcom/routethis/androidsdk/RouteThisCallback;)V", this, ptr);
			GC.KeepAlive(p0);
		}
	}
}
namespace Com.Routethis.Androidsdk.Helpers
{
	[Register("com/routethis/androidsdk/helpers/E", DoNotGenerateAcw = true)]
	public class E : AsyncTask
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/helpers/E", typeof(E));

		private static Delegate cb_a_arrayLjava_lang_Void_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
		{
			throw new NotImplementedException();
		}

		protected E(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe E()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetA_arrayLjava_lang_Void_Handler()
		{
			if ((object)cb_a_arrayLjava_lang_Void_ == null)
			{
				cb_a_arrayLjava_lang_Void_ = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr, IntPtr>(n_A_arrayLjava_lang_Void_));
			}
			return cb_a_arrayLjava_lang_Void_;
		}

		private static IntPtr n_A_arrayLjava_lang_Void_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			E e = Java.Lang.Object.GetObject<E>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Void[] array = (Java.Lang.Void[])JNIEnv.GetArray(native_p0, JniHandleOwnership.DoNotTransfer, typeof(Java.Lang.Void));
			IntPtr result = JNIEnv.ToLocalJniHandle(e.A(array));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p0);
			}
			return result;
		}

		[Register("a", "([Ljava/lang/Void;)Ljava/lang/Boolean;", "GetA_arrayLjava_lang_Void_Handler")]
		protected unsafe virtual Java.Lang.Boolean A(params Java.Lang.Void[] p0)
		{
			IntPtr intPtr = JNIEnv.NewArray(p0);
			Java.Lang.Boolean result;
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				result = Java.Lang.Object.GetObject<Java.Lang.Boolean>(_members.InstanceMethods.InvokeVirtualObjectMethod("a.([Ljava/lang/Void;)Ljava/lang/Boolean;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (p0 != null)
				{
					JNIEnv.CopyArray(intPtr, p0);
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}
			GC.KeepAlive(p0);
			return result;
		}
	}
	[Register("com/routethis/androidsdk/helpers/A", DoNotGenerateAcw = true)]
	public class A : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/helpers/A", typeof(A));

		private static Delegate cb_a;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected A(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetInvokeAHandler()
		{
			if ((object)cb_a == null)
			{
				cb_a = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_InvokeA));
			}
			return cb_a;
		}

		private static void n_InvokeA(IntPtr jnienv, IntPtr native__this)
		{
			A a = Java.Lang.Object.GetObject<A>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			a.InvokeA();
		}

		[Register("a", "()V", "GetInvokeAHandler")]
		public unsafe virtual void InvokeA()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("a.()V", this, null);
		}
	}
	[Register("com/routethis/androidsdk/helpers/C", DoNotGenerateAcw = true)]
	public class C : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/helpers/C", typeof(C));

		private static Delegate cb_a;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected C(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Ljava/util/Collection;Ljava/lang/String;Lcom/routethis/androidsdk/RouteThisCallback;)V", "")]
		public unsafe C(Context p0, ICollection<string> p1, string p2, RouteThisCallback p3)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(p1);
			IntPtr intPtr2 = JNIEnv.NewString(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(intPtr2);
				ptr[3] = new JniArgumentValue(p3?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Ljava/util/Collection;Ljava/lang/String;Lcom/routethis/androidsdk/RouteThisCallback;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Ljava/util/Collection;Ljava/lang/String;Lcom/routethis/androidsdk/RouteThisCallback;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
				GC.KeepAlive(p3);
			}
		}

		private static Delegate GetAHandler()
		{
			if ((object)cb_a == null)
			{
				cb_a = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_A));
			}
			return cb_a;
		}

		private static void n_A(IntPtr jnienv, IntPtr native__this)
		{
			C c = Java.Lang.Object.GetObject<C>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			c.A();
		}

		[Register("a", "()V", "GetAHandler")]
		public unsafe virtual void A()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("a.()V", this, null);
		}
	}
	[Register("com/routethis/androidsdk/helpers/Ca", DoNotGenerateAcw = true)]
	public class Ca : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/helpers/Ca", typeof(Ca));

		private static Delegate cb_a_arrayB;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected Ca(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetA_arrayBHandler()
		{
			if ((object)cb_a_arrayB == null)
			{
				cb_a_arrayB = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_A_arrayB));
			}
			return cb_a_arrayB;
		}

		private static void n_A_arrayB(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			Ca ca = Java.Lang.Object.GetObject<Ca>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_p0, JniHandleOwnership.DoNotTransfer, typeof(byte));
			ca.A(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_p0);
			}
		}

		[Register("a", "([B)V", "GetA_arrayBHandler")]
		public unsafe virtual void A(byte[] p0)
		{
			IntPtr intPtr = JNIEnv.NewArray(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("a.([B)V", this, ptr);
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
	}
	[Register("com/routethis/androidsdk/helpers/Ea", DoNotGenerateAcw = true)]
	public class Ea : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/helpers/Ea", typeof(Ea));

		private static Delegate cb_a;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected Ea(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetAHandler()
		{
			if ((object)cb_a == null)
			{
				cb_a = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_A));
			}
			return cb_a;
		}

		private static void n_A(IntPtr jnienv, IntPtr native__this)
		{
			Ea ea = Java.Lang.Object.GetObject<Ea>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ea.A();
		}

		[Register("a", "()V", "GetAHandler")]
		public unsafe virtual void A()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("a.()V", this, null);
		}
	}
	[Register("com/routethis/androidsdk/helpers/G", DoNotGenerateAcw = true)]
	public class G : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/helpers/G", typeof(G));

		private static Delegate cb_a;

		[Register("d")]
		protected Context D
		{
			get
			{
				return Java.Lang.Object.GetObject<Context>(_members.InstanceFields.GetObjectValue("d.Landroid/content/Context;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("d.Landroid/content/Context;", this, new JniObjectReference(jobject));
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

		protected G(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Lcom/routethis/androidsdk/RouteThisCallback;)V", "")]
		public unsafe G(Context p0, RouteThisCallback p1)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Lcom/routethis/androidsdk/RouteThisCallback;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Lcom/routethis/androidsdk/RouteThisCallback;)V", this, ptr);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
			}
		}

		private static Delegate GetAHandler()
		{
			if ((object)cb_a == null)
			{
				cb_a = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_A));
			}
			return cb_a;
		}

		private static void n_A(IntPtr jnienv, IntPtr native__this)
		{
			G g = Java.Lang.Object.GetObject<G>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			g.A();
		}

		[Register("a", "()V", "GetAHandler")]
		public unsafe virtual void A()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("a.()V", this, null);
		}
	}
	[Register("com/routethis/androidsdk/helpers/H", DoNotGenerateAcw = true)]
	public class H : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/helpers/H", typeof(H));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected H(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("a", "([Ljava/lang/String;)V", "")]
		public unsafe static void A(params string[] p0)
		{
			IntPtr intPtr = JNIEnv.NewArray(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("a.([Ljava/lang/String;)V", ptr);
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

		[Register("b", "([Ljava/lang/String;)V", "")]
		public unsafe static void B(params string[] p0)
		{
			IntPtr intPtr = JNIEnv.NewArray(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("b.([Ljava/lang/String;)V", ptr);
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

		[Register("c", "([Ljava/lang/String;)V", "")]
		public unsafe static void C(params string[] p0)
		{
			IntPtr intPtr = JNIEnv.NewArray(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("c.([Ljava/lang/String;)V", ptr);
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

		[Register("d", "([Ljava/lang/String;)V", "")]
		public unsafe static void D(params string[] p0)
		{
			IntPtr intPtr = JNIEnv.NewArray(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("d.([Ljava/lang/String;)V", ptr);
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

		[Register("e", "([Ljava/lang/String;)V", "")]
		public unsafe static void E(params string[] p0)
		{
			IntPtr intPtr = JNIEnv.NewArray(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.StaticMethods.InvokeVoidMethod("e.([Ljava/lang/String;)V", ptr);
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
	}
	[Register("com/routethis/androidsdk/helpers/Ia", DoNotGenerateAcw = true)]
	public class Ia : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/helpers/Ia", typeof(Ia));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected Ia(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;)V", "")]
		public unsafe Ia(Context p0)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;)V", this, ptr);
				GC.KeepAlive(p0);
			}
		}
	}
	[Register("com/routethis/androidsdk/helpers/D", "", "Com.Routethis.Androidsdk.Helpers.IDInvoker")]
	public interface ID : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("cancel", "()V", "GetCancelHandler:Com.Routethis.Androidsdk.Helpers.IDInvoker, RouteThisAndroidBinding")]
		void Cancel();

		[Register("start", "()V", "GetStartHandler:Com.Routethis.Androidsdk.Helpers.IDInvoker, RouteThisAndroidBinding")]
		void Start();
	}
	[Register("com/routethis/androidsdk/helpers/D", DoNotGenerateAcw = true)]
	internal class IDInvoker : Java.Lang.Object, ID, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/helpers/D", typeof(IDInvoker));

		private IntPtr class_ref;

		private static Delegate cb_cancel;

		private IntPtr id_cancel;

		private static Delegate cb_start;

		private IntPtr id_start;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => class_ref;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public static ID GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ID>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "com.routethis.androidsdk.helpers.D"));
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

		public IDInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetCancelHandler()
		{
			if ((object)cb_cancel == null)
			{
				cb_cancel = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_Cancel));
			}
			return cb_cancel;
		}

		private static void n_Cancel(IntPtr jnienv, IntPtr native__this)
		{
			ID iD = Java.Lang.Object.GetObject<ID>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iD.Cancel();
		}

		public void Cancel()
		{
			if (id_cancel == IntPtr.Zero)
			{
				id_cancel = JNIEnv.GetMethodID(class_ref, "cancel", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_cancel);
		}

		private static Delegate GetStartHandler()
		{
			if ((object)cb_start == null)
			{
				cb_start = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_Start));
			}
			return cb_start;
		}

		private static void n_Start(IntPtr jnienv, IntPtr native__this)
		{
			ID iD = Java.Lang.Object.GetObject<ID>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			iD.Start();
		}

		public void Start()
		{
			if (id_start == IntPtr.Zero)
			{
				id_start = JNIEnv.GetMethodID(class_ref, "start", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_start);
		}
	}
	[Register("com/routethis/androidsdk/helpers/Ka", DoNotGenerateAcw = true)]
	public class Ka : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/helpers/Ka", typeof(Ka));

		[Register("d")]
		public string D
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("d.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("d.Ljava/lang/String;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("e")]
		public string E
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("e.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("e.Ljava/lang/String;", this, new JniObjectReference(jobject));
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

		protected Ka(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/net/DhcpInfo;Landroid/net/wifi/WifiInfo;Ljava/util/Collection;)V", "")]
		public unsafe Ka(DhcpInfo p0, WifiInfo p1, ICollection<ScanResult> p2)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JavaCollection<ScanResult>.ToLocalJniHandle(p2);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/net/DhcpInfo;Landroid/net/wifi/WifiInfo;Ljava/util/Collection;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/net/DhcpInfo;Landroid/net/wifi/WifiInfo;Ljava/util/Collection;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p0);
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
			}
		}

		[Register("a", "(Landroid/content/Context;)Lcom/routethis/androidsdk/helpers/Ka;", "")]
		public unsafe static Ka A(Context p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			Ka result = Java.Lang.Object.GetObject<Ka>(_members.StaticMethods.InvokeObjectMethod("a.(Landroid/content/Context;)Lcom/routethis/androidsdk/helpers/Ka;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(p0);
			return result;
		}

		[Register("a", "(I)Ljava/lang/String;", "")]
		public unsafe static string A(int p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0);
			return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("a.(I)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/routethis/androidsdk/helpers/L", DoNotGenerateAcw = true)]
	public class L : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/helpers/L", typeof(L));

		private static Delegate cb_b;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected L(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetBHandler()
		{
			if ((object)cb_b == null)
			{
				cb_b = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_B));
			}
			return cb_b;
		}

		private static void n_B(IntPtr jnienv, IntPtr native__this)
		{
			L l = Java.Lang.Object.GetObject<L>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			l.B();
		}

		[Register("b", "()V", "GetBHandler")]
		public unsafe virtual void B()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("b.()V", this, null);
		}
	}
	[Register("com/routethis/androidsdk/helpers/NsdWrapper", DoNotGenerateAcw = true)]
	public class NsdWrapper : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/helpers/NsdWrapper", typeof(NsdWrapper));

		private static Delegate cb_a_IZ;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected NsdWrapper(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetA_IZHandler()
		{
			if ((object)cb_a_IZ == null)
			{
				cb_a_IZ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, int, bool>(n_A_IZ));
			}
			return cb_a_IZ;
		}

		private static void n_A_IZ(IntPtr jnienv, IntPtr native__this, int p0, bool p1)
		{
			NsdWrapper nsdWrapper = Java.Lang.Object.GetObject<NsdWrapper>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			nsdWrapper.A(p0, p1);
		}

		[Register("a", "(IZ)V", "GetA_IZHandler")]
		public unsafe virtual void A(int p0, bool p1)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(p0);
			ptr[1] = new JniArgumentValue(p1);
			_members.InstanceMethods.InvokeVirtualVoidMethod("a.(IZ)V", this, ptr);
		}
	}
	[Register("com/routethis/androidsdk/helpers/Q", DoNotGenerateAcw = true)]
	public class Q : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/helpers/Q", typeof(Q));

		private static Delegate cb_a_Lcom_routethis_androidsdk_RouteThisCallback_;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected Q(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;I)V", "")]
		public unsafe Q(string p0, int p1)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;I)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetA_Lcom_routethis_androidsdk_RouteThisCallback_Handler()
		{
			if ((object)cb_a_Lcom_routethis_androidsdk_RouteThisCallback_ == null)
			{
				cb_a_Lcom_routethis_androidsdk_RouteThisCallback_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr>(n_A_Lcom_routethis_androidsdk_RouteThisCallback_));
			}
			return cb_a_Lcom_routethis_androidsdk_RouteThisCallback_;
		}

		private static void n_A_Lcom_routethis_androidsdk_RouteThisCallback_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			Q q = Java.Lang.Object.GetObject<Q>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			RouteThisCallback p = Java.Lang.Object.GetObject<RouteThisCallback>(native_p0, JniHandleOwnership.DoNotTransfer);
			q.A(p);
		}

		[Register("a", "(Lcom/routethis/androidsdk/RouteThisCallback;)V", "GetA_Lcom_routethis_androidsdk_RouteThisCallback_Handler")]
		public unsafe virtual void A(RouteThisCallback p0)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("a.(Lcom/routethis/androidsdk/RouteThisCallback;)V", this, ptr);
			GC.KeepAlive(p0);
		}
	}
	[Register("com/routethis/androidsdk/helpers/V", DoNotGenerateAcw = true)]
	public class V : Java.Lang.Object, ID, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/helpers/V", typeof(V));

		private static Delegate cb_cancel;

		private static Delegate cb_start;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected V(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Lcom/routethis/androidsdk/RouteThisCallback;Lcom/routethis/androidsdk/RouteThisCallback;IIIII)V", "")]
		public unsafe V(string p0, RouteThisCallback p1, RouteThisCallback p2, int p3, int p4, int p5, int p6, int p7)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(p0);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[8];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(p1?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(p2?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(p3);
				ptr[4] = new JniArgumentValue(p4);
				ptr[5] = new JniArgumentValue(p5);
				ptr[6] = new JniArgumentValue(p6);
				ptr[7] = new JniArgumentValue(p7);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Lcom/routethis/androidsdk/RouteThisCallback;Lcom/routethis/androidsdk/RouteThisCallback;IIIII)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Lcom/routethis/androidsdk/RouteThisCallback;Lcom/routethis/androidsdk/RouteThisCallback;IIIII)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(p1);
				GC.KeepAlive(p2);
			}
		}

		private static Delegate GetCancelHandler()
		{
			if ((object)cb_cancel == null)
			{
				cb_cancel = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_Cancel));
			}
			return cb_cancel;
		}

		private static void n_Cancel(IntPtr jnienv, IntPtr native__this)
		{
			V v = Java.Lang.Object.GetObject<V>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			v.Cancel();
		}

		[Register("cancel", "()V", "GetCancelHandler")]
		public unsafe virtual void Cancel()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("cancel.()V", this, null);
		}

		private static Delegate GetStartHandler()
		{
			if ((object)cb_start == null)
			{
				cb_start = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr>(n_Start));
			}
			return cb_start;
		}

		private static void n_Start(IntPtr jnienv, IntPtr native__this)
		{
			V v = Java.Lang.Object.GetObject<V>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			v.Start();
		}

		[Register("start", "()V", "GetStartHandler")]
		public unsafe virtual void Start()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("start.()V", this, null);
		}
	}
	[Register("com/routethis/androidsdk/helpers/X", DoNotGenerateAcw = true)]
	public class X : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("com/routethis/androidsdk/helpers/X", typeof(X));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected X(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("a", "(Landroid/content/Context;Ljava/lang/String;ILjava/lang/String;Lcom/routethis/androidsdk/RouteThisCallback;Lcom/routethis/androidsdk/RouteThisCallback;IIIIILcom/routethis/androidsdk/RouteThisCallback;)V", "")]
		public unsafe static void A(Context p0, string p1, int p2, string p3, RouteThisCallback p4, RouteThisCallback p5, int p6, int p7, int p8, int p9, int p10, RouteThisCallback p11)
		{
			IntPtr intPtr = JNIEnv.NewString(p1);
			IntPtr intPtr2 = JNIEnv.NewString(p3);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[12];
				*ptr = new JniArgumentValue(p0?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(p2);
				ptr[3] = new JniArgumentValue(intPtr2);
				ptr[4] = new JniArgumentValue(p4?.Handle ?? IntPtr.Zero);
				ptr[5] = new JniArgumentValue(p5?.Handle ?? IntPtr.Zero);
				ptr[6] = new JniArgumentValue(p6);
				ptr[7] = new JniArgumentValue(p7);
				ptr[8] = new JniArgumentValue(p8);
				ptr[9] = new JniArgumentValue(p9);
				ptr[10] = new JniArgumentValue(p10);
				ptr[11] = new JniArgumentValue(p11?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("a.(Landroid/content/Context;Ljava/lang/String;ILjava/lang/String;Lcom/routethis/androidsdk/RouteThisCallback;Lcom/routethis/androidsdk/RouteThisCallback;IIIIILcom/routethis/androidsdk/RouteThisCallback;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(p0);
				GC.KeepAlive(p4);
				GC.KeepAlive(p5);
				GC.KeepAlive(p11);
			}
		}
	}
}
