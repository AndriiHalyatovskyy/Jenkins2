using NUnit.Framework;

namespace Jenkins2.Tests
{
	[Parallelizable]
	[TestFixture(Browsers.Chrome)]
	[TestFixture(Browsers.Firefox)]
	[TestFixture(Browsers.IE)]
	public class SimpleTest : BaseTest
	{
		public SimpleTest(Browsers browser) : base(browser)
		{

		}
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
			Assert.True(Pages.Wikipedia.getPageTitle().ToLower().Contains("wiki"));
		}
	}
}
