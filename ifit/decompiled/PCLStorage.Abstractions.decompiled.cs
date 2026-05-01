using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading;
using System.Threading.Tasks;

[assembly: AssemblyTitle("PCLStorage.Abstractions")]
[assembly: AssemblyConfiguration("")]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: TargetFramework(".NETPortable,Version=v4.5,Profile=Profile78", FrameworkDisplayName = ".NET Portable Subset")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("PCLStorage")]
[assembly: AssemblyCopyright("Copyright ©  2013")]
[assembly: AssemblyTrademark("")]
[assembly: NeutralResourcesLanguage("en")]
[assembly: AssemblyFileVersion("1.0.2.0")]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: CompilationRelaxations(8)]
[assembly: AssemblyVersion("1.0.2.0")]
namespace PCLStorage;

public enum ExistenceCheckResult
{
	NotFound,
	FileExists,
	FolderExists
}
public static class FileExtensions
{
	public static async Task<string> ReadAllTextAsync(this IFile file)
	{
		using Stream stream = await file.OpenAsync(FileAccess.Read).ConfigureAwait(continueOnCapturedContext: false);
		using StreamReader sr = new StreamReader(stream);
		return await sr.ReadToEndAsync().ConfigureAwait(continueOnCapturedContext: false);
	}

	public static async Task WriteAllTextAsync(this IFile file, string contents)
	{
		using Stream stream = await file.OpenAsync(FileAccess.ReadAndWrite).ConfigureAwait(continueOnCapturedContext: false);
		stream.SetLength(0L);
		using StreamWriter sw = new StreamWriter(stream);
		await sw.WriteAsync(contents).ConfigureAwait(continueOnCapturedContext: false);
	}
}
public enum FileAccess
{
	Read,
	ReadAndWrite
}
public interface IFile
{
	string Name { get; }

	string Path { get; }

	Task<Stream> OpenAsync(FileAccess fileAccess, CancellationToken cancellationToken = default(CancellationToken));

	Task DeleteAsync(CancellationToken cancellationToken = default(CancellationToken));

	Task RenameAsync(string newName, NameCollisionOption collisionOption = NameCollisionOption.FailIfExists, CancellationToken cancellationToken = default(CancellationToken));

	Task MoveAsync(string newPath, NameCollisionOption collisionOption = NameCollisionOption.ReplaceExisting, CancellationToken cancellationToken = default(CancellationToken));
}
public interface IFileSystem
{
	IFolder LocalStorage { get; }

	IFolder RoamingStorage { get; }

	Task<IFile> GetFileFromPathAsync(string path, CancellationToken cancellationToken = default(CancellationToken));

	Task<IFolder> GetFolderFromPathAsync(string path, CancellationToken cancellationToken = default(CancellationToken));
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
public enum NameCollisionOption
{
	GenerateUniqueName,
	ReplaceExisting,
	FailIfExists
}
