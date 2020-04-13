using NUnit.Framework;

namespace Jenkins2.Tests
{
	public class ThirdTest : BaseTest
	{
		[Test]
		public void ThirdTestMethod()
		{
			Pages.Goole.DoSearch("wikipedia");
			Pages.SearchResult.OpenSiteByTitle("wikipedia");
			Assert.IsTrue(Pages.Wikipedia.GetTitleText().ToLower().Contains("Wikipedia".ToLower()), "ThirdTestMethod failed line 12");
			Assert.True(Pages.Wikipedia.GetTitleText().ToLower().Contains("wiki"), "ThirdTestMethod failed line 13");
		}
	}
}
