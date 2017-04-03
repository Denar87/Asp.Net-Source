using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.HRM.DAL;

namespace ERPSSL.HRM
{
    public partial class LeaveApplyList : System.Web.UI.Page
    {
        LEAVE_BLL leaveBllobj = new LEAVE_BLL();
        LEAVE_BLL objLeave_BLL = new LEAVE_BLL();
        ERPSSLHBEntities _context = new ERPSSLHBEntities();
        EMPOYEE_BLL objEmp_BLL = new EMPOYEE_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getLeaveInfoForApprove();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void getLeaveInfoForApprove()
        {
            string eid = ((SessionUser)Session["SessionUser"]).EID;
            if (eid != null)
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                // string eid = ((SessionUser)Session["SessionUser"]).EID;
                string currentYear = DateTime.Now.Year.ToString();
                List<LeaveInfo> leaveinfoes = leaveBllobj.getLeaveInfoForApprove(eid, currentYear, OCODE).ToList();
                if (leaveinfoes.Count > 0)
                {
                    gridviewLeaveInfo.DataSource = leaveinfoes;
                    gridviewLeaveInfo.DataBind();
                }
            }
        }


        protected void btnaprove_Click(object sender, EventArgs e)
        {
            Button imgbtn = (Button)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string leaveCode = "";
                string Eid = "";
                Label lblLeaveCode = (Label)gridviewLeaveInfo.Rows[row.RowIndex].FindControl("lblLeaveCode");
                Label lblEidID = (Label)gridviewLeaveInfo.Rows[row.RowIndex].FindControl("lblEid");
                if (lblLeaveCode != null && lblEidID != null)
                {
                    Eid = lblEidID.Text;
                    leaveCode = lblLeaveCode.Text;
                    getLeaveTypes();
                    getLeaveEnjoyedInfoById(Eid);
                    GetLeaveDetailsByID(leaveCode);
                    GetEmployeeDetails(Eid);
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

        private void GetLeaveDetailsByID(string leaveCode)
        {
            try
            {
                LEAVE_BLL leaveBll = new LEAVE_BLL();
                LeaveDetailsR LeaveDetailobj = leaveBll.GetLeaveDetailByLeaveCode(leaveCode);
                if (LeaveDetailobj != null)
                {
                    hidLeaveCode.Value = LeaveDetailobj.LeaveCode;
                    hidAppliedDate.Value = LeaveDetailobj.LeaveAppliedDate.ToString();
                    hidEid.Value = LeaveDetailobj.EID;
                    drpLeaveType.SelectedValue = LeaveDetailobj.LeaveTypeID.ToString();
                    txtbxFromDate.Text = LeaveDetailobj.fromDate.ToShortDateString();
                    txtbxToDate.Text = LeaveDetailobj.Todate.ToShortDateString();
                    CalculateTotalDate(LeaveDetailobj.fromDate, LeaveDetailobj.Todate);
                    txtbxResion.Text = LeaveDetailobj.LeaveReson;
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
        private void GetEmployeeDetails(string Eid)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string employeeID = Convert.ToString(Eid);
                getLeaveEnjoyedInfoById(employeeID);

                var result = objEmp_BLL.GetEmployeeDetailsIDCard(employeeID, OCODE).ToList();
                if (result.Count > 0)
                {
                    var objNewEmp = result.First();
                    if (objNewEmp.Gender == "Male")
                    {
                        getLeaveTypeForMale();
                        mlHeader.Visible = false;
                        rdToal.Visible = false;
                        tdMLE.Visible = false;
                        tdmlB.Visible = false;
                    }
                    else
                    {
                        getLeaveTypesfordrp();
                        mlHeader.Visible = true;
                        rdToal.Visible = true;
                        tdMLE.Visible = true;
                        tdmlB.Visible = true;
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('This Employee is Inactive!')", true);
                    //NO RECORDS FOUND.
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void getLeaveEnjoyedInfoById(string Eid)
        {
            try
            {

                int resultsML = (from la in _context.HRM_LeaveApply
                                 where la.LeaveTypeId == 4 && la.Eid == Eid && la.LeaveStatusHRM == true
                                 select la.LeaveTypeId).Count();
                lblMLE.Text = resultsML.ToString();

                int resultscl = (from la in _context.HRM_LeaveApply
                                 where la.LeaveTypeId == 1 && la.Eid == Eid && la.LeaveStatusHRM == true
                                 select la.LeaveTypeId).Count();

                lblCloE.Text = resultscl.ToString();


                int resultsAL = (from la in _context.HRM_LeaveApply
                                 where la.LeaveTypeId == 3 && la.Eid == Eid && la.LeaveStatusHRM == true
                                 select la.LeaveTypeId).Count();

                lblALE.Text = resultsAL.ToString();


                int resultsSL = (from la in _context.HRM_LeaveApply
                                 where la.LeaveTypeId == 2 && la.Eid == Eid && la.LeaveStatusHRM == true
                                 select la.LeaveTypeId).Count();

                lblSLE.Text = resultsSL.ToString();
                int resultsLpe = (from la in _context.HRM_LeaveApply
                                  where la.LeaveTypeId == 5 && la.Eid == Eid && la.LeaveStatusHRM == true
                                  select la.LeaveTypeId).Count();

                lblLWPE.Text = resultsLpe.ToString();
                lblClB.Text = (Convert.ToInt16(lblCl.Text) - Convert.ToInt16(lblCloE.Text)).ToString();
                lblSLB.Text = (Convert.ToInt16(lblSl.Text) - Convert.ToInt16(lblSLE.Text)).ToString();
                lblALB.Text = (Convert.ToInt16(lblAL.Text) - Convert.ToInt16(lblALE.Text)).ToString();
                lblMLB.Text = (Convert.ToInt16(lblML.Text) - Convert.ToInt16(lblMLE.Text)).ToString();
                lblLWPB.Text = (Convert.ToInt16(lblLWP.Text) - Convert.ToInt16(lblLWPE.Text)).ToString();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        private void getLeaveTypes()
        {
            try
            {
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
                        else if (item.LEV_TYPE == "Others")
                        {
                            LWP = item.LEV_DAYS.ToString();
                        }
                    }

                    lblCl.Text = CL.ToString();
                    lblSl.Text = SL.ToString();
                    lblAL.Text = AL.ToString();
                    lblML.Text = ML.ToString();
                    lblLWP.Text = LWP.ToString();

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
                DateTime probationf = Convert.ToDateTime(txtbxFromDate.Text);
                DateTime probationT = Convert.ToDateTime(txtbxToDate.Text);
                txtbxTotalDay.Text = (1 + (probationT - probationf).TotalDays).ToString();
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
            string eid = hidEid.Value;

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
        private bool DeleteExistinLeaveDetailsByCodeId()
        {
            try
            {
                string LeaveCode = Convert.ToString(hidLeaveCode.Value);
                bool status = false;
                int result = objLeave_BLL.DeleteLeaveDetailsByLeaveCode(LeaveCode);
                if (result == 1)
                {
                    status = true;
                }
                return status;

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void btnSave_click(object sender, EventArgs e)
        {
            try
            {
                if (drpLeaveType.SelectedItem.ToString() == "--Select--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Leave Type')", true);
                }
                else if (txtbxFromDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input From Date')", true);
                }
                else if (txtbxToDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input To Date')", true);
                }
                else
                {
                    //if (DeleteExistinLeaveDetailsByCodeId())
                    //{
                    if (txtbxToDate.Text != "")
                    {
                        //if (!IsExist())
                        //{
                        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                        string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).UserId);
                        string LeaveCode = Convert.ToString(hidLeaveCode.Value);
                        string FirstReportingBossID = objLeave_BLL.GetFirstReportingBossIDByLeaveCode(LeaveCode);
                        string SecondReportingBossID = objLeave_BLL.GetSecondReportingBossIDByLeaveCode(LeaveCode);
                        string ThirdReportingBossID = objLeave_BLL.GetThirdReportingBossIDByLeaveCode(LeaveCode);

                        List<HRM_LeaveApply> mainLeavesbyCode = objLeave_BLL.getLeaveApplyesByCode(LeaveCode);



                        DateTime DateTimeFrom = Convert.ToDateTime(txtbxFromDate.Text);
                        DateTime DateTo = Convert.ToDateTime(txtbxToDate.Text);
                        List<HRM_LeaveApply> leaveApplyesDates1 = new List<HRM_LeaveApply>();
                        for (int i = 0; i < Convert.ToInt16(txtbxTotalDay.Text); i++)
                        {
                            HRM_LeaveApply leaveApplyObj = new HRM_LeaveApply();
                            leaveApplyObj.LeaveCode = hidLeaveCode.Value.ToString();
                            leaveApplyObj.OCODE = OCODE;
                            leaveApplyObj.LeaveDates = DateTimeFrom.AddDays(i);
                            leaveApplyObj.LeaveAppliedDate = Convert.ToDateTime(hidAppliedDate.Value);
                            leaveApplyObj.LeaveToDate = Convert.ToDateTime(txtbxToDate.Text);
                            leaveApplyObj.Eid = hidEid.Value;
                            leaveApplyObj.LeaveTypeId = Convert.ToInt16(drpLeaveType.SelectedValue.ToString());
                            leaveApplyObj.LeaveCurrentYear = DateTime.Now.Year;
                            leaveApplyObj.LeaveResion = txtbxResion.Text.Trim();
                            leaveApplyObj.ReprotingBossHRM = drpApprovedHR.SelectedValue.ToString();
                            leaveApplyObj.ReprotingBoss1 = drpdwnApproveSupervisor.SelectedValue.ToString();
                            leaveApplyObj.ReprotingBoss2 = drpApprovedAdmin.SelectedValue.ToString();
                            leaveApplyObj.LeaveStatusHRM = true;
                            if (FirstReportingBossID == EID)
                            {
                                leaveApplyObj.ReprotingBossHRmDisApporveStatus = false;
                                leaveApplyObj.ReportingBossHRMDisApproveDate = DateTime.Now;

                            }
                            else if (SecondReportingBossID == EID)
                            {
                                leaveApplyObj.ReprotingBoss1DisApproveStatus = false;
                                leaveApplyObj.ReprotingBoss1DisApproveDate = DateTime.Now;
                            }

                            else if (ThirdReportingBossID == EID)
                            {
                                leaveApplyObj.ReportingBoss2DisApporveStatus = false;
                                leaveApplyObj.ReportingBoss2DisApproveDate = DateTime.Now;
                            }
                            leaveApplyesDates1.Add(leaveApplyObj);
                        }

                        List<HRM_LeaveApply> leaveApplyesDates = (from post in mainLeavesbyCode
                                                                  join meta in leaveApplyesDates1
                                                                  on post.LeaveDates equals meta.LeaveDates
                                                                  select post

                                                                    ).ToList();
                        int resultdelete = objLeave_BLL.DeleteLeaveDetailsByLeaveCode(LeaveCode);
                        if (resultdelete == 1)
                        {
                            int result = objLeave_BLL.InsertLeaveApply(leaveApplyesDates);
                            if (result == 1)
                            {
                                int Attendanceresult = objLeave_BLL.DeleteAttendanceByLeaveDate(leaveApplyesDates);
                                if (Attendanceresult == 1)
                                {
                                    ClaerAllController();
                                    //string employeeID = Convert.ToString(txtEid_TRNS.Text);
                                    //GetLeaveDetailsByEID(employeeID);
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Leave Approved Successfully')", true);
                                }
                            }
                        }

                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('This Date Already Exist for Leave !')", true);
                    }
                    //}
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClaerAllController()
        {

            txtbxFromDate.Text = "";
            txtbxTotalDay.Text = "";
            txtbxToDate.Text = "";
            drpLeaveType.ClearSelection();
            drpApprovedHR.ClearSelection();
            drpdwnApproveSupervisor.ClearSelection();
            drpApprovedAdmin.ClearSelection();
        }

        protected void btnCancel_click(object sender, EventArgs e)
        {

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string EID = Convert.ToString(((SessionUser)Session["SessionUser"]).EID);
                string LeaveCode = Convert.ToString(hidLeaveCode.Value);

                string FirstReportingBossID = objLeave_BLL.GetFirstReportingBossIDByLeaveCode(LeaveCode);
                string SecondReportingBossID = objLeave_BLL.GetSecondReportingBossIDByLeaveCode(LeaveCode);
                string ThirdReportingBossID = objLeave_BLL.GetThirdReportingBossIDByLeaveCode(LeaveCode);

                DateTime DateTimeFrom = Convert.ToDateTime(txtbxFromDate.Text);
                DateTime DateTo = Convert.ToDateTime(txtbxToDate.Text);
                List<HRM_LeaveApply> leaveApplyesDates = new List<HRM_LeaveApply>();

                for (int i = 0; i < Convert.ToInt16(txtbxTotalDay.Text); i++)
                {
                    HRM_LeaveApply leaveApplyObj = new HRM_LeaveApply();
                    leaveApplyObj.LeaveCode = hidLeaveCode.Value.ToString();
                    leaveApplyObj.OCODE = OCODE;
                    leaveApplyObj.LeaveDates = DateTimeFrom.AddDays(i);
                    leaveApplyObj.LeaveAppliedDate = Convert.ToDateTime(hidAppliedDate.Value);
                    leaveApplyObj.LeaveToDate = Convert.ToDateTime(txtbxToDate.Text);
                    leaveApplyObj.Eid = hidEid.Value;
                    leaveApplyObj.LeaveTypeId = Convert.ToInt16(drpLeaveType.SelectedValue.ToString());
                    leaveApplyObj.LeaveCurrentYear = DateTime.Now.Year;
                    leaveApplyObj.LeaveResion = txtbxResion.Text.Trim();
                    leaveApplyObj.ReprotingBossHRM = drpApprovedHR.SelectedValue.ToString();
                    leaveApplyObj.ReprotingBoss1 = drpdwnApproveSupervisor.SelectedValue.ToString();
                    leaveApplyObj.ReprotingBoss2 = drpApprovedAdmin.SelectedValue.ToString();
                    leaveApplyObj.IsPandingStatus = true;
                    leaveApplyObj.ReprotingBossHRmDisApporveStatus = false;
                    leaveApplyObj.ReportingBossHRMDisApproveDate = DateTime.Now;
                    leaveApplyObj.ReprotingBoss1DisApproveStatus = false;
                    leaveApplyObj.ReprotingBoss1DisApproveDate = DateTime.Now;
                    leaveApplyObj.ReportingBoss2DisApporveStatus = false;
                    leaveApplyObj.ReportingBoss2DisApproveDate = DateTime.Now;

                    leaveApplyesDates.Add(leaveApplyObj);
                }

                if (FirstReportingBossID == EID)
                {
                    //leaveApplyObj.ReprotingBossHRmDisApporveStatus = false;
                    //leaveApplyObj.ReportingBossHRMDisApproveDate = DateTime.Now;

                    int result = objLeave_BLL.CancelLeavesForFirstReportinBoss(leaveApplyesDates);
                    if (result == 1)
                    {
                        int Attendanceresult = objLeave_BLL.DeleteAttendanceByLeaveDate(leaveApplyesDates);
                        if (Attendanceresult == 1)
                        {
                            ClaerAllController();
                            //string employeeID = Convert.ToString(txtEid_TRNS.Text);
                            //GetLeaveDetailsByEID(employeeID);
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Level Cancel Successfully!')", true);
                        }
                    }
                }
                else if (SecondReportingBossID == EID)
                {
                    int result = objLeave_BLL.CancelLeavesForSecondReportinBoss(leaveApplyesDates);
                    if (result == 1)
                    {
                        int Attendanceresult = objLeave_BLL.DeleteAttendanceByLeaveDate(leaveApplyesDates);
                        if (Attendanceresult == 1)
                        {
                            ClaerAllController();
                            //string employeeID = Convert.ToString(txtEid_TRNS.Text);
                            //GetLeaveDetailsByEID(employeeID);
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Level Cancel Successfully!')", true);
                        }
                    }
                }
                else if (ThirdReportingBossID == EID)
                {
                    int result = objLeave_BLL.CancelLeavesForThirdReportinBoss(leaveApplyesDates);
                    if (result == 1)
                    {
                        int Attendanceresult = objLeave_BLL.DeleteAttendanceByLeaveDate(leaveApplyesDates);
                        if (Attendanceresult == 1)
                        {
                            ClaerAllController();
                            //string employeeID = Convert.ToString(txtEid_TRNS.Text);
                            //GetLeaveDetailsByEID(employeeID);
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully!')", true);
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


