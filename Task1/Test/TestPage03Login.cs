using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.Base;
using Task1.Page;

namespace Task1.Test
{
    [TestClass]
    public class TestPage03Login : WebSetup
    {
        PageLogin pagelogin = new PageLogin(driver);

        [TestMethod]
        [Priority(6)]
        [TestCategory("03_Login")]
        public void Test_03Login01ChuacoTK()
        {
            pagelogin.login(Data.Email1, Data.password1);
        }

        [TestMethod]
        [Priority(7)]
        [TestCategory("03_Login")]
        public void Test_03Login02dacoTk()
        {
            pagelogin.login(Data.Email, Data.password);
        }
    }
}
