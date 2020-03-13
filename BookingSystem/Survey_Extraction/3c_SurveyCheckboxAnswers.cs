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
        public void AddQ2Answer(SurveyCheckboxCollections checkboxesP1, int id)
        {
            //find Survey record in db which matches id in order to update with checkbox data
            var s1 = db.SecondarySchoolSurveys.FirstOrDefault(s => s.Id == id);

            CheckboxData q2Male = checkboxesP1.SecondarySchoolCheckboxes["Q2Male"];
            CheckboxData q2Female = checkboxesP1.SecondarySchoolCheckboxes["Q2Female"];
            CheckboxData q2Other = checkboxesP1.SecondarySchoolCheckboxes["Q2Other"];
            CheckboxData q2DontWantToSay = checkboxesP1.SecondarySchoolCheckboxes["Q2DontWantToSay"];

            if (q2Male.IsChecked)
            {
                s1.Q2 = Gender.Male;
            }
            else if (q2Female.IsChecked)
            {
                s1.Q2 = Gender.Female;
            }
            else if (q2Other.IsChecked)
            {
                s1.Q2 = Gender.Other;
            }
            else
            {
                s1.Q2 = Gender.None;
            }

            db.SaveChanges();
        }

        //Adds Question 6 answer
        public void AddQ6Answer(SurveyCheckboxCollections checkboxesP1, int id)
        {
            //find Survey record in db which matches id in order to update with checkbox data
            var s1 = db.SecondarySchoolSurveys.FirstOrDefault(s => s.Id == id);

            CheckboxData q6Higher = checkboxesP1.SecondarySchoolCheckboxes["Q6Higher"];
            CheckboxData q6Ordinary = checkboxesP1.SecondarySchoolCheckboxes["Q6Ordinary"];
            CheckboxData q6Other = checkboxesP1.SecondarySchoolCheckboxes["Q6Other"];


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

    }
}