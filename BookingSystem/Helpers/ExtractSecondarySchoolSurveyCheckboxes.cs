using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;
using System.Drawing.Imaging;
using IronPdf;

namespace BookingSystem.Helpers
{
    public class ExtractSecondarySchoolSurveyCheckboxes
    {

        var pdf = PdfDocument.FromFile(@"C:\Users\jayjo\source\repos\CheckBoxTest\Surveys.pdf");
        //Extract all pages to a folder as image files
        pdf.RasterizeToImageFiles(@"C:\IronPDFDoc2\*.png");
            //Extract all pages as System.Drawing.Bitmap objects
            Bitmap[] pageImages = pdf.ToBitmap();

    }
}