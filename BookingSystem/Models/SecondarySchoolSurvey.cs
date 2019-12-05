//Craig Whelan X00075734

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookingSystem.Models
{
    public enum Gender
    {
        None,
        Male,
        Female,
        Other
    }
    public enum MathLevel
    {
        None,
        Higher,
        Ordinary,
        Other
    }
    public enum ScienceSubjects
    {
        None,
        Physics,
        Biology,
        Chemistry,
        ScienceJunior
    }
    public enum Measure
    {
        None,
        StronglyAgree,
        Agree,
        NoOpinion,
        Disagree,
        StronglyDisagree
    }
    public enum YesNo
    {
        None,
        Yes,
        No
    }
    public enum CompExperience
    {
        None,
        CoderDojo,
        School,
        Camp,
        SelfTaught,
        Other
    }
    public enum GoodBad
    {
        None,
        Good,
        NeitherGoodOrBad,
        Bad
    }
    public class SecondarySchoolSurvey
    {
        private double q1;
        private double q6b;

        [Display(Name = "Recent Math Result")]
        public double Q6b
        {
            get { return q6b; }
            set 
            {
                q6b = value;
                //if (value >= 0 && value <= 100)
                //{
                //    q6b = value;
                //}
            }
        }


        [Display(Name = "Age")]
        public double Q1
        {
            get { return q1; }
            set 
            {
                q1 = value;
                //if (q1 > 5 && q1 < 25)
                //{
                //    q1 = value;
                //}
                //else
                //{
                //    throw new ArgumentException("Age must be between 5 and 25");
                //}
            }
        }

        public int Id { get; set; }
        public string RollNumber { get; set; }
        public string OfficialSchoolName { get; set; }
        public DateTime? CampDate { get; set; }
        public string SurveyFileName { get; set; }
        public int FilePage { get; set; }

        [Display(Name = "Gender")]
        public Gender Q2 { get; set; }
        [Display(Name = "Hours Gaming")]
        public string Q3 { get; set; }
        [Display(Name = "Hours Social Media")]
        public string Q4 { get; set; }
        [Display(Name = "Hours Working")]
        public string Q5 { get; set; }
        [Display(Name = "Math Level")]
        public MathLevel Q6a { get; set; }
        [Display(Name = "Science Subjects")]
        public ScienceSubjects Q7 { get; set; }
        [Display(Name = "Computing Jobs Known")]
        public string Q8 { get; set; }
        [Display(Name = "Consider IT Job")]
        public Measure Q9 { get; set; }
        [Display(Name = "IT Skills Perception")]
        public Measure Q10 { get; set; }
        [Display(Name = "2 Reasons Against IT Job")]
        public string Q11 { get; set; }
        [Display(Name = "2 Role Models & Jobs")]
        public string Q12 { get; set; }
        [Display(Name = "Family Members in IT")]
        public YesNo Q13a { get; set; }
        [Display(Name = "Which family member")]
        public string Q13b { get; set; }
        [Display(Name = "Previous Computing Experience")]
        public CompExperience Q14a { get; set; }
        [Display(Name = "Good or Bad Experience")]
        public GoodBad Q14b { get; set; }
        [Display(Name = "Why was this?")]
        public string Q14c { get; set; }
        [Display(Name = "Consider a Job in IT")]
        public Measure Q15 { get; set; }
        [Display(Name = "Camp IT Insight")]
        public Measure Q16 { get; set; }
        [Display(Name = "Camp IT Skills Insight")]
        public Measure Q17 { get; set; }
        [Display(Name = "New Computing Knowledge")]
        public string Q18 { get; set; }
        [Display(Name = "Camp  IT Skills Insight 2")]
        public Measure Q19 { get; set; }
        [Display(Name = "Feedback")]
        public string Q20 { get; set; }

        [Display(Name = "Flag")]
        public bool Flag { get; set; }
        [Display(Name = "Flag Content")]
        public string FlagContent { get; set; }


    }
}