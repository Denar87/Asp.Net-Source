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
    public partial class Attendance_InOut_Update : System.Web.UI.Page
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

        protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerChkBox = ((CheckBox)grdview.HeaderRow.FindControl("headerLevelCheckBox"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = false;
                    }
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
                if (ddlRegion1.SelectedItem.ToString() == "--Select--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Region')", true);
                }
                else if (txtDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Date')", true);
                }
                else if (drpEntryType.SelectedItem.ToString() == "Select Entry Type")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Entry Type')", true);
                }
                else
                {
                    try
                    {
                        Attendance_BLL _attendancebll = new Attendance_BLL();
                        if (ddlSubSections.SelectedValue.ToString() == "" || ddlSubSections.SelectedValue.ToString() == "0" || ddlSection.SelectedValue.ToString() == "" || ddlSection.SelectedValue.ToString() == "0")
                        {
                            int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);

                            List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByOfficeID(DeptId, Convert.ToDateTime(txtDate.Text));
                            List<HRM_EMPLOYEES_VIEWER> newemployess = new List<HRM_EMPLOYEES_VIEWER>();

                            foreach (HRM_EMPLOYEES_VIEWER aitem in employess)
                            {
                                HRM_EMPLOYEES_VIEWER aemployee = new HRM_EMPLOYEES_VIEWER();
                                aemployee.EID = aitem.EID;

                                aemployee.EmployeeFullName = aitem.FirstName + " " + aitem.LastName;
                                aemployee.DEG_NAME = aitem.DEG_NAME;
                                //aemployee.EMP_ID = Convert.ToInt32(aitem.EID);
                                aemployee.Is_Holiday = aitem.Is_Holiday;
                                aemployee.DATE_JOINED = Convert.ToDateTime(txtDate.Text);
                                TimeSpan in_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtAttInTime.Hour, txtAttInTime.Minute, txtAttInTime.Second));
                                aemployee.Shift_TotalHour = in_time;
                                newemployess.Add(aemployee);
                            }

                            List<HRM_EMPLOYEES_VIEWER> ascendingnewemployees = newemployess.OrderBy(x => x.EID).ToList();

                            if (ascendingnewemployees.Count > 0)
                            {
                                grdview.DataSource = ascendingnewemployees;
                                grdview.DataBind();
                            }
                        }
                        else
                        {
                            int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                            int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
                            int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);
                            int sction = Convert.ToInt32(ddlSection.SelectedValue);
                            int subsction = Convert.ToInt32(ddlSubSections.SelectedValue);

                            List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByRODSSUID(ResionId, OfficeId, DeptId, sction, subsction, Convert.ToDateTime(txtDate.Text));
                            List<HRM_EMPLOYEES_VIEWER> newemployess = new List<HRM_EMPLOYEES_VIEWER>();

                            foreach (HRM_EMPLOYEES_VIEWER aitem in employess)
                            {
                                HRM_EMPLOYEES_VIEWER aemployee = new HRM_EMPLOYEES_VIEWER();
                                aemployee.EID = aitem.EID;
                                //aemployee.EMP_ID = Convert.ToInt32(aitem.EID);
                                aemployee.EmployeeFullName = aitem.FirstName + " " + aitem.LastName;
                                aemployee.DEG_NAME = aitem.DEG_NAME;
                                aemployee.DATE_JOINED = Convert.ToDateTime(txtDate.Text);
                                aemployee.Is_Holiday = aitem.Is_Holiday;
                                TimeSpan in_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtAttInTime.Hour, txtAttInTime.Minute, txtAttInTime.Second));
                                aemployee.Shift_TotalHour = in_time;
                                newemployess.Add(aemployee);
                            }
                            List<HRM_EMPLOYEES_VIEWER> assendingnewemployess = newemployess.OrderBy(x => x.EID).ToList();

                            if (assendingnewemployess.Count > 0)
                            {
                                grdview.DataSource = assendingnewemployess;
                                grdview.DataBind();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btn_Confirm_Clcik(object sender, EventArgs e)
        {
            try
            {
                Attendance_BLL _attendancebll = new Attendance_BLL();
                List<HRM_ATTENDANCE> attendances = new List<HRM_ATTENDANCE>();

                foreach (GridViewRow gvRow in grdview.Rows)
                {
                    CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                    HRM_ATTENDANCE _attendance = new HRM_ATTENDANCE();

                    if (rowChkBox.Checked == true)
                    {
                        Label lblEID = ((Label)gvRow.FindControl("lblEID"));
                        Label lblWorkingDay = ((Label)gvRow.FindControl("lblWorkingDay"));
                        TextBox txtbx = ((TextBox)gvRow.FindControl("txtbx"));

                        if (drpEntryType.SelectedValue == "In-Time")
                        {
                            _attendance.In_Time = TimeSpan.Parse(txtbx.Text);
                            _attendance.Out_Time = TimeSpan.Parse(txtbx.Text);
                        }
                        else
                        {
                            _attendance.In_Time = TimeSpan.Parse(txtbx.Text);
                            _attendance.Out_Time = TimeSpan.Parse(txtbx.Text);
                        }
                        _attendance.EID = lblEID.Text;
                        _attendance.Attendance_Date = Convert.ToDateTime(txtDate.Text);
                        _attendance.Attendance_Day = Convert.ToDateTime(txtDate.Text).DayOfWeek.ToString();
                        _attendance.Working_Day = lblWorkingDay.Text;
                        _attendance.Remarks = txtbxremark.Text;
                        _attendance.Attendance_Process_Status = true;
                        _attendance.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                        _attendance.Edit_Date = DateTime.Now;
                        _attendance.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;

                        attendances.Add(_attendance);
                    }
                }

                if (attendances.Count > 0)
                {
                    string type = drpEntryType.SelectedValue.ToString();
                    int result = _attendancebll.UpdateAttendance(attendances, type);
                    if (result == 1)
                    {
                        ClearUI();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Employee selected in the list!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearUI()
        {
            ddlSection.ClearSelection();
            ddlSubSections.ClearSelection();
            txtbxremark.Text = "";
            txtDate.Text = "";
            drpEntryType.ClearSelection();
            grdview.DataSource = null;
            grdview.DataBind();
        }

        protected void grdview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.Row.Cells[6].Text))
            {
                if (e.Row.Cells[6].Text == "Hoilday")
                {
                    e.Row.Cells[6].ForeColor = System.Drawing.Color.Red;
                    e.Row.Cells[6].BackColor = System.Drawing.Color.Wheat;
                }
            }
        }

    }
}
