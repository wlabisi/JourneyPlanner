using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TFL.Helpers;

namespace TFL.Pages
{
    internal class Homepage
    {
        private IWebDriver driver;

        public Homepage(IWebDriver driver)
        {
            this.driver = driver;
           
        }

        private IWebElement FromField => driver.FindElement(By.CssSelector("[data-placeholder-blur='From']"));
        private IWebElement FromFieldError => driver.FindElement(By.CssSelector("[id='InputFrom-error']"));
        private IWebElement ToField => driver.FindElement(By.CssSelector("[data-placeholder-blur='To']"));
        private IWebElement ToFieldError => driver.FindElement(By.CssSelector("[id='InputTo-error']"));
        private IWebElement PlanJourneyBtn => driver.FindElement(By.CssSelector("[id='plan-journey-button']"));
        private IWebElement AcceptCookieBtn => driver.FindElement(By.XPath("//*[text()='Accept all cookies']"));
        private IWebElement ChangeTimeLink => driver.FindElement(By.CssSelector("[class='change-departure-time']"));
        private IWebElement ArrivingBtn => driver.FindElement(By.XPath("//*[@for='arriving']"));
        private IWebElement RecentJourneyBtn => driver.FindElement(By.XPath("//*[text()='Recents']"));

        private void JavaScriptExecutor(IWebElement element)
        {
            new JavaScriptHelpers(driver).JavaScriptClick(element);
        }

        public void FillInFromTextbox(string value)
        {
            FromField.SendKeys(value);
            FromField.SendKeys(Keys.Tab);
        } 
        public void FillInToTextbox(string value)
        {
            ToField.SendKeys(value);
            ToField.SendKeys(Keys.Tab);
        }
       
        public void PlanJourney() => JavaScriptExecutor(PlanJourneyBtn);
        public void AcceptCookie() => AcceptCookieBtn.Click();
        public void ChangeTime() => JavaScriptExecutor(ChangeTimeLink);
        public void Arriving() => JavaScriptExecutor(ArrivingBtn);
        public void RecentsBtn() => JavaScriptExecutor(RecentJourneyBtn);
      
        public bool IsFromFieldError()
        {
            try
            {
                return FromFieldError.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool IsToFieldError()
        {
            try
            {
                return ToFieldError.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
       
    }
}
