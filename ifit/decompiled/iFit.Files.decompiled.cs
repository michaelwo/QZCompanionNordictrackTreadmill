using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("iFit Mobile")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyDescription("iFit's File Services")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("iFit.Files")]
[assembly: AssemblyTitle("iFit.Files")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace iFit.Files;

public static class AwaitExtensions
{
	public struct TaskSchedulerAwaiter(TaskScheduler taskScheduler, CancellationToken cancellationToken) : INotifyCompletion
	{
		private TaskScheduler taskScheduler = taskScheduler;

		private CancellationToken cancellationToken = cancellationToken;

		public bool IsCompleted => taskScheduler == null;

		public TaskSchedulerAwaiter GetAwaiter()
		{
			return this;
		}

		public void OnCompleted(Action continuation)
		{
			if (taskScheduler == null)
			{
				throw new InvalidOperationException("IsCompleted is true, so this is unexpected.");
			}
			Task.Factory.StartNew(continuation, CancellationToken.None, TaskCreationOptions.None, taskScheduler);
		}

		public void GetResult()
		{
			cancellationToken.ThrowIfCancellationRequested();
		}
	}

	public static TaskSchedulerAwaiter SwitchOffMainThreadAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		cancellationToken.ThrowIfCancellationRequested();
		return new TaskSchedulerAwaiter((SynchronizationContext.Current != null) ? TaskScheduler.Default : null, cancellationToken);
	}
}
public enum ExistenceCheckResult
{
	NotFound,
	FileExists,
	FolderExists
}
public interface IFileService
{
	List<IFileInfo> GetFiles(string absolutePath, bool includeDirectories);

	List<IFileInfo> GetFilesCreatedAfter(string absolutePath, DateTime date, bool includeDirectories);
}
public class FileService : IFileService
{
	private readonly IFileInfoFactory factory;

	public FileService(IFileInfoFactory factory)
	{
		this.factory = factory;
	}

	public List<IFileInfo> GetFiles(string absolutePath, bool includeDirectories)
	{
		IFileInfo fileInfo = factory.Create(absolutePath);
		if (fileInfo.IsDirectory)
		{
			return fileInfo.GetChildren(includeDirectories);
		}
		return new List<IFileInfo> { fileInfo };
	}

	public List<IFileInfo> GetFilesCreatedAfter(string absolutePath, DateTime date, bool includeDirectories)
	{
		return (from f in GetFiles(absolutePath, includeDirectories)
			where f.CreationTime > date
			select f).ToList();
	}
}
public interface IFileSystem
{
	IFolder LocalStorage { get; }
}
public static class FileSystem
{
	private static IFileSystem fileSystem;

	public static IFileSystem Current
	{
		get
		{
			if (fileSystem == null)
			{
				fileSystem = new IFitFileSystem();
			}
			return fileSystem;
		}
	}
}
public class IFitFileSystem : IFileSystem
{
	public IFolder LocalStorage => GetLocalStorage();

	private IFolder GetLocalStorage()
	{
		string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
		DirectoryInfo directoryInfo = new DirectoryInfo(folderPath);
		return new IFitFolder(folderPath, directoryInfo.Name);
	}
}
public interface IFile
{
	string Name { get; }

	string Path { get; }

	Task<FileStream> OpenAsync(FileAccess fileAccess, CancellationToken cancellationToken = default(CancellationToken));

	Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task RenameAsync(string newName, NameCollisionOption collisionOption = NameCollisionOption.FailIfExists, CancellationToken cancellationToken = default(CancellationToken));

	Task MoveAsync(string newPath, NameCollisionOption collisionOption = NameCollisionOption.ReplaceExisting, CancellationToken cancellationToken = default(CancellationToken));

	Task AppendAllTextAsync(string contents);

	Task AppendAllLinesAsync(IEnumerable<string> contents);

	Task AppendAllLinesAsync(params string[] contents);

	Task<string> ReadAllTextAsync();

	Task WriteAllTextAsync(string contents);
}
public class IFitFile : IFile
{
	public string Path { get; private set; }

	public string Name { get; private set; }

	public IFitFile(string path, string name)
	{
		Path = path;
		Name = name;
	}

