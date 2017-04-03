using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM
{
    public partial class EmployeeWiseBenefitList : System.Web.UI.Page
    {
        EmployeeBenefitBLL employeeBenefitbll = new EmployeeBenefitBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {

                    getEmployeeWiseList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }

        }

        private void getEmployeeWiseList()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<EmployeeWiseBebefit> employeeBeneFites = new List<EmployeeWiseBebefit>();
                employeeBeneFites = employeeBenefitbll.GetEmployeeWiseBenefitList(OCODE);
                if (employeeBeneFites.Count > 0)
                {
                    grdemployees.DataSource = employeeBeneFites;
                    grdemployees.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        protected void imgbtnEmployeeWiseBenefit_Click(object sender, EventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string benefitId = "";
                Label lblEmployeeWiseBenefitId = (Label)grdemployees.Rows[row.RowIndex].FindControl("lblWiseBeneFitId");
                if (lblEmployeeWiseBenefitId != null)
                {
                    benefitId = lblEmployeeWiseBenefitId.Text;
                    Session["EmployeeBenefitID"] = benefitId;
                    Response.Redirect("EmployeeWiseBenefit.aspx");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void grdemployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            grdemployees.PageIndex = e.NewPageIndex;
            getEmployeeWiseList();
        }
    }
}