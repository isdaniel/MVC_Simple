using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

namespace SeleniumTests
{
    [TestFixture]
    public class LoginSteo
    {
        private bool acceptNextAlert = true;
        private string baseURL;
        private IWebDriver driver;
        private StringBuilder verificationErrors;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost:3148/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheLoginSteoTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/User/Login");
            driver.FindElement(By.Id("Lib_username")).Clear();
            driver.FindElement(By.Id("Lib_username")).SendKeys("dd123456");
            driver.FindElement(By.Id("Lib_password")).Clear();
            driver.FindElement(By.Id("Lib_password")).SendKeys("dd123456");
            driver.FindElement(By.CssSelector("input.button")).Click();
            Assert.AreEqual("Sign Out", driver.FindElement(By.LinkText("Sign Out")).Text);
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}