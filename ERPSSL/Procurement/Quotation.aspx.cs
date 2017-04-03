using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.BLL;
using System.Data;
using Microsoft.Reporting.WebForms;
using ERPSSL.Procurement.BLL;
using System.Collections;

namespace ERPSSL.Procurement
{
    public partial class Quotation : System.Web.UI.Page
    {
        SupplierBLL supplierBll = new SupplierBLL();
        static DataTable StDT;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillPurchaseOrder();
                txtQuotationDate.Text = DateTime.Today.ToShortDateString();
            }
        }

        public void FillSupplier(string PrOrderNo)
        {
            ddlSupplier.DataSource = QuotationBll.GetSupplierList(PrOrderNo);
            ddlSupplier.DataValueField = "SupplierCode";
            ddlSupplier.DataTextField = "SupplierName";
            ddlSupplier.DataBind();
            ddlSupplier.Items.Insert(0, new ListItem("Select One", "0"));
        }

        private void FillPurchaseOrder()
        {
            StDT = PurchaseOrderBll.GetPurchaseOrderList();
            ddlPurchaseOrder.DataSource = StDT;
            ddlPurchaseOrder.DataValueField = "PrOrderNo";
            ddlPurchaseOrder.DataTextField = "PrOrderNo";
            ddlPurchaseOrder.DataBind();
            ddlPurchaseOrder.Items.Insert(0, new ListItem("Select One", "0"));

            ddlPurchaseOrderReport.DataSource = StDT;
            ddlPurchaseOrderReport.DataValueField = "PrOrderNo";
            ddlPurchaseOrderReport.DataTextField = "PrOrderNo";
            ddlPurchaseOrderReport.DataBind();
            ddlPurchaseOrderReport.Items.Insert(0, new ListItem("Select One", "0"));
        }

        protected void ddlPurchaseOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            string PrOrderNo = ddlPurchaseOrder.SelectedValue;
            ClearForm();
            LoadProducts(PrOrderNo);
            FillSupplier(PrOrderNo);
        }

        private void LoadProducts(string PrOrderNo)
        {
            ddlProduct.DataSource = PurchaseOrderBll.GetProducts(PrOrderNo);
            ddlProduct.DataValueField = "BarCode";
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataBind();
            ddlProduct.Items.Insert(0, new ListItem("Select One", "0"));
        }

        private void ClearForm()
        {
            txtOrderedQty.Text = string.Empty;
            txtCPU.Text = string.Empty;
            txtQuotationNo.Text = string.Empty;
            ddlSupplier.ClearSelection();
        }
        private void ClearForQuotation()
        {
            txtCPU.Text = string.Empty;
            txtQuotationNo.Text = string.Empty;
            //ddlSupplierCode.ClearSelection();
            ddlProduct.ClearSelection();
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            string BarCode = ddlProduct.SelectedValue;
            string PrOrderNo = ddlPurchaseOrder.SelectedValue;
            string SupCode = ddlSupplier.SelectedValue;
            SetQuotationNo(PrOrderNo, BarCode, SupCode);
            txtOrderedQty.Text = PurchaseOrderBll.GetSelectedProduct(PrOrderNo, BarCode);
        }

        private void SetQuotationNo(string PrOrderNo, string Barcode, string SupplierCode)
        {
            txtQuotationNo.Text = PrOrderNo + Barcode + SupplierCode + QuotationBll.GetCount(PrOrderNo, SupplierCode);
        }

        protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            string BarCode = ddlProduct.SelectedValue;
            string PrOrderNo = ddlPurchaseOrder.SelectedValue;
            string SupCode = ddlSupplier.SelectedValue;
            //SetQuotationNo(PrOrderNo, BarCode, SupCode);
            LoadQuotations(ddlPurchaseOrder.SelectedValue, ddlSupplier.SelectedValue);
        }

        private void LoadQuotations(string PrOrderNo, string SupCode)
        {
            grdQuotations.DataSource = QuotationBll.GetQuotationsByPrOrder(PrOrderNo, SupCode);
            grdQuotations.DataBind();
        }

        protected void txtQuotationDate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string BarCode = ddlProduct.SelectedValue;
                string PrOrderNo = ddlPurchaseOrder.SelectedValue;
                string SupCode = ddlSupplier.SelectedValue;
                SetQuotationNo(PrOrderNo, BarCode, SupCode);
            }
            catch { }
        }

        protected void BtnAddQuotation_Click(object sender, EventArgs e)
        {
            if (ddlPurchaseOrder.SelectedValue == "0" || ddlSupplier.SelectedValue == "0" || txtCPU.Text == "" || txtQuotationDate.Text == "")
            {
                return;
            }
            Hashtable ht = new Hashtable();
            string PrOrderNo = ddlPurchaseOrder.SelectedValue;
            try
            {
                ht.Add("QtNo", txtQuotationNo.Text);
                ht.Add("PrOrderNo", ddlPurchaseOrder.SelectedValue);
                ht.Add("SupplierCode", ddlSupplier.SelectedValue);
                ht.Add("BarCode", ddlProduct.SelectedValue);
                ht.Add("CPU", txtCPU.Text);
                ht.Add("QtDate", txtQuotationDate.Text);
                ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode);
                if (QuotationBll.AddQuotation(ht))
                {
                    LoadQuotations(PrOrderNo, ddlSupplier.SelectedValue);
                    lblMessage.Text = "<font color='green'>Quotation added successfully!</font>";
                    ClearForQuotation();

                }
                else
                {
                    lblMessage.Text = "<font color='red'>Error in adding quotation!</font>";
                }
            }
            catch
            {
            }
        }

        protected void BtnReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlPurchaseOrder.SelectedValue != "0")
                {
                    GenerateReport(ddlPurchaseOrder.SelectedValue);
                }
            }
            catch
            {

            }
        }

        private void GenerateReport(string PrOrderNo)
        {
            Hashtable ht = new Hashtable();
            ht.Add("PrOrderNo", PrOrderNo);
            DataTable dt = new DataTable();
            dt = QuotationBll.QuotationReportReportData(ht);
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource reportDataset = new ReportDataSource("QuotationByPrOrder_DS", dt);
            ReportViewer1.LocalReport.DataSources.Add(reportDataset);
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/QuotationByPrOrder.rdlc");
            ReportViewer1.LocalReport.Refresh();
        }

        protected void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                if (ddlPurchaseOrderReport.SelectedValue != "0")
                {
                    GenerateReport(ddlPurchaseOrderReport.SelectedValue);
                }
            }
            catch
            {

            }
        }

    }
}