using System;
using System.IO;
using System.Xml.Serialization;
using Entities;
using NUnit.Framework;

namespace Tests
{
	[TestFixture]
	public class SettingsTest
	{
		[Test]
		public void WriteTest()
		{
			var settings = new Settings {PartSize = 1000000, MaxFileSize = 10000000};
			var serializer = new XmlSerializer(typeof(Settings));
			using (StringWriter textWriter = new StringWriter())
			{
				serializer.Serialize(textWriter, settings);
				Console.WriteLine(textWriter.ToString());

				
			}
		}
	}
}