using OpenQA.Selenium;
using static Jenkins2.Pages.YouTube;

namespace Jenkins2.Pages
{
	public class YouTube : APage<YoutubeSelectors>
	{
		public YouTube(Pages p) : base(p, new YoutubeSelectors())
		{

		}

		public void doSearch(string name)
		{
			page.switchToDefault();
			page.TypeText(selectors.searchInput, name);
			page.Click(selectors.searchButton);
		}

		public bool isSearchPresent()
		{
			return page.IsElementPresent(selectors.searchInput);
		}

		public class YoutubeSelectors
		{
			public By searchInput = By.Id("search");
			public By searchButton = By.Id("search-icon-legacy");
		}

	}
}
