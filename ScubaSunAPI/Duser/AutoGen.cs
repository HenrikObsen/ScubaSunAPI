using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Net;

// Duser AutoGen 2.1
// Koden kan bruges fridt så længe denne tekst bliver i toppen af filen.
// Copyright 2016 E-train I/S, Udviklet af Henrik Obsen

//AutoGen ag = new AutoGen("NAMESPACE",Request.PhysicalApplicationPath + "App_Data/", true);

//private readonly IHostingEnvironment _hostingEnvironment;

//public HomeController(IHostingEnvironment hostingEnvironment)
//{
//    _hostingEnvironment = hostingEnvironment;
//}


//public IActionResult Index()
//{
//    //AutoGen ag = new AutoGen("BlogHenrikObsen", _hostingEnvironment.ContentRootPath);
//    return View();
//}
namespace ScubaSunAPI
{

    public class AutoGen
    {

        private string RepoName = "RepoAM";
        private bool GetHelperClases = false;
        private SqlCommand CMD;
        private string path;

        public AutoGen(string repoName, string outputPath, bool getHelpers = false)
        {

            path = outputPath;
            RepoName = repoName;
            GetHelperClases = getHelpers;

            string SQL = "SELECT Table_Name as Name FROM information_schema.tables";

            CMD = new SqlCommand(SQL);

            foreach (DataRow row in GetData(CMD, Conn.GetCon()).Rows)
            {
                MaikFolders();
                CreateClases(row["Name"].ToString());
                GenProClasses(row["Name"].ToString());
                GenApiClasses(row["Name"].ToString());

            }

            if (GetHelperClases)
            {
                GetHelpers();
            }
            //txtDone.Text += "Done!";
        }

        private void GetHelpers()
        {
            if (!Directory.Exists(path + "/AutoGen/Helpers/"))
            {
                DirectoryInfo di = Directory.CreateDirectory(path + "/AutoGen/Helpers/");
            }

            WebClient webClient = new WebClient();
            webClient.DownloadFile("http://duser.net/Download/Helpers/MailFac.txt", path + "/AutoGen/Helpers/MailFac.cs");
            webClient.DownloadFile("http://duser.net/Download/Helpers/AutoPager.txt", path + "/AutoGen/Helpers/AutoPager.cs");
            webClient.DownloadFile("http://duser.net/Download/Helpers/FileTool.txt", path + "/AutoGen/Helpers/FileTool.cs");
            webClient.DownloadFile("http://duser.net/Download/Helpers/Decryper.txt", path + "/AutoGen/Helpers/Decryper.cs");
            webClient.DownloadFile("http://duser.net/Download/Helpers/Uploader.txt", path + "/AutoGen/Helpers/Uploader.cs");
        }

        private void CreateClases(string tableName)
        {
            string strFacName = tableName;
            string strClass = "";

            strClass += "using System;" + "\n\n";


            strClass += "namespace " + RepoName + "\n{" + "\n";

            strClass += "\n\n";
            strClass += "\t public class " + strFacName + "Fac:AutoFac<" + tableName + ">\n";
            strClass += "\t {" + "\n";


            strClass += "\n\n";
            strClass += "\t }";

            strClass += "\n\n";
            strClass += "}";

            System.IO.StreamWriter writer = System.IO.File.CreateText(path + "/AutoGen/Factories/" + strFacName + "Fac.cs");
            writer.WriteLine(strClass);
            writer.Close();
            //txtDone.Text += strFacName + "Fac.cs\n";

        }


        void GenProClasses(string tableName)
        {
            string strName = tableName;
            string strClass = "";
            string pro = "";
            string SQL = "SELECT Column_Name as Name, data_type as Type FROM information_schema.columns WHERE Table_Name='" + tableName + "'";
            //string SQL = "SELECT Table_Name as Name FROM information_schema.tables";

            CMD = new SqlCommand(SQL);

            foreach (DataRow row in GetData(CMD, Conn.GetCon()).Rows)
            {
                string name = row["Name"].ToString();
                string typ = PropDataTypeConverter(row["Type"].ToString());

                pro += "\t\t public " + typ + " " + name + " { get; set; }\n\n";

            }
            strClass += "using System;\n\n";
            strClass += "namespace " + RepoName + "\n{" + "\n\n";
            strClass += "\t public class " + strName + "\n";
            strClass += "\t{\n";


            strClass += pro;

            strClass += "\t }";

            strClass += "\n\n";
            strClass += "}";

            System.IO.StreamWriter writer = System.IO.File.CreateText(path + "/AutoGen/Models/" + strName + ".cs");
            writer.WriteLine(strClass);
            writer.Close();
            // txtDone.Text += strName + ".cs\n";
        }


