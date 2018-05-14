using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;

namespace Library
{
	public class XmlValidator
	{
		public IList<XmlSchemaException> Validate(string xmlPath, string xsdPath, string ns)
		{
			XmlReaderSettings settings = new XmlReaderSettings();
			var schemas = new XmlSchemaSet();
			schemas.Add(ns, xsdPath);
			settings.Schemas = schemas;
			settings.ValidationType = ValidationType.Schema;
			IList<XmlSchemaException> errors = new List<XmlSchemaException>();
			settings.ValidationEventHandler += (sender, args) =>
			{
				if(args.Severity == XmlSeverityType.Error)
					errors.Add(args.Exception);
			};

			using(var stream = File.OpenRead(xmlPath))
			{
				XmlReader reader = XmlReader.Create(stream, settings);
				XDocument.Load(reader);
				return errors;
			}
		}
	}
}
