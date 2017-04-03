using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using AjaxControlToolkit;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM
{
    public partial class JobAllocation : System.Web.UI.Page
    {
        JobAlloctionDAL jobAllocationDal = new JobAlloctionDAL();
        Office_BLL objOfficeBLL = new Office_BLL();
        EMPLOYEE_DAL employeeDal = new EMPLOYEE_DAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GerRegionList();
                    GetClientList();
                    GetJobAllocationCode();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetJobAllocationCode()
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            int count = jobAllocationDal.GetLastRowNumber(OCODE);
            int total = count + 1;
            lblJobAllocationCode.Text = " JoBA" + total;

        }

        private void GetClientList()
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            //var row = objOfficeBLL.GetAllClient(OCODE).ToList();
            //    if (row.Count > 0)
            //    {
            //        drpClient.DataSource = row.ToList();
            //        drpClient.DataTextField = "Client_Name";
            //        drpClient.DataValueField = "ID";
            //        drpClient.DataBind();
            //        drpClient.Items.Insert(0, new ListItem("--Select--", "0"));
            //  }

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
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void drpClientOnselectedIndexChangeD(object sender, EventArgs e)
        {
            //try
            //{
            //    int ClientId = Convert.ToInt32(drpClient.SelectedValue);
            //    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            //    var row = objOfficeBLL.GetClientLocationById(ClientId, OCODE).ToList();
            //        foreach (MST_ClientDetails aitem in row)
            //        {
            //            txtbxLoacation.Text = aitem.Area;
            //        }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        protected void drpdwnDepartmentSelectedIndexChange(object sender, EventArgs e)
        {
            try
            {
                int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                int Department = Convert.ToInt32(depDepartment.SelectedValue);
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objOfficeBLL.GetAllClientListForJobAllocation(ResionId, OfficeId, Department, OCODE).ToList();
                if (row.Count > 0)
                {
                    grdemployees.DataSource = row.ToList();
                    grdemployees.DataBind();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void grdemployees_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdemployees.PageIndex = e.NewPageIndex;

            try
            {
                int ResionId = Convert.ToInt32(ddlRegions.SelectedValue);
                int OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                int Department = Convert.ToInt32(depDepartment.SelectedValue);
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objOfficeBLL.GetAllClientListForJobAllocation(ResionId, OfficeId, Department, OCODE).ToList();
                if (row.Count > 0)
                {
                    grdemployees.DataSource = row.ToList();
                    grdemployees.DataBind();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnDelete_Delete(object sender, EventArgs e)
        {
            List<HRM_PersonalInformations> personales = new List<HRM_PersonalInformations>();
            try
            {
                for (int i = 0; i < grdviewsseletedEmployee.Rows.Count; i++)
                {
                    HRM_PersonalInformations personalInfo = new HRM_PersonalInformations();

                    Label lblRegion = (Label)grdviewsseletedEmployee.Rows[i].FindControl("lblResion");
                    Label lblOffice = (Label)grdviewsseletedEmployee.Rows[i].FindControl("lblOfficeId");
                    Label lblDepartment = (Label)grdviewsseletedEmployee.Rows[i].FindControl("lblDepartmentId");
                    personalInfo.RegionsId = Convert.ToInt32(lblRegion.Text);
                    personalInfo.OfficeId = Convert.ToInt32(lblOffice.Text);
                    personalInfo.DepartmentId = Convert.ToInt32(lblDepartment.Text);
                    personalInfo.EID = grdviewsseletedEmployee.Rows[i].Cells[4].Text;
                    personalInfo.FirstName = grdviewsseletedEmployee.Rows[i].Cells[5].Text;
                    personalInfo.LastName = grdviewsseletedEmployee.Rows[i].Cells[6].Text;
                    personalInfo.ContactNumber = grdviewsseletedEmployee.Rows[i].Cells[7].Text;
                    personales.Add(personalInfo);


                }

                Button btn = (Button)sender;
                GridViewRow gvr = (GridViewRow)btn.NamingContainer;
                int rowIndex = gvr.RowIndex;
                personales.RemoveAt(rowIndex);
                grdviewsseletedEmployee.DataSource = personales;
                grdviewsseletedEmployee.DataBind();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        List<HRM_PersonalInformations> personales = new List<HRM_PersonalInformations>();
        protected void btnAdd_Click(object sender, System.EventArgs e)
        {
            try
            {
                for (int i = 0; i < grdviewsseletedEmployee.Rows.Count; i++)
                {
                    HRM_PersonalInformations personalInfo = new HRM_PersonalInformations();
                    Label lblRegion = (Label)grdviewsseletedEmployee.Rows[i].FindControl("lblResion");
                    Label lblOffice = (Label)grdviewsseletedEmployee.Rows[i].FindControl("lblOfficeId");
                    Label lblDepartment = (Label)grdviewsseletedEmployee.Rows[i].FindControl("lblDepartmentId");
                    personalInfo.RegionsId = Convert.ToInt32(lblRegion.Text);
                    personalInfo.OfficeId = Convert.ToInt32(lblOffice.Text);
                    personalInfo.DepartmentId = Convert.ToInt32(lblDepartment.Text);

                    personalInfo.EID = grdviewsseletedEmployee.Rows[i].Cells[4].Text;
                    personalInfo.FirstName = grdviewsseletedEmployee.Rows[i].Cells[5].Text;
                    personalInfo.LastName = grdviewsseletedEmployee.Rows[i].Cells[6].Text;
                    personalInfo.ContactNumber = grdviewsseletedEmployee.Rows[i].Cells[7].Text;
                    personales.Add(personalInfo);


                }

                Button btn = (Button)sender;
                GridViewRow gvr = (GridViewRow)btn.NamingContainer;
                int rowIndex = gvr.RowIndex;
                for (int i = 0; i < grdemployees.Rows.Count; i++)
                {
                    if (i == rowIndex)
                    {
                        HRM_PersonalInformations personalInfo1 = new HRM_PersonalInformations();
                        personalInfo1.DepartmentId = Convert.ToInt32(depDepartment.SelectedValue);
                        personalInfo1.OfficeId = Convert.ToInt32(drpOffice.SelectedValue);
                        personalInfo1.RegionsId = Convert.ToInt32(ddlRegions.SelectedValue);
                        personalInfo1.EID = grdemployees.Rows[i].Cells[1].Text;
                        personalInfo1.FirstName = grdemployees.Rows[i].Cells[2].Text;
                        personalInfo1.LastName = grdemployees.Rows[i].Cells[3].Text;
                        personalInfo1.ContactNumber = grdemployees.Rows[i].Cells[4].Text;
                        if (!IsExist(personalInfo1, personales))
                        {
                            personales.Add(personalInfo1);
                        }
                        else
                        {
                            string message = "This Employee already Existing.";
                            System.Text.StringBuilder sb = new System.Text.StringBuilder();
                            sb.Append("<script type = 'text/javascript'>");
                            sb.Append("window.onload=function(){");

                            sb.Append("alert('");
                            sb.Append(message);
                            sb.Append("')};");
                            sb.Append("</script>");
                            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());

                        }

                    }

                }

                grdviewsseletedEmployee.DataSource = personales;
                grdviewsseletedEmployee.DataBind();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private bool IsExist(HRM_PersonalInformations personalInfo1, List<HRM_PersonalInformations> personales)
        {
            bool status = false;
            foreach (HRM_PersonalInformations aitem in personales)
            {
                if (aitem.EID == personalInfo1.EID)
                {
                    status = true;
                }
            }
            return status;
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            List<HRM_JobAllocation> jobAllocationes = new List<HRM_JobAllocation>();
            try
            {

                TimeSpan jobAllocationTime = TimeSpan.Parse(string.Format("{0}:{1}:{2}", txtbxTime.Hour, txtbxTime.Minute, txtbxTime.Second));

                for (int i = 0; i < grdviewsseletedEmployee.Rows.Count; i++)
                {
                    HRM_JobAllocation joba = new HRM_JobAllocation();

                    Label lblRegion = (Label)grdviewsseletedEmployee.Rows[i].FindControl("lblResion");
                    Label lblOffice = (Label)grdviewsseletedEmployee.Rows[i].FindControl("lblOfficeId");
                    Label lblDepartment = (Label)grdviewsseletedEmployee.Rows[i].FindControl("lblDepartmentId");

                    joba.RegionID = Convert.ToInt32(lblRegion.Text);
                    joba.OfficeID = Convert.ToInt32(lblOffice.Text);
                    joba.DepartmentID = Convert.ToInt32(lblDepartment.Text);

                    joba.EID = grdviewsseletedEmployee.Rows[i].Cells[4].Text;
                    joba.JobAllocationCode = lblJobAllocationCode.Text;
                    joba.ClientID = Convert.ToInt32(drpClient.SelectedValue);
                    joba.Region = txtbxRegion.Text;
                    joba.Remark = txtbxRemark.Text;
                    joba.RequestFrom = txtbxRequestFrom.Text;
                    joba.JobAllocationTime = jobAllocationTime;
                    joba.JobAllocatonDate = Convert.ToDateTime(txtboxDate.Text);

                    joba.OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                    joba.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                    joba.EDIT_DATE = DateTime.Now;

                    //if (drpStatus.SelectedItem.ToString() == "Yes")
                    //{
                    //    joba.Status = true;
                    //}
                    //else
                    //{
                    //    joba.Status = false;
                    //}

                    jobAllocationes.Add(joba);


                }
                int result = jobAllocationDal.SaveJobAllocation(jobAllocationes);
                if (result == 1)
                {
                    // lblMessage.Text = "Data Save Successfully.";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                    string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                    string jobAllocationCode = lblJobAllocationCode.Text;
                    List<RJobAllocation> jobAlles = new List<RJobAllocation>();
                    jobAlles = jobAllocationDal.GetJobAllocationAssignList(Ocode, jobAllocationCode);
                    if (jobAlles.Count > 0)
                    {
                        GetJobAllocationCode();
                        Session["rptDs"] = "ds_jobAllocaion";
                        Session["rptDt"] = jobAlles;
                        Session["rptFile"] = "/HRM/reports/HRM_JobAllocation.rdlc";
                        Session["rptTitle"] = "Job Allocation";
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