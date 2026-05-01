using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using System.Text;
using Microsoft.CodeAnalysis;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("SourceGear")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("Copyright 2014-2020 SourceGear, LLC")]
[assembly: AssemblyDescription("SQLitePCLRaw is a Portable Class Library (PCL) for low-level (raw) access to SQLite")]
[assembly: AssemblyFileVersion("2.0.4.976")]
[assembly: AssemblyInformationalVersion("2.0.4")]
[assembly: AssemblyTitle("SQLitePCLRaw.core")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/ericsink/SQLitePCL.raw")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("2.0.4.976")]
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
	internal sealed class IsReadOnlyAttribute : Attribute
	{
	}
	[CompilerGenerated]
	[Embedded]
	internal sealed class IsByRefLikeAttribute : Attribute
	{
	}
}
namespace SQLitePCL
{
	public delegate int strdelegate_collation(object user_data, string s1, string s2);
	public delegate void strdelegate_update(object user_data, int type, string database, string table, long rowid);
	public delegate void strdelegate_log(object user_data, int errorCode, string msg);
	public delegate int strdelegate_authorizer(object user_data, int action_code, string param0, string param1, string dbName, string inner_most_trigger_or_view);
	public delegate void strdelegate_trace(object user_data, string s);
	public delegate void strdelegate_profile(object user_data, string statement, long ns);
	public delegate int strdelegate_exec(object user_data, string[] values, string[] names);
	public static class raw
	{
		private static ISQLite3Provider _imp;

		private static bool _frozen;

		public const int SQLITE_UTF8 = 1;

		public const int SQLITE_UTF16LE = 2;

		public const int SQLITE_UTF16BE = 3;

		public const int SQLITE_UTF16 = 4;

		public const int SQLITE_ANY = 5;

		public const int SQLITE_UTF16_ALIGNED = 8;

		public const int SQLITE_DETERMINISTIC = 2048;

		public const int SQLITE_CONFIG_SINGLETHREAD = 1;

		public const int SQLITE_CONFIG_MULTITHREAD = 2;

		public const int SQLITE_CONFIG_SERIALIZED = 3;

		public const int SQLITE_CONFIG_MALLOC = 4;

		public const int SQLITE_CONFIG_GETMALLOC = 5;

		public const int SQLITE_CONFIG_SCRATCH = 6;

		public const int SQLITE_CONFIG_PAGECACHE = 7;

		public const int SQLITE_CONFIG_HEAP = 8;

		public const int SQLITE_CONFIG_MEMSTATUS = 9;

		public const int SQLITE_CONFIG_MUTEX = 10;

		public const int SQLITE_CONFIG_GETMUTEX = 11;

		public const int SQLITE_CONFIG_LOOKASIDE = 13;

		public const int SQLITE_CONFIG_PCACHE = 14;

		public const int SQLITE_CONFIG_GETPCACHE = 15;

		public const int SQLITE_CONFIG_LOG = 16;

		public const int SQLITE_CONFIG_URI = 17;

		public const int SQLITE_CONFIG_PCACHE2 = 18;

		public const int SQLITE_CONFIG_GETPCACHE2 = 19;

		public const int SQLITE_CONFIG_COVERING_INDEX_SCAN = 20;

		public const int SQLITE_CONFIG_SQLLOG = 21;

		public const int SQLITE_OPEN_READONLY = 1;

		public const int SQLITE_OPEN_READWRITE = 2;

		public const int SQLITE_OPEN_CREATE = 4;

		public const int SQLITE_OPEN_DELETEONCLOSE = 8;

		public const int SQLITE_OPEN_EXCLUSIVE = 16;

		public const int SQLITE_OPEN_AUTOPROXY = 32;

		public const int SQLITE_OPEN_URI = 64;

		public const int SQLITE_OPEN_MEMORY = 128;

		public const int SQLITE_OPEN_MAIN_DB = 256;

		public const int SQLITE_OPEN_TEMP_DB = 512;

		public const int SQLITE_OPEN_TRANSIENT_DB = 1024;

		public const int SQLITE_OPEN_MAIN_JOURNAL = 2048;

		public const int SQLITE_OPEN_TEMP_JOURNAL = 4096;

		public const int SQLITE_OPEN_SUBJOURNAL = 8192;

		public const int SQLITE_OPEN_MASTER_JOURNAL = 16384;

		public const int SQLITE_OPEN_NOMUTEX = 32768;

		public const int SQLITE_OPEN_FULLMUTEX = 65536;

		public const int SQLITE_OPEN_SHAREDCACHE = 131072;

		public const int SQLITE_OPEN_PRIVATECACHE = 262144;

		public const int SQLITE_OPEN_WAL = 524288;

		public const int SQLITE_PREPARE_PERSISTENT = 1;

		public const int SQLITE_PREPARE_NORMALIZE = 2;

		public const int SQLITE_PREPARE_NO_VTAB = 4;

		public const int SQLITE_INTEGER = 1;

		public const int SQLITE_FLOAT = 2;

		public const int SQLITE_TEXT = 3;

		public const int SQLITE_BLOB = 4;

		public const int SQLITE_NULL = 5;

		public const int SQLITE_OK = 0;

		public const int SQLITE_ERROR = 1;

		public const int SQLITE_INTERNAL = 2;

		public const int SQLITE_PERM = 3;

		public const int SQLITE_ABORT = 4;

		public const int SQLITE_BUSY = 5;

		public const int SQLITE_LOCKED = 6;

		public const int SQLITE_NOMEM = 7;

		public const int SQLITE_READONLY = 8;

		public const int SQLITE_INTERRUPT = 9;

		public const int SQLITE_IOERR = 10;

		public const int SQLITE_CORRUPT = 11;

		public const int SQLITE_NOTFOUND = 12;

		public const int SQLITE_FULL = 13;

		public const int SQLITE_CANTOPEN = 14;

		public const int SQLITE_PROTOCOL = 15;

		public const int SQLITE_EMPTY = 16;

		public const int SQLITE_SCHEMA = 17;

		public const int SQLITE_TOOBIG = 18;

		public const int SQLITE_CONSTRAINT = 19;

		public const int SQLITE_MISMATCH = 20;

		public const int SQLITE_MISUSE = 21;

		public const int SQLITE_NOLFS = 22;

		public const int SQLITE_AUTH = 23;

		public const int SQLITE_FORMAT = 24;

		public const int SQLITE_RANGE = 25;

		public const int SQLITE_NOTADB = 26;

		public const int SQLITE_NOTICE = 27;

		public const int SQLITE_WARNING = 28;

		public const int SQLITE_ROW = 100;

		public const int SQLITE_DONE = 101;

		public const int SQLITE_IOERR_READ = 266;

		public const int SQLITE_IOERR_SHORT_READ = 522;

		public const int SQLITE_IOERR_WRITE = 778;

		public const int SQLITE_IOERR_FSYNC = 1034;

		public const int SQLITE_IOERR_DIR_FSYNC = 1290;

		public const int SQLITE_IOERR_TRUNCATE = 1546;

		public const int SQLITE_IOERR_FSTAT = 1802;

		public const int SQLITE_IOERR_UNLOCK = 2058;

		public const int SQLITE_IOERR_RDLOCK = 2314;

		public const int SQLITE_IOERR_DELETE = 2570;

		public const int SQLITE_IOERR_BLOCKED = 2826;

		public const int SQLITE_IOERR_NOMEM = 3082;

		public const int SQLITE_IOERR_ACCESS = 3338;

		public const int SQLITE_IOERR_CHECKRESERVEDLOCK = 3594;

		public const int SQLITE_IOERR_LOCK = 3850;

		public const int SQLITE_IOERR_CLOSE = 4106;

		public const int SQLITE_IOERR_DIR_CLOSE = 4362;

		public const int SQLITE_IOERR_SHMOPEN = 4618;

		public const int SQLITE_IOERR_SHMSIZE = 4874;

		public const int SQLITE_IOERR_SHMLOCK = 5130;

		public const int SQLITE_IOERR_SHMMAP = 5386;

		public const int SQLITE_IOERR_SEEK = 5642;

		public const int SQLITE_IOERR_DELETE_NOENT = 5898;

		public const int SQLITE_IOERR_MMAP = 6154;

		public const int SQLITE_IOERR_GETTEMPPATH = 6410;

		public const int SQLITE_IOERR_CONVPATH = 6666;

		public const int SQLITE_LOCKED_SHAREDCACHE = 262;

		public const int SQLITE_BUSY_RECOVERY = 261;

		public const int SQLITE_BUSY_SNAPSHOT = 517;

		public const int SQLITE_CANTOPEN_NOTEMPDIR = 270;

		public const int SQLITE_CANTOPEN_ISDIR = 526;

		public const int SQLITE_CANTOPEN_FULLPATH = 782;

		public const int SQLITE_CANTOPEN_CONVPATH = 1038;

		public const int SQLITE_CORRUPT_VTAB = 267;

		public const int SQLITE_READONLY_RECOVERY = 264;

		public const int SQLITE_READONLY_CANTLOCK = 520;

		public const int SQLITE_READONLY_ROLLBACK = 776;

		public const int SQLITE_READONLY_DBMOVED = 1032;

		public const int SQLITE_ABORT_ROLLBACK = 516;

		public const int SQLITE_CONSTRAINT_CHECK = 275;

		public const int SQLITE_CONSTRAINT_COMMITHOOK = 531;

		public const int SQLITE_CONSTRAINT_FOREIGNKEY = 787;

		public const int SQLITE_CONSTRAINT_FUNCTION = 1043;

		public const int SQLITE_CONSTRAINT_NOTNULL = 1299;

		public const int SQLITE_CONSTRAINT_PRIMARYKEY = 1555;

		public const int SQLITE_CONSTRAINT_TRIGGER = 1811;

		public const int SQLITE_CONSTRAINT_UNIQUE = 2067;

		public const int SQLITE_CONSTRAINT_VTAB = 2323;

		public const int SQLITE_CONSTRAINT_ROWID = 2579;

		public const int SQLITE_NOTICE_RECOVER_WAL = 283;

		public const int SQLITE_NOTICE_RECOVER_ROLLBACK = 539;

