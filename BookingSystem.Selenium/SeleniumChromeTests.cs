using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Chrome;

namespace BookingSystem.Selenium
{
    [TestClass]
    public class SeleniumChromeTests
    {
        //Test loging into a CSinc Booking System Admin account 
        [TestMethod]
        public void LoginTest()
        {

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://csinc-dev.eu-west-1.elasticbeanstalk.com/");
            var webAppUrl = "http://csinc-dev.eu-west-1.elasticbeanstalk.com/";


            var startTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var endTimestamp = startTimestamp + 60 * 10;

            //if login is successful, we will be redirected to the following URL
            string expectedUrl = "http://csinc-dev.eu-west-1.elasticbeanstalk.com/Home/Index";

            driver.Navigate().GoToUrl(webAppUrl);
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1056);
            driver.FindElement(By.Id("loginLink")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("user1@tudublin.ie");
            driver.FindElement(By.CssSelector("body")).Click();
            driver.FindElement(By.CssSelector(".form-horizontal")).Click();
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).SendKeys("password");
            driver.FindElement(By.CssSelector(".btn")).Click();


            // string actualValue = driver.FindElement(By.Id("h3")).Text;
            string url = driver.Url;


            Assert.AreEqual(expectedUrl, url);

        }

        // Test loging into an Admin account and adding a camp date onto the system to be available for a school/organisation to book
        [TestMethod]
        public void AddAvailableCampDateTest()
        {

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://csinc-dev.eu-west-1.elasticbeanstalk.com/");
            var webAppUrl = "http://csinc-dev.eu-west-1.elasticbeanstalk.com/";


            var startTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var endTimestamp = startTimestamp + 60 * 10;

            //if adding available camp date is successful, we will be redirected to the following URL
            string expectedUrl = "http://csinc-dev.eu-west-1.elasticbeanstalk.com/CampDate/Index";

            //login
            driver.Navigate().GoToUrl(webAppUrl);
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1056);
            driver.FindElement(By.Id("loginLink")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("user1@tudublin.ie");
            driver.FindElement(By.CssSelector("body")).Click();
            driver.FindElement(By.CssSelector(".form-horizontal")).Click();
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).SendKeys("password");
            driver.FindElement(By.CssSelector(".btn")).Click();
            //add 1st date for below selenium tests to use
            driver.Manage().Window.Size = new System.Drawing.Size(1920, 1040);
            driver.FindElement(By.LinkText("Admin")).Click();
            driver.FindElement(By.LinkText("Manage Camp Dates")).Click();
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.FindElement(By.Id("Date")).Click();
            driver.FindElement(By.LinkText("16")).Click();
            driver.FindElement(By.Id("LecturerName")).Click();
            driver.FindElement(By.Id("LecturerName")).SendKeys("Keith Quille");
            driver.FindElement(By.Id("Comment")).Click();
            driver.FindElement(By.Id("Comment")).SendKeys("Available");
            driver.FindElement(By.CssSelector("html")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();
            //add 2nd date for below selenium tests to use
            driver.Navigate().GoToUrl(webAppUrl);
            driver.FindElement(By.LinkText("Admin")).Click();
            driver.FindElement(By.LinkText("Manage Camp Dates")).Click();
            driver.FindElement(By.CssSelector(".btn-primary")).Click();
            driver.FindElement(By.Id("Date")).Click();
            driver.FindElement(By.LinkText("16")).Click();
            driver.FindElement(By.Id("LecturerName")).Click();
            driver.FindElement(By.Id("LecturerName")).SendKeys("Keith Quille");
            driver.FindElement(By.Id("Comment")).Click();
            driver.FindElement(By.Id("Comment")).SendKeys("Available");
            driver.FindElement(By.CssSelector("html")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();

            // string actualValue = driver.FindElement(By.Id("h3")).Text;
            string url = driver.Url;


            Assert.AreEqual(expectedUrl, url);

        }

        // Test making an organisation camp booking using one of the dates that was added by AddAvailableCampDateTest()
        [TestMethod]
        public void MakeOrganisationBookingTest()
        {

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://csinc-dev.eu-west-1.elasticbeanstalk.com/");
            var webAppUrl = "http://csinc-dev.eu-west-1.elasticbeanstalk.com/";


            var startTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var endTimestamp = startTimestamp + 60 * 10;

            //if making an organisation booking is successful, we will be redirected to the following URL
            string expectedUrl = "http://csinc-dev.eu-west-1.elasticbeanstalk.com/School/Confirmation";

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

            string url = driver.Url;


            Assert.AreEqual(expectedUrl, url);

        }


        // Test making a school camp booking using one of the dates that was added by AddAvailableCampDateTest()
        [TestMethod]
        public void MakeSchoolBookingTest()
        {

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://csinc-dev.eu-west-1.elasticbeanstalk.com/");
            var webAppUrl = "http://csinc-dev.eu-west-1.elasticbeanstalk.com/";


            var startTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var endTimestamp = startTimestamp + 60 * 10;

            //if making an organisation booking is successful, we will be redirected to the following URL
            string expectedUrl = "http://csinc-dev.eu-west-1.elasticbeanstalk.com/School/Confirmation";

            driver.Navigate().GoToUrl(webAppUrl);
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1056);
            driver.FindElement(By.Id("txtRoll")).Click();
            driver.FindElement(By.Id("txtRoll")).SendKeys("60010P");
            driver.FindElement(By.Id("txtDate")).Click();
            driver.FindElement(By.LinkText("16")).Click();
            driver.FindElement(By.CssSelector(".submit")).Click();
            driver.FindElement(By.Id("txtTeacherName")).Click();
            driver.FindElement(By.Id("txtTeacherName")).SendKeys("Mrs Smith");
            driver.FindElement(By.Id("txtStartTime")).Click();
            driver.FindElement(By.Id("txtStartTime")).SendKeys("10:00");
            driver.FindElement(By.Id("txtEndTime")).Click();
            driver.FindElement(By.Id("txtEndTime")).SendKeys("13:00");
            driver.FindElement(By.CssSelector(".col-md-3:nth-child(3) > .form-group")).Click();
            driver.FindElement(By.Id("txtClassGroups")).Click();
            driver.FindElement(By.Id("txtClassGroups")).SendKeys("4th year students");
            driver.FindElement(By.Id("txtTopics")).Click();
            driver.FindElement(By.Id("txtTopics")).SendKeys("general intro");
            driver.FindElement(By.Id("surveyBox")).Click();
            driver.FindElement(By.CssSelector(".btn-primary")).Click();

            string url = driver.Url;


            Assert.AreEqual(expectedUrl, url);

        }


