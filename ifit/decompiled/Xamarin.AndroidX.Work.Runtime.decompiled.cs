using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using Android;
using Android.App;
using Android.Content;
using Android.Net;
using Android.Runtime;
using AndroidX.Arch.Core.Util;
using AndroidX.Lifecycle;
using AndroidX.Work.Impl.Model;
using AndroidX.Work.Impl.Utils.TaskExecutor;
using Google.Common.Util.Concurrent;
using Java.Interop;
using Java.Lang;
using Java.Util;
using Java.Util.Concurrent;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyMetadata("BUILD_COMMIT", "d80fb7c4fd3b511ad9996ea45d1ea5241a631ca1")]
[assembly: AssemblyMetadata("BUILD_NUMBER", "20211026.1")]
[assembly: AssemblyMetadata("BUILD_TIMESTAMP", "10/26/2021 8:44:04 AM")]
[assembly: LinkerSafe]
[assembly: AssemblyMetadata("IsTrimmable", "True")]
[assembly: NamespaceMapping(Java = "androidx.work", Managed = "AndroidX.Work")]
[assembly: NamespaceMapping(Java = "androidx.work.impl.background.greedy", Managed = "AndroidX.Work.Impl.Background.Greedy")]
[assembly: NamespaceMapping(Java = "androidx.work.impl.background.systemjob", Managed = "AndroidX.Work.Impl.Background.SystemJob")]
[assembly: NamespaceMapping(Java = "androidx.work.impl.constraints", Managed = "AndroidX.Work.Impl.Constraints")]
[assembly: NamespaceMapping(Java = "androidx.work.impl.constraints.controllers", Managed = "AndroidX.Work.Impl.Constraints.Controllers")]
[assembly: NamespaceMapping(Java = "androidx.work.impl.constraints.trackers", Managed = "AndroidX.Work.Impl.Constraints.Trackers")]
[assembly: NamespaceMapping(Java = "androidx.work.impl.diagnostics", Managed = "AndroidX.Work.Impl.Diagnostics")]
[assembly: NamespaceMapping(Java = "androidx.work.impl.foreground", Managed = "AndroidX.Work.Impl.Foreground")]
[assembly: NamespaceMapping(Java = "androidx.work.impl.model", Managed = "AndroidX.Work.Impl.Model")]
[assembly: NamespaceMapping(Java = "androidx.work.impl.utils", Managed = "AndroidX.Work.Impl.Utils")]
[assembly: NamespaceMapping(Java = "androidx.work.impl.utils.futures", Managed = "AndroidX.Work.Impl.Utils.Futures")]
[assembly: NamespaceMapping(Java = "androidx.work.impl.utils.taskexecutor", Managed = "AndroidX.Work.Impl.Utils.TaskExecutor")]
[assembly: NamespaceMapping(Java = "androidx.work.impl.workers", Managed = "AndroidX.Work.Impl.Workers")]
[assembly: NamespaceMapping(Java = "androidx.work.multiprocess", Managed = "AndroidX.Work.MultiProcess")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Xamarin.Android bindings for AndroidX - work-runtime  artifact=androidx.work:work-runtime artifact_versioned=androidx.work:work-runtime:2.7.0")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Xamarin.AndroidX.Work.Runtime")]
[assembly: AssemblyTitle("Xamarin.AndroidX.Work.Runtime")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/AndroidX.git")]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
internal delegate IntPtr _JniMarshal_PP_L(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PP_V(IntPtr jnienv, IntPtr klass);
internal delegate bool _JniMarshal_PP_Z(IntPtr jnienv, IntPtr klass);
internal delegate void _JniMarshal_PPJL_V(IntPtr jnienv, IntPtr klass, long p0, IntPtr p1);
internal delegate IntPtr _JniMarshal_PPL_L(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate void _JniMarshal_PPL_V(IntPtr jnienv, IntPtr klass, IntPtr p0);
internal delegate IntPtr _JniMarshal_PPLLL_L(IntPtr jnienv, IntPtr klass, IntPtr p0, IntPtr p1, IntPtr p2);
internal delegate void _JniMarshal_PPZ_V(IntPtr jnienv, IntPtr klass, bool p0);
namespace AndroidX.Work
{
	[Register("androidx/work/OneTimeWorkRequest", DoNotGenerateAcw = true)]
	public sealed class OneTimeWorkRequest : WorkRequest
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/OneTimeWorkRequest", typeof(OneTimeWorkRequest));

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

		public static OneTimeWorkRequest From<TWorker>() where TWorker : Worker
		{
			return From(typeof(TWorker));
		}

		public static OneTimeWorkRequest From(Type type)
		{
			return From(Class.FromType(type));
		}

		internal OneTimeWorkRequest(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("from", "(Ljava/lang/Class;)Landroidx/work/OneTimeWorkRequest;", "")]
		public unsafe static OneTimeWorkRequest From(Class workerClass)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(workerClass?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<OneTimeWorkRequest>(_members.StaticMethods.InvokeObjectMethod("from.(Ljava/lang/Class;)Landroidx/work/OneTimeWorkRequest;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(workerClass);
			}
		}

		[Register("from", "(Ljava/util/List;)Ljava/util/List;", "")]
		public unsafe static IList<OneTimeWorkRequest> From(IList<Class> workerClasses)
		{
			IntPtr intPtr = JavaList<Class>.ToLocalJniHandle(workerClasses);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JavaList<OneTimeWorkRequest>.FromJniHandle(_members.StaticMethods.InvokeObjectMethod("from.(Ljava/util/List;)Ljava/util/List;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(workerClasses);
			}
		}
	}
	[Register("androidx/work/PeriodicWorkRequest", DoNotGenerateAcw = true)]
	public sealed class PeriodicWorkRequest : WorkRequest
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/PeriodicWorkRequest", typeof(PeriodicWorkRequest));

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

		internal PeriodicWorkRequest(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("androidx/work/Constraints", DoNotGenerateAcw = true)]
	public sealed class Constraints : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/Constraints", typeof(Constraints));

		[Register("NONE")]
		public static Constraints None => Java.Lang.Object.GetObject<Constraints>(_members.StaticFields.GetObjectValue("NONE.Landroidx/work/Constraints;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe ContentUriTriggers ContentUriTriggers
		{
			[Register("getContentUriTriggers", "()Landroidx/work/ContentUriTriggers;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ContentUriTriggers>(_members.InstanceMethods.InvokeAbstractObjectMethod("getContentUriTriggers.()Landroidx/work/ContentUriTriggers;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setContentUriTriggers", "(Landroidx/work/ContentUriTriggers;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setContentUriTriggers.(Landroidx/work/ContentUriTriggers;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe bool HasContentUriTriggers
		{
			[Register("hasContentUriTriggers", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasContentUriTriggers.()Z", this, null);
			}
		}

		public unsafe NetworkType RequiredNetworkType
		{
			[Register("getRequiredNetworkType", "()Landroidx/work/NetworkType;", "")]
			get
			{
				return Java.Lang.Object.GetObject<NetworkType>(_members.InstanceMethods.InvokeAbstractObjectMethod("getRequiredNetworkType.()Landroidx/work/NetworkType;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
			[Register("setRequiredNetworkType", "(Landroidx/work/NetworkType;)V", "")]
			set
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(value?.Handle ?? IntPtr.Zero);
					_members.InstanceMethods.InvokeAbstractVoidMethod("setRequiredNetworkType.(Landroidx/work/NetworkType;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(value);
				}
			}
		}

		public unsafe long TriggerContentUpdateDelay
		{
			[Register("getTriggerContentUpdateDelay", "()J", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt64Method("getTriggerContentUpdateDelay.()J", this, null);
			}
			[Register("setTriggerContentUpdateDelay", "(J)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setTriggerContentUpdateDelay.(J)V", this, ptr);
			}
		}

		public unsafe long TriggerMaxContentDelay
		{
			[Register("getTriggerMaxContentDelay", "()J", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt64Method("getTriggerMaxContentDelay.()J", this, null);
			}
			[Register("setTriggerMaxContentDelay", "(J)V", "")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeAbstractVoidMethod("setTriggerMaxContentDelay.(J)V", this, ptr);
			}
		}

		internal Constraints(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe Constraints()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register(".ctor", "(Landroidx/work/Constraints;)V", "")]
		public unsafe Constraints(Constraints other)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/work/Constraints;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/work/Constraints;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(other);
			}
		}

		[Register("requiresBatteryNotLow", "()Z", "")]
		public unsafe bool RequiresBatteryNotLow()
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("requiresBatteryNotLow.()Z", this, null);
		}

		[Register("requiresCharging", "()Z", "")]
		public unsafe bool RequiresCharging()
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("requiresCharging.()Z", this, null);
		}

		[Register("requiresDeviceIdle", "()Z", "")]
		public unsafe bool RequiresDeviceIdle()
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("requiresDeviceIdle.()Z", this, null);
		}

		[Register("requiresStorageNotLow", "()Z", "")]
		public unsafe bool RequiresStorageNotLow()
		{
			return _members.InstanceMethods.InvokeAbstractBooleanMethod("requiresStorageNotLow.()Z", this, null);
		}

		[Register("setRequiresBatteryNotLow", "(Z)V", "")]
		public unsafe void SetRequiresBatteryNotLow(bool requiresBatteryNotLow)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(requiresBatteryNotLow);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setRequiresBatteryNotLow.(Z)V", this, ptr);
		}

		[Register("setRequiresCharging", "(Z)V", "")]
		public unsafe void SetRequiresCharging(bool requiresCharging)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(requiresCharging);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setRequiresCharging.(Z)V", this, ptr);
		}

		[Register("setRequiresDeviceIdle", "(Z)V", "")]
		public unsafe void SetRequiresDeviceIdle(bool requiresDeviceIdle)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(requiresDeviceIdle);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setRequiresDeviceIdle.(Z)V", this, ptr);
		}

		[Register("setRequiresStorageNotLow", "(Z)V", "")]
		public unsafe void SetRequiresStorageNotLow(bool requiresStorageNotLow)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(requiresStorageNotLow);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setRequiresStorageNotLow.(Z)V", this, ptr);
		}
	}
	[Register("androidx/work/BackoffPolicy", DoNotGenerateAcw = true)]
	public sealed class BackoffPolicy : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/BackoffPolicy", typeof(BackoffPolicy));

		[Register("EXPONENTIAL")]
		public static BackoffPolicy Exponential => Java.Lang.Object.GetObject<BackoffPolicy>(_members.StaticFields.GetObjectValue("EXPONENTIAL.Landroidx/work/BackoffPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("LINEAR")]
		public static BackoffPolicy Linear => Java.Lang.Object.GetObject<BackoffPolicy>(_members.StaticFields.GetObjectValue("LINEAR.Landroidx/work/BackoffPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal BackoffPolicy(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/work/BackoffPolicy;", "")]
		public unsafe static BackoffPolicy ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<BackoffPolicy>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/work/BackoffPolicy;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Landroidx/work/BackoffPolicy;", "")]
		public unsafe static BackoffPolicy[] Values()
		{
			return (BackoffPolicy[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/work/BackoffPolicy;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(BackoffPolicy));
		}
	}
	[Register("androidx/work/Configuration", DoNotGenerateAcw = true)]
	public sealed class Configuration : Java.Lang.Object
	{
		[Register("androidx/work/Configuration$Builder", DoNotGenerateAcw = true)]
		public sealed class Builder : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/Configuration$Builder", typeof(Builder));

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

			internal Builder(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe Builder()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}

			[Register(".ctor", "(Landroidx/work/Configuration;)V", "")]
			public unsafe Builder(Configuration configuration)
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (base.Handle != IntPtr.Zero)
				{
					return;
				}
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(configuration?.Handle ?? IntPtr.Zero);
					SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/work/Configuration;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("(Landroidx/work/Configuration;)V", this, ptr);
				}
				finally
				{
					GC.KeepAlive(configuration);
				}
			}

			[Register("build", "()Landroidx/work/Configuration;", "")]
			public unsafe Configuration Build()
			{
				return Java.Lang.Object.GetObject<Configuration>(_members.InstanceMethods.InvokeAbstractObjectMethod("build.()Landroidx/work/Configuration;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setDefaultProcessName", "(Ljava/lang/String;)Landroidx/work/Configuration$Builder;", "")]
			public unsafe Builder SetDefaultProcessName(string processName)
			{
				IntPtr intPtr = JNIEnv.NewString(processName);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setDefaultProcessName.(Ljava/lang/String;)Landroidx/work/Configuration$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("setExecutor", "(Ljava/util/concurrent/Executor;)Landroidx/work/Configuration$Builder;", "")]
			public unsafe Builder SetExecutor(IExecutor executor)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setExecutor.(Ljava/util/concurrent/Executor;)Landroidx/work/Configuration$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(executor);
				}
			}

			[Register("setInitializationExceptionHandler", "(Landroidx/work/InitializationExceptionHandler;)Landroidx/work/Configuration$Builder;", "")]
			public unsafe Builder SetInitializationExceptionHandler(IInitializationExceptionHandler exceptionHandler)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((exceptionHandler == null) ? IntPtr.Zero : ((Java.Lang.Object)exceptionHandler).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setInitializationExceptionHandler.(Landroidx/work/InitializationExceptionHandler;)Landroidx/work/Configuration$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(exceptionHandler);
				}
			}

			[Register("setInputMergerFactory", "(Landroidx/work/InputMergerFactory;)Landroidx/work/Configuration$Builder;", "")]
			public unsafe Builder SetInputMergerFactory(InputMergerFactory inputMergerFactory)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(inputMergerFactory?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setInputMergerFactory.(Landroidx/work/InputMergerFactory;)Landroidx/work/Configuration$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(inputMergerFactory);
				}
			}

			[Register("setJobSchedulerJobIdRange", "(II)Landroidx/work/Configuration$Builder;", "")]
			public unsafe Builder SetJobSchedulerJobIdRange(int minJobSchedulerId, int maxJobSchedulerId)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(minJobSchedulerId);
				ptr[1] = new JniArgumentValue(maxJobSchedulerId);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setJobSchedulerJobIdRange.(II)Landroidx/work/Configuration$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setMaxSchedulerLimit", "(I)Landroidx/work/Configuration$Builder;", "")]
			public unsafe Builder SetMaxSchedulerLimit(int maxSchedulerLimit)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(maxSchedulerLimit);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setMaxSchedulerLimit.(I)Landroidx/work/Configuration$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setMinimumLoggingLevel", "(I)Landroidx/work/Configuration$Builder;", "")]
			public unsafe Builder SetMinimumLoggingLevel(int loggingLevel)
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(loggingLevel);
				return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setMinimumLoggingLevel.(I)Landroidx/work/Configuration$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("setRunnableScheduler", "(Landroidx/work/RunnableScheduler;)Landroidx/work/Configuration$Builder;", "")]
			public unsafe Builder SetRunnableScheduler(IRunnableScheduler runnableScheduler)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((runnableScheduler == null) ? IntPtr.Zero : ((Java.Lang.Object)runnableScheduler).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setRunnableScheduler.(Landroidx/work/RunnableScheduler;)Landroidx/work/Configuration$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(runnableScheduler);
				}
			}

			[Register("setTaskExecutor", "(Ljava/util/concurrent/Executor;)Landroidx/work/Configuration$Builder;", "")]
			public unsafe Builder SetTaskExecutor(IExecutor taskExecutor)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue((taskExecutor == null) ? IntPtr.Zero : ((Java.Lang.Object)taskExecutor).Handle);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setTaskExecutor.(Ljava/util/concurrent/Executor;)Landroidx/work/Configuration$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(taskExecutor);
				}
			}

			[Register("setWorkerFactory", "(Landroidx/work/WorkerFactory;)Landroidx/work/Configuration$Builder;", "")]
			public unsafe Builder SetWorkerFactory(WorkerFactory workerFactory)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(workerFactory?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Builder>(_members.InstanceMethods.InvokeAbstractObjectMethod("setWorkerFactory.(Landroidx/work/WorkerFactory;)Landroidx/work/Configuration$Builder;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(workerFactory);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/Configuration", typeof(Configuration));

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

		public unsafe string DefaultProcessName
		{
			[Register("getDefaultProcessName", "()Ljava/lang/String;", "")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getDefaultProcessName.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IInitializationExceptionHandler ExceptionHandler
		{
			[Register("getExceptionHandler", "()Landroidx/work/InitializationExceptionHandler;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IInitializationExceptionHandler>(_members.InstanceMethods.InvokeAbstractObjectMethod("getExceptionHandler.()Landroidx/work/InitializationExceptionHandler;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IExecutor Executor
		{
			[Register("getExecutor", "()Ljava/util/concurrent/Executor;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IExecutor>(_members.InstanceMethods.InvokeAbstractObjectMethod("getExecutor.()Ljava/util/concurrent/Executor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe InputMergerFactory InputMergerFactory
		{
			[Register("getInputMergerFactory", "()Landroidx/work/InputMergerFactory;", "")]
			get
			{
				return Java.Lang.Object.GetObject<InputMergerFactory>(_members.InstanceMethods.InvokeAbstractObjectMethod("getInputMergerFactory.()Landroidx/work/InputMergerFactory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool IsUsingDefaultTaskExecutor
		{
			[Register("isUsingDefaultTaskExecutor", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isUsingDefaultTaskExecutor.()Z", this, null);
			}
		}

		public unsafe int MaxJobSchedulerId
		{
			[Register("getMaxJobSchedulerId", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getMaxJobSchedulerId.()I", this, null);
			}
		}

		public unsafe int MaxSchedulerLimit
		{
			[Register("getMaxSchedulerLimit", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getMaxSchedulerLimit.()I", this, null);
			}
		}

		public unsafe int MinJobSchedulerId
		{
			[Register("getMinJobSchedulerId", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getMinJobSchedulerId.()I", this, null);
			}
		}

		public unsafe int MinimumLoggingLevel
		{
			[Register("getMinimumLoggingLevel", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getMinimumLoggingLevel.()I", this, null);
			}
		}

		public unsafe IRunnableScheduler RunnableScheduler
		{
			[Register("getRunnableScheduler", "()Landroidx/work/RunnableScheduler;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IRunnableScheduler>(_members.InstanceMethods.InvokeAbstractObjectMethod("getRunnableScheduler.()Landroidx/work/RunnableScheduler;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IExecutor TaskExecutor
		{
			[Register("getTaskExecutor", "()Ljava/util/concurrent/Executor;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IExecutor>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTaskExecutor.()Ljava/util/concurrent/Executor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe WorkerFactory WorkerFactory
		{
			[Register("getWorkerFactory", "()Landroidx/work/WorkerFactory;", "")]
			get
			{
				return Java.Lang.Object.GetObject<WorkerFactory>(_members.InstanceMethods.InvokeAbstractObjectMethod("getWorkerFactory.()Landroidx/work/WorkerFactory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal Configuration(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("androidx/work/ContentUriTriggers", DoNotGenerateAcw = true)]
	public sealed class ContentUriTriggers : Java.Lang.Object
	{
		[Register("androidx/work/ContentUriTriggers$Trigger", DoNotGenerateAcw = true)]
		public sealed class Trigger : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/ContentUriTriggers$Trigger", typeof(Trigger));

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

			public unsafe Android.Net.Uri Uri
			{
				[Register("getUri", "()Landroid/net/Uri;", "")]
				get
				{
					return Java.Lang.Object.GetObject<Android.Net.Uri>(_members.InstanceMethods.InvokeAbstractObjectMethod("getUri.()Landroid/net/Uri;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			internal Trigger(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("shouldTriggerForDescendants", "()Z", "")]
			public unsafe bool ShouldTriggerForDescendants()
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("shouldTriggerForDescendants.()Z", this, null);
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/ContentUriTriggers", typeof(ContentUriTriggers));

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

		public unsafe ICollection<Trigger> Triggers
		{
			[Register("getTriggers", "()Ljava/util/Set;", "")]
			get
			{
				return JavaSet<Trigger>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getTriggers.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal ContentUriTriggers(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe ContentUriTriggers()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("add", "(Landroid/net/Uri;Z)V", "")]
		public unsafe void Add(Android.Net.Uri uri, bool triggerForDescendants)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(uri?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(triggerForDescendants);
				_members.InstanceMethods.InvokeAbstractVoidMethod("add.(Landroid/net/Uri;Z)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(uri);
			}
		}

		[Register("size", "()I", "")]
		public unsafe int Size()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("size.()I", this, null);
		}
	}
	[Register("androidx/work/Data", DoNotGenerateAcw = true)]
	public sealed class Data : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/Data", typeof(Data));

		[Register("EMPTY")]
		public static Data Empty => Java.Lang.Object.GetObject<Data>(_members.StaticFields.GetObjectValue("EMPTY.Landroidx/work/Data;").Handle, JniHandleOwnership.TransferLocalRef);

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

		public unsafe IDictionary<string, Java.Lang.Object> KeyValueMap
		{
			[Register("getKeyValueMap", "()Ljava/util/Map;", "")]
			get
			{
				return JavaDictionary<string, Java.Lang.Object>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getKeyValueMap.()Ljava/util/Map;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal Data(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroidx/work/Data;)V", "")]
		public unsafe Data(Data other)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/work/Data;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/work/Data;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(other);
			}
		}

		[Register(".ctor", "(Ljava/util/Map;)V", "")]
		public unsafe Data(IDictionary<string, object> values)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JavaDictionary<string, object>.ToLocalJniHandle(values);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/util/Map;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/util/Map;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(values);
			}
		}

		[Register("convertPrimitiveBooleanArray", "([Z)[Ljava/lang/Boolean;", "")]
		public unsafe static Java.Lang.Boolean[] ConvertPrimitiveBooleanArray(bool[] value)
		{
			IntPtr intPtr = JNIEnv.NewArray(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (Java.Lang.Boolean[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("convertPrimitiveBooleanArray.([Z)[Ljava/lang/Boolean;", ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Java.Lang.Boolean));
			}
			finally
			{
				if (value != null)
				{
					JNIEnv.CopyArray(intPtr, value);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(value);
			}
		}

		[Register("convertPrimitiveByteArray", "([B)[Ljava/lang/Byte;", "")]
		public unsafe static Java.Lang.Byte[] ConvertPrimitiveByteArray(byte[] value)
		{
			IntPtr intPtr = JNIEnv.NewArray(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (Java.Lang.Byte[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("convertPrimitiveByteArray.([B)[Ljava/lang/Byte;", ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Java.Lang.Byte));
			}
			finally
			{
				if (value != null)
				{
					JNIEnv.CopyArray(intPtr, value);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(value);
			}
		}

		[Register("convertPrimitiveDoubleArray", "([D)[Ljava/lang/Double;", "")]
		public unsafe static Java.Lang.Double[] ConvertPrimitiveDoubleArray(double[] value)
		{
			IntPtr intPtr = JNIEnv.NewArray(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (Java.Lang.Double[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("convertPrimitiveDoubleArray.([D)[Ljava/lang/Double;", ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Java.Lang.Double));
			}
			finally
			{
				if (value != null)
				{
					JNIEnv.CopyArray(intPtr, value);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(value);
			}
		}

		[Register("convertPrimitiveFloatArray", "([F)[Ljava/lang/Float;", "")]
		public unsafe static Float[] ConvertPrimitiveFloatArray(float[] value)
		{
			IntPtr intPtr = JNIEnv.NewArray(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (Float[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("convertPrimitiveFloatArray.([F)[Ljava/lang/Float;", ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Float));
			}
			finally
			{
				if (value != null)
				{
					JNIEnv.CopyArray(intPtr, value);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(value);
			}
		}

		[Register("convertPrimitiveIntArray", "([I)[Ljava/lang/Integer;", "")]
		public unsafe static Integer[] ConvertPrimitiveIntArray(int[] value)
		{
			IntPtr intPtr = JNIEnv.NewArray(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (Integer[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("convertPrimitiveIntArray.([I)[Ljava/lang/Integer;", ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Integer));
			}
			finally
			{
				if (value != null)
				{
					JNIEnv.CopyArray(intPtr, value);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(value);
			}
		}

		[Register("convertPrimitiveLongArray", "([J)[Ljava/lang/Long;", "")]
		public unsafe static Long[] ConvertPrimitiveLongArray(long[] value)
		{
			IntPtr intPtr = JNIEnv.NewArray(value);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (Long[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("convertPrimitiveLongArray.([J)[Ljava/lang/Long;", ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(Long));
			}
			finally
			{
				if (value != null)
				{
					JNIEnv.CopyArray(intPtr, value);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(value);
			}
		}

		[Register("convertToPrimitiveArray", "([Ljava/lang/Boolean;)[Z", "")]
		public unsafe static bool[] ConvertToPrimitiveArray(Java.Lang.Boolean[] array)
		{
			IntPtr intPtr = JNIEnv.NewArray(array);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (bool[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("convertToPrimitiveArray.([Ljava/lang/Boolean;)[Z", ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(bool));
			}
			finally
			{
				if (array != null)
				{
					JNIEnv.CopyArray(intPtr, array);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(array);
			}
		}

		[Register("convertToPrimitiveArray", "([Ljava/lang/Byte;)[B", "")]
		public unsafe static byte[] ConvertToPrimitiveArray(Java.Lang.Byte[] array)
		{
			IntPtr intPtr = JNIEnv.NewArray(array);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (byte[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("convertToPrimitiveArray.([Ljava/lang/Byte;)[B", ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
			}
			finally
			{
				if (array != null)
				{
					JNIEnv.CopyArray(intPtr, array);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(array);
			}
		}

		[Register("convertToPrimitiveArray", "([Ljava/lang/Double;)[D", "")]
		public unsafe static double[] ConvertToPrimitiveArray(Java.Lang.Double[] array)
		{
			IntPtr intPtr = JNIEnv.NewArray(array);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (double[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("convertToPrimitiveArray.([Ljava/lang/Double;)[D", ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(double));
			}
			finally
			{
				if (array != null)
				{
					JNIEnv.CopyArray(intPtr, array);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(array);
			}
		}

		[Register("convertToPrimitiveArray", "([Ljava/lang/Float;)[F", "")]
		public unsafe static float[] ConvertToPrimitiveArray(Float[] array)
		{
			IntPtr intPtr = JNIEnv.NewArray(array);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (float[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("convertToPrimitiveArray.([Ljava/lang/Float;)[F", ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(float));
			}
			finally
			{
				if (array != null)
				{
					JNIEnv.CopyArray(intPtr, array);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(array);
			}
		}

		[Register("convertToPrimitiveArray", "([Ljava/lang/Integer;)[I", "")]
		public unsafe static int[] ConvertToPrimitiveArray(Integer[] array)
		{
			IntPtr intPtr = JNIEnv.NewArray(array);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (int[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("convertToPrimitiveArray.([Ljava/lang/Integer;)[I", ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
			}
			finally
			{
				if (array != null)
				{
					JNIEnv.CopyArray(intPtr, array);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(array);
			}
		}

		[Register("convertToPrimitiveArray", "([Ljava/lang/Long;)[J", "")]
		public unsafe static long[] ConvertToPrimitiveArray(Long[] array)
		{
			IntPtr intPtr = JNIEnv.NewArray(array);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (long[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("convertToPrimitiveArray.([Ljava/lang/Long;)[J", ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(long));
			}
			finally
			{
				if (array != null)
				{
					JNIEnv.CopyArray(intPtr, array);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(array);
			}
		}

		[Register("fromByteArray", "([B)Landroidx/work/Data;", "")]
		public unsafe static Data FromByteArray(byte[] bytes)
		{
			IntPtr intPtr = JNIEnv.NewArray(bytes);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Data>(_members.StaticMethods.InvokeObjectMethod("fromByteArray.([B)Landroidx/work/Data;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				if (bytes != null)
				{
					JNIEnv.CopyArray(intPtr, bytes);
					JNIEnv.DeleteLocalRef(intPtr);
				}
				GC.KeepAlive(bytes);
			}
		}

		[Register("getBoolean", "(Ljava/lang/String;Z)Z", "")]
		public unsafe bool GetBoolean(string key, bool defaultValue)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(defaultValue);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("getBoolean.(Ljava/lang/String;Z)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getBooleanArray", "(Ljava/lang/String;)[Z", "")]
		public unsafe bool[] GetBooleanArray(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (bool[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getBooleanArray.(Ljava/lang/String;)[Z", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(bool));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getByte", "(Ljava/lang/String;B)B", "")]
		public unsafe sbyte GetByte(string key, sbyte defaultValue)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(defaultValue);
				return _members.InstanceMethods.InvokeAbstractSByteMethod("getByte.(Ljava/lang/String;B)B", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getByteArray", "(Ljava/lang/String;)[B", "")]
		public unsafe byte[] GetByteArray(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getByteArray.(Ljava/lang/String;)[B", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getDouble", "(Ljava/lang/String;D)D", "")]
		public unsafe double GetDouble(string key, double defaultValue)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(defaultValue);
				return _members.InstanceMethods.InvokeAbstractDoubleMethod("getDouble.(Ljava/lang/String;D)D", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getDoubleArray", "(Ljava/lang/String;)[D", "")]
		public unsafe double[] GetDoubleArray(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (double[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getDoubleArray.(Ljava/lang/String;)[D", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(double));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getFloat", "(Ljava/lang/String;F)F", "")]
		public unsafe float GetFloat(string key, float defaultValue)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(defaultValue);
				return _members.InstanceMethods.InvokeAbstractSingleMethod("getFloat.(Ljava/lang/String;F)F", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getFloatArray", "(Ljava/lang/String;)[F", "")]
		public unsafe float[] GetFloatArray(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (float[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getFloatArray.(Ljava/lang/String;)[F", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(float));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getInt", "(Ljava/lang/String;I)I", "")]
		public unsafe int GetInt(string key, int defaultValue)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(defaultValue);
				return _members.InstanceMethods.InvokeAbstractInt32Method("getInt.(Ljava/lang/String;I)I", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getIntArray", "(Ljava/lang/String;)[I", "")]
		public unsafe int[] GetIntArray(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (int[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getIntArray.(Ljava/lang/String;)[I", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(int));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getLong", "(Ljava/lang/String;J)J", "")]
		public unsafe long GetLong(string key, long defaultValue)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(defaultValue);
				return _members.InstanceMethods.InvokeAbstractInt64Method("getLong.(Ljava/lang/String;J)J", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getLongArray", "(Ljava/lang/String;)[J", "")]
		public unsafe long[] GetLongArray(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (long[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getLongArray.(Ljava/lang/String;)[J", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(long));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getString", "(Ljava/lang/String;)Ljava/lang/String;", "")]
		public unsafe string GetString(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return JNIEnv.GetString(_members.InstanceMethods.InvokeAbstractObjectMethod("getString.(Ljava/lang/String;)Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getStringArray", "(Ljava/lang/String;)[Ljava/lang/String;", "")]
		public unsafe string[] GetStringArray(string key)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return (string[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("getStringArray.(Ljava/lang/String;)[Ljava/lang/String;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(string));
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("hasKeyWithValueOfType", "(Ljava/lang/String;Ljava/lang/Class;)Z", "")]
		[JavaTypeParameters(new string[] { "T" })]
		public unsafe bool HasKeyWithValueOfType(string key, Class klass)
		{
			IntPtr intPtr = JNIEnv.NewString(key);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(klass?.Handle ?? IntPtr.Zero);
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasKeyWithValueOfType.(Ljava/lang/String;Ljava/lang/Class;)Z", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(klass);
			}
		}

		[Register("size", "()I", "")]
		public unsafe int Size()
		{
			return _members.InstanceMethods.InvokeAbstractInt32Method("size.()I", this, null);
		}

		[Register("toByteArray", "()[B", "")]
		public unsafe byte[] ToByteArray()
		{
			return (byte[])JNIEnv.GetArray(_members.InstanceMethods.InvokeAbstractObjectMethod("toByteArray.()[B", this, null).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
		}

		[Register("toByteArrayInternal", "(Landroidx/work/Data;)[B", "")]
		public unsafe static byte[] ToByteArrayInternal(Data data)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
				return (byte[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("toByteArrayInternal.(Landroidx/work/Data;)[B", ptr).Handle, JniHandleOwnership.TransferLocalRef, typeof(byte));
			}
			finally
			{
				GC.KeepAlive(data);
			}
		}
	}
	[Register("androidx/work/ExistingPeriodicWorkPolicy", DoNotGenerateAcw = true)]
	public sealed class ExistingPeriodicWorkPolicy : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/ExistingPeriodicWorkPolicy", typeof(ExistingPeriodicWorkPolicy));

		[Register("KEEP")]
		public static ExistingPeriodicWorkPolicy Keep => Java.Lang.Object.GetObject<ExistingPeriodicWorkPolicy>(_members.StaticFields.GetObjectValue("KEEP.Landroidx/work/ExistingPeriodicWorkPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("REPLACE")]
		public static ExistingPeriodicWorkPolicy Replace => Java.Lang.Object.GetObject<ExistingPeriodicWorkPolicy>(_members.StaticFields.GetObjectValue("REPLACE.Landroidx/work/ExistingPeriodicWorkPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal ExistingPeriodicWorkPolicy(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/work/ExistingPeriodicWorkPolicy;", "")]
		public unsafe static ExistingPeriodicWorkPolicy ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ExistingPeriodicWorkPolicy>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/work/ExistingPeriodicWorkPolicy;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Landroidx/work/ExistingPeriodicWorkPolicy;", "")]
		public unsafe static ExistingPeriodicWorkPolicy[] Values()
		{
			return (ExistingPeriodicWorkPolicy[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/work/ExistingPeriodicWorkPolicy;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ExistingPeriodicWorkPolicy));
		}
	}
	[Register("androidx/work/ExistingWorkPolicy", DoNotGenerateAcw = true)]
	public sealed class ExistingWorkPolicy : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/ExistingWorkPolicy", typeof(ExistingWorkPolicy));

		[Register("APPEND")]
		public static ExistingWorkPolicy Append => Java.Lang.Object.GetObject<ExistingWorkPolicy>(_members.StaticFields.GetObjectValue("APPEND.Landroidx/work/ExistingWorkPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("APPEND_OR_REPLACE")]
		public static ExistingWorkPolicy AppendOrReplace => Java.Lang.Object.GetObject<ExistingWorkPolicy>(_members.StaticFields.GetObjectValue("APPEND_OR_REPLACE.Landroidx/work/ExistingWorkPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("KEEP")]
		public static ExistingWorkPolicy Keep => Java.Lang.Object.GetObject<ExistingWorkPolicy>(_members.StaticFields.GetObjectValue("KEEP.Landroidx/work/ExistingWorkPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("REPLACE")]
		public static ExistingWorkPolicy Replace => Java.Lang.Object.GetObject<ExistingWorkPolicy>(_members.StaticFields.GetObjectValue("REPLACE.Landroidx/work/ExistingWorkPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal ExistingWorkPolicy(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/work/ExistingWorkPolicy;", "")]
		public unsafe static ExistingWorkPolicy ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<ExistingWorkPolicy>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/work/ExistingWorkPolicy;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Landroidx/work/ExistingWorkPolicy;", "")]
		public unsafe static ExistingWorkPolicy[] Values()
		{
			return (ExistingWorkPolicy[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/work/ExistingWorkPolicy;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(ExistingWorkPolicy));
		}
	}
	[Register("androidx/work/ForegroundInfo", DoNotGenerateAcw = true)]
	public sealed class ForegroundInfo : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/ForegroundInfo", typeof(ForegroundInfo));

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

		public unsafe int ForegroundServiceType
		{
			[Register("getForegroundServiceType", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getForegroundServiceType.()I", this, null);
			}
		}

		public unsafe Notification Notification
		{
			[Register("getNotification", "()Landroid/app/Notification;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Notification>(_members.InstanceMethods.InvokeAbstractObjectMethod("getNotification.()Landroid/app/Notification;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int NotificationId
		{
			[Register("getNotificationId", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getNotificationId.()I", this, null);
			}
		}

		internal ForegroundInfo(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(ILandroid/app/Notification;)V", "")]
		public unsafe ForegroundInfo(int notificationId, Notification notification)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(notificationId);
				ptr[1] = new JniArgumentValue(notification?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(ILandroid/app/Notification;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(ILandroid/app/Notification;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(notification);
			}
		}

		[Register(".ctor", "(ILandroid/app/Notification;I)V", "")]
		public unsafe ForegroundInfo(int notificationId, Notification notification, int foregroundServiceType)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(notificationId);
				ptr[1] = new JniArgumentValue(notification?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(foregroundServiceType);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(ILandroid/app/Notification;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(ILandroid/app/Notification;I)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(notification);
			}
		}
	}
	[Register("androidx/work/ForegroundUpdater", "", "AndroidX.Work.IForegroundUpdaterInvoker")]
	public interface IForegroundUpdater : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("setForegroundAsync", "(Landroid/content/Context;Ljava/util/UUID;Landroidx/work/ForegroundInfo;)Lcom/google/common/util/concurrent/ListenableFuture;", "GetSetForegroundAsync_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_ForegroundInfo_Handler:AndroidX.Work.IForegroundUpdaterInvoker, Xamarin.AndroidX.Work.Runtime")]
		IListenableFuture SetForegroundAsync(Context context, UUID id, ForegroundInfo foregroundInfo);
	}
	[Register("androidx/work/ForegroundUpdater", DoNotGenerateAcw = true)]
	internal class IForegroundUpdaterInvoker : Java.Lang.Object, IForegroundUpdater, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/ForegroundUpdater", typeof(IForegroundUpdaterInvoker));

		private IntPtr class_ref;

		private static Delegate cb_setForegroundAsync_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_ForegroundInfo_;

		private IntPtr id_setForegroundAsync_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_ForegroundInfo_;

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

		public static IForegroundUpdater GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IForegroundUpdater>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.work.ForegroundUpdater'.");
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

		public IForegroundUpdaterInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetSetForegroundAsync_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_ForegroundInfo_Handler()
		{
			if ((object)cb_setForegroundAsync_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_ForegroundInfo_ == null)
			{
				cb_setForegroundAsync_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_ForegroundInfo_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_SetForegroundAsync_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_ForegroundInfo_));
			}
			return cb_setForegroundAsync_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_ForegroundInfo_;
		}

		private static IntPtr n_SetForegroundAsync_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_ForegroundInfo_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_id, IntPtr native_foregroundInfo)
		{
			IForegroundUpdater foregroundUpdater = Java.Lang.Object.GetObject<IForegroundUpdater>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			UUID id = Java.Lang.Object.GetObject<UUID>(native_id, JniHandleOwnership.DoNotTransfer);
			ForegroundInfo foregroundInfo = Java.Lang.Object.GetObject<ForegroundInfo>(native_foregroundInfo, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(foregroundUpdater.SetForegroundAsync(context, id, foregroundInfo));
		}

		public unsafe IListenableFuture SetForegroundAsync(Context context, UUID id, ForegroundInfo foregroundInfo)
		{
			if (id_setForegroundAsync_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_ForegroundInfo_ == IntPtr.Zero)
			{
				id_setForegroundAsync_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_ForegroundInfo_ = JNIEnv.GetMethodID(class_ref, "setForegroundAsync", "(Landroid/content/Context;Ljava/util/UUID;Landroidx/work/ForegroundInfo;)Lcom/google/common/util/concurrent/ListenableFuture;");
			}
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(id?.Handle ?? IntPtr.Zero);
			ptr[2] = new JValue(foregroundInfo?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IListenableFuture>(JNIEnv.CallObjectMethod(base.Handle, id_setForegroundAsync_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_ForegroundInfo_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("androidx/work/InitializationExceptionHandler", "", "AndroidX.Work.IInitializationExceptionHandlerInvoker")]
	public interface IInitializationExceptionHandler : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("handleException", "(Ljava/lang/Throwable;)V", "GetHandleException_Ljava_lang_Throwable_Handler:AndroidX.Work.IInitializationExceptionHandlerInvoker, Xamarin.AndroidX.Work.Runtime")]
		void HandleException(Throwable throwable);
	}
	[Register("androidx/work/InitializationExceptionHandler", DoNotGenerateAcw = true)]
	internal class IInitializationExceptionHandlerInvoker : Java.Lang.Object, IInitializationExceptionHandler, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/InitializationExceptionHandler", typeof(IInitializationExceptionHandlerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_handleException_Ljava_lang_Throwable_;

		private IntPtr id_handleException_Ljava_lang_Throwable_;

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

		public static IInitializationExceptionHandler GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IInitializationExceptionHandler>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.work.InitializationExceptionHandler'.");
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

		public IInitializationExceptionHandlerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetHandleException_Ljava_lang_Throwable_Handler()
		{
			if ((object)cb_handleException_Ljava_lang_Throwable_ == null)
			{
				cb_handleException_Ljava_lang_Throwable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_HandleException_Ljava_lang_Throwable_));
			}
			return cb_handleException_Ljava_lang_Throwable_;
		}

		private static void n_HandleException_Ljava_lang_Throwable_(IntPtr jnienv, IntPtr native__this, IntPtr native_throwable)
		{
			IInitializationExceptionHandler initializationExceptionHandler = Java.Lang.Object.GetObject<IInitializationExceptionHandler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Throwable throwable = Java.Lang.Object.GetObject<Throwable>(native_throwable, JniHandleOwnership.DoNotTransfer);
			initializationExceptionHandler.HandleException(throwable);
		}

		public unsafe void HandleException(Throwable throwable)
		{
			if (id_handleException_Ljava_lang_Throwable_ == IntPtr.Zero)
			{
				id_handleException_Ljava_lang_Throwable_ = JNIEnv.GetMethodID(class_ref, "handleException", "(Ljava/lang/Throwable;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue(throwable?.Handle ?? IntPtr.Zero);
			JNIEnv.CallVoidMethod(base.Handle, id_handleException_Ljava_lang_Throwable_, ptr);
		}
	}
	[Register("androidx/work/InputMerger", DoNotGenerateAcw = true)]
	public abstract class InputMerger : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/InputMerger", typeof(InputMerger));

		private static Delegate cb_merge_Ljava_util_List_;

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

		protected InputMerger(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe InputMerger()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		[Register("fromClassName", "(Ljava/lang/String;)Landroidx/work/InputMerger;", "")]
		public unsafe static InputMerger FromClassName(string className)
		{
			IntPtr intPtr = JNIEnv.NewString(className);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<InputMerger>(_members.StaticMethods.InvokeObjectMethod("fromClassName.(Ljava/lang/String;)Landroidx/work/InputMerger;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		private static Delegate GetMerge_Ljava_util_List_Handler()
		{
			if ((object)cb_merge_Ljava_util_List_ == null)
			{
				cb_merge_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Merge_Ljava_util_List_));
			}
			return cb_merge_Ljava_util_List_;
		}

		private static IntPtr n_Merge_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_inputs)
		{
			InputMerger inputMerger = Java.Lang.Object.GetObject<InputMerger>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<Data> inputs = JavaList<Data>.FromJniHandle(native_inputs, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(inputMerger.Merge(inputs));
		}

		[Register("merge", "(Ljava/util/List;)Landroidx/work/Data;", "GetMerge_Ljava_util_List_Handler")]
		public abstract Data Merge(IList<Data> inputs);
	}
	[Register("androidx/work/InputMerger", DoNotGenerateAcw = true)]
	internal class InputMergerInvoker : InputMerger
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/InputMerger", typeof(InputMergerInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public InputMergerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("merge", "(Ljava/util/List;)Landroidx/work/Data;", "GetMerge_Ljava_util_List_Handler")]
		public unsafe override Data Merge(IList<Data> inputs)
		{
			IntPtr intPtr = JavaList<Data>.ToLocalJniHandle(inputs);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<Data>(_members.InstanceMethods.InvokeAbstractObjectMethod("merge.(Ljava/util/List;)Landroidx/work/Data;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(inputs);
			}
		}
	}
	[Register("androidx/work/InputMergerFactory", DoNotGenerateAcw = true)]
	public abstract class InputMergerFactory : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/InputMergerFactory", typeof(InputMergerFactory));

		private static Delegate cb_createInputMerger_Ljava_lang_String_;

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

		public unsafe static InputMergerFactory DefaultInputMergerFactory
		{
			[Register("getDefaultInputMergerFactory", "()Landroidx/work/InputMergerFactory;", "")]
			get
			{
				return Java.Lang.Object.GetObject<InputMergerFactory>(_members.StaticMethods.InvokeObjectMethod("getDefaultInputMergerFactory.()Landroidx/work/InputMergerFactory;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected InputMergerFactory(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe InputMergerFactory()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetCreateInputMerger_Ljava_lang_String_Handler()
		{
			if ((object)cb_createInputMerger_Ljava_lang_String_ == null)
			{
				cb_createInputMerger_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_CreateInputMerger_Ljava_lang_String_));
			}
			return cb_createInputMerger_Ljava_lang_String_;
		}

		private static IntPtr n_CreateInputMerger_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_className)
		{
			InputMergerFactory inputMergerFactory = Java.Lang.Object.GetObject<InputMergerFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string className = JNIEnv.GetString(native_className, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(inputMergerFactory.CreateInputMerger(className));
		}

		[Register("createInputMerger", "(Ljava/lang/String;)Landroidx/work/InputMerger;", "GetCreateInputMerger_Ljava_lang_String_Handler")]
		public abstract InputMerger CreateInputMerger(string className);

		[Register("createInputMergerWithDefaultFallback", "(Ljava/lang/String;)Landroidx/work/InputMerger;", "")]
		public unsafe InputMerger CreateInputMergerWithDefaultFallback(string className)
		{
			IntPtr intPtr = JNIEnv.NewString(className);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<InputMerger>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("createInputMergerWithDefaultFallback.(Ljava/lang/String;)Landroidx/work/InputMerger;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("androidx/work/InputMergerFactory", DoNotGenerateAcw = true)]
	internal class InputMergerFactoryInvoker : InputMergerFactory
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/InputMergerFactory", typeof(InputMergerFactoryInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public InputMergerFactoryInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("createInputMerger", "(Ljava/lang/String;)Landroidx/work/InputMerger;", "GetCreateInputMerger_Ljava_lang_String_Handler")]
		public unsafe override InputMerger CreateInputMerger(string className)
		{
			IntPtr intPtr = JNIEnv.NewString(className);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<InputMerger>(_members.InstanceMethods.InvokeAbstractObjectMethod("createInputMerger.(Ljava/lang/String;)Landroidx/work/InputMerger;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}
	}
	[Register("androidx/work/Operation", "", "AndroidX.Work.IOperationInvoker")]
	public interface IOperation : IJavaObject, IDisposable, IJavaPeerable
	{
		IListenableFuture Result
		{
			[Register("getResult", "()Lcom/google/common/util/concurrent/ListenableFuture;", "GetGetResultHandler:AndroidX.Work.IOperationInvoker, Xamarin.AndroidX.Work.Runtime")]
			get;
		}

		LiveData State
		{
			[Register("getState", "()Landroidx/lifecycle/LiveData;", "GetGetStateHandler:AndroidX.Work.IOperationInvoker, Xamarin.AndroidX.Work.Runtime")]
			get;
		}
	}
	[Register("androidx/work/Operation", DoNotGenerateAcw = true)]
	internal class IOperationInvoker : Java.Lang.Object, IOperation, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/Operation", typeof(IOperationInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getResult;

		private IntPtr id_getResult;

		private static Delegate cb_getState;

		private IntPtr id_getState;

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

		public IListenableFuture Result
		{
			get
			{
				if (id_getResult == IntPtr.Zero)
				{
					id_getResult = JNIEnv.GetMethodID(class_ref, "getResult", "()Lcom/google/common/util/concurrent/ListenableFuture;");
				}
				return Java.Lang.Object.GetObject<IListenableFuture>(JNIEnv.CallObjectMethod(base.Handle, id_getResult), JniHandleOwnership.TransferLocalRef);
			}
		}

		public LiveData State
		{
			get
			{
				if (id_getState == IntPtr.Zero)
				{
					id_getState = JNIEnv.GetMethodID(class_ref, "getState", "()Landroidx/lifecycle/LiveData;");
				}
				return Java.Lang.Object.GetObject<LiveData>(JNIEnv.CallObjectMethod(base.Handle, id_getState), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static IOperation GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IOperation>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.work.Operation'.");
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

		public IOperationInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetResultHandler()
		{
			if ((object)cb_getResult == null)
			{
				cb_getResult = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetResult));
			}
			return cb_getResult;
		}

		private static IntPtr n_GetResult(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IOperation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Result);
		}

		private static Delegate GetGetStateHandler()
		{
			if ((object)cb_getState == null)
			{
				cb_getState = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetState));
			}
			return cb_getState;
		}

		private static IntPtr n_GetState(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<IOperation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).State);
		}
	}
	[Register("androidx/work/ProgressUpdater", "", "AndroidX.Work.IProgressUpdaterInvoker")]
	public interface IProgressUpdater : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("updateProgress", "(Landroid/content/Context;Ljava/util/UUID;Landroidx/work/Data;)Lcom/google/common/util/concurrent/ListenableFuture;", "GetUpdateProgress_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_Data_Handler:AndroidX.Work.IProgressUpdaterInvoker, Xamarin.AndroidX.Work.Runtime")]
		IListenableFuture UpdateProgress(Context context, UUID id, Data data);
	}
	[Register("androidx/work/ProgressUpdater", DoNotGenerateAcw = true)]
	internal class IProgressUpdaterInvoker : Java.Lang.Object, IProgressUpdater, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/ProgressUpdater", typeof(IProgressUpdaterInvoker));

		private IntPtr class_ref;

		private static Delegate cb_updateProgress_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_Data_;

		private IntPtr id_updateProgress_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_Data_;

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

		public static IProgressUpdater GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IProgressUpdater>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.work.ProgressUpdater'.");
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

		public IProgressUpdaterInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetUpdateProgress_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_Data_Handler()
		{
			if ((object)cb_updateProgress_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_Data_ == null)
			{
				cb_updateProgress_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_Data_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_UpdateProgress_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_Data_));
			}
			return cb_updateProgress_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_Data_;
		}

		private static IntPtr n_UpdateProgress_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_Data_(IntPtr jnienv, IntPtr native__this, IntPtr native_context, IntPtr native_id, IntPtr native_data)
		{
			IProgressUpdater progressUpdater = Java.Lang.Object.GetObject<IProgressUpdater>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context context = Java.Lang.Object.GetObject<Context>(native_context, JniHandleOwnership.DoNotTransfer);
			UUID id = Java.Lang.Object.GetObject<UUID>(native_id, JniHandleOwnership.DoNotTransfer);
			Data data = Java.Lang.Object.GetObject<Data>(native_data, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(progressUpdater.UpdateProgress(context, id, data));
		}

		public unsafe IListenableFuture UpdateProgress(Context context, UUID id, Data data)
		{
			if (id_updateProgress_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_Data_ == IntPtr.Zero)
			{
				id_updateProgress_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_Data_ = JNIEnv.GetMethodID(class_ref, "updateProgress", "(Landroid/content/Context;Ljava/util/UUID;Landroidx/work/Data;)Lcom/google/common/util/concurrent/ListenableFuture;");
			}
			JValue* ptr = stackalloc JValue[3];
			*ptr = new JValue(context?.Handle ?? IntPtr.Zero);
			ptr[1] = new JValue(id?.Handle ?? IntPtr.Zero);
			ptr[2] = new JValue(data?.Handle ?? IntPtr.Zero);
			return Java.Lang.Object.GetObject<IListenableFuture>(JNIEnv.CallObjectMethod(base.Handle, id_updateProgress_Landroid_content_Context_Ljava_util_UUID_Landroidx_work_Data_, ptr), JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("androidx/work/RunnableScheduler", "", "AndroidX.Work.IRunnableSchedulerInvoker")]
	public interface IRunnableScheduler : IJavaObject, IDisposable, IJavaPeerable
	{
		[Register("cancel", "(Ljava/lang/Runnable;)V", "GetCancel_Ljava_lang_Runnable_Handler:AndroidX.Work.IRunnableSchedulerInvoker, Xamarin.AndroidX.Work.Runtime")]
		void Cancel(IRunnable runnable);

		[Register("scheduleWithDelay", "(JLjava/lang/Runnable;)V", "GetScheduleWithDelay_JLjava_lang_Runnable_Handler:AndroidX.Work.IRunnableSchedulerInvoker, Xamarin.AndroidX.Work.Runtime")]
		void ScheduleWithDelay(long delayInMillis, IRunnable runnable);
	}
	[Register("androidx/work/RunnableScheduler", DoNotGenerateAcw = true)]
	internal class IRunnableSchedulerInvoker : Java.Lang.Object, IRunnableScheduler, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/RunnableScheduler", typeof(IRunnableSchedulerInvoker));

		private IntPtr class_ref;

		private static Delegate cb_cancel_Ljava_lang_Runnable_;

		private IntPtr id_cancel_Ljava_lang_Runnable_;

		private static Delegate cb_scheduleWithDelay_JLjava_lang_Runnable_;

		private IntPtr id_scheduleWithDelay_JLjava_lang_Runnable_;

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

		public static IRunnableScheduler GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<IRunnableScheduler>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.work.RunnableScheduler'.");
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

		public IRunnableSchedulerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetCancel_Ljava_lang_Runnable_Handler()
		{
			if ((object)cb_cancel_Ljava_lang_Runnable_ == null)
			{
				cb_cancel_Ljava_lang_Runnable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Cancel_Ljava_lang_Runnable_));
			}
			return cb_cancel_Ljava_lang_Runnable_;
		}

		private static void n_Cancel_Ljava_lang_Runnable_(IntPtr jnienv, IntPtr native__this, IntPtr native_runnable)
		{
			IRunnableScheduler runnableScheduler = Java.Lang.Object.GetObject<IRunnableScheduler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable runnable = Java.Lang.Object.GetObject<IRunnable>(native_runnable, JniHandleOwnership.DoNotTransfer);
			runnableScheduler.Cancel(runnable);
		}

		public unsafe void Cancel(IRunnable runnable)
		{
			if (id_cancel_Ljava_lang_Runnable_ == IntPtr.Zero)
			{
				id_cancel_Ljava_lang_Runnable_ = JNIEnv.GetMethodID(class_ref, "cancel", "(Ljava/lang/Runnable;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((runnable == null) ? IntPtr.Zero : ((Java.Lang.Object)runnable).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_cancel_Ljava_lang_Runnable_, ptr);
		}

		private static Delegate GetScheduleWithDelay_JLjava_lang_Runnable_Handler()
		{
			if ((object)cb_scheduleWithDelay_JLjava_lang_Runnable_ == null)
			{
				cb_scheduleWithDelay_JLjava_lang_Runnable_ = JNINativeWrapper.CreateDelegate(new _JniMarshal_PPJL_V(n_ScheduleWithDelay_JLjava_lang_Runnable_));
			}
			return cb_scheduleWithDelay_JLjava_lang_Runnable_;
		}

		private static void n_ScheduleWithDelay_JLjava_lang_Runnable_(IntPtr jnienv, IntPtr native__this, long delayInMillis, IntPtr native_runnable)
		{
			IRunnableScheduler runnableScheduler = Java.Lang.Object.GetObject<IRunnableScheduler>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable runnable = Java.Lang.Object.GetObject<IRunnable>(native_runnable, JniHandleOwnership.DoNotTransfer);
			runnableScheduler.ScheduleWithDelay(delayInMillis, runnable);
		}

		public unsafe void ScheduleWithDelay(long delayInMillis, IRunnable runnable)
		{
			if (id_scheduleWithDelay_JLjava_lang_Runnable_ == IntPtr.Zero)
			{
				id_scheduleWithDelay_JLjava_lang_Runnable_ = JNIEnv.GetMethodID(class_ref, "scheduleWithDelay", "(JLjava/lang/Runnable;)V");
			}
			JValue* ptr = stackalloc JValue[2];
			*ptr = new JValue(delayInMillis);
			ptr[1] = new JValue((runnable == null) ? IntPtr.Zero : ((Java.Lang.Object)runnable).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_scheduleWithDelay_JLjava_lang_Runnable_, ptr);
		}
	}
	[Register("androidx/work/ListenableWorker", DoNotGenerateAcw = true)]
	public abstract class ListenableWorker : Java.Lang.Object
	{
		[Register("androidx/work/ListenableWorker$Result", DoNotGenerateAcw = true)]
		public abstract class Result : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/ListenableWorker$Result", typeof(Result));

			private static Delegate cb_getOutputData;

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

			public abstract Data OutputData
			{
				[Register("getOutputData", "()Landroidx/work/Data;", "GetGetOutputDataHandler")]
				get;
			}

			protected Result(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			private static Delegate GetGetOutputDataHandler()
			{
				if ((object)cb_getOutputData == null)
				{
					cb_getOutputData = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetOutputData));
				}
				return cb_getOutputData;
			}

			private static IntPtr n_GetOutputData(IntPtr jnienv, IntPtr native__this)
			{
				return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Result>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OutputData);
			}

			[Register("failure", "()Landroidx/work/ListenableWorker$Result;", "")]
			public unsafe static Result InvokeFailure()
			{
				return Java.Lang.Object.GetObject<Result>(_members.StaticMethods.InvokeObjectMethod("failure.()Landroidx/work/ListenableWorker$Result;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("failure", "(Landroidx/work/Data;)Landroidx/work/ListenableWorker$Result;", "")]
			public unsafe static Result InvokeFailure(Data outputData)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(outputData?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Result>(_members.StaticMethods.InvokeObjectMethod("failure.(Landroidx/work/Data;)Landroidx/work/ListenableWorker$Result;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(outputData);
				}
			}

			[Register("retry", "()Landroidx/work/ListenableWorker$Result;", "")]
			public unsafe static Result InvokeRetry()
			{
				return Java.Lang.Object.GetObject<Result>(_members.StaticMethods.InvokeObjectMethod("retry.()Landroidx/work/ListenableWorker$Result;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("success", "()Landroidx/work/ListenableWorker$Result;", "")]
			public unsafe static Result InvokeSuccess()
			{
				return Java.Lang.Object.GetObject<Result>(_members.StaticMethods.InvokeObjectMethod("success.()Landroidx/work/ListenableWorker$Result;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}

			[Register("success", "(Landroidx/work/Data;)Landroidx/work/ListenableWorker$Result;", "")]
			public unsafe static Result InvokeSuccess(Data outputData)
			{
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(outputData?.Handle ?? IntPtr.Zero);
					return Java.Lang.Object.GetObject<Result>(_members.StaticMethods.InvokeObjectMethod("success.(Landroidx/work/Data;)Landroidx/work/ListenableWorker$Result;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					GC.KeepAlive(outputData);
				}
			}
		}

		[Register("androidx/work/ListenableWorker$Result", DoNotGenerateAcw = true)]
		internal class ResultInvoker : Result
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/ListenableWorker$Result", typeof(ResultInvoker));

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			public override JniPeerMembers JniPeerMembers => _members;

			[DebuggerBrowsable(DebuggerBrowsableState.Never)]
			[EditorBrowsable(EditorBrowsableState.Never)]
			protected override Type ThresholdType => _members.ManagedPeerType;

			public unsafe override Data OutputData
			{
				[Register("getOutputData", "()Landroidx/work/Data;", "GetGetOutputDataHandler")]
				get
				{
					return Java.Lang.Object.GetObject<Data>(_members.InstanceMethods.InvokeAbstractObjectMethod("getOutputData.()Landroidx/work/Data;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
				}
			}

			public ResultInvoker(IntPtr handle, JniHandleOwnership transfer)
				: base(handle, transfer)
			{
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/ListenableWorker", typeof(ListenableWorker));

		private static Delegate cb_getBackgroundExecutor;

		private static Delegate cb_getForegroundInfoAsync;

		private static Delegate cb_isRunInForeground;

		private static Delegate cb_setRunInForeground_Z;

		private static Delegate cb_getTaskExecutor;

		private static Delegate cb_getWorkerFactory;

		private static Delegate cb_onStopped;

		private static Delegate cb_setProgressAsync_Landroidx_work_Data_;

		private static Delegate cb_startWork;

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

		public unsafe Context ApplicationContext
		{
			[Register("getApplicationContext", "()Landroid/content/Context;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Context>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getApplicationContext.()Landroid/content/Context;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual IExecutor BackgroundExecutor
		{
			[Register("getBackgroundExecutor", "()Ljava/util/concurrent/Executor;", "GetGetBackgroundExecutorHandler")]
			get
			{
				return Java.Lang.Object.GetObject<IExecutor>(_members.InstanceMethods.InvokeVirtualObjectMethod("getBackgroundExecutor.()Ljava/util/concurrent/Executor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual IListenableFuture ForegroundInfoAsync
		{
			[Register("getForegroundInfoAsync", "()Lcom/google/common/util/concurrent/ListenableFuture;", "GetGetForegroundInfoAsyncHandler")]
			get
			{
				return Java.Lang.Object.GetObject<IListenableFuture>(_members.InstanceMethods.InvokeVirtualObjectMethod("getForegroundInfoAsync.()Lcom/google/common/util/concurrent/ListenableFuture;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe UUID Id
		{
			[Register("getId", "()Ljava/util/UUID;", "")]
			get
			{
				return Java.Lang.Object.GetObject<UUID>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getId.()Ljava/util/UUID;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Data InputData
		{
			[Register("getInputData", "()Landroidx/work/Data;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Data>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getInputData.()Landroidx/work/Data;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe bool IsStopped
		{
			[Register("isStopped", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isStopped.()Z", this, null);
			}
		}

		public unsafe bool IsUsed
		{
			[Register("isUsed", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualBooleanMethod("isUsed.()Z", this, null);
			}
		}

		public unsafe Network Network
		{
			[Register("getNetwork", "()Landroid/net/Network;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Network>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getNetwork.()Landroid/net/Network;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int RunAttemptCount
		{
			[Register("getRunAttemptCount", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeNonvirtualInt32Method("getRunAttemptCount.()I", this, null);
			}
		}

		public unsafe virtual bool RunInForeground
		{
			[Register("isRunInForeground", "()Z", "GetIsRunInForegroundHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("isRunInForeground.()Z", this, null);
			}
			[Register("setRunInForeground", "(Z)V", "GetSetRunInForeground_ZHandler")]
			set
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(value);
				_members.InstanceMethods.InvokeVirtualVoidMethod("setRunInForeground.(Z)V", this, ptr);
			}
		}

		public unsafe ICollection<string> Tags
		{
			[Register("getTags", "()Ljava/util/Set;", "")]
			get
			{
				return JavaSet<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTags.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual ITaskExecutor TaskExecutor
		{
			[Register("getTaskExecutor", "()Landroidx/work/impl/utils/taskexecutor/TaskExecutor;", "GetGetTaskExecutorHandler")]
			get
			{
				return Java.Lang.Object.GetObject<ITaskExecutor>(_members.InstanceMethods.InvokeVirtualObjectMethod("getTaskExecutor.()Landroidx/work/impl/utils/taskexecutor/TaskExecutor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IList<string> TriggeredContentAuthorities
		{
			[Register("getTriggeredContentAuthorities", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTriggeredContentAuthorities.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IList<Android.Net.Uri> TriggeredContentUris
		{
			[Register("getTriggeredContentUris", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<Android.Net.Uri>.FromJniHandle(_members.InstanceMethods.InvokeNonvirtualObjectMethod("getTriggeredContentUris.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual WorkerFactory WorkerFactory
		{
			[Register("getWorkerFactory", "()Landroidx/work/WorkerFactory;", "GetGetWorkerFactoryHandler")]
			get
			{
				return Java.Lang.Object.GetObject<WorkerFactory>(_members.InstanceMethods.InvokeVirtualObjectMethod("getWorkerFactory.()Landroidx/work/WorkerFactory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected ListenableWorker(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Landroidx/work/WorkerParameters;)V", "")]
		public unsafe ListenableWorker(Context appContext, WorkerParameters workerParams)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(appContext?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(workerParams?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroidx/work/WorkerParameters;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroidx/work/WorkerParameters;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(appContext);
				GC.KeepAlive(workerParams);
			}
		}

		private static Delegate GetGetBackgroundExecutorHandler()
		{
			if ((object)cb_getBackgroundExecutor == null)
			{
				cb_getBackgroundExecutor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBackgroundExecutor));
			}
			return cb_getBackgroundExecutor;
		}

		private static IntPtr n_GetBackgroundExecutor(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ListenableWorker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BackgroundExecutor);
		}

		private static Delegate GetGetForegroundInfoAsyncHandler()
		{
			if ((object)cb_getForegroundInfoAsync == null)
			{
				cb_getForegroundInfoAsync = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetForegroundInfoAsync));
			}
			return cb_getForegroundInfoAsync;
		}

		private static IntPtr n_GetForegroundInfoAsync(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ListenableWorker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).ForegroundInfoAsync);
		}

		private static Delegate GetIsRunInForegroundHandler()
		{
			if ((object)cb_isRunInForeground == null)
			{
				cb_isRunInForeground = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_IsRunInForeground));
			}
			return cb_isRunInForeground;
		}

		private static bool n_IsRunInForeground(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<ListenableWorker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RunInForeground;
		}

		private static Delegate GetSetRunInForeground_ZHandler()
		{
			if ((object)cb_setRunInForeground_Z == null)
			{
				cb_setRunInForeground_Z = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPZ_V(n_SetRunInForeground_Z));
			}
			return cb_setRunInForeground_Z;
		}

		private static void n_SetRunInForeground_Z(IntPtr jnienv, IntPtr native__this, bool runInForeground)
		{
			Java.Lang.Object.GetObject<ListenableWorker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).RunInForeground = runInForeground;
		}

		private static Delegate GetGetTaskExecutorHandler()
		{
			if ((object)cb_getTaskExecutor == null)
			{
				cb_getTaskExecutor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTaskExecutor));
			}
			return cb_getTaskExecutor;
		}

		private static IntPtr n_GetTaskExecutor(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ListenableWorker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).TaskExecutor);
		}

		private static Delegate GetGetWorkerFactoryHandler()
		{
			if ((object)cb_getWorkerFactory == null)
			{
				cb_getWorkerFactory = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetWorkerFactory));
			}
			return cb_getWorkerFactory;
		}

		private static IntPtr n_GetWorkerFactory(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ListenableWorker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WorkerFactory);
		}

		private static Delegate GetOnStoppedHandler()
		{
			if ((object)cb_onStopped == null)
			{
				cb_onStopped = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_V(n_OnStopped));
			}
			return cb_onStopped;
		}

		private static void n_OnStopped(IntPtr jnienv, IntPtr native__this)
		{
			Java.Lang.Object.GetObject<ListenableWorker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).OnStopped();
		}

		[Register("onStopped", "()V", "GetOnStoppedHandler")]
		public unsafe virtual void OnStopped()
		{
			_members.InstanceMethods.InvokeVirtualVoidMethod("onStopped.()V", this, null);
		}

		[Register("setForegroundAsync", "(Landroidx/work/ForegroundInfo;)Lcom/google/common/util/concurrent/ListenableFuture;", "")]
		public unsafe IListenableFuture SetForegroundAsync(ForegroundInfo foregroundInfo)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(foregroundInfo?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IListenableFuture>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("setForegroundAsync.(Landroidx/work/ForegroundInfo;)Lcom/google/common/util/concurrent/ListenableFuture;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(foregroundInfo);
			}
		}

		private static Delegate GetSetProgressAsync_Landroidx_work_Data_Handler()
		{
			if ((object)cb_setProgressAsync_Landroidx_work_Data_ == null)
			{
				cb_setProgressAsync_Landroidx_work_Data_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_SetProgressAsync_Landroidx_work_Data_));
			}
			return cb_setProgressAsync_Landroidx_work_Data_;
		}

		private static IntPtr n_SetProgressAsync_Landroidx_work_Data_(IntPtr jnienv, IntPtr native__this, IntPtr native_data)
		{
			ListenableWorker listenableWorker = Java.Lang.Object.GetObject<ListenableWorker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Data progressAsync = Java.Lang.Object.GetObject<Data>(native_data, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(listenableWorker.SetProgressAsync(progressAsync));
		}

		[Register("setProgressAsync", "(Landroidx/work/Data;)Lcom/google/common/util/concurrent/ListenableFuture;", "GetSetProgressAsync_Landroidx_work_Data_Handler")]
		public unsafe virtual IListenableFuture SetProgressAsync(Data data)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(data?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IListenableFuture>(_members.InstanceMethods.InvokeVirtualObjectMethod("setProgressAsync.(Landroidx/work/Data;)Lcom/google/common/util/concurrent/ListenableFuture;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(data);
			}
		}

		[Register("setUsed", "()V", "")]
		public unsafe void SetUsed()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("setUsed.()V", this, null);
		}

		private static Delegate GetStartWorkHandler()
		{
			if ((object)cb_startWork == null)
			{
				cb_startWork = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_StartWork));
			}
			return cb_startWork;
		}

		private static IntPtr n_StartWork(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ListenableWorker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StartWork());
		}

		[Register("startWork", "()Lcom/google/common/util/concurrent/ListenableFuture;", "GetStartWorkHandler")]
		public abstract IListenableFuture StartWork();

		[Register("stop", "()V", "")]
		public unsafe void Stop()
		{
			_members.InstanceMethods.InvokeNonvirtualVoidMethod("stop.()V", this, null);
		}
	}
	[Register("androidx/work/ListenableWorker", DoNotGenerateAcw = true)]
	internal class ListenableWorkerInvoker : ListenableWorker
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/ListenableWorker", typeof(ListenableWorkerInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public ListenableWorkerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("startWork", "()Lcom/google/common/util/concurrent/ListenableFuture;", "GetStartWorkHandler")]
		public unsafe override IListenableFuture StartWork()
		{
			return Java.Lang.Object.GetObject<IListenableFuture>(_members.InstanceMethods.InvokeAbstractObjectMethod("startWork.()Lcom/google/common/util/concurrent/ListenableFuture;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("androidx/work/NetworkType", DoNotGenerateAcw = true)]
	public sealed class NetworkType : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/NetworkType", typeof(NetworkType));

		[Register("CONNECTED")]
		public static NetworkType Connected => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("CONNECTED.Landroidx/work/NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("METERED")]
		public static NetworkType Metered => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("METERED.Landroidx/work/NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NOT_REQUIRED")]
		public static NetworkType NotRequired => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("NOT_REQUIRED.Landroidx/work/NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("NOT_ROAMING")]
		public static NetworkType NotRoaming => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("NOT_ROAMING.Landroidx/work/NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("TEMPORARILY_UNMETERED")]
		public static NetworkType TemporarilyUnmetered => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("TEMPORARILY_UNMETERED.Landroidx/work/NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("UNMETERED")]
		public static NetworkType Unmetered => Java.Lang.Object.GetObject<NetworkType>(_members.StaticFields.GetObjectValue("UNMETERED.Landroidx/work/NetworkType;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal NetworkType(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/work/NetworkType;", "")]
		public unsafe static NetworkType ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<NetworkType>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/work/NetworkType;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Landroidx/work/NetworkType;", "")]
		public unsafe static NetworkType[] Values()
		{
			return (NetworkType[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/work/NetworkType;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(NetworkType));
		}
	}
	[Register("androidx/work/OutOfQuotaPolicy", DoNotGenerateAcw = true)]
	public sealed class OutOfQuotaPolicy : Java.Lang.Enum
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/OutOfQuotaPolicy", typeof(OutOfQuotaPolicy));

		[Register("DROP_WORK_REQUEST")]
		public static OutOfQuotaPolicy DropWorkRequest => Java.Lang.Object.GetObject<OutOfQuotaPolicy>(_members.StaticFields.GetObjectValue("DROP_WORK_REQUEST.Landroidx/work/OutOfQuotaPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("RUN_AS_NON_EXPEDITED_WORK_REQUEST")]
		public static OutOfQuotaPolicy RunAsNonExpeditedWorkRequest => Java.Lang.Object.GetObject<OutOfQuotaPolicy>(_members.StaticFields.GetObjectValue("RUN_AS_NON_EXPEDITED_WORK_REQUEST.Landroidx/work/OutOfQuotaPolicy;").Handle, JniHandleOwnership.TransferLocalRef);

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

		internal OutOfQuotaPolicy(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("valueOf", "(Ljava/lang/String;)Landroidx/work/OutOfQuotaPolicy;", "")]
		public unsafe static OutOfQuotaPolicy ValueOf(string name)
		{
			IntPtr intPtr = JNIEnv.NewString(name);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<OutOfQuotaPolicy>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/work/OutOfQuotaPolicy;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("values", "()[Landroidx/work/OutOfQuotaPolicy;", "")]
		public unsafe static OutOfQuotaPolicy[] Values()
		{
			return (OutOfQuotaPolicy[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/work/OutOfQuotaPolicy;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(OutOfQuotaPolicy));
		}
	}
	[Register("androidx/work/WorkContinuation", DoNotGenerateAcw = true)]
	public abstract class WorkContinuation : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/WorkContinuation", typeof(WorkContinuation));

		private static Delegate cb_getWorkInfos;

		private static Delegate cb_getWorkInfosLiveData;

		private static Delegate cb_combineInternal_Ljava_util_List_;

		private static Delegate cb_enqueue;

		private static Delegate cb_then_Ljava_util_List_;

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

		public abstract IListenableFuture WorkInfos
		{
			[Register("getWorkInfos", "()Lcom/google/common/util/concurrent/ListenableFuture;", "GetGetWorkInfosHandler")]
			get;
		}

		public abstract LiveData WorkInfosLiveData
		{
			[Register("getWorkInfosLiveData", "()Landroidx/lifecycle/LiveData;", "GetGetWorkInfosLiveDataHandler")]
			get;
		}

		protected WorkContinuation(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe WorkContinuation()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetWorkInfosHandler()
		{
			if ((object)cb_getWorkInfos == null)
			{
				cb_getWorkInfos = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetWorkInfos));
			}
			return cb_getWorkInfos;
		}

		private static IntPtr n_GetWorkInfos(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WorkContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WorkInfos);
		}

		private static Delegate GetGetWorkInfosLiveDataHandler()
		{
			if ((object)cb_getWorkInfosLiveData == null)
			{
				cb_getWorkInfosLiveData = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetWorkInfosLiveData));
			}
			return cb_getWorkInfosLiveData;
		}

		private static IntPtr n_GetWorkInfosLiveData(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WorkContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WorkInfosLiveData);
		}

		[Register("combine", "(Ljava/util/List;)Landroidx/work/WorkContinuation;", "")]
		public unsafe static WorkContinuation Combine(IList<WorkContinuation> continuations)
		{
			IntPtr intPtr = JavaList<WorkContinuation>.ToLocalJniHandle(continuations);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<WorkContinuation>(_members.StaticMethods.InvokeObjectMethod("combine.(Ljava/util/List;)Landroidx/work/WorkContinuation;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(continuations);
			}
		}

		private static Delegate GetCombineInternal_Ljava_util_List_Handler()
		{
			if ((object)cb_combineInternal_Ljava_util_List_ == null)
			{
				cb_combineInternal_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_CombineInternal_Ljava_util_List_));
			}
			return cb_combineInternal_Ljava_util_List_;
		}

		private static IntPtr n_CombineInternal_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_continuations)
		{
			WorkContinuation workContinuation = Java.Lang.Object.GetObject<WorkContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<WorkContinuation> continuations = JavaList<WorkContinuation>.FromJniHandle(native_continuations, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(workContinuation.CombineInternal(continuations));
		}

		[Register("combineInternal", "(Ljava/util/List;)Landroidx/work/WorkContinuation;", "GetCombineInternal_Ljava_util_List_Handler")]
		protected abstract WorkContinuation CombineInternal(IList<WorkContinuation> continuations);

		private static Delegate GetEnqueueHandler()
		{
			if ((object)cb_enqueue == null)
			{
				cb_enqueue = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_Enqueue));
			}
			return cb_enqueue;
		}

		private static IntPtr n_Enqueue(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WorkContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Enqueue());
		}

		[Register("enqueue", "()Landroidx/work/Operation;", "GetEnqueueHandler")]
		public abstract IOperation Enqueue();

		[Register("then", "(Landroidx/work/OneTimeWorkRequest;)Landroidx/work/WorkContinuation;", "")]
		public unsafe WorkContinuation Then(OneTimeWorkRequest work)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(work?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<WorkContinuation>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("then.(Landroidx/work/OneTimeWorkRequest;)Landroidx/work/WorkContinuation;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(work);
			}
		}

		private static Delegate GetThen_Ljava_util_List_Handler()
		{
			if ((object)cb_then_Ljava_util_List_ == null)
			{
				cb_then_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Then_Ljava_util_List_));
			}
			return cb_then_Ljava_util_List_;
		}

		private static IntPtr n_Then_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_work)
		{
			WorkContinuation workContinuation = Java.Lang.Object.GetObject<WorkContinuation>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<OneTimeWorkRequest> work = JavaList<OneTimeWorkRequest>.FromJniHandle(native_work, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(workContinuation.Then(work));
		}

		[Register("then", "(Ljava/util/List;)Landroidx/work/WorkContinuation;", "GetThen_Ljava_util_List_Handler")]
		public abstract WorkContinuation Then(IList<OneTimeWorkRequest> work);
	}
	[Register("androidx/work/WorkContinuation", DoNotGenerateAcw = true)]
	internal class WorkContinuationInvoker : WorkContinuation
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/WorkContinuation", typeof(WorkContinuationInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override IListenableFuture WorkInfos
		{
			[Register("getWorkInfos", "()Lcom/google/common/util/concurrent/ListenableFuture;", "GetGetWorkInfosHandler")]
			get
			{
				return Java.Lang.Object.GetObject<IListenableFuture>(_members.InstanceMethods.InvokeAbstractObjectMethod("getWorkInfos.()Lcom/google/common/util/concurrent/ListenableFuture;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override LiveData WorkInfosLiveData
		{
			[Register("getWorkInfosLiveData", "()Landroidx/lifecycle/LiveData;", "GetGetWorkInfosLiveDataHandler")]
			get
			{
				return Java.Lang.Object.GetObject<LiveData>(_members.InstanceMethods.InvokeAbstractObjectMethod("getWorkInfosLiveData.()Landroidx/lifecycle/LiveData;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public WorkContinuationInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("combineInternal", "(Ljava/util/List;)Landroidx/work/WorkContinuation;", "GetCombineInternal_Ljava_util_List_Handler")]
		protected unsafe override WorkContinuation CombineInternal(IList<WorkContinuation> continuations)
		{
			IntPtr intPtr = JavaList<WorkContinuation>.ToLocalJniHandle(continuations);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<WorkContinuation>(_members.InstanceMethods.InvokeAbstractObjectMethod("combineInternal.(Ljava/util/List;)Landroidx/work/WorkContinuation;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(continuations);
			}
		}

		[Register("enqueue", "()Landroidx/work/Operation;", "GetEnqueueHandler")]
		public unsafe override IOperation Enqueue()
		{
			return Java.Lang.Object.GetObject<IOperation>(_members.InstanceMethods.InvokeAbstractObjectMethod("enqueue.()Landroidx/work/Operation;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("then", "(Ljava/util/List;)Landroidx/work/WorkContinuation;", "GetThen_Ljava_util_List_Handler")]
		public unsafe override WorkContinuation Then(IList<OneTimeWorkRequest> work)
		{
			IntPtr intPtr = JavaList<OneTimeWorkRequest>.ToLocalJniHandle(work);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<WorkContinuation>(_members.InstanceMethods.InvokeAbstractObjectMethod("then.(Ljava/util/List;)Landroidx/work/WorkContinuation;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(work);
			}
		}
	}
	[Register("androidx/work/Worker", DoNotGenerateAcw = true)]
	public abstract class Worker : ListenableWorker
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/Worker", typeof(Worker));

		private static Delegate cb_doWork;

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

		protected Worker(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroid/content/Context;Landroidx/work/WorkerParameters;)V", "")]
		public unsafe Worker(Context context, WorkerParameters workerParams)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(workerParams?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroid/content/Context;Landroidx/work/WorkerParameters;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroid/content/Context;Landroidx/work/WorkerParameters;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(workerParams);
			}
		}

		private static Delegate GetDoWorkHandler()
		{
			if ((object)cb_doWork == null)
			{
				cb_doWork = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_DoWork));
			}
			return cb_doWork;
		}

		private static IntPtr n_DoWork(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<Worker>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DoWork());
		}

		[Register("doWork", "()Landroidx/work/ListenableWorker$Result;", "GetDoWorkHandler")]
		public abstract Result DoWork();

		[Register("startWork", "()Lcom/google/common/util/concurrent/ListenableFuture;", "")]
		public unsafe sealed override IListenableFuture StartWork()
		{
			return Java.Lang.Object.GetObject<IListenableFuture>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("startWork.()Lcom/google/common/util/concurrent/ListenableFuture;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("androidx/work/Worker", DoNotGenerateAcw = true)]
	internal class WorkerInvoker : Worker
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/Worker", typeof(WorkerInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public WorkerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("doWork", "()Landroidx/work/ListenableWorker$Result;", "GetDoWorkHandler")]
		public unsafe override Result DoWork()
		{
			return Java.Lang.Object.GetObject<Result>(_members.InstanceMethods.InvokeAbstractObjectMethod("doWork.()Landroidx/work/ListenableWorker$Result;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("androidx/work/WorkerFactory", DoNotGenerateAcw = true)]
	public abstract class WorkerFactory : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/WorkerFactory", typeof(WorkerFactory));

		private static Delegate cb_createWorker_Landroid_content_Context_Ljava_lang_String_Landroidx_work_WorkerParameters_;

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

		public unsafe static WorkerFactory DefaultWorkerFactory
		{
			[Register("getDefaultWorkerFactory", "()Landroidx/work/WorkerFactory;", "")]
			get
			{
				return Java.Lang.Object.GetObject<WorkerFactory>(_members.StaticMethods.InvokeObjectMethod("getDefaultWorkerFactory.()Landroidx/work/WorkerFactory;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected WorkerFactory(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		public unsafe WorkerFactory()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetCreateWorker_Landroid_content_Context_Ljava_lang_String_Landroidx_work_WorkerParameters_Handler()
		{
			if ((object)cb_createWorker_Landroid_content_Context_Ljava_lang_String_Landroidx_work_WorkerParameters_ == null)
			{
				cb_createWorker_Landroid_content_Context_Ljava_lang_String_Landroidx_work_WorkerParameters_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_CreateWorker_Landroid_content_Context_Ljava_lang_String_Landroidx_work_WorkerParameters_));
			}
			return cb_createWorker_Landroid_content_Context_Ljava_lang_String_Landroidx_work_WorkerParameters_;
		}

		private static IntPtr n_CreateWorker_Landroid_content_Context_Ljava_lang_String_Landroidx_work_WorkerParameters_(IntPtr jnienv, IntPtr native__this, IntPtr native_appContext, IntPtr native_workerClassName, IntPtr native_workerParameters)
		{
			WorkerFactory workerFactory = Java.Lang.Object.GetObject<WorkerFactory>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			Context appContext = Java.Lang.Object.GetObject<Context>(native_appContext, JniHandleOwnership.DoNotTransfer);
			string workerClassName = JNIEnv.GetString(native_workerClassName, JniHandleOwnership.DoNotTransfer);
			WorkerParameters workerParameters = Java.Lang.Object.GetObject<WorkerParameters>(native_workerParameters, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(workerFactory.CreateWorker(appContext, workerClassName, workerParameters));
		}

		[Register("createWorker", "(Landroid/content/Context;Ljava/lang/String;Landroidx/work/WorkerParameters;)Landroidx/work/ListenableWorker;", "GetCreateWorker_Landroid_content_Context_Ljava_lang_String_Landroidx_work_WorkerParameters_Handler")]
		public abstract ListenableWorker CreateWorker(Context appContext, string workerClassName, WorkerParameters workerParameters);

		[Register("createWorkerWithDefaultFallback", "(Landroid/content/Context;Ljava/lang/String;Landroidx/work/WorkerParameters;)Landroidx/work/ListenableWorker;", "")]
		public unsafe ListenableWorker CreateWorkerWithDefaultFallback(Context appContext, string workerClassName, WorkerParameters workerParameters)
		{
			IntPtr intPtr = JNIEnv.NewString(workerClassName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(appContext?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(workerParameters?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ListenableWorker>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("createWorkerWithDefaultFallback.(Landroid/content/Context;Ljava/lang/String;Landroidx/work/WorkerParameters;)Landroidx/work/ListenableWorker;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(appContext);
				GC.KeepAlive(workerParameters);
			}
		}
	}
	[Register("androidx/work/WorkerFactory", DoNotGenerateAcw = true)]
	internal class WorkerFactoryInvoker : WorkerFactory
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/WorkerFactory", typeof(WorkerFactoryInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public WorkerFactoryInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("createWorker", "(Landroid/content/Context;Ljava/lang/String;Landroidx/work/WorkerParameters;)Landroidx/work/ListenableWorker;", "GetCreateWorker_Landroid_content_Context_Ljava_lang_String_Landroidx_work_WorkerParameters_Handler")]
		public unsafe override ListenableWorker CreateWorker(Context appContext, string workerClassName, WorkerParameters workerParameters)
		{
			IntPtr intPtr = JNIEnv.NewString(workerClassName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(appContext?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(intPtr);
				ptr[2] = new JniArgumentValue(workerParameters?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<ListenableWorker>(_members.InstanceMethods.InvokeAbstractObjectMethod("createWorker.(Landroid/content/Context;Ljava/lang/String;Landroidx/work/WorkerParameters;)Landroidx/work/ListenableWorker;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(appContext);
				GC.KeepAlive(workerParameters);
			}
		}
	}
	[Register("androidx/work/WorkerParameters", DoNotGenerateAcw = true)]
	public sealed class WorkerParameters : Java.Lang.Object
	{
		[Register("androidx/work/WorkerParameters$RuntimeExtras", DoNotGenerateAcw = true)]
		public class RuntimeExtras : Java.Lang.Object
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/WorkerParameters$RuntimeExtras", typeof(RuntimeExtras));

			[Register("network")]
			public Network Network
			{
				get
				{
					return Java.Lang.Object.GetObject<Network>(_members.InstanceFields.GetObjectValue("network.Landroid/net/Network;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
					try
					{
						_members.InstanceFields.SetValue("network.Landroid/net/Network;", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("triggeredContentAuthorities")]
			public System.Collections.IList TriggeredContentAuthorities
			{
				get
				{
					return JavaList.FromJniHandle(_members.InstanceFields.GetObjectValue("triggeredContentAuthorities.Ljava/util/List;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JavaList.ToLocalJniHandle(value);
					try
					{
						_members.InstanceFields.SetValue("triggeredContentAuthorities.Ljava/util/List;", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
				}
			}

			[Register("triggeredContentUris")]
			public System.Collections.IList TriggeredContentUris
			{
				get
				{
					return JavaList.FromJniHandle(_members.InstanceFields.GetObjectValue("triggeredContentUris.Ljava/util/List;", this).Handle, JniHandleOwnership.TransferLocalRef);
				}
				set
				{
					IntPtr jobject = JavaList.ToLocalJniHandle(value);
					try
					{
						_members.InstanceFields.SetValue("triggeredContentUris.Ljava/util/List;", this, new JniObjectReference(jobject));
					}
					finally
					{
						JNIEnv.DeleteLocalRef(jobject);
					}
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

			protected RuntimeExtras(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register(".ctor", "()V", "")]
			public unsafe RuntimeExtras()
				: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
			{
				if (!(base.Handle != IntPtr.Zero))
				{
					SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
					_members.InstanceMethods.FinishCreateInstance("()V", this, null);
				}
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/WorkerParameters", typeof(WorkerParameters));

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

		public unsafe IExecutor BackgroundExecutor
		{
			[Register("getBackgroundExecutor", "()Ljava/util/concurrent/Executor;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IExecutor>(_members.InstanceMethods.InvokeAbstractObjectMethod("getBackgroundExecutor.()Ljava/util/concurrent/Executor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IForegroundUpdater ForegroundUpdater
		{
			[Register("getForegroundUpdater", "()Landroidx/work/ForegroundUpdater;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IForegroundUpdater>(_members.InstanceMethods.InvokeAbstractObjectMethod("getForegroundUpdater.()Landroidx/work/ForegroundUpdater;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe UUID Id
		{
			[Register("getId", "()Ljava/util/UUID;", "")]
			get
			{
				return Java.Lang.Object.GetObject<UUID>(_members.InstanceMethods.InvokeAbstractObjectMethod("getId.()Ljava/util/UUID;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Data InputData
		{
			[Register("getInputData", "()Landroidx/work/Data;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Data>(_members.InstanceMethods.InvokeAbstractObjectMethod("getInputData.()Landroidx/work/Data;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Network Network
		{
			[Register("getNetwork", "()Landroid/net/Network;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Network>(_members.InstanceMethods.InvokeAbstractObjectMethod("getNetwork.()Landroid/net/Network;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IProgressUpdater ProgressUpdater
		{
			[Register("getProgressUpdater", "()Landroidx/work/ProgressUpdater;", "")]
			get
			{
				return Java.Lang.Object.GetObject<IProgressUpdater>(_members.InstanceMethods.InvokeAbstractObjectMethod("getProgressUpdater.()Landroidx/work/ProgressUpdater;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int RunAttemptCount
		{
			[Register("getRunAttemptCount", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getRunAttemptCount.()I", this, null);
			}
		}

		public unsafe ICollection<string> Tags
		{
			[Register("getTags", "()Ljava/util/Set;", "")]
			get
			{
				return JavaSet<string>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getTags.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe ITaskExecutor TaskExecutor
		{
			[Register("getTaskExecutor", "()Landroidx/work/impl/utils/taskexecutor/TaskExecutor;", "")]
			get
			{
				return Java.Lang.Object.GetObject<ITaskExecutor>(_members.InstanceMethods.InvokeAbstractObjectMethod("getTaskExecutor.()Landroidx/work/impl/utils/taskexecutor/TaskExecutor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IList<string> TriggeredContentAuthorities
		{
			[Register("getTriggeredContentAuthorities", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getTriggeredContentAuthorities.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IList<Android.Net.Uri> TriggeredContentUris
		{
			[Register("getTriggeredContentUris", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<Android.Net.Uri>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getTriggeredContentUris.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe WorkerFactory WorkerFactory
		{
			[Register("getWorkerFactory", "()Landroidx/work/WorkerFactory;", "")]
			get
			{
				return Java.Lang.Object.GetObject<WorkerFactory>(_members.InstanceMethods.InvokeAbstractObjectMethod("getWorkerFactory.()Landroidx/work/WorkerFactory;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal WorkerParameters(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/util/UUID;Landroidx/work/Data;Ljava/util/Collection;Landroidx/work/WorkerParameters$RuntimeExtras;ILjava/util/concurrent/Executor;Landroidx/work/impl/utils/taskexecutor/TaskExecutor;Landroidx/work/WorkerFactory;Landroidx/work/ProgressUpdater;Landroidx/work/ForegroundUpdater;)V", "")]
		public unsafe WorkerParameters(UUID id, Data inputData, ICollection<string> tags, RuntimeExtras runtimeExtras, int runAttemptCount, IExecutor backgroundExecutor, ITaskExecutor workTaskExecutor, WorkerFactory workerFactory, IProgressUpdater progressUpdater, IForegroundUpdater foregroundUpdater)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JavaCollection<string>.ToLocalJniHandle(tags);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[10];
				*ptr = new JniArgumentValue(id?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(inputData?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				ptr[3] = new JniArgumentValue(runtimeExtras?.Handle ?? IntPtr.Zero);
				ptr[4] = new JniArgumentValue(runAttemptCount);
				ptr[5] = new JniArgumentValue((backgroundExecutor == null) ? IntPtr.Zero : ((Java.Lang.Object)backgroundExecutor).Handle);
				ptr[6] = new JniArgumentValue((workTaskExecutor == null) ? IntPtr.Zero : ((Java.Lang.Object)workTaskExecutor).Handle);
				ptr[7] = new JniArgumentValue(workerFactory?.Handle ?? IntPtr.Zero);
				ptr[8] = new JniArgumentValue((progressUpdater == null) ? IntPtr.Zero : ((Java.Lang.Object)progressUpdater).Handle);
				ptr[9] = new JniArgumentValue((foregroundUpdater == null) ? IntPtr.Zero : ((Java.Lang.Object)foregroundUpdater).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/util/UUID;Landroidx/work/Data;Ljava/util/Collection;Landroidx/work/WorkerParameters$RuntimeExtras;ILjava/util/concurrent/Executor;Landroidx/work/impl/utils/taskexecutor/TaskExecutor;Landroidx/work/WorkerFactory;Landroidx/work/ProgressUpdater;Landroidx/work/ForegroundUpdater;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/util/UUID;Landroidx/work/Data;Ljava/util/Collection;Landroidx/work/WorkerParameters$RuntimeExtras;ILjava/util/concurrent/Executor;Landroidx/work/impl/utils/taskexecutor/TaskExecutor;Landroidx/work/WorkerFactory;Landroidx/work/ProgressUpdater;Landroidx/work/ForegroundUpdater;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(id);
				GC.KeepAlive(inputData);
				GC.KeepAlive(tags);
				GC.KeepAlive(runtimeExtras);
				GC.KeepAlive(backgroundExecutor);
				GC.KeepAlive(workTaskExecutor);
				GC.KeepAlive(workerFactory);
				GC.KeepAlive(progressUpdater);
				GC.KeepAlive(foregroundUpdater);
			}
		}

		[Register("getRuntimeExtras", "()Landroidx/work/WorkerParameters$RuntimeExtras;", "")]
		public unsafe RuntimeExtras GetRuntimeExtras()
		{
			return Java.Lang.Object.GetObject<RuntimeExtras>(_members.InstanceMethods.InvokeAbstractObjectMethod("getRuntimeExtras.()Landroidx/work/WorkerParameters$RuntimeExtras;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("androidx/work/WorkInfo", DoNotGenerateAcw = true)]
	public sealed class WorkInfo : Java.Lang.Object
	{
		[Register("androidx/work/WorkInfo$State", DoNotGenerateAcw = true)]
		public sealed class State : Java.Lang.Enum
		{
			private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/WorkInfo$State", typeof(State));

			[Register("BLOCKED")]
			public static State Blocked => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("BLOCKED.Landroidx/work/WorkInfo$State;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("CANCELLED")]
			public static State Cancelled => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("CANCELLED.Landroidx/work/WorkInfo$State;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("ENQUEUED")]
			public static State Enqueued => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("ENQUEUED.Landroidx/work/WorkInfo$State;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("FAILED")]
			public static State Failed => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("FAILED.Landroidx/work/WorkInfo$State;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("RUNNING")]
			public static State Running => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("RUNNING.Landroidx/work/WorkInfo$State;").Handle, JniHandleOwnership.TransferLocalRef);

			[Register("SUCCEEDED")]
			public static State Succeeded => Java.Lang.Object.GetObject<State>(_members.StaticFields.GetObjectValue("SUCCEEDED.Landroidx/work/WorkInfo$State;").Handle, JniHandleOwnership.TransferLocalRef);

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

			public unsafe bool IsFinished
			{
				[Register("isFinished", "()Z", "")]
				get
				{
					return _members.InstanceMethods.InvokeAbstractBooleanMethod("isFinished.()Z", this, null);
				}
			}

			internal State(IntPtr javaReference, JniHandleOwnership transfer)
				: base(javaReference, transfer)
			{
			}

			[Register("valueOf", "(Ljava/lang/String;)Landroidx/work/WorkInfo$State;", "")]
			public unsafe static State ValueOf(string name)
			{
				IntPtr intPtr = JNIEnv.NewString(name);
				try
				{
					JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
					*ptr = new JniArgumentValue(intPtr);
					return Java.Lang.Object.GetObject<State>(_members.StaticMethods.InvokeObjectMethod("valueOf.(Ljava/lang/String;)Landroidx/work/WorkInfo$State;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
				}
				finally
				{
					JNIEnv.DeleteLocalRef(intPtr);
				}
			}

			[Register("values", "()[Landroidx/work/WorkInfo$State;", "")]
			public unsafe static State[] Values()
			{
				return (State[])JNIEnv.GetArray(_members.StaticMethods.InvokeObjectMethod("values.()[Landroidx/work/WorkInfo$State;", null).Handle, JniHandleOwnership.TransferLocalRef, typeof(State));
			}
		}

		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/WorkInfo", typeof(WorkInfo));

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

		public unsafe UUID Id
		{
			[Register("getId", "()Ljava/util/UUID;", "")]
			get
			{
				return Java.Lang.Object.GetObject<UUID>(_members.InstanceMethods.InvokeAbstractObjectMethod("getId.()Ljava/util/UUID;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Data OutputData
		{
			[Register("getOutputData", "()Landroidx/work/Data;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Data>(_members.InstanceMethods.InvokeAbstractObjectMethod("getOutputData.()Landroidx/work/Data;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe Data Progress
		{
			[Register("getProgress", "()Landroidx/work/Data;", "")]
			get
			{
				return Java.Lang.Object.GetObject<Data>(_members.InstanceMethods.InvokeAbstractObjectMethod("getProgress.()Landroidx/work/Data;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe int RunAttemptCount
		{
			[Register("getRunAttemptCount", "()I", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractInt32Method("getRunAttemptCount.()I", this, null);
			}
		}

		public unsafe ICollection<string> Tags
		{
			[Register("getTags", "()Ljava/util/Set;", "")]
			get
			{
				return JavaSet<string>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getTags.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal WorkInfo(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/util/UUID;Landroidx/work/WorkInfo$State;Landroidx/work/Data;Ljava/util/List;Landroidx/work/Data;I)V", "")]
		public unsafe WorkInfo(UUID id, State state, Data outputData, IList<string> tags, Data progress, int runAttemptCount)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JavaList<string>.ToLocalJniHandle(tags);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[6];
				*ptr = new JniArgumentValue(id?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(state?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(outputData?.Handle ?? IntPtr.Zero);
				ptr[3] = new JniArgumentValue(intPtr);
				ptr[4] = new JniArgumentValue(progress?.Handle ?? IntPtr.Zero);
				ptr[5] = new JniArgumentValue(runAttemptCount);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/util/UUID;Landroidx/work/WorkInfo$State;Landroidx/work/Data;Ljava/util/List;Landroidx/work/Data;I)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/util/UUID;Landroidx/work/WorkInfo$State;Landroidx/work/Data;Ljava/util/List;Landroidx/work/Data;I)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(id);
				GC.KeepAlive(state);
				GC.KeepAlive(outputData);
				GC.KeepAlive(tags);
				GC.KeepAlive(progress);
			}
		}

		[Register("getState", "()Landroidx/work/WorkInfo$State;", "")]
		public unsafe State GetState()
		{
			return Java.Lang.Object.GetObject<State>(_members.InstanceMethods.InvokeAbstractObjectMethod("getState.()Landroidx/work/WorkInfo$State;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("androidx/work/WorkManager", DoNotGenerateAcw = true)]
	public abstract class WorkManager : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/WorkManager", typeof(WorkManager));

		private static Delegate cb_getLastCancelAllTimeMillis;

		private static Delegate cb_getLastCancelAllTimeMillisLiveData;

		private static Delegate cb_beginUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Ljava_util_List_;

		private static Delegate cb_beginWith_Ljava_util_List_;

		private static Delegate cb_cancelAllWork;

		private static Delegate cb_cancelAllWorkByTag_Ljava_lang_String_;

		private static Delegate cb_cancelUniqueWork_Ljava_lang_String_;

		private static Delegate cb_cancelWorkById_Ljava_util_UUID_;

		private static Delegate cb_createCancelPendingIntent_Ljava_util_UUID_;

		private static Delegate cb_enqueue_Ljava_util_List_;

		private static Delegate cb_enqueueUniquePeriodicWork_Ljava_lang_String_Landroidx_work_ExistingPeriodicWorkPolicy_Landroidx_work_PeriodicWorkRequest_;

		private static Delegate cb_enqueueUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Landroidx_work_OneTimeWorkRequest_;

		private static Delegate cb_enqueueUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Ljava_util_List_;

		private static Delegate cb_getWorkInfoById_Ljava_util_UUID_;

		private static Delegate cb_getWorkInfoByIdLiveData_Ljava_util_UUID_;

		private static Delegate cb_getWorkInfos_Landroidx_work_WorkQuery_;

		private static Delegate cb_getWorkInfosByTag_Ljava_lang_String_;

		private static Delegate cb_getWorkInfosByTagLiveData_Ljava_lang_String_;

		private static Delegate cb_getWorkInfosForUniqueWork_Ljava_lang_String_;

		private static Delegate cb_getWorkInfosForUniqueWorkLiveData_Ljava_lang_String_;

		private static Delegate cb_getWorkInfosLiveData_Landroidx_work_WorkQuery_;

		private static Delegate cb_pruneWork;

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

		public unsafe static WorkManager Instance
		{
			[Register("getInstance", "()Landroidx/work/WorkManager;", "")]
			get
			{
				return Java.Lang.Object.GetObject<WorkManager>(_members.StaticMethods.InvokeObjectMethod("getInstance.()Landroidx/work/WorkManager;", null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public abstract IListenableFuture LastCancelAllTimeMillis
		{
			[Register("getLastCancelAllTimeMillis", "()Lcom/google/common/util/concurrent/ListenableFuture;", "GetGetLastCancelAllTimeMillisHandler")]
			get;
		}

		public abstract LiveData LastCancelAllTimeMillisLiveData
		{
			[Register("getLastCancelAllTimeMillisLiveData", "()Landroidx/lifecycle/LiveData;", "GetGetLastCancelAllTimeMillisLiveDataHandler")]
			get;
		}

		protected WorkManager(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "()V", "")]
		protected unsafe WorkManager()
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (!(base.Handle != IntPtr.Zero))
			{
				SetHandle(_members.InstanceMethods.StartCreateInstance("()V", GetType(), null).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("()V", this, null);
			}
		}

		private static Delegate GetGetLastCancelAllTimeMillisHandler()
		{
			if ((object)cb_getLastCancelAllTimeMillis == null)
			{
				cb_getLastCancelAllTimeMillis = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLastCancelAllTimeMillis));
			}
			return cb_getLastCancelAllTimeMillis;
		}

		private static IntPtr n_GetLastCancelAllTimeMillis(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WorkManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LastCancelAllTimeMillis);
		}

		private static Delegate GetGetLastCancelAllTimeMillisLiveDataHandler()
		{
			if ((object)cb_getLastCancelAllTimeMillisLiveData == null)
			{
				cb_getLastCancelAllTimeMillisLiveData = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetLastCancelAllTimeMillisLiveData));
			}
			return cb_getLastCancelAllTimeMillisLiveData;
		}

		private static IntPtr n_GetLastCancelAllTimeMillisLiveData(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WorkManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).LastCancelAllTimeMillisLiveData);
		}

		[Register("beginUniqueWork", "(Ljava/lang/String;Landroidx/work/ExistingWorkPolicy;Landroidx/work/OneTimeWorkRequest;)Landroidx/work/WorkContinuation;", "")]
		public unsafe WorkContinuation BeginUniqueWork(string uniqueWorkName, ExistingWorkPolicy existingWorkPolicy, OneTimeWorkRequest work)
		{
			IntPtr intPtr = JNIEnv.NewString(uniqueWorkName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(existingWorkPolicy?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(work?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<WorkContinuation>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("beginUniqueWork.(Ljava/lang/String;Landroidx/work/ExistingWorkPolicy;Landroidx/work/OneTimeWorkRequest;)Landroidx/work/WorkContinuation;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(existingWorkPolicy);
				GC.KeepAlive(work);
			}
		}

		private static Delegate GetBeginUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Ljava_util_List_Handler()
		{
			if ((object)cb_beginUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Ljava_util_List_ == null)
			{
				cb_beginUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_BeginUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Ljava_util_List_));
			}
			return cb_beginUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Ljava_util_List_;
		}

		private static IntPtr n_BeginUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_uniqueWorkName, IntPtr native_existingWorkPolicy, IntPtr native_work)
		{
			WorkManager workManager = Java.Lang.Object.GetObject<WorkManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string uniqueWorkName = JNIEnv.GetString(native_uniqueWorkName, JniHandleOwnership.DoNotTransfer);
			ExistingWorkPolicy existingWorkPolicy = Java.Lang.Object.GetObject<ExistingWorkPolicy>(native_existingWorkPolicy, JniHandleOwnership.DoNotTransfer);
			IList<OneTimeWorkRequest> work = JavaList<OneTimeWorkRequest>.FromJniHandle(native_work, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(workManager.BeginUniqueWork(uniqueWorkName, existingWorkPolicy, work));
		}

		[Register("beginUniqueWork", "(Ljava/lang/String;Landroidx/work/ExistingWorkPolicy;Ljava/util/List;)Landroidx/work/WorkContinuation;", "GetBeginUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Ljava_util_List_Handler")]
		public abstract WorkContinuation BeginUniqueWork(string uniqueWorkName, ExistingWorkPolicy existingWorkPolicy, IList<OneTimeWorkRequest> work);

		[Register("beginWith", "(Landroidx/work/OneTimeWorkRequest;)Landroidx/work/WorkContinuation;", "")]
		public unsafe WorkContinuation BeginWith(OneTimeWorkRequest work)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(work?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<WorkContinuation>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("beginWith.(Landroidx/work/OneTimeWorkRequest;)Landroidx/work/WorkContinuation;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(work);
			}
		}

		private static Delegate GetBeginWith_Ljava_util_List_Handler()
		{
			if ((object)cb_beginWith_Ljava_util_List_ == null)
			{
				cb_beginWith_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_BeginWith_Ljava_util_List_));
			}
			return cb_beginWith_Ljava_util_List_;
		}

		private static IntPtr n_BeginWith_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_work)
		{
			WorkManager workManager = Java.Lang.Object.GetObject<WorkManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<OneTimeWorkRequest> work = JavaList<OneTimeWorkRequest>.FromJniHandle(native_work, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(workManager.BeginWith(work));
		}

		[Register("beginWith", "(Ljava/util/List;)Landroidx/work/WorkContinuation;", "GetBeginWith_Ljava_util_List_Handler")]
		public abstract WorkContinuation BeginWith(IList<OneTimeWorkRequest> work);

		private static Delegate GetCancelAllWorkHandler()
		{
			if ((object)cb_cancelAllWork == null)
			{
				cb_cancelAllWork = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_CancelAllWork));
			}
			return cb_cancelAllWork;
		}

		private static IntPtr n_CancelAllWork(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WorkManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).CancelAllWork());
		}

		[Register("cancelAllWork", "()Landroidx/work/Operation;", "GetCancelAllWorkHandler")]
		public abstract IOperation CancelAllWork();

		private static Delegate GetCancelAllWorkByTag_Ljava_lang_String_Handler()
		{
			if ((object)cb_cancelAllWorkByTag_Ljava_lang_String_ == null)
			{
				cb_cancelAllWorkByTag_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_CancelAllWorkByTag_Ljava_lang_String_));
			}
			return cb_cancelAllWorkByTag_Ljava_lang_String_;
		}

		private static IntPtr n_CancelAllWorkByTag_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_tag)
		{
			WorkManager workManager = Java.Lang.Object.GetObject<WorkManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string tag = JNIEnv.GetString(native_tag, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(workManager.CancelAllWorkByTag(tag));
		}

		[Register("cancelAllWorkByTag", "(Ljava/lang/String;)Landroidx/work/Operation;", "GetCancelAllWorkByTag_Ljava_lang_String_Handler")]
		public abstract IOperation CancelAllWorkByTag(string tag);

		private static Delegate GetCancelUniqueWork_Ljava_lang_String_Handler()
		{
			if ((object)cb_cancelUniqueWork_Ljava_lang_String_ == null)
			{
				cb_cancelUniqueWork_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_CancelUniqueWork_Ljava_lang_String_));
			}
			return cb_cancelUniqueWork_Ljava_lang_String_;
		}

		private static IntPtr n_CancelUniqueWork_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_uniqueWorkName)
		{
			WorkManager workManager = Java.Lang.Object.GetObject<WorkManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string uniqueWorkName = JNIEnv.GetString(native_uniqueWorkName, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(workManager.CancelUniqueWork(uniqueWorkName));
		}

		[Register("cancelUniqueWork", "(Ljava/lang/String;)Landroidx/work/Operation;", "GetCancelUniqueWork_Ljava_lang_String_Handler")]
		public abstract IOperation CancelUniqueWork(string uniqueWorkName);

		private static Delegate GetCancelWorkById_Ljava_util_UUID_Handler()
		{
			if ((object)cb_cancelWorkById_Ljava_util_UUID_ == null)
			{
				cb_cancelWorkById_Ljava_util_UUID_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_CancelWorkById_Ljava_util_UUID_));
			}
			return cb_cancelWorkById_Ljava_util_UUID_;
		}

		private static IntPtr n_CancelWorkById_Ljava_util_UUID_(IntPtr jnienv, IntPtr native__this, IntPtr native_id)
		{
			WorkManager workManager = Java.Lang.Object.GetObject<WorkManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			UUID id = Java.Lang.Object.GetObject<UUID>(native_id, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(workManager.CancelWorkById(id));
		}

		[Register("cancelWorkById", "(Ljava/util/UUID;)Landroidx/work/Operation;", "GetCancelWorkById_Ljava_util_UUID_Handler")]
		public abstract IOperation CancelWorkById(UUID id);

		private static Delegate GetCreateCancelPendingIntent_Ljava_util_UUID_Handler()
		{
			if ((object)cb_createCancelPendingIntent_Ljava_util_UUID_ == null)
			{
				cb_createCancelPendingIntent_Ljava_util_UUID_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_CreateCancelPendingIntent_Ljava_util_UUID_));
			}
			return cb_createCancelPendingIntent_Ljava_util_UUID_;
		}

		private static IntPtr n_CreateCancelPendingIntent_Ljava_util_UUID_(IntPtr jnienv, IntPtr native__this, IntPtr native_id)
		{
			WorkManager workManager = Java.Lang.Object.GetObject<WorkManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			UUID id = Java.Lang.Object.GetObject<UUID>(native_id, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(workManager.CreateCancelPendingIntent(id));
		}

		[Register("createCancelPendingIntent", "(Ljava/util/UUID;)Landroid/app/PendingIntent;", "GetCreateCancelPendingIntent_Ljava_util_UUID_Handler")]
		public abstract PendingIntent CreateCancelPendingIntent(UUID id);

		[Register("enqueue", "(Landroidx/work/WorkRequest;)Landroidx/work/Operation;", "")]
		public unsafe IOperation Enqueue(WorkRequest workRequest)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(workRequest?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IOperation>(_members.InstanceMethods.InvokeNonvirtualObjectMethod("enqueue.(Landroidx/work/WorkRequest;)Landroidx/work/Operation;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(workRequest);
			}
		}

		private static Delegate GetEnqueue_Ljava_util_List_Handler()
		{
			if ((object)cb_enqueue_Ljava_util_List_ == null)
			{
				cb_enqueue_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_Enqueue_Ljava_util_List_));
			}
			return cb_enqueue_Ljava_util_List_;
		}

		private static IntPtr n_Enqueue_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_requests)
		{
			WorkManager workManager = Java.Lang.Object.GetObject<WorkManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IList<WorkRequest> requests = JavaList<WorkRequest>.FromJniHandle(native_requests, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(workManager.Enqueue(requests));
		}

		[Register("enqueue", "(Ljava/util/List;)Landroidx/work/Operation;", "GetEnqueue_Ljava_util_List_Handler")]
		public abstract IOperation Enqueue(IList<WorkRequest> requests);

		private static Delegate GetEnqueueUniquePeriodicWork_Ljava_lang_String_Landroidx_work_ExistingPeriodicWorkPolicy_Landroidx_work_PeriodicWorkRequest_Handler()
		{
			if ((object)cb_enqueueUniquePeriodicWork_Ljava_lang_String_Landroidx_work_ExistingPeriodicWorkPolicy_Landroidx_work_PeriodicWorkRequest_ == null)
			{
				cb_enqueueUniquePeriodicWork_Ljava_lang_String_Landroidx_work_ExistingPeriodicWorkPolicy_Landroidx_work_PeriodicWorkRequest_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_EnqueueUniquePeriodicWork_Ljava_lang_String_Landroidx_work_ExistingPeriodicWorkPolicy_Landroidx_work_PeriodicWorkRequest_));
			}
			return cb_enqueueUniquePeriodicWork_Ljava_lang_String_Landroidx_work_ExistingPeriodicWorkPolicy_Landroidx_work_PeriodicWorkRequest_;
		}

		private static IntPtr n_EnqueueUniquePeriodicWork_Ljava_lang_String_Landroidx_work_ExistingPeriodicWorkPolicy_Landroidx_work_PeriodicWorkRequest_(IntPtr jnienv, IntPtr native__this, IntPtr native_uniqueWorkName, IntPtr native_existingPeriodicWorkPolicy, IntPtr native_periodicWork)
		{
			WorkManager workManager = Java.Lang.Object.GetObject<WorkManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string uniqueWorkName = JNIEnv.GetString(native_uniqueWorkName, JniHandleOwnership.DoNotTransfer);
			ExistingPeriodicWorkPolicy existingPeriodicWorkPolicy = Java.Lang.Object.GetObject<ExistingPeriodicWorkPolicy>(native_existingPeriodicWorkPolicy, JniHandleOwnership.DoNotTransfer);
			PeriodicWorkRequest periodicWork = Java.Lang.Object.GetObject<PeriodicWorkRequest>(native_periodicWork, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(workManager.EnqueueUniquePeriodicWork(uniqueWorkName, existingPeriodicWorkPolicy, periodicWork));
		}

		[Register("enqueueUniquePeriodicWork", "(Ljava/lang/String;Landroidx/work/ExistingPeriodicWorkPolicy;Landroidx/work/PeriodicWorkRequest;)Landroidx/work/Operation;", "GetEnqueueUniquePeriodicWork_Ljava_lang_String_Landroidx_work_ExistingPeriodicWorkPolicy_Landroidx_work_PeriodicWorkRequest_Handler")]
		public abstract IOperation EnqueueUniquePeriodicWork(string uniqueWorkName, ExistingPeriodicWorkPolicy existingPeriodicWorkPolicy, PeriodicWorkRequest periodicWork);

		private static Delegate GetEnqueueUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Landroidx_work_OneTimeWorkRequest_Handler()
		{
			if ((object)cb_enqueueUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Landroidx_work_OneTimeWorkRequest_ == null)
			{
				cb_enqueueUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Landroidx_work_OneTimeWorkRequest_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_EnqueueUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Landroidx_work_OneTimeWorkRequest_));
			}
			return cb_enqueueUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Landroidx_work_OneTimeWorkRequest_;
		}

		private static IntPtr n_EnqueueUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Landroidx_work_OneTimeWorkRequest_(IntPtr jnienv, IntPtr native__this, IntPtr native_uniqueWorkName, IntPtr native_existingWorkPolicy, IntPtr native_work)
		{
			WorkManager workManager = Java.Lang.Object.GetObject<WorkManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string uniqueWorkName = JNIEnv.GetString(native_uniqueWorkName, JniHandleOwnership.DoNotTransfer);
			ExistingWorkPolicy existingWorkPolicy = Java.Lang.Object.GetObject<ExistingWorkPolicy>(native_existingWorkPolicy, JniHandleOwnership.DoNotTransfer);
			OneTimeWorkRequest work = Java.Lang.Object.GetObject<OneTimeWorkRequest>(native_work, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(workManager.EnqueueUniqueWork(uniqueWorkName, existingWorkPolicy, work));
		}

		[Register("enqueueUniqueWork", "(Ljava/lang/String;Landroidx/work/ExistingWorkPolicy;Landroidx/work/OneTimeWorkRequest;)Landroidx/work/Operation;", "GetEnqueueUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Landroidx_work_OneTimeWorkRequest_Handler")]
		public unsafe virtual IOperation EnqueueUniqueWork(string uniqueWorkName, ExistingWorkPolicy existingWorkPolicy, OneTimeWorkRequest work)
		{
			IntPtr intPtr = JNIEnv.NewString(uniqueWorkName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(existingWorkPolicy?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(work?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IOperation>(_members.InstanceMethods.InvokeVirtualObjectMethod("enqueueUniqueWork.(Ljava/lang/String;Landroidx/work/ExistingWorkPolicy;Landroidx/work/OneTimeWorkRequest;)Landroidx/work/Operation;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(existingWorkPolicy);
				GC.KeepAlive(work);
			}
		}

		private static Delegate GetEnqueueUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Ljava_util_List_Handler()
		{
			if ((object)cb_enqueueUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Ljava_util_List_ == null)
			{
				cb_enqueueUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Ljava_util_List_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPLLL_L(n_EnqueueUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Ljava_util_List_));
			}
			return cb_enqueueUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Ljava_util_List_;
		}

		private static IntPtr n_EnqueueUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Ljava_util_List_(IntPtr jnienv, IntPtr native__this, IntPtr native_uniqueWorkName, IntPtr native_existingWorkPolicy, IntPtr native_work)
		{
			WorkManager workManager = Java.Lang.Object.GetObject<WorkManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string uniqueWorkName = JNIEnv.GetString(native_uniqueWorkName, JniHandleOwnership.DoNotTransfer);
			ExistingWorkPolicy existingWorkPolicy = Java.Lang.Object.GetObject<ExistingWorkPolicy>(native_existingWorkPolicy, JniHandleOwnership.DoNotTransfer);
			IList<OneTimeWorkRequest> work = JavaList<OneTimeWorkRequest>.FromJniHandle(native_work, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(workManager.EnqueueUniqueWork(uniqueWorkName, existingWorkPolicy, work));
		}

		[Register("enqueueUniqueWork", "(Ljava/lang/String;Landroidx/work/ExistingWorkPolicy;Ljava/util/List;)Landroidx/work/Operation;", "GetEnqueueUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Ljava_util_List_Handler")]
		public abstract IOperation EnqueueUniqueWork(string uniqueWorkName, ExistingWorkPolicy existingWorkPolicy, IList<OneTimeWorkRequest> work);

		[Register("getInstance", "(Landroid/content/Context;)Landroidx/work/WorkManager;", "")]
		public unsafe static WorkManager GetInstance(Context context)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<WorkManager>(_members.StaticMethods.InvokeObjectMethod("getInstance.(Landroid/content/Context;)Landroidx/work/WorkManager;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(context);
			}
		}

		private static Delegate GetGetWorkInfoById_Ljava_util_UUID_Handler()
		{
			if ((object)cb_getWorkInfoById_Ljava_util_UUID_ == null)
			{
				cb_getWorkInfoById_Ljava_util_UUID_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetWorkInfoById_Ljava_util_UUID_));
			}
			return cb_getWorkInfoById_Ljava_util_UUID_;
		}

		private static IntPtr n_GetWorkInfoById_Ljava_util_UUID_(IntPtr jnienv, IntPtr native__this, IntPtr native_id)
		{
			WorkManager workManager = Java.Lang.Object.GetObject<WorkManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			UUID id = Java.Lang.Object.GetObject<UUID>(native_id, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(workManager.GetWorkInfoById(id));
		}

		[Register("getWorkInfoById", "(Ljava/util/UUID;)Lcom/google/common/util/concurrent/ListenableFuture;", "GetGetWorkInfoById_Ljava_util_UUID_Handler")]
		public abstract IListenableFuture GetWorkInfoById(UUID id);

		private static Delegate GetGetWorkInfoByIdLiveData_Ljava_util_UUID_Handler()
		{
			if ((object)cb_getWorkInfoByIdLiveData_Ljava_util_UUID_ == null)
			{
				cb_getWorkInfoByIdLiveData_Ljava_util_UUID_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetWorkInfoByIdLiveData_Ljava_util_UUID_));
			}
			return cb_getWorkInfoByIdLiveData_Ljava_util_UUID_;
		}

		private static IntPtr n_GetWorkInfoByIdLiveData_Ljava_util_UUID_(IntPtr jnienv, IntPtr native__this, IntPtr native_id)
		{
			WorkManager workManager = Java.Lang.Object.GetObject<WorkManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			UUID id = Java.Lang.Object.GetObject<UUID>(native_id, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(workManager.GetWorkInfoByIdLiveData(id));
		}

		[Register("getWorkInfoByIdLiveData", "(Ljava/util/UUID;)Landroidx/lifecycle/LiveData;", "GetGetWorkInfoByIdLiveData_Ljava_util_UUID_Handler")]
		public abstract LiveData GetWorkInfoByIdLiveData(UUID id);

		private static Delegate GetGetWorkInfos_Landroidx_work_WorkQuery_Handler()
		{
			if ((object)cb_getWorkInfos_Landroidx_work_WorkQuery_ == null)
			{
				cb_getWorkInfos_Landroidx_work_WorkQuery_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetWorkInfos_Landroidx_work_WorkQuery_));
			}
			return cb_getWorkInfos_Landroidx_work_WorkQuery_;
		}

		private static IntPtr n_GetWorkInfos_Landroidx_work_WorkQuery_(IntPtr jnienv, IntPtr native__this, IntPtr native_workQuery)
		{
			WorkManager workManager = Java.Lang.Object.GetObject<WorkManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WorkQuery workQuery = Java.Lang.Object.GetObject<WorkQuery>(native_workQuery, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(workManager.GetWorkInfos(workQuery));
		}

		[Register("getWorkInfos", "(Landroidx/work/WorkQuery;)Lcom/google/common/util/concurrent/ListenableFuture;", "GetGetWorkInfos_Landroidx_work_WorkQuery_Handler")]
		public abstract IListenableFuture GetWorkInfos(WorkQuery workQuery);

		private static Delegate GetGetWorkInfosByTag_Ljava_lang_String_Handler()
		{
			if ((object)cb_getWorkInfosByTag_Ljava_lang_String_ == null)
			{
				cb_getWorkInfosByTag_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetWorkInfosByTag_Ljava_lang_String_));
			}
			return cb_getWorkInfosByTag_Ljava_lang_String_;
		}

		private static IntPtr n_GetWorkInfosByTag_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_tag)
		{
			WorkManager workManager = Java.Lang.Object.GetObject<WorkManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string tag = JNIEnv.GetString(native_tag, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(workManager.GetWorkInfosByTag(tag));
		}

		[Register("getWorkInfosByTag", "(Ljava/lang/String;)Lcom/google/common/util/concurrent/ListenableFuture;", "GetGetWorkInfosByTag_Ljava_lang_String_Handler")]
		public abstract IListenableFuture GetWorkInfosByTag(string tag);

		private static Delegate GetGetWorkInfosByTagLiveData_Ljava_lang_String_Handler()
		{
			if ((object)cb_getWorkInfosByTagLiveData_Ljava_lang_String_ == null)
			{
				cb_getWorkInfosByTagLiveData_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetWorkInfosByTagLiveData_Ljava_lang_String_));
			}
			return cb_getWorkInfosByTagLiveData_Ljava_lang_String_;
		}

		private static IntPtr n_GetWorkInfosByTagLiveData_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_tag)
		{
			WorkManager workManager = Java.Lang.Object.GetObject<WorkManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string tag = JNIEnv.GetString(native_tag, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(workManager.GetWorkInfosByTagLiveData(tag));
		}

		[Register("getWorkInfosByTagLiveData", "(Ljava/lang/String;)Landroidx/lifecycle/LiveData;", "GetGetWorkInfosByTagLiveData_Ljava_lang_String_Handler")]
		public abstract LiveData GetWorkInfosByTagLiveData(string tag);

		private static Delegate GetGetWorkInfosForUniqueWork_Ljava_lang_String_Handler()
		{
			if ((object)cb_getWorkInfosForUniqueWork_Ljava_lang_String_ == null)
			{
				cb_getWorkInfosForUniqueWork_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetWorkInfosForUniqueWork_Ljava_lang_String_));
			}
			return cb_getWorkInfosForUniqueWork_Ljava_lang_String_;
		}

		private static IntPtr n_GetWorkInfosForUniqueWork_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_uniqueWorkName)
		{
			WorkManager workManager = Java.Lang.Object.GetObject<WorkManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string uniqueWorkName = JNIEnv.GetString(native_uniqueWorkName, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(workManager.GetWorkInfosForUniqueWork(uniqueWorkName));
		}

		[Register("getWorkInfosForUniqueWork", "(Ljava/lang/String;)Lcom/google/common/util/concurrent/ListenableFuture;", "GetGetWorkInfosForUniqueWork_Ljava_lang_String_Handler")]
		public abstract IListenableFuture GetWorkInfosForUniqueWork(string uniqueWorkName);

		private static Delegate GetGetWorkInfosForUniqueWorkLiveData_Ljava_lang_String_Handler()
		{
			if ((object)cb_getWorkInfosForUniqueWorkLiveData_Ljava_lang_String_ == null)
			{
				cb_getWorkInfosForUniqueWorkLiveData_Ljava_lang_String_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetWorkInfosForUniqueWorkLiveData_Ljava_lang_String_));
			}
			return cb_getWorkInfosForUniqueWorkLiveData_Ljava_lang_String_;
		}

		private static IntPtr n_GetWorkInfosForUniqueWorkLiveData_Ljava_lang_String_(IntPtr jnienv, IntPtr native__this, IntPtr native_uniqueWorkName)
		{
			WorkManager workManager = Java.Lang.Object.GetObject<WorkManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			string uniqueWorkName = JNIEnv.GetString(native_uniqueWorkName, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(workManager.GetWorkInfosForUniqueWorkLiveData(uniqueWorkName));
		}

		[Register("getWorkInfosForUniqueWorkLiveData", "(Ljava/lang/String;)Landroidx/lifecycle/LiveData;", "GetGetWorkInfosForUniqueWorkLiveData_Ljava_lang_String_Handler")]
		public abstract LiveData GetWorkInfosForUniqueWorkLiveData(string uniqueWorkName);

		private static Delegate GetGetWorkInfosLiveData_Landroidx_work_WorkQuery_Handler()
		{
			if ((object)cb_getWorkInfosLiveData_Landroidx_work_WorkQuery_ == null)
			{
				cb_getWorkInfosLiveData_Landroidx_work_WorkQuery_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_L(n_GetWorkInfosLiveData_Landroidx_work_WorkQuery_));
			}
			return cb_getWorkInfosLiveData_Landroidx_work_WorkQuery_;
		}

		private static IntPtr n_GetWorkInfosLiveData_Landroidx_work_WorkQuery_(IntPtr jnienv, IntPtr native__this, IntPtr native_workQuery)
		{
			WorkManager workManager = Java.Lang.Object.GetObject<WorkManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			WorkQuery workQuery = Java.Lang.Object.GetObject<WorkQuery>(native_workQuery, JniHandleOwnership.DoNotTransfer);
			return JNIEnv.ToLocalJniHandle(workManager.GetWorkInfosLiveData(workQuery));
		}

		[Register("getWorkInfosLiveData", "(Landroidx/work/WorkQuery;)Landroidx/lifecycle/LiveData;", "GetGetWorkInfosLiveData_Landroidx_work_WorkQuery_Handler")]
		public abstract LiveData GetWorkInfosLiveData(WorkQuery workQuery);

		[Register("initialize", "(Landroid/content/Context;Landroidx/work/Configuration;)V", "")]
		public unsafe static void Initialize(Context context, Configuration configuration)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(context?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(configuration?.Handle ?? IntPtr.Zero);
				_members.StaticMethods.InvokeVoidMethod("initialize.(Landroid/content/Context;Landroidx/work/Configuration;)V", ptr);
			}
			finally
			{
				GC.KeepAlive(context);
				GC.KeepAlive(configuration);
			}
		}

		private static Delegate GetPruneWorkHandler()
		{
			if ((object)cb_pruneWork == null)
			{
				cb_pruneWork = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_PruneWork));
			}
			return cb_pruneWork;
		}

		private static IntPtr n_PruneWork(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WorkManager>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).PruneWork());
		}

		[Register("pruneWork", "()Landroidx/work/Operation;", "GetPruneWorkHandler")]
		public abstract IOperation PruneWork();
	}
	[Register("androidx/work/WorkManager", DoNotGenerateAcw = true)]
	internal class WorkManagerInvoker : WorkManager
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/WorkManager", typeof(WorkManagerInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public unsafe override IListenableFuture LastCancelAllTimeMillis
		{
			[Register("getLastCancelAllTimeMillis", "()Lcom/google/common/util/concurrent/ListenableFuture;", "GetGetLastCancelAllTimeMillisHandler")]
			get
			{
				return Java.Lang.Object.GetObject<IListenableFuture>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLastCancelAllTimeMillis.()Lcom/google/common/util/concurrent/ListenableFuture;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe override LiveData LastCancelAllTimeMillisLiveData
		{
			[Register("getLastCancelAllTimeMillisLiveData", "()Landroidx/lifecycle/LiveData;", "GetGetLastCancelAllTimeMillisLiveDataHandler")]
			get
			{
				return Java.Lang.Object.GetObject<LiveData>(_members.InstanceMethods.InvokeAbstractObjectMethod("getLastCancelAllTimeMillisLiveData.()Landroidx/lifecycle/LiveData;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public WorkManagerInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}

		[Register("beginUniqueWork", "(Ljava/lang/String;Landroidx/work/ExistingWorkPolicy;Ljava/util/List;)Landroidx/work/WorkContinuation;", "GetBeginUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Ljava_util_List_Handler")]
		public unsafe override WorkContinuation BeginUniqueWork(string uniqueWorkName, ExistingWorkPolicy existingWorkPolicy, IList<OneTimeWorkRequest> work)
		{
			IntPtr intPtr = JNIEnv.NewString(uniqueWorkName);
			IntPtr intPtr2 = JavaList<OneTimeWorkRequest>.ToLocalJniHandle(work);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(existingWorkPolicy?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr2);
				return Java.Lang.Object.GetObject<WorkContinuation>(_members.InstanceMethods.InvokeAbstractObjectMethod("beginUniqueWork.(Ljava/lang/String;Landroidx/work/ExistingWorkPolicy;Ljava/util/List;)Landroidx/work/WorkContinuation;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(existingWorkPolicy);
				GC.KeepAlive(work);
			}
		}

		[Register("beginWith", "(Ljava/util/List;)Landroidx/work/WorkContinuation;", "GetBeginWith_Ljava_util_List_Handler")]
		public unsafe override WorkContinuation BeginWith(IList<OneTimeWorkRequest> work)
		{
			IntPtr intPtr = JavaList<OneTimeWorkRequest>.ToLocalJniHandle(work);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<WorkContinuation>(_members.InstanceMethods.InvokeAbstractObjectMethod("beginWith.(Ljava/util/List;)Landroidx/work/WorkContinuation;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(work);
			}
		}

		[Register("cancelAllWork", "()Landroidx/work/Operation;", "GetCancelAllWorkHandler")]
		public unsafe override IOperation CancelAllWork()
		{
			return Java.Lang.Object.GetObject<IOperation>(_members.InstanceMethods.InvokeAbstractObjectMethod("cancelAllWork.()Landroidx/work/Operation;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("cancelAllWorkByTag", "(Ljava/lang/String;)Landroidx/work/Operation;", "GetCancelAllWorkByTag_Ljava_lang_String_Handler")]
		public unsafe override IOperation CancelAllWorkByTag(string tag)
		{
			IntPtr intPtr = JNIEnv.NewString(tag);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<IOperation>(_members.InstanceMethods.InvokeAbstractObjectMethod("cancelAllWorkByTag.(Ljava/lang/String;)Landroidx/work/Operation;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("cancelUniqueWork", "(Ljava/lang/String;)Landroidx/work/Operation;", "GetCancelUniqueWork_Ljava_lang_String_Handler")]
		public unsafe override IOperation CancelUniqueWork(string uniqueWorkName)
		{
			IntPtr intPtr = JNIEnv.NewString(uniqueWorkName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<IOperation>(_members.InstanceMethods.InvokeAbstractObjectMethod("cancelUniqueWork.(Ljava/lang/String;)Landroidx/work/Operation;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("cancelWorkById", "(Ljava/util/UUID;)Landroidx/work/Operation;", "GetCancelWorkById_Ljava_util_UUID_Handler")]
		public unsafe override IOperation CancelWorkById(UUID id)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(id?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IOperation>(_members.InstanceMethods.InvokeAbstractObjectMethod("cancelWorkById.(Ljava/util/UUID;)Landroidx/work/Operation;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(id);
			}
		}

		[Register("createCancelPendingIntent", "(Ljava/util/UUID;)Landroid/app/PendingIntent;", "GetCreateCancelPendingIntent_Ljava_util_UUID_Handler")]
		public unsafe override PendingIntent CreateCancelPendingIntent(UUID id)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(id?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<PendingIntent>(_members.InstanceMethods.InvokeAbstractObjectMethod("createCancelPendingIntent.(Ljava/util/UUID;)Landroid/app/PendingIntent;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(id);
			}
		}

		[Register("enqueue", "(Ljava/util/List;)Landroidx/work/Operation;", "GetEnqueue_Ljava_util_List_Handler")]
		public unsafe override IOperation Enqueue(IList<WorkRequest> requests)
		{
			IntPtr intPtr = JavaList<WorkRequest>.ToLocalJniHandle(requests);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<IOperation>(_members.InstanceMethods.InvokeAbstractObjectMethod("enqueue.(Ljava/util/List;)Landroidx/work/Operation;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(requests);
			}
		}

		[Register("enqueueUniquePeriodicWork", "(Ljava/lang/String;Landroidx/work/ExistingPeriodicWorkPolicy;Landroidx/work/PeriodicWorkRequest;)Landroidx/work/Operation;", "GetEnqueueUniquePeriodicWork_Ljava_lang_String_Landroidx_work_ExistingPeriodicWorkPolicy_Landroidx_work_PeriodicWorkRequest_Handler")]
		public unsafe override IOperation EnqueueUniquePeriodicWork(string uniqueWorkName, ExistingPeriodicWorkPolicy existingPeriodicWorkPolicy, PeriodicWorkRequest periodicWork)
		{
			IntPtr intPtr = JNIEnv.NewString(uniqueWorkName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(existingPeriodicWorkPolicy?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(periodicWork?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IOperation>(_members.InstanceMethods.InvokeAbstractObjectMethod("enqueueUniquePeriodicWork.(Ljava/lang/String;Landroidx/work/ExistingPeriodicWorkPolicy;Landroidx/work/PeriodicWorkRequest;)Landroidx/work/Operation;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(existingPeriodicWorkPolicy);
				GC.KeepAlive(periodicWork);
			}
		}

		[Register("enqueueUniqueWork", "(Ljava/lang/String;Landroidx/work/ExistingWorkPolicy;Ljava/util/List;)Landroidx/work/Operation;", "GetEnqueueUniqueWork_Ljava_lang_String_Landroidx_work_ExistingWorkPolicy_Ljava_util_List_Handler")]
		public unsafe override IOperation EnqueueUniqueWork(string uniqueWorkName, ExistingWorkPolicy existingWorkPolicy, IList<OneTimeWorkRequest> work)
		{
			IntPtr intPtr = JNIEnv.NewString(uniqueWorkName);
			IntPtr intPtr2 = JavaList<OneTimeWorkRequest>.ToLocalJniHandle(work);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(existingWorkPolicy?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr2);
				return Java.Lang.Object.GetObject<IOperation>(_members.InstanceMethods.InvokeAbstractObjectMethod("enqueueUniqueWork.(Ljava/lang/String;Landroidx/work/ExistingWorkPolicy;Ljava/util/List;)Landroidx/work/Operation;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
				GC.KeepAlive(existingWorkPolicy);
				GC.KeepAlive(work);
			}
		}

		[Register("getWorkInfoById", "(Ljava/util/UUID;)Lcom/google/common/util/concurrent/ListenableFuture;", "GetGetWorkInfoById_Ljava_util_UUID_Handler")]
		public unsafe override IListenableFuture GetWorkInfoById(UUID id)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(id?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IListenableFuture>(_members.InstanceMethods.InvokeAbstractObjectMethod("getWorkInfoById.(Ljava/util/UUID;)Lcom/google/common/util/concurrent/ListenableFuture;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(id);
			}
		}

		[Register("getWorkInfoByIdLiveData", "(Ljava/util/UUID;)Landroidx/lifecycle/LiveData;", "GetGetWorkInfoByIdLiveData_Ljava_util_UUID_Handler")]
		public unsafe override LiveData GetWorkInfoByIdLiveData(UUID id)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(id?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<LiveData>(_members.InstanceMethods.InvokeAbstractObjectMethod("getWorkInfoByIdLiveData.(Ljava/util/UUID;)Landroidx/lifecycle/LiveData;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(id);
			}
		}

		[Register("getWorkInfos", "(Landroidx/work/WorkQuery;)Lcom/google/common/util/concurrent/ListenableFuture;", "GetGetWorkInfos_Landroidx_work_WorkQuery_Handler")]
		public unsafe override IListenableFuture GetWorkInfos(WorkQuery workQuery)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(workQuery?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<IListenableFuture>(_members.InstanceMethods.InvokeAbstractObjectMethod("getWorkInfos.(Landroidx/work/WorkQuery;)Lcom/google/common/util/concurrent/ListenableFuture;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(workQuery);
			}
		}

		[Register("getWorkInfosByTag", "(Ljava/lang/String;)Lcom/google/common/util/concurrent/ListenableFuture;", "GetGetWorkInfosByTag_Ljava_lang_String_Handler")]
		public unsafe override IListenableFuture GetWorkInfosByTag(string tag)
		{
			IntPtr intPtr = JNIEnv.NewString(tag);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<IListenableFuture>(_members.InstanceMethods.InvokeAbstractObjectMethod("getWorkInfosByTag.(Ljava/lang/String;)Lcom/google/common/util/concurrent/ListenableFuture;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getWorkInfosByTagLiveData", "(Ljava/lang/String;)Landroidx/lifecycle/LiveData;", "GetGetWorkInfosByTagLiveData_Ljava_lang_String_Handler")]
		public unsafe override LiveData GetWorkInfosByTagLiveData(string tag)
		{
			IntPtr intPtr = JNIEnv.NewString(tag);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<LiveData>(_members.InstanceMethods.InvokeAbstractObjectMethod("getWorkInfosByTagLiveData.(Ljava/lang/String;)Landroidx/lifecycle/LiveData;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getWorkInfosForUniqueWork", "(Ljava/lang/String;)Lcom/google/common/util/concurrent/ListenableFuture;", "GetGetWorkInfosForUniqueWork_Ljava_lang_String_Handler")]
		public unsafe override IListenableFuture GetWorkInfosForUniqueWork(string uniqueWorkName)
		{
			IntPtr intPtr = JNIEnv.NewString(uniqueWorkName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<IListenableFuture>(_members.InstanceMethods.InvokeAbstractObjectMethod("getWorkInfosForUniqueWork.(Ljava/lang/String;)Lcom/google/common/util/concurrent/ListenableFuture;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getWorkInfosForUniqueWorkLiveData", "(Ljava/lang/String;)Landroidx/lifecycle/LiveData;", "GetGetWorkInfosForUniqueWorkLiveData_Ljava_lang_String_Handler")]
		public unsafe override LiveData GetWorkInfosForUniqueWorkLiveData(string uniqueWorkName)
		{
			IntPtr intPtr = JNIEnv.NewString(uniqueWorkName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(intPtr);
				return Java.Lang.Object.GetObject<LiveData>(_members.InstanceMethods.InvokeAbstractObjectMethod("getWorkInfosForUniqueWorkLiveData.(Ljava/lang/String;)Landroidx/lifecycle/LiveData;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
			}
		}

		[Register("getWorkInfosLiveData", "(Landroidx/work/WorkQuery;)Landroidx/lifecycle/LiveData;", "GetGetWorkInfosLiveData_Landroidx_work_WorkQuery_Handler")]
		public unsafe override LiveData GetWorkInfosLiveData(WorkQuery workQuery)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(workQuery?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<LiveData>(_members.InstanceMethods.InvokeAbstractObjectMethod("getWorkInfosLiveData.(Landroidx/work/WorkQuery;)Landroidx/lifecycle/LiveData;", this, ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(workQuery);
			}
		}

		[Register("pruneWork", "()Landroidx/work/Operation;", "GetPruneWorkHandler")]
		public unsafe override IOperation PruneWork()
		{
			return Java.Lang.Object.GetObject<IOperation>(_members.InstanceMethods.InvokeAbstractObjectMethod("pruneWork.()Landroidx/work/Operation;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
		}
	}
	[Register("androidx/work/WorkQuery", DoNotGenerateAcw = true)]
	public sealed class WorkQuery : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/WorkQuery", typeof(WorkQuery));

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

		public unsafe IList<UUID> Ids
		{
			[Register("getIds", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<UUID>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getIds.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IList<WorkInfo.State> States
		{
			[Register("getStates", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<WorkInfo.State>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getStates.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IList<string> Tags
		{
			[Register("getTags", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getTags.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe IList<string> UniqueWorkNames
		{
			[Register("getUniqueWorkNames", "()Ljava/util/List;", "")]
			get
			{
				return JavaList<string>.FromJniHandle(_members.InstanceMethods.InvokeAbstractObjectMethod("getUniqueWorkNames.()Ljava/util/List;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		internal WorkQuery(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}
	}
	[Register("androidx/work/WorkRequest", DoNotGenerateAcw = true)]
	public abstract class WorkRequest : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/WorkRequest", typeof(WorkRequest));

		private static Delegate cb_getId;

		private static Delegate cb_getStringId;

		private static Delegate cb_getTags;

		private static Delegate cb_getWorkSpec;

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

		public unsafe virtual UUID Id
		{
			[Register("getId", "()Ljava/util/UUID;", "GetGetIdHandler")]
			get
			{
				return Java.Lang.Object.GetObject<UUID>(_members.InstanceMethods.InvokeVirtualObjectMethod("getId.()Ljava/util/UUID;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual string StringId
		{
			[Register("getStringId", "()Ljava/lang/String;", "GetGetStringIdHandler")]
			get
			{
				return JNIEnv.GetString(_members.InstanceMethods.InvokeVirtualObjectMethod("getStringId.()Ljava/lang/String;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual ICollection<string> Tags
		{
			[Register("getTags", "()Ljava/util/Set;", "GetGetTagsHandler")]
			get
			{
				return JavaSet<string>.FromJniHandle(_members.InstanceMethods.InvokeVirtualObjectMethod("getTags.()Ljava/util/Set;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual WorkSpec WorkSpec
		{
			[Register("getWorkSpec", "()Landroidx/work/impl/model/WorkSpec;", "GetGetWorkSpecHandler")]
			get
			{
				return Java.Lang.Object.GetObject<WorkSpec>(_members.InstanceMethods.InvokeVirtualObjectMethod("getWorkSpec.()Landroidx/work/impl/model/WorkSpec;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		protected WorkRequest(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/util/UUID;Landroidx/work/impl/model/WorkSpec;Ljava/util/Set;)V", "")]
		protected unsafe WorkRequest(UUID id, WorkSpec workSpec, ICollection<string> tags)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JavaSet<string>.ToLocalJniHandle(tags);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[3];
				*ptr = new JniArgumentValue(id?.Handle ?? IntPtr.Zero);
				ptr[1] = new JniArgumentValue(workSpec?.Handle ?? IntPtr.Zero);
				ptr[2] = new JniArgumentValue(intPtr);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/util/UUID;Landroidx/work/impl/model/WorkSpec;Ljava/util/Set;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/util/UUID;Landroidx/work/impl/model/WorkSpec;Ljava/util/Set;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				GC.KeepAlive(id);
				GC.KeepAlive(workSpec);
				GC.KeepAlive(tags);
			}
		}

		private static Delegate GetGetIdHandler()
		{
			if ((object)cb_getId == null)
			{
				cb_getId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetId));
			}
			return cb_getId;
		}

		private static IntPtr n_GetId(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WorkRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Id);
		}

		private static Delegate GetGetStringIdHandler()
		{
			if ((object)cb_getStringId == null)
			{
				cb_getStringId = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetStringId));
			}
			return cb_getStringId;
		}

		private static IntPtr n_GetStringId(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.NewString(Java.Lang.Object.GetObject<WorkRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).StringId);
		}

		private static Delegate GetGetTagsHandler()
		{
			if ((object)cb_getTags == null)
			{
				cb_getTags = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetTags));
			}
			return cb_getTags;
		}

		private static IntPtr n_GetTags(IntPtr jnienv, IntPtr native__this)
		{
			return JavaSet<string>.ToLocalJniHandle(Java.Lang.Object.GetObject<WorkRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).Tags);
		}

		private static Delegate GetGetWorkSpecHandler()
		{
			if ((object)cb_getWorkSpec == null)
			{
				cb_getWorkSpec = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetWorkSpec));
			}
			return cb_getWorkSpec;
		}

		private static IntPtr n_GetWorkSpec(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<WorkRequest>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).WorkSpec);
		}
	}
	[Register("androidx/work/WorkRequest", DoNotGenerateAcw = true)]
	internal class WorkRequestInvoker : WorkRequest
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/WorkRequest", typeof(WorkRequestInvoker));

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		public WorkRequestInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(handle, transfer)
		{
		}
	}
}
namespace AndroidX.Work.Impl.Utils
{
	[Register("androidx/work/impl/utils/SerialExecutor", DoNotGenerateAcw = true)]
	public class SerialExecutor : Java.Lang.Object, IExecutor, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/impl/utils/SerialExecutor", typeof(SerialExecutor));

		private static Delegate cb_getDelegatedExecutor;

		private static Delegate cb_hasPendingTasks;

		private static Delegate cb_execute_Ljava_lang_Runnable_;

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

		public unsafe virtual IExecutor DelegatedExecutor
		{
			[Register("getDelegatedExecutor", "()Ljava/util/concurrent/Executor;", "GetGetDelegatedExecutorHandler")]
			get
			{
				return Java.Lang.Object.GetObject<IExecutor>(_members.InstanceMethods.InvokeVirtualObjectMethod("getDelegatedExecutor.()Ljava/util/concurrent/Executor;", this, null).Handle, JniHandleOwnership.TransferLocalRef);
			}
		}

		public unsafe virtual bool HasPendingTasks
		{
			[Register("hasPendingTasks", "()Z", "GetHasPendingTasksHandler")]
			get
			{
				return _members.InstanceMethods.InvokeVirtualBooleanMethod("hasPendingTasks.()Z", this, null);
			}
		}

		protected SerialExecutor(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Ljava/util/concurrent/Executor;)V", "")]
		public unsafe SerialExecutor(IExecutor executor)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((executor == null) ? IntPtr.Zero : ((Java.Lang.Object)executor).Handle);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/util/concurrent/Executor;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/util/concurrent/Executor;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(executor);
			}
		}

		private static Delegate GetGetDelegatedExecutorHandler()
		{
			if ((object)cb_getDelegatedExecutor == null)
			{
				cb_getDelegatedExecutor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetDelegatedExecutor));
			}
			return cb_getDelegatedExecutor;
		}

		private static IntPtr n_GetDelegatedExecutor(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<SerialExecutor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).DelegatedExecutor);
		}

		private static Delegate GetHasPendingTasksHandler()
		{
			if ((object)cb_hasPendingTasks == null)
			{
				cb_hasPendingTasks = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_Z(n_HasPendingTasks));
			}
			return cb_hasPendingTasks;
		}

		private static bool n_HasPendingTasks(IntPtr jnienv, IntPtr native__this)
		{
			return Java.Lang.Object.GetObject<SerialExecutor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).HasPendingTasks;
		}

		private static Delegate GetExecute_Ljava_lang_Runnable_Handler()
		{
			if ((object)cb_execute_Ljava_lang_Runnable_ == null)
			{
				cb_execute_Ljava_lang_Runnable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_Execute_Ljava_lang_Runnable_));
			}
			return cb_execute_Ljava_lang_Runnable_;
		}

		private static void n_Execute_Ljava_lang_Runnable_(IntPtr jnienv, IntPtr native__this, IntPtr native_command)
		{
			SerialExecutor serialExecutor = Java.Lang.Object.GetObject<SerialExecutor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable command = Java.Lang.Object.GetObject<IRunnable>(native_command, JniHandleOwnership.DoNotTransfer);
			serialExecutor.Execute(command);
		}

		[Register("execute", "(Ljava/lang/Runnable;)V", "GetExecute_Ljava_lang_Runnable_Handler")]
		public unsafe virtual void Execute(IRunnable command)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue((command == null) ? IntPtr.Zero : ((Java.Lang.Object)command).Handle);
				_members.InstanceMethods.InvokeVirtualVoidMethod("execute.(Ljava/lang/Runnable;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(command);
			}
		}
	}
}
namespace AndroidX.Work.Impl.Utils.TaskExecutor
{
	[Register("androidx/work/impl/utils/taskexecutor/TaskExecutor", "", "AndroidX.Work.Impl.Utils.TaskExecutor.ITaskExecutorInvoker")]
	public interface ITaskExecutor : IJavaObject, IDisposable, IJavaPeerable
	{
		SerialExecutor BackgroundExecutor
		{
			[Register("getBackgroundExecutor", "()Landroidx/work/impl/utils/SerialExecutor;", "GetGetBackgroundExecutorHandler:AndroidX.Work.Impl.Utils.TaskExecutor.ITaskExecutorInvoker, Xamarin.AndroidX.Work.Runtime")]
			get;
		}

		IExecutor MainThreadExecutor
		{
			[Register("getMainThreadExecutor", "()Ljava/util/concurrent/Executor;", "GetGetMainThreadExecutorHandler:AndroidX.Work.Impl.Utils.TaskExecutor.ITaskExecutorInvoker, Xamarin.AndroidX.Work.Runtime")]
			get;
		}

		[Register("executeOnBackgroundThread", "(Ljava/lang/Runnable;)V", "GetExecuteOnBackgroundThread_Ljava_lang_Runnable_Handler:AndroidX.Work.Impl.Utils.TaskExecutor.ITaskExecutorInvoker, Xamarin.AndroidX.Work.Runtime")]
		void ExecuteOnBackgroundThread(IRunnable runnable);

		[Register("postToMainThread", "(Ljava/lang/Runnable;)V", "GetPostToMainThread_Ljava_lang_Runnable_Handler:AndroidX.Work.Impl.Utils.TaskExecutor.ITaskExecutorInvoker, Xamarin.AndroidX.Work.Runtime")]
		void PostToMainThread(IRunnable runnable);
	}
	[Register("androidx/work/impl/utils/taskexecutor/TaskExecutor", DoNotGenerateAcw = true)]
	internal class ITaskExecutorInvoker : Java.Lang.Object, ITaskExecutor, IJavaObject, IDisposable, IJavaPeerable
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/impl/utils/taskexecutor/TaskExecutor", typeof(ITaskExecutorInvoker));

		private IntPtr class_ref;

		private static Delegate cb_getBackgroundExecutor;

		private IntPtr id_getBackgroundExecutor;

		private static Delegate cb_getMainThreadExecutor;

		private IntPtr id_getMainThreadExecutor;

		private static Delegate cb_executeOnBackgroundThread_Ljava_lang_Runnable_;

		private IntPtr id_executeOnBackgroundThread_Ljava_lang_Runnable_;

		private static Delegate cb_postToMainThread_Ljava_lang_Runnable_;

		private IntPtr id_postToMainThread_Ljava_lang_Runnable_;

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

		public SerialExecutor BackgroundExecutor
		{
			get
			{
				if (id_getBackgroundExecutor == IntPtr.Zero)
				{
					id_getBackgroundExecutor = JNIEnv.GetMethodID(class_ref, "getBackgroundExecutor", "()Landroidx/work/impl/utils/SerialExecutor;");
				}
				return Java.Lang.Object.GetObject<SerialExecutor>(JNIEnv.CallObjectMethod(base.Handle, id_getBackgroundExecutor), JniHandleOwnership.TransferLocalRef);
			}
		}

		public IExecutor MainThreadExecutor
		{
			get
			{
				if (id_getMainThreadExecutor == IntPtr.Zero)
				{
					id_getMainThreadExecutor = JNIEnv.GetMethodID(class_ref, "getMainThreadExecutor", "()Ljava/util/concurrent/Executor;");
				}
				return Java.Lang.Object.GetObject<IExecutor>(JNIEnv.CallObjectMethod(base.Handle, id_getMainThreadExecutor), JniHandleOwnership.TransferLocalRef);
			}
		}

		public static ITaskExecutor GetObject(IntPtr handle, JniHandleOwnership transfer)
		{
			return Java.Lang.Object.GetObject<ITaskExecutor>(handle, transfer);
		}

		private static IntPtr Validate(IntPtr handle)
		{
			if (!JNIEnv.IsInstanceOf(handle, java_class_ref))
			{
				throw new InvalidCastException("Unable to convert instance of type '" + JNIEnv.GetClassNameFromInstance(handle) + "' to type 'androidx.work.impl.utils.taskexecutor.TaskExecutor'.");
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

		public ITaskExecutorInvoker(IntPtr handle, JniHandleOwnership transfer)
			: base(Validate(handle), transfer)
		{
			IntPtr objectClass = JNIEnv.GetObjectClass(base.Handle);
			class_ref = JNIEnv.NewGlobalRef(objectClass);
			JNIEnv.DeleteLocalRef(objectClass);
		}

		private static Delegate GetGetBackgroundExecutorHandler()
		{
			if ((object)cb_getBackgroundExecutor == null)
			{
				cb_getBackgroundExecutor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetBackgroundExecutor));
			}
			return cb_getBackgroundExecutor;
		}

		private static IntPtr n_GetBackgroundExecutor(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ITaskExecutor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).BackgroundExecutor);
		}

		private static Delegate GetGetMainThreadExecutorHandler()
		{
			if ((object)cb_getMainThreadExecutor == null)
			{
				cb_getMainThreadExecutor = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PP_L(n_GetMainThreadExecutor));
			}
			return cb_getMainThreadExecutor;
		}

		private static IntPtr n_GetMainThreadExecutor(IntPtr jnienv, IntPtr native__this)
		{
			return JNIEnv.ToLocalJniHandle(Java.Lang.Object.GetObject<ITaskExecutor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer).MainThreadExecutor);
		}

		private static Delegate GetExecuteOnBackgroundThread_Ljava_lang_Runnable_Handler()
		{
			if ((object)cb_executeOnBackgroundThread_Ljava_lang_Runnable_ == null)
			{
				cb_executeOnBackgroundThread_Ljava_lang_Runnable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_ExecuteOnBackgroundThread_Ljava_lang_Runnable_));
			}
			return cb_executeOnBackgroundThread_Ljava_lang_Runnable_;
		}

		private static void n_ExecuteOnBackgroundThread_Ljava_lang_Runnable_(IntPtr jnienv, IntPtr native__this, IntPtr native_runnable)
		{
			ITaskExecutor taskExecutor = Java.Lang.Object.GetObject<ITaskExecutor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable runnable = Java.Lang.Object.GetObject<IRunnable>(native_runnable, JniHandleOwnership.DoNotTransfer);
			taskExecutor.ExecuteOnBackgroundThread(runnable);
		}

		public unsafe void ExecuteOnBackgroundThread(IRunnable runnable)
		{
			if (id_executeOnBackgroundThread_Ljava_lang_Runnable_ == IntPtr.Zero)
			{
				id_executeOnBackgroundThread_Ljava_lang_Runnable_ = JNIEnv.GetMethodID(class_ref, "executeOnBackgroundThread", "(Ljava/lang/Runnable;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((runnable == null) ? IntPtr.Zero : ((Java.Lang.Object)runnable).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_executeOnBackgroundThread_Ljava_lang_Runnable_, ptr);
		}

		private static Delegate GetPostToMainThread_Ljava_lang_Runnable_Handler()
		{
			if ((object)cb_postToMainThread_Ljava_lang_Runnable_ == null)
			{
				cb_postToMainThread_Ljava_lang_Runnable_ = JNINativeWrapper.CreateDelegate(new global::_JniMarshal_PPL_V(n_PostToMainThread_Ljava_lang_Runnable_));
			}
			return cb_postToMainThread_Ljava_lang_Runnable_;
		}

		private static void n_PostToMainThread_Ljava_lang_Runnable_(IntPtr jnienv, IntPtr native__this, IntPtr native_runnable)
		{
			ITaskExecutor taskExecutor = Java.Lang.Object.GetObject<ITaskExecutor>(jnienv, native__this, JniHandleOwnership.DoNotTransfer);
			IRunnable runnable = Java.Lang.Object.GetObject<IRunnable>(native_runnable, JniHandleOwnership.DoNotTransfer);
			taskExecutor.PostToMainThread(runnable);
		}

		public unsafe void PostToMainThread(IRunnable runnable)
		{
			if (id_postToMainThread_Ljava_lang_Runnable_ == IntPtr.Zero)
			{
				id_postToMainThread_Ljava_lang_Runnable_ = JNIEnv.GetMethodID(class_ref, "postToMainThread", "(Ljava/lang/Runnable;)V");
			}
			JValue* ptr = stackalloc JValue[1];
			*ptr = new JValue((runnable == null) ? IntPtr.Zero : ((Java.Lang.Object)runnable).Handle);
			JNIEnv.CallVoidMethod(base.Handle, id_postToMainThread_Ljava_lang_Runnable_, ptr);
		}
	}
}
namespace AndroidX.Work.Impl.Model
{
	[Register("androidx/work/impl/model/WorkSpec", DoNotGenerateAcw = true)]
	public sealed class WorkSpec : Java.Lang.Object
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("androidx/work/impl/model/WorkSpec", typeof(WorkSpec));

		[Register("WORK_INFO_MAPPER")]
		public static IFunction WorkInfoMapper => Java.Lang.Object.GetObject<IFunction>(_members.StaticFields.GetObjectValue("WORK_INFO_MAPPER.Landroidx/arch/core/util/Function;").Handle, JniHandleOwnership.TransferLocalRef);

		[Register("backoffDelayDuration")]
		public long BackoffDelayDuration
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("backoffDelayDuration.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("backoffDelayDuration.J", this, value);
			}
		}

		[Register("backoffPolicy")]
		public BackoffPolicy BackoffPolicy
		{
			get
			{
				return Java.Lang.Object.GetObject<BackoffPolicy>(_members.InstanceFields.GetObjectValue("backoffPolicy.Landroidx/work/BackoffPolicy;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("backoffPolicy.Landroidx/work/BackoffPolicy;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("constraints")]
		public Constraints Constraints
		{
			get
			{
				return Java.Lang.Object.GetObject<Constraints>(_members.InstanceFields.GetObjectValue("constraints.Landroidx/work/Constraints;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("constraints.Landroidx/work/Constraints;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("expedited")]
		public bool Expedited
		{
			get
			{
				return _members.InstanceFields.GetBooleanValue("expedited.Z", this);
			}
			set
			{
				_members.InstanceFields.SetValue("expedited.Z", this, value);
			}
		}

		[Register("flexDuration")]
		public long FlexDuration
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("flexDuration.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("flexDuration.J", this, value);
			}
		}

		[Register("id")]
		public string Id
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("id.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("id.Ljava/lang/String;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("initialDelay")]
		public long InitialDelay
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("initialDelay.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("initialDelay.J", this, value);
			}
		}

		[Register("input")]
		public Data Input
		{
			get
			{
				return Java.Lang.Object.GetObject<Data>(_members.InstanceFields.GetObjectValue("input.Landroidx/work/Data;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("input.Landroidx/work/Data;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("inputMergerClassName")]
		public string InputMergerClassName
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("inputMergerClassName.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("inputMergerClassName.Ljava/lang/String;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("intervalDuration")]
		public long IntervalDuration
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("intervalDuration.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("intervalDuration.J", this, value);
			}
		}

		[Register("minimumRetentionDuration")]
		public long MinimumRetentionDuration
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("minimumRetentionDuration.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("minimumRetentionDuration.J", this, value);
			}
		}

		[Register("outOfQuotaPolicy")]
		public OutOfQuotaPolicy OutOfQuotaPolicy
		{
			get
			{
				return Java.Lang.Object.GetObject<OutOfQuotaPolicy>(_members.InstanceFields.GetObjectValue("outOfQuotaPolicy.Landroidx/work/OutOfQuotaPolicy;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("outOfQuotaPolicy.Landroidx/work/OutOfQuotaPolicy;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("output")]
		public Data Output
		{
			get
			{
				return Java.Lang.Object.GetObject<Data>(_members.InstanceFields.GetObjectValue("output.Landroidx/work/Data;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("output.Landroidx/work/Data;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("periodStartTime")]
		public long PeriodStartTime
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("periodStartTime.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("periodStartTime.J", this, value);
			}
		}

		[Register("runAttemptCount")]
		public int RunAttemptCount
		{
			get
			{
				return _members.InstanceFields.GetInt32Value("runAttemptCount.I", this);
			}
			set
			{
				_members.InstanceFields.SetValue("runAttemptCount.I", this, value);
			}
		}

		[Register("scheduleRequestedAt")]
		public long ScheduleRequestedAt
		{
			get
			{
				return _members.InstanceFields.GetInt64Value("scheduleRequestedAt.J", this);
			}
			set
			{
				_members.InstanceFields.SetValue("scheduleRequestedAt.J", this, value);
			}
		}

		[Register("state")]
		public WorkInfo.State State
		{
			get
			{
				return Java.Lang.Object.GetObject<WorkInfo.State>(_members.InstanceFields.GetObjectValue("state.Landroidx/work/WorkInfo$State;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.ToLocalJniHandle(value);
				try
				{
					_members.InstanceFields.SetValue("state.Landroidx/work/WorkInfo$State;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
			}
		}

		[Register("workerClassName")]
		public string WorkerClassName
		{
			get
			{
				return JNIEnv.GetString(_members.InstanceFields.GetObjectValue("workerClassName.Ljava/lang/String;", this).Handle, JniHandleOwnership.TransferLocalRef);
			}
			set
			{
				IntPtr jobject = JNIEnv.NewString(value);
				try
				{
					_members.InstanceFields.SetValue("workerClassName.Ljava/lang/String;", this, new JniObjectReference(jobject));
				}
				finally
				{
					JNIEnv.DeleteLocalRef(jobject);
				}
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

		public unsafe bool HasConstraints
		{
			[Register("hasConstraints", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("hasConstraints.()Z", this, null);
			}
		}

		public unsafe bool IsBackedOff
		{
			[Register("isBackedOff", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isBackedOff.()Z", this, null);
			}
		}

		public unsafe bool IsPeriodic
		{
			[Register("isPeriodic", "()Z", "")]
			get
			{
				return _members.InstanceMethods.InvokeAbstractBooleanMethod("isPeriodic.()Z", this, null);
			}
		}

		internal WorkSpec(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register(".ctor", "(Landroidx/work/impl/model/WorkSpec;)V", "")]
		public unsafe WorkSpec(WorkSpec other)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(other?.Handle ?? IntPtr.Zero);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Landroidx/work/impl/model/WorkSpec;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Landroidx/work/impl/model/WorkSpec;)V", this, ptr);
			}
			finally
			{
				GC.KeepAlive(other);
			}
		}

		[Register(".ctor", "(Ljava/lang/String;Ljava/lang/String;)V", "")]
		public unsafe WorkSpec(string id, string workerClassName)
			: base(IntPtr.Zero, JniHandleOwnership.DoNotTransfer)
		{
			if (base.Handle != IntPtr.Zero)
			{
				return;
			}
			IntPtr intPtr = JNIEnv.NewString(id);
			IntPtr intPtr2 = JNIEnv.NewString(workerClassName);
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
				*ptr = new JniArgumentValue(intPtr);
				ptr[1] = new JniArgumentValue(intPtr2);
				SetHandle(_members.InstanceMethods.StartCreateInstance("(Ljava/lang/String;Ljava/lang/String;)V", GetType(), ptr).Handle, JniHandleOwnership.TransferLocalRef);
				_members.InstanceMethods.FinishCreateInstance("(Ljava/lang/String;Ljava/lang/String;)V", this, ptr);
			}
			finally
			{
				JNIEnv.DeleteLocalRef(intPtr);
				JNIEnv.DeleteLocalRef(intPtr2);
			}
		}

		[Register("calculateNextRunTime", "()J", "")]
		public unsafe long CalculateNextRunTime()
		{
			return _members.InstanceMethods.InvokeAbstractInt64Method("calculateNextRunTime.()J", this, null);
		}

		[Register("setBackoffDelayDuration", "(J)V", "")]
		public unsafe void SetBackoffDelayDuration(long backoffDelayDuration)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(backoffDelayDuration);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setBackoffDelayDuration.(J)V", this, ptr);
		}

		[Register("setPeriodic", "(J)V", "")]
		public unsafe void SetPeriodic(long intervalDuration)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
			*ptr = new JniArgumentValue(intervalDuration);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setPeriodic.(J)V", this, ptr);
		}

		[Register("setPeriodic", "(JJ)V", "")]
		public unsafe void SetPeriodic(long intervalDuration, long flexDuration)
		{
			JniArgumentValue* ptr = stackalloc JniArgumentValue[2];
			*ptr = new JniArgumentValue(intervalDuration);
			ptr[1] = new JniArgumentValue(flexDuration);
			_members.InstanceMethods.InvokeAbstractVoidMethod("setPeriodic.(JJ)V", this, ptr);
		}
	}
}
