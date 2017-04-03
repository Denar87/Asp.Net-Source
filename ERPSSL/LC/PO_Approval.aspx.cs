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
    public partial class PO_Approval : System.Web.UI.Page
    {
        ERPSSL.LC.BLL.OrderSheetBLL _orderSheetbll = new ERPSSL.LC.BLL.OrderSheetBLL();

        MasterLCBLL aMasterLCBLL = new MasterLCBLL();  

        LC_RequisitionBLL aLC_RequisitionBLL = new LC_RequisitionBLL();

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
                    txtDate.Text = DateTime.Today.ToShortDateString();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        public void Get_PendingPOSummaryByDate()
        {
            string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
            DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime toDate = Convert.ToDateTime(txtToDate.Text);

            var result = aMasterLCBLL.Get_All_PO_EstimatedSummaryList(Ocode).Where(x => x.LC_PO_Date >= fromDate && x.LC_PO_Date <= toDate && x.IsPO_Approved==false).ToList();

            if (result.Count > 0)
            {
                grvPOSummary.DataSource = result;
                grvPOSummary.DataBind();
            }
            else
            {
                grvPOSummary.DataSource = null;
                grvPOSummary.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
            }
        }

        protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerChkBox = ((CheckBox)gridApprovalDetails.HeaderRow.FindControl("headerLevelCheckBox"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in gridApprovalDetails.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in gridApprovalDetails.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        } 
        
        protected void gridBackToBack_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "View")
            {
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                string id = Convert.ToString(e.CommandArgument);
                List<Rep_Estimate> lstRep_Estimate = new List<Rep_Estimate>();
                lstRep_Estimate = aLC_RequisitionBLL.Get_AllPODetails(id, Ocode);

                if (lstRep_Estimate.Count > 0)
                {
                    gridApprovalDetails.DataSource = lstRep_Estimate;
                    gridApprovalDetails.DataBind();
                }
                else
                {
                    gridApprovalDetails.DataSource = null;
                    gridApprovalDetails.DataBind();
                }
                txtPONo.Text = id;     
            }
        }
        
        protected void btnProcess_Click(object sender, EventArgs e)
        {
            List<LC_PurchaseOrder> lstLC_PurchaseOrder = new List<LC_PurchaseOrder>();
            
            foreach (GridViewRow gvRow in gridApprovalDetails.Rows)
            {             
                CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                if (rowChkBox.Checked == true)
                {
                    LC_PurchaseOrder aLC_PurchaseOrder = new LC_PurchaseOrder();

                    TextBox txtReqQty = ((TextBox)gvRow.FindControl("txtApproveQty"));                    
                    Label lblProductId = ((Label)gvRow.FindControl("lblProductId"));

                    aLC_PurchaseOrder.LC_PO_No = txtPONo.Text;
                    aLC_PurchaseOrder.PO_ApprovedDate = Convert.ToDateTime(txtDate.Text);
                    aLC_PurchaseOrder.ProductId = Convert.ToInt32(lblProductId.Text);                  
                   
                    if (txtReqQty.Text == "")
                    {
                        aLC_PurchaseOrder.PO_Approved_Qty = 0;
                    }
                    else
                    {
                        aLC_PurchaseOrder.PO_Approved_Qty = Convert.ToDouble(txtReqQty.Text);
                    }

                    lstLC_PurchaseOrder.Add(aLC_PurchaseOrder);
                }
                   
            }

            var result = aLC_RequisitionBLL.UpdatePOApprovedStatus(lstLC_PurchaseOrder);
            if (result == 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Approved Successfully')", true);
                txtDate.Text = "";              
                gridApprovalDetails.DataSource = null;
                gridApprovalDetails.DataBind();
            }       
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Get_PendingPOSummaryByDate();
        }

    }
}