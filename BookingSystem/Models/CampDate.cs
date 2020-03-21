//Craig Whelan X00075734

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//Holds available camp dates & their information

namespace BookingSystem.Models
{
    public class CampDate
    {
        //remove timestamp from DateTime
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yy}")]
        public DateTime Date { get; set; }
        public int Id { get; set; }
        public string LecturerName { get; set; }
        public string Comment { get; set; }
    }
}