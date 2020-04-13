using OpenQA.Selenium;
using System.Configuration;

namespace Jenkins2.Tests
{
	public static class BuildConfiguration
	{
		public static string Browser => Read("Browser");

		public static IWebDriver GetDriver() => WebDriverFactory.GetDriver(Browser);
		private static string Read(string key) => ConfigurationManager.AppSettings[key];

	}
}
