using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.HRM
{
    public partial class LeaveApplyListForReportingBoss1 : System.Web.UI.Page
    {
        LEAVE_BLL leaveBllobj = new LEAVE_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getLeaveInfoForApprove();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void getLeaveInfoForApprove()
        {
            string eid = ((SessionUser)Session["SessionUser"]).EID;
            if (eid != null)
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //string eid = ((SessionUser)Session["SessionUser"]).EID;
                string currentYear = DateTime.Now.Year.ToString();
                List<LeaveInfo> leaveinfoes = leaveBllobj.getLeaveInfoForReportingBoss1(eid, currentYear, OCODE).ToList();
                if (leaveinfoes.Count > 0)
                {
                    gridviewLeaveInfo.DataSource = leaveinfoes;
                    gridviewLeaveInfo.DataBind();
                }
            }
        }

        protected void btnaprove_Click(object sender, EventArgs e)
        {
            Button imgbtn = (Button)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string leaveCode = "";
                string Eid = "";
                Label lblLeaveCode = (Label)gridviewLeaveInfo.Rows[row.RowIndex].FindControl("lblLeaveCode");
                Label lblEidID = (Label)gridviewLeaveInfo.Rows[row.RowIndex].FindControl("lblEid");

                if (lblLeaveCode != null && lblEidID != null)
                {
                    leaveCode = lblLeaveCode.Text;
                    Eid = lblEidID.Text;
                    Session["aLeaveID"] = leaveCode;
                    Session["aLEID"] = Eid;
                    Response.Redirect("LeaveApproveForReportingBoss1.aspx");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
    }
}