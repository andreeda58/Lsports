using Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class ExploreDealsPage:BasePage
    {

        protected IWebElement _whereAreYouGoingInput
        { get => _driver.FindElement(By.Name("ss")); }

        protected IWebElement _searchButton
        { get => _driver.FindElement(By.CssSelector("button.sb-searchbox__button")); }

        protected IWebElement _reviewScoreHotel
        { get => _driver.FindElement(By.XPath("//*[@id='searchboxInc']/div[1]/div/div/div[1]/div[18]/div[3]/label/div/div/div[1]/div")); }

        public ExploreDealsPage(IWebDriver driver) => _driver = driver;


      
        public ExploreDealsPage InputDestination(string dest)
        {
            try
            {
                _whereAreYouGoingInput.SendKeys(dest);
            }
            catch (InvalidSelectorException ex)
            {
                Logger.Instance.Add(ex.Message);
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Name("ss")));
            }
            catch (NoSuchElementException ex)
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                    .Until(drv => drv.FindElement(By.Name("ss")));
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
           
            return this;
        }
        public ExploreDealsPage ExecuteDestinationSearch()
        {
            try
            {
                _searchButton.Click();
            }
           
            catch (NoSuchElementException ex)
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                    .Until(drv => drv.FindElement(By.CssSelector("button.sb-searchbox__button")));
                Logger.Instance.Add(ex.Message);
            }

            catch (ElementNotSelectableException ex)
            {
                Logger.Instance.Add(ex.Message);
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(_searchButton));
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
            return this;
        }
        public bool ReviewScoreClick()
        {

            try
            {
                _reviewScoreHotel.Click();
                return true;
            }

            catch (NoSuchElementException ex)
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                    .Until(drv => drv.FindElement(By.XPath("//*[@id='searchboxInc']/div[1]/div/div/div[1]/div[18]/div[3]/label/div/div/div[1]/div")));
                Logger.Instance.Add(ex.Message);
            }

            catch (ElementNotSelectableException ex)
            {
                Logger.Instance.Add(ex.Message);
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(_reviewScoreHotel)); ;
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
           
            return false;
        }



    }
}
