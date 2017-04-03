using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.BLL;
using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL;
using ERPSSL.LC.DAL.Repository;

namespace ERPSSL.LC
{
    public partial class LC_Issue : System.Web.UI.Page
    {
        ERPSSL.LC.BLL.OrderSheetBLL _orderSheetbll = new ERPSSL.LC.BLL.OrderSheetBLL();

        LC_RequisitionBLL aLC_RequisitionBLL = new LC_RequisitionBLL();
        MasterLCBLL aMasterLCBLL = new MasterLCBLL();
        LC_ReportBLL aLC_ReportBLL = new LC_ReportBLL();

        GroupBLL groupBll = new GroupBLL();
        EstimatingBLL estimating = new EstimatingBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    txtFromDate.Text = DateTime.Today.ToShortDateString();
                    txtToDate.Text = DateTime.Today.ToShortDateString();
                    // txtDate.Text = DateTime.Today.ToShortDateString();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        public void Get_POList_ByDate()
        {
            string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
            DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime toDate = Convert.ToDateTime(txtToDate.Text);

            var result = aMasterLCBLL.Get_All_PO_EstimatedSummaryList(Ocode).Where(x => x.LC_PO_Date >= fromDate && x.LC_PO_Date <= toDate && x.PO_Type == "LC" && x.IsPO_Approved == true).ToList();

            if (result.Count > 0)
            {
                grvLCIssue.DataSource = result;
                grvLCIssue.DataBind();
            }
            else
            {
                grvLCIssue.DataSource = null;
                grvLCIssue.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
            }
        }

        protected void gridBackToBack_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                // Retrieve the row index stored in the 
                // CommandArgument property.
                string id = Convert.ToString(e.CommandArgument);
                var row = aMasterLCBLL.Get_EstimateDetailsList(id);
                if (row.Count > 0)
                {
                    var result = row.First();
                    txtPO.Text = result.LC_PO_No;
                    txtBuyerName.Text = result.Buyer_Name;
                    txtstyle.Text = result.Lc_Style;
                    txtFinishGoods_Name.Text = result.FinishGoods_Name;
                }
                else
                {

                }
                // txtEstimateNo.Text = id;
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Get_POList_ByDate();
        }

        protected void btnLCIssue_Click(object sender, EventArgs e)
        {

          
            var LCIssue = aLC_ReportBLL.GetRPTLCIssue().ToList();
        
            Session["rptDs"] = "HRM_EmployeeSalaryRangeDS";
            Session["rptDt"] = LCIssue;
            Session["rptFile"] = "/LC/Reports/LC_Issue.rdlc";
            Session["FromBank"] = txtFromBank.Text;
            Session["ToBank"] = txtToBank.Text;
            Session["LCNumber"] = txtLCNumber.Text;
            Session["rptTitle"] = "Salary Range Report";
            Response.Redirect("Report_Viewer.aspx");
         
        }

    }
}