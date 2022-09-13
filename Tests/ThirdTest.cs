using NUnit.Allure.Core;
using NUnit.Framework;

namespace Jenkins2.Tests
{
	[TestFixture]
	[AllureNUnit]
	public class ThirdTest : BaseTest
	{
		[Test]
		public void ThirdTestMethod()
		{
			Pages.Google.DoSearch("wikipedia");
			Pages.SearchResult.OpenSiteByTitle("wikipedia");
			Assert.IsTrue(Pages.Wikipedia.GetTitleText().ToLower().Contains("Wikipedia".ToLower()), "ThirdTestMethod failed line 12");
			Assert.True(Pages.Wikipedia.GetTitleText().ToLower().Contains("wiki"), "ThirdTestMethod failed line 13");
		}
	}
}
