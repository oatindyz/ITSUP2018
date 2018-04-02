using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ITSUP2018.Class;

namespace ITSUP2018
{
    public partial class DataStockDelete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["id"] == null)
            {
                Response.Redirect("DataStock.aspx");
            }
            if (!IsPostBack)
            {
                DatabaseManager.ExecuteNonQuery("DELETE Equip_Main WHERE ID_Equip = '" + Request.QueryString["id"].ToString() + "'");
                ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Data have Deleted!')", true);
                Response.Redirect("DataStock.aspx");
            }
        }
    }
}