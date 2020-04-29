using Jenkins2.Tests;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace Jenkins2
{
	public abstract class BaseTest : Helper
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
					_driver.Manage().Window.Maximize();
					_driver.Url = "https://www.google.com/";
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
			//Logger.Logger.GetLogger.Error(NUnit.Framework.TestContext.CurrentContext);
			TakeVideo($"{TestContext.CurrentContext.Test.ClassName}_{TestContext.CurrentContext.Test.Name}");
		}

		[TearDown]
		public void TearDown()
		{
			StopRecording(TestContext.CurrentContext);
			if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
			{
				TakeScreenshot(_driver, $"{TestContext.CurrentContext.Test.ClassName}_{TestContext.CurrentContext.Test.Name}");				
			}
		}

		[OneTimeTearDown]
		public void FixtureTeardownTest()
		{
			if (_driver != null)
				_driver.Quit();
		}
	}
}
