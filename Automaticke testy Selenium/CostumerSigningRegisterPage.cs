using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace AutomatickeTestySelenium
{
    class CostumerSigninRegisterPage
    {
        String costumerSigninRegisterPageUrl = "https://czechitas-shopizer.azurewebsites.net/shop/customer/customLogon.html";
        private IWebDriver driver;
        private WebDriverWait wait;
        public CostumerSigninRegisterPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
            driver.Url = costumerSigninRegisterPageUrl;
            Console.WriteLine("Navigate browser to page where costumers could Sign in or Resgister: " +
                costumerSigninRegisterPageUrl);
        }

        [FindsBy(How = How.Id, Using = "signin_userName")]
        [CacheLookup]
        private IWebElement costumerSigninEmail;

        [FindsBy(How = How.Id, Using = "signin_password")]
        [CacheLookup]
        private IWebElement costumerSigninPassword;

        By signinButton = By.Id("genericLogin-button");
        By loginErrorAlert = By.Id("loginError");
        By registerButton = By.XPath("//*[@class=\"btn btn-default login-btn\" and text()=\"Register\"]");

        public void FillCostumerSigninEmail(String costumerEmail)
        {
            Console.WriteLine("Find Element Costumer email adress and fill it by: " + costumerEmail);
            costumerSigninEmail.SendKeys(costumerEmail);
        }

        public void FillCostumerSigninPassword(string costumerPassword)
        {
            Console.WriteLine("Find Element Password and fill it by: " + costumerPassword);
            costumerSigninPassword.SendKeys(costumerPassword);
        }

        public CostumerMyAccountPage ClickOnSigninButton()
        {
            Console.WriteLine("Find Element Sign in button and clik on it.");
            driver.FindElement(signinButton).Click();

            return new CostumerMyAccountPage(driver);
        }

        /*
        Metóda registrácie, pre testy kedy sa chcem priamo prihlásiť, bez použitia metód pre jednotlivé kroky
        */
        public CostumerMyAccountPage Signin(String userName, String password)
        {
            FillCostumerSigninEmail(userName);
            FillCostumerSigninPassword(password);
            return ClickOnSigninButton();
        }

        public bool IsLoginFailedUserAlertPresent()
        {
            Console.WriteLine("When Element Login failed alert box if found, return true.");
            driver.FindElement(loginErrorAlert);
            return true;
        }

        public String TextOfLoginFailedUserAlert()
        {
            Console.WriteLine("Find Element Login failed alert box and get its text.");
            return driver.FindElement(loginErrorAlert).Text;
        }

        public RegistrationPage ClickOnRegistrationButton()
        {
            driver.FindElement(registerButton).Click();

            return new RegistrationPage(driver);
        }

        public String GetCurrentUrl()
        {
            Console.WriteLine("Get current Url and compare it with: " + costumerSigninRegisterPageUrl);
            return driver.Url;
        }


    }
}
