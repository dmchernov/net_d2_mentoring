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
        public void ParameterCollectionTest_Int()
        {
            Expression<Func<int, int>> expression = a => a * 2 + a - a * 3;
            var values = new Dictionary<string, object>{["a"] = 1};

            var result = new MyVisitor(values).VisitAndConvert(expression, "");

            Console.WriteLine(expression + " " + expression.Compile().Invoke(3));
            Console.WriteLine(result + " " + result?.Compile().Invoke(3));
        }

        [Test]
        public void ParameterCollectionTest_IntWithoutParameters()
        {
            Expression<Func<int>> expression = () => 2 * 2 + 2 - 2 * 3;
            var values = new Dictionary<string, object>{["a"] = 1};

            var result = new MyVisitor(values).VisitAndConvert(expression, "");

            Console.WriteLine(expression + " " + expression.Compile().Invoke());
            Console.WriteLine(result + " " + result?.Compile().Invoke());
        }

        [Test]
        public void ParameterCollectionTest_String()
        {
            Expression<Func<string, string>> expression = a => a.ToUpper();
            var values = new Dictionary<string, object>{["a"] = "aaa"};

            var result = new MyVisitor(values).VisitAndConvert(expression, "");

            Console.WriteLine(expression + " " + expression.Compile().Invoke("aaa"));
            Console.WriteLine(result + " " + result?.Compile().Invoke("aaa"));
        }
    }
}
