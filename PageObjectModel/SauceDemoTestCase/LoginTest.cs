using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SauceDemo.PageObjectModel.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SauceDemo.PageObjectModel.SauceDemoPageObjects;
using SauceDemo.PageObjectModel.CustomCommands;

namespace SauceDemo.PageObjectModel.SauceDemoTestCase
{
    public class LoginTest : Driver
    {
        [Test]
        public void Verify_Login_Functionality()
        {
            
            LoginPageObject LoginPage = new LoginPageObject(_driver);
            AddToCartPageObject AddToCartPage = new AddToCartPageObject(_driver);

            StringFormatter.PrintMessage("Verify Login functionality with valid credential");
            LoginPage.LoginToSauceDemo("visual_user", "secret_sauce");
            /*WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2));
            IWebElement element = wait.Until(SeleniumExtras
                .WaitHelpers.ExpectedConditions.ElementIsVisible(By.XPath("//div[text()='Swag Labs']")));
            Assert.IsTrue(element.Displayed);*/
            Thread.Sleep(2000);
            AddToCartPage.IsHeaderPresentAfterSuccessfulLogin("Swag Labs").ShouldBeTrue("'Swag Labs' must be present after successful login");
            //Console.WriteLine("'Swag Labs' text is visible");
        }
    }
}
