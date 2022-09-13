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

		private GooglePage google;
		private SearchResultPage searchResult;
		private WikipediaPage wikipedia;
		private YouTubePage youtube;

		private const int defaultWait = 20;

		public Pages(IWebDriver driver)
		{
			this.driver = driver;
			Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(defaultWait));
		}

		/// <summary>
		/// Google home page
		/// </summary>
		public GooglePage Google
		{
			get { return google ?? (google = new GooglePage(this)); }
		}

		/// <summary>
		/// Google search page
		/// </summary>
		public SearchResultPage SearchResult
		{
			get { return searchResult ?? (searchResult = new SearchResultPage(this)); }
		}

		/// <summary>
		/// Wikipedia home page
		/// </summary>
		public WikipediaPage Wikipedia
		{
			get { return wikipedia ?? (wikipedia = new WikipediaPage(this)); }
		}

		/// <summary>
		/// YouTube home page
		/// </summary>
		public YouTubePage YouTube
		{
			get { return youtube ?? (youtube = new YouTubePage(this)); }
		}

		/// <summary>
		/// Waits for element to be present and visible and then clicks it
		/// </summary>
		/// <param name="element"></param>
		/// <param name="scroll"></param>
		/// <param name="scrollDistance"></param>
		/// <param name="scrollToTop"></param>
		public IWebElement Click(By element, ScrollOptions scroll = ScrollOptions.none, int scrollDistance = 50, bool scrollToTop = false)
		{
			WaitForElementPresent(element);
			if (scroll != ScrollOptions.none)
				ScrollToElement(element, scroll, scrollDistance, scrollToTop);
			WaitForEnabled(element);
			return JustClick(element);
		}

		/// <summary>
		/// Just clicks an element. Does not wait for it to be present and visible.
		/// </summary>
		/// <param name="element"></param>
		public IWebElement JustClick(By element)
		{
			var el = driver.FindElement(element);
			el.Click();
			return el;
		}

		/// <summary>
		/// Clicks an element whichinner text contains specified value
		/// </summary>
		/// <param name="element"></param>
		/// <param name="name"></param>
		public void ClickByPartialName(By element, string name)
		{
			IWebElement res = null;
			WaitForElementPresent(element);
			var el = GetElements(element);
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

		/// <summary>
		/// Returns inner text of element
		/// </summary>
		/// <param name="element"></param>
		public string GetElementText(By element)
		{
			WaitForElementPresent(element);
			return driver.FindElement(element).Text;
		}

		/// <summary>
		/// Waits untill element is not present on page
		/// </summary>
		/// <param name="element"></param>
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

		/// <summary>
		/// Swithes driver to first frame on page
		/// </summary>
		public void SwitchToDefault()
		{
			driver.SwitchTo().DefaultContent();
		}

		/// <summary>
		/// Waits for the element to be enabled and clickable
		/// </summary>
		/// <param name="elements"></param>
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

		public string GetPageTitle()
		{
			return driver.Title;
		}

		/// <summary>
		/// Attempts to use javascript to scroll to a particular element
		/// </summary>
		/// <param name="element">By element</param>
		/// <param name="scrollOption">Scroll option</param>
		/// <param name="amountToScrollPast">Scroll past the element by 30 pixels in the indicated direction (to avoid floating elements)</param>
		/// <param name="scrollToTop">true = scroll to top, false (default) = scroll to bottom</param>
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

		/// <summary>
		/// Returns all elements which was finded by selector
		/// </summary>
		/// <param name="selector"></param>
		public ReadOnlyCollection<IWebElement> GetElements(By selector)
		{
			return driver.FindElements(selector);
		}

		/// <summary>
		/// Types specified text into input
		/// </summary>
		/// <param name="element"></param>
		/// <param name="text"></param>
		/// <param name="clear"></param>
		public void TypeText(By element, string text, bool clear = true)
		{
			WaitForElementPresent(element);
			if (clear)
			{
				Clear(element);
			}
			driver.FindElement(element).SendKeys(text);
		}

		/// <summary>
		/// Sends information from form to server
		/// </summary>
		/// <param name="by"></param>
		public void SubmitForm(By by)
		{
			driver.FindElement(by).Submit();
		}

		/// <summary>
		/// Checks if element is present
		/// </summary>
		/// <param name="by"></param>
		public bool IsElementPresent(By by)
		{
			try
			{
				driver.FindElement(by);
				return true;
			}
			catch (NoSuchElementException)
			{
				return false;
			}
			catch (NoSuchWindowException)
			{
				return false;
			}
		}

		/// <summary>
		/// Clears input
		/// </summary>
		/// <param name="element"></param>
		public void Clear(By element)
		{
			driver.FindElement(element).Clear();
		}


		/// <summary>
		/// Fails test. Throws 'AssertionException' with a specified fail message.
		/// </summary>
		/// <param name="failMessage">Message to be displayed in test results.</param>
		public void FailIt(string failMessage)
		{
			throw new Exception(failMessage);
		}

		/// <summary>
		/// Returns the text of the given element
		/// </summary>
		/// <param name="element"></param>
		/// <param name="hidden">Defaults to false - if true will return the innerHtml instead of the text that webdriver gets by default.</param>
		/// <returns></returns>
		public string GetText(By element, bool hidden = false)
		{
			WaitForElementPresent(element);
			if (!hidden)
			{
				return driver.FindElement(element).GetCssValue("value");
			}
			else
			{
				return driver.FindElement(element).GetAttribute("innerHTML");
			}
		}

		/// <summary>
		/// Waits for text of an element
		/// </summary>
		/// <param name="element"> the element to look for</param>
		/// <param name="text"> text to look for</param>
		/// <param name="trim">trim off newlines and spaces</param>
		/// <param name="waitTime">Time in seconds to wait for the text</param>
		/// <param name="contains">Enter true to make search be a contains search</param>
		/// <param name="toLower">Makes the result lowercase for comparison</param>
		public void WaitForText(By element, string text, bool trim = true, int waitTime = defaultWait, bool contains = false, bool toLower = false, bool hidden = false)
		{
			string actual = string.Empty;
			//use Wait.Timeout unless a value is passed in.
			if (waitTime == defaultWait)
			{
				waitTime = Convert.ToInt32(Wait.Timeout.TotalSeconds);
			}
			var startTime = DateTime.Now;
			for (int second = 0; ; second++)
			{
				if ((DateTime.Now - startTime).TotalSeconds >= waitTime && second > 1)
					FailIt("Timed out in WaitForText(" + element.ToString() + ", \nExpected: " + text + "\nBut was: " + actual + ");");
				try
				{
					actual = string.Empty;
					actual = GetText(element, hidden);
					IWebElement el = driver.FindElement(element);
					if (trim)
						actual = actual.Trim();
					if (toLower)
						actual = actual.ToLower();

					if (contains)
					{
						if (actual.Contains(text)) break;
					}
					else
					{
						if (text == actual) break;
					}
				}
				catch (Exception)
				{ }
			}
		}

		/// <summary>
		/// Options for scroll direction
		/// </summary>
		public enum ScrollOptions
		{
			none,
			up,
			down,
			intoView
		}
	}
}
