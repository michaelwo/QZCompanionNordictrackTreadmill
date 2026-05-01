using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Security;
using System.Security.Permissions;
using Android.Runtime;
using GoogleGson;
using Java.Interop;
using Java.Lang;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: NamespaceMapping(Java = "retrofit2.converter.gson", Managed = "Square.Retrofit2.Converter.Gson")]
[assembly: TargetFramework("MonoAndroid,Version=v9.0", FrameworkDisplayName = "Xamarin.Android v9.0 Support")]
[assembly: AssemblyCompany("Microsoft")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Retrofit v2 Adapter for Gson bindings for Xamarin.Android.")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Square.Retrofit2.ConverterGson")]
[assembly: AssemblyTitle("Square.Retrofit2.ConverterGson")]
[assembly: AssemblyMetadata("RepositoryUrl", "https://github.com/xamarin/XamarinComponents")]
[assembly: SecurityPermission(SecurityAction.RequestMinimum, SkipVerification = true)]
[assembly: AssemblyVersion("1.0.0.0")]
[module: UnverifiableCode]
namespace Square.Retrofit2.Converter.Gson
{
	[Register("retrofit2/converter/gson/GsonConverterFactory", DoNotGenerateAcw = true)]
	public sealed class GsonConverterFactory : ConverterFactory
	{
		private static readonly JniPeerMembers _members = new XAPeerMembers("retrofit2/converter/gson/GsonConverterFactory", typeof(GsonConverterFactory));

		internal static IntPtr class_ref => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		public override JniPeerMembers JniPeerMembers => _members;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override IntPtr ThresholdClass => _members.JniPeerType.PeerReference.Handle;

		[DebuggerBrowsable(DebuggerBrowsableState.Never)]
		[EditorBrowsable(EditorBrowsableState.Never)]
		protected override Type ThresholdType => _members.ManagedPeerType;

		internal GsonConverterFactory(IntPtr javaReference, JniHandleOwnership transfer)
			: base(javaReference, transfer)
		{
		}

		[Register("create", "()Lretrofit2/converter/gson/GsonConverterFactory;", "")]
		public unsafe static GsonConverterFactory Create()
		{
			return Java.Lang.Object.GetObject<GsonConverterFactory>(_members.StaticMethods.InvokeObjectMethod("create.()Lretrofit2/converter/gson/GsonConverterFactory;", null).Handle, JniHandleOwnership.TransferLocalRef);
		}

		[Register("create", "(Lcom/google/gson/Gson;)Lretrofit2/converter/gson/GsonConverterFactory;", "")]
		public unsafe static GsonConverterFactory Create(GoogleGson.Gson gson)
		{
			try
			{
				JniArgumentValue* ptr = stackalloc JniArgumentValue[1];
				*ptr = new JniArgumentValue(gson?.Handle ?? IntPtr.Zero);
				return Java.Lang.Object.GetObject<GsonConverterFactory>(_members.StaticMethods.InvokeObjectMethod("create.(Lcom/google/gson/Gson;)Lretrofit2/converter/gson/GsonConverterFactory;", ptr).Handle, JniHandleOwnership.TransferLocalRef);
			}
			finally
			{
				GC.KeepAlive(gson);
			}
		}
	}
}
namespace Java.Interop
{
	internal class __TypeRegistrations
	{
		private static string[] package_retrofit2_converter_gson_mappings;

		public static void RegisterPackages()
		{
			TypeManager.RegisterPackages(new string[1] { "retrofit2/converter/gson" }, new Converter<string, Type>[1] { lookup_retrofit2_converter_gson_package });
		}

		private static Type Lookup(string[] mappings, string javaType)
		{
			string text = TypeManager.LookupTypeMapping(mappings, javaType);
			if (text == null)
			{
				return null;
			}
			return Type.GetType(text);
		}

		private static Type lookup_retrofit2_converter_gson_package(string klass)
		{
			if (package_retrofit2_converter_gson_mappings == null)
			{
				package_retrofit2_converter_gson_mappings = new string[1] { "retrofit2/converter/gson/GsonConverterFactory:Square.Retrofit2.Converter.Gson.GsonConverterFactory" };
			}
			return Lookup(package_retrofit2_converter_gson_mappings, klass);
		}
	}
}
