using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.Dashboard
{
    public partial class Index : System.Web.UI.Page
    {
        LEAVE_BLL leaveBll = new LEAVE_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GettotalEmployee();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }

        }

        private void GettotalEmployee()
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

            List<HRM_ATTENDANCE> totalemployee = leaveBll.GetAllEmployee(OCODE);

            lblTotalEmp.Text = totalemployee.ToString();


        }


    }
}