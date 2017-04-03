using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.BLL;


namespace ERPSSL.HRM
{
    public partial class EmployeeIDCard : System.Web.UI.Page
    {
        #region -------------- Object ---------------

        Region_DAL regionDal = new Region_DAL();
        Office_DAL officeDal = new Office_DAL();
        Office_BLL officeBll = new Office_BLL();
        DEPARTMENT_DAL departmentDal = new DEPARTMENT_DAL();
        DEPARTMENT_BLL departmentBll = new DEPARTMENT_BLL();
        SECTION_BLL SectionBll = new SECTION_BLL();
        SECTION_DAL sectionDal = new SECTION_DAL();
        SUB_SECTION_DAL subSectionDal = new SUB_SECTION_DAL();
        SUB_SECTION_BLL subSectionBll = new SUB_SECTION_BLL();
        GRADE_DAL gradeDal = new GRADE_DAL();
        GRADE_BLL gradeBll = new GRADE_BLL();
        DESIGNATION_DAL designationDal = new DESIGNATION_DAL();
        TIME_SCHEDULE_DAL timeScheduleDal = new TIME_SCHEDULE_DAL();
        EMPOYEE_BLL objEmp_BLL = new EMPOYEE_BLL();
        EmployeeSetup_DAL empSetupDal = new EmployeeSetup_DAL();
        EmployeeSetup_BLL employeeSetUpBll = new EmployeeSetup_BLL();
        ERPSSLHBEntities context = new ERPSSLHBEntities();
        REPORTING_BLL objRpt_BLL = new REPORTING_BLL();

        #endregion
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
                Emp_IMG_TRNS.ImageUrl = "EmployeeIMG.ashx?eId=" + employeeID + "&oCode=" + OCODE;
                var result = objEmp_BLL.GetEmployeeDetailsIDCard(employeeID, OCODE).ToList();
                if (result.Count > 0)
                {
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
            string eId = Convert.ToString(txtEid_TRNS.Text);
            Generate_Report_Sal(eId);
            //btnProcess.Text = "Please Wait....";
            //ModalPopupExtender.Show();
        }

        private void Generate_Report_Sal(string eId)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var dataSource = objRpt_BLL.generate_IdCardEMP(eId, OCODE).ToList();
                if (dataSource.Count > 0)
                {
                    ReportViewerEmp.LocalReport.DataSources.Clear();
                    ReportDataSource reportDataset = new ReportDataSource("EmployeeIdCard", dataSource);
                    ReportViewerEmp.LocalReport.DataSources.Add(reportDataset);
                    ReportViewerEmp.LocalReport.ReportPath = Server.MapPath("Reports/EmployeeId.rdlc");

                    parameter_pass();
                    ReportViewerEmp.LocalReport.Refresh();
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void parameter_pass()
        {
            ReportParameter prm_1 = new ReportParameter("RPT_TITLE", Company_Config.COMPANY_NAME.ToString());
            ReportParameter prm_2 = new ReportParameter("RPT_DESCRIPTION", Company_Config.COMPANY_ADDRESS.ToString());
            ReportParameter prm_3 = new ReportParameter("DATE_PRINT", Convert.ToString(DateTime.Now.Date));
            ReportViewerEmp.LocalReport.SetParameters(new ReportParameter[] { prm_1, prm_2, prm_3 });
        }
    }
}