using BookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSystem.Helpers
{
    public class EnterSchoolSurvey
    {
        private RDSContext db = new RDSContext();

        //Enters new Survey with its data into db.SecondarySchool Survey database
        //attach roll numnber, school name and camp data to survey
        public void EnterSurvey(string rollNumber, string officialSchoolName, DateTime? campDate)
        {
            SecondarySchoolSurvey s1 = new SecondarySchoolSurvey();
            s1.RollNumber = rollNumber;
            s1.OfficialSchoolName = officialSchoolName;
            s1.CampDate = campDate;
            s1.SurveyFileName = null;
            //s1.FilePage = pageNumber;
            //s1.Q8 = answer8;
            //s1.Q11 = answer11;
            //s1.Q12 = answer12;
            //s1.Q13b = answer13b;
            //s1.Q14c = answer14c;
            //s1.Q18 = answer18;
            //s1.Q20 = answer20;
            //s1.Q1 = answer1;
            //s1.Q3 = answer3;
            //s1.Q6b = answer6b;

            db.SecondarySchoolSurveys.Add(s1);
            db.SaveChanges();
        }
    }
}