using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Threading;
using System.Transactions;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("System.Data.SQLite")]
[assembly: AssemblyDescription("ADO.NET 2.0 Data Provider for SQLite")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("http://sqlite.phxsoftware.com")]
[assembly: AssemblyProduct("System.Data.SQLite")]
[assembly: AssemblyCopyright("Public Domain")]
[assembly: AssemblyTrademark("")]
[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]
[assembly: AllowPartiallyTrustedCallers]
[assembly: ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
[assembly: SecurityRules(SecurityRuleSet.Level1)]
[assembly: AssemblyFileVersion("1.0.61.0")]
[assembly: AssemblyDelaySign(true)]
[assembly: AssemblyVersion("2.0.5.0")]
[module: UnverifiableCode]
namespace Mono.Data.Sqlite;

public sealed class SqliteConnection : DbConnection, ICloneable
{
	private ConnectionState _connectionState;

	private string _connectionString;

	internal int _transactionLevel;

	private System.Data.IsolationLevel _defaultIsolation;

	internal SQLiteEnlistment _enlistment;

	internal SQLiteBase _sql;

	private string _dataSource;

	private byte[] _password;

	private int _defaultTimeout = 30;

	internal bool _binaryGuid;

	internal long _version;

	[CompilerGenerated]
	private SQLiteUpdateEventHandler _updateHandler;

	[CompilerGenerated]
	private SQLiteCommitHandler _commitHandler;

	[CompilerGenerated]
	private EventHandler _rollbackHandler;

	private SQLiteUpdateCallback _updateCallback;

	private SQLiteCommitCallback _commitCallback;

	private SQLiteRollbackCallback _rollbackCallback;

	[CompilerGenerated]
	private StateChangeEventHandler StateChange;

	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue("")]
	[Editor("SQLite.Designer.SqliteConnectionStringEditor, SQLite.Designer, Version=1.0.36.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public override string ConnectionString
	{
		get
		{
			return _connectionString;
		}
		set
		{
			if (value == null)
			{
				throw new ArgumentNullException();
			}
			if (_connectionState != ConnectionState.Closed)
			{
				throw new InvalidOperationException();
			}
			_connectionString = value;
		}
	}

	public int DefaultTimeout => _defaultTimeout;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public override ConnectionState State => _connectionState;

	public SqliteConnection()
		: this("")
	{
	}

	public SqliteConnection(string connectionString)
	{
		_sql = null;
		_connectionState = ConnectionState.Closed;
		_connectionString = "";
		_transactionLevel = 0;
		_version = 0L;
		if (connectionString != null)
		{
			ConnectionString = connectionString;
		}
	}

	public SqliteConnection(SqliteConnection connection)
		: this(connection.ConnectionString)
	{
		if (connection.State != ConnectionState.Open)
		{
			return;
		}
		Open();
		using DataTable dataTable = connection.GetSchema("Catalogs");
		foreach (DataRow row in dataTable.Rows)
		{
			string strA = row[0].ToString();
			if (string.Compare(strA, "main", ignoreCase: true, CultureInfo.InvariantCulture) != 0 && string.Compare(strA, "temp", ignoreCase: true, CultureInfo.InvariantCulture) != 0)
			{
				using SqliteCommand sqliteCommand = CreateCommand();
				sqliteCommand.CommandText = string.Format(CultureInfo.InvariantCulture, "ATTACH DATABASE '{0}' AS [{1}]", row[1], row[0]);
				sqliteCommand.ExecuteNonQuery();
			}
		}
	}

	public object Clone()
	{
		return new SqliteConnection(this);
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (_sql != null)
		{
			_sql.Dispose();
		}
		if (disposing)
		{
			Close();
		}
	}

	public static void CreateFile(string databaseFileName)
	{
		File.Create(databaseFileName).Close();
	}

	internal void OnStateChange(ConnectionState newState)
	{
		ConnectionState connectionState = _connectionState;
		_connectionState = newState;
		if (StateChange != null && connectionState != newState)
		{
			StateChangeEventArgs e = new StateChangeEventArgs(connectionState, newState);
			StateChange(this, e);
		}
	}

	public SqliteTransaction BeginTransaction()
	{
		return (SqliteTransaction)BeginDbTransaction(_defaultIsolation);
	}

	protected override DbTransaction BeginDbTransaction(System.Data.IsolationLevel isolationLevel)
	{
		if (_connectionState != ConnectionState.Open)
		{
			throw new InvalidOperationException();
		}
		if (isolationLevel == System.Data.IsolationLevel.Unspecified)
		{
			isolationLevel = _defaultIsolation;
		}
		if (isolationLevel != System.Data.IsolationLevel.Serializable && isolationLevel != System.Data.IsolationLevel.ReadCommitted)
		{
			throw new ArgumentException("isolationLevel");
		}
		return new SqliteTransaction(this, isolationLevel != System.Data.IsolationLevel.Serializable);
	}

	public override void Close()
	{
		if (_sql != null)
		{
			if (_enlistment != null)
			{
				SqliteConnection sqliteConnection = new SqliteConnection();
				sqliteConnection._sql = _sql;
				sqliteConnection._transactionLevel = _transactionLevel;
				sqliteConnection._enlistment = _enlistment;
				sqliteConnection._connectionState = _connectionState;
				sqliteConnection._version = _version;
				sqliteConnection._enlistment._transaction._cnn = sqliteConnection;
				sqliteConnection._enlistment._disposeConnection = true;
				_sql = null;
				_enlistment = null;
			}
			if (_sql != null)
			{
				_sql.Close();
			}
			_sql = null;
			_transactionLevel = 0;
		}
		OnStateChange(ConnectionState.Closed);
	}

	public new SqliteCommand CreateCommand()
	{
		return new SqliteCommand(this);
	}

	protected override DbCommand CreateDbCommand()
	{
		return CreateCommand();
	}

	internal static void MapMonoKeyword(string[] arPiece, SortedList<string, string> ls)
	{
		string key;
		string value;
		if (arPiece[0].ToLower(CultureInfo.InvariantCulture) == "uri")
		{
			key = "Data Source";
			value = MapMonoUriPath(arPiece[1]);
		}
		else
		{
			key = arPiece[0];
			value = arPiece[1];
		}
		ls.Add(key, value);
	}

	internal static string MapMonoUriPath(string path)
	{
		if (path.StartsWith("file://"))
		{
			return path.Substring(7);
		}
		if (path.StartsWith("file:"))
		{
			return path.Substring(5);
		}
		if (path.StartsWith("/"))
		{
			return path;
		}
		throw new InvalidOperationException("Invalid connection string: invalid URI");
	}

	internal static string MapUriPath(string path)
	{
		if (path.StartsWith("file://"))
		{
			return path.Substring(7);
		}
		if (path.StartsWith("file:"))
		{
			return path.Substring(5);
		}
		if (path.StartsWith("/"))
		{
			return path;
		}
		throw new InvalidOperationException("Invalid connection string: invalid URI");
	}

	internal static SortedList<string, string> ParseConnectionString(string connectionString)
	{
		string source = connectionString.Replace(',', ';');
		SortedList<string, string> sortedList = new SortedList<string, string>(StringComparer.OrdinalIgnoreCase);
		string[] array = SqliteConvert.Split(source, ';');
		int num = array.Length;
		for (int i = 0; i < num; i++)
		{
			string[] array2 = SqliteConvert.Split(array[i], '=');
			if (array2.Length == 2)
			{
				MapMonoKeyword(array2, sortedList);
				continue;
			}
			throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid ConnectionString format for parameter \"{0}\"", (array2.Length != 0) ? array2[0] : "null"));
		}
		return sortedList;
	}

	public override void EnlistTransaction(Transaction transaction)
	{
		if (_transactionLevel > 0 && transaction != null)
		{
			throw new ArgumentException("Unable to enlist in transaction, a local transaction already exists");
		}
		if (_enlistment != null && transaction != _enlistment._scope)
		{
			throw new ArgumentException("Already enlisted in a transaction");
		}
		_enlistment = new SQLiteEnlistment(this, transaction);
	}

	internal static string FindKey(SortedList<string, string> items, string key, string defValue)
	{
		if (items.TryGetValue(key, out var value))
		{
			return value;
		}
		return defValue;
	}

	public override void Open()
	{
		if (_connectionState != ConnectionState.Closed)
		{
			throw new InvalidOperationException();
		}
		Close();
		SortedList<string, string> items = ParseConnectionString(_connectionString);
		if (Convert.ToInt32(FindKey(items, "Version", "3"), CultureInfo.InvariantCulture) != 3)
		{
			throw new NotSupportedException("Only SQLite Version 3 is supported at this time");
		}
		string text = FindKey(items, "Data Source", "");
		if (string.IsNullOrEmpty(text))
		{
			text = FindKey(items, "Uri", "");
			if (string.IsNullOrEmpty(text))
			{
				throw new ArgumentException("Data Source cannot be empty.  Use :memory: to open an in-memory database");
			}
			text = MapUriPath(text);
		}
		text = ((string.Compare(text, ":MEMORY:", ignoreCase: true, CultureInfo.InvariantCulture) != 0) ? ExpandFileName(text) : ":memory:");
		try
		{
			bool usePool = SqliteConvert.ToBoolean(FindKey(items, "Pooling", bool.FalseString));
			bool num = SqliteConvert.ToBoolean(FindKey(items, "UseUTF16Encoding", bool.FalseString));
			int maxPoolSize = Convert.ToInt32(FindKey(items, "Max Pool Size", "100"));
			_defaultTimeout = Convert.ToInt32(FindKey(items, "Default Timeout", "30"), CultureInfo.CurrentCulture);
			_defaultIsolation = (System.Data.IsolationLevel)Enum.Parse(typeof(System.Data.IsolationLevel), FindKey(items, "Default IsolationLevel", "Serializable"), ignoreCase: true);
			if (_defaultIsolation != System.Data.IsolationLevel.Serializable && _defaultIsolation != System.Data.IsolationLevel.ReadCommitted)
			{
				throw new NotSupportedException("Invalid Default IsolationLevel specified");
			}
			SQLiteDateFormats fmt = (SQLiteDateFormats)Enum.Parse(typeof(SQLiteDateFormats), FindKey(items, "DateTimeFormat", "ISO8601"), ignoreCase: true);
			if (num)
			{
				_sql = new SQLite3_UTF16(fmt);
			}
			else
			{
				_sql = new SQLite3(fmt);
			}
			SQLiteOpenFlagsEnum sQLiteOpenFlagsEnum = SQLiteOpenFlagsEnum.None;
			if (SqliteConvert.ToBoolean(FindKey(items, "Read Only", bool.FalseString)))
			{
				sQLiteOpenFlagsEnum |= SQLiteOpenFlagsEnum.ReadOnly;
			}
			else
			{
				sQLiteOpenFlagsEnum |= SQLiteOpenFlagsEnum.ReadWrite;
				if (!SqliteConvert.ToBoolean(FindKey(items, "FailIfMissing", bool.FalseString)))
				{
					sQLiteOpenFlagsEnum |= SQLiteOpenFlagsEnum.Create;
				}
			}
			if (SqliteConvert.ToBoolean(FindKey(items, "FileProtectionComplete", bool.FalseString)))
			{
				sQLiteOpenFlagsEnum |= SQLiteOpenFlagsEnum.FileProtectionComplete;
			}
			if (SqliteConvert.ToBoolean(FindKey(items, "FileProtectionCompleteUnlessOpen", bool.FalseString)))
			{
				sQLiteOpenFlagsEnum |= SQLiteOpenFlagsEnum.FileProtectionCompleteUnlessOpen;
			}
			if (SqliteConvert.ToBoolean(FindKey(items, "FileProtectionCompleteUntilFirstUserAuthentication", bool.FalseString)))
			{
				sQLiteOpenFlagsEnum |= SQLiteOpenFlagsEnum.FileProtectionCompleteUntilFirstUserAuthentication;
			}
			if (SqliteConvert.ToBoolean(FindKey(items, "FileProtectionNone", bool.FalseString)))
			{
				sQLiteOpenFlagsEnum |= SQLiteOpenFlagsEnum.FileProtectionNone;
			}
			_sql.Open(text, sQLiteOpenFlagsEnum, maxPoolSize, usePool);
			_binaryGuid = SqliteConvert.ToBoolean(FindKey(items, "BinaryGUID", bool.TrueString));
			string text2 = FindKey(items, "Password", null);
			if (!string.IsNullOrEmpty(text2))
			{
				_sql.SetPassword(Encoding.UTF8.GetBytes(text2));
			}
			else if (_password != null)
			{
				_sql.SetPassword(_password);
			}
			_password = null;
			_dataSource = Path.GetFileNameWithoutExtension(text);
			OnStateChange(ConnectionState.Open);
			_version++;
			using (SqliteCommand sqliteCommand = CreateCommand())
			{
				string text3;
				if (text != ":memory:")
				{
					text3 = FindKey(items, "Page Size", "1024");
					if (Convert.ToInt32(text3, CultureInfo.InvariantCulture) != 1024)
					{
						sqliteCommand.CommandText = string.Format(CultureInfo.InvariantCulture, "PRAGMA page_size={0}", text3);
						sqliteCommand.ExecuteNonQuery();
					}
				}
				text3 = FindKey(items, "Max Page Count", "0");
				if (Convert.ToInt32(text3, CultureInfo.InvariantCulture) != 0)
				{
					sqliteCommand.CommandText = string.Format(CultureInfo.InvariantCulture, "PRAGMA max_page_count={0}", text3);
					sqliteCommand.ExecuteNonQuery();
				}
				text3 = FindKey(items, "Legacy Format", bool.FalseString);
				sqliteCommand.CommandText = string.Format(CultureInfo.InvariantCulture, "PRAGMA legacy_file_format={0}", SqliteConvert.ToBoolean(text3) ? "ON" : "OFF");
				sqliteCommand.ExecuteNonQuery();
				text3 = FindKey(items, "Synchronous", "Normal");
				if (string.Compare(text3, "Full", StringComparison.OrdinalIgnoreCase) != 0)
				{
					sqliteCommand.CommandText = string.Format(CultureInfo.InvariantCulture, "PRAGMA synchronous={0}", text3);
					sqliteCommand.ExecuteNonQuery();
				}
				text3 = FindKey(items, "Cache Size", "2000");
				if (Convert.ToInt32(text3, CultureInfo.InvariantCulture) != 2000)
				{
					sqliteCommand.CommandText = string.Format(CultureInfo.InvariantCulture, "PRAGMA cache_size={0}", text3);
					sqliteCommand.ExecuteNonQuery();
				}
				text3 = FindKey(items, "Journal Mode", "Delete");
				if (string.Compare(text3, "Default", StringComparison.OrdinalIgnoreCase) != 0)
				{
					sqliteCommand.CommandText = string.Format(CultureInfo.InvariantCulture, "PRAGMA journal_mode={0}", text3);
					sqliteCommand.ExecuteNonQuery();
				}
			}
			if (_commitHandler != null)
			{
				_sql.SetCommitHook(_commitCallback);
			}
			if (_updateHandler != null)
			{
				_sql.SetUpdateHook(_updateCallback);
			}
			if (_rollbackHandler != null)
			{
				_sql.SetRollbackHook(_rollbackCallback);
			}
			if (Transaction.Current != null && SqliteConvert.ToBoolean(FindKey(items, "Enlist", bool.TrueString)))
			{
				EnlistTransaction(Transaction.Current);
			}
		}
		catch (SqliteException)
		{
			Close();
			throw;
		}
	}

	private string ExpandFileName(string sourceFile)
	{
		if (string.IsNullOrEmpty(sourceFile))
		{
			return sourceFile;
		}
		if (sourceFile.StartsWith("|DataDirectory|", StringComparison.OrdinalIgnoreCase))
		{
			string text = AppDomain.CurrentDomain.GetData("DataDirectory") as string;
			if (string.IsNullOrEmpty(text))
			{
				text = AppDomain.CurrentDomain.BaseDirectory;
			}
			if (sourceFile.Length > "|DataDirectory|".Length && (sourceFile["|DataDirectory|".Length] == Path.DirectorySeparatorChar || sourceFile["|DataDirectory|".Length] == Path.AltDirectorySeparatorChar))
			{
				sourceFile = sourceFile.Remove("|DataDirectory|".Length, 1);
			}
			sourceFile = Path.Combine(text, sourceFile.Substring("|DataDirectory|".Length));
		}
		sourceFile = Path.GetFullPath(sourceFile);
		return sourceFile;
	}

	public override DataTable GetSchema(string collectionName)
	{
		return GetSchema(collectionName, new string[0]);
	}

	public override DataTable GetSchema(string collectionName, string[] restrictionValues)
	{
		if (_connectionState != ConnectionState.Open)
		{
			throw new InvalidOperationException();
		}
		string[] array = new string[5];
		if (restrictionValues == null)
		{
			restrictionValues = new string[0];
		}
		restrictionValues.CopyTo(array, 0);
		switch (collectionName.ToUpper(CultureInfo.InvariantCulture))
		{
		case "METADATACOLLECTIONS":
			return Schema_MetaDataCollections();
		case "DATASOURCEINFORMATION":
			return Schema_DataSourceInformation();
		case "DATATYPES":
			return Schema_DataTypes();
		case "COLUMNS":
		case "TABLECOLUMNS":
			return Schema_Columns(array[0], array[2], array[3]);
		case "INDEXES":
			return Schema_Indexes(array[0], array[2], array[3]);
		case "TRIGGERS":
			return Schema_Triggers(array[0], array[2], array[3]);
		case "INDEXCOLUMNS":
			return Schema_IndexColumns(array[0], array[2], array[3], array[4]);
		case "TABLES":
			return Schema_Tables(array[0], array[2], array[3]);
		case "VIEWS":
			return Schema_Views(array[0], array[2]);
		case "VIEWCOLUMNS":
			return Schema_ViewColumns(array[0], array[2], array[3]);
		case "FOREIGNKEYS":
			return Schema_ForeignKeys(array[0], array[2], array[3]);
		case "CATALOGS":
			return Schema_Catalogs(array[0]);
		case "RESERVEDWORDS":
			return Schema_ReservedWords();
		default:
			throw new NotSupportedException();
		}
	}

	private static DataTable Schema_ReservedWords()
	{
		DataTable dataTable = new DataTable("MetaDataCollections");
		dataTable.Locale = CultureInfo.InvariantCulture;
		dataTable.Columns.Add("ReservedWord", typeof(string));
		dataTable.Columns.Add("MaximumVersion", typeof(string));
		dataTable.Columns.Add("MinimumVersion", typeof(string));
		dataTable.BeginLoadData();
		string[] array = SR.Keywords.Split(new char[1] { ',' });
		foreach (string value in array)
		{
			DataRow dataRow = dataTable.NewRow();
			dataRow[0] = value;
			dataTable.Rows.Add(dataRow);
		}
		dataTable.AcceptChanges();
		dataTable.EndLoadData();
		return dataTable;
	}

	private static DataTable Schema_MetaDataCollections()
	{
		DataTable dataTable = new DataTable("MetaDataCollections");
		dataTable.Locale = CultureInfo.InvariantCulture;
		dataTable.Columns.Add("CollectionName", typeof(string));
		dataTable.Columns.Add("NumberOfRestrictions", typeof(int));
		dataTable.Columns.Add("NumberOfIdentifierParts", typeof(int));
		dataTable.BeginLoadData();
		StringReader stringReader = new StringReader(SR.MetaDataCollections);
		dataTable.ReadXml((TextReader)stringReader);
		stringReader.Close();
		dataTable.AcceptChanges();
		dataTable.EndLoadData();
		return dataTable;
	}

	private DataTable Schema_DataSourceInformation()
	{
		DataTable dataTable = new DataTable("DataSourceInformation");
		dataTable.Locale = CultureInfo.InvariantCulture;
		dataTable.Columns.Add(DbMetaDataColumnNames.CompositeIdentifierSeparatorPattern, typeof(string));
		dataTable.Columns.Add(DbMetaDataColumnNames.DataSourceProductName, typeof(string));
		dataTable.Columns.Add(DbMetaDataColumnNames.DataSourceProductVersion, typeof(string));
		dataTable.Columns.Add(DbMetaDataColumnNames.DataSourceProductVersionNormalized, typeof(string));
		dataTable.Columns.Add(DbMetaDataColumnNames.GroupByBehavior, typeof(int));
		dataTable.Columns.Add(DbMetaDataColumnNames.IdentifierPattern, typeof(string));
		dataTable.Columns.Add(DbMetaDataColumnNames.IdentifierCase, typeof(int));
		dataTable.Columns.Add(DbMetaDataColumnNames.OrderByColumnsInSelect, typeof(bool));
		dataTable.Columns.Add(DbMetaDataColumnNames.ParameterMarkerFormat, typeof(string));
		dataTable.Columns.Add(DbMetaDataColumnNames.ParameterMarkerPattern, typeof(string));
		dataTable.Columns.Add(DbMetaDataColumnNames.ParameterNameMaxLength, typeof(int));
		dataTable.Columns.Add(DbMetaDataColumnNames.ParameterNamePattern, typeof(string));
		dataTable.Columns.Add(DbMetaDataColumnNames.QuotedIdentifierPattern, typeof(string));
		dataTable.Columns.Add(DbMetaDataColumnNames.QuotedIdentifierCase, typeof(int));
		dataTable.Columns.Add(DbMetaDataColumnNames.StatementSeparatorPattern, typeof(string));
		dataTable.Columns.Add(DbMetaDataColumnNames.StringLiteralPattern, typeof(string));
		dataTable.Columns.Add(DbMetaDataColumnNames.SupportedJoinOperators, typeof(int));
		dataTable.BeginLoadData();
		DataRow dataRow = dataTable.NewRow();
		dataRow.ItemArray = new object[17]
		{
			null, "SQLite", _sql.Version, _sql.Version, 3, "(^\\[\\p{Lo}\\p{Lu}\\p{Ll}_@#][\\p{Lo}\\p{Lu}\\p{Ll}\\p{Nd}@$#_]*$)|(^\\[[^\\]\\0]|\\]\\]+\\]$)|(^\\\"[^\\\"\\0]|\\\"\\\"+\\\"$)", 1, false, "{0}", "@[\\p{Lo}\\p{Lu}\\p{Ll}\\p{Lm}_@#][\\p{Lo}\\p{Lu}\\p{Ll}\\p{Lm}\\p{Nd}\\uff3f_@#\\$]*(?=\\s+|$)",
			255, "^[\\p{Lo}\\p{Lu}\\p{Ll}\\p{Lm}_@#][\\p{Lo}\\p{Lu}\\p{Ll}\\p{Lm}\\p{Nd}\\uff3f_@#\\$]*(?=\\s+|$)", "(([^\\[]|\\]\\])*)", 1, ";", "'(([^']|'')*)'", 15
		};
		dataTable.Rows.Add(dataRow);
		dataTable.AcceptChanges();
		dataTable.EndLoadData();
		return dataTable;
	}

	private DataTable Schema_Columns(string strCatalog, string strTable, string strColumn)
	{
		DataTable dataTable = new DataTable("Columns");
		dataTable.Locale = CultureInfo.InvariantCulture;
		dataTable.Columns.Add("TABLE_CATALOG", typeof(string));
		dataTable.Columns.Add("TABLE_SCHEMA", typeof(string));
		dataTable.Columns.Add("TABLE_NAME", typeof(string));
		dataTable.Columns.Add("COLUMN_NAME", typeof(string));
		dataTable.Columns.Add("COLUMN_GUID", typeof(Guid));
		dataTable.Columns.Add("COLUMN_PROPID", typeof(long));
		dataTable.Columns.Add("ORDINAL_POSITION", typeof(int));
		dataTable.Columns.Add("COLUMN_HASDEFAULT", typeof(bool));
		dataTable.Columns.Add("COLUMN_DEFAULT", typeof(string));
		dataTable.Columns.Add("COLUMN_FLAGS", typeof(long));
		dataTable.Columns.Add("IS_NULLABLE", typeof(bool));
		dataTable.Columns.Add("DATA_TYPE", typeof(string));
		dataTable.Columns.Add("TYPE_GUID", typeof(Guid));
		dataTable.Columns.Add("CHARACTER_MAXIMUM_LENGTH", typeof(int));
		dataTable.Columns.Add("CHARACTER_OCTET_LENGTH", typeof(int));
		dataTable.Columns.Add("NUMERIC_PRECISION", typeof(int));
		dataTable.Columns.Add("NUMERIC_SCALE", typeof(int));
		dataTable.Columns.Add("DATETIME_PRECISION", typeof(long));
		dataTable.Columns.Add("CHARACTER_SET_CATALOG", typeof(string));
		dataTable.Columns.Add("CHARACTER_SET_SCHEMA", typeof(string));
		dataTable.Columns.Add("CHARACTER_SET_NAME", typeof(string));
		dataTable.Columns.Add("COLLATION_CATALOG", typeof(string));
		dataTable.Columns.Add("COLLATION_SCHEMA", typeof(string));
		dataTable.Columns.Add("COLLATION_NAME", typeof(string));
		dataTable.Columns.Add("DOMAIN_CATALOG", typeof(string));
		dataTable.Columns.Add("DOMAIN_NAME", typeof(string));
		dataTable.Columns.Add("DESCRIPTION", typeof(string));
		dataTable.Columns.Add("PRIMARY_KEY", typeof(bool));
		dataTable.Columns.Add("EDM_TYPE", typeof(string));
		dataTable.Columns.Add("AUTOINCREMENT", typeof(bool));
		dataTable.Columns.Add("UNIQUE", typeof(bool));
		dataTable.BeginLoadData();
		if (string.IsNullOrEmpty(strCatalog))
		{
			strCatalog = "main";
		}
		string arg = ((string.Compare(strCatalog, "temp", ignoreCase: true, CultureInfo.InvariantCulture) == 0) ? "sqlite_temp_master" : "sqlite_master");
		using (SqliteCommand sqliteCommand = new SqliteCommand(string.Format(CultureInfo.InvariantCulture, "SELECT * FROM [{0}].[{1}] WHERE [type] LIKE 'table' OR [type] LIKE 'view'", strCatalog, arg), this))
		{
			using SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
			while (sqliteDataReader.Read())
			{
				if (!string.IsNullOrEmpty(strTable) && string.Compare(strTable, sqliteDataReader.GetString(2), ignoreCase: true, CultureInfo.InvariantCulture) != 0)
				{
					continue;
				}
				try
				{
					using SqliteCommand sqliteCommand2 = new SqliteCommand(string.Format(CultureInfo.InvariantCulture, "SELECT * FROM [{0}].[{1}]", strCatalog, sqliteDataReader.GetString(2)), this);
					using SqliteDataReader sqliteDataReader2 = sqliteCommand2.ExecuteReader(CommandBehavior.SchemaOnly);
					using DataTable dataTable2 = sqliteDataReader2.GetSchemaTable(wantUniqueInfo: true, wantDefaultValue: true);
					foreach (DataRow row in dataTable2.Rows)
					{
						if (string.Compare(row[SchemaTableColumn.ColumnName].ToString(), strColumn, ignoreCase: true, CultureInfo.InvariantCulture) == 0 || strColumn == null)
						{
							DataRow dataRow2 = dataTable.NewRow();
							dataRow2["NUMERIC_PRECISION"] = row[SchemaTableColumn.NumericPrecision];
							dataRow2["NUMERIC_SCALE"] = row[SchemaTableColumn.NumericScale];
							dataRow2["TABLE_NAME"] = sqliteDataReader.GetString(2);
							dataRow2["COLUMN_NAME"] = row[SchemaTableColumn.ColumnName];
							dataRow2["TABLE_CATALOG"] = strCatalog;
							dataRow2["ORDINAL_POSITION"] = row[SchemaTableColumn.ColumnOrdinal];
							dataRow2["COLUMN_HASDEFAULT"] = row[SchemaTableOptionalColumn.DefaultValue] != DBNull.Value;
							dataRow2["COLUMN_DEFAULT"] = row[SchemaTableOptionalColumn.DefaultValue];
							dataRow2["IS_NULLABLE"] = row[SchemaTableColumn.AllowDBNull];
							dataRow2["DATA_TYPE"] = row["DataTypeName"].ToString().ToLower(CultureInfo.InvariantCulture);
							dataRow2["EDM_TYPE"] = SqliteConvert.DbTypeToTypeName((DbType)row[SchemaTableColumn.ProviderType]).ToString().ToLower(CultureInfo.InvariantCulture);
							dataRow2["CHARACTER_MAXIMUM_LENGTH"] = row[SchemaTableColumn.ColumnSize];
							dataRow2["TABLE_SCHEMA"] = row[SchemaTableColumn.BaseSchemaName];
							dataRow2["PRIMARY_KEY"] = row[SchemaTableColumn.IsKey];
							dataRow2["AUTOINCREMENT"] = row[SchemaTableOptionalColumn.IsAutoIncrement];
							dataRow2["COLLATION_NAME"] = row["CollationType"];
							dataRow2["UNIQUE"] = row[SchemaTableColumn.IsUnique];
							dataTable.Rows.Add(dataRow2);
						}
					}
				}
				catch (SqliteException)
				{
				}
			}
		}
		dataTable.AcceptChanges();
		dataTable.EndLoadData();
		return dataTable;
	}

	private DataTable Schema_Indexes(string strCatalog, string strTable, string strIndex)
	{
		DataTable dataTable = new DataTable("Indexes");
		List<int> list = new List<int>();
		dataTable.Locale = CultureInfo.InvariantCulture;
		dataTable.Columns.Add("TABLE_CATALOG", typeof(string));
		dataTable.Columns.Add("TABLE_SCHEMA", typeof(string));
		dataTable.Columns.Add("TABLE_NAME", typeof(string));
		dataTable.Columns.Add("INDEX_CATALOG", typeof(string));
		dataTable.Columns.Add("INDEX_SCHEMA", typeof(string));
		dataTable.Columns.Add("INDEX_NAME", typeof(string));
		dataTable.Columns.Add("PRIMARY_KEY", typeof(bool));
		dataTable.Columns.Add("UNIQUE", typeof(bool));
		dataTable.Columns.Add("CLUSTERED", typeof(bool));
		dataTable.Columns.Add("TYPE", typeof(int));
		dataTable.Columns.Add("FILL_FACTOR", typeof(int));
		dataTable.Columns.Add("INITIAL_SIZE", typeof(int));
		dataTable.Columns.Add("NULLS", typeof(int));
		dataTable.Columns.Add("SORT_BOOKMARKS", typeof(bool));
		dataTable.Columns.Add("AUTO_UPDATE", typeof(bool));
		dataTable.Columns.Add("NULL_COLLATION", typeof(int));
		dataTable.Columns.Add("ORDINAL_POSITION", typeof(int));
		dataTable.Columns.Add("COLUMN_NAME", typeof(string));
		dataTable.Columns.Add("COLUMN_GUID", typeof(Guid));
		dataTable.Columns.Add("COLUMN_PROPID", typeof(long));
		dataTable.Columns.Add("COLLATION", typeof(short));
		dataTable.Columns.Add("CARDINALITY", typeof(decimal));
		dataTable.Columns.Add("PAGES", typeof(int));
		dataTable.Columns.Add("FILTER_CONDITION", typeof(string));
		dataTable.Columns.Add("INTEGRATED", typeof(bool));
		dataTable.Columns.Add("INDEX_DEFINITION", typeof(string));
		dataTable.BeginLoadData();
		if (string.IsNullOrEmpty(strCatalog))
		{
			strCatalog = "main";
		}
		string text = ((string.Compare(strCatalog, "temp", ignoreCase: true, CultureInfo.InvariantCulture) == 0) ? "sqlite_temp_master" : "sqlite_master");
		using (SqliteCommand sqliteCommand = new SqliteCommand(string.Format(CultureInfo.InvariantCulture, "SELECT * FROM [{0}].[{1}] WHERE [type] LIKE 'table'", strCatalog, text), this))
		{
			using SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
			while (sqliteDataReader.Read())
			{
				bool flag = false;
				list.Clear();
				if (!string.IsNullOrEmpty(strTable) && string.Compare(sqliteDataReader.GetString(2), strTable, ignoreCase: true, CultureInfo.InvariantCulture) != 0)
				{
					continue;
				}
				try
				{
					using SqliteCommand sqliteCommand2 = new SqliteCommand(string.Format(CultureInfo.InvariantCulture, "PRAGMA [{0}].table_info([{1}])", strCatalog, sqliteDataReader.GetString(2)), this);
					using SqliteDataReader sqliteDataReader2 = sqliteCommand2.ExecuteReader();
					while (sqliteDataReader2.Read())
					{
						if (sqliteDataReader2.GetInt32(5) == 1)
						{
							list.Add(sqliteDataReader2.GetInt32(0));
							if (string.Compare(sqliteDataReader2.GetString(2), "INTEGER", ignoreCase: true, CultureInfo.InvariantCulture) == 0)
							{
								flag = true;
							}
						}
					}
				}
				catch (SqliteException)
				{
				}
				if (list.Count == 1 && flag)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow["TABLE_CATALOG"] = strCatalog;
					dataRow["TABLE_NAME"] = sqliteDataReader.GetString(2);
					dataRow["INDEX_CATALOG"] = strCatalog;
					dataRow["PRIMARY_KEY"] = true;
					dataRow["INDEX_NAME"] = string.Format(CultureInfo.InvariantCulture, "{1}_PK_{0}", sqliteDataReader.GetString(2), text);
					dataRow["UNIQUE"] = true;
					if (string.Compare((string)dataRow["INDEX_NAME"], strIndex, ignoreCase: true, CultureInfo.InvariantCulture) == 0 || strIndex == null)
					{
						dataTable.Rows.Add(dataRow);
					}
					list.Clear();
				}
				try
				{
					using SqliteCommand sqliteCommand3 = new SqliteCommand(string.Format(CultureInfo.InvariantCulture, "PRAGMA [{0}].index_list([{1}])", strCatalog, sqliteDataReader.GetString(2)), this);
					using SqliteDataReader sqliteDataReader3 = sqliteCommand3.ExecuteReader();
					while (sqliteDataReader3.Read())
					{
						if (string.Compare(sqliteDataReader3.GetString(1), strIndex, ignoreCase: true, CultureInfo.InvariantCulture) != 0 && strIndex != null)
						{
							continue;
						}
						DataRow dataRow = dataTable.NewRow();
						dataRow["TABLE_CATALOG"] = strCatalog;
						dataRow["TABLE_NAME"] = sqliteDataReader.GetString(2);
						dataRow["INDEX_CATALOG"] = strCatalog;
						dataRow["INDEX_NAME"] = sqliteDataReader3.GetString(1);
						dataRow["UNIQUE"] = sqliteDataReader3.GetBoolean(2);
						dataRow["PRIMARY_KEY"] = false;
						using (SqliteCommand sqliteCommand4 = new SqliteCommand(string.Format(CultureInfo.InvariantCulture, "SELECT * FROM [{0}].[{2}] WHERE [type] LIKE 'index' AND [name] LIKE '{1}'", strCatalog, sqliteDataReader3.GetString(1).Replace("'", "''"), text), this))
						{
							using SqliteDataReader sqliteDataReader4 = sqliteCommand4.ExecuteReader();
							while (sqliteDataReader4.Read())
							{
								if (!sqliteDataReader4.IsDBNull(4))
								{
									dataRow["INDEX_DEFINITION"] = sqliteDataReader4.GetString(4);
									break;
								}
							}
						}
						if (list.Count > 0 && sqliteDataReader3.GetString(1).StartsWith("sqlite_autoindex_" + sqliteDataReader.GetString(2), StringComparison.InvariantCultureIgnoreCase))
						{
							using SqliteCommand sqliteCommand5 = new SqliteCommand(string.Format(CultureInfo.InvariantCulture, "PRAGMA [{0}].index_info([{1}])", strCatalog, sqliteDataReader3.GetString(1)), this);
							using SqliteDataReader sqliteDataReader5 = sqliteCommand5.ExecuteReader();
							int num = 0;
							while (sqliteDataReader5.Read())
							{
								if (!list.Contains(sqliteDataReader5.GetInt32(1)))
								{
									num = 0;
									break;
								}
								num++;
							}
							if (num == list.Count)
							{
								dataRow["PRIMARY_KEY"] = true;
								list.Clear();
							}
						}
						dataTable.Rows.Add(dataRow);
					}
				}
				catch (SqliteException)
				{
				}
			}
		}
		dataTable.AcceptChanges();
		dataTable.EndLoadData();
		return dataTable;
	}

	private DataTable Schema_Triggers(string catalog, string table, string triggerName)
	{
		DataTable dataTable = new DataTable("Triggers");
		dataTable.Locale = CultureInfo.InvariantCulture;
		dataTable.Columns.Add("TABLE_CATALOG", typeof(string));
		dataTable.Columns.Add("TABLE_SCHEMA", typeof(string));
		dataTable.Columns.Add("TABLE_NAME", typeof(string));
		dataTable.Columns.Add("TRIGGER_NAME", typeof(string));
		dataTable.Columns.Add("TRIGGER_DEFINITION", typeof(string));
		dataTable.BeginLoadData();
		if (string.IsNullOrEmpty(table))
		{
			table = null;
		}
		if (string.IsNullOrEmpty(catalog))
		{
			catalog = "main";
		}
		string arg = ((string.Compare(catalog, "temp", ignoreCase: true, CultureInfo.InvariantCulture) == 0) ? "sqlite_temp_master" : "sqlite_master");
		using (SqliteCommand sqliteCommand = new SqliteCommand(string.Format(CultureInfo.InvariantCulture, "SELECT [type], [name], [tbl_name], [rootpage], [sql], [rowid] FROM [{0}].[{1}] WHERE [type] LIKE 'trigger'", catalog, arg), this))
		{
			using SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
			while (sqliteDataReader.Read())
			{
				if ((string.Compare(sqliteDataReader.GetString(1), triggerName, ignoreCase: true, CultureInfo.InvariantCulture) == 0 || triggerName == null) && (table == null || string.Compare(table, sqliteDataReader.GetString(2), ignoreCase: true, CultureInfo.InvariantCulture) == 0))
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow["TABLE_CATALOG"] = catalog;
					dataRow["TABLE_NAME"] = sqliteDataReader.GetString(2);
					dataRow["TRIGGER_NAME"] = sqliteDataReader.GetString(1);
					dataRow["TRIGGER_DEFINITION"] = sqliteDataReader.GetString(4);
					dataTable.Rows.Add(dataRow);
				}
			}
		}
		dataTable.AcceptChanges();
		dataTable.EndLoadData();
		return dataTable;
	}

	private DataTable Schema_Tables(string strCatalog, string strTable, string strType)
	{
		DataTable dataTable = new DataTable("Tables");
		dataTable.Locale = CultureInfo.InvariantCulture;
		dataTable.Columns.Add("TABLE_CATALOG", typeof(string));
		dataTable.Columns.Add("TABLE_SCHEMA", typeof(string));
		dataTable.Columns.Add("TABLE_NAME", typeof(string));
		dataTable.Columns.Add("TABLE_TYPE", typeof(string));
		dataTable.Columns.Add("TABLE_ID", typeof(long));
		dataTable.Columns.Add("TABLE_ROOTPAGE", typeof(int));
		dataTable.Columns.Add("TABLE_DEFINITION", typeof(string));
		dataTable.BeginLoadData();
		if (string.IsNullOrEmpty(strCatalog))
		{
			strCatalog = "main";
		}
		string arg = ((string.Compare(strCatalog, "temp", ignoreCase: true, CultureInfo.InvariantCulture) == 0) ? "sqlite_temp_master" : "sqlite_master");
		using (SqliteCommand sqliteCommand = new SqliteCommand(string.Format(CultureInfo.InvariantCulture, "SELECT [type], [name], [tbl_name], [rootpage], [sql], [rowid] FROM [{0}].[{1}] WHERE [type] LIKE 'table'", strCatalog, arg), this))
		{
			using SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
			while (sqliteDataReader.Read())
			{
				string text = sqliteDataReader.GetString(0);
				if (string.Compare(sqliteDataReader.GetString(2), 0, "SQLITE_", 0, 7, ignoreCase: true, CultureInfo.InvariantCulture) == 0)
				{
					text = "SYSTEM_TABLE";
				}
				if ((string.Compare(strType, text, ignoreCase: true, CultureInfo.InvariantCulture) == 0 || strType == null) && (string.Compare(sqliteDataReader.GetString(2), strTable, ignoreCase: true, CultureInfo.InvariantCulture) == 0 || strTable == null))
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow["TABLE_CATALOG"] = strCatalog;
					dataRow["TABLE_NAME"] = sqliteDataReader.GetString(2);
					dataRow["TABLE_TYPE"] = text;
					dataRow["TABLE_ID"] = sqliteDataReader.GetInt64(5);
					dataRow["TABLE_ROOTPAGE"] = sqliteDataReader.GetInt32(3);
					dataRow["TABLE_DEFINITION"] = sqliteDataReader.GetString(4);
					dataTable.Rows.Add(dataRow);
				}
			}
		}
		dataTable.AcceptChanges();
		dataTable.EndLoadData();
		return dataTable;
	}

	private DataTable Schema_Views(string strCatalog, string strView)
	{
		DataTable dataTable = new DataTable("Views");
		dataTable.Locale = CultureInfo.InvariantCulture;
		dataTable.Columns.Add("TABLE_CATALOG", typeof(string));
		dataTable.Columns.Add("TABLE_SCHEMA", typeof(string));
		dataTable.Columns.Add("TABLE_NAME", typeof(string));
		dataTable.Columns.Add("VIEW_DEFINITION", typeof(string));
		dataTable.Columns.Add("CHECK_OPTION", typeof(bool));
		dataTable.Columns.Add("IS_UPDATABLE", typeof(bool));
		dataTable.Columns.Add("DESCRIPTION", typeof(string));
		dataTable.Columns.Add("DATE_CREATED", typeof(DateTime));
		dataTable.Columns.Add("DATE_MODIFIED", typeof(DateTime));
		dataTable.BeginLoadData();
		if (string.IsNullOrEmpty(strCatalog))
		{
			strCatalog = "main";
		}
		string arg = ((string.Compare(strCatalog, "temp", ignoreCase: true, CultureInfo.InvariantCulture) == 0) ? "sqlite_temp_master" : "sqlite_master");
		using (SqliteCommand sqliteCommand = new SqliteCommand(string.Format(CultureInfo.InvariantCulture, "SELECT * FROM [{0}].[{1}] WHERE [type] LIKE 'view'", strCatalog, arg), this))
		{
			using SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
			while (sqliteDataReader.Read())
			{
				if (string.Compare(sqliteDataReader.GetString(1), strView, ignoreCase: true, CultureInfo.InvariantCulture) == 0 || string.IsNullOrEmpty(strView))
				{
					string text = sqliteDataReader.GetString(4).Replace('\r', ' ').Replace('\n', ' ')
						.Replace('\t', ' ');
					int num = CultureInfo.InvariantCulture.CompareInfo.IndexOf(text, " AS ", CompareOptions.IgnoreCase);
					if (num > -1)
					{
						text = text.Substring(num + 4).Trim();
						DataRow dataRow = dataTable.NewRow();
						dataRow["TABLE_CATALOG"] = strCatalog;
						dataRow["TABLE_NAME"] = sqliteDataReader.GetString(2);
						dataRow["IS_UPDATABLE"] = false;
						dataRow["VIEW_DEFINITION"] = text;
						dataTable.Rows.Add(dataRow);
					}
				}
			}
		}
		dataTable.AcceptChanges();
		dataTable.EndLoadData();
		return dataTable;
	}

	private DataTable Schema_Catalogs(string strCatalog)
	{
		DataTable dataTable = new DataTable("Catalogs");
		dataTable.Locale = CultureInfo.InvariantCulture;
		dataTable.Columns.Add("CATALOG_NAME", typeof(string));
		dataTable.Columns.Add("DESCRIPTION", typeof(string));
		dataTable.Columns.Add("ID", typeof(long));
		dataTable.BeginLoadData();
		using (SqliteCommand sqliteCommand = new SqliteCommand("PRAGMA database_list", this))
		{
			using SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
			while (sqliteDataReader.Read())
			{
				if (string.Compare(sqliteDataReader.GetString(1), strCatalog, ignoreCase: true, CultureInfo.InvariantCulture) == 0 || strCatalog == null)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow["CATALOG_NAME"] = sqliteDataReader.GetString(1);
					dataRow["DESCRIPTION"] = sqliteDataReader.GetString(2);
					dataRow["ID"] = sqliteDataReader.GetInt64(0);
					dataTable.Rows.Add(dataRow);
				}
			}
		}
		dataTable.AcceptChanges();
		dataTable.EndLoadData();
		return dataTable;
	}

	private DataTable Schema_DataTypes()
	{
		DataTable dataTable = new DataTable("DataTypes");
		dataTable.Locale = CultureInfo.InvariantCulture;
		dataTable.Columns.Add("TypeName", typeof(string));
		dataTable.Columns.Add("ProviderDbType", typeof(int));
		dataTable.Columns.Add("ColumnSize", typeof(long));
		dataTable.Columns.Add("CreateFormat", typeof(string));
		dataTable.Columns.Add("CreateParameters", typeof(string));
		dataTable.Columns.Add("DataType", typeof(string));
		dataTable.Columns.Add("IsAutoIncrementable", typeof(bool));
		dataTable.Columns.Add("IsBestMatch", typeof(bool));
		dataTable.Columns.Add("IsCaseSensitive", typeof(bool));
		dataTable.Columns.Add("IsFixedLength", typeof(bool));
		dataTable.Columns.Add("IsFixedPrecisionScale", typeof(bool));
		dataTable.Columns.Add("IsLong", typeof(bool));
		dataTable.Columns.Add("IsNullable", typeof(bool));
		dataTable.Columns.Add("IsSearchable", typeof(bool));
		dataTable.Columns.Add("IsSearchableWithLike", typeof(bool));
		dataTable.Columns.Add("IsLiteralSupported", typeof(bool));
		dataTable.Columns.Add("LiteralPrefix", typeof(string));
		dataTable.Columns.Add("LiteralSuffix", typeof(string));
		dataTable.Columns.Add("IsUnsigned", typeof(bool));
		dataTable.Columns.Add("MaximumScale", typeof(short));
		dataTable.Columns.Add("MinimumScale", typeof(short));
		dataTable.Columns.Add("IsConcurrencyType", typeof(bool));
		dataTable.BeginLoadData();
		StringReader stringReader = new StringReader(SR.DataTypes);
		dataTable.ReadXml((TextReader)stringReader);
		stringReader.Close();
		dataTable.AcceptChanges();
		dataTable.EndLoadData();
		return dataTable;
	}

	private DataTable Schema_IndexColumns(string strCatalog, string strTable, string strIndex, string strColumn)
	{
		DataTable dataTable = new DataTable("IndexColumns");
		List<KeyValuePair<int, string>> list = new List<KeyValuePair<int, string>>();
		dataTable.Locale = CultureInfo.InvariantCulture;
		dataTable.Columns.Add("CONSTRAINT_CATALOG", typeof(string));
		dataTable.Columns.Add("CONSTRAINT_SCHEMA", typeof(string));
		dataTable.Columns.Add("CONSTRAINT_NAME", typeof(string));
		dataTable.Columns.Add("TABLE_CATALOG", typeof(string));
		dataTable.Columns.Add("TABLE_SCHEMA", typeof(string));
		dataTable.Columns.Add("TABLE_NAME", typeof(string));
		dataTable.Columns.Add("COLUMN_NAME", typeof(string));
		dataTable.Columns.Add("ORDINAL_POSITION", typeof(int));
		dataTable.Columns.Add("INDEX_NAME", typeof(string));
		dataTable.Columns.Add("COLLATION_NAME", typeof(string));
		dataTable.Columns.Add("SORT_MODE", typeof(string));
		dataTable.Columns.Add("CONFLICT_OPTION", typeof(int));
		if (string.IsNullOrEmpty(strCatalog))
		{
			strCatalog = "main";
		}
		string text = ((string.Compare(strCatalog, "temp", ignoreCase: true, CultureInfo.InvariantCulture) == 0) ? "sqlite_temp_master" : "sqlite_master");
		dataTable.BeginLoadData();
		using (SqliteCommand sqliteCommand = new SqliteCommand(string.Format(CultureInfo.InvariantCulture, "SELECT * FROM [{0}].[{1}] WHERE [type] LIKE 'table'", strCatalog, text), this))
		{
			using SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
			while (sqliteDataReader.Read())
			{
				bool flag = false;
				list.Clear();
				if (!string.IsNullOrEmpty(strTable) && string.Compare(sqliteDataReader.GetString(2), strTable, ignoreCase: true, CultureInfo.InvariantCulture) != 0)
				{
					continue;
				}
				try
				{
					using SqliteCommand sqliteCommand2 = new SqliteCommand(string.Format(CultureInfo.InvariantCulture, "PRAGMA [{0}].table_info([{1}])", strCatalog, sqliteDataReader.GetString(2)), this);
					using SqliteDataReader sqliteDataReader2 = sqliteCommand2.ExecuteReader();
					while (sqliteDataReader2.Read())
					{
						if (sqliteDataReader2.GetInt32(5) == 1)
						{
							list.Add(new KeyValuePair<int, string>(sqliteDataReader2.GetInt32(0), sqliteDataReader2.GetString(1)));
							if (string.Compare(sqliteDataReader2.GetString(2), "INTEGER", ignoreCase: true, CultureInfo.InvariantCulture) == 0)
							{
								flag = true;
							}
						}
					}
				}
				catch (SqliteException)
				{
				}
				if (list.Count == 1 && flag)
				{
					DataRow dataRow = dataTable.NewRow();
					dataRow["CONSTRAINT_CATALOG"] = strCatalog;
					dataRow["CONSTRAINT_NAME"] = string.Format(CultureInfo.InvariantCulture, "{1}_PK_{0}", sqliteDataReader.GetString(2), text);
					dataRow["TABLE_CATALOG"] = strCatalog;
					dataRow["TABLE_NAME"] = sqliteDataReader.GetString(2);
					dataRow["COLUMN_NAME"] = list[0].Value;
					dataRow["INDEX_NAME"] = dataRow["CONSTRAINT_NAME"];
					dataRow["ORDINAL_POSITION"] = 0;
					dataRow["COLLATION_NAME"] = "BINARY";
					dataRow["SORT_MODE"] = "ASC";
					dataRow["CONFLICT_OPTION"] = 2;
					if (string.IsNullOrEmpty(strIndex) || string.Compare(strIndex, (string)dataRow["INDEX_NAME"], ignoreCase: true, CultureInfo.InvariantCulture) == 0)
					{
						dataTable.Rows.Add(dataRow);
					}
				}
				using SqliteCommand sqliteCommand3 = new SqliteCommand(string.Format(CultureInfo.InvariantCulture, "SELECT * FROM [{0}].[{2}] WHERE [type] LIKE 'index' AND [tbl_name] LIKE '{1}'", strCatalog, sqliteDataReader.GetString(2).Replace("'", "''"), text), this);
				using SqliteDataReader sqliteDataReader3 = sqliteCommand3.ExecuteReader();
				while (sqliteDataReader3.Read())
				{
					int num = 0;
					if (!string.IsNullOrEmpty(strIndex) && string.Compare(strIndex, sqliteDataReader3.GetString(1), ignoreCase: true, CultureInfo.InvariantCulture) != 0)
					{
						continue;
					}
					try
					{
						using SqliteCommand sqliteCommand4 = new SqliteCommand(string.Format(CultureInfo.InvariantCulture, "PRAGMA [{0}].index_info([{1}])", strCatalog, sqliteDataReader3.GetString(1)), this);
						using SqliteDataReader sqliteDataReader4 = sqliteCommand4.ExecuteReader();
						while (sqliteDataReader4.Read())
						{
							DataRow dataRow = dataTable.NewRow();
							dataRow["CONSTRAINT_CATALOG"] = strCatalog;
							dataRow["CONSTRAINT_NAME"] = sqliteDataReader3.GetString(1);
							dataRow["TABLE_CATALOG"] = strCatalog;
							dataRow["TABLE_NAME"] = sqliteDataReader3.GetString(2);
							dataRow["COLUMN_NAME"] = sqliteDataReader4.GetString(2);
							dataRow["INDEX_NAME"] = sqliteDataReader3.GetString(1);
							dataRow["ORDINAL_POSITION"] = num;
							_sql.GetIndexColumnExtendedInfo(strCatalog, sqliteDataReader3.GetString(1), sqliteDataReader4.GetString(2), out var sortMode, out var onError, out var collationSequence);
							if (!string.IsNullOrEmpty(collationSequence))
							{
								dataRow["COLLATION_NAME"] = collationSequence;
							}
							dataRow["SORT_MODE"] = ((sortMode == 0) ? "ASC" : "DESC");
							dataRow["CONFLICT_OPTION"] = onError;
							num++;
							if (string.IsNullOrEmpty(strColumn) || string.Compare(strColumn, dataRow["COLUMN_NAME"].ToString(), ignoreCase: true, CultureInfo.InvariantCulture) == 0)
							{
								dataTable.Rows.Add(dataRow);
							}
						}
					}
					catch (SqliteException)
					{
					}
				}
			}
		}
		dataTable.EndLoadData();
		dataTable.AcceptChanges();
		return dataTable;
	}

	private DataTable Schema_ViewColumns(string strCatalog, string strView, string strColumn)
	{
		DataTable dataTable = new DataTable("ViewColumns");
		dataTable.Locale = CultureInfo.InvariantCulture;
		dataTable.Columns.Add("VIEW_CATALOG", typeof(string));
		dataTable.Columns.Add("VIEW_SCHEMA", typeof(string));
		dataTable.Columns.Add("VIEW_NAME", typeof(string));
		dataTable.Columns.Add("VIEW_COLUMN_NAME", typeof(string));
		dataTable.Columns.Add("TABLE_CATALOG", typeof(string));
		dataTable.Columns.Add("TABLE_SCHEMA", typeof(string));
		dataTable.Columns.Add("TABLE_NAME", typeof(string));
		dataTable.Columns.Add("COLUMN_NAME", typeof(string));
		dataTable.Columns.Add("ORDINAL_POSITION", typeof(int));
		dataTable.Columns.Add("COLUMN_HASDEFAULT", typeof(bool));
		dataTable.Columns.Add("COLUMN_DEFAULT", typeof(string));
		dataTable.Columns.Add("COLUMN_FLAGS", typeof(long));
		dataTable.Columns.Add("IS_NULLABLE", typeof(bool));
		dataTable.Columns.Add("DATA_TYPE", typeof(string));
		dataTable.Columns.Add("CHARACTER_MAXIMUM_LENGTH", typeof(int));
		dataTable.Columns.Add("NUMERIC_PRECISION", typeof(int));
		dataTable.Columns.Add("NUMERIC_SCALE", typeof(int));
		dataTable.Columns.Add("DATETIME_PRECISION", typeof(long));
		dataTable.Columns.Add("CHARACTER_SET_CATALOG", typeof(string));
		dataTable.Columns.Add("CHARACTER_SET_SCHEMA", typeof(string));
		dataTable.Columns.Add("CHARACTER_SET_NAME", typeof(string));
		dataTable.Columns.Add("COLLATION_CATALOG", typeof(string));
		dataTable.Columns.Add("COLLATION_SCHEMA", typeof(string));
		dataTable.Columns.Add("COLLATION_NAME", typeof(string));
		dataTable.Columns.Add("PRIMARY_KEY", typeof(bool));
		dataTable.Columns.Add("EDM_TYPE", typeof(string));
		dataTable.Columns.Add("AUTOINCREMENT", typeof(bool));
		dataTable.Columns.Add("UNIQUE", typeof(bool));
		if (string.IsNullOrEmpty(strCatalog))
		{
			strCatalog = "main";
		}
		string arg = ((string.Compare(strCatalog, "temp", ignoreCase: true, CultureInfo.InvariantCulture) == 0) ? "sqlite_temp_master" : "sqlite_master");
		dataTable.BeginLoadData();
		using (SqliteCommand sqliteCommand = new SqliteCommand(string.Format(CultureInfo.InvariantCulture, "SELECT * FROM [{0}].[{1}] WHERE [type] LIKE 'view'", strCatalog, arg), this))
		{
			using SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
			while (sqliteDataReader.Read())
			{
				if (!string.IsNullOrEmpty(strView) && string.Compare(strView, sqliteDataReader.GetString(2), ignoreCase: true, CultureInfo.InvariantCulture) != 0)
				{
					continue;
				}
				using SqliteCommand sqliteCommand2 = new SqliteCommand(string.Format(CultureInfo.InvariantCulture, "SELECT * FROM [{0}].[{1}]", strCatalog, sqliteDataReader.GetString(2)), this);
				string text = sqliteDataReader.GetString(4).Replace('\r', ' ').Replace('\n', ' ')
					.Replace('\t', ' ');
				int num = CultureInfo.InvariantCulture.CompareInfo.IndexOf(text, " AS ", CompareOptions.IgnoreCase);
				if (num < 0)
				{
					continue;
				}
				text = text.Substring(num + 4);
				using SqliteCommand sqliteCommand3 = new SqliteCommand(text, this);
				using SqliteDataReader sqliteDataReader2 = sqliteCommand2.ExecuteReader(CommandBehavior.SchemaOnly);
				using SqliteDataReader sqliteDataReader3 = sqliteCommand3.ExecuteReader(CommandBehavior.SchemaOnly);
				using DataTable dataTable2 = sqliteDataReader2.GetSchemaTable(wantUniqueInfo: false, wantDefaultValue: false);
				using DataTable dataTable3 = sqliteDataReader3.GetSchemaTable(wantUniqueInfo: false, wantDefaultValue: false);
				for (num = 0; num < dataTable3.Rows.Count; num++)
				{
					DataRow dataRow = dataTable2.Rows[num];
					DataRow dataRow2 = dataTable3.Rows[num];
					if (string.Compare(dataRow[SchemaTableColumn.ColumnName].ToString(), strColumn, ignoreCase: true, CultureInfo.InvariantCulture) == 0 || strColumn == null)
					{
						DataRow dataRow3 = dataTable.NewRow();
						dataRow3["VIEW_CATALOG"] = strCatalog;
						dataRow3["VIEW_NAME"] = sqliteDataReader.GetString(2);
						dataRow3["TABLE_CATALOG"] = strCatalog;
						dataRow3["TABLE_SCHEMA"] = dataRow2[SchemaTableColumn.BaseSchemaName];
						dataRow3["TABLE_NAME"] = dataRow2[SchemaTableColumn.BaseTableName];
						dataRow3["COLUMN_NAME"] = dataRow2[SchemaTableColumn.BaseColumnName];
						dataRow3["VIEW_COLUMN_NAME"] = dataRow[SchemaTableColumn.ColumnName];
						dataRow3["COLUMN_HASDEFAULT"] = dataRow[SchemaTableOptionalColumn.DefaultValue] != DBNull.Value;
						dataRow3["COLUMN_DEFAULT"] = dataRow[SchemaTableOptionalColumn.DefaultValue];
						dataRow3["ORDINAL_POSITION"] = dataRow[SchemaTableColumn.ColumnOrdinal];
						dataRow3["IS_NULLABLE"] = dataRow[SchemaTableColumn.AllowDBNull];
						dataRow3["DATA_TYPE"] = dataRow["DataTypeName"];
						dataRow3["EDM_TYPE"] = SqliteConvert.DbTypeToTypeName((DbType)dataRow[SchemaTableColumn.ProviderType]).ToString().ToLower(CultureInfo.InvariantCulture);
						dataRow3["CHARACTER_MAXIMUM_LENGTH"] = dataRow[SchemaTableColumn.ColumnSize];
						dataRow3["TABLE_SCHEMA"] = dataRow[SchemaTableColumn.BaseSchemaName];
						dataRow3["PRIMARY_KEY"] = dataRow[SchemaTableColumn.IsKey];
						dataRow3["AUTOINCREMENT"] = dataRow[SchemaTableOptionalColumn.IsAutoIncrement];
						dataRow3["COLLATION_NAME"] = dataRow["CollationType"];
						dataRow3["UNIQUE"] = dataRow[SchemaTableColumn.IsUnique];
						dataTable.Rows.Add(dataRow3);
					}
				}
			}
		}
		dataTable.EndLoadData();
		dataTable.AcceptChanges();
		return dataTable;
	}

	private DataTable Schema_ForeignKeys(string strCatalog, string strTable, string strKeyName)
	{
		DataTable dataTable = new DataTable("ForeignKeys");
		dataTable.Locale = CultureInfo.InvariantCulture;
		dataTable.Columns.Add("CONSTRAINT_CATALOG", typeof(string));
		dataTable.Columns.Add("CONSTRAINT_SCHEMA", typeof(string));
		dataTable.Columns.Add("CONSTRAINT_NAME", typeof(string));
		dataTable.Columns.Add("TABLE_CATALOG", typeof(string));
		dataTable.Columns.Add("TABLE_SCHEMA", typeof(string));
		dataTable.Columns.Add("TABLE_NAME", typeof(string));
		dataTable.Columns.Add("CONSTRAINT_TYPE", typeof(string));
		dataTable.Columns.Add("IS_DEFERRABLE", typeof(bool));
		dataTable.Columns.Add("INITIALLY_DEFERRED", typeof(bool));
		dataTable.Columns.Add("FKEY_FROM_COLUMN", typeof(string));
		dataTable.Columns.Add("FKEY_FROM_ORDINAL_POSITION", typeof(int));
		dataTable.Columns.Add("FKEY_TO_CATALOG", typeof(string));
		dataTable.Columns.Add("FKEY_TO_SCHEMA", typeof(string));
		dataTable.Columns.Add("FKEY_TO_TABLE", typeof(string));
		dataTable.Columns.Add("FKEY_TO_COLUMN", typeof(string));
		if (string.IsNullOrEmpty(strCatalog))
		{
			strCatalog = "main";
		}
		string arg = ((string.Compare(strCatalog, "temp", ignoreCase: true, CultureInfo.InvariantCulture) == 0) ? "sqlite_temp_master" : "sqlite_master");
		dataTable.BeginLoadData();
		using (SqliteCommand sqliteCommand = new SqliteCommand(string.Format(CultureInfo.InvariantCulture, "SELECT * FROM [{0}].[{1}] WHERE [type] LIKE 'table'", strCatalog, arg), this))
		{
			using SqliteDataReader sqliteDataReader = sqliteCommand.ExecuteReader();
			while (sqliteDataReader.Read())
			{
				if (!string.IsNullOrEmpty(strTable) && string.Compare(strTable, sqliteDataReader.GetString(2), ignoreCase: true, CultureInfo.InvariantCulture) != 0)
				{
					continue;
				}
				try
				{
					using SqliteCommandBuilder sqliteCommandBuilder = new SqliteCommandBuilder();
					using SqliteCommand sqliteCommand2 = new SqliteCommand(string.Format(CultureInfo.InvariantCulture, "PRAGMA [{0}].foreign_key_list([{1}])", strCatalog, sqliteDataReader.GetString(2)), this);
					using SqliteDataReader sqliteDataReader2 = sqliteCommand2.ExecuteReader();
					while (sqliteDataReader2.Read())
					{
						DataRow dataRow = dataTable.NewRow();
						dataRow["CONSTRAINT_CATALOG"] = strCatalog;
						dataRow["CONSTRAINT_NAME"] = string.Format(CultureInfo.InvariantCulture, "FK_{0}_{1}", sqliteDataReader[2], sqliteDataReader2.GetInt32(0));
						dataRow["TABLE_CATALOG"] = strCatalog;
						dataRow["TABLE_NAME"] = sqliteCommandBuilder.UnquoteIdentifier(sqliteDataReader.GetString(2));
						dataRow["CONSTRAINT_TYPE"] = "FOREIGN KEY";
						dataRow["IS_DEFERRABLE"] = false;
						dataRow["INITIALLY_DEFERRED"] = false;
						dataRow["FKEY_FROM_COLUMN"] = sqliteCommandBuilder.UnquoteIdentifier(sqliteDataReader2[3].ToString());
						dataRow["FKEY_TO_CATALOG"] = strCatalog;
						dataRow["FKEY_TO_TABLE"] = sqliteCommandBuilder.UnquoteIdentifier(sqliteDataReader2[2].ToString());
						dataRow["FKEY_TO_COLUMN"] = sqliteCommandBuilder.UnquoteIdentifier(sqliteDataReader2[4].ToString());
						dataRow["FKEY_FROM_ORDINAL_POSITION"] = sqliteDataReader2[1];
						if (string.IsNullOrEmpty(strKeyName) || string.Compare(strKeyName, dataRow["CONSTRAINT_NAME"].ToString(), ignoreCase: true, CultureInfo.InvariantCulture) == 0)
						{
							dataTable.Rows.Add(dataRow);
						}
					}
				}
				catch (SqliteException)
				{
				}
			}
		}
		dataTable.EndLoadData();
		dataTable.AcceptChanges();
		return dataTable;
	}
}
public sealed class SqliteFactory : DbProviderFactory, IServiceProvider
{
	private static Type _dbProviderServicesType;

