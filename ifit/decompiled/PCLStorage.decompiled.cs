using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;
using Android.Runtime;
using PCLStorage.Exceptions;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyDescription("")]
[assembly: ComVisible(false)]
[assembly: AssemblyFileVersion("1.0.2.0")]
[assembly: ResourceDesigner("PCLStorage.Resource", IsApplication = false)]
[assembly: AssemblyConfiguration("")]
[assembly: NeutralResourcesLanguage("en")]
[assembly: AssemblyTitle("PCLStorage.Android")]
[assembly: TargetFramework("MonoAndroid,Version=v2.2", FrameworkDisplayName = "Xamarin.Android v2.2 Support")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("PCLStorage")]
[assembly: AssemblyCopyright("Copyright ©  2013")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyVersion("1.0.2.0")]
namespace PCLStorage
{
	public class DesktopFileSystem : IFileSystem
	{
		public IFolder LocalStorage
		{
			get
			{
				string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
				return new FileSystemFolder(folderPath);
			}
		}

		public IFolder RoamingStorage => null;

		public async Task<IFile> GetFileFromPathAsync(string path, CancellationToken cancellationToken)
		{
			Requires.NotNullOrEmpty(path, "path");
			await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
			if (File.Exists(path))
			{
				return new FileSystemFile(path);
			}
			return null;
		}

		public async Task<IFolder> GetFolderFromPathAsync(string path, CancellationToken cancellationToken)
		{
			Requires.NotNullOrEmpty(path, "path");
			await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
			if (Directory.Exists(path))
			{
				return new FileSystemFolder(path, canDelete: true);
			}
			return null;
		}
	}
	[DebuggerDisplay("Name = {_name}")]
	public class FileSystemFile : IFile
	{
		private string _name;

		private string _path;

		public string Name => _name;

		public string Path => _path;

		public FileSystemFile(string path)
		{
			_name = System.IO.Path.GetFileName(path);
			_path = path;
		}

		public async Task<Stream> OpenAsync(FileAccess fileAccess, CancellationToken cancellationToken)
		{
			await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
			return fileAccess switch
			{
				FileAccess.Read => File.OpenRead(Path), 
				FileAccess.ReadAndWrite => File.Open(Path, FileMode.Open, System.IO.FileAccess.ReadWrite), 
				_ => throw new ArgumentException("Unrecognized FileAccess value: " + fileAccess), 
			};
		}

		public async Task DeleteAsync(CancellationToken cancellationToken)
		{
			await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
			if (!File.Exists(Path))
			{
				throw new PCLStorage.Exceptions.FileNotFoundException("File does not exist: " + Path);
			}
			File.Delete(Path);
		}

		public async Task RenameAsync(string newName, NameCollisionOption collisionOption, CancellationToken cancellationToken)
		{
			Requires.NotNullOrEmpty(newName, "newName");
			await MoveAsync(PortablePath.Combine(System.IO.Path.GetDirectoryName(_path), newName), collisionOption, cancellationToken);
		}

