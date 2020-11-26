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
    internal class CostumerMyAccountPage
    {
        private IWebDriver driver;

        public CostumerMyAccountPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}