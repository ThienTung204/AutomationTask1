using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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
        public void TestDelete01chualogin() 
        {
            delete.LogoutAccount();
            Thread.Sleep(400);
            delete.deleteAccount();

        }
        [TestMethod]
        public void TestDelete02daLogin() 
        {
            pagelogin.login(Data.Email, Data.password);
            delete.deleteAccount();

        }
    }
}
