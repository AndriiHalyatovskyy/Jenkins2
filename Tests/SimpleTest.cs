using NUnit.Framework;

namespace Jenkins2.Tests
{
	public class SimpleTest : BaseTest
	{
		[SetUp]
		public void SetupTest()
		{
		}

		[TearDown]
		public void TeardownTest()
		{
		}

		[Test]
		public void WikiTest()
		{
			Pages.Goole.DoSearch("wikipedia");
			Pages.SearchResult.OpenSiteByTitle("wikipedia");
			Assert.IsTrue(Pages.Wikipedia.getPageTitle().ToLower().Contains("Wikipedia".ToLower()));
			Assert.True(Pages.Wikipedia.getCurrentURL().Contains("wikipedia"));
		}
	}
}
