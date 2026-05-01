using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Android.Hardware;
using Android.Runtime;
using Java.Interop;
using Java.Lang;

[assembly: AssemblyTitle("FastAndroidCamera")]
[assembly: AssemblyDescription("Camera preview callbacks with less overhead on Xamarin.Android.")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("APX Labs, Inc.")]
[assembly: AssemblyProduct("")]
[assembly: AssemblyCopyright("2015-2016")]
[assembly: AssemblyTrademark("")]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("2.0.0.0")]
[module: UnverifiableCode]
namespace ApxLabs.FastAndroidCamera;

public static class CameraExtensions
{
	private static IntPtr id_addCallbackBuffer_arrayB;

	private static IntPtr id_setPreviewCallback_Landroid_hardware_Camera_PreviewCallback_;

	private static IntPtr id_setOneShotPreviewCallback_Landroid_hardware_Camera_PreviewCallback_;

	public static void AddCallbackBuffer(this Camera self, FastJavaByteArray callbackBuffer)
	{
		if (id_addCallbackBuffer_arrayB == IntPtr.Zero)
		{
			id_addCallbackBuffer_arrayB = JNIEnv.GetMethodID(self.Class.Handle, "addCallbackBuffer", "([B)V");
		}
		JNIEnv.CallVoidMethod(self.Handle, id_addCallbackBuffer_arrayB, new JValue(callbackBuffer.Handle));
	}

	public static void SetNonMarshalingPreviewCallback(this Camera self, INonMarshalingPreviewCallback cb)
	{
		if (id_setPreviewCallback_Landroid_hardware_Camera_PreviewCallback_ == IntPtr.Zero)
		{
			id_setPreviewCallback_Landroid_hardware_Camera_PreviewCallback_ = JNIEnv.GetMethodID(self.Class.Handle, "setPreviewCallbackWithBuffer", "(Landroid/hardware/Camera$PreviewCallback;)V");
		}
		JNIEnv.CallVoidMethod(self.Handle, id_setPreviewCallback_Landroid_hardware_Camera_PreviewCallback_, new JValue(cb));
	}

	public static void SetNonMarshalingOneShotPreviewCallback(this Camera self, INonMarshalingPreviewCallback cb)
	{
		if (id_setOneShotPreviewCallback_Landroid_hardware_Camera_PreviewCallback_ == IntPtr.Zero)
		{
			id_setOneShotPreviewCallback_Landroid_hardware_Camera_PreviewCallback_ = JNIEnv.GetMethodID(self.Class.Handle, "setOneShotPreviewCallback", "(Landroid/hardware/Camera$PreviewCallback;)V");
		}
		JNIEnv.CallVoidMethod(self.Handle, id_setOneShotPreviewCallback_Landroid_hardware_Camera_PreviewCallback_, new JValue(cb));
	}
}
[Register("android/hardware/Camera$PreviewCallback", "", "ApxLabs.FastAndroidCamera.INonMarshalingPreviewCallbackInvoker")]
public interface INonMarshalingPreviewCallback : IJavaObject, IDisposable
{
	[Register("onPreviewFrame", "([BLandroid/hardware/Camera;)V", "GetOnPreviewFrame_arrayBLandroid_hardware_Camera_Handler:ApxLabs.FastAndroidCamera.INonMarshalingPreviewCallbackInvoker, FastAndroidCamera, Version=0.0.0.0, Culture=neutral, PublicKeyToken=null")]
	void OnPreviewFrame(IntPtr data, Camera camera);
}
[Register("android/hardware/Camera$PreviewCallback", DoNotGenerateAcw = true)]
internal class INonMarshalingPreviewCallbackInvoker : Java.Lang.Object, INonMarshalingPreviewCallback, IJavaObject, IDisposable
{
	private static IntPtr java_class_ref = JNIEnv.FindClass("android/hardware/Camera$PreviewCallback");

	private IntPtr class_ref;

	private static Delegate cb_onPreviewFrame_arrayBLandroid_hardware_Camera_;

	private IntPtr id_onPreviewFrame_arrayBLandroid_hardware_Camera_;

	protected override IntPtr ThresholdClass => class_ref;

	protected override Type ThresholdType => typeof(INonMarshalingPreviewCallbackInvoker);

	public INonMarshalingPreviewCallbackInvoker(IntPtr handle, JniHandleOwnership transfer)
		: base(Validate(handle), transfer)
	{
		IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
		class_ref = JNIEnv.NewGlobalRef(objectClass);
		JNIEnv.DeleteLocalRef(objectClass);
	}

	public static INonMarshalingPreviewCallback GetObject(IntPtr handle, JniHandleOwnership transfer)
	{
		return Java.Lang.Object.GetObject<INonMarshalingPreviewCallback>(handle, transfer);
	}

	private static IntPtr Validate(IntPtr handle)
	{
		if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
		{
			throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "android.hardware.Camera.PreviewCallback"));
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

	private static Delegate GetOnPreviewFrame_arrayBLandroid_hardware_Camera_Handler()
	{
		if ((object)cb_onPreviewFrame_arrayBLandroid_hardware_Camera_ == null)
		{
			cb_onPreviewFrame_arrayBLandroid_hardware_Camera_ = JNINativeWrapper.CreateDelegate(new Action<IntPtr, IntPtr, IntPtr, IntPtr>(n_OnPreviewFrame_arrayBLandroid_hardware_Camera_));
		}
		return cb_onPreviewFrame_arrayBLandroid_hardware_Camera_;
	}

