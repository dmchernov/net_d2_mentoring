namespace KeyGen
{
	internal sealed class Converter
	{
		public byte[] Bytes { private get; set; }

		public int Convert(byte a, int b)
		{
			return a ^ Bytes[b];
		}
	}
}