	public async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		await AwaitExtensions.SwitchOffMainThreadAsync();
		File.Delete(Path);
	}

	public async Task MoveAsync(string newPath, NameCollisionOption collisionOption = NameCollisionOption.ReplaceExisting, CancellationToken cancellationToken = default(CancellationToken))
	{
		await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
		string directoryName = System.IO.Path.GetDirectoryName(newPath);
		string fileName = System.IO.Path.GetFileName(newPath);
		int num = 1;
		string text;
		string text2;
		while (true)
		{
			cancellationToken.ThrowIfCancellationRequested();
			text = fileName;
			if (num > 1)
			{
				text = string.Format(CultureInfo.InvariantCulture, "{0} ({1}){2}", System.IO.Path.GetFileNameWithoutExtension(fileName), num, System.IO.Path.GetExtension(fileName));
			}
			text2 = System.IO.Path.Combine(directoryName, text);
			if (File.Exists(text2))
			{
				switch (collisionOption)
				{
				case NameCollisionOption.FailIfExists:
					throw new IOException("File already exists.");
				case NameCollisionOption.ReplaceExisting:
					File.Delete(text2);
					break;
				case NameCollisionOption.GenerateUniqueName:
					goto IL_012b;
				}
			}
			break;
			IL_012b:
			num++;
		}
		File.Move(Path, text2);
		Path = text2;
		Name = text;
	}

	public async Task<FileStream> OpenAsync(FileAccess fileAccess, CancellationToken cancellationToken = default(CancellationToken))
	{
		await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
		return File.Open(Path, FileMode.Open, fileAccess);
	}

	public async Task RenameAsync(string newName, NameCollisionOption collisionOption = NameCollisionOption.FailIfExists, CancellationToken cancellationToken = default(CancellationToken))
	{
		await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
		string newPath = System.IO.Path.Combine(System.IO.Path.GetDirectoryName(Path), newName);
		await MoveAsync(newPath, collisionOption, cancellationToken);
	}

	public async Task AppendAllTextAsync(string contents)
	{
		await AwaitExtensions.SwitchOffMainThreadAsync();
		File.AppendAllText(Path, contents);
	}

	public async Task AppendAllLinesAsync(IEnumerable<string> contents)
	{
		await AwaitExtensions.SwitchOffMainThreadAsync();
		File.AppendAllLines(Path, contents);
	}

	public async Task AppendAllLinesAsync(params string[] contents)
	{
		await AwaitExtensions.SwitchOffMainThreadAsync();
		File.AppendAllLines(Path, contents);
	}

	public async Task<string> ReadAllTextAsync()
	{
		await AwaitExtensions.SwitchOffMainThreadAsync();
		FileStream obj = await OpenAsync(FileAccess.Read);
		StreamReader streamReader = new StreamReader(obj);
		string result = streamReader.ReadToEnd();
		obj.Close();
		streamReader.Close();
		obj.Dispose();
		streamReader.Dispose();
		return result;
	}

	public async Task WriteAllTextAsync(string contents)
	{
		await AwaitExtensions.SwitchOffMainThreadAsync();
		File.WriteAllText(Path, contents);
	}
}
public interface IFileInfo
{
	string Path { get; }

	string Name { get; }

	string Extension { get; }

	DateTime CreationTime { get; }

	DateTime CreationTimeUtc { get; }

	DateTime LastAccessTime { get; }

	DateTime LastAccessTimeUtc { get; }

	DateTime LastWriteTime { get; }

	DateTime LastWriteTimeUtc { get; }

	long SizeBytes { get; }

	double SizeMB { get; }

	bool IsDirectory { get; }

	Task<IFile> GetFileAsync();

	Task<IFolder> GetFolderAsync();

	Task DeleteAsync();

	List<IFileInfo> GetChildren(bool includeDirectories);
}
public class FileInfo : IFileInfo
{
	public string Path { get; private set; }

	public string Name { get; private set; }

	public string Extension { get; private set; }

	public DateTime CreationTime { get; private set; }

	public DateTime CreationTimeUtc { get; private set; }

	public DateTime LastAccessTime { get; private set; }

	public DateTime LastAccessTimeUtc { get; private set; }

	public DateTime LastWriteTime { get; private set; }

	public DateTime LastWriteTimeUtc { get; private set; }

	public long SizeBytes { get; private set; }

	public double SizeMB => (double)SizeBytes / 1000000.0;

	public bool IsDirectory { get; private set; }

	public async Task<IFile> GetFileAsync()
	{
		await AwaitExtensions.SwitchOffMainThreadAsync();
		return new IFitFile(Path, Name);
	}

	public async Task<IFolder> GetFolderAsync()
	{
		await AwaitExtensions.SwitchOffMainThreadAsync();
		return new IFitFolder(Path, Name);
	}

