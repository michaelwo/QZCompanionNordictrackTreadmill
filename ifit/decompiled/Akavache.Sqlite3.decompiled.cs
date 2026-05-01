using System;
using System.CodeDom.Compiler;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Reactive;
using System.Reactive.Concurrency;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using System.Reactive.Threading.Tasks;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Akavache.Core;
using Akavache.Sqlite3.Internal;
using Android.Runtime;
using Microsoft.CodeAnalysis;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
using SQLitePCL;
using Splat;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyFileVersion("7.1.1.22514")]
[assembly: AssemblyInformationalVersion("7.1.1+f257b0f8b9")]
[assembly: InternalsVisibleTo("Akavache.Tests")]
[assembly: ResourceDesigner("Akavache.Sqlite3.Resource", IsApplication = false)]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany(".NET Foundation and Contributors")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("Copyright (c) .NET Foundation and Contributors")]
[assembly: AssemblyDescription("Akavache Sqlite3")]
[assembly: AssemblyProduct("Akavache.Sqlite3 (MonoAndroid90)")]
[assembly: AssemblyTitle("Akavache.Sqlite3")]
[assembly: AssemblyVersion("7.1.0.0")]
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
internal static class ThisAssembly
{
	internal const string AssemblyVersion = "7.1.0.0";

	internal const string AssemblyFileVersion = "7.1.1.22514";

	internal const string AssemblyInformationalVersion = "7.1.1+f257b0f8b9";

	internal const string AssemblyName = "Akavache.Sqlite3";

	internal const string AssemblyTitle = "Akavache.Sqlite3";

	internal const string AssemblyConfiguration = "Release";

	internal const string GitCommitId = "f257b0f8b93ff304a0dc9c9fe33dbad619138537";

	internal const bool IsPublicRelease = true;

	internal const bool IsPrerelease = false;

	internal static readonly DateTime GitCommitDate = new DateTime(637390339680000000L, DateTimeKind.Utc);

	internal const string RootNamespace = "Akavache.Sqlite3";
}
namespace Akavache.Sqlite3
{
	internal static class EnumerableEx
	{
		public static IEnumerable<T> Return<T>(T value)
		{
			yield return value;
		}
	}
	internal class BeginTransactionSqliteOperation : IPreparedSqliteOperation, IEnableLogger, IDisposable
	{
		private readonly sqlite3_stmt _beginOp;

		private IDisposable _inner;

		public SQLiteConnection Connection { get; protected set; }

		public BeginTransactionSqliteOperation(SQLiteConnection conn)
		{
			SQLite3.Result result = (SQLite3.Result)raw.sqlite3_prepare_v2(conn.Handle, "BEGIN TRANSACTION", out _beginOp);
			Connection = conn;
			if (result != SQLite3.Result.OK)
			{
				throw new SQLiteException(result, "Couldn't prepare statement");
			}
			_inner = _beginOp;
		}

		public Action PrepareToExecute()
		{
			return delegate
			{
				try
				{
					this.Checked(raw.sqlite3_step(_beginOp));
				}
				finally
				{
					this.Checked(raw.sqlite3_reset(_beginOp));
				}
			};
		}

		public void Dispose()
		{
			Interlocked.Exchange(ref _inner, Disposable.Empty).Dispose();
		}
	}
	internal class BulkInsertSqliteOperation : IPreparedSqliteOperation, IEnableLogger, IDisposable
	{
		private readonly sqlite3_stmt _insertOp;

		private IDisposable _inner;

		public SQLiteConnection Connection { get; protected set; }

		public BulkInsertSqliteOperation(SQLiteConnection conn)
		{
			SQLite3.Result result = (SQLite3.Result)raw.sqlite3_prepare_v2(conn.Handle, "INSERT OR REPLACE INTO CacheElement VALUES (?,?,?,?,?)", out _insertOp);
			Connection = conn;
			if (result != SQLite3.Result.OK)
			{
				throw new SQLiteException(result, "Couldn't prepare statement");
			}
			_inner = _insertOp;
		}

		public Action PrepareToExecute(IEnumerable<CacheElement>? toInsert)
		{
			IEnumerable<CacheElement> enumerable = toInsert?.ToList();
			IEnumerable<CacheElement> insertList = enumerable ?? Enumerable.Empty<CacheElement>();
			return delegate
			{
				foreach (CacheElement item in insertList)
				{
					try
					{
						this.Checked(raw.sqlite3_bind_text(_insertOp, 1, item.Key));
						if (string.IsNullOrWhiteSpace(item.TypeName))
						{
							this.Checked(raw.sqlite3_bind_null(_insertOp, 2));
						}
						else
						{
							this.Checked(raw.sqlite3_bind_text(_insertOp, 2, item.TypeName));
						}
						this.Checked(raw.sqlite3_bind_blob(_insertOp, 3, item.Value));
						this.Checked(raw.sqlite3_bind_int64(_insertOp, 4, item.Expiration.Ticks));
						this.Checked(raw.sqlite3_bind_int64(_insertOp, 5, item.CreatedAt.Ticks));
						this.Checked(raw.sqlite3_step(_insertOp));
					}
					finally
					{
						this.Checked(raw.sqlite3_reset(_insertOp));
					}
				}
			};
		}

		public void Dispose()
		{
			Interlocked.Exchange(ref _inner, Disposable.Empty).Dispose();
		}
	}
	internal class BulkInvalidateByTypeSqliteOperation : BulkInvalidateSqliteOperation
	{
		public BulkInvalidateByTypeSqliteOperation(SQLiteConnection conn)
			: base(conn, useTypeInsteadOfKey: true)
		{
		}
	}
	internal class BulkInvalidateSqliteOperation : IPreparedSqliteOperation, IEnableLogger, IDisposable
	{
		private readonly sqlite3_stmt[] _deleteOps;

		private IDisposable _inner;

		public SQLiteConnection Connection { get; protected set; }

		public BulkInvalidateSqliteOperation(SQLiteConnection conn, bool useTypeInsteadOfKey)
		{
			StringBuilder qs = new StringBuilder("?");
			Connection = conn;
			string column = (useTypeInsteadOfKey ? "TypeName" : "Key");
			_deleteOps = Enumerable.Range(1, 64).Select((Func<int, sqlite3_stmt>)delegate
			{
				sqlite3_stmt stmt;
				SQLite3.Result result = (SQLite3.Result)raw.sqlite3_prepare_v2(conn.Handle, $"DELETE FROM CacheElement WHERE {column} In ({qs})", out stmt);
				if (result != SQLite3.Result.OK)
				{
					throw new SQLiteException(result, "Couldn't prepare statement");
				}
				qs.Append(",?");
				return stmt;
			}).ToArray();
			IDisposable[] deleteOps = _deleteOps;
			_inner = new CompositeDisposable(deleteOps);
		}

		public Action PrepareToExecute(IEnumerable<string>? toDelete)
		{
			List<string> deleteList = (toDelete ?? Array.Empty<string>()).ToList();
			if (deleteList.Count == 0)
			{
				return delegate
				{
				};
			}
			sqlite3_stmt deleteOp = _deleteOps[deleteList.Count - 1];
			return delegate
			{
				try
				{
					for (int i = 0; i < deleteList.Count; i++)
					{
						this.Checked(raw.sqlite3_bind_text(deleteOp, i + 1, deleteList[i]));
					}
					this.Checked(raw.sqlite3_step(deleteOp));
				}
				finally
				{
					this.Checked(raw.sqlite3_reset(deleteOp));
				}
			};
		}

		public void Dispose()
		{
			Interlocked.Exchange(ref _inner, Disposable.Empty).Dispose();
		}
	}
	internal class BulkSelectByTypeSqliteOperation : BulkSelectSqliteOperation
	{
		public BulkSelectByTypeSqliteOperation(SQLiteConnection conn, IScheduler scheduler)
			: base(conn, useTypeInsteadOfKey: true, scheduler)
		{
		}
	}
	internal class BulkSelectSqliteOperation : IPreparedSqliteOperation, IEnableLogger, IDisposable
	{
		private readonly sqlite3_stmt[] _selectOps;

		private readonly IScheduler _scheduler;

		private IDisposable _inner;

		public SQLiteConnection Connection { get; protected set; }

		public BulkSelectSqliteOperation(SQLiteConnection conn, bool useTypeInsteadOfKey, IScheduler scheduler)
		{
			StringBuilder qs = new StringBuilder("?");
			string column = (useTypeInsteadOfKey ? "TypeName" : "Key");
			Connection = conn;
			_scheduler = scheduler;
			_selectOps = Enumerable.Range(1, 64).Select((Func<int, sqlite3_stmt>)delegate
			{
				sqlite3_stmt stmt;
				SQLite3.Result result = (SQLite3.Result)raw.sqlite3_prepare_v2(conn.Handle, $"SELECT Key,TypeName,Value,Expiration,CreatedAt FROM CacheElement WHERE {column} In ({qs})", out stmt);
				string text = raw.sqlite3_errmsg(conn.Handle).utf8_to_string();
				if (result != SQLite3.Result.OK)
				{
					throw new SQLiteException(result, "Couldn't prepare statement: " + text);
				}
				qs.Append(",?");
				return stmt;
			}).ToArray();
			IDisposable[] selectOps = _selectOps;
			_inner = new CompositeDisposable(selectOps);
		}

		public Func<IEnumerable<CacheElement>> PrepareToExecute(IEnumerable<string>? toSelect)
		{
			List<string> selectList = (toSelect ?? Array.Empty<string>()).ToList();
			if (selectList.Count == 0)
			{
				return () => new List<CacheElement>();
			}
			sqlite3_stmt selectOp = _selectOps[selectList.Count - 1];
			DateTimeOffset now = _scheduler.Now;
			return delegate
			{
				List<CacheElement> list = new List<CacheElement>();
				try
				{
					for (int i = 0; i < selectList.Count; i++)
					{
						this.Checked(raw.sqlite3_bind_text(selectOp, i + 1, selectList[i]));
					}
					while (this.Checked(raw.sqlite3_step(selectOp)) == SQLite3.Result.Row)
					{
						CacheElement cacheElement = new CacheElement
						{
							Key = raw.sqlite3_column_text(selectOp, 0).utf8_to_string(),
							TypeName = raw.sqlite3_column_text(selectOp, 1).utf8_to_string(),
							Value = raw.sqlite3_column_blob(selectOp, 2).ToArray(),
							Expiration = new DateTime(raw.sqlite3_column_int64(selectOp, 3)),
							CreatedAt = new DateTime(raw.sqlite3_column_int64(selectOp, 4))
						};
						if (now.UtcTicks <= cacheElement.Expiration.Ticks)
						{
							list.Add(cacheElement);
						}
					}
					return list;
				}
				finally
				{
					this.Checked(raw.sqlite3_reset(selectOp));
				}
			};
		}

		public void Dispose()
		{
			Interlocked.Exchange(ref _inner, Disposable.Empty).Dispose();
		}
	}
	internal class CommitTransactionSqliteOperation : IPreparedSqliteOperation, IEnableLogger, IDisposable
	{
		private readonly sqlite3_stmt _commitOp;

		private IDisposable _inner;

		public SQLiteConnection Connection { get; protected set; }

		public CommitTransactionSqliteOperation(SQLiteConnection conn)
		{
			SQLite3.Result result = (SQLite3.Result)raw.sqlite3_prepare_v2(conn.Handle, "COMMIT TRANSACTION", out _commitOp);
			Connection = conn;
			if (result != SQLite3.Result.OK)
			{
				throw new SQLiteException(result, "Couldn't prepare statement");
			}
			_inner = _commitOp;
		}

		public Action PrepareToExecute()
		{
			return delegate
			{
				try
				{
					this.Checked(raw.sqlite3_step(_commitOp));
				}
				finally
				{
					this.Checked(raw.sqlite3_reset(_commitOp));
				}
			};
		}

		public void Dispose()
		{
			Interlocked.Exchange(ref _inner, Disposable.Empty).Dispose();
		}
	}
	internal static class Constants
	{
		public const int OperationQueueChunkSize = 64;
	}
	internal class DeleteExpiredSqliteOperation : IPreparedSqliteOperation, IEnableLogger, IDisposable
	{
		private readonly sqlite3_stmt _deleteOp;

		private readonly IScheduler _scheduler;

		private IDisposable _inner;

		public SQLiteConnection Connection { get; protected set; }

		public DeleteExpiredSqliteOperation(SQLiteConnection conn, IScheduler scheduler)
		{
			SQLite3.Result result = (SQLite3.Result)raw.sqlite3_prepare_v2(conn.Handle, "DELETE FROM CacheElement WHERE Expiration < ?", out _deleteOp);
			Connection = conn;
			if (result != SQLite3.Result.OK)
			{
				throw new SQLiteException(result, "Couldn't prepare delete statement");
			}
			_scheduler = scheduler;
			_inner = _deleteOp;
		}

		public Action PrepareToExecute()
		{
			long now = _scheduler.Now.UtcTicks;
			return delegate
			{
				try
				{
					this.Checked(raw.sqlite3_bind_int64(_deleteOp, 1, now));
					this.Checked(raw.sqlite3_step(_deleteOp));
				}
				finally
				{
					this.Checked(raw.sqlite3_reset(_deleteOp));
				}
			};
		}

		public void Dispose()
		{
			Interlocked.Exchange(ref _inner, Disposable.Empty).Dispose();
		}
	}
	internal class GetKeysSqliteOperation : IPreparedSqliteOperation, IEnableLogger, IDisposable
	{
		private readonly sqlite3_stmt _selectOp;

		private readonly IScheduler _scheduler;

		private IDisposable _inner;

		public SQLiteConnection Connection { get; protected set; }

		public GetKeysSqliteOperation(SQLiteConnection conn, IScheduler scheduler)
		{
			SQLite3.Result result = (SQLite3.Result)raw.sqlite3_prepare_v2(conn.Handle, "SELECT Key FROM CacheElement WHERE Expiration >= ?", out _selectOp);
			Connection = conn;
			if (result != SQLite3.Result.OK)
			{
				throw new SQLiteException(result, "Couldn't prepare statement");
			}
			_inner = _selectOp;
			_scheduler = scheduler;
		}

		public Func<IEnumerable<string>> PrepareToExecute()
		{
			return delegate
			{
				List<string> list = new List<string>();
				try
				{
					this.Checked(raw.sqlite3_bind_int64(_selectOp, 1, _scheduler.Now.UtcTicks));
					while (this.Checked(raw.sqlite3_step(_selectOp)) == SQLite3.Result.Row)
					{
						list.Add(raw.sqlite3_column_text(_selectOp, 0).utf8_to_string());
					}
					return list;
				}
				finally
				{
					this.Checked(raw.sqlite3_reset(_selectOp));
				}
			};
		}

		public void Dispose()
		{
			Interlocked.Exchange(ref _inner, Disposable.Empty).Dispose();
		}
	}
	internal class InvalidateAllSqliteOperation : IPreparedSqliteOperation, IEnableLogger, IDisposable
	{
		private readonly SQLiteConnection _connection;

		public SQLiteConnection Connection { get; protected set; }

		public InvalidateAllSqliteOperation(SQLiteConnection connection)
		{
			_connection = connection;
			Connection = connection;
		}

		public Action PrepareToExecute()
		{
			return delegate
			{
				this.Checked(raw.sqlite3_exec(_connection.Handle, "DELETE FROM CacheElement"));
			};
		}

		public void Dispose()
		{
		}
	}
	internal interface IPreparedSqliteOperation : IEnableLogger, IDisposable
	{
		SQLiteConnection Connection { get; }
	}
	internal enum OperationType
	{
		DoNothing,
		BulkSelectSqliteOperation,
		BulkSelectByTypeSqliteOperation,
		BulkInsertSqliteOperation,
		BulkInvalidateSqliteOperation,
		BulkInvalidateByTypeSqliteOperation,
		InvalidateAllSqliteOperation,
		VacuumSqliteOperation,
		DeleteExpiredSqliteOperation,
		GetKeysSqliteOperation
	}
	internal static class SqliteOperationMixin
	{
		public static SQLite3.Result Checked(this IPreparedSqliteOperation connection, int sqlite3ErrorCode, string? message = null)
		{
			if (sqlite3ErrorCode == 0 || sqlite3ErrorCode == 101 || sqlite3ErrorCode == 100)
			{
				return (SQLite3.Result)sqlite3ErrorCode;
			}
			string text = raw.sqlite3_errmsg(connection.Connection.Handle).utf8_to_string();
			SQLiteException ex = new SQLiteException((SQLite3.Result)sqlite3ErrorCode, (message ?? string.Empty) + ": " + text);
			connection.Log().Warn(ex, message);
			throw ex;
		}
	}
	internal class VacuumSqliteOperation : IPreparedSqliteOperation, IEnableLogger, IDisposable
	{
		private readonly sqlite3_stmt _vacuumOp;

		private readonly IScheduler _scheduler;

		private IDisposable _inner;

		public SQLiteConnection Connection { get; protected set; }

		public VacuumSqliteOperation(SQLiteConnection conn, IScheduler scheduler)
		{
			SQLite3.Result result = (SQLite3.Result)raw.sqlite3_prepare_v2(conn.Handle, "VACUUM", out _vacuumOp);
			Connection = conn;
			if (result != SQLite3.Result.OK)
			{
				throw new SQLiteException(result, "Couldn't prepare vacuum statement");
			}
			_scheduler = scheduler;
			_inner = _vacuumOp;
		}

		public Action PrepareToExecute()
		{
			_ = _scheduler.Now.UtcTicks;
			return delegate
			{
				try
				{
					this.Checked(raw.sqlite3_step(_vacuumOp));
				}
				finally
				{
					this.Checked(raw.sqlite3_reset(_vacuumOp));
				}
			};
		}

