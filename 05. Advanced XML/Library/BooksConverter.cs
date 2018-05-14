using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace Library
{
	public class BooksConverter
	{
		public string Convert(string booksXmlPath, string xsltPath)
		{
			var result = new StringBuilder();

			var xslt = new XslCompiledTransform();
			xslt.Load(xsltPath, new XsltSettings(true, true), new XmlUrlResolver());
			XPathDocument xPathDocument = new XPathDocument(booksXmlPath);
			XmlTextWriter writer = new XmlTextWriter(new StringWriter(result))
			{
				Formatting = Formatting.Indented
			};

			xslt.Transform(xPathDocument, null, writer, null);

			return result.ToString();
		}
	}
}
