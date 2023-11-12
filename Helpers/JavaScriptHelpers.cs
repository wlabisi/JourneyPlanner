using OpenQA.Selenium;

namespace TFL.Helpers
{
    internal class JavaScriptHelpers
    {
        private IWebDriver driver;

        public JavaScriptHelpers(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void JavaScriptClick(IWebElement element)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click();", element);
        }
    }
}
