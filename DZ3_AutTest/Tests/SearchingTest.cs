using System;
using DZ3_AutTest.Framework;
using DZ3_AutTest.PageObject;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace DZ3_AutTest.Tests
{
    [TestFixture]
    public class SearchingTest : BaseTest
    {
        private Header _header;
            
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _header = new Header(Driver);
            
        }

        [TestCase(true,"dress")]
        [TestCase(false,"qwe134")]
        public void SearchCorrect(bool isCorrect, string searchString)
        {
            bool isSearchCorrect = _header.InputSerachText(searchString).SearchButtonClick().IsSearchOk();
            
            Assert.That(isSearchCorrect, Is.EqualTo(isCorrect), 
                $"Searching works {(isSearchCorrect ? "successfully" : "unsuccessfully")}"+$", but we expected opposite");

        } 
    }
}