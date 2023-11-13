using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;


namespace TFL.Pages
{
    internal class JourneyResultsPage
    {
        private IWebDriver driver;
        public JourneyResultsPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement SearchResult => driver.FindElement(By.XPath("//*[text()='Cycling and other options']"));

        private IWebElement ResultNotFound => driver.FindElement(By.XPath("//*[text()='Journey planner could not find any results to your search. Please try again']"));
        private IWebElement EditJourneyLink => driver.FindElement(By.ClassName("edit-journey"));
        private IWebElement SelectDateFromLIst => driver.FindElement(By.CssSelector("[id='Date']"));
        private IWebElement UpdateJourneyBtn => driver.FindElement(By.CssSelector("[id='plan-journey-button']"));
        private IWebElement HomePageBtn => driver.FindElement(By.XPath("//*[text()='Home']"));

        public bool IsJourneyResultDisplayed()
        {
            try
            {
                return SearchResult.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool IsResultNotFound()
        {
            try
            {
                return ResultNotFound.Displayed;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public void EditJourney() => EditJourneyLink.Click();
        public void SelectDate()
        {
            DateTime today = DateTime.Today;
            today = today.AddDays(1);
            var formattedDate = today.ToString("yyyyMMdd");

            SelectElement dropElement = new(SelectDateFromLIst);
            dropElement.SelectByValue(formattedDate);
        }
        public void UpdateJourney() => UpdateJourneyBtn.Click();

        public void HomePage() => HomePageBtn.Click();

    }

    
}
