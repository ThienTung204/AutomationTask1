using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task1.Base;
using Task1.Page;
using Task1.Reports;

namespace Task1.Test
{
    [TestClass]
    public class TestPage02LogOut : WebSetup
    {
        
        
        PageDeleteAndLogout delete = new PageDeleteAndLogout(driver);
        PageLogin pagelogin = new PageLogin(driver);


        [TestMethod]
        public void TestLogOut02ChuaLogin()
        {
            delete.LogoutAccount();
            ExtentReporting.LogScreenshot(driver, AventStack.ExtentReports.Status.Fail, "Chưa đăng nhập nên ko logOut đc");
        }
        [TestMethod]
        public void TestLogOut01daLogin()
        {
            delete.LogoutAccount();
        }
    }
}
