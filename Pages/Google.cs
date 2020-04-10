using OpenQA.Selenium;
using static Jenkins2.Pages.Google;

namespace Jenkins2.Pages
{
	public class Google : APage<GoogleSelectors>
	{
		public Google(Pages p) : base(p, new GoogleSelectors())
		{
		}

		public void DoSearch(string text)
		{
			page.TypeText(Selectors.searchInput, text);
			page.submitForm(selectors.searchInput);
			//page.Click(selectors.searchButton);
		}

		public class GoogleSelectors
		{
			public readonly By searchInput = By.Name("q");
			public readonly By searchButton = By.Name("btnK");
		}
	}
}
