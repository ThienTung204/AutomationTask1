using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Threading;
using Task1.Base;
using Task1.Helper;
using Task1.Reports;

namespace Task1.Page
{
    public class PageAddCart
    {
        private IWebDriver driver;

        public PageAddCart(IWebDriver driver)
        {
            this.driver = driver;
        }
        //------------------
        private By buttonHere = By.CssSelector("#empty_cart > p > a");//
        private By buttonProduct = By.CssSelector("#header > div > div > div > div.col-sm-8 > div > ul > li:nth-child(2) > a");//
        private By buttonAdd = By.XPath("/html/body/section[2]/div/div/div[2]/div[1]/div[2]/div/div[1]/div[2]/div/a");
        private By buttonContinue = By.XPath("//*[@id=\"cartModal\"]/div/div/div[3]/button");//
        private By buttonViewCart = By.XPath("//*[@id=\"cartModal\"]/div/div/div[2]/p[2]/a");//
        private By Div1 = By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/div");
        private By buttonAddGreen = By.XPath("/html/body/section/div/div/div[2]/div[2]/div[2]/div/span/button");//
        private By buttonCart = By.CssSelector("#header > div > div > div > div.col-sm-8 > div > ul > li:nth-child(3) > a");//
        private By searchBox = By.Id("search_product");//
        private By buttonView = By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/div/div[2]/ul/li/a");//ViewDetail
        private By buttonSubmitSearch = By.Id("submit_search");//
        private By DivGreen = By.XPath("/html/body/section[2]/div/div/div[2]/div/div[2]/div");//
       // ------------------------------------------
        public bool KiemTraGioHang()
        {
            try
            {
                var emptyCartElement = driver.FindElement(By.Id("empty_cart"));
                var cartTable = driver.FindElement(By.Id("cart_info"));
                bool isEmptyVisible = emptyCartElement.Displayed && emptyCartElement.GetAttribute("style").Contains("display: block");
                bool isTableHidden = !cartTable.Displayed || cartTable.GetAttribute("style").Contains("display: none");
                return isEmptyVisible && isTableHidden;
            }
            catch (NoSuchElementException)
            {
                throw new Exception("Không tìm thấy giỏ hàng.");
            }
        }

        public void ClickCartIcon()
        {
            FuntionHelper.ClickElement(driver, buttonCart);
            if (!FuntionHelper.KiemTraURL(driver, URL.cart))
            {
                ExtentReporting.LogFail("URL ko đúng");
                throw new Exception("Không phải trang cart! URL hiện tại: " + driver.Url);
            }
        }

        public void GoToProduct()
        {
            if (KiemTraGioHang())
                FuntionHelper.ClickElement(driver, buttonHere);
            else
                Product();
        }

        public void SearchProduct(string productName)
        {
            FuntionHelper.sendkey(driver, productName, searchBox);
            FuntionHelper.ClickElement(driver, buttonSubmitSearch);
            Thread.Sleep(1000);
        }

        public void AddProductGreenAfterSearch()
        {
            FuntionHelper.ScrollToElement(driver, DivGreen);
            ExtentReporting.LogScreenshot(driver, AventStack.ExtentReports.Status.Info, "Tìm thành công");
            FuntionHelper.ClickElement(driver, buttonView);
            FuntionHelper.ClickElement(driver, buttonAddGreen);
        }

        public void ViewCart()
        {
            FuntionHelper.ClickElement(driver, buttonViewCart);
        }
        public void Continue()
        {
            FuntionHelper.ClickElement(driver, buttonContinue);
        }
        public void Product()
        {
            FuntionHelper.ClickElement(driver, buttonProduct);
        }
       

        public void ClickToCartAndSearch()
        {
            ClickCartIcon();
            GoToProduct();
            SearchProduct("green");
            AddProductGreenAfterSearch();
            ViewCart();
        }
        public void ClickToCartAndRemove()
        {
            ClickCartIcon();
            GoToProduct();
            Add10Product();
            ExtentReporting.LogScreenshot(driver, AventStack.ExtentReports.Status.Info, " có sản phẩm 10 số lượng");
            RemoveProductsGreaterThan10();
        }
        public void ClickToCartAndRemoveKoDu10SP()
        {
            ClickCartIcon();
            GoToProduct();
            Add5Product();
            ExtentReporting.LogScreenshot(driver, AventStack.ExtentReports.Status.Info, "Không có sản phẩm nào 10");
            RemoveProductsGreaterThan10();
        }
        public void Add10Product()
        {
            SearchProduct("green");
            
            FuntionHelper.ScrollToElement(driver, DivGreen);
            FuntionHelper.ClickElement(driver, buttonView);
            FuntionHelper.sendkey(driver, "11", By.Id("quantity"));
            FuntionHelper.ClickElement(driver, buttonAddGreen);
            ViewCart();
        }
        public void Add5Product()
        {
            SearchProduct("green");
            
            FuntionHelper.ScrollToElement(driver, DivGreen);
            FuntionHelper.ClickElement(driver, buttonView);
            FuntionHelper.sendkey(driver, "5", By.Id("quantity"));
            FuntionHelper.ClickElement(driver, buttonAddGreen);
            ViewCart();
        }
        public void RemoveProductsGreaterThan10()
        {
            var cartRows = driver.FindElements(By.CssSelector("#cart_info_table tbody tr"));
            bool kiemtra = false;
            foreach (var row in cartRows)
            {
                try
                {
                    var quantityButton = row.FindElement(By.CssSelector("td.cart_quantity > button.disabled"));
                    int quantity = int.Parse(quantityButton.Text.Trim());

                    if (quantity > 10)
                    {
                        string productId = row.GetAttribute("id").Replace("product-", "");
                        By deleteButton = By.CssSelector($"a.cart_quantity_delete[data-product-id='{productId}']");
                        FuntionHelper.ClickElement(driver, deleteButton);
                        kiemtra = true;
                        Thread.Sleep(1000);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Lỗi khi xử lý hàng: {ex.Message}");
                }
            }
            if (!kiemtra) ExtentReporting.LogFail("Không có sản phẩm nào 10 ");   
        }
    }
}
