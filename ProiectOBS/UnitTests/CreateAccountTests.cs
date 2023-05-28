using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTests
{
    [TestFixture]
    public class CreateAccountTests
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
            // Open the Create Account page
            driver.Navigate().GoToUrl("https://localhost:7000/account/create");
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));

            // Assert the presence of text input forms
            Assert.IsTrue(IsElementPresent(By.CssSelector("input[type='text']")));

            // You can also capture a screenshot for debugging purposes
            // ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("text_forms_screenshot.png");
        }

        [Test]
        public void TestCreateAccountButton()
        {
            // Open the Create Account page
            driver.Navigate().GoToUrl("https://localhost:7000/account/create");
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));

            // Assert the presence of the "Create Account" button
            Assert.IsTrue(IsElementPresent(By.CssSelector("button[type='submit'][value='Create Account']")));

            // You can also capture a screenshot for debugging purposes
            // ((ITakesScreenshot)driver).GetScreenshot().SaveAsFile("create_account_button_screenshot.png");
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