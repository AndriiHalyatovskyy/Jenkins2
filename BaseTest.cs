using Allure.Commons;
using Jenkins2.Tests;
using log4net.Core;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Reflection.Emit;
using System.Runtime.ExceptionServices;

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

			Environment.SetEnvironmentVariable(
			   AllureConstants.ALLURE_CONFIG_ENV_VARIABLE,
			   Path.Combine(Environment.CurrentDirectory, AllureConstants.CONFIG_FILENAME));

			Logger.Logger.InitLogger();
			SetOutputLogFileName(TestContext.CurrentContext.Test.ClassName);
		}

		[SetUp]
		public void SetUp()
		{
			Logger.Logger.GetLogger.Info($"Test {TestContext.CurrentContext.Test.MethodName} started from {TestContext.CurrentContext.Test.ClassName}");
			TakeVideo($"{TestContext.CurrentContext.Test.ClassName}_{TestContext.CurrentContext.Test.Name}");
		}


		[TearDown]
		public void TearDown()
		{
			Logger.Logger.GetLogger.Info($"Test {TestContext.CurrentContext.Test.MethodName} finished with status " +
				$"{TestContext.CurrentContext.Result.Outcome.Status}, Message: {TestContext.CurrentContext.Result.Message}");

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
