using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
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
using Java.Util;
using Java.Util.Concurrent;
using Kotlin.Coroutines;
using Kotlin.Jvm.Functions;
using Kotlin.Jvm.Internal;
using Kotlin.Ranges;
using Kotlin.Sequences;
using Microsoft.CodeAnalysis;
using Xamarin.KotlinX.Coroutines.Channels;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: NamespaceMapping(Java = "kotlinx.coroutines", Managed = "Xamarin.KotlinX.Coroutines")]
[assembly: NamespaceMapping(Java = "kotlinx.coroutines.channels", Managed = "Xamarin.KotlinX.Coroutines.Channels")]
[assembly: NamespaceMapping(Java = "kotlinx.coroutines.flow", Managed = "Xamarin.KotlinX.Coroutines.Flow")]
[assembly: NamespaceMapping(Java = "kotlinx.coroutines.intrinsics", Managed = "Xamarin.KotlinX.Coroutines.Intrinsics")]
[assembly: NamespaceMapping(Java = "kotlinx.coroutines.scheduling", Managed = "Xamarin.KotlinX.Coroutines.Scheduling")]
[assembly: NamespaceMapping(Java = "kotlinx.coroutines.selects", Managed = "Xamarin.KotlinX.Coroutines.Selects")]
[assembly: NamespaceMapping(Java = "kotlinx.coroutines.sync", Managed = "Xamarin.KotlinX.Coroutines.Sync")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.KotlinX.Coroutines.Core.Jvm")]
[assembly: AssemblyTitle("Xamarin.KotlinX.Coroutines.Core.Jvm")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/AndroidX.git")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
namespace Microsoft.CodeAnalysis
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	internal sealed class EmbeddedAttribute : Attribute
	{
	}
}
namespace System.Runtime.CompilerServices
{
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
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
	[CompilerGenerated]
	[Microsoft.CodeAnalysis.Embedded]
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Method | AttributeTargets.Interface | AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
	internal sealed class NullableContextAttribute : Attribute
	{
		public readonly byte Flag;

		public NullableContextAttribute(byte P_0)
		{
			Flag = P_0;
		}
	}
}
internal delegate int _JniMarshal_PP_I(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate IntPtr _JniMarshal_PPI_L(IntPtr jnienv, IntPtr klass, int p0);
internal delegate IntPtr _JniMarshal_PPJL_L(IntPtr jnienv, IntPtr klass, long p0, IntPtr p1);
internal delegate void _JniMarshal_PPJL_V(IntPtr jnienv, IntPtr klass, long p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPJLL_L(IntPtr jnienv, IntPtr klass, long p0, IntPtr p1, IntPtr p2);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate bool _JniMarshal_PPL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate IntPtr _JniMarshal_PPLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate void _JniMarshal_PPLL_V(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate bool _JniMarshal_PPLL_Z(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPLLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
namespace System.Runtime.Versioning
{
	[Conditional("NEVER")]
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Constructor | AttributeTargets.Method | AttributeTargets.Property | AttributeTargets.Event, AllowMultiple = true, Inherited = false)]
	internal sealed class SupportedOSPlatformAttribute : Attribute
	{
		public SupportedOSPlatformAttribute(string platformName)
		{
		}
	}
}
namespace Xamarin.KotlinX.Coroutines
{
	[Register("kotlinx/coroutines/AbstractTimeSourceKt", DoNotGenerateAcw = true)]
	public sealed class AbstractTimeSourceKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/AbstractTimeSourceKt", typeof(AbstractTimeSourceKt));

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

		internal AbstractTimeSourceKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/AwaitKt", DoNotGenerateAcw = true)]
	public sealed class AwaitKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/AwaitKt", typeof(AwaitKt));

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

		internal AwaitKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/BuildersKt", DoNotGenerateAcw = true)]
	public sealed class BuildersKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/BuildersKt", typeof(BuildersKt));

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

		internal BuildersKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("invoke", "(Lkotlinx/coroutines/CoroutineDispatcher;Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? Invoke(CoroutineDispatcher _this_invoke, IFunction2 block, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(_this_invoke?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				ptr[2] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("invoke.(Lkotlinx/coroutines/CoroutineDispatcher;Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_invoke);
				GC.KeepAlive(block);
				GC.KeepAlive(_completion);
			}
		}

		[Register("runBlocking", "(Lkotlin/coroutines/CoroutineContext;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? RunBlocking(ICoroutineContext context, IFunction2 block)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				ptr[1] = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("runBlocking.(Lkotlin/coroutines/CoroutineContext;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(block);
			}
		}

		[Register("withContext", "(Lkotlin/coroutines/CoroutineContext;Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? WithContext(ICoroutineContext context, IFunction2 block, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				ptr[1] = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				ptr[2] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("withContext.(Lkotlin/coroutines/CoroutineContext;Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(block);
				GC.KeepAlive(_completion);
			}
		}
	}
	[Register("kotlinx/coroutines/CancellableContinuationImplKt", DoNotGenerateAcw = true)]
	public sealed class CancellableContinuationImplKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CancellableContinuationImplKt", typeof(CancellableContinuationImplKt));

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

		internal CancellableContinuationImplKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/CancellableContinuationKt", DoNotGenerateAcw = true)]
	public sealed class CancellableContinuationKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CancellableContinuationKt", typeof(CancellableContinuationKt));

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

		internal CancellableContinuationKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("disposeOnCancellation", "(Lkotlinx/coroutines/CancellableContinuation;Lkotlinx/coroutines/DisposableHandle;)V", "")]
		public unsafe static void DisposeOnCancellation(ICancellableContinuation obj, IDisposableHandle handle)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				ptr[1] = new JniArgumentValue((handle == null) ? IntPtr.Zero : ((Java.Lang.Object)handle).Handle);
				_members.StaticMethods.InvokeVoidMethod("disposeOnCancellation.(Lkotlinx/coroutines/CancellableContinuation;Lkotlinx/coroutines/DisposableHandle;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(handle);
			}
		}

		[Register("suspendCancellableCoroutine", "(Lkotlin/jvm/functions/Function1;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? SuspendCancellableCoroutine(IFunction1 block, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				ptr[1] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("suspendCancellableCoroutine.(Lkotlin/jvm/functions/Function1;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(block);
				GC.KeepAlive(_completion);
			}
		}
	}
	[Register("kotlinx/coroutines/CompletableDeferredKt", DoNotGenerateAcw = true)]
	public sealed class CompletableDeferredKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CompletableDeferredKt", typeof(CompletableDeferredKt));

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

		internal CompletableDeferredKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/CompletionHandlerException", DoNotGenerateAcw = true)]
	public sealed class CompletionHandlerException : RuntimeException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CompletionHandlerException", typeof(CompletionHandlerException));

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

		internal CompletionHandlerException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/Throwable;)V", "")]
		public unsafe CompletionHandlerException(string message, Throwable cause)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/Throwable;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/Throwable;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(cause);
			}
		}
	}
	[Register("kotlinx/coroutines/CompletionHandlerKt", DoNotGenerateAcw = true)]
	public sealed class CompletionHandlerKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CompletionHandlerKt", typeof(CompletionHandlerKt));

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

		internal CompletionHandlerKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("getAsHandler", "(Ljava/lang/Object;)Lkotlin/jvm/functions/Function1;", "")]
		public unsafe static IFunction1 GetAsHandler(Java.Lang.Object obj)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IFunction1>(_members.StaticMethods.InvokeObjectMethod("getAsHandler.(Ljava/lang/Object;)Lkotlin/jvm/functions/Function1;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}
	}
	[Register("kotlinx/coroutines/CompletionHandler_commonKt", DoNotGenerateAcw = true)]
	public sealed class CompletionHandler_commonKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CompletionHandler_commonKt", typeof(CompletionHandler_commonKt));

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

		internal CompletionHandler_commonKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/CompletionStateKt", DoNotGenerateAcw = true)]
	public sealed class CompletionStateKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CompletionStateKt", typeof(CompletionStateKt));

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

		internal CompletionStateKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/CoroutineContextKt", DoNotGenerateAcw = true)]
	public sealed class CoroutineContextKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CoroutineContextKt", typeof(CoroutineContextKt));

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

		internal CoroutineContextKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("getCoroutineName", "(Lkotlin/coroutines/CoroutineContext;)Ljava/lang/String;", "")]
		public unsafe static string? GetCoroutineName(ICoroutineContext obj)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getCoroutineName.(Lkotlin/coroutines/CoroutineContext;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}

		[Register("newCoroutineContext", "(Lkotlin/coroutines/CoroutineContext;Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;", "")]
		public unsafe static ICoroutineContext NewCoroutineContext(ICoroutineContext obj, ICoroutineContext addedContext)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				ptr[1] = new JniArgumentValue((addedContext == null) ? IntPtr.Zero : ((Java.Lang.Object)addedContext).Handle);
				return Java.Lang.Object.GetObject<ICoroutineContext>(_members.StaticMethods.InvokeObjectMethod("newCoroutineContext.(Lkotlin/coroutines/CoroutineContext;Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(addedContext);
			}
		}

		[Register("newCoroutineContext", "(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;", "")]
		public unsafe static ICoroutineContext NewCoroutineContext(ICoroutineScope obj, ICoroutineContext context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				ptr[1] = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				return Java.Lang.Object.GetObject<ICoroutineContext>(_members.StaticMethods.InvokeObjectMethod("newCoroutineContext.(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(context);
			}
		}
	}
	[Register("kotlinx/coroutines/CoroutineDispatcher", DoNotGenerateAcw = true)]
	public abstract class CoroutineDispatcher : AbstractCoroutineContextElement, IContinuationInterceptor, ICoroutineContextElement, ICoroutineContext, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CoroutineDispatcher", typeof(CoroutineDispatcher));

		private static Delegate? cb_dispatch_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Runnable_;

		private static Delegate? cb_dispatchYield_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Runnable_;

		private static Delegate? cb_get_Lkotlin_coroutines_CoroutineContext_Key_;

		private static Delegate? cb_isDispatchNeeded_Lkotlin_coroutines_CoroutineContext_;

		private static Delegate? cb_limitedParallelism_I;

		private static Delegate? cb_minusKey_Lkotlin_coroutines_CoroutineContext_Key_;

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

		protected CoroutineDispatcher(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe CoroutineDispatcher()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetDispatch_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Runnable_Handler()
		{
			if ((object)cb_dispatch_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Runnable_ == null)
			{
				cb_dispatch_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Runnable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_Dispatch_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Runnable_));
			}
			return cb_dispatch_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Runnable_;
		}

		private static void n_Dispatch_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Runnable_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_block)
		{
			CoroutineDispatcher coroutineDispatcher = Java.Lang.Object.GetObject<CoroutineDispatcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContext context = Java.Lang.Object.GetObject<ICoroutineContext>(native_context, JniHandleOwnership.DoNotTransfer);
			IRunnable block = Java.Lang.Object.GetObject<IRunnable>(native_block, JniHandleOwnership.DoNotTransfer);
			coroutineDispatcher.Dispatch(context, block);
		}

		[Register("dispatch", "(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V", "GetDispatch_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Runnable_Handler")]
		public abstract void Dispatch(ICoroutineContext context, IRunnable block);

		private static Delegate GetDispatchYield_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Runnable_Handler()
		{
			if ((object)cb_dispatchYield_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Runnable_ == null)
			{
				cb_dispatchYield_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Runnable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_DispatchYield_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Runnable_));
			}
			return cb_dispatchYield_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Runnable_;
		}

		private static void n_DispatchYield_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Runnable_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_block)
		{
			CoroutineDispatcher coroutineDispatcher = Java.Lang.Object.GetObject<CoroutineDispatcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContext context = Java.Lang.Object.GetObject<ICoroutineContext>(native_context, JniHandleOwnership.DoNotTransfer);
			IRunnable block = Java.Lang.Object.GetObject<IRunnable>(native_block, JniHandleOwnership.DoNotTransfer);
			coroutineDispatcher.DispatchYield(context, block);
		}

		[Register("dispatchYield", "(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V", "GetDispatchYield_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Runnable_Handler")]
		public unsafe virtual void DispatchYield(ICoroutineContext context, IRunnable block)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				ptr[1] = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("dispatchYield.(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(block);
			}
		}

		private static Delegate GetGet_Lkotlin_coroutines_CoroutineContext_Key_Handler()
		{
			if ((object)cb_get_Lkotlin_coroutines_CoroutineContext_Key_ == null)
			{
				cb_get_Lkotlin_coroutines_CoroutineContext_Key_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Get_Lkotlin_coroutines_CoroutineContext_Key_));
			}
			return cb_get_Lkotlin_coroutines_CoroutineContext_Key_;
		}

		private static IntPtr n_Get_Lkotlin_coroutines_CoroutineContext_Key_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			CoroutineDispatcher coroutineDispatcher = Java.Lang.Object.GetObject<CoroutineDispatcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContextKey key = Java.Lang.Object.GetObject<ICoroutineContextKey>(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(coroutineDispatcher.Get(key));
		}

		[Register("get", "(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;", "GetGet_Lkotlin_coroutines_CoroutineContext_Key_Handler")]
		[JavaTypeParameters(new string[] { "E extends kotlin.coroutines.CoroutineContext.Element" })]
		public unsafe override Java.Lang.Object? Get(ICoroutineContextKey key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((key == null) ? IntPtr.Zero : ((Java.Lang.Object)key).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(key);
			}
		}

		[Register("interceptContinuation", "(Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe IContinuation InterceptContinuation(IContinuation continuation)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((continuation == null) ? IntPtr.Zero : ((Java.Lang.Object)continuation).Handle);
				return Java.Lang.Object.GetObject<IContinuation>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("interceptContinuation.(Lkotlin/coroutines/Continuation;)Lkotlin/coroutines/Continuation;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(continuation);
			}
		}

		private static Delegate GetIsDispatchNeeded_Lkotlin_coroutines_CoroutineContext_Handler()
		{
			if ((object)cb_isDispatchNeeded_Lkotlin_coroutines_CoroutineContext_ == null)
			{
				cb_isDispatchNeeded_Lkotlin_coroutines_CoroutineContext_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_IsDispatchNeeded_Lkotlin_coroutines_CoroutineContext_));
			}
			return cb_isDispatchNeeded_Lkotlin_coroutines_CoroutineContext_;
		}

		private static bool n_IsDispatchNeeded_Lkotlin_coroutines_CoroutineContext_(IntPtr jnienv, IntPtr native__this, IntPtr native_context)
		{
			CoroutineDispatcher coroutineDispatcher = Java.Lang.Object.GetObject<CoroutineDispatcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContext context = Java.Lang.Object.GetObject<ICoroutineContext>(native_context, JniHandleOwnership.DoNotTransfer);
			return coroutineDispatcher.IsDispatchNeeded(context);
		}

		[Register("isDispatchNeeded", "(Lkotlin/coroutines/CoroutineContext;)Z", "GetIsDispatchNeeded_Lkotlin_coroutines_CoroutineContext_Handler")]
		public unsafe virtual bool IsDispatchNeeded(ICoroutineContext context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isDispatchNeeded.(Lkotlin/coroutines/CoroutineContext;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetLimitedParallelism_IHandler()
		{
			if ((object)cb_limitedParallelism_I == null)
			{
				cb_limitedParallelism_I = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPI_L(n_LimitedParallelism_I));
			}
			return cb_limitedParallelism_I;
		}

		private static IntPtr n_LimitedParallelism_I(IntPtr jnienv, IntPtr native__this, int parallelism)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<CoroutineDispatcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LimitedParallelism(parallelism));
		}

		[Register("limitedParallelism", "(I)Lkotlinx/coroutines/CoroutineDispatcher;", "GetLimitedParallelism_IHandler")]
		public unsafe virtual CoroutineDispatcher LimitedParallelism(int parallelism)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(parallelism);
			return Java.Lang.Object.GetObject<CoroutineDispatcher>(_members.InstanceMethods.InvokeVirtualObjectMethod("limitedParallelism.(I)Lkotlinx/coroutines/CoroutineDispatcher;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetMinusKey_Lkotlin_coroutines_CoroutineContext_Key_Handler()
		{
			if ((object)cb_minusKey_Lkotlin_coroutines_CoroutineContext_Key_ == null)
			{
				cb_minusKey_Lkotlin_coroutines_CoroutineContext_Key_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_MinusKey_Lkotlin_coroutines_CoroutineContext_Key_));
			}
			return cb_minusKey_Lkotlin_coroutines_CoroutineContext_Key_;
		}

		private static IntPtr n_MinusKey_Lkotlin_coroutines_CoroutineContext_Key_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			CoroutineDispatcher coroutineDispatcher = Java.Lang.Object.GetObject<CoroutineDispatcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContextKey key = Java.Lang.Object.GetObject<ICoroutineContextKey>(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(coroutineDispatcher.MinusKey(key));
		}

		[Register("minusKey", "(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext;", "GetMinusKey_Lkotlin_coroutines_CoroutineContext_Key_Handler")]
		public unsafe override ICoroutineContext MinusKey(ICoroutineContextKey key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((key == null) ? IntPtr.Zero : ((Java.Lang.Object)key).Handle);
				return Java.Lang.Object.GetObject<ICoroutineContext>(_members.InstanceMethods.InvokeVirtualObjectMethod("minusKey.(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(key);
			}
		}

		[Obsolete("deprecated")]
		[Register("plus", "(Lkotlinx/coroutines/CoroutineDispatcher;)Lkotlinx/coroutines/CoroutineDispatcher;", "")]
		public unsafe CoroutineDispatcher Plus(CoroutineDispatcher other)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<CoroutineDispatcher>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("plus.(Lkotlinx/coroutines/CoroutineDispatcher;)Lkotlinx/coroutines/CoroutineDispatcher;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(other);
			}
		}

		[Register("releaseInterceptedContinuation", "(Lkotlin/coroutines/Continuation;)V", "")]
		public unsafe void ReleaseInterceptedContinuation(IContinuation continuation)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((continuation == null) ? IntPtr.Zero : ((Java.Lang.Object)continuation).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("releaseInterceptedContinuation.(Lkotlin/coroutines/Continuation;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(continuation);
			}
		}
	}
	[Register("kotlinx/coroutines/CoroutineDispatcher", DoNotGenerateAcw = true)]
	internal class CoroutineDispatcherInvoker : CoroutineDispatcher
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CoroutineDispatcher", typeof(CoroutineDispatcherInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public CoroutineDispatcherInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("dispatch", "(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V", "GetDispatch_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Runnable_Handler")]
		public unsafe override void Dispatch(ICoroutineContext context, IRunnable block)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				ptr[1] = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("dispatch.(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(block);
			}
		}
	}
	[Register("kotlinx/coroutines/CoroutineExceptionHandlerImplKt", DoNotGenerateAcw = true)]
	public sealed class CoroutineExceptionHandlerImplKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CoroutineExceptionHandlerImplKt", typeof(CoroutineExceptionHandlerImplKt));

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

		internal CoroutineExceptionHandlerImplKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/CoroutineExceptionHandlerKt", DoNotGenerateAcw = true)]
	public sealed class CoroutineExceptionHandlerKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CoroutineExceptionHandlerKt", typeof(CoroutineExceptionHandlerKt));

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

		internal CoroutineExceptionHandlerKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("CoroutineExceptionHandler", "(Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/CoroutineExceptionHandler;", "")]
		public unsafe static ICoroutineExceptionHandler CoroutineExceptionHandler(IFunction2 handler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((handler == null) ? IntPtr.Zero : ((Java.Lang.Object)handler).Handle);
				return Java.Lang.Object.GetObject<ICoroutineExceptionHandler>(_members.StaticMethods.InvokeObjectMethod("CoroutineExceptionHandler.(Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/CoroutineExceptionHandler;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(handler);
			}
		}

		[Register("handleCoroutineException", "(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Throwable;)V", "")]
		public unsafe static void HandleCoroutineException(ICoroutineContext context, Throwable exception)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				ptr[1] = new JniArgumentValue(exception?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("handleCoroutineException.(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Throwable;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(exception);
			}
		}
	}
	[Register("kotlinx/coroutines/CoroutineName", DoNotGenerateAcw = true)]
	public sealed class CoroutineName : AbstractCoroutineContextElement
	{
		[Register("kotlinx/coroutines/CoroutineName$Key", DoNotGenerateAcw = true)]
		public new sealed class Key : Java.Lang.Object, ICoroutineContextKey, IJavaObject, IDisposable, IJavaPeerable
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CoroutineName$Key", typeof(Key));

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

			internal Key(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Key(DefaultConstructorMarker? _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CoroutineName", typeof(CoroutineName));

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

		public unsafe string Name
		{
			[Register("getName", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal CoroutineName(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe CoroutineName(string name)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(name);
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

		[Register("component1", "()Ljava/lang/String;", "")]
		public unsafe string Component1()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("component1.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("copy", "(Ljava/lang/String;)Lkotlinx/coroutines/CoroutineName;", "")]
		public unsafe CoroutineName Copy(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<CoroutineName>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("copy.(Ljava/lang/String;)Lkotlinx/coroutines/CoroutineName;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("kotlinx/coroutines/CoroutineScopeKt", DoNotGenerateAcw = true)]
	public sealed class CoroutineScopeKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CoroutineScopeKt", typeof(CoroutineScopeKt));

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

		internal CoroutineScopeKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("CoroutineScope", "(Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/CoroutineScope;", "")]
		public unsafe static ICoroutineScope CoroutineScope(ICoroutineContext context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				return Java.Lang.Object.GetObject<ICoroutineScope>(_members.StaticMethods.InvokeObjectMethod("CoroutineScope.(Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/CoroutineScope;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		[Register("MainScope", "()Lkotlinx/coroutines/CoroutineScope;", "")]
		public unsafe static ICoroutineScope MainScope()
		{
			return Java.Lang.Object.GetObject<ICoroutineScope>(_members.StaticMethods.InvokeObjectMethod("MainScope.()Lkotlinx/coroutines/CoroutineScope;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("cancel", "(Lkotlinx/coroutines/CoroutineScope;Ljava/lang/String;Ljava/lang/Throwable;)V", "")]
		public unsafe static void Cancel(ICoroutineScope obj, string message, Throwable? cause)
		{
			IntPtr intPtr = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("cancel.(Lkotlinx/coroutines/CoroutineScope;Ljava/lang/String;Ljava/lang/Throwable;)V", ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(obj);
				GC.KeepAlive(cause);
			}
		}

		[Register("cancel", "(Lkotlinx/coroutines/CoroutineScope;Ljava/util/concurrent/CancellationException;)V", "")]
		public unsafe static void Cancel(ICoroutineScope obj, CancellationException? cause)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				ptr[1] = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("cancel.(Lkotlinx/coroutines/CoroutineScope;Ljava/util/concurrent/CancellationException;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(cause);
			}
		}

		[Register("coroutineScope", "(Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "R" })]
		public unsafe static Java.Lang.Object? CoroutineScope(IFunction2 block, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				ptr[1] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("coroutineScope.(Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(block);
				GC.KeepAlive(_completion);
			}
		}

		[Register("currentCoroutineContext", "(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		public unsafe static Java.Lang.Object? CurrentCoroutineContext(IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("currentCoroutineContext.(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_completion);
			}
		}

		[Register("ensureActive", "(Lkotlinx/coroutines/CoroutineScope;)V", "")]
		public unsafe static void EnsureActive(ICoroutineScope obj)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				_members.StaticMethods.InvokeVoidMethod("ensureActive.(Lkotlinx/coroutines/CoroutineScope;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}

		[Register("isActive", "(Lkotlinx/coroutines/CoroutineScope;)Z", "")]
		public unsafe static bool IsActive(ICoroutineScope obj)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				return _members.StaticMethods.InvokeBooleanMethod("isActive.(Lkotlinx/coroutines/CoroutineScope;)Z", ptr);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}

		[Register("plus", "(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/CoroutineScope;", "")]
		public unsafe static ICoroutineScope Plus(ICoroutineScope obj, ICoroutineContext context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				ptr[1] = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				return Java.Lang.Object.GetObject<ICoroutineScope>(_members.StaticMethods.InvokeObjectMethod("plus.(Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/CoroutineScope;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(context);
			}
		}
	}
	[Register("kotlinx/coroutines/CoroutineStart", DoNotGenerateAcw = true)]
	public sealed class CoroutineStart : Java.Lang.Enum
	{
		[Register("kotlinx/coroutines/CoroutineStart$WhenMappings", DoNotGenerateAcw = true)]
		public sealed class WhenMappings : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CoroutineStart$WhenMappings", typeof(WhenMappings));

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

			internal WhenMappings(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CoroutineStart", typeof(CoroutineStart));

		[Register("ATOMIC")]
		public static CoroutineStart? Atomic => Java.Lang.Object.GetObject<CoroutineStart>(_members.StaticFields.GetObjectValue("ATOMIC.Lkotlinx/coroutines/CoroutineStart;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DEFAULT")]
		public static CoroutineStart? Default => Java.Lang.Object.GetObject<CoroutineStart>(_members.StaticFields.GetObjectValue("DEFAULT.Lkotlinx/coroutines/CoroutineStart;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("LAZY")]
		public static CoroutineStart? Lazy => Java.Lang.Object.GetObject<CoroutineStart>(_members.StaticFields.GetObjectValue("LAZY.Lkotlinx/coroutines/CoroutineStart;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UNDISPATCHED")]
		public static CoroutineStart? Undispatched => Java.Lang.Object.GetObject<CoroutineStart>(_members.StaticFields.GetObjectValue("UNDISPATCHED.Lkotlinx/coroutines/CoroutineStart;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe bool IsLazy
		{
			[Register("isLazy", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isLazy.()Z", this, null);
			}
		}

		internal CoroutineStart(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("invoke", "(Lkotlin/jvm/functions/Function1;Lkotlin/coroutines/Continuation;)V", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe void Invoke(IFunction1 block, IContinuation completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				ptr[1] = new JniArgumentValue((completion == null) ? IntPtr.Zero : ((Java.Lang.Object)completion).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("invoke.(Lkotlin/jvm/functions/Function1;Lkotlin/coroutines/Continuation;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(block);
				GC.KeepAlive(completion);
			}
		}

		[Register("invoke", "(Lkotlin/jvm/functions/Function2;Ljava/lang/Object;Lkotlin/coroutines/Continuation;)V", "")]
		[JavaTypeParameters(new string[] { "R", "T" })]
		public unsafe void Invoke(IFunction2 block, Java.Lang.Object? receiver, IContinuation completion)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(receiver);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((completion == null) ? IntPtr.Zero : ((Java.Lang.Object)completion).Handle);
				_members.InstanceMethods.InvokeNonvirtualVoidMethod("invoke.(Lkotlin/jvm/functions/Function2;Ljava/lang/Object;Lkotlin/coroutines/Continuation;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(block);
				GC.KeepAlive(receiver);
				GC.KeepAlive(completion);
			}
		}

		[Register("valueOf", "(Ljava/lang/String;)Lkotlinx/coroutines/CoroutineStart;", "")]
		public unsafe static CoroutineStart? ValueOf(string? value)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<CoroutineStart>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lkotlinx/coroutines/CoroutineStart;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lkotlinx/coroutines/CoroutineStart;", "")]
		public unsafe static CoroutineStart[]? Values()
		{
			return (CoroutineStart[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lkotlinx/coroutines/CoroutineStart;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(CoroutineStart));
		}
	}
	[Register("kotlinx/coroutines/DebugKt", DoNotGenerateAcw = true)]
	public sealed class DebugKt : Java.Lang.Object
	{
		[Register("DEBUG_PROPERTY_NAME")]
		public const string DebugPropertyName = "kotlinx.coroutines.debug";

		[Register("DEBUG_PROPERTY_VALUE_AUTO")]
		public const string DebugPropertyValueAuto = "auto";

		[Register("DEBUG_PROPERTY_VALUE_OFF")]
		public const string DebugPropertyValueOff = "off";

		[Register("DEBUG_PROPERTY_VALUE_ON")]
		public const string DebugPropertyValueOn = "on";

		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/DebugKt", typeof(DebugKt));

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

		internal DebugKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/DebugStringsKt", DoNotGenerateAcw = true)]
	public sealed class DebugStringsKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/DebugStringsKt", typeof(DebugStringsKt));

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

		internal DebugStringsKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("getClassSimpleName", "(Ljava/lang/Object;)Ljava/lang/String;", "")]
		public unsafe static string GetClassSimpleName(Java.Lang.Object obj)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getClassSimpleName.(Ljava/lang/Object;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}

		[Register("getHexAddress", "(Ljava/lang/Object;)Ljava/lang/String;", "")]
		public unsafe static string GetHexAddress(Java.Lang.Object obj)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				return JNIEnv.GetString(_members.StaticMethods.InvokeObjectMethod("getHexAddress.(Ljava/lang/Object;)Ljava/lang/String;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}
	}
	[Register("kotlinx/coroutines/DefaultExecutorKt", DoNotGenerateAcw = true)]
	public sealed class DefaultExecutorKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/DefaultExecutorKt", typeof(DefaultExecutorKt));

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

		internal DefaultExecutorKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/DelayKt", DoNotGenerateAcw = true)]
	public sealed class DelayKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/DelayKt", typeof(DelayKt));

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

		internal DelayKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("awaitCancellation", "(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		public unsafe static Java.Lang.Object? AwaitCancellation(IContinuation p0)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("awaitCancellation.(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
			}
		}

		[Register("delay", "(JLkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		public unsafe static Java.Lang.Object? Delay(long timeMillis, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(timeMillis);
				ptr[1] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("delay.(JLkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_completion);
			}
		}

		[Register("getDelay", "(Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/Delay;", "")]
		public unsafe static IDelay GetDelay(ICoroutineContext obj)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				return Java.Lang.Object.GetObject<IDelay>(_members.StaticMethods.InvokeObjectMethod("getDelay.(Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/Delay;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}
	}
	[Annotation("kotlinx.coroutines.DelicateCoroutinesApi")]
	public class DelicateCoroutinesApiAttribute : Attribute
	{
	}
	[Register("kotlinx/coroutines/DispatchedTaskKt", DoNotGenerateAcw = true)]
	public sealed class DispatchedTaskKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/DispatchedTaskKt", typeof(DispatchedTaskKt));

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

		internal DispatchedTaskKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("isCancellableMode", "(I)Z", "")]
		public unsafe static bool IsCancellableMode(int obj)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(obj);
			return _members.StaticMethods.InvokeBooleanMethod("isCancellableMode.(I)Z", ptr);
		}

		[Register("isReusableMode", "(I)Z", "")]
		public unsafe static bool IsReusableMode(int obj)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(obj);
			return _members.StaticMethods.InvokeBooleanMethod("isReusableMode.(I)Z", ptr);
		}
	}
	[Register("kotlinx/coroutines/Dispatchers", DoNotGenerateAcw = true)]
	public sealed class Dispatchers : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/Dispatchers", typeof(Dispatchers));

		[Register("INSTANCE")]
		public static Dispatchers Instance => Java.Lang.Object.GetObject<Dispatchers>(_members.StaticFields.GetObjectValue("INSTANCE.Lkotlinx/coroutines/Dispatchers;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe static CoroutineDispatcher Default
		{
			[Register("getDefault", "()Lkotlinx/coroutines/CoroutineDispatcher;", "")]
			get
			{
				return Java.Lang.Object.GetObject<CoroutineDispatcher>(_members.StaticMethods.InvokeObjectMethod("getDefault.()Lkotlinx/coroutines/CoroutineDispatcher;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe static CoroutineDispatcher IO
		{
			[Register("getIO", "()Lkotlinx/coroutines/CoroutineDispatcher;", "")]
			get
			{
				return Java.Lang.Object.GetObject<CoroutineDispatcher>(_members.StaticMethods.InvokeObjectMethod("getIO.()Lkotlinx/coroutines/CoroutineDispatcher;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe static MainCoroutineDispatcher Main
		{
			[Register("getMain", "()Lkotlinx/coroutines/MainCoroutineDispatcher;", "")]
			get
			{
				return Java.Lang.Object.GetObject<MainCoroutineDispatcher>(_members.StaticMethods.InvokeObjectMethod("getMain.()Lkotlinx/coroutines/MainCoroutineDispatcher;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe static CoroutineDispatcher Unconfined
		{
			[Register("getUnconfined", "()Lkotlinx/coroutines/CoroutineDispatcher;", "")]
			get
			{
				return Java.Lang.Object.GetObject<CoroutineDispatcher>(_members.StaticMethods.InvokeObjectMethod("getUnconfined.()Lkotlinx/coroutines/CoroutineDispatcher;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal Dispatchers(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("shutdown", "()V", "")]
		public unsafe void Shutdown()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("shutdown.()V", this, null);
		}
	}
	[Register("kotlinx/coroutines/DispatchersKt", DoNotGenerateAcw = true)]
	public sealed class DispatchersKt : Java.Lang.Object
	{
		[Register("IO_PARALLELISM_PROPERTY_NAME")]
		public const string IoParallelismPropertyName = "kotlinx.coroutines.io.parallelism";

		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/DispatchersKt", typeof(DispatchersKt));

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

		internal DispatchersKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/EventLoopKt", DoNotGenerateAcw = true)]
	public sealed class EventLoopKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/EventLoopKt", typeof(EventLoopKt));

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

		internal EventLoopKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("processNextEventInCurrentThread", "()J", "")]
		public unsafe static long ProcessNextEventInCurrentThread()
		{
			return _members.StaticMethods.InvokeInt64Method("processNextEventInCurrentThread.()J", null);
		}
	}
	[Register("kotlinx/coroutines/EventLoop_commonKt", DoNotGenerateAcw = true)]
	public sealed class EventLoop_commonKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/EventLoop_commonKt", typeof(EventLoop_commonKt));

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

		internal EventLoop_commonKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/ExceptionsKt", DoNotGenerateAcw = true)]
	public sealed class ExceptionsKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/ExceptionsKt", typeof(ExceptionsKt));

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

		internal ExceptionsKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("CancellationException", "(Ljava/lang/String;Ljava/lang/Throwable;)Ljava/util/concurrent/CancellationException;", "")]
		public unsafe static CancellationException CancellationException(string? message, Throwable? cause)
		{
			IntPtr intPtr = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<CancellationException>(_members.StaticMethods.InvokeObjectMethod("CancellationException.(Ljava/lang/String;Ljava/lang/Throwable;)Ljava/util/concurrent/CancellationException;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(cause);
			}
		}
	}
	[Register("kotlinx/coroutines/ExecutorCoroutineDispatcher", DoNotGenerateAcw = true)]
	public abstract class ExecutorCoroutineDispatcher : CoroutineDispatcher, ICloseable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/ExecutorCoroutineDispatcher", typeof(ExecutorCoroutineDispatcher));

		private static Delegate? cb_getExecutor;

		private static Delegate? cb_close;

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

		public abstract IExecutor Executor
		{
			[Register("getExecutor", "()Ljava/util/concurrent/Executor;", "GetGetExecutorHandler")]
			get;
		}

		protected ExecutorCoroutineDispatcher(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ExecutorCoroutineDispatcher()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetExecutorHandler()
		{
			if ((object)cb_getExecutor == null)
			{
				cb_getExecutor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetExecutor));
			}
			return cb_getExecutor;
		}

		private static IntPtr n_GetExecutor(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ExecutorCoroutineDispatcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Executor);
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
			Java.Lang.Object.GetObject<ExecutorCoroutineDispatcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Close();
		}

		[Register("close", "()V", "GetCloseHandler")]
		public abstract void Close();
	}
	[Register("kotlinx/coroutines/ExecutorCoroutineDispatcher", DoNotGenerateAcw = true)]
	internal class ExecutorCoroutineDispatcherInvoker : ExecutorCoroutineDispatcher
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/ExecutorCoroutineDispatcher", typeof(ExecutorCoroutineDispatcherInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override IExecutor Executor
		{
			[Register("getExecutor", "()Ljava/util/concurrent/Executor;", "GetGetExecutorHandler")]
			get
			{
				return Java.Lang.Object.GetObject<IExecutor>(_members.InstanceMethods.InvokeAbstractObjectMethod("getExecutor.()Ljava/util/concurrent/Executor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public ExecutorCoroutineDispatcherInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("close", "()V", "GetCloseHandler")]
		public unsafe override void Close()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("close.()V", this, null);
		}

		[Register("dispatch", "(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V", "GetDispatch_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Runnable_Handler")]
		public unsafe override void Dispatch(ICoroutineContext context, IRunnable block)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				ptr[1] = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("dispatch.(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(block);
			}
		}
	}
	[Register("kotlinx/coroutines/ExecutorsKt", DoNotGenerateAcw = true)]
	public sealed class ExecutorsKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/ExecutorsKt", typeof(ExecutorsKt));

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

		internal ExecutorsKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("asExecutor", "(Lkotlinx/coroutines/CoroutineDispatcher;)Ljava/util/concurrent/Executor;", "")]
		public unsafe static IExecutor AsExecutor(CoroutineDispatcher obj)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IExecutor>(_members.StaticMethods.InvokeObjectMethod("asExecutor.(Lkotlinx/coroutines/CoroutineDispatcher;)Ljava/util/concurrent/Executor;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}

		[Register("from", "(Ljava/util/concurrent/Executor;)Lkotlinx/coroutines/CoroutineDispatcher;", "")]
		public unsafe static CoroutineDispatcher From(IExecutor obj)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				return Java.Lang.Object.GetObject<CoroutineDispatcher>(_members.StaticMethods.InvokeObjectMethod("from.(Ljava/util/concurrent/Executor;)Lkotlinx/coroutines/CoroutineDispatcher;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}

		[Register("from", "(Ljava/util/concurrent/ExecutorService;)Lkotlinx/coroutines/ExecutorCoroutineDispatcher;", "")]
		public unsafe static ExecutorCoroutineDispatcher From(IExecutorService obj)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				return Java.Lang.Object.GetObject<ExecutorCoroutineDispatcher>(_members.StaticMethods.InvokeObjectMethod("from.(Ljava/util/concurrent/ExecutorService;)Lkotlinx/coroutines/ExecutorCoroutineDispatcher;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}
	}
	[Annotation("kotlinx.coroutines.ExperimentalCoroutinesApi")]
	public class ExperimentalCoroutinesApiAttribute : Attribute
	{
	}
	[Annotation("kotlinx.coroutines.FlowPreview")]
	public class FlowPreviewAttribute : Attribute
	{
	}
	[Register("kotlinx/coroutines/GlobalScope", DoNotGenerateAcw = true)]
	public sealed class GlobalScope : Java.Lang.Object, ICoroutineScope, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/GlobalScope", typeof(GlobalScope));

		[Register("INSTANCE")]
		public static GlobalScope Instance => Java.Lang.Object.GetObject<GlobalScope>(_members.StaticFields.GetObjectValue("INSTANCE.Lkotlinx/coroutines/GlobalScope;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe ICoroutineContext CoroutineContext
		{
			[Register("getCoroutineContext", "()Lkotlin/coroutines/CoroutineContext;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ICoroutineContext>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCoroutineContext.()Lkotlin/coroutines/CoroutineContext;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal GlobalScope(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/CancellableContinuation$DefaultImpls", DoNotGenerateAcw = true)]
	public sealed class CancellableContinuationDefaultImpls : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CancellableContinuation$DefaultImpls", typeof(CancellableContinuationDefaultImpls));

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

		internal CancellableContinuationDefaultImpls(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/CancellableContinuation", "", "Xamarin.KotlinX.Coroutines.ICancellableContinuationInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface ICancellableContinuation : IContinuation, IJavaObject, IDisposable, IJavaPeerable
	{
		bool IsActive
		{
			[Register("isActive", "()Z", "GetIsActiveHandler:Xamarin.KotlinX.Coroutines.ICancellableContinuationInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
			get;
		}

		bool IsCancelled
		{
			[Register("isCancelled", "()Z", "GetIsCancelledHandler:Xamarin.KotlinX.Coroutines.ICancellableContinuationInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
			get;
		}

		bool IsCompleted
		{
			[Register("isCompleted", "()Z", "GetIsCompletedHandler:Xamarin.KotlinX.Coroutines.ICancellableContinuationInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
			get;
		}

		[Register("cancel", "(Ljava/lang/Throwable;)Z", "GetCancel_Ljava_lang_Throwable_Handler:Xamarin.KotlinX.Coroutines.ICancellableContinuationInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		bool Cancel(Throwable? cause);

		[Register("completeResume", "(Ljava/lang/Object;)V", "GetCompleteResume_Ljava_lang_Object_Handler:Xamarin.KotlinX.Coroutines.ICancellableContinuationInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		void CompleteResume(Java.Lang.Object token);

		[Register("initCancellability", "()V", "GetInitCancellabilityHandler:Xamarin.KotlinX.Coroutines.ICancellableContinuationInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		void InitCancellability();

		[Register("invokeOnCancellation", "(Lkotlin/jvm/functions/Function1;)V", "GetInvokeOnCancellation_Lkotlin_jvm_functions_Function1_Handler:Xamarin.KotlinX.Coroutines.ICancellableContinuationInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		void InvokeOnCancellation(IFunction1 handler);

		[Register("resume", "(Ljava/lang/Object;Lkotlin/jvm/functions/Function1;)V", "GetResume_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_Handler:Xamarin.KotlinX.Coroutines.ICancellableContinuationInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		void Resume(Java.Lang.Object? value, IFunction1? onCancellation);

		[Register("resumeUndispatched", "(Lkotlinx/coroutines/CoroutineDispatcher;Ljava/lang/Object;)V", "GetResumeUndispatched_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Object_Handler:Xamarin.KotlinX.Coroutines.ICancellableContinuationInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		void ResumeUndispatched(CoroutineDispatcher p0, Java.Lang.Object? value);

		[Register("resumeUndispatchedWithException", "(Lkotlinx/coroutines/CoroutineDispatcher;Ljava/lang/Throwable;)V", "GetResumeUndispatchedWithException_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Throwable_Handler:Xamarin.KotlinX.Coroutines.ICancellableContinuationInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		void ResumeUndispatchedWithException(CoroutineDispatcher p0, Throwable exception);

		[Register("tryResume", "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;", "GetTryResume_Ljava_lang_Object_Ljava_lang_Object_Handler:Xamarin.KotlinX.Coroutines.ICancellableContinuationInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		Java.Lang.Object? TryResume(Java.Lang.Object? value, Java.Lang.Object? idempotent);

		[Register("tryResume", "(Ljava/lang/Object;Ljava/lang/Object;Lkotlin/jvm/functions/Function1;)Ljava/lang/Object;", "GetTryResume_Ljava_lang_Object_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_Handler:Xamarin.KotlinX.Coroutines.ICancellableContinuationInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		Java.Lang.Object? TryResume(Java.Lang.Object? value, Java.Lang.Object? idempotent, IFunction1? onCancellation);

		[Register("tryResumeWithException", "(Ljava/lang/Throwable;)Ljava/lang/Object;", "GetTryResumeWithException_Ljava_lang_Throwable_Handler:Xamarin.KotlinX.Coroutines.ICancellableContinuationInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		Java.Lang.Object? TryResumeWithException(Throwable exception);
	}
	[Register("kotlinx/coroutines/CancellableContinuation", DoNotGenerateAcw = true)]
	internal class ICancellableContinuationInvoker : Java.Lang.Object, ICancellableContinuation, IContinuation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CancellableContinuation", typeof(ICancellableContinuationInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_isActive;

		private IntPtr id_isActive;

		private static Delegate? cb_isCancelled;

		private IntPtr id_isCancelled;

		private static Delegate? cb_isCompleted;

		private IntPtr id_isCompleted;

		private static Delegate? cb_cancel_Ljava_lang_Throwable_;

		private IntPtr id_cancel_Ljava_lang_Throwable_;

		private static Delegate? cb_completeResume_Ljava_lang_Object_;

		private IntPtr id_completeResume_Ljava_lang_Object_;

		private static Delegate? cb_initCancellability;

		private IntPtr id_initCancellability;

		private static Delegate? cb_invokeOnCancellation_Lkotlin_jvm_functions_Function1_;

		private IntPtr id_invokeOnCancellation_Lkotlin_jvm_functions_Function1_;

		private static Delegate? cb_resume_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_;

		private IntPtr id_resume_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_;

		private static Delegate? cb_resumeUndispatched_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Object_;

		private IntPtr id_resumeUndispatched_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Object_;

		private static Delegate? cb_resumeUndispatchedWithException_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Throwable_;

		private IntPtr id_resumeUndispatchedWithException_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Throwable_;

		private static Delegate? cb_tryResume_Ljava_lang_Object_Ljava_lang_Object_;

		private IntPtr id_tryResume_Ljava_lang_Object_Ljava_lang_Object_;

		private static Delegate? cb_tryResume_Ljava_lang_Object_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_;

		private IntPtr id_tryResume_Ljava_lang_Object_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_;

		private static Delegate? cb_tryResumeWithException_Ljava_lang_Throwable_;

		private IntPtr id_tryResumeWithException_Ljava_lang_Throwable_;

		private static Delegate? cb_getContext;

		private IntPtr id_getContext;

		private static Delegate? cb_resumeWith_Ljava_lang_Object_;

		private IntPtr id_resumeWith_Ljava_lang_Object_;

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

		public bool IsActive
		{
			get
			{
				if (id_isActive == IntPtr.Zero)
				{
					id_isActive = JNIEnv.GetMethodID(class_ref, "isActive", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_isActive);
			}
		}

		public bool IsCancelled
		{
			get
			{
				if (id_isCancelled == IntPtr.Zero)
				{
					id_isCancelled = JNIEnv.GetMethodID(class_ref, "isCancelled", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_isCancelled);
			}
		}

		public bool IsCompleted
		{
			get
			{
				if (id_isCompleted == IntPtr.Zero)
				{
					id_isCompleted = JNIEnv.GetMethodID(class_ref, "isCompleted", "()Z");
				}
				return JNIEnv.CallBooleanMethod(base.Handle, id_isCompleted);
			}
		}

		public ICoroutineContext Context
		{
			get
			{
				if (id_getContext == IntPtr.Zero)
				{
					id_getContext = JNIEnv.GetMethodID(class_ref, "getContext", "()Lkotlin/coroutines/CoroutineContext;");
				}
				return Java.Lang.Object.GetObject<ICoroutineContext>(JNIEnv.CallObjectMethod(base.Handle, id_getContext), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static ICancellableContinuation? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ICancellableContinuation>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'kotlinx.coroutines.CancellableContinuation'.");
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

		public ICancellableContinuationInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetIsActiveHandler()
		{
			if ((object)cb_isActive == null)
			{
				cb_isActive = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsActive));
			}
			return cb_isActive;
		}

		private static bool n_IsActive(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ICancellableContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsActive;
		}

		private static Delegate GetIsCancelledHandler()
		{
			if ((object)cb_isCancelled == null)
			{
				cb_isCancelled = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsCancelled));
			}
			return cb_isCancelled;
		}

		private static bool n_IsCancelled(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ICancellableContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCancelled;
		}

		private static Delegate GetIsCompletedHandler()
		{
			if ((object)cb_isCompleted == null)
			{
				cb_isCompleted = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsCompleted));
			}
			return cb_isCompleted;
		}

		private static bool n_IsCompleted(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ICancellableContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsCompleted;
		}

		private static Delegate GetCancel_Ljava_lang_Throwable_Handler()
		{
			if ((object)cb_cancel_Ljava_lang_Throwable_ == null)
			{
				cb_cancel_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_Cancel_Ljava_lang_Throwable_));
			}
			return cb_cancel_Ljava_lang_Throwable_;
		}

		private static bool n_Cancel_Ljava_lang_Throwable_(IntPtr jnienv, IntPtr native__this, IntPtr native_cause)
		{
			ICancellableContinuation cancellableContinuation = Java.Lang.Object.GetObject<ICancellableContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Throwable cause = Java.Lang.Object.GetObject<Throwable>(native_cause, JniHandleOwnership.DoNotTransfer);
			return cancellableContinuation.Cancel(cause);
		}

		public unsafe bool Cancel(Throwable? cause)
		{
			if (id_cancel_Ljava_lang_Throwable_ == IntPtr.Zero)
			{
				id_cancel_Ljava_lang_Throwable_ = JNIEnv.GetMethodID(class_ref, "cancel", "(Ljava/lang/Throwable;)Z");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(cause?.Handle ?? IntPtr.Zero);
			return JNIEnv.CallBooleanMethod(base.Handle, id_cancel_Ljava_lang_Throwable_, ptr);
		}

		private static Delegate GetCompleteResume_Ljava_lang_Object_Handler()
		{
			if ((object)cb_completeResume_Ljava_lang_Object_ == null)
			{
				cb_completeResume_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_CompleteResume_Ljava_lang_Object_));
			}
			return cb_completeResume_Ljava_lang_Object_;
		}

		private static void n_CompleteResume_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_token)
		{
			ICancellableContinuation cancellableContinuation = Java.Lang.Object.GetObject<ICancellableContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object token = Java.Lang.Object.GetObject<Java.Lang.Object>(native_token, JniHandleOwnership.DoNotTransfer);
			cancellableContinuation.CompleteResume(token);
		}

		public unsafe void CompleteResume(Java.Lang.Object token)
		{
			if (id_completeResume_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_completeResume_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "completeResume", "(Ljava/lang/Object;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(token?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_completeResume_Ljava_lang_Object_, ptr);
		}

		private static Delegate GetInitCancellabilityHandler()
		{
			if ((object)cb_initCancellability == null)
			{
				cb_initCancellability = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_InitCancellability));
			}
			return cb_initCancellability;
		}

		private static void n_InitCancellability(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ICancellableContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).InitCancellability();
		}

		public void InitCancellability()
		{
			if (id_initCancellability == IntPtr.Zero)
			{
				id_initCancellability = JNIEnv.GetMethodID(class_ref, "initCancellability", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_initCancellability);
		}

		private static Delegate GetInvokeOnCancellation_Lkotlin_jvm_functions_Function1_Handler()
		{
			if ((object)cb_invokeOnCancellation_Lkotlin_jvm_functions_Function1_ == null)
			{
				cb_invokeOnCancellation_Lkotlin_jvm_functions_Function1_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_InvokeOnCancellation_Lkotlin_jvm_functions_Function1_));
			}
			return cb_invokeOnCancellation_Lkotlin_jvm_functions_Function1_;
		}

		private static void n_InvokeOnCancellation_Lkotlin_jvm_functions_Function1_(IntPtr jnienv, IntPtr native__this, IntPtr native_handler)
		{
			ICancellableContinuation cancellableContinuation = Java.Lang.Object.GetObject<ICancellableContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IFunction1 handler = Java.Lang.Object.GetObject<IFunction1>(native_handler, JniHandleOwnership.DoNotTransfer);
			cancellableContinuation.InvokeOnCancellation(handler);
		}

		public unsafe void InvokeOnCancellation(IFunction1 handler)
		{
			if (id_invokeOnCancellation_Lkotlin_jvm_functions_Function1_ == IntPtr.Zero)
			{
				id_invokeOnCancellation_Lkotlin_jvm_functions_Function1_ = JNIEnv.GetMethodID(class_ref, "invokeOnCancellation", "(Lkotlin/jvm/functions/Function1;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((handler == null) ? IntPtr.Zero : ((Java.Lang.Object)handler).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_invokeOnCancellation_Lkotlin_jvm_functions_Function1_, ptr);
		}

		private static Delegate GetResume_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_Handler()
		{
			if ((object)cb_resume_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_ == null)
			{
				cb_resume_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_Resume_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_));
			}
			return cb_resume_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_;
		}

		private static void n_Resume_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_(IntPtr jnienv, IntPtr native__this, IntPtr native_value, IntPtr native_onCancellation)
		{
			ICancellableContinuation cancellableContinuation = Java.Lang.Object.GetObject<ICancellableContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			IFunction1 onCancellation = Java.Lang.Object.GetObject<IFunction1>(native_onCancellation, JniHandleOwnership.DoNotTransfer);
			cancellableContinuation.Resume(value, onCancellation);
		}

		public unsafe void Resume(Java.Lang.Object? value, IFunction1? onCancellation)
		{
			if (id_resume_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_ == IntPtr.Zero)
			{
				id_resume_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_ = JNIEnv.GetMethodID(class_ref, "resume", "(Ljava/lang/Object;Lkotlin/jvm/functions/Function1;)V");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue((onCancellation == null) ? IntPtr.Zero : ((Java.Lang.Object)onCancellation).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_resume_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetResumeUndispatched_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Object_Handler()
		{
			if ((object)cb_resumeUndispatched_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Object_ == null)
			{
				cb_resumeUndispatched_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ResumeUndispatched_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Object_));
			}
			return cb_resumeUndispatched_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Object_;
		}

		private static void n_ResumeUndispatched_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_value)
		{
			ICancellableContinuation cancellableContinuation = Java.Lang.Object.GetObject<ICancellableContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CoroutineDispatcher p = Java.Lang.Object.GetObject<CoroutineDispatcher>(native_p0, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			cancellableContinuation.ResumeUndispatched(p, value);
		}

		public unsafe void ResumeUndispatched(CoroutineDispatcher p0, Java.Lang.Object? value)
		{
			if (id_resumeUndispatched_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_resumeUndispatched_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "resumeUndispatched", "(Lkotlinx/coroutines/CoroutineDispatcher;Ljava/lang/Object;)V");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_resumeUndispatched_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Object_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetResumeUndispatchedWithException_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Throwable_Handler()
		{
			if ((object)cb_resumeUndispatchedWithException_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Throwable_ == null)
			{
				cb_resumeUndispatchedWithException_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_ResumeUndispatchedWithException_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Throwable_));
			}
			return cb_resumeUndispatchedWithException_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Throwable_;
		}

		private static void n_ResumeUndispatchedWithException_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Throwable_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0, IntPtr native_exception)
		{
			ICancellableContinuation cancellableContinuation = Java.Lang.Object.GetObject<ICancellableContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CoroutineDispatcher p = Java.Lang.Object.GetObject<CoroutineDispatcher>(native_p0, JniHandleOwnership.DoNotTransfer);
			Throwable exception = Java.Lang.Object.GetObject<Throwable>(native_exception, JniHandleOwnership.DoNotTransfer);
			cancellableContinuation.ResumeUndispatchedWithException(p, exception);
		}

		public unsafe void ResumeUndispatchedWithException(CoroutineDispatcher p0, Throwable exception)
		{
			if (id_resumeUndispatchedWithException_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Throwable_ == IntPtr.Zero)
			{
				id_resumeUndispatchedWithException_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Throwable_ = JNIEnv.GetMethodID(class_ref, "resumeUndispatchedWithException", "(Lkotlinx/coroutines/CoroutineDispatcher;Ljava/lang/Throwable;)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(p0?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(exception?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_resumeUndispatchedWithException_Lkotlinx_coroutines_CoroutineDispatcher_Ljava_lang_Throwable_, ptr);
		}

		private static Delegate GetTryResume_Ljava_lang_Object_Ljava_lang_Object_Handler()
		{
			if ((object)cb_tryResume_Ljava_lang_Object_Ljava_lang_Object_ == null)
			{
				cb_tryResume_Ljava_lang_Object_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_TryResume_Ljava_lang_Object_Ljava_lang_Object_));
			}
			return cb_tryResume_Ljava_lang_Object_Ljava_lang_Object_;
		}

		private static IntPtr n_TryResume_Ljava_lang_Object_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_value, IntPtr native_idempotent)
		{
			ICancellableContinuation cancellableContinuation = Java.Lang.Object.GetObject<ICancellableContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object idempotent = Java.Lang.Object.GetObject<Java.Lang.Object>(native_idempotent, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cancellableContinuation.TryResume(value, idempotent));
		}

		public unsafe Java.Lang.Object? TryResume(Java.Lang.Object? value, Java.Lang.Object? idempotent)
		{
			if (id_tryResume_Ljava_lang_Object_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_tryResume_Ljava_lang_Object_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "tryResume", "(Ljava/lang/Object;Ljava/lang/Object;)Ljava/lang/Object;");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(idempotent?.Handle ?? IntPtr.Zero);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_tryResume_Ljava_lang_Object_Ljava_lang_Object_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetTryResume_Ljava_lang_Object_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_Handler()
		{
			if ((object)cb_tryResume_Ljava_lang_Object_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_ == null)
			{
				cb_tryResume_Ljava_lang_Object_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_TryResume_Ljava_lang_Object_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_));
			}
			return cb_tryResume_Ljava_lang_Object_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_;
		}

		private static IntPtr n_TryResume_Ljava_lang_Object_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_(IntPtr jnienv, IntPtr native__this, IntPtr native_value, IntPtr native_idempotent, IntPtr native_onCancellation)
		{
			ICancellableContinuation cancellableContinuation = Java.Lang.Object.GetObject<ICancellableContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object idempotent = Java.Lang.Object.GetObject<Java.Lang.Object>(native_idempotent, JniHandleOwnership.DoNotTransfer);
			IFunction1 onCancellation = Java.Lang.Object.GetObject<IFunction1>(native_onCancellation, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cancellableContinuation.TryResume(value, idempotent, onCancellation));
		}

		public unsafe Java.Lang.Object? TryResume(Java.Lang.Object? value, Java.Lang.Object? idempotent, IFunction1? onCancellation)
		{
			if (id_tryResume_Ljava_lang_Object_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_ == IntPtr.Zero)
			{
				id_tryResume_Ljava_lang_Object_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_ = JNIEnv.GetMethodID(class_ref, "tryResume", "(Ljava/lang/Object;Ljava/lang/Object;Lkotlin/jvm/functions/Function1;)Ljava/lang/Object;");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(idempotent?.Handle ?? IntPtr.Zero);
			ptr[2] = new JValue((onCancellation == null) ? IntPtr.Zero : ((Java.Lang.Object)onCancellation).Handle);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_tryResume_Ljava_lang_Object_Ljava_lang_Object_Lkotlin_jvm_functions_Function1_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetTryResumeWithException_Ljava_lang_Throwable_Handler()
		{
			if ((object)cb_tryResumeWithException_Ljava_lang_Throwable_ == null)
			{
				cb_tryResumeWithException_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_TryResumeWithException_Ljava_lang_Throwable_));
			}
			return cb_tryResumeWithException_Ljava_lang_Throwable_;
		}

		private static IntPtr n_TryResumeWithException_Ljava_lang_Throwable_(IntPtr jnienv, IntPtr native__this, IntPtr native_exception)
		{
			ICancellableContinuation cancellableContinuation = Java.Lang.Object.GetObject<ICancellableContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Throwable exception = Java.Lang.Object.GetObject<Throwable>(native_exception, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(cancellableContinuation.TryResumeWithException(exception));
		}

		public unsafe Java.Lang.Object? TryResumeWithException(Throwable exception)
		{
			if (id_tryResumeWithException_Ljava_lang_Throwable_ == IntPtr.Zero)
			{
				id_tryResumeWithException_Ljava_lang_Throwable_ = JNIEnv.GetMethodID(class_ref, "tryResumeWithException", "(Ljava/lang/Throwable;)Ljava/lang/Object;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(exception?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_tryResumeWithException_Ljava_lang_Throwable_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGetContextHandler()
		{
			if ((object)cb_getContext == null)
			{
				cb_getContext = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetContext));
			}
			return cb_getContext;
		}

		private static IntPtr n_GetContext(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICancellableContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Context);
		}

		private static Delegate GetResumeWith_Ljava_lang_Object_Handler()
		{
			if ((object)cb_resumeWith_Ljava_lang_Object_ == null)
			{
				cb_resumeWith_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ResumeWith_Ljava_lang_Object_));
			}
			return cb_resumeWith_Ljava_lang_Object_;
		}

		private static void n_ResumeWith_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_result)
		{
			ICancellableContinuation cancellableContinuation = Java.Lang.Object.GetObject<ICancellableContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(native_result, JniHandleOwnership.DoNotTransfer);
			cancellableContinuation.ResumeWith(result);
		}

		public unsafe void ResumeWith(Java.Lang.Object result)
		{
			if (id_resumeWith_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_resumeWith_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "resumeWith", "(Ljava/lang/Object;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(result?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_resumeWith_Ljava_lang_Object_, ptr);
		}
	}
	[Register("kotlinx/coroutines/CopyableThreadContextElement$DefaultImpls", DoNotGenerateAcw = true)]
	public sealed class CopyableThreadContextElementDefaultImpls : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CopyableThreadContextElement$DefaultImpls", typeof(CopyableThreadContextElementDefaultImpls));

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

		internal CopyableThreadContextElementDefaultImpls(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("fold", "(Lkotlinx/coroutines/CopyableThreadContextElement;Ljava/lang/Object;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "S", "R" })]
		public unsafe static Java.Lang.Object? Fold(ICopyableThreadContextElement this_, Java.Lang.Object? initial, IFunction2 operation)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(initial);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((this_ == null) ? IntPtr.Zero : ((Java.Lang.Object)this_).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((operation == null) ? IntPtr.Zero : ((Java.Lang.Object)operation).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("fold.(Lkotlinx/coroutines/CopyableThreadContextElement;Ljava/lang/Object;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(this_);
				GC.KeepAlive(initial);
				GC.KeepAlive(operation);
			}
		}

		[Register("get", "(Lkotlinx/coroutines/CopyableThreadContextElement;Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;", "")]
		[JavaTypeParameters(new string[] { "S", "E extends kotlin.coroutines.CoroutineContext.Element" })]
		public unsafe static Java.Lang.Object? Get(ICopyableThreadContextElement this_, ICoroutineContextKey key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((this_ == null) ? IntPtr.Zero : ((Java.Lang.Object)this_).Handle);
				ptr[1] = new JniArgumentValue((key == null) ? IntPtr.Zero : ((Java.Lang.Object)key).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("get.(Lkotlinx/coroutines/CopyableThreadContextElement;Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(this_);
				GC.KeepAlive(key);
			}
		}

		[Register("minusKey", "(Lkotlinx/coroutines/CopyableThreadContextElement;Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext;", "")]
		[JavaTypeParameters(new string[] { "S" })]
		public unsafe static ICoroutineContext MinusKey(ICopyableThreadContextElement this_, ICoroutineContextKey key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((this_ == null) ? IntPtr.Zero : ((Java.Lang.Object)this_).Handle);
				ptr[1] = new JniArgumentValue((key == null) ? IntPtr.Zero : ((Java.Lang.Object)key).Handle);
				return Java.Lang.Object.GetObject<ICoroutineContext>(_members.StaticMethods.InvokeObjectMethod("minusKey.(Lkotlinx/coroutines/CopyableThreadContextElement;Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(this_);
				GC.KeepAlive(key);
			}
		}

		[Register("plus", "(Lkotlinx/coroutines/CopyableThreadContextElement;Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;", "")]
		[JavaTypeParameters(new string[] { "S" })]
		public unsafe static ICoroutineContext Plus(ICopyableThreadContextElement this_, ICoroutineContext context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((this_ == null) ? IntPtr.Zero : ((Java.Lang.Object)this_).Handle);
				ptr[1] = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				return Java.Lang.Object.GetObject<ICoroutineContext>(_members.StaticMethods.InvokeObjectMethod("plus.(Lkotlinx/coroutines/CopyableThreadContextElement;Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(this_);
				GC.KeepAlive(context);
			}
		}
	}
	[Register("kotlinx/coroutines/CopyableThreadContextElement", "", "Xamarin.KotlinX.Coroutines.ICopyableThreadContextElementInvoker")]
	[JavaTypeParameters(new string[] { "S" })]
	public interface ICopyableThreadContextElement : IThreadContextElement, ICoroutineContextElement, ICoroutineContext, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("copyForChild", "()Lkotlinx/coroutines/CopyableThreadContextElement;", "GetCopyForChildHandler:Xamarin.KotlinX.Coroutines.ICopyableThreadContextElementInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		ICopyableThreadContextElement CopyForChild();

		[Register("mergeForChild", "(Lkotlin/coroutines/CoroutineContext$Element;)Lkotlin/coroutines/CoroutineContext;", "GetMergeForChild_Lkotlin_coroutines_CoroutineContext_Element_Handler:Xamarin.KotlinX.Coroutines.ICopyableThreadContextElementInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		ICoroutineContext MergeForChild(ICoroutineContextElement overwritingElement);
	}
	[Register("kotlinx/coroutines/CopyableThreadContextElement", DoNotGenerateAcw = true)]
	internal class ICopyableThreadContextElementInvoker : Java.Lang.Object, ICopyableThreadContextElement, IThreadContextElement, ICoroutineContextElement, ICoroutineContext, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CopyableThreadContextElement", typeof(ICopyableThreadContextElementInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_copyForChild;

		private IntPtr id_copyForChild;

		private static Delegate? cb_mergeForChild_Lkotlin_coroutines_CoroutineContext_Element_;

		private IntPtr id_mergeForChild_Lkotlin_coroutines_CoroutineContext_Element_;

		private static Delegate? cb_restoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_;

		private IntPtr id_restoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_;

		private static Delegate? cb_updateThreadContext_Lkotlin_coroutines_CoroutineContext_;

		private IntPtr id_updateThreadContext_Lkotlin_coroutines_CoroutineContext_;

		private static Delegate? cb_getKey;

		private IntPtr id_getKey;

		private static Delegate? cb_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_;

		private IntPtr id_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_;

		private static Delegate? cb_get_Lkotlin_coroutines_CoroutineContext_Key_;

		private IntPtr id_get_Lkotlin_coroutines_CoroutineContext_Key_;

		private static Delegate? cb_minusKey_Lkotlin_coroutines_CoroutineContext_Key_;

		private IntPtr id_minusKey_Lkotlin_coroutines_CoroutineContext_Key_;

		private static Delegate? cb_plus_Lkotlin_coroutines_CoroutineContext_;

		private IntPtr id_plus_Lkotlin_coroutines_CoroutineContext_;

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

		public ICoroutineContextKey Key
		{
			get
			{
				if (id_getKey == IntPtr.Zero)
				{
					id_getKey = JNIEnv.GetMethodID(class_ref, "getKey", "()Lkotlin/coroutines/CoroutineContext$Key;");
				}
				return Java.Lang.Object.GetObject<ICoroutineContextKey>(JNIEnv.CallObjectMethod(base.Handle, id_getKey), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static ICopyableThreadContextElement? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ICopyableThreadContextElement>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'kotlinx.coroutines.CopyableThreadContextElement'.");
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

		public ICopyableThreadContextElementInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetCopyForChildHandler()
		{
			if ((object)cb_copyForChild == null)
			{
				cb_copyForChild = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CopyForChild));
			}
			return cb_copyForChild;
		}

		private static IntPtr n_CopyForChild(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICopyableThreadContextElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CopyForChild());
		}

		public ICopyableThreadContextElement CopyForChild()
		{
			if (id_copyForChild == IntPtr.Zero)
			{
				id_copyForChild = JNIEnv.GetMethodID(class_ref, "copyForChild", "()Lkotlinx/coroutines/CopyableThreadContextElement;");
			}
			return Java.Lang.Object.GetObject<ICopyableThreadContextElement>(JNIEnv.CallObjectMethod(base.Handle, id_copyForChild), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetMergeForChild_Lkotlin_coroutines_CoroutineContext_Element_Handler()
		{
			if ((object)cb_mergeForChild_Lkotlin_coroutines_CoroutineContext_Element_ == null)
			{
				cb_mergeForChild_Lkotlin_coroutines_CoroutineContext_Element_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_MergeForChild_Lkotlin_coroutines_CoroutineContext_Element_));
			}
			return cb_mergeForChild_Lkotlin_coroutines_CoroutineContext_Element_;
		}

		private static IntPtr n_MergeForChild_Lkotlin_coroutines_CoroutineContext_Element_(IntPtr jnienv, IntPtr native__this, IntPtr native_overwritingElement)
		{
			ICopyableThreadContextElement copyableThreadContextElement = Java.Lang.Object.GetObject<ICopyableThreadContextElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContextElement overwritingElement = Java.Lang.Object.GetObject<ICoroutineContextElement>(native_overwritingElement, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(copyableThreadContextElement.MergeForChild(overwritingElement));
		}

		public unsafe ICoroutineContext MergeForChild(ICoroutineContextElement overwritingElement)
		{
			if (id_mergeForChild_Lkotlin_coroutines_CoroutineContext_Element_ == IntPtr.Zero)
			{
				id_mergeForChild_Lkotlin_coroutines_CoroutineContext_Element_ = JNIEnv.GetMethodID(class_ref, "mergeForChild", "(Lkotlin/coroutines/CoroutineContext$Element;)Lkotlin/coroutines/CoroutineContext;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((overwritingElement == null) ? IntPtr.Zero : ((Java.Lang.Object)overwritingElement).Handle);
			return Java.Lang.Object.GetObject<ICoroutineContext>(JNIEnv.CallObjectMethod(base.Handle, id_mergeForChild_Lkotlin_coroutines_CoroutineContext_Element_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetRestoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_Handler()
		{
			if ((object)cb_restoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_ == null)
			{
				cb_restoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_RestoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_));
			}
			return cb_restoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_;
		}

		private static void n_RestoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_oldState)
		{
			ICopyableThreadContextElement copyableThreadContextElement = Java.Lang.Object.GetObject<ICopyableThreadContextElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContext context = Java.Lang.Object.GetObject<ICoroutineContext>(native_context, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object oldState = Java.Lang.Object.GetObject<Java.Lang.Object>(native_oldState, JniHandleOwnership.DoNotTransfer);
			copyableThreadContextElement.RestoreThreadContext(context, oldState);
		}

		public unsafe void RestoreThreadContext(ICoroutineContext context, Java.Lang.Object? oldState)
		{
			if (id_restoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_restoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "restoreThreadContext", "(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)V");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(oldState);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
			ptr[1] = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_restoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetUpdateThreadContext_Lkotlin_coroutines_CoroutineContext_Handler()
		{
			if ((object)cb_updateThreadContext_Lkotlin_coroutines_CoroutineContext_ == null)
			{
				cb_updateThreadContext_Lkotlin_coroutines_CoroutineContext_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_UpdateThreadContext_Lkotlin_coroutines_CoroutineContext_));
			}
			return cb_updateThreadContext_Lkotlin_coroutines_CoroutineContext_;
		}

		private static IntPtr n_UpdateThreadContext_Lkotlin_coroutines_CoroutineContext_(IntPtr jnienv, IntPtr native__this, IntPtr native_context)
		{
			ICopyableThreadContextElement copyableThreadContextElement = Java.Lang.Object.GetObject<ICopyableThreadContextElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContext context = Java.Lang.Object.GetObject<ICoroutineContext>(native_context, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(copyableThreadContextElement.UpdateThreadContext(context));
		}

		public unsafe Java.Lang.Object? UpdateThreadContext(ICoroutineContext context)
		{
			if (id_updateThreadContext_Lkotlin_coroutines_CoroutineContext_ == IntPtr.Zero)
			{
				id_updateThreadContext_Lkotlin_coroutines_CoroutineContext_ = JNIEnv.GetMethodID(class_ref, "updateThreadContext", "(Lkotlin/coroutines/CoroutineContext;)Ljava/lang/Object;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_updateThreadContext_Lkotlin_coroutines_CoroutineContext_, ptr), JniHandleOwnership.TransferLocalRef);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICopyableThreadContextElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Key);
		}

		private static Delegate GetFold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_Handler()
		{
			if ((object)cb_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_ == null)
			{
				cb_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_));
			}
			return cb_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_;
		}

		private static IntPtr n_Fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_(IntPtr jnienv, IntPtr native__this, IntPtr native_initial, IntPtr native_operation)
		{
			ICopyableThreadContextElement copyableThreadContextElement = Java.Lang.Object.GetObject<ICopyableThreadContextElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object initial = Java.Lang.Object.GetObject<Java.Lang.Object>(native_initial, JniHandleOwnership.DoNotTransfer);
			IFunction2 operation = Java.Lang.Object.GetObject<IFunction2>(native_operation, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(copyableThreadContextElement.Fold(initial, operation));
		}

		public unsafe Java.Lang.Object? Fold(Java.Lang.Object? initial, IFunction2 operation)
		{
			if (id_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_ == IntPtr.Zero)
			{
				id_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_ = JNIEnv.GetMethodID(class_ref, "fold", "(Ljava/lang/Object;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(initial?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue((operation == null) ? IntPtr.Zero : ((Java.Lang.Object)operation).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGet_Lkotlin_coroutines_CoroutineContext_Key_Handler()
		{
			if ((object)cb_get_Lkotlin_coroutines_CoroutineContext_Key_ == null)
			{
				cb_get_Lkotlin_coroutines_CoroutineContext_Key_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Get_Lkotlin_coroutines_CoroutineContext_Key_));
			}
			return cb_get_Lkotlin_coroutines_CoroutineContext_Key_;
		}

		private static IntPtr n_Get_Lkotlin_coroutines_CoroutineContext_Key_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			ICopyableThreadContextElement copyableThreadContextElement = Java.Lang.Object.GetObject<ICopyableThreadContextElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContextKey key = Java.Lang.Object.GetObject<ICoroutineContextKey>(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(copyableThreadContextElement.Get(key));
		}

		public unsafe Java.Lang.Object? Get(ICoroutineContextKey key)
		{
			if (id_get_Lkotlin_coroutines_CoroutineContext_Key_ == IntPtr.Zero)
			{
				id_get_Lkotlin_coroutines_CoroutineContext_Key_ = JNIEnv.GetMethodID(class_ref, "get", "(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((key == null) ? IntPtr.Zero : ((Java.Lang.Object)key).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_get_Lkotlin_coroutines_CoroutineContext_Key_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetMinusKey_Lkotlin_coroutines_CoroutineContext_Key_Handler()
		{
			if ((object)cb_minusKey_Lkotlin_coroutines_CoroutineContext_Key_ == null)
			{
				cb_minusKey_Lkotlin_coroutines_CoroutineContext_Key_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_MinusKey_Lkotlin_coroutines_CoroutineContext_Key_));
			}
			return cb_minusKey_Lkotlin_coroutines_CoroutineContext_Key_;
		}

		private static IntPtr n_MinusKey_Lkotlin_coroutines_CoroutineContext_Key_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			ICopyableThreadContextElement copyableThreadContextElement = Java.Lang.Object.GetObject<ICopyableThreadContextElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContextKey key = Java.Lang.Object.GetObject<ICoroutineContextKey>(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(copyableThreadContextElement.MinusKey(key));
		}

		public unsafe ICoroutineContext MinusKey(ICoroutineContextKey key)
		{
			if (id_minusKey_Lkotlin_coroutines_CoroutineContext_Key_ == IntPtr.Zero)
			{
				id_minusKey_Lkotlin_coroutines_CoroutineContext_Key_ = JNIEnv.GetMethodID(class_ref, "minusKey", "(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((key == null) ? IntPtr.Zero : ((Java.Lang.Object)key).Handle);
			return Java.Lang.Object.GetObject<ICoroutineContext>(JNIEnv.CallObjectMethod(base.Handle, id_minusKey_Lkotlin_coroutines_CoroutineContext_Key_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetPlus_Lkotlin_coroutines_CoroutineContext_Handler()
		{
			if ((object)cb_plus_Lkotlin_coroutines_CoroutineContext_ == null)
			{
				cb_plus_Lkotlin_coroutines_CoroutineContext_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Plus_Lkotlin_coroutines_CoroutineContext_));
			}
			return cb_plus_Lkotlin_coroutines_CoroutineContext_;
		}

		private static IntPtr n_Plus_Lkotlin_coroutines_CoroutineContext_(IntPtr jnienv, IntPtr native__this, IntPtr native_context)
		{
			ICopyableThreadContextElement copyableThreadContextElement = Java.Lang.Object.GetObject<ICopyableThreadContextElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContext context = Java.Lang.Object.GetObject<ICoroutineContext>(native_context, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(copyableThreadContextElement.Plus(context));
		}

		public unsafe ICoroutineContext Plus(ICoroutineContext context)
		{
			if (id_plus_Lkotlin_coroutines_CoroutineContext_ == IntPtr.Zero)
			{
				id_plus_Lkotlin_coroutines_CoroutineContext_ = JNIEnv.GetMethodID(class_ref, "plus", "(Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
			return Java.Lang.Object.GetObject<ICoroutineContext>(JNIEnv.CallObjectMethod(base.Handle, id_plus_Lkotlin_coroutines_CoroutineContext_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("kotlinx/coroutines/CopyableThrowable", "", "Xamarin.KotlinX.Coroutines.ICopyableThrowableInvoker")]
	[JavaTypeParameters(new string[] { "T extends java.lang.Throwable & kotlinx.coroutines.CopyableThrowable<T>" })]
	public interface ICopyableThrowable : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("createCopy", "()Ljava/lang/Throwable;", "GetCreateCopyHandler:Xamarin.KotlinX.Coroutines.ICopyableThrowableInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		Java.Lang.Object? CreateCopy();
	}
	[Register("kotlinx/coroutines/CopyableThrowable", DoNotGenerateAcw = true)]
	internal class ICopyableThrowableInvoker : Java.Lang.Object, ICopyableThrowable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CopyableThrowable", typeof(ICopyableThrowableInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_createCopy;

		private IntPtr id_createCopy;

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

		public static ICopyableThrowable? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ICopyableThrowable>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'kotlinx.coroutines.CopyableThrowable'.");
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

		public ICopyableThrowableInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetCreateCopyHandler()
		{
			if ((object)cb_createCopy == null)
			{
				cb_createCopy = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CreateCopy));
			}
			return cb_createCopy;
		}

		private static IntPtr n_CreateCopy(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICopyableThrowable>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CreateCopy());
		}

		public Java.Lang.Object? CreateCopy()
		{
			if (id_createCopy == IntPtr.Zero)
			{
				id_createCopy = JNIEnv.GetMethodID(class_ref, "createCopy", "()Ljava/lang/Throwable;");
			}
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_createCopy), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("kotlinx/coroutines/CoroutineExceptionHandler$DefaultImpls", DoNotGenerateAcw = true)]
	public sealed class CoroutineExceptionHandlerDefaultImpls : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CoroutineExceptionHandler$DefaultImpls", typeof(CoroutineExceptionHandlerDefaultImpls));

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

		internal CoroutineExceptionHandlerDefaultImpls(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("fold", "(Lkotlinx/coroutines/CoroutineExceptionHandler;Ljava/lang/Object;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "R" })]
		public unsafe static Java.Lang.Object? Fold(ICoroutineExceptionHandler this_, Java.Lang.Object? initial, IFunction2 operation)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(initial);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((this_ == null) ? IntPtr.Zero : ((Java.Lang.Object)this_).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((operation == null) ? IntPtr.Zero : ((Java.Lang.Object)operation).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("fold.(Lkotlinx/coroutines/CoroutineExceptionHandler;Ljava/lang/Object;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(this_);
				GC.KeepAlive(initial);
				GC.KeepAlive(operation);
			}
		}

		[Register("get", "(Lkotlinx/coroutines/CoroutineExceptionHandler;Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;", "")]
		[JavaTypeParameters(new string[] { "E extends kotlin.coroutines.CoroutineContext.Element" })]
		public unsafe static Java.Lang.Object? Get(ICoroutineExceptionHandler this_, ICoroutineContextKey key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((this_ == null) ? IntPtr.Zero : ((Java.Lang.Object)this_).Handle);
				ptr[1] = new JniArgumentValue((key == null) ? IntPtr.Zero : ((Java.Lang.Object)key).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("get.(Lkotlinx/coroutines/CoroutineExceptionHandler;Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(this_);
				GC.KeepAlive(key);
			}
		}

		[Register("minusKey", "(Lkotlinx/coroutines/CoroutineExceptionHandler;Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext;", "")]
		public unsafe static ICoroutineContext MinusKey(ICoroutineExceptionHandler this_, ICoroutineContextKey key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((this_ == null) ? IntPtr.Zero : ((Java.Lang.Object)this_).Handle);
				ptr[1] = new JniArgumentValue((key == null) ? IntPtr.Zero : ((Java.Lang.Object)key).Handle);
				return Java.Lang.Object.GetObject<ICoroutineContext>(_members.StaticMethods.InvokeObjectMethod("minusKey.(Lkotlinx/coroutines/CoroutineExceptionHandler;Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(this_);
				GC.KeepAlive(key);
			}
		}

		[Register("plus", "(Lkotlinx/coroutines/CoroutineExceptionHandler;Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;", "")]
		public unsafe static ICoroutineContext Plus(ICoroutineExceptionHandler this_, ICoroutineContext context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((this_ == null) ? IntPtr.Zero : ((Java.Lang.Object)this_).Handle);
				ptr[1] = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				return Java.Lang.Object.GetObject<ICoroutineContext>(_members.StaticMethods.InvokeObjectMethod("plus.(Lkotlinx/coroutines/CoroutineExceptionHandler;Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(this_);
				GC.KeepAlive(context);
			}
		}
	}
	[Register("kotlinx/coroutines/CoroutineExceptionHandler$Key", DoNotGenerateAcw = true)]
	public sealed class CoroutineExceptionHandlerKey : Java.Lang.Object, ICoroutineContextKey, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CoroutineExceptionHandler$Key", typeof(CoroutineExceptionHandlerKey));

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

		internal CoroutineExceptionHandlerKey(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/CoroutineExceptionHandler", DoNotGenerateAcw = true)]
	public abstract class CoroutineExceptionHandler : Java.Lang.Object
	{
		internal CoroutineExceptionHandler()
		{
		}
	}
	[Register("kotlinx/coroutines/CoroutineExceptionHandler", DoNotGenerateAcw = true)]
	[Obsolete("Use the 'CoroutineExceptionHandler' type. This type will be removed in a future release.", true)]
	public abstract class CoroutineExceptionHandlerConsts : CoroutineExceptionHandler
	{
		private CoroutineExceptionHandlerConsts()
		{
		}
	}
	[Register("kotlinx/coroutines/CoroutineExceptionHandler", "", "Xamarin.KotlinX.Coroutines.ICoroutineExceptionHandlerInvoker")]
	public interface ICoroutineExceptionHandler : ICoroutineContextElement, ICoroutineContext, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("handleException", "(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Throwable;)V", "GetHandleException_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Throwable_Handler:Xamarin.KotlinX.Coroutines.ICoroutineExceptionHandlerInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		void HandleException(ICoroutineContext context, Throwable exception);
	}
	[Register("kotlinx/coroutines/CoroutineExceptionHandler", DoNotGenerateAcw = true)]
	internal class ICoroutineExceptionHandlerInvoker : Java.Lang.Object, ICoroutineExceptionHandler, ICoroutineContextElement, ICoroutineContext, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CoroutineExceptionHandler", typeof(ICoroutineExceptionHandlerInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_handleException_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Throwable_;

		private IntPtr id_handleException_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Throwable_;

		private static Delegate? cb_getKey;

		private IntPtr id_getKey;

		private static Delegate? cb_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_;

		private IntPtr id_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_;

		private static Delegate? cb_get_Lkotlin_coroutines_CoroutineContext_Key_;

		private IntPtr id_get_Lkotlin_coroutines_CoroutineContext_Key_;

		private static Delegate? cb_minusKey_Lkotlin_coroutines_CoroutineContext_Key_;

		private IntPtr id_minusKey_Lkotlin_coroutines_CoroutineContext_Key_;

		private static Delegate? cb_plus_Lkotlin_coroutines_CoroutineContext_;

		private IntPtr id_plus_Lkotlin_coroutines_CoroutineContext_;

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

		public ICoroutineContextKey Key
		{
			get
			{
				if (id_getKey == IntPtr.Zero)
				{
					id_getKey = JNIEnv.GetMethodID(class_ref, "getKey", "()Lkotlin/coroutines/CoroutineContext$Key;");
				}
				return Java.Lang.Object.GetObject<ICoroutineContextKey>(JNIEnv.CallObjectMethod(base.Handle, id_getKey), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static ICoroutineExceptionHandler? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ICoroutineExceptionHandler>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'kotlinx.coroutines.CoroutineExceptionHandler'.");
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

		public ICoroutineExceptionHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetHandleException_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Throwable_Handler()
		{
			if ((object)cb_handleException_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Throwable_ == null)
			{
				cb_handleException_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_HandleException_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Throwable_));
			}
			return cb_handleException_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Throwable_;
		}

		private static void n_HandleException_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Throwable_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_exception)
		{
			ICoroutineExceptionHandler coroutineExceptionHandler = Java.Lang.Object.GetObject<ICoroutineExceptionHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContext context = Java.Lang.Object.GetObject<ICoroutineContext>(native_context, JniHandleOwnership.DoNotTransfer);
			Throwable exception = Java.Lang.Object.GetObject<Throwable>(native_exception, JniHandleOwnership.DoNotTransfer);
			coroutineExceptionHandler.HandleException(context, exception);
		}

		public unsafe void HandleException(ICoroutineContext context, Throwable exception)
		{
			if (id_handleException_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Throwable_ == IntPtr.Zero)
			{
				id_handleException_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Throwable_ = JNIEnv.GetMethodID(class_ref, "handleException", "(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Throwable;)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
			ptr[1] = new JValue(exception?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_handleException_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Throwable_, ptr);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICoroutineExceptionHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Key);
		}

		private static Delegate GetFold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_Handler()
		{
			if ((object)cb_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_ == null)
			{
				cb_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_));
			}
			return cb_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_;
		}

		private static IntPtr n_Fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_(IntPtr jnienv, IntPtr native__this, IntPtr native_initial, IntPtr native_operation)
		{
			ICoroutineExceptionHandler coroutineExceptionHandler = Java.Lang.Object.GetObject<ICoroutineExceptionHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object initial = Java.Lang.Object.GetObject<Java.Lang.Object>(native_initial, JniHandleOwnership.DoNotTransfer);
			IFunction2 operation = Java.Lang.Object.GetObject<IFunction2>(native_operation, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(coroutineExceptionHandler.Fold(initial, operation));
		}

		public unsafe Java.Lang.Object? Fold(Java.Lang.Object? initial, IFunction2 operation)
		{
			if (id_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_ == IntPtr.Zero)
			{
				id_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_ = JNIEnv.GetMethodID(class_ref, "fold", "(Ljava/lang/Object;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(initial?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue((operation == null) ? IntPtr.Zero : ((Java.Lang.Object)operation).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGet_Lkotlin_coroutines_CoroutineContext_Key_Handler()
		{
			if ((object)cb_get_Lkotlin_coroutines_CoroutineContext_Key_ == null)
			{
				cb_get_Lkotlin_coroutines_CoroutineContext_Key_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Get_Lkotlin_coroutines_CoroutineContext_Key_));
			}
			return cb_get_Lkotlin_coroutines_CoroutineContext_Key_;
		}

		private static IntPtr n_Get_Lkotlin_coroutines_CoroutineContext_Key_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			ICoroutineExceptionHandler coroutineExceptionHandler = Java.Lang.Object.GetObject<ICoroutineExceptionHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContextKey key = Java.Lang.Object.GetObject<ICoroutineContextKey>(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(coroutineExceptionHandler.Get(key));
		}

		public unsafe Java.Lang.Object? Get(ICoroutineContextKey key)
		{
			if (id_get_Lkotlin_coroutines_CoroutineContext_Key_ == IntPtr.Zero)
			{
				id_get_Lkotlin_coroutines_CoroutineContext_Key_ = JNIEnv.GetMethodID(class_ref, "get", "(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((key == null) ? IntPtr.Zero : ((Java.Lang.Object)key).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_get_Lkotlin_coroutines_CoroutineContext_Key_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetMinusKey_Lkotlin_coroutines_CoroutineContext_Key_Handler()
		{
			if ((object)cb_minusKey_Lkotlin_coroutines_CoroutineContext_Key_ == null)
			{
				cb_minusKey_Lkotlin_coroutines_CoroutineContext_Key_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_MinusKey_Lkotlin_coroutines_CoroutineContext_Key_));
			}
			return cb_minusKey_Lkotlin_coroutines_CoroutineContext_Key_;
		}

		private static IntPtr n_MinusKey_Lkotlin_coroutines_CoroutineContext_Key_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			ICoroutineExceptionHandler coroutineExceptionHandler = Java.Lang.Object.GetObject<ICoroutineExceptionHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContextKey key = Java.Lang.Object.GetObject<ICoroutineContextKey>(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(coroutineExceptionHandler.MinusKey(key));
		}

		public unsafe ICoroutineContext MinusKey(ICoroutineContextKey key)
		{
			if (id_minusKey_Lkotlin_coroutines_CoroutineContext_Key_ == IntPtr.Zero)
			{
				id_minusKey_Lkotlin_coroutines_CoroutineContext_Key_ = JNIEnv.GetMethodID(class_ref, "minusKey", "(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((key == null) ? IntPtr.Zero : ((Java.Lang.Object)key).Handle);
			return Java.Lang.Object.GetObject<ICoroutineContext>(JNIEnv.CallObjectMethod(base.Handle, id_minusKey_Lkotlin_coroutines_CoroutineContext_Key_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetPlus_Lkotlin_coroutines_CoroutineContext_Handler()
		{
			if ((object)cb_plus_Lkotlin_coroutines_CoroutineContext_ == null)
			{
				cb_plus_Lkotlin_coroutines_CoroutineContext_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Plus_Lkotlin_coroutines_CoroutineContext_));
			}
			return cb_plus_Lkotlin_coroutines_CoroutineContext_;
		}

		private static IntPtr n_Plus_Lkotlin_coroutines_CoroutineContext_(IntPtr jnienv, IntPtr native__this, IntPtr native_context)
		{
			ICoroutineExceptionHandler coroutineExceptionHandler = Java.Lang.Object.GetObject<ICoroutineExceptionHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContext context = Java.Lang.Object.GetObject<ICoroutineContext>(native_context, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(coroutineExceptionHandler.Plus(context));
		}

		public unsafe ICoroutineContext Plus(ICoroutineContext context)
		{
			if (id_plus_Lkotlin_coroutines_CoroutineContext_ == IntPtr.Zero)
			{
				id_plus_Lkotlin_coroutines_CoroutineContext_ = JNIEnv.GetMethodID(class_ref, "plus", "(Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
			return Java.Lang.Object.GetObject<ICoroutineContext>(JNIEnv.CallObjectMethod(base.Handle, id_plus_Lkotlin_coroutines_CoroutineContext_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("kotlinx/coroutines/CoroutineScope", "", "Xamarin.KotlinX.Coroutines.ICoroutineScopeInvoker")]
	public interface ICoroutineScope : IJavaObject, IDisposable, IJavaPeerable
	{
		ICoroutineContext CoroutineContext
		{
			[Register("getCoroutineContext", "()Lkotlin/coroutines/CoroutineContext;", "GetGetCoroutineContextHandler:Xamarin.KotlinX.Coroutines.ICoroutineScopeInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
			get;
		}
	}
	[Register("kotlinx/coroutines/CoroutineScope", DoNotGenerateAcw = true)]
	internal class ICoroutineScopeInvoker : Java.Lang.Object, ICoroutineScope, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/CoroutineScope", typeof(ICoroutineScopeInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_getCoroutineContext;

		private IntPtr id_getCoroutineContext;

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

		public ICoroutineContext CoroutineContext
		{
			get
			{
				if (id_getCoroutineContext == IntPtr.Zero)
				{
					id_getCoroutineContext = JNIEnv.GetMethodID(class_ref, "getCoroutineContext", "()Lkotlin/coroutines/CoroutineContext;");
				}
				return Java.Lang.Object.GetObject<ICoroutineContext>(JNIEnv.CallObjectMethod(base.Handle, id_getCoroutineContext), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static ICoroutineScope? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ICoroutineScope>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'kotlinx.coroutines.CoroutineScope'.");
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

		public ICoroutineScopeInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetCoroutineContextHandler()
		{
			if ((object)cb_getCoroutineContext == null)
			{
				cb_getCoroutineContext = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetCoroutineContext));
			}
			return cb_getCoroutineContext;
		}

		private static IntPtr n_GetCoroutineContext(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ICoroutineScope>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CoroutineContext);
		}
	}
	[Register("kotlinx/coroutines/Delay$DefaultImpls", DoNotGenerateAcw = true)]
	public sealed class DelayDefaultImpls : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/Delay$DefaultImpls", typeof(DelayDefaultImpls));

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

		internal DelayDefaultImpls(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Obsolete("deprecated")]
		[Register("delay", "(Lkotlinx/coroutines/Delay;JLkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		public unsafe static Java.Lang.Object? Delay(IDelay this_, long time, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((this_ == null) ? IntPtr.Zero : ((Java.Lang.Object)this_).Handle);
				ptr[1] = new JniArgumentValue(time);
				ptr[2] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("delay.(Lkotlinx/coroutines/Delay;JLkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(this_);
				GC.KeepAlive(_completion);
			}
		}

		[Register("invokeOnTimeout", "(Lkotlinx/coroutines/Delay;JLjava/lang/Runnable;Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/DisposableHandle;", "")]
		public unsafe static IDisposableHandle InvokeOnTimeout(IDelay this_, long timeMillis, IRunnable block, ICoroutineContext context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue((this_ == null) ? IntPtr.Zero : ((Java.Lang.Object)this_).Handle);
				ptr[1] = new JniArgumentValue(timeMillis);
				ptr[2] = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				ptr[3] = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				return Java.Lang.Object.GetObject<IDisposableHandle>(_members.StaticMethods.InvokeObjectMethod("invokeOnTimeout.(Lkotlinx/coroutines/Delay;JLjava/lang/Runnable;Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/DisposableHandle;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(this_);
				GC.KeepAlive(block);
				GC.KeepAlive(context);
			}
		}
	}
	[Register("kotlinx/coroutines/Delay", "", "Xamarin.KotlinX.Coroutines.IDelayInvoker")]
	public interface IDelay : IJavaObject, IDisposable, IJavaPeerable
	{
		[Obsolete("deprecated")]
		[Register("delay", "(JLkotlin/coroutines/Continuation;)Ljava/lang/Object;", "GetDelay_JLkotlin_coroutines_Continuation_Handler:Xamarin.KotlinX.Coroutines.IDelayInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		Java.Lang.Object? Delay(long time, IContinuation p1);

		[Register("invokeOnTimeout", "(JLjava/lang/Runnable;Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/DisposableHandle;", "GetInvokeOnTimeout_JLjava_lang_Runnable_Lkotlin_coroutines_CoroutineContext_Handler:Xamarin.KotlinX.Coroutines.IDelayInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		IDisposableHandle InvokeOnTimeout(long timeMillis, IRunnable block, ICoroutineContext context);

		[Register("scheduleResumeAfterDelay", "(JLkotlinx/coroutines/CancellableContinuation;)V", "GetScheduleResumeAfterDelay_JLkotlinx_coroutines_CancellableContinuation_Handler:Xamarin.KotlinX.Coroutines.IDelayInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		void ScheduleResumeAfterDelay(long timeMillis, ICancellableContinuation continuation);
	}
	[Register("kotlinx/coroutines/Delay", DoNotGenerateAcw = true)]
	internal class IDelayInvoker : Java.Lang.Object, IDelay, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/Delay", typeof(IDelayInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_delay_JLkotlin_coroutines_Continuation_;

		private IntPtr id_delay_JLkotlin_coroutines_Continuation_;

		private static Delegate? cb_invokeOnTimeout_JLjava_lang_Runnable_Lkotlin_coroutines_CoroutineContext_;

		private IntPtr id_invokeOnTimeout_JLjava_lang_Runnable_Lkotlin_coroutines_CoroutineContext_;

		private static Delegate? cb_scheduleResumeAfterDelay_JLkotlinx_coroutines_CancellableContinuation_;

		private IntPtr id_scheduleResumeAfterDelay_JLkotlinx_coroutines_CancellableContinuation_;

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

		public static IDelay? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IDelay>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'kotlinx.coroutines.Delay'.");
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

		public IDelayInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		[Obsolete]
		private static Delegate GetDelay_JLkotlin_coroutines_Continuation_Handler()
		{
			if ((object)cb_delay_JLkotlin_coroutines_Continuation_ == null)
			{
				cb_delay_JLkotlin_coroutines_Continuation_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJL_L(n_Delay_JLkotlin_coroutines_Continuation_));
			}
			return cb_delay_JLkotlin_coroutines_Continuation_;
		}

		[Obsolete]
		private static IntPtr n_Delay_JLkotlin_coroutines_Continuation_(IntPtr jnienv, IntPtr native__this, long time, IntPtr native_p1)
		{
			IDelay delay = Java.Lang.Object.GetObject<IDelay>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IContinuation p = Java.Lang.Object.GetObject<IContinuation>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(delay.Delay(time, p));
		}

		public unsafe Java.Lang.Object? Delay(long time, IContinuation p1)
		{
			if (id_delay_JLkotlin_coroutines_Continuation_ == IntPtr.Zero)
			{
				id_delay_JLkotlin_coroutines_Continuation_ = JNIEnv.GetMethodID(class_ref, "delay", "(JLkotlin/coroutines/Continuation;)Ljava/lang/Object;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(time);
			ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_delay_JLkotlin_coroutines_Continuation_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetInvokeOnTimeout_JLjava_lang_Runnable_Lkotlin_coroutines_CoroutineContext_Handler()
		{
			if ((object)cb_invokeOnTimeout_JLjava_lang_Runnable_Lkotlin_coroutines_CoroutineContext_ == null)
			{
				cb_invokeOnTimeout_JLjava_lang_Runnable_Lkotlin_coroutines_CoroutineContext_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPJLL_L(n_InvokeOnTimeout_JLjava_lang_Runnable_Lkotlin_coroutines_CoroutineContext_));
			}
			return cb_invokeOnTimeout_JLjava_lang_Runnable_Lkotlin_coroutines_CoroutineContext_;
		}

		private static IntPtr n_InvokeOnTimeout_JLjava_lang_Runnable_Lkotlin_coroutines_CoroutineContext_(IntPtr jnienv, IntPtr native__this, long timeMillis, IntPtr native_block, IntPtr native_context)
		{
			IDelay delay = Java.Lang.Object.GetObject<IDelay>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable block = Java.Lang.Object.GetObject<IRunnable>(native_block, JniHandleOwnership.DoNotTransfer);
			ICoroutineContext context = Java.Lang.Object.GetObject<ICoroutineContext>(native_context, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(delay.InvokeOnTimeout(timeMillis, block, context));
		}

		public unsafe IDisposableHandle InvokeOnTimeout(long timeMillis, IRunnable block, ICoroutineContext context)
		{
			if (id_invokeOnTimeout_JLjava_lang_Runnable_Lkotlin_coroutines_CoroutineContext_ == IntPtr.Zero)
			{
				id_invokeOnTimeout_JLjava_lang_Runnable_Lkotlin_coroutines_CoroutineContext_ = JNIEnv.GetMethodID(class_ref, "invokeOnTimeout", "(JLjava/lang/Runnable;Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/DisposableHandle;");
			}
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(timeMillis);
			ptr[1] = new JValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
			ptr[2] = new JValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
			return Java.Lang.Object.GetObject<IDisposableHandle>(JNIEnv.CallObjectMethod(base.Handle, id_invokeOnTimeout_JLjava_lang_Runnable_Lkotlin_coroutines_CoroutineContext_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetScheduleResumeAfterDelay_JLkotlinx_coroutines_CancellableContinuation_Handler()
		{
			if ((object)cb_scheduleResumeAfterDelay_JLkotlinx_coroutines_CancellableContinuation_ == null)
			{
				cb_scheduleResumeAfterDelay_JLkotlinx_coroutines_CancellableContinuation_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPJL_V(n_ScheduleResumeAfterDelay_JLkotlinx_coroutines_CancellableContinuation_));
			}
			return cb_scheduleResumeAfterDelay_JLkotlinx_coroutines_CancellableContinuation_;
		}

		private static void n_ScheduleResumeAfterDelay_JLkotlinx_coroutines_CancellableContinuation_(IntPtr jnienv, IntPtr native__this, long timeMillis, IntPtr native_continuation)
		{
			IDelay delay = Java.Lang.Object.GetObject<IDelay>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICancellableContinuation continuation = Java.Lang.Object.GetObject<ICancellableContinuation>(native_continuation, JniHandleOwnership.DoNotTransfer);
			delay.ScheduleResumeAfterDelay(timeMillis, continuation);
		}

		public unsafe void ScheduleResumeAfterDelay(long timeMillis, ICancellableContinuation continuation)
		{
			if (id_scheduleResumeAfterDelay_JLkotlinx_coroutines_CancellableContinuation_ == IntPtr.Zero)
			{
				id_scheduleResumeAfterDelay_JLkotlinx_coroutines_CancellableContinuation_ = JNIEnv.GetMethodID(class_ref, "scheduleResumeAfterDelay", "(JLkotlinx/coroutines/CancellableContinuation;)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(timeMillis);
			ptr[1] = new JValue((continuation == null) ? IntPtr.Zero : ((Java.Lang.Object)continuation).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_scheduleResumeAfterDelay_JLkotlinx_coroutines_CancellableContinuation_, ptr);
		}
	}
	[Register("kotlinx/coroutines/DelicateCoroutinesApi", "", "Xamarin.KotlinX.Coroutines.IDelicateCoroutinesApiInvoker")]
	public interface IDelicateCoroutinesApi : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("kotlinx/coroutines/DelicateCoroutinesApi", DoNotGenerateAcw = true)]
	internal class IDelicateCoroutinesApiInvoker : Java.Lang.Object, IDelicateCoroutinesApi, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/DelicateCoroutinesApi", typeof(IDelicateCoroutinesApiInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

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

		public static IDelicateCoroutinesApi? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IDelicateCoroutinesApi>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'kotlinx.coroutines.DelicateCoroutinesApi'.");
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

		public IDelicateCoroutinesApiInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IDelicateCoroutinesApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
			IDelicateCoroutinesApi delicateCoroutinesApi = Java.Lang.Object.GetObject<IDelicateCoroutinesApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return delicateCoroutinesApi.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
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
			return Java.Lang.Object.GetObject<IDelicateCoroutinesApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IDelicateCoroutinesApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("kotlinx/coroutines/DisposableHandle", "", "Xamarin.KotlinX.Coroutines.IDisposableHandleInvoker")]
	public interface IDisposableHandle : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("dispose", "()V", "GetDisposeHandler:Xamarin.KotlinX.Coroutines.IDisposableHandleInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		new void Dispose();
	}
	[Register("kotlinx/coroutines/DisposableHandle", DoNotGenerateAcw = true)]
	internal class IDisposableHandleInvoker : Java.Lang.Object, IDisposableHandle, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/DisposableHandle", typeof(IDisposableHandleInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_dispose;

		private IntPtr id_dispose;

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

		public static IDisposableHandle? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IDisposableHandle>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'kotlinx.coroutines.DisposableHandle'.");
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

		public IDisposableHandleInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetDisposeHandler()
		{
			if ((object)cb_dispose == null)
			{
				cb_dispose = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Dispose));
			}
			return cb_dispose;
		}

		private static void n_Dispose(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<IDisposableHandle>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Dispose();
		}

		public new void Dispose()
		{
			if (id_dispose == IntPtr.Zero)
			{
				id_dispose = JNIEnv.GetMethodID(class_ref, "dispose", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_dispose);
		}
	}
	[Register("kotlinx/coroutines/ExperimentalCoroutinesApi", "", "Xamarin.KotlinX.Coroutines.IExperimentalCoroutinesApiInvoker")]
	public interface IExperimentalCoroutinesApi : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("kotlinx/coroutines/ExperimentalCoroutinesApi", DoNotGenerateAcw = true)]
	internal class IExperimentalCoroutinesApiInvoker : Java.Lang.Object, IExperimentalCoroutinesApi, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/ExperimentalCoroutinesApi", typeof(IExperimentalCoroutinesApiInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

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

		public static IExperimentalCoroutinesApi? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IExperimentalCoroutinesApi>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'kotlinx.coroutines.ExperimentalCoroutinesApi'.");
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

		public IExperimentalCoroutinesApiInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IExperimentalCoroutinesApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
			IExperimentalCoroutinesApi experimentalCoroutinesApi = Java.Lang.Object.GetObject<IExperimentalCoroutinesApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return experimentalCoroutinesApi.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
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
			return Java.Lang.Object.GetObject<IExperimentalCoroutinesApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IExperimentalCoroutinesApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("kotlinx/coroutines/FlowPreview", "", "Xamarin.KotlinX.Coroutines.IFlowPreviewInvoker")]
	public interface IFlowPreview : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("kotlinx/coroutines/FlowPreview", DoNotGenerateAcw = true)]
	internal class IFlowPreviewInvoker : Java.Lang.Object, IFlowPreview, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/FlowPreview", typeof(IFlowPreviewInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

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

		public static IFlowPreview? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IFlowPreview>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'kotlinx.coroutines.FlowPreview'.");
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

		public IFlowPreviewInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IFlowPreview>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
			IFlowPreview flowPreview = Java.Lang.Object.GetObject<IFlowPreview>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return flowPreview.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
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
			return Java.Lang.Object.GetObject<IFlowPreview>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IFlowPreview>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("kotlinx/coroutines/InternalCoroutinesApi", "", "Xamarin.KotlinX.Coroutines.IInternalCoroutinesApiInvoker")]
	public interface IInternalCoroutinesApi : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("kotlinx/coroutines/InternalCoroutinesApi", DoNotGenerateAcw = true)]
	internal class IInternalCoroutinesApiInvoker : Java.Lang.Object, IInternalCoroutinesApi, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/InternalCoroutinesApi", typeof(IInternalCoroutinesApiInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

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

		public static IInternalCoroutinesApi? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IInternalCoroutinesApi>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'kotlinx.coroutines.InternalCoroutinesApi'.");
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

		public IInternalCoroutinesApiInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IInternalCoroutinesApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
			IInternalCoroutinesApi internalCoroutinesApi = Java.Lang.Object.GetObject<IInternalCoroutinesApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return internalCoroutinesApi.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
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
			return Java.Lang.Object.GetObject<IInternalCoroutinesApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IInternalCoroutinesApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Annotation("kotlinx.coroutines.InternalCoroutinesApi")]
	public class InternalCoroutinesApiAttribute : Attribute
	{
	}
	[Register("kotlinx/coroutines/InterruptibleKt", DoNotGenerateAcw = true)]
	public sealed class InterruptibleKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/InterruptibleKt", typeof(InterruptibleKt));

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

		internal InterruptibleKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("runInterruptible", "(Lkotlin/coroutines/CoroutineContext;Lkotlin/jvm/functions/Function0;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? RunInterruptible(ICoroutineContext context, IFunction0 block, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				ptr[1] = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				ptr[2] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("runInterruptible.(Lkotlin/coroutines/CoroutineContext;Lkotlin/jvm/functions/Function0;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(block);
				GC.KeepAlive(_completion);
			}
		}
	}
	[Register("kotlinx/coroutines/ObsoleteCoroutinesApi", "", "Xamarin.KotlinX.Coroutines.IObsoleteCoroutinesApiInvoker")]
	public interface IObsoleteCoroutinesApi : IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
	}
	[Register("kotlinx/coroutines/ObsoleteCoroutinesApi", DoNotGenerateAcw = true)]
	internal class IObsoleteCoroutinesApiInvoker : Java.Lang.Object, IObsoleteCoroutinesApi, IAnnotation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/ObsoleteCoroutinesApi", typeof(IObsoleteCoroutinesApiInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_annotationType;

		private IntPtr id_annotationType;

		private static Delegate? cb_equals_Ljava_lang_Object_;

		private IntPtr id_equals_Ljava_lang_Object_;

		private static Delegate? cb_hashCode;

		private IntPtr id_hashCode;

		private static Delegate? cb_toString;

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

		public static IObsoleteCoroutinesApi? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IObsoleteCoroutinesApi>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'kotlinx.coroutines.ObsoleteCoroutinesApi'.");
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

		public IObsoleteCoroutinesApiInvoker(IntPtr handle, JniHandleOwnership transfer)
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IObsoleteCoroutinesApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AnnotationType());
		}

		public Class? AnnotationType()
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
			IObsoleteCoroutinesApi obsoleteCoroutinesApi = Java.Lang.Object.GetObject<IObsoleteCoroutinesApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object obj = Java.Lang.Object.GetObject<Java.Lang.Object>(native_obj, JniHandleOwnership.DoNotTransfer);
			return obsoleteCoroutinesApi.Equals(obj);
		}

		public new unsafe bool Equals(Java.Lang.Object? obj)
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
			return Java.Lang.Object.GetObject<IObsoleteCoroutinesApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).GetHashCode();
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
			return JNIEnv.NewString(Java.Lang.Object.GetObject<IObsoleteCoroutinesApi>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ToString());
		}

		public new string? ToString()
		{
			if (id_toString == IntPtr.Zero)
			{
				id_toString = JNIEnv.GetMethodID(class_ref, "toString", "()Ljava/lang/String;");
			}
			return JNIEnv.GetString(JNIEnv.CallObjectMethod(base.Handle, id_toString), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("kotlinx/coroutines/ThreadContextElement$DefaultImpls", DoNotGenerateAcw = true)]
	public sealed class ThreadContextElementDefaultImpls : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/ThreadContextElement$DefaultImpls", typeof(ThreadContextElementDefaultImpls));

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

		internal ThreadContextElementDefaultImpls(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("fold", "(Lkotlinx/coroutines/ThreadContextElement;Ljava/lang/Object;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "S", "R" })]
		public unsafe static Java.Lang.Object? Fold(IThreadContextElement this_, Java.Lang.Object? initial, IFunction2 operation)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(initial);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((this_ == null) ? IntPtr.Zero : ((Java.Lang.Object)this_).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((operation == null) ? IntPtr.Zero : ((Java.Lang.Object)operation).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("fold.(Lkotlinx/coroutines/ThreadContextElement;Ljava/lang/Object;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(this_);
				GC.KeepAlive(initial);
				GC.KeepAlive(operation);
			}
		}

		[Register("get", "(Lkotlinx/coroutines/ThreadContextElement;Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;", "")]
		[JavaTypeParameters(new string[] { "S", "E extends kotlin.coroutines.CoroutineContext.Element" })]
		public unsafe static Java.Lang.Object? Get(IThreadContextElement this_, ICoroutineContextKey key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((this_ == null) ? IntPtr.Zero : ((Java.Lang.Object)this_).Handle);
				ptr[1] = new JniArgumentValue((key == null) ? IntPtr.Zero : ((Java.Lang.Object)key).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("get.(Lkotlinx/coroutines/ThreadContextElement;Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(this_);
				GC.KeepAlive(key);
			}
		}

		[Register("minusKey", "(Lkotlinx/coroutines/ThreadContextElement;Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext;", "")]
		[JavaTypeParameters(new string[] { "S" })]
		public unsafe static ICoroutineContext MinusKey(IThreadContextElement this_, ICoroutineContextKey key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((this_ == null) ? IntPtr.Zero : ((Java.Lang.Object)this_).Handle);
				ptr[1] = new JniArgumentValue((key == null) ? IntPtr.Zero : ((Java.Lang.Object)key).Handle);
				return Java.Lang.Object.GetObject<ICoroutineContext>(_members.StaticMethods.InvokeObjectMethod("minusKey.(Lkotlinx/coroutines/ThreadContextElement;Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(this_);
				GC.KeepAlive(key);
			}
		}

		[Register("plus", "(Lkotlinx/coroutines/ThreadContextElement;Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;", "")]
		[JavaTypeParameters(new string[] { "S" })]
		public unsafe static ICoroutineContext Plus(IThreadContextElement this_, ICoroutineContext context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((this_ == null) ? IntPtr.Zero : ((Java.Lang.Object)this_).Handle);
				ptr[1] = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				return Java.Lang.Object.GetObject<ICoroutineContext>(_members.StaticMethods.InvokeObjectMethod("plus.(Lkotlinx/coroutines/ThreadContextElement;Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(this_);
				GC.KeepAlive(context);
			}
		}
	}
	[Register("kotlinx/coroutines/ThreadContextElement", "", "Xamarin.KotlinX.Coroutines.IThreadContextElementInvoker")]
	[JavaTypeParameters(new string[] { "S" })]
	public interface IThreadContextElement : ICoroutineContextElement, ICoroutineContext, IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("restoreThreadContext", "(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)V", "GetRestoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_Handler:Xamarin.KotlinX.Coroutines.IThreadContextElementInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		void RestoreThreadContext(ICoroutineContext context, Java.Lang.Object? oldState);

		[Register("updateThreadContext", "(Lkotlin/coroutines/CoroutineContext;)Ljava/lang/Object;", "GetUpdateThreadContext_Lkotlin_coroutines_CoroutineContext_Handler:Xamarin.KotlinX.Coroutines.IThreadContextElementInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		Java.Lang.Object? UpdateThreadContext(ICoroutineContext context);
	}
	[Register("kotlinx/coroutines/ThreadContextElement", DoNotGenerateAcw = true)]
	internal class IThreadContextElementInvoker : Java.Lang.Object, IThreadContextElement, ICoroutineContextElement, ICoroutineContext, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/ThreadContextElement", typeof(IThreadContextElementInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_restoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_;

		private IntPtr id_restoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_;

		private static Delegate? cb_updateThreadContext_Lkotlin_coroutines_CoroutineContext_;

		private IntPtr id_updateThreadContext_Lkotlin_coroutines_CoroutineContext_;

		private static Delegate? cb_getKey;

		private IntPtr id_getKey;

		private static Delegate? cb_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_;

		private IntPtr id_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_;

		private static Delegate? cb_get_Lkotlin_coroutines_CoroutineContext_Key_;

		private IntPtr id_get_Lkotlin_coroutines_CoroutineContext_Key_;

		private static Delegate? cb_minusKey_Lkotlin_coroutines_CoroutineContext_Key_;

		private IntPtr id_minusKey_Lkotlin_coroutines_CoroutineContext_Key_;

		private static Delegate? cb_plus_Lkotlin_coroutines_CoroutineContext_;

		private IntPtr id_plus_Lkotlin_coroutines_CoroutineContext_;

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

		public ICoroutineContextKey Key
		{
			get
			{
				if (id_getKey == IntPtr.Zero)
				{
					id_getKey = JNIEnv.GetMethodID(class_ref, "getKey", "()Lkotlin/coroutines/CoroutineContext$Key;");
				}
				return Java.Lang.Object.GetObject<ICoroutineContextKey>(JNIEnv.CallObjectMethod(base.Handle, id_getKey), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static IThreadContextElement? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IThreadContextElement>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'kotlinx.coroutines.ThreadContextElement'.");
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

		public IThreadContextElementInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetRestoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_Handler()
		{
			if ((object)cb_restoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_ == null)
			{
				cb_restoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_V(n_RestoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_));
			}
			return cb_restoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_;
		}

		private static void n_RestoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_oldState)
		{
			IThreadContextElement threadContextElement = Java.Lang.Object.GetObject<IThreadContextElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContext context = Java.Lang.Object.GetObject<ICoroutineContext>(native_context, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object oldState = Java.Lang.Object.GetObject<Java.Lang.Object>(native_oldState, JniHandleOwnership.DoNotTransfer);
			threadContextElement.RestoreThreadContext(context, oldState);
		}

		public unsafe void RestoreThreadContext(ICoroutineContext context, Java.Lang.Object? oldState)
		{
			if (id_restoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_restoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "restoreThreadContext", "(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Object;)V");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(oldState);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
			ptr[1] = new JValue(intPtr);
			JNIEnv.CallVoidMethod(base.Handle, id_restoreThreadContext_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Object_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
		}

		private static Delegate GetUpdateThreadContext_Lkotlin_coroutines_CoroutineContext_Handler()
		{
			if ((object)cb_updateThreadContext_Lkotlin_coroutines_CoroutineContext_ == null)
			{
				cb_updateThreadContext_Lkotlin_coroutines_CoroutineContext_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_UpdateThreadContext_Lkotlin_coroutines_CoroutineContext_));
			}
			return cb_updateThreadContext_Lkotlin_coroutines_CoroutineContext_;
		}

		private static IntPtr n_UpdateThreadContext_Lkotlin_coroutines_CoroutineContext_(IntPtr jnienv, IntPtr native__this, IntPtr native_context)
		{
			IThreadContextElement threadContextElement = Java.Lang.Object.GetObject<IThreadContextElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContext context = Java.Lang.Object.GetObject<ICoroutineContext>(native_context, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(threadContextElement.UpdateThreadContext(context));
		}

		public unsafe Java.Lang.Object? UpdateThreadContext(ICoroutineContext context)
		{
			if (id_updateThreadContext_Lkotlin_coroutines_CoroutineContext_ == IntPtr.Zero)
			{
				id_updateThreadContext_Lkotlin_coroutines_CoroutineContext_ = JNIEnv.GetMethodID(class_ref, "updateThreadContext", "(Lkotlin/coroutines/CoroutineContext;)Ljava/lang/Object;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_updateThreadContext_Lkotlin_coroutines_CoroutineContext_, ptr), JniHandleOwnership.TransferLocalRef);
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
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IThreadContextElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Key);
		}

		private static Delegate GetFold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_Handler()
		{
			if ((object)cb_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_ == null)
			{
				cb_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_));
			}
			return cb_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_;
		}

		private static IntPtr n_Fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_(IntPtr jnienv, IntPtr native__this, IntPtr native_initial, IntPtr native_operation)
		{
			IThreadContextElement threadContextElement = Java.Lang.Object.GetObject<IThreadContextElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object initial = Java.Lang.Object.GetObject<Java.Lang.Object>(native_initial, JniHandleOwnership.DoNotTransfer);
			IFunction2 operation = Java.Lang.Object.GetObject<IFunction2>(native_operation, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(threadContextElement.Fold(initial, operation));
		}

		public unsafe Java.Lang.Object? Fold(Java.Lang.Object? initial, IFunction2 operation)
		{
			if (id_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_ == IntPtr.Zero)
			{
				id_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_ = JNIEnv.GetMethodID(class_ref, "fold", "(Ljava/lang/Object;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(initial?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue((operation == null) ? IntPtr.Zero : ((Java.Lang.Object)operation).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetGet_Lkotlin_coroutines_CoroutineContext_Key_Handler()
		{
			if ((object)cb_get_Lkotlin_coroutines_CoroutineContext_Key_ == null)
			{
				cb_get_Lkotlin_coroutines_CoroutineContext_Key_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Get_Lkotlin_coroutines_CoroutineContext_Key_));
			}
			return cb_get_Lkotlin_coroutines_CoroutineContext_Key_;
		}

		private static IntPtr n_Get_Lkotlin_coroutines_CoroutineContext_Key_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			IThreadContextElement threadContextElement = Java.Lang.Object.GetObject<IThreadContextElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContextKey key = Java.Lang.Object.GetObject<ICoroutineContextKey>(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(threadContextElement.Get(key));
		}

		public unsafe Java.Lang.Object? Get(ICoroutineContextKey key)
		{
			if (id_get_Lkotlin_coroutines_CoroutineContext_Key_ == IntPtr.Zero)
			{
				id_get_Lkotlin_coroutines_CoroutineContext_Key_ = JNIEnv.GetMethodID(class_ref, "get", "(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((key == null) ? IntPtr.Zero : ((Java.Lang.Object)key).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_get_Lkotlin_coroutines_CoroutineContext_Key_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetMinusKey_Lkotlin_coroutines_CoroutineContext_Key_Handler()
		{
			if ((object)cb_minusKey_Lkotlin_coroutines_CoroutineContext_Key_ == null)
			{
				cb_minusKey_Lkotlin_coroutines_CoroutineContext_Key_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_MinusKey_Lkotlin_coroutines_CoroutineContext_Key_));
			}
			return cb_minusKey_Lkotlin_coroutines_CoroutineContext_Key_;
		}

		private static IntPtr n_MinusKey_Lkotlin_coroutines_CoroutineContext_Key_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			IThreadContextElement threadContextElement = Java.Lang.Object.GetObject<IThreadContextElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContextKey key = Java.Lang.Object.GetObject<ICoroutineContextKey>(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(threadContextElement.MinusKey(key));
		}

		public unsafe ICoroutineContext MinusKey(ICoroutineContextKey key)
		{
			if (id_minusKey_Lkotlin_coroutines_CoroutineContext_Key_ == IntPtr.Zero)
			{
				id_minusKey_Lkotlin_coroutines_CoroutineContext_Key_ = JNIEnv.GetMethodID(class_ref, "minusKey", "(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((key == null) ? IntPtr.Zero : ((Java.Lang.Object)key).Handle);
			return Java.Lang.Object.GetObject<ICoroutineContext>(JNIEnv.CallObjectMethod(base.Handle, id_minusKey_Lkotlin_coroutines_CoroutineContext_Key_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetPlus_Lkotlin_coroutines_CoroutineContext_Handler()
		{
			if ((object)cb_plus_Lkotlin_coroutines_CoroutineContext_ == null)
			{
				cb_plus_Lkotlin_coroutines_CoroutineContext_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Plus_Lkotlin_coroutines_CoroutineContext_));
			}
			return cb_plus_Lkotlin_coroutines_CoroutineContext_;
		}

		private static IntPtr n_Plus_Lkotlin_coroutines_CoroutineContext_(IntPtr jnienv, IntPtr native__this, IntPtr native_context)
		{
			IThreadContextElement threadContextElement = Java.Lang.Object.GetObject<IThreadContextElement>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContext context = Java.Lang.Object.GetObject<ICoroutineContext>(native_context, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(threadContextElement.Plus(context));
		}

		public unsafe ICoroutineContext Plus(ICoroutineContext context)
		{
			if (id_plus_Lkotlin_coroutines_CoroutineContext_ == IntPtr.Zero)
			{
				id_plus_Lkotlin_coroutines_CoroutineContext_ = JNIEnv.GetMethodID(class_ref, "plus", "(Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
			return Java.Lang.Object.GetObject<ICoroutineContext>(JNIEnv.CallObjectMethod(base.Handle, id_plus_Lkotlin_coroutines_CoroutineContext_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("kotlinx/coroutines/JobKt", DoNotGenerateAcw = true)]
	public sealed class JobKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/JobKt", typeof(JobKt));

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

		internal JobKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("cancel", "(Lkotlin/coroutines/CoroutineContext;Ljava/util/concurrent/CancellationException;)V", "")]
		public unsafe static void Cancel(ICoroutineContext _this_cancel, CancellationException? cause)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_cancel == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_cancel).Handle);
				ptr[1] = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("cancel.(Lkotlin/coroutines/CoroutineContext;Ljava/util/concurrent/CancellationException;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(_this_cancel);
				GC.KeepAlive(cause);
			}
		}

		[Register("cancelChildren", "(Lkotlin/coroutines/CoroutineContext;Ljava/util/concurrent/CancellationException;)V", "")]
		public unsafe static void CancelChildren(ICoroutineContext _this_cancelChildren, CancellationException? cause)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_cancelChildren == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_cancelChildren).Handle);
				ptr[1] = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("cancelChildren.(Lkotlin/coroutines/CoroutineContext;Ljava/util/concurrent/CancellationException;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(_this_cancelChildren);
				GC.KeepAlive(cause);
			}
		}

		[Register("cancelFutureOnCancellation", "(Lkotlinx/coroutines/CancellableContinuation;Ljava/util/concurrent/Future;)V", "")]
		public unsafe static void CancelFutureOnCancellation(ICancellableContinuation _this_cancelFutureOnCancellation, IFuture future)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_cancelFutureOnCancellation == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_cancelFutureOnCancellation).Handle);
				ptr[1] = new JniArgumentValue((future == null) ? IntPtr.Zero : ((Java.Lang.Object)future).Handle);
				_members.StaticMethods.InvokeVoidMethod("cancelFutureOnCancellation.(Lkotlinx/coroutines/CancellableContinuation;Ljava/util/concurrent/Future;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(_this_cancelFutureOnCancellation);
				GC.KeepAlive(future);
			}
		}

		[Register("ensureActive", "(Lkotlin/coroutines/CoroutineContext;)V", "")]
		public unsafe static void EnsureActive(ICoroutineContext _this_ensureActive)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_ensureActive == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_ensureActive).Handle);
				_members.StaticMethods.InvokeVoidMethod("ensureActive.(Lkotlin/coroutines/CoroutineContext;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(_this_ensureActive);
			}
		}

		[Register("isActive", "(Lkotlin/coroutines/CoroutineContext;)Z", "")]
		public unsafe static bool IsActive(ICoroutineContext _this_isActive)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_isActive == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_isActive).Handle);
				return _members.StaticMethods.InvokeBooleanMethod("isActive.(Lkotlin/coroutines/CoroutineContext;)Z", ptr);
			}
			finally
			{
				GC.KeepAlive(_this_isActive);
			}
		}
	}
	[Obsolete("This class is obsoleted in this android platform")]
	[Register("kotlinx/coroutines/JobSupport", DoNotGenerateAcw = true)]
	public class JobSupport : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/JobSupport", typeof(JobSupport));

		private static Delegate? cb_getChildJobCancellationCause;

		private static Delegate? cb_isActive;

		private static Delegate? cb_isScopedCoroutine;

		private static Delegate? cb_afterCompletion_Ljava_lang_Object_;

		private static Delegate? cb_cancel_Ljava_util_concurrent_CancellationException_;

		private static Delegate? cb_cancelInternal_Ljava_lang_Throwable_;

		private static Delegate? cb_cancellationExceptionMessage;

		private static Delegate? cb_childCancelled_Ljava_lang_Throwable_;

		private static Delegate? cb_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_;

		private static Delegate? cb_get_Lkotlin_coroutines_CoroutineContext_Key_;

		private static Delegate? cb_handleJobException_Ljava_lang_Throwable_;

		private static Delegate? cb_minusKey_Lkotlin_coroutines_CoroutineContext_Key_;

		private static Delegate? cb_onCancelling_Ljava_lang_Throwable_;

		private static Delegate? cb_onCompletionInternal_Ljava_lang_Object_;

		private static Delegate? cb_onStart;

		private static Delegate? cb_plus_Lkotlin_coroutines_CoroutineContext_;

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

		public unsafe CancellationException CancellationException
		{
			[Register("getCancellationException", "()Ljava/util/concurrent/CancellationException;", "")]
			get
			{
				return Java.Lang.Object.GetObject<CancellationException>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCancellationException.()Ljava/util/concurrent/CancellationException;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual CancellationException ChildJobCancellationCause
		{
			[Register("getChildJobCancellationCause", "()Ljava/util/concurrent/CancellationException;", "GetGetChildJobCancellationCauseHandler")]
			get
			{
				return Java.Lang.Object.GetObject<CancellationException>(_members.InstanceMethods.InvokeVirtualObjectMethod("getChildJobCancellationCause.()Ljava/util/concurrent/CancellationException;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe ISequence Children
		{
			[Register("getChildren", "()Lkotlin/sequences/Sequence;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ISequence>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getChildren.()Lkotlin/sequences/Sequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected unsafe Throwable? CompletionCause
		{
			[Register("getCompletionCause", "()Ljava/lang/Throwable;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Throwable>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCompletionCause.()Ljava/lang/Throwable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected unsafe bool CompletionCauseHandled
		{
			[Register("getCompletionCauseHandled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("getCompletionCauseHandled.()Z", this, null);
			}
		}

		public unsafe Throwable? CompletionExceptionOrNull
		{
			[Register("getCompletionExceptionOrNull", "()Ljava/lang/Throwable;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Throwable>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getCompletionExceptionOrNull.()Ljava/lang/Throwable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool IsActive
		{
			[Register("isActive", "()Z", "GetIsActiveHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isActive.()Z", this, null);
			}
		}

		public unsafe bool IsCancelled
		{
			[Register("isCancelled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isCancelled.()Z", this, null);
			}
		}

		public unsafe bool IsCompleted
		{
			[Register("isCompleted", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isCompleted.()Z", this, null);
			}
		}

		public unsafe bool IsCompletedExceptionally
		{
			[Register("isCompletedExceptionally", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isCompletedExceptionally.()Z", this, null);
			}
		}

		protected unsafe virtual bool IsScopedCoroutine
		{
			[Register("isScopedCoroutine", "()Z", "GetIsScopedCoroutineHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isScopedCoroutine.()Z", this, null);
			}
		}

		public unsafe ICoroutineContextKey Key
		{
			[Register("getKey", "()Lkotlin/coroutines/CoroutineContext$Key;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ICoroutineContextKey>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getKey.()Lkotlin/coroutines/CoroutineContext$Key;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected JobSupport(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Z)V", "")]
		public unsafe JobSupport(bool active)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(active);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Z)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Z)V", this, ptr);
			}
		}

		private static Delegate GetGetChildJobCancellationCauseHandler()
		{
			if ((object)cb_getChildJobCancellationCause == null)
			{
				cb_getChildJobCancellationCause = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetChildJobCancellationCause));
			}
			return cb_getChildJobCancellationCause;
		}

		private static IntPtr n_GetChildJobCancellationCause(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<JobSupport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ChildJobCancellationCause);
		}

		private static Delegate GetIsActiveHandler()
		{
			if ((object)cb_isActive == null)
			{
				cb_isActive = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsActive));
			}
			return cb_isActive;
		}

		private static bool n_IsActive(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<JobSupport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsActive;
		}

		private static Delegate GetIsScopedCoroutineHandler()
		{
			if ((object)cb_isScopedCoroutine == null)
			{
				cb_isScopedCoroutine = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsScopedCoroutine));
			}
			return cb_isScopedCoroutine;
		}

		private static bool n_IsScopedCoroutine(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<JobSupport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).IsScopedCoroutine;
		}

		private static Delegate GetAfterCompletion_Ljava_lang_Object_Handler()
		{
			if ((object)cb_afterCompletion_Ljava_lang_Object_ == null)
			{
				cb_afterCompletion_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_AfterCompletion_Ljava_lang_Object_));
			}
			return cb_afterCompletion_Ljava_lang_Object_;
		}

		private static void n_AfterCompletion_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_state)
		{
			JobSupport jobSupport = Java.Lang.Object.GetObject<JobSupport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object state = Java.Lang.Object.GetObject<Java.Lang.Object>(native_state, JniHandleOwnership.DoNotTransfer);
			jobSupport.AfterCompletion(state);
		}

		[Register("afterCompletion", "(Ljava/lang/Object;)V", "GetAfterCompletion_Ljava_lang_Object_Handler")]
		protected unsafe virtual void AfterCompletion(Java.Lang.Object? state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("afterCompletion.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetCancel_Ljava_util_concurrent_CancellationException_Handler()
		{
			if ((object)cb_cancel_Ljava_util_concurrent_CancellationException_ == null)
			{
				cb_cancel_Ljava_util_concurrent_CancellationException_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Cancel_Ljava_util_concurrent_CancellationException_));
			}
			return cb_cancel_Ljava_util_concurrent_CancellationException_;
		}

		private static void n_Cancel_Ljava_util_concurrent_CancellationException_(IntPtr jnienv, IntPtr native__this, IntPtr native_cause)
		{
			JobSupport jobSupport = Java.Lang.Object.GetObject<JobSupport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			CancellationException cause = Java.Lang.Object.GetObject<CancellationException>(native_cause, JniHandleOwnership.DoNotTransfer);
			jobSupport.Cancel(cause);
		}

		[Register("cancel", "(Ljava/util/concurrent/CancellationException;)V", "GetCancel_Ljava_util_concurrent_CancellationException_Handler")]
		public unsafe virtual void Cancel(CancellationException? cause)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("cancel.(Ljava/util/concurrent/CancellationException;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(cause);
			}
		}

		[Register("cancelCoroutine", "(Ljava/lang/Throwable;)Z", "")]
		public unsafe bool CancelCoroutine(Throwable? cause)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("cancelCoroutine.(Ljava/lang/Throwable;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(cause);
			}
		}

		private static Delegate GetCancelInternal_Ljava_lang_Throwable_Handler()
		{
			if ((object)cb_cancelInternal_Ljava_lang_Throwable_ == null)
			{
				cb_cancelInternal_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_CancelInternal_Ljava_lang_Throwable_));
			}
			return cb_cancelInternal_Ljava_lang_Throwable_;
		}

		private static void n_CancelInternal_Ljava_lang_Throwable_(IntPtr jnienv, IntPtr native__this, IntPtr native_cause)
		{
			JobSupport jobSupport = Java.Lang.Object.GetObject<JobSupport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Throwable cause = Java.Lang.Object.GetObject<Throwable>(native_cause, JniHandleOwnership.DoNotTransfer);
			jobSupport.CancelInternal(cause);
		}

		[Register("cancelInternal", "(Ljava/lang/Throwable;)V", "GetCancelInternal_Ljava_lang_Throwable_Handler")]
		public unsafe virtual void CancelInternal(Throwable cause)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("cancelInternal.(Ljava/lang/Throwable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(cause);
			}
		}

		private static Delegate GetCancellationExceptionMessageHandler()
		{
			if ((object)cb_cancellationExceptionMessage == null)
			{
				cb_cancellationExceptionMessage = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CancellationExceptionMessage));
			}
			return cb_cancellationExceptionMessage;
		}

		private static IntPtr n_CancellationExceptionMessage(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<JobSupport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CancellationExceptionMessage());
		}

		[Register("cancellationExceptionMessage", "()Ljava/lang/String;", "GetCancellationExceptionMessageHandler")]
		protected unsafe virtual string CancellationExceptionMessage()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("cancellationExceptionMessage.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetChildCancelled_Ljava_lang_Throwable_Handler()
		{
			if ((object)cb_childCancelled_Ljava_lang_Throwable_ == null)
			{
				cb_childCancelled_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_ChildCancelled_Ljava_lang_Throwable_));
			}
			return cb_childCancelled_Ljava_lang_Throwable_;
		}

		private static bool n_ChildCancelled_Ljava_lang_Throwable_(IntPtr jnienv, IntPtr native__this, IntPtr native_cause)
		{
			JobSupport jobSupport = Java.Lang.Object.GetObject<JobSupport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Throwable cause = Java.Lang.Object.GetObject<Throwable>(native_cause, JniHandleOwnership.DoNotTransfer);
			return jobSupport.ChildCancelled(cause);
		}

		[Register("childCancelled", "(Ljava/lang/Throwable;)Z", "GetChildCancelled_Ljava_lang_Throwable_Handler")]
		public unsafe virtual bool ChildCancelled(Throwable cause)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("childCancelled.(Ljava/lang/Throwable;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(cause);
			}
		}

		private static Delegate GetFold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_Handler()
		{
			if ((object)cb_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_ == null)
			{
				cb_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_));
			}
			return cb_fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_;
		}

		private static IntPtr n_Fold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_(IntPtr jnienv, IntPtr native__this, IntPtr native_initial, IntPtr native_operation)
		{
			JobSupport jobSupport = Java.Lang.Object.GetObject<JobSupport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object initial = Java.Lang.Object.GetObject<Java.Lang.Object>(native_initial, JniHandleOwnership.DoNotTransfer);
			IFunction2 operation = Java.Lang.Object.GetObject<IFunction2>(native_operation, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(jobSupport.Fold(initial, operation));
		}

		[Register("fold", "(Ljava/lang/Object;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;", "GetFold_Ljava_lang_Object_Lkotlin_jvm_functions_Function2_Handler")]
		[JavaTypeParameters(new string[] { "R" })]
		public unsafe virtual Java.Lang.Object? Fold(Java.Lang.Object? initial, IFunction2 operation)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(initial);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue((operation == null) ? IntPtr.Zero : ((Java.Lang.Object)operation).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("fold.(Ljava/lang/Object;Lkotlin/jvm/functions/Function2;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(initial);
				GC.KeepAlive(operation);
			}
		}

		private static Delegate GetGet_Lkotlin_coroutines_CoroutineContext_Key_Handler()
		{
			if ((object)cb_get_Lkotlin_coroutines_CoroutineContext_Key_ == null)
			{
				cb_get_Lkotlin_coroutines_CoroutineContext_Key_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Get_Lkotlin_coroutines_CoroutineContext_Key_));
			}
			return cb_get_Lkotlin_coroutines_CoroutineContext_Key_;
		}

		private static IntPtr n_Get_Lkotlin_coroutines_CoroutineContext_Key_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			JobSupport jobSupport = Java.Lang.Object.GetObject<JobSupport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContextKey key = Java.Lang.Object.GetObject<ICoroutineContextKey>(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(jobSupport.Get(key));
		}

		[Register("get", "(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;", "GetGet_Lkotlin_coroutines_CoroutineContext_Key_Handler")]
		[JavaTypeParameters(new string[] { "E extends kotlin.coroutines.CoroutineContext.Element" })]
		public unsafe virtual Java.Lang.Object? Get(ICoroutineContextKey key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((key == null) ? IntPtr.Zero : ((Java.Lang.Object)key).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("get.(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext$Element;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(key);
			}
		}

		private static Delegate GetHandleJobException_Ljava_lang_Throwable_Handler()
		{
			if ((object)cb_handleJobException_Ljava_lang_Throwable_ == null)
			{
				cb_handleJobException_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_HandleJobException_Ljava_lang_Throwable_));
			}
			return cb_handleJobException_Ljava_lang_Throwable_;
		}

		private static bool n_HandleJobException_Ljava_lang_Throwable_(IntPtr jnienv, IntPtr native__this, IntPtr native_exception)
		{
			JobSupport jobSupport = Java.Lang.Object.GetObject<JobSupport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Throwable exception = Java.Lang.Object.GetObject<Throwable>(native_exception, JniHandleOwnership.DoNotTransfer);
			return jobSupport.HandleJobException(exception);
		}

		[Register("handleJobException", "(Ljava/lang/Throwable;)Z", "GetHandleJobException_Ljava_lang_Throwable_Handler")]
		protected unsafe virtual bool HandleJobException(Throwable exception)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(exception?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("handleJobException.(Ljava/lang/Throwable;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(exception);
			}
		}

		[Register("invokeOnCompletion", "(ZZLkotlin/jvm/functions/Function1;)Lkotlinx/coroutines/DisposableHandle;", "")]
		public unsafe IDisposableHandle InvokeOnCompletion(bool onCancelling, bool invokeImmediately, IFunction1 handler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(onCancelling);
				ptr[1] = new JniArgumentValue(invokeImmediately);
				ptr[2] = new JniArgumentValue((handler == null) ? IntPtr.Zero : ((Java.Lang.Object)handler).Handle);
				return Java.Lang.Object.GetObject<IDisposableHandle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("invokeOnCompletion.(ZZLkotlin/jvm/functions/Function1;)Lkotlinx/coroutines/DisposableHandle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(handler);
			}
		}

		[Register("invokeOnCompletion", "(Lkotlin/jvm/functions/Function1;)Lkotlinx/coroutines/DisposableHandle;", "")]
		public unsafe IDisposableHandle InvokeOnCompletion(IFunction1 handler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((handler == null) ? IntPtr.Zero : ((Java.Lang.Object)handler).Handle);
				return Java.Lang.Object.GetObject<IDisposableHandle>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("invokeOnCompletion.(Lkotlin/jvm/functions/Function1;)Lkotlinx/coroutines/DisposableHandle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(handler);
			}
		}

		[Register("join", "(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		public unsafe Java.Lang.Object? Join(IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("join.(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_completion);
			}
		}

		private static Delegate GetMinusKey_Lkotlin_coroutines_CoroutineContext_Key_Handler()
		{
			if ((object)cb_minusKey_Lkotlin_coroutines_CoroutineContext_Key_ == null)
			{
				cb_minusKey_Lkotlin_coroutines_CoroutineContext_Key_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_MinusKey_Lkotlin_coroutines_CoroutineContext_Key_));
			}
			return cb_minusKey_Lkotlin_coroutines_CoroutineContext_Key_;
		}

		private static IntPtr n_MinusKey_Lkotlin_coroutines_CoroutineContext_Key_(IntPtr jnienv, IntPtr native__this, IntPtr native_key)
		{
			JobSupport jobSupport = Java.Lang.Object.GetObject<JobSupport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContextKey key = Java.Lang.Object.GetObject<ICoroutineContextKey>(native_key, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(jobSupport.MinusKey(key));
		}

		[Register("minusKey", "(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext;", "GetMinusKey_Lkotlin_coroutines_CoroutineContext_Key_Handler")]
		public unsafe virtual ICoroutineContext MinusKey(ICoroutineContextKey key)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((key == null) ? IntPtr.Zero : ((Java.Lang.Object)key).Handle);
				return Java.Lang.Object.GetObject<ICoroutineContext>(_members.InstanceMethods.InvokeVirtualObjectMethod("minusKey.(Lkotlin/coroutines/CoroutineContext$Key;)Lkotlin/coroutines/CoroutineContext;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(key);
			}
		}

		private static Delegate GetOnCancelling_Ljava_lang_Throwable_Handler()
		{
			if ((object)cb_onCancelling_Ljava_lang_Throwable_ == null)
			{
				cb_onCancelling_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnCancelling_Ljava_lang_Throwable_));
			}
			return cb_onCancelling_Ljava_lang_Throwable_;
		}

		private static void n_OnCancelling_Ljava_lang_Throwable_(IntPtr jnienv, IntPtr native__this, IntPtr native_cause)
		{
			JobSupport jobSupport = Java.Lang.Object.GetObject<JobSupport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Throwable cause = Java.Lang.Object.GetObject<Throwable>(native_cause, JniHandleOwnership.DoNotTransfer);
			jobSupport.OnCancelling(cause);
		}

		[Register("onCancelling", "(Ljava/lang/Throwable;)V", "GetOnCancelling_Ljava_lang_Throwable_Handler")]
		protected unsafe virtual void OnCancelling(Throwable? cause)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onCancelling.(Ljava/lang/Throwable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(cause);
			}
		}

		private static Delegate GetOnCompletionInternal_Ljava_lang_Object_Handler()
		{
			if ((object)cb_onCompletionInternal_Ljava_lang_Object_ == null)
			{
				cb_onCompletionInternal_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_OnCompletionInternal_Ljava_lang_Object_));
			}
			return cb_onCompletionInternal_Ljava_lang_Object_;
		}

		private static void n_OnCompletionInternal_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_state)
		{
			JobSupport jobSupport = Java.Lang.Object.GetObject<JobSupport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object state = Java.Lang.Object.GetObject<Java.Lang.Object>(native_state, JniHandleOwnership.DoNotTransfer);
			jobSupport.OnCompletionInternal(state);
		}

		[Register("onCompletionInternal", "(Ljava/lang/Object;)V", "GetOnCompletionInternal_Ljava_lang_Object_Handler")]
		protected unsafe virtual void OnCompletionInternal(Java.Lang.Object? state)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeVirtualVoidMethod("onCompletionInternal.(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(state);
			}
		}

		private static Delegate GetOnStartHandler()
		{
			if ((object)cb_onStart == null)
			{
				cb_onStart = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnStart));
			}
			return cb_onStart;
		}

		private static void n_OnStart(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<JobSupport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStart();
		}

		[Register("onStart", "()V", "GetOnStartHandler")]
		protected unsafe virtual void OnStart()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onStart.()V", this, null);
		}

		private static Delegate GetPlus_Lkotlin_coroutines_CoroutineContext_Handler()
		{
			if ((object)cb_plus_Lkotlin_coroutines_CoroutineContext_ == null)
			{
				cb_plus_Lkotlin_coroutines_CoroutineContext_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Plus_Lkotlin_coroutines_CoroutineContext_));
			}
			return cb_plus_Lkotlin_coroutines_CoroutineContext_;
		}

		private static IntPtr n_Plus_Lkotlin_coroutines_CoroutineContext_(IntPtr jnienv, IntPtr native__this, IntPtr native_context)
		{
			JobSupport jobSupport = Java.Lang.Object.GetObject<JobSupport>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICoroutineContext context = Java.Lang.Object.GetObject<ICoroutineContext>(native_context, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(jobSupport.Plus(context));
		}

		[Register("plus", "(Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;", "GetPlus_Lkotlin_coroutines_CoroutineContext_Handler")]
		public unsafe virtual ICoroutineContext Plus(ICoroutineContext context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				return Java.Lang.Object.GetObject<ICoroutineContext>(_members.InstanceMethods.InvokeVirtualObjectMethod("plus.(Lkotlin/coroutines/CoroutineContext;)Lkotlin/coroutines/CoroutineContext;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		[Register("start", "()Z", "")]
		public unsafe bool Start()
		{
			return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("start.()Z", this, null);
		}

		[Register("toCancellationException", "(Ljava/lang/Throwable;Ljava/lang/String;)Ljava/util/concurrent/CancellationException;", "")]
		protected unsafe CancellationException ToCancellationException(Throwable _this_toCancellationException, string? message)
		{
			IntPtr intPtr = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(_this_toCancellationException?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<CancellationException>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toCancellationException.(Ljava/lang/Throwable;Ljava/lang/String;)Ljava/util/concurrent/CancellationException;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(_this_toCancellationException);
			}
		}

		[Register("toDebugString", "()Ljava/lang/String;", "")]
		public unsafe string ToDebugString()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toDebugString.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("kotlinx/coroutines/JobSupportKt", DoNotGenerateAcw = true)]
	public sealed class JobSupportKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/JobSupportKt", typeof(JobSupportKt));

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

		internal JobSupportKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/MainCoroutineDispatcher", DoNotGenerateAcw = true)]
	public abstract class MainCoroutineDispatcher : CoroutineDispatcher
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/MainCoroutineDispatcher", typeof(MainCoroutineDispatcher));

		private static Delegate? cb_getImmediate;

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

		public abstract MainCoroutineDispatcher Immediate
		{
			[Register("getImmediate", "()Lkotlinx/coroutines/MainCoroutineDispatcher;", "GetGetImmediateHandler")]
			get;
		}

		protected MainCoroutineDispatcher(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe MainCoroutineDispatcher()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetImmediateHandler()
		{
			if ((object)cb_getImmediate == null)
			{
				cb_getImmediate = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetImmediate));
			}
			return cb_getImmediate;
		}

		private static IntPtr n_GetImmediate(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<MainCoroutineDispatcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Immediate);
		}

		[Register("toStringInternalImpl", "()Ljava/lang/String;", "")]
		protected unsafe string? ToStringInternalImpl()
		{
			return JNIEnv.GetString(_members.InstanceMethods.InvokeNonvirtualObjectMethod("toStringInternalImpl.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("kotlinx/coroutines/MainCoroutineDispatcher", DoNotGenerateAcw = true)]
	internal class MainCoroutineDispatcherInvoker : MainCoroutineDispatcher
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/MainCoroutineDispatcher", typeof(MainCoroutineDispatcherInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override MainCoroutineDispatcher Immediate
		{
			[Register("getImmediate", "()Lkotlinx/coroutines/MainCoroutineDispatcher;", "GetGetImmediateHandler")]
			get
			{
				return Java.Lang.Object.GetObject<MainCoroutineDispatcher>(_members.InstanceMethods.InvokeAbstractObjectMethod("getImmediate.()Lkotlinx/coroutines/MainCoroutineDispatcher;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public MainCoroutineDispatcherInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("dispatch", "(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V", "GetDispatch_Lkotlin_coroutines_CoroutineContext_Ljava_lang_Runnable_Handler")]
		public unsafe override void Dispatch(ICoroutineContext context, IRunnable block)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				ptr[1] = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("dispatch.(Lkotlin/coroutines/CoroutineContext;Ljava/lang/Runnable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(block);
			}
		}
	}
	[Register("kotlinx/coroutines/NonCancellable", DoNotGenerateAcw = true)]
	public sealed class NonCancellable : AbstractCoroutineContextElement
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/NonCancellable", typeof(NonCancellable));

		[Register("INSTANCE")]
		public static NonCancellable Instance => Java.Lang.Object.GetObject<NonCancellable>(_members.StaticFields.GetObjectValue("INSTANCE.Lkotlinx/coroutines/NonCancellable;").Handle, JniHandleOwnership.TransferLocalRef);

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

		[Obsolete("deprecated")]
		public unsafe CancellationException CancellationException
		{
			[Register("getCancellationException", "()Ljava/util/concurrent/CancellationException;", "")]
			get
			{
				return Java.Lang.Object.GetObject<CancellationException>(_members.InstanceMethods.InvokeAbstractObjectMethod("getCancellationException.()Ljava/util/concurrent/CancellationException;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Obsolete("deprecated")]
		public unsafe ISequence Children
		{
			[Register("getChildren", "()Lkotlin/sequences/Sequence;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ISequence>(_members.InstanceMethods.InvokeAbstractObjectMethod("getChildren.()Lkotlin/sequences/Sequence;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		[Obsolete("deprecated")]
		public unsafe bool IsActive
		{
			[Register("isActive", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isActive.()Z", this, null);
			}
		}

		[Obsolete("deprecated")]
		public unsafe bool IsCancelled
		{
			[Register("isCancelled", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isCancelled.()Z", this, null);
			}
		}

		[Obsolete("deprecated")]
		public unsafe bool IsCompleted
		{
			[Register("isCompleted", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isCompleted.()Z", this, null);
			}
		}

		internal NonCancellable(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Obsolete("deprecated")]
		[Register("cancel", "(Ljava/util/concurrent/CancellationException;)V", "")]
		public unsafe void Cancel(CancellationException? cause)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("cancel.(Ljava/util/concurrent/CancellationException;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(cause);
			}
		}

		[Obsolete("deprecated")]
		[Register("invokeOnCompletion", "(ZZLkotlin/jvm/functions/Function1;)Lkotlinx/coroutines/DisposableHandle;", "")]
		public unsafe IDisposableHandle InvokeOnCompletion(bool onCancelling, bool invokeImmediately, IFunction1 handler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(onCancelling);
				ptr[1] = new JniArgumentValue(invokeImmediately);
				ptr[2] = new JniArgumentValue((handler == null) ? IntPtr.Zero : ((Java.Lang.Object)handler).Handle);
				return Java.Lang.Object.GetObject<IDisposableHandle>(_members.InstanceMethods.InvokeAbstractObjectMethod("invokeOnCompletion.(ZZLkotlin/jvm/functions/Function1;)Lkotlinx/coroutines/DisposableHandle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(handler);
			}
		}

		[Obsolete("deprecated")]
		[Register("invokeOnCompletion", "(Lkotlin/jvm/functions/Function1;)Lkotlinx/coroutines/DisposableHandle;", "")]
		public unsafe IDisposableHandle InvokeOnCompletion(IFunction1 handler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((handler == null) ? IntPtr.Zero : ((Java.Lang.Object)handler).Handle);
				return Java.Lang.Object.GetObject<IDisposableHandle>(_members.InstanceMethods.InvokeAbstractObjectMethod("invokeOnCompletion.(Lkotlin/jvm/functions/Function1;)Lkotlinx/coroutines/DisposableHandle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(handler);
			}
		}

		[Obsolete("deprecated")]
		[Register("join", "(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		public unsafe Java.Lang.Object? Join(IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("join.(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_completion);
			}
		}

		[Obsolete("deprecated")]
		[Register("start", "()Z", "")]
		public unsafe bool Start()
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("start.()Z", this, null);
		}
	}
	[Register("kotlinx/coroutines/NonDisposableHandle", DoNotGenerateAcw = true)]
	public sealed class NonDisposableHandle : Java.Lang.Object, IDisposableHandle, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/NonDisposableHandle", typeof(NonDisposableHandle));

		[Register("INSTANCE")]
		public static NonDisposableHandle Instance => Java.Lang.Object.GetObject<NonDisposableHandle>(_members.StaticFields.GetObjectValue("INSTANCE.Lkotlinx/coroutines/NonDisposableHandle;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal NonDisposableHandle(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("childCancelled", "(Ljava/lang/Throwable;)Z", "")]
		public unsafe bool ChildCancelled(Throwable cause)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("childCancelled.(Ljava/lang/Throwable;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(cause);
			}
		}

		[Register("dispose", "()V", "")]
		public new unsafe void Dispose()
		{
			_members.InstanceMethods.InvokeAbstractVoidMethod("dispose.()V", this, null);
		}
	}
	[Annotation("kotlinx.coroutines.ObsoleteCoroutinesApi")]
	public class ObsoleteCoroutinesApiAttribute : Attribute
	{
	}
	[Register("kotlinx/coroutines/RunnableKt", DoNotGenerateAcw = true)]
	public sealed class RunnableKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/RunnableKt", typeof(RunnableKt));

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

		internal RunnableKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("Runnable", "(Lkotlin/jvm/functions/Function0;)Ljava/lang/Runnable;", "")]
		public unsafe static IRunnable Runnable(IFunction0 block)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				return Java.Lang.Object.GetObject<IRunnable>(_members.StaticMethods.InvokeObjectMethod("Runnable.(Lkotlin/jvm/functions/Function0;)Ljava/lang/Runnable;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(block);
			}
		}
	}
	[Register("kotlinx/coroutines/SchedulerTaskKt", DoNotGenerateAcw = true)]
	public sealed class SchedulerTaskKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/SchedulerTaskKt", typeof(SchedulerTaskKt));

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

		internal SchedulerTaskKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("getTaskContext", "(Ljava/lang/Object;)Lkotlinx/coroutines/scheduling/TaskContext;", "")]
		public unsafe static Java.Lang.Object GetTaskContext(Java.Lang.Object obj)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("getTaskContext.(Ljava/lang/Object;)Lkotlinx/coroutines/scheduling/TaskContext;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}
	}
	[Register("kotlinx/coroutines/SupervisorKt", DoNotGenerateAcw = true)]
	public sealed class SupervisorKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/SupervisorKt", typeof(SupervisorKt));

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

		internal SupervisorKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("supervisorScope", "(Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "R" })]
		public unsafe static Java.Lang.Object? SupervisorScope(IFunction2 block, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				ptr[1] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("supervisorScope.(Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(block);
				GC.KeepAlive(_completion);
			}
		}
	}
	[Register("kotlinx/coroutines/ThreadContextElementKt", DoNotGenerateAcw = true)]
	public sealed class ThreadContextElementKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/ThreadContextElementKt", typeof(ThreadContextElementKt));

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

		internal ThreadContextElementKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("asContextElement", "(Ljava/lang/ThreadLocal;Ljava/lang/Object;)Lkotlinx/coroutines/ThreadContextElement;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IThreadContextElement AsContextElement(ThreadLocal obj, Java.Lang.Object? value)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<IThreadContextElement>(_members.StaticMethods.InvokeObjectMethod("asContextElement.(Ljava/lang/ThreadLocal;Ljava/lang/Object;)Lkotlinx/coroutines/ThreadContextElement;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(obj);
				GC.KeepAlive(value);
			}
		}

		[Register("ensurePresent", "(Ljava/lang/ThreadLocal;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		public unsafe static Java.Lang.Object? EnsurePresent(ThreadLocal obj, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("ensurePresent.(Ljava/lang/ThreadLocal;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(_completion);
			}
		}

		[Register("isPresent", "(Ljava/lang/ThreadLocal;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		public unsafe static Java.Lang.Object? IsPresent(ThreadLocal obj, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("isPresent.(Ljava/lang/ThreadLocal;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(_completion);
			}
		}
	}
	[Register("kotlinx/coroutines/ThreadPoolDispatcherKt", DoNotGenerateAcw = true)]
	public sealed class ThreadPoolDispatcherKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/ThreadPoolDispatcherKt", typeof(ThreadPoolDispatcherKt));

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

		internal ThreadPoolDispatcherKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("newFixedThreadPoolContext", "(ILjava/lang/String;)Lkotlinx/coroutines/ExecutorCoroutineDispatcher;", "")]
		public unsafe static ExecutorCoroutineDispatcher NewFixedThreadPoolContext(int nThreads, string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(nThreads);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ExecutorCoroutineDispatcher>(_members.StaticMethods.InvokeObjectMethod("newFixedThreadPoolContext.(ILjava/lang/String;)Lkotlinx/coroutines/ExecutorCoroutineDispatcher;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("newSingleThreadContext", "(Ljava/lang/String;)Lkotlinx/coroutines/ExecutorCoroutineDispatcher;", "")]
		public unsafe static ExecutorCoroutineDispatcher NewSingleThreadContext(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ExecutorCoroutineDispatcher>(_members.StaticMethods.InvokeObjectMethod("newSingleThreadContext.(Ljava/lang/String;)Lkotlinx/coroutines/ExecutorCoroutineDispatcher;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("kotlinx/coroutines/TimeoutCancellationException", DoNotGenerateAcw = true)]
	public sealed class TimeoutCancellationException : CancellationException, ICopyableThrowable, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/TimeoutCancellationException", typeof(TimeoutCancellationException));

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

		internal TimeoutCancellationException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("createCopy", "()Lkotlinx/coroutines/TimeoutCancellationException;", "")]
		public unsafe TimeoutCancellationException CreateCopy()
		{
			return Java.Lang.Object.GetObject<TimeoutCancellationException>(_members.InstanceMethods.InvokeAbstractObjectMethod("createCopy.()Lkotlinx/coroutines/TimeoutCancellationException;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		Java.Lang.Object? ICopyableThrowable.CreateCopy()
		{
			return JavaObjectExtensions.JavaCast<Java.Lang.Object>(CreateCopy());
		}
	}
	[Register("kotlinx/coroutines/TimeoutKt", DoNotGenerateAcw = true)]
	public sealed class TimeoutKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/TimeoutKt", typeof(TimeoutKt));

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

		internal TimeoutKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("withTimeout", "(JLkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? WithTimeout(long timeMillis, IFunction2 block, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(timeMillis);
				ptr[1] = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				ptr[2] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("withTimeout.(JLkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(block);
				GC.KeepAlive(_completion);
			}
		}

		[Register("withTimeoutOrNull", "(JLkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? WithTimeoutOrNull(long timeMillis, IFunction2 block, IContinuation p2)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(timeMillis);
				ptr[1] = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("withTimeoutOrNull.(JLkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(block);
				GC.KeepAlive(p2);
			}
		}
	}
	[Register("kotlinx/coroutines/YieldKt", DoNotGenerateAcw = true)]
	public sealed class YieldKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/YieldKt", typeof(YieldKt));

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

		internal YieldKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("yield", "(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		public unsafe static Java.Lang.Object? Yield(IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("yield.(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_completion);
			}
		}
	}
}
namespace Xamarin.KotlinX.Coroutines.Sync
{
	[Register("kotlinx/coroutines/sync/Semaphore", "", "Xamarin.KotlinX.Coroutines.Sync.ISemaphoreInvoker")]
	public interface ISemaphore : IJavaObject, IDisposable, IJavaPeerable
	{
		int AvailablePermits
		{
			[Register("getAvailablePermits", "()I", "GetGetAvailablePermitsHandler:Xamarin.KotlinX.Coroutines.Sync.ISemaphoreInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
			get;
		}

		[Register("acquire", "(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "GetAcquire_Lkotlin_coroutines_Continuation_Handler:Xamarin.KotlinX.Coroutines.Sync.ISemaphoreInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		Java.Lang.Object? Acquire(IContinuation p0);

		[Register("release", "()V", "GetReleaseHandler:Xamarin.KotlinX.Coroutines.Sync.ISemaphoreInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		void Release();

		[Register("tryAcquire", "()Z", "GetTryAcquireHandler:Xamarin.KotlinX.Coroutines.Sync.ISemaphoreInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		bool TryAcquire();
	}
	[Register("kotlinx/coroutines/sync/Semaphore", DoNotGenerateAcw = true)]
	internal class ISemaphoreInvoker : Java.Lang.Object, ISemaphore, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/sync/Semaphore", typeof(ISemaphoreInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_getAvailablePermits;

		private IntPtr id_getAvailablePermits;

		private static Delegate? cb_acquire_Lkotlin_coroutines_Continuation_;

		private IntPtr id_acquire_Lkotlin_coroutines_Continuation_;

		private static Delegate? cb_release;

		private IntPtr id_release;

		private static Delegate? cb_tryAcquire;

		private IntPtr id_tryAcquire;

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

		public int AvailablePermits
		{
			get
			{
				if (id_getAvailablePermits == IntPtr.Zero)
				{
					id_getAvailablePermits = JNIEnv.GetMethodID(class_ref, "getAvailablePermits", "()I");
				}
				return JNIEnv.CallIntMethod(base.Handle, id_getAvailablePermits);
			}
		}

		public static ISemaphore? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISemaphore>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'kotlinx.coroutines.sync.Semaphore'.");
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

		public ISemaphoreInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetAvailablePermitsHandler()
		{
			if ((object)cb_getAvailablePermits == null)
			{
				cb_getAvailablePermits = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_I(n_GetAvailablePermits));
			}
			return cb_getAvailablePermits;
		}

		private static int n_GetAvailablePermits(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ISemaphore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).AvailablePermits;
		}

		private static Delegate GetAcquire_Lkotlin_coroutines_Continuation_Handler()
		{
			if ((object)cb_acquire_Lkotlin_coroutines_Continuation_ == null)
			{
				cb_acquire_Lkotlin_coroutines_Continuation_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Acquire_Lkotlin_coroutines_Continuation_));
			}
			return cb_acquire_Lkotlin_coroutines_Continuation_;
		}

		private static IntPtr n_Acquire_Lkotlin_coroutines_Continuation_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			ISemaphore semaphore = Java.Lang.Object.GetObject<ISemaphore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IContinuation p = Java.Lang.Object.GetObject<IContinuation>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(semaphore.Acquire(p));
		}

		public unsafe Java.Lang.Object? Acquire(IContinuation p0)
		{
			if (id_acquire_Lkotlin_coroutines_Continuation_ == IntPtr.Zero)
			{
				id_acquire_Lkotlin_coroutines_Continuation_ = JNIEnv.GetMethodID(class_ref, "acquire", "(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_acquire_Lkotlin_coroutines_Continuation_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetReleaseHandler()
		{
			if ((object)cb_release == null)
			{
				cb_release = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_Release));
			}
			return cb_release;
		}

		private static void n_Release(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ISemaphore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Release();
		}

		public void Release()
		{
			if (id_release == IntPtr.Zero)
			{
				id_release = JNIEnv.GetMethodID(class_ref, "release", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_release);
		}

		private static Delegate GetTryAcquireHandler()
		{
			if ((object)cb_tryAcquire == null)
			{
				cb_tryAcquire = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_TryAcquire));
			}
			return cb_tryAcquire;
		}

		private static bool n_TryAcquire(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ISemaphore>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TryAcquire();
		}

		public bool TryAcquire()
		{
			if (id_tryAcquire == IntPtr.Zero)
			{
				id_tryAcquire = JNIEnv.GetMethodID(class_ref, "tryAcquire", "()Z");
			}
			return JNIEnv.CallBooleanMethod(base.Handle, id_tryAcquire);
		}
	}
	[Register("kotlinx/coroutines/sync/MutexKt", DoNotGenerateAcw = true)]
	public sealed class MutexKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/sync/MutexKt", typeof(MutexKt));

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

		internal MutexKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/sync/SemaphoreKt", DoNotGenerateAcw = true)]
	public sealed class SemaphoreKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/sync/SemaphoreKt", typeof(SemaphoreKt));

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

		internal SemaphoreKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("Semaphore", "(II)Lkotlinx/coroutines/sync/Semaphore;", "")]
		public unsafe static ISemaphore Semaphore(int permits, int acquiredPermits)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(permits);
			ptr[1] = new JniArgumentValue(acquiredPermits);
			return Java.Lang.Object.GetObject<ISemaphore>(_members.StaticMethods.InvokeObjectMethod("Semaphore.(II)Lkotlinx/coroutines/sync/Semaphore;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("withPermit", "(Lkotlinx/coroutines/sync/Semaphore;Lkotlin/jvm/functions/Function0;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? WithPermit(ISemaphore p0, IFunction0 action, IContinuation p2)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
				ptr[1] = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
				ptr[2] = new JniArgumentValue((p2 == null) ? IntPtr.Zero : ((Java.Lang.Object)p2).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("withPermit.(Lkotlinx/coroutines/sync/Semaphore;Lkotlin/jvm/functions/Function0;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(p0);
				GC.KeepAlive(action);
				GC.KeepAlive(p2);
			}
		}
	}
}
namespace Xamarin.KotlinX.Coroutines.Selects
{
	[Register("kotlinx/coroutines/selects/SelectKt", DoNotGenerateAcw = true)]
	public sealed class SelectKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/selects/SelectKt", typeof(SelectKt));

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

		internal SelectKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("select", "(Lkotlin/jvm/functions/Function1;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "R" })]
		public unsafe static Java.Lang.Object? Select(IFunction1 builder, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((builder == null) ? IntPtr.Zero : ((Java.Lang.Object)builder).Handle);
				ptr[1] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("select.(Lkotlin/jvm/functions/Function1;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(builder);
				GC.KeepAlive(_completion);
			}
		}
	}
	[Register("kotlinx/coroutines/selects/SelectUnbiasedKt", DoNotGenerateAcw = true)]
	public sealed class SelectUnbiasedKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/selects/SelectUnbiasedKt", typeof(SelectUnbiasedKt));

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

		internal SelectUnbiasedKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("selectUnbiased", "(Lkotlin/jvm/functions/Function1;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "R" })]
		public unsafe static Java.Lang.Object? SelectUnbiased(IFunction1 builder, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((builder == null) ? IntPtr.Zero : ((Java.Lang.Object)builder).Handle);
				ptr[1] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("selectUnbiased.(Lkotlin/jvm/functions/Function1;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(builder);
				GC.KeepAlive(_completion);
			}
		}
	}
	[Register("kotlinx/coroutines/selects/WhileSelectKt", DoNotGenerateAcw = true)]
	public sealed class WhileSelectKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/selects/WhileSelectKt", typeof(WhileSelectKt));

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

		internal WhileSelectKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("whileSelect", "(Lkotlin/jvm/functions/Function1;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		public unsafe static Java.Lang.Object? WhileSelect(IFunction1 builder, IContinuation p1)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((builder == null) ? IntPtr.Zero : ((Java.Lang.Object)builder).Handle);
				ptr[1] = new JniArgumentValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("whileSelect.(Lkotlin/jvm/functions/Function1;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(builder);
				GC.KeepAlive(p1);
			}
		}
	}
}
namespace Xamarin.KotlinX.Coroutines.Scheduling
{
	[Register("kotlinx/coroutines/scheduling/CoroutineSchedulerKt", DoNotGenerateAcw = true)]
	public sealed class CoroutineSchedulerKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/scheduling/CoroutineSchedulerKt", typeof(CoroutineSchedulerKt));

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

		internal CoroutineSchedulerKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/scheduling/TasksKt", DoNotGenerateAcw = true)]
	public sealed class TasksKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/scheduling/TasksKt", typeof(TasksKt));

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

		internal TasksKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("isBlocking", "(Ljava/lang/Object;)Z", "")]
		public unsafe static bool IsBlocking(Java.Lang.Object obj)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				return _members.StaticMethods.InvokeBooleanMethod("isBlocking.(Ljava/lang/Object;)Z", ptr);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}
	}
	[Register("kotlinx/coroutines/scheduling/WorkQueueKt", DoNotGenerateAcw = true)]
	public sealed class WorkQueueKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/scheduling/WorkQueueKt", typeof(WorkQueueKt));

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

		internal WorkQueueKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
}
namespace Xamarin.KotlinX.Coroutines.Intrinsics
{
	[Register("kotlinx/coroutines/intrinsics/CancellableKt", DoNotGenerateAcw = true)]
	public sealed class CancellableKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/intrinsics/CancellableKt", typeof(CancellableKt));

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

		internal CancellableKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("startCoroutineCancellable", "(Lkotlin/jvm/functions/Function1;Lkotlin/coroutines/Continuation;)V", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static void StartCoroutineCancellable(IFunction1 obj, IContinuation completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				ptr[1] = new JniArgumentValue((completion == null) ? IntPtr.Zero : ((Java.Lang.Object)completion).Handle);
				_members.StaticMethods.InvokeVoidMethod("startCoroutineCancellable.(Lkotlin/jvm/functions/Function1;Lkotlin/coroutines/Continuation;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(completion);
			}
		}
	}
	[Register("kotlinx/coroutines/intrinsics/UndispatchedKt", DoNotGenerateAcw = true)]
	public sealed class UndispatchedKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/intrinsics/UndispatchedKt", typeof(UndispatchedKt));

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

		internal UndispatchedKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
}
namespace Xamarin.KotlinX.Coroutines.Flow
{
	[Register("kotlinx/coroutines/flow/FlowKt", DoNotGenerateAcw = true)]
	public sealed class FlowKt : Java.Lang.Object
	{
		[Register("DEFAULT_CONCURRENCY_PROPERTY_NAME")]
		public const string DefaultConcurrencyPropertyName = "kotlinx.coroutines.flow.defaultConcurrency";

		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/flow/FlowKt", typeof(FlowKt));

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

		public unsafe static int DEFAULT_CONCURRENCY
		{
			[Register("getDEFAULT_CONCURRENCY", "()I", "")]
			get
			{
				return _members.StaticMethods.InvokeInt32Method("getDEFAULT_CONCURRENCY.()I", null);
			}
		}

		internal FlowKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("asFlow", "([I)Lkotlinx/coroutines/flow/Flow;", "")]
		public unsafe static IFlow AsFlow(int[] _this_asFlow)
		{
			IntPtr intPtr = JNIEnv.NewArray(_this_asFlow);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("asFlow.([I)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (_this_asFlow != null)
				{
					JNIEnv.CopyArray(intPtr, _this_asFlow);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(_this_asFlow);
			}
		}

		[Register("asFlow", "(Ljava/lang/Iterable;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow AsFlow(IIterable _this_asFlow)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_asFlow == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_asFlow).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("asFlow.(Ljava/lang/Iterable;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_asFlow);
			}
		}

		[Register("asFlow", "(Ljava/util/Iterator;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow AsFlow(IIterator _this_asFlow)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_asFlow == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_asFlow).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("asFlow.(Ljava/util/Iterator;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_asFlow);
			}
		}

		[Register("asFlow", "(Lkotlin/jvm/functions/Function0;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow AsFlow(IFunction0 _this_asFlow)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_asFlow == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_asFlow).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("asFlow.(Lkotlin/jvm/functions/Function0;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_asFlow);
			}
		}

		[Register("asFlow", "(Lkotlin/jvm/functions/Function1;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow AsFlow(IFunction1 _this_asFlow)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_asFlow == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_asFlow).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("asFlow.(Lkotlin/jvm/functions/Function1;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_asFlow);
			}
		}

		[Register("asFlow", "(Lkotlin/ranges/IntRange;)Lkotlinx/coroutines/flow/Flow;", "")]
		public unsafe static IFlow AsFlow(IntRange _this_asFlow)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(_this_asFlow?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("asFlow.(Lkotlin/ranges/IntRange;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_asFlow);
			}
		}

		[Register("asFlow", "(Lkotlin/ranges/LongRange;)Lkotlinx/coroutines/flow/Flow;", "")]
		public unsafe static IFlow AsFlow(LongRange _this_asFlow)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(_this_asFlow?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("asFlow.(Lkotlin/ranges/LongRange;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_asFlow);
			}
		}

		[Register("asFlow", "(Lkotlin/sequences/Sequence;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow AsFlow(ISequence _this_asFlow)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_asFlow == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_asFlow).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("asFlow.(Lkotlin/sequences/Sequence;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_asFlow);
			}
		}

		[Register("asFlow", "([J)Lkotlinx/coroutines/flow/Flow;", "")]
		public unsafe static IFlow AsFlow(long[] _this_asFlow)
		{
			IntPtr intPtr = JNIEnv.NewArray(_this_asFlow);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("asFlow.([J)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (_this_asFlow != null)
				{
					JNIEnv.CopyArray(intPtr, _this_asFlow);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(_this_asFlow);
			}
		}

		[Register("asFlow", "([Ljava/lang/Object;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow AsFlow(Java.Lang.Object[] _this_asFlow)
		{
			IntPtr intPtr = JNIEnv.NewArray(_this_asFlow);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("asFlow.([Ljava/lang/Object;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (_this_asFlow != null)
				{
					JNIEnv.CopyArray(intPtr, _this_asFlow);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(_this_asFlow);
			}
		}

		[Register("asSharedFlow", "(Lkotlinx/coroutines/flow/MutableSharedFlow;)Lkotlinx/coroutines/flow/SharedFlow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static ISharedFlow AsSharedFlow(IMutableSharedFlow _this_asSharedFlow)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_asSharedFlow == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_asSharedFlow).Handle);
				return Java.Lang.Object.GetObject<ISharedFlow>(_members.StaticMethods.InvokeObjectMethod("asSharedFlow.(Lkotlinx/coroutines/flow/MutableSharedFlow;)Lkotlinx/coroutines/flow/SharedFlow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_asSharedFlow);
			}
		}

		[Register("asStateFlow", "(Lkotlinx/coroutines/flow/MutableStateFlow;)Lkotlinx/coroutines/flow/StateFlow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IStateFlow AsStateFlow(IMutableStateFlow _this_asStateFlow)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_asStateFlow == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_asStateFlow).Handle);
				return Java.Lang.Object.GetObject<IStateFlow>(_members.StaticMethods.InvokeObjectMethod("asStateFlow.(Lkotlinx/coroutines/flow/MutableStateFlow;)Lkotlinx/coroutines/flow/StateFlow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_asStateFlow);
			}
		}

		[Register("buffer", "(Lkotlinx/coroutines/flow/Flow;ILkotlinx/coroutines/channels/BufferOverflow;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Buffer(IFlow _this_buffer, int capacity, BufferOverflow onBufferOverflow)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_buffer == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_buffer).Handle);
				ptr[1] = new JniArgumentValue(capacity);
				ptr[2] = new JniArgumentValue(onBufferOverflow?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("buffer.(Lkotlinx/coroutines/flow/Flow;ILkotlinx/coroutines/channels/BufferOverflow;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_buffer);
				GC.KeepAlive(onBufferOverflow);
			}
		}

		[Obsolete("deprecated")]
		[Register("cache", "(Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Cache(IFlow _this_cache)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_cache == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_cache).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("cache.(Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_cache);
			}
		}

		[Register("callbackFlow", "(Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow CallbackFlow(IFunction2 block)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("callbackFlow.(Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(block);
			}
		}

		[Register("cancellable", "(Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Cancellable(IFlow _this_cancellable)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_cancellable == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_cancellable).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("cancellable.(Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_cancellable);
			}
		}

		[Register("catch", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Catch(IFlow _this_catch, IFunction3 action)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_catch == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_catch).Handle);
				ptr[1] = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("catch.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_catch);
				GC.KeepAlive(action);
			}
		}

		[Register("catchImpl", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/FlowCollector;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? CatchImpl(IFlow _this_catchImpl, IFlowCollector collector, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_catchImpl == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_catchImpl).Handle);
				ptr[1] = new JniArgumentValue((collector == null) ? IntPtr.Zero : ((Java.Lang.Object)collector).Handle);
				ptr[2] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("catchImpl.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/FlowCollector;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_catchImpl);
				GC.KeepAlive(collector);
				GC.KeepAlive(_completion);
			}
		}

		[Register("channelFlow", "(Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow ChannelFlow(IFunction2 block)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("channelFlow.(Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(block);
			}
		}

		[Register("collect", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		public unsafe static Java.Lang.Object? Collect(IFlow _this_collect, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_collect == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_collect).Handle);
				ptr[1] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("collect.(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_collect);
				GC.KeepAlive(_completion);
			}
		}

		[Register("collectIndexed", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? CollectIndexed(IFlow _this_collectIndexed, IFunction3 action, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_collectIndexed == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_collectIndexed).Handle);
				ptr[1] = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
				ptr[2] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("collectIndexed.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_collectIndexed);
				GC.KeepAlive(action);
				GC.KeepAlive(_completion);
			}
		}

		[Register("collectLatest", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? CollectLatest(IFlow _this_collectLatest, IFunction2 action, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_collectLatest == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_collectLatest).Handle);
				ptr[1] = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
				ptr[2] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("collectLatest.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_collectLatest);
				GC.KeepAlive(action);
				GC.KeepAlive(_completion);
			}
		}

		[Register("collectWhile", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? CollectWhile(IFlow _this_collectWhile, IFunction2 predicate, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_collectWhile == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_collectWhile).Handle);
				ptr[1] = new JniArgumentValue((predicate == null) ? IntPtr.Zero : ((Java.Lang.Object)predicate).Handle);
				ptr[2] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("collectWhile.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_collectWhile);
				GC.KeepAlive(predicate);
				GC.KeepAlive(_completion);
			}
		}

		[Register("combine", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T1", "T2", "R" })]
		public unsafe static IFlow Combine(IFlow flow, IFlow flow2, IFunction3 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((flow == null) ? IntPtr.Zero : ((Java.Lang.Object)flow).Handle);
				ptr[1] = new JniArgumentValue((flow2 == null) ? IntPtr.Zero : ((Java.Lang.Object)flow2).Handle);
				ptr[2] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("combine.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(flow);
				GC.KeepAlive(flow2);
				GC.KeepAlive(transform);
			}
		}

		[Register("combine", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function4;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T1", "T2", "T3", "R" })]
		public unsafe static IFlow Combine(IFlow flow, IFlow flow2, IFlow flow3, IFunction4 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue((flow == null) ? IntPtr.Zero : ((Java.Lang.Object)flow).Handle);
				ptr[1] = new JniArgumentValue((flow2 == null) ? IntPtr.Zero : ((Java.Lang.Object)flow2).Handle);
				ptr[2] = new JniArgumentValue((flow3 == null) ? IntPtr.Zero : ((Java.Lang.Object)flow3).Handle);
				ptr[3] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("combine.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function4;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(flow);
				GC.KeepAlive(flow2);
				GC.KeepAlive(flow3);
				GC.KeepAlive(transform);
			}
		}

		[Register("combine", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function5;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T1", "T2", "T3", "T4", "R" })]
		public unsafe static IFlow Combine(IFlow flow, IFlow flow2, IFlow flow3, IFlow flow4, IFunction5 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue((flow == null) ? IntPtr.Zero : ((Java.Lang.Object)flow).Handle);
				ptr[1] = new JniArgumentValue((flow2 == null) ? IntPtr.Zero : ((Java.Lang.Object)flow2).Handle);
				ptr[2] = new JniArgumentValue((flow3 == null) ? IntPtr.Zero : ((Java.Lang.Object)flow3).Handle);
				ptr[3] = new JniArgumentValue((flow4 == null) ? IntPtr.Zero : ((Java.Lang.Object)flow4).Handle);
				ptr[4] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("combine.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function5;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(flow);
				GC.KeepAlive(flow2);
				GC.KeepAlive(flow3);
				GC.KeepAlive(flow4);
				GC.KeepAlive(transform);
			}
		}

		[Register("combine", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function6;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T1", "T2", "T3", "T4", "T5", "R" })]
		public unsafe static IFlow Combine(IFlow flow, IFlow flow2, IFlow flow3, IFlow flow4, IFlow flow5, IFunction6 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue((flow == null) ? IntPtr.Zero : ((Java.Lang.Object)flow).Handle);
				ptr[1] = new JniArgumentValue((flow2 == null) ? IntPtr.Zero : ((Java.Lang.Object)flow2).Handle);
				ptr[2] = new JniArgumentValue((flow3 == null) ? IntPtr.Zero : ((Java.Lang.Object)flow3).Handle);
				ptr[3] = new JniArgumentValue((flow4 == null) ? IntPtr.Zero : ((Java.Lang.Object)flow4).Handle);
				ptr[4] = new JniArgumentValue((flow5 == null) ? IntPtr.Zero : ((Java.Lang.Object)flow5).Handle);
				ptr[5] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("combine.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function6;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(flow);
				GC.KeepAlive(flow2);
				GC.KeepAlive(flow3);
				GC.KeepAlive(flow4);
				GC.KeepAlive(flow5);
				GC.KeepAlive(transform);
			}
		}

		[Obsolete("deprecated")]
		[Register("combineLatest", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T1", "T2", "R" })]
		public unsafe static IFlow CombineLatest(IFlow _this_combineLatest, IFlow other, IFunction3 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_combineLatest == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_combineLatest).Handle);
				ptr[1] = new JniArgumentValue((other == null) ? IntPtr.Zero : ((Java.Lang.Object)other).Handle);
				ptr[2] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("combineLatest.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_combineLatest);
				GC.KeepAlive(other);
				GC.KeepAlive(transform);
			}
		}

		[Obsolete("deprecated")]
		[Register("combineLatest", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function4;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T1", "T2", "T3", "R" })]
		public unsafe static IFlow CombineLatest(IFlow _this_combineLatest, IFlow other, IFlow other2, IFunction4 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue((_this_combineLatest == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_combineLatest).Handle);
				ptr[1] = new JniArgumentValue((other == null) ? IntPtr.Zero : ((Java.Lang.Object)other).Handle);
				ptr[2] = new JniArgumentValue((other2 == null) ? IntPtr.Zero : ((Java.Lang.Object)other2).Handle);
				ptr[3] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("combineLatest.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function4;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_combineLatest);
				GC.KeepAlive(other);
				GC.KeepAlive(other2);
				GC.KeepAlive(transform);
			}
		}

		[Obsolete("deprecated")]
		[Register("combineLatest", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function5;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T1", "T2", "T3", "T4", "R" })]
		public unsafe static IFlow CombineLatest(IFlow _this_combineLatest, IFlow other, IFlow other2, IFlow other3, IFunction5 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue((_this_combineLatest == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_combineLatest).Handle);
				ptr[1] = new JniArgumentValue((other == null) ? IntPtr.Zero : ((Java.Lang.Object)other).Handle);
				ptr[2] = new JniArgumentValue((other2 == null) ? IntPtr.Zero : ((Java.Lang.Object)other2).Handle);
				ptr[3] = new JniArgumentValue((other3 == null) ? IntPtr.Zero : ((Java.Lang.Object)other3).Handle);
				ptr[4] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("combineLatest.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function5;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_combineLatest);
				GC.KeepAlive(other);
				GC.KeepAlive(other2);
				GC.KeepAlive(other3);
				GC.KeepAlive(transform);
			}
		}

		[Obsolete("deprecated")]
		[Register("combineLatest", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function6;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T1", "T2", "T3", "T4", "T5", "R" })]
		public unsafe static IFlow CombineLatest(IFlow _this_combineLatest, IFlow other, IFlow other2, IFlow other3, IFlow other4, IFunction6 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue((_this_combineLatest == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_combineLatest).Handle);
				ptr[1] = new JniArgumentValue((other == null) ? IntPtr.Zero : ((Java.Lang.Object)other).Handle);
				ptr[2] = new JniArgumentValue((other2 == null) ? IntPtr.Zero : ((Java.Lang.Object)other2).Handle);
				ptr[3] = new JniArgumentValue((other3 == null) ? IntPtr.Zero : ((Java.Lang.Object)other3).Handle);
				ptr[4] = new JniArgumentValue((other4 == null) ? IntPtr.Zero : ((Java.Lang.Object)other4).Handle);
				ptr[5] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("combineLatest.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function6;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_combineLatest);
				GC.KeepAlive(other);
				GC.KeepAlive(other2);
				GC.KeepAlive(other3);
				GC.KeepAlive(other4);
				GC.KeepAlive(transform);
			}
		}

		[Register("combineTransform", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function4;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T1", "T2", "R" })]
		public unsafe static IFlow CombineTransform(IFlow flow, IFlow flow2, IFunction4 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((flow == null) ? IntPtr.Zero : ((Java.Lang.Object)flow).Handle);
				ptr[1] = new JniArgumentValue((flow2 == null) ? IntPtr.Zero : ((Java.Lang.Object)flow2).Handle);
				ptr[2] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("combineTransform.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function4;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(flow);
				GC.KeepAlive(flow2);
				GC.KeepAlive(transform);
			}
		}

		[Register("combineTransform", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function5;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T1", "T2", "T3", "R" })]
		public unsafe static IFlow CombineTransform(IFlow flow, IFlow flow2, IFlow flow3, IFunction5 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue((flow == null) ? IntPtr.Zero : ((Java.Lang.Object)flow).Handle);
				ptr[1] = new JniArgumentValue((flow2 == null) ? IntPtr.Zero : ((Java.Lang.Object)flow2).Handle);
				ptr[2] = new JniArgumentValue((flow3 == null) ? IntPtr.Zero : ((Java.Lang.Object)flow3).Handle);
				ptr[3] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("combineTransform.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function5;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(flow);
				GC.KeepAlive(flow2);
				GC.KeepAlive(flow3);
				GC.KeepAlive(transform);
			}
		}

		[Register("combineTransform", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function6;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T1", "T2", "T3", "T4", "R" })]
		public unsafe static IFlow CombineTransform(IFlow flow, IFlow flow2, IFlow flow3, IFlow flow4, IFunction6 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[5];
				*ptr = new JniArgumentValue((flow == null) ? IntPtr.Zero : ((Java.Lang.Object)flow).Handle);
				ptr[1] = new JniArgumentValue((flow2 == null) ? IntPtr.Zero : ((Java.Lang.Object)flow2).Handle);
				ptr[2] = new JniArgumentValue((flow3 == null) ? IntPtr.Zero : ((Java.Lang.Object)flow3).Handle);
				ptr[3] = new JniArgumentValue((flow4 == null) ? IntPtr.Zero : ((Java.Lang.Object)flow4).Handle);
				ptr[4] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("combineTransform.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function6;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(flow);
				GC.KeepAlive(flow2);
				GC.KeepAlive(flow3);
				GC.KeepAlive(flow4);
				GC.KeepAlive(transform);
			}
		}

		[Register("combineTransform", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function7;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T1", "T2", "T3", "T4", "T5", "R" })]
		public unsafe static IFlow CombineTransform(IFlow flow, IFlow flow2, IFlow flow3, IFlow flow4, IFlow flow5, IFunction7 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue((flow == null) ? IntPtr.Zero : ((Java.Lang.Object)flow).Handle);
				ptr[1] = new JniArgumentValue((flow2 == null) ? IntPtr.Zero : ((Java.Lang.Object)flow2).Handle);
				ptr[2] = new JniArgumentValue((flow3 == null) ? IntPtr.Zero : ((Java.Lang.Object)flow3).Handle);
				ptr[3] = new JniArgumentValue((flow4 == null) ? IntPtr.Zero : ((Java.Lang.Object)flow4).Handle);
				ptr[4] = new JniArgumentValue((flow5 == null) ? IntPtr.Zero : ((Java.Lang.Object)flow5).Handle);
				ptr[5] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("combineTransform.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function7;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(flow);
				GC.KeepAlive(flow2);
				GC.KeepAlive(flow3);
				GC.KeepAlive(flow4);
				GC.KeepAlive(flow5);
				GC.KeepAlive(transform);
			}
		}

		[Obsolete("deprecated")]
		[Register("compose", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function1;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T", "R" })]
		public unsafe static IFlow Compose(IFlow _this_compose, IFunction1 transformer)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_compose == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_compose).Handle);
				ptr[1] = new JniArgumentValue((transformer == null) ? IntPtr.Zero : ((Java.Lang.Object)transformer).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("compose.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function1;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_compose);
				GC.KeepAlive(transformer);
			}
		}

		[Obsolete("deprecated")]
		[Register("concatMap", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function1;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T", "R" })]
		public unsafe static IFlow ConcatMap(IFlow _this_concatMap, IFunction1 mapper)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_concatMap == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_concatMap).Handle);
				ptr[1] = new JniArgumentValue((mapper == null) ? IntPtr.Zero : ((Java.Lang.Object)mapper).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("concatMap.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function1;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_concatMap);
				GC.KeepAlive(mapper);
			}
		}

		[Obsolete("deprecated")]
		[Register("concatWith", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow ConcatWith(IFlow _this_concatWith, IFlow other)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_concatWith == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_concatWith).Handle);
				ptr[1] = new JniArgumentValue((other == null) ? IntPtr.Zero : ((Java.Lang.Object)other).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("concatWith.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_concatWith);
				GC.KeepAlive(other);
			}
		}

		[Obsolete("deprecated")]
		[Register("concatWith", "(Lkotlinx/coroutines/flow/Flow;Ljava/lang/Object;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow ConcatWith(IFlow _this_concatWith, Java.Lang.Object? value)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_concatWith == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_concatWith).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("concatWith.(Lkotlinx/coroutines/flow/Flow;Ljava/lang/Object;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(_this_concatWith);
				GC.KeepAlive(value);
			}
		}

		[Register("conflate", "(Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Conflate(IFlow _this_conflate)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_conflate == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_conflate).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("conflate.(Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_conflate);
			}
		}

		[Register("count", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? Count(IFlow _this_count, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_count == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_count).Handle);
				ptr[1] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("count.(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_count);
				GC.KeepAlive(_completion);
			}
		}

		[Register("count", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? Count(IFlow _this_count, IFunction2 predicate, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_count == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_count).Handle);
				ptr[1] = new JniArgumentValue((predicate == null) ? IntPtr.Zero : ((Java.Lang.Object)predicate).Handle);
				ptr[2] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("count.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_count);
				GC.KeepAlive(predicate);
				GC.KeepAlive(_completion);
			}
		}

		[Register("debounce", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function1;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Debounce(IFlow _this_debounce, IFunction1 timeoutMillis)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_debounce == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_debounce).Handle);
				ptr[1] = new JniArgumentValue((timeoutMillis == null) ? IntPtr.Zero : ((Java.Lang.Object)timeoutMillis).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("debounce.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function1;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_debounce);
				GC.KeepAlive(timeoutMillis);
			}
		}

		[Register("debounce", "(Lkotlinx/coroutines/flow/Flow;J)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Debounce(IFlow _this_debounce, long timeoutMillis)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_debounce == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_debounce).Handle);
				ptr[1] = new JniArgumentValue(timeoutMillis);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("debounce.(Lkotlinx/coroutines/flow/Flow;J)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_debounce);
			}
		}

		[Register("debounceDuration", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function1;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow DebounceDuration(IFlow _this_debounce, IFunction1 timeout)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_debounce == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_debounce).Handle);
				ptr[1] = new JniArgumentValue((timeout == null) ? IntPtr.Zero : ((Java.Lang.Object)timeout).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("debounceDuration.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function1;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_debounce);
				GC.KeepAlive(timeout);
			}
		}

		[Obsolete("deprecated")]
		[Register("delayEach", "(Lkotlinx/coroutines/flow/Flow;J)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow DelayEach(IFlow _this_delayEach, long timeMillis)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_delayEach == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_delayEach).Handle);
				ptr[1] = new JniArgumentValue(timeMillis);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("delayEach.(Lkotlinx/coroutines/flow/Flow;J)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_delayEach);
			}
		}

		[Obsolete("deprecated")]
		[Register("delayFlow", "(Lkotlinx/coroutines/flow/Flow;J)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow DelayFlow(IFlow _this_delayFlow, long timeMillis)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_delayFlow == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_delayFlow).Handle);
				ptr[1] = new JniArgumentValue(timeMillis);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("delayFlow.(Lkotlinx/coroutines/flow/Flow;J)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_delayFlow);
			}
		}

		[Register("distinctUntilChanged", "(Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow DistinctUntilChanged(IFlow _this_distinctUntilChanged)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_distinctUntilChanged == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_distinctUntilChanged).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("distinctUntilChanged.(Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_distinctUntilChanged);
			}
		}

		[Register("distinctUntilChanged", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow DistinctUntilChanged(IFlow _this_distinctUntilChanged, IFunction2 areEquivalent)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_distinctUntilChanged == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_distinctUntilChanged).Handle);
				ptr[1] = new JniArgumentValue((areEquivalent == null) ? IntPtr.Zero : ((Java.Lang.Object)areEquivalent).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("distinctUntilChanged.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_distinctUntilChanged);
				GC.KeepAlive(areEquivalent);
			}
		}

		[Register("distinctUntilChangedBy", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function1;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T", "K" })]
		public unsafe static IFlow DistinctUntilChangedBy(IFlow _this_distinctUntilChangedBy, IFunction1 keySelector)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_distinctUntilChangedBy == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_distinctUntilChangedBy).Handle);
				ptr[1] = new JniArgumentValue((keySelector == null) ? IntPtr.Zero : ((Java.Lang.Object)keySelector).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("distinctUntilChangedBy.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function1;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_distinctUntilChangedBy);
				GC.KeepAlive(keySelector);
			}
		}

		[Register("drop", "(Lkotlinx/coroutines/flow/Flow;I)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Drop(IFlow _this_drop, int count)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_drop == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_drop).Handle);
				ptr[1] = new JniArgumentValue(count);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("drop.(Lkotlinx/coroutines/flow/Flow;I)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_drop);
			}
		}

		[Register("dropWhile", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow DropWhile(IFlow _this_dropWhile, IFunction2 predicate)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_dropWhile == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_dropWhile).Handle);
				ptr[1] = new JniArgumentValue((predicate == null) ? IntPtr.Zero : ((Java.Lang.Object)predicate).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("dropWhile.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_dropWhile);
				GC.KeepAlive(predicate);
			}
		}

		[Register("emitAll", "(Lkotlinx/coroutines/flow/FlowCollector;Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? EmitAll(IFlowCollector _this_emitAll, IFlow flow, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_emitAll == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_emitAll).Handle);
				ptr[1] = new JniArgumentValue((flow == null) ? IntPtr.Zero : ((Java.Lang.Object)flow).Handle);
				ptr[2] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("emitAll.(Lkotlinx/coroutines/flow/FlowCollector;Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_emitAll);
				GC.KeepAlive(flow);
				GC.KeepAlive(_completion);
			}
		}

		[Register("emptyFlow", "()Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow EmptyFlow()
		{
			return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("emptyFlow.()Lkotlinx/coroutines/flow/Flow;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("ensureActive", "(Lkotlinx/coroutines/flow/FlowCollector;)V", "")]
		public unsafe static void EnsureActive(IFlowCollector _this_ensureActive)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_ensureActive == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_ensureActive).Handle);
				_members.StaticMethods.InvokeVoidMethod("ensureActive.(Lkotlinx/coroutines/flow/FlowCollector;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(_this_ensureActive);
			}
		}

		[Register("filter", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Filter(IFlow _this_filter, IFunction2 predicate)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_filter == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_filter).Handle);
				ptr[1] = new JniArgumentValue((predicate == null) ? IntPtr.Zero : ((Java.Lang.Object)predicate).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("filter.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_filter);
				GC.KeepAlive(predicate);
			}
		}

		[Register("filterNot", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow FilterNot(IFlow _this_filterNot, IFunction2 predicate)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_filterNot == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_filterNot).Handle);
				ptr[1] = new JniArgumentValue((predicate == null) ? IntPtr.Zero : ((Java.Lang.Object)predicate).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("filterNot.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_filterNot);
				GC.KeepAlive(predicate);
			}
		}

		[Register("filterNotNull", "(Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow FilterNotNull(IFlow _this_filterNotNull)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_filterNotNull == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_filterNotNull).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("filterNotNull.(Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_filterNotNull);
			}
		}

		[Register("first", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? First(IFlow _this_first, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_first == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_first).Handle);
				ptr[1] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("first.(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_first);
				GC.KeepAlive(_completion);
			}
		}

		[Register("first", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? First(IFlow _this_first, IFunction2 predicate, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_first == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_first).Handle);
				ptr[1] = new JniArgumentValue((predicate == null) ? IntPtr.Zero : ((Java.Lang.Object)predicate).Handle);
				ptr[2] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("first.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_first);
				GC.KeepAlive(predicate);
				GC.KeepAlive(_completion);
			}
		}

		[Register("firstOrNull", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? FirstOrNull(IFlow _this_firstOrNull, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_firstOrNull == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_firstOrNull).Handle);
				ptr[1] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("firstOrNull.(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_firstOrNull);
				GC.KeepAlive(_completion);
			}
		}

		[Register("firstOrNull", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? FirstOrNull(IFlow _this_firstOrNull, IFunction2 predicate, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_firstOrNull == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_firstOrNull).Handle);
				ptr[1] = new JniArgumentValue((predicate == null) ? IntPtr.Zero : ((Java.Lang.Object)predicate).Handle);
				ptr[2] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("firstOrNull.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_firstOrNull);
				GC.KeepAlive(predicate);
				GC.KeepAlive(_completion);
			}
		}

		[Obsolete("deprecated")]
		[Register("flatMap", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T", "R" })]
		public unsafe static IFlow FlatMap(IFlow _this_flatMap, IFunction2 mapper)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_flatMap == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_flatMap).Handle);
				ptr[1] = new JniArgumentValue((mapper == null) ? IntPtr.Zero : ((Java.Lang.Object)mapper).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("flatMap.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_flatMap);
				GC.KeepAlive(mapper);
			}
		}

		[Register("flatMapConcat", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T", "R" })]
		public unsafe static IFlow FlatMapConcat(IFlow _this_flatMapConcat, IFunction2 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_flatMapConcat == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_flatMapConcat).Handle);
				ptr[1] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("flatMapConcat.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_flatMapConcat);
				GC.KeepAlive(transform);
			}
		}

		[Register("flatMapLatest", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T", "R" })]
		public unsafe static IFlow FlatMapLatest(IFlow _this_flatMapLatest, IFunction2 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_flatMapLatest == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_flatMapLatest).Handle);
				ptr[1] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("flatMapLatest.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_flatMapLatest);
				GC.KeepAlive(transform);
			}
		}

		[Register("flatMapMerge", "(Lkotlinx/coroutines/flow/Flow;ILkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T", "R" })]
		public unsafe static IFlow FlatMapMerge(IFlow _this_flatMapMerge, int concurrency, IFunction2 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_flatMapMerge == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_flatMapMerge).Handle);
				ptr[1] = new JniArgumentValue(concurrency);
				ptr[2] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("flatMapMerge.(Lkotlinx/coroutines/flow/Flow;ILkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_flatMapMerge);
				GC.KeepAlive(transform);
			}
		}

		[Obsolete("deprecated")]
		[Register("flatten", "(Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Flatten(IFlow _this_flatten)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_flatten == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_flatten).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("flatten.(Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_flatten);
			}
		}

		[Register("flattenConcat", "(Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow FlattenConcat(IFlow _this_flattenConcat)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_flattenConcat == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_flattenConcat).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("flattenConcat.(Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_flattenConcat);
			}
		}

		[Register("flattenMerge", "(Lkotlinx/coroutines/flow/Flow;I)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow FlattenMerge(IFlow _this_flattenMerge, int concurrency)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_flattenMerge == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_flattenMerge).Handle);
				ptr[1] = new JniArgumentValue(concurrency);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("flattenMerge.(Lkotlinx/coroutines/flow/Flow;I)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_flattenMerge);
			}
		}

		[Register("flow", "(Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Flow(IFunction2 block)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("flow.(Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(block);
			}
		}

		[Register("flowCombine", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T1", "T2", "R" })]
		public unsafe static IFlow FlowCombine(IFlow _this_combine, IFlow flow, IFunction3 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_combine == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_combine).Handle);
				ptr[1] = new JniArgumentValue((flow == null) ? IntPtr.Zero : ((Java.Lang.Object)flow).Handle);
				ptr[2] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("flowCombine.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_combine);
				GC.KeepAlive(flow);
				GC.KeepAlive(transform);
			}
		}

		[Register("flowCombineTransform", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function4;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T1", "T2", "R" })]
		public unsafe static IFlow FlowCombineTransform(IFlow _this_combineTransform, IFlow flow, IFunction4 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_combineTransform == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_combineTransform).Handle);
				ptr[1] = new JniArgumentValue((flow == null) ? IntPtr.Zero : ((Java.Lang.Object)flow).Handle);
				ptr[2] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("flowCombineTransform.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function4;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_combineTransform);
				GC.KeepAlive(flow);
				GC.KeepAlive(transform);
			}
		}

		[Register("flowOf", "(Ljava/lang/Object;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow FlowOf(Java.Lang.Object? value)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("flowOf.(Ljava/lang/Object;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
			}
		}

		[Register("flowOf", "([Ljava/lang/Object;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow FlowOf(params Java.Lang.Object[] elements)
		{
			IntPtr intPtr = JNIEnv.NewArray(elements);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("flowOf.([Ljava/lang/Object;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (elements != null)
				{
					JNIEnv.CopyArray(intPtr, elements);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(elements);
			}
		}

		[Register("flowOn", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow FlowOn(IFlow _this_flowOn, ICoroutineContext context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_flowOn == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_flowOn).Handle);
				ptr[1] = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("flowOn.(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_flowOn);
				GC.KeepAlive(context);
			}
		}

		[Register("fold", "(Lkotlinx/coroutines/flow/Flow;Ljava/lang/Object;Lkotlin/jvm/functions/Function3;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T", "R" })]
		public unsafe static Java.Lang.Object? Fold(IFlow _this_fold, Java.Lang.Object? initial, IFunction3 operation, IContinuation _completion)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(initial);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue((_this_fold == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_fold).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((operation == null) ? IntPtr.Zero : ((Java.Lang.Object)operation).Handle);
				ptr[3] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("fold.(Lkotlinx/coroutines/flow/Flow;Ljava/lang/Object;Lkotlin/jvm/functions/Function3;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(_this_fold);
				GC.KeepAlive(initial);
				GC.KeepAlive(operation);
				GC.KeepAlive(_completion);
			}
		}

		[Obsolete("deprecated")]
		[Register("forEach", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)V", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static void ForEach(IFlow _this_forEach, IFunction2 action)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_forEach == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_forEach).Handle);
				ptr[1] = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
				_members.StaticMethods.InvokeVoidMethod("forEach.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(_this_forEach);
				GC.KeepAlive(action);
			}
		}

		[Register("last", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? Last(IFlow _this_last, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_last == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_last).Handle);
				ptr[1] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("last.(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_last);
				GC.KeepAlive(_completion);
			}
		}

		[Register("lastOrNull", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? LastOrNull(IFlow _this_lastOrNull, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_lastOrNull == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_lastOrNull).Handle);
				ptr[1] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("lastOrNull.(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_lastOrNull);
				GC.KeepAlive(_completion);
			}
		}

		[Register("map", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T", "R" })]
		public unsafe static IFlow Map(IFlow _this_map, IFunction2 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_map == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_map).Handle);
				ptr[1] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("map.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_map);
				GC.KeepAlive(transform);
			}
		}

		[Register("mapLatest", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T", "R" })]
		public unsafe static IFlow MapLatest(IFlow _this_mapLatest, IFunction2 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_mapLatest == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_mapLatest).Handle);
				ptr[1] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("mapLatest.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_mapLatest);
				GC.KeepAlive(transform);
			}
		}

		[Register("mapNotNull", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T", "R" })]
		public unsafe static IFlow MapNotNull(IFlow _this_mapNotNull, IFunction2 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_mapNotNull == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_mapNotNull).Handle);
				ptr[1] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("mapNotNull.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_mapNotNull);
				GC.KeepAlive(transform);
			}
		}

		[Register("merge", "(Ljava/lang/Iterable;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Merge(IIterable _this_merge)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_merge == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_merge).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("merge.(Ljava/lang/Iterable;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_merge);
			}
		}

		[Obsolete("deprecated")]
		[Register("merge", "(Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Merge(IFlow _this_merge)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_merge == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_merge).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("merge.(Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_merge);
			}
		}

		[Register("merge", "([Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Merge(params IFlow[] flows)
		{
			IntPtr intPtr = JNIEnv.NewArray(flows);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("merge.([Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (flows != null)
				{
					JNIEnv.CopyArray(intPtr, flows);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(flows);
			}
		}

		[Register("noImpl", "()Ljava/lang/Void;", "")]
		public unsafe static Java.Lang.Void NoImpl()
		{
			return Java.Lang.Object.GetObject<Java.Lang.Void>(_members.StaticMethods.InvokeObjectMethod("noImpl.()Ljava/lang/Void;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Obsolete("deprecated")]
		[Register("observeOn", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow ObserveOn(IFlow _this_observeOn, ICoroutineContext context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_observeOn == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_observeOn).Handle);
				ptr[1] = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("observeOn.(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_observeOn);
				GC.KeepAlive(context);
			}
		}

		[Register("onCompletion", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow OnCompletion(IFlow _this_onCompletion, IFunction3 action)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_onCompletion == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_onCompletion).Handle);
				ptr[1] = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("onCompletion.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_onCompletion);
				GC.KeepAlive(action);
			}
		}

		[Register("onEach", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow OnEach(IFlow _this_onEach, IFunction2 action)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_onEach == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_onEach).Handle);
				ptr[1] = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("onEach.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_onEach);
				GC.KeepAlive(action);
			}
		}

		[Register("onEmpty", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow OnEmpty(IFlow _this_onEmpty, IFunction2 action)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_onEmpty == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_onEmpty).Handle);
				ptr[1] = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("onEmpty.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_onEmpty);
				GC.KeepAlive(action);
			}
		}

		[Obsolete("deprecated")]
		[Register("onErrorResume", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow OnErrorResume(IFlow _this_onErrorResume, IFlow fallback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_onErrorResume == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_onErrorResume).Handle);
				ptr[1] = new JniArgumentValue((fallback == null) ? IntPtr.Zero : ((Java.Lang.Object)fallback).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("onErrorResume.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_onErrorResume);
				GC.KeepAlive(fallback);
			}
		}

		[Obsolete("deprecated")]
		[Register("onErrorResumeNext", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow OnErrorResumeNext(IFlow _this_onErrorResumeNext, IFlow fallback)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_onErrorResumeNext == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_onErrorResumeNext).Handle);
				ptr[1] = new JniArgumentValue((fallback == null) ? IntPtr.Zero : ((Java.Lang.Object)fallback).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("onErrorResumeNext.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_onErrorResumeNext);
				GC.KeepAlive(fallback);
			}
		}

		[Obsolete("deprecated")]
		[Register("onErrorReturn", "(Lkotlinx/coroutines/flow/Flow;Ljava/lang/Object;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow OnErrorReturn(IFlow _this_onErrorReturn, Java.Lang.Object? fallback)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(fallback);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_onErrorReturn == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_onErrorReturn).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("onErrorReturn.(Lkotlinx/coroutines/flow/Flow;Ljava/lang/Object;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(_this_onErrorReturn);
				GC.KeepAlive(fallback);
			}
		}

		[Obsolete("deprecated")]
		[Register("onErrorReturn", "(Lkotlinx/coroutines/flow/Flow;Ljava/lang/Object;Lkotlin/jvm/functions/Function1;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow OnErrorReturn(IFlow _this_onErrorReturn, Java.Lang.Object? fallback, IFunction1 predicate)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(fallback);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_onErrorReturn == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_onErrorReturn).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((predicate == null) ? IntPtr.Zero : ((Java.Lang.Object)predicate).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("onErrorReturn.(Lkotlinx/coroutines/flow/Flow;Ljava/lang/Object;Lkotlin/jvm/functions/Function1;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(_this_onErrorReturn);
				GC.KeepAlive(fallback);
				GC.KeepAlive(predicate);
			}
		}

		[Register("onStart", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow OnStart(IFlow _this_onStart, IFunction2 action)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_onStart == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_onStart).Handle);
				ptr[1] = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("onStart.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_onStart);
				GC.KeepAlive(action);
			}
		}

		[Register("onSubscription", "(Lkotlinx/coroutines/flow/SharedFlow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/SharedFlow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static ISharedFlow OnSubscription(ISharedFlow _this_onSubscription, IFunction2 action)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_onSubscription == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_onSubscription).Handle);
				ptr[1] = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
				return Java.Lang.Object.GetObject<ISharedFlow>(_members.StaticMethods.InvokeObjectMethod("onSubscription.(Lkotlinx/coroutines/flow/SharedFlow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/SharedFlow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_onSubscription);
				GC.KeepAlive(action);
			}
		}

		[Obsolete("deprecated")]
		[Register("publish", "(Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Publish(IFlow _this_publish)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_publish == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_publish).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("publish.(Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_publish);
			}
		}

		[Obsolete("deprecated")]
		[Register("publish", "(Lkotlinx/coroutines/flow/Flow;I)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Publish(IFlow _this_publish, int bufferSize)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_publish == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_publish).Handle);
				ptr[1] = new JniArgumentValue(bufferSize);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("publish.(Lkotlinx/coroutines/flow/Flow;I)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_publish);
			}
		}

		[Obsolete("deprecated")]
		[Register("publishOn", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow PublishOn(IFlow _this_publishOn, ICoroutineContext context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_publishOn == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_publishOn).Handle);
				ptr[1] = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("publishOn.(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_publishOn);
				GC.KeepAlive(context);
			}
		}

		[Register("reduce", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "S", "T extends S" })]
		public unsafe static Java.Lang.Object? Reduce(IFlow _this_reduce, IFunction3 operation, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_reduce == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_reduce).Handle);
				ptr[1] = new JniArgumentValue((operation == null) ? IntPtr.Zero : ((Java.Lang.Object)operation).Handle);
				ptr[2] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("reduce.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_reduce);
				GC.KeepAlive(operation);
				GC.KeepAlive(_completion);
			}
		}

		[Obsolete("deprecated")]
		[Register("replay", "(Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Replay(IFlow _this_replay)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_replay == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_replay).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("replay.(Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_replay);
			}
		}

		[Obsolete("deprecated")]
		[Register("replay", "(Lkotlinx/coroutines/flow/Flow;I)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Replay(IFlow _this_replay, int bufferSize)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_replay == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_replay).Handle);
				ptr[1] = new JniArgumentValue(bufferSize);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("replay.(Lkotlinx/coroutines/flow/Flow;I)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_replay);
			}
		}

		[Register("retry", "(Lkotlinx/coroutines/flow/Flow;JLkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Retry(IFlow _this_retry, long retries, IFunction2 predicate)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_retry == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_retry).Handle);
				ptr[1] = new JniArgumentValue(retries);
				ptr[2] = new JniArgumentValue((predicate == null) ? IntPtr.Zero : ((Java.Lang.Object)predicate).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("retry.(Lkotlinx/coroutines/flow/Flow;JLkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_retry);
				GC.KeepAlive(predicate);
			}
		}

		[Register("retryWhen", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function4;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow RetryWhen(IFlow _this_retryWhen, IFunction4 predicate)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_retryWhen == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_retryWhen).Handle);
				ptr[1] = new JniArgumentValue((predicate == null) ? IntPtr.Zero : ((Java.Lang.Object)predicate).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("retryWhen.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function4;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_retryWhen);
				GC.KeepAlive(predicate);
			}
		}

		[Register("runningFold", "(Lkotlinx/coroutines/flow/Flow;Ljava/lang/Object;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T", "R" })]
		public unsafe static IFlow RunningFold(IFlow _this_runningFold, Java.Lang.Object? initial, IFunction3 operation)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(initial);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_runningFold == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_runningFold).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((operation == null) ? IntPtr.Zero : ((Java.Lang.Object)operation).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("runningFold.(Lkotlinx/coroutines/flow/Flow;Ljava/lang/Object;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(_this_runningFold);
				GC.KeepAlive(initial);
				GC.KeepAlive(operation);
			}
		}

		[Register("runningReduce", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow RunningReduce(IFlow _this_runningReduce, IFunction3 operation)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_runningReduce == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_runningReduce).Handle);
				ptr[1] = new JniArgumentValue((operation == null) ? IntPtr.Zero : ((Java.Lang.Object)operation).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("runningReduce.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_runningReduce);
				GC.KeepAlive(operation);
			}
		}

		[Register("sample", "(Lkotlinx/coroutines/flow/Flow;J)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Sample(IFlow _this_sample, long periodMillis)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_sample == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_sample).Handle);
				ptr[1] = new JniArgumentValue(periodMillis);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("sample.(Lkotlinx/coroutines/flow/Flow;J)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_sample);
			}
		}

		[Register("scan", "(Lkotlinx/coroutines/flow/Flow;Ljava/lang/Object;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T", "R" })]
		public unsafe static IFlow Scan(IFlow _this_scan, Java.Lang.Object? initial, IFunction3 operation)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(initial);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_scan == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_scan).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((operation == null) ? IntPtr.Zero : ((Java.Lang.Object)operation).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("scan.(Lkotlinx/coroutines/flow/Flow;Ljava/lang/Object;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(_this_scan);
				GC.KeepAlive(initial);
				GC.KeepAlive(operation);
			}
		}

		[Obsolete("deprecated")]
		[Register("scanFold", "(Lkotlinx/coroutines/flow/Flow;Ljava/lang/Object;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T", "R" })]
		public unsafe static IFlow ScanFold(IFlow _this_scanFold, Java.Lang.Object? initial, IFunction3 operation)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(initial);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_scanFold == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_scanFold).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((operation == null) ? IntPtr.Zero : ((Java.Lang.Object)operation).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("scanFold.(Lkotlinx/coroutines/flow/Flow;Ljava/lang/Object;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(_this_scanFold);
				GC.KeepAlive(initial);
				GC.KeepAlive(operation);
			}
		}

		[Obsolete("deprecated")]
		[Register("scanReduce", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow ScanReduce(IFlow _this_scanReduce, IFunction3 operation)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_scanReduce == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_scanReduce).Handle);
				ptr[1] = new JniArgumentValue((operation == null) ? IntPtr.Zero : ((Java.Lang.Object)operation).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("scanReduce.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_scanReduce);
				GC.KeepAlive(operation);
			}
		}

		[Register("shareIn", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/CoroutineScope;Lkotlinx/coroutines/flow/SharingStarted;I)Lkotlinx/coroutines/flow/SharedFlow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static ISharedFlow ShareIn(IFlow _this_shareIn, ICoroutineScope scope, ISharingStarted started, int replay)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue((_this_shareIn == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_shareIn).Handle);
				ptr[1] = new JniArgumentValue((scope == null) ? IntPtr.Zero : ((Java.Lang.Object)scope).Handle);
				ptr[2] = new JniArgumentValue((started == null) ? IntPtr.Zero : ((Java.Lang.Object)started).Handle);
				ptr[3] = new JniArgumentValue(replay);
				return Java.Lang.Object.GetObject<ISharedFlow>(_members.StaticMethods.InvokeObjectMethod("shareIn.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/CoroutineScope;Lkotlinx/coroutines/flow/SharingStarted;I)Lkotlinx/coroutines/flow/SharedFlow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_shareIn);
				GC.KeepAlive(scope);
				GC.KeepAlive(started);
			}
		}

		[Register("single", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? Single(IFlow _this_single, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_single == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_single).Handle);
				ptr[1] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("single.(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_single);
				GC.KeepAlive(_completion);
			}
		}

		[Register("singleOrNull", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? SingleOrNull(IFlow _this_singleOrNull, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_singleOrNull == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_singleOrNull).Handle);
				ptr[1] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("singleOrNull.(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_singleOrNull);
				GC.KeepAlive(_completion);
			}
		}

		[Obsolete("deprecated")]
		[Register("skip", "(Lkotlinx/coroutines/flow/Flow;I)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Skip(IFlow _this_skip, int count)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_skip == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_skip).Handle);
				ptr[1] = new JniArgumentValue(count);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("skip.(Lkotlinx/coroutines/flow/Flow;I)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_skip);
			}
		}

		[Obsolete("deprecated")]
		[Register("startWith", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow StartWith(IFlow _this_startWith, IFlow other)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_startWith == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_startWith).Handle);
				ptr[1] = new JniArgumentValue((other == null) ? IntPtr.Zero : ((Java.Lang.Object)other).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("startWith.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_startWith);
				GC.KeepAlive(other);
			}
		}

		[Obsolete("deprecated")]
		[Register("startWith", "(Lkotlinx/coroutines/flow/Flow;Ljava/lang/Object;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow StartWith(IFlow _this_startWith, Java.Lang.Object? value)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_startWith == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_startWith).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("startWith.(Lkotlinx/coroutines/flow/Flow;Ljava/lang/Object;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(_this_startWith);
				GC.KeepAlive(value);
			}
		}

		[Register("stateIn", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? StateIn(IFlow _this_stateIn, ICoroutineScope scope, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_stateIn == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_stateIn).Handle);
				ptr[1] = new JniArgumentValue((scope == null) ? IntPtr.Zero : ((Java.Lang.Object)scope).Handle);
				ptr[2] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("stateIn.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/CoroutineScope;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_stateIn);
				GC.KeepAlive(scope);
				GC.KeepAlive(_completion);
			}
		}

		[Register("stateIn", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/CoroutineScope;Lkotlinx/coroutines/flow/SharingStarted;Ljava/lang/Object;)Lkotlinx/coroutines/flow/StateFlow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IStateFlow StateIn(IFlow _this_stateIn, ICoroutineScope scope, ISharingStarted started, Java.Lang.Object? initialValue)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(initialValue);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[4];
				*ptr = new JniArgumentValue((_this_stateIn == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_stateIn).Handle);
				ptr[1] = new JniArgumentValue((scope == null) ? IntPtr.Zero : ((Java.Lang.Object)scope).Handle);
				ptr[2] = new JniArgumentValue((started == null) ? IntPtr.Zero : ((Java.Lang.Object)started).Handle);
				ptr[3] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<IStateFlow>(_members.StaticMethods.InvokeObjectMethod("stateIn.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/CoroutineScope;Lkotlinx/coroutines/flow/SharingStarted;Ljava/lang/Object;)Lkotlinx/coroutines/flow/StateFlow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(_this_stateIn);
				GC.KeepAlive(scope);
				GC.KeepAlive(started);
				GC.KeepAlive(initialValue);
			}
		}

		[Obsolete("deprecated")]
		[Register("subscribe", "(Lkotlinx/coroutines/flow/Flow;)V", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static void Subscribe(IFlow _this_subscribe)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_subscribe == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_subscribe).Handle);
				_members.StaticMethods.InvokeVoidMethod("subscribe.(Lkotlinx/coroutines/flow/Flow;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(_this_subscribe);
			}
		}

		[Obsolete("deprecated")]
		[Register("subscribe", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)V", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static void Subscribe(IFlow _this_subscribe, IFunction2 onEach)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_subscribe == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_subscribe).Handle);
				ptr[1] = new JniArgumentValue((onEach == null) ? IntPtr.Zero : ((Java.Lang.Object)onEach).Handle);
				_members.StaticMethods.InvokeVoidMethod("subscribe.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(_this_subscribe);
				GC.KeepAlive(onEach);
			}
		}

		[Obsolete("deprecated")]
		[Register("subscribe", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;Lkotlin/jvm/functions/Function2;)V", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static void Subscribe(IFlow _this_subscribe, IFunction2 onEach, IFunction2 onError)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_subscribe == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_subscribe).Handle);
				ptr[1] = new JniArgumentValue((onEach == null) ? IntPtr.Zero : ((Java.Lang.Object)onEach).Handle);
				ptr[2] = new JniArgumentValue((onError == null) ? IntPtr.Zero : ((Java.Lang.Object)onError).Handle);
				_members.StaticMethods.InvokeVoidMethod("subscribe.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;Lkotlin/jvm/functions/Function2;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(_this_subscribe);
				GC.KeepAlive(onEach);
				GC.KeepAlive(onError);
			}
		}

		[Obsolete("deprecated")]
		[Register("subscribeOn", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow SubscribeOn(IFlow _this_subscribeOn, ICoroutineContext context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_subscribeOn == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_subscribeOn).Handle);
				ptr[1] = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("subscribeOn.(Lkotlinx/coroutines/flow/Flow;Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_subscribeOn);
				GC.KeepAlive(context);
			}
		}

		[Obsolete("deprecated")]
		[Register("switchMap", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T", "R" })]
		public unsafe static IFlow SwitchMap(IFlow _this_switchMap, IFunction2 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_switchMap == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_switchMap).Handle);
				ptr[1] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("switchMap.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_switchMap);
				GC.KeepAlive(transform);
			}
		}

		[Register("take", "(Lkotlinx/coroutines/flow/Flow;I)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Take(IFlow _this_take, int count)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_take == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_take).Handle);
				ptr[1] = new JniArgumentValue(count);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("take.(Lkotlinx/coroutines/flow/Flow;I)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_take);
			}
		}

		[Register("takeWhile", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow TakeWhile(IFlow _this_takeWhile, IFunction2 predicate)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_takeWhile == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_takeWhile).Handle);
				ptr[1] = new JniArgumentValue((predicate == null) ? IntPtr.Zero : ((Java.Lang.Object)predicate).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("takeWhile.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function2;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_takeWhile);
				GC.KeepAlive(predicate);
			}
		}

		[Register("toCollection", "(Lkotlinx/coroutines/flow/Flow;Ljava/util/Collection;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T", "C extends java.util.Collection<? super T>" })]
		public unsafe static Java.Lang.Object? ToCollection(IFlow _this_toCollection, Java.Lang.Object destination, IContinuation _completion)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(destination);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_toCollection == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_toCollection).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("toCollection.(Lkotlinx/coroutines/flow/Flow;Ljava/util/Collection;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(_this_toCollection);
				GC.KeepAlive(destination);
				GC.KeepAlive(_completion);
			}
		}

		[Register("toList", "(Lkotlinx/coroutines/flow/Flow;Ljava/util/List;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? ToList(IFlow _this_toList, System.Collections.IList destination, IContinuation _completion)
		{
			IntPtr intPtr = JavaList.ToLocalJniHandle(destination);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_toList == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_toList).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("toList.(Lkotlinx/coroutines/flow/Flow;Ljava/util/List;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(_this_toList);
				GC.KeepAlive(destination);
				GC.KeepAlive(_completion);
			}
		}

		[Register("toSet", "(Lkotlinx/coroutines/flow/Flow;Ljava/util/Set;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? ToSet(IFlow _this_toSet, System.Collections.ICollection destination, IContinuation _completion)
		{
			IntPtr intPtr = JavaSet.ToLocalJniHandle(destination);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_toSet == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_toSet).Handle);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("toSet.(Lkotlinx/coroutines/flow/Flow;Ljava/util/Set;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(_this_toSet);
				GC.KeepAlive(destination);
				GC.KeepAlive(_completion);
			}
		}

		[Register("transform", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T", "R" })]
		public unsafe static IFlow Transform(IFlow _this_transform, IFunction3 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_transform == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_transform).Handle);
				ptr[1] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("transform.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_transform);
				GC.KeepAlive(transform);
			}
		}

		[Register("transformLatest", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T", "R" })]
		public unsafe static IFlow TransformLatest(IFlow _this_transformLatest, IFunction3 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_transformLatest == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_transformLatest).Handle);
				ptr[1] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("transformLatest.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_transformLatest);
				GC.KeepAlive(transform);
			}
		}

		[Register("transformWhile", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T", "R" })]
		public unsafe static IFlow TransformWhile(IFlow _this_transformWhile, IFunction3 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_transformWhile == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_transformWhile).Handle);
				ptr[1] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("transformWhile.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_transformWhile);
				GC.KeepAlive(transform);
			}
		}

		[Register("unsafeTransform", "(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T", "R" })]
		public unsafe static IFlow UnsafeTransform(IFlow _this_unsafeTransform, IFunction3 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((_this_unsafeTransform == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_unsafeTransform).Handle);
				ptr[1] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("unsafeTransform.(Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_unsafeTransform);
				GC.KeepAlive(transform);
			}
		}

		[Register("withIndex", "(Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow WithIndex(IFlow _this_withIndex)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_this_withIndex == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_withIndex).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("withIndex.(Lkotlinx/coroutines/flow/Flow;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_withIndex);
			}
		}

		[Register("zip", "(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T1", "T2", "R" })]
		public unsafe static IFlow Zip(IFlow _this_zip, IFlow other, IFunction3 transform)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue((_this_zip == null) ? IntPtr.Zero : ((Java.Lang.Object)_this_zip).Handle);
				ptr[1] = new JniArgumentValue((other == null) ? IntPtr.Zero : ((Java.Lang.Object)other).Handle);
				ptr[2] = new JniArgumentValue((transform == null) ? IntPtr.Zero : ((Java.Lang.Object)transform).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("zip.(Lkotlinx/coroutines/flow/Flow;Lkotlinx/coroutines/flow/Flow;Lkotlin/jvm/functions/Function3;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_this_zip);
				GC.KeepAlive(other);
				GC.KeepAlive(transform);
			}
		}
	}
	[Register("kotlinx/coroutines/flow/Flow", "", "Xamarin.KotlinX.Coroutines.Flow.IFlowInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface IFlow : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("collect", "(Lkotlinx/coroutines/flow/FlowCollector;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "GetCollect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_Handler:Xamarin.KotlinX.Coroutines.Flow.IFlowInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		Java.Lang.Object? Collect(IFlowCollector collector, IContinuation p1);
	}
	[Register("kotlinx/coroutines/flow/Flow", DoNotGenerateAcw = true)]
	internal class IFlowInvoker : Java.Lang.Object, IFlow, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/flow/Flow", typeof(IFlowInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_;

		private IntPtr id_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_;

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

		public static IFlow? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IFlow>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'kotlinx.coroutines.flow.Flow'.");
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

		public IFlowInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetCollect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_Handler()
		{
			if ((object)cb_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_ == null)
			{
				cb_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_));
			}
			return cb_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_;
		}

		private static IntPtr n_Collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_(IntPtr jnienv, IntPtr native__this, IntPtr native_collector, IntPtr native_p1)
		{
			IFlow flow = Java.Lang.Object.GetObject<IFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IFlowCollector collector = Java.Lang.Object.GetObject<IFlowCollector>(native_collector, JniHandleOwnership.DoNotTransfer);
			IContinuation p = Java.Lang.Object.GetObject<IContinuation>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(flow.Collect(collector, p));
		}

		public unsafe Java.Lang.Object? Collect(IFlowCollector collector, IContinuation p1)
		{
			if (id_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_ == IntPtr.Zero)
			{
				id_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_ = JNIEnv.GetMethodID(class_ref, "collect", "(Lkotlinx/coroutines/flow/FlowCollector;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue((collector == null) ? IntPtr.Zero : ((Java.Lang.Object)collector).Handle);
			ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("kotlinx/coroutines/flow/FlowCollector", "", "Xamarin.KotlinX.Coroutines.Flow.IFlowCollectorInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface IFlowCollector : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("emit", "(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "GetEmit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_Handler:Xamarin.KotlinX.Coroutines.Flow.IFlowCollectorInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		Java.Lang.Object? Emit(Java.Lang.Object? value, IContinuation p1);
	}
	[Register("kotlinx/coroutines/flow/FlowCollector", DoNotGenerateAcw = true)]
	internal class IFlowCollectorInvoker : Java.Lang.Object, IFlowCollector, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/flow/FlowCollector", typeof(IFlowCollectorInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_;

		private IntPtr id_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_;

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

		public static IFlowCollector? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IFlowCollector>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'kotlinx.coroutines.flow.FlowCollector'.");
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

		public IFlowCollectorInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetEmit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_Handler()
		{
			if ((object)cb_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_ == null)
			{
				cb_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_));
			}
			return cb_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_;
		}

		private static IntPtr n_Emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_(IntPtr jnienv, IntPtr native__this, IntPtr native_value, IntPtr native_p1)
		{
			IFlowCollector flowCollector = Java.Lang.Object.GetObject<IFlowCollector>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			IContinuation p = Java.Lang.Object.GetObject<IContinuation>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(flowCollector.Emit(value, p));
		}

		public unsafe Java.Lang.Object? Emit(Java.Lang.Object? value, IContinuation p1)
		{
			if (id_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_ == IntPtr.Zero)
			{
				id_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_ = JNIEnv.GetMethodID(class_ref, "emit", "(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}
	}
	[Register("kotlinx/coroutines/flow/MutableSharedFlow", "", "Xamarin.KotlinX.Coroutines.Flow.IMutableSharedFlowInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface IMutableSharedFlow : IFlowCollector, IJavaObject, IDisposable, IJavaPeerable, ISharedFlow, IFlow
	{
		IStateFlow SubscriptionCount
		{
			[Register("getSubscriptionCount", "()Lkotlinx/coroutines/flow/StateFlow;", "GetGetSubscriptionCountHandler:Xamarin.KotlinX.Coroutines.Flow.IMutableSharedFlowInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
			get;
		}

		[Register("emit", "(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "GetEmit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_Handler:Xamarin.KotlinX.Coroutines.Flow.IMutableSharedFlowInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		new Java.Lang.Object? Emit(Java.Lang.Object? value, IContinuation p1);

		[Register("resetReplayCache", "()V", "GetResetReplayCacheHandler:Xamarin.KotlinX.Coroutines.Flow.IMutableSharedFlowInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		void ResetReplayCache();

		[Register("tryEmit", "(Ljava/lang/Object;)Z", "GetTryEmit_Ljava_lang_Object_Handler:Xamarin.KotlinX.Coroutines.Flow.IMutableSharedFlowInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		bool TryEmit(Java.Lang.Object? value);
	}
	[Register("kotlinx/coroutines/flow/MutableSharedFlow", DoNotGenerateAcw = true)]
	internal class IMutableSharedFlowInvoker : Java.Lang.Object, IMutableSharedFlow, IFlowCollector, IJavaObject, IDisposable, IJavaPeerable, ISharedFlow, IFlow
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/flow/MutableSharedFlow", typeof(IMutableSharedFlowInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_getSubscriptionCount;

		private IntPtr id_getSubscriptionCount;

		private static Delegate? cb_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_;

		private IntPtr id_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_;

		private static Delegate? cb_resetReplayCache;

		private IntPtr id_resetReplayCache;

		private static Delegate? cb_tryEmit_Ljava_lang_Object_;

		private IntPtr id_tryEmit_Ljava_lang_Object_;

		private static Delegate? cb_getReplayCache;

		private IntPtr id_getReplayCache;

		private static Delegate? cb_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_;

		private IntPtr id_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_;

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

		public IStateFlow SubscriptionCount
		{
			get
			{
				if (id_getSubscriptionCount == IntPtr.Zero)
				{
					id_getSubscriptionCount = JNIEnv.GetMethodID(class_ref, "getSubscriptionCount", "()Lkotlinx/coroutines/flow/StateFlow;");
				}
				return Java.Lang.Object.GetObject<IStateFlow>(JNIEnv.CallObjectMethod(base.Handle, id_getSubscriptionCount), JniHandleOwnership.TransferLocalRef);
			}
		}

		public System.Collections.IList ReplayCache
		{
			get
			{
				if (id_getReplayCache == IntPtr.Zero)
				{
					id_getReplayCache = JNIEnv.GetMethodID(class_ref, "getReplayCache", "()Ljava/util/List;");
				}
				return JavaList.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getReplayCache), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static IMutableSharedFlow? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IMutableSharedFlow>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'kotlinx.coroutines.flow.MutableSharedFlow'.");
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

		public IMutableSharedFlowInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetSubscriptionCountHandler()
		{
			if ((object)cb_getSubscriptionCount == null)
			{
				cb_getSubscriptionCount = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSubscriptionCount));
			}
			return cb_getSubscriptionCount;
		}

		private static IntPtr n_GetSubscriptionCount(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMutableSharedFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SubscriptionCount);
		}

		private static Delegate GetEmit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_Handler()
		{
			if ((object)cb_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_ == null)
			{
				cb_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_));
			}
			return cb_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_;
		}

		private static IntPtr n_Emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_(IntPtr jnienv, IntPtr native__this, IntPtr native_value, IntPtr native_p1)
		{
			IMutableSharedFlow mutableSharedFlow = Java.Lang.Object.GetObject<IMutableSharedFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			IContinuation p = Java.Lang.Object.GetObject<IContinuation>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(mutableSharedFlow.Emit(value, p));
		}

		public unsafe Java.Lang.Object? Emit(Java.Lang.Object? value, IContinuation p1)
		{
			if (id_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_ == IntPtr.Zero)
			{
				id_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_ = JNIEnv.GetMethodID(class_ref, "emit", "(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetResetReplayCacheHandler()
		{
			if ((object)cb_resetReplayCache == null)
			{
				cb_resetReplayCache = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ResetReplayCache));
			}
			return cb_resetReplayCache;
		}

		private static void n_ResetReplayCache(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<IMutableSharedFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResetReplayCache();
		}

		public void ResetReplayCache()
		{
			if (id_resetReplayCache == IntPtr.Zero)
			{
				id_resetReplayCache = JNIEnv.GetMethodID(class_ref, "resetReplayCache", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_resetReplayCache);
		}

		private static Delegate GetTryEmit_Ljava_lang_Object_Handler()
		{
			if ((object)cb_tryEmit_Ljava_lang_Object_ == null)
			{
				cb_tryEmit_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_TryEmit_Ljava_lang_Object_));
			}
			return cb_tryEmit_Ljava_lang_Object_;
		}

		private static bool n_TryEmit_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_value)
		{
			IMutableSharedFlow mutableSharedFlow = Java.Lang.Object.GetObject<IMutableSharedFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			return mutableSharedFlow.TryEmit(value);
		}

		public unsafe bool TryEmit(Java.Lang.Object? value)
		{
			if (id_tryEmit_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_tryEmit_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "tryEmit", "(Ljava/lang/Object;)Z");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			bool result = JNIEnv.CallBooleanMethod(base.Handle, id_tryEmit_Ljava_lang_Object_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetGetReplayCacheHandler()
		{
			if ((object)cb_getReplayCache == null)
			{
				cb_getReplayCache = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetReplayCache));
			}
			return cb_getReplayCache;
		}

		private static IntPtr n_GetReplayCache(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList.ToLocalJniHandle(Java.Lang.Object.GetObject<IMutableSharedFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReplayCache);
		}

		private static Delegate GetCollect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_Handler()
		{
			if ((object)cb_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_ == null)
			{
				cb_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_));
			}
			return cb_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_;
		}

		private static IntPtr n_Collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_(IntPtr jnienv, IntPtr native__this, IntPtr native_collector, IntPtr native_p1)
		{
			IMutableSharedFlow mutableSharedFlow = Java.Lang.Object.GetObject<IMutableSharedFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IFlowCollector collector = Java.Lang.Object.GetObject<IFlowCollector>(native_collector, JniHandleOwnership.DoNotTransfer);
			IContinuation p = Java.Lang.Object.GetObject<IContinuation>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(mutableSharedFlow.Collect(collector, p));
		}

		public unsafe Java.Lang.Object? Collect(IFlowCollector collector, IContinuation p1)
		{
			if (id_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_ == IntPtr.Zero)
			{
				id_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_ = JNIEnv.GetMethodID(class_ref, "collect", "(Lkotlinx/coroutines/flow/FlowCollector;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue((collector == null) ? IntPtr.Zero : ((Java.Lang.Object)collector).Handle);
			ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("kotlinx/coroutines/flow/MutableStateFlow", "", "Xamarin.KotlinX.Coroutines.Flow.IMutableStateFlowInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface IMutableStateFlow : IMutableSharedFlow, IFlowCollector, IJavaObject, IDisposable, IJavaPeerable, ISharedFlow, IFlow, IStateFlow
	{
		new Java.Lang.Object? Value
		{
			[Register("getValue", "()Ljava/lang/Object;", "GetGetValueHandler:Xamarin.KotlinX.Coroutines.Flow.IMutableStateFlowInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
			get;
			[Register("setValue", "(Ljava/lang/Object;)V", "GetSetValue_Ljava_lang_Object_Handler:Xamarin.KotlinX.Coroutines.Flow.IMutableStateFlowInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
			set;
		}

		[Register("compareAndSet", "(Ljava/lang/Object;Ljava/lang/Object;)Z", "GetCompareAndSet_Ljava_lang_Object_Ljava_lang_Object_Handler:Xamarin.KotlinX.Coroutines.Flow.IMutableStateFlowInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		bool CompareAndSet(Java.Lang.Object? expect, Java.Lang.Object? update);
	}
	[Register("kotlinx/coroutines/flow/MutableStateFlow", DoNotGenerateAcw = true)]
	internal class IMutableStateFlowInvoker : Java.Lang.Object, IMutableStateFlow, IMutableSharedFlow, IFlowCollector, IJavaObject, IDisposable, IJavaPeerable, ISharedFlow, IFlow, IStateFlow
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/flow/MutableStateFlow", typeof(IMutableStateFlowInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_getValue;

		private static Delegate? cb_setValue_Ljava_lang_Object_;

		private IntPtr id_getValue;

		private IntPtr id_setValue_Ljava_lang_Object_;

		private static Delegate? cb_compareAndSet_Ljava_lang_Object_Ljava_lang_Object_;

		private IntPtr id_compareAndSet_Ljava_lang_Object_Ljava_lang_Object_;

		private static Delegate? cb_getSubscriptionCount;

		private IntPtr id_getSubscriptionCount;

		private static Delegate? cb_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_;

		private IntPtr id_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_;

		private static Delegate? cb_resetReplayCache;

		private IntPtr id_resetReplayCache;

		private static Delegate? cb_tryEmit_Ljava_lang_Object_;

		private IntPtr id_tryEmit_Ljava_lang_Object_;

		private static Delegate? cb_getReplayCache;

		private IntPtr id_getReplayCache;

		private static Delegate? cb_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_;

		private IntPtr id_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_;

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

		public unsafe Java.Lang.Object? Value
		{
			get
			{
				if (id_getValue == IntPtr.Zero)
				{
					id_getValue = JNIEnv.GetMethodID(class_ref, "getValue", "()Ljava/lang/Object;");
				}
				return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_getValue), JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				if (id_setValue_Ljava_lang_Object_ == IntPtr.Zero)
				{
					id_setValue_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "setValue", "(Ljava/lang/Object;)V");
				}
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
				JValue* ptr = stackalloc JValue[1];
				*ptr = new JValue(intPtr);
				JNIEnv.CallVoidMethod(base.Handle, id_setValue_Ljava_lang_Object_, ptr);
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		public IStateFlow SubscriptionCount
		{
			get
			{
				if (id_getSubscriptionCount == IntPtr.Zero)
				{
					id_getSubscriptionCount = JNIEnv.GetMethodID(class_ref, "getSubscriptionCount", "()Lkotlinx/coroutines/flow/StateFlow;");
				}
				return Java.Lang.Object.GetObject<IStateFlow>(JNIEnv.CallObjectMethod(base.Handle, id_getSubscriptionCount), JniHandleOwnership.TransferLocalRef);
			}
		}

		public System.Collections.IList ReplayCache
		{
			get
			{
				if (id_getReplayCache == IntPtr.Zero)
				{
					id_getReplayCache = JNIEnv.GetMethodID(class_ref, "getReplayCache", "()Ljava/util/List;");
				}
				return JavaList.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getReplayCache), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static IMutableStateFlow? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IMutableStateFlow>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'kotlinx.coroutines.flow.MutableStateFlow'.");
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

		public IMutableStateFlowInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetValueHandler()
		{
			if ((object)cb_getValue == null)
			{
				cb_getValue = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetValue));
			}
			return cb_getValue;
		}

		private static IntPtr n_GetValue(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMutableStateFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value);
		}

		private static Delegate GetSetValue_Ljava_lang_Object_Handler()
		{
			if ((object)cb_setValue_Ljava_lang_Object_ == null)
			{
				cb_setValue_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_SetValue_Ljava_lang_Object_));
			}
			return cb_setValue_Ljava_lang_Object_;
		}

		private static void n_SetValue_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_value)
		{
			IMutableStateFlow mutableStateFlow = Java.Lang.Object.GetObject<IMutableStateFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			mutableStateFlow.Value = value;
		}

		private static Delegate GetCompareAndSet_Ljava_lang_Object_Ljava_lang_Object_Handler()
		{
			if ((object)cb_compareAndSet_Ljava_lang_Object_Ljava_lang_Object_ == null)
			{
				cb_compareAndSet_Ljava_lang_Object_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_Z(n_CompareAndSet_Ljava_lang_Object_Ljava_lang_Object_));
			}
			return cb_compareAndSet_Ljava_lang_Object_Ljava_lang_Object_;
		}

		private static bool n_CompareAndSet_Ljava_lang_Object_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_expect, IntPtr native_update)
		{
			IMutableStateFlow mutableStateFlow = Java.Lang.Object.GetObject<IMutableStateFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object expect = Java.Lang.Object.GetObject<Java.Lang.Object>(native_expect, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object update = Java.Lang.Object.GetObject<Java.Lang.Object>(native_update, JniHandleOwnership.DoNotTransfer);
			return mutableStateFlow.CompareAndSet(expect, update);
		}

		public unsafe bool CompareAndSet(Java.Lang.Object? expect, Java.Lang.Object? update)
		{
			if (id_compareAndSet_Ljava_lang_Object_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_compareAndSet_Ljava_lang_Object_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "compareAndSet", "(Ljava/lang/Object;Ljava/lang/Object;)Z");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(expect);
			IntPtr intPtr2 = JNIEnv.ToLocalJniHandle(update);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue(intPtr2);
			bool result = JNIEnv.CallBooleanMethod(base.Handle, id_compareAndSet_Ljava_lang_Object_Ljava_lang_Object_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			JNIEnv.DeleteLocalRef(intPtr2);
			return result;
		}

		private static Delegate GetGetSubscriptionCountHandler()
		{
			if ((object)cb_getSubscriptionCount == null)
			{
				cb_getSubscriptionCount = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetSubscriptionCount));
			}
			return cb_getSubscriptionCount;
		}

		private static IntPtr n_GetSubscriptionCount(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IMutableStateFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).SubscriptionCount);
		}

		private static Delegate GetEmit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_Handler()
		{
			if ((object)cb_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_ == null)
			{
				cb_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_));
			}
			return cb_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_;
		}

		private static IntPtr n_Emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_(IntPtr jnienv, IntPtr native__this, IntPtr native_value, IntPtr native_p1)
		{
			IMutableStateFlow mutableStateFlow = Java.Lang.Object.GetObject<IMutableStateFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			IContinuation p = Java.Lang.Object.GetObject<IContinuation>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(mutableStateFlow.Emit(value, p));
		}

		public unsafe Java.Lang.Object? Emit(Java.Lang.Object? value, IContinuation p1)
		{
			if (id_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_ == IntPtr.Zero)
			{
				id_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_ = JNIEnv.GetMethodID(class_ref, "emit", "(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(intPtr);
			ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			Java.Lang.Object result = Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_emit_Ljava_lang_Object_Lkotlin_coroutines_Continuation_, ptr), JniHandleOwnership.TransferLocalRef);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetResetReplayCacheHandler()
		{
			if ((object)cb_resetReplayCache == null)
			{
				cb_resetReplayCache = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_ResetReplayCache));
			}
			return cb_resetReplayCache;
		}

		private static void n_ResetReplayCache(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<IMutableStateFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ResetReplayCache();
		}

		public void ResetReplayCache()
		{
			if (id_resetReplayCache == IntPtr.Zero)
			{
				id_resetReplayCache = JNIEnv.GetMethodID(class_ref, "resetReplayCache", "()V");
			}
			JNIEnv.CallVoidMethod(base.Handle, id_resetReplayCache);
		}

		private static Delegate GetTryEmit_Ljava_lang_Object_Handler()
		{
			if ((object)cb_tryEmit_Ljava_lang_Object_ == null)
			{
				cb_tryEmit_Ljava_lang_Object_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_Z(n_TryEmit_Ljava_lang_Object_));
			}
			return cb_tryEmit_Ljava_lang_Object_;
		}

		private static bool n_TryEmit_Ljava_lang_Object_(IntPtr jnienv, IntPtr native__this, IntPtr native_value)
		{
			IMutableStateFlow mutableStateFlow = Java.Lang.Object.GetObject<IMutableStateFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Java.Lang.Object value = Java.Lang.Object.GetObject<Java.Lang.Object>(native_value, JniHandleOwnership.DoNotTransfer);
			return mutableStateFlow.TryEmit(value);
		}

		public unsafe bool TryEmit(Java.Lang.Object? value)
		{
			if (id_tryEmit_Ljava_lang_Object_ == IntPtr.Zero)
			{
				id_tryEmit_Ljava_lang_Object_ = JNIEnv.GetMethodID(class_ref, "tryEmit", "(Ljava/lang/Object;)Z");
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(intPtr);
			bool result = JNIEnv.CallBooleanMethod(base.Handle, id_tryEmit_Ljava_lang_Object_, ptr);
			JNIEnv.DeleteLocalRef(intPtr);
			return result;
		}

		private static Delegate GetGetReplayCacheHandler()
		{
			if ((object)cb_getReplayCache == null)
			{
				cb_getReplayCache = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetReplayCache));
			}
			return cb_getReplayCache;
		}

		private static IntPtr n_GetReplayCache(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList.ToLocalJniHandle(Java.Lang.Object.GetObject<IMutableStateFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReplayCache);
		}

		private static Delegate GetCollect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_Handler()
		{
			if ((object)cb_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_ == null)
			{
				cb_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_));
			}
			return cb_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_;
		}

		private static IntPtr n_Collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_(IntPtr jnienv, IntPtr native__this, IntPtr native_collector, IntPtr native_p1)
		{
			IMutableStateFlow mutableStateFlow = Java.Lang.Object.GetObject<IMutableStateFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IFlowCollector collector = Java.Lang.Object.GetObject<IFlowCollector>(native_collector, JniHandleOwnership.DoNotTransfer);
			IContinuation p = Java.Lang.Object.GetObject<IContinuation>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(mutableStateFlow.Collect(collector, p));
		}

		public unsafe Java.Lang.Object? Collect(IFlowCollector collector, IContinuation p1)
		{
			if (id_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_ == IntPtr.Zero)
			{
				id_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_ = JNIEnv.GetMethodID(class_ref, "collect", "(Lkotlinx/coroutines/flow/FlowCollector;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue((collector == null) ? IntPtr.Zero : ((Java.Lang.Object)collector).Handle);
			ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("kotlinx/coroutines/flow/SharedFlow", "", "Xamarin.KotlinX.Coroutines.Flow.ISharedFlowInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface ISharedFlow : IFlow, IJavaObject, IDisposable, IJavaPeerable
	{
		System.Collections.IList ReplayCache
		{
			[Register("getReplayCache", "()Ljava/util/List;", "GetGetReplayCacheHandler:Xamarin.KotlinX.Coroutines.Flow.ISharedFlowInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
			get;
		}

		[Register("collect", "(Lkotlinx/coroutines/flow/FlowCollector;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "GetCollect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_Handler:Xamarin.KotlinX.Coroutines.Flow.ISharedFlowInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		new Java.Lang.Object? Collect(IFlowCollector collector, IContinuation p1);
	}
	[Register("kotlinx/coroutines/flow/SharedFlow", DoNotGenerateAcw = true)]
	internal class ISharedFlowInvoker : Java.Lang.Object, ISharedFlow, IFlow, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/flow/SharedFlow", typeof(ISharedFlowInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_getReplayCache;

		private IntPtr id_getReplayCache;

		private static Delegate? cb_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_;

		private IntPtr id_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_;

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

		public System.Collections.IList ReplayCache
		{
			get
			{
				if (id_getReplayCache == IntPtr.Zero)
				{
					id_getReplayCache = JNIEnv.GetMethodID(class_ref, "getReplayCache", "()Ljava/util/List;");
				}
				return JavaList.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getReplayCache), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static ISharedFlow? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISharedFlow>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'kotlinx.coroutines.flow.SharedFlow'.");
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

		public ISharedFlowInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetReplayCacheHandler()
		{
			if ((object)cb_getReplayCache == null)
			{
				cb_getReplayCache = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetReplayCache));
			}
			return cb_getReplayCache;
		}

		private static IntPtr n_GetReplayCache(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList.ToLocalJniHandle(Java.Lang.Object.GetObject<ISharedFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReplayCache);
		}

		private static Delegate GetCollect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_Handler()
		{
			if ((object)cb_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_ == null)
			{
				cb_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_));
			}
			return cb_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_;
		}

		private static IntPtr n_Collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_(IntPtr jnienv, IntPtr native__this, IntPtr native_collector, IntPtr native_p1)
		{
			ISharedFlow sharedFlow = Java.Lang.Object.GetObject<ISharedFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IFlowCollector collector = Java.Lang.Object.GetObject<IFlowCollector>(native_collector, JniHandleOwnership.DoNotTransfer);
			IContinuation p = Java.Lang.Object.GetObject<IContinuation>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(sharedFlow.Collect(collector, p));
		}

		public unsafe Java.Lang.Object? Collect(IFlowCollector collector, IContinuation p1)
		{
			if (id_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_ == IntPtr.Zero)
			{
				id_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_ = JNIEnv.GetMethodID(class_ref, "collect", "(Lkotlinx/coroutines/flow/FlowCollector;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue((collector == null) ? IntPtr.Zero : ((Java.Lang.Object)collector).Handle);
			ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("kotlinx/coroutines/flow/SharingStarted$Companion", DoNotGenerateAcw = true)]
	public sealed class SharingStartedCompanion : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/flow/SharingStarted$Companion", typeof(SharingStartedCompanion));

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

		public unsafe ISharingStarted Eagerly
		{
			[Register("getEagerly", "()Lkotlinx/coroutines/flow/SharingStarted;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ISharingStarted>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getEagerly.()Lkotlinx/coroutines/flow/SharingStarted;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe ISharingStarted Lazily
		{
			[Register("getLazily", "()Lkotlinx/coroutines/flow/SharingStarted;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ISharingStarted>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getLazily.()Lkotlinx/coroutines/flow/SharingStarted;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal SharingStartedCompanion(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("WhileSubscribed", "(JJ)Lkotlinx/coroutines/flow/SharingStarted;", "")]
		public unsafe ISharingStarted WhileSubscribed(long stopTimeoutMillis, long replayExpirationMillis)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(stopTimeoutMillis);
			ptr[1] = new JniArgumentValue(replayExpirationMillis);
			return Java.Lang.Object.GetObject<ISharingStarted>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("WhileSubscribed.(JJ)Lkotlinx/coroutines/flow/SharingStarted;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("kotlinx/coroutines/flow/SharingStarted", DoNotGenerateAcw = true)]
	public abstract class SharingStarted : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/flow/SharingStarted", typeof(SharingStarted));

		[Register("Companion")]
		public static SharingStartedCompanion Companion => Java.Lang.Object.GetObject<SharingStartedCompanion>(_members.StaticFields.GetObjectValue("Companion.Lkotlinx/coroutines/flow/SharingStarted$Companion;").Handle, JniHandleOwnership.TransferLocalRef);

		internal SharingStarted()
		{
		}
	}
	[Register("kotlinx/coroutines/flow/SharingStarted", DoNotGenerateAcw = true)]
	[Obsolete("Use the 'SharingStarted' type. This type will be removed in a future release.", true)]
	public abstract class SharingStartedConsts : SharingStarted
	{
		private SharingStartedConsts()
		{
		}
	}
	[Register("kotlinx/coroutines/flow/SharingStarted", "", "Xamarin.KotlinX.Coroutines.Flow.ISharingStartedInvoker")]
	public interface ISharingStarted : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("command", "(Lkotlinx/coroutines/flow/StateFlow;)Lkotlinx/coroutines/flow/Flow;", "GetCommand_Lkotlinx_coroutines_flow_StateFlow_Handler:Xamarin.KotlinX.Coroutines.Flow.ISharingStartedInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		IFlow Command(IStateFlow subscriptionCount);
	}
	[Register("kotlinx/coroutines/flow/SharingStarted", DoNotGenerateAcw = true)]
	internal class ISharingStartedInvoker : Java.Lang.Object, ISharingStarted, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/flow/SharingStarted", typeof(ISharingStartedInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_command_Lkotlinx_coroutines_flow_StateFlow_;

		private IntPtr id_command_Lkotlinx_coroutines_flow_StateFlow_;

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

		public static ISharingStarted? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ISharingStarted>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'kotlinx.coroutines.flow.SharingStarted'.");
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

		public ISharingStartedInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetCommand_Lkotlinx_coroutines_flow_StateFlow_Handler()
		{
			if ((object)cb_command_Lkotlinx_coroutines_flow_StateFlow_ == null)
			{
				cb_command_Lkotlinx_coroutines_flow_StateFlow_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Command_Lkotlinx_coroutines_flow_StateFlow_));
			}
			return cb_command_Lkotlinx_coroutines_flow_StateFlow_;
		}

		private static IntPtr n_Command_Lkotlinx_coroutines_flow_StateFlow_(IntPtr jnienv, IntPtr native__this, IntPtr native_subscriptionCount)
		{
			ISharingStarted sharingStarted = Java.Lang.Object.GetObject<ISharingStarted>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IStateFlow subscriptionCount = Java.Lang.Object.GetObject<IStateFlow>(native_subscriptionCount, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(sharingStarted.Command(subscriptionCount));
		}

		public unsafe IFlow Command(IStateFlow subscriptionCount)
		{
			if (id_command_Lkotlinx_coroutines_flow_StateFlow_ == IntPtr.Zero)
			{
				id_command_Lkotlinx_coroutines_flow_StateFlow_ = JNIEnv.GetMethodID(class_ref, "command", "(Lkotlinx/coroutines/flow/StateFlow;)Lkotlinx/coroutines/flow/Flow;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((subscriptionCount == null) ? IntPtr.Zero : ((Java.Lang.Object)subscriptionCount).Handle);
			return Java.Lang.Object.GetObject<IFlow>(JNIEnv.CallObjectMethod(base.Handle, id_command_Lkotlinx_coroutines_flow_StateFlow_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("kotlinx/coroutines/flow/StateFlow", "", "Xamarin.KotlinX.Coroutines.Flow.IStateFlowInvoker")]
	[JavaTypeParameters(new string[] { "T" })]
	public interface IStateFlow : ISharedFlow, IFlow, IJavaObject, IDisposable, IJavaPeerable
	{
		Java.Lang.Object? Value
		{
			[Register("getValue", "()Ljava/lang/Object;", "GetGetValueHandler:Xamarin.KotlinX.Coroutines.Flow.IStateFlowInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
			get;
		}
	}
	[Register("kotlinx/coroutines/flow/StateFlow", DoNotGenerateAcw = true)]
	internal class IStateFlowInvoker : Java.Lang.Object, IStateFlow, ISharedFlow, IFlow, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/flow/StateFlow", typeof(IStateFlowInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_getValue;

		private IntPtr id_getValue;

		private static Delegate? cb_getReplayCache;

		private IntPtr id_getReplayCache;

		private static Delegate? cb_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_;

		private IntPtr id_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_;

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

		public Java.Lang.Object? Value
		{
			get
			{
				if (id_getValue == IntPtr.Zero)
				{
					id_getValue = JNIEnv.GetMethodID(class_ref, "getValue", "()Ljava/lang/Object;");
				}
				return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_getValue), JniHandleOwnership.TransferLocalRef);
			}
		}

		public System.Collections.IList ReplayCache
		{
			get
			{
				if (id_getReplayCache == IntPtr.Zero)
				{
					id_getReplayCache = JNIEnv.GetMethodID(class_ref, "getReplayCache", "()Ljava/util/List;");
				}
				return JavaList.FromJniHandle(JNIEnv.CallObjectMethod(base.Handle, id_getReplayCache), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static IStateFlow? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IStateFlow>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'kotlinx.coroutines.flow.StateFlow'.");
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

		public IStateFlowInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetValueHandler()
		{
			if ((object)cb_getValue == null)
			{
				cb_getValue = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetValue));
			}
			return cb_getValue;
		}

		private static IntPtr n_GetValue(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IStateFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Value);
		}

		private static Delegate GetGetReplayCacheHandler()
		{
			if ((object)cb_getReplayCache == null)
			{
				cb_getReplayCache = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetReplayCache));
			}
			return cb_getReplayCache;
		}

		private static IntPtr n_GetReplayCache(IntPtr jnienv, IntPtr native__this)
		{
			return JavaList.ToLocalJniHandle(Java.Lang.Object.GetObject<IStateFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ReplayCache);
		}

		private static Delegate GetCollect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_Handler()
		{
			if ((object)cb_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_ == null)
			{
				cb_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLL_L(n_Collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_));
			}
			return cb_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_;
		}

		private static IntPtr n_Collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_(IntPtr jnienv, IntPtr native__this, IntPtr native_collector, IntPtr native_p1)
		{
			IStateFlow stateFlow = Java.Lang.Object.GetObject<IStateFlow>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IFlowCollector collector = Java.Lang.Object.GetObject<IFlowCollector>(native_collector, JniHandleOwnership.DoNotTransfer);
			IContinuation p = Java.Lang.Object.GetObject<IContinuation>(native_p1, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(stateFlow.Collect(collector, p));
		}

		public unsafe Java.Lang.Object? Collect(IFlowCollector collector, IContinuation p1)
		{
			if (id_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_ == IntPtr.Zero)
			{
				id_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_ = JNIEnv.GetMethodID(class_ref, "collect", "(Lkotlinx/coroutines/flow/FlowCollector;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue((collector == null) ? IntPtr.Zero : ((Java.Lang.Object)collector).Handle);
			ptr[1] = new JValue((p1 == null) ? IntPtr.Zero : ((Java.Lang.Object)p1).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_collect_Lkotlinx_coroutines_flow_FlowCollector_Lkotlin_coroutines_Continuation_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("kotlinx/coroutines/flow/LintKt", DoNotGenerateAcw = true)]
	public sealed class LintKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/flow/LintKt", typeof(LintKt));

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

		internal LintKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Obsolete("deprecated")]
		[Register("cancel", "(Lkotlinx/coroutines/flow/FlowCollector;Ljava/util/concurrent/CancellationException;)V", "")]
		public unsafe static void Cancel(IFlowCollector obj, CancellationException? cause)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				ptr[1] = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("cancel.(Lkotlinx/coroutines/flow/FlowCollector;Ljava/util/concurrent/CancellationException;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(cause);
			}
		}

		[Obsolete("deprecated")]
		[Register("cancellable", "(Lkotlinx/coroutines/flow/SharedFlow;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Cancellable(ISharedFlow obj)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("cancellable.(Lkotlinx/coroutines/flow/SharedFlow;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}

		[Obsolete("deprecated")]
		[Register("conflate", "(Lkotlinx/coroutines/flow/StateFlow;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow Conflate(IStateFlow obj)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("conflate.(Lkotlinx/coroutines/flow/StateFlow;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}

		[Obsolete("deprecated")]
		[Register("distinctUntilChanged", "(Lkotlinx/coroutines/flow/StateFlow;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow DistinctUntilChanged(IStateFlow obj)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("distinctUntilChanged.(Lkotlinx/coroutines/flow/StateFlow;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}

		[Obsolete("deprecated")]
		[Register("flowOn", "(Lkotlinx/coroutines/flow/SharedFlow;Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/flow/Flow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IFlow FlowOn(ISharedFlow obj, ICoroutineContext context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				ptr[1] = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				return Java.Lang.Object.GetObject<IFlow>(_members.StaticMethods.InvokeObjectMethod("flowOn.(Lkotlinx/coroutines/flow/SharedFlow;Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/flow/Flow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(context);
			}
		}

		[Obsolete("deprecated")]
		[Register("getCoroutineContext", "(Lkotlinx/coroutines/flow/FlowCollector;)Lkotlin/coroutines/CoroutineContext;", "")]
		public unsafe static ICoroutineContext GetCoroutineContext(IFlowCollector obj)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				return Java.Lang.Object.GetObject<ICoroutineContext>(_members.StaticMethods.InvokeObjectMethod("getCoroutineContext.(Lkotlinx/coroutines/flow/FlowCollector;)Lkotlin/coroutines/CoroutineContext;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}

		[Obsolete("deprecated")]
		[Register("isActive", "(Lkotlinx/coroutines/flow/FlowCollector;)Z", "")]
		public unsafe static bool IsActive(IFlowCollector obj)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				return _members.StaticMethods.InvokeBooleanMethod("isActive.(Lkotlinx/coroutines/flow/FlowCollector;)Z", ptr);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}
	}
	[Register("kotlinx/coroutines/flow/SharedFlowKt", DoNotGenerateAcw = true)]
	public sealed class SharedFlowKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/flow/SharedFlowKt", typeof(SharedFlowKt));

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

		internal SharedFlowKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("MutableSharedFlow", "(IILkotlinx/coroutines/channels/BufferOverflow;)Lkotlinx/coroutines/flow/MutableSharedFlow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IMutableSharedFlow MutableSharedFlow(int replay, int extraBufferCapacity, BufferOverflow onBufferOverflow)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(replay);
				ptr[1] = new JniArgumentValue(extraBufferCapacity);
				ptr[2] = new JniArgumentValue(onBufferOverflow?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IMutableSharedFlow>(_members.StaticMethods.InvokeObjectMethod("MutableSharedFlow.(IILkotlinx/coroutines/channels/BufferOverflow;)Lkotlinx/coroutines/flow/MutableSharedFlow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(onBufferOverflow);
			}
		}
	}
	[Register("kotlinx/coroutines/flow/SharingCommand", DoNotGenerateAcw = true)]
	public sealed class SharingCommand : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/flow/SharingCommand", typeof(SharingCommand));

		[Register("START")]
		public static SharingCommand? Start => Java.Lang.Object.GetObject<SharingCommand>(_members.StaticFields.GetObjectValue("START.Lkotlinx/coroutines/flow/SharingCommand;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("STOP")]
		public static SharingCommand? Stop => Java.Lang.Object.GetObject<SharingCommand>(_members.StaticFields.GetObjectValue("STOP.Lkotlinx/coroutines/flow/SharingCommand;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("STOP_AND_RESET_REPLAY_CACHE")]
		public static SharingCommand? StopAndResetReplayCache => Java.Lang.Object.GetObject<SharingCommand>(_members.StaticFields.GetObjectValue("STOP_AND_RESET_REPLAY_CACHE.Lkotlinx/coroutines/flow/SharingCommand;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal SharingCommand(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lkotlinx/coroutines/flow/SharingCommand;", "")]
		public unsafe static SharingCommand? ValueOf(string? value)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<SharingCommand>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lkotlinx/coroutines/flow/SharingCommand;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lkotlinx/coroutines/flow/SharingCommand;", "")]
		public unsafe static SharingCommand[]? Values()
		{
			return (SharingCommand[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lkotlinx/coroutines/flow/SharingCommand;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(SharingCommand));
		}
	}
	[Register("kotlinx/coroutines/flow/SharingStartedKt", DoNotGenerateAcw = true)]
	public sealed class SharingStartedKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/flow/SharingStartedKt", typeof(SharingStartedKt));

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

		internal SharingStartedKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("WhileSubscribed-5qebJ5I", "(Lkotlinx/coroutines/flow/SharingStarted$Companion;JJ)Lkotlinx/coroutines/flow/SharingStarted;", "")]
		public unsafe static ISharingStarted WhileSubscribed(SharingStartedCompanion obj, long stopTimeout, long replayExpiration)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(stopTimeout);
				ptr[2] = new JniArgumentValue(replayExpiration);
				return Java.Lang.Object.GetObject<ISharingStarted>(_members.StaticMethods.InvokeObjectMethod("WhileSubscribed-5qebJ5I.(Lkotlinx/coroutines/flow/SharingStarted$Companion;JJ)Lkotlinx/coroutines/flow/SharingStarted;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}
	}
	[Register("kotlinx/coroutines/flow/StateFlowKt", DoNotGenerateAcw = true)]
	public sealed class StateFlowKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/flow/StateFlowKt", typeof(StateFlowKt));

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

		internal StateFlowKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("MutableStateFlow", "(Ljava/lang/Object;)Lkotlinx/coroutines/flow/MutableStateFlow;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static IMutableStateFlow MutableStateFlow(Java.Lang.Object? value)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<IMutableStateFlow>(_members.StaticMethods.InvokeObjectMethod("MutableStateFlow.(Ljava/lang/Object;)Lkotlinx/coroutines/flow/MutableStateFlow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
			}
		}

		[Register("getAndUpdate", "(Lkotlinx/coroutines/flow/MutableStateFlow;Lkotlin/jvm/functions/Function1;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? GetAndUpdate(IMutableStateFlow obj, IFunction1 function)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				ptr[1] = new JniArgumentValue((function == null) ? IntPtr.Zero : ((Java.Lang.Object)function).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("getAndUpdate.(Lkotlinx/coroutines/flow/MutableStateFlow;Lkotlin/jvm/functions/Function1;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(function);
			}
		}

		[Register("update", "(Lkotlinx/coroutines/flow/MutableStateFlow;Lkotlin/jvm/functions/Function1;)V", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static void Update(IMutableStateFlow obj, IFunction1 function)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				ptr[1] = new JniArgumentValue((function == null) ? IntPtr.Zero : ((Java.Lang.Object)function).Handle);
				_members.StaticMethods.InvokeVoidMethod("update.(Lkotlinx/coroutines/flow/MutableStateFlow;Lkotlin/jvm/functions/Function1;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(function);
			}
		}

		[Register("updateAndGet", "(Lkotlinx/coroutines/flow/MutableStateFlow;Lkotlin/jvm/functions/Function1;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? UpdateAndGet(IMutableStateFlow obj, IFunction1 function)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue((obj == null) ? IntPtr.Zero : ((Java.Lang.Object)obj).Handle);
				ptr[1] = new JniArgumentValue((function == null) ? IntPtr.Zero : ((Java.Lang.Object)function).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("updateAndGet.(Lkotlinx/coroutines/flow/MutableStateFlow;Lkotlin/jvm/functions/Function1;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(function);
			}
		}
	}
}
namespace Xamarin.KotlinX.Coroutines.Channels
{
	[Register("kotlinx/coroutines/channels/AbstractChannelKt", DoNotGenerateAcw = true)]
	public sealed class AbstractChannelKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/channels/AbstractChannelKt", typeof(AbstractChannelKt));

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

		internal AbstractChannelKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/channels/ActorKt", DoNotGenerateAcw = true)]
	public sealed class ActorKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/channels/ActorKt", typeof(ActorKt));

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

		internal ActorKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/channels/BroadcastChannelKt", DoNotGenerateAcw = true)]
	public sealed class BroadcastChannelKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/channels/BroadcastChannelKt", typeof(BroadcastChannelKt));

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

		internal BroadcastChannelKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/channels/BroadcastKt", DoNotGenerateAcw = true)]
	public sealed class BroadcastKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/channels/BroadcastKt", typeof(BroadcastKt));

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

		internal BroadcastKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/channels/BufferOverflow", DoNotGenerateAcw = true)]
	public sealed class BufferOverflow : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/channels/BufferOverflow", typeof(BufferOverflow));

		[Register("DROP_LATEST")]
		public static BufferOverflow? DropLatest => Java.Lang.Object.GetObject<BufferOverflow>(_members.StaticFields.GetObjectValue("DROP_LATEST.Lkotlinx/coroutines/channels/BufferOverflow;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("DROP_OLDEST")]
		public static BufferOverflow? DropOldest => Java.Lang.Object.GetObject<BufferOverflow>(_members.StaticFields.GetObjectValue("DROP_OLDEST.Lkotlinx/coroutines/channels/BufferOverflow;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("SUSPEND")]
		public static BufferOverflow? Suspend => Java.Lang.Object.GetObject<BufferOverflow>(_members.StaticFields.GetObjectValue("SUSPEND.Lkotlinx/coroutines/channels/BufferOverflow;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal BufferOverflow(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lkotlinx/coroutines/channels/BufferOverflow;", "")]
		public unsafe static BufferOverflow? ValueOf(string? value)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<BufferOverflow>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lkotlinx/coroutines/channels/BufferOverflow;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lkotlinx/coroutines/channels/BufferOverflow;", "")]
		public unsafe static BufferOverflow[]? Values()
		{
			return (BufferOverflow[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lkotlinx/coroutines/channels/BufferOverflow;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(BufferOverflow));
		}
	}
	[Register("kotlinx/coroutines/channels/ChannelKt", DoNotGenerateAcw = true)]
	public sealed class ChannelKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/channels/ChannelKt", typeof(ChannelKt));

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

		internal ChannelKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("getOrElse-WpGqRn0", "(Ljava/lang/Object;Lkotlin/jvm/functions/Function1;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object? GetOrElse(Java.Lang.Object obj, IFunction1 onFailure)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((onFailure == null) ? IntPtr.Zero : ((Java.Lang.Object)onFailure).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("getOrElse-WpGqRn0.(Ljava/lang/Object;Lkotlin/jvm/functions/Function1;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(onFailure);
			}
		}

		[Register("onClosed-WpGqRn0", "(Ljava/lang/Object;Lkotlin/jvm/functions/Function1;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object OnClosed(Java.Lang.Object obj, IFunction1 action)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("onClosed-WpGqRn0.(Ljava/lang/Object;Lkotlin/jvm/functions/Function1;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(action);
			}
		}

		[Register("onFailure-WpGqRn0", "(Ljava/lang/Object;Lkotlin/jvm/functions/Function1;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object OnFailure(Java.Lang.Object obj, IFunction1 action)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("onFailure-WpGqRn0.(Ljava/lang/Object;Lkotlin/jvm/functions/Function1;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(action);
			}
		}

		[Register("onSuccess-WpGqRn0", "(Ljava/lang/Object;Lkotlin/jvm/functions/Function1;)Ljava/lang/Object;", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe static Java.Lang.Object OnSuccess(Java.Lang.Object obj, IFunction1 action)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue((action == null) ? IntPtr.Zero : ((Java.Lang.Object)action).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("onSuccess-WpGqRn0.(Ljava/lang/Object;Lkotlin/jvm/functions/Function1;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
				GC.KeepAlive(action);
			}
		}
	}
	[Register("kotlinx/coroutines/channels/ChannelResult", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "T" })]
	public sealed class ChannelResult : Java.Lang.Object
	{
		[Register("kotlinx/coroutines/channels/ChannelResult$Companion", DoNotGenerateAcw = true)]
		public sealed class Companion : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/channels/ChannelResult$Companion", typeof(Companion));

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

			internal Companion(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
			public unsafe Companion(DefaultConstructorMarker? _constructor_marker)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(_constructor_marker?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(_constructor_marker);
				}
			}

			[Register("closed-JP2dKIU", "(Ljava/lang/Throwable;)Ljava/lang/Object;", "")]
			[JavaTypeParameters(new string[] { "E" })]
			public unsafe Java.Lang.Object Closed_JP2dKIU(Throwable? cause)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("closed-JP2dKIU.(Ljava/lang/Throwable;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(cause);
				}
			}

			[Register("failure-PtdJZtk", "()Ljava/lang/Object;", "")]
			[JavaTypeParameters(new string[] { "E" })]
			public unsafe Java.Lang.Object Failure_PtdJZtk()
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("failure-PtdJZtk.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("success-JP2dKIU", "(Ljava/lang/Object;)Ljava/lang/Object;", "")]
			[JavaTypeParameters(new string[] { "E" })]
			public unsafe Java.Lang.Object Success_JP2dKIU(Java.Lang.Object? value)
			{
				IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("success-JP2dKIU.(Ljava/lang/Object;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
					GC.KeepAlive(value);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/channels/ChannelResult", typeof(ChannelResult));

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

		internal ChannelResult(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/channels/ChannelsKt", DoNotGenerateAcw = true)]
	public sealed class ChannelsKt : Java.Lang.Object
	{
		[Register("DEFAULT_CLOSE_MESSAGE")]
		public const string DefaultCloseMessage = "Channel was closed";

		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/channels/ChannelsKt", typeof(ChannelsKt));

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

		internal ChannelsKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/channels/ClosedReceiveChannelException", DoNotGenerateAcw = true)]
	public sealed class ClosedReceiveChannelException : NoSuchElementException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/channels/ClosedReceiveChannelException", typeof(ClosedReceiveChannelException));

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

		internal ClosedReceiveChannelException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe ClosedReceiveChannelException(string? message)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("kotlinx/coroutines/channels/ClosedSendChannelException", DoNotGenerateAcw = true)]
	public sealed class ClosedSendChannelException : IllegalStateException
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/channels/ClosedSendChannelException", typeof(ClosedSendChannelException));

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

		internal ClosedSendChannelException(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/lang/String;)V", "")]
		public unsafe ClosedSendChannelException(string? message)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(message);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;)V", ((object)this).GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("kotlinx/coroutines/channels/ConflatedBroadcastChannel", DoNotGenerateAcw = true)]
	[JavaTypeParameters(new string[] { "E" })]
	public sealed class ConflatedBroadcastChannel : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/channels/ConflatedBroadcastChannel", typeof(ConflatedBroadcastChannel));

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

		public unsafe bool IsClosedForSend
		{
			[Register("isClosedForSend", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isClosedForSend.()Z", this, null);
			}
		}

		public unsafe Java.Lang.Object? Value
		{
			[Register("getValue", "()Ljava/lang/Object;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getValue.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Java.Lang.Object? ValueOrNull
		{
			[Register("getValueOrNull", "()Ljava/lang/Object;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getValueOrNull.()Ljava/lang/Object;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal ConflatedBroadcastChannel(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ConflatedBroadcastChannel()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Ljava/lang/Object;)V", "")]
		public unsafe ConflatedBroadcastChannel(Java.Lang.Object? value)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/Object;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/Object;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(value);
			}
		}

		[Register("cancel", "(Ljava/util/concurrent/CancellationException;)V", "")]
		public unsafe void Cancel(CancellationException? cause)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				_members.InstanceMethods.InvokeAbstractVoidMethod("cancel.(Ljava/util/concurrent/CancellationException;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(cause);
			}
		}

		[Register("close", "(Ljava/lang/Throwable;)Z", "")]
		public unsafe bool Close(Throwable? cause)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(cause?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("close.(Ljava/lang/Throwable;)Z", this, ptr);
			}
			finally
			{
				GC.KeepAlive(cause);
			}
		}

		[Register("invokeOnClose", "(Lkotlin/jvm/functions/Function1;)V", "")]
		public unsafe void InvokeOnClose(IFunction1 handler)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((handler == null) ? IntPtr.Zero : ((Java.Lang.Object)handler).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("invokeOnClose.(Lkotlin/jvm/functions/Function1;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(handler);
			}
		}

		[Obsolete("deprecated")]
		[Register("offer", "(Ljava/lang/Object;)Z", "")]
		public unsafe bool Offer(Java.Lang.Object? element)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(element);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("offer.(Ljava/lang/Object;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(element);
			}
		}

		[Register("send", "(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		public unsafe Java.Lang.Object? Send(Java.Lang.Object? element, IContinuation _completion)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(element);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeAbstractObjectMethod("send.(Ljava/lang/Object;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(element);
				GC.KeepAlive(_completion);
			}
		}

		[Register("trySend-JP2dKIU", "(Ljava/lang/Object;)Ljava/lang/Object;", "")]
		public unsafe Java.Lang.Object TrySend(Java.Lang.Object? element)
		{
			IntPtr intPtr = JNIEnv.ToLocalJniHandle(element);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("trySend-JP2dKIU.(Ljava/lang/Object;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(element);
			}
		}
	}
	[Register("kotlinx/coroutines/channels/ChannelIterator$DefaultImpls", DoNotGenerateAcw = true)]
	public sealed class ChannelIteratorDefaultImpls : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/channels/ChannelIterator$DefaultImpls", typeof(ChannelIteratorDefaultImpls));

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

		internal ChannelIteratorDefaultImpls(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/channels/ChannelIterator", "", "Xamarin.KotlinX.Coroutines.Channels.IChannelIteratorInvoker")]
	[JavaTypeParameters(new string[] { "E" })]
	public interface IChannelIterator : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("hasNext", "(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "GetHasNext_Lkotlin_coroutines_Continuation_Handler:Xamarin.KotlinX.Coroutines.Channels.IChannelIteratorInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		Java.Lang.Object? HasNext(IContinuation p0);

		[Register("next", "()Ljava/lang/Object;", "GetNextHandler:Xamarin.KotlinX.Coroutines.Channels.IChannelIteratorInvoker, Xamarin.KotlinX.Coroutines.Core.Jvm")]
		Java.Lang.Object? Next();
	}
	[Register("kotlinx/coroutines/channels/ChannelIterator", DoNotGenerateAcw = true)]
	internal class IChannelIteratorInvoker : Java.Lang.Object, IChannelIterator, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/channels/ChannelIterator", typeof(IChannelIteratorInvoker));

		private IntPtr class_ref;

		private static Delegate? cb_hasNext_Lkotlin_coroutines_Continuation_;

		private IntPtr id_hasNext_Lkotlin_coroutines_Continuation_;

		private static Delegate? cb_next;

		private IntPtr id_next;

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

		public static IChannelIterator? GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IChannelIterator>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'kotlinx.coroutines.channels.ChannelIterator'.");
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

		public IChannelIteratorInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetHasNext_Lkotlin_coroutines_Continuation_Handler()
		{
			if ((object)cb_hasNext_Lkotlin_coroutines_Continuation_ == null)
			{
				cb_hasNext_Lkotlin_coroutines_Continuation_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_HasNext_Lkotlin_coroutines_Continuation_));
			}
			return cb_hasNext_Lkotlin_coroutines_Continuation_;
		}

		private static IntPtr n_HasNext_Lkotlin_coroutines_Continuation_(IntPtr jnienv, IntPtr native__this, IntPtr native_p0)
		{
			IChannelIterator channelIterator = Java.Lang.Object.GetObject<IChannelIterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IContinuation p = Java.Lang.Object.GetObject<IContinuation>(native_p0, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(channelIterator.HasNext(p));
		}

		public unsafe Java.Lang.Object? HasNext(IContinuation p0)
		{
			if (id_hasNext_Lkotlin_coroutines_Continuation_ == IntPtr.Zero)
			{
				id_hasNext_Lkotlin_coroutines_Continuation_ = JNIEnv.GetMethodID(class_ref, "hasNext", "(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((p0 == null) ? IntPtr.Zero : ((Java.Lang.Object)p0).Handle);
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_hasNext_Lkotlin_coroutines_Continuation_, ptr), JniHandleOwnership.TransferLocalRef);
		}

		private static Delegate GetNextHandler()
		{
			if ((object)cb_next == null)
			{
				cb_next = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Next));
			}
			return cb_next;
		}

		private static IntPtr n_Next(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IChannelIterator>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Next());
		}

		public Java.Lang.Object? Next()
		{
			if (id_next == IntPtr.Zero)
			{
				id_next = JNIEnv.GetMethodID(class_ref, "next", "()Ljava/lang/Object;");
			}
			return Java.Lang.Object.GetObject<Java.Lang.Object>(JNIEnv.CallObjectMethod(base.Handle, id_next), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("kotlinx/coroutines/channels/ProduceKt", DoNotGenerateAcw = true)]
	public sealed class ProduceKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/channels/ProduceKt", typeof(ProduceKt));

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

		internal ProduceKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/channels/TickerChannelsKt", DoNotGenerateAcw = true)]
	public sealed class TickerChannelsKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/channels/TickerChannelsKt", typeof(TickerChannelsKt));

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

		internal TickerChannelsKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("kotlinx/coroutines/channels/TickerMode", DoNotGenerateAcw = true)]
	public sealed class TickerMode : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/channels/TickerMode", typeof(TickerMode));

		[Register("FIXED_DELAY")]
		public static TickerMode? FixedDelay => Java.Lang.Object.GetObject<TickerMode>(_members.StaticFields.GetObjectValue("FIXED_DELAY.Lkotlinx/coroutines/channels/TickerMode;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("FIXED_PERIOD")]
		public static TickerMode? FixedPeriod => Java.Lang.Object.GetObject<TickerMode>(_members.StaticFields.GetObjectValue("FIXED_PERIOD.Lkotlinx/coroutines/channels/TickerMode;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal TickerMode(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Lkotlinx/coroutines/channels/TickerMode;", "")]
		public unsafe static TickerMode? ValueOf(string? value)
		{
			IntPtr intPtr = JNIEnv.NewString(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<TickerMode>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Lkotlinx/coroutines/channels/TickerMode;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Lkotlinx/coroutines/channels/TickerMode;", "")]
		public unsafe static TickerMode[]? Values()
		{
			return (TickerMode[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Lkotlinx/coroutines/channels/TickerMode;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(TickerMode));
		}
	}
}
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		private static string[]? package_kotlinx_coroutines_mappings;

		private static string[]? package_kotlinx_coroutines_channels_mappings;

		private static string[]? package_kotlinx_coroutines_flow_mappings;

		private static string[]? package_kotlinx_coroutines_intrinsics_mappings;

		private static string[]? package_kotlinx_coroutines_scheduling_mappings;

		private static string[]? package_kotlinx_coroutines_selects_mappings;

		private static string[]? package_kotlinx_coroutines_sync_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[7] { "kotlinx/coroutines", "kotlinx/coroutines/channels", "kotlinx/coroutines/flow", "kotlinx/coroutines/intrinsics", "kotlinx/coroutines/scheduling", "kotlinx/coroutines/selects", "kotlinx/coroutines/sync" }, new Converter<string, Type>[7] { lookup_kotlinx_coroutines_package, lookup_kotlinx_coroutines_channels_package, lookup_kotlinx_coroutines_flow_package, lookup_kotlinx_coroutines_intrinsics_package, lookup_kotlinx_coroutines_scheduling_package, lookup_kotlinx_coroutines_selects_package, lookup_kotlinx_coroutines_sync_package });
		}

		private static Type? Lookup(string[] mappings, string javaType)
		{
			string text = TypeManager.LookupTypeMapping(mappings, javaType);
			if (text == null)
			{
				return null;
			}
			return Type.GetType(text);
		}

		private static Type? lookup_kotlinx_coroutines_package(string klass)
		{
			if (package_kotlinx_coroutines_mappings == null)
			{
				package_kotlinx_coroutines_mappings = new string[53]
				{
					"kotlinx/coroutines/AbstractTimeSourceKt:Xamarin.KotlinX.Coroutines.AbstractTimeSourceKt", "kotlinx/coroutines/AwaitKt:Xamarin.KotlinX.Coroutines.AwaitKt", "kotlinx/coroutines/BuildersKt:Xamarin.KotlinX.Coroutines.BuildersKt", "kotlinx/coroutines/CancellableContinuation$DefaultImpls:Xamarin.KotlinX.Coroutines.CancellableContinuationDefaultImpls", "kotlinx/coroutines/CancellableContinuationImplKt:Xamarin.KotlinX.Coroutines.CancellableContinuationImplKt", "kotlinx/coroutines/CancellableContinuationKt:Xamarin.KotlinX.Coroutines.CancellableContinuationKt", "kotlinx/coroutines/CompletableDeferredKt:Xamarin.KotlinX.Coroutines.CompletableDeferredKt", "kotlinx/coroutines/CompletionHandlerException:Xamarin.KotlinX.Coroutines.CompletionHandlerException", "kotlinx/coroutines/CompletionHandlerKt:Xamarin.KotlinX.Coroutines.CompletionHandlerKt", "kotlinx/coroutines/CompletionHandler_commonKt:Xamarin.KotlinX.Coroutines.CompletionHandler_commonKt",
					"kotlinx/coroutines/CompletionStateKt:Xamarin.KotlinX.Coroutines.CompletionStateKt", "kotlinx/coroutines/CopyableThreadContextElement$DefaultImpls:Xamarin.KotlinX.Coroutines.CopyableThreadContextElementDefaultImpls", "kotlinx/coroutines/CoroutineContextKt:Xamarin.KotlinX.Coroutines.CoroutineContextKt", "kotlinx/coroutines/CoroutineDispatcher:Xamarin.KotlinX.Coroutines.CoroutineDispatcher", "kotlinx/coroutines/CoroutineExceptionHandler$DefaultImpls:Xamarin.KotlinX.Coroutines.CoroutineExceptionHandlerDefaultImpls", "kotlinx/coroutines/CoroutineExceptionHandler$Key:Xamarin.KotlinX.Coroutines.CoroutineExceptionHandlerKey", "kotlinx/coroutines/CoroutineExceptionHandlerImplKt:Xamarin.KotlinX.Coroutines.CoroutineExceptionHandlerImplKt", "kotlinx/coroutines/CoroutineExceptionHandlerKt:Xamarin.KotlinX.Coroutines.CoroutineExceptionHandlerKt", "kotlinx/coroutines/CoroutineName:Xamarin.KotlinX.Coroutines.CoroutineName", "kotlinx/coroutines/CoroutineName$Key:Xamarin.KotlinX.Coroutines.CoroutineName/Key",
					"kotlinx/coroutines/CoroutineScopeKt:Xamarin.KotlinX.Coroutines.CoroutineScopeKt", "kotlinx/coroutines/CoroutineStart:Xamarin.KotlinX.Coroutines.CoroutineStart", "kotlinx/coroutines/CoroutineStart$WhenMappings:Xamarin.KotlinX.Coroutines.CoroutineStart/WhenMappings", "kotlinx/coroutines/DebugKt:Xamarin.KotlinX.Coroutines.DebugKt", "kotlinx/coroutines/DebugStringsKt:Xamarin.KotlinX.Coroutines.DebugStringsKt", "kotlinx/coroutines/DefaultExecutorKt:Xamarin.KotlinX.Coroutines.DefaultExecutorKt", "kotlinx/coroutines/Delay$DefaultImpls:Xamarin.KotlinX.Coroutines.DelayDefaultImpls", "kotlinx/coroutines/DelayKt:Xamarin.KotlinX.Coroutines.DelayKt", "kotlinx/coroutines/DispatchedTaskKt:Xamarin.KotlinX.Coroutines.DispatchedTaskKt", "kotlinx/coroutines/Dispatchers:Xamarin.KotlinX.Coroutines.Dispatchers",
					"kotlinx/coroutines/DispatchersKt:Xamarin.KotlinX.Coroutines.DispatchersKt", "kotlinx/coroutines/EventLoopKt:Xamarin.KotlinX.Coroutines.EventLoopKt", "kotlinx/coroutines/EventLoop_commonKt:Xamarin.KotlinX.Coroutines.EventLoop_commonKt", "kotlinx/coroutines/ExceptionsKt:Xamarin.KotlinX.Coroutines.ExceptionsKt", "kotlinx/coroutines/ExecutorCoroutineDispatcher:Xamarin.KotlinX.Coroutines.ExecutorCoroutineDispatcher", "kotlinx/coroutines/ExecutorsKt:Xamarin.KotlinX.Coroutines.ExecutorsKt", "kotlinx/coroutines/GlobalScope:Xamarin.KotlinX.Coroutines.GlobalScope", "kotlinx/coroutines/InterruptibleKt:Xamarin.KotlinX.Coroutines.InterruptibleKt", "kotlinx/coroutines/JobKt:Xamarin.KotlinX.Coroutines.JobKt", "kotlinx/coroutines/JobSupport:Xamarin.KotlinX.Coroutines.JobSupport",
					"kotlinx/coroutines/JobSupportKt:Xamarin.KotlinX.Coroutines.JobSupportKt", "kotlinx/coroutines/MainCoroutineDispatcher:Xamarin.KotlinX.Coroutines.MainCoroutineDispatcher", "kotlinx/coroutines/NonCancellable:Xamarin.KotlinX.Coroutines.NonCancellable", "kotlinx/coroutines/NonDisposableHandle:Xamarin.KotlinX.Coroutines.NonDisposableHandle", "kotlinx/coroutines/RunnableKt:Xamarin.KotlinX.Coroutines.RunnableKt", "kotlinx/coroutines/SchedulerTaskKt:Xamarin.KotlinX.Coroutines.SchedulerTaskKt", "kotlinx/coroutines/SupervisorKt:Xamarin.KotlinX.Coroutines.SupervisorKt", "kotlinx/coroutines/ThreadContextElement$DefaultImpls:Xamarin.KotlinX.Coroutines.ThreadContextElementDefaultImpls", "kotlinx/coroutines/ThreadContextElementKt:Xamarin.KotlinX.Coroutines.ThreadContextElementKt", "kotlinx/coroutines/ThreadPoolDispatcherKt:Xamarin.KotlinX.Coroutines.ThreadPoolDispatcherKt",
					"kotlinx/coroutines/TimeoutCancellationException:Xamarin.KotlinX.Coroutines.TimeoutCancellationException", "kotlinx/coroutines/TimeoutKt:Xamarin.KotlinX.Coroutines.TimeoutKt", "kotlinx/coroutines/YieldKt:Xamarin.KotlinX.Coroutines.YieldKt"
				};
			}
			return Lookup(package_kotlinx_coroutines_mappings, klass);
		}

		private static Type? lookup_kotlinx_coroutines_channels_package(string klass)
		{
			if (package_kotlinx_coroutines_channels_mappings == null)
			{
				package_kotlinx_coroutines_channels_mappings = new string[16]
				{
					"kotlinx/coroutines/channels/AbstractChannelKt:Xamarin.KotlinX.Coroutines.Channels.AbstractChannelKt", "kotlinx/coroutines/channels/ActorKt:Xamarin.KotlinX.Coroutines.Channels.ActorKt", "kotlinx/coroutines/channels/BroadcastChannelKt:Xamarin.KotlinX.Coroutines.Channels.BroadcastChannelKt", "kotlinx/coroutines/channels/BroadcastKt:Xamarin.KotlinX.Coroutines.Channels.BroadcastKt", "kotlinx/coroutines/channels/BufferOverflow:Xamarin.KotlinX.Coroutines.Channels.BufferOverflow", "kotlinx/coroutines/channels/ChannelIterator$DefaultImpls:Xamarin.KotlinX.Coroutines.Channels.ChannelIteratorDefaultImpls", "kotlinx/coroutines/channels/ChannelKt:Xamarin.KotlinX.Coroutines.Channels.ChannelKt", "kotlinx/coroutines/channels/ChannelResult:Xamarin.KotlinX.Coroutines.Channels.ChannelResult", "kotlinx/coroutines/channels/ChannelResult$Companion:Xamarin.KotlinX.Coroutines.Channels.ChannelResult/Companion", "kotlinx/coroutines/channels/ChannelsKt:Xamarin.KotlinX.Coroutines.Channels.ChannelsKt",
					"kotlinx/coroutines/channels/ClosedReceiveChannelException:Xamarin.KotlinX.Coroutines.Channels.ClosedReceiveChannelException", "kotlinx/coroutines/channels/ClosedSendChannelException:Xamarin.KotlinX.Coroutines.Channels.ClosedSendChannelException", "kotlinx/coroutines/channels/ConflatedBroadcastChannel:Xamarin.KotlinX.Coroutines.Channels.ConflatedBroadcastChannel", "kotlinx/coroutines/channels/ProduceKt:Xamarin.KotlinX.Coroutines.Channels.ProduceKt", "kotlinx/coroutines/channels/TickerChannelsKt:Xamarin.KotlinX.Coroutines.Channels.TickerChannelsKt", "kotlinx/coroutines/channels/TickerMode:Xamarin.KotlinX.Coroutines.Channels.TickerMode"
				};
			}
			return Lookup(package_kotlinx_coroutines_channels_mappings, klass);
		}

		private static Type? lookup_kotlinx_coroutines_flow_package(string klass)
		{
			if (package_kotlinx_coroutines_flow_mappings == null)
			{
				package_kotlinx_coroutines_flow_mappings = new string[7] { "kotlinx/coroutines/flow/FlowKt:Xamarin.KotlinX.Coroutines.Flow.FlowKt", "kotlinx/coroutines/flow/LintKt:Xamarin.KotlinX.Coroutines.Flow.LintKt", "kotlinx/coroutines/flow/SharedFlowKt:Xamarin.KotlinX.Coroutines.Flow.SharedFlowKt", "kotlinx/coroutines/flow/SharingCommand:Xamarin.KotlinX.Coroutines.Flow.SharingCommand", "kotlinx/coroutines/flow/SharingStarted$Companion:Xamarin.KotlinX.Coroutines.Flow.SharingStartedCompanion", "kotlinx/coroutines/flow/SharingStartedKt:Xamarin.KotlinX.Coroutines.Flow.SharingStartedKt", "kotlinx/coroutines/flow/StateFlowKt:Xamarin.KotlinX.Coroutines.Flow.StateFlowKt" };
			}
			return Lookup(package_kotlinx_coroutines_flow_mappings, klass);
		}

		private static Type? lookup_kotlinx_coroutines_intrinsics_package(string klass)
		{
			if (package_kotlinx_coroutines_intrinsics_mappings == null)
			{
				package_kotlinx_coroutines_intrinsics_mappings = new string[2] { "kotlinx/coroutines/intrinsics/CancellableKt:Xamarin.KotlinX.Coroutines.Intrinsics.CancellableKt", "kotlinx/coroutines/intrinsics/UndispatchedKt:Xamarin.KotlinX.Coroutines.Intrinsics.UndispatchedKt" };
			}
			return Lookup(package_kotlinx_coroutines_intrinsics_mappings, klass);
		}

		private static Type? lookup_kotlinx_coroutines_scheduling_package(string klass)
		{
			if (package_kotlinx_coroutines_scheduling_mappings == null)
			{
				package_kotlinx_coroutines_scheduling_mappings = new string[3] { "kotlinx/coroutines/scheduling/CoroutineSchedulerKt:Xamarin.KotlinX.Coroutines.Scheduling.CoroutineSchedulerKt", "kotlinx/coroutines/scheduling/TasksKt:Xamarin.KotlinX.Coroutines.Scheduling.TasksKt", "kotlinx/coroutines/scheduling/WorkQueueKt:Xamarin.KotlinX.Coroutines.Scheduling.WorkQueueKt" };
			}
			return Lookup(package_kotlinx_coroutines_scheduling_mappings, klass);
		}

		private static Type? lookup_kotlinx_coroutines_selects_package(string klass)
		{
			if (package_kotlinx_coroutines_selects_mappings == null)
			{
				package_kotlinx_coroutines_selects_mappings = new string[3] { "kotlinx/coroutines/selects/SelectKt:Xamarin.KotlinX.Coroutines.Selects.SelectKt", "kotlinx/coroutines/selects/SelectUnbiasedKt:Xamarin.KotlinX.Coroutines.Selects.SelectUnbiasedKt", "kotlinx/coroutines/selects/WhileSelectKt:Xamarin.KotlinX.Coroutines.Selects.WhileSelectKt" };
			}
			return Lookup(package_kotlinx_coroutines_selects_mappings, klass);
		}

		private static Type? lookup_kotlinx_coroutines_sync_package(string klass)
		{
			if (package_kotlinx_coroutines_sync_mappings == null)
			{
				package_kotlinx_coroutines_sync_mappings = new string[2] { "kotlinx/coroutines/sync/MutexKt:Xamarin.KotlinX.Coroutines.Sync.MutexKt", "kotlinx/coroutines/sync/SemaphoreKt:Xamarin.KotlinX.Coroutines.Sync.SemaphoreKt" };
			}
			return Lookup(package_kotlinx_coroutines_sync_mappings, klass);
		}
	}
}
