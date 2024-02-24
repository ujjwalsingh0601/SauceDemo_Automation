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
        public void Verify_Login_Functionality_With_Valid_Invalid_Credential()
        {
            List<string> ValidCredential = new List<string> { "visual_user", "secret_sauce" };
            List<string> InvalidCredential = new List<string> { "test", "test" };

            LoginPageObject LoginPage = new LoginPageObject(_driver);
            AddToCartPageObject AddToCartPage = new AddToCartPageObject(_driver);
            PageUtils pageUtils = new PageUtils(_driver);

            // Print a message indicating the test scenario
            StringFormatter.PrintMessage("Verification of Login functionality with invalid credential");
            //Login with invalid credential
            LoginPage.LoginToSauceDemo(InvalidCredential[0], InvalidCredential[1]);
            //Assert whether login error message is shown for invalid credential
            LoginPage.IsLoginErrorMessagePresent().ShouldBeTrue("Invalid Login error message must be present");

            // Print a message indicating the test scenario
            StringFormatter.PrintMessage("Verification of Login functionality with valid credential");
            //Reload the page inorder to reset the default state of the page
            pageUtils.ReloadPage();
            //Login with valid credential
            LoginPage.LoginToSauceDemo(ValidCredential[0], ValidCredential[1]);
            //Assert whether login is successful by verifying App logo 'Swag Labs' is present in the product page
            AddToCartPage.IsAppLogoPresentAfterSuccessfulLogin("Swag Labs")
                .ShouldBeTrue("'Swag Labs' title must be present to confirm that login is successful");
        }
    }
}
