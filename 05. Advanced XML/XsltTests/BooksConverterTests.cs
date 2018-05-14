using System;
using System.IO;
using Library;
using NUnit.Framework;

namespace XsltTests
{
	[TestFixture]
	public class BooksConverterTests
	{
		private string BooksXmlPath => Path.Combine(TestContext.CurrentContext.TestDirectory, @"XML\books.xml");
		private string BooksToRssXsltPath => Path.Combine(TestContext.CurrentContext.TestDirectory, @"XSLT\BooksToRss.xslt");

		[Test]
		public void Convert_BooksSample_ReturnsRssContent()
		{
			var converter = GetConverter();
			var result = converter.Convert(BooksXmlPath, BooksToRssXsltPath);
			Console.WriteLine(result);
		}

		private BooksConverter GetConverter()
		{
			return new BooksConverter();
		}
	}
}
