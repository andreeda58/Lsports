using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSeleniumLsports.TestCase
{
    class BaseTest
    {
        protected IWebDriver _driver;
        protected string Url = ConfigurationManager.AppSettings["Url"];

        [SetUp]
        public void BeforeBaseTest()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _driver.Navigate().GoToUrl(Url);
        }


        [TearDown]
        public void AfterBaseTest()
        {
            if (_driver != null)
                _driver.Quit();
        }
    }
}
