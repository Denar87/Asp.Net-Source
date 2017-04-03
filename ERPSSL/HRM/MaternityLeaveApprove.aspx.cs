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
    public partial class MaternityLeaveApprove : System.Web.UI.Page
    {
        MaternityLeaveBLL maternityLeaveBll = new MaternityLeaveBLL();
        LEAVE_BLL leaveBll = new LEAVE_BLL();
        EmployeeSetup_DAL employeeSetUpDal = new EmployeeSetup_DAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                string employeeId = Session["aLEID"].ToString();
                string LeaveCode = Session["aLeaveID"].ToString();
                if (!IsPostBack)
                {
                    GetEmployeeInformation(employeeId);
                    GetMaternityLeaveDetails(employeeId);
                    ControllEnable();
                    getLeaveCode();

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


        private void GetMaternityLeaveDetails(string employeeId)
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            List<HRM_MaternityLeave> maternityleaves = maternityLeaveBll.GetMaternityDetailsByEmployeeId(employeeId, OCODE);
            foreach (HRM_MaternityLeave aitem in maternityleaves)
            {
                txtbbxAppliedDate.Text = aitem.AppliedDate.ToString();
                txtbxLeaveDateFrom.Text = aitem.LeaveDateFrom.ToString();
                txtbxDexrcription.Text = aitem.Description.ToString();
                txtbxLeaveDateTo.Text = aitem.LeaveDateTo.ToString();
                txtbxTotalDay.Text = aitem.TotalDay.ToString();

            }
        }
        private void ControllEnable()
        {

            txtbxLeaveDateFrom.Enabled = false;
            txtbxLeaveDateTo.Enabled = false;
            txtbxTotalDay.Enabled = false;
            txtbxTotalDay.Enabled = false;
            txtbxDexrcription.Enabled = false;
            txtbbxAppliedDate.Enabled = false;
        }
        protected void CheckBox1_CheckChanged(object sender, EventArgs e)
        {
            try
            {
                if (CheckBox1.Checked)
                {
                    txtbxLeaveDateTo.Enabled = true;
                    txtbxLeaveDateFrom.Enabled = true;
                }
                else
                {
                    txtbxLeaveDateFrom.Enabled = false;
                    txtbxLeaveDateTo.Enabled = false;
                    txtbxTotalDay.Enabled = false;
                    txtbxTotalDay.Enabled = false;
                    txtbxDexrcription.ReadOnly = false;
                    txtbbxAppliedDate.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
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
        private int GetMaternityLeaveInfo()
        {
            try
            {
                int totlaMaternityLeave = 0;
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var MaternityLeave = leaveBll.GetMaternityLeaveInfo(OCODE);
                if (MaternityLeave.Count > 0)
                {
                    foreach (HRM_LEAVE_TYPE aitem in MaternityLeave)
                    {
                        totlaMaternityLeave = Convert.ToInt32(aitem.LEV_DAYS);
                    }
                }
                return totlaMaternityLeave;

            }
            catch (Exception)
            {

                throw;
            }

        }
        protected void txtbxLeaveDateTo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                int totalMaternityLeave = GetMaternityLeaveInfo();
                TimeSpan difference = Convert.ToDateTime(txtbxLeaveDateTo.Text) - Convert.ToDateTime(txtbxLeaveDateFrom.Text);
                var days = difference.TotalDays;
                if (days > Convert.ToInt32(totalMaternityLeave))
                {
                    lblMessage.Text = "Please Check Maternity Leave!";
                }
                else
                {
                    txtbxTotalDay.Text = days.ToString();
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

                List<HRM_LeaveApply> leaveApplyes = new List<HRM_LeaveApply>();
                int totalMaternityLeave = GetMaternityLeaveInfo();
                TimeSpan difference = Convert.ToDateTime(txtbxLeaveDateTo.Text) - Convert.ToDateTime(txtbxLeaveDateFrom.Text);
                var days = difference.TotalDays;
                if (days > Convert.ToInt32(totalMaternityLeave))
                {
                    lblMessage.Text = "Please Check Maternity Leave!";
                }
                else
                {
                    DateTime begin = Convert.ToDateTime(txtbxLeaveDateFrom.Text);
                    DateTime end = Convert.ToDateTime(txtbxLeaveDateTo.Text);
                    List<DateTime> dates = new List<DateTime>();
                    for (DateTime date = begin; date < end; date = date.AddDays(1))
                    {
                        HRM_LeaveApply leaveApply = new HRM_LeaveApply();
                        leaveApply.TotalDay = 1;
                        leaveApply.ReprotingBossHRmApporveStatus = true;
                        leaveApply.ReportingBossHRMApproveDate = DateTime.Now;
                        leaveApply.LeaveDates = date;
                        leaveApply.LeaveCode = lblLeaveId.Text;
                        leaveApply.Eid = lblApplicantId.Text;
                        leaveApply.LeaveTypeId = 6;
                        leaveApply.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                        leaveApply.EDIT_DATE = DateTime.Now;
                        leaveApply.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                        leaveApplyes.Add(leaveApply);
                        //dates.Add(date);
                    }
                    int result = leaveBll.MaternityLeaveAccept(leaveApplyes);
                    if (result == 1)
                    {
                        HRM_MaternityLeave maternityLeave = new HRM_MaternityLeave();
                        maternityLeave.StatusDate = DateTime.Now;
                        maternityLeave.EID = lblApplicantId.Text;
                        maternityLeave.ApproveStatus = true;
                        int result1 = maternityLeaveBll.ApproveMaternityLeaveLeaveInfo(maternityLeave);
                        if (result1 == 1)
                        {
                            lblMessage.Text = "Approve Successfully!";
                        }
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
                HRM_MaternityLeave maternityLeave = new HRM_MaternityLeave();
                int totalMaternityLeave = GetMaternityLeaveInfo();
                TimeSpan difference = Convert.ToDateTime(txtbxLeaveDateTo.Text) - Convert.ToDateTime(txtbxLeaveDateFrom.Text);
                var days = difference.TotalDays;
                if (days > Convert.ToInt32(totalMaternityLeave))
                {
                    lblMessage.Text = "Please Check Maternity Leave!";
                }
                else
                {
                    maternityLeave.StatusDate = DateTime.Now;
                    maternityLeave.EID = lblApplicantId.Text;
                    maternityLeave.DisApproveStatus = true;

                    int result = maternityLeaveBll.DisApproveMaternityLeaveInfo(maternityLeave);
                    if (result == 1)
                    {
                        lblMessage.Text = "DisApprove Successfully!";
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