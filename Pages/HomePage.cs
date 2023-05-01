using OpenQA.Selenium;
using SpecFlow_Demo_Project.Helpers;

namespace SpecFlow_Demo_Project.Pages
{
    public class HomePage
    {
        private IWebDriver driver;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }
        
        public void AddItemToCart(string item)
        {
            SeleniumHelper.ElementExists(By.CssSelector($"a[data-product_sku='{item}']")).Click();
            SeleniumHelper.VerifyVisible(By.CssSelector($"a[data-product_sku='{item}']+a[title='View cart']"));
        }

        public CartPage NavigateToCartPage()
        {
            SeleniumHelper.ElementExists(By.CssSelector("a[href='https://cms.demo.katalon.com/cart/']")).Click();

            return new CartPage(driver);
        }
    }
}
