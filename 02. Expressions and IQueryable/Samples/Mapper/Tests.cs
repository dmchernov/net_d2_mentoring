using System;
using NUnit.Framework;

namespace Mapper
{
    [TestFixture]
    public class Tests
    {
        [Test]
        public void Test()
        {
            var mapGenerator = new MappingGenerator();
            var mapper = mapGenerator.Generate<Class1, Class2>();

            var result = mapper.Map(new Class1());

            Console.WriteLine(result.GetType());
        }
    }
}