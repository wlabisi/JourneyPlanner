using OpenQA.Selenium;
using System.Reflection;

namespace TFL.Report
{
    internal class ScreenshotHelper
    {
        public string TakeScreenshot(IWebDriver driver)
        {
            var imagePath = $"{Directory.GetParent(Assembly.GetExecutingAssembly().Location)!.Parent!.Parent!.FullName}/Report/Screenshots/";
            var screenshotName = $"{DateTime.Now:yyyy-MM-dd_HH-mm-ss.ffff}.png";
            var screenshotLocation = $"{imagePath}{Path.PathSeparator}{screenshotName}";

            DirectoryInfo folder = new(imagePath);

            if (!folder.Exists)
            {
                folder.Create();
            }
            try
            {
                ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile($"{imagePath}{Path.PathSeparator}{screenshotName}");
            }
            catch (Exception) { }

            return screenshotLocation;
        }
    }
}