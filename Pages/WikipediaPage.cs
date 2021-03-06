﻿using OpenQA.Selenium;
using static Jenkins2.Pages.WikipediaPage;

namespace Jenkins2.Pages
{
	public class WikipediaPage : APage<WikipediaSelectors>
	{
		public WikipediaPage(Pages p) : base(p, new WikipediaSelectors())
		{
		}

		/// <summary>
		/// Returns text of title
		/// </summary>
		public string GetTitleText()
		{
			return page.GetPageTitle();
		}

		public class WikipediaSelectors
		{
			public readonly By logoTitle = By.CssSelector(".central-textlogo__image.svg-Wikipedia_wordmark");
			public readonly By allSite = By.Id("www-wikipedia-org");
		}
	}
}
