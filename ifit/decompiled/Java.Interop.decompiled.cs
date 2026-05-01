using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Text;
using System.Threading;
using Microsoft.CodeAnalysis;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: DefaultDllImportSearchPaths(DllImportSearchPath.SafeDirectories | DllImportSearchPath.AssemblyDirectory)]
[assembly: AssemblyDescription("")]
[assembly: AssemblyTrademark("Microsoft Corporation")]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: InternalsVisibleTo("Java.Interop.GenericMarshaler, PublicKey=0024000004800000940000000602000000240000525341310004000011000000438ac2a5acfbf16cbd2b2b47a62762f273df9cb2795ceccdf77d10bf508e69e7a362ea7a45455bbf3ac955e1f2e2814f144e5d817efc4c6502cc012df310783348304e3ae38573c6d658c234025821fda87a0be8a0d504df564e2c93b2b878925f42503e9d54dfef9f9586d9e6f38a305769587b1de01f6c0410328b2c9733db")]
[assembly: InternalsVisibleTo("Java.Interop-Tests, PublicKey=0024000004800000940000000602000000240000525341310004000011000000438ac2a5acfbf16cbd2b2b47a62762f273df9cb2795ceccdf77d10bf508e69e7a362ea7a45455bbf3ac955e1f2e2814f144e5d817efc4c6502cc012df310783348304e3ae38573c6d658c234025821fda87a0be8a0d504df564e2c93b2b878925f42503e9d54dfef9f9586d9e6f38a305769587b1de01f6c0410328b2c9733db")]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("Microsoft Corporation")]
[assembly: AssemblyFileVersion("0.1.0.0")]
[assembly: AssemblyInformationalVersion("")]
[assembly: AssemblyProduct("Java.Interop")]
[assembly: AssemblyTitle("Java.Interop")]
[assembly: TargetFramework("MonoAndroid,Version=v1.0", FrameworkDisplayName = "Xamarin.Android Base Class Libraries")]
[assembly: AssemblyVersion("0.1.0.0")]
[module: UnverifiableCode]
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
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.GenericParameter, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableAttribute : Attribute
	{
		public readonly byte[] NullableFlags;

		public NullableAttribute(byte P_0)
		{
			NullableFlags = new byte[1] { P_0 };
		}

		public NullableAttribute(byte[] P_0)
		{
			NullableFlags = P_0;
		}
	}
}
namespace Java.Interop
{
	public interface IJavaPeerable : IDisposable
	{
		int JniIdentityHashCode { get; }

		JniObjectReference PeerReference { get; }

		JniPeerMembers JniPeerMembers { get; }

		JniManagedPeerStates JniManagedPeerState { get; }

		void SetJniIdentityHashCode(int value);

		void SetPeerReference(JniObjectReference reference);

		void SetJniManagedPeerState(JniManagedPeerStates value);

		void DisposeUnlessReferenced();

		void Disposed();

		void Finalized();
	}
	public abstract class JavaArray<T> : JavaObject, IList, ICollection, IEnumerable, IList<T>, ICollection<T>, IEnumerable<T>
	{
		internal delegate TArray ArrayCreator<TArray>(ref JniObjectReference reference, JniObjectReferenceOptions transfer) where TArray : JavaArray<T>;

		internal bool forMarshalCollection;

		public int Length => JniEnvironment.Arrays.GetArrayLength(base.PeerReference);

		public abstract T this[int index] { get; set; }

		public bool IsReadOnly => false;

		bool ICollection.IsSynchronized => false;

		object ICollection.SyncRoot => this;

		int ICollection<T>.Count => Length;

		int ICollection.Count => Length;

		bool IList.IsFixedSize => true;

		object IList.this[int index]
		{
			get
			{
				return this[index];
			}
			set
			{
				this[index] = (T)value;
			}
		}

		internal JavaArray(ref JniObjectReference handle, JniObjectReferenceOptions transfer)
			: base(ref handle, transfer)
		{
		}

		public abstract void Clear();

		public abstract void CopyTo(T[] array, int arrayIndex);

		public abstract int IndexOf(T item);

		public virtual bool Contains(T item)
		{
			return IndexOf(item) >= 0;
		}

		public T[] ToArray()
		{
			T[] array = new T[Length];
			CopyTo(array, 0);
			return array;
		}

		public virtual IEnumerator<T> GetEnumerator()
		{
			int len = Length;
			int i = 0;
			while (i < len)
			{
				yield return this[i];
				int num = i + 1;
				i = num;
			}
		}

		internal static void CheckArrayCopy(int sourceIndex, int sourceLength, int destinationIndex, int destinationLength, int length)
		{
			if (sourceIndex < 0)
			{
				throw new ArgumentOutOfRangeException("sourceIndex", $"source index must be >= 0; was {sourceIndex}.");
			}
			if (sourceIndex != 0 && sourceIndex >= sourceLength)
			{
				throw new ArgumentException("source index is > source length.", "sourceIndex");
			}
			checked
			{
				if (sourceIndex + length > sourceLength)
				{
					throw new ArgumentException("source index + length >= source length", "length");
				}
				if (destinationIndex < 0)
				{
					throw new ArgumentOutOfRangeException("destinationIndex", $"destination index must be >= 0; was {destinationIndex}.");
				}
				if (destinationIndex != 0 && destinationIndex >= destinationLength)
				{
					throw new ArgumentException("destination index is > destination length.", "destinationIndex");
				}
				if (destinationIndex + length > destinationLength)
				{
					throw new ArgumentException("destination index + length >= destination length", "length");
				}
			}
		}

		internal static int CheckLength(int length)
		{
			if (length < 0)
			{
				throw new ArgumentException("'length' cannot be negative.", "length");
			}
			return length;
		}

		internal static int CheckLength(IList<T> value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			return value.Count;
		}

		internal IList<T> ToTargetType(Type targetType, bool dispose)
		{
			if (TargetTypeIsCurrentType(targetType))
			{
				return this;
			}
			if (targetType == typeof(T[]) || targetType.IsAssignableFrom(typeof(IList<T>)))
			{
				try
				{
					return ToArray();
				}
				finally
				{
					if (dispose)
					{
						Dispose();
					}
				}
			}
			throw CreateMarshalNotSupportedException(GetType(), targetType);
		}

		internal virtual bool TargetTypeIsCurrentType(Type targetType)
		{
			if (!(targetType == null))
			{
				return targetType == typeof(JavaArray<T>);
			}
			return true;
		}

		internal static Exception CreateMarshalNotSupportedException(Type sourceType, Type targetType)
		{
			return new NotSupportedException(string.Format("Do not know how to marshal a `{0}`{1}.", sourceType.FullName, (targetType != null) ? (" into a `" + targetType.FullName + "`") : ""));
		}

		internal static IList<T> CreateValue<TArray>(ref JniObjectReference reference, JniObjectReferenceOptions transfer, Type targetType, ArrayCreator<TArray> creator) where TArray : JavaArray<T>
		{
			return creator(ref reference, transfer).ToTargetType(targetType, dispose: true);
		}

		internal static JniValueMarshalerState CreateArgumentState<TArray>(IList<T> value, ParameterAttributes synchronize, Func<IList<T>, bool, TArray> creator) where TArray : JavaArray<T>
		{
			if (value == null)
			{
				return default(JniValueMarshalerState);
			}
			if (value is TArray peerableValue)
			{
				return new JniValueMarshalerState(peerableValue);
			}
			if (value == null)
			{
				throw CreateMarshalNotSupportedException(value.GetType(), typeof(TArray));
			}
			synchronize = GetCopyDirection(synchronize);
			bool arg = (synchronize & ParameterAttributes.In) == ParameterAttributes.In;
			return new JniValueMarshalerState(creator(value, arg));
		}

		internal static void DestroyArgumentState<TArray>(IList<T> value, ref JniValueMarshalerState state, ParameterAttributes synchronize) where TArray : JavaArray<T>
		{
			TArray val = (TArray)state.PeerableValue;
			if (val == null)
			{
				return;
			}
			synchronize = GetCopyDirection(synchronize);
			if ((synchronize & ParameterAttributes.Out) == ParameterAttributes.Out)
			{
				T[] array = value as T[];
				if (array != null)
				{
					val.CopyTo(array, 0);
				}
				else if (value != null)
				{
					val.CopyToList(value, 0);
				}
			}
			if (val.forMarshalCollection)
			{
				val.Dispose();
			}
			state = default(JniValueMarshalerState);
		}

		internal static ParameterAttributes GetCopyDirection(ParameterAttributes value)
		{
			if ((value & (ParameterAttributes.In | ParameterAttributes.Out)) != ParameterAttributes.None)
			{
				return value & (ParameterAttributes.In | ParameterAttributes.Out);
			}
			return ParameterAttributes.In | ParameterAttributes.Out;
		}

		internal virtual void CopyToList(IList<T> list, int index)
		{
			int length = Length;
			for (int i = 0; i < length; i++)
			{
				list[index + i] = this[i];
			}
		}

		void ICollection.CopyTo(Array array, int index)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			CheckArrayCopy(0, Length, index, array.Length, Length);
			int length = Length;
			for (int i = 0; i < length; i++)
			{
				array.SetValue(this[i], index + i);
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		void ICollection<T>.Add(T item)
		{
			throw new NotSupportedException();
		}

		bool ICollection<T>.Remove(T item)
		{
			throw new NotSupportedException();
		}

		bool IList.Contains(object value)
		{
			if (value is T)
			{
				return Contains((T)value);
			}
			return false;
		}

		int IList.IndexOf(object value)
		{
			if (value is T)
			{
				return IndexOf((T)value);
			}
			return -1;
		}

		int IList.Add(object value)
		{
			throw new NotSupportedException();
		}

		void IList.Insert(int index, object value)
		{
			throw new NotSupportedException();
		}

		void IList.Remove(object value)
		{
			throw new NotSupportedException();
		}

		void IList.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}

		void IList<T>.Insert(int index, T item)
		{
			throw new NotSupportedException();
		}

		void IList<T>.RemoveAt(int index)
		{
			throw new NotSupportedException();
		}
	}
	public abstract class JniArrayElements : IDisposable
	{
		private IntPtr elements;

		private int size;

		internal bool IsDisposed => elements == IntPtr.Zero;

		public IntPtr Elements
		{
			get
			{
				if (IsDisposed)
				{
					throw new ObjectDisposedException(GetType().FullName);
				}
				return elements;
			}
		}

		internal JniArrayElements(IntPtr elements, int size)
		{
			if (elements == IntPtr.Zero)
			{
				throw new ArgumentException("'elements' must not be IntPtr.Zero.", "elements");
			}
			this.elements = elements;
			this.size = size;
		}

		protected abstract void Synchronize(JniReleaseArrayElementsMode releaseMode);

		public void Release(JniReleaseArrayElementsMode releaseMode)
		{
			if (IsDisposed)
			{
				throw new ObjectDisposedException(GetType().FullName);
			}
			Synchronize(releaseMode);
			elements = IntPtr.Zero;
		}

		public void Dispose()
		{
			if (!IsDisposed)
			{
				Release(JniReleaseArrayElementsMode.Default);
			}
		}
	}
	public abstract class JavaPrimitiveArray<T> : JavaArray<T>
	{
		public override T this[int index]
		{
			get
			{
				T[] array = new T[1];
				CopyTo(index, array, 0, array.Length);
				return array[0];
			}
			set
			{
				if (index >= base.Length)
				{
					throw new ArgumentOutOfRangeException("index", "index >= Length");
				}
				T[] array = new T[1] { value };
				CopyFrom(array, 0, index, array.Length);
			}
		}

		internal JavaPrimitiveArray(ref JniObjectReference reference, JniObjectReferenceOptions transfer)
			: base(ref reference, transfer)
		{
		}

		public override void DisposeUnlessReferenced()
		{
			if (forMarshalCollection)
			{
				Dispose();
			}
			else
			{
				base.DisposeUnlessReferenced();
			}
		}

		public abstract void CopyTo(int sourceIndex, T[] destinationArray, int destinationIndex, int length);

		public abstract void CopyFrom(T[] sourceArray, int sourceIndex, int destinationIndex, int length);

		public override void CopyTo(T[] array, int arrayIndex)
		{
			CopyTo(0, array, arrayIndex, base.Length);
		}

		internal static T[] ToArray(IEnumerable<T> value)
		{
			if (value is T[] result)
			{
				return result;
			}
			return value.ToArray();
		}
	}
	[JniTypeSignature("java/lang/Throwable")]
	public class JavaException : Exception, IJavaPeerable, IDisposable
	{
		private static readonly JniPeerMembers _members = new JniPeerMembers("java/lang/Throwable", typeof(JavaException));

		private IntPtr handle;

		private JniObjectReferenceType handle_type;

		private IntPtr weak_handle;

		private int refs_added;

		protected unsafe static readonly JniObjectReference* InvalidJniObjectReference = null;

		public string JavaStackTrace { get; private set; }

		public int JniIdentityHashCode { get; private set; }

		public JniManagedPeerStates JniManagedPeerState { get; private set; }

		public JniObjectReference PeerReference => new JniObjectReference(handle, handle_type);

		public virtual JniPeerMembers JniPeerMembers => _members;

		public override string StackTrace => base.StackTrace + Environment.NewLine + "  --- End of managed " + GetType().FullName + " stack trace ---" + Environment.NewLine + JavaStackTrace;

		public unsafe JavaException()
			: this(ref *InvalidJniObjectReference, JniObjectReferenceOptions.None)
		{
			if (!PeerReference.IsValid)
			{
				JniObjectReference reference = JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null);
				Construct(ref reference, JniObjectReferenceOptions.CopyAndDispose);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
				JavaStackTrace = GetJavaStack(PeerReference);
			}
		}

