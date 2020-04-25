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
using System.IO;
using System.Threading.Tasks;
using PagedList;
using System.Web.Routing;
using BookingSystem.Survey_Extraction;

namespace BookingSystem.Controllers
{
    public class CompletedCampsController : Controller
    {
        private RDSContext db = new RDSContext();

        // GET: CompletedCamp
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.LecturerSortParm = sortOrder == "Lecturer" ? "lecturer_desc" : "Lecturer";

            //paging
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var compltedCamps = from s in db.CompletedCamps
                           select s;

            //convert search string to a Date
            var isDate = DateTime.TryParse(searchString, out var searchDate);
            if (isDate)
            {
                compltedCamps = db.CompletedCamps
                .Where(s => s.Date == searchDate);
            }
            else if (!String.IsNullOrEmpty(searchString))
            {
                compltedCamps = db.CompletedCamps.Where(s => s.OfficialSchoolName.Contains(searchString)
                                       || s.RollNumber.Contains(searchString) || s.LecturerName.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    compltedCamps = compltedCamps.OrderByDescending(s => s.OfficialSchoolName);
                    break;
                case "Date":
                    compltedCamps = compltedCamps.OrderBy(s => s.Date);
                    break;
                case "date_desc":
                    compltedCamps = compltedCamps.OrderByDescending(s => s.Date);
                    break;
                case "Lecturer":
                    compltedCamps = compltedCamps.OrderBy(s => s.LecturerName);
                    break;
                case "lecturer_desc":
                    compltedCamps = compltedCamps.OrderByDescending(s => s.LecturerName);
                    break;
                default:
                    compltedCamps = compltedCamps.OrderBy(s => s.OfficialSchoolName);
                    break;
            }


            
            //loop over each completed camp to determine if each camp has flagged surveys which need to be validated
            foreach (CompletedCamp camp in compltedCamps)
            {
                int numberFlagged = db.SecondarySchoolSurveys.Count(s => s.Flag == true && s.OfficialSchoolName == camp.OfficialSchoolName);
                if (numberFlagged > 0)
                {
                    camp.SurveysValidated = CompletedCamp.Validated.Yes;
                }
                else if (numberFlagged == 0)
                {
                    camp.SurveysValidated = CompletedCamp.Validated.No;
                }
            }

            //remove survey statistics in view if completed camp list is empty to prevent errors
            bool isEmpty = !compltedCamps.Any();
            if (isEmpty == false)
            {
                ViewBag.Validation = true;
            }
            else
            {
                ViewBag.Validation = false;
            }


            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(compltedCamps.ToPagedList(pageNumber, pageSize));
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
        public ActionResult Edit([Bind(Include = "Id,RollNumber,OfficialSchoolName,TeacherName,Address1,Address2,Address3,Address4,Eircode,County,Email,PhoneNumber,Date,StartTime,EndTime,Surveys,AcademicYear,LocalAuthority,X,Y,ITMEast,ITMNorth,Latitude,Longitude,ClassGroups,Topics,LecturerName,PrincipalName,DeisSchool,SchoolGender,PupilAttendanceType,IrishClassification,GaeltachtArea,FeePayingSchool,Religion,OpenClosedStatus,TotalGirls,TotalBoys,TotalPupils,SurveysValidated, NumberSurveys, NumberFlaggedSurveys")] CompletedCamp completedCamp)
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


       
        public ActionResult Upload(int? id)
        {
            CompletedCamp completedCamp = db.CompletedCamps.Find(id);
            return View(completedCamp);
        }

        [HttpPost]
        public async Task<ActionResult> Upload(HttpPostedFileBase file, int? id)
        {
            CompletedCamp completedCamp = db.CompletedCamps.Find(id);

            string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
            string filepath = Server.MapPath(Path.Combine("~/Surveys/", filename));
            file.SaveAs(filepath);

            completedCamp.SurveyName = filename;
            db.SaveChanges();

            //send PDF to Azure OCR Read API and saved returned text in textfile
            await AzureVisionAPI.ExtractToTextFile(filepath);
            //extract survey answers from textfile
            ParseSurveyText parse1 = new ParseSurveyText();
            parse1.ParseTextFile(completedCamp.RollNumber, completedCamp.OfficialSchoolName, completedCamp.Date, filepath);

            var s1 = db.SecondarySchoolSurveys.Where(s => s.RollNumber == completedCamp.RollNumber);
            bool isEmpty = !s1.Any();
            if (isEmpty)
            {
                return RedirectToAction("Error", "CompletedCamps");
            }
            else
            {
                return RedirectToAction("Confirmation", "CompletedCamps", new { id = id });
            }

        }

        [HttpGet]
        public ActionResult Confirmation(int? id)
        {
            var camp = db.CompletedCamps.FirstOrDefault(c => c.Id == id);
            return View(camp);
        }

        public ActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml", null);
        }

        public ActionResult Validate(int? id)
        {
            CompletedCamp completedCamp = db.CompletedCamps.Find(id);
            //direct to list flagged surveys with school id
            return RedirectToAction("Index", "FlaggedSurveys", new { id = id });
        }

    }
}