		public const int SQLITE_WARNING_AUTOINDEX = 284;

		public const int SQLITE_CREATE_INDEX = 1;

		public const int SQLITE_CREATE_TABLE = 2;

		public const int SQLITE_CREATE_TEMP_INDEX = 3;

		public const int SQLITE_CREATE_TEMP_TABLE = 4;

		public const int SQLITE_CREATE_TEMP_TRIGGER = 5;

		public const int SQLITE_CREATE_TEMP_VIEW = 6;

		public const int SQLITE_CREATE_TRIGGER = 7;

		public const int SQLITE_CREATE_VIEW = 8;

		public const int SQLITE_DELETE = 9;

		public const int SQLITE_DROP_INDEX = 10;

		public const int SQLITE_DROP_TABLE = 11;

		public const int SQLITE_DROP_TEMP_INDEX = 12;

		public const int SQLITE_DROP_TEMP_TABLE = 13;

		public const int SQLITE_DROP_TEMP_TRIGGER = 14;

		public const int SQLITE_DROP_TEMP_VIEW = 15;

		public const int SQLITE_DROP_TRIGGER = 16;

		public const int SQLITE_DROP_VIEW = 17;

		public const int SQLITE_INSERT = 18;

		public const int SQLITE_PRAGMA = 19;

		public const int SQLITE_READ = 20;

		public const int SQLITE_SELECT = 21;

		public const int SQLITE_TRANSACTION = 22;

		public const int SQLITE_UPDATE = 23;

		public const int SQLITE_ATTACH = 24;

		public const int SQLITE_DETACH = 25;

		public const int SQLITE_ALTER_TABLE = 26;

		public const int SQLITE_REINDEX = 27;

		public const int SQLITE_ANALYZE = 28;

		public const int SQLITE_CREATE_VTABLE = 29;

		public const int SQLITE_DROP_VTABLE = 30;

		public const int SQLITE_FUNCTION = 31;

		public const int SQLITE_SAVEPOINT = 32;

		public const int SQLITE_COPY = 0;

		public const int SQLITE_RECURSIVE = 33;

		public const int SQLITE_CHECKPOINT_PASSIVE = 0;

		public const int SQLITE_CHECKPOINT_FULL = 1;

		public const int SQLITE_CHECKPOINT_RESTART = 2;

		public const int SQLITE_CHECKPOINT_TRUNCATE = 3;

		public const int SQLITE_DBSTATUS_LOOKASIDE_USED = 0;

		public const int SQLITE_DBSTATUS_CACHE_USED = 1;

		public const int SQLITE_DBSTATUS_SCHEMA_USED = 2;

		public const int SQLITE_DBSTATUS_STMT_USED = 3;

		public const int SQLITE_DBSTATUS_LOOKASIDE_HIT = 4;

		public const int SQLITE_DBSTATUS_LOOKASIDE_MISS_SIZE = 5;

		public const int SQLITE_DBSTATUS_LOOKASIDE_MISS_FULL = 6;

		public const int SQLITE_DBSTATUS_CACHE_HIT = 7;

		public const int SQLITE_DBSTATUS_CACHE_MISS = 8;

		public const int SQLITE_DBSTATUS_CACHE_WRITE = 9;

		public const int SQLITE_DBSTATUS_DEFERRED_FKS = 10;

		public const int SQLITE_STATUS_MEMORY_USED = 0;

		public const int SQLITE_STATUS_PAGECACHE_USED = 1;

		public const int SQLITE_STATUS_PAGECACHE_OVERFLOW = 2;

		public const int SQLITE_STATUS_SCRATCH_USED = 3;

		public const int SQLITE_STATUS_SCRATCH_OVERFLOW = 4;

		public const int SQLITE_STATUS_MALLOC_SIZE = 5;

		public const int SQLITE_STATUS_PARSER_STACK = 6;

		public const int SQLITE_STATUS_PAGECACHE_SIZE = 7;

		public const int SQLITE_STATUS_SCRATCH_SIZE = 8;

		public const int SQLITE_STATUS_MALLOC_COUNT = 9;

		public const int SQLITE_STMTSTATUS_FULLSCAN_STEP = 1;

		public const int SQLITE_STMTSTATUS_SORT = 2;

		public const int SQLITE_STMTSTATUS_AUTOINDEX = 3;

		public const int SQLITE_STMTSTATUS_VM_STEP = 4;

		public const int SQLITE_DENY = 1;

		public const int SQLITE_IGNORE = 2;

		public const int SQLITE_TRACE_STMT = 1;

		public const int SQLITE_TRACE_PROFILE = 2;

		public const int SQLITE_TRACE_ROW = 4;

		public const int SQLITE_TRACE_CLOSE = 8;

		private static ISQLite3Provider Provider
		{
			get
			{
				if (_imp == null)
				{
					throw new Exception("You need to call SQLitePCL.raw.SetProvider().  If you are using a bundle package, this is done by calling SQLitePCL.Batteries.Init().");
				}
				return _imp;
			}
		}

		static raw()
		{
			_frozen = false;
		}

		public static void SetProvider(ISQLite3Provider imp)
		{
			if (!_frozen)
			{
				imp.sqlite3_libversion_number();
				_imp = imp;
			}
		}

		public static void FreezeProvider(bool b = true)
		{
			_frozen = b;
		}

		public static string GetNativeLibraryName()
		{
			return Provider.GetNativeLibraryName();
		}

		public static int sqlite3_open(utf8z filename, out sqlite3 db)
		{
			IntPtr db2;
			int result = Provider.sqlite3_open(filename, out db2);
			db = sqlite3.New(db2);
			return result;
		}

		public static int sqlite3_open(string filename, out sqlite3 db)
		{
			return sqlite3_open(filename.to_utf8z(), out db);
		}

		public static int sqlite3_open_v2(utf8z filename, out sqlite3 db, int flags, utf8z vfs)
		{
			IntPtr db2;
			int result = Provider.sqlite3_open_v2(filename, out db2, flags, vfs);
			db = sqlite3.New(db2);
			return result;
		}

		public static int sqlite3_open_v2(string filename, out sqlite3 db, int flags, string vfs)
		{
			return sqlite3_open_v2(filename.to_utf8z(), out db, flags, vfs.to_utf8z());
		}

		public static int sqlite3__vfs__delete(utf8z vfs, utf8z pathname, int syncdir)
		{
			return Provider.sqlite3__vfs__delete(vfs, pathname, syncdir);
		}

		public static int sqlite3__vfs__delete(string vfs, string pathname, int syncdir)
		{
			return sqlite3__vfs__delete(vfs.to_utf8z(), pathname.to_utf8z(), syncdir);
		}

		internal static int internal_sqlite3_close_v2(IntPtr p)
		{
			return Provider.sqlite3_close_v2(p);
		}

		internal static int internal_sqlite3_close(IntPtr p)
		{
			return Provider.sqlite3_close(p);
		}

		public static int sqlite3_close_v2(sqlite3 db)
		{
			return db.manual_close_v2();
		}

		public static int sqlite3_close(sqlite3 db)
		{
			return db.manual_close();
		}

		public static int sqlite3_enable_shared_cache(int enable)
		{
			return Provider.sqlite3_enable_shared_cache(enable);
		}

		public static void sqlite3_interrupt(sqlite3 db)
		{
			Provider.sqlite3_interrupt(db);
		}

		public static int sqlite3_config_log(delegate_log f, object v)
		{
			return Provider.sqlite3_config_log(f, v);
		}

		public static int sqlite3_config_log(strdelegate_log f, object v)
		{
			delegate_log f2 = ((f != null) ? ((delegate_log)delegate(object ob, int e, utf8z msg)
			{
				f(ob, e, msg.utf8_to_string());
			}) : null);
			return sqlite3_config_log(f2, v);
		}

		public static void sqlite3_log(int errcode, utf8z s)
		{
			Provider.sqlite3_log(errcode, s);
		}

		public static void sqlite3_log(int errcode, string s)
		{
			sqlite3_log(errcode, s.to_utf8z());
		}

		public static void sqlite3_commit_hook(sqlite3 db, delegate_commit f, object v)
		{
			Provider.sqlite3_commit_hook(db, f, v);
		}

		public static void sqlite3_rollback_hook(sqlite3 db, delegate_rollback f, object v)
		{
			Provider.sqlite3_rollback_hook(db, f, v);
		}

		public static void sqlite3_trace(sqlite3 db, delegate_trace f, object v)
		{
			Provider.sqlite3_trace(db, f, v);
		}

		public static void sqlite3_trace(sqlite3 db, strdelegate_trace f, object v)
		{
			delegate_trace f2 = ((f != null) ? ((delegate_trace)delegate(object ob, utf8z sp)
			{
				f(v, sp.utf8_to_string());
			}) : null);
			sqlite3_trace(db, f2, v);
		}

		public static void sqlite3_profile(sqlite3 db, delegate_profile f, object v)
		{
			Provider.sqlite3_profile(db, f, v);
		}

		public static void sqlite3_profile(sqlite3 db, strdelegate_profile f, object v)
		{
			delegate_profile f2 = ((f != null) ? ((delegate_profile)delegate(object ob, utf8z sp, long ns)
			{
				f(v, sp.utf8_to_string(), ns);
			}) : null);
			sqlite3_profile(db, f2, v);
		}

		public static void sqlite3_progress_handler(sqlite3 db, int instructions, delegate_progress func, object v)
		{
			Provider.sqlite3_progress_handler(db, instructions, func, v);
		}

		public static void sqlite3_update_hook(sqlite3 db, delegate_update f, object v)
		{
			Provider.sqlite3_update_hook(db, f, v);
		}

		public static void sqlite3_update_hook(sqlite3 db, strdelegate_update f, object v)
		{
			delegate_update f2 = ((f != null) ? ((delegate_update)delegate(object ob, int typ, utf8z dbname, utf8z tbl, long rowid)
			{
				f(ob, typ, dbname.utf8_to_string(), tbl.utf8_to_string(), rowid);
			}) : null);
			sqlite3_update_hook(db, f2, v);
		}

