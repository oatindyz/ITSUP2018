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
    public partial class DataStock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindDataTable();
            }

        }
        public void BindDataTable()
        {

            SqlConnection con = new SqlConnection(DatabaseManager.CONNECTION_STRING);
            con.Open();
            SqlCommand com = new SqlCommand("SELECT ID_Equip, Convert(varchar, Equip_Date, 101) Equip_Date, ID_Equip_Type + ' : ' + Equip_Name as Equip_Name, Equip_Serial, Equip_Asset, Equip_Remark, Equip_Case_Claim + ' : ' + Equip_Case_Brand Equip_Case_Claim FROM Equip_Main ORDER BY ID_Equip ASC", con);
            SqlDataReader reader = com.ExecuteReader();
            String UnreadText = "";
            Int32 i = 0;
            while (reader.Read())
            {

                UnreadText += "<tr>";
                UnreadText += "			<td class=\"center\">" + reader["Equip_Date"] + "</td>";
                UnreadText += "			<td class=\"center\">" + reader["Equip_Name"] + "</td>";
                UnreadText += "			<td class=\"center\">" + reader["Equip_Serial"] + "</td>";
                UnreadText += "			<td class=\"center\">" + reader["Equip_Asset"] + "</td>";
                UnreadText += "			<td class=\"center\">" + reader["Equip_Remark"] + "</td>";
                UnreadText += "			<td class=\"center\">" + reader["Equip_Case_Claim"] + "</td>";
                UnreadText += "			<td class=\"center\">";
                UnreadText += "				<a class=\"btn btn-info\" href=\"DataStockDetail.aspx?ID=" + reader[0] + "\">";
                UnreadText += "					<i class=\"icon-edit icon-white\"></i>  ";
                UnreadText += "					Edit                                    ";
                UnreadText += "				</a>";
                UnreadText += "				<a class=\"btn btn-info\" href=\"DataStockDelete.aspx?ID=" + reader[0] + "\">";
                UnreadText += "					<i class=\"icon-edit icon-white\"></i>  ";
                UnreadText += "					Delete                                    ";
                UnreadText += "				</a>";
                UnreadText += "			</td>";
                UnreadText += "		</tr>";
                tlist.InnerHtml = UnreadText;
                i++;
            }

        }
    }
}