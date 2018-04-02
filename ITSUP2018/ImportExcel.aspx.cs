using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using ITSUP2018.Class;
using System.IO;
using ExcelDataReader;

namespace ITSUP2018
{
    public partial class ImportExcel : System.Web.UI.Page
    {
        private bool isValidFile;

        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected void btnInsertExcel_Click(object sender, EventArgs e)
        {
            string[] validFileTypes = { "xlsx", "xls" };
            string ext = System.IO.Path.GetExtension(FUExcel.PostedFile.FileName);
            //bool isValidFile = false;

            for (int i = 0; i < validFileTypes.Length; i++)
            {
                if (ext == "." + validFileTypes[i])
                {
                    isValidFile = true;
                    break;
                }
            }
            if (!isValidFile)
            {
                ScriptManager.GetCurrent(this.Page).SetFocus(this.FUExcel);
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Please XLS or XLSX')", true);
                return;
            }

            using (SqlConnection con = new SqlConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                FileInfo fi = new FileInfo(FUExcel.FileName);
                FUExcel.SaveAs(Server.MapPath("Upload/Excel/" + fi));
                if (FUExcel.HasFile)
                {
                    using (FileStream stream = File.Open(Server.MapPath("Upload/Excel/" + fi), FileMode.Open, FileAccess.Read))
                    {
                        IExcelDataReader excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                        //excelReader.IsFirstRowAsColumnNames = false;
                        int i = 0;
                        while (excelReader.Read())
                        {
                            if (i > 0)
                            {
                                using (SqlCommand com = new SqlCommand("INSERT INTO Equip_Main (Equip_Date ,Equip_Name ,ID_Equip_Type ,Equip_Serial ,Equip_Asset ,Equip_Remark ,Date_Start_Claim ,Equip_Case_Claim ,Equip_Case_Brand ,Equip_Status ,Equip_File ,Equip_PC) VALUES (@Equip_Date ,@Equip_Name ,@ID_Equip_Type ,@Equip_Serial ,@Equip_Asset ,@Equip_Remark ,@Date_Start_Claim ,@Equip_Case_Claim ,@Equip_Case_Brand ,@Equip_Status ,@Equip_File ,@Equip_PC)", con))
                                {
                                    com.Parameters.Add(new SqlParameter("Equip_Date", excelReader.GetDateTime(0).AddYears(-543).ToString("MM/dd/yyyy")));
                                    com.Parameters.Add(new SqlParameter("Equip_Name", excelReader.GetString(1)));
                                    com.Parameters.Add(new SqlParameter("ID_Equip_Type", excelReader.GetString(2)));
                                    com.Parameters.Add(new SqlParameter("Equip_Serial", excelReader.GetString(3)));
                                    com.Parameters.Add(new SqlParameter("Equip_Asset", excelReader.GetString(4)));
                                    com.Parameters.Add(new SqlParameter("Equip_Remark", excelReader.GetString(5)));
                                    com.Parameters.Add(new SqlParameter("Date_Start_Claim", excelReader.GetDateTime(6).AddYears(-543).ToString("MM/dd/yyyy")));
                                    com.Parameters.Add(new SqlParameter("Equip_Case_Claim", excelReader.GetString(7)));
                                    com.Parameters.Add(new SqlParameter("Equip_Case_Brand", excelReader.GetString(8)));
                                    com.Parameters.Add(new SqlParameter("Equip_Status", "N"));
                                    com.Parameters.Add(new SqlParameter("Equip_File", fi.FullName));
                                    com.Parameters.Add(new SqlParameter("Equip_PC", HttpContext.Current.Server.MachineName));
                                    com.ExecuteNonQuery();
                                }
                            }
                            i++;

                            if (i == 0)
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('ERROR')", true);
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Success')", true);
                            }

                        }
                    }
                }
            }
        }
    }
}