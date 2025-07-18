using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1.Helper
{
    public static class FuntionHelper
    {
        private static readonly int defaultTimout = 10;
        public static bool KiemTraURL(IWebDriver driver,String Path)
        {
            return driver.Url.Contains(Path);
        }
        private static IWebElement Wait(IWebDriver driver ,Func<IWebDriver,IWebElement> condition)
        {
            var wait = new WebDriverWait(driver,TimeSpan.FromSeconds(defaultTimout));
            return wait.Until(condition);
        }
        public static void ClickElement(IWebDriver driver, By locator)
        {
            try
            {
                var element =Wait(driver,ExpectedConditions.ElementToBeClickable(locator));
                element.Click();

            }
            catch 
            {
                throw new Exception($"ko thể click vào {locator} ");
            }
        }
        public static void sendkey(IWebDriver driver,string key,By locator)
        {
            try
            {
                var element = Wait(driver,ExpectedConditions.ElementIsVisible(locator));
                element.Clear();
                element.SendKeys(key);
            }
            catch 
            {
                throw new Exception($"ko thể nhập vào {locator} ");
            }
        }
        public static void SelectDropdownByValue(IWebDriver driver, By locator, string value)
        {
            var dropdown = new SelectElement(driver.FindElement(locator));
            dropdown.SelectByValue(value);
        }

        public static void SelectDropdownByVisibleText(IWebDriver driver,By locator, string text)
        {
            var dropdown = new SelectElement(driver.FindElement(locator));
            dropdown.SelectByText(text);
        }
        public static void ScrollToElement(IWebDriver driver, By locator)
        {
            try
            {
                var element = driver.FindElement(locator);
                ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            }
            catch (NoSuchElementException)
            {
                throw new Exception($"Không tìm thấy phần tử để scroll tới: {locator}");
            }
        }
        public static void HoverAndClick(IWebDriver driver, By hoverTarget, By clickTarget)
        {
            Actions actions = new Actions(driver);
            var hoverElement = driver.FindElement(hoverTarget);
            actions.MoveToElement(hoverElement).Perform();
            FuntionHelper.ClickElement(driver, clickTarget);
        }
    }
}