		public static int sqlite3_create_collation(sqlite3 db, string name, object v, strdelegate_collation f)
		{
			byte[] name2 = name.to_utf8_with_z();
			delegate_collation func = ((f != null) ? ((delegate_collation)((object ob, ReadOnlySpan<byte> s1, ReadOnlySpan<byte> s2) => f(ob, s1.utf8_span_to_string(), s2.utf8_span_to_string()))) : null);
			return Provider.sqlite3_create_collation(db, name2, v, func);
		}

		public static int sqlite3_create_function(sqlite3 db, string name, int nArg, int flags, object v, delegate_function_scalar func)
		{
			byte[] name2 = name.to_utf8_with_z();
			return Provider.sqlite3_create_function(db, name2, nArg, flags, v, func);
		}

		public static int sqlite3_create_function(sqlite3 db, string name, int nArg, int flags, object v, delegate_function_aggregate_step func_step, delegate_function_aggregate_final func_final)
		{
			byte[] name2 = name.to_utf8_with_z();
			return Provider.sqlite3_create_function(db, name2, nArg, flags, v, func_step, func_final);
		}

		public static int sqlite3_create_function(sqlite3 db, string name, int nArg, object v, delegate_function_scalar func)
		{
			return sqlite3_create_function(db, name, nArg, 0, v, func);
		}

		public static int sqlite3_create_function(sqlite3 db, string name, int nArg, object v, delegate_function_aggregate_step func_step, delegate_function_aggregate_final func_final)
		{
			return sqlite3_create_function(db, name, nArg, 0, v, func_step, func_final);
		}

		public static int sqlite3_db_status(sqlite3 db, int op, out int current, out int highest, int resetFlg)
		{
			return Provider.sqlite3_db_status(db, op, out current, out highest, resetFlg);
		}

		public unsafe static string utf8_span_to_string(this ReadOnlySpan<byte> p)
		{
			if (p.Length == 0)
			{
				return "";
			}
			fixed (byte* bytes = p)
			{
				return Encoding.UTF8.GetString(bytes, p.Length);
			}
		}

		public static int sqlite3_key(sqlite3 db, ReadOnlySpan<byte> k)
		{
			return Provider.sqlite3_key(db, k);
		}

		public static int sqlite3_key_v2(sqlite3 db, utf8z name, ReadOnlySpan<byte> k)
		{
			return Provider.sqlite3_key_v2(db, name, k);
		}

		public static int sqlite3_rekey(sqlite3 db, ReadOnlySpan<byte> k)
		{
			return Provider.sqlite3_rekey(db, k);
		}

		public static int sqlite3_rekey_v2(sqlite3 db, utf8z name, ReadOnlySpan<byte> k)
		{
			return Provider.sqlite3_rekey_v2(db, name, k);
		}

		public static utf8z sqlite3_libversion()
		{
			return Provider.sqlite3_libversion();
		}

		public static int sqlite3_libversion_number()
		{
			return Provider.sqlite3_libversion_number();
		}

		public static int sqlite3_threadsafe()
		{
			return Provider.sqlite3_threadsafe();
		}

		public static int sqlite3_initialize()
		{
			return Provider.sqlite3_initialize();
		}

		public static int sqlite3_shutdown()
		{
			return Provider.sqlite3_shutdown();
		}

		public static int sqlite3_config(int op)
		{
			return Provider.sqlite3_config(op);
		}

		public static int sqlite3_config(int op, int val)
		{
			return Provider.sqlite3_config(op, val);
		}

		public static int sqlite3_enable_load_extension(sqlite3 db, int onoff)
		{
			return Provider.sqlite3_enable_load_extension(db, onoff);
		}

		public static utf8z sqlite3_sourceid()
		{
			return Provider.sqlite3_sourceid();
		}

		public static long sqlite3_memory_used()
		{
			return Provider.sqlite3_memory_used();
		}

		public static long sqlite3_memory_highwater(int resetFlag)
		{
			return Provider.sqlite3_memory_highwater(resetFlag);
		}

		public static int sqlite3_status(int op, out int current, out int highwater, int resetFlag)
		{
			return Provider.sqlite3_status(op, out current, out highwater, resetFlag);
		}

		public static utf8z sqlite3_errmsg(sqlite3 db)
		{
			return Provider.sqlite3_errmsg(db);
		}

		public static int sqlite3_db_readonly(sqlite3 db, utf8z dbName)
		{
			return Provider.sqlite3_db_readonly(db, dbName);
		}

		public static int sqlite3_db_readonly(sqlite3 db, string dbName)
		{
			return sqlite3_db_readonly(db, dbName.to_utf8z());
		}

		public static utf8z sqlite3_db_filename(sqlite3 db, utf8z att)
		{
			return Provider.sqlite3_db_filename(db, att);
		}

		public static utf8z sqlite3_db_filename(sqlite3 db, string att)
		{
			return sqlite3_db_filename(db, att.to_utf8z());
		}

		public static long sqlite3_last_insert_rowid(sqlite3 db)
		{
			return Provider.sqlite3_last_insert_rowid(db);
		}

		public static int sqlite3_changes(sqlite3 db)
		{
			return Provider.sqlite3_changes(db);
		}

		public static int sqlite3_total_changes(sqlite3 db)
		{
			return Provider.sqlite3_total_changes(db);
		}

		public static int sqlite3_get_autocommit(sqlite3 db)
		{
			return Provider.sqlite3_get_autocommit(db);
		}

		public static int sqlite3_busy_timeout(sqlite3 db, int ms)
		{
			return Provider.sqlite3_busy_timeout(db, ms);
		}

		public static int sqlite3_extended_result_codes(sqlite3 db, int onoff)
		{
			return Provider.sqlite3_extended_result_codes(db, onoff);
		}

		public static int sqlite3_errcode(sqlite3 db)
		{
			return Provider.sqlite3_errcode(db);
		}

		public static int sqlite3_extended_errcode(sqlite3 db)
		{
			return Provider.sqlite3_extended_errcode(db);
		}

		public static utf8z sqlite3_errstr(int rc)
		{
			return Provider.sqlite3_errstr(rc);
		}

		public static int sqlite3_prepare_v2(sqlite3 db, ReadOnlySpan<byte> sql, out sqlite3_stmt stmt)
		{
			IntPtr stmt2;
			ReadOnlySpan<byte> remain;
			int result = Provider.sqlite3_prepare_v2(db, sql, out stmt2, out remain);
			stmt = sqlite3_stmt.From(stmt2, db);
			return result;
		}

		public static int sqlite3_prepare_v2(sqlite3 db, utf8z sql, out sqlite3_stmt stmt)
		{
			IntPtr stmt2;
			utf8z remain;
			int result = Provider.sqlite3_prepare_v2(db, sql, out stmt2, out remain);
			stmt = sqlite3_stmt.From(stmt2, db);
			return result;
		}

		public static int sqlite3_prepare_v2(sqlite3 db, string sql, out sqlite3_stmt stmt)
		{
			return sqlite3_prepare_v2(db, sql.to_utf8z(), out stmt);
		}

		public static int sqlite3_prepare_v2(sqlite3 db, ReadOnlySpan<byte> sql, out sqlite3_stmt stmt, out ReadOnlySpan<byte> tail)
		{
			IntPtr stmt2;
			int result = Provider.sqlite3_prepare_v2(db, sql, out stmt2, out tail);
			stmt = sqlite3_stmt.From(stmt2, db);
			return result;
		}

		public static int sqlite3_prepare_v2(sqlite3 db, utf8z sql, out sqlite3_stmt stmt, out utf8z tail)
		{
			IntPtr stmt2;
			int result = Provider.sqlite3_prepare_v2(db, sql, out stmt2, out tail);
			stmt = sqlite3_stmt.From(stmt2, db);
			return result;
		}

		public static int sqlite3_prepare_v2(sqlite3 db, string sql, out sqlite3_stmt stmt, out string tail)
		{
			byte[] array = sql.to_utf8_with_z();
			ReadOnlySpan<byte> sql2 = new ReadOnlySpan<byte>(array);
			ReadOnlySpan<byte> tail2;
			int result = sqlite3_prepare_v2(db, sql2, out stmt, out tail2);
			tail = tail2.Slice(0, tail2.Length - 1).utf8_span_to_string();
			return result;
		}

		public static int sqlite3_prepare_v3(sqlite3 db, ReadOnlySpan<byte> sql, uint flags, out sqlite3_stmt stmt)
		{
			IntPtr stmt2;
			ReadOnlySpan<byte> remain;
			int result = Provider.sqlite3_prepare_v3(db, sql, flags, out stmt2, out remain);
			stmt = sqlite3_stmt.From(stmt2, db);
			return result;
		}

		public static int sqlite3_prepare_v3(sqlite3 db, utf8z sql, uint flags, out sqlite3_stmt stmt)
		{
			IntPtr stmt2;
			utf8z remain;
			int result = Provider.sqlite3_prepare_v3(db, sql, flags, out stmt2, out remain);
			stmt = sqlite3_stmt.From(stmt2, db);
			return result;
		}

		public static int sqlite3_prepare_v3(sqlite3 db, string sql, uint flags, out sqlite3_stmt stmt)
		{
			return sqlite3_prepare_v3(db, sql.to_utf8z(), flags, out stmt);
		}

		public static int sqlite3_prepare_v3(sqlite3 db, ReadOnlySpan<byte> sql, uint flags, out sqlite3_stmt stmt, out ReadOnlySpan<byte> tail)
		{
			IntPtr stmt2;
			int result = Provider.sqlite3_prepare_v3(db, sql, flags, out stmt2, out tail);
			stmt = sqlite3_stmt.From(stmt2, db);
			return result;
		}

		public static int sqlite3_prepare_v3(sqlite3 db, utf8z sql, uint flags, out sqlite3_stmt stmt, out utf8z tail)
		{
			IntPtr stmt2;
			int result = Provider.sqlite3_prepare_v3(db, sql, flags, out stmt2, out tail);
			stmt = sqlite3_stmt.From(stmt2, db);
			return result;
		}

		public static int sqlite3_prepare_v3(sqlite3 db, string sql, uint flags, out sqlite3_stmt stmt, out string tail)
		{
			utf8z tail2;
			int result = sqlite3_prepare_v3(db, sql.to_utf8z(), flags, out stmt, out tail2);
			tail = tail2.utf8_to_string();
			return result;
		}

