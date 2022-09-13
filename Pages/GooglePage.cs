using OpenQA.Selenium;
using static Jenkins2.Pages.GooglePage;

namespace Jenkins2.Pages
{
	public class GooglePage : APage<GoogleSelectors>
	{
		public GooglePage(Pages p) : base(p, new GoogleSelectors())
		{
		}

		/// <summary>
		/// Searches specified information
		/// </summary>
		/// <param name="text">searched information</param>
		public void DoSearch(string text)
		{
			page.TypeText(Selectors.searchInput, text);
			page.SubmitForm(selectors.searchInput);
		}

		public void WaitForText(string text)
        {
			page.WaitForElementPresent(selectors.Anything(text));
        }

		public class GoogleSelectors
		{
			public readonly By searchInput = By.Name("q");
			public readonly By searchButton = By.Name("btnK");
			public By Anything(string text) => By.XPath($"//*[* = '{text}']");
		}
	}
}
