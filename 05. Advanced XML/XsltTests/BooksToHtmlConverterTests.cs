using System;
using System.IO;
using Library;
using NUnit.Framework;

namespace XsltTests
{
	[TestFixture]
	public class BooksToHtmlConverterTests
	{
		private string BooksXmlPath => Path.Combine(TestContext.CurrentContext.TestDirectory, @"XML\books.xml");
		private string BooksToHtmlXsltPath => Path.Combine(TestContext.CurrentContext.TestDirectory, @"XSLT\BooksToHtml.xslt");
		private string HtmlPath => @"Report.html";

		[TearDown]
		public void Clean()
		{
			if (File.Exists(HtmlPath))
				File.Delete(HtmlPath);
		}

		[Test]
		public void CreateReport_BooksSample_WritesToDiskHtmlFileWithContent()
		{
			var c = new BooksToHtmlConverter();
			c.CreateReport(BooksXmlPath, BooksToHtmlXsltPath, HtmlPath);
			var content = File.ReadAllText(HtmlPath);
			Console.WriteLine(content);
		}
	}
}
