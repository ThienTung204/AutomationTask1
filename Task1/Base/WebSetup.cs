using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using Task1.Browser;
using Task1.Reports;

namespace Task1.Base
{
    [TestClass]
    public class WebSetup
    {
        protected static IWebDriver driver;
        public TestContext TestContext { get; set; }

        [AssemblyInitialize]
        public static void InitAssembly(TestContext context)
        {
            BrowserType browser = BrowserType.Chrome;
            driver = Factory.InitDriver(browser);
            driver.Navigate().GoToUrl("https://automationexercise.com/");
        }

        [TestInitialize]
        public void InitTest()
        {
            ExtentReporting.CreateTest(TestContext.TestName);
        }

        [TestCleanup]
        public void CleanupTest()
        {
            var outcome = TestContext.CurrentTestOutcome;
            if (outcome == UnitTestOutcome.Failed)
            {
                ExtentReporting.LogFail("Bug!");
                AutoLogScreenshot(driver, outcome, $"Test: {TestContext.TestName}");
            }
            else if (outcome == UnitTestOutcome.Passed)
            {
                ExtentReporting.LogPass($"Test passed: {TestContext.TestName}");
            }
            else
            {
                ExtentReporting.LogInfo($"Test ended with status {outcome}: {TestContext.TestName}");
            }
        }

        [AssemblyCleanup]
        public static void CleanupAssembly()
        {
            ExtentReporting.StopExtent();
            driver.Quit();
        }
        public static void AutoLogScreenshot(IWebDriver driver, UnitTestOutcome outcome, string stepDetail)
        {
            if (outcome == UnitTestOutcome.Failed)
            {

                ExtentReporting.LogScreenshot(driver, AventStack.ExtentReports.Status.Fail, $"{stepDetail} - FAILED");
            }
            else if (outcome == UnitTestOutcome.Passed)
            {
                ExtentReporting.LogScreenshot(driver, AventStack.ExtentReports.Status.Pass, $"{stepDetail} - PASSED");
            }
            else
            {
                ExtentReporting.LogScreenshot(driver, AventStack.ExtentReports.Status.Info  , $"{stepDetail} - Status: {outcome}");
            }
        }

        public static IWebDriver GetDriver() => driver;
    }
}
