using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DZ3_AutTest.Tests
{
    [TestFixture]
    public class BaseTest
    {
        private readonly IWebDriver driver;
        private static readonly string url = "http://automationpractice.com/index.php";
        private static readonly TimeSpan implicitWait = TimeSpan.FromSeconds(5);
        private WebDriverWait wait;
        public BaseTest()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = implicitWait;
            driver.Navigate().GoToUrl(url);
        }
        static void Main (string[] args)
        {
            
        }
        [OneTimeTearDown]
        public void OneTimeTearDown() => driver.Quit();
        
        [Test]
       
        [TestCase(true,"dress")]
        [TestCase(false,"qwe134")]
        public void SearchCorrect(bool isCorrect, string searchString)
        {
            driver.FindElement(By.Id("search_query_top")).SendKeys(searchString);
            driver.FindElement(By.CssSelector("button[name='submit_search']")).Click();
            driver.Manage().Timeouts().ImplicitWait=TimeSpan.Zero;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(3));
            wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));
            bool IsSearchCorrect = wait.Until(x => x.FindElements(By.ClassName("lighter"))
                .Any());

            driver.Manage().Timeouts().ImplicitWait=implicitWait;
            Assert.That(IsSearchCorrect, Is.EqualTo(isCorrect), $"Searching works {(IsSearchCorrect ? "successfully" : "unsuccessfully")}"+$", but we expected opposite");

        } 
       
    }

   
    
}