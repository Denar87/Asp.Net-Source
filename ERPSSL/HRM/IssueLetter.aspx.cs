using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;
using Microsoft.Reporting.WebForms;

namespace ERPSSL.HRM
{
    public partial class IssueLetter : System.Web.UI.Page
    {
        EmployeeSetup_BLL objEmp_BLL = new EmployeeSetup_BLL();
        LatterFormatBLL latterFormateBll = new LatterFormatBLL();
        LetterTypeBLL letterTypeBllObj = new LetterTypeBLL();
        DEPARTMENT_BLL DepartmentBll = new DEPARTMENT_BLL();
        EmployeeSetup_BLL employeeBll = new EmployeeSetup_BLL();
        Office_BLL objOfficeBLL = new Office_BLL();
        EMPOYEE_BLL employeeBllObj = new EMPOYEE_BLL();



        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    lformate.Visible = false;
                    GetLatterFormateType();

                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }

            //if (!IsPostBack)
            //{
            //    GerRegionList();
            //}

        }

        private void GetLatterFormateType()
        {

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = letterTypeBllObj.GetAllLetterTypes(OCODE).ToList();
                if (row.Count > 0)
                {
                    drpLetterType.DataSource = row.ToList();
                    drpLetterType.DataTextField = "LatterType";
                    drpLetterType.DataValueField = "LatterTypeId";
                    drpLetterType.DataBind();
                    drpLetterType.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void txtEid_AT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string employeeID = Convert.ToString(txtEid_AT.Text);
                Emp_IMG_AT.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;

                var result = objEmp_BLL.GetEmployeeDetailsForAttendece(employeeID, OCODE).ToList();
                if (result.Count > 0)
                {
                    var objNewEmp = result.First();
                    txtEid_AT.Text = Convert.ToString(objNewEmp.EID);
                    txtEmpName_AT.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                    lblHiddenId.Text = Convert.ToString(objNewEmp.EMP_ID);
                    txtDepartment_AT.Text = objNewEmp.DPT_NAME;
                    txtDesignation_AT.Text = objNewEmp.DEG_NAME;
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

        protected void drpLetterTitle_SelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int leterType = Convert.ToInt32(drpLetterType.SelectedValue);
                List<HRM_LETTER_FORMAT> letterFormates = latterFormateBll.getLetterTitleByTypeId(leterType);
                if (letterFormates.Count > 0)
                {
                    drpdwnLetterTitle.DataSource = letterFormates.ToList();
                    drpdwnLetterTitle.DataTextField = "LTR_Title";
                    drpdwnLetterTitle.DataValueField = "LTR_ID";
                    drpdwnLetterTitle.DataBind();
                    drpdwnLetterTitle.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                int lType = Convert.ToInt32(drpLetterType.SelectedValue);
                string aTitle = drpdwnLetterTitle.SelectedItem.ToString();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_LETTER_FORMAT> Lformate = latterFormateBll.GetLatterFormatemate(lType, aTitle, OCODE);

                if (Lformate.Count > 0)
                {
                    foreach (HRM_LETTER_FORMAT aitem in Lformate)
                    {
                        txtLatterDetails.Text = aitem.LTR_Details;
                    }
                }
                lformate.Visible = true;

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnProcess_click(object sender, EventArgs e)
        {
            HRM_StoreLetter leterStoreobj = new HRM_StoreLetter();

            try
            {
                leterStoreobj.EID = txtEid_AT.Text;
                leterStoreobj.Description = txtLatterDetails.Text;
                leterStoreobj.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                leterStoreobj.EDIT_DATE = DateTime.Now;
                leterStoreobj.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int result = latterFormateBll.SaveLetterFormate(leterStoreobj);

                if (result == 1)
                {

                    var _context = new ERPSSLHBEntities();

                    var lastId = _context.HRM_StoreLetter.OrderByDescending(u => u.StoreLetterId).FirstOrDefault();
                    int lid = lastId.StoreLetterId;

                    List<HRM_StoreLetter> vaues = latterFormateBll.getData(lid);
                    ReportViewerEmp.LocalReport.DataSources.Clear();
                    ReportDataSource reportDataset = new ReportDataSource("LatterIssue", vaues);
                    ReportViewerEmp.LocalReport.DataSources.Add(reportDataset);
                    ReportViewerEmp.LocalReport.ReportPath = Server.MapPath("reports/LetterFormate.rdlc");
                    ReportViewerEmp.LocalReport.Refresh();
                    //lblmodalMessage.Text = "";
                    //ModalPopupExtender.Show();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


        //For Letter Formate Report

        //protected void drpdwnResionForDepartmentSelecttedIndexChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
        //        BridOfficeByResion(ResionId);

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
        //private void BridOfficeByResion(int ResionId)
        //{
        //    var row = objOfficeBLL.GetOfficeByResionId(ResionId).ToList();
        //    if (row.Count > 0)
        //    {
        //        drpOffice.DataSource = row.ToList();
        //        drpOffice.DataTextField = "OfficeName";
        //        drpOffice.DataValueField = "OfficeID";
        //        drpOffice.DataBind();
        //        drpOffice.Items.Insert(0, new ListItem("--Select--"));
        //    }
        //    else
        //    {
        //        drpOffice.DataSource = null;
        //        drpOffice.DataTextField = "OfficeName";
        //        drpOffice.DataValueField = "OfficeID";
        //        drpOffice.DataBind();
        //        drpOffice.Items.Insert(0, new ListItem("--Select--"));
        //    }
        //}

        //private void GerRegionList()
        //{
        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        var row = objOfficeBLL.GetAllResion(OCODE).ToList();
        //        if (row.Count > 0)
        //        {
        //            ddlRegions.DataSource = row.ToList();
        //            ddlRegions.DataTextField = "RegionName";
        //            ddlRegions.DataValueField = "RegionID";
        //            ddlRegions.DataBind();
        //            ddlRegions.Items.Insert(0, new ListItem("--Select--"));
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }
        //}
        //protected void onSelectedIndedexChangeOffice(object sender, EventArgs e)
        //{
        //    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //    int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
        //    int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
        //    var row = objOfficeBLL.GetOfficeByResionId(ResionId, OfficeId, OCODE).ToList();
        //    if (row.Count > 0)
        //    {
        //        depDepartment.DataSource = row.ToList();
        //        depDepartment.DataTextField = "DPT_NAME";
        //        depDepartment.DataValueField = "DPT_ID";
        //        depDepartment.DataBind();
        //        depDepartment.Items.Insert(0, new ListItem("--Select--"));
        //    }
        //    else
        //    {
        //        depDepartment.DataSource = null;
        //        depDepartment.DataTextField = "DPT_NAME";
        //        depDepartment.DataValueField = "DPT_ID";
        //        depDepartment.DataBind();
        //        depDepartment.Items.Insert(0, new ListItem("--Select--"));
        //    }
        //}

        protected void drpdwnDepartmentSelectedIndexChange(object sender, EventArgs e)
        {
            //List<REmployee> employees = new List<REmployee>();
            //string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            //int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
            //int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
            //int departmentID = Convert.ToInt32(depDepartment.SelectedValue);
            //employees = objOfficeBLL.GetEmployeeListForDepartment(ResionId, OfficeId, departmentID, OCODE).ToList();
            //if (employees.Count > 0)
            //{
            //    Session["rptDs"] = "hrm_employeeforDepartment";
            //    Session["rptDt"] = employees;
            //    Session["rptFile"] = "/HRM/reports/HRM_EmployeeForDepartment.rdlc";
            //    Session["rptTitle"] = "Department Wise";
            //    Response.Redirect("Report_Viewer.aspx");

            //}
        }
        public void Clear()
        {
            txtDesignation1_AT.Text = "";
            txtDepartment1_AT.Text = "";
            txtEmpName1_AT.Text = "";
            txtEid1_AT.Text = "";

        }

        protected void txtEid1_AT_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string employeeID = Convert.ToString(txtEid1_AT.Text);
                img2.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;

                var result = objEmp_BLL.GetEmployeeDetailsForAttendece(employeeID, OCODE).ToList();
                if (result.Count > 0)
                {
                    var objNewEmp = result.First();
                    txtEid1_AT.Text = Convert.ToString(objNewEmp.EID);
                    txtEmpName1_AT.Text = Convert.ToString(objNewEmp.EMP_FIRSTNAME + " " + objNewEmp.EMP_LASTNAME);
                    HiddenId.Text = Convert.ToString(objNewEmp.EMP_ID);
                    txtDepartment1_AT.Text = objNewEmp.DPT_NAME;
                    txtDesignation1_AT.Text = objNewEmp.DEG_NAME;
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

        protected void btnProcess1_Click(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<REmployee> employees = new List<REmployee>();


                if (rdAppointment.Checked)
                {
                    string empId = txtEid1_AT.Text;
                    employees = objOfficeBLL.GetJobAppointment(empId, OCODE).ToList();
                    if (employees.Count > 0)
                    {
                        Session["rptDs"] = "HRM_JobAppointmentDS";
                        Session["rptDt"] = employees;
                        Session["rptFile"] = "/HRM/reports/JobAppointmentRPT.rdlc";
                        Session["rptTitle"] = "Job Appointment";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                }

                else if (rdJobcertificate.Checked)
                {
                    string empId = txtEid1_AT.Text;
                    employees = objOfficeBLL.GetJobCertification(empId, OCODE).ToList();
                    if (employees.Count > 0)
                    {
                        Session["rptDs"] = "HRM_JobCertificationDS";
                        Session["rptDt"] = employees;
                        Session["rptFile"] = "/HRM/reports/JobCertificationRPT.rdlc";
                        Session["rptTitle"] = "Job Certification";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                }

                else if (rdJobTransfer.Checked)
                {
                    string empId = txtEid1_AT.Text;
                    employees = objOfficeBLL.GetJobEMP_Transfer(empId, OCODE).ToList();
                    if (employees.Count > 0)
                    {
                        Session["rptDs"] = "HRM_JobEmployeeTransferDS";
                        Session["rptDt"] = employees;
                        Session["rptFile"] = "/HRM/reports/JobEMP_TransferRPT.rdlc";
                        Session["rptTitle"] = "Employee Transfer";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                }

                else if (rdIncrement.Checked)
                {
                    string empId = txtEid1_AT.Text;
                    employees = objOfficeBLL.GetEmployeeIncrement(empId, OCODE).ToList();
                    if (employees.Count > 0)
                    {
                        Session["rptDs"] = "HRM_JobEmployeeIncDS";
                        Session["rptDt"] = employees;
                        Session["rptFile"] = "/HRM/reports/HRM_JobEmployeeIncRPT.rdlc";
                        Session["rptTitle"] = "Employee Increment";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                }

                else if (rdTermination.Checked)
                {
                    string empId = txtEid1_AT.Text;
                    employees = objOfficeBLL.GetJobTermination(empId, OCODE).ToList();
                    if (employees.Count > 0)
                    {
                        Session["rptDs"] = "HRM_JobTerminationDS";
                        Session["rptDt"] = employees;
                        Session["rptFile"] = "/HRM/reports/JobTerminationRPT.rdlc";
                        Session["rptTitle"] = "Job Termination";
                        Response.Redirect("Report_Viewer.aspx");
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