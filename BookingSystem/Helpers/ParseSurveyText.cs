//Craig Whelan X00075734

//parse .txt data logic, which was returned from Azure API   ***

using BookingSystem.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace BookingSystem.Helpers
{
    //scans a data file which contains line by line text from 1-x numbers of surveys. Loops through data line by line
    //using 'constant' page markers to locate and record only the specific 'hand-written' answers to survey questions. 
    //Uses constant markers such as 'Page 1 of 2' and 'Page 2 of 2' to keep track of page and survey number. Every 2x
    //pages a new Survey, along with the new data is entered into db.SecondarySchool Survey database

    public class ParseSurveyText
    {

        //public int StartSurveyID { get; set; }
        //private bool startIDMarked;
        //public int EndSurveyID { get; set; }


        private RDSContext db = new RDSContext();


        //stores server friendly map path for data file
        private static string datafile = HttpContext.Current.Server.MapPath("~/testout2.txt");
        //creates a List of lines of text from data file
        private readonly List<string> lines = File.ReadAllLines(datafile).ToList();

        //start recording markers for loop
        private int recordq1 = 1;
        private int recordq3 = 1;
        private int recordq4 = 1;
        private int recordq5 = 1;
        private int recordq6b = 1;

        private int record = 1;
        private int record2 = 1;
        private int record3 = 1;
        private int record4 = 1;
        private int record5 = 1;
        private int record6 = 1;
        private int record7 = 1;

        //hold asnwers
        private double answer1;
        private string answer3 = string.Empty;
        private string answer4 = string.Empty;
        private string answer5 = string.Empty;
        private string answer6b;

        private string answer8 = string.Empty;
        private string answer11 = string.Empty;
        private string answer12 = string.Empty;
        private string answer13b = string.Empty;
        private string answer14c = string.Empty;
        private string answer18 = string.Empty;
        private string answer20 = string.Empty;

        //hold page numbers
        private int pageNumber = 0;
        //hold survey numbers, 1 survey is 2 pages
        private int surveyNumber = 0;

        //set to true after every surveys final answer is extracted. Allows EnterSurvey() to then be called after each survey
        private bool surveyGate = false;



        //loop through data in text file line by line using 'constant' text as markers 
        //to locate 'variable' text i.e. hand-written text answers to questions.

        //added 2nd set of constant markers to deal with special edge cases where Azure OCR API failed to return a correct constant

    
        public void ParseTextFile(string rollNumber, string officialSchoolName, DateTime? campDate, string filename)
        {
            foreach (string line in lines)
            {

                //if a line contains a constant marker then recording will be triggered for next loop
                //iteration to record answer data 
                // i.e.    2 constant triggers are used to record the data in between


                //search for answer to question 1
                if (line.Contains("before the camp."))
                {
                    //trigger recording variable to start recording
                    recordq1 = 2;
                    continue;
                }
                if (recordq1 == 2)
                {
                    //constant marker to stop recording
                    if (line.Contains("select your gender."))
                    {
                        recordq1 = 1;
                        continue;
                    }
                    //else record the answer data
                    else
                    {
                        //record answer 1
                        //extract age from line, convert to double and add 10 
                        string ageText = line.Substring(line.Length - 1);
                        double age;
                        double.TryParse(ageText, out age);

                        //NOSONAR
                        answer1 = age += 10;
                    }
                }


                //search for answer to question 3
                if (line.Contains("games per day"))
                {
                    //trigger recording variable to start recording
                    recordq3 = 2;
                    continue;
                }
                if (recordq3 == 2)
                {
                    //constant marker to stop recording
                    //added 2nd constant to allow for special edge cases (sometimes Azure API did not return 9 at all)
                    if (line.Contains("spend on social") || line.StartsWith("4."))
                    {
                        recordq3 = 1;

                        //set record question 4 to true because next iteration is answer 4
                        recordq4 = 2;
                        continue;
                    }
                    //else record the answer data
                    else
                    {
                        //record answer 3
                        answer3 = line;
                        continue;
                    }
                }


                //search for answer to question 4
                if (recordq4 == 2)
                {
                    //constant marker to stop recording
                    //added 2nd constant to allow for special edge cases (sometimes Azure API did not return 9 at all)
                    if (line.Contains("do you work at") || line.StartsWith("5."))
                    {
                        recordq4 = 1;

                        //set record question 5 to true because next iteration is answer 5
                        recordq5 = 2;
                        continue;
                    }
                    //else record the answer data
                    else
                    {
                        //record answer 4
                        answer4 = line;
                        continue;
                    }
                }

                //search for answer to question 5
                if (recordq5 == 2)
                {
                    //constant marker to stop recording
                    //added 2nd constant to allow for special edge cases (sometimes Azure API did not return 9 at all)
                    if (line.Contains("you currently studying") || line.StartsWith("6"))
                    {
                        recordq5 = 1;
                        continue;
                    }
                    //else record the answer data
                    else
                    {
                        //record answer 5
                        answer5 = line;
                        continue;
                    }
                }


                //search for answer to question 6b
                if (line.Contains("Most recent"))
                {
                    //trigger recording variable to start recording
                    recordq6b = 2;
                    continue;
                }
                if (recordq6b == 2)
                {
                    //constant marker to stop recording
                    //added 2nd constant to allow for special edge cases (sometimes Azure API did not return 9 at all)
                    if (line.Contains("What science") || line.StartsWith("7."))
                    {
                        recordq6b = 1;
                        continue;
                    }
                    //else record the answer data
                    else
                    {
                        answer6b += " " + line;
                    }
                }


                //search for answer to question 8
                if (line.Contains("know of?"))
                {
                    //trigger recording variable to start recording
                    record = 2;
                    continue;
                }
                if (record == 2)
                {
                    //constant marker to stop recording
                    //added 2nd constant to allow for special edge cases (sometimes Azure API did not return 9 at all)
                    if (line.Contains("consider a career") || line.StartsWith("9"))
                    {
                        record = 1;
                        continue;
                    }
                    //else record the answer data
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

                        //also set recording for next answer because next answer is on next line
                        record3 = 2;
                        continue;
                    }
                    else
                    {
                        answer11 += " " + line;
                    }
                }

                //search for answer to question 12, record3 is already set to 2 as foreach loop is already on line
                if (record3 == 2)
                {
                    if (line.StartsWith("Page"))
                    {
                        //Next answer will be on page 2
                        pageNumber++;

                        record3 = 1;
                        continue;
                    }
                    else
                    {
                        answer12 += " " + line;
                    }
                }

                //Page 2 of 2

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
                        //New page and new survey
                        pageNumber++;
                        surveyNumber++;

                        //open survey gate to allow EnterSurvey() call (enter a survey into db)
                        surveyGate = true;

                        record7 = 1;
                        continue;
                    }
                    else
                    {
                        answer20 += " " + line;
                    }
                }


                // Called every 2x pages when final survey answer has been collected
                if (surveyNumber != 0 && surveyGate == true)
                {
                    EnterSurvey(rollNumber, officialSchoolName, campDate);

                    //close survey gate for next round of answer extraction
                    surveyGate = false;

                    //reset answers for next survey
                    answer8 = string.Empty;
                    answer11 = string.Empty;
                    answer12 = string.Empty;
                    answer13b = string.Empty;
                    answer14c = string.Empty;
                    answer18 = string.Empty;
                    answer20 = string.Empty;
                    answer1 = 0;
                    answer3 = string.Empty;
                    answer4 = string.Empty;
                    answer5 = string.Empty;
                    answer6b = string.Empty;

                    //String lastSurvey = lines.Last();
                    //while (line.Equals(lastSurvey))
                    //{
                    //    EndSurveyID = +surveyNumber;
                    //}

                }

                
            }

           // ExtractSecondarySchoolSurveyCheckboxes extract1 = new ExtractSecondarySchoolSurveyCheckboxes();
           // extract1.ExtractCheckboxData(StartSurveyID, EndSurveyID, filename);
        }


        //Enters new Survey with its data into db.SecondarySchool Survey database
        //attach roll numnber, school name and camp data to survey
        public void EnterSurvey(string rollNumber, string officialSchoolName, DateTime? campDate)
        {
            SecondarySchoolSurvey s1 = new SecondarySchoolSurvey();
            s1.RollNumber = rollNumber;
            s1.OfficialSchoolName = officialSchoolName;
            s1.CampDate = campDate;
            s1.SurveyFileName = null;
            s1.FilePage = pageNumber;

            s1.Q8 = answer8;
            s1.Q11 = answer11;
            s1.Q12 = answer12;
            s1.Q13b = answer13b;
            s1.Q14c = answer14c;
            s1.Q18 = answer18;
            s1.Q20 = answer20;
            s1.Q1 = answer1;
            s1.Q3 = answer3;
            s1.Q4 = answer4;
            s1.Q5 = answer5;
            s1.Q6b = answer6b;
            
         


            db.SecondarySchoolSurveys.Add(s1);
            db.SaveChanges();

             
            //while(startIDMarked == false)
            //{
            //    StartSurveyID = s1.Id;
            //    startIDMarked = true;
            //}
        }
    }
}
