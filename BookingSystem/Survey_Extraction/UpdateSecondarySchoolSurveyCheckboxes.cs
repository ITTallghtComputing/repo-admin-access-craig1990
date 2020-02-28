using BookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSystem.Helpers
{
    //Updates a Secondary School Survey with the extracted checkbox data

    public class SubmitSecondarySchoolSurveyCheckboxes
    {
        private RDSContext db = new RDSContext();

        public void UpdateSurvey(SurveyCheckboxCollections checkboxesP1, SurveyCheckboxCollections checkboxesP2, int id)
        {
            //find Survey record in db which matches id in order to update with checkbox data
            var s1 = db.SecondarySchoolSurveys.FirstOrDefault(s => s.Id == id);

            CheckboxData q2Male = checkboxesP1.SecondarySchoolCheckboxes["Q2Male"];
            CheckboxData q2Female = checkboxesP1.SecondarySchoolCheckboxes["Q2Female"];
            CheckboxData q2Other = checkboxesP1.SecondarySchoolCheckboxes["Q2Other"];
            CheckboxData q2DontWantToSay = checkboxesP1.SecondarySchoolCheckboxes["Q2DontWantToSay"];

            if(q2Male.IsChecked)
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

    }
}