//Craig Whelan X00075734

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }
        [DisplayName("Roll Number")]
        public string RollNumber { get; set; }
        [Required]
        [DisplayName("School/Organisation Name")]
        public string OfficialSchoolName { get; set; }
        [Required]
        [DisplayName("Teacher Name")]
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
        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }
        [DisplayName("Camp Date")]
        //remove timestamp from DateTime
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? Date { get; set; }
        [Required]
        [DisplayName("Start Time")]
        public string StartTime { get; set; }
        [Required]
        [DisplayName("End Time")]
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
        [DisplayName("Class Groups")]
        public string ClassGroups { get; set; }
        [Required]
        public string Topics { get; set; }
        [DisplayName("Camp Lecturer")]
        public string LecturerName { get; set; }
        [DisplayName("Principal Name")]
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