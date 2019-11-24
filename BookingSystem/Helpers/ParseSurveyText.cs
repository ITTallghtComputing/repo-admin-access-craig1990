using BookingSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BookingSystem.Helpers
{
    public class ParseSurveyText
    {
        private RDSContext db = new RDSContext();
        private static string datafile = HttpContext.Current.Server.MapPath("~/surveytest.txt");


        List<string> lines = File.ReadAllLines(datafile).ToList();

        string answer1 = string.Empty;

        //start recording 
        public int record = 1;
        public int record2 = 1;
        public int record3 = 1;
        public int record4 = 1;
        public int record5 = 1;
        public int record6 = 1;
        public int record7 = 1;

        //hold asnwers
        public string answer8 = string.Empty;
        public string answer11 = string.Empty;
        public string answer12 = string.Empty;
        public string answer13b = string.Empty;
        public string answer14c = string.Empty;
        public string answer18 = string.Empty;
        public string answer20 = string.Empty;

        public int pageNumber = 0;
        public int surveyNumber = 0;


       

        public void ParseTextFile()
        {
            foreach (string line in lines)
            {
                //search for answer to question 8
                if (line.Contains("know of?"))
                {
                    record = 2;
                    continue;
                }
                if (record == 2)
                {
                    if (line.StartsWith("9"))
                    {
                        record = 1;
                        continue;
                    }
                    else
                    {
                        answer8 += " " + line;
                    }
                }

                //search for answer to question 11
                if (line.Contains("programming?"))
                {
                    record2 = 2;
                    continue;
                }
                if (record2 == 2)
                {
                    if (line.StartsWith("12"))
                    {
                        record2 = 1;
                        record3 = 2;
                        continue;
                    }
                    else
                    {
                        answer11 += " " + line;
                    }
                }

                //search for answer to question 12, record3 is already set to 2 as foreach is already on line
                if (record3 == 2)
                {
                    if (line.StartsWith("Page"))
                    {
                        record3 = 1;
                        pageNumber++;
                        continue;
                    }
                    else
                    {
                        answer12 += " " + line;
                    }
                }

                //search for answer to question 13b
                if (line.Contains("sister etc."))
                {
                    record4 = 2;
                    continue;
                }
                if (record4 == 2)
                {
                    if (line.StartsWith("14"))
                    {
                        record4 = 1;
                        continue;
                    }
                    else
                    {
                        answer13b += " " + line;
                    }
                }

                //search for answer to question 14c
                if (line.Contains("4 words"))
                {
                    record5 = 2;
                    continue;
                }
                if (record5 == 2)
                {
                    if (line.StartsWith("To be"))
                    {
                        record5 = 1;
                        continue;
                    }
                    else
                    {
                        answer14c += " " + line;
                    }
                }

                //search for answer to question 18
                if (line.Contains("the camp?"))
                {
                    record6 = 2;
                    continue;
                }
                if (record6 == 2)
                {
                    if (line.StartsWith("5"))
                    {
                        record6 = 1;
                        continue;
                    }
                    else
                    {
                        answer18 += " " + line;
                    }
                }

                //search for answer to question 20
                if (line.Contains("comments about"))
                {
                    record7 = 2;
                    continue;
                }
                if (record7 == 2)
                {
                    if (line.StartsWith("Thank you"))
                    {
                        record7 = 1;
                        pageNumber++;
                        surveyNumber++;
                        continue;
                    }
                    else
                    {
                        answer20 += " " + line;
                    }
                }

                if (new int[] { 2, 4, 6, 8, 10 }.Contains(pageNumber))
                {
                    EnterSurvey();
                }
               
            }
        }

        public void EnterSurvey()
        {
            SecondarySchool s1 = new SecondarySchool();
            s1.RollNumber = null;
            s1.CampDate = null;
            s1.SurveyFileName = null;
            s1.FilePage = pageNumber;
            s1.Q8 = answer8;
            s1.Q11 = answer11;
            s1.Q12 = answer12;
            s1.Q13b = answer13b;
            s1.Q14c = answer14c;
            s1.Q18 = answer18;
            s1.Q20 = answer20;

            db.SecondarySchools.Add(s1);
            db.SaveChanges();
        }
    }
}