	private static object _sqliteServices;

	public static readonly SqliteFactory Instance;

	static SqliteFactory()
	{
		Instance = new SqliteFactory();
		_dbProviderServicesType = Type.GetType("System.Data.Common.DbProviderServices, System.Data.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", throwOnError: false);
	}

	object IServiceProvider.GetService(Type serviceType)
	{
		if (serviceType == typeof(ISQLiteSchemaExtensions) || (_dbProviderServicesType != null && serviceType == _dbProviderServicesType))
		{
			return GetSQLiteProviderServicesInstance();
		}
		return null;
	}

	private object GetSQLiteProviderServicesInstance()
	{
		if (_sqliteServices == null)
		{
			Type type = Type.GetType("Mono.Data.Sqlite.SQLiteProviderServices, Mono.Data.Sqlite.Linq, Version=2.0.38.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139", throwOnError: false);
			if (type != null)
			{
				_sqliteServices = type.GetField("Instance", BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic).GetValue(null);
			}
		}
		return _sqliteServices;
	}
}
internal class SQLite3 : SQLiteBase
{
	protected SqliteConnectionHandle _sql;

	protected string _fileName;

	protected bool _usePool;

	protected int _poolVersion;

	private bool _buildingSchema;

	protected SqliteFunction[] _functionsArray;

