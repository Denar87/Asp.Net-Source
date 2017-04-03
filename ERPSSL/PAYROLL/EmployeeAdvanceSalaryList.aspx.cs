using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.PAYROLL
{
    public partial class EmployeeAdvanceSalaryList : System.Web.UI.Page
    {
        EmployeeBenefitBLL employeeBenefitbll = new EmployeeBenefitBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getEmployeeWiseAdvanceSalaryList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }

        }

        private void getEmployeeWiseAdvanceSalaryList()
        {

            try
            {

                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<EmployeeAdvanceSalaryR> employeeAdvanceSalary = new List<EmployeeAdvanceSalaryR>();
                employeeAdvanceSalary = employeeBenefitbll.getEmployeeWiseAdvanceSalaryList(OCODE);
                if (employeeAdvanceSalary.Count > 0)
                {
                    grdemployees.DataSource = employeeAdvanceSalary;
                    grdemployees.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }


        }

        protected void imgEmployeeAdvanceSalry_Click(object sender, EventArgs e)
        {
            try
            {

                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

                try
                {
                    string lblAdvanceSalaryId = "";
                    string AdCode = "";

                    Label lblAdvanceSalaryCode = (Label)grdemployees.Rows[row.RowIndex].FindControl("lblAdvanceSalaryId");
                    Label lblAdCode = (Label)grdemployees.Rows[row.RowIndex].FindControl("lblAdCode");
                    if (lblAdvanceSalaryCode != null && lblAdCode != null)
                    {
                        lblAdvanceSalaryId = lblAdvanceSalaryCode.Text;
                        AdCode = lblAdCode.Text;
                        Session["employeeAdvanceSalaryId"] = lblAdvanceSalaryId;
                        Session["eAdcode"] = AdCode;
                        Response.Redirect("EmployeeAdvanceSalary.aspx");
                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
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
            getEmployeeWiseAdvanceSalaryList();
        }
    }
}