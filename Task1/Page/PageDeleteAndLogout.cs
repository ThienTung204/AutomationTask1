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
    public class PageDeleteAndLogout
    {
        IWebDriver driver;
        PageLogin login;
        private By buttondelete = By.CssSelector("#header > div > div > div > div.col-sm-8 > div > ul > li:nth-child(5) > a");
        private By buttonlogout = By.CssSelector("#header > div > div > div > div.col-sm-8 > div > ul > li:nth-child(4) > a");
        private By buttoncontinue = By.CssSelector("#form > div > div > div > div > a");
        public PageDeleteAndLogout(IWebDriver driver)
        {
            this.driver = driver;
            login = new PageLogin(driver);
        }

        public void deleteAccount(){

            if (login.submitLogin())
            {
                FuntionHelper.ClickElement(driver, buttondelete);
            }
            if (!FuntionHelper.KiemTraURL(driver, URL.deleted))
            {
                ExtentReporting.LogFail("xoa ko thanh cong");

                throw new Exception(" ko xóa thành công");
            }
            FuntionHelper.ClickElement(driver, buttoncontinue);
            Console.WriteLine("xoa thanh cong");

        }
        public void LogoutAccount(){
            if (login.submitLogin())
            {
                FuntionHelper.ClickElement(driver, buttonlogout);
            }
            
        }
    }
}
