using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using TFL.Report;

namespace TFL.Hooks
{
    [Binding]
    public sealed class Hooks
    {
        private IWebDriver? driver;
        private readonly Configuration configuration;
        private readonly IObjectContainer objectContainer;

        public Hooks(IObjectContainer objectContainer, ScenarioContext scenarioContext)
        {
            this.objectContainer = objectContainer;
            configuration = new Configuration();
        }

        [BeforeTestRun]
        public static void BerforeTestRun() => ExtentReport.GenerateExtentreport();

        [BeforeStep]
        public static void BeforeStep() => ExtentReport.ExtentBeforeStep();

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            string screenshot = "";
            if (scenarioContext.TestError != null)
            {
                screenshot = new ScreenshotHelper().TakeScreenshot(driver!);
            }
            ExtentReport.ExtentAfterStep(scenarioContext, screenshot);
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext) => ExtentReport.ExtentFeatureSetup(featureContext.FeatureInfo.Title, featureContext.FeatureInfo.Description);

        [BeforeScenario]
        public void BeforeScenario(ScenarioContext scenarioContext)
        {
            driver = configuration.Browser.ToLower() switch
            {
                "chrome" => new ChromeDriver(Directory.GetCurrentDirectory()),
                "edge" => new EdgeDriver(Directory.GetCurrentDirectory()),
                "firefox" => new FirefoxDriver(Directory.GetCurrentDirectory()),
                _ => throw new WebDriverArgumentException("No matching browser found"),
            };
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(15);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            driver.Manage().Timeouts().AsynchronousJavaScript = TimeSpan.FromSeconds(15);
            objectContainer.RegisterInstanceAs(driver);
            ExtentReport.ExtentScenarioSetup(scenarioContext.ScenarioInfo.Title, scenarioContext.ScenarioInfo.Description);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            driver = objectContainer.Resolve<IWebDriver>();
            driver.Quit();
        }

        [AfterTestRun]
        public static void AftertestRun() => ExtentReport.TearDownReport();
    }
}