using BookingSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace BookingSystem.Survey_Extraction
{
    //Updates a Secondary School Survey with the extracted checkbox data

    public class SubmitSecondarySchoolSurveyCheckboxes
    {
        private RDSContext db = new RDSContext();

        public async void UpdateSurvey(SurveyCheckboxCollections checkboxes, int id)
        {
      
            SurveyCheckboxAnswers answers = new SurveyCheckboxAnswers();

            //Add Page 1 checkbox answers
            answers.AddQ2Answer(checkboxes, id);
            await Task.Delay(500);
            answers.AddQ6Answer(checkboxes, id);
            await Task.Delay(500);
            answers.AddQ7Answer(checkboxes, id);
            await Task.Delay(500);
            answers.AddQ9Answer(checkboxes, id);
            await Task.Delay(500);
            answers.AddQ10Answer(checkboxes, id);
            await Task.Delay(500);

            //Add Page 2 checkbox answers
            answers.AddQ13Answer(checkboxes, id);
            await Task.Delay(500);
            answers.AddQ14aAnswer(checkboxes, id);
            await Task.Delay(500);
            answers.AddQ14bAnswer(checkboxes, id);
            await Task.Delay(500);
            answers.AddQ15Answer(checkboxes, id);
            await Task.Delay(500);
            answers.AddQ16Answer(checkboxes, id);
            await Task.Delay(500);
            answers.AddQ17Answer(checkboxes, id);
            await Task.Delay(500);
            answers.AddQ19Answer(checkboxes, id);

        }

    }
}