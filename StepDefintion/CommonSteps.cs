using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace TFL.StepDefintion
{
    [Binding]
    internal class CommonSteps
    {
        private IWebDriver driver;
        public CommonSteps(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"I navigate to homepage")]
        public void GivenINavigateToHomepage()
        {
            string url = new Configuration().BaseUrl;

            driver.Navigate().GoToUrl(url);
            var s = driver.Title;
            Assert.IsTrue(driver.Title.Contains("Transport for London"));
           // Thread.Sleep(5000);
        }
    }
}
