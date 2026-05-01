using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Polly.Bulkhead;
using Polly.Caching;
using Polly.CircuitBreaker;
using Polly.Fallback;
using Polly.NoOp;
using Polly.Retry;
using Polly.Timeout;
using Polly.Utilities;
using Polly.Wrap;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: InternalsVisibleTo("Polly.Specs, PublicKey=0024000004800000940000000602000000240000525341310004000001000100150819e3494f97263a3abdd18e5e0c47b04e6c0ede44a6c51d50b545d403ceeb7cbb32d18dbbbcdd1d88a87d7b73206b126be134b0609c36aa3cb31dd2e47e393293102809b8d77f192f3188618a42e651c14ebf05f8f5b76aa91b431642b23497ed82b65d63791cdaa31d4282a2d6cbabc3fe0745b6b6690c417cabf6a1349c")]
[assembly: AssemblyCompany("App vNext")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("Copyright (c) 2020, App vNext")]
[assembly: AssemblyDescription("Polly is a library that allows developers to express resilience and transient fault handling policies such as Retry, Circuit Breaker, Timeout, Bulkhead Isolation, and Fallback in a fluent and thread-safe manner.")]
[assembly: AssemblyFileVersion("7.2.1.0")]
[assembly: AssemblyInformationalVersion("7.2.1.0+52968c25f2e13e2708898174c15aafc9cb915020")]
[assembly: AssemblyProduct("Polly")]
[assembly: AssemblyTitle("Polly")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: AssemblyVersion("7.0.0.0")]
namespace Polly
{
	public abstract class AsyncPolicy : PolicyBase, IAsyncPolicy, IsPolicy
	{
		public AsyncPolicy WithPolicyKey(string policyKey)
		{
			if (policyKeyInternal != null)
			{
				throw PolicyBase.PolicyKeyMustBeImmutableException;
			}
			policyKeyInternal = policyKey;
			return this;
		}

		IAsyncPolicy IAsyncPolicy.WithPolicyKey(string policyKey)
		{
			if (policyKeyInternal != null)
			{
				throw PolicyBase.PolicyKeyMustBeImmutableException;
			}
			policyKeyInternal = policyKey;
			return this;
		}

		internal AsyncPolicy(ExceptionPredicates exceptionPredicates)
			: base(exceptionPredicates)
		{
		}

		protected AsyncPolicy(PolicyBuilder policyBuilder = null)
			: base(policyBuilder)
		{
		}

