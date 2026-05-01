using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Amazon.S3.Model;
using iFit.Aws.Core;
using iFit.Files;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("iFit Mobile")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("Log file utilities for uploading or deleting log files.")]
[assembly: AssemblyFileVersion("2.1.0.0")]
[assembly: AssemblyInformationalVersion("2.1.0")]
[assembly: AssemblyProduct("iFit.Logger.Files")]
[assembly: AssemblyTitle("iFit.Logger.Files")]
[assembly: AssemblyVersion("2.1.0.0")]
namespace iFit.Logger.Files;

public static class Defaults
{
	public const string DefaultS3LogUploadDir = "logs/";
}
public interface ILogFileServiceConfig
{
	string LogDirPath { get; }

	string EruLogPath { get; }

	double MaxLogFolderSizeMB { get; }

	int MaxDaysToKeepLogs { get; }
}
public interface ILogFileService
{
	ILogFileServiceConfig Config { get; }

	Task<LogFileUploadResult> UploadLatestLogFileToS3(string uploadedName, string uploadDirectory = "logs/");

	Task<string> UploadLogsToS3AndCreateDescription(string uploadDirectory = "logs/", string supplementalCrashReport = null, IList<string> excludedLogs = null, bool shouldZip = true);

	Task<List<LogFileUploadResult>> UploadLogsToS3(List<LogFileUploadResult> logFiles, bool deleteUponSuccess = false);

	List<LogFileUploadResult> PrepareFilesForS3(List<IFileInfo> logFiles, string folderPath = "logs/", bool shouldZip = true);

	LogFileUploadResult PrepareFileForS3(IFileInfo logFile, string folderPath = "logs/", bool prependGuid = true, string uploadedName = null, bool shouldZip = true);

	Task DeleteAllLogs();

	Task DeleteLogs(List<IFileInfo> files);

	Task DeleteOldLogsAndBigLogs();

	Task DeleteOldLogs();

	Task DeleteBigLogs();

	List<IFileInfo> GetLogs();

	void WriteTextToFile(string fileName, string text);
}
public class LogFileService : ILogFileService
{
	private const string ErrorTag = "Error";

	private readonly IFileService fileService;

	private readonly SemaphoreSlim fileLock = new SemaphoreSlim(1, 1);

	public ILogFileServiceConfig Config { get; }

	public LogFileService(IFileService fileService, ILogFileServiceConfig config)
	{
		Config = config;
		this.fileService = fileService;
	}

	public async Task DeleteAllLogs()
	{
		try
		{
			List<IFileInfo> logs = GetLogs();
			await DeleteLogs(logs);
		}
		catch (FileNotFoundException)
		{
		}
	}

	public async Task DeleteLogs(List<IFileInfo> files)
	{
		if (files == null || files.Count == 0)
		{
			return;
		}
		try
		{
			foreach (IFileInfo file in files)
			{
				await DeleteLogFile(file);
			}
		}
		catch (FileNotFoundException)
		{
		}
	}

	private async Task DeleteLogFile(IFileInfo fileStats)
	{
		if (fileStats == null)
		{
			return;
		}
		try
		{
			await fileStats.DeleteAsync();
		}
		catch (FileNotFoundException)
		{
		}
	}

	public async Task DeleteOldLogsAndBigLogs()
	{
		await DeleteOldLogs();
		await DeleteBigLogs();
	}

	public async Task DeleteOldLogs()
	{
		try
		{
			DateTime utcNow = DateTime.UtcNow;
			List<IFileInfo> list = GetLogs()?.Where((IFileInfo x) => (utcNow - x.CreationTimeUtc).TotalDays >= (double)Config.MaxDaysToKeepLogs).ToList();
			if (list != null && list.Count != 0)
			{
				await DeleteLogs(list);
			}
		}
		catch (FileNotFoundException)
		{
		}
	}

	public async Task DeleteBigLogs()
	{
		try
		{
			double maxLogAmountMB = Config.MaxLogFolderSizeMB;
			List<IFileInfo> logs = GetLogs();
			double num = logs.Sum((IFileInfo x) => x.SizeMB);
			if (!(num > maxLogAmountMB))
			{
				return;
			}
			double sizeToRemove = num - maxLogAmountMB;
			double pendingRemovalSize = 0.0;
			List<IFileInfo> list = logs.TakeWhile(delegate(IFileInfo x)
			{
				double sizeMB = x.SizeMB;
				bool num2 = pendingRemovalSize + sizeMB < sizeToRemove || sizeMB > maxLogAmountMB || (sizeMB > sizeToRemove && pendingRemovalSize <= 0.0);
				if (num2)
				{
					pendingRemovalSize += sizeMB;
				}
				return num2;
			}).ToList();
			if (list != null && list.Count != 0)
			{
				await DeleteLogs(list);
			}
		}
		catch (FileNotFoundException)
		{
		}
	}

