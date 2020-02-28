using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSystem.Helpers
{
    public class SurveyCheckboxCollections
    {
        private Dictionary<string, CheckboxData> secondarySchoolCheckboxes = new Dictionary<string, CheckboxData>()
            {
                {"Q2Male", new CheckboxData() {startX = 182, startY = 197, endX = 238, endY = 227, AveragePixels = 1609.8711f} },
                {"Q2Female", new CheckboxData() {startX = 249, startY = 196, endX = 313, endY = 239, AveragePixels = 2665.125f } },
                {"Q2Other", new CheckboxData() {startX = 325, startY = 197, endX = 383, endY =  227, AveragePixels = 1669.1561f} },
                {"Q2DontWantToSay", new CheckboxData() {startX = 385, startY = 194, endX = 528, endY =  229, AveragePixels = 4892.9985f} },
                //{"Q6Higher", new CheckboxData() {startX = 80, startY = 361, endX = 141, endY =  389, AveragePixels = 243} },
                //{"Q6Ordinary", new CheckboxData() {startX = 142, startY = 361, endX = 218, endY =  389, AveragePixels = 238} },
                //{"Q6Other", new CheckboxData() {startX = 217, startY = 361, endX = 277, endY =  390} },
                //{"Q7Physics", new CheckboxData() {startX = 78, startY = 408, endX = 144, endY = 438 } },
                //{"Q7Biology", new CheckboxData() {startX = 153, startY = 408, endX = 222, endY = 439 } },
                //{"Q7Chemistry", new CheckboxData() {startX = 231, startY = 408, endX = 310, endY = 439 } },
                //{"Q7Science", new CheckboxData() {startX = 310, startY = 409, endX = 428, endY = 440 } },
                //{"Q7None", new CheckboxData() {startX = 432, startY = 409, endX = 489, endY = 438 } },
                //{"Q9StrongAgree", new CheckboxData() {startX = 94, startY = 511, endX = 112, endY = 525 } },
                //{"Q9Agree", new CheckboxData() {startX = 148, startY = 511, endX = 166, endY = 525 } },
                //{"Q9NoOpinion", new CheckboxData() {startX = 201, startY = 511, endX = 218, endY = 525 } },
                //{"Q9Disagree", new CheckboxData() {startX = 246, startY = 511, endX = 266, endY = 525 } },
                //{"Q9StrongDisagree", new CheckboxData() {startX = 322, startY = 511, endX = 340, endY = 525 } },
                //{"Q10StrongAgree", new CheckboxData() {startX = 94, startY = 556, endX = 112, endY = 569 } },
                //{"Q10Agree", new CheckboxData() {startX = 148, startY = 556, endX = 166, endY = 569 } },
                //{"Q10NoOpinion", new CheckboxData() {startX = 200, startY = 556, endX = 219, endY = 569 } },
                //{"Q10Disagree", new CheckboxData() {startX = 247, startY = 556, endX = 266, endY = 569 } }
            };

        public Dictionary<string, CheckboxData> SecondarySchoolCheckboxes
        {
            get
            {
                return secondarySchoolCheckboxes;
            }
        }

        private Dictionary<string, CheckboxData> secondarySchoolCheckboxesP2 = new Dictionary<string, CheckboxData>()
            {

                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } }
            };

        public Dictionary<string, CheckboxData> SecondarySchoolCheckboxesP2
        {
            get
            {
                return secondarySchoolCheckboxesP2;
            }
        }

    }
}