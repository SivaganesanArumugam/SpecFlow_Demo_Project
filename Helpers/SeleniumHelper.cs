using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;

namespace SpecFlow_Demo_Project.Helpers
{
    public static class SeleniumHelper
    {
        private static WebDriverWait _wait;
        private static IWebDriver _driver;

        public static void Init(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
        }

        public static IWebElement ElementExists(By by)
        {
            _wait.Message = "Element was not found.";
            return _wait.Until(ExpectedConditions.ElementExists(by));
        }

        public static IWebElement ElementVisible(By by)
        {
            _wait.Message = "Element was not found.";
            return _wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public static void VerifyVisible(By by)
        {
            _wait.Message = "Element was not found.";
            _wait.Until(ExpectedConditions.ElementIsVisible(by));
        }

        public static void VerifyNotVisible(By by)
        {
            _wait.Message = "Element was found.";
            _wait.Until(ExpectedConditions.InvisibilityOfElementLocated(by));
        }
    }
}
