using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace UnitTests
{
    [TestFixture]
    public class LayoutPageTests
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
        public void TestHeader()
        {
            // Open homepage
            driver.Navigate().GoToUrl("https://localhost:7000/");
            Thread.Sleep(TimeSpan.FromSeconds(2));

            // Assert presence of homepage elements
            Assert.IsTrue(IsElementPresent(By.LinkText("Homepage")));
            Assert.IsTrue(IsElementPresent(By.LinkText("Transactions")));
            Assert.IsTrue(IsElementPresent(By.LinkText("Help")));
            Assert.IsTrue(IsElementPresent(By.CssSelector("a.navbar-brand > img[src^='https://cdn-icons-png.flaticon.com/512/285/285850.png?w=826&t=st=1683727461~exp=1683728061~hmac=d6dcaa4c0cb80fd2b29fc1ae1e617deee59f630d561875b3819a309dcc6846d2']")));

            // Open transactions page
            driver.FindElement(By.LinkText("Transactions")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            // Assert presence of transactions page elements
            Assert.IsTrue(IsElementPresent(By.LinkText("Homepage")));
            Assert.IsTrue(IsElementPresent(By.LinkText("Transactions")));
            Assert.IsTrue(IsElementPresent(By.LinkText("Help")));
            Assert.IsTrue(IsElementPresent(By.CssSelector("a.navbar-brand > img[src^='https://cdn-icons-png.flaticon.com/512/285/285850.png?w=826&t=st=1683727461~exp=1683728061~hmac=d6dcaa4c0cb80fd2b29fc1ae1e617deee59f630d561875b3819a309dcc6846d2']")));

            // Open help page
            driver.FindElement(By.LinkText("Help")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            // Assert presence of help page elements
            Assert.IsTrue(IsElementPresent(By.LinkText("Homepage")));
            Assert.IsTrue(IsElementPresent(By.LinkText("Transactions")));
            Assert.IsTrue(IsElementPresent(By.LinkText("Help")));
            Assert.IsTrue(IsElementPresent(By.CssSelector("a.navbar-brand > img[src^='https://cdn-icons-png.flaticon.com/512/285/285850.png?w=826&t=st=1683727461~exp=1683728061~hmac=d6dcaa4c0cb80fd2b29fc1ae1e617deee59f630d561875b3819a309dcc6846d2']")));
        }

        [Test]
        public void TestFooter()
        {
            // Open homepage
            driver.Navigate().GoToUrl("https://localhost:7000/");
            Thread.Sleep(TimeSpan.FromSeconds(2));

            // Scroll to the footer
            IWebElement footer = driver.FindElement(By.TagName("footer"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", footer);
            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Assert presence of footer buttons
            Assert.IsTrue(IsElementPresent(By.LinkText("HELP")));
            Assert.IsTrue(IsElementPresent(By.LinkText("HOMEPAGE")));

            // Click on the "Help" button
            driver.FindElement(By.LinkText("HELP")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            // Scroll to the footer
            footer = driver.FindElement(By.TagName("footer"));
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);", footer);
            Thread.Sleep(TimeSpan.FromSeconds(1));

            // Assert presence of help page elements
            Assert.IsTrue(IsElementPresent(By.LinkText("HOMEPAGE")));
            Assert.IsTrue(IsElementPresent(By.LinkText("HELP")));
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


/* Chrome "I agree" popup 

             // Find and click the language dropdown
            IWebElement languageDropdown = driver.FindElement(By.ClassName("tHlp8d"));
            languageDropdown.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            // Find and click the agree button
            IWebElement agreeButton = driver.FindElement(By.Id("L2AGLb"));
            agreeButton.Click();
*/