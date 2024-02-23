using SauceDemo.PageObjectModel.CustomCommands;
using SauceDemo.PageObjectModel.Drivers;
using SauceDemo.PageObjectModel.SauceDemoPageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo.PageObjectModel.SauceDemoTestCase
{
    public class AddToCartTest:Driver
    {
        [Test]
        public void Verify_user_is_able_perform_AddToCart_Fuctionality()
        {
            StringFormatter.PrintMessage($"Verify product will be successfully added to cart");
            AddToCartPageObject AddToCartPage = new AddToCartPageObject(_driver);
            try
            {
                //AddToCartPage.AddProductToCart("add-to-cart-sauce-labs-backpack");
                AddToCartPage.AddProductToCart("Sauce Labs Backpack");
                AddToCartPage.ViewShoppingCartList();
                AddToCartPage.IsProductPresentInTheCart("Sauce Labs Backpack").ShouldBeTrue("'Sauce Labs Backpack' is present in cart");
            }
            finally
            {
                AddToCartPage.RemoveProductFromCart("Sauce Labs Backpack");
            }
            
        }
    }
}
