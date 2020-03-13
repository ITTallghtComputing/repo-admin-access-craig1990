using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using IronPdf;
using IronOcr;
using System.IO;

namespace BookingSystem.Helpers
{
    public class ExtractSecondarySchoolSurveyCheckboxes
    {
        //private string bitmapFolder = HttpContext.Current.Server.MapPath(@"~\IronPDFDoc\");
        private string bitmapFolder = Path.Combine(HttpRuntime.AppDomainAppPath, "IronPDFDoc\\");


        public void ExtractCheckboxData(int startID, int endID, string filename)
        {
            int surveyIDCounter = startID;
            //load PDF
            var pdf = PdfDocument.FromFile(filename);
            //Extract all PDF pages to a folder as Bitmap image files
            pdf.RasterizeToImageFiles(bitmapFolder + "*.png");


            //Extract all pages as System.Drawing.Bitmap objects        
            //Bitmap[] pageImages = pdf.ToBitmap();
            //int numberPages = pageImages.Count();

            int numberPages = pdf.PageCount; 
            int numberSurveys = numberPages / 2;



            SurveyCheckboxCollections checkboxData = new SurveyCheckboxCollections();
            SurveyCheckboxCollections checkboxDataP2 = new SurveyCheckboxCollections();

            for (int i = 1; i <= numberPages; i++) //8 pages
            {
                //Bitmap bm = new Bitmap(bitmapFolder + $"\\{i}.png", true);
                //Loop through Page 1 checkbox dictionary
                if (i % 2 != 0)
                {
                    //create Bitmap with 1st page of Survey
                    Bitmap bm = new Bitmap(bitmapFolder + $"\\{i}.png", true);
                    //loops through each checkbox in checkbox dictionary and compares
                    foreach (KeyValuePair<string, CheckboxData> element in checkboxData.SecondarySchoolCheckboxes)
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

                        //pixel density tolerance used to determine if checkbox is marked or not
                        float densityTolerance = 3.5f;

                        //sums together all pixels brightness in lResult List to provide overall checkbox pixel density
                        float checkboxDensity = lResult.Sum();
                        //blank, un-marked pixel density of checkbox to measure against checkboxDensity above 
                        float blankCheckboxDensity = element.Value.AveragePixels;


                        //measures blank pixel density against passed in checkbox pixel density against a tolerance to determine if marked or not
                        if ((blankCheckboxDensity - checkboxDensity) >= densityTolerance)
                        {
                            element.Value.IsChecked = true;
                        }
                        else
                        {
                            element.Value.IsChecked = false;
                        }

                    }

                }

                //every 2nd iteration loop through Page 2 of checkbox dictionary and then update a survey with checkbox data
                else if (i % 2 == 0)
                {
                    //int bitmapSecondPage = i+1;
                    //create Bitmap with 2nd page of Survey
                    Bitmap bm = new Bitmap(bitmapFolder + $"\\{i}.png", true);
                    //loops through each checkbox in checkbox dictionary and compares
                    foreach (KeyValuePair<string, CheckboxData> element in checkboxDataP2.SecondarySchoolCheckboxes)
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

                        //pixel density tolerance used to determine if checkbox is marked or not
                        float densityTolerance = 3.5f;

                        //sums together all pixels brightness in lResult List to provide overall checkbox pixel density
                        float checkboxDensity = lResult.Sum();
                        //blank, un-marked pixel density of checkbox to measure against checkboxDensity above 
                        float blankCheckboxDensity = element.Value.AveragePixels;

                        //measures blank pixel density against passed in checkbox pixel density against a tolerance to determine if marked or not
                        if ((blankCheckboxDensity - checkboxDensity) >= densityTolerance)
                        {
                            element.Value.IsChecked = true;
                        }
                        else
                        {
                            element.Value.IsChecked = false;
                        }

                    }


                    //update a survey with checkbox data
                    SubmitSecondarySchoolSurveyCheckboxes submitCheckboxes = new SubmitSecondarySchoolSurveyCheckboxes();
                    submitCheckboxes.UpdateSurvey(checkboxData, checkboxDataP2, surveyIDCounter);

                    surveyIDCounter++;

                    //reset checkbox collections
                    checkboxData = new SurveyCheckboxCollections();
                    checkboxDataP2 = new SurveyCheckboxCollections();

                }

            }

        }

        

    }
}