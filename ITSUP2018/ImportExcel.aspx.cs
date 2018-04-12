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
                                using (SqlCommand com = new SqlCommand("INSERT INTO tb_equip (Equip_Rep ,Equip_Date ,Equip_location ,Equip_Name ,ID_Equip_Type ,Equip_Serial ,Equip_Asset ,Equip_Remark ,Date_Call_Claim ,Case_Claim ,Case_Brand ,Date_Claim ,Case_Remark ,Date_Sent ,Equip_Status ,Equip_File ,Created_Date ,Created_By) VALUES (@Equip_Rep ,@Equip_Date ,@Equip_location ,@Equip_Name ,@ID_Equip_Type ,@Equip_Serial ,@Equip_Asset ,@Equip_Remark ,@Date_Call_Claim ,@Case_Claim ,@Case_Brand ,@Date_Claim ,@Case_Remark ,@Date_Sent ,@Equip_Status ,@Equip_File ,@Created_Date ,@Created_By)", con))
                                {
                                    if (string.IsNullOrEmpty(excelReader.GetString(0)))
                                    {
                                        com.Parameters.Add(new SqlParameter("Equip_Rep", DBNull.Value));
                                    }
                                    else { com.Parameters.Add(new SqlParameter("Equip_Rep", excelReader.GetString(0))); }
                                    //
                                    if (excelReader.IsDBNull(1))
                                    {
                                        com.Parameters.Add(new SqlParameter("Equip_Date", DBNull.Value));
                                    }
                                    else { com.Parameters.Add(new SqlParameter("Equip_Date", excelReader.GetDateTime(1).AddYears(-543).ToString("MM/dd/yyyy"))); }
                                    //
                                    if (string.IsNullOrEmpty(excelReader.GetString(2)))
                                    {
                                        com.Parameters.Add(new SqlParameter("Equip_location", DBNull.Value));
                                    }
                                    else { com.Parameters.Add(new SqlParameter("Equip_location", excelReader.GetString(2))); }
                                    //
                                    if (string.IsNullOrEmpty(excelReader.GetString(3)))
                                    {
                                        com.Parameters.Add(new SqlParameter("Equip_Name", DBNull.Value));
                                    }
                                    else { com.Parameters.Add(new SqlParameter("Equip_Name", excelReader.GetString(3))); }
                                    //
                                    if (string.IsNullOrEmpty(excelReader.GetString(4)))
                                    {
                                        com.Parameters.Add(new SqlParameter("ID_Equip_Type", DBNull.Value));
                                    }
                                    else { com.Parameters.Add(new SqlParameter("ID_Equip_Type", excelReader.GetString(4))); }
                                    //
                                    if (string.IsNullOrEmpty(excelReader.GetString(5)))
                                    {
                                        com.Parameters.Add(new SqlParameter("Equip_Serial", DBNull.Value));
                                    }
                                    else { com.Parameters.Add(new SqlParameter("Equip_Serial", excelReader.GetString(5))); }
                                    //
                                    if (string.IsNullOrEmpty(excelReader.GetString(6)))
                                    {
                                        com.Parameters.Add(new SqlParameter("Equip_Asset", DBNull.Value));
                                    }
                                    else { com.Parameters.Add(new SqlParameter("Equip_Asset", excelReader.GetString(6))); }
                                    //
                                    if (string.IsNullOrEmpty(excelReader.GetString(7)))
                                    {
                                        com.Parameters.Add(new SqlParameter("Equip_Remark", DBNull.Value));
                                    }
                                    else { com.Parameters.Add(new SqlParameter("Equip_Remark", excelReader.GetString(7))); }
                                    //
                                    if (excelReader.IsDBNull(8))
                                    {
                                        com.Parameters.Add(new SqlParameter("Date_Call_Claim", DBNull.Value));
                                    }
                                    else { com.Parameters.Add(new SqlParameter("Date_Call_Claim", excelReader.GetDateTime(8).AddYears(-543).ToString("MM/dd/yyyy"))); }
                                    //
                                    if (excelReader.IsDBNull(9))
                                    {
                                        com.Parameters.Add(new SqlParameter("Case_Claim", DBNull.Value));
                                    }
                                    else { com.Parameters.Add(new SqlParameter("Case_Claim", excelReader.GetValue(9))); }
                                    //
                                    if (string.IsNullOrEmpty(excelReader.GetString(10)))
                                    {
                                        com.Parameters.Add(new SqlParameter("Case_Brand", DBNull.Value));
                                    }
                                    else { com.Parameters.Add(new SqlParameter("Case_Brand", excelReader.GetString(10))); }
                                    //
                                    if (excelReader.IsDBNull(11))
                                    {
                                        com.Parameters.Add(new SqlParameter("Date_Claim", DBNull.Value));
                                    }
                                    else { com.Parameters.Add(new SqlParameter("Date_Claim", excelReader.GetDateTime(11).AddYears(-543).ToString("MM/dd/yyyy"))); }
                                    //
                                    if (string.IsNullOrEmpty(excelReader.GetString(12)))
                                    {
                                        com.Parameters.Add(new SqlParameter("Case_Remark", DBNull.Value));
                                    }
                                    else { com.Parameters.Add(new SqlParameter("Case_Remark", excelReader.GetString(12))); }
                                    //
                                    if (excelReader.IsDBNull(13))
                                    {
                                        com.Parameters.Add(new SqlParameter("Date_Sent", DBNull.Value));
                                    }
                                    else { com.Parameters.Add(new SqlParameter("Date_Sent", excelReader.GetDateTime(13).AddYears(-543).ToString("MM/dd/yyyy"))); }
                                    //                            
                                    com.Parameters.Add(new SqlParameter("Equip_Status", "N"));
                                    com.Parameters.Add(new SqlParameter("Equip_File", fi.FullName));
                                    com.Parameters.Add(new SqlParameter("Created_Date", DateTime.Now.AddYears(-543).ToString("MM/dd/yyyy hh:mm:ss.fff")));
                                    com.Parameters.Add(new SqlParameter("Created_By", HttpContext.Current.Server.MachineName));

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