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
            public float AveragePixels { get; set; }

            public bool IsChecked { get; set; }
        }

        //stores a dictionary of all secondary school survey checkbox names and their CheckboxData i.e. location,
        //over pixel color for blank checkbox and if marked or not
        public class SecondarySchoolCheckboxes
        {
            private Dictionary<string, CheckboxData> checkboxLocations = new Dictionary<string, CheckboxData>()
            {
                //PAGE 1 CHECKBOX LOCATIONS
              {"Q2Male", new CheckboxData() { startX = 134, startY = 107, endX = 193, endY = 139} },
              {"Q2Female", new CheckboxData() { startX = 203, startY = 107, endX = 271, endY = 138} },
              {"Q2Other", new CheckboxData() { startX = 282, startY = 107, endX = 345, endY = 138} },
              {"Q2DontWantToSay", new CheckboxData() { startX = 348, startY = 107, endX = 490, endY = 138} },
              {"Q6Higher", new CheckboxData() { startX = 26, startY = 278, endX = 91, endY = 308} },
              {"Q6Ordinary", new CheckboxData() { startX = 93, startY = 279, endX = 171, endY = 308} },
              {"Q6Other", new CheckboxData() { startX = 173, startY = 278, endX = 233, endY = 307} },
              {"Q7Physics", new CheckboxData() { startX = 26, startY = 328, endX = 92, endY = 358} },
              {"Q7Biology", new CheckboxData() { startX = 103, startY = 328, endX = 174, endY = 358} },
              {"Q7Chemistry", new CheckboxData() { startX = 187, startY = 326, endX = 269, endY = 358} },
              {"Q7Science", new CheckboxData() { startX = 282, startY = 326, endX = 353, endY = 358} },
              {"Q7None", new CheckboxData() { startX = 354, startY = 326, endX = 419, endY = 358} },
              {"Q9StrongAgree", new CheckboxData() { startX = 45, startY = 434, endX = 60, endY = 448} },
              {"Q9Agree", new CheckboxData() { startX = 101, startY = 434, endX = 118, endY = 448} },
              {"Q9NoOpinion", new CheckboxData() { startX = 156, startY = 434, endX = 172, endY = 448} },
              {"Q9Disagree", new CheckboxData() { startX = 205, startY = 434, endX = 219, endY = 448} },
              {"Q9StrongDisagree", new CheckboxData() { startX = 283, startY = 432, endX = 299, endY = 448} },
              {"Q10StrongAgree", new CheckboxData() { startX = 45, startY = 481, endX = 61, endY = 495} },
              {"Q10Agree", new CheckboxData() { startX = 102, startY = 481, endX = 118, endY = 495} },
              {"Q10NoOpinion", new CheckboxData() { startX = 157, startY = 480, endX = 172, endY = 495} },
              {"Q10Disagree", new CheckboxData() { startX = 205, startY = 480, endX = 220, endY = 495 } },
              {"Q10StrongDisagree", new CheckboxData() { startX = 284, startY = 480, endX = 299, endY = 495} }

                // PAGE 2 CHECKBOXE LOCATIONS
                //{"Q13Yes", new CheckboxData() {startX = 271, startY = 23, endX = 319, endY = 55 } },
                //{"Q13No", new CheckboxData() {startX = 328, startY = 23, endX = 377, endY = 55 } },
                //{"Q14CoderDojo", new CheckboxData() {startX = 29, startY = 111, endX = 114, endY =  140} },
                //{"Q14InSchool", new CheckboxData() {startX = 125, startY = 111, endX = 203, endY =  140} },
                //{"Q14Camp", new CheckboxData() {startX = 205, startY = 111, endX = 261, endY =  140} },
                //{"Q14SelfTaught", new CheckboxData() {startX = 269, startY = 111, endX = 358, endY =  140} },
                //{"Q14Other", new CheckboxData() {startX = 362, startY = 111, endX = 421, endY =  141} },
                //{"Q14bGood", new CheckboxData() {startX = 108, startY = 163, endX = 166, endY = 194 } },
                //{"Q14bNeither", new CheckboxData() {startX = 179, startY = 164, endX = 312, endY = 194 } },
                //{"Q14Bad", new CheckboxData() {startX = 321, startY = 164, endX = 377, endY = 195 } },
                //{"Q15StrongAgree", new CheckboxData() {startX = 43, startY = 319, endX = 57, endY = 333 } },
                //{"Q15Agree", new CheckboxData() {startX = 99, startY = 319, endX = 115, endY = 333 } },
                //{"Q15NoOpinion", new CheckboxData() {startX = 155, startY = 319, endX = 169, endY = 333 } },
                //{"Q15Disagree", new CheckboxData() {startX = 204, startY = 319, endX = 218, endY =  333} },
                //{"Q15StrongDisagree", new CheckboxData() {startX = 282, startY = 319, endX = 296, endY =  333} },
                //{"Q16StrongAgree", new CheckboxData() {startX = 43, startY = 365, endX = 57, endY = 379 } },
                //{"Q16Agree", new CheckboxData() {startX = 99, startY = 365, endX = 115, endY = 379 } },
                //{"Q16NoOpinion", new CheckboxData() {startX = 155, startY = 365, endX = 169, endY = 379 } },
                //{"Q16Disagree", new CheckboxData() {startX = 204, startY = 365, endX = 218, endY = 379 } },
                //{"Q16StrongDisagree", new CheckboxData() {startX = 282, startY = 365, endX = 296, endY = 379 } },
                //{"Q17StrongAgree", new CheckboxData() {startX = 43, startY = 419, endX = 57, endY = 433 } },
                //{"Q17Agree", new CheckboxData() {startX = 100, startY = 419, endX = 114, endY = 433 } },
                //{"Q17NoOpinion", new CheckboxData() {startX = 155, startY = 419, endX = 169, endY = 433 } },
                //{"Q17Disagree", new CheckboxData() {startX = 204, startY = 419, endX = 218, endY = 433 } },
                //{"Q17StrongDisagree", new CheckboxData() {startX = 282, startY = 419, endX = 296, endY = 433 } },
                //{"Q19StrongAgree", new CheckboxData() {startX = 42, startY = 542, endX = 57, endY = 556 } },
                //{"Q19Agree", new CheckboxData() {startX = 99, startY = 542, endX = 114, endY = 556 } },
                //{"Q19NoOpinion", new CheckboxData() {startX = 154, startY = 542, endX = 170, endY = 556 } },
                //{"Q19Disagree", new CheckboxData() {startX = 202, startY = 542, endX = 217, endY = 556 } },
                //{"Q19StrongDisagree", new CheckboxData() {startX = 281, startY = 542, endX = 296, endY = 556 } }

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
            //load BLANK .pdf Survey file
            var pdf = PdfDocument.FromFile(@"C:\Users\jayjo\repo-admin-access-craig1990\CheckboxPixelDensity\1BlankSurvey.pdf");
            //Extract all pages to a folder as image files
            pdf.RasterizeToImageFiles(@"C:\Users\jayjo\repo-admin-access-craig1990\CheckboxPixelDensity\SurveyBitmaps\*.png");
            //Extract all pages as System.Drawing.Bitmap objects
            Bitmap[] pageImages = pdf.ToBitmap();


            //Create Bitmap of a survey page to be processed - 1.png for page 1 and 2.png for page 2
            using (var bm = new Bitmap(@"C:\Users\jayjo\repo-admin-access-craig1990\CheckboxPixelDensity\SurveyBitmaps\1.png", true))
            {

                //Start crop location
                int cropX = 0;
                int cropY = 0;
                bool cropFlag = false;

                //Find start crop location
                for (int y = 0; y < 120; y++)
                {
                    for (int x = 0; x < 62; x++)
                    {
                        float pixelBrightness = bm.GetPixel(x, y).GetBrightness();
                        if (pixelBrightness < 0.8 && cropFlag == false)
                        {
                            cropFlag = true;
                            cropX = x;
                            cropY = y;
                        }
                    }
                }

                //Use start crop location to crop Survey page
                Rectangle crop = new Rectangle(cropX, cropY, 495, 665);
                Bitmap croppedSurvey = new Bitmap(crop.Width, crop.Height);

                using (Graphics g = Graphics.FromImage(croppedSurvey))
                {
                    g.DrawImage(bm, new Rectangle(0, 0, croppedSurvey.Width, croppedSurvey.Height),
                                     crop,
                                     GraphicsUnit.Pixel);
                }

                croppedSurvey.Save(@"C:\Users\jayjo\repo-admin-access-craig1990\CheckboxPixelDensity\SurveyBitmaps\croppedSurvey.png", ImageFormat.Png);




                SecondarySchoolCheckboxes b1 = new SecondarySchoolCheckboxes();
                //loop over checkbox XY locations in the cropped survey page. Measure each checkbox pixel by pixel to find
                //each checkboxes un-marked pixel density.
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
                            lResult.Add(croppedSurvey.GetPixel(x, y).GetBrightness());

                            //color in scanned pixels
                            croppedSurvey.SetPixel(x, y, Color.BlueViolet);
                        }
                    }
                    croppedSurvey.Save(@"C:\Users\jayjo\repo-admin-access-craig1990\CheckboxPixelDensity\SurveyBitmaps\croppedSurveyMARKED.png", ImageFormat.Png);


                    float numMarked = 0;
                    foreach (float b in lResult)
                    {

                        numMarked += b;

                    }

                    Console.WriteLine($"Box Name: {element.Key}\nBlank Pixel Density: {numMarked}\n");

                }

                string wait = Console.ReadLine();
            }
        }

    }
}