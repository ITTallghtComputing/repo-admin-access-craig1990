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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yy}")]
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
    }
}