		public static int sqlite3_exec(sqlite3 db, string sql, strdelegate_exec callback, object user_data, out string errMsg)
		{
			delegate_exec callback2 = ((callback == null) ? null : ((delegate_exec)delegate(object ob, IntPtr[] values, IntPtr[] names)
			{
				string[] array = new string[values.Length];
				string[] array2 = new string[names.Length];
				for (int i = 0; i < values.Length; i++)
				{
					array[i] = util.from_utf8_z(values[i]);
					array2[i] = util.from_utf8_z(names[i]);
				}
				return callback(ob, array, array2);
			}));
			IntPtr errMsg2;
			int result = Provider.sqlite3_exec(db, sql.to_utf8z(), callback2, user_data, out errMsg2);
			if (errMsg2 == IntPtr.Zero)
			{
				errMsg = null;
				return result;
			}
			errMsg = util.from_utf8_z(errMsg2);
			Provider.sqlite3_free(errMsg2);
			return result;
		}

		public static int sqlite3_exec(sqlite3 db, string sql, out string errMsg)
		{
			IntPtr errMsg2;
			int result = Provider.sqlite3_exec(db, sql.to_utf8z(), null, null, out errMsg2);
			if (errMsg2 == IntPtr.Zero)
			{
				errMsg = null;
				return result;
			}
			errMsg = util.from_utf8_z(errMsg2);
			Provider.sqlite3_free(errMsg2);
			return result;
		}

		public static int sqlite3_exec(sqlite3 db, string sql)
		{
			IntPtr errMsg;
			int result = Provider.sqlite3_exec(db, sql.to_utf8z(), null, null, out errMsg);
			if (!(errMsg == IntPtr.Zero))
			{
				Provider.sqlite3_free(errMsg);
			}
			return result;
		}

		public static int sqlite3_step(sqlite3_stmt stmt)
		{
			return Provider.sqlite3_step(stmt);
		}

		public static int sqlite3_finalize(sqlite3_stmt stmt)
		{
			return stmt.manual_close();
		}

		public static int internal_sqlite3_finalize(IntPtr stmt)
		{
			return Provider.sqlite3_finalize(stmt);
		}

		public static int sqlite3_reset(sqlite3_stmt stmt)
		{
			return Provider.sqlite3_reset(stmt);
		}

		public static int sqlite3_clear_bindings(sqlite3_stmt stmt)
		{
			return Provider.sqlite3_clear_bindings(stmt);
		}

		public static int sqlite3_stmt_status(sqlite3_stmt stmt, int op, int resetFlg)
		{
			return Provider.sqlite3_stmt_status(stmt, op, resetFlg);
		}

		public static int sqlite3_complete(utf8z sql)
		{
			return Provider.sqlite3_complete(sql);
		}

		public static int sqlite3_complete(string sql)
		{
			return sqlite3_complete(sql.to_utf8z());
		}

		public static int sqlite3_compileoption_used(utf8z s)
		{
			return Provider.sqlite3_compileoption_used(s);
		}

		public static int sqlite3_compileoption_used(string s)
		{
			return sqlite3_compileoption_used(s.to_utf8z());
		}

		public static utf8z sqlite3_compileoption_get(int n)
		{
			return Provider.sqlite3_compileoption_get(n);
		}

		public static int sqlite3_table_column_metadata(sqlite3 db, utf8z dbName, utf8z tblName, utf8z colName, out utf8z dataType, out utf8z collSeq, out int notNull, out int primaryKey, out int autoInc)
		{
			return Provider.sqlite3_table_column_metadata(db, dbName, tblName, colName, out dataType, out collSeq, out notNull, out primaryKey, out autoInc);
		}

		public static int sqlite3_table_column_metadata(sqlite3 db, string dbName, string tblName, string colName, out string dataType, out string collSeq, out int notNull, out int primaryKey, out int autoInc)
		{
			utf8z dataType2;
			utf8z collSeq2;
			int result = sqlite3_table_column_metadata(db, dbName.to_utf8z(), tblName.to_utf8z(), colName.to_utf8z(), out dataType2, out collSeq2, out notNull, out primaryKey, out autoInc);
			dataType = dataType2.utf8_to_string();
			collSeq = collSeq2.utf8_to_string();
			return result;
		}

		public static utf8z sqlite3_sql(sqlite3_stmt stmt)
		{
			return Provider.sqlite3_sql(stmt);
		}

		public static sqlite3 sqlite3_db_handle(sqlite3_stmt stmt)
		{
			return stmt.db;
		}

		public static sqlite3_stmt sqlite3_next_stmt(sqlite3 db, sqlite3_stmt stmt)
		{
			IntPtr intPtr = Provider.sqlite3_next_stmt(db, stmt?.ptr ?? IntPtr.Zero);
			if (intPtr == IntPtr.Zero)
			{
				return null;
			}
			return db.find_stmt(intPtr);
		}

		public static int sqlite3_bind_zeroblob(sqlite3_stmt stmt, int index, int size)
		{
			return Provider.sqlite3_bind_zeroblob(stmt, index, size);
		}

		public static utf8z sqlite3_bind_parameter_name(sqlite3_stmt stmt, int index)
		{
			return Provider.sqlite3_bind_parameter_name(stmt, index);
		}

		public static object sqlite3_user_data(sqlite3_context context)
		{
			return context.user_data;
		}

		public static void sqlite3_result_null(sqlite3_context context)
		{
			Provider.sqlite3_result_null(context.ptr);
		}

		public static void sqlite3_result_blob(sqlite3_context context, ReadOnlySpan<byte> val)
		{
			Provider.sqlite3_result_blob(context.ptr, val);
		}

		public static void sqlite3_result_error(sqlite3_context context, ReadOnlySpan<byte> val)
		{
			Provider.sqlite3_result_error(context.ptr, val);
		}

		public static void sqlite3_result_error(sqlite3_context context, utf8z val)
		{
			Provider.sqlite3_result_error(context.ptr, val);
		}

		public static void sqlite3_result_error(sqlite3_context context, string val)
		{
			sqlite3_result_error(context, val.to_utf8z());
		}

		public static void sqlite3_result_text(sqlite3_context context, ReadOnlySpan<byte> val)
		{
			Provider.sqlite3_result_text(context.ptr, val);
		}

		public static void sqlite3_result_text(sqlite3_context context, utf8z val)
		{
			Provider.sqlite3_result_text(context.ptr, val);
		}

		public static void sqlite3_result_text(sqlite3_context context, string val)
		{
			sqlite3_result_text(context, val.to_utf8z());
		}

		public static void sqlite3_result_double(sqlite3_context context, double val)
		{
			Provider.sqlite3_result_double(context.ptr, val);
		}

		public static void sqlite3_result_int(sqlite3_context context, int val)
		{
			Provider.sqlite3_result_int(context.ptr, val);
		}

		public static void sqlite3_result_int64(sqlite3_context context, long val)
		{
			Provider.sqlite3_result_int64(context.ptr, val);
		}

		public static void sqlite3_result_zeroblob(sqlite3_context context, int n)
		{
			Provider.sqlite3_result_zeroblob(context.ptr, n);
		}

		public static void sqlite3_result_error_toobig(sqlite3_context context)
		{
			Provider.sqlite3_result_error_toobig(context.ptr);
		}

		public static void sqlite3_result_error_nomem(sqlite3_context context)
		{
			Provider.sqlite3_result_error_nomem(context.ptr);
		}

		public static void sqlite3_result_error_code(sqlite3_context context, int code)
		{
			Provider.sqlite3_result_error_code(context.ptr, code);
		}

		public static ReadOnlySpan<byte> sqlite3_value_blob(sqlite3_value val)
		{
			return Provider.sqlite3_value_blob(val.ptr);
		}

		public static int sqlite3_value_bytes(sqlite3_value val)
		{
			return Provider.sqlite3_value_bytes(val.ptr);
		}

		public static double sqlite3_value_double(sqlite3_value val)
		{
			return Provider.sqlite3_value_double(val.ptr);
		}

		public static int sqlite3_value_int(sqlite3_value val)
		{
			return Provider.sqlite3_value_int(val.ptr);
		}

		public static long sqlite3_value_int64(sqlite3_value val)
		{
			return Provider.sqlite3_value_int64(val.ptr);
		}

		public static int sqlite3_value_type(sqlite3_value val)
		{
			return Provider.sqlite3_value_type(val.ptr);
		}

		public static utf8z sqlite3_value_text(sqlite3_value val)
		{
			return Provider.sqlite3_value_text(val.ptr);
		}

		public static int sqlite3_bind_blob(sqlite3_stmt stmt, int index, ReadOnlySpan<byte> blob)
		{
			return Provider.sqlite3_bind_blob(stmt, index, blob);
		}

		public static int sqlite3_bind_double(sqlite3_stmt stmt, int index, double val)
		{
			return Provider.sqlite3_bind_double(stmt, index, val);
		}

		public static int sqlite3_bind_int(sqlite3_stmt stmt, int index, int val)
		{
			return Provider.sqlite3_bind_int(stmt, index, val);
		}

		public static int sqlite3_bind_int64(sqlite3_stmt stmt, int index, long val)
		{
			return Provider.sqlite3_bind_int64(stmt, index, val);
		}

		public static int sqlite3_bind_null(sqlite3_stmt stmt, int index)
		{
			return Provider.sqlite3_bind_null(stmt, index);
		}

		public static int sqlite3_bind_text(sqlite3_stmt stmt, int index, ReadOnlySpan<byte> val)
		{
			return Provider.sqlite3_bind_text(stmt, index, val);
		}

		public static int sqlite3_bind_text(sqlite3_stmt stmt, int index, utf8z val)
		{
			return Provider.sqlite3_bind_text(stmt, index, val);
		}

		public static int sqlite3_bind_text(sqlite3_stmt stmt, int index, string val)
		{
			return sqlite3_bind_text(stmt, index, val.to_utf8z());
		}

		public static int sqlite3_bind_parameter_count(sqlite3_stmt stmt)
		{
			return Provider.sqlite3_bind_parameter_count(stmt);
		}

