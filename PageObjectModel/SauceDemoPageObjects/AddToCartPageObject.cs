using OpenQA.Selenium;
using SauceDemo.PageObjectModel.Drivers;
using SauceDemo.PageObjectModel.SauceDemoTestCase;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo.PageObjectModel.SauceDemoPageObjects
{
    public class AddToCartPageObject
    {
        public IWebDriver _driver;

        [FindsBy(How = How.XPath, Using = AddToCardByXpath)]
        private IWebElement _AddToCardBtn;
        [FindsBy(How = How.Id, Using = ShoppingCartIconById)]
        private IWebElement _ShoppingCartIcon;
        [FindsBy(How = How.XPath, Using = ProductAddedToCartByXpath)]
        private IWebElement _ProductAddedToCart;
        [FindsBy(How = How.XPath, Using = RemoveProductFromCartByXpath)]
        private IWebElement _RemoveProductFromCart;

        [FindsBy(How = How.XPath, Using = HeaderLabelInCartPageByXpath)]
        private IWebElement _HeaderLabelInCartPage;

        #region Locators for Add to Cart Page
        //public const string AddToCardByXpath = "//button[@id='add-to-cart-sauce-labs-backpack']";
        //public const string AddToCardByXpath = "//button[@id='{0}']"; 
        public const string AddToCardByXpath = "//div[text()='{0}']/../../../div[2]/button";

        public const string ShoppingCartIconById = "shopping_cart_container";

        public const string ProductAddedToCartByXpath = "//div[text()='{0}']";
        //public const string ProductAddedToCartByXpath= "//div[text()='Sauce Labs Backpack']";

        //public const string RemoveProductFromCartByXpath = "//button[text()='Remove']";
        public const string RemoveProductFromCartByXpath = "//div[text()='{0}']/../../div[2]/button";

        public const string HeaderLabelInCartPageByXpath = "//div[@class='header_label']/div[text()='{0}']";

        #endregion

        public AddToCartPageObject(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }

       /* public void AddToCart()
        {
            LoginPageObject Login = new LoginPageObject(_driver);
            Login.LoginToSauceDemo("visual_user", "secret_sauce");
            *//*LoginTest LT = new LoginTest();
            LT.Verify_Login_with_Valid_Crendential();*//*
            _AddToCardBtn.Click();
        }*/
       
        public void AddProductToCart(string productname)
        {
            LoginPageObject Login = new LoginPageObject(_driver);
            Login.LoginToSauceDemo("visual_user", "secret_sauce");
            // Construct the dynamic XPath by formatting the template with the provided buttonId
            string dynamicXPath = string.Format(AddToCardByXpath, productname);
            _AddToCardBtn = _driver.FindElement(By.XPath(dynamicXPath));
            _AddToCardBtn.Click();
            Console.WriteLine($"{productname} has been added to cart");
        }
        public void ViewShoppingCartList()
        {
            _ShoppingCartIcon.Click();
            Console.WriteLine("User is redirected to product list that has been added into Cart");
        }

        public bool IsProductAddedToCart(string productname)
        {
            string dynamicXPath = string.Format(ProductAddedToCartByXpath, productname);
            _ProductAddedToCart = _driver.FindElement(By.XPath(dynamicXPath));
            if (_ProductAddedToCart != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool IsProductPresentInTheCart(string productname)
        {
            string dynamicXPath = string.Format(ProductAddedToCartByXpath, productname);
            _ProductAddedToCart = _driver.FindElement(By.XPath(dynamicXPath));
            if (_ProductAddedToCart != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsHeaderPresentAfterSuccessfulLogin(string text)
        {
            string dynamicXPath = string.Format(HeaderLabelInCartPageByXpath, text);
            _HeaderLabelInCartPage = _driver.FindElement(By.XPath(dynamicXPath));
            if (_HeaderLabelInCartPage != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void RemoveProductFromCart(string productname)
        {
            string dynamicXPath = string.Format(RemoveProductFromCartByXpath, productname);
            _RemoveProductFromCart = _driver.FindElement(By.XPath(dynamicXPath));
            _RemoveProductFromCart.Click();
            Console.WriteLine($"{productname} Removed from Cart");
        }

    }
}
