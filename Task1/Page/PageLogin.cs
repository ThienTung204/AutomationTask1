using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Base;
using Task1.Helper;
using Task1.Reports;

namespace Task1.Page
{
    public class PageLogin
    {
        private IWebDriver driver;
        public PageLogin(IWebDriver driver)
        {
            this.driver = driver;
        }
        private By buttonlogin => By.CssSelector("#header > div > div > div > div.col-sm-8 > div > ul > li:nth-child(4) > a");
        private By email => By.Name("email");
        private By password => By.Name("password");
        private By submitlogin => By.CssSelector("#form > div > div > div.col-sm-4.col-sm-offset-1 > div > form > button");

        public void login(String TK, String PW)
        {
            ClickLoginButton();
            EnterEmail(TK);
            EnterPassword(PW);
            ExtentReporting.LogInfo("Opened website");
            FuntionHelper.ClickElement(driver, submitlogin);
            if (!submitLogin())
            {
                throw new Exception("Login ko thành công");
            }

        }
        public void ClickLoginButton()
        {
            FuntionHelper.ClickElement(driver, buttonlogin);
            ExtentReporting.LogInfo("Clicked Login button");

            if (!FuntionHelper.KiemTraURL(driver, URL.login))
            {
                ExtentReporting.LogFail("URL ko đúng");
                throw new Exception("Không phải trang login! URL hiện tại: " + driver.Url);
            }
        }

        public void EnterEmail(string emailValue)
        {
            driver.FindElement(email).Clear();
            FuntionHelper.sendkey(driver, emailValue, email);
        }

        public void EnterPassword(string passwordValue)
        {
            driver.FindElement(password).Clear();
            FuntionHelper.sendkey(driver, passwordValue, password);
        }
        public bool submitLogin()
        {
            try
            {
                var TextLogin = driver.FindElement(By.CssSelector("#header > div > div > div > div.col-sm-8 > div > ul > li:nth-child(10) > a > b"));
                String test = TextLogin.Text;
                return test.Equals(Data.Name);
            }
            catch (NoSuchElementException)
            {
                ExtentReporting.LogFail("Chưa login");
                return false;
            }
        }
    }
}
