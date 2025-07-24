using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        [Priority(4)]
        [TestCategory("02_LogOut")]
        public void TestLogOut01daLogin()
        {
            delete.LogoutAccount();
        }

        [TestMethod]
        [Priority(5)]
        [TestCategory("02_LogOut")]
        public void TestLogOut02ChuaLogin()
        {
            delete.LogoutAccount();
            ExtentReporting.LogScreenshot(driver, AventStack.ExtentReports.Status.Fail, "Chưa đăng nhập nên ko logOut đc");
        }
    }
}
