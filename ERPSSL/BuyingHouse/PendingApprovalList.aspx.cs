using ERPSSL.LC.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.BuyingHouse
{
    public partial class PendingApprovalList : System.Web.UI.Page
    {
       // ApprovalBLL _ApprovalBLL = new ApprovalBLL();
        MasterLCBLL masterBLL = new MasterLCBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {

                if (!IsPostBack)
                {
                    GetPandingList();
                }

            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        public void GetPandingList()
        {
            try
            {
                string UserEmpId = ((SessionUser)Session["SessionUser"]).EID;
                var PandingList = masterBLL.GetApprovallistByEid(UserEmpId);
                if (PandingList.Count() != 0)
                {
                    gridviewPanding.DataSource = PandingList;
                    gridviewPanding.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void imgbtnEdit_Click(object sender, ImageClickEventArgs e)
        {
            lblMessage.Text = "";

            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            Label lblTID = (Label)gridviewPanding.Rows[row.RowIndex].FindControl("lblTID");
            Label lblTableUniqeID = (Label)gridviewPanding.Rows[row.RowIndex].FindControl("lblTableUniqeID");
            Label lblUserEID = (Label)gridviewPanding.Rows[row.RowIndex].FindControl("lblUserEID");
            Label lblOrder_No = (Label)gridviewPanding.Rows[row.RowIndex].FindControl("lblOrder_No");
            Label lblRedirectPageName = (Label)gridviewPanding.Rows[row.RowIndex].FindControl("lblRedirectPageName");

            Session["TID"] = lblTID.Text;
            Session["TableUniqeID"] = lblTableUniqeID.Text;
            Session["alblOrder_No"] = lblOrder_No.Text;
            Session["UserEID"] = lblUserEID.Text;
            string url = "..\\BuyingHouse\\" + lblRedirectPageName.Text;


            Response.Redirect(url);

        }
        protected void gridviewPanding_OnPageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                gridviewPanding.PageIndex = e.NewPageIndex;
                GetPandingList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}