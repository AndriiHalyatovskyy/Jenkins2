using OpenQA.Selenium;
using static Jenkins2.Pages.SearchResult;

namespace Jenkins2.Pages
{
	public class SearchResult : APage<SearchResultSelectors>
	{
		public SearchResult(Pages p) : base(p, new SearchResultSelectors())
		{
		}


		public void OpenSiteByTitle(string name)
		{
			page.ClickByPartialName(selectors.resultBlockTitle, name);
		}

		public void OpenSiteByDescription(string name)
		{
			page.ClickByPartialName(selectors.resultBlockDescription, name);
		}
		public class SearchResultSelectors
		{
			public readonly By resultBlock = By.ClassName("g");
			public readonly By resultBlockTitle = By.CssSelector(".g h3");
			public readonly By resultBlockLink = By.CssSelector(".gn link");
			public readonly By resultBlockDescription = By.ClassName("st");
		}
	}
}
