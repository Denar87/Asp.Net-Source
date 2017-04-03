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
    public partial class JobAllocationStatus : System.Web.UI.Page
    {
        JobAlloctionDAL jobAllocationDal = new JobAlloctionDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    string jobAllocationCode = Convert.ToString(Session["JobAllocationCode"]);
                    if (jobAllocationCode != null)
                    {
                        lblJobAllocationCode.Text = jobAllocationCode.ToString();
                        GetJobAllocationInfoByCode(jobAllocationCode);
                        GetJobAllocationEemployeeListByCode(jobAllocationCode);
                    }
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }

        }

        private void GetJobAllocationEemployeeListByCode(string jobAllocationCode)
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                List<RJobAllocation> jobAlles = new List<RJobAllocation>();
                jobAlles = jobAllocationDal.GetJobAllocationAssignList(Ocode, jobAllocationCode);
                if (jobAlles.Count > 0)
                {
                    gridviewEmployeeList.DataSource = jobAlles;
                    gridviewEmployeeList.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }


        }

        protected void btnStatusChange_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_JobAllocation joba = new HRM_JobAllocation();
                if (drpdwnStatus.SelectedItem.ToString() == "Success")
                {
                    joba.SuccessStatus = true;
                }
                else if (drpdwnStatus.SelectedItem.ToString() == "Pending")
                {
                    joba.PendingStatus = true;
                }
                else if (drpdwnStatus.SelectedItem.ToString() == "Cancel")
                {
                    joba.CancelStatus = true;
                }
                joba.UpdateRemark = txtbxRemark.Text;
                string jobAllocatinCode = lblJobAllocationCode.Text;
                int result = jobAllocationDal.SaveJobAllocationStatus(joba, jobAllocatinCode);
                if (result == 1)
                {
                    lblMessage.Text = "Status Save Successfully.";
                }


            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


        private void GetJobAllocationInfoByCode(string jobAllocationCode)
        {
            List<RJobAllocationAssign> jobAllocationes = new List<RJobAllocationAssign>();
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            try
            {
                jobAllocationes = jobAllocationDal.GEtJobAllocationInfoByJobAllocationCode(jobAllocationCode, OCODE);
                if (jobAllocationes.Count > 0)
                {
                    foreach (RJobAllocationAssign aitem in jobAllocationes)
                    {
                        lblReason.Text = aitem.Reasion;
                        lblClicentName.Text = aitem.ClientName;
                        lblDate.Text = aitem.JobAllocationDate.ToShortDateString();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void gridviewEmployeeList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }
    }
}