using BookingSystem.Models;
using BookingSystem.Survey_Extraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//Checks which checkbox have been marked for each question to determine answer to question
namespace BookingSystem.Survey_Extraction
{
    public class SurveyCheckboxAnswers
    {
        private RDSContext db = new RDSContext();

        //Adds Question 2 answer
        public void AddQ2Answer(SurveyCheckboxCollections checkboxes, int id)
        {
            //find Survey record in db which matches id in order to update with checkbox data
            var s1 = db.SecondarySchoolSurveys.FirstOrDefault(s => s.Id == id);

            CheckboxData q2Male = checkboxes.SecondarySchoolCheckboxes["Q2Male"];
            CheckboxData q2Female = checkboxes.SecondarySchoolCheckboxes["Q2Female"];
            CheckboxData q2Other = checkboxes.SecondarySchoolCheckboxes["Q2Other"];
            CheckboxData q2DontWantToSay = checkboxes.SecondarySchoolCheckboxes["Q2DontWantToSay"];

            int checkboxValidaiton = 0;

            if (q2Male.IsChecked)
            {
                s1.Q2 = Gender.Male;
                checkboxValidaiton++;
            }
            if (q2Female.IsChecked)
            {
                s1.Q2 = Gender.Female;
                checkboxValidaiton++;
            }
            if (q2Other.IsChecked)
            {
                s1.Q2 = Gender.Other;
                checkboxValidaiton++;
            }
            if (q2DontWantToSay.IsChecked)
            {
                s1.Q2 = Gender.None;
                checkboxValidaiton++;
            }

            //validate only 1 checkbox has been marked 
            if(checkboxValidaiton == 0)
            {
                s1.Flag = true;
                s1.FlagContent += "question2: no checkboxes marked. ";
            }
            else if (checkboxValidaiton > 1)
            {
                s1.Flag = true;
                s1.FlagContent += "question2: more than 1 checkboxes marked. ";
            }

            db.SaveChanges();
        }

        //Adds Question 6 answer
        public void AddQ6Answer(SurveyCheckboxCollections checkboxes, int id)
        {
            //find Survey record in db which matches id in order to update with checkbox data
            var s1 = db.SecondarySchoolSurveys.FirstOrDefault(s => s.Id == id);

            CheckboxData q6Higher = checkboxes.SecondarySchoolCheckboxes["Q6Higher"];
            CheckboxData q6Ordinary = checkboxes.SecondarySchoolCheckboxes["Q6Ordinary"];
            CheckboxData q6Other = checkboxes.SecondarySchoolCheckboxes["Q6Other"];


            if (q6Higher.IsChecked)
            {
                s1.Q6a = MathLevel.Higher;
            }
            else if (q6Ordinary.IsChecked)
            {
                s1.Q6a = MathLevel.Ordinary;
            }
            else if (q6Other.IsChecked)
            {
                s1.Q6a = MathLevel.Other;
            }
            else
            {
                s1.Q6a = MathLevel.None;
            }


            db.SaveChanges();
        }

        //Adds Question 7 answer
        public void AddQ7Answer(SurveyCheckboxCollections checkboxes, int id)
        {
            //find Survey record in db which matches id in order to update with checkbox data
            var s1 = db.SecondarySchoolSurveys.FirstOrDefault(s => s.Id == id);

            CheckboxData q7Physics = checkboxes.SecondarySchoolCheckboxes["Q7Physics"];
            CheckboxData q7Biology = checkboxes.SecondarySchoolCheckboxes["Q7Biology"];
            CheckboxData q7Chemistry = checkboxes.SecondarySchoolCheckboxes["Q7Chemistry"];
            CheckboxData q7Science = checkboxes.SecondarySchoolCheckboxes["Q7Science"];
            CheckboxData q7None = checkboxes.SecondarySchoolCheckboxes["Q7None"];


            if (q7Physics.IsChecked)
            {
                s1.Q7 = ScienceSubjects.Physics;
            }
            else if (q7Biology.IsChecked)
            {
                s1.Q7 = ScienceSubjects.Biology;
            }
            else if (q7Chemistry.IsChecked)
            {
                s1.Q7 = ScienceSubjects.Chemistry;
            }
            else if (q7Science.IsChecked)
            {
                s1.Q7 = ScienceSubjects.ScienceJunior;
            }
            else
            {
                s1.Q7 = ScienceSubjects.None;
            }

            db.SaveChanges();
        }

