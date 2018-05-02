using System.Reflection;
using System.Threading.Tasks;
using ClientApplication;
using NUnit.Framework;

namespace Tests
{
	public class ClientModelTests
	{
		[Test]
		public void Send()
		{
			var model = new Model();
			var task = model.SendFile(Assembly.GetExecutingAssembly().Location);
			Task.WaitAll(task);
		}
	}
}
