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
    public partial class POByRequisition : System.Web.UI.Page
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

        public void GetPO_EstimatedSummaryByDate()
        {
            string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
            DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime toDate = Convert.ToDateTime(txtToDate.Text);

            var result = aLC_RequisitionBLL.Get_All_LC_RequisitionList(Ocode).Where(x => x.LC_ReqDate >= fromDate && x.LC_ReqDate <= toDate && x.IsReqApproved == true).ToList();

            if (result.Count > 0)
            {
                grvRequisionSummary.DataSource = result;
                grvRequisionSummary.DataBind();
            }
            else
            {
                grvRequisionSummary.DataSource = null;
                grvRequisionSummary.DataBind();
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
                // Retrieve the row index stored in the 
                // CommandArgument property.

                string id = Convert.ToString(e.CommandArgument);

                List<Rep_Estimate> lstRep_Estimate = new List<Rep_Estimate>();

                lstRep_Estimate = aLC_RequisitionBLL.Get_AllRequisitionDetails(id);

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
                txtReqNo.Text = id;
            }
        }

        public void CreatePONo()
        {
            string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
            DateTime Date = DateTime.Today;
            txtPO_NO.Text = aLC_RequisitionBLL.GeneratePO_No(Ocode, Date);
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            CreatePONo();
            List<LC_PurchaseOrder> lstLC_PurchaseOrder = new List<LC_PurchaseOrder>();
            foreach (GridViewRow gvRow in gridApprovalDetails.Rows)
            {
                CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                if (rowChkBox.Checked == true)
                {
                    LC_PurchaseOrder aLC_PurchaseOrder = new LC_PurchaseOrder();

                    TextBox txtPOQty = ((TextBox)gvRow.FindControl("txtPOQty"));
                    Label lblEstimateId = ((Label)gvRow.FindControl("lblEstimateId"));
                    Label lblLC_ReqNo = ((Label)gvRow.FindControl("lblLC_ReqNo"));
                    Label lblUnitId = ((Label)gvRow.FindControl("lblUnitId"));
                    Label lblBuyerID = ((Label)gvRow.FindControl("lblBuyerID"));
                    Label lblProductId = ((Label)gvRow.FindControl("lblProductId"));
                    Label lblLc_Style = ((Label)gvRow.FindControl("lblLc_Style"));
                    Label lblLc_Order = ((Label)gvRow.FindControl("lblLc_Order"));
                    Label lblGroupId = ((Label)gvRow.FindControl("lblGroupId"));
                    Label lblSupplierCode = ((Label)gvRow.FindControl("lblSupplierCode"));

                    aLC_PurchaseOrder.LC_PO_No = txtPO_NO.Text;
                    aLC_PurchaseOrder.LC_ReqNo = txtReqNo.Text;

                    if (txtPOQty.Text == "")
                    {
                        aLC_PurchaseOrder.LC_PO_Qty = 0;
                    }
                    else
                    {
                        aLC_PurchaseOrder.LC_PO_Qty = Convert.ToDouble(txtPOQty.Text);
                    }

                    aLC_PurchaseOrder.UnitId = Convert.ToInt32(lblUnitId.Text);
                    aLC_PurchaseOrder.Cost_Estimate_ID = lblEstimateId.Text;
                    aLC_PurchaseOrder.Buyer_ID = Convert.ToInt32(lblBuyerID.Text);
                    aLC_PurchaseOrder.ProductId = Convert.ToInt32(lblProductId.Text);
                    aLC_PurchaseOrder.LC_Style = lblLc_Style.Text;
                    aLC_PurchaseOrder.SupplierCode = lblSupplierCode.Text;
                    aLC_PurchaseOrder.GroupId = Convert.ToInt32(lblGroupId.Text);
                    aLC_PurchaseOrder.LC_PO_Date = Convert.ToDateTime(txtDate.Text);
                    aLC_PurchaseOrder.LC_Order = lblLc_Order.Text;
                    aLC_PurchaseOrder.PO_Type = ddlPOType.SelectedItem.Text;

                    aLC_PurchaseOrder.OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                    aLC_PurchaseOrder.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                    aLC_PurchaseOrder.EditDate = DateTime.Today;
                    aLC_PurchaseOrder.IsPO_Approved = false;
                    lstLC_PurchaseOrder.Add(aLC_PurchaseOrder);
                }
            }
            var result = aLC_RequisitionBLL.SavePO(lstLC_PurchaseOrder);
            if (result == 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                txtDate.Text = "";
                txtReqNo.Text = "";
                txtPO_NO.Text = "";
                gridApprovalDetails.DataSource = null;
                gridApprovalDetails.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetPO_EstimatedSummaryByDate();
        }

    }
}