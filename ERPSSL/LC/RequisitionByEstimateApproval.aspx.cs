﻿using System;
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
    public partial class RequisitionByEstimateApproval : System.Web.UI.Page
    {
        ERPSSL.LC.BLL.OrderSheetBLL _orderSheetbll = new ERPSSL.LC.BLL.OrderSheetBLL();

        LC_RequisitionBLL aLC_RequisitionBLL = new LC_RequisitionBLL();
        List<Rep_Estimate> lstRep_Estimate = new List<Rep_Estimate>();
        LC_ReportBLL _lcReportBLL = new LC_ReportBLL();

        GroupBLL groupBll = new GroupBLL();
        EstimatingBLL estimating = new EstimatingBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    //GetEstimatedSummaryByDate();
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

        public void GetApproved_EstimatedSummaryByDate()
        {
            string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
            DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime toDate = Convert.ToDateTime(txtToDate.Text);

            var result = aLC_RequisitionBLL.Get_All_LC_RequisitionList(Ocode).Where(x => x.LC_ReqDate >= fromDate && x.LC_ReqDate <= toDate && x.IsReqApproved==false).ToList();

            if (result.Count > 0)
            {
                grvEstimatedSummary.DataSource = result;
                grvEstimatedSummary.DataBind();
            }
            else
            {
                grvEstimatedSummary.DataSource = null;
                grvEstimatedSummary.DataBind();
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
                txtRequisition.Text = id;
               Session["ReqNo"]=txtRequisition.Text;
            }
        }
        //public void CreateReqNo()
        //{
        //    string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
        //    DateTime Date = DateTime.Today;
        //  txtReqno.Text=  _orderSheetbll.GetRequisitionNo(Ocode, Date);
        //}

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            //CreateReqNo();
            List<LC_Requisition> _requisition = new List<LC_Requisition>();
            foreach (GridViewRow gvRow in gridApprovalDetails.Rows)
            {
               
                CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                if (rowChkBox.Checked == true)
                {
                    LC_Requisition requisition = new LC_Requisition();

                    TextBox txtReqQty = ((TextBox)gvRow.FindControl("txtApproveQty"));                    
                    Label lblProductId = ((Label)gvRow.FindControl("lblProductId"));

                    requisition.LC_ReqNo =txtRequisition.Text;
                    requisition.Req_Approve_Date = Convert.ToDateTime(txtDate.Text);
                    requisition.ProductId = Convert.ToInt32(lblProductId.Text);                  
                   
                    if (txtReqQty.Text == "")
                    {
                        requisition.Req_ApprovedQty = 0;
                    }
                    else
                    {
                        requisition.Req_ApprovedQty = Convert.ToDouble(txtReqQty.Text);
                    }
                    
                    //requisition.UnitId = Convert.ToInt32(lblUnitId.Text);
                    //requisition.Buyer_ID = Convert.ToInt32(lblBuyerID.Text);
                    //requisition.ProductId = Convert.ToInt32(lblProductId.Text);
                    //requisition.LC_Style = lblLc_Style.Text;
                    //requisition.SupplierCode = lblSupplierCode.Text;
                    //requisition.GroupId = Convert.ToInt32(lblGroupId.Text);
                    //requisition.LC_ReqDate = Convert.ToDateTime(txtDate.Text);
                    //requisition.LC_Order = lblLc_Order.Text;
                    //requisition.OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                    //requisition.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                    //requisition.EditDate = DateTime.Today;
                    //requisition.IsReqApproved = false;
                    _requisition.Add(requisition);
                }
                   
            }
            var result = aLC_RequisitionBLL.UpdateRequisitionApprovedStatus(_requisition);
            if (result == 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Approve Successfully')", true);
                txtDate.Text = "";              
                gridApprovalDetails.DataSource = null;
                gridApprovalDetails.DataBind();
            }


            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            GetApproved_EstimatedSummaryByDate();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string RequNo =Convert.ToString( Session["ReqNo"]);
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<Rep_Estimate> _rptEstimateApp = new List<Rep_Estimate>();
                _rptEstimateApp = _lcReportBLL.GetCostEstimateRequisitionApproval(RequNo, OCode).ToList();
                if (_rptEstimateApp.Count > 0)
                {
                    Session["rptDs"] = "Rpt_LCCostEstimate";
                    Session["rptDt"] = _rptEstimateApp;
                    Session["rptFile"] = "/LC/Reports/CostEstimateRequisitionApproval.rdlc";
                    Session["rptTitle"] = "CostEstimateRequisitionApproval";
                    Response.Redirect("ReportViewer.aspx");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}