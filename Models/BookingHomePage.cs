using Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class BookingHomePage:BasePage
    {
        protected IWebElement _learnMoreLink 
        { get => _driver.FindElement(By.CssSelector("a[class='bui-link coronavirus-banner__link']")); }
        protected IWebElement _moreDealsLink 
        { get=> _driver.FindElement(By.Id("dealsCampaign_getaway")).FindElement(By.ClassName("bui-button")); }

        public BookingHomePage(IWebDriver driver)=> _driver = driver;

        public ExploreDealsPage GoToExploreDealsPage()
        {
            try
            {
                _moreDealsLink.Click();
            }
            catch (NoSuchElementException ex)
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                    .Until(drv => drv.FindElement(By.ClassName("bui-button")));
                Logger.Instance.Add(ex.Message);
            }

            catch (ElementNotSelectableException ex)
            {
                Logger.Instance.Add(ex.Message);
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(_moreDealsLink));
            }

            catch (StaleElementReferenceException ex)
            {
                Logger.Instance.Add(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Instance.Add(ex.Message);
                throw;
            }
           
            return new ExploreDealsPage(_driver);
        }

        public CovidInfoPage GoToCovidInfo()
        {
            try
            {
                _learnMoreLink.Click();
            }
            catch (ElementNotSelectableException err)
            {
                Logger.Instance.Add(err.Message);
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                    .Until(ExpectedConditions.ElementToBeClickable(_learnMoreLink));
            }
            catch (NoSuchElementException ex)
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                    .Until(drv => drv.FindElement(By.ClassName("bui-button")));
                Logger.Instance.Add(ex.Message);
            }

            catch (StaleElementReferenceException ex)
            {
                Logger.Instance.Add(ex.Message);
            }
            catch (Exception ex)
            {
                Logger.Instance.Add(ex.Message);
                throw;
            }
           
            return new CovidInfoPage(_driver);
        }

    }
}
