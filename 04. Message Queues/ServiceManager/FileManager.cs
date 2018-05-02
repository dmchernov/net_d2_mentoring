using Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ServiceManager
{
	public class FileManager
	{
		private readonly string _directoryPath;
		private readonly string _tempDir = Path.Combine(Directory.GetCurrentDirectory(), "tmp");
		private IDictionary<Guid, string> _processingFiles = new Dictionary<Guid, string>();
		private const string STATE_FILE_NAME = "state.dat";

		public FileManager(string directoryPath = null)
		{
			_directoryPath = directoryPath ?? Path.Combine(Directory.GetCurrentDirectory(), "Files");
			CreateFileDirectory();
			LoadState();
		}

		private void CreateFileDirectory()
		{
			if (!Directory.Exists(_directoryPath))
				Directory.CreateDirectory(_directoryPath);

			if (!Directory.Exists(_tempDir))
				Directory.CreateDirectory(_tempDir);
		}

		public void SaveFilePart(FilePart part)
		{
			var filePath = CreateLocalFilePath(part);
			TryCreateFile(filePath);

			AddProcessingFile(part, filePath);

			using (var stream = new FileStream(filePath, FileMode.Append))
			{
				stream.Write(part.Content, 0, part.Content.Length);
			}

			if (part.IsLastPart)
			{
				RemoveProcessingFile(part);
				MoveCompletedFile(filePath);
				SaveState();
			}
		}

		private void AddProcessingFile(FilePart part, string localPath)
		{
			_processingFiles[part.FileIdentifier] = localPath;
			SaveState();
		}

		private string CreateLocalFilePath(FilePart part)
		{
			if (_processingFiles.ContainsKey(part.FileIdentifier))
				return _processingFiles[part.FileIdentifier];

			var path = Path.Combine(_tempDir, part.FileName);
			return GenerateUniqueFileName(path);
		}

		private string GenerateUniqueFileName(string localFilePath)
		{
			if (!File.Exists(localFilePath))
				return localFilePath;

			var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(localFilePath);
			var extension = Path.GetExtension(localFilePath);
			var i = 1;
			while (true)
			{
				var newName = Path.Combine(_tempDir, fileNameWithoutExtension + i + extension);
				if (!File.Exists(newName))
					return newName;
				i++;
			}
		}

		private void TryCreateFile(string filePath)
		{
			if (!File.Exists(filePath))
			{
				var s = File.Create(filePath);
				s.Close();
			}
		}

		private void RemoveProcessingFile(FilePart part)
		{
			if (_processingFiles.ContainsKey(part.FileIdentifier))
				_processingFiles.Remove(part.FileIdentifier);
		}

		private void MoveCompletedFile(string filePath)
		{
			var destination = Path.Combine(_directoryPath, Path.GetFileName(filePath) ?? String.Empty);
			File.Move(filePath, destination);
		}

		private void LoadState()
		{
			if (!File.Exists(STATE_FILE_NAME))
				return;

			var formatter = new BinaryFormatter();
			using (FileStream fs = new FileStream(STATE_FILE_NAME, FileMode.Open))
			{
				_processingFiles = (IDictionary<Guid, string>)formatter.Deserialize(fs);
			}
		}

		private void SaveState()
		{
			var formatter = new BinaryFormatter();
			using (FileStream fs = new FileStream(STATE_FILE_NAME, FileMode.OpenOrCreate))
			{
				formatter.Serialize(fs, _processingFiles);
			}
		}
	}
}
