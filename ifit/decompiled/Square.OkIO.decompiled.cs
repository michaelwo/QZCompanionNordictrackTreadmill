using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.Runtime;
using Java.IO;
using Java.Interop;
using Java.Lang;
using Java.Lang.Annotation;
using Java.Net;
using Java.Nio;
using Java.Nio.Channels;
using Java.Nio.Charset;
using Java.Nio.FileNio;
using Java.Security;
using Java.Util;
using Java.Util.Concurrent;
using Java.Util.Zip;
using Javax.Crypto;
using Kotlin.Collections;
using Kotlin.Jvm.Functions;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: NamespaceMapping(Java = "okio", Managed = "Square.OkIO")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("OkIO is a new library that complements Java.IO and Java.Nio to make it much easier to access, store, and process your data.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Square.OkIO")]
[assembly: AssemblyTitle("Square.OkIO")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/XamarinComponents")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate sbyte _JniMarshal_PP_B(IntPtr jnienv, IntPtr klass);
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate long _JniMarshal_PP_J(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate short _JniMarshal_PP_S(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate long _JniMarshal_PPB_J(IntPtr jnienv, IntPtr klass, sbyte p0);
internal delegate long _JniMarshal_PPBJ_J(IntPtr jnienv, IntPtr klass, sbyte p0, long p1);
internal delegate long _JniMarshal_PPBJJ_J(IntPtr jnienv, IntPtr klass, sbyte p0, long p1, long p2);
internal delegate IntPtr _JniMarshal_PPI_L(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPII_L(IntPtr jnienv, IntPtr klass, int p0, int p1);
internal delegate bool _JniMarshal_PPILII_Z(IntPtr jnienv, IntPtr klass, int p0, IntPtr p1, int p2, int p3);
internal delegate IntPtr _JniMarshal_PPJ_L(IntPtr jnienv, IntPtr klass, long p0);
internal delegate void _JniMarshal_PPJ_V(IntPtr jnienv, IntPtr klass, long p0);
internal delegate bool _JniMarshal_PPJ_Z(IntPtr jnienv, IntPtr klass, long p0);
internal delegate IntPtr _JniMarshal_PPJL_L(IntPtr jnienv, IntPtr klass, long p0, IntPtr p1);
internal delegate bool _JniMarshal_PPJL_Z(IntPtr jnienv, IntPtr klass, long p0, IntPtr p1);
internal delegate bool _JniMarshal_PPJLII_Z(IntPtr jnienv, IntPtr klass, long p0, IntPtr p1, int p2, int p3);
internal delegate int _JniMarshal_PPL_I(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate long _JniMarshal_PPL_J(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate int _JniMarshal_PPLI_I(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1);
internal delegate int _JniMarshal_PPLII_I(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2);
internal delegate IntPtr _JniMarshal_PPLII_L(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2);
internal delegate IntPtr _JniMarshal_PPLIIL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, int p1, int p2, IntPtr p3);
internal delegate long _JniMarshal_PPLJ_J(IntPtr jnienv, IntPtr klass, IntPtr p0, long p1);
internal delegate IntPtr _JniMarshal_PPLJ_L(IntPtr jnienv, IntPtr klass, IntPtr p0, long p1);
internal delegate void _JniMarshal_PPLJ_V(IntPtr jnienv, IntPtr klass, IntPtr p0, long p1);
internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		private static string[] package_okio_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[1] { "okio" }, new Converter<string, Type>[1] { lookup_okio_package });
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

		private static Type lookup_okio_package(string klass)
		{
			if (package_okio_mappings == null)
			{
				package_okio_mappings = new string[27]
				{
					"okio/AsyncTimeout:Square.OkIO.AsyncTimeout", "okio/AsyncTimeout$Companion:Square.OkIO.AsyncTimeout/CompanionStatic", "okio/Buffer:Square.OkIO.OkBuffer", "okio/Buffer$UnsafeCursor:Square.OkIO.OkBuffer/UnsafeCursor", "okio/ByteString:Square.OkIO.ByteString", "okio/ByteString$Companion:Square.OkIO.ByteString/CompanionStatic", "okio/CipherSink:Square.OkIO.CipherSink", "okio/CipherSource:Square.OkIO.CipherSource", "okio/DeflaterSink:Square.OkIO.DeflaterSink", "okio/ForwardingSink:Square.OkIO.ForwardingSink",
					"okio/ForwardingSource:Square.OkIO.ForwardingSource", "okio/ForwardingTimeout:Square.OkIO.ForwardingTimeout", "okio/GzipSink:Square.OkIO.GzipSink", "okio/GzipSource:Square.OkIO.GzipSource", "okio/HashingSink:Square.OkIO.HashingSink", "okio/HashingSink$Companion:Square.OkIO.HashingSink/CompanionStatic", "okio/HashingSource:Square.OkIO.HashingSource", "okio/HashingSource$Companion:Square.OkIO.HashingSource/CompanionStatic", "okio/InflaterSource:Square.OkIO.InflaterSource", "okio/Okio:Square.OkIO.OkIO",
					"okio/Options:Square.OkIO.Options", "okio/Options$Companion:Square.OkIO.Options/CompanionStatic", "okio/Pipe:Square.OkIO.Pipe", "okio/Throttler:Square.OkIO.Throttler", "okio/Timeout:Square.OkIO.Timeout", "okio/Timeout$Companion:Square.OkIO.Timeout/CompanionStatic", "okio/Utf8:Square.OkIO.Utf8"
				};
			}
			return Lookup(package_okio_mappings, klass);
		}
	}
}
namespace Square.OkIO
{
	[Register("okio/Buffer", DoNotGenerateAcw = true)]
	public sealed class OkBuffer : Java.Lang.Object, Java.Lang.ICloneable, IJavaObject, IDisposable, IJavaPeerable, IByteChannel, IReadableByteChannel, IChannel, ICloseable, IWritableByteChannel, IBufferedSink, ISink, IFlushable, IBufferedSource, ISource
	{
		[Register("okio/Buffer$UnsafeCursor", DoNotGenerateAcw = true)]
		public sealed class UnsafeCursor : Java.Lang.Object, ICloseable, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("okio/Buffer$UnsafeCursor", typeof(UnsafeCursor));

			[Register("buffer")]
			public OkBuffer Buffer
			{
				get
				{
					return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceFields.GetObjectValue("buffer.Lokio/Buffer;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
					try
					{
						_members.InstanceFields.SetValue("buffer.Lokio/Buffer;", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("data")]
			public IList<byte> Data
			{
				get
				{
					return Android.Runtime.JavaArray<byte>.FromJniHandle(_members.InstanceFields.GetObjectValue("data.[B", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = Android.Runtime.JavaArray<byte>.ToLocalJniHandle(value);
					try
					{
						_members.InstanceFields.SetValue("data.[B", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("end")]
			public int End
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("end.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("end.I", this, value);
				}
			}

			[Register("offset")]
			public long Offset
			{
				get
				{
					return _members.InstanceFields.GetInt64Value("offset.J", this);
				}
				set
				{
					_members.InstanceFields.SetValue("offset.J", this, value);
				}
			}

			[Register("readWrite")]
			public bool ReadWrite
			{
				get
				{
					return _members.InstanceFields.GetBooleanValue("readWrite.Z", this);
				}
				set
				{
					_members.InstanceFields.SetValue("readWrite.Z", this, value);
				}
			}

			[Register("start")]
			public int Start
			{
				get
				{
					return _members.InstanceFields.GetInt32Value("start.I", this);
				}
				set
				{
					_members.InstanceFields.SetValue("start.I", this, value);
				}
			}

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal UnsafeCursor(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe UnsafeCursor()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			[Register("close", "()V", "")]
			public unsafe void Close()
			{
				_members.InstanceMethods.InvokeAbstractVoidMethod("close.()V", this, null);
			}

			[Register("expandBuffer", "(I)J", "")]
			public unsafe long ExpandBuffer(int minByteCount)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(minByteCount);
				return _members.InstanceMethods.InvokeNonvirtualInt64Method("expandBuffer.(I)J", this, ptr);
			}

			[Register("next", "()I", "")]
			public unsafe int Next()
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("next.()I", this, null);
			}

			[Register("resizeBuffer", "(J)J", "")]
			public unsafe long ResizeBuffer(long newSize)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(newSize);
				return _members.InstanceMethods.InvokeNonvirtualInt64Method("resizeBuffer.(J)J", this, ptr);
			}

			[Register("seek", "(J)I", "")]
			public unsafe int Seek(long offset)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(offset);
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("seek.(J)I", this, ptr);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/Buffer", typeof(OkBuffer));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe OkBuffer Buffer
		{
			[Register("buffer", "()Lokio/Buffer;", "")]
			get
			{
				return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("buffer.()Lokio/Buffer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool IsOpen
		{
			[Register("isOpen", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isOpen.()Z", this, null);
			}
		}

		public unsafe Stream OutputStream
		{
			[Register("outputStream", "()Ljava/io/OutputStream;", "")]
			get
			{
				return OutputStreamInvoker.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("outputStream.()Ljava/io/OutputStream;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		IBufferedSink IBufferedSink.Emit()
		{
			return Emit();
		}

		IBufferedSink IBufferedSink.EmitCompleteSegments()
		{
			return EmitCompleteSegments();
		}

		IBufferedSink IBufferedSink.Write(ISource source, long byteCount)
		{
			return Write(source, byteCount);
		}

		IBufferedSink IBufferedSink.Write(byte[] source)
		{
			return Write(source);
		}

		IBufferedSink IBufferedSink.Write(byte[] source, int offset, int byteCount)
		{
			return Write(source, offset, byteCount);
		}

		IBufferedSink IBufferedSink.Write(ByteString byteString)
		{
			return Write(byteString);
		}

		IBufferedSink IBufferedSink.Write(ByteString byteString, int offset, int byteCount)
		{
			return Write(byteString, offset, byteCount);
		}

		IBufferedSink IBufferedSink.WriteByte(int b)
		{
			return WriteByte(b);
		}

		IBufferedSink IBufferedSink.WriteDecimalLong(long v)
		{
			return WriteDecimalLong(v);
		}

		IBufferedSink IBufferedSink.WriteHexadecimalUnsignedLong(long v)
		{
			return WriteHexadecimalUnsignedLong(v);
		}

		IBufferedSink IBufferedSink.WriteInt(int i)
		{
			return WriteInt(i);
		}

		IBufferedSink IBufferedSink.WriteIntLe(int i)
		{
			return WriteIntLe(i);
		}

		IBufferedSink IBufferedSink.WriteLong(long v)
		{
			return WriteLong(v);
		}

		IBufferedSink IBufferedSink.WriteLongLe(long v)
		{
			return WriteLongLe(v);
		}

		IBufferedSink IBufferedSink.WriteShort(int s)
		{
			return WriteShort(s);
		}

		IBufferedSink IBufferedSink.WriteShortLe(int s)
		{
			return WriteShortLe(s);
		}

		IBufferedSink IBufferedSink.WriteString(string str, int beginIndex, int endIndex, Charset charset)
		{
			return WriteString(str, beginIndex, endIndex, charset);
		}

		IBufferedSink IBufferedSink.WriteString(string str, Charset charset)
		{
			return WriteString(str, charset);
		}

		IBufferedSink IBufferedSink.WriteUtf8(string str)
		{
			return WriteUtf8(str);
		}

		IBufferedSink IBufferedSink.WriteUtf8(string str, int beginIndex, int endIndex)
		{
			return WriteUtf8(str, beginIndex, endIndex);
		}

		IBufferedSink IBufferedSink.WriteUtf8CodePoint(int codePoint)
		{
			return WriteUtf8CodePoint(codePoint);
		}

		internal OkBuffer(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe OkBuffer()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("clear", "()V", "")]
		public unsafe void Clear()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("clear.()V", this, null);
		}

		[Register("clone", "()Lokio/Buffer;", "")]
		public new unsafe OkBuffer Clone()
		{
			return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("clone.()Lokio/Buffer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("close", "()V", "")]
		public unsafe void Close()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("close.()V", this, null);
		}

		[Register("completeSegmentByteCount", "()J", "")]
		public unsafe long CompleteSegmentByteCount()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt64Method("completeSegmentByteCount.()J", this, null);
		}

		[Register("copy", "()Lokio/Buffer;", "")]
		public unsafe OkBuffer Copy()
		{
			return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.()Lokio/Buffer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("copyTo", "(Ljava/io/OutputStream;)Lokio/Buffer;", "")]
		public unsafe OkBuffer CopyTo(Stream @out)
		{
			IntPtr intPtr = OutputStreamAdapter.ToLocalJniHandle(@out);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copyTo.(Ljava/io/OutputStream;)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(@out);
			}
		}

		[Register("copyTo", "(Ljava/io/OutputStream;J)Lokio/Buffer;", "")]
		public unsafe OkBuffer CopyTo(Stream @out, long offset)
		{
			IntPtr intPtr = OutputStreamAdapter.ToLocalJniHandle(@out);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(offset);
				return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copyTo.(Ljava/io/OutputStream;J)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(@out);
			}
		}

		[Register("copyTo", "(Ljava/io/OutputStream;JJ)Lokio/Buffer;", "")]
		public unsafe OkBuffer CopyTo(Stream @out, long offset, long byteCount)
		{
			IntPtr intPtr = OutputStreamAdapter.ToLocalJniHandle(@out);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(offset);
				ptr[2] = new JniArgumentValue(byteCount);
				return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copyTo.(Ljava/io/OutputStream;JJ)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(@out);
			}
		}

		[Register("copyTo", "(Lokio/Buffer;J)Lokio/Buffer;", "")]
		public unsafe OkBuffer CopyTo(OkBuffer @out, long offset)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(offset);
				return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copyTo.(Lokio/Buffer;J)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}

		[Register("copyTo", "(Lokio/Buffer;JJ)Lokio/Buffer;", "")]
		public unsafe OkBuffer CopyTo(OkBuffer @out, long offset, long byteCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(@out?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(offset);
				ptr[2] = new JniArgumentValue(byteCount);
				return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copyTo.(Lokio/Buffer;JJ)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(@out);
			}
		}

		[Register("emit", "()Lokio/Buffer;", "")]
		public unsafe OkBuffer Emit()
		{
			return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("emit.()Lokio/Buffer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("emitCompleteSegments", "()Lokio/Buffer;", "")]
		public unsafe OkBuffer EmitCompleteSegments()
		{
			return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("emitCompleteSegments.()Lokio/Buffer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("exhausted", "()Z", "")]
		public unsafe bool Exhausted()
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("exhausted.()Z", this, null);
		}

		[Register("flush", "()V", "")]
		public unsafe void Flush()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("flush.()V", this, null);
		}

		[Register("getBuffer", "()Lokio/Buffer;", "")]
		public unsafe OkBuffer GetBuffer()
		{
			return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("getBuffer.()Lokio/Buffer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("getByte", "(J)B", "")]
		public unsafe sbyte GetByte(long pos)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(pos);
			return _members.InstanceMethods.InvokeNonvirtualSByteMethod("getByte.(J)B", this, ptr);
		}

		[Register("hmacSha1", "(Lokio/ByteString;)Lokio/ByteString;", "")]
		public unsafe ByteString HmacSha1(ByteString key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(key?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("hmacSha1.(Lokio/ByteString;)Lokio/ByteString;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(key);
			}
		}

		[Register("hmacSha256", "(Lokio/ByteString;)Lokio/ByteString;", "")]
		public unsafe ByteString HmacSha256(ByteString key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(key?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("hmacSha256.(Lokio/ByteString;)Lokio/ByteString;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(key);
			}
		}

		[Register("hmacSha512", "(Lokio/ByteString;)Lokio/ByteString;", "")]
		public unsafe ByteString HmacSha512(ByteString key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(key?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("hmacSha512.(Lokio/ByteString;)Lokio/ByteString;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(key);
			}
		}

		[Register("indexOf", "(B)J", "")]
		public unsafe long IndexOf(sbyte b)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(b);
			return _members.InstanceMethods.InvokeAbstractInt64Method("indexOf.(B)J", this, ptr);
		}

		[Register("indexOf", "(BJ)J", "")]
		public unsafe long IndexOf(sbyte b, long fromIndex)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(b);
			ptr[1] = new JniArgumentValue(fromIndex);
			return _members.InstanceMethods.InvokeAbstractInt64Method("indexOf.(BJ)J", this, ptr);
		}

		[Register("indexOf", "(BJJ)J", "")]
		public unsafe long IndexOf(sbyte b, long fromIndex, long toIndex)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(b);
			ptr[1] = new JniArgumentValue(fromIndex);
			ptr[2] = new JniArgumentValue(toIndex);
			return _members.InstanceMethods.InvokeAbstractInt64Method("indexOf.(BJJ)J", this, ptr);
		}

		[Register("indexOf", "(Lokio/ByteString;)J", "")]
		public unsafe long IndexOf(ByteString bytes)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(bytes?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractInt64Method("indexOf.(Lokio/ByteString;)J", this, ptr);
			}
			finally
			{
				GC.KeepAlive(bytes);
			}
		}

		[Register("indexOf", "(Lokio/ByteString;J)J", "")]
		public unsafe long IndexOf(ByteString bytes, long fromIndex)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(bytes?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(fromIndex);
				return _members.InstanceMethods.InvokeAbstractInt64Method("indexOf.(Lokio/ByteString;J)J", this, ptr);
			}
			finally
			{
				GC.KeepAlive(bytes);
			}
		}

		[Register("indexOfElement", "(Lokio/ByteString;)J", "")]
		public unsafe long IndexOfElement(ByteString targetBytes)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(targetBytes?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractInt64Method("indexOfElement.(Lokio/ByteString;)J", this, ptr);
			}
			finally
			{
				GC.KeepAlive(targetBytes);
			}
		}

		[Register("indexOfElement", "(Lokio/ByteString;J)J", "")]
		public unsafe long IndexOfElement(ByteString targetBytes, long fromIndex)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(targetBytes?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(fromIndex);
				return _members.InstanceMethods.InvokeAbstractInt64Method("indexOfElement.(Lokio/ByteString;J)J", this, ptr);
			}
			finally
			{
				GC.KeepAlive(targetBytes);
			}
		}

		[Register("inputStream", "()Ljava/io/InputStream;", "")]
		public unsafe Stream InputStream()
		{
			return InputStreamInvoker.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("inputStream.()Ljava/io/InputStream;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("md5", "()Lokio/ByteString;", "")]
		public unsafe ByteString Md5()
		{
			return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("md5.()Lokio/ByteString;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("peek", "()Lokio/BufferedSource;", "")]
		public unsafe IBufferedSource Peek()
		{
			return Java.Lang.Object.GetObject<IBufferedSource>(_members.InstanceMethods.InvokeAbstractObjectMethod("peek.()Lokio/BufferedSource;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("rangeEquals", "(JLokio/ByteString;)Z", "")]
		public unsafe bool RangeEquals(long offset, ByteString bytes)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(offset);
				ptr[1] = new JniArgumentValue(bytes?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("rangeEquals.(JLokio/ByteString;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(bytes);
			}
		}

		[Register("rangeEquals", "(JLokio/ByteString;II)Z", "")]
		public unsafe bool RangeEquals(long offset, ByteString bytes, int bytesOffset, int byteCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(offset);
				ptr[1] = new JniArgumentValue(bytes?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(bytesOffset);
				ptr[3] = new JniArgumentValue(byteCount);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("rangeEquals.(JLokio/ByteString;II)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(bytes);
			}
		}

		[Register("read", "([B)I", "")]
		public unsafe int Read(byte[] sink)
		{
			IntPtr intPtr = JNIEnv.NewArray(sink);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeAbstractInt32Method("read.([B)I", this, ptr);
			}
			finally
			{
				if (sink != null)
				{
					JNIEnv.CopyArray(intPtr, sink);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(sink);
			}
		}

		[Register("read", "([BII)I", "")]
		public unsafe int Read(byte[] sink, int offset, int byteCount)
		{
			IntPtr intPtr = JNIEnv.NewArray(sink);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(offset);
				ptr[2] = new JniArgumentValue(byteCount);
				return _members.InstanceMethods.InvokeAbstractInt32Method("read.([BII)I", this, ptr);
			}
			finally
			{
				if (sink != null)
				{
					JNIEnv.CopyArray(intPtr, sink);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(sink);
			}
		}

		[Register("read", "(Ljava/nio/ByteBuffer;)I", "")]
		public unsafe int Read(ByteBuffer sink)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(sink?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractInt32Method("read.(Ljava/nio/ByteBuffer;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sink);
			}
		}

		[Register("read", "(Lokio/Buffer;J)J", "")]
		public unsafe long Read(OkBuffer sink, long byteCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(sink?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(byteCount);
				return _members.InstanceMethods.InvokeAbstractInt64Method("read.(Lokio/Buffer;J)J", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sink);
			}
		}

		[Register("readAll", "(Lokio/Sink;)J", "")]
		public unsafe long ReadAll(ISink sink)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
				return _members.InstanceMethods.InvokeAbstractInt64Method("readAll.(Lokio/Sink;)J", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sink);
			}
		}

		[Register("readAndWriteUnsafe", "()Lokio/Buffer$UnsafeCursor;", "")]
		public unsafe UnsafeCursor ReadAndWriteUnsafe()
		{
			return Java.Lang.Object.GetObject<UnsafeCursor>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("readAndWriteUnsafe.()Lokio/Buffer$UnsafeCursor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("readAndWriteUnsafe", "(Lokio/Buffer$UnsafeCursor;)Lokio/Buffer$UnsafeCursor;", "")]
		public unsafe UnsafeCursor ReadAndWriteUnsafe(UnsafeCursor unsafeCursor)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(unsafeCursor?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<UnsafeCursor>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("readAndWriteUnsafe.(Lokio/Buffer$UnsafeCursor;)Lokio/Buffer$UnsafeCursor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(unsafeCursor);
			}
		}

		[Register("readByte", "()B", "")]
		public unsafe sbyte ReadByte()
		{
			return _members.InstanceMethods.InvokeAbstractSByteMethod("readByte.()B", this, null);
		}

		[Register("readByteArray", "()[B", "")]
		public unsafe byte[] ReadByteArray()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("readByteArray.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}

		[Register("readByteArray", "(J)[B", "")]
		public unsafe byte[] ReadByteArray(long byteCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(byteCount);
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("readByteArray.(J)[B", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}

		[Register("readByteString", "()Lokio/ByteString;", "")]
		public unsafe ByteString ReadByteString()
		{
			return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeAbstractObjectMethod("readByteString.()Lokio/ByteString;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("readByteString", "(J)Lokio/ByteString;", "")]
		public unsafe ByteString ReadByteString(long byteCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(byteCount);
			return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeAbstractObjectMethod("readByteString.(J)Lokio/ByteString;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("readDecimalLong", "()J", "")]
		public unsafe long ReadDecimalLong()
		{
			return _members.InstanceMethods.InvokeAbstractInt64Method("readDecimalLong.()J", this, null);
		}

		[Register("readFrom", "(Ljava/io/InputStream;)Lokio/Buffer;", "")]
		public unsafe OkBuffer ReadFrom(Stream @in)
		{
			IntPtr intPtr = InputStreamAdapter.ToLocalJniHandle(@in);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("readFrom.(Ljava/io/InputStream;)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(@in);
			}
		}

		[Register("readFrom", "(Ljava/io/InputStream;J)Lokio/Buffer;", "")]
		public unsafe OkBuffer ReadFrom(Stream @in, long byteCount)
		{
			IntPtr intPtr = InputStreamAdapter.ToLocalJniHandle(@in);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(byteCount);
				return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("readFrom.(Ljava/io/InputStream;J)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(@in);
			}
		}

		[Register("readFully", "([B)V", "")]
		public unsafe void ReadFully(byte[] sink)
		{
			IntPtr intPtr = JNIEnv.NewArray(sink);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeAbstractVoidMethod("readFully.([B)V", this, ptr);
			}
			finally
			{
				if (sink != null)
				{
					JNIEnv.CopyArray(intPtr, sink);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(sink);
			}
		}

		[Register("readFully", "(Lokio/Buffer;J)V", "")]
		public unsafe void ReadFully(OkBuffer sink, long byteCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(sink?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(byteCount);
				_members.InstanceMethods.InvokeAbstractVoidMethod("readFully.(Lokio/Buffer;J)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sink);
			}
		}

		[Register("readHexadecimalUnsignedLong", "()J", "")]
		public unsafe long ReadHexadecimalUnsignedLong()
		{
			return _members.InstanceMethods.InvokeAbstractInt64Method("readHexadecimalUnsignedLong.()J", this, null);
		}

		[Register("readInt", "()I", "")]
		public unsafe int ReadInt()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("readInt.()I", this, null);
		}

		[Register("readIntLe", "()I", "")]
		public unsafe int ReadIntLe()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("readIntLe.()I", this, null);
		}

		[Register("readLong", "()J", "")]
		public unsafe long ReadLong()
		{
			return _members.InstanceMethods.InvokeAbstractInt64Method("readLong.()J", this, null);
		}

		[Register("readLongLe", "()J", "")]
		public unsafe long ReadLongLe()
		{
			return _members.InstanceMethods.InvokeAbstractInt64Method("readLongLe.()J", this, null);
		}

		[Register("readShort", "()S", "")]
		public unsafe short ReadShort()
		{
			return _members.InstanceMethods.InvokeAbstractInt16Method("readShort.()S", this, null);
		}

		[Register("readShortLe", "()S", "")]
		public unsafe short ReadShortLe()
		{
			return _members.InstanceMethods.InvokeAbstractInt16Method("readShortLe.()S", this, null);
		}

		[Register("readString", "(Ljava/nio/charset/Charset;)Ljava/lang/String;", "")]
		public unsafe string ReadString(Charset charset)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(charset?.Handle ?? IntPtr.Zero);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("readString.(Ljava/nio/charset/Charset;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(charset);
			}
		}

		[Register("readString", "(JLjava/nio/charset/Charset;)Ljava/lang/String;", "")]
		public unsafe string ReadString(long byteCount, Charset charset)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(byteCount);
				ptr[1] = new JniArgumentValue(charset?.Handle ?? IntPtr.Zero);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("readString.(JLjava/nio/charset/Charset;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(charset);
			}
		}

		[Register("readUnsafe", "()Lokio/Buffer$UnsafeCursor;", "")]
		public unsafe UnsafeCursor ReadUnsafe()
		{
			return Java.Lang.Object.GetObject<UnsafeCursor>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("readUnsafe.()Lokio/Buffer$UnsafeCursor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("readUnsafe", "(Lokio/Buffer$UnsafeCursor;)Lokio/Buffer$UnsafeCursor;", "")]
		public unsafe UnsafeCursor ReadUnsafe(UnsafeCursor unsafeCursor)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(unsafeCursor?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<UnsafeCursor>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("readUnsafe.(Lokio/Buffer$UnsafeCursor;)Lokio/Buffer$UnsafeCursor;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(unsafeCursor);
			}
		}

		[Register("readUtf8", "()Ljava/lang/String;", "")]
		public unsafe string ReadUtf8()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("readUtf8.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("readUtf8", "(J)Ljava/lang/String;", "")]
		public unsafe string ReadUtf8(long byteCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(byteCount);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("readUtf8.(J)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("readUtf8CodePoint", "()I", "")]
		public unsafe int ReadUtf8CodePoint()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("readUtf8CodePoint.()I", this, null);
		}

		[Register("readUtf8Line", "()Ljava/lang/String;", "")]
		public unsafe string ReadUtf8Line()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("readUtf8Line.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("readUtf8LineStrict", "()Ljava/lang/String;", "")]
		public unsafe string ReadUtf8LineStrict()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("readUtf8LineStrict.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("readUtf8LineStrict", "(J)Ljava/lang/String;", "")]
		public unsafe string ReadUtf8LineStrict(long limit)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(limit);
			return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("readUtf8LineStrict.(J)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("request", "(J)Z", "")]
		public unsafe bool Request(long byteCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(byteCount);
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("request.(J)Z", this, ptr);
		}

		[Register("require", "(J)V", "")]
		public unsafe void Require(long byteCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(byteCount);
			_members.InstanceMethods.InvokeAbstractVoidMethod("require.(J)V", this, ptr);
		}

		[Register("select", "(Lokio/Options;)I", "")]
		public unsafe int Select(Options options)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(options?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractInt32Method("select.(Lokio/Options;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(options);
			}
		}

		[Register("sha1", "()Lokio/ByteString;", "")]
		public unsafe ByteString Sha1()
		{
			return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("sha1.()Lokio/ByteString;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("sha256", "()Lokio/ByteString;", "")]
		public unsafe ByteString Sha256()
		{
			return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("sha256.()Lokio/ByteString;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("sha512", "()Lokio/ByteString;", "")]
		public unsafe ByteString Sha512()
		{
			return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("sha512.()Lokio/ByteString;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("size", "()J", "")]
		public unsafe long Size()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt64Method("size.()J", this, null);
		}

		[Register("skip", "(J)V", "")]
		public unsafe void Skip(long byteCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(byteCount);
			_members.InstanceMethods.InvokeAbstractVoidMethod("skip.(J)V", this, ptr);
		}

		[Register("snapshot", "()Lokio/ByteString;", "")]
		public unsafe ByteString Snapshot()
		{
			return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("snapshot.()Lokio/ByteString;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("snapshot", "(I)Lokio/ByteString;", "")]
		public unsafe ByteString Snapshot(int byteCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(byteCount);
			return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("snapshot.(I)Lokio/ByteString;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("timeout", "()Lokio/Timeout;", "")]
		public unsafe Timeout Timeout()
		{
			return Java.Lang.Object.GetObject<Timeout>(_members.InstanceMethods.InvokeAbstractObjectMethod("timeout.()Lokio/Timeout;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("write", "([B)Lokio/Buffer;", "")]
		public unsafe OkBuffer Write(byte[] source)
		{
			IntPtr intPtr = JNIEnv.NewArray(source);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("write.([B)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (source != null)
				{
					JNIEnv.CopyArray(intPtr, source);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(source);
			}
		}

		[Register("write", "([BII)Lokio/Buffer;", "")]
		public unsafe OkBuffer Write(byte[] source, int offset, int byteCount)
		{
			IntPtr intPtr = JNIEnv.NewArray(source);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(offset);
				ptr[2] = new JniArgumentValue(byteCount);
				return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("write.([BII)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (source != null)
				{
					JNIEnv.CopyArray(intPtr, source);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(source);
			}
		}

		[Register("write", "(Ljava/nio/ByteBuffer;)I", "")]
		public unsafe int Write(ByteBuffer source)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractInt32Method("write.(Ljava/nio/ByteBuffer;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		[Register("write", "(Lokio/Buffer;J)V", "")]
		public unsafe void Write(OkBuffer source, long byteCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(byteCount);
				_members.InstanceMethods.InvokeAbstractVoidMethod("write.(Lokio/Buffer;J)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		[Register("write", "(Lokio/ByteString;)Lokio/Buffer;", "")]
		public unsafe OkBuffer Write(ByteString byteString)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(byteString?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("write.(Lokio/ByteString;)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(byteString);
			}
		}

		[Register("write", "(Lokio/ByteString;II)Lokio/Buffer;", "")]
		public unsafe OkBuffer Write(ByteString byteString, int offset, int byteCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(byteString?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(offset);
				ptr[2] = new JniArgumentValue(byteCount);
				return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("write.(Lokio/ByteString;II)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(byteString);
			}
		}

		[Register("write", "(Lokio/Source;J)Lokio/Buffer;", "")]
		public unsafe OkBuffer Write(ISource source, long byteCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
				ptr[1] = new JniArgumentValue(byteCount);
				return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("write.(Lokio/Source;J)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		[Register("writeAll", "(Lokio/Source;)J", "")]
		public unsafe long WriteAll(ISource source)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
				return _members.InstanceMethods.InvokeAbstractInt64Method("writeAll.(Lokio/Source;)J", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		[Register("writeByte", "(I)Lokio/Buffer;", "")]
		public unsafe OkBuffer WriteByte(int b)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(b);
			return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("writeByte.(I)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeDecimalLong", "(J)Lokio/Buffer;", "")]
		public unsafe OkBuffer WriteDecimalLong(long v)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(v);
			return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("writeDecimalLong.(J)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeHexadecimalUnsignedLong", "(J)Lokio/Buffer;", "")]
		public unsafe OkBuffer WriteHexadecimalUnsignedLong(long v)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(v);
			return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("writeHexadecimalUnsignedLong.(J)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeInt", "(I)Lokio/Buffer;", "")]
		public unsafe OkBuffer WriteInt(int i)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(i);
			return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("writeInt.(I)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeIntLe", "(I)Lokio/Buffer;", "")]
		public unsafe OkBuffer WriteIntLe(int i)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(i);
			return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("writeIntLe.(I)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeLong", "(J)Lokio/Buffer;", "")]
		public unsafe OkBuffer WriteLong(long v)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(v);
			return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("writeLong.(J)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeLongLe", "(J)Lokio/Buffer;", "")]
		public unsafe OkBuffer WriteLongLe(long v)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(v);
			return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("writeLongLe.(J)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeShort", "(I)Lokio/Buffer;", "")]
		public unsafe OkBuffer WriteShort(int s)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(s);
			return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("writeShort.(I)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeShortLe", "(I)Lokio/Buffer;", "")]
		public unsafe OkBuffer WriteShortLe(int s)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(s);
			return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("writeShortLe.(I)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("writeString", "(Ljava/lang/String;IILjava/nio/charset/Charset;)Lokio/Buffer;", "")]
		public unsafe OkBuffer WriteString(string @string, int beginIndex, int endIndex, Charset charset)
		{
			IntPtr intPtr = JNIEnv.NewString(@string);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(beginIndex);
				ptr[2] = new JniArgumentValue(endIndex);
				ptr[3] = new JniArgumentValue(charset?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("writeString.(Ljava/lang/String;IILjava/nio/charset/Charset;)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(charset);
			}
		}

		[Register("writeString", "(Ljava/lang/String;Ljava/nio/charset/Charset;)Lokio/Buffer;", "")]
		public unsafe OkBuffer WriteString(string @string, Charset charset)
		{
			IntPtr intPtr = JNIEnv.NewString(@string);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(charset?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("writeString.(Ljava/lang/String;Ljava/nio/charset/Charset;)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(charset);
			}
		}

		[Register("writeTo", "(Ljava/io/OutputStream;)Lokio/Buffer;", "")]
		public unsafe OkBuffer WriteTo(Stream @out)
		{
			IntPtr intPtr = OutputStreamAdapter.ToLocalJniHandle(@out);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("writeTo.(Ljava/io/OutputStream;)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(@out);
			}
		}

		[Register("writeTo", "(Ljava/io/OutputStream;J)Lokio/Buffer;", "")]
		public unsafe OkBuffer WriteTo(Stream @out, long byteCount)
		{
			IntPtr intPtr = OutputStreamAdapter.ToLocalJniHandle(@out);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(byteCount);
				return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("writeTo.(Ljava/io/OutputStream;J)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(@out);
			}
		}

		[Register("writeUtf8", "(Ljava/lang/String;)Lokio/Buffer;", "")]
		public unsafe OkBuffer WriteUtf8(string @string)
		{
			IntPtr intPtr = JNIEnv.NewString(@string);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("writeUtf8.(Ljava/lang/String;)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("writeUtf8", "(Ljava/lang/String;II)Lokio/Buffer;", "")]
		public unsafe OkBuffer WriteUtf8(string @string, int beginIndex, int endIndex)
		{
			IntPtr intPtr = JNIEnv.NewString(@string);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(beginIndex);
				ptr[2] = new JniArgumentValue(endIndex);
				return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("writeUtf8.(Ljava/lang/String;II)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("writeUtf8CodePoint", "(I)Lokio/Buffer;", "")]
		public unsafe OkBuffer WriteUtf8CodePoint(int codePoint)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(codePoint);
			return Java.Lang.Object.GetObject<OkBuffer>(_members.InstanceMethods.InvokeAbstractObjectMethod("writeUtf8CodePoint.(I)Lokio/Buffer;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okio/Options", DoNotGenerateAcw = true)]
	public sealed class Options : Kotlin.Collections.AbstractList, IRandomAccess, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("okio/Options$Companion", DoNotGenerateAcw = true)]
		public sealed class CompanionStatic : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("okio/Options$Companion", typeof(CompanionStatic));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal CompanionStatic(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("of", "([Lokio/ByteString;)Lokio/Options;", "")]
			public unsafe Options Of(params ByteString[] byteStrings)
			{
				IntPtr intPtr = JNIEnv.NewArray(byteStrings);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Options>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("of.([Lokio/ByteString;)Lokio/Options;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					if (byteStrings != null)
					{
						JNIEnv.CopyArray(intPtr, byteStrings);
						JNIEnv.DeleteLocalRef(intPtr);
					}
					GC.KeepAlive(byteStrings);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/Options", typeof(Options));

		[Register("Companion")]
		public static CompanionStatic Companion => Java.Lang.Object.GetObject<CompanionStatic>(_members.StaticFields.GetObjectValue("Companion.Lokio/Options$Companion;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public ByteString GetOption(int i)
		{
			return (ByteString)Get(i);
		}

		public new bool Remove(Java.Lang.Object o)
		{
			return base.Remove(o);
		}

		public ByteString RemoveAt(int index)
		{
			ByteString option = GetOption(index);
			if (option != null)
			{
				Remove(option);
			}
			return option;
		}

		public new int Size()
		{
			return base.Size();
		}

		internal Options(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("contains", "(Ljava/lang/Object;)Z", "")]
		public unsafe sealed override bool Contains(Java.Lang.Object o)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(o?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("contains.(Ljava/lang/Object;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(o);
			}
		}

		[Register("contains", "(Lokio/ByteString;)Z", "")]
		public unsafe bool Contains(ByteString o)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(o?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("contains.(Lokio/ByteString;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(o);
			}
		}

		[Register("get", "(I)Lokio/ByteString;", "")]
		public unsafe override Java.Lang.Object Get(int i)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(i);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("get.(I)Lokio/ByteString;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("getSize", "()I", "")]
		public unsafe override int GetSize()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("getSize.()I", this, null);
		}

		[Register("indexOf", "(Ljava/lang/Object;)I", "")]
		public unsafe sealed override int IndexOf(Java.Lang.Object o)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(o?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("indexOf.(Ljava/lang/Object;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(o);
			}
		}

		[Register("indexOf", "(Lokio/ByteString;)I", "")]
		public unsafe int IndexOf(ByteString o)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(o?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractInt32Method("indexOf.(Lokio/ByteString;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(o);
			}
		}

		[Register("lastIndexOf", "(Ljava/lang/Object;)I", "")]
		public unsafe sealed override int LastIndexOf(Java.Lang.Object o)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(o?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("lastIndexOf.(Ljava/lang/Object;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(o);
			}
		}

		[Register("lastIndexOf", "(Lokio/ByteString;)I", "")]
		public unsafe int LastIndexOf(ByteString o)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(o?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractInt32Method("lastIndexOf.(Lokio/ByteString;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(o);
			}
		}

		[Register("of", "([Lokio/ByteString;)Lokio/Options;", "")]
		public unsafe static Options Of(params ByteString[] byteStrings)
		{
			IntPtr intPtr = JNIEnv.NewArray(byteStrings);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Options>(_members.StaticMethods.InvokeObjectMethod("of.([Lokio/ByteString;)Lokio/Options;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (byteStrings != null)
				{
					JNIEnv.CopyArray(intPtr, byteStrings);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(byteStrings);
			}
		}
	}
	[Register("okio/AsyncTimeout", DoNotGenerateAcw = true)]
	public class AsyncTimeout : Timeout
	{
		[Register("okio/AsyncTimeout$Companion", DoNotGenerateAcw = true)]
		public new sealed class CompanionStatic : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("okio/AsyncTimeout$Companion", typeof(CompanionStatic));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal CompanionStatic(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/AsyncTimeout", typeof(AsyncTimeout));

		private static Delegate cb_newTimeoutException_Ljava_io_IOException_;

		private static Delegate cb_timedOut;

		[Register("Companion")]
		public new static CompanionStatic Companion => Java.Lang.Object.GetObject<CompanionStatic>(_members.StaticFields.GetObjectValue("Companion.Lokio/AsyncTimeout$Companion;").Handle, JniHandleOwnership.TransferLocalRef);

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected AsyncTimeout(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe AsyncTimeout()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("enter", "()V", "")]
		public unsafe void Enter()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("enter.()V", this, null);
		}

		[Register("exit", "()Z", "")]
		public unsafe bool Exit()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("exit.()Z", this, null);
		}

		private static Delegate GetNewTimeoutException_Ljava_io_IOException_Handler()
		{
			if ((object)cb_newTimeoutException_Ljava_io_IOException_ == null)
			{
				cb_newTimeoutException_Ljava_io_IOException_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_NewTimeoutException_Ljava_io_IOException_));
			}
			return cb_newTimeoutException_Ljava_io_IOException_;
		}

		private static IntPtr n_NewTimeoutException_Ljava_io_IOException_(IntPtr jnienv, IntPtr native__this, IntPtr native_cause)
		{
			AsyncTimeout asyncTimeout = Java.Lang.Object.GetObject<AsyncTimeout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.IO.IOException cause = Java.Lang.Object.GetObject<Java.IO.IOException>(native_cause, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(asyncTimeout.NewTimeoutException(cause));
		}

		[Register("newTimeoutException", "(Ljava/io/IOException;)Ljava/io/IOException;", "GetNewTimeoutException_Ljava_io_IOException_Handler")]
		protected unsafe virtual Java.IO.IOException NewTimeoutException(Java.IO.IOException cause)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.IO.IOException>(_members.InstanceMethods.InvokeVirtualObjectMethod("newTimeoutException.(Ljava/io/IOException;)Ljava/io/IOException;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(cause);
			}
		}

		[Register("sink", "(Lokio/Sink;)Lokio/Sink;", "")]
		public unsafe ISink Sink(ISink sink)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
				return Java.Lang.Object.GetObject<ISink>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("sink.(Lokio/Sink;)Lokio/Sink;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(sink);
			}
		}

		[Register("source", "(Lokio/Source;)Lokio/Source;", "")]
		public unsafe ISource Source(ISource source)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
				return Java.Lang.Object.GetObject<ISource>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("source.(Lokio/Source;)Lokio/Source;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		private static Delegate GetTimedOutHandler()
		{
			if ((object)cb_timedOut == null)
			{
				cb_timedOut = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_TimedOut));
			}
			return cb_timedOut;
		}

		private static void n_TimedOut(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<AsyncTimeout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TimedOut();
		}

		[Register("timedOut", "()V", "GetTimedOutHandler")]
		protected unsafe virtual void TimedOut()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("timedOut.()V", this, null);
		}

		[Register("withTimeout", "(Lkotlin/jvm/functions/Function0;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe Java.Lang.Object WithTimeout(IFunction0 block)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("withTimeout.(Lkotlin/jvm/functions/Function0;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(block);
			}
		}
	}
	[Register("okio/ByteString", DoNotGenerateAcw = true)]
	public class ByteString : Java.Lang.Object, ISerializable, IJavaObject, IDisposable, IJavaPeerable, Java.Lang.IComparable
	{
		[Register("okio/ByteString$Companion", DoNotGenerateAcw = true)]
		public sealed class CompanionStatic : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("okio/ByteString$Companion", typeof(CompanionStatic));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal CompanionStatic(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("decodeBase64", "(Ljava/lang/String;)Lokio/ByteString;", "")]
			public unsafe ByteString DecodeBase64(string base64)
			{
				IntPtr intPtr = JNIEnv.NewString(base64);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("decodeBase64.(Ljava/lang/String;)Lokio/ByteString;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("decodeHex", "(Ljava/lang/String;)Lokio/ByteString;", "")]
			public unsafe ByteString DecodeHex(string hex)
			{
				IntPtr intPtr = JNIEnv.NewString(hex);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("decodeHex.(Ljava/lang/String;)Lokio/ByteString;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("encodeString", "(Ljava/lang/String;Ljava/nio/charset/Charset;)Lokio/ByteString;", "")]
			public unsafe ByteString EncodeString(string s, Charset charset)
			{
				IntPtr intPtr = JNIEnv.NewString(s);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(charset?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("encodeString.(Ljava/lang/String;Ljava/nio/charset/Charset;)Lokio/ByteString;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(charset);
				}
			}

			[Register("encodeUtf8", "(Ljava/lang/String;)Lokio/ByteString;", "")]
			public unsafe ByteString EncodeUtf8(string s)
			{
				IntPtr intPtr = JNIEnv.NewString(s);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("encodeUtf8.(Ljava/lang/String;)Lokio/ByteString;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("of", "([B)Lokio/ByteString;", "")]
			public unsafe ByteString Of(params byte[] data)
			{
				IntPtr intPtr = JNIEnv.NewArray(data);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("of.([B)Lokio/ByteString;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					if (data != null)
					{
						JNIEnv.CopyArray(intPtr, data);
						JNIEnv.DeleteLocalRef(intPtr);
					}
					GC.KeepAlive(data);
				}
			}

			[Register("of", "([BII)Lokio/ByteString;", "")]
			public unsafe ByteString Of(byte[] data, int offset, int byteCount)
			{
				IntPtr intPtr = JNIEnv.NewArray(data);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(offset);
					ptr[2] = new JniArgumentValue(byteCount);
					return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("of.([BII)Lokio/ByteString;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					if (data != null)
					{
						JNIEnv.CopyArray(intPtr, data);
						JNIEnv.DeleteLocalRef(intPtr);
					}
					GC.KeepAlive(data);
				}
			}

			[Register("of", "(Ljava/nio/ByteBuffer;)Lokio/ByteString;", "")]
			public unsafe ByteString Of(ByteBuffer data)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("of.(Ljava/nio/ByteBuffer;)Lokio/ByteString;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(data);
				}
			}

			[Register("read", "(Ljava/io/InputStream;I)Lokio/ByteString;", "")]
			public unsafe ByteString Read(Stream @in, int byteCount)
			{
				IntPtr intPtr = InputStreamAdapter.ToLocalJniHandle(@in);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue(intPtr);
					ptr[1] = new JniArgumentValue(byteCount);
					return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("read.(Ljava/io/InputStream;I)Lokio/ByteString;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(@in);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/ByteString", typeof(ByteString));

		private static Delegate cb_asByteBuffer;

		private static Delegate cb_base64;

		private static Delegate cb_base64Url;

		private static Delegate cb_compareTo_Lokio_ByteString_;

		private static Delegate cb_hex;

		private static Delegate cb_hmacSha1_Lokio_ByteString_;

		private static Delegate cb_hmacSha256_Lokio_ByteString_;

		private static Delegate cb_hmacSha512_Lokio_ByteString_;

		private static Delegate cb_indexOf_arrayBI;

		private static Delegate cb_lastIndexOf_arrayBI;

		private static Delegate cb_rangeEquals_IarrayBII;

		private static Delegate cb_rangeEquals_ILokio_ByteString_II;

		private static Delegate cb_string_Ljava_nio_charset_Charset_;

		private static Delegate cb_substring_II;

		private static Delegate cb_toAsciiLowercase;

		private static Delegate cb_toAsciiUppercase;

		private static Delegate cb_toByteArray;

		private static Delegate cb_utf8;

		private static Delegate cb_write_Ljava_io_OutputStream_;

		[Register("Companion")]
		public static CompanionStatic Companion => Java.Lang.Object.GetObject<CompanionStatic>(_members.StaticFields.GetObjectValue("Companion.Lokio/ByteString$Companion;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("EMPTY")]
		public static ByteString Empty => Java.Lang.Object.GetObject<ByteString>(_members.StaticFields.GetObjectValue("EMPTY.Lokio/ByteString;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected ByteString(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		private static Delegate GetAsByteBufferHandler()
		{
			if ((object)cb_asByteBuffer == null)
			{
				cb_asByteBuffer = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AsByteBuffer));
			}
			return cb_asByteBuffer;
		}

		private static IntPtr n_AsByteBuffer(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ByteString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AsByteBuffer());
		}

		[Register("asByteBuffer", "()Ljava/nio/ByteBuffer;", "GetAsByteBufferHandler")]
		public unsafe virtual ByteBuffer AsByteBuffer()
		{
			return Java.Lang.Object.GetObject<ByteBuffer>(_members.InstanceMethods.InvokeVirtualObjectMethod("asByteBuffer.()Ljava/nio/ByteBuffer;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetBase64Handler()
		{
			if ((object)cb_base64 == null)
			{
				cb_base64 = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Base64));
			}
			return cb_base64;
		}

		private static IntPtr n_Base64(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ByteString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Base64());
		}

		[Register("base64", "()Ljava/lang/String;", "GetBase64Handler")]
		public unsafe virtual string Base64()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("base64.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetBase64UrlHandler()
		{
			if ((object)cb_base64Url == null)
			{
				cb_base64Url = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Base64Url));
			}
			return cb_base64Url;
		}

		private static IntPtr n_Base64Url(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ByteString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Base64Url());
		}

		[Register("base64Url", "()Ljava/lang/String;", "GetBase64UrlHandler")]
		public unsafe virtual string Base64Url()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("base64Url.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetCompareTo_Lokio_ByteString_Handler()
		{
			if ((object)cb_compareTo_Lokio_ByteString_ == null)
			{
				cb_compareTo_Lokio_ByteString_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_CompareTo_Lokio_ByteString_));
			}
			return cb_compareTo_Lokio_ByteString_;
		}

		private static int n_CompareTo_Lokio_ByteString_(IntPtr jnienv, IntPtr native__this, IntPtr native_other)
		{
			ByteString byteString = Java.Lang.Object.GetObject<ByteString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteString other = Java.Lang.Object.GetObject<ByteString>(native_other, JniHandleOwnership.DoNotTransfer);
			return byteString.CompareTo(other);
		}

		[Register("compareTo", "(Lokio/ByteString;)I", "GetCompareTo_Lokio_ByteString_Handler")]
		public unsafe virtual int CompareTo(Java.Lang.Object other)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualInt32Method("compareTo.(Lokio/ByteString;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(other);
			}
		}

		[Register("decodeBase64", "(Ljava/lang/String;)Lokio/ByteString;", "")]
		public unsafe static ByteString DecodeBase64(string base64)
		{
			IntPtr intPtr = JNIEnv.NewString(base64);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ByteString>(_members.StaticMethods.InvokeObjectMethod("decodeBase64.(Ljava/lang/String;)Lokio/ByteString;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("decodeHex", "(Ljava/lang/String;)Lokio/ByteString;", "")]
		public unsafe static ByteString DecodeHex(string hex)
		{
			IntPtr intPtr = JNIEnv.NewString(hex);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ByteString>(_members.StaticMethods.InvokeObjectMethod("decodeHex.(Ljava/lang/String;)Lokio/ByteString;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("encodeString", "(Ljava/lang/String;Ljava/nio/charset/Charset;)Lokio/ByteString;", "")]
		public unsafe static ByteString EncodeString(string s, Charset charset)
		{
			IntPtr intPtr = JNIEnv.NewString(s);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(charset?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ByteString>(_members.StaticMethods.InvokeObjectMethod("encodeString.(Ljava/lang/String;Ljava/nio/charset/Charset;)Lokio/ByteString;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(charset);
			}
		}

		[Register("encodeUtf8", "(Ljava/lang/String;)Lokio/ByteString;", "")]
		public unsafe static ByteString EncodeUtf8(string s)
		{
			IntPtr intPtr = JNIEnv.NewString(s);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ByteString>(_members.StaticMethods.InvokeObjectMethod("encodeUtf8.(Ljava/lang/String;)Lokio/ByteString;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("endsWith", "([B)Z", "")]
		public unsafe bool EndsWith(byte[] suffix)
		{
			IntPtr intPtr = JNIEnv.NewArray(suffix);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("endsWith.([B)Z", this, ptr);
			}
			finally
			{
				if (suffix != null)
				{
					JNIEnv.CopyArray(intPtr, suffix);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(suffix);
			}
		}

		[Register("endsWith", "(Lokio/ByteString;)Z", "")]
		public unsafe bool EndsWith(ByteString suffix)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(suffix?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("endsWith.(Lokio/ByteString;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(suffix);
			}
		}

		[Register("getByte", "(I)B", "")]
		public unsafe sbyte GetByte(int index)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(index);
			return _members.InstanceMethods.InvokeNonvirtualSByteMethod("getByte.(I)B", this, ptr);
		}

		private static Delegate GetHexHandler()
		{
			if ((object)cb_hex == null)
			{
				cb_hex = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Hex));
			}
			return cb_hex;
		}

		private static IntPtr n_Hex(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ByteString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Hex());
		}

		[Register("hex", "()Ljava/lang/String;", "GetHexHandler")]
		public unsafe virtual string Hex()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("hex.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetHmacSha1_Lokio_ByteString_Handler()
		{
			if ((object)cb_hmacSha1_Lokio_ByteString_ == null)
			{
				cb_hmacSha1_Lokio_ByteString_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_HmacSha1_Lokio_ByteString_));
			}
			return cb_hmacSha1_Lokio_ByteString_;
		}

		private static IntPtr n_HmacSha1_Lokio_ByteString_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			ByteString byteString = Java.Lang.Object.GetObject<ByteString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteString key = Java.Lang.Object.GetObject<ByteString>(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(byteString.HmacSha1(key));
		}

		[Register("hmacSha1", "(Lokio/ByteString;)Lokio/ByteString;", "GetHmacSha1_Lokio_ByteString_Handler")]
		public unsafe virtual ByteString HmacSha1(ByteString key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(key?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeVirtualObjectMethod("hmacSha1.(Lokio/ByteString;)Lokio/ByteString;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(key);
			}
		}

		private static Delegate GetHmacSha256_Lokio_ByteString_Handler()
		{
			if ((object)cb_hmacSha256_Lokio_ByteString_ == null)
			{
				cb_hmacSha256_Lokio_ByteString_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_HmacSha256_Lokio_ByteString_));
			}
			return cb_hmacSha256_Lokio_ByteString_;
		}

		private static IntPtr n_HmacSha256_Lokio_ByteString_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			ByteString byteString = Java.Lang.Object.GetObject<ByteString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteString key = Java.Lang.Object.GetObject<ByteString>(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(byteString.HmacSha256(key));
		}

		[Register("hmacSha256", "(Lokio/ByteString;)Lokio/ByteString;", "GetHmacSha256_Lokio_ByteString_Handler")]
		public unsafe virtual ByteString HmacSha256(ByteString key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(key?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeVirtualObjectMethod("hmacSha256.(Lokio/ByteString;)Lokio/ByteString;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(key);
			}
		}

		private static Delegate GetHmacSha512_Lokio_ByteString_Handler()
		{
			if ((object)cb_hmacSha512_Lokio_ByteString_ == null)
			{
				cb_hmacSha512_Lokio_ByteString_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_HmacSha512_Lokio_ByteString_));
			}
			return cb_hmacSha512_Lokio_ByteString_;
		}

		private static IntPtr n_HmacSha512_Lokio_ByteString_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			ByteString byteString = Java.Lang.Object.GetObject<ByteString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteString key = Java.Lang.Object.GetObject<ByteString>(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(byteString.HmacSha512(key));
		}

		[Register("hmacSha512", "(Lokio/ByteString;)Lokio/ByteString;", "GetHmacSha512_Lokio_ByteString_Handler")]
		public unsafe virtual ByteString HmacSha512(ByteString key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(key?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeVirtualObjectMethod("hmacSha512.(Lokio/ByteString;)Lokio/ByteString;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(key);
			}
		}

		[Register("indexOf", "([B)I", "")]
		public unsafe int IndexOf(byte[] other)
		{
			IntPtr intPtr = JNIEnv.NewArray(other);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("indexOf.([B)I", this, ptr);
			}
			finally
			{
				if (other != null)
				{
					JNIEnv.CopyArray(intPtr, other);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(other);
			}
		}

		private static Delegate GetIndexOf_arrayBIHandler()
		{
			if ((object)cb_indexOf_arrayBI == null)
			{
				cb_indexOf_arrayBI = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_I(n_IndexOf_arrayBI));
			}
			return cb_indexOf_arrayBI;
		}

		private static int n_IndexOf_arrayBI(IntPtr jnienv, IntPtr native__this, IntPtr native_other, int fromIndex)
		{
			ByteString byteString = Java.Lang.Object.GetObject<ByteString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_other, JniHandleOwnership.DoNotTransfer, typeof(byte));
			int result = byteString.IndexOf(array, fromIndex);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_other);
			}
			return result;
		}

		[Register("indexOf", "([BI)I", "GetIndexOf_arrayBIHandler")]
		public unsafe virtual int IndexOf(byte[] other, int fromIndex)
		{
			IntPtr intPtr = JNIEnv.NewArray(other);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(fromIndex);
				return _members.InstanceMethods.InvokeVirtualInt32Method("indexOf.([BI)I", this, ptr);
			}
			finally
			{
				if (other != null)
				{
					JNIEnv.CopyArray(intPtr, other);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(other);
			}
		}

		[Register("indexOf", "(Lokio/ByteString;)I", "")]
		public unsafe int IndexOf(ByteString other)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("indexOf.(Lokio/ByteString;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(other);
			}
		}

		[Register("indexOf", "(Lokio/ByteString;I)I", "")]
		public unsafe int IndexOf(ByteString other, int fromIndex)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(fromIndex);
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("indexOf.(Lokio/ByteString;I)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(other);
			}
		}

		[Register("lastIndexOf", "([B)I", "")]
		public unsafe int LastIndexOf(byte[] other)
		{
			IntPtr intPtr = JNIEnv.NewArray(other);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("lastIndexOf.([B)I", this, ptr);
			}
			finally
			{
				if (other != null)
				{
					JNIEnv.CopyArray(intPtr, other);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(other);
			}
		}

		private static Delegate GetLastIndexOf_arrayBIHandler()
		{
			if ((object)cb_lastIndexOf_arrayBI == null)
			{
				cb_lastIndexOf_arrayBI = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLI_I(n_LastIndexOf_arrayBI));
			}
			return cb_lastIndexOf_arrayBI;
		}

		private static int n_LastIndexOf_arrayBI(IntPtr jnienv, IntPtr native__this, IntPtr native_other, int fromIndex)
		{
			ByteString byteString = Java.Lang.Object.GetObject<ByteString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_other, JniHandleOwnership.DoNotTransfer, typeof(byte));
			int result = byteString.LastIndexOf(array, fromIndex);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_other);
			}
			return result;
		}

		[Register("lastIndexOf", "([BI)I", "GetLastIndexOf_arrayBIHandler")]
		public unsafe virtual int LastIndexOf(byte[] other, int fromIndex)
		{
			IntPtr intPtr = JNIEnv.NewArray(other);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(fromIndex);
				return _members.InstanceMethods.InvokeVirtualInt32Method("lastIndexOf.([BI)I", this, ptr);
			}
			finally
			{
				if (other != null)
				{
					JNIEnv.CopyArray(intPtr, other);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(other);
			}
		}

		[Register("lastIndexOf", "(Lokio/ByteString;)I", "")]
		public unsafe int LastIndexOf(ByteString other)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("lastIndexOf.(Lokio/ByteString;)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(other);
			}
		}

		[Register("lastIndexOf", "(Lokio/ByteString;I)I", "")]
		public unsafe int LastIndexOf(ByteString other, int fromIndex)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(fromIndex);
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("lastIndexOf.(Lokio/ByteString;I)I", this, ptr);
			}
			finally
			{
				GC.KeepAlive(other);
			}
		}

		[Register("md5", "()Lokio/ByteString;", "")]
		public unsafe ByteString Md5()
		{
			return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("md5.()Lokio/ByteString;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("of", "([B)Lokio/ByteString;", "")]
		public unsafe static ByteString Of(params byte[] data)
		{
			IntPtr intPtr = JNIEnv.NewArray(data);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ByteString>(_members.StaticMethods.InvokeObjectMethod("of.([B)Lokio/ByteString;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (data != null)
				{
					JNIEnv.CopyArray(intPtr, data);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(data);
			}
		}

		[Register("of", "([BII)Lokio/ByteString;", "")]
		public unsafe static ByteString Of(byte[] data, int offset, int byteCount)
		{
			IntPtr intPtr = JNIEnv.NewArray(data);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(offset);
				ptr[2] = new JniArgumentValue(byteCount);
				return Java.Lang.Object.GetObject<ByteString>(_members.StaticMethods.InvokeObjectMethod("of.([BII)Lokio/ByteString;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (data != null)
				{
					JNIEnv.CopyArray(intPtr, data);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(data);
			}
		}

		[Register("of", "(Ljava/nio/ByteBuffer;)Lokio/ByteString;", "")]
		public unsafe static ByteString Of(ByteBuffer data)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ByteString>(_members.StaticMethods.InvokeObjectMethod("of.(Ljava/nio/ByteBuffer;)Lokio/ByteString;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(data);
			}
		}

		private static Delegate GetRangeEquals_IarrayBIIHandler()
		{
			if ((object)cb_rangeEquals_IarrayBII == null)
			{
				cb_rangeEquals_IarrayBII = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPILII_Z(n_RangeEquals_IarrayBII));
			}
			return cb_rangeEquals_IarrayBII;
		}

		private static bool n_RangeEquals_IarrayBII(IntPtr jnienv, IntPtr native__this, int offset, IntPtr native_other, int otherOffset, int byteCount)
		{
			ByteString byteString = Java.Lang.Object.GetObject<ByteString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_other, JniHandleOwnership.DoNotTransfer, typeof(byte));
			bool result = byteString.RangeEquals(offset, array, otherOffset, byteCount);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_other);
			}
			return result;
		}

		[Register("rangeEquals", "(I[BII)Z", "GetRangeEquals_IarrayBIIHandler")]
		public unsafe virtual bool RangeEquals(int offset, byte[] other, int otherOffset, int byteCount)
		{
			IntPtr intPtr = JNIEnv.NewArray(other);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(offset);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(otherOffset);
				ptr[3] = new JniArgumentValue(byteCount);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("rangeEquals.(I[BII)Z", this, ptr);
			}
			finally
			{
				if (other != null)
				{
					JNIEnv.CopyArray(intPtr, other);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(other);
			}
		}

		private static Delegate GetRangeEquals_ILokio_ByteString_IIHandler()
		{
			if ((object)cb_rangeEquals_ILokio_ByteString_II == null)
			{
				cb_rangeEquals_ILokio_ByteString_II = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPILII_Z(n_RangeEquals_ILokio_ByteString_II));
			}
			return cb_rangeEquals_ILokio_ByteString_II;
		}

		private static bool n_RangeEquals_ILokio_ByteString_II(IntPtr jnienv, IntPtr native__this, int offset, IntPtr native_other, int otherOffset, int byteCount)
		{
			ByteString byteString = Java.Lang.Object.GetObject<ByteString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteString other = Java.Lang.Object.GetObject<ByteString>(native_other, JniHandleOwnership.DoNotTransfer);
			return byteString.RangeEquals(offset, other, otherOffset, byteCount);
		}

		[Register("rangeEquals", "(ILokio/ByteString;II)Z", "GetRangeEquals_ILokio_ByteString_IIHandler")]
		public unsafe virtual bool RangeEquals(int offset, ByteString other, int otherOffset, int byteCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue(offset);
				ptr[1] = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(otherOffset);
				ptr[3] = new JniArgumentValue(byteCount);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("rangeEquals.(ILokio/ByteString;II)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(other);
			}
		}

		[Register("read", "(Ljava/io/InputStream;I)Lokio/ByteString;", "")]
		public unsafe static ByteString Read(Stream @in, int byteCount)
		{
			IntPtr intPtr = InputStreamAdapter.ToLocalJniHandle(@in);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(byteCount);
				return Java.Lang.Object.GetObject<ByteString>(_members.StaticMethods.InvokeObjectMethod("read.(Ljava/io/InputStream;I)Lokio/ByteString;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(@in);
			}
		}

		[Register("sha1", "()Lokio/ByteString;", "")]
		public unsafe ByteString Sha1()
		{
			return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("sha1.()Lokio/ByteString;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("sha256", "()Lokio/ByteString;", "")]
		public unsafe ByteString Sha256()
		{
			return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("sha256.()Lokio/ByteString;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("sha512", "()Lokio/ByteString;", "")]
		public unsafe ByteString Sha512()
		{
			return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("sha512.()Lokio/ByteString;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("size", "()I", "")]
		public unsafe int Size()
		{
			return _members.InstanceMethods.InvokeNonvirtualInt32Method("size.()I", this, null);
		}

		[Register("startsWith", "([B)Z", "")]
		public unsafe bool StartsWith(byte[] prefix)
		{
			IntPtr intPtr = JNIEnv.NewArray(prefix);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("startsWith.([B)Z", this, ptr);
			}
			finally
			{
				if (prefix != null)
				{
					JNIEnv.CopyArray(intPtr, prefix);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(prefix);
			}
		}

		[Register("startsWith", "(Lokio/ByteString;)Z", "")]
		public unsafe bool StartsWith(ByteString prefix)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(prefix?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("startsWith.(Lokio/ByteString;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(prefix);
			}
		}

		private static Delegate GetString_Ljava_nio_charset_Charset_Handler()
		{
			if ((object)cb_string_Ljava_nio_charset_Charset_ == null)
			{
				cb_string_Ljava_nio_charset_Charset_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_String_Ljava_nio_charset_Charset_));
			}
			return cb_string_Ljava_nio_charset_Charset_;
		}

		private static IntPtr n_String_Ljava_nio_charset_Charset_(IntPtr jnienv, IntPtr native__this, IntPtr native_charset)
		{
			ByteString byteString = Java.Lang.Object.GetObject<ByteString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Charset charset = Java.Lang.Object.GetObject<Charset>(native_charset, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(byteString.String(charset));
		}

		[Register("string", "(Ljava/nio/charset/Charset;)Ljava/lang/String;", "GetString_Ljava_nio_charset_Charset_Handler")]
		public unsafe virtual string String(Charset charset)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(charset?.Handle ?? IntPtr.Zero);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("string.(Ljava/nio/charset/Charset;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(charset);
			}
		}

		[Register("substring", "()Lokio/ByteString;", "")]
		public unsafe ByteString Substring()
		{
			return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("substring.()Lokio/ByteString;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("substring", "(I)Lokio/ByteString;", "")]
		public unsafe ByteString Substring(int beginIndex)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(beginIndex);
			return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("substring.(I)Lokio/ByteString;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetSubstring_IIHandler()
		{
			if ((object)cb_substring_II == null)
			{
				cb_substring_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPII_L(n_Substring_II));
			}
			return cb_substring_II;
		}

		private static IntPtr n_Substring_II(IntPtr jnienv, IntPtr native__this, int beginIndex, int endIndex)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ByteString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Substring(beginIndex, endIndex));
		}

		[Register("substring", "(II)Lokio/ByteString;", "GetSubstring_IIHandler")]
		public unsafe virtual ByteString Substring(int beginIndex, int endIndex)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(beginIndex);
			ptr[1] = new JniArgumentValue(endIndex);
			return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeVirtualObjectMethod("substring.(II)Lokio/ByteString;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetToAsciiLowercaseHandler()
		{
			if ((object)cb_toAsciiLowercase == null)
			{
				cb_toAsciiLowercase = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToAsciiLowercase));
			}
			return cb_toAsciiLowercase;
		}

		private static IntPtr n_ToAsciiLowercase(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ByteString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToAsciiLowercase());
		}

		[Register("toAsciiLowercase", "()Lokio/ByteString;", "GetToAsciiLowercaseHandler")]
		public unsafe virtual ByteString ToAsciiLowercase()
		{
			return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeVirtualObjectMethod("toAsciiLowercase.()Lokio/ByteString;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetToAsciiUppercaseHandler()
		{
			if ((object)cb_toAsciiUppercase == null)
			{
				cb_toAsciiUppercase = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToAsciiUppercase));
			}
			return cb_toAsciiUppercase;
		}

		private static IntPtr n_ToAsciiUppercase(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ByteString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToAsciiUppercase());
		}

		[Register("toAsciiUppercase", "()Lokio/ByteString;", "GetToAsciiUppercaseHandler")]
		public unsafe virtual ByteString ToAsciiUppercase()
		{
			return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeVirtualObjectMethod("toAsciiUppercase.()Lokio/ByteString;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetToByteArrayHandler()
		{
			if ((object)cb_toByteArray == null)
			{
				cb_toByteArray = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToByteArray));
			}
			return cb_toByteArray;
		}

		private static IntPtr n_ToByteArray(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<ByteString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToByteArray());
		}

		[Register("toByteArray", "()[B", "GetToByteArrayHandler")]
		public unsafe virtual byte[] ToByteArray()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeVirtualObjectMethod("toByteArray.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}

		private static Delegate GetUtf8Handler()
		{
			if ((object)cb_utf8 == null)
			{
				cb_utf8 = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Utf8));
			}
			return cb_utf8;
		}

		private static IntPtr n_Utf8(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<ByteString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Utf8());
		}

		[Register("utf8", "()Ljava/lang/String;", "GetUtf8Handler")]
		public unsafe virtual string Utf8()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("utf8.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWrite_Ljava_io_OutputStream_Handler()
		{
			if ((object)cb_write_Ljava_io_OutputStream_ == null)
			{
				cb_write_Ljava_io_OutputStream_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Write_Ljava_io_OutputStream_));
			}
			return cb_write_Ljava_io_OutputStream_;
		}

		private static void n_Write_Ljava_io_OutputStream_(IntPtr jnienv, IntPtr native__this, IntPtr native__out)
		{
			ByteString byteString = Java.Lang.Object.GetObject<ByteString>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Stream stream = OutputStreamInvoker.FromJniHandle(native__out, JniHandleOwnership.DoNotTransfer);
			byteString.Write(stream);
		}

		[Register("write", "(Ljava/io/OutputStream;)V", "GetWrite_Ljava_io_OutputStream_Handler")]
		public unsafe virtual void Write(Stream @out)
		{
			IntPtr intPtr = OutputStreamAdapter.ToLocalJniHandle(@out);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				_members.InstanceMethods.InvokeVirtualVoidMethod("write.(Ljava/io/OutputStream;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(@out);
			}
		}
	}
	[Register("okio/CipherSink", DoNotGenerateAcw = true)]
	public sealed class CipherSink : Java.Lang.Object, ISink, ICloseable, IJavaObject, IDisposable, IJavaPeerable, IFlushable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/CipherSink", typeof(CipherSink));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe Cipher Cipher
		{
			[Register("getCipher", "()Ljavax/crypto/Cipher;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Cipher>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCipher.()Ljavax/crypto/Cipher;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal CipherSink(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lokio/BufferedSink;Ljavax/crypto/Cipher;)V", "")]
		public unsafe CipherSink(IBufferedSink sink, Cipher cipher)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
				ptr[1] = new JniArgumentValue(cipher?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lokio/BufferedSink;Ljavax/crypto/Cipher;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lokio/BufferedSink;Ljavax/crypto/Cipher;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sink);
				GC.KeepAlive(cipher);
			}
		}

		[Register("close", "()V", "")]
		public unsafe void Close()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("close.()V", this, null);
		}

		[Register("flush", "()V", "")]
		public unsafe void Flush()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("flush.()V", this, null);
		}

		[Register("timeout", "()Lokio/Timeout;", "")]
		public unsafe Timeout Timeout()
		{
			return Java.Lang.Object.GetObject<Timeout>(_members.InstanceMethods.InvokeAbstractObjectMethod("timeout.()Lokio/Timeout;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("write", "(Lokio/Buffer;J)V", "")]
		public unsafe void Write(OkBuffer source, long byteCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(byteCount);
				_members.InstanceMethods.InvokeAbstractVoidMethod("write.(Lokio/Buffer;J)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}
	}
	[Register("okio/CipherSource", DoNotGenerateAcw = true)]
	public sealed class CipherSource : Java.Lang.Object, ISource, ICloseable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/CipherSource", typeof(CipherSource));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe Cipher Cipher
		{
			[Register("getCipher", "()Ljavax/crypto/Cipher;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Cipher>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCipher.()Ljavax/crypto/Cipher;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal CipherSource(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lokio/BufferedSource;Ljavax/crypto/Cipher;)V", "")]
		public unsafe CipherSource(IBufferedSource source, Cipher cipher)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
				ptr[1] = new JniArgumentValue(cipher?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lokio/BufferedSource;Ljavax/crypto/Cipher;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lokio/BufferedSource;Ljavax/crypto/Cipher;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
				GC.KeepAlive(cipher);
			}
		}

		[Register("close", "()V", "")]
		public unsafe void Close()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("close.()V", this, null);
		}

		[Register("read", "(Lokio/Buffer;J)J", "")]
		public unsafe long Read(OkBuffer sink, long byteCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(sink?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(byteCount);
				return _members.InstanceMethods.InvokeAbstractInt64Method("read.(Lokio/Buffer;J)J", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sink);
			}
		}

		[Register("timeout", "()Lokio/Timeout;", "")]
		public unsafe Timeout Timeout()
		{
			return Java.Lang.Object.GetObject<Timeout>(_members.InstanceMethods.InvokeAbstractObjectMethod("timeout.()Lokio/Timeout;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okio/DeflaterSink", DoNotGenerateAcw = true)]
	public sealed class DeflaterSink : Java.Lang.Object, ISink, ICloseable, IJavaObject, IDisposable, IJavaPeerable, IFlushable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/DeflaterSink", typeof(DeflaterSink));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal DeflaterSink(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lokio/Sink;Ljava/util/zip/Deflater;)V", "")]
		public unsafe DeflaterSink(ISink sink, Deflater deflater)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
				ptr[1] = new JniArgumentValue(deflater?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lokio/Sink;Ljava/util/zip/Deflater;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lokio/Sink;Ljava/util/zip/Deflater;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sink);
				GC.KeepAlive(deflater);
			}
		}

		[Register("close", "()V", "")]
		public unsafe void Close()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("close.()V", this, null);
		}

		[Register("flush", "()V", "")]
		public unsafe void Flush()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("flush.()V", this, null);
		}

		[Register("timeout", "()Lokio/Timeout;", "")]
		public unsafe Timeout Timeout()
		{
			return Java.Lang.Object.GetObject<Timeout>(_members.InstanceMethods.InvokeAbstractObjectMethod("timeout.()Lokio/Timeout;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("write", "(Lokio/Buffer;J)V", "")]
		public unsafe void Write(OkBuffer source, long byteCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(byteCount);
				_members.InstanceMethods.InvokeAbstractVoidMethod("write.(Lokio/Buffer;J)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}
	}
	[Annotation("okio.ExperimentalFileSystem")]
	public class ExperimentalFileSystemAttribute : Attribute
	{
	}
	[Register("okio/ForwardingSink", DoNotGenerateAcw = true)]
	public abstract class ForwardingSink : Java.Lang.Object, ISink, ICloseable, IJavaObject, IDisposable, IJavaPeerable, IFlushable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/ForwardingSink", typeof(ForwardingSink));

		private static Delegate cb_close;

		private static Delegate cb_flush;

		private static Delegate cb_timeout;

		private static Delegate cb_write_Lokio_Buffer_J;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected ForwardingSink(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lokio/Sink;)V", "")]
		public unsafe ForwardingSink(ISink @delegate)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((@delegate == null) ? IntPtr.Zero : ((Java.Lang.Object)@delegate).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lokio/Sink;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lokio/Sink;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@delegate);
			}
		}

		private static Delegate GetCloseHandler()
		{
			if ((object)cb_close == null)
			{
				cb_close = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Close));
			}
			return cb_close;
		}

		private static void n_Close(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ForwardingSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
		}

		[Register("close", "()V", "GetCloseHandler")]
		public unsafe virtual void Close()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("close.()V", this, null);
		}

		[Register("delegate", "()Lokio/Sink;", "")]
		public unsafe ISink Delegate()
		{
			return Java.Lang.Object.GetObject<ISink>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("delegate.()Lokio/Sink;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetFlushHandler()
		{
			if ((object)cb_flush == null)
			{
				cb_flush = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Flush));
			}
			return cb_flush;
		}

		private static void n_Flush(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ForwardingSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Flush();
		}

		[Register("flush", "()V", "GetFlushHandler")]
		public unsafe virtual void Flush()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("flush.()V", this, null);
		}

		private static Delegate GetTimeoutHandler()
		{
			if ((object)cb_timeout == null)
			{
				cb_timeout = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Timeout));
			}
			return cb_timeout;
		}

		private static IntPtr n_Timeout(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ForwardingSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Timeout());
		}

		[Register("timeout", "()Lokio/Timeout;", "GetTimeoutHandler")]
		public unsafe virtual Timeout Timeout()
		{
			return Java.Lang.Object.GetObject<Timeout>(_members.InstanceMethods.InvokeVirtualObjectMethod("timeout.()Lokio/Timeout;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWrite_Lokio_Buffer_JHandler()
		{
			if ((object)cb_write_Lokio_Buffer_J == null)
			{
				cb_write_Lokio_Buffer_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLJ_V(n_Write_Lokio_Buffer_J));
			}
			return cb_write_Lokio_Buffer_J;
		}

		private static void n_Write_Lokio_Buffer_J(IntPtr jnienv, IntPtr native__this, IntPtr native_source, long byteCount)
		{
			ForwardingSink forwardingSink = Java.Lang.Object.GetObject<ForwardingSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OkBuffer source = Java.Lang.Object.GetObject<OkBuffer>(native_source, JniHandleOwnership.DoNotTransfer);
			forwardingSink.Write(source, byteCount);
		}

		[Register("write", "(Lokio/Buffer;J)V", "GetWrite_Lokio_Buffer_JHandler")]
		public unsafe virtual void Write(OkBuffer source, long byteCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(byteCount);
				_members.InstanceMethods.InvokeVirtualVoidMethod("write.(Lokio/Buffer;J)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}
	}
	[Register("okio/ForwardingSink", DoNotGenerateAcw = true)]
	internal class ForwardingSinkInvoker : ForwardingSink
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/ForwardingSink", typeof(ForwardingSinkInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public ForwardingSinkInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("okio/ForwardingSource", DoNotGenerateAcw = true)]
	public abstract class ForwardingSource : Java.Lang.Object, ISource, ICloseable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/ForwardingSource", typeof(ForwardingSource));

		private static Delegate cb_close;

		private static Delegate cb_read_Lokio_Buffer_J;

		private static Delegate cb_timeout;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected ForwardingSource(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lokio/Source;)V", "")]
		public unsafe ForwardingSource(ISource @delegate)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((@delegate == null) ? IntPtr.Zero : ((Java.Lang.Object)@delegate).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lokio/Source;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lokio/Source;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@delegate);
			}
		}

		private static Delegate GetCloseHandler()
		{
			if ((object)cb_close == null)
			{
				cb_close = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Close));
			}
			return cb_close;
		}

		private static void n_Close(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ForwardingSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
		}

		[Register("close", "()V", "GetCloseHandler")]
		public unsafe virtual void Close()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("close.()V", this, null);
		}

		[Register("delegate", "()Lokio/Source;", "")]
		public unsafe ISource Delegate()
		{
			return Java.Lang.Object.GetObject<ISource>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("delegate.()Lokio/Source;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetRead_Lokio_Buffer_JHandler()
		{
			if ((object)cb_read_Lokio_Buffer_J == null)
			{
				cb_read_Lokio_Buffer_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLJ_J(n_Read_Lokio_Buffer_J));
			}
			return cb_read_Lokio_Buffer_J;
		}

		private static long n_Read_Lokio_Buffer_J(IntPtr jnienv, IntPtr native__this, IntPtr native_sink, long byteCount)
		{
			ForwardingSource forwardingSource = Java.Lang.Object.GetObject<ForwardingSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OkBuffer sink = Java.Lang.Object.GetObject<OkBuffer>(native_sink, JniHandleOwnership.DoNotTransfer);
			return forwardingSource.Read(sink, byteCount);
		}

		[Register("read", "(Lokio/Buffer;J)J", "GetRead_Lokio_Buffer_JHandler")]
		public unsafe virtual long Read(OkBuffer sink, long byteCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(sink?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(byteCount);
				return _members.InstanceMethods.InvokeVirtualInt64Method("read.(Lokio/Buffer;J)J", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sink);
			}
		}

		private static Delegate GetTimeoutHandler()
		{
			if ((object)cb_timeout == null)
			{
				cb_timeout = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Timeout));
			}
			return cb_timeout;
		}

		private static IntPtr n_Timeout(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ForwardingSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Timeout());
		}

		[Register("timeout", "()Lokio/Timeout;", "GetTimeoutHandler")]
		public unsafe virtual Timeout Timeout()
		{
			return Java.Lang.Object.GetObject<Timeout>(_members.InstanceMethods.InvokeVirtualObjectMethod("timeout.()Lokio/Timeout;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okio/ForwardingSource", DoNotGenerateAcw = true)]
	internal class ForwardingSourceInvoker : ForwardingSource
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/ForwardingSource", typeof(ForwardingSourceInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public ForwardingSourceInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
	[Register("okio/ForwardingTimeout", DoNotGenerateAcw = true)]
	public class ForwardingTimeout : Timeout
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/ForwardingTimeout", typeof(ForwardingTimeout));

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		protected ForwardingTimeout(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lokio/Timeout;)V", "")]
		public unsafe ForwardingTimeout(Timeout @delegate)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(@delegate?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lokio/Timeout;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lokio/Timeout;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(@delegate);
			}
		}

		[Register("delegate", "()Lokio/Timeout;", "")]
		public unsafe Timeout Delegate()
		{
			return Java.Lang.Object.GetObject<Timeout>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("delegate.()Lokio/Timeout;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("setDelegate", "(Lokio/Timeout;)Lokio/ForwardingTimeout;", "")]
		public unsafe ForwardingTimeout SetDelegate(Timeout @delegate)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(@delegate?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ForwardingTimeout>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setDelegate.(Lokio/Timeout;)Lokio/ForwardingTimeout;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(@delegate);
			}
		}
	}
	[Register("okio/GzipSink", DoNotGenerateAcw = true)]
	public sealed class GzipSink : Java.Lang.Object, ISink, ICloseable, IJavaObject, IDisposable, IJavaPeerable, IFlushable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/GzipSink", typeof(GzipSink));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal GzipSink(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lokio/Sink;)V", "")]
		public unsafe GzipSink(ISink sink)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lokio/Sink;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lokio/Sink;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sink);
			}
		}

		[Register("close", "()V", "")]
		public unsafe void Close()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("close.()V", this, null);
		}

		[Register("deflater", "()Ljava/util/zip/Deflater;", "")]
		public unsafe Deflater Deflater()
		{
			return Java.Lang.Object.GetObject<Deflater>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("deflater.()Ljava/util/zip/Deflater;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("flush", "()V", "")]
		public unsafe void Flush()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("flush.()V", this, null);
		}

		[Register("timeout", "()Lokio/Timeout;", "")]
		public unsafe Timeout Timeout()
		{
			return Java.Lang.Object.GetObject<Timeout>(_members.InstanceMethods.InvokeAbstractObjectMethod("timeout.()Lokio/Timeout;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("write", "(Lokio/Buffer;J)V", "")]
		public unsafe void Write(OkBuffer source, long byteCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(source?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(byteCount);
				_members.InstanceMethods.InvokeAbstractVoidMethod("write.(Lokio/Buffer;J)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}
	}
	[Register("okio/GzipSource", DoNotGenerateAcw = true)]
	public sealed class GzipSource : Java.Lang.Object, ISource, ICloseable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/GzipSource", typeof(GzipSource));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal GzipSource(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lokio/Source;)V", "")]
		public unsafe GzipSource(ISource source)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lokio/Source;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lokio/Source;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		[Register("close", "()V", "")]
		public unsafe void Close()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("close.()V", this, null);
		}

		[Register("read", "(Lokio/Buffer;J)J", "")]
		public unsafe long Read(OkBuffer sink, long byteCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(sink?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(byteCount);
				return _members.InstanceMethods.InvokeAbstractInt64Method("read.(Lokio/Buffer;J)J", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sink);
			}
		}

		[Register("timeout", "()Lokio/Timeout;", "")]
		public unsafe Timeout Timeout()
		{
			return Java.Lang.Object.GetObject<Timeout>(_members.InstanceMethods.InvokeAbstractObjectMethod("timeout.()Lokio/Timeout;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okio/HashingSink", DoNotGenerateAcw = true)]
	public sealed class HashingSink : ForwardingSink, ISink, ICloseable, IJavaObject, IDisposable, IJavaPeerable, IFlushable
	{
		[Register("okio/HashingSink$Companion", DoNotGenerateAcw = true)]
		public sealed class CompanionStatic : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("okio/HashingSink$Companion", typeof(CompanionStatic));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal CompanionStatic(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("hmacSha1", "(Lokio/Sink;Lokio/ByteString;)Lokio/HashingSink;", "")]
			public unsafe HashingSink HmacSha1(ISink sink, ByteString key)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
					ptr[1] = new JniArgumentValue(key?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<HashingSink>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("hmacSha1.(Lokio/Sink;Lokio/ByteString;)Lokio/HashingSink;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(sink);
					GC.KeepAlive(key);
				}
			}

			[Register("hmacSha256", "(Lokio/Sink;Lokio/ByteString;)Lokio/HashingSink;", "")]
			public unsafe HashingSink HmacSha256(ISink sink, ByteString key)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
					ptr[1] = new JniArgumentValue(key?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<HashingSink>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("hmacSha256.(Lokio/Sink;Lokio/ByteString;)Lokio/HashingSink;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(sink);
					GC.KeepAlive(key);
				}
			}

			[Register("hmacSha512", "(Lokio/Sink;Lokio/ByteString;)Lokio/HashingSink;", "")]
			public unsafe HashingSink HmacSha512(ISink sink, ByteString key)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
					ptr[1] = new JniArgumentValue(key?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<HashingSink>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("hmacSha512.(Lokio/Sink;Lokio/ByteString;)Lokio/HashingSink;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(sink);
					GC.KeepAlive(key);
				}
			}

			[Register("md5", "(Lokio/Sink;)Lokio/HashingSink;", "")]
			public unsafe HashingSink Md5(ISink sink)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
					return Java.Lang.Object.GetObject<HashingSink>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("md5.(Lokio/Sink;)Lokio/HashingSink;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(sink);
				}
			}

			[Register("sha1", "(Lokio/Sink;)Lokio/HashingSink;", "")]
			public unsafe HashingSink Sha1(ISink sink)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
					return Java.Lang.Object.GetObject<HashingSink>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("sha1.(Lokio/Sink;)Lokio/HashingSink;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(sink);
				}
			}

			[Register("sha256", "(Lokio/Sink;)Lokio/HashingSink;", "")]
			public unsafe HashingSink Sha256(ISink sink)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
					return Java.Lang.Object.GetObject<HashingSink>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("sha256.(Lokio/Sink;)Lokio/HashingSink;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(sink);
				}
			}

			[Register("sha512", "(Lokio/Sink;)Lokio/HashingSink;", "")]
			public unsafe HashingSink Sha512(ISink sink)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
					return Java.Lang.Object.GetObject<HashingSink>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("sha512.(Lokio/Sink;)Lokio/HashingSink;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(sink);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/HashingSink", typeof(HashingSink));

		[Register("Companion")]
		public static CompanionStatic Companion => Java.Lang.Object.GetObject<CompanionStatic>(_members.StaticFields.GetObjectValue("Companion.Lokio/HashingSink$Companion;").Handle, JniHandleOwnership.TransferLocalRef);

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal HashingSink(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("hash", "()Lokio/ByteString;", "")]
		public unsafe ByteString Hash()
		{
			return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("hash.()Lokio/ByteString;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("hmacSha1", "(Lokio/Sink;Lokio/ByteString;)Lokio/HashingSink;", "")]
		public unsafe static HashingSink HmacSha1(ISink sink, ByteString key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
				ptr[1] = new JniArgumentValue(key?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<HashingSink>(_members.StaticMethods.InvokeObjectMethod("hmacSha1.(Lokio/Sink;Lokio/ByteString;)Lokio/HashingSink;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(sink);
				GC.KeepAlive(key);
			}
		}

		[Register("hmacSha256", "(Lokio/Sink;Lokio/ByteString;)Lokio/HashingSink;", "")]
		public unsafe static HashingSink HmacSha256(ISink sink, ByteString key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
				ptr[1] = new JniArgumentValue(key?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<HashingSink>(_members.StaticMethods.InvokeObjectMethod("hmacSha256.(Lokio/Sink;Lokio/ByteString;)Lokio/HashingSink;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(sink);
				GC.KeepAlive(key);
			}
		}

		[Register("hmacSha512", "(Lokio/Sink;Lokio/ByteString;)Lokio/HashingSink;", "")]
		public unsafe static HashingSink HmacSha512(ISink sink, ByteString key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
				ptr[1] = new JniArgumentValue(key?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<HashingSink>(_members.StaticMethods.InvokeObjectMethod("hmacSha512.(Lokio/Sink;Lokio/ByteString;)Lokio/HashingSink;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(sink);
				GC.KeepAlive(key);
			}
		}

		[Register("md5", "(Lokio/Sink;)Lokio/HashingSink;", "")]
		public unsafe static HashingSink Md5(ISink sink)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
				return Java.Lang.Object.GetObject<HashingSink>(_members.StaticMethods.InvokeObjectMethod("md5.(Lokio/Sink;)Lokio/HashingSink;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(sink);
			}
		}

		[Register("sha1", "(Lokio/Sink;)Lokio/HashingSink;", "")]
		public unsafe static HashingSink Sha1(ISink sink)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
				return Java.Lang.Object.GetObject<HashingSink>(_members.StaticMethods.InvokeObjectMethod("sha1.(Lokio/Sink;)Lokio/HashingSink;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(sink);
			}
		}

		[Register("sha256", "(Lokio/Sink;)Lokio/HashingSink;", "")]
		public unsafe static HashingSink Sha256(ISink sink)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
				return Java.Lang.Object.GetObject<HashingSink>(_members.StaticMethods.InvokeObjectMethod("sha256.(Lokio/Sink;)Lokio/HashingSink;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(sink);
			}
		}

		[Register("sha512", "(Lokio/Sink;)Lokio/HashingSink;", "")]
		public unsafe static HashingSink Sha512(ISink sink)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
				return Java.Lang.Object.GetObject<HashingSink>(_members.StaticMethods.InvokeObjectMethod("sha512.(Lokio/Sink;)Lokio/HashingSink;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(sink);
			}
		}
	}
	[Register("okio/HashingSource", DoNotGenerateAcw = true)]
	public sealed class HashingSource : ForwardingSource, ISource, ICloseable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("okio/HashingSource$Companion", DoNotGenerateAcw = true)]
		public sealed class CompanionStatic : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("okio/HashingSource$Companion", typeof(CompanionStatic));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal CompanionStatic(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("hmacSha1", "(Lokio/Source;Lokio/ByteString;)Lokio/HashingSource;", "")]
			public unsafe HashingSource HmacSha1(ISource source, ByteString key)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
					ptr[1] = new JniArgumentValue(key?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<HashingSource>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("hmacSha1.(Lokio/Source;Lokio/ByteString;)Lokio/HashingSource;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(source);
					GC.KeepAlive(key);
				}
			}

			[Register("hmacSha256", "(Lokio/Source;Lokio/ByteString;)Lokio/HashingSource;", "")]
			public unsafe HashingSource HmacSha256(ISource source, ByteString key)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
					ptr[1] = new JniArgumentValue(key?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<HashingSource>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("hmacSha256.(Lokio/Source;Lokio/ByteString;)Lokio/HashingSource;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(source);
					GC.KeepAlive(key);
				}
			}

			[Register("hmacSha512", "(Lokio/Source;Lokio/ByteString;)Lokio/HashingSource;", "")]
			public unsafe HashingSource HmacSha512(ISource source, ByteString key)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
					*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
					ptr[1] = new JniArgumentValue(key?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<HashingSource>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("hmacSha512.(Lokio/Source;Lokio/ByteString;)Lokio/HashingSource;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(source);
					GC.KeepAlive(key);
				}
			}

			[Register("md5", "(Lokio/Source;)Lokio/HashingSource;", "")]
			public unsafe HashingSource Md5(ISource source)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
					return Java.Lang.Object.GetObject<HashingSource>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("md5.(Lokio/Source;)Lokio/HashingSource;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(source);
				}
			}

			[Register("sha1", "(Lokio/Source;)Lokio/HashingSource;", "")]
			public unsafe HashingSource Sha1(ISource source)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
					return Java.Lang.Object.GetObject<HashingSource>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("sha1.(Lokio/Source;)Lokio/HashingSource;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(source);
				}
			}

			[Register("sha256", "(Lokio/Source;)Lokio/HashingSource;", "")]
			public unsafe HashingSource Sha256(ISource source)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
					return Java.Lang.Object.GetObject<HashingSource>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("sha256.(Lokio/Source;)Lokio/HashingSource;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(source);
				}
			}

			[Register("sha512", "(Lokio/Source;)Lokio/HashingSource;", "")]
			public unsafe HashingSource Sha512(ISource source)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
					return Java.Lang.Object.GetObject<HashingSource>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("sha512.(Lokio/Source;)Lokio/HashingSource;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(source);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/HashingSource", typeof(HashingSource));

		[Register("Companion")]
		public static CompanionStatic Companion => Java.Lang.Object.GetObject<CompanionStatic>(_members.StaticFields.GetObjectValue("Companion.Lokio/HashingSource$Companion;").Handle, JniHandleOwnership.TransferLocalRef);

		internal new static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal HashingSource(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("hash", "()Lokio/ByteString;", "")]
		public unsafe ByteString Hash()
		{
			return Java.Lang.Object.GetObject<ByteString>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("hash.()Lokio/ByteString;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("hmacSha1", "(Lokio/Source;Lokio/ByteString;)Lokio/HashingSource;", "")]
		public unsafe static HashingSource HmacSha1(ISource source, ByteString key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
				ptr[1] = new JniArgumentValue(key?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<HashingSource>(_members.StaticMethods.InvokeObjectMethod("hmacSha1.(Lokio/Source;Lokio/ByteString;)Lokio/HashingSource;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(source);
				GC.KeepAlive(key);
			}
		}

		[Register("hmacSha256", "(Lokio/Source;Lokio/ByteString;)Lokio/HashingSource;", "")]
		public unsafe static HashingSource HmacSha256(ISource source, ByteString key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
				ptr[1] = new JniArgumentValue(key?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<HashingSource>(_members.StaticMethods.InvokeObjectMethod("hmacSha256.(Lokio/Source;Lokio/ByteString;)Lokio/HashingSource;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(source);
				GC.KeepAlive(key);
			}
		}

		[Register("hmacSha512", "(Lokio/Source;Lokio/ByteString;)Lokio/HashingSource;", "")]
		public unsafe static HashingSource HmacSha512(ISource source, ByteString key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
				ptr[1] = new JniArgumentValue(key?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<HashingSource>(_members.StaticMethods.InvokeObjectMethod("hmacSha512.(Lokio/Source;Lokio/ByteString;)Lokio/HashingSource;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(source);
				GC.KeepAlive(key);
			}
		}

		[Register("md5", "(Lokio/Source;)Lokio/HashingSource;", "")]
		public unsafe static HashingSource Md5(ISource source)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
				return Java.Lang.Object.GetObject<HashingSource>(_members.StaticMethods.InvokeObjectMethod("md5.(Lokio/Source;)Lokio/HashingSource;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		[Register("sha1", "(Lokio/Source;)Lokio/HashingSource;", "")]
		public unsafe static HashingSource Sha1(ISource source)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
				return Java.Lang.Object.GetObject<HashingSource>(_members.StaticMethods.InvokeObjectMethod("sha1.(Lokio/Source;)Lokio/HashingSource;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		[Register("sha256", "(Lokio/Source;)Lokio/HashingSource;", "")]
		public unsafe static HashingSource Sha256(ISource source)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
				return Java.Lang.Object.GetObject<HashingSource>(_members.StaticMethods.InvokeObjectMethod("sha256.(Lokio/Source;)Lokio/HashingSource;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		[Register("sha512", "(Lokio/Source;)Lokio/HashingSource;", "")]
		public unsafe static HashingSource Sha512(ISource source)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
				return Java.Lang.Object.GetObject<HashingSource>(_members.StaticMethods.InvokeObjectMethod("sha512.(Lokio/Source;)Lokio/HashingSource;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}
	}
	[Register("okio/BufferedSink", "", "Square.OkIO.IBufferedSinkInvoker")]
	public interface IBufferedSink : IWritableByteChannel, IChannel, ICloseable, IJavaObject, IDisposable, IJavaPeerable, ISink, IFlushable
	{
		OkBuffer Buffer
		{
			[Register("buffer", "()Lokio/Buffer;", "GetGetBufferObsoleteHandler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
			get;
		}

		Stream OutputStream
		{
			[Register("outputStream", "()Ljava/io/OutputStream;", "GetGetOutputStreamHandler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
			get;
		}

		[Register("emit", "()Lokio/BufferedSink;", "GetEmitHandler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		IBufferedSink Emit();

		[Register("emitCompleteSegments", "()Lokio/BufferedSink;", "GetEmitCompleteSegmentsHandler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		IBufferedSink EmitCompleteSegments();

		[Register("flush", "()V", "GetFlushHandler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		new void Flush();

		[Register("getBuffer", "()Lokio/Buffer;", "GetGetBufferHandler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		OkBuffer GetBuffer();

		[Register("write", "([B)Lokio/BufferedSink;", "GetWrite_arrayBHandler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		IBufferedSink Write(byte[] source);

		[Register("write", "([BII)Lokio/BufferedSink;", "GetWrite_arrayBIIHandler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		IBufferedSink Write(byte[] source, int offset, int byteCount);

		[Register("write", "(Lokio/ByteString;)Lokio/BufferedSink;", "GetWrite_Lokio_ByteString_Handler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		IBufferedSink Write(ByteString byteString);

		[Register("write", "(Lokio/ByteString;II)Lokio/BufferedSink;", "GetWrite_Lokio_ByteString_IIHandler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		IBufferedSink Write(ByteString byteString, int offset, int byteCount);

		[Register("write", "(Lokio/Source;J)Lokio/BufferedSink;", "GetWrite_Lokio_Source_JHandler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		IBufferedSink Write(ISource source, long byteCount);

		[Register("writeAll", "(Lokio/Source;)J", "GetWriteAll_Lokio_Source_Handler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		long WriteAll(ISource source);

		[Register("writeByte", "(I)Lokio/BufferedSink;", "GetWriteByte_IHandler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		IBufferedSink WriteByte(int b);

		[Register("writeDecimalLong", "(J)Lokio/BufferedSink;", "GetWriteDecimalLong_JHandler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		IBufferedSink WriteDecimalLong(long v);

		[Register("writeHexadecimalUnsignedLong", "(J)Lokio/BufferedSink;", "GetWriteHexadecimalUnsignedLong_JHandler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		IBufferedSink WriteHexadecimalUnsignedLong(long v);

		[Register("writeInt", "(I)Lokio/BufferedSink;", "GetWriteInt_IHandler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		IBufferedSink WriteInt(int i);

		[Register("writeIntLe", "(I)Lokio/BufferedSink;", "GetWriteIntLe_IHandler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		IBufferedSink WriteIntLe(int i);

		[Register("writeLong", "(J)Lokio/BufferedSink;", "GetWriteLong_JHandler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		IBufferedSink WriteLong(long v);

		[Register("writeLongLe", "(J)Lokio/BufferedSink;", "GetWriteLongLe_JHandler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		IBufferedSink WriteLongLe(long v);

		[Register("writeShort", "(I)Lokio/BufferedSink;", "GetWriteShort_IHandler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		IBufferedSink WriteShort(int s);

		[Register("writeShortLe", "(I)Lokio/BufferedSink;", "GetWriteShortLe_IHandler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		IBufferedSink WriteShortLe(int s);

		[Register("writeString", "(Ljava/lang/String;IILjava/nio/charset/Charset;)Lokio/BufferedSink;", "GetWriteString_Ljava_lang_String_IILjava_nio_charset_Charset_Handler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		IBufferedSink WriteString(string str, int beginIndex, int endIndex, Charset charset);

		[Register("writeString", "(Ljava/lang/String;Ljava/nio/charset/Charset;)Lokio/BufferedSink;", "GetWriteString_Ljava_lang_String_Ljava_nio_charset_Charset_Handler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		IBufferedSink WriteString(string str, Charset charset);

		[Register("writeUtf8", "(Ljava/lang/String;)Lokio/BufferedSink;", "GetWriteUtf8_Ljava_lang_String_Handler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		IBufferedSink WriteUtf8(string str);

		[Register("writeUtf8", "(Ljava/lang/String;II)Lokio/BufferedSink;", "GetWriteUtf8_Ljava_lang_String_IIHandler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		IBufferedSink WriteUtf8(string str, int beginIndex, int endIndex);

		[Register("writeUtf8CodePoint", "(I)Lokio/BufferedSink;", "GetWriteUtf8CodePoint_IHandler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		IBufferedSink WriteUtf8CodePoint(int codePoint);

		[Register("close", "()V", "GetCloseHandler:Square.OkIO.IBufferedSinkInvoker, Square.OkIO")]
		new void Close();
	}
	[Register("okio/BufferedSink", DoNotGenerateAcw = true)]
	internal class IBufferedSinkInvoker : Java.Lang.Object, IBufferedSink, IWritableByteChannel, IChannel, ICloseable, IJavaObject, IDisposable, IJavaPeerable, ISink, IFlushable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/BufferedSink", typeof(IBufferedSinkInvoker));

		private IntPtr class_ref;

		private static Delegate cb_buffer;

		private IntPtr id_buffer;

		private static Delegate cb_outputStream;

		private IntPtr id_outputStream;

		private static Delegate cb_emit;

		private IntPtr id_emit;

		private static Delegate cb_emitCompleteSegments;

		private IntPtr id_emitCompleteSegments;

		private static Delegate cb_flush;

		private IntPtr id_flush;

		private static Delegate cb_getBuffer;

		private IntPtr id_getBuffer;

		private static Delegate cb_write_arrayB;

		private IntPtr id_write_arrayB;

		private static Delegate cb_write_arrayBII;

		private IntPtr id_write_arrayBII;

		private static Delegate cb_write_Lokio_ByteString_;

		private IntPtr id_write_Lokio_ByteString_;

		private static Delegate cb_write_Lokio_ByteString_II;

		private IntPtr id_write_Lokio_ByteString_II;

		private static Delegate cb_write_Lokio_Source_J;

		private IntPtr id_write_Lokio_Source_J;

		private static Delegate cb_writeAll_Lokio_Source_;

		private IntPtr id_writeAll_Lokio_Source_;

		private static Delegate cb_writeByte_I;

		private IntPtr id_writeByte_I;

		private static Delegate cb_writeDecimalLong_J;

		private IntPtr id_writeDecimalLong_J;

		private static Delegate cb_writeHexadecimalUnsignedLong_J;

		private IntPtr id_writeHexadecimalUnsignedLong_J;

		private static Delegate cb_writeInt_I;

		private IntPtr id_writeInt_I;

		private static Delegate cb_writeIntLe_I;

		private IntPtr id_writeIntLe_I;

		private static Delegate cb_writeLong_J;

		private IntPtr id_writeLong_J;

		private static Delegate cb_writeLongLe_J;

		private IntPtr id_writeLongLe_J;

		private static Delegate cb_writeShort_I;

		private IntPtr id_writeShort_I;

		private static Delegate cb_writeShortLe_I;

		private IntPtr id_writeShortLe_I;

		private static Delegate cb_writeString_Ljava_lang_String_IILjava_nio_charset_Charset_;

		private IntPtr id_writeString_Ljava_lang_String_IILjava_nio_charset_Charset_;

		private static Delegate cb_writeString_Ljava_lang_String_Ljava_nio_charset_Charset_;

		private IntPtr id_writeString_Ljava_lang_String_Ljava_nio_charset_Charset_;

		private static Delegate cb_writeUtf8_Ljava_lang_String_;

		private IntPtr id_writeUtf8_Ljava_lang_String_;

		private static Delegate cb_writeUtf8_Ljava_lang_String_II;

		private IntPtr id_writeUtf8_Ljava_lang_String_II;

		private static Delegate cb_writeUtf8CodePoint_I;

		private IntPtr id_writeUtf8CodePoint_I;

		private static Delegate cb_close;

		private IntPtr id_close;

		private static Delegate cb_write_Ljava_nio_ByteBuffer_;

		private IntPtr id_write_Ljava_nio_ByteBuffer_;

		private static Delegate cb_isOpen;

		private IntPtr id_isOpen;

		private static Delegate cb_timeout;

		private IntPtr id_timeout;

		private static Delegate cb_write_Lokio_Buffer_J;

		private IntPtr id_write_Lokio_Buffer_J;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public OkBuffer Buffer
		{
			get
			{
				if (id_buffer == IntPtr.Zero)
				{
					id_buffer = JNIEnv.GetMethodID(class_ref, "buffer", "()Lokio/Buffer;");
				}
				return Java.Lang.Object.GetObject<OkBuffer>(JNIEnv.CallObjectMethod(base.Handle, id_buffer), JniHandleOwnership.TransferLocalRef);
			}
		}

		public Stream OutputStream
		{
			get
			{
				if (id_outputStream == IntPtr.Zero)
				{
					id_outputStream = JNIEnv.GetMethodID(class_ref, "outputStream", "()Ljava/io/OutputStream;");
				}
				return OutputStreamInvoker.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_outputStream), JniHandleOwnership.TransferLocalRef);
			}
		}

		public bool IsOpen
		{
			get
			{
				if (id_isOpen == IntPtr.Zero)
				{
					id_isOpen = JNIEnv.GetMethodID(class_ref, "isOpen", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_isOpen);
			}
		}

		public static IBufferedSink GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IBufferedSink>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "okio.BufferedSink"));
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

		public IBufferedSinkInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		[Obsolete]
		private static Delegate GetGetBufferObsoleteHandler()
		{
			if ((object)cb_buffer == null)
			{
				cb_buffer = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBufferObsolete));
			}
			return cb_buffer;
		}

		[Obsolete]
		private static IntPtr n_GetBufferObsolete(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Buffer);
		}

		private static Delegate GetGetOutputStreamHandler()
		{
			if ((object)cb_outputStream == null)
			{
				cb_outputStream = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOutputStream));
			}
			return cb_outputStream;
		}

		private static IntPtr n_GetOutputStream(IntPtr jnienv, IntPtr native__this)
		{
			return OutputStreamAdapter.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OutputStream);
		}

		private static Delegate GetEmitHandler()
		{
			if ((object)cb_emit == null)
			{
				cb_emit = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Emit));
			}
			return cb_emit;
		}

		private static IntPtr n_Emit(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Emit());
		}

		public IBufferedSink Emit()
		{
			if (id_emit == IntPtr.Zero)
			{
				id_emit = JNIEnv.GetMethodID(class_ref, "emit", "()Lokio/BufferedSink;");
			}
			return Java.Lang.Object.GetObject<IBufferedSink>(JNIEnv.CallObjectMethod(base.Handle, id_emit), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetEmitCompleteSegmentsHandler()
		{
			if ((object)cb_emitCompleteSegments == null)
			{
				cb_emitCompleteSegments = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_EmitCompleteSegments));
			}
			return cb_emitCompleteSegments;
		}

		private static IntPtr n_EmitCompleteSegments(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).EmitCompleteSegments());
		}

		public IBufferedSink EmitCompleteSegments()
		{
			if (id_emitCompleteSegments == IntPtr.Zero)
			{
				id_emitCompleteSegments = JNIEnv.GetMethodID(class_ref, "emitCompleteSegments", "()Lokio/BufferedSink;");
			}
			return Java.Lang.Object.GetObject<IBufferedSink>(JNIEnv.CallObjectMethod(base.Handle, id_emitCompleteSegments), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetFlushHandler()
		{
			if ((object)cb_flush == null)
			{
				cb_flush = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Flush));
			}
			return cb_flush;
		}

		private static void n_Flush(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Flush();
		}

		public void Flush()
		{
			if (id_flush == IntPtr.Zero)
			{
				id_flush = JNIEnv.GetMethodID(class_ref, "flush", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_flush);
		}

		private static Delegate GetGetBufferHandler()
		{
			if ((object)cb_getBuffer == null)
			{
				cb_getBuffer = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBuffer));
			}
			return cb_getBuffer;
		}

		private static IntPtr n_GetBuffer(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetBuffer());
		}

		public OkBuffer GetBuffer()
		{
			if (id_getBuffer == IntPtr.Zero)
			{
				id_getBuffer = JNIEnv.GetMethodID(class_ref, "getBuffer", "()Lokio/Buffer;");
			}
			return Java.Lang.Object.GetObject<OkBuffer>(JNIEnv.CallObjectMethod(base.Handle, id_getBuffer), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWrite_arrayBHandler()
		{
			if ((object)cb_write_arrayB == null)
			{
				cb_write_arrayB = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Write_arrayB));
			}
			return cb_write_arrayB;
		}

		private static IntPtr n_Write_arrayB(IntPtr jnienv, IntPtr native__this, IntPtr native_source)
		{
			IBufferedSink bufferedSink = Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_source, JniHandleOwnership.DoNotTransfer, typeof(byte));
			IntPtr result = JNIEnv.ToLocalJniHandle(bufferedSink.Write(array));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_source);
			}
			return result;
		}

		public unsafe IBufferedSink Write(byte[] source)
		{
			if (id_write_arrayB == IntPtr.Zero)
			{
				id_write_arrayB = JNIEnv.GetMethodID(class_ref, "write", "([B)Lokio/BufferedSink;");
			}
			IntPtr intPtr = JNIEnv.NewArray(source);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			IBufferedSink result = Java.Lang.Object.GetObject<IBufferedSink>(JNIEnv.CallObjectMethod(base.Handle, id_write_arrayB, ptr), JniHandleOwnership.TransferLocalRef);
			if (source != null)
			{
				JNIEnv.CopyArray(intPtr, source);
				JNIEnv.DeleteLocalRef(intPtr);
			}
			return result;
		}

		private static Delegate GetWrite_arrayBIIHandler()
		{
			if ((object)cb_write_arrayBII == null)
			{
				cb_write_arrayBII = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_L(n_Write_arrayBII));
			}
			return cb_write_arrayBII;
		}

		private static IntPtr n_Write_arrayBII(IntPtr jnienv, IntPtr native__this, IntPtr native_source, int offset, int byteCount)
		{
			IBufferedSink bufferedSink = Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_source, JniHandleOwnership.DoNotTransfer, typeof(byte));
			IntPtr result = JNIEnv.ToLocalJniHandle(bufferedSink.Write(array, offset, byteCount));
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_source);
			}
			return result;
		}

		public unsafe IBufferedSink Write(byte[] source, int offset, int byteCount)
		{
			if (id_write_arrayBII == IntPtr.Zero)
			{
				id_write_arrayBII = JNIEnv.GetMethodID(class_ref, "write", "([BII)Lokio/BufferedSink;");
			}
			IntPtr intPtr = JNIEnv.NewArray(source);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(offset);
			ptr[2] = new JValue(byteCount);
			IBufferedSink result = Java.Lang.Object.GetObject<IBufferedSink>(JNIEnv.CallObjectMethod(base.Handle, id_write_arrayBII, ptr), JniHandleOwnership.TransferLocalRef);
			if (source != null)
			{
				JNIEnv.CopyArray(intPtr, source);
				JNIEnv.DeleteLocalRef(intPtr);
			}
			return result;
		}

		private static Delegate GetWrite_Lokio_ByteString_Handler()
		{
			if ((object)cb_write_Lokio_ByteString_ == null)
			{
				cb_write_Lokio_ByteString_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Write_Lokio_ByteString_));
			}
			return cb_write_Lokio_ByteString_;
		}

		private static IntPtr n_Write_Lokio_ByteString_(IntPtr jnienv, IntPtr native__this, IntPtr native_byteString)
		{
			IBufferedSink bufferedSink = Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteString byteString = Java.Lang.Object.GetObject<ByteString>(native_byteString, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(bufferedSink.Write(byteString));
		}

		public unsafe IBufferedSink Write(ByteString byteString)
		{
			if (id_write_Lokio_ByteString_ == IntPtr.Zero)
			{
				id_write_Lokio_ByteString_ = JNIEnv.GetMethodID(class_ref, "write", "(Lokio/ByteString;)Lokio/BufferedSink;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(byteString?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IBufferedSink>(JNIEnv.CallObjectMethod(base.Handle, id_write_Lokio_ByteString_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWrite_Lokio_ByteString_IIHandler()
		{
			if ((object)cb_write_Lokio_ByteString_II == null)
			{
				cb_write_Lokio_ByteString_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_L(n_Write_Lokio_ByteString_II));
			}
			return cb_write_Lokio_ByteString_II;
		}

		private static IntPtr n_Write_Lokio_ByteString_II(IntPtr jnienv, IntPtr native__this, IntPtr native_byteString, int offset, int byteCount)
		{
			IBufferedSink bufferedSink = Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteString byteString = Java.Lang.Object.GetObject<ByteString>(native_byteString, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(bufferedSink.Write(byteString, offset, byteCount));
		}

		public unsafe IBufferedSink Write(ByteString byteString, int offset, int byteCount)
		{
			if (id_write_Lokio_ByteString_II == IntPtr.Zero)
			{
				id_write_Lokio_ByteString_II = JNIEnv.GetMethodID(class_ref, "write", "(Lokio/ByteString;II)Lokio/BufferedSink;");
			}
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(byteString?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(offset);
			ptr[2] = new JValue(byteCount);
			return Java.Lang.Object.GetObject<IBufferedSink>(JNIEnv.CallObjectMethod(base.Handle, id_write_Lokio_ByteString_II, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWrite_Lokio_Source_JHandler()
		{
			if ((object)cb_write_Lokio_Source_J == null)
			{
				cb_write_Lokio_Source_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLJ_L(n_Write_Lokio_Source_J));
			}
			return cb_write_Lokio_Source_J;
		}

		private static IntPtr n_Write_Lokio_Source_J(IntPtr jnienv, IntPtr native__this, IntPtr native_source, long byteCount)
		{
			IBufferedSink bufferedSink = Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISource source = Java.Lang.Object.GetObject<ISource>(native_source, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(bufferedSink.Write(source, byteCount));
		}

		public unsafe IBufferedSink Write(ISource source, long byteCount)
		{
			if (id_write_Lokio_Source_J == IntPtr.Zero)
			{
				id_write_Lokio_Source_J = JNIEnv.GetMethodID(class_ref, "write", "(Lokio/Source;J)Lokio/BufferedSink;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
			ptr[1] = new JValue(byteCount);
			return Java.Lang.Object.GetObject<IBufferedSink>(JNIEnv.CallObjectMethod(base.Handle, id_write_Lokio_Source_J, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWriteAll_Lokio_Source_Handler()
		{
			if ((object)cb_writeAll_Lokio_Source_ == null)
			{
				cb_writeAll_Lokio_Source_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_J(n_WriteAll_Lokio_Source_));
			}
			return cb_writeAll_Lokio_Source_;
		}

		private static long n_WriteAll_Lokio_Source_(IntPtr jnienv, IntPtr native__this, IntPtr native_source)
		{
			IBufferedSink bufferedSink = Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISource source = Java.Lang.Object.GetObject<ISource>(native_source, JniHandleOwnership.DoNotTransfer);
			return bufferedSink.WriteAll(source);
		}

		public unsafe long WriteAll(ISource source)
		{
			if (id_writeAll_Lokio_Source_ == IntPtr.Zero)
			{
				id_writeAll_Lokio_Source_ = JNIEnv.GetMethodID(class_ref, "writeAll", "(Lokio/Source;)J");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
			return JNIEnv.CallLongMethod(base.Handle, id_writeAll_Lokio_Source_, ptr);
		}

		private static Delegate GetWriteByte_IHandler()
		{
			if ((object)cb_writeByte_I == null)
			{
				cb_writeByte_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_WriteByte_I));
			}
			return cb_writeByte_I;
		}

		private static IntPtr n_WriteByte_I(IntPtr jnienv, IntPtr native__this, int b)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WriteByte(b));
		}

		public unsafe IBufferedSink WriteByte(int b)
		{
			if (id_writeByte_I == IntPtr.Zero)
			{
				id_writeByte_I = JNIEnv.GetMethodID(class_ref, "writeByte", "(I)Lokio/BufferedSink;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(b);
			return Java.Lang.Object.GetObject<IBufferedSink>(JNIEnv.CallObjectMethod(base.Handle, id_writeByte_I, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWriteDecimalLong_JHandler()
		{
			if ((object)cb_writeDecimalLong_J == null)
			{
				cb_writeDecimalLong_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_WriteDecimalLong_J));
			}
			return cb_writeDecimalLong_J;
		}

		private static IntPtr n_WriteDecimalLong_J(IntPtr jnienv, IntPtr native__this, long v)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WriteDecimalLong(v));
		}

		public unsafe IBufferedSink WriteDecimalLong(long v)
		{
			if (id_writeDecimalLong_J == IntPtr.Zero)
			{
				id_writeDecimalLong_J = JNIEnv.GetMethodID(class_ref, "writeDecimalLong", "(J)Lokio/BufferedSink;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(v);
			return Java.Lang.Object.GetObject<IBufferedSink>(JNIEnv.CallObjectMethod(base.Handle, id_writeDecimalLong_J, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWriteHexadecimalUnsignedLong_JHandler()
		{
			if ((object)cb_writeHexadecimalUnsignedLong_J == null)
			{
				cb_writeHexadecimalUnsignedLong_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_WriteHexadecimalUnsignedLong_J));
			}
			return cb_writeHexadecimalUnsignedLong_J;
		}

		private static IntPtr n_WriteHexadecimalUnsignedLong_J(IntPtr jnienv, IntPtr native__this, long v)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WriteHexadecimalUnsignedLong(v));
		}

		public unsafe IBufferedSink WriteHexadecimalUnsignedLong(long v)
		{
			if (id_writeHexadecimalUnsignedLong_J == IntPtr.Zero)
			{
				id_writeHexadecimalUnsignedLong_J = JNIEnv.GetMethodID(class_ref, "writeHexadecimalUnsignedLong", "(J)Lokio/BufferedSink;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(v);
			return Java.Lang.Object.GetObject<IBufferedSink>(JNIEnv.CallObjectMethod(base.Handle, id_writeHexadecimalUnsignedLong_J, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWriteInt_IHandler()
		{
			if ((object)cb_writeInt_I == null)
			{
				cb_writeInt_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_WriteInt_I));
			}
			return cb_writeInt_I;
		}

		private static IntPtr n_WriteInt_I(IntPtr jnienv, IntPtr native__this, int i)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WriteInt(i));
		}

		public unsafe IBufferedSink WriteInt(int i)
		{
			if (id_writeInt_I == IntPtr.Zero)
			{
				id_writeInt_I = JNIEnv.GetMethodID(class_ref, "writeInt", "(I)Lokio/BufferedSink;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(i);
			return Java.Lang.Object.GetObject<IBufferedSink>(JNIEnv.CallObjectMethod(base.Handle, id_writeInt_I, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWriteIntLe_IHandler()
		{
			if ((object)cb_writeIntLe_I == null)
			{
				cb_writeIntLe_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_WriteIntLe_I));
			}
			return cb_writeIntLe_I;
		}

		private static IntPtr n_WriteIntLe_I(IntPtr jnienv, IntPtr native__this, int i)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WriteIntLe(i));
		}

		public unsafe IBufferedSink WriteIntLe(int i)
		{
			if (id_writeIntLe_I == IntPtr.Zero)
			{
				id_writeIntLe_I = JNIEnv.GetMethodID(class_ref, "writeIntLe", "(I)Lokio/BufferedSink;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(i);
			return Java.Lang.Object.GetObject<IBufferedSink>(JNIEnv.CallObjectMethod(base.Handle, id_writeIntLe_I, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWriteLong_JHandler()
		{
			if ((object)cb_writeLong_J == null)
			{
				cb_writeLong_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_WriteLong_J));
			}
			return cb_writeLong_J;
		}

		private static IntPtr n_WriteLong_J(IntPtr jnienv, IntPtr native__this, long v)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WriteLong(v));
		}

		public unsafe IBufferedSink WriteLong(long v)
		{
			if (id_writeLong_J == IntPtr.Zero)
			{
				id_writeLong_J = JNIEnv.GetMethodID(class_ref, "writeLong", "(J)Lokio/BufferedSink;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(v);
			return Java.Lang.Object.GetObject<IBufferedSink>(JNIEnv.CallObjectMethod(base.Handle, id_writeLong_J, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWriteLongLe_JHandler()
		{
			if ((object)cb_writeLongLe_J == null)
			{
				cb_writeLongLe_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_WriteLongLe_J));
			}
			return cb_writeLongLe_J;
		}

		private static IntPtr n_WriteLongLe_J(IntPtr jnienv, IntPtr native__this, long v)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WriteLongLe(v));
		}

		public unsafe IBufferedSink WriteLongLe(long v)
		{
			if (id_writeLongLe_J == IntPtr.Zero)
			{
				id_writeLongLe_J = JNIEnv.GetMethodID(class_ref, "writeLongLe", "(J)Lokio/BufferedSink;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(v);
			return Java.Lang.Object.GetObject<IBufferedSink>(JNIEnv.CallObjectMethod(base.Handle, id_writeLongLe_J, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWriteShort_IHandler()
		{
			if ((object)cb_writeShort_I == null)
			{
				cb_writeShort_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_WriteShort_I));
			}
			return cb_writeShort_I;
		}

		private static IntPtr n_WriteShort_I(IntPtr jnienv, IntPtr native__this, int s)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WriteShort(s));
		}

		public unsafe IBufferedSink WriteShort(int s)
		{
			if (id_writeShort_I == IntPtr.Zero)
			{
				id_writeShort_I = JNIEnv.GetMethodID(class_ref, "writeShort", "(I)Lokio/BufferedSink;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(s);
			return Java.Lang.Object.GetObject<IBufferedSink>(JNIEnv.CallObjectMethod(base.Handle, id_writeShort_I, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWriteShortLe_IHandler()
		{
			if ((object)cb_writeShortLe_I == null)
			{
				cb_writeShortLe_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_WriteShortLe_I));
			}
			return cb_writeShortLe_I;
		}

		private static IntPtr n_WriteShortLe_I(IntPtr jnienv, IntPtr native__this, int s)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WriteShortLe(s));
		}

		public unsafe IBufferedSink WriteShortLe(int s)
		{
			if (id_writeShortLe_I == IntPtr.Zero)
			{
				id_writeShortLe_I = JNIEnv.GetMethodID(class_ref, "writeShortLe", "(I)Lokio/BufferedSink;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(s);
			return Java.Lang.Object.GetObject<IBufferedSink>(JNIEnv.CallObjectMethod(base.Handle, id_writeShortLe_I, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWriteString_Ljava_lang_String_IILjava_nio_charset_Charset_Handler()
		{
			if ((object)cb_writeString_Ljava_lang_String_IILjava_nio_charset_Charset_ == null)
			{
				cb_writeString_Ljava_lang_String_IILjava_nio_charset_Charset_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPLIIL_L(n_WriteString_Ljava_lang_String_IILjava_nio_charset_Charset_));
			}
			return cb_writeString_Ljava_lang_String_IILjava_nio_charset_Charset_;
		}

		private static IntPtr n_WriteString_Ljava_lang_String_IILjava_nio_charset_Charset_(IntPtr jnienv, IntPtr native__this, IntPtr native_str, int beginIndex, int endIndex, IntPtr native_charset)
		{
			IBufferedSink bufferedSink = Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string str = JNIEnv.GetString(native_str, JniHandleOwnership.DoNotTransfer);
			Charset charset = Java.Lang.Object.GetObject<Charset>(native_charset, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(bufferedSink.WriteString(str, beginIndex, endIndex, charset));
		}

		public unsafe IBufferedSink WriteString(string str, int beginIndex, int endIndex, Charset charset)
		{
			if (id_writeString_Ljava_lang_String_IILjava_nio_charset_Charset_ == IntPtr.Zero)
			{
				id_writeString_Ljava_lang_String_IILjava_nio_charset_Charset_ = JNIEnv.GetMethodID(class_ref, "writeString", "(Ljava/lang/String;IILjava/nio/charset/Charset;)Lokio/BufferedSink;");
			}
			IntPtr intPtr = JNIEnv.NewString(str);
			JValue* ptr = stackalloc JValue[4];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(beginIndex);
			ptr[2] = new JValue(endIndex);
			ptr[3] = new JValue(charset?.Handle ?? IntPtr.Zero);
			IBufferedSink result = Java.Lang.Object.GetObject<IBufferedSink>(JNIEnv.CallObjectMethod(base.Handle, id_writeString_Ljava_lang_String_IILjava_nio_charset_Charset_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetWriteString_Ljava_lang_String_Ljava_nio_charset_Charset_Handler()
		{
			if ((object)cb_writeString_Ljava_lang_String_Ljava_nio_charset_Charset_ == null)
			{
				cb_writeString_Ljava_lang_String_Ljava_nio_charset_Charset_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_WriteString_Ljava_lang_String_Ljava_nio_charset_Charset_));
			}
			return cb_writeString_Ljava_lang_String_Ljava_nio_charset_Charset_;
		}

		private static IntPtr n_WriteString_Ljava_lang_String_Ljava_nio_charset_Charset_(IntPtr jnienv, IntPtr native__this, IntPtr native_str, IntPtr native_charset)
		{
			IBufferedSink bufferedSink = Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string str = JNIEnv.GetString(native_str, JniHandleOwnership.DoNotTransfer);
			Charset charset = Java.Lang.Object.GetObject<Charset>(native_charset, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(bufferedSink.WriteString(str, charset));
		}

		public unsafe IBufferedSink WriteString(string str, Charset charset)
		{
			if (id_writeString_Ljava_lang_String_Ljava_nio_charset_Charset_ == IntPtr.Zero)
			{
				id_writeString_Ljava_lang_String_Ljava_nio_charset_Charset_ = JNIEnv.GetMethodID(class_ref, "writeString", "(Ljava/lang/String;Ljava/nio/charset/Charset;)Lokio/BufferedSink;");
			}
			IntPtr intPtr = JNIEnv.NewString(str);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(charset?.Handle ?? IntPtr.Zero);
			IBufferedSink result = Java.Lang.Object.GetObject<IBufferedSink>(JNIEnv.CallObjectMethod(base.Handle, id_writeString_Ljava_lang_String_Ljava_nio_charset_Charset_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetWriteUtf8_Ljava_lang_String_Handler()
		{
			if ((object)cb_writeUtf8_Ljava_lang_String_ == null)
			{
				cb_writeUtf8_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_WriteUtf8_Ljava_lang_String_));
			}
			return cb_writeUtf8_Ljava_lang_String_;
		}

		private static IntPtr n_WriteUtf8_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_str)
		{
			IBufferedSink bufferedSink = Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string str = JNIEnv.GetString(native_str, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(bufferedSink.WriteUtf8(str));
		}

		public unsafe IBufferedSink WriteUtf8(string str)
		{
			if (id_writeUtf8_Ljava_lang_String_ == IntPtr.Zero)
			{
				id_writeUtf8_Ljava_lang_String_ = JNIEnv.GetMethodID(class_ref, "writeUtf8", "(Ljava/lang/String;)Lokio/BufferedSink;");
			}
			IntPtr intPtr = JNIEnv.NewString(str);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			IBufferedSink result = Java.Lang.Object.GetObject<IBufferedSink>(JNIEnv.CallObjectMethod(base.Handle, id_writeUtf8_Ljava_lang_String_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetWriteUtf8_Ljava_lang_String_IIHandler()
		{
			if ((object)cb_writeUtf8_Ljava_lang_String_II == null)
			{
				cb_writeUtf8_Ljava_lang_String_II = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_L(n_WriteUtf8_Ljava_lang_String_II));
			}
			return cb_writeUtf8_Ljava_lang_String_II;
		}

		private static IntPtr n_WriteUtf8_Ljava_lang_String_II(IntPtr jnienv, IntPtr native__this, IntPtr native_str, int beginIndex, int endIndex)
		{
			IBufferedSink bufferedSink = Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string str = JNIEnv.GetString(native_str, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(bufferedSink.WriteUtf8(str, beginIndex, endIndex));
		}

		public unsafe IBufferedSink WriteUtf8(string str, int beginIndex, int endIndex)
		{
			if (id_writeUtf8_Ljava_lang_String_II == IntPtr.Zero)
			{
				id_writeUtf8_Ljava_lang_String_II = JNIEnv.GetMethodID(class_ref, "writeUtf8", "(Ljava/lang/String;II)Lokio/BufferedSink;");
			}
			IntPtr intPtr = JNIEnv.NewString(str);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(beginIndex);
			ptr[2] = new JValue(endIndex);
			IBufferedSink result = Java.Lang.Object.GetObject<IBufferedSink>(JNIEnv.CallObjectMethod(base.Handle, id_writeUtf8_Ljava_lang_String_II, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetWriteUtf8CodePoint_IHandler()
		{
			if ((object)cb_writeUtf8CodePoint_I == null)
			{
				cb_writeUtf8CodePoint_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_WriteUtf8CodePoint_I));
			}
			return cb_writeUtf8CodePoint_I;
		}

		private static IntPtr n_WriteUtf8CodePoint_I(IntPtr jnienv, IntPtr native__this, int codePoint)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WriteUtf8CodePoint(codePoint));
		}

		public unsafe IBufferedSink WriteUtf8CodePoint(int codePoint)
		{
			if (id_writeUtf8CodePoint_I == IntPtr.Zero)
			{
				id_writeUtf8CodePoint_I = JNIEnv.GetMethodID(class_ref, "writeUtf8CodePoint", "(I)Lokio/BufferedSink;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(codePoint);
			return Java.Lang.Object.GetObject<IBufferedSink>(JNIEnv.CallObjectMethod(base.Handle, id_writeUtf8CodePoint_I, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetCloseHandler()
		{
			if ((object)cb_close == null)
			{
				cb_close = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Close));
			}
			return cb_close;
		}

		private static void n_Close(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
		}

		public void Close()
		{
			if (id_close == IntPtr.Zero)
			{
				id_close = JNIEnv.GetMethodID(class_ref, "close", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_close);
		}

		private static Delegate GetWrite_Ljava_nio_ByteBuffer_Handler()
		{
			if ((object)cb_write_Ljava_nio_ByteBuffer_ == null)
			{
				cb_write_Ljava_nio_ByteBuffer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_Write_Ljava_nio_ByteBuffer_));
			}
			return cb_write_Ljava_nio_ByteBuffer_;
		}

		private static int n_Write_Ljava_nio_ByteBuffer_(IntPtr jnienv, IntPtr native__this, IntPtr native_src)
		{
			IBufferedSink bufferedSink = Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteBuffer src = Java.Lang.Object.GetObject<ByteBuffer>(native_src, JniHandleOwnership.DoNotTransfer);
			return bufferedSink.Write(src);
		}

		public unsafe int Write(ByteBuffer src)
		{
			if (id_write_Ljava_nio_ByteBuffer_ == IntPtr.Zero)
			{
				id_write_Ljava_nio_ByteBuffer_ = JNIEnv.GetMethodID(class_ref, "write", "(Ljava/nio/ByteBuffer;)I");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(src?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallIntMethod(base.Handle, id_write_Ljava_nio_ByteBuffer_, ptr);
		}

		private static Delegate GetIsOpenHandler()
		{
			if ((object)cb_isOpen == null)
			{
				cb_isOpen = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsOpen));
			}
			return cb_isOpen;
		}

		private static bool n_IsOpen(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsOpen;
		}

		private static Delegate GetTimeoutHandler()
		{
			if ((object)cb_timeout == null)
			{
				cb_timeout = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Timeout));
			}
			return cb_timeout;
		}

		private static IntPtr n_Timeout(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Timeout());
		}

		public Timeout Timeout()
		{
			if (id_timeout == IntPtr.Zero)
			{
				id_timeout = JNIEnv.GetMethodID(class_ref, "timeout", "()Lokio/Timeout;");
			}
			return Java.Lang.Object.GetObject<Timeout>(JNIEnv.CallObjectMethod(base.Handle, id_timeout), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWrite_Lokio_Buffer_JHandler()
		{
			if ((object)cb_write_Lokio_Buffer_J == null)
			{
				cb_write_Lokio_Buffer_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLJ_V(n_Write_Lokio_Buffer_J));
			}
			return cb_write_Lokio_Buffer_J;
		}

		private static void n_Write_Lokio_Buffer_J(IntPtr jnienv, IntPtr native__this, IntPtr native_source, long byteCount)
		{
			IBufferedSink bufferedSink = Java.Lang.Object.GetObject<IBufferedSink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OkBuffer source = Java.Lang.Object.GetObject<OkBuffer>(native_source, JniHandleOwnership.DoNotTransfer);
			bufferedSink.Write(source, byteCount);
		}

		public unsafe void Write(OkBuffer source, long byteCount)
		{
			if (id_write_Lokio_Buffer_J == IntPtr.Zero)
			{
				id_write_Lokio_Buffer_J = JNIEnv.GetMethodID(class_ref, "write", "(Lokio/Buffer;J)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(source?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(byteCount);
			JNIEnv.CallVoidMethod(base.Handle, id_write_Lokio_Buffer_J, ptr);
		}
	}
	[Register("okio/BufferedSource", "", "Square.OkIO.IBufferedSourceInvoker")]
	public interface IBufferedSource : IReadableByteChannel, IChannel, ICloseable, IJavaObject, IDisposable, IJavaPeerable, ISource
	{
		OkBuffer Buffer
		{
			[Register("buffer", "()Lokio/Buffer;", "GetGetBufferObsoleteHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
			get;
		}

		[Register("exhausted", "()Z", "GetExhaustedHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		bool Exhausted();

		[Register("getBuffer", "()Lokio/Buffer;", "GetGetBufferHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		OkBuffer GetBuffer();

		[Register("indexOf", "(B)J", "GetIndexOf_BHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		long IndexOf(sbyte b);

		[Register("indexOf", "(BJ)J", "GetIndexOf_BJHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		long IndexOf(sbyte b, long fromIndex);

		[Register("indexOf", "(BJJ)J", "GetIndexOf_BJJHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		long IndexOf(sbyte b, long fromIndex, long toIndex);

		[Register("indexOf", "(Lokio/ByteString;)J", "GetIndexOf_Lokio_ByteString_Handler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		long IndexOf(ByteString bytes);

		[Register("indexOf", "(Lokio/ByteString;J)J", "GetIndexOf_Lokio_ByteString_JHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		long IndexOf(ByteString bytes, long fromIndex);

		[Register("indexOfElement", "(Lokio/ByteString;)J", "GetIndexOfElement_Lokio_ByteString_Handler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		long IndexOfElement(ByteString targetBytes);

		[Register("indexOfElement", "(Lokio/ByteString;J)J", "GetIndexOfElement_Lokio_ByteString_JHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		long IndexOfElement(ByteString targetBytes, long fromIndex);

		[Register("inputStream", "()Ljava/io/InputStream;", "GetInputStreamHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		Stream InputStream();

		[Register("peek", "()Lokio/BufferedSource;", "GetPeekHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		IBufferedSource Peek();

		[Register("rangeEquals", "(JLokio/ByteString;)Z", "GetRangeEquals_JLokio_ByteString_Handler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		bool RangeEquals(long offset, ByteString bytes);

		[Register("rangeEquals", "(JLokio/ByteString;II)Z", "GetRangeEquals_JLokio_ByteString_IIHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		bool RangeEquals(long offset, ByteString bytes, int bytesOffset, int byteCount);

		[Register("read", "([B)I", "GetRead_arrayBHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		int Read(byte[] sink);

		[Register("read", "([BII)I", "GetRead_arrayBIIHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		int Read(byte[] sink, int offset, int byteCount);

		[Register("readAll", "(Lokio/Sink;)J", "GetReadAll_Lokio_Sink_Handler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		long ReadAll(ISink sink);

		[Register("readByte", "()B", "GetReadByteHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		sbyte ReadByte();

		[Register("readByteArray", "()[B", "GetReadByteArrayHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		byte[] ReadByteArray();

		[Register("readByteArray", "(J)[B", "GetReadByteArray_JHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		byte[] ReadByteArray(long byteCount);

		[Register("readByteString", "()Lokio/ByteString;", "GetReadByteStringHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		ByteString ReadByteString();

		[Register("readByteString", "(J)Lokio/ByteString;", "GetReadByteString_JHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		ByteString ReadByteString(long byteCount);

		[Register("readDecimalLong", "()J", "GetReadDecimalLongHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		long ReadDecimalLong();

		[Register("readFully", "([B)V", "GetReadFully_arrayBHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		void ReadFully(byte[] sink);

		[Register("readFully", "(Lokio/Buffer;J)V", "GetReadFully_Lokio_Buffer_JHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		void ReadFully(OkBuffer sink, long byteCount);

		[Register("readHexadecimalUnsignedLong", "()J", "GetReadHexadecimalUnsignedLongHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		long ReadHexadecimalUnsignedLong();

		[Register("readInt", "()I", "GetReadIntHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		int ReadInt();

		[Register("readIntLe", "()I", "GetReadIntLeHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		int ReadIntLe();

		[Register("readLong", "()J", "GetReadLongHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		long ReadLong();

		[Register("readLongLe", "()J", "GetReadLongLeHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		long ReadLongLe();

		[Register("readShort", "()S", "GetReadShortHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		short ReadShort();

		[Register("readShortLe", "()S", "GetReadShortLeHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		short ReadShortLe();

		[Register("readString", "(Ljava/nio/charset/Charset;)Ljava/lang/String;", "GetReadString_Ljava_nio_charset_Charset_Handler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		string ReadString(Charset charset);

		[Register("readString", "(JLjava/nio/charset/Charset;)Ljava/lang/String;", "GetReadString_JLjava_nio_charset_Charset_Handler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		string ReadString(long byteCount, Charset charset);

		[Register("readUtf8", "()Ljava/lang/String;", "GetReadUtf8Handler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		string ReadUtf8();

		[Register("readUtf8", "(J)Ljava/lang/String;", "GetReadUtf8_JHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		string ReadUtf8(long byteCount);

		[Register("readUtf8CodePoint", "()I", "GetReadUtf8CodePointHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		int ReadUtf8CodePoint();

		[Register("readUtf8Line", "()Ljava/lang/String;", "GetReadUtf8LineHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		string ReadUtf8Line();

		[Register("readUtf8LineStrict", "()Ljava/lang/String;", "GetReadUtf8LineStrictHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		string ReadUtf8LineStrict();

		[Register("readUtf8LineStrict", "(J)Ljava/lang/String;", "GetReadUtf8LineStrict_JHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		string ReadUtf8LineStrict(long limit);

		[Register("request", "(J)Z", "GetRequest_JHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		bool Request(long byteCount);

		[Register("require", "(J)V", "GetRequire_JHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		void Require(long byteCount);

		[Register("select", "(Lokio/Options;)I", "GetSelect_Lokio_Options_Handler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		int Select(Options options);

		[Register("skip", "(J)V", "GetSkip_JHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		void Skip(long byteCount);

		[Register("close", "()V", "GetCloseHandler:Square.OkIO.IBufferedSourceInvoker, Square.OkIO")]
		new void Close();
	}
	[Register("okio/BufferedSource", DoNotGenerateAcw = true)]
	internal class IBufferedSourceInvoker : Java.Lang.Object, IBufferedSource, IReadableByteChannel, IChannel, ICloseable, IJavaObject, IDisposable, IJavaPeerable, ISource
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/BufferedSource", typeof(IBufferedSourceInvoker));

		private IntPtr class_ref;

		private static Delegate cb_buffer;

		private IntPtr id_buffer;

		private static Delegate cb_exhausted;

		private IntPtr id_exhausted;

		private static Delegate cb_getBuffer;

		private IntPtr id_getBuffer;

		private static Delegate cb_indexOf_B;

		private IntPtr id_indexOf_B;

		private static Delegate cb_indexOf_BJ;

		private IntPtr id_indexOf_BJ;

		private static Delegate cb_indexOf_BJJ;

		private IntPtr id_indexOf_BJJ;

		private static Delegate cb_indexOf_Lokio_ByteString_;

		private IntPtr id_indexOf_Lokio_ByteString_;

		private static Delegate cb_indexOf_Lokio_ByteString_J;

		private IntPtr id_indexOf_Lokio_ByteString_J;

		private static Delegate cb_indexOfElement_Lokio_ByteString_;

		private IntPtr id_indexOfElement_Lokio_ByteString_;

		private static Delegate cb_indexOfElement_Lokio_ByteString_J;

		private IntPtr id_indexOfElement_Lokio_ByteString_J;

		private static Delegate cb_inputStream;

		private IntPtr id_inputStream;

		private static Delegate cb_peek;

		private IntPtr id_peek;

		private static Delegate cb_rangeEquals_JLokio_ByteString_;

		private IntPtr id_rangeEquals_JLokio_ByteString_;

		private static Delegate cb_rangeEquals_JLokio_ByteString_II;

		private IntPtr id_rangeEquals_JLokio_ByteString_II;

		private static Delegate cb_read_arrayB;

		private IntPtr id_read_arrayB;

		private static Delegate cb_read_arrayBII;

		private IntPtr id_read_arrayBII;

		private static Delegate cb_readAll_Lokio_Sink_;

		private IntPtr id_readAll_Lokio_Sink_;

		private static Delegate cb_readByte;

		private IntPtr id_readByte;

		private static Delegate cb_readByteArray;

		private IntPtr id_readByteArray;

		private static Delegate cb_readByteArray_J;

		private IntPtr id_readByteArray_J;

		private static Delegate cb_readByteString;

		private IntPtr id_readByteString;

		private static Delegate cb_readByteString_J;

		private IntPtr id_readByteString_J;

		private static Delegate cb_readDecimalLong;

		private IntPtr id_readDecimalLong;

		private static Delegate cb_readFully_arrayB;

		private IntPtr id_readFully_arrayB;

		private static Delegate cb_readFully_Lokio_Buffer_J;

		private IntPtr id_readFully_Lokio_Buffer_J;

		private static Delegate cb_readHexadecimalUnsignedLong;

		private IntPtr id_readHexadecimalUnsignedLong;

		private static Delegate cb_readInt;

		private IntPtr id_readInt;

		private static Delegate cb_readIntLe;

		private IntPtr id_readIntLe;

		private static Delegate cb_readLong;

		private IntPtr id_readLong;

		private static Delegate cb_readLongLe;

		private IntPtr id_readLongLe;

		private static Delegate cb_readShort;

		private IntPtr id_readShort;

		private static Delegate cb_readShortLe;

		private IntPtr id_readShortLe;

		private static Delegate cb_readString_Ljava_nio_charset_Charset_;

		private IntPtr id_readString_Ljava_nio_charset_Charset_;

		private static Delegate cb_readString_JLjava_nio_charset_Charset_;

		private IntPtr id_readString_JLjava_nio_charset_Charset_;

		private static Delegate cb_readUtf8;

		private IntPtr id_readUtf8;

		private static Delegate cb_readUtf8_J;

		private IntPtr id_readUtf8_J;

		private static Delegate cb_readUtf8CodePoint;

		private IntPtr id_readUtf8CodePoint;

		private static Delegate cb_readUtf8Line;

		private IntPtr id_readUtf8Line;

		private static Delegate cb_readUtf8LineStrict;

		private IntPtr id_readUtf8LineStrict;

		private static Delegate cb_readUtf8LineStrict_J;

		private IntPtr id_readUtf8LineStrict_J;

		private static Delegate cb_request_J;

		private IntPtr id_request_J;

		private static Delegate cb_require_J;

		private IntPtr id_require_J;

		private static Delegate cb_select_Lokio_Options_;

		private IntPtr id_select_Lokio_Options_;

		private static Delegate cb_skip_J;

		private IntPtr id_skip_J;

		private static Delegate cb_close;

		private IntPtr id_close;

		private static Delegate cb_read_Ljava_nio_ByteBuffer_;

		private IntPtr id_read_Ljava_nio_ByteBuffer_;

		private static Delegate cb_isOpen;

		private IntPtr id_isOpen;

		private static Delegate cb_read_Lokio_Buffer_J;

		private IntPtr id_read_Lokio_Buffer_J;

		private static Delegate cb_timeout;

		private IntPtr id_timeout;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public OkBuffer Buffer
		{
			get
			{
				if (id_buffer == IntPtr.Zero)
				{
					id_buffer = JNIEnv.GetMethodID(class_ref, "buffer", "()Lokio/Buffer;");
				}
				return Java.Lang.Object.GetObject<OkBuffer>(JNIEnv.CallObjectMethod(base.Handle, id_buffer), JniHandleOwnership.TransferLocalRef);
			}
		}

		public bool IsOpen
		{
			get
			{
				if (id_isOpen == IntPtr.Zero)
				{
					id_isOpen = JNIEnv.GetMethodID(class_ref, "isOpen", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_isOpen);
			}
		}

		public static IBufferedSource GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IBufferedSource>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "okio.BufferedSource"));
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

		public IBufferedSourceInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		[Obsolete]
		private static Delegate GetGetBufferObsoleteHandler()
		{
			if ((object)cb_buffer == null)
			{
				cb_buffer = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBufferObsolete));
			}
			return cb_buffer;
		}

		[Obsolete]
		private static IntPtr n_GetBufferObsolete(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Buffer);
		}

		private static Delegate GetExhaustedHandler()
		{
			if ((object)cb_exhausted == null)
			{
				cb_exhausted = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_Exhausted));
			}
			return cb_exhausted;
		}

		private static bool n_Exhausted(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Exhausted();
		}

		public bool Exhausted()
		{
			if (id_exhausted == IntPtr.Zero)
			{
				id_exhausted = JNIEnv.GetMethodID(class_ref, "exhausted", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_exhausted);
		}

		private static Delegate GetGetBufferHandler()
		{
			if ((object)cb_getBuffer == null)
			{
				cb_getBuffer = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBuffer));
			}
			return cb_getBuffer;
		}

		private static IntPtr n_GetBuffer(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetBuffer());
		}

		public OkBuffer GetBuffer()
		{
			if (id_getBuffer == IntPtr.Zero)
			{
				id_getBuffer = JNIEnv.GetMethodID(class_ref, "getBuffer", "()Lokio/Buffer;");
			}
			return Java.Lang.Object.GetObject<OkBuffer>(JNIEnv.CallObjectMethod(base.Handle, id_getBuffer), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetIndexOf_BHandler()
		{
			if ((object)cb_indexOf_B == null)
			{
				cb_indexOf_B = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPB_J(n_IndexOf_B));
			}
			return cb_indexOf_B;
		}

		private static long n_IndexOf_B(IntPtr jnienv, IntPtr native__this, sbyte b)
		{
			return Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IndexOf(b);
		}

		public unsafe long IndexOf(sbyte b)
		{
			if (id_indexOf_B == IntPtr.Zero)
			{
				id_indexOf_B = JNIEnv.GetMethodID(class_ref, "indexOf", "(B)J");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(b);
			return JNIEnv.CallLongMethod(base.Handle, id_indexOf_B, ptr);
		}

		private static Delegate GetIndexOf_BJHandler()
		{
			if ((object)cb_indexOf_BJ == null)
			{
				cb_indexOf_BJ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPBJ_J(n_IndexOf_BJ));
			}
			return cb_indexOf_BJ;
		}

		private static long n_IndexOf_BJ(IntPtr jnienv, IntPtr native__this, sbyte b, long fromIndex)
		{
			return Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IndexOf(b, fromIndex);
		}

		public unsafe long IndexOf(sbyte b, long fromIndex)
		{
			if (id_indexOf_BJ == IntPtr.Zero)
			{
				id_indexOf_BJ = JNIEnv.GetMethodID(class_ref, "indexOf", "(BJ)J");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(b);
			ptr[1] = new JValue(fromIndex);
			return JNIEnv.CallLongMethod(base.Handle, id_indexOf_BJ, ptr);
		}

		private static Delegate GetIndexOf_BJJHandler()
		{
			if ((object)cb_indexOf_BJJ == null)
			{
				cb_indexOf_BJJ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPBJJ_J(n_IndexOf_BJJ));
			}
			return cb_indexOf_BJJ;
		}

		private static long n_IndexOf_BJJ(IntPtr jnienv, IntPtr native__this, sbyte b, long fromIndex, long toIndex)
		{
			return Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IndexOf(b, fromIndex, toIndex);
		}

		public unsafe long IndexOf(sbyte b, long fromIndex, long toIndex)
		{
			if (id_indexOf_BJJ == IntPtr.Zero)
			{
				id_indexOf_BJJ = JNIEnv.GetMethodID(class_ref, "indexOf", "(BJJ)J");
			}
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(b);
			ptr[1] = new JValue(fromIndex);
			ptr[2] = new JValue(toIndex);
			return JNIEnv.CallLongMethod(base.Handle, id_indexOf_BJJ, ptr);
		}

		private static Delegate GetIndexOf_Lokio_ByteString_Handler()
		{
			if ((object)cb_indexOf_Lokio_ByteString_ == null)
			{
				cb_indexOf_Lokio_ByteString_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_J(n_IndexOf_Lokio_ByteString_));
			}
			return cb_indexOf_Lokio_ByteString_;
		}

		private static long n_IndexOf_Lokio_ByteString_(IntPtr jnienv, IntPtr native__this, IntPtr native_bytes)
		{
			IBufferedSource bufferedSource = Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteString bytes = Java.Lang.Object.GetObject<ByteString>(native_bytes, JniHandleOwnership.DoNotTransfer);
			return bufferedSource.IndexOf(bytes);
		}

		public unsafe long IndexOf(ByteString bytes)
		{
			if (id_indexOf_Lokio_ByteString_ == IntPtr.Zero)
			{
				id_indexOf_Lokio_ByteString_ = JNIEnv.GetMethodID(class_ref, "indexOf", "(Lokio/ByteString;)J");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(bytes?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallLongMethod(base.Handle, id_indexOf_Lokio_ByteString_, ptr);
		}

		private static Delegate GetIndexOf_Lokio_ByteString_JHandler()
		{
			if ((object)cb_indexOf_Lokio_ByteString_J == null)
			{
				cb_indexOf_Lokio_ByteString_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLJ_J(n_IndexOf_Lokio_ByteString_J));
			}
			return cb_indexOf_Lokio_ByteString_J;
		}

		private static long n_IndexOf_Lokio_ByteString_J(IntPtr jnienv, IntPtr native__this, IntPtr native_bytes, long fromIndex)
		{
			IBufferedSource bufferedSource = Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteString bytes = Java.Lang.Object.GetObject<ByteString>(native_bytes, JniHandleOwnership.DoNotTransfer);
			return bufferedSource.IndexOf(bytes, fromIndex);
		}

		public unsafe long IndexOf(ByteString bytes, long fromIndex)
		{
			if (id_indexOf_Lokio_ByteString_J == IntPtr.Zero)
			{
				id_indexOf_Lokio_ByteString_J = JNIEnv.GetMethodID(class_ref, "indexOf", "(Lokio/ByteString;J)J");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(bytes?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(fromIndex);
			return JNIEnv.CallLongMethod(base.Handle, id_indexOf_Lokio_ByteString_J, ptr);
		}

		private static Delegate GetIndexOfElement_Lokio_ByteString_Handler()
		{
			if ((object)cb_indexOfElement_Lokio_ByteString_ == null)
			{
				cb_indexOfElement_Lokio_ByteString_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_J(n_IndexOfElement_Lokio_ByteString_));
			}
			return cb_indexOfElement_Lokio_ByteString_;
		}

		private static long n_IndexOfElement_Lokio_ByteString_(IntPtr jnienv, IntPtr native__this, IntPtr native_targetBytes)
		{
			IBufferedSource bufferedSource = Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteString targetBytes = Java.Lang.Object.GetObject<ByteString>(native_targetBytes, JniHandleOwnership.DoNotTransfer);
			return bufferedSource.IndexOfElement(targetBytes);
		}

		public unsafe long IndexOfElement(ByteString targetBytes)
		{
			if (id_indexOfElement_Lokio_ByteString_ == IntPtr.Zero)
			{
				id_indexOfElement_Lokio_ByteString_ = JNIEnv.GetMethodID(class_ref, "indexOfElement", "(Lokio/ByteString;)J");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(targetBytes?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallLongMethod(base.Handle, id_indexOfElement_Lokio_ByteString_, ptr);
		}

		private static Delegate GetIndexOfElement_Lokio_ByteString_JHandler()
		{
			if ((object)cb_indexOfElement_Lokio_ByteString_J == null)
			{
				cb_indexOfElement_Lokio_ByteString_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLJ_J(n_IndexOfElement_Lokio_ByteString_J));
			}
			return cb_indexOfElement_Lokio_ByteString_J;
		}

		private static long n_IndexOfElement_Lokio_ByteString_J(IntPtr jnienv, IntPtr native__this, IntPtr native_targetBytes, long fromIndex)
		{
			IBufferedSource bufferedSource = Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteString targetBytes = Java.Lang.Object.GetObject<ByteString>(native_targetBytes, JniHandleOwnership.DoNotTransfer);
			return bufferedSource.IndexOfElement(targetBytes, fromIndex);
		}

		public unsafe long IndexOfElement(ByteString targetBytes, long fromIndex)
		{
			if (id_indexOfElement_Lokio_ByteString_J == IntPtr.Zero)
			{
				id_indexOfElement_Lokio_ByteString_J = JNIEnv.GetMethodID(class_ref, "indexOfElement", "(Lokio/ByteString;J)J");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(targetBytes?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(fromIndex);
			return JNIEnv.CallLongMethod(base.Handle, id_indexOfElement_Lokio_ByteString_J, ptr);
		}

		private static Delegate GetInputStreamHandler()
		{
			if ((object)cb_inputStream == null)
			{
				cb_inputStream = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_InputStream));
			}
			return cb_inputStream;
		}

		private static IntPtr n_InputStream(IntPtr jnienv, IntPtr native__this)
		{
			return InputStreamAdapter.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InputStream());
		}

		public Stream InputStream()
		{
			if (id_inputStream == IntPtr.Zero)
			{
				id_inputStream = JNIEnv.GetMethodID(class_ref, "inputStream", "()Ljava/io/InputStream;");
			}
			return InputStreamInvoker.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_inputStream), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetPeekHandler()
		{
			if ((object)cb_peek == null)
			{
				cb_peek = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Peek));
			}
			return cb_peek;
		}

		private static IntPtr n_Peek(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Peek());
		}

		public IBufferedSource Peek()
		{
			if (id_peek == IntPtr.Zero)
			{
				id_peek = JNIEnv.GetMethodID(class_ref, "peek", "()Lokio/BufferedSource;");
			}
			return Java.Lang.Object.GetObject<IBufferedSource>(JNIEnv.CallObjectMethod(base.Handle, id_peek), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetRangeEquals_JLokio_ByteString_Handler()
		{
			if ((object)cb_rangeEquals_JLokio_ByteString_ == null)
			{
				cb_rangeEquals_JLokio_ByteString_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJL_Z(n_RangeEquals_JLokio_ByteString_));
			}
			return cb_rangeEquals_JLokio_ByteString_;
		}

		private static bool n_RangeEquals_JLokio_ByteString_(IntPtr jnienv, IntPtr native__this, long offset, IntPtr native_bytes)
		{
			IBufferedSource bufferedSource = Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteString bytes = Java.Lang.Object.GetObject<ByteString>(native_bytes, JniHandleOwnership.DoNotTransfer);
			return bufferedSource.RangeEquals(offset, bytes);
		}

		public unsafe bool RangeEquals(long offset, ByteString bytes)
		{
			if (id_rangeEquals_JLokio_ByteString_ == IntPtr.Zero)
			{
				id_rangeEquals_JLokio_ByteString_ = JNIEnv.GetMethodID(class_ref, "rangeEquals", "(JLokio/ByteString;)Z");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(offset);
			ptr[1] = new JValue(bytes?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_rangeEquals_JLokio_ByteString_, ptr);
		}

		private static Delegate GetRangeEquals_JLokio_ByteString_IIHandler()
		{
			if ((object)cb_rangeEquals_JLokio_ByteString_II == null)
			{
				cb_rangeEquals_JLokio_ByteString_II = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPJLII_Z(n_RangeEquals_JLokio_ByteString_II));
			}
			return cb_rangeEquals_JLokio_ByteString_II;
		}

		private static bool n_RangeEquals_JLokio_ByteString_II(IntPtr jnienv, IntPtr native__this, long offset, IntPtr native_bytes, int bytesOffset, int byteCount)
		{
			IBufferedSource bufferedSource = Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteString bytes = Java.Lang.Object.GetObject<ByteString>(native_bytes, JniHandleOwnership.DoNotTransfer);
			return bufferedSource.RangeEquals(offset, bytes, bytesOffset, byteCount);
		}

		public unsafe bool RangeEquals(long offset, ByteString bytes, int bytesOffset, int byteCount)
		{
			if (id_rangeEquals_JLokio_ByteString_II == IntPtr.Zero)
			{
				id_rangeEquals_JLokio_ByteString_II = JNIEnv.GetMethodID(class_ref, "rangeEquals", "(JLokio/ByteString;II)Z");
			}
			JValue* ptr = stackalloc JValue[4];
			*ptr = new JValue(offset);
			ptr[1] = new JValue(bytes?.Handle ?? IntPtr.Zero);
			ptr[2] = new JValue(bytesOffset);
			ptr[3] = new JValue(byteCount);
			return JNIEnv.CallBooleanMethod(base.Handle, id_rangeEquals_JLokio_ByteString_II, ptr);
		}

		private static Delegate GetRead_arrayBHandler()
		{
			if ((object)cb_read_arrayB == null)
			{
				cb_read_arrayB = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_Read_arrayB));
			}
			return cb_read_arrayB;
		}

		private static int n_Read_arrayB(IntPtr jnienv, IntPtr native__this, IntPtr native_sink)
		{
			IBufferedSource bufferedSource = Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_sink, JniHandleOwnership.DoNotTransfer, typeof(byte));
			int result = bufferedSource.Read(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_sink);
			}
			return result;
		}

		public unsafe int Read(byte[] sink)
		{
			if (id_read_arrayB == IntPtr.Zero)
			{
				id_read_arrayB = JNIEnv.GetMethodID(class_ref, "read", "([B)I");
			}
			IntPtr intPtr = JNIEnv.NewArray(sink);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			int result = JNIEnv.CallIntMethod(base.Handle, id_read_arrayB, ptr);
			if (sink != null)
			{
				JNIEnv.CopyArray(intPtr, sink);
				JNIEnv.DeleteLocalRef(intPtr);
			}
			return result;
		}

		private static Delegate GetRead_arrayBIIHandler()
		{
			if ((object)cb_read_arrayBII == null)
			{
				cb_read_arrayBII = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLII_I(n_Read_arrayBII));
			}
			return cb_read_arrayBII;
		}

		private static int n_Read_arrayBII(IntPtr jnienv, IntPtr native__this, IntPtr native_sink, int offset, int byteCount)
		{
			IBufferedSource bufferedSource = Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_sink, JniHandleOwnership.DoNotTransfer, typeof(byte));
			int result = bufferedSource.Read(array, offset, byteCount);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_sink);
			}
			return result;
		}

		public unsafe int Read(byte[] sink, int offset, int byteCount)
		{
			if (id_read_arrayBII == IntPtr.Zero)
			{
				id_read_arrayBII = JNIEnv.GetMethodID(class_ref, "read", "([BII)I");
			}
			IntPtr intPtr = JNIEnv.NewArray(sink);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(offset);
			ptr[2] = new JValue(byteCount);
			int result = JNIEnv.CallIntMethod(base.Handle, id_read_arrayBII, ptr);
			if (sink != null)
			{
				JNIEnv.CopyArray(intPtr, sink);
				JNIEnv.DeleteLocalRef(intPtr);
			}
			return result;
		}

		private static Delegate GetReadAll_Lokio_Sink_Handler()
		{
			if ((object)cb_readAll_Lokio_Sink_ == null)
			{
				cb_readAll_Lokio_Sink_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_J(n_ReadAll_Lokio_Sink_));
			}
			return cb_readAll_Lokio_Sink_;
		}

		private static long n_ReadAll_Lokio_Sink_(IntPtr jnienv, IntPtr native__this, IntPtr native_sink)
		{
			IBufferedSource bufferedSource = Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ISink sink = Java.Lang.Object.GetObject<ISink>(native_sink, JniHandleOwnership.DoNotTransfer);
			return bufferedSource.ReadAll(sink);
		}

		public unsafe long ReadAll(ISink sink)
		{
			if (id_readAll_Lokio_Sink_ == IntPtr.Zero)
			{
				id_readAll_Lokio_Sink_ = JNIEnv.GetMethodID(class_ref, "readAll", "(Lokio/Sink;)J");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
			return JNIEnv.CallLongMethod(base.Handle, id_readAll_Lokio_Sink_, ptr);
		}

		private static Delegate GetReadByteHandler()
		{
			if ((object)cb_readByte == null)
			{
				cb_readByte = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_B(n_ReadByte));
			}
			return cb_readByte;
		}

		private static sbyte n_ReadByte(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReadByte();
		}

		public sbyte ReadByte()
		{
			if (id_readByte == IntPtr.Zero)
			{
				id_readByte = JNIEnv.GetMethodID(class_ref, "readByte", "()B");
			}
			return JNIEnv.CallByteMethod(base.Handle, id_readByte);
		}

		private static Delegate GetReadByteArrayHandler()
		{
			if ((object)cb_readByteArray == null)
			{
				cb_readByteArray = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ReadByteArray));
			}
			return cb_readByteArray;
		}

		private static IntPtr n_ReadByteArray(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReadByteArray());
		}

		public byte[] ReadByteArray()
		{
			if (id_readByteArray == IntPtr.Zero)
			{
				id_readByteArray = JNIEnv.GetMethodID(class_ref, "readByteArray", "()[B");
			}
			return (byte[])JNIEnv.GetArray(JNIEnv.CallObjectMethod(base.Handle, id_readByteArray), JniHandleOwnership.TransferLocalRef, typeof(byte));
		}

		private static Delegate GetReadByteArray_JHandler()
		{
			if ((object)cb_readByteArray_J == null)
			{
				cb_readByteArray_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_ReadByteArray_J));
			}
			return cb_readByteArray_J;
		}

		private static IntPtr n_ReadByteArray_J(IntPtr jnienv, IntPtr native__this, long byteCount)
		{
			return JNIEnv.NewArray(Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReadByteArray(byteCount));
		}

		public unsafe byte[] ReadByteArray(long byteCount)
		{
			if (id_readByteArray_J == IntPtr.Zero)
			{
				id_readByteArray_J = JNIEnv.GetMethodID(class_ref, "readByteArray", "(J)[B");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(byteCount);
			return (byte[])JNIEnv.GetArray(JNIEnv.CallObjectMethod(base.Handle, id_readByteArray_J, ptr), JniHandleOwnership.TransferLocalRef, typeof(byte));
		}

		private static Delegate GetReadByteStringHandler()
		{
			if ((object)cb_readByteString == null)
			{
				cb_readByteString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ReadByteString));
			}
			return cb_readByteString;
		}

		private static IntPtr n_ReadByteString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReadByteString());
		}

		public ByteString ReadByteString()
		{
			if (id_readByteString == IntPtr.Zero)
			{
				id_readByteString = JNIEnv.GetMethodID(class_ref, "readByteString", "()Lokio/ByteString;");
			}
			return Java.Lang.Object.GetObject<ByteString>(JNIEnv.CallObjectMethod(base.Handle, id_readByteString), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetReadByteString_JHandler()
		{
			if ((object)cb_readByteString_J == null)
			{
				cb_readByteString_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_ReadByteString_J));
			}
			return cb_readByteString_J;
		}

		private static IntPtr n_ReadByteString_J(IntPtr jnienv, IntPtr native__this, long byteCount)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReadByteString(byteCount));
		}

		public unsafe ByteString ReadByteString(long byteCount)
		{
			if (id_readByteString_J == IntPtr.Zero)
			{
				id_readByteString_J = JNIEnv.GetMethodID(class_ref, "readByteString", "(J)Lokio/ByteString;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(byteCount);
			return Java.Lang.Object.GetObject<ByteString>(JNIEnv.CallObjectMethod(base.Handle, id_readByteString_J, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetReadDecimalLongHandler()
		{
			if ((object)cb_readDecimalLong == null)
			{
				cb_readDecimalLong = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_ReadDecimalLong));
			}
			return cb_readDecimalLong;
		}

		private static long n_ReadDecimalLong(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReadDecimalLong();
		}

		public long ReadDecimalLong()
		{
			if (id_readDecimalLong == IntPtr.Zero)
			{
				id_readDecimalLong = JNIEnv.GetMethodID(class_ref, "readDecimalLong", "()J");
			}
			return JNIEnv.CallLongMethod(base.Handle, id_readDecimalLong);
		}

		private static Delegate GetReadFully_arrayBHandler()
		{
			if ((object)cb_readFully_arrayB == null)
			{
				cb_readFully_arrayB = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ReadFully_arrayB));
			}
			return cb_readFully_arrayB;
		}

		private static void n_ReadFully_arrayB(IntPtr jnienv, IntPtr native__this, IntPtr native_sink)
		{
			IBufferedSource bufferedSource = Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			byte[] array = (byte[])JNIEnv.GetArray(native_sink, JniHandleOwnership.DoNotTransfer, typeof(byte));
			bufferedSource.ReadFully(array);
			if (array != null)
			{
				JNIEnv.CopyArray(array, native_sink);
			}
		}

		public unsafe void ReadFully(byte[] sink)
		{
			if (id_readFully_arrayB == IntPtr.Zero)
			{
				id_readFully_arrayB = JNIEnv.GetMethodID(class_ref, "readFully", "([B)V");
			}
			IntPtr intPtr = JNIEnv.NewArray(sink);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_readFully_arrayB, ptr);
			if (sink != null)
			{
				JNIEnv.CopyArray(intPtr, sink);
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetReadFully_Lokio_Buffer_JHandler()
		{
			if ((object)cb_readFully_Lokio_Buffer_J == null)
			{
				cb_readFully_Lokio_Buffer_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLJ_V(n_ReadFully_Lokio_Buffer_J));
			}
			return cb_readFully_Lokio_Buffer_J;
		}

		private static void n_ReadFully_Lokio_Buffer_J(IntPtr jnienv, IntPtr native__this, IntPtr native_sink, long byteCount)
		{
			IBufferedSource bufferedSource = Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OkBuffer sink = Java.Lang.Object.GetObject<OkBuffer>(native_sink, JniHandleOwnership.DoNotTransfer);
			bufferedSource.ReadFully(sink, byteCount);
		}

		public unsafe void ReadFully(OkBuffer sink, long byteCount)
		{
			if (id_readFully_Lokio_Buffer_J == IntPtr.Zero)
			{
				id_readFully_Lokio_Buffer_J = JNIEnv.GetMethodID(class_ref, "readFully", "(Lokio/Buffer;J)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(sink?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(byteCount);
			JNIEnv.CallVoidMethod(base.Handle, id_readFully_Lokio_Buffer_J, ptr);
		}

		private static Delegate GetReadHexadecimalUnsignedLongHandler()
		{
			if ((object)cb_readHexadecimalUnsignedLong == null)
			{
				cb_readHexadecimalUnsignedLong = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_ReadHexadecimalUnsignedLong));
			}
			return cb_readHexadecimalUnsignedLong;
		}

		private static long n_ReadHexadecimalUnsignedLong(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReadHexadecimalUnsignedLong();
		}

		public long ReadHexadecimalUnsignedLong()
		{
			if (id_readHexadecimalUnsignedLong == IntPtr.Zero)
			{
				id_readHexadecimalUnsignedLong = JNIEnv.GetMethodID(class_ref, "readHexadecimalUnsignedLong", "()J");
			}
			return JNIEnv.CallLongMethod(base.Handle, id_readHexadecimalUnsignedLong);
		}

		private static Delegate GetReadIntHandler()
		{
			if ((object)cb_readInt == null)
			{
				cb_readInt = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_ReadInt));
			}
			return cb_readInt;
		}

		private static int n_ReadInt(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReadInt();
		}

		public int ReadInt()
		{
			if (id_readInt == IntPtr.Zero)
			{
				id_readInt = JNIEnv.GetMethodID(class_ref, "readInt", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_readInt);
		}

		private static Delegate GetReadIntLeHandler()
		{
			if ((object)cb_readIntLe == null)
			{
				cb_readIntLe = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_ReadIntLe));
			}
			return cb_readIntLe;
		}

		private static int n_ReadIntLe(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReadIntLe();
		}

		public int ReadIntLe()
		{
			if (id_readIntLe == IntPtr.Zero)
			{
				id_readIntLe = JNIEnv.GetMethodID(class_ref, "readIntLe", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_readIntLe);
		}

		private static Delegate GetReadLongHandler()
		{
			if ((object)cb_readLong == null)
			{
				cb_readLong = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_ReadLong));
			}
			return cb_readLong;
		}

		private static long n_ReadLong(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReadLong();
		}

		public long ReadLong()
		{
			if (id_readLong == IntPtr.Zero)
			{
				id_readLong = JNIEnv.GetMethodID(class_ref, "readLong", "()J");
			}
			return JNIEnv.CallLongMethod(base.Handle, id_readLong);
		}

		private static Delegate GetReadLongLeHandler()
		{
			if ((object)cb_readLongLe == null)
			{
				cb_readLongLe = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_ReadLongLe));
			}
			return cb_readLongLe;
		}

		private static long n_ReadLongLe(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReadLongLe();
		}

		public long ReadLongLe()
		{
			if (id_readLongLe == IntPtr.Zero)
			{
				id_readLongLe = JNIEnv.GetMethodID(class_ref, "readLongLe", "()J");
			}
			return JNIEnv.CallLongMethod(base.Handle, id_readLongLe);
		}

		private static Delegate GetReadShortHandler()
		{
			if ((object)cb_readShort == null)
			{
				cb_readShort = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_S(n_ReadShort));
			}
			return cb_readShort;
		}

		private static short n_ReadShort(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReadShort();
		}

		public short ReadShort()
		{
			if (id_readShort == IntPtr.Zero)
			{
				id_readShort = JNIEnv.GetMethodID(class_ref, "readShort", "()S");
			}
			return JNIEnv.CallShortMethod(base.Handle, id_readShort);
		}

		private static Delegate GetReadShortLeHandler()
		{
			if ((object)cb_readShortLe == null)
			{
				cb_readShortLe = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_S(n_ReadShortLe));
			}
			return cb_readShortLe;
		}

		private static short n_ReadShortLe(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReadShortLe();
		}

		public short ReadShortLe()
		{
			if (id_readShortLe == IntPtr.Zero)
			{
				id_readShortLe = JNIEnv.GetMethodID(class_ref, "readShortLe", "()S");
			}
			return JNIEnv.CallShortMethod(base.Handle, id_readShortLe);
		}

		private static Delegate GetReadString_Ljava_nio_charset_Charset_Handler()
		{
			if ((object)cb_readString_Ljava_nio_charset_Charset_ == null)
			{
				cb_readString_Ljava_nio_charset_Charset_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_ReadString_Ljava_nio_charset_Charset_));
			}
			return cb_readString_Ljava_nio_charset_Charset_;
		}

		private static IntPtr n_ReadString_Ljava_nio_charset_Charset_(IntPtr jnienv, IntPtr native__this, IntPtr native_charset)
		{
			IBufferedSource bufferedSource = Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Charset charset = Java.Lang.Object.GetObject<Charset>(native_charset, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(bufferedSource.ReadString(charset));
		}

		public unsafe string ReadString(Charset charset)
		{
			if (id_readString_Ljava_nio_charset_Charset_ == IntPtr.Zero)
			{
				id_readString_Ljava_nio_charset_Charset_ = JNIEnv.GetMethodID(class_ref, "readString", "(Ljava/nio/charset/Charset;)Ljava/lang/String;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(charset?.Handle ?? IntPtr.Zero);
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_readString_Ljava_nio_charset_Charset_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetReadString_JLjava_nio_charset_Charset_Handler()
		{
			if ((object)cb_readString_JLjava_nio_charset_Charset_ == null)
			{
				cb_readString_JLjava_nio_charset_Charset_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJL_L(n_ReadString_JLjava_nio_charset_Charset_));
			}
			return cb_readString_JLjava_nio_charset_Charset_;
		}

		private static IntPtr n_ReadString_JLjava_nio_charset_Charset_(IntPtr jnienv, IntPtr native__this, long byteCount, IntPtr native_charset)
		{
			IBufferedSource bufferedSource = Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Charset charset = Java.Lang.Object.GetObject<Charset>(native_charset, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.NewString(bufferedSource.ReadString(byteCount, charset));
		}

		public unsafe string ReadString(long byteCount, Charset charset)
		{
			if (id_readString_JLjava_nio_charset_Charset_ == IntPtr.Zero)
			{
				id_readString_JLjava_nio_charset_Charset_ = JNIEnv.GetMethodID(class_ref, "readString", "(JLjava/nio/charset/Charset;)Ljava/lang/String;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(byteCount);
			ptr[1] = new JValue(charset?.Handle ?? IntPtr.Zero);
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_readString_JLjava_nio_charset_Charset_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetReadUtf8Handler()
		{
			if ((object)cb_readUtf8 == null)
			{
				cb_readUtf8 = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ReadUtf8));
			}
			return cb_readUtf8;
		}

		private static IntPtr n_ReadUtf8(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReadUtf8());
		}

		public string ReadUtf8()
		{
			if (id_readUtf8 == IntPtr.Zero)
			{
				id_readUtf8 = JNIEnv.GetMethodID(class_ref, "readUtf8", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_readUtf8), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetReadUtf8_JHandler()
		{
			if ((object)cb_readUtf8_J == null)
			{
				cb_readUtf8_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_ReadUtf8_J));
			}
			return cb_readUtf8_J;
		}

		private static IntPtr n_ReadUtf8_J(IntPtr jnienv, IntPtr native__this, long byteCount)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReadUtf8(byteCount));
		}

		public unsafe string ReadUtf8(long byteCount)
		{
			if (id_readUtf8_J == IntPtr.Zero)
			{
				id_readUtf8_J = JNIEnv.GetMethodID(class_ref, "readUtf8", "(J)Ljava/lang/String;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(byteCount);
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_readUtf8_J, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetReadUtf8CodePointHandler()
		{
			if ((object)cb_readUtf8CodePoint == null)
			{
				cb_readUtf8CodePoint = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_ReadUtf8CodePoint));
			}
			return cb_readUtf8CodePoint;
		}

		private static int n_ReadUtf8CodePoint(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReadUtf8CodePoint();
		}

		public int ReadUtf8CodePoint()
		{
			if (id_readUtf8CodePoint == IntPtr.Zero)
			{
				id_readUtf8CodePoint = JNIEnv.GetMethodID(class_ref, "readUtf8CodePoint", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_readUtf8CodePoint);
		}

		private static Delegate GetReadUtf8LineHandler()
		{
			if ((object)cb_readUtf8Line == null)
			{
				cb_readUtf8Line = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ReadUtf8Line));
			}
			return cb_readUtf8Line;
		}

		private static IntPtr n_ReadUtf8Line(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReadUtf8Line());
		}

		public string ReadUtf8Line()
		{
			if (id_readUtf8Line == IntPtr.Zero)
			{
				id_readUtf8Line = JNIEnv.GetMethodID(class_ref, "readUtf8Line", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_readUtf8Line), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetReadUtf8LineStrictHandler()
		{
			if ((object)cb_readUtf8LineStrict == null)
			{
				cb_readUtf8LineStrict = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ReadUtf8LineStrict));
			}
			return cb_readUtf8LineStrict;
		}

		private static IntPtr n_ReadUtf8LineStrict(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReadUtf8LineStrict());
		}

		public string ReadUtf8LineStrict()
		{
			if (id_readUtf8LineStrict == IntPtr.Zero)
			{
				id_readUtf8LineStrict = JNIEnv.GetMethodID(class_ref, "readUtf8LineStrict", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_readUtf8LineStrict), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetReadUtf8LineStrict_JHandler()
		{
			if ((object)cb_readUtf8LineStrict_J == null)
			{
				cb_readUtf8LineStrict_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_ReadUtf8LineStrict_J));
			}
			return cb_readUtf8LineStrict_J;
		}

		private static IntPtr n_ReadUtf8LineStrict_J(IntPtr jnienv, IntPtr native__this, long limit)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReadUtf8LineStrict(limit));
		}

		public unsafe string ReadUtf8LineStrict(long limit)
		{
			if (id_readUtf8LineStrict_J == IntPtr.Zero)
			{
				id_readUtf8LineStrict_J = JNIEnv.GetMethodID(class_ref, "readUtf8LineStrict", "(J)Ljava/lang/String;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(limit);
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_readUtf8LineStrict_J, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetRequest_JHandler()
		{
			if ((object)cb_request_J == null)
			{
				cb_request_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_Z(n_Request_J));
			}
			return cb_request_J;
		}

		private static bool n_Request_J(IntPtr jnienv, IntPtr native__this, long byteCount)
		{
			return Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Request(byteCount);
		}

		public unsafe bool Request(long byteCount)
		{
			if (id_request_J == IntPtr.Zero)
			{
				id_request_J = JNIEnv.GetMethodID(class_ref, "request", "(J)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(byteCount);
			return JNIEnv.CallBooleanMethod(base.Handle, id_request_J, ptr);
		}

		private static Delegate GetRequire_JHandler()
		{
			if ((object)cb_require_J == null)
			{
				cb_require_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_V(n_Require_J));
			}
			return cb_require_J;
		}

		private static void n_Require_J(IntPtr jnienv, IntPtr native__this, long byteCount)
		{
			Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Require(byteCount);
		}

		public unsafe void Require(long byteCount)
		{
			if (id_require_J == IntPtr.Zero)
			{
				id_require_J = JNIEnv.GetMethodID(class_ref, "require", "(J)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(byteCount);
			JNIEnv.CallVoidMethod(base.Handle, id_require_J, ptr);
		}

		private static Delegate GetSelect_Lokio_Options_Handler()
		{
			if ((object)cb_select_Lokio_Options_ == null)
			{
				cb_select_Lokio_Options_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_Select_Lokio_Options_));
			}
			return cb_select_Lokio_Options_;
		}

		private static int n_Select_Lokio_Options_(IntPtr jnienv, IntPtr native__this, IntPtr native_options)
		{
			IBufferedSource bufferedSource = Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Options options = Java.Lang.Object.GetObject<Options>(native_options, JniHandleOwnership.DoNotTransfer);
			return bufferedSource.Select(options);
		}

		public unsafe int Select(Options options)
		{
			if (id_select_Lokio_Options_ == IntPtr.Zero)
			{
				id_select_Lokio_Options_ = JNIEnv.GetMethodID(class_ref, "select", "(Lokio/Options;)I");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(options?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallIntMethod(base.Handle, id_select_Lokio_Options_, ptr);
		}

		private static Delegate GetSkip_JHandler()
		{
			if ((object)cb_skip_J == null)
			{
				cb_skip_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_V(n_Skip_J));
			}
			return cb_skip_J;
		}

		private static void n_Skip_J(IntPtr jnienv, IntPtr native__this, long byteCount)
		{
			Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Skip(byteCount);
		}

		public unsafe void Skip(long byteCount)
		{
			if (id_skip_J == IntPtr.Zero)
			{
				id_skip_J = JNIEnv.GetMethodID(class_ref, "skip", "(J)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(byteCount);
			JNIEnv.CallVoidMethod(base.Handle, id_skip_J, ptr);
		}

		private static Delegate GetCloseHandler()
		{
			if ((object)cb_close == null)
			{
				cb_close = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Close));
			}
			return cb_close;
		}

		private static void n_Close(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
		}

		public void Close()
		{
			if (id_close == IntPtr.Zero)
			{
				id_close = JNIEnv.GetMethodID(class_ref, "close", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_close);
		}

		private static Delegate GetRead_Ljava_nio_ByteBuffer_Handler()
		{
			if ((object)cb_read_Ljava_nio_ByteBuffer_ == null)
			{
				cb_read_Ljava_nio_ByteBuffer_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_I(n_Read_Ljava_nio_ByteBuffer_));
			}
			return cb_read_Ljava_nio_ByteBuffer_;
		}

		private static int n_Read_Ljava_nio_ByteBuffer_(IntPtr jnienv, IntPtr native__this, IntPtr native_dst)
		{
			IBufferedSource bufferedSource = Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ByteBuffer dst = Java.Lang.Object.GetObject<ByteBuffer>(native_dst, JniHandleOwnership.DoNotTransfer);
			return bufferedSource.Read(dst);
		}

		public unsafe int Read(ByteBuffer dst)
		{
			if (id_read_Ljava_nio_ByteBuffer_ == IntPtr.Zero)
			{
				id_read_Ljava_nio_ByteBuffer_ = JNIEnv.GetMethodID(class_ref, "read", "(Ljava/nio/ByteBuffer;)I");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(dst?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallIntMethod(base.Handle, id_read_Ljava_nio_ByteBuffer_, ptr);
		}

		private static Delegate GetIsOpenHandler()
		{
			if ((object)cb_isOpen == null)
			{
				cb_isOpen = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsOpen));
			}
			return cb_isOpen;
		}

		private static bool n_IsOpen(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsOpen;
		}

		private static Delegate GetRead_Lokio_Buffer_JHandler()
		{
			if ((object)cb_read_Lokio_Buffer_J == null)
			{
				cb_read_Lokio_Buffer_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLJ_J(n_Read_Lokio_Buffer_J));
			}
			return cb_read_Lokio_Buffer_J;
		}

		private static long n_Read_Lokio_Buffer_J(IntPtr jnienv, IntPtr native__this, IntPtr native_sink, long byteCount)
		{
			IBufferedSource bufferedSource = Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OkBuffer sink = Java.Lang.Object.GetObject<OkBuffer>(native_sink, JniHandleOwnership.DoNotTransfer);
			return bufferedSource.Read(sink, byteCount);
		}

		public unsafe long Read(OkBuffer sink, long byteCount)
		{
			if (id_read_Lokio_Buffer_J == IntPtr.Zero)
			{
				id_read_Lokio_Buffer_J = JNIEnv.GetMethodID(class_ref, "read", "(Lokio/Buffer;J)J");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(sink?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(byteCount);
			return JNIEnv.CallLongMethod(base.Handle, id_read_Lokio_Buffer_J, ptr);
		}

		private static Delegate GetTimeoutHandler()
		{
			if ((object)cb_timeout == null)
			{
				cb_timeout = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Timeout));
			}
			return cb_timeout;
		}

		private static IntPtr n_Timeout(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IBufferedSource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Timeout());
		}

		public Timeout Timeout()
		{
			if (id_timeout == IntPtr.Zero)
			{
				id_timeout = JNIEnv.GetMethodID(class_ref, "timeout", "()Lokio/Timeout;");
			}
			return Java.Lang.Object.GetObject<Timeout>(JNIEnv.CallObjectMethod(base.Handle, id_timeout), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okio/ExperimentalFileSystem", "", "Square.OkIO.IExperimentalFileSystemInvoker")]
	public interface IExperimentalFileSystem : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("okio/ExperimentalFileSystem", DoNotGenerateAcw = true)]
	internal class IExperimentalFileSystemInvoker : Java.Lang.Object, IExperimentalFileSystem, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/ExperimentalFileSystem", typeof(IExperimentalFileSystemInvoker));

		private IntPtr class_ref;

		private static Delegate cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate cb_toString;

		private IntPtr id_toString;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static IExperimentalFileSystem GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IExperimentalFileSystem>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "okio.ExperimentalFileSystem"));
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

		public IExperimentalFileSystemInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetAnnotationTypeHandler()
		{
			if ((object)cb_annotationType == null)
			{
				cb_annotationType = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_AnnotationType));
			}
			return cb_annotationType;
		}

		private static IntPtr n_AnnotationType(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IExperimentalFileSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class AnnotationType()
		{
			if (id_annotationType == IntPtr.Zero)
			{
				id_annotationType = JNIEnv.GetMethodID(class_ref, "annotationType", "()Ljava/lang/Class;");
			}
			return Java.Lang.Object.GetObject<Class>(JNIEnv.CallObjectMethod(base.Handle, id_annotationType), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetEquals_Ljava_lang_Object_Handler()
		{
			if ((object)cb_equals_Ljava_lang_Object_ == null)
			{
				cb_equals_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Equals_Ljava_lang_Object_));
			}
			return cb_equals_Ljava_lang_Object_;
		}

		private static bool n_Equals_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_obj)
		{
			IExperimentalFileSystem experimentalFileSystem = Java.Lang.Object.GetObject<IExperimentalFileSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return experimentalFileSystem.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object obj)
		{
			if (id_equals_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_equals_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "equals", "(Ljava/lang/Object;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(obj?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_equals_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetGetHashCodeHandler()
		{
			if ((object)cb_hashCode == null)
			{
				cb_hashCode = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetHashCode));
			}
			return cb_hashCode;
		}

		private static int n_GetHashCode(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<IExperimentalFileSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
		}

		public new int GetHashCode()
		{
			if (id_hashCode == IntPtr.Zero)
			{
				id_hashCode = JNIEnv.GetMethodID(class_ref, "hashCode", "()I");
			}
			return JNIEnv.CallIntMethod(base.Handle, id_hashCode);
		}

		private static Delegate GetToStringHandler()
		{
			if ((object)cb_toString == null)
			{
				cb_toString = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ToString));
			}
			return cb_toString;
		}

		private static IntPtr n_ToString(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IExperimentalFileSystem>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okio/InflaterSource", DoNotGenerateAcw = true)]
	public sealed class InflaterSource : Java.Lang.Object, ISource, ICloseable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/InflaterSource", typeof(InflaterSource));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal InflaterSource(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lokio/Source;Ljava/util/zip/Inflater;)V", "")]
		public unsafe InflaterSource(ISource source, Inflater inflater)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
				ptr[1] = new JniArgumentValue(inflater?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Lokio/Source;Ljava/util/zip/Inflater;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Lokio/Source;Ljava/util/zip/Inflater;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(source);
				GC.KeepAlive(inflater);
			}
		}

		[Register("close", "()V", "")]
		public unsafe void Close()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("close.()V", this, null);
		}

		[Register("read", "(Lokio/Buffer;J)J", "")]
		public unsafe long Read(OkBuffer sink, long byteCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(sink?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(byteCount);
				return _members.InstanceMethods.InvokeAbstractInt64Method("read.(Lokio/Buffer;J)J", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sink);
			}
		}

		[Register("readOrInflate", "(Lokio/Buffer;J)J", "")]
		public unsafe long ReadOrInflate(OkBuffer sink, long byteCount)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(sink?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(byteCount);
				return _members.InstanceMethods.InvokeNonvirtualInt64Method("readOrInflate.(Lokio/Buffer;J)J", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sink);
			}
		}

		[Register("refill", "()Z", "")]
		public unsafe bool Refill()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("refill.()Z", this, null);
		}

		[Register("timeout", "()Lokio/Timeout;", "")]
		public unsafe Timeout Timeout()
		{
			return Java.Lang.Object.GetObject<Timeout>(_members.InstanceMethods.InvokeAbstractObjectMethod("timeout.()Lokio/Timeout;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okio/Sink", "", "Square.OkIO.ISinkInvoker")]
	public interface ISink : ICloseable, IJavaObject, IDisposable, IJavaPeerable, IFlushable
	{
		[Register("close", "()V", "GetCloseHandler:Square.OkIO.ISinkInvoker, Square.OkIO")]
		new void Close();

		[Register("flush", "()V", "GetFlushHandler:Square.OkIO.ISinkInvoker, Square.OkIO")]
		new void Flush();

		[Register("timeout", "()Lokio/Timeout;", "GetTimeoutHandler:Square.OkIO.ISinkInvoker, Square.OkIO")]
		Timeout Timeout();

		[Register("write", "(Lokio/Buffer;J)V", "GetWrite_Lokio_Buffer_JHandler:Square.OkIO.ISinkInvoker, Square.OkIO")]
		void Write(OkBuffer source, long byteCount);
	}
	[Register("okio/Sink", DoNotGenerateAcw = true)]
	internal class ISinkInvoker : Java.Lang.Object, ISink, ICloseable, IJavaObject, IDisposable, IJavaPeerable, IFlushable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/Sink", typeof(ISinkInvoker));

		private IntPtr class_ref;

		private static Delegate cb_close;

		private IntPtr id_close;

		private static Delegate cb_flush;

		private IntPtr id_flush;

		private static Delegate cb_timeout;

		private IntPtr id_timeout;

		private static Delegate cb_write_Lokio_Buffer_J;

		private IntPtr id_write_Lokio_Buffer_J;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static ISink GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISink>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "okio.Sink"));
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

		public ISinkInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetCloseHandler()
		{
			if ((object)cb_close == null)
			{
				cb_close = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Close));
			}
			return cb_close;
		}

		private static void n_Close(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ISink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
		}

		public void Close()
		{
			if (id_close == IntPtr.Zero)
			{
				id_close = JNIEnv.GetMethodID(class_ref, "close", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_close);
		}

		private static Delegate GetFlushHandler()
		{
			if ((object)cb_flush == null)
			{
				cb_flush = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Flush));
			}
			return cb_flush;
		}

		private static void n_Flush(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ISink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Flush();
		}

		public void Flush()
		{
			if (id_flush == IntPtr.Zero)
			{
				id_flush = JNIEnv.GetMethodID(class_ref, "flush", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_flush);
		}

		private static Delegate GetTimeoutHandler()
		{
			if ((object)cb_timeout == null)
			{
				cb_timeout = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Timeout));
			}
			return cb_timeout;
		}

		private static IntPtr n_Timeout(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Timeout());
		}

		public Timeout Timeout()
		{
			if (id_timeout == IntPtr.Zero)
			{
				id_timeout = JNIEnv.GetMethodID(class_ref, "timeout", "()Lokio/Timeout;");
			}
			return Java.Lang.Object.GetObject<Timeout>(JNIEnv.CallObjectMethod(base.Handle, id_timeout), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetWrite_Lokio_Buffer_JHandler()
		{
			if ((object)cb_write_Lokio_Buffer_J == null)
			{
				cb_write_Lokio_Buffer_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLJ_V(n_Write_Lokio_Buffer_J));
			}
			return cb_write_Lokio_Buffer_J;
		}

		private static void n_Write_Lokio_Buffer_J(IntPtr jnienv, IntPtr native__this, IntPtr native_source, long byteCount)
		{
			ISink sink = Java.Lang.Object.GetObject<ISink>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OkBuffer source = Java.Lang.Object.GetObject<OkBuffer>(native_source, JniHandleOwnership.DoNotTransfer);
			sink.Write(source, byteCount);
		}

		public unsafe void Write(OkBuffer source, long byteCount)
		{
			if (id_write_Lokio_Buffer_J == IntPtr.Zero)
			{
				id_write_Lokio_Buffer_J = JNIEnv.GetMethodID(class_ref, "write", "(Lokio/Buffer;J)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(source?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(byteCount);
			JNIEnv.CallVoidMethod(base.Handle, id_write_Lokio_Buffer_J, ptr);
		}
	}
	[Register("okio/Source", "", "Square.OkIO.ISourceInvoker")]
	public interface ISource : ICloseable, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("close", "()V", "GetCloseHandler:Square.OkIO.ISourceInvoker, Square.OkIO")]
		new void Close();

		[Register("read", "(Lokio/Buffer;J)J", "GetRead_Lokio_Buffer_JHandler:Square.OkIO.ISourceInvoker, Square.OkIO")]
		long Read(OkBuffer sink, long byteCount);

		[Register("timeout", "()Lokio/Timeout;", "GetTimeoutHandler:Square.OkIO.ISourceInvoker, Square.OkIO")]
		Timeout Timeout();
	}
	[Register("okio/Source", DoNotGenerateAcw = true)]
	internal class ISourceInvoker : Java.Lang.Object, ISource, ICloseable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/Source", typeof(ISourceInvoker));

		private IntPtr class_ref;

		private static Delegate cb_close;

		private IntPtr id_close;

		private static Delegate cb_read_Lokio_Buffer_J;

		private IntPtr id_read_Lokio_Buffer_J;

		private static Delegate cb_timeout;

		private IntPtr id_timeout;

		private static IntPtr java_class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => class_ref;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public static ISource GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISource>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException(string.Format("Unable to convert instance of type '{0}' to type '{1}'.", JNIEnv.GetClassNameFromInstance(handle), "okio.Source"));
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

		public ISourceInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetCloseHandler()
		{
			if ((object)cb_close == null)
			{
				cb_close = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Close));
			}
			return cb_close;
		}

		private static void n_Close(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ISource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
		}

		public void Close()
		{
			if (id_close == IntPtr.Zero)
			{
				id_close = JNIEnv.GetMethodID(class_ref, "close", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_close);
		}

		private static Delegate GetRead_Lokio_Buffer_JHandler()
		{
			if ((object)cb_read_Lokio_Buffer_J == null)
			{
				cb_read_Lokio_Buffer_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLJ_J(n_Read_Lokio_Buffer_J));
			}
			return cb_read_Lokio_Buffer_J;
		}

		private static long n_Read_Lokio_Buffer_J(IntPtr jnienv, IntPtr native__this, IntPtr native_sink, long byteCount)
		{
			ISource source = Java.Lang.Object.GetObject<ISource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			OkBuffer sink = Java.Lang.Object.GetObject<OkBuffer>(native_sink, JniHandleOwnership.DoNotTransfer);
			return source.Read(sink, byteCount);
		}

		public unsafe long Read(OkBuffer sink, long byteCount)
		{
			if (id_read_Lokio_Buffer_J == IntPtr.Zero)
			{
				id_read_Lokio_Buffer_J = JNIEnv.GetMethodID(class_ref, "read", "(Lokio/Buffer;J)J");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(sink?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(byteCount);
			return JNIEnv.CallLongMethod(base.Handle, id_read_Lokio_Buffer_J, ptr);
		}

		private static Delegate GetTimeoutHandler()
		{
			if ((object)cb_timeout == null)
			{
				cb_timeout = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Timeout));
			}
			return cb_timeout;
		}

		private static IntPtr n_Timeout(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ISource>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Timeout());
		}

		public Timeout Timeout()
		{
			if (id_timeout == IntPtr.Zero)
			{
				id_timeout = JNIEnv.GetMethodID(class_ref, "timeout", "()Lokio/Timeout;");
			}
			return Java.Lang.Object.GetObject<Timeout>(JNIEnv.CallObjectMethod(base.Handle, id_timeout), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okio/Okio", DoNotGenerateAcw = true)]
	public sealed class OkIO : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/Okio", typeof(OkIO));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal OkIO(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("appendingSink", "(Ljava/io/File;)Lokio/Sink;", "")]
		public unsafe static ISink AppendingSink(Java.IO.File file)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(file?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ISink>(_members.StaticMethods.InvokeObjectMethod("appendingSink.(Ljava/io/File;)Lokio/Sink;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(file);
			}
		}

		[Register("blackhole", "()Lokio/Sink;", "")]
		public unsafe static ISink Blackhole()
		{
			return Java.Lang.Object.GetObject<ISink>(_members.StaticMethods.InvokeObjectMethod("blackhole.()Lokio/Sink;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("buffer", "(Lokio/Sink;)Lokio/BufferedSink;", "")]
		public unsafe static IBufferedSink Buffer(ISink sink)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
				return Java.Lang.Object.GetObject<IBufferedSink>(_members.StaticMethods.InvokeObjectMethod("buffer.(Lokio/Sink;)Lokio/BufferedSink;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(sink);
			}
		}

		[Register("buffer", "(Lokio/Source;)Lokio/BufferedSource;", "")]
		public unsafe static IBufferedSource Buffer(ISource source)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
				return Java.Lang.Object.GetObject<IBufferedSource>(_members.StaticMethods.InvokeObjectMethod("buffer.(Lokio/Source;)Lokio/BufferedSource;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}

		[Register("cipherSink", "(Lokio/Sink;Ljavax/crypto/Cipher;)Lokio/CipherSink;", "")]
		public unsafe static CipherSink CipherSink(ISink _this_cipherSink, Cipher cipher)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_cipherSink == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_cipherSink).Handle);
				ptr[1] = new JniArgumentValue(cipher?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<CipherSink>(_members.StaticMethods.InvokeObjectMethod("cipherSink.(Lokio/Sink;Ljavax/crypto/Cipher;)Lokio/CipherSink;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_cipherSink);
				GC.KeepAlive(cipher);
			}
		}

		[Register("cipherSource", "(Lokio/Source;Ljavax/crypto/Cipher;)Lokio/CipherSource;", "")]
		public unsafe static CipherSource CipherSource(ISource _this_cipherSource, Cipher cipher)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_cipherSource == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_cipherSource).Handle);
				ptr[1] = new JniArgumentValue(cipher?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<CipherSource>(_members.StaticMethods.InvokeObjectMethod("cipherSource.(Lokio/Source;Ljavax/crypto/Cipher;)Lokio/CipherSource;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_cipherSource);
				GC.KeepAlive(cipher);
			}
		}

		[Register("hashingSink", "(Lokio/Sink;Ljava/security/MessageDigest;)Lokio/HashingSink;", "")]
		public unsafe static HashingSink HashingSink(ISink _this_hashingSink, MessageDigest digest)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_hashingSink == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_hashingSink).Handle);
				ptr[1] = new JniArgumentValue(digest?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<HashingSink>(_members.StaticMethods.InvokeObjectMethod("hashingSink.(Lokio/Sink;Ljava/security/MessageDigest;)Lokio/HashingSink;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_hashingSink);
				GC.KeepAlive(digest);
			}
		}

		[Register("hashingSink", "(Lokio/Sink;Ljavax/crypto/Mac;)Lokio/HashingSink;", "")]
		public unsafe static HashingSink HashingSink(ISink _this_hashingSink, Mac mac)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_hashingSink == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_hashingSink).Handle);
				ptr[1] = new JniArgumentValue(mac?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<HashingSink>(_members.StaticMethods.InvokeObjectMethod("hashingSink.(Lokio/Sink;Ljavax/crypto/Mac;)Lokio/HashingSink;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_hashingSink);
				GC.KeepAlive(mac);
			}
		}

		[Register("hashingSource", "(Lokio/Source;Ljava/security/MessageDigest;)Lokio/HashingSource;", "")]
		public unsafe static HashingSource HashingSource(ISource _this_hashingSource, MessageDigest digest)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_hashingSource == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_hashingSource).Handle);
				ptr[1] = new JniArgumentValue(digest?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<HashingSource>(_members.StaticMethods.InvokeObjectMethod("hashingSource.(Lokio/Source;Ljava/security/MessageDigest;)Lokio/HashingSource;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_hashingSource);
				GC.KeepAlive(digest);
			}
		}

		[Register("hashingSource", "(Lokio/Source;Ljavax/crypto/Mac;)Lokio/HashingSource;", "")]
		public unsafe static HashingSource HashingSource(ISource _this_hashingSource, Mac mac)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_hashingSource == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_hashingSource).Handle);
				ptr[1] = new JniArgumentValue(mac?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<HashingSource>(_members.StaticMethods.InvokeObjectMethod("hashingSource.(Lokio/Source;Ljavax/crypto/Mac;)Lokio/HashingSource;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_hashingSource);
				GC.KeepAlive(mac);
			}
		}

		[Register("isAndroidGetsocknameError", "(Ljava/lang/AssertionError;)Z", "")]
		public unsafe static bool IsAndroidGetsocknameError(AssertionError _this_isAndroidGetsocknameError)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(_this_isAndroidGetsocknameError?.Handle ?? IntPtr.Zero);
				return _members.StaticMethods.InvokeBooleanMethod("isAndroidGetsocknameError.(Ljava/lang/AssertionError;)Z", ptr);
			}
			finally
			{
				GC.KeepAlive(_this_isAndroidGetsocknameError);
			}
		}

		[Register("sink", "(Ljava/io/File;)Lokio/Sink;", "")]
		public unsafe static ISink Sink(Java.IO.File file)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(file?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ISink>(_members.StaticMethods.InvokeObjectMethod("sink.(Ljava/io/File;)Lokio/Sink;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(file);
			}
		}

		[Register("sink", "(Ljava/io/File;Z)Lokio/Sink;", "")]
		public unsafe static ISink Sink(Java.IO.File file, bool append)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(file?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(append);
				return Java.Lang.Object.GetObject<ISink>(_members.StaticMethods.InvokeObjectMethod("sink.(Ljava/io/File;Z)Lokio/Sink;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(file);
			}
		}

		[Register("sink", "(Ljava/io/OutputStream;)Lokio/Sink;", "")]
		public unsafe static ISink Sink(Stream @out)
		{
			IntPtr intPtr = OutputStreamAdapter.ToLocalJniHandle(@out);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ISink>(_members.StaticMethods.InvokeObjectMethod("sink.(Ljava/io/OutputStream;)Lokio/Sink;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(@out);
			}
		}

		[Register("sink", "(Ljava/net/Socket;)Lokio/Sink;", "")]
		public unsafe static ISink Sink(Socket socket)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(socket?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ISink>(_members.StaticMethods.InvokeObjectMethod("sink.(Ljava/net/Socket;)Lokio/Sink;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(socket);
			}
		}

		[Register("sink", "(Ljava/nio/file/Path;[Ljava/nio/file/OpenOption;)Lokio/Sink;", "")]
		public unsafe static ISink Sink(IPath path, params IOpenOption[] options)
		{
			IntPtr intPtr = JNIEnv.NewArray(options);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((path == null) ? IntPtr.Zero : ((Java.Lang.Object)path).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ISink>(_members.StaticMethods.InvokeObjectMethod("sink.(Ljava/nio/file/Path;[Ljava/nio/file/OpenOption;)Lokio/Sink;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (options != null)
				{
					JNIEnv.CopyArray(intPtr, options);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(path);
				GC.KeepAlive(options);
			}
		}

		[Register("source", "(Ljava/io/File;)Lokio/Source;", "")]
		public unsafe static ISource Source(Java.IO.File file)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(file?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ISource>(_members.StaticMethods.InvokeObjectMethod("source.(Ljava/io/File;)Lokio/Source;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(file);
			}
		}

		[Register("source", "(Ljava/io/InputStream;)Lokio/Source;", "")]
		public unsafe static ISource Source(Stream @in)
		{
			IntPtr intPtr = InputStreamAdapter.ToLocalJniHandle(@in);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ISource>(_members.StaticMethods.InvokeObjectMethod("source.(Ljava/io/InputStream;)Lokio/Source;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(@in);
			}
		}

		[Register("source", "(Ljava/net/Socket;)Lokio/Source;", "")]
		public unsafe static ISource Source(Socket socket)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(socket?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ISource>(_members.StaticMethods.InvokeObjectMethod("source.(Ljava/net/Socket;)Lokio/Source;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(socket);
			}
		}

		[Register("source", "(Ljava/nio/file/Path;[Ljava/nio/file/OpenOption;)Lokio/Source;", "")]
		public unsafe static ISource Source(IPath path, params IOpenOption[] options)
		{
			IntPtr intPtr = JNIEnv.NewArray(options);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((path == null) ? IntPtr.Zero : ((Java.Lang.Object)path).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ISource>(_members.StaticMethods.InvokeObjectMethod("source.(Ljava/nio/file/Path;[Ljava/nio/file/OpenOption;)Lokio/Source;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (options != null)
				{
					JNIEnv.CopyArray(intPtr, options);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(path);
				GC.KeepAlive(options);
			}
		}

		[Register("use", "(Ljava/io/Closeable;Lkotlin/jvm/functions/Function1;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T extends java.io.Closeable", "R" })]
		public unsafe static Java.Lang.Object Use(Java.Lang.Object _this_use, IFunction1 block)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(_this_use);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("use.(Ljava/io/Closeable;Lkotlin/jvm/functions/Function1;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(_this_use);
				GC.KeepAlive(block);
			}
		}
	}
	[Register("okio/Pipe", DoNotGenerateAcw = true)]
	public sealed class Pipe : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/Pipe", typeof(Pipe));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Pipe(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(J)V", "")]
		public unsafe Pipe(long maxBufferSize)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(maxBufferSize);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(J)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(J)V", this, ptr);
			}
		}

		[Register("cancel", "()V", "")]
		public unsafe void Cancel()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("cancel.()V", this, null);
		}

		[Register("fold", "(Lokio/Sink;)V", "")]
		public unsafe void Fold(ISink sink)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("fold.(Lokio/Sink;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(sink);
			}
		}

		[Register("sink", "()Lokio/Sink;", "")]
		public unsafe ISink Sink()
		{
			return Java.Lang.Object.GetObject<ISink>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("sink.()Lokio/Sink;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("source", "()Lokio/Source;", "")]
		public unsafe ISource Source()
		{
			return Java.Lang.Object.GetObject<ISource>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("source.()Lokio/Source;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("okio/Throttler", DoNotGenerateAcw = true)]
	public sealed class Throttler : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/Throttler", typeof(Throttler));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Throttler(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Throttler()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("bytesPerSecond", "(J)V", "")]
		public unsafe void BytesPerSecond(long bytesPerSecond)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(bytesPerSecond);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("bytesPerSecond.(J)V", this, ptr);
		}

		[Register("bytesPerSecond", "(JJ)V", "")]
		public unsafe void BytesPerSecond(long bytesPerSecond, long waitByteCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(bytesPerSecond);
			ptr[1] = new JniArgumentValue(waitByteCount);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("bytesPerSecond.(JJ)V", this, ptr);
		}

		[Register("bytesPerSecond", "(JJJ)V", "")]
		public unsafe void BytesPerSecond(long bytesPerSecond, long waitByteCount, long maxByteCount)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
			*ptr = new JniArgumentValue(bytesPerSecond);
			ptr[1] = new JniArgumentValue(waitByteCount);
			ptr[2] = new JniArgumentValue(maxByteCount);
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("bytesPerSecond.(JJJ)V", this, ptr);
		}

		[Register("sink", "(Lokio/Sink;)Lokio/Sink;", "")]
		public unsafe ISink Sink(ISink sink)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((sink == null) ? IntPtr.Zero : ((Java.Lang.Object)sink).Handle);
				return Java.Lang.Object.GetObject<ISink>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("sink.(Lokio/Sink;)Lokio/Sink;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(sink);
			}
		}

		[Register("source", "(Lokio/Source;)Lokio/Source;", "")]
		public unsafe ISource Source(ISource source)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((source == null) ? IntPtr.Zero : ((Java.Lang.Object)source).Handle);
				return Java.Lang.Object.GetObject<ISource>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("source.(Lokio/Source;)Lokio/Source;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(source);
			}
		}
	}
	[Register("okio/Timeout", DoNotGenerateAcw = true)]
	public class Timeout : Java.Lang.Object
	{
		[Register("okio/Timeout$Companion", DoNotGenerateAcw = true)]
		public sealed class CompanionStatic : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("okio/Timeout$Companion", typeof(CompanionStatic));

			internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			internal CompanionStatic(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("minTimeout", "(JJ)J", "")]
			public unsafe long MinTimeout(long aNanos, long bNanos)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(aNanos);
				ptr[1] = new JniArgumentValue(bNanos);
				return _members.InstanceMethods.InvokeNonvirtualInt64Method("minTimeout.(JJ)J", this, ptr);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/Timeout", typeof(Timeout));

		private static Delegate cb_hasDeadline;

		private static Delegate cb_clearDeadline;

		private static Delegate cb_clearTimeout;

		private static Delegate cb_deadlineNanoTime;

		private static Delegate cb_deadlineNanoTime_J;

		private static Delegate cb_throwIfReached;

		private static Delegate cb_timeout_JLjava_util_concurrent_TimeUnit_;

		private static Delegate cb_timeoutNanos;

		[Register("Companion")]
		public static CompanionStatic Companion => Java.Lang.Object.GetObject<CompanionStatic>(_members.StaticFields.GetObjectValue("Companion.Lokio/Timeout$Companion;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NONE")]
		public static Timeout None => Java.Lang.Object.GetObject<Timeout>(_members.StaticFields.GetObjectValue("NONE.Lokio/Timeout;").Handle, JniHandleOwnership.TransferLocalRef);

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe virtual bool HasDeadline
		{
			[Register("hasDeadline", "()Z", "GetHasDeadlineHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasDeadline.()Z", this, null);
			}
		}

		protected Timeout(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Timeout()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetHasDeadlineHandler()
		{
			if ((object)cb_hasDeadline == null)
			{
				cb_hasDeadline = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasDeadline));
			}
			return cb_hasDeadline;
		}

		private static bool n_HasDeadline(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Timeout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasDeadline;
		}

		private static Delegate GetClearDeadlineHandler()
		{
			if ((object)cb_clearDeadline == null)
			{
				cb_clearDeadline = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ClearDeadline));
			}
			return cb_clearDeadline;
		}

		private static IntPtr n_ClearDeadline(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Timeout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearDeadline());
		}

		[Register("clearDeadline", "()Lokio/Timeout;", "GetClearDeadlineHandler")]
		public unsafe virtual Timeout ClearDeadline()
		{
			return Java.Lang.Object.GetObject<Timeout>(_members.InstanceMethods.InvokeVirtualObjectMethod("clearDeadline.()Lokio/Timeout;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetClearTimeoutHandler()
		{
			if ((object)cb_clearTimeout == null)
			{
				cb_clearTimeout = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_ClearTimeout));
			}
			return cb_clearTimeout;
		}

		private static IntPtr n_ClearTimeout(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Timeout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ClearTimeout());
		}

		[Register("clearTimeout", "()Lokio/Timeout;", "GetClearTimeoutHandler")]
		public unsafe virtual Timeout ClearTimeout()
		{
			return Java.Lang.Object.GetObject<Timeout>(_members.InstanceMethods.InvokeVirtualObjectMethod("clearTimeout.()Lokio/Timeout;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("deadline", "(JLjava/util/concurrent/TimeUnit;)Lokio/Timeout;", "")]
		public unsafe Timeout Deadline(long duration, TimeUnit unit)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(duration);
				ptr[1] = new JniArgumentValue(unit?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Timeout>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("deadline.(JLjava/util/concurrent/TimeUnit;)Lokio/Timeout;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(unit);
			}
		}

		private static Delegate GetDeadlineNanoTimeHandler()
		{
			if ((object)cb_deadlineNanoTime == null)
			{
				cb_deadlineNanoTime = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_DeadlineNanoTime));
			}
			return cb_deadlineNanoTime;
		}

		private static long n_DeadlineNanoTime(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Timeout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DeadlineNanoTime();
		}

		[Register("deadlineNanoTime", "()J", "GetDeadlineNanoTimeHandler")]
		public unsafe virtual long DeadlineNanoTime()
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("deadlineNanoTime.()J", this, null);
		}

		private static Delegate GetDeadlineNanoTime_JHandler()
		{
			if ((object)cb_deadlineNanoTime_J == null)
			{
				cb_deadlineNanoTime_J = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJ_L(n_DeadlineNanoTime_J));
			}
			return cb_deadlineNanoTime_J;
		}

		private static IntPtr n_DeadlineNanoTime_J(IntPtr jnienv, IntPtr native__this, long deadlineNanoTime)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Timeout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DeadlineNanoTime(deadlineNanoTime));
		}

		[Register("deadlineNanoTime", "(J)Lokio/Timeout;", "GetDeadlineNanoTime_JHandler")]
		public unsafe virtual Timeout DeadlineNanoTime(long deadlineNanoTime)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(deadlineNanoTime);
			return Java.Lang.Object.GetObject<Timeout>(_members.InstanceMethods.InvokeVirtualObjectMethod("deadlineNanoTime.(J)Lokio/Timeout;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("intersectWith", "(Lokio/Timeout;Lkotlin/jvm/functions/Function0;)V", "")]
		public unsafe void IntersectWith(Timeout other, IFunction0 block)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("intersectWith.(Lokio/Timeout;Lkotlin/jvm/functions/Function0;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(other);
				GC.KeepAlive(block);
			}
		}

		private static Delegate GetThrowIfReachedHandler()
		{
			if ((object)cb_throwIfReached == null)
			{
				cb_throwIfReached = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ThrowIfReached));
			}
			return cb_throwIfReached;
		}

		private static void n_ThrowIfReached(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<Timeout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ThrowIfReached();
		}

		[Register("throwIfReached", "()V", "GetThrowIfReachedHandler")]
		public unsafe virtual void ThrowIfReached()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("throwIfReached.()V", this, null);
		}

		private static Delegate GetInvokeTimeout_JLjava_util_concurrent_TimeUnit_Handler()
		{
			if ((object)cb_timeout_JLjava_util_concurrent_TimeUnit_ == null)
			{
				cb_timeout_JLjava_util_concurrent_TimeUnit_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJL_L(n_InvokeTimeout_JLjava_util_concurrent_TimeUnit_));
			}
			return cb_timeout_JLjava_util_concurrent_TimeUnit_;
		}

		private static IntPtr n_InvokeTimeout_JLjava_util_concurrent_TimeUnit_(IntPtr jnienv, IntPtr native__this, long timeout, IntPtr native_unit)
		{
			Timeout timeout2 = Java.Lang.Object.GetObject<Timeout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			TimeUnit unit = Java.Lang.Object.GetObject<TimeUnit>(native_unit, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(timeout2.InvokeTimeout(timeout, unit));
		}

		[Register("timeout", "(JLjava/util/concurrent/TimeUnit;)Lokio/Timeout;", "GetInvokeTimeout_JLjava_util_concurrent_TimeUnit_Handler")]
		public unsafe virtual Timeout InvokeTimeout(long timeout, TimeUnit unit)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(timeout);
				ptr[1] = new JniArgumentValue(unit?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Timeout>(_members.InstanceMethods.InvokeVirtualObjectMethod("timeout.(JLjava/util/concurrent/TimeUnit;)Lokio/Timeout;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(unit);
			}
		}

		private static Delegate GetTimeoutNanosHandler()
		{
			if ((object)cb_timeoutNanos == null)
			{
				cb_timeoutNanos = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_J(n_TimeoutNanos));
			}
			return cb_timeoutNanos;
		}

		private static long n_TimeoutNanos(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<Timeout>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TimeoutNanos();
		}

		[Register("timeoutNanos", "()J", "GetTimeoutNanosHandler")]
		public unsafe virtual long TimeoutNanos()
		{
			return _members.InstanceMethods.InvokeVirtualInt64Method("timeoutNanos.()J", this, null);
		}

		[Register("waitUntilNotified", "(Ljava/lang/Object;)V", "")]
		public unsafe void WaitUntilNotified(Java.Lang.Object monitor)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(monitor?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("waitUntilNotified.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(monitor);
			}
		}
	}
	[Register("okio/Utf8", DoNotGenerateAcw = true)]
	public sealed class Utf8 : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("okio/Utf8", typeof(Utf8));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal Utf8(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("size", "(Ljava/lang/String;)J", "")]
		public unsafe static long Size(string @string)
		{
			IntPtr intPtr = JNIEnv.NewString(@string);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.StaticMethods.InvokeInt64Method("size.(Ljava/lang/String;)J", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("size", "(Ljava/lang/String;I)J", "")]
		public unsafe static long Size(string @string, int beginIndex)
		{
			IntPtr intPtr = JNIEnv.NewString(@string);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(beginIndex);
				return _members.StaticMethods.InvokeInt64Method("size.(Ljava/lang/String;I)J", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("size", "(Ljava/lang/String;II)J", "")]
		public unsafe static long Size(string @string, int beginIndex, int endIndex)
		{
			IntPtr intPtr = JNIEnv.NewString(@string);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(beginIndex);
				ptr[2] = new JniArgumentValue(endIndex);
				return _members.StaticMethods.InvokeInt64Method("size.(Ljava/lang/String;II)J", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
}
