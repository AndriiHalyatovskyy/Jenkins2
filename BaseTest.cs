using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Jenkins2
{
	public abstract class BaseTest
	{
		private IWebDriver driver;
		private Pages.Pages _page;

		protected IWebDriver Driver
		{
			get
			{
				if (driver == null)
				{
					DesiredCapabilities capabilities = new DesiredCapabilities();

					driver = new ChromeDriver();
					driver.Url = "https://www.google.com/";
					driver.Manage().Window.Maximize();

				}
				return driver;
			}
		}

		protected Pages.Pages Page => _page ?? (_page = new Pages.Pages(
				driver: Driver));


		[OneTimeTearDown]
		public void FixtureTeardownTest()
		{
			if (driver != null)
				driver.Quit();
		}
	}
}
