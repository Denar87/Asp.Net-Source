using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.HRM.DAL;
using System.Text;

namespace ERPSSL.HRM
{
    public partial class leaveApplicationForm : System.Web.UI.Page
    {
        LEAVE_BLL leaveBll = new LEAVE_BLL();
        EmployeeSetup_DAL employeeSetUpDal = new EmployeeSetup_DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getLeaveCode();
                    getApplicantInfo();
                    getLeaveTypes();
                    lblDateApplied.Text = DateTime.Now.ToString("dd/MM/yyyy");
                    setAnnulLeave();
                    GetLeaveInfoByEmployeeId();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void getLeaveCode()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int count = leaveBll.GetLastRowNumber(OCODE);
                int total = count + 1;
                lblLeaveId.Text = " LC" + total;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void GetLeaveInfoByEmployeeId()
        {
            try
            {
                string eid = ((SessionUser)Session["SessionUser"]).EID;
                if (eid != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    string currentYear = DateTime.Now.Year.ToString();
                    List<LeaveInfo> leaveInfoes = leaveBll.GetLeaveInfoByEmployeeId(eid, currentYear, OCODE).ToList();
                    if (leaveInfoes.Count > 0)
                    {
                        gridviewLeaveInfo.DataSource = leaveInfoes;
                        gridviewLeaveInfo.DataBind();
                    }
                }

            }
            catch
            {


            }
        }

        private void setAnnulLeave()
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            int TotalAnnulLeave = 0;
            List<HRM_LEAVE_TYPE> leaveTypes = leaveBll.GetAllLeaveType(OCODE);
            foreach (HRM_LEAVE_TYPE leave in leaveTypes)
            {
                TotalAnnulLeave += Convert.ToInt32(leave.LEV_DAYS);
            }
            lblTotal.Text = TotalAnnulLeave.ToString();
            int TotalAnnualTakenLeave = 0;
            string currentYear = DateTime.Now.Year.ToString();
            List<TakenLeave> leaveApply = leaveBll.getAnnualTakenLeaveByEid(lblApplicantId.Text, OCODE, currentYear).ToList();
            foreach (TakenLeave aitem in leaveApply)
            {
                TotalAnnualTakenLeave += Convert.ToInt32(aitem.AnnualTakenLeave);
            }
            lblToken.Text = TotalAnnualTakenLeave.ToString();
            int AnnualBalanceLeave = Convert.ToInt32(lblTotal.Text) - Convert.ToInt32(lblToken.Text);
            lblBanlance.Text = AnnualBalanceLeave.ToString();
        }

