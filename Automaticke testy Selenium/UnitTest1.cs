using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using SeleniumExtras.PageObjects;

namespace AutomatickeTestySelenium
{
    public class Tests
    {
        IWebDriver firefox;
        FirefoxOptions firefoxOptions;

        [SetUp]
        public void Setup()
        {
            firefox = new FirefoxDriver();
            firefoxOptions = new FirefoxOptions();
            firefoxOptions.AddArguments("-private");
            firefox.Manage().Window.Maximize();
            //firefox.Manage().Timeouts().ImplicitWait;
        }

        [Test]
        public void Test1()
        {

            CostumerSigninRegisterPage costumerSigninRegisterPage = new CostumerSigninRegisterPage(firefox);

            costumerSigninRegisterPage.FillCostumerSigninEmail("NonExistingCustomer");
            costumerSigninRegisterPage.FillCostumerSigninPassword("FakePass");
            costumerSigninRegisterPage.ClickOnSigninButton();
 
            Assert.IsTrue(costumerSigninRegisterPage.IsLoginFailedUserAlertPresent(),"Login Failed User Alert must be present");
            Assert.AreEqual("Login Failed. Username or Password is incorrect.", costumerSigninRegisterPage.TextOfLoginFailedUserAlert(),
                "Text of Login failed Alert should be: Login Failed. Username or Password is incorrect.");
           
        }

        [TearDown]
        public void Close_Browser()
        {
            firefox.Quit();
        }
    }
}