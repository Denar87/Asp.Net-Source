using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.HRM
{
    public partial class LeaveUpdate : System.Web.UI.Page
    {
        EMPOYEE_BLL objEmp_BLL = new EMPOYEE_BLL();
        ERPSSLHBEntities _context = new ERPSSLHBEntities();
        LEAVE_BLL objLeave_BLL = new LEAVE_BLL();
        Attendance_BLL aAttendance_BLL = new Attendance_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    gethrmemployeeList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        private void gethrmemployeeList()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<ReportingBoss> personalInfos = objEmp_BLL.GetPersonalInfoByDepartment(OCODE);
                if (personalInfos.Count > 0)
                {
                    drpdwnApproveSupervisor.DataSource = personalInfos;
                    drpdwnApproveSupervisor.DataTextField = "FulllName";
                    drpdwnApproveSupervisor.DataValueField = "EID";
                    drpdwnApproveSupervisor.DataBind();
                    drpdwnApproveSupervisor.Items.Insert(0, new ListItem("--Select--", "0"));

                    drpApprovedAdmin.DataSource = personalInfos;
                    drpApprovedAdmin.DataTextField = "FulllName";
                    drpApprovedAdmin.DataValueField = "EID";
                    drpApprovedAdmin.DataBind();
                    drpApprovedAdmin.Items.Insert(0, new ListItem("--Select--", "0"));

                    drpApprovedHR.DataSource = personalInfos;
                    drpApprovedHR.DataTextField = "FulllName";
                    drpApprovedHR.DataValueField = "EID";
                    drpApprovedHR.DataBind();
                    drpApprovedHR.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void txtEIdNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string employeeID = Convert.ToString(txtEid_TRNS.Text.Trim());
                GetLeaveDetailsByEID(employeeID);
                LoadApprovePersonListByEid(employeeID);

                var result = objEmp_BLL.GetEmployeeDetailsIDCard(employeeID, OCODE).ToList();
                if (result.Count > 0)
                {
                    var objNewEmp = result.First();
                    Emp_IMG_TR.Visible = true;
                    Emp_IMG_TR.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;
                    if (objNewEmp.Gender == "Male")
                    {
                        getLeaveTypeForMale();

                    }
                    else
                    {
                        getLeaveTypesfordrp();
                    }

                    ProbationPeriod();
                    txtEid_TRNS.Text = Convert.ToString(objNewEmp.EID);
                    txtEmpName_TRNS.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                    txtDepartment.Text = objNewEmp.DPT_NAME;
                    txtDesignation.Text = objNewEmp.DEG_NAME;
                }
                else
                {
                    Emp_IMG_TR.Visible = false;
                    txtEmpName_TRNS.Text = "";
                    txtDepartment.Text = "";
                    txtDesignation.Text = "";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('This Employee is Inactive!')", true);
                    //NO RECORDS FOUND.
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void LoadApprovePersonListByEid(string employeeID)
        {

            try
            {
                HRM_PersonalInformations personalInformation = objEmp_BLL.getDepartmentByEID(employeeID);
                int departmentId = Convert.ToInt16(personalInformation.DepartmentId);
                List<ReportingBoss> personallist = objEmp_BLL.LoadApprovePersonListByDepartmentId(departmentId);
                if (personallist.Count > 0)
                {
                    drpdwnApproveSupervisor.DataSource = personallist;
                    drpdwnApproveSupervisor.DataTextField = "FulllName";
                    drpdwnApproveSupervisor.DataValueField = "EID";
                    drpdwnApproveSupervisor.DataBind();
                    drpdwnApproveSupervisor.Items.Insert(0, new ListItem("--Select--", "0"));

                    drpApprovedAdmin.DataSource = personallist;
                    drpApprovedAdmin.DataTextField = "FulllName";
                    drpApprovedAdmin.DataValueField = "EID";
                    drpApprovedAdmin.DataBind();
                    drpApprovedAdmin.Items.Insert(0, new ListItem("--Select--", "0"));
                }

                // List<ReportingBoss> personalforHrm = objEmp_BLL.getPersonalInfoForHRM();

                if (personallist.Count > 0)
                {

                    drpApprovedHR.DataSource = personallist;
                    drpApprovedHR.DataTextField = "FulllName";
                    drpApprovedHR.DataValueField = "EID";
                    drpApprovedHR.DataBind();
                    drpApprovedHR.Items.Insert(0, new ListItem("--Select--", "0"));
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void GetLeaveDetailsByEID(string employeeID)
        {
            try
            {
                LEAVE_BLL leaveBll = new LEAVE_BLL();
                List<LeaveDetailsR> leaveDetails = new List<LeaveDetailsR>();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var result = objEmp_BLL.GetEmployeeDetailsIDCard(employeeID, OCODE).ToList();
                if (result.Count > 0)
                {
                    var objNewEmp = result.First();
                    if (objNewEmp.Gender == "Male")
                    {

                        leaveDetails = leaveBll.GetLeaveDetailsByEID(employeeID);
                    }
                    else
                    {
                        leaveDetails = leaveBll.GetLeaveDetailsFoRFemaleByEID(employeeID);

                    }

                    if (leaveDetails.Count > 0)
                    {
                        grdLeaveUpdate.DataSource = leaveDetails;
                        grdLeaveUpdate.DataBind();

                    }
                    else
                    {
                        grdLeaveUpdate.DataSource = null;
                        grdLeaveUpdate.DataBind();

                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void getLeaveTypesfordrp()
        {
            try
            {
                LEAVE_BLL leaveBll = new LEAVE_BLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_LEAVE_TYPE> leaveTypes = leaveBll.GetAllLeaveType(OCODE);
                if (leaveTypes.Count > 0)
                {

                    drpLeaveType.DataSource = leaveTypes;
                    drpLeaveType.DataTextField = "LEV_TYPE";
                    drpLeaveType.DataValueField = "LEV_ID";
                    drpLeaveType.DataBind();
                    drpLeaveType.Items.Insert(0, new ListItem("--Select--"));
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void getLeaveTypeForMale()
        {
            try
            {
                var leaveTypes = _context.HRM_LEAVE_TYPE.Where(n => n.LEV_ID != 4).ToList();
                if (leaveTypes.Count > 0)
                {
                    drpLeaveType.DataSource = leaveTypes;
                    drpLeaveType.DataTextField = "LEV_TYPE";
                    drpLeaveType.DataValueField = "LEV_ID";
                    drpLeaveType.DataBind();
                    drpLeaveType.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ProbationPeriod()
        {
            try
            {
                DateTime date = DateTime.Now;
                string eid = txtEid_TRNS.Text;
                List<HRM_LEAVE_TYPE> leaveTypes = objLeave_BLL.ProbationPeriod(date, eid);
                if (leaveTypes.Count > 0)
                {
                    drpLeaveType.ClearSelection();
                    drpLeaveType.DataSource = leaveTypes;
                    drpLeaveType.DataTextField = "LEV_TYPE";
                    drpLeaveType.DataValueField = "LEV_ID";
                    drpLeaveType.DataBind();
                    drpLeaveType.Items.Insert(0, new ListItem("--Select--"));
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void txtbxToDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                try
                {
                    DateTime probationf = Convert.ToDateTime(txtbxFromDate.Text);
                    DateTime probationT = Convert.ToDateTime(txtbxToDate.Text);
                    txtbxTotalDay.Text = (1 + (probationT - probationf).TotalDays).ToString();
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private bool IsExist()
        {

            bool status = false;
            DateTime AppliedDate = Convert.ToDateTime(txtbxFromDate.Text);
            DateTime ToDate = Convert.ToDateTime(txtbxToDate.Text);
            string eid = txtEid_TRNS.Text;

            var item = (from aitem in _context.HRM_LeaveApply
                        where aitem.Eid == eid && (aitem.LeaveDates >= AppliedDate && aitem.LeaveDates <= ToDate)
                        select new
                        {
                            aitem.LeaveCode
                        }).Count();

            if (item > 0)
            {
                status = true;
            }

            return status;

        }

        private int TotalLeave()
        {
            int item = 0;
            try
            {
                int Year = Convert.ToInt32(DateTime.Now.Year);
                DateTime AppliedDate = Convert.ToDateTime(txtbxFromDate.Text);
                DateTime ToDate = Convert.ToDateTime(txtbxToDate.Text);
                int LeaveType = Convert.ToInt32(drpLeaveType.SelectedValue);


                string eid = txtEid_TRNS.Text;
                //var item = (from aitem in _context.HRM_LeaveApply
                //            where aitem.Eid == eid).Count();

                item = _context.HRM_LeaveApply.Count(x => x.Eid == eid && x.LeaveTypeId == LeaveType && x.LeaveCurrentYear == Year);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
            return item;

        }

        protected void btnUpdate_click(object sender, EventArgs e)
        {
            try
            {
                bool status = false;
                string CL = "";
                string SL = "";
                string AL = "";
                string ML = "";
                string LWP = "";

                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objLeave_BLL.GetAllLeaveType(OCODE).ToList();
                if (row.Count > 0)
                {
                    foreach (var item in row)
                    {
                        if (item.LEV_TYPE == "AL")
                        {
                            AL = item.LEV_DAYS.ToString();
                        }
                        else if (item.LEV_TYPE == "CL")
                        {
                            CL = item.LEV_DAYS.ToString();
                        }
                        else if (item.LEV_TYPE == "SL")
                        {
                            SL = item.LEV_DAYS.ToString();
                        }
                        else if (item.LEV_TYPE == "ML")
                        {
                            ML = item.LEV_DAYS.ToString();
                        }

                    }
                }

                if (txtEid_TRNS.Text == "")
                {
                    status = false;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input E-ID')", true);
                }
                else if (drpLeaveType.SelectedItem.ToString() == "--Select--")
                {
                    status = false;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Leave Type')", true);
                }
                else if (txtbxFromDate.Text == "")
                {
                    status = false;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input From Date')", true);
                }
                else if (txtbxToDate.Text == "")
                {
                    status = false;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input To Date')", true);
                }

                else if (drpLeaveType.SelectedItem.ToString() == "CL")
                {
                    status = true;
                    Int32 totalActualLeave = TotalLeave();
                    Int32 totalLeave = totalActualLeave - Convert.ToInt16(hidTotalLeave.Value);

                    if (totalLeave + Convert.ToInt32(txtbxTotalDay.Text) > Convert.ToInt32(CL))
                    {
                        status = false;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Check Total CL Leave!')", true);
                    }
                }

                else if (drpLeaveType.SelectedItem.ToString() == "SL")
                {
                    status = true;
                    Int32 totalActualLeave = TotalLeave();
                    Int32 totalLeave = totalActualLeave - Convert.ToInt16(hidTotalLeave.Value);
                    if (Convert.ToInt32(txtbxTotalDay.Text) + totalLeave > Convert.ToInt32(SL))
                    {
                        status = false;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Check Total SL Leave!')", true);

                    }

                }
                else if (drpLeaveType.SelectedItem.ToString() == "AL")
                {
                    Int32 totalActualLeave = TotalLeave();
                    Int32 totalLeave = totalActualLeave - Convert.ToInt16(hidTotalLeave.Value);

                    status = true;
                    if (Convert.ToInt32(txtbxTotalDay.Text) + totalLeave > Convert.ToInt32(AL))
                    {
                        status = false;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Check Total AL Leave!')", true);

                    }
                }
                else if (drpLeaveType.SelectedItem.ToString() == "ML")
                {
                    status = true;
                    Int32 totalActualLeave = TotalLeave();
                    Int32 totalLeave = totalActualLeave - Convert.ToInt16(hidTotalLeave.Value);
                    if (totalLeave + Convert.ToInt32(txtbxTotalDay.Text) > Convert.ToInt32(ML))
                    {
                        status = false;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Check Total ML Leave!')", true);
                    }
                }

                else if (drpLeaveType.SelectedItem.ToString() == "LWP")
                {
                    status = true;
                }
                if (status)
                {
                    if (DeleteExistinLeaveDetailsByCodeId())
                    {
                        if (txtbxToDate.Text != "")
                        {
                            if (!IsExist())
                            {
                                //string OCODE1 = ((SessionUser)Session["SessionUser"]).OCode;

                                DateTime DateTimeFrom = Convert.ToDateTime(txtbxFromDate.Text);
                                DateTime DateTo = Convert.ToDateTime(txtbxToDate.Text);
                                List<HRM_LeaveApply> leaveApplyesDates = new List<HRM_LeaveApply>();
                                for (int i = 0; i < Convert.ToInt16(txtbxTotalDay.Text); i++)
                                {
                                    //check employee present
                                    List<HRM_ATTENDANCE> lstHRM_ATTENDANCE = aAttendance_BLL.GetAttendanceInfo_DateWise(DateTimeFrom.AddDays(i)).Where(x => x.EID == txtEid_TRNS.Text && x.Status == "P").ToList();

                                    if (lstHRM_ATTENDANCE.Count > 0)
                                    {
                                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('This Employee Already Exist in Attendance!')", true);
                                        return;
                                    }

                                    HRM_LeaveApply leaveApplyObj = new HRM_LeaveApply();
                                    leaveApplyObj.LeaveCode = hidLeaveCode.Value.ToString();
                                    leaveApplyObj.LeaveDates = DateTimeFrom.AddDays(i);
                                    leaveApplyObj.LeaveAppliedDate = Convert.ToDateTime(hidAppliedDate.Value);
                                    leaveApplyObj.LeaveToDate = Convert.ToDateTime(txtbxToDate.Text);
                                    leaveApplyObj.Eid = txtEid_TRNS.Text;
                                    leaveApplyObj.LeaveTypeId = Convert.ToInt16(drpLeaveType.SelectedValue.ToString());
                                    leaveApplyObj.LeaveCurrentYear = Convert.ToDateTime(txtbxFromDate.Text).Year;
                                    leaveApplyObj.LeaveResion = txtbxResion.Text.Trim();
                                    leaveApplyObj.ReprotingBossHRM = drpApprovedHR.SelectedValue.ToString();
                                    leaveApplyObj.ReprotingBoss1 = drpdwnApproveSupervisor.SelectedValue.ToString();
                                    leaveApplyObj.ReprotingBoss2 = drpApprovedAdmin.SelectedValue.ToString();
                                    leaveApplyObj.LeaveStatusHRM = true;
                                    leaveApplyObj.ReprotingBoss1ApproveStatus = true;
                                    leaveApplyObj.ReportingBoss2ApporveStatus = true;
                                    leaveApplyObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                                    leaveApplyObj.EDIT_DATE = DateTime.Now;
                                    leaveApplyObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                                    leaveApplyesDates.Add(leaveApplyObj);
                                }

                                //int checkResult = objLeave_BLL.CheckAttendance(leaveApplyesDates);
                                //if (checkResult == 0)
                                //{
                                    int result = objLeave_BLL.InsertLeaveApply(leaveApplyesDates);
                                    if (result == 1)
                                    {
                                        int Attendanceresult = objLeave_BLL.DeleteAttendanceByLeaveDate(leaveApplyesDates);
                                        if (Attendanceresult == 1)
                                        {
                                            ClaerAllController();
                                            string employeeID = Convert.ToString(txtEid_TRNS.Text);
                                            GetLeaveDetailsByEID(employeeID);
                                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully!')", true);
                                        }
                                    }
                                //}
                                //else
                                //{
                                //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('This Employee Already Exist in Attendance!')", true);
                                //}
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('This Date Already Exist for Leave !')", true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private bool DeleteExistinLeaveDetailsByCodeId()
        {
            bool status = false;
            try
            {
                string LeaveCode = Convert.ToString(hidLeaveCode.Value);

                int result = objLeave_BLL.DeleteLeaveDetailsByLeaveCode(LeaveCode);
                if (result == 1)
                {
                    status = true;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
            return status;
        }

        private void ClaerAllController()
        {
            txtbxResion.Text = "";
            txtbxFromDate.Text = "";
            txtbxTotalDay.Text = "";
            txtbxToDate.Text = "";
            drpLeaveType.ClearSelection();
            drpApprovedHR.ClearSelection();
            drpdwnApproveSupervisor.ClearSelection();
            drpApprovedAdmin.ClearSelection();
        }

        protected void ImgBtnUpdate_Click(object sender, EventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            LEAVE_BLL leaveBll = new LEAVE_BLL();
            try
            {
                string leaveCode = "";
                Label lblLeaveCode = (Label)grdLeaveUpdate.Rows[row.RowIndex].FindControl("lblLeaveCode");
                if (lblLeaveCode.Text != null)
                {
                    leaveCode = lblLeaveCode.Text;
                    LeaveDetailsR LeaveDetailobj = leaveBll.GetLeaveDetailByLeaveCode(leaveCode);
                    if (LeaveDetailobj != null)
                    {
                        hidLeaveCode.Value = LeaveDetailobj.LeaveCode;
                        hidAppliedDate.Value = LeaveDetailobj.LeaveAppliedDate.ToString();
                        drpLeaveType.SelectedValue = LeaveDetailobj.LeaveTypeID.ToString();
                        txtbxFromDate.Text = LeaveDetailobj.fromDate.ToShortDateString();
                        txtbxToDate.Text = LeaveDetailobj.Todate.ToShortDateString();
                        CalculateTotalDate(LeaveDetailobj.fromDate, LeaveDetailobj.Todate);
                        txtbxResion.Text = LeaveDetailobj.LeaveReson;
                        drpApprovedHR.SelectedValue = LeaveDetailobj.ReportingBossHRM.ToString();
                        drpdwnApproveSupervisor.SelectedValue = LeaveDetailobj.ReprotingBoss1.ToString();
                        drpApprovedAdmin.SelectedValue = LeaveDetailobj.ReprotingBoss2.ToString();
                        hidTotalLeave.Value = txtbxTotalDay.Text;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void CalculateTotalDate(DateTime fromDate, DateTime Todate)
        {
            try
            {
                DateTime probationf = fromDate;
                DateTime probationT = Todate;
                txtbxTotalDay.Text = (1 + (probationT - probationf).TotalDays).ToString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ImgBtnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string leaveCode = "";
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
                Label lblLeaveCode = (Label)grdLeaveUpdate.Rows[row.RowIndex].FindControl("lblLeaveCode");
                if (lblLeaveCode.Text != null)
                {
                    leaveCode = lblLeaveCode.Text;
                }

                List<HRM_LeaveApply> leaves = objLeave_BLL.GetLeaveDateByLeaveCode(leaveCode);
                if (leaves.Count > 0)
                {
                    int Attendanceresult = objLeave_BLL.DeleteAttendanceByLeave(leaves);
                    if (Attendanceresult == 1)
                    {
                        int result = objLeave_BLL.DeleteLeaveDetailsByLeaveCode(leaveCode);
                        if (result == 1)
                        {

                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Deleted Successfully')", true);
                            string employeeID = Convert.ToString(txtEid_TRNS.Text);
                            GetLeaveDetailsByEID(employeeID);
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