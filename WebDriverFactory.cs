using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;

namespace Jenkins2
{
	public class WebDriverFactory
	{

		public static IWebDriver GetDriver(Browsers browser)
		{
			switch (browser)
			{
				case Browsers.Chrome:
					return new ChromeDriver();
				case Browsers.Firefox:
					return new FirefoxDriver();
				case Browsers.IE:
					return new InternetExplorerDriver();
				default:
					return new ChromeDriver();
			}
		}
	}

	public enum Browsers
	{
		Chrome,
		Firefox,
		IE
	}

}
