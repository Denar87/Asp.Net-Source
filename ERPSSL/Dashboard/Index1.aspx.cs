using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Dashboard
{
    public partial class Index1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }

        }
    }
}