using System;
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
[assembly: NamespaceMapping(Java = "com.google.common.util.concurrent.internal", Managed = "Google.Common.Util.Concurrent.Internal")]
[assembly: TargetFramework("MonoAndroid,Version=v5.0", FrameworkDisplayName = "Xamarin.Android v5.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.Google.Guava.FailureAccess")]
[assembly: AssemblyTitle("Xamarin.Google.Guava.FailureAccess")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		private static string[] package_com_google_common_util_concurrent_internal_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[1] { "com/google/common/util/concurrent/internal" }, new Converter<string, Type>[1] { lookup_com_google_common_util_concurrent_internal_package });
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

		private static Type lookup_com_google_common_util_concurrent_internal_package(string klass)
		{
			if (package_com_google_common_util_concurrent_internal_mappings == null)
			{
				package_com_google_common_util_concurrent_internal_mappings = new string[2] { "com/google/common/util/concurrent/internal/InternalFutureFailureAccess:Google.Common.Util.Concurrent.Internal.InternalFutureFailureAccess", "com/google/common/util/concurrent/internal/InternalFutures:Google.Common.Util.Concurrent.Internal.InternalFutures" };
			}
			return Lookup(package_com_google_common_util_concurrent_internal_mappings, klass);
		}
	}
}
namespace Google.Common.Util.Concurrent.Internal
{
	[Register("com/google/common/util/concurrent/internal/InternalFutureFailureAccess", DoNotGenerateAcw = true)]
	public abstract class InternalFutureFailureAccess : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/common/util/concurrent/internal/InternalFutureFailureAccess", typeof(InternalFutureFailureAccess));

		private static Delegate cb_tryInternalFastPathGetFailure;

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		protected InternalFutureFailureAccess(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		protected unsafe InternalFutureFailureAccess()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetTryInternalFastPathGetFailureHandler()
		{
			if ((object)cb_tryInternalFastPathGetFailure == null)
			{
				cb_tryInternalFastPathGetFailure = JNINativeWrapper.CreateDelegate(new Func<IntPtr, IntPtr, IntPtr>(n_TryInternalFastPathGetFailure));
			}
			return cb_tryInternalFastPathGetFailure;
		}

		private static IntPtr n_TryInternalFastPathGetFailure(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<InternalFutureFailureAccess>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TryInternalFastPathGetFailure());
		}

		[Register("tryInternalFastPathGetFailure", "()Ljava/lang/Throwable;", "GetTryInternalFastPathGetFailureHandler")]
		protected abstract Throwable TryInternalFastPathGetFailure();
	}
	[Register("com/google/common/util/concurrent/internal/InternalFutureFailureAccess", DoNotGenerateAcw = true)]
	internal class InternalFutureFailureAccessInvoker : InternalFutureFailureAccess
	{
		internal new static readonly JniPeerMembers _members = new XAPeerMembers("com/google/common/util/concurrent/internal/InternalFutureFailureAccess", typeof(InternalFutureFailureAccessInvoker));

		public override JniPeerMembers JniPeerMembers => _members;

		protected override Type ThresholdType => _members.ManagedPeerType;

		public InternalFutureFailureAccessInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("tryInternalFastPathGetFailure", "()Ljava/lang/Throwable;", "GetTryInternalFastPathGetFailureHandler")]
		protected unsafe override Throwable TryInternalFastPathGetFailure()
		{
			return Java.Lang.Object.GetObject<Throwable>(_members.InstanceMethods.InvokeAbstractObjectMethod("tryInternalFastPathGetFailure.()Ljava/lang/Throwable;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("com/google/common/util/concurrent/internal/InternalFutures", DoNotGenerateAcw = true)]
	public sealed class InternalFutures : Java.Lang.Object
	{
		internal static readonly JniPeerMembers _members = new XAPeerMembers("com/google/common/util/concurrent/internal/InternalFutures", typeof(InternalFutures));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		public override JniPeerMembers JniPeerMembers => _members;

		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		protected override Type ThresholdType => _members.ManagedPeerType;

		internal InternalFutures(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("tryInternalFastPathGetFailure", "(Lcom/google/common/util/concurrent/internal/InternalFutureFailureAccess;)Ljava/lang/Throwable;", "")]
		public unsafe static Throwable TryInternalFastPathGetFailure(InternalFutureFailureAccess future)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(future?.Handle ?? IntPtr.Zero);
			Throwable result = Java.Lang.Object.GetObject<Throwable>(_members.StaticMethods.InvokeObjectMethod("tryInternalFastPathGetFailure.(Lcom/google/common/util/concurrent/internal/InternalFutureFailureAccess;)Ljava/lang/Throwable;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			GC.KeepAlive(future);
			return result;
		}
	}
}
