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

namespace ERPSSL.HRM
{
    public partial class AttendanceReports_Compliance : System.Web.UI.Page
    {
        EmployeeSetup_BLL objEmp_BLL = new EmployeeSetup_BLL();
        DEPARTMENT_BLL DepartmentBll = new DEPARTMENT_BLL();
        EmployeeSetup_BLL employeeBll = new EmployeeSetup_BLL();
        Office_BLL objOfficeBLL = new Office_BLL();
        EMPOYEE_BLL employeeBllObj = new EMPOYEE_BLL();
        SECTION_BLL SectionBll = new SECTION_BLL();
        SUB_SECTION_BLL subSectionBll = new SUB_SECTION_BLL();
        SUB_SECTION_DAL subSectionDal = new SUB_SECTION_DAL();
        Attendance_RPT_Bll aAttendance_RPT_Bll = new Attendance_RPT_Bll();
        TIME_SCHEDULE_BLL timeScheduleBll = new TIME_SCHEDULE_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GerRegion1List();
                    txtbxFrom.Text = DateTime.Today.ToShortDateString();
                    txtbxTo.Text = DateTime.Today.ToShortDateString();
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



        protected void ddlSubSections_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int RegionId = Convert.ToInt32(ddlRegion1.SelectedValue);
            //int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
            //int departmentId = Convert.ToInt32(ddlDept1.SelectedValue);
            //BindShiftCodeByDepartment(RegionId, OfficeId, departmentId);
        }

        protected void txtEid1_AT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string employeeID = Convert.ToString(txtEid1_AT.Text);
                //Emp_IMG_AT.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;

