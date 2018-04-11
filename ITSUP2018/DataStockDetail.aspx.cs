using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Text;
using ITSUP2018.Class;

namespace ITSUP2018
{
    public partial class DataStockDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("DataStock.aspx");
            }
            if (!IsPostBack)
            {
                ReadSelectID();
            }
        }

        private void ReadSelectID()
        {
            using (SqlConnection con = new SqlConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("SELECT Convert(varchar, Equip_Date, 101), Equip_Name, ID_Equip_Type, Equip_Serial, Equip_Asset, Equip_Remark, Convert(varchar, Date_Start_Claim, 101), Convert(varchar, Date_End_Claim, 101), Equip_Case_Claim, Equip_Case_Brand, Equip_Status FROM Equip_Main WHERE ID_Equip = '" + Request.QueryString["id"].ToString() + "'", con))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;
                            tbEquip_Date.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbEquip_Name.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbID_Equip_Type.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbEquip_Serial.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbEquip_Asset.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbEquip_Remark.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbDate_Start_Claim.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbDate_End_Claim.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbEquip_Case_Claim.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbEquip_Case_Brand.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            HFvalueCheck.Value = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            if (HFvalueCheck.Value == "N") {
                                cbtbEquip_StatusY.Checked = false;
                                cbtbEquip_StatusN.Checked = true;
                            } else if (HFvalueCheck.Value == "Y")
                            {
                                cbtbEquip_StatusY.Checked = true;
                                cbtbEquip_StatusN.Checked = false;
                            }
                              

                        }
                    }
                }
            }
        }

        protected void lbuBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("DataStock.aspx");
        }

        protected void lbuSave_Click(object sender, EventArgs e)
        {
            int id = 0;
            SqlConnection.ClearAllPools();
            using (SqlConnection con = new SqlConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("UPDATE Equip_Main SET Equip_Date=@Equip_Date, Equip_Name=@Equip_Name, ID_Equip_Type=@ID_Equip_Type, Equip_Serial=@Equip_Serial, Equip_Asset=@Equip_Asset, Equip_Remark=@Equip_Remark, Date_Start_Claim=@Date_Start_Claim, Date_End_Claim=@Date_End_Claim, Equip_Case_Claim=@Equip_Case_Claim, Equip_Case_Brand=@Equip_Case_Brand, Equip_Status=@Equip_Status WHERE ID_Equip = '" + Request.QueryString["id"].ToString() + "'", con))
                {
                    com.Parameters.Add(new SqlParameter("Equip_Date", tbEquip_Date.Text));
                    com.Parameters.Add(new SqlParameter("Equip_Name", tbEquip_Name.Text));
                    com.Parameters.Add(new SqlParameter("ID_Equip_Type", tbID_Equip_Type.Text));
                    com.Parameters.Add(new SqlParameter("Equip_Serial", tbEquip_Serial.Text));
                    com.Parameters.Add(new SqlParameter("Equip_Asset", tbEquip_Asset.Text));
                    com.Parameters.Add(new SqlParameter("Equip_Remark", tbEquip_Remark.Text));

                    if (!string.IsNullOrEmpty(tbDate_Start_Claim.Text)) {
                        com.Parameters.Add(new SqlParameter("Date_Start_Claim", tbDate_Start_Claim.Text));
                    } else {
                        com.Parameters.Add(new SqlParameter("Date_Start_Claim", DBNull.Value));
                    }
                    if (!string.IsNullOrEmpty(tbDate_End_Claim.Text))
                    {
                        com.Parameters.Add(new SqlParameter("Date_End_Claim", tbDate_End_Claim.Text));
                    } else {
                        com.Parameters.Add(new SqlParameter("Date_End_Claim", DBNull.Value));
                    }
                    
                    com.Parameters.Add(new SqlParameter("Equip_Case_Claim", tbEquip_Case_Claim.Text));
                    com.Parameters.Add(new SqlParameter("Equip_Case_Brand", tbEquip_Case_Brand.Text));

                    if (cbtbEquip_StatusY.Checked == true)
                    {
                        com.Parameters.Add(new SqlParameter("Equip_Status", "Y"));
                    } else if (cbtbEquip_StatusN.Checked == true)
                    {
                        com.Parameters.Add(new SqlParameter("Equip_Status", "N"));
                    }
                    
                    id = com.ExecuteNonQuery();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Save!')", true);

                }
            }
        }
    }
}