using OpenQA.Selenium;
using SpecFlow_Demo_Project.Helpers;
using SpecFlow_Demo_Project.Model;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace SpecFlow_Demo_Project.Pages
{
    public class CartPage
    {
        private IWebDriver driver;
        private readonly string cartitemsCssSelector = ".woocommerce-cart-form__cart-item.cart_item";

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public int GetTotalNumberOfItemsListedIntheCart()
        {
            IList<IWebElement> items = driver.FindElements(By.CssSelector(cartitemsCssSelector));
            
            return items.Count;
        }

        public Product GetLowestPriceItemIntheCart()
        {
            IList<IWebElement> items = driver.FindElements(By.CssSelector(cartitemsCssSelector));
            List<Product> products = new();

            foreach (var item in items)
            {
                var itemPrice = item.FindElement(By.CssSelector(".product-price")).Text;

                var itemName = item.FindElement(By.CssSelector(".product-remove > a")).GetAttribute("data-product_sku");                

                var price = decimal.Parse(itemPrice, NumberStyles.Currency);

                products.Add(new()
                { 
                    Name = itemName, Price = price 
                });
            }

            var lowestPriceItem = products.OrderBy(p => p.Price).First();

            return lowestPriceItem;
        }

        public void RemoveItemFromCart(string itemName)
        {
            var productNameCssSelector = $"a[data-product_sku='{itemName}']";
            SeleniumHelper.ElementExists(By.CssSelector(productNameCssSelector)).Click();
            SeleniumHelper.VerifyNotVisible(By.CssSelector(productNameCssSelector));
        }
    }    
}
