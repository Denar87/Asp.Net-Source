using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using AjaxControlToolkit;
using ERPSSL.HRM.DAL;
using ERPSSL;
using ERPSSL.PAYROLL.DAL.Repository;
using Microsoft.Reporting.WebForms;

namespace ERPSSL.PAYROLL
{
    public partial class BankAdvice : System.Web.UI.Page
    {
        EMPOYEE_BLL objEmp_BLL = new EMPOYEE_BLL();
        ERPSSLHBEntities context = new ERPSSLHBEntities();
        Attendance_BLL objAtt_BLL = new Attendance_BLL();
        Increment_BLL objIncrementBll = new Increment_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    FillRegion();
                    txtDateFrom.Text = DateTime.Today.ToShortDateString();
                    //txtDateFrom.Text = DateTime.Today.ToShortDateString();
                    //txtDateTo.Text = DateTime.Today.ToShortDateString();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void BindGridForBankAdvice()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;


                List<BankAdviceRe> Bank1 = new List<BankAdviceRe>();


                if (drpDepartment.SelectedValue != " " && txtDateFrom.Text != "" && txtEid_TRNS.Text == "")
                {
                    string FormDate = txtDateFrom.Text.ToString();
                    //DateTime Todate = Convert.ToDateTime(txtDateFrom.Text.ToString());
                    string dptId = drpDepartment.SelectedValue.ToString();
                    List<BankAdviceRe> Bank2 = new List<BankAdviceRe>();
                    Bank2 = objAtt_BLL.GetBankAdviceByDepartmentId(OCODE, dptId, FormDate).ToList();
                    if (Bank2.Count > 0)
                    {
                        GridViewEMP_AT.DataSource = Bank2.ToList();
                        GridViewEMP_AT.DataBind();

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);

                    }


                }
                else if (txtDateFrom.Text != "" && txtEid_TRNS.Text != "")
                {
                    string eid = txtEid_TRNS.Text.ToString();
                    string FormDate = txtDateFrom.Text.ToString();
                    //DateTime Todate = Convert.ToDateTime(txtDateFrom.Text.ToString());
                    List<BankAdviceRe> Bank3 = new List<BankAdviceRe>();
                    Bank3 = objAtt_BLL.GetBankAdviceByEid(OCODE, eid, FormDate).ToList();
                    if (Bank3.Count > 0)
                    {
                        GridViewEMP_AT.DataSource = Bank3.ToList();
                        GridViewEMP_AT.DataBind();

                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Item !')", true);
                    //Bank1 = objAtt_BLL.GetBankAdviceAll(OCODE).ToList();
                    //if (Bank1.Count > 0)
                    //{
                    //    GridViewEMP_AT.DataSource = Bank1.ToList();
                    //    GridViewEMP_AT.DataBind();

                    //}
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void FillRegion()
        {

            try
            {
                string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                var row = objIncrementBll.GetAllRegion(OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlRegion.DataSource = row.ToList();
                    ddlRegion.DataTextField = "RegionName";
                    ddlRegion.DataValueField = "RegionID";
                    ddlRegion.DataBind();
                    ddlRegion.Items.Insert(0, new ListItem("---Select One---", "0"));
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            int RegionId = Convert.ToInt32(ddlRegion.SelectedValue);
            FillOffice(RegionId);
        }
        private void FillOffice(int RegionId)
        {
            try
            {
                var row = objIncrementBll.GetOfficeByResionId(RegionId).ToList();
                if (row.Count > 0)
                {
                    ddlOffice.DataSource = row.ToList();
                    ddlOffice.DataTextField = "OfficeName";
                    ddlOffice.DataValueField = "OfficeID";
                    ddlOffice.DataBind();
                    ddlOffice.Items.Insert(0, new ListItem("---Select One---", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void ddlOffice_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadDepartment();

        }
        private void LoadDepartment()
        {
            try
            {
                int officeID = Convert.ToInt16(ddlOffice.SelectedValue);
                var row = objIncrementBll.GetDepartmentByOfficeId(officeID).ToList();
                if (row.Count > 0)
                {
                    drpDepartment.DataSource = row.ToList();
                    drpDepartment.DataTextField = "DPT_NAME";
                    drpDepartment.DataValueField = "DPT_ID";
                    drpDepartment.DataBind();
                    drpDepartment.Items.Insert(0, new ListItem("---Select One---", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            BindGridForBankAdvice();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

            if (drpDepartment.SelectedValue != "0" && txtDateFrom.Text != "" && txtEid_TRNS.Text == "")
            {
                string dptId = drpDepartment.SelectedValue.ToString();
                string FormDate = txtDateFrom.Text.ToString();
                List<BankAdviceRe> Bank2 = new List<BankAdviceRe>();
                Bank2 = objAtt_BLL.GetBankAdviceByDepartmentId(OCODE, dptId, FormDate).ToList();
                if (Bank2.Count > 0)
                {
                    Session["rptDs"] = "HRM_BankAdviceAllListDS";
                    Session["rptDt"] = Bank2;
                    Session["rptFile"] = "/PAYROLL/reports/HRM_BankAdviceByDptId.rdlc";
                    Session["rptTitle"] = " ";
                    Response.Redirect("Report_Viewer.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);

                }

            }

            else if (txtEid_TRNS.Text != "")
            {
                string eid = txtEid_TRNS.Text.ToString();
                string FormDate = txtDateFrom.Text.ToString();
                //DateTime Todate = Convert.ToDateTime(txtDateFrom.Text.ToString());
                List<BankAdviceRe> Bank3 = new List<BankAdviceRe>();
                Bank3 = objAtt_BLL.GetBankAdviceByEid(OCODE, eid, FormDate).ToList();
                if (Bank3.Count > 0)
                {
                    Session["rptDs"] = "HRM_BankAdviceAllListDS";
                    Session["rptDt"] = Bank3;
                    Session["rptFile"] = "/PAYROLL/reports/HRM_BankAdviceByEid.rdlc";
                    Session["rptTitle"] = " ";
                    Response.Redirect("Report_Viewer.aspx");

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);

                }

            }
            else
            {

                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);

                //List<BankAdviceRe> Bank1 = new List<BankAdviceRe>();
                //Bank1 = objAtt_BLL.GetBankAdviceAll(OCODE).ToList();
                //if (Bank1.Count > 0)
                //{
                //    Session["rptDs"] = "HRM_BankAdviceAllListDS";
                //    Session["rptDt"] = Bank1;
                //    Session["rptFile"] = "/PAYROLL/reports/HRM_BankAdviceAll.rdlc";
                //    Session["rptTitle"] = " ";
                //    Response.Redirect("Report_Viewer.aspx");


                //ReportViewerBankAdvice.LocalReport.DataSources.Clear();
                //ReportDataSource reportDataset = new ReportDataSource("HRM_BankAdviceAllListDS", Bank1);
                //ReportViewerBankAdvice.LocalReport.DataSources.Add(reportDataset);
                //ReportViewerBankAdvice.LocalReport.ReportPath = Server.MapPath("reports/HRM_BankAdviceAll.rdlc");
                //ReportViewerBankAdvice.LocalReport.Refresh();

                //}
            }



        }

        protected void GridViewEMP_AT_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewEMP_AT.PageIndex = e.NewPageIndex;
            BindGridForBankAdvice();
        }

        protected void txtDateFrom_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        protected void txtDateTo_TextChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }
        protected void txtEid_TRNS_TextChanged(object sender, EventArgs e)
        {
            if (txtEid_TRNS.Text != "")
            {
                try
                {
                    string id = txtEid_TRNS.Text;
                    employeeDetails(id);

                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                }
            }
            else
            {

            }

        }

        public void employeeDetails(string id)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string employeeID = Convert.ToString(id);

                var result = objEmp_BLL.GetEmployeeDetailsIDCard(employeeID, OCODE).ToList();
                if (result.Count > 0)
                {
                    // Emp_IMG_TRNS.Visible = true;
                    //  Emp_IMG_TRNS.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;
                    var objNewEmp = result.First();
                    txtEid_TRNS.Text = Convert.ToString(objNewEmp.EID);
                    txtEmpName_TRNS.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                    txtDepartment.Text = objNewEmp.DPT_NAME;
                    txtDesignation.Text = objNewEmp.DEG_NAME;
                }
                else
                {

                    //  Emp_IMG_TRNS.Visible = false;
                    txtEid_TRNS.Text = "";
                    txtEmpName_TRNS.Text = "";
                    txtDepartment.Text = "";
                    txtDesignation.Text = "";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('This Employee is Inactive!')", true);

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }
    }
}