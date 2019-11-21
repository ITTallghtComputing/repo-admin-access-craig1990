using System;
using System.Collections.Generic;
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
        private double age;
        private double hoursGaming;
        private double hoursSocialMedia;
        private double hoursWork;
        private double mathResult;

        public double MathResult
        {
            get { return mathResult; }
            set 
            { 
                if (value >= 0 && value <= 100)
                {
                    mathResult = value;
                }
            }
        }


        public double HoursWork
        {
            get { return hoursWork; }
            set
            {
                if (value <= 50)
                {
                    hoursWork = value;
                }
            }
        }


        public double HoursSocialMedia
        {
            get { return hoursSocialMedia; }
            set
            {
                if (value <= 24)
                {
                    hoursSocialMedia = value;
                }
            }
        }


        public double HoursGaming
        {
            get { return hoursGaming; }

            set
            {
                if (value <= 24)
                {
                    hoursGaming = value;
                }
            }
        }


        public double Age
        {
            get { return age; }
            set 
            {
                if (age > 5 && age < 25)
                {
                    age = value;
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