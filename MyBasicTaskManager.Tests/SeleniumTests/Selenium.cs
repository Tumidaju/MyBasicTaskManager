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
        private string _testRandomNumber;
        private string _appUrl;
        private string _login;
        private string _password;
        private string _TaskName;
        private string _Color;
        IWebDriver _driver;

        [SetUp]
        public void StartBrowser()
        {
            _driver = new FirefoxDriver();
        }
        [SetUp]
        public void SetVariables()
        {
            _testRandomNumber = DateTime.Now.ToBinary().ToString().Substring(5, 10);
            _appUrl = "http://localhost:54142/";
            _login = "c" + _testRandomNumber + "a@testmbtm.pl";
            _password = "Adm!n123";
            _TaskName = "Test_task" + _testRandomNumber;
            _Color = "#000";
        }
        [Test]
        public void BusinessFlow()
        {
            Register();
            Logout();
            LogIn();
            AddTask();
            Logout();
        }
        private void Register()
        {
            //act
            _driver.Navigate().GoToUrl(_appUrl);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.Id("loginLink"))));
            _driver.FindElement(By.Id("loginLink")).Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.Id("registerLink"))));
            _driver.FindElement(By.Id("registerLink")).Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.Id("ConfirmPassword"))));
            _driver.FindElement(By.Id("Email")).SendKeys(_login);
            _driver.FindElement(By.Id("Password")).SendKeys(_password);
            _driver.FindElement(By.Id("ConfirmPassword")).SendKeys(_password + Keys.Enter);
            //assert
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.Id("logoutForm"))));
            var id = _driver.FindElement(By.Id("logoutForm")).GetAttribute("id");
            Assert.AreEqual(id, "logoutForm");
        }
        private void Logout()
        {
            _driver.Navigate().GoToUrl(_appUrl);     
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.ClassName("logout"))));
            _driver.FindElement(By.ClassName("logout")).Submit();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.Id("loginLink"))));
            var id = _driver.FindElement(By.Id("loginLink")).GetAttribute("id");
            //assert
            Assert.AreEqual(id, "loginLink");
        }
        private void LogIn()
        {
            //act
            _driver.Navigate().GoToUrl(_appUrl);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.Id("loginLink"))));
            _driver.FindElement(By.Id("loginLink")).Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.Id("Email"))));
            _driver.FindElement(By.Id("Email")).SendKeys(_login);
            _driver.FindElement(By.Id("Password")).SendKeys(_password + Keys.Enter);
            //assert
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.Id("logoutForm"))));
            var id = _driver.FindElement(By.Id("logoutForm")).GetAttribute("id");
            Assert.AreEqual(id, "logoutForm");
        }
        private void AddTask()
        {
            //act
            _driver.Navigate().GoToUrl(_appUrl);
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.Id("logoutForm"))));
            _driver.FindElement(By.ClassName("tasks")).Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.ClassName("addtask"))));
            _driver.FindElement(By.ClassName("addtask")).Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.Id("Task_Id"))));
            _driver.FindElement(By.Id("Name")).SendKeys(_TaskName);
            _driver.FindElement(By.Id("Description")).SendKeys(_TaskName);
            _driver.FindElement(By.Id("CardColor")).SendKeys(_Color);
            _driver.FindElement(By.Id("FontColor")).SendKeys(_Color);
            _driver.FindElement(By.Id("Progress")).SendKeys("1");
            _driver.FindElement(By.ClassName("add")).Click();
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.Id("pills-tab"))));
            //assert
            new WebDriverWait(_driver, TimeSpan.FromSeconds(10)).Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists((By.Id("logoutForm"))));
            var taskClass = _driver.FindElement(By.ClassName(_TaskName)).GetAttribute("class");
            Assert.AreEqual(taskClass, _TaskName);
        }
        [TearDown]
        public void CloseBrowser() { _driver.Close(); }
    }
}