        //Adds Question 9 answer
        public void AddQ9Answer(SurveyCheckboxCollections checkboxes, int id)
        {
            //find Survey record in db which matches id in order to update with checkbox data
            var s1 = db.SecondarySchoolSurveys.FirstOrDefault(s => s.Id == id);

            CheckboxData q9StrongAgree = checkboxes.SecondarySchoolCheckboxes["Q9StrongAgree"];
            CheckboxData q9Agree = checkboxes.SecondarySchoolCheckboxes["Q9Agree"];
            CheckboxData q9NoOpinion = checkboxes.SecondarySchoolCheckboxes["Q9NoOpinion"];
            CheckboxData q9Disagree = checkboxes.SecondarySchoolCheckboxes["Q9Disagree"];
            CheckboxData q9StrongDisagree = checkboxes.SecondarySchoolCheckboxes["Q9StrongDisagree"];


            if (q9StrongAgree.IsChecked)
            {
                s1.Q9 = Measure.StronglyAgree;
            }
            else if (q9Agree.IsChecked)
            {
                s1.Q9 = Measure.Agree;
            }
            else if (q9NoOpinion.IsChecked)
            {
                s1.Q9 = Measure.NoOpinion;
            }
            else if (q9Disagree.IsChecked)
            {
                s1.Q9 = Measure.Disagree;
            }
            else
            {
                s1.Q9 = Measure.None;
            }

            db.SaveChanges();
        }

        //Adds Question 10 answer
        public void AddQ10Answer(SurveyCheckboxCollections checkboxes, int id)
        {
            //find Survey record in db which matches id in order to update with checkbox data
            var s1 = db.SecondarySchoolSurveys.FirstOrDefault(s => s.Id == id);

            CheckboxData q10StrongAgree = checkboxes.SecondarySchoolCheckboxes["Q10StrongAgree"];
            CheckboxData q10Agree = checkboxes.SecondarySchoolCheckboxes["Q10Agree"];
            CheckboxData q10NoOpinion = checkboxes.SecondarySchoolCheckboxes["Q10NoOpinion"];
            CheckboxData q10Disagree = checkboxes.SecondarySchoolCheckboxes["Q10Disagree"];
            CheckboxData q10StrongDisagree = checkboxes.SecondarySchoolCheckboxes["Q10StrongDisagree"];


            if (q10StrongAgree.IsChecked)
            {
                s1.Q10 = Measure.StronglyAgree;
            }
            else if (q10Agree.IsChecked)
            {
                s1.Q10 = Measure.Agree;
            }
            else if (q10NoOpinion.IsChecked)
            {
                s1.Q10 = Measure.NoOpinion;
            }
            else if (q10Disagree.IsChecked)
            {
                s1.Q10 = Measure.Disagree;
            }
            else if (q10StrongDisagree.IsChecked)
            {
                s1.Q10 = Measure.StronglyDisagree;
            }
            else
            {
                s1.Q10 = Measure.None;
            }

            db.SaveChanges();
        }


        //Adds Question 13 answer
        public void AddQ13Answer(SurveyCheckboxCollections checkboxes, int id)
        {
            //find Survey record in db which matches id in order to update with checkbox data
            var s1 = db.SecondarySchoolSurveys.FirstOrDefault(s => s.Id == id);

            CheckboxData q13Yes = checkboxes.SecondarySchoolCheckboxesP2["Q13Yes"];
            CheckboxData q13No = checkboxes.SecondarySchoolCheckboxesP2["Q13No"];



            if (q13Yes.IsChecked)
            {
                s1.Q13a = YesNo.Yes;
            }
            else if (q13No.IsChecked)
            {
                s1.Q13a = YesNo.No;
            }
            else
            {
                s1.Q13a = YesNo.None;
            }
    

            db.SaveChanges();
        }

