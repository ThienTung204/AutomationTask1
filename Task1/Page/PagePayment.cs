using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1.Base;
using Task1.Helper;
using Task1.Reports;

namespace Task1.Page
{
    public class PagePayment
    {
        IWebDriver driver;
        PageAddCart pageCart;
        PageLogin login;
        public PagePayment(IWebDriver driver)
        {
            this.driver = driver;
            pageCart = new PageAddCart(driver);
            login = new PageLogin(driver);
               
        }
        By buttonpayment = By.XPath("//*[@id=\"do_action\"]/div[1]/div/div/a");
        By buttonLogin = By.XPath("//*[@id=\"checkoutModal\"]/div/div/div[2]/p[2]/a");
        By buttonplace = By.XPath("//*[@id=\"cart_items\"]/div/div[7]/a");
        By textMessage = By.Name("message");
        By TextName = By.Name("name_on_card");
        By TextCard = By.Name("card_number");
        By CVC = By.Name("cvc");
        By Expiration = By.Name("expiry_month");
        By Expirationyear = By.Name("expiry_year");
        By submit = By.Id("submit");
        By buttonDone = By.XPath("//*[@id=\"form\"]/div/div/div/div/a");

        public void ClickPayment()
        {
            pageCart.ClickCartIcon();
            if (pageCart.KiemTraGioHang())
            {
                ExtentReporting.LogFail("Không có sản phẩm trong giỏ hàng ");
            }
            else
            {
                if(login.submitLogin())
                    FuntionHelper.ClickElement(driver, buttonpayment);
                else
                {
                    FuntionHelper.ClickElement(driver, buttonpayment);
                    FuntionHelper.ClickElement(driver, buttonLogin);
                }
            }
        }
        public void FillinMessage()
        {
            if (FuntionHelper.KiemTraURL(driver, URL.checkOut))
            {
                FuntionHelper.ScrollToElement(driver, textMessage);
                FuntionHelper.sendkey(driver, "Camr onw", textMessage);
                FuntionHelper.ClickElement(driver, buttonplace);
            }
            else ExtentReporting.LogFail("ko mở trang checkout thành công");

        }
        public void Fillinfo()
        {
            if (FuntionHelper.KiemTraURL(driver, URL.payment)) 
            { 
            FuntionHelper.sendkey(driver, Data.Name, TextName);
            FuntionHelper.sendkey(driver, Data.CardNumber, TextCard);
            FuntionHelper.sendkey(driver, Data.CVC, CVC);
            FuntionHelper.sendkey(driver, Data.Month, Expiration);
            FuntionHelper.sendkey(driver, Data.year, Expirationyear);
            FuntionHelper.ClickElement(driver, submit); 
            }
            else ExtentReporting.LogFail("ko mở trang payment thành công");
        }
        public void Done() 
        {
            if (FuntionHelper.KiemTraURL(driver, URL.paymentdone))
            {
                FuntionHelper.ClickElement(driver, buttonDone);
            }
            else ExtentReporting.LogFail("ko mở trang Paymentdone thành công");
        }
        public void paymentWithLogin()
        {
            login.login(Data.Email, Data.password);
            pageCart.ClickToCartAndSearch();
            ClickPayment();
            FillinMessage();
            Fillinfo();
        }
        

        
    }
}