		public static int sqlite3_bind_parameter_index(sqlite3_stmt stmt, utf8z strName)
		{
			return Provider.sqlite3_bind_parameter_index(stmt, strName);
		}

		public static int sqlite3_bind_parameter_index(sqlite3_stmt stmt, string strName)
		{
			return sqlite3_bind_parameter_index(stmt, strName.to_utf8z());
		}

		public static int sqlite3_stmt_isexplain(sqlite3_stmt stmt)
		{
			return _imp.sqlite3_stmt_isexplain(stmt);
		}

		public static int sqlite3_stmt_busy(sqlite3_stmt stmt)
		{
			return Provider.sqlite3_stmt_busy(stmt);
		}

		public static int sqlite3_stmt_readonly(sqlite3_stmt stmt)
		{
			return Provider.sqlite3_stmt_readonly(stmt);
		}

		public static utf8z sqlite3_column_database_name(sqlite3_stmt stmt, int index)
		{
			return Provider.sqlite3_column_database_name(stmt, index);
		}

		public static utf8z sqlite3_column_name(sqlite3_stmt stmt, int index)
		{
			return Provider.sqlite3_column_name(stmt, index);
		}

		public static utf8z sqlite3_column_origin_name(sqlite3_stmt stmt, int index)
		{
			return Provider.sqlite3_column_origin_name(stmt, index);
		}

		public static utf8z sqlite3_column_table_name(sqlite3_stmt stmt, int index)
		{
			return Provider.sqlite3_column_table_name(stmt, index);
		}

		public static utf8z sqlite3_column_text(sqlite3_stmt stmt, int index)
		{
			return Provider.sqlite3_column_text(stmt, index);
		}

		public static int sqlite3_column_count(sqlite3_stmt stmt)
		{
			return Provider.sqlite3_column_count(stmt);
		}

		public static int sqlite3_data_count(sqlite3_stmt stmt)
		{
			return Provider.sqlite3_data_count(stmt);
		}

		public static double sqlite3_column_double(sqlite3_stmt stmt, int index)
		{
			return Provider.sqlite3_column_double(stmt, index);
		}

		public static int sqlite3_column_int(sqlite3_stmt stmt, int index)
		{
			return Provider.sqlite3_column_int(stmt, index);
		}

		public static long sqlite3_column_int64(sqlite3_stmt stmt, int index)
		{
			return Provider.sqlite3_column_int64(stmt, index);
		}

		public static ReadOnlySpan<byte> sqlite3_column_blob(sqlite3_stmt stmt, int index)
		{
			return Provider.sqlite3_column_blob(stmt, index);
		}

		public static int sqlite3_column_bytes(sqlite3_stmt stmt, int index)
		{
			return Provider.sqlite3_column_bytes(stmt, index);
		}

		public static int sqlite3_column_type(sqlite3_stmt stmt, int index)
		{
			return Provider.sqlite3_column_type(stmt, index);
		}

		public static utf8z sqlite3_column_decltype(sqlite3_stmt stmt, int index)
		{
			return Provider.sqlite3_column_decltype(stmt, index);
		}

		public static sqlite3_backup sqlite3_backup_init(sqlite3 destDb, string destName, sqlite3 sourceDb, string sourceName)
		{
			return Provider.sqlite3_backup_init(destDb, destName.to_utf8z(), sourceDb, sourceName.to_utf8z());
		}

		public static int sqlite3_backup_step(sqlite3_backup backup, int nPage)
		{
			return Provider.sqlite3_backup_step(backup, nPage);
		}

		public static int sqlite3_backup_remaining(sqlite3_backup backup)
		{
			return Provider.sqlite3_backup_remaining(backup);
		}

		public static int sqlite3_backup_pagecount(sqlite3_backup backup)
		{
			return Provider.sqlite3_backup_pagecount(backup);
		}

		public static int sqlite3_backup_finish(sqlite3_backup backup)
		{
			return backup.manual_close();
		}

		internal static int internal_sqlite3_backup_finish(IntPtr p)
		{
			return Provider.sqlite3_backup_finish(p);
		}

		public static int sqlite3_blob_open(sqlite3 db, utf8z db_utf8, utf8z table_utf8, utf8z col_utf8, long rowid, int flags, out sqlite3_blob blob)
		{
			return Provider.sqlite3_blob_open(db, db_utf8, table_utf8, col_utf8, rowid, flags, out blob);
		}

		public static int sqlite3_blob_open(sqlite3 db, string sdb, string table, string col, long rowid, int flags, out sqlite3_blob blob)
		{
			return sqlite3_blob_open(db, sdb.to_utf8z(), table.to_utf8z(), col.to_utf8z(), rowid, flags, out blob);
		}

		public static int sqlite3_blob_bytes(sqlite3_blob blob)
		{
			return Provider.sqlite3_blob_bytes(blob);
		}

		public static int sqlite3_blob_reopen(sqlite3_blob blob, long rowid)
		{
			return Provider.sqlite3_blob_reopen(blob, rowid);
		}

		public static int sqlite3_blob_write(sqlite3_blob blob, ReadOnlySpan<byte> b, int offset)
		{
			return Provider.sqlite3_blob_write(blob, b, offset);
		}

		public static int sqlite3_blob_read(sqlite3_blob blob, Span<byte> b, int offset)
		{
			return Provider.sqlite3_blob_read(blob, b, offset);
		}

		public static int sqlite3_blob_close(sqlite3_blob blob)
		{
			return blob.manual_close();
		}

		internal static int internal_sqlite3_blob_close(IntPtr blob)
		{
			return Provider.sqlite3_blob_close(blob);
		}

		public static int sqlite3_wal_autocheckpoint(sqlite3 db, int n)
		{
			return Provider.sqlite3_wal_autocheckpoint(db, n);
		}

		public static int sqlite3_wal_checkpoint(sqlite3 db, string dbName)
		{
			return Provider.sqlite3_wal_checkpoint(db, dbName.to_utf8z());
		}

		public static int sqlite3_wal_checkpoint_v2(sqlite3 db, string dbName, int eMode, out int logSize, out int framesCheckPointed)
		{
			return Provider.sqlite3_wal_checkpoint_v2(db, dbName.to_utf8z(), eMode, out logSize, out framesCheckPointed);
		}

		public static int sqlite3_set_authorizer(sqlite3 db, delegate_authorizer f, object user_data)
		{
			return Provider.sqlite3_set_authorizer(db, f, user_data);
		}

		public static int sqlite3_set_authorizer(sqlite3 db, strdelegate_authorizer f, object user_data)
		{
			delegate_authorizer f2 = ((f != null) ? ((delegate_authorizer)((object ob, int a, utf8z p0, utf8z p1, utf8z dbname, utf8z v) => f(ob, a, p0.utf8_to_string(), p1.utf8_to_string(), dbname.utf8_to_string(), v.utf8_to_string()))) : null);
			return sqlite3_set_authorizer(db, f2, user_data);
		}

		public static int sqlite3_win32_set_directory(int typ, string path)
		{
			return Provider.sqlite3_win32_set_directory(typ, path.to_utf8z());
		}
	}
	public class sqlite3_backup : SafeHandle
	{
		public override bool IsInvalid => handle == IntPtr.Zero;

		private sqlite3_backup()
			: base(IntPtr.Zero, ownsHandle: true)
		{
		}

		protected override bool ReleaseHandle()
		{
			raw.internal_sqlite3_backup_finish(handle);
			return true;
		}

		public int manual_close()
		{
			int result = raw.internal_sqlite3_backup_finish(handle);
			handle = IntPtr.Zero;
			return result;
		}
	}
	public class sqlite3_context
	{
		private IntPtr _p;

		private object _user_data;

		public object state;

		internal object user_data => _user_data;

		internal IntPtr ptr => _p;

		protected sqlite3_context(object user_data)
		{
			_user_data = user_data;
		}

		protected void set_context_ptr(IntPtr p)
		{
			_p = p;
		}
	}
	public class sqlite3_value
	{
		private IntPtr _p;

		internal IntPtr ptr => _p;

		public sqlite3_value(IntPtr p)
		{
			_p = p;
		}
	}
	public class sqlite3_blob : SafeHandle
	{
		public override bool IsInvalid => handle == IntPtr.Zero;

		private sqlite3_blob()
			: base(IntPtr.Zero, ownsHandle: true)
		{
		}

		protected override bool ReleaseHandle()
		{
			raw.internal_sqlite3_blob_close(handle);
			return true;
		}

		public int manual_close()
		{
			int result = raw.internal_sqlite3_blob_close(handle);
			handle = IntPtr.Zero;
			return result;
		}
	}
	public class sqlite3_stmt : SafeHandle
	{
		private sqlite3 _db;

		public override bool IsInvalid => handle == IntPtr.Zero;

		internal IntPtr ptr => handle;

		internal sqlite3 db => _db;

		internal static sqlite3_stmt From(IntPtr p, sqlite3 db)
		{
			sqlite3_stmt sqlite3_stmt2 = new sqlite3_stmt();
			sqlite3_stmt2.SetHandle(p);
			db.add_stmt(sqlite3_stmt2);
			sqlite3_stmt2._db = db;
			return sqlite3_stmt2;
		}

		private sqlite3_stmt()
			: base(IntPtr.Zero, ownsHandle: true)
		{
		}

		protected override bool ReleaseHandle()
		{
			raw.internal_sqlite3_finalize(handle);
			_db.remove_stmt(this);
			return true;
		}

		public int manual_close()
		{
			int result = raw.internal_sqlite3_finalize(handle);
			handle = IntPtr.Zero;
			_db.remove_stmt(this);
			return result;
		}
	}
	public class sqlite3 : SafeHandle
	{
		private ConcurrentDictionary<IntPtr, sqlite3_stmt> _stmts;

		private IDisposable extra;

		public override bool IsInvalid => handle == IntPtr.Zero;

		private sqlite3()
			: base(IntPtr.Zero, ownsHandle: true)
		{
		}

		protected override bool ReleaseHandle()
		{
			raw.internal_sqlite3_close_v2(handle);
			dispose_extra();
			return true;
		}

