using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SauceDemo.PageObjectModel.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SauceDemo.PageObjectModel.SauceDemoPageObjects;

namespace SauceDemo.PageObjectModel.SauceDemoTestCase
{
    public class LoginTest : Driver
    {
        [Test]
        public void Verify_Login_with_Valid_Crendential()
        {
            LoginPageObject Login = new LoginPageObject(_driver);
            Thread.Sleep(2000);
            Login.LoginToSauceDemo("visual_user", "secret_sauce");
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            IWebElement element = wait.Until(SeleniumExtras
                .WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[text()='Swag Labs']")));
            Assert.IsTrue(element.Displayed);
            Console.WriteLine("'Swag Labs' text is visible");
        }
    }
}
