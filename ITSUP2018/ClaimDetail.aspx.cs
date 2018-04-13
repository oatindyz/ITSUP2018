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
using System.Globalization;

namespace ITSUP2018
{
    public partial class ClaimDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("Claim.aspx");
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
                using (SqlCommand com = new SqlCommand("select Equip_Rep, Convert(varchar, Equip_Date, 103) as Equip_Date, Equip_location, Equip_Name, ID_Equip_Type, Equip_Serial, Equip_Asset, Equip_Remark, Convert(varchar, Date_Call_Claim, 103) as Date_Call_Claim, Case_Claim, Case_Brand, Convert(varchar, Date_Claim, 103) as Date_Claim, Case_Remark, Convert(varchar, Date_Sent, 103) as Date_Sent, Equip_Status, Equip_ID from tb_Equip WHERE Equip_ID = '" + Request.QueryString["id"].ToString() + "'", con))
                {
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int i = 0;

                            tbEquip_Rep.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbEquip_Date.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbEquip_location.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbEquip_Name.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbID_Equip_Type.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbEquip_Serial.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbEquip_Asset.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbEquip_Remark.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbDate_Call_Claim.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbCase_Claim.Text = reader.IsDBNull(i) ? "" : reader.GetInt64(i).ToString(); ++i;
                            tbCase_Brand.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbDate_Claim.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbCase_Remark.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbDate_Sent.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            HFvalueCheck.Value = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;

                            if (HFvalueCheck.Value == "N")
                            {
                                cbtbEquip_StatusY.Checked = false;
                                cbtbEquip_StatusN.Checked = true;
                            }
                            else if (HFvalueCheck.Value == "Y")
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
            Response.Redirect("Claim.aspx");
        }

        protected void lbuSave_Click(object sender, EventArgs e)
        {
            int id = 0;
            SqlConnection.ClearAllPools();
            /*
            DateTime dttbEquip_Date = DateTime.ParseExact(tbEquip_Date.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime dttbDate_Call_Claim = DateTime.ParseExact(tbDate_Call_Claim.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime dttbDate_Claim = DateTime.ParseExact(tbDate_Claim.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);
            DateTime dttbDate_Sent = DateTime.ParseExact(tbDate_Sent.Text, "MM/dd/yyyy", CultureInfo.InvariantCulture);*/

            using (SqlConnection con = new SqlConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("UPDATE tb_equip SET Equip_Rep=@Equip_Rep, Equip_Date=@Equip_Date, Equip_location=@Equip_location, Equip_Name=@Equip_Name, ID_Equip_Type=@ID_Equip_Type, Equip_Serial=@Equip_Serial, Equip_Asset=@Equip_Asset, Equip_Remark=@Equip_Remark, Date_Call_Claim=@Date_Call_Claim, Case_Claim=@Case_Claim, Case_Brand=@Case_Brand, Date_Claim=@Date_Claim, Case_Remark=@Case_Remark, Date_Sent=@Date_Sent, Equip_Status=@Equip_Status WHERE Equip_ID = '" + Request.QueryString["id"].ToString() + "'", con))
                {

                    com.Parameters.Add(new SqlParameter("Equip_Rep", tbEquip_Rep.Text));

                    if (!string.IsNullOrEmpty(tbEquip_Date.Text)) {
                        com.Parameters.Add(new SqlParameter("Equip_Date", DateTime.Parse(tbEquip_Date.Text).ToString("MM/dd/yyyy")));
                    } else { com.Parameters.Add(new SqlParameter("Equip_Date", DBNull.Value)); }

                    com.Parameters.Add(new SqlParameter("Equip_location", tbEquip_location.Text));
                    com.Parameters.Add(new SqlParameter("Equip_Name", tbEquip_Name.Text));
                    com.Parameters.Add(new SqlParameter("ID_Equip_Type", tbID_Equip_Type.Text));
                    com.Parameters.Add(new SqlParameter("Equip_Serial", tbEquip_Serial.Text));
                    com.Parameters.Add(new SqlParameter("Equip_Asset", tbEquip_Asset.Text));
                    com.Parameters.Add(new SqlParameter("Equip_Remark", tbEquip_Remark.Text));

                    if (!string.IsNullOrEmpty(tbDate_Call_Claim.Text)) {
                        com.Parameters.Add(new SqlParameter("Date_Call_Claim", DateTime.Parse(tbDate_Call_Claim.Text).ToString("MM/dd/yyyy")));
                    } else { com.Parameters.Add(new SqlParameter("Date_Call_Claim", DBNull.Value)); }
                    
                    com.Parameters.Add(new SqlParameter("Case_Claim", tbCase_Claim.Text));
                    com.Parameters.Add(new SqlParameter("Case_Brand", tbCase_Brand.Text));

                    if (!string.IsNullOrEmpty(tbDate_Claim.Text)) {
                        com.Parameters.Add(new SqlParameter("Date_Claim", DateTime.Parse(tbDate_Claim.Text).ToString("MM/dd/yyyy")));
                    } else { com.Parameters.Add(new SqlParameter("Date_Claim", DBNull.Value)); }
                    
                    com.Parameters.Add(new SqlParameter("Case_Remark", tbCase_Remark.Text));

                    if (!string.IsNullOrEmpty(tbDate_Sent.Text)) {
                        com.Parameters.Add(new SqlParameter("Date_Sent", DateTime.Parse(tbDate_Sent.Text).ToString("MM/dd/yyyy"))); ;
                    } else { com.Parameters.Add(new SqlParameter("Date_Sent", DBNull.Value)); }
                    
                    if (cbtbEquip_StatusY.Checked == true) { com.Parameters.Add(new SqlParameter("Equip_Status", "Y")); }
                    else if (cbtbEquip_StatusN.Checked == true) { com.Parameters.Add(new SqlParameter("Equip_Status", "N")); }
                     
                    id = com.ExecuteNonQuery();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Save!')", true);
                }
            }
        }
    }
}