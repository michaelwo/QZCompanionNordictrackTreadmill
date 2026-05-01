using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("System.Transactions.dll")]
[assembly: AssemblyDescription("System.Transactions.dll")]
[assembly: AssemblyDefaultAlias("System.Transactions.dll")]
[assembly: AssemblyCompany("Mono development team")]
[assembly: AssemblyProduct("Mono Common Language Infrastructure")]
[assembly: AssemblyCopyright("(c) Various Mono authors")]
[assembly: SatelliteContractVersion("2.0.5.0")]
[assembly: AssemblyInformationalVersion("4.0.50524.0")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: ComVisible(false)]
[assembly: AllowPartiallyTrustedCallers]
[assembly: CLSCompliant(true)]
[assembly: AssemblyDelaySign(true)]
[assembly: AssemblyFileVersion("4.0.50524.0")]
[assembly: BestFitMapping(false)]
[assembly: AssemblyVersion("2.0.5.0")]
namespace System.Transactions;

public class Enlistment
{
	internal bool done;

	internal Enlistment()
	{
		done = false;
	}
}
[Flags]
public enum EnlistmentOptions
{
	None = 0,
	EnlistDuringPrepareRequired = 1
}
public interface IEnlistmentNotification
{
}
public enum IsolationLevel
{
	Serializable,
	RepeatableRead,
	ReadCommitted,
	ReadUncommitted,
	Snapshot,
	Chaos,
	Unspecified
}
[Serializable]
public class Transaction
{
	[ThreadStatic]
	private static Transaction ambient;

	private IsolationLevel level;

	private TransactionInformation info;

	private List<IEnlistmentNotification> volatiles;

	private TransactionScope scope;

	internal List<IEnlistmentNotification> Volatiles
	{
		get
		{
			if (volatiles == null)
			{
				volatiles = new List<IEnlistmentNotification>();
			}
			return volatiles;
		}
	}

	public static Transaction Current
	{
		get
		{
			EnsureIncompleteCurrentScope();
			return CurrentInternal;
		}
	}

	internal static Transaction CurrentInternal => ambient;

	internal TransactionScope Scope => scope;

	public Enlistment EnlistVolatile(IEnlistmentNotification enlistmentNotification, EnlistmentOptions enlistmentOptions)
	{
		return EnlistVolatileInternal(enlistmentNotification, enlistmentOptions);
	}

	private Enlistment EnlistVolatileInternal(IEnlistmentNotification notification, EnlistmentOptions options)
	{
		EnsureIncompleteCurrentScope();
		Volatiles.Add(notification);
		return new Enlistment();
	}

	private bool Equals(Transaction t)
	{
		if ((object)t == this)
		{
			return true;
		}
		if ((object)t == null)
		{
			return false;
		}
		if (level == t.level)
		{
			return info == t.info;
		}
		return false;
	}

	public static bool operator ==(Transaction x, Transaction y)
	{
		return x?.Equals(y) ?? ((object)y == null);
	}

	public static bool operator !=(Transaction x, Transaction y)
	{
		return !(x == y);
	}

	private static void EnsureIncompleteCurrentScope()
	{
		if (CurrentInternal == null || CurrentInternal.Scope == null || !CurrentInternal.Scope.IsComplete)
		{
			return;
		}
		throw new InvalidOperationException("The current TransactionScope is already complete");
	}
}
public class TransactionInformation
{
}
public static class TransactionManager
{
	private static TimeSpan defaultTimeout;

	private static TimeSpan maxTimeout;

	public static TimeSpan DefaultTimeout => defaultTimeout;

	static TransactionManager()
	{
		defaultTimeout = new TimeSpan(0, 1, 0);
		maxTimeout = new TimeSpan(0, 10, 0);
	}
}
public struct TransactionOptions(IsolationLevel level, TimeSpan timeout)
{
	private IsolationLevel level = level;

	private TimeSpan timeout = timeout;

	public static bool operator ==(TransactionOptions x, TransactionOptions y)
	{
		if (x.level == y.level)
		{
			return x.timeout == y.timeout;
		}
		return false;
	}

	public override bool Equals(object obj)
	{
		if (!(obj is TransactionOptions))
		{
			return false;
		}
		return this == (TransactionOptions)obj;
	}

	public override int GetHashCode()
	{
		return (int)level ^ timeout.GetHashCode();
	}
}
public sealed class TransactionScope
{
	private static TransactionOptions defaultOptions = new TransactionOptions(IsolationLevel.Serializable, TransactionManager.DefaultTimeout);

	private bool completed;

	internal bool IsComplete => completed;
}
