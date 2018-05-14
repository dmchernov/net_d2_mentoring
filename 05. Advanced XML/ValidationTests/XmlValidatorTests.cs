using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Schema;
using Library;
using NUnit.Framework;

namespace ValidationTests
{
	[TestFixture]
	public class XmlValidatorTests
	{
		private string XsdPath => Path.Combine(TestContext.CurrentContext.TestDirectory, @"Data\books.xsd");
		private string ValidXmlPath => Path.Combine(TestContext.CurrentContext.TestDirectory, @"Data\books.xml");
		private string InvalidIsbnXmlPath => Path.Combine(TestContext.CurrentContext.TestDirectory, @"Data\books_invalid_isbn.xml");
		private string InvalidIdXmlPath => Path.Combine(TestContext.CurrentContext.TestDirectory, @"Data\books_invalid_id.xml");
		private string InvalidGenreXmlPath => Path.Combine(TestContext.CurrentContext.TestDirectory, @"Data\books_invalid_genre.xml");
		private string InvalidDatesXmlPath => Path.Combine(TestContext.CurrentContext.TestDirectory, @"Data\books_invalid_dates.xml");

		[Test]
		public void Validate_ValidXml_ReturnsEmptyErrorCollection()
		{
			var validator = GetValidator();
			var errors = validator.Validate(ValidXmlPath, XsdPath, "http://library.by/catalog");

			Assert.IsEmpty(errors);
		}

		[Test]
		public void Validate_InvalidIsbn_ReturnsError()
		{
			var validator = GetValidator();
			var errors = validator.Validate(InvalidIsbnXmlPath, XsdPath, "http://library.by/catalog");

			PrintErrors(errors);

			Assert.NotNull(errors.FirstOrDefault(e => e.Message.Contains("isbn")));
		}

		[Test]
		public void Validate_InvalidId_ReturnsError()
		{
			var validator = GetValidator();
			var errors = validator.Validate(InvalidIdXmlPath, XsdPath, "http://library.by/catalog");

			PrintErrors(errors);

			Assert.NotNull(errors.FirstOrDefault(e => e.Message.Contains("ID")));
		}

		[Test]
		public void Validate_InvalidGenre_ReturnsError()
		{
			var validator = GetValidator();
			var errors = validator.Validate(InvalidGenreXmlPath, XsdPath, "http://library.by/catalog");

			PrintErrors(errors);

			Assert.NotNull(errors.FirstOrDefault(e => e.Message.Contains("genre")));
		}

		[Test]
		public void Validate_InvalidDates_ReturnsError()
		{
			var validator = GetValidator();
			var errors = validator.Validate(InvalidDatesXmlPath, XsdPath, "http://library.by/catalog");

			PrintErrors(errors);

			Assert.NotNull(errors.FirstOrDefault(e => e.Message.Contains("date")));
		}

		private XmlValidator GetValidator()
		{
			return new XmlValidator();
		}

		private void PrintErrors(IList<XmlSchemaException> errors)
		{
			foreach (var xmlSchemaException in errors)
			{
				Console.WriteLine($"Line :{xmlSchemaException.LineNumber}");
				Console.WriteLine($"Position :{xmlSchemaException.LinePosition}");
				Console.WriteLine($"Message :{xmlSchemaException.Message}");
				Console.WriteLine(String.Empty.PadLeft(20, '-'));
			}
		}
	}
}
