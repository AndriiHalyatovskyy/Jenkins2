using NUnit.Framework;

namespace Jenkins2.Tests
{
	[Parallelizable]
	public class ThirdTest : BaseTest
	{
		[Test]
		public void TestMethod()
		{
			Pages.Goole.DoSearch("wikipedia");
			Pages.SearchResult.OpenSiteByTitle("wikipedia");
			Assert.IsTrue(Pages.Wikipedia.getPageTitle().ToLower().Contains("Wikipedia".ToLower()));
			Assert.True(Pages.Wikipedia.getPageTitle().ToLower().Contains("wiki"));
		}
	}
}
