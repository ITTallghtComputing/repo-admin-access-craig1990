//Craig Whelan X00075734

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//deals with organisations that are not schools and their data

namespace BookingSystem.Models
{
    public class Organisation
    {
        public int Id { get; set; }
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
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yy}")]
        public DateTime? Date { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public bool? Surveys { get; set; }
        public string ClassGroups { get; set; }
        public string Topics { get; set; }
        public string ValidationMsg { get; set; }
        public string LecturerName { get; set; }
    }
}