	public List<IFileInfo> GetLogs()
	{
		return fileService.GetFiles(Config.LogDirPath, includeDirectories: false);
	}

	public LogFileUploadResult PrepareFileForS3(IFileInfo logFile, string folderPath = "logs/", bool prependGuid = true, string uploadedName = null, bool shouldZip = true)
	{
		if (logFile == null)
		{
			return null;
		}
		string text = uploadedName ?? logFile.Name;
		if (prependGuid)
		{
			text = $"{Guid.NewGuid()}_{text}";
		}
		if (folderPath != null)
		{
			text = Path.Combine(folderPath, text);
		}
		if (shouldZip)
		{
			text += ".gz";
		}
		string logUrl = S3.UrlForKey(text);
		return new LogFileUploadResult
		{
			Log = logFile,
			LogUrl = logUrl,
			LocalPath = text
		};
	}

	public List<LogFileUploadResult> PrepareFilesForS3(List<IFileInfo> logFiles, string folderPath = "logs/", bool shouldZip = true)
	{
		if (logFiles == null || logFiles.Count == 0)
		{
			return null;
		}
		List<LogFileUploadResult> list = new List<LogFileUploadResult>();
		foreach (IFileInfo logFile in logFiles)
		{
			list.Add(PrepareFileForS3(logFile, folderPath, prependGuid: true, null, shouldZip));
		}
		return list;
	}

	public async Task<List<LogFileUploadResult>> UploadLogsToS3(List<LogFileUploadResult> logFiles, bool deleteUponSuccess = false)
	{
		if (logFiles == null || logFiles.Count == 0)
		{
			return null;
		}
		foreach (LogFileUploadResult file in logFiles)
		{
			if (file == null)
			{
				continue;
			}
			object obj = null;
			try
			{
				try
				{
					await UploadFileToS3(file);
				}
				catch (Exception arg)
				{
					Log.Error("Error", $"An error occurred uploading files to S3: {arg}");
				}
			}
			catch (object obj2)
			{
				obj = obj2;
			}
			if (deleteUponSuccess)
			{
				PutObjectResponse response = file.Response;
				if (response != null && response.HttpStatusCode == HttpStatusCode.OK)
				{
					await DeleteLogFile(file.Log);
				}
			}
			object obj3 = obj;
			if (obj3 != null)
			{
				ExceptionDispatchInfo.Capture((obj3 as Exception) ?? throw obj3).Throw();
			}
		}
		return logFiles;
	}

	private async Task<LogFileUploadResult> UploadFileToS3(LogFileUploadResult preparedFile)
	{
		if (preparedFile == null)
		{
			return null;
		}
		try
		{
			await fileLock.WaitAsync();
			return (!ShouldZipFile(preparedFile)) ? (await UploadUnzippedFileToS3(preparedFile)) : (await UploadZippedFileToS3(preparedFile));
		}
		finally
		{
			fileLock.Release();
		}
	}

	private bool ShouldZipFile(LogFileUploadResult file)
	{
		return file.LocalPath.EndsWith(".gz", StringComparison.Ordinal);
	}

	private async Task<LogFileUploadResult> UploadUnzippedFileToS3(LogFileUploadResult preparedFile)
	{
		using FileStream stream = await (await preparedFile.Log.GetFileAsync()).OpenAsync(FileAccess.Read);
		preparedFile.Response = await S3.PutObjectStream(preparedFile.LocalPath, stream);
		return preparedFile;
	}

	private async Task<LogFileUploadResult> UploadZippedFileToS3(LogFileUploadResult preparedFile)
	{
		using FileStream fileStream = await (await preparedFile.Log.GetFileAsync()).OpenAsync(FileAccess.Read);
		using MemoryStream compressedStream = new MemoryStream();
		using (GZipStream destination = new GZipStream(compressedStream, CompressionMode.Compress, leaveOpen: true))
		{
			fileStream.CopyTo(destination);
		}
		preparedFile.Response = await S3.PutObjectStream(preparedFile.LocalPath, compressedStream);
		return preparedFile;
	}

