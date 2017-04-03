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
using ERPSSL.AppGateway.DAL;
using ERPSSL.Adminpanel.DAL;

namespace ERPSSL.HRM
{
    public partial class AttendancePunishment : System.Web.UI.Page
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
                Attendance_BLL _attendancebll = new Attendance_BLL();

                if (ddlRegion1.SelectedItem.ToString() == "--Select--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Region')", true);
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
                else if (ddlSection.SelectedItem.ToString() == "--Select--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Section!')", true);
                    return;
                }
                else if (ddlSubSections.SelectedItem.ToString() == "--Select--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Sub-Section!')", true);
                    return;
                }
                else if (txtDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input To Date')", true);
                }
                else
                {
                    //sub-section wise process

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
                        //aemployee.EMP_ID = Convert.ToInt32(aitem.EID);
                        aemployee.EmployeeFullName = aitem.FirstName + " " + aitem.LastName;
                        aemployee.DEG_NAME = aitem.DEG_NAME;
                        aemployee.DATE_JOINED = Convert.ToDateTime(txtDate.Text);


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
                UserDAL userDAl = new UserDAL();
                Attendance_BLL _attendancebll = new Attendance_BLL();
                List<HRM_ATTENDANCE> attendances = new List<HRM_ATTENDANCE>();

                if (ckIndividualPunishment.Checked)   //individual process
                {
                    if (txtbxEID.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Enter E-ID!')", true);
                        return;
                    }
                    if (txtDate.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Attendance Date!')", true);
                        return;
                    }
                    HRM_ATTENDANCE _attendance = new HRM_ATTENDANCE();

                    _attendance.EID = txtbxEID.Text;
                    _attendance.Attendance_Date = Convert.ToDateTime(txtDate.Text);
                    _attendance.Remarks = txtbxremark.Text;
                    _attendance.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                    _attendance.Edit_Date = DateTime.Now;
                    _attendance.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                    attendances.Add(_attendance);

                    if (attendances.Count > 0)
                    {
                        List<HRM_EMPLOYEES_VIEWER> lstEmpAttendnace = _attendancebll.GetEmployeesByEidForAttendance(txtbxEID.Text, Convert.ToDateTime(txtDate.Text), Convert.ToDateTime(txtDate.Text)); //check attendance data

                        if (lstEmpAttendnace.Count > 0)
                        {
                            Guid UserID = ((SessionUser)Session["SessionUser"]).UserId;
                            string PunishedBy = userDAl.getEIDbyUserGuidID(UserID);

                            int result = _attendancebll.AttendanceAdjustment(attendances, PunishedBy);

                            if (result == 1)
                            {
                                // insert/update leave/holiday attendnace status process by selected eid
                                aAttendance_RPT_Bll.Insert_Update_AbsentLeaveStatus_ByDate_EID(attendances, Convert.ToDateTime(txtDate.Text), Convert.ToDateTime(txtDate.Text));

                                ClearUI();
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Attendance Punishment Successfull')", true);
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Attendance Data Found!')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Employee selected in the list!')", true);
                    }
                }

                else
                {
                    foreach (GridViewRow gvRow in grdview.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        HRM_ATTENDANCE _attendance = new HRM_ATTENDANCE();
                        if (rowChkBox.Checked == true)
                        {

                            Label lblEID = ((Label)gvRow.FindControl("lblEID"));
                            TextBox txtbx = ((TextBox)gvRow.FindControl("txtbx"));

                            _attendance.EID = lblEID.Text;
                            _attendance.Attendance_Date = Convert.ToDateTime(txtDate.Text);
                            _attendance.Remarks = txtbxremark.Text;
                            _attendance.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                            _attendance.Edit_Date = DateTime.Now;
                            _attendance.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                            attendances.Add(_attendance);
                        }


                    }


                    if (attendances.Count > 0)
                    {
                        Guid UserID = ((SessionUser)Session["SessionUser"]).UserId;
                        string PunishedBy = userDAl.getEIDbyUserGuidID(UserID);
                        int result = _attendancebll.AttendanceAdjustment(attendances, PunishedBy);
                        if (result == 1)
                        {
                            // insert/update leave/holiday attendnace status process by selected eid
                            aAttendance_RPT_Bll.Insert_Update_AbsentLeaveStatus_ByDate_EID(attendances, Convert.ToDateTime(txtDate.Text), Convert.ToDateTime(txtDate.Text));

                            ClearUI();
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Attendance Punishment Successfull')", true);
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Employee selected in the list!')", true);
                    }
                }    

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearUI()
        {

            //ddlRegion1.ClearSelection();
            //ddlOffice1.ClearSelection();
            //ddlDept1.ClearSelection();
            //ddlSection.ClearSelection();
            //ddlSubSections.ClearSelection();
            txtbxremark.Text = "";
            txtDate.Text = "";
            txtbxEID.Text = "";
            txtbxDepartment.Text = "";
            txtbxDesgination.Text = "";
            txtbxName.Text = "";

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
        protected void ckIndividualPunishment_click(object sender, EventArgs e)
        {
            try
            {
                if (ckIndividualPunishment.Checked)
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