        //Adds Question 14a answer
        public void AddQ14aAnswer(SurveyCheckboxCollections checkboxes, int id)
        {
            //find Survey record in db which matches id in order to update with checkbox data
            var s1 = db.SecondarySchoolSurveys.FirstOrDefault(s => s.Id == id);

            CheckboxData q14CoderDojo = checkboxes.SecondarySchoolCheckboxesP2["Q14CoderDojo"];
            CheckboxData q14InSchool = checkboxes.SecondarySchoolCheckboxesP2["Q14InSchool"];
            CheckboxData q14Camp = checkboxes.SecondarySchoolCheckboxesP2["Q14Camp"];
            CheckboxData q14SelfTaught = checkboxes.SecondarySchoolCheckboxesP2["Q14SelfTaught"];
            CheckboxData q14Other = checkboxes.SecondarySchoolCheckboxesP2["Q14Other"];



            if (q14CoderDojo.IsChecked)
            {
                s1.Q14a = CompExperience.CoderDojo;
            }
            else if (q14InSchool.IsChecked)
            {
                s1.Q14a = CompExperience.School;
            }
            else if (q14Camp.IsChecked)
            {
                s1.Q14a = CompExperience.Camp;
            }
            else if (q14SelfTaught.IsChecked)
            {
                s1.Q14a = CompExperience.SelfTaught;
            }
            else if (q14Other.IsChecked)
            {
                s1.Q14a = CompExperience.Other;
            }
            else
            {
                s1.Q14a = CompExperience.None;
            }


            db.SaveChanges();
        }

        //Adds Question 14b answer
        public void AddQ14bAnswer(SurveyCheckboxCollections checkboxes, int id)
        {
            //find Survey record in db which matches id in order to update with checkbox data
            var s1 = db.SecondarySchoolSurveys.FirstOrDefault(s => s.Id == id);

            CheckboxData q14bGood = checkboxes.SecondarySchoolCheckboxesP2["Q14bGood"];
            CheckboxData q14bNeither = checkboxes.SecondarySchoolCheckboxesP2["Q14bNeither"];
            CheckboxData q14bBad = checkboxes.SecondarySchoolCheckboxesP2["Q14bBad"];



            if (q14bGood.IsChecked)
            {
                s1.Q14b = GoodBad.Good;
            }
            else if (q14bNeither.IsChecked)
            {
                s1.Q14b = GoodBad.NeitherGoodOrBad;
            }
            else if (q14bBad.IsChecked)
            {
                s1.Q14b = GoodBad.Bad;
            }
            else
            {
                s1.Q14b = GoodBad.None;
            }

            db.SaveChanges();
        }

        //Adds Question 15 answer
        public void AddQ15Answer(SurveyCheckboxCollections checkboxes, int id)
        {
            //find Survey record in db which matches id in order to update with checkbox data
            var s1 = db.SecondarySchoolSurveys.FirstOrDefault(s => s.Id == id);

            CheckboxData q15StrongAgree = checkboxes.SecondarySchoolCheckboxesP2["Q15StrongAgree"];
            CheckboxData q15Agree = checkboxes.SecondarySchoolCheckboxesP2["Q15Agree"];
            CheckboxData q15NoOpinion = checkboxes.SecondarySchoolCheckboxesP2["Q15NoOpinion"];
            CheckboxData q15Disagree = checkboxes.SecondarySchoolCheckboxesP2["Q15Disagree"];
            CheckboxData q15StrongDisagree = checkboxes.SecondarySchoolCheckboxesP2["Q15StrongDisagree"];


            if (q15StrongAgree.IsChecked)
            {
                s1.Q15 = Measure.StronglyAgree;
            }
            else if (q15Agree.IsChecked)
            {
                s1.Q15 = Measure.Agree;
            }
            else if (q15NoOpinion.IsChecked)
            {
                s1.Q15 = Measure.NoOpinion;
            }
            else if (q15Disagree.IsChecked)
            {
                s1.Q15 = Measure.Disagree;
            }
            else if (q15StrongDisagree.IsChecked)
            {
                s1.Q15 = Measure.StronglyDisagree;
            }
            else
            {
                s1.Q15 = Measure.None;
            }

            db.SaveChanges();
        }

