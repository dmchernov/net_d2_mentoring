using System;
using System.Threading;
using System.Threading.Tasks;
using Entities;
using Microsoft.ServiceBus.Messaging;

namespace ServiceManager
{
	public class Receiver
	{
		private readonly FileManager _fileManager;
		private CancellationToken _cancellationToken;
		private QueueClient _client;

		public Receiver(FileManager manager)
		{
			_fileManager = manager;
		}

		public async Task Run(CancellationToken cancellation)
		{
			_cancellationToken = cancellation;
			_cancellationToken.Register(StopListening);
			await Task.Factory.StartNew(Start, _cancellationToken);
		}

		private void Start()
		{
			_client = QueueClient.Create("files");

			OnMessageOptions options = new OnMessageOptions
			{
				AutoComplete = false,
				AutoRenewTimeout = TimeSpan.FromMinutes(1)
			};
			options.ExceptionReceived += LogErrors;

			_client.OnMessage(OnMessageReceived, options);
		}

		private void LogErrors(object sender, ExceptionReceivedEventArgs e)
		{
			Console.WriteLine(e.Exception);
		}

		private void OnMessageReceived(BrokeredMessage message)
		{
			if (_cancellationToken.IsCancellationRequested)
			{
				message?.Abandon();
				return;
			}

			try
			{
				if (message != null)
				{
					var receivedPart = message.GetBody<FilePart>();
					_fileManager.SaveFilePart(receivedPart);
					message.Complete();
				}
			}
			catch
			{
				message?.Abandon();
			}
		}

		private void StopListening()
		{
			//_client.Close();
		}
	}
}
