using System;
using System.Linq;
using DZ3_AutTest.Framework;
using OpenQA.Selenium;

namespace DZ3_AutTest.PageObject
{
    public class Header : PageObjectBase
    {
        private static readonly By searchInput = By.Id("search_query_top");
        private static readonly By searchButton = By.CssSelector("button[name='submit_search']");
        private static readonly By IsSearchCorrectClass = By.ClassName("lighter");
        public Header(IWebDriver driver) : base(driver)
        {
            
        }

        public Header InputSerachText(string searchText)
        {
            Driver.FindElement(searchInput).Click();
            Driver.FindElement(searchInput).Clear();
            Driver.FindElement(searchInput).SendKeys(searchText);

            return this;
        }

        public Header SearchButtonClick()
        {
            Driver.FindElement(searchButton).Click();
            return this;
        }

        public bool IsSearchOk()
        {
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.Zero;
            bool isOk = Wait.WaitFor(() => Driver.FindElements(IsSearchCorrectClass).Any());
            Driver.Manage().Timeouts().ImplicitWait = Settings.ImplicitWait;
            return isOk;
        }
        
    }
}