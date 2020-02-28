using System;
using IronOcr;
using IronPdf;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections.Generic;
using System.Linq;

//In order to find each checkboxes base un-marked pixel density I created a seperate program which allows me to pass in a survey of any type/layout, 
//and a list of checkbox X, Y locations within the survey; the program then returns each checkboxes un-marked pixel density. This was needed as there are currently 
//over 130 separate checkboxes throughout 4 survey types (8 pages total).

namespace CheckBoxTest
{
    public class Program
    {
        public class CheckboxData
        {
            //checkbox location
            public int startX { get; set; }
            public int startY { get; set; }
            public int endX { get; set; }
            public int endY { get; set; }

            //overall pixel color average for blank checkbox
            public int AveragePixels { get; set; }

            public bool IsChecked { get; set; }
        }

        //stores a dictionary of all secondary school survey checkbox names and their CheckboxData i.e. location,
        //over pixel color for blank checkbox and if marked or not
        public class SecondarySchoolCheckboxes
        {
            private Dictionary<string, CheckboxData> checkboxLocations = new Dictionary<string, CheckboxData>()
            {
                {"Q2Male", new CheckboxData() {startX = 182, startY = 197, endX = 238, endY = 227, } },
                {"Q2Female", new CheckboxData() {startX = 249, startY = 196, endX = 313, endY = 239 } },
                {"Q2Other", new CheckboxData() {startX = 325, startY = 197, endX = 383, endY =  227} },
                {"Q2DontWantToSay", new CheckboxData() {startX = 385, startY = 194, endX = 528, endY =  229} },
                {"Q6Higher", new CheckboxData() {startX = 80, startY = 361, endX = 141, endY =  389} },
                {"Q6Ordinary", new CheckboxData() {startX = 142, startY = 361, endX = 218, endY =  389} },
                {"Q6Other", new CheckboxData() {startX = 217, startY = 361, endX = 277, endY =  390} },
                {"Q7Physics", new CheckboxData() {startX = 78, startY = 408, endX = 144, endY = 438 } },
                {"Q7Biology", new CheckboxData() {startX = 153, startY = 408, endX = 222, endY = 439 } },
                {"Q7Chemistry", new CheckboxData() {startX = 231, startY = 408, endX = 310, endY = 439 } },
                {"Q7Science", new CheckboxData() {startX = 310, startY = 409, endX = 428, endY = 440 } },
                {"Q7None", new CheckboxData() {startX = 432, startY = 409, endX = 489, endY = 438 } },
                {"Q9StrongAgree", new CheckboxData() {startX = 94, startY = 511, endX = 112, endY = 525 } },
                {"Q9Agree", new CheckboxData() {startX = 148, startY = 511, endX = 166, endY = 525 } },
                {"Q9NoOpinion", new CheckboxData() {startX = 201, startY = 511, endX = 218, endY = 525 } },
                {"Q9Disagree", new CheckboxData() {startX = 246, startY = 511, endX = 266, endY = 525 } },
                {"Q9StrongDisagree", new CheckboxData() {startX = 322, startY = 511, endX = 340, endY = 525 } },
                {"Q10StrongAgree", new CheckboxData() {startX = 94, startY = 556, endX = 112, endY = 569 } },
                {"Q10Agree", new CheckboxData() {startX = 148, startY = 556, endX = 166, endY = 569 } },
                {"Q10NoOpinion", new CheckboxData() {startX = 200, startY = 556, endX = 219, endY = 569 } },
                {"Q10Disagree", new CheckboxData() {startX = 247, startY = 556, endX = 266, endY = 569 } },
                {"Q10StrongDisagree", new CheckboxData() {startX = 323, startY = 556, endX = 340, endY = 569 } }

            };

            //will be used as base value to compare against uploaded checkboxes
            //SecondarySchoolCheckboxesP2

            public Dictionary<string, CheckboxData> CheckboxLocations
            {
                get
                {
                    return checkboxLocations;
                }
            }


        }

        static void Main(string[] args)
        {
            //load .pdf file
            var pdf = PdfDocument.FromFile(@"C:\Users\jayjo\source\repos\CheckBoxTest\Surveys.pdf");
            //Extract all pages to a folder as image files
            pdf.RasterizeToImageFiles(@"C:\IronPDFDoc\*.png");
            //Extract all pages as System.Drawing.Bitmap objects
            Bitmap[] pageImages = pdf.ToBitmap();

            //Create Bitmap of survey page to be processed
            Bitmap bm = new Bitmap(@"C:\IronPDFDoc\3.png", true);



            SecondarySchoolCheckboxes b1 = new SecondarySchoolCheckboxes();

            foreach (KeyValuePair<string, CheckboxData> element in b1.CheckboxLocations)
            {

                int startX = element.Value.startX;
                int endX = element.Value.endX;
                int startY = element.Value.startY;
                int endY = element.Value.endY;

                List<float> lResult = new List<float>();

                for (int y = startY; y < endY; y++)
                {
                    for (int x = startX; x < endX; x++)
                    {
                        lResult.Add(bm.GetPixel(x, y).GetBrightness());
                    }
                }

                float numMarked = 0;
                foreach (float b in lResult)
                {

                    numMarked += b;

                }

                Console.WriteLine($"Box Name: {element.Key}\nNum Squares Marked: {numMarked}\n");
                
            }
            string test = Console.ReadLine();
        }

    }
}