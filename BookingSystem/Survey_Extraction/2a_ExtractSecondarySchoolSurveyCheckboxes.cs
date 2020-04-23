using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using IronPdf;
using IronOcr;
using System.IO;
using System.Threading.Tasks;

namespace BookingSystem.Survey_Extraction
{
    public class ExtractSecondarySchoolSurveyCheckboxes
    {
        //private string bitmapFolder = HttpContext.Current.Server.MapPath(@"~\IronPDFDoc\");
        private string bitmapFolder = Path.Combine(HttpRuntime.AppDomainAppPath, "IronPDFDoc\\");

        public void ExtractCheckboxData(int startID, int endID, string filename)
        {
            //crop all PDF surveys to remove any checkbox XY location inaccuracies from scanning in the surveys
            //It is important that all checkboxes in survey uploads are at the same XY page locations for accurate
            //pixel density scanning comparisons. 
            CropSurvey.cropSurveys(filename, bitmapFolder);

            //load PDF
            var pdf = PdfDocument.FromFile(filename);
            //used to keep track of surveys IDs for Stamping and to updateSurvey() with checkbox data
            int surveyIDCounter = startID;
            //current page for stamping purposes
            int currentPage = 0;
            //get number of pages in .PDF
            int numberPages = pdf.PageCount;


            SurveyCheckboxCollections checkboxData = new SurveyCheckboxCollections();

            //loop through cropped Bitmap pages, while scanning over checkbox locations to get each checkboxes pixel density
            for (int i = 1; i <= numberPages; i++)
            {
                //Loop through Page 1 checkbox dictionary
                if (i % 2 != 0)
                {
                    //STAMPS the survey ID on uploaded PDF file for validation comparisons 
                    var ForegroundStamp = new HtmlStamp() { Html = $"<h2 style='color:red'>Survey ID: {surveyIDCounter}", Width = 70, Height = 70, Opacity = 100, Top = 5, ZIndex = HtmlStamp.StampLayer.OnTopOfExistingPDFContent };
                    pdf.StampHTML(ForegroundStamp, currentPage);
                    currentPage++;
                    //create Bitmap with 1st page of Survey
                    using (var bm = new Bitmap(bitmapFolder + $"\\croppedSurvey{i}.png", true))
                    {

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
                            float blankCheckboxDensity = element.Value.UnmarkedPixelDensity;


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
                }

                //every 2nd iteration loop through Page 2 checkbox dictionary and then update matching survey with checkbox data
                else if (i % 2 == 0)
                {
                    //STAMPS the survey ID on uploaded PDF file for validation comparisons 
                    var ForegroundStamp = new HtmlStamp() { Html = $"<h2 style='color:red'>Survey ID: {surveyIDCounter}", Width = 70, Height = 70, Opacity = 100, Top = 5, ZIndex = HtmlStamp.StampLayer.OnTopOfExistingPDFContent };
                    //STAMP page with survey ID
                    pdf.StampHTML(ForegroundStamp, currentPage);
                    currentPage++;

                    //create Bitmap with 2nd page of Survey
                    using (var bm = new Bitmap(bitmapFolder + $"\\croppedSurvey{i}.png", true))
                    {

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
                                    //bm.SetPixel(x, y, Color.Blue);
                                }
                            }
                            //bm.Save(bitmapFolder + $"\\markedSurvey{i}.png", ImageFormat.Png);

                            //pixel density tolerance used to determine if checkbox is marked or not              ***
                            float densityTolerance = 2.0f;

                            //sums together all pixels brightness in lResult List to provide overall checkbox pixel density
                            float checkboxDensity = lResult.Sum();
                            //blank, un-marked pixel density of checkbox to measure against checkboxDensity above 
                            float blankCheckboxDensity = element.Value.UnmarkedPixelDensity;

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
                    }

                }


                //Save PDF with new Survey ID stamps
                pdf.SaveAs(filename);

            }


        }

    }
}