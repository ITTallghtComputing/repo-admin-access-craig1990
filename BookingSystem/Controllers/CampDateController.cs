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
    public class CampDateController : Controller
    {
        private RDSContext db = new RDSContext();

        // GET: CampDate
        public ActionResult Index()
        {
            return View(db.CampDates.ToList());
        }

        // GET: CampDate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampDate campDate = db.CampDates.Find(id);
            if (campDate == null)
            {
                return HttpNotFound();
            }
            return View(campDate);
        }

        // GET: CampDate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CampDate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,LecturerName,Comment")] CampDate campDate)
        {
            if (ModelState.IsValid)
            {
                db.CampDates.Add(campDate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(campDate);
        }

        // GET: CampDate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampDate campDate = db.CampDates.Find(id);
            if (campDate == null)
            {
                return HttpNotFound();
            }
            return View(campDate);
        }

        // POST: CampDate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,LecturerName,Comment")] CampDate campDate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campDate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(campDate);
        }

        // GET: CampDate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CampDate campDate = db.CampDates.Find(id);
            if (campDate == null)
            {
                return HttpNotFound();
            }
            return View(campDate);
        }

        // POST: CampDate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CampDate campDate = db.CampDates.Find(id);
            db.CampDates.Remove(campDate);
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
