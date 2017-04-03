using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.HRM
{
    public partial class LeaveApproveForReportingBoss1 : System.Web.UI.Page
    {
        LEAVE_BLL leaveBll = new LEAVE_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    string employeeId = Session["aLEID"].ToString();
                    string LeaveCode = Session["aLeaveID"].ToString();
                    GetEmployeeInformation(employeeId);
                    getLeaveTypes();
                    getLeaveInfoByLeaveId(LeaveCode);
                    ControllEnable();
                    GetApproveStatusByLeaveCode(LeaveCode);
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetApproveStatusByLeaveCode(string LeaveCode)
        {
            try
            {
                bool? FirstReportingBoss;
                bool? SecondReportingBoss;
                bool? HrmReportinBoss;
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_LeaveApply> leaveApplyes = leaveBll.GetLeaveStautsByCode(LeaveCode, OCODE);
                foreach (HRM_LeaveApply aitem in leaveApplyes)
                {
                    HrmReportinBoss = aitem.ReprotingBossHRmApporveStatus;
                    FirstReportingBoss = aitem.ReprotingBoss1ApproveStatus;
                    SecondReportingBoss = aitem.ReportingBoss2ApporveStatus;
                    if (FirstReportingBoss == false)
                    {
                        lbl1ApproveBy.Text = "Pending";
                    }
                    else
                    {
                        lbl1ApproveBy.Text = "Approve";
                    }

                    if (SecondReportingBoss == false)
                    {
                        lblSecond.Text = "Pending";
                    }
                    else
                    {
                        lblSecond.Text = "Approve";
                    }

                    if (HrmReportinBoss == false)
                    {
                        lblHRMApproveBY.Text = "Pending";
                    }
                    else
                    {
                        lblHRMApproveBY.Text = "Approve";
                    }

                    break;
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        private void getLeaveInfoByLeaveId(string LeaveCode)
        {

            string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            List<LeaveInfo> leaveinfoes = leaveBll.GetLeaveListByLeaveCode(LeaveCode, ocode);
            StringBuilder builder = new StringBuilder();
            if (leaveinfoes != null)
            {
                foreach (LeaveInfo aitem in leaveinfoes)
                {


                    hidLeaveCode.Value = aitem.LeaveCode.ToString();
                    lblDateApplied.Text = aitem.LeaveAppliedDate.ToString();
                    drpLeaveType.SelectedValue = aitem.LeaveTypeId.ToString();
                    //txtLeaveDate.Text = LeaveApplyObj.LeaveDates;
                    txtbxTotalDay.Text = aitem.TotalDay.ToString();
                    txtbxLeaveReason.Text = aitem.LeaveResion;
                    List<LeaveDate> hrmLeaveApplyeDate = leaveBll.GetAppliedDates(aitem.LeaveCode, ocode);
                    foreach (LeaveDate adate in hrmLeaveApplyeDate)
                    {
                        string date = adate.Dates.ToString();
                        builder.Append(date).Append(",");
                    }

                    string dates = builder.ToString();
                    lblLeaveDates.Text = dates;
                }
            }
        }

        private void ControllEnable()
        {
            drpLeaveType.Enabled = false;
            txtLeaveDate.Enabled = false;
            txtbxTotalDay.Enabled = false;
            txtbxLeaveReason.Enabled = false;
        }

        private void getLeaveTypes()
        {

            try
            {
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
            catch (Exception)
            {

                throw;
            }
        }

        private void GetEmployeeInformation(string employeeId)
        {

            try
            {

                EMPOYEE_BLL employeeBll = new EMPOYEE_BLL();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string eid = employeeId;
                List<AssignTo> assignTos = new List<AssignTo>();
                assignTos = employeeBll.GetDesgination(eid, OCODE).ToList();
                foreach (AssignTo assign in assignTos)
                {
                    lblApplicantId.Text = employeeId.ToString();
                    lblApplicantDesignation.Text = assign.DeginationName.ToString();
                    lblApplicantDepartment.Text = assign.DepartmentName.ToString();
                    List<HRM_PersonalInformations> personanlInfo = employeeBll.getEmpployeeNameById(eid, OCODE);
                    foreach (HRM_PersonalInformations aperson in personanlInfo)
                    {
                        lblApplicantName.Text = aperson.FirstName + " " + aperson.LastName;

                    }

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void CheckBox1_CheckChanged(object sender, EventArgs e)
        {
            try
            {

                if (lblHRMApproveBY.Text == "Approve")
                {
                    lblMessage.Text = "You cannot change date becuse HRM has apporved.";
                }
                else
                {
                    if (CheckBox1.Checked)
                    {
                        txtLeaveDate.Enabled = true;
                        txtbxTotalDay.Enabled = true;
                    }
                    else
                    {
                        drpLeaveType.Enabled = false;
                        txtLeaveDate.Enabled = false;
                        txtbxTotalDay.Enabled = false;
                        txtbxLeaveReason.Enabled = false;
                        btnDisapporve.Enabled = false;
                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnDisapporve_Click(object sender, EventArgs e)
        {
            try
            {
                string leaveCode = hidLeaveCode.Value;
                HRM_LeaveApply leaveApplyObj = new HRM_LeaveApply();
                leaveApplyObj.LeaveCode = leaveCode;
                leaveApplyObj.ReprotingBoss1DisApproveStatus = true;
                leaveApplyObj.ReprotingBoss1DisApproveDate = DateTime.Now;

                int result = leaveBll.LeaveForDisApproveNotChangeForReportingBoss1(leaveApplyObj);

                if (result == 1)
                {
                    lblMessage.Text = "This Leave has Dispproved";
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


        protected void BtnAprove_Click(object sender, EventArgs e)
        {
            try
            {

                LEAVE_BLL leaveBll = new LEAVE_BLL();

                // string leaveId = Session["aLeaveID"].ToString();
                // leaveApplyObj.ApporveBy = "SBD";              
                // leaveApplyObj.ApproveDate = DateTime.Now;
                //// leaveApplyObj.LeaveDates = txtLeaveDate.Text.ToString();
                // leaveApplyObj.TotalDay = Convert.ToInt32(txtbxTotalDay.Text);
                // string leaId = Session["aLeaveID"].ToString();

                if (txtLeaveDate.Text == "")
                {
                    string leaveCode = hidLeaveCode.Value;
                    HRM_LeaveApply leaveApplyObj = new HRM_LeaveApply();
                    leaveApplyObj.LeaveCode = leaveCode;
                    leaveApplyObj.ReprotingBoss1ApproveStatus = true;
                    leaveApplyObj.ReprotingBoss1ApproveDate = DateTime.Now;

                    int result = leaveBll.UpdateLeaveForApproveNotChangeForReportingBoss1(leaveApplyObj);

                    if (result == 1)
                    {
                        lblMessage.Text = "This Leave has Approved";
                    }

                }
                else
                {
                    List<HRM_LeaveApply> newLeaveApplyList = new List<HRM_LeaveApply>();
                    string[] dates = txtLeaveDate.Text.Split(',');

                    if (dates.Length > 0)
                    {


                        for (int i = 0; i < dates.Length; i++)
                        {
                            string leaveCode = hidLeaveCode.Value;
                            HRM_LeaveApply leaveApplyObj = new HRM_LeaveApply();
                            // DateTime ConvertDate = Convert.ToDateTime(dates[i]);
                            //string formateDate = ConvertDate.ToString("yyyy-MM-dd");                            
                            leaveApplyObj.LeaveCode = leaveCode;
                            leaveApplyObj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                            leaveApplyObj.LeaveDates = Convert.ToDateTime(dates[i]);
                            leaveApplyObj.ReprotingBossHRmApporveStatus = true;
                            leaveApplyObj.ReportingBossHRMApproveDate = DateTime.Now.Date;
                            newLeaveApplyList.Add(leaveApplyObj);
                        }
                    }
                    int result = leaveBll.UpdateLeaveChangeForReportingBoss1(newLeaveApplyList);

                    if (result == 1)
                    {
                        lblMessage.Text = "This Leave has Approved";
                    }
                }
                //int result = leaveBll.UpdateLeaveForApprove(leaveApplyObj, leaId);
                //if (result == 1)
                //{
                //    lblMessage.Text = "This Leave has Approved";
                //}


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
    }
}