	public async Task DeleteAsync()
	{
		if (IsDirectory)
		{
			IFolder folder = await GetFolderAsync();
			if (folder != null)
			{
				await folder.DeleteAsync();
			}
		}
		else
		{
			IFile file = await GetFileAsync();
			if (file != null)
			{
				await file.DeleteAsync();
			}
		}
	}

	public FileInfo(string path)
	{
		Path = path;
		if (File.Exists(path))
		{
			Init(new System.IO.FileInfo(path));
			return;
		}
		if (Directory.Exists(path))
		{
			Init(new DirectoryInfo(path));
			return;
		}
		throw new FileNotFoundException("The file/dir at " + path + " was not found.");
	}

	private void Init(System.IO.FileInfo info)
	{
		Name = info.Name;
		Extension = info.Extension;
		CreationTime = info.CreationTime;
		CreationTimeUtc = info.CreationTimeUtc;
		LastAccessTime = info.LastAccessTime;
		LastAccessTimeUtc = info.LastAccessTimeUtc;
		LastWriteTime = info.LastWriteTime;
		LastWriteTimeUtc = info.LastWriteTimeUtc;
		SizeBytes = info.Length;
		IsDirectory = false;
	}

	private void Init(DirectoryInfo info)
	{
		Name = info.Name;
		Extension = string.Empty;
		CreationTime = info.CreationTime;
		CreationTimeUtc = info.CreationTimeUtc;
		LastAccessTime = info.LastAccessTime;
		LastAccessTimeUtc = info.LastAccessTimeUtc;
		LastWriteTime = info.LastWriteTime;
		LastWriteTimeUtc = info.LastWriteTimeUtc;
		IsDirectory = true;
	}

	public List<IFileInfo> GetChildren(bool includeDirectories)
	{
		if (!IsDirectory)
		{
			throw new DirectoryNotFoundException("Unable to get children for " + Name + " because it's a file.");
		}
		return GetFilesRecursively(Path, includeDirectories);
	}

	private static List<IFileInfo> GetFilesRecursively(string path, bool includeDirectories)
	{
		List<IFileInfo> results = new List<IFileInfo>();
		if (includeDirectories)
		{
			results.Add(new FileInfo(path));
		}
		DirectoryInfo directoryInfo = new DirectoryInfo(path);
		(from f in directoryInfo.EnumerateFiles()
			where f != null
			select f).ToList().ForEach(delegate(System.IO.FileInfo f)
		{
			results.Add(new FileInfo(f.FullName));
		});
		(from d in directoryInfo.EnumerateDirectories()
			where d != null
			select d).ToList().ForEach(delegate(DirectoryInfo d)
		{
			results.AddRange(GetFilesRecursively(d.FullName, includeDirectories));
		});
		return results;
	}
}
public interface IFileInfoFactory
{
	IFileInfo Create(string path);
}
public class FileInfoFactory : IFileInfoFactory
{
	public IFileInfo Create(string path)
	{
		return new FileInfo(path);
	}
}
public enum CreationCollisionOption
{
	GenerateUniqueName,
	ReplaceExisting,
	FailIfExists,
	OpenIfExists
}
public interface IFolder
{
	string Name { get; }

	string Path { get; }

	Task<IFile> CreateFileAsync(string desiredName, CreationCollisionOption option, CancellationToken cancellationToken = default(CancellationToken));

	Task<IFile> GetFileAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

	Task<IList<IFile>> GetFilesAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<IFolder> CreateFolderAsync(string desiredName, CreationCollisionOption option, CancellationToken cancellationToken = default(CancellationToken));

	Task<IFolder> GetFolderAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

	Task<IList<IFolder>> GetFoldersAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task<ExistenceCheckResult> CheckExistsAsync(string name, CancellationToken cancellationToken = default(CancellationToken));

	Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));
}
internal class IFitFolder : IFolder
{
	public string Path { get; private set; }

	public string Name { get; private set; }

	public IFitFolder(string path, string name)
	{
		Path = path;
		Name = name;
	}

	public async Task<ExistenceCheckResult> CheckExistsAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
	{
		await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
		string path = System.IO.Path.Combine(Path, name);
		if (File.Exists(path))
		{
			return ExistenceCheckResult.FileExists;
		}
		if (Directory.Exists(path))
		{
			return ExistenceCheckResult.FolderExists;
		}
		return ExistenceCheckResult.NotFound;
	}

