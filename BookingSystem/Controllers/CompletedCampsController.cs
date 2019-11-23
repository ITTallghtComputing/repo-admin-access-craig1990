using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookingSystem.Models;
using System.IO;
using BookingSystem.Helpers;
using System.Threading.Tasks;

namespace BookingSystem.Controllers
{
    public class CompletedCampsController : Controller
    {
        private RDSContext db = new RDSContext();

        // GET: CompletedCamps
        public ActionResult Index()
        {
            return View(db.CompletedCamps.ToList());
        }

        // GET: CompletedCamps/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompletedCamp completedCamp = db.CompletedCamps.Find(id);
            if (completedCamp == null)
            {
                return HttpNotFound();
            }
            return View(completedCamp);
        }

        // GET: CompletedCamps/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CompletedCamps/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,RollNumber,OfficialSchoolName,TeacherName,Address1,Address2,Address3,Address4,Eircode,County,Email,PhoneNumber,Date,StartTime,EndTime,Surveys,AcademicYear,LocalAuthority,X,Y,ITMEast,ITMNorth,Latitude,Longitude,ClassGroups,Topics,LecturerName,PrincipalName,DeisSchool,SchoolGender,PupilAttendanceType,IrishClassification,GaeltachtArea,FeePayingSchool,Religion,OpenClosedStatus,TotalGirls,TotalBoys,TotalPupils")] CompletedCamp completedCamp)
        {
            if (ModelState.IsValid)
            {
                db.CompletedCamps.Add(completedCamp);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(completedCamp);
        }

        // GET: CompletedCamps/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompletedCamp completedCamp = db.CompletedCamps.Find(id);
            if (completedCamp == null)
            {
                return HttpNotFound();
            }
            return View(completedCamp);
        }

        // POST: CompletedCamps/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,RollNumber,OfficialSchoolName,TeacherName,Address1,Address2,Address3,Address4,Eircode,County,Email,PhoneNumber,Date,StartTime,EndTime,Surveys,AcademicYear,LocalAuthority,X,Y,ITMEast,ITMNorth,Latitude,Longitude,ClassGroups,Topics,LecturerName,PrincipalName,DeisSchool,SchoolGender,PupilAttendanceType,IrishClassification,GaeltachtArea,FeePayingSchool,Religion,OpenClosedStatus,TotalGirls,TotalBoys,TotalPupils")] CompletedCamp completedCamp)
        {
            if (ModelState.IsValid)
            {
                db.Entry(completedCamp).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(completedCamp);
        }

        // GET: CompletedCamps/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompletedCamp completedCamp = db.CompletedCamps.Find(id);
            if (completedCamp == null)
            {
                return HttpNotFound();
            }
            return View(completedCamp);
        }

        // POST: CompletedCamps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompletedCamp completedCamp = db.CompletedCamps.Find(id);
            db.CompletedCamps.Remove(completedCamp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Upload(HttpPostedFileBase file)
        {
            string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string filepath = Server.MapPath(Path.Combine("~/Surveys/", filename));
            file.SaveAs(Path.Combine(Server.MapPath("/Surveys/"), filename));
            await AzureVisionAPI.ExtractToTextFile(filepath);


            return View();
        }
    }
}
