using IronPdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Web;

namespace BookingSystem.Survey_Extraction
{
    public class CropSurvey
    {
        public static void cropSurveys(string filename, string bitmapFolder)
        {
            //load PDF
            var pdf = PdfDocument.FromFile(filename);
            //Extract all PDF pages to a folder as Bitmap image files
            pdf.RasterizeToImageFiles(bitmapFolder + "*.png");
            //get number of pages in .PDF
            int numberPages = pdf.PageCount;

            for (int i = 1; i <= numberPages; i++)
            {
                Bitmap bm = new Bitmap(bitmapFolder + $"\\{i}.png", true);

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

                croppedSurvey.Save(bitmapFolder + $"\\croppedSurvey{i}.png", ImageFormat.Png);
            }

        }
    }
}