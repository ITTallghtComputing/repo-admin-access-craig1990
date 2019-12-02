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
    public class SecondarySchoolSurveyController : Controller
    {
        private RDSContext db = new RDSContext();

        // GET: SecondarySchoolSurvey
        public ActionResult Index()
        {
            return View(db.SecondarySchoolSurveys.ToList());
        }

        // GET: SecondarySchoolSurvey/Details/5
        public ActionResult Details(int? id)
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
            return View(secondarySchoolSurvey);
        }

        // GET: SecondarySchoolSurvey/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SecondarySchoolSurvey/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Q6b,Q5,Q4,Q3,Q1,RollNumber,CampDate,SurveyFileName,FilePage,Q2,Q6a,Q7,Q8,Q9,Q10,Q11,Q12,Q13a,Q13b,Q14a,Q14b,Q14c,Q15,Q16,Q17,Q18,Q19,Q20,Flag,FlagContent")] SecondarySchoolSurvey secondarySchoolSurvey)
        {
            if (ModelState.IsValid)
            {
                db.SecondarySchoolSurveys.Add(secondarySchoolSurvey);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(secondarySchoolSurvey);
        }

        // GET: SecondarySchoolSurvey/Edit/5
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
            return View(secondarySchoolSurvey);
        }

        // POST: SecondarySchoolSurvey/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Q6b,Q5,Q4,Q3,Q1,RollNumber,CampDate,SurveyFileName,FilePage,Q2,Q6a,Q7,Q8,Q9,Q10,Q11,Q12,Q13a,Q13b,Q14a,Q14b,Q14c,Q15,Q16,Q17,Q18,Q19,Q20,Flag,FlagContent")] SecondarySchoolSurvey secondarySchoolSurvey)
        {
            if (ModelState.IsValid)
            {
                db.Entry(secondarySchoolSurvey).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(secondarySchoolSurvey);
        }

        // GET: SecondarySchoolSurvey/Delete/5
        public ActionResult Delete(int? id)
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
            return View(secondarySchoolSurvey);
        }

        // POST: SecondarySchoolSurvey/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SecondarySchoolSurvey secondarySchoolSurvey = db.SecondarySchoolSurveys.Find(id);
            db.SecondarySchoolSurveys.Remove(secondarySchoolSurvey);
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
    }
}