	private static void n_OnPreviewFrame_arrayBLandroid_hardware_Camera_(IntPtr jnienv, IntPtr native__this, IntPtr native_data, IntPtr native_camera)
	{
		INonMarshalingPreviewCallback nonMarshalingPreviewCallback = Java.Lang.Object.GetObject<INonMarshalingPreviewCallback>(native__this, JniHandleOwnership.DoNotTransfer);
		Camera camera = Java.Lang.Object.GetObject<Camera>(native_camera, JniHandleOwnership.DoNotTransfer);
		nonMarshalingPreviewCallback.OnPreviewFrame(native_data, camera);
	}

	public void OnPreviewFrame(IntPtr data, Camera camera)
	{
		if (id_onPreviewFrame_arrayBLandroid_hardware_Camera_ == IntPtr.Zero)
		{
			id_onPreviewFrame_arrayBLandroid_hardware_Camera_ = JNIEnv.GetMethodID(class_ref, "onPreviewFrame", "([BLandroid/hardware/Camera;)V");
		}
		JNIEnv.CallVoidMethod(base.Handle, id_onPreviewFrame_arrayBLandroid_hardware_Camera_, new JValue(data), new JValue(camera));
	}
}
public sealed class FastJavaByteArray : IList<byte>, IDisposable, ICollection<byte>, IEnumerable<byte>, IEnumerable
{
	private JniObjectReference _javaRef;

	public int Count { get; private set; }

	public bool IsReadOnly { get; private set; }

	public unsafe byte this[int index]
	{
		get
		{
			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			return Raw[index];
		}
		set
		{
			if (IsReadOnly)
			{
				throw new NotSupportedException("This FastJavaByteArray is read-only");
			}
			if (index < 0 || index >= Count)
			{
				throw new ArgumentOutOfRangeException();
			}
			Raw[index] = value;
		}
	}

	public unsafe byte* Raw { get; private set; }

	public IntPtr Handle => _javaRef.Handle;

	public unsafe FastJavaByteArray(int length)
	{
		if (length <= 0)
		{
			throw new ArgumentOutOfRangeException();
		}
		JniObjectReference jniObjectReference = JniEnvironment.Arrays.NewByteArray(length);
		if (!jniObjectReference.IsValid)
		{
			throw new OutOfMemoryException();
		}
		_javaRef = jniObjectReference.NewGlobalRef();
		Count = length;
		bool flag = false;
		Raw = (byte*)JniEnvironment.Arrays.GetByteArrayElements(_javaRef, &flag);
	}

	public unsafe FastJavaByteArray(IntPtr handle, bool readOnly = true)
	{
		if (handle == IntPtr.Zero)
		{
			throw new ArgumentNullException("handle");
		}
		IsReadOnly = readOnly;
		_javaRef = new JniObjectReference(handle).NewGlobalRef();
		Count = JniEnvironment.Arrays.GetArrayLength(_javaRef);
		bool flag = false;
		Raw = (byte*)JniEnvironment.Arrays.GetByteArrayElements(_javaRef, &flag);
	}

	~FastJavaByteArray()
	{
		Dispose(disposing: false);
	}

	public void Dispose()
	{
		Dispose(disposing: true);
		GC.SuppressFinalize(this);
	}

	private unsafe void Dispose(bool disposing)
	{
		if (_javaRef.IsValid)
		{
			JniEnvironment.Arrays.ReleaseByteArrayElements(_javaRef, (sbyte*)Raw, JniReleaseArrayElementsMode.Default);
			if (disposing)
			{
				JniObjectReference.Dispose(ref _javaRef);
			}
		}
	}

	public void Add(byte item)
	{
		throw new NotSupportedException("FastJavaByteArray is fixed length");
	}

	public void Clear()
	{
		throw new NotSupportedException("FastJavaByteArray is fixed length");
	}

	public bool Contains(byte item)
	{
		return IndexOf(item) >= 0;
	}

	public unsafe void CopyTo(byte[] array, int arrayIndex)
	{
		Marshal.Copy(new IntPtr(Raw), array, arrayIndex, System.Math.Min(Count, array.Length - arrayIndex));
	}

	[DebuggerHidden]
	public IEnumerator<byte> GetEnumerator()
	{
		return new FastJavaByteArrayEnumerator(this);
	}

	[DebuggerHidden]
	IEnumerator IEnumerable.GetEnumerator()
	{
		return new FastJavaByteArrayEnumerator(this);
	}

	public unsafe int IndexOf(byte item)
	{
		for (int i = 0; i < Count; i++)
		{
			byte b = Raw[i];
			if (b == item)
			{
				return i;
			}
		}
		return -1;
	}

	public void Insert(int index, byte item)
	{
		throw new NotSupportedException("FastJavaByteArray is fixed length");
	}

	public bool Remove(byte item)
	{
		throw new NotSupportedException("FastJavaByteArray is fixed length");
	}

	public void RemoveAt(int index)
	{
		throw new NotSupportedException("FastJavaByteArray is fixed length");
	}
}
internal class FastJavaByteArrayEnumerator : IEnumerator<byte>, IDisposable, IEnumerator
{
	private FastJavaByteArray _arr;

	private int _idx;

	unsafe object IEnumerator.Current
	{
		get
		{
			byte b = _arr.Raw[_idx];
			return b;
		}
	}

	public unsafe byte Current => _arr.Raw[_idx];

	internal FastJavaByteArrayEnumerator(FastJavaByteArray arr)
	{
		if (arr == null)
		{
			throw new ArgumentNullException();
		}
		_arr = arr;
		_idx = 0;
	}

	public void Dispose()
	{
	}

	public bool MoveNext()
	{
		if (_idx > _arr.Count)
		{
			return false;
		}
		_idx++;
		return _idx < _arr.Count;
	}

	public void Reset()
	{
		_idx = 0;
	}
}
