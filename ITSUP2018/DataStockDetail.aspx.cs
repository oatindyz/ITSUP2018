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
                using (SqlCommand com = new SqlCommand("SELECT Convert(varchar, Equip_Date, 101), Equip_Name, ID_Equip_Type, Equip_Serial, Equip_Asset, Equip_Remark, Convert(varchar, Date_Start_Claim, 101), Convert(varchar, Date_End_Claim, 101), Equip_Case_Claim, Equip_Case_Brand, Equip_Status, Equip_File, Equip_PC FROM Equip_Main WHERE ID_Equip = '" + Request.QueryString["id"].ToString() + "'", con))
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
                            tbEquip_Status.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbEquip_File.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbEquip_PC.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;

                        }
                    }
                }
            }
        }

        protected void lbuS1Back_Click(object sender, EventArgs e)
        {
            Response.Redirect("DataStock.aspx");
        }
    }
}