		[DebuggerStepThrough]
		public Task ExecuteAsync(Func<Task> action)
		{
			return ExecuteAsync((Context ctx, CancellationToken ct) => action(), new Context(), DefaultCancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task ExecuteAsync(Func<Context, Task> action, IDictionary<string, object> contextData)
		{
			return ExecuteAsync((Context ctx, CancellationToken ct) => action(ctx), new Context(contextData), DefaultCancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task ExecuteAsync(Func<Context, Task> action, Context context)
		{
			return ExecuteAsync((Context ctx, CancellationToken ct) => action(ctx), context, DefaultCancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task ExecuteAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken)
		{
			return ExecuteAsync((Context ctx, CancellationToken ct) => action(ct), new Context(), cancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task ExecuteAsync(Func<Context, CancellationToken, Task> action, IDictionary<string, object> contextData, CancellationToken cancellationToken)
		{
			return ExecuteAsync(action, new Context(contextData), cancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task ExecuteAsync(Func<Context, CancellationToken, Task> action, Context context, CancellationToken cancellationToken)
		{
			return ExecuteAsync(action, context, cancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task ExecuteAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return ExecuteAsync((Context ctx, CancellationToken ct) => action(ct), new Context(), cancellationToken, continueOnCapturedContext);
		}

		[DebuggerStepThrough]
		public Task ExecuteAsync(Func<Context, CancellationToken, Task> action, IDictionary<string, object> contextData, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return ExecuteAsync(action, new Context(contextData), cancellationToken, continueOnCapturedContext);
		}

		public async Task ExecuteAsync(Func<Context, CancellationToken, Task> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			SetPolicyContext(context, out var priorPolicyWrapKey, out var priorPolicyKey);
			try
			{
				await ImplementationAsync(action, context, cancellationToken, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext);
			}
			finally
			{
				RestorePolicyContext(context, priorPolicyWrapKey, priorPolicyKey);
			}
		}

		[DebuggerStepThrough]
		public Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> action)
		{
			return ExecuteAsync((Context ctx, CancellationToken ct) => action(), new Context(), DefaultCancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<TResult> ExecuteAsync<TResult>(Func<Context, Task<TResult>> action, IDictionary<string, object> contextData)
		{
			return ExecuteAsync((Context ctx, CancellationToken ct) => action(ctx), new Context(contextData), DefaultCancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<TResult> ExecuteAsync<TResult>(Func<Context, Task<TResult>> action, Context context)
		{
			return ExecuteAsync((Context ctx, CancellationToken ct) => action(ctx), context, DefaultCancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<TResult> ExecuteAsync<TResult>(Func<CancellationToken, Task<TResult>> action, CancellationToken cancellationToken)
		{
			return ExecuteAsync((Context ctx, CancellationToken ct) => action(ct), new Context(), cancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<TResult> ExecuteAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, IDictionary<string, object> contextData, CancellationToken cancellationToken)
		{
			return ExecuteAsync(action, new Context(contextData), cancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<TResult> ExecuteAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken)
		{
			return ExecuteAsync(action, context, cancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<TResult> ExecuteAsync<TResult>(Func<CancellationToken, Task<TResult>> action, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return ExecuteAsync((Context ctx, CancellationToken ct) => action(ct), new Context(), cancellationToken, continueOnCapturedContext);
		}

		[DebuggerStepThrough]
		public Task<TResult> ExecuteAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, IDictionary<string, object> contextData, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return ExecuteAsync(action, new Context(contextData), cancellationToken, continueOnCapturedContext);
		}

		public async Task<TResult> ExecuteAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			SetPolicyContext(context, out var priorPolicyWrapKey, out var priorPolicyKey);
			try
			{
				return await ImplementationAsync(action, context, cancellationToken, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext);
			}
			finally
			{
				RestorePolicyContext(context, priorPolicyWrapKey, priorPolicyKey);
			}
		}

		[DebuggerStepThrough]
		public Task<PolicyResult> ExecuteAndCaptureAsync(Func<Task> action)
		{
			return ExecuteAndCaptureAsync((Context ctx, CancellationToken ct) => action(), new Context(), DefaultCancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<PolicyResult> ExecuteAndCaptureAsync(Func<Context, Task> action, IDictionary<string, object> contextData)
		{
			return ExecuteAndCaptureAsync((Context ctx, CancellationToken ct) => action(ctx), new Context(contextData), DefaultCancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<PolicyResult> ExecuteAndCaptureAsync(Func<Context, Task> action, Context context)
		{
			return ExecuteAndCaptureAsync((Context ctx, CancellationToken ct) => action(ctx), context, DefaultCancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<PolicyResult> ExecuteAndCaptureAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken)
		{
			return ExecuteAndCaptureAsync((Context ctx, CancellationToken ct) => action(ct), new Context(), cancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<PolicyResult> ExecuteAndCaptureAsync(Func<Context, CancellationToken, Task> action, IDictionary<string, object> contextData, CancellationToken cancellationToken)
		{
			return ExecuteAndCaptureAsync(action, new Context(contextData), cancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<PolicyResult> ExecuteAndCaptureAsync(Func<Context, CancellationToken, Task> action, Context context, CancellationToken cancellationToken)
		{
			return ExecuteAndCaptureAsync(action, context, cancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<PolicyResult> ExecuteAndCaptureAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return ExecuteAndCaptureAsync((Context ctx, CancellationToken ct) => action(ct), new Context(), cancellationToken, continueOnCapturedContext);
		}

		[DebuggerStepThrough]
		public Task<PolicyResult> ExecuteAndCaptureAsync(Func<Context, CancellationToken, Task> action, IDictionary<string, object> contextData, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return ExecuteAndCaptureAsync(action, new Context(contextData), cancellationToken, continueOnCapturedContext);
		}

		public async Task<PolicyResult> ExecuteAndCaptureAsync(Func<Context, CancellationToken, Task> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			try
			{
				await ExecuteAsync(action, context, cancellationToken, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext);
				return PolicyResult.Successful(context);
			}
			catch (Exception exception)
			{
				return PolicyResult.Failure(exception, PolicyBase.GetExceptionType(base.ExceptionPredicates, exception), context);
			}
		}

		[DebuggerStepThrough]
		public Task<PolicyResult<TResult>> ExecuteAndCaptureAsync<TResult>(Func<Task<TResult>> action)
		{
			return ExecuteAndCaptureAsync((Context ctx, CancellationToken ct) => action(), new Context(), DefaultCancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<PolicyResult<TResult>> ExecuteAndCaptureAsync<TResult>(Func<Context, Task<TResult>> action, IDictionary<string, object> contextData)
		{
			return ExecuteAndCaptureAsync((Context ctx, CancellationToken ct) => action(ctx), new Context(contextData), DefaultCancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<PolicyResult<TResult>> ExecuteAndCaptureAsync<TResult>(Func<Context, Task<TResult>> action, Context context)
		{
			return ExecuteAndCaptureAsync((Context ctx, CancellationToken ct) => action(ctx), context, DefaultCancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<PolicyResult<TResult>> ExecuteAndCaptureAsync<TResult>(Func<CancellationToken, Task<TResult>> action, CancellationToken cancellationToken)
		{
			return ExecuteAndCaptureAsync((Context ctx, CancellationToken ct) => action(ct), new Context(), cancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<PolicyResult<TResult>> ExecuteAndCaptureAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, IDictionary<string, object> contextData, CancellationToken cancellationToken)
		{
			return ExecuteAndCaptureAsync(action, new Context(contextData), cancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<PolicyResult<TResult>> ExecuteAndCaptureAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken)
		{
			return ExecuteAndCaptureAsync(action, context, cancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<PolicyResult<TResult>> ExecuteAndCaptureAsync<TResult>(Func<CancellationToken, Task<TResult>> action, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return ExecuteAndCaptureAsync((Context ctx, CancellationToken ct) => action(ct), new Context(), cancellationToken, continueOnCapturedContext);
		}

		[DebuggerStepThrough]
		public Task<PolicyResult<TResult>> ExecuteAndCaptureAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, IDictionary<string, object> contextData, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return ExecuteAndCaptureAsync(action, new Context(contextData), cancellationToken, continueOnCapturedContext);
		}

		public async Task<PolicyResult<TResult>> ExecuteAndCaptureAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			try
			{
				return PolicyResult<TResult>.Successful(await ExecuteAsync(action, context, cancellationToken, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext), context);
			}
			catch (Exception exception)
			{
				return PolicyResult<TResult>.Failure(exception, PolicyBase.GetExceptionType(base.ExceptionPredicates, exception), context);
			}
		}

		protected virtual Task ImplementationAsync(Func<Context, CancellationToken, Task> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return ImplementationAsync(async delegate(Context ctx, CancellationToken token)
			{
				await action(ctx, token).ConfigureAwait(continueOnCapturedContext);
				return EmptyStruct.Instance;
			}, context, cancellationToken, continueOnCapturedContext);
		}

		protected abstract Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext);

		public AsyncPolicyWrap WrapAsync(IAsyncPolicy innerPolicy)
		{
			if (innerPolicy == null)
			{
				throw new ArgumentNullException("innerPolicy");
			}
			return new AsyncPolicyWrap(this, innerPolicy);
		}

		public AsyncPolicyWrap<TResult> WrapAsync<TResult>(IAsyncPolicy<TResult> innerPolicy)
		{
			if (innerPolicy == null)
			{
				throw new ArgumentNullException("innerPolicy");
			}
			return new AsyncPolicyWrap<TResult>(this, innerPolicy);
		}
	}
	public abstract class AsyncPolicy<TResult> : PolicyBase<TResult>, IAsyncPolicy<TResult>, IsPolicy
	{
		public AsyncPolicy<TResult> WithPolicyKey(string policyKey)
		{
			if (policyKeyInternal != null)
			{
				throw PolicyBase.PolicyKeyMustBeImmutableException;
			}
			policyKeyInternal = policyKey;
			return this;
		}

		IAsyncPolicy<TResult> IAsyncPolicy<TResult>.WithPolicyKey(string policyKey)
		{
			if (policyKeyInternal != null)
			{
				throw PolicyBase.PolicyKeyMustBeImmutableException;
			}
			policyKeyInternal = policyKey;
			return this;
		}

		protected abstract Task<TResult> ImplementationAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext);

		internal AsyncPolicy(ExceptionPredicates exceptionPredicates, ResultPredicates<TResult> resultPredicates)
			: base(exceptionPredicates, resultPredicates)
		{
		}

		protected AsyncPolicy(PolicyBuilder<TResult> policyBuilder = null)
			: base(policyBuilder)
		{
		}

		[DebuggerStepThrough]
		public Task<TResult> ExecuteAsync(Func<Task<TResult>> action)
		{
			return ExecuteAsync((Context ctx, CancellationToken ct) => action(), new Context(), CancellationToken.None, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<TResult> ExecuteAsync(Func<Context, Task<TResult>> action, IDictionary<string, object> contextData)
		{
			return ExecuteAsync((Context ctx, CancellationToken ct) => action(ctx), new Context(contextData), CancellationToken.None, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<TResult> ExecuteAsync(Func<Context, Task<TResult>> action, Context context)
		{
			return ExecuteAsync((Context ctx, CancellationToken ct) => action(ctx), context, CancellationToken.None, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<TResult> ExecuteAsync(Func<CancellationToken, Task<TResult>> action, CancellationToken cancellationToken)
		{
			return ExecuteAsync((Context ctx, CancellationToken ct) => action(ct), new Context(), cancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<TResult> ExecuteAsync(Func<CancellationToken, Task<TResult>> action, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return ExecuteAsync((Context ctx, CancellationToken ct) => action(ct), new Context(), cancellationToken, continueOnCapturedContext);
		}

		[DebuggerStepThrough]
		public Task<TResult> ExecuteAsync(Func<Context, CancellationToken, Task<TResult>> action, IDictionary<string, object> contextData, CancellationToken cancellationToken)
		{
			return ExecuteAsync(action, new Context(contextData), cancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<TResult> ExecuteAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken)
		{
			return ExecuteAsync(action, context, cancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<TResult> ExecuteAsync(Func<Context, CancellationToken, Task<TResult>> action, IDictionary<string, object> contextData, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return ExecuteAsync(action, new Context(contextData), cancellationToken, continueOnCapturedContext);
		}

		public async Task<TResult> ExecuteAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			SetPolicyContext(context, out var priorPolicyWrapKey, out var priorPolicyKey);
			try
			{
				return await ImplementationAsync(action, context, cancellationToken, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext);
			}
			finally
			{
				RestorePolicyContext(context, priorPolicyWrapKey, priorPolicyKey);
			}
		}

		[DebuggerStepThrough]
		public Task<PolicyResult<TResult>> ExecuteAndCaptureAsync(Func<Task<TResult>> action)
		{
			return ExecuteAndCaptureAsync((Context ctx, CancellationToken ct) => action(), new Context(), CancellationToken.None, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<PolicyResult<TResult>> ExecuteAndCaptureAsync(Func<Context, Task<TResult>> action, IDictionary<string, object> contextData)
		{
			return ExecuteAndCaptureAsync((Context ctx, CancellationToken ct) => action(ctx), new Context(contextData), CancellationToken.None, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<PolicyResult<TResult>> ExecuteAndCaptureAsync(Func<Context, Task<TResult>> action, Context context)
		{
			return ExecuteAndCaptureAsync((Context ctx, CancellationToken ct) => action(ctx), context, CancellationToken.None, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<PolicyResult<TResult>> ExecuteAndCaptureAsync(Func<CancellationToken, Task<TResult>> action, CancellationToken cancellationToken)
		{
			return ExecuteAndCaptureAsync((Context ctx, CancellationToken ct) => action(ct), new Context(), cancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<PolicyResult<TResult>> ExecuteAndCaptureAsync(Func<CancellationToken, Task<TResult>> action, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return ExecuteAndCaptureAsync((Context ctx, CancellationToken ct) => action(ct), new Context(), cancellationToken, continueOnCapturedContext);
		}

		[DebuggerStepThrough]
		public Task<PolicyResult<TResult>> ExecuteAndCaptureAsync(Func<Context, CancellationToken, Task<TResult>> action, IDictionary<string, object> contextData, CancellationToken cancellationToken)
		{
			return ExecuteAndCaptureAsync(action, new Context(contextData), cancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<PolicyResult<TResult>> ExecuteAndCaptureAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken)
		{
			return ExecuteAndCaptureAsync(action, context, cancellationToken, continueOnCapturedContext: false);
		}

		[DebuggerStepThrough]
		public Task<PolicyResult<TResult>> ExecuteAndCaptureAsync(Func<Context, CancellationToken, Task<TResult>> action, IDictionary<string, object> contextData, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return ExecuteAndCaptureAsync(action, new Context(contextData), cancellationToken, continueOnCapturedContext);
		}

		public async Task<PolicyResult<TResult>> ExecuteAndCaptureAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			try
			{
				TResult val = await ExecuteAsync(action, context, cancellationToken, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext);
				if (base.ResultPredicates.AnyMatch(val))
				{
					return PolicyResult<TResult>.Failure(val, context);
				}
				return PolicyResult<TResult>.Successful(val, context);
			}
			catch (Exception exception)
			{
				return PolicyResult<TResult>.Failure(exception, PolicyBase.GetExceptionType(base.ExceptionPredicates, exception), context);
			}
		}

		public AsyncPolicyWrap<TResult> WrapAsync(IAsyncPolicy innerPolicy)
		{
			if (innerPolicy == null)
			{
				throw new ArgumentNullException("innerPolicy");
			}
			return new AsyncPolicyWrap<TResult>(this, innerPolicy);
		}

		public AsyncPolicyWrap<TResult> WrapAsync(IAsyncPolicy<TResult> innerPolicy)
		{
			if (innerPolicy == null)
			{
				throw new ArgumentNullException("innerPolicy");
			}
			return new AsyncPolicyWrap<TResult>(this, innerPolicy);
		}
	}
	public abstract class Policy : PolicyBase, ISyncPolicy, IsPolicy
	{
		public static AsyncBulkheadPolicy BulkheadAsync(int maxParallelization)
		{
			Func<Context, Task> onBulkheadRejectedAsync = (Context _) => TaskHelper.EmptyTask;
			return BulkheadAsync(maxParallelization, 0, onBulkheadRejectedAsync);
		}

		public static AsyncBulkheadPolicy BulkheadAsync(int maxParallelization, Func<Context, Task> onBulkheadRejectedAsync)
		{
			return BulkheadAsync(maxParallelization, 0, onBulkheadRejectedAsync);
		}

		public static AsyncBulkheadPolicy BulkheadAsync(int maxParallelization, int maxQueuingActions)
		{
			Func<Context, Task> onBulkheadRejectedAsync = (Context _) => TaskHelper.EmptyTask;
			return BulkheadAsync(maxParallelization, maxQueuingActions, onBulkheadRejectedAsync);
		}

		public static AsyncBulkheadPolicy BulkheadAsync(int maxParallelization, int maxQueuingActions, Func<Context, Task> onBulkheadRejectedAsync)
		{
			if (maxParallelization <= 0)
			{
				throw new ArgumentOutOfRangeException("maxParallelization", "Value must be greater than zero.");
			}
			if (maxQueuingActions < 0)
			{
				throw new ArgumentOutOfRangeException("maxQueuingActions", "Value must be greater than or equal to zero.");
			}
			if (onBulkheadRejectedAsync == null)
			{
				throw new ArgumentNullException("onBulkheadRejectedAsync");
			}
			return new AsyncBulkheadPolicy(maxParallelization, maxQueuingActions, onBulkheadRejectedAsync);
		}

		public static AsyncBulkheadPolicy<TResult> BulkheadAsync<TResult>(int maxParallelization)
		{
			Func<Context, Task> onBulkheadRejectedAsync = (Context _) => TaskHelper.EmptyTask;
			return BulkheadAsync<TResult>(maxParallelization, 0, onBulkheadRejectedAsync);
		}

		public static AsyncBulkheadPolicy<TResult> BulkheadAsync<TResult>(int maxParallelization, Func<Context, Task> onBulkheadRejectedAsync)
		{
			return BulkheadAsync<TResult>(maxParallelization, 0, onBulkheadRejectedAsync);
		}

		public static AsyncBulkheadPolicy<TResult> BulkheadAsync<TResult>(int maxParallelization, int maxQueuingActions)
		{
			Func<Context, Task> onBulkheadRejectedAsync = (Context _) => TaskHelper.EmptyTask;
			return BulkheadAsync<TResult>(maxParallelization, maxQueuingActions, onBulkheadRejectedAsync);
		}

		public static AsyncBulkheadPolicy<TResult> BulkheadAsync<TResult>(int maxParallelization, int maxQueuingActions, Func<Context, Task> onBulkheadRejectedAsync)
		{
			if (maxParallelization <= 0)
			{
				throw new ArgumentOutOfRangeException("maxParallelization", "Value must be greater than zero.");
			}
			if (maxQueuingActions < 0)
			{
				throw new ArgumentOutOfRangeException("maxQueuingActions", "Value must be greater than or equal to zero.");
			}
			if (onBulkheadRejectedAsync == null)
			{
				throw new ArgumentNullException("onBulkheadRejectedAsync");
			}
			return new AsyncBulkheadPolicy<TResult>(maxParallelization, maxQueuingActions, onBulkheadRejectedAsync);
		}

		public static BulkheadPolicy Bulkhead(int maxParallelization)
		{
			Action<Context> onBulkheadRejected = delegate
			{
			};
			return Bulkhead(maxParallelization, 0, onBulkheadRejected);
		}

		public static BulkheadPolicy Bulkhead(int maxParallelization, Action<Context> onBulkheadRejected)
		{
			return Bulkhead(maxParallelization, 0, onBulkheadRejected);
		}

		public static BulkheadPolicy Bulkhead(int maxParallelization, int maxQueuingActions)
		{
			Action<Context> onBulkheadRejected = delegate
			{
			};
			return Bulkhead(maxParallelization, maxQueuingActions, onBulkheadRejected);
		}

		public static BulkheadPolicy Bulkhead(int maxParallelization, int maxQueuingActions, Action<Context> onBulkheadRejected)
		{
			if (maxParallelization <= 0)
			{
				throw new ArgumentOutOfRangeException("maxParallelization", "Value must be greater than zero.");
			}
			if (maxQueuingActions < 0)
			{
				throw new ArgumentOutOfRangeException("maxQueuingActions", "Value must be greater than or equal to zero.");
			}
			if (onBulkheadRejected == null)
			{
				throw new ArgumentNullException("onBulkheadRejected");
			}
			return new BulkheadPolicy(maxParallelization, maxQueuingActions, onBulkheadRejected);
		}

		public static BulkheadPolicy<TResult> Bulkhead<TResult>(int maxParallelization)
		{
			Action<Context> onBulkheadRejected = delegate
			{
			};
			return Bulkhead<TResult>(maxParallelization, 0, onBulkheadRejected);
		}

		public static BulkheadPolicy<TResult> Bulkhead<TResult>(int maxParallelization, Action<Context> onBulkheadRejected)
		{
			return Bulkhead<TResult>(maxParallelization, 0, onBulkheadRejected);
		}

		public static BulkheadPolicy<TResult> Bulkhead<TResult>(int maxParallelization, int maxQueuingActions)
		{
			Action<Context> onBulkheadRejected = delegate
			{
			};
			return Bulkhead<TResult>(maxParallelization, maxQueuingActions, onBulkheadRejected);
		}

		public static BulkheadPolicy<TResult> Bulkhead<TResult>(int maxParallelization, int maxQueuingActions, Action<Context> onBulkheadRejected)
		{
			if (maxParallelization <= 0)
			{
				throw new ArgumentOutOfRangeException("maxParallelization", "Value must be greater than zero.");
			}
			if (maxQueuingActions < 0)
			{
				throw new ArgumentOutOfRangeException("maxQueuingActions", "Value must be greater than or equal to zero.");
			}
			if (onBulkheadRejected == null)
			{
				throw new ArgumentNullException("onBulkheadRejected");
			}
			return new BulkheadPolicy<TResult>(maxParallelization, maxQueuingActions, onBulkheadRejected);
		}

		public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, TimeSpan ttl, Action<Context, string, Exception> onCacheError = null)
		{
			return CacheAsync(cacheProvider, new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
		}

		public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			return CacheAsync(cacheProvider, ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
		}

		public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			return CacheAsync(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheError);
		}

		public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			if (ttlStrategy == null)
			{
				throw new ArgumentNullException("ttlStrategy");
			}
			if (cacheKeyStrategy == null)
			{
				throw new ArgumentNullException("cacheKeyStrategy");
			}
			onCacheError = onCacheError ?? ((Action<Context, string, Exception>)delegate
			{
			});
			Action<Context, string> action = delegate
			{
			};
			return new AsyncCachePolicy(cacheProvider, ttlStrategy, cacheKeyStrategy.GetCacheKey, action, action, action, onCacheError, onCacheError);
		}

		public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			return CacheAsync(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy, onCacheError);
		}

		public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			if (ttlStrategy == null)
			{
				throw new ArgumentNullException("ttlStrategy");
			}
			if (cacheKeyStrategy == null)
			{
				throw new ArgumentNullException("cacheKeyStrategy");
			}
			onCacheError = onCacheError ?? ((Action<Context, string, Exception>)delegate
			{
			});
			Action<Context, string> action = delegate
			{
			};
			return new AsyncCachePolicy(cacheProvider, ttlStrategy, cacheKeyStrategy, action, action, action, onCacheError, onCacheError);
		}

		public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, TimeSpan ttl, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return CacheAsync(cacheProvider, new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return CacheAsync(cacheProvider, ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return CacheAsync(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return CacheAsync(cacheProvider, ttlStrategy, cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return CacheAsync(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static AsyncCachePolicy CacheAsync(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			if (ttlStrategy == null)
			{
				throw new ArgumentNullException("ttlStrategy");
			}
			if (cacheKeyStrategy == null)
			{
				throw new ArgumentNullException("cacheKeyStrategy");
			}
			if (onCacheGet == null)
			{
				throw new ArgumentNullException("onCacheGet");
			}
			if (onCacheMiss == null)
			{
				throw new ArgumentNullException("onCacheMiss");
			}
			if (onCachePut == null)
			{
				throw new ArgumentNullException("onCachePut");
			}
			if (onCachePutError == null)
			{
				throw new ArgumentNullException("onCachePutError");
			}
			if (onCachePutError == null)
			{
				throw new ArgumentNullException("onCachePutError");
			}
			return new AsyncCachePolicy(cacheProvider, ttlStrategy, cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, TimeSpan ttl, Action<Context, string, Exception> onCacheError = null)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return CacheAsync(cacheProvider.AsyncFor<TResult>(), new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return CacheAsync(cacheProvider.AsyncFor<TResult>(), ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return CacheAsync(cacheProvider.AsyncFor<TResult>(), new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return CacheAsync(cacheProvider.AsyncFor<TResult>(), ttlStrategy, cacheKeyStrategy.GetCacheKey, onCacheError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return CacheAsync(cacheProvider.AsyncFor<TResult>(), new RelativeTtl(ttl), cacheKeyStrategy, onCacheError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return CacheAsync(cacheProvider.AsyncFor<TResult>(), ttlStrategy, cacheKeyStrategy, onCacheError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, TimeSpan ttl, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return CacheAsync(cacheProvider.AsyncFor<TResult>(), new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return CacheAsync(cacheProvider.AsyncFor<TResult>(), ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return CacheAsync(cacheProvider.AsyncFor<TResult>(), new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return CacheAsync(cacheProvider.AsyncFor<TResult>(), ttlStrategy, cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return CacheAsync(cacheProvider.AsyncFor<TResult>(), new RelativeTtl(ttl), cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return CacheAsync(cacheProvider.AsyncFor<TResult>(), ttlStrategy, cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, Action<Context, string, Exception> onCacheError = null)
		{
			return CacheAsync(cacheProvider, new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			return CacheAsync(cacheProvider, ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			return CacheAsync(cacheProvider, ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			return CacheAsync(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			onCacheError = onCacheError ?? ((Action<Context, string, Exception>)delegate
			{
			});
			Action<Context, string> action = delegate
			{
			};
			return CacheAsync(cacheProvider, ttlStrategy, cacheKeyStrategy.GetCacheKey, action, action, action, onCacheError, onCacheError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			onCacheError = onCacheError ?? ((Action<Context, string, Exception>)delegate
			{
			});
			Action<Context, string> action = delegate
			{
			};
			return CacheAsync(cacheProvider, ttlStrategy, cacheKeyStrategy.GetCacheKey, action, action, action, onCacheError, onCacheError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			return CacheAsync(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy, onCacheError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			onCacheError = onCacheError ?? ((Action<Context, string, Exception>)delegate
			{
			});
			Action<Context, string> action = delegate
			{
			};
			return CacheAsync(cacheProvider, ttlStrategy, cacheKeyStrategy, action, action, action, onCacheError, onCacheError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			onCacheError = onCacheError ?? ((Action<Context, string, Exception>)delegate
			{
			});
			Action<Context, string> action = delegate
			{
			};
			return CacheAsync(cacheProvider, ttlStrategy, cacheKeyStrategy, action, action, action, onCacheError, onCacheError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return CacheAsync(cacheProvider, new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return CacheAsync(cacheProvider, ttlStrategy.For<TResult>(), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return CacheAsync(cacheProvider, ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return CacheAsync(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return CacheAsync(cacheProvider, ttlStrategy.For<TResult>(), cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return CacheAsync(cacheProvider, ttlStrategy, cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return CacheAsync(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return CacheAsync(cacheProvider, ttlStrategy.For<TResult>(), cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static AsyncCachePolicy<TResult> CacheAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			if (ttlStrategy == null)
			{
				throw new ArgumentNullException("ttlStrategy");
			}
			if (cacheKeyStrategy == null)
			{
				throw new ArgumentNullException("cacheKeyStrategy");
			}
			if (onCacheGet == null)
			{
				throw new ArgumentNullException("onCacheGet");
			}
			if (onCacheMiss == null)
			{
				throw new ArgumentNullException("onCacheMiss");
			}
			if (onCachePut == null)
			{
				throw new ArgumentNullException("onCachePut");
			}
			if (onCachePutError == null)
			{
				throw new ArgumentNullException("onCachePutError");
			}
			if (onCachePutError == null)
			{
				throw new ArgumentNullException("onCachePutError");
			}
			return new AsyncCachePolicy<TResult>(cacheProvider, ttlStrategy, cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static CachePolicy Cache(ISyncCacheProvider cacheProvider, TimeSpan ttl, Action<Context, string, Exception> onCacheError = null)
		{
			return Cache(cacheProvider, new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
		}

		public static CachePolicy Cache(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			return Cache(cacheProvider, ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
		}

		public static CachePolicy Cache(ISyncCacheProvider cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			return Cache(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheError);
		}

		public static CachePolicy Cache(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			if (ttlStrategy == null)
			{
				throw new ArgumentNullException("ttlStrategy");
			}
			if (cacheKeyStrategy == null)
			{
				throw new ArgumentNullException("cacheKeyStrategy");
			}
			onCacheError = onCacheError ?? ((Action<Context, string, Exception>)delegate
			{
			});
			Action<Context, string> action = delegate
			{
			};
			return Cache(cacheProvider, ttlStrategy, cacheKeyStrategy.GetCacheKey, action, action, action, onCacheError, onCacheError);
		}

		public static CachePolicy Cache(ISyncCacheProvider cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			return Cache(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy, onCacheError);
		}

		public static CachePolicy Cache(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			if (ttlStrategy == null)
			{
				throw new ArgumentNullException("ttlStrategy");
			}
			if (cacheKeyStrategy == null)
			{
				throw new ArgumentNullException("cacheKeyStrategy");
			}
			onCacheError = onCacheError ?? ((Action<Context, string, Exception>)delegate
			{
			});
			Action<Context, string> action = delegate
			{
			};
			return Cache(cacheProvider, ttlStrategy, cacheKeyStrategy, action, action, action, onCacheError, onCacheError);
		}

		public static CachePolicy Cache(ISyncCacheProvider cacheProvider, TimeSpan ttl, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return Cache(cacheProvider, new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static CachePolicy Cache(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return Cache(cacheProvider, ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static CachePolicy Cache(ISyncCacheProvider cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return Cache(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static CachePolicy Cache(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return Cache(cacheProvider, ttlStrategy, cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static CachePolicy Cache(ISyncCacheProvider cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return Cache(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static CachePolicy Cache(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			if (ttlStrategy == null)
			{
				throw new ArgumentNullException("ttlStrategy");
			}
			if (cacheKeyStrategy == null)
			{
				throw new ArgumentNullException("cacheKeyStrategy");
			}
			if (onCacheGet == null)
			{
				throw new ArgumentNullException("onCacheGet");
			}
			if (onCacheMiss == null)
			{
				throw new ArgumentNullException("onCacheMiss");
			}
			if (onCachePut == null)
			{
				throw new ArgumentNullException("onCachePut");
			}
			if (onCachePutError == null)
			{
				throw new ArgumentNullException("onCachePutError");
			}
			if (onCachePutError == null)
			{
				throw new ArgumentNullException("onCachePutError");
			}
			return new CachePolicy(cacheProvider, ttlStrategy, cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, TimeSpan ttl, Action<Context, string, Exception> onCacheError = null)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return Cache(cacheProvider.For<TResult>(), new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return Cache(cacheProvider.For<TResult>(), ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return Cache(cacheProvider.For<TResult>(), new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return Cache(cacheProvider.For<TResult>(), ttlStrategy, cacheKeyStrategy.GetCacheKey, onCacheError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return Cache(cacheProvider.For<TResult>(), new RelativeTtl(ttl), cacheKeyStrategy, onCacheError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return Cache(cacheProvider.For<TResult>(), ttlStrategy, cacheKeyStrategy, onCacheError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, TimeSpan ttl, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return Cache(cacheProvider.For<TResult>(), new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return Cache(cacheProvider.For<TResult>(), ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return Cache(cacheProvider.For<TResult>(), new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return Cache(cacheProvider.For<TResult>(), ttlStrategy, cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return Cache(cacheProvider.For<TResult>(), new RelativeTtl(ttl), cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			return Cache(cacheProvider.For<TResult>(), ttlStrategy, cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, Action<Context, string, Exception> onCacheError = null)
		{
			return Cache(cacheProvider, new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			return Cache(cacheProvider, ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			return Cache(cacheProvider, ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			return Cache(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			onCacheError = onCacheError ?? ((Action<Context, string, Exception>)delegate
			{
			});
			Action<Context, string> action = delegate
			{
			};
			return Cache(cacheProvider, ttlStrategy.For<TResult>(), cacheKeyStrategy.GetCacheKey, action, action, action, onCacheError, onCacheError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			onCacheError = onCacheError ?? ((Action<Context, string, Exception>)delegate
			{
			});
			Action<Context, string> action = delegate
			{
			};
			return Cache(cacheProvider, ttlStrategy, cacheKeyStrategy, action, action, action, onCacheError, onCacheError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			return Cache(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy, onCacheError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			onCacheError = onCacheError ?? ((Action<Context, string, Exception>)delegate
			{
			});
			Action<Context, string> action = delegate
			{
			};
			return Cache(cacheProvider, ttlStrategy.For<TResult>(), cacheKeyStrategy, action, action, action, onCacheError, onCacheError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string, Exception> onCacheError = null)
		{
			onCacheError = onCacheError ?? ((Action<Context, string, Exception>)delegate
			{
			});
			Action<Context, string> action = delegate
			{
			};
			return Cache(cacheProvider, ttlStrategy, cacheKeyStrategy, action, action, action, onCacheError, onCacheError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return Cache(cacheProvider, new RelativeTtl(ttl), DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return Cache(cacheProvider, ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return Cache(cacheProvider, ttlStrategy, DefaultCacheKeyStrategy.Instance.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return Cache(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return Cache(cacheProvider, ttlStrategy, cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, ICacheKeyStrategy cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return Cache(cacheProvider, ttlStrategy, cacheKeyStrategy.GetCacheKey, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, TimeSpan ttl, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return Cache(cacheProvider, new RelativeTtl(ttl), cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			return Cache(cacheProvider, ttlStrategy.For<TResult>(), cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static CachePolicy<TResult> Cache<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			if (cacheProvider == null)
			{
				throw new ArgumentNullException("cacheProvider");
			}
			if (ttlStrategy == null)
			{
				throw new ArgumentNullException("ttlStrategy");
			}
			if (cacheKeyStrategy == null)
			{
				throw new ArgumentNullException("cacheKeyStrategy");
			}
			if (onCacheGet == null)
			{
				throw new ArgumentNullException("onCacheGet");
			}
			if (onCacheMiss == null)
			{
				throw new ArgumentNullException("onCacheMiss");
			}
			if (onCachePut == null)
			{
				throw new ArgumentNullException("onCachePut");
			}
			if (onCachePutError == null)
			{
				throw new ArgumentNullException("onCachePutError");
			}
			if (onCachePutError == null)
			{
				throw new ArgumentNullException("onCachePutError");
			}
			return new CachePolicy<TResult>(cacheProvider, ttlStrategy, cacheKeyStrategy, onCacheGet, onCacheMiss, onCachePut, onCacheGetError, onCachePutError);
		}

		public static AsyncNoOpPolicy NoOpAsync()
		{
			return new AsyncNoOpPolicy();
		}

		public static AsyncNoOpPolicy<TResult> NoOpAsync<TResult>()
		{
			return new AsyncNoOpPolicy<TResult>();
		}

		public static NoOpPolicy NoOp()
		{
			return new NoOpPolicy();
		}

		public static NoOpPolicy<TResult> NoOp<TResult>()
		{
			return new NoOpPolicy<TResult>();
		}

		public Policy WithPolicyKey(string policyKey)
		{
			if (policyKeyInternal != null)
			{
				throw PolicyBase.PolicyKeyMustBeImmutableException;
			}
			policyKeyInternal = policyKey;
			return this;
		}

		ISyncPolicy ISyncPolicy.WithPolicyKey(string policyKey)
		{
			if (policyKeyInternal != null)
			{
				throw PolicyBase.PolicyKeyMustBeImmutableException;
			}
			policyKeyInternal = policyKey;
			return this;
		}

		internal Policy(ExceptionPredicates exceptionPredicates)
			: base(exceptionPredicates)
		{
		}

		protected Policy(PolicyBuilder policyBuilder = null)
			: base(policyBuilder)
		{
		}

		[DebuggerStepThrough]
		public void Execute(Action action)
		{
			Execute(delegate
			{
				action();
			}, new Context(), DefaultCancellationToken);
		}

		[DebuggerStepThrough]
		public void Execute(Action<Context> action, IDictionary<string, object> contextData)
		{
			Execute(delegate(Context ctx, CancellationToken ct)
			{
				action(ctx);
			}, new Context(contextData), DefaultCancellationToken);
		}

		[DebuggerStepThrough]
		public void Execute(Action<Context> action, Context context)
		{
			Execute(delegate(Context ctx, CancellationToken ct)
			{
				action(ctx);
			}, context, DefaultCancellationToken);
		}

		[DebuggerStepThrough]
		public void Execute(Action<CancellationToken> action, CancellationToken cancellationToken)
		{
			Execute(delegate(Context ctx, CancellationToken ct)
			{
				action(ct);
			}, new Context(), cancellationToken);
		}

		[DebuggerStepThrough]
		public void Execute(Action<Context, CancellationToken> action, IDictionary<string, object> contextData, CancellationToken cancellationToken)
		{
			Execute(action, new Context(contextData), cancellationToken);
		}

		[DebuggerStepThrough]
		public void Execute(Action<Context, CancellationToken> action, Context context, CancellationToken cancellationToken)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			SetPolicyContext(context, out var priorPolicyWrapKey, out var priorPolicyKey);
			try
			{
				Implementation(action, context, cancellationToken);
			}
			finally
			{
				RestorePolicyContext(context, priorPolicyWrapKey, priorPolicyKey);
			}
		}

		[DebuggerStepThrough]
		public TResult Execute<TResult>(Func<TResult> action)
		{
			return Execute((Context ctx, CancellationToken ct) => action(), new Context(), DefaultCancellationToken);
		}

		[DebuggerStepThrough]
		public TResult Execute<TResult>(Func<Context, TResult> action, IDictionary<string, object> contextData)
		{
			return Execute((Context ctx, CancellationToken ct) => action(ctx), new Context(contextData), DefaultCancellationToken);
		}

		[DebuggerStepThrough]
		public TResult Execute<TResult>(Func<Context, TResult> action, Context context)
		{
			return Execute((Context ctx, CancellationToken ct) => action(ctx), context, DefaultCancellationToken);
		}

		[DebuggerStepThrough]
		public TResult Execute<TResult>(Func<CancellationToken, TResult> action, CancellationToken cancellationToken)
		{
			return Execute((Context ctx, CancellationToken ct) => action(ct), new Context(), cancellationToken);
		}

		[DebuggerStepThrough]
		public TResult Execute<TResult>(Func<Context, CancellationToken, TResult> action, IDictionary<string, object> contextData, CancellationToken cancellationToken)
		{
			return Execute(action, new Context(contextData), cancellationToken);
		}

		[DebuggerStepThrough]
		public TResult Execute<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			SetPolicyContext(context, out var priorPolicyWrapKey, out var priorPolicyKey);
			try
			{
				return Implementation(action, context, cancellationToken);
			}
			finally
			{
				RestorePolicyContext(context, priorPolicyWrapKey, priorPolicyKey);
			}
		}

		[DebuggerStepThrough]
		public PolicyResult ExecuteAndCapture(Action action)
		{
			return ExecuteAndCapture(delegate
			{
				action();
			}, new Context(), DefaultCancellationToken);
		}

		[DebuggerStepThrough]
		public PolicyResult ExecuteAndCapture(Action<Context> action, IDictionary<string, object> contextData)
		{
			return ExecuteAndCapture(delegate(Context ctx, CancellationToken ct)
			{
				action(ctx);
			}, new Context(contextData), DefaultCancellationToken);
		}

		[DebuggerStepThrough]
		public PolicyResult ExecuteAndCapture(Action<Context> action, Context context)
		{
			return ExecuteAndCapture(delegate(Context ctx, CancellationToken ct)
			{
				action(ctx);
			}, context, DefaultCancellationToken);
		}

		[DebuggerStepThrough]
		public PolicyResult ExecuteAndCapture(Action<CancellationToken> action, CancellationToken cancellationToken)
		{
			return ExecuteAndCapture(delegate(Context ctx, CancellationToken ct)
			{
				action(ct);
			}, new Context(), cancellationToken);
		}

		[DebuggerStepThrough]
		public PolicyResult ExecuteAndCapture(Action<Context, CancellationToken> action, IDictionary<string, object> contextData, CancellationToken cancellationToken)
		{
			return ExecuteAndCapture(action, new Context(contextData), cancellationToken);
		}

		[DebuggerStepThrough]
		public PolicyResult ExecuteAndCapture(Action<Context, CancellationToken> action, Context context, CancellationToken cancellationToken)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			try
			{
				Execute(action, context, cancellationToken);
				return PolicyResult.Successful(context);
			}
			catch (Exception exception)
			{
				return PolicyResult.Failure(exception, PolicyBase.GetExceptionType(base.ExceptionPredicates, exception), context);
			}
		}

		[DebuggerStepThrough]
		public PolicyResult<TResult> ExecuteAndCapture<TResult>(Func<TResult> action)
		{
			return ExecuteAndCapture((Context ctx, CancellationToken ct) => action(), new Context(), DefaultCancellationToken);
		}

		[DebuggerStepThrough]
		public PolicyResult<TResult> ExecuteAndCapture<TResult>(Func<Context, TResult> action, IDictionary<string, object> contextData)
		{
			return ExecuteAndCapture((Context ctx, CancellationToken ct) => action(ctx), new Context(contextData), DefaultCancellationToken);
		}

		[DebuggerStepThrough]
		public PolicyResult<TResult> ExecuteAndCapture<TResult>(Func<Context, TResult> action, Context context)
		{
			return ExecuteAndCapture((Context ctx, CancellationToken ct) => action(ctx), context, DefaultCancellationToken);
		}

		public PolicyResult<TResult> ExecuteAndCapture<TResult>(Func<CancellationToken, TResult> action, CancellationToken cancellationToken)
		{
			return ExecuteAndCapture((Context ctx, CancellationToken ct) => action(ct), new Context(), cancellationToken);
		}

		[DebuggerStepThrough]
		public PolicyResult<TResult> ExecuteAndCapture<TResult>(Func<Context, CancellationToken, TResult> action, IDictionary<string, object> contextData, CancellationToken cancellationToken)
		{
			return ExecuteAndCapture(action, new Context(contextData), cancellationToken);
		}

		[DebuggerStepThrough]
		public PolicyResult<TResult> ExecuteAndCapture<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			try
			{
				return PolicyResult<TResult>.Successful(Execute(action, context, cancellationToken), context);
			}
			catch (Exception exception)
			{
				return PolicyResult<TResult>.Failure(exception, PolicyBase.GetExceptionType(base.ExceptionPredicates, exception), context);
			}
		}

		public static PolicyBuilder Handle<TException>() where TException : Exception
		{
			return new PolicyBuilder((Exception exception) => (!(exception is TException)) ? null : exception);
		}

		public static PolicyBuilder Handle<TException>(Func<TException, bool> exceptionPredicate) where TException : Exception
		{
			return new PolicyBuilder((Exception exception) => (!(exception is TException arg) || !exceptionPredicate(arg)) ? null : exception);
		}

		public static PolicyBuilder HandleInner<TException>() where TException : Exception
		{
			return new PolicyBuilder(PolicyBuilder.HandleInner((Exception ex) => ex is TException));
		}

		public static PolicyBuilder HandleInner<TException>(Func<TException, bool> exceptionPredicate) where TException : Exception
		{
			return new PolicyBuilder(PolicyBuilder.HandleInner((Exception ex) => ex is TException arg && exceptionPredicate(arg)));
		}

		public static PolicyBuilder<TResult> HandleResult<TResult>(Func<TResult, bool> resultPredicate)
		{
			return new PolicyBuilder<TResult>(resultPredicate);
		}

		public static PolicyBuilder<TResult> HandleResult<TResult>(TResult result)
		{
			return HandleResult((TResult r) => (r != null && r.Equals(result)) || (r == null && result == null));
		}

		[DebuggerStepThrough]
		protected virtual void Implementation(Action<Context, CancellationToken> action, Context context, CancellationToken cancellationToken)
		{
			Implementation(delegate(Context ctx, CancellationToken token)
			{
				action(ctx, token);
				return EmptyStruct.Instance;
			}, context, cancellationToken);
		}

		protected abstract TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken);

		public static AsyncTimeoutPolicy TimeoutAsync(int seconds)
		{
			TimeoutValidator.ValidateSecondsTimeout(seconds);
			return TimeoutAsync(onTimeoutAsync: (Context _, TimeSpan __, Task ___, Exception ____) => TaskHelper.EmptyTask, timeoutProvider: (Context ctx) => TimeSpan.FromSeconds(seconds), timeoutStrategy: TimeoutStrategy.Optimistic);
		}

		public static AsyncTimeoutPolicy TimeoutAsync(int seconds, TimeoutStrategy timeoutStrategy)
		{
			TimeoutValidator.ValidateSecondsTimeout(seconds);
			return TimeoutAsync(onTimeoutAsync: (Context _, TimeSpan __, Task ___, Exception ____) => TaskHelper.EmptyTask, timeoutProvider: (Context ctx) => TimeSpan.FromSeconds(seconds), timeoutStrategy: timeoutStrategy);
		}

		public static AsyncTimeoutPolicy TimeoutAsync(int seconds, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
		{
			TimeoutValidator.ValidateSecondsTimeout(seconds);
			if (onTimeoutAsync == null)
			{
				throw new ArgumentNullException("onTimeoutAsync");
			}
			return TimeoutAsync((Context ctx) => TimeSpan.FromSeconds(seconds), TimeoutStrategy.Optimistic, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy TimeoutAsync(int seconds, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
		{
			if (seconds <= 0)
			{
				throw new ArgumentOutOfRangeException("seconds");
			}
			if (onTimeoutAsync == null)
			{
				throw new ArgumentNullException("onTimeoutAsync");
			}
			return TimeoutAsync((Context ctx) => TimeSpan.FromSeconds(seconds), TimeoutStrategy.Optimistic, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy TimeoutAsync(int seconds, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
		{
			TimeoutValidator.ValidateSecondsTimeout(seconds);
			return TimeoutAsync((Context ctx) => TimeSpan.FromSeconds(seconds), timeoutStrategy, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy TimeoutAsync(int seconds, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
		{
			if (seconds <= 0)
			{
				throw new ArgumentOutOfRangeException("seconds");
			}
			return TimeoutAsync((Context ctx) => TimeSpan.FromSeconds(seconds), timeoutStrategy, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy TimeoutAsync(TimeSpan timeout)
		{
			TimeoutValidator.ValidateTimeSpanTimeout(timeout);
			return TimeoutAsync(onTimeoutAsync: (Context _, TimeSpan __, Task ___, Exception ____) => TaskHelper.EmptyTask, timeoutProvider: (Context ctx) => timeout, timeoutStrategy: TimeoutStrategy.Optimistic);
		}

		public static AsyncTimeoutPolicy TimeoutAsync(TimeSpan timeout, TimeoutStrategy timeoutStrategy)
		{
			TimeoutValidator.ValidateTimeSpanTimeout(timeout);
			return TimeoutAsync(onTimeoutAsync: (Context _, TimeSpan __, Task ___, Exception ____) => TaskHelper.EmptyTask, timeoutProvider: (Context ctx) => timeout, timeoutStrategy: timeoutStrategy);
		}

		public static AsyncTimeoutPolicy TimeoutAsync(TimeSpan timeout, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
		{
			TimeoutValidator.ValidateTimeSpanTimeout(timeout);
			return TimeoutAsync((Context ctx) => timeout, TimeoutStrategy.Optimistic, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy TimeoutAsync(TimeSpan timeout, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
		{
			TimeoutValidator.ValidateTimeSpanTimeout(timeout);
			return TimeoutAsync((Context ctx) => timeout, TimeoutStrategy.Optimistic, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy TimeoutAsync(TimeSpan timeout, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
		{
			TimeoutValidator.ValidateTimeSpanTimeout(timeout);
			return TimeoutAsync((Context ctx) => timeout, timeoutStrategy, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy TimeoutAsync(TimeSpan timeout, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
		{
			TimeoutValidator.ValidateTimeSpanTimeout(timeout);
			return TimeoutAsync((Context ctx) => timeout, timeoutStrategy, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy TimeoutAsync(Func<TimeSpan> timeoutProvider)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return TimeoutAsync(onTimeoutAsync: (Context _, TimeSpan __, Task ___, Exception ____) => TaskHelper.EmptyTask, timeoutProvider: (Context ctx) => timeoutProvider(), timeoutStrategy: TimeoutStrategy.Optimistic);
		}

		public static AsyncTimeoutPolicy TimeoutAsync(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return TimeoutAsync(onTimeoutAsync: (Context _, TimeSpan __, Task ___, Exception ____) => TaskHelper.EmptyTask, timeoutProvider: (Context ctx) => timeoutProvider(), timeoutStrategy: timeoutStrategy);
		}

		public static AsyncTimeoutPolicy TimeoutAsync(Func<TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return TimeoutAsync((Context ctx) => timeoutProvider(), TimeoutStrategy.Optimistic, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy TimeoutAsync(Func<TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return TimeoutAsync((Context ctx) => timeoutProvider(), TimeoutStrategy.Optimistic, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy TimeoutAsync(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return TimeoutAsync((Context ctx) => timeoutProvider(), timeoutStrategy, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy TimeoutAsync(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return TimeoutAsync((Context ctx) => timeoutProvider(), timeoutStrategy, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy TimeoutAsync(Func<Context, TimeSpan> timeoutProvider)
		{
			Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync = (Context _, TimeSpan __, Task ___, Exception ____) => TaskHelper.EmptyTask;
			return TimeoutAsync(timeoutProvider, TimeoutStrategy.Optimistic, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy TimeoutAsync(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy)
		{
			Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync = (Context _, TimeSpan __, Task ___, Exception ____) => TaskHelper.EmptyTask;
			return TimeoutAsync(timeoutProvider, timeoutStrategy, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy TimeoutAsync(Func<Context, TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
		{
			return TimeoutAsync(timeoutProvider, TimeoutStrategy.Optimistic, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy TimeoutAsync(Func<Context, TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
		{
			return TimeoutAsync(timeoutProvider, TimeoutStrategy.Optimistic, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy TimeoutAsync(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
		{
			if (onTimeoutAsync == null)
			{
				throw new ArgumentNullException("onTimeoutAsync");
			}
			return TimeoutAsync(timeoutProvider, timeoutStrategy, (Context ctx, TimeSpan timeout, Task task, Exception ex) => onTimeoutAsync(ctx, timeout, task));
		}

		public static AsyncTimeoutPolicy TimeoutAsync(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			if (onTimeoutAsync == null)
			{
				throw new ArgumentNullException("onTimeoutAsync");
			}
			return new AsyncTimeoutPolicy(timeoutProvider, timeoutStrategy, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(int seconds)
		{
			TimeoutValidator.ValidateSecondsTimeout(seconds);
			return TimeoutAsync<TResult>(onTimeoutAsync: (Context _, TimeSpan __, Task ___, Exception ____) => Task.FromResult(default(TResult)), timeoutProvider: (Context ctx) => TimeSpan.FromSeconds(seconds), timeoutStrategy: TimeoutStrategy.Optimistic);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(int seconds, TimeoutStrategy timeoutStrategy)
		{
			TimeoutValidator.ValidateSecondsTimeout(seconds);
			return TimeoutAsync<TResult>(onTimeoutAsync: (Context _, TimeSpan __, Task ___, Exception ____) => Task.FromResult(default(TResult)), timeoutProvider: (Context ctx) => TimeSpan.FromSeconds(seconds), timeoutStrategy: timeoutStrategy);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(int seconds, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
		{
			TimeoutValidator.ValidateSecondsTimeout(seconds);
			return TimeoutAsync<TResult>((Context ctx) => TimeSpan.FromSeconds(seconds), TimeoutStrategy.Optimistic, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(int seconds, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
		{
			if (seconds <= 0)
			{
				throw new ArgumentOutOfRangeException("seconds");
			}
			return TimeoutAsync<TResult>((Context ctx) => TimeSpan.FromSeconds(seconds), TimeoutStrategy.Optimistic, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(int seconds, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
		{
			TimeoutValidator.ValidateSecondsTimeout(seconds);
			return TimeoutAsync<TResult>((Context ctx) => TimeSpan.FromSeconds(seconds), timeoutStrategy, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(int seconds, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
		{
			if (seconds <= 0)
			{
				throw new ArgumentOutOfRangeException("seconds");
			}
			return TimeoutAsync<TResult>((Context ctx) => TimeSpan.FromSeconds(seconds), timeoutStrategy, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(TimeSpan timeout)
		{
			TimeoutValidator.ValidateTimeSpanTimeout(timeout);
			return TimeoutAsync<TResult>(onTimeoutAsync: (Context _, TimeSpan __, Task ___, Exception ____) => Task.FromResult(default(TResult)), timeoutProvider: (Context ctx) => timeout, timeoutStrategy: TimeoutStrategy.Optimistic);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(TimeSpan timeout, TimeoutStrategy timeoutStrategy)
		{
			TimeoutValidator.ValidateTimeSpanTimeout(timeout);
			return TimeoutAsync<TResult>(onTimeoutAsync: (Context _, TimeSpan __, Task ___, Exception ____) => Task.FromResult(default(TResult)), timeoutProvider: (Context ctx) => timeout, timeoutStrategy: timeoutStrategy);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(TimeSpan timeout, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
		{
			TimeoutValidator.ValidateTimeSpanTimeout(timeout);
			if (onTimeoutAsync == null)
			{
				throw new ArgumentNullException("onTimeoutAsync");
			}
			return TimeoutAsync<TResult>((Context ctx) => timeout, TimeoutStrategy.Optimistic, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(TimeSpan timeout, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
		{
			if (timeout <= TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException("timeout");
			}
			if (onTimeoutAsync == null)
			{
				throw new ArgumentNullException("onTimeoutAsync");
			}
			return TimeoutAsync<TResult>((Context ctx) => timeout, TimeoutStrategy.Optimistic, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(TimeSpan timeout, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
		{
			TimeoutValidator.ValidateTimeSpanTimeout(timeout);
			return TimeoutAsync<TResult>((Context ctx) => timeout, timeoutStrategy, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(TimeSpan timeout, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
		{
			if (timeout <= TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException("timeout");
			}
			return TimeoutAsync<TResult>((Context ctx) => timeout, timeoutStrategy, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<TimeSpan> timeoutProvider)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return TimeoutAsync<TResult>(onTimeoutAsync: (Context _, TimeSpan __, Task ___, Exception ____) => Task.FromResult(default(TResult)), timeoutProvider: (Context ctx) => timeoutProvider(), timeoutStrategy: TimeoutStrategy.Optimistic);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return TimeoutAsync<TResult>(onTimeoutAsync: (Context _, TimeSpan __, Task ___, Exception ____) => Task.FromResult(default(TResult)), timeoutProvider: (Context ctx) => timeoutProvider(), timeoutStrategy: timeoutStrategy);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return TimeoutAsync<TResult>((Context ctx) => timeoutProvider(), TimeoutStrategy.Optimistic, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return TimeoutAsync<TResult>((Context ctx) => timeoutProvider(), TimeoutStrategy.Optimistic, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return TimeoutAsync<TResult>((Context ctx) => timeoutProvider(), onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return TimeoutAsync<TResult>((Context ctx) => timeoutProvider(), timeoutStrategy, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<Context, TimeSpan> timeoutProvider)
		{
			Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync = (Context _, TimeSpan __, Task ___, Exception ____) => Task.FromResult(default(TResult));
			return TimeoutAsync<TResult>(timeoutProvider, TimeoutStrategy.Optimistic, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy)
		{
			Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync = (Context _, TimeSpan __, Task ___, Exception ____) => Task.FromResult(default(TResult));
			return TimeoutAsync<TResult>(timeoutProvider, timeoutStrategy, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<Context, TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
		{
			return TimeoutAsync<TResult>(timeoutProvider, TimeoutStrategy.Optimistic, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<Context, TimeSpan> timeoutProvider, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
		{
			return TimeoutAsync<TResult>(timeoutProvider, TimeoutStrategy.Optimistic, onTimeoutAsync);
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Task> onTimeoutAsync)
		{
			if (onTimeoutAsync == null)
			{
				throw new ArgumentNullException("onTimeoutAsync");
			}
			return TimeoutAsync<TResult>(timeoutProvider, timeoutStrategy, (Context ctx, TimeSpan timeout, Task task, Exception ex) => onTimeoutAsync(ctx, timeout, task));
		}

		public static AsyncTimeoutPolicy<TResult> TimeoutAsync<TResult>(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			if (onTimeoutAsync == null)
			{
				throw new ArgumentNullException("onTimeoutAsync");
			}
			return new AsyncTimeoutPolicy<TResult>(timeoutProvider, timeoutStrategy, onTimeoutAsync);
		}

		public static TimeoutPolicy Timeout(int seconds)
		{
			TimeoutValidator.ValidateSecondsTimeout(seconds);
			return Timeout(onTimeout: (Action<Context, TimeSpan, Task, Exception>)delegate
			{
			}, timeoutProvider: (Func<Context, TimeSpan>)((Context ctx) => TimeSpan.FromSeconds(seconds)), timeoutStrategy: TimeoutStrategy.Optimistic);
		}

		public static TimeoutPolicy Timeout(int seconds, TimeoutStrategy timeoutStrategy)
		{
			TimeoutValidator.ValidateSecondsTimeout(seconds);
			return Timeout(onTimeout: (Action<Context, TimeSpan, Task, Exception>)delegate
			{
			}, timeoutProvider: (Func<Context, TimeSpan>)((Context ctx) => TimeSpan.FromSeconds(seconds)), timeoutStrategy: timeoutStrategy);
		}

		public static TimeoutPolicy Timeout(int seconds, Action<Context, TimeSpan, Task> onTimeout)
		{
			TimeoutValidator.ValidateSecondsTimeout(seconds);
			return Timeout((Context ctx) => TimeSpan.FromSeconds(seconds), TimeoutStrategy.Optimistic, onTimeout);
		}

		public static TimeoutPolicy Timeout(int seconds, Action<Context, TimeSpan, Task, Exception> onTimeout)
		{
			if (seconds <= 0)
			{
				throw new ArgumentOutOfRangeException("seconds");
			}
			return Timeout((Context ctx) => TimeSpan.FromSeconds(seconds), TimeoutStrategy.Optimistic, onTimeout);
		}

		public static TimeoutPolicy Timeout(int seconds, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task> onTimeout)
		{
			TimeoutValidator.ValidateSecondsTimeout(seconds);
			return Timeout((Context ctx) => TimeSpan.FromSeconds(seconds), timeoutStrategy, onTimeout);
		}

		public static TimeoutPolicy Timeout(int seconds, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
		{
			if (seconds <= 0)
			{
				throw new ArgumentOutOfRangeException("seconds");
			}
			return Timeout((Context ctx) => TimeSpan.FromSeconds(seconds), timeoutStrategy, onTimeout);
		}

		public static TimeoutPolicy Timeout(TimeSpan timeout)
		{
			TimeoutValidator.ValidateTimeSpanTimeout(timeout);
			return Timeout(onTimeout: (Action<Context, TimeSpan, Task, Exception>)delegate
			{
			}, timeoutProvider: (Func<Context, TimeSpan>)((Context ctx) => timeout), timeoutStrategy: TimeoutStrategy.Optimistic);
		}

		public static TimeoutPolicy Timeout(TimeSpan timeout, TimeoutStrategy timeoutStrategy)
		{
			TimeoutValidator.ValidateTimeSpanTimeout(timeout);
			return Timeout(onTimeout: (Action<Context, TimeSpan, Task, Exception>)delegate
			{
			}, timeoutProvider: (Func<Context, TimeSpan>)((Context ctx) => timeout), timeoutStrategy: timeoutStrategy);
		}

		public static TimeoutPolicy Timeout(TimeSpan timeout, Action<Context, TimeSpan, Task> onTimeout)
		{
			TimeoutValidator.ValidateTimeSpanTimeout(timeout);
			return Timeout((Context ctx) => timeout, TimeoutStrategy.Optimistic, onTimeout);
		}

		public static TimeoutPolicy Timeout(TimeSpan timeout, Action<Context, TimeSpan, Task, Exception> onTimeout)
		{
			TimeoutValidator.ValidateTimeSpanTimeout(timeout);
			return Timeout((Context ctx) => timeout, TimeoutStrategy.Optimistic, onTimeout);
		}

		public static TimeoutPolicy Timeout(TimeSpan timeout, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task> onTimeout)
		{
			TimeoutValidator.ValidateTimeSpanTimeout(timeout);
			return Timeout((Context ctx) => timeout, timeoutStrategy, onTimeout);
		}

		public static TimeoutPolicy Timeout(TimeSpan timeout, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
		{
			TimeoutValidator.ValidateTimeSpanTimeout(timeout);
			return Timeout((Context ctx) => timeout, timeoutStrategy, onTimeout);
		}

		public static TimeoutPolicy Timeout(Func<TimeSpan> timeoutProvider)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return Timeout(onTimeout: (Action<Context, TimeSpan, Task, Exception>)delegate
			{
			}, timeoutProvider: (Func<Context, TimeSpan>)((Context ctx) => timeoutProvider()), timeoutStrategy: TimeoutStrategy.Optimistic);
		}

		public static TimeoutPolicy Timeout(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return Timeout(onTimeout: (Action<Context, TimeSpan, Task, Exception>)delegate
			{
			}, timeoutProvider: (Func<Context, TimeSpan>)((Context ctx) => timeoutProvider()), timeoutStrategy: timeoutStrategy);
		}

		public static TimeoutPolicy Timeout(Func<TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task> onTimeout)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return Timeout((Context ctx) => timeoutProvider(), TimeoutStrategy.Optimistic, onTimeout);
		}

		public static TimeoutPolicy Timeout(Func<TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task, Exception> onTimeout)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return Timeout((Context ctx) => timeoutProvider(), TimeoutStrategy.Optimistic, onTimeout);
		}

		public static TimeoutPolicy Timeout(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task> onTimeout)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return Timeout((Context ctx) => timeoutProvider(), timeoutStrategy, onTimeout);
		}

		public static TimeoutPolicy Timeout(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return Timeout((Context ctx) => timeoutProvider(), timeoutStrategy, onTimeout);
		}

		public static TimeoutPolicy Timeout(Func<Context, TimeSpan> timeoutProvider)
		{
			Action<Context, TimeSpan, Task, Exception> onTimeout = delegate
			{
			};
			return Timeout(timeoutProvider, TimeoutStrategy.Optimistic, onTimeout);
		}

		public static TimeoutPolicy Timeout(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy)
		{
			Action<Context, TimeSpan, Task, Exception> onTimeout = delegate
			{
			};
			return Timeout(timeoutProvider, timeoutStrategy, onTimeout);
		}

		public static TimeoutPolicy Timeout(Func<Context, TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task> onTimeout)
		{
			return Timeout(timeoutProvider, TimeoutStrategy.Optimistic, onTimeout);
		}

		public static TimeoutPolicy Timeout(Func<Context, TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task, Exception> onTimeout)
		{
			return Timeout(timeoutProvider, TimeoutStrategy.Optimistic, onTimeout);
		}

		public static TimeoutPolicy Timeout(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task> onTimeout)
		{
			if (onTimeout == null)
			{
				throw new ArgumentNullException("onTimeout");
			}
			return Timeout(timeoutProvider, timeoutStrategy, delegate(Context ctx, TimeSpan timeout, Task task, Exception ex)
			{
				onTimeout(ctx, timeout, task);
			});
		}

		public static TimeoutPolicy Timeout(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			if (onTimeout == null)
			{
				throw new ArgumentNullException("onTimeout");
			}
			return new TimeoutPolicy(timeoutProvider, timeoutStrategy, onTimeout);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(int seconds)
		{
			TimeoutValidator.ValidateSecondsTimeout(seconds);
			return Policy.Timeout<TResult>(onTimeout: (Action<Context, TimeSpan, Task, Exception>)delegate
			{
			}, timeoutProvider: (Func<Context, TimeSpan>)((Context ctx) => TimeSpan.FromSeconds(seconds)), timeoutStrategy: TimeoutStrategy.Optimistic);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(int seconds, TimeoutStrategy timeoutStrategy)
		{
			TimeoutValidator.ValidateSecondsTimeout(seconds);
			return Policy.Timeout<TResult>(onTimeout: (Action<Context, TimeSpan, Task, Exception>)delegate
			{
			}, timeoutProvider: (Func<Context, TimeSpan>)((Context ctx) => TimeSpan.FromSeconds(seconds)), timeoutStrategy: timeoutStrategy);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(int seconds, Action<Context, TimeSpan, Task> onTimeout)
		{
			TimeoutValidator.ValidateSecondsTimeout(seconds);
			return Timeout<TResult>((Context ctx) => TimeSpan.FromSeconds(seconds), TimeoutStrategy.Optimistic, onTimeout);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(int seconds, Action<Context, TimeSpan, Task, Exception> onTimeout)
		{
			if (seconds <= 0)
			{
				throw new ArgumentOutOfRangeException("seconds");
			}
			return Timeout<TResult>((Context ctx) => TimeSpan.FromSeconds(seconds), TimeoutStrategy.Optimistic, onTimeout);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(int seconds, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task> onTimeout)
		{
			TimeoutValidator.ValidateSecondsTimeout(seconds);
			return Timeout<TResult>((Context ctx) => TimeSpan.FromSeconds(seconds), timeoutStrategy, onTimeout);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(int seconds, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
		{
			if (seconds <= 0)
			{
				throw new ArgumentOutOfRangeException("seconds");
			}
			return Timeout<TResult>((Context ctx) => TimeSpan.FromSeconds(seconds), timeoutStrategy, onTimeout);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(TimeSpan timeout)
		{
			TimeoutValidator.ValidateTimeSpanTimeout(timeout);
			return Policy.Timeout<TResult>(onTimeout: (Action<Context, TimeSpan, Task, Exception>)delegate
			{
			}, timeoutProvider: (Func<Context, TimeSpan>)((Context ctx) => timeout), timeoutStrategy: TimeoutStrategy.Optimistic);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(TimeSpan timeout, TimeoutStrategy timeoutStrategy)
		{
			TimeoutValidator.ValidateTimeSpanTimeout(timeout);
			return Policy.Timeout<TResult>(onTimeout: (Action<Context, TimeSpan, Task, Exception>)delegate
			{
			}, timeoutProvider: (Func<Context, TimeSpan>)((Context ctx) => timeout), timeoutStrategy: timeoutStrategy);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(TimeSpan timeout, Action<Context, TimeSpan, Task> onTimeout)
		{
			TimeoutValidator.ValidateTimeSpanTimeout(timeout);
			return Timeout<TResult>((Context ctx) => timeout, TimeoutStrategy.Optimistic, onTimeout);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(TimeSpan timeout, Action<Context, TimeSpan, Task, Exception> onTimeout)
		{
			TimeoutValidator.ValidateTimeSpanTimeout(timeout);
			return Timeout<TResult>((Context ctx) => timeout, TimeoutStrategy.Optimistic, onTimeout);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(TimeSpan timeout, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task> onTimeout)
		{
			TimeoutValidator.ValidateTimeSpanTimeout(timeout);
			return Timeout<TResult>((Context ctx) => timeout, timeoutStrategy, onTimeout);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(TimeSpan timeout, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
		{
			TimeoutValidator.ValidateTimeSpanTimeout(timeout);
			return Timeout<TResult>((Context ctx) => timeout, timeoutStrategy, onTimeout);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(Func<TimeSpan> timeoutProvider)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return Policy.Timeout<TResult>(onTimeout: (Action<Context, TimeSpan, Task, Exception>)delegate
			{
			}, timeoutProvider: (Func<Context, TimeSpan>)((Context ctx) => timeoutProvider()), timeoutStrategy: TimeoutStrategy.Optimistic);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return Policy.Timeout<TResult>(onTimeout: (Action<Context, TimeSpan, Task, Exception>)delegate
			{
			}, timeoutProvider: (Func<Context, TimeSpan>)((Context ctx) => timeoutProvider()), timeoutStrategy: timeoutStrategy);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(Func<TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task> onTimeout)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return Timeout<TResult>((Context ctx) => timeoutProvider(), TimeoutStrategy.Optimistic, onTimeout);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(Func<TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task, Exception> onTimeout)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return Timeout<TResult>((Context ctx) => timeoutProvider(), TimeoutStrategy.Optimistic, onTimeout);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task> onTimeout)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return Timeout<TResult>((Context ctx) => timeoutProvider(), timeoutStrategy, onTimeout);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(Func<TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			return Timeout<TResult>((Context ctx) => timeoutProvider(), timeoutStrategy, onTimeout);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(Func<Context, TimeSpan> timeoutProvider)
		{
			Action<Context, TimeSpan, Task, Exception> onTimeout = delegate
			{
			};
			return Timeout<TResult>(timeoutProvider, TimeoutStrategy.Optimistic, onTimeout);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy)
		{
			Action<Context, TimeSpan, Task, Exception> onTimeout = delegate
			{
			};
			return Timeout<TResult>(timeoutProvider, timeoutStrategy, onTimeout);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(Func<Context, TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task> onTimeout)
		{
			return Timeout<TResult>(timeoutProvider, TimeoutStrategy.Optimistic, onTimeout);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(Func<Context, TimeSpan> timeoutProvider, Action<Context, TimeSpan, Task, Exception> onTimeout)
		{
			return Timeout<TResult>(timeoutProvider, TimeoutStrategy.Optimistic, onTimeout);
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task> onTimeout)
		{
			if (onTimeout == null)
			{
				throw new ArgumentNullException("onTimeout");
			}
			return Timeout<TResult>(timeoutProvider, timeoutStrategy, delegate(Context ctx, TimeSpan timeout, Task task, Exception ex)
			{
				onTimeout(ctx, timeout, task);
			});
		}

		public static TimeoutPolicy<TResult> Timeout<TResult>(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
		{
			if (timeoutProvider == null)
			{
				throw new ArgumentNullException("timeoutProvider");
			}
			if (onTimeout == null)
			{
				throw new ArgumentNullException("onTimeout");
			}
			return new TimeoutPolicy<TResult>(timeoutProvider, timeoutStrategy, onTimeout);
		}

		public static AsyncPolicyWrap WrapAsync(params IAsyncPolicy[] policies)
		{
			switch (policies.Length)
			{
			case 0:
			case 1:
				throw new ArgumentException("The enumerable of policies to form the wrap must contain at least two policies.", "policies");
			case 2:
				return new AsyncPolicyWrap((AsyncPolicy)policies[0], policies[1]);
			default:
				return WrapAsync(policies[0], WrapAsync(policies.Skip(1).ToArray()));
			}
		}

		public static AsyncPolicyWrap<TResult> WrapAsync<TResult>(params IAsyncPolicy<TResult>[] policies)
		{
			switch (policies.Length)
			{
			case 0:
			case 1:
				throw new ArgumentException("The enumerable of policies to form the wrap must contain at least two policies.", "policies");
			case 2:
				return new AsyncPolicyWrap<TResult>((AsyncPolicy<TResult>)policies[0], policies[1]);
			default:
				return WrapAsync<TResult>(policies[0], WrapAsync(policies.Skip(1).ToArray()));
			}
		}

		public PolicyWrap Wrap(ISyncPolicy innerPolicy)
		{
			if (innerPolicy == null)
			{
				throw new ArgumentNullException("innerPolicy");
			}
			return new PolicyWrap(this, innerPolicy);
		}

		public PolicyWrap<TResult> Wrap<TResult>(ISyncPolicy<TResult> innerPolicy)
		{
			if (innerPolicy == null)
			{
				throw new ArgumentNullException("innerPolicy");
			}
			return new PolicyWrap<TResult>(this, innerPolicy);
		}

		public static PolicyWrap Wrap(params ISyncPolicy[] policies)
		{
			switch (policies.Length)
			{
			case 0:
			case 1:
				throw new ArgumentException("The enumerable of policies to form the wrap must contain at least two policies.", "policies");
			case 2:
				return new PolicyWrap((Policy)policies[0], policies[1]);
			default:
				return Wrap(policies[0], Wrap(policies.Skip(1).ToArray()));
			}
		}

		public static PolicyWrap<TResult> Wrap<TResult>(params ISyncPolicy<TResult>[] policies)
		{
			switch (policies.Length)
			{
			case 0:
			case 1:
				throw new ArgumentException("The enumerable of policies to form the wrap must contain at least two policies.", "policies");
			case 2:
				return new PolicyWrap<TResult>((Policy<TResult>)policies[0], policies[1]);
			default:
				return Wrap<TResult>(policies[0], Wrap(policies.Skip(1).ToArray()));
			}
		}
	}
	public static class AdvancedCircuitBreakerSyntax
	{
		public static CircuitBreakerPolicy AdvancedCircuitBreaker(this PolicyBuilder policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak)
		{
			Action<Exception, TimeSpan> onBreak = delegate
			{
			};
			Action onReset = delegate
			{
			};
			return policyBuilder.AdvancedCircuitBreaker(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, onBreak, onReset);
		}

		public static CircuitBreakerPolicy AdvancedCircuitBreaker(this PolicyBuilder policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak, Action<Exception, TimeSpan> onBreak, Action onReset)
		{
			return policyBuilder.AdvancedCircuitBreaker(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, delegate(Exception exception, TimeSpan timespan, Context context)
			{
				onBreak(exception, timespan);
			}, delegate
			{
				onReset();
			});
		}

		public static CircuitBreakerPolicy AdvancedCircuitBreaker(this PolicyBuilder policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak, Action<Exception, TimeSpan, Context> onBreak, Action<Context> onReset)
		{
			Action onHalfOpen = delegate
			{
			};
			return policyBuilder.AdvancedCircuitBreaker(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, onBreak, onReset, onHalfOpen);
		}

		public static CircuitBreakerPolicy AdvancedCircuitBreaker(this PolicyBuilder policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak, Action<Exception, TimeSpan> onBreak, Action onReset, Action onHalfOpen)
		{
			return policyBuilder.AdvancedCircuitBreaker(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, delegate(Exception exception, TimeSpan timespan, Context context)
			{
				onBreak(exception, timespan);
			}, delegate
			{
				onReset();
			}, onHalfOpen);
		}

		public static CircuitBreakerPolicy AdvancedCircuitBreaker(this PolicyBuilder policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak, Action<Exception, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
		{
			return policyBuilder.AdvancedCircuitBreaker(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, delegate(Exception exception, CircuitState state, TimeSpan timespan, Context context)
			{
				onBreak(exception, timespan, context);
			}, onReset, onHalfOpen);
		}

		public static CircuitBreakerPolicy AdvancedCircuitBreaker(this PolicyBuilder policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak, Action<Exception, CircuitState, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
		{
			TimeSpan timeSpan = TimeSpan.FromTicks(AdvancedCircuitController<EmptyStruct>.ResolutionOfCircuitTimer);
			if (failureThreshold <= 0.0)
			{
				throw new ArgumentOutOfRangeException("failureThreshold", "Value must be greater than zero.");
			}
			if (failureThreshold > 1.0)
			{
				throw new ArgumentOutOfRangeException("failureThreshold", "Value must be less than or equal to one.");
			}
			if (samplingDuration < timeSpan)
			{
				throw new ArgumentOutOfRangeException("samplingDuration", $"Value must be equal to or greater than {timeSpan.TotalMilliseconds} milliseconds. This is the minimum resolution of the CircuitBreaker timer.");
			}
			if (minimumThroughput <= 1)
			{
				throw new ArgumentOutOfRangeException("minimumThroughput", "Value must be greater than one.");
			}
			if (durationOfBreak < TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException("durationOfBreak", "Value must be greater than zero.");
			}
			if (onBreak == null)
			{
				throw new ArgumentNullException("onBreak");
			}
			if (onReset == null)
			{
				throw new ArgumentNullException("onReset");
			}
			if (onHalfOpen == null)
			{
				throw new ArgumentNullException("onHalfOpen");
			}
			AdvancedCircuitController<EmptyStruct> breakerController = new AdvancedCircuitController<EmptyStruct>(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, delegate(DelegateResult<EmptyStruct> outcome, CircuitState state, TimeSpan timespan, Context context)
			{
				onBreak(outcome.Exception, state, timespan, context);
			}, onReset, onHalfOpen);
			return new CircuitBreakerPolicy(policyBuilder, breakerController);
		}
	}
	public static class AdvancedCircuitBreakerTResultSyntax
	{
		public static CircuitBreakerPolicy<TResult> AdvancedCircuitBreaker<TResult>(this PolicyBuilder<TResult> policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak)
		{
			Action<DelegateResult<TResult>, TimeSpan> onBreak = delegate
			{
			};
			Action onReset = delegate
			{
			};
			return policyBuilder.AdvancedCircuitBreaker(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, onBreak, onReset);
		}

		public static CircuitBreakerPolicy<TResult> AdvancedCircuitBreaker<TResult>(this PolicyBuilder<TResult> policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, TimeSpan> onBreak, Action onReset)
		{
			return policyBuilder.AdvancedCircuitBreaker(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, delegate(DelegateResult<TResult> outcome, TimeSpan timespan, Context context)
			{
				onBreak(outcome, timespan);
			}, delegate
			{
				onReset();
			});
		}

		public static CircuitBreakerPolicy<TResult> AdvancedCircuitBreaker<TResult>(this PolicyBuilder<TResult> policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, TimeSpan, Context> onBreak, Action<Context> onReset)
		{
			Action onHalfOpen = delegate
			{
			};
			return policyBuilder.AdvancedCircuitBreaker(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, onBreak, onReset, onHalfOpen);
		}

		public static CircuitBreakerPolicy<TResult> AdvancedCircuitBreaker<TResult>(this PolicyBuilder<TResult> policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, TimeSpan> onBreak, Action onReset, Action onHalfOpen)
		{
			return policyBuilder.AdvancedCircuitBreaker(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, delegate(DelegateResult<TResult> outcome, TimeSpan timespan, Context context)
			{
				onBreak(outcome, timespan);
			}, delegate
			{
				onReset();
			}, onHalfOpen);
		}

		public static CircuitBreakerPolicy<TResult> AdvancedCircuitBreaker<TResult>(this PolicyBuilder<TResult> policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
		{
			return policyBuilder.AdvancedCircuitBreaker(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, delegate(DelegateResult<TResult> outcome, CircuitState state, TimeSpan timespan, Context context)
			{
				onBreak(outcome, timespan, context);
			}, onReset, onHalfOpen);
		}

		public static CircuitBreakerPolicy<TResult> AdvancedCircuitBreaker<TResult>(this PolicyBuilder<TResult> policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, CircuitState, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
		{
			TimeSpan timeSpan = TimeSpan.FromTicks(AdvancedCircuitController<EmptyStruct>.ResolutionOfCircuitTimer);
			if (failureThreshold <= 0.0)
			{
				throw new ArgumentOutOfRangeException("failureThreshold", "Value must be greater than zero.");
			}
			if (failureThreshold > 1.0)
			{
				throw new ArgumentOutOfRangeException("failureThreshold", "Value must be less than or equal to one.");
			}
			if (samplingDuration < timeSpan)
			{
				throw new ArgumentOutOfRangeException("samplingDuration", $"Value must be equal to or greater than {timeSpan.TotalMilliseconds} milliseconds. This is the minimum resolution of the CircuitBreaker timer.");
			}
			if (minimumThroughput <= 1)
			{
				throw new ArgumentOutOfRangeException("minimumThroughput", "Value must be greater than one.");
			}
			if (durationOfBreak < TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException("durationOfBreak", "Value must be greater than zero.");
			}
			if (onBreak == null)
			{
				throw new ArgumentNullException("onBreak");
			}
			if (onReset == null)
			{
				throw new ArgumentNullException("onReset");
			}
			if (onHalfOpen == null)
			{
				throw new ArgumentNullException("onHalfOpen");
			}
			AdvancedCircuitController<TResult> breakerController = new AdvancedCircuitController<TResult>(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, onBreak, onReset, onHalfOpen);
			return new CircuitBreakerPolicy<TResult>(policyBuilder, breakerController);
		}
	}
	public static class AsyncAdvancedCircuitBreakerSyntax
	{
		public static AsyncCircuitBreakerPolicy AdvancedCircuitBreakerAsync(this PolicyBuilder policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak)
		{
			Action<Exception, TimeSpan> onBreak = delegate
			{
			};
			Action onReset = delegate
			{
			};
			return policyBuilder.AdvancedCircuitBreakerAsync(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, onBreak, onReset);
		}

		public static AsyncCircuitBreakerPolicy AdvancedCircuitBreakerAsync(this PolicyBuilder policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak, Action<Exception, TimeSpan> onBreak, Action onReset)
		{
			return policyBuilder.AdvancedCircuitBreakerAsync(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, delegate(Exception exception, TimeSpan timespan, Context context)
			{
				onBreak(exception, timespan);
			}, delegate
			{
				onReset();
			});
		}

		public static AsyncCircuitBreakerPolicy AdvancedCircuitBreakerAsync(this PolicyBuilder policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak, Action<Exception, TimeSpan, Context> onBreak, Action<Context> onReset)
		{
			Action onHalfOpen = delegate
			{
			};
			return policyBuilder.AdvancedCircuitBreakerAsync(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, onBreak, onReset, onHalfOpen);
		}

		public static AsyncCircuitBreakerPolicy AdvancedCircuitBreakerAsync(this PolicyBuilder policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak, Action<Exception, TimeSpan> onBreak, Action onReset, Action onHalfOpen)
		{
			return policyBuilder.AdvancedCircuitBreakerAsync(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, delegate(Exception exception, TimeSpan timespan, Context context)
			{
				onBreak(exception, timespan);
			}, delegate
			{
				onReset();
			}, onHalfOpen);
		}

		public static AsyncCircuitBreakerPolicy AdvancedCircuitBreakerAsync(this PolicyBuilder policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak, Action<Exception, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
		{
			return policyBuilder.AdvancedCircuitBreakerAsync(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, delegate(Exception exception, CircuitState state, TimeSpan timespan, Context context)
			{
				onBreak(exception, timespan, context);
			}, onReset, onHalfOpen);
		}

		public static AsyncCircuitBreakerPolicy AdvancedCircuitBreakerAsync(this PolicyBuilder policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak, Action<Exception, CircuitState, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
		{
			TimeSpan timeSpan = TimeSpan.FromTicks(AdvancedCircuitController<EmptyStruct>.ResolutionOfCircuitTimer);
			if (failureThreshold <= 0.0)
			{
				throw new ArgumentOutOfRangeException("failureThreshold", "Value must be greater than zero.");
			}
			if (failureThreshold > 1.0)
			{
				throw new ArgumentOutOfRangeException("failureThreshold", "Value must be less than or equal to one.");
			}
			if (samplingDuration < timeSpan)
			{
				throw new ArgumentOutOfRangeException("samplingDuration", $"Value must be equal to or greater than {timeSpan.TotalMilliseconds} milliseconds. This is the minimum resolution of the CircuitBreaker timer.");
			}
			if (minimumThroughput <= 1)
			{
				throw new ArgumentOutOfRangeException("minimumThroughput", "Value must be greater than one.");
			}
			if (durationOfBreak < TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException("durationOfBreak", "Value must be greater than zero.");
			}
			if (onBreak == null)
			{
				throw new ArgumentNullException("onBreak");
			}
			if (onReset == null)
			{
				throw new ArgumentNullException("onReset");
			}
			if (onHalfOpen == null)
			{
				throw new ArgumentNullException("onHalfOpen");
			}
			AdvancedCircuitController<EmptyStruct> breakerController = new AdvancedCircuitController<EmptyStruct>(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, delegate(DelegateResult<EmptyStruct> outcome, CircuitState state, TimeSpan timespan, Context context)
			{
				onBreak(outcome.Exception, state, timespan, context);
			}, onReset, onHalfOpen);
			return new AsyncCircuitBreakerPolicy(policyBuilder, breakerController);
		}
	}
	public static class AsyncAdvancedCircuitBreakerTResultSyntax
	{
		public static AsyncCircuitBreakerPolicy<TResult> AdvancedCircuitBreakerAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak)
		{
			Action<DelegateResult<TResult>, TimeSpan> onBreak = delegate
			{
			};
			Action onReset = delegate
			{
			};
			return policyBuilder.AdvancedCircuitBreakerAsync(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, onBreak, onReset);
		}

		public static AsyncCircuitBreakerPolicy<TResult> AdvancedCircuitBreakerAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, TimeSpan> onBreak, Action onReset)
		{
			return policyBuilder.AdvancedCircuitBreakerAsync(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, delegate(DelegateResult<TResult> outcome, TimeSpan timespan, Context context)
			{
				onBreak(outcome, timespan);
			}, delegate
			{
				onReset();
			});
		}

		public static AsyncCircuitBreakerPolicy<TResult> AdvancedCircuitBreakerAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, TimeSpan, Context> onBreak, Action<Context> onReset)
		{
			Action onHalfOpen = delegate
			{
			};
			return policyBuilder.AdvancedCircuitBreakerAsync(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, onBreak, onReset, onHalfOpen);
		}

		public static AsyncCircuitBreakerPolicy<TResult> AdvancedCircuitBreakerAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, TimeSpan> onBreak, Action onReset, Action onHalfOpen)
		{
			return policyBuilder.AdvancedCircuitBreakerAsync(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, delegate(DelegateResult<TResult> outcome, TimeSpan timespan, Context context)
			{
				onBreak(outcome, timespan);
			}, delegate
			{
				onReset();
			}, onHalfOpen);
		}

		public static AsyncCircuitBreakerPolicy<TResult> AdvancedCircuitBreakerAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
		{
			return policyBuilder.AdvancedCircuitBreakerAsync(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, delegate(DelegateResult<TResult> outcome, CircuitState state, TimeSpan timespan, Context context)
			{
				onBreak(outcome, timespan, context);
			}, onReset, onHalfOpen);
		}

		public static AsyncCircuitBreakerPolicy<TResult> AdvancedCircuitBreakerAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, CircuitState, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
		{
			TimeSpan timeSpan = TimeSpan.FromTicks(AdvancedCircuitController<EmptyStruct>.ResolutionOfCircuitTimer);
			if (failureThreshold <= 0.0)
			{
				throw new ArgumentOutOfRangeException("failureThreshold", "Value must be greater than zero.");
			}
			if (failureThreshold > 1.0)
			{
				throw new ArgumentOutOfRangeException("failureThreshold", "Value must be less than or equal to one.");
			}
			if (samplingDuration < timeSpan)
			{
				throw new ArgumentOutOfRangeException("samplingDuration", $"Value must be equal to or greater than {timeSpan.TotalMilliseconds} milliseconds. This is the minimum resolution of the CircuitBreaker timer.");
			}
			if (minimumThroughput <= 1)
			{
				throw new ArgumentOutOfRangeException("minimumThroughput", "Value must be greater than one.");
			}
			if (durationOfBreak < TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException("durationOfBreak", "Value must be greater than zero.");
			}
			if (onBreak == null)
			{
				throw new ArgumentNullException("onBreak");
			}
			if (onReset == null)
			{
				throw new ArgumentNullException("onReset");
			}
			if (onHalfOpen == null)
			{
				throw new ArgumentNullException("onHalfOpen");
			}
			AdvancedCircuitController<TResult> breakerController = new AdvancedCircuitController<TResult>(failureThreshold, samplingDuration, minimumThroughput, durationOfBreak, onBreak, onReset, onHalfOpen);
			return new AsyncCircuitBreakerPolicy<TResult>(policyBuilder, breakerController);
		}
	}
	public static class AsyncCircuitBreakerSyntax
	{
		public static AsyncCircuitBreakerPolicy CircuitBreakerAsync(this PolicyBuilder policyBuilder, int exceptionsAllowedBeforeBreaking, TimeSpan durationOfBreak)
		{
			Action<Exception, TimeSpan> onBreak = delegate
			{
			};
			Action onReset = delegate
			{
			};
			return policyBuilder.CircuitBreakerAsync(exceptionsAllowedBeforeBreaking, durationOfBreak, onBreak, onReset);
		}

		public static AsyncCircuitBreakerPolicy CircuitBreakerAsync(this PolicyBuilder policyBuilder, int exceptionsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<Exception, TimeSpan> onBreak, Action onReset)
		{
			return policyBuilder.CircuitBreakerAsync(exceptionsAllowedBeforeBreaking, durationOfBreak, delegate(Exception exception, TimeSpan timespan, Context context)
			{
				onBreak(exception, timespan);
			}, delegate
			{
				onReset();
			});
		}

		public static AsyncCircuitBreakerPolicy CircuitBreakerAsync(this PolicyBuilder policyBuilder, int exceptionsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<Exception, TimeSpan, Context> onBreak, Action<Context> onReset)
		{
			Action onHalfOpen = delegate
			{
			};
			return policyBuilder.CircuitBreakerAsync(exceptionsAllowedBeforeBreaking, durationOfBreak, onBreak, onReset, onHalfOpen);
		}

		public static AsyncCircuitBreakerPolicy CircuitBreakerAsync(this PolicyBuilder policyBuilder, int exceptionsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<Exception, TimeSpan> onBreak, Action onReset, Action onHalfOpen)
		{
			return policyBuilder.CircuitBreakerAsync(exceptionsAllowedBeforeBreaking, durationOfBreak, delegate(Exception exception, TimeSpan timespan, Context context)
			{
				onBreak(exception, timespan);
			}, delegate
			{
				onReset();
			}, onHalfOpen);
		}

		public static AsyncCircuitBreakerPolicy CircuitBreakerAsync(this PolicyBuilder policyBuilder, int exceptionsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<Exception, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
		{
			return policyBuilder.CircuitBreakerAsync(exceptionsAllowedBeforeBreaking, durationOfBreak, delegate(Exception exception, CircuitState state, TimeSpan timespan, Context context)
			{
				onBreak(exception, timespan, context);
			}, onReset, onHalfOpen);
		}

		public static AsyncCircuitBreakerPolicy CircuitBreakerAsync(this PolicyBuilder policyBuilder, int exceptionsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<Exception, CircuitState, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
		{
			if (exceptionsAllowedBeforeBreaking <= 0)
			{
				throw new ArgumentOutOfRangeException("exceptionsAllowedBeforeBreaking", "Value must be greater than zero.");
			}
			if (durationOfBreak < TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException("durationOfBreak", "Value must be greater than zero.");
			}
			if (onBreak == null)
			{
				throw new ArgumentNullException("onBreak");
			}
			if (onReset == null)
			{
				throw new ArgumentNullException("onReset");
			}
			if (onHalfOpen == null)
			{
				throw new ArgumentNullException("onHalfOpen");
			}
			ConsecutiveCountCircuitController<EmptyStruct> breakerController = new ConsecutiveCountCircuitController<EmptyStruct>(exceptionsAllowedBeforeBreaking, durationOfBreak, delegate(DelegateResult<EmptyStruct> outcome, CircuitState state, TimeSpan timespan, Context context)
			{
				onBreak(outcome.Exception, state, timespan, context);
			}, onReset, onHalfOpen);
			return new AsyncCircuitBreakerPolicy(policyBuilder, breakerController);
		}
	}
	public static class AsyncCircuitBreakerTResultSyntax
	{
		public static AsyncCircuitBreakerPolicy<TResult> CircuitBreakerAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int handledEventsAllowedBeforeBreaking, TimeSpan durationOfBreak)
		{
			Action<DelegateResult<TResult>, TimeSpan> onBreak = delegate
			{
			};
			Action onReset = delegate
			{
			};
			return policyBuilder.CircuitBreakerAsync(handledEventsAllowedBeforeBreaking, durationOfBreak, onBreak, onReset);
		}

		public static AsyncCircuitBreakerPolicy<TResult> CircuitBreakerAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int handledEventsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, TimeSpan> onBreak, Action onReset)
		{
			return policyBuilder.CircuitBreakerAsync(handledEventsAllowedBeforeBreaking, durationOfBreak, delegate(DelegateResult<TResult> outcome, TimeSpan timespan, Context context)
			{
				onBreak(outcome, timespan);
			}, delegate
			{
				onReset();
			});
		}

		public static AsyncCircuitBreakerPolicy<TResult> CircuitBreakerAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int handledEventsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, TimeSpan, Context> onBreak, Action<Context> onReset)
		{
			Action onHalfOpen = delegate
			{
			};
			return policyBuilder.CircuitBreakerAsync(handledEventsAllowedBeforeBreaking, durationOfBreak, onBreak, onReset, onHalfOpen);
		}

		public static AsyncCircuitBreakerPolicy<TResult> CircuitBreakerAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int handledEventsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, TimeSpan> onBreak, Action onReset, Action onHalfOpen)
		{
			return policyBuilder.CircuitBreakerAsync(handledEventsAllowedBeforeBreaking, durationOfBreak, delegate(DelegateResult<TResult> outcome, TimeSpan timespan, Context context)
			{
				onBreak(outcome, timespan);
			}, delegate
			{
				onReset();
			}, onHalfOpen);
		}

		public static AsyncCircuitBreakerPolicy<TResult> CircuitBreakerAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int handledEventsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
		{
			return policyBuilder.CircuitBreakerAsync(handledEventsAllowedBeforeBreaking, durationOfBreak, delegate(DelegateResult<TResult> outcome, CircuitState state, TimeSpan timespan, Context context)
			{
				onBreak(outcome, timespan, context);
			}, onReset, onHalfOpen);
		}

		public static AsyncCircuitBreakerPolicy<TResult> CircuitBreakerAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int handledEventsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, CircuitState, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
		{
			if (handledEventsAllowedBeforeBreaking <= 0)
			{
				throw new ArgumentOutOfRangeException("handledEventsAllowedBeforeBreaking", "Value must be greater than zero.");
			}
			if (durationOfBreak < TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException("durationOfBreak", "Value must be greater than zero.");
			}
			if (onBreak == null)
			{
				throw new ArgumentNullException("onBreak");
			}
			if (onReset == null)
			{
				throw new ArgumentNullException("onReset");
			}
			if (onHalfOpen == null)
			{
				throw new ArgumentNullException("onHalfOpen");
			}
			ConsecutiveCountCircuitController<TResult> breakerController = new ConsecutiveCountCircuitController<TResult>(handledEventsAllowedBeforeBreaking, durationOfBreak, onBreak, onReset, onHalfOpen);
			return new AsyncCircuitBreakerPolicy<TResult>(policyBuilder, breakerController);
		}
	}
	public static class CircuitBreakerSyntax
	{
		public static CircuitBreakerPolicy CircuitBreaker(this PolicyBuilder policyBuilder, int exceptionsAllowedBeforeBreaking, TimeSpan durationOfBreak)
		{
			Action<Exception, TimeSpan> onBreak = delegate
			{
			};
			Action onReset = delegate
			{
			};
			return policyBuilder.CircuitBreaker(exceptionsAllowedBeforeBreaking, durationOfBreak, onBreak, onReset);
		}

		public static CircuitBreakerPolicy CircuitBreaker(this PolicyBuilder policyBuilder, int exceptionsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<Exception, TimeSpan> onBreak, Action onReset)
		{
			return policyBuilder.CircuitBreaker(exceptionsAllowedBeforeBreaking, durationOfBreak, delegate(Exception exception, TimeSpan timespan, Context context)
			{
				onBreak(exception, timespan);
			}, delegate
			{
				onReset();
			});
		}

		public static CircuitBreakerPolicy CircuitBreaker(this PolicyBuilder policyBuilder, int exceptionsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<Exception, TimeSpan, Context> onBreak, Action<Context> onReset)
		{
			Action onHalfOpen = delegate
			{
			};
			return policyBuilder.CircuitBreaker(exceptionsAllowedBeforeBreaking, durationOfBreak, onBreak, onReset, onHalfOpen);
		}

		public static CircuitBreakerPolicy CircuitBreaker(this PolicyBuilder policyBuilder, int exceptionsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<Exception, TimeSpan> onBreak, Action onReset, Action onHalfOpen)
		{
			return policyBuilder.CircuitBreaker(exceptionsAllowedBeforeBreaking, durationOfBreak, delegate(Exception exception, TimeSpan timespan, Context context)
			{
				onBreak(exception, timespan);
			}, delegate
			{
				onReset();
			}, onHalfOpen);
		}

		public static CircuitBreakerPolicy CircuitBreaker(this PolicyBuilder policyBuilder, int exceptionsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<Exception, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
		{
			return policyBuilder.CircuitBreaker(exceptionsAllowedBeforeBreaking, durationOfBreak, delegate(Exception exception, CircuitState state, TimeSpan timespan, Context context)
			{
				onBreak(exception, timespan, context);
			}, onReset, onHalfOpen);
		}

		public static CircuitBreakerPolicy CircuitBreaker(this PolicyBuilder policyBuilder, int exceptionsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<Exception, CircuitState, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
		{
			if (exceptionsAllowedBeforeBreaking <= 0)
			{
				throw new ArgumentOutOfRangeException("exceptionsAllowedBeforeBreaking", "Value must be greater than zero.");
			}
			if (durationOfBreak < TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException("durationOfBreak", "Value must be greater than zero.");
			}
			if (onBreak == null)
			{
				throw new ArgumentNullException("onBreak");
			}
			if (onReset == null)
			{
				throw new ArgumentNullException("onReset");
			}
			if (onHalfOpen == null)
			{
				throw new ArgumentNullException("onHalfOpen");
			}
			ConsecutiveCountCircuitController<EmptyStruct> breakerController = new ConsecutiveCountCircuitController<EmptyStruct>(exceptionsAllowedBeforeBreaking, durationOfBreak, delegate(DelegateResult<EmptyStruct> outcome, CircuitState state, TimeSpan timespan, Context context)
			{
				onBreak(outcome.Exception, state, timespan, context);
			}, onReset, onHalfOpen);
			return new CircuitBreakerPolicy(policyBuilder, breakerController);
		}
	}
	public static class CircuitBreakerTResultSyntax
	{
		public static CircuitBreakerPolicy<TResult> CircuitBreaker<TResult>(this PolicyBuilder<TResult> policyBuilder, int handledEventsAllowedBeforeBreaking, TimeSpan durationOfBreak)
		{
			Action<DelegateResult<TResult>, TimeSpan> onBreak = delegate
			{
			};
			Action onReset = delegate
			{
			};
			return policyBuilder.CircuitBreaker(handledEventsAllowedBeforeBreaking, durationOfBreak, onBreak, onReset);
		}

		public static CircuitBreakerPolicy<TResult> CircuitBreaker<TResult>(this PolicyBuilder<TResult> policyBuilder, int handledEventsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, TimeSpan> onBreak, Action onReset)
		{
			return policyBuilder.CircuitBreaker(handledEventsAllowedBeforeBreaking, durationOfBreak, delegate(DelegateResult<TResult> outcome, TimeSpan timespan, Context context)
			{
				onBreak(outcome, timespan);
			}, delegate
			{
				onReset();
			});
		}

		public static CircuitBreakerPolicy<TResult> CircuitBreaker<TResult>(this PolicyBuilder<TResult> policyBuilder, int handledEventsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, TimeSpan, Context> onBreak, Action<Context> onReset)
		{
			Action onHalfOpen = delegate
			{
			};
			return policyBuilder.CircuitBreaker(handledEventsAllowedBeforeBreaking, durationOfBreak, onBreak, onReset, onHalfOpen);
		}

		public static CircuitBreakerPolicy<TResult> CircuitBreaker<TResult>(this PolicyBuilder<TResult> policyBuilder, int handledEventsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, TimeSpan> onBreak, Action onReset, Action onHalfOpen)
		{
			return policyBuilder.CircuitBreaker(handledEventsAllowedBeforeBreaking, durationOfBreak, delegate(DelegateResult<TResult> outcome, TimeSpan timespan, Context context)
			{
				onBreak(outcome, timespan);
			}, delegate
			{
				onReset();
			}, onHalfOpen);
		}

		public static CircuitBreakerPolicy<TResult> CircuitBreaker<TResult>(this PolicyBuilder<TResult> policyBuilder, int handledEventsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
		{
			return policyBuilder.CircuitBreaker(handledEventsAllowedBeforeBreaking, durationOfBreak, delegate(DelegateResult<TResult> outcome, CircuitState state, TimeSpan timespan, Context context)
			{
				onBreak(outcome, timespan, context);
			}, onReset, onHalfOpen);
		}

		public static CircuitBreakerPolicy<TResult> CircuitBreaker<TResult>(this PolicyBuilder<TResult> policyBuilder, int handledEventsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, CircuitState, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
		{
			if (handledEventsAllowedBeforeBreaking <= 0)
			{
				throw new ArgumentOutOfRangeException("handledEventsAllowedBeforeBreaking", "Value must be greater than zero.");
			}
			if (durationOfBreak < TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException("durationOfBreak", "Value must be greater than zero.");
			}
			if (onBreak == null)
			{
				throw new ArgumentNullException("onBreak");
			}
			if (onReset == null)
			{
				throw new ArgumentNullException("onReset");
			}
			if (onHalfOpen == null)
			{
				throw new ArgumentNullException("onHalfOpen");
			}
			ICircuitController<TResult> breakerController = new ConsecutiveCountCircuitController<TResult>(handledEventsAllowedBeforeBreaking, durationOfBreak, onBreak, onReset, onHalfOpen);
			return new CircuitBreakerPolicy<TResult>(policyBuilder, breakerController);
		}
	}
	public class Context : IDictionary<string, object>, ICollection<KeyValuePair<string, object>>, IEnumerable<KeyValuePair<string, object>>, IEnumerable, IDictionary, ICollection, IReadOnlyDictionary<string, object>, IReadOnlyCollection<KeyValuePair<string, object>>
	{
		private Guid? _correlationId;

		private Dictionary<string, object> wrappedDictionary;

		public string PolicyWrapKey { get; internal set; }

		public string PolicyKey { get; internal set; }

		public string OperationKey { get; }

		public Guid CorrelationId
		{
			get
			{
				if (!_correlationId.HasValue)
				{
					_correlationId = Guid.NewGuid();
				}
				return _correlationId.Value;
			}
		}

		private Dictionary<string, object> WrappedDictionary => wrappedDictionary ?? (wrappedDictionary = new Dictionary<string, object>());

		public ICollection<string> Keys => WrappedDictionary.Keys;

		public ICollection<object> Values => WrappedDictionary.Values;

		public int Count => WrappedDictionary.Count;

		bool ICollection<KeyValuePair<string, object>>.IsReadOnly => ((ICollection<KeyValuePair<string, object>>)WrappedDictionary).IsReadOnly;

		public object this[string key]
		{
			get
			{
				return WrappedDictionary[key];
			}
			set
			{
				WrappedDictionary[key] = value;
			}
		}

		IEnumerable<string> IReadOnlyDictionary<string, object>.Keys => ((IReadOnlyDictionary<string, object>)WrappedDictionary).Keys;

		IEnumerable<object> IReadOnlyDictionary<string, object>.Values => ((IReadOnlyDictionary<string, object>)WrappedDictionary).Values;

		bool IDictionary.IsFixedSize => ((IDictionary)WrappedDictionary).IsFixedSize;

		bool IDictionary.IsReadOnly => ((IDictionary)WrappedDictionary).IsReadOnly;

		ICollection IDictionary.Keys => ((IDictionary)WrappedDictionary).Keys;

		ICollection IDictionary.Values => ((IDictionary)WrappedDictionary).Values;

		bool ICollection.IsSynchronized => ((ICollection)WrappedDictionary).IsSynchronized;

		object ICollection.SyncRoot => ((ICollection)WrappedDictionary).SyncRoot;

		object IDictionary.this[object key]
		{
			get
			{
				return ((IDictionary)WrappedDictionary)[key];
			}
			set
			{
				((IDictionary)WrappedDictionary)[key] = value;
			}
		}

		internal static Context None()
		{
			return new Context();
		}

		public Context(string operationKey)
		{
			OperationKey = operationKey;
		}

		public Context()
		{
		}

		public Context(string operationKey, IDictionary<string, object> contextData)
			: this(contextData)
		{
			OperationKey = operationKey;
		}

		internal Context(IDictionary<string, object> contextData)
			: this()
		{
			if (contextData == null)
			{
				throw new ArgumentNullException("contextData");
			}
			wrappedDictionary = new Dictionary<string, object>(contextData);
		}

		public void Add(string key, object value)
		{
			WrappedDictionary.Add(key, value);
		}

		public bool ContainsKey(string key)
		{
			return WrappedDictionary.ContainsKey(key);
		}

		public bool Remove(string key)
		{
			return WrappedDictionary.Remove(key);
		}

		public bool TryGetValue(string key, out object value)
		{
			return WrappedDictionary.TryGetValue(key, out value);
		}

		void ICollection<KeyValuePair<string, object>>.Add(KeyValuePair<string, object> item)
		{
			((ICollection<KeyValuePair<string, object>>)WrappedDictionary).Add(item);
		}

		public void Clear()
		{
			WrappedDictionary.Clear();
		}

		bool ICollection<KeyValuePair<string, object>>.Contains(KeyValuePair<string, object> item)
		{
			return ((ICollection<KeyValuePair<string, object>>)WrappedDictionary).Contains(item);
		}

		void ICollection<KeyValuePair<string, object>>.CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
		{
			((ICollection<KeyValuePair<string, object>>)WrappedDictionary).CopyTo(array, arrayIndex);
		}

		bool ICollection<KeyValuePair<string, object>>.Remove(KeyValuePair<string, object> item)
		{
			return ((ICollection<KeyValuePair<string, object>>)WrappedDictionary).Remove(item);
		}

		public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
		{
			return WrappedDictionary.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return WrappedDictionary.GetEnumerator();
		}

		public void Add(object key, object value)
		{
			((IDictionary)WrappedDictionary).Add(key, value);
		}

		public bool Contains(object key)
		{
			return ((IDictionary)WrappedDictionary).Contains(key);
		}

		IDictionaryEnumerator IDictionary.GetEnumerator()
		{
			return ((IDictionary)WrappedDictionary).GetEnumerator();
		}

		public void Remove(object key)
		{
			((IDictionary)WrappedDictionary).Remove(key);
		}

		public void CopyTo(Array array, int index)
		{
			((ICollection)WrappedDictionary).CopyTo(array, index);
		}
	}
	public class DelegateResult<TResult>
	{
		public TResult Result { get; }

		public Exception Exception { get; }

		public DelegateResult(TResult result)
		{
			Result = result;
		}

		public DelegateResult(Exception exception)
		{
			Exception = exception;
		}
	}
	public delegate Exception ExceptionPredicate(Exception ex);
	public class ExceptionPredicates
	{
		private List<ExceptionPredicate> _predicates;

		public static readonly ExceptionPredicates None = new ExceptionPredicates();

		internal void Add(ExceptionPredicate predicate)
		{
			_predicates = _predicates ?? new List<ExceptionPredicate>();
			_predicates.Add(predicate);
		}

		public Exception FirstMatchOrDefault(Exception ex)
		{
			return _predicates?.Select((ExceptionPredicate predicate) => predicate(ex)).FirstOrDefault((Exception e) => e != null);
		}
	}
	public abstract class ExecutionRejectedException : Exception
	{
		protected ExecutionRejectedException()
		{
		}

		protected ExecutionRejectedException(string message)
			: base(message)
		{
		}

		protected ExecutionRejectedException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected ExecutionRejectedException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
	public static class AsyncFallbackSyntax
	{
		public static AsyncFallbackPolicy FallbackAsync(this PolicyBuilder policyBuilder, Func<CancellationToken, Task> fallbackAction)
		{
			if (fallbackAction == null)
			{
				throw new ArgumentNullException("fallbackAction");
			}
			Func<Exception, Task> onFallbackAsync = (Exception _) => TaskHelper.EmptyTask;
			return policyBuilder.FallbackAsync(fallbackAction, onFallbackAsync);
		}

		public static AsyncFallbackPolicy FallbackAsync(this PolicyBuilder policyBuilder, Func<CancellationToken, Task> fallbackAction, Func<Exception, Task> onFallbackAsync)
		{
			if (fallbackAction == null)
			{
				throw new ArgumentNullException("fallbackAction");
			}
			if (onFallbackAsync == null)
			{
				throw new ArgumentNullException("onFallbackAsync");
			}
			return policyBuilder.FallbackAsync((Exception outcome, Context ctx, CancellationToken ct) => fallbackAction(ct), (Exception outcome, Context context) => onFallbackAsync(outcome));
		}

		public static AsyncFallbackPolicy FallbackAsync(this PolicyBuilder policyBuilder, Func<Context, CancellationToken, Task> fallbackAction, Func<Exception, Context, Task> onFallbackAsync)
		{
			if (fallbackAction == null)
			{
				throw new ArgumentNullException("fallbackAction");
			}
			if (onFallbackAsync == null)
			{
				throw new ArgumentNullException("onFallbackAsync");
			}
			return policyBuilder.FallbackAsync((Exception outcome, Context ctx, CancellationToken ct) => fallbackAction(ctx, ct), onFallbackAsync);
		}

		public static AsyncFallbackPolicy FallbackAsync(this PolicyBuilder policyBuilder, Func<Exception, Context, CancellationToken, Task> fallbackAction, Func<Exception, Context, Task> onFallbackAsync)
		{
			if (fallbackAction == null)
			{
				throw new ArgumentNullException("fallbackAction");
			}
			if (onFallbackAsync == null)
			{
				throw new ArgumentNullException("onFallbackAsync");
			}
			return new AsyncFallbackPolicy(policyBuilder, onFallbackAsync, fallbackAction);
		}
	}
	public static class AsyncFallbackTResultSyntax
	{
		public static AsyncFallbackPolicy<TResult> FallbackAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, TResult fallbackValue)
		{
			Func<DelegateResult<TResult>, Task> onFallbackAsync = (DelegateResult<TResult> _) => TaskHelper.EmptyTask;
			return policyBuilder.FallbackAsync((CancellationToken ct) => Task.FromResult(fallbackValue), onFallbackAsync);
		}

		public static AsyncFallbackPolicy<TResult> FallbackAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<CancellationToken, Task<TResult>> fallbackAction)
		{
			if (fallbackAction == null)
			{
				throw new ArgumentNullException("fallbackAction");
			}
			Func<DelegateResult<TResult>, Task> onFallbackAsync = (DelegateResult<TResult> _) => TaskHelper.EmptyTask;
			return policyBuilder.FallbackAsync(fallbackAction, onFallbackAsync);
		}

		public static AsyncFallbackPolicy<TResult> FallbackAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, TResult fallbackValue, Func<DelegateResult<TResult>, Task> onFallbackAsync)
		{
			if (onFallbackAsync == null)
			{
				throw new ArgumentNullException("onFallbackAsync");
			}
			return policyBuilder.FallbackAsync((DelegateResult<TResult> outcome, Context ctx, CancellationToken ct) => Task.FromResult(fallbackValue), (DelegateResult<TResult> outcome, Context context) => onFallbackAsync(outcome));
		}

		public static AsyncFallbackPolicy<TResult> FallbackAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<CancellationToken, Task<TResult>> fallbackAction, Func<DelegateResult<TResult>, Task> onFallbackAsync)
		{
			if (fallbackAction == null)
			{
				throw new ArgumentNullException("fallbackAction");
			}
			if (onFallbackAsync == null)
			{
				throw new ArgumentNullException("onFallbackAsync");
			}
			return policyBuilder.FallbackAsync((DelegateResult<TResult> outcome, Context ctx, CancellationToken ct) => fallbackAction(ct), (DelegateResult<TResult> outcome, Context context) => onFallbackAsync(outcome));
		}

		public static AsyncFallbackPolicy<TResult> FallbackAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, TResult fallbackValue, Func<DelegateResult<TResult>, Context, Task> onFallbackAsync)
		{
			if (onFallbackAsync == null)
			{
				throw new ArgumentNullException("onFallbackAsync");
			}
			return policyBuilder.FallbackAsync((DelegateResult<TResult> outcome, Context ctx, CancellationToken ct) => Task.FromResult(fallbackValue), onFallbackAsync);
		}

		public static AsyncFallbackPolicy<TResult> FallbackAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<Context, CancellationToken, Task<TResult>> fallbackAction, Func<DelegateResult<TResult>, Context, Task> onFallbackAsync)
		{
			if (fallbackAction == null)
			{
				throw new ArgumentNullException("fallbackAction");
			}
			if (onFallbackAsync == null)
			{
				throw new ArgumentNullException("onFallbackAsync");
			}
			return policyBuilder.FallbackAsync((DelegateResult<TResult> outcome, Context ctx, CancellationToken ct) => fallbackAction(ctx, ct), onFallbackAsync);
		}

		public static AsyncFallbackPolicy<TResult> FallbackAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<DelegateResult<TResult>, Context, CancellationToken, Task<TResult>> fallbackAction, Func<DelegateResult<TResult>, Context, Task> onFallbackAsync)
		{
			if (fallbackAction == null)
			{
				throw new ArgumentNullException("fallbackAction");
			}
			if (onFallbackAsync == null)
			{
				throw new ArgumentNullException("onFallbackAsync");
			}
			return new AsyncFallbackPolicy<TResult>(policyBuilder, onFallbackAsync, fallbackAction);
		}
	}
	public static class FallbackSyntax
	{
		public static FallbackPolicy Fallback(this PolicyBuilder policyBuilder, Action fallbackAction)
		{
			if (fallbackAction == null)
			{
				throw new ArgumentNullException("fallbackAction");
			}
			Action<Exception> onFallback = delegate
			{
			};
			return policyBuilder.Fallback(fallbackAction, onFallback);
		}

		public static FallbackPolicy Fallback(this PolicyBuilder policyBuilder, Action<CancellationToken> fallbackAction)
		{
			if (fallbackAction == null)
			{
				throw new ArgumentNullException("fallbackAction");
			}
			Action<Exception> onFallback = delegate
			{
			};
			return policyBuilder.Fallback(fallbackAction, onFallback);
		}

		public static FallbackPolicy Fallback(this PolicyBuilder policyBuilder, Action fallbackAction, Action<Exception> onFallback)
		{
			if (fallbackAction == null)
			{
				throw new ArgumentNullException("fallbackAction");
			}
			if (onFallback == null)
			{
				throw new ArgumentNullException("onFallback");
			}
			return policyBuilder.Fallback((Action<Exception, Context, CancellationToken>)delegate
			{
				fallbackAction();
			}, (Action<Exception, Context>)delegate(Exception exception, Context ctx)
			{
				onFallback(exception);
			});
		}

		public static FallbackPolicy Fallback(this PolicyBuilder policyBuilder, Action<CancellationToken> fallbackAction, Action<Exception> onFallback)
		{
			if (fallbackAction == null)
			{
				throw new ArgumentNullException("fallbackAction");
			}
			if (onFallback == null)
			{
				throw new ArgumentNullException("onFallback");
			}
			return policyBuilder.Fallback(delegate(Exception outcome, Context ctx, CancellationToken ct)
			{
				fallbackAction(ct);
			}, delegate(Exception exception, Context ctx)
			{
				onFallback(exception);
			});
		}

		public static FallbackPolicy Fallback(this PolicyBuilder policyBuilder, Action<Context> fallbackAction, Action<Exception, Context> onFallback)
		{
			if (fallbackAction == null)
			{
				throw new ArgumentNullException("fallbackAction");
			}
			if (onFallback == null)
			{
				throw new ArgumentNullException("onFallback");
			}
			return policyBuilder.Fallback(delegate(Exception outcome, Context ctx, CancellationToken ct)
			{
				fallbackAction(ctx);
			}, onFallback);
		}

		public static FallbackPolicy Fallback(this PolicyBuilder policyBuilder, Action<Context, CancellationToken> fallbackAction, Action<Exception, Context> onFallback)
		{
			if (fallbackAction == null)
			{
				throw new ArgumentNullException("fallbackAction");
			}
			if (onFallback == null)
			{
				throw new ArgumentNullException("onFallback");
			}
			return policyBuilder.Fallback(delegate(Exception outcome, Context ctx, CancellationToken ct)
			{
				fallbackAction(ctx, ct);
			}, onFallback);
		}

		public static FallbackPolicy Fallback(this PolicyBuilder policyBuilder, Action<Exception, Context, CancellationToken> fallbackAction, Action<Exception, Context> onFallback)
		{
			if (fallbackAction == null)
			{
				throw new ArgumentNullException("fallbackAction");
			}
			if (onFallback == null)
			{
				throw new ArgumentNullException("onFallback");
			}
			return new FallbackPolicy(policyBuilder, onFallback, fallbackAction);
		}
	}
	public static class FallbackTResultSyntax
	{
		public static FallbackPolicy<TResult> Fallback<TResult>(this PolicyBuilder<TResult> policyBuilder, TResult fallbackValue)
		{
			Action<DelegateResult<TResult>> onFallback = delegate
			{
			};
			return policyBuilder.Fallback(() => fallbackValue, onFallback);
		}

		public static FallbackPolicy<TResult> Fallback<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<TResult> fallbackAction)
		{
			if (fallbackAction == null)
			{
				throw new ArgumentNullException("fallbackAction");
			}
			Action<DelegateResult<TResult>> onFallback = delegate
			{
			};
			return policyBuilder.Fallback(fallbackAction, onFallback);
		}

		public static FallbackPolicy<TResult> Fallback<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<CancellationToken, TResult> fallbackAction)
		{
			if (fallbackAction == null)
			{
				throw new ArgumentNullException("fallbackAction");
			}
			Action<DelegateResult<TResult>> onFallback = delegate
			{
			};
			return policyBuilder.Fallback(fallbackAction, onFallback);
		}

		public static FallbackPolicy<TResult> Fallback<TResult>(this PolicyBuilder<TResult> policyBuilder, TResult fallbackValue, Action<DelegateResult<TResult>> onFallback)
		{
			if (onFallback == null)
			{
				throw new ArgumentNullException("onFallback");
			}
			return policyBuilder.Fallback((DelegateResult<TResult> outcome, Context ctx, CancellationToken ct) => fallbackValue, delegate(DelegateResult<TResult> outcome, Context ctx)
			{
				onFallback(outcome);
			});
		}

		public static FallbackPolicy<TResult> Fallback<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<TResult> fallbackAction, Action<DelegateResult<TResult>> onFallback)
		{
			if (fallbackAction == null)
			{
				throw new ArgumentNullException("fallbackAction");
			}
			if (onFallback == null)
			{
				throw new ArgumentNullException("onFallback");
			}
			return policyBuilder.Fallback((DelegateResult<TResult> outcome, Context ctx, CancellationToken ct) => fallbackAction(), delegate(DelegateResult<TResult> outcome, Context ctx)
			{
				onFallback(outcome);
			});
		}

		public static FallbackPolicy<TResult> Fallback<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<CancellationToken, TResult> fallbackAction, Action<DelegateResult<TResult>> onFallback)
		{
			if (fallbackAction == null)
			{
				throw new ArgumentNullException("fallbackAction");
			}
			if (onFallback == null)
			{
				throw new ArgumentNullException("onFallback");
			}
			return policyBuilder.Fallback((DelegateResult<TResult> outcome, Context ctx, CancellationToken ct) => fallbackAction(ct), delegate(DelegateResult<TResult> outcome, Context ctx)
			{
				onFallback(outcome);
			});
		}

		public static FallbackPolicy<TResult> Fallback<TResult>(this PolicyBuilder<TResult> policyBuilder, TResult fallbackValue, Action<DelegateResult<TResult>, Context> onFallback)
		{
			if (onFallback == null)
			{
				throw new ArgumentNullException("onFallback");
			}
			return policyBuilder.Fallback((DelegateResult<TResult> outcome, Context ctx, CancellationToken ct) => fallbackValue, onFallback);
		}

		public static FallbackPolicy<TResult> Fallback<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<Context, TResult> fallbackAction, Action<DelegateResult<TResult>, Context> onFallback)
		{
			if (fallbackAction == null)
			{
				throw new ArgumentNullException("fallbackAction");
			}
			if (onFallback == null)
			{
				throw new ArgumentNullException("onFallback");
			}
			return policyBuilder.Fallback((DelegateResult<TResult> outcome, Context ctx, CancellationToken ct) => fallbackAction(ctx), onFallback);
		}

		public static FallbackPolicy<TResult> Fallback<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<Context, CancellationToken, TResult> fallbackAction, Action<DelegateResult<TResult>, Context> onFallback)
		{
			if (fallbackAction == null)
			{
				throw new ArgumentNullException("fallbackAction");
			}
			if (onFallback == null)
			{
				throw new ArgumentNullException("onFallback");
			}
			return policyBuilder.Fallback((DelegateResult<TResult> outcome, Context ctx, CancellationToken ct) => fallbackAction(ctx, ct), onFallback);
		}

		public static FallbackPolicy<TResult> Fallback<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<DelegateResult<TResult>, Context, CancellationToken, TResult> fallbackAction, Action<DelegateResult<TResult>, Context> onFallback)
		{
			if (fallbackAction == null)
			{
				throw new ArgumentNullException("fallbackAction");
			}
			if (onFallback == null)
			{
				throw new ArgumentNullException("onFallback");
			}
			return new FallbackPolicy<TResult>(policyBuilder, onFallback, fallbackAction);
		}
	}
	public interface IAsyncPolicy : IsPolicy
	{
		IAsyncPolicy WithPolicyKey(string policyKey);

		Task ExecuteAsync(Func<Task> action);

		Task ExecuteAsync(Func<Context, Task> action, IDictionary<string, object> contextData);

		Task ExecuteAsync(Func<Context, Task> action, Context context);

		Task ExecuteAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken);

		Task ExecuteAsync(Func<Context, CancellationToken, Task> action, IDictionary<string, object> contextData, CancellationToken cancellationToken);

		Task ExecuteAsync(Func<Context, CancellationToken, Task> action, Context context, CancellationToken cancellationToken);

		Task ExecuteAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, bool continueOnCapturedContext);

		Task ExecuteAsync(Func<Context, CancellationToken, Task> action, IDictionary<string, object> contextData, CancellationToken cancellationToken, bool continueOnCapturedContext);

		Task ExecuteAsync(Func<Context, CancellationToken, Task> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext);

		Task<TResult> ExecuteAsync<TResult>(Func<Task<TResult>> action);

		Task<TResult> ExecuteAsync<TResult>(Func<Context, Task<TResult>> action, Context context);

		Task<TResult> ExecuteAsync<TResult>(Func<Context, Task<TResult>> action, IDictionary<string, object> contextData);

		Task<TResult> ExecuteAsync<TResult>(Func<CancellationToken, Task<TResult>> action, CancellationToken cancellationToken);

		Task<TResult> ExecuteAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, IDictionary<string, object> contextData, CancellationToken cancellationToken);

		Task<TResult> ExecuteAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken);

		Task<TResult> ExecuteAsync<TResult>(Func<CancellationToken, Task<TResult>> action, CancellationToken cancellationToken, bool continueOnCapturedContext);

		Task<TResult> ExecuteAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, IDictionary<string, object> contextData, CancellationToken cancellationToken, bool continueOnCapturedContext);

		Task<TResult> ExecuteAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext);

		Task<PolicyResult> ExecuteAndCaptureAsync(Func<Task> action);

		Task<PolicyResult> ExecuteAndCaptureAsync(Func<Context, Task> action, IDictionary<string, object> contextData);

		Task<PolicyResult> ExecuteAndCaptureAsync(Func<Context, Task> action, Context context);

		Task<PolicyResult> ExecuteAndCaptureAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken);

		Task<PolicyResult> ExecuteAndCaptureAsync(Func<Context, CancellationToken, Task> action, IDictionary<string, object> contextData, CancellationToken cancellationToken);

		Task<PolicyResult> ExecuteAndCaptureAsync(Func<Context, CancellationToken, Task> action, Context context, CancellationToken cancellationToken);

		Task<PolicyResult> ExecuteAndCaptureAsync(Func<CancellationToken, Task> action, CancellationToken cancellationToken, bool continueOnCapturedContext);

		Task<PolicyResult> ExecuteAndCaptureAsync(Func<Context, CancellationToken, Task> action, IDictionary<string, object> contextData, CancellationToken cancellationToken, bool continueOnCapturedContext);

		Task<PolicyResult> ExecuteAndCaptureAsync(Func<Context, CancellationToken, Task> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext);

		Task<PolicyResult<TResult>> ExecuteAndCaptureAsync<TResult>(Func<Task<TResult>> action);

		Task<PolicyResult<TResult>> ExecuteAndCaptureAsync<TResult>(Func<Context, Task<TResult>> action, IDictionary<string, object> contextData);

		Task<PolicyResult<TResult>> ExecuteAndCaptureAsync<TResult>(Func<Context, Task<TResult>> action, Context context);

		Task<PolicyResult<TResult>> ExecuteAndCaptureAsync<TResult>(Func<CancellationToken, Task<TResult>> action, CancellationToken cancellationToken);

		Task<PolicyResult<TResult>> ExecuteAndCaptureAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, IDictionary<string, object> contextData, CancellationToken cancellationToken);

		Task<PolicyResult<TResult>> ExecuteAndCaptureAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken);

		Task<PolicyResult<TResult>> ExecuteAndCaptureAsync<TResult>(Func<CancellationToken, Task<TResult>> action, CancellationToken cancellationToken, bool continueOnCapturedContext);

		Task<PolicyResult<TResult>> ExecuteAndCaptureAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, IDictionary<string, object> contextData, CancellationToken cancellationToken, bool continueOnCapturedContext);

		Task<PolicyResult<TResult>> ExecuteAndCaptureAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext);
	}
	public static class IAsyncPolicyExtensions
	{
		public static IAsyncPolicy<TResult> AsAsyncPolicy<TResult>(this IAsyncPolicy policy)
		{
			return policy.WrapAsync(Policy.NoOpAsync<TResult>());
		}
	}
	public interface IAsyncPolicy<TResult> : IsPolicy
	{
		IAsyncPolicy<TResult> WithPolicyKey(string policyKey);

		Task<TResult> ExecuteAsync(Func<Task<TResult>> action);

		Task<TResult> ExecuteAsync(Func<Context, Task<TResult>> action, Context context);

		Task<TResult> ExecuteAsync(Func<Context, Task<TResult>> action, IDictionary<string, object> contextData);

		Task<TResult> ExecuteAsync(Func<CancellationToken, Task<TResult>> action, CancellationToken cancellationToken);

		Task<TResult> ExecuteAsync(Func<Context, CancellationToken, Task<TResult>> action, IDictionary<string, object> contextData, CancellationToken cancellationToken);

		Task<TResult> ExecuteAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken);

		Task<TResult> ExecuteAsync(Func<CancellationToken, Task<TResult>> action, CancellationToken cancellationToken, bool continueOnCapturedContext);

		Task<TResult> ExecuteAsync(Func<Context, CancellationToken, Task<TResult>> action, IDictionary<string, object> contextData, CancellationToken cancellationToken, bool continueOnCapturedContext);

		Task<TResult> ExecuteAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext);

		Task<PolicyResult<TResult>> ExecuteAndCaptureAsync(Func<Task<TResult>> action);

		Task<PolicyResult<TResult>> ExecuteAndCaptureAsync(Func<Context, Task<TResult>> action, IDictionary<string, object> contextData);

		Task<PolicyResult<TResult>> ExecuteAndCaptureAsync(Func<Context, Task<TResult>> action, Context context);

		Task<PolicyResult<TResult>> ExecuteAndCaptureAsync(Func<CancellationToken, Task<TResult>> action, CancellationToken cancellationToken);

		Task<PolicyResult<TResult>> ExecuteAndCaptureAsync(Func<Context, CancellationToken, Task<TResult>> action, IDictionary<string, object> contextData, CancellationToken cancellationToken);

		Task<PolicyResult<TResult>> ExecuteAndCaptureAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken);

		Task<PolicyResult<TResult>> ExecuteAndCaptureAsync(Func<CancellationToken, Task<TResult>> action, CancellationToken cancellationToken, bool continueOnCapturedContext);

		Task<PolicyResult<TResult>> ExecuteAndCaptureAsync(Func<Context, CancellationToken, Task<TResult>> action, IDictionary<string, object> contextData, CancellationToken cancellationToken, bool continueOnCapturedContext);

		Task<PolicyResult<TResult>> ExecuteAndCaptureAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext);
	}
	public interface IsPolicy
	{
		string PolicyKey { get; }
	}
	public interface ISyncPolicy : IsPolicy
	{
		ISyncPolicy WithPolicyKey(string policyKey);

		void Execute(Action action);

		void Execute(Action<Context> action, IDictionary<string, object> contextData);

		void Execute(Action<Context> action, Context context);

		void Execute(Action<CancellationToken> action, CancellationToken cancellationToken);

		void Execute(Action<Context, CancellationToken> action, IDictionary<string, object> contextData, CancellationToken cancellationToken);

		void Execute(Action<Context, CancellationToken> action, Context context, CancellationToken cancellationToken);

		TResult Execute<TResult>(Func<TResult> action);

		TResult Execute<TResult>(Func<Context, TResult> action, IDictionary<string, object> contextData);

		TResult Execute<TResult>(Func<Context, TResult> action, Context context);

		TResult Execute<TResult>(Func<CancellationToken, TResult> action, CancellationToken cancellationToken);

		TResult Execute<TResult>(Func<Context, CancellationToken, TResult> action, IDictionary<string, object> contextData, CancellationToken cancellationToken);

		TResult Execute<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken);

		PolicyResult ExecuteAndCapture(Action action);

		PolicyResult ExecuteAndCapture(Action<Context> action, IDictionary<string, object> contextData);

		PolicyResult ExecuteAndCapture(Action<Context> action, Context context);

		PolicyResult ExecuteAndCapture(Action<CancellationToken> action, CancellationToken cancellationToken);

		PolicyResult ExecuteAndCapture(Action<Context, CancellationToken> action, IDictionary<string, object> contextData, CancellationToken cancellationToken);

		PolicyResult ExecuteAndCapture(Action<Context, CancellationToken> action, Context context, CancellationToken cancellationToken);

		PolicyResult<TResult> ExecuteAndCapture<TResult>(Func<TResult> action);

		PolicyResult<TResult> ExecuteAndCapture<TResult>(Func<Context, TResult> action, IDictionary<string, object> contextData);

		PolicyResult<TResult> ExecuteAndCapture<TResult>(Func<Context, TResult> action, Context context);

		PolicyResult<TResult> ExecuteAndCapture<TResult>(Func<CancellationToken, TResult> action, CancellationToken cancellationToken);

		PolicyResult<TResult> ExecuteAndCapture<TResult>(Func<Context, CancellationToken, TResult> action, IDictionary<string, object> contextData, CancellationToken cancellationToken);

		PolicyResult<TResult> ExecuteAndCapture<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken);
	}
	public static class ISyncPolicyExtensions
	{
		public static ISyncPolicy<TResult> AsPolicy<TResult>(this ISyncPolicy policy)
		{
			return policy.Wrap(Policy.NoOp<TResult>());
		}
	}
	public interface ISyncPolicy<TResult> : IsPolicy
	{
		ISyncPolicy<TResult> WithPolicyKey(string policyKey);

		TResult Execute(Func<TResult> action);

		TResult Execute(Func<Context, TResult> action, IDictionary<string, object> contextData);

		TResult Execute(Func<Context, TResult> action, Context context);

		TResult Execute(Func<CancellationToken, TResult> action, CancellationToken cancellationToken);

		TResult Execute(Func<Context, CancellationToken, TResult> action, IDictionary<string, object> contextData, CancellationToken cancellationToken);

		TResult Execute(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken);

		PolicyResult<TResult> ExecuteAndCapture(Func<TResult> action);

		PolicyResult<TResult> ExecuteAndCapture(Func<Context, TResult> action, IDictionary<string, object> contextData);

		PolicyResult<TResult> ExecuteAndCapture(Func<Context, TResult> action, Context context);

		PolicyResult<TResult> ExecuteAndCapture(Func<CancellationToken, TResult> action, CancellationToken cancellationToken);

		PolicyResult<TResult> ExecuteAndCapture(Func<Context, CancellationToken, TResult> action, IDictionary<string, object> contextData, CancellationToken cancellationToken);

		PolicyResult<TResult> ExecuteAndCapture(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken);
	}
	public abstract class Policy<TResult> : PolicyBase<TResult>, ISyncPolicy<TResult>, IsPolicy
	{
		public Policy<TResult> WithPolicyKey(string policyKey)
		{
			if (policyKeyInternal != null)
			{
				throw PolicyBase.PolicyKeyMustBeImmutableException;
			}
			policyKeyInternal = policyKey;
			return this;
		}

		ISyncPolicy<TResult> ISyncPolicy<TResult>.WithPolicyKey(string policyKey)
		{
			if (policyKeyInternal != null)
			{
				throw PolicyBase.PolicyKeyMustBeImmutableException;
			}
			policyKeyInternal = policyKey;
			return this;
		}

		public static PolicyBuilder<TResult> Handle<TException>() where TException : Exception
		{
			return new PolicyBuilder<TResult>((Exception exception) => (!(exception is TException)) ? null : exception);
		}

		public static PolicyBuilder<TResult> Handle<TException>(Func<TException, bool> exceptionPredicate) where TException : Exception
		{
			return new PolicyBuilder<TResult>((Exception exception) => (!(exception is TException arg) || !exceptionPredicate(arg)) ? null : exception);
		}

		public static PolicyBuilder<TResult> HandleInner<TException>() where TException : Exception
		{
			return new PolicyBuilder<TResult>(PolicyBuilder.HandleInner((Exception ex) => ex is TException));
		}

		public static PolicyBuilder<TResult> HandleInner<TException>(Func<TException, bool> exceptionPredicate) where TException : Exception
		{
			return new PolicyBuilder<TResult>(PolicyBuilder.HandleInner((Exception ex) => ex is TException arg && exceptionPredicate(arg)));
		}

		public static PolicyBuilder<TResult> HandleResult(Func<TResult, bool> resultPredicate)
		{
			return new PolicyBuilder<TResult>(resultPredicate);
		}

		public static PolicyBuilder<TResult> HandleResult(TResult result)
		{
			return HandleResult((TResult r) => (r != null && r.Equals(result)) || (r == null && result == null));
		}

		protected abstract TResult Implementation(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken);

		internal Policy(ExceptionPredicates exceptionPredicates, ResultPredicates<TResult> resultPredicates)
			: base(exceptionPredicates, resultPredicates)
		{
		}

		protected Policy(PolicyBuilder<TResult> policyBuilder = null)
			: base(policyBuilder)
		{
		}

		[DebuggerStepThrough]
		public TResult Execute(Func<TResult> action)
		{
			return Execute((Context ctx, CancellationToken ct) => action(), new Context(), DefaultCancellationToken);
		}

		[DebuggerStepThrough]
		public TResult Execute(Func<Context, TResult> action, IDictionary<string, object> contextData)
		{
			return Execute((Context ctx, CancellationToken ct) => action(ctx), new Context(contextData), DefaultCancellationToken);
		}

		[DebuggerStepThrough]
		public TResult Execute(Func<Context, TResult> action, Context context)
		{
			return Execute((Context ctx, CancellationToken ct) => action(ctx), context, DefaultCancellationToken);
		}

		[DebuggerStepThrough]
		public TResult Execute(Func<CancellationToken, TResult> action, CancellationToken cancellationToken)
		{
			return Execute((Context ctx, CancellationToken ct) => action(ct), new Context(), cancellationToken);
		}

		[DebuggerStepThrough]
		public TResult Execute(Func<Context, CancellationToken, TResult> action, IDictionary<string, object> contextData, CancellationToken cancellationToken)
		{
			return Execute(action, new Context(contextData), cancellationToken);
		}

		[DebuggerStepThrough]
		public TResult Execute(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			SetPolicyContext(context, out var priorPolicyWrapKey, out var priorPolicyKey);
			try
			{
				return Implementation(action, context, cancellationToken);
			}
			finally
			{
				RestorePolicyContext(context, priorPolicyWrapKey, priorPolicyKey);
			}
		}

		[DebuggerStepThrough]
		public PolicyResult<TResult> ExecuteAndCapture(Func<TResult> action)
		{
			return ExecuteAndCapture((Context ctx, CancellationToken ct) => action(), new Context(), DefaultCancellationToken);
		}

		[DebuggerStepThrough]
		public PolicyResult<TResult> ExecuteAndCapture(Func<Context, TResult> action, IDictionary<string, object> contextData)
		{
			return ExecuteAndCapture((Context ctx, CancellationToken ct) => action(ctx), new Context(contextData), DefaultCancellationToken);
		}

		[DebuggerStepThrough]
		public PolicyResult<TResult> ExecuteAndCapture(Func<Context, TResult> action, Context context)
		{
			return ExecuteAndCapture((Context ctx, CancellationToken ct) => action(ctx), context, DefaultCancellationToken);
		}

		[DebuggerStepThrough]
		public PolicyResult<TResult> ExecuteAndCapture(Func<CancellationToken, TResult> action, CancellationToken cancellationToken)
		{
			return ExecuteAndCapture((Context ctx, CancellationToken ct) => action(ct), new Context(), cancellationToken);
		}

		[DebuggerStepThrough]
		public PolicyResult<TResult> ExecuteAndCapture(Func<Context, CancellationToken, TResult> action, IDictionary<string, object> contextData, CancellationToken cancellationToken)
		{
			return ExecuteAndCapture(action, new Context(contextData), cancellationToken);
		}

		[DebuggerStepThrough]
		public PolicyResult<TResult> ExecuteAndCapture(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
		{
			if (context == null)
			{
				throw new ArgumentNullException("context");
			}
			try
			{
				TResult val = Execute(action, context, cancellationToken);
				if (base.ResultPredicates.AnyMatch(val))
				{
					return PolicyResult<TResult>.Failure(val, context);
				}
				return PolicyResult<TResult>.Successful(val, context);
			}
			catch (Exception exception)
			{
				return PolicyResult<TResult>.Failure(exception, PolicyBase.GetExceptionType(base.ExceptionPredicates, exception), context);
			}
		}

		public PolicyWrap<TResult> Wrap(ISyncPolicy innerPolicy)
		{
			if (innerPolicy == null)
			{
				throw new ArgumentNullException("innerPolicy");
			}
			return new PolicyWrap<TResult>(this, innerPolicy);
		}

		public PolicyWrap<TResult> Wrap(ISyncPolicy<TResult> innerPolicy)
		{
			if (innerPolicy == null)
			{
				throw new ArgumentNullException("innerPolicy");
			}
			return new PolicyWrap<TResult>(this, innerPolicy);
		}
	}
	public abstract class PolicyBase
	{
		protected string policyKeyInternal;

		internal readonly CancellationToken DefaultCancellationToken = CancellationToken.None;

		internal const bool DefaultContinueOnCapturedContext = false;

		public string PolicyKey => policyKeyInternal ?? (policyKeyInternal = GetType().Name + "-" + KeyHelper.GuidPart());

		internal static ArgumentException PolicyKeyMustBeImmutableException => new ArgumentException("PolicyKey cannot be changed once set; or (when using the default value after the PolicyKey property has been accessed.", "policyKey");

		protected internal ExceptionPredicates ExceptionPredicates { get; }

		internal virtual void SetPolicyContext(Context executionContext, out string priorPolicyWrapKey, out string priorPolicyKey)
		{
			priorPolicyWrapKey = executionContext.PolicyWrapKey;
			priorPolicyKey = executionContext.PolicyKey;
			executionContext.PolicyKey = PolicyKey;
		}

		internal void RestorePolicyContext(Context executionContext, string priorPolicyWrapKey, string priorPolicyKey)
		{
			executionContext.PolicyWrapKey = priorPolicyWrapKey;
			executionContext.PolicyKey = priorPolicyKey;
		}

		internal static ExceptionType GetExceptionType(ExceptionPredicates exceptionPredicates, Exception exception)
		{
			if (exceptionPredicates.FirstMatchOrDefault(exception) == null)
			{
				return ExceptionType.Unhandled;
			}
			return ExceptionType.HandledByThisPolicy;
		}

		internal PolicyBase(ExceptionPredicates exceptionPredicates)
		{
			ExceptionPredicates = exceptionPredicates ?? ExceptionPredicates.None;
		}

		protected PolicyBase(PolicyBuilder policyBuilder)
			: this(policyBuilder?.ExceptionPredicates)
		{
		}
	}
	public abstract class PolicyBase<TResult> : PolicyBase
	{
		protected internal ResultPredicates<TResult> ResultPredicates { get; }

		internal PolicyBase(ExceptionPredicates exceptionPredicates, ResultPredicates<TResult> resultPredicates)
			: base(exceptionPredicates)
		{
			ResultPredicates = resultPredicates ?? ResultPredicates<TResult>.None;
		}

		protected PolicyBase(PolicyBuilder<TResult> policyBuilder)
			: this(policyBuilder?.ExceptionPredicates, policyBuilder?.ResultPredicates)
		{
		}
	}
	public sealed class PolicyBuilder
	{
		internal ExceptionPredicates ExceptionPredicates { get; }

		internal PolicyBuilder(ExceptionPredicate exceptionPredicate)
		{
			ExceptionPredicates = new ExceptionPredicates();
			ExceptionPredicates.Add(exceptionPredicate);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return base.ToString();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Type GetType()
		{
			return base.GetType();
		}

		public PolicyBuilder Or<TException>() where TException : Exception
		{
			ExceptionPredicates.Add((Exception exception) => (!(exception is TException)) ? null : exception);
			return this;
		}

		public PolicyBuilder Or<TException>(Func<TException, bool> exceptionPredicate) where TException : Exception
		{
			ExceptionPredicates.Add((Exception exception) => (!(exception is TException arg) || !exceptionPredicate(arg)) ? null : exception);
			return this;
		}

		public PolicyBuilder OrInner<TException>() where TException : Exception
		{
			ExceptionPredicates.Add(HandleInner((Exception ex) => ex is TException));
			return this;
		}

		public PolicyBuilder OrInner<TException>(Func<TException, bool> exceptionPredicate) where TException : Exception
		{
			ExceptionPredicates.Add(HandleInner((Exception exception) => exception is TException arg && exceptionPredicate(arg)));
			return this;
		}

		internal static ExceptionPredicate HandleInner(Func<Exception, bool> predicate)
		{
			return delegate(Exception exception)
			{
				if (exception is AggregateException ex)
				{
					Exception ex2 = ex.Flatten().InnerExceptions.FirstOrDefault(predicate);
					if (ex2 != null)
					{
						return ex2;
					}
				}
				return HandleInnerNested(predicate, exception);
			};
		}

		private static Exception HandleInnerNested(Func<Exception, bool> predicate, Exception current)
		{
			if (current == null)
			{
				return null;
			}
			if (predicate(current))
			{
				return current;
			}
			return HandleInnerNested(predicate, current.InnerException);
		}

		public PolicyBuilder<TResult> OrResult<TResult>(Func<TResult, bool> resultPredicate)
		{
			return new PolicyBuilder<TResult>(ExceptionPredicates).OrResult(resultPredicate);
		}

		public PolicyBuilder<TResult> OrResult<TResult>(TResult result)
		{
			return OrResult((TResult r) => (r != null && r.Equals(result)) || (r == null && result == null));
		}
	}
	public sealed class PolicyBuilder<TResult>
	{
		internal ExceptionPredicates ExceptionPredicates { get; }

		internal ResultPredicates<TResult> ResultPredicates { get; }

		private PolicyBuilder()
		{
			ExceptionPredicates = new ExceptionPredicates();
			ResultPredicates = new ResultPredicates<TResult>();
		}

		internal PolicyBuilder(Func<TResult, bool> resultPredicate)
			: this()
		{
			OrResult(resultPredicate);
		}

		internal PolicyBuilder(ExceptionPredicate predicate)
			: this()
		{
			ExceptionPredicates.Add(predicate);
		}

		internal PolicyBuilder(ExceptionPredicates exceptionPredicates)
			: this()
		{
			ExceptionPredicates = exceptionPredicates;
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override string ToString()
		{
			return base.ToString();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		[EditorBrowsable(EditorBrowsableState.Never)]
		public new Type GetType()
		{
			return base.GetType();
		}

		public PolicyBuilder<TResult> OrResult(Func<TResult, bool> resultPredicate)
		{
			ResultPredicate<TResult> predicate = (TResult result) => resultPredicate(result);
			ResultPredicates.Add(predicate);
			return this;
		}

		public PolicyBuilder<TResult> OrResult(TResult result)
		{
			return OrResult((TResult r) => (r != null && r.Equals(result)) || (r == null && result == null));
		}

		public PolicyBuilder<TResult> Or<TException>() where TException : Exception
		{
			ExceptionPredicates.Add((Exception exception) => (!(exception is TException)) ? null : exception);
			return this;
		}

		public PolicyBuilder<TResult> Or<TException>(Func<TException, bool> exceptionPredicate) where TException : Exception
		{
			ExceptionPredicates.Add((Exception exception) => (!(exception is TException arg) || !exceptionPredicate(arg)) ? null : exception);
			return this;
		}

		public PolicyBuilder<TResult> OrInner<TException>() where TException : Exception
		{
			ExceptionPredicates.Add(PolicyBuilder.HandleInner((Exception ex) => ex is TException));
			return this;
		}

		public PolicyBuilder<TResult> OrInner<TException>(Func<TException, bool> exceptionPredicate) where TException : Exception
		{
			ExceptionPredicates.Add(PolicyBuilder.HandleInner((Exception ex) => ex is TException arg && exceptionPredicate(arg)));
			return this;
		}
	}
	public class PolicyResult
	{
		public OutcomeType Outcome { get; }

		public Exception FinalException { get; }

		public ExceptionType? ExceptionType { get; }

		public Context Context { get; }

		internal PolicyResult(OutcomeType outcome, Exception finalException, ExceptionType? exceptionType, Context context)
		{
			Outcome = outcome;
			FinalException = finalException;
			ExceptionType = exceptionType;
			Context = context;
		}

		public static PolicyResult Successful(Context context)
		{
			return new PolicyResult(OutcomeType.Successful, null, null, context);
		}

		public static PolicyResult Failure(Exception exception, ExceptionType exceptionType, Context context)
		{
			return new PolicyResult(OutcomeType.Failure, exception, exceptionType, context);
		}
	}
	public class PolicyResult<TResult>
	{
		public OutcomeType Outcome { get; }

		public Exception FinalException { get; }

		public ExceptionType? ExceptionType { get; }

		public TResult Result { get; }

		public TResult FinalHandledResult { get; }

		public FaultType? FaultType { get; }

		public Context Context { get; }

		internal PolicyResult(TResult result, OutcomeType outcome, Exception finalException, ExceptionType? exceptionType, Context context)
			: this(result, outcome, finalException, exceptionType, default(TResult), (FaultType?)null, context)
		{
		}

		internal PolicyResult(TResult result, OutcomeType outcome, Exception finalException, ExceptionType? exceptionType, TResult finalHandledResult, FaultType? faultType, Context context)
		{
			Result = result;
			Outcome = outcome;
			FinalException = finalException;
			ExceptionType = exceptionType;
			FinalHandledResult = finalHandledResult;
			FaultType = faultType;
			Context = context;
		}

		public static PolicyResult<TResult> Successful(TResult result, Context context)
		{
			return new PolicyResult<TResult>(result, OutcomeType.Successful, null, null, context);
		}

		public static PolicyResult<TResult> Failure(Exception exception, ExceptionType exceptionType, Context context)
		{
			return new PolicyResult<TResult>(default(TResult), OutcomeType.Failure, exception, exceptionType, default(TResult), (exceptionType != Polly.ExceptionType.HandledByThisPolicy) ? Polly.FaultType.UnhandledException : Polly.FaultType.ExceptionHandledByThisPolicy, context);
		}

		public static PolicyResult<TResult> Failure(TResult handledResult, Context context)
		{
			return new PolicyResult<TResult>(default(TResult), OutcomeType.Failure, null, null, handledResult, Polly.FaultType.ResultHandledByThisPolicy, context);
		}
	}
	public enum OutcomeType
	{
		Successful,
		Failure
	}
	public enum ExceptionType
	{
		HandledByThisPolicy,
		Unhandled
	}
	public enum FaultType
	{
		ExceptionHandledByThisPolicy,
		UnhandledException,
		ResultHandledByThisPolicy
	}
	public delegate bool ResultPredicate<in TResult>(TResult result);
	public class ResultPredicates<TResult>
	{
		private List<ResultPredicate<TResult>> _predicates;

		public static readonly ResultPredicates<TResult> None = new ResultPredicates<TResult>();

		internal void Add(ResultPredicate<TResult> predicate)
		{
			_predicates = _predicates ?? new List<ResultPredicate<TResult>>();
			_predicates.Add(predicate);
		}

		public bool AnyMatch(TResult result)
		{
			if (_predicates == null)
			{
				return false;
			}
			return _predicates.Any((ResultPredicate<TResult> predicate) => predicate(result));
		}
	}
	public static class AsyncRetrySyntax
	{
		public static AsyncRetryPolicy RetryAsync(this PolicyBuilder policyBuilder)
		{
			return policyBuilder.RetryAsync(1);
		}

		public static AsyncRetryPolicy RetryAsync(this PolicyBuilder policyBuilder, int retryCount)
		{
			Action<Exception, int, Context> onRetry = delegate
			{
			};
			return policyBuilder.RetryAsync(retryCount, onRetry);
		}

		public static AsyncRetryPolicy RetryAsync(this PolicyBuilder policyBuilder, Action<Exception, int> onRetry)
		{
			return policyBuilder.RetryAsync(1, async delegate(Exception outcome, int i, Context ctx)
			{
				onRetry(outcome, i);
			});
		}

		public static AsyncRetryPolicy RetryAsync(this PolicyBuilder policyBuilder, Func<Exception, int, Task> onRetryAsync)
		{
			return policyBuilder.RetryAsync(1, (Exception outcome, int i, Context ctx) => onRetryAsync(outcome, i));
		}

		public static AsyncRetryPolicy RetryAsync(this PolicyBuilder policyBuilder, int retryCount, Action<Exception, int> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.RetryAsync(retryCount, async delegate(Exception outcome, int i, Context ctx)
			{
				onRetry(outcome, i);
			});
		}

		public static AsyncRetryPolicy RetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<Exception, int, Task> onRetryAsync)
		{
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return policyBuilder.RetryAsync(retryCount, (Exception outcome, int i, Context ctx) => onRetryAsync(outcome, i));
		}

		public static AsyncRetryPolicy RetryAsync(this PolicyBuilder policyBuilder, Action<Exception, int, Context> onRetry)
		{
			return policyBuilder.RetryAsync(1, onRetry);
		}

		public static AsyncRetryPolicy RetryAsync(this PolicyBuilder policyBuilder, Func<Exception, int, Context, Task> onRetryAsync)
		{
			return policyBuilder.RetryAsync(1, onRetryAsync);
		}

		public static AsyncRetryPolicy RetryAsync(this PolicyBuilder policyBuilder, int retryCount, Action<Exception, int, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.RetryAsync(retryCount, async delegate(Exception outcome, int i, Context ctx)
			{
				onRetry(outcome, i, ctx);
			});
		}

		public static AsyncRetryPolicy RetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<Exception, int, Context, Task> onRetryAsync)
		{
			if (retryCount < 0)
			{
				throw new ArgumentOutOfRangeException("retryCount", "Value must be greater than or equal to zero.");
			}
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return new AsyncRetryPolicy(policyBuilder, (Exception outcome, TimeSpan timespan, int i, Context ctx) => onRetryAsync(outcome, i, ctx), retryCount);
		}

		public static AsyncRetryPolicy RetryForeverAsync(this PolicyBuilder policyBuilder)
		{
			Action<Exception> onRetry = delegate
			{
			};
			return policyBuilder.RetryForeverAsync(onRetry);
		}

		public static AsyncRetryPolicy RetryForeverAsync(this PolicyBuilder policyBuilder, Action<Exception> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.RetryForeverAsync(async delegate(Exception outcome, Context ctx)
			{
				onRetry(outcome);
			});
		}

		public static AsyncRetryPolicy RetryForeverAsync(this PolicyBuilder policyBuilder, Action<Exception, int> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.RetryForeverAsync(async delegate(Exception outcome, int i, Context context)
			{
				onRetry(outcome, i);
			});
		}

		public static AsyncRetryPolicy RetryForeverAsync(this PolicyBuilder policyBuilder, Func<Exception, Task> onRetryAsync)
		{
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return policyBuilder.RetryForeverAsync((Exception outcome, Context ctx) => onRetryAsync(outcome));
		}

		public static AsyncRetryPolicy RetryForeverAsync(this PolicyBuilder policyBuilder, Func<Exception, int, Task> onRetryAsync)
		{
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return policyBuilder.RetryForeverAsync((Exception outcome, int i, Context context) => onRetryAsync(outcome, i));
		}

		public static AsyncRetryPolicy RetryForeverAsync(this PolicyBuilder policyBuilder, Action<Exception, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.RetryForeverAsync(async delegate(Exception outcome, Context ctx)
			{
				onRetry(outcome, ctx);
			});
		}

		public static AsyncRetryPolicy RetryForeverAsync(this PolicyBuilder policyBuilder, Action<Exception, int, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.RetryForeverAsync(async delegate(Exception outcome, int i, Context ctx)
			{
				onRetry(outcome, i, ctx);
			});
		}

		public static AsyncRetryPolicy RetryForeverAsync(this PolicyBuilder policyBuilder, Func<Exception, Context, Task> onRetryAsync)
		{
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return new AsyncRetryPolicy(policyBuilder, (Exception outcome, TimeSpan timespan, int i, Context ctx) => onRetryAsync(outcome, ctx));
		}

		public static AsyncRetryPolicy RetryForeverAsync(this PolicyBuilder policyBuilder, Func<Exception, int, Context, Task> onRetryAsync)
		{
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return new AsyncRetryPolicy(policyBuilder, (Exception outcome, TimeSpan timespan, int i, Context ctx) => onRetryAsync(outcome, i, ctx));
		}

		public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider)
		{
			Action<Exception, TimeSpan> onRetry = delegate
			{
			};
			return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, onRetry);
		}

		public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, async delegate(Exception outcome, TimeSpan span, int i, Context ctx)
			{
				onRetry(outcome, span);
			});
		}

		public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Func<Exception, TimeSpan, Task> onRetryAsync)
		{
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, (Exception outcome, TimeSpan span, int i, Context ctx) => onRetryAsync(outcome, span));
		}

		public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, async delegate(Exception outcome, TimeSpan span, int i, Context ctx)
			{
				onRetry(outcome, span, ctx);
			});
		}

		public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Func<Exception, TimeSpan, Context, Task> onRetryAsync)
		{
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, (Exception outcome, TimeSpan timespan, int i, Context ctx) => onRetryAsync(outcome, timespan, ctx));
		}

		public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, int, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, async delegate(Exception outcome, TimeSpan timespan, int i, Context ctx)
			{
				onRetry(outcome, timespan, i, ctx);
			});
		}

		public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Func<Exception, TimeSpan, int, Context, Task> onRetryAsync)
		{
			if (retryCount < 0)
			{
				throw new ArgumentOutOfRangeException("retryCount", "Value must be greater than or equal to zero.");
			}
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			IEnumerable<TimeSpan> sleepDurationsEnumerable = Enumerable.Range(1, retryCount).Select(sleepDurationProvider);
			return new AsyncRetryPolicy(policyBuilder, onRetryAsync, retryCount, sleepDurationsEnumerable);
		}

		public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, Context, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, async delegate(Exception outcome, TimeSpan span, int i, Context ctx)
			{
				onRetry(outcome, span, ctx);
			});
		}

		public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, Context, TimeSpan> sleepDurationProvider, Func<Exception, TimeSpan, Context, Task> onRetryAsync)
		{
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, (Exception outcome, TimeSpan timespan, int i, Context ctx) => onRetryAsync(outcome, timespan, ctx));
		}

		public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, Context, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, int, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, async delegate(Exception outcome, TimeSpan timespan, int i, Context ctx)
			{
				onRetry(outcome, timespan, i, ctx);
			});
		}

		public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, Context, TimeSpan> sleepDurationProvider, Func<Exception, TimeSpan, int, Context, Task> onRetryAsync)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			return policyBuilder.WaitAndRetryAsync(retryCount, (int i, Exception outcome, Context ctx) => sleepDurationProvider(i, ctx), onRetryAsync);
		}

		public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, int retryCount, Func<int, Exception, Context, TimeSpan> sleepDurationProvider, Func<Exception, TimeSpan, int, Context, Task> onRetryAsync)
		{
			if (retryCount < 0)
			{
				throw new ArgumentOutOfRangeException("retryCount", "Value must be greater than or equal to zero.");
			}
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return new AsyncRetryPolicy(policyBuilder, onRetryAsync, retryCount, null, sleepDurationProvider);
		}

		public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, IEnumerable<TimeSpan> sleepDurations)
		{
			Action<Exception, TimeSpan, int, Context> onRetry = delegate
			{
			};
			return policyBuilder.WaitAndRetryAsync(sleepDurations, onRetry);
		}

		public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, IEnumerable<TimeSpan> sleepDurations, Action<Exception, TimeSpan> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryAsync(sleepDurations, async delegate(Exception outcome, TimeSpan timespan, int i, Context ctx)
			{
				onRetry(outcome, timespan);
			});
		}

		public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, IEnumerable<TimeSpan> sleepDurations, Func<Exception, TimeSpan, Task> onRetryAsync)
		{
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return policyBuilder.WaitAndRetryAsync(sleepDurations, (Exception outcome, TimeSpan timespan, int i, Context ctx) => onRetryAsync(outcome, timespan));
		}

		public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, IEnumerable<TimeSpan> sleepDurations, Action<Exception, TimeSpan, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryAsync(sleepDurations, async delegate(Exception outcome, TimeSpan timespan, int i, Context ctx)
			{
				onRetry(outcome, timespan, ctx);
			});
		}

		public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, IEnumerable<TimeSpan> sleepDurations, Func<Exception, TimeSpan, Context, Task> onRetryAsync)
		{
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return policyBuilder.WaitAndRetryAsync(sleepDurations, (Exception outcome, TimeSpan timespan, int i, Context ctx) => onRetryAsync(outcome, timespan, ctx));
		}

		public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, IEnumerable<TimeSpan> sleepDurations, Action<Exception, TimeSpan, int, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryAsync(sleepDurations, async delegate(Exception outcome, TimeSpan timespan, int i, Context ctx)
			{
				onRetry(outcome, timespan, i, ctx);
			});
		}

		public static AsyncRetryPolicy WaitAndRetryAsync(this PolicyBuilder policyBuilder, IEnumerable<TimeSpan> sleepDurations, Func<Exception, TimeSpan, int, Context, Task> onRetryAsync)
		{
			if (sleepDurations == null)
			{
				throw new ArgumentNullException("sleepDurations");
			}
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return new AsyncRetryPolicy(policyBuilder, onRetryAsync, 2147483647, sleepDurations);
		}

		public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, TimeSpan> sleepDurationProvider)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			Action<Exception, TimeSpan> onRetry = delegate
			{
			};
			return policyBuilder.WaitAndRetryForeverAsync(sleepDurationProvider, onRetry);
		}

		public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			Action<Exception, TimeSpan, Context> onRetry = delegate
			{
			};
			return policyBuilder.WaitAndRetryForeverAsync(sleepDurationProvider, onRetry);
		}

		public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan> onRetry)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryForeverAsync((int retryCount, Context context) => sleepDurationProvider(retryCount), delegate(Exception exception, TimeSpan timespan, Context context)
			{
				onRetry(exception, timespan);
			});
		}

		public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, TimeSpan> sleepDurationProvider, Action<Exception, int, TimeSpan> onRetry)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryForeverAsync((int retryCount, Context context) => sleepDurationProvider(retryCount), delegate(Exception exception, int i, TimeSpan timespan, Context context)
			{
				onRetry(exception, i, timespan);
			});
		}

		public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, TimeSpan> sleepDurationProvider, Func<Exception, TimeSpan, Task> onRetryAsync)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return policyBuilder.WaitAndRetryForeverAsync((int retryCount, Context context) => sleepDurationProvider(retryCount), (Exception exception, TimeSpan timespan, Context context) => onRetryAsync(exception, timespan));
		}

		public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, TimeSpan> sleepDurationProvider, Func<Exception, int, TimeSpan, Task> onRetryAsync)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return policyBuilder.WaitAndRetryForeverAsync((int retryCount, Context context) => sleepDurationProvider(retryCount), (Exception exception, int i, TimeSpan timespan, Context context) => onRetryAsync(exception, i, timespan));
		}

		public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, Context> onRetry)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryForeverAsync(sleepDurationProvider, async delegate(Exception exception, TimeSpan timespan, Context ctx)
			{
				onRetry(exception, timespan, ctx);
			});
		}

		public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider, Action<Exception, int, TimeSpan, Context> onRetry)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryForeverAsync(sleepDurationProvider, async delegate(Exception exception, int i, TimeSpan timespan, Context ctx)
			{
				onRetry(exception, i, timespan, ctx);
			});
		}

		public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider, Func<Exception, TimeSpan, Context, Task> onRetryAsync)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			return policyBuilder.WaitAndRetryForeverAsync((int i, Exception outcome, Context ctx) => sleepDurationProvider(i, ctx), onRetryAsync);
		}

		public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider, Func<Exception, int, TimeSpan, Context, Task> onRetryAsync)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			return policyBuilder.WaitAndRetryForeverAsync((int i, Exception outcome, Context ctx) => sleepDurationProvider(i, ctx), onRetryAsync);
		}

		public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, Exception, Context, TimeSpan> sleepDurationProvider, Func<Exception, TimeSpan, Context, Task> onRetryAsync)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return new AsyncRetryPolicy(policyBuilder, (Exception outcome, TimeSpan timespan, int i, Context ctx) => onRetryAsync(outcome, timespan, ctx), 2147483647, null, sleepDurationProvider);
		}

		public static AsyncRetryPolicy WaitAndRetryForeverAsync(this PolicyBuilder policyBuilder, Func<int, Exception, Context, TimeSpan> sleepDurationProvider, Func<Exception, int, TimeSpan, Context, Task> onRetryAsync)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return new AsyncRetryPolicy(policyBuilder, (Exception exception, TimeSpan timespan, int i, Context ctx) => onRetryAsync(exception, i, timespan, ctx), 2147483647, null, sleepDurationProvider);
		}
	}
	public static class AsyncRetryTResultSyntax
	{
		public static AsyncRetryPolicy<TResult> RetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder)
		{
			return policyBuilder.RetryAsync(1);
		}

		public static AsyncRetryPolicy<TResult> RetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount)
		{
			Action<DelegateResult<TResult>, int> onRetry = delegate
			{
			};
			return policyBuilder.RetryAsync(retryCount, onRetry);
		}

		public static AsyncRetryPolicy<TResult> RetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Action<DelegateResult<TResult>, int> onRetry)
		{
			return policyBuilder.RetryAsync(1, async delegate(DelegateResult<TResult> outcome, int i, Context ctx)
			{
				onRetry(outcome, i);
			});
		}

		public static AsyncRetryPolicy<TResult> RetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<DelegateResult<TResult>, int, Task> onRetryAsync)
		{
			return policyBuilder.RetryAsync(1, (DelegateResult<TResult> outcome, int i, Context ctx) => onRetryAsync(outcome, i));
		}

		public static AsyncRetryPolicy<TResult> RetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Action<DelegateResult<TResult>, int> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.RetryAsync(retryCount, async delegate(DelegateResult<TResult> outcome, int i, Context ctx)
			{
				onRetry(outcome, i);
			});
		}

		public static AsyncRetryPolicy<TResult> RetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<DelegateResult<TResult>, int, Task> onRetryAsync)
		{
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return policyBuilder.RetryAsync(retryCount, (DelegateResult<TResult> outcome, int i, Context ctx) => onRetryAsync(outcome, i));
		}

		public static AsyncRetryPolicy<TResult> RetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Action<DelegateResult<TResult>, int, Context> onRetry)
		{
			return policyBuilder.RetryAsync(1, onRetry);
		}

		public static AsyncRetryPolicy<TResult> RetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<DelegateResult<TResult>, int, Context, Task> onRetryAsync)
		{
			return policyBuilder.RetryAsync(1, onRetryAsync);
		}

		public static AsyncRetryPolicy<TResult> RetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Action<DelegateResult<TResult>, int, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.RetryAsync(retryCount, async delegate(DelegateResult<TResult> outcome, int i, Context ctx)
			{
				onRetry(outcome, i, ctx);
			});
		}

		public static AsyncRetryPolicy<TResult> RetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<DelegateResult<TResult>, int, Context, Task> onRetryAsync)
		{
			if (retryCount < 0)
			{
				throw new ArgumentOutOfRangeException("retryCount", "Value must be greater than or equal to zero.");
			}
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return new AsyncRetryPolicy<TResult>(policyBuilder, (DelegateResult<TResult> outcome, TimeSpan timespan, int i, Context ctx) => onRetryAsync(outcome, i, ctx), retryCount);
		}

		public static AsyncRetryPolicy<TResult> RetryForeverAsync<TResult>(this PolicyBuilder<TResult> policyBuilder)
		{
			Action<DelegateResult<TResult>> onRetry = delegate
			{
			};
			return policyBuilder.RetryForeverAsync(onRetry);
		}

		public static AsyncRetryPolicy<TResult> RetryForeverAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Action<DelegateResult<TResult>> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.RetryForeverAsync(async delegate(DelegateResult<TResult> outcome, Context ctx)
			{
				onRetry(outcome);
			});
		}

		public static AsyncRetryPolicy<TResult> RetryForeverAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Action<DelegateResult<TResult>, int> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.RetryForeverAsync(async delegate(DelegateResult<TResult> outcome, int i, Context context)
			{
				onRetry(outcome, i);
			});
		}

		public static AsyncRetryPolicy<TResult> RetryForeverAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<DelegateResult<TResult>, Task> onRetryAsync)
		{
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return policyBuilder.RetryForeverAsync((DelegateResult<TResult> outcome, Context ctx) => onRetryAsync(outcome));
		}

		public static AsyncRetryPolicy<TResult> RetryForeverAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<DelegateResult<TResult>, int, Task> onRetryAsync)
		{
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return policyBuilder.RetryForeverAsync((DelegateResult<TResult> outcome, int i, Context context) => onRetryAsync(outcome, i));
		}

		public static AsyncRetryPolicy<TResult> RetryForeverAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Action<DelegateResult<TResult>, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.RetryForeverAsync(async delegate(DelegateResult<TResult> outcome, Context ctx)
			{
				onRetry(outcome, ctx);
			});
		}

		public static AsyncRetryPolicy<TResult> RetryForeverAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Action<DelegateResult<TResult>, int, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.RetryForeverAsync(async delegate(DelegateResult<TResult> outcome, int i, Context ctx)
			{
				onRetry(outcome, i, ctx);
			});
		}

		public static AsyncRetryPolicy<TResult> RetryForeverAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<DelegateResult<TResult>, Context, Task> onRetryAsync)
		{
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return new AsyncRetryPolicy<TResult>(policyBuilder, (DelegateResult<TResult> outcome, TimeSpan timespan, int i, Context ctx) => onRetryAsync(outcome, ctx));
		}

		public static AsyncRetryPolicy<TResult> RetryForeverAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<DelegateResult<TResult>, int, Context, Task> onRetryAsync)
		{
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return new AsyncRetryPolicy<TResult>(policyBuilder, (DelegateResult<TResult> outcome, TimeSpan timespan, int i, Context ctx) => onRetryAsync(outcome, i, ctx));
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider)
		{
			Action<DelegateResult<TResult>, TimeSpan> onRetry = delegate
			{
			};
			return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, onRetry);
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, TimeSpan> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, async delegate(DelegateResult<TResult> outcome, TimeSpan span, int i, Context ctx)
			{
				onRetry(outcome, span);
			});
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Func<DelegateResult<TResult>, TimeSpan, Task> onRetryAsync)
		{
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, (DelegateResult<TResult> outcome, TimeSpan span, int i, Context ctx) => onRetryAsync(outcome, span));
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, TimeSpan, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, async delegate(DelegateResult<TResult> outcome, TimeSpan span, int i, Context ctx)
			{
				onRetry(outcome, span, ctx);
			});
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Func<DelegateResult<TResult>, TimeSpan, Context, Task> onRetryAsync)
		{
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, (DelegateResult<TResult> outcome, TimeSpan timespan, int i, Context ctx) => onRetryAsync(outcome, timespan, ctx));
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, TimeSpan, int, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, async delegate(DelegateResult<TResult> outcome, TimeSpan timespan, int i, Context ctx)
			{
				onRetry(outcome, timespan, i, ctx);
			});
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Func<DelegateResult<TResult>, TimeSpan, int, Context, Task> onRetryAsync)
		{
			if (retryCount < 0)
			{
				throw new ArgumentOutOfRangeException("retryCount", "Value must be greater than or equal to zero.");
			}
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			IEnumerable<TimeSpan> sleepDurationsEnumerable = Enumerable.Range(1, retryCount).Select(sleepDurationProvider);
			return new AsyncRetryPolicy<TResult>(policyBuilder, onRetryAsync, retryCount, sleepDurationsEnumerable);
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, Context, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, TimeSpan, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, async delegate(DelegateResult<TResult> outcome, TimeSpan span, int i, Context ctx)
			{
				onRetry(outcome, span, ctx);
			});
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, Context, TimeSpan> sleepDurationProvider, Func<DelegateResult<TResult>, TimeSpan, Context, Task> onRetryAsync)
		{
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, (DelegateResult<TResult> outcome, TimeSpan timespan, int i, Context ctx) => onRetryAsync(outcome, timespan, ctx));
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, Context, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, TimeSpan, int, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryAsync(retryCount, sleepDurationProvider, async delegate(DelegateResult<TResult> outcome, TimeSpan timespan, int i, Context ctx)
			{
				onRetry(outcome, timespan, i, ctx);
			});
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, Context, TimeSpan> sleepDurationProvider, Func<DelegateResult<TResult>, TimeSpan, int, Context, Task> onRetryAsync)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			return policyBuilder.WaitAndRetryAsync(retryCount, (int i, DelegateResult<TResult> outcome, Context ctx) => sleepDurationProvider(i, ctx), onRetryAsync);
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, DelegateResult<TResult>, Context, TimeSpan> sleepDurationProvider, Func<DelegateResult<TResult>, TimeSpan, int, Context, Task> onRetryAsync)
		{
			if (retryCount < 0)
			{
				throw new ArgumentOutOfRangeException("retryCount", "Value must be greater than or equal to zero.");
			}
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return new AsyncRetryPolicy<TResult>(policyBuilder, onRetryAsync, retryCount, null, sleepDurationProvider);
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, IEnumerable<TimeSpan> sleepDurations)
		{
			Action<DelegateResult<TResult>, TimeSpan> onRetry = delegate
			{
			};
			return policyBuilder.WaitAndRetryAsync(sleepDurations, onRetry);
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, IEnumerable<TimeSpan> sleepDurations, Action<DelegateResult<TResult>, TimeSpan> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryAsync(sleepDurations, async delegate(DelegateResult<TResult> outcome, TimeSpan timespan, int i, Context ctx)
			{
				onRetry(outcome, timespan);
			});
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, IEnumerable<TimeSpan> sleepDurations, Func<DelegateResult<TResult>, TimeSpan, Task> onRetryAsync)
		{
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return policyBuilder.WaitAndRetryAsync(sleepDurations, (DelegateResult<TResult> outcome, TimeSpan timespan, int i, Context ctx) => onRetryAsync(outcome, timespan));
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, IEnumerable<TimeSpan> sleepDurations, Action<DelegateResult<TResult>, TimeSpan, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryAsync(sleepDurations, async delegate(DelegateResult<TResult> outcome, TimeSpan timespan, int i, Context ctx)
			{
				onRetry(outcome, timespan, ctx);
			});
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, IEnumerable<TimeSpan> sleepDurations, Func<DelegateResult<TResult>, TimeSpan, Context, Task> onRetryAsync)
		{
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return policyBuilder.WaitAndRetryAsync(sleepDurations, (DelegateResult<TResult> outcome, TimeSpan timespan, int i, Context ctx) => onRetryAsync(outcome, timespan, ctx));
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, IEnumerable<TimeSpan> sleepDurations, Action<DelegateResult<TResult>, TimeSpan, int, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryAsync(sleepDurations, async delegate(DelegateResult<TResult> outcome, TimeSpan timespan, int i, Context ctx)
			{
				onRetry(outcome, timespan, i, ctx);
			});
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, IEnumerable<TimeSpan> sleepDurations, Func<DelegateResult<TResult>, TimeSpan, int, Context, Task> onRetryAsync)
		{
			if (sleepDurations == null)
			{
				throw new ArgumentNullException("sleepDurations");
			}
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return new AsyncRetryPolicy<TResult>(policyBuilder, onRetryAsync, 2147483647, sleepDurations);
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryForeverAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<int, TimeSpan> sleepDurationProvider)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			Action<DelegateResult<TResult>, TimeSpan> onRetry = delegate
			{
			};
			return policyBuilder.WaitAndRetryForeverAsync(sleepDurationProvider, onRetry);
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryForeverAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			Action<DelegateResult<TResult>, TimeSpan, Context> onRetry = delegate
			{
			};
			return policyBuilder.WaitAndRetryForeverAsync(sleepDurationProvider, onRetry);
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryForeverAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<int, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, TimeSpan> onRetry)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryForeverAsync((int retryCount, Context context) => sleepDurationProvider(retryCount), delegate(DelegateResult<TResult> outcome, TimeSpan timespan, Context context)
			{
				onRetry(outcome, timespan);
			});
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryForeverAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<int, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, int, TimeSpan> onRetry)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryForeverAsync((int retryCount, Context context) => sleepDurationProvider(retryCount), delegate(DelegateResult<TResult> outcome, int i, TimeSpan timespan, Context context)
			{
				onRetry(outcome, i, timespan);
			});
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryForeverAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<int, TimeSpan> sleepDurationProvider, Func<DelegateResult<TResult>, TimeSpan, Task> onRetryAsync)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return policyBuilder.WaitAndRetryForeverAsync((int retryCount, Context context) => sleepDurationProvider(retryCount), (DelegateResult<TResult> outcome, TimeSpan timespan, Context context) => onRetryAsync(outcome, timespan));
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryForeverAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<int, TimeSpan> sleepDurationProvider, Func<DelegateResult<TResult>, int, TimeSpan, Task> onRetryAsync)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return policyBuilder.WaitAndRetryForeverAsync((int retryCount, Context context) => sleepDurationProvider(retryCount), (DelegateResult<TResult> outcome, int i, TimeSpan timespan, Context context) => onRetryAsync(outcome, i, timespan));
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryForeverAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, TimeSpan, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryForeverAsync(sleepDurationProvider, async delegate(DelegateResult<TResult> outcome, TimeSpan timespan, Context ctx)
			{
				onRetry(outcome, timespan, ctx);
			});
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryForeverAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, int, TimeSpan, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryForeverAsync(sleepDurationProvider, async delegate(DelegateResult<TResult> outcome, int i, TimeSpan timespan, Context ctx)
			{
				onRetry(outcome, i, timespan, ctx);
			});
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryForeverAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider, Func<DelegateResult<TResult>, TimeSpan, Context, Task> onRetryAsync)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			return policyBuilder.WaitAndRetryForeverAsync((int i, DelegateResult<TResult> outcome, Context ctx) => sleepDurationProvider(i, ctx), onRetryAsync);
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryForeverAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider, Func<DelegateResult<TResult>, int, TimeSpan, Context, Task> onRetryAsync)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			return policyBuilder.WaitAndRetryForeverAsync((int i, DelegateResult<TResult> outcome, Context ctx) => sleepDurationProvider(i, ctx), onRetryAsync);
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryForeverAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<int, DelegateResult<TResult>, Context, TimeSpan> sleepDurationProvider, Func<DelegateResult<TResult>, TimeSpan, Context, Task> onRetryAsync)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return new AsyncRetryPolicy<TResult>(policyBuilder, (DelegateResult<TResult> outcome, TimeSpan timespan, int i, Context ctx) => onRetryAsync(outcome, timespan, ctx), 2147483647, null, sleepDurationProvider);
		}

		public static AsyncRetryPolicy<TResult> WaitAndRetryForeverAsync<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<int, DelegateResult<TResult>, Context, TimeSpan> sleepDurationProvider, Func<DelegateResult<TResult>, int, TimeSpan, Context, Task> onRetryAsync)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetryAsync == null)
			{
				throw new ArgumentNullException("onRetryAsync");
			}
			return new AsyncRetryPolicy<TResult>(policyBuilder, (DelegateResult<TResult> exception, TimeSpan timespan, int i, Context ctx) => onRetryAsync(exception, i, timespan, ctx), 2147483647, null, sleepDurationProvider);
		}
	}
	public static class RetrySyntax
	{
		public static RetryPolicy Retry(this PolicyBuilder policyBuilder)
		{
			return policyBuilder.Retry(1);
		}

		public static RetryPolicy Retry(this PolicyBuilder policyBuilder, int retryCount)
		{
			Action<Exception, int> onRetry = delegate
			{
			};
			return policyBuilder.Retry(retryCount, onRetry);
		}

		public static RetryPolicy Retry(this PolicyBuilder policyBuilder, Action<Exception, int> onRetry)
		{
			return policyBuilder.Retry(1, onRetry);
		}

		public static RetryPolicy Retry(this PolicyBuilder policyBuilder, int retryCount, Action<Exception, int> onRetry)
		{
			if (retryCount < 0)
			{
				throw new ArgumentOutOfRangeException("retryCount", "Value must be greater than or equal to zero.");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.Retry(retryCount, delegate(Exception outcome, int i, Context ctx)
			{
				onRetry(outcome, i);
			});
		}

		public static RetryPolicy Retry(this PolicyBuilder policyBuilder, Action<Exception, int, Context> onRetry)
		{
			return policyBuilder.Retry(1, onRetry);
		}

		public static RetryPolicy Retry(this PolicyBuilder policyBuilder, int retryCount, Action<Exception, int, Context> onRetry)
		{
			if (retryCount < 0)
			{
				throw new ArgumentOutOfRangeException("retryCount", "Value must be greater than or equal to zero.");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return new RetryPolicy(policyBuilder, delegate(Exception outcome, TimeSpan timespan, int i, Context ctx)
			{
				onRetry(outcome, i, ctx);
			}, retryCount);
		}

		public static RetryPolicy RetryForever(this PolicyBuilder policyBuilder)
		{
			Action<Exception> onRetry = delegate
			{
			};
			return policyBuilder.RetryForever(onRetry);
		}

		public static RetryPolicy RetryForever(this PolicyBuilder policyBuilder, Action<Exception> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.RetryForever(delegate(Exception outcome, Context ctx)
			{
				onRetry(outcome);
			});
		}

		public static RetryPolicy RetryForever(this PolicyBuilder policyBuilder, Action<Exception, int> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.RetryForever(delegate(Exception outcome, int i, Context ctx)
			{
				onRetry(outcome, i);
			});
		}

		public static RetryPolicy RetryForever(this PolicyBuilder policyBuilder, Action<Exception, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return new RetryPolicy(policyBuilder, delegate(Exception outcome, TimeSpan timespan, int i, Context ctx)
			{
				onRetry(outcome, ctx);
			});
		}

		public static RetryPolicy RetryForever(this PolicyBuilder policyBuilder, Action<Exception, int, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return new RetryPolicy(policyBuilder, delegate(Exception outcome, TimeSpan timespan, int i, Context ctx)
			{
				onRetry(outcome, i, ctx);
			});
		}

		public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider)
		{
			Action<Exception, TimeSpan, int, Context> onRetry = delegate
			{
			};
			return policyBuilder.WaitAndRetry(retryCount, sleepDurationProvider, onRetry);
		}

		public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetry(retryCount, sleepDurationProvider, delegate(Exception outcome, TimeSpan span, int i, Context ctx)
			{
				onRetry(outcome, span);
			});
		}

		public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetry(retryCount, sleepDurationProvider, delegate(Exception outcome, TimeSpan span, int i, Context ctx)
			{
				onRetry(outcome, span, ctx);
			});
		}

		public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, int, Context> onRetry)
		{
			if (retryCount < 0)
			{
				throw new ArgumentOutOfRangeException("retryCount", "Value must be greater than or equal to zero.");
			}
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			IEnumerable<TimeSpan> sleepDurationsEnumerable = Enumerable.Range(1, retryCount).Select(sleepDurationProvider);
			return new RetryPolicy(policyBuilder, onRetry, retryCount, sleepDurationsEnumerable);
		}

		public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, int retryCount, Func<int, Context, TimeSpan> sleepDurationProvider)
		{
			Action<Exception, TimeSpan, int, Context> onRetry = delegate
			{
			};
			return policyBuilder.WaitAndRetry(retryCount, sleepDurationProvider, onRetry);
		}

		public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, int retryCount, Func<int, Context, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetry(retryCount, sleepDurationProvider, delegate(Exception outcome, TimeSpan span, int i, Context ctx)
			{
				onRetry(outcome, span, ctx);
			});
		}

		public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, int retryCount, Func<int, Context, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, int, Context> onRetry)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			return policyBuilder.WaitAndRetry(retryCount, (int i, Exception outcome, Context ctx) => sleepDurationProvider(i, ctx), onRetry);
		}

		public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, int retryCount, Func<int, Exception, Context, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, int, Context> onRetry)
		{
			if (retryCount < 0)
			{
				throw new ArgumentOutOfRangeException("retryCount", "Value must be greater than or equal to zero.");
			}
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return new RetryPolicy(policyBuilder, onRetry, retryCount, null, sleepDurationProvider);
		}

		public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, IEnumerable<TimeSpan> sleepDurations)
		{
			Action<Exception, TimeSpan> onRetry = delegate
			{
			};
			return policyBuilder.WaitAndRetry(sleepDurations, onRetry);
		}

		public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, IEnumerable<TimeSpan> sleepDurations, Action<Exception, TimeSpan> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetry(sleepDurations, delegate(Exception outcome, TimeSpan span, int i, Context ctx)
			{
				onRetry(outcome, span);
			});
		}

		public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, IEnumerable<TimeSpan> sleepDurations, Action<Exception, TimeSpan, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetry(sleepDurations, delegate(Exception outcome, TimeSpan span, int i, Context ctx)
			{
				onRetry(outcome, span, ctx);
			});
		}

		public static RetryPolicy WaitAndRetry(this PolicyBuilder policyBuilder, IEnumerable<TimeSpan> sleepDurations, Action<Exception, TimeSpan, int, Context> onRetry)
		{
			if (sleepDurations == null)
			{
				throw new ArgumentNullException("sleepDurations");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return new RetryPolicy(policyBuilder, onRetry, 2147483647, sleepDurations);
		}

		public static RetryPolicy WaitAndRetryForever(this PolicyBuilder policyBuilder, Func<int, TimeSpan> sleepDurationProvider)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			Action<Exception, TimeSpan> onRetry = delegate
			{
			};
			return policyBuilder.WaitAndRetryForever(sleepDurationProvider, onRetry);
		}

		public static RetryPolicy WaitAndRetryForever(this PolicyBuilder policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			Action<Exception, TimeSpan, Context> onRetry = delegate
			{
			};
			return policyBuilder.WaitAndRetryForever(sleepDurationProvider, onRetry);
		}

		public static RetryPolicy WaitAndRetryForever(this PolicyBuilder policyBuilder, Func<int, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan> onRetry)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryForever((int retryCount, Context context) => sleepDurationProvider(retryCount), delegate(Exception exception, TimeSpan timespan, Context context)
			{
				onRetry(exception, timespan);
			});
		}

		public static RetryPolicy WaitAndRetryForever(this PolicyBuilder policyBuilder, Func<int, TimeSpan> sleepDurationProvider, Action<Exception, int, TimeSpan> onRetry)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryForever((int retryCount, Exception exception, Context context) => sleepDurationProvider(retryCount), delegate(Exception exception, int i, TimeSpan timespan, Context context)
			{
				onRetry(exception, i, timespan);
			});
		}

		public static RetryPolicy WaitAndRetryForever(this PolicyBuilder policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, Context> onRetry)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			return policyBuilder.WaitAndRetryForever((int i, Exception outcome, Context ctx) => sleepDurationProvider(i, ctx), onRetry);
		}

		public static RetryPolicy WaitAndRetryForever(this PolicyBuilder policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider, Action<Exception, int, TimeSpan, Context> onRetry)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			return policyBuilder.WaitAndRetryForever((int i, Exception outcome, Context ctx) => sleepDurationProvider(i, ctx), onRetry);
		}

		public static RetryPolicy WaitAndRetryForever(this PolicyBuilder policyBuilder, Func<int, Exception, Context, TimeSpan> sleepDurationProvider, Action<Exception, TimeSpan, Context> onRetry)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return new RetryPolicy(policyBuilder, delegate(Exception outcome, TimeSpan timespan, int i, Context ctx)
			{
				onRetry(outcome, timespan, ctx);
			}, 2147483647, null, sleepDurationProvider);
		}

		public static RetryPolicy WaitAndRetryForever(this PolicyBuilder policyBuilder, Func<int, Exception, Context, TimeSpan> sleepDurationProvider, Action<Exception, int, TimeSpan, Context> onRetry)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return new RetryPolicy(policyBuilder, delegate(Exception exception, TimeSpan timespan, int i, Context ctx)
			{
				onRetry(exception, i, timespan, ctx);
			}, 2147483647, null, sleepDurationProvider);
		}
	}
	public static class RetryTResultSyntax
	{
		public static RetryPolicy<TResult> Retry<TResult>(this PolicyBuilder<TResult> policyBuilder)
		{
			return policyBuilder.Retry(1);
		}

		public static RetryPolicy<TResult> Retry<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount)
		{
			Action<DelegateResult<TResult>, int> onRetry = delegate
			{
			};
			return policyBuilder.Retry(retryCount, onRetry);
		}

		public static RetryPolicy<TResult> Retry<TResult>(this PolicyBuilder<TResult> policyBuilder, Action<DelegateResult<TResult>, int> onRetry)
		{
			return policyBuilder.Retry(1, onRetry);
		}

		public static RetryPolicy<TResult> Retry<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Action<DelegateResult<TResult>, int> onRetry)
		{
			if (retryCount < 0)
			{
				throw new ArgumentOutOfRangeException("retryCount", "Value must be greater than or equal to zero.");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.Retry(retryCount, delegate(DelegateResult<TResult> outcome, int i, Context ctx)
			{
				onRetry(outcome, i);
			});
		}

		public static RetryPolicy<TResult> Retry<TResult>(this PolicyBuilder<TResult> policyBuilder, Action<DelegateResult<TResult>, int, Context> onRetry)
		{
			return policyBuilder.Retry(1, onRetry);
		}

		public static RetryPolicy<TResult> Retry<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Action<DelegateResult<TResult>, int, Context> onRetry)
		{
			if (retryCount < 0)
			{
				throw new ArgumentOutOfRangeException("retryCount", "Value must be greater than or equal to zero.");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return new RetryPolicy<TResult>(policyBuilder, delegate(DelegateResult<TResult> outcome, TimeSpan timespan, int i, Context ctx)
			{
				onRetry(outcome, i, ctx);
			}, retryCount);
		}

		public static RetryPolicy<TResult> RetryForever<TResult>(this PolicyBuilder<TResult> policyBuilder)
		{
			Action<DelegateResult<TResult>> onRetry = delegate
			{
			};
			return policyBuilder.RetryForever(onRetry);
		}

		public static RetryPolicy<TResult> RetryForever<TResult>(this PolicyBuilder<TResult> policyBuilder, Action<DelegateResult<TResult>> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.RetryForever(delegate(DelegateResult<TResult> outcome, Context ctx)
			{
				onRetry(outcome);
			});
		}

		public static RetryPolicy<TResult> RetryForever<TResult>(this PolicyBuilder<TResult> policyBuilder, Action<DelegateResult<TResult>, int> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.RetryForever(delegate(DelegateResult<TResult> outcome, int i, Context context)
			{
				onRetry(outcome, i);
			});
		}

		public static RetryPolicy<TResult> RetryForever<TResult>(this PolicyBuilder<TResult> policyBuilder, Action<DelegateResult<TResult>, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return new RetryPolicy<TResult>(policyBuilder, delegate(DelegateResult<TResult> outcome, TimeSpan timespan, int i, Context ctx)
			{
				onRetry(outcome, ctx);
			});
		}

		public static RetryPolicy<TResult> RetryForever<TResult>(this PolicyBuilder<TResult> policyBuilder, Action<DelegateResult<TResult>, int, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return new RetryPolicy<TResult>(policyBuilder, delegate(DelegateResult<TResult> outcome, TimeSpan timespan, int i, Context ctx)
			{
				onRetry(outcome, i, ctx);
			});
		}

		public static RetryPolicy<TResult> WaitAndRetry<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider)
		{
			Action<DelegateResult<TResult>, TimeSpan, int, Context> onRetry = delegate
			{
			};
			return policyBuilder.WaitAndRetry(retryCount, sleepDurationProvider, onRetry);
		}

		public static RetryPolicy<TResult> WaitAndRetry<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, TimeSpan> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetry(retryCount, sleepDurationProvider, delegate(DelegateResult<TResult> outcome, TimeSpan span, int i, Context ctx)
			{
				onRetry(outcome, span);
			});
		}

		public static RetryPolicy<TResult> WaitAndRetry<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, TimeSpan, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetry(retryCount, sleepDurationProvider, delegate(DelegateResult<TResult> outcome, TimeSpan span, int i, Context ctx)
			{
				onRetry(outcome, span, ctx);
			});
		}

		public static RetryPolicy<TResult> WaitAndRetry<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, TimeSpan, int, Context> onRetry)
		{
			if (retryCount < 0)
			{
				throw new ArgumentOutOfRangeException("retryCount", "Value must be greater than or equal to zero.");
			}
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			IEnumerable<TimeSpan> sleepDurationsEnumerable = Enumerable.Range(1, retryCount).Select(sleepDurationProvider);
			return new RetryPolicy<TResult>(policyBuilder, onRetry, retryCount, sleepDurationsEnumerable);
		}

		public static RetryPolicy<TResult> WaitAndRetry<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, Context, TimeSpan> sleepDurationProvider)
		{
			Action<DelegateResult<TResult>, TimeSpan, int, Context> onRetry = delegate
			{
			};
			return policyBuilder.WaitAndRetry(retryCount, sleepDurationProvider, onRetry);
		}

		public static RetryPolicy<TResult> WaitAndRetry<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, Context, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, TimeSpan, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetry(retryCount, sleepDurationProvider, delegate(DelegateResult<TResult> outcome, TimeSpan span, int i, Context ctx)
			{
				onRetry(outcome, span, ctx);
			});
		}

		public static RetryPolicy<TResult> WaitAndRetry<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, Context, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, TimeSpan, int, Context> onRetry)
		{
			return policyBuilder.WaitAndRetry(retryCount, (int i, DelegateResult<TResult> outcome, Context ctx) => sleepDurationProvider(i, ctx), onRetry);
		}

		public static RetryPolicy<TResult> WaitAndRetry<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, DelegateResult<TResult>, Context, TimeSpan> sleepDurationProvider)
		{
			Action<DelegateResult<TResult>, TimeSpan, int, Context> onRetry = delegate
			{
			};
			return policyBuilder.WaitAndRetry(retryCount, sleepDurationProvider, onRetry);
		}

		public static RetryPolicy<TResult> WaitAndRetry<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, DelegateResult<TResult>, Context, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, TimeSpan, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetry(retryCount, sleepDurationProvider, delegate(DelegateResult<TResult> outcome, TimeSpan span, int i, Context ctx)
			{
				onRetry(outcome, span, ctx);
			});
		}

		public static RetryPolicy<TResult> WaitAndRetry<TResult>(this PolicyBuilder<TResult> policyBuilder, int retryCount, Func<int, DelegateResult<TResult>, Context, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, TimeSpan, int, Context> onRetry)
		{
			if (retryCount < 0)
			{
				throw new ArgumentOutOfRangeException("retryCount", "Value must be greater than or equal to zero.");
			}
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return new RetryPolicy<TResult>(policyBuilder, onRetry, retryCount, null, sleepDurationProvider);
		}

		public static RetryPolicy<TResult> WaitAndRetry<TResult>(this PolicyBuilder<TResult> policyBuilder, IEnumerable<TimeSpan> sleepDurations)
		{
			Action<DelegateResult<TResult>, TimeSpan> onRetry = delegate
			{
			};
			return policyBuilder.WaitAndRetry(sleepDurations, onRetry);
		}

		public static RetryPolicy<TResult> WaitAndRetry<TResult>(this PolicyBuilder<TResult> policyBuilder, IEnumerable<TimeSpan> sleepDurations, Action<DelegateResult<TResult>, TimeSpan> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetry(sleepDurations, delegate(DelegateResult<TResult> outcome, TimeSpan span, int i, Context ctx)
			{
				onRetry(outcome, span);
			});
		}

		public static RetryPolicy<TResult> WaitAndRetry<TResult>(this PolicyBuilder<TResult> policyBuilder, IEnumerable<TimeSpan> sleepDurations, Action<DelegateResult<TResult>, TimeSpan, Context> onRetry)
		{
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetry(sleepDurations, delegate(DelegateResult<TResult> outcome, TimeSpan span, int i, Context ctx)
			{
				onRetry(outcome, span, ctx);
			});
		}

		public static RetryPolicy<TResult> WaitAndRetry<TResult>(this PolicyBuilder<TResult> policyBuilder, IEnumerable<TimeSpan> sleepDurations, Action<DelegateResult<TResult>, TimeSpan, int, Context> onRetry)
		{
			if (sleepDurations == null)
			{
				throw new ArgumentNullException("sleepDurations");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return new RetryPolicy<TResult>(policyBuilder, onRetry, 2147483647, sleepDurations);
		}

		public static RetryPolicy<TResult> WaitAndRetryForever<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<int, TimeSpan> sleepDurationProvider)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			Action<DelegateResult<TResult>, TimeSpan> onRetry = delegate
			{
			};
			return policyBuilder.WaitAndRetryForever(sleepDurationProvider, onRetry);
		}

		public static RetryPolicy<TResult> WaitAndRetryForever<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			Action<DelegateResult<TResult>, TimeSpan, Context> onRetry = delegate
			{
			};
			return policyBuilder.WaitAndRetryForever(sleepDurationProvider, onRetry);
		}

		public static RetryPolicy<TResult> WaitAndRetryForever<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<int, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, TimeSpan> onRetry)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryForever((int retryCount, Context context) => sleepDurationProvider(retryCount), delegate(DelegateResult<TResult> exception, TimeSpan timespan, Context context)
			{
				onRetry(exception, timespan);
			});
		}

		public static RetryPolicy<TResult> WaitAndRetryForever<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<int, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, int, TimeSpan> onRetry)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return policyBuilder.WaitAndRetryForever((int retryCount, DelegateResult<TResult> outcome, Context context) => sleepDurationProvider(retryCount), delegate(DelegateResult<TResult> outcome, int i, TimeSpan timespan, Context context)
			{
				onRetry(outcome, i, timespan);
			});
		}

		public static RetryPolicy<TResult> WaitAndRetryForever<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, TimeSpan, Context> onRetry)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			return policyBuilder.WaitAndRetryForever((int i, DelegateResult<TResult> outcome, Context ctx) => sleepDurationProvider(i, ctx), onRetry);
		}

		public static RetryPolicy<TResult> WaitAndRetryForever<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<int, Context, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, int, TimeSpan, Context> onRetry)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			return policyBuilder.WaitAndRetryForever((int i, DelegateResult<TResult> outcome, Context ctx) => sleepDurationProvider(i, ctx), onRetry);
		}

		public static RetryPolicy<TResult> WaitAndRetryForever<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<int, DelegateResult<TResult>, Context, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, TimeSpan, Context> onRetry)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return new RetryPolicy<TResult>(policyBuilder, delegate(DelegateResult<TResult> outcome, TimeSpan timespan, int i, Context ctx)
			{
				onRetry(outcome, timespan, ctx);
			}, 2147483647, null, sleepDurationProvider);
		}

		public static RetryPolicy<TResult> WaitAndRetryForever<TResult>(this PolicyBuilder<TResult> policyBuilder, Func<int, DelegateResult<TResult>, Context, TimeSpan> sleepDurationProvider, Action<DelegateResult<TResult>, int, TimeSpan, Context> onRetry)
		{
			if (sleepDurationProvider == null)
			{
				throw new ArgumentNullException("sleepDurationProvider");
			}
			if (onRetry == null)
			{
				throw new ArgumentNullException("onRetry");
			}
			return new RetryPolicy<TResult>(policyBuilder, delegate(DelegateResult<TResult> exception, TimeSpan timespan, int i, Context ctx)
			{
				onRetry(exception, i, timespan, ctx);
			}, 2147483647, null, sleepDurationProvider);
		}
	}
	public static class IAsyncPolicyPolicyWrapExtensions
	{
		public static AsyncPolicyWrap WrapAsync(this IAsyncPolicy outerPolicy, IAsyncPolicy innerPolicy)
		{
			if (outerPolicy == null)
			{
				throw new ArgumentNullException("outerPolicy");
			}
			return ((AsyncPolicy)outerPolicy).WrapAsync(innerPolicy);
		}

		public static AsyncPolicyWrap<TResult> WrapAsync<TResult>(this IAsyncPolicy outerPolicy, IAsyncPolicy<TResult> innerPolicy)
		{
			if (outerPolicy == null)
			{
				throw new ArgumentNullException("outerPolicy");
			}
			return ((AsyncPolicy)outerPolicy).WrapAsync(innerPolicy);
		}

		public static AsyncPolicyWrap<TResult> WrapAsync<TResult>(this IAsyncPolicy<TResult> outerPolicy, IAsyncPolicy innerPolicy)
		{
			if (outerPolicy == null)
			{
				throw new ArgumentNullException("outerPolicy");
			}
			return ((AsyncPolicy<TResult>)outerPolicy).WrapAsync(innerPolicy);
		}

		public static AsyncPolicyWrap<TResult> WrapAsync<TResult>(this IAsyncPolicy<TResult> outerPolicy, IAsyncPolicy<TResult> innerPolicy)
		{
			if (outerPolicy == null)
			{
				throw new ArgumentNullException("outerPolicy");
			}
			return ((AsyncPolicy<TResult>)outerPolicy).WrapAsync(innerPolicy);
		}
	}
	public static class ISyncPolicyPolicyWrapExtensions
	{
		public static PolicyWrap Wrap(this ISyncPolicy outerPolicy, ISyncPolicy innerPolicy)
		{
			if (outerPolicy == null)
			{
				throw new ArgumentNullException("outerPolicy");
			}
			return ((Policy)outerPolicy).Wrap(innerPolicy);
		}

		public static PolicyWrap<TResult> Wrap<TResult>(this ISyncPolicy outerPolicy, ISyncPolicy<TResult> innerPolicy)
		{
			if (outerPolicy == null)
			{
				throw new ArgumentNullException("outerPolicy");
			}
			return ((Policy)outerPolicy).Wrap(innerPolicy);
		}

		public static PolicyWrap<TResult> Wrap<TResult>(this ISyncPolicy<TResult> outerPolicy, ISyncPolicy innerPolicy)
		{
			if (outerPolicy == null)
			{
				throw new ArgumentNullException("outerPolicy");
			}
			return ((Policy<TResult>)outerPolicy).Wrap(innerPolicy);
		}

		public static PolicyWrap<TResult> Wrap<TResult>(this ISyncPolicy<TResult> outerPolicy, ISyncPolicy<TResult> innerPolicy)
		{
			if (outerPolicy == null)
			{
				throw new ArgumentNullException("outerPolicy");
			}
			return ((Policy<TResult>)outerPolicy).Wrap(innerPolicy);
		}
	}
}
namespace Polly.Wrap
{
	public class AsyncPolicyWrap : AsyncPolicy, IPolicyWrap, IsPolicy
	{
		private IAsyncPolicy _outer;

		private IAsyncPolicy _inner;

		public IsPolicy Outer => _outer;

		public IsPolicy Inner => _inner;

		internal override void SetPolicyContext(Context executionContext, out string priorPolicyWrapKey, out string priorPolicyKey)
		{
			priorPolicyWrapKey = executionContext.PolicyWrapKey;
			priorPolicyKey = executionContext.PolicyKey;
			if (executionContext.PolicyWrapKey == null)
			{
				executionContext.PolicyWrapKey = base.PolicyKey;
			}
			base.SetPolicyContext(executionContext, out var _, out var _);
		}

		internal AsyncPolicyWrap(AsyncPolicy outer, IAsyncPolicy inner)
			: base(outer.ExceptionPredicates)
		{
			_outer = outer;
			_inner = inner;
		}

		[DebuggerStepThrough]
		protected override Task ImplementationAsync(Func<Context, CancellationToken, Task> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return AsyncPolicyWrapEngine.ImplementationAsync(action, context, cancellationToken, continueOnCapturedContext, _outer, _inner);
		}

		[DebuggerStepThrough]
		protected override Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return AsyncPolicyWrapEngine.ImplementationAsync(action, context, cancellationToken, continueOnCapturedContext, _outer, _inner);
		}
	}
	public class AsyncPolicyWrap<TResult> : AsyncPolicy<TResult>, IPolicyWrap<TResult>, IPolicyWrap, IsPolicy
	{
		private IAsyncPolicy _outerNonGeneric;

		private IAsyncPolicy _innerNonGeneric;

		private IAsyncPolicy<TResult> _outerGeneric;

		private IAsyncPolicy<TResult> _innerGeneric;

		public IsPolicy Outer
		{
			get
			{
				IsPolicy outerGeneric = _outerGeneric;
				return outerGeneric ?? _outerNonGeneric;
			}
		}

		public IsPolicy Inner
		{
			get
			{
				IsPolicy innerGeneric = _innerGeneric;
				return innerGeneric ?? _innerNonGeneric;
			}
		}

		internal override void SetPolicyContext(Context executionContext, out string priorPolicyWrapKey, out string priorPolicyKey)
		{
			priorPolicyWrapKey = executionContext.PolicyWrapKey;
			priorPolicyKey = executionContext.PolicyKey;
			if (executionContext.PolicyWrapKey == null)
			{
				executionContext.PolicyWrapKey = base.PolicyKey;
			}
			base.SetPolicyContext(executionContext, out var _, out var _);
		}

		internal AsyncPolicyWrap(AsyncPolicy outer, IAsyncPolicy<TResult> inner)
			: base(outer.ExceptionPredicates, ResultPredicates<TResult>.None)
		{
			_outerNonGeneric = outer;
			_innerGeneric = inner;
		}

		internal AsyncPolicyWrap(AsyncPolicy<TResult> outer, IAsyncPolicy inner)
			: base(outer.ExceptionPredicates, outer.ResultPredicates)
		{
			_outerGeneric = outer;
			_innerNonGeneric = inner;
		}

		internal AsyncPolicyWrap(AsyncPolicy<TResult> outer, IAsyncPolicy<TResult> inner)
			: base(outer.ExceptionPredicates, outer.ResultPredicates)
		{
			_outerGeneric = outer;
			_innerGeneric = inner;
		}

		protected override Task<TResult> ImplementationAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			if (_outerNonGeneric != null)
			{
				if (_innerNonGeneric != null)
				{
					return AsyncPolicyWrapEngine.ImplementationAsync(action, context, cancellationToken, continueOnCapturedContext, _outerNonGeneric, _innerNonGeneric);
				}
				if (_innerGeneric != null)
				{
					return AsyncPolicyWrapEngine.ImplementationAsync(action, context, cancellationToken, continueOnCapturedContext, _outerNonGeneric, _innerGeneric);
				}
				throw new InvalidOperationException("A AsyncPolicyWrap must define an inner policy.");
			}
			if (_outerGeneric != null)
			{
				if (_innerNonGeneric != null)
				{
					return AsyncPolicyWrapEngine.ImplementationAsync(action, context, cancellationToken, continueOnCapturedContext, _outerGeneric, _innerNonGeneric);
				}
				if (_innerGeneric != null)
				{
					return AsyncPolicyWrapEngine.ImplementationAsync(action, context, cancellationToken, continueOnCapturedContext, _outerGeneric, _innerGeneric);
				}
				throw new InvalidOperationException("A AsyncPolicyWrap must define an inner policy.");
			}
			throw new InvalidOperationException("A AsyncPolicyWrap must define an outer policy.");
		}
	}
	internal static class AsyncPolicyWrapEngine
	{
		internal static async Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> func, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext, IAsyncPolicy<TResult> outerPolicy, IAsyncPolicy<TResult> innerPolicy)
		{
			return await outerPolicy.ExecuteAsync(async (Context ctx, CancellationToken ct) => await innerPolicy.ExecuteAsync(func, ctx, ct, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext), context, cancellationToken, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext);
		}

		internal static async Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> func, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext, IAsyncPolicy<TResult> outerPolicy, IAsyncPolicy innerPolicy)
		{
			return await outerPolicy.ExecuteAsync(async (Context ctx, CancellationToken ct) => await innerPolicy.ExecuteAsync(func, ctx, ct, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext), context, cancellationToken, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext);
		}

		internal static async Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> func, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext, IAsyncPolicy outerPolicy, IAsyncPolicy<TResult> innerPolicy)
		{
			return await outerPolicy.ExecuteAsync(async (Context ctx, CancellationToken ct) => await innerPolicy.ExecuteAsync(func, ctx, ct, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext), context, cancellationToken, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext);
		}

		internal static async Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> func, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext, IAsyncPolicy outerPolicy, IAsyncPolicy innerPolicy)
		{
			return await outerPolicy.ExecuteAsync(async (Context ctx, CancellationToken ct) => await innerPolicy.ExecuteAsync(func, ctx, ct, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext), context, cancellationToken, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext);
		}

		internal static async Task ImplementationAsync(Func<Context, CancellationToken, Task> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext, IAsyncPolicy outerPolicy, IAsyncPolicy innerPolicy)
		{
			await outerPolicy.ExecuteAsync(async delegate(Context ctx, CancellationToken ct)
			{
				await innerPolicy.ExecuteAsync(action, ctx, ct, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext);
			}, context, cancellationToken, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext);
		}
	}
	public interface IPolicyWrap : IsPolicy
	{
		IsPolicy Outer { get; }

		IsPolicy Inner { get; }
	}
	public interface IPolicyWrap<TResult> : IPolicyWrap, IsPolicy
	{
	}
	public static class IPolicyWrapExtension
	{
		public static IEnumerable<IsPolicy> GetPolicies(this IPolicyWrap policyWrap)
		{
			IsPolicy[] array = new IsPolicy[2] { policyWrap.Outer, policyWrap.Inner };
			IsPolicy[] array2 = array;
			foreach (IsPolicy isPolicy in array2)
			{
				if (isPolicy is IPolicyWrap policyWrap2)
				{
					foreach (IsPolicy policy in policyWrap2.GetPolicies())
					{
						yield return policy;
					}
				}
				else if (isPolicy != null)
				{
					yield return isPolicy;
				}
			}
		}

		public static IEnumerable<TPolicy> GetPolicies<TPolicy>(this IPolicyWrap policyWrap)
		{
			return policyWrap.GetPolicies().OfType<TPolicy>();
		}

		public static IEnumerable<TPolicy> GetPolicies<TPolicy>(this IPolicyWrap policyWrap, Func<TPolicy, bool> filter)
		{
			if (filter == null)
			{
				throw new ArgumentNullException("filter");
			}
			return policyWrap.GetPolicies().OfType<TPolicy>().Where(filter);
		}

		public static TPolicy GetPolicy<TPolicy>(this IPolicyWrap policyWrap)
		{
			return policyWrap.GetPolicies().OfType<TPolicy>().SingleOrDefault();
		}

		public static TPolicy GetPolicy<TPolicy>(this IPolicyWrap policyWrap, Func<TPolicy, bool> filter)
		{
			if (filter == null)
			{
				throw new ArgumentNullException("filter");
			}
			return policyWrap.GetPolicies().OfType<TPolicy>().SingleOrDefault(filter);
		}
	}
	public class PolicyWrap : Policy, IPolicyWrap, IsPolicy
	{
		private ISyncPolicy _outer;

		private ISyncPolicy _inner;

		public IsPolicy Outer => _outer;

		public IsPolicy Inner => _inner;

		internal override void SetPolicyContext(Context executionContext, out string priorPolicyWrapKey, out string priorPolicyKey)
		{
			priorPolicyWrapKey = executionContext.PolicyWrapKey;
			priorPolicyKey = executionContext.PolicyKey;
			if (executionContext.PolicyWrapKey == null)
			{
				executionContext.PolicyWrapKey = base.PolicyKey;
			}
			base.SetPolicyContext(executionContext, out var _, out var _);
		}

		internal PolicyWrap(Policy outer, ISyncPolicy inner)
			: base(outer.ExceptionPredicates)
		{
			_outer = outer;
			_inner = inner;
		}

		[DebuggerStepThrough]
		protected override void Implementation(Action<Context, CancellationToken> action, Context context, CancellationToken cancellationToken)
		{
			PolicyWrapEngine.Implementation(action, context, cancellationToken, _outer, _inner);
		}

		[DebuggerStepThrough]
		protected override TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
		{
			return PolicyWrapEngine.Implementation(action, context, cancellationToken, _outer, _inner);
		}
	}
	public class PolicyWrap<TResult> : Policy<TResult>, IPolicyWrap<TResult>, IPolicyWrap, IsPolicy
	{
		private ISyncPolicy _outerNonGeneric;

		private ISyncPolicy _innerNonGeneric;

		private ISyncPolicy<TResult> _outerGeneric;

		private ISyncPolicy<TResult> _innerGeneric;

		public IsPolicy Outer
		{
			get
			{
				IsPolicy outerGeneric = _outerGeneric;
				return outerGeneric ?? _outerNonGeneric;
			}
		}

		public IsPolicy Inner
		{
			get
			{
				IsPolicy innerGeneric = _innerGeneric;
				return innerGeneric ?? _innerNonGeneric;
			}
		}

		internal override void SetPolicyContext(Context executionContext, out string priorPolicyWrapKey, out string priorPolicyKey)
		{
			priorPolicyWrapKey = executionContext.PolicyWrapKey;
			priorPolicyKey = executionContext.PolicyKey;
			if (executionContext.PolicyWrapKey == null)
			{
				executionContext.PolicyWrapKey = base.PolicyKey;
			}
			base.SetPolicyContext(executionContext, out var _, out var _);
		}

		internal PolicyWrap(Policy outer, ISyncPolicy<TResult> inner)
			: base(outer.ExceptionPredicates, ResultPredicates<TResult>.None)
		{
			_outerNonGeneric = outer;
			_innerGeneric = inner;
		}

		internal PolicyWrap(Policy<TResult> outer, ISyncPolicy inner)
			: base(outer.ExceptionPredicates, outer.ResultPredicates)
		{
			_outerGeneric = outer;
			_innerNonGeneric = inner;
		}

		internal PolicyWrap(Policy<TResult> outer, ISyncPolicy<TResult> inner)
			: base(outer.ExceptionPredicates, outer.ResultPredicates)
		{
			_outerGeneric = outer;
			_innerGeneric = inner;
		}

		protected override TResult Implementation(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
		{
			if (_outerNonGeneric != null)
			{
				if (_innerNonGeneric != null)
				{
					return PolicyWrapEngine.Implementation(action, context, cancellationToken, _outerNonGeneric, _innerNonGeneric);
				}
				if (_innerGeneric != null)
				{
					return PolicyWrapEngine.Implementation(action, context, cancellationToken, _outerNonGeneric, _innerGeneric);
				}
				throw new InvalidOperationException("A PolicyWrap must define an inner policy.");
			}
			if (_outerGeneric != null)
			{
				if (_innerNonGeneric != null)
				{
					return PolicyWrapEngine.Implementation(action, context, cancellationToken, _outerGeneric, _innerNonGeneric);
				}
				if (_innerGeneric != null)
				{
					return PolicyWrapEngine.Implementation(action, context, cancellationToken, _outerGeneric, _innerGeneric);
				}
				throw new InvalidOperationException("A PolicyWrap must define an inner policy.");
			}
			throw new InvalidOperationException("A PolicyWrap must define an outer policy.");
		}
	}
	internal static class PolicyWrapEngine
	{
		internal static TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> func, Context context, CancellationToken cancellationToken, ISyncPolicy<TResult> outerPolicy, ISyncPolicy<TResult> innerPolicy)
		{
			return outerPolicy.Execute((Context ctx, CancellationToken ct) => innerPolicy.Execute(func, ctx, ct), context, cancellationToken);
		}

		internal static TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> func, Context context, CancellationToken cancellationToken, ISyncPolicy<TResult> outerPolicy, ISyncPolicy innerPolicy)
		{
			return outerPolicy.Execute((Context ctx, CancellationToken ct) => innerPolicy.Execute(func, ctx, ct), context, cancellationToken);
		}

		internal static TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> func, Context context, CancellationToken cancellationToken, ISyncPolicy outerPolicy, ISyncPolicy<TResult> innerPolicy)
		{
			return outerPolicy.Execute((Context ctx, CancellationToken ct) => innerPolicy.Execute(func, ctx, ct), context, cancellationToken);
		}

		internal static TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> func, Context context, CancellationToken cancellationToken, ISyncPolicy outerPolicy, ISyncPolicy innerPolicy)
		{
			return outerPolicy.Execute((Context ctx, CancellationToken ct) => innerPolicy.Execute(func, ctx, ct), context, cancellationToken);
		}

		internal static void Implementation(Action<Context, CancellationToken> action, Context context, CancellationToken cancellationToken, ISyncPolicy outerPolicy, ISyncPolicy innerPolicy)
		{
			outerPolicy.Execute(delegate(Context ctx, CancellationToken ct)
			{
				innerPolicy.Execute(action, ctx, ct);
			}, context, cancellationToken);
		}
	}
}
namespace Polly.Utilities
{
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	internal struct EmptyStruct
	{
		internal static readonly EmptyStruct Instance;
	}
	public static class ExceptionExtensions
	{
		public static void RethrowWithOriginalStackTraceIfDiffersFrom(this Exception exceptionPossiblyToThrow, Exception exceptionToCompare)
		{
			if (exceptionPossiblyToThrow != exceptionToCompare)
			{
				ExceptionDispatchInfo.Capture(exceptionPossiblyToThrow).Throw();
			}
		}
	}
	internal static class KeyHelper
	{
		public static string GuidPart()
		{
			return Guid.NewGuid().ToString().Substring(0, 8);
		}
	}
	public static class SystemClock
	{
		public static Action<TimeSpan, CancellationToken> Sleep = delegate(TimeSpan timeSpan, CancellationToken cancellationToken)
		{
			if (cancellationToken.WaitHandle.WaitOne(timeSpan))
			{
				cancellationToken.ThrowIfCancellationRequested();
			}
		};

		public static Func<TimeSpan, CancellationToken, Task> SleepAsync = Task.Delay;

		public static Func<DateTime> UtcNow = () => DateTime.UtcNow;

		public static Func<DateTimeOffset> DateTimeOffsetUtcNow = () => DateTimeOffset.UtcNow;

		public static Action<CancellationTokenSource, TimeSpan> CancelTokenAfter = delegate(CancellationTokenSource tokenSource, TimeSpan timespan)
		{
			tokenSource.CancelAfter(timespan);
		};

		public static void Reset()
		{
			Sleep = delegate(TimeSpan timeSpan, CancellationToken cancellationToken)
			{
				if (cancellationToken.WaitHandle.WaitOne(timeSpan))
				{
					cancellationToken.ThrowIfCancellationRequested();
				}
			};
			SleepAsync = Task.Delay;
			UtcNow = () => DateTime.UtcNow;
			DateTimeOffsetUtcNow = () => DateTimeOffset.UtcNow;
			CancelTokenAfter = delegate(CancellationTokenSource tokenSource, TimeSpan timespan)
			{
				tokenSource.CancelAfter(timespan);
			};
		}
	}
	public static class TaskHelper
	{
		public static Task EmptyTask = Task.FromResult(result: true);
	}
	internal struct TimedLock : IDisposable
	{
		private static readonly TimeSpan LockTimeout = TimeSpan.FromMilliseconds(2147483647.0);

		private object target;

		public static TimedLock Lock(object o)
		{
			return Lock(o, LockTimeout);
		}

		private static TimedLock Lock(object o, TimeSpan timeout)
		{
			TimedLock result = new TimedLock(o);
			if (!Monitor.TryEnter(o, timeout))
			{
				throw new LockTimeoutException();
			}
			return result;
		}

		private TimedLock(object o)
		{
			target = o;
		}

		public void Dispose()
		{
			Monitor.Exit(target);
		}
	}
	internal class LockTimeoutException : Exception
	{
		public LockTimeoutException()
			: base("Timeout waiting for lock")
		{
		}
	}
}
namespace Polly.Timeout
{
	internal static class AsyncTimeoutEngine
	{
		internal static async Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync, bool continueOnCapturedContext)
		{
			cancellationToken.ThrowIfCancellationRequested();
			TimeSpan timeout = timeoutProvider(context);
			TResult result = default(TResult);
			using (CancellationTokenSource timeoutCancellationTokenSource = new CancellationTokenSource())
			{
				using CancellationTokenSource combinedTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, timeoutCancellationTokenSource.Token);
				Task<TResult> actionTask = null;
				CancellationToken token = combinedTokenSource.Token;
				try
				{
					if (timeoutStrategy == TimeoutStrategy.Optimistic)
					{
						SystemClock.CancelTokenAfter(timeoutCancellationTokenSource, timeout);
						result = await action(context, token).ConfigureAwait(continueOnCapturedContext);
						return result;
					}
					Task<TResult> task = timeoutCancellationTokenSource.Token.AsTask<TResult>();
					SystemClock.CancelTokenAfter(timeoutCancellationTokenSource, timeout);
					actionTask = action(context, token);
					result = await (await Task.WhenAny<TResult>(actionTask, task).ConfigureAwait(continueOnCapturedContext)).ConfigureAwait(continueOnCapturedContext);
					return result;
				}
				catch (Exception ex)
				{
					Exception ex2 = ex;
					if (ex2 is OperationCanceledException && timeoutCancellationTokenSource.IsCancellationRequested)
					{
						await onTimeoutAsync(context, timeout, actionTask, ex2).ConfigureAwait(continueOnCapturedContext);
						throw new TimeoutRejectedException("The delegate executed asynchronously through TimeoutPolicy did not complete within the timeout.", ex2);
					}
					ExceptionDispatchInfo.Capture((ex as Exception) ?? throw ex).Throw();
				}
			}
			return result;
		}

		private static Task<TResult> AsTask<TResult>(this CancellationToken cancellationToken)
		{
			TaskCompletionSource<TResult> tcs = new TaskCompletionSource<TResult>();
			IDisposable registration = null;
			registration = cancellationToken.Register(delegate
			{
				tcs.TrySetCanceled();
				registration?.Dispose();
			}, useSynchronizationContext: false);
			return tcs.Task;
		}
	}
	public class AsyncTimeoutPolicy : AsyncPolicy, ITimeoutPolicy, IsPolicy
	{
		private readonly Func<Context, TimeSpan> _timeoutProvider;

		private readonly TimeoutStrategy _timeoutStrategy;

		private readonly Func<Context, TimeSpan, Task, Exception, Task> _onTimeoutAsync;

		internal AsyncTimeoutPolicy(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
		{
			_timeoutProvider = timeoutProvider ?? throw new ArgumentNullException("timeoutProvider");
			_timeoutStrategy = timeoutStrategy;
			_onTimeoutAsync = onTimeoutAsync ?? throw new ArgumentNullException("onTimeoutAsync");
		}

		[DebuggerStepThrough]
		protected override Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return AsyncTimeoutEngine.ImplementationAsync(action, context, cancellationToken, _timeoutProvider, _timeoutStrategy, _onTimeoutAsync, continueOnCapturedContext);
		}
	}
	public class AsyncTimeoutPolicy<TResult> : AsyncPolicy<TResult>, ITimeoutPolicy<TResult>, ITimeoutPolicy, IsPolicy
	{
		private Func<Context, TimeSpan> _timeoutProvider;

		private TimeoutStrategy _timeoutStrategy;

		private Func<Context, TimeSpan, Task, Exception, Task> _onTimeoutAsync;

		internal AsyncTimeoutPolicy(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Func<Context, TimeSpan, Task, Exception, Task> onTimeoutAsync)
			: base((PolicyBuilder<TResult>)null)
		{
			_timeoutProvider = timeoutProvider ?? throw new ArgumentNullException("timeoutProvider");
			_timeoutStrategy = timeoutStrategy;
			_onTimeoutAsync = onTimeoutAsync ?? throw new ArgumentNullException("onTimeoutAsync");
		}

		[DebuggerStepThrough]
		protected override Task<TResult> ImplementationAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return AsyncTimeoutEngine.ImplementationAsync(action, context, cancellationToken, _timeoutProvider, _timeoutStrategy, _onTimeoutAsync, continueOnCapturedContext);
		}
	}
	public interface ITimeoutPolicy : IsPolicy
	{
	}
	public interface ITimeoutPolicy<TResult> : ITimeoutPolicy, IsPolicy
	{
	}
	internal static class TimeoutEngine
	{
		internal static TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken, Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
		{
			cancellationToken.ThrowIfCancellationRequested();
			TimeSpan arg = timeoutProvider(context);
			using CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
			using CancellationTokenSource cancellationTokenSource2 = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken, cancellationTokenSource.Token);
			CancellationToken combinedToken = cancellationTokenSource2.Token;
			Task<TResult> task = null;
			try
			{
				if (timeoutStrategy == TimeoutStrategy.Optimistic)
				{
					SystemClock.CancelTokenAfter(cancellationTokenSource, arg);
					return action(context, combinedToken);
				}
				SystemClock.CancelTokenAfter(cancellationTokenSource, arg);
				task = Task.Run(() => action(context, combinedToken), combinedToken);
				try
				{
					task.Wait(cancellationTokenSource.Token);
				}
				catch (AggregateException ex) when (ex.InnerExceptions.Count == 1)
				{
					ExceptionDispatchInfo.Capture(ex.InnerException).Throw();
				}
				return task.Result;
			}
			catch (Exception ex2)
			{
				if (ex2 is OperationCanceledException && cancellationTokenSource.IsCancellationRequested)
				{
					onTimeout(context, arg, task, ex2);
					throw new TimeoutRejectedException("The delegate executed through TimeoutPolicy did not complete within the timeout.", ex2);
				}
				throw;
			}
		}
	}
	public class TimeoutPolicy : Policy, ITimeoutPolicy, IsPolicy
	{
		private Func<Context, TimeSpan> _timeoutProvider;

		private TimeoutStrategy _timeoutStrategy;

		private Action<Context, TimeSpan, Task, Exception> _onTimeout;

		internal TimeoutPolicy(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
		{
			_timeoutProvider = timeoutProvider ?? throw new ArgumentNullException("timeoutProvider");
			_timeoutStrategy = timeoutStrategy;
			_onTimeout = onTimeout ?? throw new ArgumentNullException("onTimeout");
		}

		[DebuggerStepThrough]
		protected override TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
		{
			return TimeoutEngine.Implementation(action, context, cancellationToken, _timeoutProvider, _timeoutStrategy, _onTimeout);
		}
	}
	public class TimeoutPolicy<TResult> : Policy<TResult>, ITimeoutPolicy<TResult>, ITimeoutPolicy, IsPolicy
	{
		private Func<Context, TimeSpan> _timeoutProvider;

		private TimeoutStrategy _timeoutStrategy;

		private Action<Context, TimeSpan, Task, Exception> _onTimeout;

		internal TimeoutPolicy(Func<Context, TimeSpan> timeoutProvider, TimeoutStrategy timeoutStrategy, Action<Context, TimeSpan, Task, Exception> onTimeout)
			: base((PolicyBuilder<TResult>)null)
		{
			_timeoutProvider = timeoutProvider ?? throw new ArgumentNullException("timeoutProvider");
			_timeoutStrategy = timeoutStrategy;
			_onTimeout = onTimeout ?? throw new ArgumentNullException("onTimeout");
		}

		protected override TResult Implementation(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
		{
			return TimeoutEngine.Implementation(action, context, cancellationToken, _timeoutProvider, _timeoutStrategy, _onTimeout);
		}
	}
	[Serializable]
	public class TimeoutRejectedException : ExecutionRejectedException
	{
		public TimeoutRejectedException()
		{
		}

		public TimeoutRejectedException(string message)
			: base(message)
		{
		}

		public TimeoutRejectedException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected TimeoutRejectedException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
	public enum TimeoutStrategy
	{
		Optimistic,
		Pessimistic
	}
	internal static class TimeoutValidator
	{
		internal static void ValidateSecondsTimeout(int seconds)
		{
			if (seconds <= 0)
			{
				throw new ArgumentOutOfRangeException("seconds");
			}
		}

		internal static void ValidateTimeSpanTimeout(TimeSpan timeout)
		{
			if (timeout <= TimeSpan.Zero && timeout != System.Threading.Timeout.InfiniteTimeSpan)
			{
				throw new ArgumentOutOfRangeException("timeout", timeout, "timeout must be a positive TimeSpan (or Timeout.InfiniteTimeSpan to indicate no timeout)");
			}
		}
	}
}
namespace Polly.Retry
{
	internal static class AsyncRetryEngine
	{
		internal static async Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, ExceptionPredicates shouldRetryExceptionPredicates, ResultPredicates<TResult> shouldRetryResultPredicates, Func<DelegateResult<TResult>, TimeSpan, int, Context, Task> onRetryAsync, int permittedRetryCount = 2147483647, IEnumerable<TimeSpan> sleepDurationsEnumerable = null, Func<int, DelegateResult<TResult>, Context, TimeSpan> sleepDurationProvider = null, bool continueOnCapturedContext = false)
		{
			int tryCount = 0;
			using IEnumerator<TimeSpan> sleepDurationsEnumerator = sleepDurationsEnumerable?.GetEnumerator();
			while (true)
			{
				cancellationToken.ThrowIfCancellationRequested();
				DelegateResult<TResult> delegateResult;
				try
				{
					TResult result = await action(context, cancellationToken).ConfigureAwait(continueOnCapturedContext);
					if (!shouldRetryResultPredicates.AnyMatch(result))
					{
						return result;
					}
					if (tryCount >= permittedRetryCount || (sleepDurationsEnumerable != null && !sleepDurationsEnumerator.MoveNext()))
					{
						return result;
					}
					delegateResult = new DelegateResult<TResult>(result);
				}
				catch (Exception ex)
				{
					Exception ex2 = shouldRetryExceptionPredicates.FirstMatchOrDefault(ex);
					if (ex2 == null)
					{
						throw;
					}
					if (tryCount >= permittedRetryCount || (sleepDurationsEnumerable != null && !sleepDurationsEnumerator.MoveNext()))
					{
						ex2.RethrowWithOriginalStackTraceIfDiffersFrom(ex);
						throw;
					}
					delegateResult = new DelegateResult<TResult>(ex2);
				}
				if (tryCount < 2147483647)
				{
					tryCount++;
				}
				TimeSpan waitDuration = sleepDurationsEnumerator?.Current ?? sleepDurationProvider?.Invoke(tryCount, delegateResult, context) ?? TimeSpan.Zero;
				await onRetryAsync(delegateResult, waitDuration, tryCount, context).ConfigureAwait(continueOnCapturedContext);
				if (waitDuration > TimeSpan.Zero)
				{
					await SystemClock.SleepAsync(waitDuration, cancellationToken).ConfigureAwait(continueOnCapturedContext);
				}
			}
		}
	}
	public class AsyncRetryPolicy : AsyncPolicy, IRetryPolicy, IsPolicy
	{
		private readonly Func<Exception, TimeSpan, int, Context, Task> _onRetryAsync;

		private readonly int _permittedRetryCount;

		private readonly IEnumerable<TimeSpan> _sleepDurationsEnumerable;

		private readonly Func<int, Exception, Context, TimeSpan> _sleepDurationProvider;

		internal AsyncRetryPolicy(PolicyBuilder policyBuilder, Func<Exception, TimeSpan, int, Context, Task> onRetryAsync, int permittedRetryCount = 2147483647, IEnumerable<TimeSpan> sleepDurationsEnumerable = null, Func<int, Exception, Context, TimeSpan> sleepDurationProvider = null)
			: base(policyBuilder)
		{
			_permittedRetryCount = permittedRetryCount;
			_sleepDurationsEnumerable = sleepDurationsEnumerable;
			_sleepDurationProvider = sleepDurationProvider;
			_onRetryAsync = onRetryAsync ?? throw new ArgumentNullException("onRetryAsync");
		}

		[DebuggerStepThrough]
		protected override Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return AsyncRetryEngine.ImplementationAsync(action, context, cancellationToken, base.ExceptionPredicates, ResultPredicates<TResult>.None, (DelegateResult<TResult> outcome, TimeSpan timespan, int retryCount, Context ctx) => _onRetryAsync(outcome.Exception, timespan, retryCount, ctx), _permittedRetryCount, _sleepDurationsEnumerable, (_sleepDurationProvider != null) ? ((Func<int, DelegateResult<TResult>, Context, TimeSpan>)((int retryCount, DelegateResult<TResult> outcome, Context ctx) => _sleepDurationProvider(retryCount, outcome.Exception, ctx))) : null, continueOnCapturedContext);
		}
	}
	public class AsyncRetryPolicy<TResult> : AsyncPolicy<TResult>, IRetryPolicy<TResult>, IRetryPolicy, IsPolicy
	{
		private readonly Func<DelegateResult<TResult>, TimeSpan, int, Context, Task> _onRetryAsync;

		private readonly int _permittedRetryCount;

		private readonly IEnumerable<TimeSpan> _sleepDurationsEnumerable;

		private readonly Func<int, DelegateResult<TResult>, Context, TimeSpan> _sleepDurationProvider;

		internal AsyncRetryPolicy(PolicyBuilder<TResult> policyBuilder, Func<DelegateResult<TResult>, TimeSpan, int, Context, Task> onRetryAsync, int permittedRetryCount = 2147483647, IEnumerable<TimeSpan> sleepDurationsEnumerable = null, Func<int, DelegateResult<TResult>, Context, TimeSpan> sleepDurationProvider = null)
			: base(policyBuilder)
		{
			_permittedRetryCount = permittedRetryCount;
			_sleepDurationsEnumerable = sleepDurationsEnumerable;
			_sleepDurationProvider = sleepDurationProvider;
			_onRetryAsync = onRetryAsync ?? throw new ArgumentNullException("onRetryAsync");
		}

		[DebuggerStepThrough]
		protected override Task<TResult> ImplementationAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return AsyncRetryEngine.ImplementationAsync(action, context, cancellationToken, base.ExceptionPredicates, base.ResultPredicates, _onRetryAsync, _permittedRetryCount, _sleepDurationsEnumerable, _sleepDurationProvider, continueOnCapturedContext);
		}
	}
	public interface IRetryPolicy : IsPolicy
	{
	}
	public interface IRetryPolicy<TResult> : IRetryPolicy, IsPolicy
	{
	}
	internal static class RetryEngine
	{
		internal static TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken, ExceptionPredicates shouldRetryExceptionPredicates, ResultPredicates<TResult> shouldRetryResultPredicates, Action<DelegateResult<TResult>, TimeSpan, int, Context> onRetry, int permittedRetryCount = 2147483647, IEnumerable<TimeSpan> sleepDurationsEnumerable = null, Func<int, DelegateResult<TResult>, Context, TimeSpan> sleepDurationProvider = null)
		{
			int num = 0;
			using IEnumerator<TimeSpan> enumerator = sleepDurationsEnumerable?.GetEnumerator();
			while (true)
			{
				cancellationToken.ThrowIfCancellationRequested();
				DelegateResult<TResult> delegateResult;
				try
				{
					TResult result = action(context, cancellationToken);
					if (!shouldRetryResultPredicates.AnyMatch(result))
					{
						return result;
					}
					if (num >= permittedRetryCount || (sleepDurationsEnumerable != null && !enumerator.MoveNext()))
					{
						return result;
					}
					delegateResult = new DelegateResult<TResult>(result);
				}
				catch (Exception ex)
				{
					Exception ex2 = shouldRetryExceptionPredicates.FirstMatchOrDefault(ex);
					if (ex2 == null)
					{
						throw;
					}
					if (num >= permittedRetryCount || (sleepDurationsEnumerable != null && !enumerator.MoveNext()))
					{
						ex2.RethrowWithOriginalStackTraceIfDiffersFrom(ex);
						throw;
					}
					delegateResult = new DelegateResult<TResult>(ex2);
				}
				if (num < 2147483647)
				{
					num++;
				}
				TimeSpan timeSpan = enumerator?.Current ?? sleepDurationProvider?.Invoke(num, delegateResult, context) ?? TimeSpan.Zero;
				onRetry(delegateResult, timeSpan, num, context);
				if (timeSpan > TimeSpan.Zero)
				{
					SystemClock.Sleep(timeSpan, cancellationToken);
				}
			}
		}
	}
	public class RetryPolicy : Policy, IRetryPolicy, IsPolicy
	{
		private readonly Action<Exception, TimeSpan, int, Context> _onRetry;

		private readonly int _permittedRetryCount;

		private readonly IEnumerable<TimeSpan> _sleepDurationsEnumerable;

		private readonly Func<int, Exception, Context, TimeSpan> _sleepDurationProvider;

		internal RetryPolicy(PolicyBuilder policyBuilder, Action<Exception, TimeSpan, int, Context> onRetry, int permittedRetryCount = 2147483647, IEnumerable<TimeSpan> sleepDurationsEnumerable = null, Func<int, Exception, Context, TimeSpan> sleepDurationProvider = null)
			: base(policyBuilder)
		{
			_permittedRetryCount = permittedRetryCount;
			_sleepDurationsEnumerable = sleepDurationsEnumerable;
			_sleepDurationProvider = sleepDurationProvider;
			_onRetry = onRetry ?? throw new ArgumentNullException("onRetry");
		}

		protected override TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
		{
			return RetryEngine.Implementation(action, context, cancellationToken, base.ExceptionPredicates, ResultPredicates<TResult>.None, delegate(DelegateResult<TResult> outcome, TimeSpan timespan, int retryCount, Context ctx)
			{
				_onRetry(outcome.Exception, timespan, retryCount, ctx);
			}, _permittedRetryCount, _sleepDurationsEnumerable, (_sleepDurationProvider != null) ? ((Func<int, DelegateResult<TResult>, Context, TimeSpan>)((int retryCount, DelegateResult<TResult> outcome, Context ctx) => _sleepDurationProvider(retryCount, outcome.Exception, ctx))) : null);
		}
	}
	public class RetryPolicy<TResult> : Policy<TResult>, IRetryPolicy<TResult>, IRetryPolicy, IsPolicy
	{
		private readonly Action<DelegateResult<TResult>, TimeSpan, int, Context> _onRetry;

		private readonly int _permittedRetryCount;

		private readonly IEnumerable<TimeSpan> _sleepDurationsEnumerable;

		private readonly Func<int, DelegateResult<TResult>, Context, TimeSpan> _sleepDurationProvider;

		internal RetryPolicy(PolicyBuilder<TResult> policyBuilder, Action<DelegateResult<TResult>, TimeSpan, int, Context> onRetry, int permittedRetryCount = 2147483647, IEnumerable<TimeSpan> sleepDurationsEnumerable = null, Func<int, DelegateResult<TResult>, Context, TimeSpan> sleepDurationProvider = null)
			: base(policyBuilder)
		{
			_permittedRetryCount = permittedRetryCount;
			_sleepDurationsEnumerable = sleepDurationsEnumerable;
			_sleepDurationProvider = sleepDurationProvider;
			_onRetry = onRetry ?? throw new ArgumentNullException("onRetry");
		}

		[DebuggerStepThrough]
		protected override TResult Implementation(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
		{
			return RetryEngine.Implementation(action, context, cancellationToken, base.ExceptionPredicates, base.ResultPredicates, _onRetry, _permittedRetryCount, _sleepDurationsEnumerable, _sleepDurationProvider);
		}
	}
}
namespace Polly.Registry
{
	public interface IConcurrentPolicyRegistry<TKey> : IPolicyRegistry<TKey>, IReadOnlyPolicyRegistry<TKey>, IEnumerable<KeyValuePair<TKey, IsPolicy>>, IEnumerable
	{
		bool TryAdd<TPolicy>(TKey key, TPolicy policy) where TPolicy : IsPolicy;

		bool TryRemove<TPolicy>(TKey key, out TPolicy policy) where TPolicy : IsPolicy;

		bool TryUpdate<TPolicy>(TKey key, TPolicy newPolicy, TPolicy comparisonPolicy) where TPolicy : IsPolicy;

		TPolicy GetOrAdd<TPolicy>(TKey key, Func<TKey, TPolicy> policyFactory) where TPolicy : IsPolicy;

		TPolicy GetOrAdd<TPolicy>(TKey key, TPolicy policy) where TPolicy : IsPolicy;

		TPolicy AddOrUpdate<TPolicy>(TKey key, Func<TKey, TPolicy> addPolicyFactory, Func<TKey, TPolicy, TPolicy> updatePolicyFactory) where TPolicy : IsPolicy;

		TPolicy AddOrUpdate<TPolicy>(TKey key, TPolicy addPolicy, Func<TKey, TPolicy, TPolicy> updatePolicyFactory) where TPolicy : IsPolicy;
	}
	public interface IPolicyRegistry<TKey> : IReadOnlyPolicyRegistry<TKey>, IEnumerable<KeyValuePair<TKey, IsPolicy>>, IEnumerable
	{
		new IsPolicy this[TKey key] { get; set; }

		void Add<TPolicy>(TKey key, TPolicy policy) where TPolicy : IsPolicy;

		bool Remove(TKey key);

		void Clear();
	}
	public interface IReadOnlyPolicyRegistry<TKey> : IEnumerable<KeyValuePair<TKey, IsPolicy>>, IEnumerable
	{
		IsPolicy this[TKey key] { get; }

		int Count { get; }

		TPolicy Get<TPolicy>(TKey key) where TPolicy : IsPolicy;

		bool TryGet<TPolicy>(TKey key, out TPolicy policy) where TPolicy : IsPolicy;

		bool ContainsKey(TKey key);
	}
	public class PolicyRegistry : IConcurrentPolicyRegistry<string>, IPolicyRegistry<string>, IReadOnlyPolicyRegistry<string>, IEnumerable<KeyValuePair<string, IsPolicy>>, IEnumerable
	{
		private readonly IDictionary<string, IsPolicy> _registry = new ConcurrentDictionary<string, IsPolicy>();

		public int Count => _registry.Count;

		public IsPolicy this[string key]
		{
			get
			{
				return _registry[key];
			}
			set
			{
				_registry[key] = value;
			}
		}

		public PolicyRegistry()
		{
		}

		internal PolicyRegistry(IDictionary<string, IsPolicy> registry)
		{
			_registry = registry ?? throw new NullReferenceException("registry");
		}

		private ConcurrentDictionary<string, IsPolicy> ThrowIfNotConcurrentImplementation()
		{
			if (_registry is ConcurrentDictionary<string, IsPolicy> result)
			{
				return result;
			}
			throw new InvalidOperationException("This PolicyRegistry is not configured for concurrent operations. This exception should never be thrown in production code as the only public constructors create PolicyRegistry instances of the correct form.");
		}

		public void Add<TPolicy>(string key, TPolicy policy) where TPolicy : IsPolicy
		{
			_registry.Add(key, policy);
		}

		public bool TryAdd<TPolicy>(string key, TPolicy policy) where TPolicy : IsPolicy
		{
			return ThrowIfNotConcurrentImplementation().TryAdd(key, policy);
		}

		public TPolicy Get<TPolicy>(string key) where TPolicy : IsPolicy
		{
			return (TPolicy)_registry[key];
		}

		public bool TryGet<TPolicy>(string key, out TPolicy policy) where TPolicy : IsPolicy
		{
			IsPolicy value;
			bool flag = _registry.TryGetValue(key, out value);
			policy = (flag ? ((TPolicy)value) : default(TPolicy));
			return flag;
		}

		public void Clear()
		{
			_registry.Clear();
		}

		public bool ContainsKey(string key)
		{
			return _registry.ContainsKey(key);
		}

		public bool Remove(string key)
		{
			return _registry.Remove(key);
		}

		public bool TryRemove<TPolicy>(string key, out TPolicy policy) where TPolicy : IsPolicy
		{
			IsPolicy value;
			bool flag = ThrowIfNotConcurrentImplementation().TryRemove(key, out value);
			policy = (flag ? ((TPolicy)value) : default(TPolicy));
			return flag;
		}

		public bool TryUpdate<TPolicy>(string key, TPolicy newPolicy, TPolicy comparisonPolicy) where TPolicy : IsPolicy
		{
			return ThrowIfNotConcurrentImplementation().TryUpdate(key, newPolicy, comparisonPolicy);
		}

		public TPolicy GetOrAdd<TPolicy>(string key, Func<string, TPolicy> policyFactory) where TPolicy : IsPolicy
		{
			return (TPolicy)ThrowIfNotConcurrentImplementation().GetOrAdd(key, (string k) => policyFactory(k));
		}

		public TPolicy GetOrAdd<TPolicy>(string key, TPolicy policy) where TPolicy : IsPolicy
		{
			return (TPolicy)ThrowIfNotConcurrentImplementation().GetOrAdd(key, policy);
		}

		public TPolicy AddOrUpdate<TPolicy>(string key, Func<string, TPolicy> addPolicyFactory, Func<string, TPolicy, TPolicy> updatePolicyFactory) where TPolicy : IsPolicy
		{
			return (TPolicy)ThrowIfNotConcurrentImplementation().AddOrUpdate(key, (string k) => addPolicyFactory(k), (string k, IsPolicy e) => updatePolicyFactory(k, (TPolicy)e));
		}

		public TPolicy AddOrUpdate<TPolicy>(string key, TPolicy addPolicy, Func<string, TPolicy, TPolicy> updatePolicyFactory) where TPolicy : IsPolicy
		{
			return (TPolicy)ThrowIfNotConcurrentImplementation().AddOrUpdate(key, addPolicy, (string k, IsPolicy e) => updatePolicyFactory(k, (TPolicy)e));
		}

		public IEnumerator<KeyValuePair<string, IsPolicy>> GetEnumerator()
		{
			return _registry.GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
namespace Polly.NoOp
{
	public class AsyncNoOpPolicy : AsyncPolicy, INoOpPolicy, IsPolicy
	{
		internal AsyncNoOpPolicy()
		{
		}

		[DebuggerStepThrough]
		protected override Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return NoOpEngine.ImplementationAsync(action, context, cancellationToken, continueOnCapturedContext);
		}
	}
	public class AsyncNoOpPolicy<TResult> : AsyncPolicy<TResult>, INoOpPolicy<TResult>, INoOpPolicy, IsPolicy
	{
		internal AsyncNoOpPolicy()
			: base((PolicyBuilder<TResult>)null)
		{
		}

		[DebuggerStepThrough]
		protected override Task<TResult> ImplementationAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return NoOpEngine.ImplementationAsync(action, context, cancellationToken, continueOnCapturedContext);
		}
	}
	public interface INoOpPolicy : IsPolicy
	{
	}
	public interface INoOpPolicy<TResult> : INoOpPolicy, IsPolicy
	{
	}
	internal static class NoOpEngine
	{
		internal static TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
		{
			return action(context, cancellationToken);
		}

		internal static async Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return await action(context, cancellationToken).ConfigureAwait(continueOnCapturedContext);
		}
	}
	public class NoOpPolicy : Policy, INoOpPolicy, IsPolicy
	{
		internal NoOpPolicy()
		{
		}

		[DebuggerStepThrough]
		protected override TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
		{
			return NoOpEngine.Implementation(action, context, cancellationToken);
		}
	}
	public class NoOpPolicy<TResult> : Policy<TResult>, INoOpPolicy<TResult>, INoOpPolicy, IsPolicy
	{
		internal NoOpPolicy()
			: base((PolicyBuilder<TResult>)null)
		{
		}

		[DebuggerStepThrough]
		protected override TResult Implementation(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
		{
			return NoOpEngine.Implementation(action, context, cancellationToken);
		}
	}
}
namespace Polly.Fallback
{
	internal class AsyncFallbackEngine
	{
		internal static async Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, ExceptionPredicates shouldHandleExceptionPredicates, ResultPredicates<TResult> shouldHandleResultPredicates, Func<DelegateResult<TResult>, Context, Task> onFallbackAsync, Func<DelegateResult<TResult>, Context, CancellationToken, Task<TResult>> fallbackAction, bool continueOnCapturedContext)
		{
			DelegateResult<TResult> delegateOutcome;
			try
			{
				cancellationToken.ThrowIfCancellationRequested();
				TResult result = await action(context, cancellationToken).ConfigureAwait(continueOnCapturedContext);
				if (!shouldHandleResultPredicates.AnyMatch(result))
				{
					return result;
				}
				delegateOutcome = new DelegateResult<TResult>(result);
			}
			catch (Exception ex)
			{
				Exception ex2 = shouldHandleExceptionPredicates.FirstMatchOrDefault(ex);
				if (ex2 == null)
				{
					throw;
				}
				delegateOutcome = new DelegateResult<TResult>(ex2);
			}
			await onFallbackAsync(delegateOutcome, context).ConfigureAwait(continueOnCapturedContext);
			return await fallbackAction(delegateOutcome, context, cancellationToken).ConfigureAwait(continueOnCapturedContext);
		}
	}
	public class AsyncFallbackPolicy : AsyncPolicy, IFallbackPolicy, IsPolicy
	{
		private Func<Exception, Context, Task> _onFallbackAsync;

		private Func<Exception, Context, CancellationToken, Task> _fallbackAction;

		internal AsyncFallbackPolicy(PolicyBuilder policyBuilder, Func<Exception, Context, Task> onFallbackAsync, Func<Exception, Context, CancellationToken, Task> fallbackAction)
			: base(policyBuilder)
		{
			_onFallbackAsync = onFallbackAsync ?? throw new ArgumentNullException("onFallbackAsync");
			_fallbackAction = fallbackAction ?? throw new ArgumentNullException("fallbackAction");
		}

		protected override Task ImplementationAsync(Func<Context, CancellationToken, Task> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return AsyncFallbackEngine.ImplementationAsync(async delegate(Context ctx, CancellationToken ct)
			{
				await action(ctx, ct).ConfigureAwait(continueOnCapturedContext);
				return EmptyStruct.Instance;
			}, context, cancellationToken, base.ExceptionPredicates, ResultPredicates<EmptyStruct>.None, (DelegateResult<EmptyStruct> outcome, Context ctx) => _onFallbackAsync(outcome.Exception, ctx), async delegate(DelegateResult<EmptyStruct> outcome, Context ctx, CancellationToken ct)
			{
				await _fallbackAction(outcome.Exception, ctx, ct).ConfigureAwait(continueOnCapturedContext);
				return EmptyStruct.Instance;
			}, continueOnCapturedContext);
		}

		protected override Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			throw new InvalidOperationException("You have executed the generic .Execute<TResult> method on a non-generic FallbackPolicy.  A non-generic FallbackPolicy only defines a fallback action which returns void; it can never return a substitute TResult value.  To use FallbackPolicy to provide fallback TResult values you must define a generic fallback policy FallbackPolicy<TResult>.  For example, define the policy as Policy<TResult>.Handle<Whatever>.Fallback<TResult>(/* some TResult value or Func<..., TResult> */);");
		}
	}
	public class AsyncFallbackPolicy<TResult> : AsyncPolicy<TResult>, IFallbackPolicy<TResult>, IFallbackPolicy, IsPolicy
	{
		private Func<DelegateResult<TResult>, Context, Task> _onFallbackAsync;

		private Func<DelegateResult<TResult>, Context, CancellationToken, Task<TResult>> _fallbackAction;

		internal AsyncFallbackPolicy(PolicyBuilder<TResult> policyBuilder, Func<DelegateResult<TResult>, Context, Task> onFallbackAsync, Func<DelegateResult<TResult>, Context, CancellationToken, Task<TResult>> fallbackAction)
			: base(policyBuilder)
		{
			_onFallbackAsync = onFallbackAsync ?? throw new ArgumentNullException("onFallbackAsync");
			_fallbackAction = fallbackAction ?? throw new ArgumentNullException("fallbackAction");
		}

		[DebuggerStepThrough]
		protected override Task<TResult> ImplementationAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return AsyncFallbackEngine.ImplementationAsync(action, context, cancellationToken, base.ExceptionPredicates, base.ResultPredicates, _onFallbackAsync, _fallbackAction, continueOnCapturedContext);
		}
	}
	internal static class FallbackEngine
	{
		internal static TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken, ExceptionPredicates shouldHandleExceptionPredicates, ResultPredicates<TResult> shouldHandleResultPredicates, Action<DelegateResult<TResult>, Context> onFallback, Func<DelegateResult<TResult>, Context, CancellationToken, TResult> fallbackAction)
		{
			DelegateResult<TResult> arg;
			try
			{
				cancellationToken.ThrowIfCancellationRequested();
				TResult result = action(context, cancellationToken);
				if (!shouldHandleResultPredicates.AnyMatch(result))
				{
					return result;
				}
				arg = new DelegateResult<TResult>(result);
			}
			catch (Exception ex)
			{
				Exception ex2 = shouldHandleExceptionPredicates.FirstMatchOrDefault(ex);
				if (ex2 == null)
				{
					throw;
				}
				arg = new DelegateResult<TResult>(ex2);
			}
			onFallback(arg, context);
			return fallbackAction(arg, context, cancellationToken);
		}
	}
	public class FallbackPolicy : Policy, IFallbackPolicy, IsPolicy
	{
		private Action<Exception, Context> _onFallback;

		private Action<Exception, Context, CancellationToken> _fallbackAction;

		internal FallbackPolicy(PolicyBuilder policyBuilder, Action<Exception, Context> onFallback, Action<Exception, Context, CancellationToken> fallbackAction)
			: base(policyBuilder)
		{
			_onFallback = onFallback ?? throw new ArgumentNullException("onFallback");
			_fallbackAction = fallbackAction ?? throw new ArgumentNullException("fallbackAction");
		}

		[DebuggerStepThrough]
		protected override void Implementation(Action<Context, CancellationToken> action, Context context, CancellationToken cancellationToken)
		{
			FallbackEngine.Implementation(delegate(Context ctx, CancellationToken token)
			{
				action(ctx, token);
				return EmptyStruct.Instance;
			}, context, cancellationToken, base.ExceptionPredicates, ResultPredicates<EmptyStruct>.None, delegate(DelegateResult<EmptyStruct> outcome, Context ctx)
			{
				_onFallback(outcome.Exception, ctx);
			}, delegate(DelegateResult<EmptyStruct> outcome, Context ctx, CancellationToken ct)
			{
				_fallbackAction(outcome.Exception, ctx, ct);
				return EmptyStruct.Instance;
			});
		}

		protected override TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
		{
			throw new InvalidOperationException("You have executed the generic .Execute<TResult> method on a non-generic FallbackPolicy.  A non-generic FallbackPolicy only defines a fallback action which returns void; it can never return a substitute TResult value.  To use FallbackPolicy to provide fallback TResult values you must define a generic fallback policy FallbackPolicy<TResult>.  For example, define the policy as Policy<TResult>.Handle<Whatever>.Fallback<TResult>(/* some TResult value or Func<..., TResult> */);");
		}
	}
	public class FallbackPolicy<TResult> : Policy<TResult>, IFallbackPolicy<TResult>, IFallbackPolicy, IsPolicy
	{
		private Action<DelegateResult<TResult>, Context> _onFallback;

		private Func<DelegateResult<TResult>, Context, CancellationToken, TResult> _fallbackAction;

		internal FallbackPolicy(PolicyBuilder<TResult> policyBuilder, Action<DelegateResult<TResult>, Context> onFallback, Func<DelegateResult<TResult>, Context, CancellationToken, TResult> fallbackAction)
			: base(policyBuilder)
		{
			_onFallback = onFallback ?? throw new ArgumentNullException("onFallback");
			_fallbackAction = fallbackAction ?? throw new ArgumentNullException("fallbackAction");
		}

		[DebuggerStepThrough]
		protected override TResult Implementation(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
		{
			return FallbackEngine.Implementation(action, context, cancellationToken, base.ExceptionPredicates, base.ResultPredicates, _onFallback, _fallbackAction);
		}
	}
	public interface IFallbackPolicy : IsPolicy
	{
	}
	public interface IFallbackPolicy<TResult> : IFallbackPolicy, IsPolicy
	{
	}
}
namespace Polly.CircuitBreaker
{
	internal class AdvancedCircuitController<TResult> : CircuitStateController<TResult>
	{
		private const short NumberOfWindows = 10;

		internal static readonly long ResolutionOfCircuitTimer = TimeSpan.FromMilliseconds(20.0).Ticks;

		private readonly IHealthMetrics _metrics;

		private readonly double _failureThreshold;

		private readonly int _minimumThroughput;

		public AdvancedCircuitController(double failureThreshold, TimeSpan samplingDuration, int minimumThroughput, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, CircuitState, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
			: base(durationOfBreak, onBreak, onReset, onHalfOpen)
		{
			IHealthMetrics metrics;
			if (samplingDuration.Ticks >= ResolutionOfCircuitTimer * 10)
			{
				IHealthMetrics healthMetrics = new RollingHealthMetrics(samplingDuration, 10);
				metrics = healthMetrics;
			}
			else
			{
				IHealthMetrics healthMetrics = new SingleHealthMetrics(samplingDuration);
				metrics = healthMetrics;
			}
			_metrics = metrics;
			_failureThreshold = failureThreshold;
			_minimumThroughput = minimumThroughput;
		}

		public override void OnCircuitReset(Context context)
		{
			using (TimedLock.Lock(_lock))
			{
				_metrics?.Reset_NeedsLock();
				ResetInternal_NeedsLock(context);
			}
		}

		public override void OnActionSuccess(Context context)
		{
			using (TimedLock.Lock(_lock))
			{
				switch (_circuitState)
				{
				case CircuitState.HalfOpen:
					OnCircuitReset(context);
					break;
				default:
					throw new InvalidOperationException("Unhandled CircuitState.");
				case CircuitState.Closed:
				case CircuitState.Open:
				case CircuitState.Isolated:
					break;
				}
				_metrics.IncrementSuccess_NeedsLock();
			}
		}

		public override void OnActionFailure(DelegateResult<TResult> outcome, Context context)
		{
			using (TimedLock.Lock(_lock))
			{
				_lastOutcome = outcome;
				switch (_circuitState)
				{
				case CircuitState.HalfOpen:
					Break_NeedsLock(context);
					break;
				case CircuitState.Closed:
				{
					_metrics.IncrementFailure_NeedsLock();
					HealthCount healthCount_NeedsLock = _metrics.GetHealthCount_NeedsLock();
					int total = healthCount_NeedsLock.Total;
					if (total >= _minimumThroughput && (double)healthCount_NeedsLock.Failures / (double)total >= _failureThreshold)
					{
						Break_NeedsLock(context);
					}
					break;
				}
				case CircuitState.Open:
				case CircuitState.Isolated:
					_metrics.IncrementFailure_NeedsLock();
					break;
				default:
					throw new InvalidOperationException("Unhandled CircuitState.");
				}
			}
		}
	}
	internal class AsyncCircuitBreakerEngine
	{
		internal static async Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext, ExceptionPredicates shouldHandleExceptionPredicates, ResultPredicates<TResult> shouldHandleResultPredicates, ICircuitController<TResult> breakerController)
		{
			cancellationToken.ThrowIfCancellationRequested();
			breakerController.OnActionPreExecute();
			try
			{
				TResult result = await action(context, cancellationToken).ConfigureAwait(continueOnCapturedContext);
				if (shouldHandleResultPredicates.AnyMatch(result))
				{
					breakerController.OnActionFailure(new DelegateResult<TResult>(result), context);
				}
				else
				{
					breakerController.OnActionSuccess(context);
				}
				return result;
			}
			catch (Exception ex)
			{
				Exception ex2 = shouldHandleExceptionPredicates.FirstMatchOrDefault(ex);
				if (ex2 == null)
				{
					throw;
				}
				breakerController.OnActionFailure(new DelegateResult<TResult>(ex2), context);
				ex2.RethrowWithOriginalStackTraceIfDiffersFrom(ex);
				throw;
			}
		}
	}
	public class AsyncCircuitBreakerPolicy : AsyncPolicy, ICircuitBreakerPolicy, IsPolicy
	{
		internal readonly ICircuitController<EmptyStruct> _breakerController;

		public CircuitState CircuitState => _breakerController.CircuitState;

		public Exception LastException => _breakerController.LastException;

		internal AsyncCircuitBreakerPolicy(PolicyBuilder policyBuilder, ICircuitController<EmptyStruct> breakerController)
			: base(policyBuilder)
		{
			_breakerController = breakerController;
		}

		public void Isolate()
		{
			_breakerController.Isolate();
		}

		public void Reset()
		{
			_breakerController.Reset();
		}

		protected override async Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			TResult result = default(TResult);
			await AsyncCircuitBreakerEngine.ImplementationAsync(async delegate(Context ctx, CancellationToken ct)
			{
				result = await action(ctx, ct).ConfigureAwait(continueOnCapturedContext);
				return EmptyStruct.Instance;
			}, context, cancellationToken, continueOnCapturedContext, base.ExceptionPredicates, ResultPredicates<EmptyStruct>.None, _breakerController).ConfigureAwait(continueOnCapturedContext);
			return result;
		}
	}
	public class AsyncCircuitBreakerPolicy<TResult> : AsyncPolicy<TResult>, ICircuitBreakerPolicy<TResult>, ICircuitBreakerPolicy, IsPolicy
	{
		internal readonly ICircuitController<TResult> _breakerController;

		public CircuitState CircuitState => _breakerController.CircuitState;

		public Exception LastException => _breakerController.LastException;

		public TResult LastHandledResult => _breakerController.LastHandledResult;

		internal AsyncCircuitBreakerPolicy(PolicyBuilder<TResult> policyBuilder, ICircuitController<TResult> breakerController)
			: base(policyBuilder)
		{
			_breakerController = breakerController;
		}

		public void Isolate()
		{
			_breakerController.Isolate();
		}

		public void Reset()
		{
			_breakerController.Reset();
		}

		[DebuggerStepThrough]
		protected override Task<TResult> ImplementationAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return AsyncCircuitBreakerEngine.ImplementationAsync(action, context, cancellationToken, continueOnCapturedContext, base.ExceptionPredicates, base.ResultPredicates, _breakerController);
		}
	}
	[Serializable]
	public class BrokenCircuitException : ExecutionRejectedException
	{
		public BrokenCircuitException()
		{
		}

		public BrokenCircuitException(string message)
			: base(message)
		{
		}

		public BrokenCircuitException(string message, Exception inner)
			: base(message, inner)
		{
		}

		protected BrokenCircuitException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
	[Serializable]
	public class BrokenCircuitException<TResult> : BrokenCircuitException
	{
		private readonly TResult result;

		public TResult Result => result;

		public BrokenCircuitException(TResult result)
		{
			this.result = result;
		}

		public BrokenCircuitException(string message, TResult result)
			: base(message)
		{
			this.result = result;
		}

		protected BrokenCircuitException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
	internal class CircuitBreakerEngine
	{
		internal static TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken, ExceptionPredicates shouldHandleExceptionPredicates, ResultPredicates<TResult> shouldHandleResultPredicates, ICircuitController<TResult> breakerController)
		{
			cancellationToken.ThrowIfCancellationRequested();
			breakerController.OnActionPreExecute();
			try
			{
				TResult result = action(context, cancellationToken);
				if (shouldHandleResultPredicates.AnyMatch(result))
				{
					breakerController.OnActionFailure(new DelegateResult<TResult>(result), context);
				}
				else
				{
					breakerController.OnActionSuccess(context);
				}
				return result;
			}
			catch (Exception ex)
			{
				Exception ex2 = shouldHandleExceptionPredicates.FirstMatchOrDefault(ex);
				if (ex2 == null)
				{
					throw;
				}
				breakerController.OnActionFailure(new DelegateResult<TResult>(ex2), context);
				if (ex2 != ex)
				{
					ExceptionDispatchInfo.Capture(ex2).Throw();
				}
				throw;
			}
		}
	}
	public class CircuitBreakerPolicy : Policy, ICircuitBreakerPolicy, IsPolicy
	{
		internal readonly ICircuitController<EmptyStruct> _breakerController;

		public CircuitState CircuitState => _breakerController.CircuitState;

		public Exception LastException => _breakerController.LastException;

		internal CircuitBreakerPolicy(PolicyBuilder policyBuilder, ICircuitController<EmptyStruct> breakerController)
			: base(policyBuilder)
		{
			_breakerController = breakerController;
		}

		public void Isolate()
		{
			_breakerController.Isolate();
		}

		public void Reset()
		{
			_breakerController.Reset();
		}

		[DebuggerStepThrough]
		protected override TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
		{
			TResult result = default(TResult);
			CircuitBreakerEngine.Implementation(delegate(Context ctx, CancellationToken ct)
			{
				result = action(ctx, ct);
				return EmptyStruct.Instance;
			}, context, cancellationToken, base.ExceptionPredicates, ResultPredicates<EmptyStruct>.None, _breakerController);
			return result;
		}
	}
	public class CircuitBreakerPolicy<TResult> : Policy<TResult>, ICircuitBreakerPolicy<TResult>, ICircuitBreakerPolicy, IsPolicy
	{
		internal readonly ICircuitController<TResult> _breakerController;

		public CircuitState CircuitState => _breakerController.CircuitState;

		public Exception LastException => _breakerController.LastException;

		public TResult LastHandledResult => _breakerController.LastHandledResult;

		internal CircuitBreakerPolicy(PolicyBuilder<TResult> policyBuilder, ICircuitController<TResult> breakerController)
			: base(policyBuilder)
		{
			_breakerController = breakerController;
		}

		public void Isolate()
		{
			_breakerController.Isolate();
		}

		public void Reset()
		{
			_breakerController.Reset();
		}

		[DebuggerStepThrough]
		protected override TResult Implementation(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
		{
			return CircuitBreakerEngine.Implementation(action, context, cancellationToken, base.ExceptionPredicates, base.ResultPredicates, _breakerController);
		}
	}
	public enum CircuitState
	{
		Closed,
		Open,
		HalfOpen,
		Isolated
	}
	internal abstract class CircuitStateController<TResult> : ICircuitController<TResult>
	{
		protected readonly TimeSpan _durationOfBreak;

		protected long _blockedTill;

		protected CircuitState _circuitState;

		protected DelegateResult<TResult> _lastOutcome;

		protected readonly Action<DelegateResult<TResult>, CircuitState, TimeSpan, Context> _onBreak;

		protected readonly Action<Context> _onReset;

		protected readonly Action _onHalfOpen;

		protected readonly object _lock = new object();

		public CircuitState CircuitState
		{
			get
			{
				if (_circuitState != CircuitState.Open)
				{
					return _circuitState;
				}
				using (TimedLock.Lock(_lock))
				{
					if (_circuitState == CircuitState.Open && !IsInAutomatedBreak_NeedsLock)
					{
						_circuitState = CircuitState.HalfOpen;
						_onHalfOpen();
					}
					return _circuitState;
				}
			}
		}

		public Exception LastException
		{
			get
			{
				using (TimedLock.Lock(_lock))
				{
					return _lastOutcome?.Exception;
				}
			}
		}

		public TResult LastHandledResult
		{
			get
			{
				using (TimedLock.Lock(_lock))
				{
					return (_lastOutcome != null) ? _lastOutcome.Result : default(TResult);
				}
			}
		}

		protected bool IsInAutomatedBreak_NeedsLock => SystemClock.UtcNow().Ticks < _blockedTill;

		protected CircuitStateController(TimeSpan durationOfBreak, Action<DelegateResult<TResult>, CircuitState, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
		{
			_durationOfBreak = durationOfBreak;
			_onBreak = onBreak;
			_onReset = onReset;
			_onHalfOpen = onHalfOpen;
			_circuitState = CircuitState.Closed;
			Reset();
		}

		public void Isolate()
		{
			using (TimedLock.Lock(_lock))
			{
				_lastOutcome = new DelegateResult<TResult>(new IsolatedCircuitException("The circuit is manually held open and is not allowing calls."));
				BreakFor_NeedsLock(TimeSpan.MaxValue, Context.None());
				_circuitState = CircuitState.Isolated;
			}
		}

		protected void Break_NeedsLock(Context context)
		{
			BreakFor_NeedsLock(_durationOfBreak, context);
		}

		private void BreakFor_NeedsLock(TimeSpan durationOfBreak, Context context)
		{
			long ticks;
			if (!(durationOfBreak > DateTime.MaxValue - SystemClock.UtcNow()))
			{
				ticks = (SystemClock.UtcNow() + durationOfBreak).Ticks;
			}
			else
			{
				DateTime maxValue = DateTime.MaxValue;
				ticks = maxValue.Ticks;
			}
			_blockedTill = ticks;
			CircuitState circuitState = _circuitState;
			_circuitState = CircuitState.Open;
			_onBreak(_lastOutcome, circuitState, durationOfBreak, context);
		}

		public void Reset()
		{
			OnCircuitReset(Context.None());
		}

		protected void ResetInternal_NeedsLock(Context context)
		{
			DateTime minValue = DateTime.MinValue;
			_blockedTill = minValue.Ticks;
			_lastOutcome = null;
			CircuitState circuitState = _circuitState;
			_circuitState = CircuitState.Closed;
			if (circuitState != CircuitState.Closed)
			{
				_onReset(context);
			}
		}

		protected bool PermitHalfOpenCircuitTest()
		{
			long blockedTill = _blockedTill;
			if (SystemClock.UtcNow().Ticks >= blockedTill)
			{
				ref long blockedTill2 = ref _blockedTill;
				long ticks = SystemClock.UtcNow().Ticks;
				TimeSpan durationOfBreak = _durationOfBreak;
				return Interlocked.CompareExchange(ref blockedTill2, ticks + durationOfBreak.Ticks, blockedTill) == blockedTill;
			}
			return false;
		}

		private BrokenCircuitException GetBreakingException()
		{
			DelegateResult<TResult> lastOutcome = _lastOutcome;
			if (lastOutcome == null)
			{
				return new BrokenCircuitException("The circuit is now open and is not allowing calls.");
			}
			if (lastOutcome.Exception != null)
			{
				return new BrokenCircuitException("The circuit is now open and is not allowing calls.", lastOutcome.Exception);
			}
			return new BrokenCircuitException<TResult>("The circuit is now open and is not allowing calls.", lastOutcome.Result);
		}

		public void OnActionPreExecute()
		{
			switch (CircuitState)
			{
			case CircuitState.HalfOpen:
				if (!PermitHalfOpenCircuitTest())
				{
					throw GetBreakingException();
				}
				break;
			case CircuitState.Open:
				throw GetBreakingException();
			case CircuitState.Isolated:
				throw new IsolatedCircuitException("The circuit is manually held open and is not allowing calls.");
			default:
				throw new InvalidOperationException("Unhandled CircuitState.");
			case CircuitState.Closed:
				break;
			}
		}

		public abstract void OnActionSuccess(Context context);

		public abstract void OnActionFailure(DelegateResult<TResult> outcome, Context context);

		public abstract void OnCircuitReset(Context context);
	}
	internal class ConsecutiveCountCircuitController<TResult> : CircuitStateController<TResult>
	{
		private readonly int _exceptionsAllowedBeforeBreaking;

		private int _consecutiveFailureCount;

		public ConsecutiveCountCircuitController(int exceptionsAllowedBeforeBreaking, TimeSpan durationOfBreak, Action<DelegateResult<TResult>, CircuitState, TimeSpan, Context> onBreak, Action<Context> onReset, Action onHalfOpen)
			: base(durationOfBreak, onBreak, onReset, onHalfOpen)
		{
			_exceptionsAllowedBeforeBreaking = exceptionsAllowedBeforeBreaking;
		}

		public override void OnCircuitReset(Context context)
		{
			using (TimedLock.Lock(_lock))
			{
				_consecutiveFailureCount = 0;
				ResetInternal_NeedsLock(context);
			}
		}

		public override void OnActionSuccess(Context context)
		{
			using (TimedLock.Lock(_lock))
			{
				switch (_circuitState)
				{
				case CircuitState.HalfOpen:
					OnCircuitReset(context);
					break;
				case CircuitState.Closed:
					_consecutiveFailureCount = 0;
					break;
				default:
					throw new InvalidOperationException("Unhandled CircuitState.");
				case CircuitState.Open:
				case CircuitState.Isolated:
					break;
				}
			}
		}

		public override void OnActionFailure(DelegateResult<TResult> outcome, Context context)
		{
			using (TimedLock.Lock(_lock))
			{
				_lastOutcome = outcome;
				switch (_circuitState)
				{
				case CircuitState.HalfOpen:
					Break_NeedsLock(context);
					break;
				case CircuitState.Closed:
					_consecutiveFailureCount++;
					if (_consecutiveFailureCount >= _exceptionsAllowedBeforeBreaking)
					{
						Break_NeedsLock(context);
					}
					break;
				default:
					throw new InvalidOperationException("Unhandled CircuitState.");
				case CircuitState.Open:
				case CircuitState.Isolated:
					break;
				}
			}
		}
	}
	internal class HealthCount
	{
		public int Successes { get; set; }

		public int Failures { get; set; }

		public int Total => Successes + Failures;

		public long StartedAt { get; set; }
	}
	public interface ICircuitBreakerPolicy : IsPolicy
	{
		CircuitState CircuitState { get; }

		Exception LastException { get; }

		void Isolate();

		void Reset();
	}
	public interface ICircuitBreakerPolicy<TResult> : ICircuitBreakerPolicy, IsPolicy
	{
		TResult LastHandledResult { get; }
	}
	internal interface ICircuitController<TResult>
	{
		CircuitState CircuitState { get; }

		Exception LastException { get; }

		TResult LastHandledResult { get; }

		void Isolate();

		void Reset();

		void OnCircuitReset(Context context);

		void OnActionPreExecute();

		void OnActionSuccess(Context context);

		void OnActionFailure(DelegateResult<TResult> outcome, Context context);
	}
	internal interface IHealthMetrics
	{
		void IncrementSuccess_NeedsLock();

		void IncrementFailure_NeedsLock();

		void Reset_NeedsLock();

		HealthCount GetHealthCount_NeedsLock();
	}
	[Serializable]
	public class IsolatedCircuitException : BrokenCircuitException
	{
		public IsolatedCircuitException(string message)
			: base(message)
		{
		}

		protected IsolatedCircuitException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
	internal class RollingHealthMetrics : IHealthMetrics
	{
		private readonly long _samplingDuration;

		private readonly long _windowDuration;

		private readonly Queue<HealthCount> _windows;

		private HealthCount _currentWindow;

		public RollingHealthMetrics(TimeSpan samplingDuration, short numberOfWindows)
		{
			_samplingDuration = samplingDuration.Ticks;
			_windowDuration = _samplingDuration / numberOfWindows;
			_windows = new Queue<HealthCount>(numberOfWindows + 1);
		}

		public void IncrementSuccess_NeedsLock()
		{
			ActualiseCurrentMetric_NeedsLock();
			_currentWindow.Successes++;
		}

		public void IncrementFailure_NeedsLock()
		{
			ActualiseCurrentMetric_NeedsLock();
			_currentWindow.Failures++;
		}

		public void Reset_NeedsLock()
		{
			_currentWindow = null;
			_windows.Clear();
		}

		public HealthCount GetHealthCount_NeedsLock()
		{
			ActualiseCurrentMetric_NeedsLock();
			int num = 0;
			int num2 = 0;
			foreach (HealthCount window in _windows)
			{
				num += window.Successes;
				num2 += window.Failures;
			}
			return new HealthCount
			{
				Successes = num,
				Failures = num2,
				StartedAt = _windows.Peek().StartedAt
			};
		}

		private void ActualiseCurrentMetric_NeedsLock()
		{
			long ticks = SystemClock.UtcNow().Ticks;
			if (_currentWindow == null || ticks - _currentWindow.StartedAt >= _windowDuration)
			{
				_currentWindow = new HealthCount
				{
					StartedAt = ticks
				};
				_windows.Enqueue(_currentWindow);
			}
			while (_windows.Count > 0 && ticks - _windows.Peek().StartedAt >= _samplingDuration)
			{
				_windows.Dequeue();
			}
		}
	}
	internal class SingleHealthMetrics : IHealthMetrics
	{
		private readonly long _samplingDuration;

		private HealthCount _current;

		public SingleHealthMetrics(TimeSpan samplingDuration)
		{
			_samplingDuration = samplingDuration.Ticks;
		}

		public void IncrementSuccess_NeedsLock()
		{
			ActualiseCurrentMetric_NeedsLock();
			_current.Successes++;
		}

		public void IncrementFailure_NeedsLock()
		{
			ActualiseCurrentMetric_NeedsLock();
			_current.Failures++;
		}

		public void Reset_NeedsLock()
		{
			_current = null;
		}

		public HealthCount GetHealthCount_NeedsLock()
		{
			ActualiseCurrentMetric_NeedsLock();
			return _current;
		}

		private void ActualiseCurrentMetric_NeedsLock()
		{
			long ticks = SystemClock.UtcNow().Ticks;
			if (_current == null || ticks - _current.StartedAt >= _samplingDuration)
			{
				_current = new HealthCount
				{
					StartedAt = ticks
				};
			}
		}
	}
}
namespace Polly.Caching
{
	public class AbsoluteTtl : NonSlidingTtl
	{
		public AbsoluteTtl(DateTimeOffset absoluteExpirationTime)
			: base(absoluteExpirationTime)
		{
		}
	}
	internal static class AsyncCacheEngine
	{
		internal static async Task<TResult> ImplementationAsync<TResult>(IAsyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, Func<Context, string> cacheKeyStrategy, Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			cancellationToken.ThrowIfCancellationRequested();
			string cacheKey = cacheKeyStrategy(context);
			if (cacheKey == null)
			{
				return await action(context, cancellationToken).ConfigureAwait(continueOnCapturedContext);
			}
			bool flag;
			TResult result;
			try
			{
				(flag, result) = await cacheProvider.TryGetAsync(cacheKey, cancellationToken, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext);
			}
			catch (Exception arg)
			{
				flag = false;
				result = default(TResult);
				onCacheGetError(context, cacheKey, arg);
			}
			if (flag)
			{
				onCacheGet(context, cacheKey);
				return result;
			}
			onCacheMiss(context, cacheKey);
			TResult result2 = await action(context, cancellationToken).ConfigureAwait(continueOnCapturedContext);
			Ttl ttl = ttlStrategy.GetTtl(context, result2);
			if (ttl.Timespan > TimeSpan.Zero)
			{
				try
				{
					await cacheProvider.PutAsync(cacheKey, result2, ttl, cancellationToken, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext);
					onCachePut(context, cacheKey);
				}
				catch (Exception arg2)
				{
					onCachePutError(context, cacheKey, arg2);
				}
			}
			return result2;
		}
	}
	public class AsyncCachePolicy : AsyncPolicy
	{
		private readonly IAsyncCacheProvider _asyncCacheProvider;

		private readonly ITtlStrategy _ttlStrategy;

		private readonly Func<Context, string> _cacheKeyStrategy;

		private readonly Action<Context, string> _onCacheGet;

		private readonly Action<Context, string> _onCacheMiss;

		private readonly Action<Context, string> _onCachePut;

		private readonly Action<Context, string, Exception> _onCacheGetError;

		private readonly Action<Context, string, Exception> _onCachePutError;

		internal AsyncCachePolicy(IAsyncCacheProvider asyncCacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			_asyncCacheProvider = asyncCacheProvider;
			_ttlStrategy = ttlStrategy;
			_cacheKeyStrategy = cacheKeyStrategy;
			_onCacheGet = onCacheGet;
			_onCachePut = onCachePut;
			_onCacheMiss = onCacheMiss;
			_onCacheGetError = onCacheGetError;
			_onCachePutError = onCachePutError;
		}

		protected override Task ImplementationAsync(Func<Context, CancellationToken, Task> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return action(context, cancellationToken);
		}

		[DebuggerStepThrough]
		protected override Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return AsyncCacheEngine.ImplementationAsync(_asyncCacheProvider.AsyncFor<TResult>(), _ttlStrategy.For<TResult>(), _cacheKeyStrategy, action, context, cancellationToken, continueOnCapturedContext, _onCacheGet, _onCacheMiss, _onCachePut, _onCacheGetError, _onCachePutError);
		}
	}
	public class AsyncCachePolicy<TResult> : AsyncPolicy<TResult>
	{
		private IAsyncCacheProvider<TResult> _asyncCacheProvider;

		private readonly ITtlStrategy<TResult> _ttlStrategy;

		private readonly Func<Context, string> _cacheKeyStrategy;

		private readonly Action<Context, string> _onCacheGet;

		private readonly Action<Context, string> _onCacheMiss;

		private readonly Action<Context, string> _onCachePut;

		private readonly Action<Context, string, Exception> _onCacheGetError;

		private readonly Action<Context, string, Exception> _onCachePutError;

		internal AsyncCachePolicy(IAsyncCacheProvider<TResult> asyncCacheProvider, ITtlStrategy<TResult> ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
			: base((PolicyBuilder<TResult>)null)
		{
			_asyncCacheProvider = asyncCacheProvider;
			_ttlStrategy = ttlStrategy;
			_cacheKeyStrategy = cacheKeyStrategy;
			_onCacheGet = onCacheGet;
			_onCachePut = onCachePut;
			_onCacheMiss = onCacheMiss;
			_onCacheGetError = onCacheGetError;
			_onCachePutError = onCachePutError;
		}

		[DebuggerStepThrough]
		protected override Task<TResult> ImplementationAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return AsyncCacheEngine.ImplementationAsync(_asyncCacheProvider, _ttlStrategy, _cacheKeyStrategy, action, context, cancellationToken, continueOnCapturedContext, _onCacheGet, _onCacheMiss, _onCachePut, _onCacheGetError, _onCachePutError);
		}
	}
	internal class AsyncGenericCacheProvider<TCacheFormat> : IAsyncCacheProvider<TCacheFormat>
	{
		private readonly IAsyncCacheProvider _wrappedCacheProvider;

		internal AsyncGenericCacheProvider(IAsyncCacheProvider nonGenericCacheProvider)
		{
			_wrappedCacheProvider = nonGenericCacheProvider ?? throw new ArgumentNullException("nonGenericCacheProvider");
		}

		async Task<(bool, TCacheFormat)> IAsyncCacheProvider<TCacheFormat>.TryGetAsync(string key, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			var (item, obj) = await _wrappedCacheProvider.TryGetAsync(key, cancellationToken, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext);
			return (item, (TCacheFormat)(obj ?? ((object)default(TCacheFormat))));
		}

		Task IAsyncCacheProvider<TCacheFormat>.PutAsync(string key, TCacheFormat value, Ttl ttl, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return _wrappedCacheProvider.PutAsync(key, value, ttl, cancellationToken, continueOnCapturedContext);
		}
	}
	public class AsyncSerializingCacheProvider<TSerialized> : IAsyncCacheProvider
	{
		private readonly IAsyncCacheProvider<TSerialized> _wrappedCacheProvider;

		private readonly ICacheItemSerializer<object, TSerialized> _serializer;

		public AsyncSerializingCacheProvider(IAsyncCacheProvider<TSerialized> wrappedCacheProvider, ICacheItemSerializer<object, TSerialized> serializer)
		{
			_wrappedCacheProvider = wrappedCacheProvider ?? throw new ArgumentNullException("wrappedCacheProvider");
			_serializer = serializer ?? throw new ArgumentNullException("serializer");
		}

		public async Task<(bool, object)> TryGetAsync(string key, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			var (flag, objectToDeserialize) = await _wrappedCacheProvider.TryGetAsync(key, cancellationToken, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext);
			return (flag, flag ? _serializer.Deserialize(objectToDeserialize) : null);
		}

		public async Task PutAsync(string key, object value, Ttl ttl, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			await _wrappedCacheProvider.PutAsync(key, _serializer.Serialize(value), ttl, cancellationToken, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext);
		}
	}
	public class AsyncSerializingCacheProvider<TResult, TSerialized> : IAsyncCacheProvider<TResult>
	{
		private readonly IAsyncCacheProvider<TSerialized> _wrappedCacheProvider;

		private readonly ICacheItemSerializer<TResult, TSerialized> _serializer;

		public AsyncSerializingCacheProvider(IAsyncCacheProvider<TSerialized> wrappedCacheProvider, ICacheItemSerializer<TResult, TSerialized> serializer)
		{
			_wrappedCacheProvider = wrappedCacheProvider ?? throw new ArgumentNullException("wrappedCacheProvider");
			_serializer = serializer ?? throw new ArgumentNullException("serializer");
		}

		public async Task<(bool, TResult)> TryGetAsync(string key, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			var (flag, objectToDeserialize) = await _wrappedCacheProvider.TryGetAsync(key, cancellationToken, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext);
			return (flag, flag ? _serializer.Deserialize(objectToDeserialize) : default(TResult));
		}

		public async Task PutAsync(string key, TResult value, Ttl ttl, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			await _wrappedCacheProvider.PutAsync(key, _serializer.Serialize(value), ttl, cancellationToken, continueOnCapturedContext).ConfigureAwait(continueOnCapturedContext);
		}
	}
	internal static class CacheEngine
	{
		internal static TResult Implementation<TResult>(ISyncCacheProvider<TResult> cacheProvider, ITtlStrategy<TResult> ttlStrategy, Func<Context, string> cacheKeyStrategy, Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			cancellationToken.ThrowIfCancellationRequested();
			string text = cacheKeyStrategy(context);
			if (text == null)
			{
				return action(context, cancellationToken);
			}
			bool flag;
			TResult result;
			try
			{
				(flag, result) = cacheProvider.TryGet(text);
			}
			catch (Exception arg)
			{
				flag = false;
				result = default(TResult);
				onCacheGetError(context, text, arg);
			}
			if (flag)
			{
				onCacheGet(context, text);
				return result;
			}
			onCacheMiss(context, text);
			TResult val = action(context, cancellationToken);
			Ttl ttl = ttlStrategy.GetTtl(context, val);
			if (ttl.Timespan > TimeSpan.Zero)
			{
				try
				{
					cacheProvider.Put(text, val, ttl);
					onCachePut(context, text);
				}
				catch (Exception arg2)
				{
					onCachePutError(context, text, arg2);
				}
			}
			return val;
		}
	}
	public class CachePolicy : Policy, ICachePolicy, IsPolicy
	{
		private readonly ISyncCacheProvider _syncCacheProvider;

		private readonly ITtlStrategy _ttlStrategy;

		private readonly Func<Context, string> _cacheKeyStrategy;

		private readonly Action<Context, string> _onCacheGet;

		private readonly Action<Context, string> _onCacheMiss;

		private readonly Action<Context, string> _onCachePut;

		private readonly Action<Context, string, Exception> _onCacheGetError;

		private readonly Action<Context, string, Exception> _onCachePutError;

		internal CachePolicy(ISyncCacheProvider syncCacheProvider, ITtlStrategy ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
		{
			_syncCacheProvider = syncCacheProvider;
			_ttlStrategy = ttlStrategy;
			_cacheKeyStrategy = cacheKeyStrategy;
			_onCacheGet = onCacheGet;
			_onCachePut = onCachePut;
			_onCacheMiss = onCacheMiss;
			_onCacheGetError = onCacheGetError;
			_onCachePutError = onCachePutError;
		}

		protected override void Implementation(Action<Context, CancellationToken> action, Context context, CancellationToken cancellationToken)
		{
			action(context, cancellationToken);
		}

		[DebuggerStepThrough]
		protected override TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
		{
			return CacheEngine.Implementation(_syncCacheProvider.For<TResult>(), _ttlStrategy.For<TResult>(), _cacheKeyStrategy, action, context, cancellationToken, _onCacheGet, _onCacheMiss, _onCachePut, _onCacheGetError, _onCachePutError);
		}
	}
	public class CachePolicy<TResult> : Policy<TResult>, ICachePolicy<TResult>, ICachePolicy, IsPolicy
	{
		private ISyncCacheProvider<TResult> _syncCacheProvider;

		private ITtlStrategy<TResult> _ttlStrategy;

		private Func<Context, string> _cacheKeyStrategy;

		private readonly Action<Context, string> _onCacheGet;

		private readonly Action<Context, string> _onCacheMiss;

		private readonly Action<Context, string> _onCachePut;

		private readonly Action<Context, string, Exception> _onCacheGetError;

		private readonly Action<Context, string, Exception> _onCachePutError;

		internal CachePolicy(ISyncCacheProvider<TResult> syncCacheProvider, ITtlStrategy<TResult> ttlStrategy, Func<Context, string> cacheKeyStrategy, Action<Context, string> onCacheGet, Action<Context, string> onCacheMiss, Action<Context, string> onCachePut, Action<Context, string, Exception> onCacheGetError, Action<Context, string, Exception> onCachePutError)
			: base((PolicyBuilder<TResult>)null)
		{
			_syncCacheProvider = syncCacheProvider;
			_ttlStrategy = ttlStrategy;
			_cacheKeyStrategy = cacheKeyStrategy;
			_onCacheGet = onCacheGet;
			_onCachePut = onCachePut;
			_onCacheMiss = onCacheMiss;
			_onCacheGetError = onCacheGetError;
			_onCachePutError = onCachePutError;
		}

		[DebuggerStepThrough]
		protected override TResult Implementation(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
		{
			return CacheEngine.Implementation(_syncCacheProvider, _ttlStrategy, _cacheKeyStrategy, action, context, cancellationToken, _onCacheGet, _onCacheMiss, _onCachePut, _onCacheGetError, _onCachePutError);
		}
	}
	public static class CacheProviderExtensions
	{
		public static ISyncCacheProvider<TCacheFormat> For<TCacheFormat>(this ISyncCacheProvider nonGenericCacheProvider)
		{
			return new GenericCacheProvider<TCacheFormat>(nonGenericCacheProvider);
		}

		public static IAsyncCacheProvider<TCacheFormat> AsyncFor<TCacheFormat>(this IAsyncCacheProvider nonGenericCacheProvider)
		{
			return new AsyncGenericCacheProvider<TCacheFormat>(nonGenericCacheProvider);
		}

		public static SerializingCacheProvider<TSerialized> WithSerializer<TSerialized>(this ISyncCacheProvider<TSerialized> cacheProvider, ICacheItemSerializer<object, TSerialized> serializer)
		{
			return new SerializingCacheProvider<TSerialized>(cacheProvider, serializer);
		}

		public static SerializingCacheProvider<TResult, TSerialized> WithSerializer<TResult, TSerialized>(this ISyncCacheProvider<TSerialized> cacheProvider, ICacheItemSerializer<TResult, TSerialized> serializer)
		{
			return new SerializingCacheProvider<TResult, TSerialized>(cacheProvider, serializer);
		}

		public static AsyncSerializingCacheProvider<TSerialized> WithSerializer<TSerialized>(this IAsyncCacheProvider<TSerialized> cacheProvider, ICacheItemSerializer<object, TSerialized> serializer)
		{
			return new AsyncSerializingCacheProvider<TSerialized>(cacheProvider, serializer);
		}

		public static AsyncSerializingCacheProvider<TResult, TSerialized> WithSerializer<TResult, TSerialized>(this IAsyncCacheProvider<TSerialized> cacheProvider, ICacheItemSerializer<TResult, TSerialized> serializer)
		{
			return new AsyncSerializingCacheProvider<TResult, TSerialized>(cacheProvider, serializer);
		}
	}
	public class ContextualTtl : ITtlStrategy, ITtlStrategy<object>
	{
		public static readonly string TimeSpanKey = "ContextualTtlTimeSpan";

		public static readonly string SlidingExpirationKey = "ContextualTtlSliding";

		private static readonly Ttl _noTtl = new Ttl(TimeSpan.Zero, slidingExpiration: false);

		public Ttl GetTtl(Context context, object result)
		{
			if (!context.ContainsKey(TimeSpanKey))
			{
				return _noTtl;
			}
			bool slidingExpiration = context.ContainsKey(SlidingExpirationKey) && context[SlidingExpirationKey] as bool? == true;
			return new Ttl((context[TimeSpanKey] as TimeSpan?) ?? TimeSpan.Zero, slidingExpiration);
		}
	}
	public class DefaultCacheKeyStrategy : ICacheKeyStrategy
	{
		public static readonly ICacheKeyStrategy Instance = new DefaultCacheKeyStrategy();

		public string GetCacheKey(Context context)
		{
			return context.OperationKey;
		}
	}
	internal class GenericCacheProvider<TCacheFormat> : ISyncCacheProvider<TCacheFormat>
	{
		private readonly ISyncCacheProvider _wrappedCacheProvider;

		internal GenericCacheProvider(ISyncCacheProvider nonGenericCacheProvider)
		{
			_wrappedCacheProvider = nonGenericCacheProvider ?? throw new ArgumentNullException("nonGenericCacheProvider");
		}

		(bool, TCacheFormat) ISyncCacheProvider<TCacheFormat>.TryGet(string key)
		{
			var (item, obj) = _wrappedCacheProvider.TryGet(key);
			return (item, (TCacheFormat)(obj ?? ((object)default(TCacheFormat))));
		}

		void ISyncCacheProvider<TCacheFormat>.Put(string key, TCacheFormat value, Ttl ttl)
		{
			_wrappedCacheProvider.Put(key, value, ttl);
		}
	}
	internal class GenericTtlStrategy<TResult> : ITtlStrategy<TResult>
	{
		private readonly ITtlStrategy _wrappedTtlStrategy;

		internal GenericTtlStrategy(ITtlStrategy ttlStrategy)
		{
			_wrappedTtlStrategy = ttlStrategy ?? throw new ArgumentNullException("ttlStrategy");
		}

		public Ttl GetTtl(Context context, TResult result)
		{
			return _wrappedTtlStrategy.GetTtl(context, result);
		}
	}
	public interface IAsyncCacheProvider
	{
		Task<(bool, object)> TryGetAsync(string key, CancellationToken cancellationToken, bool continueOnCapturedContext);

		Task PutAsync(string key, object value, Ttl ttl, CancellationToken cancellationToken, bool continueOnCapturedContext);
	}
	public interface IAsyncCacheProvider<TResult>
	{
		Task<(bool, TResult)> TryGetAsync(string key, CancellationToken cancellationToken, bool continueOnCapturedContext);

		Task PutAsync(string key, TResult value, Ttl ttl, CancellationToken cancellationToken, bool continueOnCapturedContext);
	}
	public interface ICacheItemSerializer<TResult, TSerialized>
	{
		TSerialized Serialize(TResult objectToSerialize);

		TResult Deserialize(TSerialized objectToDeserialize);
	}
	public interface ICacheKeyStrategy
	{
		string GetCacheKey(Context context);
	}
	public interface ICachePolicy : IsPolicy
	{
	}
	public interface ICachePolicy<TResult> : ICachePolicy, IsPolicy
	{
	}
	public interface ISyncCacheProvider
	{
		(bool, object) TryGet(string key);

		void Put(string key, object value, Ttl ttl);
	}
	public interface ISyncCacheProvider<TResult>
	{
		(bool, TResult) TryGet(string key);

		void Put(string key, TResult value, Ttl ttl);
	}
	public interface ITtlStrategy : ITtlStrategy<object>
	{
	}
	public interface ITtlStrategy<TResult>
	{
		Ttl GetTtl(Context context, TResult result);
	}
	public abstract class NonSlidingTtl : ITtlStrategy, ITtlStrategy<object>
	{
		protected readonly DateTimeOffset absoluteExpirationTime;

		protected NonSlidingTtl(DateTimeOffset absoluteExpirationTime)
		{
			this.absoluteExpirationTime = absoluteExpirationTime;
		}

		public Ttl GetTtl(Context context, object result)
		{
			DateTimeOffset dateTimeOffset = absoluteExpirationTime;
			TimeSpan timeSpan = dateTimeOffset.Subtract(SystemClock.DateTimeOffsetUtcNow());
			return new Ttl((timeSpan > TimeSpan.Zero) ? timeSpan : TimeSpan.Zero, slidingExpiration: false);
		}
	}
	public class RelativeTtl : ITtlStrategy, ITtlStrategy<object>
	{
		private readonly TimeSpan ttl;

		public RelativeTtl(TimeSpan ttl)
		{
			if (ttl < TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException("ttl", "The ttl for items to cache must be greater than zero.");
			}
			this.ttl = ttl;
		}

		public Ttl GetTtl(Context context, object result)
		{
			return new Ttl(ttl);
		}
	}
	public class ResultTtl<TResult> : ITtlStrategy<TResult>
	{
		private readonly Func<Context, TResult, Ttl> _ttlFunc;

		public ResultTtl(Func<TResult, Ttl> ttlFunc)
		{
			if (ttlFunc == null)
			{
				throw new ArgumentNullException("ttlFunc");
			}
			_ttlFunc = (Context context, TResult result) => ttlFunc(result);
		}

		public ResultTtl(Func<Context, TResult, Ttl> ttlFunc)
		{
			_ttlFunc = ttlFunc ?? throw new ArgumentNullException("ttlFunc");
		}

		public Ttl GetTtl(Context context, TResult result)
		{
			return _ttlFunc(context, result);
		}
	}
	public class SerializingCacheProvider<TSerialized> : ISyncCacheProvider
	{
		private readonly ISyncCacheProvider<TSerialized> _wrappedCacheProvider;

		private readonly ICacheItemSerializer<object, TSerialized> _serializer;

		public SerializingCacheProvider(ISyncCacheProvider<TSerialized> wrappedCacheProvider, ICacheItemSerializer<object, TSerialized> serializer)
		{
			_wrappedCacheProvider = wrappedCacheProvider ?? throw new ArgumentNullException("wrappedCacheProvider");
			_serializer = serializer ?? throw new ArgumentNullException("serializer");
		}

		public (bool, object) TryGet(string key)
		{
			var (flag, objectToDeserialize) = _wrappedCacheProvider.TryGet(key);
			return (flag, flag ? _serializer.Deserialize(objectToDeserialize) : null);
		}

		public void Put(string key, object value, Ttl ttl)
		{
			_wrappedCacheProvider.Put(key, _serializer.Serialize(value), ttl);
		}
	}
	public class SerializingCacheProvider<TResult, TSerialized> : ISyncCacheProvider<TResult>
	{
		private readonly ISyncCacheProvider<TSerialized> _wrappedCacheProvider;

		private readonly ICacheItemSerializer<TResult, TSerialized> _serializer;

		public SerializingCacheProvider(ISyncCacheProvider<TSerialized> wrappedCacheProvider, ICacheItemSerializer<TResult, TSerialized> serializer)
		{
			_wrappedCacheProvider = wrappedCacheProvider ?? throw new ArgumentNullException("wrappedCacheProvider");
			_serializer = serializer ?? throw new ArgumentNullException("serializer");
		}

		public (bool, TResult) TryGet(string key)
		{
			var (flag, objectToDeserialize) = _wrappedCacheProvider.TryGet(key);
			return (flag, flag ? _serializer.Deserialize(objectToDeserialize) : default(TResult));
		}

		public void Put(string key, TResult value, Ttl ttl)
		{
			_wrappedCacheProvider.Put(key, _serializer.Serialize(value), ttl);
		}
	}
	public class SlidingTtl : ITtlStrategy, ITtlStrategy<object>
	{
		private readonly Ttl ttl;

		public SlidingTtl(TimeSpan slidingTtl)
		{
			if (slidingTtl < TimeSpan.Zero)
			{
				throw new ArgumentOutOfRangeException("slidingTtl", "The ttl for items to cache must be greater than zero.");
			}
			ttl = new Ttl(slidingTtl, slidingExpiration: true);
		}

		public Ttl GetTtl(Context context, object result)
		{
			return ttl;
		}
	}
	public struct Ttl
	{
		public TimeSpan Timespan;

		public bool SlidingExpiration;

		public Ttl(TimeSpan timeSpan)
			: this(timeSpan, slidingExpiration: false)
		{
		}

		public Ttl(TimeSpan timeSpan, bool slidingExpiration)
		{
			Timespan = timeSpan;
			SlidingExpiration = slidingExpiration;
		}
	}
	internal static class TtlStrategyExtensions
	{
		internal static ITtlStrategy<TResult> For<TResult>(this ITtlStrategy ttlStrategy)
		{
			return new GenericTtlStrategy<TResult>(ttlStrategy);
		}
	}
}
namespace Polly.Bulkhead
{
	internal static class AsyncBulkheadEngine
	{
		internal static async Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, Func<Context, Task> onBulkheadRejectedAsync, SemaphoreSlim maxParallelizationSemaphore, SemaphoreSlim maxQueuedActionsSemaphore, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			if (!(await maxQueuedActionsSemaphore.WaitAsync(TimeSpan.Zero, cancellationToken).ConfigureAwait(continueOnCapturedContext)))
			{
				await onBulkheadRejectedAsync(context).ConfigureAwait(continueOnCapturedContext);
				throw new BulkheadRejectedException();
			}
			try
			{
				await maxParallelizationSemaphore.WaitAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext);
				try
				{
					return await action(context, cancellationToken).ConfigureAwait(continueOnCapturedContext);
				}
				finally
				{
					maxParallelizationSemaphore.Release();
				}
			}
			finally
			{
				maxQueuedActionsSemaphore.Release();
			}
		}
	}
	public class AsyncBulkheadPolicy : AsyncPolicy, IBulkheadPolicy, IsPolicy, IDisposable
	{
		private readonly SemaphoreSlim _maxParallelizationSemaphore;

		private readonly SemaphoreSlim _maxQueuedActionsSemaphore;

		private readonly int _maxQueueingActions;

		private Func<Context, Task> _onBulkheadRejectedAsync;

		public int BulkheadAvailableCount => _maxParallelizationSemaphore.CurrentCount;

		public int QueueAvailableCount => Math.Min(_maxQueuedActionsSemaphore.CurrentCount, _maxQueueingActions);

		internal AsyncBulkheadPolicy(int maxParallelization, int maxQueueingActions, Func<Context, Task> onBulkheadRejectedAsync)
		{
			_maxQueueingActions = maxQueueingActions;
			_onBulkheadRejectedAsync = onBulkheadRejectedAsync ?? throw new ArgumentNullException("onBulkheadRejectedAsync");
			(_maxParallelizationSemaphore, _maxQueuedActionsSemaphore) = BulkheadSemaphoreFactory.CreateBulkheadSemaphores(maxParallelization, maxQueueingActions);
		}

		[DebuggerStepThrough]
		protected override Task<TResult> ImplementationAsync<TResult>(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return AsyncBulkheadEngine.ImplementationAsync(action, context, _onBulkheadRejectedAsync, _maxParallelizationSemaphore, _maxQueuedActionsSemaphore, cancellationToken, continueOnCapturedContext);
		}

		public void Dispose()
		{
			_maxParallelizationSemaphore.Dispose();
			_maxQueuedActionsSemaphore.Dispose();
		}
	}
	public class AsyncBulkheadPolicy<TResult> : AsyncPolicy<TResult>, IBulkheadPolicy<TResult>, IBulkheadPolicy, IsPolicy, IDisposable
	{
		private readonly SemaphoreSlim _maxParallelizationSemaphore;

		private readonly SemaphoreSlim _maxQueuedActionsSemaphore;

		private readonly int _maxQueueingActions;

		private Func<Context, Task> _onBulkheadRejectedAsync;

		public int BulkheadAvailableCount => _maxParallelizationSemaphore.CurrentCount;

		public int QueueAvailableCount => Math.Min(_maxQueuedActionsSemaphore.CurrentCount, _maxQueueingActions);

		internal AsyncBulkheadPolicy(int maxParallelization, int maxQueueingActions, Func<Context, Task> onBulkheadRejectedAsync)
			: base((PolicyBuilder<TResult>)null)
		{
			_maxQueueingActions = maxQueueingActions;
			_onBulkheadRejectedAsync = onBulkheadRejectedAsync ?? throw new ArgumentNullException("onBulkheadRejectedAsync");
			(_maxParallelizationSemaphore, _maxQueuedActionsSemaphore) = BulkheadSemaphoreFactory.CreateBulkheadSemaphores(maxParallelization, maxQueueingActions);
		}

		[DebuggerStepThrough]
		protected override Task<TResult> ImplementationAsync(Func<Context, CancellationToken, Task<TResult>> action, Context context, CancellationToken cancellationToken, bool continueOnCapturedContext)
		{
			return AsyncBulkheadEngine.ImplementationAsync(action, context, _onBulkheadRejectedAsync, _maxParallelizationSemaphore, _maxQueuedActionsSemaphore, cancellationToken, continueOnCapturedContext);
		}

		public void Dispose()
		{
			_maxParallelizationSemaphore.Dispose();
			_maxQueuedActionsSemaphore.Dispose();
		}
	}
	internal static class BulkheadEngine
	{
		internal static TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, Action<Context> onBulkheadRejected, SemaphoreSlim maxParallelizationSemaphore, SemaphoreSlim maxQueuedActionsSemaphore, CancellationToken cancellationToken)
		{
			if (!maxQueuedActionsSemaphore.Wait(TimeSpan.Zero, cancellationToken))
			{
				onBulkheadRejected(context);
				throw new BulkheadRejectedException();
			}
			try
			{
				maxParallelizationSemaphore.Wait(cancellationToken);
				try
				{
					return action(context, cancellationToken);
				}
				finally
				{
					maxParallelizationSemaphore.Release();
				}
			}
			finally
			{
				maxQueuedActionsSemaphore.Release();
			}
		}
	}
	public class BulkheadPolicy : Policy, IBulkheadPolicy, IsPolicy, IDisposable
	{
		private readonly SemaphoreSlim _maxParallelizationSemaphore;

		private readonly SemaphoreSlim _maxQueuedActionsSemaphore;

		private readonly int _maxQueueingActions;

		private readonly Action<Context> _onBulkheadRejected;

		public int BulkheadAvailableCount => _maxParallelizationSemaphore.CurrentCount;

		public int QueueAvailableCount => Math.Min(_maxQueuedActionsSemaphore.CurrentCount, _maxQueueingActions);

		internal BulkheadPolicy(int maxParallelization, int maxQueueingActions, Action<Context> onBulkheadRejected)
		{
			_maxQueueingActions = maxQueueingActions;
			_onBulkheadRejected = onBulkheadRejected ?? throw new ArgumentNullException("onBulkheadRejected");
			(_maxParallelizationSemaphore, _maxQueuedActionsSemaphore) = BulkheadSemaphoreFactory.CreateBulkheadSemaphores(maxParallelization, maxQueueingActions);
		}

		[DebuggerStepThrough]
		protected override TResult Implementation<TResult>(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
		{
			return BulkheadEngine.Implementation(action, context, _onBulkheadRejected, _maxParallelizationSemaphore, _maxQueuedActionsSemaphore, cancellationToken);
		}

		public void Dispose()
		{
			_maxParallelizationSemaphore.Dispose();
			_maxQueuedActionsSemaphore.Dispose();
		}
	}
	public class BulkheadPolicy<TResult> : Policy<TResult>, IBulkheadPolicy<TResult>, IBulkheadPolicy, IsPolicy, IDisposable
	{
		private readonly SemaphoreSlim _maxParallelizationSemaphore;

		private readonly SemaphoreSlim _maxQueuedActionsSemaphore;

		private readonly int _maxQueueingActions;

		private readonly Action<Context> _onBulkheadRejected;

		public int BulkheadAvailableCount => _maxParallelizationSemaphore.CurrentCount;

		public int QueueAvailableCount => Math.Min(_maxQueuedActionsSemaphore.CurrentCount, _maxQueueingActions);

		internal BulkheadPolicy(int maxParallelization, int maxQueueingActions, Action<Context> onBulkheadRejected)
			: base((PolicyBuilder<TResult>)null)
		{
			_maxQueueingActions = maxQueueingActions;
			_onBulkheadRejected = onBulkheadRejected ?? throw new ArgumentNullException("onBulkheadRejected");
			(_maxParallelizationSemaphore, _maxQueuedActionsSemaphore) = BulkheadSemaphoreFactory.CreateBulkheadSemaphores(maxParallelization, maxQueueingActions);
		}

		[DebuggerStepThrough]
		protected override TResult Implementation(Func<Context, CancellationToken, TResult> action, Context context, CancellationToken cancellationToken)
		{
			return BulkheadEngine.Implementation(action, context, _onBulkheadRejected, _maxParallelizationSemaphore, _maxQueuedActionsSemaphore, cancellationToken);
		}

		public void Dispose()
		{
			_maxParallelizationSemaphore.Dispose();
			_maxQueuedActionsSemaphore.Dispose();
		}
	}
	[Serializable]
	public class BulkheadRejectedException : ExecutionRejectedException
	{
		public BulkheadRejectedException()
			: this("The bulkhead semaphore and queue are full and execution was rejected.")
		{
		}

		public BulkheadRejectedException(string message)
			: base(message)
		{
		}

		public BulkheadRejectedException(string message, Exception innerException)
			: base(message, innerException)
		{
		}

		protected BulkheadRejectedException(SerializationInfo info, StreamingContext context)
			: base(info, context)
		{
		}
	}
	internal static class BulkheadSemaphoreFactory
	{
		public static (SemaphoreSlim, SemaphoreSlim) CreateBulkheadSemaphores(int maxParallelization, int maxQueueingActions)
		{
			SemaphoreSlim item = new SemaphoreSlim(maxParallelization, maxParallelization);
			int num = ((maxQueueingActions <= 2147483647 - maxParallelization) ? (maxQueueingActions + maxParallelization) : 2147483647);
			SemaphoreSlim item2 = new SemaphoreSlim(num, num);
			return (item, item2);
		}
	}
	public interface IBulkheadPolicy : IsPolicy, IDisposable
	{
		int BulkheadAvailableCount { get; }

		int QueueAvailableCount { get; }
	}
	public interface IBulkheadPolicy<TResult> : IBulkheadPolicy, IsPolicy, IDisposable
	{
	}
}
