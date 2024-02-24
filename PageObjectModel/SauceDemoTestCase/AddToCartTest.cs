using SauceDemo.PageObjectModel.CustomCommands;
using SauceDemo.PageObjectModel.Drivers;
using SauceDemo.PageObjectModel.SauceDemoPageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo.PageObjectModel.SauceDemoTestCase
{
    public class AddToCartTest : Driver
    {
        [Test]
        public void Verify_user_is_able_Add_Product_To_Cart_And_Remove_From_Cart()
        {
            AddToCartPageObject AddToCartPage = new AddToCartPageObject(_driver);
            try
            {
                // Print a message indicating the test scenario
                StringFormatter.PrintMessage("Verification that product will be successfully added to cart");
                //Navigate to Product page
                AddToCartPage.NavigateToAddToCartPage();
                //Click on Add to cart button for the desired product
                AddToCartPage.ClickOnAddToCartButton("Sauce Labs Backpack");
                //Assert whether the total count of the product added to the cart is shown accurate in the cart icon 
                AddToCartPage.GetNumberOfAddedProductFromCartIcon().ToString().ShouldBeEqual("1", "Total product added count must be 1");
                //Click on Cart Icon. Clicking on the icon will navigate user to My Cart List
                AddToCartPage.ClickOnMyCartIcon();
                //Assert whether the product that has been added is present in My Cart List
                AddToCartPage.IsProductPresentInTheCart("Sauce Labs Backpack").ShouldBeTrue("'Sauce Labs Backpack' must be present in cart");

                // Print a message indicating the test scenario
                StringFormatter.PrintMessage("Verification that added product will be successfully removed from cart list");
                //Click on remove button for the desired product from My cart list. (Note: the mentioned product was added to My Cart earlier
                AddToCartPage.ClickOnRemoveButton("Sauce Labs Backpack");
                //Assert whether the product is not present in the My Cart List after clicking on remove button
                AddToCartPage.IsProductPresentInTheCart("Sauce Labs Backpack")
                    .ShouldBeFalse("'Sauce Labs Backpack' must be removed from cart list");
            }
            finally
            {
                AddToCartPage.ClickOnContinueShoppingButton();
            }

        }
        [Test]
        public void Verify_product_sorting_functionality_LowToHigh_HighToLow()
        {
            AddToCartPageObject AddToCartPage = new AddToCartPageObject(_driver);
            PageUtils pageUtil = new PageUtils(_driver);
            AddToCartPage.NavigateToAddToCartPage();

            // Print a message indicating the test scenario
            StringFormatter.PrintMessage("Verification of Product Sorting Options with 'Price Low to High'");
            // Click on the product sorting icon
            AddToCartPage.ClickOnProductSortingIcon();
            // Click on the sorting option 'Price (low to high)'
            AddToCartPage.ClickOnProductSortingOption("Price (low to high)");
            // Get the list of product prices after sorting
            List<string> pricesLowToHigh = AddToCartPage.GetProductPrices();
            // Assert whether the prices are ordered low to high
            IsOrdered(pricesLowToHigh, true).ShouldBeTrue("Product prices must be sorted low to high.");

            // Print a message indicating the test scenario
            StringFormatter.PrintMessage("Verify Product Sorting Options with 'Price High to Low'");
            //Reload the page inorder to reset the default state of the page
            pageUtil.ReloadPage();
            // Click on the product sorting icon
            AddToCartPage.ClickOnProductSortingIcon();
            // Click on the sorting option 'Price (high to low)'
            AddToCartPage.ClickOnProductSortingOption("Price (high to low)");
            // Get the list of product prices after sorting
            List<string> pricesHighToLow = AddToCartPage.GetProductPrices();
            // Assert whether the prices are ordered high to low
            IsOrdered(pricesHighToLow, false).ShouldBeTrue("Product prices must be sorted high to low.");

        }

        #region
        private bool IsOrdered(List<string> prices, bool lowToHigh)
        {
            for (int i = 0; i < prices.Count - 1; i++)
            {
                decimal currentPrice = decimal.Parse(prices[i]);
                decimal nextPrice = decimal.Parse(prices[i + 1]);

                if (lowToHigh)
                {
                    if (currentPrice > nextPrice)
                    {
                        return false; // If any price is greater than the next one, ordering is incorrect
                    }
                }
                else // High to Low
                {
                    if (currentPrice < nextPrice)
                    {
                        return false; // If any price is less than the next one, ordering is incorrect
                    }
                }
            }
            return true; // If all prices are in correct order
        }
        #endregion 



    }
}
