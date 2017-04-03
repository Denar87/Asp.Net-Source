using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using ERPSSL.INV.BLL;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace ERPSSL.INV
{
    public partial class MRRReports_RPT : System.Web.UI.Page
    {
        SupplierBLL supplierBll = new SupplierBLL();
        ReportsBll rpt = new ReportsBll();
        GroupBLL groupBll = new GroupBLL();
        ProductBLL productBll = new ProductBLL();
        CompanyBLL companyBll = new CompanyBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    FillSupplier();
                    FillProductGroup();
                    FillMasterLC();
                    ddlSupplier.Enabled = false;
                    txtMRRNo.Enabled = false;
                    ddlItemGroup.Enabled = false;
                    ddlItemName.Enabled = false;
                    ddlMasterLc.Enabled = false;
                    DivddlB2BLCNo.Visible = false;
                    DivddlPINo.Visible = false;
                    FillPI_No();
                    FillB2BLCNo();
                    GetAllStore();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        protected void GetAllStore()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                var row = companyBll.GetStore(OCODE);
                if (row.Count > 0)
                {
                    ddlStoreWiseMRR.DataSource = row.ToList();
                    ddlStoreWiseMRR.DataTextField = "StoreName";
                    ddlStoreWiseMRR.DataValueField = "Store_Code";
                    ddlStoreWiseMRR.DataBind();
                    ddlStoreWiseMRR.AppendDataBoundItems = false;
                    ddlStoreWiseMRR.Items.Insert(0, new ListItem("--Select Store & Company--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FillProductGroup()
        {

            ddlItemGroup.DataSource = groupBll.GetAllGroup();
            ddlItemGroup.DataValueField = "GroupId";
            ddlItemGroup.DataTextField = "GroupName";
            ddlItemGroup.DataBind();
            ddlItemGroup.Items.Insert(0, new ListItem("Select One", "0"));

        }

        public void FillSupplier()
        {
            ddlSupplier.DataSource = supplierBll.GetAllSupplier();
            ddlSupplier.DataValueField = "SupplierCode";
            ddlSupplier.DataTextField = "SupplierName";
            ddlSupplier.DataBind();
            ddlSupplier.Items.Insert(0, new ListItem("Select One", "0"));
        }
        public void FillMasterLC()
        {
            ddlMasterLc.DataSource = rpt.GetAllMAsterLC();
            ddlMasterLc.DataValueField = "MasterLCNo";
            ddlMasterLc.DataTextField = "MasterLCNo";
            ddlMasterLc.DataBind();
            ddlMasterLc.Items.Insert(0, new ListItem("Select One", "0"));

        }

        public void FillB2BLCNo()
        {
            ddlB2BLCNo.DataSource = rpt.GetAllB2BLC();
            ddlB2BLCNo.DataValueField = "B2BLCNo";
            ddlB2BLCNo.DataTextField = "B2BLCNo";
            ddlB2BLCNo.DataBind();
            ddlB2BLCNo.Items.Insert(0, new ListItem("Select One", "0"));

        }
        public void FillPI_No()
        {
            ddlPINo.DataSource = rpt.GetAllPiNoLC();
            ddlPINo.DataValueField = "PI_No";
            ddlPINo.DataTextField = "PI_No";
            ddlPINo.DataBind();
            ddlPINo.Items.Insert(0, new ListItem("Select One", "0"));

        }
        protected void RBLReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string reportType = RBLReport.SelectedValue;
                if (RBLReport.SelectedValue == "ProductsBySpecificSupplier")
                {
                    ddlSupplier.Enabled = true;
                    txtMRRNo.Text = string.Empty;
                    txtMRRNo.Enabled = false;
                    ddlItemGroup.Enabled = false;
                    ddlItemName.Enabled = false;
                    ddlMasterLc.Enabled = false;
                    DivStore.Visible = false;

                }
                else if (RBLReport.SelectedValue == "ProductsByChallanNumber")
                {
                    ddlSupplier.Enabled = false;
                    txtMRRNo.Enabled = true;
                    ddlItemGroup.Enabled = false;
                    ddlItemName.Enabled = false;
                    ddlMasterLc.Enabled = false;
                    DivStore.Visible = false;
                }

                else if (RBLReport.SelectedValue == "ProductsByGroup")
                {
                    ddlSupplier.Enabled = false;
                    txtMRRNo.Text = string.Empty;
                    txtMRRNo.Enabled = false;
                    ddlItemGroup.Enabled = true;
                    ddlItemName.Enabled = false;
                    ddlMasterLc.Enabled = false;
                    DivStore.Visible = false;
                }
                else if (RBLReport.SelectedValue == "SpecificProduct")
                {
                    ddlSupplier.Enabled = false;
                    txtMRRNo.Text = string.Empty;
                    txtMRRNo.Enabled = false;
                    ddlItemGroup.Enabled = true;
                    ddlItemName.Enabled = true;
                    ddlMasterLc.Enabled = false;
                    DivStore.Visible = false;
                }
                else if (RBLReport.SelectedValue == "ByMasterLC")
                {
                    ddlSupplier.Enabled = false;
                    txtMRRNo.Text = string.Empty;
                    txtMRRNo.Enabled = false;
                    ddlItemGroup.Enabled = false;
                    ddlItemName.Enabled = false;
                    ddlMasterLc.Enabled = true;
                    DivStore.Visible = false;
                }
                //--
                else if (RBLReport.SelectedValue == "ByB2BLc")
                {
                    ddlSupplier.Enabled = false;
                    txtMRRNo.Text = string.Empty;
                    txtMRRNo.Enabled = false;
                    ddlItemGroup.Enabled = false;
                    ddlItemName.Enabled = false;
                    ddlMasterLc.Enabled = false;
                    DivStore.Visible = false;
                    DivddlB2BLCNo.Visible = true;
                    DivddlPINo.Visible = false;
                }
                else if (RBLReport.SelectedValue == "ByPINo")
                {
                    ddlSupplier.Enabled = false;
                    txtMRRNo.Text = string.Empty;
                    txtMRRNo.Enabled = false;
                    ddlItemGroup.Enabled = false;
                    ddlItemName.Enabled = false;
                    ddlMasterLc.Enabled = false;
                    DivStore.Visible = false;
                    DivddlPINo.Visible = true;
                    DivddlB2BLCNo.Visible = false;
                }
                //---
                    
                else if (RBLReport.SelectedValue == "ByStoreWiseMRRReport")
                {
                    DivStore.Visible = true;
                    ddlSupplier.Enabled = false;
                    txtMRRNo.Text = "";
                    txtMRRNo.Enabled = false;
                    ddlItemGroup.Enabled = false;
                    ddlItemName.Enabled = false;
                    ddlMasterLc.Enabled = false;
                }
                else
                {
                    //ddlSupplier.Enabled = false;
                    //txtChallanNo.Enabled = false;
                    //ddlSupplier.Items.Clear();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void BindReport(DataTable dataSource, string typ)
        {
            try
            {
                ReportViewer1.LocalReport.DataSources.Clear();

                if (typ == "AllProductsReceived")
                {
                    ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllMRRReports.rdlc");
                    ModalPopupExtender.Show();
                }
                else if (typ == "AllProductsBySuppliers")
                {
                    ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllProductsBySuppliersReports.rdlc");
                    ModalPopupExtender.Show();
                }
                else if (typ == "ProductsByChallanNumber")
                {
                    ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_ProductsByChallanNumberReports.rdlc");
                    ModalPopupExtender.Show();
                }
                else if (typ == "ProductsBySpecificSupplier")
                {
                    ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllProductsBySuppliersReports.rdlc");
                    ModalPopupExtender.Show();
                }

                else if (typ == "ProductsByGroup")
                {
                    ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_ProductsByGroupReports.rdlc");
                    ModalPopupExtender.Show();
                }
                else if (typ == "SpecificProduct")
                {
                    ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_ProductsByItemWise.rdlc");
                    ModalPopupExtender.Show();
                }
                else if (typ == "ByMasterLC")
                {
                    ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_ProductsByMasterLC.rdlc");
                    ModalPopupExtender.Show();
                }

                    //---------
                else if (typ == "ByB2BLc")
                {
                    ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_ProductsByB2BLc.rdlc");
                    ModalPopupExtender.Show();
                }
                else if (typ == "ByPINo")
                {
                    ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_ProductsByPINo.rdlc");
                    ModalPopupExtender.Show();
                }
                //---------

                else if (typ == "ByStoreWiseMRRReport")
                {
                    if (txtFrom.Text == "" && txtTo.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select From Date And To Date')", true);
                        return;
                    }
                    ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/INV_RPT_StoreWiseMRRReport.rdlc");
                    ModalPopupExtender.Show();
                }
                ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void BtnGenerateReport_Click(object sender, EventArgs e)
        {
            try
            {
                string type = RBLReport.SelectedValue;
                Hashtable ht = new Hashtable();
                ht.Add("Type", RBLReport.SelectedValue);
                ht.Add("DateFrom", txtFrom.Text);
                ht.Add("DateTo", txtTo.Text);
                ht.Add("SupplierCode", ddlSupplier.SelectedValue);
                ht.Add("ChallanNo", txtMRRNo.Text);
                ht.Add("ProductGroupId", ddlItemGroup.SelectedValue);
                ht.Add("ProductId", ddlItemName.SelectedValue);
                ht.Add("MasterLC", ddlMasterLc.SelectedValue);

                ht.Add("B2BLCNo", ddlB2BLCNo.SelectedValue);
                ht.Add("PI_No", ddlPINo.SelectedValue);

                ht.Add("Store_Code", ddlStoreWiseMRR.SelectedValue);

                DataTable dt = new DataTable();
                dt = rpt.GetPurchaseReportData(ht);
                BindReport(dt, type);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlItemGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillProductName();
                if (RBLReport.SelectedValue == "ProductsByGroup")
                {
                    ddlItemName.Enabled = false;
                }
                else
                {
                    ddlItemName.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        public void FillProductName()
        {
            try
            {
                if (Convert.ToInt32(ddlItemGroup.SelectedValue) > 0)
                {
                    ddlItemName.DataSource = productBll.GetProductListByGroup(Convert.ToInt32(ddlItemGroup.SelectedValue));
                    ddlItemName.DataValueField = "ProductId";
                    ddlItemName.DataTextField = "ProductName";
                    ddlItemName.DataBind();
                    ddlItemName.Items.Insert(0, new ListItem("Select One", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

    }
}