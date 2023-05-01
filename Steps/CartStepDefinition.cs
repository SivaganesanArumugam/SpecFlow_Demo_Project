using NUnit.Framework;
using OpenQA.Selenium;
using SpecFlow_Demo_Project.Model;
using SpecFlow_Demo_Project.Pages;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SpecFlow_Demo_Project.Steps
{
    [Binding]
    public sealed class CartStepDefinition
    {

        private readonly IWebDriver driver;
        private HomePage homePage;
        private CartPage cartPage;
        private Product product;

        public CartStepDefinition(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"Go to Home Page")]
        public void GivenGoToHomePage()
        {
            driver.Url = "https://cms.demo.katalon.com/";

            homePage = new HomePage(driver);
        }

        [Given(@"I add items to my cart")]
        public void GivenIAddItemsToMyCart(Table table)
        {
            var items = table.CreateSet<ItemsTestData>();

            foreach (var item in items)
            {
                homePage.AddItemToCart(item.ItemName);
            }
        }

        [When(@"I view my cart")]
        public void WhenIViewMyCart()
        {
            cartPage = homePage.NavigateToCartPage();
        }

        [Then(@"I verify total number of items listed in my cart '(.*)'")]
        public void ThenIFindTotalNumberOfItemsListedInMyCart(int expectedTotalNumberOfItems)
        {
            Assert.AreEqual(expected: expectedTotalNumberOfItems, actual: cartPage.GetTotalNumberOfItemsListedIntheCart());
        }

        [When(@"I search for lowest price item")]
        public void WhenISearchForLowestPriceItem()
        {
            product = cartPage.GetLowestPriceItemIntheCart();
        }

        [When(@"I am able to remove the lowest price item from my cart")]
        public void WhenIAmAbleToRemoveTheLowestPriceItemFromMyCart()
        {
            cartPage.RemoveItemFromCart(product.Name);
        }
    }

    public class ItemsTestData
    {
        public string ItemName { get; set; }
    }
}
