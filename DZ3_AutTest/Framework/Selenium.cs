using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace DZ3_AutTest.Framework
{
    public class Selenium
    {
        public static IWebDriver GetDriver(Drivers drivers)
        {
            switch (drivers)
            {
                case Drivers.Chrome:
                    default:
                    return GetChromeDriver();
            }
            
        }

        private static IWebDriver GetChromeDriver()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = Settings.ImplicitWait;
            return driver;
        }
    }
    public enum Drivers
    {
        Chrome
    }
}