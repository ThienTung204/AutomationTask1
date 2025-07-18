using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task1.Base;
using Task1.Page;

namespace Task1.Test
{
    [TestClass]
    public class TestPage03Login : WebSetup
    {
        PageLogin pagelogin = new PageLogin(driver);
        [TestMethod]
        public void TestLogin02dacoTk()
        {
            pagelogin.login(Data.Email, Data.password);
        }
        [TestMethod]
        public void TestLogin01ChuacoTK()
        {
            pagelogin.login(Data.Email1, Data.password1);
            
        }
    }
}
