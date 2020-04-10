using NUnit.Framework;
using OpenQA.Selenium;

namespace Jenkins2
{
	public abstract class BaseTest
	{
		private IWebDriver _driver;
		private Pages.Pages _pages;
		private Browsers _browser;

		public BaseTest(Browsers browser)
		{
			_browser = browser;
		}
		protected IWebDriver Driver
		{
			get
			{
				if (_driver == null)
				{
					_driver = WebDriverFactory.GetDriver(_browser);
					_driver.Url = "https://www.google.com/";
					_driver.Manage().Window.Maximize();
				}
				return _driver;
			}
		}

		protected Pages.Pages Pages => _pages ?? (_pages = new Pages.Pages(
				driver: Driver));


		[OneTimeTearDown]
		public void FixtureTeardownTest()
		{
			if (_driver != null)
				_driver.Quit();
		}
	}
}
