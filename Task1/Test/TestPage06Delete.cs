using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using Task1.Base;
using Task1.Page;

namespace Task1.Test
{
    [TestClass]
    public class TestPage06Delete : WebSetup
    {
        PageDeleteAndLogout delete = new PageDeleteAndLogout(driver);
        PageLogin pagelogin = new PageLogin(driver);

        [TestMethod]
        [Priority(12)]
        [TestCategory("06_Delete")]
        public void Test_06Delete01chualogin()
        {
            delete.LogoutAccount();
            Thread.Sleep(400);
            delete.deleteAccount();
        }

        [TestMethod]
        [Priority(13)]
        [TestCategory("06_Delete")]
        public void Test_06Delete02daLogin()
        {
            pagelogin.login(Data.Email, Data.password);
            delete.deleteAccount();
        }
    }
}
