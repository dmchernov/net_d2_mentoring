using System;

namespace Entities
{
	public class FilePart
	{
		public Guid FileIdentifier { get; set; }
		public int Part { get; set; }
		public bool IsLastPart { get; set; }
		public byte[] Content { get; set; }
		public string FileName { get; set; }
	}
}