        //Adds Question 16 answer
        public void AddQ16Answer(SurveyCheckboxCollections checkboxes, int id)
        {
            //find Survey record in db which matches id in order to update with checkbox data
            var s1 = db.SecondarySchoolSurveys.FirstOrDefault(s => s.Id == id);

            CheckboxData q16StrongAgree = checkboxes.SecondarySchoolCheckboxesP2["Q16StrongAgree"];
            CheckboxData q16Agree = checkboxes.SecondarySchoolCheckboxesP2["Q16Agree"];
            CheckboxData q16NoOpinion = checkboxes.SecondarySchoolCheckboxesP2["Q16NoOpinion"];
            CheckboxData q16Disagree = checkboxes.SecondarySchoolCheckboxesP2["Q16Disagree"];
            CheckboxData q16StrongDisagree = checkboxes.SecondarySchoolCheckboxesP2["Q16StrongDisagree"];


            if (q16StrongAgree.IsChecked)
            {
                s1.Q16 = Measure.StronglyAgree;
            }
            else if (q16Agree.IsChecked)
            {
                s1.Q16 = Measure.Agree;
            }
            else if (q16NoOpinion.IsChecked)
            {
                s1.Q16 = Measure.NoOpinion;
            }
            else if (q16Disagree.IsChecked)
            {
                s1.Q16 = Measure.Disagree;
            }
            else if (q16StrongDisagree.IsChecked)
            {
                s1.Q16 = Measure.StronglyDisagree;
            }
            else
            {
                s1.Q16 = Measure.None;
            }

            db.SaveChanges();
        }

        //Adds Question 17 answer
        public void AddQ17Answer(SurveyCheckboxCollections checkboxes, int id)
        {
            //find Survey record in db which matches id in order to update with checkbox data
            var s1 = db.SecondarySchoolSurveys.FirstOrDefault(s => s.Id == id);

            CheckboxData q17StrongAgree = checkboxes.SecondarySchoolCheckboxesP2["Q17StrongAgree"];
            CheckboxData q17Agree = checkboxes.SecondarySchoolCheckboxesP2["Q17Agree"];
            CheckboxData q17NoOpinion = checkboxes.SecondarySchoolCheckboxesP2["Q17NoOpinion"];
            CheckboxData q17Disagree = checkboxes.SecondarySchoolCheckboxesP2["Q17Disagree"];
            CheckboxData q17StrongDisagree = checkboxes.SecondarySchoolCheckboxesP2["Q17StrongDisagree"];


            if (q17StrongAgree.IsChecked)
            {
                s1.Q17 = Measure.StronglyAgree;
            }
            else if (q17Agree.IsChecked)
            {
                s1.Q17 = Measure.Agree;
            }
            else if (q17NoOpinion.IsChecked)
            {
                s1.Q17 = Measure.NoOpinion;
            }
            else if (q17Disagree.IsChecked)
            {
                s1.Q17 = Measure.Disagree;
            }
            else if (q17StrongDisagree.IsChecked)
            {
                s1.Q17 = Measure.StronglyDisagree;
            }
            else
            {
                s1.Q17 = Measure.None;
            }

            db.SaveChanges();
        }

        //Adds Question 19 answer
        public void AddQ19Answer(SurveyCheckboxCollections checkboxes, int id)
        {
            //find Survey record in db which matches id in order to update with checkbox data
            var s1 = db.SecondarySchoolSurveys.FirstOrDefault(s => s.Id == id);

            CheckboxData q19StrongAgree = checkboxes.SecondarySchoolCheckboxesP2["Q19StrongAgree"];
            CheckboxData q19Agree = checkboxes.SecondarySchoolCheckboxesP2["Q19Agree"];
            CheckboxData q19NoOpinion = checkboxes.SecondarySchoolCheckboxesP2["Q19NoOpinion"];
            CheckboxData q19Disagree = checkboxes.SecondarySchoolCheckboxesP2["Q19Disagree"];
            CheckboxData q19StrongDisagree = checkboxes.SecondarySchoolCheckboxesP2["Q19StrongDisagree"];


            if (q19StrongAgree.IsChecked)
            {
                s1.Q19 = Measure.StronglyAgree;
            }
            else if (q19Agree.IsChecked)
            {
                s1.Q19 = Measure.Agree;
            }
            else if (q19NoOpinion.IsChecked)
            {
                s1.Q19 = Measure.NoOpinion;
            }
            else if (q19Disagree.IsChecked)
            {
                s1.Q19 = Measure.Disagree;
            }
            else if (q19StrongDisagree.IsChecked)
            {
                s1.Q19 = Measure.StronglyDisagree;
            }
            else
            {
                s1.Q19 = Measure.None;
            }

            db.SaveChanges();
        }
    }
}