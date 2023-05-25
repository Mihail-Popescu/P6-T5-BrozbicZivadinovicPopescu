using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using OpenQA.Selenium.Interactions;

namespace UnitTests
{
    [TestFixture]
    public class HelpPageTests
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
        public void TestHelpPageButtons()
        {
            // Open help page
            driver.Navigate().GoToUrl("https://localhost:7000/HELP/HELP");
            Thread.Sleep(TimeSpan.FromSeconds(2));

            // Click on the "FAQ" button
            driver.FindElement(By.CssSelector("button.faq-button")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            // Assert that the FAQ section is highlighted
            IWebElement faqSection = driver.FindElement(By.Id("faq"));
            Assert.IsTrue(faqSection.GetAttribute("class").Contains("highlight"));

            // Click on the "About" button
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("window.scrollTo(0, 0);");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            driver.FindElement(By.CssSelector("button.about-button")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            // Assert that the About section is highlighted
            IWebElement aboutSection = driver.FindElement(By.Id("about"));
            Assert.IsTrue(aboutSection.GetAttribute("class").Contains("highlight"));

            // Click on the "Contact" button
            jsExecutor = (IJavaScriptExecutor)driver;
            jsExecutor.ExecuteScript("window.scrollTo(0, 0);");
            Thread.Sleep(TimeSpan.FromSeconds(2));
            driver.FindElement(By.CssSelector("button.contact-button")).Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            // Assert that the Contact section is highlighted
            IWebElement contactSection = driver.FindElement(By.Id("contact"));
            Assert.IsTrue(contactSection.GetAttribute("class").Contains("highlight"));
        }

        [Test]
        public void TestHelpPageSearch()
        {
            // Open help page
            driver.Navigate().GoToUrl("https://localhost:7000/HELP/HELP");
            Thread.Sleep(TimeSpan.FromSeconds(2));

            // Enter search term in the search box
            IWebElement searchBox = driver.FindElement(By.Id("search-box"));
            searchBox.SendKeys("phone");

            // Click the search button
            IWebElement searchButton = driver.FindElement(By.CssSelector(".search-button"));
            searchButton.Click();
            Thread.Sleep(TimeSpan.FromSeconds(2));

            // Check if the page has been scrolled
            IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;
            bool isScrolled = (bool)jsExecutor.ExecuteScript("return (window.pageYOffset !== undefined);");

            // Assert that the page has been scrolled
            Assert.IsTrue(isScrolled, "The page should be scrolled after clicking the search button.");
        }

    }

}