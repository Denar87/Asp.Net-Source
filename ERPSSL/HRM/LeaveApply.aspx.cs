using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.HRM
{
    public partial class LeaveApply : System.Web.UI.Page
    {
        EMPOYEE_BLL objEmp_BLL = new EMPOYEE_BLL();
        LEAVE_BLL objLeave_BLL = new LEAVE_BLL();
        ERPSSLHBEntities _context = new ERPSSLHBEntities();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {         
                getLeaveTypes();
                getApplicantInfo();
                LeaveApplyAndDetailsInfo();
              //  gethrmemployeeList();                    
            }
        }

        private void getLeaveEnjoyedInfoById(string Eid)
        {
            try
            {
                int resultsML = (from la in _context.HRM_LeaveApply
                                 where la.LeaveTypeId == 4 && la.Eid == Eid && la.IsPandingStatus==true 
                                 select la.LeaveTypeId).Count();
                lblMLE.Text = resultsML.ToString();

                int resultscl = (from la in _context.HRM_LeaveApply
                                 where la.LeaveTypeId == 1 && la.Eid == Eid && la.IsPandingStatus == true
                                 select la.LeaveTypeId).Count();

                lblCloE.Text = resultscl.ToString();


                int resultsAL = (from la in _context.HRM_LeaveApply
                                 where la.LeaveTypeId == 3 && la.Eid == Eid && la.IsPandingStatus == true
                                 select la.LeaveTypeId).Count();

                lblALE.Text = resultsAL.ToString();


                int resultsSL = (from la in _context.HRM_LeaveApply
                                 where la.LeaveTypeId == 2 && la.Eid == Eid && la.IsPandingStatus == true
                                 select la.LeaveTypeId).Count();

                lblSLE.Text = resultsSL.ToString();
                int resultsLpe = (from la in _context.HRM_LeaveApply
                                  where la.LeaveTypeId == 5 && la.Eid == Eid && la.IsPandingStatus == true
                                  select la.LeaveTypeId).Count();

                lblLWPE.Text = resultsLpe.ToString();
                lblClB.Text = (Convert.ToInt16(lblCl.Text) - Convert.ToInt16(lblCloE.Text)).ToString();
                lblSLB.Text = (Convert.ToInt16(lblSl.Text) - Convert.ToInt16(lblSLE.Text)).ToString();
                lblALB.Text = (Convert.ToInt16(lblAL.Text) - Convert.ToInt16(lblALE.Text)).ToString();
                lblMLB.Text = (Convert.ToInt16(lblML.Text) - Convert.ToInt16(lblMLE.Text)).ToString();
                lblLWPB.Text = (Convert.ToInt16(lblLWP.Text) - Convert.ToInt16(lblLWPE.Text)).ToString();    
   
                //---------------------------Pending -----------------------------------------------------

                int resultsMLp = (from la in _context.HRM_LeaveApply
                                 where la.LeaveTypeId == 4 && la.Eid == Eid && la.IsPandingStatus == false
                                 select la.LeaveTypeId).Count();
                
                int resultsclp = (from la in _context.HRM_LeaveApply
                                 where la.LeaveTypeId == 1 && la.Eid == Eid && la.IsPandingStatus == false
                                 select la.LeaveTypeId).Count();


                int resultsALp = (from la in _context.HRM_LeaveApply
                                 where la.LeaveTypeId == 3 && la.Eid == Eid && la.IsPandingStatus == false
                                 select la.LeaveTypeId).Count();

                int resultsSLp = (from la in _context.HRM_LeaveApply
                                 where la.LeaveTypeId == 2 && la.Eid == Eid && la.IsPandingStatus == false
                                 select la.LeaveTypeId).Count();

                
                int resultsLpep = (from la in _context.HRM_LeaveApply
                                  where la.LeaveTypeId == 5 && la.Eid == Eid && la.IsPandingStatus == false
                                  select la.LeaveTypeId).Count();

                lblClP.Text = resultsclp.ToString();
                lblSlP.Text = resultsSLp.ToString();
                lblAlP.Text = resultsALp.ToString();
                lblMlP.Text = resultsMLp.ToString();
                lblWpP.Text = resultsLpep.ToString();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void LeaveApplyAndDetailsInfo()
        { 
          try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                string eid = ((SessionUser)Session["SessionUser"]).EID;

                //string employeeID = Convert.ToString(txtEid_TRNS.Text);
                getLeaveEnjoyedInfoById(eid);
                LoadApprovePersonListByEid(eid);
                var result = objEmp_BLL.GetEmployeeDetailsIDCard(eid, OCODE).ToList();
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
              throw ex;
          }
        }

        //private void gethrmemployeeList()
        //{
        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        List<ReportingBoss> personalInfos = objEmp_BLL.GetPersonalInfoByDepartment(OCODE);
        //        if (personalInfos.Count > 0)
        //        {
        //            //drpdwnApproveSupervisor.DataSource = personalInfos;
        //            //drpdwnApproveSupervisor.DataTextField = "FulllName";
        //            //drpdwnApproveSupervisor.DataValueField = "EID";
        //            //drpdwnApproveSupervisor.DataBind();
        //            //drpdwnApproveSupervisor.Items.Insert(0, new ListItem("--Select--", "0"));



        //            //drpApprovedAdmin.DataSource = personalInfos;
        //            //drpApprovedAdmin.DataTextField = "FulllName";
        //            //drpApprovedAdmin.DataValueField = "EID";
        //            //drpApprovedAdmin.DataBind();
        //            //drpApprovedAdmin.Items.Insert(0, new ListItem("--Select--", "0"));


        //            drpApprovedHR.DataSource = personalInfos;
        //            drpApprovedHR.DataTextField = "FulllName";
        //            drpApprovedHR.DataValueField = "EID";
        //            drpApprovedHR.DataBind();
        //            drpApprovedHR.Items.Insert(0, new ListItem("--Select--", "0"));

                    

        //        }


        //    }
        //    catch (Exception)
        //    {
                
        //        throw;
        //    }
           

        //}

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
                        txtEid_TRNS.Text = ((SessionUser)Session["SessionUser"]).EID;
                        txtDesignation.Text = assign.DeginationName.ToString();
                        txtDepartment.Text = assign.DepartmentName.ToString();
                        string employeeID = Convert.ToString(txtEid_TRNS.Text);
                        Emp_IMG_TR.Visible = true;
                        Emp_IMG_TR.ImageUrl = "EmployeeIMG.ashx?eId=" + eid + "&oCode=" + OCODE;
                    }
                    List<HRM_PersonalInformations> personanlInfo = employeeBll.getEmpployeeNameById(eid, OCODE);
                    foreach (HRM_PersonalInformations aperson in personanlInfo)
                    {
                        txtEmpName_TRNS.Text = aperson.FirstName + " " + aperson.LastName;
                        //hidReportingBossID.Value = aperson.ReportingBossId.ToString();
                    }



                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void btnSave_click(object sender, EventArgs e)
        {
            try
            {

                if (txtEid_TRNS.Text=="")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input E-ID')", true);                    
                }
                else if (drpLeaveType.SelectedItem.ToString() == "--Select--")
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

                    if (!IsExist())
                    {
                        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                        int count = objLeave_BLL.GetLastRowNumber(OCODE);
                        int total = count + 1;
                        string Code = " LC" + total;

                            string thirdReportingBoss=null;
                            string secondReportingBoss=null;
                            string hrmreportinBoss=null; 
                        HRM_PersonalInformations _personalinfo = objEmp_BLL.getPersonalInfosByID(txtEid_TRNS.Text);
                        if (_personalinfo.ReportingBossId != null)
                        {
                            hrmreportinBoss = _personalinfo.ReportingBossId.ToString();
                        }
                        if (_personalinfo.SecondReportingBossId != null)
                        {
                             secondReportingBoss = _personalinfo.SecondReportingBossId.ToString();
                        }
                        if (_personalinfo.ThirdReportingBossId != null)
                        {
                            thirdReportingBoss = _personalinfo.ThirdReportingBossId.ToString();
                        }
                        DateTime DateTimeFrom = Convert.ToDateTime(txtbxFromDate.Text);
                        DateTime DateTo = Convert.ToDateTime(txtbxToDate.Text);
                        List<HRM_LeaveApply> leaveApplyesDates = new List<HRM_LeaveApply>();
                        for (int i = 0; i < Convert.ToInt16(txtbxTotalDay.Text); i++)
                        {
                            HRM_LeaveApply leaveApplyObj = new HRM_LeaveApply();
                            leaveApplyObj.LeaveCode = Code;
                            leaveApplyObj.OCODE = OCODE;
                            leaveApplyObj.LeaveDates = DateTimeFrom.AddDays(i);
                            leaveApplyObj.LeaveAppliedDate = Convert.ToDateTime(txtbxFromDate.Text);
                            leaveApplyObj.LeaveToDate = Convert.ToDateTime(txtbxToDate.Text);
                            leaveApplyObj.Eid = txtEid_TRNS.Text;
                            leaveApplyObj.LeaveTypeId = Convert.ToInt16(drpLeaveType.SelectedValue.ToString());
                            leaveApplyObj.LeaveCurrentYear = DateTime.Now.Year;
                            leaveApplyObj.LeaveResion = txtbxResion.Text.Trim();
                            leaveApplyObj.TotalDay = 1;
                            leaveApplyObj.IsPandingStatus = false;
                            leaveApplyObj.LeaveStatusHRM = false;
                            leaveApplyObj.ReprotingBoss1ApproveStatus = false;
                            leaveApplyObj.ReportingBoss2ApporveStatus = false;


                            leaveApplyObj.ReprotingBossHRM = hrmreportinBoss;
                            leaveApplyObj.ReprotingBoss1 = secondReportingBoss;
                            leaveApplyObj.ReprotingBoss2 = thirdReportingBoss;
                            

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
                                  ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                              }


                        }

                        string eid = txtEid_TRNS.Text;

                        List<LeaveForReport> report = new List<LeaveForReport>();
                        report = objLeave_BLL.GetEmployeeApplyReport(eid, DateTimeFrom, DateTo);

                        if (report.Count > 0)
                        {



                            Session["rptDs"] = "DataSet1";
                            Session["rptDt"] = report;
                            Session["rptFile"] = "/HRM/reports/HRM_Leave_Apply_ById.rdlc";
                            Session["rptTitle"] = "Leave Apply";
                            Response.Redirect("Report_Viewer.aspx");

                            //ReportViewer1.LocalReport.DataSources.Clear();
                            //ReportDataSource rpts = new ReportDataSource("DataSet1", report);
                            //ReportViewer1.LocalReport.DataSources.Add(rpts);
                            //ReportViewer1.LocalReport.ReportPath = "D:/TFS/HOMEBOUND/ERPSSL/HRM/reports/HRM_Leave_Apply_ById.rdlc";

                            //ReportViewer1.LocalReport.Refresh();
                            //rpt_Leave_Apply.Reset();
                            //ReportDataSource rpts = new ReportDataSource("D:/TFS/HOMEBOUND/ERPSSL/HRM/reports/DataSet1", report);
                            //rpt_Leave_Apply.LocalReport.DataSources.Add(rpts);
                            //rpt_Leave_Apply.LocalReport.ReportPath = "D:/TFS/HOMEBOUND/ERPSSL/HRM/reports/HRM_Leave_Apply_ById.rdlc";
                        
                           
                            
                        }


                    }
                
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('This Date Already Exist for Leave !')", true);
                    }
                
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
       


        private bool IsExist()
        {

            bool status = false;
            DateTime AppliedDate = Convert.ToDateTime(txtbxFromDate.Text);
            DateTime ToDate = Convert.ToDateTime(txtbxToDate.Text);
            string eid=txtEid_TRNS.Text;

            var item = (from aitem in _context.HRM_LeaveApply
                        where aitem.Eid == eid && (aitem.LeaveDates >= AppliedDate && aitem.LeaveDates<=ToDate)
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
            catch (Exception)
            {

                throw;
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
            catch (Exception)
            {

                //throw;
            }
        }
        //protected void txtEIdNo_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        string employeeID = Convert.ToString(txtEid_TRNS.Text);
        //        getLeaveEnjoyedInfoById(employeeID);
        //        LoadApprovePersonListByEid(employeeID);
        //        var result = objEmp_BLL.GetEmployeeDetailsIDCard(employeeID, OCODE).ToList();
        //        if (result.Count > 0)
        //        {
        //            var objNewEmp = result.First();
        //            Emp_IMG_TR.Visible = true;
        //            Emp_IMG_TR.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;
        //            if (objNewEmp.Gender == "Male")
        //            {
        //                getLeaveTypeForMale();
        //                mlHeader.Visible = false;
        //                rdToal.Visible = false;
        //                tdMLE.Visible = false;
        //                tdmlB.Visible = false;
        //            }
        //            else
        //            {
        //                getLeaveTypesfordrp();
        //                mlHeader.Visible = true;
        //                rdToal.Visible = true;
        //                tdMLE.Visible = true;
        //                tdmlB.Visible = true;

        //            }
                   
                   
        //            txtEid_TRNS.Text = Convert.ToString(objNewEmp.EID);
        //            txtEmpName_TRNS.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
        //            txtDepartment.Text = objNewEmp.DPT_NAME;
        //            txtDesignation.Text = objNewEmp.DEG_NAME;
        //        }
        //        else
        //        {
        //            Emp_IMG_TR.Visible = false;
        //            txtEmpName_TRNS.Text = "";
        //            txtDepartment.Text = "";
        //            txtDesignation.Text = "";
        //            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('This Employee is Inactive!')", true);
        //            //NO RECORDS FOUND.
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

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

               List<ReportingBoss> personalforHrm = objEmp_BLL.getPersonalInfoForHRM();

               if (personalforHrm.Count > 0)
               {

                   drpApprovedHR.DataSource = personalforHrm;
                   drpApprovedHR.DataTextField = "FulllName";
                   drpApprovedHR.DataValueField = "EID";
                   drpApprovedHR.DataBind();
                   drpApprovedHR.Items.Insert(0, new ListItem("--Select--", "0"));
               }

           }
           catch 
           {
               
               
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
            catch (Exception)
            {
                
                throw;
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
            catch (Exception)
            {
                
                throw;
            }
        }

      
      
    }
}