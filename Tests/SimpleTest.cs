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
		public void ACL_UploadToFilterOrganizeProfileTemplateBTest()
		{
			Page.Goole.DoSearch("wikipedia");
			Page.SearchResult.OpenSiteByTitle("wikipedia");
			Assert.IsTrue(Page.Wikipedia.getTitleText().Contains("Wikipedia"));
		}
	}
}
