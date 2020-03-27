//Craig Whelan X00075734

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//stores school data from .csv type 1

namespace BookingSystem.Models
{
    public class School
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Valid School Roll Number Required")]
        public string RollNumber { get; set; }
        public string OfficialSchoolName { get; set; }
        public string TeacherName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string Eircode { get; set; }
        public string County { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        //remove timestamp from DateTime
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }
        public string StartTime { get; set; }
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
        public string ClassGroups { get; set; }
        public string Topics { get; set; }
        public string ValidationMsg { get; set; }
        public string LecturerName { get; set; }
        public string PrincipalName { get; set; }
        public string DeisSchool { get; set; }
        public string SchoolGender { get; set; }
        public string PupilAttendanceType { get; set; }
        public string IrishClassification { get; set; }
        public string GaeltachtArea { get; set; }
        public string FeePayingSchool { get; set; }
        public string Religion { get; set; }
        public string OpenClosedStatus { get; set; }
        public int? TotalGirls { get; set; }
        public int? TotalBoys { get; set; }
        public int? TotalPupils { get; set; }
    }
}