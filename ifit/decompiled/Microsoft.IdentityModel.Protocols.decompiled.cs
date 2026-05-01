using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

[assembly: CompilationRelaxations(8)]
[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyInformationalVersion("5.6.0.61018232319.2574f3cbc3736db085497b9b241ea5ae338357b9")]
[assembly: AssemblyFileVersion("5.6.0.61018")]
[assembly: AssemblyMetadata("Serviceable", "True")]
[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]
[assembly: TargetFramework(".NETStandard,Version=v2.0", FrameworkDisplayName = "")]
[assembly: AssemblyCompany("Microsoft Corporation.")]
[assembly: AssemblyConfiguration("Release")]
[assembly: AssemblyCopyright("© Microsoft Corporation. All rights reserved.")]
[assembly: AssemblyDescription("Provides base protocol support for OpenIdConnect and WsFederation.")]
[assembly: AssemblyProduct("Microsoft IdentityModel")]
[assembly: AssemblyTitle("Microsoft.IdentityModel.Protocols")]
[assembly: AssemblyVersion("5.6.0.0")]
namespace Microsoft.IdentityModel.Protocols;

public abstract class AuthenticationProtocolMessage
{
	private string _postTitle = "Working...";

	private string _script = "<script language=\"javascript\">window.setTimeout('document.forms[0].submit()', 0);</script>";

	private string _scriptButtonText = "Submit";

	private string _scriptDisabledText = "Script is disabled. Click Submit to continue.";

	private Dictionary<string, string> _parameters = new Dictionary<string, string>();

	private string _issuerAddress = string.Empty;

	public string IssuerAddress
	{
		get
		{
			return _issuerAddress;
		}
		set
		{
			if (value == null)
			{
				throw LogHelper.LogArgumentNullException("IssuerAddress");
			}
			_issuerAddress = value;
		}
	}

	public IDictionary<string, string> Parameters => _parameters;

	public string PostTitle
	{
		get
		{
			return _postTitle;
		}
		set
		{
			if (value == null)
			{
				throw LogHelper.LogArgumentNullException("PostTitle");
			}
			_postTitle = value;
		}
	}

	public string Script
	{
		get
		{
			return _script;
		}
		set
		{
			if (value == null)
			{
				throw LogHelper.LogArgumentNullException("Script");
			}
			_script = value;
		}
	}

	public string ScriptButtonText
	{
		get
		{
			return _scriptButtonText;
		}
		set
		{
			if (value == null)
			{
				throw LogHelper.LogArgumentNullException("ScriptButtonText");
			}
			_scriptButtonText = value;
		}
	}

	public string ScriptDisabledText
	{
		get
		{
			return _scriptDisabledText;
		}
		set
		{
			if (value == null)
			{
				throw LogHelper.LogArgumentNullException("ScriptDisabledText");
			}
			_scriptDisabledText = value;
		}
	}

	public virtual string BuildFormPost()
	{
		StringBuilder stringBuilder = new StringBuilder();
		stringBuilder.Append("<html><head><title>");
		stringBuilder.Append(WebUtility.HtmlEncode(PostTitle));
		stringBuilder.Append("</title></head><body><form method=\"POST\" name=\"hiddenform\" action=\"");
		stringBuilder.Append(WebUtility.HtmlEncode(IssuerAddress));
		stringBuilder.Append("\">");
		foreach (KeyValuePair<string, string> parameter in _parameters)
		{
			stringBuilder.Append("<input type=\"hidden\" name=\"");
			stringBuilder.Append(WebUtility.HtmlEncode(parameter.Key));
			stringBuilder.Append("\" value=\"");
			stringBuilder.Append(WebUtility.HtmlEncode(parameter.Value));
			stringBuilder.Append("\" />");
		}
		stringBuilder.Append("<noscript><p>");
		stringBuilder.Append(WebUtility.HtmlEncode(ScriptDisabledText));
		stringBuilder.Append("</p><input type=\"submit\" value=\"");
		stringBuilder.Append(WebUtility.HtmlEncode(ScriptButtonText));
		stringBuilder.Append("\" /></noscript>");
		stringBuilder.Append("</form>");
		stringBuilder.Append(Script);
		stringBuilder.Append("</body></html>");
		return stringBuilder.ToString();
	}

