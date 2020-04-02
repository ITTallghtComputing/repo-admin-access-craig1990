using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookingSystem.Models;
using PagedList;

namespace BookingSystem.Controllers
{
    public class FlaggedSurveysController : Controller
    {
        private RDSContext db = new RDSContext();

        // GET: FlaggedSurveys
        public ActionResult Index(int? page, int? id)
        {
            var flagID = id;

            //find school associated with id
            var flaggedSchool = db.CompletedCamps.FirstOrDefault(s => s.Id == flagID);  
            //get school name
            string schoolName = flaggedSchool.OfficialSchoolName;  
            //get list of flagged surveys from a school
            var surveys = db.SecondarySchoolSurveys.Where(s => s.Flag == true && s.OfficialSchoolName == schoolName).OrderBy(s => s.Id);

            //determine if a school camp has flagged surveys that will need to be validated
            CompletedCamp completedCamp = db.CompletedCamps.Find(id);
            int numberFlagged = db.SecondarySchoolSurveys.Count(s => s.Flag == true && s.OfficialSchoolName == completedCamp.OfficialSchoolName);
            if (numberFlagged > 0)
            {
                completedCamp.SurveysValidated = CompletedCamp.Validated.Yes;
            }
            else if (numberFlagged == 0)
            {
                completedCamp.SurveysValidated = CompletedCamp.Validated.No;
            }


            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(surveys.ToPagedList(pageNumber, pageSize));
        }

        // GET: FlaggedSurveys/Edit/5
        public ActionResult Edit(int? id)
        {
            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SecondarySchoolSurvey secondarySchoolSurvey = db.SecondarySchoolSurveys.Find(id);
            if (secondarySchoolSurvey == null)
            {
                return HttpNotFound();
            }

            //get school id to send back as parameter to Index view
            var school = db.CompletedCamps.FirstOrDefault(s => s.OfficialSchoolName == secondarySchoolSurvey.OfficialSchoolName);
            var campID = school.Id;

            //break flag content string into list to display each flag in View
            List<string> listStrLineElements = secondarySchoolSurvey.FlagContent.Split('|').ToList();
            ViewBag.FlagList = listStrLineElements;

            ViewBag.CompletedCamp = campID;

            return View(secondarySchoolSurvey);
        }

        // POST: FlaggedSurveys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Q1,RollNumber,OfficialSchoolName,CampDate,SurveyFileName,FilePage,Q2,Q3,Q4,Q5,Q6a,Q6b,Q7,Q8,Q9,Q10,Q11,Q12,Q13a,Q13b,Q14a,Q14b,Q14c,Q15,Q16,Q17,Q18,Q19,Q20,Flag,FlagContent")] SecondarySchoolSurvey secondarySchoolSurvey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(secondarySchoolSurvey).State = EntityState.Modified;
                db.SaveChanges();

                //get school id to send back as parameter to Index view
                var school = db.CompletedCamps.FirstOrDefault(s => s.OfficialSchoolName == secondarySchoolSurvey.OfficialSchoolName);
                var id = school.Id;

                //direct to list flagged surveys with school id
                return RedirectToAction("Index", "FlaggedSurveys", new { id = id });
            }
            return View(secondarySchoolSurvey);
        }

        // GET: FlaggedSurveys/Delete/5
        public ActionResult Delete(int? id)
        {
            SecondarySchoolSurvey secondarySchoolSurvey = db.SecondarySchoolSurveys.Find(id);
            var school = db.CompletedCamps.FirstOrDefault(s => s.OfficialSchoolName == secondarySchoolSurvey.OfficialSchoolName);
            var id2 = school.Id;

            ViewBag.SchoolID = id2;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (secondarySchoolSurvey == null)
            {
                return HttpNotFound();
            }
            return View(secondarySchoolSurvey);
        }

        // POST: FlaggedSurveys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SecondarySchoolSurvey secondarySchoolSurvey = db.SecondarySchoolSurveys.Find(id);
            db.SecondarySchoolSurveys.Remove(secondarySchoolSurvey);
            db.SaveChanges();

            //get school id to send back as parameter to Index view
            var school = db.CompletedCamps.FirstOrDefault(s => s.OfficialSchoolName == secondarySchoolSurvey.OfficialSchoolName);
            var id2 = school.Id;

            //direct to list flagged surveys with school id
            return RedirectToAction("Index", "FlaggedSurveys", new { id = id2 });
        }

        public ActionResult OpenPDF(int? id)
        {
            CompletedCamp completedCamp = db.CompletedCamps.Find(id);
            string filepath = Server.MapPath(Path.Combine("~/Surveys/" + completedCamp.SurveyName));
            return File(filepath, "application/pdf");
        }

        //public FileStreamResult GetPDF()
        //{
        //    FileStream fs = new FileStream("c:\\PeterPDF2.pdf", FileMode.Open, FileAccess.Read);
        //    return File(fs, "application/pdf");
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
