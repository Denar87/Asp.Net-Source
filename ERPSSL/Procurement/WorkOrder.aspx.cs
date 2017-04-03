using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.Procurement.BLL;
using System.Data;
using System.Collections;
using Microsoft.Reporting.WebForms;

namespace ERPSSL.Procurement
{
    public partial class WorkOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillPurchaseOrder();
                btnWorkOrderDone.Visible = false;
            }
        }

        public void FillSupplier(string PrOrderNo, string BarCode)
        {
            ddlSupplier.DataSource = QuotationBll.GetBidders(PrOrderNo, BarCode);
            ddlSupplier.DataValueField = "SupplierCode";
            ddlSupplier.DataTextField = "SupplierName";
            ddlSupplier.DataBind();
            ddlSupplier.Items.Insert(0, new ListItem("Select One", "0"));
        }

        protected void ddlPurchaseOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadProducts(ddlPurchaseOrder.SelectedValue);
            LoadQuotations(ddlPurchaseOrder.SelectedValue, "All");
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillSupplier(ddlPurchaseOrder.SelectedValue, ddlProduct.SelectedValue);
            LoadQuotations(ddlPurchaseOrder.SelectedValue, ddlProduct.SelectedValue);
        }
      
        private void FillPurchaseOrder()
        {
            ddlPurchaseOrder.DataSource = PurchaseOrderBll.GetPurchaseOrderList();
            ddlPurchaseOrder.DataValueField = "PrOrderNo";
            ddlPurchaseOrder.DataTextField = "PrOrderNo";
            ddlPurchaseOrder.DataBind();
            ddlPurchaseOrder.Items.Insert(0, new ListItem("Select One", "0"));
        }

        private void LoadProducts(string PrOrderNo)
        {
            ddlProduct.DataSource = PurchaseOrderBll.GetUnGivenProducts(PrOrderNo);
            ddlProduct.DataValueField = "BarCode";
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataBind();
            ddlProduct.Items.Insert(0, new ListItem("Select One", "0"));
        }

        protected void btnOrderWork_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "Please print this report before completing Work order.";
            DataTable dt = new DataTable();
            string PrOrderNo = ddlPurchaseOrder.SelectedValue;
            Hashtable ht = new Hashtable();
            ht.Add("PrOrderNo", PrOrderNo);
            ht.Add("SupCode", ddlSupplier.SelectedValue);
            ht.Add("BarCode", ddlProduct.SelectedValue);
            dt = QuotationBll.GetPurchaseOrder(ht);
            ReportViewer2.LocalReport.DataSources.Clear();
            ReportDataSource reportDataset = new ReportDataSource("WorkOrder_RPT_DS", dt);
            ReportViewer2.LocalReport.DataSources.Add(reportDataset);
            ReportViewer2.LocalReport.ReportPath = Server.MapPath("Reports/WorkOrder_RPT.rdlc");
            ReportViewer2.LocalReport.Refresh();
            btnWorkOrderDone.Visible = true;
        }

        private void LoadQuotations(string PrOrderNo, string BarCode)
        {
            grdQuotations.DataSource = QuotationBll.GetQuotationsByBarCode(PrOrderNo, BarCode);
            grdQuotations.DataBind();
        }

        protected void btnWorkOrderDone_Click(object sender, EventArgs e)
        {
            if (QuotationBll.CompleteWorkOrder(ddlPurchaseOrder.SelectedValue, ddlSupplier.SelectedValue, ddlProduct.SelectedValue, txtRemarks.Text))
            {
                btnWorkOrderDone.Visible = false;
                DataTable dt3 = PurchaseOrderBll.GetPurchaseOrderProducts(ddlPurchaseOrder.SelectedValue);
                if (PurchaseOrderBll.MailToSupplier(ddlSupplier.SelectedValue, ddlPurchaseOrder.SelectedValue, dt3))
                {

                }
                lblWorkOrder.Text = "<font color='green'>Work order has been given to this supplier.</font>";
                FillPurchaseOrder();
            }
            else
            {
                lblWorkOrder.Text = "<font color='red'>Error in generating work order!.</font>";
            }
        }

    }
}