	public virtual string BuildRedirectUrl()
	{
		StringBuilder stringBuilder = new StringBuilder(_issuerAddress);
		bool flag = _issuerAddress.Contains("?");
		foreach (KeyValuePair<string, string> parameter in _parameters)
		{
			if (parameter.Value != null)
			{
				if (!flag)
				{
					stringBuilder.Append('?');
					flag = true;
				}
				else
				{
					stringBuilder.Append('&');
				}
				stringBuilder.Append(Uri.EscapeDataString(parameter.Key));
				stringBuilder.Append('=');
				stringBuilder.Append(Uri.EscapeDataString(parameter.Value));
			}
		}
		return stringBuilder.ToString();
	}

	public virtual string GetParameter(string parameter)
	{
		if (string.IsNullOrEmpty(parameter))
		{
			throw LogHelper.LogArgumentNullException("parameter");
		}
		string value = null;
		_parameters.TryGetValue(parameter, out value);
		return value;
	}

	public virtual void RemoveParameter(string parameter)
	{
		if (string.IsNullOrEmpty(parameter))
		{
			throw LogHelper.LogArgumentNullException("parameter");
		}
		if (_parameters.ContainsKey(parameter))
		{
			_parameters.Remove(parameter);
		}
	}

	public void SetParameter(string parameter, string value)
	{
		if (string.IsNullOrEmpty(parameter))
		{
			throw LogHelper.LogArgumentNullException("parameter");
		}
		if (value == null)
		{
			RemoveParameter(parameter);
		}
		else
		{
			_parameters[parameter] = value;
		}
	}

	public virtual void SetParameters(NameValueCollection nameValueCollection)
	{
		if (nameValueCollection != null)
		{
			string[] allKeys = nameValueCollection.AllKeys;
			foreach (string text in allKeys)
			{
				SetParameter(text, nameValueCollection[text]);
			}
		}
	}
}
public class ConfigurationManager<T> : IConfigurationManager<T> where T : class
{
	public static readonly TimeSpan DefaultAutomaticRefreshInterval;

	public static readonly TimeSpan DefaultRefreshInterval;

	public static readonly TimeSpan MinimumAutomaticRefreshInterval;

	public static readonly TimeSpan MinimumRefreshInterval;

	private TimeSpan _automaticRefreshInterval = DefaultAutomaticRefreshInterval;

	private TimeSpan _refreshInterval = DefaultRefreshInterval;

	private DateTimeOffset _syncAfter = DateTimeOffset.MinValue;

	private DateTimeOffset _lastRefresh = DateTimeOffset.MinValue;

	private readonly SemaphoreSlim _refreshLock;

	private readonly string _metadataAddress;

	private readonly IDocumentRetriever _docRetriever;

	private readonly IConfigurationRetriever<T> _configRetriever;

	private T _currentConfiguration;

