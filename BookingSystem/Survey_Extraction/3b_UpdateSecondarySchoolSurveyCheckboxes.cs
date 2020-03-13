using BookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSystem.Survey_Extraction
{
    //Updates a Secondary School Survey with the extracted checkbox data

    public class SubmitSecondarySchoolSurveyCheckboxes
    {
        private RDSContext db = new RDSContext();

        public void UpdateSurvey(SurveyCheckboxCollections checkboxesP1, SurveyCheckboxCollections checkboxesP2, int id)
        {
      
            SurveyCheckboxAnswers answers = new SurveyCheckboxAnswers();


            answers.AddQ2Answer(checkboxesP1, id);
            answers.AddQ6Answer(checkboxesP1, id);
            answers.AddQ7Answer(checkboxesP1, id);



        }

    }
}