		public int manual_close_v2()
		{
			int result = raw.internal_sqlite3_close_v2(handle);
			handle = IntPtr.Zero;
			dispose_extra();
			return result;
		}

		public int manual_close()
		{
			int result = raw.internal_sqlite3_close(handle);
			handle = IntPtr.Zero;
			dispose_extra();
			return result;
		}

		internal static sqlite3 New(IntPtr p)
		{
			sqlite3 obj = new sqlite3();
			obj.SetHandle(p);
			return obj;
		}

		public void enable_sqlite3_next_stmt(bool enabled)
		{
			if (enabled)
			{
				if (_stmts == null)
				{
					_stmts = new ConcurrentDictionary<IntPtr, sqlite3_stmt>();
				}
			}
			else
			{
				_stmts = null;
			}
		}

		internal void add_stmt(sqlite3_stmt stmt)
		{
			if (_stmts != null)
			{
				_stmts[stmt.ptr] = stmt;
			}
		}

		internal sqlite3_stmt find_stmt(IntPtr p)
		{
			if (_stmts != null)
			{
				return _stmts[p];
			}
			throw new Exception("The sqlite3_next_stmt() function is disabled.  To enable it, call sqlite3.enable_sqlite3_next_stmt(true) immediately after opening the sqlite3 connection.");
		}

		internal void remove_stmt(sqlite3_stmt s)
		{
			if (_stmts != null)
			{
				_stmts.TryRemove(s.ptr, out var _);
			}
		}

		public T GetOrCreateExtra<T>(Func<T> f) where T : class, IDisposable
		{
			if (extra != null)
			{
				return (T)extra;
			}
			return (T)(extra = f());
		}

		private void dispose_extra()
		{
			if (extra != null)
			{
				extra.Dispose();
				extra = null;
			}
		}
	}
	public delegate int delegate_collation(object user_data, ReadOnlySpan<byte> s1, ReadOnlySpan<byte> s2);
	public delegate void delegate_update(object user_data, int type, utf8z database, utf8z table, long rowid);
	public delegate void delegate_log(object user_data, int errorCode, utf8z msg);
	public delegate int delegate_authorizer(object user_data, int action_code, utf8z param0, utf8z param1, utf8z dbName, utf8z inner_most_trigger_or_view);
	public delegate int delegate_exec(object user_data, IntPtr[] values, IntPtr[] names);
	public delegate int delegate_commit(object user_data);
	public delegate void delegate_rollback(object user_data);
	public delegate void delegate_trace(object user_data, utf8z statement);
	public delegate void delegate_profile(object user_data, utf8z statement, long ns);
	public delegate int delegate_progress(object user_data);
	public delegate void delegate_function_scalar(sqlite3_context ctx, object user_data, sqlite3_value[] args);
	public delegate void delegate_function_aggregate_step(sqlite3_context ctx, object user_data, sqlite3_value[] args);
	public delegate void delegate_function_aggregate_final(sqlite3_context ctx, object user_data);
	public interface ISQLite3Provider
	{
		string GetNativeLibraryName();

		int sqlite3_open(utf8z filename, out IntPtr db);

		int sqlite3_open_v2(utf8z filename, out IntPtr db, int flags, utf8z vfs);

		int sqlite3_close_v2(IntPtr db);

		int sqlite3_close(IntPtr db);

		int sqlite3_enable_shared_cache(int enable);

		void sqlite3_interrupt(sqlite3 db);

		int sqlite3__vfs__delete(utf8z vfs, utf8z pathname, int syncDir);

		int sqlite3_threadsafe();

		utf8z sqlite3_libversion();

		int sqlite3_libversion_number();

		utf8z sqlite3_sourceid();

		long sqlite3_memory_used();

		long sqlite3_memory_highwater(int resetFlag);

		int sqlite3_status(int op, out int current, out int highwater, int resetFlag);

		int sqlite3_db_readonly(sqlite3 db, utf8z dbName);

		utf8z sqlite3_db_filename(sqlite3 db, utf8z att);

		utf8z sqlite3_errmsg(sqlite3 db);

		long sqlite3_last_insert_rowid(sqlite3 db);

		int sqlite3_changes(sqlite3 db);

		int sqlite3_total_changes(sqlite3 db);

		int sqlite3_get_autocommit(sqlite3 db);

		int sqlite3_busy_timeout(sqlite3 db, int ms);

		int sqlite3_extended_result_codes(sqlite3 db, int onoff);

		int sqlite3_errcode(sqlite3 db);

		int sqlite3_extended_errcode(sqlite3 db);

		utf8z sqlite3_errstr(int rc);

		int sqlite3_prepare_v2(sqlite3 db, ReadOnlySpan<byte> sql, out IntPtr stmt, out ReadOnlySpan<byte> remain);

		int sqlite3_prepare_v3(sqlite3 db, ReadOnlySpan<byte> sql, uint flags, out IntPtr stmt, out ReadOnlySpan<byte> remain);

		int sqlite3_prepare_v2(sqlite3 db, utf8z sql, out IntPtr stmt, out utf8z remain);

		int sqlite3_prepare_v3(sqlite3 db, utf8z sql, uint flags, out IntPtr stmt, out utf8z remain);

		int sqlite3_step(sqlite3_stmt stmt);

		int sqlite3_finalize(IntPtr stmt);

		int sqlite3_reset(sqlite3_stmt stmt);

		int sqlite3_clear_bindings(sqlite3_stmt stmt);

		int sqlite3_stmt_status(sqlite3_stmt stmt, int op, int resetFlg);

		utf8z sqlite3_sql(sqlite3_stmt stmt);

		IntPtr sqlite3_db_handle(IntPtr stmt);

		IntPtr sqlite3_next_stmt(sqlite3 db, IntPtr stmt);

		int sqlite3_bind_zeroblob(sqlite3_stmt stmt, int index, int size);

		utf8z sqlite3_bind_parameter_name(sqlite3_stmt stmt, int index);

		int sqlite3_bind_blob(sqlite3_stmt stmt, int index, ReadOnlySpan<byte> blob);

		int sqlite3_bind_double(sqlite3_stmt stmt, int index, double val);

		int sqlite3_bind_int(sqlite3_stmt stmt, int index, int val);

		int sqlite3_bind_int64(sqlite3_stmt stmt, int index, long val);

		int sqlite3_bind_null(sqlite3_stmt stmt, int index);

		int sqlite3_bind_text(sqlite3_stmt stmt, int index, ReadOnlySpan<byte> text);

		int sqlite3_bind_text(sqlite3_stmt stmt, int index, utf8z text);

		int sqlite3_bind_parameter_count(sqlite3_stmt stmt);

		int sqlite3_bind_parameter_index(sqlite3_stmt stmt, utf8z strName);

		utf8z sqlite3_column_database_name(sqlite3_stmt stmt, int index);

		utf8z sqlite3_column_name(sqlite3_stmt stmt, int index);

		utf8z sqlite3_column_origin_name(sqlite3_stmt stmt, int index);

		utf8z sqlite3_column_table_name(sqlite3_stmt stmt, int index);

		utf8z sqlite3_column_text(sqlite3_stmt stmt, int index);

		int sqlite3_data_count(sqlite3_stmt stmt);

		int sqlite3_column_count(sqlite3_stmt stmt);

		double sqlite3_column_double(sqlite3_stmt stmt, int index);

		int sqlite3_column_int(sqlite3_stmt stmt, int index);

		long sqlite3_column_int64(sqlite3_stmt stmt, int index);

		ReadOnlySpan<byte> sqlite3_column_blob(sqlite3_stmt stmt, int index);

		int sqlite3_column_bytes(sqlite3_stmt stmt, int index);

		int sqlite3_column_type(sqlite3_stmt stmt, int index);

		utf8z sqlite3_column_decltype(sqlite3_stmt stmt, int index);

		sqlite3_backup sqlite3_backup_init(sqlite3 destDb, utf8z destName, sqlite3 sourceDb, utf8z sourceName);

		int sqlite3_backup_step(sqlite3_backup backup, int nPage);

		int sqlite3_backup_remaining(sqlite3_backup backup);

		int sqlite3_backup_pagecount(sqlite3_backup backup);

		int sqlite3_backup_finish(IntPtr backup);

		int sqlite3_blob_open(sqlite3 db, utf8z db_utf8, utf8z table_utf8, utf8z col_utf8, long rowid, int flags, out sqlite3_blob blob);

		int sqlite3_blob_bytes(sqlite3_blob blob);

		int sqlite3_blob_reopen(sqlite3_blob blob, long rowid);

		int sqlite3_blob_write(sqlite3_blob blob, ReadOnlySpan<byte> b, int offset);

		int sqlite3_blob_read(sqlite3_blob blob, Span<byte> b, int offset);

		int sqlite3_blob_close(IntPtr blob);

		int sqlite3_config_log(delegate_log func, object v);

		void sqlite3_log(int errcode, utf8z s);

		void sqlite3_commit_hook(sqlite3 db, delegate_commit func, object v);

		void sqlite3_rollback_hook(sqlite3 db, delegate_rollback func, object v);

		void sqlite3_trace(sqlite3 db, delegate_trace func, object v);

		void sqlite3_profile(sqlite3 db, delegate_profile func, object v);

		void sqlite3_progress_handler(sqlite3 db, int instructions, delegate_progress func, object v);

		void sqlite3_update_hook(sqlite3 db, delegate_update func, object v);

		int sqlite3_create_collation(sqlite3 db, byte[] name, object v, delegate_collation func);

		int sqlite3_create_function(sqlite3 db, byte[] name, int nArg, int flags, object v, delegate_function_scalar func);

		int sqlite3_create_function(sqlite3 db, byte[] name, int nArg, int flags, object v, delegate_function_aggregate_step func_step, delegate_function_aggregate_final func_final);

		int sqlite3_db_status(sqlite3 db, int op, out int current, out int highest, int resetFlg);

		void sqlite3_result_blob(IntPtr context, ReadOnlySpan<byte> val);

		void sqlite3_result_double(IntPtr context, double val);

		void sqlite3_result_error(IntPtr context, ReadOnlySpan<byte> strErr);

