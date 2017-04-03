using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.FA
{
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //SessionUser s = new SessionUser();
                //s.OCode = "8989";
                //s.UserId = Guid.Parse("E077F2DC-9C9B-4C12-B4B4-8578C591CB51");
                //Session["SessionUser"] = s;
                ////System.Guid.NewGuid().ToString();
                //Session["OCode"] = s.OCode;
                //Session["UserId"] = s.UserId;

                //string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                //string RoleId = ((SessionUser)Session["SessionUser"]).RoleId;
                //string UserId = ((SessionUser)Session["SessionUser"]).UserId.ToString();
                //string UserType = ((SessionUser)Session["SessionUser"]).User_Level;
            }
        }
    }
}