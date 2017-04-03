using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.HRM;
using ERPSSL.HRM.DAL;
using ERPSSL.PAYROLL.BLL;
using ERPSSL.PAYROLL.DAL.Repository;

namespace ERPSSL.PAYROLL
{
    public partial class Payroll_RPT : System.Web.UI.Page
    {

        EmployeeSetup_BLL objEmp_BLL = new EmployeeSetup_BLL();
        DEPARTMENT_BLL DepartmentBll = new DEPARTMENT_BLL();
        //EmployeeSetup_BLL employeeBll = new EmployeeSetup_BLL();
        Office_BLL objOfficeBLL = new Office_BLL();
        Attendance_RPT_Bll aAttendance_RPT_Bll = new Attendance_RPT_Bll();
        Attendance_BLL objAtt_BLL = new Attendance_BLL();
        TIME_SCHEDULE_BLL timeScheduleBll = new TIME_SCHEDULE_BLL();
        EMPOYEE_BLL employeeBllObj = new EMPOYEE_BLL();
        TaxCalculationBLL ATaxCalculationBLL = new TaxCalculationBLL();
        SECTION_BLL SectionBll = new SECTION_BLL();
        SUB_SECTION_BLL subSectionBll = new SUB_SECTION_BLL();
        SUB_SECTION_DAL subSectionDal = new SUB_SECTION_DAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GerRegionList();
                    //GetShiftCodeList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        //private void GetShiftCodeList()
        //{
        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        var row = timeScheduleBll.GetAllSchedule(OCODE).ToList();
        //        if (row.Count > 0)
        //        {
        //            ddlShiftCode.DataSource = row.ToList();
        //            ddlShiftCode.DataTextField = "ShiftCode";
        //            ddlShiftCode.DataValueField = "ScheduleId";
        //            ddlShiftCode.DataBind();
        //            ddlShiftCode.Items.Insert(0, new ListItem("------Select One------", "0"));
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}


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
                    //lblHiddenId.Text = Convert.ToString(objNewEmp.EMP_ID);
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
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
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
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int departmentId = Convert.ToInt16(depDepartment.SelectedValue);
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

            //try
            //{
            //    int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
            //    int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
            //    int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
            //    BindShiftCodeByDepartment(RegionId, OfficeId, departmentId);

            //}
            //catch (Exception)
            //{
            //    throw;
            //}
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


        //int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
        //int departmentId = Convert.ToInt32(depDepartment.SelectedValue);

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<REmployee> employees = new List<REmployee>();
                List<Attendance_Viewer> empAtendance = new List<Attendance_Viewer>();
                string fromDate = txtbxFrom.Text;
                string toDate = txtbxTo.Text;

                string monthYear = Convert.ToDateTime(txtbxFrom.Text).ToString("MMMM-yyyy");

                //OT All  CALCULATION REPORT
                //if (rdAllOTHourCal.Checked)
                //{

                //    empAtendance = aAttendance_RPT_Bll.GetAllOtHourCalculationReport(fromDate, toDate).ToList();
                //    if (empAtendance.Count > 0)
                //    {
                //        Session["rptDs"] = "HRM_Rpt_AllOTHourCalculationDS";
                //        Session["rptDt"] = empAtendance;
                //        Session["rptFile"] = "/PAYROLL/reports/HRM_Rpt_AllOTHourCalculation.rdlc";
                //        Session["rptTitle"] = "OT All  CALCULATION REPORT";
                //        Response.Redirect("Report_Viewer.aspx");
                //    }
                //}
                //else if (rdAttendanceOTRegister.Checked)
                //{
                //    // string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //    //objAtt_BLL.InsertOTperiodic(objOTperiodic);

                // objAtt_BLL.UpdateAttendanceOTperiodic_ByDate(Convert.ToDateTime(txtbxFrom.Text), Convert.ToDateTime(txtbxTo.Text), OCODE);

                //    empAtendance = aAttendance_RPT_Bll.GetrdAttendanceOTRegisterReport(fromDate, toDate).ToList();
                //    if (empAtendance.Count > 0)
                //    {
                //        Session["rptDs"] = "DSAttendanceandOTRegister";
                //        Session["rptDt"] = empAtendance;
                //        Session["rptFile"] = "/PAYROLL/reports/HRM_Rpt_AttendanceAndOTRegister.rdlc";
                //        Session["rptTitle"] = "Attendance and OT Register";
                //        Response.Redirect("Report_Viewer.aspx");
                //    }
                //}
                //Employee Wise  OT Report

                // if (rdbEmpwiseOT.Checked)
                //{
                //    string empId = txtEid_AT.Text;
                //    empAtendance = aAttendance_RPT_Bll.GetEmpWiseOTReport(empId, fromDate, toDate).ToList();
                //    if (empAtendance.Count > 0)
                //    {
                //        Session["rptDs"] = "HRM_Rpt_EmpwiseOTCalculationDS";
                //        Session["rptDt"] = empAtendance;
                //        Session["rptFile"] = "/PAYROLL/reports/HRM_Rpt_EmpwiseOTCalculation.rdlc";
                //        Session["rptTitle"] = "Employee Wise OT CALCULATION REPORT";
                //        Response.Redirect("Report_Viewer.aspx");
                //    }
                //}

