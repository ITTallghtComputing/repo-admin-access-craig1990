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
                {"Q2Male", new CheckboxData() {startX = 184, startY = 192, endX = 239, endY = 225, AveragePixels =  1710.1294f} },
                {"Q2Female", new CheckboxData() {startX = 251, startY = 192, endX = 321, endY = 225, AveragePixels = 2175.5981f } },
                {"Q2Other", new CheckboxData() {startX = 331, startY = 192, endX = 396, endY = 225, AveragePixels = 2022.347f} },
                {"Q2DontWantToSay", new CheckboxData() {startX = 398, startY = 192, endX = 541, endY = 225, AveragePixels = 4391.0137f} },
                //{"Q6Higher", new CheckboxData() {startX = 74, startY = 364, endX = 142, endY =  396} },
                //{"Q6Ordinary", new CheckboxData() {startX = 142, startY = 364, endX = 222, endY =  395} },
                //{"Q6Other", new CheckboxData() {startX = 223, startY = 364, endX = 285, endY =  394} },
                //{"Q7Physics", new CheckboxData() {startX = 74, startY = 414, endX = 144, endY = 445 } },
                //{"Q7Biology", new CheckboxData() {startX = 154, startY = 414, endX = 224, endY = 444 } },
                //{"Q7Chemistry", new CheckboxData() {startX = 236, startY = 413, endX = 319, endY = 444 } },
                //{"Q7Science", new CheckboxData() {startX = 332, startY = 413, endX = 403, endY = 444 } },
                //{"Q7None", new CheckboxData() {startX = 404, startY = 413, endX = 467, endY = 443 } },
                //{"Q9StrongAgree", new CheckboxData() {startX = 94, startY = 520, endX = 111, endY = 534 } },
                //{"Q9Agree", new CheckboxData() {startX = 152, startY = 520, endX = 169, endY = 534 } },
                //{"Q9NoOpinion", new CheckboxData() {startX = 207, startY = 520, endX = 222, endY = 533 } },
                //{"Q9Disagree", new CheckboxData() {startX = 255, startY = 520, endX = 269, endY = 534 } },
                //{"Q9StrongDisagree", new CheckboxData() {startX = 333, startY = 519, endX = 349, endY = 534 } },
                //{"Q10StrongAgree", new CheckboxData() {startX = 94, startY = 567, endX = 111, endY = 581 } },
                //{"Q10Agree", new CheckboxData() {startX = 152, startY = 567, endX = 168, endY = 581 } },
                //{"Q10NoOpinion", new CheckboxData() {startX = 207, startY = 566, endX = 222, endY = 581 } },
                //{"Q10Disagree", new CheckboxData() {startX = 256, startY = 566, endX = 269, endY = 581 } },
                //{"Q10StrongDisagree", new CheckboxData() {startX = 334, startY = 566, endX = 349, endY = 580 } }
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