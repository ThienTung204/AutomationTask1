using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using System;
using System.IO;
namespace Task1.Reports
{
    public class ExtentReporting
    {
        private static ExtentReports extentReports;
        private static ExtentTest extentTest;

        public static ExtentReports StartExtentReports()
        {
            if (extentReports == null)
            {
                string reportDir = @"D:\AUTO\Task1\Task1\ReportResult";
                Directory.CreateDirectory(reportDir);

                string reportPath = Path.Combine(reportDir, $"ExtentReport_{DateTime.Now:yyyyMMdd_HHmmss}.html");
                var sparkReporter = new ExtentSparkReporter(reportPath); 

                extentReports = new ExtentReports();
                extentReports.AttachReporter(sparkReporter);
            }
            return extentReports;
        }

        public static void CreateTest(string testName)
        {
            extentTest = StartExtentReports().CreateTest(testName);
        }
        public static void StopExtent()
        {
            StartExtentReports().Flush();
        }
        public static void LogPass(string info)
        {
            extentTest.Pass(info);
        }
        public static void LogFail(string info)
        {
            extentTest.Fail(info);
        }
        public static void LogInfo(string info)
        {
            extentTest.Info(info);
        }
        public static void LogScreenshot(IWebDriver driver,AventStack.ExtentReports.Status info,string stepDetail)
        {
            string imagesDir = @"D:\AUTO\Task1\Task1\ReportResult\Imagess";
            Directory.CreateDirectory(imagesDir);
            string fileName = $"Screenshot_{DateTime.Now:yyyyMMdd_HHmmss}.png";
            string filePath = Path.Combine(imagesDir, fileName);
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            extentTest.Log(info, stepDetail,
                MediaEntityBuilder.CreateScreenCaptureFromPath(filePath).Build());
        }

    }
}