	internal override string Version => SQLiteVersion;

	internal static string SQLiteVersion => SqliteConvert.UTF8ToString(UnsafeNativeMethods.sqlite3_libversion(), -1);

	internal override int Changes => UnsafeNativeMethods.sqlite3_changes(_sql);

	internal SQLite3(SQLiteDateFormats fmt)
		: base(fmt)
	{
	}

	protected override void Dispose(bool bDisposing)
	{
		if (bDisposing)
		{
			Close();
		}
	}

	internal override void Close()
	{
		if (_sql != null)
		{
			if (_usePool)
			{
				SQLiteBase.ResetConnection(_sql);
				SqliteConnectionPool.Add(_fileName, _sql, _poolVersion);
			}
			else
			{
				_sql.Dispose();
			}
		}
		_sql = null;
	}

	internal override void Open(string strFilename, SQLiteOpenFlagsEnum flags, int maxPoolSize, bool usePool)
	{
		if (_sql != null)
		{
			return;
		}
		_usePool = usePool;
		if (usePool)
		{
			_fileName = strFilename;
			_sql = SqliteConnectionPool.Remove(strFilename, maxPoolSize, out _poolVersion);
		}
		if (_sql == null)
		{
			int num;
			IntPtr db;
			if (UnsafeNativeMethods.use_sqlite3_open_v2)
			{
				num = UnsafeNativeMethods.sqlite3_open_v2(SqliteConvert.ToUTF8(strFilename), out db, (int)flags, IntPtr.Zero);
			}
			else
			{
				Console.WriteLine("Your sqlite3 version is old - please upgrade to at least v3.5.0!");
				num = UnsafeNativeMethods.sqlite3_open(SqliteConvert.ToUTF8(strFilename), out db);
			}
			if (num > 0)
			{
				throw new SqliteException(num, null);
			}
			_sql = db;
		}
		_functionsArray = SqliteFunction.BindFunctions(this);
		SetTimeout(0);
	}

	internal override void SetTimeout(int nTimeoutMS)
	{
		int num = UnsafeNativeMethods.sqlite3_busy_timeout(_sql, nTimeoutMS);
		if (num > 0)
		{
			throw new SqliteException(num, SQLiteLastError());
		}
	}

	internal override bool Step(SqliteStatement stmt)
	{
		Random random = null;
		uint tickCount = (uint)Environment.TickCount;
		uint num = (uint)(stmt._command._commandTimeout * 1000);
		while (true)
		{
			int num2 = UnsafeNativeMethods.sqlite3_step(stmt._sqlite_stmt);
			if (num2 == 100)
			{
				return true;
			}
			if (num2 == 101)
			{
				break;
			}
			if (num2 <= 0)
			{
				continue;
			}
			int num3 = Reset(stmt);
			switch (num3)
			{
			case 0:
				throw new SqliteException(num2, SQLiteLastError());
			case 5:
			case 6:
				if (stmt._command != null)
				{
					if (random == null)
					{
						random = new Random();
					}
					if ((uint)(Environment.TickCount - (int)tickCount) > num)
					{
						throw new SqliteException(num3, SQLiteLastError());
					}
					Thread.CurrentThread.Join(random.Next(1, 150));
				}
				break;
			}
		}
		return false;
	}

	internal override int Reset(SqliteStatement stmt)
	{
		int num = UnsafeNativeMethods.sqlite3_reset(stmt._sqlite_stmt);
		if (num == 17)
		{
			string strRemain;
			using (SqliteStatement sqliteStatement = Prepare(null, stmt._sqlStatement, null, (uint)(stmt._command._commandTimeout * 1000), out strRemain))
			{
				stmt._sqlite_stmt.Dispose();
				stmt._sqlite_stmt = sqliteStatement._sqlite_stmt;
				sqliteStatement._sqlite_stmt = null;
				stmt.BindParameters();
			}
			return -1;
		}
		if (num == 6 || num == 5)
		{
			return num;
		}
		if (num > 0)
		{
			throw new SqliteException(num, SQLiteLastError());
		}
		return 0;
	}

	internal override string SQLiteLastError()
	{
		return SQLiteBase.SQLiteLastError(_sql);
	}

	internal override SqliteStatement Prepare(SqliteConnection cnn, string strSql, SqliteStatement previous, uint timeoutMS, out string strRemain)
	{
		IntPtr stmt = IntPtr.Zero;
		IntPtr ptrRemain = IntPtr.Zero;
		int nativestringlen = 0;
		int num = 17;
		int num2 = 0;
		byte[] array = SqliteConvert.ToUTF8(strSql);
		string text = null;
		SqliteStatement sqliteStatement = null;
		Random random = null;
		uint tickCount = (uint)Environment.TickCount;
		GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
		IntPtr pSql = gCHandle.AddrOfPinnedObject();
		try
		{
			while ((num == 17 || num == 6 || num == 5) && num2 < 3)
			{
				num = UnsafeNativeMethods.sqlite3_prepare(_sql, pSql, array.Length - 1, out stmt, out ptrRemain);
				nativestringlen = -1;
				switch (num)
				{
				case 17:
					num2++;
					break;
				case 1:
					if (string.Compare(SQLiteLastError(), "near \"TYPES\": syntax error", StringComparison.OrdinalIgnoreCase) == 0)
					{
						int num3 = strSql.IndexOf(';');
						if (num3 == -1)
						{
							num3 = strSql.Length - 1;
						}
						text = strSql.Substring(0, num3 + 1);
						strSql = strSql.Substring(num3 + 1);
						strRemain = "";
						while (sqliteStatement == null && strSql.Length > 0)
						{
							sqliteStatement = Prepare(cnn, strSql, previous, timeoutMS, out strRemain);
							strSql = strRemain;
						}
						sqliteStatement?.SetTypes(text);
						return sqliteStatement;
					}
					if (_buildingSchema || string.Compare(SQLiteLastError(), 0, "no such table: TEMP.SCHEMA", 0, 26, StringComparison.OrdinalIgnoreCase) != 0)
					{
						break;
					}
					strRemain = "";
					_buildingSchema = true;
					try
					{
						if (((IServiceProvider)SqliteFactory.Instance).GetService(typeof(ISQLiteSchemaExtensions)) is ISQLiteSchemaExtensions iSQLiteSchemaExtensions)
						{
							iSQLiteSchemaExtensions.BuildTempSchema(cnn);
						}
						while (sqliteStatement == null && strSql.Length > 0)
						{
							sqliteStatement = Prepare(cnn, strSql, previous, timeoutMS, out strRemain);
							strSql = strRemain;
						}
						return sqliteStatement;
					}
					finally
					{
						_buildingSchema = false;
					}
				case 5:
				case 6:
					if (random == null)
					{
						random = new Random();
					}
					if ((uint)(Environment.TickCount - (int)tickCount) > timeoutMS)
					{
						throw new SqliteException(num, SQLiteLastError());
					}
					Thread.CurrentThread.Join(random.Next(1, 150));
					break;
				}
			}
			if (num > 0)
			{
				throw new SqliteException(num, SQLiteLastError());
			}
			strRemain = SqliteConvert.UTF8ToString(ptrRemain, nativestringlen);
			if (stmt != IntPtr.Zero)
			{
				sqliteStatement = new SqliteStatement(this, stmt, strSql.Substring(0, strSql.Length - strRemain.Length), previous);
			}
			return sqliteStatement;
		}
		finally
		{
			gCHandle.Free();
		}
	}

	internal override void Bind_Double(SqliteStatement stmt, int index, double value)
	{
		int num = UnsafeNativeMethods.sqlite3_bind_double(stmt._sqlite_stmt, index, value);
		if (num > 0)
		{
			throw new SqliteException(num, SQLiteLastError());
		}
	}

	internal override void Bind_Int32(SqliteStatement stmt, int index, int value)
	{
		int num = UnsafeNativeMethods.sqlite3_bind_int(stmt._sqlite_stmt, index, value);
		if (num > 0)
		{
			throw new SqliteException(num, SQLiteLastError());
		}
	}

	internal override void Bind_Int64(SqliteStatement stmt, int index, long value)
	{
		int num = UnsafeNativeMethods.sqlite3_bind_int64(stmt._sqlite_stmt, index, value);
		if (num > 0)
		{
			throw new SqliteException(num, SQLiteLastError());
		}
	}

	internal override void Bind_Text(SqliteStatement stmt, int index, string value)
	{
		byte[] array = SqliteConvert.ToUTF8(value);
		int num = UnsafeNativeMethods.sqlite3_bind_text(stmt._sqlite_stmt, index, array, array.Length - 1, (IntPtr)(-1));
		if (num > 0)
		{
			throw new SqliteException(num, SQLiteLastError());
		}
	}

	internal override void Bind_DateTime(SqliteStatement stmt, int index, DateTime dt)
	{
		byte[] array = ToUTF8(dt);
		int num = UnsafeNativeMethods.sqlite3_bind_text(stmt._sqlite_stmt, index, array, array.Length - 1, (IntPtr)(-1));
		if (num > 0)
		{
			throw new SqliteException(num, SQLiteLastError());
		}
	}

	internal override void Bind_Blob(SqliteStatement stmt, int index, byte[] blobData)
	{
		int num = UnsafeNativeMethods.sqlite3_bind_blob(stmt._sqlite_stmt, index, blobData, blobData.Length, (IntPtr)(-1));
		if (num > 0)
		{
			throw new SqliteException(num, SQLiteLastError());
		}
	}

	internal override void Bind_Null(SqliteStatement stmt, int index)
	{
		int num = UnsafeNativeMethods.sqlite3_bind_null(stmt._sqlite_stmt, index);
		if (num > 0)
		{
			throw new SqliteException(num, SQLiteLastError());
		}
	}

	internal override int Bind_ParamCount(SqliteStatement stmt)
	{
		return UnsafeNativeMethods.sqlite3_bind_parameter_count(stmt._sqlite_stmt);
	}

	internal override string Bind_ParamName(SqliteStatement stmt, int index)
	{
		return SqliteConvert.UTF8ToString(UnsafeNativeMethods.sqlite3_bind_parameter_name(stmt._sqlite_stmt, index), -1);
	}

	internal override int ColumnCount(SqliteStatement stmt)
	{
		return UnsafeNativeMethods.sqlite3_column_count(stmt._sqlite_stmt);
	}

	internal override string ColumnName(SqliteStatement stmt, int index)
	{
		return SqliteConvert.UTF8ToString(UnsafeNativeMethods.sqlite3_column_name(stmt._sqlite_stmt, index), -1);
	}

	internal override TypeAffinity ColumnAffinity(SqliteStatement stmt, int index)
	{
		return UnsafeNativeMethods.sqlite3_column_type(stmt._sqlite_stmt, index);
	}