		public async Task MoveAsync(string newPath, NameCollisionOption collisionOption, CancellationToken cancellationToken)
		{
			Requires.NotNullOrEmpty(newPath, "newPath");
			await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
			string newDirectory = System.IO.Path.GetDirectoryName(newPath);
			string newName = System.IO.Path.GetFileName(newPath);
			int num = 1;
			string text;
			string text2;
			while (true)
			{
				cancellationToken.ThrowIfCancellationRequested();
				text = newName;
				if (num > 1)
				{
					text = string.Format(CultureInfo.InvariantCulture, "{0} ({1}){2}", new object[3]
					{
						System.IO.Path.GetFileNameWithoutExtension(newName),
						num,
						System.IO.Path.GetExtension(newName)
					});
				}
				text2 = PortablePath.Combine(newDirectory, text);
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
						goto IL_018c;
					}
				}
				break;
				IL_018c:
				num++;
			}
			File.Move(_path, text2);
			_path = text2;
			_name = text;
		}
	}
	[DebuggerDisplay("Name = {_name}")]
	public class FileSystemFolder : IFolder
	{
		private readonly string _name;

		private readonly string _path;

		private readonly bool _canDelete;

		public string Name => _name;

		public string Path => _path;

		public FileSystemFolder(string path, bool canDelete)
		{
			_name = System.IO.Path.GetFileName(path);
			_path = path;
			_canDelete = canDelete;
		}

		public FileSystemFolder(string path)
			: this(path, canDelete: false)
		{
		}

		public async Task<IFile> CreateFileAsync(string desiredName, CreationCollisionOption option, CancellationToken cancellationToken)
		{
			Requires.NotNullOrEmpty(desiredName, "desiredName");
			await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
			EnsureExists();
			string nameToUse = desiredName;
			string newPath = System.IO.Path.Combine(Path, nameToUse);
			if (File.Exists(newPath))
			{
				switch (option)
				{
				case CreationCollisionOption.GenerateUniqueName:
				{
					string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(desiredName);
					string extension = System.IO.Path.GetExtension(desiredName);
					int num = 2;
					while (File.Exists(newPath))
					{
						cancellationToken.ThrowIfCancellationRequested();
						newPath = System.IO.Path.Combine(path2: fileNameWithoutExtension + " (" + num + ")" + extension, path1: Path);
						num++;
					}
					InternalCreateFile(newPath);
					break;
				}
				case CreationCollisionOption.ReplaceExisting:
					File.Delete(newPath);
					InternalCreateFile(newPath);
					break;
				case CreationCollisionOption.FailIfExists:
					throw new IOException("File already exists: " + newPath);
				default:
					throw new ArgumentException("Unrecognized CreationCollisionOption: " + option);
				case CreationCollisionOption.OpenIfExists:
					break;
				}
			}
			else
			{
				InternalCreateFile(newPath);
			}
			return new FileSystemFile(newPath);
		}

		private void InternalCreateFile(string path)
		{
			using (File.Create(path))
			{
			}
		}

		public async Task<IFile> GetFileAsync(string name, CancellationToken cancellationToken)
		{
			await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
			string path = System.IO.Path.Combine(Path, name);
			if (!File.Exists(path))
			{
				throw new PCLStorage.Exceptions.FileNotFoundException("File does not exist: " + path);
			}
			return new FileSystemFile(path);
		}

		public async Task<IList<IFile>> GetFilesAsync(CancellationToken cancellationToken)
		{
			await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
			EnsureExists();
			return ((IEnumerable<IFile>)(from f in Directory.GetFiles(Path)
				select new FileSystemFile(f))).ToList().AsReadOnly();
		}

		public async Task<IFolder> CreateFolderAsync(string desiredName, CreationCollisionOption option, CancellationToken cancellationToken)
		{
			Requires.NotNullOrEmpty(desiredName, "desiredName");
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
						cancellationToken.ThrowIfCancellationRequested();
						newPath = System.IO.Path.Combine(path2: desiredName + " (" + num + ")", path1: Path);
						num++;
					}
					Directory.CreateDirectory(newPath);
					break;
				}
				case CreationCollisionOption.ReplaceExisting:
					Directory.Delete(newPath, recursive: true);
					Directory.CreateDirectory(newPath);
					break;
				case CreationCollisionOption.FailIfExists:
					throw new IOException("Directory already exists: " + newPath);
				default:
					throw new ArgumentException("Unrecognized CreationCollisionOption: " + option);
				case CreationCollisionOption.OpenIfExists:
					break;
				}
			}
			else
			{
				Directory.CreateDirectory(newPath);
			}
			return new FileSystemFolder(newPath, canDelete: true);
		}

		public async Task<IFolder> GetFolderAsync(string name, CancellationToken cancellationToken)
		{
			Requires.NotNullOrEmpty(name, "name");
			await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
			string path = System.IO.Path.Combine(Path, name);
			if (!Directory.Exists(path))
			{
				throw new PCLStorage.Exceptions.DirectoryNotFoundException("Directory does not exist: " + path);
			}
			return new FileSystemFolder(path, canDelete: true);
		}

		public async Task<IList<IFolder>> GetFoldersAsync(CancellationToken cancellationToken)
		{
			await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
			EnsureExists();
			return ((IEnumerable<IFolder>)(from d in Directory.GetDirectories(Path)
				select new FileSystemFolder(d, canDelete: true))).ToList().AsReadOnly();
		}

		public async Task<ExistenceCheckResult> CheckExistsAsync(string name, CancellationToken cancellationToken)
		{
			Requires.NotNullOrEmpty(name, "name");
			await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
			string checkPath = PortablePath.Combine(Path, name);
			if (File.Exists(checkPath))
			{
				return ExistenceCheckResult.FileExists;
			}
			if (Directory.Exists(checkPath))
			{
				return ExistenceCheckResult.FolderExists;
			}
			return ExistenceCheckResult.NotFound;
		}

		public async Task DeleteAsync(CancellationToken cancellationToken)
		{
			if (!_canDelete)
			{
				throw new IOException("Cannot delete root storage folder.");
			}
			await AwaitExtensions.SwitchOffMainThreadAsync(cancellationToken);
			EnsureExists();
			Directory.Delete(Path, recursive: true);
		}

		private void EnsureExists()
		{
			if (!Directory.Exists(Path))
			{
				throw new PCLStorage.Exceptions.DirectoryNotFoundException("Directory does not exist: " + Path);
			}
		}
	}
	internal static class AwaitExtensions
	{
		internal struct TaskSchedulerAwaiter(TaskScheduler taskScheduler, CancellationToken cancellationToken) : INotifyCompletion
		{
			private TaskScheduler taskScheduler = taskScheduler;

			private CancellationToken cancellationToken = cancellationToken;

			public bool IsCompleted => taskScheduler == null;

			internal TaskSchedulerAwaiter GetAwaiter()
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

		internal static TaskSchedulerAwaiter SwitchOffMainThreadAsync(CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			return new TaskSchedulerAwaiter((SynchronizationContext.Current != null) ? TaskScheduler.Default : null, cancellationToken);
		}
	}
}
namespace PCLStorage.Exceptions
{
	public class FileNotFoundException : System.IO.FileNotFoundException
	{
		public FileNotFoundException(string message)
			: base(message)
		{
		}