		public void Dispose()
		{
			Interlocked.Exchange(ref _inner, Disposable.Empty).Dispose();
		}
	}
	internal class SqliteOperationQueue : IEnableLogger, IDisposable
	{
		private readonly Akavache.Sqlite3.Internal.AsyncLock _flushLock = new Akavache.Sqlite3.Internal.AsyncLock();

		private readonly IScheduler _scheduler;

		private readonly Lazy<BulkSelectSqliteOperation> _bulkSelectKey;

		private readonly Lazy<BulkSelectByTypeSqliteOperation> _bulkSelectType;

		private readonly Lazy<BulkInsertSqliteOperation> _bulkInsertKey;

		private readonly Lazy<BulkInvalidateSqliteOperation> _bulkInvalidateKey;

		private readonly Lazy<BulkInvalidateByTypeSqliteOperation> _bulkInvalidateType;

		private readonly Lazy<InvalidateAllSqliteOperation> _invalidateAll;

		private readonly Lazy<VacuumSqliteOperation> _vacuum;

		private readonly Lazy<DeleteExpiredSqliteOperation> _deleteExpired;

		private readonly Lazy<GetKeysSqliteOperation> _getAllKeys;

		private readonly Lazy<BeginTransactionSqliteOperation> _begin;

		private readonly Lazy<CommitTransactionSqliteOperation> _commit;

		private BlockingCollection<OperationQueueItem> _operationQueue = new BlockingCollection<OperationQueueItem>();

		private IDisposable? _start;

		private CancellationTokenSource? _shouldQuit;

		private const string NullKey = "___THIS_IS_THE_NULL_KEY_HOPE_NOBODY_PICKS_IT_FFS_____";

		public SqliteOperationQueue(SQLiteConnection connection, IScheduler scheduler)
		{
			_scheduler = scheduler;
			_bulkSelectKey = new Lazy<BulkSelectSqliteOperation>(() => new BulkSelectSqliteOperation(connection, useTypeInsteadOfKey: false, scheduler));
			_bulkSelectType = new Lazy<BulkSelectByTypeSqliteOperation>(() => new BulkSelectByTypeSqliteOperation(connection, scheduler));
			_bulkInsertKey = new Lazy<BulkInsertSqliteOperation>(() => new BulkInsertSqliteOperation(connection));
			_bulkInvalidateKey = new Lazy<BulkInvalidateSqliteOperation>(() => new BulkInvalidateSqliteOperation(connection, useTypeInsteadOfKey: false));
			_bulkInvalidateType = new Lazy<BulkInvalidateByTypeSqliteOperation>(() => new BulkInvalidateByTypeSqliteOperation(connection));
			_invalidateAll = new Lazy<InvalidateAllSqliteOperation>(() => new InvalidateAllSqliteOperation(connection));
			_vacuum = new Lazy<VacuumSqliteOperation>(() => new VacuumSqliteOperation(connection, scheduler));
			_deleteExpired = new Lazy<DeleteExpiredSqliteOperation>(() => new DeleteExpiredSqliteOperation(connection, scheduler));
			_getAllKeys = new Lazy<GetKeysSqliteOperation>(() => new GetKeysSqliteOperation(connection, scheduler));
			_begin = new Lazy<BeginTransactionSqliteOperation>(() => new BeginTransactionSqliteOperation(connection));
			_commit = new Lazy<CommitTransactionSqliteOperation>(() => new CommitTransactionSqliteOperation(connection));
		}

		internal SqliteOperationQueue()
		{
		}

		public IDisposable Start()
		{
			if (_start != null)
			{
				return _start;
			}
			_shouldQuit = new CancellationTokenSource();
			Task task = Task.Run(async delegate
			{
				List<OperationQueueItem> toProcess = new List<OperationQueueItem>();
				while (!_shouldQuit.IsCancellationRequested)
				{
					toProcess.Clear();
					IDisposable disposable;
					try
					{
						disposable = await _flushLock.LockAsync(_shouldQuit.Token).ConfigureAwait(continueOnCapturedContext: false);
					}
					catch (OperationCanceledException)
					{
						break;
					}
					if (disposable == null)
					{
						break;
					}
					using (disposable)
					{
						OperationQueueItem item;
						try
						{
							item = _operationQueue.Take(_shouldQuit.Token);
						}
						catch (OperationCanceledException)
						{
							break;
						}
						if (_shouldQuit.IsCancellationRequested && item == null)
						{
							break;
						}
						toProcess.Add(item);
						while (toProcess.Count < 64 && _operationQueue.TryTake(out item))
						{
							toProcess.Add(item);
						}
						try
						{
							ProcessItems(CoalesceOperations(toProcess));
						}
						catch (SQLiteException)
						{
							foreach (OperationQueueItem item2 in toProcess)
							{
								_operationQueue.Add(item2);
							}
						}
					}
				}
			});
			return _start = Disposable.Create(delegate
			{
				try
				{
					_shouldQuit.Cancel();
					task.Wait();
				}
				catch (OperationCanceledException)
				{
				}
				try
				{
					using (_flushLock.LockAsync().Result)
					{
						FlushInternal();
					}
				}
				catch (OperationCanceledException)
				{
				}
				_start = null;
			});
		}

		public IObservable<Unit> Flush()
		{
			OperationQueueItem operationQueueItem = OperationQueueItem.CreateUnit(OperationType.DoNothing);
			_operationQueue.Add(operationQueueItem);
			return operationQueueItem.CompletionAsUnit;
		}

		public AsyncSubject<IEnumerable<CacheElement>> Select(IEnumerable<string> keys)
		{
			OperationQueueItem operationQueueItem = OperationQueueItem.CreateSelect(OperationType.BulkSelectSqliteOperation, keys);
			_operationQueue.Add(operationQueueItem);
			return operationQueueItem.CompletionAsElements;
		}

		public AsyncSubject<IEnumerable<CacheElement>> SelectTypes(IEnumerable<string> types)
		{
			OperationQueueItem operationQueueItem = OperationQueueItem.CreateSelect(OperationType.BulkSelectByTypeSqliteOperation, types);
			_operationQueue.Add(operationQueueItem);
			return operationQueueItem.CompletionAsElements;
		}

		public AsyncSubject<Unit> Insert(IEnumerable<CacheElement> items)
		{
			OperationQueueItem operationQueueItem = OperationQueueItem.CreateInsert(OperationType.BulkInsertSqliteOperation, items);
			_operationQueue.Add(operationQueueItem);
			return operationQueueItem.CompletionAsUnit;
		}

		public AsyncSubject<Unit> Invalidate(IEnumerable<string> keys)
		{
			OperationQueueItem operationQueueItem = OperationQueueItem.CreateInvalidate(OperationType.BulkInvalidateSqliteOperation, keys);
			_operationQueue.Add(operationQueueItem);
			return operationQueueItem.CompletionAsUnit;
		}

		public AsyncSubject<Unit> InvalidateTypes(IEnumerable<string> types)
		{
			OperationQueueItem operationQueueItem = OperationQueueItem.CreateInvalidate(OperationType.BulkInvalidateByTypeSqliteOperation, types);
			_operationQueue.Add(operationQueueItem);
			return operationQueueItem.CompletionAsUnit;
		}

		public AsyncSubject<Unit> InvalidateAll()
		{
			OperationQueueItem operationQueueItem = OperationQueueItem.CreateUnit(OperationType.InvalidateAllSqliteOperation);
			_operationQueue.Add(operationQueueItem);
			return operationQueueItem.CompletionAsUnit;
		}

		public AsyncSubject<Unit> Vacuum()
		{
			AsyncSubject<Unit> asyncSubject = new AsyncSubject<Unit>();
			Task.Run(async delegate
			{
				IDisposable @lock = null;
				try
				{
					Task<IDisposable> task = _flushLock.LockAsync(_shouldQuit?.Token ?? CancellationToken.None);
					_operationQueue.Add(OperationQueueItem.CreateUnit(OperationType.DoNothing));
					try
					{
						@lock = await task.ConfigureAwait(continueOnCapturedContext: false);
					}
					catch (OperationCanceledException)
					{
					}
					OperationQueueItem operationQueueItem = OperationQueueItem.CreateUnit(OperationType.DeleteExpiredSqliteOperation);
					_operationQueue.Add(operationQueueItem);
					FlushInternal();
					await operationQueueItem.CompletionAsUnit;
					OperationQueueItem operationQueueItem2 = OperationQueueItem.CreateUnit(OperationType.VacuumSqliteOperation);
					MarshalCompletion(operationQueueItem2.Completion, _vacuum.Value.PrepareToExecute(), Observable.Return(Unit.Default));
					await operationQueueItem2.CompletionAsUnit;
				}
				finally
				{
					@lock?.Dispose();
				}
			}).ToObservable().ObserveOn(_scheduler)
				.Multicast(asyncSubject)
				.PermaRef();
			return asyncSubject;
		}

		public AsyncSubject<IEnumerable<string>> GetAllKeys()
		{
			OperationQueueItem operationQueueItem = OperationQueueItem.CreateGetAllKeys();
			_operationQueue.Add(operationQueueItem);
			return operationQueueItem.CompletionAsKeys;
		}

		public void Dispose()
		{
			if (_bulkSelectKey.IsValueCreated)
			{
				_bulkSelectKey.Value.Dispose();
			}
			if (_bulkSelectType.IsValueCreated)
			{
				_bulkSelectType.Value.Dispose();
			}
			if (_bulkInsertKey.IsValueCreated)
			{
				_bulkInsertKey.Value.Dispose();
			}
			if (_bulkInvalidateKey.IsValueCreated)
			{
				_bulkInvalidateKey.Value.Dispose();
			}
			if (_bulkInvalidateType.IsValueCreated)
			{
				_bulkInvalidateType.Value.Dispose();
			}
			if (_invalidateAll.IsValueCreated)
			{
				_invalidateAll.Value.Dispose();
			}
			if (_vacuum.IsValueCreated)
			{
				_vacuum.Value.Dispose();
			}
			if (_deleteExpired.IsValueCreated)
			{
				_deleteExpired.Value.Dispose();
			}
			if (_getAllKeys.IsValueCreated)
			{
				_getAllKeys.Value.Dispose();
			}
			if (_begin.IsValueCreated)
			{
				_begin.Value.Dispose();
			}
			if (_begin.IsValueCreated)
			{
				_commit.Value.Dispose();
			}
			_operationQueue?.Dispose();
			_flushLock?.Dispose();
			_shouldQuit?.Dispose();
		}

		internal List<OperationQueueItem> DumpQueue()
		{
			return _operationQueue.ToList();
		}

		private static void MarshalCompletion(object completion, Action block, IObservable<Unit> commitResult)
		{
			AsyncSubject<Unit> asyncSubject = (AsyncSubject<Unit>)completion;
			try
			{
				block();
				asyncSubject.OnNext(Unit.Default);
				commitResult.SelectMany((Unit _) => Observable.Empty<Unit>()).Multicast(asyncSubject).PermaRef();
			}
			catch (Exception error)
			{
				asyncSubject.OnError(error);
			}
		}

		private void FlushInternal()
		{
			BlockingCollection<OperationQueueItem> value = new BlockingCollection<OperationQueueItem>();
			List<OperationQueueItem> inputItems = Interlocked.Exchange(ref _operationQueue, value).ToList();
			ProcessItems(CoalesceOperations(inputItems));
		}

		private void ProcessItems(List<OperationQueueItem> toProcess)
		{
			AsyncSubject<Unit> commitResult = new AsyncSubject<Unit>();
			_begin.Value.PrepareToExecute()();
			foreach (OperationQueueItem item in toProcess)
			{
				switch (item.OperationType)
				{
				case OperationType.DoNothing:
					MarshalCompletion(item.Completion, delegate
					{
					}, commitResult);
					break;
				case OperationType.BulkInsertSqliteOperation:
					MarshalCompletion(item.Completion, _bulkInsertKey.Value.PrepareToExecute(item.ParametersAsElements), commitResult);
					break;
				case OperationType.BulkInvalidateByTypeSqliteOperation:
					MarshalCompletion(item.Completion, _bulkInvalidateType.Value.PrepareToExecute(item.ParametersAsKeys), commitResult);
					break;
				case OperationType.BulkInvalidateSqliteOperation:
					MarshalCompletion(item.Completion, _bulkInvalidateKey.Value.PrepareToExecute(item.ParametersAsKeys), commitResult);
					break;
				case OperationType.BulkSelectByTypeSqliteOperation:
					MarshalCompletion(item.Completion, _bulkSelectType.Value.PrepareToExecute(item.ParametersAsKeys), commitResult);
					break;
				case OperationType.BulkSelectSqliteOperation:
					MarshalCompletion(item.Completion, _bulkSelectKey.Value.PrepareToExecute(item.ParametersAsKeys), commitResult);
					break;
				case OperationType.GetKeysSqliteOperation:
					MarshalCompletion(item.Completion, _getAllKeys.Value.PrepareToExecute(), commitResult);
					break;
				case OperationType.InvalidateAllSqliteOperation:
					MarshalCompletion(item.Completion, _invalidateAll.Value.PrepareToExecute(), commitResult);
					break;
				case OperationType.DeleteExpiredSqliteOperation:
					MarshalCompletion(item.Completion, _deleteExpired.Value.PrepareToExecute(), commitResult);
					break;
				case OperationType.VacuumSqliteOperation:
					throw new ArgumentException("Vacuum operation can't run inside transaction", "toProcess");
				default:
					throw new ArgumentException("Unknown operation", "toProcess");
				}
			}
			try
			{
				_commit.Value.PrepareToExecute()();
				_scheduler.Schedule((Action)delegate
				{
					commitResult.OnNext(Unit.Default);
					commitResult.OnCompleted();
				});
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
				Exception ex3 = ex2;
				_scheduler.Schedule((Action)delegate
				{
					commitResult.OnError(ex3);
				});
			}
		}

		private void MarshalCompletion<T>(object completion, Func<T> block, IObservable<Unit> commitResult)
		{
			AsyncSubject<T> subj = (AsyncSubject<T>)completion;
			try
			{
				T value = block();
				subj.OnNext(value);
				commitResult.SelectMany((Unit _) => Observable.Empty<T>()).Multicast(subj).PermaRef();
			}
			catch (Exception ex)
			{
				Exception ex2 = ex;
				_scheduler.Schedule((Action)delegate
				{
					subj.OnError(ex2);
				});
			}
		}

		internal static List<OperationQueueItem> CoalesceOperations(List<OperationQueueItem> inputItems)
		{
			if (inputItems.Count <= 1)
			{
				return inputItems;
			}
			List<OperationQueueItem> list = new List<OperationQueueItem>();
			if (inputItems.Any((OperationQueueItem x) => x.OperationType == OperationType.GetKeysSqliteOperation || x.OperationType == OperationType.InvalidateAllSqliteOperation))
			{
				return inputItems;
			}
			Dictionary<string, List<OperationQueueItem>> dictionary = new Dictionary<string, List<OperationQueueItem>>();
			foreach (OperationQueueItem inputItem in inputItems)
			{
				string key = GetKeyFromTuple(inputItem) ?? "___THIS_IS_THE_NULL_KEY_HOPE_NOBODY_PICKS_IT_FFS_____";
				if (!dictionary.ContainsKey(key))
				{
					dictionary.Add(key, new List<OperationQueueItem>());
				}
				dictionary[key].Add(inputItem);
			}
			OperationType[] source = new OperationType[3]
			{
				OperationType.BulkInvalidateSqliteOperation,
				OperationType.BulkInsertSqliteOperation,
				OperationType.BulkSelectSqliteOperation
			};
			foreach (string item in dictionary.Keys.ToList())
			{
				if (!(item == "___THIS_IS_THE_NULL_KEY_HOPE_NOBODY_PICKS_IT_FFS_____"))
				{
					dictionary[item] = ((IEnumerable<OperationType>)source).Aggregate((IEnumerable<OperationQueueItem>)dictionary[item], (Func<IEnumerable<OperationQueueItem>, OperationType, IEnumerable<OperationQueueItem>>)MultipleOpsTurnIntoSingleOp).ToList();
				}
			}
			while (dictionary.Count > 0)
			{
				List<OperationQueueItem> list2 = new List<OperationQueueItem>();
				List<string> list3 = new List<string>();
				foreach (string key2 in dictionary.Keys)
				{
					List<OperationQueueItem> list4 = dictionary[key2];
					list2.Add(list4[0]);
					list4.RemoveAt(0);
					if (list4.Count == 0)
					{
						list3.Add(key2);
					}
				}
				IEnumerable<OperationQueueItem> collection = CoalesceUnrelatedItems(list2);
				list.AddRange(collection);
				foreach (string item2 in list3)
				{
					dictionary.Remove(item2);
				}
			}
			return list;
		}

		private static IEnumerable<OperationQueueItem> CoalesceUnrelatedItems(IEnumerable<OperationQueueItem> items)
		{
			return (from x in items
				group x by x.OperationType).SelectMany((IGrouping<OperationType, OperationQueueItem> group) => group.Key switch
			{
				OperationType.BulkSelectSqliteOperation => new OperationQueueItem[1] { GroupUnrelatedSelects(group) }, 
				OperationType.BulkInsertSqliteOperation => new OperationQueueItem[1] { GroupUnrelatedInserts(group) }, 
				OperationType.BulkInvalidateSqliteOperation => new OperationQueueItem[1] { GroupUnrelatedDeletes(group) }, 
				_ => group, 
			});
		}