		public unsafe JavaException(string message)
			: base(message)
		{
			JniObjectReference reference = JniEnvironment.Strings.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(reference);
				JniObjectReference reference2 = JniPeerMembers.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", GetType(), ptr);
				Construct(ref reference2, JniObjectReferenceOptions.CopyAndDispose);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JniObjectReference.Dispose(ref reference, JniObjectReferenceOptions.CopyAndDispose);
			}
			JavaStackTrace = GetJavaStack(PeerReference);
		}

		public JavaException(ref JniObjectReference reference, JniObjectReferenceOptions transfer)
			: base(GetMessage(ref reference, transfer), GetCause(ref reference, transfer))
		{
			Construct(ref reference, transfer);
			if (PeerReference.IsValid)
			{
				JavaStackTrace = GetJavaStack(PeerReference);
			}
		}

		protected void Construct(ref JniObjectReference reference, JniObjectReferenceOptions options)
		{
			JniEnvironment.Runtime.ValueManager.ConstructPeer(this, ref reference, options);
		}

		~JavaException()
		{
			JniEnvironment.Runtime.ValueManager.FinalizePeer(this);
		}

		protected void SetPeerReference(ref JniObjectReference reference, JniObjectReferenceOptions options)
		{
			if (options == JniObjectReferenceOptions.None)
			{
				((IJavaPeerable)this).SetPeerReference(default(JniObjectReference));
				return;
			}
			handle = reference.Handle;
			handle_type = reference.Type;
			JniObjectReference.Dispose(ref reference, options);
		}

		public void Dispose()
		{
			JniEnvironment.Runtime.ValueManager.DisposePeer(this);
		}

		public void DisposeUnlessReferenced()
		{
			JniEnvironment.Runtime.ValueManager.DisposePeerUnlessReferenced(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (base.InnerException is JavaException ex)
			{
				ex.Dispose();
			}
		}

		public override bool Equals(object obj)
		{
			JniPeerMembers.AssertSelf(this);
			if (obj == this)
			{
				return true;
			}
			if (obj is IJavaPeerable javaPeerable)
			{
				return JniEnvironment.Types.IsSameObject(PeerReference, javaPeerable.PeerReference);
			}
			return false;
		}

		public unsafe override int GetHashCode()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("hashCode.()I", this, null);
		}

		private static string GetMessage(ref JniObjectReference reference, JniObjectReferenceOptions transfer)
		{
			if (transfer == JniObjectReferenceOptions.None)
			{
				return null;
			}
			JniMethodInfo methodInfo = _members.InstanceMethods.GetMethodInfo("getMessage.()Ljava/lang/String;");
			JniObjectReference value = JniEnvironment.InstanceMethods.CallObjectMethod(reference, methodInfo);
			return JniEnvironment.Strings.ToString(ref value, JniObjectReferenceOptions.CopyAndDispose);
		}

		private static Exception GetCause(ref JniObjectReference reference, JniObjectReferenceOptions transfer)
		{
			if (transfer == JniObjectReferenceOptions.None)
			{
				return null;
			}
			JniMethodInfo methodInfo = _members.InstanceMethods.GetMethodInfo("getCause.()Ljava/lang/Throwable;");
			JniObjectReference reference2 = JniEnvironment.InstanceMethods.CallObjectMethod(reference, methodInfo);
			return JniEnvironment.Runtime.GetExceptionForThrowable(ref reference2, JniObjectReferenceOptions.CopyAndDispose);
		}

		private unsafe string GetJavaStack(JniObjectReference handle)
		{
			using JniType jniType = new JniType("java/io/StringWriter");
			using JniType jniType2 = new JniType("java/io/PrintWriter");
			JniMethodInfo constructor = jniType.GetConstructor("()V");
			JniMethodInfo constructor2 = jniType2.GetConstructor("(Ljava/io/Writer;)V");
			JniObjectReference reference = jniType.NewObject(constructor, null);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(reference);
				JniObjectReference reference2 = jniType2.NewObject(constructor2, ptr);
				try
				{
					JniMethodInfo methodInfo = _members.InstanceMethods.GetMethodInfo("printStackTrace.(Ljava/io/PrintWriter;)V");
					JniArgumentValue* ptr2 = stackalloc JniArgumentValue[1];
					*ptr2 = new JniArgumentValue(reference2);
					JniEnvironment.InstanceMethods.CallVoidMethod(handle, methodInfo, ptr2);
					JniObjectReference value = JniEnvironment.Object.ToString(reference);
					return JniEnvironment.Strings.ToString(ref value, JniObjectReferenceOptions.CopyAndDispose);
				}
				finally
				{
					JniObjectReference.Dispose(ref reference2, JniObjectReferenceOptions.CopyAndDispose);
				}
			}
			finally
			{
				JniObjectReference.Dispose(ref reference, JniObjectReferenceOptions.CopyAndDispose);
			}
		}

		void IJavaPeerable.Disposed()
		{
			Dispose(disposing: true);
		}

		void IJavaPeerable.Finalized()
		{
			Dispose(disposing: false);
		}

		void IJavaPeerable.SetJniIdentityHashCode(int value)
		{
			JniIdentityHashCode = value;
		}

		void IJavaPeerable.SetJniManagedPeerState(JniManagedPeerStates value)
		{
			JniManagedPeerState = value;
		}

		void IJavaPeerable.SetPeerReference(JniObjectReference reference)
		{
			SetPeerReference(ref reference, JniObjectReferenceOptions.Copy);
		}
	}
	[JniTypeSignature("java/lang/Object")]
	public class JavaObject : IJavaPeerable, IDisposable
	{
		private static readonly JniPeerMembers _members = new JniPeerMembers("java/lang/Object", typeof(JavaObject));

		private IntPtr handle;

		private JniObjectReferenceType handle_type;

		private IntPtr weak_handle;

		private int refs_added;

		protected unsafe static readonly JniObjectReference* InvalidJniObjectReference = null;

		public int JniIdentityHashCode { get; private set; }

		public JniManagedPeerStates JniManagedPeerState { get; private set; }

		public JniObjectReference PeerReference => new JniObjectReference(handle, handle_type);

		public virtual JniPeerMembers JniPeerMembers => _members;

		~JavaObject()
		{
			JniEnvironment.Runtime.ValueManager.FinalizePeer(this);
		}

		public JavaObject(ref JniObjectReference reference, JniObjectReferenceOptions options)
		{
			Construct(ref reference, options);
		}

		public unsafe JavaObject()
			: this(ref *InvalidJniObjectReference, JniObjectReferenceOptions.None)
		{
			if (!PeerReference.IsValid)
			{
				JniObjectReference reference = JniPeerMembers.InstanceMethods.StartCreateInstance("()V", GetType(), null);
				Construct(ref reference, JniObjectReferenceOptions.CopyAndDispose);
				JniPeerMembers.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		protected void Construct(ref JniObjectReference reference, JniObjectReferenceOptions options)
		{
			JniEnvironment.Runtime.ValueManager.ConstructPeer(this, ref reference, options);
		}

		protected void SetPeerReference(ref JniObjectReference reference, JniObjectReferenceOptions options)
		{
			if (options == JniObjectReferenceOptions.None)
			{
				((IJavaPeerable)this).SetPeerReference(default(JniObjectReference));
				return;
			}
			handle = reference.Handle;
			handle_type = reference.Type;
			JniObjectReference.Dispose(ref reference, options);
		}

		public void Dispose()
		{
			JniEnvironment.Runtime.ValueManager.DisposePeer(this);
		}

		public virtual void DisposeUnlessReferenced()
		{
			JniEnvironment.Runtime.ValueManager.DisposePeerUnlessReferenced(this);
		}

		protected virtual void Dispose(bool disposing)
		{
		}

		public override bool Equals(object obj)
		{
			JniPeerMembers.AssertSelf(this);
			if (obj == this)
			{
				return true;
			}
			if (obj is IJavaPeerable javaPeerable)
			{
				return JniEnvironment.Types.IsSameObject(PeerReference, javaPeerable.PeerReference);
			}
			return false;
		}

		public unsafe override int GetHashCode()
		{
			return _members.InstanceMethods.InvokeVirtualInt32Method("hashCode.()I", this, null);
		}

		public unsafe override string ToString()
		{
			JniObjectReference value = _members.InstanceMethods.InvokeVirtualObjectMethod("toString.()Ljava/lang/String;", this, null);
			return JniEnvironment.Strings.ToString(ref value, JniObjectReferenceOptions.CopyAndDispose);
		}

		void IJavaPeerable.Disposed()
		{
			Dispose(disposing: true);
		}

		void IJavaPeerable.Finalized()
		{
			Dispose(disposing: false);
		}

		void IJavaPeerable.SetJniIdentityHashCode(int value)
		{
			JniIdentityHashCode = value;
		}

		void IJavaPeerable.SetJniManagedPeerState(JniManagedPeerStates value)
		{
			JniManagedPeerState = value;
		}

		void IJavaPeerable.SetPeerReference(JniObjectReference reference)
		{
			SetPeerReference(ref reference, JniObjectReferenceOptions.Copy);
		}
	}
	public class JavaObjectArray<T> : JavaArray<T>
	{
		internal sealed class ValueMarshaler : JniValueMarshaler<IList<T>>
		{
			public override IList<T> CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
			{
				return JavaArray<T>.CreateValue(ref reference, options, targetType, delegate(ref JniObjectReference h, JniObjectReferenceOptions t)
				{
					return new JavaObjectArray<T>(ref h, t)
					{
						forMarshalCollection = true
					};
				});
			}

			public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(IList<T> value, ParameterAttributes synchronize)
			{
				return JavaArray<T>.CreateArgumentState(value, synchronize, delegate(IList<T> list, bool copy)
				{
					JavaObjectArray<T> obj = (copy ? new JavaObjectArray<T>(list) : new JavaObjectArray<T>(list.Count));
					obj.forMarshalCollection = true;
					return obj;
				});
			}

			public override void DestroyGenericArgumentState(IList<T> value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
			{
				JavaArray<T>.DestroyArgumentState<JavaObjectArray<T>>(value, ref state, synchronize);
			}
		}

		internal static readonly ValueMarshaler Instance = new ValueMarshaler();

		public override T this[int index]
		{
			get
			{
				if (index < 0 || index >= base.Length)
				{
					throw new ArgumentOutOfRangeException("index", "index < 0 || index >= Length");
				}
				return GetElementAt(index);
			}
			set
			{
				if (index < 0 || index >= base.Length)
				{
					throw new ArgumentOutOfRangeException("index", "index < 0 || index >= Length");
				}
				SetElementAt(index, value);
			}
		}

		public JavaObjectArray(ref JniObjectReference handle, JniObjectReferenceOptions options)
			: base(ref handle, options)
		{
		}

		private static JniObjectReference NewArray(int length)
		{
			JniTypeSignature jniTypeSignature = JniEnvironment.Runtime.TypeManager.GetTypeSignature(typeof(T));
			if (jniTypeSignature.SimpleReference == null)
			{
				jniTypeSignature = new JniTypeSignature("java/lang/Object", jniTypeSignature.ArrayRank);
			}
			if (jniTypeSignature.IsKeyword && jniTypeSignature.ArrayRank == 0)
			{
				jniTypeSignature = jniTypeSignature.GetPrimitivePeerTypeSignature();
			}
			using JniType jniType = new JniType(jniTypeSignature.Name);
			return JniEnvironment.Arrays.NewObjectArray(length, jniType.PeerReference, default(JniObjectReference));
		}

		public unsafe JavaObjectArray(int length)
			: this(ref *JavaObject.InvalidJniObjectReference, JniObjectReferenceOptions.None)
		{
			JniObjectReference reference = NewArray(JavaArray<T>.CheckLength(length));
			Construct(ref reference, JniObjectReferenceOptions.CopyAndDispose);
		}

		public JavaObjectArray(IList<T> value)
			: this(JavaArray<T>.CheckLength(value))
		{
			for (int i = 0; i < value.Count; i++)
			{
				SetElementAt(i, value[i]);
			}
		}

		public override void DisposeUnlessReferenced()
		{
			if (forMarshalCollection)
			{
				Dispose();
			}
			else
			{
				base.DisposeUnlessReferenced();
			}
		}

		private T GetElementAt(int index)
		{
			JniObjectReference reference = JniEnvironment.Arrays.GetObjectArrayElement(base.PeerReference, index);
			return JniEnvironment.Runtime.ValueManager.GetValue<T>(ref reference, JniObjectReferenceOptions.CopyAndDispose);
		}

		private void SetElementAt(int index, T value)
		{
			JniValueMarshaler<T> valueMarshaler = JniEnvironment.Runtime.ValueManager.GetValueMarshaler<T>();
			JniValueMarshalerState state = valueMarshaler.CreateGenericObjectReferenceArgumentState(value);
			JniEnvironment.Arrays.SetObjectArrayElement(base.PeerReference, index, state.ReferenceValue);
			valueMarshaler.DestroyGenericArgumentState(value, ref state);
		}

		public override IEnumerator<T> GetEnumerator()
		{
			int len = base.Length;
			int i = 0;
			while (i < len)
			{
				yield return GetElementAt(i);
				int num = i + 1;
				i = num;
			}
		}

		public override void Clear()
		{
			int length = base.Length;
			JniValueMarshaler<T> valueMarshaler = JniEnvironment.Runtime.ValueManager.GetValueMarshaler<T>();
			JniValueMarshalerState state = valueMarshaler.CreateArgumentState(default(T));
			for (int i = 0; i < length; i++)
			{
				JniEnvironment.Arrays.SetObjectArrayElement(base.PeerReference, i, state.ReferenceValue);
			}
			valueMarshaler.DestroyGenericArgumentState(default(T), ref state);
		}

		public override int IndexOf(T item)
		{
			int length = base.Length;
			for (int i = 0; i < length; i++)
			{
				T elementAt = GetElementAt(i);
				try
				{
					if (EqualityComparer<T>.Default.Equals(item, elementAt) || JniMarshal.RecursiveEquals(item, elementAt))
					{
						return i;
					}
				}
				finally
				{
					if (elementAt is IJavaPeerable javaPeerable)
					{
						javaPeerable.DisposeUnlessReferenced();
					}
				}
			}
			return -1;
		}

		public override void CopyTo(T[] array, int arrayIndex)
		{
			if (array == null)
			{
				throw new ArgumentNullException("array");
			}
			JavaArray<T>.CheckArrayCopy(0, base.Length, arrayIndex, array.Length, base.Length);
			CopyToList(array, arrayIndex);
		}

		internal override void CopyToList(IList<T> list, int index)
		{
			int length = base.Length;
			for (int i = 0; i < length; i++)
			{
				T val = (list[index + i] = GetElementAt(i));
				if (forMarshalCollection && val is IJavaPeerable javaPeerable)
				{
					javaPeerable.DisposeUnlessReferenced();
				}
			}
		}

		internal override bool TargetTypeIsCurrentType(Type targetType)
		{
			if (!base.TargetTypeIsCurrentType(targetType))
			{
				return targetType == typeof(JavaObjectArray<T>);
			}
			return true;
		}
	}
	public static class JniEnvironment
	{
		public static class Arrays
		{
			public static int GetArrayLength(JniObjectReference array)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				return NativeMethods.java_interop_jnienv_get_array_length(EnvironmentPointer, array.Handle);
			}

			public static JniObjectReference NewObjectArray(int length, JniObjectReference elementClass, JniObjectReference initialElement)
			{
				if (!elementClass.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "elementClass");
				}
				IntPtr thrown;
				IntPtr intPtr = NativeMethods.java_interop_jnienv_new_object_array(EnvironmentPointer, out thrown, length, elementClass.Handle, initialElement.Handle);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			public static JniObjectReference GetObjectArrayElement(JniObjectReference array, int index)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				IntPtr thrown;
				IntPtr intPtr = NativeMethods.java_interop_jnienv_get_object_array_element(EnvironmentPointer, out thrown, array.Handle, index);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			public static void SetObjectArrayElement(JniObjectReference array, int index, JniObjectReference value)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_set_object_array_element(EnvironmentPointer, out var thrown, array.Handle, index, value.Handle);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}

			public static JniObjectReference NewBooleanArray(int length)
			{
				IntPtr intPtr = NativeMethods.java_interop_jnienv_new_boolean_array(EnvironmentPointer, length);
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			public static JniObjectReference NewByteArray(int length)
			{
				IntPtr intPtr = NativeMethods.java_interop_jnienv_new_byte_array(EnvironmentPointer, length);
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			public static JniObjectReference NewCharArray(int length)
			{
				IntPtr intPtr = NativeMethods.java_interop_jnienv_new_char_array(EnvironmentPointer, length);
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			public static JniObjectReference NewShortArray(int length)
			{
				IntPtr intPtr = NativeMethods.java_interop_jnienv_new_short_array(EnvironmentPointer, length);
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			public static JniObjectReference NewIntArray(int length)
			{
				IntPtr intPtr = NativeMethods.java_interop_jnienv_new_int_array(EnvironmentPointer, length);
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			public static JniObjectReference NewLongArray(int length)
			{
				IntPtr intPtr = NativeMethods.java_interop_jnienv_new_long_array(EnvironmentPointer, length);
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			public static JniObjectReference NewFloatArray(int length)
			{
				IntPtr intPtr = NativeMethods.java_interop_jnienv_new_float_array(EnvironmentPointer, length);
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			public static JniObjectReference NewDoubleArray(int length)
			{
				IntPtr intPtr = NativeMethods.java_interop_jnienv_new_double_array(EnvironmentPointer, length);
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			public unsafe static bool* GetBooleanArrayElements(JniObjectReference array, bool* isCopy)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				return NativeMethods.java_interop_jnienv_get_boolean_array_elements(EnvironmentPointer, array.Handle, isCopy);
			}

			public unsafe static sbyte* GetByteArrayElements(JniObjectReference array, bool* isCopy)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				return NativeMethods.java_interop_jnienv_get_byte_array_elements(EnvironmentPointer, array.Handle, isCopy);
			}

			public unsafe static char* GetCharArrayElements(JniObjectReference array, bool* isCopy)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				return NativeMethods.java_interop_jnienv_get_char_array_elements(EnvironmentPointer, array.Handle, isCopy);
			}

			public unsafe static short* GetShortArrayElements(JniObjectReference array, bool* isCopy)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				return NativeMethods.java_interop_jnienv_get_short_array_elements(EnvironmentPointer, array.Handle, isCopy);
			}

			public unsafe static int* GetIntArrayElements(JniObjectReference array, bool* isCopy)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				return NativeMethods.java_interop_jnienv_get_int_array_elements(EnvironmentPointer, array.Handle, isCopy);
			}

			public unsafe static long* GetLongArrayElements(JniObjectReference array, bool* isCopy)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				return NativeMethods.java_interop_jnienv_get_long_array_elements(EnvironmentPointer, array.Handle, isCopy);
			}

			public unsafe static float* GetFloatArrayElements(JniObjectReference array, bool* isCopy)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				return NativeMethods.java_interop_jnienv_get_float_array_elements(EnvironmentPointer, array.Handle, isCopy);
			}

			public unsafe static double* GetDoubleArrayElements(JniObjectReference array, bool* isCopy)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				return NativeMethods.java_interop_jnienv_get_double_array_elements(EnvironmentPointer, array.Handle, isCopy);
			}

			public unsafe static void ReleaseBooleanArrayElements(JniObjectReference array, bool* elements, JniReleaseArrayElementsMode mode)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_release_boolean_array_elements(EnvironmentPointer, array.Handle, elements, (int)mode);
			}

			public unsafe static void ReleaseByteArrayElements(JniObjectReference array, sbyte* elements, JniReleaseArrayElementsMode mode)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_release_byte_array_elements(EnvironmentPointer, array.Handle, elements, (int)mode);
			}

			public unsafe static void ReleaseCharArrayElements(JniObjectReference array, char* elements, JniReleaseArrayElementsMode mode)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_release_char_array_elements(EnvironmentPointer, array.Handle, elements, (int)mode);
			}

			public unsafe static void ReleaseShortArrayElements(JniObjectReference array, short* elements, JniReleaseArrayElementsMode mode)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_release_short_array_elements(EnvironmentPointer, array.Handle, elements, (int)mode);
			}

			public unsafe static void ReleaseIntArrayElements(JniObjectReference array, int* elements, JniReleaseArrayElementsMode mode)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_release_int_array_elements(EnvironmentPointer, array.Handle, elements, (int)mode);
			}

			public unsafe static void ReleaseLongArrayElements(JniObjectReference array, long* elements, JniReleaseArrayElementsMode mode)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_release_long_array_elements(EnvironmentPointer, array.Handle, elements, (int)mode);
			}

			public unsafe static void ReleaseFloatArrayElements(JniObjectReference array, float* elements, JniReleaseArrayElementsMode mode)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_release_float_array_elements(EnvironmentPointer, array.Handle, elements, (int)mode);
			}

			public unsafe static void ReleaseDoubleArrayElements(JniObjectReference array, double* elements, JniReleaseArrayElementsMode mode)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_release_double_array_elements(EnvironmentPointer, array.Handle, elements, (int)mode);
			}

			public unsafe static void GetBooleanArrayRegion(JniObjectReference array, int start, int length, bool* buffer)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_get_boolean_array_region(EnvironmentPointer, out var thrown, array.Handle, start, length, buffer);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}

			public unsafe static void GetByteArrayRegion(JniObjectReference array, int start, int length, sbyte* buffer)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_get_byte_array_region(EnvironmentPointer, out var thrown, array.Handle, start, length, buffer);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}

			public unsafe static void GetCharArrayRegion(JniObjectReference array, int start, int length, char* buffer)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_get_char_array_region(EnvironmentPointer, out var thrown, array.Handle, start, length, buffer);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}

			public unsafe static void GetShortArrayRegion(JniObjectReference array, int start, int length, short* buffer)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_get_short_array_region(EnvironmentPointer, out var thrown, array.Handle, start, length, buffer);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}

			public unsafe static void GetIntArrayRegion(JniObjectReference array, int start, int length, int* buffer)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_get_int_array_region(EnvironmentPointer, out var thrown, array.Handle, start, length, buffer);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}

			public unsafe static void GetLongArrayRegion(JniObjectReference array, int start, int length, long* buffer)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_get_long_array_region(EnvironmentPointer, out var thrown, array.Handle, start, length, buffer);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}

			public unsafe static void GetFloatArrayRegion(JniObjectReference array, int start, int length, float* buffer)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_get_float_array_region(EnvironmentPointer, out var thrown, array.Handle, start, length, buffer);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}

			public unsafe static void GetDoubleArrayRegion(JniObjectReference array, int start, int length, double* buffer)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_get_double_array_region(EnvironmentPointer, out var thrown, array.Handle, start, length, buffer);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}

			public unsafe static void SetBooleanArrayRegion(JniObjectReference array, int start, int length, bool* buffer)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_set_boolean_array_region(EnvironmentPointer, out var thrown, array.Handle, start, length, buffer);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}

			public unsafe static void SetByteArrayRegion(JniObjectReference array, int start, int length, sbyte* buffer)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_set_byte_array_region(EnvironmentPointer, out var thrown, array.Handle, start, length, buffer);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}

			public unsafe static void SetCharArrayRegion(JniObjectReference array, int start, int length, char* buffer)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_set_char_array_region(EnvironmentPointer, out var thrown, array.Handle, start, length, buffer);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}

			public unsafe static void SetShortArrayRegion(JniObjectReference array, int start, int length, short* buffer)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_set_short_array_region(EnvironmentPointer, out var thrown, array.Handle, start, length, buffer);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}

			public unsafe static void SetIntArrayRegion(JniObjectReference array, int start, int length, int* buffer)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_set_int_array_region(EnvironmentPointer, out var thrown, array.Handle, start, length, buffer);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}

			public unsafe static void SetLongArrayRegion(JniObjectReference array, int start, int length, long* buffer)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_set_long_array_region(EnvironmentPointer, out var thrown, array.Handle, start, length, buffer);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}

			public unsafe static void SetFloatArrayRegion(JniObjectReference array, int start, int length, float* buffer)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_set_float_array_region(EnvironmentPointer, out var thrown, array.Handle, start, length, buffer);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}

			public unsafe static void SetDoubleArrayRegion(JniObjectReference array, int start, int length, double* buffer)
			{
				if (!array.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "array");
				}
				NativeMethods.java_interop_jnienv_set_double_array_region(EnvironmentPointer, out var thrown, array.Handle, start, length, buffer);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}
		}

		public static class References
		{
			internal static int GetJavaVM(IntPtr jnienv, out IntPtr vm)
			{
				return NativeMethods.java_interop_jnienv_get_java_vm(jnienv, out vm);
			}

			internal static void RawDeleteLocalRef(IntPtr env, IntPtr localRef)
			{
				NativeMethods.java_interop_jnienv_delete_local_ref(env, localRef);
			}

			public static void EnsureLocalCapacity(int capacity)
			{
				int num = _EnsureLocalCapacity(capacity);
				if (num == 0)
				{
					return;
				}
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable();
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				throw new InvalidOperationException($"Could not ensure capacity; JNIEnv::EnsureLocalCapacity() returned {num}.");
			}

			public static void PushLocalFrame(int capacity)
			{
				int num = _PushLocalFrame(capacity);
				if (num == 0)
				{
					return;
				}
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable();
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				throw new InvalidOperationException($"Could not push a frame; JNIEnv::PushLocalFrame() returned {num}.");
			}

			internal static int _PushLocalFrame(int capacity)
			{
				return NativeMethods.java_interop_jnienv_push_local_frame(EnvironmentPointer, capacity);
			}

			public static JniObjectReference PopLocalFrame(JniObjectReference result)
			{
				IntPtr intPtr = NativeMethods.java_interop_jnienv_pop_local_frame(EnvironmentPointer, result.Handle);
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			internal static JniObjectReference NewGlobalRef(JniObjectReference instance)
			{
				return new JniObjectReference(NativeMethods.java_interop_jnienv_new_global_ref(EnvironmentPointer, instance.Handle), JniObjectReferenceType.Global);
			}

			internal static void DeleteGlobalRef(IntPtr instance)
			{
				NativeMethods.java_interop_jnienv_delete_global_ref(EnvironmentPointer, instance);
			}

			internal static void DeleteLocalRef(IntPtr instance)
			{
				NativeMethods.java_interop_jnienv_delete_local_ref(EnvironmentPointer, instance);
			}

			internal static JniObjectReference NewLocalRef(JniObjectReference instance)
			{
				return new JniObjectReference(NativeMethods.java_interop_jnienv_new_local_ref(EnvironmentPointer, instance.Handle), JniObjectReferenceType.Local);
			}

			internal static int _EnsureLocalCapacity(int capacity)
			{
				return NativeMethods.java_interop_jnienv_ensure_local_capacity(EnvironmentPointer, capacity);
			}

			internal static void DeleteWeakGlobalRef(IntPtr instance)
			{
				NativeMethods.java_interop_jnienv_delete_weak_global_ref(EnvironmentPointer, instance);
			}
		}

		public static class Exceptions
		{
			public static void Throw(JniObjectReference toThrow)
			{
				if (!toThrow.IsValid)
				{
					throw new ArgumentException("toThrow");
				}
				int num = _Throw(toThrow);
				if (num != 0)
				{
					throw new InvalidOperationException($"Could not raise an exception; JNIEnv::Throw() returned {num}.");
				}
			}

			public static void ThrowNew(JniObjectReference klass, string message)
			{
				if (!klass.IsValid)
				{
					throw new ArgumentException("klass");
				}
				if (message == null)
				{
					throw new ArgumentNullException("message");
				}
				int num = _ThrowNew(klass, message);
				if (num != 0)
				{
					throw new InvalidOperationException($"Could not raise an exception; JNIEnv::ThrowNew() returned {num}.");
				}
			}

			public static void Throw(Exception e)
			{
				if (e == null)
				{
					throw new ArgumentNullException("e");
				}
				JavaException ex = e as JavaException;
				if (ex == null)
				{
					ex = new JavaProxyThrowable(e);
				}
				Throw(ex.PeerReference);
			}

			internal static int _Throw(JniObjectReference toThrow)
			{
				if (!toThrow.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "toThrow");
				}
				return NativeMethods.java_interop_jnienv_throw(EnvironmentPointer, toThrow.Handle);
			}

			internal static int _ThrowNew(JniObjectReference type, string message)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (message == null)
				{
					throw new ArgumentNullException("message");
				}
				return NativeMethods.java_interop_jnienv_throw_new(EnvironmentPointer, type.Handle, message);
			}

			public static JniObjectReference ExceptionOccurred()
			{
				return new JniObjectReference(NativeMethods.java_interop_jnienv_exception_occurred(EnvironmentPointer), JniObjectReferenceType.Local);
			}

			public static void ExceptionDescribe()
			{
				NativeMethods.java_interop_jnienv_exception_describe(EnvironmentPointer);
			}

			public static void ExceptionClear()
			{
				NativeMethods.java_interop_jnienv_exception_clear(EnvironmentPointer);
			}
		}

		public static class Object
		{
			private static JniMethodInfo Object_toString;

			static Object()
			{
				using JniType jniType = new JniType("java/lang/Object");
				Object_toString = jniType.GetInstanceMethod("toString", "()Ljava/lang/String;");
			}

			public static JniObjectReference NewObject(JniObjectReference type, JniMethodInfo method)
			{
				WithinNewObjectScope = true;
				try
				{
					return _NewObject(type, method);
				}
				finally
				{
					WithinNewObjectScope = false;
				}
			}

			public unsafe static JniObjectReference NewObject(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
			{
				WithinNewObjectScope = true;
				try
				{
					return _NewObject(type, method, args);
				}
				finally
				{
					WithinNewObjectScope = false;
				}
			}

			public static JniObjectReference ToString(JniObjectReference value)
			{
				return InstanceMethods.CallObjectMethod(value, Object_toString);
			}

			public static JniObjectReference AllocObject(JniObjectReference type)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				IntPtr thrown;
				IntPtr intPtr = NativeMethods.java_interop_jnienv_alloc_object(EnvironmentPointer, out thrown, type.Handle);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			internal static JniObjectReference _NewObject(JniObjectReference type, JniMethodInfo method)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				IntPtr intPtr = NativeMethods.java_interop_jnienv_new_object(EnvironmentPointer, out thrown, type.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			internal unsafe static JniObjectReference _NewObject(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				IntPtr intPtr = NativeMethods.java_interop_jnienv_new_object_a(EnvironmentPointer, out thrown, type.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}
		}

		public static class Strings
		{
			public unsafe static JniObjectReference NewString(string value)
			{
				if (value == null)
				{
					return default(JniObjectReference);
				}
				fixed (char* unicodeChars = value)
				{
					return NewString(unicodeChars, value.Length);
				}
			}

			public static string ToString(IntPtr reference)
			{
				return ToString(new JniObjectReference(reference));
			}

			internal static string ToString(ref JniObjectReference reference, JniObjectReferenceOptions transfer, Type targetType)
			{
				return ToString(ref reference, transfer);
			}

			public static string ToString(JniObjectReference value)
			{
				return ToString(ref value, JniObjectReferenceOptions.Copy);
			}

			public unsafe static string ToString(ref JniObjectReference value, JniObjectReferenceOptions transfer)
			{
				if (!value.IsValid)
				{
					return null;
				}
				int stringLength = GetStringLength(value);
				char* stringChars = GetStringChars(value, null);
				try
				{
					return new string(stringChars, 0, stringLength);
				}
				finally
				{
					ReleaseStringChars(value, stringChars);
					JniObjectReference.Dispose(ref value, transfer);
				}
			}

			public unsafe static JniObjectReference NewString(char* unicodeChars, int length)
			{
				IntPtr thrown;
				IntPtr intPtr = NativeMethods.java_interop_jnienv_new_string(EnvironmentPointer, out thrown, unicodeChars, length);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			public static int GetStringLength(JniObjectReference stringInstance)
			{
				if (!stringInstance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "stringInstance");
				}
				return NativeMethods.java_interop_jnienv_get_string_length(EnvironmentPointer, stringInstance.Handle);
			}

			public unsafe static char* GetStringChars(JniObjectReference stringInstance, bool* isCopy)
			{
				if (!stringInstance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "stringInstance");
				}
				return NativeMethods.java_interop_jnienv_get_string_chars(EnvironmentPointer, stringInstance.Handle, isCopy);
			}

			public unsafe static void ReleaseStringChars(JniObjectReference stringInstance, char* chars)
			{
				if (!stringInstance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "stringInstance");
				}
				NativeMethods.java_interop_jnienv_release_string_chars(EnvironmentPointer, stringInstance.Handle, chars);
			}
		}

		public static class Types
		{
			private static readonly KeyValuePair<string, string>[] BuiltinMappings;

			private static readonly JniMethodInfo Class_getName;

			static Types()
			{
				BuiltinMappings = new KeyValuePair<string, string>[9]
				{
					new KeyValuePair<string, string>("byte", "B"),
					new KeyValuePair<string, string>("boolean", "Z"),
					new KeyValuePair<string, string>("char", "C"),
					new KeyValuePair<string, string>("double", "D"),
					new KeyValuePair<string, string>("float", "F"),
					new KeyValuePair<string, string>("int", "I"),
					new KeyValuePair<string, string>("long", "J"),
					new KeyValuePair<string, string>("short", "S"),
					new KeyValuePair<string, string>("void", "V")
				};
				using JniType jniType = new JniType("java/lang/Class");
				Class_getName = jniType.GetInstanceMethod("getName", "()Ljava/lang/String;");
			}

			public static JniObjectReference FindClass(string classname)
			{
				return TryFindClass(classname, throwOnError: true);
			}

			private unsafe static JniObjectReference TryFindClass(string classname, bool throwOnError)
			{
				if (classname == null)
				{
					throw new ArgumentNullException("classname");
				}
				if (classname.Length == 0)
				{
					throw new ArgumentException("'classname' cannot be a zero-length string.", "classname");
				}
				JniEnvironmentInfo currentInfo = CurrentInfo;
				if (TryRawFindClass(currentInfo.EnvironmentPointer, classname, out var klass, out var thrown))
				{
					JniObjectReference jniObjectReference = new JniObjectReference(klass, JniObjectReferenceType.Local);
					LogCreateLocalRef(jniObjectReference);
					return jniObjectReference;
				}
				RawExceptionClear(currentInfo.EnvironmentPointer);
				JniObjectReference reference = new JniObjectReference(thrown, JniObjectReferenceType.Local);
				LogCreateLocalRef(reference);
				Exception exceptionForThrowable = currentInfo.Runtime.GetExceptionForThrowable(ref reference, JniObjectReferenceOptions.CopyAndDispose);
				if (currentInfo.Runtime.ClassLoader_LoadClass != null)
				{
					JniObjectReference reference2 = currentInfo.ToJavaName(classname);
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(reference2);
					klass = RawCallObjectMethodA(currentInfo.EnvironmentPointer, out thrown, currentInfo.Runtime.ClassLoader.Handle, currentInfo.Runtime.ClassLoader_LoadClass.ID, (IntPtr)ptr);
					JniObjectReference.Dispose(ref reference2);
					if (thrown == IntPtr.Zero)
					{
						(exceptionForThrowable as IJavaPeerable)?.Dispose();
						JniObjectReference jniObjectReference2 = new JniObjectReference(klass, JniObjectReferenceType.Local);
						LogCreateLocalRef(jniObjectReference2);
						return jniObjectReference2;
					}
					RawExceptionClear(currentInfo.EnvironmentPointer);
					if (exceptionForThrowable != null)
					{
						References.RawDeleteLocalRef(currentInfo.EnvironmentPointer, thrown);
					}
					else
					{
						JniObjectReference reference3 = new JniObjectReference(thrown, JniObjectReferenceType.Local);
						LogCreateLocalRef(reference3);
						exceptionForThrowable = currentInfo.Runtime.GetExceptionForThrowable(ref reference3, JniObjectReferenceOptions.CopyAndDispose);
					}
				}
				if (!throwOnError)
				{
					(exceptionForThrowable as IJavaPeerable)?.Dispose();
					return default(JniObjectReference);
				}
				throw exceptionForThrowable;
			}

			private static bool TryRawFindClass(IntPtr env, string classname, out IntPtr klass, out IntPtr thrown)
			{
				klass = NativeMethods.java_interop_jnienv_find_class(env, out thrown, classname);
				if (thrown == IntPtr.Zero)
				{
					return true;
				}
				return false;
			}

			private static void RawExceptionClear(IntPtr env)
			{
				NativeMethods.java_interop_jnienv_exception_clear(env);
			}

			private static IntPtr RawCallObjectMethodA(IntPtr env, out IntPtr thrown, IntPtr instance, IntPtr jmethodID, IntPtr args)
			{
				return NativeMethods.java_interop_jnienv_call_object_method_a(env, out thrown, instance, jmethodID, args);
			}

			public static string GetJniTypeNameFromInstance(JniObjectReference instance)
			{
				if (!instance.IsValid)
				{
					return null;
				}
				JniObjectReference reference = GetObjectClass(instance);
				try
				{
					return GetJniTypeNameFromClass(reference);
				}
				finally
				{
					JniObjectReference.Dispose(ref reference, JniObjectReferenceOptions.CopyAndDispose);
				}
			}

			public static string GetJniTypeNameFromClass(JniObjectReference type)
			{
				if (!type.IsValid)
				{
					return null;
				}
				JniObjectReference value = InstanceMethods.CallObjectMethod(type, Class_getName);
				return JavaClassToJniType(Strings.ToString(ref value, JniObjectReferenceOptions.CopyAndDispose));
			}

			private static string JavaClassToJniType(string value)
			{
				for (int i = 0; i < BuiltinMappings.Length; i++)
				{
					if (value == BuiltinMappings[i].Key)
					{
						return BuiltinMappings[i].Value;
					}
				}
				return value.Replace('.', '/');
			}

			public static void RegisterNatives(JniObjectReference type, JniNativeMethodRegistration[] methods, int numMethods)
			{
				if (numMethods < 0 || numMethods > ((methods != null) ? methods.Length : 0))
				{
					throw new ArgumentOutOfRangeException("numMethods", numMethods, $"`numMethods` must be between 0 and `methods.Length` ({((methods != null) ? methods.Length : 0)})!");
				}
				int num = _RegisterNatives(type, methods, numMethods);
				if (num != 0)
				{
					throw new InvalidOperationException($"Could not register native methods for class '{GetJniTypeNameFromClass(type)}'; JNIEnv::RegisterNatives() returned {num}.");
				}
			}

			public static void UnregisterNatives(JniObjectReference type)
			{
				int num = _UnregisterNatives(type);
				if (num != 0)
				{
					throw new InvalidOperationException($"Could not unregister native methods for class '{GetJniTypeNameFromClass(type)}'; JNIEnv::UnregisterNatives() returned {num}.");
				}
			}

			public static JniObjectReference GetSuperclass(JniObjectReference type)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				IntPtr intPtr = NativeMethods.java_interop_jnienv_get_superclass(EnvironmentPointer, type.Handle);
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			public static bool IsAssignableFrom(JniObjectReference class1, JniObjectReference class2)
			{
				if (!class1.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "class1");
				}
				if (!class2.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "class2");
				}
				if (NativeMethods.java_interop_jnienv_is_assignable_from(EnvironmentPointer, class1.Handle, class2.Handle) == 0)
				{
					return false;
				}
				return true;
			}

			public static bool IsSameObject(JniObjectReference object1, JniObjectReference object2)
			{
				if (NativeMethods.java_interop_jnienv_is_same_object(EnvironmentPointer, object1.Handle, object2.Handle) == 0)
				{
					return false;
				}
				return true;
			}

			public static JniObjectReference GetObjectClass(JniObjectReference instance)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				IntPtr intPtr = NativeMethods.java_interop_jnienv_get_object_class(EnvironmentPointer, instance.Handle);
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			public static bool IsInstanceOf(JniObjectReference instance, JniObjectReference type)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (NativeMethods.java_interop_jnienv_is_instance_of(EnvironmentPointer, instance.Handle, type.Handle) == 0)
				{
					return false;
				}
				return true;
			}

			internal static int _RegisterNatives(JniObjectReference type, JniNativeMethodRegistration[] methods, int numMethods)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				IntPtr thrown;
				int result = NativeMethods.java_interop_jnienv_register_natives(EnvironmentPointer, out thrown, type.Handle, methods, numMethods);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			internal static int _UnregisterNatives(JniObjectReference type)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				return NativeMethods.java_interop_jnienv_unregister_natives(EnvironmentPointer, type.Handle);
			}
		}

		public static class InstanceFields
		{
			public static JniFieldInfo GetFieldID(JniObjectReference type, string name, string signature)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (name == null)
				{
					throw new ArgumentNullException("name");
				}
				if (signature == null)
				{
					throw new ArgumentNullException("signature");
				}
				IntPtr thrown;
				IntPtr intPtr = NativeMethods.java_interop_jnienv_get_field_id(EnvironmentPointer, out thrown, type.Handle, name, signature);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new JniFieldInfo(name, signature, intPtr, isStatic: false);
			}

			public static JniObjectReference GetObjectField(JniObjectReference instance, JniFieldInfo field)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				IntPtr intPtr = NativeMethods.java_interop_jnienv_get_object_field(EnvironmentPointer, instance.Handle, field.ID);
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			public static bool GetBooleanField(JniObjectReference instance, JniFieldInfo field)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				if (NativeMethods.java_interop_jnienv_get_boolean_field(EnvironmentPointer, instance.Handle, field.ID) == 0)
				{
					return false;
				}
				return true;
			}

			public static sbyte GetByteField(JniObjectReference instance, JniFieldInfo field)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				return NativeMethods.java_interop_jnienv_get_byte_field(EnvironmentPointer, instance.Handle, field.ID);
			}

			public static char GetCharField(JniObjectReference instance, JniFieldInfo field)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				return NativeMethods.java_interop_jnienv_get_char_field(EnvironmentPointer, instance.Handle, field.ID);
			}

			public static short GetShortField(JniObjectReference instance, JniFieldInfo field)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				return NativeMethods.java_interop_jnienv_get_short_field(EnvironmentPointer, instance.Handle, field.ID);
			}

			public static int GetIntField(JniObjectReference instance, JniFieldInfo field)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				return NativeMethods.java_interop_jnienv_get_int_field(EnvironmentPointer, instance.Handle, field.ID);
			}

			public static long GetLongField(JniObjectReference instance, JniFieldInfo field)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				return NativeMethods.java_interop_jnienv_get_long_field(EnvironmentPointer, instance.Handle, field.ID);
			}

			public static float GetFloatField(JniObjectReference instance, JniFieldInfo field)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				return NativeMethods.java_interop_jnienv_get_float_field(EnvironmentPointer, instance.Handle, field.ID);
			}

			public static double GetDoubleField(JniObjectReference instance, JniFieldInfo field)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				return NativeMethods.java_interop_jnienv_get_double_field(EnvironmentPointer, instance.Handle, field.ID);
			}

			public static void SetObjectField(JniObjectReference instance, JniFieldInfo field, JniObjectReference value)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				NativeMethods.java_interop_jnienv_set_object_field(EnvironmentPointer, instance.Handle, field.ID, value.Handle);
			}

			public static void SetBooleanField(JniObjectReference instance, JniFieldInfo field, bool value)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				NativeMethods.java_interop_jnienv_set_boolean_field(EnvironmentPointer, instance.Handle, field.ID, (byte)(value ? 1 : 0));
			}

			public static void SetByteField(JniObjectReference instance, JniFieldInfo field, sbyte value)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				NativeMethods.java_interop_jnienv_set_byte_field(EnvironmentPointer, instance.Handle, field.ID, value);
			}

			public static void SetCharField(JniObjectReference instance, JniFieldInfo field, char value)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				NativeMethods.java_interop_jnienv_set_char_field(EnvironmentPointer, instance.Handle, field.ID, value);
			}

			public static void SetShortField(JniObjectReference instance, JniFieldInfo field, short value)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				NativeMethods.java_interop_jnienv_set_short_field(EnvironmentPointer, instance.Handle, field.ID, value);
			}

			public static void SetIntField(JniObjectReference instance, JniFieldInfo field, int value)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				NativeMethods.java_interop_jnienv_set_int_field(EnvironmentPointer, instance.Handle, field.ID, value);
			}

			public static void SetLongField(JniObjectReference instance, JniFieldInfo field, long value)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				NativeMethods.java_interop_jnienv_set_long_field(EnvironmentPointer, instance.Handle, field.ID, value);
			}

			public static void SetFloatField(JniObjectReference instance, JniFieldInfo field, float value)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				NativeMethods.java_interop_jnienv_set_float_field(EnvironmentPointer, instance.Handle, field.ID, value);
			}

			public static void SetDoubleField(JniObjectReference instance, JniFieldInfo field, double value)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				NativeMethods.java_interop_jnienv_set_double_field(EnvironmentPointer, instance.Handle, field.ID, value);
			}
		}

		public static class InstanceMethods
		{
			public static JniMethodInfo GetMethodID(JniObjectReference type, string name, string signature)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (name == null)
				{
					throw new ArgumentNullException("name");
				}
				if (signature == null)
				{
					throw new ArgumentNullException("signature");
				}
				IntPtr thrown;
				IntPtr intPtr = NativeMethods.java_interop_jnienv_get_method_id(EnvironmentPointer, out thrown, type.Handle, name, signature);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new JniMethodInfo(name, signature, intPtr, isStatic: false);
			}

			public static JniObjectReference CallObjectMethod(JniObjectReference instance, JniMethodInfo method)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				IntPtr intPtr = NativeMethods.java_interop_jnienv_call_object_method(EnvironmentPointer, out thrown, instance.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			public unsafe static JniObjectReference CallObjectMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				IntPtr intPtr = NativeMethods.java_interop_jnienv_call_object_method_a(EnvironmentPointer, out thrown, instance.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			public static bool CallBooleanMethod(JniObjectReference instance, JniMethodInfo method)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				byte num = NativeMethods.java_interop_jnienv_call_boolean_method(EnvironmentPointer, out thrown, instance.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				if (num == 0)
				{
					return false;
				}
				return true;
			}

			public unsafe static bool CallBooleanMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				byte num = NativeMethods.java_interop_jnienv_call_boolean_method_a(EnvironmentPointer, out thrown, instance.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				if (num == 0)
				{
					return false;
				}
				return true;
			}

			public static sbyte CallByteMethod(JniObjectReference instance, JniMethodInfo method)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				sbyte result = NativeMethods.java_interop_jnienv_call_byte_method(EnvironmentPointer, out thrown, instance.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public unsafe static sbyte CallByteMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				sbyte result = NativeMethods.java_interop_jnienv_call_byte_method_a(EnvironmentPointer, out thrown, instance.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public static char CallCharMethod(JniObjectReference instance, JniMethodInfo method)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				char result = NativeMethods.java_interop_jnienv_call_char_method(EnvironmentPointer, out thrown, instance.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public unsafe static char CallCharMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				char result = NativeMethods.java_interop_jnienv_call_char_method_a(EnvironmentPointer, out thrown, instance.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public static short CallShortMethod(JniObjectReference instance, JniMethodInfo method)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				short result = NativeMethods.java_interop_jnienv_call_short_method(EnvironmentPointer, out thrown, instance.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public unsafe static short CallShortMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				short result = NativeMethods.java_interop_jnienv_call_short_method_a(EnvironmentPointer, out thrown, instance.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public static int CallIntMethod(JniObjectReference instance, JniMethodInfo method)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				int result = NativeMethods.java_interop_jnienv_call_int_method(EnvironmentPointer, out thrown, instance.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public unsafe static int CallIntMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				int result = NativeMethods.java_interop_jnienv_call_int_method_a(EnvironmentPointer, out thrown, instance.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public static long CallLongMethod(JniObjectReference instance, JniMethodInfo method)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				long result = NativeMethods.java_interop_jnienv_call_long_method(EnvironmentPointer, out thrown, instance.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public unsafe static long CallLongMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				long result = NativeMethods.java_interop_jnienv_call_long_method_a(EnvironmentPointer, out thrown, instance.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public static float CallFloatMethod(JniObjectReference instance, JniMethodInfo method)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				float result = NativeMethods.java_interop_jnienv_call_float_method(EnvironmentPointer, out thrown, instance.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public unsafe static float CallFloatMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				float result = NativeMethods.java_interop_jnienv_call_float_method_a(EnvironmentPointer, out thrown, instance.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public static double CallDoubleMethod(JniObjectReference instance, JniMethodInfo method)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				double result = NativeMethods.java_interop_jnienv_call_double_method(EnvironmentPointer, out thrown, instance.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public unsafe static double CallDoubleMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				double result = NativeMethods.java_interop_jnienv_call_double_method_a(EnvironmentPointer, out thrown, instance.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public static void CallVoidMethod(JniObjectReference instance, JniMethodInfo method)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				NativeMethods.java_interop_jnienv_call_void_method(EnvironmentPointer, out var thrown, instance.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}

			public unsafe static void CallVoidMethod(JniObjectReference instance, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				NativeMethods.java_interop_jnienv_call_void_method_a(EnvironmentPointer, out var thrown, instance.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}

			public static JniObjectReference CallNonvirtualObjectMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				IntPtr intPtr = NativeMethods.java_interop_jnienv_call_nonvirtual_object_method(EnvironmentPointer, out thrown, instance.Handle, type.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			public unsafe static JniObjectReference CallNonvirtualObjectMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				IntPtr intPtr = NativeMethods.java_interop_jnienv_call_nonvirtual_object_method_a(EnvironmentPointer, out thrown, instance.Handle, type.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			public static bool CallNonvirtualBooleanMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				byte num = NativeMethods.java_interop_jnienv_call_nonvirtual_boolean_method(EnvironmentPointer, out thrown, instance.Handle, type.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				if (num == 0)
				{
					return false;
				}
				return true;
			}

			public unsafe static bool CallNonvirtualBooleanMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				byte num = NativeMethods.java_interop_jnienv_call_nonvirtual_boolean_method_a(EnvironmentPointer, out thrown, instance.Handle, type.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				if (num == 0)
				{
					return false;
				}
				return true;
			}

			public static sbyte CallNonvirtualByteMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				sbyte result = NativeMethods.java_interop_jnienv_call_nonvirtual_byte_method(EnvironmentPointer, out thrown, instance.Handle, type.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public unsafe static sbyte CallNonvirtualByteMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				sbyte result = NativeMethods.java_interop_jnienv_call_nonvirtual_byte_method_a(EnvironmentPointer, out thrown, instance.Handle, type.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public static char CallNonvirtualCharMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				char result = NativeMethods.java_interop_jnienv_call_nonvirtual_char_method(EnvironmentPointer, out thrown, instance.Handle, type.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public unsafe static char CallNonvirtualCharMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				char result = NativeMethods.java_interop_jnienv_call_nonvirtual_char_method_a(EnvironmentPointer, out thrown, instance.Handle, type.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public static short CallNonvirtualShortMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				short result = NativeMethods.java_interop_jnienv_call_nonvirtual_short_method(EnvironmentPointer, out thrown, instance.Handle, type.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public unsafe static short CallNonvirtualShortMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				short result = NativeMethods.java_interop_jnienv_call_nonvirtual_short_method_a(EnvironmentPointer, out thrown, instance.Handle, type.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public static int CallNonvirtualIntMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				int result = NativeMethods.java_interop_jnienv_call_nonvirtual_int_method(EnvironmentPointer, out thrown, instance.Handle, type.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public unsafe static int CallNonvirtualIntMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				int result = NativeMethods.java_interop_jnienv_call_nonvirtual_int_method_a(EnvironmentPointer, out thrown, instance.Handle, type.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public static long CallNonvirtualLongMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				long result = NativeMethods.java_interop_jnienv_call_nonvirtual_long_method(EnvironmentPointer, out thrown, instance.Handle, type.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public unsafe static long CallNonvirtualLongMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				long result = NativeMethods.java_interop_jnienv_call_nonvirtual_long_method_a(EnvironmentPointer, out thrown, instance.Handle, type.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public static float CallNonvirtualFloatMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				float result = NativeMethods.java_interop_jnienv_call_nonvirtual_float_method(EnvironmentPointer, out thrown, instance.Handle, type.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public unsafe static float CallNonvirtualFloatMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				float result = NativeMethods.java_interop_jnienv_call_nonvirtual_float_method_a(EnvironmentPointer, out thrown, instance.Handle, type.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public static double CallNonvirtualDoubleMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				double result = NativeMethods.java_interop_jnienv_call_nonvirtual_double_method(EnvironmentPointer, out thrown, instance.Handle, type.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public unsafe static double CallNonvirtualDoubleMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				double result = NativeMethods.java_interop_jnienv_call_nonvirtual_double_method_a(EnvironmentPointer, out thrown, instance.Handle, type.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public static void CallNonvirtualVoidMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				NativeMethods.java_interop_jnienv_call_nonvirtual_void_method(EnvironmentPointer, out var thrown, instance.Handle, type.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}

			public unsafe static void CallNonvirtualVoidMethod(JniObjectReference instance, JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!instance.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "instance");
				}
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				NativeMethods.java_interop_jnienv_call_nonvirtual_void_method_a(EnvironmentPointer, out var thrown, instance.Handle, type.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}
		}

		public static class IO
		{
			public static JniObjectReference NewDirectByteBuffer(IntPtr address, long capacity)
			{
				if (address == IntPtr.Zero)
				{
					throw new ArgumentException("'address' must not be IntPtr.Zero.", "address");
				}
				IntPtr thrown;
				IntPtr intPtr = NativeMethods.java_interop_jnienv_new_direct_byte_buffer(EnvironmentPointer, out thrown, address, capacity);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			public static IntPtr GetDirectBufferAddress(JniObjectReference buffer)
			{
				if (!buffer.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "buffer");
				}
				return NativeMethods.java_interop_jnienv_get_direct_buffer_address(EnvironmentPointer, buffer.Handle);
			}

			public static long GetDirectBufferCapacity(JniObjectReference buffer)
			{
				if (!buffer.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "buffer");
				}
				return NativeMethods.java_interop_jnienv_get_direct_buffer_capacity(EnvironmentPointer, buffer.Handle);
			}
		}

		public static class StaticFields
		{
			public static JniFieldInfo GetStaticFieldID(JniObjectReference type, string name, string signature)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (name == null)
				{
					throw new ArgumentNullException("name");
				}
				if (signature == null)
				{
					throw new ArgumentNullException("signature");
				}
				IntPtr thrown;
				IntPtr intPtr = NativeMethods.java_interop_jnienv_get_static_field_id(EnvironmentPointer, out thrown, type.Handle, name, signature);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new JniFieldInfo(name, signature, intPtr, isStatic: true);
			}

			public static JniObjectReference GetStaticObjectField(JniObjectReference type, JniFieldInfo field)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				IntPtr intPtr = NativeMethods.java_interop_jnienv_get_static_object_field(EnvironmentPointer, type.Handle, field.ID);
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			public static bool GetStaticBooleanField(JniObjectReference type, JniFieldInfo field)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				if (NativeMethods.java_interop_jnienv_get_static_boolean_field(EnvironmentPointer, type.Handle, field.ID) == 0)
				{
					return false;
				}
				return true;
			}

			public static sbyte GetStaticByteField(JniObjectReference type, JniFieldInfo field)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				return NativeMethods.java_interop_jnienv_get_static_byte_field(EnvironmentPointer, type.Handle, field.ID);
			}

			public static char GetStaticCharField(JniObjectReference type, JniFieldInfo field)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				return NativeMethods.java_interop_jnienv_get_static_char_field(EnvironmentPointer, type.Handle, field.ID);
			}

			public static short GetStaticShortField(JniObjectReference type, JniFieldInfo field)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				return NativeMethods.java_interop_jnienv_get_static_short_field(EnvironmentPointer, type.Handle, field.ID);
			}

			public static int GetStaticIntField(JniObjectReference type, JniFieldInfo field)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				return NativeMethods.java_interop_jnienv_get_static_int_field(EnvironmentPointer, type.Handle, field.ID);
			}

			public static long GetStaticLongField(JniObjectReference type, JniFieldInfo field)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				return NativeMethods.java_interop_jnienv_get_static_long_field(EnvironmentPointer, type.Handle, field.ID);
			}

			public static float GetStaticFloatField(JniObjectReference type, JniFieldInfo field)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				return NativeMethods.java_interop_jnienv_get_static_float_field(EnvironmentPointer, type.Handle, field.ID);
			}

			public static double GetStaticDoubleField(JniObjectReference type, JniFieldInfo field)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				return NativeMethods.java_interop_jnienv_get_static_double_field(EnvironmentPointer, type.Handle, field.ID);
			}

			public static void SetStaticObjectField(JniObjectReference type, JniFieldInfo field, JniObjectReference value)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				NativeMethods.java_interop_jnienv_set_static_object_field(EnvironmentPointer, type.Handle, field.ID, value.Handle);
			}

			public static void SetStaticBooleanField(JniObjectReference type, JniFieldInfo field, bool value)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				NativeMethods.java_interop_jnienv_set_static_boolean_field(EnvironmentPointer, type.Handle, field.ID, (byte)(value ? 1 : 0));
			}

			public static void SetStaticByteField(JniObjectReference type, JniFieldInfo field, sbyte value)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				NativeMethods.java_interop_jnienv_set_static_byte_field(EnvironmentPointer, type.Handle, field.ID, value);
			}

			public static void SetStaticCharField(JniObjectReference type, JniFieldInfo field, char value)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				NativeMethods.java_interop_jnienv_set_static_char_field(EnvironmentPointer, type.Handle, field.ID, value);
			}

			public static void SetStaticShortField(JniObjectReference type, JniFieldInfo field, short value)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				NativeMethods.java_interop_jnienv_set_static_short_field(EnvironmentPointer, type.Handle, field.ID, value);
			}

			public static void SetStaticIntField(JniObjectReference type, JniFieldInfo field, int value)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				NativeMethods.java_interop_jnienv_set_static_int_field(EnvironmentPointer, type.Handle, field.ID, value);
			}

			public static void SetStaticLongField(JniObjectReference type, JniFieldInfo field, long value)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				NativeMethods.java_interop_jnienv_set_static_long_field(EnvironmentPointer, type.Handle, field.ID, value);
			}

			public static void SetStaticFloatField(JniObjectReference type, JniFieldInfo field, float value)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				NativeMethods.java_interop_jnienv_set_static_float_field(EnvironmentPointer, type.Handle, field.ID, value);
			}

			public static void SetStaticDoubleField(JniObjectReference type, JniFieldInfo field, double value)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (field == null)
				{
					throw new ArgumentNullException("field");
				}
				if (!field.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "field");
				}
				NativeMethods.java_interop_jnienv_set_static_double_field(EnvironmentPointer, type.Handle, field.ID, value);
			}
		}

		public static class StaticMethods
		{
			public static JniMethodInfo GetStaticMethodID(JniObjectReference type, string name, string signature)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (name == null)
				{
					throw new ArgumentNullException("name");
				}
				if (signature == null)
				{
					throw new ArgumentNullException("signature");
				}
				IntPtr thrown;
				IntPtr intPtr = NativeMethods.java_interop_jnienv_get_static_method_id(EnvironmentPointer, out thrown, type.Handle, name, signature);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				if (intPtr == IntPtr.Zero)
				{
					return null;
				}
				return new JniMethodInfo(name, signature, intPtr, isStatic: true);
			}

			public static JniObjectReference CallStaticObjectMethod(JniObjectReference type, JniMethodInfo method)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				IntPtr intPtr = NativeMethods.java_interop_jnienv_call_static_object_method(EnvironmentPointer, out thrown, type.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			public unsafe static JniObjectReference CallStaticObjectMethod(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				IntPtr intPtr = NativeMethods.java_interop_jnienv_call_static_object_method_a(EnvironmentPointer, out thrown, type.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				LogCreateLocalRef(intPtr);
				return new JniObjectReference(intPtr, JniObjectReferenceType.Local);
			}

			public static bool CallStaticBooleanMethod(JniObjectReference type, JniMethodInfo method)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				byte num = NativeMethods.java_interop_jnienv_call_static_boolean_method(EnvironmentPointer, out thrown, type.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				if (num == 0)
				{
					return false;
				}
				return true;
			}

			public unsafe static bool CallStaticBooleanMethod(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				byte num = NativeMethods.java_interop_jnienv_call_static_boolean_method_a(EnvironmentPointer, out thrown, type.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				if (num == 0)
				{
					return false;
				}
				return true;
			}

			public static sbyte CallStaticByteMethod(JniObjectReference type, JniMethodInfo method)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				sbyte result = NativeMethods.java_interop_jnienv_call_static_byte_method(EnvironmentPointer, out thrown, type.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public unsafe static sbyte CallStaticByteMethod(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				sbyte result = NativeMethods.java_interop_jnienv_call_static_byte_method_a(EnvironmentPointer, out thrown, type.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public static char CallStaticCharMethod(JniObjectReference type, JniMethodInfo method)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				char result = NativeMethods.java_interop_jnienv_call_static_char_method(EnvironmentPointer, out thrown, type.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public unsafe static char CallStaticCharMethod(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				char result = NativeMethods.java_interop_jnienv_call_static_char_method_a(EnvironmentPointer, out thrown, type.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public static short CallStaticShortMethod(JniObjectReference type, JniMethodInfo method)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				short result = NativeMethods.java_interop_jnienv_call_static_short_method(EnvironmentPointer, out thrown, type.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public unsafe static short CallStaticShortMethod(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				short result = NativeMethods.java_interop_jnienv_call_static_short_method_a(EnvironmentPointer, out thrown, type.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public static int CallStaticIntMethod(JniObjectReference type, JniMethodInfo method)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				int result = NativeMethods.java_interop_jnienv_call_static_int_method(EnvironmentPointer, out thrown, type.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public unsafe static int CallStaticIntMethod(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				int result = NativeMethods.java_interop_jnienv_call_static_int_method_a(EnvironmentPointer, out thrown, type.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public static long CallStaticLongMethod(JniObjectReference type, JniMethodInfo method)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				long result = NativeMethods.java_interop_jnienv_call_static_long_method(EnvironmentPointer, out thrown, type.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public unsafe static long CallStaticLongMethod(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				long result = NativeMethods.java_interop_jnienv_call_static_long_method_a(EnvironmentPointer, out thrown, type.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public static float CallStaticFloatMethod(JniObjectReference type, JniMethodInfo method)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				float result = NativeMethods.java_interop_jnienv_call_static_float_method(EnvironmentPointer, out thrown, type.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public unsafe static float CallStaticFloatMethod(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				float result = NativeMethods.java_interop_jnienv_call_static_float_method_a(EnvironmentPointer, out thrown, type.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public static double CallStaticDoubleMethod(JniObjectReference type, JniMethodInfo method)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				double result = NativeMethods.java_interop_jnienv_call_static_double_method(EnvironmentPointer, out thrown, type.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public unsafe static double CallStaticDoubleMethod(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				IntPtr thrown;
				double result = NativeMethods.java_interop_jnienv_call_static_double_method_a(EnvironmentPointer, out thrown, type.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
				return result;
			}

			public static void CallStaticVoidMethod(JniObjectReference type, JniMethodInfo method)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				NativeMethods.java_interop_jnienv_call_static_void_method(EnvironmentPointer, out var thrown, type.Handle, method.ID);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}

			public unsafe static void CallStaticVoidMethod(JniObjectReference type, JniMethodInfo method, JniArgumentValue* args)
			{
				if (!type.IsValid)
				{
					throw new ArgumentException("Handle must be valid.", "type");
				}
				if (method == null)
				{
					throw new ArgumentNullException("method");
				}
				if (!method.IsValid)
				{
					throw new ArgumentException("Handle value is not valid.", "method");
				}
				NativeMethods.java_interop_jnienv_call_static_void_method_a(EnvironmentPointer, out var thrown, type.Handle, method.ID, (IntPtr)args);
				Exception exceptionForLastThrowable = GetExceptionForLastThrowable(thrown);
				if (exceptionForLastThrowable != null)
				{
					ExceptionDispatchInfo.Capture(exceptionForLastThrowable).Throw();
				}
			}
		}

		internal static readonly ThreadLocal<JniEnvironmentInfo> Info = new ThreadLocal<JniEnvironmentInfo>(() => new JniEnvironmentInfo(), trackAllValues: true);

		internal static JniEnvironmentInfo CurrentInfo
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				JniEnvironmentInfo value = Info.Value;
				if (!value.IsValid)
				{
					throw new NotSupportedException("JNI Environment Information has been invalidated on this thread.");
				}
				return value;
			}
		}

		public static JniRuntime Runtime
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return CurrentInfo.Runtime;
			}
		}

		public static IntPtr EnvironmentPointer
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return CurrentInfo.EnvironmentPointer;
			}
		}

		public static int LocalReferenceCount
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return CurrentInfo.LocalReferenceCount;
			}
		}

		public static bool WithinNewObjectScope
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return CurrentInfo.WithinNewObjectScope;
			}
			internal set
			{
				CurrentInfo.WithinNewObjectScope = value;
			}
		}

		internal static void SetEnvironmentPointer(IntPtr environmentPointer)
		{
			CurrentInfo.EnvironmentPointer = environmentPointer;
		}

		internal static void SetEnvironmentInfo(JniEnvironmentInfo info)
		{
			Info.Value = info;
		}

		internal static Exception GetExceptionForLastThrowable()
		{
			JniObjectReference reference = Exceptions.ExceptionOccurred();
			if (!reference.IsValid)
			{
				return null;
			}
			Exceptions.ExceptionClear();
			LogCreateLocalRef(reference);
			return Runtime.GetExceptionForThrowable(ref reference, JniObjectReferenceOptions.CopyAndDispose);
		}

		internal static Exception GetExceptionForLastThrowable(IntPtr thrown)
		{
			if (thrown == IntPtr.Zero)
			{
				return null;
			}
			JniObjectReference reference = new JniObjectReference(thrown, JniObjectReferenceType.Local);
			Exceptions.ExceptionClear();
			LogCreateLocalRef(reference);
			return Runtime.GetExceptionForThrowable(ref reference, JniObjectReferenceOptions.CopyAndDispose);
		}

		internal static void LogCreateLocalRef(JniObjectReference value)
		{
			if (value.IsValid)
			{
				Runtime.ObjectReferenceManager.CreatedLocalReference(CurrentInfo, value);
			}
		}

		internal static void LogCreateLocalRef(IntPtr value)
		{
			if (!(value == IntPtr.Zero))
			{
				LogCreateLocalRef(new JniObjectReference(value, JniObjectReferenceType.Local));
			}
		}
	}
	public class JniRuntime : IDisposable
	{
		public abstract class JniValueManager : ISetRuntime, IDisposable
		{
			private JniRuntime runtime;

			private bool disposed;

			private static readonly KeyValuePair<Type, Type>[] PeerTypeMappings = new KeyValuePair<Type, Type>[3]
			{
				new KeyValuePair<Type, Type>(typeof(object), typeof(JavaObject)),
				new KeyValuePair<Type, Type>(typeof(IJavaPeerable), typeof(JavaObject)),
				new KeyValuePair<Type, Type>(typeof(Exception), typeof(JavaException))
			};

			private static readonly Type ByRefJniObjectReference = typeof(JniObjectReference).MakeByRefType();

			private Dictionary<Type, JniValueMarshaler> Marshalers = new Dictionary<Type, JniValueMarshaler>();

			public JniRuntime Runtime => runtime ?? throw new NotSupportedException();

			public virtual void OnSetRuntime(JniRuntime runtime)
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				this.runtime = runtime;
			}

			public void Dispose()
			{
				Dispose(disposing: true);
				GC.SuppressFinalize(this);
			}

			protected virtual void Dispose(bool disposing)
			{
				disposed = true;
			}

			public abstract void AddPeer(IJavaPeerable value);

			public abstract void RemovePeer(IJavaPeerable value);

			public abstract void FinalizePeer(IJavaPeerable value);

			public abstract List<JniSurfacedPeerInfo> GetSurfacedPeers();

			public abstract void ActivatePeer(IJavaPeerable self, JniObjectReference reference, ConstructorInfo cinfo, object[] argumentValues);

			public void ConstructPeer(IJavaPeerable peer, ref JniObjectReference reference, JniObjectReferenceOptions options)
			{
				if (peer == null)
				{
					throw new ArgumentNullException("peer");
				}
				JniObjectReference peerReference = peer.PeerReference;
				if (peerReference.IsValid)
				{
					peer.SetJniManagedPeerState(peer.JniManagedPeerState | JniManagedPeerStates.Activatable);
					JniObjectReference.Dispose(ref reference, options);
					peerReference = peerReference.NewGlobalRef();
				}
				else
				{
					if (options == JniObjectReferenceOptions.None)
					{
						return;
					}
					if (!reference.IsValid)
					{
						throw new ArgumentException("JNI Object Reference is invalid.", "reference");
					}
					peerReference = reference;
					if ((options & JniObjectReferenceOptions.Copy) == JniObjectReferenceOptions.Copy)
					{
						peerReference = reference.NewGlobalRef();
					}
					JniObjectReference.Dispose(ref reference, options);
				}
				peer.SetPeerReference(peerReference);
				peer.SetJniIdentityHashCode(JniSystem.IdentityHashCode(peerReference));
				JniObjectReferenceManager objectReferenceManager = Runtime.ObjectReferenceManager;
				if (objectReferenceManager.LogGlobalReferenceMessages)
				{
					objectReferenceManager.WriteGlobalReferenceLine("Created PeerReference={0} IdentityHashCode=0x{1} Instance=0x{2} Instance.Type={3}, Java.Type={4}", peerReference.ToString(), peer.JniIdentityHashCode.ToString("x"), RuntimeHelpers.GetHashCode(peer).ToString("x"), peer.GetType().FullName, JniEnvironment.Types.GetJniTypeNameFromInstance(peerReference));
				}
				if ((options & (JniObjectReferenceOptions)4) != (JniObjectReferenceOptions)4)
				{
					AddPeer(peer);
				}
			}

			public int GetJniIdentityHashCode(JniObjectReference reference)
			{
				return JniSystem.IdentityHashCode(reference);
			}

			public virtual void DisposePeer(IJavaPeerable value)
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				if (value.PeerReference.IsValid)
				{
					value.Disposed();
					RemovePeer(value);
					JniObjectReference peerReference = value.PeerReference;
					if (peerReference.IsValid)
					{
						DisposePeer(peerReference, value);
					}
				}
			}

			private void DisposePeer(JniObjectReference h, IJavaPeerable value)
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				JniObjectReferenceManager objectReferenceManager = Runtime.ObjectReferenceManager;
				if (objectReferenceManager.LogGlobalReferenceMessages)
				{
					objectReferenceManager.WriteGlobalReferenceLine("Disposing PeerReference={0} IdentityHashCode=0x{1} Instance=0x{2} Instance.Type={3} Java.Type={4}", h.ToString(), value.JniIdentityHashCode.ToString("x"), RuntimeHelpers.GetHashCode(value).ToString("x"), value.GetType().ToString(), JniEnvironment.Types.GetJniTypeNameFromInstance(h));
				}
				JniObjectReference.Dispose(ref h);
				value.SetPeerReference(default(JniObjectReference));
				GC.SuppressFinalize(value);
			}

			public virtual void DisposePeerUnlessReferenced(IJavaPeerable value)
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				JniObjectReference peerReference = value.PeerReference;
				if (peerReference.IsValid)
				{
					IJavaPeerable javaPeerable = PeekPeer(peerReference);
					if (javaPeerable == null || javaPeerable != value)
					{
						DisposePeer(peerReference, value);
					}
				}
			}

			public abstract IJavaPeerable PeekPeer(JniObjectReference reference);

			public object PeekValue(JniObjectReference reference)
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				if (!reference.IsValid)
				{
					return null;
				}
				IJavaPeerable javaPeerable = PeekPeer(reference);
				if (javaPeerable == null)
				{
					return javaPeerable;
				}
				if (!TryUnboxPeerObject(javaPeerable, out var result))
				{
					return javaPeerable;
				}
				return result;
			}

			protected virtual bool TryUnboxPeerObject(IJavaPeerable value, out object result)
			{
				result = null;
				if (value is JavaProxyObject javaProxyObject)
				{
					result = javaProxyObject.Value;
					return true;
				}
				if (value is JavaProxyThrowable javaProxyThrowable)
				{
					result = javaProxyThrowable.Exception;
					return true;
				}
				return false;
			}

			private static Type GetPeerType(Type type)
			{
				KeyValuePair<Type, Type>[] peerTypeMappings = PeerTypeMappings;
				for (int i = 0; i < peerTypeMappings.Length; i++)
				{
					KeyValuePair<Type, Type> keyValuePair = peerTypeMappings[i];
					if (keyValuePair.Key == type)
					{
						return keyValuePair.Value;
					}
				}
				return type;
			}

			public virtual IJavaPeerable CreatePeer(ref JniObjectReference reference, JniObjectReferenceOptions transfer, Type targetType)
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				targetType = targetType ?? typeof(JavaObject);
				targetType = GetPeerType(targetType);
				if (!typeof(IJavaPeerable).IsAssignableFrom(targetType))
				{
					throw new ArgumentException("targetType `" + targetType.AssemblyQualifiedName + "` must implement IJavaPeerable!", "targetType");
				}
				ConstructorInfo peerConstructor = GetPeerConstructor(reference, targetType);
				if (peerConstructor == null)
				{
					throw new NotSupportedException($"Could not find an appropriate constructable wrapper type for Java type '{JniEnvironment.Types.GetJniTypeNameFromInstance(reference)}', targetType='{targetType}'.");
				}
				object[] array = new object[2] { reference, transfer };
				try
				{
					IJavaPeerable obj = (IJavaPeerable)peerConstructor.Invoke(array);
					obj.SetJniManagedPeerState(obj.JniManagedPeerState | JniManagedPeerStates.Replaceable);
					return obj;
				}
				finally
				{
					reference = (JniObjectReference)array[0];
				}
			}

			private ConstructorInfo GetPeerConstructor(JniObjectReference instance, Type fallbackType)
			{
				JniObjectReference reference = JniEnvironment.Types.GetObjectClass(instance);
				string text = JniEnvironment.Types.GetJniTypeNameFromClass(reference);
				Type type = null;
				while (text != null)
				{
					if (!JniTypeSignature.TryParse(text, out var result))
					{
						return null;
					}
					type = Runtime.TypeManager.GetType(result);
					if (type != null)
					{
						ConstructorInfo activationConstructor = GetActivationConstructor(type);
						if (activationConstructor != null)
						{
							JniObjectReference.Dispose(ref reference);
							return activationConstructor;
						}
					}
					JniObjectReference superclass = JniEnvironment.Types.GetSuperclass(reference);
					text = (superclass.IsValid ? JniEnvironment.Types.GetJniTypeNameFromClass(superclass) : null);
					JniObjectReference.Dispose(ref reference, JniObjectReferenceOptions.CopyAndDispose);
					reference = superclass;
				}
				JniObjectReference.Dispose(ref reference, JniObjectReferenceOptions.CopyAndDispose);
				return GetActivationConstructor(fallbackType);
			}

			private static ConstructorInfo GetActivationConstructor(Type type)
			{
				return (from c in type.GetConstructors(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
					let p = c.GetParameters()
					where p.Length == 2 && p[0].ParameterType == ByRefJniObjectReference && p[1].ParameterType == typeof(JniObjectReferenceOptions)
					select c).FirstOrDefault();
			}

			internal Type GetRuntimeType(JniObjectReference reference)
			{
				if (!reference.IsValid)
				{
					return null;
				}
				if (!JniTypeSignature.TryParse(JniEnvironment.Types.GetJniTypeNameFromInstance(reference), out var result))
				{
					return null;
				}
				return Runtime.TypeManager.GetType(result);
			}

			public object GetValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType = null)
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				if (!reference.IsValid)
				{
					return null;
				}
				object obj = PeekValue(reference);
				if (obj != null && (targetType == null || targetType.IsAssignableFrom(obj.GetType())))
				{
					JniObjectReference.Dispose(ref reference, options);
					return obj;
				}
				if (targetType != null && typeof(IJavaPeerable).IsAssignableFrom(targetType))
				{
					return JavaPeerableValueMarshaler.Instance.CreateGenericValue(ref reference, options, targetType);
				}
				targetType = targetType ?? GetRuntimeType(reference);
				if (targetType == null)
				{
					return JavaPeerableValueMarshaler.Instance.CreateGenericValue(ref reference, options, targetType);
				}
				return GetValueMarshaler(targetType).CreateValue(ref reference, options, targetType);
			}

			public T GetValue<T>(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType = null)
			{
				if (!reference.IsValid)
				{
					return default(T);
				}
				if (targetType != null && !typeof(T).IsAssignableFrom(targetType))
				{
					throw new ArgumentException(string.Format("Requested runtime '{0}' value of '{1}' is not compatible with requested compile-time type T of '{2}'.", "targetType", targetType, typeof(T)), "targetType");
				}
				targetType = targetType ?? typeof(T);
				object obj = PeekValue(reference);
				if (obj != null && (targetType == null || targetType.IsAssignableFrom(obj.GetType())))
				{
					JniObjectReference.Dispose(ref reference, options);
					return (T)obj;
				}
				if (typeof(IJavaPeerable).IsAssignableFrom(targetType))
				{
					return (T)JavaPeerableValueMarshaler.Instance.CreateGenericValue(ref reference, options, targetType);
				}
				return GetValueMarshaler<T>().CreateGenericValue(ref reference, options, targetType);
			}

			public JniValueMarshaler<T> GetValueMarshaler<T>()
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				JniValueMarshaler valueMarshaler = GetValueMarshaler(typeof(T));
				if (valueMarshaler is JniValueMarshaler<T> result)
				{
					return result;
				}
				lock (Marshalers)
				{
					if (!Marshalers.TryGetValue(typeof(T), out var value))
					{
						Marshalers.Add(typeof(T), value = new DelegatingValueMarshaler<T>(valueMarshaler));
					}
					return (JniValueMarshaler<T>)value;
				}
			}

			public JniValueMarshaler GetValueMarshaler(Type type)
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				if (type == null)
				{
					throw new ArgumentNullException("type");
				}
				if (type.ContainsGenericParameters)
				{
					throw new ArgumentException("Generic type definitions are not supported.", "type");
				}
				JniValueMarshalerAttribute customAttribute = type.GetCustomAttribute<JniValueMarshalerAttribute>();
				if (customAttribute != null)
				{
					return (JniValueMarshaler)Activator.CreateInstance(customAttribute.MarshalerType);
				}
				if (typeof(IJavaPeerable) == type)
				{
					return JavaPeerableValueMarshaler.Instance;
				}
				if (typeof(void) == type)
				{
					return VoidValueMarshaler.Instance;
				}
				KeyValuePair<Type, JniValueMarshaler>[] value = JniBuiltinMarshalers.Value;
				for (int i = 0; i < value.Length; i++)
				{
					KeyValuePair<Type, JniValueMarshaler> keyValuePair = value[i];
					if (keyValuePair.Key == type)
					{
						return keyValuePair.Value;
					}
				}
				Type listIface = typeof(IList<>);
				Type type2 = (from iface in type.GetInterfaces().Concat(new Type[1] { type })
					where listIface.IsAssignableFrom(iface.IsGenericType ? iface.GetGenericTypeDefinition() : iface)
					select iface).FirstOrDefault();
				if (type2 != null)
				{
					Type type3 = type2.GenericTypeArguments[0];
					if (type3.IsValueType)
					{
						value = JniPrimitiveArrayMarshalers.Value;
						for (int i = 0; i < value.Length; i++)
						{
							KeyValuePair<Type, JniValueMarshaler> keyValuePair2 = value[i];
							if (type.IsAssignableFrom(keyValuePair2.Key))
							{
								return keyValuePair2.Value;
							}
						}
					}
					return GetObjectArrayMarshaler(type3);
				}
				if (typeof(IJavaPeerable).IsAssignableFrom(type))
				{
					return JavaPeerableValueMarshaler.Instance;
				}
				JniValueMarshalerAttribute jniValueMarshalerAttribute = null;
				Type[] interfaces = type.GetInterfaces();
				for (int i = 0; i < interfaces.Length; i++)
				{
					customAttribute = interfaces[i].GetCustomAttribute<JniValueMarshalerAttribute>();
					if (customAttribute != null)
					{
						if (jniValueMarshalerAttribute != null)
						{
							throw new NotSupportedException($"There is more than one interface with custom marshaler for type {type}.");
						}
						jniValueMarshalerAttribute = customAttribute;
					}
				}
				if (jniValueMarshalerAttribute != null)
				{
					return (JniValueMarshaler)Activator.CreateInstance(jniValueMarshalerAttribute.MarshalerType);
				}
				return GetValueMarshalerCore(type);
			}

			private static JniValueMarshaler GetObjectArrayMarshaler(Type elementType)
			{
				MethodInfo method = new Func<JniValueMarshaler>(GetObjectArrayMarshalerHelper<object>).Method.GetGenericMethodDefinition().MakeGenericMethod(elementType);
				return ((Func<JniValueMarshaler>)Delegate.CreateDelegate(typeof(Func<JniValueMarshaler>), method))();
			}

			private static JniValueMarshaler GetObjectArrayMarshalerHelper<T>()
			{
				return JavaObjectArray<T>.Instance;
			}

			protected virtual JniValueMarshaler GetValueMarshalerCore(Type type)
			{
				return ProxyValueMarshaler.Instance;
			}
		}

		public class CreationOptions
		{
			public bool TrackIDs { get; }

			public bool DestroyRuntimeOnDispose { get; }

			public bool NewObjectRequired { get; set; }

			public JniVersion JniVersion { get; set; }

			public IntPtr InvocationPointer { get; set; }

			public IntPtr EnvironmentPointer { get; set; }

			public JniObjectReference ClassLoader { get; set; }

			public IntPtr ClassLoader_LoadClass_id { get; set; }

			public JniObjectReferenceManager ObjectReferenceManager { get; set; }

			public JniTypeManager TypeManager { get; set; }

			public bool JniAddNativeMethodRegistrationAttributePresent { get; set; } = true;

			public bool UseMarshalMemberBuilder { get; set; } = true;

			public JniMarshalMemberBuilder MarshalMemberBuilder { get; }

			public JniValueManager ValueManager { get; set; }

			public CreationOptions()
			{
				JniVersion = JniVersion.v1_2;
			}
		}

		private interface ISetRuntime
		{
			void OnSetRuntime(JniRuntime runtime);
		}

		public abstract class JniMarshalMemberBuilder : ISetRuntime
		{
			private JniRuntime runtime;

			private bool disposed;

			public virtual void OnSetRuntime(JniRuntime runtime)
			{
				if (disposed)
				{
					throw new ObjectDisposedException(GetType().Name);
				}
				this.runtime = runtime;
			}

			public void Dispose()
			{
				Dispose(disposing: false);
			}

			protected virtual void Dispose(bool disposing)
			{
				disposed = true;
			}
		}

		public abstract class JniObjectReferenceManager : IDisposable, ISetRuntime
		{
			private JniRuntime runtime;

			public abstract int GlobalReferenceCount { get; }

			public abstract int WeakGlobalReferenceCount { get; }

			public virtual bool LogGlobalReferenceMessages => false;

			public JniObjectReferenceManager()
			{
			}

			public virtual void OnSetRuntime(JniRuntime runtime)
			{
				this.runtime = runtime;
			}

			internal JniObjectReference CreateLocalReference(JniEnvironmentInfo environment, JniObjectReference reference)
			{
				int localReferenceCount = environment.LocalReferenceCount;
				JniObjectReference result = CreateLocalReference(reference, ref localReferenceCount);
				environment.LocalReferenceCount = localReferenceCount;
				return result;
			}

			public virtual JniObjectReference CreateLocalReference(JniObjectReference reference, ref int localReferenceCount)
			{
				if (!reference.IsValid)
				{
					return reference;
				}
				_ = localReferenceCount;
				_ = 0;
				localReferenceCount++;
				return JniEnvironment.References.NewLocalRef(reference);
			}

			internal void DeleteLocalReference(JniEnvironmentInfo environment, ref JniObjectReference reference)
			{
				int localReferenceCount = environment.LocalReferenceCount;
				DeleteLocalReference(ref reference, ref localReferenceCount);
				environment.LocalReferenceCount = localReferenceCount;
			}

			public virtual void DeleteLocalReference(ref JniObjectReference reference, ref int localReferenceCount)
			{
				if (reference.IsValid)
				{
					localReferenceCount--;
					_ = localReferenceCount;
					_ = 0;
					JniEnvironment.References.DeleteLocalRef(reference.Handle);
					reference.Invalidate();
				}
			}

			internal void CreatedLocalReference(JniEnvironmentInfo environment, JniObjectReference reference)
			{
				int localReferenceCount = environment.LocalReferenceCount;
				CreatedLocalReference(reference, ref localReferenceCount);
				environment.LocalReferenceCount = localReferenceCount;
			}

			public virtual void CreatedLocalReference(JniObjectReference reference, ref int localReferenceCount)
			{
				if (reference.IsValid)
				{
					_ = localReferenceCount;
					_ = 0;
					localReferenceCount++;
				}
			}

			public virtual void WriteGlobalReferenceLine(string format, params object[] args)
			{
			}

			public virtual JniObjectReference CreateGlobalReference(JniObjectReference reference)
			{
				if (!reference.IsValid)
				{
					return reference;
				}
				JniObjectReference result = JniEnvironment.References.NewGlobalRef(reference);
				_ = GlobalReferenceCount;
				_ = 0;
				return result;
			}

			public virtual void DeleteGlobalReference(ref JniObjectReference reference)
			{
				if (reference.IsValid)
				{
					_ = GlobalReferenceCount;
					_ = 0;
					JniEnvironment.References.DeleteGlobalRef(reference.Handle);
					reference.Invalidate();
				}
			}

			public virtual void DeleteWeakGlobalReference(ref JniObjectReference reference)
			{
				if (reference.IsValid)
				{
					_ = WeakGlobalReferenceCount;
					_ = 0;
					JniEnvironment.References.DeleteWeakGlobalRef(reference.Handle);
					reference.Invalidate();
				}
			}

			public void Dispose()
			{
				Dispose(disposing: false);
			}

			protected virtual void Dispose(bool disposing)
			{
			}
		}

		public class JniTypeManager : IDisposable, ISetRuntime
		{
			private JniRuntime runtime;

			private bool disposed;

			private static readonly string[] EmptyStringArray = Array.Empty<string>();

			private static readonly Type[] EmptyTypeArray = Array.Empty<Type>();

			private static Type[] registerMethodParameters = new Type[1] { typeof(JniNativeMethodRegistrationArguments) };

			private static List<JniNativeMethodRegistration> sharedRegistrations = new List<JniNativeMethodRegistration>();

			public JniRuntime Runtime => runtime ?? throw new NotSupportedException();

			public virtual void OnSetRuntime(JniRuntime runtime)
			{
				AssertValid();
				this.runtime = runtime;
			}

			public void Dispose()
			{
				Dispose(disposing: false);
			}

			protected virtual void Dispose(bool disposing)
			{
				disposed = true;
			}

			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			private void AssertValid()
			{
				if (!disposed)
				{
					return;
				}
				throw new ObjectDisposedException("JniTypeManager");
			}

			internal static void AssertSimpleReference(string jniSimpleReference, string argumentName = "jniSimpleReference")
			{
				if (string.IsNullOrEmpty(jniSimpleReference))
				{
					throw new ArgumentNullException(argumentName);
				}
				if (jniSimpleReference.IndexOf('.') >= 0)
				{
					throw new ArgumentException("JNI type names do not contain '.', they use '/'. Are you sure you're using a JNI type name?", argumentName);
				}
				switch (jniSimpleReference[0])
				{
				case '[':
					throw new ArgumentException("Arrays cannot be present in simplified type references.", argumentName);
				case 'L':
					if (jniSimpleReference[jniSimpleReference.Length - 1] == ';')
					{
						throw new ArgumentException("JNI type references are not supported.", argumentName);
					}
					break;
				}
			}

			public JniTypeSignature GetTypeSignature(Type type)
			{
				AssertValid();
				if (type == null)
				{
					throw new ArgumentNullException("type");
				}
				if (type.ContainsGenericParameters)
				{
					throw new ArgumentException($"'{type}' contains a generic type definition. This is not supported.", "type");
				}
				type = GetUnderlyingType(type, out var rank);
				JniTypeSignature signature = JniTypeSignature.Empty;
				if (GetBuiltInTypeSignature(type, ref signature))
				{
					return signature.AddArrayRank(rank);
				}
				if (GetBuiltInTypeArraySignature(type, ref signature))
				{
					return signature.AddArrayRank(rank);
				}
				string simpleReference = GetSimpleReference(type);
				if (simpleReference != null)
				{
					return new JniTypeSignature(simpleReference, rank);
				}
				JniTypeSignatureAttribute customAttribute = type.GetCustomAttribute<JniTypeSignatureAttribute>(inherit: false);
				if (customAttribute != null)
				{
					return new JniTypeSignature(customAttribute.SimpleReference, customAttribute.ArrayRank + rank, customAttribute.IsKeyword);
				}
				bool isGenericType = type.IsGenericType;
				Type type2 = (isGenericType ? type.GetGenericTypeDefinition() : type);
				if (isGenericType && (type2 == typeof(JavaArray<>) || type2 == typeof(JavaObjectArray<>)))
				{
					return GetTypeSignature(type.GenericTypeArguments[0]).AddArrayRank(rank + 1);
				}
				if (isGenericType)
				{
					simpleReference = GetSimpleReference(type2);
					if (simpleReference != null)
					{
						return new JniTypeSignature(simpleReference, rank);
					}
				}
				return default(JniTypeSignature);
			}

			private static Type GetUnderlyingType(Type type, out int rank)
			{
				rank = 0;
				Type type2 = type;
				while (type.IsArray)
				{
					if (type.IsArray && type.GetArrayRank() > 1)
					{
						throw new ArgumentException("Multidimensional array '" + type2.FullName + "' is not supported.", "type");
					}
					rank++;
					type = type.GetElementType();
				}
				if (type.IsEnum)
				{
					type = Enum.GetUnderlyingType(type);
				}
				return type;
			}

			protected virtual string GetSimpleReference(Type type)
			{
				return GetSimpleReferences(type).FirstOrDefault();
			}

			protected virtual IEnumerable<string> GetSimpleReferences(Type type)
			{
				AssertValid();
				if (type == null)
				{
					throw new ArgumentNullException("type");
				}
				if (type.IsArray)
				{
					throw new ArgumentException("Array type '" + type.FullName + "' is not supported.", "type");
				}
				return EmptyStringArray;
			}

			public Type GetType(JniTypeSignature typeSignature)
			{
				AssertValid();
				return GetTypes(typeSignature).FirstOrDefault();
			}

			public virtual IEnumerable<Type> GetTypes(JniTypeSignature typeSignature)
			{
				AssertValid();
				if (typeSignature.SimpleReference == null)
				{
					return EmptyTypeArray;
				}
				return CreateGetTypesEnumerator(typeSignature);
			}

			private IEnumerable<Type> CreateGetTypesEnumerator(JniTypeSignature typeSignature)
			{
				if (!typeSignature.IsValid)
				{
					yield break;
				}
				foreach (Type type in GetTypesForSimpleReference(typeSignature.SimpleReference ?? throw new InvalidOperationException("Should not be reached")))
				{
					if (typeSignature.ArrayRank == 0)
					{
						yield return type;
						continue;
					}
					if (typeSignature.ArrayRank > 0)
					{
						int num = typeSignature.ArrayRank;
						Type type2 = type;
						if (typeSignature.IsKeyword)
						{
							type2 = typeof(JavaPrimitiveArray<>).MakeGenericType(type2);
							num--;
						}
						while (num-- > 0)
						{
							type2 = typeof(JavaObjectArray<>).MakeGenericType(type2);
						}
						yield return type2;
					}
					if (typeSignature.ArrayRank > 0)
					{
						int arrayRank = typeSignature.ArrayRank;
						Type type3 = type;
						while (arrayRank-- > 0)
						{
							type3 = type3.MakeArrayType();
						}
						yield return type3;
					}
				}
			}

			protected virtual IEnumerable<Type> GetTypesForSimpleReference(string jniSimpleReference)
			{
				AssertValid();
				AssertSimpleReference(jniSimpleReference);
				return CreateGetTypesForSimpleReferenceEnumerator(jniSimpleReference);
			}

			private IEnumerable<Type> CreateGetTypesForSimpleReferenceEnumerator(string jniSimpleReference)
			{
				if (JniBuiltinSimpleReferenceToType.Value.TryGetValue(jniSimpleReference, out var value))
				{
					yield return value;
				}
			}

			public virtual void RegisterNativeMembers(JniType nativeClass, Type type, string methods)
			{
				TryRegisterNativeMembers(nativeClass, type, methods);
			}

			protected bool TryRegisterNativeMembers(JniType nativeClass, Type type, string methods)
			{
				AssertValid();
				if (!TryLoadJniMarshalMethods(nativeClass, type, methods))
				{
					return TryRegisterNativeMembers(nativeClass, type, methods, null);
				}
				return true;
			}

			private bool TryLoadJniMarshalMethods(JniType nativeClass, Type type, string methods)
			{
				Type type2 = type?.GetNestedType("__<$>_jni_marshal_methods", BindingFlags.NonPublic);
				if (type2 == null)
				{
					return false;
				}
				MethodInfo runtimeMethod = type2.GetRuntimeMethod("__RegisterNativeMembers", registerMethodParameters);
				return TryRegisterNativeMembers(nativeClass, type2, methods, runtimeMethod);
			}

			private bool TryRegisterNativeMembers(JniType nativeClass, Type marshalType, string methods, MethodInfo registerMethod)
			{
				bool lockTaken = false;
				bool result = false;
				try
				{
					Monitor.TryEnter(sharedRegistrations, ref lockTaken);
					List<JniNativeMethodRegistration> list;
					if (lockTaken)
					{
						sharedRegistrations.Clear();
						list = sharedRegistrations;
					}
					else
					{
						list = new List<JniNativeMethodRegistration>();
					}
					JniNativeMethodRegistrationArguments jniNativeMethodRegistrationArguments = new JniNativeMethodRegistrationArguments(list, methods);
					if (registerMethod != null)
					{
						registerMethod.Invoke(null, new object[1] { jniNativeMethodRegistrationArguments });
						result = true;
					}
					else
					{
						result = FindAndCallRegisterMethod(marshalType, jniNativeMethodRegistrationArguments);
					}
					if (list.Count > 0)
					{
						nativeClass.RegisterNativeMethods(list.ToArray());
					}
				}
				finally
				{
					if (lockTaken)
					{
						Monitor.Exit(sharedRegistrations);
					}
				}
				return result;
			}

			private bool FindAndCallRegisterMethod(Type marshalType, JniNativeMethodRegistrationArguments arguments)
			{
				if (!Runtime.JniAddNativeMethodRegistrationAttributePresent)
				{
					return false;
				}
				bool result = false;
				foreach (MethodInfo runtimeMethod in marshalType.GetRuntimeMethods())
				{
					if (runtimeMethod.GetCustomAttribute(typeof(JniAddNativeMethodRegistrationAttribute)) != null)
					{
						if ((runtimeMethod.Attributes & MethodAttributes.Static) != MethodAttributes.Static)
						{
							throw new InvalidOperationException(string.Format("The method {0} marked with {1} must be static", runtimeMethod, "JniAddNativeMethodRegistrationAttribute"));
						}
						((Action<JniNativeMethodRegistrationArguments>)runtimeMethod.CreateDelegate(typeof(Action<JniNativeMethodRegistrationArguments>)))(arguments);
						result = true;
					}
				}
				return result;
			}
		}

		private static JniTypeSignature __BooleanTypeArraySignature;

		private static JniTypeSignature __SByteTypeArraySignature;

		private static JniTypeSignature __CharTypeArraySignature;

		private static JniTypeSignature __Int16TypeArraySignature;

		private static JniTypeSignature __Int32TypeArraySignature;

		private static JniTypeSignature __Int64TypeArraySignature;

		private static JniTypeSignature __SingleTypeArraySignature;

		private static JniTypeSignature __DoubleTypeArraySignature;

		private static readonly Lazy<KeyValuePair<Type, JniValueMarshaler>[]> JniPrimitiveArrayMarshalers = new Lazy<KeyValuePair<Type, JniValueMarshaler>[]>(InitJniPrimitiveArrayMarshalers);

		private static JniTypeSignature __StringTypeSignature;

		private static JniTypeSignature __VoidTypeSignature;

		private static JniTypeSignature __BooleanTypeSignature;

		private static JniTypeSignature __BooleanNullableTypeSignature;

		private static JniTypeSignature __SByteTypeSignature;

		private static JniTypeSignature __SByteNullableTypeSignature;

		private static JniTypeSignature __CharTypeSignature;

		private static JniTypeSignature __CharNullableTypeSignature;

		private static JniTypeSignature __Int16TypeSignature;

		private static JniTypeSignature __Int16NullableTypeSignature;

		private static JniTypeSignature __Int32TypeSignature;

		private static JniTypeSignature __Int32NullableTypeSignature;

		private static JniTypeSignature __Int64TypeSignature;

		private static JniTypeSignature __Int64NullableTypeSignature;

		private static JniTypeSignature __SingleTypeSignature;

		private static JniTypeSignature __SingleNullableTypeSignature;

		private static JniTypeSignature __DoubleTypeSignature;

		private static JniTypeSignature __DoubleNullableTypeSignature;

		private static readonly Lazy<Dictionary<string, Type>> JniBuiltinSimpleReferenceToType = new Lazy<Dictionary<string, Type>>(InitJniBuiltinSimpleReferenceToType);

		private static readonly Lazy<KeyValuePair<Type, JniValueMarshaler>[]> JniBuiltinMarshalers = new Lazy<KeyValuePair<Type, JniValueMarshaler>[]>(InitJniBuiltinMarshalers);

		private static Dictionary<IntPtr, JniRuntime> Runtimes = new Dictionary<IntPtr, JniRuntime>();

		private static JniRuntime current;

		private Dictionary<IntPtr, IDisposable> TrackedInstances = new Dictionary<IntPtr, IDisposable>();

		private JavaVMInterface Invoker;

		private bool DestroyRuntimeOnDispose;

		internal JniObjectReference ClassLoader;

		internal JniMethodInfo ClassLoader_LoadClass;

		[CompilerGenerated]
		private bool <TrackIDs>k__BackingField;

		private JniMarshalMemberBuilder marshalMemberBuilder;

		private JniValueManager valueManager;

		public static JniRuntime CurrentRuntime
		{
			get
			{
				JniRuntime jniRuntime = current;
				if (jniRuntime != null)
				{
					return jniRuntime;
				}
				int num = 0;
				lock (Runtimes)
				{
					foreach (JniRuntime value in Runtimes.Values)
					{
						if (num++ == 0)
						{
							jniRuntime = value;
						}
					}
				}
				if (num == 1)
				{
					Interlocked.CompareExchange(ref current, jniRuntime, null);
					return jniRuntime;
				}
				if (num > 1)
				{
					throw new NotSupportedException($"Found {num} known Java Runtime instances. Don't know which to use. Use JniRuntime.SetCurrent().");
				}
				throw new NotSupportedException("No available Java runtime to attach to. Please create one.");
			}
		}

		public IntPtr InvocationPointer { get; private set; }

		public JniVersion JniVersion { get; private set; }

		private bool TrackIDs
		{
			[CompilerGenerated]
			set
			{
				<TrackIDs>k__BackingField = value;
			}
		}

		internal bool NewObjectRequired { get; private set; }

		internal bool JniAddNativeMethodRegistrationAttributePresent { get; }

		public JniObjectReferenceManager ObjectReferenceManager { get; private set; }

		public JniTypeManager TypeManager { get; private set; }

		public JniValueManager ValueManager => valueManager ?? throw new NotSupportedException();

		private static bool GetBuiltInTypeArraySignature(Type type, ref JniTypeSignature signature)
		{
			if (type == typeof(JavaArray<bool>) || type == typeof(JavaPrimitiveArray<bool>))
			{
				signature = GetCachedTypeSignature(ref __BooleanTypeArraySignature, "Z", 1, keyword: true);
				return true;
			}
			if (type == typeof(JavaArray<sbyte>) || type == typeof(JavaPrimitiveArray<sbyte>))
			{
				signature = GetCachedTypeSignature(ref __SByteTypeArraySignature, "B", 1, keyword: true);
				return true;
			}
			if (type == typeof(JavaArray<char>) || type == typeof(JavaPrimitiveArray<char>))
			{
				signature = GetCachedTypeSignature(ref __CharTypeArraySignature, "C", 1, keyword: true);
				return true;
			}
			if (type == typeof(JavaArray<short>) || type == typeof(JavaPrimitiveArray<short>))
			{
				signature = GetCachedTypeSignature(ref __Int16TypeArraySignature, "S", 1, keyword: true);
				return true;
			}
			if (type == typeof(JavaArray<int>) || type == typeof(JavaPrimitiveArray<int>))
			{
				signature = GetCachedTypeSignature(ref __Int32TypeArraySignature, "I", 1, keyword: true);
				return true;
			}
			if (type == typeof(JavaArray<long>) || type == typeof(JavaPrimitiveArray<long>))
			{
				signature = GetCachedTypeSignature(ref __Int64TypeArraySignature, "J", 1, keyword: true);
				return true;
			}
			if (type == typeof(JavaArray<float>) || type == typeof(JavaPrimitiveArray<float>))
			{
				signature = GetCachedTypeSignature(ref __SingleTypeArraySignature, "F", 1, keyword: true);
				return true;
			}
			if (type == typeof(JavaArray<double>) || type == typeof(JavaPrimitiveArray<double>))
			{
				signature = GetCachedTypeSignature(ref __DoubleTypeArraySignature, "D", 1, keyword: true);
				return true;
			}
			return false;
		}

		private static KeyValuePair<Type, JniValueMarshaler>[] InitJniPrimitiveArrayMarshalers()
		{
			return new KeyValuePair<Type, JniValueMarshaler>[32]
			{
				new KeyValuePair<Type, JniValueMarshaler>(typeof(bool[]), JavaBooleanArray.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaArray<bool>), JavaBooleanArray.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaPrimitiveArray<bool>), JavaBooleanArray.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaBooleanArray), JavaBooleanArray.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(sbyte[]), JavaSByteArray.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaArray<sbyte>), JavaSByteArray.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaPrimitiveArray<sbyte>), JavaSByteArray.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaSByteArray), JavaSByteArray.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(char[]), JavaCharArray.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaArray<char>), JavaCharArray.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaPrimitiveArray<char>), JavaCharArray.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaCharArray), JavaCharArray.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(short[]), JavaInt16Array.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaArray<short>), JavaInt16Array.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaPrimitiveArray<short>), JavaInt16Array.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaInt16Array), JavaInt16Array.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(int[]), JavaInt32Array.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaArray<int>), JavaInt32Array.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaPrimitiveArray<int>), JavaInt32Array.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaInt32Array), JavaInt32Array.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(long[]), JavaInt64Array.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaArray<long>), JavaInt64Array.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaPrimitiveArray<long>), JavaInt64Array.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaInt64Array), JavaInt64Array.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(float[]), JavaSingleArray.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaArray<float>), JavaSingleArray.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaPrimitiveArray<float>), JavaSingleArray.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaSingleArray), JavaSingleArray.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(double[]), JavaDoubleArray.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaArray<double>), JavaDoubleArray.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaPrimitiveArray<double>), JavaDoubleArray.ArrayMarshaler),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(JavaDoubleArray), JavaDoubleArray.ArrayMarshaler)
			};
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private static JniTypeSignature GetCachedTypeSignature(ref JniTypeSignature field, string signature, int arrayRank = 0, bool keyword = false)
		{
			if (!field.IsValid)
			{
				field = new JniTypeSignature(signature, arrayRank, keyword);
			}
			return field;
		}

		private static bool GetBuiltInTypeSignature(Type type, ref JniTypeSignature signature)
		{
			switch (Type.GetTypeCode(type))
			{
			case TypeCode.String:
				signature = GetCachedTypeSignature(ref __StringTypeSignature, "java/lang/String");
				return true;
			case TypeCode.Boolean:
				signature = GetCachedTypeSignature(ref __BooleanTypeSignature, "Z", 0, keyword: true);
				return true;
			case TypeCode.SByte:
				signature = GetCachedTypeSignature(ref __SByteTypeSignature, "B", 0, keyword: true);
				return true;
			case TypeCode.Char:
				signature = GetCachedTypeSignature(ref __CharTypeSignature, "C", 0, keyword: true);
				return true;
			case TypeCode.Int16:
				signature = GetCachedTypeSignature(ref __Int16TypeSignature, "S", 0, keyword: true);
				return true;
			case TypeCode.Int32:
				signature = GetCachedTypeSignature(ref __Int32TypeSignature, "I", 0, keyword: true);
				return true;
			case TypeCode.Int64:
				signature = GetCachedTypeSignature(ref __Int64TypeSignature, "J", 0, keyword: true);
				return true;
			case TypeCode.Single:
				signature = GetCachedTypeSignature(ref __SingleTypeSignature, "F", 0, keyword: true);
				return true;
			case TypeCode.Double:
				signature = GetCachedTypeSignature(ref __DoubleTypeSignature, "D", 0, keyword: true);
				return true;
			case TypeCode.Empty:
			case TypeCode.DBNull:
			case TypeCode.UInt16:
			case TypeCode.UInt32:
			case TypeCode.UInt64:
			case TypeCode.Decimal:
			case TypeCode.DateTime:
				return false;
			default:
				if (type == typeof(void))
				{
					signature = GetCachedTypeSignature(ref __VoidTypeSignature, "V", 0, keyword: true);
					return true;
				}
				if (!type.IsValueType)
				{
					return false;
				}
				if (type == typeof(bool?))
				{
					signature = GetCachedTypeSignature(ref __BooleanNullableTypeSignature, "java/lang/Boolean");
					return true;
				}
				if (type == typeof(sbyte?))
				{
					signature = GetCachedTypeSignature(ref __SByteNullableTypeSignature, "java/lang/Byte");
					return true;
				}
				if (type == typeof(char?))
				{
					signature = GetCachedTypeSignature(ref __CharNullableTypeSignature, "java/lang/Character");
					return true;
				}
				if (type == typeof(short?))
				{
					signature = GetCachedTypeSignature(ref __Int16NullableTypeSignature, "java/lang/Short");
					return true;
				}
				if (type == typeof(int?))
				{
					signature = GetCachedTypeSignature(ref __Int32NullableTypeSignature, "java/lang/Integer");
					return true;
				}
				if (type == typeof(long?))
				{
					signature = GetCachedTypeSignature(ref __Int64NullableTypeSignature, "java/lang/Long");
					return true;
				}
				if (type == typeof(float?))
				{
					signature = GetCachedTypeSignature(ref __SingleNullableTypeSignature, "java/lang/Float");
					return true;
				}
				if (type == typeof(double?))
				{
					signature = GetCachedTypeSignature(ref __DoubleNullableTypeSignature, "java/lang/Double");
					return true;
				}
				return false;
			}
		}

		private static Dictionary<string, Type> InitJniBuiltinSimpleReferenceToType()
		{
			return new Dictionary<string, Type>(StringComparer.Ordinal)
			{
				{
					"java/lang/String",
					typeof(string)
				},
				{
					"V",
					typeof(void)
				},
				{
					"Z",
					typeof(bool)
				},
				{
					"java/lang/Boolean",
					typeof(bool?)
				},
				{
					"B",
					typeof(sbyte)
				},
				{
					"java/lang/Byte",
					typeof(sbyte?)
				},
				{
					"C",
					typeof(char)
				},
				{
					"java/lang/Character",
					typeof(char?)
				},
				{
					"S",
					typeof(short)
				},
				{
					"java/lang/Short",
					typeof(short?)
				},
				{
					"I",
					typeof(int)
				},
				{
					"java/lang/Integer",
					typeof(int?)
				},
				{
					"J",
					typeof(long)
				},
				{
					"java/lang/Long",
					typeof(long?)
				},
				{
					"F",
					typeof(float)
				},
				{
					"java/lang/Float",
					typeof(float?)
				},
				{
					"D",
					typeof(double)
				},
				{
					"java/lang/Double",
					typeof(double?)
				}
			};
		}

		private static KeyValuePair<Type, JniValueMarshaler>[] InitJniBuiltinMarshalers()
		{
			return new KeyValuePair<Type, JniValueMarshaler>[17]
			{
				new KeyValuePair<Type, JniValueMarshaler>(typeof(string), JniStringValueMarshaler.Instance),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(bool), JniBooleanValueMarshaler.Instance),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(bool?), JniNullableBooleanValueMarshaler.Instance),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(sbyte), JniSByteValueMarshaler.Instance),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(sbyte?), JniNullableSByteValueMarshaler.Instance),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(char), JniCharValueMarshaler.Instance),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(char?), JniNullableCharValueMarshaler.Instance),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(short), JniInt16ValueMarshaler.Instance),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(short?), JniNullableInt16ValueMarshaler.Instance),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(int), JniInt32ValueMarshaler.Instance),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(int?), JniNullableInt32ValueMarshaler.Instance),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(long), JniInt64ValueMarshaler.Instance),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(long?), JniNullableInt64ValueMarshaler.Instance),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(float), JniSingleValueMarshaler.Instance),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(float?), JniNullableSingleValueMarshaler.Instance),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(double), JniDoubleValueMarshaler.Instance),
				new KeyValuePair<Type, JniValueMarshaler>(typeof(double?), JniNullableDoubleValueMarshaler.Instance)
			};
		}

		public static JniRuntime GetRegisteredRuntime(IntPtr invocationPointer)
		{
			lock (Runtimes)
			{
				JniRuntime value;
				return Runtimes.TryGetValue(invocationPointer, out value) ? value : null;
			}
		}

		protected JniRuntime(CreationOptions options)
		{
			if (options == null)
			{
				throw new ArgumentNullException("options");
			}
			if (options.InvocationPointer == IntPtr.Zero)
			{
				throw new ArgumentException("options.InvocationPointer is null", "options");
			}
			TrackIDs = options.TrackIDs;
			DestroyRuntimeOnDispose = options.DestroyRuntimeOnDispose;
			JniAddNativeMethodRegistrationAttributePresent = options.JniAddNativeMethodRegistrationAttributePresent;
			NewObjectRequired = options.NewObjectRequired;
			JniVersion = options.JniVersion;
			InvocationPointer = options.InvocationPointer;
			Invoker = CreateInvoker(InvocationPointer);
			SetValueManager(options);
			SetMarshalMemberBuilder(options);
			ObjectReferenceManager = SetRuntime(options.ObjectReferenceManager ?? throw new NotSupportedException("Please set CreationOptions.ObjectReferenceManager!"));
			TypeManager = SetRuntime(options.TypeManager ?? new JniTypeManager());
			Interlocked.CompareExchange(ref current, this, null);
			lock (Runtimes)
			{
				Runtimes[InvocationPointer] = this;
			}
			IntPtr envptr = options.EnvironmentPointer;
			if (envptr == IntPtr.Zero && Invoker.GetEnv(InvocationPointer, out envptr, (int)JniVersion) != 0 && (envptr = _AttachCurrentThread()) == IntPtr.Zero)
			{
				throw new InvalidOperationException("Could not obtain JNIEnv* value!");
			}
			JniEnvironment.SetEnvironmentInfo(new JniEnvironmentInfo(envptr, this));
			ClassLoader = options.ClassLoader;
			if (options.ClassLoader_LoadClass_id != IntPtr.Zero)
			{
				ClassLoader_LoadClass = new JniMethodInfo(options.ClassLoader_LoadClass_id, isStatic: false);
			}
			if (ClassLoader.IsValid)
			{
				ClassLoader = ClassLoader.NewGlobalRef();
			}
			if (!ClassLoader.IsValid || ClassLoader_LoadClass == null)
			{
				using JniType jniType = new JniType("java/lang/ClassLoader");
				if (!ClassLoader.IsValid)
				{
					JniMethodInfo staticMethod = jniType.GetStaticMethod("getSystemClassLoader", "()Ljava/lang/ClassLoader;");
					JniObjectReference reference = JniEnvironment.StaticMethods.CallStaticObjectMethod(jniType.PeerReference, staticMethod);
					ClassLoader = reference.NewGlobalRef();
					JniObjectReference.Dispose(ref reference);
				}
				if (ClassLoader_LoadClass == null)
				{
					ClassLoader_LoadClass = jniType.GetInstanceMethod("loadClass", "(Ljava/lang/String;)Ljava/lang/Class;");
				}
			}
			ManagedPeer.Init();
		}

		private T SetRuntime<T>(T value) where T : class, ISetRuntime
		{
			if (value == null)
			{
				throw new NotSupportedException();
			}
			value.OnSetRuntime(this);
			return value;
		}

		private void SetValueManager(CreationOptions options)
		{
			JniValueManager jniValueManager = options.ValueManager;
			if (jniValueManager == null)
			{
				throw new ArgumentException("No JniValueManager specified in JniRuntime.CreationOptions.ValueManager.", "options");
			}
			valueManager = SetRuntime(jniValueManager);
		}

		private void SetMarshalMemberBuilder(CreationOptions options)
		{
			if (!options.UseMarshalMemberBuilder)
			{
				return;
			}
			if (options.MarshalMemberBuilder != null)
			{
				marshalMemberBuilder = SetRuntime(options.MarshalMemberBuilder);
				return;
			}
			Assembly assembly;
			try
			{
				assembly = Assembly.Load(new AssemblyName("Java.Interop.Export"));
			}
			catch (Exception)
			{
				return;
			}
			Type type = assembly.GetType("Java.Interop.MarshalMemberBuilder");
			if (type == null)
			{
				throw new InvalidOperationException("Could not find Java.Interop.MarshalMemberBuilder from Java.Interop.Export.dll!");
			}
			JniMarshalMemberBuilder runtime = (JniMarshalMemberBuilder)Activator.CreateInstance(type);
			marshalMemberBuilder = SetRuntime(runtime);
		}

		private static JavaVMInterface CreateInvoker(IntPtr handle)
		{
			return (JavaVMInterface)Marshal.PtrToStructure(Marshal.ReadIntPtr(handle), typeof(JavaVMInterface));
		}

		~JniRuntime()
		{
			Dispose(disposing: false);
		}

		public override string ToString()
		{
			return string.Format("{0}(0x{1})", GetType().FullName, InvocationPointer.ToString("x"));
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (InvocationPointer == IntPtr.Zero)
			{
				return;
			}
			Interlocked.CompareExchange(ref current, null, this);
			lock (Runtimes)
			{
				if (Runtimes.TryGetValue(InvocationPointer, out var value) && value == this)
				{
					Runtimes.Remove(InvocationPointer);
				}
			}
			if (disposing)
			{
				JniObjectReference.Dispose(ref ClassLoader);
				ClearTrackedReferences();
				ValueManager.Dispose();
				marshalMemberBuilder?.Dispose();
				TypeManager.Dispose();
				ObjectReferenceManager.Dispose();
				IList<JniEnvironmentInfo> values = JniEnvironment.Info.Values;
				for (int i = 0; i < values.Count; i++)
				{
					if (values[i].Runtime == this)
					{
						values[i].Dispose();
					}
				}
			}
			if (DestroyRuntimeOnDispose)
			{
				DestroyRuntime();
			}
			InvocationPointer = IntPtr.Zero;
			Invoker = default(JavaVMInterface);
		}

		internal IntPtr _AttachCurrentThread(string name = null, JniObjectReference group = default(JniObjectReference))
		{
			AssertValid();
			JavaVMThreadAttachArgs args = new JavaVMThreadAttachArgs
			{
				version = JniVersion
			};
			try
			{
				if (name != null)
				{
					args.name = Marshal.StringToHGlobalAnsi(name);
				}
				if (group.IsValid)
				{
					args.group = group.Handle;
				}
				IntPtr env;
				int num = Invoker.AttachCurrentThread(InvocationPointer, out env, ref args);
				if (num != 0)
				{
					throw new NotSupportedException("AttachCurrentThread returned " + num);
				}
				return env;
			}
			finally
			{
				Marshal.FreeHGlobal(args.name);
			}
		}

		private void AssertValid()
		{
			if (InvocationPointer == IntPtr.Zero)
			{
				throw new ObjectDisposedException("JniRuntime");
			}
		}

		public void DestroyRuntime()
		{
			AssertValid();
			Invoker.DestroyJavaVM(InvocationPointer);
		}

		public virtual Exception GetExceptionForThrowable(ref JniObjectReference reference, JniObjectReferenceOptions options)
		{
			return ValueManager.GetValue<Exception>(ref reference, options);
		}

		internal void Track(JniType value)
		{
			lock (TrackedInstances)
			{
				if (!TrackedInstances.ContainsKey(value.PeerReference.Handle))
				{
					TrackedInstances[value.PeerReference.Handle] = value;
				}
			}
		}

		internal void UnTrack(IntPtr key)
		{
			lock (TrackedInstances)
			{
				if (TrackedInstances.ContainsKey(key))
				{
					TrackedInstances.Remove(key);
				}
			}
		}

		private void ClearTrackedReferences()
		{
			List<IDisposable> list;
			lock (TrackedInstances)
			{
				list = new List<IDisposable>(TrackedInstances.Values);
				TrackedInstances.Clear();
			}
			foreach (IDisposable item in list)
			{
				item.Dispose();
			}
		}

		public virtual bool ExceptionShouldTransitionToJni(Exception e)
		{
			return !Debugger.IsAttached;
		}

		public virtual void RaisePendingException(Exception pendingException)
		{
			JniEnvironment.Exceptions.Throw(pendingException);
		}
	}
	public sealed class JniBooleanArrayElements : JniArrayElements
	{
		private JniObjectReference arrayHandle;

		public new unsafe bool* Elements => (bool*)(void*)base.Elements;

		public unsafe ref bool this[int index]
		{
			get
			{
				if (base.IsDisposed)
				{
					throw new ObjectDisposedException(GetType().FullName);
				}
				return ref Elements[index];
			}
		}

		internal unsafe JniBooleanArrayElements(JniObjectReference arrayHandle, bool* elements, int size)
			: base((IntPtr)elements, size)
		{
			this.arrayHandle = arrayHandle;
		}

		protected unsafe override void Synchronize(JniReleaseArrayElementsMode releaseMode)
		{
			JniEnvironment.Arrays.ReleaseBooleanArrayElements(arrayHandle, Elements, releaseMode);
		}
	}
	[JniTypeSignature("Z", ArrayRank = 1, IsKeyword = true)]
	public sealed class JavaBooleanArray : JavaPrimitiveArray<bool>
	{
		internal sealed class ValueMarshaler : JniValueMarshaler<IList<bool>>
		{
			public override IList<bool> CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
			{
				return JavaArray<bool>.CreateValue(ref reference, options, targetType, delegate(ref JniObjectReference h, JniObjectReferenceOptions o)
				{
					return new JavaBooleanArray(ref h, o);
				});
			}

			public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(IList<bool> value, ParameterAttributes synchronize)
			{
				return JavaArray<bool>.CreateArgumentState(value, synchronize, delegate(IList<bool> list, bool copy)
				{
					JavaBooleanArray obj = (copy ? new JavaBooleanArray(list) : new JavaBooleanArray(list.Count));
					obj.forMarshalCollection = true;
					return obj;
				});
			}

			public override void DestroyGenericArgumentState(IList<bool> value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
			{
				JavaArray<bool>.DestroyArgumentState<JavaBooleanArray>(value, ref state, synchronize);
			}
		}

		internal static readonly ValueMarshaler ArrayMarshaler = new ValueMarshaler();

		public JavaBooleanArray(ref JniObjectReference handle, JniObjectReferenceOptions options)
			: base(ref handle, options)
		{
		}

		public unsafe JavaBooleanArray(int length)
			: base(ref *JavaObject.InvalidJniObjectReference, JniObjectReferenceOptions.None)
		{
			JniObjectReference reference = JniEnvironment.Arrays.NewBooleanArray(JavaArray<bool>.CheckLength(length));
			Construct(ref reference, JniObjectReferenceOptions.CopyAndDispose);
		}

		public JavaBooleanArray(IList<bool> value)
			: this(JavaArray<bool>.CheckLength(value))
		{
			CopyFrom(JavaPrimitiveArray<bool>.ToArray(value), 0, 0, value.Count);
		}

		public unsafe JniBooleanArrayElements GetElements()
		{
			if (!base.PeerReference.IsValid)
			{
				throw new ObjectDisposedException(GetType().FullName);
			}
			bool* booleanArrayElements = JniEnvironment.Arrays.GetBooleanArrayElements(base.PeerReference, null);
			if (booleanArrayElements == null)
			{
				throw new InvalidOperationException("`JniEnvironment.Arrays.GetBooleanArrayElements()` returned NULL!");
			}
			return new JniBooleanArrayElements(base.PeerReference, booleanArrayElements, base.Length);
		}

		public override int IndexOf(bool item)
		{
			int length = base.Length;
			if (length == 0)
			{
				return -1;
			}
			using (JniBooleanArrayElements jniBooleanArrayElements = GetElements())
			{
				if (jniBooleanArrayElements == null)
				{
					return -1;
				}
				for (int i = 0; i < length; i++)
				{
					if (jniBooleanArrayElements[i] == item)
					{
						return i;
					}
				}
			}
			return -1;
		}

		public override void Clear()
		{
			int length = base.Length;
			using JniBooleanArrayElements jniBooleanArrayElements = GetElements();
			for (int i = 0; i < length; i++)
			{
				jniBooleanArrayElements[i] = false;
			}
		}

		public unsafe override void CopyTo(int sourceIndex, bool[] destinationArray, int destinationIndex, int length)
		{
			if (destinationArray == null)
			{
				throw new ArgumentNullException("destinationArray");
			}
			JavaArray<bool>.CheckArrayCopy(sourceIndex, base.Length, destinationIndex, destinationArray.Length, length);
			if (destinationArray.Length != 0)
			{
				fixed (bool* ptr = destinationArray)
				{
					JniEnvironment.Arrays.GetBooleanArrayRegion(base.PeerReference, sourceIndex, length, ptr + destinationIndex);
				}
			}
		}

		public unsafe override void CopyFrom(bool[] sourceArray, int sourceIndex, int destinationIndex, int length)
		{
			if (sourceArray == null)
			{
				throw new ArgumentNullException("sourceArray");
			}
			JavaArray<bool>.CheckArrayCopy(sourceIndex, sourceArray.Length, destinationIndex, base.Length, length);
			if (sourceArray.Length != 0)
			{
				fixed (bool* ptr = sourceArray)
				{
					JniEnvironment.Arrays.SetBooleanArrayRegion(base.PeerReference, destinationIndex, length, ptr + sourceIndex);
				}
			}
		}

		internal override bool TargetTypeIsCurrentType(Type targetType)
		{
			if (!base.TargetTypeIsCurrentType(targetType) && !(typeof(JavaPrimitiveArray<bool>) == targetType))
			{
				return typeof(JavaBooleanArray) == targetType;
			}
			return true;
		}
	}
	public sealed class JniSByteArrayElements : JniArrayElements
	{
		private JniObjectReference arrayHandle;

		public new unsafe sbyte* Elements => (sbyte*)(void*)base.Elements;

		public unsafe ref sbyte this[int index]
		{
			get
			{
				if (base.IsDisposed)
				{
					throw new ObjectDisposedException(GetType().FullName);
				}
				return ref Elements[index];
			}
		}

		internal unsafe JniSByteArrayElements(JniObjectReference arrayHandle, sbyte* elements, int size)
			: base((IntPtr)elements, size)
		{
			this.arrayHandle = arrayHandle;
		}

		protected unsafe override void Synchronize(JniReleaseArrayElementsMode releaseMode)
		{
			JniEnvironment.Arrays.ReleaseByteArrayElements(arrayHandle, Elements, releaseMode);
		}
	}
	[JniTypeSignature("B", ArrayRank = 1, IsKeyword = true)]
	public sealed class JavaSByteArray : JavaPrimitiveArray<sbyte>
	{
		internal sealed class ValueMarshaler : JniValueMarshaler<IList<sbyte>>
		{
			public override IList<sbyte> CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
			{
				return JavaArray<sbyte>.CreateValue(ref reference, options, targetType, delegate(ref JniObjectReference h, JniObjectReferenceOptions o)
				{
					return new JavaSByteArray(ref h, o);
				});
			}

			public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(IList<sbyte> value, ParameterAttributes synchronize)
			{
				return JavaArray<sbyte>.CreateArgumentState(value, synchronize, delegate(IList<sbyte> list, bool copy)
				{
					JavaSByteArray obj = (copy ? new JavaSByteArray(list) : new JavaSByteArray(list.Count));
					obj.forMarshalCollection = true;
					return obj;
				});
			}

			public override void DestroyGenericArgumentState(IList<sbyte> value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
			{
				JavaArray<sbyte>.DestroyArgumentState<JavaSByteArray>(value, ref state, synchronize);
			}
		}

		internal static readonly ValueMarshaler ArrayMarshaler = new ValueMarshaler();

		public JavaSByteArray(ref JniObjectReference handle, JniObjectReferenceOptions options)
			: base(ref handle, options)
		{
		}

		public unsafe JavaSByteArray(int length)
			: base(ref *JavaObject.InvalidJniObjectReference, JniObjectReferenceOptions.None)
		{
			JniObjectReference reference = JniEnvironment.Arrays.NewByteArray(JavaArray<sbyte>.CheckLength(length));
			Construct(ref reference, JniObjectReferenceOptions.CopyAndDispose);
		}

		public JavaSByteArray(IList<sbyte> value)
			: this(JavaArray<sbyte>.CheckLength(value))
		{
			CopyFrom(JavaPrimitiveArray<sbyte>.ToArray(value), 0, 0, value.Count);
		}

		public unsafe JniSByteArrayElements GetElements()
		{
			if (!base.PeerReference.IsValid)
			{
				throw new ObjectDisposedException(GetType().FullName);
			}
			sbyte* byteArrayElements = JniEnvironment.Arrays.GetByteArrayElements(base.PeerReference, null);
			if (byteArrayElements == null)
			{
				throw new InvalidOperationException("`JniEnvironment.Arrays.GetByteArrayElements()` returned NULL!");
			}
			return new JniSByteArrayElements(base.PeerReference, byteArrayElements, base.Length);
		}

		public override int IndexOf(sbyte item)
		{
			int length = base.Length;
			if (length == 0)
			{
				return -1;
			}
			using (JniSByteArrayElements jniSByteArrayElements = GetElements())
			{
				if (jniSByteArrayElements == null)
				{
					return -1;
				}
				for (int i = 0; i < length; i++)
				{
					if (jniSByteArrayElements[i] == item)
					{
						return i;
					}
				}
			}
			return -1;
		}

		public override void Clear()
		{
			int length = base.Length;
			using JniSByteArrayElements jniSByteArrayElements = GetElements();
			for (int i = 0; i < length; i++)
			{
				jniSByteArrayElements[i] = 0;
			}
		}

		public unsafe override void CopyTo(int sourceIndex, sbyte[] destinationArray, int destinationIndex, int length)
		{
			if (destinationArray == null)
			{
				throw new ArgumentNullException("destinationArray");
			}
			JavaArray<sbyte>.CheckArrayCopy(sourceIndex, base.Length, destinationIndex, destinationArray.Length, length);
			if (destinationArray.Length != 0)
			{
				fixed (sbyte* ptr = destinationArray)
				{
					JniEnvironment.Arrays.GetByteArrayRegion(base.PeerReference, sourceIndex, length, ptr + destinationIndex);
				}
			}
		}

		public unsafe override void CopyFrom(sbyte[] sourceArray, int sourceIndex, int destinationIndex, int length)
		{
			if (sourceArray == null)
			{
				throw new ArgumentNullException("sourceArray");
			}
			JavaArray<sbyte>.CheckArrayCopy(sourceIndex, sourceArray.Length, destinationIndex, base.Length, length);
			if (sourceArray.Length != 0)
			{
				fixed (sbyte* ptr = sourceArray)
				{
					JniEnvironment.Arrays.SetByteArrayRegion(base.PeerReference, destinationIndex, length, ptr + sourceIndex);
				}
			}
		}

		internal override bool TargetTypeIsCurrentType(Type targetType)
		{
			if (!base.TargetTypeIsCurrentType(targetType) && !(typeof(JavaPrimitiveArray<sbyte>) == targetType))
			{
				return typeof(JavaSByteArray) == targetType;
			}
			return true;
		}
	}
	public sealed class JniCharArrayElements : JniArrayElements
	{
		private JniObjectReference arrayHandle;

		public new unsafe char* Elements => (char*)(void*)base.Elements;

		public unsafe ref char this[int index]
		{
			get
			{
				if (base.IsDisposed)
				{
					throw new ObjectDisposedException(GetType().FullName);
				}
				return ref Elements[index];
			}
		}

		internal unsafe JniCharArrayElements(JniObjectReference arrayHandle, char* elements, int size)
			: base((IntPtr)elements, size)
		{
			this.arrayHandle = arrayHandle;
		}

		protected unsafe override void Synchronize(JniReleaseArrayElementsMode releaseMode)
		{
			JniEnvironment.Arrays.ReleaseCharArrayElements(arrayHandle, Elements, releaseMode);
		}
	}
	[JniTypeSignature("C", ArrayRank = 1, IsKeyword = true)]
	public sealed class JavaCharArray : JavaPrimitiveArray<char>
	{
		internal sealed class ValueMarshaler : JniValueMarshaler<IList<char>>
		{
			public override IList<char> CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
			{
				return JavaArray<char>.CreateValue(ref reference, options, targetType, delegate(ref JniObjectReference h, JniObjectReferenceOptions o)
				{
					return new JavaCharArray(ref h, o);
				});
			}

			public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(IList<char> value, ParameterAttributes synchronize)
			{
				return JavaArray<char>.CreateArgumentState(value, synchronize, delegate(IList<char> list, bool copy)
				{
					JavaCharArray obj = (copy ? new JavaCharArray(list) : new JavaCharArray(list.Count));
					obj.forMarshalCollection = true;
					return obj;
				});
			}

			public override void DestroyGenericArgumentState(IList<char> value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
			{
				JavaArray<char>.DestroyArgumentState<JavaCharArray>(value, ref state, synchronize);
			}
		}

		internal static readonly ValueMarshaler ArrayMarshaler = new ValueMarshaler();

		public JavaCharArray(ref JniObjectReference handle, JniObjectReferenceOptions options)
			: base(ref handle, options)
		{
		}

		public unsafe JavaCharArray(int length)
			: base(ref *JavaObject.InvalidJniObjectReference, JniObjectReferenceOptions.None)
		{
			JniObjectReference reference = JniEnvironment.Arrays.NewCharArray(JavaArray<char>.CheckLength(length));
			Construct(ref reference, JniObjectReferenceOptions.CopyAndDispose);
		}

		public JavaCharArray(IList<char> value)
			: this(JavaArray<char>.CheckLength(value))
		{
			CopyFrom(JavaPrimitiveArray<char>.ToArray(value), 0, 0, value.Count);
		}

		public unsafe JniCharArrayElements GetElements()
		{
			if (!base.PeerReference.IsValid)
			{
				throw new ObjectDisposedException(GetType().FullName);
			}
			char* charArrayElements = JniEnvironment.Arrays.GetCharArrayElements(base.PeerReference, null);
			if (charArrayElements == null)
			{
				throw new InvalidOperationException("`JniEnvironment.Arrays.GetCharArrayElements()` returned NULL!");
			}
			return new JniCharArrayElements(base.PeerReference, charArrayElements, base.Length * 2);
		}

		public override int IndexOf(char item)
		{
			int length = base.Length;
			if (length == 0)
			{
				return -1;
			}
			using (JniCharArrayElements jniCharArrayElements = GetElements())
			{
				if (jniCharArrayElements == null)
				{
					return -1;
				}
				for (int i = 0; i < length; i++)
				{
					if (jniCharArrayElements[i] == item)
					{
						return i;
					}
				}
			}
			return -1;
		}

		public override void Clear()
		{
			int length = base.Length;
			using JniCharArrayElements jniCharArrayElements = GetElements();
			for (int i = 0; i < length; i++)
			{
				jniCharArrayElements[i] = '\0';
			}
		}

		public unsafe override void CopyTo(int sourceIndex, char[] destinationArray, int destinationIndex, int length)
		{
			if (destinationArray == null)
			{
				throw new ArgumentNullException("destinationArray");
			}
			JavaArray<char>.CheckArrayCopy(sourceIndex, base.Length, destinationIndex, destinationArray.Length, length);
			if (destinationArray.Length != 0)
			{
				fixed (char* ptr = destinationArray)
				{
					JniEnvironment.Arrays.GetCharArrayRegion(base.PeerReference, sourceIndex, length, ptr + destinationIndex);
				}
			}
		}

		public unsafe override void CopyFrom(char[] sourceArray, int sourceIndex, int destinationIndex, int length)
		{
			if (sourceArray == null)
			{
				throw new ArgumentNullException("sourceArray");
			}
			JavaArray<char>.CheckArrayCopy(sourceIndex, sourceArray.Length, destinationIndex, base.Length, length);
			if (sourceArray.Length != 0)
			{
				fixed (char* ptr = sourceArray)
				{
					JniEnvironment.Arrays.SetCharArrayRegion(base.PeerReference, destinationIndex, length, ptr + sourceIndex);
				}
			}
		}

		internal override bool TargetTypeIsCurrentType(Type targetType)
		{
			if (!base.TargetTypeIsCurrentType(targetType) && !(typeof(JavaPrimitiveArray<char>) == targetType))
			{
				return typeof(JavaCharArray) == targetType;
			}
			return true;
		}
	}
	public sealed class JniInt16ArrayElements : JniArrayElements
	{
		private JniObjectReference arrayHandle;

		public new unsafe short* Elements => (short*)(void*)base.Elements;

		public unsafe ref short this[int index]
		{
			get
			{
				if (base.IsDisposed)
				{
					throw new ObjectDisposedException(GetType().FullName);
				}
				return ref Elements[index];
			}
		}

		internal unsafe JniInt16ArrayElements(JniObjectReference arrayHandle, short* elements, int size)
			: base((IntPtr)elements, size)
		{
			this.arrayHandle = arrayHandle;
		}

		protected unsafe override void Synchronize(JniReleaseArrayElementsMode releaseMode)
		{
			JniEnvironment.Arrays.ReleaseShortArrayElements(arrayHandle, Elements, releaseMode);
		}
	}
	[JniTypeSignature("S", ArrayRank = 1, IsKeyword = true)]
	public sealed class JavaInt16Array : JavaPrimitiveArray<short>
	{
		internal sealed class ValueMarshaler : JniValueMarshaler<IList<short>>
		{
			public override IList<short> CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
			{
				return JavaArray<short>.CreateValue(ref reference, options, targetType, delegate(ref JniObjectReference h, JniObjectReferenceOptions o)
				{
					return new JavaInt16Array(ref h, o);
				});
			}

			public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(IList<short> value, ParameterAttributes synchronize)
			{
				return JavaArray<short>.CreateArgumentState(value, synchronize, delegate(IList<short> list, bool copy)
				{
					JavaInt16Array obj = (copy ? new JavaInt16Array(list) : new JavaInt16Array(list.Count));
					obj.forMarshalCollection = true;
					return obj;
				});
			}

			public override void DestroyGenericArgumentState(IList<short> value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
			{
				JavaArray<short>.DestroyArgumentState<JavaInt16Array>(value, ref state, synchronize);
			}
		}

		internal static readonly ValueMarshaler ArrayMarshaler = new ValueMarshaler();

		public JavaInt16Array(ref JniObjectReference handle, JniObjectReferenceOptions options)
			: base(ref handle, options)
		{
		}

		public unsafe JavaInt16Array(int length)
			: base(ref *JavaObject.InvalidJniObjectReference, JniObjectReferenceOptions.None)
		{
			JniObjectReference reference = JniEnvironment.Arrays.NewShortArray(JavaArray<short>.CheckLength(length));
			Construct(ref reference, JniObjectReferenceOptions.CopyAndDispose);
		}

		public JavaInt16Array(IList<short> value)
			: this(JavaArray<short>.CheckLength(value))
		{
			CopyFrom(JavaPrimitiveArray<short>.ToArray(value), 0, 0, value.Count);
		}

		public unsafe JniInt16ArrayElements GetElements()
		{
			if (!base.PeerReference.IsValid)
			{
				throw new ObjectDisposedException(GetType().FullName);
			}
			short* shortArrayElements = JniEnvironment.Arrays.GetShortArrayElements(base.PeerReference, null);
			if (shortArrayElements == null)
			{
				throw new InvalidOperationException("`JniEnvironment.Arrays.GetShortArrayElements()` returned NULL!");
			}
			return new JniInt16ArrayElements(base.PeerReference, shortArrayElements, base.Length * 2);
		}

		public override int IndexOf(short item)
		{
			int length = base.Length;
			if (length == 0)
			{
				return -1;
			}
			using (JniInt16ArrayElements jniInt16ArrayElements = GetElements())
			{
				if (jniInt16ArrayElements == null)
				{
					return -1;
				}
				for (int i = 0; i < length; i++)
				{
					if (jniInt16ArrayElements[i] == item)
					{
						return i;
					}
				}
			}
			return -1;
		}

		public override void Clear()
		{
			int length = base.Length;
			using JniInt16ArrayElements jniInt16ArrayElements = GetElements();
			for (int i = 0; i < length; i++)
			{
				jniInt16ArrayElements[i] = 0;
			}
		}

		public unsafe override void CopyTo(int sourceIndex, short[] destinationArray, int destinationIndex, int length)
		{
			if (destinationArray == null)
			{
				throw new ArgumentNullException("destinationArray");
			}
			JavaArray<short>.CheckArrayCopy(sourceIndex, base.Length, destinationIndex, destinationArray.Length, length);
			if (destinationArray.Length != 0)
			{
				fixed (short* ptr = destinationArray)
				{
					JniEnvironment.Arrays.GetShortArrayRegion(base.PeerReference, sourceIndex, length, ptr + destinationIndex);
				}
			}
		}

		public unsafe override void CopyFrom(short[] sourceArray, int sourceIndex, int destinationIndex, int length)
		{
			if (sourceArray == null)
			{
				throw new ArgumentNullException("sourceArray");
			}
			JavaArray<short>.CheckArrayCopy(sourceIndex, sourceArray.Length, destinationIndex, base.Length, length);
			if (sourceArray.Length != 0)
			{
				fixed (short* ptr = sourceArray)
				{
					JniEnvironment.Arrays.SetShortArrayRegion(base.PeerReference, destinationIndex, length, ptr + sourceIndex);
				}
			}
		}

		internal override bool TargetTypeIsCurrentType(Type targetType)
		{
			if (!base.TargetTypeIsCurrentType(targetType) && !(typeof(JavaPrimitiveArray<short>) == targetType))
			{
				return typeof(JavaInt16Array) == targetType;
			}
			return true;
		}
	}
	public sealed class JniInt32ArrayElements : JniArrayElements
	{
		private JniObjectReference arrayHandle;

		public new unsafe int* Elements => (int*)(void*)base.Elements;

		public unsafe ref int this[int index]
		{
			get
			{
				if (base.IsDisposed)
				{
					throw new ObjectDisposedException(GetType().FullName);
				}
				return ref Elements[index];
			}
		}

		internal unsafe JniInt32ArrayElements(JniObjectReference arrayHandle, int* elements, int size)
			: base((IntPtr)elements, size)
		{
			this.arrayHandle = arrayHandle;
		}

		protected unsafe override void Synchronize(JniReleaseArrayElementsMode releaseMode)
		{
			JniEnvironment.Arrays.ReleaseIntArrayElements(arrayHandle, Elements, releaseMode);
		}
	}
	[JniTypeSignature("I", ArrayRank = 1, IsKeyword = true)]
	public sealed class JavaInt32Array : JavaPrimitiveArray<int>
	{
		internal sealed class ValueMarshaler : JniValueMarshaler<IList<int>>
		{
			public override IList<int> CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
			{
				return JavaArray<int>.CreateValue(ref reference, options, targetType, delegate(ref JniObjectReference h, JniObjectReferenceOptions o)
				{
					return new JavaInt32Array(ref h, o);
				});
			}

			public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(IList<int> value, ParameterAttributes synchronize)
			{
				return JavaArray<int>.CreateArgumentState(value, synchronize, delegate(IList<int> list, bool copy)
				{
					JavaInt32Array obj = (copy ? new JavaInt32Array(list) : new JavaInt32Array(list.Count));
					obj.forMarshalCollection = true;
					return obj;
				});
			}

			public override void DestroyGenericArgumentState(IList<int> value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
			{
				JavaArray<int>.DestroyArgumentState<JavaInt32Array>(value, ref state, synchronize);
			}
		}

		internal static readonly ValueMarshaler ArrayMarshaler = new ValueMarshaler();

		public JavaInt32Array(ref JniObjectReference handle, JniObjectReferenceOptions options)
			: base(ref handle, options)
		{
		}

		public unsafe JavaInt32Array(int length)
			: base(ref *JavaObject.InvalidJniObjectReference, JniObjectReferenceOptions.None)
		{
			JniObjectReference reference = JniEnvironment.Arrays.NewIntArray(JavaArray<int>.CheckLength(length));
			Construct(ref reference, JniObjectReferenceOptions.CopyAndDispose);
		}

		public JavaInt32Array(IList<int> value)
			: this(JavaArray<int>.CheckLength(value))
		{
			CopyFrom(JavaPrimitiveArray<int>.ToArray(value), 0, 0, value.Count);
		}

		public unsafe JniInt32ArrayElements GetElements()
		{
			if (!base.PeerReference.IsValid)
			{
				throw new ObjectDisposedException(GetType().FullName);
			}
			int* intArrayElements = JniEnvironment.Arrays.GetIntArrayElements(base.PeerReference, null);
			if (intArrayElements == null)
			{
				throw new InvalidOperationException("`JniEnvironment.Arrays.GetIntArrayElements()` returned NULL!");
			}
			return new JniInt32ArrayElements(base.PeerReference, intArrayElements, base.Length * 4);
		}

		public override int IndexOf(int item)
		{
			int length = base.Length;
			if (length == 0)
			{
				return -1;
			}
			using (JniInt32ArrayElements jniInt32ArrayElements = GetElements())
			{
				if (jniInt32ArrayElements == null)
				{
					return -1;
				}
				for (int i = 0; i < length; i++)
				{
					if (jniInt32ArrayElements[i] == item)
					{
						return i;
					}
				}
			}
			return -1;
		}

		public override void Clear()
		{
			int length = base.Length;
			using JniInt32ArrayElements jniInt32ArrayElements = GetElements();
			for (int i = 0; i < length; i++)
			{
				jniInt32ArrayElements[i] = 0;
			}
		}

		public unsafe override void CopyTo(int sourceIndex, int[] destinationArray, int destinationIndex, int length)
		{
			if (destinationArray == null)
			{
				throw new ArgumentNullException("destinationArray");
			}
			JavaArray<int>.CheckArrayCopy(sourceIndex, base.Length, destinationIndex, destinationArray.Length, length);
			if (destinationArray.Length != 0)
			{
				fixed (int* ptr = destinationArray)
				{
					JniEnvironment.Arrays.GetIntArrayRegion(base.PeerReference, sourceIndex, length, ptr + destinationIndex);
				}
			}
		}

		public unsafe override void CopyFrom(int[] sourceArray, int sourceIndex, int destinationIndex, int length)
		{
			if (sourceArray == null)
			{
				throw new ArgumentNullException("sourceArray");
			}
			JavaArray<int>.CheckArrayCopy(sourceIndex, sourceArray.Length, destinationIndex, base.Length, length);
			if (sourceArray.Length != 0)
			{
				fixed (int* ptr = sourceArray)
				{
					JniEnvironment.Arrays.SetIntArrayRegion(base.PeerReference, destinationIndex, length, ptr + sourceIndex);
				}
			}
		}

		internal override bool TargetTypeIsCurrentType(Type targetType)
		{
			if (!base.TargetTypeIsCurrentType(targetType) && !(typeof(JavaPrimitiveArray<int>) == targetType))
			{
				return typeof(JavaInt32Array) == targetType;
			}
			return true;
		}
	}
	public sealed class JniInt64ArrayElements : JniArrayElements
	{
		private JniObjectReference arrayHandle;

		public new unsafe long* Elements => (long*)(void*)base.Elements;

		public unsafe ref long this[int index]
		{
			get
			{
				if (base.IsDisposed)
				{
					throw new ObjectDisposedException(GetType().FullName);
				}
				return ref Elements[index];
			}
		}

		internal unsafe JniInt64ArrayElements(JniObjectReference arrayHandle, long* elements, int size)
			: base((IntPtr)elements, size)
		{
			this.arrayHandle = arrayHandle;
		}

		protected unsafe override void Synchronize(JniReleaseArrayElementsMode releaseMode)
		{
			JniEnvironment.Arrays.ReleaseLongArrayElements(arrayHandle, Elements, releaseMode);
		}
	}
	[JniTypeSignature("J", ArrayRank = 1, IsKeyword = true)]
	public sealed class JavaInt64Array : JavaPrimitiveArray<long>
	{
		internal sealed class ValueMarshaler : JniValueMarshaler<IList<long>>
		{
			public override IList<long> CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
			{
				return JavaArray<long>.CreateValue(ref reference, options, targetType, delegate(ref JniObjectReference h, JniObjectReferenceOptions o)
				{
					return new JavaInt64Array(ref h, o);
				});
			}

			public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(IList<long> value, ParameterAttributes synchronize)
			{
				return JavaArray<long>.CreateArgumentState(value, synchronize, delegate(IList<long> list, bool copy)
				{
					JavaInt64Array obj = (copy ? new JavaInt64Array(list) : new JavaInt64Array(list.Count));
					obj.forMarshalCollection = true;
					return obj;
				});
			}

			public override void DestroyGenericArgumentState(IList<long> value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
			{
				JavaArray<long>.DestroyArgumentState<JavaInt64Array>(value, ref state, synchronize);
			}
		}

		internal static readonly ValueMarshaler ArrayMarshaler = new ValueMarshaler();

		public JavaInt64Array(ref JniObjectReference handle, JniObjectReferenceOptions options)
			: base(ref handle, options)
		{
		}

		public unsafe JavaInt64Array(int length)
			: base(ref *JavaObject.InvalidJniObjectReference, JniObjectReferenceOptions.None)
		{
			JniObjectReference reference = JniEnvironment.Arrays.NewLongArray(JavaArray<long>.CheckLength(length));
			Construct(ref reference, JniObjectReferenceOptions.CopyAndDispose);
		}

		public JavaInt64Array(IList<long> value)
			: this(JavaArray<long>.CheckLength(value))
		{
			CopyFrom(JavaPrimitiveArray<long>.ToArray(value), 0, 0, value.Count);
		}

		public unsafe JniInt64ArrayElements GetElements()
		{
			if (!base.PeerReference.IsValid)
			{
				throw new ObjectDisposedException(GetType().FullName);
			}
			long* longArrayElements = JniEnvironment.Arrays.GetLongArrayElements(base.PeerReference, null);
			if (longArrayElements == null)
			{
				throw new InvalidOperationException("`JniEnvironment.Arrays.GetLongArrayElements()` returned NULL!");
			}
			return new JniInt64ArrayElements(base.PeerReference, longArrayElements, base.Length * 8);
		}

		public override int IndexOf(long item)
		{
			int length = base.Length;
			if (length == 0)
			{
				return -1;
			}
			using (JniInt64ArrayElements jniInt64ArrayElements = GetElements())
			{
				if (jniInt64ArrayElements == null)
				{
					return -1;
				}
				for (int i = 0; i < length; i++)
				{
					if (jniInt64ArrayElements[i] == item)
					{
						return i;
					}
				}
			}
			return -1;
		}

		public override void Clear()
		{
			int length = base.Length;
			using JniInt64ArrayElements jniInt64ArrayElements = GetElements();
			for (int i = 0; i < length; i++)
			{
				jniInt64ArrayElements[i] = 0L;
			}
		}

		public unsafe override void CopyTo(int sourceIndex, long[] destinationArray, int destinationIndex, int length)
		{
			if (destinationArray == null)
			{
				throw new ArgumentNullException("destinationArray");
			}
			JavaArray<long>.CheckArrayCopy(sourceIndex, base.Length, destinationIndex, destinationArray.Length, length);
			if (destinationArray.Length != 0)
			{
				fixed (long* ptr = destinationArray)
				{
					JniEnvironment.Arrays.GetLongArrayRegion(base.PeerReference, sourceIndex, length, ptr + destinationIndex);
				}
			}
		}

		public unsafe override void CopyFrom(long[] sourceArray, int sourceIndex, int destinationIndex, int length)
		{
			if (sourceArray == null)
			{
				throw new ArgumentNullException("sourceArray");
			}
			JavaArray<long>.CheckArrayCopy(sourceIndex, sourceArray.Length, destinationIndex, base.Length, length);
			if (sourceArray.Length != 0)
			{
				fixed (long* ptr = sourceArray)
				{
					JniEnvironment.Arrays.SetLongArrayRegion(base.PeerReference, destinationIndex, length, ptr + sourceIndex);
				}
			}
		}

		internal override bool TargetTypeIsCurrentType(Type targetType)
		{
			if (!base.TargetTypeIsCurrentType(targetType) && !(typeof(JavaPrimitiveArray<long>) == targetType))
			{
				return typeof(JavaInt64Array) == targetType;
			}
			return true;
		}
	}
	public sealed class JniSingleArrayElements : JniArrayElements
	{
		private JniObjectReference arrayHandle;

		public new unsafe float* Elements => (float*)(void*)base.Elements;

		public unsafe ref float this[int index]
		{
			get
			{
				if (base.IsDisposed)
				{
					throw new ObjectDisposedException(GetType().FullName);
				}
				return ref Elements[index];
			}
		}

		internal unsafe JniSingleArrayElements(JniObjectReference arrayHandle, float* elements, int size)
			: base((IntPtr)elements, size)
		{
			this.arrayHandle = arrayHandle;
		}

		protected unsafe override void Synchronize(JniReleaseArrayElementsMode releaseMode)
		{
			JniEnvironment.Arrays.ReleaseFloatArrayElements(arrayHandle, Elements, releaseMode);
		}
	}
	[JniTypeSignature("F", ArrayRank = 1, IsKeyword = true)]
	public sealed class JavaSingleArray : JavaPrimitiveArray<float>
	{
		internal sealed class ValueMarshaler : JniValueMarshaler<IList<float>>
		{
			public override IList<float> CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
			{
				return JavaArray<float>.CreateValue(ref reference, options, targetType, delegate(ref JniObjectReference h, JniObjectReferenceOptions o)
				{
					return new JavaSingleArray(ref h, o);
				});
			}

			public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(IList<float> value, ParameterAttributes synchronize)
			{
				return JavaArray<float>.CreateArgumentState(value, synchronize, delegate(IList<float> list, bool copy)
				{
					JavaSingleArray obj = (copy ? new JavaSingleArray(list) : new JavaSingleArray(list.Count));
					obj.forMarshalCollection = true;
					return obj;
				});
			}

			public override void DestroyGenericArgumentState(IList<float> value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
			{
				JavaArray<float>.DestroyArgumentState<JavaSingleArray>(value, ref state, synchronize);
			}
		}

		internal static readonly ValueMarshaler ArrayMarshaler = new ValueMarshaler();

		public JavaSingleArray(ref JniObjectReference handle, JniObjectReferenceOptions options)
			: base(ref handle, options)
		{
		}

		public unsafe JavaSingleArray(int length)
			: base(ref *JavaObject.InvalidJniObjectReference, JniObjectReferenceOptions.None)
		{
			JniObjectReference reference = JniEnvironment.Arrays.NewFloatArray(JavaArray<float>.CheckLength(length));
			Construct(ref reference, JniObjectReferenceOptions.CopyAndDispose);
		}

		public JavaSingleArray(IList<float> value)
			: this(JavaArray<float>.CheckLength(value))
		{
			CopyFrom(JavaPrimitiveArray<float>.ToArray(value), 0, 0, value.Count);
		}

		public unsafe JniSingleArrayElements GetElements()
		{
			if (!base.PeerReference.IsValid)
			{
				throw new ObjectDisposedException(GetType().FullName);
			}
			float* floatArrayElements = JniEnvironment.Arrays.GetFloatArrayElements(base.PeerReference, null);
			if (floatArrayElements == null)
			{
				throw new InvalidOperationException("`JniEnvironment.Arrays.GetFloatArrayElements()` returned NULL!");
			}
			return new JniSingleArrayElements(base.PeerReference, floatArrayElements, base.Length * 4);
		}

		public override int IndexOf(float item)
		{
			int length = base.Length;
			if (length == 0)
			{
				return -1;
			}
			using (JniSingleArrayElements jniSingleArrayElements = GetElements())
			{
				if (jniSingleArrayElements == null)
				{
					return -1;
				}
				for (int i = 0; i < length; i++)
				{
					if (jniSingleArrayElements[i] == item)
					{
						return i;
					}
				}
			}
			return -1;
		}

		public override void Clear()
		{
			int length = base.Length;
			using JniSingleArrayElements jniSingleArrayElements = GetElements();
			for (int i = 0; i < length; i++)
			{
				jniSingleArrayElements[i] = 0f;
			}
		}

		public unsafe override void CopyTo(int sourceIndex, float[] destinationArray, int destinationIndex, int length)
		{
			if (destinationArray == null)
			{
				throw new ArgumentNullException("destinationArray");
			}
			JavaArray<float>.CheckArrayCopy(sourceIndex, base.Length, destinationIndex, destinationArray.Length, length);
			if (destinationArray.Length != 0)
			{
				fixed (float* ptr = destinationArray)
				{
					JniEnvironment.Arrays.GetFloatArrayRegion(base.PeerReference, sourceIndex, length, ptr + destinationIndex);
				}
			}
		}

		public unsafe override void CopyFrom(float[] sourceArray, int sourceIndex, int destinationIndex, int length)
		{
			if (sourceArray == null)
			{
				throw new ArgumentNullException("sourceArray");
			}
			JavaArray<float>.CheckArrayCopy(sourceIndex, sourceArray.Length, destinationIndex, base.Length, length);
			if (sourceArray.Length != 0)
			{
				fixed (float* ptr = sourceArray)
				{
					JniEnvironment.Arrays.SetFloatArrayRegion(base.PeerReference, destinationIndex, length, ptr + sourceIndex);
				}
			}
		}

		internal override bool TargetTypeIsCurrentType(Type targetType)
		{
			if (!base.TargetTypeIsCurrentType(targetType) && !(typeof(JavaPrimitiveArray<float>) == targetType))
			{
				return typeof(JavaSingleArray) == targetType;
			}
			return true;
		}
	}
	public sealed class JniDoubleArrayElements : JniArrayElements
	{
		private JniObjectReference arrayHandle;

		public new unsafe double* Elements => (double*)(void*)base.Elements;

		public unsafe ref double this[int index]
		{
			get
			{
				if (base.IsDisposed)
				{
					throw new ObjectDisposedException(GetType().FullName);
				}
				return ref Elements[index];
			}
		}

		internal unsafe JniDoubleArrayElements(JniObjectReference arrayHandle, double* elements, int size)
			: base((IntPtr)elements, size)
		{
			this.arrayHandle = arrayHandle;
		}

		protected unsafe override void Synchronize(JniReleaseArrayElementsMode releaseMode)
		{
			JniEnvironment.Arrays.ReleaseDoubleArrayElements(arrayHandle, Elements, releaseMode);
		}
	}
	[JniTypeSignature("D", ArrayRank = 1, IsKeyword = true)]
	public sealed class JavaDoubleArray : JavaPrimitiveArray<double>
	{
		internal sealed class ValueMarshaler : JniValueMarshaler<IList<double>>
		{
			public override IList<double> CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
			{
				return JavaArray<double>.CreateValue(ref reference, options, targetType, delegate(ref JniObjectReference h, JniObjectReferenceOptions o)
				{
					return new JavaDoubleArray(ref h, o);
				});
			}

			public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(IList<double> value, ParameterAttributes synchronize)
			{
				return JavaArray<double>.CreateArgumentState(value, synchronize, delegate(IList<double> list, bool copy)
				{
					JavaDoubleArray obj = (copy ? new JavaDoubleArray(list) : new JavaDoubleArray(list.Count));
					obj.forMarshalCollection = true;
					return obj;
				});
			}

			public override void DestroyGenericArgumentState(IList<double> value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
			{
				JavaArray<double>.DestroyArgumentState<JavaDoubleArray>(value, ref state, synchronize);
			}
		}

		internal static readonly ValueMarshaler ArrayMarshaler = new ValueMarshaler();

		public JavaDoubleArray(ref JniObjectReference handle, JniObjectReferenceOptions options)
			: base(ref handle, options)
		{
		}

		public unsafe JavaDoubleArray(int length)
			: base(ref *JavaObject.InvalidJniObjectReference, JniObjectReferenceOptions.None)
		{
			JniObjectReference reference = JniEnvironment.Arrays.NewDoubleArray(JavaArray<double>.CheckLength(length));
			Construct(ref reference, JniObjectReferenceOptions.CopyAndDispose);
		}

		public JavaDoubleArray(IList<double> value)
			: this(JavaArray<double>.CheckLength(value))
		{
			CopyFrom(JavaPrimitiveArray<double>.ToArray(value), 0, 0, value.Count);
		}

		public unsafe JniDoubleArrayElements GetElements()
		{
			if (!base.PeerReference.IsValid)
			{
				throw new ObjectDisposedException(GetType().FullName);
			}
			double* doubleArrayElements = JniEnvironment.Arrays.GetDoubleArrayElements(base.PeerReference, null);
			if (doubleArrayElements == null)
			{
				throw new InvalidOperationException("`JniEnvironment.Arrays.GetDoubleArrayElements()` returned NULL!");
			}
			return new JniDoubleArrayElements(base.PeerReference, doubleArrayElements, base.Length * 8);
		}

		public override int IndexOf(double item)
		{
			int length = base.Length;
			if (length == 0)
			{
				return -1;
			}
			using (JniDoubleArrayElements jniDoubleArrayElements = GetElements())
			{
				if (jniDoubleArrayElements == null)
				{
					return -1;
				}
				for (int i = 0; i < length; i++)
				{
					if (jniDoubleArrayElements[i] == item)
					{
						return i;
					}
				}
			}
			return -1;
		}

		public override void Clear()
		{
			int length = base.Length;
			using JniDoubleArrayElements jniDoubleArrayElements = GetElements();
			for (int i = 0; i < length; i++)
			{
				jniDoubleArrayElements[i] = 0.0;
			}
		}

		public unsafe override void CopyTo(int sourceIndex, double[] destinationArray, int destinationIndex, int length)
		{
			if (destinationArray == null)
			{
				throw new ArgumentNullException("destinationArray");
			}
			JavaArray<double>.CheckArrayCopy(sourceIndex, base.Length, destinationIndex, destinationArray.Length, length);
			if (destinationArray.Length != 0)
			{
				fixed (double* ptr = destinationArray)
				{
					JniEnvironment.Arrays.GetDoubleArrayRegion(base.PeerReference, sourceIndex, length, ptr + destinationIndex);
				}
			}
		}

		public unsafe override void CopyFrom(double[] sourceArray, int sourceIndex, int destinationIndex, int length)
		{
			if (sourceArray == null)
			{
				throw new ArgumentNullException("sourceArray");
			}
			JavaArray<double>.CheckArrayCopy(sourceIndex, sourceArray.Length, destinationIndex, base.Length, length);
			if (sourceArray.Length != 0)
			{
				fixed (double* ptr = sourceArray)
				{
					JniEnvironment.Arrays.SetDoubleArrayRegion(base.PeerReference, destinationIndex, length, ptr + sourceIndex);
				}
			}
		}

		internal override bool TargetTypeIsCurrentType(Type targetType)
		{
			if (!base.TargetTypeIsCurrentType(targetType) && !(typeof(JavaPrimitiveArray<double>) == targetType))
			{
				return typeof(JavaDoubleArray) == targetType;
			}
			return true;
		}
	}
	[JniTypeSignature("com/xamarin/java_interop/internal/JavaProxyObject")]
	internal sealed class JavaProxyObject : JavaObject, IEquatable<JavaProxyObject>
	{
		private static readonly JniPeerMembers _members = new JniPeerMembers("com/xamarin/java_interop/internal/JavaProxyObject", typeof(JavaProxyObject));

		private static readonly ConditionalWeakTable<object, JavaProxyObject> CachedValues = new ConditionalWeakTable<object, JavaProxyObject>();

		public override JniPeerMembers JniPeerMembers => _members;

		public object Value { get; private set; }

		private JavaProxyObject(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			Value = value;
		}

		public override int GetHashCode()
		{
			return Value.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			if (obj is JavaProxyObject javaProxyObject)
			{
				return object.Equals(Value, javaProxyObject.Value);
			}
			return object.Equals(Value, obj);
		}

		public bool Equals(JavaProxyObject other)
		{
			return object.Equals(Value, other?.Value);
		}

		public override string ToString()
		{
			return Value.ToString();
		}

		public static JavaProxyObject GetProxy(object value)
		{
			if (value == null)
			{
				return null;
			}
			lock (CachedValues)
			{
				if (CachedValues.TryGetValue(value, out var value2))
				{
					return value2;
				}
				value2 = new JavaProxyObject(value);
				CachedValues.Add(value, value2);
				return value2;
			}
		}
	}
	[JniTypeSignature("com/xamarin/java_interop/internal/JavaProxyThrowable")]
	internal sealed class JavaProxyThrowable : JavaException
	{
		public Exception Exception { get; private set; }

		public JavaProxyThrowable(Exception exception)
			: base(GetMessage(exception))
		{
			Exception = exception;
		}

		private static string GetMessage(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			return exception.ToString();
		}
	}
	[AttributeUsage(AttributeTargets.Method)]
	public sealed class JniAddNativeMethodRegistrationAttribute : Attribute
	{
	}
	[StructLayout(LayoutKind.Explicit)]
	public struct JniArgumentValue : IEquatable<JniArgumentValue>
	{
		[FieldOffset(0)]
		private bool z;

		[FieldOffset(0)]
		private sbyte b;

		[FieldOffset(0)]
		private char c;

		[FieldOffset(0)]
		private short s;

		[FieldOffset(0)]
		private int i;

		[FieldOffset(0)]
		private long j;

		[FieldOffset(0)]
		private float f;

		[FieldOffset(0)]
		private double d;

		[FieldOffset(0)]
		private IntPtr l;

		public JniArgumentValue(bool value)
		{
			this = default(JniArgumentValue);
			z = value;
		}

		public JniArgumentValue(sbyte value)
		{
			this = default(JniArgumentValue);
			b = value;
		}

		public JniArgumentValue(byte value)
			: this((sbyte)value)
		{
		}

		public JniArgumentValue(char value)
		{
			this = default(JniArgumentValue);
			c = value;
		}

		public JniArgumentValue(short value)
		{
			this = default(JniArgumentValue);
			s = value;
		}

		public JniArgumentValue(ushort value)
			: this((short)value)
		{
		}

		public JniArgumentValue(int value)
		{
			this = default(JniArgumentValue);
			i = value;
		}

		public JniArgumentValue(uint value)
			: this((int)value)
		{
		}

		public JniArgumentValue(long value)
		{
			this = default(JniArgumentValue);
			j = value;
		}

		public JniArgumentValue(ulong value)
			: this((long)value)
		{
		}

		public JniArgumentValue(float value)
		{
			this = default(JniArgumentValue);
			f = value;
		}

		public JniArgumentValue(double value)
		{
			this = default(JniArgumentValue);
			d = value;
		}

		public JniArgumentValue(IntPtr value)
		{
			this = default(JniArgumentValue);
			l = value;
		}

		public JniArgumentValue(JniObjectReference value)
		{
			this = default(JniArgumentValue);
			l = value.Handle;
		}

		public JniArgumentValue(IJavaPeerable value)
		{
			this = default(JniArgumentValue);
			if (value != null)
			{
				l = value.PeerReference.Handle;
			}
			else
			{
				l = IntPtr.Zero;
			}
		}

		public override int GetHashCode()
		{
			return j.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			JniArgumentValue? jniArgumentValue = obj as JniArgumentValue?;
			if (!jniArgumentValue.HasValue)
			{
				return false;
			}
			return Equals(jniArgumentValue.Value);
		}

		public bool Equals(JniArgumentValue other)
		{
			return j == other.j;
		}

		public override string ToString()
		{
			return string.Format("JniArgumentValue(z={0},b={1},c={2},s={3},i={4},j={5},f={6},d={7},l=0x{8})", z, b, c, s, i, j, f, d, l.ToString("x"));
		}
	}
	internal static class JniBoolean
	{
		private static JniType _TypeRef;

		private static JniMethodInfo init;

		private static JniMethodInfo booleanValue;

		private static JniType TypeRef => JniType.GetCachedJniType(ref _TypeRef, "java/lang/Boolean");

		internal unsafe static JniObjectReference CreateLocalRef(bool value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			TypeRef.GetCachedConstructor(ref init, "(Z)V");
			return TypeRef.NewObject(init, ptr);
		}

		internal static bool GetValueFromJni(ref JniObjectReference self, JniObjectReferenceOptions transfer, Type targetType)
		{
			TypeRef.GetCachedInstanceMethod(ref booleanValue, "booleanValue", "()Z");
			try
			{
				return JniEnvironment.InstanceMethods.CallBooleanMethod(self, booleanValue);
			}
			finally
			{
				JniObjectReference.Dispose(ref self, transfer);
			}
		}
	}
	internal sealed class JniBooleanValueMarshaler : JniValueMarshaler<bool>
	{
		internal static readonly JniBooleanValueMarshaler Instance = new JniBooleanValueMarshaler();

		public override object CreateValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return null;
			}
			return CreateGenericValue(ref reference, options, targetType);
		}

		public override bool CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return false;
			}
			return JniBoolean.GetValueFromJni(ref reference, options, targetType);
		}

		public override JniValueMarshalerState CreateGenericArgumentState(bool value, ParameterAttributes synchronize = ParameterAttributes.In)
		{
			return new JniValueMarshalerState(new JniArgumentValue(value));
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(bool value, ParameterAttributes synchronize)
		{
			return new JniValueMarshalerState(JniBoolean.CreateLocalRef(value));
		}

		public override void DestroyArgumentState(object value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}

		public override void DestroyGenericArgumentState(bool value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}
	}
	internal sealed class JniNullableBooleanValueMarshaler : JniValueMarshaler<bool?>
	{
		internal static readonly JniNullableBooleanValueMarshaler Instance = new JniNullableBooleanValueMarshaler();

		public override bool? CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return null;
			}
			return JniBoolean.GetValueFromJni(ref reference, options, null);
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(bool? value, ParameterAttributes synchronize)
		{
			if (!value.HasValue)
			{
				return default(JniValueMarshalerState);
			}
			return new JniValueMarshalerState(JniBoolean.CreateLocalRef(value.Value));
		}

		public override void DestroyGenericArgumentState(bool? value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}
	}
	internal static class JniByte
	{
		private static JniType _TypeRef;

		private static JniMethodInfo init;

		private static JniMethodInfo byteValue;

		private static JniType TypeRef => JniType.GetCachedJniType(ref _TypeRef, "java/lang/Byte");

		internal unsafe static JniObjectReference CreateLocalRef(sbyte value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			TypeRef.GetCachedConstructor(ref init, "(B)V");
			return TypeRef.NewObject(init, ptr);
		}

		internal static sbyte GetValueFromJni(ref JniObjectReference self, JniObjectReferenceOptions transfer, Type targetType)
		{
			TypeRef.GetCachedInstanceMethod(ref byteValue, "byteValue", "()B");
			try
			{
				return JniEnvironment.InstanceMethods.CallByteMethod(self, byteValue);
			}
			finally
			{
				JniObjectReference.Dispose(ref self, transfer);
			}
		}
	}
	internal sealed class JniSByteValueMarshaler : JniValueMarshaler<sbyte>
	{
		internal static readonly JniSByteValueMarshaler Instance = new JniSByteValueMarshaler();

		public override object CreateValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return null;
			}
			return CreateGenericValue(ref reference, options, targetType);
		}

		public override sbyte CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return 0;
			}
			return JniByte.GetValueFromJni(ref reference, options, targetType);
		}

		public override JniValueMarshalerState CreateGenericArgumentState(sbyte value, ParameterAttributes synchronize = ParameterAttributes.In)
		{
			return new JniValueMarshalerState(new JniArgumentValue(value));
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(sbyte value, ParameterAttributes synchronize)
		{
			return new JniValueMarshalerState(JniByte.CreateLocalRef(value));
		}

		public override void DestroyArgumentState(object value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}

		public override void DestroyGenericArgumentState(sbyte value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}
	}
	internal sealed class JniNullableSByteValueMarshaler : JniValueMarshaler<sbyte?>
	{
		internal static readonly JniNullableSByteValueMarshaler Instance = new JniNullableSByteValueMarshaler();

		public override sbyte? CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return null;
			}
			return JniByte.GetValueFromJni(ref reference, options, null);
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(sbyte? value, ParameterAttributes synchronize)
		{
			if (!value.HasValue)
			{
				return default(JniValueMarshalerState);
			}
			return new JniValueMarshalerState(JniByte.CreateLocalRef(value.Value));
		}

		public override void DestroyGenericArgumentState(sbyte? value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}
	}
	internal static class JniCharacter
	{
		private static JniType _TypeRef;

		private static JniMethodInfo init;

		private static JniMethodInfo charValue;

		private static JniType TypeRef => JniType.GetCachedJniType(ref _TypeRef, "java/lang/Character");

		internal unsafe static JniObjectReference CreateLocalRef(char value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			TypeRef.GetCachedConstructor(ref init, "(C)V");
			return TypeRef.NewObject(init, ptr);
		}

		internal static char GetValueFromJni(ref JniObjectReference self, JniObjectReferenceOptions transfer, Type targetType)
		{
			TypeRef.GetCachedInstanceMethod(ref charValue, "charValue", "()C");
			try
			{
				return JniEnvironment.InstanceMethods.CallCharMethod(self, charValue);
			}
			finally
			{
				JniObjectReference.Dispose(ref self, transfer);
			}
		}
	}
	internal sealed class JniCharValueMarshaler : JniValueMarshaler<char>
	{
		internal static readonly JniCharValueMarshaler Instance = new JniCharValueMarshaler();

		public override object CreateValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return null;
			}
			return CreateGenericValue(ref reference, options, targetType);
		}

		public override char CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return '\0';
			}
			return JniCharacter.GetValueFromJni(ref reference, options, targetType);
		}

		public override JniValueMarshalerState CreateGenericArgumentState(char value, ParameterAttributes synchronize = ParameterAttributes.In)
		{
			return new JniValueMarshalerState(new JniArgumentValue(value));
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(char value, ParameterAttributes synchronize)
		{
			return new JniValueMarshalerState(JniCharacter.CreateLocalRef(value));
		}

		public override void DestroyArgumentState(object value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}

		public override void DestroyGenericArgumentState(char value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}
	}
	internal sealed class JniNullableCharValueMarshaler : JniValueMarshaler<char?>
	{
		internal static readonly JniNullableCharValueMarshaler Instance = new JniNullableCharValueMarshaler();

		public override char? CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return null;
			}
			return JniCharacter.GetValueFromJni(ref reference, options, null);
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(char? value, ParameterAttributes synchronize)
		{
			if (!value.HasValue)
			{
				return default(JniValueMarshalerState);
			}
			return new JniValueMarshalerState(JniCharacter.CreateLocalRef(value.Value));
		}

		public override void DestroyGenericArgumentState(char? value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}
	}
	internal static class JniShort
	{
		private static JniType _TypeRef;

		private static JniMethodInfo init;

		private static JniMethodInfo shortValue;

		private static JniType TypeRef => JniType.GetCachedJniType(ref _TypeRef, "java/lang/Short");

		internal unsafe static JniObjectReference CreateLocalRef(short value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			TypeRef.GetCachedConstructor(ref init, "(S)V");
			return TypeRef.NewObject(init, ptr);
		}

		internal static short GetValueFromJni(ref JniObjectReference self, JniObjectReferenceOptions transfer, Type targetType)
		{
			TypeRef.GetCachedInstanceMethod(ref shortValue, "shortValue", "()S");
			try
			{
				return JniEnvironment.InstanceMethods.CallShortMethod(self, shortValue);
			}
			finally
			{
				JniObjectReference.Dispose(ref self, transfer);
			}
		}
	}
	internal sealed class JniInt16ValueMarshaler : JniValueMarshaler<short>
	{
		internal static readonly JniInt16ValueMarshaler Instance = new JniInt16ValueMarshaler();

		public override object CreateValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return null;
			}
			return CreateGenericValue(ref reference, options, targetType);
		}

		public override short CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return 0;
			}
			return JniShort.GetValueFromJni(ref reference, options, targetType);
		}

		public override JniValueMarshalerState CreateGenericArgumentState(short value, ParameterAttributes synchronize = ParameterAttributes.In)
		{
			return new JniValueMarshalerState(new JniArgumentValue(value));
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(short value, ParameterAttributes synchronize)
		{
			return new JniValueMarshalerState(JniShort.CreateLocalRef(value));
		}

		public override void DestroyArgumentState(object value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}

		public override void DestroyGenericArgumentState(short value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}
	}
	internal sealed class JniNullableInt16ValueMarshaler : JniValueMarshaler<short?>
	{
		internal static readonly JniNullableInt16ValueMarshaler Instance = new JniNullableInt16ValueMarshaler();

		public override short? CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return null;
			}
			return JniShort.GetValueFromJni(ref reference, options, null);
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(short? value, ParameterAttributes synchronize)
		{
			if (!value.HasValue)
			{
				return default(JniValueMarshalerState);
			}
			return new JniValueMarshalerState(JniShort.CreateLocalRef(value.Value));
		}

		public override void DestroyGenericArgumentState(short? value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}
	}
	internal static class JniInteger
	{
		private static JniType _TypeRef;

		private static JniMethodInfo init;

		private static JniMethodInfo intValue;

		private static JniType TypeRef => JniType.GetCachedJniType(ref _TypeRef, "java/lang/Integer");

		internal unsafe static JniObjectReference CreateLocalRef(int value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			TypeRef.GetCachedConstructor(ref init, "(I)V");
			return TypeRef.NewObject(init, ptr);
		}

		internal static int GetValueFromJni(ref JniObjectReference self, JniObjectReferenceOptions transfer, Type targetType)
		{
			TypeRef.GetCachedInstanceMethod(ref intValue, "intValue", "()I");
			try
			{
				return JniEnvironment.InstanceMethods.CallIntMethod(self, intValue);
			}
			finally
			{
				JniObjectReference.Dispose(ref self, transfer);
			}
		}
	}
	internal sealed class JniInt32ValueMarshaler : JniValueMarshaler<int>
	{
		internal static readonly JniInt32ValueMarshaler Instance = new JniInt32ValueMarshaler();

		public override object CreateValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return null;
			}
			return CreateGenericValue(ref reference, options, targetType);
		}

		public override int CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return 0;
			}
			return JniInteger.GetValueFromJni(ref reference, options, targetType);
		}

		public override JniValueMarshalerState CreateGenericArgumentState(int value, ParameterAttributes synchronize = ParameterAttributes.In)
		{
			return new JniValueMarshalerState(new JniArgumentValue(value));
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(int value, ParameterAttributes synchronize)
		{
			return new JniValueMarshalerState(JniInteger.CreateLocalRef(value));
		}

		public override void DestroyArgumentState(object value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}

		public override void DestroyGenericArgumentState(int value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}
	}
	internal sealed class JniNullableInt32ValueMarshaler : JniValueMarshaler<int?>
	{
		internal static readonly JniNullableInt32ValueMarshaler Instance = new JniNullableInt32ValueMarshaler();

		public override int? CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return null;
			}
			return JniInteger.GetValueFromJni(ref reference, options, null);
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(int? value, ParameterAttributes synchronize)
		{
			if (!value.HasValue)
			{
				return default(JniValueMarshalerState);
			}
			return new JniValueMarshalerState(JniInteger.CreateLocalRef(value.Value));
		}

		public override void DestroyGenericArgumentState(int? value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}
	}
	internal static class JniLong
	{
		private static JniType _TypeRef;

		private static JniMethodInfo init;

		private static JniMethodInfo longValue;

		private static JniType TypeRef => JniType.GetCachedJniType(ref _TypeRef, "java/lang/Long");

		internal unsafe static JniObjectReference CreateLocalRef(long value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			TypeRef.GetCachedConstructor(ref init, "(J)V");
			return TypeRef.NewObject(init, ptr);
		}

		internal static long GetValueFromJni(ref JniObjectReference self, JniObjectReferenceOptions transfer, Type targetType)
		{
			TypeRef.GetCachedInstanceMethod(ref longValue, "longValue", "()J");
			try
			{
				return JniEnvironment.InstanceMethods.CallLongMethod(self, longValue);
			}
			finally
			{
				JniObjectReference.Dispose(ref self, transfer);
			}
		}
	}
	internal sealed class JniInt64ValueMarshaler : JniValueMarshaler<long>
	{
		internal static readonly JniInt64ValueMarshaler Instance = new JniInt64ValueMarshaler();

		public override object CreateValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return null;
			}
			return CreateGenericValue(ref reference, options, targetType);
		}

		public override long CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return 0L;
			}
			return JniLong.GetValueFromJni(ref reference, options, targetType);
		}

		public override JniValueMarshalerState CreateGenericArgumentState(long value, ParameterAttributes synchronize = ParameterAttributes.In)
		{
			return new JniValueMarshalerState(new JniArgumentValue(value));
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(long value, ParameterAttributes synchronize)
		{
			return new JniValueMarshalerState(JniLong.CreateLocalRef(value));
		}

		public override void DestroyArgumentState(object value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}

		public override void DestroyGenericArgumentState(long value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}
	}
	internal sealed class JniNullableInt64ValueMarshaler : JniValueMarshaler<long?>
	{
		internal static readonly JniNullableInt64ValueMarshaler Instance = new JniNullableInt64ValueMarshaler();

		public override long? CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return null;
			}
			return JniLong.GetValueFromJni(ref reference, options, null);
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(long? value, ParameterAttributes synchronize)
		{
			if (!value.HasValue)
			{
				return default(JniValueMarshalerState);
			}
			return new JniValueMarshalerState(JniLong.CreateLocalRef(value.Value));
		}

		public override void DestroyGenericArgumentState(long? value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}
	}
	internal static class JniFloat
	{
		private static JniType _TypeRef;

		private static JniMethodInfo init;

		private static JniMethodInfo floatValue;

		private static JniType TypeRef => JniType.GetCachedJniType(ref _TypeRef, "java/lang/Float");

		internal unsafe static JniObjectReference CreateLocalRef(float value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			TypeRef.GetCachedConstructor(ref init, "(F)V");
			return TypeRef.NewObject(init, ptr);
		}

		internal static float GetValueFromJni(ref JniObjectReference self, JniObjectReferenceOptions transfer, Type targetType)
		{
			TypeRef.GetCachedInstanceMethod(ref floatValue, "floatValue", "()F");
			try
			{
				return JniEnvironment.InstanceMethods.CallFloatMethod(self, floatValue);
			}
			finally
			{
				JniObjectReference.Dispose(ref self, transfer);
			}
		}
	}
	internal sealed class JniSingleValueMarshaler : JniValueMarshaler<float>
	{
		internal static readonly JniSingleValueMarshaler Instance = new JniSingleValueMarshaler();

		public override object CreateValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return null;
			}
			return CreateGenericValue(ref reference, options, targetType);
		}

		public override float CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return 0f;
			}
			return JniFloat.GetValueFromJni(ref reference, options, targetType);
		}

		public override JniValueMarshalerState CreateGenericArgumentState(float value, ParameterAttributes synchronize = ParameterAttributes.In)
		{
			return new JniValueMarshalerState(new JniArgumentValue(value));
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(float value, ParameterAttributes synchronize)
		{
			return new JniValueMarshalerState(JniFloat.CreateLocalRef(value));
		}

		public override void DestroyArgumentState(object value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}

		public override void DestroyGenericArgumentState(float value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}
	}
	internal sealed class JniNullableSingleValueMarshaler : JniValueMarshaler<float?>
	{
		internal static readonly JniNullableSingleValueMarshaler Instance = new JniNullableSingleValueMarshaler();

		public override float? CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return null;
			}
			return JniFloat.GetValueFromJni(ref reference, options, null);
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(float? value, ParameterAttributes synchronize)
		{
			if (!value.HasValue)
			{
				return default(JniValueMarshalerState);
			}
			return new JniValueMarshalerState(JniFloat.CreateLocalRef(value.Value));
		}

		public override void DestroyGenericArgumentState(float? value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}
	}
	internal static class JniDouble
	{
		private static JniType _TypeRef;

		private static JniMethodInfo init;

		private static JniMethodInfo doubleValue;

		private static JniType TypeRef => JniType.GetCachedJniType(ref _TypeRef, "java/lang/Double");

		internal unsafe static JniObjectReference CreateLocalRef(double value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			TypeRef.GetCachedConstructor(ref init, "(D)V");
			return TypeRef.NewObject(init, ptr);
		}

		internal static double GetValueFromJni(ref JniObjectReference self, JniObjectReferenceOptions transfer, Type targetType)
		{
			TypeRef.GetCachedInstanceMethod(ref doubleValue, "doubleValue", "()D");
			try
			{
				return JniEnvironment.InstanceMethods.CallDoubleMethod(self, doubleValue);
			}
			finally
			{
				JniObjectReference.Dispose(ref self, transfer);
			}
		}
	}
	internal sealed class JniDoubleValueMarshaler : JniValueMarshaler<double>
	{
		internal static readonly JniDoubleValueMarshaler Instance = new JniDoubleValueMarshaler();

		public override object CreateValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return null;
			}
			return CreateGenericValue(ref reference, options, targetType);
		}

		public override double CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return 0.0;
			}
			return JniDouble.GetValueFromJni(ref reference, options, targetType);
		}

		public override JniValueMarshalerState CreateGenericArgumentState(double value, ParameterAttributes synchronize = ParameterAttributes.In)
		{
			return new JniValueMarshalerState(new JniArgumentValue(value));
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(double value, ParameterAttributes synchronize)
		{
			return new JniValueMarshalerState(JniDouble.CreateLocalRef(value));
		}

		public override void DestroyArgumentState(object value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}

		public override void DestroyGenericArgumentState(double value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}
	}
	internal sealed class JniNullableDoubleValueMarshaler : JniValueMarshaler<double?>
	{
		internal static readonly JniNullableDoubleValueMarshaler Instance = new JniNullableDoubleValueMarshaler();

		public override double? CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			if (!reference.IsValid)
			{
				return null;
			}
			return JniDouble.GetValueFromJni(ref reference, options, null);
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(double? value, ParameterAttributes synchronize)
		{
			if (!value.HasValue)
			{
				return default(JniValueMarshalerState);
			}
			return new JniValueMarshalerState(JniDouble.CreateLocalRef(value.Value));
		}

		public override void DestroyGenericArgumentState(double? value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}
	}
	internal sealed class JniEnvironmentInfo : IDisposable
	{
		private IntPtr environmentPointer;

		private char[] nameBuffer;

		private bool disposed;

		private JniRuntime runtime;

		public int LocalReferenceCount { get; internal set; }

		public bool WithinNewObjectScope { get; set; }

		public JniRuntime Runtime
		{
			get
			{
				return runtime ?? throw new NotSupportedException();
			}
			private set
			{
				runtime = value;
			}
		}

		public IntPtr EnvironmentPointer
		{
			get
			{
				return environmentPointer;
			}
			set
			{
				if (disposed)
				{
					throw new ObjectDisposedException("JniEnvironmentInfo");
				}
				if (!(environmentPointer == value))
				{
					environmentPointer = value;
					IntPtr vm = IntPtr.Zero;
					int javaVM = JniEnvironment.References.GetJavaVM(EnvironmentPointer, out vm);
					if (javaVM < 0)
					{
						throw new InvalidOperationException("JNIEnv::GetJavaVM() returned: " + javaVM);
					}
					JniRuntime registeredRuntime = JniRuntime.GetRegisteredRuntime(vm);
					if (registeredRuntime == null)
					{
						throw new NotSupportedException(string.Format("No JavaVM registered with handle 0x{0}.", vm.ToString("x")));
					}
					Runtime = registeredRuntime;
				}
			}
		}

		public bool IsValid
		{
			get
			{
				if (Runtime != null)
				{
					return environmentPointer != IntPtr.Zero;
				}
				return false;
			}
		}

		public JniEnvironmentInfo()
		{
			Runtime = JniRuntime.CurrentRuntime;
			EnvironmentPointer = Runtime._AttachCurrentThread();
		}

		internal JniEnvironmentInfo(IntPtr environmentPointer, JniRuntime runtime)
		{
			EnvironmentPointer = environmentPointer;
			Runtime = runtime;
		}

		internal unsafe JniObjectReference ToJavaName(string jniTypeName)
		{
			if (jniTypeName.IndexOf("/", StringComparison.Ordinal) == -1)
			{
				return JniEnvironment.Strings.NewString(jniTypeName);
			}
			int length = jniTypeName.Length;
			if (length > 512)
			{
				return JniEnvironment.Strings.NewString(jniTypeName.Replace('/', '.'));
			}
			if (nameBuffer == null)
			{
				nameBuffer = new char[512];
			}
			fixed (char* ptr = jniTypeName)
			{
				fixed (char* ptr2 = nameBuffer)
				{
					char* ptr3 = ptr;
					char* ptr4 = ptr2;
					char* ptr5 = ptr + length;
					while (ptr3 < ptr5)
					{
						*ptr4 = ((*ptr3 == '/') ? '.' : (*ptr3));
						ptr3++;
						ptr4++;
					}
					return JniEnvironment.Strings.NewString(ptr2, length);
				}
			}
		}

		public void Dispose()
		{
			if (!disposed)
			{
				runtime = null;
				environmentPointer = IntPtr.Zero;
				nameBuffer = null;
				LocalReferenceCount = 0;
				disposed = true;
			}
		}
	}
	public sealed class JniFieldInfo
	{
		[CompilerGenerated]
		private bool <IsStatic>k__BackingField;

		public IntPtr ID { get; private set; }

		private bool IsStatic
		{
			[CompilerGenerated]
			set
			{
				<IsStatic>k__BackingField = value;
			}
		}

		internal bool IsValid => ID != IntPtr.Zero;

		public string Name
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public string Signature
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public JniFieldInfo(IntPtr fieldID, bool isStatic)
		{
			ID = fieldID;
			IsStatic = isStatic;
		}

		public JniFieldInfo(string name, string signature, IntPtr fieldID, bool isStatic)
		{
			ID = fieldID;
			IsStatic = isStatic;
		}

		public override string ToString()
		{
			bool flag = false;
			bool flag2 = false;
			return string.Format("JniFieldInfo({0}{1}{2}{3}ID=0x{4})", flag ? ("Name=" + Name) : string.Empty, flag ? ", " : string.Empty, flag2 ? ("Signature=" + Signature) : string.Empty, (flag || flag2) ? ", " : string.Empty, ID.ToString("x"));
		}
	}
	[Flags]
	public enum JniManagedPeerStates
	{
		None = 0,
		Activatable = 1,
		Replaceable = 2
	}
	public static class JniMarshal
	{
		public static bool RecursiveEquals(object objA, object objB)
		{
			if (object.Equals(objA, objB))
			{
				return true;
			}
			IEnumerable enumerable = objA as IEnumerable;
			IEnumerable enumerable2 = objB as IEnumerable;
			if (enumerable != null && enumerable2 != null)
			{
				IEnumerator enumerator = enumerable.GetEnumerator();
				IEnumerator enumerator2 = enumerable2.GetEnumerator();
				try
				{
					bool flag;
					bool flag2;
					while (true)
					{
						flag = enumerator.MoveNext();
						flag2 = enumerator2.MoveNext();
						if (!(flag && flag2))
						{
							break;
						}
						if (!RecursiveEquals(enumerator.Current, enumerator2.Current))
						{
							return false;
						}
					}
					return flag == flag2;
				}
				finally
				{
					IDisposable disposable = enumerator as IDisposable;
					IDisposable disposable2 = enumerator2 as IDisposable;
					disposable?.Dispose();
					disposable2?.Dispose();
				}
			}
			return false;
		}
	}
	public sealed class JniMethodInfo
	{
		[CompilerGenerated]
		private bool <IsStatic>k__BackingField;

		public IntPtr ID { get; private set; }

		private bool IsStatic
		{
			[CompilerGenerated]
			set
			{
				<IsStatic>k__BackingField = value;
			}
		}

		internal bool IsValid => ID != IntPtr.Zero;

		public string Name
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public string Signature
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		public JniMethodInfo(IntPtr methodID, bool isStatic)
		{
			ID = methodID;
			IsStatic = isStatic;
		}

		public JniMethodInfo(string name, string signature, IntPtr methodID, bool isStatic)
		{
			ID = methodID;
			IsStatic = isStatic;
		}

		public override string ToString()
		{
			bool flag = false;
			bool flag2 = false;
			return string.Format("JniMethodInfo({0}{1}{2}{3}ID=0x{4})", flag ? ("Name=" + Name) : string.Empty, flag ? ", " : string.Empty, flag2 ? ("Signature=" + Signature) : string.Empty, (flag || flag2) ? ", " : string.Empty, ID.ToString("x"));
		}
	}
	public struct JniNativeMethodRegistration(string name, string signature, Delegate marshaler)
	{
		public string Name = name ?? throw new ArgumentNullException("name");

		public string Signature = signature ?? throw new ArgumentNullException("signature");

		public Delegate Marshaler = marshaler ?? throw new ArgumentNullException("marshaler");
	}
	public struct JniNativeMethodRegistrationArguments(ICollection<JniNativeMethodRegistration> registrations, string methods)
	{
		[CompilerGenerated]
		private readonly string <Methods>k__BackingField = methods;

		private ICollection<JniNativeMethodRegistration> _registrations = registrations ?? throw new ArgumentNullException("registrations");
	}
	[Flags]
	internal enum JniObjectReferenceFlags : uint
	{
		None = 0u,
		Alloc = 0x10000u
	}
	public struct JniObjectReference : IEquatable<JniObjectReference>
	{
		private uint referenceInfo;

		public IntPtr Handle
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get;
			private set; }

		public JniObjectReferenceType Type => (JniObjectReferenceType)(referenceInfo & 0xFFFF);

		internal JniObjectReferenceFlags Flags
		{
			set
			{
				referenceInfo |= (uint)value & 0xFFFF0000u;
			}
		}

		public bool IsValid
		{
			[MethodImpl(MethodImplOptions.AggressiveInlining)]
			get
			{
				return Handle != IntPtr.Zero;
			}
		}

		public JniObjectReference(IntPtr handle, JniObjectReferenceType type = JniObjectReferenceType.Invalid)
		{
			referenceInfo = (uint)type;
			Handle = handle;
		}

		public override int GetHashCode()
		{
			return Handle.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			JniObjectReference? jniObjectReference = obj as JniObjectReference?;
			if (jniObjectReference.HasValue)
			{
				return Equals(jniObjectReference.Value);
			}
			return false;
		}

		public bool Equals(JniObjectReference other)
		{
			return Handle == other.Handle;
		}

		public JniObjectReference NewGlobalRef()
		{
			return JniEnvironment.Runtime.ObjectReferenceManager.CreateGlobalReference(this);
		}

		public JniObjectReference NewLocalRef()
		{
			return JniEnvironment.Runtime.ObjectReferenceManager.CreateLocalReference(JniEnvironment.CurrentInfo, this);
		}

		internal void Invalidate()
		{
			Handle = IntPtr.Zero;
			referenceInfo = 0u;
		}

		public override string ToString()
		{
			return "0x" + Handle.ToString("x") + "/" + ToString(Type);
		}

		private static string ToString(JniObjectReferenceType type)
		{
			return type switch
			{
				JniObjectReferenceType.Global => "G", 
				JniObjectReferenceType.Invalid => "I", 
				JniObjectReferenceType.Local => "L", 
				JniObjectReferenceType.WeakGlobal => "W", 
				_ => type.ToString(), 
			};
		}

		public static void Dispose(ref JniObjectReference reference)
		{
			if (reference.IsValid)
			{
				switch (reference.Type)
				{
				case JniObjectReferenceType.Global:
					JniEnvironment.Runtime.ObjectReferenceManager.DeleteGlobalReference(ref reference);
					break;
				case JniObjectReferenceType.Local:
					JniEnvironment.Runtime.ObjectReferenceManager.DeleteLocalReference(JniEnvironment.CurrentInfo, ref reference);
					break;
				case JniObjectReferenceType.WeakGlobal:
					JniEnvironment.Runtime.ObjectReferenceManager.DeleteWeakGlobalReference(ref reference);
					break;
				default:
					throw new NotImplementedException("Do not know how to dispose: " + reference.Type.ToString() + ".");
				}
				reference.Invalidate();
			}
		}

		public static void Dispose(ref JniObjectReference reference, JniObjectReferenceOptions options)
		{
			if (options != JniObjectReferenceOptions.None && reference.IsValid && (options & (JniObjectReferenceOptions)2) != JniObjectReferenceOptions.None)
			{
				Dispose(ref reference);
			}
		}
	}
	[Flags]
	public enum JniObjectReferenceOptions
	{
		None = 0,
		Copy = 1,
		CopyAndDispose = 3,
		CopyAndDoNotRegister = 5
	}
	public enum JniObjectReferenceType
	{
		Invalid,
		Local,
		Global,
		WeakGlobal
	}
	public class JniPeerMembers
	{
		public sealed class JniInstanceFields
		{
			private readonly JniPeerMembers Members;

			private Dictionary<string, JniFieldInfo> InstanceFields = new Dictionary<string, JniFieldInfo>(StringComparer.Ordinal);

			public bool GetBooleanValue(string encodedMember, IJavaPeerable self)
			{
				AssertSelf(self);
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				bool booleanField = JniEnvironment.InstanceFields.GetBooleanField(self.PeerReference, fieldInfo);
				GC.KeepAlive(self);
				return booleanField;
			}

			public void SetValue(string encodedMember, IJavaPeerable self, bool value)
			{
				AssertSelf(self);
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				JniEnvironment.InstanceFields.SetBooleanField(self.PeerReference, fieldInfo, value);
				GC.KeepAlive(self);
			}

			public sbyte GetSByteValue(string encodedMember, IJavaPeerable self)
			{
				AssertSelf(self);
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				sbyte byteField = JniEnvironment.InstanceFields.GetByteField(self.PeerReference, fieldInfo);
				GC.KeepAlive(self);
				return byteField;
			}

			public void SetValue(string encodedMember, IJavaPeerable self, sbyte value)
			{
				AssertSelf(self);
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				JniEnvironment.InstanceFields.SetByteField(self.PeerReference, fieldInfo, value);
				GC.KeepAlive(self);
			}

			public char GetCharValue(string encodedMember, IJavaPeerable self)
			{
				AssertSelf(self);
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				char charField = JniEnvironment.InstanceFields.GetCharField(self.PeerReference, fieldInfo);
				GC.KeepAlive(self);
				return charField;
			}

			public void SetValue(string encodedMember, IJavaPeerable self, char value)
			{
				AssertSelf(self);
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				JniEnvironment.InstanceFields.SetCharField(self.PeerReference, fieldInfo, value);
				GC.KeepAlive(self);
			}

			public short GetInt16Value(string encodedMember, IJavaPeerable self)
			{
				AssertSelf(self);
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				short shortField = JniEnvironment.InstanceFields.GetShortField(self.PeerReference, fieldInfo);
				GC.KeepAlive(self);
				return shortField;
			}

			public void SetValue(string encodedMember, IJavaPeerable self, short value)
			{
				AssertSelf(self);
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				JniEnvironment.InstanceFields.SetShortField(self.PeerReference, fieldInfo, value);
				GC.KeepAlive(self);
			}

			public int GetInt32Value(string encodedMember, IJavaPeerable self)
			{
				AssertSelf(self);
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				int intField = JniEnvironment.InstanceFields.GetIntField(self.PeerReference, fieldInfo);
				GC.KeepAlive(self);
				return intField;
			}

			public void SetValue(string encodedMember, IJavaPeerable self, int value)
			{
				AssertSelf(self);
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				JniEnvironment.InstanceFields.SetIntField(self.PeerReference, fieldInfo, value);
				GC.KeepAlive(self);
			}

			public long GetInt64Value(string encodedMember, IJavaPeerable self)
			{
				AssertSelf(self);
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				long longField = JniEnvironment.InstanceFields.GetLongField(self.PeerReference, fieldInfo);
				GC.KeepAlive(self);
				return longField;
			}

			public void SetValue(string encodedMember, IJavaPeerable self, long value)
			{
				AssertSelf(self);
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				JniEnvironment.InstanceFields.SetLongField(self.PeerReference, fieldInfo, value);
				GC.KeepAlive(self);
			}

			public float GetSingleValue(string encodedMember, IJavaPeerable self)
			{
				AssertSelf(self);
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				float floatField = JniEnvironment.InstanceFields.GetFloatField(self.PeerReference, fieldInfo);
				GC.KeepAlive(self);
				return floatField;
			}

			public void SetValue(string encodedMember, IJavaPeerable self, float value)
			{
				AssertSelf(self);
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				JniEnvironment.InstanceFields.SetFloatField(self.PeerReference, fieldInfo, value);
				GC.KeepAlive(self);
			}

			public double GetDoubleValue(string encodedMember, IJavaPeerable self)
			{
				AssertSelf(self);
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				double doubleField = JniEnvironment.InstanceFields.GetDoubleField(self.PeerReference, fieldInfo);
				GC.KeepAlive(self);
				return doubleField;
			}

			public void SetValue(string encodedMember, IJavaPeerable self, double value)
			{
				AssertSelf(self);
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				JniEnvironment.InstanceFields.SetDoubleField(self.PeerReference, fieldInfo, value);
				GC.KeepAlive(self);
			}

			public JniObjectReference GetObjectValue(string encodedMember, IJavaPeerable self)
			{
				AssertSelf(self);
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				JniObjectReference objectField = JniEnvironment.InstanceFields.GetObjectField(self.PeerReference, fieldInfo);
				GC.KeepAlive(self);
				return objectField;
			}

			public void SetValue(string encodedMember, IJavaPeerable self, JniObjectReference value)
			{
				AssertSelf(self);
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				JniEnvironment.InstanceFields.SetObjectField(self.PeerReference, fieldInfo, value);
				GC.KeepAlive(self);
			}

			internal JniInstanceFields(JniPeerMembers members)
			{
				Members = members;
			}

			public JniFieldInfo GetFieldInfo(string encodedMember)
			{
				lock (InstanceFields)
				{
					if (!InstanceFields.TryGetValue(encodedMember, out var value))
					{
						GetNameAndSignature(encodedMember, out var name, out var signature);
						value = Members.JniPeerType.GetInstanceField(name, signature);
						InstanceFields.Add(encodedMember, value);
					}
					return value;
				}
			}
		}

		public sealed class JniStaticFields
		{
			private readonly JniPeerMembers Members;

			private Dictionary<string, JniFieldInfo> StaticFields = new Dictionary<string, JniFieldInfo>(StringComparer.Ordinal);

			public bool GetBooleanValue(string encodedMember)
			{
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				return JniEnvironment.StaticFields.GetStaticBooleanField(Members.JniPeerType.PeerReference, fieldInfo);
			}

			public void SetValue(string encodedMember, bool value)
			{
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				JniEnvironment.StaticFields.SetStaticBooleanField(Members.JniPeerType.PeerReference, fieldInfo, value);
			}

			public int GetInt32Value(string encodedMember)
			{
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				return JniEnvironment.StaticFields.GetStaticIntField(Members.JniPeerType.PeerReference, fieldInfo);
			}

			public void SetValue(string encodedMember, int value)
			{
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				JniEnvironment.StaticFields.SetStaticIntField(Members.JniPeerType.PeerReference, fieldInfo, value);
			}

			public long GetInt64Value(string encodedMember)
			{
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				return JniEnvironment.StaticFields.GetStaticLongField(Members.JniPeerType.PeerReference, fieldInfo);
			}

			public void SetValue(string encodedMember, long value)
			{
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				JniEnvironment.StaticFields.SetStaticLongField(Members.JniPeerType.PeerReference, fieldInfo, value);
			}

			public float GetSingleValue(string encodedMember)
			{
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				return JniEnvironment.StaticFields.GetStaticFloatField(Members.JniPeerType.PeerReference, fieldInfo);
			}

			public void SetValue(string encodedMember, float value)
			{
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				JniEnvironment.StaticFields.SetStaticFloatField(Members.JniPeerType.PeerReference, fieldInfo, value);
			}

			public double GetDoubleValue(string encodedMember)
			{
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				return JniEnvironment.StaticFields.GetStaticDoubleField(Members.JniPeerType.PeerReference, fieldInfo);
			}

			public JniObjectReference GetObjectValue(string encodedMember)
			{
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				return JniEnvironment.StaticFields.GetStaticObjectField(Members.JniPeerType.PeerReference, fieldInfo);
			}

			public void SetValue(string encodedMember, JniObjectReference value)
			{
				JniFieldInfo fieldInfo = GetFieldInfo(encodedMember);
				JniEnvironment.StaticFields.SetStaticObjectField(Members.JniPeerType.PeerReference, fieldInfo, value);
			}

			internal JniStaticFields(JniPeerMembers members)
			{
				Members = members;
			}

			public JniFieldInfo GetFieldInfo(string encodedMember)
			{
				lock (StaticFields)
				{
					if (!StaticFields.TryGetValue(encodedMember, out var value))
					{
						GetNameAndSignature(encodedMember, out var name, out var signature);
						value = Members.JniPeerType.GetStaticField(name, signature);
						StaticFields.Add(encodedMember, value);
					}
					return value;
				}
			}
		}

		public sealed class JniInstanceMethods
		{
			private JniPeerMembers members;

			private JniType jniPeerType;

			private readonly Type DeclaringType;

			private Dictionary<string, JniMethodInfo> InstanceMethods = new Dictionary<string, JniMethodInfo>(StringComparer.Ordinal);

			private Dictionary<Type, JniInstanceMethods> SubclassConstructors = new Dictionary<Type, JniInstanceMethods>();

			internal JniPeerMembers Members => members ?? throw new InvalidOperationException();

			internal JniType JniPeerType => jniPeerType ?? Members?.JniPeerType ?? throw new InvalidOperationException();

			internal JniInstanceMethods(JniPeerMembers members)
			{
				DeclaringType = members.ManagedPeerType;
				this.members = members;
			}

			private JniInstanceMethods(Type declaringType)
			{
				JniTypeSignature typeSignature = JniEnvironment.Runtime.TypeManager.GetTypeSignature(declaringType);
				if (typeSignature.SimpleReference == null)
				{
					throw new NotSupportedException($"Cannot create instance of type '{declaringType.FullName}': no Java peer type found.");
				}
				DeclaringType = declaringType;
				jniPeerType = new JniType(typeSignature.Name);
				jniPeerType.RegisterWithRuntime();
			}

			public JniMethodInfo GetConstructor(string signature)
			{
				if (signature == null)
				{
					throw new ArgumentNullException("signature");
				}
				lock (InstanceMethods)
				{
					if (!InstanceMethods.TryGetValue(signature, out var value))
					{
						value = JniPeerType.GetConstructor(signature);
						InstanceMethods.Add(signature, value);
					}
					return value;
				}
			}

			internal JniInstanceMethods GetConstructorsForType(Type declaringType)
			{
				if (declaringType == DeclaringType)
				{
					return this;
				}
				lock (SubclassConstructors)
				{
					if (!SubclassConstructors.TryGetValue(declaringType, out var value))
					{
						value = new JniInstanceMethods(declaringType);
						SubclassConstructors.Add(declaringType, value);
					}
					return value;
				}
			}

			public JniMethodInfo GetMethodInfo(string encodedMember)
			{
				lock (InstanceMethods)
				{
					if (InstanceMethods.TryGetValue(encodedMember, out var value))
					{
						return value;
					}
				}
				GetNameAndSignature(encodedMember, out var name, out var signature);
				JniMethodInfo methodInfo = GetMethodInfo(name, signature);
				lock (InstanceMethods)
				{
					if (InstanceMethods.TryGetValue(encodedMember, out var value2))
					{
						return value2;
					}
					InstanceMethods.Add(encodedMember, methodInfo);
					return methodInfo;
				}
			}

			private JniMethodInfo GetMethodInfo(string method, string signature)
			{
				return JniPeerType.GetInstanceMethod(method, signature);
			}

			public unsafe JniObjectReference StartCreateInstance(string constructorSignature, Type declaringType, JniArgumentValue* parameters)
			{
				if (constructorSignature == null)
				{
					throw new ArgumentNullException("constructorSignature");
				}
				if (declaringType == null)
				{
					throw new ArgumentNullException("declaringType");
				}
				if (JniEnvironment.Runtime.NewObjectRequired)
				{
					return NewObject(constructorSignature, declaringType, parameters);
				}
				JniObjectReference result = GetConstructorsForType(declaringType).JniPeerType.AllocObject();
				result.Flags = JniObjectReferenceFlags.Alloc;
				return result;
			}

			internal unsafe JniObjectReference NewObject(string constructorSignature, Type declaringType, JniArgumentValue* parameters)
			{
				JniInstanceMethods constructorsForType = GetConstructorsForType(declaringType);
				JniMethodInfo constructor = constructorsForType.GetConstructor(constructorSignature);
				return constructorsForType.JniPeerType.NewObject(constructor, parameters);
			}

			public unsafe void FinishCreateInstance(string constructorSignature, IJavaPeerable self, JniArgumentValue* parameters)
			{
				if (constructorSignature == null)
				{
					throw new ArgumentNullException("constructorSignature");
				}
				if (self == null)
				{
					throw new ArgumentNullException("self");
				}
				if (!JniEnvironment.Runtime.NewObjectRequired)
				{
					JniInstanceMethods constructorsForType = GetConstructorsForType(self.GetType());
					JniMethodInfo constructor = constructorsForType.GetConstructor(constructorSignature);
					JniEnvironment.InstanceMethods.CallNonvirtualVoidMethod(self.PeerReference, constructorsForType.JniPeerType.PeerReference, constructor, parameters);
				}
			}

			private unsafe static bool TryInvokeVoidStaticRedirect(JniMethodInfo method, IJavaPeerable self, JniArgumentValue* parameters)
			{
				return false;
			}

			public unsafe void InvokeAbstractVoidMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				try
				{
					JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
					if (!TryInvokeVoidStaticRedirect(methodInfo, self, parameters))
					{
						JniEnvironment.InstanceMethods.CallVoidMethod(self.PeerReference, methodInfo, parameters);
					}
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			public unsafe void InvokeVirtualVoidMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				try
				{
					Type declaringType = DeclaringType;
					if (Members.UsesVirtualDispatch(self, declaringType))
					{
						JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
						if (!TryInvokeVoidStaticRedirect(methodInfo, self, parameters))
						{
							JniEnvironment.InstanceMethods.CallVoidMethod(self.PeerReference, methodInfo, parameters);
						}
						return;
					}
					JniPeerMembers peerMembers = Members.GetPeerMembers(self);
					JniMethodInfo methodInfo2 = peerMembers.InstanceMethods.GetMethodInfo(encodedMember);
					if (!TryInvokeVoidStaticRedirect(methodInfo2, self, parameters))
					{
						JniEnvironment.InstanceMethods.CallNonvirtualVoidMethod(self.PeerReference, peerMembers.JniPeerType.PeerReference, methodInfo2, parameters);
					}
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			public unsafe void InvokeNonvirtualVoidMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				try
				{
					if (!TryInvokeVoidStaticRedirect(methodInfo, self, parameters))
					{
						JniEnvironment.InstanceMethods.CallNonvirtualVoidMethod(self.PeerReference, JniPeerType.PeerReference, methodInfo, parameters);
					}
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			private unsafe static bool TryInvokeBooleanStaticRedirect(JniMethodInfo method, IJavaPeerable self, JniArgumentValue* parameters, out bool r)
			{
				r = false;
				return false;
			}

			public unsafe bool InvokeAbstractBooleanMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				try
				{
					JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
					if (TryInvokeBooleanStaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallBooleanMethod(self.PeerReference, methodInfo, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			public unsafe bool InvokeVirtualBooleanMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				try
				{
					Type declaringType = DeclaringType;
					if (Members.UsesVirtualDispatch(self, declaringType))
					{
						JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
						if (TryInvokeBooleanStaticRedirect(methodInfo, self, parameters, out var r))
						{
							return r;
						}
						return JniEnvironment.InstanceMethods.CallBooleanMethod(self.PeerReference, methodInfo, parameters);
					}
					JniPeerMembers peerMembers = Members.GetPeerMembers(self);
					JniMethodInfo methodInfo2 = peerMembers.InstanceMethods.GetMethodInfo(encodedMember);
					if (TryInvokeBooleanStaticRedirect(methodInfo2, self, parameters, out var r2))
					{
						return r2;
					}
					return JniEnvironment.InstanceMethods.CallNonvirtualBooleanMethod(self.PeerReference, peerMembers.JniPeerType.PeerReference, methodInfo2, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			public unsafe bool InvokeNonvirtualBooleanMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				try
				{
					if (TryInvokeBooleanStaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallNonvirtualBooleanMethod(self.PeerReference, JniPeerType.PeerReference, methodInfo, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			private unsafe static bool TryInvokeSByteStaticRedirect(JniMethodInfo method, IJavaPeerable self, JniArgumentValue* parameters, out sbyte r)
			{
				r = 0;
				return false;
			}

			public unsafe sbyte InvokeAbstractSByteMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				try
				{
					JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
					if (TryInvokeSByteStaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallByteMethod(self.PeerReference, methodInfo, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			public unsafe sbyte InvokeVirtualSByteMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				try
				{
					Type declaringType = DeclaringType;
					if (Members.UsesVirtualDispatch(self, declaringType))
					{
						JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
						if (TryInvokeSByteStaticRedirect(methodInfo, self, parameters, out var r))
						{
							return r;
						}
						return JniEnvironment.InstanceMethods.CallByteMethod(self.PeerReference, methodInfo, parameters);
					}
					JniPeerMembers peerMembers = Members.GetPeerMembers(self);
					JniMethodInfo methodInfo2 = peerMembers.InstanceMethods.GetMethodInfo(encodedMember);
					if (TryInvokeSByteStaticRedirect(methodInfo2, self, parameters, out var r2))
					{
						return r2;
					}
					return JniEnvironment.InstanceMethods.CallNonvirtualByteMethod(self.PeerReference, peerMembers.JniPeerType.PeerReference, methodInfo2, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			public unsafe sbyte InvokeNonvirtualSByteMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				try
				{
					if (TryInvokeSByteStaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallNonvirtualByteMethod(self.PeerReference, JniPeerType.PeerReference, methodInfo, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			private unsafe static bool TryInvokeCharStaticRedirect(JniMethodInfo method, IJavaPeerable self, JniArgumentValue* parameters, out char r)
			{
				r = '\0';
				return false;
			}

			public unsafe char InvokeAbstractCharMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				try
				{
					JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
					if (TryInvokeCharStaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallCharMethod(self.PeerReference, methodInfo, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			public unsafe char InvokeVirtualCharMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				try
				{
					Type declaringType = DeclaringType;
					if (Members.UsesVirtualDispatch(self, declaringType))
					{
						JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
						if (TryInvokeCharStaticRedirect(methodInfo, self, parameters, out var r))
						{
							return r;
						}
						return JniEnvironment.InstanceMethods.CallCharMethod(self.PeerReference, methodInfo, parameters);
					}
					JniPeerMembers peerMembers = Members.GetPeerMembers(self);
					JniMethodInfo methodInfo2 = peerMembers.InstanceMethods.GetMethodInfo(encodedMember);
					if (TryInvokeCharStaticRedirect(methodInfo2, self, parameters, out var r2))
					{
						return r2;
					}
					return JniEnvironment.InstanceMethods.CallNonvirtualCharMethod(self.PeerReference, peerMembers.JniPeerType.PeerReference, methodInfo2, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			public unsafe char InvokeNonvirtualCharMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				try
				{
					if (TryInvokeCharStaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallNonvirtualCharMethod(self.PeerReference, JniPeerType.PeerReference, methodInfo, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			private unsafe static bool TryInvokeInt16StaticRedirect(JniMethodInfo method, IJavaPeerable self, JniArgumentValue* parameters, out short r)
			{
				r = 0;
				return false;
			}

			public unsafe short InvokeAbstractInt16Method(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				try
				{
					JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
					if (TryInvokeInt16StaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallShortMethod(self.PeerReference, methodInfo, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			public unsafe short InvokeVirtualInt16Method(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				try
				{
					Type declaringType = DeclaringType;
					if (Members.UsesVirtualDispatch(self, declaringType))
					{
						JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
						if (TryInvokeInt16StaticRedirect(methodInfo, self, parameters, out var r))
						{
							return r;
						}
						return JniEnvironment.InstanceMethods.CallShortMethod(self.PeerReference, methodInfo, parameters);
					}
					JniPeerMembers peerMembers = Members.GetPeerMembers(self);
					JniMethodInfo methodInfo2 = peerMembers.InstanceMethods.GetMethodInfo(encodedMember);
					if (TryInvokeInt16StaticRedirect(methodInfo2, self, parameters, out var r2))
					{
						return r2;
					}
					return JniEnvironment.InstanceMethods.CallNonvirtualShortMethod(self.PeerReference, peerMembers.JniPeerType.PeerReference, methodInfo2, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			private unsafe static bool TryInvokeInt32StaticRedirect(JniMethodInfo method, IJavaPeerable self, JniArgumentValue* parameters, out int r)
			{
				r = 0;
				return false;
			}

			public unsafe int InvokeAbstractInt32Method(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				try
				{
					JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
					if (TryInvokeInt32StaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallIntMethod(self.PeerReference, methodInfo, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			public unsafe int InvokeVirtualInt32Method(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				try
				{
					Type declaringType = DeclaringType;
					if (Members.UsesVirtualDispatch(self, declaringType))
					{
						JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
						if (TryInvokeInt32StaticRedirect(methodInfo, self, parameters, out var r))
						{
							return r;
						}
						return JniEnvironment.InstanceMethods.CallIntMethod(self.PeerReference, methodInfo, parameters);
					}
					JniPeerMembers peerMembers = Members.GetPeerMembers(self);
					JniMethodInfo methodInfo2 = peerMembers.InstanceMethods.GetMethodInfo(encodedMember);
					if (TryInvokeInt32StaticRedirect(methodInfo2, self, parameters, out var r2))
					{
						return r2;
					}
					return JniEnvironment.InstanceMethods.CallNonvirtualIntMethod(self.PeerReference, peerMembers.JniPeerType.PeerReference, methodInfo2, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			public unsafe int InvokeNonvirtualInt32Method(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				try
				{
					if (TryInvokeInt32StaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallNonvirtualIntMethod(self.PeerReference, JniPeerType.PeerReference, methodInfo, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			private unsafe static bool TryInvokeInt64StaticRedirect(JniMethodInfo method, IJavaPeerable self, JniArgumentValue* parameters, out long r)
			{
				r = 0L;
				return false;
			}

			public unsafe long InvokeAbstractInt64Method(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				try
				{
					JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
					if (TryInvokeInt64StaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallLongMethod(self.PeerReference, methodInfo, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			public unsafe long InvokeVirtualInt64Method(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				try
				{
					Type declaringType = DeclaringType;
					if (Members.UsesVirtualDispatch(self, declaringType))
					{
						JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
						if (TryInvokeInt64StaticRedirect(methodInfo, self, parameters, out var r))
						{
							return r;
						}
						return JniEnvironment.InstanceMethods.CallLongMethod(self.PeerReference, methodInfo, parameters);
					}
					JniPeerMembers peerMembers = Members.GetPeerMembers(self);
					JniMethodInfo methodInfo2 = peerMembers.InstanceMethods.GetMethodInfo(encodedMember);
					if (TryInvokeInt64StaticRedirect(methodInfo2, self, parameters, out var r2))
					{
						return r2;
					}
					return JniEnvironment.InstanceMethods.CallNonvirtualLongMethod(self.PeerReference, peerMembers.JniPeerType.PeerReference, methodInfo2, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			public unsafe long InvokeNonvirtualInt64Method(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				try
				{
					if (TryInvokeInt64StaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallNonvirtualLongMethod(self.PeerReference, JniPeerType.PeerReference, methodInfo, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			private unsafe static bool TryInvokeSingleStaticRedirect(JniMethodInfo method, IJavaPeerable self, JniArgumentValue* parameters, out float r)
			{
				r = 0f;
				return false;
			}

			public unsafe float InvokeAbstractSingleMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				try
				{
					JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
					if (TryInvokeSingleStaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallFloatMethod(self.PeerReference, methodInfo, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			public unsafe float InvokeVirtualSingleMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				try
				{
					Type declaringType = DeclaringType;
					if (Members.UsesVirtualDispatch(self, declaringType))
					{
						JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
						if (TryInvokeSingleStaticRedirect(methodInfo, self, parameters, out var r))
						{
							return r;
						}
						return JniEnvironment.InstanceMethods.CallFloatMethod(self.PeerReference, methodInfo, parameters);
					}
					JniPeerMembers peerMembers = Members.GetPeerMembers(self);
					JniMethodInfo methodInfo2 = peerMembers.InstanceMethods.GetMethodInfo(encodedMember);
					if (TryInvokeSingleStaticRedirect(methodInfo2, self, parameters, out var r2))
					{
						return r2;
					}
					return JniEnvironment.InstanceMethods.CallNonvirtualFloatMethod(self.PeerReference, peerMembers.JniPeerType.PeerReference, methodInfo2, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			public unsafe float InvokeNonvirtualSingleMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				try
				{
					if (TryInvokeSingleStaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallNonvirtualFloatMethod(self.PeerReference, JniPeerType.PeerReference, methodInfo, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			private unsafe static bool TryInvokeDoubleStaticRedirect(JniMethodInfo method, IJavaPeerable self, JniArgumentValue* parameters, out double r)
			{
				r = 0.0;
				return false;
			}

			public unsafe double InvokeAbstractDoubleMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				try
				{
					JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
					if (TryInvokeDoubleStaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallDoubleMethod(self.PeerReference, methodInfo, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			public unsafe double InvokeVirtualDoubleMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				try
				{
					Type declaringType = DeclaringType;
					if (Members.UsesVirtualDispatch(self, declaringType))
					{
						JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
						if (TryInvokeDoubleStaticRedirect(methodInfo, self, parameters, out var r))
						{
							return r;
						}
						return JniEnvironment.InstanceMethods.CallDoubleMethod(self.PeerReference, methodInfo, parameters);
					}
					JniPeerMembers peerMembers = Members.GetPeerMembers(self);
					JniMethodInfo methodInfo2 = peerMembers.InstanceMethods.GetMethodInfo(encodedMember);
					if (TryInvokeDoubleStaticRedirect(methodInfo2, self, parameters, out var r2))
					{
						return r2;
					}
					return JniEnvironment.InstanceMethods.CallNonvirtualDoubleMethod(self.PeerReference, peerMembers.JniPeerType.PeerReference, methodInfo2, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			public unsafe double InvokeNonvirtualDoubleMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				try
				{
					if (TryInvokeDoubleStaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallNonvirtualDoubleMethod(self.PeerReference, JniPeerType.PeerReference, methodInfo, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			private unsafe static bool TryInvokeObjectStaticRedirect(JniMethodInfo method, IJavaPeerable self, JniArgumentValue* parameters, out JniObjectReference r)
			{
				r = default(JniObjectReference);
				return false;
			}

			public unsafe JniObjectReference InvokeAbstractObjectMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				try
				{
					JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
					if (TryInvokeObjectStaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallObjectMethod(self.PeerReference, methodInfo, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			public unsafe JniObjectReference InvokeVirtualObjectMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				try
				{
					Type declaringType = DeclaringType;
					if (Members.UsesVirtualDispatch(self, declaringType))
					{
						JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
						if (TryInvokeObjectStaticRedirect(methodInfo, self, parameters, out var r))
						{
							return r;
						}
						return JniEnvironment.InstanceMethods.CallObjectMethod(self.PeerReference, methodInfo, parameters);
					}
					JniPeerMembers peerMembers = Members.GetPeerMembers(self);
					JniMethodInfo methodInfo2 = peerMembers.InstanceMethods.GetMethodInfo(encodedMember);
					if (TryInvokeObjectStaticRedirect(methodInfo2, self, parameters, out var r2))
					{
						return r2;
					}
					return JniEnvironment.InstanceMethods.CallNonvirtualObjectMethod(self.PeerReference, peerMembers.JniPeerType.PeerReference, methodInfo2, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}

			public unsafe JniObjectReference InvokeNonvirtualObjectMethod(string encodedMember, IJavaPeerable self, JniArgumentValue* parameters)
			{
				AssertSelf(self);
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				try
				{
					if (TryInvokeObjectStaticRedirect(methodInfo, self, parameters, out var r))
					{
						return r;
					}
					return JniEnvironment.InstanceMethods.CallNonvirtualObjectMethod(self.PeerReference, JniPeerType.PeerReference, methodInfo, parameters);
				}
				finally
				{
					GC.KeepAlive(self);
				}
			}
		}

		public sealed class JniStaticMethods
		{
			internal readonly JniPeerMembers Members;

			private Dictionary<string, JniMethodInfo> StaticMethods = new Dictionary<string, JniMethodInfo>(StringComparer.Ordinal);

			internal JniStaticMethods(JniPeerMembers members)
			{
				Members = members;
			}

			public JniMethodInfo GetMethodInfo(string encodedMember)
			{
				lock (StaticMethods)
				{
					if (StaticMethods.TryGetValue(encodedMember, out var value))
					{
						return value;
					}
				}
				GetNameAndSignature(encodedMember, out var name, out var signature);
				JniMethodInfo methodInfo = GetMethodInfo(name, signature);
				lock (StaticMethods)
				{
					if (StaticMethods.TryGetValue(encodedMember, out var value2))
					{
						return value2;
					}
					StaticMethods.Add(encodedMember, methodInfo);
					return methodInfo;
				}
			}

			private JniMethodInfo GetMethodInfo(string method, string signature)
			{
				return Members.JniPeerType.GetStaticMethod(method, signature);
			}

			public unsafe void InvokeVoidMethod(string encodedMember, JniArgumentValue* parameters)
			{
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				JniEnvironment.StaticMethods.CallStaticVoidMethod(Members.JniPeerType.PeerReference, methodInfo, parameters);
			}

			public unsafe bool InvokeBooleanMethod(string encodedMember, JniArgumentValue* parameters)
			{
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				return JniEnvironment.StaticMethods.CallStaticBooleanMethod(Members.JniPeerType.PeerReference, methodInfo, parameters);
			}

			public unsafe sbyte InvokeSByteMethod(string encodedMember, JniArgumentValue* parameters)
			{
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				return JniEnvironment.StaticMethods.CallStaticByteMethod(Members.JniPeerType.PeerReference, methodInfo, parameters);
			}

			public unsafe char InvokeCharMethod(string encodedMember, JniArgumentValue* parameters)
			{
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				return JniEnvironment.StaticMethods.CallStaticCharMethod(Members.JniPeerType.PeerReference, methodInfo, parameters);
			}

			public unsafe short InvokeInt16Method(string encodedMember, JniArgumentValue* parameters)
			{
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				return JniEnvironment.StaticMethods.CallStaticShortMethod(Members.JniPeerType.PeerReference, methodInfo, parameters);
			}

			public unsafe int InvokeInt32Method(string encodedMember, JniArgumentValue* parameters)
			{
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				return JniEnvironment.StaticMethods.CallStaticIntMethod(Members.JniPeerType.PeerReference, methodInfo, parameters);
			}

			public unsafe long InvokeInt64Method(string encodedMember, JniArgumentValue* parameters)
			{
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				return JniEnvironment.StaticMethods.CallStaticLongMethod(Members.JniPeerType.PeerReference, methodInfo, parameters);
			}

			public unsafe float InvokeSingleMethod(string encodedMember, JniArgumentValue* parameters)
			{
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				return JniEnvironment.StaticMethods.CallStaticFloatMethod(Members.JniPeerType.PeerReference, methodInfo, parameters);
			}

			public unsafe double InvokeDoubleMethod(string encodedMember, JniArgumentValue* parameters)
			{
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				return JniEnvironment.StaticMethods.CallStaticDoubleMethod(Members.JniPeerType.PeerReference, methodInfo, parameters);
			}

			public unsafe JniObjectReference InvokeObjectMethod(string encodedMember, JniArgumentValue* parameters)
			{
				JniMethodInfo methodInfo = GetMethodInfo(encodedMember);
				return JniEnvironment.StaticMethods.CallStaticObjectMethod(Members.JniPeerType.PeerReference, methodInfo, parameters);
			}
		}

		private bool isInterface;

		private JniType jniPeerType;

		private JniInstanceMethods instanceMethods;

		private JniInstanceFields instanceFields;

		private JniStaticMethods staticMethods;

		private JniStaticFields staticFields;

		public Type ManagedPeerType { get; private set; }

		public string JniPeerTypeName { get; private set; }

		public JniType JniPeerType
		{
			get
			{
				JniType cachedJniType = JniType.GetCachedJniType(ref jniPeerType, JniPeerTypeName);
				cachedJniType.RegisterWithRuntime();
				return cachedJniType;
			}
		}

		public JniInstanceMethods InstanceMethods => Assert(instanceMethods);

		public JniInstanceFields InstanceFields => Assert(instanceFields);

		public JniStaticMethods StaticMethods => Assert(staticMethods);

		public JniStaticFields StaticFields => Assert(staticFields);

		public JniPeerMembers(string jniPeerTypeName, Type managedPeerType, bool isInterface)
			: this(jniPeerTypeName, managedPeerType, checkManagedPeerType: true, isInterface)
		{
		}

		public JniPeerMembers(string jniPeerTypeName, Type managedPeerType)
			: this(jniPeerTypeName = GetReplacementType(jniPeerTypeName), managedPeerType, checkManagedPeerType: true)
		{
		}

		private static string GetReplacementType(string jniPeerTypeName)
		{
			return jniPeerTypeName;
		}

		private JniPeerMembers(string jniPeerTypeName, Type managedPeerType, bool checkManagedPeerType, bool isInterface = false)
		{
			if (jniPeerTypeName == null)
			{
				throw new ArgumentNullException("jniPeerTypeName");
			}
			if (checkManagedPeerType)
			{
				if (managedPeerType == null)
				{
					throw new ArgumentNullException("managedPeerType");
				}
				if (!typeof(IJavaPeerable).IsAssignableFrom(managedPeerType))
				{
					throw new ArgumentException("'managedPeerType' must implement the IJavaPeerable interface.", "managedPeerType");
				}
			}
			JniPeerTypeName = jniPeerTypeName;
			ManagedPeerType = managedPeerType;
			this.isInterface = isInterface;
			instanceMethods = new JniInstanceMethods(this);
			instanceFields = new JniInstanceFields(this);
			staticMethods = new JniStaticMethods(this);
			staticFields = new JniStaticFields(this);
		}

		private static T Assert<T>(T value) where T : class
		{
			if (value == null)
			{
				throw new ObjectDisposedException("JniPeerMembers");
			}
			return value;
		}

		protected virtual bool UsesVirtualDispatch(IJavaPeerable value, Type declaringType)
		{
			if (!(value.GetType() == declaringType) && !(declaringType == null))
			{
				return value.GetType() == value.JniPeerMembers.ManagedPeerType;
			}
			return true;
		}

		protected virtual JniPeerMembers GetPeerMembers(IJavaPeerable value)
		{
			if (!isInterface)
			{
				return value.JniPeerMembers;
			}
			return this;
		}

		internal static void AssertSelf(IJavaPeerable self)
		{
			if (self == null)
			{
				throw new ArgumentNullException("self");
			}
			if (!self.PeerReference.IsValid)
			{
				throw new ObjectDisposedException(self.GetType().FullName);
			}
		}

		internal static int GetSignatureSeparatorIndex(string encodedMember)
		{
			if (encodedMember == null)
			{
				throw new ArgumentNullException("encodedMember");
			}
			int num = encodedMember.IndexOf(".", StringComparison.Ordinal);
			if (num < 0)
			{
				throw new ArgumentException("Invalid encoding; 'encodedMember' should be encoded as \"<NAME>.<SIGNATURE>\".", "encodedMember");
			}
			if (encodedMember.Length <= num + 1)
			{
				throw new ArgumentException("Invalid encoding; 'encodedMember' is missing a JNI signature, and should be in the format \"<NAME>.<SIGNATURE>\".", "encodedMember");
			}
			return num;
		}

		internal static void GetNameAndSignature(string encodedMember, out string name, out string signature)
		{
			int signatureSeparatorIndex = GetSignatureSeparatorIndex(encodedMember);
			name = encodedMember.Substring(0, signatureSeparatorIndex);
			signature = encodedMember.Substring(signatureSeparatorIndex + 1);
		}
	}
	public enum JniReleaseArrayElementsMode
	{
		Default,
		Commit,
		Abort
	}
	internal delegate int DestroyJavaVMDelegate(IntPtr javavm);
	internal delegate int GetEnvDelegate(IntPtr javavm, out IntPtr envptr, int version);
	internal delegate int AttachCurrentThreadDelegate(IntPtr javavm, out IntPtr env, ref JavaVMThreadAttachArgs args);
	internal delegate int DetachCurrentThreadDelegate(IntPtr javavm);
	internal delegate int AttachCurrentThreadAsDaemonDelegate(IntPtr javavm, out IntPtr env, IntPtr args);
	internal struct JavaVMInterface
	{
		public IntPtr reserved0;

		public IntPtr reserved1;

		public IntPtr reserved2;

		public DestroyJavaVMDelegate DestroyJavaVM;

		public AttachCurrentThreadDelegate AttachCurrentThread;

		public DetachCurrentThreadDelegate DetachCurrentThread;

		public GetEnvDelegate GetEnv;

		public AttachCurrentThreadAsDaemonDelegate AttachCurrentThreadAsDaemon;
	}
	public enum JniVersion
	{
		v1_2 = 65538,
		v1_4 = 65540,
		v1_6 = 65542
	}
	internal struct JavaVMThreadAttachArgs
	{
		public JniVersion version;

		public IntPtr name;

		public IntPtr group;
	}
	public class JniSurfacedPeerInfo
	{
		[CompilerGenerated]
		private int <JniIdentityHashCode>k__BackingField;

		private int JniIdentityHashCode
		{
			[CompilerGenerated]
			set
			{
				<JniIdentityHashCode>k__BackingField = value;
			}
		}

		public WeakReference<IJavaPeerable> SurfacedPeer { get; private set; }

		public JniSurfacedPeerInfo(int jniIdentityHashCode, WeakReference<IJavaPeerable> surfacedPeer)
		{
			JniIdentityHashCode = jniIdentityHashCode;
			SurfacedPeer = surfacedPeer;
		}
	}
	internal sealed class VoidValueMarshaler : JniValueMarshaler
	{
		internal static VoidValueMarshaler Instance = new VoidValueMarshaler();

		public override object CreateValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			throw new NotSupportedException();
		}

		public override JniValueMarshalerState CreateObjectReferenceArgumentState(object value, ParameterAttributes synchronize)
		{
			throw new NotSupportedException();
		}

		public override void DestroyArgumentState(object value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			throw new NotSupportedException();
		}
	}
	internal sealed class JavaPeerableValueMarshaler : JniValueMarshaler<IJavaPeerable>
	{
		internal static JavaPeerableValueMarshaler Instance = new JavaPeerableValueMarshaler();

		public override IJavaPeerable CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			JniRuntime runtime = JniEnvironment.Runtime;
			JniValueMarshaler valueMarshaler = runtime.ValueManager.GetValueMarshaler(targetType ?? typeof(IJavaPeerable));
			if (valueMarshaler != Instance)
			{
				return (IJavaPeerable)valueMarshaler.CreateValue(ref reference, options, targetType);
			}
			return runtime.ValueManager.CreatePeer(ref reference, options, targetType);
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(IJavaPeerable value, ParameterAttributes synchronize)
		{
			if (value == null || !value.PeerReference.IsValid)
			{
				return default(JniValueMarshalerState);
			}
			return new JniValueMarshalerState(value.PeerReference.NewLocalRef());
		}

		public override void DestroyGenericArgumentState(IJavaPeerable value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}
	}
	internal sealed class DelegatingValueMarshaler<T> : JniValueMarshaler<T>
	{
		private JniValueMarshaler ValueMarshaler;

		public DelegatingValueMarshaler(JniValueMarshaler valueMarshaler)
		{
			ValueMarshaler = valueMarshaler;
		}

		public override T CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			return (T)ValueMarshaler.CreateValue(ref reference, options, targetType ?? typeof(T));
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(T value, ParameterAttributes synchronize)
		{
			return ValueMarshaler.CreateObjectReferenceArgumentState(value, synchronize);
		}

		public override void DestroyGenericArgumentState(T value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			ValueMarshaler.DestroyArgumentState(value, ref state, synchronize);
		}
	}
	internal sealed class ProxyValueMarshaler : JniValueMarshaler<object>
	{
		internal static ProxyValueMarshaler Instance = new ProxyValueMarshaler();

		public override object CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			JniRuntime runtime = JniEnvironment.Runtime;
			if (targetType == null || targetType == typeof(object))
			{
				targetType = runtime.ValueManager.GetRuntimeType(reference);
			}
			if (targetType != null)
			{
				JniValueMarshaler valueMarshaler = runtime.ValueManager.GetValueMarshaler(targetType);
				if (valueMarshaler != Instance)
				{
					return valueMarshaler.CreateValue(ref reference, options, targetType);
				}
			}
			object obj = runtime.ValueManager.PeekValue(reference);
			if (obj != null)
			{
				JniObjectReference.Dispose(ref reference, options);
				return obj;
			}
			return runtime.ValueManager.CreatePeer(ref reference, options, targetType);
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(object value, ParameterAttributes synchronize)
		{
			if (value == null)
			{
				return default(JniValueMarshalerState);
			}
			JniValueMarshaler valueMarshaler = JniEnvironment.Runtime.ValueManager.GetValueMarshaler(value.GetType());
			if (valueMarshaler != Instance)
			{
				return new JniValueMarshalerState(valueMarshaler.CreateObjectReferenceArgumentState(value, synchronize), valueMarshaler);
			}
			return new JniValueMarshalerState(JavaProxyObject.GetProxy(value).PeerReference.NewLocalRef());
		}

		public override void DestroyGenericArgumentState(object value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			if (state.Extra is JniValueMarshaler jniValueMarshaler)
			{
				jniValueMarshaler.DestroyArgumentState(value, ref state, synchronize);
				return;
			}
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}
	}
	internal sealed class JniStringValueMarshaler : JniValueMarshaler<string>
	{
		internal static readonly JniStringValueMarshaler Instance = new JniStringValueMarshaler();

		public override string CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType)
		{
			return JniEnvironment.Strings.ToString(ref reference, options, targetType ?? typeof(string));
		}

		public override JniValueMarshalerState CreateGenericObjectReferenceArgumentState(string value, ParameterAttributes synchronize)
		{
			return new JniValueMarshalerState(JniEnvironment.Strings.NewString(value));
		}

		public override void DestroyGenericArgumentState(string value, ref JniValueMarshalerState state, ParameterAttributes synchronize)
		{
			JniObjectReference reference = state.ReferenceValue;
			JniObjectReference.Dispose(ref reference);
			state = default(JniValueMarshalerState);
		}
	}
	internal static class JniSystem
	{
		private static JniType _typeRef;

		private static JniMethodInfo _identityHashCode;

		private static JniType TypeRef => JniType.GetCachedJniType(ref _typeRef, "java/lang/System");

		internal unsafe static int IdentityHashCode(JniObjectReference value)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(value);
			TypeRef.GetCachedStaticMethod(ref _identityHashCode, "identityHashCode", "(Ljava/lang/Object;)I");
			return JniEnvironment.StaticMethods.CallStaticIntMethod(TypeRef.PeerReference, _identityHashCode, ptr);
		}
	}
	public struct JniTransition : IDisposable
	{
		private bool disposed = false;

		private Exception pendingException = null;

		public JniTransition(IntPtr environmentPointer)
		{
			JniEnvironment.SetEnvironmentPointer(environmentPointer);
		}

		public void SetPendingException(Exception exception)
		{
			if (disposed)
			{
				throw new ObjectDisposedException("JniTransition");
			}
			pendingException = exception;
		}

		public void Dispose()
		{
			if (!disposed)
			{
				disposed = true;
				if (pendingException != null)
				{
					JniEnvironment.Runtime.RaisePendingException(pendingException);
					pendingException = null;
				}
			}
		}
	}
	public sealed class JniType : IDisposable
	{
		private bool registered;

		private JniObjectReference peerReference;

		private JniNativeMethodRegistration[] methods;

		public JniObjectReference PeerReference => peerReference;

		public string Name
		{
			get
			{
				AssertValid();
				return JniEnvironment.Types.GetJniTypeNameFromClass(PeerReference);
			}
		}

		public JniType(string classname)
		{
			JniObjectReference jniObjectReference = JniEnvironment.Types.FindClass(classname);
			Initialize(ref jniObjectReference, JniObjectReferenceOptions.CopyAndDispose);
		}

		public JniType(ref JniObjectReference peerReference, JniObjectReferenceOptions transfer)
		{
			Initialize(ref peerReference, transfer);
		}

		private void Initialize(ref JniObjectReference peerReference, JniObjectReferenceOptions transfer)
		{
			if (!peerReference.IsValid)
			{
				throw new ArgumentException("handle must be valid.", "peerReference");
			}
			try
			{
				this.peerReference = peerReference.NewGlobalRef();
			}
			finally
			{
				JniObjectReference.Dispose(ref peerReference, transfer);
			}
		}

		public override string ToString()
		{
			return $"JniType(Name='{Name}' PeerReference={PeerReference})";
		}

		public void RegisterWithRuntime()
		{
			AssertValid();
			if (!registered)
			{
				JniEnvironment.Runtime.Track(this);
				registered = true;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		private void AssertValid()
		{
			if (!PeerReference.IsValid)
			{
				throw new ObjectDisposedException(GetType().FullName);
			}
		}

		public static JniType GetCachedJniType(ref JniType cachedType, string classname)
		{
			if (cachedType != null && cachedType.PeerReference.IsValid)
			{
				return cachedType;
			}
			JniType jniType = new JniType(classname);
			if (Interlocked.CompareExchange(ref cachedType, jniType, null) != null)
			{
				jniType.Dispose();
			}
			cachedType.RegisterWithRuntime();
			return cachedType;
		}

		public void Dispose()
		{
			if (PeerReference.IsValid)
			{
				if (registered)
				{
					JniEnvironment.Runtime.UnTrack(PeerReference.Handle);
				}
				if (methods != null)
				{
					UnregisterNativeMethods();
				}
				JniObjectReference.Dispose(ref peerReference);
			}
		}

		public void RegisterNativeMethods(params JniNativeMethodRegistration[] methods)
		{
			AssertValid();
			if (methods == null)
			{
				throw new ArgumentNullException("methods");
			}
			JniEnvironment.Types.RegisterNatives(PeerReference, methods, methods.Length);
			this.methods = methods;
			RegisterWithRuntime();
		}

		public void UnregisterNativeMethods()
		{
			AssertValid();
			JniEnvironment.Types.UnregisterNatives(PeerReference);
		}

		public JniMethodInfo GetConstructor(string signature)
		{
			AssertValid();
			return JniEnvironment.InstanceMethods.GetMethodID(PeerReference, "<init>", signature);
		}

		public JniMethodInfo GetCachedConstructor(ref JniMethodInfo cachedMethod, string signature)
		{
			AssertValid();
			return GetCachedInstanceMethod(ref cachedMethod, "<init>", signature);
		}

		public JniObjectReference AllocObject()
		{
			AssertValid();
			return JniEnvironment.Object.AllocObject(PeerReference);
		}

		public unsafe JniObjectReference NewObject(JniMethodInfo constructor, JniArgumentValue* parameters)
		{
			AssertValid();
			return JniEnvironment.Object.NewObject(PeerReference, constructor, parameters);
		}

		public JniFieldInfo GetInstanceField(string name, string signature)
		{
			AssertValid();
			return JniEnvironment.InstanceFields.GetFieldID(PeerReference, name, signature);
		}

		public JniFieldInfo GetStaticField(string name, string signature)
		{
			AssertValid();
			return JniEnvironment.StaticFields.GetStaticFieldID(PeerReference, name, signature);
		}

		public JniMethodInfo GetInstanceMethod(string name, string signature)
		{
			AssertValid();
			return JniEnvironment.InstanceMethods.GetMethodID(PeerReference, name, signature);
		}

		public JniMethodInfo GetCachedInstanceMethod(ref JniMethodInfo cachedMethod, string name, string signature)
		{
			AssertValid();
			if (cachedMethod != null && cachedMethod.IsValid)
			{
				return cachedMethod;
			}
			JniMethodInfo instanceMethod = GetInstanceMethod(name, signature);
			Interlocked.CompareExchange(ref cachedMethod, instanceMethod, null);
			return cachedMethod;
		}

		public JniMethodInfo GetStaticMethod(string name, string signature)
		{
			AssertValid();
			return JniEnvironment.StaticMethods.GetStaticMethodID(PeerReference, name, signature);
		}

		public JniMethodInfo GetCachedStaticMethod(ref JniMethodInfo cachedMethod, string name, string signature)
		{
			AssertValid();
			if (cachedMethod != null && cachedMethod.IsValid)
			{
				return cachedMethod;
			}
			JniMethodInfo staticMethod = GetStaticMethod(name, signature);
			Interlocked.CompareExchange(ref cachedMethod, staticMethod, null);
			return cachedMethod;
		}
	}
	public struct JniTypeSignature : IEquatable<JniTypeSignature>
	{
		public static readonly JniTypeSignature Empty;

		internal bool IsKeyword { get; private set; }

		public string SimpleReference { get; private set; }

		public int ArrayRank { get; private set; }

		public bool IsValid => SimpleReference != null;

		public string QualifiedReference
		{
			get
			{
				string text = (IsKeyword ? (SimpleReference ?? throw new InvalidOperationException()) : ("L" + SimpleReference + ";"));
				if (ArrayRank != 0)
				{
					return new string('[', ArrayRank) + text;
				}
				return text;
			}
		}

		public string Name
		{
			get
			{
				if (ArrayRank != 0)
				{
					return QualifiedReference;
				}
				return SimpleReference ?? throw new InvalidOperationException();
			}
		}

		public JniTypeSignature(string simpleReference, int arrayRank = 0, bool keyword = false)
		{
			if (simpleReference != null)
			{
				if (simpleReference.Length < 1)
				{
					throw new ArgumentException("The empty string is not a valid JNI simple reference.", "simpleReference");
				}
				if (simpleReference.IndexOf('.') >= 0)
				{
					throw new ArgumentException("JNI type names do not contain '.', they use '/'. Are you sure you're using a JNI type name?", "simpleReference");
				}
				if (simpleReference[0] == '[')
				{
					throw new ArgumentException("To specify an array, use the ArrayRank property.", "simpleReference");
				}
				if (simpleReference[0] == 'L' && simpleReference[simpleReference.Length - 1] == ';')
				{
					throw new ArgumentException("JNI type references are not supported.", "simpleReference");
				}
			}
			SimpleReference = simpleReference;
			ArrayRank = arrayRank;
			IsKeyword = keyword;
		}

		public JniTypeSignature AddArrayRank(int rank)
		{
			if (SimpleReference == null)
			{
				throw new InvalidOperationException();
			}
			return new JniTypeSignature(SimpleReference, ArrayRank + rank, IsKeyword);
		}

		public JniTypeSignature GetPrimitivePeerTypeSignature()
		{
			if (!IsKeyword)
			{
				return this;
			}
			return SimpleReference switch
			{
				"V" => new JniTypeSignature("java/lang/Void", ArrayRank), 
				"Z" => new JniTypeSignature("java/lang/Boolean", ArrayRank), 
				"B" => new JniTypeSignature("java/lang/Byte", ArrayRank), 
				"C" => new JniTypeSignature("java/lang/Character", ArrayRank), 
				"S" => new JniTypeSignature("java/lang/Short", ArrayRank), 
				"I" => new JniTypeSignature("java/lang/Integer", ArrayRank), 
				"J" => new JniTypeSignature("java/lang/Long", ArrayRank), 
				"F" => new JniTypeSignature("java/lang/Float", ArrayRank), 
				"D" => new JniTypeSignature("java/lang/Double", ArrayRank), 
				_ => throw new InvalidOperationException($"SimpleReference '{SimpleReference}' isn't a known keyword reference, yet is a keyword."), 
			};
		}

		public static bool TryParse(string signature, out JniTypeSignature result)
		{
			if (TryParseWithException(signature, out result) != null)
			{
				return false;
			}
			return true;
		}

		private static Exception TryParseWithException(string signature, out JniTypeSignature result)
		{
			result = default(JniTypeSignature);
			if (signature == null)
			{
				return new ArgumentNullException("signature");
			}
			if (signature.Length < 1)
			{
				return new ArgumentException("The empty string is not a valid JNI simple reference.", "signature");
			}
			int num = 0;
			int num2 = 0;
			string text = null;
			bool keyword = false;
			while (num < signature.Length && signature[num] == '[')
			{
				num++;
				num2++;
			}
			switch (signature[num])
			{
			case 'B':
			case 'C':
			case 'D':
			case 'F':
			case 'I':
			case 'J':
			case 'S':
			case 'Z':
				if (signature.Length - num > 1)
				{
					text = signature.Substring(num);
					break;
				}
				text = signature[num].ToString();
				keyword = true;
				break;
			case 'L':
			{
				int num3 = signature.IndexOf(';', num);
				if (num3 >= num && num3 != signature.Length - 1)
				{
					return new ArgumentException($"Malformed JNI type reference: trailing text after ';' in '{signature}'.", "signature");
				}
				if (num == 0)
				{
					text = ((num3 > num) ? signature.Substring(num + 1, num3 - num - 1) : signature);
					break;
				}
				if (num3 < num)
				{
					return new ArgumentException($"Malformed JNI type reference; no terminating ';' for type ref: '{signature.Substring(num)}'.", "signature");
				}
				if (num3 != signature.Length - 1)
				{
					return new ArgumentException($"Malformed jNI type reference: invalid trailing text: '{signature.Substring(num)}'.", "signature");
				}
				text = signature.Substring(num + 1, num3 - num - 1);
				break;
			}
			default:
				if (num != 0)
				{
					return new ArgumentException($"Malformed JNI type reference: found unrecognized char '{signature[num]}' in '{signature}'.", "signature");
				}
				text = signature;
				break;
			}
			int num4 = text.IndexOfAny(new char[2] { '.', ';' });
			if (num4 >= 0)
			{
				return new ArgumentException($"Malformed JNI type reference: contains '{text[num4]}': {signature}", "signature");
			}
			result = new JniTypeSignature(text, num2, keyword);
			return null;
		}

		public override int GetHashCode()
		{
			return QualifiedReference.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			JniTypeSignature? jniTypeSignature = obj as JniTypeSignature?;
			if (jniTypeSignature.HasValue)
			{
				return Equals(jniTypeSignature.Value);
			}
			return false;
		}

		public bool Equals(JniTypeSignature other)
		{
			if (IsKeyword == other.IsKeyword && SimpleReference == other.SimpleReference)
			{
				return ArrayRank == other.ArrayRank;
			}
			return false;
		}

		public override string ToString()
		{
			return $"JniTypeSignature(TypeName={SimpleReference} ArrayRank={ArrayRank} Keyword={IsKeyword})";
		}
	}
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, AllowMultiple = false)]
	public sealed class JniTypeSignatureAttribute : Attribute
	{
		private int arrayRank;

		public bool IsKeyword { get; set; }

		public string SimpleReference { get; private set; }

		public int ArrayRank
		{
			get
			{
				return arrayRank;
			}
			set
			{
				if (value < 0)
				{
					throw new ArgumentException("ArrayRank cannot be less than zero.", "value");
				}
				arrayRank = value;
			}
		}

		public JniTypeSignatureAttribute(string simpleReference)
		{
			JniRuntime.JniTypeManager.AssertSimpleReference(simpleReference, "simpleReference");
			SimpleReference = simpleReference;
		}
	}
	public struct JniValueMarshalerState : IEquatable<JniValueMarshalerState>
	{
		public JniArgumentValue JniArgumentValue { get; private set; }

		public JniObjectReference ReferenceValue { get; private set; }

		public IJavaPeerable PeerableValue { get; private set; }

		public object Extra { get; private set; }

		public JniValueMarshalerState(JniArgumentValue jniArgumentValue, object extra = null)
		{
			JniArgumentValue = jniArgumentValue;
			ReferenceValue = default(JniObjectReference);
			PeerableValue = null;
			Extra = extra;
		}

		public JniValueMarshalerState(JniObjectReference referenceValue, object extra = null)
		{
			JniArgumentValue = new JniArgumentValue(referenceValue);
			ReferenceValue = referenceValue;
			PeerableValue = null;
			Extra = extra;
		}

		public JniValueMarshalerState(IJavaPeerable peerableValue, object extra = null)
		{
			PeerableValue = peerableValue;
			ReferenceValue = peerableValue?.PeerReference ?? default(JniObjectReference);
			JniArgumentValue = new JniArgumentValue(ReferenceValue);
			Extra = extra;
		}

		internal JniValueMarshalerState(JniValueMarshalerState copy, object extra = null)
		{
			JniArgumentValue = copy.JniArgumentValue;
			ReferenceValue = copy.ReferenceValue;
			PeerableValue = copy.PeerableValue;
			Extra = extra ?? copy.Extra;
		}

		public override int GetHashCode()
		{
			return JniArgumentValue.GetHashCode();
		}

		public override bool Equals(object obj)
		{
			JniValueMarshalerState? jniValueMarshalerState = obj as JniValueMarshalerState?;
			if (!jniValueMarshalerState.HasValue)
			{
				return false;
			}
			return Equals(jniValueMarshalerState.Value);
		}

		public bool Equals(JniValueMarshalerState other)
		{
			if (JniArgumentValue.Equals(other.JniArgumentValue) && ReferenceValue.Equals(other.ReferenceValue) && PeerableValue == other.PeerableValue)
			{
				return Extra == other.Extra;
			}
			return false;
		}

		public override string ToString()
		{
			return string.Format("JniValueMarshalerState({0}, ReferenceValue={1}, PeerableValue=0x{2}, Extra={3})", JniArgumentValue.ToString(), ReferenceValue.ToString(), RuntimeHelpers.GetHashCode(PeerableValue).ToString("x"), Extra);
		}
	}
	public abstract class JniValueMarshaler
	{
		public abstract object CreateValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType = null);

		public virtual JniValueMarshalerState CreateArgumentState(object value, ParameterAttributes synchronize = ParameterAttributes.None)
		{
			return CreateObjectReferenceArgumentState(value, synchronize);
		}

		public abstract JniValueMarshalerState CreateObjectReferenceArgumentState(object value, ParameterAttributes synchronize = ParameterAttributes.None);

		public abstract void DestroyArgumentState(object value, ref JniValueMarshalerState state, ParameterAttributes synchronize = ParameterAttributes.None);
	}
	public abstract class JniValueMarshaler<T> : JniValueMarshaler
	{
		public abstract T CreateGenericValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType = null);

		public virtual JniValueMarshalerState CreateGenericArgumentState(T value, ParameterAttributes synchronize = ParameterAttributes.None)
		{
			return CreateGenericObjectReferenceArgumentState(value, synchronize);
		}

		public abstract JniValueMarshalerState CreateGenericObjectReferenceArgumentState(T value, ParameterAttributes synchronize = ParameterAttributes.None);

		public abstract void DestroyGenericArgumentState(T value, ref JniValueMarshalerState state, ParameterAttributes synchronize = ParameterAttributes.None);

		public override object CreateValue(ref JniObjectReference reference, JniObjectReferenceOptions options, Type targetType = null)
		{
			return CreateGenericValue(ref reference, options, targetType ?? typeof(T));
		}

		public override JniValueMarshalerState CreateArgumentState(object value, ParameterAttributes synchronize = ParameterAttributes.None)
		{
			return CreateGenericArgumentState((T)value, synchronize);
		}

		public override JniValueMarshalerState CreateObjectReferenceArgumentState(object value, ParameterAttributes synchronize = ParameterAttributes.None)
		{
			return CreateGenericObjectReferenceArgumentState((T)value, synchronize);
		}

		public override void DestroyArgumentState(object value, ref JniValueMarshalerState state, ParameterAttributes synchronize = ParameterAttributes.None)
		{
			DestroyGenericArgumentState((T)value, ref state, synchronize);
		}
	}
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Interface | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = false)]
	public class JniValueMarshalerAttribute : Attribute
	{
		public Type MarshalerType { get; }

		public JniValueMarshalerAttribute(Type marshalerType)
		{
			if (marshalerType == null)
			{
				throw new ArgumentNullException("marshalerType");
			}
			if (!typeof(JniValueMarshaler).IsAssignableFrom(marshalerType))
			{
				throw new ArgumentException($"`{marshalerType.FullName}` must inherit from JniValueMarshaler!", "marshalerType");
			}
			MarshalerType = marshalerType;
		}
	}
	[JniTypeSignature("com/xamarin/java_interop/ManagedPeer")]
	internal sealed class ManagedPeer : JavaObject
	{
		private delegate void ConstructMarshalMethod(IntPtr jnienv, IntPtr klass, IntPtr n_self, IntPtr n_assemblyQualifiedName, IntPtr n_constructorSignature, IntPtr n_constructorArguments);

		private delegate void RegisterMarshalMethod(IntPtr jnienv, IntPtr klass, IntPtr n_nativeClass, IntPtr n_assemblyQualifiedName, IntPtr n_methods);

		private static readonly JniPeerMembers _members;

		static ManagedPeer()
		{
			_members = new JniPeerMembers("com/xamarin/java_interop/ManagedPeer", typeof(ManagedPeer));
			_members.JniPeerType.RegisterNativeMethods(new JniNativeMethodRegistration("construct", "(Ljava/lang/Object;Ljava/lang/String;Ljava/lang/String;[Ljava/lang/Object;)V", new ConstructMarshalMethod(Construct)), new JniNativeMethodRegistration("registerNativeMembers", "(Ljava/lang/Class;Ljava/lang/String;Ljava/lang/String;)V", new RegisterMarshalMethod(RegisterNativeMembers)));
		}

		internal static void Init()
		{
		}

		private static void Construct(IntPtr jnienv, IntPtr klass, IntPtr n_self, IntPtr n_assemblyQualifiedName, IntPtr n_constructorSignature, IntPtr n_constructorArguments)
		{
			JniTransition jniTransition = new JniTransition(jnienv);
			try
			{
				JniRuntime runtime = JniEnvironment.Runtime;
				JniObjectReference jniObjectReference = new JniObjectReference(n_self);
				IJavaPeerable javaPeerable = runtime.ValueManager.PeekPeer(jniObjectReference);
				if (javaPeerable != null)
				{
					JniManagedPeerStates jniManagedPeerState = javaPeerable.JniManagedPeerState;
					if ((jniManagedPeerState & JniManagedPeerStates.Activatable) != JniManagedPeerStates.Activatable && (jniManagedPeerState & JniManagedPeerStates.Replaceable) != JniManagedPeerStates.Replaceable)
					{
						return;
					}
				}
				if (JniEnvironment.WithinNewObjectScope)
				{
					if (runtime.ObjectReferenceManager.LogGlobalReferenceMessages)
					{
						runtime.ObjectReferenceManager.WriteGlobalReferenceLine("Warning: Skipping managed constructor invocation for PeerReference={0} IdentityHashCode=0x{1} Java.Type={2}. Please use JniPeerMembers.InstanceMethods.StartCreateInstance() + JniPeerMembers.InstanceMethods.FinishCreateInstance() instead of JniEnvironment.Object.NewObject().", jniObjectReference, runtime.ValueManager.GetJniIdentityHashCode(jniObjectReference).ToString("x"), JniEnvironment.Types.GetJniTypeNameFromInstance(jniObjectReference));
					}
					return;
				}
				Type type = Type.GetType(JniEnvironment.Strings.ToString(n_assemblyQualifiedName), throwOnError: true);
				if (type.IsGenericTypeDefinition)
				{
					throw new NotSupportedException("Constructing instances of generic types from Java is not supported, as the type parameters cannot be determined.", CreateJniLocationException());
				}
				Type[] parameterTypes = GetParameterTypes(JniEnvironment.Strings.ToString(n_constructorSignature));
				object[] values = GetValues(runtime, new JniObjectReference(n_constructorArguments), parameterTypes);
				ConstructorInfo constructor = type.GetConstructor(parameterTypes);
				if (constructor == null)
				{
					throw CreateMissingConstructorException(type, parameterTypes);
				}
				if (javaPeerable != null)
				{
					constructor.Invoke(javaPeerable, values);
				}
				else
				{
					JniEnvironment.Runtime.ValueManager.ActivatePeer(javaPeerable, new JniObjectReference(n_self), constructor, values);
				}
			}
			catch (Exception ex) when (JniEnvironment.Runtime.ExceptionShouldTransitionToJni(ex))
			{
				jniTransition.SetPendingException(ex);
			}
			finally
			{
				jniTransition.Dispose();
			}
		}

		private static Exception CreateMissingConstructorException(Type type, Type[] ptypes)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("Unable to find constructor ");
			stringBuilder.Append(type.FullName);
			stringBuilder.Append("(");
			if (ptypes.Length != 0)
			{
				stringBuilder.Append(ptypes[0].FullName);
				for (int i = 1; i < ptypes.Length; i++)
				{
					stringBuilder.Append(", ").Append(ptypes[i].FullName);
				}
			}
			stringBuilder.Append(")");
			stringBuilder.Append(". Please provide the missing constructor.");
			return new NotSupportedException(stringBuilder.ToString(), CreateJniLocationException());
		}

		private static Exception CreateJniLocationException()
		{
			using JavaException ex = new JavaException();
			return new JniLocationException(ex.ToString());
		}

		private static Type[] GetParameterTypes(string signature)
		{
			if (string.IsNullOrEmpty(signature))
			{
				return Array.Empty<Type>();
			}
			string[] array = signature.Split(':');
			Type[] array2 = new Type[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = Type.GetType(array[i], throwOnError: true);
			}
			return array2;
		}

		private static object[] GetValues(JniRuntime runtime, JniObjectReference values, Type[] types)
		{
			if (!values.IsValid)
			{
				return null;
			}
			JniEnvironment.Arrays.GetArrayLength(values);
			object[] array = new object[types.Length];
			for (int i = 0; i < array.Length; i++)
			{
				JniObjectReference reference = JniEnvironment.Arrays.GetObjectArrayElement(values, i);
				object value = runtime.ValueManager.GetValue(ref reference, JniObjectReferenceOptions.CopyAndDispose, types[i]);
				array[i] = value;
			}
			return array;
		}

		private static void RegisterNativeMembers(IntPtr jnienv, IntPtr klass, IntPtr n_nativeClass, IntPtr n_assemblyQualifiedName, IntPtr n_methods)
		{
			JniTransition jniTransition = new JniTransition(jnienv);
			try
			{
				JniObjectReference peerReference = new JniObjectReference(n_nativeClass);
				JniType nativeClass = new JniType(ref peerReference, JniObjectReferenceOptions.Copy);
				Type type = Type.GetType(JniEnvironment.Strings.ToString(new JniObjectReference(n_assemblyQualifiedName)), throwOnError: true);
				string methods = JniEnvironment.Strings.ToString(new JniObjectReference(n_methods));
				JniEnvironment.Runtime.TypeManager.RegisterNativeMembers(nativeClass, type, methods);
			}
			catch (Exception ex) when (JniEnvironment.Runtime.ExceptionShouldTransitionToJni(ex))
			{
				jniTransition.SetPendingException(ex);
			}
			finally
			{
				jniTransition.Dispose();
			}
		}
	}
	internal sealed class JniLocationException : Exception
	{
		private string stackTrace;

		public override string StackTrace => stackTrace;

		public JniLocationException(string stackTrace)
		{
			this.stackTrace = stackTrace;
		}
	}
	internal static class NativeMethods
	{
		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_find_class(IntPtr jnienv, out IntPtr thrown, string classname);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_get_superclass(IntPtr jnienv, IntPtr type);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern byte java_interop_jnienv_is_assignable_from(IntPtr jnienv, IntPtr class1, IntPtr class2);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int java_interop_jnienv_throw(IntPtr jnienv, IntPtr toThrow);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int java_interop_jnienv_throw_new(IntPtr jnienv, IntPtr type, string message);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_exception_occurred(IntPtr jnienv);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_exception_describe(IntPtr jnienv);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_exception_clear(IntPtr jnienv);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int java_interop_jnienv_push_local_frame(IntPtr jnienv, int capacity);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_pop_local_frame(IntPtr jnienv, IntPtr result);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_new_global_ref(IntPtr jnienv, IntPtr instance);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_delete_global_ref(IntPtr jnienv, IntPtr instance);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_delete_local_ref(IntPtr jnienv, IntPtr instance);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern byte java_interop_jnienv_is_same_object(IntPtr jnienv, IntPtr object1, IntPtr object2);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_new_local_ref(IntPtr jnienv, IntPtr instance);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int java_interop_jnienv_ensure_local_capacity(IntPtr jnienv, int capacity);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_alloc_object(IntPtr jnienv, out IntPtr thrown, IntPtr type);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_new_object(IntPtr jnienv, out IntPtr thrown, IntPtr type, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_new_object_a(IntPtr jnienv, out IntPtr thrown, IntPtr type, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_get_object_class(IntPtr jnienv, IntPtr instance);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern byte java_interop_jnienv_is_instance_of(IntPtr jnienv, IntPtr instance, IntPtr type);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_get_method_id(IntPtr jnienv, out IntPtr thrown, IntPtr type, string name, string signature);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_call_object_method(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_call_object_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern byte java_interop_jnienv_call_boolean_method(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern byte java_interop_jnienv_call_boolean_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern sbyte java_interop_jnienv_call_byte_method(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern sbyte java_interop_jnienv_call_byte_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern char java_interop_jnienv_call_char_method(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern char java_interop_jnienv_call_char_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern short java_interop_jnienv_call_short_method(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern short java_interop_jnienv_call_short_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int java_interop_jnienv_call_int_method(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int java_interop_jnienv_call_int_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern long java_interop_jnienv_call_long_method(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern long java_interop_jnienv_call_long_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern float java_interop_jnienv_call_float_method(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern float java_interop_jnienv_call_float_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern double java_interop_jnienv_call_double_method(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern double java_interop_jnienv_call_double_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_call_void_method(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_call_void_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_call_nonvirtual_object_method(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr type, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_call_nonvirtual_object_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr type, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern byte java_interop_jnienv_call_nonvirtual_boolean_method(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr type, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern byte java_interop_jnienv_call_nonvirtual_boolean_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr type, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern sbyte java_interop_jnienv_call_nonvirtual_byte_method(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr type, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern sbyte java_interop_jnienv_call_nonvirtual_byte_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr type, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern char java_interop_jnienv_call_nonvirtual_char_method(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr type, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern char java_interop_jnienv_call_nonvirtual_char_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr type, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern short java_interop_jnienv_call_nonvirtual_short_method(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr type, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern short java_interop_jnienv_call_nonvirtual_short_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr type, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int java_interop_jnienv_call_nonvirtual_int_method(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr type, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int java_interop_jnienv_call_nonvirtual_int_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr type, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern long java_interop_jnienv_call_nonvirtual_long_method(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr type, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern long java_interop_jnienv_call_nonvirtual_long_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr type, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern float java_interop_jnienv_call_nonvirtual_float_method(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr type, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern float java_interop_jnienv_call_nonvirtual_float_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr type, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern double java_interop_jnienv_call_nonvirtual_double_method(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr type, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern double java_interop_jnienv_call_nonvirtual_double_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr type, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_call_nonvirtual_void_method(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr type, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_call_nonvirtual_void_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr instance, IntPtr type, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_get_field_id(IntPtr jnienv, out IntPtr thrown, IntPtr type, string name, string signature);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_get_object_field(IntPtr jnienv, IntPtr instance, IntPtr field);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern byte java_interop_jnienv_get_boolean_field(IntPtr jnienv, IntPtr instance, IntPtr field);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern sbyte java_interop_jnienv_get_byte_field(IntPtr jnienv, IntPtr instance, IntPtr field);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern char java_interop_jnienv_get_char_field(IntPtr jnienv, IntPtr instance, IntPtr field);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern short java_interop_jnienv_get_short_field(IntPtr jnienv, IntPtr instance, IntPtr field);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int java_interop_jnienv_get_int_field(IntPtr jnienv, IntPtr instance, IntPtr field);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern long java_interop_jnienv_get_long_field(IntPtr jnienv, IntPtr instance, IntPtr field);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern float java_interop_jnienv_get_float_field(IntPtr jnienv, IntPtr instance, IntPtr field);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern double java_interop_jnienv_get_double_field(IntPtr jnienv, IntPtr instance, IntPtr field);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_set_object_field(IntPtr jnienv, IntPtr instance, IntPtr field, IntPtr value);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_set_boolean_field(IntPtr jnienv, IntPtr instance, IntPtr field, byte value);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_set_byte_field(IntPtr jnienv, IntPtr instance, IntPtr field, sbyte value);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_set_char_field(IntPtr jnienv, IntPtr instance, IntPtr field, char value);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_set_short_field(IntPtr jnienv, IntPtr instance, IntPtr field, short value);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_set_int_field(IntPtr jnienv, IntPtr instance, IntPtr field, int value);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_set_long_field(IntPtr jnienv, IntPtr instance, IntPtr field, long value);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_set_float_field(IntPtr jnienv, IntPtr instance, IntPtr field, float value);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_set_double_field(IntPtr jnienv, IntPtr instance, IntPtr field, double value);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_get_static_method_id(IntPtr jnienv, out IntPtr thrown, IntPtr type, string name, string signature);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_call_static_object_method(IntPtr jnienv, out IntPtr thrown, IntPtr type, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_call_static_object_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr type, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern byte java_interop_jnienv_call_static_boolean_method(IntPtr jnienv, out IntPtr thrown, IntPtr type, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern byte java_interop_jnienv_call_static_boolean_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr type, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern sbyte java_interop_jnienv_call_static_byte_method(IntPtr jnienv, out IntPtr thrown, IntPtr type, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern sbyte java_interop_jnienv_call_static_byte_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr type, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern char java_interop_jnienv_call_static_char_method(IntPtr jnienv, out IntPtr thrown, IntPtr type, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern char java_interop_jnienv_call_static_char_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr type, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern short java_interop_jnienv_call_static_short_method(IntPtr jnienv, out IntPtr thrown, IntPtr type, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern short java_interop_jnienv_call_static_short_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr type, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int java_interop_jnienv_call_static_int_method(IntPtr jnienv, out IntPtr thrown, IntPtr type, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int java_interop_jnienv_call_static_int_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr type, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern long java_interop_jnienv_call_static_long_method(IntPtr jnienv, out IntPtr thrown, IntPtr type, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern long java_interop_jnienv_call_static_long_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr type, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern float java_interop_jnienv_call_static_float_method(IntPtr jnienv, out IntPtr thrown, IntPtr type, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern float java_interop_jnienv_call_static_float_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr type, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern double java_interop_jnienv_call_static_double_method(IntPtr jnienv, out IntPtr thrown, IntPtr type, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern double java_interop_jnienv_call_static_double_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr type, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_call_static_void_method(IntPtr jnienv, out IntPtr thrown, IntPtr type, IntPtr method);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_call_static_void_method_a(IntPtr jnienv, out IntPtr thrown, IntPtr type, IntPtr method, IntPtr args);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_get_static_field_id(IntPtr jnienv, out IntPtr thrown, IntPtr type, string name, string signature);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_get_static_object_field(IntPtr jnienv, IntPtr type, IntPtr field);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern byte java_interop_jnienv_get_static_boolean_field(IntPtr jnienv, IntPtr type, IntPtr field);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern sbyte java_interop_jnienv_get_static_byte_field(IntPtr jnienv, IntPtr type, IntPtr field);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern char java_interop_jnienv_get_static_char_field(IntPtr jnienv, IntPtr type, IntPtr field);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern short java_interop_jnienv_get_static_short_field(IntPtr jnienv, IntPtr type, IntPtr field);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int java_interop_jnienv_get_static_int_field(IntPtr jnienv, IntPtr type, IntPtr field);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern long java_interop_jnienv_get_static_long_field(IntPtr jnienv, IntPtr type, IntPtr field);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern float java_interop_jnienv_get_static_float_field(IntPtr jnienv, IntPtr type, IntPtr field);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern double java_interop_jnienv_get_static_double_field(IntPtr jnienv, IntPtr type, IntPtr field);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_set_static_object_field(IntPtr jnienv, IntPtr type, IntPtr field, IntPtr value);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_set_static_boolean_field(IntPtr jnienv, IntPtr type, IntPtr field, byte value);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_set_static_byte_field(IntPtr jnienv, IntPtr type, IntPtr field, sbyte value);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_set_static_char_field(IntPtr jnienv, IntPtr type, IntPtr field, char value);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_set_static_short_field(IntPtr jnienv, IntPtr type, IntPtr field, short value);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_set_static_int_field(IntPtr jnienv, IntPtr type, IntPtr field, int value);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_set_static_long_field(IntPtr jnienv, IntPtr type, IntPtr field, long value);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_set_static_float_field(IntPtr jnienv, IntPtr type, IntPtr field, float value);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_set_static_double_field(IntPtr jnienv, IntPtr type, IntPtr field, double value);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern IntPtr java_interop_jnienv_new_string(IntPtr jnienv, out IntPtr thrown, char* unicodeChars, int length);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int java_interop_jnienv_get_string_length(IntPtr jnienv, IntPtr stringInstance);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern char* java_interop_jnienv_get_string_chars(IntPtr jnienv, IntPtr stringInstance, bool* isCopy);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_release_string_chars(IntPtr jnienv, IntPtr stringInstance, char* chars);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int java_interop_jnienv_get_array_length(IntPtr jnienv, IntPtr array);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_new_object_array(IntPtr jnienv, out IntPtr thrown, int length, IntPtr elementClass, IntPtr initialElement);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_get_object_array_element(IntPtr jnienv, out IntPtr thrown, IntPtr array, int index);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_set_object_array_element(IntPtr jnienv, out IntPtr thrown, IntPtr array, int index, IntPtr value);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_new_boolean_array(IntPtr jnienv, int length);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_new_byte_array(IntPtr jnienv, int length);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_new_char_array(IntPtr jnienv, int length);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_new_short_array(IntPtr jnienv, int length);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_new_int_array(IntPtr jnienv, int length);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_new_long_array(IntPtr jnienv, int length);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_new_float_array(IntPtr jnienv, int length);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_new_double_array(IntPtr jnienv, int length);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern bool* java_interop_jnienv_get_boolean_array_elements(IntPtr jnienv, IntPtr array, bool* isCopy);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern sbyte* java_interop_jnienv_get_byte_array_elements(IntPtr jnienv, IntPtr array, bool* isCopy);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern char* java_interop_jnienv_get_char_array_elements(IntPtr jnienv, IntPtr array, bool* isCopy);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern short* java_interop_jnienv_get_short_array_elements(IntPtr jnienv, IntPtr array, bool* isCopy);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern int* java_interop_jnienv_get_int_array_elements(IntPtr jnienv, IntPtr array, bool* isCopy);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern long* java_interop_jnienv_get_long_array_elements(IntPtr jnienv, IntPtr array, bool* isCopy);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern float* java_interop_jnienv_get_float_array_elements(IntPtr jnienv, IntPtr array, bool* isCopy);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern double* java_interop_jnienv_get_double_array_elements(IntPtr jnienv, IntPtr array, bool* isCopy);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_release_boolean_array_elements(IntPtr jnienv, IntPtr array, bool* elements, int mode);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_release_byte_array_elements(IntPtr jnienv, IntPtr array, sbyte* elements, int mode);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_release_char_array_elements(IntPtr jnienv, IntPtr array, char* elements, int mode);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_release_short_array_elements(IntPtr jnienv, IntPtr array, short* elements, int mode);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_release_int_array_elements(IntPtr jnienv, IntPtr array, int* elements, int mode);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_release_long_array_elements(IntPtr jnienv, IntPtr array, long* elements, int mode);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_release_float_array_elements(IntPtr jnienv, IntPtr array, float* elements, int mode);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_release_double_array_elements(IntPtr jnienv, IntPtr array, double* elements, int mode);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_get_boolean_array_region(IntPtr jnienv, out IntPtr thrown, IntPtr array, int start, int length, bool* buffer);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_get_byte_array_region(IntPtr jnienv, out IntPtr thrown, IntPtr array, int start, int length, sbyte* buffer);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_get_char_array_region(IntPtr jnienv, out IntPtr thrown, IntPtr array, int start, int length, char* buffer);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_get_short_array_region(IntPtr jnienv, out IntPtr thrown, IntPtr array, int start, int length, short* buffer);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_get_int_array_region(IntPtr jnienv, out IntPtr thrown, IntPtr array, int start, int length, int* buffer);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_get_long_array_region(IntPtr jnienv, out IntPtr thrown, IntPtr array, int start, int length, long* buffer);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_get_float_array_region(IntPtr jnienv, out IntPtr thrown, IntPtr array, int start, int length, float* buffer);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_get_double_array_region(IntPtr jnienv, out IntPtr thrown, IntPtr array, int start, int length, double* buffer);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_set_boolean_array_region(IntPtr jnienv, out IntPtr thrown, IntPtr array, int start, int length, bool* buffer);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_set_byte_array_region(IntPtr jnienv, out IntPtr thrown, IntPtr array, int start, int length, sbyte* buffer);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_set_char_array_region(IntPtr jnienv, out IntPtr thrown, IntPtr array, int start, int length, char* buffer);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_set_short_array_region(IntPtr jnienv, out IntPtr thrown, IntPtr array, int start, int length, short* buffer);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_set_int_array_region(IntPtr jnienv, out IntPtr thrown, IntPtr array, int start, int length, int* buffer);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_set_long_array_region(IntPtr jnienv, out IntPtr thrown, IntPtr array, int start, int length, long* buffer);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_set_float_array_region(IntPtr jnienv, out IntPtr thrown, IntPtr array, int start, int length, float* buffer);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal unsafe static extern void java_interop_jnienv_set_double_array_region(IntPtr jnienv, out IntPtr thrown, IntPtr array, int start, int length, double* buffer);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int java_interop_jnienv_register_natives(IntPtr jnienv, out IntPtr thrown, IntPtr type, JniNativeMethodRegistration[] methods, int numMethods);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int java_interop_jnienv_unregister_natives(IntPtr jnienv, IntPtr type);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern int java_interop_jnienv_get_java_vm(IntPtr jnienv, out IntPtr vm);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern void java_interop_jnienv_delete_weak_global_ref(IntPtr jnienv, IntPtr instance);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_new_direct_byte_buffer(IntPtr jnienv, out IntPtr thrown, IntPtr address, long capacity);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern IntPtr java_interop_jnienv_get_direct_buffer_address(IntPtr jnienv, IntPtr buffer);

		[DllImport("java-interop", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi)]
		internal static extern long java_interop_jnienv_get_direct_buffer_capacity(IntPtr jnienv, IntPtr buffer);
	}
}
