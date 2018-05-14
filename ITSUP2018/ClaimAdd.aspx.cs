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
    public partial class ClaimAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            
            }
        }

        protected void lbuBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Claim.aspx");
        }

        public void TextClearAll()
        {
            tbEquip_Rep.Text = "";
            tbEquip_Date.Text = "";
            tbEquip_location.Text = "";
            tbEquip_Name.Text = "";
            RB_Type_PC.Checked = false;
            RB_Type_NB.Checked = false;
            tbEquip_Serial.Text = "";
            tbEquip_Asset.Text = "";
            tbEquip_Remark.Text = "";
            tbDate_Call_Claim.Text = "";
            tbCase_Claim.Text = "";
            RB_Case_Brand_Lenovo.Checked = false;
            RB_Case_Brand_HP.Checked = false;
            RB_Case_Brand_Dell.Checked = false;
        }

        protected void lbuSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbEquip_Rep.Text))
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed! เลขที่เอกสาร ห้ามว่าง')", true);
                return;
            }
            string Have = DatabaseManager.ExecuteString("SELECT COUNT(*) FROM tb_equip WHERE Equip_Rep = '" + tbEquip_Rep.Text + "'");
            if (Have != "0")
            {
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Failed! เลขที่เอกสาร " + tbEquip_Rep.Text + " มีแล้วในระบบ')", true);
                return;
            }
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

            SqlConnection.ClearAllPools();

            using (SqlConnection con = new SqlConnection(DatabaseManager.CONNECTION_STRING))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand("INSERT INTO tb_equip (Equip_Rep, Equip_Date, Equip_location, Equip_Name, ID_Equip_Type, Equip_Serial, Equip_Asset, Equip_Remark, Date_Call_Claim, Case_Claim, Case_Brand, Equip_Status, Equip_File, Created_Date, Created_By) VALUES (@Equip_Rep, @Equip_Date, @Equip_location, @Equip_Name, @ID_Equip_Type, @Equip_Serial, @Equip_Asset, @Equip_Remark, @Date_Call_Claim, @Case_Claim, @Case_Brand, @Equip_Status, @Equip_File, @Created_Date, @Created_By)", con))
                {
                    com.Parameters.Add(new SqlParameter("Equip_Rep", tbEquip_Rep.Text));
                    com.Parameters.Add(new SqlParameter("Equip_Date", DateTime.ParseExact(tbEquip_Date.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
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
                    com.Parameters.Add(new SqlParameter("Date_Call_Claim", DateTime.ParseExact(tbDate_Call_Claim.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture).ToString("MM/dd/yyyy", CultureInfo.InvariantCulture)));
                    com.Parameters.Add(new SqlParameter("Case_Claim", tbCase_Claim.Text));

                    if (RB_Case_Brand_Lenovo.Checked) {
                        com.Parameters.Add(new SqlParameter("Case_Brand", "Lenovo"));
                    } else if (RB_Case_Brand_HP.Checked) {
                        com.Parameters.Add(new SqlParameter("Case_Brand", "HP"));
                    } else if (RB_Case_Brand_Dell.Checked) {
                        com.Parameters.Add(new SqlParameter("Case_Brand", "Dell"));
                    }

                    com.Parameters.Add(new SqlParameter("Equip_Status", "N"));
                    com.Parameters.Add(new SqlParameter("Equip_File", "Create Manaul"));
                    com.Parameters.Add(new SqlParameter("Created_Date", DateTime.Now.AddYears(-543).ToString("yyyy/MM/dd hh:mm:ss.fff")));
                    com.Parameters.Add(new SqlParameter("Created_By", HttpContext.Current.Server.MachineName));
                    com.ExecuteNonQuery();

                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Success')", true);
                    TextClearAll();
                }
            }
       
        }
    }
}