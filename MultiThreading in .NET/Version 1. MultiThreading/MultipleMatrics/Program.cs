using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace MultipleMatrics
{
	class Program
	{
		static void Main(string[] args)
		{
			var matrixHelper = new MatrixHelper();
			var matrix1 = matrixHelper.GetRandomMatrix();
			var matrix2 = matrixHelper.GetRandomMatrix();

			var matrix1AsString = matrixHelper.GetMatrixAsString(matrix1);
			Console.WriteLine("Matrix1:");
			Console.WriteLine(matrix1AsString);

			var matrix2AsString = matrixHelper.GetMatrixAsString(matrix2);
			Console.WriteLine("Matrix2:");
			Console.WriteLine(matrix2AsString);

			var multipleMatrixParallel = matrixHelper.MultipleMatrix(matrix1, matrix2);
			var multipleMatrixParallelAsString = matrixHelper.GetMatrixAsString(multipleMatrixParallel);
			Console.WriteLine("Multiple:");
			Console.WriteLine(multipleMatrixParallelAsString);

			Console.ReadLine();
		}
	}
}
