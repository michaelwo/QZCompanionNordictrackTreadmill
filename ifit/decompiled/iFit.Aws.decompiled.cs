using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Amazon.S3.Model;
using Android.App;
using Android.Content;
using Android.OS;
using iFit.Aws.Core;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework("MonoAndroid,Version=v12.0", FrameworkDisplayName = "Xamarin.Android v12.0 Support")]
[assembly: AssemblyVersion("0.0.0.0")]
namespace iFit.Aws.Android;

[Service(Label = "AwsS3IntentService", Exported = true)]
[IntentFilter(new string[] { "com.ifit.core.AwsS3IntentService" })]
public class AwsS3IntentService : IntentService
{
	private IBinder binder;

	public AwsS3IntentService()
		: base("AwsS3IntentService")
	{
	}

	protected override async void OnHandleIntent(Intent intent)
	{
		Bundle bundleExtra = intent.GetBundleExtra("s3Bundle");
		string text = bundleExtra.GetString("saved_file_path");
		string bucketName = bundleExtra.GetString("bucket_name");
		string saveToFileName = bundleExtra.GetString("file_name");
		string basePath = bundleExtra.GetString("base_path");
		string contentType = bundleExtra.GetString("content_type");
		string[] stringArray = bundleExtra.GetStringArray("s3key");
		string[] stringArray2 = bundleExtra.GetStringArray("s3secret");
		if (stringArray != null && stringArray2 != null)
		{
			S3.Initialize(stringArray, stringArray2);
			byte[] array = null;
			if (!string.IsNullOrEmpty(text))
			{
				array = File.ReadAllBytes(text);
			}
			if (array != null)
			{
				MemoryStream stream = new MemoryStream(array);
				await UploadToS3(bucketName, basePath, saveToFileName, contentType, stream);
			}
		}
	}

	public async Task UploadToS3(string bucketName, string basePath, string saveToFileName, string contentType, Stream stream)
	{
		if (stream != null)
		{
			PutObjectRequest request = new PutObjectRequest
			{
				BucketName = bucketName,
				Key = basePath + saveToFileName,
				InputStream = stream,
				ContentType = contentType
			};
			_ = (await S3.Client.PutObjectAsync(request)).HttpStatusCode;
			_ = 200;
		}
	}

	public override IBinder OnBind(Intent intent)
	{
		binder = new AwsS3IntentServiceBinder(this);
		return binder;
	}
}
public class AwsS3IntentServiceBinder : global::Android.OS.Binder
{
	private readonly AwsS3IntentService service;

	public AwsS3IntentServiceBinder(AwsS3IntentService service)
	{
		this.service = service;
	}

	public AwsS3IntentService GetAwsS3IntentService()
	{
		return service;
	}
}