	public TimeSpan AutomaticRefreshInterval
	{
		get
		{
			return _automaticRefreshInterval;
		}
		set
		{
			if (value < MinimumAutomaticRefreshInterval)
			{
				throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException("value", LogHelper.FormatInvariant("IDX20107: When setting AutomaticRefreshInterval, the value must be greater than MinimumAutomaticRefreshInterval: '{0}'. value: '{1}'.", MinimumAutomaticRefreshInterval, value)));
			}
			_automaticRefreshInterval = value;
		}
	}

	public TimeSpan RefreshInterval
	{
		get
		{
			return _refreshInterval;
		}
		set
		{
			if (value < MinimumRefreshInterval)
			{
				throw LogHelper.LogExceptionMessage(new ArgumentOutOfRangeException("value", LogHelper.FormatInvariant("IDX20106: When setting RefreshInterval, the value must be greater than MinimumRefreshInterval: '{0}'. value: '{1}'.", MinimumRefreshInterval, value)));
			}
			_refreshInterval = value;
		}
	}

	static ConfigurationManager()
	{
		DefaultAutomaticRefreshInterval = new TimeSpan(1, 0, 0, 0);
		DefaultRefreshInterval = new TimeSpan(0, 0, 0, 30);
		MinimumAutomaticRefreshInterval = new TimeSpan(0, 0, 5, 0);
		MinimumRefreshInterval = new TimeSpan(0, 0, 0, 1);
		LogHelper.LogVerbose("Assembly version info: " + typeof(ConfigurationManager<T>).AssemblyQualifiedName);
	}

	public ConfigurationManager(string metadataAddress, IConfigurationRetriever<T> configRetriever)
		: this(metadataAddress, configRetriever, (IDocumentRetriever)new HttpDocumentRetriever())
	{
	}

	public ConfigurationManager(string metadataAddress, IConfigurationRetriever<T> configRetriever, HttpClient httpClient)
		: this(metadataAddress, configRetriever, (IDocumentRetriever)new HttpDocumentRetriever(httpClient))
	{
	}

	public ConfigurationManager(string metadataAddress, IConfigurationRetriever<T> configRetriever, IDocumentRetriever docRetriever)
	{
		if (string.IsNullOrWhiteSpace(metadataAddress))
		{
			throw LogHelper.LogArgumentNullException("metadataAddress");
		}
		if (configRetriever == null)
		{
			throw LogHelper.LogArgumentNullException("configRetriever");
		}
		if (docRetriever == null)
		{
			throw LogHelper.LogArgumentNullException("docRetriever");
		}
		_metadataAddress = metadataAddress;
		_docRetriever = docRetriever;
		_configRetriever = configRetriever;
		_refreshLock = new SemaphoreSlim(1);
	}

	public async Task<T> GetConfigurationAsync()
	{
		return await GetConfigurationAsync(CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
	}

	public async Task<T> GetConfigurationAsync(CancellationToken cancel)
	{
		DateTimeOffset now = DateTimeOffset.UtcNow;
		if (_currentConfiguration != null && _syncAfter > now)
		{
			return _currentConfiguration;
		}
		await _refreshLock.WaitAsync(cancel);
		try
		{
			if (_syncAfter <= now)
			{
				try
				{
					_currentConfiguration = await _configRetriever.GetConfigurationAsync(_metadataAddress, _docRetriever, CancellationToken.None).ConfigureAwait(continueOnCapturedContext: false);
					_lastRefresh = now;
					_syncAfter = DateTimeUtil.Add(now.UtcDateTime, _automaticRefreshInterval);
				}
				catch (Exception innerException)
				{
					_syncAfter = DateTimeUtil.Add(now.UtcDateTime, (_automaticRefreshInterval < _refreshInterval) ? _automaticRefreshInterval : _refreshInterval);
					if (_currentConfiguration == null)
					{
						throw LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX20803: Unable to obtain configuration from: '{0}'.", _metadataAddress ?? "null"), innerException));
					}
					LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX20806: Unable to obtain an updated configuration from: '{0}'. Returning the current configuration.", _metadataAddress ?? "null"), innerException));
				}
			}
			if (_currentConfiguration != null)
			{
				return _currentConfiguration;
			}
			throw LogHelper.LogExceptionMessage(new InvalidOperationException(LogHelper.FormatInvariant("IDX20803: Unable to obtain configuration from: '{0}'.", _metadataAddress ?? "null")));
		}
		finally
		{
			_refreshLock.Release();
		}
	}

	public void RequestRefresh()
	{
		DateTimeOffset utcNow = DateTimeOffset.UtcNow;
		if (utcNow >= DateTimeUtil.Add(_lastRefresh.UtcDateTime, RefreshInterval))
		{
			_syncAfter = utcNow;
		}
	}
}
public class FileDocumentRetriever : IDocumentRetriever
{
	public async Task<string> GetDocumentAsync(string address, CancellationToken cancel)
	{
		if (string.IsNullOrWhiteSpace(address))
		{
			throw LogHelper.LogArgumentNullException("address");
		}
		try
		{
			using StreamReader reader = File.OpenText(address);
			return await reader.ReadToEndAsync().ConfigureAwait(continueOnCapturedContext: false);
		}
		catch (Exception innerException)
		{
			throw LogHelper.LogExceptionMessage(new IOException(LogHelper.FormatInvariant("IDX20804: Unable to retrieve document from: '{0}'.", address), innerException));
		}
	}
}
public class HttpDocumentRetriever : IDocumentRetriever
{
	private HttpClient _httpClient;

	private static readonly HttpClient _defaultHttpClient = new HttpClient();

	public bool RequireHttps { get; set; } = true;

