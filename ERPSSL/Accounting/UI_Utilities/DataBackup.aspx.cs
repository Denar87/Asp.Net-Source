using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Accounting.UI_Utilities
{
    public partial class DataBackup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["CompanyCode"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {

                }
            }
            else
            {
                Response.Redirect("..\\..\\Default.aspx");
            }
        }
    }
}