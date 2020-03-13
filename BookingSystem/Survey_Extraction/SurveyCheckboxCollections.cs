using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookingSystem.Survey_Extraction
{
    public class SurveyCheckboxCollections
    {
        private Dictionary<string, CheckboxData> secondarySchoolCheckboxes = new Dictionary<string, CheckboxData>()
            {
                {"Q2Male", new CheckboxData() {startX = 184, startY = 192, endX = 239, endY = 225, AveragePixels =  1710.1294f} },
                {"Q2Female", new CheckboxData() {startX = 251, startY = 192, endX = 321, endY = 225, AveragePixels = 2175.5981f } },
                {"Q2Other", new CheckboxData() {startX = 331, startY = 192, endX = 396, endY = 225, AveragePixels = 2022.347f} },
                {"Q2DontWantToSay", new CheckboxData() {startX = 398, startY = 192, endX = 541, endY = 225, AveragePixels = 4391.0137f} },
                {"Q6Higher", new CheckboxData() {startX = 74, startY = 364, endX = 142, endY =  396, AveragePixels = 2053.0308f} },
                {"Q6Ordinary", new CheckboxData() {startX = 142, startY = 364, endX = 222, endY =  395, AveragePixels = 2321.1863f} },
                {"Q6Other", new CheckboxData() {startX = 223, startY = 364, endX = 285, endY =  394, AveragePixels = 1745.5236f} },
                {"Q7Physics", new CheckboxData() {startX = 74, startY = 414, endX = 144, endY = 445, AveragePixels = 2041.3314f} },
                {"Q7Biology", new CheckboxData() {startX = 154, startY = 414, endX = 224, endY = 444, AveragePixels = 1957.2627f} },
                {"Q7Chemistry", new CheckboxData() {startX = 236, startY = 413, endX = 319, endY = 444, AveragePixels = 2399.8352f } },
                {"Q7Science", new CheckboxData() {startX = 332, startY = 413, endX = 403, endY = 444, AveragePixels = 2062.9607f} },
                {"Q7None", new CheckboxData() {startX = 404, startY = 413, endX = 467, endY = 443, AveragePixels = 1779.7137f} },
                {"Q9StrongAgree", new CheckboxData() {startX = 94, startY = 520, endX = 111, endY = 534, AveragePixels = 220.29608f } },
                {"Q9Agree", new CheckboxData() {startX = 152, startY = 520, endX = 169, endY = 534, AveragePixels = 217.9804f } },
                {"Q9NoOpinion", new CheckboxData() {startX = 207, startY = 520, endX = 222, endY = 533, AveragePixels = 175.75098f } },
                {"Q9Disagree", new CheckboxData() {startX = 255, startY = 520, endX = 269, endY = 534, AveragePixels = 174.83725f } },
                {"Q9StrongDisagree", new CheckboxData() {startX = 333, startY = 519, endX = 349, endY = 534, AveragePixels = 219.5098f } },
                {"Q10StrongAgree", new CheckboxData() {startX = 94, startY = 567, endX = 111, endY = 581, AveragePixels = 219.52353f } },
                {"Q10Agree", new CheckboxData() {startX = 152, startY = 567, endX = 168, endY = 581, AveragePixels = 203.3647f} },
                {"Q10NoOpinion", new CheckboxData() {startX = 207, startY = 566, endX = 222, endY = 581, AveragePixels = 205.58432f } },
                {"Q10Disagree", new CheckboxData() {startX = 256, startY = 566, endX = 269, endY = 581, AveragePixels = 175.87646f } },
                {"Q10StrongDisagree", new CheckboxData() {startX = 334, startY = 566, endX = 349, endY = 580, AveragePixels = 189.69412f } }
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

                {"Q13Yes", new CheckboxData() {startX = 315, startY = 113, endX = 363, endY = 145, AveragePixels = 1467.2607f } },
                {"Q13No", new CheckboxData() {startX = 374, startY = 113, endX = 420, endY = 145, AveragePixels = 1406.6412f } },
                {"Q14CoderDojo", new CheckboxData() {startX = 72, startY = 201, endX = 158, endY = 230, AveragePixels = 2323.445f} },
                {"Q14InSchool", new CheckboxData() {startX = 168, startY = 201, endX = 248, endY = 232, AveragePixels = 2333.0823f} },
                {"Q14Camp", new CheckboxData() {startX = 249, startY = 201, endX = 305, endY =  232, AveragePixels = 1632.9236f} },
                {"Q14SelfTaught", new CheckboxData() {startX = 310, startY = 201, endX = 401, endY =  232, AveragePixels = 2652.6392f} },
                {"Q14Other", new CheckboxData() {startX = 404, startY = 201, endX = 466, endY =  232, AveragePixels = 1812.7687f} },
                {"Q14bGood", new CheckboxData() {startX = 153, startY = 253, endX = 210, endY = 284, AveragePixels = 1656.7549f } },
                {"Q14bNeither", new CheckboxData() {startX = 211, startY = 253, endX = 356, endY = 284, AveragePixels = 4196.0923f } },
                {"Q14bBad", new CheckboxData() {startX = 365, startY = 253, endX = 424, endY = 286, AveragePixels = 1856.3726f } },
                {"Q15StrongAgree", new CheckboxData() {startX = 86, startY = 409, endX = 102, endY = 423, AveragePixels = 205.29411f } },
                {"Q15Agree", new CheckboxData() {startX = 143, startY = 409, endX = 159, endY = 423, AveragePixels = 205.43137f } },
                {"Q15NoOpinion", new CheckboxData() {startX = 198, startY = 409, endX = 214, endY = 423, AveragePixels = 205.43333f } },
                {"Q15Disagree", new CheckboxData() {startX = 247, startY = 409, endX = 263, endY =  423, AveragePixels = 205.7255f} },
                {"Q15StrongDisagree", new CheckboxData() {startX = 325, startY = 408, endX = 341, endY =  423, AveragePixels = 211.74902f} },
                {"Q16StrongAgree", new CheckboxData() {startX = 86, startY = 455, endX = 102, endY = 469, AveragePixels = 205.84314f } },
                {"Q16Agree", new CheckboxData() {startX = 143, startY = 455, endX = 159, endY = 469, AveragePixels = 206.08824f } },
                {"Q16NoOpinion", new CheckboxData() {startX = 198, startY = 455, endX = 214, endY = 469, AveragePixels = 205.39412f } },
                {"Q16Disagree", new CheckboxData() {startX = 247, startY = 455, endX = 262, endY = 469, AveragePixels = 191.72745f} },
                {"Q16StrongDisagree", new CheckboxData() {startX = 325, startY = 454, endX = 341, endY = 469, AveragePixels = 220.96863f} },
                {"Q17StrongAgree", new CheckboxData() {startX = 86, startY = 509, endX = 101, endY = 523, AveragePixels = 191.74902f } },
                {"Q17Agree", new CheckboxData() {startX = 143, startY = 509, endX = 158, endY = 523, AveragePixels = 192.55882f } },
                {"Q17NoOpinion", new CheckboxData() {startX = 198, startY = 509, endX = 213, endY = 523, AveragePixels = 191.78432f } },
                {"Q17Disagree", new CheckboxData() {startX = 247, startY = 509, endX = 262, endY = 523, AveragePixels = 191.92941f } },
                {"Q17StrongDisagree", new CheckboxData() {startX = 325, startY = 509, endX = 341, endY = 523, AveragePixels = 205.38039f } },
                {"Q19StrongAgree", new CheckboxData() {startX = 85, startY = 632, endX = 101, endY = 646, AveragePixels = 206.56863f } },
                {"Q19Agree", new CheckboxData() {startX = 142, startY = 632, endX = 158, endY = 646, AveragePixels = 206.83138f } },
                {"Q19NoOpinion", new CheckboxData() {startX = 198, startY = 632, endX = 214, endY = 646, AveragePixels = 205.03922f } },
                {"Q19Disagree", new CheckboxData() {startX = 246, startY = 632, endX = 261, endY = 646, AveragePixels = 191.58627f } },
                {"Q19StrongDisagree", new CheckboxData() {startX = 325, startY = 632, endX = 340, endY = 646, AveragePixels = 192.13725f } }
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