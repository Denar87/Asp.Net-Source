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
using System.Data.SqlClient;

namespace ERPSSL.HRM
{
    public partial class ExtraShiftEmployeewise : System.Web.UI.Page
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
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();
        Attendance_BLL aAttendance_BLL = new Attendance_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    divEid.Visible = false;
                    divDesgination.Visible = false;
                    divName.Visible = false;
                    divIndiDepartment.Visible = false;
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
            catch (Exception ex)
            {
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //    LogController<ExtraShiftEmployeewise>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
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
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                // LogController<ExtraShiftEmployeewise>.SetLog(ex, EID);
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
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //  LogController<ExtraShiftEmployeewise>.SetLog(ex, EID);
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
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                // LogController<ExtraShiftEmployeewise>.SetLog(ex, EID);
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
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //  LogController<ExtraShiftEmployeewise>.SetLog(ex, EID);
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
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                // LogController<ExtraShiftEmployeewise>.SetLog(ex, EID);
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

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlRegion1.SelectedItem.ToString() == "--Select--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Region!')", true);
                }

                else if (ddlOffice1.SelectedItem.ToString() == "--Select--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Office!')", true);
                    return;
                }
                else if (ddlDept1.SelectedItem.ToString() == "--Select--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Department!')", true);
                    return;
                }

                else if (txtFromDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Extra Shift Date!')", true);
                    return;
                }

                else
                {
                    try
                    {
                        Attendance_BLL _attendancebll = new Attendance_BLL();

                        //sub-section wise process

                        if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text != "--Select--")
                        {
                            int ResionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                            int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
                            int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);
                            int sction = Convert.ToInt32(ddlSection.SelectedValue);
                            int subsction = Convert.ToInt32(ddlSubSections.SelectedValue);

                            List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByRODSSUID(ResionId, OfficeId, DeptId, sction, subsction);
                            List<HRM_EMPLOYEES_VIEWER> newemployess = new List<HRM_EMPLOYEES_VIEWER>();

                            foreach (HRM_EMPLOYEES_VIEWER aitem in employess)
                            {
                                HRM_EMPLOYEES_VIEWER aemployee = new HRM_EMPLOYEES_VIEWER();
                                aemployee.EID = aitem.EID;
                                //  aemployee.EMP_ID = Convert.ToInt32(aitem.EMP_ID);
                                aemployee.EmployeeFullName = aitem.FirstName + " " + aitem.LastName;
                                aemployee.DEG_NAME = aitem.DEG_NAME;
                                aemployee.DATE_JOINED = Convert.ToDateTime(txtFromDate.Text);
                                TimeSpan in_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtAttInTime.Hour, txtAttInTime.Minute, txtAttInTime.Second));
                                aemployee.Shift_TotalHour = in_time;
                                aemployee.SHIFTCODE = aitem.SHIFTCODE;
                                newemployess.Add(aemployee);
                            }

                            List<HRM_EMPLOYEES_VIEWER> assendingnewemployess = newemployess.OrderBy(x => x.EID).ToList();

                            if (assendingnewemployess.Count > 0)
                            {
                                grdview.DataSource = newemployess;
                                grdview.DataBind();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                                grdview.DataSource = null;
                                grdview.DataBind();
                            }
                        }


                        //section wise process

                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text != "--Select--" && ddlSubSections.SelectedItem.Text == "--Select--")
                        {
                            int regionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                            int officeId = Convert.ToInt32(ddlOffice1.SelectedValue);
                            int deptId = Convert.ToInt32(ddlDept1.SelectedValue);
                            int sectionId = Convert.ToInt32(ddlSection.SelectedValue);

                            List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeBySectionId(regionId, officeId, deptId, sectionId, Convert.ToDateTime(txtFromDate.Text));

                            if (employess.Count > 0)
                            {
                                List<HRM_EMPLOYEES_VIEWER> newemployess = new List<HRM_EMPLOYEES_VIEWER>();

                                foreach (HRM_EMPLOYEES_VIEWER aitem in employess)
                                {
                                    HRM_EMPLOYEES_VIEWER aemployee = new HRM_EMPLOYEES_VIEWER();
                                    aemployee.EID = aitem.EID;
                                    // aemployee.EMP_ID = Convert.ToInt32(aitem.EID);
                                    aemployee.EmployeeFullName = aitem.FirstName + " " + aitem.LastName;
                                    aemployee.DEG_NAME = aitem.DEG_NAME;
                                    aemployee.DATE_JOINED = Convert.ToDateTime(txtFromDate.Text);
                                    TimeSpan in_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtAttInTime.Hour, txtAttInTime.Minute, txtAttInTime.Second));
                                    aemployee.Shift_TotalHour = in_time;
                                    aemployee.SHIFTCODE = aitem.SHIFTCODE;
                                    newemployess.Add(aemployee);
                                }
                                List<HRM_EMPLOYEES_VIEWER> assendingnewemployess = newemployess.OrderBy(x => x.EID).ToList();

                                if (assendingnewemployess.Count > 0)
                                {
                                    grdview.DataSource = assendingnewemployess;
                                    grdview.DataBind();
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                                grdview.DataSource = null;
                                grdview.DataBind();
                            }
                        }


                        //department wise process

                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--")
                        {
                            int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);

                            List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByOfficeID(DeptId);

                            List<HRM_EMPLOYEES_VIEWER> newemployess = new List<HRM_EMPLOYEES_VIEWER>();

                            foreach (HRM_EMPLOYEES_VIEWER aitem in employess)
                            {
                                HRM_EMPLOYEES_VIEWER aemployee = new HRM_EMPLOYEES_VIEWER();
                                aemployee.EID = aitem.EID;
                                // aemployee.EMP_ID = Convert.ToInt32(aitem.EID);
                                aemployee.EmployeeFullName = aitem.FirstName + " " + aitem.LastName;
                                aemployee.DEG_NAME = aitem.DEG_NAME;
                                aemployee.DATE_JOINED = Convert.ToDateTime(txtFromDate.Text);
                                TimeSpan in_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtAttInTime.Hour, txtAttInTime.Minute, txtAttInTime.Second));
                                aemployee.Shift_TotalHour = in_time;
                                aemployee.SHIFTCODE = aitem.SHIFTCODE;
                                newemployess.Add(aemployee);
                            }

                            List<HRM_EMPLOYEES_VIEWER> assendingnewemployes = newemployess.OrderBy(x => x.EID).ToList();

                            if (assendingnewemployes.Count > 0)
                            {
                                grdview.DataSource = assendingnewemployes;
                                grdview.DataBind();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                                grdview.DataSource = null;
                                grdview.DataBind();
                            }
                        }

                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select information for process!')", true);
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
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                // LogController<ExtraShiftEmployeewise>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btn_Confirm_Clcik(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                DateTime EDIT_DATE = DateTime.Now;
                Guid userId = ((SessionUser)Session["SessionUser"]).UserId;

                Attendance_BLL _attendancebll = new Attendance_BLL();

                List<HRM_AttendanceReason_Individual> lstHRM_AttendanceReason_Individual = new List<HRM_AttendanceReason_Individual>();

                if (chkIndividualShift.Checked)   //individual process
                {
                    for (int i = 0; i < Convert.ToInt16(hdfTotalDay.Value); i++)
                    {
                        if (txtbxEID.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Enter E-ID!')", true);
                            return;
                        }
                        if (txtFromDate.Text == "")
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Attendance Date!')", true);
                            return;
                        }

                        HRM_AttendanceReason_Individual _attendance = new HRM_AttendanceReason_Individual();

                        string shiftCode = hdShiftCode.Value;
                        string EID = txtbxEID.Text;
                        DateTime fromdate = Convert.ToDateTime(txtFromDate.Text);

                        var getAttendancedata = aAttendance_BLL.GetAttendanceByEID_Date(OCODE, EID, Convert.ToDateTime(txtFromDate.Text));

                        List<HRM_AttendanceReason_Individual> a_HRM_AttendanceReason_Individual = aAttendance_BLL.GetHRM_AttendanceReason_Individual(EID, fromdate.AddDays(i));

                        if (a_HRM_AttendanceReason_Individual.Count == 0)  //insert
                        {
                            _attendance.EID = txtbxEID.Text;
                            _attendance.ReasonDate = fromdate.AddDays(i);
                            _attendance.Remarks = txtbxremark.Text;
                            _attendance.Status = "true";
                            _attendance.ShiftCode = shiftCode;
                            _attendance.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                            _attendance.Edit_Date = DateTime.Now;
                            _attendance.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;

                            TimeSpan start_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtAttInTime.Hour, txtAttInTime.Minute, txtAttInTime.Second));
                            _attendance.InTime = start_time;

                            TimeSpan end_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtAttOutTime.Hour, txtAttOutTime.Minute, txtAttOutTime.Second));
                            _attendance.OutTime = end_time;

                            TimeSpan lateAllowed = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtLateAllowed.Hour, txtLateAllowed.Minute, txtLateAllowed.Second));
                            _attendance.LateAllowed = lateAllowed;

                            TimeSpan totalHour, hour1, hour2;

                            if (start_time > end_time)
                            {
                                hour1 = TimeSpan.Parse("23:59:59");
                                hour2 = Calculations.timeDiff(start_time, hour1);
                                totalHour = hour2 + end_time;
                                _attendance.Shift_TotalHour = totalHour;
                            }
                            else
                            {
                                totalHour = Calculations.timeDiff(start_time, end_time);
                                _attendance.Shift_TotalHour = totalHour;
                            }

                            lstHRM_AttendanceReason_Individual.Add(_attendance);

                            _context.HRM_AttendanceReason_Individual.AddObject(_attendance);
                            try
                            {
                                _context.SaveChanges();

                                if (getAttendancedata.Count > 0)
                                {
                                    aAttendance_RPT_Bll.UpdateAll_AttStatus_ByDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtFromDate.Text)); // update attendnace status by date

                                    // insert/update leave/holiday attendnace status process by selected eid
                                    aAttendance_RPT_Bll.Insert_Update_AbsentLeaveStatus_ByDate_EID1(lstHRM_AttendanceReason_Individual, Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtFromDate.Text));

                                    //ot process

                                    List<string> ShiftCodes = aAttendance_BLL.GetAllShiftCode(OCODE).ToList();

                                    foreach (string ashiftcode in ShiftCodes)
                                    {
                                        aAttendance_BLL.UpdateOT_ByDateandShift(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtFromDate.Text), ashiftcode);
                                    }

                                    //ot process log
                                    var ParamempID1 = new SqlParameter("@DateFrom", Convert.ToDateTime(txtFromDate.Text));
                                    var ParamempID2 = new SqlParameter("@DateTo", Convert.ToDateTime(txtFromDate.Text));
                                    var ParamempID3 = new SqlParameter("@Edit_User", userId);
                                    var ParamempID4 = new SqlParameter("@Edit_Date", DateTime.Now);
                                    var ParamempID5 = new SqlParameter("@OCODE", OCODE);
                                    string SP_SQL = "HRM_Insert_OTProcessLog @DateFrom, @DateTo, @Edit_User, @Edit_Date, @OCODE";
                                    _context.ExecuteStoreCommand(SP_SQL, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5);
                                    //
                                }

                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Processed Successfully')", true);
                                grdview.DataSource = null;
                                grdview.DataBind();
                            }
                            catch (Exception ex)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                            }
                            //ClearUI();
                        }
                        else   //update
                        {
                            DateTime iDate = fromdate.AddDays(i);
                            foreach (var AttendanceReason in _context.HRM_AttendanceReason_Individual.Where(x => x.EID == EID && x.ReasonDate == iDate))
                            {
                                //AttendanceReason.ReasonDate = Convert.ToDateTime(txtFromDate.Text);
                                AttendanceReason.Remarks = txtbxremark.Text;
                                AttendanceReason.Status = "true";
                                AttendanceReason.ShiftCode = shiftCode;
                                AttendanceReason.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                                AttendanceReason.Edit_Date = DateTime.Now;
                                AttendanceReason.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;

                                TimeSpan start_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtAttInTime.Hour, txtAttInTime.Minute, txtAttInTime.Second));
                                AttendanceReason.InTime = start_time;

                                TimeSpan end_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtAttOutTime.Hour, txtAttOutTime.Minute, txtAttOutTime.Second));
                                AttendanceReason.OutTime = end_time;

                                TimeSpan lateAllowed = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtLateAllowed.Hour, txtLateAllowed.Minute, txtLateAllowed.Second));
                                _attendance.LateAllowed = lateAllowed;

                                TimeSpan totalHour, hour1, hour2;

                                if (start_time > end_time)
                                {
                                    hour1 = TimeSpan.Parse("23:59:59");
                                    hour2 = Calculations.timeDiff(start_time, hour1);
                                    totalHour = hour2 + end_time;
                                    AttendanceReason.Shift_TotalHour = totalHour;
                                }
                                else
                                {
                                    totalHour = Calculations.timeDiff(start_time, end_time);
                                    AttendanceReason.Shift_TotalHour = totalHour;
                                }
                                lstHRM_AttendanceReason_Individual.Add(_attendance);
                            }
                            try
                            {
                                _context.SaveChanges();

                                if (getAttendancedata.Count > 0)
                                {
                                    aAttendance_RPT_Bll.UpdateAll_AttStatus_ByDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtFromDate.Text)); // update attendnace status by date

                                    // insert/update leave/holiday attendnace status process by selected eid
                                    aAttendance_RPT_Bll.Insert_Update_AbsentLeaveStatus_ByDate_EID1(lstHRM_AttendanceReason_Individual, Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtFromDate.Text));

                                    //ot process

                                    List<string> ShiftCodes = aAttendance_BLL.GetAllShiftCode(OCODE).ToList();

                                    foreach (string ashiftcode in ShiftCodes)
                                    {
                                        aAttendance_BLL.UpdateOT_ByDateandShift(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtFromDate.Text), ashiftcode);
                                    }

                                    //ot process log
                                    var ParamempID1 = new SqlParameter("@DateFrom", Convert.ToDateTime(txtFromDate.Text));
                                    var ParamempID2 = new SqlParameter("@DateTo", Convert.ToDateTime(txtFromDate.Text));
                                    var ParamempID3 = new SqlParameter("@Edit_User", userId);
                                    var ParamempID4 = new SqlParameter("@Edit_Date", DateTime.Now);
                                    var ParamempID5 = new SqlParameter("@OCODE", OCODE);
                                    string SP_SQL = "HRM_Insert_OTProcessLog @DateFrom, @DateTo, @Edit_User, @Edit_Date, @OCODE";
                                    _context.ExecuteStoreCommand(SP_SQL, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5);

                                    //
                                }

                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Processed Successfully')", true);
                                grdview.DataSource = null;
                                grdview.DataBind();
                            }
                            catch (Exception ex)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                            }
                            
                        }
                    }
                    ClearUI();
                }

                else // dept/section/subsection wise process
                {
                    if (grdview.Rows.Count < 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Employee selected in the list!')", true);
                        return;
                    }



                    foreach (GridViewRow gvRow in grdview.Rows)
                    {


                        for (int i = 0; i < Convert.ToInt16(hdfTotalDay.Value); i++)
                        {
                            CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                            HRM_AttendanceReason_Individual _attendance = new HRM_AttendanceReason_Individual();
                            Label lblEID = ((Label)gvRow.FindControl("lblEID"));
                            Label lblShiftCode = ((Label)gvRow.FindControl("lblShiftCode"));
                            string shiftCode = lblShiftCode.Text;
                            string EID = lblEID.Text;
                            DateTime fromdate = Convert.ToDateTime(txtFromDate.Text);

                            List<HRM_AttendanceReason_Individual> a_HRM_AttendanceReason_Individual = aAttendance_BLL.GetHRM_AttendanceReason_Individual(EID, fromdate.AddDays(i));

                            //var getAttendancedata = aAttendance_BLL.GetAttendanceByEID_Date(OCODE, EID, fromdate);

                            if (rowChkBox.Checked == true)
                            {
                                if (a_HRM_AttendanceReason_Individual.Count == 0)  //insert
                                {
                                    _attendance.EID = lblEID.Text;
                                    _attendance.ReasonDate = fromdate.AddDays(i);
                                    _attendance.Remarks = txtbxremark.Text;
                                    _attendance.Status = "true";
                                    _attendance.ShiftCode = shiftCode;
                                    _attendance.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                                    _attendance.Edit_Date = DateTime.Now;
                                    _attendance.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;

                                    TimeSpan start_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtAttInTime.Hour, txtAttInTime.Minute, txtAttInTime.Second));
                                    _attendance.InTime = start_time;

                                    TimeSpan end_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtAttOutTime.Hour, txtAttOutTime.Minute, txtAttOutTime.Second));
                                    _attendance.OutTime = end_time;

                                    TimeSpan lateAllowed = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtLateAllowed.Hour, txtLateAllowed.Minute, txtLateAllowed.Second));
                                    _attendance.LateAllowed = lateAllowed;

                                    TimeSpan totalHour, hour1, hour2;

                                    if (start_time > end_time)
                                    {
                                        hour1 = TimeSpan.Parse("23:59:59");
                                        hour2 = Calculations.timeDiff(start_time, hour1);
                                        totalHour = hour2 + end_time;
                                        _attendance.Shift_TotalHour = totalHour;
                                    }
                                    else
                                    {
                                        totalHour = Calculations.timeDiff(start_time, end_time);
                                        _attendance.Shift_TotalHour = totalHour;
                                    }

                                    lstHRM_AttendanceReason_Individual.Add(_attendance);

                                    _context.HRM_AttendanceReason_Individual.AddObject(_attendance); //insert
                                    try
                                    {
                                        _context.SaveChanges();

                                        //if (getAttendancedata.Count > 0)
                                        //{
                                        //aAttendance_RPT_Bll.UpdateAll_AttStatus_ByDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtFromDate.Text)); // update attendnace status by date

                                        // insert/update leave/holiday attendnace status process by selected eid
                                        //aAttendance_RPT_Bll.Insert_Update_AbsentLeaveStatus_ByDate_EID1(lstHRM_AttendanceReason_Individual, Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtFromDate.Text));

                                        //ot process

                                        //List<string> ShiftCodes = aAttendance_BLL.GetAllShiftCode(OCODE).ToList();

                                        //foreach (string ashiftcode in ShiftCodes)
                                        //{
                                        //    aAttendance_BLL.UpdateOT_ByDateandShift(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtFromDate.Text), ashiftcode);
                                        //}

                                        ////ot process log
                                        //var ParamempID1 = new SqlParameter("@DateFrom", Convert.ToDateTime(txtFromDate.Text));
                                        //var ParamempID2 = new SqlParameter("@DateTo", Convert.ToDateTime(txtFromDate.Text));
                                        //var ParamempID3 = new SqlParameter("@Edit_User", userId);
                                        //var ParamempID4 = new SqlParameter("@Edit_Date", DateTime.Now);
                                        //var ParamempID5 = new SqlParameter("@OCODE", OCODE);
                                        //string SP_SQL = "HRM_Insert_OTProcessLog @DateFrom, @DateTo, @Edit_User, @Edit_Date, @OCODE";
                                        //_context.ExecuteStoreCommand(SP_SQL, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5);

                                        //
                                        //}

                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Processed Successfully')", true);
                                        grdview.DataSource = null;
                                        grdview.DataBind();
                                    }
                                    catch (Exception ex)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                                    }
                                }
                                else  //update
                                {
                                    DateTime iDate = fromdate.AddDays(i);

                                    foreach (var AttendanceReason in _context.HRM_AttendanceReason_Individual.Where(x => x.EID == EID && x.ReasonDate == iDate))
                                    {
                                        AttendanceReason.Remarks = txtbxremark.Text;
                                        AttendanceReason.Status = "true";
                                        AttendanceReason.ShiftCode = shiftCode;
                                        AttendanceReason.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                                        AttendanceReason.Edit_Date = DateTime.Now;
                                        AttendanceReason.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;

                                        TimeSpan start_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtAttInTime.Hour, txtAttInTime.Minute, txtAttInTime.Second));
                                        AttendanceReason.InTime = start_time;

                                        TimeSpan end_time = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtAttOutTime.Hour, txtAttOutTime.Minute, txtAttOutTime.Second));
                                        AttendanceReason.OutTime = end_time;

                                        TimeSpan lateAllowed = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtLateAllowed.Hour, txtLateAllowed.Minute, txtLateAllowed.Second));
                                        _attendance.LateAllowed = lateAllowed;

                                        TimeSpan totalHour, hour1, hour2;

                                        if (start_time > end_time)
                                        {
                                            hour1 = TimeSpan.Parse("23:59:59");
                                            hour2 = Calculations.timeDiff(start_time, hour1);
                                            totalHour = hour2 + end_time;
                                            AttendanceReason.Shift_TotalHour = totalHour;
                                        }
                                        else
                                        {
                                            totalHour = Calculations.timeDiff(start_time, end_time);
                                            AttendanceReason.Shift_TotalHour = totalHour;
                                        }

                                        lstHRM_AttendanceReason_Individual.Add(AttendanceReason);
                                    }
                                    try
                                    {
                                        _context.SaveChanges();   //update

                                        //if (getAttendancedata.Count > 0)
                                        //{
                                        //aAttendance_RPT_Bll.UpdateAll_AttStatus_ByDate(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtFromDate.Text)); // update attendnace status by date

                                        // insert/update leave/holiday attendnace status process by selected eid
                                        //aAttendance_RPT_Bll.Insert_Update_AbsentLeaveStatus_ByDate_EID1(lstHRM_AttendanceReason_Individual, Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtFromDate.Text));

                                        //ot process

                                        //List<string> ShiftCodes = aAttendance_BLL.GetAllShiftCode(OCODE).ToList();

                                        //foreach (string ashiftcode in ShiftCodes)
                                        //{
                                        //    aAttendance_BLL.UpdateOT_ByDateandShift(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtFromDate.Text), ashiftcode);
                                        //}

                                        ////ot process log
                                        //var ParamempID1 = new SqlParameter("@DateFrom", Convert.ToDateTime(txtFromDate.Text));
                                        //var ParamempID2 = new SqlParameter("@DateTo", Convert.ToDateTime(txtFromDate.Text));
                                        //var ParamempID3 = new SqlParameter("@Edit_User", userId);
                                        //var ParamempID4 = new SqlParameter("@Edit_Date", DateTime.Now);
                                        //var ParamempID5 = new SqlParameter("@OCODE", OCODE);
                                        //string SP_SQL = "HRM_Insert_OTProcessLog @DateFrom, @DateTo, @Edit_User, @Edit_Date, @OCODE";
                                        //_context.ExecuteStoreCommand(SP_SQL, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5);

                                        //
                                        //}

                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Processed Successfully')", true);
                                        grdview.DataSource = null;
                                        grdview.DataBind();
                                    }
                                    catch (Exception ex)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                                    }
                                }
                            }



                        }
                    }




                    ClearUI();
                }
            }
            catch (Exception ex)
            {
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                // LogController<ExtraShiftEmployeewise>.SetLog(ex, EID);
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearUI()
        {
            txtbxEID.Text = "";
            txtbxName.Text = "";
            txtbxDepartment.Text = "";
            txtbxDesgination.Text = "";
            ddlSection.ClearSelection();
            ddlSubSections.ClearSelection();
            txtbxremark.Text = "";
            txtFromDate.Text = "";
            txtToDate.Text = "";
            grdview.DataSource = null;
            grdview.DataBind();
        }

        protected void txtbxEID_TextChangeEvent(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string employeeID = Convert.ToString(txtbxEID.Text);
                //Emp_IMG_AT.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;

                var result = objEmp_BLL.GetEmployeeDetailsForAttendece(employeeID, OCODE).ToList();
                if (result.Count > 0)
                {
                    var objNewEmp = result.First();
                    txtbxEID.Text = Convert.ToString(objNewEmp.EID);
                    txtbxName.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                    //lblHiddenId.Text = Convert.ToString(objNewEmp.EMP_ID);
                    txtbxDesgination.Text = objNewEmp.DPT_NAME;
                    txtbxDepartment.Text = objNewEmp.DEG_NAME;
                    hdShiftCode.Value = objNewEmp.SHIFTCODE;
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Employee Not Available!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void chkIndividualShift_click(object sender, EventArgs e)
        {
            try
            {
                if (chkIndividualShift.Checked)
                {
                    txtbxEID.Text = "";
                    region.Visible = false;
                    office.Visible = false;
                    department.Visible = false;
                    section.Visible = false;
                    subSection.Visible = false;
                    divEid.Visible = true;
                    divDesgination.Visible = true;
                    divName.Visible = true;
                    divIndiDepartment.Visible = true;
                    btnProcess.Visible = false;
                }
                else
                {
                    txtbxEID.Text = "";
                    region.Visible = true;
                    office.Visible = true;
                    department.Visible = true;
                    section.Visible = true;
                    subSection.Visible = true;
                    divEid.Visible = false;
                    divDesgination.Visible = false;
                    divName.Visible = false;
                    divIndiDepartment.Visible = false;
                    btnProcess.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtToDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
                DateTime toDate = Convert.ToDateTime(txtToDate.Text);
                hdfTotalDay.Value = (1 + (toDate - fromDate).TotalDays).ToString();
            }
            catch (Exception ex)
            {
                //string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                //LogController<ManualLeaveRegister>.SetLog(ex, EID);
                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

    }
}
