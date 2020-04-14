using Jenkins2.Tests;
using log4net;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Reflection;

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


		[OneTimeSetUp]
		public void OneTimeSetupTest()
		{
			Logger.Logger.InitLogger();
		}

		[SetUp]
		public void SetUp()
		{
			//Logger.Logger.GetLogger.Error(this.GetType().UnderlyingSystemType.Name);
			Logger.Logger.GetLogger.Error("My Message");
		}

		[OneTimeTearDown]
		public void FixtureTeardownTest()
		{
			if (_driver != null)
				_driver.Quit();
		}
	}
}
