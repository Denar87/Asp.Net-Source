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
    public partial class EmployeeReActive : System.Web.UI.Page
    {
        EMPOYEE_BLL objEmp_BLL = new EMPOYEE_BLL();
        LEAVE_BLL _leaveBll = new LEAVE_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        protected void txtEIdNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string employeeID = Convert.ToString(txtEid_TRNS.Text);              
                var result = objEmp_BLL.GetTerminateEmployeeList(employeeID, OCODE).ToList();
                if (result.Count > 0)
                {
                    Emp_IMG_TRNS.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;
                    var objNewEmp = result.First();
                    txtEid_TRNS.Text = Convert.ToString(objNewEmp.EID);
                    txtEmpName_TRNS.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                    txtDepartment.Text = objNewEmp.DPT_NAME;
                    txtDesignation.Text = objNewEmp.DEG_NAME;
                }
                else
                {
                    //NO RECORDS FOUND.
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {


                if (txtEid_TRNS.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input E-ID')", true);
                }
                else if (chewithPreviousData.Checked == false && cheWithoutPreviousData.Checked == false)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Condition')", true);
                }
                else
                {
                    ERPSSLHBEntities _context = new ERPSSLHBEntities();
                    HRM_JOB_TERMINATE obj = new HRM_JOB_TERMINATE();
                    obj.TERMINATE_DATE = DateTime.Now;
                    obj.REMARKS = txtRemarks_TRM.Text;
                    obj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    obj.EDIT_DATE = DateTime.Now;
                    obj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    string eid = txtEid_TRNS.Text;

                    if (cheWithoutPreviousData.Text == "Without Previous Data")
                    {
                        List<HRM_LeaveApply> hrm_leaveDetails = _leaveBll.GetLeavesByEID(eid);
                        int result = SaveReactiveLeavetable(hrm_leaveDetails);

                        HRM_PersonalInformations objEmpUpdate1 = _context.HRM_PersonalInformations.First(x => x.EID == eid);
                        objEmpUpdate1.EMP_TERMIN_STATUS = false;
                        objEmpUpdate1.EMP_Retired_Status = false;
                        objEmpUpdate1.EMP_Resignation_Status = false;
                        objEmpUpdate1.EMP_Dismissal_Status = false;
                        objEmpUpdate1.EMP_Died_Status = false;
                        objEmpUpdate1.EMP_Dis_Continution_Status = false;
                        objEmpUpdate1.EMP_Other = false;
                        objEmpUpdate1.Seperation_Date = null;

                        HRM_JOB_TERMINATE objEmpUpdate = _context.HRM_JOB_TERMINATE.First(x => x.EID == eid);

                        objEmpUpdate.Status = "Re-Active";
                        objEmpUpdate.Termination_Status = false;
                        objEmpUpdate.TERMINATE_DATE = DateTime.Now;
                        _context.SaveChanges();
                        int reslut = _leaveBll.DeleteLeaveDetailsByEID(eid);
                        //lblTrMessage.Text = "Record Added successfully!";
                        //lblTrMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Active Successfully!')", true);


                    }
                    else
                    {

                        HRM_PersonalInformations objEmpUpdate1 = _context.HRM_PersonalInformations.First(x => x.EID == eid);
                        objEmpUpdate1.EMP_TERMIN_STATUS = false;
                        objEmpUpdate1.EMP_Retired_Status = false;
                        objEmpUpdate1.EMP_Resignation_Status = false;
                        objEmpUpdate1.EMP_Dismissal_Status = false;
                        objEmpUpdate1.EMP_Died_Status = false;
                        objEmpUpdate1.EMP_Dis_Continution_Status = false;
                        objEmpUpdate1.EMP_Other = false;
                        objEmpUpdate1.Seperation_Date = null;

                        HRM_JOB_TERMINATE objEmpUpdate = _context.HRM_JOB_TERMINATE.First(x => x.EID == eid);
                        objEmpUpdate.Status = "Re-Active";
                        objEmpUpdate.Termination_Status = false;
                        objEmpUpdate.TERMINATE_DATE = DateTime.Now;
                        _context.SaveChanges();
                        //lblTrMessage.Text = "Record Added successfully!";
                        //lblTrMessage.ForeColor = System.Drawing.Color.Green;
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Active Successfully!')", true);
                    }
                }
                
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private int SaveReactiveLeavetable(List<HRM_LeaveApply> hrm_leaveDetails)
        {
                ERPSSLHBEntities _context = new ERPSSLHBEntities();
                foreach (HRM_LeaveApply aitm in hrm_leaveDetails)
                {
                    HRM_Re_Active_LeaveApply reactiveleaveApply = new HRM_Re_Active_LeaveApply();
                    reactiveleaveApply.LeaveCode = aitm.LeaveCode;
                    reactiveleaveApply.Eid = aitm.Eid;
                    reactiveleaveApply.ReportingBossId = aitm.ReportingBossId;
                    reactiveleaveApply.LeaveAppliedDate = aitm.LeaveAppliedDate;
                    reactiveleaveApply.LeaveDates = aitm.LeaveDates;
                    reactiveleaveApply.LeaveTypeId = aitm.LeaveTypeId;
                    reactiveleaveApply.TotalDay = aitm.TotalDay;
                    reactiveleaveApply.LeaveResion = aitm.LeaveResion;
                    reactiveleaveApply.LeaveToDate = aitm.LeaveToDate;
                    reactiveleaveApply.LeaveCurrentYear = aitm.LeaveCurrentYear;
                    reactiveleaveApply.ReprotingBoss1 = aitm.ReprotingBoss1;
                    reactiveleaveApply.ReprotingBoss2 = aitm.ReprotingBoss2;
                    reactiveleaveApply.ReprotingBossHRM = aitm.ReprotingBossHRM;
                    reactiveleaveApply.ReprotingBoss1ApproveStatus = aitm.ReprotingBoss1ApproveStatus;
                    reactiveleaveApply.ReportingBoss2ApporveStatus = aitm.ReportingBoss2ApporveStatus;
                    reactiveleaveApply.ReprotingBossHRmApporveStatus = aitm.ReprotingBossHRmApporveStatus;
                    reactiveleaveApply.ReprotingBoss1ApproveDate = aitm.ReprotingBoss1ApproveDate;
                    reactiveleaveApply.ReportingBoss2ApproveDate = aitm.ReportingBoss2ApproveDate;
                    reactiveleaveApply.ReportingBossHRMApproveDate = aitm.ReportingBossHRMApproveDate;
                    reactiveleaveApply.ReprotingBoss1DisApproveStatus = aitm.ReprotingBoss1DisApproveStatus;
                    reactiveleaveApply.ReportingBoss2DisApporveStatus = aitm.ReportingBoss2DisApporveStatus;
                    reactiveleaveApply.ReprotingBossHRmDisApporveStatus = aitm.ReprotingBossHRmDisApporveStatus;
                    reactiveleaveApply.ReprotingBoss1DisApproveDate = aitm.ReprotingBoss1DisApproveDate;
                    reactiveleaveApply.ReportingBoss2DisApproveDate = aitm.ReportingBoss2DisApproveDate;
                    reactiveleaveApply.ReportingBossHRMDisApproveDate = aitm.ReportingBossHRMDisApproveDate;
                    reactiveleaveApply.ReportingBoss = aitm.ReportingBoss;
                    reactiveleaveApply.LeaveStatusHRM = aitm.LeaveStatusHRM;
                    reactiveleaveApply.LeaveStatusForReportingBoss = aitm.LeaveStatusForReportingBoss;
                    reactiveleaveApply.ApporveBy = aitm.ApporveBy;
                    reactiveleaveApply.IsPandingStatus = aitm.IsPandingStatus;
                    reactiveleaveApply.ApproveDate = aitm.ApproveDate;
                    reactiveleaveApply.EDIT_USER = aitm.EDIT_USER;
                    reactiveleaveApply.EDIT_DATE = aitm.EDIT_DATE;
                    reactiveleaveApply.OCODE = aitm.OCODE;

                    _context.HRM_Re_Active_LeaveApply.AddObject(reactiveleaveApply);
                    _context.SaveChanges();
                }
                _context.SaveChanges();
                return 1;
           
        }


        //protected void btnSepartaion_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        string[] EmpSrachItem = this.txtbxSeparation.Text.Split(' ');
        //        List<REmployee> employees = new List<REmployee>();

        //        employees = employeeBll.GetSeparationSearchEmployeesList(OCODE, EmpSrachItem[0]).ToList();
        //        if (employees.Count > 0)
        //        {
                   


        //        }
               
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }

        //}

        //[System.Web.Script.Services.ScriptMethod()]
        //[System.Web.Services.WebMethod]
        //public static List<string> EmployeeSepartioanSearch(string prefixText, int count)
        //{
        //    using (var _context = new ERPSSLHBEntities())
        //    {
        //        var employees = from emp in _context.HRM_PersonalInformations
        //                        where ((emp.EMP_TERMIN_STATUS == true || emp.EMP_Retired_Status == true || emp.EMP_Resignation_Status == true || emp.EMP_Dismissal_Status == true || emp.EMP_Died_Status == true || emp.EMP_Dis_Continution_Status == true || emp.EMP_Other == true) && (emp.FirstName.StartsWith(prefixText) || emp.LastName.StartsWith(prefixText) || emp.EID.StartsWith(prefixText) || emp.Gender.StartsWith(prefixText) || emp.ContactNumber.StartsWith(prefixText) || emp.Email.StartsWith(prefixText)))
        //                        select emp;

        //        List<String> employeeList = new List<String>();

        //        foreach (var employee in employees)
        //        {
        //            employeeList.Add(employee.FirstName + " " + employee.LastName);
        //        }

        //        //System.Threading.Thread.Sleep(500);
        //        return employeeList;
        //    }
        //}
    }
}