		private static IEnumerable<OperationQueueItem> MultipleOpsTurnIntoSingleOp(IEnumerable<OperationQueueItem> itemsWithSameKey, OperationType opTypeToDedup)
		{
			List<OperationQueueItem> currentWrites = null;
			foreach (OperationQueueItem item in itemsWithSameKey)
			{
				if (item.OperationType == opTypeToDedup)
				{
					if (currentWrites == null)
					{
						currentWrites = new List<OperationQueueItem>();
					}
					currentWrites.Add(item);
					continue;
				}
				if (currentWrites != null)
				{
					if (currentWrites.Count == 1)
					{
						yield return currentWrites[0];
					}
					else
					{
						yield return new OperationQueueItem(CombineSubjectsByOperation(currentWrites[0].Completion, from x in currentWrites.Skip(1)
							select x.Completion, opTypeToDedup), currentWrites[0].Parameters)
						{
							OperationType = currentWrites[0].OperationType
						};
					}
					currentWrites = null;
				}
				yield return item;
			}
			if (currentWrites != null)
			{
				yield return new OperationQueueItem(CombineSubjectsByOperation(currentWrites[0].Completion, from x in currentWrites.Skip(1)
					select x.Completion, opTypeToDedup), currentWrites[0].Parameters)
				{
					OperationType = currentWrites[0].OperationType
				};
			}
		}

		private static OperationQueueItem GroupUnrelatedSelects(IEnumerable<OperationQueueItem> unrelatedSelects)
		{
			Dictionary<string, AsyncSubject<IEnumerable<CacheElement>>> elementMap = new Dictionary<string, AsyncSubject<IEnumerable<CacheElement>>>();
			List<OperationQueueItem> list = unrelatedSelects.ToList();
			if (list.Count == 1)
			{
				return list[0];
			}
			foreach (OperationQueueItem item in list)
			{
				string key = item.ParametersAsKeys.First();
				elementMap[key] = item.CompletionAsElements;
			}
			OperationQueueItem operationQueueItem = OperationQueueItem.CreateSelect(OperationType.BulkSelectSqliteOperation, elementMap.Keys);
			operationQueueItem.CompletionAsElements.Subscribe(delegate(IEnumerable<CacheElement> items)
			{
				Dictionary<string, CacheElement> dictionary = items.ToDictionary((CacheElement k) => k.Key, (CacheElement v) => v);
				foreach (string key2 in elementMap.Keys)
				{
					try
					{
						if (dictionary.ContainsKey(key2))
						{
							elementMap[key2].OnNext(EnumerableEx.Return(dictionary[key2]));
						}
						else
						{
							elementMap[key2].OnNext(Enumerable.Empty<CacheElement>());
						}
						elementMap[key2].OnCompleted();
					}
					catch (KeyNotFoundException)
					{
					}
				}
			}, delegate(Exception ex)
			{
				foreach (AsyncSubject<IEnumerable<CacheElement>> value in elementMap.Values)
				{
					value.OnError(ex);
				}
			}, delegate
			{
				foreach (AsyncSubject<IEnumerable<CacheElement>> value2 in elementMap.Values)
				{
					value2.OnCompleted();
				}
			});
			return operationQueueItem;
		}

		private static OperationQueueItem GroupUnrelatedInserts(IEnumerable<OperationQueueItem> unrelatedInserts)
		{
			List<OperationQueueItem> list = unrelatedInserts.ToList();
			if (list.Count == 1)
			{
				return list[0];
			}
			AsyncSubject<Unit> subj = new AsyncSubject<Unit>();
			List<CacheElement> toInsert = list.SelectMany(delegate(OperationQueueItem x)
			{
				subj.Subscribe(x.CompletionAsUnit);
				return x.ParametersAsElements;
			}).ToList();
			return OperationQueueItem.CreateInsert(OperationType.BulkInsertSqliteOperation, toInsert, subj);
		}

		private static OperationQueueItem GroupUnrelatedDeletes(IEnumerable<OperationQueueItem> unrelatedDeletes)
		{
			AsyncSubject<Unit> subj = new AsyncSubject<Unit>();
			List<OperationQueueItem> list = unrelatedDeletes.ToList();
			if (list.Count == 1)
			{
				return list[0];
			}
			List<string> toInvalidate = list.SelectMany(delegate(OperationQueueItem x)
			{
				subj.Subscribe(x.CompletionAsUnit);
				return x.ParametersAsKeys;
			}).ToList();
			return OperationQueueItem.CreateInvalidate(OperationType.BulkInvalidateSqliteOperation, toInvalidate, subj);
		}

		private static string? GetKeyFromTuple(OperationQueueItem item)
		{
			switch (item.OperationType)
			{
			case OperationType.BulkInsertSqliteOperation:
				return item.ParametersAsElements.First().Key;
			case OperationType.BulkSelectSqliteOperation:
			case OperationType.BulkSelectByTypeSqliteOperation:
			case OperationType.BulkInvalidateSqliteOperation:
			case OperationType.BulkInvalidateByTypeSqliteOperation:
				return item.ParametersAsKeys.First();
			case OperationType.DoNothing:
			case OperationType.InvalidateAllSqliteOperation:
			case OperationType.VacuumSqliteOperation:
			case OperationType.DeleteExpiredSqliteOperation:
			case OperationType.GetKeysSqliteOperation:
				return null;
			default:
				throw new ArgumentException("Unknown operation", "item");
			}
		}

		private static object CombineSubjectsByOperation(object source, IEnumerable<object>? subjects, OperationType opType)
		{
			List<object> source2 = (subjects ?? Enumerable.Empty<object>()).ToList();
			switch (opType)
			{
			case OperationType.BulkSelectSqliteOperation:
				return CombineSubjects((AsyncSubject<IEnumerable<CacheElement>>)source, source2.Cast<AsyncSubject<IEnumerable<CacheElement>>>());
			case OperationType.BulkInsertSqliteOperation:
			case OperationType.BulkInvalidateSqliteOperation:
				return CombineSubjects((AsyncSubject<Unit>)source, source2.Cast<AsyncSubject<Unit>>());
			default:
				throw new ArgumentException("Invalid operation type", "opType");
			}
		}

		private static AsyncSubject<T> CombineSubjects<T>(AsyncSubject<T> source, IEnumerable<AsyncSubject<T>> subjs)
		{
			foreach (AsyncSubject<T> subj in subjs)
			{
				source.Subscribe(subj);
			}
			return source;
		}
	}
	internal class OperationQueueItem
	{
		public OperationType OperationType { get; set; }

		public IEnumerable? Parameters { get; set; }

		public object Completion { get; set; }

		public IEnumerable<CacheElement>? ParametersAsElements => (IEnumerable<CacheElement>)Parameters;

		public IEnumerable<string>? ParametersAsKeys => (IEnumerable<string>)Parameters;

		public AsyncSubject<Unit> CompletionAsUnit => (AsyncSubject<Unit>)Completion;

		public AsyncSubject<IEnumerable<CacheElement>> CompletionAsElements => (AsyncSubject<IEnumerable<CacheElement>>)Completion;

		public AsyncSubject<IEnumerable<string>> CompletionAsKeys => (AsyncSubject<IEnumerable<string>>)Completion;

		public OperationQueueItem(object completion, IEnumerable? parameters)
		{
			Completion = completion;
			Parameters = parameters;
		}

		public static OperationQueueItem CreateInsert(OperationType opType, IEnumerable<CacheElement> toInsert, AsyncSubject<Unit>? completion = null)
		{
			return new OperationQueueItem(completion ?? new AsyncSubject<Unit>(), toInsert)
			{
				OperationType = opType
			};
		}

		public static OperationQueueItem CreateInvalidate(OperationType opType, IEnumerable<string> toInvalidate, AsyncSubject<Unit>? completion = null)
		{
			return new OperationQueueItem(completion ?? new AsyncSubject<Unit>(), toInvalidate)
			{
				OperationType = opType
			};
		}

		public static OperationQueueItem CreateSelect(OperationType opType, IEnumerable<string> toSelect, AsyncSubject<IEnumerable<CacheElement>>? completion = null)
		{
			return new OperationQueueItem(completion ?? new AsyncSubject<IEnumerable<CacheElement>>(), toSelect)
			{
				OperationType = opType
			};
		}

		public static OperationQueueItem CreateUnit(OperationType opType, AsyncSubject<Unit>? completion = null)
		{
			return new OperationQueueItem(completion ?? new AsyncSubject<Unit>(), null)
			{
				OperationType = opType
			};
		}

		public static OperationQueueItem CreateGetAllKeys()
		{
			return new OperationQueueItem(new AsyncSubject<IEnumerable<string>>(), null)
			{
				OperationType = OperationType.GetKeysSqliteOperation
			};
		}
	}
	[Akavache.Core.Preserve(AllMembers = true)]
	public class Registrations : IWantsToRegisterStuff
	{
		public static void Start(string applicationName, Action initSql)
		{
			BlobCache.ApplicationName = applicationName;
			initSql?.Invoke();
		}

		public void Register(IMutableDependencyResolver resolver, IReadonlyDependencyResolver readonlyDependencyResolver)
		{
			if (resolver == null)
			{
				throw new ArgumentNullException("resolver");
			}
			IFilesystemProvider fs = Locator.Current.GetService<IFilesystemProvider>();
			if (fs == null)
			{
				throw new Exception("Failed to initialize Akavache properly. Do you have a reference to Akavache.dll?");
			}
			Lazy<IBlobCache> localCache = new Lazy<IBlobCache>(delegate
			{
				string defaultLocalMachineCacheDirectory = fs.GetDefaultLocalMachineCacheDirectory();
				if (defaultLocalMachineCacheDirectory == null || string.IsNullOrWhiteSpace(defaultLocalMachineCacheDirectory))
				{
					throw new InvalidOperationException("There is a invalid directory being returned by the file system provider.");
				}
				fs.CreateRecursive(defaultLocalMachineCacheDirectory).SubscribeOn(BlobCache.TaskpoolScheduler).Wait();
				return new SqlRawPersistentBlobCache(Path.Combine(fs.GetDefaultLocalMachineCacheDirectory(), "blobs.db"), BlobCache.TaskpoolScheduler);
			});
			resolver.Register(() => localCache.Value, typeof(IBlobCache), "LocalMachine");
			Lazy<IBlobCache> userAccount = new Lazy<IBlobCache>(delegate
			{
				string defaultRoamingCacheDirectory = fs.GetDefaultRoamingCacheDirectory();
				if (defaultRoamingCacheDirectory == null || string.IsNullOrWhiteSpace(defaultRoamingCacheDirectory))
				{
					throw new InvalidOperationException("There is a invalid directory being returned by the file system provider.");
				}
				fs.CreateRecursive(defaultRoamingCacheDirectory).SubscribeOn(BlobCache.TaskpoolScheduler).Wait();
				return new SqlRawPersistentBlobCache(Path.Combine(fs.GetDefaultRoamingCacheDirectory(), "userblobs.db"), BlobCache.TaskpoolScheduler);
			});
			resolver.Register(() => userAccount.Value, typeof(IBlobCache), "UserAccount");
			Lazy<ISecureBlobCache> secure = new Lazy<ISecureBlobCache>(delegate
			{
				string defaultSecretCacheDirectory = fs.GetDefaultSecretCacheDirectory();
				if (defaultSecretCacheDirectory == null || string.IsNullOrWhiteSpace(defaultSecretCacheDirectory))
				{
					throw new InvalidOperationException("There is a invalid directory being returned by the file system provider.");
				}
				fs.CreateRecursive(defaultSecretCacheDirectory).SubscribeOn(BlobCache.TaskpoolScheduler).Wait();
				return new SQLiteEncryptedBlobCache(Path.Combine(fs.GetDefaultSecretCacheDirectory(), "secret.db"), Locator.Current.GetService<IEncryptionProvider>(), BlobCache.TaskpoolScheduler);
			});
			resolver.Register(() => secure.Value, typeof(ISecureBlobCache));
		}
	}
	internal class CacheElement
	{
		[PrimaryKey]
		public string Key { get; set; } = string.Empty;

		[Indexed]
		public string? TypeName { get; set; }

		public byte[] Value { get; set; } = Array.Empty<byte>();

		[Indexed]
		public DateTime Expiration { get; set; }

		public DateTime CreatedAt { get; set; }
	}
	internal interface IObjectWrapper
	{
	}
	internal class ObjectWrapper<T> : IObjectWrapper
	{
		public T Value { get; set; }
	}
	internal class SchemaInfo
	{
		public int Version { get; set; }
	}
	public class SQLiteEncryptedBlobCache : SqlRawPersistentBlobCache, ISecureBlobCache, IBlobCache, IDisposable
	{
		private readonly IEncryptionProvider _encryption;

		public SQLiteEncryptedBlobCache(string databaseFile, IEncryptionProvider? encryptionProvider = null, IScheduler? scheduler = null)
			: base(databaseFile, scheduler)
		{
			_encryption = encryptionProvider ?? Locator.Current.GetService<IEncryptionProvider>();
			if (_encryption == null)
			{
				throw new Exception("No IEncryptionProvider available. This should never happen, your DependencyResolver is broken");
			}
		}

		protected override IObservable<byte[]> BeforeWriteToDiskFilter(byte[] data, IScheduler scheduler)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (data.Length == 0)
			{
				return Observable.Return(data);
			}
			return _encryption.EncryptBlock(data);
		}