	public HttpDocumentRetriever()
	{
	}

	public HttpDocumentRetriever(HttpClient httpClient)
	{
		if (httpClient == null)
		{
			throw LogHelper.LogArgumentNullException("httpClient");
		}
		_httpClient = httpClient;
	}

	public async Task<string> GetDocumentAsync(string address, CancellationToken cancel)
	{
		if (string.IsNullOrWhiteSpace(address))
		{
			throw LogHelper.LogArgumentNullException("address");
		}
		if (!Utility.IsHttps(address) && RequireHttps)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentException(LogHelper.FormatInvariant("IDX20108: The address specified '{0}' is not valid as per HTTPS scheme. Please specify an https address for security reasons. If you want to test with http address, set the RequireHttps property  on IDocumentRetriever to false.", address), "address"));
		}
		Exception exception;
		try
		{
			LogHelper.LogVerbose("IDX20805: Obtaining information from metadata endpoint: '{0}'.", address);
			HttpResponseMessage response = await (_httpClient ?? _defaultHttpClient).GetAsync(address, cancel).ConfigureAwait(continueOnCapturedContext: false);
			string text = await response.Content.ReadAsStringAsync().ConfigureAwait(continueOnCapturedContext: false);
			if (response.IsSuccessStatusCode)
			{
				return text;
			}
			exception = new IOException(LogHelper.FormatInvariant("IDX20807: Unable to retrieve document from: '{0}'. HttpResponseMessage: '{1}', HttpResponseMessage.Content: '{2}'.", address, response, text));
		}
		catch (Exception innerException)
		{
			throw LogHelper.LogExceptionMessage(new IOException(LogHelper.FormatInvariant("IDX20804: Unable to retrieve document from: '{0}'.", address), innerException));
		}
		throw LogHelper.LogExceptionMessage(exception);
	}
}
public interface IConfigurationManager<T> where T : class
{
	Task<T> GetConfigurationAsync(CancellationToken cancel);

	void RequestRefresh();
}
public interface IConfigurationRetriever<T>
{
	Task<T> GetConfigurationAsync(string address, IDocumentRetriever retriever, CancellationToken cancel);
}
public interface IDocumentRetriever
{
	Task<string> GetDocumentAsync(string address, CancellationToken cancel);
}
public class StaticConfigurationManager<T> : IConfigurationManager<T> where T : class
{
	private T _configuration;

	public StaticConfigurationManager(T configuration)
	{
		if (configuration == null)
		{
			throw LogHelper.LogExceptionMessage(new ArgumentNullException("configuration", LogHelper.FormatInvariant("IDX20000: The parameter '{0}' cannot be a 'null' or an empty object.", "configuration")));
		}
		_configuration = configuration;
	}

	public Task<T> GetConfigurationAsync(CancellationToken cancel)
	{
		return Task.FromResult(_configuration);
	}

	public void RequestRefresh()
	{
	}
}
internal static class LogMessages
{
	internal const string IDX20000 = "IDX20000: The parameter '{0}' cannot be a 'null' or an empty object.";

	internal const string IDX20106 = "IDX20106: When setting RefreshInterval, the value must be greater than MinimumRefreshInterval: '{0}'. value: '{1}'.";

	internal const string IDX20107 = "IDX20107: When setting AutomaticRefreshInterval, the value must be greater than MinimumAutomaticRefreshInterval: '{0}'. value: '{1}'.";

	internal const string IDX20108 = "IDX20108: The address specified '{0}' is not valid as per HTTPS scheme. Please specify an https address for security reasons. If you want to test with http address, set the RequireHttps property  on IDocumentRetriever to false.";

	internal const string IDX20803 = "IDX20803: Unable to obtain configuration from: '{0}'.";

	internal const string IDX20804 = "IDX20804: Unable to retrieve document from: '{0}'.";

	internal const string IDX20805 = "IDX20805: Obtaining information from metadata endpoint: '{0}'.";

	internal const string IDX20806 = "IDX20806: Unable to obtain an updated configuration from: '{0}'. Returning the current configuration.";

	internal const string IDX20807 = "IDX20807: Unable to retrieve document from: '{0}'. HttpResponseMessage: '{1}', HttpResponseMessage.Content: '{2}'.";
}
public class X509CertificateValidationMode
{
}
