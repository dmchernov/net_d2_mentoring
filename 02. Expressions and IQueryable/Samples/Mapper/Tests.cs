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

        [Test]
        public void MapActionTest()
        {
            var mapper = new MappingGenerator().Generate<Class1, Class2>();
            var c2 = mapper.Map(new Class1 {A = "A", B = "B", C = DateTime.Today});
            foreach (var propertyInfo in c2.GetType().GetProperties())
            {
                Console.WriteLine($"{propertyInfo.Name} = '{propertyInfo.GetValue(c2)}'");
            }
        }
    }
}
