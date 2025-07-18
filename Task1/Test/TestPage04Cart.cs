using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Task1.Base;
using Task1.Page;

namespace Task1.Test
{
    [TestClass]
    public class TestPage04Cart : WebSetup
    {
        PageAddCart pagecart = new PageAddCart(driver);
        [TestMethod]
        public void TestCart01Search()
        {
            pagecart.ClickToCartAndSearch();
        }
        [TestMethod]
        public void TestCart02KoDu10SP()
        {
            pagecart.ClickToCartAndRemoveKoDu10SP();
        }
        [TestMethod]
        public void TestCart03Du10Sp()
        {
            pagecart.ClickToCartAndRemove();
        }
    }
}
