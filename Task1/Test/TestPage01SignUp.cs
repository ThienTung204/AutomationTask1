using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task1.Base;
using Task1.Page;

namespace Task1.Test
{
    [TestClass]
    public class TestPage01SignUp : WebSetup
    {
       PageSignUp signUp = new PageSignUp(driver);
        [TestMethod]
        public void TestSignUp1()
        {
            signUp.SignUpFail1();
        }
        [TestMethod]
        public void TestSignUp2()
        {
            signUp.SignUpFail2();
        }
        [TestMethod]
        public void TestSignUp3()
        {
            signUp.SignUp();
        }
    }
}
