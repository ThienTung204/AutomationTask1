using OpenQA.Selenium;
using System;
using System.Threading;
using Task1.Base;
using Task1.Helper;
using Task1.Reports;

public class PageSignUp
{
    private readonly IWebDriver driver;

    public PageSignUp(IWebDriver driver)
    {
        this.driver = driver;
    }

    // ---------- Locators ----------
    private By buttonLogin = By.CssSelector("#header > div > div > div > div.col-sm-8 > div > ul > li:nth-child(4) > a");
    private By name = By.Name("name");
    private By email = By.CssSelector("#form > div > div > div:nth-child(3) > div > form > input[type=email]:nth-child(3)");
    private By buttonSignUp = By.CssSelector("#form > div > div > div:nth-child(3) > div > form > button");
    private By male = By.Id("id_gender1");
    private By female = By.Id("id_gender2");
    private By password = By.Id("password");
    private By firstName = By.Id("first_name");
    private By lastName = By.Id("last_name");
    private By selectDay = By.Id("days");
    private By selectMonth = By.Id("months");
    private By selectYear = By.Id("years");
    private By inputCompany = By.Id("company");
    private By inputAddress1 = By.Id("address1");
    private By inputAddress2 = By.Id("address2");
    private By inputState = By.Id("state");
    private By inputCity = By.Id("city");
    private By inputZipcode = By.Id("zipcode");
    private By inputPhone = By.Id("mobile_number");
    private By checkbox1 = By.Id("newsletter");
    private By checkbox2 = By.Id("optin");
    private By selectCountry = By.Id("country");
    private By buttonCreate = By.CssSelector("#form > div > div > div > div.login-form > form > button");
    private By buttonContinue = By.CssSelector("#form > div > div > div > div > a");

    // ---------- Hành động riêng biệt ----------

    public void ClickLoginButton()
    {
        FuntionHelper.ClickElement(driver, buttonLogin);
        ExtentReporting.LogInfo("Clicked Login button");

        if (!FuntionHelper.KiemTraURL(driver, URL.login))
        {
            throw new Exception("Không phải trang login! URL hiện tại: " + driver.Url);
        }
    }

    public void EnterName(string userName)
    {
        FuntionHelper.sendkey(driver, userName, name);
    }

    public void EnterEmail(string emailValue)
    {
        FuntionHelper.sendkey(driver, emailValue, email);
    }

    public void ClickSignUpButton()
    {
        FuntionHelper.ClickElement(driver, buttonSignUp);
        Thread.Sleep(1000);
    }

    public void VerifyOnSignUpPage()
    {
        if (!FuntionHelper.KiemTraURL(driver, URL.signup))
        {
            throw new Exception("Không phải trang SignUp! URL hiện tại: " + driver.Url);
        }
    }

    public void FillAccountInformation()
    {
        if (Data.gender)
            FuntionHelper.ClickElement(driver, male);
        else
            FuntionHelper.ClickElement(driver, female);

        FuntionHelper.sendkey(driver, Data.password, password);
        FuntionHelper.SelectDropdownByValue(driver, selectDay, Data.date.Day.ToString());
        FuntionHelper.SelectDropdownByValue(driver, selectMonth, Data.date.Month.ToString());
        FuntionHelper.SelectDropdownByValue(driver, selectYear, Data.date.Year.ToString());

        FuntionHelper.ClickElement(driver, checkbox1);
        FuntionHelper.ClickElement(driver, checkbox2);
    }

    public void FillAddressInformation()
    {

        FuntionHelper.sendkey(driver, Data.LastName, lastName);
        FuntionHelper.sendkey(driver, Data.FirstName, firstName);
        FuntionHelper.sendkey(driver, Data.company, inputCompany);
        FuntionHelper.sendkey(driver, Data.adress, inputAddress1);
        FuntionHelper.sendkey(driver, Data.adress, inputAddress2);
        FuntionHelper.sendkey(driver, Data.state, inputState);
        FuntionHelper.sendkey(driver, Data.city, inputCity);
        FuntionHelper.sendkey(driver, Data.zipcode.ToString(), inputZipcode);
        FuntionHelper.sendkey(driver, Data.phone, inputPhone);

        FuntionHelper.SelectDropdownByVisibleText(driver, selectCountry, Data.Country);
    }

    public void ClickCreateAccount()
    {
        FuntionHelper.ClickElement(driver, buttonCreate);
    }

    public void VerifyAccountCreated()
    {
        if (!FuntionHelper.KiemTraURL(driver, URL.created))
        {
            throw new Exception("Tạo tài khoản không thành công!");
        }
    }

    public void ClickContinueAfterCreate()
    {
        FuntionHelper.ClickElement(driver, buttonContinue);
    }

    // ---------- Kịch bản đã gom ----------

    public void SignUp()
    {
        ClickLoginButton();
        EnterName(Data.Name);
        EnterEmail(Data.Email);
        ClickSignUpButton();
        VerifyOnSignUpPage();
        FillAccountInformation();
        FillAddressInformation();
        ClickCreateAccount();
        VerifyAccountCreated();
        ClickContinueAfterCreate();
    }

    public void SignUpFail1()
    {
        ClickLoginButton();
        EnterName(Data.Name); // Không nhập email
        ClickSignUpButton();
        ExtentReporting.LogScreenshot(driver, AventStack.ExtentReports.Status.Fail, "SignUpFail1 - thiếu email");
        driver.Navigate().Refresh();
    }

    public void SignUpFail2()
    {
        ClickLoginButton();
        EnterEmail(Data.Email); // Không nhập tên
        ClickSignUpButton();
        ExtentReporting.LogScreenshot(driver, AventStack.ExtentReports.Status.Fail, "SignUpFail2 - thiếu tên");
        driver.Navigate().Refresh();
    }
}
