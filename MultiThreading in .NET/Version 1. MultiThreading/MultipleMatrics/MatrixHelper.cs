using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultipleMatrics
{
	public class MatrixHelper
	{
		private object _lockObj = new object();
		public int[,] GetRandomMatrix()
		{
			Thread.Sleep(50);
			var random = new Random();
			var matrix = new int[10, 10];
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					matrix[i, j] = random.Next(1, 9);
				}
			}

			return matrix;
		}

		public string GetMatrixAsString(int[,] matrix)
		{
			var sb = new StringBuilder();
			for (int i = 0; i < matrix.GetLength(0); i++)
			{
				for (int j = 0; j < matrix.GetLength(1); j++)
				{
					sb.Append($"{matrix[i, j], 5}");
				}

				sb.AppendLine();
			}

			return sb.ToString();
		}

		public int[,] MultipleMatrix(int[,] matrix1, int[,] matrix2)
		{
			var result = new int[matrix1.GetLength(0), matrix2.GetLength(1)];
			Parallel.For(0, matrix1.GetLength(0), i =>
			{
				Parallel.For(0, matrix2.GetLength(1), j =>
				{
					result[i,j] = CalculateMatrixValue(matrix1, matrix2, i, j);
				});
			});
			return result;
		}

		private int CalculateMatrixValue(int[,] matrix1, int[,] matrix2, int rowNumber, int columnNumber)
		{
			int result = 0;
			Parallel.For(0, matrix1.GetLength(0), (i) =>
			{
				lock (_lockObj)
				{
					result += matrix1[rowNumber, i] * matrix2[i, columnNumber];
				}
			});
			return result;
		}
	}
}
