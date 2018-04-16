using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using NUnit.Framework;

namespace ExpressionTree
{
	[TestFixture]
	public class MyVisitorTests
	{
		[Test]
		public void IncrementTest()
		{
			Expression<Func<int, int>> source = a => a + (a + 1) * (a + 5) * (a + 1);
			var result = new MyVisitor().VisitAndConvert(source, "");

			Console.WriteLine(source + " " + source.Compile().Invoke(3));
			Console.WriteLine(result + " " + result?.Compile().Invoke(3));
		}

		[Test]
		public void DecrementTest()
		{
			Expression<Func<int, int>> source = a => a + (a - 1) * (a + 5) * (a - 1);
			var result = new MyVisitor().VisitAndConvert(source, "");

			Console.WriteLine(source + " " + source.Compile().Invoke(3));
			Console.WriteLine(result + " " + result?.Compile().Invoke(3));
		}

		[Test]
		public void ParameterCollectionIntTest_Int()
		{
			Expression<Func<int, int>> expression = a => a * 10 + a - a * 3;
			var values = new Dictionary<string, object>{["a"] = 1};

			var result = new MyVisitor(values).Visit(expression) as LambdaExpression;

			Console.WriteLine(expression + " " + expression.Compile().Invoke(1));
			Console.WriteLine(result + " " + result?.Compile().DynamicInvoke());
		}

		[Test]
		public void ParameterCollectionStringTest_Int()
		{
			Expression<Func<string, string, string>> expression = (a, b) => String.Concat(a, b);
			var values = new Dictionary<string, object>{["a"] = "str1", ["b"] = "str2"};

			var result = new MyVisitor(values).Visit(expression) as LambdaExpression;

			Console.WriteLine(expression + " " + expression.Compile().Invoke("str1", "str2"));
			Console.WriteLine(result + " " + result?.Compile().DynamicInvoke());
		}

		[Test]
		public void ParameterCollectionStringIntTest_Int()
		{
			Expression<Func<int, string, string>> expression = (a, b) => a.ToString().ToUpper() + b.ToLower();
			var values = new Dictionary<string, object>{["a"] = 12345, ["b"] = "STRING"};

			var result = new MyVisitor(values).Visit(expression) as LambdaExpression;

			Console.WriteLine(expression + " " + expression.Compile().Invoke(12345, "STRING"));
			Console.WriteLine(result + " " + result?.Compile().DynamicInvoke());
		}

		[Test]
		public void ParameterCollectionTest_String()
		{
			Expression<Func<string, string>> expression = a => a.ToUpper();
			var values = new Dictionary<string, object>{["a"] = "aaa"};

			var result = new MyVisitor(values).Visit(expression) as LambdaExpression;

			Console.WriteLine(expression + " " + expression.Compile().Invoke("aaa"));
			Console.WriteLine(result + " " + result?.Compile().DynamicInvoke());
		}
	}
}
