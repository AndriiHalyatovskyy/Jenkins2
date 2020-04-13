using NUnit.Framework;

namespace Jenkins2.Tests
{
	public class ThirdTest : BaseTest
	{
		[Test]
		public void TestMethod()
		{
			Pages.Goole.DoSearch("wikipedia");
			Pages.SearchResult.OpenSiteByTitle("wikipedia");
			Assert.IsTrue(Pages.Wikipedia.GetTitleText().ToLower().Contains("Wikipedia".ToLower()));
			Assert.True(Pages.Wikipedia.GetTitleText().ToLower().Contains("wiki"));
		}
	}
}
