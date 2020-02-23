//Craig Whelan X00075734

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookingSystem.Models;

namespace BookingSystem.Controllers
{
    public class BookingController : Controller
    {
        private RDSContext db = new RDSContext();

        // GET: Booking
        public ActionResult Index(string searchString)
        {
            var bookings = from s in db.Bookings
                           select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                bookings = db.Bookings.Where(s => s.OfficialSchoolName.Contains(searchString)
                                       || s.RollNumber.Contains(searchString));
            }

            return View(bookings.ToList());
        }

        // GET: Booking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // GET: Booking/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Booking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RollNumber,OfficialSchoolName,TeacherName,Address1,Address2,Address3,Address4,Eircode,County,Email,PhoneNumber,Date,StartTime,EndTime,Surveys,AcademicYear,LocalAuthority,X,Y,ITMEast,ITMNorth,Latitude,Longitude,ClassGroups,Topics,LecturerName,PrincipalName,DeisSchool,SchoolGender,PupilAttendanceType,IrishClassification,GaeltachtArea,FeePayingSchool,Religion,OpenClosedStatus,TotalGirls,TotalBoys,TotalPupils")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Bookings.Add(booking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(booking);
        }

        // GET: Booking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Booking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RollNumber,OfficialSchoolName,TeacherName,Address1,Address2,Address3,Address4,Eircode,County,Email,PhoneNumber,Date,StartTime,EndTime,Surveys,AcademicYear,LocalAuthority,X,Y,ITMEast,ITMNorth,Latitude,Longitude,ClassGroups,Topics,LecturerName,PrincipalName,DeisSchool,SchoolGender,PupilAttendanceType,IrishClassification,GaeltachtArea,FeePayingSchool,Religion,OpenClosedStatus,TotalGirls,TotalBoys,TotalPupils")] Booking booking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(booking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(booking);
        }

        // GET: Booking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                return HttpNotFound();
            }
            return View(booking);
        }

        // POST: Booking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Booking booking = db.Bookings.Find(id);
            db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Completed(int? id)
        {
            Booking booking = db.Bookings.Find(id);

            CompletedCamp camp = new CompletedCamp();
            camp.AcademicYear = booking.AcademicYear;
            camp.Address1 = booking.Address1;
            camp.Address2 = booking.Address2;
            camp.Address3 = booking.Address3;
            camp.Address4 = booking.Address4;
            camp.ClassGroups = booking.ClassGroups;
            camp.County = booking.County;
            camp.Date = booking.Date;
            camp.DeisSchool = booking.DeisSchool;
            camp.Eircode = booking.Eircode;
            camp.Email = booking.Email;
            camp.EndTime = booking.EndTime;
            camp.FeePayingSchool = booking.FeePayingSchool;
            camp.GaeltachtArea = booking.GaeltachtArea;
            camp.IrishClassification = booking.GaeltachtArea;
            camp.ITMEast = booking.ITMEast;
            camp.ITMNorth = booking.ITMNorth;
            camp.Latitude = booking.Latitude;
            camp.LecturerName = booking.LecturerName;
            camp.LocalAuthority = booking.LocalAuthority;
            camp.Longitude = booking.Longitude;
            camp.OfficialSchoolName = booking.OfficialSchoolName;
            camp.OpenClosedStatus = booking.OpenClosedStatus;
            camp.PhoneNumber = booking.PhoneNumber;
            camp.PrincipalName = booking.PrincipalName;
            camp.PupilAttendanceType = booking.PupilAttendanceType;
            camp.Religion = booking.Religion;
            camp.RollNumber = booking.RollNumber;
            camp.SchoolGender = booking.SchoolGender;
            camp.StartTime = booking.StartTime;
            camp.Surveys = booking.Surveys;
            camp.TeacherName = booking.TeacherName;
            camp.Topics = booking.Topics;
            camp.TotalBoys = booking.TotalBoys;
            camp.TotalGirls = booking.TotalGirls;
            camp.TotalPupils = booking.TotalPupils;
            camp.X = booking.X;
            camp.Y = booking.Y;

            db.CompletedCamps.Add(camp);

            db.Bookings.Remove(booking);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //// POST: Booking/Completed/5
        //[HttpPost, ActionName("Completed")]
        //[ValidateAntiForgeryToken]
        //public ActionResult CompletedConfirmed(int id)
        //{
        //    Booking booking = db.Bookings.Find(id);

        //    CompletedCamp camp = new CompletedCamp();
        //    camp.AcademicYear = booking.AcademicYear;
        //    camp.Address1 = booking.Address1;
        //    camp.Address2 = booking.Address2;
        //    camp.Address3 = booking.Address3;
        //    camp.Address4 = booking.Address4;
        //    camp.ClassGroups = booking.ClassGroups;
        //    camp.County = booking.County;
        //    camp.Date = booking.Date;
        //    camp.DeisSchool = booking.DeisSchool;
        //    camp.Eircode = booking.Eircode;
        //    camp.Email = booking.Email;
        //    camp.EndTime = booking.EndTime;
        //    camp.FeePayingSchool = booking.FeePayingSchool;
        //    camp.GaeltachtArea = booking.GaeltachtArea;
        //    camp.IrishClassification = booking.GaeltachtArea;
        //    camp.ITMEast = booking.ITMEast;
        //    camp.ITMNorth = booking.ITMNorth;
        //    camp.Latitude = booking.Latitude;
        //    camp.LecturerName = booking.LecturerName;
        //    camp.LocalAuthority = booking.LocalAuthority;
        //    camp.Longitude = booking.Longitude;
        //    camp.OfficialSchoolName = booking.OfficialSchoolName;
        //    camp.OpenClosedStatus = booking.OpenClosedStatus;
        //    camp.PhoneNumber = booking.PhoneNumber;
        //    camp.PrincipalName = booking.PrincipalName;
        //    camp.PupilAttendanceType = booking.PupilAttendanceType;
        //    camp.Religion = booking.Religion;
        //    camp.RollNumber = booking.RollNumber;
        //    camp.SchoolGender = booking.SchoolGender;
        //    camp.StartTime = booking.StartTime;
        //    camp.Surveys = booking.Surveys;
        //    camp.TeacherName = booking.TeacherName;
        //    camp.Topics = booking.Topics;
        //    camp.TotalBoys = booking.TotalBoys;
        //    camp.TotalGirls = booking.TotalGirls;
        //    camp.TotalPupils = booking.TotalPupils;
        //    camp.X = booking.X;
        //    camp.Y = booking.Y;

        //    db.CompletedCamps.Add(camp);

        //    db.Bookings.Remove(booking);
        //    db.SaveChanges();
        //    return RedirectToAction("Index");
        //}


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