        public DataTable GetData(SqlCommand CMD, SqlConnection CON)
        {

            DataSet objDS = new DataSet();
            SqlDataAdapter objDA = new SqlDataAdapter();

            CMD.Connection = CON;
            objDA.SelectCommand = CMD;
            objDA.Fill(objDS);

            return objDS.Tables[0];
        }

        string SQLDataTypeConverter(string strDataType)
        {
            string res = "";

            switch (strDataType)
            {
                case "int":
                    res = "Int";
                    break;
                case "varchar":
                    res = "VarChar";
                    break;
                case "dateTime":
                    res = "DateTime";
                    break;
                case "text":
                    res = "Text";
                    break;
                case "float":
                    res = "Float";
                    break;
                case "decimal":
                    res = "Decimal";
                    break;
                default:
                    res = "VarChar";
                    break;
            }
            return res;
        }

        string PropDataTypeConverter(string strDataType)
        {
            string res = "";

            switch (strDataType)
            {
                case "int":
                    res = "int";
                    break;
                case "varchar":
                    res = "string";
                    break;
                case "datetime":
                    res = "DateTime";
                    break;
                case "text":
                    res = "string";
                    break;
                case "decimal":
                    res = "decimal";
                    break;
                case "float":
                    res = "float";
                    break;
                case "bit":
                    res = "bool";
                    break;
                default:
                    res = "string";
                    break;
            }
            return res;
        }


