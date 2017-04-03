using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.BLL;
using Microsoft.Reporting.WebForms;

namespace ERPSSL.INV
{
    public partial class GIN_Reports : System.Web.UI.Page
    {
        ProductBLL aProductBll = new ProductBLL();
        ReportsBll rpt = new ReportsBll();
        IChallanBLL aChallanBll = new IChallanBLL();
        CompanyBLL companyBll = new CompanyBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillCompany();
                FillProductGroup();
                ddlStoreFrom.Enabled = false;
                ddlStoreTo.Enabled = false;
                txtGINNo.Enabled = false;
                TxtEmployeeId.Enabled = false;
                ddlItemGroup.Enabled = false;
                ddlItemName.Enabled = false;
                LoadSubCompanyList();
                GetAllStore();
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
                    ddlStoreWiseGIN.DataSource = row.ToList();
                    ddlStoreWiseGIN.DataTextField = "StoreName";
                    ddlStoreWiseGIN.DataValueField = "Store_Code";
                    ddlStoreWiseGIN.DataBind();
                    ddlStoreWiseGIN.AppendDataBoundItems = false;
                    ddlStoreWiseGIN.Items.Insert(0, new ListItem("--Select Store & Company--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadSubCompanyList()
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = companyBll.GetSubCompanyList(OCode);
                if (row.Count > 0)
                {
                    ddlSubCompany.DataSource = row.ToList();
                    ddlSubCompany.DataTextField = "SubCompanyName";
                    ddlSubCompany.DataValueField = "SubCompany_Id";
                    ddlSubCompany.DataBind();
                    ddlSubCompany.AppendDataBoundItems = false;
                    ddlSubCompany.Items.Insert(0, new ListItem("--Select Sub company--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillProductGroup()
        {
            ddlItemGroup.DataSource = aChallanBll.GetListGroup();
            ddlItemGroup.DataValueField = "GroupId";
            ddlItemGroup.DataTextField = "GroupName";
            ddlItemGroup.DataBind();
            ddlItemGroup.Items.Insert(0, new ListItem("Select One", "0"));
        }

        private void FillCompany()
        {
            ddlStoreFrom.DataSource = aChallanBll.GetCompanyList();
            ddlStoreFrom.DataValueField = "CompanyCode";
            ddlStoreFrom.DataTextField = "CompanyName";
            ddlStoreFrom.DataBind();
            ddlStoreFrom.Items.Insert(0, new ListItem("Select One", "0"));

            ddlStoreTo.DataSource = aChallanBll.GetCompanyList();
            ddlStoreTo.DataValueField = "CompanyCode";
            ddlStoreTo.DataTextField = "CompanyName";
            ddlStoreTo.DataBind();
            ddlStoreTo.Items.Insert(0, new ListItem("Select One", "0"));
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string type = RBLReport.SelectedValue;
                Hashtable ht = new Hashtable();
                ht.Add("Type", RBLReport.SelectedValue);
                ht.Add("DateFrom", txtFrom.Text);
                ht.Add("DateTo", txtTo.Text);
                ht.Add("CompanyToCode", ddlStoreTo.SelectedValue);
                ht.Add("CompanyFromCode", ddlStoreFrom.SelectedValue);
                ht.Add("ChallanNo", txtGINNo.Text);
                ht.Add("EID", TxtEmployeeId.Text);
                ht.Add("ProductGroupId", ddlItemGroup.SelectedValue);
                ht.Add("ProductId", ddlItemName.SelectedValue);
                ht.Add("Sub_Company", ddlSubCompany.SelectedItem.Text);
                ht.Add("Store_Code", ddlStoreWiseGIN.SelectedValue);
                DataTable dt = new DataTable();
                dt = rpt.GetDeliveryReportData(ht);
                BindReport(dt, type);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        private void BindReport(DataTable dataSource, string typ)
        {
            try
            {  // ? reports can be different for each type in future, that's why.
                ReportViewer1.LocalReport.DataSources.Clear();

                if (typ == "AllProductsDelivered")
                {
                    ReportDataSource reportDataset = new ReportDataSource("AllDeliver_RPT_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/AllItemDeliveryReport_RPT.rdlc");
                }
                else if (typ == "DeliveryByGroup")
                {
                    ReportDataSource reportDataset = new ReportDataSource("AllDeliver_RPT_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_SpecificItemByGroupReport_RPT.rdlc");
                }
                else if (typ == "DeliveryBySpecificEmployeeId")
                {
                    ReportDataSource reportDataset = new ReportDataSource("AllDeliver_RPT_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_DeliveryReportByEmployeeWise.rdlc");
                }
                else if (typ == "DeliveryToSpecificCompany")
                {
                    ReportDataSource reportDataset = new ReportDataSource("AllDeliver_RPT_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/AllItemDeliveryReport_RPT.rdlc");
                }
                else if (typ == "DeliveryFromSpecificCompany")
                {
                    ReportDataSource reportDataset = new ReportDataSource("AllDeliver_RPT_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/AllItemDeliveryReport_RPT.rdlc");
                }
                else if (typ == "DeliveryFromSpecificCompanyToCompany")
                {
                    if (ddlStoreTo.SelectedValue != "0" && ddlStoreFrom.SelectedValue != "0")
                    {
                        ReportDataSource reportDataset = new ReportDataSource("AllDeliver_RPT_DS", dataSource);
                        ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/DeliveryCompanyToCompnay.rdlc");
                    }
                    else
                    {
                        lblMessage.Text = "Please select Company to and Company from";
                    }
                }
                else if (typ == "DeliveryByChallanNumber")
                {
                    ReportDataSource reportDataset = new ReportDataSource("AllDeliver_RPT_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_DeliveryByChalanNo.rdlc");
                }

                else if (typ == "SubCompanyWiseReport")
                {
                    ReportDataSource reportDataset = new ReportDataSource("AllDeliver_RPT_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_DeliveryBySubCompany.rdlc");
                }

                else if (typ == "StoreToStoreTransferHistory")
                {
                    ReportDataSource reportDataset = new ReportDataSource("AllDeliver_RPT_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/INV_RPT_StoreToStoreTransferHistory.rdlc");
                }

                else if (typ == "DeliverySpecificProduct")
                {
                    ReportDataSource reportDataset = new ReportDataSource("AllDeliver_RPT_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_SpecificItemByGroupReport_RPT.rdlc");
                }

                else if (typ == "ByStoreWiseGINReport")
                {
                    if (txtFrom.Text == "" && txtTo.Text == "")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select From Date And To Date')", true);
                        return;
                    }
                    ReportDataSource reportDataset = new ReportDataSource("AllDeliver_RPT_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/INV_RPT_StoreWiseGINReport.rdlc");
                }

                ReportViewer1.LocalReport.Refresh();
            }
            catch (Exception)
            {

                throw;
            }
          



        }

        protected void RBLReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            string reportType = RBLReport.SelectedValue;
            if (RBLReport.SelectedValue == "AllProductsDelivered")
            {
                DivStore.Visible = false;
                ddlStoreFrom.Enabled = false;
                ddlStoreTo.Enabled = false;
                txtGINNo.Text = string.Empty;
                txtGINNo.Enabled = false;
                ddlItemGroup.Enabled = false;
                ddlItemName.Enabled = false;

            }
            if (RBLReport.SelectedValue == "DeliveryBySpecificEmployeeId")
            {
                DivStore.Visible = false;
                ddlStoreFrom.Enabled = false;
                ddlStoreTo.Enabled = false;
                TxtEmployeeId.Enabled = true;
                txtGINNo.Text = string.Empty;
                txtGINNo.Enabled = false;
                ddlItemGroup.Enabled = false;
                ddlItemName.Enabled = false;

            }
            else if (RBLReport.SelectedValue == "DeliveryToSpecificCompany")
            {
                DivStore.Visible = false;
                ddlStoreFrom.Enabled = false;
                ddlStoreTo.Enabled = true;
                txtGINNo.Text = string.Empty;
                txtGINNo.Enabled = false;
                ddlItemGroup.Enabled = false;
                ddlItemName.Enabled = false;
            }

            else if (RBLReport.SelectedValue == "DeliveryFromSpecificCompany")
            {
                DivStore.Visible = false;
                ddlStoreFrom.Enabled = true;
                ddlStoreTo.Enabled = false;
                txtGINNo.Text = string.Empty;
                txtGINNo.Enabled = false;
                ddlItemGroup.Enabled = false;
                ddlItemName.Enabled = false;
            }
            else if (RBLReport.SelectedValue == "DeliveryFromSpecificCompanyToCompany")
            {
                DivStore.Visible = false;
                ddlStoreFrom.Enabled = true;
                ddlStoreTo.Enabled = true;
                txtGINNo.Text = string.Empty;
                txtGINNo.Enabled = false;
                ddlItemGroup.Enabled = false;
                ddlItemName.Enabled = false;
            }
            else if (RBLReport.SelectedValue == "DeliveryByChallanNumber")
            {
                DivStore.Visible = false;
                ddlStoreFrom.Enabled = false;
                ddlStoreTo.Enabled = false;
                txtGINNo.Text = string.Empty;
                txtGINNo.Enabled = true;
                TxtEmployeeId.Enabled = false;
                ddlItemGroup.Enabled = false;
                ddlItemName.Enabled = false;
            }
            else if (RBLReport.SelectedValue == "DeliveryByGroup")
            {
                DivStore.Visible = false;
                ddlStoreFrom.Enabled = false;
                ddlStoreTo.Enabled = false;
                txtGINNo.Text = string.Empty;
                txtGINNo.Enabled = false;
                ddlItemGroup.Enabled = true;
                ddlItemName.Enabled = false;
            }
            else if (RBLReport.SelectedValue == "DeliverySpecificProduct")
            {
                DivStore.Visible = false;
                ddlStoreFrom.Enabled = false;
                ddlStoreTo.Enabled = false;
                txtGINNo.Text = string.Empty;
                txtGINNo.Enabled = false;
                ddlItemGroup.Enabled = true;
                ddlItemName.Enabled = true;
            }

            else if (RBLReport.SelectedValue == "ByStoreWiseGINReport")
            {
                DivStore.Visible = true;
                ddlStoreFrom.Enabled = false;
                ddlStoreTo.Enabled = false;
                txtGINNo.Text = string.Empty;
                txtGINNo.Enabled = false;
                ddlItemGroup.Enabled = false;
                ddlItemName.Enabled = false;
            }

            else
            {
                //ddlSupplier.Enabled = false;
                //txtChallanNo.Enabled = false;
                //ddlSupplier.Items.Clear();
            }
        }

        protected void ddlItemGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillProductName();
            // ddlItemName.Enabled = true;
        }

        private void FillProductName()
        {

            if (Convert.ToInt32(ddlItemGroup.SelectedValue) > 0)
            {
                ddlItemName.DataSource = aProductBll.GetProductListByGroup(Convert.ToInt32(ddlItemGroup.SelectedValue));
                ddlItemName.DataValueField = "ProductId";
                ddlItemName.DataTextField = "ProductName";
                ddlItemName.DataBind();
                ddlItemName.Items.Insert(0, new ListItem("Select One", "0"));
            }
        }
    }
}