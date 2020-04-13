using OpenQA.Selenium;
using static Jenkins2.Pages.YouTubePage;

namespace Jenkins2.Pages
{
	public class YouTubePage : APage<YoutubeSelectors>
	{
		public YouTubePage(Pages p) : base(p, new YoutubeSelectors())
		{

		}

		/// <summary>
		/// Searches specified video
		/// </summary>
		/// <param name="name">searched information</param>
		public void DoSearch(string name)
		{
			page.SwitchToDefault();
			page.TypeText(selectors.searchInput, name);
			page.Click(selectors.searchButton);
		}

		public class YoutubeSelectors
		{
			public By searchInput = By.Id("search");
			public By searchButton = By.Id("search-icon-legacy");
		}

	}
}
