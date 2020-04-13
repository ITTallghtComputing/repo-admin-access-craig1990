using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookingSystem.Controllers
{
    public class CSO_CSVUploadController : Controller
    {
            private static string connStr = ConfigurationManager.ConnectionStrings["RDSContext"].ConnectionString;
            SqlConnection con = new SqlConnection(connStr);

            OleDbConnection Econ;

            public ActionResult Upload()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Upload(HttpPostedFileBase file)
            {
                string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string filepath = "/CSVuploads/" + filename;
                file.SaveAs(Path.Combine(Server.MapPath("/CSVuploads"), filename));
                InsertExceldata(filepath, filename);
                return View();
            }

            [HttpPost]
            public ActionResult Upload2(HttpPostedFileBase file)
            {
                string filename = Guid.NewGuid() + Path.GetExtension(file.FileName);
                string filepath = "/CSVuploads/" + filename;
                file.SaveAs(Path.Combine(Server.MapPath("/CSVuploads"), filename));
                InsertExceldata2(filepath, filename);
                return RedirectToAction("Upload");
            }

            private void ExcelConn(string filepath)
            {
                string constr = string.Format(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=""Excel 12.0 Xml;HDR=YES;""", filepath);
                Econ = new OleDbConnection(constr);
            }

            private void InsertExceldata(string filepath, string filename)
            {
                string fullpath = Server.MapPath("/CSVuploads/") + filename;
                ExcelConn(fullpath);
                string query = string.Format("Select * from [{0}]", "Sheet1$");
                OleDbCommand Ecom = new OleDbCommand(query, Econ);
                Econ.Open();

                DataSet ds = new DataSet();
                OleDbDataAdapter oda = new OleDbDataAdapter(query, Econ);
                Econ.Close();
                oda.Fill(ds);

                DataTable dt = ds.Tables[0];

                SqlBulkCopy objbulk = new SqlBulkCopy(con);
                objbulk.DestinationTableName = "dbo.Schools";
                objbulk.ColumnMappings.Add("AcademicYear", "AcademicYear");
                objbulk.ColumnMappings.Add("RollNumber", "RollNumber");
                objbulk.ColumnMappings.Add("OfficialSchoolName", "OfficialSchoolName");
                objbulk.ColumnMappings.Add("Address1", "Address1");
                objbulk.ColumnMappings.Add("Address2", "Address2");
                objbulk.ColumnMappings.Add("Address3", "Address3");
                objbulk.ColumnMappings.Add("Address4", "Address4");
                objbulk.ColumnMappings.Add("County", "County");
                objbulk.ColumnMappings.Add("Eircode", "Eircode");
                objbulk.ColumnMappings.Add("LocalAuthority", "LocalAuthority");
                objbulk.ColumnMappings.Add("X", "X");
                objbulk.ColumnMappings.Add("Y", "Y");
                objbulk.ColumnMappings.Add("ITMEast", "ITMEast");
                objbulk.ColumnMappings.Add("ITMNorth", "ITMNorth");
                objbulk.ColumnMappings.Add("Latitude", "Latitude");
                objbulk.ColumnMappings.Add("Longitude", "Longitude");

                con.Open();
                objbulk.WriteToServer(dt);
                con.Close();
            }

            private void InsertExceldata2(string filepath, string filename)
            {
                string fullpath = Server.MapPath("/CSVuploads/") + filename;
                ExcelConn(fullpath);
                string query = string.Format("Select * from [{0}]", "Sheet1$");
                OleDbCommand Ecom = new OleDbCommand(query, Econ);
                Econ.Open();

                DataSet ds = new DataSet();
                OleDbDataAdapter oda = new OleDbDataAdapter(query, Econ);
                Econ.Close();
                oda.Fill(ds);

                DataTable dt = ds.Tables[0];

                SqlBulkCopy objbulk = new SqlBulkCopy(con);
                objbulk.DestinationTableName = "dbo.School2";
                objbulk.ColumnMappings.Add("RollNumber", "RollNumber");
                objbulk.ColumnMappings.Add("OfficialSchoolName", "OfficialSchoolName");
                objbulk.ColumnMappings.Add("Address1", "Address1");
                objbulk.ColumnMappings.Add("Address2", "Address2");
                objbulk.ColumnMappings.Add("Address3", "Address3");
                objbulk.ColumnMappings.Add("Address4", "Address4");
                objbulk.ColumnMappings.Add("County", "County");
                objbulk.ColumnMappings.Add("Eircode", "Eircode");
                objbulk.ColumnMappings.Add("PhoneNumber", "PhoneNumber");
                objbulk.ColumnMappings.Add("Email", "Email");
                objbulk.ColumnMappings.Add("PrincipalName", "PrincipalName");
                objbulk.ColumnMappings.Add("DeisSchool", "DeisSchool");
                objbulk.ColumnMappings.Add("SchoolGender", "SchoolGender");
                objbulk.ColumnMappings.Add("PupilAttendanceType", "PupilAttendanceType");
                objbulk.ColumnMappings.Add("IrishClassification", "IrishClassification");
                objbulk.ColumnMappings.Add("GaeltachtArea", "GaeltachtArea");
                objbulk.ColumnMappings.Add("FeePayingSchool", "FeePayingSchool");
                objbulk.ColumnMappings.Add("Religion", "Religion");
                objbulk.ColumnMappings.Add("OpenClosedStatus", "OpenClosedStatus");
                objbulk.ColumnMappings.Add("TotalGirls", "TotalGirls");
                objbulk.ColumnMappings.Add("TotalBoys", "TotalBoys");
                objbulk.ColumnMappings.Add("TotalPupils", "TotalPupils");

                con.Open();
                objbulk.WriteToServer(dt);
                con.Close();
            }
        }
    }