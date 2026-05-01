using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks.Dataflow.Internal;
using FxResources.System.Threading.Tasks.Dataflow;
using Internal;
using Microsoft.CodeAnalysis;

[assembly: CLSCompliant(true)]
[assembly: AssemblyProduct("Microsoft® .NET Core")]
[assembly: AssemblyInformationalVersion("3.1.0+0f7f38c4fd323b26da10cce95f857f77f0f09b48")]
[assembly: AssemblyFileVersion("4.700.19.56404")]
[assembly: AssemblyDescription("System.Threading.Tasks.Dataflow")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyMetadata("PreferInbox", "True")]
[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: AssemblyMetadata(".NETFrameworkAssembly", "")]
[assembly: AssemblyDefaultAlias("System.Threading.Tasks.Dataflow")]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: CompilationRelaxations(8)]
[assembly: AssemblyTitle("System.Threading.Tasks.Dataflow")]
[assembly: AssemblyVersion("4.6.5.0")]
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
	internal sealed class IsReadOnlyAttribute : Attribute
	{
	}
}
namespace FxResources.System.Threading.Tasks.Dataflow
{
	internal static class SR
	{
	}
}
namespace Internal
{
	[StructLayout(LayoutKind.Explicit, Size = 124)]
	internal struct PaddingFor32
	{
	}
}
namespace System
{
	internal static class SR
	{
		private static ResourceManager s_resourceManager;

		internal static ResourceManager ResourceManager => s_resourceManager ?? (s_resourceManager = new ResourceManager(typeof(FxResources.System.Threading.Tasks.Dataflow.SR)));

		internal static string ArgumentOutOfRange_BatchSizeMustBeNoGreaterThanBoundedCapacity => GetResourceString("ArgumentOutOfRange_BatchSizeMustBeNoGreaterThanBoundedCapacity");

		internal static string ArgumentOutOfRange_GenericPositive => GetResourceString("ArgumentOutOfRange_GenericPositive");

		internal static string ArgumentOutOfRange_NeedNonNegOrNegative1 => GetResourceString("ArgumentOutOfRange_NeedNonNegOrNegative1");

		internal static string Argument_BoundedCapacityNotSupported => GetResourceString("Argument_BoundedCapacityNotSupported");

		internal static string Argument_CantConsumeFromANullSource => GetResourceString("Argument_CantConsumeFromANullSource");

		internal static string Argument_InvalidMessageHeader => GetResourceString("Argument_InvalidMessageHeader");

		internal static string Argument_InvalidMessageId => GetResourceString("Argument_InvalidMessageId");

		internal static string Argument_NonGreedyNotSupported => GetResourceString("Argument_NonGreedyNotSupported");

		internal static string InvalidOperation_DataNotAvailableForReceive => GetResourceString("InvalidOperation_DataNotAvailableForReceive");

		internal static string InvalidOperation_FailedToConsumeReservedMessage => GetResourceString("InvalidOperation_FailedToConsumeReservedMessage");

		internal static string InvalidOperation_MessageNotReservedByTarget => GetResourceString("InvalidOperation_MessageNotReservedByTarget");

		internal static string NotSupported_MemberNotNeeded => GetResourceString("NotSupported_MemberNotNeeded");

		internal static string InvalidOperation_ErrorDuringCleanup => GetResourceString("InvalidOperation_ErrorDuringCleanup");

		[MethodImpl(MethodImplOptions.NoInlining)]
		private static bool UsingResourceKeys()
		{
			return false;
		}

		internal static string GetResourceString(string resourceKey, string defaultString = null)
		{
			if (UsingResourceKeys())
			{
				return defaultString ?? resourceKey;
			}
			string text = null;
			try
			{
				text = ResourceManager.GetString(resourceKey);
			}
			catch (MissingManifestResourceException)
			{
			}
			if (defaultString != null && resourceKey.Equals(text))
			{
				return defaultString;
			}
			return text;
		}
	}
}
namespace System.Threading.Tasks
{
	internal interface IProducerConsumerQueue<T> : IEnumerable<T>, IEnumerable
	{
		bool IsEmpty { get; }

		int Count { get; }

		void Enqueue(T item);

		bool TryDequeue(out T result);

		int GetCountSafe(object syncObj);
	}
	[DebuggerDisplay("Count = {Count}")]
	internal sealed class MultiProducerMultiConsumerQueue<T> : ConcurrentQueue<T>, IProducerConsumerQueue<T>, IEnumerable<T>, IEnumerable
	{
		bool IProducerConsumerQueue<T>.IsEmpty => base.IsEmpty;

		int IProducerConsumerQueue<T>.Count => base.Count;

		void IProducerConsumerQueue<T>.Enqueue(T item)
		{
			Enqueue(item);
		}

		bool IProducerConsumerQueue<T>.TryDequeue(out T result)
		{
			return TryDequeue(out result);
		}

		int IProducerConsumerQueue<T>.GetCountSafe(object syncObj)
		{
			return base.Count;
		}
	}
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(SingleProducerSingleConsumerQueue<>.SingleProducerSingleConsumerQueue_DebugView))]
	internal sealed class SingleProducerSingleConsumerQueue<T> : IProducerConsumerQueue<T>, IEnumerable<T>, IEnumerable
	{
		[StructLayout(LayoutKind.Sequential)]
		private sealed class Segment
		{
			internal Segment _next;

			internal readonly T[] _array;

			internal SegmentState _state;

			internal Segment(int size)
			{
				_array = new T[size];
			}
		}

		private struct SegmentState
		{
			internal PaddingFor32 _pad0;

			internal volatile int _first;

			internal int _lastCopy;

			internal PaddingFor32 _pad1;

			internal int _firstCopy;

			internal volatile int _last;

			internal PaddingFor32 _pad2;
		}

		private sealed class SingleProducerSingleConsumerQueue_DebugView
		{
			private readonly SingleProducerSingleConsumerQueue<T> _queue;

			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public T[] Items
			{
				get
				{
					List<T> list = new List<T>();
					foreach (T item in _queue)
					{
						list.Add(item);
					}
					return list.ToArray();
				}
			}

			public SingleProducerSingleConsumerQueue_DebugView(SingleProducerSingleConsumerQueue<T> queue)
			{
				_queue = queue;
			}
		}

		private volatile Segment _head;

		private volatile Segment _tail;

		public bool IsEmpty
		{
			get
			{
				Segment head = _head;
				if (head._state._first != head._state._lastCopy)
				{
					return false;
				}
				if (head._state._first != head._state._last)
				{
					return false;
				}
				return head._next == null;
			}
		}

		public int Count
		{
			get
			{
				int num = 0;
				for (Segment segment = _head; segment != null; segment = segment._next)
				{
					int num2 = segment._array.Length;
					int first;
					int last;
					do
					{
						first = segment._state._first;
						last = segment._state._last;
					}
					while (first != segment._state._first);
					num += (last - first) & (num2 - 1);
				}
				return num;
			}
		}

		internal SingleProducerSingleConsumerQueue()
		{
			_head = (_tail = new Segment(32));
		}

		public void Enqueue(T item)
		{
			Segment segment = _tail;
			T[] array = segment._array;
			int last = segment._state._last;
			int num = (last + 1) & (array.Length - 1);
			if (num != segment._state._firstCopy)
			{
				array[last] = item;
				segment._state._last = num;
			}
			else
			{
				EnqueueSlow(item, ref segment);
			}
		}

		private void EnqueueSlow(T item, ref Segment segment)
		{
			if (segment._state._firstCopy != segment._state._first)
			{
				segment._state._firstCopy = segment._state._first;
				Enqueue(item);
				return;
			}
			int num = _tail._array.Length << 1;
			if (num > 16777216)
			{
				num = 16777216;
			}
			Segment segment2 = new Segment(num);
			segment2._array[0] = item;
			segment2._state._last = 1;
			segment2._state._lastCopy = 1;
			try
			{
			}
			finally
			{
				Volatile.Write(ref _tail._next, segment2);
				_tail = segment2;
			}
		}

		public bool TryDequeue(out T result)
		{
			Segment segment = _head;
			T[] array = segment._array;
			int first = segment._state._first;
			if (first != segment._state._lastCopy)
			{
				result = array[first];
				array[first] = default(T);
				segment._state._first = (first + 1) & (array.Length - 1);
				return true;
			}
			return TryDequeueSlow(ref segment, ref array, out result);
		}

		private bool TryDequeueSlow(ref Segment segment, ref T[] array, out T result)
		{
			if (segment._state._last != segment._state._lastCopy)
			{
				segment._state._lastCopy = segment._state._last;
				return TryDequeue(out result);
			}
			if (segment._next != null && segment._state._first == segment._state._last)
			{
				segment = segment._next;
				array = segment._array;
				_head = segment;
			}
			int first = segment._state._first;
			if (first == segment._state._last)
			{
				result = default(T);
				return false;
			}
			result = array[first];
			array[first] = default(T);
			segment._state._first = (first + 1) & (segment._array.Length - 1);
			segment._state._lastCopy = segment._state._last;
			return true;
		}

		public bool TryPeek(out T result)
		{
			Segment segment = _head;
			T[] array = segment._array;
			int first = segment._state._first;
			if (first != segment._state._lastCopy)
			{
				result = array[first];
				return true;
			}
			return TryPeekSlow(ref segment, ref array, out result);
		}

		private bool TryPeekSlow(ref Segment segment, ref T[] array, out T result)
		{
			if (segment._state._last != segment._state._lastCopy)
			{
				segment._state._lastCopy = segment._state._last;
				return TryPeek(out result);
			}
			if (segment._next != null && segment._state._first == segment._state._last)
			{
				segment = segment._next;
				array = segment._array;
				_head = segment;
			}
			int first = segment._state._first;
			if (first == segment._state._last)
			{
				result = default(T);
				return false;
			}
			result = array[first];
			return true;
		}

		public bool TryDequeueIf(Predicate<T> predicate, out T result)
		{
			Segment segment = _head;
			T[] array = segment._array;
			int first = segment._state._first;
			if (first != segment._state._lastCopy)
			{
				result = array[first];
				if (predicate == null || predicate(result))
				{
					array[first] = default(T);
					segment._state._first = (first + 1) & (array.Length - 1);
					return true;
				}
				result = default(T);
				return false;
			}
			return TryDequeueIfSlow(predicate, ref segment, ref array, out result);
		}

		private bool TryDequeueIfSlow(Predicate<T> predicate, ref Segment segment, ref T[] array, out T result)
		{
			if (segment._state._last != segment._state._lastCopy)
			{
				segment._state._lastCopy = segment._state._last;
				return TryDequeueIf(predicate, out result);
			}
			if (segment._next != null && segment._state._first == segment._state._last)
			{
				segment = segment._next;
				array = segment._array;
				_head = segment;
			}
			int first = segment._state._first;
			if (first == segment._state._last)
			{
				result = default(T);
				return false;
			}
			result = array[first];
			if (predicate == null || predicate(result))
			{
				array[first] = default(T);
				segment._state._first = (first + 1) & (segment._array.Length - 1);
				segment._state._lastCopy = segment._state._last;
				return true;
			}
			result = default(T);
			return false;
		}

		public void Clear()
		{
			T result;
			while (TryDequeue(out result))
			{
			}
		}

		public IEnumerator<T> GetEnumerator()
		{
			for (Segment segment = _head; segment != null; segment = segment._next)
			{
				for (int pt = segment._state._first; pt != segment._state._last; pt = (pt + 1) & (segment._array.Length - 1))
				{
					yield return segment._array[pt];
				}
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		int IProducerConsumerQueue<T>.GetCountSafe(object syncObj)
		{
			lock (syncObj)
			{
				return Count;
			}
		}
	}
}
namespace System.Threading.Tasks.Dataflow
{
	public static class DataflowBlock
	{
		[DebuggerTypeProxy(typeof(FilteredLinkPropagator<>.DebugView))]
		[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
		private sealed class FilteredLinkPropagator<T> : IPropagatorBlock<T, T>, ITargetBlock<T>, IDataflowBlock, ISourceBlock<T>, IDebuggerDisplay
		{
			private sealed class DebugView
			{
				private readonly FilteredLinkPropagator<T> _filter;

				public ITargetBlock<T> LinkedTarget => _filter._target;

				public DebugView(FilteredLinkPropagator<T> filter)
				{
					_filter = filter;
				}
			}

			private readonly ISourceBlock<T> _source;

			private readonly ITargetBlock<T> _target;

			private readonly Predicate<T> _userProvidedPredicate;

			Task IDataflowBlock.Completion => _source.Completion;

			private object DebuggerDisplayContent
			{
				get
				{
					IDebuggerDisplay debuggerDisplay = _source as IDebuggerDisplay;
					IDebuggerDisplay debuggerDisplay2 = _target as IDebuggerDisplay;
					return $"{Common.GetNameForDebugger(this)} Source=\"{((debuggerDisplay != null) ? debuggerDisplay.Content : _source)}\", Target=\"{((debuggerDisplay2 != null) ? debuggerDisplay2.Content : _target)}\"";
				}
			}

			object IDebuggerDisplay.Content => DebuggerDisplayContent;

			internal FilteredLinkPropagator(ISourceBlock<T> source, ITargetBlock<T> target, Predicate<T> predicate)
			{
				_source = source;
				_target = target;
				_userProvidedPredicate = predicate;
			}

			private bool RunPredicate(T item)
			{
				return _userProvidedPredicate(item);
			}

			DataflowMessageStatus ITargetBlock<T>.OfferMessage(DataflowMessageHeader messageHeader, T messageValue, ISourceBlock<T> source, bool consumeToAccept)
			{
				if (!messageHeader.IsValid)
				{
					throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
				}
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				if (RunPredicate(messageValue))
				{
					return _target.OfferMessage(messageHeader, messageValue, this, consumeToAccept);
				}
				return DataflowMessageStatus.Declined;
			}

			T ISourceBlock<T>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<T> target, out bool messageConsumed)
			{
				return _source.ConsumeMessage(messageHeader, this, out messageConsumed);
			}

			bool ISourceBlock<T>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<T> target)
			{
				return _source.ReserveMessage(messageHeader, this);
			}

			void ISourceBlock<T>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<T> target)
			{
				_source.ReleaseReservation(messageHeader, this);
			}

			void IDataflowBlock.Complete()
			{
				_target.Complete();
			}

			void IDataflowBlock.Fault(Exception exception)
			{
				_target.Fault(exception);
			}

			IDisposable ISourceBlock<T>.LinkTo(ITargetBlock<T> target, DataflowLinkOptions linkOptions)
			{
				throw new NotSupportedException(SR.NotSupported_MemberNotNeeded);
			}
		}

		[DebuggerTypeProxy(typeof(SendAsyncSource<>.DebugView))]
		[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
		private sealed class SendAsyncSource<TOutput> : TaskCompletionSource<bool>, ISourceBlock<TOutput>, IDataflowBlock, IDebuggerDisplay
		{
			private sealed class DebugView
			{
				private readonly SendAsyncSource<TOutput> _source;

				public ITargetBlock<TOutput> Target => _source._target;

				public TOutput Message => _source._messageValue;

				public Task<bool> Completion => _source.Task;

				public DebugView(SendAsyncSource<TOutput> source)
				{
					_source = source;
				}
			}

			private readonly ITargetBlock<TOutput> _target;

			private readonly TOutput _messageValue;

			private CancellationToken _cancellationToken;

			private CancellationTokenRegistration _cancellationRegistration;

			private int _cancellationState;

			private static readonly Action<object> _cancellationCallback = CancellationHandler;

			Task IDataflowBlock.Completion => base.Task;

			private object DebuggerDisplayContent
			{
				get
				{
					IDebuggerDisplay debuggerDisplay = _target as IDebuggerDisplay;
					return $"{Common.GetNameForDebugger(this)} Message={_messageValue}, Target=\"{((debuggerDisplay != null) ? debuggerDisplay.Content : _target)}\"";
				}
			}

			object IDebuggerDisplay.Content => DebuggerDisplayContent;

			internal SendAsyncSource(ITargetBlock<TOutput> target, TOutput messageValue, CancellationToken cancellationToken)
			{
				_target = target;
				_messageValue = messageValue;
				if (cancellationToken.CanBeCanceled)
				{
					_cancellationToken = cancellationToken;
					_cancellationState = 1;
					try
					{
						_cancellationRegistration = cancellationToken.Register(_cancellationCallback, new WeakReference<SendAsyncSource<TOutput>>(this));
					}
					catch
					{
						GC.SuppressFinalize(this);
						throw;
					}
				}
			}

			~SendAsyncSource()
			{
				if (!Environment.HasShutdownStarted)
				{
					CompleteAsDeclined(runAsync: true);
				}
			}

			private void CompleteAsAccepted(bool runAsync)
			{
				RunCompletionAction(delegate(object state)
				{
					try
					{
						((SendAsyncSource<TOutput>)state).TrySetResult(result: true);
					}
					catch (ObjectDisposedException)
					{
					}
				}, this, runAsync);
			}

			private void CompleteAsDeclined(bool runAsync)
			{
				RunCompletionAction(delegate(object state)
				{
					try
					{
						((SendAsyncSource<TOutput>)state).TrySetResult(result: false);
					}
					catch (ObjectDisposedException)
					{
					}
				}, this, runAsync);
			}

			private void CompleteAsFaulted(Exception exception, bool runAsync)
			{
				RunCompletionAction(delegate(object state)
				{
					Tuple<SendAsyncSource<TOutput>, Exception> tuple = (Tuple<SendAsyncSource<TOutput>, Exception>)state;
					try
					{
						tuple.Item1.TrySetException(tuple.Item2);
					}
					catch (ObjectDisposedException)
					{
					}
				}, Tuple.Create(this, exception), runAsync);
			}

			private void CompleteAsCanceled(bool runAsync)
			{
				RunCompletionAction(delegate(object state)
				{
					try
					{
						((SendAsyncSource<TOutput>)state).TrySetCanceled();
					}
					catch (ObjectDisposedException)
					{
					}
				}, this, runAsync);
			}

			private void RunCompletionAction(Action<object> completionAction, object completionActionState, bool runAsync)
			{
				GC.SuppressFinalize(this);
				if (_cancellationState != 0)
				{
					_cancellationRegistration.Dispose();
				}
				if (runAsync)
				{
					System.Threading.Tasks.Task.Factory.StartNew(completionAction, completionActionState, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
				}
				else
				{
					completionAction(completionActionState);
				}
			}

			private void OfferToTargetAsync()
			{
				System.Threading.Tasks.Task.Factory.StartNew(delegate(object state)
				{
					((SendAsyncSource<TOutput>)state).OfferToTarget();
				}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
			}

			private static void CancellationHandler(object state)
			{
				SendAsyncSource<TOutput> sendAsyncSource = Common.UnwrapWeakReference<SendAsyncSource<TOutput>>(state);
				if (sendAsyncSource != null && sendAsyncSource._cancellationState == 1 && Interlocked.CompareExchange(ref sendAsyncSource._cancellationState, 3, 1) == 1)
				{
					sendAsyncSource.CompleteAsCanceled(runAsync: true);
				}
			}

			internal void OfferToTarget()
			{
				try
				{
					bool flag = _cancellationState != 0;
					switch (_target.OfferMessage(Common.SingleMessageHeader, _messageValue, this, flag))
					{
					case DataflowMessageStatus.Accepted:
						if (!flag)
						{
							CompleteAsAccepted(runAsync: false);
						}
						break;
					case DataflowMessageStatus.Declined:
					case DataflowMessageStatus.DecliningPermanently:
						CompleteAsDeclined(runAsync: false);
						break;
					case DataflowMessageStatus.Postponed:
					case DataflowMessageStatus.NotAvailable:
						break;
					}
				}
				catch (Exception ex)
				{
					Common.StoreDataflowMessageValueIntoExceptionData(ex, _messageValue);
					CompleteAsFaulted(ex, runAsync: false);
				}
			}

			TOutput ISourceBlock<TOutput>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target, out bool messageConsumed)
			{
				if (!messageHeader.IsValid)
				{
					throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
				}
				if (target == null)
				{
					throw new ArgumentNullException("target");
				}
				if (base.Task.IsCompleted)
				{
					messageConsumed = false;
					return default(TOutput);
				}
				if (messageHeader.Id == 1)
				{
					int cancellationState = _cancellationState;
					if (cancellationState == 0 || (cancellationState != 3 && Interlocked.CompareExchange(ref _cancellationState, 3, cancellationState) == cancellationState))
					{
						CompleteAsAccepted(runAsync: true);
						messageConsumed = true;
						return _messageValue;
					}
				}
				messageConsumed = false;
				return default(TOutput);
			}

			bool ISourceBlock<TOutput>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target)
			{
				if (!messageHeader.IsValid)
				{
					throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
				}
				if (target == null)
				{
					throw new ArgumentNullException("target");
				}
				if (base.Task.IsCompleted)
				{
					return false;
				}
				if (messageHeader.Id == 1)
				{
					if (_cancellationState != 0)
					{
						return Interlocked.CompareExchange(ref _cancellationState, 2, 1) == 1;
					}
					return true;
				}
				return false;
			}

			void ISourceBlock<TOutput>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target)
			{
				if (!messageHeader.IsValid)
				{
					throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
				}
				if (target == null)
				{
					throw new ArgumentNullException("target");
				}
				if (messageHeader.Id != 1)
				{
					throw new InvalidOperationException(SR.InvalidOperation_MessageNotReservedByTarget);
				}
				if (base.Task.IsCompleted)
				{
					return;
				}
				if (_cancellationState != 0)
				{
					if (Interlocked.CompareExchange(ref _cancellationState, 1, 2) != 2)
					{
						throw new InvalidOperationException(SR.InvalidOperation_MessageNotReservedByTarget);
					}
					if (_cancellationToken.IsCancellationRequested)
					{
						CancellationHandler(new WeakReference<SendAsyncSource<TOutput>>(this));
					}
				}
				OfferToTargetAsync();
			}

			IDisposable ISourceBlock<TOutput>.LinkTo(ITargetBlock<TOutput> target, DataflowLinkOptions linkOptions)
			{
				throw new NotSupportedException(SR.NotSupported_MemberNotNeeded);
			}

			void IDataflowBlock.Complete()
			{
				throw new NotSupportedException(SR.NotSupported_MemberNotNeeded);
			}

			void IDataflowBlock.Fault(Exception exception)
			{
				throw new NotSupportedException(SR.NotSupported_MemberNotNeeded);
			}
		}

		private enum ReceiveCoreByLinkingCleanupReason
		{
			Success,
			Timer,
			Cancellation,
			SourceCompletion,
			SourceProtocolError,
			ErrorDuringCleanup
		}

		[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
		private sealed class ReceiveTarget<T> : TaskCompletionSource<T>, ITargetBlock<T>, IDataflowBlock, IDebuggerDisplay
		{
			internal static readonly TimerCallback CachedLinkingTimerCallback = delegate(object state)
			{
				ReceiveTarget<T> receiveTarget = (ReceiveTarget<T>)state;
				receiveTarget.TryCleanupAndComplete(ReceiveCoreByLinkingCleanupReason.Timer);
			};

			internal static readonly Action<object> CachedLinkingCancellationCallback = delegate(object state)
			{
				ReceiveTarget<T> receiveTarget = (ReceiveTarget<T>)state;
				receiveTarget.TryCleanupAndComplete(ReceiveCoreByLinkingCleanupReason.Cancellation);
			};

			private T _receivedValue;

			internal readonly CancellationTokenSource _cts = new CancellationTokenSource();

			internal bool _cleanupReserved;

			internal CancellationToken _externalCancellationToken;

			internal CancellationTokenRegistration _regFromExternalCancellationToken;

			internal Timer _timer;

			internal IDisposable _unlink;

			internal Exception _receivedException;

			internal object IncomingLock => _cts;

			Task IDataflowBlock.Completion
			{
				get
				{
					throw new NotSupportedException(SR.NotSupported_MemberNotNeeded);
				}
			}

			private object DebuggerDisplayContent => $"{Common.GetNameForDebugger(this)} IsCompleted={base.Task.IsCompleted}";

			object IDebuggerDisplay.Content => DebuggerDisplayContent;

			internal ReceiveTarget()
			{
			}

			DataflowMessageStatus ITargetBlock<T>.OfferMessage(DataflowMessageHeader messageHeader, T messageValue, ISourceBlock<T> source, bool consumeToAccept)
			{
				if (!messageHeader.IsValid)
				{
					throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
				}
				if (source == null && consumeToAccept)
				{
					throw new ArgumentException(SR.Argument_CantConsumeFromANullSource, "consumeToAccept");
				}
				DataflowMessageStatus dataflowMessageStatus = DataflowMessageStatus.NotAvailable;
				if (Volatile.Read(ref _cleanupReserved))
				{
					return DataflowMessageStatus.DecliningPermanently;
				}
				lock (IncomingLock)
				{
					if (_cleanupReserved)
					{
						return DataflowMessageStatus.DecliningPermanently;
					}
					try
					{
						bool messageConsumed = true;
						T receivedValue = (consumeToAccept ? source.ConsumeMessage(messageHeader, this, out messageConsumed) : messageValue);
						if (messageConsumed)
						{
							dataflowMessageStatus = DataflowMessageStatus.Accepted;
							_receivedValue = receivedValue;
							_cleanupReserved = true;
						}
					}
					catch (Exception ex)
					{
						dataflowMessageStatus = DataflowMessageStatus.DecliningPermanently;
						Common.StoreDataflowMessageValueIntoExceptionData(ex, messageValue);
						_receivedException = ex;
						_cleanupReserved = true;
					}
				}
				switch (dataflowMessageStatus)
				{
				case DataflowMessageStatus.Accepted:
					CleanupAndComplete(ReceiveCoreByLinkingCleanupReason.Success);
					break;
				case DataflowMessageStatus.DecliningPermanently:
					CleanupAndComplete(ReceiveCoreByLinkingCleanupReason.SourceProtocolError);
					break;
				}
				return dataflowMessageStatus;
			}

			internal bool TryCleanupAndComplete(ReceiveCoreByLinkingCleanupReason reason)
			{
				if (Volatile.Read(ref _cleanupReserved))
				{
					return false;
				}
				lock (IncomingLock)
				{
					if (_cleanupReserved)
					{
						return false;
					}
					_cleanupReserved = true;
				}
				CleanupAndComplete(reason);
				return true;
			}

			private void CleanupAndComplete(ReceiveCoreByLinkingCleanupReason reason)
			{
				IDisposable unlink = _unlink;
				if (reason != ReceiveCoreByLinkingCleanupReason.SourceCompletion && unlink != null)
				{
					IDisposable disposable = Interlocked.CompareExchange(ref _unlink, null, unlink);
					if (disposable != null)
					{
						try
						{
							disposable.Dispose();
						}
						catch (Exception receivedException)
						{
							_receivedException = receivedException;
							reason = ReceiveCoreByLinkingCleanupReason.SourceProtocolError;
						}
					}
				}
				if (_timer != null)
				{
					_timer.Dispose();
				}
				if (reason != ReceiveCoreByLinkingCleanupReason.Cancellation)
				{
					if (reason == ReceiveCoreByLinkingCleanupReason.SourceCompletion && (_externalCancellationToken.IsCancellationRequested || _cts.IsCancellationRequested))
					{
						reason = ReceiveCoreByLinkingCleanupReason.Cancellation;
					}
					_cts.Cancel();
				}
				_regFromExternalCancellationToken.Dispose();
				switch (reason)
				{
				case ReceiveCoreByLinkingCleanupReason.Success:
					System.Threading.Tasks.Task.Factory.StartNew(delegate(object state)
					{
						ReceiveTarget<T> receiveTarget = (ReceiveTarget<T>)state;
						try
						{
							receiveTarget.TrySetResult(receiveTarget._receivedValue);
						}
						catch (ObjectDisposedException)
						{
						}
					}, this, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
					return;
				default:
					System.Threading.Tasks.Task.Factory.StartNew(delegate(object state)
					{
						ReceiveTarget<T> receiveTarget = (ReceiveTarget<T>)state;
						try
						{
							receiveTarget.TrySetCanceled();
						}
						catch (ObjectDisposedException)
						{
						}
					}, this, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
					return;
				case ReceiveCoreByLinkingCleanupReason.SourceCompletion:
					if (_receivedException == null)
					{
						_receivedException = CreateExceptionForSourceCompletion();
					}
					break;
				case ReceiveCoreByLinkingCleanupReason.Timer:
					if (_receivedException == null)
					{
						_receivedException = CreateExceptionForTimeout();
					}
					break;
				case ReceiveCoreByLinkingCleanupReason.SourceProtocolError:
				case ReceiveCoreByLinkingCleanupReason.ErrorDuringCleanup:
					break;
				}
				System.Threading.Tasks.Task.Factory.StartNew(delegate(object state)
				{
					ReceiveTarget<T> receiveTarget = (ReceiveTarget<T>)state;
					try
					{
						receiveTarget.TrySetException(receiveTarget._receivedException ?? new InvalidOperationException(SR.InvalidOperation_ErrorDuringCleanup));
					}
					catch (ObjectDisposedException)
					{
					}
				}, this, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default);
			}

			internal static Exception CreateExceptionForSourceCompletion()
			{
				return Common.InitializeStackTrace(new InvalidOperationException(SR.InvalidOperation_DataNotAvailableForReceive));
			}

			internal static Exception CreateExceptionForTimeout()
			{
				return Common.InitializeStackTrace(new TimeoutException());
			}

			void IDataflowBlock.Complete()
			{
				TryCleanupAndComplete(ReceiveCoreByLinkingCleanupReason.SourceCompletion);
			}

			void IDataflowBlock.Fault(Exception exception)
			{
				((IDataflowBlock)this).Complete();
			}
		}

		[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
		private sealed class OutputAvailableAsyncTarget<T> : TaskCompletionSource<bool>, ITargetBlock<T>, IDataflowBlock, IDebuggerDisplay
		{
			internal static readonly Func<Task<bool>, object, bool> s_handleCompletion = delegate(Task<bool> antecedent, object state)
			{
				OutputAvailableAsyncTarget<T> outputAvailableAsyncTarget = state as OutputAvailableAsyncTarget<T>;
				outputAvailableAsyncTarget._ctr.Dispose();
				return antecedent.GetAwaiter().GetResult();
			};

			internal static readonly Action<object> s_cancelAndUnlink = CancelAndUnlink;

			internal IDisposable _unlinker;

			internal CancellationTokenRegistration _ctr;

			Task IDataflowBlock.Completion
			{
				get
				{
					throw new NotSupportedException(SR.NotSupported_MemberNotNeeded);
				}
			}

			private object DebuggerDisplayContent => $"{Common.GetNameForDebugger(this)} IsCompleted={base.Task.IsCompleted}";

			object IDebuggerDisplay.Content => DebuggerDisplayContent;

			private static void CancelAndUnlink(object state)
			{
				OutputAvailableAsyncTarget<T> state2 = state as OutputAvailableAsyncTarget<T>;
				System.Threading.Tasks.Task.Factory.StartNew(delegate(object tgt)
				{
					OutputAvailableAsyncTarget<T> outputAvailableAsyncTarget = (OutputAvailableAsyncTarget<T>)tgt;
					outputAvailableAsyncTarget.TrySetCanceled();
					outputAvailableAsyncTarget.AttemptThreadSafeUnlink();
				}, state2, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
			}

			internal void AttemptThreadSafeUnlink()
			{
				IDisposable unlinker = _unlinker;
				if (unlinker != null && Interlocked.CompareExchange(ref _unlinker, null, unlinker) == unlinker)
				{
					unlinker.Dispose();
				}
			}

			DataflowMessageStatus ITargetBlock<T>.OfferMessage(DataflowMessageHeader messageHeader, T messageValue, ISourceBlock<T> source, bool consumeToAccept)
			{
				if (!messageHeader.IsValid)
				{
					throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
				}
				if (source == null)
				{
					throw new ArgumentNullException("source");
				}
				TrySetResult(result: true);
				return DataflowMessageStatus.DecliningPermanently;
			}

			void IDataflowBlock.Complete()
			{
				TrySetResult(result: false);
			}

			void IDataflowBlock.Fault(Exception exception)
			{
				if (exception == null)
				{
					throw new ArgumentNullException("exception");
				}
				TrySetResult(result: false);
			}
		}

		[DebuggerTypeProxy(typeof(EncapsulatingPropagator<, >.DebugView))]
		[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
		private sealed class EncapsulatingPropagator<TInput, TOutput> : IPropagatorBlock<TInput, TOutput>, ITargetBlock<TInput>, IDataflowBlock, ISourceBlock<TOutput>, IReceivableSourceBlock<TOutput>, IDebuggerDisplay
		{
			private sealed class DebugView
			{
				private readonly EncapsulatingPropagator<TInput, TOutput> _propagator;

				public ITargetBlock<TInput> Target => _propagator._target;

				public ISourceBlock<TOutput> Source => _propagator._source;

				public DebugView(EncapsulatingPropagator<TInput, TOutput> propagator)
				{
					_propagator = propagator;
				}
			}

			private ITargetBlock<TInput> _target;

			private ISourceBlock<TOutput> _source;

			public Task Completion => _source.Completion;

			private object DebuggerDisplayContent
			{
				get
				{
					IDebuggerDisplay debuggerDisplay = _target as IDebuggerDisplay;
					IDebuggerDisplay debuggerDisplay2 = _source as IDebuggerDisplay;
					return $"{Common.GetNameForDebugger(this)} Target=\"{((debuggerDisplay != null) ? debuggerDisplay.Content : _target)}\", Source=\"{((debuggerDisplay2 != null) ? debuggerDisplay2.Content : _source)}\"";
				}
			}

			object IDebuggerDisplay.Content => DebuggerDisplayContent;

			public EncapsulatingPropagator(ITargetBlock<TInput> target, ISourceBlock<TOutput> source)
			{
				_target = target;
				_source = source;
			}

			public void Complete()
			{
				_target.Complete();
			}

			void IDataflowBlock.Fault(Exception exception)
			{
				if (exception == null)
				{
					throw new ArgumentNullException("exception");
				}
				_target.Fault(exception);
			}

			public DataflowMessageStatus OfferMessage(DataflowMessageHeader messageHeader, TInput messageValue, ISourceBlock<TInput> source, bool consumeToAccept)
			{
				return _target.OfferMessage(messageHeader, messageValue, source, consumeToAccept);
			}

			public IDisposable LinkTo(ITargetBlock<TOutput> target, DataflowLinkOptions linkOptions)
			{
				return _source.LinkTo(target, linkOptions);
			}

			public bool TryReceive(Predicate<TOutput> filter, out TOutput item)
			{
				if (_source is IReceivableSourceBlock<TOutput> receivableSourceBlock)
				{
					return receivableSourceBlock.TryReceive(filter, out item);
				}
				item = default(TOutput);
				return false;
			}

			public bool TryReceiveAll(out IList<TOutput> items)
			{
				if (_source is IReceivableSourceBlock<TOutput> receivableSourceBlock)
				{
					return receivableSourceBlock.TryReceiveAll(out items);
				}
				items = null;
				return false;
			}

			public TOutput ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target, out bool messageConsumed)
			{
				return _source.ConsumeMessage(messageHeader, target, out messageConsumed);
			}

			public bool ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target)
			{
				return _source.ReserveMessage(messageHeader, target);
			}

			public void ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target)
			{
				_source.ReleaseReservation(messageHeader, target);
			}
		}

		[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
		private sealed class ChooseTarget<T> : TaskCompletionSource<T>, ITargetBlock<T>, IDataflowBlock, IDebuggerDisplay
		{
			internal static readonly Func<object, int> s_processBranchFunction = delegate(object state)
			{
				Tuple<Action<T>, T, int> tuple = (Tuple<Action<T>, T, int>)state;
				tuple.Item1(tuple.Item2);
				return tuple.Item3;
			};

			private StrongBox<Task> _completed;

			Task IDataflowBlock.Completion
			{
				get
				{
					throw new NotSupportedException(SR.NotSupported_MemberNotNeeded);
				}
			}

			private object DebuggerDisplayContent => $"{Common.GetNameForDebugger(this)} IsCompleted={base.Task.IsCompleted}";

			object IDebuggerDisplay.Content => DebuggerDisplayContent;

			internal ChooseTarget(StrongBox<Task> completed, CancellationToken cancellationToken)
			{
				_completed = completed;
				Common.WireCancellationToComplete(cancellationToken, base.Task, delegate(object state)
				{
					ChooseTarget<T> chooseTarget = (ChooseTarget<T>)state;
					lock (chooseTarget._completed)
					{
						chooseTarget.TrySetCanceled();
					}
				}, this);
			}

			public DataflowMessageStatus OfferMessage(DataflowMessageHeader messageHeader, T messageValue, ISourceBlock<T> source, bool consumeToAccept)
			{
				if (!messageHeader.IsValid)
				{
					throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
				}
				if (source == null && consumeToAccept)
				{
					throw new ArgumentException(SR.Argument_CantConsumeFromANullSource, "consumeToAccept");
				}
				lock (_completed)
				{
					if (_completed.Value != null || base.Task.IsCompleted)
					{
						return DataflowMessageStatus.DecliningPermanently;
					}
					if (consumeToAccept)
					{
						messageValue = source.ConsumeMessage(messageHeader, this, out var messageConsumed);
						if (!messageConsumed)
						{
							return DataflowMessageStatus.NotAvailable;
						}
					}
					TrySetResult(messageValue);
					_completed.Value = base.Task;
					return DataflowMessageStatus.Accepted;
				}
			}

			void IDataflowBlock.Complete()
			{
				lock (_completed)
				{
					TrySetCanceled();
				}
			}

			void IDataflowBlock.Fault(Exception exception)
			{
				((IDataflowBlock)this).Complete();
			}
		}

		[DebuggerTypeProxy(typeof(SourceObservable<>.DebugView))]
		[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
		private sealed class SourceObservable<TOutput> : IObservable<TOutput>, IDebuggerDisplay
		{
			private sealed class DebugView
			{
				private readonly SourceObservable<TOutput> _observable;

				[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
				public IObserver<TOutput>[] Observers => _observable._observersState.Observers.ToArray();

				public DebugView(SourceObservable<TOutput> observable)
				{
					_observable = observable;
				}
			}

			private sealed class ObserversState
			{
				internal readonly SourceObservable<TOutput> Observable;

				internal readonly ActionBlock<TOutput> Target;

				internal readonly CancellationTokenSource Canceler = new CancellationTokenSource();

				internal ImmutableArray<IObserver<TOutput>> Observers = ImmutableArray<IObserver<TOutput>>.Empty;

				internal IDisposable Unlinker;

				private List<Task<bool>> _tempSendAsyncTaskList;

				internal ObserversState(SourceObservable<TOutput> observable)
				{
					Observable = observable;
					Target = new ActionBlock<TOutput>((Func<TOutput, Task>)ProcessItemAsync, _nonGreedyExecutionOptions);
					Target.Completion.ContinueWith(delegate(Task t, object state)
					{
						((ObserversState)state).NotifyObserversOfCompletion(t.Exception);
					}, this, CancellationToken.None, Common.GetContinuationOptions(TaskContinuationOptions.OnlyOnFaulted | TaskContinuationOptions.ExecuteSynchronously), TaskScheduler.Default);
					Common.GetPotentiallyNotSupportedCompletionTask(Observable._source)?.ContinueWith(delegate(Task _1, object state1)
					{
						ObserversState observersState = (ObserversState)state1;
						observersState.Target.Complete();
						observersState.Target.Completion.ContinueWith(delegate(Task task, object obj)
						{
							((ObserversState)obj).NotifyObserversOfCompletion();
						}, state1, CancellationToken.None, Common.GetContinuationOptions(TaskContinuationOptions.NotOnFaulted | TaskContinuationOptions.ExecuteSynchronously), TaskScheduler.Default);
					}, this, Canceler.Token, Common.GetContinuationOptions(TaskContinuationOptions.ExecuteSynchronously), TaskScheduler.Default);
				}

				private Task ProcessItemAsync(TOutput item)
				{
					ImmutableArray<IObserver<TOutput>> observers;
					lock (Observable._SubscriptionLock)
					{
						observers = Observers;
					}
					try
					{
						foreach (IObserver<TOutput> item2 in observers)
						{
							if (item2 is TargetObserver<TOutput> targetObserver)
							{
								Task<bool> task = targetObserver.SendAsyncToTarget(item);
								if (task.Status != TaskStatus.RanToCompletion)
								{
									if (_tempSendAsyncTaskList == null)
									{
										_tempSendAsyncTaskList = new List<Task<bool>>();
									}
									_tempSendAsyncTaskList.Add(task);
								}
							}
							else
							{
								item2.OnNext(item);
							}
						}
						if (_tempSendAsyncTaskList != null && _tempSendAsyncTaskList.Count > 0)
						{
							Task<bool[]> result = Task.WhenAll(_tempSendAsyncTaskList);
							_tempSendAsyncTaskList.Clear();
							return result;
						}
					}
					catch (Exception exception)
					{
						return Common.CreateTaskFromException<VoidResult>(exception);
					}
					return Common.CompletedTaskWithTrueResult;
				}

				private void NotifyObserversOfCompletion(Exception targetException = null)
				{
					ImmutableArray<IObserver<TOutput>> observers;
					lock (Observable._SubscriptionLock)
					{
						observers = Observers;
						if (targetException != null)
						{
							Observable.ResetObserverState();
						}
						Observers = ImmutableArray<IObserver<TOutput>>.Empty;
					}
					if (observers.Count <= 0)
					{
						return;
					}
					Exception ex = targetException ?? Observable.GetCompletionError();
					try
					{
						if (ex != null)
						{
							foreach (IObserver<TOutput> item in observers)
							{
								item.OnError(ex);
							}
							return;
						}
						foreach (IObserver<TOutput> item2 in observers)
						{
							item2.OnCompleted();
						}
					}
					catch (Exception error)
					{
						Common.ThrowAsync(error);
					}
				}
			}

			private static readonly ConditionalWeakTable<ISourceBlock<TOutput>, SourceObservable<TOutput>> _table = new ConditionalWeakTable<ISourceBlock<TOutput>, SourceObservable<TOutput>>();

			private readonly object _SubscriptionLock = new object();

			private readonly ISourceBlock<TOutput> _source;

			private ObserversState _observersState;

			private object DebuggerDisplayContent
			{
				get
				{
					IDebuggerDisplay debuggerDisplay = _source as IDebuggerDisplay;
					return $"Observers={_observersState.Observers.Count}, Block=\"{((debuggerDisplay != null) ? debuggerDisplay.Content : _source)}\"";
				}
			}

			object IDebuggerDisplay.Content => DebuggerDisplayContent;

			internal static IObservable<TOutput> From(ISourceBlock<TOutput> source)
			{
				return _table.GetValue(source, (ISourceBlock<TOutput> s) => new SourceObservable<TOutput>(s));
			}

			internal SourceObservable(ISourceBlock<TOutput> source)
			{
				_source = source;
				_observersState = new ObserversState(this);
			}

			private AggregateException GetCompletionError()
			{
				Task potentiallyNotSupportedCompletionTask = Common.GetPotentiallyNotSupportedCompletionTask(_source);
				if (potentiallyNotSupportedCompletionTask == null || !potentiallyNotSupportedCompletionTask.IsFaulted)
				{
					return null;
				}
				return potentiallyNotSupportedCompletionTask.Exception;
			}

			IDisposable IObservable<TOutput>.Subscribe(IObserver<TOutput> observer)
			{
				if (observer == null)
				{
					throw new ArgumentNullException("observer");
				}
				Task potentiallyNotSupportedCompletionTask = Common.GetPotentiallyNotSupportedCompletionTask(_source);
				Exception ex = null;
				lock (_SubscriptionLock)
				{
					if (potentiallyNotSupportedCompletionTask == null || !potentiallyNotSupportedCompletionTask.IsCompleted || !_observersState.Target.Completion.IsCompleted)
					{
						_observersState.Observers = _observersState.Observers.Add(observer);
						if (_observersState.Observers.Count == 1)
						{
							_observersState.Unlinker = _source.LinkTo(_observersState.Target);
							if (_observersState.Unlinker == null)
							{
								_observersState.Observers = ImmutableArray<IObserver<TOutput>>.Empty;
								return null;
							}
						}
						return Disposables.Create(delegate(SourceObservable<TOutput> s, IObserver<TOutput> o)
						{
							s.Unsubscribe(o);
						}, this, observer);
					}
					ex = GetCompletionError();
				}
				if (ex != null)
				{
					observer.OnError(ex);
				}
				else
				{
					observer.OnCompleted();
				}
				return Disposables.Nop;
			}

			private void Unsubscribe(IObserver<TOutput> observer)
			{
				lock (_SubscriptionLock)
				{
					ObserversState observersState = _observersState;
					if (observersState.Observers.Contains(observer))
					{
						if (observersState.Observers.Count == 1)
						{
							ResetObserverState();
						}
						else
						{
							observersState.Observers = observersState.Observers.Remove(observer);
						}
					}
				}
			}

			private ImmutableArray<IObserver<TOutput>> ResetObserverState()
			{
				ObserversState observersState = _observersState;
				ImmutableArray<IObserver<TOutput>> observers = observersState.Observers;
				_observersState = new ObserversState(this);
				observersState.Unlinker.Dispose();
				observersState.Canceler.Cancel();
				return observers;
			}
		}

		[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
		private sealed class TargetObserver<TInput> : IObserver<TInput>, IDebuggerDisplay
		{
			private readonly ITargetBlock<TInput> _target;

			private object DebuggerDisplayContent
			{
				get
				{
					IDebuggerDisplay debuggerDisplay = _target as IDebuggerDisplay;
					return $"Block=\"{((debuggerDisplay != null) ? debuggerDisplay.Content : _target)}\"";
				}
			}

			object IDebuggerDisplay.Content => DebuggerDisplayContent;

			internal TargetObserver(ITargetBlock<TInput> target)
			{
				_target = target;
			}

			void IObserver<TInput>.OnNext(TInput value)
			{
				Task<bool> task = SendAsyncToTarget(value);
				task.GetAwaiter().GetResult();
			}

			void IObserver<TInput>.OnCompleted()
			{
				_target.Complete();
			}

			void IObserver<TInput>.OnError(Exception error)
			{
				_target.Fault(error);
			}

			internal Task<bool> SendAsyncToTarget(TInput value)
			{
				return _target.SendAsync(value);
			}
		}

		private class NullTargetBlock<TInput> : ITargetBlock<TInput>, IDataflowBlock
		{
			private Task _completion;

			Task IDataflowBlock.Completion => LazyInitializer.EnsureInitialized(ref _completion, () => new TaskCompletionSource<VoidResult>().Task);

			DataflowMessageStatus ITargetBlock<TInput>.OfferMessage(DataflowMessageHeader messageHeader, TInput messageValue, ISourceBlock<TInput> source, bool consumeToAccept)
			{
				if (!messageHeader.IsValid)
				{
					throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
				}
				if (consumeToAccept)
				{
					if (source == null)
					{
						throw new ArgumentException(SR.Argument_CantConsumeFromANullSource, "consumeToAccept");
					}
					source.ConsumeMessage(messageHeader, this, out var messageConsumed);
					if (!messageConsumed)
					{
						return DataflowMessageStatus.NotAvailable;
					}
				}
				return DataflowMessageStatus.Accepted;
			}

			void IDataflowBlock.Complete()
			{
			}

			void IDataflowBlock.Fault(Exception exception)
			{
			}
		}

		private static readonly Action<object> _cancelCts = delegate(object state)
		{
			((CancellationTokenSource)state).Cancel();
		};

		private static readonly ExecutionDataflowBlockOptions _nonGreedyExecutionOptions = new ExecutionDataflowBlockOptions
		{
			BoundedCapacity = 1
		};

		public static IDisposable LinkTo<TOutput>(this ISourceBlock<TOutput> source, ITargetBlock<TOutput> target)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			return source.LinkTo(target, DataflowLinkOptions.Default);
		}

		public static IDisposable LinkTo<TOutput>(this ISourceBlock<TOutput> source, ITargetBlock<TOutput> target, Predicate<TOutput> predicate)
		{
			return source.LinkTo(target, DataflowLinkOptions.Default, predicate);
		}

		public static IDisposable LinkTo<TOutput>(this ISourceBlock<TOutput> source, ITargetBlock<TOutput> target, DataflowLinkOptions linkOptions, Predicate<TOutput> predicate)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (linkOptions == null)
			{
				throw new ArgumentNullException("linkOptions");
			}
			if (predicate == null)
			{
				throw new ArgumentNullException("predicate");
			}
			FilteredLinkPropagator<TOutput> target2 = new FilteredLinkPropagator<TOutput>(source, target, predicate);
			return source.LinkTo(target2, linkOptions);
		}

		public static bool Post<TInput>(this ITargetBlock<TInput> target, TInput item)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			return target.OfferMessage(Common.SingleMessageHeader, item, null, consumeToAccept: false) == DataflowMessageStatus.Accepted;
		}

		public static Task<bool> SendAsync<TInput>(this ITargetBlock<TInput> target, TInput item)
		{
			return target.SendAsync(item, CancellationToken.None);
		}

		public static Task<bool> SendAsync<TInput>(this ITargetBlock<TInput> target, TInput item, CancellationToken cancellationToken)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (cancellationToken.IsCancellationRequested)
			{
				return Common.CreateTaskFromCancellation<bool>(cancellationToken);
			}
			SendAsyncSource<TInput> sendAsyncSource;
			try
			{
				switch (target.OfferMessage(Common.SingleMessageHeader, item, null, consumeToAccept: false))
				{
				case DataflowMessageStatus.Accepted:
					return Common.CompletedTaskWithTrueResult;
				case DataflowMessageStatus.DecliningPermanently:
					return Common.CompletedTaskWithFalseResult;
				default:
					sendAsyncSource = new SendAsyncSource<TInput>(target, item, cancellationToken);
					break;
				}
			}
			catch (Exception ex)
			{
				Common.StoreDataflowMessageValueIntoExceptionData(ex, item);
				return Common.CreateTaskFromException<bool>(ex);
			}
			sendAsyncSource.OfferToTarget();
			return sendAsyncSource.Task;
		}

		public static bool TryReceive<TOutput>(this IReceivableSourceBlock<TOutput> source, out TOutput item)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return source.TryReceive(null, out item);
		}

		public static Task<TOutput> ReceiveAsync<TOutput>(this ISourceBlock<TOutput> source)
		{
			return source.ReceiveAsync(Common.InfiniteTimeSpan, CancellationToken.None);
		}

		public static Task<TOutput> ReceiveAsync<TOutput>(this ISourceBlock<TOutput> source, CancellationToken cancellationToken)
		{
			return source.ReceiveAsync(Common.InfiniteTimeSpan, cancellationToken);
		}

		public static Task<TOutput> ReceiveAsync<TOutput>(this ISourceBlock<TOutput> source, TimeSpan timeout)
		{
			return source.ReceiveAsync(timeout, CancellationToken.None);
		}

		public static Task<TOutput> ReceiveAsync<TOutput>(this ISourceBlock<TOutput> source, TimeSpan timeout, CancellationToken cancellationToken)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (!Common.IsValidTimeout(timeout))
			{
				throw new ArgumentOutOfRangeException("timeout", SR.ArgumentOutOfRange_NeedNonNegOrNegative1);
			}
			return source.ReceiveCore(attemptTryReceive: true, timeout, cancellationToken);
		}

		public static TOutput Receive<TOutput>(this ISourceBlock<TOutput> source)
		{
			return source.Receive(Common.InfiniteTimeSpan, CancellationToken.None);
		}

		public static TOutput Receive<TOutput>(this ISourceBlock<TOutput> source, CancellationToken cancellationToken)
		{
			return source.Receive(Common.InfiniteTimeSpan, cancellationToken);
		}

		public static TOutput Receive<TOutput>(this ISourceBlock<TOutput> source, TimeSpan timeout)
		{
			return source.Receive(timeout, CancellationToken.None);
		}

		public static TOutput Receive<TOutput>(this ISourceBlock<TOutput> source, TimeSpan timeout, CancellationToken cancellationToken)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (!Common.IsValidTimeout(timeout))
			{
				throw new ArgumentOutOfRangeException("timeout", SR.ArgumentOutOfRange_NeedNonNegOrNegative1);
			}
			cancellationToken.ThrowIfCancellationRequested();
			if (source is IReceivableSourceBlock<TOutput> receivableSourceBlock && receivableSourceBlock.TryReceive(null, out var item))
			{
				return item;
			}
			Task<TOutput> task = source.ReceiveCore(attemptTryReceive: false, timeout, cancellationToken);
			try
			{
				return task.GetAwaiter().GetResult();
			}
			catch
			{
				if (task.IsCanceled)
				{
					cancellationToken.ThrowIfCancellationRequested();
				}
				throw;
			}
		}

		private static Task<TOutput> ReceiveCore<TOutput>(this ISourceBlock<TOutput> source, bool attemptTryReceive, TimeSpan timeout, CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				return Common.CreateTaskFromCancellation<TOutput>(cancellationToken);
			}
			if (attemptTryReceive && source is IReceivableSourceBlock<TOutput> receivableSourceBlock)
			{
				try
				{
					if (receivableSourceBlock.TryReceive(null, out var item))
					{
						return Task.FromResult(item);
					}
				}
				catch (Exception exception)
				{
					return Common.CreateTaskFromException<TOutput>(exception);
				}
			}
			int num = (int)timeout.TotalMilliseconds;
			if (num == 0)
			{
				return Common.CreateTaskFromException<TOutput>(ReceiveTarget<TOutput>.CreateExceptionForTimeout());
			}
			return ReceiveCoreByLinking(source, num, cancellationToken);
		}

		private static Task<TOutput> ReceiveCoreByLinking<TOutput>(ISourceBlock<TOutput> source, int millisecondsTimeout, CancellationToken cancellationToken)
		{
			ReceiveTarget<TOutput> receiveTarget = new ReceiveTarget<TOutput>();
			try
			{
				if (cancellationToken.CanBeCanceled)
				{
					receiveTarget._externalCancellationToken = cancellationToken;
					receiveTarget._regFromExternalCancellationToken = cancellationToken.Register(_cancelCts, receiveTarget._cts);
				}
				if (millisecondsTimeout > 0)
				{
					receiveTarget._timer = new Timer(ReceiveTarget<TOutput>.CachedLinkingTimerCallback, receiveTarget, millisecondsTimeout, -1);
				}
				if (receiveTarget._cts.Token.CanBeCanceled)
				{
					receiveTarget._cts.Token.Register(ReceiveTarget<TOutput>.CachedLinkingCancellationCallback, receiveTarget);
				}
				IDisposable comparand = (receiveTarget._unlink = source.LinkTo(receiveTarget, DataflowLinkOptions.UnlinkAfterOneAndPropagateCompletion));
				if (Volatile.Read(ref receiveTarget._cleanupReserved))
				{
					Interlocked.CompareExchange(ref receiveTarget._unlink, null, comparand)?.Dispose();
				}
			}
			catch (Exception receivedException)
			{
				receiveTarget._receivedException = receivedException;
				receiveTarget.TryCleanupAndComplete(ReceiveCoreByLinkingCleanupReason.SourceProtocolError);
			}
			return receiveTarget.Task;
		}

		public static Task<bool> OutputAvailableAsync<TOutput>(this ISourceBlock<TOutput> source)
		{
			return source.OutputAvailableAsync(CancellationToken.None);
		}

		public static Task<bool> OutputAvailableAsync<TOutput>(this ISourceBlock<TOutput> source, CancellationToken cancellationToken)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			if (cancellationToken.IsCancellationRequested)
			{
				return Common.CreateTaskFromCancellation<bool>(cancellationToken);
			}
			OutputAvailableAsyncTarget<TOutput> outputAvailableAsyncTarget = new OutputAvailableAsyncTarget<TOutput>();
			try
			{
				outputAvailableAsyncTarget._unlinker = source.LinkTo(outputAvailableAsyncTarget, DataflowLinkOptions.UnlinkAfterOneAndPropagateCompletion);
				if (outputAvailableAsyncTarget.Task.IsCompleted)
				{
					return outputAvailableAsyncTarget.Task;
				}
				if (cancellationToken.CanBeCanceled)
				{
					outputAvailableAsyncTarget._ctr = cancellationToken.Register(OutputAvailableAsyncTarget<TOutput>.s_cancelAndUnlink, outputAvailableAsyncTarget);
				}
				return outputAvailableAsyncTarget.Task.ContinueWith(OutputAvailableAsyncTarget<TOutput>.s_handleCompletion, outputAvailableAsyncTarget, CancellationToken.None, Common.GetContinuationOptions() | TaskContinuationOptions.NotOnCanceled, TaskScheduler.Default);
			}
			catch (Exception exception)
			{
				outputAvailableAsyncTarget.TrySetException(exception);
				outputAvailableAsyncTarget.AttemptThreadSafeUnlink();
				return outputAvailableAsyncTarget.Task;
			}
		}

		public static IPropagatorBlock<TInput, TOutput> Encapsulate<TInput, TOutput>(ITargetBlock<TInput> target, ISourceBlock<TOutput> source)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return new EncapsulatingPropagator<TInput, TOutput>(target, source);
		}

		public static Task<int> Choose<T1, T2>(ISourceBlock<T1> source1, Action<T1> action1, ISourceBlock<T2> source2, Action<T2> action2)
		{
			return Choose(source1, action1, source2, action2, DataflowBlockOptions.Default);
		}

		public static Task<int> Choose<T1, T2>(ISourceBlock<T1> source1, Action<T1> action1, ISourceBlock<T2> source2, Action<T2> action2, DataflowBlockOptions dataflowBlockOptions)
		{
			if (source1 == null)
			{
				throw new ArgumentNullException("source1");
			}
			if (action1 == null)
			{
				throw new ArgumentNullException("action1");
			}
			if (source2 == null)
			{
				throw new ArgumentNullException("source2");
			}
			if (action2 == null)
			{
				throw new ArgumentNullException("action2");
			}
			if (dataflowBlockOptions == null)
			{
				throw new ArgumentNullException("dataflowBlockOptions");
			}
			return ChooseCore<T1, T2, VoidResult>(source1, action1, source2, action2, null, null, dataflowBlockOptions);
		}

		public static Task<int> Choose<T1, T2, T3>(ISourceBlock<T1> source1, Action<T1> action1, ISourceBlock<T2> source2, Action<T2> action2, ISourceBlock<T3> source3, Action<T3> action3)
		{
			return Choose(source1, action1, source2, action2, source3, action3, DataflowBlockOptions.Default);
		}

		public static Task<int> Choose<T1, T2, T3>(ISourceBlock<T1> source1, Action<T1> action1, ISourceBlock<T2> source2, Action<T2> action2, ISourceBlock<T3> source3, Action<T3> action3, DataflowBlockOptions dataflowBlockOptions)
		{
			if (source1 == null)
			{
				throw new ArgumentNullException("source1");
			}
			if (action1 == null)
			{
				throw new ArgumentNullException("action1");
			}
			if (source2 == null)
			{
				throw new ArgumentNullException("source2");
			}
			if (action2 == null)
			{
				throw new ArgumentNullException("action2");
			}
			if (source3 == null)
			{
				throw new ArgumentNullException("source3");
			}
			if (action3 == null)
			{
				throw new ArgumentNullException("action3");
			}
			if (dataflowBlockOptions == null)
			{
				throw new ArgumentNullException("dataflowBlockOptions");
			}
			return ChooseCore(source1, action1, source2, action2, source3, action3, dataflowBlockOptions);
		}

		private static Task<int> ChooseCore<T1, T2, T3>(ISourceBlock<T1> source1, Action<T1> action1, ISourceBlock<T2> source2, Action<T2> action2, ISourceBlock<T3> source3, Action<T3> action3, DataflowBlockOptions dataflowBlockOptions)
		{
			bool flag = source3 != null;
			if (dataflowBlockOptions.CancellationToken.IsCancellationRequested)
			{
				return Common.CreateTaskFromCancellation<int>(dataflowBlockOptions.CancellationToken);
			}
			try
			{
				TaskScheduler taskScheduler = dataflowBlockOptions.TaskScheduler;
				if (TryChooseFromSource(source1, action1, 0, taskScheduler, out var task) || TryChooseFromSource(source2, action2, 1, taskScheduler, out task) || (flag && TryChooseFromSource(source3, action3, 2, taskScheduler, out task)))
				{
					return task;
				}
			}
			catch (Exception exception)
			{
				return Common.CreateTaskFromException<int>(exception);
			}
			return ChooseCoreByLinking(source1, action1, source2, action2, source3, action3, dataflowBlockOptions);
		}

		private static bool TryChooseFromSource<T>(ISourceBlock<T> source, Action<T> action, int branchId, TaskScheduler scheduler, out Task<int> task)
		{
			if (!(source is IReceivableSourceBlock<T> source2) || !source2.TryReceive(out var item))
			{
				task = null;
				return false;
			}
			task = Task.Factory.StartNew(ChooseTarget<T>.s_processBranchFunction, Tuple.Create(action, item, branchId), CancellationToken.None, Common.GetCreationOptionsForTask(), scheduler);
			return true;
		}

		private static Task<int> ChooseCoreByLinking<T1, T2, T3>(ISourceBlock<T1> source1, Action<T1> action1, ISourceBlock<T2> source2, Action<T2> action2, ISourceBlock<T3> source3, Action<T3> action3, DataflowBlockOptions dataflowBlockOptions)
		{
			bool flag = source3 != null;
			StrongBox<Task> boxedCompleted = new StrongBox<Task>();
			CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(dataflowBlockOptions.CancellationToken, CancellationToken.None);
			TaskScheduler taskScheduler = dataflowBlockOptions.TaskScheduler;
			Task<int>[] array = new Task<int>[flag ? 3 : 2];
			array[0] = CreateChooseBranch(boxedCompleted, cts, taskScheduler, 0, source1, action1);
			array[1] = CreateChooseBranch(boxedCompleted, cts, taskScheduler, 1, source2, action2);
			if (flag)
			{
				array[2] = CreateChooseBranch(boxedCompleted, cts, taskScheduler, 2, source3, action3);
			}
			TaskCompletionSource<int> result = new TaskCompletionSource<int>();
			Task.Factory.ContinueWhenAll(array, delegate(Task<int>[] tasks)
			{
				List<Exception> list = null;
				int num = -1;
				foreach (Task<int> task in tasks)
				{
					switch (task.Status)
					{
					case TaskStatus.Faulted:
						Common.AddException(ref list, task.Exception, unwrapInnerExceptions: true);
						break;
					case TaskStatus.RanToCompletion:
					{
						int result2 = task.Result;
						if (result2 >= 0)
						{
							num = result2;
						}
						break;
					}
					}
				}
				if (list != null)
				{
					result.TrySetException(list);
				}
				else if (num >= 0)
				{
					result.TrySetResult(num);
				}
				else
				{
					result.TrySetCanceled();
				}
				cts.Dispose();
			}, CancellationToken.None, Common.GetContinuationOptions(), TaskScheduler.Default);
			return result.Task;
		}

		private static Task<int> CreateChooseBranch<T>(StrongBox<Task> boxedCompleted, CancellationTokenSource cts, TaskScheduler scheduler, int branchId, ISourceBlock<T> source, Action<T> action)
		{
			if (cts.IsCancellationRequested)
			{
				return Common.CreateTaskFromCancellation<int>(cts.Token);
			}
			ChooseTarget<T> chooseTarget = new ChooseTarget<T>(boxedCompleted, cts.Token);
			IDisposable unlink;
			try
			{
				unlink = source.LinkTo(chooseTarget, DataflowLinkOptions.UnlinkAfterOneAndPropagateCompletion);
			}
			catch (Exception exception)
			{
				cts.Cancel();
				return Common.CreateTaskFromException<int>(exception);
			}
			return chooseTarget.Task.ContinueWith(delegate(Task<T> completed)
			{
				try
				{
					if (completed.Status == TaskStatus.RanToCompletion)
					{
						cts.Cancel();
						action(completed.Result);
						return branchId;
					}
					return -1;
				}
				finally
				{
					unlink.Dispose();
				}
			}, CancellationToken.None, Common.GetContinuationOptions(), scheduler);
		}

		public static IObservable<TOutput> AsObservable<TOutput>(this ISourceBlock<TOutput> source)
		{
			if (source == null)
			{
				throw new ArgumentNullException("source");
			}
			return SourceObservable<TOutput>.From(source);
		}

		public static IObserver<TInput> AsObserver<TInput>(this ITargetBlock<TInput> target)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			return new TargetObserver<TInput>(target);
		}

		public static ITargetBlock<TInput> NullTarget<TInput>()
		{
			return new NullTargetBlock<TInput>();
		}
	}
	[DebuggerDisplay("TaskScheduler = {TaskScheduler}, MaxMessagesPerTask = {MaxMessagesPerTask}, BoundedCapacity = {BoundedCapacity}")]
	public class DataflowBlockOptions
	{
		public const int Unbounded = -1;

		private TaskScheduler _taskScheduler = TaskScheduler.Default;

		private CancellationToken _cancellationToken = CancellationToken.None;

		private int _maxMessagesPerTask = -1;

		private int _boundedCapacity = -1;

		private string _nameFormat = "{0} Id={1}";

		private bool _ensureOrdered = true;

		internal static readonly DataflowBlockOptions Default = new DataflowBlockOptions();

		public TaskScheduler TaskScheduler
		{
			get
			{
				return _taskScheduler;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				_taskScheduler = value;
			}
		}

		public CancellationToken CancellationToken
		{
			get
			{
				return _cancellationToken;
			}
			set
			{
				_cancellationToken = value;
			}
		}

		public int MaxMessagesPerTask
		{
			get
			{
				return _maxMessagesPerTask;
			}
			set
			{
				if (value < 1 && value != -1)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_maxMessagesPerTask = value;
			}
		}

		internal int ActualMaxMessagesPerTask
		{
			get
			{
				if (_maxMessagesPerTask != -1)
				{
					return _maxMessagesPerTask;
				}
				return 2147483647;
			}
		}

		public int BoundedCapacity
		{
			get
			{
				return _boundedCapacity;
			}
			set
			{
				if (value < 1 && value != -1)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_boundedCapacity = value;
			}
		}

		public string NameFormat
		{
			get
			{
				return _nameFormat;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				_nameFormat = value;
			}
		}

		public bool EnsureOrdered
		{
			get
			{
				return _ensureOrdered;
			}
			set
			{
				_ensureOrdered = value;
			}
		}

		internal DataflowBlockOptions DefaultOrClone()
		{
			if (this != Default)
			{
				return new DataflowBlockOptions
				{
					TaskScheduler = TaskScheduler,
					CancellationToken = CancellationToken,
					MaxMessagesPerTask = MaxMessagesPerTask,
					BoundedCapacity = BoundedCapacity,
					NameFormat = NameFormat,
					EnsureOrdered = EnsureOrdered
				};
			}
			return this;
		}
	}
	[DebuggerDisplay("TaskScheduler = {TaskScheduler}, MaxMessagesPerTask = {MaxMessagesPerTask}, BoundedCapacity = {BoundedCapacity}, MaxDegreeOfParallelism = {MaxDegreeOfParallelism}")]
	public class ExecutionDataflowBlockOptions : DataflowBlockOptions
	{
		internal new static readonly ExecutionDataflowBlockOptions Default = new ExecutionDataflowBlockOptions();

		private int _maxDegreeOfParallelism = 1;

		private bool _singleProducerConstrained;

		public int MaxDegreeOfParallelism
		{
			get
			{
				return _maxDegreeOfParallelism;
			}
			set
			{
				if (value < 1 && value != -1)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_maxDegreeOfParallelism = value;
			}
		}

		public bool SingleProducerConstrained
		{
			get
			{
				return _singleProducerConstrained;
			}
			set
			{
				_singleProducerConstrained = value;
			}
		}

		internal int ActualMaxDegreeOfParallelism
		{
			get
			{
				if (_maxDegreeOfParallelism != -1)
				{
					return _maxDegreeOfParallelism;
				}
				return 2147483647;
			}
		}

		internal bool SupportsParallelExecution
		{
			get
			{
				if (_maxDegreeOfParallelism != -1)
				{
					return _maxDegreeOfParallelism > 1;
				}
				return true;
			}
		}

		internal new ExecutionDataflowBlockOptions DefaultOrClone()
		{
			if (this != Default)
			{
				return new ExecutionDataflowBlockOptions
				{
					TaskScheduler = base.TaskScheduler,
					CancellationToken = base.CancellationToken,
					MaxMessagesPerTask = base.MaxMessagesPerTask,
					BoundedCapacity = base.BoundedCapacity,
					NameFormat = base.NameFormat,
					EnsureOrdered = base.EnsureOrdered,
					MaxDegreeOfParallelism = MaxDegreeOfParallelism,
					SingleProducerConstrained = SingleProducerConstrained
				};
			}
			return this;
		}
	}
	[DebuggerDisplay("TaskScheduler = {TaskScheduler}, MaxMessagesPerTask = {MaxMessagesPerTask}, BoundedCapacity = {BoundedCapacity}, Greedy = {Greedy}, MaxNumberOfGroups = {MaxNumberOfGroups}")]
	public class GroupingDataflowBlockOptions : DataflowBlockOptions
	{
		internal new static readonly GroupingDataflowBlockOptions Default = new GroupingDataflowBlockOptions();

		private bool _greedy = true;

		private long _maxNumberOfGroups = -1L;

		public bool Greedy
		{
			get
			{
				return _greedy;
			}
			set
			{
				_greedy = value;
			}
		}

		public long MaxNumberOfGroups
		{
			get
			{
				return _maxNumberOfGroups;
			}
			set
			{
				if (value <= 0 && value != -1)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_maxNumberOfGroups = value;
			}
		}

		internal long ActualMaxNumberOfGroups
		{
			get
			{
				if (_maxNumberOfGroups != -1)
				{
					return _maxNumberOfGroups;
				}
				return 9223372036854775807L;
			}
		}

		internal new GroupingDataflowBlockOptions DefaultOrClone()
		{
			if (this != Default)
			{
				return new GroupingDataflowBlockOptions
				{
					TaskScheduler = base.TaskScheduler,
					CancellationToken = base.CancellationToken,
					MaxMessagesPerTask = base.MaxMessagesPerTask,
					BoundedCapacity = base.BoundedCapacity,
					NameFormat = base.NameFormat,
					EnsureOrdered = base.EnsureOrdered,
					Greedy = Greedy,
					MaxNumberOfGroups = MaxNumberOfGroups
				};
			}
			return this;
		}
	}
	[DebuggerDisplay("PropagateCompletion = {PropagateCompletion}, MaxMessages = {MaxMessages}, Append = {Append}")]
	public class DataflowLinkOptions
	{
		private bool _propagateCompletion;

		private int _maxNumberOfMessages = -1;

		private bool _append = true;

		internal static readonly DataflowLinkOptions Default = new DataflowLinkOptions();

		internal static readonly DataflowLinkOptions UnlinkAfterOneAndPropagateCompletion = new DataflowLinkOptions
		{
			MaxMessages = 1,
			PropagateCompletion = true
		};

		public bool PropagateCompletion
		{
			get
			{
				return _propagateCompletion;
			}
			set
			{
				_propagateCompletion = value;
			}
		}

		public int MaxMessages
		{
			get
			{
				return _maxNumberOfMessages;
			}
			set
			{
				if (value < 1 && value != -1)
				{
					throw new ArgumentOutOfRangeException("value");
				}
				_maxNumberOfMessages = value;
			}
		}

		public bool Append
		{
			get
			{
				return _append;
			}
			set
			{
				_append = value;
			}
		}
	}
	[DebuggerDisplay("Id = {Id}")]
	public readonly struct DataflowMessageHeader : IEquatable<DataflowMessageHeader>
	{
		private readonly long _id;

		public bool IsValid => _id != 0;

		public long Id => _id;

		public DataflowMessageHeader(long id)
		{
			if (id == 0L)
			{
				throw new ArgumentException(SR.Argument_InvalidMessageId, "id");
			}
			_id = id;
		}

		public bool Equals(DataflowMessageHeader other)
		{
			return this == other;
		}

		public override bool Equals(object obj)
		{
			if (obj is DataflowMessageHeader)
			{
				return this == (DataflowMessageHeader)obj;
			}
			return false;
		}

		public override int GetHashCode()
		{
			return (int)Id;
		}

		public static bool operator ==(DataflowMessageHeader left, DataflowMessageHeader right)
		{
			return left.Id == right.Id;
		}

		public static bool operator !=(DataflowMessageHeader left, DataflowMessageHeader right)
		{
			return left.Id != right.Id;
		}
	}
	public enum DataflowMessageStatus
	{
		Accepted,
		Declined,
		Postponed,
		NotAvailable,
		DecliningPermanently
	}
	public interface IDataflowBlock
	{
		Task Completion { get; }

		void Complete();

		void Fault(Exception exception);
	}
	public interface IPropagatorBlock<in TInput, out TOutput> : ITargetBlock<TInput>, IDataflowBlock, ISourceBlock<TOutput>
	{
	}
	public interface IReceivableSourceBlock<TOutput> : ISourceBlock<TOutput>, IDataflowBlock
	{
		bool TryReceive(Predicate<TOutput> filter, out TOutput item);

		bool TryReceiveAll(out IList<TOutput> items);
	}
	public interface ISourceBlock<out TOutput> : IDataflowBlock
	{
		IDisposable LinkTo(ITargetBlock<TOutput> target, DataflowLinkOptions linkOptions);

		TOutput ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target, out bool messageConsumed);

		bool ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target);

		void ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target);
	}
	public interface ITargetBlock<in TInput> : IDataflowBlock
	{
		DataflowMessageStatus OfferMessage(DataflowMessageHeader messageHeader, TInput messageValue, ISourceBlock<TInput> source, bool consumeToAccept);
	}
	[DebuggerTypeProxy(typeof(ActionBlock<>.DebugView))]
	[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
	public sealed class ActionBlock<TInput> : ITargetBlock<TInput>, IDataflowBlock, IDebuggerDisplay
	{
		private sealed class DebugView
		{
			private readonly ActionBlock<TInput> _actionBlock;

			private readonly TargetCore<TInput>.DebuggingInformation _defaultDebugInfo;

			private readonly SpscTargetCore<TInput>.DebuggingInformation _spscDebugInfo;

			public IEnumerable<TInput> InputQueue
			{
				get
				{
					if (_defaultDebugInfo == null)
					{
						return _spscDebugInfo.InputQueue;
					}
					return _defaultDebugInfo.InputQueue;
				}
			}

			public QueuedMap<ISourceBlock<TInput>, DataflowMessageHeader> PostponedMessages
			{
				get
				{
					if (_defaultDebugInfo == null)
					{
						return null;
					}
					return _defaultDebugInfo.PostponedMessages;
				}
			}

			public int CurrentDegreeOfParallelism
			{
				get
				{
					if (_defaultDebugInfo == null)
					{
						return _spscDebugInfo.CurrentDegreeOfParallelism;
					}
					return _defaultDebugInfo.CurrentDegreeOfParallelism;
				}
			}

			public ExecutionDataflowBlockOptions DataflowBlockOptions
			{
				get
				{
					if (_defaultDebugInfo == null)
					{
						return _spscDebugInfo.DataflowBlockOptions;
					}
					return _defaultDebugInfo.DataflowBlockOptions;
				}
			}

			public bool IsDecliningPermanently
			{
				get
				{
					if (_defaultDebugInfo == null)
					{
						return _spscDebugInfo.IsDecliningPermanently;
					}
					return _defaultDebugInfo.IsDecliningPermanently;
				}
			}

			public bool IsCompleted
			{
				get
				{
					if (_defaultDebugInfo == null)
					{
						return _spscDebugInfo.IsCompleted;
					}
					return _defaultDebugInfo.IsCompleted;
				}
			}

			public int Id => Common.GetBlockId(_actionBlock);

			public DebugView(ActionBlock<TInput> actionBlock)
			{
				_actionBlock = actionBlock;
				if (_actionBlock._defaultTarget != null)
				{
					_defaultDebugInfo = actionBlock._defaultTarget.GetDebuggingInformation();
				}
				else
				{
					_spscDebugInfo = actionBlock._spscTarget.GetDebuggingInformation();
				}
			}
		}

		private readonly TargetCore<TInput> _defaultTarget;

		private readonly SpscTargetCore<TInput> _spscTarget;

		public Task Completion
		{
			get
			{
				if (_defaultTarget == null)
				{
					return _spscTarget.Completion;
				}
				return _defaultTarget.Completion;
			}
		}

		public int InputCount
		{
			get
			{
				if (_defaultTarget == null)
				{
					return _spscTarget.InputCount;
				}
				return _defaultTarget.InputCount;
			}
		}

		private int InputCountForDebugger
		{
			get
			{
				if (_defaultTarget == null)
				{
					return _spscTarget.InputCount;
				}
				return _defaultTarget.GetDebuggingInformation().InputCount;
			}
		}

		private object DebuggerDisplayContent => $"{Common.GetNameForDebugger(this, (_defaultTarget != null) ? _defaultTarget.DataflowBlockOptions : _spscTarget.DataflowBlockOptions)}, InputCount={InputCountForDebugger}";

		object IDebuggerDisplay.Content => DebuggerDisplayContent;

		public ActionBlock(Action<TInput> action)
			: this((Delegate)action, ExecutionDataflowBlockOptions.Default)
		{
		}

		public ActionBlock(Action<TInput> action, ExecutionDataflowBlockOptions dataflowBlockOptions)
			: this((Delegate)action, dataflowBlockOptions)
		{
		}

		public ActionBlock(Func<TInput, Task> action)
			: this((Delegate)action, ExecutionDataflowBlockOptions.Default)
		{
		}

		public ActionBlock(Func<TInput, Task> action, ExecutionDataflowBlockOptions dataflowBlockOptions)
			: this((Delegate)action, dataflowBlockOptions)
		{
		}

		private ActionBlock(Delegate action, ExecutionDataflowBlockOptions dataflowBlockOptions)
		{
			ActionBlock<TInput> actionBlock = this;
			if ((object)action == null)
			{
				throw new ArgumentNullException("action");
			}
			if (dataflowBlockOptions == null)
			{
				throw new ArgumentNullException("dataflowBlockOptions");
			}
			dataflowBlockOptions = dataflowBlockOptions.DefaultOrClone();
			Action<TInput> syncAction = action as Action<TInput>;
			if (syncAction != null && dataflowBlockOptions.SingleProducerConstrained && dataflowBlockOptions.MaxDegreeOfParallelism == 1 && !dataflowBlockOptions.CancellationToken.CanBeCanceled && dataflowBlockOptions.BoundedCapacity == -1)
			{
				_spscTarget = new SpscTargetCore<TInput>(this, syncAction, dataflowBlockOptions);
			}
			else
			{
				if (syncAction != null)
				{
					_defaultTarget = new TargetCore<TInput>(this, delegate(KeyValuePair<TInput, long> messageWithId)
					{
						actionBlock.ProcessMessage(syncAction, messageWithId);
					}, null, dataflowBlockOptions, TargetCoreOptions.RepresentsBlockCompletion);
				}
				else
				{
					Func<TInput, Task> asyncAction = action as Func<TInput, Task>;
					_defaultTarget = new TargetCore<TInput>(this, delegate(KeyValuePair<TInput, long> messageWithId)
					{
						actionBlock.ProcessMessageWithTask(asyncAction, messageWithId);
					}, null, dataflowBlockOptions, TargetCoreOptions.UsesAsyncCompletion | TargetCoreOptions.RepresentsBlockCompletion);
				}
				Common.WireCancellationToComplete(dataflowBlockOptions.CancellationToken, Completion, delegate(object state)
				{
					((TargetCore<TInput>)state).Complete(null, dropPendingMessages: true);
				}, _defaultTarget);
			}
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.DataflowBlockCreated(this, dataflowBlockOptions);
			}
		}

		private void ProcessMessage(Action<TInput> action, KeyValuePair<TInput, long> messageWithId)
		{
			try
			{
				action(messageWithId.Key);
			}
			catch (Exception exception)
			{
				if (!Common.IsCooperativeCancellation(exception))
				{
					throw;
				}
			}
			finally
			{
				if (_defaultTarget.IsBounded)
				{
					_defaultTarget.ChangeBoundingCount(-1);
				}
			}
		}

		private void ProcessMessageWithTask(Func<TInput, Task> action, KeyValuePair<TInput, long> messageWithId)
		{
			Task task = null;
			Exception ex = null;
			try
			{
				task = action(messageWithId.Key);
			}
			catch (Exception ex2)
			{
				ex = ex2;
			}
			if (task == null)
			{
				if (ex != null && !Common.IsCooperativeCancellation(ex))
				{
					Common.StoreDataflowMessageValueIntoExceptionData(ex, messageWithId.Key);
					_defaultTarget.Complete(ex, dropPendingMessages: true, storeExceptionEvenIfAlreadyCompleting: true);
				}
				_defaultTarget.SignalOneAsyncMessageCompleted(-1);
			}
			else if (task.IsCompleted)
			{
				AsyncCompleteProcessMessageWithTask(task);
			}
			else
			{
				task.ContinueWith(delegate(Task completed, object state)
				{
					((ActionBlock<TInput>)state).AsyncCompleteProcessMessageWithTask(completed);
				}, this, CancellationToken.None, Common.GetContinuationOptions(TaskContinuationOptions.ExecuteSynchronously), TaskScheduler.Default);
			}
		}

		private void AsyncCompleteProcessMessageWithTask(Task completed)
		{
			if (completed.IsFaulted)
			{
				_defaultTarget.Complete(completed.Exception, dropPendingMessages: true, storeExceptionEvenIfAlreadyCompleting: true, unwrapInnerExceptions: true);
			}
			_defaultTarget.SignalOneAsyncMessageCompleted(-1);
		}

		public void Complete()
		{
			if (_defaultTarget != null)
			{
				_defaultTarget.Complete(null, dropPendingMessages: false);
			}
			else
			{
				_spscTarget.Complete(null);
			}
		}

		void IDataflowBlock.Fault(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			if (_defaultTarget != null)
			{
				_defaultTarget.Complete(exception, dropPendingMessages: true);
			}
			else
			{
				_spscTarget.Complete(exception);
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining)]
		public bool Post(TInput item)
		{
			if (_defaultTarget == null)
			{
				return _spscTarget.Post(item);
			}
			return _defaultTarget.OfferMessage(Common.SingleMessageHeader, item, null, consumeToAccept: false) == DataflowMessageStatus.Accepted;
		}

		DataflowMessageStatus ITargetBlock<TInput>.OfferMessage(DataflowMessageHeader messageHeader, TInput messageValue, ISourceBlock<TInput> source, bool consumeToAccept)
		{
			if (_defaultTarget == null)
			{
				return _spscTarget.OfferMessage(messageHeader, messageValue, source, consumeToAccept);
			}
			return _defaultTarget.OfferMessage(messageHeader, messageValue, source, consumeToAccept);
		}

		public override string ToString()
		{
			return Common.GetNameForDebugger(this, (_defaultTarget != null) ? _defaultTarget.DataflowBlockOptions : _spscTarget.DataflowBlockOptions);
		}
	}
	[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
	[DebuggerTypeProxy(typeof(BatchBlock<>.DebugView))]
	public sealed class BatchBlock<T> : IPropagatorBlock<T, T[]>, ITargetBlock<T>, IDataflowBlock, ISourceBlock<T[]>, IReceivableSourceBlock<T[]>, IDebuggerDisplay
	{
		private sealed class DebugView
		{
			private BatchBlock<T> _batchBlock;

			private readonly BatchBlockTargetCore.DebuggingInformation _targetDebuggingInformation;

			private readonly SourceCore<T[]>.DebuggingInformation _sourceDebuggingInformation;

			public IEnumerable<T> InputQueue => _targetDebuggingInformation.InputQueue;

			public IEnumerable<T[]> OutputQueue => _sourceDebuggingInformation.OutputQueue;

			public long BatchesCompleted => _targetDebuggingInformation.NumberOfBatchesCompleted;

			public Task TaskForInputProcessing => _targetDebuggingInformation.TaskForInputProcessing;

			public Task TaskForOutputProcessing => _sourceDebuggingInformation.TaskForOutputProcessing;

			public GroupingDataflowBlockOptions DataflowBlockOptions => _targetDebuggingInformation.DataflowBlockOptions;

			public int BatchSize => _batchBlock.BatchSize;

			public bool IsDecliningPermanently => _targetDebuggingInformation.IsDecliningPermanently;

			public bool IsCompleted => _sourceDebuggingInformation.IsCompleted;

			public int Id => Common.GetBlockId(_batchBlock);

			public QueuedMap<ISourceBlock<T>, DataflowMessageHeader> PostponedMessages => _targetDebuggingInformation.PostponedMessages;

			public TargetRegistry<T[]> LinkedTargets => _sourceDebuggingInformation.LinkedTargets;

			public ITargetBlock<T[]> NextMessageReservedFor => _sourceDebuggingInformation.NextMessageReservedFor;

			public DebugView(BatchBlock<T> batchBlock)
			{
				_batchBlock = batchBlock;
				_targetDebuggingInformation = batchBlock._target.GetDebuggingInformation();
				_sourceDebuggingInformation = batchBlock._source.GetDebuggingInformation();
			}
		}

		[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
		private sealed class BatchBlockTargetCore
		{
			private sealed class NonGreedyState
			{
				internal readonly QueuedMap<ISourceBlock<T>, DataflowMessageHeader> PostponedMessages;

				internal readonly KeyValuePair<ISourceBlock<T>, DataflowMessageHeader>[] PostponedMessagesTemp;

				internal readonly List<KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>> ReservedSourcesTemp;

				internal bool AcceptFewerThanBatchSize;

				internal Task TaskForInputProcessing;

				internal NonGreedyState(int batchSize)
				{
					PostponedMessages = new QueuedMap<ISourceBlock<T>, DataflowMessageHeader>(batchSize);
					PostponedMessagesTemp = new KeyValuePair<ISourceBlock<T>, DataflowMessageHeader>[batchSize];
					ReservedSourcesTemp = new List<KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>>(batchSize);
				}
			}

			internal sealed class DebuggingInformation
			{
				private BatchBlockTargetCore _target;

				public IEnumerable<T> InputQueue => _target._messages.ToList();

				public Task TaskForInputProcessing
				{
					get
					{
						if (_target._nonGreedyState == null)
						{
							return null;
						}
						return _target._nonGreedyState.TaskForInputProcessing;
					}
				}

				public QueuedMap<ISourceBlock<T>, DataflowMessageHeader> PostponedMessages
				{
					get
					{
						if (_target._nonGreedyState == null)
						{
							return null;
						}
						return _target._nonGreedyState.PostponedMessages;
					}
				}

				public bool IsDecliningPermanently => _target._decliningPermanently;

				public GroupingDataflowBlockOptions DataflowBlockOptions => _target._dataflowBlockOptions;

				public long NumberOfBatchesCompleted => _target._batchesCompleted;

				public DebuggingInformation(BatchBlockTargetCore target)
				{
					_target = target;
				}
			}

			private readonly Queue<T> _messages = new Queue<T>();

			private readonly TaskCompletionSource<VoidResult> _completionTask = new TaskCompletionSource<VoidResult>();

			private readonly BatchBlock<T> _owningBatch;

			private readonly int _batchSize;

			private readonly NonGreedyState _nonGreedyState;

			private readonly BoundingState _boundingState;

			private readonly GroupingDataflowBlockOptions _dataflowBlockOptions;

			private readonly Action<T[]> _batchCompletedAction;

			private bool _decliningPermanently;

			private long _batchesCompleted;

			private bool _completionReserved;

			private object IncomingLock => _completionTask;

			internal Task Completion => _completionTask.Task;

			internal int BatchSize => _batchSize;

			private bool CanceledOrFaulted
			{
				get
				{
					if (!_dataflowBlockOptions.CancellationToken.IsCancellationRequested)
					{
						return _owningBatch._source.HasExceptions;
					}
					return true;
				}
			}

			private int BoundedCapacityAvailable
			{
				get
				{
					if (_boundingState == null)
					{
						return _batchSize;
					}
					return _dataflowBlockOptions.BoundedCapacity - _boundingState.CurrentCount;
				}
			}

			private bool BatchesNeedProcessing
			{
				get
				{
					bool flag = _batchesCompleted >= _dataflowBlockOptions.ActualMaxNumberOfGroups;
					bool flag2 = _nonGreedyState != null && _nonGreedyState.TaskForInputProcessing != null;
					if (flag || flag2 || CanceledOrFaulted)
					{
						return false;
					}
					int num = _batchSize - _messages.Count;
					int boundedCapacityAvailable = BoundedCapacityAvailable;
					if (num <= 0)
					{
						return true;
					}
					if (_nonGreedyState != null)
					{
						if (_nonGreedyState.AcceptFewerThanBatchSize && (_messages.Count > 0 || (_nonGreedyState.PostponedMessages.Count > 0 && boundedCapacityAvailable > 0)))
						{
							return true;
						}
						if (_dataflowBlockOptions.Greedy)
						{
							if (_nonGreedyState.PostponedMessages.Count > 0 && boundedCapacityAvailable > 0)
							{
								return true;
							}
						}
						else if (_nonGreedyState.PostponedMessages.Count >= num && boundedCapacityAvailable >= num)
						{
							return true;
						}
					}
					return false;
				}
			}

			private object DebuggerDisplayContent
			{
				get
				{
					IDebuggerDisplay owningBatch = _owningBatch;
					return $"Block=\"{((owningBatch != null) ? owningBatch.Content : _owningBatch)}\"";
				}
			}

			internal BatchBlockTargetCore(BatchBlock<T> owningBatch, int batchSize, Action<T[]> batchCompletedAction, GroupingDataflowBlockOptions dataflowBlockOptions)
			{
				_owningBatch = owningBatch;
				_batchSize = batchSize;
				_batchCompletedAction = batchCompletedAction;
				_dataflowBlockOptions = dataflowBlockOptions;
				bool flag = dataflowBlockOptions.BoundedCapacity > 0;
				if (!_dataflowBlockOptions.Greedy || flag)
				{
					_nonGreedyState = new NonGreedyState(batchSize);
				}
				if (flag)
				{
					_boundingState = new BoundingState(dataflowBlockOptions.BoundedCapacity);
				}
			}

			internal void TriggerBatch()
			{
				lock (IncomingLock)
				{
					if (!_decliningPermanently && !_dataflowBlockOptions.CancellationToken.IsCancellationRequested)
					{
						if (_nonGreedyState == null)
						{
							MakeBatchIfPossible(evenIfFewerThanBatchSize: true);
						}
						else
						{
							_nonGreedyState.AcceptFewerThanBatchSize = true;
							ProcessAsyncIfNecessary();
						}
					}
					CompleteBlockIfPossible();
				}
			}

			internal DataflowMessageStatus OfferMessage(DataflowMessageHeader messageHeader, T messageValue, ISourceBlock<T> source, bool consumeToAccept)
			{
				if (!messageHeader.IsValid)
				{
					throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
				}
				if (source == null && consumeToAccept)
				{
					throw new ArgumentException(SR.Argument_CantConsumeFromANullSource, "consumeToAccept");
				}
				lock (IncomingLock)
				{
					if (_decliningPermanently)
					{
						CompleteBlockIfPossible();
						return DataflowMessageStatus.DecliningPermanently;
					}
					if (_dataflowBlockOptions.Greedy && (_boundingState == null || (_boundingState.CountIsLessThanBound && _nonGreedyState.PostponedMessages.Count == 0 && _nonGreedyState.TaskForInputProcessing == null)))
					{
						if (consumeToAccept)
						{
							messageValue = source.ConsumeMessage(messageHeader, _owningBatch, out var messageConsumed);
							if (!messageConsumed)
							{
								return DataflowMessageStatus.NotAvailable;
							}
						}
						_messages.Enqueue(messageValue);
						if (_boundingState != null)
						{
							_boundingState.CurrentCount++;
						}
						if (!_decliningPermanently && _batchesCompleted + _messages.Count / _batchSize >= _dataflowBlockOptions.ActualMaxNumberOfGroups)
						{
							_decliningPermanently = true;
						}
						MakeBatchIfPossible(evenIfFewerThanBatchSize: false);
						CompleteBlockIfPossible();
						return DataflowMessageStatus.Accepted;
					}
					if (source != null)
					{
						_nonGreedyState.PostponedMessages.Push(source, messageHeader);
						if (!_dataflowBlockOptions.Greedy)
						{
							ProcessAsyncIfNecessary();
						}
						return DataflowMessageStatus.Postponed;
					}
					return DataflowMessageStatus.Declined;
				}
			}

			internal void Complete(Exception exception, bool dropPendingMessages, bool releaseReservedMessages, bool revertProcessingState = false)
			{
				lock (IncomingLock)
				{
					if (exception != null && (!_decliningPermanently || releaseReservedMessages))
					{
						_owningBatch._source.AddException(exception);
					}
					if (dropPendingMessages)
					{
						_messages.Clear();
					}
				}
				if (releaseReservedMessages)
				{
					try
					{
						ReleaseReservedMessages(throwOnFirstException: false);
					}
					catch (Exception exception2)
					{
						_owningBatch._source.AddException(exception2);
					}
				}
				lock (IncomingLock)
				{
					if (revertProcessingState)
					{
						_nonGreedyState.TaskForInputProcessing = null;
					}
					_decliningPermanently = true;
					CompleteBlockIfPossible();
				}
			}

			private void CompleteBlockIfPossible()
			{
				if (_completionReserved)
				{
					return;
				}
				bool flag = _nonGreedyState != null && _nonGreedyState.TaskForInputProcessing != null;
				bool flag2 = _batchesCompleted >= _dataflowBlockOptions.ActualMaxNumberOfGroups;
				bool flag3 = _decliningPermanently && _messages.Count < _batchSize;
				if (flag || (!(flag2 || flag3) && !CanceledOrFaulted))
				{
					return;
				}
				_completionReserved = true;
				_decliningPermanently = true;
				if (_messages.Count > 0)
				{
					MakeBatchIfPossible(evenIfFewerThanBatchSize: true);
				}
				Task.Factory.StartNew(delegate(object thisTargetCore)
				{
					BatchBlockTargetCore batchBlockTargetCore = (BatchBlockTargetCore)thisTargetCore;
					List<Exception> exceptions = null;
					if (batchBlockTargetCore._nonGreedyState != null)
					{
						Common.ReleaseAllPostponedMessages(batchBlockTargetCore._owningBatch, batchBlockTargetCore._nonGreedyState.PostponedMessages, ref exceptions);
					}
					if (exceptions != null)
					{
						batchBlockTargetCore._owningBatch._source.AddExceptions(exceptions);
					}
					batchBlockTargetCore._completionTask.TrySetResult(default(VoidResult));
				}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
			}

			private void ProcessAsyncIfNecessary(bool isReplacementReplica = false)
			{
				if (BatchesNeedProcessing)
				{
					ProcessAsyncIfNecessary_Slow(isReplacementReplica);
				}
			}

			private void ProcessAsyncIfNecessary_Slow(bool isReplacementReplica)
			{
				_nonGreedyState.TaskForInputProcessing = new Task(delegate(object thisBatchTarget)
				{
					((BatchBlockTargetCore)thisBatchTarget).ProcessMessagesLoopCore();
				}, this, Common.GetCreationOptionsForTask(isReplacementReplica));
				DataflowEtwProvider log = DataflowEtwProvider.Log;
				if (log.IsEnabled())
				{
					log.TaskLaunchedForMessageHandling(_owningBatch, _nonGreedyState.TaskForInputProcessing, DataflowEtwProvider.TaskLaunchedReason.ProcessingInputMessages, _messages.Count + _nonGreedyState.PostponedMessages.Count);
				}
				Exception ex = Common.StartTaskSafe(_nonGreedyState.TaskForInputProcessing, _dataflowBlockOptions.TaskScheduler);
				if (ex != null)
				{
					Task.Factory.StartNew(delegate(object exc)
					{
						Complete((Exception)exc, dropPendingMessages: true, releaseReservedMessages: true, revertProcessingState: true);
					}, ex, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
				}
			}

			private void ProcessMessagesLoopCore()
			{
				try
				{
					int actualMaxMessagesPerTask = _dataflowBlockOptions.ActualMaxMessagesPerTask;
					int num = 0;
					bool flag2;
					do
					{
						bool flag = Volatile.Read(ref _nonGreedyState.AcceptFewerThanBatchSize);
						if (!_dataflowBlockOptions.Greedy)
						{
							RetrievePostponedItemsNonGreedy(flag);
						}
						else
						{
							RetrievePostponedItemsGreedyBounded(flag);
						}
						lock (IncomingLock)
						{
							flag2 = MakeBatchIfPossible(flag);
							if (flag2 || flag)
							{
								_nonGreedyState.AcceptFewerThanBatchSize = false;
							}
						}
						num++;
					}
					while (flag2 && num < actualMaxMessagesPerTask);
				}
				catch (Exception exception)
				{
					Complete(exception, dropPendingMessages: false, releaseReservedMessages: true);
				}
				finally
				{
					lock (IncomingLock)
					{
						_nonGreedyState.TaskForInputProcessing = null;
						ProcessAsyncIfNecessary(isReplacementReplica: true);
						CompleteBlockIfPossible();
					}
				}
			}

			private bool MakeBatchIfPossible(bool evenIfFewerThanBatchSize)
			{
				bool flag = _messages.Count >= _batchSize;
				if (flag || (evenIfFewerThanBatchSize && _messages.Count > 0))
				{
					T[] array = new T[flag ? _batchSize : _messages.Count];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = _messages.Dequeue();
					}
					_batchCompletedAction(array);
					_batchesCompleted++;
					if (_batchesCompleted >= _dataflowBlockOptions.ActualMaxNumberOfGroups)
					{
						_decliningPermanently = true;
					}
					return true;
				}
				return false;
			}

			private void RetrievePostponedItemsNonGreedy(bool allowFewerThanBatchSize)
			{
				QueuedMap<ISourceBlock<T>, DataflowMessageHeader> postponedMessages = _nonGreedyState.PostponedMessages;
				KeyValuePair<ISourceBlock<T>, DataflowMessageHeader>[] postponedMessagesTemp = _nonGreedyState.PostponedMessagesTemp;
				List<KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>> reservedSourcesTemp = _nonGreedyState.ReservedSourcesTemp;
				reservedSourcesTemp.Clear();
				int num;
				lock (IncomingLock)
				{
					int boundedCapacityAvailable = BoundedCapacityAvailable;
					if (_decliningPermanently || postponedMessages.Count == 0 || boundedCapacityAvailable <= 0 || (!allowFewerThanBatchSize && (postponedMessages.Count < _batchSize || boundedCapacityAvailable < _batchSize)))
					{
						return;
					}
					num = postponedMessages.PopRange(postponedMessagesTemp, 0, _batchSize);
				}
				for (int i = 0; i < num; i++)
				{
					KeyValuePair<ISourceBlock<T>, DataflowMessageHeader> keyValuePair = postponedMessagesTemp[i];
					if (keyValuePair.Key.ReserveMessage(keyValuePair.Value, _owningBatch))
					{
						KeyValuePair<DataflowMessageHeader, T> value = new KeyValuePair<DataflowMessageHeader, T>(keyValuePair.Value, default(T));
						KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>> item = new KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>(keyValuePair.Key, value);
						reservedSourcesTemp.Add(item);
					}
				}
				Array.Clear(postponedMessagesTemp, 0, postponedMessagesTemp.Length);
				while (reservedSourcesTemp.Count < _batchSize)
				{
					KeyValuePair<ISourceBlock<T>, DataflowMessageHeader> item2;
					lock (IncomingLock)
					{
						if (!postponedMessages.TryPop(out item2))
						{
							break;
						}
					}
					if (item2.Key.ReserveMessage(item2.Value, _owningBatch))
					{
						KeyValuePair<DataflowMessageHeader, T> value2 = new KeyValuePair<DataflowMessageHeader, T>(item2.Value, default(T));
						KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>> item3 = new KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>(item2.Key, value2);
						reservedSourcesTemp.Add(item3);
					}
				}
				if (reservedSourcesTemp.Count > 0)
				{
					bool flag = true;
					if (allowFewerThanBatchSize)
					{
						lock (IncomingLock)
						{
							if (!_decliningPermanently && _batchesCompleted + 1 >= _dataflowBlockOptions.ActualMaxNumberOfGroups)
							{
								flag = !_decliningPermanently;
								_decliningPermanently = true;
							}
						}
					}
					if (flag && (allowFewerThanBatchSize || reservedSourcesTemp.Count == _batchSize))
					{
						ConsumeReservedMessagesNonGreedy();
					}
					else
					{
						ReleaseReservedMessages(throwOnFirstException: true);
					}
				}
				reservedSourcesTemp.Clear();
			}

			private void RetrievePostponedItemsGreedyBounded(bool allowFewerThanBatchSize)
			{
				QueuedMap<ISourceBlock<T>, DataflowMessageHeader> postponedMessages = _nonGreedyState.PostponedMessages;
				KeyValuePair<ISourceBlock<T>, DataflowMessageHeader>[] postponedMessagesTemp = _nonGreedyState.PostponedMessagesTemp;
				List<KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>> reservedSourcesTemp = _nonGreedyState.ReservedSourcesTemp;
				reservedSourcesTemp.Clear();
				int num;
				int num2;
				lock (IncomingLock)
				{
					int boundedCapacityAvailable = BoundedCapacityAvailable;
					num = _batchSize - _messages.Count;
					if (_decliningPermanently || postponedMessages.Count == 0 || boundedCapacityAvailable <= 0)
					{
						return;
					}
					if (boundedCapacityAvailable < num)
					{
						num = boundedCapacityAvailable;
					}
					num2 = postponedMessages.PopRange(postponedMessagesTemp, 0, num);
				}
				for (int i = 0; i < num2; i++)
				{
					KeyValuePair<ISourceBlock<T>, DataflowMessageHeader> keyValuePair = postponedMessagesTemp[i];
					KeyValuePair<DataflowMessageHeader, T> value = new KeyValuePair<DataflowMessageHeader, T>(keyValuePair.Value, default(T));
					KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>> item = new KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>(keyValuePair.Key, value);
					reservedSourcesTemp.Add(item);
				}
				Array.Clear(postponedMessagesTemp, 0, postponedMessagesTemp.Length);
				while (reservedSourcesTemp.Count < num)
				{
					KeyValuePair<ISourceBlock<T>, DataflowMessageHeader> item2;
					lock (IncomingLock)
					{
						if (!postponedMessages.TryPop(out item2))
						{
							break;
						}
					}
					KeyValuePair<DataflowMessageHeader, T> value2 = new KeyValuePair<DataflowMessageHeader, T>(item2.Value, default(T));
					KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>> item3 = new KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>(item2.Key, value2);
					reservedSourcesTemp.Add(item3);
				}
				if (reservedSourcesTemp.Count > 0)
				{
					bool flag = true;
					if (allowFewerThanBatchSize)
					{
						lock (IncomingLock)
						{
							if (!_decliningPermanently && _batchesCompleted + 1 >= _dataflowBlockOptions.ActualMaxNumberOfGroups)
							{
								flag = !_decliningPermanently;
								_decliningPermanently = true;
							}
						}
					}
					if (flag)
					{
						ConsumeReservedMessagesGreedyBounded();
					}
				}
				reservedSourcesTemp.Clear();
			}

			private void ConsumeReservedMessagesNonGreedy()
			{
				List<KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>> reservedSourcesTemp = _nonGreedyState.ReservedSourcesTemp;
				for (int i = 0; i < reservedSourcesTemp.Count; i++)
				{
					KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>> keyValuePair = reservedSourcesTemp[i];
					reservedSourcesTemp[i] = default(KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>);
					bool messageConsumed;
					T value = keyValuePair.Key.ConsumeMessage(keyValuePair.Value.Key, _owningBatch, out messageConsumed);
					if (!messageConsumed)
					{
						for (int j = 0; j < i; j++)
						{
							reservedSourcesTemp[j] = default(KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>);
						}
						throw new InvalidOperationException(SR.InvalidOperation_FailedToConsumeReservedMessage);
					}
					KeyValuePair<DataflowMessageHeader, T> value2 = new KeyValuePair<DataflowMessageHeader, T>(keyValuePair.Value.Key, value);
					KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>> value3 = new KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>(keyValuePair.Key, value2);
					reservedSourcesTemp[i] = value3;
				}
				lock (IncomingLock)
				{
					if (_boundingState != null)
					{
						_boundingState.CurrentCount += reservedSourcesTemp.Count;
					}
					foreach (KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>> item in reservedSourcesTemp)
					{
						_messages.Enqueue(item.Value.Value);
					}
				}
			}

			private void ConsumeReservedMessagesGreedyBounded()
			{
				int num = 0;
				List<KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>> reservedSourcesTemp = _nonGreedyState.ReservedSourcesTemp;
				for (int i = 0; i < reservedSourcesTemp.Count; i++)
				{
					KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>> keyValuePair = reservedSourcesTemp[i];
					reservedSourcesTemp[i] = default(KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>);
					bool messageConsumed;
					T value = keyValuePair.Key.ConsumeMessage(keyValuePair.Value.Key, _owningBatch, out messageConsumed);
					if (messageConsumed)
					{
						KeyValuePair<DataflowMessageHeader, T> value2 = new KeyValuePair<DataflowMessageHeader, T>(keyValuePair.Value.Key, value);
						KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>> value3 = new KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>(keyValuePair.Key, value2);
						reservedSourcesTemp[i] = value3;
						num++;
					}
				}
				lock (IncomingLock)
				{
					if (_boundingState != null)
					{
						_boundingState.CurrentCount += num;
					}
					foreach (KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>> item in reservedSourcesTemp)
					{
						if (item.Key != null)
						{
							_messages.Enqueue(item.Value.Value);
						}
					}
				}
			}

			internal void ReleaseReservedMessages(bool throwOnFirstException)
			{
				List<Exception> list = null;
				List<KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>> reservedSourcesTemp = _nonGreedyState.ReservedSourcesTemp;
				for (int i = 0; i < reservedSourcesTemp.Count; i++)
				{
					KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>> keyValuePair = reservedSourcesTemp[i];
					reservedSourcesTemp[i] = default(KeyValuePair<ISourceBlock<T>, KeyValuePair<DataflowMessageHeader, T>>);
					ISourceBlock<T> key = keyValuePair.Key;
					KeyValuePair<DataflowMessageHeader, T> value = keyValuePair.Value;
					if (key == null || !value.Key.IsValid)
					{
						continue;
					}
					try
					{
						key.ReleaseReservation(value.Key, _owningBatch);
					}
					catch (Exception item)
					{
						if (throwOnFirstException)
						{
							throw;
						}
						if (list == null)
						{
							list = new List<Exception>(1);
						}
						list.Add(item);
					}
				}
				if (list != null)
				{
					throw new AggregateException(list);
				}
			}

			internal void OnItemsRemoved(int numItemsRemoved)
			{
				if (_boundingState != null)
				{
					lock (IncomingLock)
					{
						_boundingState.CurrentCount -= numItemsRemoved;
						ProcessAsyncIfNecessary();
						CompleteBlockIfPossible();
					}
				}
			}

			internal static int CountItems(T[] singleOutputItem, IList<T[]> multipleOutputItems)
			{
				if (multipleOutputItems == null)
				{
					return singleOutputItem.Length;
				}
				int num = 0;
				foreach (T[] multipleOutputItem in multipleOutputItems)
				{
					num += multipleOutputItem.Length;
				}
				return num;
			}

			internal DebuggingInformation GetDebuggingInformation()
			{
				return new DebuggingInformation(this);
			}
		}

		private readonly BatchBlockTargetCore _target;

		private readonly SourceCore<T[]> _source;

		public int OutputCount => _source.OutputCount;

		public Task Completion => _source.Completion;

		public int BatchSize => _target.BatchSize;

		private int OutputCountForDebugger => _source.GetDebuggingInformation().OutputCount;

		private object DebuggerDisplayContent => $"{Common.GetNameForDebugger(this, _source.DataflowBlockOptions)}, BatchSize={BatchSize}, OutputCount={OutputCountForDebugger}";

		object IDebuggerDisplay.Content => DebuggerDisplayContent;

		public BatchBlock(int batchSize)
			: this(batchSize, GroupingDataflowBlockOptions.Default)
		{
		}

		public BatchBlock(int batchSize, GroupingDataflowBlockOptions dataflowBlockOptions)
		{
			if (batchSize < 1)
			{
				throw new ArgumentOutOfRangeException("batchSize", SR.ArgumentOutOfRange_GenericPositive);
			}
			if (dataflowBlockOptions == null)
			{
				throw new ArgumentNullException("dataflowBlockOptions");
			}
			if (dataflowBlockOptions.BoundedCapacity > 0 && dataflowBlockOptions.BoundedCapacity < batchSize)
			{
				throw new ArgumentOutOfRangeException("batchSize", SR.ArgumentOutOfRange_BatchSizeMustBeNoGreaterThanBoundedCapacity);
			}
			dataflowBlockOptions = dataflowBlockOptions.DefaultOrClone();
			Action<ISourceBlock<T[]>, int> itemsRemovedAction = null;
			Func<ISourceBlock<T[]>, T[], IList<T[]>, int> itemCountingFunc = null;
			if (dataflowBlockOptions.BoundedCapacity > 0)
			{
				itemsRemovedAction = delegate(ISourceBlock<T[]> owningSource, int count)
				{
					((BatchBlock<T>)owningSource)._target.OnItemsRemoved(count);
				};
				itemCountingFunc = (ISourceBlock<T[]> owningSource, T[] singleOutputItem, IList<T[]> multipleOutputItems) => BatchBlockTargetCore.CountItems(singleOutputItem, multipleOutputItems);
			}
			_source = new SourceCore<T[]>(this, dataflowBlockOptions, delegate(ISourceBlock<T[]> owningSource)
			{
				((BatchBlock<T>)owningSource)._target.Complete(null, dropPendingMessages: true, releaseReservedMessages: false);
			}, itemsRemovedAction, itemCountingFunc);
			_target = new BatchBlockTargetCore(this, batchSize, delegate(T[] batch)
			{
				_source.AddMessage(batch);
			}, dataflowBlockOptions);
			_target.Completion.ContinueWith(delegate
			{
				_source.Complete();
			}, CancellationToken.None, Common.GetContinuationOptions(), TaskScheduler.Default);
			_source.Completion.ContinueWith(delegate(Task completed, object state)
			{
				IDataflowBlock dataflowBlock = (BatchBlock<T>)state;
				dataflowBlock.Fault(completed.Exception);
			}, this, CancellationToken.None, Common.GetContinuationOptions() | TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
			Common.WireCancellationToComplete(dataflowBlockOptions.CancellationToken, _source.Completion, delegate(object state)
			{
				((BatchBlockTargetCore)state).Complete(null, dropPendingMessages: true, releaseReservedMessages: false);
			}, _target);
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.DataflowBlockCreated(this, dataflowBlockOptions);
			}
		}

		public void Complete()
		{
			_target.Complete(null, dropPendingMessages: false, releaseReservedMessages: false);
		}

		void IDataflowBlock.Fault(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			_target.Complete(exception, dropPendingMessages: true, releaseReservedMessages: false);
		}

		public void TriggerBatch()
		{
			_target.TriggerBatch();
		}

		public IDisposable LinkTo(ITargetBlock<T[]> target, DataflowLinkOptions linkOptions)
		{
			return _source.LinkTo(target, linkOptions);
		}

		public bool TryReceive(Predicate<T[]> filter, out T[] item)
		{
			return _source.TryReceive(filter, out item);
		}

		public bool TryReceiveAll(out IList<T[]> items)
		{
			return _source.TryReceiveAll(out items);
		}

		DataflowMessageStatus ITargetBlock<T>.OfferMessage(DataflowMessageHeader messageHeader, T messageValue, ISourceBlock<T> source, bool consumeToAccept)
		{
			return _target.OfferMessage(messageHeader, messageValue, source, consumeToAccept);
		}

		T[] ISourceBlock<T[]>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<T[]> target, out bool messageConsumed)
		{
			return _source.ConsumeMessage(messageHeader, target, out messageConsumed);
		}

		bool ISourceBlock<T[]>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<T[]> target)
		{
			return _source.ReserveMessage(messageHeader, target);
		}

		void ISourceBlock<T[]>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<T[]> target)
		{
			_source.ReleaseReservation(messageHeader, target);
		}

		public override string ToString()
		{
			return Common.GetNameForDebugger(this, _source.DataflowBlockOptions);
		}
	}
	[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
	[DebuggerTypeProxy(typeof(BatchedJoinBlock<, >.DebugView))]
	public sealed class BatchedJoinBlock<T1, T2> : IReceivableSourceBlock<Tuple<IList<T1>, IList<T2>>>, ISourceBlock<Tuple<IList<T1>, IList<T2>>>, IDataflowBlock, IDebuggerDisplay
	{
		private sealed class DebugView
		{
			private readonly BatchedJoinBlock<T1, T2> _batchedJoinBlock;

			private readonly SourceCore<Tuple<IList<T1>, IList<T2>>>.DebuggingInformation _sourceDebuggingInformation;

			public IEnumerable<Tuple<IList<T1>, IList<T2>>> OutputQueue => _sourceDebuggingInformation.OutputQueue;

			public long BatchesCreated => _batchedJoinBlock._sharedResources._batchesCreated;

			public int RemainingItemsForBatch => _batchedJoinBlock._sharedResources._remainingItemsInBatch;

			public int BatchSize => _batchedJoinBlock._batchSize;

			public ITargetBlock<T1> Target1 => _batchedJoinBlock._target1;

			public ITargetBlock<T2> Target2 => _batchedJoinBlock._target2;

			public Task TaskForOutputProcessing => _sourceDebuggingInformation.TaskForOutputProcessing;

			public GroupingDataflowBlockOptions DataflowBlockOptions => (GroupingDataflowBlockOptions)_sourceDebuggingInformation.DataflowBlockOptions;

			public bool IsCompleted => _sourceDebuggingInformation.IsCompleted;

			public int Id => Common.GetBlockId(_batchedJoinBlock);

			public TargetRegistry<Tuple<IList<T1>, IList<T2>>> LinkedTargets => _sourceDebuggingInformation.LinkedTargets;

			public ITargetBlock<Tuple<IList<T1>, IList<T2>>> NextMessageReservedFor => _sourceDebuggingInformation.NextMessageReservedFor;

			public DebugView(BatchedJoinBlock<T1, T2> batchedJoinBlock)
			{
				_batchedJoinBlock = batchedJoinBlock;
				_sourceDebuggingInformation = batchedJoinBlock._source.GetDebuggingInformation();
			}
		}

		private readonly int _batchSize;

		private readonly BatchedJoinBlockTargetSharedResources _sharedResources;

		private readonly BatchedJoinBlockTarget<T1> _target1;

		private readonly BatchedJoinBlockTarget<T2> _target2;

		private readonly SourceCore<Tuple<IList<T1>, IList<T2>>> _source;

		public int BatchSize => _batchSize;

		public ITargetBlock<T1> Target1 => _target1;

		public ITargetBlock<T2> Target2 => _target2;

		public int OutputCount => _source.OutputCount;

		public Task Completion => _source.Completion;

		private int OutputCountForDebugger => _source.GetDebuggingInformation().OutputCount;

		private object DebuggerDisplayContent => $"{Common.GetNameForDebugger(this, _source.DataflowBlockOptions)}, BatchSize={BatchSize}, OutputCount={OutputCountForDebugger}";

		object IDebuggerDisplay.Content => DebuggerDisplayContent;

		public BatchedJoinBlock(int batchSize)
			: this(batchSize, GroupingDataflowBlockOptions.Default)
		{
		}

		public BatchedJoinBlock(int batchSize, GroupingDataflowBlockOptions dataflowBlockOptions)
		{
			if (batchSize < 1)
			{
				throw new ArgumentOutOfRangeException("batchSize", SR.ArgumentOutOfRange_GenericPositive);
			}
			if (dataflowBlockOptions == null)
			{
				throw new ArgumentNullException("dataflowBlockOptions");
			}
			if (!dataflowBlockOptions.Greedy)
			{
				throw new ArgumentException(SR.Argument_NonGreedyNotSupported, "dataflowBlockOptions");
			}
			if (dataflowBlockOptions.BoundedCapacity != -1)
			{
				throw new ArgumentException(SR.Argument_BoundedCapacityNotSupported, "dataflowBlockOptions");
			}
			_batchSize = batchSize;
			dataflowBlockOptions = dataflowBlockOptions.DefaultOrClone();
			_source = new SourceCore<Tuple<IList<T1>, IList<T2>>>(this, dataflowBlockOptions, delegate(ISourceBlock<Tuple<IList<T1>, IList<T2>>> owningSource)
			{
				((BatchedJoinBlock<T1, T2>)owningSource).CompleteEachTarget();
			});
			Action createBatchAction = delegate
			{
				if (_target1.Count > 0 || _target2.Count > 0)
				{
					_source.AddMessage(Tuple.Create(_target1.GetAndEmptyMessages(), _target2.GetAndEmptyMessages()));
				}
			};
			_sharedResources = new BatchedJoinBlockTargetSharedResources(batchSize, dataflowBlockOptions, createBatchAction, delegate
			{
				createBatchAction();
				_source.Complete();
			}, _source.AddException, Complete);
			_target1 = new BatchedJoinBlockTarget<T1>(_sharedResources);
			_target2 = new BatchedJoinBlockTarget<T2>(_sharedResources);
			_source.Completion.ContinueWith(delegate(Task completed, object state)
			{
				IDataflowBlock dataflowBlock = (BatchedJoinBlock<T1, T2>)state;
				dataflowBlock.Fault(completed.Exception);
			}, this, CancellationToken.None, Common.GetContinuationOptions() | TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
			Common.WireCancellationToComplete(dataflowBlockOptions.CancellationToken, _source.Completion, delegate(object state)
			{
				((BatchedJoinBlock<T1, T2>)state).CompleteEachTarget();
			}, this);
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.DataflowBlockCreated(this, dataflowBlockOptions);
			}
		}

		public IDisposable LinkTo(ITargetBlock<Tuple<IList<T1>, IList<T2>>> target, DataflowLinkOptions linkOptions)
		{
			return _source.LinkTo(target, linkOptions);
		}

		public bool TryReceive(Predicate<Tuple<IList<T1>, IList<T2>>> filter, out Tuple<IList<T1>, IList<T2>> item)
		{
			return _source.TryReceive(filter, out item);
		}

		public bool TryReceiveAll(out IList<Tuple<IList<T1>, IList<T2>>> items)
		{
			return _source.TryReceiveAll(out items);
		}

		public void Complete()
		{
			_target1.Complete();
			_target2.Complete();
		}

		void IDataflowBlock.Fault(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			lock (_sharedResources._incomingLock)
			{
				if (!_sharedResources._decliningPermanently)
				{
					_source.AddException(exception);
				}
			}
			Complete();
		}

		Tuple<IList<T1>, IList<T2>> ISourceBlock<Tuple<IList<T1>, IList<T2>>>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<IList<T1>, IList<T2>>> target, out bool messageConsumed)
		{
			return _source.ConsumeMessage(messageHeader, target, out messageConsumed);
		}

		bool ISourceBlock<Tuple<IList<T1>, IList<T2>>>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<IList<T1>, IList<T2>>> target)
		{
			return _source.ReserveMessage(messageHeader, target);
		}

		void ISourceBlock<Tuple<IList<T1>, IList<T2>>>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<IList<T1>, IList<T2>>> target)
		{
			_source.ReleaseReservation(messageHeader, target);
		}

		private void CompleteEachTarget()
		{
			_target1.Complete();
			_target2.Complete();
		}

		public override string ToString()
		{
			return Common.GetNameForDebugger(this, _source.DataflowBlockOptions);
		}
	}
	[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
	[DebuggerTypeProxy(typeof(BatchedJoinBlock<, , >.DebugView))]
	public sealed class BatchedJoinBlock<T1, T2, T3> : IReceivableSourceBlock<Tuple<IList<T1>, IList<T2>, IList<T3>>>, ISourceBlock<Tuple<IList<T1>, IList<T2>, IList<T3>>>, IDataflowBlock, IDebuggerDisplay
	{
		private sealed class DebugView
		{
			private readonly BatchedJoinBlock<T1, T2, T3> _batchedJoinBlock;

			private readonly SourceCore<Tuple<IList<T1>, IList<T2>, IList<T3>>>.DebuggingInformation _sourceDebuggingInformation;

			public IEnumerable<Tuple<IList<T1>, IList<T2>, IList<T3>>> OutputQueue => _sourceDebuggingInformation.OutputQueue;

			public long BatchesCreated => _batchedJoinBlock._sharedResources._batchesCreated;

			public int RemainingItemsForBatch => _batchedJoinBlock._sharedResources._remainingItemsInBatch;

			public int BatchSize => _batchedJoinBlock._batchSize;

			public ITargetBlock<T1> Target1 => _batchedJoinBlock._target1;

			public ITargetBlock<T2> Target2 => _batchedJoinBlock._target2;

			public ITargetBlock<T3> Target3 => _batchedJoinBlock._target3;

			public Task TaskForOutputProcessing => _sourceDebuggingInformation.TaskForOutputProcessing;

			public GroupingDataflowBlockOptions DataflowBlockOptions => (GroupingDataflowBlockOptions)_sourceDebuggingInformation.DataflowBlockOptions;

			public bool IsCompleted => _sourceDebuggingInformation.IsCompleted;

			public int Id => Common.GetBlockId(_batchedJoinBlock);

			public TargetRegistry<Tuple<IList<T1>, IList<T2>, IList<T3>>> LinkedTargets => _sourceDebuggingInformation.LinkedTargets;

			public ITargetBlock<Tuple<IList<T1>, IList<T2>, IList<T3>>> NextMessageReservedFor => _sourceDebuggingInformation.NextMessageReservedFor;

			public DebugView(BatchedJoinBlock<T1, T2, T3> batchedJoinBlock)
			{
				_sourceDebuggingInformation = batchedJoinBlock._source.GetDebuggingInformation();
				_batchedJoinBlock = batchedJoinBlock;
			}
		}

		private readonly int _batchSize;

		private readonly BatchedJoinBlockTargetSharedResources _sharedResources;

		private readonly BatchedJoinBlockTarget<T1> _target1;

		private readonly BatchedJoinBlockTarget<T2> _target2;

		private readonly BatchedJoinBlockTarget<T3> _target3;

		private readonly SourceCore<Tuple<IList<T1>, IList<T2>, IList<T3>>> _source;

		public int BatchSize => _batchSize;

		public ITargetBlock<T1> Target1 => _target1;

		public ITargetBlock<T2> Target2 => _target2;

		public ITargetBlock<T3> Target3 => _target3;

		public int OutputCount => _source.OutputCount;

		public Task Completion => _source.Completion;

		private int OutputCountForDebugger => _source.GetDebuggingInformation().OutputCount;

		private object DebuggerDisplayContent => $"{Common.GetNameForDebugger(this, _source.DataflowBlockOptions)}, BatchSize={BatchSize}, OutputCount={OutputCountForDebugger}";

		object IDebuggerDisplay.Content => DebuggerDisplayContent;

		public BatchedJoinBlock(int batchSize)
			: this(batchSize, GroupingDataflowBlockOptions.Default)
		{
		}

		public BatchedJoinBlock(int batchSize, GroupingDataflowBlockOptions dataflowBlockOptions)
		{
			if (batchSize < 1)
			{
				throw new ArgumentOutOfRangeException("batchSize", SR.ArgumentOutOfRange_GenericPositive);
			}
			if (dataflowBlockOptions == null)
			{
				throw new ArgumentNullException("dataflowBlockOptions");
			}
			if (!dataflowBlockOptions.Greedy || dataflowBlockOptions.BoundedCapacity != -1)
			{
				throw new ArgumentException(SR.Argument_NonGreedyNotSupported, "dataflowBlockOptions");
			}
			_batchSize = batchSize;
			dataflowBlockOptions = dataflowBlockOptions.DefaultOrClone();
			_source = new SourceCore<Tuple<IList<T1>, IList<T2>, IList<T3>>>(this, dataflowBlockOptions, delegate(ISourceBlock<Tuple<IList<T1>, IList<T2>, IList<T3>>> owningSource)
			{
				((BatchedJoinBlock<T1, T2, T3>)owningSource).CompleteEachTarget();
			});
			Action createBatchAction = delegate
			{
				if (_target1.Count > 0 || _target2.Count > 0 || _target3.Count > 0)
				{
					_source.AddMessage(Tuple.Create(_target1.GetAndEmptyMessages(), _target2.GetAndEmptyMessages(), _target3.GetAndEmptyMessages()));
				}
			};
			_sharedResources = new BatchedJoinBlockTargetSharedResources(batchSize, dataflowBlockOptions, createBatchAction, delegate
			{
				createBatchAction();
				_source.Complete();
			}, _source.AddException, Complete);
			_target1 = new BatchedJoinBlockTarget<T1>(_sharedResources);
			_target2 = new BatchedJoinBlockTarget<T2>(_sharedResources);
			_target3 = new BatchedJoinBlockTarget<T3>(_sharedResources);
			_source.Completion.ContinueWith(delegate(Task completed, object state)
			{
				IDataflowBlock dataflowBlock = (BatchedJoinBlock<T1, T2, T3>)state;
				dataflowBlock.Fault(completed.Exception);
			}, this, CancellationToken.None, Common.GetContinuationOptions() | TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
			Common.WireCancellationToComplete(dataflowBlockOptions.CancellationToken, _source.Completion, delegate(object state)
			{
				((BatchedJoinBlock<T1, T2, T3>)state).CompleteEachTarget();
			}, this);
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.DataflowBlockCreated(this, dataflowBlockOptions);
			}
		}

		public IDisposable LinkTo(ITargetBlock<Tuple<IList<T1>, IList<T2>, IList<T3>>> target, DataflowLinkOptions linkOptions)
		{
			return _source.LinkTo(target, linkOptions);
		}

		public bool TryReceive(Predicate<Tuple<IList<T1>, IList<T2>, IList<T3>>> filter, out Tuple<IList<T1>, IList<T2>, IList<T3>> item)
		{
			return _source.TryReceive(filter, out item);
		}

		public bool TryReceiveAll(out IList<Tuple<IList<T1>, IList<T2>, IList<T3>>> items)
		{
			return _source.TryReceiveAll(out items);
		}

		public void Complete()
		{
			_target1.Complete();
			_target2.Complete();
			_target3.Complete();
		}

		void IDataflowBlock.Fault(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			lock (_sharedResources._incomingLock)
			{
				if (!_sharedResources._decliningPermanently)
				{
					_source.AddException(exception);
				}
			}
			Complete();
		}

		Tuple<IList<T1>, IList<T2>, IList<T3>> ISourceBlock<Tuple<IList<T1>, IList<T2>, IList<T3>>>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<IList<T1>, IList<T2>, IList<T3>>> target, out bool messageConsumed)
		{
			return _source.ConsumeMessage(messageHeader, target, out messageConsumed);
		}

		bool ISourceBlock<Tuple<IList<T1>, IList<T2>, IList<T3>>>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<IList<T1>, IList<T2>, IList<T3>>> target)
		{
			return _source.ReserveMessage(messageHeader, target);
		}

		void ISourceBlock<Tuple<IList<T1>, IList<T2>, IList<T3>>>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<IList<T1>, IList<T2>, IList<T3>>> target)
		{
			_source.ReleaseReservation(messageHeader, target);
		}

		private void CompleteEachTarget()
		{
			_target1.Complete();
			_target2.Complete();
			_target3.Complete();
		}

		public override string ToString()
		{
			return Common.GetNameForDebugger(this, _source.DataflowBlockOptions);
		}
	}
	[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
	[DebuggerTypeProxy(typeof(BroadcastBlock<>.DebugView))]
	public sealed class BroadcastBlock<T> : IPropagatorBlock<T, T>, ITargetBlock<T>, IDataflowBlock, ISourceBlock<T>, IReceivableSourceBlock<T>, IDebuggerDisplay
	{
		private sealed class DebugView
		{
			private readonly BroadcastBlock<T> _broadcastBlock;

			private readonly BroadcastingSourceCore<T>.DebuggingInformation _sourceDebuggingInformation;

			public IEnumerable<T> InputQueue => _sourceDebuggingInformation.InputQueue;

			public bool HasValue => _broadcastBlock.HasValueForDebugger;

			public T Value => _broadcastBlock.ValueForDebugger;

			public Task TaskForOutputProcessing => _sourceDebuggingInformation.TaskForOutputProcessing;

			public DataflowBlockOptions DataflowBlockOptions => _sourceDebuggingInformation.DataflowBlockOptions;

			public bool IsDecliningPermanently => _broadcastBlock._decliningPermanently;

			public bool IsCompleted => _sourceDebuggingInformation.IsCompleted;

			public int Id => Common.GetBlockId(_broadcastBlock);

			public TargetRegistry<T> LinkedTargets => _sourceDebuggingInformation.LinkedTargets;

			public ITargetBlock<T> NextMessageReservedFor => _sourceDebuggingInformation.NextMessageReservedFor;

			public DebugView(BroadcastBlock<T> broadcastBlock)
			{
				_broadcastBlock = broadcastBlock;
				_sourceDebuggingInformation = broadcastBlock._source.GetDebuggingInformation();
			}
		}

		[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
		private sealed class BroadcastingSourceCore<TOutput>
		{
			internal sealed class DebuggingInformation
			{
				private BroadcastingSourceCore<TOutput> _source;

				public bool HasValue => _source._currentMessageIsValid;

				public TOutput Value => _source._currentMessage;

				public IEnumerable<TOutput> InputQueue => _source._messages.ToList();

				public Task TaskForOutputProcessing => _source._taskForOutputProcessing;

				public DataflowBlockOptions DataflowBlockOptions => _source._dataflowBlockOptions;

				public bool IsCompleted => _source.Completion.IsCompleted;

				public TargetRegistry<TOutput> LinkedTargets => _source._targetRegistry;

				public ITargetBlock<TOutput> NextMessageReservedFor => _source._nextMessageReservedFor;

				public DebuggingInformation(BroadcastingSourceCore<TOutput> source)
				{
					_source = source;
				}
			}

			private readonly TargetRegistry<TOutput> _targetRegistry;

			private readonly Queue<TOutput> _messages = new Queue<TOutput>();

			private readonly TaskCompletionSource<VoidResult> _completionTask = new TaskCompletionSource<VoidResult>();

			private readonly Action<int> _itemsRemovedAction;

			private readonly BroadcastBlock<TOutput> _owningSource;

			private readonly DataflowBlockOptions _dataflowBlockOptions;

			private readonly Func<TOutput, TOutput> _cloningFunction;

			private bool _currentMessageIsValid;

			private TOutput _currentMessage;

			private ITargetBlock<TOutput> _nextMessageReservedFor;

			private bool _enableOffering;

			private bool _decliningPermanently;

			private Task _taskForOutputProcessing;

			private List<Exception> _exceptions;

			private long _nextMessageId = 1L;

			private bool _completionReserved;

			private object OutgoingLock => _completionTask;

			private object ValueLock => _targetRegistry;

			private bool CanceledOrFaulted
			{
				get
				{
					if (!_dataflowBlockOptions.CancellationToken.IsCancellationRequested)
					{
						if (Volatile.Read(ref _exceptions) != null)
						{
							return _decliningPermanently;
						}
						return false;
					}
					return true;
				}
			}

			internal Task Completion => _completionTask.Task;

			internal DataflowBlockOptions DataflowBlockOptions => _dataflowBlockOptions;

			private object DebuggerDisplayContent
			{
				get
				{
					IDebuggerDisplay owningSource = _owningSource;
					return $"Block=\"{((owningSource != null) ? owningSource.Content : _owningSource)}\"";
				}
			}

			internal BroadcastingSourceCore(BroadcastBlock<TOutput> owningSource, Func<TOutput, TOutput> cloningFunction, DataflowBlockOptions dataflowBlockOptions, Action<int> itemsRemovedAction)
			{
				_owningSource = owningSource;
				_cloningFunction = cloningFunction;
				_dataflowBlockOptions = dataflowBlockOptions;
				_itemsRemovedAction = itemsRemovedAction;
				_targetRegistry = new TargetRegistry<TOutput>(_owningSource);
			}

			internal bool TryReceive(Predicate<TOutput> filter, out TOutput item)
			{
				TOutput currentMessage;
				bool currentMessageIsValid;
				lock (OutgoingLock)
				{
					lock (ValueLock)
					{
						currentMessage = _currentMessage;
						currentMessageIsValid = _currentMessageIsValid;
					}
				}
				if (currentMessageIsValid && (filter == null || filter(currentMessage)))
				{
					item = CloneItem(currentMessage);
					return true;
				}
				item = default(TOutput);
				return false;
			}

			internal bool TryReceiveAll(out IList<TOutput> items)
			{
				if (TryReceive(null, out var item))
				{
					items = new TOutput[1] { item };
					return true;
				}
				items = null;
				return false;
			}

			internal void AddMessage(TOutput item)
			{
				lock (ValueLock)
				{
					if (!_decliningPermanently)
					{
						_messages.Enqueue(item);
						if (_messages.Count == 1)
						{
							_enableOffering = true;
						}
						OfferAsyncIfNecessary();
					}
				}
			}

			internal void Complete()
			{
				lock (ValueLock)
				{
					_decliningPermanently = true;
					Task.Factory.StartNew(delegate(object state)
					{
						BroadcastingSourceCore<TOutput> broadcastingSourceCore = (BroadcastingSourceCore<TOutput>)state;
						lock (broadcastingSourceCore.OutgoingLock)
						{
							lock (broadcastingSourceCore.ValueLock)
							{
								broadcastingSourceCore.CompleteBlockIfPossible();
							}
						}
					}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
				}
			}

			private TOutput CloneItem(TOutput item)
			{
				if (_cloningFunction == null)
				{
					return item;
				}
				return _cloningFunction(item);
			}

			private void OfferCurrentMessageToNewTarget(ITargetBlock<TOutput> target)
			{
				TOutput currentMessage;
				bool currentMessageIsValid;
				lock (ValueLock)
				{
					currentMessage = _currentMessage;
					currentMessageIsValid = _currentMessageIsValid;
				}
				if (!currentMessageIsValid)
				{
					return;
				}
				bool flag = _cloningFunction != null;
				switch (target.OfferMessage(new DataflowMessageHeader(_nextMessageId), currentMessage, _owningSource, flag))
				{
				case DataflowMessageStatus.Accepted:
					if (!flag)
					{
						_targetRegistry.Remove(target, onlyIfReachedMaxMessages: true);
					}
					break;
				case DataflowMessageStatus.DecliningPermanently:
					_targetRegistry.Remove(target);
					break;
				}
			}

			private bool OfferToTargets()
			{
				DataflowMessageHeader header = default(DataflowMessageHeader);
				TOutput message = default(TOutput);
				int num = 0;
				lock (ValueLock)
				{
					if (_nextMessageReservedFor != null || _messages.Count <= 0)
					{
						_enableOffering = false;
						return false;
					}
					if (_targetRegistry.FirstTargetNode == null)
					{
						while (_messages.Count > 1)
						{
							_messages.Dequeue();
							num++;
						}
					}
					message = (_currentMessage = _messages.Dequeue());
					num++;
					_currentMessageIsValid = true;
					header = new DataflowMessageHeader(++_nextMessageId);
					if (_messages.Count == 0)
					{
						_enableOffering = false;
					}
				}
				if (header.IsValid)
				{
					if (_itemsRemovedAction != null)
					{
						_itemsRemovedAction(num);
					}
					TargetRegistry<TOutput>.LinkedTargetInfo linkedTargetInfo = _targetRegistry.FirstTargetNode;
					while (linkedTargetInfo != null)
					{
						TargetRegistry<TOutput>.LinkedTargetInfo next = linkedTargetInfo.Next;
						ITargetBlock<TOutput> target = linkedTargetInfo.Target;
						OfferMessageToTarget(header, message, target);
						linkedTargetInfo = next;
					}
				}
				return true;
			}

			private void OfferMessageToTarget(DataflowMessageHeader header, TOutput message, ITargetBlock<TOutput> target)
			{
				bool flag = _cloningFunction != null;
				switch (target.OfferMessage(header, message, _owningSource, flag))
				{
				case DataflowMessageStatus.Accepted:
					if (!flag)
					{
						_targetRegistry.Remove(target, onlyIfReachedMaxMessages: true);
					}
					break;
				case DataflowMessageStatus.DecliningPermanently:
					_targetRegistry.Remove(target);
					break;
				case DataflowMessageStatus.Declined:
				case DataflowMessageStatus.Postponed:
				case DataflowMessageStatus.NotAvailable:
					break;
				}
			}

			private void OfferAsyncIfNecessary(bool isReplacementReplica = false)
			{
				bool flag = _taskForOutputProcessing != null;
				bool flag2 = _enableOffering && _messages.Count > 0;
				if (!(!flag && flag2) || CanceledOrFaulted)
				{
					return;
				}
				_taskForOutputProcessing = new Task(delegate(object thisSourceCore)
				{
					((BroadcastingSourceCore<TOutput>)thisSourceCore).OfferMessagesLoopCore();
				}, this, Common.GetCreationOptionsForTask(isReplacementReplica));
				DataflowEtwProvider log = DataflowEtwProvider.Log;
				if (log.IsEnabled())
				{
					log.TaskLaunchedForMessageHandling(_owningSource, _taskForOutputProcessing, DataflowEtwProvider.TaskLaunchedReason.OfferingOutputMessages, _messages.Count);
				}
				Exception ex = Common.StartTaskSafe(_taskForOutputProcessing, _dataflowBlockOptions.TaskScheduler);
				if (ex == null)
				{
					return;
				}
				AddException(ex);
				_decliningPermanently = true;
				_taskForOutputProcessing = null;
				Task.Factory.StartNew(delegate(object state)
				{
					BroadcastingSourceCore<TOutput> broadcastingSourceCore = (BroadcastingSourceCore<TOutput>)state;
					lock (broadcastingSourceCore.OutgoingLock)
					{
						lock (broadcastingSourceCore.ValueLock)
						{
							broadcastingSourceCore.CompleteBlockIfPossible();
						}
					}
				}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
			}

			private void OfferMessagesLoopCore()
			{
				try
				{
					int actualMaxMessagesPerTask = _dataflowBlockOptions.ActualMaxMessagesPerTask;
					lock (OutgoingLock)
					{
						for (int i = 0; i < actualMaxMessagesPerTask; i++)
						{
							if (CanceledOrFaulted)
							{
								break;
							}
							if (!OfferToTargets())
							{
								break;
							}
						}
					}
				}
				catch (Exception exception)
				{
					_owningSource.CompleteCore(exception, storeExceptionEvenIfAlreadyCompleting: true);
				}
				finally
				{
					lock (OutgoingLock)
					{
						lock (ValueLock)
						{
							_taskForOutputProcessing = null;
							OfferAsyncIfNecessary(isReplacementReplica: true);
							CompleteBlockIfPossible();
						}
					}
				}
			}

			private void CompleteBlockIfPossible()
			{
				if (!_completionReserved)
				{
					bool flag = _taskForOutputProcessing != null;
					bool flag2 = _decliningPermanently && _messages.Count == 0;
					if (!flag && (flag2 || CanceledOrFaulted))
					{
						CompleteBlockIfPossible_Slow();
					}
				}
			}

			private void CompleteBlockIfPossible_Slow()
			{
				_completionReserved = true;
				Task.Factory.StartNew(delegate(object thisSourceCore)
				{
					((BroadcastingSourceCore<TOutput>)thisSourceCore).CompleteBlockOncePossible();
				}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
			}

			private void CompleteBlockOncePossible()
			{
				TargetRegistry<TOutput>.LinkedTargetInfo firstTarget;
				List<Exception> exceptions;
				lock (OutgoingLock)
				{
					firstTarget = _targetRegistry.ClearEntryPoints();
					lock (ValueLock)
					{
						_messages.Clear();
						exceptions = _exceptions;
						_exceptions = null;
					}
				}
				if (exceptions != null)
				{
					_completionTask.TrySetException(exceptions);
				}
				else if (_dataflowBlockOptions.CancellationToken.IsCancellationRequested)
				{
					_completionTask.TrySetCanceled();
				}
				else
				{
					_completionTask.TrySetResult(default(VoidResult));
				}
				_targetRegistry.PropagateCompletion(firstTarget);
				DataflowEtwProvider log = DataflowEtwProvider.Log;
				if (log.IsEnabled())
				{
					log.DataflowBlockCompleted(_owningSource);
				}
			}

			internal IDisposable LinkTo(ITargetBlock<TOutput> target, DataflowLinkOptions linkOptions)
			{
				if (target == null)
				{
					throw new ArgumentNullException("target");
				}
				if (linkOptions == null)
				{
					throw new ArgumentNullException("linkOptions");
				}
				lock (OutgoingLock)
				{
					if (_completionReserved)
					{
						OfferCurrentMessageToNewTarget(target);
						if (linkOptions.PropagateCompletion)
						{
							Common.PropagateCompletionOnceCompleted(_completionTask.Task, target);
						}
						return Disposables.Nop;
					}
					_targetRegistry.Add(ref target, linkOptions);
					OfferCurrentMessageToNewTarget(target);
					return Common.CreateUnlinker(OutgoingLock, _targetRegistry, target);
				}
			}

			internal TOutput ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target, out bool messageConsumed)
			{
				if (!messageHeader.IsValid)
				{
					throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
				}
				if (target == null)
				{
					throw new ArgumentNullException("target");
				}
				TOutput currentMessage;
				lock (OutgoingLock)
				{
					lock (ValueLock)
					{
						if (messageHeader.Id != _nextMessageId)
						{
							messageConsumed = false;
							return default(TOutput);
						}
						if (_nextMessageReservedFor == target)
						{
							_nextMessageReservedFor = null;
							_enableOffering = true;
						}
						_targetRegistry.Remove(target, onlyIfReachedMaxMessages: true);
						OfferAsyncIfNecessary();
						CompleteBlockIfPossible();
						currentMessage = _currentMessage;
					}
				}
				messageConsumed = true;
				return CloneItem(currentMessage);
			}

			internal bool ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target)
			{
				if (!messageHeader.IsValid)
				{
					throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
				}
				if (target == null)
				{
					throw new ArgumentNullException("target");
				}
				lock (OutgoingLock)
				{
					if (_nextMessageReservedFor == null)
					{
						lock (ValueLock)
						{
							if (messageHeader.Id == _nextMessageId)
							{
								_nextMessageReservedFor = target;
								_enableOffering = false;
								return true;
							}
						}
					}
				}
				return false;
			}

			internal void ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target)
			{
				if (!messageHeader.IsValid)
				{
					throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
				}
				if (target == null)
				{
					throw new ArgumentNullException("target");
				}
				lock (OutgoingLock)
				{
					if (_nextMessageReservedFor != target)
					{
						throw new InvalidOperationException(SR.InvalidOperation_MessageNotReservedByTarget);
					}
					TOutput currentMessage;
					lock (ValueLock)
					{
						if (messageHeader.Id != _nextMessageId)
						{
							throw new InvalidOperationException(SR.InvalidOperation_MessageNotReservedByTarget);
						}
						_nextMessageReservedFor = null;
						_enableOffering = true;
						currentMessage = _currentMessage;
						OfferAsyncIfNecessary();
					}
					OfferMessageToTarget(messageHeader, currentMessage, target);
				}
			}

			internal void AddException(Exception exception)
			{
				lock (ValueLock)
				{
					Common.AddException(ref _exceptions, exception);
				}
			}

			internal void AddExceptions(List<Exception> exceptions)
			{
				lock (ValueLock)
				{
					foreach (Exception exception in exceptions)
					{
						Common.AddException(ref _exceptions, exception);
					}
				}
			}

			internal DebuggingInformation GetDebuggingInformation()
			{
				return new DebuggingInformation(this);
			}
		}

		private readonly BroadcastingSourceCore<T> _source;

		private readonly BoundingStateWithPostponedAndTask<T> _boundingState;

		private bool _decliningPermanently;

		private bool _completionReserved;

		private object IncomingLock => _source;

		public Task Completion => _source.Completion;

		private bool HasValueForDebugger => _source.GetDebuggingInformation().HasValue;

		private T ValueForDebugger => _source.GetDebuggingInformation().Value;

		private object DebuggerDisplayContent => $"{Common.GetNameForDebugger(this, _source.DataflowBlockOptions)}, HasValue={HasValueForDebugger}, Value={ValueForDebugger}";

		object IDebuggerDisplay.Content => DebuggerDisplayContent;

		public BroadcastBlock(Func<T, T> cloningFunction)
			: this(cloningFunction, DataflowBlockOptions.Default)
		{
		}

		public BroadcastBlock(Func<T, T> cloningFunction, DataflowBlockOptions dataflowBlockOptions)
		{
			if (dataflowBlockOptions == null)
			{
				throw new ArgumentNullException("dataflowBlockOptions");
			}
			dataflowBlockOptions = dataflowBlockOptions.DefaultOrClone();
			Action<int> itemsRemovedAction = null;
			if (dataflowBlockOptions.BoundedCapacity > 0)
			{
				itemsRemovedAction = OnItemsRemoved;
				_boundingState = new BoundingStateWithPostponedAndTask<T>(dataflowBlockOptions.BoundedCapacity);
			}
			_source = new BroadcastingSourceCore<T>(this, cloningFunction, dataflowBlockOptions, itemsRemovedAction);
			_source.Completion.ContinueWith(delegate(Task completed, object state)
			{
				IDataflowBlock dataflowBlock = (BroadcastBlock<T>)state;
				dataflowBlock.Fault(completed.Exception);
			}, this, CancellationToken.None, Common.GetContinuationOptions() | TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
			Common.WireCancellationToComplete(dataflowBlockOptions.CancellationToken, _source.Completion, delegate(object state)
			{
				((BroadcastBlock<T>)state).Complete();
			}, this);
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.DataflowBlockCreated(this, dataflowBlockOptions);
			}
		}

		public void Complete()
		{
			CompleteCore(null, storeExceptionEvenIfAlreadyCompleting: false);
		}

		void IDataflowBlock.Fault(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			CompleteCore(exception, storeExceptionEvenIfAlreadyCompleting: false);
		}

		internal void CompleteCore(Exception exception, bool storeExceptionEvenIfAlreadyCompleting, bool revertProcessingState = false)
		{
			lock (IncomingLock)
			{
				if (exception != null && (!_decliningPermanently || storeExceptionEvenIfAlreadyCompleting))
				{
					_source.AddException(exception);
				}
				if (revertProcessingState)
				{
					_boundingState.TaskForInputProcessing = null;
				}
				_decliningPermanently = true;
				CompleteTargetIfPossible();
			}
		}

		public IDisposable LinkTo(ITargetBlock<T> target, DataflowLinkOptions linkOptions)
		{
			return _source.LinkTo(target, linkOptions);
		}

		public bool TryReceive(Predicate<T> filter, out T item)
		{
			return _source.TryReceive(filter, out item);
		}

		bool IReceivableSourceBlock<T>.TryReceiveAll(out IList<T> items)
		{
			return _source.TryReceiveAll(out items);
		}

		DataflowMessageStatus ITargetBlock<T>.OfferMessage(DataflowMessageHeader messageHeader, T messageValue, ISourceBlock<T> source, bool consumeToAccept)
		{
			if (!messageHeader.IsValid)
			{
				throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
			}
			if (source == null && consumeToAccept)
			{
				throw new ArgumentException(SR.Argument_CantConsumeFromANullSource, "consumeToAccept");
			}
			lock (IncomingLock)
			{
				if (_decliningPermanently)
				{
					CompleteTargetIfPossible();
					return DataflowMessageStatus.DecliningPermanently;
				}
				if (_boundingState == null || (_boundingState.CountIsLessThanBound && _boundingState.PostponedMessages.Count == 0 && _boundingState.TaskForInputProcessing == null))
				{
					if (consumeToAccept)
					{
						messageValue = source.ConsumeMessage(messageHeader, this, out var messageConsumed);
						if (!messageConsumed)
						{
							return DataflowMessageStatus.NotAvailable;
						}
					}
					_source.AddMessage(messageValue);
					if (_boundingState != null)
					{
						_boundingState.CurrentCount++;
					}
					return DataflowMessageStatus.Accepted;
				}
				if (source != null)
				{
					_boundingState.PostponedMessages.Push(source, messageHeader);
					return DataflowMessageStatus.Postponed;
				}
				return DataflowMessageStatus.Declined;
			}
		}

		private void OnItemsRemoved(int numItemsRemoved)
		{
			if (_boundingState != null)
			{
				lock (IncomingLock)
				{
					_boundingState.CurrentCount -= numItemsRemoved;
					ConsumeAsyncIfNecessary();
					CompleteTargetIfPossible();
				}
			}
		}

		internal void ConsumeAsyncIfNecessary(bool isReplacementReplica = false)
		{
			if (_decliningPermanently || _boundingState.TaskForInputProcessing != null || _boundingState.PostponedMessages.Count <= 0 || !_boundingState.CountIsLessThanBound)
			{
				return;
			}
			_boundingState.TaskForInputProcessing = new Task(delegate(object state)
			{
				((BroadcastBlock<T>)state).ConsumeMessagesLoopCore();
			}, this, Common.GetCreationOptionsForTask(isReplacementReplica));
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.TaskLaunchedForMessageHandling(this, _boundingState.TaskForInputProcessing, DataflowEtwProvider.TaskLaunchedReason.ProcessingInputMessages, _boundingState.PostponedMessages.Count);
			}
			Exception ex = Common.StartTaskSafe(_boundingState.TaskForInputProcessing, _source.DataflowBlockOptions.TaskScheduler);
			if (ex != null)
			{
				Task.Factory.StartNew(delegate(object exc)
				{
					CompleteCore((Exception)exc, storeExceptionEvenIfAlreadyCompleting: true, revertProcessingState: true);
				}, ex, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
			}
		}

		private void ConsumeMessagesLoopCore()
		{
			try
			{
				int actualMaxMessagesPerTask = _source.DataflowBlockOptions.ActualMaxMessagesPerTask;
				for (int i = 0; i < actualMaxMessagesPerTask; i++)
				{
					if (!ConsumeAndStoreOneMessageIfAvailable())
					{
						break;
					}
				}
			}
			catch (Exception exception)
			{
				CompleteCore(exception, storeExceptionEvenIfAlreadyCompleting: true);
			}
			finally
			{
				lock (IncomingLock)
				{
					_boundingState.TaskForInputProcessing = null;
					ConsumeAsyncIfNecessary(isReplacementReplica: true);
					CompleteTargetIfPossible();
				}
			}
		}

		private bool ConsumeAndStoreOneMessageIfAvailable()
		{
			while (true)
			{
				KeyValuePair<ISourceBlock<T>, DataflowMessageHeader> item;
				lock (IncomingLock)
				{
					if (!_boundingState.CountIsLessThanBound)
					{
						return false;
					}
					if (!_boundingState.PostponedMessages.TryPop(out item))
					{
						return false;
					}
					_boundingState.CurrentCount++;
				}
				bool messageConsumed = false;
				try
				{
					T item2 = item.Key.ConsumeMessage(item.Value, this, out messageConsumed);
					if (messageConsumed)
					{
						_source.AddMessage(item2);
						return true;
					}
				}
				finally
				{
					if (!messageConsumed)
					{
						lock (IncomingLock)
						{
							_boundingState.CurrentCount--;
						}
					}
				}
			}
		}

		private void CompleteTargetIfPossible()
		{
			if (!_decliningPermanently || _completionReserved || (_boundingState != null && _boundingState.TaskForInputProcessing != null))
			{
				return;
			}
			_completionReserved = true;
			if (_boundingState != null && _boundingState.PostponedMessages.Count > 0)
			{
				Task.Factory.StartNew(delegate(object state)
				{
					BroadcastBlock<T> broadcastBlock = (BroadcastBlock<T>)state;
					List<Exception> exceptions = null;
					if (broadcastBlock._boundingState != null)
					{
						Common.ReleaseAllPostponedMessages(broadcastBlock, broadcastBlock._boundingState.PostponedMessages, ref exceptions);
					}
					if (exceptions != null)
					{
						broadcastBlock._source.AddExceptions(exceptions);
					}
					broadcastBlock._source.Complete();
				}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
			}
			else
			{
				_source.Complete();
			}
		}

		T ISourceBlock<T>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<T> target, out bool messageConsumed)
		{
			return _source.ConsumeMessage(messageHeader, target, out messageConsumed);
		}

		bool ISourceBlock<T>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<T> target)
		{
			return _source.ReserveMessage(messageHeader, target);
		}

		void ISourceBlock<T>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<T> target)
		{
			_source.ReleaseReservation(messageHeader, target);
		}

		public override string ToString()
		{
			return Common.GetNameForDebugger(this, _source.DataflowBlockOptions);
		}
	}
	[DebuggerTypeProxy(typeof(BufferBlock<>.DebugView))]
	[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
	public sealed class BufferBlock<T> : IPropagatorBlock<T, T>, ITargetBlock<T>, IDataflowBlock, ISourceBlock<T>, IReceivableSourceBlock<T>, IDebuggerDisplay
	{
		private sealed class DebugView
		{
			private readonly BufferBlock<T> _bufferBlock;

			private readonly SourceCore<T>.DebuggingInformation _sourceDebuggingInformation;

			public QueuedMap<ISourceBlock<T>, DataflowMessageHeader> PostponedMessages
			{
				get
				{
					if (_bufferBlock._boundingState == null)
					{
						return null;
					}
					return _bufferBlock._boundingState.PostponedMessages;
				}
			}

			public IEnumerable<T> Queue => _sourceDebuggingInformation.OutputQueue;

			public Task TaskForInputProcessing
			{
				get
				{
					if (_bufferBlock._boundingState == null)
					{
						return null;
					}
					return _bufferBlock._boundingState.TaskForInputProcessing;
				}
			}

			public Task TaskForOutputProcessing => _sourceDebuggingInformation.TaskForOutputProcessing;

			public DataflowBlockOptions DataflowBlockOptions => _sourceDebuggingInformation.DataflowBlockOptions;

			public bool IsDecliningPermanently => _bufferBlock._targetDecliningPermanently;

			public bool IsCompleted => _sourceDebuggingInformation.IsCompleted;

			public int Id => Common.GetBlockId(_bufferBlock);

			public TargetRegistry<T> LinkedTargets => _sourceDebuggingInformation.LinkedTargets;

			public ITargetBlock<T> NextMessageReservedFor => _sourceDebuggingInformation.NextMessageReservedFor;

			public DebugView(BufferBlock<T> bufferBlock)
			{
				_bufferBlock = bufferBlock;
				_sourceDebuggingInformation = bufferBlock._source.GetDebuggingInformation();
			}
		}

		private readonly SourceCore<T> _source;

		private readonly BoundingStateWithPostponedAndTask<T> _boundingState;

		private bool _targetDecliningPermanently;

		private bool _targetCompletionReserved;

		private object IncomingLock => _source;

		public int Count => _source.OutputCount;

		public Task Completion => _source.Completion;

		private int CountForDebugger => _source.GetDebuggingInformation().OutputCount;

		private object DebuggerDisplayContent => $"{Common.GetNameForDebugger(this, _source.DataflowBlockOptions)}, Count={CountForDebugger}";

		object IDebuggerDisplay.Content => DebuggerDisplayContent;

		public BufferBlock()
			: this(DataflowBlockOptions.Default)
		{
		}

		public BufferBlock(DataflowBlockOptions dataflowBlockOptions)
		{
			if (dataflowBlockOptions == null)
			{
				throw new ArgumentNullException("dataflowBlockOptions");
			}
			dataflowBlockOptions = dataflowBlockOptions.DefaultOrClone();
			Action<ISourceBlock<T>, int> itemsRemovedAction = null;
			if (dataflowBlockOptions.BoundedCapacity > 0)
			{
				itemsRemovedAction = delegate(ISourceBlock<T> owningSource, int count)
				{
					((BufferBlock<T>)owningSource).OnItemsRemoved(count);
				};
				_boundingState = new BoundingStateWithPostponedAndTask<T>(dataflowBlockOptions.BoundedCapacity);
			}
			_source = new SourceCore<T>(this, dataflowBlockOptions, delegate(ISourceBlock<T> owningSource)
			{
				((BufferBlock<T>)owningSource).Complete();
			}, itemsRemovedAction);
			_source.Completion.ContinueWith(delegate(Task completed, object state)
			{
				IDataflowBlock dataflowBlock = (BufferBlock<T>)state;
				dataflowBlock.Fault(completed.Exception);
			}, this, CancellationToken.None, Common.GetContinuationOptions() | TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
			Common.WireCancellationToComplete(dataflowBlockOptions.CancellationToken, _source.Completion, delegate(object owningSource)
			{
				((BufferBlock<T>)owningSource).Complete();
			}, this);
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.DataflowBlockCreated(this, dataflowBlockOptions);
			}
		}

		DataflowMessageStatus ITargetBlock<T>.OfferMessage(DataflowMessageHeader messageHeader, T messageValue, ISourceBlock<T> source, bool consumeToAccept)
		{
			if (!messageHeader.IsValid)
			{
				throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
			}
			if (source == null && consumeToAccept)
			{
				throw new ArgumentException(SR.Argument_CantConsumeFromANullSource, "consumeToAccept");
			}
			lock (IncomingLock)
			{
				if (_targetDecliningPermanently)
				{
					CompleteTargetIfPossible();
					return DataflowMessageStatus.DecliningPermanently;
				}
				if (_boundingState == null || (_boundingState.CountIsLessThanBound && _boundingState.PostponedMessages.Count == 0 && _boundingState.TaskForInputProcessing == null))
				{
					if (consumeToAccept)
					{
						messageValue = source.ConsumeMessage(messageHeader, this, out var messageConsumed);
						if (!messageConsumed)
						{
							return DataflowMessageStatus.NotAvailable;
						}
					}
					_source.AddMessage(messageValue);
					if (_boundingState != null)
					{
						_boundingState.CurrentCount++;
					}
					return DataflowMessageStatus.Accepted;
				}
				if (source != null)
				{
					_boundingState.PostponedMessages.Push(source, messageHeader);
					return DataflowMessageStatus.Postponed;
				}
				return DataflowMessageStatus.Declined;
			}
		}

		public void Complete()
		{
			CompleteCore(null, storeExceptionEvenIfAlreadyCompleting: false);
		}

		void IDataflowBlock.Fault(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			CompleteCore(exception, storeExceptionEvenIfAlreadyCompleting: false);
		}

		private void CompleteCore(Exception exception, bool storeExceptionEvenIfAlreadyCompleting, bool revertProcessingState = false)
		{
			lock (IncomingLock)
			{
				if (exception != null && (!_targetDecliningPermanently || storeExceptionEvenIfAlreadyCompleting))
				{
					_source.AddException(exception);
				}
				if (revertProcessingState)
				{
					_boundingState.TaskForInputProcessing = null;
				}
				_targetDecliningPermanently = true;
				CompleteTargetIfPossible();
			}
		}

		public IDisposable LinkTo(ITargetBlock<T> target, DataflowLinkOptions linkOptions)
		{
			return _source.LinkTo(target, linkOptions);
		}

		public bool TryReceive(Predicate<T> filter, out T item)
		{
			return _source.TryReceive(filter, out item);
		}

		public bool TryReceiveAll(out IList<T> items)
		{
			return _source.TryReceiveAll(out items);
		}

		T ISourceBlock<T>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<T> target, out bool messageConsumed)
		{
			return _source.ConsumeMessage(messageHeader, target, out messageConsumed);
		}

		bool ISourceBlock<T>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<T> target)
		{
			return _source.ReserveMessage(messageHeader, target);
		}

		void ISourceBlock<T>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<T> target)
		{
			_source.ReleaseReservation(messageHeader, target);
		}

		private void OnItemsRemoved(int numItemsRemoved)
		{
			if (_boundingState != null)
			{
				lock (IncomingLock)
				{
					_boundingState.CurrentCount -= numItemsRemoved;
					ConsumeAsyncIfNecessary();
					CompleteTargetIfPossible();
				}
			}
		}

		internal void ConsumeAsyncIfNecessary(bool isReplacementReplica = false)
		{
			if (_targetDecliningPermanently || _boundingState.TaskForInputProcessing != null || _boundingState.PostponedMessages.Count <= 0 || !_boundingState.CountIsLessThanBound)
			{
				return;
			}
			_boundingState.TaskForInputProcessing = new Task(delegate(object state)
			{
				((BufferBlock<T>)state).ConsumeMessagesLoopCore();
			}, this, Common.GetCreationOptionsForTask(isReplacementReplica));
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.TaskLaunchedForMessageHandling(this, _boundingState.TaskForInputProcessing, DataflowEtwProvider.TaskLaunchedReason.ProcessingInputMessages, _boundingState.PostponedMessages.Count);
			}
			Exception ex = Common.StartTaskSafe(_boundingState.TaskForInputProcessing, _source.DataflowBlockOptions.TaskScheduler);
			if (ex != null)
			{
				Task.Factory.StartNew(delegate(object exc)
				{
					CompleteCore((Exception)exc, storeExceptionEvenIfAlreadyCompleting: true, revertProcessingState: true);
				}, ex, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
			}
		}

		private void ConsumeMessagesLoopCore()
		{
			try
			{
				int actualMaxMessagesPerTask = _source.DataflowBlockOptions.ActualMaxMessagesPerTask;
				for (int i = 0; i < actualMaxMessagesPerTask; i++)
				{
					if (!ConsumeAndStoreOneMessageIfAvailable())
					{
						break;
					}
				}
			}
			catch (Exception exception)
			{
				CompleteCore(exception, storeExceptionEvenIfAlreadyCompleting: true);
			}
			finally
			{
				lock (IncomingLock)
				{
					_boundingState.TaskForInputProcessing = null;
					ConsumeAsyncIfNecessary(isReplacementReplica: true);
					CompleteTargetIfPossible();
				}
			}
		}

		private bool ConsumeAndStoreOneMessageIfAvailable()
		{
			while (true)
			{
				KeyValuePair<ISourceBlock<T>, DataflowMessageHeader> item;
				lock (IncomingLock)
				{
					if (_targetDecliningPermanently)
					{
						return false;
					}
					if (!_boundingState.CountIsLessThanBound)
					{
						return false;
					}
					if (!_boundingState.PostponedMessages.TryPop(out item))
					{
						return false;
					}
					_boundingState.CurrentCount++;
				}
				bool messageConsumed = false;
				try
				{
					T item2 = item.Key.ConsumeMessage(item.Value, this, out messageConsumed);
					if (messageConsumed)
					{
						_source.AddMessage(item2);
						return true;
					}
				}
				finally
				{
					if (!messageConsumed)
					{
						lock (IncomingLock)
						{
							_boundingState.CurrentCount--;
						}
					}
				}
			}
		}

		private void CompleteTargetIfPossible()
		{
			if (!_targetDecliningPermanently || _targetCompletionReserved || (_boundingState != null && _boundingState.TaskForInputProcessing != null))
			{
				return;
			}
			_targetCompletionReserved = true;
			if (_boundingState != null && _boundingState.PostponedMessages.Count > 0)
			{
				Task.Factory.StartNew(delegate(object state)
				{
					BufferBlock<T> bufferBlock = (BufferBlock<T>)state;
					List<Exception> exceptions = null;
					if (bufferBlock._boundingState != null)
					{
						Common.ReleaseAllPostponedMessages(bufferBlock, bufferBlock._boundingState.PostponedMessages, ref exceptions);
					}
					if (exceptions != null)
					{
						bufferBlock._source.AddExceptions(exceptions);
					}
					bufferBlock._source.Complete();
				}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
			}
			else
			{
				_source.Complete();
			}
		}

		public override string ToString()
		{
			return Common.GetNameForDebugger(this, _source.DataflowBlockOptions);
		}
	}
	[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
	[DebuggerTypeProxy(typeof(JoinBlock<, >.DebugView))]
	public sealed class JoinBlock<T1, T2> : IReceivableSourceBlock<Tuple<T1, T2>>, ISourceBlock<Tuple<T1, T2>>, IDataflowBlock, IDebuggerDisplay
	{
		private sealed class DebugView
		{
			private readonly JoinBlock<T1, T2> _joinBlock;

			private readonly SourceCore<Tuple<T1, T2>>.DebuggingInformation _sourceDebuggingInformation;

			public IEnumerable<Tuple<T1, T2>> OutputQueue => _sourceDebuggingInformation.OutputQueue;

			public long JoinsCreated => _joinBlock._sharedResources._joinsCreated;

			public Task TaskForInputProcessing => _joinBlock._sharedResources._taskForInputProcessing;

			public Task TaskForOutputProcessing => _sourceDebuggingInformation.TaskForOutputProcessing;

			public GroupingDataflowBlockOptions DataflowBlockOptions => (GroupingDataflowBlockOptions)_sourceDebuggingInformation.DataflowBlockOptions;

			public bool IsDecliningPermanently => _joinBlock._sharedResources._decliningPermanently;

			public bool IsCompleted => _sourceDebuggingInformation.IsCompleted;

			public int Id => Common.GetBlockId(_joinBlock);

			public ITargetBlock<T1> Target1 => _joinBlock._target1;

			public ITargetBlock<T2> Target2 => _joinBlock._target2;

			public TargetRegistry<Tuple<T1, T2>> LinkedTargets => _sourceDebuggingInformation.LinkedTargets;

			public ITargetBlock<Tuple<T1, T2>> NextMessageReservedFor => _sourceDebuggingInformation.NextMessageReservedFor;

			public DebugView(JoinBlock<T1, T2> joinBlock)
			{
				_joinBlock = joinBlock;
				_sourceDebuggingInformation = joinBlock._source.GetDebuggingInformation();
			}
		}

		private readonly JoinBlockTargetSharedResources _sharedResources;

		private readonly SourceCore<Tuple<T1, T2>> _source;

		private readonly JoinBlockTarget<T1> _target1;

		private readonly JoinBlockTarget<T2> _target2;

		public int OutputCount => _source.OutputCount;

		public Task Completion => _source.Completion;

		public ITargetBlock<T1> Target1 => _target1;

		public ITargetBlock<T2> Target2 => _target2;

		private int OutputCountForDebugger => _source.GetDebuggingInformation().OutputCount;

		private object DebuggerDisplayContent => $"{Common.GetNameForDebugger(this, _source.DataflowBlockOptions)}, OutputCount={OutputCountForDebugger}";

		object IDebuggerDisplay.Content => DebuggerDisplayContent;

		public JoinBlock()
			: this(GroupingDataflowBlockOptions.Default)
		{
		}

		public JoinBlock(GroupingDataflowBlockOptions dataflowBlockOptions)
		{
			if (dataflowBlockOptions == null)
			{
				throw new ArgumentNullException("dataflowBlockOptions");
			}
			dataflowBlockOptions = dataflowBlockOptions.DefaultOrClone();
			Action<ISourceBlock<Tuple<T1, T2>>, int> itemsRemovedAction = null;
			if (dataflowBlockOptions.BoundedCapacity > 0)
			{
				itemsRemovedAction = delegate(ISourceBlock<Tuple<T1, T2>> owningSource, int count)
				{
					((JoinBlock<T1, T2>)owningSource)._sharedResources.OnItemsRemoved(count);
				};
			}
			_source = new SourceCore<Tuple<T1, T2>>(this, dataflowBlockOptions, delegate(ISourceBlock<Tuple<T1, T2>> owningSource)
			{
				((JoinBlock<T1, T2>)owningSource)._sharedResources.CompleteEachTarget();
			}, itemsRemovedAction);
			JoinBlockTargetBase[] array = new JoinBlockTargetBase[2];
			_sharedResources = new JoinBlockTargetSharedResources(this, array, delegate
			{
				_source.AddMessage(Tuple.Create(_target1.GetOneMessage(), _target2.GetOneMessage()));
			}, delegate(Exception exception)
			{
				Volatile.Write(ref _sharedResources._hasExceptions, value: true);
				_source.AddException(exception);
			}, dataflowBlockOptions);
			array[0] = (_target1 = new JoinBlockTarget<T1>(_sharedResources));
			array[1] = (_target2 = new JoinBlockTarget<T2>(_sharedResources));
			Task.Factory.ContinueWhenAll(new Task[2] { _target1.CompletionTaskInternal, _target2.CompletionTaskInternal }, delegate
			{
				_source.Complete();
			}, CancellationToken.None, Common.GetContinuationOptions(), TaskScheduler.Default);
			_source.Completion.ContinueWith(delegate(Task completed, object state)
			{
				IDataflowBlock dataflowBlock = (JoinBlock<T1, T2>)state;
				dataflowBlock.Fault(completed.Exception);
			}, this, CancellationToken.None, Common.GetContinuationOptions() | TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
			Common.WireCancellationToComplete(dataflowBlockOptions.CancellationToken, _source.Completion, delegate(object state)
			{
				((JoinBlock<T1, T2>)state)._sharedResources.CompleteEachTarget();
			}, this);
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.DataflowBlockCreated(this, dataflowBlockOptions);
			}
		}

		public IDisposable LinkTo(ITargetBlock<Tuple<T1, T2>> target, DataflowLinkOptions linkOptions)
		{
			return _source.LinkTo(target, linkOptions);
		}

		public bool TryReceive(Predicate<Tuple<T1, T2>> filter, out Tuple<T1, T2> item)
		{
			return _source.TryReceive(filter, out item);
		}

		public bool TryReceiveAll(out IList<Tuple<T1, T2>> items)
		{
			return _source.TryReceiveAll(out items);
		}

		public void Complete()
		{
			_target1.CompleteCore(null, dropPendingMessages: false, releaseReservedMessages: false);
			_target2.CompleteCore(null, dropPendingMessages: false, releaseReservedMessages: false);
		}

		void IDataflowBlock.Fault(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			lock (_sharedResources.IncomingLock)
			{
				if (!_sharedResources._decliningPermanently)
				{
					_sharedResources._exceptionAction(exception);
				}
			}
			Complete();
		}

		Tuple<T1, T2> ISourceBlock<Tuple<T1, T2>>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<T1, T2>> target, out bool messageConsumed)
		{
			return _source.ConsumeMessage(messageHeader, target, out messageConsumed);
		}

		bool ISourceBlock<Tuple<T1, T2>>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<T1, T2>> target)
		{
			return _source.ReserveMessage(messageHeader, target);
		}

		void ISourceBlock<Tuple<T1, T2>>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<T1, T2>> target)
		{
			_source.ReleaseReservation(messageHeader, target);
		}

		public override string ToString()
		{
			return Common.GetNameForDebugger(this, _source.DataflowBlockOptions);
		}
	}
	[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
	[DebuggerTypeProxy(typeof(JoinBlock<, , >.DebugView))]
	public sealed class JoinBlock<T1, T2, T3> : IReceivableSourceBlock<Tuple<T1, T2, T3>>, ISourceBlock<Tuple<T1, T2, T3>>, IDataflowBlock, IDebuggerDisplay
	{
		private sealed class DebugView
		{
			private readonly JoinBlock<T1, T2, T3> _joinBlock;

			private readonly SourceCore<Tuple<T1, T2, T3>>.DebuggingInformation _sourceDebuggingInformation;

			public IEnumerable<Tuple<T1, T2, T3>> OutputQueue => _sourceDebuggingInformation.OutputQueue;

			public long JoinsCreated => _joinBlock._sharedResources._joinsCreated;

			public Task TaskForInputProcessing => _joinBlock._sharedResources._taskForInputProcessing;

			public Task TaskForOutputProcessing => _sourceDebuggingInformation.TaskForOutputProcessing;

			public GroupingDataflowBlockOptions DataflowBlockOptions => (GroupingDataflowBlockOptions)_sourceDebuggingInformation.DataflowBlockOptions;

			public bool IsDecliningPermanently => _joinBlock._sharedResources._decliningPermanently;

			public bool IsCompleted => _sourceDebuggingInformation.IsCompleted;

			public int Id => Common.GetBlockId(_joinBlock);

			public ITargetBlock<T1> Target1 => _joinBlock._target1;

			public ITargetBlock<T2> Target2 => _joinBlock._target2;

			public ITargetBlock<T3> Target3 => _joinBlock._target3;

			public TargetRegistry<Tuple<T1, T2, T3>> LinkedTargets => _sourceDebuggingInformation.LinkedTargets;

			public ITargetBlock<Tuple<T1, T2, T3>> NextMessageReservedFor => _sourceDebuggingInformation.NextMessageReservedFor;

			public DebugView(JoinBlock<T1, T2, T3> joinBlock)
			{
				_joinBlock = joinBlock;
				_sourceDebuggingInformation = joinBlock._source.GetDebuggingInformation();
			}
		}

		private readonly JoinBlockTargetSharedResources _sharedResources;

		private readonly SourceCore<Tuple<T1, T2, T3>> _source;

		private readonly JoinBlockTarget<T1> _target1;

		private readonly JoinBlockTarget<T2> _target2;

		private readonly JoinBlockTarget<T3> _target3;

		public int OutputCount => _source.OutputCount;

		public Task Completion => _source.Completion;

		public ITargetBlock<T1> Target1 => _target1;

		public ITargetBlock<T2> Target2 => _target2;

		public ITargetBlock<T3> Target3 => _target3;

		private int OutputCountForDebugger => _source.GetDebuggingInformation().OutputCount;

		private object DebuggerDisplayContent => $"{Common.GetNameForDebugger(this, _source.DataflowBlockOptions)} OutputCount={OutputCountForDebugger}";

		object IDebuggerDisplay.Content => DebuggerDisplayContent;

		public JoinBlock()
			: this(GroupingDataflowBlockOptions.Default)
		{
		}

		public JoinBlock(GroupingDataflowBlockOptions dataflowBlockOptions)
		{
			if (dataflowBlockOptions == null)
			{
				throw new ArgumentNullException("dataflowBlockOptions");
			}
			dataflowBlockOptions = dataflowBlockOptions.DefaultOrClone();
			Action<ISourceBlock<Tuple<T1, T2, T3>>, int> itemsRemovedAction = null;
			if (dataflowBlockOptions.BoundedCapacity > 0)
			{
				itemsRemovedAction = delegate(ISourceBlock<Tuple<T1, T2, T3>> owningSource, int count)
				{
					((JoinBlock<T1, T2, T3>)owningSource)._sharedResources.OnItemsRemoved(count);
				};
			}
			_source = new SourceCore<Tuple<T1, T2, T3>>(this, dataflowBlockOptions, delegate(ISourceBlock<Tuple<T1, T2, T3>> owningSource)
			{
				((JoinBlock<T1, T2, T3>)owningSource)._sharedResources.CompleteEachTarget();
			}, itemsRemovedAction);
			JoinBlockTargetBase[] array = new JoinBlockTargetBase[3];
			_sharedResources = new JoinBlockTargetSharedResources(this, array, delegate
			{
				_source.AddMessage(Tuple.Create(_target1.GetOneMessage(), _target2.GetOneMessage(), _target3.GetOneMessage()));
			}, delegate(Exception exception)
			{
				Volatile.Write(ref _sharedResources._hasExceptions, value: true);
				_source.AddException(exception);
			}, dataflowBlockOptions);
			array[0] = (_target1 = new JoinBlockTarget<T1>(_sharedResources));
			array[1] = (_target2 = new JoinBlockTarget<T2>(_sharedResources));
			array[2] = (_target3 = new JoinBlockTarget<T3>(_sharedResources));
			Task.Factory.ContinueWhenAll(new Task[3] { _target1.CompletionTaskInternal, _target2.CompletionTaskInternal, _target3.CompletionTaskInternal }, delegate
			{
				_source.Complete();
			}, CancellationToken.None, Common.GetContinuationOptions(), TaskScheduler.Default);
			_source.Completion.ContinueWith(delegate(Task completed, object state)
			{
				IDataflowBlock dataflowBlock = (JoinBlock<T1, T2, T3>)state;
				dataflowBlock.Fault(completed.Exception);
			}, this, CancellationToken.None, Common.GetContinuationOptions() | TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
			Common.WireCancellationToComplete(dataflowBlockOptions.CancellationToken, _source.Completion, delegate(object state)
			{
				((JoinBlock<T1, T2, T3>)state)._sharedResources.CompleteEachTarget();
			}, this);
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.DataflowBlockCreated(this, dataflowBlockOptions);
			}
		}

		public IDisposable LinkTo(ITargetBlock<Tuple<T1, T2, T3>> target, DataflowLinkOptions linkOptions)
		{
			return _source.LinkTo(target, linkOptions);
		}

		public bool TryReceive(Predicate<Tuple<T1, T2, T3>> filter, out Tuple<T1, T2, T3> item)
		{
			return _source.TryReceive(filter, out item);
		}

		public bool TryReceiveAll(out IList<Tuple<T1, T2, T3>> items)
		{
			return _source.TryReceiveAll(out items);
		}

		public void Complete()
		{
			_target1.CompleteCore(null, dropPendingMessages: false, releaseReservedMessages: false);
			_target2.CompleteCore(null, dropPendingMessages: false, releaseReservedMessages: false);
			_target3.CompleteCore(null, dropPendingMessages: false, releaseReservedMessages: false);
		}

		void IDataflowBlock.Fault(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			lock (_sharedResources.IncomingLock)
			{
				if (!_sharedResources._decliningPermanently)
				{
					_sharedResources._exceptionAction(exception);
				}
			}
			Complete();
		}

		Tuple<T1, T2, T3> ISourceBlock<Tuple<T1, T2, T3>>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<T1, T2, T3>> target, out bool messageConsumed)
		{
			return _source.ConsumeMessage(messageHeader, target, out messageConsumed);
		}

		bool ISourceBlock<Tuple<T1, T2, T3>>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<T1, T2, T3>> target)
		{
			return _source.ReserveMessage(messageHeader, target);
		}

		void ISourceBlock<Tuple<T1, T2, T3>>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<Tuple<T1, T2, T3>> target)
		{
			_source.ReleaseReservation(messageHeader, target);
		}

		public override string ToString()
		{
			return Common.GetNameForDebugger(this, _source.DataflowBlockOptions);
		}
	}
	[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
	[DebuggerTypeProxy(typeof(TransformBlock<, >.DebugView))]
	public sealed class TransformBlock<TInput, TOutput> : IPropagatorBlock<TInput, TOutput>, ITargetBlock<TInput>, IDataflowBlock, ISourceBlock<TOutput>, IReceivableSourceBlock<TOutput>, IDebuggerDisplay
	{
		private sealed class DebugView
		{
			private readonly TransformBlock<TInput, TOutput> _transformBlock;

			private readonly TargetCore<TInput>.DebuggingInformation _targetDebuggingInformation;

			private readonly SourceCore<TOutput>.DebuggingInformation _sourceDebuggingInformation;

			public IEnumerable<TInput> InputQueue => _targetDebuggingInformation.InputQueue;

			public QueuedMap<ISourceBlock<TInput>, DataflowMessageHeader> PostponedMessages => _targetDebuggingInformation.PostponedMessages;

			public IEnumerable<TOutput> OutputQueue => _sourceDebuggingInformation.OutputQueue;

			public int CurrentDegreeOfParallelism => _targetDebuggingInformation.CurrentDegreeOfParallelism;

			public Task TaskForOutputProcessing => _sourceDebuggingInformation.TaskForOutputProcessing;

			public ExecutionDataflowBlockOptions DataflowBlockOptions => _targetDebuggingInformation.DataflowBlockOptions;

			public bool IsDecliningPermanently => _targetDebuggingInformation.IsDecliningPermanently;

			public bool IsCompleted => _sourceDebuggingInformation.IsCompleted;

			public int Id => Common.GetBlockId(_transformBlock);

			public TargetRegistry<TOutput> LinkedTargets => _sourceDebuggingInformation.LinkedTargets;

			public ITargetBlock<TOutput> NextMessageReservedFor => _sourceDebuggingInformation.NextMessageReservedFor;

			public DebugView(TransformBlock<TInput, TOutput> transformBlock)
			{
				_transformBlock = transformBlock;
				_targetDebuggingInformation = transformBlock._target.GetDebuggingInformation();
				_sourceDebuggingInformation = transformBlock._source.GetDebuggingInformation();
			}
		}

		private readonly TargetCore<TInput> _target;

		private readonly ReorderingBuffer<TOutput> _reorderingBuffer;

		private readonly SourceCore<TOutput> _source;

		private object ParallelSourceLock => _source;

		public Task Completion => _source.Completion;

		public int InputCount => _target.InputCount;

		public int OutputCount => _source.OutputCount;

		private int InputCountForDebugger => _target.GetDebuggingInformation().InputCount;

		private int OutputCountForDebugger => _source.GetDebuggingInformation().OutputCount;

		private object DebuggerDisplayContent => $"{Common.GetNameForDebugger(this, _source.DataflowBlockOptions)}, InputCount={InputCountForDebugger}, OutputCount={OutputCountForDebugger}";

		object IDebuggerDisplay.Content => DebuggerDisplayContent;

		public TransformBlock(Func<TInput, TOutput> transform)
			: this(transform, (Func<TInput, Task<TOutput>>)null, ExecutionDataflowBlockOptions.Default)
		{
		}

		public TransformBlock(Func<TInput, TOutput> transform, ExecutionDataflowBlockOptions dataflowBlockOptions)
			: this(transform, (Func<TInput, Task<TOutput>>)null, dataflowBlockOptions)
		{
		}

		public TransformBlock(Func<TInput, Task<TOutput>> transform)
			: this((Func<TInput, TOutput>)null, transform, ExecutionDataflowBlockOptions.Default)
		{
		}

		public TransformBlock(Func<TInput, Task<TOutput>> transform, ExecutionDataflowBlockOptions dataflowBlockOptions)
			: this((Func<TInput, TOutput>)null, transform, dataflowBlockOptions)
		{
		}

		private TransformBlock(Func<TInput, TOutput> transformSync, Func<TInput, Task<TOutput>> transformAsync, ExecutionDataflowBlockOptions dataflowBlockOptions)
		{
			TransformBlock<TInput, TOutput> transformBlock = this;
			if (transformSync == null && transformAsync == null)
			{
				throw new ArgumentNullException("transform");
			}
			if (dataflowBlockOptions == null)
			{
				throw new ArgumentNullException("dataflowBlockOptions");
			}
			dataflowBlockOptions = dataflowBlockOptions.DefaultOrClone();
			Action<ISourceBlock<TOutput>, int> itemsRemovedAction = null;
			if (dataflowBlockOptions.BoundedCapacity > 0)
			{
				itemsRemovedAction = delegate(ISourceBlock<TOutput> owningSource, int count)
				{
					((TransformBlock<TInput, TOutput>)owningSource)._target.ChangeBoundingCount(-count);
				};
			}
			_source = new SourceCore<TOutput>(this, dataflowBlockOptions, delegate(ISourceBlock<TOutput> owningSource)
			{
				((TransformBlock<TInput, TOutput>)owningSource)._target.Complete(null, dropPendingMessages: true);
			}, itemsRemovedAction);
			if (dataflowBlockOptions.SupportsParallelExecution && dataflowBlockOptions.EnsureOrdered)
			{
				_reorderingBuffer = new ReorderingBuffer<TOutput>(this, delegate(object owningSource, TOutput message)
				{
					((TransformBlock<TInput, TOutput>)owningSource)._source.AddMessage(message);
				});
			}
			if (transformSync != null)
			{
				_target = new TargetCore<TInput>(this, delegate(KeyValuePair<TInput, long> messageWithId)
				{
					transformBlock.ProcessMessage(transformSync, messageWithId);
				}, _reorderingBuffer, dataflowBlockOptions, TargetCoreOptions.None);
			}
			else
			{
				_target = new TargetCore<TInput>(this, delegate(KeyValuePair<TInput, long> messageWithId)
				{
					transformBlock.ProcessMessageWithTask(transformAsync, messageWithId);
				}, _reorderingBuffer, dataflowBlockOptions, TargetCoreOptions.UsesAsyncCompletion);
			}
			_target.Completion.ContinueWith(delegate(Task completed, object state)
			{
				SourceCore<TOutput> sourceCore = (SourceCore<TOutput>)state;
				if (completed.IsFaulted)
				{
					sourceCore.AddAndUnwrapAggregateException(completed.Exception);
				}
				sourceCore.Complete();
			}, _source, CancellationToken.None, Common.GetContinuationOptions(), TaskScheduler.Default);
			_source.Completion.ContinueWith(delegate(Task completed, object state)
			{
				IDataflowBlock dataflowBlock = (TransformBlock<TInput, TOutput>)state;
				dataflowBlock.Fault(completed.Exception);
			}, this, CancellationToken.None, Common.GetContinuationOptions() | TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
			Common.WireCancellationToComplete(dataflowBlockOptions.CancellationToken, Completion, delegate(object state)
			{
				((TargetCore<TInput>)state).Complete(null, dropPendingMessages: true);
			}, _target);
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.DataflowBlockCreated(this, dataflowBlockOptions);
			}
		}

		private void ProcessMessage(Func<TInput, TOutput> transform, KeyValuePair<TInput, long> messageWithId)
		{
			TOutput item = default(TOutput);
			bool flag = false;
			try
			{
				item = transform(messageWithId.Key);
				flag = true;
			}
			catch (Exception exception)
			{
				if (!Common.IsCooperativeCancellation(exception))
				{
					throw;
				}
			}
			finally
			{
				if (!flag)
				{
					_target.ChangeBoundingCount(-1);
				}
				if (_reorderingBuffer == null)
				{
					if (flag)
					{
						if (_target.DataflowBlockOptions.MaxDegreeOfParallelism == 1)
						{
							_source.AddMessage(item);
						}
						else
						{
							lock (ParallelSourceLock)
							{
								_source.AddMessage(item);
							}
						}
					}
				}
				else
				{
					_reorderingBuffer.AddItem(messageWithId.Value, item, flag);
				}
			}
		}

		private void ProcessMessageWithTask(Func<TInput, Task<TOutput>> transform, KeyValuePair<TInput, long> messageWithId)
		{
			Task<TOutput> task = null;
			Exception ex = null;
			try
			{
				task = transform(messageWithId.Key);
			}
			catch (Exception ex2)
			{
				ex = ex2;
			}
			if (task == null)
			{
				if (ex != null && !Common.IsCooperativeCancellation(ex))
				{
					Common.StoreDataflowMessageValueIntoExceptionData(ex, messageWithId.Key);
					_target.Complete(ex, dropPendingMessages: true, storeExceptionEvenIfAlreadyCompleting: true);
				}
				if (_reorderingBuffer != null)
				{
					_reorderingBuffer.IgnoreItem(messageWithId.Value);
				}
				_target.SignalOneAsyncMessageCompleted(-1);
			}
			else
			{
				task.ContinueWith(delegate(Task<TOutput> completed, object state)
				{
					Tuple<TransformBlock<TInput, TOutput>, KeyValuePair<TInput, long>> tuple = (Tuple<TransformBlock<TInput, TOutput>, KeyValuePair<TInput, long>>)state;
					tuple.Item1.AsyncCompleteProcessMessageWithTask(completed, tuple.Item2);
				}, Tuple.Create(this, messageWithId), CancellationToken.None, Common.GetContinuationOptions(TaskContinuationOptions.ExecuteSynchronously), TaskScheduler.Default);
			}
		}

		private void AsyncCompleteProcessMessageWithTask(Task<TOutput> completed, KeyValuePair<TInput, long> messageWithId)
		{
			bool isBounded = _target.IsBounded;
			bool flag = false;
			TOutput item = default(TOutput);
			switch (completed.Status)
			{
			case TaskStatus.RanToCompletion:
				item = completed.Result;
				flag = true;
				break;
			case TaskStatus.Faulted:
			{
				AggregateException exception = completed.Exception;
				Common.StoreDataflowMessageValueIntoExceptionData(exception, messageWithId.Key, targetInnerExceptions: true);
				_target.Complete(exception, dropPendingMessages: true, storeExceptionEvenIfAlreadyCompleting: true, unwrapInnerExceptions: true);
				break;
			}
			}
			if (!flag && isBounded)
			{
				_target.ChangeBoundingCount(-1);
			}
			if (_reorderingBuffer == null)
			{
				if (flag)
				{
					if (_target.DataflowBlockOptions.MaxDegreeOfParallelism == 1)
					{
						_source.AddMessage(item);
					}
					else
					{
						lock (ParallelSourceLock)
						{
							_source.AddMessage(item);
						}
					}
				}
			}
			else
			{
				_reorderingBuffer.AddItem(messageWithId.Value, item, flag);
			}
			_target.SignalOneAsyncMessageCompleted();
		}

		public void Complete()
		{
			_target.Complete(null, dropPendingMessages: false);
		}

		void IDataflowBlock.Fault(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			_target.Complete(exception, dropPendingMessages: true);
		}

		public IDisposable LinkTo(ITargetBlock<TOutput> target, DataflowLinkOptions linkOptions)
		{
			return _source.LinkTo(target, linkOptions);
		}

		public bool TryReceive(Predicate<TOutput> filter, out TOutput item)
		{
			return _source.TryReceive(filter, out item);
		}

		public bool TryReceiveAll(out IList<TOutput> items)
		{
			return _source.TryReceiveAll(out items);
		}

		DataflowMessageStatus ITargetBlock<TInput>.OfferMessage(DataflowMessageHeader messageHeader, TInput messageValue, ISourceBlock<TInput> source, bool consumeToAccept)
		{
			return _target.OfferMessage(messageHeader, messageValue, source, consumeToAccept);
		}

		TOutput ISourceBlock<TOutput>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target, out bool messageConsumed)
		{
			return _source.ConsumeMessage(messageHeader, target, out messageConsumed);
		}

		bool ISourceBlock<TOutput>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target)
		{
			return _source.ReserveMessage(messageHeader, target);
		}

		void ISourceBlock<TOutput>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target)
		{
			_source.ReleaseReservation(messageHeader, target);
		}

		public override string ToString()
		{
			return Common.GetNameForDebugger(this, _source.DataflowBlockOptions);
		}
	}
	[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
	[DebuggerTypeProxy(typeof(TransformManyBlock<, >.DebugView))]
	public sealed class TransformManyBlock<TInput, TOutput> : IPropagatorBlock<TInput, TOutput>, ITargetBlock<TInput>, IDataflowBlock, ISourceBlock<TOutput>, IReceivableSourceBlock<TOutput>, IDebuggerDisplay
	{
		private sealed class DebugView
		{
			private readonly TransformManyBlock<TInput, TOutput> _transformManyBlock;

			private readonly TargetCore<TInput>.DebuggingInformation _targetDebuggingInformation;

			private readonly SourceCore<TOutput>.DebuggingInformation _sourceDebuggingInformation;

			public IEnumerable<TInput> InputQueue => _targetDebuggingInformation.InputQueue;

			public QueuedMap<ISourceBlock<TInput>, DataflowMessageHeader> PostponedMessages => _targetDebuggingInformation.PostponedMessages;

			public IEnumerable<TOutput> OutputQueue => _sourceDebuggingInformation.OutputQueue;

			public int CurrentDegreeOfParallelism => _targetDebuggingInformation.CurrentDegreeOfParallelism;

			public Task TaskForOutputProcessing => _sourceDebuggingInformation.TaskForOutputProcessing;

			public ExecutionDataflowBlockOptions DataflowBlockOptions => _targetDebuggingInformation.DataflowBlockOptions;

			public bool IsDecliningPermanently => _targetDebuggingInformation.IsDecliningPermanently;

			public bool IsCompleted => _sourceDebuggingInformation.IsCompleted;

			public int Id => Common.GetBlockId(_transformManyBlock);

			public TargetRegistry<TOutput> LinkedTargets => _sourceDebuggingInformation.LinkedTargets;

			public ITargetBlock<TOutput> NextMessageReservedFor => _sourceDebuggingInformation.NextMessageReservedFor;

			public DebugView(TransformManyBlock<TInput, TOutput> transformManyBlock)
			{
				_transformManyBlock = transformManyBlock;
				_targetDebuggingInformation = transformManyBlock._target.GetDebuggingInformation();
				_sourceDebuggingInformation = transformManyBlock._source.GetDebuggingInformation();
			}
		}

		private readonly TargetCore<TInput> _target;

		private readonly ReorderingBuffer<IEnumerable<TOutput>> _reorderingBuffer;

		private readonly SourceCore<TOutput> _source;

		private object ParallelSourceLock => _source;

		public Task Completion => _source.Completion;

		public int InputCount => _target.InputCount;

		public int OutputCount => _source.OutputCount;

		private int InputCountForDebugger => _target.GetDebuggingInformation().InputCount;

		private int OutputCountForDebugger => _source.GetDebuggingInformation().OutputCount;

		private object DebuggerDisplayContent => $"{Common.GetNameForDebugger(this, _source.DataflowBlockOptions)}, InputCount={InputCountForDebugger}, OutputCount={OutputCountForDebugger}";

		object IDebuggerDisplay.Content => DebuggerDisplayContent;

		public TransformManyBlock(Func<TInput, IEnumerable<TOutput>> transform)
			: this(transform, (Func<TInput, Task<IEnumerable<TOutput>>>)null, ExecutionDataflowBlockOptions.Default)
		{
		}

		public TransformManyBlock(Func<TInput, IEnumerable<TOutput>> transform, ExecutionDataflowBlockOptions dataflowBlockOptions)
			: this(transform, (Func<TInput, Task<IEnumerable<TOutput>>>)null, dataflowBlockOptions)
		{
		}

		public TransformManyBlock(Func<TInput, Task<IEnumerable<TOutput>>> transform)
			: this((Func<TInput, IEnumerable<TOutput>>)null, transform, ExecutionDataflowBlockOptions.Default)
		{
		}

		public TransformManyBlock(Func<TInput, Task<IEnumerable<TOutput>>> transform, ExecutionDataflowBlockOptions dataflowBlockOptions)
			: this((Func<TInput, IEnumerable<TOutput>>)null, transform, dataflowBlockOptions)
		{
		}

		private TransformManyBlock(Func<TInput, IEnumerable<TOutput>> transformSync, Func<TInput, Task<IEnumerable<TOutput>>> transformAsync, ExecutionDataflowBlockOptions dataflowBlockOptions)
		{
			TransformManyBlock<TInput, TOutput> transformManyBlock = this;
			if (transformSync == null && transformAsync == null)
			{
				throw new ArgumentNullException("transform");
			}
			if (dataflowBlockOptions == null)
			{
				throw new ArgumentNullException("dataflowBlockOptions");
			}
			dataflowBlockOptions = dataflowBlockOptions.DefaultOrClone();
			Action<ISourceBlock<TOutput>, int> itemsRemovedAction = null;
			if (dataflowBlockOptions.BoundedCapacity > 0)
			{
				itemsRemovedAction = delegate(ISourceBlock<TOutput> owningSource, int count)
				{
					((TransformManyBlock<TInput, TOutput>)owningSource)._target.ChangeBoundingCount(-count);
				};
			}
			_source = new SourceCore<TOutput>(this, dataflowBlockOptions, delegate(ISourceBlock<TOutput> owningSource)
			{
				((TransformManyBlock<TInput, TOutput>)owningSource)._target.Complete(null, dropPendingMessages: true);
			}, itemsRemovedAction);
			if (dataflowBlockOptions.SupportsParallelExecution && dataflowBlockOptions.EnsureOrdered)
			{
				_reorderingBuffer = new ReorderingBuffer<IEnumerable<TOutput>>(this, delegate(object source, IEnumerable<TOutput> messages)
				{
					((TransformManyBlock<TInput, TOutput>)source)._source.AddMessages(messages);
				});
			}
			if (transformSync != null)
			{
				_target = new TargetCore<TInput>(this, delegate(KeyValuePair<TInput, long> messageWithId)
				{
					transformManyBlock.ProcessMessage(transformSync, messageWithId);
				}, _reorderingBuffer, dataflowBlockOptions, TargetCoreOptions.None);
			}
			else
			{
				_target = new TargetCore<TInput>(this, delegate(KeyValuePair<TInput, long> messageWithId)
				{
					transformManyBlock.ProcessMessageWithTask(transformAsync, messageWithId);
				}, _reorderingBuffer, dataflowBlockOptions, TargetCoreOptions.UsesAsyncCompletion);
			}
			_target.Completion.ContinueWith(delegate(Task completed, object state)
			{
				SourceCore<TOutput> sourceCore = (SourceCore<TOutput>)state;
				if (completed.IsFaulted)
				{
					sourceCore.AddAndUnwrapAggregateException(completed.Exception);
				}
				sourceCore.Complete();
			}, _source, CancellationToken.None, Common.GetContinuationOptions(), TaskScheduler.Default);
			_source.Completion.ContinueWith(delegate(Task completed, object state)
			{
				IDataflowBlock dataflowBlock = (TransformManyBlock<TInput, TOutput>)state;
				dataflowBlock.Fault(completed.Exception);
			}, this, CancellationToken.None, Common.GetContinuationOptions() | TaskContinuationOptions.OnlyOnFaulted, TaskScheduler.Default);
			Common.WireCancellationToComplete(dataflowBlockOptions.CancellationToken, Completion, delegate(object state)
			{
				((TargetCore<TInput>)state).Complete(null, dropPendingMessages: true);
			}, _target);
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.DataflowBlockCreated(this, dataflowBlockOptions);
			}
		}

		private void ProcessMessage(Func<TInput, IEnumerable<TOutput>> transformFunction, KeyValuePair<TInput, long> messageWithId)
		{
			bool flag = false;
			try
			{
				IEnumerable<TOutput> outputItems = transformFunction(messageWithId.Key);
				flag = true;
				StoreOutputItems(messageWithId, outputItems);
			}
			catch (Exception exception)
			{
				if (!Common.IsCooperativeCancellation(exception))
				{
					throw;
				}
			}
			finally
			{
				if (!flag)
				{
					StoreOutputItems(messageWithId, null);
				}
			}
		}

		private void ProcessMessageWithTask(Func<TInput, Task<IEnumerable<TOutput>>> function, KeyValuePair<TInput, long> messageWithId)
		{
			Task<IEnumerable<TOutput>> task = null;
			Exception ex = null;
			try
			{
				task = function(messageWithId.Key);
			}
			catch (Exception ex2)
			{
				ex = ex2;
			}
			if (task == null)
			{
				if (ex != null && !Common.IsCooperativeCancellation(ex))
				{
					Common.StoreDataflowMessageValueIntoExceptionData(ex, messageWithId.Key);
					_target.Complete(ex, dropPendingMessages: true, storeExceptionEvenIfAlreadyCompleting: true);
				}
				if (_reorderingBuffer != null)
				{
					StoreOutputItems(messageWithId, null);
					_target.SignalOneAsyncMessageCompleted();
				}
				else
				{
					_target.SignalOneAsyncMessageCompleted(-1);
				}
			}
			else
			{
				task.ContinueWith(delegate(Task<IEnumerable<TOutput>> completed, object state)
				{
					Tuple<TransformManyBlock<TInput, TOutput>, KeyValuePair<TInput, long>> tuple = (Tuple<TransformManyBlock<TInput, TOutput>, KeyValuePair<TInput, long>>)state;
					tuple.Item1.AsyncCompleteProcessMessageWithTask(completed, tuple.Item2);
				}, Tuple.Create(this, messageWithId), CancellationToken.None, Common.GetContinuationOptions(TaskContinuationOptions.ExecuteSynchronously), _source.DataflowBlockOptions.TaskScheduler);
			}
		}

		private void AsyncCompleteProcessMessageWithTask(Task<IEnumerable<TOutput>> completed, KeyValuePair<TInput, long> messageWithId)
		{
			switch (completed.Status)
			{
			case TaskStatus.RanToCompletion:
			{
				IEnumerable<TOutput> result = completed.Result;
				try
				{
					StoreOutputItems(messageWithId, result);
				}
				catch (Exception ex)
				{
					if (!Common.IsCooperativeCancellation(ex))
					{
						Common.StoreDataflowMessageValueIntoExceptionData(ex, messageWithId.Key);
						_target.Complete(ex, dropPendingMessages: true, storeExceptionEvenIfAlreadyCompleting: true);
					}
				}
				break;
			}
			case TaskStatus.Faulted:
			{
				AggregateException exception = completed.Exception;
				Common.StoreDataflowMessageValueIntoExceptionData(exception, messageWithId.Key, targetInnerExceptions: true);
				_target.Complete(exception, dropPendingMessages: true, storeExceptionEvenIfAlreadyCompleting: true, unwrapInnerExceptions: true);
				goto case TaskStatus.Canceled;
			}
			case TaskStatus.Canceled:
				StoreOutputItems(messageWithId, null);
				break;
			}
			_target.SignalOneAsyncMessageCompleted();
		}

		private void StoreOutputItems(KeyValuePair<TInput, long> messageWithId, IEnumerable<TOutput> outputItems)
		{
			if (_reorderingBuffer != null)
			{
				StoreOutputItemsReordered(messageWithId.Value, outputItems);
			}
			else if (outputItems != null)
			{
				if (outputItems is TOutput[] || outputItems is List<TOutput>)
				{
					StoreOutputItemsNonReorderedAtomic(outputItems);
				}
				else
				{
					StoreOutputItemsNonReorderedWithIteration(outputItems);
				}
			}
			else if (_target.IsBounded)
			{
				_target.ChangeBoundingCount(-1);
			}
		}

		private void StoreOutputItemsReordered(long id, IEnumerable<TOutput> item)
		{
			TargetCore<TInput> target = _target;
			bool isBounded = target.IsBounded;
			if (item == null)
			{
				_reorderingBuffer.AddItem(id, null, itemIsValid: false);
				if (isBounded)
				{
					target.ChangeBoundingCount(-1);
				}
				return;
			}
			IList<TOutput> list = item as TOutput[];
			if (list == null)
			{
				list = item as List<TOutput>;
			}
			if (list != null && isBounded)
			{
				UpdateBoundingCountWithOutputCount(list.Count);
			}
			bool? flag = _reorderingBuffer.AddItemIfNextAndTrusted(id, list, list != null);
			if (!flag.HasValue)
			{
				return;
			}
			bool value = flag.Value;
			List<TOutput> list2 = null;
			try
			{
				if (value)
				{
					StoreOutputItemsNonReorderedWithIteration(item);
					return;
				}
				if (list != null)
				{
					list2 = list.ToList();
					return;
				}
				int count = 0;
				try
				{
					list2 = item.ToList();
					count = list2.Count;
				}
				finally
				{
					if (isBounded)
					{
						UpdateBoundingCountWithOutputCount(count);
					}
				}
			}
			finally
			{
				_reorderingBuffer.AddItem(id, list2, list2 != null);
			}
		}

		private void StoreOutputItemsNonReorderedAtomic(IEnumerable<TOutput> outputItems)
		{
			if (_target.IsBounded)
			{
				UpdateBoundingCountWithOutputCount(((ICollection<TOutput>)outputItems).Count);
			}
			if (_target.DataflowBlockOptions.MaxDegreeOfParallelism == 1)
			{
				_source.AddMessages(outputItems);
				return;
			}
			lock (ParallelSourceLock)
			{
				_source.AddMessages(outputItems);
			}
		}

		private void StoreOutputItemsNonReorderedWithIteration(IEnumerable<TOutput> outputItems)
		{
			bool flag = _target.DataflowBlockOptions.MaxDegreeOfParallelism == 1 || _reorderingBuffer != null;
			if (_target.IsBounded)
			{
				bool flag2 = false;
				try
				{
					foreach (TOutput outputItem in outputItems)
					{
						if (flag2)
						{
							_target.ChangeBoundingCount(1);
						}
						else
						{
							flag2 = true;
						}
						if (flag)
						{
							_source.AddMessage(outputItem);
							continue;
						}
						lock (ParallelSourceLock)
						{
							_source.AddMessage(outputItem);
						}
					}
					return;
				}
				finally
				{
					if (!flag2)
					{
						_target.ChangeBoundingCount(-1);
					}
				}
			}
			if (flag)
			{
				foreach (TOutput outputItem2 in outputItems)
				{
					_source.AddMessage(outputItem2);
				}
				return;
			}
			foreach (TOutput outputItem3 in outputItems)
			{
				lock (ParallelSourceLock)
				{
					_source.AddMessage(outputItem3);
				}
			}
		}

		private void UpdateBoundingCountWithOutputCount(int count)
		{
			if (count > 1)
			{
				_target.ChangeBoundingCount(count - 1);
			}
			else if (count == 0)
			{
				_target.ChangeBoundingCount(-1);
			}
		}

		public void Complete()
		{
			_target.Complete(null, dropPendingMessages: false);
		}

		void IDataflowBlock.Fault(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			_target.Complete(exception, dropPendingMessages: true);
		}

		public IDisposable LinkTo(ITargetBlock<TOutput> target, DataflowLinkOptions linkOptions)
		{
			return _source.LinkTo(target, linkOptions);
		}

		public bool TryReceive(Predicate<TOutput> filter, out TOutput item)
		{
			return _source.TryReceive(filter, out item);
		}

		public bool TryReceiveAll(out IList<TOutput> items)
		{
			return _source.TryReceiveAll(out items);
		}

		DataflowMessageStatus ITargetBlock<TInput>.OfferMessage(DataflowMessageHeader messageHeader, TInput messageValue, ISourceBlock<TInput> source, bool consumeToAccept)
		{
			return _target.OfferMessage(messageHeader, messageValue, source, consumeToAccept);
		}

		TOutput ISourceBlock<TOutput>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target, out bool messageConsumed)
		{
			return _source.ConsumeMessage(messageHeader, target, out messageConsumed);
		}

		bool ISourceBlock<TOutput>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target)
		{
			return _source.ReserveMessage(messageHeader, target);
		}

		void ISourceBlock<TOutput>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target)
		{
			_source.ReleaseReservation(messageHeader, target);
		}

		public override string ToString()
		{
			return Common.GetNameForDebugger(this, _source.DataflowBlockOptions);
		}
	}
	[DebuggerTypeProxy(typeof(WriteOnceBlock<>.DebugView))]
	[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
	public sealed class WriteOnceBlock<T> : IPropagatorBlock<T, T>, ITargetBlock<T>, IDataflowBlock, ISourceBlock<T>, IReceivableSourceBlock<T>, IDebuggerDisplay
	{
		private sealed class DebugView
		{
			private readonly WriteOnceBlock<T> _writeOnceBlock;

			public bool IsCompleted => _writeOnceBlock.Completion.IsCompleted;

			public int Id => Common.GetBlockId(_writeOnceBlock);

			public bool HasValue => _writeOnceBlock.HasValue;

			public T Value => _writeOnceBlock.Value;

			public DataflowBlockOptions DataflowBlockOptions => _writeOnceBlock._dataflowBlockOptions;

			public TargetRegistry<T> LinkedTargets => _writeOnceBlock._targetRegistry;

			public DebugView(WriteOnceBlock<T> writeOnceBlock)
			{
				_writeOnceBlock = writeOnceBlock;
			}
		}

		private readonly TargetRegistry<T> _targetRegistry;

		private readonly Func<T, T> _cloningFunction;

		private readonly DataflowBlockOptions _dataflowBlockOptions;

		private TaskCompletionSource<VoidResult> _lazyCompletionTaskSource;

		private bool _decliningPermanently;

		private bool _completionReserved;

		private DataflowMessageHeader _header;

		private T _value;

		private object ValueLock => _targetRegistry;

		public Task Completion => CompletionTaskSource.Task;

		private TaskCompletionSource<VoidResult> CompletionTaskSource
		{
			get
			{
				if (_lazyCompletionTaskSource == null)
				{
					Interlocked.CompareExchange(ref _lazyCompletionTaskSource, new TaskCompletionSource<VoidResult>(), null);
				}
				return _lazyCompletionTaskSource;
			}
		}

		private bool HasValue => _header.IsValid;

		private T Value
		{
			get
			{
				if (!_header.IsValid)
				{
					return default(T);
				}
				return _value;
			}
		}

		private object DebuggerDisplayContent => $"{Common.GetNameForDebugger(this, _dataflowBlockOptions)}, HasValue={HasValue}, Value={Value}";

		object IDebuggerDisplay.Content => DebuggerDisplayContent;

		public WriteOnceBlock(Func<T, T> cloningFunction)
			: this(cloningFunction, DataflowBlockOptions.Default)
		{
		}

		public WriteOnceBlock(Func<T, T> cloningFunction, DataflowBlockOptions dataflowBlockOptions)
		{
			if (dataflowBlockOptions == null)
			{
				throw new ArgumentNullException("dataflowBlockOptions");
			}
			_cloningFunction = cloningFunction;
			_dataflowBlockOptions = dataflowBlockOptions.DefaultOrClone();
			_targetRegistry = new TargetRegistry<T>(this);
			if (dataflowBlockOptions.CancellationToken.CanBeCanceled)
			{
				_lazyCompletionTaskSource = new TaskCompletionSource<VoidResult>();
				if (dataflowBlockOptions.CancellationToken.IsCancellationRequested)
				{
					_completionReserved = (_decliningPermanently = true);
					_lazyCompletionTaskSource.SetCanceled();
				}
				else
				{
					Common.WireCancellationToComplete(dataflowBlockOptions.CancellationToken, _lazyCompletionTaskSource.Task, delegate(object state)
					{
						((WriteOnceBlock<T>)state).Complete();
					}, this);
				}
			}
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.DataflowBlockCreated(this, dataflowBlockOptions);
			}
		}

		private void CompleteBlockAsync(IList<Exception> exceptions)
		{
			if (exceptions == null)
			{
				Task task = new Task(delegate(object state)
				{
					((WriteOnceBlock<T>)state).OfferToTargetsAndCompleteBlock();
				}, this, Common.GetCreationOptionsForTask());
				DataflowEtwProvider log = DataflowEtwProvider.Log;
				if (log.IsEnabled())
				{
					log.TaskLaunchedForMessageHandling(this, task, DataflowEtwProvider.TaskLaunchedReason.OfferingOutputMessages, _header.IsValid ? 1 : 0);
				}
				Exception ex = Common.StartTaskSafe(task, _dataflowBlockOptions.TaskScheduler);
				if (ex != null)
				{
					CompleteCore(ex, storeExceptionEvenIfAlreadyCompleting: true);
				}
			}
			else
			{
				Task.Factory.StartNew(delegate(object state)
				{
					Tuple<WriteOnceBlock<T>, IList<Exception>> tuple = (Tuple<WriteOnceBlock<T>, IList<Exception>>)state;
					tuple.Item1.CompleteBlock(tuple.Item2);
				}, Tuple.Create(this, exceptions), CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
			}
		}

		private void OfferToTargetsAndCompleteBlock()
		{
			List<Exception> exceptions = OfferToTargets();
			CompleteBlock(exceptions);
		}

		private void CompleteBlock(IList<Exception> exceptions)
		{
			TargetRegistry<T>.LinkedTargetInfo firstTarget = _targetRegistry.ClearEntryPoints();
			if (exceptions != null && exceptions.Count > 0)
			{
				CompletionTaskSource.TrySetException(exceptions);
			}
			else if (_dataflowBlockOptions.CancellationToken.IsCancellationRequested)
			{
				CompletionTaskSource.TrySetCanceled();
			}
			else if (Interlocked.CompareExchange(ref _lazyCompletionTaskSource, Common.CompletedVoidResultTaskCompletionSource, null) != null)
			{
				_lazyCompletionTaskSource.TrySetResult(default(VoidResult));
			}
			_targetRegistry.PropagateCompletion(firstTarget);
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.DataflowBlockCompleted(this);
			}
		}

		void IDataflowBlock.Fault(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			CompleteCore(exception, storeExceptionEvenIfAlreadyCompleting: false);
		}

		public void Complete()
		{
			CompleteCore(null, storeExceptionEvenIfAlreadyCompleting: false);
		}

		private void CompleteCore(Exception exception, bool storeExceptionEvenIfAlreadyCompleting)
		{
			bool flag = false;
			lock (ValueLock)
			{
				if (_decliningPermanently && !storeExceptionEvenIfAlreadyCompleting)
				{
					return;
				}
				_decliningPermanently = true;
				if (!_completionReserved || storeExceptionEvenIfAlreadyCompleting)
				{
					flag = (_completionReserved = true);
				}
			}
			if (flag)
			{
				List<Exception> list = null;
				if (exception != null)
				{
					list = new List<Exception>();
					list.Add(exception);
				}
				CompleteBlockAsync(list);
			}
		}

		public bool TryReceive(Predicate<T> filter, out T item)
		{
			if (_header.IsValid && (filter == null || filter(_value)))
			{
				item = CloneItem(_value);
				return true;
			}
			item = default(T);
			return false;
		}

		bool IReceivableSourceBlock<T>.TryReceiveAll(out IList<T> items)
		{
			if (TryReceive(null, out var item))
			{
				items = new T[1] { item };
				return true;
			}
			items = null;
			return false;
		}

		public IDisposable LinkTo(ITargetBlock<T> target, DataflowLinkOptions linkOptions)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (linkOptions == null)
			{
				throw new ArgumentNullException("linkOptions");
			}
			bool hasValue;
			lock (ValueLock)
			{
				hasValue = HasValue;
				bool completionReserved = _completionReserved;
				if (!hasValue && !completionReserved)
				{
					_targetRegistry.Add(ref target, linkOptions);
					return Common.CreateUnlinker(ValueLock, _targetRegistry, target);
				}
			}
			if (hasValue)
			{
				bool consumeToAccept = _cloningFunction != null;
				target.OfferMessage(_header, _value, this, consumeToAccept);
			}
			if (linkOptions.PropagateCompletion)
			{
				Common.PropagateCompletionOnceCompleted(Completion, target);
			}
			return Disposables.Nop;
		}

		DataflowMessageStatus ITargetBlock<T>.OfferMessage(DataflowMessageHeader messageHeader, T messageValue, ISourceBlock<T> source, bool consumeToAccept)
		{
			if (!messageHeader.IsValid)
			{
				throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
			}
			if (source == null && consumeToAccept)
			{
				throw new ArgumentException(SR.Argument_CantConsumeFromANullSource, "consumeToAccept");
			}
			bool flag = false;
			lock (ValueLock)
			{
				if (_decliningPermanently)
				{
					return DataflowMessageStatus.DecliningPermanently;
				}
				if (consumeToAccept)
				{
					messageValue = source.ConsumeMessage(messageHeader, this, out var messageConsumed);
					if (!messageConsumed)
					{
						return DataflowMessageStatus.NotAvailable;
					}
				}
				_header = Common.SingleMessageHeader;
				_value = messageValue;
				_decliningPermanently = true;
				if (!_completionReserved)
				{
					flag = (_completionReserved = true);
				}
			}
			if (flag)
			{
				CompleteBlockAsync(null);
			}
			return DataflowMessageStatus.Accepted;
		}

		T ISourceBlock<T>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<T> target, out bool messageConsumed)
		{
			if (!messageHeader.IsValid)
			{
				throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
			}
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (_header.Id == messageHeader.Id)
			{
				messageConsumed = true;
				return CloneItem(_value);
			}
			messageConsumed = false;
			return default(T);
		}

		bool ISourceBlock<T>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<T> target)
		{
			if (!messageHeader.IsValid)
			{
				throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
			}
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			return _header.Id == messageHeader.Id;
		}

		void ISourceBlock<T>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<T> target)
		{
			if (!messageHeader.IsValid)
			{
				throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
			}
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (_header.Id != messageHeader.Id)
			{
				throw new InvalidOperationException(SR.InvalidOperation_MessageNotReservedByTarget);
			}
			bool consumeToAccept = _cloningFunction != null;
			target.OfferMessage(_header, _value, this, consumeToAccept);
		}

		private T CloneItem(T item)
		{
			if (_cloningFunction == null)
			{
				return item;
			}
			return _cloningFunction(item);
		}

		private List<Exception> OfferToTargets()
		{
			List<Exception> list = null;
			if (HasValue)
			{
				TargetRegistry<T>.LinkedTargetInfo linkedTargetInfo = _targetRegistry.FirstTargetNode;
				while (linkedTargetInfo != null)
				{
					TargetRegistry<T>.LinkedTargetInfo next = linkedTargetInfo.Next;
					ITargetBlock<T> target = linkedTargetInfo.Target;
					try
					{
						bool consumeToAccept = _cloningFunction != null;
						target.OfferMessage(_header, _value, this, consumeToAccept);
					}
					catch (Exception ex)
					{
						Common.StoreDataflowMessageValueIntoExceptionData(ex, _value);
						Common.AddException(ref list, ex);
					}
					linkedTargetInfo = next;
				}
			}
			return list;
		}

		public override string ToString()
		{
			return Common.GetNameForDebugger(this, _dataflowBlockOptions);
		}
	}
}
namespace System.Threading.Tasks.Dataflow.Internal
{
	[DebuggerTypeProxy(typeof(BatchedJoinBlockTarget<>.DebugView))]
	[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
	internal sealed class BatchedJoinBlockTarget<T> : ITargetBlock<T>, IDataflowBlock, IDebuggerDisplay
	{
		private sealed class DebugView
		{
			private readonly BatchedJoinBlockTarget<T> _batchedJoinBlockTarget;

			public IEnumerable<T> InputQueue => _batchedJoinBlockTarget._messages;

			public bool IsDecliningPermanently
			{
				get
				{
					if (!_batchedJoinBlockTarget._decliningPermanently)
					{
						return _batchedJoinBlockTarget._sharedResources._decliningPermanently;
					}
					return true;
				}
			}

			public DebugView(BatchedJoinBlockTarget<T> batchedJoinBlockTarget)
			{
				_batchedJoinBlockTarget = batchedJoinBlockTarget;
			}
		}

		private readonly BatchedJoinBlockTargetSharedResources _sharedResources;

		private bool _decliningPermanently;

		private IList<T> _messages = new List<T>();

		internal int Count => _messages.Count;

		Task IDataflowBlock.Completion
		{
			get
			{
				throw new NotSupportedException(SR.NotSupported_MemberNotNeeded);
			}
		}

		private object DebuggerDisplayContent => $"{Common.GetNameForDebugger(this)} InputCount={_messages.Count}";

		object IDebuggerDisplay.Content => DebuggerDisplayContent;

		internal BatchedJoinBlockTarget(BatchedJoinBlockTargetSharedResources sharedResources)
		{
			_sharedResources = sharedResources;
			sharedResources._remainingAliveTargets++;
		}

		internal IList<T> GetAndEmptyMessages()
		{
			IList<T> messages = _messages;
			_messages = new List<T>();
			return messages;
		}

		public DataflowMessageStatus OfferMessage(DataflowMessageHeader messageHeader, T messageValue, ISourceBlock<T> source, bool consumeToAccept)
		{
			if (!messageHeader.IsValid)
			{
				throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
			}
			if (source == null && consumeToAccept)
			{
				throw new ArgumentException(SR.Argument_CantConsumeFromANullSource, "consumeToAccept");
			}
			lock (_sharedResources._incomingLock)
			{
				if (_decliningPermanently || _sharedResources._decliningPermanently)
				{
					return DataflowMessageStatus.DecliningPermanently;
				}
				if (consumeToAccept)
				{
					messageValue = source.ConsumeMessage(messageHeader, this, out var messageConsumed);
					if (!messageConsumed)
					{
						return DataflowMessageStatus.NotAvailable;
					}
				}
				_messages.Add(messageValue);
				if (--_sharedResources._remainingItemsInBatch == 0)
				{
					_sharedResources._batchSizeReachedAction();
				}
				return DataflowMessageStatus.Accepted;
			}
		}

		public void Complete()
		{
			lock (_sharedResources._incomingLock)
			{
				if (!_decliningPermanently)
				{
					_decliningPermanently = true;
					if (--_sharedResources._remainingAliveTargets == 0)
					{
						_sharedResources._allTargetsDecliningPermanentlyAction();
					}
				}
			}
		}

		void IDataflowBlock.Fault(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			lock (_sharedResources._incomingLock)
			{
				if (!_decliningPermanently && !_sharedResources._decliningPermanently)
				{
					_sharedResources._exceptionAction(exception);
				}
			}
			_sharedResources._completionAction();
		}
	}
	internal sealed class BatchedJoinBlockTargetSharedResources
	{
		internal readonly object _incomingLock;

		internal readonly int _batchSize;

		internal readonly Action _batchSizeReachedAction;

		internal readonly Action _allTargetsDecliningPermanentlyAction;

		internal readonly Action<Exception> _exceptionAction;

		internal readonly Action _completionAction;

		internal int _remainingItemsInBatch;

		internal int _remainingAliveTargets;

		internal bool _decliningPermanently;

		internal long _batchesCreated;

		internal BatchedJoinBlockTargetSharedResources(int batchSize, GroupingDataflowBlockOptions dataflowBlockOptions, Action batchSizeReachedAction, Action allTargetsDecliningAction, Action<Exception> exceptionAction, Action completionAction)
		{
			BatchedJoinBlockTargetSharedResources batchedJoinBlockTargetSharedResources = this;
			_incomingLock = new object();
			_batchSize = batchSize;
			_remainingAliveTargets = 0;
			_remainingItemsInBatch = batchSize;
			_allTargetsDecliningPermanentlyAction = delegate
			{
				allTargetsDecliningAction();
				batchedJoinBlockTargetSharedResources._decliningPermanently = true;
			};
			_batchSizeReachedAction = delegate
			{
				batchSizeReachedAction();
				batchedJoinBlockTargetSharedResources._batchesCreated++;
				if (batchedJoinBlockTargetSharedResources._batchesCreated >= dataflowBlockOptions.ActualMaxNumberOfGroups)
				{
					batchedJoinBlockTargetSharedResources._allTargetsDecliningPermanentlyAction();
				}
				else
				{
					batchedJoinBlockTargetSharedResources._remainingItemsInBatch = batchedJoinBlockTargetSharedResources._batchSize;
				}
			};
			_exceptionAction = exceptionAction;
			_completionAction = completionAction;
		}
	}
	[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
	[DebuggerTypeProxy(typeof(JoinBlockTarget<>.DebugView))]
	internal sealed class JoinBlockTarget<T> : JoinBlockTargetBase, ITargetBlock<T>, IDataflowBlock, IDebuggerDisplay
	{
		private sealed class NonGreedyState
		{
			internal readonly QueuedMap<ISourceBlock<T>, DataflowMessageHeader> PostponedMessages = new QueuedMap<ISourceBlock<T>, DataflowMessageHeader>();

			internal KeyValuePair<ISourceBlock<T>, DataflowMessageHeader> ReservedMessage;

			internal KeyValuePair<bool, T> ConsumedMessage;
		}

		private sealed class DebugView
		{
			private readonly JoinBlockTarget<T> _joinBlockTarget;

			public IEnumerable<T> InputQueue => _joinBlockTarget._messages;

			public bool IsDecliningPermanently
			{
				get
				{
					if (!_joinBlockTarget._decliningPermanently)
					{
						return _joinBlockTarget._sharedResources._decliningPermanently;
					}
					return true;
				}
			}

			public DebugView(JoinBlockTarget<T> joinBlockTarget)
			{
				_joinBlockTarget = joinBlockTarget;
			}
		}

		private readonly JoinBlockTargetSharedResources _sharedResources;

		private readonly TaskCompletionSource<VoidResult> _completionTask = new TaskCompletionSource<VoidResult>();

		private readonly Queue<T> _messages;

		private readonly NonGreedyState _nonGreedy;

		private bool _decliningPermanently;

		internal override bool IsDecliningPermanently => _decliningPermanently;

		internal override bool HasAtLeastOneMessageAvailable
		{
			get
			{
				if (_sharedResources._dataflowBlockOptions.Greedy)
				{
					return _messages.Count > 0;
				}
				return _nonGreedy.ConsumedMessage.Key;
			}
		}

		internal override bool HasAtLeastOnePostponedMessage
		{
			get
			{
				if (_nonGreedy != null)
				{
					return _nonGreedy.PostponedMessages.Count > 0;
				}
				return false;
			}
		}

		internal override int NumberOfMessagesAvailableOrPostponed
		{
			get
			{
				if (_sharedResources._dataflowBlockOptions.Greedy)
				{
					return _messages.Count;
				}
				return _nonGreedy.PostponedMessages.Count;
			}
		}

		internal override bool HasTheHighestNumberOfMessagesAvailable
		{
			get
			{
				int count = _messages.Count;
				JoinBlockTargetBase[] targets = _sharedResources._targets;
				foreach (JoinBlockTargetBase joinBlockTargetBase in targets)
				{
					if (joinBlockTargetBase != this && joinBlockTargetBase.NumberOfMessagesAvailableOrPostponed > count)
					{
						return false;
					}
				}
				return true;
			}
		}

		public Task Completion
		{
			get
			{
				throw new NotSupportedException(SR.NotSupported_MemberNotNeeded);
			}
		}

		internal Task CompletionTaskInternal => _completionTask.Task;

		private int InputCountForDebugger
		{
			get
			{
				if (_messages == null)
				{
					if (!_nonGreedy.ConsumedMessage.Key)
					{
						return 0;
					}
					return 1;
				}
				return _messages.Count;
			}
		}

		private object DebuggerDisplayContent
		{
			get
			{
				IDebuggerDisplay debuggerDisplay = _sharedResources._ownerJoin as IDebuggerDisplay;
				return $"{Common.GetNameForDebugger(this)} InputCount={InputCountForDebugger}, Join=\"{((debuggerDisplay != null) ? debuggerDisplay.Content : _sharedResources._ownerJoin)}\"";
			}
		}

		object IDebuggerDisplay.Content => DebuggerDisplayContent;

		internal JoinBlockTarget(JoinBlockTargetSharedResources sharedResources)
		{
			GroupingDataflowBlockOptions dataflowBlockOptions = sharedResources._dataflowBlockOptions;
			_sharedResources = sharedResources;
			if (!dataflowBlockOptions.Greedy || dataflowBlockOptions.BoundedCapacity > 0)
			{
				_nonGreedy = new NonGreedyState();
			}
			if (dataflowBlockOptions.Greedy)
			{
				_messages = new Queue<T>();
			}
		}

		internal T GetOneMessage()
		{
			if (_sharedResources._dataflowBlockOptions.Greedy)
			{
				return _messages.Dequeue();
			}
			T value = _nonGreedy.ConsumedMessage.Value;
			_nonGreedy.ConsumedMessage = new KeyValuePair<bool, T>(key: false, default(T));
			return value;
		}

		internal override bool ReserveOneMessage()
		{
			KeyValuePair<ISourceBlock<T>, DataflowMessageHeader> item;
			lock (_sharedResources.IncomingLock)
			{
				if (!_nonGreedy.PostponedMessages.TryPop(out item))
				{
					return false;
				}
			}
			while (!item.Key.ReserveMessage(item.Value, this))
			{
				lock (_sharedResources.IncomingLock)
				{
					if (!_nonGreedy.PostponedMessages.TryPop(out item))
					{
						return false;
					}
				}
			}
			_nonGreedy.ReservedMessage = item;
			return true;
		}

		internal override bool ConsumeReservedMessage()
		{
			bool messageConsumed;
			T value = _nonGreedy.ReservedMessage.Key.ConsumeMessage(_nonGreedy.ReservedMessage.Value, this, out messageConsumed);
			_nonGreedy.ReservedMessage = default(KeyValuePair<ISourceBlock<T>, DataflowMessageHeader>);
			if (!messageConsumed)
			{
				_sharedResources._exceptionAction(new InvalidOperationException(SR.InvalidOperation_FailedToConsumeReservedMessage));
				CompleteOncePossible();
				return false;
			}
			lock (_sharedResources.IncomingLock)
			{
				_nonGreedy.ConsumedMessage = new KeyValuePair<bool, T>(key: true, value);
				CompleteIfLastJoinIsFeasible();
			}
			return true;
		}

		internal override bool ConsumeOnePostponedMessage()
		{
			bool hasTheHighestNumberOfMessagesAvailable;
			T item2;
			bool messageConsumed;
			do
			{
				KeyValuePair<ISourceBlock<T>, DataflowMessageHeader> item;
				lock (_sharedResources.IncomingLock)
				{
					hasTheHighestNumberOfMessagesAvailable = HasTheHighestNumberOfMessagesAvailable;
					bool flag = _sharedResources._boundingState.CountIsLessThanBound || !hasTheHighestNumberOfMessagesAvailable;
					if (_decliningPermanently || _sharedResources._decliningPermanently || !flag || !_nonGreedy.PostponedMessages.TryPop(out item))
					{
						return false;
					}
				}
				item2 = item.Key.ConsumeMessage(item.Value, this, out messageConsumed);
			}
			while (!messageConsumed);
			lock (_sharedResources.IncomingLock)
			{
				if (hasTheHighestNumberOfMessagesAvailable)
				{
					_sharedResources._boundingState.CurrentCount++;
				}
				_messages.Enqueue(item2);
				CompleteIfLastJoinIsFeasible();
				return true;
			}
		}

		private void CompleteIfLastJoinIsFeasible()
		{
			int num = (_sharedResources._dataflowBlockOptions.Greedy ? _messages.Count : (_nonGreedy.ConsumedMessage.Key ? 1 : 0));
			if (_sharedResources._joinsCreated + num < _sharedResources._dataflowBlockOptions.ActualMaxNumberOfGroups)
			{
				return;
			}
			_decliningPermanently = true;
			bool flag = true;
			JoinBlockTargetBase[] targets = _sharedResources._targets;
			foreach (JoinBlockTargetBase joinBlockTargetBase in targets)
			{
				if (!joinBlockTargetBase.IsDecliningPermanently)
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				_sharedResources._decliningPermanently = true;
			}
		}

		internal override void ReleaseReservedMessage()
		{
			if (_nonGreedy != null && _nonGreedy.ReservedMessage.Key != null)
			{
				try
				{
					_nonGreedy.ReservedMessage.Key.ReleaseReservation(_nonGreedy.ReservedMessage.Value, this);
				}
				finally
				{
					ClearReservation();
				}
			}
		}

		internal override void ClearReservation()
		{
			_nonGreedy.ReservedMessage = default(KeyValuePair<ISourceBlock<T>, DataflowMessageHeader>);
		}

		internal override void CompleteOncePossible()
		{
			lock (_sharedResources.IncomingLock)
			{
				_decliningPermanently = true;
				if (_messages != null)
				{
					_messages.Clear();
				}
			}
			List<Exception> exceptions = null;
			if (_nonGreedy != null)
			{
				Common.ReleaseAllPostponedMessages(this, _nonGreedy.PostponedMessages, ref exceptions);
			}
			if (exceptions != null)
			{
				foreach (Exception item in exceptions)
				{
					_sharedResources._exceptionAction(item);
				}
			}
			_completionTask.TrySetResult(default(VoidResult));
		}

		DataflowMessageStatus ITargetBlock<T>.OfferMessage(DataflowMessageHeader messageHeader, T messageValue, ISourceBlock<T> source, bool consumeToAccept)
		{
			if (!messageHeader.IsValid)
			{
				throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
			}
			if (source == null && consumeToAccept)
			{
				throw new ArgumentException(SR.Argument_CantConsumeFromANullSource, "consumeToAccept");
			}
			lock (_sharedResources.IncomingLock)
			{
				if (_decliningPermanently || _sharedResources._decliningPermanently)
				{
					_sharedResources.CompleteBlockIfPossible();
					return DataflowMessageStatus.DecliningPermanently;
				}
				if (_sharedResources._dataflowBlockOptions.Greedy && (_sharedResources._boundingState == null || ((_sharedResources._boundingState.CountIsLessThanBound || !HasTheHighestNumberOfMessagesAvailable) && _nonGreedy.PostponedMessages.Count == 0 && _sharedResources._taskForInputProcessing == null)))
				{
					if (consumeToAccept)
					{
						messageValue = source.ConsumeMessage(messageHeader, this, out var messageConsumed);
						if (!messageConsumed)
						{
							return DataflowMessageStatus.NotAvailable;
						}
					}
					if (_sharedResources._boundingState != null && HasTheHighestNumberOfMessagesAvailable)
					{
						_sharedResources._boundingState.CurrentCount++;
					}
					_messages.Enqueue(messageValue);
					CompleteIfLastJoinIsFeasible();
					if (_sharedResources.AllTargetsHaveAtLeastOneMessage)
					{
						_sharedResources._joinFilledAction();
						_sharedResources._joinsCreated++;
					}
					_sharedResources.CompleteBlockIfPossible();
					return DataflowMessageStatus.Accepted;
				}
				if (source != null)
				{
					_nonGreedy.PostponedMessages.Push(source, messageHeader);
					_sharedResources.ProcessAsyncIfNecessary();
					return DataflowMessageStatus.Postponed;
				}
				return DataflowMessageStatus.Declined;
			}
		}

		internal override void CompleteCore(Exception exception, bool dropPendingMessages, bool releaseReservedMessages)
		{
			bool greedy = _sharedResources._dataflowBlockOptions.Greedy;
			lock (_sharedResources.IncomingLock)
			{
				if (exception != null && ((!_decliningPermanently && !_sharedResources._decliningPermanently) || releaseReservedMessages))
				{
					_sharedResources._exceptionAction(exception);
				}
				if (dropPendingMessages && greedy)
				{
					_messages.Clear();
				}
			}
			if (releaseReservedMessages && !greedy)
			{
				JoinBlockTargetBase[] targets = _sharedResources._targets;
				foreach (JoinBlockTargetBase joinBlockTargetBase in targets)
				{
					try
					{
						joinBlockTargetBase.ReleaseReservedMessage();
					}
					catch (Exception obj)
					{
						_sharedResources._exceptionAction(obj);
					}
				}
			}
			lock (_sharedResources.IncomingLock)
			{
				_decliningPermanently = true;
				_sharedResources.CompleteBlockIfPossible();
			}
		}

		void IDataflowBlock.Fault(Exception exception)
		{
			if (exception == null)
			{
				throw new ArgumentNullException("exception");
			}
			CompleteCore(exception, dropPendingMessages: true, releaseReservedMessages: false);
		}
	}
	internal abstract class JoinBlockTargetBase
	{
		internal abstract bool IsDecliningPermanently { get; }

		internal abstract bool HasAtLeastOneMessageAvailable { get; }

		internal abstract bool HasAtLeastOnePostponedMessage { get; }

		internal abstract int NumberOfMessagesAvailableOrPostponed { get; }

		internal abstract bool HasTheHighestNumberOfMessagesAvailable { get; }

		internal abstract bool ReserveOneMessage();

		internal abstract bool ConsumeReservedMessage();

		internal abstract bool ConsumeOnePostponedMessage();

		internal abstract void ReleaseReservedMessage();

		internal abstract void ClearReservation();

		public void Complete()
		{
			CompleteCore(null, dropPendingMessages: false, releaseReservedMessages: false);
		}

		internal abstract void CompleteCore(Exception exception, bool dropPendingMessages, bool releaseReservedMessages);

		internal abstract void CompleteOncePossible();
	}
	[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
	internal sealed class JoinBlockTargetSharedResources
	{
		internal readonly IDataflowBlock _ownerJoin;

		internal readonly JoinBlockTargetBase[] _targets;

		internal readonly Action<Exception> _exceptionAction;

		internal readonly Action _joinFilledAction;

		internal readonly GroupingDataflowBlockOptions _dataflowBlockOptions;

		internal readonly BoundingState _boundingState;

		internal bool _decliningPermanently;

		internal Task _taskForInputProcessing;

		internal bool _hasExceptions;

		internal long _joinsCreated;

		private bool _completionReserved;

		internal object IncomingLock => _targets;

		internal bool AllTargetsHaveAtLeastOneMessage
		{
			get
			{
				JoinBlockTargetBase[] targets = _targets;
				foreach (JoinBlockTargetBase joinBlockTargetBase in targets)
				{
					if (!joinBlockTargetBase.HasAtLeastOneMessageAvailable)
					{
						return false;
					}
				}
				return true;
			}
		}

		private bool TargetsHaveAtLeastOneMessageQueuedOrPostponed
		{
			get
			{
				if (_boundingState == null)
				{
					JoinBlockTargetBase[] targets = _targets;
					foreach (JoinBlockTargetBase joinBlockTargetBase in targets)
					{
						if (!joinBlockTargetBase.HasAtLeastOneMessageAvailable && (_decliningPermanently || joinBlockTargetBase.IsDecliningPermanently || !joinBlockTargetBase.HasAtLeastOnePostponedMessage))
						{
							return false;
						}
					}
					return true;
				}
				bool countIsLessThanBound = _boundingState.CountIsLessThanBound;
				bool flag = true;
				bool flag2 = false;
				JoinBlockTargetBase[] targets2 = _targets;
				foreach (JoinBlockTargetBase joinBlockTargetBase2 in targets2)
				{
					bool flag3 = !_decliningPermanently && !joinBlockTargetBase2.IsDecliningPermanently && joinBlockTargetBase2.HasAtLeastOnePostponedMessage;
					if (_dataflowBlockOptions.Greedy && flag3 && (countIsLessThanBound || !joinBlockTargetBase2.HasTheHighestNumberOfMessagesAvailable))
					{
						return true;
					}
					bool hasAtLeastOneMessageAvailable = joinBlockTargetBase2.HasAtLeastOneMessageAvailable;
					flag = flag && (hasAtLeastOneMessageAvailable || flag3);
					if (hasAtLeastOneMessageAvailable)
					{
						flag2 = true;
					}
				}
				if (flag)
				{
					return flag2 || countIsLessThanBound;
				}
				return false;
			}
		}

		private bool CanceledOrFaulted
		{
			get
			{
				if (!_dataflowBlockOptions.CancellationToken.IsCancellationRequested)
				{
					return _hasExceptions;
				}
				return true;
			}
		}

		internal bool JoinNeedsProcessing
		{
			get
			{
				if (_taskForInputProcessing == null && !CanceledOrFaulted)
				{
					return TargetsHaveAtLeastOneMessageQueuedOrPostponed;
				}
				return false;
			}
		}

		private object DebuggerDisplayContent
		{
			get
			{
				IDebuggerDisplay debuggerDisplay = _ownerJoin as IDebuggerDisplay;
				return $"Block=\"{((debuggerDisplay != null) ? debuggerDisplay.Content : _ownerJoin)}\"";
			}
		}

		internal JoinBlockTargetSharedResources(IDataflowBlock ownerJoin, JoinBlockTargetBase[] targets, Action joinFilledAction, Action<Exception> exceptionAction, GroupingDataflowBlockOptions dataflowBlockOptions)
		{
			_ownerJoin = ownerJoin;
			_targets = targets;
			_joinFilledAction = joinFilledAction;
			_exceptionAction = exceptionAction;
			_dataflowBlockOptions = dataflowBlockOptions;
			if (dataflowBlockOptions.BoundedCapacity > 0)
			{
				_boundingState = new BoundingState(dataflowBlockOptions.BoundedCapacity);
			}
		}

		internal void CompleteEachTarget()
		{
			JoinBlockTargetBase[] targets = _targets;
			foreach (JoinBlockTargetBase joinBlockTargetBase in targets)
			{
				joinBlockTargetBase.CompleteCore(null, dropPendingMessages: true, releaseReservedMessages: false);
			}
		}

		private bool RetrievePostponedItemsNonGreedy()
		{
			lock (IncomingLock)
			{
				if (!TargetsHaveAtLeastOneMessageQueuedOrPostponed)
				{
					return false;
				}
			}
			bool flag = true;
			JoinBlockTargetBase[] targets = _targets;
			foreach (JoinBlockTargetBase joinBlockTargetBase in targets)
			{
				if (!joinBlockTargetBase.ReserveOneMessage())
				{
					flag = false;
					break;
				}
			}
			if (flag)
			{
				JoinBlockTargetBase[] targets2 = _targets;
				foreach (JoinBlockTargetBase joinBlockTargetBase2 in targets2)
				{
					if (!joinBlockTargetBase2.ConsumeReservedMessage())
					{
						flag = false;
						break;
					}
				}
			}
			if (!flag)
			{
				JoinBlockTargetBase[] targets3 = _targets;
				foreach (JoinBlockTargetBase joinBlockTargetBase3 in targets3)
				{
					joinBlockTargetBase3.ReleaseReservedMessage();
				}
			}
			return flag;
		}

		private bool RetrievePostponedItemsGreedyBounded()
		{
			bool flag = false;
			JoinBlockTargetBase[] targets = _targets;
			foreach (JoinBlockTargetBase joinBlockTargetBase in targets)
			{
				flag |= joinBlockTargetBase.ConsumeOnePostponedMessage();
			}
			return flag;
		}

		internal void ProcessAsyncIfNecessary(bool isReplacementReplica = false)
		{
			if (JoinNeedsProcessing)
			{
				ProcessAsyncIfNecessary_Slow(isReplacementReplica);
			}
		}

		private void ProcessAsyncIfNecessary_Slow(bool isReplacementReplica)
		{
			_taskForInputProcessing = new Task(delegate(object thisSharedResources)
			{
				((JoinBlockTargetSharedResources)thisSharedResources).ProcessMessagesLoopCore();
			}, this, Common.GetCreationOptionsForTask(isReplacementReplica));
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.TaskLaunchedForMessageHandling(_ownerJoin, _taskForInputProcessing, DataflowEtwProvider.TaskLaunchedReason.ProcessingInputMessages, _targets.Max((JoinBlockTargetBase t) => t.NumberOfMessagesAvailableOrPostponed));
			}
			Exception ex = Common.StartTaskSafe(_taskForInputProcessing, _dataflowBlockOptions.TaskScheduler);
			if (ex != null)
			{
				_exceptionAction(ex);
				_taskForInputProcessing = null;
				CompleteBlockIfPossible();
			}
		}

		internal void CompleteBlockIfPossible()
		{
			if (_completionReserved)
			{
				return;
			}
			bool flag = _decliningPermanently && !AllTargetsHaveAtLeastOneMessage;
			if (!flag)
			{
				JoinBlockTargetBase[] targets = _targets;
				foreach (JoinBlockTargetBase joinBlockTargetBase in targets)
				{
					if (joinBlockTargetBase.IsDecliningPermanently && !joinBlockTargetBase.HasAtLeastOneMessageAvailable)
					{
						flag = true;
						break;
					}
				}
			}
			if (_taskForInputProcessing != null || (!flag && !CanceledOrFaulted))
			{
				return;
			}
			_completionReserved = true;
			_decliningPermanently = true;
			Task.Factory.StartNew(delegate(object state)
			{
				JoinBlockTargetSharedResources joinBlockTargetSharedResources = (JoinBlockTargetSharedResources)state;
				JoinBlockTargetBase[] targets2 = joinBlockTargetSharedResources._targets;
				foreach (JoinBlockTargetBase joinBlockTargetBase2 in targets2)
				{
					joinBlockTargetBase2.CompleteOncePossible();
				}
			}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
		}

		private void ProcessMessagesLoopCore()
		{
			try
			{
				int num = 0;
				int actualMaxMessagesPerTask = _dataflowBlockOptions.ActualMaxMessagesPerTask;
				bool flag;
				do
				{
					flag = ((!_dataflowBlockOptions.Greedy) ? RetrievePostponedItemsNonGreedy() : RetrievePostponedItemsGreedyBounded());
					if (flag)
					{
						lock (IncomingLock)
						{
							if (AllTargetsHaveAtLeastOneMessage)
							{
								_joinFilledAction();
								_joinsCreated++;
								if (!_dataflowBlockOptions.Greedy && _boundingState != null)
								{
									_boundingState.CurrentCount++;
								}
							}
						}
					}
					num++;
				}
				while (flag && num < actualMaxMessagesPerTask);
			}
			catch (Exception exception)
			{
				_targets[0].CompleteCore(exception, dropPendingMessages: true, releaseReservedMessages: true);
			}
			finally
			{
				lock (IncomingLock)
				{
					_taskForInputProcessing = null;
					ProcessAsyncIfNecessary(isReplacementReplica: true);
					CompleteBlockIfPossible();
				}
			}
		}

		internal void OnItemsRemoved(int numItemsRemoved)
		{
			if (_boundingState != null)
			{
				lock (IncomingLock)
				{
					_boundingState.CurrentCount -= numItemsRemoved;
					ProcessAsyncIfNecessary();
					CompleteBlockIfPossible();
				}
			}
		}
	}
	internal sealed class Disposables
	{
		[DebuggerDisplay("Disposed = true")]
		private sealed class NopDisposable : IDisposable
		{
			void IDisposable.Dispose()
			{
			}
		}

		[DebuggerDisplay("Disposed = {Disposed}")]
		private sealed class Disposable<T1, T2> : IDisposable
		{
			private readonly T1 _arg1;

			private readonly T2 _arg2;

			private Action<T1, T2> _action;

			private bool Disposed => _action == null;

			internal Disposable(Action<T1, T2> action, T1 arg1, T2 arg2)
			{
				_action = action;
				_arg1 = arg1;
				_arg2 = arg2;
			}

			void IDisposable.Dispose()
			{
				Action<T1, T2> action = _action;
				if (action != null && Interlocked.CompareExchange(ref _action, null, action) == action)
				{
					action(_arg1, _arg2);
				}
			}
		}

		[DebuggerDisplay("Disposed = {Disposed}")]
		private sealed class Disposable<T1, T2, T3> : IDisposable
		{
			private readonly T1 _arg1;

			private readonly T2 _arg2;

			private readonly T3 _arg3;

			private Action<T1, T2, T3> _action;

			private bool Disposed => _action == null;

			internal Disposable(Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
			{
				_action = action;
				_arg1 = arg1;
				_arg2 = arg2;
				_arg3 = arg3;
			}

			void IDisposable.Dispose()
			{
				Action<T1, T2, T3> action = _action;
				if (action != null && Interlocked.CompareExchange(ref _action, null, action) == action)
				{
					action(_arg1, _arg2, _arg3);
				}
			}
		}

		internal static readonly IDisposable Nop = new NopDisposable();

		internal static IDisposable Create<T1, T2>(Action<T1, T2> action, T1 arg1, T2 arg2)
		{
			return new Disposable<T1, T2>(action, arg1, arg2);
		}

		internal static IDisposable Create<T1, T2, T3>(Action<T1, T2, T3> action, T1 arg1, T2 arg2, T3 arg3)
		{
			return new Disposable<T1, T2, T3>(action, arg1, arg2, arg3);
		}
	}
	internal static class Common
	{
		internal delegate bool KeepAlivePredicate<TStateIn, TStateOut>(TStateIn stateIn, out TStateOut stateOut);

		private static class CachedGenericDelegates<T>
		{
			internal static readonly Func<T> DefaultTResultFunc = () => default(T);

			internal static readonly Action<object, TargetRegistry<T>, ITargetBlock<T>> CreateUnlinkerShimAction = delegate(object syncObj, TargetRegistry<T> registry, ITargetBlock<T> target)
			{
				lock (syncObj)
				{
					registry.Remove(target);
				}
			};
		}

		internal static readonly DataflowMessageHeader SingleMessageHeader = new DataflowMessageHeader(1L);

		internal static readonly Task<bool> CompletedTaskWithTrueResult = CreateCachedBooleanTask(value: true);

		internal static readonly Task<bool> CompletedTaskWithFalseResult = CreateCachedBooleanTask(value: false);

		internal static readonly TaskCompletionSource<VoidResult> CompletedVoidResultTaskCompletionSource = CreateCachedTaskCompletionSource<VoidResult>();

		internal static readonly TimeSpan InfiniteTimeSpan = Timeout.InfiniteTimeSpan;

		internal static readonly Action<Exception> AsyncExceptionHandler = ThrowAsync;

		internal static bool TryKeepAliveUntil<TStateIn, TStateOut>(KeepAlivePredicate<TStateIn, TStateOut> predicate, TStateIn stateIn, out TStateOut stateOut)
		{
			for (int num = 16; num > 0; num--)
			{
				if (!Thread.Yield() && predicate(stateIn, out stateOut))
				{
					return true;
				}
			}
			stateOut = default(TStateOut);
			return false;
		}

		internal static T UnwrapWeakReference<T>(object state) where T : class
		{
			WeakReference<T> weakReference = state as WeakReference<T>;
			if (!weakReference.TryGetTarget(out var target))
			{
				return null;
			}
			return target;
		}

		internal static int GetBlockId(IDataflowBlock block)
		{
			return GetPotentiallyNotSupportedCompletionTask(block)?.Id ?? 0;
		}

		internal static string GetNameForDebugger(IDataflowBlock block, DataflowBlockOptions options = null)
		{
			if (block == null)
			{
				return string.Empty;
			}
			string name = block.GetType().Name;
			if (options == null)
			{
				return name;
			}
			int blockId = GetBlockId(block);
			try
			{
				return string.Format(options.NameFormat, name, blockId);
			}
			catch (Exception ex)
			{
				return ex.Message;
			}
		}

		internal static bool IsCooperativeCancellation(Exception exception)
		{
			return exception is OperationCanceledException;
		}

		internal static void WireCancellationToComplete(CancellationToken cancellationToken, Task completionTask, Action<object> completeAction, object completeState)
		{
			if (cancellationToken.IsCancellationRequested)
			{
				completeAction(completeState);
			}
			else if (cancellationToken.CanBeCanceled)
			{
				CancellationTokenRegistration cancellationTokenRegistration = cancellationToken.Register(completeAction, completeState);
				completionTask.ContinueWith(delegate(Task completed, object state)
				{
					((CancellationTokenRegistration)state).Dispose();
				}, cancellationTokenRegistration, cancellationToken, GetContinuationOptions(), TaskScheduler.Default);
			}
		}

		internal static Exception InitializeStackTrace(Exception exception)
		{
			try
			{
				throw exception;
			}
			catch
			{
				return exception;
			}
		}

		internal static void StoreDataflowMessageValueIntoExceptionData<T>(Exception exc, T messageValue, bool targetInnerExceptions = false)
		{
			string text = messageValue as string;
			if (text == null && messageValue != null)
			{
				try
				{
					text = messageValue.ToString();
				}
				catch
				{
				}
			}
			if (text == null)
			{
				return;
			}
			StoreStringIntoExceptionData(exc, "DataflowMessageValue", text);
			if (!targetInnerExceptions)
			{
				return;
			}
			if (exc is AggregateException ex)
			{
				{
					foreach (Exception innerException in ex.InnerExceptions)
					{
						StoreStringIntoExceptionData(innerException, "DataflowMessageValue", text);
					}
					return;
				}
			}
			if (exc.InnerException != null)
			{
				StoreStringIntoExceptionData(exc.InnerException, "DataflowMessageValue", text);
			}
		}

		private static void StoreStringIntoExceptionData(Exception exception, string key, string value)
		{
			try
			{
				IDictionary data = exception.Data;
				if (data != null && !data.IsFixedSize && !data.IsReadOnly && data[key] == null)
				{
					data[key] = value;
				}
			}
			catch
			{
			}
		}

		internal static void ThrowAsync(Exception error)
		{
			ExceptionDispatchInfo state = ExceptionDispatchInfo.Capture(error);
			ThreadPool.QueueUserWorkItem(delegate(object obj)
			{
				((ExceptionDispatchInfo)obj).Throw();
			}, state);
		}

		internal static void AddException(ref List<Exception> list, Exception exception, bool unwrapInnerExceptions = false)
		{
			if (list == null)
			{
				list = new List<Exception>();
			}
			if (unwrapInnerExceptions)
			{
				if (exception is AggregateException ex)
				{
					list.AddRange(ex.InnerExceptions);
				}
				else
				{
					list.Add(exception.InnerException);
				}
			}
			else
			{
				list.Add(exception);
			}
		}

		private static Task<bool> CreateCachedBooleanTask(bool value)
		{
			AsyncTaskMethodBuilder<bool> asyncTaskMethodBuilder = AsyncTaskMethodBuilder<bool>.Create();
			asyncTaskMethodBuilder.SetResult(value);
			return asyncTaskMethodBuilder.Task;
		}

		private static TaskCompletionSource<T> CreateCachedTaskCompletionSource<T>()
		{
			TaskCompletionSource<T> taskCompletionSource = new TaskCompletionSource<T>();
			taskCompletionSource.SetResult(default(T));
			return taskCompletionSource;
		}

		internal static Task<TResult> CreateTaskFromException<TResult>(Exception exception)
		{
			AsyncTaskMethodBuilder<TResult> asyncTaskMethodBuilder = AsyncTaskMethodBuilder<TResult>.Create();
			asyncTaskMethodBuilder.SetException(exception);
			return asyncTaskMethodBuilder.Task;
		}

		internal static Task<TResult> CreateTaskFromCancellation<TResult>(CancellationToken cancellationToken)
		{
			return new Task<TResult>(CachedGenericDelegates<TResult>.DefaultTResultFunc, cancellationToken);
		}

		internal static Task GetPotentiallyNotSupportedCompletionTask(IDataflowBlock block)
		{
			try
			{
				return block.Completion;
			}
			catch (NotImplementedException)
			{
			}
			catch (NotSupportedException)
			{
			}
			return null;
		}

		internal static IDisposable CreateUnlinker<TOutput>(object outgoingLock, TargetRegistry<TOutput> targetRegistry, ITargetBlock<TOutput> targetBlock)
		{
			return Disposables.Create(CachedGenericDelegates<TOutput>.CreateUnlinkerShimAction, outgoingLock, targetRegistry, targetBlock);
		}

		internal static bool IsValidTimeout(TimeSpan timeout)
		{
			long num = (long)timeout.TotalMilliseconds;
			if (num >= -1)
			{
				return num <= 2147483647;
			}
			return false;
		}

		internal static TaskContinuationOptions GetContinuationOptions(TaskContinuationOptions toInclude = TaskContinuationOptions.None)
		{
			return toInclude | TaskContinuationOptions.DenyChildAttach;
		}

		internal static TaskCreationOptions GetCreationOptionsForTask(bool isReplacementReplica = false)
		{
			TaskCreationOptions taskCreationOptions = TaskCreationOptions.DenyChildAttach;
			if (isReplacementReplica)
			{
				taskCreationOptions |= TaskCreationOptions.PreferFairness;
			}
			return taskCreationOptions;
		}

		internal static Exception StartTaskSafe(Task task, TaskScheduler scheduler)
		{
			if (scheduler == TaskScheduler.Default)
			{
				task.Start(scheduler);
				return null;
			}
			return StartTaskSafeCore(task, scheduler);
		}

		private static Exception StartTaskSafeCore(Task task, TaskScheduler scheduler)
		{
			Exception result = null;
			try
			{
				task.Start(scheduler);
			}
			catch (Exception ex)
			{
				AggregateException exception = task.Exception;
				result = ex;
			}
			return result;
		}

		internal static void ReleaseAllPostponedMessages<T>(ITargetBlock<T> target, QueuedMap<ISourceBlock<T>, DataflowMessageHeader> postponedMessages, ref List<Exception> exceptions)
		{
			int count = postponedMessages.Count;
			int num = 0;
			KeyValuePair<ISourceBlock<T>, DataflowMessageHeader> item;
			while (postponedMessages.TryPop(out item))
			{
				try
				{
					if (item.Key.ReserveMessage(item.Value, target))
					{
						item.Key.ReleaseReservation(item.Value, target);
					}
				}
				catch (Exception exception)
				{
					AddException(ref exceptions, exception);
				}
				num++;
			}
		}

		internal static void PropagateCompletion(Task sourceCompletionTask, IDataflowBlock target, Action<Exception> exceptionHandler)
		{
			AggregateException ex = (sourceCompletionTask.IsFaulted ? sourceCompletionTask.Exception : null);
			try
			{
				if (ex != null)
				{
					target.Fault(ex);
				}
				else
				{
					target.Complete();
				}
			}
			catch (Exception obj)
			{
				if (exceptionHandler != null)
				{
					exceptionHandler(obj);
					return;
				}
				throw;
			}
		}

		private static void PropagateCompletionAsContinuation(Task sourceCompletionTask, IDataflowBlock target)
		{
			sourceCompletionTask.ContinueWith(delegate(Task task, object state)
			{
				PropagateCompletion(task, (IDataflowBlock)state, AsyncExceptionHandler);
			}, target, CancellationToken.None, GetContinuationOptions(), TaskScheduler.Default);
		}

		internal static void PropagateCompletionOnceCompleted(Task sourceCompletionTask, IDataflowBlock target)
		{
			if (sourceCompletionTask.IsCompleted)
			{
				PropagateCompletion(sourceCompletionTask, target, null);
			}
			else
			{
				PropagateCompletionAsContinuation(sourceCompletionTask, target);
			}
		}
	}
	[DebuggerDisplay("BoundedCapacity={BoundedCapacity}}")]
	internal class BoundingState
	{
		internal readonly int BoundedCapacity;

		internal int CurrentCount;

		internal bool CountIsLessThanBound => CurrentCount < BoundedCapacity;

		internal BoundingState(int boundedCapacity)
		{
			BoundedCapacity = boundedCapacity;
		}
	}
	[DebuggerDisplay("BoundedCapacity={BoundedCapacity}, PostponedMessages={PostponedMessagesCountForDebugger}")]
	internal class BoundingStateWithPostponed<TInput>(int boundedCapacity) : BoundingState(boundedCapacity)
	{
		internal readonly QueuedMap<ISourceBlock<TInput>, DataflowMessageHeader> PostponedMessages = new QueuedMap<ISourceBlock<TInput>, DataflowMessageHeader>();

		internal int OutstandingTransfers;

		private int PostponedMessagesCountForDebugger => PostponedMessages.Count;
	}
	internal class BoundingStateWithPostponedAndTask<TInput> : BoundingStateWithPostponed<TInput>
	{
		internal Task TaskForInputProcessing;

		internal BoundingStateWithPostponedAndTask(int boundedCapacity)
			: base(boundedCapacity)
		{
		}
	}
	[StructLayout(LayoutKind.Sequential, Size = 1)]
	[DebuggerNonUserCode]
	internal struct VoidResult
	{
	}
	[EventSource(Name = "System.Threading.Tasks.Dataflow.DataflowEventSource", Guid = "16F53577-E41D-43D4-B47E-C17025BF4025", LocalizationResources = "FxResources.System.Threading.Tasks.Dataflow.SR")]
	internal sealed class DataflowEtwProvider : EventSource
	{
		internal enum TaskLaunchedReason
		{
			ProcessingInputMessages = 1,
			OfferingOutputMessages
		}

		internal enum BlockCompletionReason
		{
			RanToCompletion = 5,
			Faulted = 7,
			Canceled = 6
		}

		internal static readonly DataflowEtwProvider Log = new DataflowEtwProvider();

		private DataflowEtwProvider()
		{
		}

		[NonEvent]
		internal void DataflowBlockCreated(IDataflowBlock block, DataflowBlockOptions dataflowBlockOptions)
		{
			if (IsEnabled(EventLevel.Informational, EventKeywords.All))
			{
				DataflowBlockCreated(Common.GetNameForDebugger(block, dataflowBlockOptions), Common.GetBlockId(block));
			}
		}

		[Event(1, Level = EventLevel.Informational)]
		private void DataflowBlockCreated(string blockName, int blockId)
		{
			WriteEvent(1, blockName, blockId);
		}

		[NonEvent]
		internal void TaskLaunchedForMessageHandling(IDataflowBlock block, Task task, TaskLaunchedReason reason, int availableMessages)
		{
			if (IsEnabled(EventLevel.Informational, EventKeywords.All))
			{
				TaskLaunchedForMessageHandling(Common.GetBlockId(block), reason, availableMessages, task.Id);
			}
		}

		[Event(2, Level = EventLevel.Informational)]
		private void TaskLaunchedForMessageHandling(int blockId, TaskLaunchedReason reason, int availableMessages, int taskId)
		{
			WriteEvent(2, blockId, reason, availableMessages, taskId);
		}

		[NonEvent]
		internal void DataflowBlockCompleted(IDataflowBlock block)
		{
			if (!IsEnabled(EventLevel.Informational, EventKeywords.All))
			{
				return;
			}
			Task potentiallyNotSupportedCompletionTask = Common.GetPotentiallyNotSupportedCompletionTask(block);
			if (potentiallyNotSupportedCompletionTask == null || !potentiallyNotSupportedCompletionTask.IsCompleted)
			{
				return;
			}
			BlockCompletionReason status = (BlockCompletionReason)potentiallyNotSupportedCompletionTask.Status;
			string exceptionData = string.Empty;
			if (potentiallyNotSupportedCompletionTask.IsFaulted)
			{
				try
				{
					exceptionData = string.Join(Environment.NewLine, potentiallyNotSupportedCompletionTask.Exception.InnerExceptions.Select((Exception e) => e.ToString()));
				}
				catch
				{
				}
			}
			DataflowBlockCompleted(Common.GetBlockId(block), status, exceptionData);
		}

		[Event(3, Level = EventLevel.Informational)]
		private void DataflowBlockCompleted(int blockId, BlockCompletionReason reason, string exceptionData)
		{
			WriteEvent(3, blockId, reason, exceptionData);
		}

		[NonEvent]
		internal void DataflowBlockLinking<T>(ISourceBlock<T> source, ITargetBlock<T> target)
		{
			if (IsEnabled(EventLevel.Informational, EventKeywords.All))
			{
				DataflowBlockLinking(Common.GetBlockId(source), Common.GetBlockId(target));
			}
		}

		[Event(4, Level = EventLevel.Informational)]
		private void DataflowBlockLinking(int sourceId, int targetId)
		{
			WriteEvent(4, sourceId, targetId);
		}

		[NonEvent]
		internal void DataflowBlockUnlinking<T>(ISourceBlock<T> source, ITargetBlock<T> target)
		{
			if (IsEnabled(EventLevel.Informational, EventKeywords.All))
			{
				DataflowBlockUnlinking(Common.GetBlockId(source), Common.GetBlockId(target));
			}
		}

		[Event(5, Level = EventLevel.Informational)]
		private void DataflowBlockUnlinking(int sourceId, int targetId)
		{
			WriteEvent(5, sourceId, targetId);
		}
	}
	internal sealed class EnumerableDebugView<TKey, TValue>
	{
		private readonly IEnumerable<KeyValuePair<TKey, TValue>> _enumerable;

		[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
		public KeyValuePair<TKey, TValue>[] Items => _enumerable.ToArray();

		public EnumerableDebugView(IEnumerable<KeyValuePair<TKey, TValue>> enumerable)
		{
			_enumerable = enumerable;
		}
	}
	internal interface IDebuggerDisplay
	{
		object Content { get; }
	}
	[DebuggerDisplay("Count={Count}")]
	internal readonly struct ImmutableArray<T>
	{
		private static readonly ImmutableArray<T> s_empty = new ImmutableArray<T>(new T[0]);

		private readonly T[] _array;

		public static ImmutableArray<T> Empty => s_empty;

		public int Count => _array.Length;

		private ImmutableArray(T[] elements)
		{
			_array = elements;
		}

		public ImmutableArray<T> Add(T item)
		{
			T[] array = new T[_array.Length + 1];
			Array.Copy(_array, 0, array, 0, _array.Length);
			array[array.Length - 1] = item;
			return new ImmutableArray<T>(array);
		}

		public ImmutableArray<T> Remove(T item)
		{
			int num = Array.IndexOf(_array, item);
			if (num < 0)
			{
				return this;
			}
			if (_array.Length == 1)
			{
				return Empty;
			}
			T[] array = new T[_array.Length - 1];
			Array.Copy(_array, 0, array, 0, num);
			Array.Copy(_array, num + 1, array, num, _array.Length - num - 1);
			return new ImmutableArray<T>(array);
		}

		public bool Contains(T item)
		{
			return Array.IndexOf(_array, item) >= 0;
		}

		public IEnumerator<T> GetEnumerator()
		{
			return ((IEnumerable<T>)_array).GetEnumerator();
		}

		public T[] ToArray()
		{
			if (_array.Length != 0)
			{
				return (T[])_array.Clone();
			}
			return s_empty._array;
		}
	}
	[StructLayout(LayoutKind.Explicit, Size = 256)]
	internal struct PaddedInt64
	{
		[FieldOffset(128)]
		internal long Value;
	}
	[DebuggerDisplay("Count = {Count}")]
	[DebuggerTypeProxy(typeof(EnumerableDebugView<, >))]
	internal sealed class QueuedMap<TKey, TValue>
	{
		private sealed class ArrayBasedLinkedQueue<T>
		{
			private readonly List<KeyValuePair<int, T>> _storage;

			private int _headIndex = -1;

			private int _tailIndex = -1;

			private int _freeIndex = -1;

			internal bool IsEmpty => _headIndex == -1;

			internal ArrayBasedLinkedQueue()
			{
				_storage = new List<KeyValuePair<int, T>>();
			}

			internal ArrayBasedLinkedQueue(int capacity)
			{
				_storage = new List<KeyValuePair<int, T>>(capacity);
			}

			internal int Enqueue(T item)
			{
				int num;
				if (_freeIndex != -1)
				{
					num = _freeIndex;
					_freeIndex = _storage[_freeIndex].Key;
					_storage[num] = new KeyValuePair<int, T>(-1, item);
				}
				else
				{
					num = _storage.Count;
					_storage.Add(new KeyValuePair<int, T>(-1, item));
				}
				if (_headIndex == -1)
				{
					_headIndex = num;
				}
				else
				{
					_storage[_tailIndex] = new KeyValuePair<int, T>(num, _storage[_tailIndex].Value);
				}
				_tailIndex = num;
				return num;
			}

			internal bool TryDequeue(out T item)
			{
				if (_headIndex == -1)
				{
					item = default(T);
					return false;
				}
				item = _storage[_headIndex].Value;
				int key = _storage[_headIndex].Key;
				_storage[_headIndex] = new KeyValuePair<int, T>(_freeIndex, default(T));
				_freeIndex = _headIndex;
				_headIndex = key;
				if (_headIndex == -1)
				{
					_tailIndex = -1;
				}
				return true;
			}

			internal void Replace(int index, T item)
			{
				_storage[index] = new KeyValuePair<int, T>(_storage[index].Key, item);
			}
		}

		private readonly ArrayBasedLinkedQueue<KeyValuePair<TKey, TValue>> _queue;

		private readonly Dictionary<TKey, int> _mapKeyToIndex;

		internal int Count => _mapKeyToIndex.Count;

		internal QueuedMap()
		{
			_queue = new ArrayBasedLinkedQueue<KeyValuePair<TKey, TValue>>();
			_mapKeyToIndex = new Dictionary<TKey, int>();
		}

		internal QueuedMap(int capacity)
		{
			_queue = new ArrayBasedLinkedQueue<KeyValuePair<TKey, TValue>>(capacity);
			_mapKeyToIndex = new Dictionary<TKey, int>(capacity);
		}

		internal void Push(TKey key, TValue value)
		{
			if (!_queue.IsEmpty && _mapKeyToIndex.TryGetValue(key, out var value2))
			{
				_queue.Replace(value2, new KeyValuePair<TKey, TValue>(key, value));
				return;
			}
			value2 = _queue.Enqueue(new KeyValuePair<TKey, TValue>(key, value));
			_mapKeyToIndex.Add(key, value2);
		}

		internal bool TryPop(out KeyValuePair<TKey, TValue> item)
		{
			bool flag = _queue.TryDequeue(out item);
			if (flag)
			{
				_mapKeyToIndex.Remove(item.Key);
			}
			return flag;
		}

		internal int PopRange(KeyValuePair<TKey, TValue>[] items, int arrayOffset, int count)
		{
			int i = 0;
			int num = arrayOffset;
			for (; i < count; i++)
			{
				if (!TryPop(out var item))
				{
					break;
				}
				items[num] = item;
				num++;
			}
			return i;
		}
	}
	internal interface IReorderingBuffer
	{
		void IgnoreItem(long id);
	}
	[DebuggerDisplay("Count={CountForDebugging}")]
	[DebuggerTypeProxy(typeof(ReorderingBuffer<>.DebugView))]
	internal sealed class ReorderingBuffer<TOutput> : IReorderingBuffer
	{
		private sealed class DebugView
		{
			private readonly ReorderingBuffer<TOutput> _buffer;

			public Dictionary<long, KeyValuePair<bool, TOutput>> ItemsBuffered => _buffer._reorderingBuffer;

			public long NextIdRequired => _buffer._nextReorderedIdToOutput;

			public DebugView(ReorderingBuffer<TOutput> buffer)
			{
				_buffer = buffer;
			}
		}

		private readonly object _owningSource;

		private readonly Dictionary<long, KeyValuePair<bool, TOutput>> _reorderingBuffer = new Dictionary<long, KeyValuePair<bool, TOutput>>();

		private readonly Action<object, TOutput> _outputAction;

		private long _nextReorderedIdToOutput;

		private object ValueLock => _reorderingBuffer;

		private int CountForDebugging => _reorderingBuffer.Count;

		internal ReorderingBuffer(object owningSource, Action<object, TOutput> outputAction)
		{
			_owningSource = owningSource;
			_outputAction = outputAction;
		}

		internal void AddItem(long id, TOutput item, bool itemIsValid)
		{
			lock (ValueLock)
			{
				if (_nextReorderedIdToOutput == id)
				{
					OutputNextItem(item, itemIsValid);
				}
				else
				{
					_reorderingBuffer.Add(id, new KeyValuePair<bool, TOutput>(itemIsValid, item));
				}
			}
		}

		internal bool? AddItemIfNextAndTrusted(long id, TOutput item, bool isTrusted)
		{
			lock (ValueLock)
			{
				if (_nextReorderedIdToOutput == id)
				{
					if (isTrusted)
					{
						OutputNextItem(item, itemIsValid: true);
						return null;
					}
					return true;
				}
				return false;
			}
		}

		public void IgnoreItem(long id)
		{
			AddItem(id, default(TOutput), itemIsValid: false);
		}

		private void OutputNextItem(TOutput theNextItem, bool itemIsValid)
		{
			_nextReorderedIdToOutput++;
			if (itemIsValid)
			{
				_outputAction(_owningSource, theNextItem);
			}
			KeyValuePair<bool, TOutput> value;
			while (_reorderingBuffer.TryGetValue(_nextReorderedIdToOutput, out value))
			{
				_reorderingBuffer.Remove(_nextReorderedIdToOutput);
				_nextReorderedIdToOutput++;
				if (value.Key)
				{
					_outputAction(_owningSource, value.Value);
				}
			}
		}
	}
	[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
	internal sealed class SourceCore<TOutput>
	{
		internal sealed class DebuggingInformation
		{
			private SourceCore<TOutput> _source;

			internal int OutputCount => _source._messages.Count;

			internal IEnumerable<TOutput> OutputQueue => _source._messages.ToList();

			internal Task TaskForOutputProcessing => _source._taskForOutputProcessing;

			internal DataflowBlockOptions DataflowBlockOptions => _source._dataflowBlockOptions;

			internal bool IsCompleted => _source.Completion.IsCompleted;

			internal TargetRegistry<TOutput> LinkedTargets => _source._targetRegistry;

			internal ITargetBlock<TOutput> NextMessageReservedFor => _source._nextMessageReservedFor;

			internal DebuggingInformation(SourceCore<TOutput> source)
			{
				_source = source;
			}
		}

		private readonly TaskCompletionSource<VoidResult> _completionTask = new TaskCompletionSource<VoidResult>();

		private readonly TargetRegistry<TOutput> _targetRegistry;

		private readonly SingleProducerSingleConsumerQueue<TOutput> _messages = new SingleProducerSingleConsumerQueue<TOutput>();

		private readonly ISourceBlock<TOutput> _owningSource;

		private readonly DataflowBlockOptions _dataflowBlockOptions;

		private readonly Action<ISourceBlock<TOutput>> _completeAction;

		private readonly Action<ISourceBlock<TOutput>, int> _itemsRemovedAction;

		private readonly Func<ISourceBlock<TOutput>, TOutput, IList<TOutput>, int> _itemCountingFunc;

		private Task _taskForOutputProcessing;

		private PaddedInt64 _nextMessageId = new PaddedInt64
		{
			Value = 1L
		};

		private ITargetBlock<TOutput> _nextMessageReservedFor;

		private bool _decliningPermanently;

		private bool _enableOffering = true;

		private bool _completionReserved;

		private List<Exception> _exceptions;

		private object OutgoingLock => _completionTask;

		private object ValueLock => _targetRegistry;

		internal Task Completion => _completionTask.Task;

		internal int OutputCount
		{
			get
			{
				lock (OutgoingLock)
				{
					lock (ValueLock)
					{
						return _messages.Count;
					}
				}
			}
		}

		internal bool HasExceptions => Volatile.Read(ref _exceptions) != null;

		internal DataflowBlockOptions DataflowBlockOptions => _dataflowBlockOptions;

		private bool CanceledOrFaulted
		{
			get
			{
				if (!_dataflowBlockOptions.CancellationToken.IsCancellationRequested)
				{
					if (HasExceptions)
					{
						return _decliningPermanently;
					}
					return false;
				}
				return true;
			}
		}

		private object DebuggerDisplayContent
		{
			get
			{
				IDebuggerDisplay debuggerDisplay = _owningSource as IDebuggerDisplay;
				return $"Block=\"{((debuggerDisplay != null) ? debuggerDisplay.Content : _owningSource)}\"";
			}
		}

		internal SourceCore(ISourceBlock<TOutput> owningSource, DataflowBlockOptions dataflowBlockOptions, Action<ISourceBlock<TOutput>> completeAction, Action<ISourceBlock<TOutput>, int> itemsRemovedAction = null, Func<ISourceBlock<TOutput>, TOutput, IList<TOutput>, int> itemCountingFunc = null)
		{
			_owningSource = owningSource;
			_dataflowBlockOptions = dataflowBlockOptions;
			_itemsRemovedAction = itemsRemovedAction;
			_itemCountingFunc = itemCountingFunc;
			_completeAction = completeAction;
			_targetRegistry = new TargetRegistry<TOutput>(_owningSource);
		}

		internal IDisposable LinkTo(ITargetBlock<TOutput> target, DataflowLinkOptions linkOptions)
		{
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			if (linkOptions == null)
			{
				throw new ArgumentNullException("linkOptions");
			}
			if (_completionTask.Task.IsCompleted)
			{
				if (linkOptions.PropagateCompletion)
				{
					Common.PropagateCompletion(_completionTask.Task, target, null);
				}
				return Disposables.Nop;
			}
			lock (OutgoingLock)
			{
				if (!_completionReserved)
				{
					_targetRegistry.Add(ref target, linkOptions);
					OfferToTargets(target);
					return Common.CreateUnlinker(OutgoingLock, _targetRegistry, target);
				}
			}
			if (linkOptions.PropagateCompletion)
			{
				Common.PropagateCompletionOnceCompleted(_completionTask.Task, target);
			}
			return Disposables.Nop;
		}

		internal TOutput ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target, out bool messageConsumed)
		{
			if (!messageHeader.IsValid)
			{
				throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
			}
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			TOutput result = default(TOutput);
			lock (OutgoingLock)
			{
				if (_nextMessageReservedFor != target && _nextMessageReservedFor != null)
				{
					messageConsumed = false;
					return default(TOutput);
				}
				lock (ValueLock)
				{
					if (messageHeader.Id != _nextMessageId.Value || !_messages.TryDequeue(out result))
					{
						messageConsumed = false;
						return default(TOutput);
					}
					_nextMessageReservedFor = null;
					_targetRegistry.Remove(target, onlyIfReachedMaxMessages: true);
					_enableOffering = true;
					_nextMessageId.Value++;
					CompleteBlockIfPossible();
					OfferAsyncIfNecessary(isReplacementReplica: false, outgoingLockKnownAcquired: true);
				}
			}
			if (_itemsRemovedAction != null)
			{
				int arg = ((_itemCountingFunc == null) ? 1 : _itemCountingFunc(_owningSource, result, null));
				_itemsRemovedAction(_owningSource, arg);
			}
			messageConsumed = true;
			return result;
		}

		internal bool ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target)
		{
			if (!messageHeader.IsValid)
			{
				throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
			}
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			lock (OutgoingLock)
			{
				if (_nextMessageReservedFor == null)
				{
					lock (ValueLock)
					{
						if (messageHeader.Id == _nextMessageId.Value && !_messages.IsEmpty)
						{
							_nextMessageReservedFor = target;
							_enableOffering = false;
							return true;
						}
					}
				}
			}
			return false;
		}

		internal void ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<TOutput> target)
		{
			if (!messageHeader.IsValid)
			{
				throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
			}
			if (target == null)
			{
				throw new ArgumentNullException("target");
			}
			lock (OutgoingLock)
			{
				if (_nextMessageReservedFor != target)
				{
					throw new InvalidOperationException(SR.InvalidOperation_MessageNotReservedByTarget);
				}
				lock (ValueLock)
				{
					if (messageHeader.Id != _nextMessageId.Value || _messages.IsEmpty)
					{
						throw new InvalidOperationException(SR.InvalidOperation_MessageNotReservedByTarget);
					}
					_nextMessageReservedFor = null;
					_enableOffering = true;
					OfferAsyncIfNecessary(isReplacementReplica: false, outgoingLockKnownAcquired: true);
					CompleteBlockIfPossible();
				}
			}
		}

		internal bool TryReceive(Predicate<TOutput> filter, out TOutput item)
		{
			item = default(TOutput);
			bool flag = false;
			lock (OutgoingLock)
			{
				if (_nextMessageReservedFor == null)
				{
					lock (ValueLock)
					{
						if (_messages.TryDequeueIf(filter, out item))
						{
							_nextMessageId.Value++;
							_enableOffering = true;
							CompleteBlockIfPossible();
							OfferAsyncIfNecessary(isReplacementReplica: false, outgoingLockKnownAcquired: true);
							flag = true;
						}
					}
				}
			}
			if (flag && _itemsRemovedAction != null)
			{
				int arg = ((_itemCountingFunc == null) ? 1 : _itemCountingFunc(_owningSource, item, null));
				_itemsRemovedAction(_owningSource, arg);
			}
			return flag;
		}

		internal bool TryReceiveAll(out IList<TOutput> items)
		{
			items = null;
			int num = 0;
			lock (OutgoingLock)
			{
				if (_nextMessageReservedFor == null)
				{
					lock (ValueLock)
					{
						if (!_messages.IsEmpty)
						{
							List<TOutput> list = new List<TOutput>();
							TOutput result;
							while (_messages.TryDequeue(out result))
							{
								list.Add(result);
							}
							num = list.Count;
							items = list;
							_nextMessageId.Value++;
							_enableOffering = true;
							CompleteBlockIfPossible();
						}
					}
				}
			}
			if (num > 0)
			{
				if (_itemsRemovedAction != null)
				{
					int arg = ((_itemCountingFunc != null) ? _itemCountingFunc(_owningSource, default(TOutput), items) : num);
					_itemsRemovedAction(_owningSource, arg);
				}
				return true;
			}
			return false;
		}

		internal void AddMessage(TOutput item)
		{
			if (!_decliningPermanently)
			{
				_messages.Enqueue(item);
				Interlocked.MemoryBarrier();
				if (_taskForOutputProcessing == null)
				{
					OfferAsyncIfNecessaryWithValueLock();
				}
			}
		}

		internal void AddMessages(IEnumerable<TOutput> items)
		{
			if (_decliningPermanently)
			{
				return;
			}
			if (items is List<TOutput> list)
			{
				for (int i = 0; i < list.Count; i++)
				{
					_messages.Enqueue(list[i]);
				}
			}
			else if (items is TOutput[] array)
			{
				for (int j = 0; j < array.Length; j++)
				{
					_messages.Enqueue(array[j]);
				}
			}
			else
			{
				foreach (TOutput item in items)
				{
					_messages.Enqueue(item);
				}
			}
			Interlocked.MemoryBarrier();
			if (_taskForOutputProcessing == null)
			{
				OfferAsyncIfNecessaryWithValueLock();
			}
		}

		internal void AddException(Exception exception)
		{
			lock (ValueLock)
			{
				Common.AddException(ref _exceptions, exception);
			}
		}

		internal void AddExceptions(List<Exception> exceptions)
		{
			lock (ValueLock)
			{
				foreach (Exception exception in exceptions)
				{
					Common.AddException(ref _exceptions, exception);
				}
			}
		}

		internal void AddAndUnwrapAggregateException(AggregateException aggregateException)
		{
			lock (ValueLock)
			{
				Common.AddException(ref _exceptions, aggregateException, unwrapInnerExceptions: true);
			}
		}

		internal void Complete()
		{
			lock (ValueLock)
			{
				_decliningPermanently = true;
				Task.Factory.StartNew(delegate(object state)
				{
					SourceCore<TOutput> sourceCore = (SourceCore<TOutput>)state;
					lock (sourceCore.OutgoingLock)
					{
						lock (sourceCore.ValueLock)
						{
							sourceCore.CompleteBlockIfPossible();
						}
					}
				}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
			}
		}

		private bool OfferToTargets(ITargetBlock<TOutput> linkToTarget = null)
		{
			if (_nextMessageReservedFor != null)
			{
				return false;
			}
			DataflowMessageHeader header = default(DataflowMessageHeader);
			TOutput result = default(TOutput);
			bool flag = false;
			if (!Volatile.Read(ref _enableOffering))
			{
				if (linkToTarget == null)
				{
					return false;
				}
				flag = true;
			}
			if (_messages.TryPeek(out result))
			{
				header = new DataflowMessageHeader(_nextMessageId.Value);
			}
			bool messageWasAccepted = false;
			if (header.IsValid)
			{
				if (flag)
				{
					OfferMessageToTarget(header, result, linkToTarget, out messageWasAccepted);
				}
				else
				{
					TargetRegistry<TOutput>.LinkedTargetInfo linkedTargetInfo = _targetRegistry.FirstTargetNode;
					while (linkedTargetInfo != null)
					{
						TargetRegistry<TOutput>.LinkedTargetInfo next = linkedTargetInfo.Next;
						if (OfferMessageToTarget(header, result, linkedTargetInfo.Target, out messageWasAccepted))
						{
							break;
						}
						linkedTargetInfo = next;
					}
					if (!messageWasAccepted)
					{
						lock (ValueLock)
						{
							_enableOffering = false;
						}
					}
				}
			}
			if (messageWasAccepted)
			{
				lock (ValueLock)
				{
					if (_nextMessageId.Value == header.Id)
					{
						_messages.TryDequeue(out var _);
					}
					_nextMessageId.Value++;
					_enableOffering = true;
					if (linkToTarget != null)
					{
						CompleteBlockIfPossible();
						OfferAsyncIfNecessary(isReplacementReplica: false, outgoingLockKnownAcquired: true);
					}
				}
				if (_itemsRemovedAction != null)
				{
					int arg = ((_itemCountingFunc == null) ? 1 : _itemCountingFunc(_owningSource, result, null));
					_itemsRemovedAction(_owningSource, arg);
				}
			}
			return messageWasAccepted;
		}

		private bool OfferMessageToTarget(DataflowMessageHeader header, TOutput message, ITargetBlock<TOutput> target, out bool messageWasAccepted)
		{
			DataflowMessageStatus dataflowMessageStatus = target.OfferMessage(header, message, _owningSource, consumeToAccept: false);
			messageWasAccepted = false;
			switch (dataflowMessageStatus)
			{
			case DataflowMessageStatus.Accepted:
				_targetRegistry.Remove(target, onlyIfReachedMaxMessages: true);
				messageWasAccepted = true;
				return true;
			case DataflowMessageStatus.DecliningPermanently:
				_targetRegistry.Remove(target);
				break;
			default:
				if (_nextMessageReservedFor != null)
				{
					return true;
				}
				break;
			}
			return false;
		}

		private void OfferAsyncIfNecessaryWithValueLock()
		{
			lock (ValueLock)
			{
				OfferAsyncIfNecessary(isReplacementReplica: false, outgoingLockKnownAcquired: false);
			}
		}

		private void OfferAsyncIfNecessary(bool isReplacementReplica, bool outgoingLockKnownAcquired)
		{
			if (_taskForOutputProcessing == null && _enableOffering && !_messages.IsEmpty)
			{
				OfferAsyncIfNecessary_Slow(isReplacementReplica, outgoingLockKnownAcquired);
			}
		}

		private void OfferAsyncIfNecessary_Slow(bool isReplacementReplica, bool outgoingLockKnownAcquired)
		{
			bool flag = true;
			if (outgoingLockKnownAcquired || Monitor.IsEntered(OutgoingLock))
			{
				flag = _targetRegistry.FirstTargetNode != null;
			}
			if (!flag || CanceledOrFaulted)
			{
				return;
			}
			_taskForOutputProcessing = new Task(delegate(object thisSourceCore)
			{
				((SourceCore<TOutput>)thisSourceCore).OfferMessagesLoopCore();
			}, this, Common.GetCreationOptionsForTask(isReplacementReplica));
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.TaskLaunchedForMessageHandling(_owningSource, _taskForOutputProcessing, DataflowEtwProvider.TaskLaunchedReason.OfferingOutputMessages, _messages.Count);
			}
			Exception ex = Common.StartTaskSafe(_taskForOutputProcessing, _dataflowBlockOptions.TaskScheduler);
			if (ex != null)
			{
				AddException(ex);
				_taskForOutputProcessing = null;
				_decliningPermanently = true;
				Task.Factory.StartNew(delegate(object state)
				{
					SourceCore<TOutput> sourceCore = (SourceCore<TOutput>)state;
					lock (sourceCore.OutgoingLock)
					{
						lock (sourceCore.ValueLock)
						{
							sourceCore.CompleteBlockIfPossible();
						}
					}
				}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
			}
			if (ex != null)
			{
				AddException(ex);
			}
		}

		private void OfferMessagesLoopCore()
		{
			try
			{
				int actualMaxMessagesPerTask = _dataflowBlockOptions.ActualMaxMessagesPerTask;
				int num = ((_dataflowBlockOptions.MaxMessagesPerTask == -1) ? 10 : actualMaxMessagesPerTask);
				int num2 = 0;
				while (num2 < actualMaxMessagesPerTask && !CanceledOrFaulted)
				{
					lock (OutgoingLock)
					{
						int num3 = 0;
						while (num2 < actualMaxMessagesPerTask && num3 < num && !CanceledOrFaulted)
						{
							if (!OfferToTargets())
							{
								return;
							}
							num2++;
							num3++;
						}
					}
				}
			}
			catch (Exception exception)
			{
				AddException(exception);
				_completeAction(_owningSource);
			}
			finally
			{
				lock (OutgoingLock)
				{
					lock (ValueLock)
					{
						_taskForOutputProcessing = null;
						Interlocked.MemoryBarrier();
						OfferAsyncIfNecessary(isReplacementReplica: true, outgoingLockKnownAcquired: true);
						CompleteBlockIfPossible();
					}
				}
			}
		}

		private void CompleteBlockIfPossible()
		{
			if (!_completionReserved && _decliningPermanently && _taskForOutputProcessing == null && _nextMessageReservedFor == null)
			{
				CompleteBlockIfPossible_Slow();
			}
		}

		private void CompleteBlockIfPossible_Slow()
		{
			if (_messages.IsEmpty || CanceledOrFaulted)
			{
				_completionReserved = true;
				Task.Factory.StartNew(delegate(object state)
				{
					((SourceCore<TOutput>)state).CompleteBlockOncePossible();
				}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
			}
		}

		private void CompleteBlockOncePossible()
		{
			TargetRegistry<TOutput>.LinkedTargetInfo firstTarget;
			List<Exception> exceptions;
			lock (OutgoingLock)
			{
				firstTarget = _targetRegistry.ClearEntryPoints();
				lock (ValueLock)
				{
					_messages.Clear();
					exceptions = _exceptions;
					_exceptions = null;
				}
			}
			if (exceptions != null)
			{
				_completionTask.TrySetException(exceptions);
			}
			else if (_dataflowBlockOptions.CancellationToken.IsCancellationRequested)
			{
				_completionTask.TrySetCanceled();
			}
			else
			{
				_completionTask.TrySetResult(default(VoidResult));
			}
			_targetRegistry.PropagateCompletion(firstTarget);
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.DataflowBlockCompleted(_owningSource);
			}
		}

		internal DebuggingInformation GetDebuggingInformation()
		{
			return new DebuggingInformation(this);
		}
	}
	[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
	internal sealed class SpscTargetCore<TInput>
	{
		internal sealed class DebuggingInformation
		{
			private readonly SpscTargetCore<TInput> _target;

			internal IEnumerable<TInput> InputQueue => _target._messages.ToList();

			internal int CurrentDegreeOfParallelism
			{
				get
				{
					if (_target._activeConsumer == null || _target.Completion.IsCompleted)
					{
						return 0;
					}
					return 1;
				}
			}

			internal ExecutionDataflowBlockOptions DataflowBlockOptions => _target._dataflowBlockOptions;

			internal bool IsDecliningPermanently => _target._decliningPermanently;

			internal bool IsCompleted => _target.Completion.IsCompleted;

			internal DebuggingInformation(SpscTargetCore<TInput> target)
			{
				_target = target;
			}
		}

		private readonly ITargetBlock<TInput> _owningTarget;

		private readonly SingleProducerSingleConsumerQueue<TInput> _messages = new SingleProducerSingleConsumerQueue<TInput>();

		private readonly ExecutionDataflowBlockOptions _dataflowBlockOptions;

		private readonly Action<TInput> _action;

		private volatile List<Exception> _exceptions;

		private volatile bool _decliningPermanently;

		private volatile bool _completionReserved;

		private volatile Task _activeConsumer;

		private TaskCompletionSource<VoidResult> _completionTask;

		internal int InputCount => _messages.Count;

		internal Task Completion => CompletionSource.Task;

		private TaskCompletionSource<VoidResult> CompletionSource => LazyInitializer.EnsureInitialized(ref _completionTask, () => new TaskCompletionSource<VoidResult>());

		internal ExecutionDataflowBlockOptions DataflowBlockOptions => _dataflowBlockOptions;

		private object DebuggerDisplayContent
		{
			get
			{
				IDebuggerDisplay debuggerDisplay = _owningTarget as IDebuggerDisplay;
				return $"Block=\"{((debuggerDisplay != null) ? debuggerDisplay.Content : _owningTarget)}\"";
			}
		}

		internal SpscTargetCore(ITargetBlock<TInput> owningTarget, Action<TInput> action, ExecutionDataflowBlockOptions dataflowBlockOptions)
		{
			_owningTarget = owningTarget;
			_action = action;
			_dataflowBlockOptions = dataflowBlockOptions;
		}

		internal bool Post(TInput messageValue)
		{
			if (_decliningPermanently)
			{
				return false;
			}
			_messages.Enqueue(messageValue);
			Interlocked.MemoryBarrier();
			if (_activeConsumer == null)
			{
				ScheduleConsumerIfNecessary(isReplica: false);
			}
			return true;
		}

		internal DataflowMessageStatus OfferMessage(DataflowMessageHeader messageHeader, TInput messageValue, ISourceBlock<TInput> source, bool consumeToAccept)
		{
			if (consumeToAccept || !Post(messageValue))
			{
				return OfferMessage_Slow(messageHeader, messageValue, source, consumeToAccept);
			}
			return DataflowMessageStatus.Accepted;
		}

		private DataflowMessageStatus OfferMessage_Slow(DataflowMessageHeader messageHeader, TInput messageValue, ISourceBlock<TInput> source, bool consumeToAccept)
		{
			if (_decliningPermanently)
			{
				return DataflowMessageStatus.DecliningPermanently;
			}
			if (!messageHeader.IsValid)
			{
				throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
			}
			if (consumeToAccept)
			{
				if (source == null)
				{
					throw new ArgumentException(SR.Argument_CantConsumeFromANullSource, "consumeToAccept");
				}
				messageValue = source.ConsumeMessage(messageHeader, _owningTarget, out var messageConsumed);
				if (!messageConsumed)
				{
					return DataflowMessageStatus.NotAvailable;
				}
			}
			_messages.Enqueue(messageValue);
			Interlocked.MemoryBarrier();
			if (_activeConsumer == null)
			{
				ScheduleConsumerIfNecessary(isReplica: false);
			}
			return DataflowMessageStatus.Accepted;
		}

		private void ScheduleConsumerIfNecessary(bool isReplica)
		{
			if (_activeConsumer != null)
			{
				return;
			}
			Task task = new Task(delegate(object state)
			{
				((SpscTargetCore<TInput>)state).ProcessMessagesLoopCore();
			}, this, CancellationToken.None, Common.GetCreationOptionsForTask(isReplica));
			if (Interlocked.CompareExchange(ref _activeConsumer, task, null) == null)
			{
				DataflowEtwProvider log = DataflowEtwProvider.Log;
				if (log.IsEnabled())
				{
					log.TaskLaunchedForMessageHandling(_owningTarget, task, DataflowEtwProvider.TaskLaunchedReason.ProcessingInputMessages, _messages.Count);
				}
				task.Start(_dataflowBlockOptions.TaskScheduler);
			}
		}

		private void ProcessMessagesLoopCore()
		{
			int num = 0;
			int actualMaxMessagesPerTask = _dataflowBlockOptions.ActualMaxMessagesPerTask;
			bool flag = true;
			while (flag)
			{
				flag = false;
				TInput result = default(TInput);
				try
				{
					while (_exceptions == null && num < actualMaxMessagesPerTask && _messages.TryDequeue(out result))
					{
						num++;
						_action(result);
					}
				}
				catch (Exception ex)
				{
					if (!Common.IsCooperativeCancellation(ex))
					{
						_decliningPermanently = true;
						Common.StoreDataflowMessageValueIntoExceptionData(ex, result);
						StoreException(ex);
					}
				}
				finally
				{
					if (!_messages.IsEmpty && _exceptions == null && num < actualMaxMessagesPerTask)
					{
						flag = true;
					}
					else
					{
						bool decliningPermanently = _decliningPermanently;
						if ((decliningPermanently && _messages.IsEmpty) || _exceptions != null)
						{
							if (!_completionReserved)
							{
								_completionReserved = true;
								CompleteBlockOncePossible();
							}
						}
						else
						{
							Task task = Interlocked.Exchange(ref _activeConsumer, null);
							if (!_messages.IsEmpty || (!decliningPermanently && _decliningPermanently) || _exceptions != null)
							{
								ScheduleConsumerIfNecessary(isReplica: true);
							}
						}
					}
				}
			}
		}

		internal void Complete(Exception exception)
		{
			if (!_decliningPermanently)
			{
				if (exception != null)
				{
					StoreException(exception);
				}
				_decliningPermanently = true;
				ScheduleConsumerIfNecessary(isReplica: false);
			}
		}

		private void StoreException(Exception exception)
		{
			lock (LazyInitializer.EnsureInitialized(ref _exceptions, () => new List<Exception>()))
			{
				_exceptions.Add(exception);
			}
		}

		private void CompleteBlockOncePossible()
		{
			TInput result;
			while (_messages.TryDequeue(out result))
			{
			}
			if (_exceptions != null)
			{
				Exception[] exceptions;
				lock (_exceptions)
				{
					exceptions = _exceptions.ToArray();
				}
				bool flag = CompletionSource.TrySetException(exceptions);
			}
			else
			{
				bool flag = CompletionSource.TrySetResult(default(VoidResult));
			}
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.DataflowBlockCompleted(_owningTarget);
			}
		}

		internal DebuggingInformation GetDebuggingInformation()
		{
			return new DebuggingInformation(this);
		}
	}
	[Flags]
	internal enum TargetCoreOptions : byte
	{
		None = 0,
		UsesAsyncCompletion = 1,
		RepresentsBlockCompletion = 2
	}
	[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
	internal sealed class TargetCore<TInput>
	{
		internal sealed class DebuggingInformation
		{
			private readonly TargetCore<TInput> _target;

			internal int InputCount => _target._messages.Count;

			internal IEnumerable<TInput> InputQueue => _target._messages.Select((KeyValuePair<TInput, long> kvp) => kvp.Key).ToList();

			internal QueuedMap<ISourceBlock<TInput>, DataflowMessageHeader> PostponedMessages
			{
				get
				{
					if (_target._boundingState == null)
					{
						return null;
					}
					return _target._boundingState.PostponedMessages;
				}
			}

			internal int CurrentDegreeOfParallelism => _target._numberOfOutstandingOperations - _target._numberOfOutstandingServiceTasks;

			internal ExecutionDataflowBlockOptions DataflowBlockOptions => _target._dataflowBlockOptions;

			internal bool IsDecliningPermanently => _target._decliningPermanently;

			internal bool IsCompleted => _target.Completion.IsCompleted;

			internal DebuggingInformation(TargetCore<TInput> target)
			{
				_target = target;
			}
		}

		private static readonly Common.KeepAlivePredicate<TargetCore<TInput>, KeyValuePair<TInput, long>> _keepAlivePredicate = delegate(TargetCore<TInput> thisTargetCore, out KeyValuePair<TInput, long> messageWithId)
		{
			return thisTargetCore.TryGetNextAvailableOrPostponedMessage(out messageWithId);
		};

		private readonly TaskCompletionSource<VoidResult> _completionSource = new TaskCompletionSource<VoidResult>();

		private readonly ITargetBlock<TInput> _owningTarget;

		private readonly IProducerConsumerQueue<KeyValuePair<TInput, long>> _messages;

		private readonly ExecutionDataflowBlockOptions _dataflowBlockOptions;

		private readonly Action<KeyValuePair<TInput, long>> _callAction;

		private readonly TargetCoreOptions _targetCoreOptions;

		private readonly BoundingStateWithPostponed<TInput> _boundingState;

		private readonly IReorderingBuffer _reorderingBuffer;

		private List<Exception> _exceptions;

		private bool _decliningPermanently;

		private int _numberOfOutstandingOperations;

		private int _numberOfOutstandingServiceTasks;

		private PaddedInt64 _nextAvailableInputMessageId;

		private bool _completionReserved;

		private int _keepAliveBanCounter;

		private object IncomingLock => _messages;

		internal Task Completion => _completionSource.Task;

		internal int InputCount => _messages.GetCountSafe(IncomingLock);

		private bool UsesAsyncCompletion => (_targetCoreOptions & TargetCoreOptions.UsesAsyncCompletion) != 0;

		private bool HasRoomForMoreOperations => _numberOfOutstandingOperations - _numberOfOutstandingServiceTasks < _dataflowBlockOptions.ActualMaxDegreeOfParallelism;

		private bool HasRoomForMoreServiceTasks
		{
			get
			{
				if (!UsesAsyncCompletion)
				{
					return HasRoomForMoreOperations;
				}
				if (HasRoomForMoreOperations)
				{
					return _numberOfOutstandingServiceTasks < _dataflowBlockOptions.ActualMaxDegreeOfParallelism;
				}
				return false;
			}
		}

		private bool CanceledOrFaulted
		{
			get
			{
				if (!_dataflowBlockOptions.CancellationToken.IsCancellationRequested)
				{
					return Volatile.Read(ref _exceptions) != null;
				}
				return true;
			}
		}

		internal bool IsBounded => _boundingState != null;

		private object DebuggerDisplayContent
		{
			get
			{
				IDebuggerDisplay debuggerDisplay = _owningTarget as IDebuggerDisplay;
				return $"Block=\"{((debuggerDisplay != null) ? debuggerDisplay.Content : _owningTarget)}\"";
			}
		}

		internal ExecutionDataflowBlockOptions DataflowBlockOptions => _dataflowBlockOptions;

		internal TargetCore(ITargetBlock<TInput> owningTarget, Action<KeyValuePair<TInput, long>> callAction, IReorderingBuffer reorderingBuffer, ExecutionDataflowBlockOptions dataflowBlockOptions, TargetCoreOptions targetCoreOptions)
		{
			_owningTarget = owningTarget;
			_callAction = callAction;
			_reorderingBuffer = reorderingBuffer;
			_dataflowBlockOptions = dataflowBlockOptions;
			_targetCoreOptions = targetCoreOptions;
			IProducerConsumerQueue<KeyValuePair<TInput, long>> messages;
			if (dataflowBlockOptions.MaxDegreeOfParallelism != 1)
			{
				IProducerConsumerQueue<KeyValuePair<TInput, long>> producerConsumerQueue = new MultiProducerMultiConsumerQueue<KeyValuePair<TInput, long>>();
				messages = producerConsumerQueue;
			}
			else
			{
				IProducerConsumerQueue<KeyValuePair<TInput, long>> producerConsumerQueue = new SingleProducerSingleConsumerQueue<KeyValuePair<TInput, long>>();
				messages = producerConsumerQueue;
			}
			_messages = messages;
			if (_dataflowBlockOptions.BoundedCapacity != -1)
			{
				_boundingState = new BoundingStateWithPostponed<TInput>(_dataflowBlockOptions.BoundedCapacity);
			}
		}

		internal void Complete(Exception exception, bool dropPendingMessages, bool storeExceptionEvenIfAlreadyCompleting = false, bool unwrapInnerExceptions = false, bool revertProcessingState = false)
		{
			lock (IncomingLock)
			{
				if (exception != null && (!_decliningPermanently || storeExceptionEvenIfAlreadyCompleting))
				{
					Common.AddException(ref _exceptions, exception, unwrapInnerExceptions);
				}
				if (dropPendingMessages)
				{
					KeyValuePair<TInput, long> result;
					while (_messages.TryDequeue(out result))
					{
					}
				}
				if (revertProcessingState)
				{
					_numberOfOutstandingOperations--;
					if (UsesAsyncCompletion)
					{
						_numberOfOutstandingServiceTasks--;
					}
				}
				_decliningPermanently = true;
				CompleteBlockIfPossible();
			}
		}

		internal DataflowMessageStatus OfferMessage(DataflowMessageHeader messageHeader, TInput messageValue, ISourceBlock<TInput> source, bool consumeToAccept)
		{
			if (!messageHeader.IsValid)
			{
				throw new ArgumentException(SR.Argument_InvalidMessageHeader, "messageHeader");
			}
			if (source == null && consumeToAccept)
			{
				throw new ArgumentException(SR.Argument_CantConsumeFromANullSource, "consumeToAccept");
			}
			lock (IncomingLock)
			{
				if (_decliningPermanently)
				{
					CompleteBlockIfPossible();
					return DataflowMessageStatus.DecliningPermanently;
				}
				if (_boundingState == null || (_boundingState.OutstandingTransfers == 0 && _boundingState.CountIsLessThanBound && _boundingState.PostponedMessages.Count == 0))
				{
					if (consumeToAccept)
					{
						messageValue = source.ConsumeMessage(messageHeader, _owningTarget, out var messageConsumed);
						if (!messageConsumed)
						{
							return DataflowMessageStatus.NotAvailable;
						}
					}
					long value = _nextAvailableInputMessageId.Value++;
					if (_boundingState != null)
					{
						_boundingState.CurrentCount++;
					}
					_messages.Enqueue(new KeyValuePair<TInput, long>(messageValue, value));
					ProcessAsyncIfNecessary();
					return DataflowMessageStatus.Accepted;
				}
				if (source != null)
				{
					_boundingState.PostponedMessages.Push(source, messageHeader);
					ProcessAsyncIfNecessary();
					return DataflowMessageStatus.Postponed;
				}
				return DataflowMessageStatus.Declined;
			}
		}

		internal void SignalOneAsyncMessageCompleted()
		{
			SignalOneAsyncMessageCompleted(0);
		}

		internal void SignalOneAsyncMessageCompleted(int boundingCountChange)
		{
			lock (IncomingLock)
			{
				if (_numberOfOutstandingOperations > 0)
				{
					_numberOfOutstandingOperations--;
				}
				if (_boundingState != null && boundingCountChange != 0)
				{
					_boundingState.CurrentCount += boundingCountChange;
				}
				ProcessAsyncIfNecessary(repeat: true);
				CompleteBlockIfPossible();
			}
		}

		private void ProcessAsyncIfNecessary(bool repeat = false)
		{
			if (HasRoomForMoreServiceTasks)
			{
				ProcessAsyncIfNecessary_Slow(repeat);
			}
		}

		private void ProcessAsyncIfNecessary_Slow(bool repeat)
		{
			if ((_messages.IsEmpty && (_decliningPermanently || _boundingState == null || !_boundingState.CountIsLessThanBound || _boundingState.PostponedMessages.Count <= 0)) || CanceledOrFaulted)
			{
				return;
			}
			_numberOfOutstandingOperations++;
			if (UsesAsyncCompletion)
			{
				_numberOfOutstandingServiceTasks++;
			}
			Task task = new Task(delegate(object thisTargetCore)
			{
				((TargetCore<TInput>)thisTargetCore).ProcessMessagesLoopCore();
			}, this, Common.GetCreationOptionsForTask(repeat));
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.TaskLaunchedForMessageHandling(_owningTarget, task, DataflowEtwProvider.TaskLaunchedReason.ProcessingInputMessages, _messages.Count + ((_boundingState != null) ? _boundingState.PostponedMessages.Count : 0));
			}
			Exception ex = Common.StartTaskSafe(task, _dataflowBlockOptions.TaskScheduler);
			if (ex != null)
			{
				Task.Factory.StartNew(delegate(object exc)
				{
					Complete((Exception)exc, dropPendingMessages: true, storeExceptionEvenIfAlreadyCompleting: true, unwrapInnerExceptions: false, revertProcessingState: true);
				}, ex, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
			}
		}

		private void ProcessMessagesLoopCore()
		{
			KeyValuePair<TInput, long> messageWithId = default(KeyValuePair<TInput, long>);
			try
			{
				bool usesAsyncCompletion = UsesAsyncCompletion;
				bool flag = _boundingState != null && _boundingState.BoundedCapacity > 1;
				int num = 0;
				int num2 = 0;
				int actualMaxMessagesPerTask = _dataflowBlockOptions.ActualMaxMessagesPerTask;
				while (num < actualMaxMessagesPerTask && !CanceledOrFaulted)
				{
					if (flag && TryConsumePostponedMessage(forPostponementTransfer: true, out var result))
					{
						lock (IncomingLock)
						{
							_boundingState.OutstandingTransfers--;
							_messages.Enqueue(result);
							ProcessAsyncIfNecessary();
						}
					}
					if (usesAsyncCompletion)
					{
						if (!TryGetNextMessageForNewAsyncOperation(out messageWithId))
						{
							break;
						}
					}
					else if (!TryGetNextAvailableOrPostponedMessage(out messageWithId))
					{
						if (_dataflowBlockOptions.MaxDegreeOfParallelism != 1 || num2 > 1)
						{
							break;
						}
						if (_keepAliveBanCounter > 0)
						{
							_keepAliveBanCounter--;
							break;
						}
						num2 = 0;
						if (!Common.TryKeepAliveUntil(_keepAlivePredicate, this, out messageWithId))
						{
							_keepAliveBanCounter = 1000;
							break;
						}
					}
					num++;
					num2++;
					_callAction(messageWithId);
				}
			}
			catch (Exception ex)
			{
				Common.StoreDataflowMessageValueIntoExceptionData(ex, messageWithId.Key);
				Complete(ex, dropPendingMessages: true, storeExceptionEvenIfAlreadyCompleting: true);
			}
			finally
			{
				lock (IncomingLock)
				{
					_numberOfOutstandingOperations--;
					if (UsesAsyncCompletion)
					{
						_numberOfOutstandingServiceTasks--;
					}
					ProcessAsyncIfNecessary(repeat: true);
					CompleteBlockIfPossible();
				}
			}
		}

		private bool TryGetNextMessageForNewAsyncOperation(out KeyValuePair<TInput, long> messageWithId)
		{
			bool hasRoomForMoreOperations;
			lock (IncomingLock)
			{
				hasRoomForMoreOperations = HasRoomForMoreOperations;
				if (hasRoomForMoreOperations)
				{
					_numberOfOutstandingOperations++;
				}
			}
			messageWithId = default(KeyValuePair<TInput, long>);
			if (hasRoomForMoreOperations)
			{
				bool flag = false;
				try
				{
					flag = TryGetNextAvailableOrPostponedMessage(out messageWithId);
				}
				catch
				{
					SignalOneAsyncMessageCompleted();
					throw;
				}
				if (!flag)
				{
					SignalOneAsyncMessageCompleted();
				}
				return flag;
			}
			return false;
		}

		private bool TryGetNextAvailableOrPostponedMessage(out KeyValuePair<TInput, long> messageWithId)
		{
			if (_messages.TryDequeue(out messageWithId))
			{
				return true;
			}
			if (_boundingState != null && TryConsumePostponedMessage(forPostponementTransfer: false, out messageWithId))
			{
				return true;
			}
			messageWithId = default(KeyValuePair<TInput, long>);
			return false;
		}

		private bool TryConsumePostponedMessage(bool forPostponementTransfer, out KeyValuePair<TInput, long> result)
		{
			bool flag = false;
			long num = -1L;
			while (true)
			{
				KeyValuePair<ISourceBlock<TInput>, DataflowMessageHeader> item;
				lock (IncomingLock)
				{
					if (_decliningPermanently)
					{
						break;
					}
					if (!forPostponementTransfer && _messages.TryDequeue(out result))
					{
						return true;
					}
					if (!_boundingState.CountIsLessThanBound || !_boundingState.PostponedMessages.TryPop(out item))
					{
						if (flag)
						{
							flag = false;
							_boundingState.CurrentCount--;
						}
						break;
					}
					if (!flag)
					{
						flag = true;
						num = _nextAvailableInputMessageId.Value++;
						_boundingState.CurrentCount++;
						if (forPostponementTransfer)
						{
							_boundingState.OutstandingTransfers++;
						}
					}
					goto IL_00d1;
				}
				IL_00d1:
				bool messageConsumed;
				TInput key = item.Key.ConsumeMessage(item.Value, _owningTarget, out messageConsumed);
				if (messageConsumed)
				{
					result = new KeyValuePair<TInput, long>(key, num);
					return true;
				}
				if (forPostponementTransfer)
				{
					_boundingState.OutstandingTransfers--;
				}
			}
			if (_reorderingBuffer != null && num != -1)
			{
				_reorderingBuffer.IgnoreItem(num);
			}
			if (flag)
			{
				ChangeBoundingCount(-1);
			}
			result = default(KeyValuePair<TInput, long>);
			return false;
		}

		private void CompleteBlockIfPossible()
		{
			if ((_decliningPermanently && _messages.IsEmpty) || CanceledOrFaulted)
			{
				CompleteBlockIfPossible_Slow();
			}
		}

		private void CompleteBlockIfPossible_Slow()
		{
			if (_numberOfOutstandingOperations == 0 && !_completionReserved)
			{
				_completionReserved = true;
				_decliningPermanently = true;
				Task.Factory.StartNew(delegate(object state)
				{
					((TargetCore<TInput>)state).CompleteBlockOncePossible();
				}, this, CancellationToken.None, Common.GetCreationOptionsForTask(), TaskScheduler.Default);
			}
		}

		private void CompleteBlockOncePossible()
		{
			if (_boundingState != null)
			{
				Common.ReleaseAllPostponedMessages(_owningTarget, _boundingState.PostponedMessages, ref _exceptions);
			}
			IProducerConsumerQueue<KeyValuePair<TInput, long>> messages = _messages;
			KeyValuePair<TInput, long> result;
			while (messages.TryDequeue(out result))
			{
			}
			if (Volatile.Read(ref _exceptions) != null)
			{
				_completionSource.TrySetException(Volatile.Read(ref _exceptions));
			}
			else if (_dataflowBlockOptions.CancellationToken.IsCancellationRequested)
			{
				_completionSource.TrySetCanceled();
			}
			else
			{
				_completionSource.TrySetResult(default(VoidResult));
			}
			DataflowEtwProvider log;
			if ((_targetCoreOptions & TargetCoreOptions.RepresentsBlockCompletion) != TargetCoreOptions.None && (log = DataflowEtwProvider.Log).IsEnabled())
			{
				log.DataflowBlockCompleted(_owningTarget);
			}
		}

		internal void ChangeBoundingCount(int count)
		{
			if (_boundingState != null)
			{
				lock (IncomingLock)
				{
					_boundingState.CurrentCount += count;
					ProcessAsyncIfNecessary();
					CompleteBlockIfPossible();
				}
			}
		}

		internal DebuggingInformation GetDebuggingInformation()
		{
			return new DebuggingInformation(this);
		}
	}
	[DebuggerDisplay("Count={Count}")]
	[DebuggerTypeProxy(typeof(TargetRegistry<>.DebugView))]
	internal sealed class TargetRegistry<T>
	{
		internal sealed class LinkedTargetInfo
		{
			internal readonly ITargetBlock<T> Target;

			internal readonly bool PropagateCompletion;

			internal int RemainingMessages;

			internal LinkedTargetInfo Previous;

			internal LinkedTargetInfo Next;

			internal LinkedTargetInfo(ITargetBlock<T> target, DataflowLinkOptions linkOptions)
			{
				Target = target;
				PropagateCompletion = linkOptions.PropagateCompletion;
				RemainingMessages = linkOptions.MaxMessages;
			}
		}

		[DebuggerTypeProxy(typeof(TargetRegistry<>.NopLinkPropagator.DebugView))]
		[DebuggerDisplay("{DebuggerDisplayContent,nq}")]
		private sealed class NopLinkPropagator : IPropagatorBlock<T, T>, ITargetBlock<T>, IDataflowBlock, ISourceBlock<T>, IDebuggerDisplay
		{
			private sealed class DebugView
			{
				private readonly NopLinkPropagator _passthrough;

				public ITargetBlock<T> LinkedTarget => _passthrough._target;

				public DebugView(NopLinkPropagator passthrough)
				{
					_passthrough = passthrough;
				}
			}

			private readonly ISourceBlock<T> _owningSource;

			private readonly ITargetBlock<T> _target;

			Task IDataflowBlock.Completion => _owningSource.Completion;

			private object DebuggerDisplayContent
			{
				get
				{
					IDebuggerDisplay debuggerDisplay = _owningSource as IDebuggerDisplay;
					IDebuggerDisplay debuggerDisplay2 = _target as IDebuggerDisplay;
					return $"{Common.GetNameForDebugger(this)} Source=\"{((debuggerDisplay != null) ? debuggerDisplay.Content : _owningSource)}\", Target=\"{((debuggerDisplay2 != null) ? debuggerDisplay2.Content : _target)}\"";
				}
			}

			object IDebuggerDisplay.Content => DebuggerDisplayContent;

			internal NopLinkPropagator(ISourceBlock<T> owningSource, ITargetBlock<T> target)
			{
				_owningSource = owningSource;
				_target = target;
			}

			DataflowMessageStatus ITargetBlock<T>.OfferMessage(DataflowMessageHeader messageHeader, T messageValue, ISourceBlock<T> source, bool consumeToAccept)
			{
				return _target.OfferMessage(messageHeader, messageValue, this, consumeToAccept);
			}

			T ISourceBlock<T>.ConsumeMessage(DataflowMessageHeader messageHeader, ITargetBlock<T> target, out bool messageConsumed)
			{
				return _owningSource.ConsumeMessage(messageHeader, this, out messageConsumed);
			}

			bool ISourceBlock<T>.ReserveMessage(DataflowMessageHeader messageHeader, ITargetBlock<T> target)
			{
				return _owningSource.ReserveMessage(messageHeader, this);
			}

			void ISourceBlock<T>.ReleaseReservation(DataflowMessageHeader messageHeader, ITargetBlock<T> target)
			{
				_owningSource.ReleaseReservation(messageHeader, this);
			}

			void IDataflowBlock.Complete()
			{
				_target.Complete();
			}

			void IDataflowBlock.Fault(Exception exception)
			{
				_target.Fault(exception);
			}

			IDisposable ISourceBlock<T>.LinkTo(ITargetBlock<T> target, DataflowLinkOptions linkOptions)
			{
				throw new NotSupportedException(SR.NotSupported_MemberNotNeeded);
			}
		}

		private sealed class DebugView
		{
			private readonly TargetRegistry<T> _registry;

			[DebuggerBrowsable(DebuggerBrowsableState.RootHidden)]
			public ITargetBlock<T>[] Targets => _registry.TargetsForDebugger;

			public DebugView(TargetRegistry<T> registry)
			{
				_registry = registry;
			}
		}

		private readonly ISourceBlock<T> _owningSource;

		private readonly Dictionary<ITargetBlock<T>, LinkedTargetInfo> _targetInformation;

		private LinkedTargetInfo _firstTarget;

		private LinkedTargetInfo _lastTarget;

		private int _linksWithRemainingMessages;

		internal LinkedTargetInfo FirstTargetNode => _firstTarget;

		private int Count => _targetInformation.Count;

		private ITargetBlock<T>[] TargetsForDebugger
		{
			get
			{
				ITargetBlock<T>[] array = new ITargetBlock<T>[Count];
				int num = 0;
				for (LinkedTargetInfo linkedTargetInfo = _firstTarget; linkedTargetInfo != null; linkedTargetInfo = linkedTargetInfo.Next)
				{
					array[num++] = linkedTargetInfo.Target;
				}
				return array;
			}
		}

		internal TargetRegistry(ISourceBlock<T> owningSource)
		{
			_owningSource = owningSource;
			_targetInformation = new Dictionary<ITargetBlock<T>, LinkedTargetInfo>();
		}

		internal void Add(ref ITargetBlock<T> target, DataflowLinkOptions linkOptions)
		{
			if (_targetInformation.TryGetValue(target, out var _))
			{
				target = new NopLinkPropagator(_owningSource, target);
			}
			LinkedTargetInfo linkedTargetInfo = new LinkedTargetInfo(target, linkOptions);
			AddToList(linkedTargetInfo, linkOptions.Append);
			_targetInformation.Add(target, linkedTargetInfo);
			if (linkedTargetInfo.RemainingMessages > 0)
			{
				_linksWithRemainingMessages++;
			}
			DataflowEtwProvider log = DataflowEtwProvider.Log;
			if (log.IsEnabled())
			{
				log.DataflowBlockLinking(_owningSource, target);
			}
		}

		internal void Remove(ITargetBlock<T> target, bool onlyIfReachedMaxMessages = false)
		{
			if (!onlyIfReachedMaxMessages || _linksWithRemainingMessages != 0)
			{
				Remove_Slow(target, onlyIfReachedMaxMessages);
			}
		}

		private void Remove_Slow(ITargetBlock<T> target, bool onlyIfReachedMaxMessages)
		{
			if (!_targetInformation.TryGetValue(target, out var value))
			{
				return;
			}
			if (!onlyIfReachedMaxMessages || value.RemainingMessages == 1)
			{
				RemoveFromList(value);
				_targetInformation.Remove(target);
				if (value.RemainingMessages == 0)
				{
					_linksWithRemainingMessages--;
				}
				DataflowEtwProvider log = DataflowEtwProvider.Log;
				if (log.IsEnabled())
				{
					log.DataflowBlockUnlinking(_owningSource, target);
				}
			}
			else if (value.RemainingMessages > 0)
			{
				value.RemainingMessages--;
			}
		}

		internal LinkedTargetInfo ClearEntryPoints()
		{
			LinkedTargetInfo firstTarget = _firstTarget;
			_firstTarget = (_lastTarget = null);
			_targetInformation.Clear();
			_linksWithRemainingMessages = 0;
			return firstTarget;
		}

		internal void PropagateCompletion(LinkedTargetInfo firstTarget)
		{
			Task completion = _owningSource.Completion;
			for (LinkedTargetInfo linkedTargetInfo = firstTarget; linkedTargetInfo != null; linkedTargetInfo = linkedTargetInfo.Next)
			{
				if (linkedTargetInfo.PropagateCompletion)
				{
					Common.PropagateCompletion(completion, linkedTargetInfo.Target, Common.AsyncExceptionHandler);
				}
			}
		}

		internal void AddToList(LinkedTargetInfo node, bool append)
		{
			if (_firstTarget == null && _lastTarget == null)
			{
				_firstTarget = (_lastTarget = node);
			}
			else if (append)
			{
				node.Previous = _lastTarget;
				_lastTarget.Next = node;
				_lastTarget = node;
			}
			else
			{
				node.Next = _firstTarget;
				_firstTarget.Previous = node;
				_firstTarget = node;
			}
		}

		internal void RemoveFromList(LinkedTargetInfo node)
		{
			LinkedTargetInfo previous = node.Previous;
			LinkedTargetInfo next = node.Next;
			if (node.Previous != null)
			{
				node.Previous.Next = next;
				node.Previous = null;
			}
			if (node.Next != null)
			{
				node.Next.Previous = previous;
				node.Next = null;
			}
			if (_firstTarget == node)
			{
				_firstTarget = next;
			}
			if (_lastTarget == node)
			{
				_lastTarget = previous;
			}
		}
	}
}
