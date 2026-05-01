using System;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using System.Threading.Tasks;
using Sindarin.Core;
using Sindarin.Core.Ble.Connection;
using Sindarin.Core.Communication.Logging;
using Sindarin.Core.Connection;
using Sindarin.Core.Console;
using Sindarin.Core.Services.Fatality;
using Sindarin.Core.Tcp;
using Sindarin.Core.Util;
using Sindarin.FitPro1.Communication;
using iFit.Collections;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: TargetFramework(".NETStandard,Version=v2.1", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("Sindarin.FitPro1.Tcp")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyFileVersion("1.0.0.0")]
[assembly: AssemblyInformationalVersion("1.0.0")]
[assembly: AssemblyProduct("Sindarin.FitPro1.Tcp")]
[assembly: AssemblyTitle("Sindarin.FitPro1.Tcp")]
[assembly: AssemblyVersion("1.0.0.0")]
namespace Sindarin.FitPro1.Tcp;

public class FitProTcpConsoleCommunicationAdapter : FitProCommunicationAdapter
{
	protected override int maxItemLostBeforeFatality => 2147483647;

	protected override TimeSpan rateOfItemLostDecay => TimeSpan.FromSeconds(2.0);

	public override ConnectionType ConnectionType => ConnectionType.TCP;

	public override TimeSpan DefaultTimeout => base.Connection.Timeout;

	public FitProTcpConsoleCommunicationAdapter(FitProTcpConnection connection, IFatalityService fatalityService)
		: base(connection, fatalityService)
	{
	}

	protected override IDisposable CreateDataChangedSubscriber()
	{
		return base.Connection.WhenValueUpdated.Timeout(base.CurrentQueueItem.Timeout).SubscribeAsync(DataReceived, base.DataResponseError);
	}

	protected override async Task DataReceived(byte[] bytes)
	{
		await base.DataReceived(bytes);
		if (CheckResponseComplete(base.CurrentQueueItemGroup))
		{
			await CommGroupResponseComplete();
		}
	}

	protected bool CheckResponseComplete(FitProCommunicationGroup commGroup)
	{
		if (commGroup?.ResponsePackets == null || commGroup.ResponsePackets.Count == 0)
		{
			return false;
		}
		byte[] array = commGroup.ResponsePackets.FirstOrDefault();
		byte[] array2 = commGroup.ResponsePackets.LastOrDefault();
		if (array.CountSafe() == 0 || array2.CountSafe() == 0)
		{
			return false;
		}
		bool num = array[0] == 254;
		bool flag = array2[0] == 255;
		return num && flag;
	}
}
public static class TcpFitnessConsoleFactory
{
	public static IFitnessConsole TcpFactory(IBleDevice device, ISindarinEventHandler fitProEventHandler, IFatalityService fatalityService, IFitProBytesLogger fitProBytesLogger)
	{
		return new FitPro1Console(new FitProTcpConsoleCommunicationAdapter(new FitProTcpConnection(device), fatalityService), fitProEventHandler, fatalityService, fitProBytesLogger);
	}
}
