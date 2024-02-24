using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SauceDemo.PageObjectModel.CustomCommands;
using SauceDemo.PageObjectModel.Drivers;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo.PageObjectModel.SauceDemoPageObjects
{
    public class LoginPageObject
    {
        public IWebDriver _driver;

        #region Xpath for Login page elements
        public const string usernameXpath = "//input[@id='user-name']";
        public const string passwordXpath = "//input[@id='password']";
        public const string loginBtnXpath = "//input[@id='login-button']";
        public const string LoginErrorMessageXpath = "//div[@id='login_button_container']/div/form/div[3]/h3";
        #endregion


        public void EnterUsername(string username)
        {
            _driver.FindElement(By.XPath(usernameXpath)).SendKeys(username);
        }
        public void EnterPassword(string password)
        {
            _driver.FindElement(By.XPath(passwordXpath)).SendKeys(password);
        }
        public void ClickOnLoginButton()
        {
            _driver.FindElement(By.XPath(loginBtnXpath)).Click();
        }
        public LoginPageObject(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void LoginToSauceDemo(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
            ClickOnLoginButton();
            Console.WriteLine("Login into SauceDemo site");
        }

        public bool IsLoginErrorMessagePresent()
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10)); // Adjust the timeout as needed
                wait.Until(ExpectedConditions.ElementExists(By.XPath(LoginErrorMessageXpath)));
                return true;
            }
            catch (WebDriverTimeoutException)
            {
                return false;
            }

        }
    }
}
