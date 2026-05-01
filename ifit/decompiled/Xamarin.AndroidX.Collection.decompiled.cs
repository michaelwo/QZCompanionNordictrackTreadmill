using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "a0b083e48e5cb48b5f74f95cbf4e400692849c0e")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20210223.1")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "2/23/2021 6:09:48 AM")]
[assembly: LinkerSafe]
[assembly: NamespaceMapping(Java = "androidx.collection", Managed = "AndroidX.Collection")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Xamarin.Android bindings for AndroidX - collection")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.Collection")]
[assembly: AssemblyTitle("Xamarin.AndroidX.Collection")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate int _JniMarshal_PPI_I(IntPtr jnienv, IntPtr klass, int p0);
internal delegate long _JniMarshal_PPI_J(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPI_L(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPI_V(IntPtr jnienv, IntPtr klass, int p0);
internal delegate bool _JniMarshal_PPI_Z(IntPtr jnienv, IntPtr klass, int p0);
internal delegate void _JniMarshal_PPII_V(IntPtr jnienv, IntPtr klass, int p0, int p1);
internal delegate IntPtr _JniMarshal_PPIL_L(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1);
internal delegate void _JniMarshal_PPIL_V(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1);
internal delegate bool _JniMarshal_PPIL_Z(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1);
internal delegate bool _JniMarshal_PPILL_Z(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1, IntPtr p2);
internal delegate int _JniMarshal_PPJ_I(IntPtr jnienv, IntPtr klass, long p0);
internal delegate IntPtr _JniMarshal_PPJ_L(IntPtr jnienv, IntPtr klass, long p0);
internal delegate void _JniMarshal_PPJ_V(IntPtr jnienv, IntPtr klass, long p0);
internal delegate bool _JniMarshal_PPJ_Z(IntPtr jnienv, IntPtr klass, long p0);
internal delegate IntPtr _JniMarshal_PPJL_L(IntPtr jnienv, IntPtr klass, long p0, IntPtr p1);
internal delegate void _JniMarshal_PPJL_V(IntPtr jnienv, IntPtr klass, long p0, IntPtr p1);
internal delegate bool _JniMarshal_PPJL_Z(IntPtr jnienv, IntPtr klass, long p0, IntPtr p1);
internal delegate bool _JniMarshal_PPJLL_Z(IntPtr jnienv, IntPtr klass, long p0, IntPtr p1, IntPtr p2);
internal delegate int _JniMarshal_PPL_I(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
namespace AndroidX.Collection;

[Register("androidx/collection/LongSparseArray", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "E" })]
public class LongSparseArray : Java.Lang.Object, Java.Lang.ICloneable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/collection/LongSparseArray", typeof(LongSparseArray));

	private static Delegate cb_isEmpty;

	private static Delegate cb_append_JLjava_lang_Object_;

	private static Delegate cb_clear;

	private static Delegate cb_clone;

	private static Delegate cb_containsKey_J;

	private static Delegate cb_containsValue_Ljava_lang_Object_;

	private static Delegate cb_delete_J;

	private static Delegate cb_get_J;

	private static Delegate cb_get_JLjava_lang_Object_;

	private static Delegate cb_indexOfKey_J;

	private static Delegate cb_indexOfValue_Ljava_lang_Object_;

	private static Delegate cb_keyAt_I;

	private static Delegate cb_put_JLjava_lang_Object_;

	private static Delegate cb_putAll_Landroidx_collection_LongSparseArray_;

	private static Delegate cb_putIfAbsent_JLjava_lang_Object_;

	private static Delegate cb_remove_J;

	private static Delegate cb_remove_JLjava_lang_Object_;

	private static Delegate cb_removeAt_I;

	private static Delegate cb_replace_JLjava_lang_Object_;

	private static Delegate cb_replace_JLjava_lang_Object_Ljava_lang_Object_;

	private static Delegate cb_setValueAt_ILjava_lang_Object_;

	private static Delegate cb_size;

	private static Delegate cb_valueAt_I;

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

	protected LongSparseArray(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe LongSparseArray()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(I)V", "")]
	public unsafe LongSparseArray(int initialCapacity)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(initialCapacity);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
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
		return Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsEmpty;
	}

	private static Delegate GetAppend_JLjava_lang_Object_Handler()
	{
		if ((object)cb_append_JLjava_lang_Object_ == null)
		{
			cb_append_JLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPJL_V(n_Append_JLjava_lang_Object_));
		}
		return cb_append_JLjava_lang_Object_;
	}

	private static void n_Append_JLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, long key, IntPtr native_value)
	{
		LongSparseArray longSparseArray = Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
		longSparseArray.Append(key, value);
	}

	[Register("append", "(JLjava/lang/Object;)V", "GetAppend_JLjava_lang_Object_Handler")]
	public unsafe virtual void Append(long key, Java.Lang.Object value)
	{
		IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(key);
			ptr[1] = new JniArgumentValue(intPtr);
			_members.InstanceMethods.InvokeVirtualVoidMethod("append.(JLjava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(value);
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
		Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
	}

	[Register("clear", "()V", "GetClearHandler")]
	public unsafe virtual void Clear()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clear.()V", this, null);
	}

	private static Delegate GetCloneHandler()
	{
		if ((object)cb_clone == null)
		{
			cb_clone = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Clone));
		}
		return cb_clone;
	}

	private static IntPtr n_Clone(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clone());
	}

	[Register("clone", "()Landroidx/collection/LongSparseArray;", "GetCloneHandler")]
	public new unsafe virtual LongSparseArray Clone()
	{
		return Java.Lang.Object.GetObject<LongSparseArray>(_members.InstanceMethods.InvokeVirtualObjectMethod("clone.()Landroidx/collection/LongSparseArray;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetContainsKey_JHandler()
	{
		if ((object)cb_containsKey_J == null)
		{
			cb_containsKey_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_Z(n_ContainsKey_J));
		}
		return cb_containsKey_J;
	}

	private static bool n_ContainsKey_J(IntPtr jnienv, IntPtr native__this, long key)
	{
		return Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContainsKey(key);
	}

	[Register("containsKey", "(J)Z", "GetContainsKey_JHandler")]
	public unsafe virtual bool ContainsKey(long key)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(key);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("containsKey.(J)Z", this, ptr);
	}

	private static Delegate GetContainsValue_Ljava_lang_Object_Handler()
	{
		if ((object)cb_containsValue_Ljava_lang_Object_ == null)
		{
			cb_containsValue_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_ContainsValue_Ljava_lang_Object_));
		}
		return cb_containsValue_Ljava_lang_Object_;
	}

	private static bool n_ContainsValue_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_value)
	{
		LongSparseArray longSparseArray = Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
		return longSparseArray.ContainsValue(value);
	}

	[Register("containsValue", "(Ljava/lang/Object;)Z", "GetContainsValue_Ljava_lang_Object_Handler")]
	public unsafe virtual bool ContainsValue(Java.Lang.Object value)
	{
		IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intPtr);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("containsValue.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetDelete_JHandler()
	{
		if ((object)cb_delete_J == null)
		{
			cb_delete_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_V(n_Delete_J));
		}
		return cb_delete_J;
	}

	private static void n_Delete_J(IntPtr jnienv, IntPtr native__this, long key)
	{
		Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Delete(key);
	}

	[Register("delete", "(J)V", "GetDelete_JHandler")]
	public unsafe virtual void Delete(long key)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(key);
		_members.InstanceMethods.InvokeVirtualVoidMethod("delete.(J)V", this, ptr);
	}

	private static Delegate GetGet_JHandler()
	{
		if ((object)cb_get_J == null)
		{
			cb_get_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_Get_J));
		}
		return cb_get_J;
	}

	private static IntPtr n_Get_J(IntPtr jnienv, IntPtr native__this, long key)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Get(key));
	}

	[Register("get", "(J)Ljava/lang/Object;", "GetGet_JHandler")]
	public unsafe virtual Java.Lang.Object Get(long key)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(key);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(J)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGet_JLjava_lang_Object_Handler()
	{
		if ((object)cb_get_JLjava_lang_Object_ == null)
		{
			cb_get_JLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJL_L(n_Get_JLjava_lang_Object_));
		}
		return cb_get_JLjava_lang_Object_;
	}

	private static IntPtr n_Get_JLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, long key, IntPtr native_valueIfKeyNotFound)
	{
		LongSparseArray longSparseArray = Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object valueIfKeyNotFound = Java.Lang.Object.GetObject<Java.Lang.Object>(native_valueIfKeyNotFound, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(longSparseArray.Get(key, valueIfKeyNotFound));
	}

	[Register("get", "(JLjava/lang/Object;)Ljava/lang/Object;", "GetGet_JLjava_lang_Object_Handler")]
	public unsafe virtual Java.Lang.Object Get(long key, Java.Lang.Object valueIfKeyNotFound)
	{
		IntPtr intPtr = JNIEnv.ToLocalJniHandle(valueIfKeyNotFound);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(key);
			ptr[1] = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(JLjava/lang/Object;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(valueIfKeyNotFound);
		}
	}

	private static Delegate GetIndexOfKey_JHandler()
	{
		if ((object)cb_indexOfKey_J == null)
		{
			cb_indexOfKey_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_I(n_IndexOfKey_J));
		}
		return cb_indexOfKey_J;
	}

	private static int n_IndexOfKey_J(IntPtr jnienv, IntPtr native__this, long key)
	{
		return Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IndexOfKey(key);
	}

	[Register("indexOfKey", "(J)I", "GetIndexOfKey_JHandler")]
	public unsafe virtual int IndexOfKey(long key)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(key);
		return _members.InstanceMethods.InvokeVirtualInt32Method("indexOfKey.(J)I", this, ptr);
	}

	private static Delegate GetIndexOfValue_Ljava_lang_Object_Handler()
	{
		if ((object)cb_indexOfValue_Ljava_lang_Object_ == null)
		{
			cb_indexOfValue_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_IndexOfValue_Ljava_lang_Object_));
		}
		return cb_indexOfValue_Ljava_lang_Object_;
	}

	private static int n_IndexOfValue_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_value)
	{
		LongSparseArray longSparseArray = Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
		return longSparseArray.IndexOfValue(value);
	}

	[Register("indexOfValue", "(Ljava/lang/Object;)I", "GetIndexOfValue_Ljava_lang_Object_Handler")]
	public unsafe virtual int IndexOfValue(Java.Lang.Object value)
	{
		IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intPtr);
			return _members.InstanceMethods.InvokeVirtualInt32Method("indexOfValue.(Ljava/lang/Object;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetKeyAt_IHandler()
	{
		if ((object)cb_keyAt_I == null)
		{
			cb_keyAt_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_J(n_KeyAt_I));
		}
		return cb_keyAt_I;
	}

	private static long n_KeyAt_I(IntPtr jnienv, IntPtr native__this, int index)
	{
		return Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).KeyAt(index);
	}

	[Register("keyAt", "(I)J", "GetKeyAt_IHandler")]
	public unsafe virtual long KeyAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return _members.InstanceMethods.InvokeVirtualInt64Method("keyAt.(I)J", this, ptr);
	}

	private static Delegate GetPut_JLjava_lang_Object_Handler()
	{
		if ((object)cb_put_JLjava_lang_Object_ == null)
		{
			cb_put_JLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPJL_V(n_Put_JLjava_lang_Object_));
		}
		return cb_put_JLjava_lang_Object_;
	}

	private static void n_Put_JLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, long key, IntPtr native_value)
	{
		LongSparseArray longSparseArray = Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
		longSparseArray.Put(key, value);
	}

	[Register("put", "(JLjava/lang/Object;)V", "GetPut_JLjava_lang_Object_Handler")]
	public unsafe virtual void Put(long key, Java.Lang.Object value)
	{
		IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(key);
			ptr[1] = new JniArgumentValue(intPtr);
			_members.InstanceMethods.InvokeVirtualVoidMethod("put.(JLjava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetPutAll_Landroidx_collection_LongSparseArray_Handler()
	{
		if ((object)cb_putAll_Landroidx_collection_LongSparseArray_ == null)
		{
			cb_putAll_Landroidx_collection_LongSparseArray_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_PutAll_Landroidx_collection_LongSparseArray_));
		}
		return cb_putAll_Landroidx_collection_LongSparseArray_;
	}

	private static void n_PutAll_Landroidx_collection_LongSparseArray_(IntPtr jnienv, IntPtr native__this, IntPtr native_other)
	{
		LongSparseArray longSparseArray = Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		LongSparseArray other = Java.Lang.Object.GetObject<LongSparseArray>(native_other, JniHandleOwnership.DoNotTransfer);
		longSparseArray.PutAll(other);
	}

	[Register("putAll", "(Landroidx/collection/LongSparseArray;)V", "GetPutAll_Landroidx_collection_LongSparseArray_Handler")]
	public unsafe virtual void PutAll(LongSparseArray other)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("putAll.(Landroidx/collection/LongSparseArray;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(other);
		}
	}

	private static Delegate GetPutIfAbsent_JLjava_lang_Object_Handler()
	{
		if ((object)cb_putIfAbsent_JLjava_lang_Object_ == null)
		{
			cb_putIfAbsent_JLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJL_L(n_PutIfAbsent_JLjava_lang_Object_));
		}
		return cb_putIfAbsent_JLjava_lang_Object_;
	}

	private static IntPtr n_PutIfAbsent_JLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, long key, IntPtr native_value)
	{
		LongSparseArray longSparseArray = Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(longSparseArray.PutIfAbsent(key, value));
	}

	[Register("putIfAbsent", "(JLjava/lang/Object;)Ljava/lang/Object;", "GetPutIfAbsent_JLjava_lang_Object_Handler")]
	public unsafe virtual Java.Lang.Object PutIfAbsent(long key, Java.Lang.Object value)
	{
		IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(key);
			ptr[1] = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("putIfAbsent.(JLjava/lang/Object;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetRemove_JHandler()
	{
		if ((object)cb_remove_J == null)
		{
			cb_remove_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_V(n_Remove_J));
		}
		return cb_remove_J;
	}

	private static void n_Remove_J(IntPtr jnienv, IntPtr native__this, long key)
	{
		Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Remove(key);
	}

	[Register("remove", "(J)V", "GetRemove_JHandler")]
	public unsafe virtual void Remove(long key)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(key);
		_members.InstanceMethods.InvokeVirtualVoidMethod("remove.(J)V", this, ptr);
	}

	private static Delegate GetRemove_JLjava_lang_Object_Handler()
	{
		if ((object)cb_remove_JLjava_lang_Object_ == null)
		{
			cb_remove_JLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJL_Z(n_Remove_JLjava_lang_Object_));
		}
		return cb_remove_JLjava_lang_Object_;
	}

	private static bool n_Remove_JLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, long key, IntPtr native_value)
	{
		LongSparseArray longSparseArray = Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
		return longSparseArray.Remove(key, value);
	}

	[Register("remove", "(JLjava/lang/Object;)Z", "GetRemove_JLjava_lang_Object_Handler")]
	public unsafe virtual bool Remove(long key, Java.Lang.Object value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(key);
			ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("remove.(JLjava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetRemoveAt_IHandler()
	{
		if ((object)cb_removeAt_I == null)
		{
			cb_removeAt_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_RemoveAt_I));
		}
		return cb_removeAt_I;
	}

	private static void n_RemoveAt_I(IntPtr jnienv, IntPtr native__this, int index)
	{
		Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveAt(index);
	}

	[Register("removeAt", "(I)V", "GetRemoveAt_IHandler")]
	public unsafe virtual void RemoveAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		_members.InstanceMethods.InvokeVirtualVoidMethod("removeAt.(I)V", this, ptr);
	}

	private static Delegate GetReplace_JLjava_lang_Object_Handler()
	{
		if ((object)cb_replace_JLjava_lang_Object_ == null)
		{
			cb_replace_JLjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJL_L(n_Replace_JLjava_lang_Object_));
		}
		return cb_replace_JLjava_lang_Object_;
	}

	private static IntPtr n_Replace_JLjava_lang_Object_(IntPtr jnienv, IntPtr native__this, long key, IntPtr native_value)
	{
		LongSparseArray longSparseArray = Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(longSparseArray.Replace(key, value));
	}

	[Register("replace", "(JLjava/lang/Object;)Ljava/lang/Object;", "GetReplace_JLjava_lang_Object_Handler")]
	public unsafe virtual Java.Lang.Object Replace(long key, Java.Lang.Object value)
	{
		IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(key);
			ptr[1] = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("replace.(JLjava/lang/Object;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetReplace_JLjava_lang_Object_Ljava_lang_Object_Handler()
	{
		if ((object)cb_replace_JLjava_lang_Object_Ljava_lang_Object_ == null)
		{
			cb_replace_JLjava_lang_Object_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPJLL_Z(n_Replace_JLjava_lang_Object_Ljava_lang_Object_));
		}
		return cb_replace_JLjava_lang_Object_Ljava_lang_Object_;
	}

	private static bool n_Replace_JLjava_lang_Object_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, long key, IntPtr native_oldValue, IntPtr native_newValue)
	{
		LongSparseArray longSparseArray = Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object oldValue = Java.Lang.Object.GetObject<Java.Lang.Object>(native_oldValue, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object newValue = Java.Lang.Object.GetObject<Java.Lang.Object>(native_newValue, JniHandleOwnership.DoNotTransfer);
		return longSparseArray.Replace(key, oldValue, newValue);
	}

	[Register("replace", "(JLjava/lang/Object;Ljava/lang/Object;)Z", "GetReplace_JLjava_lang_Object_Ljava_lang_Object_Handler")]
	public unsafe virtual bool Replace(long key, Java.Lang.Object oldValue, Java.Lang.Object newValue)
	{
		IntPtr intPtr = JNIEnv.ToLocalJniHandle(oldValue);
		IntPtr intPtr2 = JNIEnv.ToLocalJniHandle(newValue);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(key);
			ptr[1] = new JniArgumentValue(intPtr);
			ptr[2] = new JniArgumentValue(intPtr2);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("replace.(JLjava/lang/Object;Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			GC.KeepAlive(oldValue);
			GC.KeepAlive(newValue);
		}
	}

	private static Delegate GetSetValueAt_ILjava_lang_Object_Handler()
	{
		if ((object)cb_setValueAt_ILjava_lang_Object_ == null)
		{
			cb_setValueAt_ILjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_V(n_SetValueAt_ILjava_lang_Object_));
		}
		return cb_setValueAt_ILjava_lang_Object_;
	}

	private static void n_SetValueAt_ILjava_lang_Object_(IntPtr jnienv, IntPtr native__this, int index, IntPtr native_value)
	{
		LongSparseArray longSparseArray = Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
		longSparseArray.SetValueAt(index, value);
	}

	[Register("setValueAt", "(ILjava/lang/Object;)V", "GetSetValueAt_ILjava_lang_Object_Handler")]
	public unsafe virtual void SetValueAt(int index, Java.Lang.Object value)
	{
		IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(index);
			ptr[1] = new JniArgumentValue(intPtr);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setValueAt.(ILjava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(value);
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
		return Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size();
	}

	[Register("size", "()I", "GetSizeHandler")]
	public unsafe virtual int Size()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("size.()I", this, null);
	}

	private static Delegate GetValueAt_IHandler()
	{
		if ((object)cb_valueAt_I == null)
		{
			cb_valueAt_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_ValueAt_I));
		}
		return cb_valueAt_I;
	}

	private static IntPtr n_ValueAt_I(IntPtr jnienv, IntPtr native__this, int index)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<LongSparseArray>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ValueAt(index));
	}

	[Register("valueAt", "(I)Ljava/lang/Object;", "GetValueAt_IHandler")]
	public unsafe virtual Java.Lang.Object ValueAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("valueAt.(I)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
[Register("androidx/collection/SparseArrayCompat", DoNotGenerateAcw = true)]
[JavaTypeParameters(new string[] { "E" })]
public class SparseArrayCompat : Java.Lang.Object, Java.Lang.ICloneable, IJavaObject, IDisposable, IJavaPeerable
{
	private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/collection/SparseArrayCompat", typeof(SparseArrayCompat));

	private static Delegate cb_isEmpty;

	private static Delegate cb_append_ILjava_lang_Object_;

	private static Delegate cb_clear;

	private static Delegate cb_clone;

	private static Delegate cb_containsKey_I;

	private static Delegate cb_containsValue_Ljava_lang_Object_;

	private static Delegate cb_delete_I;

	private static Delegate cb_get_I;

	private static Delegate cb_get_ILjava_lang_Object_;

	private static Delegate cb_indexOfKey_I;

	private static Delegate cb_indexOfValue_Ljava_lang_Object_;

	private static Delegate cb_keyAt_I;

	private static Delegate cb_put_ILjava_lang_Object_;

	private static Delegate cb_putAll_Landroidx_collection_SparseArrayCompat_;

	private static Delegate cb_putIfAbsent_ILjava_lang_Object_;

	private static Delegate cb_remove_I;

	private static Delegate cb_remove_ILjava_lang_Object_;

	private static Delegate cb_removeAt_I;

	private static Delegate cb_removeAtRange_II;

	private static Delegate cb_replace_ILjava_lang_Object_;

	private static Delegate cb_replace_ILjava_lang_Object_Ljava_lang_Object_;

	private static Delegate cb_setValueAt_ILjava_lang_Object_;

	private static Delegate cb_size;

	private static Delegate cb_valueAt_I;

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

	protected SparseArrayCompat(IntPtr javaReference, JniHandleOwnership transfer)
		: base(javaReference, transfer)
	{
	}

	[Register(".ctor", "()V", "")]
	public unsafe SparseArrayCompat()
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("()V", this, null);
		}
	}

	[Register(".ctor", "(I)V", "")]
	public unsafe SparseArrayCompat(int initialCapacity)
		: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
	{
		if (!(base.Handle != IntPtr.Zero))
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(initialCapacity);
			SetHandle(_members.InstanceMethods.StartCreateInstance("(I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
			_members.InstanceMethods.FinishCreateInstance("(I)V", this, ptr);
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
		return Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsEmpty;
	}

	private static Delegate GetAppend_ILjava_lang_Object_Handler()
	{
		if ((object)cb_append_ILjava_lang_Object_ == null)
		{
			cb_append_ILjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_V(n_Append_ILjava_lang_Object_));
		}
		return cb_append_ILjava_lang_Object_;
	}

	private static void n_Append_ILjava_lang_Object_(IntPtr jnienv, IntPtr native__this, int key, IntPtr native_value)
	{
		SparseArrayCompat sparseArrayCompat = Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
		sparseArrayCompat.Append(key, value);
	}

	[Register("append", "(ILjava/lang/Object;)V", "GetAppend_ILjava_lang_Object_Handler")]
	public unsafe virtual void Append(int key, Java.Lang.Object value)
	{
		IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(key);
			ptr[1] = new JniArgumentValue(intPtr);
			_members.InstanceMethods.InvokeVirtualVoidMethod("append.(ILjava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(value);
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
		Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clear();
	}

	[Register("clear", "()V", "GetClearHandler")]
	public unsafe virtual void Clear()
	{
		_members.InstanceMethods.InvokeVirtualVoidMethod("clear.()V", this, null);
	}

	private static Delegate GetCloneHandler()
	{
		if ((object)cb_clone == null)
		{
			cb_clone = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Clone));
		}
		return cb_clone;
	}

	private static IntPtr n_Clone(IntPtr jnienv, IntPtr native__this)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Clone());
	}

	[Register("clone", "()Landroidx/collection/SparseArrayCompat;", "GetCloneHandler")]
	public new unsafe virtual SparseArrayCompat Clone()
	{
		return Java.Lang.Object.GetObject<SparseArrayCompat>(_members.InstanceMethods.InvokeVirtualObjectMethod("clone.()Landroidx/collection/SparseArrayCompat;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetContainsKey_IHandler()
	{
		if ((object)cb_containsKey_I == null)
		{
			cb_containsKey_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_Z(n_ContainsKey_I));
		}
		return cb_containsKey_I;
	}

	private static bool n_ContainsKey_I(IntPtr jnienv, IntPtr native__this, int key)
	{
		return Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ContainsKey(key);
	}

	[Register("containsKey", "(I)Z", "GetContainsKey_IHandler")]
	public unsafe virtual bool ContainsKey(int key)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(key);
		return _members.InstanceMethods.InvokeVirtualBooleanMethod("containsKey.(I)Z", this, ptr);
	}

	private static Delegate GetContainsValue_Ljava_lang_Object_Handler()
	{
		if ((object)cb_containsValue_Ljava_lang_Object_ == null)
		{
			cb_containsValue_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_ContainsValue_Ljava_lang_Object_));
		}
		return cb_containsValue_Ljava_lang_Object_;
	}

	private static bool n_ContainsValue_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_value)
	{
		SparseArrayCompat sparseArrayCompat = Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
		return sparseArrayCompat.ContainsValue(value);
	}

	[Register("containsValue", "(Ljava/lang/Object;)Z", "GetContainsValue_Ljava_lang_Object_Handler")]
	public unsafe virtual bool ContainsValue(Java.Lang.Object value)
	{
		IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intPtr);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("containsValue.(Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetDelete_IHandler()
	{
		if ((object)cb_delete_I == null)
		{
			cb_delete_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_Delete_I));
		}
		return cb_delete_I;
	}

	private static void n_Delete_I(IntPtr jnienv, IntPtr native__this, int key)
	{
		Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Delete(key);
	}

	[Register("delete", "(I)V", "GetDelete_IHandler")]
	public unsafe virtual void Delete(int key)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(key);
		_members.InstanceMethods.InvokeVirtualVoidMethod("delete.(I)V", this, ptr);
	}

	private static Delegate GetGet_IHandler()
	{
		if ((object)cb_get_I == null)
		{
			cb_get_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_Get_I));
		}
		return cb_get_I;
	}

	private static IntPtr n_Get_I(IntPtr jnienv, IntPtr native__this, int key)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Get(key));
	}

	[Register("get", "(I)Ljava/lang/Object;", "GetGet_IHandler")]
	public unsafe virtual Java.Lang.Object Get(int key)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(key);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(I)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}

	private static Delegate GetGet_ILjava_lang_Object_Handler()
	{
		if ((object)cb_get_ILjava_lang_Object_ == null)
		{
			cb_get_ILjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_L(n_Get_ILjava_lang_Object_));
		}
		return cb_get_ILjava_lang_Object_;
	}

	private static IntPtr n_Get_ILjava_lang_Object_(IntPtr jnienv, IntPtr native__this, int key, IntPtr native_valueIfKeyNotFound)
	{
		SparseArrayCompat sparseArrayCompat = Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object valueIfKeyNotFound = Java.Lang.Object.GetObject<Java.Lang.Object>(native_valueIfKeyNotFound, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(sparseArrayCompat.Get(key, valueIfKeyNotFound));
	}

	[Register("get", "(ILjava/lang/Object;)Ljava/lang/Object;", "GetGet_ILjava_lang_Object_Handler")]
	public unsafe virtual Java.Lang.Object Get(int key, Java.Lang.Object valueIfKeyNotFound)
	{
		IntPtr intPtr = JNIEnv.ToLocalJniHandle(valueIfKeyNotFound);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(key);
			ptr[1] = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(ILjava/lang/Object;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(valueIfKeyNotFound);
		}
	}

	private static Delegate GetIndexOfKey_IHandler()
	{
		if ((object)cb_indexOfKey_I == null)
		{
			cb_indexOfKey_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_I(n_IndexOfKey_I));
		}
		return cb_indexOfKey_I;
	}

	private static int n_IndexOfKey_I(IntPtr jnienv, IntPtr native__this, int key)
	{
		return Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IndexOfKey(key);
	}

	[Register("indexOfKey", "(I)I", "GetIndexOfKey_IHandler")]
	public unsafe virtual int IndexOfKey(int key)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(key);
		return _members.InstanceMethods.InvokeVirtualInt32Method("indexOfKey.(I)I", this, ptr);
	}

	private static Delegate GetIndexOfValue_Ljava_lang_Object_Handler()
	{
		if ((object)cb_indexOfValue_Ljava_lang_Object_ == null)
		{
			cb_indexOfValue_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_IndexOfValue_Ljava_lang_Object_));
		}
		return cb_indexOfValue_Ljava_lang_Object_;
	}

	private static int n_IndexOfValue_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_value)
	{
		SparseArrayCompat sparseArrayCompat = Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
		return sparseArrayCompat.IndexOfValue(value);
	}

	[Register("indexOfValue", "(Ljava/lang/Object;)I", "GetIndexOfValue_Ljava_lang_Object_Handler")]
	public unsafe virtual int IndexOfValue(Java.Lang.Object value)
	{
		IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intPtr);
			return _members.InstanceMethods.InvokeVirtualInt32Method("indexOfValue.(Ljava/lang/Object;)I", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetKeyAt_IHandler()
	{
		if ((object)cb_keyAt_I == null)
		{
			cb_keyAt_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_I(n_KeyAt_I));
		}
		return cb_keyAt_I;
	}

	private static int n_KeyAt_I(IntPtr jnienv, IntPtr native__this, int index)
	{
		return Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).KeyAt(index);
	}

	[Register("keyAt", "(I)I", "GetKeyAt_IHandler")]
	public unsafe virtual int KeyAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return _members.InstanceMethods.InvokeVirtualInt32Method("keyAt.(I)I", this, ptr);
	}

	private static Delegate GetPut_ILjava_lang_Object_Handler()
	{
		if ((object)cb_put_ILjava_lang_Object_ == null)
		{
			cb_put_ILjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_V(n_Put_ILjava_lang_Object_));
		}
		return cb_put_ILjava_lang_Object_;
	}

	private static void n_Put_ILjava_lang_Object_(IntPtr jnienv, IntPtr native__this, int key, IntPtr native_value)
	{
		SparseArrayCompat sparseArrayCompat = Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
		sparseArrayCompat.Put(key, value);
	}

	[Register("put", "(ILjava/lang/Object;)V", "GetPut_ILjava_lang_Object_Handler")]
	public unsafe virtual void Put(int key, Java.Lang.Object value)
	{
		IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(key);
			ptr[1] = new JniArgumentValue(intPtr);
			_members.InstanceMethods.InvokeVirtualVoidMethod("put.(ILjava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetPutAll_Landroidx_collection_SparseArrayCompat_Handler()
	{
		if ((object)cb_putAll_Landroidx_collection_SparseArrayCompat_ == null)
		{
			cb_putAll_Landroidx_collection_SparseArrayCompat_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_PutAll_Landroidx_collection_SparseArrayCompat_));
		}
		return cb_putAll_Landroidx_collection_SparseArrayCompat_;
	}

	private static void n_PutAll_Landroidx_collection_SparseArrayCompat_(IntPtr jnienv, IntPtr native__this, IntPtr native_other)
	{
		SparseArrayCompat sparseArrayCompat = Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		SparseArrayCompat other = Java.Lang.Object.GetObject<SparseArrayCompat>(native_other, JniHandleOwnership.DoNotTransfer);
		sparseArrayCompat.PutAll(other);
	}

	[Register("putAll", "(Landroidx/collection/SparseArrayCompat;)V", "GetPutAll_Landroidx_collection_SparseArrayCompat_Handler")]
	public unsafe virtual void PutAll(SparseArrayCompat other)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
			_members.InstanceMethods.InvokeVirtualVoidMethod("putAll.(Landroidx/collection/SparseArrayCompat;)V", this, ptr);
		}
		finally
		{
			GC.KeepAlive(other);
		}
	}

	private static Delegate GetPutIfAbsent_ILjava_lang_Object_Handler()
	{
		if ((object)cb_putIfAbsent_ILjava_lang_Object_ == null)
		{
			cb_putIfAbsent_ILjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_L(n_PutIfAbsent_ILjava_lang_Object_));
		}
		return cb_putIfAbsent_ILjava_lang_Object_;
	}

	private static IntPtr n_PutIfAbsent_ILjava_lang_Object_(IntPtr jnienv, IntPtr native__this, int key, IntPtr native_value)
	{
		SparseArrayCompat sparseArrayCompat = Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(sparseArrayCompat.PutIfAbsent(key, value));
	}

	[Register("putIfAbsent", "(ILjava/lang/Object;)Ljava/lang/Object;", "GetPutIfAbsent_ILjava_lang_Object_Handler")]
	public unsafe virtual Java.Lang.Object PutIfAbsent(int key, Java.Lang.Object value)
	{
		IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(key);
			ptr[1] = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("putIfAbsent.(ILjava/lang/Object;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetRemove_IHandler()
	{
		if ((object)cb_remove_I == null)
		{
			cb_remove_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_Remove_I));
		}
		return cb_remove_I;
	}

	private static void n_Remove_I(IntPtr jnienv, IntPtr native__this, int key)
	{
		Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Remove(key);
	}

	[Register("remove", "(I)V", "GetRemove_IHandler")]
	public unsafe virtual void Remove(int key)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(key);
		_members.InstanceMethods.InvokeVirtualVoidMethod("remove.(I)V", this, ptr);
	}

	private static Delegate GetRemove_ILjava_lang_Object_Handler()
	{
		if ((object)cb_remove_ILjava_lang_Object_ == null)
		{
			cb_remove_ILjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_Z(n_Remove_ILjava_lang_Object_));
		}
		return cb_remove_ILjava_lang_Object_;
	}

	private static bool n_Remove_ILjava_lang_Object_(IntPtr jnienv, IntPtr native__this, int key, IntPtr native_value)
	{
		SparseArrayCompat sparseArrayCompat = Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
		return sparseArrayCompat.Remove(key, value);
	}

	[Register("remove", "(ILjava/lang/Object;)Z", "GetRemove_ILjava_lang_Object_Handler")]
	public unsafe virtual bool Remove(int key, Java.Lang.Object value)
	{
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(key);
			ptr[1] = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("remove.(ILjava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetRemoveAt_IHandler()
	{
		if ((object)cb_removeAt_I == null)
		{
			cb_removeAt_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_V(n_RemoveAt_I));
		}
		return cb_removeAt_I;
	}

	private static void n_RemoveAt_I(IntPtr jnienv, IntPtr native__this, int index)
	{
		Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveAt(index);
	}

	[Register("removeAt", "(I)V", "GetRemoveAt_IHandler")]
	public unsafe virtual void RemoveAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		_members.InstanceMethods.InvokeVirtualVoidMethod("removeAt.(I)V", this, ptr);
	}

	private static Delegate GetRemoveAtRange_IIHandler()
	{
		if ((object)cb_removeAtRange_II == null)
		{
			cb_removeAtRange_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_V(n_RemoveAtRange_II));
		}
		return cb_removeAtRange_II;
	}

	private static void n_RemoveAtRange_II(IntPtr jnienv, IntPtr native__this, int index, int size)
	{
		Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RemoveAtRange(index, size);
	}

	[Register("removeAtRange", "(II)V", "GetRemoveAtRange_IIHandler")]
	public unsafe virtual void RemoveAtRange(int index, int size)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
		*ptr = new JniArgumentValue(index);
		ptr[1] = new JniArgumentValue(size);
		_members.InstanceMethods.InvokeVirtualVoidMethod("removeAtRange.(II)V", this, ptr);
	}

	private static Delegate GetReplace_ILjava_lang_Object_Handler()
	{
		if ((object)cb_replace_ILjava_lang_Object_ == null)
		{
			cb_replace_ILjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_L(n_Replace_ILjava_lang_Object_));
		}
		return cb_replace_ILjava_lang_Object_;
	}

	private static IntPtr n_Replace_ILjava_lang_Object_(IntPtr jnienv, IntPtr native__this, int key, IntPtr native_value)
	{
		SparseArrayCompat sparseArrayCompat = Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
		return JNIEnv.ToLocalJniHandle(sparseArrayCompat.Replace(key, value));
	}

	[Register("replace", "(ILjava/lang/Object;)Ljava/lang/Object;", "GetReplace_ILjava_lang_Object_Handler")]
	public unsafe virtual Java.Lang.Object Replace(int key, Java.Lang.Object value)
	{
		IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(key);
			ptr[1] = new JniArgumentValue(intPtr);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("replace.(ILjava/lang/Object;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(value);
		}
	}

	private static Delegate GetReplace_ILjava_lang_Object_Ljava_lang_Object_Handler()
	{
		if ((object)cb_replace_ILjava_lang_Object_Ljava_lang_Object_ == null)
		{
			cb_replace_ILjava_lang_Object_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPILL_Z(n_Replace_ILjava_lang_Object_Ljava_lang_Object_));
		}
		return cb_replace_ILjava_lang_Object_Ljava_lang_Object_;
	}

	private static bool n_Replace_ILjava_lang_Object_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, int key, IntPtr native_oldValue, IntPtr native_newValue)
	{
		SparseArrayCompat sparseArrayCompat = Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object oldValue = Java.Lang.Object.GetObject<Java.Lang.Object>(native_oldValue, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object newValue = Java.Lang.Object.GetObject<Java.Lang.Object>(native_newValue, JniHandleOwnership.DoNotTransfer);
		return sparseArrayCompat.Replace(key, oldValue, newValue);
	}

	[Register("replace", "(ILjava/lang/Object;Ljava/lang/Object;)Z", "GetReplace_ILjava_lang_Object_Ljava_lang_Object_Handler")]
	public unsafe virtual bool Replace(int key, Java.Lang.Object oldValue, Java.Lang.Object newValue)
	{
		IntPtr intPtr = JNIEnv.ToLocalJniHandle(oldValue);
		IntPtr intPtr2 = JNIEnv.ToLocalJniHandle(newValue);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(key);
			ptr[1] = new JniArgumentValue(intPtr);
			ptr[2] = new JniArgumentValue(intPtr2);
			return _members.InstanceMethods.InvokeVirtualBooleanMethod("replace.(ILjava/lang/Object;Ljava/lang/Object;)Z", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			GC.KeepAlive(oldValue);
			GC.KeepAlive(newValue);
		}
	}

	private static Delegate GetSetValueAt_ILjava_lang_Object_Handler()
	{
		if ((object)cb_setValueAt_ILjava_lang_Object_ == null)
		{
			cb_setValueAt_ILjava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPIL_V(n_SetValueAt_ILjava_lang_Object_));
		}
		return cb_setValueAt_ILjava_lang_Object_;
	}

	private static void n_SetValueAt_ILjava_lang_Object_(IntPtr jnienv, IntPtr native__this, int index, IntPtr native_value)
	{
		SparseArrayCompat sparseArrayCompat = Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
		Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
		sparseArrayCompat.SetValueAt(index, value);
	}

	[Register("setValueAt", "(ILjava/lang/Object;)V", "GetSetValueAt_ILjava_lang_Object_Handler")]
	public unsafe virtual void SetValueAt(int index, Java.Lang.Object value)
	{
		IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
		try
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(index);
			ptr[1] = new JniArgumentValue(intPtr);
			_members.InstanceMethods.InvokeVirtualVoidMethod("setValueAt.(ILjava/lang/Object;)V", this, ptr);
		}
		finally
		{
			JNIEnv.DeleteLocalRef(intPtr);
			GC.KeepAlive(value);
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
		return Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Size();
	}

	[Register("size", "()I", "GetSizeHandler")]
	public unsafe virtual int Size()
	{
		return _members.InstanceMethods.InvokeVirtualInt32Method("size.()I", this, null);
	}

	private static Delegate GetValueAt_IHandler()
	{
		if ((object)cb_valueAt_I == null)
		{
			cb_valueAt_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_ValueAt_I));
		}
		return cb_valueAt_I;
	}

	private static IntPtr n_ValueAt_I(IntPtr jnienv, IntPtr native__this, int index)
	{
		return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SparseArrayCompat>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ValueAt(index));
	}

	[Register("valueAt", "(I)Ljava/lang/Object;", "GetValueAt_IHandler")]
	public unsafe virtual Java.Lang.Object ValueAt(int index)
	{
		JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
		*ptr = new JniArgumentValue(index);
		return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("valueAt.(I)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
	}
}
