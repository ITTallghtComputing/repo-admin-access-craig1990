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
    public class SecondarySchool
    {
        [Display(Name = "Age")]
        private double q1;
        [Display(Name = "Hours Gaming")]
        private double q3;
        [Display(Name = "Hours Social Media")]
        private double q4;
        [Display(Name = "Hours Working")]
        private double q5;
        [Display(Name = "Recent Math Result")]
        private double q6b;

        public double MathResult
        {
            get { return q6b; }
            set 
            { 
                if (value >= 0 && value <= 100)
                {
                    q6b = value;
                }
            }
        }


        public double Q5
        {
            get { return q5; }
            set
            {
                if (value <= 50)
                {
                    q5 = value;
                }
            }
        }


        public double Q4
        {
            get { return q4; }
            set
            {
                if (value <= 24)
                {
                    q4 = value;
                }
            }
        }


        public double Q3
        {
            get { return q3; }

            set
            {
                if (value <= 24)
                {
                    q3 = value;
                }
            }
        }

        public double Q1
        {
            get { return q1; }
            set 
            {
                if (q1 > 5 && q1 < 25)
                {
                    q1 = value;
                }
                else
                {
                    throw new ArgumentException("Age must be between 5 and 25");
                }
            }
        }

        public bool Flag { get; set; }
        public string FlagContent { get; set; }
        public Gender Gender { get; set; }
        public MathLevel MathLevel { get; set; }
        public ScienceSubjects ScienceSubjects { get; set; }
        public string ITJobs { get; set; }
        public Measure ConsiderIT { get; set; }
        public Measure ITPerception { get; set; }
        public string ReasonsAgainstIT { get; set; }
        public string ITRoleModels { get; set; }
        public YesNo ITFamilyMembers { get; set; }
        public string FamilyMember { get; set; }
        public CompExperience CompExperience { get; set; }
        public GoodBad Experience { get; set; }
        public string ExperienceReason { get; set; }
        public Measure ConsiderIT2 { get; set; }
        public Measure CampITInsight { get; set; }
        public Measure CampSkillsInsight { get; set; }
        public string NewKnowledge { get; set; }
        public Measure CampSkillsInsight2 { get; set; }
        public string Feedback { get; set; }


    }
}