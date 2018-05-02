using System;
using System.IO;

namespace ClientApplication
{
	public class Presenter
	{
		private readonly ClientForm _view;
		private readonly Model _model;

		public Presenter(ClientForm view, Model model)
		{
			_view = view;
			_model = model;
		}

		public async void SendFile(string filePath)
		{
			try
			{
				using (File.Open(filePath, FileMode.Open))
				{
				}

				await _model.SendFile(filePath);
				_view.ShowMessage($"File {Path.GetFileName(filePath)} has been sent to server");
			}
			catch (InvalidOperationException ex)
			{
				_view.ShowMessage(ex.Message);
			}
			catch (Exception ex)
			{
				_view.ShowMessage(ex.ToString());
			}
		}
	}
}
