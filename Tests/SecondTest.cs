using NUnit.Allure.Core;
using NUnit.Framework;

namespace Jenkins2.Tests
{
	[TestFixture]
	[AllureNUnit]
	public class SecondTest : BaseTest
	{
		[Test]
		public void SecondTestMethod()
		{
			Pages.Goole.DoSearch("Youtube");
			Pages.SearchResult.OpenSiteByTitle("Youtube");
			Assert.True(true, "SecondTestMethod failed line 13");
		}
	}
}
