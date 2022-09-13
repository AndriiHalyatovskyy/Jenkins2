using Jenkins2.DTO;
using Jenkins2.Readers;
using NUnit.Allure.Core;
using NUnit.Framework;
using System.Collections.Generic;

namespace Jenkins2.Tests
{
	[TestFixture]
	[AllureNUnit]
	public class FirstTest : BaseTest
	{
		private readonly string jsonFile = "SearchText.json";

		[Test]
		public void WikiTest()
		{
			Pages.Google.DoSearch("wikipedia");
			Pages.SearchResult.OpenSiteByTitle("wikipedia");
			Assert.IsTrue(Pages.Wikipedia.GetTitleText().ToLower().Contains("wikipedia"), "WikiTest failed");
		}

		[Test]
		public void GoogleSearchTest()
		{
			Pages.Google.DoSearch("test");
			Assert.True(true, "GoogleSeatchTest failed");
		}

		[Test]
		public void FailedTest()
		{
			Pages.Google.DoSearch("Fail");
			Assert.True(false, "Expect True, but was false");
		}

		[Test]
		public void SearchTest()
        {
			var searchTextArray = JsonReader.ReadFile<List<SearchTextDTO>>(jsonFile);
			foreach (var searchText in searchTextArray)
			{
				Pages.Google.DoSearch(searchText.Text);
				Pages.Google.WaitForText(searchText.Text);
			}
        }
	}
}