        void GenApiClasses(string tableName)
        {
            string strName = tableName;
            string strClass = "";


            strClass += "using System.Web.Http;\n";
            strClass += "using System.Collections.Generic;\n";
            strClass += "using System;\n\n";
            strClass += "namespace " + RepoName + ".Controllers\n{" + "\n\n";
            strClass += "\t public class " + strName + "ApiController : ApiController\n";
            strClass += "\t{\n\n";
            //*****************************************************************


            strClass += "\t\t AutoFac<" + strName + "> af = new AutoFac<" + strName + ">();\n\n";

            strClass += "\t\t [HttpGet] \n";

            strClass += "\t\t [Route(\"" + strName + "/Get/{id}\")] \n";
            strClass += "\t\t public " + strName + " Get(int id) \n";
            strClass += "\t\t { \n";
            strClass += "\t\t\t return af.Get(id); \n";
            strClass += "\t\t } \n\n";

            strClass += "\t\t [HttpGet] \n";
            strClass += "\t\t [Route(\"" + strName + "/GetAll\")] \n";
            strClass += "\t\t public IEnumerable<" + strName + "> GetAll() \n";
            strClass += "\t\t { \n";
            strClass += "\t\t\t return af.GetAll(); \n";
            strClass += "\t\t } \n\n";

            strClass += "\t\t [HttpGet] \n";
            strClass += "\t\t [Route(\"" + strName + "/GetAll/{column}/{direction}\")] \n";
            strClass += "\t\t public IEnumerable<" + strName + "> GetAll(string column, string direction) \n";
            strClass += "\t\t { \n";
            strClass += "\t\t\t return af.GetAll(column, direction); \n";
            strClass += "\t\t } \n\n";


            strClass += "\t\t [HttpGet] \n";
            strClass += "\t\t [Route(\"" + strName + "/GetAll/{column}/{direction}/{amount}\")] \n";
            strClass += "\t\t public IEnumerable<" + strName + "> GetAll(string column, string direction, int amount) \n";
            strClass += "\t\t { \n";
            strClass += "\t\t\t return af.GetAll(column, direction, amount); \n";
            strClass += "\t\t } \n\n";

            strClass += "\t\t [HttpGet] \n";
            strClass += "\t\t [Route(\"" + strName + "/GetBy/{column}/{value}\")] \n";
            strClass += "\t\t public IEnumerable<" + strName + "> GetBy(string column, object value) \n";
            strClass += "\t\t { \n";
            strClass += "\t\t\t return af.GetBy(column, value); \n";
            strClass += "\t\t } \n\n";

            strClass += "\t\t [HttpGet] \n";
            strClass += "\t\t [Route(\"" + strName + "/GetBy/{column}/{value}/{ordercolumn}/{direction}\")] \n";
            strClass += "\t\t public IEnumerable<" + strName + "> GetBy(string column, object value, string ordercolumn, string direction) \n";
            strClass += "\t\t { \n";
            strClass += "\t\t\t return af.GetBy(column, value, ordercolumn, direction); \n";
            strClass += "\t\t } \n\n";

            strClass += "\t\t [HttpGet] \n";
            strClass += "\t\t [Route(\"" + strName + "/Count\")] \n";
            strClass += "\t\t public int Count() \n";
            strClass += "\t\t { \n";
            strClass += "\t\t\t return af.Count(); \n";
            strClass += "\t\t } \n\n";

            strClass += "\t\t [HttpGet] \n";
            strClass += "\t\t [Route(\"" + strName + "/Count/{column}/{value}\")] \n";
            strClass += "\t\t public int Count(string column, object value) \n";
            strClass += "\t\t { \n";
            strClass += "\t\t\t return af.Count(column, value); \n";
            strClass += "\t\t } \n\n";

            strClass += "\t\t [HttpGet] \n";
            strClass += "\t\t [Route(\"" + strName + "/Delete/{id}\")] \n";
            strClass += "\t\t public void Delete(int id) \n";
            strClass += "\t\t { \n";
            strClass += "\t\t\t af.Delete(id); \n";
            strClass += "\t\t } \n\n";


            strClass += "\t\t [HttpGet] \n";
            strClass += "\t\t [Route(\"" + strName + "/DeleteBy/{column}/{value}\")] \n";
            strClass += "\t\t public void DeleteBy(string column, object value) \n";
            strClass += "\t\t { \n";
            strClass += "\t\t\t af.DeleteBy(column, value); \n";
            strClass += "\t\t } \n\n";

            strClass += "\t\t [HttpPost] \n";
            strClass += "\t\t [Route(\"" + strName + "/Insert\")] \n";
            strClass += "\t\t public int Insert(" + strName + " model) \n";
            strClass += "\t\t { \n";
            strClass += "\t\t\t return af.Insert(model); \n";
            strClass += "\t\t } \n\n";


            strClass += "\t\t [HttpPost] \n";
            strClass += "\t\t [Route(\"" + strName + "/Update\")] \n";
            strClass += "\t\t public void Update(" + strName + " model) \n";
            strClass += "\t\t { \n";
            strClass += "\t\t\t af.Update(model); \n";
            strClass += "\t\t } \n\n";

            strClass += "\t\t [HttpPost] \n";
            strClass += "\t\t [Route(\"" + strName + "/UpdateColumn\")] \n";
            strClass += "\t\t public void UpdateColumn(string column, object value, int id) \n";
            strClass += "\t\t { \n";
            strClass += "\t\t\t af.UpdateColumn(column, value, id); \n";
            strClass += "\t\t } \n\n";



            //*****************************************************************

            strClass += "\t }";

            strClass += "\n\n";
            strClass += "}";

            System.IO.StreamWriter writer = System.IO.File.CreateText(path + "/AutoGen/Controllers/" + strName + "ApiController.cs");
            writer.WriteLine(strClass);
            writer.Close();
            // txtDone.Text += strName + ".cs\n";
        }

        void MaikFolders()
        {
            if (!Directory.Exists(path + "/AutoGen/"))
            {
                DirectoryInfo di = Directory.CreateDirectory(path + "/AutoGen/");
                //txtDone.Text += "/App_Code/\n";
            }

            if (!Directory.Exists(path + "/AutoGen/Models/"))
            {
                DirectoryInfo di = Directory.CreateDirectory(path + "/AutoGen/Models/");
                //txtDone.Text += "/App_Code/Types/\n";
            }

            if (!Directory.Exists(path + "/AutoGen/Factories/"))
            {
                DirectoryInfo di = Directory.CreateDirectory(path + "/AutoGen/Factories/");
                //txtDone.Text += "/App_Code/Factories/\n";
            }

            if (!Directory.Exists(path + "/AutoGen/Controllers/"))
            {
                DirectoryInfo di = Directory.CreateDirectory(path + "/AutoGen/Controllers/");
                //txtDone.Text += "/App_Code/Controllers/\n";
            }

            //string sti = Path.GetDirectoryName(_AppPath);
            //System.IO.File.Copy(sti + "/Classes/Data/DataAccess.cs", path + "/App_Code/DataAccess.cs", true);
            //File.Copy(sti + "/Classes/Data/web.config", path + "/web.config", true);
            //txtDone.Text += "/App_Code/DataAccess/ \n";



        }
    }

}