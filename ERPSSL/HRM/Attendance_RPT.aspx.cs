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
    public partial class Attendance_RPT : System.Web.UI.Page
    {
        EmployeeSetup_BLL objEmp_BLL = new EmployeeSetup_BLL();
        DEPARTMENT_BLL DepartmentBll = new DEPARTMENT_BLL();
        //EmployeeSetup_BLL employeeBll = new EmployeeSetup_BLL();
        Office_BLL objOfficeBLL = new Office_BLL();
        Attendance_RPT_Bll aAttendance_RPT_Bll = new Attendance_RPT_Bll();
        TIME_SCHEDULE_BLL timeScheduleBll = new TIME_SCHEDULE_BLL();

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
        private void GetShiftCodeList()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = timeScheduleBll.GetAllSchedule(OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlShiftCode.DataSource = row.ToList();
                    ddlShiftCode.DataTextField = "ShiftCode";
                    ddlShiftCode.DataValueField = "ScheduleId";
                    ddlShiftCode.DataBind();
                    ddlShiftCode.Items.Insert(0, new ListItem("------Select One------", "0"));
                }
            }
            catch (Exception)
            {

                throw;
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

        protected void ddlShiftCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string shiftCode = Convert.ToString(ddlShiftCode.SelectedItem.Text);

                var result = timeScheduleBll.GetScheduleByCode(OCODE, shiftCode).ToList();
                if (result.Count > 0)
                {
                    //var objShift = result.First();
                    //txtShift.Text = objShift.ShiftName;
                    //txtRegion.Text = objShift.HRM_Regions.RegionName;
                    //txtOffice.Text = objShift.HRM_Office.OfficeName;
                    //lblRegionId.Text = objShift.RegionId.ToString();
                    //lblOfficeId.Text = objShift.OfficeId.ToString();
                    //BindRegionByShift(shiftCode);
                    //BindOfficeByShift(shiftCode);
                    //TimeSpan in_time= objShift.StartTime;
                    //TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtStartTime.Hour, txtStartTime.Minute, txtStartTime.Second)) = objShift.StartTime;
                }
                else
                {
                    //lblMessage.Text = "<font color='red'>No record found</font>";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
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

                var row = objOfficeBLL.GetDeptByOfficeId(ResionId, OfficeId, OCODE).ToList();
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
                int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                BindShiftCodeByDepartment(RegionId, OfficeId, departmentId);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void BindShiftCodeByDepartment(int ResionId, int OfficeId, int departmentId)
        {
            try
            {
                var row = objOfficeBLL.GetShiftCodeByDept(ResionId, OfficeId, departmentId).ToList();
                if (row.Count > 0)
                {
                    ddlShiftCode.DataSource = row.ToList();
                    ddlShiftCode.DataTextField = "ShiftCode";
                    ddlShiftCode.DataValueField = "ScheduleId";
                    ddlShiftCode.DataBind();
                    ddlShiftCode.Items.Insert(0, new ListItem("--Select--"));
                }
                else
                {
                    ddlShiftCode.DataSource = null;
                    ddlShiftCode.DataTextField = "ShiftCode";
                    ddlShiftCode.DataValueField = "ScheduleId";
                    ddlShiftCode.DataBind();
                    ddlShiftCode.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


        //int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
        //int departmentId = Convert.ToInt32(depDepartment.SelectedValue);

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                List<Attendance_Viewer> empAtendance = new List<Attendance_Viewer>();
                string fromDate = txtbxFrom.Text;
                string toDate = txtbxTo.Text;

                //for Region Wise 
                if (rdRegion.Checked)
                {
                    int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                    if (rdbPresent.Checked)
                    {
                        string status = "P";
                        empAtendance = aAttendance_RPT_Bll.GetPresentAttendenceReport(ResionId, status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceRegionWiseSP";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceRegionWise.rdlc";
                            Session["rptTitle"] = "Region Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdbLate.Checked)
                    {
                        string status = "L";
                        empAtendance = aAttendance_RPT_Bll.GetPresentAttendenceReport(ResionId, status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceRegionWiseSP";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceRegionWise.rdlc";
                            Session["rptTitle"] = "Region Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdbOverLate.Checked)
                    {
                        string status = "OL";

                        empAtendance = aAttendance_RPT_Bll.GetPresentAttendenceReport(ResionId, status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceRegionWiseSP";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceRegionWise.rdlc";
                            Session["rptTitle"] = "Region Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdbAbsent.Checked)
                    {
                        string status = "A";

                        empAtendance = aAttendance_RPT_Bll.GetPresentAttendenceReport(ResionId, status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceRegionWiseSP";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceRegionWise.rdlc";
                            Session["rptTitle"] = "Region Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }
                    else if (rdbAll.Checked)
                    {
                        string status = "ALL";

                        empAtendance = aAttendance_RPT_Bll.GetPresentAttendenceReport(ResionId, status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceRegionWiseSP";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceRegionWise.rdlc";
                            Session["rptTitle"] = "Region Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }
                }

                //for All Region  
                if (rdAllRegion.Checked)
                {
                    if (rdbPresent.Checked)
                    {
                        string status = "P";
                        empAtendance = aAttendance_RPT_Bll.GetAllRegion(status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceAllRegionWiseDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceAllRegionWise.rdlc";
                            Session["rptTitle"] = "Region Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdbLate.Checked)
                    {
                        string status = "L";

                        empAtendance = aAttendance_RPT_Bll.GetAllRegion(status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceAllRegionWiseDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceAllRegionWise.rdlc";
                            Session["rptTitle"] = "Region Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdbOverLate.Checked)
                    {
                        string status = "OL";

                        empAtendance = aAttendance_RPT_Bll.GetAllRegion(status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceAllRegionWiseDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceAllRegionWise.rdlc";
                            Session["rptTitle"] = "Region Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdbAbsent.Checked)
                    {
                        string status = "A";

                        empAtendance = aAttendance_RPT_Bll.GetAllRegion(status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceAllRegionWiseDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceAllRegionWise.rdlc";
                            Session["rptTitle"] = "Region Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }
                    else if (rdbAll.Checked)
                    {
                        string status = "ALL";

                        empAtendance = aAttendance_RPT_Bll.GetAllRegion(status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceAllRegionWiseDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceAllRegionWise.rdlc";
                            Session["rptTitle"] = "Region Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }
                }

                //for Office 

                else if (rdOffice.Checked)
                {
                    int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                    int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                    if (rdbPresent.Checked)
                    {
                        string status = "P";
                        empAtendance = aAttendance_RPT_Bll.GetOfficeReport(ResionId, OfficeId, status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceOfficeWiseDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceOfficeWise.rdlc";
                            Session["rptTitle"] = "Office Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdbLate.Checked)
                    {
                        string status = "L";

                        empAtendance = aAttendance_RPT_Bll.GetOfficeReport(ResionId, OfficeId, status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceOfficeWiseDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceOfficeWise.rdlc";
                            Session["rptTitle"] = "Office Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdbOverLate.Checked)
                    {
                        string status = "OL";

                        empAtendance = aAttendance_RPT_Bll.GetOfficeReport(ResionId, OfficeId, status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceOfficeWiseDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceOfficeWise.rdlc";
                            Session["rptTitle"] = "office Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdbAbsent.Checked)
                    {
                        string status = "A";
                        empAtendance = aAttendance_RPT_Bll.GetOfficeReport(ResionId, OfficeId, status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceOfficeWiseDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceOfficeWise.rdlc";
                            Session["rptTitle"] = "Office Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }
                    else if (rdbAll.Checked)
                    {
                        string status = "ALL";
                        empAtendance = aAttendance_RPT_Bll.GetOfficeReport(ResionId, OfficeId, status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceOfficeWiseDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceOfficeWise.rdlc";
                            Session["rptTitle"] = "Office Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }
                }

                //For Department

                else if (rdDepartment.Checked)
                {
                    int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                    int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                    int DeptId = Convert.ToInt32(depDepartment.SelectedValue);
                    if (rdbPresent.Checked)
                    {
                        string status = "P";
                        empAtendance = aAttendance_RPT_Bll.GetDepartmentReport(ResionId, OfficeId, DeptId, status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceDeptWiseDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceDeptWise.rdlc";
                            Session["rptTitle"] = "Dept Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdbLate.Checked)
                    {
                        string status = "L";

                        empAtendance = aAttendance_RPT_Bll.GetDepartmentReport(ResionId, OfficeId, DeptId, status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceDeptWiseDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceDeptWise.rdlc";
                            Session["rptTitle"] = "Dept Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdbOverLate.Checked)
                    {
                        string status = "OL";

                        empAtendance = aAttendance_RPT_Bll.GetDepartmentReport(ResionId, OfficeId, DeptId, status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceDeptWiseDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceDeptWise.rdlc";
                            Session["rptTitle"] = "Dept Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdbAbsent.Checked)
                    {
                        string status = "A";
                        empAtendance = aAttendance_RPT_Bll.GetDepartmentReport(ResionId, OfficeId, DeptId, status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceDeptWiseDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceDeptWise.rdlc";
                            Session["rptTitle"] = "Dept Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }
                    else if (rdbAll.Checked)
                    {
                        string status = "ALL";
                        empAtendance = aAttendance_RPT_Bll.GetDepartmentReport(ResionId, OfficeId, DeptId, status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceDeptWiseDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceDeptWise.rdlc";
                            Session["rptTitle"] = "Dept Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }
                }

                //For ShiftCode

                else if (rdShiftCode.Checked)
                {
                    int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                    int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                    int DeptId = Convert.ToInt32(depDepartment.SelectedValue);
                    string ShiftCode = ddlShiftCode.SelectedItem.Text;

                    if (rdbPresent.Checked)
                    {
                        string status = "P";
                        empAtendance = aAttendance_RPT_Bll.GetShiftCodeReport(RegionId, OfficeId, DeptId, status, fromDate, toDate, ShiftCode).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceShiftCodeWiseDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceShiftCodeWise.rdlc";
                            Session["rptTitle"] = "ShiftCode Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdbLate.Checked)
                    {
                        string status = "L";

                        empAtendance = aAttendance_RPT_Bll.GetShiftCodeReport(RegionId, OfficeId, DeptId, status, fromDate, toDate, ShiftCode).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceShiftCodeWiseDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceShiftCodeWise.rdlc";
                            Session["rptTitle"] = "ShiftCode Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdbOverLate.Checked)
                    {
                        string status = "OL";

                        empAtendance = aAttendance_RPT_Bll.GetShiftCodeReport(RegionId, OfficeId, DeptId, status, fromDate, toDate, ShiftCode).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceShiftCodeWiseDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceShiftCodeWise.rdlc";
                            Session["rptTitle"] = "ShiftCode Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdbAbsent.Checked)
                    {
                        string status = "A";
                        empAtendance = aAttendance_RPT_Bll.GetShiftCodeReport(RegionId, OfficeId, DeptId, status, fromDate, toDate, ShiftCode).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceShiftCodeWiseDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceShiftCodeWise.rdlc";
                            Session["rptTitle"] = "ShiftCode Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }
                    else if (rdbAll.Checked)
                    {
                        string status = "ALL";
                        empAtendance = aAttendance_RPT_Bll.GetShiftCodeReport(RegionId, OfficeId, DeptId, status, fromDate, toDate, ShiftCode).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_AttendanceShiftCodeWiseDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_AttendanceShiftCodeWise.rdlc";
                            Session["rptTitle"] = "ShiftCode Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }
                }


                //For Individual Employee Report

                else if (rdIndividual.Checked)
                {
                    string empId = txtEid_AT.Text;
                    if (rdbPresent.Checked)
                    {
                        string status = "P";
                        empAtendance = aAttendance_RPT_Bll.GetEmpIndividualReport(empId, status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceIndividualEmpDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceIndividualEmp.rdlc";
                            Session["rptTitle"] = "Employee Id Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdbLate.Checked)
                    {
                        string status = "L";
                        empAtendance = aAttendance_RPT_Bll.GetEmpIndividualReport(empId, status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceIndividualEmpDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceIndividualEmp.rdlc";
                            Session["rptTitle"] = "Employee Id Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdbOverLate.Checked)
                    {
                        string status = "OL";
                        empAtendance = aAttendance_RPT_Bll.GetEmpIndividualReport(empId, status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceIndividualEmpDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceIndividualEmp.rdlc";
                            Session["rptTitle"] = "Employee Id Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdbAbsent.Checked)
                    {
                        string status = "A";
                        empAtendance = aAttendance_RPT_Bll.GetEmpIndividualReport(empId, status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceIndividualEmpDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceIndividualEmp.rdlc";
                            Session["rptTitle"] = "Employee Id Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }
                }

                else if (rdbEmpwiseAll.Checked)
                {
                    string empId = txtEid_AT.Text;
                    if (rdbAll.Checked)
                    {
                        string status = "ALL";
                        empAtendance = aAttendance_RPT_Bll.GetEmpIndividualReport(empId, status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceIndividualEmpDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceEmpwise(All).rdlc";
                            Session["rptTitle"] = "Employee Id Wise Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }
                }

                //Absent Report For All Employee
                else if (rdbEmpAbsent.Checked)
                {
                    string status = "A";
                    empAtendance = aAttendance_RPT_Bll.GetAttendanceAllEmp(status, fromDate, toDate).ToList();
                    if (empAtendance.Count > 0)
                    {
                        Session["rptDs"] = "HRM_RPT_AttendanceLateAbsentAllEmpDS";
                        Session["rptDt"] = empAtendance;
                        Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAbsentAllEmp.rdlc";
                        Session["rptTitle"] = "All Employee Attandence";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                }

                //Late Report For All Employee  
                else if (rdAllEmpLate.Checked)
                {
                    string status = "L";
                    empAtendance = aAttendance_RPT_Bll.GetAttendanceAllEmp(status, fromDate, toDate).ToList();
                    if (empAtendance.Count > 0)
                    {
                        Session["rptDs"] = "HRM_RPT_AttendanceLateAbsentAllEmpDS";
                        Session["rptDt"] = empAtendance;
                        Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceLateAllEmp.rdlc";
                        Session["rptTitle"] = "All Employee Attandence";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                }

                else if (rdbAllEmp.Checked)
                {
                    if (rdbAll.Checked)
                    {
                        string status = "ALL";
                        empAtendance = aAttendance_RPT_Bll.GetAttendanceAllEmp(status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAllEmp.rdlc";
                            Session["rptTitle"] = "All Employee Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }
                }
                //Epmloyee All Info
                else if (rdbAllEmpStatuswise.Checked)
                {
                    if (rdbPresent.Checked)
                    {
                        string status = "P";
                        empAtendance = aAttendance_RPT_Bll.GetAttendanceAllEmp(status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAllEmp.rdlc";
                            Session["rptTitle"] = "All Employee Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdbLate.Checked)
                    {
                        string status = "L";
                        empAtendance = aAttendance_RPT_Bll.GetAttendanceAllEmp(status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAllEmp.rdlc";
                            Session["rptTitle"] = "All Employee Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdbOverLate.Checked)
                    {
                        string status = "OL";
                        empAtendance = aAttendance_RPT_Bll.GetAttendanceAllEmp(status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAllEmp.rdlc";
                            Session["rptTitle"] = "All Employee Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }

                    else if (rdbAbsent.Checked)
                    {
                        string status = "A";
                        empAtendance = aAttendance_RPT_Bll.GetAttendanceAllEmp(status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAllEmp.rdlc";
                            Session["rptTitle"] = "All Employee Attandence";
                            Response.Redirect("Report_Viewer.aspx");
                        }
                    }
                }

                else if (rdbAllEmp.Checked)
                {
                    if (rdbAll.Checked)
                    {
                        string status = "ALL";
                        empAtendance = aAttendance_RPT_Bll.GetAttendanceAllEmp(status, fromDate, toDate).ToList();
                        if (empAtendance.Count > 0)
                        {
                            Session["rptDs"] = "HRM_RPT_AttendanceAllEmpDS";
                            Session["rptDt"] = empAtendance;
                            Session["rptFile"] = "/HRM/reports/HRM_RPT_AttendanceAllEmp.rdlc";
                            Session["rptTitle"] = "All Employee Attandence";
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
    }
}