                var result = objEmp_BLL.GetAllEmployeeInfoByEID(employeeID, OCODE).ToList();
                if (result.Count > 0)
                {
                    var objNewEmp = result.First();
                    txtEid1_AT.Text = Convert.ToString(objNewEmp.EID);
                    name1TextBox.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                    //lblHiddenId.Text = Convert.ToString(objNewEmp.EMP_ID);
                    dept1TextBox.Text = objNewEmp.DPT_NAME;
                    design1TextBox.Text = objNewEmp.DEG_NAME;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No record found!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void AttendanceProccess()
        {
            try
            {
                //aAttendance_RPT_Bll.UpdateAttStatus_ByDate(Convert.ToDateTime(txtbxFrom.Text), Convert.ToDateTime(txtbxTo.Text));
                //aAttendance_RPT_Bll.Update_AbsentLeaveStatus_ByDate(Convert.ToDateTime(txtbxFrom.Text), Convert.ToDateTime(txtbxTo.Text));

                List<Attendance_Viewer> empAtendance = new List<Attendance_Viewer>();
                string fromDate = txtbxFrom.Text;
                string toDate = txtbxTo.Text;
                //int RegionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                //int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
                //int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);

                //daily attendance report

                if (rdbDailyAttendance.Checked)
                {
                    if (fromDate == toDate)
                    {
                        if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            empAtendance = aAttendance_RPT_Bll.GetAttendanceAllEmpForAllBySubSection_Comp(Convert.ToInt32(ddlSubSections.SelectedValue), Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAllEmpDailyBySubSection.rdlc";
                                Session["rptTitle"] = "All Employee Attendance";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                        {
                            empAtendance = aAttendance_RPT_Bll.GetAttendanceAllEmpForAllBySection_Comp(Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAllEmpDailyBySection.rdlc";
                                Session["rptTitle"] = "All Employee Attendance";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                        {
                            empAtendance = aAttendance_RPT_Bll.GetAttendanceAllEmpForAllByDept_Comp(Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAllEmpDailyByDept.rdlc";
                                Session["rptTitle"] = "All Employee Attendance";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else
                        {
                            empAtendance = aAttendance_RPT_Bll.GetAttendanceAllEmpForAll_Comp(fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAllEmpDaily.rdlc";
                                Session["rptTitle"] = "All Employee Attendance";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select information for search!')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select same date for daily report!')", true);
                    }
                }

                //daily absent report

                else if (rdbDailyAbsentReport.Checked == true)
                {
                    if (fromDate == toDate)
                    {
                        if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            empAtendance = aAttendance_RPT_Bll.GetAbsentAllEmpForAllBySubSection(Convert.ToInt32(ddlSubSections.SelectedValue), Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), "A", fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_DailyAbsentBySubSection.rdlc";
                                Session["rptTitle"] = "All Employee Attendance";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                        {
                            empAtendance = aAttendance_RPT_Bll.GetAbsentAllEmpForAllBySection(Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), "A", fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_DailyAbsentBySection.rdlc";
                                Session["rptTitle"] = "All Employee Attendance";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                        {
                            empAtendance = aAttendance_RPT_Bll.GetAbsentAllEmpForAllByDept(Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), "A", fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_DailyAbsentByDept.rdlc";
                                Session["rptTitle"] = "All Employee Attendance";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text == "--Select--")
                        {
                            empAtendance = aAttendance_RPT_Bll.GetAbsentAllEmpForAllByByOffice(Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), "A", fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_DailyAbsentByOffice.rdlc";
                                Session["rptTitle"] = "All Employee Attendance";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else
                        {
                            empAtendance = aAttendance_RPT_Bll.GetAbsentAllEmpForAll("A", fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_DailyAbsentAll.rdlc";
                                Session["rptTitle"] = "All Employee Attendance";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select information for search!')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select same date for daily report!')", true);
                    }

                }

                //daily late report

                else if (rdbDailyLateReport.Checked == true)
                {
                    if (fromDate == toDate)
                    {
                        if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            empAtendance = aAttendance_RPT_Bll.GetAbsentAllEmpForAllBySubSection(Convert.ToInt32(ddlSubSections.SelectedValue), Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), "L", fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_DailyLateBySubSection.rdlc";
                                Session["rptTitle"] = "All Employee Attendance";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                        {
                            empAtendance = aAttendance_RPT_Bll.GetAbsentAllEmpForAllBySection(Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), "L", fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_DailyLateBySection.rdlc";
                                Session["rptTitle"] = "All Employee Attendance";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                        {
                            empAtendance = aAttendance_RPT_Bll.GetAbsentAllEmpForAllByDept(Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), "L", fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_DailyLateByDept.rdlc";
                                Session["rptTitle"] = "All Employee Attendance";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else
                        {
                            empAtendance = aAttendance_RPT_Bll.GetAbsentAllEmpForAll("L", fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_DailyLateAll.rdlc";
                                Session["rptTitle"] = "All Employee Attendance";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select information for search!')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select same date for daily report!')", true);
                    }

                }

                //daily attendance summary report

                else if (rdbDailyAttendanceSummary.Checked)
                {
                    if (fromDate == toDate)
                    {
                        if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Line wise report!')", true);
                        }
                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                        {
                            empAtendance = aAttendance_RPT_Bll.DailyAttendanceSummmaryBySection(Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_DailyAttendanceSummaryBySection.rdlc";
                                Session["rptTitle"] = "All Employee Attendance";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text == "--Select--")
                        {
                            empAtendance = aAttendance_RPT_Bll.DailyAttendanceSummmaryByOffice(Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_DailyAttendanceSummaryByOfiice.rdlc";
                                Session["rptTitle"] = "All Employee Attandence";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                        {
                            empAtendance = aAttendance_RPT_Bll.DailyAttendanceSummmaryByDept(Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_DailyAttendanceSummaryByDept.rdlc";
                                Session["rptTitle"] = "All Employee Attandence";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select information for search!')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select same date for daily report!')", true);
                    }
                }

                //daily attendance summary designation wise report

                else if (rdbDailyAttendanceSummaryByDesignation.Checked)
                {
                    if (fromDate == toDate)
                    {
                        if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Line wise report!')", true);
                        }
                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                        {
                            empAtendance = aAttendance_RPT_Bll.DailyAttendanceSummmaryBySection_Designationwise(Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_DailyAttendanceSummaryBySection_Designationwise.rdlc";
                                Session["rptTitle"] = "All Employee Attandence";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                        {
                            empAtendance = aAttendance_RPT_Bll.DailyAttendanceSummmaryByDept_Designationwise(Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_DailyAttendanceSummaryByDept_Designationwise.rdlc";
                                Session["rptTitle"] = "All Employee Attandence";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select information for search!')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select same date for daily report!')", true);
                    }
                }

                //daily attendance report

                if (rdbDailySinglePunchList.Checked)
                {
                    if (fromDate == toDate)
                    {
                        if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            empAtendance = aAttendance_RPT_Bll.GetSinglePunchListBySubSection(Convert.ToInt32(ddlSubSections.SelectedValue), Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_SinglePunchDailyBySubSection.rdlc";
                                Session["rptTitle"] = "All Employee Attandence";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                        {
                            empAtendance = aAttendance_RPT_Bll.GetSinglePunchBySection(Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_SinglePunchDailyBySection.rdlc";
                                Session["rptTitle"] = "All Employee Attandence";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                        {
                            empAtendance = aAttendance_RPT_Bll.GetSinglePunchByDept(Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_SinglePunchDailyByDept.rdlc";
                                Session["rptTitle"] = "All Employee Attandence";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }

                        else
                        {
                            empAtendance = aAttendance_RPT_Bll.GetSinglePunchForAll(fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_SinglePunchAllEmpDaily.rdlc";
                                Session["rptTitle"] = "All Employee Attandence";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                            //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select information for search!')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select same date for daily report!')", true);
                    }
                }


                //current date leave report
                else if (rdbAllLeave.Checked)
                {
                    string today = DateTime.Today.ToString();
                    empAtendance = aAttendance_RPT_Bll.GetAllEmployeeLeave(today).ToList();
                    if (empAtendance.Count > 0)
                    {
                        Session["rptDs"] = "DS_AllEmployeeLeave";
                        Session["rptDt"] = empAtendance;
                        Session["rptFile"] = "/HRM/reports/HRM_RPT_AllEmployeeDailyLeave.rdlc";
                        Session["rptTitle"] = "All Employee Daily Leave";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }


                //monthly attendance report
                else if (rdbMonthlyAttendance.Checked)
                {


                    if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                    {
                        empAtendance = aAttendance_RPT_Bll.MonthlyAttendanceBySubSection(Convert.ToInt32(ddlSubSections.SelectedValue), Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AllEmpMonthlyAttendanceBySubSection.rdlc";
                            Session["rptTitle"] = "All Employee Attendance";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }
                    else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                    {
                        empAtendance = aAttendance_RPT_Bll.MonthlyAttendanceBySection(Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "DS_AllEmpDailyAttBySec";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AllEmpMonthlyAttBySec.rdlc";
                            Session["rptTitle"] = "All Employee Attendance";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }
                    else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                    {
                        empAtendance = aAttendance_RPT_Bll.MonthlyAttendanceByDept(Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AllEmpMonthlyAttendanceByDept.rdlc";
                            Session["rptTitle"] = "All Employee Attendance";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }

                    else
                    {
                        empAtendance = aAttendance_RPT_Bll.MonthlyAttendanceAll(fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_Rpt_AllEmpMonthlyAttendance.rdlc";
                            Session["rptTitle"] = "All Employee Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select information for search!')", true);
                    }

                }

                //monthly all attendance report
                else if (rdbMonthlyAllAttendance.Checked)
                {
                    if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                    {
                        empAtendance = aAttendance_RPT_Bll.MonthlyAttendanceBySubSection(Convert.ToInt32(ddlSubSections.SelectedValue), Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_Rpt_AllEmpMonthlyAllAttendanceBySubSection.rdlc";
                            Session["rptTitle"] = "All Employee Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }
                    else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                    {
                        empAtendance = aAttendance_RPT_Bll.MonthlyAttendanceBySection(Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "DS_AllEmpDailyAttBySec";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AllEmpMonthlyAllAttendanceBySection.rdlc";
                            Session["rptTitle"] = "All Employee Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }
                    else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                    {
                        empAtendance = aAttendance_RPT_Bll.MonthlyAttendanceByDept(Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_Rpt_AllEmpMonthlyAllAttendanceByDept.rdlc";
                            Session["rptTitle"] = "All Employee Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }

                    else
                    {
                        empAtendance = aAttendance_RPT_Bll.MonthlyAttendanceAll(fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_Rpt_AllEmpMonthlyAllAttendance.rdlc";
                            Session["rptTitle"] = "All Employee Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select information for search!')", true);
                    }

                }

                //monthly present report

                else if (rdbMonthlyPresent.Checked)
                {
                    if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                    {
                        empAtendance = aAttendance_RPT_Bll.MonthlyPresentBySubSection(Convert.ToInt32(ddlSubSections.SelectedValue), Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AllEmpMonthlyPresentBySubSection.rdlc";
                            Session["rptTitle"] = "All Employee Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }
                    else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                    {
                        empAtendance = aAttendance_RPT_Bll.MonthlyPresentBySection(Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AllEmpMonthlyPresentBySection.rdlc";
                            Session["rptTitle"] = "All Employee Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }
                    else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                    {
                        empAtendance = aAttendance_RPT_Bll.MonthlyAttendanceForLeaveforDept(Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AllEmpMonthlyPresentByDept.rdlc";
                            Session["rptTitle"] = "All Employee Attendance";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }

                    else
                    {
                        empAtendance = aAttendance_RPT_Bll.MonthlyAttendanceForLeave(fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_Rpt_AllEmpMonthlyPresent.rdlc";
                            Session["rptTitle"] = "All Employee Attendance";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select information for search!')", true);
                    }
                }

                //monthly absent report

                else if (rdbMonthlyAbsent.Checked)
                {
                    if (txtAbsentDay.Text != "")
                    {
                        if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            int AbsentDay = Convert.ToInt32(txtAbsentDay.Text);
                            empAtendance = aAttendance_RPT_Bll.MonthlyAbsentbyDaySubSectionWise(Convert.ToInt32(ddlSubSections.SelectedValue), Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate, AbsentDay).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AllEmpAbesntDay";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_AllEmpAbsentByDaySubSection.rdlc";
                                Session["rptTitle"] = "All Employee Absent Day";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                        {
                            int AbsentDay = Convert.ToInt32(txtAbsentDay.Text);
                            empAtendance = aAttendance_RPT_Bll.MonthlyAbsentbyDaySectionWise(Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate, AbsentDay).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AllEmpAbesntDay";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_AllEmpAbsentByDaySection.rdlc";
                                Session["rptTitle"] = "All Employee Absent Day";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--")
                        {
                            int AbsentDay = Convert.ToInt32(txtAbsentDay.Text);
                            empAtendance = aAttendance_RPT_Bll.MonthlyAbsentbyDayDeptWise(Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate, AbsentDay).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AllEmpAbesntDay";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_AllEmpAbsentByDayDept.rdlc";
                                Session["rptTitle"] = "All Employee Absent Day";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--")
                        {
                            int AbsentDay = Convert.ToInt32(txtAbsentDay.Text);
                            empAtendance = aAttendance_RPT_Bll.MonthlyAbsentbyDayOfficeWise(Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate, AbsentDay).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AllEmpAbesntDay";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_AllEmpAbsentByDayOffice.rdlc";
                                Session["rptTitle"] = "All Employee Absent Day";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else if (ddlRegion1.SelectedItem.Text != "--Select--")
                        {
                            int AbsentDay = Convert.ToInt32(txtAbsentDay.Text);
                            empAtendance = aAttendance_RPT_Bll.MonthlyAbsentbyDayRegionWise(Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate, AbsentDay).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AllEmpAbesntDay";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_AllEmpAbsentByDayRegion.rdlc";
                                Session["rptTitle"] = "All Employee Absent Day";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else
                        {
                            int AbsentDay = Convert.ToInt32(txtAbsentDay.Text);
                            empAtendance = aAttendance_RPT_Bll.MonthlyAbsentbyDay(fromDate, toDate, AbsentDay).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AllEmpAbesntDay";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_AllEmpAbsentByDay.rdlc";
                                Session["rptTitle"] = "All Employee Absent Day";
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
                        if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            empAtendance = aAttendance_RPT_Bll.MonthlyAbsentBySubSection(Convert.ToInt32(ddlSubSections.SelectedValue), Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                            if (empAtendance.Count > 0)
                            {
                                Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                                Session["rptDt"] = empAtendance;
                                Session["rptFile"] = "/HRM/reports/HRM_RPT_AllEmpMonthlyAbsentBySubSection.rdlc";
                                Session["rptTitle"] = "All Employee Attendance";
                                Response.Redirect("Report_Viewer.aspx");
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            }
                        }
                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                        {
                            //empAtendance = aAttendance_RPT_Bll.MonthlyPresentBySection(Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                            //if (empAtendance.Count > 0)
                            //{
                            //    Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                            //    Session["rptDt"] = empAtendance;
                            //    Session["rptFile"] = "/HRM/reports/HRM_Rpt_AllEmpMonthlyPresentBySection.rdlc";
                            //    Session["rptTitle"] = "All Employee Attendance";
                            //    Response.Redirect("Report_Viewer.aspx");
                            //}
                            //else
                            //{
                            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            //}
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Section wise report!')", true);
                        }
                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                        {
                            //empAtendance = aAttendance_RPT_Bll.MonthlyAttendanceForLeaveforDept(Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                            //if (empAtendance.Count > 0)
                            //{
                            //    Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                            //    Session["rptDt"] = empAtendance;
                            //    Session["rptFile"] = "/HRM/reports/HRM_Rpt_AllEmpMonthlyPresentByDept.rdlc";
                            //    Session["rptTitle"] = "All Employee Attendance";
                            //    Response.Redirect("Report_Viewer.aspx");
                            //}
                            //else
                            //{
                            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            //}
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Department wise report!')", true);
                        }

                        else
                        {
                            //empAtendance = aAttendance_RPT_Bll.MonthlyAttendanceForLeave(fromDate, toDate).ToList();
                            //if (empAtendance.Count > 0)
                            //{
                            //    Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                            //    Session["rptDt"] = empAtendance;
                            //    Session["rptFile"] = "/HRM/reports/HRM_Rpt_AllEmpMonthlyPresent.rdlc";
                            //    Session["rptTitle"] = "All Employee Attendance";
                            //    Response.Redirect("Report_Viewer.aspx");
                            //}
                            //else
                            //{
                            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            //}
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select information for search!')", true);
                        }
                    }
                }

                //monthly attendance summary report

                else if (rdbMonthlyAttendanceSummary.Checked)
                {
                    if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Line wise report!')", true);
                    }
                    else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                    {
                        empAtendance = aAttendance_RPT_Bll.MonthlyAttendanceSummmaryBySection(Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_MonthlyAttendanceSummaryBySection.rdlc";
                            Session["rptTitle"] = "All Employee Attendance";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }
                    else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                    {
                        empAtendance = aAttendance_RPT_Bll.MonthlyAttendanceSummmaryByDept(Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_MonthlyAttendanceSummaryByDept.rdlc";
                            Session["rptTitle"] = "All Employee Attendance";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }

                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select information for search!')", true);
                    }

                }

                #region rdbMonthlyOvertimeList

                else if (rdbMonthlyOvertimeList.Checked)
                {
                    if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                    {
                        //empAtendance = aAttendance_RPT_Bll.MonthlyAttendanceBySubSection(Convert.ToInt32(ddlSubSections.SelectedValue), Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                        //if (empAtendance.Count > 0)
                        //{
                        //    Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                        //    Session["rptDt"] = empAtendance;
                        //    Session["rptFile"] = "/HRM/reports/HRM_Rpt_AllEmpMonthlyAttendanceBySubSection.rdlc";
                        //    Session["rptTitle"] = "All Employee Attendance";
                        //    Response.Redirect("Report_Viewer.aspx");
                        //}
                        //else
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        //}
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Line wise report!')", true);
                    }
                    else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                    {
                        //empAtendance = aAttendance_RPT_Bll.MonthlyAttendanceBySection(Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                        //if (empAtendance.Count > 0)
                        //{
                        //    Session["rptDs"] = "DS_AllEmpDailyAttBySec";
                        //    Session["rptDt"] = empAtendance;
                        //    Session["rptFile"] = "/HRM/reports/HRM_RPT_AllEmpMonthlyAttBySec.rdlc";
                        //    Session["rptTitle"] = "All Employee Attendance";
                        //    Response.Redirect("Report_Viewer.aspx");
                        //}
                        //else
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        //}
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Section wise report!')", true);
                    }

                    else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                    {
                        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                        empAtendance = aAttendance_RPT_Bll.MonthlyOTByDept_Com(Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate, OCODE).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_Rpt_AllEmpMonthlyOTByDept.rdlc";
                            Session["rptTitle"] = "All Employee Attendance";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }
                    else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text == "--Select--")
                    {
                        //string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                        //empAtendance = aAttendance_RPT_Bll.MonthlyOTByDept(Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate, OCODE).ToList();
                        //if (empAtendance.Count > 0)
                        //{
                        //    Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                        //    Session["rptDt"] = empAtendance;
                        //    Session["rptFile"] = "/HRM/reports/HRM_Rpt_AllEmpMonthlyOT.rdlc";
                        //    Session["rptTitle"] = "All Employee Attendance";
                        //    Response.Redirect("Report_Viewer.aspx");
                        //}
                        //else
                        //{
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Office Wise Report!')", true);
                        //}
                    }
                    else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text == "--Select--")
                    {
                        //string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                        //empAtendance = aAttendance_RPT_Bll.MonthlyOTByDept(Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate, OCODE).ToList();
                        //if (empAtendance.Count > 0)
                        //{
                        //    Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                        //    Session["rptDt"] = empAtendance;
                        //    Session["rptFile"] = "/HRM/reports/HRM_Rpt_AllEmpMonthlyOT.rdlc";
                        //    Session["rptTitle"] = "All Employee Attendance";
                        //    Response.Redirect("Report_Viewer.aspx");
                        //}
                        //else
                        //{
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Region Wise Report!')", true);
                        //}
                    }
                    else
                    {
                        empAtendance = aAttendance_RPT_Bll.MonthlyOTAll_Comp(fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_Rpt_AllEmpMonthlyOT.rdlc";
                            Session["rptTitle"] = "All Employee Attendance";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }
                }

                #endregion

                //monthly overtime summary report

                else if (rdbMonthlyOvertimeSummary.Checked)
                {
                    if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Line wise report!')", true);
                    }
                    //else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--")
                    //{
                    //    empAtendance = aAttendance_RPT_Bll.MonthlyAttendanceSummmaryBySection(Convert.ToInt32(ddlSection.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                    //    if (empAtendance.Count > 0)
                    //    {
                    //        Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                    //        Session["rptDt"] = empAtendance;
                    //        Session["rptFile"] = "/HRM/reports/HRM_RPT_MonthlyOvertimeSummaryBySection.rdlc";
                    //        Session["rptTitle"] = "All Employee Attendance";
                    //        Response.Redirect("Report_Viewer.aspx");
                    //    }
                    //    else
                    //    {
                    //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    //    }
                    //}
                    //else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                    //{
                    //    empAtendance = aAttendance_RPT_Bll.MonthlyAttendanceSummmaryByDept(Convert.ToInt32(ddlDept1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlRegion1.SelectedValue), fromDate, toDate).ToList();
                    //    if (empAtendance.Count > 0)
                    //    {
                    //        Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                    //        Session["rptDt"] = empAtendance;
                    //        Session["rptFile"] = "/HRM/reports/HRM_RPT_MonthlyOvertimeSummaryByDept.rdlc";
                    //        Session["rptTitle"] = "All Employee Attendance";
                    //        Response.Redirect("Report_Viewer.aspx");
                    //    }
                    //    else
                    //    {
                    //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    //    }
                    //}
                     else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--")
                    {
                        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                        empAtendance = aAttendance_RPT_Bll.MonthlyOTSummmaryByDept_Comp(Convert.ToInt32(ddlRegion1.SelectedValue), Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToInt32(ddlDept1.SelectedValue), fromDate, toDate, OCODE).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDailyByDeptDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_MonthlyOTSummaryByDept.rdlc";
                            Session["rptTitle"] = "All Employee Attendance";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select information for search!')", true);
                    }
                }

                //employee wise attendance compliance mode ot=<2

                else if (rdbMonthlyAttendanceEmpwise.Checked)
                {
                    if (txtEid1_AT.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Employee Selected!')", true);
                        return;
                    }
                    string empId = txtEid1_AT.Text;
                    //if (rdbAll.Checked)
                    {
                        string status = "ALL";
                        empAtendance = aAttendance_RPT_Bll.Get_EmpIndividual_Compliance_Report(empId, status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceIndividualEmpDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceEmpwise(Multiple)_Complice.rdlc";
                            Session["rptTitle"] = "Employee Id Wise Attendance";
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

            ////
        }

        protected void btnProcess1_Click(object sender, EventArgs e)
        {
            AttendanceProccess();
        }

        protected void btnAttProcess_Click(object sender, EventArgs e)
        {
            AttendanceProccess();
        }

    }
}