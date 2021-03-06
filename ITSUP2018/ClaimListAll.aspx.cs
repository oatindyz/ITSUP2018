﻿using System;
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
    public partial class ClaimListAll : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                BindDataNo();
            }

        }
        public void BindDataNo()
        {
            SqlConnection.ClearAllPools();
            SqlConnection con = new SqlConnection(DatabaseManager.CONNECTION_STRING);
            con.Open();
            SqlCommand com = new SqlCommand("SELECT Equip_ID, Equip_Rep, Equip_Name, Equip_Asset, Equip_Remark, Cast(Case_Claim as nvarchar(255)) + ' : ' + Case_Brand Equip_Case_Claim , Equip_Status FROM tb_equip ORDER BY Equip_Rep ASC", con);
            SqlDataReader reader = com.ExecuteReader();
            String UnreadText = "";
            Int32 i = 0;
            while (reader.Read())
            {

                UnreadText += "<tr>";
                UnreadText += "			<td class=\"center\">" + reader["Equip_Rep"] + "</td>";
                UnreadText += "			<td class=\"center\">" + reader["Equip_Name"] + "</td>";
                UnreadText += "			<td class=\"center\">" + reader["Equip_Asset"] + "</td>";
                UnreadText += "			<td class=\"center\">" + reader["Equip_Remark"] + "</td>";
                UnreadText += "			<td class=\"center\">" + reader["Equip_Case_Claim"] + "</td>";
                UnreadText += "			<td class=\"center\">" + reader["Equip_Status"] + "</td>";
                UnreadText += "			<td class=\"center\">";
                UnreadText += "				<a class=\"btn btn-info\" href=\"ClaimDetail.aspx?ID=" + reader[0] + "\">";
                UnreadText += "					<i class=\"icon-edit icon-white\"></i>  ";
                UnreadText += "					Edit                                    ";
                UnreadText += "				</a>";
                UnreadText += "				<a class=\"btn btn-info\" href=\"ClaimDetailDelete.aspx?ID=" + reader[0] + "\">";
                UnreadText += "					<i class=\"icon-edit icon-white\"></i>  ";
                UnreadText += "					Delete                                    ";
                UnreadText += "				</a>";
                UnreadText += "			</td>";
                UnreadText += "		</tr>";
                tlistAll.InnerHtml = UnreadText;
                i++;
            }

        }
    }
}