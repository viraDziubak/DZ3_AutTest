using System;
using System.Linq;
using DZ3_AutTest.Framework;
using DZ3_AutTest.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DZ3_AutTest.Tests
{
    public abstract class BaseTest
    {
        protected readonly IWebDriver Driver;
       
        protected BaseTest()
        {
            Driver = Selenium.GetDriver(Settings.Driver);
            Driver.Navigate().GoToUrl(Settings.Url);
        }
        static void Main ()
        {
            
        }
        
        [OneTimeTearDown]
        public void OneTimeTearDown() => Driver.Quit();
    }
}