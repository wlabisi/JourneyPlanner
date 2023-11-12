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
        public void PlanJourney() => new JavaScriptHelpers(driver).JavaScriptClick(PlanJourneyBtn);
        public void AcceptCookie() => AcceptCookieBtn.Click();
        public void ChangeTime() => new JavaScriptHelpers(driver).JavaScriptClick(ChangeTimeLink);

        public void Arriving() => new JavaScriptHelpers(driver).JavaScriptClick(ArrivingBtn);

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
