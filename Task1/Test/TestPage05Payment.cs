using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task1.Base;
using Task1.Page;

namespace Task1.Test
{
    [TestClass]
    public class TestPage05Payment :WebSetup
    {
        PagePayment payment = new PagePayment(driver);
        PageDeleteAndLogout delete = new PageDeleteAndLogout(driver);

        [TestMethod]
        public void TestPayment01()
        {
            payment.paymentWithLogin();
        }
       
    }
}