		protected override IObservable<byte[]> AfterReadFromDiskFilter(byte[] data, IScheduler scheduler)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			if (data.Length == 0)
			{
				return Observable.Return(data);
			}
			return _encryption.DecryptBlock(data);
		}
	}
	public static class SqlLite
	{
		public static void Start(Action bundleRegistration)
		{
			if (bundleRegistration == null)
			{
				throw new ArgumentNullException("bundleRegistration");
			}
			bundleRegistration();
		}
	}
	public class SqlRawPersistentBlobCache : IEnableLogger, IObjectBulkBlobCache, IObjectBlobCache, IBlobCache, IDisposable, IBulkBlobCache
	{
		private static readonly object DisposeGate = 42;

		private readonly IObservable<Unit> _initializer;

		private readonly AsyncSubject<Unit> _shutdown = new AsyncSubject<Unit>();

		private SqliteOperationQueue? _opQueue;

		private IDisposable? _queueThread;

		private DateTimeKind? _dateTimeKind;

		private bool _disposed;

		private JsonDateTimeContractResolver _jsonDateTimeContractResolver = new JsonDateTimeContractResolver();

		public DateTimeKind? ForcedDateTimeKind
		{
			get
			{
				return _dateTimeKind ?? BlobCache.ForcedDateTimeKind;
			}
			set
			{
				_dateTimeKind = value;
				if (_jsonDateTimeContractResolver != null)
				{
					_jsonDateTimeContractResolver.ForceDateTimeKindOverride = value;
				}
			}
		}

		public IScheduler Scheduler { get; }

		public SQLiteConnection Connection { get; }

		public IObservable<Unit> Shutdown => _shutdown;

		public SqlRawPersistentBlobCache(string databaseFile, IScheduler? scheduler = null)
		{
			Scheduler = scheduler ?? BlobCache.TaskpoolScheduler;
			BlobCache.EnsureInitialized();
			Connection = new SQLiteConnection(databaseFile, storeDateTimeAsTicks: true);
			_initializer = Initialize();
		}

		public IObservable<Unit> Insert(string key, byte[] data, DateTimeOffset? absoluteExpiration = null)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
			}
			if (key == null)
			{
				return Observable.Throw<Unit>(new ArgumentNullException("key"));
			}
			if (data == null)
			{
				return Observable.Throw<Unit>(new ArgumentNullException("data"));
			}
			if (_opQueue == null)
			{
				return Observable.Throw<Unit>(new InvalidOperationException("There is not a valid operation queue"));
			}
			DateTime exp = (absoluteExpiration ?? DateTimeOffset.MaxValue).UtcDateTime;
			DateTime createdAt = Scheduler.Now.UtcDateTime;
			return _initializer.SelectMany((Unit _) => BeforeWriteToDiskFilter(data, Scheduler)).SelectMany((byte[] encData) => _opQueue.Insert(new CacheElement[1]
			{
				new CacheElement
				{
					Key = key,
					Value = encData,
					CreatedAt = createdAt,
					Expiration = exp
				}
			})).PublishLast()
				.PermaRef();
		}

		public IObservable<byte[]> Get(string key)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<byte[]>("SqlitePersistentBlobCache");
			}
			if (key == null)
			{
				return Observable.Throw<byte[]>(new ArgumentNullException("key"));
			}
			if (_opQueue == null)
			{
				return Observable.Throw<byte[]>(new InvalidOperationException("There is not a valid operation queue"));
			}
			return _initializer.SelectMany((Unit _) => _opQueue.Select(new string[1] { key })).SelectMany(delegate(IEnumerable<CacheElement> x)
			{
				List<CacheElement> list = x.ToList();
				return (IObservable<byte[]>)((list.Count != 1) ? ((object)ExceptionHelper.ObservableThrowKeyNotFoundException<byte[]>(key)) : ((object)Observable.Return(list.First().Value)));
			}).SelectMany((byte[] x) => AfterReadFromDiskFilter(x, Scheduler))
				.PublishLast()
				.PermaRef();
		}

		public IObservable<IEnumerable<string>> GetAllKeys()
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<List<string>>("SqlitePersistentBlobCache");
			}
			if (_opQueue == null)
			{
				return Observable.Throw<IEnumerable<string>>(new InvalidOperationException("There is not a valid operation queue"));
			}
			return _initializer.SelectMany((Unit _) => _opQueue.GetAllKeys()).PublishLast().PermaRef();
		}

		public IObservable<DateTimeOffset?> GetCreatedAt(string key)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<DateTimeOffset?>("SqlitePersistentBlobCache");
			}
			if (key == null)
			{
				return Observable.Throw<DateTimeOffset?>(new ArgumentNullException("key"));
			}
			if (_opQueue == null)
			{
				return Observable.Throw<DateTimeOffset?>(new InvalidOperationException("There is not a valid operation queue"));
			}
			return _initializer.SelectMany((Unit _) => _opQueue.Select(new string[1] { key })).Select(delegate(IEnumerable<CacheElement> x)
			{
				List<CacheElement> list = x.ToList();
				return (list.Count != 1) ? ((DateTimeOffset?)null) : new DateTimeOffset?(new DateTimeOffset(list[0].CreatedAt, TimeSpan.Zero));
			}).PublishLast()
				.PermaRef();
		}

		public IObservable<DateTimeOffset?> GetObjectCreatedAt<T>(string key)
		{
			return GetCreatedAt(key);
		}

		public IObservable<Unit> Flush()
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
			}
			if (_opQueue == null)
			{
				return Observable.Throw<Unit>(new InvalidOperationException("There is not a valid operation queue"));
			}
			return _initializer.SelectMany((Unit _) => _opQueue.Flush()).PublishLast().PermaRef();
		}

		public IObservable<Unit> Invalidate(string key)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
			}
			if (_opQueue == null)
			{
				return Observable.Throw<Unit>(new InvalidOperationException("There is not a valid operation queue"));
			}
			return _initializer.SelectMany((Unit _) => _opQueue.Invalidate(new string[1] { key })).PublishLast().PermaRef();
		}

		public IObservable<Unit> InvalidateAll()
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
			}
			if (_opQueue == null)
			{
				return Observable.Throw<Unit>(new InvalidOperationException("There is not a valid operation queue"));
			}
			return _initializer.SelectMany((Unit _) => _opQueue.InvalidateAll()).PublishLast().PermaRef();
		}

		public IObservable<Unit> InsertObject<T>(string key, T value, DateTimeOffset? absoluteExpiration = null)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
			}
			if (key == null)
			{
				return Observable.Throw<Unit>(new ArgumentNullException("key"));
			}
			if (_opQueue == null)
			{
				return Observable.Throw<Unit>(new InvalidOperationException("There is not a valid operation queue"));
			}
			byte[] data = SerializeObject(value);
			DateTime exp = (absoluteExpiration ?? DateTimeOffset.MaxValue).UtcDateTime;
			DateTime createdAt = Scheduler.Now.UtcDateTime;
			return _initializer.SelectMany((Unit _) => BeforeWriteToDiskFilter(data, Scheduler)).SelectMany((byte[] encData) => _opQueue.Insert(new CacheElement[1]
			{
				new CacheElement
				{
					Key = key,
					TypeName = typeof(T).FullName,
					Value = encData,
					CreatedAt = createdAt,
					Expiration = exp
				}
			})).PublishLast()
				.PermaRef();
		}

		public IObservable<T> GetObject<T>(string key)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<T>("SqlitePersistentBlobCache");
			}
			if (key == null)
			{
				return Observable.Throw<T>(new ArgumentNullException("key"));
			}
			if (_opQueue == null)
			{
				return Observable.Throw<T>(new InvalidOperationException("There is not a valid operation queue"));
			}
			return _initializer.SelectMany((Unit _) => _opQueue.Select(new string[1] { key })).SelectMany(delegate(IEnumerable<CacheElement> x)
			{
				List<CacheElement> list = x.ToList();
				return (IObservable<byte[]>)((list.Count != 1) ? ((object)ExceptionHelper.ObservableThrowKeyNotFoundException<byte[]>(key)) : ((object)Observable.Return(list.First().Value)));
			}).SelectMany((byte[] x) => AfterReadFromDiskFilter(x, Scheduler))
				.SelectMany(DeserializeObject<T>)
				.PublishLast()
				.PermaRef();
		}

		public IObservable<IEnumerable<T>> GetAllObjects<T>()
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<IEnumerable<T>>("SqlitePersistentBlobCache");
			}
			if (_opQueue == null)
			{
				return Observable.Throw<IEnumerable<T>>(new InvalidOperationException("There is not a valid operation queue"));
			}
			return _initializer.SelectMany((Unit _) => _opQueue.SelectTypes(new string[1] { typeof(T).FullName }).SelectMany((IEnumerable<CacheElement> x) => x.ToObservable().SelectMany((CacheElement y) => AfterReadFromDiskFilter(y.Value, Scheduler)).SelectMany(DeserializeObject<T>)
				.ToList())).PublishLast().PermaRef();
		}

		public IObservable<Unit> InvalidateObject<T>(string key)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
			}
			return Invalidate(key);
		}

		public IObservable<Unit> InvalidateAllObjects<T>()
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
			}
			if (_opQueue == null)
			{
				return Observable.Throw<Unit>(new InvalidOperationException("There is not a valid operation queue"));
			}
			return _initializer.SelectMany((Unit _) => _opQueue.InvalidateTypes(new string[1] { typeof(T).FullName })).PublishLast().PermaRef();
		}

		public IObservable<Unit> Vacuum()
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
			}
			if (_opQueue == null)
			{
				return Observable.Throw<Unit>(new InvalidOperationException("There is not a valid operation queue"));
			}
			return _initializer.SelectMany((Unit _) => _opQueue.Vacuum()).PublishLast().PermaRef();
		}

		public IObservable<Unit> Insert(IDictionary<string, byte[]> keyValuePairs, DateTimeOffset? absoluteExpiration = null)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
			}
			if (keyValuePairs == null)
			{
				return Observable.Throw<Unit>(new ArgumentNullException("keyValuePairs"));
			}
			if (_opQueue == null)
			{
				return Observable.Throw<Unit>(new InvalidOperationException("There is not a valid operation queue"));
			}
			DateTime exp = (absoluteExpiration ?? DateTimeOffset.MaxValue).UtcDateTime;
			DateTime createdAt = Scheduler.Now.UtcDateTime;
			return _initializer.SelectMany((Unit _) => keyValuePairs.Select<KeyValuePair<string, byte[]>, IObservable<(string, byte[])>>((KeyValuePair<string, byte[]> x) => from data in BeforeWriteToDiskFilter(x.Value, Scheduler)
				select (key: x.Key, data: data))).Merge().ToList()
				.SelectMany((IList<(string key, byte[] data)> list) => _opQueue.Insert(list.Select(((string key, byte[] data) data) => new CacheElement
				{
					Key = data.key,
					Value = data.data,
					CreatedAt = createdAt,
					Expiration = exp
				})))
				.PublishLast()
				.PermaRef();
		}

		public IObservable<IDictionary<string, byte[]>> Get(IEnumerable<string> keys)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<IDictionary<string, byte[]>>("SqlitePersistentBlobCache");
			}
			if (keys == null)
			{
				return Observable.Throw<IDictionary<string, byte[]>>(new ArgumentNullException("keys"));
			}
			if (_opQueue == null)
			{
				return Observable.Throw<IDictionary<string, byte[]>>(new InvalidOperationException("There is not a valid operation queue"));
			}
			return _initializer.SelectMany((Unit _) => _opQueue.Select(keys)).SelectMany((IEnumerable<CacheElement> x) => Observable.Return(x.ToList().ToDictionary((CacheElement element) => element.Key, (CacheElement element) => element.Value))).SelectMany((Dictionary<string, byte[]> dict) => dict.Select((KeyValuePair<string, byte[]> x) => from data in AfterReadFromDiskFilter(x.Value, Scheduler)
				select (key: x.Key, data: data)))
				.Merge()
				.ToDictionary(((string key, byte[] data) x) => x.key, ((string key, byte[] data) x) => x.data)
				.PublishLast()
				.PermaRef();
		}

		public IObservable<IDictionary<string, DateTimeOffset?>> GetCreatedAt(IEnumerable<string> keys)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<IDictionary<string, DateTimeOffset?>>("SqlitePersistentBlobCache");
			}
			if (keys == null)
			{
				return Observable.Throw<IDictionary<string, DateTimeOffset?>>(new ArgumentNullException("keys"));
			}
			if (_opQueue == null)
			{
				return Observable.Throw<IDictionary<string, DateTimeOffset?>>(new InvalidOperationException("There is not a valid operation queue"));
			}
			return (from x in _initializer.SelectMany((Unit _) => _opQueue.Select(keys))
				select ((IEnumerable<CacheElement>)x.ToList()).ToDictionary((Func<CacheElement, string>)((CacheElement element) => element.Key), (Func<CacheElement, DateTimeOffset?>)((CacheElement element) => new DateTimeOffset(element.CreatedAt, TimeSpan.Zero)))).PublishLast().PermaRef();
		}

		public IObservable<Unit> Invalidate(IEnumerable<string> keys)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
			}
			if (_opQueue == null)
			{
				return Observable.Throw<Unit>(new InvalidOperationException("There is not a valid operation queue"));
			}
			return _initializer.SelectMany((Unit _) => _opQueue.Invalidate(keys)).PublishLast().PermaRef();
		}

		public IObservable<Unit> InsertObjects<T>(IDictionary<string, T> keyValuePairs, DateTimeOffset? absoluteExpiration = null)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
			}
			if (keyValuePairs == null)
			{
				return Observable.Throw<Unit>(new ArgumentNullException("keyValuePairs"));
			}
			if (_opQueue == null)
			{
				return Observable.Throw<Unit>(new InvalidOperationException("There is not a valid operation queue"));
			}
			IEnumerable<(string key, byte[] value)> dataToAdd = keyValuePairs.Select<KeyValuePair<string, T>, (string, byte[])>((KeyValuePair<string, T> x) => (key: x.Key, value: SerializeObject(x.Value)));
			DateTime exp = (absoluteExpiration ?? DateTimeOffset.MaxValue).UtcDateTime;
			DateTime createdAt = Scheduler.Now.UtcDateTime;
			return _initializer.SelectMany((Unit _) => dataToAdd.Select(((string key, byte[] value) x) => from data in BeforeWriteToDiskFilter(x.value, Scheduler)
				select (key: x.key, data: data))).Merge().ToList()
				.SelectMany((IList<(string key, byte[] data)> list) => _opQueue.Insert(list.Select(((string key, byte[] data) data) => new CacheElement
				{
					Key = data.key,
					TypeName = typeof(T).FullName,
					Value = data.data,
					CreatedAt = createdAt,
					Expiration = exp
				})))
				.PublishLast()
				.PermaRef();
		}

		public IObservable<IDictionary<string, T>> GetObjects<T>(IEnumerable<string> keys)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<IDictionary<string, T>>("SqlitePersistentBlobCache");
			}
			if (keys == null)
			{
				return Observable.Throw<IDictionary<string, T>>(new ArgumentNullException("keys"));
			}
			if (_opQueue == null)
			{
				return Observable.Throw<IDictionary<string, T>>(new InvalidOperationException("There is not a valid operation queue"));
			}
			return _initializer.SelectMany((Unit _) => _opQueue.Select(keys)).SelectMany((IEnumerable<CacheElement> x) => Observable.Return(x.ToList().ToDictionary((CacheElement element) => element.Key, (CacheElement element) => element.Value))).SelectMany((Dictionary<string, byte[]> dict) => dict.Select((KeyValuePair<string, byte[]> x) => from data in AfterReadFromDiskFilter(x.Value, Scheduler)
				select (key: x.Key, data: data)))
				.Merge()
				.SelectMany(((string key, byte[] data) x) => from obj in DeserializeObject<T>(x.data)
					select (key: x.key, data: obj))
				.ToDictionary(((string key, T data) x) => x.key, ((string key, T data) x) => x.data)
				.PublishLast()
				.PermaRef();
		}

		public IObservable<Unit> InvalidateObjects<T>(IEnumerable<string> keys)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<Unit>("SqlitePersistentBlobCache");
			}
			return Invalidate(keys);
		}

		public void Dispose()
		{
			Dispose(isDisposing: true);
			GC.SuppressFinalize(this);
		}

		internal void ReplaceOperationQueue(SqliteOperationQueue queue)
		{
			_initializer.Wait();
			_opQueue?.Dispose();
			_opQueue = queue;
			_opQueue.Start();
		}

		protected virtual void Dispose(bool isDisposing)
		{
			if (_disposed)
			{
				return;
			}
			if (isDisposing)
			{
				IDisposable disp = Interlocked.Exchange(ref _queueThread, null);
				if (disp == null)
				{
					return;
				}
				Observable.Start(delegate
				{
					lock (DisposeGate)
					{
						disp.Dispose();
						_opQueue?.Dispose();
						Connection.Dispose();
					}
				}, Scheduler).Multicast(_shutdown).PermaRef();
			}
			_disposed = true;
		}

		protected IObservable<Unit> Initialize()
		{
			return Observable.Create(delegate(IObserver<Unit> subj)
			{
				try
				{
					Connection.ExecuteScalar<int>("PRAGMA journal_mode=WAL", Array.Empty<object>());
					Connection.Execute("PRAGMA temp_store=MEMORY");
					Connection.Execute("PRAGMA synchronous=OFF");
				}
				catch (SQLiteException)
				{
				}
				try
				{
					Connection.CreateTable<CacheElement>();
					if (GetSchemaVersion() < 2)
					{
						Connection.Execute("ALTER TABLE CacheElement RENAME TO VersionOneCacheElement;");
						Connection.CreateTable<CacheElement>();
						string format = "INSERT INTO CacheElement SELECT Key,TypeName,Value,Expiration,\"{0}\" AS CreatedAt FROM VersionOneCacheElement;";
						Connection.Execute(string.Format(CultureInfo.InvariantCulture, format, BlobCache.TaskpoolScheduler.Now.UtcDateTime.Ticks));
						Connection.Execute("DROP TABLE VersionOneCacheElement;");
						Connection.Insert(new SchemaInfo
						{
							Version = 2
						});
					}
					_opQueue = new SqliteOperationQueue(Connection, Scheduler);
					_queueThread = _opQueue.Start();
					subj.OnNext(Unit.Default);
					subj.OnCompleted();
				}
				catch (Exception error)
				{
					subj.OnError(error);
				}
				return Disposable.Empty;
			}).PublishLast().PermaRef();
		}

		protected int GetSchemaVersion()
		{
			bool flag = false;
			int result = 0;
			try
			{
				result = Connection.ExecuteScalar<int>("SELECT Version from SchemaInfo ORDER BY Version DESC LIMIT 1", Array.Empty<object>());
			}
			catch (Exception)
			{
				flag = true;
			}
			if (flag)
			{
				Connection.CreateTable<SchemaInfo>();
				result = 1;
			}
			return result;
		}

		protected virtual IObservable<byte[]> BeforeWriteToDiskFilter(byte[] data, IScheduler scheduler)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<byte[]>("SqlitePersistentBlobCache");
			}
			return Observable.Return(data, scheduler);
		}

		protected virtual IObservable<byte[]> AfterReadFromDiskFilter(byte[] data, IScheduler scheduler)
		{
			if (_disposed)
			{
				return ExceptionHelper.ObservableThrowObjectDisposedException<byte[]>("SqlitePersistentBlobCache");
			}
			return Observable.Return(data, scheduler);
		}

		private byte[] SerializeObject<T>(T value)
		{
			JsonSerializer serializer = GetSerializer();
			using MemoryStream memoryStream = new MemoryStream();
			using BsonDataWriter jsonWriter = new BsonDataWriter(memoryStream);
			serializer.Serialize(jsonWriter, new ObjectWrapper<T>
			{
				Value = value
			});
			return memoryStream.ToArray();
		}

		private IObservable<T> DeserializeObject<T>(byte[] data)
		{
			JsonSerializer serializer = GetSerializer();
			using BsonDataReader bsonDataReader = new BsonDataReader(new MemoryStream(data));
			DateTimeKind? forcedDateTimeKind = BlobCache.ForcedDateTimeKind;
			if (forcedDateTimeKind.HasValue)
			{
				bsonDataReader.DateTimeKindHandling = forcedDateTimeKind.Value;
			}
			try
			{
				try
				{
					return Observable.Return(serializer.Deserialize<ObjectWrapper<T>>(bsonDataReader).Value);
				}
				catch (Exception exception)
				{
					this.Log().Warn(exception, "Failed to deserialize data as boxed, we may be migrating from an old Akavache");
				}
				return Observable.Return(serializer.Deserialize<T>(bsonDataReader));
			}
			catch (Exception exception2)
			{
				return Observable.Throw<T>(exception2);
			}
		}

		private JsonSerializer GetSerializer()
		{
			JsonSerializerSettings jsonSerializerSettings = Locator.Current.GetService<JsonSerializerSettings>() ?? new JsonSerializerSettings();
			lock (jsonSerializerSettings)
			{
				_jsonDateTimeContractResolver.ExistingContractResolver = jsonSerializerSettings.ContractResolver;
				jsonSerializerSettings.ContractResolver = _jsonDateTimeContractResolver;
				JsonSerializer result = JsonSerializer.Create(jsonSerializerSettings);
				jsonSerializerSettings.ContractResolver = _jsonDateTimeContractResolver.ExistingContractResolver;
				return result;
			}
		}
	}
	[GeneratedCode("Xamarin.Android.Build.Tasks", "1.0.0.0")]
	public class Resource
	{
		public class Attribute
		{
			static Attribute()
			{
				ResourceIdManager.UpdateIdValues();
			}

			private Attribute()
			{
			}
		}

		static Resource()
		{
			ResourceIdManager.UpdateIdValues();
		}
	}
}
namespace Akavache.Sqlite3.Internal
{
	public sealed class AsyncLock : IDisposable
	{
		private sealed class Releaser : IDisposable
		{
			private readonly AsyncLock _toRelease;

			internal Releaser(AsyncLock toRelease)
			{
				_toRelease = toRelease;
			}

			public void Dispose()
			{
				_toRelease._semaphore.Release();
			}
		}

		private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

		private readonly Task<IDisposable?> _releaser;

		public AsyncLock()
		{
			_releaser = Task.FromResult((IDisposable)new Releaser(this));
		}

