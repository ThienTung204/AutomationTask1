using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.Base;
using Task1.Page;

namespace Task1.Test
{
    [TestClass]
    public class TestPage01SignUp : WebSetup
    {
        PageSignUp signUp = new PageSignUp(driver);

        [TestMethod]
        [Priority(1)]
        [TestCategory("01_SignUp")]
        public void TestSignUp1()
        {
            signUp.SignUpFail1();
        }

        [TestMethod]
        [Priority(2)]
        [TestCategory("01_SignUp")]
        public void TestSignUp2()
        {
            signUp.SignUpFail2();
        }

        [TestMethod]
        [Priority(3)]
        [TestCategory("01_SignUp")]
        public void TestSignUp3()
        {
            signUp.SignUp();
        }
    }
}
