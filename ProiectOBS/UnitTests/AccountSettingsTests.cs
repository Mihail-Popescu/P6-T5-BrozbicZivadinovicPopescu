using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTests
{
    [TestFixture]
    public class AccountSettingsTests
    {
        private IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Set up the WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [TearDown]
        public void TearDown()
        {
            // Quit the WebDriver
            driver.Quit();
        }

        [Test]
        public void TestTextForms()
        {
            // Open the Account Settings page
            driver.Navigate().GoToUrl("https://localhost:7000/Home/AccountSettings");
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));

            // Assert the presence of text input forms
            Assert.IsTrue(IsElementPresent(By.CssSelector("input[type='text']")));

        }

        [Test]
        public void TestSaveChangesButton()
        {
            // Open the Account Settings page
            driver.Navigate().GoToUrl("https://localhost:7000/Home/AccountSettings");
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));

            // Assert the presence of the "Save Changes" button
            Assert.IsTrue(IsElementPresent(By.CssSelector("button#save-changes")));

        }

        [Test]
        public void TestDeleteAccountButton()
        {
            // Open the Account Settings page
            driver.Navigate().GoToUrl("https://localhost:7000/Home/AccountSettings");
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));

            // Assert the presence of the "Delete Account" button
            Assert.IsTrue(IsElementPresent(By.CssSelector("button#delete-account")));

        }

        private bool IsElementPresent(By locator)
        {
            try
            {
                // Attempt to find the element
                driver.FindElement(locator);
                return true;
            }
            catch (NoSuchElementException)
            {
                // Element not found
                return false;
            }
        }
    }
}