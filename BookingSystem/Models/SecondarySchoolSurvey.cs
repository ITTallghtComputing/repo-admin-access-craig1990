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
        


        [Display(Name = "Q1. Age")]
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
        [DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        public DateTime? CampDate { get; set; }
        public string SurveyFileName { get; set; }
        public int FilePage { get; set; }

        [Display(Name = "Q2. Gender")]
        public Gender Q2 { get; set; }
        [Display(Name = "Q3. Hours Gaming")]
        public string Q3 { get; set; }
        [Display(Name = "Q4. Hours Social Media")]
        public string Q4 { get; set; }
        [Display(Name = "Q5. Hours Working")]
        public string Q5 { get; set; }
        [Display(Name = "Q6a. Math Level")]
        public MathLevel Q6a { get; set; }
        [Display(Name = "Q6b. Recent Math Result")]
        public string Q6b { get; set; }
        [Display(Name = "Q7. Science Subjects")]
        public ScienceSubjects Q7 { get; set; }
        [Display(Name = "Q8. Computing Jobs Known")]
        public string Q8 { get; set; }
        [Display(Name = "Q9. Consider IT Job")]
        public Measure Q9 { get; set; }
        [Display(Name = "Q10. IT Skills Perception")]
        public Measure Q10 { get; set; }
        [Display(Name = "Q11. 2 Reasons Against IT Job")]
        public string Q11 { get; set; }
        [Display(Name = "Q12. 2 Role Models & Jobs")]
        public string Q12 { get; set; }
        [Display(Name = "Q13a. Family Members in IT")]
        public YesNo Q13a { get; set; }
        [Display(Name = "Q13b. Which family member")]
        public string Q13b { get; set; }
        [Display(Name = "Q14a. Previous Computing Experience")]
        public CompExperience Q14a { get; set; }
        [Display(Name = "Q14b. Good or Bad Experience")]
        public GoodBad Q14b { get; set; }
        [Display(Name = "Q14c. Why was this?")]
        public string Q14c { get; set; }
        [Display(Name = "Q1. Consider a Job in IT")]
        public Measure Q15 { get; set; }
        [Display(Name = "Q2. Camp IT Insight")]
        public Measure Q16 { get; set; }
        [Display(Name = "Q3. Camp IT Skills Insight")]
        public Measure Q17 { get; set; }
        [Display(Name = "Q4. New Computing Knowledge")]
        public string Q18 { get; set; }
        [Display(Name = "Q5. Camp  IT Skills Insight 2")]
        public Measure Q19 { get; set; }
        [Display(Name = "Q6. Feedback")]
        public string Q20 { get; set; }

        [Display(Name = "Flag")]
        public bool Flag { get; set; }
        [Display(Name = "Flag Content")]
        public string FlagContent { get; set; }

    }
}