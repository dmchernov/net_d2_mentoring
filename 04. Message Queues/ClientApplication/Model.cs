using Entities;
using Microsoft.ServiceBus.Messaging;
using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using QueueHelper;

namespace ClientApplication
{
	public class Model
	{
		private readonly QueueClient _queueClient;

		public Model()
		{
			var helper = new ServiceBusHelper();
			_queueClient = helper.GetFileTransferQueueClientPeekLock();
		}
		public async Task SendFile(string filePath)
		{
			await Task.Factory.StartNew(() => SendFileToQueue(filePath));
		}

		private void SendFileToQueue(string filePath)
		{
			ConfigurationManager.RefreshSection("appSettings");
			int partSize;
			if (!Int32.TryParse(ConfigurationManager.AppSettings["partSize"], out partSize))
				if (partSize == 0) partSize = 1048576;

			int maxFileSize;
			if (!Int32.TryParse(ConfigurationManager.AppSettings["maxFileSize"], out maxFileSize))
				if (maxFileSize == 0) maxFileSize = 10000000;

			var guid = Guid.NewGuid();
			var content = File.ReadAllBytes(filePath);
			if (content.Length > maxFileSize)
				throw new InvalidOperationException("File is very large");

			var partCount = content.Length % partSize == 0 ? content.Length / partSize : content.Length / partSize + 1;
			for (int i = 0; i < partCount; i++)
			{
				var bytesToSend = content.Skip(i * partSize).Take(partSize).ToArray();
				var filePart = new FilePart
				{
					FileIdentifier = guid,
					Content = bytesToSend,
					FileName = Path.GetFileName(filePath),
					Part = i + 1,
					IsLastPart = i + 1 == partCount
				};
				_queueClient.Send(new BrokeredMessage(filePart));
			}
		}
	}
}
