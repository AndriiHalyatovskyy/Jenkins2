﻿using NUnit.Framework;

namespace Jenkins2.Tests
{
	[Parallelizable]
	public class SecondTest : BaseTest
	{
		[Test]
		public void testMethod()
		{
			Pages.Goole.DoSearch("Youtube");
			Pages.SearchResult.OpenSiteByTitle("Youtube");
			Assert.True(true);
		}
	}
}