		void sqlite3_result_error(IntPtr context, utf8z strErr);

		void sqlite3_result_int(IntPtr context, int val);

		void sqlite3_result_int64(IntPtr context, long val);

		void sqlite3_result_null(IntPtr context);

		void sqlite3_result_text(IntPtr context, ReadOnlySpan<byte> val);

		void sqlite3_result_text(IntPtr context, utf8z val);

		void sqlite3_result_zeroblob(IntPtr context, int n);

		void sqlite3_result_error_toobig(IntPtr context);

		void sqlite3_result_error_nomem(IntPtr context);

		void sqlite3_result_error_code(IntPtr context, int code);

		ReadOnlySpan<byte> sqlite3_value_blob(IntPtr p);

		int sqlite3_value_bytes(IntPtr p);

		double sqlite3_value_double(IntPtr p);

		int sqlite3_value_int(IntPtr p);

		long sqlite3_value_int64(IntPtr p);

		int sqlite3_value_type(IntPtr p);

		utf8z sqlite3_value_text(IntPtr p);

		int sqlite3_stmt_isexplain(sqlite3_stmt stmt);

		int sqlite3_stmt_busy(sqlite3_stmt stmt);

		int sqlite3_stmt_readonly(sqlite3_stmt stmt);

		int sqlite3_exec(sqlite3 db, utf8z sql, delegate_exec callback, object user_data, out IntPtr errMsg);

		int sqlite3_complete(utf8z sql);

		int sqlite3_compileoption_used(utf8z sql);

		utf8z sqlite3_compileoption_get(int n);

		int sqlite3_wal_autocheckpoint(sqlite3 db, int n);

		int sqlite3_wal_checkpoint(sqlite3 db, utf8z dbName);

		int sqlite3_wal_checkpoint_v2(sqlite3 db, utf8z dbName, int eMode, out int logSize, out int framesCheckPointed);

		int sqlite3_table_column_metadata(sqlite3 db, utf8z dbName, utf8z tblName, utf8z colName, out utf8z dataType, out utf8z collSeq, out int notNull, out int primaryKey, out int autoInc);

		int sqlite3_set_authorizer(sqlite3 db, delegate_authorizer authorizer, object user_data);

		int sqlite3_stricmp(IntPtr p, IntPtr q);

		int sqlite3_strnicmp(IntPtr p, IntPtr q, int n);

		void sqlite3_free(IntPtr p);

		int sqlite3_key(sqlite3 db, ReadOnlySpan<byte> key);

		int sqlite3_key_v2(sqlite3 db, utf8z dbname, ReadOnlySpan<byte> key);

		int sqlite3_rekey(sqlite3 db, ReadOnlySpan<byte> key);

		int sqlite3_rekey_v2(sqlite3 db, utf8z dbname, ReadOnlySpan<byte> key);

		int sqlite3_initialize();

		int sqlite3_shutdown();

		int sqlite3_config(int op);

		int sqlite3_config(int op, int val);

		int sqlite3_enable_load_extension(sqlite3 db, int enable);

		int sqlite3_win32_set_directory(int typ, utf8z path);
	}
	internal static class util
	{
		public static utf8z to_utf8z(this string s)
		{
			return utf8z.FromString(s);
		}

		public static byte[] to_utf8_with_z(this string sourceText)
		{
			if (sourceText == null)
			{
				return null;
			}
			byte[] array = new byte[Encoding.UTF8.GetByteCount(sourceText) + 1];
			int bytes = Encoding.UTF8.GetBytes(sourceText, 0, sourceText.Length, array, 0);
			array[bytes] = 0;
			return array;
		}

		private static int my_strlen(IntPtr nativeString)
		{
			int i = 0;
			if (nativeString != IntPtr.Zero)
			{
				for (; Marshal.ReadByte(nativeString, i) > 0; i++)
				{
				}
			}
			return i;
		}

		public static string from_utf8_z(IntPtr nativeString)
		{
			return from_utf8(nativeString, my_strlen(nativeString));
		}

		public unsafe static string from_utf8(IntPtr nativeString, int size)
		{
			string result = null;
			if (nativeString != IntPtr.Zero)
			{
				result = Encoding.UTF8.GetString((byte*)nativeString.ToPointer(), size);
			}
			return result;
		}
	}
	public readonly ref struct utf8z
	{
		private readonly ReadOnlySpan<byte> sp;

		public ref readonly byte GetPinnableReference()
		{
			return ref sp.GetPinnableReference();
		}

		private utf8z(ReadOnlySpan<byte> a)
		{
			sp = a;
		}

		private static utf8z FromSpan(ReadOnlySpan<byte> a)
		{
			if (a.Length > 0 && a[a.Length - 1] != 0)
			{
				throw new ArgumentException("zero terminator required");
			}
			return new utf8z(a);
		}

		public static utf8z FromString(string s)
		{
			if (s == null)
			{
				return new utf8z(ReadOnlySpan<byte>.Empty);
			}
			return new utf8z(s.to_utf8_with_z());
		}

		private unsafe static long my_strlen(byte* p)
		{
			byte* ptr;
			for (ptr = p; *ptr != 0; ptr++)
			{
			}
			return ptr - p;
		}

		private unsafe static ReadOnlySpan<byte> find_zero_terminator(byte* p)
		{
			int num = (int)my_strlen(p);
			return new ReadOnlySpan<byte>(p, num + 1);
		}

		public unsafe static utf8z FromPtr(byte* p)
		{
			if (p == null)
			{
				return new utf8z(ReadOnlySpan<byte>.Empty);
			}
			return new utf8z(find_zero_terminator(p));
		}

		public unsafe static utf8z FromPtrLen(byte* p, int len)
		{
			if (p == null)
			{
				return new utf8z(ReadOnlySpan<byte>.Empty);
			}
			return FromSpan(new ReadOnlySpan<byte>(p, len + 1));
		}

		public unsafe static utf8z FromIntPtr(IntPtr p)
		{
			if (p == IntPtr.Zero)
			{
				return new utf8z(ReadOnlySpan<byte>.Empty);
			}
			return new utf8z(find_zero_terminator((byte*)p.ToPointer()));
		}

		public unsafe string utf8_to_string()
		{
			if (sp.Length == 0)
			{
				return null;
			}
			fixed (byte* bytes = sp)
			{
				return Encoding.UTF8.GetString(bytes, sp.Length - 1);
			}
		}
	}
	public sealed class PreserveAttribute : Attribute
	{
		public bool AllMembers;

		public bool Conditional;
	}
	public sealed class MonoPInvokeCallbackAttribute : Attribute
	{
		public MonoPInvokeCallbackAttribute(Type t)
		{
		}
	}
	public class SafeGCHandle : SafeHandle
	{
		public override bool IsInvalid => handle == IntPtr.Zero;

		public SafeGCHandle(object v, GCHandleType typ)
			: base(IntPtr.Zero, ownsHandle: true)
		{
			if (v != null)
			{
				GCHandle value = GCHandle.Alloc(v, typ);
				SetHandle(GCHandle.ToIntPtr(value));
			}
		}

		protected override bool ReleaseHandle()
		{
			GCHandle.FromIntPtr(handle).Free();
			return true;
		}
	}
	public class hook_handle : SafeGCHandle
	{
		public hook_handle(object target)
			: base(target, GCHandleType.Normal)
		{
		}

		public IDisposable ForDispose()
		{
			if (IsInvalid)
			{
				return null;
			}
			return this;
		}
	}
	internal class CompareBuf : EqualityComparer<byte[]>
	{
		private Func<IntPtr, IntPtr, int, bool> _f;

		public CompareBuf(Func<IntPtr, IntPtr, int, bool> f)
		{
			_f = f;
		}

		public override bool Equals(byte[] p1, byte[] p2)
		{
			if (p1.Length != p2.Length)
			{
				return false;
			}
			GCHandle gCHandle = GCHandle.Alloc(p1, GCHandleType.Pinned);
			GCHandle gCHandle2 = GCHandle.Alloc(p2, GCHandleType.Pinned);
			bool result = _f(gCHandle.AddrOfPinnedObject(), gCHandle2.AddrOfPinnedObject(), p1.Length);
			gCHandle.Free();
			gCHandle2.Free();
			return result;
		}

		public override int GetHashCode(byte[] p)
		{
			return p.Length;
		}
	}
	internal class FuncName
	{
		public byte[] name { get; private set; }

		public int n { get; private set; }

		public FuncName(byte[] _name, int _n)
		{
			name = _name;
			n = _n;
		}
	}
	internal class CompareFuncName : EqualityComparer<FuncName>
	{
		private IEqualityComparer<byte[]> _ptrlencmp;

		public CompareFuncName(IEqualityComparer<byte[]> ptrlencmp)
		{
			_ptrlencmp = ptrlencmp;
		}

		public override bool Equals(FuncName p1, FuncName p2)
		{
			if (p1.n != p2.n)
			{
				return false;
			}
			return _ptrlencmp.Equals(p1.name, p2.name);
		}

		public override int GetHashCode(FuncName p)
		{
			return p.n + p.name.Length;
		}
	}
	public class hook_handles : IDisposable
	{
		private readonly ConcurrentDictionary<byte[], IDisposable> collation;

		private readonly ConcurrentDictionary<FuncName, IDisposable> scalar;

		private readonly ConcurrentDictionary<FuncName, IDisposable> agg;

		public IDisposable update;

		public IDisposable rollback;

		public IDisposable commit;

		public IDisposable trace;

		public IDisposable profile;

		public IDisposable progress;

		public IDisposable authorizer;

		public hook_handles(Func<IntPtr, IntPtr, int, bool> f)
		{
			CompareBuf compareBuf = new CompareBuf(f);
			collation = new ConcurrentDictionary<byte[], IDisposable>(compareBuf);
			scalar = new ConcurrentDictionary<FuncName, IDisposable>(new CompareFuncName(compareBuf));
			agg = new ConcurrentDictionary<FuncName, IDisposable>(new CompareFuncName(compareBuf));
		}

		public bool RemoveScalarFunction(byte[] name, int nargs)
		{
			FuncName key = new FuncName(name, nargs);
			if (scalar.TryRemove(key, out var value))
			{
				value.Dispose();
				return true;
			}
			return false;
		}

