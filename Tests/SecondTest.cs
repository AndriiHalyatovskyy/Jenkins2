using NUnit.Framework;

namespace Jenkins2.Tests
{
	[Parallelizable]
	[TestFixture(Browsers.Chrome)]
	[TestFixture(Browsers.Firefox)]
	[TestFixture(Browsers.IE)]
	public class SecondTest : BaseTest
	{
		public SecondTest(Browsers browser) : base(browser)
		{

		}
		
		[Test]
		public void testMethod()
		{
			Pages.Goole.DoSearch("Youtube");
			Pages.SearchResult.OpenSiteByTitle("Youtube");
			Assert.True(true);
		}
	}
}
