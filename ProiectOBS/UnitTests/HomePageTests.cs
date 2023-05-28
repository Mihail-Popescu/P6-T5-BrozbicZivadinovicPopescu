using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UnitTests
{
    [TestFixture]
    public class HomePageTests
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
        public void TestCarousel()
        {
            // Open the homepage
            driver.Navigate().GoToUrl("https://localhost:7000");
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));

            // Assert the presence of the carousel
            Assert.IsTrue(IsElementPresent(By.Id("carousel")));


            
        }

        [Test]
        public void TestImageVisibility()
        {
            // Open the homepage
            driver.Navigate().GoToUrl("https://localhost:7000");
            System.Threading.Thread.Sleep(TimeSpan.FromSeconds(2));

            // Assert the presence of images in the body section
            Assert.IsTrue(IsElementPresent(By.CssSelector("logo_1")));
            Assert.IsTrue(IsElementPresent(By.CssSelector("logo_2")));
            Assert.IsTrue(IsElementPresent(By.CssSelector("logo_3")));

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