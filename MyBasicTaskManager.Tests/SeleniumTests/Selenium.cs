using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using OpenQA.Selenium.Support.UI;
namespace SeleniumDemo
{
    [TestFixture]
    public class FirstTests
    {
        IWebDriver _driver;
        [SetUp] public void StartBrowser() { _driver = new FirefoxDriver(); }
        [Test]
        public void GoogleTest()
        {
            var text = "Pierwszy test"; _driver.Navigate().GoToUrl("https://google.pl");
            var searchTextBox = _driver.FindElement(By.Name("q"));
            searchTextBox.SendKeys(text + Keys.Enter);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.CssSelector("div.hdtb-mitem:nth-child(1)"))));
            StringAssert.StartsWith("https://www.google.pl/search?", _driver.Url);
        }
        [TearDown] public void CloseBrowser() { _driver.Close(); }
    }
}