	public async Task<LogFileUploadResult> UploadLatestLogFileToS3(string uploadedName, string uploadDirectory = "logs/")
	{
		try
		{
			DateTime date = DateTime.Now.Date.AddDays(-Config.MaxDaysToKeepLogs);
			string logDirPath = Config.LogDirPath;
			List<IFileInfo> filesCreatedAfter = fileService.GetFilesCreatedAfter(logDirPath, date, includeDirectories: false);
			IFileInfo fileInfo = filesCreatedAfter.OrderByDescending((IFileInfo x) => x.CreationTime).FirstOrDefault();
			if (filesCreatedAfter.Count == 0 || fileInfo == null)
			{
				return null;
			}
			LogFileUploadResult logFileUploadResult = PrepareFileForS3(fileInfo, uploadDirectory, prependGuid: false, uploadedName);
			if (logFileUploadResult != null)
			{
				return (await UploadLogsToS3(new List<LogFileUploadResult> { logFileUploadResult })).FirstOrDefault();
			}
		}
		catch (Exception)
		{
		}
		return null;
	}

	public async Task<string> UploadLogsToS3AndCreateDescription(string uploadDirectory = "logs/", string supplementalCrashReport = null, IList<string> excludedLogs = null, bool shouldZip = true)
	{
		_ = 1;
		try
		{
			DateTime logDate = DateTime.Now.Date.AddDays(-Config.MaxDaysToKeepLogs);
			string logDirPath = Config.LogDirPath;
			List<LogFileUploadResult> list = PrepareLogs(logDirPath, logDate, uploadDirectory, excludedLogs);
			string description = string.Join(Environment.NewLine, list.Select((LogFileUploadResult x) => x.LogUrl));
			if (list == null)
			{
				return string.Empty;
			}
			if (!string.IsNullOrWhiteSpace(supplementalCrashReport))
			{
				description = description + Environment.NewLine + Environment.NewLine + supplementalCrashReport;
			}
			await UploadLogsToS3(list);
			if (!string.IsNullOrEmpty(Config.EruLogPath))
			{
				description += Environment.NewLine;
				string uploadDirectory2 = uploadDirectory + "eru/";
				List<LogFileUploadResult> eruLogs = PrepareLogs(Config.EruLogPath, logDate, uploadDirectory2);
				await UploadLogsToS3(eruLogs);
				description += string.Join(Environment.NewLine + Environment.NewLine, eruLogs.Select((LogFileUploadResult x) => x.LogUrl));
			}
			return description;
		}
		catch (Exception)
		{
			return string.Empty;
		}
	}

	private List<LogFileUploadResult> PrepareLogs(string directory, DateTime logDate, string uploadDirectory, IList<string> excludedLogs = null, bool shouldZip = true)
	{
		try
		{
			List<IFileInfo> filesCreatedAfter = fileService.GetFilesCreatedAfter(directory, logDate, includeDirectories: false);
			if (filesCreatedAfter == null || filesCreatedAfter.Count == 0)
			{
				return null;
			}
			if (excludedLogs != null && excludedLogs.Count > 0)
			{
				filesCreatedAfter.RemoveAll((IFileInfo log) => excludedLogs.Contains(log.Name));
			}
			return PrepareFilesForS3(filesCreatedAfter, uploadDirectory, shouldZip);
		}
		catch (Exception exception)
		{
			Log.Error("Error", "Unable to prepare logs in " + directory, exception);
			return null;
		}
	}

	public void WriteTextToFile(string fileName, string text)
	{
		writeTextToFileAsync().ConfigureAwait(continueOnCapturedContext: false);
		async Task writeTextToFileAsync()
		{
			_ = 3;
			try
			{
				await fileLock.WaitAsync();
				await (await (await FileSystem.Current.LocalStorage.CreateFolderAsync(Config.LogDirPath, CreationCollisionOption.OpenIfExists)).CreateFileAsync(fileName, CreationCollisionOption.OpenIfExists)).AppendAllTextAsync(text + Environment.NewLine);
			}
			catch (Exception ex)
			{
				Log.Error("Error", $"Unable to write to file: {ex.GetBaseException()}");
			}
			finally
			{
				fileLock.Release();
			}
		}
	}
}
public class LogFileUploadResult
{
	public IFileInfo Log { get; set; }

	public string LogUrl { get; set; }

	public string LocalPath { get; set; }

	public PutObjectResponse Response { get; set; }
}