        private void getLeaveTypes()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_LEAVE_TYPE> leaveTypes = leaveBll.GetAllLeaveType(OCODE);
                if (leaveTypes.Count > 0)
                {
                    RLeaveTypes.DataSource = leaveTypes;
                    RLeaveTypes.DataBind();
                    drpLeaveType.DataSource = leaveTypes;
                    drpLeaveType.DataTextField = "LEV_TYPE";
                    drpLeaveType.DataValueField = "LEV_ID";
                    drpLeaveType.DataBind();
                    drpLeaveType.Items.Insert(0, new ListItem("--Select--"));
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void getApplicantInfo()
        {
            try
            {
                string eid = ((SessionUser)Session["SessionUser"]).EID;
                if (eid != null)
                {
                    EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    //int eid = Convert.ToInt16(ddlReportingTo.SelectedValue);

                    List<AssignTo> assignTos = new List<AssignTo>();
                    assignTos = employeeBll.GetDesgination(eid, OCODE).ToList();
                    foreach (AssignTo assign in assignTos)
                    {
                        lblApplicantId.Text = ((SessionUser)Session["SessionUser"]).EID;
                        lblApplicantDesignation.Text = assign.DeginationName.ToString();
                        lblApplicantDepartment.Text = assign.DepartmentName.ToString();

                    }
                    List<HRM_PersonalInformations> personanlInfo = employeeBll.getEmpployeeNameById(eid, OCODE);
                    foreach (HRM_PersonalInformations aperson in personanlInfo)
                    {
                        lblApplicantName.Text = aperson.FirstName + " " + aperson.LastName;
                        //hidReportingBossID.Value = aperson.ReportingBossId.ToString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void BtnLeaveSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                List<HRM_LeaveApply> leaveApplyes = new List<HRM_LeaveApply>();

                HRM_PersonalInformations personalInfo = employeeSetUpDal.GetReportingBossById(lblApplicantId.Text);
                string firstReportingBoss = personalInfo.ReportingBossId;
                string secondReportinBoss = personalInfo.SecondReportingBossId;
                string thirdReportingBoss = personalInfo.ThirdReportingBossId;
                if (drpLeaveType.SelectedItem.ToString() == "--Select--")
                {
                    lblMessage.Text = "Please Select Leave Type!";
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                }
                else
                {

                    string[] dates = txtLeaveDate.Text.Split(',');

                    if (dates.Length > 0)
                    {

                        for (int i = 0; i < dates.Length; i++)
                        {
                            HRM_LeaveApply leaveApplyObj = new HRM_LeaveApply();

                            //leaveApplyObj.LeaveAppliedDate = DateTime.Now;
                            //leaveApplyObj.LeaveResion = txtbxLeaveReason.Text;
                            //leaveApplyObj.LeaveDates = txtLeaveDate.Text;
                            //leaveApplyObj.LeaveTypeId = Convert.ToInt32(drpLeaveType.SelectedValue);
                            //leaveApplyObj.TotalDay = Convert.ToInt32(txtbxTotalDay.Text);
                            //leaveApplyObj.ReportingBossId = hidReportingBossID.Value.ToString();
                            //if (BtnLeaveSubmit.Text == "Submit")
                            //{
                            //    leaveApplyObj.Eid = lblApplicantId.Text;
                            //    leaveApplyObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                            //    leaveApplyObj.EDIT_DATE = DateTime.Now;                    
                            //    leaveApplyObj.OCODE =((SessionUser)Session["SessionUser"]).OCode;

                            //    int result = leaveBll.InsertLeaveApply(leaveApplyObj);
                            //    if (result == 1)
                            //    {
                            //        lblMessage.Text = "Data Save Successfully.";
                            //        setAnnulLeave();
                            //        GetLeaveInfoByEmployeeId();
                            //    }
                            //}
                            //else
                            //{
                            //    int leaveId = Convert.ToInt32(hidLeaveId.Value);
                            //    int result = leaveBll.UpdateLeaveApplyByLeaveId(leaveApplyObj, leaveId);
                            //    if (result == 1)
                            //    {
                            //        lblMessage.Text = "Data Update Successfully.";
                            //        setAnnulLeave();
                            //        GetLeaveInfoByEmployeeId();
                            //        clearAllControl();
                            //    }

                            //}
                            leaveApplyObj.LeaveCode = lblLeaveId.Text;
                            leaveApplyObj.ReprotingBoss1 = firstReportingBoss;
                            leaveApplyObj.ReprotingBoss2 = secondReportinBoss;
                            leaveApplyObj.ReprotingBossHRM = thirdReportingBoss;
                            leaveApplyObj.LeaveAppliedDate = DateTime.Now;
                            leaveApplyObj.LeaveResion = txtbxLeaveReason.Text;
                            leaveApplyObj.LeaveDates = Convert.ToDateTime(dates[i]);
                            leaveApplyObj.LeaveTypeId = Convert.ToInt32(drpLeaveType.SelectedValue);
                            leaveApplyObj.TotalDay = 1;
                            leaveApplyObj.ReportingBossId = hidReportingBossID.Value.ToString();
                            leaveApplyObj.ReprotingBossHRmApporveStatus = false;
                            leaveApplyObj.ReprotingBoss1ApproveStatus = false;
                            leaveApplyObj.ReportingBoss2ApporveStatus = false;
                            leaveApplyObj.ReprotingBoss1DisApproveStatus = false;
                            leaveApplyObj.ReportingBoss2DisApporveStatus = false;
                            leaveApplyObj.ReprotingBossHRmDisApporveStatus = false;
                            leaveApplyObj.Eid = lblApplicantId.Text;
                            leaveApplyObj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                            leaveApplyObj.EDIT_DATE = DateTime.Now;
                            leaveApplyObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                            leaveApplyes.Add(leaveApplyObj);
                        }
                        if (BtnLeaveSubmit.Text == "Submit")
                        {
                            int result = leaveBll.InsertLeaveApply(leaveApplyes);
                            if (result == 1)
                            {
                                lblMessage.Text = "Data Save Successfully.";
                                setAnnulLeave();
                                GetLeaveInfoByEmployeeId();
                            }
                        }
                        getLeaveCode();
                    }

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }



        private void clearAllControl()
        {
            lblTotalLeaveOFType.Text = "";
            lblTTaken.Text = "";
            lblTBalance.Text = "";
            txtbxLeaveReason.Text = "";
            txtLeaveDate.Text = "";
            txtbxTotalDay.Text = "";
            lblDateApplied.Text = DateTime.Now.ToString("dd/MM/yyyy");
            getLeaveTypes();

        }

        protected void drpLeaveType_SelectedChange(object sender, EventArgs e)
        {

            try
            {
                int lType = Convert.ToInt32(drpLeaveType.SelectedValue);
                ShowLeaveByLeaveType(lType);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ShowLeaveByLeaveType(int ltype)
        {
            try
            {

                int token = 0;
                LEAVE_BLL leaveBll = new LEAVE_BLL();
                //int leaveType = Convert.ToInt32(drpLeaveType.SelectedValue);
                int leaveType = ltype;

                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_LEAVE_TYPE> leaveTypes = leaveBll.getTotalLeaveOfTypeByTypeId(leaveType, ocode);
                foreach (HRM_LEAVE_TYPE aitem in leaveTypes)
                {
                    lblTotalLeaveOFType.Text = aitem.LEV_DAYS.ToString();
                }

                string currentYear = DateTime.Now.Year.ToString();
                List<TakenLeave> leaveApply = leaveBll.getTakenLeaveByLeaveType(leaveType, lblApplicantId.Text, ocode, currentYear).ToList();
                foreach (TakenLeave aitem in leaveApply)
                {
                    token += Convert.ToInt32(aitem.TotalLeaveTakenDay);
                }
                lblTTaken.Text = token.ToString();
                int balance = Convert.ToInt32(lblTotalLeaveOFType.Text) - token;
                lblTBalance.Text = balance.ToString();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void imgbtnLeaveEdit_Click(object sender, EventArgs e)
        {
            // HRM_LeaveApply LeaveApplyObj = new HRM_LeaveApply();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            StringBuilder builder = new StringBuilder();
            try
            {

                Label lblLeaveId = (Label)gridviewLeaveInfo.Rows[row.RowIndex].FindControl("lblLeaveId");
                if (lblLeaveId != null)
                {
                    string leaveCode = lblLeaveId.Text;
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    List<LeaveDate> hrmLeaveApplyeDate = leaveBll.GetAppliedDates(leaveCode, OCODE);
                    foreach (LeaveDate adate in hrmLeaveApplyeDate)
                    {
                        string date = adate.Dates.ToString();
                        builder.Append(date).Append(",");
                    }

                    string dates = builder.ToString();
                    System.Text.StringBuilder sb = new System.Text.StringBuilder();
                    sb.Append("<script type = 'text/javascript'>");
                    sb.Append("window.onload=function(){");
                    sb.Append("alert('");
                    sb.Append("Total Leave dates :" + dates);
                    sb.Append("')};");
                    sb.Append("</script>");
                    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

                    //leaveId = lblLeaveId.Text;
                    //LeaveApplyObj = leaveBll.GetLeaveInfoById(leaveId, OCODE);

                    //if (LeaveApplyObj != null)
                    //{
                    //    hidLeaveId.Value = LeaveApplyObj.LeaveId.ToString();
                    //    lblDateApplied.Text = LeaveApplyObj.LeaveAppliedDate.ToString();
                    //    drpLeaveType.SelectedValue = LeaveApplyObj.LeaveTypeId.ToString();
                    //   // txtLeaveDate.Text = LeaveApplyObj.LeaveDates;
                    //    txtbxTotalDay.Text = LeaveApplyObj.TotalDay.ToString();
                    //    txtbxLeaveReason.Text = LeaveApplyObj.LeaveResion;
                    //    ShowLeaveByLeaveType(Convert.ToInt32(LeaveApplyObj.LeaveTypeId));

                    //    if (BtnLeaveSubmit.Text == "Submit")
                    //    {
                    //        BtnLeaveSubmit.Text = "Update";
                    //    }
                    //}

                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
    }
}