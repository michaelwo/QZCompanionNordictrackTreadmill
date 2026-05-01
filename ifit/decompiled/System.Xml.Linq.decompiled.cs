using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Resources;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Xml.Serialization;

[assembly: RuntimeCompatibility(WrapNonExceptionThrows = true)]
[assembly: Debuggable(DebuggableAttribute.DebuggingModes.IgnoreSymbolStoreSequencePoints)]
[assembly: AssemblyTitle("System.Xml.Linq.dll")]
[assembly: AssemblyDescription("System.Xml.Linq.dll")]
[assembly: AssemblyDefaultAlias("System.Xml.Linq.dll")]
[assembly: AssemblyCompany("Mono development team")]
[assembly: AssemblyProduct("Mono Common Language Infrastructure")]
[assembly: AssemblyCopyright("(c) Various Mono authors")]
[assembly: SatelliteContractVersion("2.0.5.0")]
[assembly: AssemblyInformationalVersion("4.0.50524.0")]
[assembly: AssemblyFileVersion("4.0.50524.0")]
[assembly: NeutralResourcesLanguage("en-US")]
[assembly: CLSCompliant(true)]
[assembly: AssemblyDelaySign(true)]
[assembly: AssemblyKeyFile("../winfx.pub")]
[assembly: ComVisible(false)]
[assembly: CompilationRelaxations(CompilationRelaxations.NoStringInterning)]
[assembly: AssemblyVersion("2.0.5.0")]
[module: UnverifiableCode]
internal static class SR
{
	internal static string Format(string resourceFormat, object p1)
	{
		return string.Format(CultureInfo.InvariantCulture, resourceFormat, p1);
	}

	internal static string Format(string resourceFormat, object p1, object p2)
	{
		return string.Format(CultureInfo.InvariantCulture, resourceFormat, p1, p2);
	}
}
namespace System.Xml.Linq
{
	internal class BaseUriAnnotation
	{
		internal string baseUri;

		public BaseUriAnnotation(string baseUri)
		{
			this.baseUri = baseUri;
		}
	}
	internal class LineInfoAnnotation
	{
		internal int lineNumber;

		internal int linePosition;

		public LineInfoAnnotation(int lineNumber, int linePosition)
		{
			this.lineNumber = lineNumber;
			this.linePosition = linePosition;
		}
	}
	internal class LineInfoEndElementAnnotation : LineInfoAnnotation
	{
		public LineInfoEndElementAnnotation(int lineNumber, int linePosition)
			: base(lineNumber, linePosition)
		{
		}
	}
	public class XAttribute : XObject
	{
		internal XAttribute next;

		internal XName name;

		internal string value;

		public static IEnumerable<XAttribute> EmptySequence => Array.Empty<XAttribute>();

		public bool IsNamespaceDeclaration
		{
			get
			{
				string namespaceName = name.NamespaceName;
				if (namespaceName.Length == 0)
				{
					return name.LocalName == "xmlns";
				}
				return (object)namespaceName == "http://www.w3.org/2000/xmlns/";
			}
		}

		public XName Name => name;

		public override XmlNodeType NodeType => XmlNodeType.Attribute;

		public string Value
		{
			get
			{
				return value;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				ValidateAttribute(name, value);
				bool num = NotifyChanging(this, XObjectChangeEventArgs.Value);
				this.value = value;
				if (num)
				{
					NotifyChanged(this, XObjectChangeEventArgs.Value);
				}
			}
		}

		public XAttribute(XName name, object value)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			string stringValue = XContainer.GetStringValue(value);
			ValidateAttribute(name, stringValue);
			this.name = name;
			this.value = stringValue;
		}

		public XAttribute(XAttribute other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			name = other.name;
			value = other.value;
		}

