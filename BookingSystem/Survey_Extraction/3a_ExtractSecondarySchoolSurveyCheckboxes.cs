﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using IronPdf;
using IronOcr;
using System.IO;

namespace BookingSystem.Survey_Extraction
{
    public class ExtractSecondarySchoolSurveyCheckboxes
    {
        //private string bitmapFolder = HttpContext.Current.Server.MapPath(@"~\IronPDFDoc\");
        private string bitmapFolder = Path.Combine(HttpRuntime.AppDomainAppPath, "IronPDFDoc\\");


        public void ExtractCheckboxData(int startID, int endID, string filename)
        {
            //load PDF
            var pdf = PdfDocument.FromFile(filename);
            //Extract all PDF pages to a folder as Bitmap image files
            pdf.RasterizeToImageFiles(bitmapFolder + "*.png");

            //used to keep track of surveys IDs for Stamping and to updateSurvey() with checkbox data
            int surveyIDCounter = startID;
            //current page for stamping purposes
            int currentPage = 1;
            //get number of pages in .PDF
            int numberPages = pdf.PageCount; 
            //get number of Surveys in .PDF
            int numberSurveys = numberPages / 2;
    
         

            SurveyCheckboxCollections checkboxData = new SurveyCheckboxCollections();

            for (int i = 1; i <= numberPages; i++) //8 pages
            {
                //Loop through Page 1 checkbox dictionary
                if (i % 2 != 0)
                {
                    //create Bitmap with 1st page of Survey
                    Bitmap bm = new Bitmap(bitmapFolder + $"\\{i}.png", true);
                    //loops through each page 1 checkbox in page1 checkbox dictionary and compares
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

                        //pixel density tolerance used to determine if checkbox is marked or not                ***
                        float densityTolerance = 2.0f;

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

                //every 2nd iteration loop through Page 2 checkbox dictionary and then update matching survey with checkbox data
                else if (i % 2 == 0)
                {
                    //STAMPS the survey ID on uploaded PDF file for validation comparisons 
                    var ForegroundStamp = new HtmlStamp() { Html = $"<h2 style='color:red'>{surveyIDCounter}", Width = 50, Height = 50, Opacity = 50, Rotation = -45, ZIndex = HtmlStamp.StampLayer.OnTopOfExistingPDFContent };

                    //create Bitmap with 2nd page of Survey
                    Bitmap bm = new Bitmap(bitmapFolder + $"\\{i}.png", true);
                    //loops through each checkbox in checkbox dictionary and compares
                    foreach (KeyValuePair<string, CheckboxData> element in checkboxData.SecondarySchoolCheckboxesP2)
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

                        //pixel density tolerance used to determine if checkbox is marked or not              ***
                        float densityTolerance = 2.0f;

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
                    submitCheckboxes.UpdateSurvey(checkboxData, surveyIDCounter);
                    surveyIDCounter++;

                    //reset checkbox collections
                    checkboxData = new SurveyCheckboxCollections();


                    //STAMP page with survey ID
                    pdf.StampHTML(ForegroundStamp, currentPage);
                    currentPage+=2;

                }
                pdf.SaveAs(filename);
                
            }

        }

        

    }
}