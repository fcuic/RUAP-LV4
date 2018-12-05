using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace SeleniumTests
{
    [TestFixture]
    public class Register
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;
        
        [SetUp]
        public void SetupTest()
        {
            // driver = new FirefoxDriver();
            driver = new ChromeDriver();
            baseURL = "https://www.katalon.com/";
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
        public void Test1_TheRegisterTest()
        {
            driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/");
            driver.FindElement(By.LinkText("Register")).Click();
            driver.FindElement(By.Id("gender-male")).Click();
            driver.FindElement(By.Id("FirstName")).Click();
            driver.FindElement(By.Id("FirstName")).Clear();
            driver.FindElement(By.Id("FirstName")).SendKeys("asd");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Female'])[1]/following::div[1]")).Click();
            driver.FindElement(By.Id("LastName")).Click();
            driver.FindElement(By.Id("LastName")).Clear();
            driver.FindElement(By.Id("LastName")).SendKeys("asdf");
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("fcuic243677@etfos.hr");
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("asd123");
            driver.FindElement(By.Id("ConfirmPassword")).Click();
            driver.FindElement(By.Id("ConfirmPassword")).Clear();
            driver.FindElement(By.Id("ConfirmPassword")).SendKeys("asd123");
            driver.FindElement(By.Id("register-button")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Your registration completed'])[1]/following::input[1]")).Click();
        }

        [Test]
        public void Test2_TheLogInTest()
        {
            driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/");
            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("filipcuic.nasice@gmail.com");
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("asd123");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Forgot password?'])[1]/following::input[1]")).Click();
        }

        [Test]
        public void Test3_TheAddToShoppingCartTest()
        {

            driver.Navigate().GoToUrl("http://demowebshop.tricentis.com/");
            driver.FindElement(By.LinkText("Log in")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).Clear();
            driver.FindElement(By.Id("Email")).SendKeys("filipcuic.nasice@gmail.com");
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).Clear();
            driver.FindElement(By.Id("Password")).SendKeys("asd123");
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Forgot password?'])[1]/following::input[1]")).Click();
            driver.FindElement(By.LinkText("Computers")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Desktops'])[4]/following::img[1]")).Click();
            driver.FindElement(By.LinkText("Build your own cheap computer")).Click();
            driver.FindElement(By.Id("product_attribute_72_5_18_65")).Click();
            driver.FindElement(By.Id("product_attribute_72_6_19_91")).Click();
            driver.FindElement(By.Id("product_attribute_72_3_20_58")).Click();
            driver.FindElement(By.Id("product_attribute_72_8_30_93")).Click();
            driver.FindElement(By.Id("product_attribute_72_8_30_94")).Click();
            driver.FindElement(By.Id("product_attribute_72_8_30_95")).Click();
            driver.FindElement(By.Id("add-to-cart-button-72")).Click();
            driver.FindElement(By.XPath("(.//*[normalize-space(text()) and normalize-space(.)='Log out'])[1]/following::span[1]")).Click();
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
        
        private string CloseAlertAndGetItsText() {
            try {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert) {
                    alert.Accept();
                } else {
                    alert.Dismiss();
                }
                return alertText;
            } finally {
                acceptNextAlert = true;
            }
        }
    }
}
