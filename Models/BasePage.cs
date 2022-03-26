using Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BasePage
    {
        protected IWebDriver _driver;

        public bool ElementIsPresent(IWebDriver driver, By locator)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(drv => drv.FindElement(locator));
                return true;
            }
            catch (Exception e)
            {
                Logger.Instance.Add(e.Message);
                throw new Exception(e.Message);
            }
        }

        
        
    }
}
