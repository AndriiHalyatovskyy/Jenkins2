﻿using OpenQA.Selenium;
using static Jenkins2.Pages.Wikipedia;

namespace Jenkins2.Pages
{
	public class Wikipedia : APage<WikipediaSelectors>
	{
		public Wikipedia(Pages p) : base(p, new WikipediaSelectors())
		{
		}

		public string getTitleText()
		{
			return page.getElementText(selectors.logoTitle);
		}

		public string getCurrentURL()
		{
			return page.getPageTitle();
		}

		public string getPageTitle()
		{
			return page.getPageTitle();
		}

		public class WikipediaSelectors
		{
			public readonly By logoTitle = By.CssSelector("#central-textlogo-wrapper div");

		}
	}
}
