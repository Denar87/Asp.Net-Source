using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL;

namespace ERPSSL.PAYROLL
{
    public partial class index : System.Web.UI.Page
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
            //SessionUser objSessionUser = new SessionUser();
            //objSessionUser.UserId = Guid.Parse("a376708d-757f-4777-bd05-bfc89b6971ce");
            //objSessionUser.OCode = "8989";
            //Session["SessionUser"] = objSessionUser;
        }
    }
}