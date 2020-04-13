using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;

namespace BookingSystem.Tests
{
    [TestClass]
    public class SeleniumChrome
    {

        

        [TestMethod]
        public void FunctionalTestNormal()
        {

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://csinc-dev.eu-west-1.elasticbeanstalk.com/");
            var webAppUrl = "http://csinc-dev.eu-west-1.elasticbeanstalk.com/";

            //driver.Navigate().GoToUrl("https://localhost:44379/");
            //var webAppUrl = "https://localhost:44379/";



            var startTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var endTimestamp = startTimestamp + 60 * 10;

            string expectedValue = "Thank you for your booking";

            driver.Navigate().GoToUrl(webAppUrl);
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1056);
            driver.FindElement(By.Id("txtRoll")).Click();
            driver.FindElement(By.LinkText("Click if organisation without school roll number")).Click();
            driver.FindElement(By.Id("txtName")).Click();
            driver.FindElement(By.Id("txtName")).SendKeys("Test Organisation");
            driver.FindElement(By.Id("txtDate")).Click();
            driver.FindElement(By.LinkText("16")).Click();
            driver.FindElement(By.CssSelector(".submit")).Click();
            driver.FindElement(By.Id("txtTeacherName")).Click();
            driver.FindElement(By.Id("txtTeacherName")).SendKeys("Mr Smith");
            driver.FindElement(By.Id("txtEmail")).Click();
            driver.FindElement(By.Id("txtEmail")).SendKeys("mrsmith@test.com");
            driver.FindElement(By.Id("txtPhoneNumber")).Click();
            driver.FindElement(By.Id("txtPhoneNumber")).SendKeys("014598634");
            driver.FindElement(By.Id("txtAddress1")).Click();
            driver.FindElement(By.Id("txtAddress1")).SendKeys("29 Emmet Lodge");
            driver.FindElement(By.Id("txtAddress2")).SendKeys("Templeogue");
            driver.FindElement(By.Id("txtCounty")).Click();
            driver.FindElement(By.Id("txtCounty")).SendKeys("Dublin 6");
            driver.FindElement(By.Id("txtEircode")).Click();
            driver.FindElement(By.Id("txtEircode")).SendKeys("D6WP38");
            driver.FindElement(By.Id("txtStartTime")).Click();
            driver.FindElement(By.Id("txtStartTime")).SendKeys("10:00");
            driver.FindElement(By.Id("txtEndTime")).Click();
            driver.FindElement(By.Id("txtEndTime")).SendKeys("13:30");
            driver.FindElement(By.Id("txtClassGroups")).Click();
            driver.FindElement(By.Id("txtClassGroups")).SendKeys("4th year students");
            driver.FindElement(By.Id("txtTopics")).Click();
            driver.FindElement(By.Id("txtTopics")).SendKeys("General");
            driver.FindElement(By.Id("surveyBox")).Click();
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            //driver.FindElement(By.CssSelector("h3")).Click();

           // string actualValue = driver.FindElement(By.Id("h3")).Text;
           string url = driver.Url;


            Assert.AreEqual("http://csinc-dev.eu-west-1.elasticbeanstalk.com/School/Confirmation", url);

        }
    }
}