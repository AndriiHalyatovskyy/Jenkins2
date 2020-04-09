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
			Pages.Goole.DoSearch("wikipedia");
			Pages.SearchResult.OpenSiteByTitle("wikipedia");
			Assert.IsTrue(Pages.Wikipedia.getTitleText().Contains("English"));
		}
	}
}
