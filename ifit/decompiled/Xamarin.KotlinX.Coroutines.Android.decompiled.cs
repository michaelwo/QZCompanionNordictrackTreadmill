using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.OS;
using Android.Runtime;
using Java.Interop;
using Java.Lang;
using Kotlin.Coroutines;
using Kotlin.Jvm.Internal;
using Microsoft.CodeAnalysis;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: NamespaceMapping(Java = "kotlinx.coroutines.android", Managed = "Xamarin.KotlinX.Coroutines.CoroutinesAndroid")]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.KotlinX.Coroutines.Android")]
[assembly: AssemblyTitle("Xamarin.KotlinX.Coroutines.Android")]
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
internal delegate IntPtr _JniMarshal_PPJL_L(IntPtr jnienv, IntPtr klass, long p0, IntPtr p1);
internal delegate void _JniMarshal_PPJL_V(IntPtr jnienv, IntPtr klass, long p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPJLL_L(IntPtr jnienv, IntPtr klass, long p0, IntPtr p1, IntPtr p2);
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
namespace Xamarin.KotlinX.Coroutines.CoroutinesAndroid
{
	[Register("kotlinx/coroutines/android/HandlerDispatcher", DoNotGenerateAcw = true)]
	public abstract class HandlerDispatcher : MainCoroutineDispatcher, IDelay, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/android/HandlerDispatcher", typeof(HandlerDispatcher));

		private static Delegate? cb_delay_JLkotlin_coroutines_Continuation_;

		private static Delegate? cb_invokeOnTimeout_JLjava_lang_Runnable_Lkotlin_coroutines_CoroutineContext_;

		private static Delegate? cb_scheduleResumeAfterDelay_JLkotlinx_coroutines_CancellableContinuation_;

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

		protected HandlerDispatcher(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Lkotlin/jvm/internal/DefaultConstructorMarker;)V", "")]
		public unsafe HandlerDispatcher(DefaultConstructorMarker? _constructor_marker)
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
		private static IntPtr n_Delay_JLkotlin_coroutines_Continuation_(IntPtr jnienv, IntPtr native__this, long time, IntPtr native__completion)
		{
			HandlerDispatcher handlerDispatcher = Java.Lang.Object.GetObject<HandlerDispatcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IContinuation completion = Java.Lang.Object.GetObject<IContinuation>(native__completion, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(handlerDispatcher.Delay(time, completion));
		}

		[Obsolete("deprecated")]
		[Register("delay", "(JLkotlin/coroutines/Continuation;)Ljava/lang/Object;", "GetDelay_JLkotlin_coroutines_Continuation_Handler")]
		public unsafe virtual Java.Lang.Object? Delay(long time, IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(time);
				ptr[1] = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.InstanceMethods.InvokeVirtualObjectMethod("delay.(JLkotlin/coroutines/Continuation;)Ljava/lang/Object;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_completion);
			}
		}

		private static Delegate GetInvokeOnTimeout_JLjava_lang_Runnable_Lkotlin_coroutines_CoroutineContext_Handler()
		{
			if ((object)cb_invokeOnTimeout_JLjava_lang_Runnable_Lkotlin_coroutines_CoroutineContext_ == null)
			{
				cb_invokeOnTimeout_JLjava_lang_Runnable_Lkotlin_coroutines_CoroutineContext_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJLL_L(n_InvokeOnTimeout_JLjava_lang_Runnable_Lkotlin_coroutines_CoroutineContext_));
			}
			return cb_invokeOnTimeout_JLjava_lang_Runnable_Lkotlin_coroutines_CoroutineContext_;
		}

		private static IntPtr n_InvokeOnTimeout_JLjava_lang_Runnable_Lkotlin_coroutines_CoroutineContext_(IntPtr jnienv, IntPtr native__this, long timeMillis, IntPtr native_block, IntPtr native_context)
		{
			HandlerDispatcher handlerDispatcher = Java.Lang.Object.GetObject<HandlerDispatcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable block = Java.Lang.Object.GetObject<IRunnable>(native_block, JniHandleOwnership.DoNotTransfer);
			ICoroutineContext context = Java.Lang.Object.GetObject<ICoroutineContext>(native_context, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(handlerDispatcher.InvokeOnTimeout(timeMillis, block, context));
		}

		[Register("invokeOnTimeout", "(JLjava/lang/Runnable;Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/DisposableHandle;", "GetInvokeOnTimeout_JLjava_lang_Runnable_Lkotlin_coroutines_CoroutineContext_Handler")]
		public unsafe virtual IDisposableHandle InvokeOnTimeout(long timeMillis, IRunnable block, ICoroutineContext context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(timeMillis);
				ptr[1] = new JniArgumentValue((block == null) ? IntPtr.Zero : ((Java.Lang.Object)block).Handle);
				ptr[2] = new JniArgumentValue((context == null) ? IntPtr.Zero : ((Java.Lang.Object)context).Handle);
				return Java.Lang.Object.GetObject<IDisposableHandle>(_members.InstanceMethods.InvokeVirtualObjectMethod("invokeOnTimeout.(JLjava/lang/Runnable;Lkotlin/coroutines/CoroutineContext;)Lkotlinx/coroutines/DisposableHandle;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(block);
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetScheduleResumeAfterDelay_JLkotlinx_coroutines_CancellableContinuation_Handler()
		{
			if ((object)cb_scheduleResumeAfterDelay_JLkotlinx_coroutines_CancellableContinuation_ == null)
			{
				cb_scheduleResumeAfterDelay_JLkotlinx_coroutines_CancellableContinuation_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPJL_V(n_ScheduleResumeAfterDelay_JLkotlinx_coroutines_CancellableContinuation_));
			}
			return cb_scheduleResumeAfterDelay_JLkotlinx_coroutines_CancellableContinuation_;
		}

		private static void n_ScheduleResumeAfterDelay_JLkotlinx_coroutines_CancellableContinuation_(IntPtr jnienv, IntPtr native__this, long timeMillis, IntPtr native_continuation)
		{
			HandlerDispatcher handlerDispatcher = Java.Lang.Object.GetObject<HandlerDispatcher>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			ICancellableContinuation continuation = Java.Lang.Object.GetObject<ICancellableContinuation>(native_continuation, JniHandleOwnership.DoNotTransfer);
			handlerDispatcher.ScheduleResumeAfterDelay(timeMillis, continuation);
		}

		[Register("scheduleResumeAfterDelay", "(JLkotlinx/coroutines/CancellableContinuation;)V", "GetScheduleResumeAfterDelay_JLkotlinx_coroutines_CancellableContinuation_Handler")]
		public abstract void ScheduleResumeAfterDelay(long timeMillis, ICancellableContinuation continuation);
	}
	[Register("kotlinx/coroutines/android/HandlerDispatcher", DoNotGenerateAcw = true)]
	internal class HandlerDispatcherInvoker : HandlerDispatcher
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/android/HandlerDispatcher", typeof(HandlerDispatcherInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override MainCoroutineDispatcher Immediate
		{
			[Register("getImmediate", "()Lkotlinx/coroutines/android/HandlerDispatcher;", "GetGetImmediateHandler")]
			get
			{
				return Java.Lang.Object.GetObject<MainCoroutineDispatcher>(_members.InstanceMethods.InvokeAbstractObjectMethod("getImmediate.()Lkotlinx/coroutines/android/HandlerDispatcher;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public HandlerDispatcherInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("scheduleResumeAfterDelay", "(JLkotlinx/coroutines/CancellableContinuation;)V", "GetScheduleResumeAfterDelay_JLkotlinx_coroutines_CancellableContinuation_Handler")]
		public unsafe override void ScheduleResumeAfterDelay(long timeMillis, ICancellableContinuation continuation)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(timeMillis);
				ptr[1] = new JniArgumentValue((continuation == null) ? IntPtr.Zero : ((Java.Lang.Object)continuation).Handle);
				_members.InstanceMethods.InvokeAbstractVoidMethod("scheduleResumeAfterDelay.(JLkotlinx/coroutines/CancellableContinuation;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(continuation);
			}
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
	[Register("kotlinx/coroutines/android/HandlerDispatcherKt", DoNotGenerateAcw = true)]
	public sealed class HandlerDispatcherKt : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("kotlinx/coroutines/android/HandlerDispatcherKt", typeof(HandlerDispatcherKt));

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

		internal HandlerDispatcherKt(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("awaitFrame", "(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "")]
		public unsafe static Java.Lang.Object? AwaitFrame(IContinuation _completion)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((_completion == null) ? IntPtr.Zero : ((Java.Lang.Object)_completion).Handle);
				return Java.Lang.Object.GetObject<Java.Lang.Object>(_members.StaticMethods.InvokeObjectMethod("awaitFrame.(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(_completion);
			}
		}

		[Register("from", "(Landroid/os/Handler;)Lkotlinx/coroutines/android/HandlerDispatcher;", "")]
		public unsafe static HandlerDispatcher From(Handler obj)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<HandlerDispatcher>(_members.StaticMethods.InvokeObjectMethod("from.(Landroid/os/Handler;)Lkotlinx/coroutines/android/HandlerDispatcher;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(obj);
			}
		}

		[Register("from", "(Landroid/os/Handler;Ljava/lang/String;)Lkotlinx/coroutines/android/HandlerDispatcher;", "")]
		public unsafe static HandlerDispatcher From(Handler obj, string? name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(obj?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<HandlerDispatcher>(_members.StaticMethods.InvokeObjectMethod("from.(Landroid/os/Handler;Ljava/lang/String;)Lkotlinx/coroutines/android/HandlerDispatcher;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(obj);
			}
		}
	}
}
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		private static string[]? package_kotlinx_coroutines_android_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[1] { "kotlinx/coroutines/android" }, new Converter<string, Type>[1] { lookup_kotlinx_coroutines_android_package });
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

		private static Type? lookup_kotlinx_coroutines_android_package(string klass)
		{
			if (package_kotlinx_coroutines_android_mappings == null)
			{
				package_kotlinx_coroutines_android_mappings = new string[2] { "kotlinx/coroutines/android/HandlerDispatcher:Xamarin.KotlinX.Coroutines.CoroutinesAndroid.HandlerDispatcher", "kotlinx/coroutines/android/HandlerDispatcherKt:Xamarin.KotlinX.Coroutines.CoroutinesAndroid.HandlerDispatcherKt" };
			}
			return Lookup(package_kotlinx_coroutines_android_mappings, klass);
		}
	}
}
