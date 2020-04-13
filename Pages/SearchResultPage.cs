using OpenQA.Selenium;
using static Jenkins2.Pages.SearchResultPage;

namespace Jenkins2.Pages
{
	public class SearchResultPage : APage<SearchResultSelectors>
	{
		public SearchResultPage(Pages p) : base(p, new SearchResultSelectors())
		{
		}

		/// <summary>
		/// Opens first site from google search result page which header contains specified value
		/// </summary>
		/// <param name="name"> Words which should be present on header</param>
		public void OpenSiteByTitle(string name)
		{
			page.ClickByPartialName(selectors.resultBlockTitle, name);
		}



		public class SearchResultSelectors
		{
			public readonly By resultBlock = By.ClassName("g");
			public readonly By resultBlockTitle = By.CssSelector(".g h3");
			public readonly By resultBlockLink = By.CssSelector(".g a");
			public readonly By resultBlockDescription = By.ClassName("st");
		}
	}
}