		public void AddScalarFunction(byte[] name, int nargs, IDisposable d)
		{
			FuncName key = new FuncName(name, nargs);
			scalar[key] = d;
		}

		public bool RemoveAggFunction(byte[] name, int nargs)
		{
			FuncName key = new FuncName(name, nargs);
			if (agg.TryRemove(key, out var value))
			{
				value.Dispose();
				return true;
			}
			return false;
		}

		public void AddAggFunction(byte[] name, int nargs, IDisposable d)
		{
			FuncName key = new FuncName(name, nargs);
			agg[key] = d;
		}

		public bool RemoveCollation(byte[] name)
		{
			if (collation.TryRemove(name, out var value))
			{
				value.Dispose();
				return true;
			}
			return false;
		}

		public void AddCollation(byte[] name, IDisposable d)
		{
			collation[name] = d;
		}

		public void Dispose()
		{
			foreach (IDisposable value in collation.Values)
			{
				value.Dispose();
			}
			foreach (IDisposable value2 in scalar.Values)
			{
				value2.Dispose();
			}
			foreach (IDisposable value3 in agg.Values)
			{
				value3.Dispose();
			}
			if (update != null)
			{
				update.Dispose();
			}
			if (rollback != null)
			{
				rollback.Dispose();
			}
			if (commit != null)
			{
				commit.Dispose();
			}
			if (trace != null)
			{
				trace.Dispose();
			}
			if (profile != null)
			{
				profile.Dispose();
			}
			if (progress != null)
			{
				progress.Dispose();
			}
			if (authorizer != null)
			{
				authorizer.Dispose();
			}
		}
	}
	public class log_hook_info
	{
		private delegate_log _func;

		private object _user_data;

		public log_hook_info(delegate_log func, object v)
		{
			_func = func;
			_user_data = v;
		}

		public static log_hook_info from_ptr(IntPtr p)
		{
			return ((GCHandle)p).Target as log_hook_info;
		}

		public void call(int rc, utf8z msg)
		{
			_func(_user_data, rc, msg);
		}
	}
	public class commit_hook_info
	{
		public delegate_commit _func { get; private set; }

		public object _user_data { get; private set; }

		public commit_hook_info(delegate_commit func, object v)
		{
			_func = func;
			_user_data = v;
		}

		public int call()
		{
			return _func(_user_data);
		}

		public static commit_hook_info from_ptr(IntPtr p)
		{
			return ((GCHandle)p).Target as commit_hook_info;
		}
	}
	public class rollback_hook_info
	{
		private delegate_rollback _func;

		private object _user_data;

		public rollback_hook_info(delegate_rollback func, object v)
		{
			_func = func;
			_user_data = v;
		}

		public static rollback_hook_info from_ptr(IntPtr p)
		{
			return ((GCHandle)p).Target as rollback_hook_info;
		}

		public void call()
		{
			_func(_user_data);
		}
	}
	public class trace_hook_info
	{
		private delegate_trace _func;

		private object _user_data;

		public trace_hook_info(delegate_trace func, object v)
		{
			_func = func;
			_user_data = v;
		}

		public static trace_hook_info from_ptr(IntPtr p)
		{
			return ((GCHandle)p).Target as trace_hook_info;
		}

		public void call(utf8z s)
		{
			_func(_user_data, s);
		}
	}
	public class profile_hook_info
	{
		private delegate_profile _func;

		private object _user_data;

		public profile_hook_info(delegate_profile func, object v)
		{
			_func = func;
			_user_data = v;
		}

		public static profile_hook_info from_ptr(IntPtr p)
		{
			return ((GCHandle)p).Target as profile_hook_info;
		}

		public void call(utf8z s, long elapsed)
		{
			_func(_user_data, s, elapsed);
		}
	}
	public class progress_hook_info
	{
		private delegate_progress _func;

		private object _user_data;

		public progress_hook_info(delegate_progress func, object v)
		{
			_func = func;
			_user_data = v;
		}

		public static progress_hook_info from_ptr(IntPtr p)
		{
			return ((GCHandle)p).Target as progress_hook_info;
		}

		public int call()
		{
			return _func(_user_data);
		}
	}
	public class update_hook_info
	{
		private delegate_update _func;

		private object _user_data;

		public update_hook_info(delegate_update func, object v)
		{
			_func = func;
			_user_data = v;
		}

		public static update_hook_info from_ptr(IntPtr p)
		{
			return ((GCHandle)p).Target as update_hook_info;
		}

		public void call(int typ, utf8z db, utf8z tbl, long rowid)
		{
			_func(_user_data, typ, db, tbl, rowid);
		}
	}
	public class collation_hook_info
	{
		private delegate_collation _func;

		private object _user_data;

		public collation_hook_info(delegate_collation func, object v)
		{
			_func = func;
			_user_data = v;
		}

		public static collation_hook_info from_ptr(IntPtr p)
		{
			return ((GCHandle)p).Target as collation_hook_info;
		}

		public int call(ReadOnlySpan<byte> s1, ReadOnlySpan<byte> s2)
		{
			return _func(_user_data, s1, s2);
		}
	}
	public class exec_hook_info
	{
		private delegate_exec _func;

		private object _user_data;

		public exec_hook_info(delegate_exec func, object v)
		{
			_func = func;
			_user_data = v;
		}

		public static exec_hook_info from_ptr(IntPtr p)
		{
			return ((GCHandle)p).Target as exec_hook_info;
		}

		public int call(int n, IntPtr values_ptr, IntPtr names_ptr)
		{
			IntPtr[] array = new IntPtr[n];
			IntPtr[] array2 = new IntPtr[n];
			int num = Marshal.SizeOf(typeof(IntPtr));
			for (int i = 0; i < n; i++)
			{
				IntPtr intPtr = Marshal.ReadIntPtr(values_ptr, i * num);
				array[i] = intPtr;
				intPtr = Marshal.ReadIntPtr(names_ptr, i * num);
				array2[i] = intPtr;
			}
			return _func(_user_data, array, array2);
		}
	}
	public class function_hook_info
	{
		private class agg_sqlite3_context : sqlite3_context
		{
			public agg_sqlite3_context(object v)
				: base(v)
			{
			}

			public void fix_ptr(IntPtr p)
			{
				set_context_ptr(p);
			}
		}

		private class scalar_sqlite3_context : sqlite3_context
		{
			public scalar_sqlite3_context(IntPtr p, object v)
				: base(v)
			{
				set_context_ptr(p);
			}
		}

		private delegate_function_scalar _func_scalar;

		private delegate_function_aggregate_step _func_step;

		private delegate_function_aggregate_final _func_final;

		private object _user_data;

		public function_hook_info(delegate_function_scalar func_scalar, object user_data)
		{
			_func_scalar = func_scalar;
			_user_data = user_data;
		}

		public function_hook_info(delegate_function_aggregate_step func_step, delegate_function_aggregate_final func_final, object user_data)
		{
			_func_step = func_step;
			_func_final = func_final;
			_user_data = user_data;
		}

		public static function_hook_info from_ptr(IntPtr p)
		{
			return ((GCHandle)p).Target as function_hook_info;
		}

		private sqlite3_context get_context(IntPtr context, IntPtr agg_context)
		{
			IntPtr intPtr = Marshal.ReadIntPtr(agg_context);
			agg_sqlite3_context agg_sqlite3_context2;
			if (intPtr == IntPtr.Zero)
			{
				agg_sqlite3_context2 = new agg_sqlite3_context(_user_data);
				GCHandle gCHandle = GCHandle.Alloc(agg_sqlite3_context2);
				Marshal.WriteIntPtr(agg_context, (IntPtr)gCHandle);
			}
			else
			{
				agg_sqlite3_context2 = ((GCHandle)intPtr).Target as agg_sqlite3_context;
			}
			agg_sqlite3_context2.fix_ptr(context);
			return agg_sqlite3_context2;
		}

		public void call_scalar(IntPtr context, int num_args, IntPtr argsptr)
		{
			scalar_sqlite3_context ctx = new scalar_sqlite3_context(context, _user_data);
			sqlite3_value[] array = new sqlite3_value[num_args];
			int num = Marshal.SizeOf(typeof(IntPtr));
			for (int i = 0; i < num_args; i++)
			{
				IntPtr p = Marshal.ReadIntPtr(argsptr, i * num);
				array[i] = new sqlite3_value(p);
			}
			_func_scalar(ctx, _user_data, array);
		}

		public void call_step(IntPtr context, IntPtr agg_context, int num_args, IntPtr argsptr)
		{
			sqlite3_context ctx = get_context(context, agg_context);
			sqlite3_value[] array = new sqlite3_value[num_args];
			int num = Marshal.SizeOf(typeof(IntPtr));
			for (int i = 0; i < num_args; i++)
			{
				IntPtr p = Marshal.ReadIntPtr(argsptr, i * num);
				array[i] = new sqlite3_value(p);
			}
			_func_step(ctx, _user_data, array);
		}

		public void call_final(IntPtr context, IntPtr agg_context)
		{
			sqlite3_context ctx = get_context(context, agg_context);
			_func_final(ctx, _user_data);
			((GCHandle)Marshal.ReadIntPtr(agg_context)).Free();
		}
	}
	public class authorizer_hook_info
	{
		private delegate_authorizer _func;

		private object _user_data;

		public authorizer_hook_info(delegate_authorizer func, object v)
		{
			_func = func;
			_user_data = v;
		}

		public static authorizer_hook_info from_ptr(IntPtr p)
		{
			return ((GCHandle)p).Target as authorizer_hook_info;
		}

		public int call(int action_code, utf8z param0, utf8z param1, utf8z dbName, utf8z inner_most_trigger_or_view)
		{
			return _func(_user_data, action_code, param0, param1, dbName, inner_most_trigger_or_view);
		}
	}
	public sealed class EntryPointAttribute : Attribute
	{
		public string Name { get; private set; }

		public EntryPointAttribute(string name)
		{
			Name = name;
		}
	}
	public interface IGetFunctionPointer
	{
		IntPtr GetFunctionPointer(string name);
	}
}
