using NUnit.Framework;

namespace Jenkins2.Tests
{
	[TestFixture]
	public class FirstTest : BaseTest
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
			Assert.IsTrue(Pages.Wikipedia.GetTitleText().ToLower().Contains("wikipedia"), "WikiTest failed");
		}

		[Test]
		public void GoogleSeatchTest()
		{
			Pages.Goole.DoSearch("test");
			Assert.True(true, "GoogleSeatchTest failed");
		}
	}
}
