using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

//CheckboxData holds needed checkbox information such as checkbox (x,y) boxed coordinates, an un-marked pixel density value and IsChecked bool

namespace BookingSystem.Helpers
{
    public class CheckboxData
    {
        //checkbox location
        public int startX { get; set; }
        public int startY { get; set; }
        public int endX { get; set; }
        public int endY { get; set; }

        //average un-marked pixel density value for checkbox
        public int AveragePixels { get; set; }

        public bool IsChecked { get; set; }
    }
}