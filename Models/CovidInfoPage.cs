using Logging;
using OpenQA.Selenium;

using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Linq;

namespace Models
{
    public class CovidInfoPage : BasePage
    {
        protected IWebElement _frame1
        { get => _driver.FindElement(By.Id("sherpa-widget-container")); }
        protected IWebElement _frame2
        { get => _driver.FindElement(By.CssSelector("[title=\"sherpa° Map\"]")); }
        protected IWebElement _passportBox
        {
            get => _driver.FindElement(By.Id("passportFilter"))
                  .FindElement(By.ClassName("mat-button-base"));
        }
        protected IWebElement _inputPassport
        { get => _driver.FindElement(By.Id("cdk-overlay-0")).FindElement(By.Id("mat-input-0")); }
        protected IWebElement _itemListBoxPassport
        {
            get => _driver
                 .FindElement(By.CssSelector("mat-selection-list[data-cy='passport-search-results']"))
                 .FindElement(By.CssSelector("div[class='cdk-virtual-scroll-content-wrapper']"));
        }
        protected IWebElement _departureBox
        { get => _driver.FindElement(By.CssSelector("mat-icon[data-mat-icon-name='pin']")); }
        protected IWebElement _inputDeparture
        { get => _driver.FindElement(By.Id("cdk-overlay-1")).FindElement(By.Id("mat-input-1")); }
        protected IWebElement _itemListBoxDeparture
        {
            get => _driver.FindElement(By.CssSelector("mat-selection-list[data-cy='search-results']"))
                      .FindElement(By.CssSelector("mat-list-option[role='option']"));
        }
        protected IWebElement _destinationBox
        { get => _driver.FindElement(By.CssSelector("mat-icon[data-mat-icon-name='search']")); }
        protected IWebElement _inputDestination
        {
            get => _driver.FindElement(By.Id("cdk-overlay-2"))
                    .FindElement(By.Id("mat-input-2"));
        }
        protected IWebElement _itemListBoxDestination
        {
            get => _driver.FindElement(By.CssSelector("mat-selection-list[data-cy='search-results']"))
                  .FindElements(By.CssSelector("h4[class='mat-line']")).FirstOrDefault(e => e.Text.Contains("CDG"));
        }
        protected IWebElement _vaccinationFilter
        {
            get => _driver.FindElement(By.Id("vaccinationFilter"))
                  .FindElement(By.Id("mat-slide-toggle-1-input"));
        }
        protected IWebElement _covidText
        {
            get => _driver.FindElement(By.Id("sidenav"))
                  .FindElement(By.CssSelector("h2[class='mat-subheading-1']"));
        }

        public CovidInfoPage(IWebDriver driver) => _driver = driver;

