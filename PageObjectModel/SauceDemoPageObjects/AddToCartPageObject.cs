using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SauceDemo.PageObjectModel.Drivers;
using SauceDemo.PageObjectModel.SauceDemoTestCase;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;
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

        #region Locators for Add to Cart Page

        public const string AddToCardByXpath = "//div[text()='{0}']/../../../div[2]/button";

        public const string ShoppingCartIconById = "shopping_cart_container";

        public const string ProductAddedToCartByXpath = "//div[text()='{0}']";

        public const string RemoveProductFromCartByXpath = "//div[text()='{0}']/../../div[2]/button";

        public const string AppLogoInCartPageByXpath = "//div[@class='header_label']/div[text()='{0}']";

        public const string AddedProductCountByXpath = "//div[@id='shopping_cart_container']/a/span";

        public const string ProductPriceByXpath = "//div[@class='inventory_item_price']";

        public const string ProductSortingIconByXpath =  "//select[@class='product_sort_container']";

        public const string ProductSortingOptionsByXpath = "//select[@class='product_sort_container']/option[text()='{0}']";

        public const string ContinueShoppingButtonByXpath = "//button[@id='continue-shopping']";

        #endregion

        public AddToCartPageObject(IWebDriver driver)
        {
            _driver = driver;
            PageFactory.InitElements(driver, this);
        }
        public void NavigateToAddToCartPage()
        {
            LoginPageObject Login = new LoginPageObject(_driver);
            Login.LoginToSauceDemo("visual_user", "secret_sauce");
            Console.WriteLine("User is navigated to AddToCart Page");
        }
        public void ClickOnAddToCartButton(string productname)
        {
            string dynamicXPath = string.Format(AddToCardByXpath, productname);
            var addToCartButton = _driver.FindElement(By.XPath(dynamicXPath));
            // Wait for the button to be clickable
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(addToCartButton));

            addToCartButton.Click();
            Console.WriteLine($"Clicked on 'Add to cart' for '{productname}'");
        }
        public void ClickOnMyCartIcon()
        {
            _driver.FindElement(By.Id(ShoppingCartIconById)).Click();
            Console.WriteLine("User is redirected to product list that has been added into Cart");
        }

        public bool IsProductAddedToCart(string productname)
        {
            string dynamicXPath = string.Format(ProductAddedToCartByXpath, productname);
            _driver.FindElement(By.XPath(dynamicXPath));
            if (_driver.FindElement(By.XPath(dynamicXPath)) != null)
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
            try
            {
                _driver.FindElement(By.XPath(dynamicXPath));
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }


        public bool IsAppLogoPresentAfterSuccessfulLogin(string text)
        {
            string dynamicXPath = string.Format(AppLogoInCartPageByXpath, text);
            _driver.FindElement(By.XPath(dynamicXPath));
            if (_driver.FindElement(By.XPath(dynamicXPath)) != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public string GetNumberOfAddedProductFromCartIcon()
        {
             return _driver.FindElement(By.XPath(AddedProductCountByXpath)).Text;
        }
        public void ClickOnRemoveButton(string productname)
        {
            string dynamicXPath = string.Format(RemoveProductFromCartByXpath, productname);
            _driver.FindElement(By.XPath(dynamicXPath)).Click();
            Console.WriteLine($"Click on 'Remove' buttton for '{productname}' from the list");
        }
        public void ClickOnContinueShoppingButton()
        {
            _driver.FindElement(By.XPath(ContinueShoppingButtonByXpath)).Click();
            Console.WriteLine("Click on ContinueShopping");
        }

        public List<string> GetProductPrices()
        {
            var priceList = _driver.FindElements(By.XPath(ProductPriceByXpath));
            return priceList.Select(price => price.Text.Replace("$", "")).ToList();
        }


        public void ClickOnProductSortingIcon()
        {
            _driver.FindElement(By.XPath(ProductSortingIconByXpath)).Click();
            Console.WriteLine("Click on product sorting icon");
        }

        public void ClickOnProductSortingOption(string option)
        {
            string dynamicXpath = string.Format(ProductSortingOptionsByXpath, option);
             _driver.FindElement(By.XPath(dynamicXpath)).Click();
            Console.WriteLine($"Click on product sorting option '{option}'");

        }
    }
}
