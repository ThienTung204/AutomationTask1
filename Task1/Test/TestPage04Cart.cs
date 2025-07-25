﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using Task1.Base;
using Task1.Page;

namespace Task1.Test
{
    [TestClass]
    public class TestPage04Cart : WebSetup
    {
        PageAddCart pagecart = new PageAddCart(driver);

        [TestMethod]
        [Priority(8)]
        [TestCategory("04_Cart")]
        public void Test_04Cart01Search()
        {
            pagecart.ClickToCartAndSearch();
        }

        [TestMethod]
        [Priority(9)]
        [TestCategory("04_Cart")]
        public void Test_04Cart02KoDu10SP()
        {
            pagecart.ClickToCartAndRemoveKoDu10SP();
        }

        [TestMethod]
        [Priority(10)]
        [TestCategory("04_Cart")]
        public void Test_04Cart03Du10Sp()
        {
            pagecart.ClickToCartAndRemove();
        }
    }
}
