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
    public partial class MaternityLeave : System.Web.UI.Page
    {
        LEAVE_BLL leaveBll = new LEAVE_BLL();
        EmployeeSetup_DAL employeeSetUpDal = new EmployeeSetup_DAL();
        MaternityLeaveBLL maternityLeaveBll = new MaternityLeaveBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    string eid = ((SessionUser)Session["SessionUser"]).EID;

                    HRM_PersonalInformations personal = employeeSetUpDal.GetEmployeeGender(eid);

                    if (personal.Gender == "Female")
                    {
                        getLeaveCode();
                        getApplicantInfo();
                        GetMaternityLeaveInfo();
                        lblDateApplied.Text = DateTime.Now.ToString("dd/MM/yyyy");
                        GetMaternityLeaveInfoForList();
                    }
                    else
                    {
                        System.Text.StringBuilder sb = new System.Text.StringBuilder();
                        sb.Append("<script type = 'text/javascript'>");
                        sb.Append("window.onload=function(){");
                        sb.Append("alert('");
                        sb.Append("You are not able to Apply !");
                        sb.Append("')};");
                        sb.Append("</script>");
                        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
                    }
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetMaternityLeaveInfoForList()
        {
            try
            {


                string eid = ((SessionUser)Session["SessionUser"]).EID;
                if (eid != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    string currentYear = DateTime.Now.Year.ToString();

                    List<MaternityLeaveR> maternity = maternityLeaveBll.GetMaternityLeaveInfoForList(eid, currentYear, OCODE);
                    if (maternity.Count > 0)
                    {
                        gridviewLeaveInfo.DataSource = maternity;
                        gridviewLeaveInfo.DataBind();
                    }
                }
            }
            catch (Exception)
            {

                throw;
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
        protected void txtbxLeaveDateTo_TextChanged(object sender, EventArgs e)
        {

            try
            {
                DateTime endDate = Convert.ToDateTime(txtbxLeaveDateFrom.Text);
                Int64 addedDays = Convert.ToInt64(lblTotalMaternityLeave.Text);
                endDate = endDate.AddDays(addedDays);
                txtbxLeaveDateTo.Text = endDate.ToShortDateString();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void GetMaternityLeaveInfo()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var MaternityLeave = leaveBll.GetMaternityLeaveInfo(OCODE);
                if (MaternityLeave.Count > 0)
                {
                    foreach (HRM_LEAVE_TYPE aitem in MaternityLeave)
                    {
                        lblTotalMaternityLeave.Text = aitem.LEV_DAYS.ToString();
                    }
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
                    List<HRM_PersonalInformations> personanlInfo1 = employeeBll.getEmpployeeNameById(eid, OCODE);
                    foreach (HRM_PersonalInformations aperson in personanlInfo1)
                    {
                        lblApplicantName.Text = aperson.FirstName + " " + aperson.LastName;
                        //hidReportingBossID.Value = aperson.ReportingBossId.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void BtnLeaveSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_MaternityLeave maternityLeave = new HRM_MaternityLeave();
                HRM_PersonalInformations personalInfo = employeeSetUpDal.GetReportingBossById(lblApplicantId.Text);
                string hrmReportinBossId = personalInfo.ThirdReportingBossId;

                TimeSpan difference = Convert.ToDateTime(txtbxLeaveDateTo.Text) - Convert.ToDateTime(txtbxLeaveDateFrom.Text);
                var days = difference.TotalDays;
                if (days > Convert.ToInt32(lblTotalMaternityLeave.Text))
                {
                    lblMessage.Text = "Please Check Maternity Leave!";
                }
                else
                {
                    maternityLeave.AppliedDate = DateTime.Now;
                    maternityLeave.EID = lblApplicantId.Text;
                    maternityLeave.LeaveDateFrom = Convert.ToDateTime(txtbxLeaveDateFrom.Text);
                    maternityLeave.LeaveDateTo = Convert.ToDateTime(txtbxLeaveDateTo.Text);
                    maternityLeave.Description = txtbxDexrcription.Text;
                    maternityLeave.ApproveStatus = false;
                    maternityLeave.DisApproveStatus = false;
                    maternityLeave.HrmReportinBossId = hrmReportinBossId;
                    maternityLeave.TotalDay = Convert.ToInt32(days);
                    maternityLeave.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    maternityLeave.EDIT_DATE = DateTime.Now;
                    maternityLeave.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    int result = maternityLeaveBll.SaveMaternityLeaveInfo(maternityLeave);
                    if (result == 1)
                    {
                        lblMessage.Text = "Data Save Successfully!";
                        GetMaternityLeaveInfoForList();
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