using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace Jenkins2.Pages
{
	public class Pages
	{
		public IWebDriver driver;
		public WebDriverWait Wait;

		private Google google;
		private SearchResult searchResult;
		private Wikipedia wikipedia;

		private const int defaultWait = 20;

		public Pages(IWebDriver driver)
		{
			this.driver = driver;
			Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(defaultWait));
		}

		public Google Goole
		{
			get { return google ?? (google = new Google(this)); }
		}

		public SearchResult SearchResult
		{
			get { return searchResult ?? (searchResult = new SearchResult(this)); }
		}

		public Wikipedia Wikipedia
		{
			get { return wikipedia ?? (wikipedia = new Wikipedia(this)); }
		}

		public IWebElement Click(By element, ScrollOptions scroll = ScrollOptions.none, int scrollDistance = 50, bool scrollToTop = false)
		{
			WaitForElementPresent(element);
			if (scroll != ScrollOptions.none)
				ScrollToElement(element, scroll, scrollDistance, scrollToTop);
			WaitForEnabled(element);
			return JustClick(element);
		}

		public IWebElement JustClick(By element)
		{
			var el = driver.FindElement(element);
			el.Click();
			return el;
		}

		public void ClickByPartialName(By element, string name)
		{
			IWebElement res = null;
			WaitForElementPresent(element);
			var el = getElements(element);
			foreach (IWebElement elem in el)
			{
				if (elem.Text.ToLower().Contains(name.ToLower()))
				{
					res = elem;
					break;
				}
			}

			if (res != null)
			{
				res.Click();
			}
		}

		public string getElementText(By element)
		{
			WaitForElementPresent(element);
			return driver.FindElement(element).Text;
		}

		public string getPageURL()
		{
			return driver.Url;
		}

		public string getPageTitle()
		{
			return driver.Title;
		}

		public void WaitForElementPresent(By element)
		{
			try
			{
				Wait.Until(ExpectedConditions.ElementExists(element));
			}
			catch
			{
			}
		}

		public void WaitForEnabled(params By[] elements)
		{
			foreach (var element in elements)
			{
				try
				{
					Wait.Until(ExpectedConditions.ElementToBeClickable(element));
				}
				catch
				{
				}
			}
		}

		public void ScrollToElement(By element, ScrollOptions scrollOption = ScrollOptions.none, int amountToScrollPast = 30, bool scrollToTop = false)
		{
			try
			{
				WaitForElementPresent(element); //just wait for present since it's not in view in IE if it isn't visible.
			}
			catch { }
			if (scrollOption == ScrollOptions.none)
			{
				((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0," + (driver.FindElement(element).Location.Y) + ");");
			}
			else if (scrollOption == ScrollOptions.up)
			{
				((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0," + (driver.FindElement(element).Location.Y - amountToScrollPast) + ");");
			}
			else if (scrollOption == ScrollOptions.down)
			{
				((IJavaScriptExecutor)driver).ExecuteScript("window.scrollTo(0," + (driver.FindElement(element).Location.Y + amountToScrollPast) + ");");
			}
			else if (scrollOption == ScrollOptions.intoView)
			{
				((IJavaScriptExecutor)driver).ExecuteScript($"arguments[0].scrollIntoView({scrollToTop.ToString().ToLower()});"); //scrollIntoView(true) brakes search results page
			}
		}

		public ReadOnlyCollection<IWebElement> getElements(By selector)
		{
			return driver.FindElements(selector);
		}

		public void TypeText(By element, string text, bool clear = true)
		{
			WaitForElementPresent(element);
			if (clear)
			{
				Clear(element);
			}
			driver.FindElement(element).SendKeys(text);
		}

		public void Clear(By element)
		{
			driver.FindElement(element).Clear();
		}

		public enum ScrollOptions
		{
			none,
			up,
			down,
			intoView
		}
	}
}
