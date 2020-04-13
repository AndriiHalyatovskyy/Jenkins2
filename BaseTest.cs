using Jenkins2.Tests;
using NUnit.Framework;
using OpenQA.Selenium;

[assembly: LevelOfParallelism(3)]
namespace Jenkins2
{
	public abstract class BaseTest
	{
		private IWebDriver _driver;
		private Pages.Pages _pages;
		protected IWebDriver Driver
		{
			get
			{
				if (_driver == null)
				{
					_driver = BuildConfiguration.GetDriver();
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