	internal override string ColumnType(SqliteStatement stmt, int index, out TypeAffinity nAffinity)
	{
		int nativestringlen = -1;
		IntPtr intPtr = UnsafeNativeMethods.sqlite3_column_decltype(stmt._sqlite_stmt, index);
		nAffinity = ColumnAffinity(stmt, index);
		if (intPtr != IntPtr.Zero)
		{
			return SqliteConvert.UTF8ToString(intPtr, nativestringlen);
		}
		string[] typeDefinitions = stmt.TypeDefinitions;
		if (typeDefinitions != null && index < typeDefinitions.Length && typeDefinitions[index] != null)
		{
			return typeDefinitions[index];
		}
		return string.Empty;
	}

	internal override string ColumnOriginalName(SqliteStatement stmt, int index)
	{
		return SqliteConvert.UTF8ToString(UnsafeNativeMethods.sqlite3_column_origin_name(stmt._sqlite_stmt, index), -1);
	}

	internal override string ColumnDatabaseName(SqliteStatement stmt, int index)
	{
		return SqliteConvert.UTF8ToString(UnsafeNativeMethods.sqlite3_column_database_name(stmt._sqlite_stmt, index), -1);
	}

	internal override string ColumnTableName(SqliteStatement stmt, int index)
	{
		return SqliteConvert.UTF8ToString(UnsafeNativeMethods.sqlite3_column_table_name(stmt._sqlite_stmt, index), -1);
	}

	internal override void ColumnMetaData(string dataBase, string table, string column, out string dataType, out string collateSequence, out bool notNull, out bool primaryKey, out bool autoIncrement)
	{
		int nativestringlen = -1;
		int nativestringlen2 = -1;
		IntPtr ptrDataType;
		IntPtr ptrCollSeq;
		int notNull2;
		int primaryKey2;
		int autoInc;
		int num = UnsafeNativeMethods.sqlite3_table_column_metadata(_sql, SqliteConvert.ToUTF8(dataBase), SqliteConvert.ToUTF8(table), SqliteConvert.ToUTF8(column), out ptrDataType, out ptrCollSeq, out notNull2, out primaryKey2, out autoInc);
		if (num > 0)
		{
			throw new SqliteException(num, SQLiteLastError());
		}
		dataType = SqliteConvert.UTF8ToString(ptrDataType, nativestringlen);
		collateSequence = SqliteConvert.UTF8ToString(ptrCollSeq, nativestringlen2);
		notNull = notNull2 == 1;
		primaryKey = primaryKey2 == 1;
		autoIncrement = autoInc == 1;
	}

	internal override double GetDouble(SqliteStatement stmt, int index)
	{
		return UnsafeNativeMethods.sqlite3_column_double(stmt._sqlite_stmt, index);
	}

	internal override int GetInt32(SqliteStatement stmt, int index)
	{
		return UnsafeNativeMethods.sqlite3_column_int(stmt._sqlite_stmt, index);
	}

	internal override long GetInt64(SqliteStatement stmt, int index)
	{
		return UnsafeNativeMethods.sqlite3_column_int64(stmt._sqlite_stmt, index);
	}

	internal override string GetText(SqliteStatement stmt, int index)
	{
		return SqliteConvert.UTF8ToString(UnsafeNativeMethods.sqlite3_column_text(stmt._sqlite_stmt, index), -1);
	}

	internal override DateTime GetDateTime(SqliteStatement stmt, int index)
	{
		return ToDateTime(UnsafeNativeMethods.sqlite3_column_text(stmt._sqlite_stmt, index), -1);
	}

	internal unsafe override long GetBytes(SqliteStatement stmt, int index, int nDataOffset, byte[] bDest, int nStart, int nLength)
	{
		int num = nLength;
		int num2 = UnsafeNativeMethods.sqlite3_column_bytes(stmt._sqlite_stmt, index);
		IntPtr intPtr = UnsafeNativeMethods.sqlite3_column_blob(stmt._sqlite_stmt, index);
		if (bDest == null)
		{
			return num2;
		}
		if (num + nStart > bDest.Length)
		{
			num = bDest.Length - nStart;
		}
		if (num + nDataOffset > num2)
		{
			num = num2 - nDataOffset;
		}
		if (num > 0)
		{
			Marshal.Copy((IntPtr)((byte*)(void*)intPtr + nDataOffset), bDest, nStart, num);
		}
		else
		{
			num = 0;
		}
		return num;
	}

	internal override bool IsNull(SqliteStatement stmt, int index)
	{
		return ColumnAffinity(stmt, index) == TypeAffinity.Null;
	}

	internal override void CreateFunction(string strFunction, int nArgs, bool needCollSeq, SQLiteCallback func, SQLiteCallback funcstep, SQLiteFinalCallback funcfinal)
	{
		int num = UnsafeNativeMethods.sqlite3_create_function(_sql, SqliteConvert.ToUTF8(strFunction), nArgs, 4, IntPtr.Zero, func, funcstep, funcfinal);
		if (num == 0)
		{
			num = UnsafeNativeMethods.sqlite3_create_function(_sql, SqliteConvert.ToUTF8(strFunction), nArgs, 1, IntPtr.Zero, func, funcstep, funcfinal);
		}
		if (num > 0)
		{
			throw new SqliteException(num, SQLiteLastError());
		}
	}

	internal override void CreateCollation(string strCollation, SQLiteCollation func, SQLiteCollation func16, IntPtr user_data)
	{
		int num = UnsafeNativeMethods.sqlite3_create_collation(_sql, SqliteConvert.ToUTF8(strCollation), 2, user_data, func16);
		if (num == 0)
		{
			UnsafeNativeMethods.sqlite3_create_collation(_sql, SqliteConvert.ToUTF8(strCollation), 1, user_data, func);
		}
		if (num > 0)
		{
			throw new SqliteException(num, SQLiteLastError());
		}
	}

	internal unsafe override long GetParamValueBytes(IntPtr p, int nDataOffset, byte[] bDest, int nStart, int nLength)
	{
		int num = nLength;
		int num2 = UnsafeNativeMethods.sqlite3_value_bytes(p);
		IntPtr intPtr = UnsafeNativeMethods.sqlite3_value_blob(p);
		if (bDest == null)
		{
			return num2;
		}
		if (num + nStart > bDest.Length)
		{
			num = bDest.Length - nStart;
		}
		if (num + nDataOffset > num2)
		{
			num = num2 - nDataOffset;
		}
		if (num > 0)
		{
			Marshal.Copy((IntPtr)((byte*)(void*)intPtr + nDataOffset), bDest, nStart, num);
		}
		else
		{
			num = 0;
		}
		return num;
	}

	internal override double GetParamValueDouble(IntPtr ptr)
	{
		return UnsafeNativeMethods.sqlite3_value_double(ptr);
	}

	internal override long GetParamValueInt64(IntPtr ptr)
	{
		return UnsafeNativeMethods.sqlite3_value_int64(ptr);
	}

	internal override string GetParamValueText(IntPtr ptr)
	{
		return SqliteConvert.UTF8ToString(UnsafeNativeMethods.sqlite3_value_text(ptr), -1);
	}

	internal override TypeAffinity GetParamValueType(IntPtr ptr)
	{
		return UnsafeNativeMethods.sqlite3_value_type(ptr);
	}

	internal override void ReturnBlob(IntPtr context, byte[] value)
	{
		UnsafeNativeMethods.sqlite3_result_blob(context, value, value.Length, (IntPtr)(-1));
	}

	internal override void ReturnDouble(IntPtr context, double value)
	{
		UnsafeNativeMethods.sqlite3_result_double(context, value);
	}

	internal override void ReturnError(IntPtr context, string value)
	{
		UnsafeNativeMethods.sqlite3_result_error(context, SqliteConvert.ToUTF8(value), value.Length);
	}

	internal override void ReturnInt64(IntPtr context, long value)
	{
		UnsafeNativeMethods.sqlite3_result_int64(context, value);
	}

	internal override void ReturnNull(IntPtr context)
	{
		UnsafeNativeMethods.sqlite3_result_null(context);
	}

	internal override void ReturnText(IntPtr context, string value)
	{
		byte[] array = SqliteConvert.ToUTF8(value);
		UnsafeNativeMethods.sqlite3_result_text(context, SqliteConvert.ToUTF8(value), array.Length - 1, (IntPtr)(-1));
	}

	internal override IntPtr AggregateContext(IntPtr context)
	{
		return UnsafeNativeMethods.sqlite3_aggregate_context(context, 1);
	}

	internal override void SetPassword(byte[] passwordBytes)
	{
		throw new PlatformNotSupportedException();
	}

	internal override void SetUpdateHook(SQLiteUpdateCallback func)
	{
		UnsafeNativeMethods.sqlite3_update_hook(_sql, func, IntPtr.Zero);
	}

	internal override void SetCommitHook(SQLiteCommitCallback func)
	{
		UnsafeNativeMethods.sqlite3_commit_hook(_sql, func, IntPtr.Zero);
	}

	internal override void SetRollbackHook(SQLiteRollbackCallback func)
	{
		UnsafeNativeMethods.sqlite3_rollback_hook(_sql, func, IntPtr.Zero);
	}

	internal override object GetValue(SqliteStatement stmt, int index, SQLiteType typ)
	{
		if (IsNull(stmt, index))
		{
			return DBNull.Value;
		}
		TypeAffinity typeAffinity = typ.Affinity;
		Type type = null;
		if (typ.Type != DbType.Object)
		{
			type = SqliteConvert.SQLiteTypeToType(typ);
			typeAffinity = SqliteConvert.TypeToAffinity(type);
		}
		switch (typeAffinity)
		{
		case TypeAffinity.Blob:
		{
			if (typ.Type == DbType.Guid && typ.Affinity == TypeAffinity.Text)
			{
				return new Guid(GetText(stmt, index));
			}
			int num = (int)GetBytes(stmt, index, 0, null, 0, 0);
			byte[] array = new byte[num];
			GetBytes(stmt, index, 0, array, 0, num);
			if (typ.Type == DbType.Guid && num == 16)
			{
				return new Guid(array);
			}
			return array;
		}
		case TypeAffinity.DateTime:
			return GetDateTime(stmt, index);
		case TypeAffinity.Double:
			if (type == null)
			{
				return GetDouble(stmt, index);
			}
			return Convert.ChangeType(GetDouble(stmt, index), type, null);
		case TypeAffinity.Int64:
			if (type == null)
			{
				return GetInt64(stmt, index);
			}
			return Convert.ChangeType(GetInt64(stmt, index), type, null);
		default:
			return GetText(stmt, index);
		}
	}

	internal override int GetCursorForTable(SqliteStatement stmt, int db, int rootPage)
	{
		return -1;
	}

	internal override long GetRowIdForCursor(SqliteStatement stmt, int cursor)
	{
		return 0L;
	}

	internal override void GetIndexColumnExtendedInfo(string database, string index, string column, out int sortMode, out int onError, out string collationSequence)
	{
		sortMode = 0;
		onError = 2;
		collationSequence = "BINARY";
	}
}
internal class SQLite3_UTF16 : SQLite3
{
	internal SQLite3_UTF16(SQLiteDateFormats fmt)
		: base(fmt)
	{
	}

	public override string ToString(IntPtr b, int nbytelen)
	{
		return UTF16ToString(b, nbytelen);
	}

	public static string UTF16ToString(IntPtr b, int nbytelen)
	{
		if (nbytelen == 0 || b == IntPtr.Zero)
		{
			return "";
		}
		if (nbytelen == -1)
		{
			return Marshal.PtrToStringUni(b);
		}
		return Marshal.PtrToStringUni(b, nbytelen / 2);
	}

	internal override void Open(string strFilename, SQLiteOpenFlagsEnum flags, int maxPoolSize, bool usePool)
	{
		if (_sql != null)
		{
			return;
		}
		_usePool = usePool;
		if (usePool)
		{
			_fileName = strFilename;
			_sql = SqliteConnectionPool.Remove(strFilename, maxPoolSize, out _poolVersion);
		}
		if (_sql == null)
		{
			if ((flags & SQLiteOpenFlagsEnum.Create) == 0 && !File.Exists(strFilename))
			{
				throw new SqliteException(14, strFilename);
			}
			IntPtr db;
			int num = UnsafeNativeMethods.sqlite3_open16(strFilename, out db);
			if (num > 0)
			{
				throw new SqliteException(num, null);
			}
			_sql = db;
		}
		_functionsArray = SqliteFunction.BindFunctions(this);
	}

	internal override void Bind_DateTime(SqliteStatement stmt, int index, DateTime dt)
	{
		Bind_Text(stmt, index, ToString(dt));
	}

	internal override void Bind_Text(SqliteStatement stmt, int index, string value)
	{
		int num = UnsafeNativeMethods.sqlite3_bind_text16(stmt._sqlite_stmt, index, value, value.Length * 2, (IntPtr)(-1));
		if (num > 0)
		{
			throw new SqliteException(num, SQLiteLastError());
		}
	}

	internal override DateTime GetDateTime(SqliteStatement stmt, int index)
	{
		return ToDateTime(GetText(stmt, index));
	}

	internal override string ColumnName(SqliteStatement stmt, int index)
	{
		return UTF16ToString(UnsafeNativeMethods.sqlite3_column_name16(stmt._sqlite_stmt, index), -1);
	}

	internal override string GetText(SqliteStatement stmt, int index)
	{
		return UTF16ToString(UnsafeNativeMethods.sqlite3_column_text16(stmt._sqlite_stmt, index), -1);
	}

	internal override string ColumnOriginalName(SqliteStatement stmt, int index)
	{
		return UTF16ToString(UnsafeNativeMethods.sqlite3_column_origin_name16(stmt._sqlite_stmt, index), -1);
	}

	internal override string ColumnDatabaseName(SqliteStatement stmt, int index)
	{
		return UTF16ToString(UnsafeNativeMethods.sqlite3_column_database_name16(stmt._sqlite_stmt, index), -1);
	}

	internal override string ColumnTableName(SqliteStatement stmt, int index)
	{
		return UTF16ToString(UnsafeNativeMethods.sqlite3_column_table_name16(stmt._sqlite_stmt, index), -1);
	}

	internal override string GetParamValueText(IntPtr ptr)
	{
		return UTF16ToString(UnsafeNativeMethods.sqlite3_value_text16(ptr), -1);
	}

	internal override void ReturnError(IntPtr context, string value)
	{
		UnsafeNativeMethods.sqlite3_result_error16(context, value, value.Length * 2);
	}

	internal override void ReturnText(IntPtr context, string value)
	{
		UnsafeNativeMethods.sqlite3_result_text16(context, value, value.Length * 2, (IntPtr)(-1));
	}
}
internal abstract class SQLiteBase : SqliteConvert, IDisposable
{
	internal static object _lock = new object();

	internal abstract string Version { get; }

	internal abstract int Changes { get; }

	internal SQLiteBase(SQLiteDateFormats fmt)
		: base(fmt)
	{
	}

	internal abstract void Open(string strFilename, SQLiteOpenFlagsEnum flags, int maxPoolSize, bool usePool);

	internal abstract void Close();

	internal abstract void SetTimeout(int nTimeoutMS);

	internal abstract string SQLiteLastError();

	internal abstract SqliteStatement Prepare(SqliteConnection cnn, string strSql, SqliteStatement previous, uint timeoutMS, out string strRemain);

	internal abstract bool Step(SqliteStatement stmt);

	internal abstract int Reset(SqliteStatement stmt);

	internal abstract void Bind_Double(SqliteStatement stmt, int index, double value);

	internal abstract void Bind_Int32(SqliteStatement stmt, int index, int value);

	internal abstract void Bind_Int64(SqliteStatement stmt, int index, long value);

	internal abstract void Bind_Text(SqliteStatement stmt, int index, string value);

	internal abstract void Bind_Blob(SqliteStatement stmt, int index, byte[] blobData);

	internal abstract void Bind_DateTime(SqliteStatement stmt, int index, DateTime dt);

	internal abstract void Bind_Null(SqliteStatement stmt, int index);

	internal abstract int Bind_ParamCount(SqliteStatement stmt);

	internal abstract string Bind_ParamName(SqliteStatement stmt, int index);

	internal abstract int ColumnCount(SqliteStatement stmt);

	internal abstract string ColumnName(SqliteStatement stmt, int index);

	internal abstract TypeAffinity ColumnAffinity(SqliteStatement stmt, int index);

	internal abstract string ColumnType(SqliteStatement stmt, int index, out TypeAffinity nAffinity);

	internal abstract string ColumnOriginalName(SqliteStatement stmt, int index);

	internal abstract string ColumnDatabaseName(SqliteStatement stmt, int index);

	internal abstract string ColumnTableName(SqliteStatement stmt, int index);

	internal abstract void ColumnMetaData(string dataBase, string table, string column, out string dataType, out string collateSequence, out bool notNull, out bool primaryKey, out bool autoIncrement);

	internal abstract void GetIndexColumnExtendedInfo(string database, string index, string column, out int sortMode, out int onError, out string collationSequence);

	internal abstract double GetDouble(SqliteStatement stmt, int index);

	internal abstract int GetInt32(SqliteStatement stmt, int index);

	internal abstract long GetInt64(SqliteStatement stmt, int index);

	internal abstract string GetText(SqliteStatement stmt, int index);

	internal abstract long GetBytes(SqliteStatement stmt, int index, int nDataoffset, byte[] bDest, int nStart, int nLength);

	internal abstract DateTime GetDateTime(SqliteStatement stmt, int index);

	internal abstract bool IsNull(SqliteStatement stmt, int index);

	internal abstract void CreateCollation(string strCollation, SQLiteCollation func, SQLiteCollation func16, IntPtr user_data);

	internal abstract void CreateFunction(string strFunction, int nArgs, bool needCollSeq, SQLiteCallback func, SQLiteCallback funcstep, SQLiteFinalCallback funcfinal);

	internal abstract IntPtr AggregateContext(IntPtr context);

	internal abstract long GetParamValueBytes(IntPtr ptr, int nDataOffset, byte[] bDest, int nStart, int nLength);

	internal abstract double GetParamValueDouble(IntPtr ptr);

	internal abstract long GetParamValueInt64(IntPtr ptr);

	internal abstract string GetParamValueText(IntPtr ptr);

	internal abstract TypeAffinity GetParamValueType(IntPtr ptr);

	internal abstract void ReturnBlob(IntPtr context, byte[] value);

	internal abstract void ReturnDouble(IntPtr context, double value);

	internal abstract void ReturnError(IntPtr context, string value);

	internal abstract void ReturnInt64(IntPtr context, long value);

	internal abstract void ReturnNull(IntPtr context);

	internal abstract void ReturnText(IntPtr context, string value);

	internal abstract void SetPassword(byte[] passwordBytes);

	internal abstract void SetUpdateHook(SQLiteUpdateCallback func);

	internal abstract void SetCommitHook(SQLiteCommitCallback func);

	internal abstract void SetRollbackHook(SQLiteRollbackCallback func);

	internal abstract int GetCursorForTable(SqliteStatement stmt, int database, int rootPage);

	internal abstract long GetRowIdForCursor(SqliteStatement stmt, int cursor);

	internal abstract object GetValue(SqliteStatement stmt, int index, SQLiteType typ);

	protected virtual void Dispose(bool bDisposing)
	{
	}

	public void Dispose()
	{
		Dispose(bDisposing: true);
	}

	internal static string SQLiteLastError(SqliteConnectionHandle db)
	{
		return SqliteConvert.UTF8ToString(UnsafeNativeMethods.sqlite3_errmsg(db), -1);
	}

	internal static void FinalizeStatement(SqliteStatementHandle stmt)
	{
		lock (_lock)
		{
			int num = UnsafeNativeMethods.sqlite3_finalize(stmt);
			if (num > 0)
			{
				throw new SqliteException(num, null);
			}
		}
	}

	internal static void CloseConnection(SqliteConnectionHandle db)
	{
		lock (_lock)
		{
			ResetConnection(db);
			int num = ((!UnsafeNativeMethods.use_sqlite3_close_v2) ? UnsafeNativeMethods.sqlite3_close(db) : UnsafeNativeMethods.sqlite3_close_v2(db));
			if (num > 0)
			{
				throw new SqliteException(num, SQLiteLastError(db));
			}
		}
	}

	internal static void ResetConnection(SqliteConnectionHandle db)
	{
		lock (_lock)
		{
			IntPtr errMsg = IntPtr.Zero;
			do
			{
				errMsg = UnsafeNativeMethods.sqlite3_next_stmt(db, errMsg);
				if (errMsg != IntPtr.Zero)
				{
					UnsafeNativeMethods.sqlite3_reset(errMsg);
				}
			}
			while (errMsg != IntPtr.Zero);
			UnsafeNativeMethods.sqlite3_exec(db, SqliteConvert.ToUTF8("ROLLBACK"), IntPtr.Zero, IntPtr.Zero, out errMsg);
			if (errMsg != IntPtr.Zero)
			{
				UnsafeNativeMethods.sqlite3_free(errMsg);
			}
		}
	}
}
internal interface ISQLiteSchemaExtensions
{
	void BuildTempSchema(SqliteConnection cnn);
}
[Flags]
internal enum SQLiteOpenFlagsEnum
{
	None = 0,
	ReadOnly = 1,
	ReadWrite = 2,
	Create = 4,
	Default = 6,
	FileProtectionComplete = 0x100000,
	FileProtectionCompleteUnlessOpen = 0x200000,
	FileProtectionCompleteUntilFirstUserAuthentication = 0x300000,
	FileProtectionNone = 0x400000
}
[ToolboxItem(true)]
public sealed class SqliteCommand : DbCommand, ICloneable
{
	private string _commandText;

	private SqliteConnection _cnn;

	private long _version;

	private WeakReference _activeReader;

	internal int _commandTimeout;

	private bool _designTimeVisible;

	private UpdateRowSource _updateRowSource;

	private SqliteParameterCollection _parameterCollection;

	internal List<SqliteStatement> _statementList;

	internal string _remainingText;

	private SqliteTransaction _transaction;

