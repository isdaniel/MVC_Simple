using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text;
using TechTalk.SpecFlow;

namespace UnitTestWeb
{
    [Binding]
    public class LoginFeatureSteps
    {
        private bool acceptNextAlert = true;
        private string baseURL;
        private IWebDriver driver;
        private StringBuilder verificationErrors;

        #region 初始化和結束

        [AfterScenario("LoginFeature")]
        public void AfterScenario()
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

        [BeforeScenario("LoginFeature")]
        public void BeforeScenario()
        {
            driver = new ChromeDriver();
            baseURL = "http://localhost:3148/";
            verificationErrors = new StringBuilder();
        }

        #endregion 初始化和結束

        [Given(@"至""(.*)""登入帳號")]
        public void Given至登入帳號(string url)
        {
            driver.Navigate().GoToUrl(url + "/User/Login");
        }

        [Given(@"輸入密碼(.*)")]
        public void Given輸入密碼(string password)
        {
            driver.FindElement(By.Id("Lib_password")).Clear();
            driver.FindElement(By.Id("Lib_password")).SendKeys("dd123456");
        }

        [Given(@"輸入帳號(.*)")]
        public void Given輸入帳號(string username)
        {
            driver.FindElement(By.Id("Lib_username")).Clear();
            driver.FindElement(By.Id("Lib_username")).SendKeys("dd123456");
        }

        [Then(@"登入管理者頁面 頁面並有(.*)標誌 代表登入成功")]
        public void Then登入管理者頁面頁面並有Logout標誌代表登入成功(string tag)
        {
            Assert.AreEqual(tag, driver.FindElement(By.LinkText("Sign Out")).Text);
        }

        [When(@"按下提交按鈕")]
        public void When按下提交按鈕()
        {
            driver.FindElement(By.CssSelector("input.button")).Click();
        }
    }
}