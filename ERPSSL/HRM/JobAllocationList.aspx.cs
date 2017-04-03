using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.HRM.DAL;
using ERPSSL.HRM.DAL.Repository;

namespace ERPSSL.HRM
{
    public partial class JobAllocationList : System.Web.UI.Page
    {
        JobAlloctionDAL jobAllocationDal = new JobAlloctionDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetJobAllocationList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetJobAllocationList()
        {
            List<RJobAllocationAssign> jobAllocationes = new List<RJobAllocationAssign>();
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            try
            {
                jobAllocationes = jobAllocationDal.GetJobAllocationList(OCODE);
                if (jobAllocationes.Count > 0)
                {
                    gridviewJobAllocationList.DataSource = jobAllocationes;
                    gridviewJobAllocationList.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                List<RJobAllocationAssign> jobAllocationes = new List<RJobAllocationAssign>();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                string fromDate = txtbxFrom.Text;
                string toDate = txtbxTo.Text;

                jobAllocationes = jobAllocationDal.GetJobAllocationDateWise(OCODE, fromDate, toDate);
                if (jobAllocationes.Count > 0)
                {
                    gridviewJobAllocationList.DataSource = jobAllocationes;
                    gridviewJobAllocationList.DataBind();
                }
                else
                {
                    gridviewJobAllocationList.DataSource = null;
                    gridviewJobAllocationList.DataBind();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnStatus_Click(object sender, EventArgs e)
        {
            List<HRM_Regions> Regions = new List<HRM_Regions>();
            Button imgbtn = (Button)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string JobAllocation = "";
                Label lblJobAllocation = (Label)gridviewJobAllocationList.Rows[row.RowIndex].FindControl("lblAllocationJobCode");
                if (lblJobAllocation != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    JobAllocation = lblJobAllocation.Text;

                    Session["JobAllocationCode"] = JobAllocation;
                    Response.Redirect("JobAllocationStatus.aspx");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnReport_Click(object sender, EventArgs e)
        {
            List<HRM_Regions> Regions = new List<HRM_Regions>();
            Button imgbtn = (Button)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {

                Label lblJobAllocation = (Label)gridviewJobAllocationList.Rows[row.RowIndex].FindControl("lblAllocationJobCode");
                if (lblJobAllocation != null)
                {
                    string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                    string jobAllocationCode = lblJobAllocation.Text;
                    List<RJobAllocation> jobAlles = new List<RJobAllocation>();
                    jobAlles = jobAllocationDal.GetJobAllocationAssignList(Ocode, jobAllocationCode);
                    if (jobAlles.Count > 0)
                    {
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                List<HRM_Regions> Regions = new List<HRM_Regions>();
                Button imgbtn = (Button)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
                try
                {
                    Label lblJobAllocation = (Label)gridviewJobAllocationList.Rows[row.RowIndex].FindControl("lblAllocationJobCode");
                    if (lblJobAllocation != null)
                    {
                        string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                        string jobAllocationCode = lblJobAllocation.Text;

                        int result = jobAllocationDal.DeleteJobAllocationByCode(jobAllocationCode, Ocode);
                        if (result == 1)
                        {
                            lblMessage.Text = "Data Delete Successfully.";
                            GetJobAllocationList();
                        }

                    }
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void gridviewJobAllocationList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridviewJobAllocationList.PageIndex = e.NewPageIndex;
            GetJobAllocationList();
        }

    }
}