using NUnit.Framework;

namespace Jenkins2.Tests
{
	[Parallelizable]
	[TestFixture(Browsers.Chrome)]
	[TestFixture(Browsers.Firefox)]
	[TestFixture(Browsers.IE)]
	public class ThirdTest : BaseTest
	{
		public ThirdTest(Browsers browser) : base(browser)
		{

		}
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