                ////Employee (Office) Refion Wise OT Report

                //else if (rdOfficeWiseOT.Checked)
                //{
                //    int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                //    empAtendance = aAttendance_RPT_Bll.GetEmpRegioneWiseOT(RegionId, fromDate, toDate).ToList();
                //    if (empAtendance.Count > 0)
                //    {
                //        Session["rptDs"] = "HRM_Rpt_EmpOfficeWiseOTCalculationDS";
                //        Session["rptDt"] = empAtendance;
                //        Session["rptFile"] = "/PAYROLL/reports/HRM_Rpt_EmpOfficeWiseOTCalculation.rdlc";
                //        Session["rptTitle"] = "Employee Office Wise OT CALCULATION REPORT";
                //        Response.Redirect("Report_Viewer.aspx");
                //    }
                //}

                //Employee All Salary Sheet 

                if (txtbxFrom.Text != "")
                {
                    if (rdSalarySheet.Checked)
                    {
                        if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                            int subSectionId = Convert.ToInt32(ddlSubSections.SelectedValue);

                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetSubSectionWise(departmentId, fromDate, RegionId, OfficeId, sectionId, subSectionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetBySubSection.rdlc";
                                Session["rptTitle"] = "Employee Salary Report Sheet";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                        {
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetSectionWise(departmentId, fromDate, RegionId, OfficeId, sectionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetBySection.rdlc";
                                Session["rptTitle"] = "Employee Salary Report Sheet";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }

                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetDeptWise(departmentId, fromDate, toDate, RegionId, OfficeId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetByDept.rdlc";
                                Session["rptTitle"] = "Employee Salary Report Sheet";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetOfficeWise(fromDate, RegionId, OfficeId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetByOffice.rdlc";
                                Session["rptTitle"] = "Employee Salary Report Sheet";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);


                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetRegionWise(fromDate, RegionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetByRegion.rdlc";
                                Session["rptTitle"] = "Employee Salary Report Sheet";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            empsalaryList = aAttendance_RPT_Bll.GetEmployeeIndividualReport(fromDate).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheet.rdlc";
                                Session["rptTitle"] = "Employee Salary Report Sheet";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                    }

                    // mobile bank wise report
                    else if (rdbMobileBank.Checked)
                    {
                        if (txtbxFrom.Text != "")
                        {
                            string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                            List<BankAdviceRe> Bank2 = new List<BankAdviceRe>();
                            Bank2 = objAtt_BLL.GetMobileBankAdvice(OCode, fromDate).ToList();
                            if (Bank2.Count > 0)
                            {
                                Session["rptDs"] = "HRM_BankAdviceAllListDS";
                                Session["rptDt"] = Bank2;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_MobileBankAdviceByDptId.rdlc";
                                Session["rptTitle"] = "Mobile Bank Info";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Form Date...!')", true);
                        }
                    }

                    // bank advice
                    else if (rdbBankAdvice.Checked)
                    {
                        if (txtbxFrom.Text != "")
                        {
                            string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                            List<BankAdviceRe> Bank2 = new List<BankAdviceRe>();
                            Bank2 = objAtt_BLL.GetOnlyBankAdvice(OCode, fromDate).ToList();
                            if (Bank2.Count > 0)
                            {
                                Session["rptDs"] = "HRM_BankAdviceAllListDS";
                                Session["rptDt"] = Bank2;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_BankAdvice.rdlc";
                                Session["rptTitle"] = "Mobile Bank Info";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {

                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Form Date...!')", true);
                        }
                    }


                    else if (rdbCashSalary.Checked)
                    {
                        if (txtbxFrom.Text != "")
                        {
                            string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                            List<BankAdviceRe> Bank2 = new List<BankAdviceRe>();
                            Bank2 = objAtt_BLL.GetInfo_WithOutBankInfo(OCode, fromDate).ToList();
                            if (Bank2.Count > 0)
                            {
                                Session["rptDs"] = "HRM_BankAdviceAllListDS";
                                Session["rptDt"] = Bank2;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_PersonalInfo_WithOut_BankAdvice.rdlc";
                                Session["rptTitle"] = "Mobile Bank Info";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {

                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Form Date...!')", true);
                        }
                    }

                    else if (rdSalaryWithStamp.Checked)
                    {
                        if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text == "--Select--")
                        {
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetSectionWise(departmentId, fromDate, RegionId, OfficeId, sectionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetWithStampSectionWise.rdlc";
                                Session["rptTitle"] = "Employee Ot Report Sheet";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                            int subSectionId = Convert.ToInt32(ddlSubSections.SelectedValue);

                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetSubSectionWise(departmentId, fromDate, RegionId, OfficeId, sectionId, subSectionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetWithStampSubSectionWise.rdlc";
                                Session["rptTitle"] = "Employee Salary Report Sheet";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Section Or SubsSection!')", true);
                        }
                    }

                    //salary top sheet All (Non Compliance)

                    else if (rdSalaryTopSheet.Checked)
                    {
                        if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Sub-Section wise report!')", true);
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Section wise report!')", true);
                        }

                        // department wise
                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);

                            empsalaryList = aAttendance_RPT_Bll.GetSalaryTopSheetDepartmentWise(fromDate, RegionId, OfficeId, departmentId, OCODE).ToList();

                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_Get_SalaryTopSheetByDepartmentRPT.rdlc";
                                Session["rptTitle"] = "All Salary Summary For the Month of " + monthYear + " (All)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        // office wise
                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);

                            empsalaryList = aAttendance_RPT_Bll.GetSalaryTopSheetOfficeWise(fromDate, RegionId, OfficeId, OCODE).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_Get_SalaryTopSheet_ByOffice.rdlc";
                                Session["rptTitle"] = "All Salary Summary For the Month of " + monthYear + " (All)";

                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        //region wise
                        //if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text == "--Select--")
                        //{
                        //    List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                        //    int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                        //    empsalaryList = aAttendance_RPT_Bll.GetSalaryTopSheetRegionWise(fromDate, RegionId).ToList();
                        //    if (empsalaryList.Count > 0)
                        //    {
                        //        Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                        //        Session["rptDt"] = empsalaryList;
                        //        Session["rptFile"] = "/PAYROLL/reports/HRM_Get_SalaryTopSheetByRegionRPT.rdlc";
                        //        Session["rptTitle"] = "Employee Salary Top Sheet";
                        //        Response.Redirect("Report_Viewer.aspx");
                        //    }
                        //    else
                        //    {
                        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        //    }
                        //}

                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Office or Department')", true);
                        }
                    }


                    //salary top sheet by cash (Non Compliance)

                    else if (rdSalaryTopSheetByCash.Checked)
                    {
                        if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Sub-Section wise report!')", true);
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Section wise report!')", true);
                        }

                        // department wise
                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Department wise report!')", true);
                        }
                        // office wise
                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);

                            empsalaryList = aAttendance_RPT_Bll.GetSalaryTopSheetOfficeWise_ByCash(fromDate, RegionId, OfficeId, OCODE).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_Get_SalaryTopSheet_ByOffice.rdlc";
                                Session["rptTitle"] = "All Salary Summary For the Month of " + monthYear + " (Cash)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Region & Office for top sheet')", true);
                        }
                    }

                     //salary top sheet by bank (Non Compliance)

                    else if (rdSalaryTopSheetByBank.Checked)
                    {
                        if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Sub-Section wise report!')", true);
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Section wise report!')", true);
                        }

                        // department wise
                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Department wise report!')", true);
                        }
                        // office wise
                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);

