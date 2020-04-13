using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Jenkins2
{
	public abstract class WebDriverFactory
	{

		public static IWebDriver GetDriver(string browser)
		{
			switch (browser.ToLower())
			{
				case "chrome":
					return new ChromeDriver();
				case "firefox":
					return new FirefoxDriver();
				case "ie":
					return new InternetExplorerDriver();
				default:
					return new ChromeDriver();
			}
		}
	}
}
