using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.HRM;

namespace ERPSSL.HRM
{
    public partial class Report : System.Web.UI.Page
    {
        EmployeeSetup_BLL objEmp_BLL = new EmployeeSetup_BLL();
        DEPARTMENT_BLL DepartmentBll = new DEPARTMENT_BLL();
        EmployeeSetup_BLL employeeBll = new EmployeeSetup_BLL();
        Office_BLL objOfficeBLL = new Office_BLL();
        EMPOYEE_BLL employeeBllObj = new EMPOYEE_BLL();
        Attendance_RPT_Bll aAttendance_RPT_Bll = new Attendance_RPT_Bll();
        TIME_SCHEDULE_BLL timeScheduleBll = new TIME_SCHEDULE_BLL();



        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    //  txtbxFrom.Text = DateTime.Today.ToShortDateString();
                    //  txtbxTo.Text = DateTime.Today.ToShortDateString();
                    GerRegionList();
                    GetDesignation();
                    //GerRegion1List();
                    GerRegion2List();
                    //  GetDept();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }



        private void GetDept()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                List<string> row = objOfficeBLL.GetAllDept(OCODE).ToList();

                if (row.Count > 0)
                {
                    depDepartment.DataSource = row;
                    //depDepartment.DataTextField = "DPT_NAME";
                    //depDepartment.DataValueField = "DPT_NAME";
                    depDepartment.DataBind();
                    depDepartment.Items.Insert(0, new ListItem("--Select--"));
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void GetDesignation()
        {
            try
            {

                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objOfficeBLL.GetAllDesignation(OCODE).ToList();
                if (row.Count > 0)
                {
                    ddldesignation.DataSource = row.ToList();
                    ddldesignation.DataTextField = "DEG_NAME";
                    ddldesignation.DataValueField = "DEG_NAME";
                    ddldesignation.DataBind();
                    ddldesignation.Items.Insert(0, new ListItem("--Select--"));
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void drpdwnResionForDepartmentSelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                BridOfficeByResion(ResionId);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        private void BridOfficeByResion(int ResionId)
        {
            try
            {
                var row = objOfficeBLL.GetOfficeByResionId(ResionId).ToList();
                if (row.Count > 0)
                {
                    drpOffice.DataSource = row.ToList();
                    drpOffice.DataTextField = "OfficeName";
                    drpOffice.DataValueField = "OfficeID";
                    drpOffice.DataBind();
                    drpOffice.Items.Insert(0, new ListItem("--Select--"));
                }
                else
                {
                    drpOffice.DataSource = null;
                    drpOffice.DataTextField = "OfficeName";
                    drpOffice.DataValueField = "OfficeID";
                    drpOffice.DataBind();
                    drpOffice.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void GerRegionList()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objOfficeBLL.GetAllResion(OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlRegions.DataSource = row.ToList();
                    ddlRegions.DataTextField = "RegionName";
                    ddlRegions.DataValueField = "RegionID";
                    ddlRegions.DataBind();
                    ddlRegions.Items.Insert(0, new ListItem("--Select--"));
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void onSelectedIndedexChangeOffice(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                var row = objOfficeBLL.GetOfficeByResionId(ResionId, OfficeId, OCODE).ToList();
                if (row.Count > 0)
                {
                    depDepartment.DataSource = row.ToList();
                    depDepartment.DataTextField = "DPT_NAME";
                    depDepartment.DataValueField = "DPT_ID";
                    depDepartment.DataBind();
                    depDepartment.Items.Insert(0, new ListItem("--Select--"));
                }
                else
                {
                    depDepartment.DataSource = null;
                    depDepartment.DataTextField = "DPT_NAME";
                    depDepartment.DataValueField = "DPT_ID";
                    depDepartment.DataBind();
                    depDepartment.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void drpdwnDepartmentSelectedIndexChange(object sender, EventArgs e)
        {
            //List<REmployee> employees = new List<REmployee>();
            //string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            //int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
            //int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
            //int departmentID = Convert.ToInt32(depDepartment.SelectedValue);
            //employees = objOfficeBLL.GetEmployeeListForDepartment(ResionId, OfficeId, departmentID, OCODE).ToList();
            //if (employees.Count > 0)
            //{
            //    Session["rptDs"] = "hrm_employeeforDepartment";
            //    Session["rptDt"] = employees;
            //    Session["rptFile"] = "/HRM/reports/HRM_EmployeeForDepartment.rdlc";
            //    Session["rptTitle"] = "Department Wise";
            //    Response.Redirect("Report_Viewer.aspx");

            //}

            try
            {
                SECTION_BLL SectionBll = new SECTION_BLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int departmentId = Convert.ToInt16(depDepartment.SelectedValue);
                var row = SectionBll.GetSectionsByDepartmentIdAndOCode(departmentId, OCODE).ToList();
                if (row.Count > 0)
                {
                    drpSection.DataSource = row;
                    drpSection.DataTextField = "SEC_NAME";
                    drpSection.DataValueField = "SEC_ID";
                    drpSection.DataBind();
                    drpSection.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtEid_AT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string employeeID = Convert.ToString(txtEid_AT.Text);
                //Emp_IMG_AT.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;

                var result = objEmp_BLL.GetEmployeeDetailsForAttendece(employeeID, OCODE).ToList();
                if (result.Count > 0)
                {
                    var objNewEmp = result.First();
                    txtEid_AT.Text = Convert.ToString(objNewEmp.EID);
                    txtEmpName_AT.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                    lblHiddenId.Text = Convert.ToString(objNewEmp.EMP_ID);
                    txtDepartment_AT.Text = objNewEmp.DPT_NAME;
                    txtDesignation_AT.Text = objNewEmp.DEG_NAME;
                }
                else
                {
                    //NO RECORDS FOUND.
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
                //SYED Maftahur Rahman SOHEL . Starting Work 3 December 2015

                //Salary Range Wise Report 
                List<REmployee> employees = new List<REmployee>();
                if (txtSalaryFrom.Text != "" && txtSalaryTo.Text != "")
                {

                    string FromSalary = txtSalaryFrom.Text;
                    string ToSalary = txtSalaryTo.Text;
                    employees = employeeBll.GetSalaryRangeReport(FromSalary, ToSalary).ToList();
                    if (employees.Count > 0)
                    {
                        Session["rptDs"] = "HRM_EmployeeSalaryRangeDS";
                        Session["rptDt"] = employees;
                        Session["rptFile"] = "/HRM/reports/HRM_RPT_EmployeeSalaryRange.rdlc";
                        Session["rptTitle"] = "Salary Range Report";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }
                else
                {
                    //All Employee Report 
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    string gender;
                    if (rdAllEmployee.Checked)
                    {
                        employees = employeeBll.GetAllEmployeForReport(OCODE).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "ds_allEmployee";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/HRM_AllEmployee.rdlc";
                            Session["rptTitle"] = "All Employee";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }


                    //Management Employee Report 
                    else if (rdManagement.Checked)
                    {
                        string Type = "Management";
                        employees = employeeBll.GetAllMannagementEmpReport(OCODE, Type).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "HRM_EmployeeAllManagement";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/HRM_EmployeeAllManagement.rdlc";
                            Session["rptTitle"] = "All Management Employee";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }
                    else if (rdNonManagement.Checked)
                    {
                        string Type = "Non-Management";
                        employees = employeeBll.GetAllMannagementEmpReport(OCODE, Type).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "HRM_EmployeeAllManagement";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/HRM_EmployeeAllNonManagement.rdlc";
                            Session["rptTitle"] = "All Non Management Employee";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }


                    else if (rdCurrentEmoloyee.Checked)
                    {
                        employees = employeeBll.GetAllCurrentForReport(OCODE).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "hrm_CurrentEmployee";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/HRM_CurrentEmployee.rdlc";
                            Session["rptTitle"] = "Current Employee";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }

                    else if (rdEmployee.Checked)
                    {

                        if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text == "--Select--")
                        {
                            int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            employees = objOfficeBLL.GetEmployeeListForRegion(ResionId, OCODE).ToList();
                            if (employees.Count > 0)
                            {
                                Session["rptDs"] = "hrm_employeeforRegionDS";
                                Session["rptDt"] = employees;
                                Session["rptFile"] = "/HRM/reports/HRM_EmployeeForRegion.rdlc";
                                Session["rptTitle"] = "Region Wise";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                            }
                        }
                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text == "--Select--")
                        {

                            int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            employees = objOfficeBLL.GetEmployeeListForOffice(ResionId, OfficeId, OCODE).ToList();
                            if (employees.Count > 0)
                            {
                                Session["rptDs"] = "EmployeeListForOfficeDS";
                                Session["rptDt"] = employees;
                                Session["rptFile"] = "/HRM/reports/HRM_EmployeeForOffice.rdlc";
                                Session["rptTitle"] = "Office Wise";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                            }

                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && drpSection.SelectedItem.Text == "--Select--")
                        {

                            if (depDepartment.SelectedItem.Text == "--Select--")
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select a department!')", true);
                                return;
                            }
                            string Dept = depDepartment.SelectedItem.Text;
                            employees = objOfficeBLL.GetEmployeeListForDepartmentwise(Dept).ToList();
                            if (employees.Count > 0)
                            {
                                Session["rptDs"] = "hrm_employeeforDepartment";
                                Session["rptDt"] = employees;
                                Session["rptFile"] = "/HRM/reports/HRM_EmployeeForDepartment.rdlc";
                                Session["rptTitle"] = "Department Wise";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }

                        }
                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && drpSection.SelectedItem.Text != "--Select--")
                        {

                            if (depDepartment.SelectedItem.Text == "--Select--")
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select a department!')", true);
                                return;
                            }
                            string Dept = depDepartment.SelectedItem.Text;
                            employees = objOfficeBLL.GetEmployeeListForDepartmentwise(Dept).ToList();
                            if (employees.Count > 0)
                            {
                                Session["rptDs"] = "hrm_employeeforDepartment";
                                Session["rptDt"] = employees;
                                Session["rptFile"] = "/HRM/reports/HRM_EmployeeForDepartment.rdlc";
                                Session["rptTitle"] = "Department Wise";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }

                        }
                        else
                        {

                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Information For Search!')", true);

                        }
                    }

                    else if (rdCurrentEmoloyeeShiftwise.Checked)
                    {
                        int region = Convert.ToInt16(ddlRegions.SelectedValue);
                        employees = employeeBll.GetAllCurrentEmoployeeShiftWise(OCODE, region).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "hrm_CurrentEmployee";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/HRM_CurrentEmployeeShiftwise.rdlc";
                            Session["rptTitle"] = "Current Employee Shift Wise";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }
                    else if (rdTransferEmployee.Checked)
                    {
                        employees = employeeBll.GetAllTransferEmployeeForReport(OCODE).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "hrmTransferEmployee";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/HRM_TransferEmployee.rdlc";
                            Session["rptTitle"] = "Transfer Employee";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }
                    //separated employee list
                    else if (rdSeperationEmployee.Checked)
                    {
                        if (txtDateFrom.Text != "" && txtbxToDate.Text != "")
                        {
                            employees = employeeBll.GetEmployeeSeparationByDate(txtDateFrom.Text, txtbxToDate.Text, OCODE).ToList();
                            if (employees.Count > 0)
                            {
                                Session["rptDs"] = "DS_SeparatedEmployee";
                                Session["rptDt"] = employees;
                                Session["rptFile"] = "/HRM/reports/HRM_SeparatedEmployeeByDate.rdlc";
                                Session["rptTitle"] = "Separated Employee";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else
                        {
                            employees = employeeBll.GetEmployeeSeparation(OCODE).ToList();
                            if (employees.Count > 0)
                            {
                                Session["rptDs"] = "DS_SeparatedEmployee";
                                Session["rptDt"] = employees;
                                Session["rptFile"] = "/HRM/reports/HRM_SeparatedEmployee.rdlc";
                                Session["rptTitle"] = "Separated Employee";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                    }
                    else if (rdTerminatedEmployee.Checked)
                    {
                        if (txtDateFrom.Text != "" && txtbxToDate.Text != "")
                        {
                            employees = employeeBll.GetAllTerminatedrEmployeeForReport_byDate(txtDateFrom.Text, txtbxToDate.Text, OCODE).ToList();
                            if (employees.Count > 0)
                            {
                                Session["rptDs"] = "hrm_terminatedEmployee";
                                Session["rptDt"] = employees;
                                Session["rptFile"] = "/HRM/reports/HRM_TerminatedEmployee_ByDate.rdlc";
                                Session["rptTitle"] = "Terminated Employee";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else
                        {
                            employees = employeeBll.GetAllTerminatedrEmployeeForReport(OCODE).ToList();
                            if (employees.Count > 0)
                            {
                                Session["rptDs"] = "hrm_terminatedEmployee";
                                Session["rptDt"] = employees;
                                Session["rptFile"] = "/HRM/reports/HRM_TerminatedEmployee.rdlc";
                                Session["rptTitle"] = "Terminated Employee";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                    }
                    //Retired Employee
                    else if (rdretired.Checked)
                    {
                        if (txtDateFrom.Text != "" && txtbxToDate.Text != "")
                        {
                            employees = employeeBll.GetAllRetireddrEmployeeForReport_ByDate(txtDateFrom.Text, txtbxToDate.Text, OCODE).ToList();
                            if (employees.Count > 0)
                            {
                                Session["rptDs"] = "hrm_retiredEmployee";
                                Session["rptDt"] = employees;
                                Session["rptFile"] = "/HRM/reports/HRM_RetiredEmployee_ByDate.rdlc";
                                Session["rptTitle"] = "Retired Employee";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else
                        {
                            employees = employeeBll.GetAllRetireddrEmployeeForReport(OCODE).ToList();
                            if (employees.Count > 0)
                            {
                                Session["rptDs"] = "hrm_retiredEmployee";
                                Session["rptDt"] = employees;
                                Session["rptFile"] = "/HRM/reports/HRM_RetiredEmployee.rdlc";
                                Session["rptTitle"] = "Retired Employee";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }


                    }
                    //Resigned Employee
                    else if (rdresignation.Checked)
                    {

                        if (txtDateFrom.Text != "" && txtbxToDate.Text != "")
                        {
                            employees = employeeBll.GetAllResignedEmployeeForReport_ByDate(txtDateFrom.Text, txtbxToDate.Text, OCODE).ToList();
                            if (employees.Count > 0)
                            {
                                Session["rptDs"] = "hrm_resignedEmployee";
                                Session["rptDt"] = employees;
                                Session["rptFile"] = "/HRM/reports/HRM_ResignedEmployee_ByDate.rdlc";
                                Session["rptTitle"] = "Retired Employee";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else
                        {
                            employees = employeeBll.GetAllResignedEmployeeForReport(OCODE).ToList();
                            if (employees.Count > 0)
                            {
                                Session["rptDs"] = "hrm_resignedEmployee";
                                Session["rptDt"] = employees;
                                Session["rptFile"] = "/HRM/reports/HRM_ResignedEmployee.rdlc";
                                Session["rptTitle"] = "Retired Employee";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                    }

                      //Dismissal Employee
                    else if (rdbEMPDismissalStatus.Checked)
                    {
                        if (txtDateFrom.Text != "" && txtbxToDate.Text != "")
                        {
                            employees = employeeBll.GetAllDismissalEmployeeForReport_ByDate(txtDateFrom.Text, txtbxToDate.Text, OCODE).ToList();
                            if (employees.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_DismissalEmployeeDS";
                                Session["rptDt"] = employees;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_DismissalEmployeePRT_ByDate.rdlc";
                                Session["rptTitle"] = "Dismissal Employee";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else
                        {
                            employees = employeeBll.GetAllDismissalEmployeeForReport(OCODE).ToList();
                            if (employees.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_DismissalEmployeeDS";
                                Session["rptDt"] = employees;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_DismissalEmployeePRT.rdlc";
                                Session["rptTitle"] = "Dismissal Employee";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                    }

                     //Died Employee
                    else if (rdbEMPDiedStatus.Checked)
                    {
                        if (txtDateFrom.Text != "" && txtbxToDate.Text != "")
                        {
                            employees = employeeBll.GetAllDiedEmployeeForReport_ByDate(txtDateFrom.Text, txtbxToDate.Text, OCODE).ToList();
                            if (employees.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_DiedEmployeeDS";
                                Session["rptDt"] = employees;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_DiedEmployeeRPT_ByDate.rdlc";
                                Session["rptTitle"] = "Died Employee";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }

                        }

                        else
                        {
                            employees = employeeBll.GetAllDiedEmployeeForReport(OCODE).ToList();
                            if (employees.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_DiedEmployeeDS";
                                Session["rptDt"] = employees;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_DiedEmployeeRPT.rdlc";
                                Session["rptTitle"] = "Died Employee";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }


                    }

                    //Discontinuous Employee
                    else if (rdbEMPDisContinutionStatus.Checked)
                    {
                        if (txtDateFrom.Text != "" && txtbxToDate.Text != "")
                        {
                            employees = employeeBll.GetAllDiscontinuousEmployeeForReport_ByDate(txtDateFrom.Text, txtbxToDate.Text, OCODE).ToList();
                            if (employees.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_DiscontiniousEmployeeDS";
                                Session["rptDt"] = employees;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_DiscontiniousEmployeeRPT_ByDate.rdlc";
                                Session["rptTitle"] = "Discontinious Employee";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else
                        {
                            employees = employeeBll.GetAllDiscontinuousEmployeeForReport(OCODE).ToList();
                            if (employees.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_DiscontiniousEmployeeDS";
                                Session["rptDt"] = employees;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_DiscontiniousEmployeeRPT.rdlc";
                                Session["rptTitle"] = "Discontinious Employee";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                    }
                    //Employee Other Employee
                    //else if (rdbEMPOther.Checked)
                    //{
                    //    employees = employeeBll.GetAllOtherEmployeeForReport(OCODE).ToList();
                    //    if (employees.Count > 0)
                    //    {
                    //        Session["rptDs"] = "HRM_RPT_OtherEmployeeDS";
                    //        Session["rptDt"] = employees;
                    //        Session["rptFile"] = "/HRM/reports/HRM_RPT_OtherEmployeeRPT.rdlc";
                    //        Session["rptTitle"] = "Other Employee";
                    //        Response.Redirect("Report_Viewer.aspx");
                    //    }

                    //}
                    //Employee length Of Services 
                    else if (rdbLenghtofservices.Checked)
                    {
                        employees = employeeBll.GetAllEmolyeeLenthOfServices(OCODE).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_LenthOFServicesDS";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_LenthOfService.rdlc";
                            Session["rptTitle"] = "Lenth Of Service Employee";
                            Response.Redirect("Report_Viewer.aspx");
                        }

                    }


                    //All Employee Retirement Report
                    else if (rdbRetredage.Checked)
                    {
                        employees = employeeBll.GetAllEmolyeeRetirementRPT(OCODE).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_EmployeeAgeOverRetieredmentDS";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_EmployeeRetirementOverAgeReport.rdlc";
                            Session["rptTitle"] = "Retired Employee";
                            Response.Redirect("Report_Viewer.aspx");
                        }

                    }



                    //Employee Retirement Report Region Wise
                    else if (rdbRetieredforRegion.Checked)
                    {
                        //int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);

                        employees = employeeBll.GetAllEmolyeeRetirementRPTforRegion(OCODE).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_EmployeeAgeOverRetieredmentDS";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_EmployeeRetirementOverAgeReportForRegion.rdlc";
                            Session["rptTitle"] = "Retired Employee";
                            Response.Redirect("Report_Viewer.aspx");
                        }

                    }
                    //Employee Retirement Report Office Wise
                    else if (rdbRetieredforOffice.Checked)
                    {
                        int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                        int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);

                        employees = employeeBll.GetAllEmolyeeRetirementRPTForOffice(OCODE, ResionId, OfficeId).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_EmployeeAgeOverRetieredmentDS";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_EmployeeRetirementOverAgeReportForOffice.rdlc";
                            Session["rptTitle"] = "Retired Employee";
                            Response.Redirect("Report_Viewer.aspx");
                        }

                    }
                    //Employee Retirement Report Dept. Wise
                    else if (rdbRetieredforDept.Checked)
                    {
                        int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                        int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                        int departmentID = Convert.ToInt32(depDepartment.SelectedValue);

                        employees = employeeBll.GetAllEmolyeeRetirementRPTForDept(OCODE, ResionId, OfficeId, departmentID).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_EmployeeAgeOverRetieredmentDS";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_EmployeeRetirementOverAgeReportForDept.rdlc";
                            Session["rptTitle"] = "Retired Employee";
                            Response.Redirect("Report_Viewer.aspx");
                        }

                    }
                    //
                    else if (rdlEmplyeeSalary.Checked)
                    {

                        if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && drpSection.SelectedItem.Text != "--Select--")
                        {
                            int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentID = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(drpSection.SelectedValue);

                            employees = employeeBll.GetAllEmolyeeSalaryByRODSID(OCODE, ResionId, OfficeId, departmentID, sectionId).ToList();
                            if (employees.Count > 0)
                            {
                                Session["rptDs"] = "HRM_EmployeeSalaryBYRODS";
                                Session["rptDt"] = employees;
                                Session["rptFile"] = "/HRM/reports/HRM_EmployeeSalaryDetailsByRODSID.rdlc";
                                Session["rptTitle"] = "Employee Salary";
                                Response.Redirect("Report_Viewer.aspx");
                            }

                            else
                            {

                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);

                            }
                        }
                        else
                        {

                            employees = employeeBll.GetAllEmolyeeSalaryALLByRODSID().ToList();
                            if (employees.Count > 0)
                            {
                                Session["rptDs"] = "HRM_EmployeeSalaryBYRODS";
                                Session["rptDt"] = employees;
                                Session["rptFile"] = "/HRM/reports/HRM_EmployeeSalaryALLDetailsByRODSID.rdlc";
                                Session["rptTitle"] = "Employee Salary";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                        }

                    }

                    //Employee Turn Over Report
                    else if (rdbTurnOveremp.Checked)
                    {
                        employees = employeeBll.GetAllTurnOverHistoryRPT(OCODE).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_EmployeeTurnOverReportDS";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_EmployeeTurnOverReport.rdlc";
                            Session["rptTitle"] = "Retired Employee";
                            Response.Redirect("Report_Viewer.aspx");
                        }

                    }




                    //else if (rdDeptWiseEmployee.Checked)
                    //{
                    //    int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                    //    int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                    //    int departmentID = Convert.ToInt32(depDepartment.SelectedValue);
                    //    employees = objOfficeBLL.GetEmployeeListForDepartment(ResionId, OfficeId, departmentID, OCODE).ToList();
                    //    if (employees.Count > 0)
                    //    {
                    //        Session["rptDs"] = "hrm_employeeforDepartment";
                    //        Session["rptDt"] = employees;
                    //        Session["rptFile"] = "/HRM/reports/HRM_EmployeeForDepartment.rdlc";
                    //        Session["rptTitle"] = "Department Wise";
                    //        Response.Redirect("Report_Viewer.aspx");
                    //    }
                    //}





                    //ALL Employee Blood Report
                    else if (rdbAllbloodGroup.Checked)
                    {

                        employees = objOfficeBLL.GetEmployeeListForBlood(OCODE).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "EmployeeListForBloodDS";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_ALLEmployeeBlood.rdlc";
                            Session["rptTitle"] = "Blood Wise";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdBloodWiseEmployee.Checked)
                    {

                        string Blood = ddlBloodGrp.SelectedItem.Text;
                        int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                        int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                        int departmentID = Convert.ToInt32(depDepartment.SelectedValue);
                        employees = objOfficeBLL.GetEmployeeListForBlood(Blood, ResionId, OfficeId, departmentID, OCODE).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "EmployeeListForBloodDS";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/HRM_EmployeeBlood.rdlc";
                            Session["rptTitle"] = "Blood Wise";
                            Response.Redirect("Report_Viewer.aspx");
                        }

                    }
                    else if (rdAllBlood.Checked)
                    {
                        if (ddlBloodGrp.SelectedItem.Text == "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select a Blood Group!')", true);
                            return;
                        }
                        string Blood = ddlBloodGrp.SelectedItem.Text;
                        employees = objOfficeBLL.GetEmployeeListForBloodAll(Blood, OCODE).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "EmployeeListForAllBloodDS";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/EmployeeListForAllBlood.rdlc";
                            Session["rptTitle"] = "Blood Wise";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }

                    //Designation Wise Report
                    else if (rdbdesignation.Checked)
                    {

                        if (ddldesignation.SelectedItem.Text == "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select a designation!')", true);
                            return;
                        }
                        string designation = ddldesignation.SelectedItem.Text;
                        employees = objOfficeBLL.GetEmployeeDesignation(designation, OCODE).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_designationDS";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_designation.rdlc";
                            Session["rptTitle"] = "Designation Wise";
                            Response.Redirect("Report_Viewer.aspx");

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }
                    //Bank Account Wise Employee 
                    else if (rdbbankaccount.Checked)
                    {
                        employees = objOfficeBLL.GetEmployeeBankAccount(OCODE).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_BankAccountwiseDS";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_BankAccountwise.rdlc";
                            Session["rptTitle"] = "Designation Wise";
                            Response.Redirect("Report_Viewer.aspx");

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }

                    else if (rdChildCount.Checked)
                    {
                        employees = employeeBllObj.GetAllChildCountRPT(OCODE).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "HRM_ChildCountDS";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/HRM_Rpt_ChildrenCount.rdlc";
                            Session["rptTitle"] = "All Chield Count";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdEmpInfo.Checked)
                    {
                        employees = employeeBllObj.GetAllEmployeeContact(OCODE).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "HRM_Rpt_EmployeeAddressDS";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/HRM_Rpt_EmployeeAddress.rdlc";
                            Session["rptTitle"] = "All Employee Contact";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }
                    else if (rdIndividual.Checked)
                    {
                        string empId = txtEid_AT.Text;
                        if (empId == "")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Give EID for search!')", true);
                            return;
                        }
                        employees = objOfficeBLL.GetEmployeeIndividualInfo(empId, OCODE).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RptEmployeeIndividualDS";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/HRM_RptEmployeeIndividual.rdlc";
                            Session["rptTitle"] = "Region Wise";
                            Response.Redirect("Report_Viewer.aspx");
                        }

                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }

                    }

                    else if (rdMale.Checked)
                    {
                        gender = "Male";
                        string empId = txtEid_AT.Text;
                        employees = objOfficeBLL.GetAllMaleEmployee(OCODE, gender).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "HRM_Rpt_AllMaleEmployeesDS";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/HRM_AllMaleEmployeesRPT.rdlc";
                            Session["rptTitle"] = "Male Employee";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rjoiningNewEmployee.Checked)
                    {
                        if (txtbxToDate.Text != "" && txtDateFrom.Text != "")
                        {

                            if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text == "--Select--")
                            {
                                DateTime todate = Convert.ToDateTime(txtbxToDate.Text);
                                DateTime Fromdate = Convert.ToDateTime(txtDateFrom.Text);

                                int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                                employees = objOfficeBLL.GetAllEmployeeJoiningDateByRegion(todate, Fromdate, ResionId).ToList();

                                if (employees.Count > 0)
                                {
                                    Session["rptDs"] = "DSLeftEmployee";
                                    Session["rptDt"] = employees;
                                    Session["rptFile"] = "/HRM/reports/HRM_AllEmployeeJoiningDateByRegion.rdlc";
                                    Session["rptTitle"] = "Region Wise";
                                    Response.Redirect("Report_Viewer.aspx");
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                                }
                            }
                            else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text == "--Select--")
                            {
                                DateTime todate = Convert.ToDateTime(txtbxToDate.Text);
                                DateTime Fromdate = Convert.ToDateTime(txtDateFrom.Text);
                                int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                                int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                                employees = objOfficeBLL.GetAllEmployeeJoiningDateByOffice(todate, Fromdate, ResionId, OfficeId).ToList();
                                if (employees.Count > 0)
                                {
                                    Session["rptDs"] = "DSLeftEmployee";
                                    Session["rptDt"] = employees;
                                    Session["rptFile"] = "/HRM/reports/HRM_AllEmployeeJoiningDateByOffice.rdlc";
                                    Session["rptTitle"] = "Office Wise";
                                    Response.Redirect("Report_Viewer.aspx");
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                                }

                            }

                            else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && drpSection.SelectedItem.Text == "--Select--")
                            {

                                DateTime todate = Convert.ToDateTime(txtbxToDate.Text);
                                DateTime Fromdate = Convert.ToDateTime(txtDateFrom.Text);
                                int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                                int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                                int Dept = Convert.ToInt32(depDepartment.SelectedValue);
                                employees = objOfficeBLL.GetAllEmployeeJoiningDateByDepartment(todate, Fromdate, ResionId, OfficeId, Dept).ToList();
                                if (employees.Count > 0)
                                {
                                    Session["rptDs"] = "DSLeftEmployee";
                                    Session["rptDt"] = employees;
                                    Session["rptFile"] = "/HRM/reports/HRM_AllEmployeeJoiningDateByDepartment.rdlc";
                                    Session["rptTitle"] = "Department Wise";
                                    Response.Redirect("Report_Viewer.aspx");
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                                }

                            }
                            else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && drpSection.SelectedItem.Text != "--Select--")
                            {

                                DateTime todate = Convert.ToDateTime(txtbxToDate.Text);
                                DateTime Fromdate = Convert.ToDateTime(txtDateFrom.Text);
                                int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                                int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                                int Dept = Convert.ToInt32(depDepartment.SelectedValue);
                                int sectionId = Convert.ToInt32(drpSection.SelectedValue);
                                employees = objOfficeBLL.GetAllEmployeeJoiningDateBySection(todate, Fromdate, ResionId, OfficeId, Dept, sectionId).ToList();
                                if (employees.Count > 0)
                                {
                                    Session["rptDs"] = "DSLeftEmployee";
                                    Session["rptDt"] = employees;
                                    Session["rptFile"] = "/HRM/reports/HRM_AllEmployeeJoiningDateBySection.rdlc";
                                    Session["rptTitle"] = "Department Wise";
                                    Response.Redirect("Report_Viewer.aspx");
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                                }

                            }
                            else
                            {


                                DateTime todate = Convert.ToDateTime(txtbxToDate.Text);
                                DateTime Fromdate = Convert.ToDateTime(txtDateFrom.Text);
                                employees = objOfficeBLL.GetAllEmployeeJoiningDateWise(todate, Fromdate).ToList();

                                if (employees.Count > 0)
                                {
                                    Session["rptDs"] = "DSLeftEmployee";
                                    Session["rptDt"] = employees;
                                    Session["rptFile"] = "/HRM/reports/HRM_LeftEmployeeDateWise.rdlc";
                                    Session["rptTitle"] = "Left Employee";
                                    Response.Redirect("Report_Viewer.aspx");

                                }

                            }

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Date Must Be Select!')", true);

                        }


                    }
                    else if (rdleftEmployee.Checked)
                    {
                        DateTime todate = Convert.ToDateTime(txtbxToDate.Text);
                        DateTime Fromdate = Convert.ToDateTime(txtDateFrom.Text);
                        employees = objOfficeBLL.GetAllEmployeeLeftgDateWise(todate, Fromdate).ToList();
                        if (employees.Count > 0)
                        {

                        }
                    }

                    else if (rdFemale.Checked)
                    {
                        gender = "Female";
                        string empId = txtEid_AT.Text;
                        employees = objOfficeBLL.GetAllMaleEmployee(OCODE, gender).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "HRM_Rpt_AllMaleEmployeesDS";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/HRM_AllMaleEmployeesRPT.rdlc";
                            Session["rptTitle"] = "Male Employee";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }
                    else if (btnEmployeeWiseLeave.Checked)
                    {
                        string empId = txtEid_AT.Text;
                        string currentDate = DateTime.Now.Year.ToString();
                        List<LeaveForReport> leaveinfoes = objOfficeBLL.GetLeaveInfoByEId(empId, currentDate, OCODE);
                        if (leaveinfoes.Count > 0)
                        {
                            Session["rptDs"] = "rptLeaveDetailByEid";
                            Session["rptDt"] = leaveinfoes;
                            Session["rptFile"] = "/HRM/reports/HrmLeaveDetailsByEid.rdlc";
                            Session["rptTitle"] = "Employee Wise Leave Info";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    //Male Employee Wise Leave Report
                    //else if (rdbMaleEmployeewiseleave.Checked)
                    //{
                    //    string empId = txtEid_AT.Text;
                    //    string Type = "Male";
                    //    List<LeaveForReport> leaveinfoes = objOfficeBLL.GetEmployeewiseLeaveRpt(empId, Type);
                    //    if (leaveinfoes.Count > 0)
                    //    {
                    //        Session["rptDs"] = "HRM_RPT_EmployeewiseLeaveDS";
                    //        Session["rptDt"] = leaveinfoes;
                    //        Session["rptFile"] = "/HRM/reports/HRM_RPT_EmployeewiseLeave.rdlc";
                    //        Session["rptTitle"] = "Employee Wise Leave Info";
                    //        Response.Redirect("Report_Viewer.aspx");
                    //    }
                    //}

                    //Female Employee Wise Leave Report
                    //else if (rdbFemaleEmplyeeleave.Checked)
                    //{
                    //    string empId = txtEid_AT.Text;
                    //    string Type = "Female";
                    //    List<LeaveForReport> leaveinfoes = objOfficeBLL.GetEmployeewiseLeaveRpt(empId, Type);
                    //    if (leaveinfoes.Count > 0)
                    //    {
                    //        Session["rptDs"] = "HRM_RPT_EmployeewiseLeaveDS";
                    //        Session["rptDt"] = leaveinfoes;
                    //        Session["rptFile"] = "/HRM/reports/HRM_RPT_FemaleEmployeewiseLeave.rdlc";
                    //        Session["rptTitle"] = "Employee Wise Leave Info";
                    //        Response.Redirect("Report_Viewer.aspx");
                    //    }
                    //}


                    // Employee All Child List
                    else if (rdChildList.Checked)
                    {
                        employees = employeeBllObj.GetAllEmployeeChildList(OCODE).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "HRM_Get18PluseChildrenDS";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/HRM/reports/HRM_Get18PluseChildrenRPT.rdlc";
                            Session["rptTitle"] = "All Employee Child List";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }



        //Leave Report

        protected void drpdwnResion2ForDepartmentSelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ResionId = Convert.ToInt32(ddlregion2.SelectedValue);
                BridOfficeByResion2(ResionId);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        private void BridOfficeByResion2(int ResionId)
        {
            try
            {
                var row = objOfficeBLL.GetOfficeByResionId(ResionId).ToList();
                if (row.Count > 0)
                {
                    ddlOffice2.DataSource = row.ToList();
                    ddlOffice2.DataTextField = "OfficeName";
                    ddlOffice2.DataValueField = "OfficeID";
                    ddlOffice2.DataBind();
                    ddlOffice2.Items.Insert(0, new ListItem("--Select--"));
                }
                else
                {
                    ddlOffice2.DataSource = null;
                    ddlOffice2.DataTextField = "OfficeName";
                    ddlOffice2.DataValueField = "OfficeID";
                    ddlOffice2.DataBind();
                    ddlOffice2.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void GerRegion2List()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objOfficeBLL.GetAllResion(OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlregion2.DataSource = row.ToList();
                    ddlregion2.DataTextField = "RegionName";
                    ddlregion2.DataValueField = "RegionID";
                    ddlregion2.DataBind();
                    ddlregion2.Items.Insert(0, new ListItem("--Select--"));
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void onSelectedIndedexChangeOffice2(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int ResionId = Convert.ToInt32(ddlregion2.SelectedValue);
                int OfficeId = Convert.ToInt32(ddlOffice2.SelectedValue);
                var row = objOfficeBLL.GetOfficeByResionId(ResionId, OfficeId, OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlDept2.DataSource = row.ToList();
                    ddlDept2.DataTextField = "DPT_NAME";
                    ddlDept2.DataValueField = "DPT_ID";
                    ddlDept2.DataBind();
                    ddlDept2.Items.Insert(0, new ListItem("--Select--"));
                }
                else
                {
                    ddlDept2.DataSource = null;
                    ddlDept2.DataTextField = "DPT_NAME";
                    ddlDept2.DataValueField = "DPT_ID";
                    ddlDept2.DataBind();
                    ddlDept2.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void drpdwnDepartment2SelectedIndexChange(object sender, EventArgs e)
        {
            //List<REmployee> employees = new List<REmployee>();
            //string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            //int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
            //int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
            //int departmentID = Convert.ToInt32(depDepartment.SelectedValue);
            //employees = objOfficeBLL.GetEmployeeListForDepartment(ResionId, OfficeId, departmentID, OCODE).ToList();
            //if (employees.Count > 0)
            //{
            //    Session["rptDs"] = "hrm_employeeforDepartment";
            //    Session["rptDt"] = employees;
            //    Session["rptFile"] = "/HRM/reports/HRM_EmployeeForDepartment.rdlc";
            //    Session["rptTitle"] = "Department Wise";
            //    Response.Redirect("Report_Viewer.aspx");

            //}
        }

        protected void txtEid2_AT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string employeeID = Convert.ToString(txtEid2_AT.Text);
                // img2.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;

                var result = objEmp_BLL.GetEmployeeDetailsForAttendece(employeeID, OCODE).ToList();
                if (result.Count > 0)
                {
                    var objNewEmp = result.First();
                    txtEid2_AT.Text = Convert.ToString(objNewEmp.EID);
                    nameTextBox2.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                    lblHiddenId.Text = Convert.ToString(objNewEmp.EMP_ID);
                    deptTextBox2.Text = objNewEmp.DPT_NAME;
                    desigTextBox2.Text = objNewEmp.DEG_NAME;
                }
                else
                {
                    //NO RECORDS FOUND.
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnProcess2_Click(object sender, EventArgs e)
        {
            try
            { 
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                if (btnEmployeeWiseLeave.Checked)
                {
                    string empId = txtEid2_AT.Text;
                    List<LeaveForReport> leaveinfoes = objOfficeBLL.GetEmployeewiseTotalLeave(empId, OCODE);
                    if (leaveinfoes.Count > 0)
                    {
                        Session["rptDs"] = "HRM_RPT_EmployeewiseLotalLeaveDS";
                        Session["rptDt"] = leaveinfoes;
                        Session["rptFile"] = "/HRM/reports/HRM_RPT_EmployeeWiseTotalLeave.rdlc";
                        Session["rptTitle"] = "Employee Wise Leave Info";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                }
                //Employee Male Leave Report
                else if (rdbMaleEmployeewiseleave.Checked)
                {
                    string empId = txtEid2_AT.Text;
                    string Type = "Male";
                    List<LeaveForReport> leaveinfoes = objOfficeBLL.GetEmployeewiseLeaveRpt(empId, Type, OCODE);
                    if (leaveinfoes.Count > 0)
                    {
                        Session["rptDs"] = "HRM_RPT_EmployeewiseLeaveDS";
                        Session["rptDt"] = leaveinfoes;
                        Session["rptFile"] = "/HRM/reports/HRM_RPT_EmployeeWiseTotalLeave.rdlc";
                        Session["rptTitle"] = "Employee Wise Leave Info";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                }

                //Female Employee Wise Leave Report
                else if (rdbFemaleEmplyeeleave.Checked)
                {
                    string empId = txtEid2_AT.Text;
                    string Type = "Female";
                    List<LeaveForReport> leaveinfoes = objOfficeBLL.GetEmployeewiseLeaveRpt(empId, Type, OCODE);
                    if (leaveinfoes.Count > 0)
                    {
                        Session["rptDs"] = "HRM_RPT_EmployeewiseLeaveDS";
                        Session["rptDt"] = leaveinfoes;
                        Session["rptFile"] = "/HRM/reports/HRM_RPT_FemaleEmployeewiseLeave.rdlc";
                        Session["rptTitle"] = "Employee Wise Leave Info";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                }
                //All Employee Leave
                else if (rdbAllemployeeleave.Checked)
                {


                    List<LeaveForReport> leaveinfoes = objOfficeBLL.GetAllEmployeewiseLeaveRpt(OCODE);
                    if (leaveinfoes.Count > 0)
                    {
                        Session["rptDs"] = "HRM_RPT_AllEmployeewiseLeaveDS";
                        Session["rptDt"] = leaveinfoes;
                        Session["rptFile"] = "/HRM/reports/HRM_RPT_AllEmployeewiseLeave.rdlc";
                        Session["rptTitle"] = "Employee Wise Leave Info";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                }
                else if (rdbEmployeeWiseLeaveStatment.Checked)
                {
                    string eid = txtEid2_AT.Text;
                    List<LeaveForReport> leaveinfoes = objOfficeBLL.GetAllEmployeewiseLeaveStatmentRpt(OCODE, eid);
                    if (leaveinfoes.Count > 0)
                    {
                        Session["rptDs"] = "HRM_RPT_AllEmployeewiseLeaveDS";
                        Session["rptDt"] = leaveinfoes;
                        Session["rptFile"] = "/HRM/reports/HRM_RPT_AllEmployeeWiseLeaveStatment.rdlc";
                        Session["rptTitle"] = "Employee Wise Leave Info";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                }

                else if (rdbAllEmployeeLeaveSummery.Checked)
                {
                    DateTime DateFrom = Convert.ToDateTime(txtDateFrom1.Text);
                    DateTime DateTo = Convert.ToDateTime(txtDateTo1.Text);
                    if (ddlregion2.SelectedItem.Text != "--Select--" && ddlOffice2.SelectedItem.Text == "--Select--")
                    {

                        string Region = ddlregion2.SelectedValue.ToString();
                        List<LeaveForReport> leaveinfoes = objOfficeBLL.GetAllEmployeeLeaveSummeryRptByRegion(DateFrom, DateTo, OCODE, Region);
                        if (leaveinfoes.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AllEmployeewiseLeaveDS";
                            Session["rptDt"] = leaveinfoes;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AllEmployeeLeaveSummeryRegionWise.rdlc";
                            Session["rptTitle"] = "Employee Wise Leave Info";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }

                    }
                    else if (ddlregion2.SelectedItem.Text != "--Select--" && ddlOffice2.SelectedItem.Text != "--Select--" && ddlDept2.SelectedItem.Text == "--Select--")
                    {
                        string Region = ddlregion2.SelectedValue.ToString();
                        string Office = ddlOffice2.SelectedValue.ToString();

                        List<LeaveForReport> leaveinfoes = objOfficeBLL.GetAllEmployeeLeaveSummeryRptByOffice(DateFrom, DateTo, OCODE, Region, Office);
                        if (leaveinfoes.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AllEmployeewiseLeaveDS";
                            Session["rptDt"] = leaveinfoes;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AllEmployeeLeaveSummeryOfficeWise.rdlc";
                            Session["rptTitle"] = "Employee Wise Leave Info";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }


                    }
                    else if (ddlregion2.SelectedItem.Text != "--Select--" && ddlOffice2.SelectedItem.Text != "--Select--" && ddlDept2.SelectedItem.Text != "--Select--")
                    {
                        string Region = ddlregion2.SelectedValue.ToString();
                        string Office = ddlOffice2.SelectedValue.ToString();
                        string Department = ddlDept2.SelectedValue.ToString();
                        List<LeaveForReport> leaveinfoes = objOfficeBLL.GetAllEmployeeLeaveSummeryRptByDepartment(DateFrom, DateTo, OCODE, Region, Office, Department);
                        if (leaveinfoes.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AllEmployeewiseLeaveDS";
                            Session["rptDt"] = leaveinfoes;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AllEmployeeLeaveSummeryDepartmentWise.rdlc";
                            Session["rptTitle"] = "Employee Wise Leave Info";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }

                    }
                    else
                    {

                        List<LeaveForReport> leaveinfoes = objOfficeBLL.GetAllEmployeeLeaveSummeryRpt(DateFrom, DateTo, OCODE);
                        if (leaveinfoes.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AllEmployeewiseLeaveDS";
                            Session["rptDt"] = leaveinfoes;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AllEmployeeLeaveSummery.rdlc";
                            Session["rptTitle"] = "Employee Wise Leave Info";
                            Response.Redirect("Report_Viewer.aspx");
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }



        // Attendance Report Code
        //private void GetShiftCodeList()
        //{
        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        var row = timeScheduleBll.GetAllSchedule(OCODE).ToList();
        //        if (row.Count > 0)
        //        {
        //            ddlShiftCode.DataSource = row.ToList();
        //            ddlShiftCode.DataTextField = "ShiftName";
        //            ddlShiftCode.DataValueField = "ShiftCode";
        //            ddlShiftCode.DataBind();
        //            ddlShiftCode.Items.Insert(0, new ListItem("------Select One------", "0"));
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


        //protected void txtEid1_AT_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        string employeeID = Convert.ToString(txtEid1_AT.Text);
        //        //Emp_IMG_AT.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;

        //        var result = objEmp_BLL.GetEmployeeDetailsForAttendece(employeeID, OCODE).ToList();
        //        if (result.Count > 0)
        //        {
        //            var objNewEmp = result.First();
        //            txtEid1_AT.Text = Convert.ToString(objNewEmp.EID);
        //            name1TextBox.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
        //            //lblHiddenId.Text = Convert.ToString(objNewEmp.EMP_ID);
        //            dept1TextBox.Text = objNewEmp.DPT_NAME;
        //            design1TextBox.Text = objNewEmp.DEG_NAME;
        //        }
        //        else
        //        {
        //            //NO RECORDS FOUND.
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //protected void ddlShiftCode_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        string shiftCode = Convert.ToString(ddlShiftCode.SelectedItem.Text);

        //        var result = timeScheduleBll.GetScheduleByCode(OCODE, shiftCode).ToList();
        //        if (result.Count > 0)
        //        {
        //            //var objShift = result.First();
        //            //txtShift.Text = objShift.ShiftName;
        //            //txtRegion.Text = objShift.HRM_Regions.RegionName;
        //            //txtOffice.Text = objShift.HRM_Office.OfficeName;
        //            //lblRegionId.Text = objShift.RegionId.ToString();
        //            //lblOfficeId.Text = objShift.OfficeId.ToString();
        //            //BindRegionByShift(shiftCode);
        //            //BindOfficeByShift(shiftCode);
        //            //TimeSpan in_time= objShift.StartTime;
        //            //TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtStartTime.Hour, txtStartTime.Minute, txtStartTime.Second)) = objShift.StartTime;
        //        }
        //        else
        //        {
        //            //lblMessage.Text = "<font color='red'>No record found</font>";
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        //protected void drpdwnResion1ForDepartmentSelecttedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
        //        BridOfficeByResion1(ResionId);

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //private void BridOfficeByResion1(int ResionId)
        //{
        //    var row = objOfficeBLL.GetOfficeByResionId(ResionId).ToList();
        //    if (row.Count > 0)
        //    {
        //        ddlOffice1.DataSource = row.ToList();
        //        ddlOffice1.DataTextField = "OfficeName";
        //        ddlOffice1.DataValueField = "OfficeID";
        //        ddlOffice1.DataBind();
        //        ddlOffice1.Items.Insert(0, new ListItem("--Select--"));
        //    }
        //    else
        //    {
        //        ddlOffice1.DataSource = null;
        //        ddlOffice1.DataTextField = "OfficeName";
        //        ddlOffice1.DataValueField = "OfficeID";
        //        ddlOffice1.DataBind();
        //        ddlOffice1.Items.Insert(0, new ListItem("--Select--"));
        //    }
        //}

        //private void GerRegion1List()
        //{
        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        var row = objOfficeBLL.GetAllResion(OCODE).ToList();
        //        if (row.Count > 0)
        //        {
        //            ddlRegion1.DataSource = row.ToList();
        //            ddlRegion1.DataTextField = "RegionName";
        //            ddlRegion1.DataValueField = "RegionID";
        //            ddlRegion1.DataBind();
        //            ddlRegion1.Items.Insert(0, new ListItem("--Select--"));
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //protected void onSelectedIndedexChangeOffice1(object sender, EventArgs e)
        //{
        //    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //    int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
        //    int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);

        //    var row = objOfficeBLL.GetOfficeByResionId(ResionId, OfficeId, OCODE).ToList();
        //    if (row.Count > 0)
        //    {
        //        ddlDept1.DataSource = row.ToList();
        //        ddlDept1.DataTextField = "DPT_NAME";
        //        ddlDept1.DataValueField = "DPT_ID";
        //        ddlDept1.DataBind();
        //        ddlDept1.Items.Insert(0, new ListItem("--Select--"));
        //    }
        //    else
        //    {
        //        ddlDept1.DataSource = null;
        //        ddlDept1.DataTextField = "DPT_NAME";
        //        ddlDept1.DataValueField = "DPT_ID";
        //        ddlDept1.DataBind();
        //        ddlDept1.Items.Insert(0, new ListItem("--Select--"));
        //    }
        //}

        //protected void drpdwnDepartment1SelectedIndexChange(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int RegionId = Convert.ToInt32(ddlRegion1.SelectedValue);
        //        int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
        //        int departmentId = Convert.ToInt32(ddlDept1.SelectedValue);
        //        BindShiftCodeByDepartment(RegionId, OfficeId, departmentId);

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        //private void BindShiftCodeByDepartment(int ResionId, int OfficeId, int departmentId)
        //{
        //    var row = objOfficeBLL.GetShiftCodeByDept(ResionId, OfficeId, departmentId).ToList();
        //    if (row.Count > 0)
        //    {
        //        ddlShiftCode.DataSource = row.ToList();
        //        ddlShiftCode.DataTextField = "ShiftCode";
        //        ddlShiftCode.DataValueField = "ScheduleId";
        //        ddlShiftCode.DataBind();
        //        ddlShiftCode.Items.Insert(0, new ListItem("--Select--"));
        //    }
        //    else
        //    {
        //        ddlShiftCode.DataSource = null;
        //        ddlShiftCode.DataTextField = "ShiftCode";
        //        ddlShiftCode.DataValueField = "ScheduleId";
        //        ddlShiftCode.DataBind();
        //        ddlShiftCode.Items.Insert(0, new ListItem("--Select--"));
        //    }
        //}
        ////int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
        ////int departmentId = Convert.ToInt32(depDepartment.SelectedValue); 

        //protected void btnProcess1_Click(object sender, EventArgs e)
        //{
        //    //Guid userId = ((SessionUser)Session["SessionUser"]).UserId;
        //    //aAttendance_RPT_Bll.UpdateAttStatus_ByDate(Convert.ToDateTime(txtbxFrom.Text), Convert.ToDateTime(txtbxTo.Text), userId);
        //    //aAttendance_RPT_Bll.Update_AbsentLeaveStatus_ByDate(Convert.ToDateTime(txtbxFrom.Text), Convert.ToDateTime(txtbxTo.Text));

        //    try
        //    {
        //        List<Attendance_Viewer> empAtendance = new List<Attendance_Viewer>();
        //        string fromDate = txtbxFrom.Text;
        //        string toDate = txtbxTo.Text;


        //        //For All Attendance Report
        //        if (rdbAllEmpAtt.Checked)
        //        {
        //            if (rdbAll.Checked)
        //            {
        //                empAtendance = aAttendance_RPT_Bll.GetAllAttendanceForEmployee(fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_RPT_AttendanceAllEmployeeDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAllEmployee.rdlc";
        //                    Session["rptTitle"] = "All Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }
        //        }

        //       //For All Attendance Report By Region Wise
        //        else if (rdbAllEmpRegionWise.Checked)
        //        {
        //            if (rdbAll.Checked)
        //            {
        //                int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
        //                empAtendance = aAttendance_RPT_Bll.GetAllAttendanceForRegionWise(ResionId, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_RPT_AttendanceAllEmpRegionWiseDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAllEmpRegionWise.rdlc";
        //                    Session["rptTitle"] = "All Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }
        //        }

        //         //for Region Wise 
        //        else if (rdRegion.Checked)
        //        {
        //            int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
        //            if (rdbPresent.Checked)
        //            {
        //                string status = "P";
        //                empAtendance = aAttendance_RPT_Bll.GetPresentAttendenceReport(ResionId, status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_AttendanceRegionWiseSP";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_AttendanceRegionWise.rdlc";
        //                    Session["rptTitle"] = "Region Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }

        //            else if (rdbLate.Checked)
        //            {
        //                string status = "L";
        //                empAtendance = aAttendance_RPT_Bll.GetPresentAttendenceReport(ResionId, status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_AttendanceRegionWiseSP";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_AttendanceRegionWise.rdlc";
        //                    Session["rptTitle"] = "Region Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }

        //            //else if (rdbOverLate.Checked)
        //            //{
        //            //    string status = "OL";

        //            //    empAtendance = aAttendance_RPT_Bll.GetPresentAttendenceReport(ResionId, status, fromDate, toDate).ToList();
        //            //    if (empAtendance.Count > 0)
        //            //    {
        //            //        Session["rptDs"] = "HRM_AttendanceRegionWiseSP";
        //            //        Session["rptDt"] = empAtendance;
        //            //        Session["rptFile"] = "/HRM/reports/HRM_AttendanceRegionWise.rdlc";
        //            //        Session["rptTitle"] = "Region Wise Attandence";
        //            //        Response.Redirect("Report_Viewer.aspx");
        //            //    }
        //            //}

        //            else if (rdbAbsent.Checked)
        //            {
        //                string status = "A";
        //                empAtendance = aAttendance_RPT_Bll.GetPresentAttendenceReport(ResionId, status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_AttendanceRegionWiseSP";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_AttendanceRegionWise.rdlc";
        //                    Session["rptTitle"] = "Region Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }
        //            else if (rdbAll.Checked)
        //            {
        //                string status = "ALL";
        //                empAtendance = aAttendance_RPT_Bll.GetPresentAttendenceReport(ResionId, status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_AttendanceRegionWiseSP";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_AttendanceRegionWise.rdlc";
        //                    Session["rptTitle"] = "Region Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }
        //        }

        //        //for All Region  
        //        if (rdAllRegion.Checked)
        //        {
        //            if (rdbPresent.Checked)
        //            {
        //                string status = "P";
        //                empAtendance = aAttendance_RPT_Bll.GetAllRegion(status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_AttendanceAllRegionWiseDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_AttendanceAllRegionWise.rdlc";
        //                    Session["rptTitle"] = "Region Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }

        //            else if (rdbLate.Checked)
        //            {
        //                string status = "L";

        //                empAtendance = aAttendance_RPT_Bll.GetAllRegion(status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_AttendanceAllRegionWiseDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_AttendanceAllRegionWise.rdlc";
        //                    Session["rptTitle"] = "Region Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }

        //            //else if (rdbOverLate.Checked)
        //            //{
        //            //    string status = "OL";

        //            //    empAtendance = aAttendance_RPT_Bll.GetAllRegion(status, fromDate, toDate).ToList();
        //            //    if (empAtendance.Count > 0)
        //            //    {
        //            //        Session["rptDs"] = "HRM_AttendanceAllRegionWiseDS";
        //            //        Session["rptDt"] = empAtendance;
        //            //        Session["rptFile"] = "/HRM/reports/HRM_AttendanceAllRegionWise.rdlc";
        //            //        Session["rptTitle"] = "Region Wise Attandence";
        //            //        Response.Redirect("Report_Viewer.aspx");
        //            //    }
        //            //}

        //            else if (rdbAbsent.Checked)
        //            {
        //                string status = "A";

        //                empAtendance = aAttendance_RPT_Bll.GetAllRegion(status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_AttendanceAllRegionWiseDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_AttendanceAllRegionWise.rdlc";
        //                    Session["rptTitle"] = "Region Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }
        //            else if (rdbAll.Checked)
        //            {
        //                string status = "ALL";

        //                empAtendance = aAttendance_RPT_Bll.GetAllRegion(status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_AttendanceAllRegionWiseDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_AttendanceAllRegionWise.rdlc";
        //                    Session["rptTitle"] = "Region Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }
        //        }

        //        //for Office 

        //        else if (rdOffice.Checked)
        //        {
        //            int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
        //            int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
        //            if (rdbPresent.Checked)
        //            {
        //                string status = "P";

        //                empAtendance = aAttendance_RPT_Bll.GetOfficeReport(ResionId, OfficeId, status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_AttendanceOfficeWiseDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_AttendanceOfficeWise.rdlc";
        //                    Session["rptTitle"] = "Office Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }

        //            else if (rdbLate.Checked)
        //            {
        //                string status = "L";

        //                empAtendance = aAttendance_RPT_Bll.GetOfficeReport(ResionId, OfficeId, status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_AttendanceOfficeWiseDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_AttendanceOfficeWise.rdlc";
        //                    Session["rptTitle"] = "Office Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }

        //            //else if (rdbOverLate.Checked)
        //            //{
        //            //    string status = "OL";

        //            //    empAtendance = aAttendance_RPT_Bll.GetOfficeReport(ResionId, OfficeId, status, fromDate, toDate).ToList();
        //            //    if (empAtendance.Count > 0)
        //            //    {
        //            //        Session["rptDs"] = "HRM_AttendanceOfficeWiseDS";
        //            //        Session["rptDt"] = empAtendance;
        //            //        Session["rptFile"] = "/HRM/reports/HRM_AttendanceOfficeWise.rdlc";
        //            //        Session["rptTitle"] = "office Wise Attandence";
        //            //        Response.Redirect("Report_Viewer.aspx");
        //            //    }
        //            //}

        //            else if (rdbAbsent.Checked)
        //            {
        //                string status = "A";
        //                empAtendance = aAttendance_RPT_Bll.GetOfficeReport(ResionId, OfficeId, status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_AttendanceOfficeWiseDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_AttendanceOfficeWise.rdlc";
        //                    Session["rptTitle"] = "Office Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }
        //            else if (rdbAll.Checked)
        //            {
        //                string status = "ALL";
        //                empAtendance = aAttendance_RPT_Bll.GetOfficeReport(ResionId, OfficeId, status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_AttendanceOfficeWiseDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_AttendanceOfficeWise.rdlc";
        //                    Session["rptTitle"] = "Office Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }
        //        }

        //        //For Department

        //        else if (rdDepartment.Checked)
        //        {
        //            int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
        //            int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
        //            int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);
        //            if (rdbPresent.Checked)
        //            {
        //                string status = "P";
        //                empAtendance = aAttendance_RPT_Bll.GetDepartmentReport(ResionId, OfficeId, DeptId, status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_AttendanceDeptWiseDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_AttendanceDeptWise.rdlc";
        //                    Session["rptTitle"] = "Dept Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }

        //            else if (rdbLate.Checked)
        //            {
        //                string status = "L";

        //                empAtendance = aAttendance_RPT_Bll.GetDepartmentReport(ResionId, OfficeId, DeptId, status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_AttendanceDeptWiseDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_AttendanceDeptWise.rdlc";
        //                    Session["rptTitle"] = "Dept Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }

        //            //else if (rdbOverLate.Checked)
        //            //{
        //            //    string status = "OL";

        //            //    empAtendance = aAttendance_RPT_Bll.GetDepartmentReport(ResionId, OfficeId, DeptId, status, fromDate, toDate).ToList();
        //            //    if (empAtendance.Count > 0)
        //            //    {
        //            //        Session["rptDs"] = "HRM_AttendanceDeptWiseDS";
        //            //        Session["rptDt"] = empAtendance;
        //            //        Session["rptFile"] = "/HRM/reports/HRM_AttendanceDeptWise.rdlc";
        //            //        Session["rptTitle"] = "Dept Wise Attandence";
        //            //        Response.Redirect("Report_Viewer.aspx");
        //            //    }
        //            //}

        //            else if (rdbAbsent.Checked)
        //            {
        //                string status = "A";
        //                empAtendance = aAttendance_RPT_Bll.GetDepartmentReport(ResionId, OfficeId, DeptId, status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_AttendanceDeptWiseDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_AttendanceDeptWise.rdlc";
        //                    Session["rptTitle"] = "Dept Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }
        //            else if (rdbAll.Checked)
        //            {
        //                string status = "ALL";
        //                empAtendance = aAttendance_RPT_Bll.GetDepartmentReport(ResionId, OfficeId, DeptId, status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_AttendanceDeptWiseDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_AttendanceDeptWise.rdlc";
        //                    Session["rptTitle"] = "Dept Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }
        //        }

        //        //For ShiftCode

        //        else if (rdShiftCode.Checked)
        //        {
        //            int RegionId = Convert.ToInt32(ddlRegion1.SelectedValue);
        //            int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
        //            int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);
        //            string ShiftCode = ddlShiftCode.SelectedItem.Text;

        //            if (rdbPresent.Checked)
        //            {
        //                string status = "P";
        //                empAtendance = aAttendance_RPT_Bll.GetShiftCodeReport(RegionId, OfficeId, DeptId, status, fromDate, toDate, ShiftCode).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_AttendanceShiftCodeWiseDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_AttendanceShiftCodeWise.rdlc";
        //                    Session["rptTitle"] = "ShiftCode Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }

        //            else if (rdbLate.Checked)
        //            {
        //                string status = "L";

        //                empAtendance = aAttendance_RPT_Bll.GetShiftCodeReport(RegionId, OfficeId, DeptId, status, fromDate, toDate, ShiftCode).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_AttendanceShiftCodeWiseDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_AttendanceShiftCodeWise.rdlc";
        //                    Session["rptTitle"] = "ShiftCode Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }

        //            //else if (rdbOverLate.Checked)
        //            //{
        //            //    string status = "OL";

        //            //    empAtendance = aAttendance_RPT_Bll.GetShiftCodeReport(RegionId, OfficeId, DeptId, status, fromDate, toDate, ShiftCode).ToList();
        //            //    if (empAtendance.Count > 0)
        //            //    {
        //            //        Session["rptDs"] = "HRM_AttendanceShiftCodeWiseDS";
        //            //        Session["rptDt"] = empAtendance;
        //            //        Session["rptFile"] = "/HRM/reports/HRM_AttendanceShiftCodeWise.rdlc";
        //            //        Session["rptTitle"] = "ShiftCode Wise Attandence";
        //            //        Response.Redirect("Report_Viewer.aspx");
        //            //    }
        //            //}

        //            else if (rdbAbsent.Checked)
        //            {
        //                string status = "A";
        //                empAtendance = aAttendance_RPT_Bll.GetShiftCodeReport(RegionId, OfficeId, DeptId, status, fromDate, toDate, ShiftCode).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_AttendanceShiftCodeWiseDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_AttendanceShiftCodeWise.rdlc";
        //                    Session["rptTitle"] = "ShiftCode Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }
        //            else if (rdbAll.Checked)
        //            {
        //                string status = "ALL";
        //                empAtendance = aAttendance_RPT_Bll.GetShiftCodeReport(RegionId, OfficeId, DeptId, status, fromDate, toDate, ShiftCode).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_AttendanceShiftCodeWiseDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_AttendanceShiftCodeWise.rdlc";
        //                    Session["rptTitle"] = "ShiftCode Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }
        //        }


        //        //For Individual Employee Report

        //        else if (rdIndividualByStatus.Checked)
        //        {
        //            string empId = txtEid1_AT.Text;
        //            if (rdbPresent.Checked)
        //            {
        //                string status = "P";
        //                empAtendance = aAttendance_RPT_Bll.GetEmpIndividualReport(empId, status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_RPT_AttendanceIndividualEmpDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceIndividualEmp.rdlc";
        //                    Session["rptTitle"] = "Employee Id Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }

        //            else if (rdbLate.Checked)
        //            {
        //                string status = "L";
        //                empAtendance = aAttendance_RPT_Bll.GetEmpIndividualReport(empId, status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_RPT_AttendanceIndividualEmpDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceIndividualEmp.rdlc";
        //                    Session["rptTitle"] = "Employee Id Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }

        //            //else if (rdbOverLate.Checked)
        //            //{
        //            //    string status = "OL";
        //            //    empAtendance = aAttendance_RPT_Bll.GetEmpIndividualReport(empId, status, fromDate, toDate).ToList();
        //            //    if (empAtendance.Count > 0)
        //            //    {
        //            //        Session["rptDs"] = "HRM_RPT_AttendanceIndividualEmpDS";
        //            //        Session["rptDt"] = empAtendance;
        //            //        Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceIndividualEmp.rdlc";
        //            //        Session["rptTitle"] = "Employee Id Wise Attandence";
        //            //        Response.Redirect("Report_Viewer.aspx");
        //            //    }
        //            //}

        //            else if (rdbAbsent.Checked)
        //            {
        //                string status = "A";
        //                empAtendance = aAttendance_RPT_Bll.GetEmpIndividualReport(empId, status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_RPT_AttendanceIndividualEmpDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceIndividualEmp.rdlc";
        //                    Session["rptTitle"] = "Employee Id Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }
        //        }

        //        else if (rdbEmpwiseAll.Checked)
        //        {
        //            string empId = txtEid1_AT.Text;
        //            if (rdbAll.Checked)
        //            {
        //                string status = "ALL";
        //                empAtendance = aAttendance_RPT_Bll.GetEmpIndividualReport(empId, status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_RPT_AttendanceIndividualEmpDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceEmpwise(All).rdlc";
        //                    Session["rptTitle"] = "Employee Id Wise Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }
        //        }

        //        //Absent Report For All Employee
        //        else if (rdbEmpAbsent.Checked)
        //        {
        //            string status = "A";
        //            empAtendance = aAttendance_RPT_Bll.AttendanceLateAbsentAllEmp(status, fromDate, toDate).ToList();
        //            if (empAtendance.Count > 0)
        //            {
        //                Session["rptDs"] = "HRM_RPT_AttendanceLateAbsentAllEmpDS";
        //                Session["rptDt"] = empAtendance;
        //                Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAbsentAllEmp.rdlc";
        //                Session["rptTitle"] = "All Employee Attandence";
        //                Response.Redirect("Report_Viewer.aspx");
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //            }
        //        }

        //        //Late Report For All Employee  
        //        else if (rdAllEmpLate.Checked)
        //        {
        //            string status = "L";
        //            empAtendance = aAttendance_RPT_Bll.AttendanceLateAbsentAllEmp(status, fromDate, toDate).ToList();
        //            if (empAtendance.Count > 0)
        //            {
        //                Session["rptDs"] = "HRM_RPT_AttendanceLateAbsentAllEmpDS";
        //                Session["rptDt"] = empAtendance;
        //                Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceLateAllEmp.rdlc";
        //                Session["rptTitle"] = "All Employee Attandence";
        //                Response.Redirect("Report_Viewer.aspx");
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //            }
        //        }

        //        // Region Wise Absent Employee 
        //        else if (rdRegAbsRpt.Checked)
        //        {
        //            int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
        //            string status = "A";
        //            empAtendance = aAttendance_RPT_Bll.GetRegionWiseAtteAbsentAllEmp(ResionId, status, fromDate, toDate).ToList();
        //            if (empAtendance.Count > 0)
        //            {
        //                Session["rptDs"] = "HRM_RPT_RegionWiseAtteAbsentAllEmpDS";
        //                Session["rptDt"] = empAtendance;
        //                Session["rptFile"] = "/HRM/reports/HRM_RPT_RegionWiseAtteAbsentAllEmp.rdlc";
        //                Session["rptTitle"] = "All Employee Attandence";
        //                Response.Redirect("Report_Viewer.aspx");
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //            }
        //        }
        //        // Office Wise Absent Employee 
        //        else if (rdRegAbsRptOffice.Checked)
        //        {
        //            int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
        //            int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
        //            string status = "A";
        //            empAtendance = aAttendance_RPT_Bll.GetOfficeWiseAtteAbsentAllEmp(OfficeId, ResionId, status, fromDate, toDate).ToList();
        //            if (empAtendance.Count > 0)
        //            {
        //                Session["rptDs"] = "HRM_RPT_OfficeWiseAtteAbsentAllEmpDS";
        //                Session["rptDt"] = empAtendance;
        //                Session["rptFile"] = "/HRM/reports/HRM_RPT_OfficeWiseAtteAbsentAllEmp.rdlc";
        //                Session["rptTitle"] = "All Employee Attandence";
        //                Response.Redirect("Report_Viewer.aspx");
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //            }
        //        }

        //        // Department Wise Absent Employee 
        //        else if (rdRegAbsRptDeptWise.Checked)
        //        {
        //            int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
        //            int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
        //            int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);
        //            string status = "A";
        //            empAtendance = aAttendance_RPT_Bll.GetDeptWiseAtteAbsentAllEmp(DeptId, OfficeId, ResionId, status, fromDate, toDate).ToList();
        //            if (empAtendance.Count > 0)
        //            {
        //                Session["rptDs"] = "HRM_RPT_DeptWiseAtteAbsentAllEmpDS";
        //                Session["rptDt"] = empAtendance;
        //                Session["rptFile"] = "/HRM/reports/HRM_RPT_DeptWiseAtteAbsentAllEmp.rdlc";
        //                Session["rptTitle"] = "All Employee Attandence";
        //                Response.Redirect("Report_Viewer.aspx");
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //            }
        //        }

        //        //Region Wise Late Employee 
        //        else if (rdRegLateRpt.Checked)
        //        {
        //            int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
        //            string status = "L";
        //            empAtendance = aAttendance_RPT_Bll.GetRegionWiseAtteLatetAllEmp(ResionId, status, fromDate, toDate).ToList();
        //            if (empAtendance.Count > 0)
        //            {
        //                Session["rptDs"] = "HRM_RPT_RegionWiseAttenLateAllEmpDS";
        //                Session["rptDt"] = empAtendance;
        //                Session["rptFile"] = "/HRM/reports/HRM_RPT_RegionWiseAttenLateAllEmp.rdlc";
        //                Session["rptTitle"] = "All Employee Attandence";
        //                Response.Redirect("Report_Viewer.aspx");
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //            }
        //        }

        //        //Office Wise Late Employee 
        //        else if (rdRegLateRptOfficeWise.Checked)
        //        {
        //            int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
        //            int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
        //            string status = "L";
        //            empAtendance = aAttendance_RPT_Bll.GetOfficeWiseAtteLatetAllEmp(OfficeId, ResionId, status, fromDate, toDate).ToList();
        //            if (empAtendance.Count > 0)
        //            {
        //                Session["rptDs"] = "HRM_RPT_OfficeWiseAttenLateAllEmpDS";
        //                Session["rptDt"] = empAtendance;
        //                Session["rptFile"] = "/HRM/reports/HRM_RPT_OfficeWiseAttenLateAllEmp.rdlc";
        //                Session["rptTitle"] = "All Employee Attandence";
        //                Response.Redirect("Report_Viewer.aspx");
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //            }
        //        }
        //        //Dept Wise Late Employee 
        //        else if (rdRegLateRptDeptWise.Checked)
        //        {
        //            int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
        //            int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
        //            int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);
        //            string status = "L";
        //            empAtendance = aAttendance_RPT_Bll.GetDeptWiseAtteLatetAllEmp(DeptId, OfficeId, ResionId, status, fromDate, toDate).ToList();
        //            if (empAtendance.Count > 0)
        //            {
        //                Session["rptDs"] = "HRM_RPT_DeptWiseAttenLateAllEmpDS";
        //                Session["rptDt"] = empAtendance;
        //                Session["rptFile"] = "/HRM/reports/HRM_RPT_DeptWiseAttenLateAllEmp.rdlc";
        //                Session["rptTitle"] = "All Employee Attandence";
        //                Response.Redirect("Report_Viewer.aspx");
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //            }
        //        }
        //        //Daily Report For Employee 
        //        else if (rdbAllEmp.Checked)
        //        {
        //            //string status = "All";
        //            empAtendance = aAttendance_RPT_Bll.GetAttendanceAllEmpForAll(fromDate, toDate).ToList();
        //            if (empAtendance.Count > 0)
        //            {
        //                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyDS";
        //                Session["rptDt"] = empAtendance;
        //                Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAllEmpDaily.rdlc";
        //                Session["rptTitle"] = "All Employee Attandence";
        //                Response.Redirect("Report_Viewer.aspx");
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //            }
        //        }

        //        // Daily Report For Employee Region Wise
        //        else if (rdbAllEmpByRegion.Checked)
        //        {
        //            if (txtbxFrom.Text == txtbxTo.Text)
        //            {
        //                int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
        //                //string status = "All";
        //                empAtendance = aAttendance_RPT_Bll.GetAttendanceAllEmpForAllByRegion(ResionId, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByRegionDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAllEmpDailyByRegion.rdlc";
        //                    Session["rptTitle"] = "All Employee Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select same date for daily report!')", true);
        //            }
        //        }

        //       //Daily Report For Employee Office Wise
        //        else if (rdbAllEmpOfficeWise.Checked)
        //        {
        //            if (txtbxFrom.Text == txtbxTo.Text)
        //            {
        //                int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
        //                int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
        //                //string status = "All";
        //                empAtendance = aAttendance_RPT_Bll.GetAttendanceAllEmpForAllByOffice(OfficeId, ResionId, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByOfficeDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAllEmpDailyByOffice.rdlc";
        //                    Session["rptTitle"] = "All Employee Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select same date for daily report!')", true);
        //            }
        //        }
        //        // Daily Report For Employee Department Wise
        //        else if (rdbAllEmpDeptWise.Checked)
        //        {
        //            if (txtbxFrom.Text == txtbxTo.Text)
        //            {
        //                int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
        //                int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
        //                int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);
        //                //string status = "All";
        //                empAtendance = aAttendance_RPT_Bll.GetAttendanceAllEmpForAllByDept(DeptId, OfficeId, ResionId, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAllEmpDailyByDept.rdlc";
        //                    Session["rptTitle"] = "All Employee Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select same date for daily report!')", true);
        //            }
        //        }
        //        //Epmloyee All Info
        //        else if (rdbAllEmpStatuswise.Checked)
        //        {
        //            if (rdbPresent.Checked)
        //            {
        //                if (txtbxFrom.Text == txtbxTo.Text)
        //                {
        //                    string status = "P";
        //                    empAtendance = aAttendance_RPT_Bll.GetAttendanceAllEmp(status, fromDate, toDate).ToList();
        //                    if (empAtendance.Count > 0)
        //                    {
        //                        Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDS";
        //                        Session["rptDt"] = empAtendance;
        //                        Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAllEmp.rdlc";
        //                        Session["rptTitle"] = "All Employee Attandence";
        //                        Response.Redirect("Report_Viewer.aspx");
        //                    }
        //                    else
        //                    {
        //                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                    }
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select same date for daily report!')", true);
        //                }
        //            }

        //            else if (rdbLate.Checked)
        //            {
        //                string status = "L";
        //                empAtendance = aAttendance_RPT_Bll.GetAttendanceAllEmp(status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAllEmp.rdlc";
        //                    Session["rptTitle"] = "All Employee Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }

        //            //else if (rdbOverLate.Checked)
        //            //{
        //            //    string status = "OL";
        //            //    empAtendance = aAttendance_RPT_Bll.GetAttendanceAllEmp(status, fromDate, toDate).ToList();
        //            //    if (empAtendance.Count > 0)
        //            //    {
        //            //        Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDS";
        //            //        Session["rptDt"] = empAtendance;
        //            //        Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAllEmp.rdlc";
        //            //        Session["rptTitle"] = "All Employee Attandence";
        //            //        Response.Redirect("Report_Viewer.aspx");
        //            //    }
        //            //}

        //            else if (rdbAbsent.Checked)
        //            {
        //                string status = "A";
        //                empAtendance = aAttendance_RPT_Bll.GetAttendanceAllEmp(status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAllEmp.rdlc";
        //                    Session["rptTitle"] = "All Employee Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }

        //            else if (rdbAll.Checked)
        //            {
        //                string status = "All";
        //                empAtendance = aAttendance_RPT_Bll.GetAttendanceAllEmp(status, fromDate, toDate).ToList();
        //                if (empAtendance.Count > 0)
        //                {
        //                    Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDS";
        //                    Session["rptDt"] = empAtendance;
        //                    Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAllEmp.rdlc";
        //                    Session["rptTitle"] = "All Employee Attandence";
        //                    Response.Redirect("Report_Viewer.aspx");
        //                }
        //                else
        //                {
        //                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //                }
        //            }
        //        }

        //        //Employee Monthly Present Report
        //        else if (rdbEmpPresent.Checked)
        //        {
        //            empAtendance = aAttendance_RPT_Bll.MonthlyAttendanceForLeave(fromDate, toDate).ToList();
        //            if (empAtendance.Count > 0)
        //            {
        //                Session["rptDs"] = "HRM_Rpt_MonthlyAttendanceForLeaveDS";
        //                Session["rptDt"] = empAtendance;
        //                Session["rptFile"] = "/HRM/reports/HRM_Rpt_MonthlyAttendanceForLeave.rdlc";
        //                Session["rptTitle"] = "All Employee Attandence";
        //                Response.Redirect("Report_Viewer.aspx");
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //            }
        //        }

        //        //Employee Monthly Present Region Wise Report
        //        else if (rdbEmpPresentRegWise.Checked)
        //        {
        //            int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
        //            empAtendance = aAttendance_RPT_Bll.MonthlyAttendanceForLeaveforRegion(ResionId, fromDate, toDate).ToList();
        //            if (empAtendance.Count > 0)
        //            {
        //                Session["rptDs"] = "HRM_Rpt_MonthlyAttendanceForLeaveForRegionDS";
        //                Session["rptDt"] = empAtendance;
        //                Session["rptFile"] = "/HRM/reports/HRM_Rpt_MonthlyAttendanceForLeaveForRegion.rdlc";
        //                Session["rptTitle"] = "All Employee Attandence";
        //                Response.Redirect("Report_Viewer.aspx");
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //            }
        //        }

        //         //Employee Monthly Present Office Wise Report
        //        else if (rdbEmpOfficeWise.Checked)
        //        {
        //            int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
        //            int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
        //            empAtendance = aAttendance_RPT_Bll.MonthlyAttendanceForLeaveforOffice(OfficeId, ResionId, fromDate, toDate).ToList();
        //            if (empAtendance.Count > 0)
        //            {
        //                Session["rptDs"] = "HRM_Rpt_MonthlyAttendanceForLeaveForOfficeDS";
        //                Session["rptDt"] = empAtendance;
        //                Session["rptFile"] = "/HRM/reports/HRM_Rpt_MonthlyAttendanceForLeaveForOffice.rdlc";
        //                Session["rptTitle"] = "All Employee Attandence";
        //                Response.Redirect("Report_Viewer.aspx");
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //            }
        //        }

        //        //Employee Monthly Present Dept Wise Report
        //        else if (rdbEmpDeptWise.Checked)
        //        {
        //            int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
        //            int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
        //            int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);
        //            empAtendance = aAttendance_RPT_Bll.MonthlyAttendanceForLeaveforDept(DeptId, OfficeId, ResionId, fromDate, toDate).ToList();
        //            if (empAtendance.Count > 0)
        //            {
        //                Session["rptDs"] = "HRM_Rpt_MonthlyAttendanceForLeaveForDeptDS";
        //                Session["rptDt"] = empAtendance;
        //                Session["rptFile"] = "/HRM/reports/HRM_Rpt_MonthlyAttendanceForLeaveForDept.rdlc";
        //                Session["rptTitle"] = "All Employee Attandence";
        //                Response.Redirect("Report_Viewer.aspx");
        //            }
        //            else
        //            {
        //                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
        //            }
        //        }
        //    }

        //    catch
        //    {

        //    }


        //}


    }
}

