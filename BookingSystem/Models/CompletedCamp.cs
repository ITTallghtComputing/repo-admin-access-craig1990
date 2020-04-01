//Craig Whelan X00075734

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingSystem.Models
{
    
    public class CompletedCamp
    {
        public enum Validated
        {
            No,
            Yes
        }

        private RDSContext db = new RDSContext();

        public int Id { get; set; }
        public string RollNumber { get; set; }
        [Required]
        [DisplayName("School/Organisation Name")]
        public string OfficialSchoolName { get; set; }
        [Required]
        public string TeacherName { get; set; }
        [Required]
        public string Address1 { get; set; }
        [Required]
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Eircode { get; set; }
        public string County { get; set; }
        [Required]
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        //remove timestamp from DateTime
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }
        [Required]
        public string StartTime { get; set; }
        [Required]
        public string EndTime { get; set; }
        public bool? Surveys { get; set; }
        public string AcademicYear { get; set; }
        public string LocalAuthority { get; set; }
        public decimal X { get; set; }
        public decimal Y { get; set; }
        public decimal ITMEast { get; set; }
        public decimal ITMNorth { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        [Required]
        public string ClassGroups { get; set; }
        [Required]
        public string Topics { get; set; }
        [DisplayName("Lecturer Name")]
        public string LecturerName { get; set; }
        [DisplayName("Organisation Name")]
        public string PrincipalName { get; set; }
        public string DeisSchool { get; set; }
        public string SchoolGender { get; set; }
        public string PupilAttendanceType { get; set; }
        public string IrishClassification { get; set; }
        public string GaeltachtArea { get; set; }
        public string FeePayingSchool { get; set; }
        public string Religion { get; set; }
        public string OpenClosedStatus { get; set; }
        public int TotalGirls { get; set; }
        public int TotalBoys { get; set; }
        public int TotalPupils { get; set; }
        public string SurveyName { get; set; }
        [DisplayName("Validation Required")]
        public Validated SurveysValidated { get; set; }

        //get total number of student surveys
        public int Tpupils
        {
            get
            {
                int studentTotal = db.SecondarySchoolSurveys.Count();
                return studentTotal;
            }
        }

        //get total number of girl student surveys
        public int Tgirls
        {
            get
            {
                int totalGirls = db.SecondarySchoolSurveys.Where(p => p.Q2 == Gender.Female).Count();
                return totalGirls;
            }
        }

        //get total number of male student surveys
        public int Tboys
        {
            get
            {
                int totalBoys = db.SecondarySchoolSurveys.Where(p => p.Q2 == Gender.Male).Count();
                return totalBoys;
            }
        }

        //get total number of surveys uploaded for a school camp
        [DisplayName("Surveys Processed")]
        public int NumberSurveys
        {
            get
            {
                int numberSurveys = db.SecondarySchoolSurveys.Where(s => s.RollNumber == RollNumber).Count();
                return numberSurveys;
            }
        }

        //return current number of flagged surveys
        public int NumberFlaggedSurveys
        {
            get
            {
                int numberFlagged = db.SecondarySchoolSurveys.Count(s => s.Flag == true && s.OfficialSchoolName == OfficialSchoolName);
                return numberFlagged;
            }
        }

        //set number of flagged camp surveys
        public int InitialNumFlaggedSurveys { get; set; }
        public void setNumberFlaggedSurveys()
        {
                int numberFlagged = db.SecondarySchoolSurveys.Count(s => s.Flag == true && s.OfficialSchoolName == OfficialSchoolName);
                InitialNumFlaggedSurveys = numberFlagged;
        }
    }
}