	[DefaultValue("")]
	[RefreshProperties(RefreshProperties.All)]
	[Editor("Microsoft.VSDesigner.Data.SQL.Design.SqlCommandTextEditor, Microsoft.VSDesigner, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public override string CommandText
	{
		get
		{
			return _commandText;
		}
		set
		{
			if (!(_commandText == value))
			{
				if (_activeReader != null && _activeReader.IsAlive)
				{
					throw new InvalidOperationException("Cannot set CommandText while a DataReader is active");
				}
				ClearCommands();
				_commandText = value;
				_ = _cnn;
			}
		}
	}

	[DefaultValue(30)]
	public override int CommandTimeout
	{
		get
		{
			return _commandTimeout;
		}
		set
		{
			_commandTimeout = value;
		}
	}

	[RefreshProperties(RefreshProperties.All)]
	[DefaultValue(CommandType.Text)]
	public override CommandType CommandType
	{
		set
		{
			if (value != CommandType.Text)
			{
				throw new NotSupportedException();
			}
		}
	}

	[DefaultValue(null)]
	[Editor("Microsoft.VSDesigner.Data.Design.DbConnectionEditor, Microsoft.VSDesigner, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	public new SqliteConnection Connection
	{
		get
		{
			return _cnn;
		}
		set
		{
			if (_activeReader != null && _activeReader.IsAlive)
			{
				throw new InvalidOperationException("Cannot set Connection while a DataReader is active");
			}
			if (_cnn != null)
			{
				ClearCommands();
			}
			_cnn = value;
			if (_cnn != null)
			{
				_version = _cnn._version;
			}
		}
	}

	protected override DbConnection DbConnection
	{
		get
		{
			return Connection;
		}
		set
		{
			Connection = (SqliteConnection)value;
		}
	}

	[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
	public new SqliteParameterCollection Parameters => _parameterCollection;

	protected override DbParameterCollection DbParameterCollection => Parameters;

	[Browsable(false)]
	[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
	public new SqliteTransaction Transaction
	{
		get
		{
			return _transaction;
		}
		set
		{
			if (_cnn != null)
			{
				if (_activeReader != null && _activeReader.IsAlive)
				{
					throw new InvalidOperationException("Cannot set Transaction while a DataReader is active");
				}
				if (value != null && value._cnn != _cnn)
				{
					throw new ArgumentException("Transaction is not associated with the command's connection");
				}
				_transaction = value;
			}
			else
			{
				Connection = value.Connection;
				_transaction = value;
			}
		}
	}

	protected override DbTransaction DbTransaction
	{
		get
		{
			return Transaction;
		}
		set
		{
			Transaction = (SqliteTransaction)value;
		}
	}

	[DefaultValue(UpdateRowSource.None)]
	public override UpdateRowSource UpdatedRowSource
	{
		get
		{
			return _updateRowSource;
		}
		set
		{
			_updateRowSource = value;
		}
	}

	[DesignOnly(true)]
	[Browsable(false)]
	[DefaultValue(true)]
	[EditorBrowsable(EditorBrowsableState.Never)]
	public override bool DesignTimeVisible
	{
		get
		{
			return _designTimeVisible;
		}
		set
		{
			_designTimeVisible = value;
			TypeDescriptor.Refresh(this);
		}
	}

	public SqliteCommand(string commandText, SqliteConnection connection)
		: this(commandText, connection, null)
	{
	}

	public SqliteCommand(SqliteConnection connection)
		: this(null, connection, null)
	{
	}

	private SqliteCommand(SqliteCommand source)
		: this(source.CommandText, source.Connection, source.Transaction)
	{
		CommandTimeout = source.CommandTimeout;
		DesignTimeVisible = source.DesignTimeVisible;
		UpdatedRowSource = source.UpdatedRowSource;
		foreach (SqliteParameter item in source._parameterCollection)
		{
			Parameters.Add(item.Clone());
		}
	}

	public SqliteCommand(string commandText, SqliteConnection connection, SqliteTransaction transaction)
	{
		_statementList = null;
		_activeReader = null;
		_commandTimeout = 30;
		_parameterCollection = new SqliteParameterCollection(this);
		_designTimeVisible = true;
		_updateRowSource = UpdateRowSource.None;
		_transaction = null;
		if (commandText != null)
		{
			CommandText = commandText;
		}
		if (connection != null)
		{
			DbConnection = connection;
			_commandTimeout = connection.DefaultTimeout;
		}
		if (transaction != null)
		{
			Transaction = transaction;
		}
	}

	protected override void Dispose(bool disposing)
	{
		base.Dispose(disposing);
		if (!disposing)
		{
			return;
		}
		SqliteDataReader sqliteDataReader = null;
		if (_activeReader != null)
		{
			try
			{
				sqliteDataReader = _activeReader.Target as SqliteDataReader;
			}
			catch
			{
			}
		}
		if (sqliteDataReader != null)
		{
			sqliteDataReader._disposeCommand = true;
			_activeReader = null;
		}
		else
		{
			Connection = null;
			_parameterCollection.Clear();
			_commandText = null;
		}
	}

	internal void ClearCommands()
	{
		if (_activeReader != null)
		{
			SqliteDataReader sqliteDataReader = null;
			try
			{
				sqliteDataReader = _activeReader.Target as SqliteDataReader;
			}
			catch
			{
			}
			sqliteDataReader?.Close();
			_activeReader = null;
		}
		if (_statementList != null)
		{
			int count = _statementList.Count;
			for (int i = 0; i < count; i++)
			{
				_statementList[i].Dispose();
			}
			_statementList = null;
			_parameterCollection.Unbind();
		}
	}

	internal SqliteStatement BuildNextCommand()
	{
		SqliteStatement sqliteStatement = null;
		try
		{
			if (_statementList == null)
			{
				_remainingText = _commandText;
			}
			sqliteStatement = _cnn._sql.Prepare(_cnn, _remainingText, (_statementList == null) ? null : _statementList[_statementList.Count - 1], (uint)(_commandTimeout * 1000), out _remainingText);
			if (sqliteStatement != null)
			{
				sqliteStatement._command = this;
				if (_statementList == null)
				{
					_statementList = new List<SqliteStatement>();
				}
				_statementList.Add(sqliteStatement);
				_parameterCollection.MapParameters(sqliteStatement);
				sqliteStatement.BindParameters();
			}
			return sqliteStatement;
		}
		catch (Exception)
		{
			if (sqliteStatement != null)
			{
				if (_statementList.Contains(sqliteStatement))
				{
					_statementList.Remove(sqliteStatement);
				}
				sqliteStatement.Dispose();
			}
			_remainingText = null;
			throw;
		}
	}

	internal SqliteStatement GetStatement(int index)
	{
		if (_statementList == null)
		{
			return BuildNextCommand();
		}
		if (index == _statementList.Count)
		{
			if (!string.IsNullOrEmpty(_remainingText))
			{
				return BuildNextCommand();
			}
			return null;
		}
		SqliteStatement sqliteStatement = _statementList[index];
		sqliteStatement.BindParameters();
		return sqliteStatement;
	}

	protected override DbParameter CreateDbParameter()
	{
		return CreateParameter();
	}

	public new SqliteParameter CreateParameter()
	{
		return new SqliteParameter();
	}

	private void InitializeForReader()
	{
		if (_activeReader != null && _activeReader.IsAlive)
		{
			throw new InvalidOperationException("DataReader already active on this command");
		}
		if (_cnn == null)
		{
			throw new InvalidOperationException("No connection associated with this command");
		}
		if (_cnn.State != ConnectionState.Open)
		{
			throw new InvalidOperationException("Database is not open");
		}
		if (string.IsNullOrWhiteSpace(CommandText))
		{
			throw new ArgumentException("Empty SQL statement");
		}
		if (_cnn._version != _version)
		{
			_version = _cnn._version;
			ClearCommands();
		}
		_parameterCollection.MapParameters(null);
	}

	protected override DbDataReader ExecuteDbDataReader(CommandBehavior behavior)
	{
		return ExecuteReader(behavior);
	}

	public new SqliteDataReader ExecuteReader(CommandBehavior behavior)
	{
		InitializeForReader();
		SqliteDataReader sqliteDataReader = new SqliteDataReader(this, behavior);
		_activeReader = new WeakReference(sqliteDataReader, trackResurrection: false);
		return sqliteDataReader;
	}

	public new SqliteDataReader ExecuteReader()
	{
		return ExecuteReader(CommandBehavior.Default);
	}

	internal void ClearDataReader()
	{
		_activeReader = null;
	}

	public override int ExecuteNonQuery()
	{
		using SqliteDataReader sqliteDataReader = ExecuteReader(CommandBehavior.SingleResult | CommandBehavior.SingleRow);
		while (sqliteDataReader.NextResult())
		{
		}
		return sqliteDataReader.RecordsAffected;
	}

	public object Clone()
	{
		return new SqliteCommand(this);
	}
}
public sealed class SqliteCommandBuilder : DbCommandBuilder
{
	public new SqliteDataAdapter DataAdapter
	{
		set
		{
			base.DataAdapter = value;
		}
	}

	[Browsable(false)]
	public override CatalogLocation CatalogLocation => base.CatalogLocation;

	[Browsable(false)]
	public override string CatalogSeparator => base.CatalogSeparator;

	[Browsable(false)]
	[DefaultValue("[")]
	public override string QuotePrefix
	{
		get
		{
			return base.QuotePrefix;
		}
		set
		{
			base.QuotePrefix = value;
		}
	}

	[Browsable(false)]
	public override string QuoteSuffix
	{
		get
		{
			return base.QuoteSuffix;
		}
		set
		{
			base.QuoteSuffix = value;
		}
	}

	[Browsable(false)]
	public override string SchemaSeparator => base.SchemaSeparator;

	public SqliteCommandBuilder()
		: this(null)
	{
	}

	public SqliteCommandBuilder(SqliteDataAdapter adp)
	{
		QuotePrefix = "[";
		QuoteSuffix = "]";
		DataAdapter = adp;
	}

	protected override void ApplyParameterInfo(DbParameter parameter, DataRow row, StatementType statementType, bool whereClause)
	{
		((SqliteParameter)parameter).DbType = (DbType)row[SchemaTableColumn.ProviderType];
	}

	protected override string GetParameterName(string parameterName)
	{
		return string.Format(CultureInfo.InvariantCulture, "@{0}", parameterName);
	}

	protected override string GetParameterName(int parameterOrdinal)
	{
		return string.Format(CultureInfo.InvariantCulture, "@param{0}", parameterOrdinal);
	}

	protected override string GetParameterPlaceholder(int parameterOrdinal)
	{
		return GetParameterName(parameterOrdinal);
	}

	protected override void SetRowUpdatingHandler(DbDataAdapter adapter)
	{
		if (adapter == base.DataAdapter)
		{
			((SqliteDataAdapter)adapter).RowUpdating -= RowUpdatingEventHandler;
		}
		else
		{
			((SqliteDataAdapter)adapter).RowUpdating += RowUpdatingEventHandler;
		}
	}

	private void RowUpdatingEventHandler(object sender, RowUpdatingEventArgs e)
	{
		RowUpdatingHandler(e);
	}

	public override string QuoteIdentifier(string unquotedIdentifier)
	{
		if (string.IsNullOrEmpty(QuotePrefix) || string.IsNullOrEmpty(QuoteSuffix) || string.IsNullOrEmpty(unquotedIdentifier))
		{
			return unquotedIdentifier;
		}
		return QuotePrefix + unquotedIdentifier.Replace(QuoteSuffix, QuoteSuffix + QuoteSuffix) + QuoteSuffix;
	}

	public override string UnquoteIdentifier(string quotedIdentifier)
	{
		if (string.IsNullOrEmpty(QuotePrefix) || string.IsNullOrEmpty(QuoteSuffix) || string.IsNullOrEmpty(quotedIdentifier))
		{
			return quotedIdentifier;
		}
		if (!quotedIdentifier.StartsWith(QuotePrefix, StringComparison.InvariantCultureIgnoreCase) || !quotedIdentifier.EndsWith(QuoteSuffix, StringComparison.InvariantCultureIgnoreCase))
		{
			return quotedIdentifier;
		}
		return quotedIdentifier.Substring(QuotePrefix.Length, quotedIdentifier.Length - (QuotePrefix.Length + QuoteSuffix.Length)).Replace(QuoteSuffix + QuoteSuffix, QuoteSuffix);
	}

	protected override DataTable GetSchemaTable(DbCommand sourceCommand)
	{
		using IDataReader dataReader = sourceCommand.ExecuteReader(CommandBehavior.SchemaOnly | CommandBehavior.KeyInfo);
		DataTable schemaTable = dataReader.GetSchemaTable();
		if (HasSchemaPrimaryKey(schemaTable))
		{
			ResetIsUniqueSchemaColumn(schemaTable);
		}
		return schemaTable;
	}

	private bool HasSchemaPrimaryKey(DataTable schema)
	{
		DataColumn column = schema.Columns[SchemaTableColumn.IsKey];
		foreach (DataRow row in schema.Rows)
		{
			if ((bool)row[column])
			{
				return true;
			}
		}
		return false;
	}

	private void ResetIsUniqueSchemaColumn(DataTable schema)
	{
		DataColumn column = schema.Columns[SchemaTableColumn.IsUnique];
		DataColumn column2 = schema.Columns[SchemaTableColumn.IsKey];
		foreach (DataRow row in schema.Rows)
		{
			if (!(bool)row[column2])
			{
				row[column] = false;
			}
		}
		schema.AcceptChanges();
	}
}
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal delegate void SQLiteUpdateCallback(IntPtr puser, int type, IntPtr database, IntPtr table, long rowid);
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal delegate int SQLiteCommitCallback(IntPtr puser);
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal delegate void SQLiteRollbackCallback(IntPtr puser);
public delegate void SQLiteCommitHandler(object sender, CommitEventArgs e);
public delegate void SQLiteUpdateEventHandler(object sender, UpdateEventArgs e);
public class UpdateEventArgs : EventArgs
{
}
public class CommitEventArgs : EventArgs
{
}
internal static class SqliteConnectionPool
{
	internal class Pool
	{
		internal readonly Queue<WeakReference> Queue = new Queue<WeakReference>();

		internal int PoolVersion;

		internal int MaxPoolSize;

		internal Pool(int version, int maxSize)
		{
			PoolVersion = version;
			MaxPoolSize = maxSize;
		}
	}

	private static SortedList<string, Pool> _connections = new SortedList<string, Pool>(StringComparer.OrdinalIgnoreCase);

	private static int _poolVersion = 1;

	internal static SqliteConnectionHandle Remove(string fileName, int maxPoolSize, out int version)
	{
		lock (_connections)
		{
			version = _poolVersion;
			if (!_connections.TryGetValue(fileName, out var value))
			{
				value = new Pool(_poolVersion, maxPoolSize);
				_connections.Add(fileName, value);
				return null;
			}
			version = value.PoolVersion;
			value.MaxPoolSize = maxPoolSize;
			ResizePool(value, forAdding: false);
			while (value.Queue.Count > 0)
			{
				if (value.Queue.Dequeue().Target is SqliteConnectionHandle result)
				{
					return result;
				}
			}
			return null;
		}
	}

	internal static void Add(string fileName, SqliteConnectionHandle hdl, int version)
	{
		lock (_connections)
		{
			if (_connections.TryGetValue(fileName, out var value) && version == value.PoolVersion)
			{
				ResizePool(value, forAdding: true);
				value.Queue.Enqueue(new WeakReference(hdl, trackResurrection: false));
				GC.KeepAlive(hdl);
			}
			else
			{
				hdl.Close();
			}
		}
	}

	private static void ResizePool(Pool queue, bool forAdding)
	{
		int num = queue.MaxPoolSize;
		if (forAdding && num > 0)
		{
			num--;
		}
		while (queue.Queue.Count > num)
		{
			if (queue.Queue.Dequeue().Target is SqliteConnectionHandle sqliteConnectionHandle)
			{
				sqliteConnectionHandle.Dispose();
			}
		}
	}
}
[DefaultProperty("DataSource")]
[DefaultMember("Item")]
public sealed class SqliteConnectionStringBuilder : DbConnectionStringBuilder
{
	private Hashtable _properties;

	[DisplayName("Data Source")]
	[Browsable(true)]
	[DefaultValue("")]
	public string DataSource
	{
		set
		{
			this["data source"] = value;
		}
	}

	[Browsable(true)]
	[DefaultValue(SQLiteDateFormats.ISO8601)]
	public SQLiteDateFormats DateTimeFormat
	{
		set
		{
			this["datetimeformat"] = value;
		}
	}

	public SqliteConnectionStringBuilder()
	{
		Initialize(null);
	}

	private void Initialize(string cnnString)
	{
		_properties = new Hashtable(StringComparer.InvariantCultureIgnoreCase);
		try
		{
			base.GetProperties(_properties);
		}
		catch (NotImplementedException)
		{
			FallbackGetProperties(_properties);
		}
		if (!string.IsNullOrEmpty(cnnString))
		{
			base.ConnectionString = cnnString;
		}
	}

	public override bool TryGetValue(string keyword, out object value)
	{
		bool flag = base.TryGetValue(keyword, out value);
		if (!_properties.ContainsKey(keyword))
		{
			return flag;
		}
		if (!(_properties[keyword] is PropertyDescriptor propertyDescriptor))
		{
			return flag;
		}
		if (flag)
		{
			if (propertyDescriptor.PropertyType == typeof(bool))
			{
				value = SqliteConvert.ToBoolean(value);
			}
			else
			{
				value = TypeDescriptor.GetConverter(propertyDescriptor.PropertyType).ConvertFrom(value);
			}
		}
		else if (propertyDescriptor.Attributes[typeof(DefaultValueAttribute)] is DefaultValueAttribute defaultValueAttribute)
		{
			value = defaultValueAttribute.Value;
			flag = true;
		}
		return flag;
	}

	private void FallbackGetProperties(Hashtable propertyList)
	{
		foreach (PropertyDescriptor property in TypeDescriptor.GetProperties(this, noCustomTypeDesc: true))
		{
			if (property.Name != "ConnectionString" && !propertyList.ContainsKey(property.DisplayName))
			{
				propertyList.Add(property.DisplayName, property);
			}
		}
	}
}
public abstract class SqliteConvert
{
	protected static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

	private static string[] _datetimeFormats = new string[31]
	{
		"THHmmssK", "THHmmK", "HH:mm:ss.FFFFFFFK", "HH:mm:ssK", "HH:mmK", "yyyy-MM-dd HH:mm:ss.FFFFFFFK", "yyyy-MM-dd HH:mm:ssK", "yyyy-MM-dd HH:mmK", "yyyy-MM-ddTHH:mm:ss.FFFFFFFK", "yyyy-MM-ddTHH:mmK",
		"yyyy-MM-ddTHH:mm:ssK", "yyyyMMddHHmmssK", "yyyyMMddHHmmK", "yyyyMMddTHHmmssFFFFFFFK", "THHmmss", "THHmm", "HH:mm:ss.FFFFFFF", "HH:mm:ss", "HH:mm", "yyyy-MM-dd HH:mm:ss.FFFFFFF",
		"yyyy-MM-dd HH:mm:ss", "yyyy-MM-dd HH:mm", "yyyy-MM-ddTHH:mm:ss.FFFFFFF", "yyyy-MM-ddTHH:mm", "yyyy-MM-ddTHH:mm:ss", "yyyyMMddHHmmss", "yyyyMMddHHmm", "yyyyMMddTHHmmssFFFFFFF", "yyyy-MM-dd", "yyyyMMdd",
		"yy-MM-dd"
	};

	private static Encoding _utf8 = new UTF8Encoding();

	internal SQLiteDateFormats _datetimeFormat;

	private static Type[] _affinitytotype = new Type[8]
	{
		typeof(object),
		typeof(long),
		typeof(double),
		typeof(string),
		typeof(byte[]),
		typeof(object),
		typeof(DateTime),
		typeof(object)
	};

	private static DbType[] _typetodbtype = new DbType[19]
	{
		DbType.Object,
		DbType.Binary,
		DbType.Object,
		DbType.Boolean,
		DbType.SByte,
		DbType.SByte,
		DbType.Byte,
		DbType.Int16,
		DbType.UInt16,
		DbType.Int32,
		DbType.UInt32,
		DbType.Int64,
		DbType.UInt64,
		DbType.Single,
		DbType.Double,
		DbType.Decimal,
		DbType.DateTime,
		DbType.Object,
		DbType.String
	};

	private static int[] _dbtypetocolumnsize = new int[26]
	{
		2147483647, 2147483647, 1, 1, 8, 8, 8, 8, 8, 16,
		2, 4, 8, 2147483647, 1, 4, 2147483647, 8, 2, 4,
		8, 8, 2147483647, 2147483647, 2147483647, 2147483647
	};

	private static object[] _dbtypetonumericprecision = new object[25]
	{
		DBNull.Value,
		DBNull.Value,
		3,
		DBNull.Value,
		19,
		DBNull.Value,
		DBNull.Value,
		53,
		53,
		DBNull.Value,
		5,
		10,
		19,
		DBNull.Value,
		3,
		24,
		DBNull.Value,
		DBNull.Value,
		5,
		10,
		19,
		53,
		DBNull.Value,
		DBNull.Value,
		DBNull.Value
	};

	private static object[] _dbtypetonumericscale = new object[25]
	{
		DBNull.Value,
		DBNull.Value,
		0,
		DBNull.Value,
		4,
		DBNull.Value,
		DBNull.Value,
		DBNull.Value,
		DBNull.Value,
		DBNull.Value,
		0,
		0,
		0,
		DBNull.Value,
		0,
		DBNull.Value,
		DBNull.Value,
		DBNull.Value,
		0,
		0,
		0,
		0,
		DBNull.Value,
		DBNull.Value,
		DBNull.Value
	};

	private static SQLiteTypeNames[] _dbtypeNames = new SQLiteTypeNames[15]
	{
		new SQLiteTypeNames("INTEGER", DbType.Int64),
		new SQLiteTypeNames("TINYINT", DbType.Byte),
		new SQLiteTypeNames("INT", DbType.Int32),
		new SQLiteTypeNames("VARCHAR", DbType.AnsiString),
		new SQLiteTypeNames("NVARCHAR", DbType.String),
		new SQLiteTypeNames("CHAR", DbType.AnsiStringFixedLength),
		new SQLiteTypeNames("NCHAR", DbType.StringFixedLength),
		new SQLiteTypeNames("FLOAT", DbType.Double),
		new SQLiteTypeNames("REAL", DbType.Single),
		new SQLiteTypeNames("BIT", DbType.Boolean),
		new SQLiteTypeNames("DECIMAL", DbType.Decimal),
		new SQLiteTypeNames("DATETIME", DbType.DateTime),
		new SQLiteTypeNames("BLOB", DbType.Binary),
		new SQLiteTypeNames("UNIQUEIDENTIFIER", DbType.Guid),
		new SQLiteTypeNames("SMALLINT", DbType.Int16)
	};

	private static Type[] _dbtypeToType = new Type[26]
	{
		typeof(string),
		typeof(byte[]),
		typeof(byte),
		typeof(bool),
		typeof(decimal),
		typeof(DateTime),
		typeof(DateTime),
		typeof(decimal),
		typeof(double),
		typeof(Guid),
		typeof(short),
		typeof(int),
		typeof(long),
		typeof(object),
		typeof(sbyte),
		typeof(float),
		typeof(string),
		typeof(DateTime),
		typeof(ushort),
		typeof(uint),
		typeof(ulong),
		typeof(double),
		typeof(string),
		typeof(string),
		typeof(string),
		typeof(string)
	};

	private static TypeAffinity[] _typecodeAffinities = new TypeAffinity[19]
	{
		TypeAffinity.Null,
		TypeAffinity.Blob,
		TypeAffinity.Null,
		TypeAffinity.Int64,
		TypeAffinity.Int64,
		TypeAffinity.Int64,
		TypeAffinity.Int64,
		TypeAffinity.Int64,
		TypeAffinity.Int64,
		TypeAffinity.Int64,
		TypeAffinity.Int64,
		TypeAffinity.Int64,
		TypeAffinity.Int64,
		TypeAffinity.Double,
		TypeAffinity.Double,
		TypeAffinity.Double,
		TypeAffinity.DateTime,
		TypeAffinity.Null,
		TypeAffinity.Text
	};

	private static SQLiteTypeNames[] _typeNames = new SQLiteTypeNames[47]
	{
		new SQLiteTypeNames("COUNTER", DbType.Int64),
		new SQLiteTypeNames("AUTOINCREMENT", DbType.Int64),
		new SQLiteTypeNames("IDENTITY", DbType.Int64),
		new SQLiteTypeNames("LONGTEXT", DbType.String),
		new SQLiteTypeNames("LONGCHAR", DbType.String),
		new SQLiteTypeNames("LONGVARCHAR", DbType.String),
		new SQLiteTypeNames("LONG", DbType.Int64),
		new SQLiteTypeNames("TINYINT", DbType.Byte),
		new SQLiteTypeNames("INTEGER", DbType.Int64),
		new SQLiteTypeNames("INT", DbType.Int32),
		new SQLiteTypeNames("VARCHAR", DbType.String),
		new SQLiteTypeNames("NVARCHAR", DbType.String),
		new SQLiteTypeNames("CHAR", DbType.String),
		new SQLiteTypeNames("NCHAR", DbType.String),
		new SQLiteTypeNames("TEXT", DbType.String),
		new SQLiteTypeNames("NTEXT", DbType.String),
		new SQLiteTypeNames("STRING", DbType.String),
		new SQLiteTypeNames("DOUBLE", DbType.Double),
		new SQLiteTypeNames("FLOAT", DbType.Double),
		new SQLiteTypeNames("REAL", DbType.Single),
		new SQLiteTypeNames("BIT", DbType.Boolean),
		new SQLiteTypeNames("YESNO", DbType.Boolean),
		new SQLiteTypeNames("LOGICAL", DbType.Boolean),
		new SQLiteTypeNames("BOOL", DbType.Boolean),
		new SQLiteTypeNames("BOOLEAN", DbType.Boolean),
		new SQLiteTypeNames("NUMERIC", DbType.Decimal),
		new SQLiteTypeNames("DECIMAL", DbType.Decimal),
		new SQLiteTypeNames("MONEY", DbType.Decimal),
		new SQLiteTypeNames("CURRENCY", DbType.Decimal),
		new SQLiteTypeNames("TIME", DbType.DateTime),
		new SQLiteTypeNames("DATE", DbType.DateTime),
		new SQLiteTypeNames("SMALLDATE", DbType.DateTime),
		new SQLiteTypeNames("BLOB", DbType.Binary),
		new SQLiteTypeNames("BINARY", DbType.Binary),
		new SQLiteTypeNames("VARBINARY", DbType.Binary),
		new SQLiteTypeNames("IMAGE", DbType.Binary),
		new SQLiteTypeNames("GENERAL", DbType.Binary),
		new SQLiteTypeNames("OLEOBJECT", DbType.Binary),
		new SQLiteTypeNames("GUID", DbType.Guid),
		new SQLiteTypeNames("GUIDBLOB", DbType.Guid),
		new SQLiteTypeNames("UNIQUEIDENTIFIER", DbType.Guid),
		new SQLiteTypeNames("MEMO", DbType.String),
		new SQLiteTypeNames("NOTE", DbType.String),
		new SQLiteTypeNames("SMALLINT", DbType.Int16),
		new SQLiteTypeNames("BIGINT", DbType.Int64),
		new SQLiteTypeNames("TIMESTAMP", DbType.DateTime),
		new SQLiteTypeNames("DATETIME", DbType.DateTime)
	};

	internal SqliteConvert(SQLiteDateFormats fmt)
	{
		_datetimeFormat = fmt;
	}

	public static byte[] ToUTF8(string sourceText)
	{
		int num = _utf8.GetByteCount(sourceText) + 1;
		byte[] array = new byte[num];
		num = _utf8.GetBytes(sourceText, 0, sourceText.Length, array, 0);
		array[num] = 0;
		return array;
	}

	public byte[] ToUTF8(DateTime dateTimeValue)
	{
		return ToUTF8(ToString(dateTimeValue));
	}

	public virtual string ToString(IntPtr nativestring, int nativestringlen)
	{
		return UTF8ToString(nativestring, nativestringlen);
	}

	public static string UTF8ToString(IntPtr nativestring, int nativestringlen)
	{
		if (nativestringlen == 0 || nativestring == IntPtr.Zero)
		{
			return "";
		}
		if (nativestringlen == -1)
		{
			do
			{
				nativestringlen++;
			}
			while (Marshal.ReadByte(nativestring, nativestringlen) != 0);
		}
		byte[] array = new byte[nativestringlen];
		Marshal.Copy(nativestring, array, 0, nativestringlen);
		return _utf8.GetString(array, 0, nativestringlen);
	}

	public DateTime ToDateTime(string dateText)
	{
		return _datetimeFormat switch
		{
			SQLiteDateFormats.Ticks => new DateTime(Convert.ToInt64(dateText, CultureInfo.InvariantCulture)), 
			SQLiteDateFormats.JulianDay => ToDateTime(Convert.ToDouble(dateText, CultureInfo.InvariantCulture)), 
			SQLiteDateFormats.UnixEpoch => UnixEpoch.AddSeconds(Convert.ToInt32(dateText, CultureInfo.InvariantCulture)), 
			_ => DateTime.ParseExact(dateText, _datetimeFormats, DateTimeFormatInfo.InvariantInfo, DateTimeStyles.None), 
		};
	}

	public DateTime ToDateTime(double julianDay)
	{
		return DateTime.FromOADate(julianDay - 2415018.5);
	}

	public double ToJulianDay(DateTime value)
	{
		return value.ToOADate() + 2415018.5;
	}

	public string ToString(DateTime dateValue)
	{
		return _datetimeFormat switch
		{
			SQLiteDateFormats.Ticks => dateValue.Ticks.ToString(CultureInfo.InvariantCulture), 
			SQLiteDateFormats.JulianDay => ToJulianDay(dateValue).ToString(CultureInfo.InvariantCulture), 
			SQLiteDateFormats.UnixEpoch => (dateValue.Subtract(UnixEpoch).Ticks / 10000000).ToString(), 
			_ => dateValue.ToString(_datetimeFormats[19], CultureInfo.InvariantCulture), 
		};
	}

	internal DateTime ToDateTime(IntPtr ptr, int len)
	{
		return ToDateTime(ToString(ptr, len));
	}

	public static string[] Split(string source, char separator)
	{
		char[] array = new char[2] { '"', separator };
		char[] array2 = new char[1] { '"' };
		int startIndex = 0;
		List<string> list = new List<string>();
		while (source.Length > 0)
		{
			startIndex = source.IndexOfAny(array, startIndex);
			if (startIndex == -1)
			{
				break;
			}
			if (source[startIndex] == array[0])
			{
				startIndex = source.IndexOfAny(array2, startIndex + 1);
				if (startIndex == -1)
				{
					break;
				}
				startIndex++;
				continue;
			}
			string text = source.Substring(0, startIndex).Trim();
			if (text.Length > 1 && text[0] == array2[0] && text[text.Length - 1] == text[0])
			{
				text = text.Substring(1, text.Length - 2);
			}
			source = source.Substring(startIndex + 1).Trim();
			if (text.Length > 0)
			{
				list.Add(text);
			}
			startIndex = 0;
		}
		if (source.Length > 0)
		{
			string text = source.Trim();
			if (text.Length > 1 && text[0] == array2[0] && text[text.Length - 1] == text[0])
			{
				text = text.Substring(1, text.Length - 2);
			}
			list.Add(text);
		}
		string[] array3 = new string[list.Count];
		list.CopyTo(array3, 0);
		return array3;
	}

	public static bool ToBoolean(object source)
	{
		if (source is bool)
		{
			return (bool)source;
		}
		return ToBoolean(source.ToString());
	}

	public static bool ToBoolean(string source)
	{
		if (string.Compare(source, bool.TrueString, StringComparison.OrdinalIgnoreCase) == 0)
		{
			return true;
		}
		if (string.Compare(source, bool.FalseString, StringComparison.OrdinalIgnoreCase) == 0)
		{
			return false;
		}
		switch (source.ToLower())
		{
		case "yes":
		case "y":
		case "1":
		case "on":
			return true;
		case "no":
		case "n":
		case "0":
		case "off":
			return false;
		default:
			throw new ArgumentException("source");
		}
	}

	internal static Type SQLiteTypeToType(SQLiteType t)
	{
		if (t.Type == DbType.Object)
		{
			return _affinitytotype[(int)t.Affinity];
		}
		return DbTypeToType(t.Type);
	}

	internal static DbType TypeToDbType(Type typ)
	{
		TypeCode typeCode = Type.GetTypeCode(typ);
		if (typeCode == TypeCode.Object)
		{
			if (typ == typeof(byte[]))
			{
				return DbType.Binary;
			}
			if (typ == typeof(Guid))
			{
				return DbType.Guid;
			}
			return DbType.String;
		}
		return _typetodbtype[(int)typeCode];
	}

	internal static int DbTypeToColumnSize(DbType typ)
	{
		return _dbtypetocolumnsize[(int)typ];
	}

	internal static object DbTypeToNumericPrecision(DbType typ)
	{
		return _dbtypetonumericprecision[(int)typ];
	}

	internal static object DbTypeToNumericScale(DbType typ)
	{
		return _dbtypetonumericscale[(int)typ];
	}

	internal static string DbTypeToTypeName(DbType typ)
	{
		for (int i = 0; i < _dbtypeNames.Length; i++)
		{
			if (_dbtypeNames[i].dataType == typ)
			{
				return _dbtypeNames[i].typeName;
			}
		}
		return string.Empty;
	}

	internal static Type DbTypeToType(DbType typ)
	{
		return _dbtypeToType[(int)typ];
	}

	internal static TypeAffinity TypeToAffinity(Type typ)
	{
		TypeCode typeCode = Type.GetTypeCode(typ);
		if (typeCode == TypeCode.Object)
		{
			if (typ == typeof(byte[]) || typ == typeof(Guid))
			{
				return TypeAffinity.Blob;
			}
			return TypeAffinity.Text;
		}
		return _typecodeAffinities[(int)typeCode];
	}

	internal static DbType TypeNameToDbType(string Name)
	{
		if (string.IsNullOrEmpty(Name))
		{
			return DbType.Object;
		}
		string text = Name;
		int num = text.IndexOf('(');
		if (num > 0)
		{
			text = text.Substring(0, num);
		}
		for (int i = 0; i < _typeNames.Length; i++)
		{
			if (string.Compare(text, _typeNames[i].typeName, ignoreCase: true, CultureInfo.InvariantCulture) == 0)
			{
				return _typeNames[i].dataType;
			}
		}
		if (Name.IndexOf("INT", StringComparison.OrdinalIgnoreCase) >= 0)
		{
			return DbType.Int64;
		}
		if (Name.IndexOf("CHAR", StringComparison.OrdinalIgnoreCase) >= 0 || Name.IndexOf("CLOB", StringComparison.OrdinalIgnoreCase) >= 0 || Name.IndexOf("TEXT", StringComparison.OrdinalIgnoreCase) >= 0)
		{
			return DbType.String;
		}
		if (Name.IndexOf("BLOB", StringComparison.OrdinalIgnoreCase) >= 0)
		{
			return DbType.Object;
		}
		if (Name.IndexOf("REAL", StringComparison.OrdinalIgnoreCase) >= 0 || Name.IndexOf("FLOA", StringComparison.OrdinalIgnoreCase) >= 0 || Name.IndexOf("DOUB", StringComparison.OrdinalIgnoreCase) >= 0)
		{
			return DbType.Double;
		}
		return DbType.Object;
	}
}
public enum TypeAffinity
{
	Uninitialized = 0,
	Int64 = 1,
	Double = 2,
	Text = 3,
	Blob = 4,
	Null = 5,
	DateTime = 10,
	None = 11
}
public enum SQLiteDateFormats
{
	Ticks,
	ISO8601,
	JulianDay,
	UnixEpoch
}
internal class SQLiteType
{
	internal DbType Type;

	internal TypeAffinity Affinity;
}
internal struct SQLiteTypeNames(string newtypeName, DbType newdataType)
{
	internal string typeName = newtypeName;

	internal DbType dataType = newdataType;
}
[DefaultEvent("RowUpdated")]
[ToolboxItem("SQLite.Designer.SqliteDataAdapterToolboxItem, SQLite.Designer, Version=1.0.36.0, Culture=neutral, PublicKeyToken=db937bc2d44ff139")]
public sealed class SqliteDataAdapter : DbDataAdapter
{
	private static object _updatingEventPH = new object();

	private static object _updatedEventPH = new object();

	public event EventHandler<RowUpdatingEventArgs> RowUpdating
	{
		add
		{
			EventHandler<RowUpdatingEventArgs> eventHandler = (EventHandler<RowUpdatingEventArgs>)base.Events[_updatingEventPH];
			if (eventHandler != null && value.Target is DbCommandBuilder)
			{
				EventHandler<RowUpdatingEventArgs> eventHandler2 = (EventHandler<RowUpdatingEventArgs>)FindBuilder(eventHandler);
				if (eventHandler2 != null)
				{
					base.Events.RemoveHandler(_updatingEventPH, eventHandler2);
				}
			}
			base.Events.AddHandler(_updatingEventPH, value);
		}
		remove
		{
			base.Events.RemoveHandler(_updatingEventPH, value);
		}
	}

	internal static Delegate FindBuilder(MulticastDelegate mcd)
	{
		if ((object)mcd != null)
		{
			Delegate[] invocationList = mcd.GetInvocationList();
			for (int i = 0; i < invocationList.Length; i++)
			{
				if (invocationList[i].Target is DbCommandBuilder)
				{
					return invocationList[i];
				}
			}
		}
		return null;
	}
}
public sealed class SqliteDataReader : DbDataReader
{
	private SqliteCommand _command;

	private int _activeStatementIndex;

	private SqliteStatement _activeStatement;

	private int _readingState;

	private int _rowsAffected;

	private int _fieldCount;

	private SQLiteType[] _fieldTypeArray;

	private CommandBehavior _commandBehavior;

	internal bool _disposeCommand;

	private SqliteKeyReader _keyInfo;

	internal long _version;

	private static bool hasColumnMetadataSupport = true;

	public override int FieldCount
	{
		get
		{
			CheckClosed();
			if (_keyInfo == null)
			{
				return _fieldCount;
			}
			return _fieldCount + _keyInfo.Count;
		}
	}

	public override int VisibleFieldCount
	{
		get
		{
			CheckClosed();
			return _fieldCount;
		}
	}

	public override bool IsClosed => _command == null;

	public override int RecordsAffected
	{
		get
		{
			if (_rowsAffected >= 0)
			{
				return _rowsAffected;
			}
			return 0;
		}
	}

	public override object this[int i] => GetValue(i);

	internal SqliteDataReader(SqliteCommand cmd, CommandBehavior behave)
	{
		_command = cmd;
		_version = _command.Connection._version;
		_commandBehavior = behave;
		_activeStatementIndex = -1;
		_activeStatement = null;
		_rowsAffected = -1;
		_fieldCount = 0;
		if (_command != null)
		{
			NextResult();
		}
	}

	public override void Close()
	{
		try
		{
			if (_command != null)
			{
				try
				{
					try
					{
						if (_version != 0L)
						{
							try
							{
								while (NextResult())
								{
								}
							}
							catch
							{
							}
						}
						_command.ClearDataReader();
					}
					finally
					{
						if ((_commandBehavior & CommandBehavior.CloseConnection) != CommandBehavior.Default && _command.Connection != null)
						{
							SqliteConnection connection = _command.Connection;
							_command.Dispose();
							connection.Close();
							_disposeCommand = false;
						}
					}
				}
				finally
				{
					if (_disposeCommand)
					{
						_command.Dispose();
					}
				}
			}
			_command = null;
			_activeStatement = null;
			_fieldTypeArray = null;
		}
		finally
		{
			if (_keyInfo != null)
			{
				_keyInfo.Dispose();
				_keyInfo = null;
			}
		}
	}

	private void CheckClosed()
	{
		if (_command == null)
		{
			throw new InvalidOperationException("DataReader has been closed");
		}
		if (_version == 0L)
		{
			throw new SqliteException(4, "Execution was aborted by the user");
		}
		if (_command.Connection.State != ConnectionState.Open || _command.Connection._version != _version)
		{
			throw new InvalidOperationException("Connection was closed, statement was terminated");
		}
	}

	private void CheckValidRow()
	{
		if (_readingState != 0)
		{
			throw new InvalidOperationException("No current row");
		}
	}

	public override IEnumerator GetEnumerator()
	{
		return new DbEnumerator(this, (_commandBehavior & CommandBehavior.CloseConnection) == CommandBehavior.CloseConnection);
	}

	private TypeAffinity VerifyType(int i, DbType typ)
	{
		CheckClosed();
		CheckValidRow();
		TypeAffinity affinity = GetSQLiteType(i).Affinity;
		switch (affinity)
		{
		case TypeAffinity.Int64:
			switch (typ)
			{
			case DbType.Int16:
				return affinity;
			case DbType.Int32:
				return affinity;
			case DbType.Int64:
				return affinity;
			case DbType.Boolean:
				return affinity;
			case DbType.Byte:
				return affinity;
			case DbType.DateTime:
				return affinity;
			case DbType.Single:
				return affinity;
			case DbType.Double:
				return affinity;
			case DbType.Decimal:
				return affinity;
			}
			break;
		case TypeAffinity.Double:
			switch (typ)
			{
			case DbType.Single:
				return affinity;
			case DbType.Double:
				return affinity;
			case DbType.Decimal:
				return affinity;
			case DbType.DateTime:
				return affinity;
			}
			break;
		case TypeAffinity.Text:
			switch (typ)
			{
			case DbType.SByte:
				return affinity;
			case DbType.String:
				return affinity;
			}
			switch (typ)
			{
			case DbType.SByte:
				return affinity;
			case DbType.Guid:
				return affinity;
			case DbType.DateTime:
				return affinity;
			case DbType.Decimal:
				return affinity;
			}
			break;
		case TypeAffinity.Blob:
			switch (typ)
			{
			case DbType.Guid:
				return affinity;
			case DbType.String:
				return affinity;
			case DbType.Binary:
				return affinity;
			}
			break;
		}
		throw new InvalidCastException();
	}

	public override bool GetBoolean(int i)
	{
		if (i >= VisibleFieldCount && _keyInfo != null)
		{
			return _keyInfo.GetBoolean(i - VisibleFieldCount);
		}
		VerifyType(i, DbType.Boolean);
		return Convert.ToBoolean(GetValue(i), CultureInfo.CurrentCulture);
	}

	public override long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
	{
		if (i >= VisibleFieldCount && _keyInfo != null)
		{
			return _keyInfo.GetBytes(i - VisibleFieldCount, fieldOffset, buffer, bufferoffset, length);
		}
		VerifyType(i, DbType.Binary);
		return _activeStatement._sql.GetBytes(_activeStatement, i, (int)fieldOffset, buffer, bufferoffset, length);
	}

	public override string GetDataTypeName(int i)
	{
		if (i >= VisibleFieldCount && _keyInfo != null)
		{
			return _keyInfo.GetDataTypeName(i - VisibleFieldCount);
		}
		SQLiteType sQLiteType = GetSQLiteType(i);
		return _activeStatement._sql.ColumnType(_activeStatement, i, out sQLiteType.Affinity);
	}

	public override DateTime GetDateTime(int i)
	{
		if (i >= VisibleFieldCount && _keyInfo != null)
		{
			return _keyInfo.GetDateTime(i - VisibleFieldCount);
		}
		VerifyType(i, DbType.DateTime);
		return _activeStatement._sql.GetDateTime(_activeStatement, i);
	}

	public override Type GetFieldType(int i)
	{
		if (i >= VisibleFieldCount && _keyInfo != null)
		{
			return _keyInfo.GetFieldType(i - VisibleFieldCount);
		}
		return SqliteConvert.SQLiteTypeToType(GetSQLiteType(i));
	}

	public override int GetInt32(int i)
	{
		if (i >= VisibleFieldCount && _keyInfo != null)
		{
			return _keyInfo.GetInt32(i - VisibleFieldCount);
		}
		VerifyType(i, DbType.Int32);
		return _activeStatement._sql.GetInt32(_activeStatement, i);
	}

	public override long GetInt64(int i)
	{
		if (i >= VisibleFieldCount && _keyInfo != null)
		{
			return _keyInfo.GetInt64(i - VisibleFieldCount);
		}
		VerifyType(i, DbType.Int64);
		return _activeStatement._sql.GetInt64(_activeStatement, i);
	}

	public override string GetName(int i)
	{
		if (i >= VisibleFieldCount && _keyInfo != null)
		{
			return _keyInfo.GetName(i - VisibleFieldCount);
		}
		return _activeStatement._sql.ColumnName(_activeStatement, i);
	}

	public override DataTable GetSchemaTable()
	{
		return GetSchemaTable(wantUniqueInfo: true, wantDefaultValue: false);
	}

	internal DataTable GetSchemaTable(bool wantUniqueInfo, bool wantDefaultValue)
	{
		CheckClosed();
		DataTable dataTable = new DataTable("SchemaTable");
		DataTable dataTable2 = null;
		string text = "";
		string text2 = "";
		string text3 = "";
		dataTable.Locale = CultureInfo.InvariantCulture;
		dataTable.Columns.Add(SchemaTableColumn.ColumnName, typeof(string));
		dataTable.Columns.Add(SchemaTableColumn.ColumnOrdinal, typeof(int));
		dataTable.Columns.Add(SchemaTableColumn.ColumnSize, typeof(int));
		dataTable.Columns.Add(SchemaTableColumn.NumericPrecision, typeof(short));
		dataTable.Columns.Add(SchemaTableColumn.NumericScale, typeof(short));
		dataTable.Columns.Add(SchemaTableColumn.IsUnique, typeof(bool));
		dataTable.Columns.Add(SchemaTableColumn.IsKey, typeof(bool));
		dataTable.Columns.Add(SchemaTableOptionalColumn.BaseServerName, typeof(string));
		dataTable.Columns.Add(SchemaTableOptionalColumn.BaseCatalogName, typeof(string));
		dataTable.Columns.Add(SchemaTableColumn.BaseColumnName, typeof(string));
		dataTable.Columns.Add(SchemaTableColumn.BaseSchemaName, typeof(string));
		dataTable.Columns.Add(SchemaTableColumn.BaseTableName, typeof(string));
		dataTable.Columns.Add(SchemaTableColumn.DataType, typeof(Type));
		dataTable.Columns.Add(SchemaTableColumn.AllowDBNull, typeof(bool));
		dataTable.Columns.Add(SchemaTableColumn.ProviderType, typeof(int));
		dataTable.Columns.Add(SchemaTableColumn.IsAliased, typeof(bool));
		dataTable.Columns.Add(SchemaTableColumn.IsExpression, typeof(bool));
		dataTable.Columns.Add(SchemaTableOptionalColumn.IsAutoIncrement, typeof(bool));
		dataTable.Columns.Add(SchemaTableOptionalColumn.IsRowVersion, typeof(bool));
		dataTable.Columns.Add(SchemaTableOptionalColumn.IsHidden, typeof(bool));
		dataTable.Columns.Add(SchemaTableColumn.IsLong, typeof(bool));
		dataTable.Columns.Add(SchemaTableOptionalColumn.IsReadOnly, typeof(bool));
		dataTable.Columns.Add(SchemaTableOptionalColumn.ProviderSpecificDataType, typeof(Type));
		dataTable.Columns.Add(SchemaTableOptionalColumn.DefaultValue, typeof(object));
		dataTable.Columns.Add("DataTypeName", typeof(string));
		dataTable.Columns.Add("CollationType", typeof(string));
		dataTable.BeginLoadData();
		for (int i = 0; i < _fieldCount; i++)
		{
			DataRow dataRow = dataTable.NewRow();
			DbType type = GetSQLiteType(i).Type;
			dataRow[SchemaTableColumn.ColumnName] = GetName(i);
			dataRow[SchemaTableColumn.ColumnOrdinal] = i;
			dataRow[SchemaTableColumn.ColumnSize] = SqliteConvert.DbTypeToColumnSize(type);
			dataRow[SchemaTableColumn.NumericPrecision] = SqliteConvert.DbTypeToNumericPrecision(type);
			dataRow[SchemaTableColumn.NumericScale] = SqliteConvert.DbTypeToNumericScale(type);
			dataRow[SchemaTableColumn.ProviderType] = GetSQLiteType(i).Type;
			dataRow[SchemaTableColumn.IsLong] = false;
			dataRow[SchemaTableColumn.AllowDBNull] = true;
			dataRow[SchemaTableOptionalColumn.IsReadOnly] = false;
			dataRow[SchemaTableOptionalColumn.IsRowVersion] = false;
			dataRow[SchemaTableColumn.IsUnique] = false;
			dataRow[SchemaTableColumn.IsKey] = false;
			dataRow[SchemaTableOptionalColumn.IsAutoIncrement] = false;
			dataRow[SchemaTableColumn.DataType] = GetFieldType(i);
			dataRow[SchemaTableOptionalColumn.IsHidden] = false;
			if (hasColumnMetadataSupport)
			{
				try
				{
					text3 = _command.Connection._sql.ColumnOriginalName(_activeStatement, i);
					if (!string.IsNullOrEmpty(text3))
					{
						dataRow[SchemaTableColumn.BaseColumnName] = text3;
					}
					dataRow[SchemaTableColumn.IsExpression] = string.IsNullOrEmpty(text3);
					dataRow[SchemaTableColumn.IsAliased] = string.Compare(GetName(i), text3, ignoreCase: true, CultureInfo.InvariantCulture) != 0;
					string value = _command.Connection._sql.ColumnTableName(_activeStatement, i);
					if (!string.IsNullOrEmpty(value))
					{
						dataRow[SchemaTableColumn.BaseTableName] = value;
					}
					value = _command.Connection._sql.ColumnDatabaseName(_activeStatement, i);
					if (!string.IsNullOrEmpty(value))
					{
						dataRow[SchemaTableOptionalColumn.BaseCatalogName] = value;
					}
				}
				catch (EntryPointNotFoundException)
				{
					hasColumnMetadataSupport = false;
				}
			}
			string dataType = null;
			if (!string.IsNullOrEmpty(text3))
			{
				_command.Connection._sql.ColumnMetaData((string)dataRow[SchemaTableOptionalColumn.BaseCatalogName], (string)dataRow[SchemaTableColumn.BaseTableName], text3, out dataType, out var collateSequence, out var notNull, out var primaryKey, out var autoIncrement);
				if (notNull || primaryKey)
				{
					dataRow[SchemaTableColumn.AllowDBNull] = false;
				}
				dataRow[SchemaTableColumn.IsKey] = primaryKey;
				dataRow[SchemaTableOptionalColumn.IsAutoIncrement] = autoIncrement;
				dataRow["CollationType"] = collateSequence;
				string[] array = dataType.Split('(');
				if (array.Length > 1)
				{
					dataType = array[0];
					array = array[1].Split(')');
					if (array.Length > 1)
					{
						array = array[0].Split(',', '.');
						if (GetSQLiteType(i).Type == DbType.String || GetSQLiteType(i).Type == DbType.Binary)
						{
							dataRow[SchemaTableColumn.ColumnSize] = Convert.ToInt32(array[0], CultureInfo.InvariantCulture);
						}
						else
						{
							dataRow[SchemaTableColumn.NumericPrecision] = Convert.ToInt32(array[0], CultureInfo.InvariantCulture);
							if (array.Length > 1)
							{
								dataRow[SchemaTableColumn.NumericScale] = Convert.ToInt32(array[1], CultureInfo.InvariantCulture);
							}
						}
					}
				}
				if (wantDefaultValue)
				{
					using SqliteCommand sqliteCommand = new SqliteCommand(string.Format(CultureInfo.InvariantCulture, "PRAGMA [{0}].TABLE_INFO([{1}])", dataRow[SchemaTableOptionalColumn.BaseCatalogName], dataRow[SchemaTableColumn.BaseTableName]), _command.Connection);
					using DbDataReader dbDataReader = sqliteCommand.ExecuteReader();
					while (dbDataReader.Read())
					{
						if (string.Compare((string)dataRow[SchemaTableColumn.BaseColumnName], dbDataReader.GetString(1), ignoreCase: true, CultureInfo.InvariantCulture) == 0)
						{
							if (!dbDataReader.IsDBNull(4))
							{
								dataRow[SchemaTableOptionalColumn.DefaultValue] = dbDataReader[4];
							}
							break;
						}
					}
				}
				if (wantUniqueInfo)
				{
					if ((string)dataRow[SchemaTableOptionalColumn.BaseCatalogName] != text || (string)dataRow[SchemaTableColumn.BaseTableName] != text2)
					{
						text = (string)dataRow[SchemaTableOptionalColumn.BaseCatalogName];
						text2 = (string)dataRow[SchemaTableColumn.BaseTableName];
						dataTable2 = _command.Connection.GetSchema("Indexes", new string[4]
						{
							(string)dataRow[SchemaTableOptionalColumn.BaseCatalogName],
							null,
							(string)dataRow[SchemaTableColumn.BaseTableName],
							null
						});
					}
					foreach (DataRow row in dataTable2.Rows)
					{
						DataTable schema = _command.Connection.GetSchema("IndexColumns", new string[5]
						{
							(string)dataRow[SchemaTableOptionalColumn.BaseCatalogName],
							null,
							(string)dataRow[SchemaTableColumn.BaseTableName],
							(string)row["INDEX_NAME"],
							null
						});
						foreach (DataRow row2 in schema.Rows)
						{
							if (string.Compare((string)row2["COLUMN_NAME"], text3, ignoreCase: true, CultureInfo.InvariantCulture) == 0)
							{
								if (schema.Rows.Count == 1 && !(bool)dataRow[SchemaTableColumn.AllowDBNull])
								{
									dataRow[SchemaTableColumn.IsUnique] = row["UNIQUE"];
								}
								if (schema.Rows.Count == 1 && (bool)row["PRIMARY_KEY"] && !string.IsNullOrEmpty(dataType) && string.Compare(dataType, "integer", ignoreCase: true, CultureInfo.InvariantCulture) != 0)
								{
								}
								break;
							}
						}
					}
				}
				if (string.IsNullOrEmpty(dataType))
				{
					dataType = _activeStatement._sql.ColumnType(_activeStatement, i, out var _);
				}
				if (!string.IsNullOrEmpty(dataType))
				{
					dataRow["DataTypeName"] = dataType;
				}
			}
			dataTable.Rows.Add(dataRow);
		}
		if (_keyInfo != null)
		{
			_keyInfo.AppendSchemaTable(dataTable);
		}
		dataTable.AcceptChanges();
		dataTable.EndLoadData();
		return dataTable;
	}

	public override string GetString(int i)
	{
		if (i >= VisibleFieldCount && _keyInfo != null)
		{
			return _keyInfo.GetString(i - VisibleFieldCount);
		}
		VerifyType(i, DbType.String);
		return _activeStatement._sql.GetText(_activeStatement, i);
	}

	public override object GetValue(int i)
	{
		if (i >= VisibleFieldCount && _keyInfo != null)
		{
			return _keyInfo.GetValue(i - VisibleFieldCount);
		}
		SQLiteType sQLiteType = GetSQLiteType(i);
		return _activeStatement._sql.GetValue(_activeStatement, i, sQLiteType);
	}

	public override int GetValues(object[] values)
	{
		int num = FieldCount;
		if (values.Length < num)
		{
			num = values.Length;
		}
		for (int i = 0; i < num; i++)
		{
			values[i] = GetValue(i);
		}
		return num;
	}

	public override bool IsDBNull(int i)
	{
		if (i >= VisibleFieldCount && _keyInfo != null)
		{
			return _keyInfo.IsDBNull(i - VisibleFieldCount);
		}
		return _activeStatement._sql.IsNull(_activeStatement, i);
	}

	public override bool NextResult()
	{
		CheckClosed();
		SqliteStatement sqliteStatement = null;
		int num;
		while (true)
		{
			if (_activeStatement != null && sqliteStatement == null)
			{
				_activeStatement._sql.Reset(_activeStatement);
				if ((_commandBehavior & CommandBehavior.SingleResult) != CommandBehavior.Default)
				{
					while (true)
					{
						sqliteStatement = _command.GetStatement(_activeStatementIndex + 1);
						if (sqliteStatement == null)
						{
							break;
						}
						_activeStatementIndex++;
						sqliteStatement._sql.Step(sqliteStatement);
						if (sqliteStatement._sql.ColumnCount(sqliteStatement) == 0)
						{
							if (_rowsAffected == -1)
							{
								_rowsAffected = 0;
							}
							_rowsAffected += sqliteStatement._sql.Changes;
						}
						sqliteStatement._sql.Reset(sqliteStatement);
					}
					return false;
				}
			}
			sqliteStatement = _command.GetStatement(_activeStatementIndex + 1);
			if (sqliteStatement == null)
			{
				return false;
			}
			if (_readingState < 1)
			{
				_readingState = 1;
			}
			_activeStatementIndex++;
			num = sqliteStatement._sql.ColumnCount(sqliteStatement);
			if ((_commandBehavior & CommandBehavior.SchemaOnly) != CommandBehavior.Default && num != 0)
			{
				break;
			}
			if (sqliteStatement._sql.Step(sqliteStatement))
			{
				_readingState = -1;
				break;
			}
			if (num == 0)
			{
				if (_rowsAffected == -1)
				{
					_rowsAffected = 0;
				}
				_rowsAffected += sqliteStatement._sql.Changes;
				sqliteStatement._sql.Reset(sqliteStatement);
				continue;
			}
			_readingState = 1;
			break;
		}
		_activeStatement = sqliteStatement;
		_fieldCount = num;
		_fieldTypeArray = null;
		if ((_commandBehavior & CommandBehavior.KeyInfo) != CommandBehavior.Default)
		{
			LoadKeyInfo();
		}
		return true;
	}

	private SQLiteType GetSQLiteType(int i)
	{
		if (_fieldTypeArray == null)
		{
			_fieldTypeArray = new SQLiteType[VisibleFieldCount];
		}
		if (_fieldTypeArray[i] == null)
		{
			_fieldTypeArray[i] = new SQLiteType();
		}
		SQLiteType sQLiteType = _fieldTypeArray[i];
		if (sQLiteType.Affinity == TypeAffinity.Uninitialized)
		{
			sQLiteType.Type = SqliteConvert.TypeNameToDbType(_activeStatement._sql.ColumnType(_activeStatement, i, out sQLiteType.Affinity));
		}
		else
		{
			sQLiteType.Affinity = _activeStatement._sql.ColumnAffinity(_activeStatement, i);
		}
		return sQLiteType;
	}

	public override bool Read()
	{
		CheckClosed();
		if (_readingState == -1)
		{
			_readingState = 0;
			return true;
		}
		if (_readingState == 0)
		{
			if ((_commandBehavior & CommandBehavior.SingleRow) == 0 && _activeStatement._sql.Step(_activeStatement))
			{
				if (_keyInfo != null)
				{
					_keyInfo.Reset();
				}
				return true;
			}
			_readingState = 1;
		}
		return false;
	}

	private void LoadKeyInfo()
	{
		if (_keyInfo != null)
		{
			_keyInfo.Dispose();
		}
		_keyInfo = new SqliteKeyReader(_command.Connection, this, _activeStatement);
	}
}
internal class SQLiteEnlistment : IEnlistmentNotification
{
	internal SqliteTransaction _transaction;

	internal Transaction _scope;

	internal bool _disposeConnection;

	internal SQLiteEnlistment(SqliteConnection cnn, Transaction scope)
	{
		_transaction = cnn.BeginTransaction();
		_scope = scope;
		_disposeConnection = false;
		_scope.EnlistVolatile(this, EnlistmentOptions.None);
	}
}
[Serializable]
public sealed class SqliteException : DbException
{
	private SQLiteErrorCode _errorCode;

	private static string[] _errorMessages = new string[27]
	{
		"SQLite OK", "SQLite error", "An internal logic error in SQLite", "Access permission denied", "Callback routine requested an abort", "The database file is locked", "A table in the database is locked", "malloc() failed", "Attempt to write a read-only database", "Operation terminated by sqlite3_interrupt()",
		"Some kind of disk I/O error occurred", "The database disk image is malformed", "Table or record not found", "Insertion failed because the database is full", "Unable to open the database file", "Database lock protocol error", "Database is empty", "The database schema changed", "Too much data for one row of a table", "Abort due to constraint violation",
		"Data type mismatch", "Library used incorrectly", "Uses OS features not supported on host", "Authorization denied", "Auxiliary database format error", "2nd parameter to sqlite3_bind() out of range", "File opened that is not a database file"
	};

	private SqliteException(SerializationInfo info, StreamingContext context)
		: base(info, context)
	{
	}

	public SqliteException(int errorCode, string extendedInformation)
		: base(GetStockErrorMessage(errorCode, extendedInformation))
	{
		_errorCode = (SQLiteErrorCode)errorCode;
	}

	public SqliteException()
	{
	}

	private static string GetStockErrorMessage(int errorCode, string errorMessage)
	{
		if (errorMessage == null)
		{
			errorMessage = "";
		}
		if (errorMessage.Length > 0)
		{
			errorMessage = "\r\n" + errorMessage;
		}
		if (errorCode < 0 || errorCode >= _errorMessages.Length)
		{
			errorCode = 1;
		}
		return _errorMessages[errorCode] + errorMessage;
	}
}
public enum SQLiteErrorCode
{
	Ok = 0,
	Error = 1,
	Internal = 2,
	Perm = 3,
	Abort = 4,
	Busy = 5,
	Locked = 6,
	NoMem = 7,
	ReadOnly = 8,
	Interrupt = 9,
	IOErr = 10,
	Corrupt = 11,
	NotFound = 12,
	Full = 13,
	CantOpen = 14,
	Protocol = 15,
	Empty = 16,
	Schema = 17,
	TooBig = 18,
	Constraint = 19,
	Mismatch = 20,
	Misuse = 21,
	NOLFS = 22,
	Auth = 23,
	Format = 24,
	Range = 25,
	NotADatabase = 26,
	Row = 100,
	Done = 101
}
public abstract class SqliteFunction
{
	private class AggregateData
	{
		internal int _count = 1;

		internal object _data;
	}

	internal SQLiteBase _base;

	private Dictionary<long, AggregateData> _contextDataList;

	private SQLiteCallback _InvokeFunc;

	private SQLiteCallback _StepFunc;

	private SQLiteFinalCallback _FinalFunc;

	private SQLiteCollation _CompareFunc;

	private SQLiteCollation _CompareFunc16;

	internal IntPtr _context;

	private static List<SqliteFunctionAttribute> _registeredFunctions;

	public virtual object Invoke(object[] args)
	{
		return null;
	}

	public virtual void Step(object[] args, int stepNumber, ref object contextData)
	{
	}

	public virtual object Final(object contextData)
	{
		return null;
	}

	public virtual int Compare(string param1, string param2)
	{
		return 0;
	}

	internal object[] ConvertParams(int nArgs, IntPtr argsptr)
	{
		object[] array = new object[nArgs];
		IntPtr[] array2 = new IntPtr[nArgs];
		Marshal.Copy(argsptr, array2, 0, nArgs);
		for (int i = 0; i < nArgs; i++)
		{
			switch (_base.GetParamValueType(array2[i]))
			{
			case TypeAffinity.Null:
				array[i] = DBNull.Value;
				break;
			case TypeAffinity.Int64:
				array[i] = _base.GetParamValueInt64(array2[i]);
				break;
			case TypeAffinity.Double:
				array[i] = _base.GetParamValueDouble(array2[i]);
				break;
			case TypeAffinity.Text:
				array[i] = _base.GetParamValueText(array2[i]);
				break;
			case TypeAffinity.Blob:
			{
				int num = (int)_base.GetParamValueBytes(array2[i], 0, null, 0, 0);
				byte[] array3 = new byte[num];
				_base.GetParamValueBytes(array2[i], 0, array3, 0, num);
				array[i] = array3;
				break;
			}
			case TypeAffinity.DateTime:
				array[i] = _base.ToDateTime(_base.GetParamValueText(array2[i]));
				break;
			}
		}
		return array;
	}

	private void SetReturnValue(IntPtr context, object returnValue)
	{
		if (returnValue == null || returnValue == DBNull.Value)
		{
			_base.ReturnNull(context);
			return;
		}
		Type type = returnValue.GetType();
		if (type == typeof(DateTime))
		{
			_base.ReturnText(context, _base.ToString((DateTime)returnValue));
			return;
		}
		if (returnValue is Exception ex)
		{
			_base.ReturnError(context, ex.Message);
			return;
		}
		switch (SqliteConvert.TypeToAffinity(type))
		{
		case TypeAffinity.Null:
			_base.ReturnNull(context);
			break;
		case TypeAffinity.Int64:
			_base.ReturnInt64(context, Convert.ToInt64(returnValue, CultureInfo.CurrentCulture));
			break;
		case TypeAffinity.Double:
			_base.ReturnDouble(context, Convert.ToDouble(returnValue, CultureInfo.CurrentCulture));
			break;
		case TypeAffinity.Text:
			_base.ReturnText(context, returnValue.ToString());
			break;
		case TypeAffinity.Blob:
			_base.ReturnBlob(context, (byte[])returnValue);
			break;
		}
	}

	internal void ScalarCallback(IntPtr context, int nArgs, IntPtr argsptr)
	{
		_context = context;
		SetReturnValue(context, Invoke(ConvertParams(nArgs, argsptr)));
	}

	internal int CompareCallback(IntPtr ptr, int len1, IntPtr ptr1, int len2, IntPtr ptr2)
	{
		return Compare(SqliteConvert.UTF8ToString(ptr1, len1), SqliteConvert.UTF8ToString(ptr2, len2));
	}

	internal int CompareCallback16(IntPtr ptr, int len1, IntPtr ptr1, int len2, IntPtr ptr2)
	{
		return Compare(SQLite3_UTF16.UTF16ToString(ptr1, len1), SQLite3_UTF16.UTF16ToString(ptr2, len2));
	}

	internal void StepCallback(IntPtr context, int nArgs, IntPtr argsptr)
	{
		long key = (long)_base.AggregateContext(context);
		if (!_contextDataList.TryGetValue(key, out var value))
		{
			value = new AggregateData();
			_contextDataList[key] = value;
		}
		try
		{
			_context = context;
			Step(ConvertParams(nArgs, argsptr), value._count, ref value._data);
		}
		finally
		{
			value._count++;
		}
	}

	internal void FinalCallback(IntPtr context)
	{
		long key = (long)_base.AggregateContext(context);
		object obj = null;
		if (_contextDataList.ContainsKey(key))
		{
			obj = _contextDataList[key]._data;
			_contextDataList.Remove(key);
		}
		_context = context;
		SetReturnValue(context, Final(obj));
		if (obj is IDisposable disposable)
		{
			disposable.Dispose();
		}
	}

	static SqliteFunction()
	{
		_registeredFunctions = new List<SqliteFunctionAttribute>();
		try
		{
			Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
			int num = assemblies.Length;
			AssemblyName name = Assembly.GetCallingAssembly().GetName();
			for (int i = 0; i < num; i++)
			{
				bool flag = false;
				Type[] types;
				try
				{
					AssemblyName[] referencedAssemblies = assemblies[i].GetReferencedAssemblies();
					int num2 = referencedAssemblies.Length;
					for (int j = 0; j < num2; j++)
					{
						if (referencedAssemblies[j].Name == name.Name)
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						continue;
					}
					types = assemblies[i].GetTypes();
					goto IL_008c;
				}
				catch (ReflectionTypeLoadException ex)
				{
					types = ex.Types;
					goto IL_008c;
				}
				IL_008c:
				int num3 = types.Length;
				for (int k = 0; k < num3; k++)
				{
					if (types[k] == null)
					{
						continue;
					}
					object[] customAttributes = types[k].GetCustomAttributes(typeof(SqliteFunctionAttribute), inherit: false);
					int num4 = customAttributes.Length;
					for (int l = 0; l < num4; l++)
					{
						if (customAttributes[l] is SqliteFunctionAttribute sqliteFunctionAttribute)
						{
							sqliteFunctionAttribute._instanceType = types[k];
							_registeredFunctions.Add(sqliteFunctionAttribute);
						}
					}
				}
			}
		}
		catch
		{
		}
	}

	internal static SqliteFunction[] BindFunctions(SQLiteBase sqlbase)
	{
		List<SqliteFunction> list = new List<SqliteFunction>();
		foreach (SqliteFunctionAttribute registeredFunction in _registeredFunctions)
		{
			SqliteFunction sqliteFunction = (SqliteFunction)Activator.CreateInstance(registeredFunction._instanceType);
			sqliteFunction._base = sqlbase;
			sqliteFunction._InvokeFunc = ((registeredFunction.FuncType == FunctionType.Scalar) ? new SQLiteCallback(sqliteFunction.ScalarCallback) : null);
			sqliteFunction._StepFunc = ((registeredFunction.FuncType == FunctionType.Aggregate) ? new SQLiteCallback(sqliteFunction.StepCallback) : null);
			sqliteFunction._FinalFunc = ((registeredFunction.FuncType == FunctionType.Aggregate) ? new SQLiteFinalCallback(sqliteFunction.FinalCallback) : null);
			sqliteFunction._CompareFunc = ((registeredFunction.FuncType == FunctionType.Collation) ? new SQLiteCollation(sqliteFunction.CompareCallback) : null);
			sqliteFunction._CompareFunc16 = ((registeredFunction.FuncType == FunctionType.Collation) ? new SQLiteCollation(sqliteFunction.CompareCallback16) : null);
			if (registeredFunction.FuncType != FunctionType.Collation)
			{
				sqlbase.CreateFunction(registeredFunction.Name, registeredFunction.Arguments, sqliteFunction is SqliteFunctionEx, sqliteFunction._InvokeFunc, sqliteFunction._StepFunc, sqliteFunction._FinalFunc);
			}
			else
			{
				sqlbase.CreateCollation(registeredFunction.Name, sqliteFunction._CompareFunc, sqliteFunction._CompareFunc16, IntPtr.Zero);
			}
			list.Add(sqliteFunction);
		}
		SqliteFunction[] array = new SqliteFunction[list.Count];
		list.CopyTo(array, 0);
		return array;
	}
}
public class SqliteFunctionEx : SqliteFunction
{
}
public enum FunctionType
{
	Scalar,
	Aggregate,
	Collation
}
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal delegate void SQLiteCallback(IntPtr context, int nArgs, IntPtr argsptr);
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal delegate void SQLiteFinalCallback(IntPtr context);
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal delegate int SQLiteCollation(IntPtr puser, int len1, IntPtr pv1, int len2, IntPtr pv2);
[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
public sealed class SqliteFunctionAttribute : Attribute
{
	private string _name;

	private int _arguments;

	private FunctionType _functionType;

	internal Type _instanceType;

	public string Name => _name;

	public int Arguments => _arguments;

	public FunctionType FuncType => _functionType;
}
internal sealed class SqliteKeyReader : IDisposable
{
	private struct KeyInfo
	{
		internal string databaseName;

		internal string tableName;

		internal string columnName;

		internal int database;

		internal int rootPage;

		internal int cursor;

		internal KeyQuery query;

		internal int column;
	}

	private sealed class KeyQuery : IDisposable
	{
		private SqliteCommand _command;

		internal SqliteDataReader _reader;

		internal bool IsValid
		{
			set
			{
				if (value)
				{
					throw new ArgumentException();
				}
				if (_reader != null)
				{
					_reader.Dispose();
					_reader = null;
				}
			}
		}

		internal KeyQuery(SqliteConnection cnn, string database, string table, params string[] columns)
		{
			using (SqliteCommandBuilder sqliteCommandBuilder = new SqliteCommandBuilder())
			{
				_command = cnn.CreateCommand();
				for (int i = 0; i < columns.Length; i++)
				{
					columns[i] = sqliteCommandBuilder.QuoteIdentifier(columns[i]);
				}
			}
			_command.CommandText = string.Format("SELECT {0} FROM [{1}].[{2}] WHERE ROWID = ?", string.Join(",", columns), database, table);
			_command.Parameters.AddWithValue(null, 0L);
		}

		internal void Sync(long rowid)
		{
			IsValid = false;
			_command.Parameters[0].Value = rowid;
			_reader = _command.ExecuteReader();
			_reader.Read();
		}

		public void Dispose()
		{
			IsValid = false;
			if (_command != null)
			{
				_command.Dispose();
			}
			_command = null;
		}
	}

	private KeyInfo[] _keyInfo;

	private SqliteStatement _stmt;

	private bool _isValid;

	internal int Count
	{
		get
		{
			if (_keyInfo != null)
			{
				return _keyInfo.Length;
			}
			return 0;
		}
	}

	internal SqliteKeyReader(SqliteConnection cnn, SqliteDataReader reader, SqliteStatement stmt)
	{
		Dictionary<string, int> dictionary = new Dictionary<string, int>();
		Dictionary<string, List<string>> dictionary2 = new Dictionary<string, List<string>>();
		List<KeyInfo> list = new List<KeyInfo>();
		_stmt = stmt;
		using (DataTable dataTable = cnn.GetSchema("Catalogs"))
		{
			foreach (DataRow row in dataTable.Rows)
			{
				dictionary.Add((string)row["CATALOG_NAME"], Convert.ToInt32(row["ID"]));
			}
		}
		using (DataTable dataTable2 = reader.GetSchemaTable(wantUniqueInfo: false, wantDefaultValue: false))
		{
			foreach (DataRow row2 in dataTable2.Rows)
			{
				if (row2[SchemaTableOptionalColumn.BaseCatalogName] != DBNull.Value)
				{
					string key = (string)row2[SchemaTableOptionalColumn.BaseCatalogName];
					string item = (string)row2[SchemaTableColumn.BaseTableName];
					List<string> list2;
					if (!dictionary2.ContainsKey(key))
					{
						list2 = new List<string>();
						dictionary2.Add(key, list2);
					}
					else
					{
						list2 = dictionary2[key];
					}
					if (!list2.Contains(item))
					{
						list2.Add(item);
					}
				}
			}
			foreach (KeyValuePair<string, List<string>> item2 in dictionary2)
			{
				for (int i = 0; i < item2.Value.Count; i++)
				{
					string text = item2.Value[i];
					DataRow dataRow3 = null;
					using DataTable dataTable3 = cnn.GetSchema("Indexes", new string[3] { item2.Key, null, text });
					for (int j = 0; j < 2; j++)
					{
						if (dataRow3 != null)
						{
							break;
						}
						foreach (DataRow row3 in dataTable3.Rows)
						{
							if (j == 0 && (bool)row3["PRIMARY_KEY"])
							{
								dataRow3 = row3;
								break;
							}
							if (j == 1 && (bool)row3["UNIQUE"])
							{
								dataRow3 = row3;
								break;
							}
						}
					}
					if (dataRow3 == null)
					{
						item2.Value.RemoveAt(i);
						i--;
						continue;
					}
					using DataTable dataTable4 = cnn.GetSchema("Tables", new string[3] { item2.Key, null, text });
					int database = dictionary[item2.Key];
					int rootPage = Convert.ToInt32(dataTable4.Rows[0]["TABLE_ROOTPAGE"]);
					int cursorForTable = stmt._sql.GetCursorForTable(stmt, database, rootPage);
					using DataTable dataTable5 = cnn.GetSchema("IndexColumns", new string[4]
					{
						item2.Key,
						null,
						text,
						(string)dataRow3["INDEX_NAME"]
					});
					KeyQuery query = null;
					List<string> list3 = new List<string>();
					for (int k = 0; k < dataTable5.Rows.Count; k++)
					{
						bool flag = true;
						foreach (DataRow row4 in dataTable2.Rows)
						{
							if (!row4.IsNull(SchemaTableColumn.BaseColumnName) && (string)row4[SchemaTableColumn.BaseColumnName] == (string)dataTable5.Rows[k]["COLUMN_NAME"] && (string)row4[SchemaTableColumn.BaseTableName] == text && (string)row4[SchemaTableOptionalColumn.BaseCatalogName] == item2.Key)
							{
								dataTable5.Rows.RemoveAt(k);
								k--;
								flag = false;
								break;
							}
						}
						if (flag)
						{
							list3.Add((string)dataTable5.Rows[k]["COLUMN_NAME"]);
						}
					}
					if ((string)dataRow3["INDEX_NAME"] != "sqlite_master_PK_" + text && list3.Count > 0)
					{
						string[] array = new string[list3.Count];
						list3.CopyTo(array);
						query = new KeyQuery(cnn, item2.Key, text, array);
					}
					for (int l = 0; l < dataTable5.Rows.Count; l++)
					{
						string columnName = (string)dataTable5.Rows[l]["COLUMN_NAME"];
						list.Add(new KeyInfo
						{
							rootPage = rootPage,
							cursor = cursorForTable,
							database = database,
							databaseName = item2.Key,
							tableName = text,
							columnName = columnName,
							query = query,
							column = l
						});
					}
				}
			}
		}
		_keyInfo = new KeyInfo[list.Count];
		list.CopyTo(_keyInfo);
	}

	internal void Sync(int i)
	{
		Sync();
		if (_keyInfo[i].cursor == -1)
		{
			throw new InvalidCastException();
		}
	}

	internal void Sync()
	{
		if (_isValid)
		{
			return;
		}
		KeyQuery keyQuery = null;
		for (int i = 0; i < _keyInfo.Length; i++)
		{
			if (_keyInfo[i].query == null || _keyInfo[i].query != keyQuery)
			{
				keyQuery = _keyInfo[i].query;
				keyQuery?.Sync(_stmt._sql.GetRowIdForCursor(_stmt, _keyInfo[i].cursor));
			}
		}
		_isValid = true;
	}

	internal void Reset()
	{
		_isValid = false;
		if (_keyInfo == null)
		{
			return;
		}
		for (int i = 0; i < _keyInfo.Length; i++)
		{
			if (_keyInfo[i].query != null)
			{
				_keyInfo[i].query.IsValid = false;
			}
		}
	}

	public void Dispose()
	{
		_stmt = null;
		if (_keyInfo == null)
		{
			return;
		}
		for (int i = 0; i < _keyInfo.Length; i++)
		{
			if (_keyInfo[i].query != null)
			{
				_keyInfo[i].query.Dispose();
			}
		}
		_keyInfo = null;
	}

	internal string GetDataTypeName(int i)
	{
		Sync();
		if (_keyInfo[i].query != null)
		{
			return _keyInfo[i].query._reader.GetDataTypeName(_keyInfo[i].column);
		}
		return "integer";
	}

	internal Type GetFieldType(int i)
	{
		Sync();
		if (_keyInfo[i].query != null)
		{
			return _keyInfo[i].query._reader.GetFieldType(_keyInfo[i].column);
		}
		return typeof(long);
	}

	internal string GetName(int i)
	{
		return _keyInfo[i].columnName;
	}

	internal bool GetBoolean(int i)
	{
		Sync(i);
		if (_keyInfo[i].query != null)
		{
			return _keyInfo[i].query._reader.GetBoolean(_keyInfo[i].column);
		}
		throw new InvalidCastException();
	}

	internal long GetBytes(int i, long fieldOffset, byte[] buffer, int bufferoffset, int length)
	{
		Sync(i);
		if (_keyInfo[i].query != null)
		{
			return _keyInfo[i].query._reader.GetBytes(_keyInfo[i].column, fieldOffset, buffer, bufferoffset, length);
		}
		throw new InvalidCastException();
	}

	internal DateTime GetDateTime(int i)
	{
		Sync(i);
		if (_keyInfo[i].query != null)
		{
			return _keyInfo[i].query._reader.GetDateTime(_keyInfo[i].column);
		}
		throw new InvalidCastException();
	}

	internal int GetInt32(int i)
	{
		Sync(i);
		if (_keyInfo[i].query != null)
		{
			return _keyInfo[i].query._reader.GetInt32(_keyInfo[i].column);
		}
		long rowIdForCursor = _stmt._sql.GetRowIdForCursor(_stmt, _keyInfo[i].cursor);
		if (rowIdForCursor == 0L)
		{
			throw new InvalidCastException();
		}
		return Convert.ToInt32(rowIdForCursor);
	}

	internal long GetInt64(int i)
	{
		Sync(i);
		if (_keyInfo[i].query != null)
		{
			return _keyInfo[i].query._reader.GetInt64(_keyInfo[i].column);
		}
		long rowIdForCursor = _stmt._sql.GetRowIdForCursor(_stmt, _keyInfo[i].cursor);
		if (rowIdForCursor == 0L)
		{
			throw new InvalidCastException();
		}
		return Convert.ToInt64(rowIdForCursor);
	}

	internal string GetString(int i)
	{
		Sync(i);
		if (_keyInfo[i].query != null)
		{
			return _keyInfo[i].query._reader.GetString(_keyInfo[i].column);
		}
		throw new InvalidCastException();
	}

	internal object GetValue(int i)
	{
		if (_keyInfo[i].cursor == -1)
		{
			return DBNull.Value;
		}
		Sync(i);
		if (_keyInfo[i].query != null)
		{
			return _keyInfo[i].query._reader.GetValue(_keyInfo[i].column);
		}
		if (IsDBNull(i))
		{
			return DBNull.Value;
		}
		return GetInt64(i);
	}

	internal bool IsDBNull(int i)
	{
		if (_keyInfo[i].cursor == -1)
		{
			return true;
		}
		Sync(i);
		if (_keyInfo[i].query != null)
		{
			return _keyInfo[i].query._reader.IsDBNull(_keyInfo[i].column);
		}
		return _stmt._sql.GetRowIdForCursor(_stmt, _keyInfo[i].cursor) == 0;
	}

	internal void AppendSchemaTable(DataTable tbl)
	{
		KeyQuery keyQuery = null;
		for (int i = 0; i < _keyInfo.Length; i++)
		{
			if (_keyInfo[i].query != null && _keyInfo[i].query == keyQuery)
			{
				continue;
			}
			keyQuery = _keyInfo[i].query;
			if (keyQuery == null)
			{
				DataRow dataRow = tbl.NewRow();
				dataRow[SchemaTableColumn.ColumnName] = _keyInfo[i].columnName;
				dataRow[SchemaTableColumn.ColumnOrdinal] = tbl.Rows.Count;
				dataRow[SchemaTableColumn.ColumnSize] = 8;
				dataRow[SchemaTableColumn.NumericPrecision] = 255;
				dataRow[SchemaTableColumn.NumericScale] = 255;
				dataRow[SchemaTableColumn.ProviderType] = DbType.Int64;
				dataRow[SchemaTableColumn.IsLong] = false;
				dataRow[SchemaTableColumn.AllowDBNull] = false;
				dataRow[SchemaTableOptionalColumn.IsReadOnly] = false;
				dataRow[SchemaTableOptionalColumn.IsRowVersion] = false;
				dataRow[SchemaTableColumn.IsUnique] = false;
				dataRow[SchemaTableColumn.IsKey] = true;
				dataRow[SchemaTableColumn.DataType] = typeof(long);
				dataRow[SchemaTableOptionalColumn.IsHidden] = true;
				dataRow[SchemaTableColumn.BaseColumnName] = _keyInfo[i].columnName;
				dataRow[SchemaTableColumn.IsExpression] = false;
				dataRow[SchemaTableColumn.IsAliased] = false;
				dataRow[SchemaTableColumn.BaseTableName] = _keyInfo[i].tableName;
				dataRow[SchemaTableOptionalColumn.BaseCatalogName] = _keyInfo[i].databaseName;
				dataRow[SchemaTableOptionalColumn.IsAutoIncrement] = true;
				dataRow["DataTypeName"] = "integer";
				tbl.Rows.Add(dataRow);
				continue;
			}
			keyQuery.Sync(0L);
			using DataTable dataTable = keyQuery._reader.GetSchemaTable();
			foreach (DataRow row in dataTable.Rows)
			{
				object[] itemArray = row.ItemArray;
				DataRow dataRow2 = tbl.Rows.Add(itemArray);
				dataRow2[SchemaTableOptionalColumn.IsHidden] = true;
				dataRow2[SchemaTableColumn.ColumnOrdinal] = tbl.Rows.Count - 1;
			}
		}
	}
}
public sealed class SqliteParameter : DbParameter, ICloneable
{
	internal int _dbType;

	private DataRowVersion _rowVersion;

	private object _objValue;

	private string _sourceColumn;

	private string _parameterName;

	private int _dataSize;

	private bool _nullable;

	private bool _nullMapping;

	public override bool IsNullable
	{
		get
		{
			return _nullable;
		}
		set
		{
			_nullable = value;
		}
	}

	[DbProviderSpecificTypeProperty(true)]
	[RefreshProperties(RefreshProperties.All)]
	public override DbType DbType
	{
		get
		{
			if (_dbType == -1)
			{
				if (_objValue != null && _objValue != DBNull.Value)
				{
					return SqliteConvert.TypeToDbType(_objValue.GetType());
				}
				return DbType.String;
			}
			return (DbType)_dbType;
		}
		set
		{
			_dbType = (int)value;
		}
	}

	public override ParameterDirection Direction
	{
		get
		{
			return ParameterDirection.Input;
		}
		set
		{
			if (value != ParameterDirection.Input)
			{
				throw new NotSupportedException();
			}
		}
	}

	public override string ParameterName
	{
		get
		{
			return _parameterName;
		}
		set
		{
			_parameterName = value;
		}
	}

	[DefaultValue(0)]
	public override int Size
	{
		set
		{
			_dataSize = value;
		}
	}

	public override string SourceColumn
	{
		get
		{
			return _sourceColumn;
		}
		set
		{
			_sourceColumn = value;
		}
	}

	public override bool SourceColumnNullMapping
	{
		set
		{
			_nullMapping = value;
		}
	}

	public override DataRowVersion SourceVersion
	{
		get
		{
			return _rowVersion;
		}
		set
		{
			_rowVersion = value;
		}
	}

	[TypeConverter(typeof(StringConverter))]
	[RefreshProperties(RefreshProperties.All)]
	public override object Value
	{
		get
		{
			return _objValue;
		}
		set
		{
			_objValue = value;
			if (_dbType == -1 && _objValue != null && _objValue != DBNull.Value)
			{
				_dbType = (int)SqliteConvert.TypeToDbType(_objValue.GetType());
			}
		}
	}

	public SqliteParameter()
		: this(null, (DbType)(-1), 0, null, DataRowVersion.Current)
	{
	}

	public SqliteParameter(string parameterName, object value)
		: this(parameterName, (DbType)(-1), 0, null, DataRowVersion.Current)
	{
		Value = value;
	}

	public SqliteParameter(string parameterName, DbType parameterType, int parameterSize, string sourceColumn, DataRowVersion rowVersion)
	{
		_parameterName = parameterName;
		_dbType = (int)parameterType;
		_sourceColumn = sourceColumn;
		_rowVersion = rowVersion;
		_objValue = null;
		_dataSize = parameterSize;
		_nullMapping = false;
		_nullable = true;
	}

	private SqliteParameter(SqliteParameter source)
		: this(source.ParameterName, (DbType)source._dbType, 0, source.Direction, source.IsNullable, 0, 0, source.SourceColumn, source.SourceVersion, source.Value)
	{
		_nullMapping = source._nullMapping;
	}

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	public SqliteParameter(string parameterName, DbType parameterType, int parameterSize, ParameterDirection direction, bool isNullable, byte precision, byte scale, string sourceColumn, DataRowVersion rowVersion, object value)
		: this(parameterName, parameterType, parameterSize, sourceColumn, rowVersion)
	{
		Direction = direction;
		IsNullable = isNullable;
		Value = value;
	}

	public object Clone()
	{
		return new SqliteParameter(this);
	}
}
[Editor("Microsoft.VSDesigner.Data.Design.DBParametersEditor, Microsoft.VSDesigner, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", "System.Drawing.Design.UITypeEditor, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
[ListBindable(false)]
public sealed class SqliteParameterCollection : DbParameterCollection
{
	private SqliteCommand _command;

	private List<SqliteParameter> _parameterList;

	private bool _unboundFlag;

	public override bool IsSynchronized => true;

	public override bool IsFixedSize => false;

	public override bool IsReadOnly => false;

	public override object SyncRoot => null;

	public override int Count => _parameterList.Count;

	public new SqliteParameter this[int index] => (SqliteParameter)GetParameter(index);

	internal SqliteParameterCollection(SqliteCommand cmd)
	{
		_command = cmd;
		_parameterList = new List<SqliteParameter>();
		_unboundFlag = true;
	}

	public override IEnumerator GetEnumerator()
	{
		return _parameterList.GetEnumerator();
	}

	public int Add(SqliteParameter parameter)
	{
		int num = -1;
		if (!string.IsNullOrEmpty(parameter.ParameterName))
		{
			num = IndexOf(parameter.ParameterName);
		}
		if (num == -1)
		{
			num = _parameterList.Count;
			_parameterList.Add(parameter);
		}
		SetParameter(num, parameter);
		return num;
	}

	[EditorBrowsable(EditorBrowsableState.Never)]
	public override int Add(object value)
	{
		return Add((SqliteParameter)value);
	}

	public SqliteParameter AddWithValue(string parameterName, object value)
	{
		SqliteParameter sqliteParameter = new SqliteParameter(parameterName, value);
		Add(sqliteParameter);
		return sqliteParameter;
	}

	public override void Clear()
	{
		_unboundFlag = true;
		_parameterList.Clear();
	}

	public override bool Contains(object value)
	{
		return _parameterList.Contains((SqliteParameter)value);
	}

	public override void CopyTo(Array array, int index)
	{
		throw new NotImplementedException();
	}

	protected override DbParameter GetParameter(int index)
	{
		return _parameterList[index];
	}

	public override int IndexOf(string parameterName)
	{
		int count = _parameterList.Count;
		for (int i = 0; i < count; i++)
		{
			if (string.Compare(parameterName, _parameterList[i].ParameterName, ignoreCase: true, CultureInfo.InvariantCulture) == 0)
			{
				return i;
			}
		}
		return -1;
	}

	public override int IndexOf(object value)
	{
		return _parameterList.IndexOf((SqliteParameter)value);
	}

	public override void Insert(int index, object value)
	{
		_unboundFlag = true;
		_parameterList.Insert(index, (SqliteParameter)value);
	}

	public override void Remove(object value)
	{
		_unboundFlag = true;
		_parameterList.Remove((SqliteParameter)value);
	}

	public override void RemoveAt(int index)
	{
		_unboundFlag = true;
		_parameterList.RemoveAt(index);
	}

	protected override void SetParameter(int index, DbParameter value)
	{
		_unboundFlag = true;
		_parameterList[index] = (SqliteParameter)value;
	}

	internal void Unbind()
	{
		_unboundFlag = true;
	}

	internal void MapParameters(SqliteStatement activeStatement)
	{
		if (!_unboundFlag || _parameterList.Count == 0 || _command._statementList == null)
		{
			return;
		}
		int num = 0;
		int num2 = -1;
		foreach (SqliteParameter parameter in _parameterList)
		{
			num2++;
			string text = parameter.ParameterName;
			if (text == null)
			{
				text = string.Format(CultureInfo.InvariantCulture, ";{0}", num);
				num++;
			}
			bool flag = false;
			int num3 = ((activeStatement != null) ? 1 : _command._statementList.Count);
			SqliteStatement sqliteStatement = activeStatement;
			for (int i = 0; i < num3; i++)
			{
				flag = false;
				if (sqliteStatement == null)
				{
					sqliteStatement = _command._statementList[i];
				}
				if (sqliteStatement._paramNames != null && sqliteStatement.MapParameter(text, parameter))
				{
					flag = true;
				}
				sqliteStatement = null;
			}
			if (flag)
			{
				continue;
			}
			text = string.Format(CultureInfo.InvariantCulture, ";{0}", num2);
			sqliteStatement = activeStatement;
			for (int i = 0; i < num3; i++)
			{
				if (sqliteStatement == null)
				{
					sqliteStatement = _command._statementList[i];
				}
				if (sqliteStatement._paramNames != null && sqliteStatement.MapParameter(text, parameter))
				{
					flag = true;
				}
				sqliteStatement = null;
			}
		}
		if (activeStatement == null)
		{
			_unboundFlag = false;
		}
	}
}
internal sealed class SqliteStatement : IDisposable
{
	internal SQLiteBase _sql;

	internal string _sqlStatement;

	internal SqliteStatementHandle _sqlite_stmt;

	internal int _unnamedParameters;

	internal string[] _paramNames;

	internal SqliteParameter[] _paramValues;

	internal SqliteCommand _command;

	private string[] _types;

	internal string[] TypeDefinitions => _types;

	internal SqliteStatement(SQLiteBase sqlbase, SqliteStatementHandle stmt, string strCommand, SqliteStatement previous)
	{
		_sql = sqlbase;
		_sqlite_stmt = stmt;
		_sqlStatement = strCommand;
		int num = 0;
		int num2 = _sql.Bind_ParamCount(this);
		if (num2 <= 0)
		{
			return;
		}
		if (previous != null)
		{
			num = previous._unnamedParameters;
		}
		_paramNames = new string[num2];
		_paramValues = new SqliteParameter[num2];
		for (int i = 0; i < num2; i++)
		{
			string text = _sql.Bind_ParamName(this, i + 1);
			if (string.IsNullOrEmpty(text))
			{
				text = string.Format(CultureInfo.InvariantCulture, ";{0}", num);
				num++;
				_unnamedParameters++;
			}
			_paramNames[i] = text;
			_paramValues[i] = null;
		}
	}

	internal bool MapParameter(string s, SqliteParameter p)
	{
		if (_paramNames == null)
		{
			return false;
		}
		int num = 0;
		if (s.Length > 0 && ":$@;".IndexOf(s[0]) == -1)
		{
			num = 1;
		}
		int num2 = _paramNames.Length;
		for (int i = 0; i < num2; i++)
		{
			if (string.Compare(_paramNames[i], num, s, 0, System.Math.Max(_paramNames[i].Length - num, s.Length), ignoreCase: true, CultureInfo.InvariantCulture) == 0)
			{
				_paramValues[i] = p;
				return true;
			}
		}
		return false;
	}

	public void Dispose()
	{
		if (_sqlite_stmt != null)
		{
			_sqlite_stmt.Dispose();
		}
		_sqlite_stmt = null;
		_paramNames = null;
		_paramValues = null;
		_sql = null;
		_sqlStatement = null;
	}

	internal void BindParameters()
	{
		if (_paramNames != null)
		{
			int num = _paramNames.Length;
			for (int i = 0; i < num; i++)
			{
				BindParameter(i + 1, _paramValues[i]);
			}
		}
	}

	private void BindParameter(int index, SqliteParameter param)
	{
		if (param == null)
		{
			throw new SqliteException(1, "Insufficient parameters supplied to the command");
		}
		object value = param.Value;
		DbType dbType = param.DbType;
		if (Convert.IsDBNull(value) || value == null)
		{
			_sql.Bind_Null(this, index);
			return;
		}
		if (dbType == DbType.Object)
		{
			dbType = SqliteConvert.TypeToDbType(value.GetType());
		}
		switch (dbType)
		{
		case DbType.Date:
		case DbType.DateTime:
		case DbType.Time:
			_sql.Bind_DateTime(this, index, Convert.ToDateTime(value, CultureInfo.CurrentCulture));
			break;
		case DbType.Int64:
		case DbType.UInt32:
		case DbType.UInt64:
			_sql.Bind_Int64(this, index, Convert.ToInt64(value, CultureInfo.CurrentCulture));
			break;
		case DbType.Byte:
		case DbType.Boolean:
		case DbType.Int16:
		case DbType.Int32:
		case DbType.SByte:
		case DbType.UInt16:
			_sql.Bind_Int32(this, index, Convert.ToInt32(value, CultureInfo.CurrentCulture));
			break;
		case DbType.Currency:
		case DbType.Double:
		case DbType.Single:
			_sql.Bind_Double(this, index, Convert.ToDouble(value, CultureInfo.CurrentCulture));
			break;
		case DbType.Binary:
			_sql.Bind_Blob(this, index, (byte[])value);
			break;
		case DbType.Guid:
			if (_command.Connection._binaryGuid)
			{
				_sql.Bind_Blob(this, index, ((Guid)value).ToByteArray());
			}
			else
			{
				_sql.Bind_Text(this, index, value.ToString());
			}
			break;
		case DbType.Decimal:
			_sql.Bind_Text(this, index, Convert.ToDecimal(value, CultureInfo.CurrentCulture).ToString(CultureInfo.InvariantCulture));
			break;
		default:
			_sql.Bind_Text(this, index, value.ToString());
			break;
		}
	}

	internal void SetTypes(string typedefs)
	{
		int num = typedefs.IndexOf("TYPES", 0, StringComparison.OrdinalIgnoreCase);
		if (num == -1)
		{
			throw new ArgumentOutOfRangeException();
		}
		string[] array = typedefs.Substring(num + 6).Replace(" ", "").Replace(";", "")
			.Replace("\"", "")
			.Replace("[", "")
			.Replace("]", "")
			.Replace("`", "")
			.Split(',', '\r', '\n', '\t');
		for (int i = 0; i < array.Length; i++)
		{
			if (string.IsNullOrEmpty(array[i]))
			{
				array[i] = null;
			}
		}
		_types = array;
	}
}
public sealed class SqliteTransaction : DbTransaction
{
	internal SqliteConnection _cnn;

	internal long _version;

	private System.Data.IsolationLevel _level;

	public SqliteConnection Connection => _cnn;

	internal SqliteTransaction(SqliteConnection connection, bool deferredLock)
	{
		_cnn = connection;
		_version = _cnn._version;
		_level = (deferredLock ? System.Data.IsolationLevel.ReadCommitted : System.Data.IsolationLevel.Serializable);
		if (_cnn._transactionLevel++ != 0)
		{
			return;
		}
		try
		{
			using SqliteCommand sqliteCommand = _cnn.CreateCommand();
			if (!deferredLock)
			{
				sqliteCommand.CommandText = "BEGIN IMMEDIATE";
			}
			else
			{
				sqliteCommand.CommandText = "BEGIN";
			}
			sqliteCommand.ExecuteNonQuery();
		}
		catch (SqliteException)
		{
			_cnn._transactionLevel--;
			_cnn = null;
			throw;
		}
	}

	protected override void Dispose(bool disposing)
	{
		if (disposing)
		{
			lock (this)
			{
				if (IsValid(throwError: false))
				{
					Rollback();
				}
				_cnn = null;
			}
		}
		base.Dispose(disposing);
	}

	public override void Rollback()
	{
		IsValid(throwError: true);
		IssueRollback(_cnn);
		_cnn._transactionLevel = 0;
		_cnn = null;
	}

	internal static void IssueRollback(SqliteConnection cnn)
	{
		using SqliteCommand sqliteCommand = cnn.CreateCommand();
		sqliteCommand.CommandText = "ROLLBACK";
		sqliteCommand.ExecuteNonQuery();
	}

	internal bool IsValid(bool throwError)
	{
		if (_cnn == null)
		{
			if (throwError)
			{
				throw new ArgumentNullException("No connection associated with this transaction");
			}
			return false;
		}
		if (_cnn._transactionLevel == 0)
		{
			if (throwError)
			{
				throw new SqliteException(21, "No transaction is active on this connection");
			}
			return false;
		}
		if (_cnn._version != _version)
		{
			if (throwError)
			{
				throw new SqliteException(21, "The connection was closed and re-opened, changes were rolled back");
			}
			return false;
		}
		if (_cnn.State != ConnectionState.Open)
		{
			if (throwError)
			{
				throw new SqliteException(21, "Connection was closed");
			}
			return false;
		}
		return true;
	}
}
[DebuggerNonUserCode]
internal class SR
{
	private static ResourceManager resourceMan;

	private static CultureInfo resourceCulture;

	[EditorBrowsable(EditorBrowsableState.Advanced)]
	internal static ResourceManager ResourceManager
	{
		get
		{
			if (resourceMan == null)
			{
				resourceMan = new ResourceManager("SR", typeof(SR).Assembly);
			}
			return resourceMan;
		}
	}

	internal static string DataTypes => ResourceManager.GetString("DataTypes", resourceCulture);

	internal static string Keywords => ResourceManager.GetString("Keywords", resourceCulture);

	internal static string MetaDataCollections => ResourceManager.GetString("MetaDataCollections", resourceCulture);
}
[SuppressUnmanagedCodeSecurity]
internal static class UnsafeNativeMethods
{
	internal static readonly bool use_sqlite3_close_v2;

	internal static readonly bool use_sqlite3_open_v2;

	internal static readonly bool use_sqlite3_create_function_v2;

	static UnsafeNativeMethods()
	{
		int num = sqlite3_libversion_number();
		Version obj = new Version(build: num % 1000, minor: num / 1000 % 1000, major: num / 1000000);
		use_sqlite3_open_v2 = obj >= new Version(3, 5, 0);
		use_sqlite3_close_v2 = obj >= new Version(3, 7, 14);
		use_sqlite3_create_function_v2 = obj >= new Version(3, 7, 3);
	}

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_close(IntPtr db);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_close_v2(IntPtr db);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_create_function(IntPtr db, byte[] strName, int nArgs, int nType, IntPtr pvUser, SQLiteCallback func, SQLiteCallback fstep, SQLiteFinalCallback ffinal);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_finalize(IntPtr stmt);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_open_v2(byte[] utf8Filename, out IntPtr db, int flags, IntPtr vfs);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_open(byte[] utf8Filename, out IntPtr db);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
	internal static extern int sqlite3_open16(string fileName, out IntPtr db);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_reset(IntPtr stmt);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_bind_parameter_name(IntPtr stmt, int index);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_column_database_name(IntPtr stmt, int index);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_column_database_name16(IntPtr stmt, int index);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_column_decltype(IntPtr stmt, int index);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_column_name(IntPtr stmt, int index);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_column_name16(IntPtr stmt, int index);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_column_origin_name(IntPtr stmt, int index);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_column_origin_name16(IntPtr stmt, int index);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_column_table_name(IntPtr stmt, int index);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_column_table_name16(IntPtr stmt, int index);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_column_text(IntPtr stmt, int index);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_column_text16(IntPtr stmt, int index);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_errmsg(IntPtr db);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_prepare(IntPtr db, IntPtr pSql, int nBytes, out IntPtr stmt, out IntPtr ptrRemain);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_table_column_metadata(IntPtr db, byte[] dbName, byte[] tblName, byte[] colName, out IntPtr ptrDataType, out IntPtr ptrCollSeq, out int notNull, out int primaryKey, out int autoInc);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_value_text(IntPtr p);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_value_text16(IntPtr p);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_libversion();

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_changes(IntPtr db);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_busy_timeout(IntPtr db, int ms);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_bind_blob(IntPtr stmt, int index, byte[] value, int nSize, IntPtr nTransient);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_bind_double(IntPtr stmt, int index, double value);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_bind_int(IntPtr stmt, int index, int value);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_bind_int64(IntPtr stmt, int index, long value);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_bind_null(IntPtr stmt, int index);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_bind_text(IntPtr stmt, int index, byte[] value, int nlen, IntPtr pvReserved);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_bind_parameter_count(IntPtr stmt);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_column_count(IntPtr stmt);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_step(IntPtr stmt);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern double sqlite3_column_double(IntPtr stmt, int index);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_column_int(IntPtr stmt, int index);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern long sqlite3_column_int64(IntPtr stmt, int index);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_column_blob(IntPtr stmt, int index);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_column_bytes(IntPtr stmt, int index);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern TypeAffinity sqlite3_column_type(IntPtr stmt, int index);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_create_collation(IntPtr db, byte[] strName, int nType, IntPtr pvUser, SQLiteCollation func);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_value_blob(IntPtr p);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_value_bytes(IntPtr p);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern double sqlite3_value_double(IntPtr p);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern long sqlite3_value_int64(IntPtr p);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern TypeAffinity sqlite3_value_type(IntPtr p);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void sqlite3_result_blob(IntPtr context, byte[] value, int nSize, IntPtr pvReserved);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void sqlite3_result_double(IntPtr context, double value);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void sqlite3_result_error(IntPtr context, byte[] strErr, int nLen);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void sqlite3_result_int64(IntPtr context, long value);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void sqlite3_result_null(IntPtr context);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern void sqlite3_result_text(IntPtr context, byte[] value, int nLen, IntPtr pvReserved);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_aggregate_context(IntPtr context, int nBytes);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
	internal static extern int sqlite3_bind_text16(IntPtr stmt, int index, string value, int nlen, IntPtr pvReserved);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
	internal static extern void sqlite3_result_error16(IntPtr context, string strName, int nLen);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Unicode)]
	internal static extern void sqlite3_result_text16(IntPtr context, string strName, int nLen, IntPtr pvReserved);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_update_hook(IntPtr db, SQLiteUpdateCallback func, IntPtr pvUser);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_commit_hook(IntPtr db, SQLiteCommitCallback func, IntPtr pvUser);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_rollback_hook(IntPtr db, SQLiteRollbackCallback func, IntPtr pvUser);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern IntPtr sqlite3_next_stmt(IntPtr db, IntPtr stmt);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_exec(IntPtr db, byte[] strSql, IntPtr pvCallback, IntPtr pvParam, out IntPtr errMsg);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_free(IntPtr ptr);

	[DllImport("sqlite3", CallingConvention = CallingConvention.Cdecl)]
	internal static extern int sqlite3_libversion_number();
}
internal class SqliteConnectionHandle : CriticalHandle
{
	public override bool IsInvalid => handle == IntPtr.Zero;

	public static implicit operator IntPtr(SqliteConnectionHandle db)
	{
		return db.handle;
	}

	public static implicit operator SqliteConnectionHandle(IntPtr db)
	{
		return new SqliteConnectionHandle(db);
	}

	private SqliteConnectionHandle(IntPtr db)
		: this()
	{
		SetHandle(db);
	}

	internal SqliteConnectionHandle()
		: base(IntPtr.Zero)
	{
	}

	protected override bool ReleaseHandle()
	{
		try
		{
			SQLiteBase.CloseConnection(this);
		}
		catch (SqliteException)
		{
		}
		return true;
	}
}
internal class SqliteStatementHandle : CriticalHandle
{
	public override bool IsInvalid => handle == IntPtr.Zero;

	public static implicit operator IntPtr(SqliteStatementHandle stmt)
	{
		return stmt.handle;
	}

	public static implicit operator SqliteStatementHandle(IntPtr stmt)
	{
		return new SqliteStatementHandle(stmt);
	}

	private SqliteStatementHandle(IntPtr stmt)
		: this()
	{
		SetHandle(stmt);
	}

	internal SqliteStatementHandle()
		: base(IntPtr.Zero)
	{
	}

	protected override bool ReleaseHandle()
	{
		try
		{
			SQLiteBase.FinalizeStatement(this);
		}
		catch (SqliteException)
		{
		}
		return true;
	}
}
