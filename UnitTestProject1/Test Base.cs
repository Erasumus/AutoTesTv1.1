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
    public class TestBase
    {
        public IWebDriver driver;
        public StringBuilder verificationErrors;
        public string baseURL;
        public bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new ChromeDriver(@"C:\");
            baseURL = "http://kpfu.ru/";
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
        public void Exit()
        {
            driver.FindElement(By.LinkText("Выход")).Click();
        }

        public void Save()
        {
            driver.FindElement(By.CssSelector("input[type=\"button\"]")).Click();
        }

        public void AboutMe()
        {
            driver.FindElement(By.LinkText("Обо мне")).Click();
        }

        public void Forum()
        {
            driver.FindElement(By.LinkText("Форум")).Click();
        }

        public void MyOffice()
        {
            driver.FindElement(By.LinkText("Мой кабинет")).Click();
        }

        public void Email()
        {
            driver.FindElement(By.Name("p_email")).Clear();
            driver.FindElement(By.Name("p_email")).SendKeys("erasumus@mail.ru");
        }

        public void Login(Account user)
        {
            driver.FindElement(By.LinkText("Вход")).Click();
            FillField("p_login", user.Login);
            FillField("p_pass", user.Password);
            driver.FindElement(By.CssSelector("input[type=\"submit\"]")).Click();
        }

        private void FillField(string field, string value)
        {
            driver.FindElement(By.Name(field)).Clear();
            driver.FindElement(By.Name(field)).SendKeys(value);
        }

        public void Site()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
        }

        public bool IsElementPresent(By by)
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

        public bool IsAlertPresent()
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

        public string CloseAlertAndGetItsText()
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
    }
}


