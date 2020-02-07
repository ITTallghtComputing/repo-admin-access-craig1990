using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using IronPdf;
using IronOcr;

namespace BookingSystem.Helpers
{
    public class ExtractSecondarySchoolSurveyCheckboxes
    {
        private string bitmapFolder = HttpContext.Current.Server.MapPath(@"~\IronPDFDoc\*.png");

        public void ExtractCheckboxData(int startID, int endID, string filename)
        {
            int surveyIDCounter = startID;
            //load PDF
            var pdf = PdfDocument.FromFile(filename);
            //Extract all PDF pages to a folder as Bitmap image files
            pdf.RasterizeToImageFiles(bitmapFolder);
            //Extract all pages as System.Drawing.Bitmap objects
            
            //Bitmap[] pageImages = pdf.ToBitmap();
            //int numberPages = pageImages.Count();

            int numberPages = pdf.PageCount;
            int numberSurveys = numberPages / 2;



            SurveyCheckboxCollections checkboxData = new SurveyCheckboxCollections();
            SurveyCheckboxCollections checkboxDataP2 = new SurveyCheckboxCollections();

            for (int i = 0; i < numberPages; i++)
            {

                Bitmap bm = new Bitmap($"~/IronPDFDoc2/{i++}.png", true);
                BitmapData srcData = bm.LockBits(
                new Rectangle(0, 0, bm.Width, bm.Height),
                ImageLockMode.ReadOnly,
                PixelFormat.Format32bppArgb);

                int stride = srcData.Stride;
                IntPtr Scan0 = srcData.Scan0;

                

                //every 2nd iteration loop through Page 2 of checkbox dictionary and then update a survey with checkbox data
                if (i % 2 == 0)
                {

                    //loops through each checkbox in checkbox dictionary and compares
                    foreach (KeyValuePair<string, CheckboxData> element in checkboxDataP2.SecondarySchoolCheckboxes)
                    {
                        int[] totals = new int[] { 0, 0, 0 };

                        int startX = element.Value.startX;
                        int endX = element.Value.endX;
                        int startY = element.Value.startY;
                        int endY = element.Value.endY;
                        int width = endX - startX;
                        int height = endY - startY;

                        unsafe
                        {
                            byte* p = (byte*)(void*)Scan0;

                            for (int y = startY; y < endY; y++)
                            {
                                for (int x = startX; x < endX; x++)
                                {
                                    for (int color = 0; color < 3; color++)
                                    {
                                        int idx = (y * stride) + x * 4 + color;

                                        totals[color] += p[idx];
                                    }
                                }
                            }
                        }


                        //gets average colour to take into account different colour pens/marks
                        //i.e. red, blue, black, green pens used for marking survey forms
                        int avgB = totals[0] / (width * height);
                        int avgG = totals[1] / (width * height);
                        int avgR = totals[2] / (width * height);

                        //get average overall pixel density to measure against constant to determine if marked or not
                        int avgTotal = (avgB + avgG + avgR) / 3;

                        //
                        int blankaverageC = element.Value.AveragePixels;


                        if ((blankaverageC - avgTotal) >= 1)
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

                    //reset checkbox collections
                    checkboxData = new SurveyCheckboxCollections();
                    checkboxDataP2 = new SurveyCheckboxCollections();


                }
                //Loop through Page 1 checkbox dictionary
                else
                {
                    

                    //loops through each checkbox in checkbox dictionary and compares
                    foreach (KeyValuePair<string, CheckboxData> element in checkboxData.SecondarySchoolCheckboxes)
                    {
                        int[] totals = new int[] { 0, 0, 0 };

                        int startX = element.Value.startX;
                        int endX = element.Value.endX;
                        int startY = element.Value.startY;
                        int endY = element.Value.endY;
                        int width = endX - startX;
                        int height = endY - startY;

                        unsafe
                        {
                            byte* p = (byte*)(void*)Scan0;

                            for (int y = startY; y < endY; y++)
                            {
                                for (int x = startX; x < endX; x++)
                                {
                                    for (int color = 0; color < 3; color++)
                                    {
                                        int idx = (y * stride) + x * 4 + color;

                                        totals[color] += p[idx];
                                    }
                                }
                            }
                        }


                        //gets average colour to take into account different colour pens/marks
                        //i.e. red, blue, black, green pens used for marking survey forms
                        int avgB = totals[0] / (width * height);
                        int avgG = totals[1] / (width * height);
                        int avgR = totals[2] / (width * height);

                        //get average overall pixel density to measure against constant to determine if marked or not
                        int avgTotal = (avgB + avgG + avgR) / 3;

                        //
                        int blankaverageC = element.Value.AveragePixels;


                        if ((blankaverageC - avgTotal) >= 1)
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

   

        }

        

    }
}