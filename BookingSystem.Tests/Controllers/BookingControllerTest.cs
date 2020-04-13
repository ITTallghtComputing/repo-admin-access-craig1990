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
    [TestClass]
    public class BookingControllerTest
    {

        [TestMethod]
        public void BookingTest()
        {
            var controller = new BookingController();
            //var ar = controller.Create() as ViewResult;
            Assert.AreEqual("Create", controller.ViewBag.Title);
        }
    }
}