	public async Task<IFile> CreateFileAsync(string desiredName, CreationCollisionOption option, CancellationToken cancellationToken = default(CancellationToken))
	{
		await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
		EnsureExists();
		string text = desiredName;
		string text2 = System.IO.Path.Combine(Path, text);
		if (File.Exists(text2))
		{
			switch (option)
			{
			case CreationCollisionOption.GenerateUniqueName:
			{
				string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(desiredName);
				string extension = System.IO.Path.GetExtension(desiredName);
				int num = 2;
				while (File.Exists(text2))
				{
					text = $"{fileNameWithoutExtension} ({num}){extension}";
					text2 = System.IO.Path.Combine(Path, text);
					num++;
				}
				InternalCreateFile(text2);
				break;
			}
			case CreationCollisionOption.ReplaceExisting:
				File.Delete(text2);
				InternalCreateFile(text2);
				break;
			case CreationCollisionOption.FailIfExists:
				throw new IOException("File already exists: " + text2);
			default:
				throw new ArgumentException($"Unrecognized CreationCollisionOption: {option}");
			case CreationCollisionOption.OpenIfExists:
				break;
			}
		}
		else
		{
			InternalCreateFile(text2);
		}
		return new IFitFile(text2, text);
	}

	public async Task<IFolder> CreateFolderAsync(string desiredName, CreationCollisionOption option, CancellationToken cancellationToken = default(CancellationToken))
	{
		await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
		EnsureExists();
		string nameToUse = desiredName;
		string newPath = System.IO.Path.Combine(Path, nameToUse);
		if (Directory.Exists(newPath))
		{
			switch (option)
			{
			case CreationCollisionOption.GenerateUniqueName:
			{
				int num = 2;
				while (Directory.Exists(newPath))
				{
					nameToUse = $"{desiredName} ({num})";
					newPath = System.IO.Path.Combine(Path, nameToUse);
					num++;
				}
				Directory.CreateDirectory(newPath);
				break;
			}
			case CreationCollisionOption.ReplaceExisting:
				await new IFitFolder(Path, nameToUse).DeleteAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				Directory.CreateDirectory(newPath);
				break;
			case CreationCollisionOption.FailIfExists:
				throw new IOException("Directory already exists: " + newPath);
			default:
				throw new ArgumentException($"Unrecognized CreationCollisionOption: {option}");
			case CreationCollisionOption.OpenIfExists:
				break;
			}
		}
		else
		{
			Directory.CreateDirectory(newPath);
		}
		return new IFitFolder(newPath, nameToUse);
	}

	public async Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
		EnsureExists();
		if (string.IsNullOrEmpty(Path))
		{
			throw new IOException("Cannot delete root Isolated Storage folder.");
		}
		Directory.Delete(Path, recursive: true);
	}

	public async Task<IFile> GetFileAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
	{
		await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
		EnsureExists();
		string text = System.IO.Path.Combine(Path, name);
		if (!File.Exists(text))
		{
			throw new FileNotFoundException("File does not exist: " + text);
		}
		return new IFitFile(text, name);
	}

	public async Task<IList<IFile>> GetFilesAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
		EnsureExists();
		return (from fileNameWithPath in Directory.GetFiles(Path)
			select new IFitFile(fileNameWithPath, System.IO.Path.GetFileName(fileNameWithPath))).Cast<IFile>().ToList().AsReadOnly();
	}

	public async Task<IFolder> GetFolderAsync(string name, CancellationToken cancellationToken = default(CancellationToken))
	{
		await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
		EnsureExists();
		string text = System.IO.Path.Combine(Path, name);
		if (!Directory.Exists(text))
		{
			throw new DirectoryNotFoundException("Directory does not exist: " + text);
		}
		return new IFitFolder(Path, name);
	}

	public async Task<IList<IFolder>> GetFoldersAsync(CancellationToken cancellationToken = default(CancellationToken))
	{
		await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
		EnsureExists();
		return (from fn in Directory.GetDirectories(System.IO.Path.Combine(Path, "*"))
			select new IFitFolder(Path, fn)).Cast<IFolder>().ToList().AsReadOnly();
	}

	private void EnsureExists()
	{
		if (!Directory.Exists(Path))
		{
			throw new DirectoryNotFoundException("The specified folder does not exist: " + Path);
		}
	}

	private void InternalCreateFile(string path)
	{
		File.Create(path).Close();
	}
}
public enum NameCollisionOption
{
	GenerateUniqueName,
	ReplaceExisting,
	FailIfExists
}
