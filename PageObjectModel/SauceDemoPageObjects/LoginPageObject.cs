using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo.PageObjectModel.SauceDemoPageObjects
{
    public class LoginPageObject
    {
        //moved to driver class and inherited 'Driver' class
        //create class variable for webdriver object
        public IWebDriver _driver;

        #region class variable for login page elements
        //to initialize the page object using page factory we use "FindsByAttribute"
        [FindsBy(How = How.XPath, Using = usernameXpath)]
        private IWebElement _username;
        [FindsBy(How = How.XPath, Using = passwordXpath)]
        private IWebElement _password;
        [FindsBy(How = How.XPath, Using = loginBtnXpath)]
        private IWebElement _loginBtn;

        #endregion

        #region Xpath for Login page elements
        public const string usernameXpath = "//input[@id='user-name']";
        public const string passwordXpath = "//input[@id='password']";
        public const string loginBtnXpath = "//input[@id='login-button']";

        #endregion

        //create constructor to initialize object of this class and in the constructor we initialize web driver object which can be passed in constructor arguments
        public LoginPageObject(IWebDriver driver) //IWebDriver driver argument removed from method
        {
            //moved to driver class and inherited 'Driver' class
            //initialze webdriver object of this class
            _driver = driver;

            //to intilialize page factory with web driver object use below method (this will initialize web driver object and  page element will be searched by using same web driver object
            PageFactory.InitElements(driver, this);  //'driver' replaced by '_driver'
        }
        public void LoginToSauceDemo(string username, string password)
        {
            _username.SendKeys(username);
            _password.SendKeys(password);
            _loginBtn.Click();
        }

        /* public bool IsDashboardTextPresentAfterLogin(string text)
         {
             *//*string.Format(dasboardtextXpath, text, How.XPath);
             return true;*//*
             // Construct dynamic XPath for dashboard text based on the provided text
             string dynamicXPath = string.Format(dasboardtextXpath, text);

             // Find the dashboard text element using the dynamic XPath
             IWebElement element = _driver.FindElement(By.XPath(dynamicXPath));

             // Return true if the element is found, false otherwise
             return element != null;
         }*/
    }
}
