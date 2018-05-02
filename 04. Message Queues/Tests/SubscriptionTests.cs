using NUnit.Framework;
using QueueHelper;

namespace Tests
{
	class SubscriptionTests
	{
		[Test]
		public void CreateTest()
		{
			var helper = new ServiceBusHelper();
			helper.CreateSubscription("testsubscription");
		}

		[Test]
		public void DeleteTest()
		{
			var helper = new ServiceBusHelper();
			helper.DeleteSubscription("testsubscription");
		}
	}
}
