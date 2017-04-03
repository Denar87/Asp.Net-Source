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
    public partial class MaternityLeaveList : System.Web.UI.Page
    {
        MaternityLeaveBLL maternityLeaveBll = new MaternityLeaveBLL();
        LEAVE_BLL leaveBll = new LEAVE_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    getMternityLeaveList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void getMternityLeaveList()
        {

            //string eid = ((SessionUser)Session["SessionUser"]).EID;
            string eid = "779";
            if (eid != null)
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string currentYear = DateTime.Now.Year.ToString();
                List<MaternityLeaveR> leaveinfoes = leaveBll.getMaternityLeaveInfoForApprove(eid, currentYear, OCODE).ToList();
                if (leaveinfoes.Count > 0)
                {
                    gridviewLeaveInfo.DataSource = leaveinfoes;
                    gridviewLeaveInfo.DataBind();
                }
            }
        }
        protected void btnView_Click(object sender, EventArgs e)
        {

            Button imgbtn = (Button)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string MLeaveId = "";
                string Eid = "";
                Label lblMaternityLeaveId = (Label)gridviewLeaveInfo.Rows[row.RowIndex].FindControl("lblMaternityLeaveId");
                Label lblEidID = (Label)gridviewLeaveInfo.Rows[row.RowIndex].FindControl("lblEid");

                if (lblMaternityLeaveId != null && lblEidID != null)
                {
                    MLeaveId = lblMaternityLeaveId.Text;
                    Eid = lblEidID.Text;

                    Session["aLeaveID"] = MLeaveId;
                    Session["aLEID"] = Eid;
                    Response.Redirect("MaternityLeaveApprove.aspx");
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

    }

}