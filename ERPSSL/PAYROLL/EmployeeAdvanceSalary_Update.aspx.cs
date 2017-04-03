using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.DAL;

namespace ERPSSL.PAYROLL
{
    public partial class EmployeeAdvanceSalary_Update : System.Web.UI.Page
    {
        EmployeeBenefitBLL employeeBenefitbll = new EmployeeBenefitBLL();
        AdvanceSalaryBLL aAdvanceSalaryBLL = new AdvanceSalaryBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //Load Month
                //for (int j = 1; j <= 12; j++)
                //{
                //    DateTime date = new DateTime(1900, j, 1);
                //    ddlMonthList.Items.Add(new ListItem(date.ToString("MMMM"), j.ToString()));
                //}
                //ddlMonthList.SelectedValue = DateTime.Today.Month.ToString();
                LoadMonth();

                //load 30 year
                int i = DateTime.Now.Year;
                for (i = i - 1; i <= DateTime.Now.Year + 30; i++)
                    ddlYearList.Items.Add(Convert.ToString(i));

                // getEmployeeWiseAdvanceSalaryList();
            }
        }

        private void LoadMonth()
        {
            ddlMonthList.Items.Add(new ListItem("Select", 0.ToString()));
            var months = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            for (int i = 0; i < months.Length - 1; i++)
            {
                ddlMonthList.Items.Add(new ListItem(months[i], (i + 1).ToString()));
            }
            ddlMonthList.SelectedItem.Text = "";
            ddlMonthList.SelectedValue = "";
        }

        private void getEmployeeWiseAdvanceSalaryList()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<EmployeeAdvanceSalaryR> employeeAdvanceSalary = new List<EmployeeAdvanceSalaryR>();
                employeeAdvanceSalary = employeeBenefitbll.GetAdvanceSalaryDetailsListByEID(txtEID.Text, Convert.ToInt16(ddlMonthList.SelectedValue), ddlYearList.SelectedValue, OCODE);
                if (employeeAdvanceSalary.Count > 0)
                {
                    grdemployees.DataSource = employeeAdvanceSalary;
                    grdemployees.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                    grdemployees.DataSource = null;
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

            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string detailsId = "";
                Label lblAdvanceSalaryDetailsId = (Label)grdemployees.Rows[row.RowIndex].FindControl("lblAdvanceSalaryDetailsId");
                if (lblAdvanceSalaryDetailsId != null)
                {
                    string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                    detailsId = lblAdvanceSalaryDetailsId.Text;

                    List<HRM_AdvanceSalaryDetails> lstHRM_AdvanceSalaryDetails = new List<HRM_AdvanceSalaryDetails>();
                    lstHRM_AdvanceSalaryDetails = employeeBenefitbll.GetAllAdvanceSalaryDetails(OCODE, detailsId);

                    if (lstHRM_AdvanceSalaryDetails.Count > 0)
                    {
                        foreach (HRM_AdvanceSalaryDetails aHRM_AdvanceSalaryDetails in lstHRM_AdvanceSalaryDetails)
                        {
                            hidAdDetailsId.Value = aHRM_AdvanceSalaryDetails.AdvanceSalaryDetailsId.ToString();
                            txtEID.Text = aHRM_AdvanceSalaryDetails.EID;
                            ddlMonthList.SelectedValue = aHRM_AdvanceSalaryDetails.Month.ToString();
                            ddlYearList.SelectedValue = aHRM_AdvanceSalaryDetails.Year.ToString();

                            hdfPayCode.Value = aHRM_AdvanceSalaryDetails.ASCode.ToString();
                            hdfMonth.Value = aHRM_AdvanceSalaryDetails.Month.ToString();
                            hdfYear.Value = aHRM_AdvanceSalaryDetails.Year.ToString();
                        }
                    }
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            getEmployeeWiseAdvanceSalaryList();
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                int detailId = Convert.ToInt32(hidAdDetailsId.Value);

                //insert previous log
                HRM_AdvanceSalaryDetailPrevious_Log aHRM_AdvanceSalaryDetailsLog = new HRM_AdvanceSalaryDetailPrevious_Log();

                aHRM_AdvanceSalaryDetailsLog.AdvanceSalaryDetailsId = detailId;
                aHRM_AdvanceSalaryDetailsLog.ASCode = hdfPayCode.Value;
                aHRM_AdvanceSalaryDetailsLog.EID = txtEID.Text;
                aHRM_AdvanceSalaryDetailsLog.Month = Convert.ToInt16(hdfMonth.Value);
                aHRM_AdvanceSalaryDetailsLog.Year = Convert.ToInt16(hdfYear.Value);
                aHRM_AdvanceSalaryDetailsLog.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                aHRM_AdvanceSalaryDetailsLog.EDIT_DATE = DateTime.Now;
                aHRM_AdvanceSalaryDetailsLog.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                aAdvanceSalaryBLL.InsertAdvanceSalaryDetailsLog(aHRM_AdvanceSalaryDetailsLog);

                // update advance pay time
                HRM_AdvanceSalaryDetails aHRM_AdvanceSalaryDetails = new HRM_AdvanceSalaryDetails();

                aHRM_AdvanceSalaryDetails.Month = Convert.ToInt16(ddlMonthList.SelectedValue);
                aHRM_AdvanceSalaryDetails.Year = Convert.ToInt16(ddlYearList.SelectedValue);
                aHRM_AdvanceSalaryDetails.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                aHRM_AdvanceSalaryDetails.EDIT_DATE = DateTime.Now;
                aHRM_AdvanceSalaryDetails.OCODE = ((SessionUser)Session["SessionUser"]).OCode;


                int result = aAdvanceSalaryBLL.Update_AdvanceSalaryDetails(aHRM_AdvanceSalaryDetails, detailId);
                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                    getEmployeeWiseAdvanceSalaryList();

                    txtEID.Text = "";
                    ddlMonthList.ClearSelection();
                    ddlYearList.ClearSelection();
                    hdfMonth.Value = "";
                    hdfYear.Value = "";
                    hidAdDetailsId.Value = "";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


    }
}