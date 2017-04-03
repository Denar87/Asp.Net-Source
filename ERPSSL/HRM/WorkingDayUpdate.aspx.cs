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
    public partial class WorkingDayUpdate : System.Web.UI.Page
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
        Attendance_BLL objAtt_BLL = new Attendance_BLL();
        private ERPSSLHBEntities _context = new ERPSSLHBEntities();

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
               // LogController<WorkingDayUpdate>.SetLog(ex, EID);
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
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Region')", true);
                    return;
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
                else if (txtDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Working Date')", true);
                    return;
                }
                else if (ddlworkingType.SelectedItem.ToString() == "Select Day Type")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Day Type')", true);
                    return;
                }
                else if (ddlworkingType.SelectedItem.Text == "------ Select One ------")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Working Day!')", true);
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

                            List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByRODSSUID(ResionId, OfficeId, DeptId, sction, subsction, Convert.ToDateTime(txtDate.Text));
                            List<HRM_EMPLOYEES_VIEWER> newemployess = new List<HRM_EMPLOYEES_VIEWER>();

                            foreach (HRM_EMPLOYEES_VIEWER aitem in employess)
                            {
                                HRM_EMPLOYEES_VIEWER aemployee = new HRM_EMPLOYEES_VIEWER();
                                aemployee.EID = aitem.EID;
                               // aemployee.EMP_ID = Convert.ToInt32(aitem.EID);
                                aemployee.EmployeeFullName = aitem.FirstName + " " + aitem.LastName;
                                aemployee.DEG_NAME = aitem.DEG_NAME;
                                aemployee.DATE_JOINED = Convert.ToDateTime(txtDate.Text);
                                aemployee.Is_Holiday = aitem.Is_Holiday;
                                aemployee.Working_Day = ddlworkingType.SelectedValue;
                                newemployess.Add(aemployee);
                            }
                            List<HRM_EMPLOYEES_VIEWER> assendingnewemployess = newemployess.OrderBy(x => x.EID).ToList();

                            if (assendingnewemployess.Count > 0)
                            {
                                grdview.DataSource = assendingnewemployess;
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

                            List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeBySectionId(regionId, officeId, deptId, sectionId, Convert.ToDateTime(txtDate.Text));

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
                                    aemployee.DATE_JOINED = Convert.ToDateTime(txtDate.Text);
                                    aemployee.Is_Holiday = aitem.Is_Holiday;
                                    aemployee.Working_Day = ddlworkingType.SelectedValue;
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

                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text != "--Select--" && ddlSection.SelectedItem.Text == "--Select--" && (ddlSubSections.SelectedValue.ToString() == "" || ddlSubSections.SelectedValue.ToString() == "0" || ddlSection.SelectedValue.ToString() == "" || ddlSection.SelectedValue.ToString() == "0"))
                        {
                            int RegionId = Convert.ToInt32(ddlRegion1.SelectedValue);
                            int OfficeId = Convert.ToInt32(ddlOffice1.SelectedValue);
                            int DeptId = Convert.ToInt32(ddlDept1.SelectedValue);

                            List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByDepartmentID(RegionId, OfficeId, DeptId, Convert.ToDateTime(txtDate.Text));
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
                                aemployee.Working_Day = ddlworkingType.SelectedValue;
                                newemployess.Add(aemployee);
                            }

                            List<HRM_EMPLOYEES_VIEWER> ascendingnewemployees = newemployess.OrderBy(x => x.EID).ToList();

                            if (ascendingnewemployees.Count > 0)
                            {
                                grdview.DataSource = ascendingnewemployees;
                                grdview.DataBind();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                                grdview.DataSource = null;
                                grdview.DataBind();
                            }
                        }

                        //office wise process

                        else if (ddlRegion1.SelectedItem.Text != "--Select--" && ddlOffice1.SelectedItem.Text != "--Select--" && ddlDept1.SelectedItem.Text == "--Select--")
                        {
                            List<HRM_EMPLOYEES_VIEWER> employess = _attendancebll.GetEmployeeByOffice(Convert.ToInt32(ddlOffice1.SelectedValue), Convert.ToDateTime(txtDate.Text));
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
                                aemployee.Working_Day = ddlworkingType.SelectedValue;
                                newemployess.Add(aemployee);
                            }

                            List<HRM_EMPLOYEES_VIEWER> ascendingnewemployees = newemployess.OrderBy(x => x.EID).ToList();

                            if (ascendingnewemployees.Count > 0)
                            {
                                grdview.DataSource = ascendingnewemployees;
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
                DateTime workingDate = Convert.ToDateTime(txtDate.Text);
                string Attdate = Convert.ToString(txtDate.Text);

                List<HRM_OfficialDay_Individual> lstHRM_OfficialDay_Individual = new List<HRM_OfficialDay_Individual>();

                if (ckIndividualWorkingDay.Checked) // individual working day type change
                {
                    if (txtbxEID.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Enter E-ID!')", true);
                        return;
                    }
                    if (txtDate.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Working Date!')", true);
                        return;
                    }
                    if (ddlworkingType.SelectedItem.Text == "------ Select One ------")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Working Day!')", true);
                        return;
                    }

                    HRM_OfficialDay_Individual aHRM_OfficialDay_Individual = new HRM_OfficialDay_Individual();

                    string eid = txtbxEID.Text;
                    string workingDay = ddlworkingType.Text;

                    var getdata = objAtt_BLL.GetAllOfficeDayById(OCODE, eid, Convert.ToDateTime(txtDate.Text));

                    var getAttendancedata = objAtt_BLL.GetAttendanceByEID_Date(OCODE, eid, Convert.ToDateTime(txtDate.Text));

                    if (getdata.Count() == 0)   //insert
                    {
                        aHRM_OfficialDay_Individual.EID = txtbxEID.Text;
                        aHRM_OfficialDay_Individual.Official_Date = Convert.ToDateTime(txtDate.Text);
                        aHRM_OfficialDay_Individual.Working_Day = workingDay;
                        aHRM_OfficialDay_Individual.OCode = OCODE;
                        aHRM_OfficialDay_Individual.Edit_Date = EDIT_DATE;
                        aHRM_OfficialDay_Individual.Edit_User = userId;

                        lstHRM_OfficialDay_Individual.Add(aHRM_OfficialDay_Individual);

                        _context.HRM_OfficialDay_Individual.AddObject(aHRM_OfficialDay_Individual);

                        _context.SaveChanges();  // insert working day type

                        if (getAttendancedata.Count > 0)
                        {
                            HRM_ATTENDANCE aHRM_ATTENDANCE = new HRM_ATTENDANCE();

                            DateTime date = Convert.ToDateTime(Attdate);
                            aHRM_ATTENDANCE = _context.HRM_ATTENDANCE.Where(c => c.EID == eid && c.Attendance_Date == date).First();

                            aHRM_ATTENDANCE.Update_Status = 0;
                            aHRM_ATTENDANCE.OCode = OCODE;
                            aHRM_ATTENDANCE.Edit_Date = EDIT_DATE;
                            aHRM_ATTENDANCE.Edit_User = userId;

                            _context.SaveChanges();   // update attendance update status

                            // update attendnace status by date
                            aAttendance_RPT_Bll.UpdateAll_AttStatus_ByDate(Convert.ToDateTime(txtDate.Text), Convert.ToDateTime(txtDate.Text));

                            //insert/update leave/holiday attendnace status process by selected eid
                            aAttendance_RPT_Bll.Insert_Update_AbsentLeaveStatus_ByDate_EID2(lstHRM_OfficialDay_Individual, Convert.ToDateTime(txtDate.Text), Convert.ToDateTime(txtDate.Text));

                            //ot process

                            List<string> ShiftCodes = objAtt_BLL.GetAllShiftCode(OCODE).ToList();

                            foreach (string ashiftcode in ShiftCodes)
                            {
                                objAtt_BLL.UpdateOT_ByDateandShift(Convert.ToDateTime(txtDate.Text), Convert.ToDateTime(txtDate.Text), ashiftcode);
                            }

                            //ot process log
                            var ParamempID1 = new SqlParameter("@DateFrom", Convert.ToDateTime(txtDate.Text));
                            var ParamempID2 = new SqlParameter("@DateTo", Convert.ToDateTime(txtDate.Text));
                            var ParamempID3 = new SqlParameter("@Edit_User", userId);
                            var ParamempID4 = new SqlParameter("@Edit_Date", DateTime.Now);
                            var ParamempID5 = new SqlParameter("@OCODE", OCODE);
                            string SP_SQL = "HRM_Insert_OTProcessLog @DateFrom, @DateTo, @Edit_User, @Edit_Date, @OCODE";
                            _context.ExecuteStoreCommand(SP_SQL, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5);
                        }

                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Processed Successfully')", true);

                        grdview.DataSource = null;
                        grdview.DataBind();
                    }

                    else  //update
                    {
                        HRM_OfficialDay_Individual _HRM_OfficialDay_Individual = new HRM_OfficialDay_Individual();

                        _HRM_OfficialDay_Individual = _context.HRM_OfficialDay_Individual.Where(c => c.EID == eid).First();

                        _HRM_OfficialDay_Individual.Working_Day = workingDay;
                        _HRM_OfficialDay_Individual.OCode = OCODE;
                        _HRM_OfficialDay_Individual.Edit_Date = EDIT_DATE;
                        _HRM_OfficialDay_Individual.Edit_User = userId;
                        _HRM_OfficialDay_Individual.Official_Date = Convert.ToDateTime(txtDate.Text);

                        lstHRM_OfficialDay_Individual.Add(_HRM_OfficialDay_Individual);

                        int result = objAtt_BLL.UpdateWorkingDay(lstHRM_OfficialDay_Individual); // update working day type

                        if (result == 1)
                        {
                            if (getAttendancedata.Count > 0)
                            {
                                HRM_ATTENDANCE aHRM_ATTENDANCE = new HRM_ATTENDANCE();
                                DateTime date = Convert.ToDateTime(Attdate);
                                aHRM_ATTENDANCE = _context.HRM_ATTENDANCE.Where(c => c.EID == eid && c.Attendance_Date == date).First();

                                aHRM_ATTENDANCE.Update_Status = 0;
                                aHRM_ATTENDANCE.OCode = OCODE;
                                aHRM_ATTENDANCE.Edit_Date = EDIT_DATE;
                                aHRM_ATTENDANCE.Edit_User = userId;

                                _context.SaveChanges();   // update attendnace update status

                                // update attendnace status by date
                                aAttendance_RPT_Bll.UpdateAll_AttStatus_ByDate(Convert.ToDateTime(txtDate.Text), Convert.ToDateTime(txtDate.Text));

                                //insert/update leave/holiday attendnace status process by selected eid
                                aAttendance_RPT_Bll.Insert_Update_AbsentLeaveStatus_ByDate_EID2(lstHRM_OfficialDay_Individual, Convert.ToDateTime(txtDate.Text), Convert.ToDateTime(txtDate.Text));

                                //ot process

                                List<string> ShiftCodes = objAtt_BLL.GetAllShiftCode(OCODE).ToList();

                                foreach (string ashiftcode in ShiftCodes)
                                {
                                    objAtt_BLL.UpdateOT_ByDateandShift(Convert.ToDateTime(txtDate.Text), Convert.ToDateTime(txtDate.Text), ashiftcode);
                                }

                                //ot process log
                                var ParamempID1 = new SqlParameter("@DateFrom", Convert.ToDateTime(txtDate.Text));
                                var ParamempID2 = new SqlParameter("@DateTo", Convert.ToDateTime(txtDate.Text));
                                var ParamempID3 = new SqlParameter("@Edit_User", userId);
                                var ParamempID4 = new SqlParameter("@Edit_Date", DateTime.Now);
                                var ParamempID5 = new SqlParameter("@OCODE", OCODE);
                                string SP_SQL = "HRM_Insert_OTProcessLog @DateFrom, @DateTo, @Edit_User, @Edit_Date, @OCODE";
                                _context.ExecuteStoreCommand(SP_SQL, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5);
                            }
                            grdview.DataSource = null;
                            grdview.DataBind();
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Processed Successfully')", true);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Processing Faliure!')", true);
                        }
                    }
                    ClearUI();
                }

                else  // dept/section/subsection wise working day type change
                {
                    if (grdview.Rows.Count < 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Employee selected in the list!')", true);
                        return;
                    }

                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                        HRM_OfficialDay_Individual aHRM_OfficialDay_Individual = new HRM_OfficialDay_Individual();

                        Label lblEID = ((Label)gvRow.FindControl("lblEID"));
                        string eid = lblEID.Text.ToString();

                        DropDownList ddlworking_Day = ((DropDownList)gvRow.FindControl("ddlworking_Day"));
                        string workingDay = ddlworking_Day.Text;

                        var getdata = objAtt_BLL.GetAllOfficeDayById(OCODE, eid, Convert.ToDateTime(txtDate.Text));

                        //var getAttendancedata = objAtt_BLL.GetAttendanceByEID_Date(OCODE, eid, Convert.ToDateTime(txtDate.Text));

                        if (rowChkBox.Checked == true)
                        {
                            if (getdata.Count() == 0) //insert
                            {
                                aHRM_OfficialDay_Individual.EID = lblEID.Text;
                                aHRM_OfficialDay_Individual.Official_Date = Convert.ToDateTime(txtDate.Text);
                                aHRM_OfficialDay_Individual.Working_Day = workingDay;
                                aHRM_OfficialDay_Individual.OCode = OCODE;
                                aHRM_OfficialDay_Individual.Edit_Date = EDIT_DATE;
                                aHRM_OfficialDay_Individual.Edit_User = userId;

                                lstHRM_OfficialDay_Individual.Add(aHRM_OfficialDay_Individual);

                                _context.HRM_OfficialDay_Individual.AddObject(aHRM_OfficialDay_Individual);

                                _context.SaveChanges(); //insert

                                //if (getAttendancedata.Count > 0)
                                //{
                                //foreach (var aHRM_ATTENDANCE in _context.HRM_ATTENDANCE.Where(x => x.EID == eid && x.Attendance_Date == workingDate))
                                //{
                                //    aHRM_ATTENDANCE.Update_Status = 0;
                                //    aHRM_ATTENDANCE.OCode = OCODE;
                                //    aHRM_ATTENDANCE.Edit_Date = EDIT_DATE;
                                //    aHRM_ATTENDANCE.Edit_User = userId;
                                //}
                                //_context.CommandTimeout = 1000;
                                //_context.SaveChanges();


                                //HRM_ATTENDANCE aHRM_ATTENDANCE = new HRM_ATTENDANCE();
                                //DateTime date = Convert.ToDateTime(Attdate);
                                //aHRM_ATTENDANCE = _context.HRM_ATTENDANCE.Where(c => c.EID == eid && c.Attendance_Date == date).First();

                                //aHRM_ATTENDANCE.Update_Status = 0;
                                //aHRM_ATTENDANCE.OCode = OCODE;
                                //aHRM_ATTENDANCE.Edit_Date = EDIT_DATE;
                                //aHRM_ATTENDANCE.Edit_User = userId;

                                //_context.SaveChanges();

                                //aAttendance_RPT_Bll.UpdateAll_AttStatus_ByDate(Convert.ToDateTime(txtDate.Text), Convert.ToDateTime(txtDate.Text)); // update attendnace status by date

                                //insert/update leave/holiday attendnace status process by selected eid
                                //aAttendance_RPT_Bll.Insert_Update_AbsentLeaveStatus_ByDate_EID2(lstHRM_OfficialDay_Individual, Convert.ToDateTime(txtDate.Text), Convert.ToDateTime(txtDate.Text));

                                //ot process

                                //List<string> ShiftCodes = objAtt_BLL.GetAllShiftCode(OCODE).ToList();

                                //foreach (string ashiftcode in ShiftCodes)
                                //{
                                //    objAtt_BLL.UpdateOT_ByDateandShift(Convert.ToDateTime(txtDate.Text), Convert.ToDateTime(txtDate.Text), ashiftcode);
                                //}

                                ////ot process log
                                //var ParamempID1 = new SqlParameter("@DateFrom", Convert.ToDateTime(txtDate.Text));
                                //var ParamempID2 = new SqlParameter("@DateTo", Convert.ToDateTime(txtDate.Text));
                                //var ParamempID3 = new SqlParameter("@Edit_User", userId);
                                //var ParamempID4 = new SqlParameter("@Edit_Date", DateTime.Now);
                                //var ParamempID5 = new SqlParameter("@OCODE", OCODE);
                                //string SP_SQL = "HRM_Insert_OTProcessLog @DateFrom, @DateTo, @Edit_User, @Edit_Date, @OCODE";
                                //_context.ExecuteStoreCommand(SP_SQL, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5);
                                //}

                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Processed Successfully')", true);

                                grdview.DataSource = null;
                                grdview.DataBind();
                            }
                            else  //update
                            {
                                foreach (var _HRM_OfficialDay_Individual in _context.HRM_OfficialDay_Individual.Where(x => x.EID == eid && x.Official_Date == workingDate))
                                {
                                    _HRM_OfficialDay_Individual.Working_Day = workingDay;
                                    _HRM_OfficialDay_Individual.OCode = OCODE;
                                    _HRM_OfficialDay_Individual.Edit_Date = EDIT_DATE;
                                    _HRM_OfficialDay_Individual.Edit_User = userId;

                                    lstHRM_OfficialDay_Individual.Add(_HRM_OfficialDay_Individual);
                                }

                                _context.SaveChanges();

                                //if (getAttendancedata.Count > 0)
                                //{
                                //foreach (var aHRM_ATTENDANCE in _context.HRM_ATTENDANCE.Where(x => x.EID == eid && x.Attendance_Date == workingDate))
                                //{
                                //    aHRM_ATTENDANCE.Update_Status = 0;
                                //    aHRM_ATTENDANCE.OCode = OCODE;
                                //    aHRM_ATTENDANCE.Edit_Date = EDIT_DATE;
                                //    aHRM_ATTENDANCE.Edit_User = userId;
                                //}
                                // _context.CommandTimeout = 1000;
                                //_context.SaveChanges();

                                //HRM_ATTENDANCE aHRM_ATTENDANCE = new HRM_ATTENDANCE();
                                //DateTime date = Convert.ToDateTime(Attdate);
                                //aHRM_ATTENDANCE = _context.HRM_ATTENDANCE.Where(c => c.EID == eid && c.Attendance_Date == date).First();

                                //aHRM_ATTENDANCE.Update_Status = 0;
                                //aHRM_ATTENDANCE.OCode = OCODE;
                                //aHRM_ATTENDANCE.Edit_Date = EDIT_DATE;
                                //aHRM_ATTENDANCE.Edit_User = userId;

                                //_context.SaveChanges();

                                // update attendnace status by date
                                //aAttendance_RPT_Bll.UpdateAll_AttStatus_ByDate(Convert.ToDateTime(txtDate.Text), Convert.ToDateTime(txtDate.Text));

                                //insert/update leave/holiday attendnace status process by selected eid
                                //aAttendance_RPT_Bll.Insert_Update_AbsentLeaveStatus_ByDate_EID2(lstHRM_OfficialDay_Individual, Convert.ToDateTime(txtDate.Text), Convert.ToDateTime(txtDate.Text));

                                //ot process

                                //List<string> ShiftCodes = objAtt_BLL.GetAllShiftCode(OCODE).ToList();

                                //foreach (string ashiftcode in ShiftCodes)
                                //{
                                //    objAtt_BLL.UpdateOT_ByDateandShift(Convert.ToDateTime(txtDate.Text), Convert.ToDateTime(txtDate.Text), ashiftcode);
                                //}

                                ////ot process log
                                //var ParamempID1 = new SqlParameter("@DateFrom", Convert.ToDateTime(txtDate.Text));
                                //var ParamempID2 = new SqlParameter("@DateTo", Convert.ToDateTime(txtDate.Text));
                                //var ParamempID3 = new SqlParameter("@Edit_User", userId);
                                //var ParamempID4 = new SqlParameter("@Edit_Date", DateTime.Now);
                                //var ParamempID5 = new SqlParameter("@OCODE", OCODE);
                                //string SP_SQL = "HRM_Insert_OTProcessLog @DateFrom, @DateTo, @Edit_User, @Edit_Date, @OCODE";
                                //_context.ExecuteStoreCommand(SP_SQL, ParamempID1, ParamempID2, ParamempID3, ParamempID4, ParamempID5);
                                //}

                                grdview.DataSource = null;
                                grdview.DataBind();
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                            }
                        }
                    }
                    //_context.SaveChanges();
                    ClearUI();
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
            //txtDate.Text = "";
            ddlworkingType.ClearSelection();
            txtbxEID.Text = "";
            txtbxDepartment.Text = "";
            txtbxDesgination.Text = "";
            txtbxName.Text = "";
            //txtDate.Text = "";

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

        protected void ckIndividualWorkingDay_click(object sender, EventArgs e)
        {
            try
            {
                if (ckIndividualWorkingDay.Checked)
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

    }
}
