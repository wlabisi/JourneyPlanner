using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System.Reflection;
using TechTalk.SpecFlow;

namespace TFL.Report
{
    internal class ExtentReport
    {
        private static ExtentHtmlReporter? extentHtmlReporter;
        private static ExtentReports? extentReports;
        private static ExtentTest? extentFeature, extentTest, extentStep;

        //private static readonly bool IsReportedEnabled = new Configuration().ExtentReport;

        public static void GenerateExtentreport()
        {
            string path = Directory.GetParent(Assembly.GetExecutingAssembly().Location)!.Parent!.Parent!.FullName;
            string reportPath = $"{path}/Report/ExtentReport-{DateTime.Now:ddMMMMyyyy-HHmmsstt}";
            extentHtmlReporter = new ExtentHtmlReporter(reportPath);
            extentReports = new ExtentReports();
            extentReports.AttachReporter(extentHtmlReporter);
            extentReports.AddSystemInfo("Operating System:", Environment.OSVersion.ToString());
            extentReports.AddSystemInfo("Platform:", Environment.OSVersion.Platform.ToString());
            extentReports.AddSystemInfo("Version:", Environment.OSVersion.Version.ToString());
            extentReports.AddSystemInfo("Machine Name:", Environment.MachineName.ToString());
            extentReports.AddSystemInfo("Browser:", new Configuration().Browser);
        }

        public static void ExtentFeatureSetup(string title, string description) => extentFeature = extentReports?.CreateTest(new GherkinKeyword("Feature"), title, description);

        public static void ExtentScenarioSetup(string title, string description) => extentTest = extentFeature?.CreateNode(new GherkinKeyword("Scenario"), title, description);

        public static void ExtentBeforeStep() => extentStep = extentTest;

        public static void ExtentAfterStep(ScenarioContext scenarioContext, string screenshot)
        {
            var status = scenarioContext.TestError != null ? Status.Fail : Status.Pass;
            extentStep = extentTest?.CreateNode(
                    new GherkinKeyword(scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString())
                    , $"{scenarioContext.StepContext.StepInfo.Text}");
            if (status == Status.Fail)
            {
                var stackTrace = "<pre>" + scenarioContext.TestError!.StackTrace + "</pre>";
                var errorMessage = scenarioContext.TestError.Message;
                extentStep?.Log(Status.Fail);
                if (screenshot != null)
                {
                    extentStep?.AddScreenCaptureFromPath(screenshot);
                }
                extentStep?.Fail(errorMessage + stackTrace);
            }
        }

        public static void TearDownReport() => extentReports?.Flush();
    }
}
