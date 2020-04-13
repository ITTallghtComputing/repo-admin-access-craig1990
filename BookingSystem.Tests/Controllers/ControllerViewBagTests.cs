using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BookingSystem;
using BookingSystem.Controllers;
using BookingSystem.Models;

namespace BookingSystem.Tests.Controllers
{
    //Unit tests to ensure that controllers are passing correct ViewBag dynamic data to Views
    [TestClass]
    public class ControllerViewBagTests
    {

        [TestMethod]
        public void BookingControllerTest()
        {
            //Arrange
            var controller = new BookingController();
            string expected = "Create";

            //Act
            var result = controller.Create() as ViewResult;
            var actual = (string)result.ViewData["Title"];

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CampDateControllerTest()
        {
            //Arrange
            var controller = new CampDateController();
            string expected = "Create";

            //Act
            var result = controller.Create() as ViewResult;
            var actual = (string)result.ViewData["Title"];

            //Assert
            Assert.AreEqual(expected, actual);
        }


        [TestMethod]
        public void SecondarySchoolSurveysControllerTest()
        {
            //Arrange
            var controller = new SecondarySchoolSurveyController();
            string expected = "Create";

            //Act
            var result = controller.Create() as ViewResult;
            var actual = (string)result.ViewData["Title"];

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