                            empsalaryList = aAttendance_RPT_Bll.GetSalaryTopSheetOfficeWise_ByBank(fromDate, RegionId, OfficeId, OCODE).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_Get_SalaryTopSheet_ByOffice.rdlc";
                                Session["rptTitle"] = "All Salary Summary For the Month of " + monthYear + " (Bank)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Region & Office for top sheet')", true);
                        }
                    }

                    //salary top sheet by mobile bank (Non Compliance)

                    else if (rdSalaryTopSheetByMobileBank.Checked)
                    {
                        if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Sub-Section wise report!')", true);
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Section wise report!')", true);
                        }

                        // department wise
                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Department wise report!')", true);
                        }
                        // office wise
                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);

                            empsalaryList = aAttendance_RPT_Bll.GetSalaryTopSheetOfficeWise_ByMobileBank(fromDate, RegionId, OfficeId, OCODE).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_Get_SalaryTopSheet_ByOffice.rdlc";
                                Session["rptTitle"] = "All Salary Summary For the Month of " + monthYear + " (Mobile Bank)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Region & Office for top sheet')", true);
                        }
                    }


                    else if (rdOtSheet.Checked)
                    {
                        if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                            int subSectionId = Convert.ToInt32(ddlSubSections.SelectedValue);

                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetSubSectionWise(departmentId, fromDate, RegionId, OfficeId, sectionId, subSectionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllOTSheetBySubSection.rdlc";
                                Session["rptTitle"] = "Employee Salary Report Sheet";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text == "--Select--")
                        {
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetSectionWise(departmentId, fromDate, RegionId, OfficeId, sectionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllOTSheetBySection.rdlc";
                                Session["rptTitle"] = "Employee Ot Report Sheet";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetDeptWise(departmentId, fromDate, toDate, RegionId, OfficeId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllOTSheetByDpt.rdlc";
                                Session["rptTitle"] = "Employee Salary Report Sheet";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetRegionWise(fromDate, RegionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllOTSheetByRegion.rdlc";
                                Session["rptTitle"] = "Employee Salary Report Sheet";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetOfficeWise(fromDate, RegionId, OfficeId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllOTSheetByOffice.rdlc";
                                Session["rptTitle"] = "Employee Salary Report Sheet";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            empsalaryList = aAttendance_RPT_Bll.GetEmployeeIndividualReport(fromDate).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllOTSheet.rdlc";
                                Session["rptTitle"] = "Employee Salary Report Sheet";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                    }


                    else if (rdOTSheetByHour.Checked)
                    {
                        if (txtOTHour.Text != "")
                        {

                            string hour = txtOTHour.Text.ToString();

                            if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                            {
                                int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                                int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                                int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                                int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                                int subSectionId = Convert.ToInt32(ddlSubSections.SelectedValue);

                                List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                                empsalaryList = aAttendance_RPT_Bll.GetOTSheetSubSectionWiseByOTHour(departmentId, fromDate, RegionId, OfficeId, sectionId, subSectionId, hour).ToList();
                                if (empsalaryList.Count > 0)
                                {
                                    Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                    Session["rptDt"] = empsalaryList;
                                    Session["rptFile"] = "/PAYROLL/reports/HRM_Get_OT_SheetBySubSectionWiseRPT.rdlc";
                                    Session["rptTitle"] = "Employee Salary Report Sheet";
                                    Response.Redirect("Report_Viewer.aspx");
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                                }
                            }
                            else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text == "--Select--")
                            {
                                int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                                int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                                int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                                int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                                List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                                empsalaryList = aAttendance_RPT_Bll.GetOTSheetSectionWiseByOTHour(departmentId, fromDate, RegionId, OfficeId, sectionId, hour).ToList();
                                if (empsalaryList.Count > 0)
                                {
                                    Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                    Session["rptDt"] = empsalaryList;
                                    Session["rptFile"] = "/PAYROLL/reports/HRM_Get_OT_SheetBySectionWiseRPT.rdlc";
                                    Session["rptTitle"] = "Employee Ot Report Sheet";
                                    Response.Redirect("Report_Viewer.aspx");
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                                }
                            }
                            else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                            {
                                List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                                int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                                int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                                int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                                empsalaryList = aAttendance_RPT_Bll.GetOTSheetDeptWiseByOTHour(departmentId, fromDate, toDate, RegionId, OfficeId, hour).ToList();
                                if (empsalaryList.Count > 0)
                                {
                                    Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                    Session["rptDt"] = empsalaryList;
                                    Session["rptFile"] = "/PAYROLL/reports/HRM_Get_OT_SheetByDeptWiseRPT.rdlc";
                                    Session["rptTitle"] = "Employee Salary Report Sheet";
                                    Response.Redirect("Report_Viewer.aspx");
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                                }
                            }
                            else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text == "--Select--")
                            {
                                List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                                int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                                empsalaryList = aAttendance_RPT_Bll.GetOTSheetRegionWiseByOTHour(fromDate, RegionId, hour).ToList();
                                if (empsalaryList.Count > 0)
                                {
                                    Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                    Session["rptDt"] = empsalaryList;
                                    Session["rptFile"] = "/PAYROLL/reports/HRM_Get_OT_SheetByRegionWiseRPT.rdlc";
                                    Session["rptTitle"] = "Employee Salary Report Sheet";
                                    Response.Redirect("Report_Viewer.aspx");
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                                }
                            }
                            else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text == "--Select--")
                            {
                                List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                                int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                                int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                                empsalaryList = aAttendance_RPT_Bll.GetOTSheetOfficeWiseByOTHour(fromDate, RegionId, OfficeId, hour).ToList();
                                if (empsalaryList.Count > 0)
                                {
                                    Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                    Session["rptDt"] = empsalaryList;
                                    Session["rptFile"] = "/PAYROLL/reports/HRM_Get_OT_SheetByOfficeWiseRPT.rdlc";
                                    Session["rptTitle"] = "Employee Salary Report Sheet";
                                    Response.Redirect("Report_Viewer.aspx");
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                                }
                            }
                            else
                            {
                                List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                                empsalaryList = aAttendance_RPT_Bll.GetALLOTReportByOTHour(fromDate, hour).ToList();
                                if (empsalaryList.Count > 0)
                                {
                                    Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                    Session["rptDt"] = empsalaryList;
                                    Session["rptFile"] = "/PAYROLL/reports/HRM_Get_OT_SheetByAllWiseRPT.rdlc";
                                    Session["rptTitle"] = "Employee Salary Report Sheet";
                                    Response.Redirect("Report_Viewer.aspx");
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                                }
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Input OT Hour!')", true);
                        }
                    }

                     // salary sheet all
                    else if (rdSalaryandOTSheet.Checked)
                    {
                        if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                            int subSectionId = Convert.ToInt32(ddlSubSections.SelectedValue);
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetSubSectionWise(departmentId, fromDate, RegionId, OfficeId, sectionId, subSectionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheetBySubSection.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                        {
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetSectionWise(departmentId, fromDate, RegionId, OfficeId, sectionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheetBySection.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }

                        }
                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetDeptWise(departmentId, fromDate, toDate, RegionId, OfficeId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheetByDpt.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetOfficeWise(fromDate, RegionId, OfficeId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheetByOffice.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);


                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetRegionWise(fromDate, RegionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheetByRegion.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            empsalaryList = aAttendance_RPT_Bll.GetEmployeeIndividualReport(fromDate).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheet.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                    }

                    //Salary sheet by cash
                    else if (rdSalaryandOTSheet_ByCash.Checked)
                    {
                        if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                            int subSectionId = Convert.ToInt32(ddlSubSections.SelectedValue);
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetSubSectionByCash(departmentId, fromDate, RegionId, OfficeId, sectionId, subSectionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheetBySubSection.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Cash)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                            // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No SubSection wise data!')", true);
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                        {
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetSectionByCash(departmentId, fromDate, RegionId, OfficeId, sectionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheetBySection.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Cash)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Section wise data!')", true);

                        }
                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetDepartmentByCash(departmentId, fromDate, toDate, RegionId, OfficeId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheetByDpt.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Cash)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                            // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Department wise data!')", true);
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text == "--Select--")
                        {
                            //List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            //int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            //int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);

                            //empsalaryList = aAttendance_RPT_Bll.GetSalarySheetOfficeWise(fromDate, RegionId, OfficeId).ToList();
                            //if (empsalaryList.Count > 0)
                            //{
                            //    Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                            //    Session["rptDt"] = empsalaryList;
                            //    Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheetByOffice.rdlc";
                            //    Session["rptTitle"] = "Salary & OT Sheet";
                            //    Response.Redirect("Report_Viewer1.aspx");
                            //}
                            //else
                            //{
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Office Wise Report!')", true);
                            //}
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text == "--Select--")
                        {
                            //List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            //int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);

                            //empsalaryList = aAttendance_RPT_Bll.GetSalarySheetRegionWise(fromDate, RegionId).ToList();
                            //if (empsalaryList.Count > 0)
                            //{
                            //    Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                            //    Session["rptDt"] = empsalaryList;
                            //    Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheetByRegion.rdlc";
                            //    Session["rptTitle"] = "Salary & OT Sheet";
                            //    Response.Redirect("Report_Viewer1.aspx");
                            //}
                            //else
                            //{
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Region Wise Report!')", true);
                            //}
                        }

                        else
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetAllByCash(fromDate).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheet.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Cash)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                    }

                    //Salary sheet By Bank
                    else if (rdSalaryandOTSheet_ByBank.Checked)
                    {

                        if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                            int subSectionId = Convert.ToInt32(ddlSubSections.SelectedValue);
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetSubSectionByBank(departmentId, fromDate, RegionId, OfficeId, sectionId, subSectionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheetBySubSection.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Bank)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                        {
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetSectionByBank(departmentId, fromDate, RegionId, OfficeId, sectionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheetBySection.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Bank)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetDepartmentByBank(departmentId, fromDate, toDate, RegionId, OfficeId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheetByDpt.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Bank)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text == "--Select--")
                        {
                            //List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            //int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            //int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);

                            //empsalaryList = aAttendance_RPT_Bll.GetSalarySheetOfficeWise(fromDate, RegionId, OfficeId).ToList();
                            //if (empsalaryList.Count > 0)
                            //{
                            //    Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                            //    Session["rptDt"] = empsalaryList;
                            //    Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheetByOffice.rdlc";
                            //    Session["rptTitle"] = "Salary & OT Sheet";
                            //    Response.Redirect("Report_Viewer1.aspx");
                            //}
                            //else
                            //{
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Office Wise Report!')", true);
                            //}
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text == "--Select--")
                        {
                            //List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            //int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);


                            //empsalaryList = aAttendance_RPT_Bll.GetSalarySheetRegionWise(fromDate, RegionId).ToList();
                            //if (empsalaryList.Count > 0)
                            //{
                            //    Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                            //    Session["rptDt"] = empsalaryList;
                            //    Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheetByRegion.rdlc";
                            //    Session["rptTitle"] = "Salary & OT Sheet";
                            //    Response.Redirect("Report_Viewer1.aspx");
                            //}
                            //else
                            //{
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Region Wise Report!')", true);
                            //}
                        }

                        else
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetAllByBank(fromDate).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheet.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Bank)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                    }

                    //Salary Sheet By Mobile Bank
                    else if (rdSalaryandOTSheet_ByMobile.Checked)
                    {

                        if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                            int subSectionId = Convert.ToInt32(ddlSubSections.SelectedValue);
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetSubSectionByMobile(departmentId, fromDate, RegionId, OfficeId, sectionId, subSectionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheetBySubSection.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Mobile Bank)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                        {
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetSectionByMobile(departmentId, fromDate, RegionId, OfficeId, sectionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheetBySection.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Mobile Bank)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }

                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetDepartmentByMobile(departmentId, fromDate, toDate, RegionId, OfficeId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheetByDpt.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Mobile Bank)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text == "--Select--")
                        {
                            //List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            //int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            //int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);

                            //empsalaryList = aAttendance_RPT_Bll.GetSalarySheetOfficeWise(fromDate, RegionId, OfficeId).ToList();
                            //if (empsalaryList.Count > 0)
                            //{
                            //    Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                            //    Session["rptDt"] = empsalaryList;
                            //    Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheetByOffice.rdlc";
                            //    Session["rptTitle"] = "Salary & OT Sheet";
                            //    Response.Redirect("Report_Viewer1.aspx");
                            //}
                            //else
                            //{
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Office Wise Report!')", true);
                            // }
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text == "--Select--")
                        {
                            //List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            //int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);


                            //empsalaryList = aAttendance_RPT_Bll.GetSalarySheetRegionWise(fromDate, RegionId).ToList();
                            //if (empsalaryList.Count > 0)
                            //{
                            //    Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                            //    Session["rptDt"] = empsalaryList;
                            //    Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheetByRegion.rdlc";
                            //    Session["rptTitle"] = "Salary & OT Sheet";
                            //    Response.Redirect("Report_Viewer1.aspx");
                            //}
                            //else
                            //{
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Region Wise Report!')", true);
                            //}
                        }

                        else
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetAllByMobile(fromDate).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalaryWithOTSheet.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Mobile Bank)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                    }

                    // compliance sheet by cash
                    else if (rdSalaryandOTSheetByCash.Checked)
                    {

                        if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                            int subSectionId = Convert.ToInt32(ddlSubSections.SelectedValue);
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetSubSectionByCash(departmentId, fromDate, RegionId, OfficeId, sectionId, subSectionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetWithOT_ComplianceBySubSection.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Cash)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                        {
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetSectionByCash(departmentId, fromDate, RegionId, OfficeId, sectionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetWithOT_ComplianceBySection.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Cash)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetDepartmentByCash(departmentId, fromDate, toDate, RegionId, OfficeId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetWithOT_ComplianceByDpt.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Cash)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text == "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Office Wise Report')", true);
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text == "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Region Wise Report!')", true);
                        }

                        else
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetAllByCash(fromDate).ToList();
                            if (empsalaryList.Count > 0) 
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetWithOT_Compliance.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Cash)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                    }

                    // compliance sheet by bank
                    else if (rdSalaryandOTSheetByBank.Checked)
                    {
                        if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                            int subSectionId = Convert.ToInt32(ddlSubSections.SelectedValue);
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetSubSectionByBank(departmentId, fromDate, RegionId, OfficeId, sectionId, subSectionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetWithOT_ComplianceBySubSection.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Bank)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                        {
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetSectionByBank(departmentId, fromDate, RegionId, OfficeId, sectionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetWithOT_ComplianceBySection.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Bank)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }

                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetDepartmentByBank(departmentId, fromDate, toDate, RegionId, OfficeId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetWithOT_ComplianceByDpt.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Bank)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text == "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Office Wise Report')", true);
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text == "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Region Wise Report!')", true);
                        }

                        else
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetAllByBank(fromDate).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetWithOT_Compliance.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Bank)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                    }

                    // compliance sheet by mobilebank
                    else if (rdSalaryandOTSheetByMobileBank.Checked)
                    {

                        if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                            int subSectionId = Convert.ToInt32(ddlSubSections.SelectedValue);
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetSubSectionByMobile(departmentId, fromDate, RegionId, OfficeId, sectionId, subSectionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetWithOT_ComplianceBySubSection.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Mobile Bank)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                        {
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetSectionByMobile(departmentId, fromDate, RegionId, OfficeId, sectionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetWithOT_ComplianceBySection.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Mobile Bank)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }

                        }
                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetDepartmentByMobile(departmentId, fromDate, toDate, RegionId, OfficeId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetWithOT_ComplianceByDpt.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Mobile Bank)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text == "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Office Wise Report')", true);
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text == "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Region Wise Report!')", true);
                        }

                        else
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetAllByMobile(fromDate).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetWithOT_Compliance.rdlc";
                                Session["rptTitle"] = "Salary & OT Sheet (Mobile Bank)";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                    }

                    //salary & OT Compliance sheet
                    if (rdSalaryandOTCompliance.Checked)
                    {

                        if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                            int subSectionId = Convert.ToInt32(ddlSubSections.SelectedValue);
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetSubSectionWise(departmentId, fromDate, RegionId, OfficeId, sectionId, subSectionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetWithOT_ComplianceBySubSection.rdlc";
                                Session["rptTitle"] = "Employee Salary Report Sheet";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                        {
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetSectionWise(departmentId, fromDate, RegionId, OfficeId, sectionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetWithOT_ComplianceBySection.rdlc";
                                Session["rptTitle"] = "Employee Salary Report Sheet";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }

                        }
                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                            int departmentId = Convert.ToInt32(depDepartment.SelectedValue);

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetDeptWise(departmentId, fromDate, toDate, RegionId, OfficeId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetWithOT_ComplianceByDpt.rdlc";
                                Session["rptTitle"] = "Employee Salary Report Sheet";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text != "--Select--" && depDepartment.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                            int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);

                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetOfficeWise(fromDate, RegionId, OfficeId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetWithOT_ComplianceByOffice.rdlc";
                                Session["rptTitle"] = "Employee Salary Report Sheet";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else if (ddlRegions.SelectedItem.Text != "--Select--" && drpOffice.SelectedItem.Text == "--Select--")
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);


                            empsalaryList = aAttendance_RPT_Bll.GetSalarySheetRegionWise(fromDate, RegionId).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetWithOT_ComplianceByRegion.rdlc";
                                Session["rptTitle"] = "Employee Salary Report Sheet";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else
                        {
                            List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                            empsalaryList = aAttendance_RPT_Bll.GetEmployeeIndividualReport(fromDate).ToList();
                            if (empsalaryList.Count > 0)
                            {
                                Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                                Session["rptDt"] = empsalaryList;
                                Session["rptFile"] = "/PAYROLL/reports/HRM_RPT_AllSalarySheetWithOT_Compliance.rdlc";
                                Session["rptTitle"] = "Employee Salary & OT Sheet ";
                                Response.Redirect("Report_Viewer1.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                    }

                    //Employee All Salary Sheet Region Wise
                    //else if (rdSalarySheetRegionWise.Checked)
                    //{
                    //    List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                    //    int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                    //    empsalaryList = aAttendance_RPT_Bll.GetSalarySheetRegionWise(fromDate, RegionId).ToList();
                    //    if (empsalaryList.Count > 0)
                    //    {
                    //        Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                    //        Session["rptDt"] = empsalaryList;
                    //        Session["rptFile"] = "/PAYROLL/reports/HRM_Get_SalaryInfoRegionWiseRPT.rdlc";
                    //        Session["rptTitle"] = "Employee Salary Report Sheet";
                    //        Response.Redirect("Report_Viewer.aspx");
                    //    }
                    //}
                    //Employee All Salary Sheet Office Wise
                    //else if (rdSalarySheetOfficeWise.Checked)
                    //{
                    //    List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                    //    int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                    //    int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                    //    empsalaryList = aAttendance_RPT_Bll.GetSalarySheetOfficeWise(fromDate, RegionId, OfficeId).ToList();
                    //    if (empsalaryList.Count > 0)
                    //    {
                    //        Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                    //        Session["rptDt"] = empsalaryList;
                    //        Session["rptFile"] = "/PAYROLL/reports/HRM_Get_SalaryInfoOfficeWiseRPT.rdlc";
                    //        Session["rptTitle"] = "Employee Salary Report Sheet";
                    //        Response.Redirect("Report_Viewer.aspx");
                    //    }
                    //}

                                      //Employee All Salary Sheet Dept Wise
                    //else if (rdSalarySheetDeptWise.Checked)
                    //{
                    //    List<Salary_Viewer> empsalaryList = new List<Salary_Viewer>();
                    //    int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                    //    int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                    //    int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                    //    empsalaryList = aAttendance_RPT_Bll.GetSalarySheetDeptWise(departmentId, fromDate, RegionId, OfficeId).ToList();
                    //    if (empsalaryList.Count > 0)
                    //    {
                    //        Session["rptDs"] = "HRMRptGetSalaryInfoDS";
                    //        Session["rptDt"] = empsalaryList;
                    //        Session["rptFile"] = "/PAYROLL/reports/HRM_Get_SalaryInfoDeptWiseRPT.rdlc";
                    //        Session["rptTitle"] = "Employee Salary Report Sheet";
                    //        Response.Redirect("Report_Viewer.aspx");
                    //    }
                    //}


                    //Employee Wise Benefit
                    else if (rdEmpWiseBenefit.Checked)
                    {
                        string empId = txtEid_AT.Text;
                        List<EmployeeBenefit> emplBenefit = objOfficeBLL.GetRptForEmployeeBenefit(empId);
                        if (emplBenefit.Count > 0)
                        {
                            Session["rptDs"] = "HRM_EmployeeBenefitDS";
                            Session["rptDt"] = emplBenefit;
                            Session["rptFile"] = "/PAYROLL/reports/HRM_EmployeeBenefitRPT.rdlc";
                            Session["rptTitle"] = "Employee Wise Benefits";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                   //All Employee Benefit
                    else if (rdAllEmpBenefit.Checked)
                    {
                        List<EmployeeBenefit> emplBenefit = objOfficeBLL.GetRptForAllEmployeeBenefit(OCODE);
                        if (emplBenefit.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AllEmployeeBenefitDS";
                            Session["rptDt"] = emplBenefit;
                            Session["rptFile"] = "/PAYROLL/reports/HRM_AllEmployeeBenefitRPT.rdlc";
                            Session["rptTitle"] = "Employee Wise Benefits";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    //All Employee Benefit Office Wise
                    else if (rdbAllEmpBenifitOfficeWise.Checked)
                    {
                        int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                        int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                        List<EmployeeBenefit> emplBenefit = objOfficeBLL.GetRptForAllEmployeeBenefitOfficeWise(RegionId, OfficeId);
                        if (emplBenefit.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AllEmployeeBenefitDS";
                            Session["rptDt"] = emplBenefit;
                            Session["rptFile"] = "/PAYROLL/reports/HRM_AllEmployeeBenefitOfficeWiseRPT.rdlc";
                            Session["rptTitle"] = "Employee Wise Benefits";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    //All Employee Benefit Department Wise
                    else if (rdbAllEmpBenifitDeptWise.Checked)
                    {
                        int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                        int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                        int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                        List<EmployeeBenefit> emplBenefit = objOfficeBLL.GetRptForAllEmployeeBenefitDepartmentWise(departmentId, RegionId, OfficeId);
                        if (emplBenefit.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AllEmployeeBenefitDS";
                            Session["rptDt"] = emplBenefit;
                            Session["rptFile"] = "/PAYROLL/reports/HRM_AllEmployeeBenefitDeptWiseRPT.rdlc";
                            Session["rptTitle"] = "Employee Wise Benefits";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    // Employee Id Wise Advanced Salary
                    else if (rdSalAdvList.Checked)
                    {
                        string empId = txtEid_AT.Text;
                        List<AdvancedSalary> EmpadvancedSalary = objOfficeBLL.GetRptForAdvancedSalary(empId);
                        if (EmpadvancedSalary.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AdvancedSalaryListDS";
                            Session["rptDt"] = EmpadvancedSalary;
                            Session["rptFile"] = "/PAYROLL/reports/HRM_AdvancedSalaryList.rdlc";
                            Session["rptTitle"] = "Employee Advanced Salary";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    // Employee All Advanced Salary
                    else if (rdAllSalAdvList.Checked)
                    {
                        List<AdvancedSalary> EmpadvancedSalary = objOfficeBLL.GetRptForAllAdvancedSalary(OCODE);
                        if (EmpadvancedSalary.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AllAdvancedSalaryListDS";
                            Session["rptDt"] = EmpadvancedSalary;
                            Session["rptFile"] = "/PAYROLL/reports/HRM_AllAdvancedSalaryList.rdlc";
                            Session["rptTitle"] = "Employee All Advanced Salary";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    // Employee All Advanced Salary Office Wise
                    else if (rdAllSalAdvListOfficeWise.Checked)
                    {
                        int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                        int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                        List<AdvancedSalary> EmpadvancedSalary = objOfficeBLL.GetRptForAllAdvancedSalaryOfficeWise(RegionId, OfficeId);
                        if (EmpadvancedSalary.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AllAdvancedSalaryListDS";
                            Session["rptDt"] = EmpadvancedSalary;
                            Session["rptFile"] = "/PAYROLL/reports/HRM_AllAdvancedSalaryListOfficeWise.rdlc";
                            Session["rptTitle"] = "Employee All Advanced Salary";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    // Employee All Advanced Salary Department Wise
                    else if (rdAllSalAdvListDeptWise.Checked)
                    {
                        int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                        int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                        int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                        List<AdvancedSalary> EmpadvancedSalary = objOfficeBLL.GetRptForAllAdvancedSalaryDeptWise(departmentId, RegionId, OfficeId);
                        if (EmpadvancedSalary.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AllAdvancedSalaryListDS";
                            Session["rptDt"] = EmpadvancedSalary;
                            Session["rptFile"] = "/PAYROLL/reports/HRM_AllEmployeeBenefitDeptWiseRPT.rdlc";
                            Session["rptTitle"] = "Employee All Advanced Salary";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdSalary.Checked)
                    {
                        int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                        int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                        int departmentID = Convert.ToInt32(depDepartment.SelectedValue);
                        employees = objOfficeBLL.GetEmployeeListForSalary(ResionId, OfficeId, departmentID, OCODE).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "SalaryWiseDS";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/PAYROLL/reports/HRM_SalaryWiseReport.rdlc";
                            Session["rptTitle"] = "Salary Wise";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdAllSalary.Checked)
                    {
                        employees = employeeBllObj.GetAllSalaryRPT(OCODE).ToList();
                        if (employees.Count > 0)
                        {
                            Session["rptDs"] = "HRM_ALLSalaryDS";
                            Session["rptDt"] = employees;
                            Session["rptFile"] = "/PAYROLL/reports/HRM_AllSalary.rdlc";
                            Session["rptTitle"] = "All Salary";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdtaxCalculation.Checked)
                    {
                        string Eid = txtEid_AT.Text;
                        List<TaxCalculate> aemployees = new List<TaxCalculate>();
                        aemployees = ATaxCalculationBLL.GetTaxDetailByEID(Eid).ToList();
                        if (aemployees.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_TaxCalulationDS";
                            Session["rptDt"] = aemployees;
                            Session["rptFile"] = "/PAYROLL/reports/HRM_TaxCalculation.rdlc";
                            Session["rptTitle"] = "All Salary";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Date!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }




    }
}