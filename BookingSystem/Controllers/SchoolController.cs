//Craig Whelan X00075734

using BookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace BookingSystem.Controllers
{
    public class SchoolController : Controller
    {
        private RDSContext db = new RDSContext();

        [HttpGet]
        public ActionResult Booking()
        {
            var model = db.CampDates.ToList();
            return View(model);
        }

        [HttpGet]
        public ActionResult BookingOrg()
        {
            var model = db.CampDates.ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Booking(School model)
        {
            //get row in SchoolDb which matches RollNumber

            var schoolresult = db.Schools.Where(m => m.RollNumber == model.RollNumber);
            School school = schoolresult.FirstOrDefault();

            if (school != null)
            {
                //get row in DatepickerDb which matches Date
                CampDate date = db.CampDates.First(m => m.Date == model.Date);

                //add extra information from 2nd csv to main school object
                School2 school2 = db.School2.First(m => m.RollNumber == model.RollNumber);
                school.Email = school2.Email;
                school.PhoneNumber = school2.PhoneNumber;
                school.PrincipalName = school2.PrincipalName;
                school.DeisSchool = school2.DeisSchool;
                school.SchoolGender = school2.SchoolGender;
                school.PupilAttendanceType = school2.PupilAttendanceType;
                school.IrishClassification = school2.IrishClassification;
                school.GaeltachtArea = school2.GaeltachtArea;
                school.FeePayingSchool = school2.FeePayingSchool;
                school.Religion = school2.Religion;
                school.OpenClosedStatus = school2.OpenClosedStatus;
                school.TotalGirls = school2.TotalGirls.GetValueOrDefault();
                school.TotalBoys = school2.TotalBoys.GetValueOrDefault();
                school.TotalPupils = school2.TotalPupils;

                //add camp lecturer and camp date to main school object
                var lecturer = date.LecturerName;
                school.LecturerName = lecturer;
                school.Date = model.Date;

                //save Db changes
                db.SaveChanges();

                return RedirectToAction("BookingForm", "School", new RouteValueDictionary(school));
            }

            //if roll number is invalid then create error message and return list of dates again
            ViewBag.ErrorMessage = "Invalid Roll Number";
            var dateModel = db.CampDates.ToList();
            return View(dateModel);
        }

        [HttpPost]
        public ActionResult BookingOrg(Organisation model)
        {
            //get row in DatepickerDb which matches Date
            CampDate date = db.CampDates.First(m => m.Date == model.Date);

            //add camp lecturer and camp date into SchoolDb
            var lecturer = date.LecturerName;
            model.LecturerName = lecturer;

            //save Db changes
            db.Organisations.Add(model);
            db.SaveChanges();

            return RedirectToAction("BookingFormOrg", "School", new RouteValueDictionary(model));
        }

        [HttpGet]
        public ActionResult BookingForm(School model)
        {
            School school = db.Schools.First(m => m.RollNumber == model.RollNumber);
            return View(school);
        }

        [HttpGet]
        public ActionResult BookingFormOrg(Organisation model)
        {
            Organisation organisation = db.Organisations.First(m => m.Id == model.Id);
            return View(organisation);
        }

        [HttpPost]
        [ActionName("BookingForm")]
        public ActionResult BookingFormPost(Booking model)
        {
            if (ModelState.IsValid)
            {
                //add booking
                db.Bookings.Add(model);
                //make used date unavailable in datepicker
                CampDate date = db.CampDates.First(m => m.Date == model.Date);
                db.CampDates.Remove(date);

                db.SaveChanges();
                return RedirectToAction("Confirmation", "School");
            }

            //pass form data back to be fully resubmitted
            var School = new School();
            School = db.Schools.First(m => m.RollNumber == model.RollNumber);
            School.Date = model.Date;
            School.ValidationMsg = "Please complete all fields";

            return View(School);
        }

        [HttpPost]
        [ActionName("BookingFormOrg")]
        public ActionResult BookingFormPostOrg(Booking model)
        {
            if (ModelState.IsValid)
            {
                //add booking
                db.Bookings.Add(model);
                //make used date unavailable in datepicker
                CampDate date = db.CampDates.First(m => m.Date == model.Date);
                db.CampDates.Remove(date);

                db.SaveChanges();
                return RedirectToAction("Confirmation", "School");
            }

            //pass form data back to be fully resubmitted
            var Organisation = new Organisation();
            Organisation = db.Organisations.First(m => m.Id == model.Id);
            Organisation.OfficialSchoolName = model.OfficialSchoolName;
            Organisation.Date = model.Date;
            Organisation.TeacherName = model.TeacherName;
            Organisation.Email = model.Email;
            Organisation.PhoneNumber = model.PhoneNumber;
            Organisation.Address1 = model.Address1;
            Organisation.Address2 = model.Address2;
            Organisation.Address3 = model.Address3;
            Organisation.Address4 = model.Address4;
            Organisation.County = model.County;
            Organisation.Eircode = model.Eircode;
            Organisation.StartTime = model.StartTime;
            Organisation.EndTime = model.EndTime;
            Organisation.ClassGroups = model.ClassGroups;
            Organisation.Topics = model.Topics;
            Organisation.Surveys = model.Surveys;
            Organisation.ValidationMsg = "Please complete all fields";

            return View(Organisation);
        }

        [HttpGet]
        public ActionResult Confirmation()
        {
            return View();
        }
    }
}