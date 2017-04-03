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
    public partial class ManualLeaveRegister : System.Web.UI.Page
    {
        EMPOYEE_BLL objEmp_BLL = new EMPOYEE_BLL();
        LEAVE_BLL objLeave_BLL = new LEAVE_BLL();
        Attendance_BLL aAttendance_BLL = new Attendance_BLL();

        ERPSSLHBEntities _context = new ERPSSLHBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    //getLeaveTypes();
                    //  gethrmemployeeList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void getLeaveEnjoyedInfoById(string Eid)
        {
            int Year = Convert.ToInt32(DateTime.Now.Year);

            try
            {
                int totalEnjoyedCL = 0;
                decimal totalCl_forHDL = 0;

                int resultsML = (from la in _context.HRM_LeaveApply
                                 where la.LeaveTypeId == 4 && la.Eid == Eid && la.LeaveCurrentYear == Year
                                 select la.LeaveTypeId).Count();
                lblMLE.Text = resultsML.ToString();


                int resultscl = (from la in _context.HRM_LeaveApply
                                 where la.LeaveTypeId == 2 && la.Eid == Eid && la.LeaveStatusHRM == true
                                 select la.LeaveTypeId).Count();

                totalEnjoyedCL = Convert.ToInt16(resultscl + totalCl_forHDL);

                if (totalEnjoyedCL != 0)
                {
                    lblCloE.Text = totalEnjoyedCL.ToString();
                }
                else
                {
                    lblCloE.Text = "0";
                }

                int resultsAL = (from la in _context.HRM_LeaveApply
                                 where la.LeaveTypeId == 1 && la.Eid == Eid && la.LeaveCurrentYear == Year
                                 select la.LeaveTypeId).Count();

                lblALE.Text = resultsAL.ToString();


                int resultsSL = (from la in _context.HRM_LeaveApply
                                 where la.LeaveTypeId == 3 && la.Eid == Eid && la.LeaveCurrentYear == Year
                                 select la.LeaveTypeId).Count();

                lblSLE.Text = resultsSL.ToString();
                int resultsLpe = (from la in _context.HRM_LeaveApply
                                  where la.LeaveTypeId == 5 && la.Eid == Eid && la.LeaveCurrentYear == Year
                                  select la.LeaveTypeId).Count();

                lblClB.Text = (Convert.ToInt16(lblCl.Text) - Convert.ToInt16(lblCloE.Text)).ToString();
                lblSLB.Text = (Convert.ToInt16(lblSl.Text) - Convert.ToInt16(lblSLE.Text)).ToString();
                lblALB.Text = (Convert.ToInt16(lblAL.Text) - Convert.ToInt16(lblALE.Text)).ToString();
                lblMLB.Text = (Convert.ToInt16(lblML.Text) - Convert.ToInt16(lblMLE.Text)).ToString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnSave_click(object sender, EventArgs e)
        {
            try
            {
                bool status = false;

                if (txtEid_TRNS.Text == "")
                {
                    status = false;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input E-ID!')", true);
                }
                else if (drpLeaveType.SelectedItem.ToString() == "--Select--")
                {
                    status = false;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Leave Type!')", true);
                }
                else if (txtbxFromDate.Text == "")
                {
                    status = false;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input From Date!')", true);
                }
                else if (txtbxToDate.Text == "")
                {
                    status = false;
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input To Date!')", true);
                }

                else if (drpLeaveType.SelectedItem.ToString() == "CL")
                {
                    status = true;
                    if (Convert.ToInt32(lblCloE.Text) + Convert.ToInt32(txtbxTotalDay.Text) > Convert.ToInt32(lblCl.Text))
                    {
                        status = false;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Check Total CL Leave!')", true);
                    }
                }

                else if (drpLeaveType.SelectedItem.ToString() == "SL")
                {
                    status = true;
                    if (Convert.ToInt32(lblSLE.Text) + Convert.ToInt32(txtbxTotalDay.Text) > Convert.ToInt32(lblSl.Text))
                    {
                        status = false;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Check Total SL Leave!')", true);
                    }
                }
                else if (drpLeaveType.SelectedItem.ToString() == "AL")
                {
                    status = true;
                    if (Convert.ToInt32(lblALE.Text) + Convert.ToInt32(txtbxTotalDay.Text) > Convert.ToInt32(lblAL.Text))
                    {
                        status = false;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Check Total AL Leave!')", true);
                    }
                }
                else if (drpLeaveType.SelectedItem.ToString() == "ML")
                {
                    status = true;
                    if (Convert.ToInt32(lblMLE.Text) + Convert.ToInt32(txtbxTotalDay.Text) > Convert.ToInt32(lblML.Text))
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
                    if (!IsExist())
                    {
                        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                        int count = objLeave_BLL.GetLastRowNumber(OCODE);
                        int total = count + 1;
                        string Code = "LC" + total;

                        DateTime DateTimeFrom = Convert.ToDateTime(txtbxFromDate.Text);
                        DateTime DateTo = Convert.ToDateTime(txtbxToDate.Text);
                        List<HRM_LeaveApply> leaveApplyesDates = new List<HRM_LeaveApply>();
                        for (int i = 0; i < Convert.ToInt16(txtbxTotalDay.Text); i++)
                        {
                            //check employee present
                            List<HRM_ATTENDANCE> lstHRM_ATTENDANCE = aAttendance_BLL.GetAttendanceInfo_DateWise(DateTimeFrom.AddDays(i)).Where(x => x.EID == txtEid_TRNS.Text).ToList();

                            if (lstHRM_ATTENDANCE.Count > 0)
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('This Employee Already Exist in Attendance!')", true);
                                return;
                            }

                            HRM_LeaveApply leaveApplyObj = new HRM_LeaveApply();
                            leaveApplyObj.LeaveCode = Code;
                            leaveApplyObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                            leaveApplyObj.EDIT_DATE = DateTime.Now;
                            leaveApplyObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                            leaveApplyObj.LeaveDates = DateTimeFrom.AddDays(i);
                            leaveApplyObj.LeaveAppliedDate = Convert.ToDateTime(txtbxFromDate.Text);
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
                            leaveApplyObj.EDIT_DATE = DateTime.Now;
                            leaveApplyObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                            leaveApplyesDates.Add(leaveApplyObj);
                        }

                        int result = objLeave_BLL.InsertLeaveApply(leaveApplyesDates);
                        if (result == 1)
                        {
                            int Attendanceresult = objLeave_BLL.DeleteAttendanceByLeaveDate(leaveApplyesDates);
                            if (Attendanceresult == 1)
                            {
                                ClaerAllController();
                                string employeeID = Convert.ToString(txtEid_TRNS.Text);
                                getLeaveEnjoyedInfoById(employeeID);
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                            }
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('This Date Already Exist for Leave!')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
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
               
                item = _context.HRM_LeaveApply.Count(x => x.Eid == eid && x.LeaveTypeId == LeaveType && x.LeaveCurrentYear == Year);
            }

            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
            return item;

        }

        private bool IsExist()
        {

            bool status = false;
            try
            {
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

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
            return status;
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
        private void getLeaveTypes()
        {
            try
            {
                int CL = 0;
                int SL = 0;
                int AL = 0;
                int ML = 0;
                int LWP = 0;

                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                var row = objLeave_BLL.GetAllLeaveType(OCODE).ToList();

                if (row.Count > 0)
                {
                    foreach (var item in row)
                    {
                        if (item.LEV_TYPE == "AL")
                        {
                            AL = Convert.ToInt16(item.LEV_DAYS);
                        }
                        else if (item.LEV_TYPE == "CL")
                        {
                            CL = Convert.ToInt16(item.LEV_DAYS);
                        }
                        else if (item.LEV_TYPE == "SL")
                        {
                            SL = Convert.ToInt16(item.LEV_DAYS);
                        }
                        else if (item.LEV_TYPE == "MATL")
                        {
                            ML = Convert.ToInt16(item.LEV_DAYS);
                        }
                        else if (item.LEV_TYPE == "LWP")
                        {
                            LWP = Convert.ToInt16(item.LEV_DAYS);
                        }
                    }

                    string eid = txtEid_TRNS.Text;

                    List<HRM_PersonalInformations> personanlInfo = objEmp_BLL.getEmpployeeNameById(eid, OCODE);
                    var empInfo = personanlInfo.First();

                    DateTime joning_date = Convert.ToDateTime(empInfo.JoiningDate);
                    int joining_year = joning_date.Year;

                    int current_year = DateTime.Now.Year;

                    DateTime firstDay = new DateTime(current_year, 1, 1);
                    DateTime lastDay = new DateTime(current_year, 12, 31);
                    double dayOfYear = (lastDay - firstDay).TotalDays + 1;

                    if (joining_year == current_year)
                    {
                        double empDay = (lastDay - joning_date).TotalDays + 1;
                        double cl_total = (CL * empDay) / dayOfYear;

                        lblCl.Text = Math.Round(cl_total).ToString();

                        double empDaySL = (lastDay - joning_date).TotalDays + 1;
                        double sl_total = (SL * empDaySL) / dayOfYear;

                        lblSl.Text = Math.Round(sl_total).ToString();
                    }
                    else
                    {
                        lblCl.Text = CL.ToString();
                        lblSl.Text = SL.ToString();
                    }

                   
                    lblAL.Text = AL.ToString();
                    lblML.Text = ML.ToString();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void txtEIdNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string employeeID = Convert.ToString(txtEid_TRNS.Text);
                getLeaveTypes();
                getLeaveEnjoyedInfoById(employeeID);
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

        private void LoadApprovePersonListByEid(string employeeID)
        {
            try
            {
                HRM_PersonalInformations personalInformation = objEmp_BLL.getDepartmentByEID(employeeID);
                int departmentId = Convert.ToInt16(personalInformation.DepartmentId);
                List<ReportingBoss> personallist = objEmp_BLL.LoadApprovePersonListByDepartmentId(departmentId);
                List<ReportingBoss> reportingBosses = new List<ReportingBoss>();

                foreach (var aitem in personallist)
                {
                    ReportingBoss _aitem = new ReportingBoss();
                    _aitem.FulllName = aitem.FirstName + " " + aitem.LastName;
                    reportingBosses.Add(_aitem);
                }

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
    }
}