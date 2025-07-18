using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Browser
{
    public static class Factory
    {
        public static IWebDriver InitDriver(BrowserType browser)
        {
            IWebDriver driver;

            switch (browser)
            {
                case BrowserType.Chrome:
                    driver = new ChromeDriver();
                    break;
                case BrowserType.Edge:
                    driver = new EdgeDriver();
                    break;
                case BrowserType.Firefox:
                    driver = new FirefoxDriver();
                    break;
                default:
                    throw new ArgumentException("Trình duyệt không được hỗ trợ");
            }
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            return driver;
        }
    }
}