        // Test searching for the organisation booking made by MakeOrganisationBookingTest() to make sure it was added to the system
        // then remove booking
        [TestMethod]
        public void SearchDeleteOrgBooking()
        {

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://csinc-dev.eu-west-1.elasticbeanstalk.com/");
            var webAppUrl = "http://csinc-dev.eu-west-1.elasticbeanstalk.com/";


            var startTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var endTimestamp = startTimestamp + 60 * 10;

            //if making an organisation booking is successful, we will be redirected to the following URL
            string expectedUrl = "http://csinc-dev.eu-west-1.elasticbeanstalk.com/Booking/Index";

            //login
            driver.Navigate().GoToUrl(webAppUrl);
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1056);
            driver.FindElement(By.Id("loginLink")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("user1@tudublin.ie");
            driver.FindElement(By.CssSelector("body")).Click();
            driver.FindElement(By.CssSelector(".form-horizontal")).Click();
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).SendKeys("password");
            driver.FindElement(By.CssSelector(".btn")).Click();
            //delete organisation booking
            driver.FindElement(By.LinkText("Admin")).Click();
            driver.FindElement(By.LinkText("Manage Bookings")).Click();
            driver.FindElement(By.Id("SearchString")).Click();
            driver.FindElement(By.Id("SearchString")).SendKeys("Test Organisation");
            driver.FindElement(By.CssSelector(".btn:nth-child(2)")).Click();
            driver.FindElement(By.Id("dropdownMenu1")).Click();
            driver.FindElement(By.LinkText("Delete")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();

            string url = driver.Url;


            Assert.AreEqual(expectedUrl, url);

        }


        // Test marking the booking made by MakeSchoolBookingTest() as complete. Then search for the booking to confirm it was added
        // removes booking after
        [TestMethod]
        public void MarkBookingAsComplete()
        {

            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl("http://csinc-dev.eu-west-1.elasticbeanstalk.com/");
            var webAppUrl = "http://csinc-dev.eu-west-1.elasticbeanstalk.com/";


            var startTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
            var endTimestamp = startTimestamp + 60 * 10;

            //if making an organisation booking is successful, we will be redirected to the following URL
            string expectedUrl = "http://csinc-dev.eu-west-1.elasticbeanstalk.com/CompletedCamps/Index";

            //login
            driver.Navigate().GoToUrl(webAppUrl);
            driver.Manage().Window.Size = new System.Drawing.Size(1936, 1056);
            driver.FindElement(By.Id("loginLink")).Click();
            driver.FindElement(By.Id("Email")).Click();
            driver.FindElement(By.Id("Email")).SendKeys("user1@tudublin.ie");
            driver.FindElement(By.CssSelector("body")).Click();
            driver.FindElement(By.CssSelector(".form-horizontal")).Click();
            driver.FindElement(By.Id("Password")).Click();
            driver.FindElement(By.Id("Password")).SendKeys("password");
            driver.FindElement(By.CssSelector(".btn")).Click();
            //mark booking as completed. move to completed booking and search for the booking to confirm it was added
            //remove booking
            driver.FindElement(By.LinkText("Admin")).Click();
            driver.FindElement(By.LinkText("Manage Bookings")).Click();
            driver.FindElement(By.CssSelector("tr:nth-child(2) > td > .btn")).Click();
            driver.FindElement(By.CssSelector(".btn-block")).Click();
            driver.FindElement(By.Id("SearchString")).Click();
            driver.FindElement(By.Id("SearchString")).SendKeys("Loreto");
            driver.FindElement(By.CssSelector(".btn-sm")).Click();
            driver.FindElement(By.Id("dropdownMenu1")).Click();
            driver.FindElement(By.LinkText("Delete")).Click();
            driver.FindElement(By.CssSelector(".btn")).Click();

            string url = driver.Url;


            Assert.AreEqual(expectedUrl, url);


        }
    }
}