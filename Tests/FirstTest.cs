﻿using NUnit.Framework;

namespace Jenkins2.Tests
{
	[TestFixture]
	public class FirstTest : BaseTest
	{

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

		[Test]
		public void FailedTest()
		{
			Pages.Goole.DoSearch("Fail");
			Assert.True(false, "Expect True, but was false");
		}
	}
}