		public FileNotFoundException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
	public class DirectoryNotFoundException : System.IO.DirectoryNotFoundException
	{
		public DirectoryNotFoundException(string message)
			: base(message)
		{
		}

		public DirectoryNotFoundException(string message, Exception innerException)
			: base(message, innerException)
		{
		}
	}
}
namespace PCLStorage
{
	public static class FileSystem
	{
		private static Lazy<IFileSystem> _fileSystem = new Lazy<IFileSystem>(() => CreateFileSystem(), LazyThreadSafetyMode.PublicationOnly);

		public static IFileSystem Current
		{
			get
			{
				IFileSystem value = _fileSystem.Value;
				if (value == null)
				{
					throw NotImplementedInReferenceAssembly();
				}
				return value;
			}
		}

		private static IFileSystem CreateFileSystem()
		{
			return new DesktopFileSystem();
		}

		internal static Exception NotImplementedInReferenceAssembly()
		{
			return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the PCLStorage NuGet package from your main application project in order to reference the platform-specific implementation.");
		}
	}
	public static class PortablePath
	{
		public static char DirectorySeparatorChar => Path.DirectorySeparatorChar;

		public static string Combine(params string[] paths)
		{
			return Path.Combine(paths);
		}
	}
	internal static class Requires
	{
		private const string Argument_EmptyString = "'{0}' cannot be an empty string (\"\") or start with the null character.";

		[DebuggerStepThrough]
		public static T NotNull<T>(T value, string parameterName) where T : class
		{
			if (value == null)
			{
				throw new ArgumentNullException(parameterName);
			}
			return value;
		}

		[DebuggerStepThrough]
		public static void NotNullOrEmpty(string value, string parameterName)
		{
			if (value == null)
			{
				throw new ArgumentNullException(parameterName);
			}
			if (value.Length == 0 || value[0] == '\0')
			{
				throw new ArgumentException(Format("'{0}' cannot be an empty string (\"\") or start with the null character.", parameterName), parameterName);
			}
		}

		private static string Format(string format, params object[] arguments)
		{
			return string.Format(CultureInfo.CurrentCulture, format, arguments);
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

		public class String
		{
			public static int ApplicationName;

			public static int Hello;

			static String()
			{
				ApplicationName = 2130837505;
				Hello = 2130837504;
				ResourceIdManager.UpdateIdValues();
			}

			private String()
			{
			}
		}

		static Resource()
		{
			ResourceIdManager.UpdateIdValues();
		}
	}
}