		public override string ToString()
		{
			using StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
			XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
			xmlWriterSettings.ConformanceLevel = ConformanceLevel.Fragment;
			using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, xmlWriterSettings))
			{
				xmlWriter.WriteAttributeString(GetPrefixOfNamespace(name.Namespace), name.LocalName, name.NamespaceName, value);
			}
			return stringWriter.ToString().Trim();
		}

		internal int GetDeepHashCode()
		{
			return name.GetHashCode() ^ value.GetHashCode();
		}

		internal string GetPrefixOfNamespace(XNamespace ns)
		{
			string namespaceName = ns.NamespaceName;
			if (namespaceName.Length == 0)
			{
				return string.Empty;
			}
			if (parent != null)
			{
				return ((XElement)parent).GetPrefixOfNamespace(ns);
			}
			if ((object)namespaceName == "http://www.w3.org/XML/1998/namespace")
			{
				return "xml";
			}
			if ((object)namespaceName == "http://www.w3.org/2000/xmlns/")
			{
				return "xmlns";
			}
			return null;
		}

		private static void ValidateAttribute(XName name, string value)
		{
			string namespaceName = name.NamespaceName;
			if ((object)namespaceName == "http://www.w3.org/2000/xmlns/")
			{
				if (value.Length == 0)
				{
					throw new ArgumentException(global::SR.Format("The prefix '{0}' cannot be bound to the empty namespace name.", name.LocalName));
				}
				if (value == "http://www.w3.org/XML/1998/namespace")
				{
					if (name.LocalName != "xml")
					{
						throw new ArgumentException("The prefix 'xml' is bound to the namespace name 'http://www.w3.org/XML/1998/namespace'. Other prefixes must not be bound to this namespace name, and it must not be declared as the default namespace.");
					}
					return;
				}
				if (value == "http://www.w3.org/2000/xmlns/")
				{
					throw new ArgumentException("The prefix 'xmlns' is bound to the namespace name 'http://www.w3.org/2000/xmlns/'. It must not be declared. Other prefixes must not be bound to this namespace name, and it must not be declared as the default namespace.");
				}
				string localName = name.LocalName;
				if (localName == "xml")
				{
					throw new ArgumentException("The prefix 'xml' is bound to the namespace name 'http://www.w3.org/XML/1998/namespace'. Other prefixes must not be bound to this namespace name, and it must not be declared as the default namespace.");
				}
				if (localName == "xmlns")
				{
					throw new ArgumentException("The prefix 'xmlns' is bound to the namespace name 'http://www.w3.org/2000/xmlns/'. It must not be declared. Other prefixes must not be bound to this namespace name, and it must not be declared as the default namespace.");
				}
			}
			else if (namespaceName.Length == 0 && name.LocalName == "xmlns")
			{
				if (value == "http://www.w3.org/XML/1998/namespace")
				{
					throw new ArgumentException("The prefix 'xml' is bound to the namespace name 'http://www.w3.org/XML/1998/namespace'. Other prefixes must not be bound to this namespace name, and it must not be declared as the default namespace.");
				}
				if (value == "http://www.w3.org/2000/xmlns/")
				{
					throw new ArgumentException("The prefix 'xmlns' is bound to the namespace name 'http://www.w3.org/2000/xmlns/'. It must not be declared. Other prefixes must not be bound to this namespace name, and it must not be declared as the default namespace.");
				}
			}
		}
	}
	public class XCData : XText
	{
		public override XmlNodeType NodeType => XmlNodeType.CDATA;

		public XCData(string value)
			: base(value)
		{
		}

		public XCData(XCData other)
			: base(other)
		{
		}

		public override void WriteTo(XmlWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			writer.WriteCData(text);
		}

		public override Task WriteToAsync(XmlWriter writer, CancellationToken cancellationToken)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled(cancellationToken);
			}
			return writer.WriteCDataAsync(text);
		}

		internal override XNode CloneNode()
		{
			return new XCData(this);
		}
	}
	public class XComment : XNode
	{
		internal string value;

		public override XmlNodeType NodeType => XmlNodeType.Comment;

		public string Value
		{
			get
			{
				return value;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				bool num = NotifyChanging(this, XObjectChangeEventArgs.Value);
				this.value = value;
				if (num)
				{
					NotifyChanged(this, XObjectChangeEventArgs.Value);
				}
			}
		}

		public XComment(string value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			this.value = value;
		}

		public XComment(XComment other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			value = other.value;
		}

		public override void WriteTo(XmlWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			writer.WriteComment(value);
		}

		public override Task WriteToAsync(XmlWriter writer, CancellationToken cancellationToken)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled(cancellationToken);
			}
			return writer.WriteCommentAsync(value);
		}

		internal override XNode CloneNode()
		{
			return new XComment(this);
		}

		internal override bool DeepEquals(XNode node)
		{
			if (node is XComment xComment)
			{
				return value == xComment.value;
			}
			return false;
		}

		internal override int GetDeepHashCode()
		{
			return value.GetHashCode();
		}
	}
	public abstract class XContainer : XNode
	{
		private sealed class ContentReader
		{
			private readonly NamespaceCache _eCache;

			private readonly NamespaceCache _aCache;

			private readonly IXmlLineInfo _lineInfo;

			private XContainer _currentContainer;

			private string _baseUri;

			public ContentReader(XContainer rootContainer)
			{
				_currentContainer = rootContainer;
			}

			public ContentReader(XContainer rootContainer, XmlReader r, LoadOptions o)
			{
				_currentContainer = rootContainer;
				_baseUri = (((o & LoadOptions.SetBaseUri) != LoadOptions.None) ? r.BaseURI : null);
				_lineInfo = (((o & LoadOptions.SetLineInfo) != LoadOptions.None) ? (r as IXmlLineInfo) : null);
			}

			public bool ReadContentFrom(XContainer rootContainer, XmlReader r)
			{
				switch (r.NodeType)
				{
				case XmlNodeType.Element:
				{
					XElement xElement = new XElement(_eCache.Get(r.NamespaceURI).GetName(r.LocalName));
					if (r.MoveToFirstAttribute())
					{
						do
						{
							xElement.AppendAttributeSkipNotify(new XAttribute(_aCache.Get((r.Prefix.Length == 0) ? string.Empty : r.NamespaceURI).GetName(r.LocalName), r.Value));
						}
						while (r.MoveToNextAttribute());
						r.MoveToElement();
					}
					_currentContainer.AddNodeSkipNotify(xElement);
					if (!r.IsEmptyElement)
					{
						_currentContainer = xElement;
					}
					break;
				}
				case XmlNodeType.EndElement:
					if (_currentContainer.content == null)
					{
						_currentContainer.content = string.Empty;
					}
					if (_currentContainer == rootContainer)
					{
						return false;
					}
					_currentContainer = _currentContainer.parent;
					break;
				case XmlNodeType.Text:
				case XmlNodeType.Whitespace:
				case XmlNodeType.SignificantWhitespace:
					_currentContainer.AddStringSkipNotify(r.Value);
					break;
				case XmlNodeType.CDATA:
					_currentContainer.AddNodeSkipNotify(new XCData(r.Value));
					break;
				case XmlNodeType.Comment:
					_currentContainer.AddNodeSkipNotify(new XComment(r.Value));
					break;
				case XmlNodeType.ProcessingInstruction:
					_currentContainer.AddNodeSkipNotify(new XProcessingInstruction(r.Name, r.Value));
					break;
				case XmlNodeType.DocumentType:
					_currentContainer.AddNodeSkipNotify(new XDocumentType(r.LocalName, r.GetAttribute("PUBLIC"), r.GetAttribute("SYSTEM"), r.Value));
					break;
				case XmlNodeType.EntityReference:
					if (!r.CanResolveEntity)
					{
						throw new InvalidOperationException("The XmlReader cannot resolve entity references.");
					}
					r.ResolveEntity();
					break;
				default:
					throw new InvalidOperationException(global::SR.Format("The XmlReader should not be on a node of type {0}.", r.NodeType));
				case XmlNodeType.EndEntity:
					break;
				}
				return true;
			}

			public bool ReadContentFrom(XContainer rootContainer, XmlReader r, LoadOptions o)
			{
				XNode xNode = null;
				string baseURI = r.BaseURI;
				switch (r.NodeType)
				{
				case XmlNodeType.Element:
				{
					XElement xElement2 = new XElement(_eCache.Get(r.NamespaceURI).GetName(r.LocalName));
					if (_baseUri != null && _baseUri != baseURI)
					{
						xElement2.SetBaseUri(baseURI);
					}
					if (_lineInfo != null && _lineInfo.HasLineInfo())
					{
						xElement2.SetLineInfo(_lineInfo.LineNumber, _lineInfo.LinePosition);
					}
					if (r.MoveToFirstAttribute())
					{
						do
						{
							XAttribute xAttribute = new XAttribute(_aCache.Get((r.Prefix.Length == 0) ? string.Empty : r.NamespaceURI).GetName(r.LocalName), r.Value);
							if (_lineInfo != null && _lineInfo.HasLineInfo())
							{
								xAttribute.SetLineInfo(_lineInfo.LineNumber, _lineInfo.LinePosition);
							}
							xElement2.AppendAttributeSkipNotify(xAttribute);
						}
						while (r.MoveToNextAttribute());
						r.MoveToElement();
					}
					_currentContainer.AddNodeSkipNotify(xElement2);
					if (!r.IsEmptyElement)
					{
						_currentContainer = xElement2;
						if (_baseUri != null)
						{
							_baseUri = baseURI;
						}
					}
					break;
				}
				case XmlNodeType.EndElement:
					if (_currentContainer.content == null)
					{
						_currentContainer.content = string.Empty;
					}
					if (_currentContainer is XElement xElement && _lineInfo != null && _lineInfo.HasLineInfo())
					{
						xElement.SetEndElementLineInfo(_lineInfo.LineNumber, _lineInfo.LinePosition);
					}
					if (_currentContainer == rootContainer)
					{
						return false;
					}
					if (_baseUri != null && _currentContainer.HasBaseUri)
					{
						_baseUri = _currentContainer.parent.BaseUri;
					}
					_currentContainer = _currentContainer.parent;
					break;
				case XmlNodeType.Text:
				case XmlNodeType.Whitespace:
				case XmlNodeType.SignificantWhitespace:
					if ((_baseUri != null && _baseUri != baseURI) || (_lineInfo != null && _lineInfo.HasLineInfo()))
					{
						xNode = new XText(r.Value);
					}
					else
					{
						_currentContainer.AddStringSkipNotify(r.Value);
					}
					break;
				case XmlNodeType.CDATA:
					xNode = new XCData(r.Value);
					break;
				case XmlNodeType.Comment:
					xNode = new XComment(r.Value);
					break;
				case XmlNodeType.ProcessingInstruction:
					xNode = new XProcessingInstruction(r.Name, r.Value);
					break;
				case XmlNodeType.DocumentType:
					xNode = new XDocumentType(r.LocalName, r.GetAttribute("PUBLIC"), r.GetAttribute("SYSTEM"), r.Value);
					break;
				case XmlNodeType.EntityReference:
					if (!r.CanResolveEntity)
					{
						throw new InvalidOperationException("The XmlReader cannot resolve entity references.");
					}
					r.ResolveEntity();
					break;
				default:
					throw new InvalidOperationException(global::SR.Format("The XmlReader should not be on a node of type {0}.", r.NodeType));
				case XmlNodeType.EndEntity:
					break;
				}
				if (xNode != null)
				{
					if (_baseUri != null && _baseUri != baseURI)
					{
						xNode.SetBaseUri(baseURI);
					}
					if (_lineInfo != null && _lineInfo.HasLineInfo())
					{
						xNode.SetLineInfo(_lineInfo.LineNumber, _lineInfo.LinePosition);
					}
					_currentContainer.AddNodeSkipNotify(xNode);
					xNode = null;
				}
				return true;
			}
		}

		internal object content;

		public XNode FirstNode => LastNode?.next;

		public XNode LastNode
		{
			get
			{
				if (content == null)
				{
					return null;
				}
				if (content is XNode result)
				{
					return result;
				}
				if (content is string text)
				{
					if (text.Length == 0)
					{
						return null;
					}
					XText xText = new XText(text);
					xText.parent = this;
					xText.next = xText;
					Interlocked.CompareExchange<object>(ref content, (object)xText, (object)text);
				}
				return (XNode)content;
			}
		}

		internal XContainer()
		{
		}

		internal XContainer(XContainer other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			if (other.content is string)
			{
				content = other.content;
				return;
			}
			XNode xNode = (XNode)other.content;
			if (xNode != null)
			{
				do
				{
					xNode = xNode.next;
					AppendNodeSkipNotify(xNode.CloneNode());
				}
				while (xNode != other.content);
			}
		}

		public void Add(object content)
		{
			if (SkipNotify())
			{
				AddContentSkipNotify(content);
			}
			else
			{
				if (content == null)
				{
					return;
				}
				if (content is XNode n)
				{
					AddNode(n);
					return;
				}
				if (content is string s)
				{
					AddString(s);
					return;
				}
				if (content is XAttribute a)
				{
					AddAttribute(a);
					return;
				}
				if (content is XStreamingElement other)
				{
					AddNode(new XElement(other));
					return;
				}
				if (content is object[] array)
				{
					object[] array2 = array;
					foreach (object obj in array2)
					{
						Add(obj);
					}
					return;
				}
				if (content is IEnumerable enumerable)
				{
					{
						foreach (object item in enumerable)
						{
							Add(item);
						}
						return;
					}
				}
				AddString(GetStringValue(content));
			}
		}

		public IEnumerable<XElement> Descendants(XName name)
		{
			if (!(name != null))
			{
				return XElement.EmptySequence;
			}
			return GetDescendants(name, self: false);
		}

		public XElement Element(XName name)
		{
			XNode xNode = content as XNode;
			if (xNode != null)
			{
				do
				{
					xNode = xNode.next;
					if (xNode is XElement xElement && xElement.name == name)
					{
						return xElement;
					}
				}
				while (xNode != content);
			}
			return null;
		}

		public IEnumerable<XNode> Nodes()
		{
			XNode n = LastNode;
			if (n != null)
			{
				do
				{
					n = n.next;
					yield return n;
				}
				while (n.parent == this && n != content);
			}
		}

		public void RemoveNodes()
		{
			if (SkipNotify())
			{
				RemoveNodesSkipNotify();
				return;
			}
			while (content != null)
			{
				if (content is string text)
				{
					if (text.Length > 0)
					{
						ConvertTextToNode();
					}
					else if (this is XElement)
					{
						NotifyChanging(this, XObjectChangeEventArgs.Value);
						if (text != content)
						{
							throw new InvalidOperationException("This operation was corrupted by external code.");
						}
						content = null;
						NotifyChanged(this, XObjectChangeEventArgs.Value);
					}
					else
					{
						content = null;
					}
				}
				if (content is XNode { next: var xNode2 } xNode)
				{
					NotifyChanging(xNode2, XObjectChangeEventArgs.Remove);
					if (xNode != content || xNode2 != xNode.next)
					{
						throw new InvalidOperationException("This operation was corrupted by external code.");
					}
					if (xNode2 != xNode)
					{
						xNode.next = xNode2.next;
					}
					else
					{
						content = null;
					}
					xNode2.parent = null;
					xNode2.next = null;
					NotifyChanged(xNode2, XObjectChangeEventArgs.Remove);
				}
			}
		}

		internal virtual void AddAttribute(XAttribute a)
		{
		}

		internal virtual void AddAttributeSkipNotify(XAttribute a)
		{
		}

		internal void AddContentSkipNotify(object content)
		{
			if (content == null)
			{
				return;
			}
			if (content is XNode n)
			{
				AddNodeSkipNotify(n);
				return;
			}
			if (content is string s)
			{
				AddStringSkipNotify(s);
				return;
			}
			if (content is XAttribute a)
			{
				AddAttributeSkipNotify(a);
				return;
			}
			if (content is XStreamingElement other)
			{
				AddNodeSkipNotify(new XElement(other));
				return;
			}
			if (content is object[] array)
			{
				object[] array2 = array;
				foreach (object obj in array2)
				{
					AddContentSkipNotify(obj);
				}
				return;
			}
			if (content is IEnumerable enumerable)
			{
				{
					foreach (object item in enumerable)
					{
						AddContentSkipNotify(item);
					}
					return;
				}
			}
			AddStringSkipNotify(GetStringValue(content));
		}

		internal void AddNode(XNode n)
		{
			ValidateNode(n, this);
			if (n.parent != null)
			{
				n = n.CloneNode();
			}
			else
			{
				XNode xNode = this;
				while (xNode.parent != null)
				{
					xNode = xNode.parent;
				}
				if (n == xNode)
				{
					n = n.CloneNode();
				}
			}
			ConvertTextToNode();
			AppendNode(n);
		}

		internal void AddNodeSkipNotify(XNode n)
		{
			ValidateNode(n, this);
			if (n.parent != null)
			{
				n = n.CloneNode();
			}
			else
			{
				XNode xNode = this;
				while (xNode.parent != null)
				{
					xNode = xNode.parent;
				}
				if (n == xNode)
				{
					n = n.CloneNode();
				}
			}
			ConvertTextToNode();
			AppendNodeSkipNotify(n);
		}

		internal void AddString(string s)
		{
			ValidateString(s);
			if (content == null)
			{
				if (s.Length > 0)
				{
					AppendNode(new XText(s));
				}
				else if (this is XElement)
				{
					NotifyChanging(this, XObjectChangeEventArgs.Value);
					if (content != null)
					{
						throw new InvalidOperationException("This operation was corrupted by external code.");
					}
					content = s;
					NotifyChanged(this, XObjectChangeEventArgs.Value);
				}
				else
				{
					content = s;
				}
			}
			else if (s.Length > 0)
			{
				ConvertTextToNode();
				if (content is XText xText && !(xText is XCData))
				{
					xText.Value += s;
				}
				else
				{
					AppendNode(new XText(s));
				}
			}
		}

		internal void AddStringSkipNotify(string s)
		{
			ValidateString(s);
			if (content == null)
			{
				content = s;
			}
			else if (s.Length > 0)
			{
				if (content is string text)
				{
					content = text + s;
				}
				else if (content is XText xText && !(xText is XCData))
				{
					xText.text += s;
				}
				else
				{
					AppendNodeSkipNotify(new XText(s));
				}
			}
		}

		internal void AppendNode(XNode n)
		{
			bool num = NotifyChanging(n, XObjectChangeEventArgs.Add);
			if (n.parent != null)
			{
				throw new InvalidOperationException("This operation was corrupted by external code.");
			}
			AppendNodeSkipNotify(n);
			if (num)
			{
				NotifyChanged(n, XObjectChangeEventArgs.Add);
			}
		}

		internal void AppendNodeSkipNotify(XNode n)
		{
			n.parent = this;
			if (content == null || content is string)
			{
				n.next = n;
			}
			else
			{
				XNode xNode = (XNode)content;
				n.next = xNode.next;
				xNode.next = n;
			}
			content = n;
		}

		internal override void AppendText(StringBuilder sb)
		{
			if (content is string value)
			{
				sb.Append(value);
				return;
			}
			XNode xNode = (XNode)content;
			if (xNode != null)
			{
				do
				{
					xNode = xNode.next;
					xNode.AppendText(sb);
				}
				while (xNode != content);
			}
		}

		private string GetTextOnly()
		{
			if (content == null)
			{
				return null;
			}
			string text = content as string;
			if (text == null)
			{
				XNode xNode = (XNode)content;
				do
				{
					xNode = xNode.next;
					if (xNode.NodeType != XmlNodeType.Text)
					{
						return null;
					}
					text += ((XText)xNode).Value;
				}
				while (xNode != content);
			}
			return text;
		}

		private string CollectText(ref XNode n)
		{
			string text = "";
			while (n != null && n.NodeType == XmlNodeType.Text)
			{
				text += ((XText)n).Value;
				n = ((n != content) ? n.next : null);
			}
			return text;
		}

		internal bool ContentsEqual(XContainer e)
		{
			if (content == e.content)
			{
				return true;
			}
			string textOnly = GetTextOnly();
			if (textOnly != null)
			{
				return textOnly == e.GetTextOnly();
			}
			XNode xNode = content as XNode;
			XNode xNode2 = e.content as XNode;
			if (xNode != null && xNode2 != null)
			{
				xNode = xNode.next;
				xNode2 = xNode2.next;
				while (!(CollectText(ref xNode) != e.CollectText(ref xNode2)))
				{
					if (xNode == null && xNode2 == null)
					{
						return true;
					}
					if (xNode == null || xNode2 == null || !xNode.DeepEquals(xNode2))
					{
						break;
					}
					xNode = ((xNode != content) ? xNode.next : null);
					xNode2 = ((xNode2 != e.content) ? xNode2.next : null);
				}
			}
			return false;
		}

		internal int ContentsHashCode()
		{
			string textOnly = GetTextOnly();
			if (textOnly != null)
			{
				return textOnly.GetHashCode();
			}
			int num = 0;
			XNode n = content as XNode;
			if (n != null)
			{
				do
				{
					n = n.next;
					string text = CollectText(ref n);
					if (text.Length > 0)
					{
						num ^= text.GetHashCode();
					}
					if (n == null)
					{
						break;
					}
					num ^= n.GetDeepHashCode();
				}
				while (n != content);
			}
			return num;
		}

		internal void ConvertTextToNode()
		{
			string value = content as string;
			if (!string.IsNullOrEmpty(value))
			{
				XText xText = new XText(value);
				xText.parent = this;
				xText.next = xText;
				content = xText;
			}
		}

		internal IEnumerable<XNode> GetDescendantNodes(bool self)
		{
			if (self)
			{
				yield return this;
			}
			XNode n = this;
			while (true)
			{
				XNode firstNode;
				if (n is XContainer xContainer && (firstNode = xContainer.FirstNode) != null)
				{
					n = firstNode;
				}
				else
				{
					while (n != null && n != this && n == n.parent.content)
					{
						n = n.parent;
					}
					if (n == null || n == this)
					{
						break;
					}
					n = n.next;
				}
				yield return n;
			}
		}

		internal IEnumerable<XElement> GetDescendants(XName name, bool self)
		{
			if (self)
			{
				XElement xElement = (XElement)this;
				if (name == null || xElement.name == name)
				{
					yield return xElement;
				}
			}
			XNode n = this;
			XContainer xContainer = this;
			while (true)
			{
				if (xContainer != null && xContainer.content is XNode)
				{
					n = ((XNode)xContainer.content).next;
				}
				else
				{
					while (n != this && n == n.parent.content)
					{
						n = n.parent;
					}
					if (n == this)
					{
						break;
					}
					n = n.next;
				}
				XElement e = n as XElement;
				if (e != null && (name == null || e.name == name))
				{
					yield return e;
				}
				xContainer = e;
			}
		}

		internal static string GetStringValue(object value)
		{
			if (value is string result)
			{
				return result;
			}
			string text;
			if (value is double)
			{
				text = XmlConvert.ToString((double)value);
			}
			else if (value is float)
			{
				text = XmlConvert.ToString((float)value);
			}
			else if (value is decimal)
			{
				text = XmlConvert.ToString((decimal)value);
			}
			else if (value is bool)
			{
				text = XmlConvert.ToString((bool)value);
			}
			else if (value is DateTime)
			{
				text = XmlConvert.ToString((DateTime)value, XmlDateTimeSerializationMode.RoundtripKind);
			}
			else if (value is DateTimeOffset)
			{
				text = XmlConvert.ToString((DateTimeOffset)value);
			}
			else if (value is TimeSpan)
			{
				text = XmlConvert.ToString((TimeSpan)value);
			}
			else
			{
				if (value is XObject)
				{
					throw new ArgumentException("An XObject cannot be used as a value.");
				}
				text = value.ToString();
			}
			if (text == null)
			{
				throw new ArgumentException("The argument cannot be converted to a string.");
			}
			return text;
		}

		internal void ReadContentFrom(XmlReader r)
		{
			if (r.ReadState != ReadState.Interactive)
			{
				throw new InvalidOperationException("The XmlReader state should be Interactive.");
			}
			ContentReader contentReader = new ContentReader(this);
			while (contentReader.ReadContentFrom(this, r) && r.Read())
			{
			}
		}

		internal void ReadContentFrom(XmlReader r, LoadOptions o)
		{
			if ((o & (LoadOptions.SetBaseUri | LoadOptions.SetLineInfo)) == 0)
			{
				ReadContentFrom(r);
				return;
			}
			if (r.ReadState != ReadState.Interactive)
			{
				throw new InvalidOperationException("The XmlReader state should be Interactive.");
			}
			ContentReader contentReader = new ContentReader(this, r, o);
			while (contentReader.ReadContentFrom(this, r, o) && r.Read())
			{
			}
		}

		internal async Task ReadContentFromAsync(XmlReader r, CancellationToken cancellationToken)
		{
			if (r.ReadState != ReadState.Interactive)
			{
				throw new InvalidOperationException("The XmlReader state should be Interactive.");
			}
			ContentReader cr = new ContentReader(this);
			bool flag;
			do
			{
				cancellationToken.ThrowIfCancellationRequested();
				flag = cr.ReadContentFrom(this, r);
				if (flag)
				{
					flag = await r.ReadAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			while (flag);
		}

		internal async Task ReadContentFromAsync(XmlReader r, LoadOptions o, CancellationToken cancellationToken)
		{
			if ((o & (LoadOptions.SetBaseUri | LoadOptions.SetLineInfo)) == 0)
			{
				await ReadContentFromAsync(r, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				return;
			}
			if (r.ReadState != ReadState.Interactive)
			{
				throw new InvalidOperationException("The XmlReader state should be Interactive.");
			}
			ContentReader cr = new ContentReader(this, r, o);
			bool flag;
			do
			{
				cancellationToken.ThrowIfCancellationRequested();
				flag = cr.ReadContentFrom(this, r, o);
				if (flag)
				{
					flag = await r.ReadAsync().ConfigureAwait(continueOnCapturedContext: false);
				}
			}
			while (flag);
		}

		internal void RemoveNode(XNode n)
		{
			bool flag = NotifyChanging(n, XObjectChangeEventArgs.Remove);
			if (n.parent != this)
			{
				throw new InvalidOperationException("This operation was corrupted by external code.");
			}
			XNode xNode = (XNode)content;
			while (xNode.next != n)
			{
				xNode = xNode.next;
			}
			if (xNode == n)
			{
				content = null;
			}
			else
			{
				if (content == n)
				{
					content = xNode;
				}
				xNode.next = n.next;
			}
			n.parent = null;
			n.next = null;
			if (flag)
			{
				NotifyChanged(n, XObjectChangeEventArgs.Remove);
			}
		}

		private void RemoveNodesSkipNotify()
		{
			XNode xNode = content as XNode;
			if (xNode != null)
			{
				do
				{
					XNode xNode2 = xNode.next;
					xNode.parent = null;
					xNode.next = null;
					xNode = xNode2;
				}
				while (xNode != content);
			}
			content = null;
		}

		internal virtual void ValidateNode(XNode node, XNode previous)
		{
		}

		internal virtual void ValidateString(string s)
		{
		}

		internal void WriteContentTo(XmlWriter writer)
		{
			if (content == null)
			{
				return;
			}
			if (content is string text)
			{
				if (this is XDocument)
				{
					writer.WriteWhitespace(text);
				}
				else
				{
					writer.WriteString(text);
				}
				return;
			}
			XNode xNode = (XNode)content;
			do
			{
				xNode = xNode.next;
				xNode.WriteTo(writer);
			}
			while (xNode != content);
		}

		internal async Task WriteContentToAsync(XmlWriter writer, CancellationToken cancellationToken)
		{
			if (content == null)
			{
				return;
			}
			if (content is string text)
			{
				cancellationToken.ThrowIfCancellationRequested();
				Task task = ((!(this is XDocument)) ? writer.WriteStringAsync(text) : writer.WriteWhitespaceAsync(text));
				await task.ConfigureAwait(continueOnCapturedContext: false);
				return;
			}
			XNode n = (XNode)content;
			do
			{
				n = n.next;
				await n.WriteToAsync(writer, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			}
			while (n != content);
		}

		private static void AddContentToList(List<object> list, object content)
		{
			IEnumerable enumerable = ((content is string) ? null : (content as IEnumerable));
			if (enumerable == null)
			{
				list.Add(content);
				return;
			}
			foreach (object item in enumerable)
			{
				if (item != null)
				{
					AddContentToList(list, item);
				}
			}
		}

		internal static object GetContentSnapshot(object content)
		{
			if (content is string || !(content is IEnumerable))
			{
				return content;
			}
			List<object> list = new List<object>();
			AddContentToList(list, content);
			return list;
		}
	}
	public class XDeclaration
	{
		private string _version;

		private string _encoding;

		private string _standalone;

		public string Encoding
		{
			get
			{
				return _encoding;
			}
			set
			{
				_encoding = value;
			}
		}

		public string Standalone
		{
			get
			{
				return _standalone;
			}
			set
			{
				_standalone = value;
			}
		}

		public string Version => _version;

		public XDeclaration(string version, string encoding, string standalone)
		{
			_version = version;
			_encoding = encoding;
			_standalone = standalone;
		}

		public XDeclaration(XDeclaration other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			_version = other._version;
			_encoding = other._encoding;
			_standalone = other._standalone;
		}

		internal XDeclaration(XmlReader r)
		{
			_version = r.GetAttribute("version");
			_encoding = r.GetAttribute("encoding");
			_standalone = r.GetAttribute("standalone");
			r.Read();
		}

		public override string ToString()
		{
			StringBuilder stringBuilder = System.Text.StringBuilderCache.Acquire();
			stringBuilder.Append("<?xml");
			if (_version != null)
			{
				stringBuilder.Append(" version=\"");
				stringBuilder.Append(_version);
				stringBuilder.Append('"');
			}
			if (_encoding != null)
			{
				stringBuilder.Append(" encoding=\"");
				stringBuilder.Append(_encoding);
				stringBuilder.Append('"');
			}
			if (_standalone != null)
			{
				stringBuilder.Append(" standalone=\"");
				stringBuilder.Append(_standalone);
				stringBuilder.Append('"');
			}
			stringBuilder.Append("?>");
			return System.Text.StringBuilderCache.GetStringAndRelease(stringBuilder);
		}
	}
	public class XDocument : XContainer
	{
		private XDeclaration _declaration;

		public XDeclaration Declaration
		{
			get
			{
				return _declaration;
			}
			set
			{
				_declaration = value;
			}
		}

		public override XmlNodeType NodeType => XmlNodeType.Document;

		public XElement Root => GetFirstNode<XElement>();

		public XDocument()
		{
		}

		public XDocument(params object[] content)
			: this()
		{
			AddContentSkipNotify(content);
		}

		public XDocument(XDeclaration declaration, params object[] content)
			: this(content)
		{
			_declaration = declaration;
		}

		public XDocument(XDocument other)
			: base(other)
		{
			if (other._declaration != null)
			{
				_declaration = new XDeclaration(other._declaration);
			}
		}

		public static XDocument Load(Stream stream)
		{
			return Load(stream, LoadOptions.None);
		}

		public static XDocument Load(Stream stream, LoadOptions options)
		{
			XmlReaderSettings xmlReaderSettings = XNode.GetXmlReaderSettings(options);
			using XmlReader reader = XmlReader.Create(stream, xmlReaderSettings);
			return Load(reader, options);
		}

		public static XDocument Load(XmlReader reader, LoadOptions options)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			if (reader.ReadState == ReadState.Initial)
			{
				reader.Read();
			}
			XDocument xDocument = InitLoad(reader, options);
			xDocument.ReadContentFrom(reader, options);
			if (!reader.EOF)
			{
				throw new InvalidOperationException("The XmlReader state should be EndOfFile after this operation.");
			}
			if (xDocument.Root == null)
			{
				throw new InvalidOperationException("The root element is missing.");
			}
			return xDocument;
		}

		private static XDocument InitLoad(XmlReader reader, LoadOptions options)
		{
			XDocument xDocument = new XDocument();
			if ((options & LoadOptions.SetBaseUri) != LoadOptions.None)
			{
				string baseURI = reader.BaseURI;
				if (!string.IsNullOrEmpty(baseURI))
				{
					xDocument.SetBaseUri(baseURI);
				}
			}
			if ((options & LoadOptions.SetLineInfo) != LoadOptions.None && reader is IXmlLineInfo xmlLineInfo && xmlLineInfo.HasLineInfo())
			{
				xDocument.SetLineInfo(xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
			}
			if (reader.NodeType == XmlNodeType.XmlDeclaration)
			{
				xDocument.Declaration = new XDeclaration(reader);
			}
			return xDocument;
		}

		public override void WriteTo(XmlWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			if (_declaration != null && _declaration.Standalone == "yes")
			{
				writer.WriteStartDocument(standalone: true);
			}
			else if (_declaration != null && _declaration.Standalone == "no")
			{
				writer.WriteStartDocument(standalone: false);
			}
			else
			{
				writer.WriteStartDocument();
			}
			WriteContentTo(writer);
			writer.WriteEndDocument();
		}

		public override Task WriteToAsync(XmlWriter writer, CancellationToken cancellationToken)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled(cancellationToken);
			}
			return WriteToAsyncInternal(writer, cancellationToken);
		}

		private async Task WriteToAsyncInternal(XmlWriter writer, CancellationToken cancellationToken)
		{
			Task task = ((_declaration != null && _declaration.Standalone == "yes") ? writer.WriteStartDocumentAsync(standalone: true) : ((_declaration == null || !(_declaration.Standalone == "no")) ? writer.WriteStartDocumentAsync() : writer.WriteStartDocumentAsync(standalone: false)));
			await task.ConfigureAwait(continueOnCapturedContext: false);
			await WriteContentToAsync(writer, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			await writer.WriteEndDocumentAsync().ConfigureAwait(continueOnCapturedContext: false);
		}

		internal override void AddAttribute(XAttribute a)
		{
			throw new ArgumentException("An attribute cannot be added to content.");
		}

		internal override void AddAttributeSkipNotify(XAttribute a)
		{
			throw new ArgumentException("An attribute cannot be added to content.");
		}

		internal override XNode CloneNode()
		{
			return new XDocument(this);
		}

		internal override bool DeepEquals(XNode node)
		{
			if (node is XDocument e)
			{
				return ContentsEqual(e);
			}
			return false;
		}

		internal override int GetDeepHashCode()
		{
			return ContentsHashCode();
		}

		private T GetFirstNode<T>() where T : XNode
		{
			XNode xNode = content as XNode;
			if (xNode != null)
			{
				do
				{
					xNode = xNode.next;
					if (xNode is T result)
					{
						return result;
					}
				}
				while (xNode != content);
			}
			return null;
		}

		internal static bool IsWhitespace(string s)
		{
			foreach (char c in s)
			{
				if (c != ' ' && c != '\t' && c != '\r' && c != '\n')
				{
					return false;
				}
			}
			return true;
		}

		internal override void ValidateNode(XNode node, XNode previous)
		{
			switch (node.NodeType)
			{
			case XmlNodeType.Text:
				ValidateString(((XText)node).Value);
				break;
			case XmlNodeType.Element:
				ValidateDocument(previous, XmlNodeType.DocumentType, XmlNodeType.None);
				break;
			case XmlNodeType.DocumentType:
				ValidateDocument(previous, XmlNodeType.None, XmlNodeType.Element);
				break;
			case XmlNodeType.CDATA:
				throw new ArgumentException(global::SR.Format("A node of type {0} cannot be added to content.", XmlNodeType.CDATA));
			case XmlNodeType.Document:
				throw new ArgumentException(global::SR.Format("A node of type {0} cannot be added to content.", XmlNodeType.Document));
			}
		}

		private void ValidateDocument(XNode previous, XmlNodeType allowBefore, XmlNodeType allowAfter)
		{
			XNode xNode = content as XNode;
			if (xNode == null)
			{
				return;
			}
			if (previous == null)
			{
				allowBefore = allowAfter;
			}
			do
			{
				xNode = xNode.next;
				XmlNodeType nodeType = xNode.NodeType;
				if (nodeType == XmlNodeType.Element || nodeType == XmlNodeType.DocumentType)
				{
					if (nodeType != allowBefore)
					{
						throw new InvalidOperationException("This operation would create an incorrectly structured document.");
					}
					allowBefore = XmlNodeType.None;
				}
				if (xNode == previous)
				{
					allowBefore = allowAfter;
				}
			}
			while (xNode != content);
		}

		internal override void ValidateString(string s)
		{
			if (!IsWhitespace(s))
			{
				throw new ArgumentException("Non-whitespace characters cannot be added to content.");
			}
		}
	}
	public class XDocumentType : XNode
	{
		private string _name;

		private string _publicId;

		private string _systemId;

		private string _internalSubset;

		public string InternalSubset => _internalSubset;

		public string Name => _name;

		public override XmlNodeType NodeType => XmlNodeType.DocumentType;

		public string PublicId => _publicId;

		public string SystemId => _systemId;

		public XDocumentType(string name, string publicId, string systemId, string internalSubset)
		{
			_name = XmlConvert.VerifyName(name);
			_publicId = publicId;
			_systemId = systemId;
			_internalSubset = internalSubset;
		}

		public XDocumentType(XDocumentType other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			_name = other._name;
			_publicId = other._publicId;
			_systemId = other._systemId;
			_internalSubset = other._internalSubset;
		}

		public override void WriteTo(XmlWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			writer.WriteDocType(_name, _publicId, _systemId, _internalSubset);
		}

		public override Task WriteToAsync(XmlWriter writer, CancellationToken cancellationToken)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled(cancellationToken);
			}
			return writer.WriteDocTypeAsync(_name, _publicId, _systemId, _internalSubset);
		}

		internal override XNode CloneNode()
		{
			return new XDocumentType(this);
		}

		internal override bool DeepEquals(XNode node)
		{
			if (node is XDocumentType xDocumentType && _name == xDocumentType._name && _publicId == xDocumentType._publicId && _systemId == xDocumentType.SystemId)
			{
				return _internalSubset == xDocumentType._internalSubset;
			}
			return false;
		}

		internal override int GetDeepHashCode()
		{
			return _name.GetHashCode() ^ ((_publicId != null) ? _publicId.GetHashCode() : 0) ^ ((_systemId != null) ? _systemId.GetHashCode() : 0) ^ ((_internalSubset != null) ? _internalSubset.GetHashCode() : 0);
		}
	}
	[XmlTypeConvertor("ConvertForAssignment")]
	[XmlSchemaProvider(null, IsAny = true)]
	public class XElement : XContainer, IXmlSerializable
	{
		[StructLayout(LayoutKind.Sequential, Size = 1)]
		private struct AsyncConstructionSentry
		{
		}

		internal XName name;

		internal XAttribute lastAttr;

		public static IEnumerable<XElement> EmptySequence => Array.Empty<XElement>();

		public XAttribute FirstAttribute
		{
			get
			{
				if (lastAttr == null)
				{
					return null;
				}
				return lastAttr.next;
			}
		}

		public bool HasAttributes => lastAttr != null;

		public bool HasElements
		{
			get
			{
				XNode xNode = content as XNode;
				if (xNode != null)
				{
					do
					{
						if (xNode is XElement)
						{
							return true;
						}
						xNode = xNode.next;
					}
					while (xNode != content);
				}
				return false;
			}
		}

		public bool IsEmpty => content == null;

		public XAttribute LastAttribute => lastAttr;

		public XName Name
		{
			get
			{
				return name;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				bool num = NotifyChanging(this, XObjectChangeEventArgs.Name);
				name = value;
				if (num)
				{
					NotifyChanged(this, XObjectChangeEventArgs.Name);
				}
			}
		}

		public override XmlNodeType NodeType => XmlNodeType.Element;

		public string Value
		{
			get
			{
				if (content == null)
				{
					return string.Empty;
				}
				if (content is string result)
				{
					return result;
				}
				StringBuilder sb = System.Text.StringBuilderCache.Acquire();
				AppendText(sb);
				return System.Text.StringBuilderCache.GetStringAndRelease(sb);
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				RemoveNodes();
				Add(value);
			}
		}

		public XElement(XName name)
		{
			if (name == null)
			{
				throw new ArgumentNullException("name");
			}
			this.name = name;
		}

		public XElement(XName name, object content)
			: this(name)
		{
			AddContentSkipNotify(content);
		}

		public XElement(XName name, params object[] content)
			: this(name, (object)content)
		{
		}

		public XElement(XElement other)
			: base(other)
		{
			name = other.name;
			XAttribute xAttribute = other.lastAttr;
			if (xAttribute != null)
			{
				do
				{
					xAttribute = xAttribute.next;
					AppendAttributeSkipNotify(new XAttribute(xAttribute));
				}
				while (xAttribute != other.lastAttr);
			}
		}

		public XElement(XStreamingElement other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			name = other.name;
			AddContentSkipNotify(other.content);
		}

		internal XElement()
			: this("default")
		{
		}

		internal XElement(XmlReader r)
			: this(r, LoadOptions.None)
		{
		}

		private XElement(AsyncConstructionSentry s)
		{
		}

		internal XElement(XmlReader r, LoadOptions o)
		{
			ReadElementFrom(r, o);
		}

		internal static async Task<XElement> CreateAsync(XmlReader r, CancellationToken cancellationToken)
		{
			XElement xe = new XElement(default(AsyncConstructionSentry));
			await xe.ReadElementFromAsync(r, LoadOptions.None, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			return xe;
		}

		public void Save(string fileName)
		{
			Save(fileName, GetSaveOptionsFromAnnotations());
		}

		public void Save(string fileName, SaveOptions options)
		{
			XmlWriterSettings xmlWriterSettings = XNode.GetXmlWriterSettings(options);
			using XmlWriter writer = XmlWriter.Create(fileName, xmlWriterSettings);
			Save(writer);
		}

		public IEnumerable<XElement> AncestorsAndSelf()
		{
			return GetAncestors(null, self: true);
		}

		public IEnumerable<XElement> AncestorsAndSelf(XName name)
		{
			if (!(name != null))
			{
				return EmptySequence;
			}
			return GetAncestors(name, self: true);
		}

		public XAttribute Attribute(XName name)
		{
			XAttribute xAttribute = lastAttr;
			if (xAttribute != null)
			{
				do
				{
					xAttribute = xAttribute.next;
					if (xAttribute.name == name)
					{
						return xAttribute;
					}
				}
				while (xAttribute != lastAttr);
			}
			return null;
		}

		public IEnumerable<XAttribute> Attributes()
		{
			return GetAttributes(null);
		}

		public IEnumerable<XAttribute> Attributes(XName name)
		{
			if (!(name != null))
			{
				return XAttribute.EmptySequence;
			}
			return GetAttributes(name);
		}

		public IEnumerable<XNode> DescendantNodesAndSelf()
		{
			return GetDescendantNodes(self: true);
		}

		public IEnumerable<XElement> DescendantsAndSelf()
		{
			return GetDescendants(null, self: true);
		}

		public IEnumerable<XElement> DescendantsAndSelf(XName name)
		{
			if (!(name != null))
			{
				return EmptySequence;
			}
			return GetDescendants(name, self: true);
		}

		public XNamespace GetDefaultNamespace()
		{
			string namespaceOfPrefixInScope = GetNamespaceOfPrefixInScope("xmlns", null);
			if (namespaceOfPrefixInScope == null)
			{
				return XNamespace.None;
			}
			return XNamespace.Get(namespaceOfPrefixInScope);
		}

		public XNamespace GetNamespaceOfPrefix(string prefix)
		{
			if (prefix == null)
			{
				throw new ArgumentNullException("prefix");
			}
			if (prefix.Length == 0)
			{
				throw new ArgumentException(global::SR.Format("'{0}' is an invalid prefix.", prefix));
			}
			if (prefix == "xmlns")
			{
				return XNamespace.Xmlns;
			}
			string namespaceOfPrefixInScope = GetNamespaceOfPrefixInScope(prefix, null);
			if (namespaceOfPrefixInScope != null)
			{
				return XNamespace.Get(namespaceOfPrefixInScope);
			}
			if (prefix == "xml")
			{
				return XNamespace.Xml;
			}
			return null;
		}

		public string GetPrefixOfNamespace(XNamespace ns)
		{
			if (ns == null)
			{
				throw new ArgumentNullException("ns");
			}
			string namespaceName = ns.NamespaceName;
			bool flag = false;
			XElement xElement = this;
			do
			{
				XAttribute xAttribute = xElement.lastAttr;
				if (xAttribute != null)
				{
					bool flag2 = false;
					do
					{
						xAttribute = xAttribute.next;
						if (xAttribute.IsNamespaceDeclaration)
						{
							if (xAttribute.Value == namespaceName && xAttribute.Name.NamespaceName.Length != 0 && (!flag || GetNamespaceOfPrefixInScope(xAttribute.Name.LocalName, xElement) == null))
							{
								return xAttribute.Name.LocalName;
							}
							flag2 = true;
						}
					}
					while (xAttribute != xElement.lastAttr);
					flag = flag || flag2;
				}
				xElement = xElement.parent as XElement;
			}
			while (xElement != null);
			if ((object)namespaceName == "http://www.w3.org/XML/1998/namespace")
			{
				if (!flag || GetNamespaceOfPrefixInScope("xml", null) == null)
				{
					return "xml";
				}
			}
			else if ((object)namespaceName == "http://www.w3.org/2000/xmlns/")
			{
				return "xmlns";
			}
			return null;
		}

		public static XElement Load(string uri)
		{
			return Load(uri, LoadOptions.None);
		}

		public static XElement Load(string uri, LoadOptions options)
		{
			XmlReaderSettings xmlReaderSettings = XNode.GetXmlReaderSettings(options);
			using XmlReader reader = XmlReader.Create(uri, xmlReaderSettings);
			return Load(reader, options);
		}

		public static XElement Load(Stream stream)
		{
			return Load(stream, LoadOptions.None);
		}

		public static XElement Load(Stream stream, LoadOptions options)
		{
			XmlReaderSettings xmlReaderSettings = XNode.GetXmlReaderSettings(options);
			using XmlReader reader = XmlReader.Create(stream, xmlReaderSettings);
			return Load(reader, options);
		}

		public static async Task<XElement> LoadAsync(Stream stream, LoadOptions options, CancellationToken cancellationToken)
		{
			XmlReaderSettings xmlReaderSettings = XNode.GetXmlReaderSettings(options);
			xmlReaderSettings.Async = true;
			using XmlReader r = XmlReader.Create(stream, xmlReaderSettings);
			return await LoadAsync(r, options, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public static XElement Load(TextReader textReader)
		{
			return Load(textReader, LoadOptions.None);
		}

		public static XElement Load(TextReader textReader, LoadOptions options)
		{
			XmlReaderSettings xmlReaderSettings = XNode.GetXmlReaderSettings(options);
			using XmlReader reader = XmlReader.Create(textReader, xmlReaderSettings);
			return Load(reader, options);
		}

		public static async Task<XElement> LoadAsync(TextReader textReader, LoadOptions options, CancellationToken cancellationToken)
		{
			XmlReaderSettings xmlReaderSettings = XNode.GetXmlReaderSettings(options);
			xmlReaderSettings.Async = true;
			using XmlReader r = XmlReader.Create(textReader, xmlReaderSettings);
			return await LoadAsync(r, options, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public static XElement Load(XmlReader reader)
		{
			return Load(reader, LoadOptions.None);
		}

		public static XElement Load(XmlReader reader, LoadOptions options)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			if (reader.MoveToContent() != XmlNodeType.Element)
			{
				throw new InvalidOperationException(global::SR.Format("The XmlReader must be on a node of type {0} instead of a node of type {1}.", XmlNodeType.Element, reader.NodeType));
			}
			XElement result = new XElement(reader, options);
			reader.MoveToContent();
			if (!reader.EOF)
			{
				throw new InvalidOperationException("The XmlReader state should be EndOfFile after this operation.");
			}
			return result;
		}

		public static Task<XElement> LoadAsync(XmlReader reader, LoadOptions options, CancellationToken cancellationToken)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled<XElement>(cancellationToken);
			}
			return LoadAsyncInternal(reader, options, cancellationToken);
		}

		private static async Task<XElement> LoadAsyncInternal(XmlReader reader, LoadOptions options, CancellationToken cancellationToken)
		{
			if (await reader.MoveToContentAsync().ConfigureAwait(continueOnCapturedContext: false) != XmlNodeType.Element)
			{
				throw new InvalidOperationException(global::SR.Format("The XmlReader must be on a node of type {0} instead of a node of type {1}.", XmlNodeType.Element, reader.NodeType));
			}
			XElement e = new XElement(default(AsyncConstructionSentry));
			await e.ReadElementFromAsync(reader, options, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			cancellationToken.ThrowIfCancellationRequested();
			await reader.MoveToContentAsync().ConfigureAwait(continueOnCapturedContext: false);
			if (!reader.EOF)
			{
				throw new InvalidOperationException("The XmlReader state should be EndOfFile after this operation.");
			}
			return e;
		}

		public static XElement Parse(string text)
		{
			return Parse(text, LoadOptions.None);
		}

		public static XElement Parse(string text, LoadOptions options)
		{
			using StringReader input = new StringReader(text);
			XmlReaderSettings xmlReaderSettings = XNode.GetXmlReaderSettings(options);
			using XmlReader reader = XmlReader.Create(input, xmlReaderSettings);
			return Load(reader, options);
		}

		public void RemoveAll()
		{
			RemoveAttributes();
			RemoveNodes();
		}

		public void RemoveAttributes()
		{
			if (SkipNotify())
			{
				RemoveAttributesSkipNotify();
				return;
			}
			while (lastAttr != null)
			{
				XAttribute xAttribute = lastAttr.next;
				NotifyChanging(xAttribute, XObjectChangeEventArgs.Remove);
				if (lastAttr == null || xAttribute != lastAttr.next)
				{
					throw new InvalidOperationException("This operation was corrupted by external code.");
				}
				if (xAttribute != lastAttr)
				{
					lastAttr.next = xAttribute.next;
				}
				else
				{
					lastAttr = null;
				}
				xAttribute.parent = null;
				xAttribute.next = null;
				NotifyChanged(xAttribute, XObjectChangeEventArgs.Remove);
			}
		}

		public void ReplaceAll(object content)
		{
			content = XContainer.GetContentSnapshot(content);
			RemoveAll();
			Add(content);
		}

		public void ReplaceAll(params object[] content)
		{
			ReplaceAll((object)content);
		}

		public void ReplaceAttributes(object content)
		{
			content = XContainer.GetContentSnapshot(content);
			RemoveAttributes();
			Add(content);
		}

		public void ReplaceAttributes(params object[] content)
		{
			ReplaceAttributes((object)content);
		}

		public void Save(Stream stream)
		{
			Save(stream, GetSaveOptionsFromAnnotations());
		}

		public void Save(Stream stream, SaveOptions options)
		{
			XmlWriterSettings xmlWriterSettings = XNode.GetXmlWriterSettings(options);
			using XmlWriter writer = XmlWriter.Create(stream, xmlWriterSettings);
			Save(writer);
		}

		public async Task SaveAsync(Stream stream, SaveOptions options, CancellationToken cancellationToken)
		{
			XmlWriterSettings xmlWriterSettings = XNode.GetXmlWriterSettings(options);
			xmlWriterSettings.Async = true;
			using XmlWriter w = XmlWriter.Create(stream, xmlWriterSettings);
			await SaveAsync(w, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public void Save(TextWriter textWriter)
		{
			Save(textWriter, GetSaveOptionsFromAnnotations());
		}

		public void Save(TextWriter textWriter, SaveOptions options)
		{
			XmlWriterSettings xmlWriterSettings = XNode.GetXmlWriterSettings(options);
			using XmlWriter writer = XmlWriter.Create(textWriter, xmlWriterSettings);
			Save(writer);
		}

		public async Task SaveAsync(TextWriter textWriter, SaveOptions options, CancellationToken cancellationToken)
		{
			XmlWriterSettings xmlWriterSettings = XNode.GetXmlWriterSettings(options);
			xmlWriterSettings.Async = true;
			using XmlWriter w = XmlWriter.Create(textWriter, xmlWriterSettings);
			await SaveAsync(w, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
		}

		public void Save(XmlWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			writer.WriteStartDocument();
			WriteTo(writer);
			writer.WriteEndDocument();
		}

		public Task SaveAsync(XmlWriter writer, CancellationToken cancellationToken)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled(cancellationToken);
			}
			return SaveAsyncInternal(writer, cancellationToken);
		}

		private async Task SaveAsyncInternal(XmlWriter writer, CancellationToken cancellationToken)
		{
			await writer.WriteStartDocumentAsync().ConfigureAwait(continueOnCapturedContext: false);
			await WriteToAsync(writer, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
			cancellationToken.ThrowIfCancellationRequested();
			await writer.WriteEndDocumentAsync().ConfigureAwait(continueOnCapturedContext: false);
		}

		public void SetAttributeValue(XName name, object value)
		{
			XAttribute xAttribute = Attribute(name);
			if (value == null)
			{
				if (xAttribute != null)
				{
					RemoveAttribute(xAttribute);
				}
			}
			else if (xAttribute != null)
			{
				xAttribute.Value = XContainer.GetStringValue(value);
			}
			else
			{
				AppendAttribute(new XAttribute(name, value));
			}
		}

		public void SetElementValue(XName name, object value)
		{
			XElement xElement = Element(name);
			if (value == null)
			{
				if (xElement != null)
				{
					RemoveNode(xElement);
				}
			}
			else if (xElement != null)
			{
				xElement.Value = XContainer.GetStringValue(value);
			}
			else
			{
				AddNode(new XElement(name, XContainer.GetStringValue(value)));
			}
		}

		public void SetValue(object value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			Value = XContainer.GetStringValue(value);
		}

		public override void WriteTo(XmlWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			new ElementWriter(writer).WriteElement(this);
		}

		public override Task WriteToAsync(XmlWriter writer, CancellationToken cancellationToken)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled(cancellationToken);
			}
			return new ElementWriter(writer).WriteElementAsync(this, cancellationToken);
		}

		[CLSCompliant(false)]
		public static explicit operator string(XElement element)
		{
			return element?.Value;
		}

		[CLSCompliant(false)]
		public static explicit operator bool(XElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return XmlConvert.ToBoolean(element.Value.ToLowerInvariant());
		}

		[CLSCompliant(false)]
		public static explicit operator bool?(XElement element)
		{
			if (element == null)
			{
				return null;
			}
			return XmlConvert.ToBoolean(element.Value.ToLowerInvariant());
		}

		[CLSCompliant(false)]
		public static explicit operator int(XElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return XmlConvert.ToInt32(element.Value);
		}

		[CLSCompliant(false)]
		public static explicit operator int?(XElement element)
		{
			if (element == null)
			{
				return null;
			}
			return XmlConvert.ToInt32(element.Value);
		}

		[CLSCompliant(false)]
		public static explicit operator uint(XElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return XmlConvert.ToUInt32(element.Value);
		}

		[CLSCompliant(false)]
		public static explicit operator uint?(XElement element)
		{
			if (element == null)
			{
				return null;
			}
			return XmlConvert.ToUInt32(element.Value);
		}

		[CLSCompliant(false)]
		public static explicit operator long(XElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return XmlConvert.ToInt64(element.Value);
		}

		[CLSCompliant(false)]
		public static explicit operator long?(XElement element)
		{
			if (element == null)
			{
				return null;
			}
			return XmlConvert.ToInt64(element.Value);
		}

		[CLSCompliant(false)]
		public static explicit operator ulong(XElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return XmlConvert.ToUInt64(element.Value);
		}

		[CLSCompliant(false)]
		public static explicit operator ulong?(XElement element)
		{
			if (element == null)
			{
				return null;
			}
			return XmlConvert.ToUInt64(element.Value);
		}

		[CLSCompliant(false)]
		public static explicit operator float(XElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return XmlConvert.ToSingle(element.Value);
		}

		[CLSCompliant(false)]
		public static explicit operator float?(XElement element)
		{
			if (element == null)
			{
				return null;
			}
			return XmlConvert.ToSingle(element.Value);
		}

		[CLSCompliant(false)]
		public static explicit operator double(XElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return XmlConvert.ToDouble(element.Value);
		}

		[CLSCompliant(false)]
		public static explicit operator double?(XElement element)
		{
			if (element == null)
			{
				return null;
			}
			return XmlConvert.ToDouble(element.Value);
		}

		[CLSCompliant(false)]
		public static explicit operator decimal(XElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return XmlConvert.ToDecimal(element.Value);
		}

		[CLSCompliant(false)]
		public static explicit operator decimal?(XElement element)
		{
			if (element == null)
			{
				return null;
			}
			return XmlConvert.ToDecimal(element.Value);
		}

		[CLSCompliant(false)]
		public static explicit operator DateTime(XElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return DateTime.Parse(element.Value, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
		}

		[CLSCompliant(false)]
		public static explicit operator DateTime?(XElement element)
		{
			if (element == null)
			{
				return null;
			}
			return DateTime.Parse(element.Value, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind);
		}

		[CLSCompliant(false)]
		public static explicit operator DateTimeOffset(XElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return XmlConvert.ToDateTimeOffset(element.Value);
		}

		[CLSCompliant(false)]
		public static explicit operator DateTimeOffset?(XElement element)
		{
			if (element == null)
			{
				return null;
			}
			return XmlConvert.ToDateTimeOffset(element.Value);
		}

		[CLSCompliant(false)]
		public static explicit operator TimeSpan(XElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return XmlConvert.ToTimeSpan(element.Value);
		}

		[CLSCompliant(false)]
		public static explicit operator TimeSpan?(XElement element)
		{
			if (element == null)
			{
				return null;
			}
			return XmlConvert.ToTimeSpan(element.Value);
		}

		[CLSCompliant(false)]
		public static explicit operator Guid(XElement element)
		{
			if (element == null)
			{
				throw new ArgumentNullException("element");
			}
			return XmlConvert.ToGuid(element.Value);
		}

		[CLSCompliant(false)]
		public static explicit operator Guid?(XElement element)
		{
			if (element == null)
			{
				return null;
			}
			return XmlConvert.ToGuid(element.Value);
		}

		private static object ConvertForAssignment(object value)
		{
			if (!(value is XmlNode node))
			{
				return value;
			}
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.AppendChild(xmlDocument.ImportNode(node, deep: true));
			return Parse(xmlDocument.InnerXml);
		}

		XmlSchema IXmlSerializable.GetSchema()
		{
			return null;
		}

		void IXmlSerializable.ReadXml(XmlReader reader)
		{
			if (reader == null)
			{
				throw new ArgumentNullException("reader");
			}
			if (parent != null || annotations != null || content != null || lastAttr != null)
			{
				throw new InvalidOperationException("This instance cannot be deserialized.");
			}
			if (reader.MoveToContent() != XmlNodeType.Element)
			{
				throw new InvalidOperationException(global::SR.Format("The XmlReader must be on a node of type {0} instead of a node of type {1}.", XmlNodeType.Element, reader.NodeType));
			}
			ReadElementFrom(reader, LoadOptions.None);
		}

		void IXmlSerializable.WriteXml(XmlWriter writer)
		{
			WriteTo(writer);
		}

		internal override void AddAttribute(XAttribute a)
		{
			if (Attribute(a.Name) != null)
			{
				throw new InvalidOperationException("Duplicate attribute.");
			}
			if (a.parent != null)
			{
				a = new XAttribute(a);
			}
			AppendAttribute(a);
		}

		internal override void AddAttributeSkipNotify(XAttribute a)
		{
			if (Attribute(a.Name) != null)
			{
				throw new InvalidOperationException("Duplicate attribute.");
			}
			if (a.parent != null)
			{
				a = new XAttribute(a);
			}
			AppendAttributeSkipNotify(a);
		}

		internal void AppendAttribute(XAttribute a)
		{
			bool num = NotifyChanging(a, XObjectChangeEventArgs.Add);
			if (a.parent != null)
			{
				throw new InvalidOperationException("This operation was corrupted by external code.");
			}
			AppendAttributeSkipNotify(a);
			if (num)
			{
				NotifyChanged(a, XObjectChangeEventArgs.Add);
			}
		}

		internal void AppendAttributeSkipNotify(XAttribute a)
		{
			a.parent = this;
			if (lastAttr == null)
			{
				a.next = a;
			}
			else
			{
				a.next = lastAttr.next;
				lastAttr.next = a;
			}
			lastAttr = a;
		}

		private bool AttributesEqual(XElement e)
		{
			XAttribute xAttribute = lastAttr;
			XAttribute xAttribute2 = e.lastAttr;
			if (xAttribute != null && xAttribute2 != null)
			{
				do
				{
					xAttribute = xAttribute.next;
					xAttribute2 = xAttribute2.next;
					if (xAttribute.name != xAttribute2.name || xAttribute.value != xAttribute2.value)
					{
						return false;
					}
				}
				while (xAttribute != lastAttr);
				return xAttribute2 == e.lastAttr;
			}
			if (xAttribute == null)
			{
				return xAttribute2 == null;
			}
			return false;
		}

		internal override XNode CloneNode()
		{
			return new XElement(this);
		}

		internal override bool DeepEquals(XNode node)
		{
			if (node is XElement xElement && name == xElement.name && ContentsEqual(xElement))
			{
				return AttributesEqual(xElement);
			}
			return false;
		}

		private IEnumerable<XAttribute> GetAttributes(XName name)
		{
			XAttribute a = lastAttr;
			if (a == null)
			{
				yield break;
			}
			do
			{
				a = a.next;
				if (name == null || a.name == name)
				{
					yield return a;
				}
			}
			while (a.parent == this && a != lastAttr);
		}

		private string GetNamespaceOfPrefixInScope(string prefix, XElement outOfScope)
		{
			for (XElement xElement = this; xElement != outOfScope; xElement = xElement.parent as XElement)
			{
				XAttribute xAttribute = xElement.lastAttr;
				if (xAttribute != null)
				{
					do
					{
						xAttribute = xAttribute.next;
						if (xAttribute.IsNamespaceDeclaration && xAttribute.Name.LocalName == prefix)
						{
							return xAttribute.Value;
						}
					}
					while (xAttribute != xElement.lastAttr);
				}
			}
			return null;
		}

		internal override int GetDeepHashCode()
		{
			int hashCode = name.GetHashCode();
			hashCode ^= ContentsHashCode();
			XAttribute xAttribute = lastAttr;
			if (xAttribute != null)
			{
				do
				{
					xAttribute = xAttribute.next;
					hashCode ^= xAttribute.GetDeepHashCode();
				}
				while (xAttribute != lastAttr);
			}
			return hashCode;
		}

		private void ReadElementFrom(XmlReader r, LoadOptions o)
		{
			ReadElementFromImpl(r, o);
			if (!r.IsEmptyElement)
			{
				r.Read();
				ReadContentFrom(r, o);
			}
			r.Read();
		}

		private async Task ReadElementFromAsync(XmlReader r, LoadOptions o, CancellationToken cancellationTokentoken)
		{
			ReadElementFromImpl(r, o);
			if (!r.IsEmptyElement)
			{
				cancellationTokentoken.ThrowIfCancellationRequested();
				await r.ReadAsync().ConfigureAwait(continueOnCapturedContext: false);
				await ReadContentFromAsync(r, o, cancellationTokentoken).ConfigureAwait(continueOnCapturedContext: false);
			}
			cancellationTokentoken.ThrowIfCancellationRequested();
			await r.ReadAsync().ConfigureAwait(continueOnCapturedContext: false);
		}

		private void ReadElementFromImpl(XmlReader r, LoadOptions o)
		{
			if (r.ReadState != ReadState.Interactive)
			{
				throw new InvalidOperationException("The XmlReader state should be Interactive.");
			}
			name = XNamespace.Get(r.NamespaceURI).GetName(r.LocalName);
			if ((o & LoadOptions.SetBaseUri) != LoadOptions.None)
			{
				string baseURI = r.BaseURI;
				if (!string.IsNullOrEmpty(baseURI))
				{
					SetBaseUri(baseURI);
				}
			}
			IXmlLineInfo xmlLineInfo = null;
			if ((o & LoadOptions.SetLineInfo) != LoadOptions.None)
			{
				xmlLineInfo = r as IXmlLineInfo;
				if (xmlLineInfo != null && xmlLineInfo.HasLineInfo())
				{
					SetLineInfo(xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
				}
			}
			if (!r.MoveToFirstAttribute())
			{
				return;
			}
			do
			{
				XAttribute xAttribute = new XAttribute(XNamespace.Get((r.Prefix.Length == 0) ? string.Empty : r.NamespaceURI).GetName(r.LocalName), r.Value);
				if (xmlLineInfo != null && xmlLineInfo.HasLineInfo())
				{
					xAttribute.SetLineInfo(xmlLineInfo.LineNumber, xmlLineInfo.LinePosition);
				}
				AppendAttributeSkipNotify(xAttribute);
			}
			while (r.MoveToNextAttribute());
			r.MoveToElement();
		}

		internal void RemoveAttribute(XAttribute a)
		{
			bool flag = NotifyChanging(a, XObjectChangeEventArgs.Remove);
			if (a.parent != this)
			{
				throw new InvalidOperationException("This operation was corrupted by external code.");
			}
			XAttribute xAttribute = lastAttr;
			XAttribute xAttribute2;
			while ((xAttribute2 = xAttribute.next) != a)
			{
				xAttribute = xAttribute2;
			}
			if (xAttribute == a)
			{
				lastAttr = null;
			}
			else
			{
				if (lastAttr == a)
				{
					lastAttr = xAttribute;
				}
				xAttribute.next = a.next;
			}
			a.parent = null;
			a.next = null;
			if (flag)
			{
				NotifyChanged(a, XObjectChangeEventArgs.Remove);
			}
		}

		private void RemoveAttributesSkipNotify()
		{
			if (lastAttr != null)
			{
				XAttribute xAttribute = lastAttr;
				do
				{
					XAttribute xAttribute2 = xAttribute.next;
					xAttribute.parent = null;
					xAttribute.next = null;
					xAttribute = xAttribute2;
				}
				while (xAttribute != lastAttr);
				lastAttr = null;
			}
		}

		internal void SetEndElementLineInfo(int lineNumber, int linePosition)
		{
			AddAnnotation(new LineInfoEndElementAnnotation(lineNumber, linePosition));
		}

		internal override void ValidateNode(XNode node, XNode previous)
		{
			if (node is XDocument)
			{
				throw new ArgumentException(global::SR.Format("A node of type {0} cannot be added to content.", XmlNodeType.Document));
			}
			if (node is XDocumentType)
			{
				throw new ArgumentException(global::SR.Format("A node of type {0} cannot be added to content.", XmlNodeType.DocumentType));
			}
		}
	}
	internal sealed class XHashtable<TValue>
	{
		public delegate string ExtractKeyDelegate(TValue value);

		private sealed class XHashtableState
		{
			private struct Entry
			{
				public TValue Value;

				public int HashCode;

				public int Next;
			}

			private int[] _buckets;

			private Entry[] _entries;

			private int _numEntries;

			private ExtractKeyDelegate _extractKey;

			public XHashtableState(ExtractKeyDelegate extractKey, int capacity)
			{
				_buckets = new int[capacity];
				_entries = new Entry[capacity];
				_extractKey = extractKey;
			}

			public XHashtableState Resize()
			{
				if (_numEntries < _buckets.Length)
				{
					return this;
				}
				int num = 0;
				for (int i = 0; i < _buckets.Length; i++)
				{
					int num2 = _buckets[i];
					if (num2 == 0)
					{
						num2 = Interlocked.CompareExchange(ref _buckets[i], -1, 0);
					}
					while (num2 > 0)
					{
						if (_extractKey(_entries[num2].Value) != null)
						{
							num++;
						}
						num2 = ((_entries[num2].Next != 0) ? _entries[num2].Next : Interlocked.CompareExchange(ref _entries[num2].Next, -1, 0));
					}
				}
				if (num < _buckets.Length / 2)
				{
					num = _buckets.Length;
				}
				else
				{
					num = _buckets.Length * 2;
					if (num < 0)
					{
						throw new OverflowException();
					}
				}
				XHashtableState xHashtableState = new XHashtableState(_extractKey, num);
				for (int j = 0; j < _buckets.Length; j++)
				{
					for (int num3 = _buckets[j]; num3 > 0; num3 = _entries[num3].Next)
					{
						xHashtableState.TryAdd(_entries[num3].Value, out var _);
					}
				}
				return xHashtableState;
			}

			public bool TryGetValue(string key, int index, int count, out TValue value)
			{
				int hashCode = ComputeHashCode(key, index, count);
				int entryIndex = 0;
				if (FindEntry(hashCode, key, index, count, ref entryIndex))
				{
					value = _entries[entryIndex].Value;
					return true;
				}
				value = default(TValue);
				return false;
			}

			public bool TryAdd(TValue value, out TValue newValue)
			{
				newValue = value;
				string text = _extractKey(value);
				if (text == null)
				{
					return true;
				}
				int num = ComputeHashCode(text, 0, text.Length);
				int num2 = Interlocked.Increment(ref _numEntries);
				if (num2 < 0 || num2 >= _buckets.Length)
				{
					return false;
				}
				_entries[num2].Value = value;
				_entries[num2].HashCode = num;
				Thread.MemoryBarrier();
				int entryIndex = 0;
				while (!FindEntry(num, text, 0, text.Length, ref entryIndex))
				{
					entryIndex = ((entryIndex != 0) ? Interlocked.CompareExchange(ref _entries[entryIndex].Next, num2, 0) : Interlocked.CompareExchange(ref _buckets[num & (_buckets.Length - 1)], num2, 0));
					if (entryIndex <= 0)
					{
						return entryIndex == 0;
					}
				}
				newValue = _entries[entryIndex].Value;
				return true;
			}

			private bool FindEntry(int hashCode, string key, int index, int count, ref int entryIndex)
			{
				int num = entryIndex;
				int num2 = ((num != 0) ? num : _buckets[hashCode & (_buckets.Length - 1)]);
				while (num2 > 0)
				{
					if (_entries[num2].HashCode == hashCode)
					{
						string text = _extractKey(_entries[num2].Value);
						if (text == null)
						{
							if (_entries[num2].Next > 0)
							{
								_entries[num2].Value = default(TValue);
								num2 = _entries[num2].Next;
								if (num == 0)
								{
									_buckets[hashCode & (_buckets.Length - 1)] = num2;
								}
								else
								{
									_entries[num].Next = num2;
								}
								continue;
							}
						}
						else if (count == text.Length && string.CompareOrdinal(key, index, text, 0, count) == 0)
						{
							entryIndex = num2;
							return true;
						}
					}
					num = num2;
					num2 = _entries[num2].Next;
				}
				entryIndex = num;
				return false;
			}

			private static int ComputeHashCode(string key, int index, int count)
			{
				int num = 352654597;
				int num2 = index + count;
				for (int i = index; i < num2; i++)
				{
					num += (num << 7) ^ key[i];
				}
				num -= num >> 17;
				num -= num >> 11;
				num -= num >> 5;
				return num & 0x7FFFFFFF;
			}
		}

		private XHashtableState _state;

		public XHashtable(ExtractKeyDelegate extractKey, int capacity)
		{
			_state = new XHashtableState(extractKey, capacity);
		}

		public bool TryGetValue(string key, int index, int count, out TValue value)
		{
			return _state.TryGetValue(key, index, count, out value);
		}

		public TValue Add(TValue value)
		{
			TValue newValue;
			while (!_state.TryAdd(value, out newValue))
			{
				lock (this)
				{
					XHashtableState state = _state.Resize();
					Thread.MemoryBarrier();
					_state = state;
				}
			}
			return newValue;
		}
	}
	internal struct NamespaceCache
	{
		private XNamespace _ns;

		private string _namespaceName;

		public XNamespace Get(string namespaceName)
		{
			if ((object)namespaceName == _namespaceName)
			{
				return _ns;
			}
			_namespaceName = namespaceName;
			_ns = XNamespace.Get(namespaceName);
			return _ns;
		}
	}
	internal struct ElementWriter(XmlWriter writer)
	{
		private XmlWriter _writer = writer;

		private NamespaceResolver _resolver = default(NamespaceResolver);

		public void WriteElement(XElement e)
		{
			PushAncestors(e);
			XElement xElement = e;
			XNode xNode = e;
			while (true)
			{
				e = xNode as XElement;
				if (e != null)
				{
					WriteStartElement(e);
					if (e.content == null)
					{
						WriteEndElement();
					}
					else
					{
						if (!(e.content is string text))
						{
							xNode = ((XNode)e.content).next;
							continue;
						}
						_writer.WriteString(text);
						WriteFullEndElement();
					}
				}
				else
				{
					xNode.WriteTo(_writer);
				}
				while (xNode != xElement && xNode == xNode.parent.content)
				{
					xNode = xNode.parent;
					WriteFullEndElement();
				}
				if (xNode != xElement)
				{
					xNode = xNode.next;
					continue;
				}
				break;
			}
		}

		public async Task WriteElementAsync(XElement e, CancellationToken cancellationToken)
		{
			PushAncestors(e);
			XElement root = e;
			XNode n = e;
			while (true)
			{
				e = n as XElement;
				if (e == null)
				{
					await n.WriteToAsync(_writer, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				else
				{
					await WriteStartElementAsync(e, cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					if (e.content == null)
					{
						await WriteEndElementAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					}
					else
					{
						if (!(e.content is string text))
						{
							n = ((XNode)e.content).next;
							continue;
						}
						cancellationToken.ThrowIfCancellationRequested();
						await _writer.WriteStringAsync(text).ConfigureAwait(continueOnCapturedContext: false);
						await WriteFullEndElementAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
					}
				}
				while (n != root && n == n.parent.content)
				{
					n = n.parent;
					await WriteFullEndElementAsync(cancellationToken).ConfigureAwait(continueOnCapturedContext: false);
				}
				if (n != root)
				{
					n = n.next;
					continue;
				}
				break;
			}
		}

		private string GetPrefixOfNamespace(XNamespace ns, bool allowDefaultNamespace)
		{
			string namespaceName = ns.NamespaceName;
			if (namespaceName.Length == 0)
			{
				return string.Empty;
			}
			string prefixOfNamespace = _resolver.GetPrefixOfNamespace(ns, allowDefaultNamespace);
			if (prefixOfNamespace != null)
			{
				return prefixOfNamespace;
			}
			if ((object)namespaceName == "http://www.w3.org/XML/1998/namespace")
			{
				return "xml";
			}
			if ((object)namespaceName == "http://www.w3.org/2000/xmlns/")
			{
				return "xmlns";
			}
			return null;
		}

		private void PushAncestors(XElement e)
		{
			while (true)
			{
				e = e.parent as XElement;
				if (e == null)
				{
					break;
				}
				XAttribute xAttribute = e.lastAttr;
				if (xAttribute == null)
				{
					continue;
				}
				do
				{
					xAttribute = xAttribute.next;
					if (xAttribute.IsNamespaceDeclaration)
					{
						_resolver.AddFirst((xAttribute.Name.NamespaceName.Length == 0) ? string.Empty : xAttribute.Name.LocalName, XNamespace.Get(xAttribute.Value));
					}
				}
				while (xAttribute != e.lastAttr);
			}
		}

		private void PushElement(XElement e)
		{
			_resolver.PushScope();
			XAttribute xAttribute = e.lastAttr;
			if (xAttribute == null)
			{
				return;
			}
			do
			{
				xAttribute = xAttribute.next;
				if (xAttribute.IsNamespaceDeclaration)
				{
					_resolver.Add((xAttribute.Name.NamespaceName.Length == 0) ? string.Empty : xAttribute.Name.LocalName, XNamespace.Get(xAttribute.Value));
				}
			}
			while (xAttribute != e.lastAttr);
		}

		private void WriteEndElement()
		{
			_writer.WriteEndElement();
			_resolver.PopScope();
		}

		private async Task WriteEndElementAsync(CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			await _writer.WriteEndElementAsync().ConfigureAwait(continueOnCapturedContext: false);
			_resolver.PopScope();
		}

		private void WriteFullEndElement()
		{
			_writer.WriteFullEndElement();
			_resolver.PopScope();
		}

		private async Task WriteFullEndElementAsync(CancellationToken cancellationToken)
		{
			cancellationToken.ThrowIfCancellationRequested();
			await _writer.WriteFullEndElementAsync().ConfigureAwait(continueOnCapturedContext: false);
			_resolver.PopScope();
		}

		private void WriteStartElement(XElement e)
		{
			PushElement(e);
			XNamespace xNamespace = e.Name.Namespace;
			_writer.WriteStartElement(GetPrefixOfNamespace(xNamespace, allowDefaultNamespace: true), e.Name.LocalName, xNamespace.NamespaceName);
			XAttribute xAttribute = e.lastAttr;
			if (xAttribute != null)
			{
				do
				{
					xAttribute = xAttribute.next;
					xNamespace = xAttribute.Name.Namespace;
					string localName = xAttribute.Name.LocalName;
					string namespaceName = xNamespace.NamespaceName;
					_writer.WriteAttributeString(GetPrefixOfNamespace(xNamespace, allowDefaultNamespace: false), localName, (namespaceName.Length == 0 && localName == "xmlns") ? "http://www.w3.org/2000/xmlns/" : namespaceName, xAttribute.Value);
				}
				while (xAttribute != e.lastAttr);
			}
		}

		private async Task WriteStartElementAsync(XElement e, CancellationToken cancellationToken)
		{
			PushElement(e);
			XNamespace xNamespace = e.Name.Namespace;
			await _writer.WriteStartElementAsync(GetPrefixOfNamespace(xNamespace, allowDefaultNamespace: true), e.Name.LocalName, xNamespace.NamespaceName).ConfigureAwait(continueOnCapturedContext: false);
			XAttribute a = e.lastAttr;
			if (a != null)
			{
				do
				{
					a = a.next;
					xNamespace = a.Name.Namespace;
					string localName = a.Name.LocalName;
					string namespaceName = xNamespace.NamespaceName;
					await _writer.WriteAttributeStringAsync(GetPrefixOfNamespace(xNamespace, allowDefaultNamespace: false), localName, (namespaceName.Length == 0 && localName == "xmlns") ? "http://www.w3.org/2000/xmlns/" : namespaceName, a.Value).ConfigureAwait(continueOnCapturedContext: false);
				}
				while (a != e.lastAttr);
			}
		}
	}
	internal struct NamespaceResolver
	{
		private class NamespaceDeclaration
		{
			public string prefix;

			public XNamespace ns;

			public int scope;

			public NamespaceDeclaration prev;
		}

		private int _scope;

		private NamespaceDeclaration _declaration;

		private NamespaceDeclaration _rover;

		public void PushScope()
		{
			_scope++;
		}

		public void PopScope()
		{
			NamespaceDeclaration namespaceDeclaration = _declaration;
			if (namespaceDeclaration != null)
			{
				do
				{
					namespaceDeclaration = namespaceDeclaration.prev;
					if (namespaceDeclaration.scope != _scope)
					{
						break;
					}
					if (namespaceDeclaration == _declaration)
					{
						_declaration = null;
					}
					else
					{
						_declaration.prev = namespaceDeclaration.prev;
					}
					_rover = null;
				}
				while (namespaceDeclaration != _declaration && _declaration != null);
			}
			_scope--;
		}

		public void Add(string prefix, XNamespace ns)
		{
			NamespaceDeclaration namespaceDeclaration = new NamespaceDeclaration();
			namespaceDeclaration.prefix = prefix;
			namespaceDeclaration.ns = ns;
			namespaceDeclaration.scope = _scope;
			if (_declaration == null)
			{
				_declaration = namespaceDeclaration;
			}
			else
			{
				namespaceDeclaration.prev = _declaration.prev;
			}
			_declaration.prev = namespaceDeclaration;
			_rover = null;
		}

		public void AddFirst(string prefix, XNamespace ns)
		{
			NamespaceDeclaration namespaceDeclaration = new NamespaceDeclaration();
			namespaceDeclaration.prefix = prefix;
			namespaceDeclaration.ns = ns;
			namespaceDeclaration.scope = _scope;
			if (_declaration == null)
			{
				namespaceDeclaration.prev = namespaceDeclaration;
			}
			else
			{
				namespaceDeclaration.prev = _declaration.prev;
				_declaration.prev = namespaceDeclaration;
			}
			_declaration = namespaceDeclaration;
			_rover = null;
		}

		public string GetPrefixOfNamespace(XNamespace ns, bool allowDefaultNamespace)
		{
			if (_rover != null && _rover.ns == ns && (allowDefaultNamespace || _rover.prefix.Length > 0))
			{
				return _rover.prefix;
			}
			NamespaceDeclaration namespaceDeclaration = _declaration;
			if (namespaceDeclaration != null)
			{
				do
				{
					namespaceDeclaration = namespaceDeclaration.prev;
					if (!(namespaceDeclaration.ns == ns))
					{
						continue;
					}
					NamespaceDeclaration prev = _declaration.prev;
					while (prev != namespaceDeclaration && prev.prefix != namespaceDeclaration.prefix)
					{
						prev = prev.prev;
					}
					if (prev == namespaceDeclaration)
					{
						if (allowDefaultNamespace)
						{
							_rover = namespaceDeclaration;
							return namespaceDeclaration.prefix;
						}
						if (namespaceDeclaration.prefix.Length > 0)
						{
							return namespaceDeclaration.prefix;
						}
					}
				}
				while (namespaceDeclaration != _declaration);
			}
			return null;
		}
	}
	public enum XObjectChange
	{
		Add,
		Remove,
		Name,
		Value
	}
	[Flags]
	public enum LoadOptions
	{
		None = 0,
		PreserveWhitespace = 1,
		SetBaseUri = 2,
		SetLineInfo = 4
	}
	[Flags]
	public enum SaveOptions
	{
		None = 0,
		DisableFormatting = 1,
		OmitDuplicateNamespaces = 2
	}
	[Serializable]
	public sealed class XName : IEquatable<XName>, ISerializable
	{
		private XNamespace _ns;

		private string _localName;

		private int _hashCode;

		public string LocalName => _localName;

		public XNamespace Namespace => _ns;

		public string NamespaceName => _ns.NamespaceName;

		internal XName(XNamespace ns, string localName)
		{
			_ns = ns;
			_localName = XmlConvert.VerifyNCName(localName);
			_hashCode = ns.GetHashCode() ^ localName.GetHashCode();
		}

		public override string ToString()
		{
			if (_ns.NamespaceName.Length == 0)
			{
				return _localName;
			}
			return "{" + _ns.NamespaceName + "}" + _localName;
		}

		public static XName Get(string expandedName)
		{
			if (expandedName == null)
			{
				throw new ArgumentNullException("expandedName");
			}
			if (expandedName.Length == 0)
			{
				throw new ArgumentException(global::SR.Format("'{0}' is an invalid expanded name.", expandedName));
			}
			if (expandedName[0] == '{')
			{
				int num = expandedName.LastIndexOf('}');
				if (num <= 1 || num == expandedName.Length - 1)
				{
					throw new ArgumentException(global::SR.Format("'{0}' is an invalid expanded name.", expandedName));
				}
				return XNamespace.Get(expandedName, 1, num - 1).GetName(expandedName, num + 1, expandedName.Length - num - 1);
			}
			return XNamespace.None.GetName(expandedName);
		}

		public static XName Get(string localName, string namespaceName)
		{
			return XNamespace.Get(namespaceName).GetName(localName);
		}

		[CLSCompliant(false)]
		public static implicit operator XName(string expandedName)
		{
			if (expandedName == null)
			{
				return null;
			}
			return Get(expandedName);
		}

		public override bool Equals(object obj)
		{
			return this == obj;
		}

		public override int GetHashCode()
		{
			return _hashCode;
		}

		public static bool operator ==(XName left, XName right)
		{
			return (object)left == right;
		}

		public static bool operator !=(XName left, XName right)
		{
			return (object)left != right;
		}

		bool IEquatable<XName>.Equals(XName other)
		{
			return (object)this == other;
		}

		void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
		{
			throw new PlatformNotSupportedException();
		}
	}
	public sealed class XNamespace
	{
		private static XHashtable<WeakReference> s_namespaces;

		private static WeakReference s_refNone;

		private static WeakReference s_refXml;

		private static WeakReference s_refXmlns;

		private string _namespaceName;

		private int _hashCode;

		private XHashtable<XName> _names;

		public string NamespaceName => _namespaceName;

		public static XNamespace None => EnsureNamespace(ref s_refNone, string.Empty);

		public static XNamespace Xml => EnsureNamespace(ref s_refXml, "http://www.w3.org/XML/1998/namespace");

		public static XNamespace Xmlns => EnsureNamespace(ref s_refXmlns, "http://www.w3.org/2000/xmlns/");

		internal XNamespace(string namespaceName)
		{
			_namespaceName = namespaceName;
			_hashCode = namespaceName.GetHashCode();
			_names = new XHashtable<XName>(ExtractLocalName, 8);
		}

		public XName GetName(string localName)
		{
			if (localName == null)
			{
				throw new ArgumentNullException("localName");
			}
			return GetName(localName, 0, localName.Length);
		}

		public override string ToString()
		{
			return _namespaceName;
		}

		public static XNamespace Get(string namespaceName)
		{
			if (namespaceName == null)
			{
				throw new ArgumentNullException("namespaceName");
			}
			return Get(namespaceName, 0, namespaceName.Length);
		}

		[CLSCompliant(false)]
		public static implicit operator XNamespace(string namespaceName)
		{
			if (namespaceName == null)
			{
				return null;
			}
			return Get(namespaceName);
		}

		public static XName operator +(XNamespace ns, string localName)
		{
			if (ns == null)
			{
				throw new ArgumentNullException("ns");
			}
			return ns.GetName(localName);
		}

		public override bool Equals(object obj)
		{
			return this == obj;
		}

		public override int GetHashCode()
		{
			return _hashCode;
		}

		public static bool operator ==(XNamespace left, XNamespace right)
		{
			return (object)left == right;
		}

		public static bool operator !=(XNamespace left, XNamespace right)
		{
			return (object)left != right;
		}

		internal XName GetName(string localName, int index, int count)
		{
			if (_names.TryGetValue(localName, index, count, out var value))
			{
				return value;
			}
			return _names.Add(new XName(this, localName.Substring(index, count)));
		}

		internal static XNamespace Get(string namespaceName, int index, int count)
		{
			if (count == 0)
			{
				return None;
			}
			if (s_namespaces == null)
			{
				Interlocked.CompareExchange(ref s_namespaces, new XHashtable<WeakReference>(ExtractNamespace, 32), null);
			}
			XNamespace xNamespace;
			do
			{
				if (!s_namespaces.TryGetValue(namespaceName, index, count, out var value))
				{
					if (count == "http://www.w3.org/XML/1998/namespace".Length && string.CompareOrdinal(namespaceName, index, "http://www.w3.org/XML/1998/namespace", 0, count) == 0)
					{
						return Xml;
					}
					if (count == "http://www.w3.org/2000/xmlns/".Length && string.CompareOrdinal(namespaceName, index, "http://www.w3.org/2000/xmlns/", 0, count) == 0)
					{
						return Xmlns;
					}
					value = s_namespaces.Add(new WeakReference(new XNamespace(namespaceName.Substring(index, count))));
				}
				xNamespace = ((value != null) ? ((XNamespace)value.Target) : null);
			}
			while (xNamespace == null);
			return xNamespace;
		}

		private static string ExtractLocalName(XName n)
		{
			return n.LocalName;
		}

		private static string ExtractNamespace(WeakReference r)
		{
			XNamespace xNamespace;
			if (r == null || (xNamespace = (XNamespace)r.Target) == null)
			{
				return null;
			}
			return xNamespace.NamespaceName;
		}

		private static XNamespace EnsureNamespace(ref WeakReference refNmsp, string namespaceName)
		{
			XNamespace xNamespace;
			while (true)
			{
				WeakReference weakReference = refNmsp;
				if (weakReference != null)
				{
					xNamespace = (XNamespace)weakReference.Target;
					if (xNamespace != null)
					{
						break;
					}
				}
				Interlocked.CompareExchange(ref refNmsp, new WeakReference(new XNamespace(namespaceName)), weakReference);
			}
			return xNamespace;
		}
	}
	public abstract class XNode : XObject
	{
		internal XNode next;

		internal XNode()
		{
		}

		public void Remove()
		{
			if (parent == null)
			{
				throw new InvalidOperationException("The parent is missing.");
			}
			parent.RemoveNode(this);
		}

		public override string ToString()
		{
			return GetXmlString(GetSaveOptionsFromAnnotations());
		}

		public abstract void WriteTo(XmlWriter writer);

		public abstract Task WriteToAsync(XmlWriter writer, CancellationToken cancellationToken);

		internal virtual void AppendText(StringBuilder sb)
		{
		}

		internal abstract XNode CloneNode();

		internal abstract bool DeepEquals(XNode node);

		internal IEnumerable<XElement> GetAncestors(XName name, bool self)
		{
			for (XElement e = (self ? this : parent) as XElement; e != null; e = e.parent as XElement)
			{
				if (name == null || e.name == name)
				{
					yield return e;
				}
			}
		}

		internal abstract int GetDeepHashCode();

		internal static XmlReaderSettings GetXmlReaderSettings(LoadOptions o)
		{
			XmlReaderSettings xmlReaderSettings = new XmlReaderSettings();
			if ((o & LoadOptions.PreserveWhitespace) == 0)
			{
				xmlReaderSettings.IgnoreWhitespace = true;
			}
			xmlReaderSettings.DtdProcessing = DtdProcessing.Parse;
			xmlReaderSettings.MaxCharactersFromEntities = 10000000L;
			return xmlReaderSettings;
		}

		internal static XmlWriterSettings GetXmlWriterSettings(SaveOptions o)
		{
			XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
			if ((o & SaveOptions.DisableFormatting) == 0)
			{
				xmlWriterSettings.Indent = true;
			}
			if ((o & SaveOptions.OmitDuplicateNamespaces) != SaveOptions.None)
			{
				xmlWriterSettings.NamespaceHandling |= NamespaceHandling.OmitDuplicates;
			}
			return xmlWriterSettings;
		}

		private string GetXmlString(SaveOptions o)
		{
			using StringWriter stringWriter = new StringWriter(CultureInfo.InvariantCulture);
			XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
			xmlWriterSettings.OmitXmlDeclaration = true;
			if ((o & SaveOptions.DisableFormatting) == 0)
			{
				xmlWriterSettings.Indent = true;
			}
			if ((o & SaveOptions.OmitDuplicateNamespaces) != SaveOptions.None)
			{
				xmlWriterSettings.NamespaceHandling |= NamespaceHandling.OmitDuplicates;
			}
			if (this is XText)
			{
				xmlWriterSettings.ConformanceLevel = ConformanceLevel.Fragment;
			}
			using (XmlWriter writer = XmlWriter.Create(stringWriter, xmlWriterSettings))
			{
				if (this is XDocument xDocument)
				{
					xDocument.WriteContentTo(writer);
				}
				else
				{
					WriteTo(writer);
				}
			}
			return stringWriter.ToString();
		}
	}
	public abstract class XObject : IXmlLineInfo
	{
		internal XContainer parent;

		internal object annotations;

		public string BaseUri
		{
			get
			{
				XObject xObject = this;
				while (true)
				{
					if (xObject != null && xObject.annotations == null)
					{
						xObject = xObject.parent;
						continue;
					}
					if (xObject == null)
					{
						break;
					}
					BaseUriAnnotation baseUriAnnotation = xObject.Annotation<BaseUriAnnotation>();
					if (baseUriAnnotation != null)
					{
						return baseUriAnnotation.baseUri;
					}
					xObject = xObject.parent;
				}
				return string.Empty;
			}
		}

		public abstract XmlNodeType NodeType { get; }

		public XElement Parent => parent as XElement;

		int IXmlLineInfo.LineNumber => Annotation<LineInfoAnnotation>()?.lineNumber ?? 0;

		int IXmlLineInfo.LinePosition => Annotation<LineInfoAnnotation>()?.linePosition ?? 0;

		internal bool HasBaseUri => Annotation<BaseUriAnnotation>() != null;

		internal XObject()
		{
		}

		public void AddAnnotation(object annotation)
		{
			if (annotation == null)
			{
				throw new ArgumentNullException("annotation");
			}
			if (annotations == null)
			{
				annotations = ((!(annotation is object[])) ? annotation : new object[1] { annotation });
				return;
			}
			object[] array = annotations as object[];
			if (array == null)
			{
				annotations = new object[2] { annotations, annotation };
				return;
			}
			int i;
			for (i = 0; i < array.Length && array[i] != null; i++)
			{
			}
			if (i == array.Length)
			{
				Array.Resize(ref array, i * 2);
				annotations = array;
			}
			array[i] = annotation;
		}

		private object AnnotationForSealedType(Type type)
		{
			if (annotations != null)
			{
				if (!(annotations is object[] array))
				{
					if (annotations.GetType() == type)
					{
						return annotations;
					}
				}
				else
				{
					foreach (object obj in array)
					{
						if (obj == null)
						{
							break;
						}
						if (obj.GetType() == type)
						{
							return obj;
						}
					}
				}
			}
			return null;
		}

		public T Annotation<T>() where T : class
		{
			if (annotations != null)
			{
				if (!(annotations is object[] array))
				{
					return annotations as T;
				}
				foreach (object obj in array)
				{
					if (obj == null)
					{
						break;
					}
					if (obj is T result)
					{
						return result;
					}
				}
			}
			return null;
		}

		bool IXmlLineInfo.HasLineInfo()
		{
			return Annotation<LineInfoAnnotation>() != null;
		}

		internal bool NotifyChanged(object sender, XObjectChangeEventArgs e)
		{
			bool result = false;
			XObject xObject = this;
			while (true)
			{
				if (xObject != null && xObject.annotations == null)
				{
					xObject = xObject.parent;
					continue;
				}
				if (xObject == null)
				{
					break;
				}
				XObjectChangeAnnotation xObjectChangeAnnotation = xObject.Annotation<XObjectChangeAnnotation>();
				if (xObjectChangeAnnotation != null)
				{
					result = true;
					if (xObjectChangeAnnotation.changed != null)
					{
						xObjectChangeAnnotation.changed(sender, e);
					}
				}
				xObject = xObject.parent;
			}
			return result;
		}

		internal bool NotifyChanging(object sender, XObjectChangeEventArgs e)
		{
			bool result = false;
			XObject xObject = this;
			while (true)
			{
				if (xObject != null && xObject.annotations == null)
				{
					xObject = xObject.parent;
					continue;
				}
				if (xObject == null)
				{
					break;
				}
				XObjectChangeAnnotation xObjectChangeAnnotation = xObject.Annotation<XObjectChangeAnnotation>();
				if (xObjectChangeAnnotation != null)
				{
					result = true;
					if (xObjectChangeAnnotation.changing != null)
					{
						xObjectChangeAnnotation.changing(sender, e);
					}
				}
				xObject = xObject.parent;
			}
			return result;
		}

		internal void SetBaseUri(string baseUri)
		{
			AddAnnotation(new BaseUriAnnotation(baseUri));
		}

		internal void SetLineInfo(int lineNumber, int linePosition)
		{
			AddAnnotation(new LineInfoAnnotation(lineNumber, linePosition));
		}

		internal bool SkipNotify()
		{
			XObject xObject = this;
			while (true)
			{
				if (xObject != null && xObject.annotations == null)
				{
					xObject = xObject.parent;
					continue;
				}
				if (xObject == null)
				{
					return true;
				}
				if (xObject.Annotation<XObjectChangeAnnotation>() != null)
				{
					break;
				}
				xObject = xObject.parent;
			}
			return false;
		}

		internal SaveOptions GetSaveOptionsFromAnnotations()
		{
			XObject xObject = this;
			object obj;
			while (true)
			{
				if (xObject != null && xObject.annotations == null)
				{
					xObject = xObject.parent;
					continue;
				}
				if (xObject == null)
				{
					return SaveOptions.None;
				}
				obj = xObject.AnnotationForSealedType(typeof(SaveOptions));
				if (obj != null)
				{
					break;
				}
				xObject = xObject.parent;
			}
			return (SaveOptions)obj;
		}
	}
	internal class XObjectChangeAnnotation
	{
		internal EventHandler<XObjectChangeEventArgs> changing;

		internal EventHandler<XObjectChangeEventArgs> changed;
	}
	public class XObjectChangeEventArgs : EventArgs
	{
		private XObjectChange _objectChange;

		public static readonly XObjectChangeEventArgs Add = new XObjectChangeEventArgs(XObjectChange.Add);

		public static readonly XObjectChangeEventArgs Remove = new XObjectChangeEventArgs(XObjectChange.Remove);

		public static readonly XObjectChangeEventArgs Name = new XObjectChangeEventArgs(XObjectChange.Name);

		public static readonly XObjectChangeEventArgs Value = new XObjectChangeEventArgs(XObjectChange.Value);

		public XObjectChangeEventArgs(XObjectChange objectChange)
		{
			_objectChange = objectChange;
		}
	}
	public class XProcessingInstruction : XNode
	{
		internal string target;

		internal string data;

		public string Data
		{
			get
			{
				return data;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				bool num = NotifyChanging(this, XObjectChangeEventArgs.Value);
				data = value;
				if (num)
				{
					NotifyChanged(this, XObjectChangeEventArgs.Value);
				}
			}
		}

		public override XmlNodeType NodeType => XmlNodeType.ProcessingInstruction;

		public string Target => target;

		public XProcessingInstruction(string target, string data)
		{
			if (data == null)
			{
				throw new ArgumentNullException("data");
			}
			ValidateName(target);
			this.target = target;
			this.data = data;
		}

		public XProcessingInstruction(XProcessingInstruction other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			target = other.target;
			data = other.data;
		}

		public override void WriteTo(XmlWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			writer.WriteProcessingInstruction(target, data);
		}

		public override Task WriteToAsync(XmlWriter writer, CancellationToken cancellationToken)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled(cancellationToken);
			}
			return writer.WriteProcessingInstructionAsync(target, data);
		}

		internal override XNode CloneNode()
		{
			return new XProcessingInstruction(this);
		}

		internal override bool DeepEquals(XNode node)
		{
			if (node is XProcessingInstruction xProcessingInstruction && target == xProcessingInstruction.target)
			{
				return data == xProcessingInstruction.data;
			}
			return false;
		}

		internal override int GetDeepHashCode()
		{
			return target.GetHashCode() ^ data.GetHashCode();
		}

		private static void ValidateName(string name)
		{
			XmlConvert.VerifyNCName(name);
			if (string.Equals(name, "xml", StringComparison.OrdinalIgnoreCase))
			{
				throw new ArgumentException(global::SR.Format("'{0}' is an invalid name for a processing instruction.", name));
			}
		}
	}
	public class XStreamingElement
	{
		internal XName name;

		internal object content;
	}
	public class XText : XNode
	{
		internal string text;

		public override XmlNodeType NodeType => XmlNodeType.Text;

		public string Value
		{
			get
			{
				return text;
			}
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				bool num = NotifyChanging(this, XObjectChangeEventArgs.Value);
				text = value;
				if (num)
				{
					NotifyChanged(this, XObjectChangeEventArgs.Value);
				}
			}
		}

		public XText(string value)
		{
			if (value == null)
			{
				throw new ArgumentNullException("value");
			}
			text = value;
		}

		public XText(XText other)
		{
			if (other == null)
			{
				throw new ArgumentNullException("other");
			}
			text = other.text;
		}

		public override void WriteTo(XmlWriter writer)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			if (parent is XDocument)
			{
				writer.WriteWhitespace(text);
			}
			else
			{
				writer.WriteString(text);
			}
		}

		public override Task WriteToAsync(XmlWriter writer, CancellationToken cancellationToken)
		{
			if (writer == null)
			{
				throw new ArgumentNullException("writer");
			}
			if (cancellationToken.IsCancellationRequested)
			{
				return Task.FromCanceled(cancellationToken);
			}
			if (!(parent is XDocument))
			{
				return writer.WriteStringAsync(text);
			}
			return writer.WriteWhitespaceAsync(text);
		}

		internal override void AppendText(StringBuilder sb)
		{
			sb.Append(text);
		}

		internal override XNode CloneNode()
		{
			return new XText(this);
		}

		internal override bool DeepEquals(XNode node)
		{
			if (node != null && NodeType == node.NodeType)
			{
				return text == ((XText)node).text;
			}
			return false;
		}

		internal override int GetDeepHashCode()
		{
			return text.GetHashCode();
		}
	}
}
namespace System.Text
{
	internal static class StringBuilderCache
	{
		[ThreadStatic]
		private static StringBuilder t_cachedInstance;

		public static StringBuilder Acquire(int capacity = 16)
		{
			if (capacity <= 360)
			{
				StringBuilder stringBuilder = t_cachedInstance;
				if (stringBuilder != null && capacity <= stringBuilder.Capacity)
				{
					t_cachedInstance = null;
					stringBuilder.Clear();
					return stringBuilder;
				}
			}
			return new StringBuilder(capacity);
		}

		public static void Release(StringBuilder sb)
		{
			if (sb.Capacity <= 360)
			{
				t_cachedInstance = sb;
			}
		}

		public static string GetStringAndRelease(StringBuilder sb)
		{
			string result = sb.ToString();
			Release(sb);
			return result;
		}
	}
}