        public CovidInfoPage GoToCorrectFrame()
        {
            try
            {
                var tabs = _driver.WindowHandles;
                _driver.SwitchTo().Window(tabs[1]);
                _driver.SwitchTo().Frame(_frame1);
                _driver.SwitchTo().Frame(_frame2);
            }
            catch (InvalidSelectorException ex)
            {
                Logger.Instance.Add(ex.Message);
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("[title=\"sherpa° Map\"]")));
            }
            catch (NoSuchElementException ex)
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                    .Until(drv => drv.FindElement(By.CssSelector("[title=\"sherpa° Map\"]")));
                Logger.Instance.Add(ex.Message);
            }
            catch (StaleElementReferenceException ex)
            {
                Logger.Instance.Add(ex.Message);
            }
            catch (NoSuchFrameException ex)
            {
                Logger.Instance.Add(ex.Message);
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.Id("sherpa-widget-container")));

            }
            catch (Exception ex)
            {
                Logger.Instance.Add(ex.Message);
                throw;
            }

            return this;
        }

        public CovidInfoPage ClickPassportBox()
        {
            try
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(_passportBox)).Click();
            }

            catch (NoSuchElementException ex)
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                    .Until(drv => drv.FindElement(By.ClassName("mat-button-base")));
                Logger.Instance.Add(ex.Message);
            }

            catch (ElementNotSelectableException ex)
            {
                Logger.Instance.Add(ex.Message);
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(_passportBox));
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
        public CovidInfoPage TypeInputPassport(string text)
        {
            try
            {
                _inputPassport.SendKeys(text);
            }
            catch (InvalidSelectorException ex)
            {
                Logger.Instance.Add(ex.Message);
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("mat-input-0")));
            }
            catch (NoSuchElementException ex)
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                    .Until(drv => drv.FindElement(By.Id("mat-input-0")));
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
        public CovidInfoPage SelectFromListBoxPassport()
        {
            try
            {
                _itemListBoxPassport.Click();
            }

            catch (NoSuchElementException ex)
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                    .Until(drv => drv.FindElement(By.CssSelector("div[class='cdk-virtual-scroll-content-wrapper']")));
                Logger.Instance.Add(ex.Message);
            }

            catch (ElementNotSelectableException ex)
            {
                Logger.Instance.Add(ex.Message);
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(_itemListBoxPassport));
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

        public CovidInfoPage ClickDepartureBox()
        {   
            try
            {
                _departureBox.Click(); ;
            }

            catch (NoSuchElementException ex)
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                    .Until(drv => drv.FindElement(By.CssSelector("mat-icon[data-mat-icon-name='pin']")));
                Logger.Instance.Add(ex.Message);
            }

            catch (ElementNotSelectableException ex)
            {
                Logger.Instance.Add(ex.Message);
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(_departureBox));
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
        public CovidInfoPage InputDeparture(string text)
        {
            try
            {
                _inputDeparture.SendKeys(text);
            }
            catch (InvalidSelectorException ex)
            {
                Logger.Instance.Add(ex.Message);
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("mat-input-1")));
            }
            catch (NoSuchElementException ex)
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                    .Until(drv => drv.FindElement(By.Id("mat-input-1")));
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
        public CovidInfoPage SelectFromListBoxDeparture()
        {
            try
            {
                _itemListBoxDeparture.Click();
            }
            catch (NoSuchElementException ex)
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                    .Until(drv => drv.FindElement(By.CssSelector("mat-list-option[role='option']")));
                Logger.Instance.Add(ex.Message);
            }

            catch (ElementNotSelectableException ex)
            {
                Logger.Instance.Add(ex.Message);
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(_itemListBoxDeparture));
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

        public CovidInfoPage ClickDestinationBox()
        {
               
            try
            {
                _destinationBox.Click();
            }

            catch (NoSuchElementException ex)
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                    .Until(drv => drv.FindElement(By.CssSelector("mat-icon[data-mat-icon-name='search']")));
                Logger.Instance.Add(ex.Message);
            }

            catch (ElementNotSelectableException ex)
            {
                Logger.Instance.Add(ex.Message);
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(_destinationBox));
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
        public CovidInfoPage InputDestination(string text)
        {
           
            try
            {
                _inputDestination.SendKeys(text);
            }
            catch (InvalidSelectorException ex)
            {
                Logger.Instance.Add(ex.Message);
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("mat-input-2")));
            }
            catch (NoSuchElementException ex)
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                    .Until(drv => drv.FindElement(By.Id("mat-input-2")));
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
        public CovidInfoPage SelectFromListBoxDestination()
        {
            try
            {
                _itemListBoxDestination.Click();
            }

            catch (NoSuchElementException ex)
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                    .Until(drv => drv.FindElement(By.CssSelector("h4[class='mat-line']")));
                Logger.Instance.Add(ex.Message);
            }

            catch (ElementNotSelectableException ex)
            {
                Logger.Instance.Add(ex.Message);
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(_itemListBoxDestination));
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

        public CovidInfoPage SelectVacunationFilter()
        {
            try
            {
                if (_vaccinationFilter.GetAttribute("aria-checked")!="true")
                _vaccinationFilter.Click();
            }

            catch (NoSuchElementException ex)
            {
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                    .Until(drv => drv.FindElement(By.CssSelector("h4[class='mat-line']")));
                Logger.Instance.Add(ex.Message);
            }

            catch (ElementNotSelectableException ex)
            {
                Logger.Instance.Add(ex.Message);
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                .Until(ExpectedConditions.ElementToBeClickable(_itemListBoxDestination));
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
        public string GetText()
        {
            string text = "";
            try
            {
                text = _covidText.Text;
            }
            catch (StaleElementReferenceException err)
            {
                Logger.Instance.Add(err.Message);
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                    .Until(ExpectedConditions.ElementToBeClickable(_inputDeparture));
            }

            catch (TimeoutException err)
            {
                Logger.Instance.Add(err.Message);
                new WebDriverWait(_driver, TimeSpan.FromSeconds(10))
                    .Until(ExpectedConditions.ElementToBeClickable(_inputDeparture));
            }
            catch (Exception err)
            {
                Logger.Instance.Add(err.Message);
                throw;
            }

            Logger.Instance.Add(text);
            return text;
        }
    }
}
