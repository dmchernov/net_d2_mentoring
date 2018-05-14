using System.IO;

namespace Library
{
	public class BooksToHtmlConverter
	{
		public void CreateReport(string booksXmlFilePath, string booksToHtmlXsltFilePath, string htmlFilePath)
		{
			var converter = new BooksConverter();
			var content = converter.Convert(booksXmlFilePath, booksToHtmlXsltFilePath);
			File.WriteAllText(htmlFilePath, content);
		}
	}
}
