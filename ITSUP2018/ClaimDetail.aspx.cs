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
                MV.ActiveViewIndex = 0;
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

                            HF_ID_Equip_Type.Value = reader.GetString(i).ToString(); ++i;
                            if (HF_ID_Equip_Type.Value == "PC") {
                                RB_Type_PC.Checked = true;
                                RB_Type_NB.Checked = false;
                            } else if (HF_ID_Equip_Type.Value == "NB"){
                                RB_Type_PC.Checked = false;
                                RB_Type_NB.Checked = true;
                            }

                            tbEquip_Serial.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbEquip_Asset.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbEquip_Remark.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbDate_Call_Claim.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbCase_Claim.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;

                            HF_Case_Brand.Value = reader.GetString(i).ToString(); ++i;
                            if (HF_Case_Brand.Value == "Lenovo") {
                                RB_Case_Brand_Lenovo.Checked = true;
                                RB_Case_Brand_HP.Checked = false;
                                RB_Case_Brand_Dell.Checked = false;
                            } else if (HF_Case_Brand.Value == "HP") {
                                RB_Case_Brand_Lenovo.Checked = false;
                                RB_Case_Brand_HP.Checked = true;
                                RB_Case_Brand_Dell.Checked = false;
                            } else if (HF_Case_Brand.Value == "Dell") {
                                RB_Case_Brand_Lenovo.Checked = false;
                                RB_Case_Brand_HP.Checked = false;
                                RB_Case_Brand_Dell.Checked = true;
                            }

                            tbDate_Claim.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbCase_Remark.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;
                            tbDate_Sent.Text = reader.IsDBNull(i) ? "" : reader.GetString(i).ToString(); ++i;

                            HFvalueCheck.Value = reader.GetString(i).ToString(); ++i;
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
            if (string.IsNullOrEmpty(tbEquip_Rep.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed! เลขที่เอกสาร ห้ามว่าง')", true);
                return;
            }
            if (string.IsNullOrEmpty(tbEquip_Date.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed! วันที่เอกสาร ห้ามว่าง')", true);
                return;
            }
            if (string.IsNullOrEmpty(tbEquip_Name.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed! ชื่อรุ่นคอมพิวเตอร์ ห้ามว่าง')", true);
                return;
            }
            if (!RB_Type_PC.Checked && !RB_Type_NB.Checked)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed! เลือก อุปกรณ์ประเภท')", true);
                return;
            }
            if (string.IsNullOrEmpty(tbDate_Call_Claim.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed! วันที่โทรแจ้งเคลม ห้ามว่าง')", true);
                return;
            }
            if (string.IsNullOrEmpty(tbCase_Claim.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed! เลขเคสงาน ห้ามว่าง')", true);
                return;
            }
            if (!RB_Case_Brand_Lenovo.Checked && !RB_Case_Brand_HP.Checked && !RB_Case_Brand_Dell.Checked)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed! เลือก เคสแบรนที่แจ้ง')", true);
                return;
            }
            if (string.IsNullOrEmpty(tbDate_Claim.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed! วันที่ช่างแก้ไข ห้ามว่าง')", true);
                return;
            }
            if (string.IsNullOrEmpty(tbCase_Remark.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed! อาการที่ช่างแก้ไข ห้ามว่าง')", true);
                return;
            }
            if (string.IsNullOrEmpty(tbDate_Sent.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed! วันที่ส่งคืนอุปกรณ์ ห้ามว่าง')", true);
                return;
            }
            if (!cbtbEquip_StatusY.Checked && !cbtbEquip_StatusN.Checked)
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed! เลือก สถานะ')", true);
                return;
            }

            int id = 0;
            SqlConnection.ClearAllPools();

            using (SqlConnection con = new SqlConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("UPDATE tb_equip SET Equip_Rep=@Equip_Rep, Equip_Date=@Equip_Date, Equip_location=@Equip_location, Equip_Name=@Equip_Name, ID_Equip_Type=@ID_Equip_Type, Equip_Serial=@Equip_Serial, Equip_Asset=@Equip_Asset, Equip_Remark=@Equip_Remark, Date_Call_Claim=@Date_Call_Claim, Case_Claim=@Case_Claim, Case_Brand=@Case_Brand, Date_Claim=@Date_Claim, Case_Remark=@Case_Remark, Date_Sent=@Date_Sent, Equip_Status=@Equip_Status, Modified_Date=@Modified_Date, Modified_By=@Modified_By WHERE Equip_ID = '" + Request.QueryString["id"].ToString() + "'", con))
                {

                    com.Parameters.Add(new SqlParameter("Equip_Rep", tbEquip_Rep.Text));

                    if (!string.IsNullOrEmpty(tbEquip_Date.Text)) {
                        com.Parameters.Add(new SqlParameter("Equip_Date", DateTime.Parse(tbEquip_Date.Text).ToString("MM/dd/yyyy")));
                    } else { com.Parameters.Add(new SqlParameter("Equip_Date", DBNull.Value)); }

                    com.Parameters.Add(new SqlParameter("Equip_location", tbEquip_location.Text));
                    com.Parameters.Add(new SqlParameter("Equip_Name", tbEquip_Name.Text));

                    if (RB_Type_PC.Checked) {
                        com.Parameters.Add(new SqlParameter("ID_Equip_Type", "PC"));
                    } else if (RB_Type_NB.Checked) {
                        com.Parameters.Add(new SqlParameter("ID_Equip_Type", "NB"));
                    }

                    com.Parameters.Add(new SqlParameter("Equip_Serial", tbEquip_Serial.Text));
                    com.Parameters.Add(new SqlParameter("Equip_Asset", tbEquip_Asset.Text));
                    com.Parameters.Add(new SqlParameter("Equip_Remark", tbEquip_Remark.Text));

                    if (!string.IsNullOrEmpty(tbDate_Call_Claim.Text)) {
                        com.Parameters.Add(new SqlParameter("Date_Call_Claim", DateTime.Parse(tbDate_Call_Claim.Text).ToString("MM/dd/yyyy")));
                    } else { com.Parameters.Add(new SqlParameter("Date_Call_Claim", DBNull.Value)); }
                    
                    com.Parameters.Add(new SqlParameter("Case_Claim", tbCase_Claim.Text));

                    if (RB_Case_Brand_Lenovo.Checked) {
                        com.Parameters.Add(new SqlParameter("Case_Brand", "Lenovo"));
                    } else if (RB_Case_Brand_HP.Checked) {
                        com.Parameters.Add(new SqlParameter("Case_Brand", "HP"));
                    } else if (RB_Case_Brand_Dell.Checked) {
                        com.Parameters.Add(new SqlParameter("Case_Brand", "Dell"));
                    }

                    if (!string.IsNullOrEmpty(tbDate_Claim.Text)) {
                        com.Parameters.Add(new SqlParameter("Date_Claim", DateTime.Parse(tbDate_Claim.Text).ToString("MM/dd/yyyy")));
                    } else { com.Parameters.Add(new SqlParameter("Date_Claim", DBNull.Value)); }
                    
                    com.Parameters.Add(new SqlParameter("Case_Remark", tbCase_Remark.Text));

                    if (!string.IsNullOrEmpty(tbDate_Sent.Text)) {
                        com.Parameters.Add(new SqlParameter("Date_Sent", DateTime.Parse(tbDate_Sent.Text).ToString("MM/dd/yyyy"))); ;
                    } else { com.Parameters.Add(new SqlParameter("Date_Sent", DBNull.Value)); }
                    
                    if (cbtbEquip_StatusY.Checked == true) { com.Parameters.Add(new SqlParameter("Equip_Status", "Y")); }
                    else if (cbtbEquip_StatusN.Checked == true) { com.Parameters.Add(new SqlParameter("Equip_Status", "N")); }

                    com.Parameters.Add(new SqlParameter("Modified_Date", DateTime.Now.AddYears(-543).ToString("yyyy/MM/dd hh:mm:ss.fff")));
                    com.Parameters.Add(new SqlParameter("Modified_By", HttpContext.Current.Server.MachineName));

                    id = com.ExecuteNonQuery();
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data Save!')", true);
                    MV.ActiveViewIndex = 1;
                }
            }
        }

        protected void lbBackListClaim_Click(object sender, EventArgs e)
        {
            Response.Redirect("Claim.aspx");
        }
    }
}