using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.PAYROLL.BLL;
using ERPSSL.HRM.BLL;
using AjaxControlToolkit;
using ERPSSL.HRM.DAL;
using ERPSSL;
using ERPSSL.HRM.DAL.Repository;
using Microsoft.Reporting.WebForms;

namespace ERPSSL.PAYROLL
{
    public partial class PaySlip : System.Web.UI.Page
    {
        Salary_Proccess_BLL aSalary_Proccess_BLL = new Salary_Proccess_BLL();
        AttendanceReason_BLL objAttendanceReasonBll = new AttendanceReason_BLL();
        Office_BLL objOfficeBLL = new Office_BLL();
        EMPOYEE_BLL employeeBllObj = new EMPOYEE_BLL();
        SECTION_BLL SectionBll = new SECTION_BLL();
        SUB_SECTION_BLL subSectionBll = new SUB_SECTION_BLL();
        SUB_SECTION_DAL subSectionDal = new SUB_SECTION_DAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                try
                {
                    if (!IsPostBack)
                    {
                        ChekedLoadAll();
                        GerRegion1List();
                    }
                }
                catch
                {

                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GerRegion1List()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objOfficeBLL.GetAllResion(OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlRegion1.DataSource = row.ToList();
                    ddlRegion1.DataTextField = "RegionName";
                    ddlRegion1.DataValueField = "RegionID";
                    ddlRegion1.DataBind();
                    ddlRegion1.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void drpdwnResion1ForDepartmentSelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                BridOfficeByResion1(ResionId);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void BridOfficeByResion1(int ResionId)
        {
            try
            {
                var row = objOfficeBLL.GetOfficeByResionId(ResionId).ToList();
                if (row.Count > 0)
                {
                    ddlOffice1.DataSource = row.ToList();
                    ddlOffice1.DataTextField = "OfficeName";
                    ddlOffice1.DataValueField = "OfficeID";
                    ddlOffice1.DataBind();
                    ddlOffice1.Items.Insert(0, new ListItem("--Select--"));
                }
                else
                {
                    ddlOffice1.DataSource = null;
                    ddlOffice1.DataTextField = "OfficeName";
                    ddlOffice1.DataValueField = "OfficeID";
                    ddlOffice1.DataBind();
                    ddlOffice1.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void onSelectedIndedexChangeOffice1(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);

                var row = objOfficeBLL.GetDeptByOfficeId(ResionId, OfficeId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlDept1.DataSource = row.ToList();
                    ddlDept1.DataTextField = "DPT_NAME";
                    ddlDept1.DataValueField = "DPT_ID";
                    ddlDept1.DataBind();
                    ddlDept1.Items.Insert(0, new ListItem("--Select--"));
                }
                else
                {
                    ddlDept1.DataSource = null;
                    ddlDept1.DataTextField = "DPT_NAME";
                    ddlDept1.DataValueField = "DPT_ID";
                    ddlDept1.DataBind();
                    ddlDept1.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void drpdwnDepartment1SelectedIndexChange(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int departmentId = Convert.ToInt16(ddlDept1.SelectedValue);
                var row = SectionBll.GetSectionsByDepartmentIdAndOCode(departmentId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlSection.DataSource = row;
                    ddlSection.DataTextField = "SEC_NAME";
                    ddlSection.DataValueField = "SEC_ID";
                    ddlSection.DataBind();
                    ddlSection.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlSection_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int sectionId = Convert.ToInt16(ddlSection.SelectedValue);
                var row = subSectionBll.GetSubSectionsBySectionIdAndOCode(sectionId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlSubSections.DataSource = row;
                    ddlSubSections.DataTextField = "SUB_SEC_NAME";
                    ddlSubSections.DataValueField = "SUB_SEC_ID";
                    ddlSubSections.DataBind();
                    ddlSubSections.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ChekedLoadAll()
        {
            if (rdbAll.Checked)
            {
                //Label1.Visible = false;
                //txtEid_AT.Visible = false;
                //Label2.Visible = false;
                //Label3.Visible = false;
                //Label4.Visible = false;
                //txtEmpName_AT.Visible = false;
                //txtDepartment_AT.Visible = false;
                //txtDesignation_AT.Visible = false;
            }
        }

        protected void txtEid_AT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string employeeID = Convert.ToString(txtEid_AT.Text);
                var result = objAttendanceReasonBll.GetEmployeeDetailsID(employeeID, OCODE).ToList();
                if (result.Count > 0)
                {
                    var objNewEmp = result.First();
                    txtEid_AT.Text = Convert.ToString(objNewEmp.EID);
                    txtEmpName_AT.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                    //lblHiddenId.Text = Convert.ToString(objNewEmp.EMP_ID);
                    txtDepartment_AT.Text = objNewEmp.DPT_NAME;
                    txtDesignation_AT.Text = objNewEmp.DEG_NAME;
                    //lblShiftCode.Text = objNewEmp.SHIFTCODE;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                    //lblMessege.Text = "NO RECORDS FOUND.";
                    //lblMessege.ForeColor = System.Drawing.Color.Green;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime date = Convert.ToDateTime(txtbxFrom.Text);

                //int result = aSalary_Proccess_BLL.DividedParySalaryInfo(date);

                List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                string fromdate = txtbxFrom.Text;

                if (rdbIndividual.Checked)
                {
                    string empId = txtEid_AT.Text;
                    empsalaryList = aSalary_Proccess_BLL.GetIndividualPaySlip(fromdate, empId).ToList();
                    if (empsalaryList.Count > 0)
                    {
                        ReportViewer1.LocalReport.DataSources.Clear();
                        var reportDataset = new ReportDataSource("HRMRptGetSalaryInfoDS", empsalaryList);
                        ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/PAYROLL/reports/HRM_Get_PaySlipAllRPT_Compliance_Bangla.rdlc");
                        ReportViewer1.LocalReport.Refresh();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                    }
                }
                else if (rdbAll.Checked)
                {
                    if (txtbxFrom.Text != "" && ddlRegion1.SelectedItem.Text == "--Select--")//&& ddlDept1.SelectedItem.Text == "--Select--" && ddlOffice1.SelectedItem.Text == "--Select--" && ddlRegion1.SelectedItem.Text == "--Select--" && ddlSection.SelectedItem.Text == "--Select--" && ddlSubSections.SelectedItem.Text == "--Select--")
                    {
                        List<Salary_Viewer> empsalaryList1 = new List<Salary_Viewer>();

                        empsalaryList1 = aSalary_Proccess_BLL.GetAllPaySlip(fromdate).ToList();

                        if (empsalaryList1.Count > 0)
                        {
                            ReportViewer1.LocalReport.DataSources.Clear();
                            var reportDataset1 = new ReportDataSource("HRMRptGetSalaryInfoDS", empsalaryList1);

                            ReportViewer1.LocalReport.DataSources.Add(reportDataset1);
                            ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/PAYROLL/reports/HRM_Get_PaySlipAllRPT_Compliance_Bangla.rdlc");
                            ReportViewer1.LocalReport.Refresh();
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                        }
                    }
                    else
                    {
                        //Sub section wise
                        if (txtbxFrom.Text != "" && ddlDept1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlRegion1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        { 
                            List<Salary_Viewer> empsalaryList1 = new List<Salary_Viewer>();

                            int department = Convert.ToInt32(ddlDept1.SelectedValue);
                            int region = Convert.ToInt32(ddlRegion1.SelectedValue);
                            int office = Convert.ToInt32(ddlOffice1.SelectedValue);
                            int section = Convert.ToInt32(ddlSection.SelectedValue);
                            int subsection = Convert.ToInt32(ddlSubSections.SelectedValue);

                            empsalaryList1 = aSalary_Proccess_BLL.GetAllPaySlipBySubsection(department, fromdate, region, office, section, subsection).ToList();

                            if (empsalaryList1.Count > 0)
                            {
                                ReportViewer1.LocalReport.DataSources.Clear();
                                var reportDataset1 = new ReportDataSource("HRMRptGetSalaryInfoDS", empsalaryList1);

                                ReportViewer1.LocalReport.DataSources.Add(reportDataset1);
                                ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/PAYROLL/reports/HRM_Get_PaySlipAllRPT_Compliance_Bangla.rdlc");
                                ReportViewer1.LocalReport.Refresh();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                            }
                        }
                    }

                    //List<Salary_Viewer> empsalaryList1 = new List<Salary_Viewer>();
                    //List<Salary_Viewer> empsalaryList2 = new List<Salary_Viewer>();
                    //empsalaryList1 = aSalary_Proccess_BLL.GetAllPaySlip1(fromdate).ToList();
                    //empsalaryList2 = aSalary_Proccess_BLL.GetAllPaySlip2(fromdate).ToList();
                    //if (empsalaryList1.Count > 0)
                    //{
                    //    ReportViewer1.LocalReport.DataSources.Clear();
                    //    var reportDataset1 = new ReportDataSource("HRMRptGetSalaryInfoDS", empsalaryList1);
                    //    var reportDataset2 = new ReportDataSource("DS_HRM_PaySalary2", empsalaryList2);

                    //    ReportViewer1.LocalReport.DataSources.Add(reportDataset1);
                    //    ReportViewer1.LocalReport.DataSources.Add(reportDataset2);
                    //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("~/PAYROLL/reports/HRM_Get_PaySlipAllRPT.rdlc");
                    //    ReportViewer1.LocalReport.Refresh();
                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                    //}
                }

                //int result1 = aSalary_Proccess_BLL.truncateTableHRM_PaySalary();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

    }
}