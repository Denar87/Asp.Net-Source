using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM
{
    public partial class JobAllocationRPT : System.Web.UI.Page
    {
        EmployeeSetup_BLL objEmp_BLL = new EmployeeSetup_BLL();
        DEPARTMENT_BLL DepartmentBll = new DEPARTMENT_BLL();
        EmployeeSetup_BLL employeeBll = new EmployeeSetup_BLL();
        Office_BLL objOfficeBLL = new Office_BLL();
        JobAllocationRPT_BLL objJobAllocationRPT_Bll = new JobAllocationRPT_BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GerRegionList();
                    //GetClientList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        private void GerRegionList()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objOfficeBLL.GetAllResion(OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlRegions.DataSource = row.ToList();
                    ddlRegions.DataTextField = "RegionName";
                    ddlRegions.DataValueField = "RegionID";
                    ddlRegions.DataBind();
                    ddlRegions.Items.Insert(0, new ListItem("--Select--"));
                }

            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void drpdwnResionForDepartmentSelecttedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                BridOfficeByResion(ResionId);

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
            rdRegionWiseEmployee.Checked = true;
        }

        private void BridOfficeByResion(int ResionId)
        {
            try
            {
                var row = objOfficeBLL.GetOfficeByResionId(ResionId).ToList();
                if (row.Count > 0)
                {
                    drpOffice.DataSource = row.ToList();
                    drpOffice.DataTextField = "OfficeName";
                    drpOffice.DataValueField = "OfficeID";
                    drpOffice.DataBind();
                    drpOffice.Items.Insert(0, new ListItem("--Select--"));
                }
                else
                {
                    drpOffice.DataSource = null;
                    drpOffice.DataTextField = "OfficeName";
                    drpOffice.DataValueField = "OfficeID";
                    drpOffice.DataBind();
                    drpOffice.Items.Insert(0, new ListItem("--Select--"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void onSelectedIndedexChangeOffice(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                var row = objOfficeBLL.GetDeptByOfficeId(ResionId, OfficeId, OCODE).ToList();
                if (row.Count > 0)
                {
                    depDepartment.DataSource = row.ToList();
                    depDepartment.DataTextField = "DPT_NAME";
                    depDepartment.DataValueField = "DPT_ID";
                    depDepartment.DataBind();
                    depDepartment.Items.Insert(0, new ListItem("--Select--"));
                }
                else
                {
                    depDepartment.DataSource = null;
                    depDepartment.DataTextField = "DPT_NAME";
                    depDepartment.DataValueField = "DPT_ID";
                    depDepartment.DataBind();
                    depDepartment.Items.Insert(0, new ListItem("--Select--"));
                }

                rdOfficewiseEmployee.Checked = true;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void depDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            rdDeptWiseEmployee.Checked = true;
        }

        protected void drpClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            rdIndividualClient.Checked = true;
        }

        //private void GetClientList()
        //{
        //    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //    var row = objOfficeBLL.GetAllClient(OCODE).ToList();
        //        if (row.Count > 0)
        //        {
        //            drpClient.DataSource = row.ToList();
        //            drpClient.DataTextField = "Client_Name";
        //            drpClient.DataValueField = "ID";
        //            drpClient.DataBind();
        //            drpClient.Items.Insert(0, new ListItem("--Select--", "0"));
        //        }

        //}

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string fromDate = txtbxFrom.Text;
                string toDate = txtbxTo.Text;

                List<JobAllocationRPTGlobal> employees = new List<JobAllocationRPTGlobal>();

                if (rdAllClient.Checked)
                {
                    employees = objJobAllocationRPT_Bll.GetAllClientForReport(OCODE, fromDate, toDate).ToList();
                    if (employees.Count > 0)
                    {
                        Session["rptDs"] = "HRM_JobAllocationAllCompanyDS";
                        Session["rptDt"] = employees;
                        Session["rptFile"] = "/HRM/reports/JobAllocationAllClientRPT.rdlc";
                        Session["rptTitle"] = "All Client";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                }
                else if (rdIndividualClient.Checked)
                {
                    employees = objJobAllocationRPT_Bll.JobAllocationSingleClientRPT(OCODE, drpClient.SelectedValue, fromDate, toDate).ToList();
                    if (employees.Count > 0)
                    {
                        Session["rptDs"] = "HRM_JobAllocationSingleClientDS";
                        Session["rptDt"] = employees;
                        Session["rptFile"] = "/HRM/reports/JobAllocationSingleClientRPT.rdlc";
                        Session["rptTitle"] = "Single Client";
                        Response.Redirect("Report_Viewer.aspx");
                    }

                }

                else if (rdRegionWiseEmployee.Checked)
                {
                    int RegionId = Convert.ToInt32(ddlRegions.SelectedValue);
                    employees = objJobAllocationRPT_Bll.RegionWiseJobAllocation(OCODE, RegionId, fromDate, toDate).ToList();
                    if (employees.Count > 0)
                    {
                        Session["rptDs"] = "HRM_JobAllocationRegionDS";
                        Session["rptDt"] = employees;
                        Session["rptFile"] = "/HRM/reports/JobAllocationRegionRPT.rdlc";
                        Session["rptTitle"] = "Region Wise";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                }
                else if (rdOfficewiseEmployee.Checked)
                {
                    int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                    int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                    employees = objJobAllocationRPT_Bll.OfficeWiseJobAllocation(OCODE, ResionId, OfficeId, fromDate, toDate).ToList();
                    if (employees.Count > 0)
                    {
                        Session["rptDs"] = "HRM_JobAllocationOfficeDS";
                        Session["rptDt"] = employees;
                        Session["rptFile"] = "/HRM/reports/JobAllocationOfficeRPT.rdlc";
                        Session["rptTitle"] = "Office Wise";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                }
                else if (rdDeptWiseEmployee.Checked)
                {
                    int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                    int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                    int departmentId = Convert.ToInt32(depDepartment.SelectedValue);
                    employees = objJobAllocationRPT_Bll.DepartmentWiseJobAllocation(OCODE, ResionId, OfficeId, departmentId, fromDate, toDate).ToList();
                    if (employees.Count > 0)
                    {
                        Session["rptDs"] = "HRM_JobAllocationDepartmentDS";
                        Session["rptDt"] = employees;
                        Session["rptFile"] = "/HRM/reports/JobAllocationDepartment.rdlc";
                        Session["rptTitle"] = "Department Wise";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        //protected void txtEIdNo_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        List<JobAllocationRPTGlobal> employees = new List<JobAllocationRPTGlobal>();
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        string fromDate = txtbxFrom.Text;
        //        string toDate = txtbxTo.Text;
        //        employees = objJobAllocationRPT_Bll.GetJobAllocationDateWise(OCODE, fromDate, toDate);
        //        if (employees.Count > 0)
        //        {
        //            Session["rptDs"] = "JobAllocationListByDatesDS";
        //            Session["rptDt"] = employees;
        //            Session["rptFile"] = "/HRM/reports/JobAlloationListByDateRpt.rdlc";
        //            Session["rptTitle"] = "Date Wise";
        //            Response.Redirect("Report_Viewer.aspx");
        //        }

        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }



        //}


    }
}