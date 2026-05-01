using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.Versioning;
using MvvmCross.Platform.Core;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("MvvmCross.FieldBinding")]
[assembly: AssemblyDescription("")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Cirrious")]
[assembly: AssemblyProduct("MvvmCross.FieldBinding")]
[assembly: AssemblyCopyright("Copyright © 2016")]
[assembly: AssemblyTrademark("")]
[assembly: NeutralResourcesLanguage("en")]
[assembly: AssemblyFileVersion("4.0.0.0")]
[assembly: TargetFramework(".NETPortable,Version=v4.5,Profile=Profile7", FrameworkDisplayName = ".NET Portable Subset")]
[assembly: AssemblyVersion("4.0.0.0")]
namespace MvvmCross.FieldBinding;

public interface INC<T> : INotifyChange<T>, INotifyChange
{
}
public interface INCString : INC<string>, INotifyChange<string>, INotifyChange
{
}
public interface INCList<TValue> : INotifyChangeList<TValue>, INotifyChange<IList<TValue>>, INotifyChange
{
}
public interface INCDictionary<TKey, TValue> : INotifyChangeDictionary<TKey, TValue>, INotifyChange<IDictionary<TKey, TValue>>, INotifyChange
{
}
public interface INotifyChange
{
	object Value { get; set; }

	Type ValueType { get; }

	event EventHandler Changed;
}
public interface INotifyChange<T> : INotifyChange
{
	new T Value { get; set; }
}
public interface INotifyChangeList<TValue> : INotifyChange<IList<TValue>>, INotifyChange
{
	TValue this[int key] { get; set; }
}
public interface INotifyChangeDictionary<TKey, TValue> : INotifyChange<IDictionary<TKey, TValue>>, INotifyChange
{
	TValue this[TKey key] { get; set; }
}
public class NC<T> : NotifyChange<T>, INC<T>, INotifyChange<T>, INotifyChange
{
	public NC()
	{
	}

	public NC(T value)
		: base(value)
	{
	}

	public NC(T value, Action<T> valueChanged)
		: base(value, valueChanged)
	{
	}
}
public class NCString : NC<string>, INCString, INC<string>, INotifyChange<string>, INotifyChange
{
	public int MaxLength { get; private set; }

	public NCString()
	{
	}

	public NCString(string value)
		: base(value)
	{
	}

	public NCString(string value, Action<string> valueChanged)
		: base(value, valueChanged)
	{
	}

	public NCString(int maxLength)
		: this()
	{
		MaxLength = maxLength;
		base.Changed += NCString_Changed;
	}

	public NCString(string value, int maxLength)
		: this(value)
	{
		MaxLength = maxLength;
		base.Changed += NCString_Changed;
	}

	public NCString(string value, Action<string> valueChanged, int maxLength)
		: this(value, valueChanged)
	{
		MaxLength = maxLength;
		base.Changed += NCString_Changed;
	}

	private void NCString_Changed(object sender, EventArgs e)
	{
		if (MaxLength > 0 && base.Value != null && base.Value.Length > MaxLength)
		{
			base.Value = base.Value.Remove(MaxLength);
		}
	}
}
public class NCList<TValue> : NotifyChangeList<TValue>, INCList<TValue>, INotifyChangeList<TValue>, INotifyChange<IList<TValue>>, INotifyChange
{
	public NCList()
	{
	}

	public NCList(IList<TValue> value)
		: base(value)
	{
	}

	public NCList(IList<TValue> value, Action<IList<TValue>> valueChanged)
		: base(value, valueChanged)
	{
	}
}
public class NCDictionary<TKey, TValue> : NotifyChangeDictionary<TKey, TValue>, INCDictionary<TKey, TValue>, INotifyChangeDictionary<TKey, TValue>, INotifyChange<IDictionary<TKey, TValue>>, INotifyChange
{
	public NCDictionary()
	{
	}

	public NCDictionary(IDictionary<TKey, TValue> value)
		: base(value)
	{
	}

	public NCDictionary(IDictionary<TKey, TValue> value, Action<IDictionary<TKey, TValue>> valueChanged)
		: base(value, valueChanged)
	{
	}
}
public class NotifyChange : MvxMainThreadDispatchingObject, INotifyChange
{
	private bool _shouldAlwaysRaiseChangedOnUserInterfaceThread;

	private object _value;

	public object Value
	{
		get
		{
			return _value;
		}
		set
		{
			_value = value;
			RaiseChanged();
		}
	}

	public Type ValueType { get; protected set; }

	public event EventHandler Changed;

	public NotifyChange()
	{
		_shouldAlwaysRaiseChangedOnUserInterfaceThread = true;
	}

	protected NotifyChange(object value)
		: this()
	{
		_value = value;
	}

	protected NotifyChange(object value, Action<object> valueChanged)
		: this(value)
	{
		NotifyChange notifyChange = this;
		Changed += delegate
		{
			valueChanged?.Invoke(notifyChange.Value);
		};
	}

	public bool ShouldAlwaysRaiseChangedOnUserInterfaceThread()
	{
		return _shouldAlwaysRaiseChangedOnUserInterfaceThread;
	}

	public void ShouldAlwaysRaiseChangedOnUserInterfaceThread(bool value)
	{
		_shouldAlwaysRaiseChangedOnUserInterfaceThread = value;
	}

	public void RaiseChanged()
	{
		Action action = delegate
		{
			this.Changed?.Invoke(this, EventArgs.Empty);
		};
		if (ShouldAlwaysRaiseChangedOnUserInterfaceThread())
		{
			if (this.Changed != null)
			{
				InvokeOnMainThread(action);
			}
		}
		else
		{
			action();
		}
	}
}
public class NotifyChange<T> : NotifyChange, INotifyChange<T>, INotifyChange
{
	public new T Value
	{
		get
		{
			return (T)base.Value;
		}
		set
		{
			base.Value = value;
		}
	}

	public NotifyChange()
		: this(default(T))
	{
	}

	public NotifyChange(T value)
		: base(value)
	{
		base.ValueType = typeof(T);
	}

	public NotifyChange(T value, Action<T> valueChanged)
		: base(value, delegate(object obj)
		{
			valueChanged?.Invoke((T)obj);
		})
	{
		base.ValueType = typeof(T);
	}
}
public class NotifyChangeList<TValue> : NotifyChange<IList<TValue>>, INotifyChangeList<TValue>, INotifyChange<IList<TValue>>, INotifyChange
{
	public TValue this[int key]
	{
		get
		{
			return base.Value[key];
		}
		set
		{
			base.Value[key] = value;
		}
	}

	public NotifyChangeList()
	{
	}

	public NotifyChangeList(IList<TValue> value)
		: base(value)
	{
	}

	public NotifyChangeList(IList<TValue> value, Action<IList<TValue>> valueChanged)
		: base(value, valueChanged)
	{
	}
}
public class NotifyChangeDictionary<TKey, TValue> : NotifyChange<IDictionary<TKey, TValue>>, INotifyChangeDictionary<TKey, TValue>, INotifyChange<IDictionary<TKey, TValue>>, INotifyChange
{
	public TValue this[TKey key]
	{
		get
		{
			return base.Value[key];
		}
		set
		{
			base.Value[key] = value;
		}
	}

	public NotifyChangeDictionary()
	{
	}

	public NotifyChangeDictionary(IDictionary<TKey, TValue> value)
		: base(value)
	{
	}

	public NotifyChangeDictionary(IDictionary<TKey, TValue> value, Action<IDictionary<TKey, TValue>> valueChanged)
		: base(value, valueChanged)
	{
	}
}