		public Task<IDisposable?> LockAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			Task task = _semaphore.WaitAsync(cancellationToken);
			if (task.IsCompleted && !task.IsFaulted && !task.IsCanceled)
			{
				return _releaser;
			}
			return task.ContinueWith((Task task2, object state) => (!task2.IsCanceled) ? ((IDisposable)state) : null, _releaser.Result, cancellationToken, TaskContinuationOptions.ExecuteSynchronously, TaskScheduler.Default);
		}

		public void Dispose()
		{
			_semaphore?.Dispose();
			_releaser?.Dispose();
		}
	}
	public class SQLiteException : Exception
	{
		public SQLite3.Result Result { get; private set; }

		public SQLiteException(SQLite3.Result r, string message)
			: base(message)
		{
			Result = r;
		}

		public static SQLiteException New(SQLite3.Result r, string message)
		{
			return new SQLiteException(r, message);
		}
	}
	public class NotNullConstraintViolationException : SQLiteException
	{
		public IEnumerable<TableMapping.Column> Columns { get; protected set; }

		protected NotNullConstraintViolationException(SQLite3.Result r, string message)
			: this(r, message, null, null)
		{
		}

		protected NotNullConstraintViolationException(SQLite3.Result r, string message, TableMapping mapping, object obj)
			: base(r, message)
		{
			if (mapping != null && obj != null)
			{
				Columns = mapping.Columns.Where((TableMapping.Column c) => !c.IsNullable && c.GetValue(obj) == null);
			}
		}

		public new static NotNullConstraintViolationException New(SQLite3.Result r, string message)
		{
			return new NotNullConstraintViolationException(r, message);
		}

		public static NotNullConstraintViolationException New(SQLite3.Result r, string message, TableMapping mapping, object obj)
		{
			return new NotNullConstraintViolationException(r, message, mapping, obj);
		}

		public static NotNullConstraintViolationException New(SQLiteException exception, TableMapping mapping, object obj)
		{
			return new NotNullConstraintViolationException(exception.Result, exception.Message, mapping, obj);
		}
	}
	[Flags]
	public enum SQLiteOpenFlags
	{
		ReadOnly = 1,
		ReadWrite = 2,
		Create = 4,
		NoMutex = 0x8000,
		FullMutex = 0x10000,
		SharedCache = 0x20000,
		PrivateCache = 0x40000,
		ProtectionComplete = 0x100000,
		ProtectionCompleteUnlessOpen = 0x200000,
		ProtectionCompleteUntilFirstUserAuthentication = 0x300000,
		ProtectionNone = 0x400000
	}
	[Flags]
	public enum CreateFlags
	{
		None = 0,
		ImplicitPK = 1,
		ImplicitIndex = 2,
		AllImplicit = 3,
		AutoIncPK = 4
	}
	public class SQLiteConnection : IDisposable
	{
		private struct IndexedColumn
		{
			public int Order;

			public string ColumnName;
		}

		private struct IndexInfo
		{
			public string IndexName;

			public string TableName;

			public bool Unique;

			public List<IndexedColumn> Columns;
		}

		public class ColumnInfo
		{
			[Column("name")]
			public string Name { get; set; }

			public int notnull { get; set; }

			public override string ToString()
			{
				return Name;
			}
		}

		private static bool _preserveDuringLinkMagic;

		private bool _open;

		private TimeSpan _busyTimeout;

		private Dictionary<string, TableMapping> _mappings;

		private Dictionary<string, TableMapping> _tables;

		private Stopwatch _sw;

		private long _elapsedMilliseconds;

		private int _transactionDepth;

		private Random _rand = new Random();

		internal static readonly sqlite3 NullHandle;

		public sqlite3 Handle { get; private set; }

		public string DatabasePath { get; private set; }

		public bool TimeExecution { get; set; }

		public bool Trace { get; set; }

		public bool StoreDateTimeAsTicks { get; private set; }

		public TimeSpan BusyTimeout
		{
			get
			{
				return _busyTimeout;
			}
			set
			{
				_busyTimeout = value;
				if (Handle != NullHandle)
				{
					SQLite3.BusyTimeout(Handle, (int)_busyTimeout.TotalMilliseconds);
				}
			}
		}

		public IEnumerable<TableMapping> TableMappings
		{
			get
			{
				if (_tables == null)
				{
					return Enumerable.Empty<TableMapping>();
				}
				return _tables.Values;
			}
		}

		public bool IsInTransaction => _transactionDepth > 0;

		public event EventHandler<NotifyTableChangedEventArgs> TableChanged;

		public SQLiteConnection(string databasePath, bool storeDateTimeAsTicks = false)
			: this(databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create, storeDateTimeAsTicks)
		{
		}

		public SQLiteConnection(string databasePath, SQLiteOpenFlags openFlags, bool storeDateTimeAsTicks = false)
		{
			if (string.IsNullOrEmpty(databasePath))
			{
				throw new ArgumentException("Must be specified", "databasePath");
			}
			DatabasePath = databasePath;
			sqlite3 db;
			SQLite3.Result result = SQLite3.Open(databasePath, out db, (int)openFlags, IntPtr.Zero);
			Handle = db;
			if (result != SQLite3.Result.OK)
			{
				throw SQLiteException.New(result, $"Could not open database file: {DatabasePath} ({result})");
			}
			_open = true;
			StoreDateTimeAsTicks = storeDateTimeAsTicks;
			BusyTimeout = TimeSpan.FromSeconds(0.1);
		}

		static SQLiteConnection()
		{
			if (_preserveDuringLinkMagic)
			{
				new ColumnInfo().Name = "magic";
			}
		}

		public TableMapping GetMapping(Type type, CreateFlags createFlags = CreateFlags.None)
		{
			if (_mappings == null)
			{
				_mappings = new Dictionary<string, TableMapping>();
			}
			if (!_mappings.TryGetValue(type.FullName, out var value))
			{
				value = new TableMapping(type, createFlags);
				_mappings[type.FullName] = value;
			}
			return value;
		}

		public TableMapping GetMapping<T>()
		{
			return GetMapping(typeof(T));
		}

		public int DropTable<T>()
		{
			TableMapping mapping = GetMapping(typeof(T));
			string query = $"drop table if exists \"{mapping.TableName}\"";
			return Execute(query);
		}

		public int CreateTable<T>(CreateFlags createFlags = CreateFlags.None)
		{
			return CreateTable(typeof(T), createFlags);
		}

		public int CreateTable(Type ty, CreateFlags createFlags = CreateFlags.None)
		{
			if (_tables == null)
			{
				_tables = new Dictionary<string, TableMapping>();
			}
			if (!_tables.TryGetValue(ty.FullName, out var value))
			{
				value = GetMapping(ty, createFlags);
				_tables.Add(ty.FullName, value);
			}
			string text = "create table if not exists \"" + value.TableName + "\"(\n";
			IEnumerable<string> source = value.Columns.Select((TableMapping.Column p) => Orm.SqlDecl(p, StoreDateTimeAsTicks));
			string text2 = string.Join(",\n", source.ToArray());
			text += text2;
			text += ")";
			int num = Execute(text);
			if (num == 0)
			{
				MigrateTable(value);
			}
			Dictionary<string, IndexInfo> dictionary = new Dictionary<string, IndexInfo>();
			TableMapping.Column[] columns = value.Columns;
			foreach (TableMapping.Column column in columns)
			{
				foreach (IndexedAttribute index in column.Indices)
				{
					string text3 = index.Name ?? (value.TableName + "_" + column.Name);
					if (!dictionary.TryGetValue(text3, out var value2))
					{
						value2 = new IndexInfo
						{
							IndexName = text3,
							TableName = value.TableName,
							Unique = index.Unique,
							Columns = new List<IndexedColumn>()
						};
						dictionary.Add(text3, value2);
					}
					if (index.Unique != value2.Unique)
					{
						throw new Exception("All the columns in an index must have the same value for their Unique property");
					}
					value2.Columns.Add(new IndexedColumn
					{
						Order = index.Order,
						ColumnName = column.Name
					});
				}
			}
			foreach (string key in dictionary.Keys)
			{
				IndexInfo indexInfo = dictionary[key];
				string[] columnNames = (from i in indexInfo.Columns
					orderby i.Order
					select i.ColumnName).ToArray();
				num += CreateIndex(key, indexInfo.TableName, columnNames, indexInfo.Unique);
			}
			return num;
		}

		public int CreateIndex(string indexName, string tableName, string[] columnNames, bool unique = false)
		{
			string query = string.Format("create {2} index if not exists \"{3}\" on \"{0}\"(\"{1}\")", tableName, string.Join("\", \"", columnNames), unique ? "unique" : "", indexName);
			return Execute(query);
		}

		public int CreateIndex(string indexName, string tableName, string columnName, bool unique = false)
		{
			return CreateIndex(indexName, tableName, new string[1] { columnName }, unique);
		}

		public int CreateIndex(string tableName, string columnName, bool unique = false)
		{
			return CreateIndex(tableName + "_" + columnName, tableName, columnName, unique);
		}

		public int CreateIndex(string tableName, string[] columnNames, bool unique = false)
		{
			return CreateIndex(tableName + "_" + string.Join("_", columnNames), tableName, columnNames, unique);
		}

		public void CreateIndex<T>(Expression<Func<T, object>> property, bool unique = false)
		{
			MemberExpression memberExpression = ((property.Body.NodeType != ExpressionType.Convert) ? (property.Body as MemberExpression) : (((UnaryExpression)property.Body).Operand as MemberExpression));
			string name = ((memberExpression.Member as PropertyInfo) ?? throw new ArgumentException("The lambda expression 'property' should point to a valid Property")).Name;
			TableMapping mapping = GetMapping<T>();
			string name2 = mapping.FindColumnWithPropertyName(name).Name;
			CreateIndex(mapping.TableName, name2, unique);
		}

		public List<ColumnInfo> GetTableInfo(string tableName)
		{
			string query = "pragma table_info(\"" + tableName + "\")";
			return Query<ColumnInfo>(query, Array.Empty<object>());
		}

		private void MigrateTable(TableMapping map)
		{
			List<ColumnInfo> tableInfo = GetTableInfo(map.TableName);
			List<TableMapping.Column> list = new List<TableMapping.Column>();
			TableMapping.Column[] columns = map.Columns;
			foreach (TableMapping.Column column in columns)
			{
				bool flag = false;
				foreach (ColumnInfo item in tableInfo)
				{
					flag = string.Compare(column.Name, item.Name, StringComparison.OrdinalIgnoreCase) == 0;
					if (flag)
					{
						break;
					}
				}
				if (!flag)
				{
					list.Add(column);
				}
			}
			foreach (TableMapping.Column item2 in list)
			{
				string query = "alter table \"" + map.TableName + "\" add column " + Orm.SqlDecl(item2, StoreDateTimeAsTicks);
				Execute(query);
			}
		}

		protected virtual SQLiteCommand NewCommand()
		{
			return new SQLiteCommand(this);
		}

		public SQLiteCommand CreateCommand(string cmdText, params object[] ps)
		{
			if (!_open)
			{
				throw SQLiteException.New(SQLite3.Result.Error, "Cannot create commands from unopened database");
			}
			SQLiteCommand sQLiteCommand = NewCommand();
			sQLiteCommand.CommandText = cmdText;
			foreach (object val in ps)
			{
				sQLiteCommand.Bind(val);
			}
			return sQLiteCommand;
		}

		public int Execute(string query, params object[] args)
		{
			SQLiteCommand sQLiteCommand = CreateCommand(query, args);
			if (TimeExecution)
			{
				if (_sw == null)
				{
					_sw = new Stopwatch();
				}
				_sw.Reset();
				_sw.Start();
			}
			int result = sQLiteCommand.ExecuteNonQuery();
			if (TimeExecution)
			{
				_sw.Stop();
				_elapsedMilliseconds += _sw.ElapsedMilliseconds;
			}
			return result;
		}

		public T ExecuteScalar<T>(string query, params object[] args)
		{
			SQLiteCommand sQLiteCommand = CreateCommand(query, args);
			if (TimeExecution)
			{
				if (_sw == null)
				{
					_sw = new Stopwatch();
				}
				_sw.Reset();
				_sw.Start();
			}
			T result = sQLiteCommand.ExecuteScalar<T>();
			if (TimeExecution)
			{
				_sw.Stop();
				_elapsedMilliseconds += _sw.ElapsedMilliseconds;
			}
			return result;
		}

		public List<T> Query<T>(string query, params object[] args) where T : new()
		{
			return CreateCommand(query, args).ExecuteQuery<T>();
		}

		public IEnumerable<T> DeferredQuery<T>(string query, params object[] args) where T : new()
		{
			return CreateCommand(query, args).ExecuteDeferredQuery<T>();
		}

		public List<object> Query(TableMapping map, string query, params object[] args)
		{
			return CreateCommand(query, args).ExecuteQuery<object>(map);
		}

		public IEnumerable<object> DeferredQuery(TableMapping map, string query, params object[] args)
		{
			return CreateCommand(query, args).ExecuteDeferredQuery<object>(map);
		}

		public TableQuery<T> Table<T>() where T : new()
		{
			return new TableQuery<T>(this);
		}

		public T Get<T>(object pk) where T : new()
		{
			TableMapping mapping = GetMapping(typeof(T));
			return Query<T>(mapping.GetByPrimaryKeySql, new object[1] { pk }).First();
		}

		public T Get<T>(Expression<Func<T, bool>> predicate) where T : new()
		{
			return Table<T>().Where(predicate).First();
		}

		public T Find<T>(object pk) where T : new()
		{
			TableMapping mapping = GetMapping(typeof(T));
			return Query<T>(mapping.GetByPrimaryKeySql, new object[1] { pk }).FirstOrDefault();
		}

		public object Find(object pk, TableMapping map)
		{
			return Query(map, map.GetByPrimaryKeySql, pk).FirstOrDefault();
		}

		public T Find<T>(Expression<Func<T, bool>> predicate) where T : new()
		{
			return Table<T>().Where(predicate).FirstOrDefault();
		}

		public void BeginTransaction()
		{
			if (Interlocked.CompareExchange(ref _transactionDepth, 1, 0) == 0)
			{
				try
				{
					Execute("begin transaction");
					return;
				}
				catch (Exception ex)
				{
					if (ex is SQLiteException ex2)
					{
						switch (ex2.Result)
						{
						case SQLite3.Result.Busy:
						case SQLite3.Result.NoMem:
						case SQLite3.Result.Interrupt:
						case SQLite3.Result.IOError:
						case SQLite3.Result.Full:
							RollbackTo(null, noThrow: true);
							break;
						}
					}
					else
					{
						Interlocked.Decrement(ref _transactionDepth);
					}
					throw;
				}
			}
			throw new InvalidOperationException("Cannot begin a transaction while already in a transaction.");
		}

		public string SaveTransactionPoint()
		{
			int num = Interlocked.Increment(ref _transactionDepth) - 1;
			string text = "S" + _rand.Next(32767) + "D" + num;
			try
			{
				Execute("savepoint " + text);
				return text;
			}
			catch (Exception ex)
			{
				if (ex is SQLiteException ex2)
				{
					switch (ex2.Result)
					{
					case SQLite3.Result.Busy:
					case SQLite3.Result.NoMem:
					case SQLite3.Result.Interrupt:
					case SQLite3.Result.IOError:
					case SQLite3.Result.Full:
						RollbackTo(null, noThrow: true);
						break;
					}
				}
				else
				{
					Interlocked.Decrement(ref _transactionDepth);
				}
				throw;
			}
		}

		public void Rollback()
		{
			RollbackTo(null, noThrow: false);
		}

		public void RollbackTo(string savepoint)
		{
			RollbackTo(savepoint, noThrow: false);
		}

		private void RollbackTo(string savePoint, bool noThrow)
		{
			try
			{
				if (string.IsNullOrEmpty(savePoint))
				{
					if (Interlocked.Exchange(ref _transactionDepth, 0) > 0)
					{
						Execute("rollback");
					}
				}
				else
				{
					DoSavePointExecute(savePoint, "rollback to ");
				}
			}
			catch (SQLiteException)
			{
				if (!noThrow)
				{
					throw;
				}
			}
		}

		public void Release(string savepoint)
		{
			DoSavePointExecute(savepoint, "release ");
		}

		private void DoSavePointExecute(string savepoint, string cmd)
		{
			int num = savepoint.IndexOf('D');
			if (num >= 2 && savepoint.Length > num + 1 && int.TryParse(savepoint.Substring(num + 1), out var result) && 0 <= result && result < _transactionDepth)
			{
				Volatile.Write(ref _transactionDepth, result);
				Execute(cmd + savepoint);
				return;
			}
			throw new ArgumentException("savePoint is not valid, and should be the result of a call to SaveTransactionPoint.", "savePoint");
		}

		public void Commit()
		{
			if (Interlocked.Exchange(ref _transactionDepth, 0) != 0)
			{
				Execute("commit");
			}
		}

		public void RunInTransaction(Action action)
		{
			try
			{
				string savepoint = SaveTransactionPoint();
				action();
				Release(savepoint);
			}
			catch (Exception)
			{
				Rollback();
				throw;
			}
		}

		public int InsertAll(IEnumerable objects)
		{
			int c = 0;
			RunInTransaction(delegate
			{
				foreach (object @object in objects)
				{
					c += Insert(@object);
				}
			});
			return c;
		}

		public int InsertAll(IEnumerable objects, string extra)
		{
			int c = 0;
			RunInTransaction(delegate
			{
				foreach (object @object in objects)
				{
					c += Insert(@object, extra);
				}
			});
			return c;
		}

		public int InsertAll(IEnumerable objects, Type objType)
		{
			int c = 0;
			RunInTransaction(delegate
			{
				foreach (object @object in objects)
				{
					c += Insert(@object, objType);
				}
			});
			return c;
		}

		public int Insert(object obj)
		{
			if (obj == null)
			{
				return 0;
			}
			return Insert(obj, "", obj.GetType());
		}

		public int InsertOrReplace(object obj)
		{
			if (obj == null)
			{
				return 0;
			}
			return Insert(obj, "OR REPLACE", obj.GetType());
		}

		public int Insert(object obj, Type objType)
		{
			return Insert(obj, "", objType);
		}

		public int InsertOrReplace(object obj, Type objType)
		{
			return Insert(obj, "OR REPLACE", objType);
		}

		public int Insert(object obj, string extra)
		{
			if (obj == null)
			{
				return 0;
			}
			return Insert(obj, extra, obj.GetType());
		}

		public int Insert(object obj, string extra, Type objType)
		{
			if (obj == null || (object)objType == null)
			{
				return 0;
			}
			TableMapping mapping = GetMapping(objType);
			if (mapping.PK != null && mapping.PK.IsAutoGuid)
			{
				while (objType != null)
				{
					TypeInfo typeInfo = objType.GetTypeInfo();
					PropertyInfo declaredProperty = typeInfo.GetDeclaredProperty(mapping.PK.PropertyName);
					if (declaredProperty != null)
					{
						if (declaredProperty.GetValue(obj, null).Equals(Guid.Empty))
						{
							declaredProperty.SetValue(obj, Guid.NewGuid(), null);
						}
						break;
					}
					objType = typeInfo.BaseType;
				}
			}
			TableMapping.Column[] array = ((string.Compare(extra, "OR REPLACE", StringComparison.OrdinalIgnoreCase) == 0) ? mapping.InsertOrReplaceColumns : mapping.InsertColumns);
			object[] array2 = new object[array.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = array[i].GetValue(obj);
			}
			PreparedSqlLiteInsertCommand insertCommand = mapping.GetInsertCommand(this, extra);
			int num;
			try
			{
				num = insertCommand.ExecuteNonQuery(array2);
			}
			catch (SQLiteException ex)
			{
				if (SQLite3.ExtendedErrCode(Handle) == SQLite3.ExtendedResult.ConstraintNotNull)
				{
					throw NotNullConstraintViolationException.New(ex.Result, ex.Message, mapping, obj);
				}
				throw;
			}
			if (mapping.HasAutoIncPK)
			{
				long id = SQLite3.LastInsertRowid(Handle);
				mapping.SetAutoIncPK(obj, id);
			}
			if (num > 0)
			{
				OnTableChanged(mapping, NotifyTableChangedAction.Insert);
			}
			return num;
		}

		public int Update(object obj)
		{
			if (obj == null)
			{
				return 0;
			}
			return Update(obj, obj.GetType());
		}

		public int Update(object obj, Type objType)
		{
			int num = 0;
			if (obj == null || (object)objType == null)
			{
				return 0;
			}
			TableMapping mapping = GetMapping(objType);
			TableMapping.Column pk = mapping.PK;
			if (pk == null)
			{
				throw new NotSupportedException("Cannot update " + mapping.TableName + ": it has no PK");
			}
			IEnumerable<TableMapping.Column> source = mapping.Columns.Where((TableMapping.Column p) => p != pk);
			List<object> list = new List<object>(source.Select((TableMapping.Column c) => c.GetValue(obj)));
			list.Add(pk.GetValue(obj));
			string query = string.Format("update \"{0}\" set {1} where {2} = ? ", mapping.TableName, string.Join(",", source.Select((TableMapping.Column c) => "\"" + c.Name + "\" = ? ").ToArray()), pk.Name);
			try
			{
				num = Execute(query, list.ToArray());
			}
			catch (SQLiteException ex)
			{
				if (ex.Result == SQLite3.Result.Constraint && SQLite3.ExtendedErrCode(Handle) == SQLite3.ExtendedResult.ConstraintNotNull)
				{
					throw NotNullConstraintViolationException.New(ex, mapping, obj);
				}
				throw ex;
			}
			if (num > 0)
			{
				OnTableChanged(mapping, NotifyTableChangedAction.Update);
			}
			return num;
		}

		public int UpdateAll(IEnumerable objects)
		{
			int c = 0;
			RunInTransaction(delegate
			{
				foreach (object @object in objects)
				{
					c += Update(@object);
				}
			});
			return c;
		}

		public int Delete(object objectToDelete)
		{
			TableMapping mapping = GetMapping(objectToDelete.GetType());
			TableMapping.Column pK = mapping.PK;
			if (pK == null)
			{
				throw new NotSupportedException("Cannot delete " + mapping.TableName + ": it has no PK");
			}
			string query = $"delete from \"{mapping.TableName}\" where \"{pK.Name}\" = ?";
			int num = Execute(query, pK.GetValue(objectToDelete));
			if (num > 0)
			{
				OnTableChanged(mapping, NotifyTableChangedAction.Delete);
			}
			return num;
		}

		public int Delete<T>(object primaryKey)
		{
			TableMapping mapping = GetMapping(typeof(T));
			TableMapping.Column pK = mapping.PK;
			if (pK == null)
			{
				throw new NotSupportedException("Cannot delete " + mapping.TableName + ": it has no PK");
			}
			string query = $"delete from \"{mapping.TableName}\" where \"{pK.Name}\" = ?";
			int num = Execute(query, primaryKey);
			if (num > 0)
			{
				OnTableChanged(mapping, NotifyTableChangedAction.Delete);
			}
			return num;
		}

		public int DeleteAll<T>()
		{
			TableMapping mapping = GetMapping(typeof(T));
			string query = $"delete from \"{mapping.TableName}\"";
			int num = Execute(query);
			if (num > 0)
			{
				OnTableChanged(mapping, NotifyTableChangedAction.Delete);
			}
			return num;
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			Close();
		}

		public void Close()
		{
			if (!_open || Handle == NullHandle)
			{
				return;
			}
			try
			{
				if (_mappings != null)
				{
					foreach (TableMapping value in _mappings.Values)
					{
						value.Dispose();
					}
				}
				SQLite3.Result result = SQLite3.Close(Handle);
				if (result != SQLite3.Result.OK)
				{
					string errmsg = SQLite3.GetErrmsg(Handle);
					throw SQLiteException.New(result, errmsg);
				}
			}
			finally
			{
				Handle = NullHandle;
				_open = false;
			}
		}

		private void OnTableChanged(TableMapping table, NotifyTableChangedAction action)
		{
			this.TableChanged?.Invoke(this, new NotifyTableChangedEventArgs(table, action));
		}
	}
	public class NotifyTableChangedEventArgs : EventArgs
	{
		public TableMapping Table { get; private set; }

		public NotifyTableChangedAction Action { get; private set; }

		public NotifyTableChangedEventArgs(TableMapping table, NotifyTableChangedAction action)
		{
			Table = table;
			Action = action;
		}
	}
	public enum NotifyTableChangedAction
	{
		Insert,
		Update,
		Delete
	}
	internal class SQLiteConnectionString
	{
		public string ConnectionString { get; private set; }

		public string DatabasePath { get; private set; }

		public bool StoreDateTimeAsTicks { get; private set; }

		public SQLiteConnectionString(string databasePath, bool storeDateTimeAsTicks)
		{
			ConnectionString = databasePath;
			StoreDateTimeAsTicks = storeDateTimeAsTicks;
			DatabasePath = databasePath;
		}
	}
	[AttributeUsage(AttributeTargets.Class)]
	public class TableAttribute : Attribute
	{
		public string Name { get; set; }

		public TableAttribute(string name)
		{
			Name = name;
		}
	}
	[AttributeUsage(AttributeTargets.Property)]
	public class ColumnAttribute : Attribute
	{
		public string Name { get; set; }

		public ColumnAttribute(string name)
		{
			Name = name;
		}
	}
	[AttributeUsage(AttributeTargets.Property)]
	public class PrimaryKeyAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Property)]
	public class AutoIncrementAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Property)]
	public class IndexedAttribute : Attribute
	{
		public string Name { get; set; }

		public int Order { get; set; }

		public virtual bool Unique { get; set; }

		public IndexedAttribute()
		{
		}

		public IndexedAttribute(string name, int order)
		{
			Name = name;
			Order = order;
		}
	}
	[AttributeUsage(AttributeTargets.Property)]
	public class IgnoreAttribute : Attribute
	{
	}
	[AttributeUsage(AttributeTargets.Property)]
	public class UniqueAttribute : IndexedAttribute
	{
		public override bool Unique
		{
			get
			{
				return true;
			}
			set
			{
			}
		}
	}
	[AttributeUsage(AttributeTargets.Property)]
	public class MaxLengthAttribute : Attribute
	{
		public int Value { get; private set; }

		public MaxLengthAttribute(int length)
		{
			Value = length;
		}
	}
	[AttributeUsage(AttributeTargets.Property)]
	public class CollationAttribute : Attribute
	{
		public string Value { get; private set; }

		public CollationAttribute(string collation)
		{
			Value = collation;
		}
	}
	[AttributeUsage(AttributeTargets.Property)]
	public class NotNullAttribute : Attribute
	{
	}
	public class TableMapping
	{
		public class Column
		{
			private PropertyInfo _prop;

			public string Name { get; private set; }

			public string PropertyName => _prop.Name;

			public Type ColumnType { get; private set; }

			public string Collation { get; private set; }

			public bool IsAutoInc { get; private set; }

			public bool IsAutoGuid { get; private set; }

			public bool IsPK { get; private set; }

			public IEnumerable<IndexedAttribute> Indices { get; set; }

			public bool IsNullable { get; private set; }

			public int? MaxStringLength { get; private set; }

			public Column(PropertyInfo prop, CreateFlags createFlags = CreateFlags.None)
			{
				ColumnAttribute columnAttribute = (ColumnAttribute)prop.GetCustomAttributes(typeof(ColumnAttribute), inherit: true).FirstOrDefault();
				_prop = prop;
				Name = ((columnAttribute == null) ? prop.Name : columnAttribute.Name);
				ColumnType = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
				Collation = Orm.Collation(prop);
				IsPK = Orm.IsPK(prop) || ((createFlags & CreateFlags.ImplicitPK) == CreateFlags.ImplicitPK && string.Compare(prop.Name, "Id", StringComparison.OrdinalIgnoreCase) == 0);
				bool flag = Orm.IsAutoInc(prop) || (IsPK && (createFlags & CreateFlags.AutoIncPK) == CreateFlags.AutoIncPK);
				IsAutoGuid = flag && ColumnType == typeof(Guid);
				IsAutoInc = flag && !IsAutoGuid;
				Indices = Orm.GetIndices(prop);
				if (!Indices.Any() && !IsPK && (createFlags & CreateFlags.ImplicitIndex) == CreateFlags.ImplicitIndex && Name.EndsWith("Id", StringComparison.OrdinalIgnoreCase))
				{
					Indices = new IndexedAttribute[1]
					{
						new IndexedAttribute()
					};
				}
				IsNullable = !IsPK && !Orm.IsMarkedNotNull(prop);
				MaxStringLength = Orm.MaxStringLength(prop);
			}

			public void SetValue(object obj, object val)
			{
				_prop.SetValue(obj, val, null);
			}

			public object GetValue(object obj)
			{
				return _prop.GetValue(obj, null);
			}
		}

		private Column _autoPk;

		private Column[] _insertColumns;

		private Column[] _insertOrReplaceColumns;

		private PreparedSqlLiteInsertCommand _insertCommand;

		private string _insertCommandExtra;

		public Type MappedType { get; private set; }

		public string TableName { get; private set; }

		public Column[] Columns { get; private set; }

		public Column PK { get; private set; }

		public string GetByPrimaryKeySql { get; private set; }

		public bool HasAutoIncPK { get; private set; }

		public Column[] InsertColumns
		{
			get
			{
				if (_insertColumns == null)
				{
					_insertColumns = Columns.Where((Column c) => !c.IsAutoInc).ToArray();
				}
				return _insertColumns;
			}
		}

		public Column[] InsertOrReplaceColumns
		{
			get
			{
				if (_insertOrReplaceColumns == null)
				{
					_insertOrReplaceColumns = Columns.ToArray();
				}
				return _insertOrReplaceColumns;
			}
		}

		public TableMapping(Type type, CreateFlags createFlags = CreateFlags.None)
		{
			MappedType = type;
			TableAttribute tableAttribute = (TableAttribute)type.GetTypeInfo().GetCustomAttribute(typeof(TableAttribute), inherit: true);
			TableName = ((tableAttribute != null) ? tableAttribute.Name : MappedType.Name);
			IEnumerable<PropertyInfo> enumerable = from p in MappedType.GetRuntimeProperties()
				where (p.GetMethod != null && p.GetMethod.IsPublic) || (p.SetMethod != null && p.SetMethod.IsPublic) || (p.GetMethod != null && p.GetMethod.IsStatic) || (p.SetMethod != null && p.SetMethod.IsStatic)
				select p;
			List<Column> list = new List<Column>();
			foreach (PropertyInfo item in enumerable)
			{
				bool flag = item.GetCustomAttributes(typeof(IgnoreAttribute), inherit: true).Count() > 0;
				if (item.CanWrite && !flag)
				{
					list.Add(new Column(item, createFlags));
				}
			}
			Columns = list.ToArray();
			Column[] columns = Columns;
			foreach (Column column in columns)
			{
				if (column.IsAutoInc && column.IsPK)
				{
					_autoPk = column;
				}
				if (column.IsPK)
				{
					PK = column;
				}
			}
			HasAutoIncPK = _autoPk != null;
			if (PK != null)
			{
				GetByPrimaryKeySql = $"select * from \"{TableName}\" where \"{PK.Name}\" = ?";
			}
			else
			{
				GetByPrimaryKeySql = $"select * from \"{TableName}\" limit 1";
			}
		}

		public void SetAutoIncPK(object obj, long id)
		{
			if (_autoPk != null)
			{
				_autoPk.SetValue(obj, Convert.ChangeType(id, _autoPk.ColumnType, null));
			}
		}

		public Column FindColumnWithPropertyName(string propertyName)
		{
			return Columns.FirstOrDefault((Column c) => c.PropertyName == propertyName);
		}

		public Column FindColumn(string columnName)
		{
			return Columns.FirstOrDefault((Column c) => c.Name == columnName);
		}

		public PreparedSqlLiteInsertCommand GetInsertCommand(SQLiteConnection conn, string extra)
		{
			if (_insertCommand == null)
			{
				_insertCommand = CreateInsertCommand(conn, extra);
				_insertCommandExtra = extra;
			}
			else if (_insertCommandExtra != extra)
			{
				_insertCommand.Dispose();
				_insertCommand = CreateInsertCommand(conn, extra);
				_insertCommandExtra = extra;
			}
			return _insertCommand;
		}

		private PreparedSqlLiteInsertCommand CreateInsertCommand(SQLiteConnection conn, string extra)
		{
			Column[] source = InsertColumns;
			string commandText;
			if (!source.Any() && Columns.Count() == 1 && Columns[0].IsAutoInc)
			{
				commandText = string.Format("insert {1} into \"{0}\" default values", TableName, extra);
			}
			else
			{
				if (string.Compare(extra, "OR REPLACE", StringComparison.OrdinalIgnoreCase) == 0)
				{
					source = InsertOrReplaceColumns;
				}
				commandText = string.Format("insert {3} into \"{0}\"({1}) values ({2})", TableName, string.Join(",", source.Select((Column c) => "\"" + c.Name + "\"").ToArray()), string.Join(",", source.Select((Column c) => "?").ToArray()), extra);
			}
			return new PreparedSqlLiteInsertCommand(conn)
			{
				CommandText = commandText
			};
		}

		protected internal void Dispose()
		{
			if (_insertCommand != null)
			{
				_insertCommand.Dispose();
				_insertCommand = null;
			}
		}
	}
	public static class Orm
	{
		public const int DefaultMaxStringLength = 140;

		public const string ImplicitPkName = "Id";

		public const string ImplicitIndexSuffix = "Id";

		public static string SqlDecl(TableMapping.Column p, bool storeDateTimeAsTicks)
		{
			string text = "\"" + p.Name + "\" " + SqlType(p, storeDateTimeAsTicks) + " ";
			if (p.IsPK)
			{
				text += "primary key ";
			}
			if (p.IsAutoInc)
			{
				text += "autoincrement ";
			}
			if (!p.IsNullable)
			{
				text += "not null ";
			}
			if (!string.IsNullOrEmpty(p.Collation))
			{
				text = text + "collate " + p.Collation + " ";
			}
			return text;
		}

		public static string SqlType(TableMapping.Column p, bool storeDateTimeAsTicks)
		{
			Type columnType = p.ColumnType;
			if (columnType == typeof(bool) || columnType == typeof(byte) || columnType == typeof(ushort) || columnType == typeof(sbyte) || columnType == typeof(short) || columnType == typeof(int))
			{
				return "integer";
			}
			if (columnType == typeof(uint) || columnType == typeof(long))
			{
				return "bigint";
			}
			if (columnType == typeof(float) || columnType == typeof(double) || columnType == typeof(decimal))
			{
				return "float";
			}
			if (columnType == typeof(string))
			{
				int? maxStringLength = p.MaxStringLength;
				if (maxStringLength.HasValue)
				{
					return "varchar(" + maxStringLength.Value + ")";
				}
				return "varchar";
			}
			if (columnType == typeof(TimeSpan))
			{
				return "bigint";
			}
			if (columnType == typeof(DateTime))
			{
				if (!storeDateTimeAsTicks)
				{
					return "datetime";
				}
				return "bigint";
			}
			if (columnType == typeof(DateTimeOffset))
			{
				return "bigint";
			}
			if (columnType.GetTypeInfo().IsEnum)
			{
				return "integer";
			}
			if (columnType == typeof(byte[]))
			{
				return "blob";
			}
			if (columnType == typeof(Guid))
			{
				return "varchar(36)";
			}
			throw new NotSupportedException("Don't know about " + columnType);
		}

		public static bool IsPK(MemberInfo p)
		{
			return p.GetCustomAttributes(typeof(PrimaryKeyAttribute), inherit: true).Count() > 0;
		}

		public static string Collation(MemberInfo p)
		{
			object[] customAttributes = p.GetCustomAttributes(typeof(CollationAttribute), inherit: true);
			if (customAttributes.Count() > 0)
			{
				return ((CollationAttribute)customAttributes.First()).Value;
			}
			return string.Empty;
		}

		public static bool IsAutoInc(MemberInfo p)
		{
			return p.GetCustomAttributes(typeof(AutoIncrementAttribute), inherit: true).Count() > 0;
		}

		public static IEnumerable<IndexedAttribute> GetIndices(MemberInfo p)
		{
			return p.GetCustomAttributes(typeof(IndexedAttribute), inherit: true).Cast<IndexedAttribute>();
		}

		public static int? MaxStringLength(PropertyInfo p)
		{
			object[] customAttributes = p.GetCustomAttributes(typeof(MaxLengthAttribute), inherit: true);
			if (customAttributes.Count() > 0)
			{
				return ((MaxLengthAttribute)customAttributes.First()).Value;
			}
			return null;
		}

		public static bool IsMarkedNotNull(MemberInfo p)
		{
			return p.GetCustomAttributes(typeof(NotNullAttribute), inherit: true).Count() > 0;
		}
	}
	public class SQLiteCommand
	{
		private class Binding
		{
			public string Name { get; set; }

			public object Value { get; set; }

			public int Index { get; set; }
		}

		private SQLiteConnection _conn;

		private List<Binding> _bindings;

		internal static IntPtr NegativePointer = new IntPtr(-1);

		public string CommandText { get; set; }

		internal SQLiteCommand(SQLiteConnection conn)
		{
			_conn = conn;
			_bindings = new List<Binding>();
			CommandText = "";
		}

		public int ExecuteNonQuery()
		{
			_ = _conn.Trace;
			SQLite3.Result result = SQLite3.Result.OK;
			sqlite3_stmt stmt = Prepare();
			result = SQLite3.Step(stmt);
			Finalize(stmt);
			switch (result)
			{
			case SQLite3.Result.Done:
				return SQLite3.Changes(_conn.Handle);
			case SQLite3.Result.Error:
			{
				string errmsg = SQLite3.GetErrmsg(_conn.Handle);
				throw SQLiteException.New(result, errmsg);
			}
			case SQLite3.Result.Constraint:
				if (SQLite3.ExtendedErrCode(_conn.Handle) == SQLite3.ExtendedResult.ConstraintNotNull)
				{
					throw NotNullConstraintViolationException.New(result, SQLite3.GetErrmsg(_conn.Handle));
				}
				break;
			}
			throw SQLiteException.New(result, result.ToString());
		}

		public IEnumerable<T> ExecuteDeferredQuery<T>()
		{
			return ExecuteDeferredQuery<T>(_conn.GetMapping(typeof(T)));
		}

		public List<T> ExecuteQuery<T>()
		{
			return ExecuteDeferredQuery<T>(_conn.GetMapping(typeof(T))).ToList();
		}

		public List<T> ExecuteQuery<T>(TableMapping map)
		{
			return ExecuteDeferredQuery<T>(map).ToList();
		}

		protected virtual void OnInstanceCreated(object obj)
		{
		}

		public IEnumerable<T> ExecuteDeferredQuery<T>(TableMapping map)
		{
			_ = _conn.Trace;
			sqlite3_stmt stmt = Prepare();
			try
			{
				TableMapping.Column[] cols = new TableMapping.Column[SQLite3.ColumnCount(stmt)];
				for (int i = 0; i < cols.Length; i++)
				{
					string columnName = SQLite3.ColumnName16(stmt, i);
					cols[i] = map.FindColumn(columnName);
				}
				while (SQLite3.Step(stmt) == SQLite3.Result.Row)
				{
					object obj = Activator.CreateInstance(map.MappedType);
					for (int j = 0; j < cols.Length; j++)
					{
						if (cols[j] != null)
						{
							SQLite3.ColType type = SQLite3.ColumnType(stmt, j);
							object val = ReadCol(stmt, j, type, cols[j].ColumnType);
							cols[j].SetValue(obj, val);
						}
					}
					OnInstanceCreated(obj);
					yield return (T)obj;
				}
			}
			finally
			{
				SQLite3.Finalize(stmt);
			}
		}

		public T ExecuteScalar<T>()
		{
			_ = _conn.Trace;
			T result = default(T);
			sqlite3_stmt stmt = Prepare();
			try
			{
				SQLite3.Result result2 = SQLite3.Step(stmt);
				switch (result2)
				{
				case SQLite3.Result.Row:
				{
					SQLite3.ColType type = SQLite3.ColumnType(stmt, 0);
					result = (T)ReadCol(stmt, 0, type, typeof(T));
					return result;
				}
				case SQLite3.Result.Done:
					break;
				default:
					throw SQLiteException.New(result2, SQLite3.GetErrmsg(_conn.Handle));
				}
			}
			finally
			{
				Finalize(stmt);
			}
			return result;
		}

		public void Bind(string name, object val)
		{
			_bindings.Add(new Binding
			{
				Name = name,
				Value = val
			});
		}

		public void Bind(object val)
		{
			Bind(null, val);
		}

		public override string ToString()
		{
			string[] array = new string[1 + _bindings.Count];
			array[0] = CommandText;
			int num = 1;
			foreach (Binding binding in _bindings)
			{
				array[num] = $"  {num - 1}: {binding.Value}";
				num++;
			}
			return string.Join(Environment.NewLine, array);
		}

		private sqlite3_stmt Prepare()
		{
			sqlite3_stmt sqlite3_stmt2 = SQLite3.Prepare2(_conn.Handle, CommandText);
			BindAll(sqlite3_stmt2);
			return sqlite3_stmt2;
		}

		private void Finalize(sqlite3_stmt stmt)
		{
			SQLite3.Finalize(stmt);
		}

		private void BindAll(sqlite3_stmt stmt)
		{
			int num = 1;
			foreach (Binding binding in _bindings)
			{
				if (binding.Name != null)
				{
					binding.Index = SQLite3.BindParameterIndex(stmt, binding.Name);
				}
				else
				{
					binding.Index = num++;
				}
				BindParameter(stmt, binding.Index, binding.Value, _conn.StoreDateTimeAsTicks);
			}
		}

		internal static void BindParameter(sqlite3_stmt stmt, int index, object value, bool storeDateTimeAsTicks)
		{
			if (value == null)
			{
				SQLite3.BindNull(stmt, index);
				return;
			}
			if (value is int)
			{
				SQLite3.BindInt(stmt, index, (int)value);
				return;
			}
			if (value is string)
			{
				SQLite3.BindText(stmt, index, (string)value, -1, NegativePointer);
				return;
			}
			if (value is byte || value is ushort || value is sbyte || value is short)
			{
				SQLite3.BindInt(stmt, index, Convert.ToInt32(value));
				return;
			}
			if (value is bool)
			{
				SQLite3.BindInt(stmt, index, ((bool)value) ? 1 : 0);
				return;
			}
			if (value is uint || value is long)
			{
				SQLite3.BindInt64(stmt, index, Convert.ToInt64(value));
				return;
			}
			if (value is float || value is double || value is decimal)
			{
				SQLite3.BindDouble(stmt, index, Convert.ToDouble(value));
				return;
			}
			if (value is TimeSpan)
			{
				SQLite3.BindInt64(stmt, index, ((TimeSpan)value).Ticks);
				return;
			}
			if (value is DateTime)
			{
				if (storeDateTimeAsTicks)
				{
					SQLite3.BindInt64(stmt, index, ((DateTime)value).Ticks);
				}
				else
				{
					SQLite3.BindText(stmt, index, ((DateTime)value).ToString("yyyy-MM-dd HH:mm:ss"), -1, NegativePointer);
				}
				return;
			}
			if (value is DateTimeOffset)
			{
				SQLite3.BindInt64(stmt, index, ((DateTimeOffset)value).UtcTicks);
				return;
			}
			if (value.GetType().GetTypeInfo().IsEnum)
			{
				SQLite3.BindInt(stmt, index, Convert.ToInt32(value));
				return;
			}
			if (value is byte[])
			{
				SQLite3.BindBlob(stmt, index, (byte[])value, ((byte[])value).Length, NegativePointer);
				return;
			}
			if (value is Guid)
			{
				SQLite3.BindText(stmt, index, ((Guid)value/*cast due to .constrained prefix*/).ToString(), 72, NegativePointer);
				return;
			}
			throw new NotSupportedException("Cannot store type: " + value.GetType());
		}

		private object ReadCol(sqlite3_stmt stmt, int index, SQLite3.ColType type, Type clrType)
		{
			if (type == SQLite3.ColType.Null)
			{
				return null;
			}
			if (clrType == typeof(string))
			{
				return SQLite3.ColumnString(stmt, index);
			}
			if (clrType == typeof(int))
			{
				return SQLite3.ColumnInt(stmt, index);
			}
			if (clrType == typeof(bool))
			{
				return SQLite3.ColumnInt(stmt, index) == 1;
			}
			if (clrType == typeof(double))
			{
				return SQLite3.ColumnDouble(stmt, index);
			}
			if (clrType == typeof(float))
			{
				return (float)SQLite3.ColumnDouble(stmt, index);
			}
			if (clrType == typeof(TimeSpan))
			{
				return new TimeSpan(SQLite3.ColumnInt64(stmt, index));
			}
			if (clrType == typeof(DateTime))
			{
				if (_conn.StoreDateTimeAsTicks)
				{
					return new DateTime(SQLite3.ColumnInt64(stmt, index));
				}
				return DateTime.Parse(SQLite3.ColumnString(stmt, index));
			}
			if (clrType == typeof(DateTimeOffset))
			{
				return new DateTimeOffset(SQLite3.ColumnInt64(stmt, index), TimeSpan.Zero);
			}
			if (clrType.GetTypeInfo().IsEnum)
			{
				return SQLite3.ColumnInt(stmt, index);
			}
			if (clrType == typeof(long))
			{
				return SQLite3.ColumnInt64(stmt, index);
			}
			if (clrType == typeof(uint))
			{
				return (uint)SQLite3.ColumnInt64(stmt, index);
			}
			if (clrType == typeof(decimal))
			{
				return (decimal)SQLite3.ColumnDouble(stmt, index);
			}
			if (clrType == typeof(byte))
			{
				return (byte)SQLite3.ColumnInt(stmt, index);
			}
			if (clrType == typeof(ushort))
			{
				return (ushort)SQLite3.ColumnInt(stmt, index);
			}
			if (clrType == typeof(short))
			{
				return (short)SQLite3.ColumnInt(stmt, index);
			}
			if (clrType == typeof(sbyte))
			{
				return (sbyte)SQLite3.ColumnInt(stmt, index);
			}
			if (clrType == typeof(byte[]))
			{
				return SQLite3.ColumnByteArray(stmt, index);
			}
			if (clrType == typeof(Guid))
			{
				return new Guid(SQLite3.ColumnString(stmt, index));
			}
			throw new NotSupportedException("Don't know how to read " + clrType);
		}
	}
	public class PreparedSqlLiteInsertCommand : IDisposable
	{
		internal static readonly sqlite3_stmt NullStatement;

		public bool Initialized { get; set; }

		protected SQLiteConnection Connection { get; set; }

		public string CommandText { get; set; }

		protected sqlite3_stmt Statement { get; set; }

		internal PreparedSqlLiteInsertCommand(SQLiteConnection conn)
		{
			Connection = conn;
		}

		public int ExecuteNonQuery(object[] source)
		{
			_ = Connection.Trace;
			SQLite3.Result result = SQLite3.Result.OK;
			if (!Initialized)
			{
				Statement = Prepare();
				Initialized = true;
			}
			if (source != null)
			{
				for (int i = 0; i < source.Length; i++)
				{
					SQLiteCommand.BindParameter(Statement, i + 1, source[i], Connection.StoreDateTimeAsTicks);
				}
			}
			result = SQLite3.Step(Statement);
			switch (result)
			{
			case SQLite3.Result.Done:
			{
				int result2 = SQLite3.Changes(Connection.Handle);
				SQLite3.Reset(Statement);
				return result2;
			}
			case SQLite3.Result.Error:
			{
				string errmsg = SQLite3.GetErrmsg(Connection.Handle);
				SQLite3.Reset(Statement);
				throw SQLiteException.New(result, errmsg);
			}
			case SQLite3.Result.Constraint:
				if (SQLite3.ExtendedErrCode(Connection.Handle) == SQLite3.ExtendedResult.ConstraintNotNull)
				{
					SQLite3.Reset(Statement);
					throw NotNullConstraintViolationException.New(result, SQLite3.GetErrmsg(Connection.Handle));
				}
				break;
			}
			SQLite3.Reset(Statement);
			throw SQLiteException.New(result, result.ToString());
		}

		protected virtual sqlite3_stmt Prepare()
		{
			return SQLite3.Prepare2(Connection.Handle, CommandText);
		}

		public void Dispose()
		{
			Dispose(disposing: true);
			GC.SuppressFinalize(this);
		}

		private void Dispose(bool disposing)
		{
			if (Statement != NullStatement)
			{
				try
				{
					SQLite3.Finalize(Statement);
				}
				finally
				{
					Statement = NullStatement;
					Connection = null;
				}
			}
		}

		~PreparedSqlLiteInsertCommand()
		{
			Dispose(disposing: false);
		}
	}
	public abstract class BaseTableQuery
	{
		protected class Ordering
		{
			public string ColumnName { get; set; }

			public bool Ascending { get; set; }
		}
	}
	public class TableQuery<T> : BaseTableQuery, IEnumerable<T>, IEnumerable
	{
		private class CompileResult
		{
			public string CommandText { get; set; }

			public object Value { get; set; }
		}

		private Expression _where;

		private List<Ordering> _orderBys;

		private int? _limit;

		private int? _offset;

		private BaseTableQuery _joinInner;

		private Expression _joinInnerKeySelector;

		private BaseTableQuery _joinOuter;

		private Expression _joinOuterKeySelector;

		private Expression _joinSelector;

		private Expression _selector;

		private bool _deferred;

		public SQLiteConnection Connection { get; private set; }

		public TableMapping Table { get; private set; }

		private TableQuery(SQLiteConnection conn, TableMapping table)
		{
			Connection = conn;
			Table = table;
		}

		public TableQuery(SQLiteConnection conn)
		{
			Connection = conn;
			Table = Connection.GetMapping(typeof(T));
		}

		public TableQuery<U> Clone<U>()
		{
			TableQuery<U> tableQuery = new TableQuery<U>(Connection, Table);
			tableQuery._where = _where;
			tableQuery._deferred = _deferred;
			if (_orderBys != null)
			{
				tableQuery._orderBys = new List<Ordering>(_orderBys);
			}
			tableQuery._limit = _limit;
			tableQuery._offset = _offset;
			tableQuery._joinInner = _joinInner;
			tableQuery._joinInnerKeySelector = _joinInnerKeySelector;
			tableQuery._joinOuter = _joinOuter;
			tableQuery._joinOuterKeySelector = _joinOuterKeySelector;
			tableQuery._joinSelector = _joinSelector;
			tableQuery._selector = _selector;
			return tableQuery;
		}

		public TableQuery<T> Where(Expression<Func<T, bool>> predExpr)
		{
			if (predExpr.NodeType == ExpressionType.Lambda)
			{
				Expression body = predExpr.Body;
				TableQuery<T> tableQuery = Clone<T>();
				tableQuery.AddWhere(body);
				return tableQuery;
			}
			throw new NotSupportedException("Must be a predicate");
		}

		public TableQuery<T> Take(int n)
		{
			TableQuery<T> tableQuery = Clone<T>();
			tableQuery._limit = n;
			return tableQuery;
		}

		public TableQuery<T> Skip(int n)
		{
			TableQuery<T> tableQuery = Clone<T>();
			tableQuery._offset = n;
			return tableQuery;
		}

		public T ElementAt(int index)
		{
			return Skip(index).Take(1).First();
		}

		public TableQuery<T> Deferred()
		{
			TableQuery<T> tableQuery = Clone<T>();
			tableQuery._deferred = true;
			return tableQuery;
		}

		public TableQuery<T> OrderBy<U>(Expression<Func<T, U>> orderExpr)
		{
			return AddOrderBy(orderExpr, asc: true);
		}

		public TableQuery<T> OrderByDescending<U>(Expression<Func<T, U>> orderExpr)
		{
			return AddOrderBy(orderExpr, asc: false);
		}

		public TableQuery<T> ThenBy<U>(Expression<Func<T, U>> orderExpr)
		{
			return AddOrderBy(orderExpr, asc: true);
		}

		public TableQuery<T> ThenByDescending<U>(Expression<Func<T, U>> orderExpr)
		{
			return AddOrderBy(orderExpr, asc: false);
		}

		private TableQuery<T> AddOrderBy<U>(Expression<Func<T, U>> orderExpr, bool asc)
		{
			if (orderExpr.NodeType == ExpressionType.Lambda)
			{
				MemberExpression memberExpression = null;
				memberExpression = ((!(orderExpr.Body is UnaryExpression { NodeType: ExpressionType.Convert } unaryExpression)) ? (orderExpr.Body as MemberExpression) : (unaryExpression.Operand as MemberExpression));
				if (memberExpression != null && memberExpression.Expression.NodeType == ExpressionType.Parameter)
				{
					TableQuery<T> tableQuery = Clone<T>();
					if (tableQuery._orderBys == null)
					{
						tableQuery._orderBys = new List<Ordering>();
					}
					tableQuery._orderBys.Add(new Ordering
					{
						ColumnName = Table.FindColumnWithPropertyName(memberExpression.Member.Name).Name,
						Ascending = asc
					});
					return tableQuery;
				}
				throw new NotSupportedException("Order By does not support: " + orderExpr);
			}
			throw new NotSupportedException("Must be a predicate");
		}

		private void AddWhere(Expression pred)
		{
			if (_where == null)
			{
				_where = pred;
			}
			else
			{
				_where = Expression.AndAlso(_where, pred);
			}
		}

		public TableQuery<TResult> Join<TInner, TKey, TResult>(TableQuery<TInner> inner, Expression<Func<T, TKey>> outerKeySelector, Expression<Func<TInner, TKey>> innerKeySelector, Expression<Func<T, TInner, TResult>> resultSelector)
		{
			return new TableQuery<TResult>(Connection, Connection.GetMapping(typeof(TResult)))
			{
				_joinOuter = this,
				_joinOuterKeySelector = outerKeySelector,
				_joinInner = inner,
				_joinInnerKeySelector = innerKeySelector,
				_joinSelector = resultSelector
			};
		}

		public TableQuery<TResult> Select<TResult>(Expression<Func<T, TResult>> selector)
		{
			TableQuery<TResult> tableQuery = Clone<TResult>();
			tableQuery._selector = selector;
			return tableQuery;
		}

		private SQLiteCommand GenerateCommand(string selectionList)
		{
			if (_joinInner != null && _joinOuter != null)
			{
				throw new NotSupportedException("Joins are not supported.");
			}
			string text = "select " + selectionList + " from \"" + Table.TableName + "\"";
			List<object> list = new List<object>();
			if (_where != null)
			{
				CompileResult compileResult = CompileExpr(_where, list);
				text = text + " where " + compileResult.CommandText;
			}
			if (_orderBys != null && _orderBys.Count > 0)
			{
				string text2 = string.Join(", ", _orderBys.Select((Ordering o) => "\"" + o.ColumnName + "\"" + (o.Ascending ? "" : " desc")).ToArray());
				text = text + " order by " + text2;
			}
			if (_limit.HasValue)
			{
				text = text + " limit " + _limit.Value;
			}
			if (_offset.HasValue)
			{
				if (!_limit.HasValue)
				{
					text += " limit -1 ";
				}
				text = text + " offset " + _offset.Value;
			}
			return Connection.CreateCommand(text, list.ToArray());
		}

		private CompileResult CompileExpr(Expression expr, List<object> queryArgs)
		{
			if (expr == null)
			{
				throw new NotSupportedException("Expression is NULL");
			}
			if (expr is BinaryExpression)
			{
				BinaryExpression binaryExpression = (BinaryExpression)expr;
				CompileResult compileResult = CompileExpr(binaryExpression.Left, queryArgs);
				CompileResult compileResult2 = CompileExpr(binaryExpression.Right, queryArgs);
				string commandText = ((compileResult.CommandText == "?" && compileResult.Value == null) ? CompileNullBinaryExpression(binaryExpression, compileResult2) : ((!(compileResult2.CommandText == "?") || compileResult2.Value != null) ? ("(" + compileResult.CommandText + " " + GetSqlName(binaryExpression) + " " + compileResult2.CommandText + ")") : CompileNullBinaryExpression(binaryExpression, compileResult)));
				return new CompileResult
				{
					CommandText = commandText
				};
			}
			if (expr.NodeType == ExpressionType.Call)
			{
				MethodCallExpression methodCallExpression = (MethodCallExpression)expr;
				CompileResult[] array = new CompileResult[methodCallExpression.Arguments.Count];
				CompileResult compileResult3 = ((methodCallExpression.Object != null) ? CompileExpr(methodCallExpression.Object, queryArgs) : null);
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = CompileExpr(methodCallExpression.Arguments[i], queryArgs);
				}
				string text = "";
				text = ((methodCallExpression.Method.Name == "Like" && array.Length == 2) ? ("(" + array[0].CommandText + " like " + array[1].CommandText + ")") : ((methodCallExpression.Method.Name == "Contains" && array.Length == 2) ? ("(" + array[1].CommandText + " in " + array[0].CommandText + ")") : ((methodCallExpression.Method.Name == "Contains" && array.Length == 1) ? ((methodCallExpression.Object == null || !(methodCallExpression.Object.Type == typeof(string))) ? ("(" + array[0].CommandText + " in " + compileResult3.CommandText + ")") : ("(" + compileResult3.CommandText + " like ('%' || " + array[0].CommandText + " || '%'))")) : ((methodCallExpression.Method.Name == "StartsWith" && array.Length == 1) ? ("(" + compileResult3.CommandText + " like (" + array[0].CommandText + " || '%'))") : ((methodCallExpression.Method.Name == "EndsWith" && array.Length == 1) ? ("(" + compileResult3.CommandText + " like ('%' || " + array[0].CommandText + "))") : ((methodCallExpression.Method.Name == "Equals" && array.Length == 1) ? ("(" + compileResult3.CommandText + " = (" + array[0].CommandText + "))") : ((methodCallExpression.Method.Name == "ToLower") ? ("(lower(" + compileResult3.CommandText + "))") : ((!(methodCallExpression.Method.Name == "ToUpper")) ? (methodCallExpression.Method.Name.ToLower() + "(" + string.Join(",", array.Select((CompileResult a) => a.CommandText).ToArray()) + ")") : ("(upper(" + compileResult3.CommandText + "))")))))))));
				return new CompileResult
				{
					CommandText = text
				};
			}
			if (expr.NodeType == ExpressionType.Constant)
			{
				ConstantExpression constantExpression = (ConstantExpression)expr;
				queryArgs.Add(constantExpression.Value);
				return new CompileResult
				{
					CommandText = "?",
					Value = constantExpression.Value
				};
			}
			if (expr.NodeType == ExpressionType.Convert)
			{
				UnaryExpression unaryExpression = (UnaryExpression)expr;
				Type type = unaryExpression.Type;
				CompileResult compileResult4 = CompileExpr(unaryExpression.Operand, queryArgs);
				return new CompileResult
				{
					CommandText = compileResult4.CommandText,
					Value = ((compileResult4.Value != null) ? ConvertTo(compileResult4.Value, type) : null)
				};
			}
			if (expr.NodeType == ExpressionType.MemberAccess)
			{
				MemberExpression memberExpression = (MemberExpression)expr;
				if (memberExpression.Expression != null && memberExpression.Expression.NodeType == ExpressionType.Parameter)
				{
					string name = Table.FindColumnWithPropertyName(memberExpression.Member.Name).Name;
					return new CompileResult
					{
						CommandText = "\"" + name + "\""
					};
				}
				object obj = null;
				if (memberExpression.Expression != null)
				{
					CompileResult compileResult5 = CompileExpr(memberExpression.Expression, queryArgs);
					if (compileResult5.Value == null)
					{
						throw new NotSupportedException("Member access failed to compile expression");
					}
					if (compileResult5.CommandText == "?")
					{
						queryArgs.RemoveAt(queryArgs.Count - 1);
					}
					obj = compileResult5.Value;
				}
				object obj2 = null;
				if (memberExpression.Member is PropertyInfo)
				{
					obj2 = ((PropertyInfo)memberExpression.Member).GetValue(obj, null);
				}
				else
				{
					if (!(memberExpression.Member is FieldInfo))
					{
						throw new NotSupportedException("MemberExpr: " + memberExpression.Member.DeclaringType);
					}
					obj2 = ((FieldInfo)memberExpression.Member).GetValue(obj);
				}
				if (obj2 != null && obj2 is IEnumerable && !(obj2 is string) && !(obj2 is IEnumerable<byte>))
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append("(");
					string value = "";
					foreach (object item in (IEnumerable)obj2)
					{
						queryArgs.Add(item);
						stringBuilder.Append(value);
						stringBuilder.Append("?");
						value = ",";
					}
					stringBuilder.Append(")");
					return new CompileResult
					{
						CommandText = stringBuilder.ToString(),
						Value = obj2
					};
				}
				queryArgs.Add(obj2);
				return new CompileResult
				{
					CommandText = "?",
					Value = obj2
				};
			}
			throw new NotSupportedException("Cannot compile: " + expr.NodeType);
		}

		private static object ConvertTo(object obj, Type t)
		{
			Type underlyingType = Nullable.GetUnderlyingType(t);
			if (underlyingType != null)
			{
				if (obj == null)
				{
					return null;
				}
				return Convert.ChangeType(obj, underlyingType);
			}
			return Convert.ChangeType(obj, t);
		}

		private string CompileNullBinaryExpression(BinaryExpression expression, CompileResult parameter)
		{
			if (expression.NodeType == ExpressionType.Equal)
			{
				return "(" + parameter.CommandText + " is ?)";
			}
			if (expression.NodeType == ExpressionType.NotEqual)
			{
				return "(" + parameter.CommandText + " is not ?)";
			}
			throw new NotSupportedException("Cannot compile Null-BinaryExpression with type " + expression.NodeType);
		}

		private string GetSqlName(Expression expr)
		{
			ExpressionType nodeType = expr.NodeType;
			return nodeType switch
			{
				ExpressionType.GreaterThan => ">", 
				ExpressionType.GreaterThanOrEqual => ">=", 
				ExpressionType.LessThan => "<", 
				ExpressionType.LessThanOrEqual => "<=", 
				ExpressionType.And => "&", 
				ExpressionType.AndAlso => "and", 
				ExpressionType.Or => "|", 
				ExpressionType.OrElse => "or", 
				ExpressionType.Equal => "=", 
				ExpressionType.NotEqual => "!=", 
				_ => throw new NotSupportedException("Cannot get SQL for: " + nodeType), 
			};
		}

		public int Count()
		{
			return GenerateCommand("count(*)").ExecuteScalar<int>();
		}

		public int Count(Expression<Func<T, bool>> predExpr)
		{
			return Where(predExpr).Count();
		}

		public IEnumerator<T> GetEnumerator()
		{
			if (!_deferred)
			{
				return GenerateCommand("*").ExecuteQuery<T>().GetEnumerator();
			}
			return GenerateCommand("*").ExecuteDeferredQuery<T>().GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		public T First()
		{
			return Take(1).ToList().First();
		}

		public T FirstOrDefault()
		{
			return Take(1).ToList().FirstOrDefault();
		}
	}
	public static class SQLite3
	{
		public enum Result
		{
			OK = 0,
			Error = 1,
			Internal = 2,
			Perm = 3,
			Abort = 4,
			Busy = 5,
			Locked = 6,
			NoMem = 7,
			ReadOnly = 8,
			Interrupt = 9,
			IOError = 10,
			Corrupt = 11,
			NotFound = 12,
			Full = 13,
			CannotOpen = 14,
			LockErr = 15,
			Empty = 16,
			SchemaChngd = 17,
			TooBig = 18,
			Constraint = 19,
			Mismatch = 20,
			Misuse = 21,
			NotImplementedLFS = 22,
			AccessDenied = 23,
			Format = 24,
			Range = 25,
			NonDBFile = 26,
			Notice = 27,
			Warning = 28,
			Row = 100,
			Done = 101
		}

		public enum ExtendedResult
		{
			IOErrorRead = 266,
			IOErrorShortRead = 522,
			IOErrorWrite = 778,
			IOErrorFsync = 1034,
			IOErrorDirFSync = 1290,
			IOErrorTruncate = 1546,
			IOErrorFStat = 1802,
			IOErrorUnlock = 2058,
			IOErrorRdlock = 2314,
			IOErrorDelete = 2570,
			IOErrorBlocked = 2826,
			IOErrorNoMem = 3082,
			IOErrorAccess = 3338,
			IOErrorCheckReservedLock = 3594,
			IOErrorLock = 3850,
			IOErrorClose = 4106,
			IOErrorDirClose = 4362,
			IOErrorSHMOpen = 4618,
			IOErrorSHMSize = 4874,
			IOErrorSHMLock = 5130,
			IOErrorSHMMap = 5386,
			IOErrorSeek = 5642,
			IOErrorDeleteNoEnt = 5898,
			IOErrorMMap = 6154,
			LockedSharedcache = 262,
			BusyRecovery = 261,
			CannottOpenNoTempDir = 270,
			CannotOpenIsDir = 526,
			CannotOpenFullPath = 782,
			CorruptVTab = 267,
			ReadonlyRecovery = 264,
			ReadonlyCannotLock = 520,
			ReadonlyRollback = 776,
			AbortRollback = 516,
			ConstraintCheck = 275,
			ConstraintCommitHook = 531,
			ConstraintForeignKey = 787,
			ConstraintFunction = 1043,
			ConstraintNotNull = 1299,
			ConstraintPrimaryKey = 1555,
			ConstraintTrigger = 1811,
			ConstraintUnique = 2067,
			ConstraintVTab = 2323,
			NoticeRecoverWAL = 283,
			NoticeRecoverRollback = 539
		}

		public enum ConfigOption
		{
			SingleThread = 1,
			MultiThread,
			Serialized
		}

		public enum ColType
		{
			Integer = 1,
			Float,
			Text,
			Blob,
			Null
		}

		public static Result Open(string filename, out sqlite3 db)
		{
			return (Result)raw.sqlite3_open(filename, out db);
		}

		public static Result Open(string filename, out sqlite3 db, int flags, IntPtr zVfs)
		{
			return (Result)raw.sqlite3_open_v2(filename, out db, flags, null);
		}

		public static Result Close(sqlite3 db)
		{
			return (Result)raw.sqlite3_close(db);
		}

		public static Result BusyTimeout(sqlite3 db, int milliseconds)
		{
			return (Result)raw.sqlite3_busy_timeout(db, milliseconds);
		}

		public static int Changes(sqlite3 db)
		{
			return raw.sqlite3_changes(db);
		}

		public static sqlite3_stmt Prepare2(sqlite3 db, string query)
		{
			sqlite3_stmt stmt = null;
			int num = raw.sqlite3_prepare_v2(db, query, out stmt);
			if (num != 0)
			{
				throw SQLiteException.New((Result)num, GetErrmsg(db));
			}
			return stmt;
		}

		public static Result Step(sqlite3_stmt stmt)
		{
			return (Result)raw.sqlite3_step(stmt);
		}

		public static Result Reset(sqlite3_stmt stmt)
		{
			return (Result)raw.sqlite3_reset(stmt);
		}

		public static Result Finalize(sqlite3_stmt stmt)
		{
			return (Result)raw.sqlite3_finalize(stmt);
		}

		public static long LastInsertRowid(sqlite3 db)
		{
			return raw.sqlite3_last_insert_rowid(db);
		}

		public static string GetErrmsg(sqlite3 db)
		{
			return raw.sqlite3_errmsg(db).utf8_to_string();
		}

		public static int BindParameterIndex(sqlite3_stmt stmt, string name)
		{
			return raw.sqlite3_bind_parameter_index(stmt, name);
		}

		public static int BindNull(sqlite3_stmt stmt, int index)
		{
			return raw.sqlite3_bind_null(stmt, index);
		}

		public static int BindInt(sqlite3_stmt stmt, int index, int val)
		{
			return raw.sqlite3_bind_int(stmt, index, val);
		}

		public static int BindInt64(sqlite3_stmt stmt, int index, long val)
		{
			return raw.sqlite3_bind_int64(stmt, index, val);
		}

		public static int BindDouble(sqlite3_stmt stmt, int index, double val)
		{
			return raw.sqlite3_bind_double(stmt, index, val);
		}

		public static int BindText(sqlite3_stmt stmt, int index, string val, int n, IntPtr free)
		{
			return raw.sqlite3_bind_text(stmt, index, val);
		}

		public static int BindBlob(sqlite3_stmt stmt, int index, byte[] val, int n, IntPtr free)
		{
			return raw.sqlite3_bind_blob(stmt, index, val);
		}

		public static int ColumnCount(sqlite3_stmt stmt)
		{
			return raw.sqlite3_column_count(stmt);
		}

		public static string ColumnName(sqlite3_stmt stmt, int index)
		{
			return raw.sqlite3_column_name(stmt, index).utf8_to_string();
		}

		public static string ColumnName16(sqlite3_stmt stmt, int index)
		{
			return raw.sqlite3_column_name(stmt, index).utf8_to_string();
		}

		public static ColType ColumnType(sqlite3_stmt stmt, int index)
		{
			return (ColType)raw.sqlite3_column_type(stmt, index);
		}

		public static int ColumnInt(sqlite3_stmt stmt, int index)
		{
			return raw.sqlite3_column_int(stmt, index);
		}

		public static long ColumnInt64(sqlite3_stmt stmt, int index)
		{
			return raw.sqlite3_column_int64(stmt, index);
		}

		public static double ColumnDouble(sqlite3_stmt stmt, int index)
		{
			return raw.sqlite3_column_double(stmt, index);
		}

		public static string ColumnText(sqlite3_stmt stmt, int index)
		{
			return raw.sqlite3_column_text(stmt, index).utf8_to_string();
		}

		public static string ColumnText16(sqlite3_stmt stmt, int index)
		{
			return raw.sqlite3_column_text(stmt, index).utf8_to_string();
		}

		public static byte[] ColumnBlob(sqlite3_stmt stmt, int index)
		{
			return raw.sqlite3_column_blob(stmt, index).ToArray();
		}

		public static int ColumnBytes(sqlite3_stmt stmt, int index)
		{
			return raw.sqlite3_column_bytes(stmt, index);
		}

		public static string ColumnString(sqlite3_stmt stmt, int index)
		{
			return raw.sqlite3_column_text(stmt, index).utf8_to_string();
		}

		public static byte[] ColumnByteArray(sqlite3_stmt stmt, int index)
		{
			return ColumnBlob(stmt, index);
		}

		public static ExtendedResult ExtendedErrCode(sqlite3 db)
		{
			return (ExtendedResult)raw.sqlite3_extended_errcode(db);
		}
	}
}
