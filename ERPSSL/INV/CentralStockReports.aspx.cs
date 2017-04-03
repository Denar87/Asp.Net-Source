using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.BLL;
using ERPSSL.INV.DAL.Repository;
using Microsoft.Reporting.WebForms;

namespace ERPSSL.INV
{
    public partial class CentralStockReports : System.Web.UI.Page
    {

        ReportsBll rpt = new ReportsBll();
        ProductBLL productBll = new ProductBLL();
        IChallanBLL ic = new IChallanBLL();
        StoreBLL aStoreBll = new StoreBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillProductGroup();
                LoadStore();
                //ddlItemGroup.Enabled = false;
                //ddlItemName.Enabled = false;

            }
        }

        public void FillProductGroup()
        {
            ddlItemGroup.DataSource = ic.GetListGroup();
            ddlItemGroup.DataValueField = "GroupId";
            ddlItemGroup.DataTextField = "GroupName";
            ddlItemGroup.DataBind();
            ddlItemGroup.Items.Insert(0, new ListItem("---Select---", "0"));
        }

        private void LoadStore()
        {
            try
            {

                var row = aStoreBll.GetStoreByProjectCodeByLocation(((SessionUser)Session["SessionUser"]).OCode);
                if (row.Count > 0)
                {
                    ddlStoreName.DataSource = row.ToList();
                    ddlStoreName.DataTextField = "StoreName";
                    ddlStoreName.DataValueField = "Store_Code";
                    ddlStoreName.DataBind();
                    ddlStoreName.Items.Insert(0, new ListItem("---Select---", "0"));
                }

            }
            catch
            {

            }

        }

        //protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string reportType = RadioButtonList1.SelectedValue;
        //    if (RadioButtonList1.SelectedValue == "FullStock")
        //    {
        //        ddlItemGroup.Enabled = false;
        //        ddlItemName.Enabled = false;
        //        txtQtyless.Enabled = false;
        //    }
        //    else if (RadioButtonList1.SelectedValue == "BySpecificProductGroup")
        //    {
        //        ddlItemGroup.Enabled = true;
        //        ddlItemName.Enabled = false;
        //        txtQtyless.Enabled = false;
        //    }

        //    else if (RadioButtonList1.SelectedValue == "BySpecificProduct")
        //    {
        //        ddlItemGroup.Enabled = true;
        //        ddlItemName.Enabled = true;
        //        txtQtyless.Enabled = false;

        //    }
        //    else if (RadioButtonList1.SelectedValue == "ByQuantityLessThen")
        //    {
        //        ddlItemGroup.Enabled = false;
        //        ddlItemName.Enabled = false;
        //        txtQtyless.Enabled = true;
        //    }
        //    else if (RadioButtonList1.SelectedValue == "LessThenReOrderQty")
        //    {
        //        ddlItemGroup.Enabled = false;
        //        ddlItemName.Enabled = false;
        //        txtQtyless.Enabled = false;
        //    }
        //}

        //private void BindReport(DataTable dataSource, string typ)
        //{
        //    // ? reports can be different for each type in future, thats why.

        //    ReportViewer1.LocalReport.DataSources.Clear();
        //    if (typ == "FullStock")
        //    {
        //        ReportDataSource reportDataset = new ReportDataSource("StockReportCentran_RPT_DS", dataSource);
        //        ReportViewer1.LocalReport.DataSources.Add(reportDataset);
        //        ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllStockReport.rdlc");
        //        // ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/StockReportCentral_RPT.rdlc");
        //    }
        //    else if (typ == "BySpecificProductGroup")
        //    {
        //        ReportDataSource reportDataset = new ReportDataSource("StockReportCentran_RPT_DS", dataSource);
        //        ReportViewer1.LocalReport.DataSources.Add(reportDataset);
        //        ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_StockReportsByItemGroup.rdlc");
        //        // ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/StockReportCentral_RPT.rdlc");
        //    }
        //    else if (typ == "BySpecificProduct")
        //    {
        //        ReportDataSource reportDataset = new ReportDataSource("StockReportCentran_RPT_DS", dataSource);
        //        ReportViewer1.LocalReport.DataSources.Add(reportDataset);
        //        ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_StockReportByItem.rdlc");
        //    }
        //    else if (typ == "ByQuantityLessThen")
        //    {
        //        ReportDataSource reportDataset = new ReportDataSource("StockReportCentran_RPT_DS", dataSource);
        //        ReportViewer1.LocalReport.DataSources.Add(reportDataset);
        //        ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_ItemStockByQuantityLessThen.rdlc");
        //    }
        //    else if (typ == "LessThenReOrderQty")
        //    {
        //        ReportDataSource reportDataset = new ReportDataSource("StockReportCentran_RPT_DS", dataSource);
        //        ReportViewer1.LocalReport.DataSources.Add(reportDataset);
        //        ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_ItemStockLessThenReorderLevel.rdlc");
        //    }
        //    ReportViewer1.LocalReport.Refresh();
        //}

        public void FillProductName()
        {
            if (Convert.ToInt32(ddlItemGroup.SelectedValue) > 0)
            {
                ddlItemName.DataSource = productBll.GetProductListByGroup(Convert.ToInt32(ddlItemGroup.SelectedValue));
                ddlItemName.DataValueField = "ProductId";
                ddlItemName.DataTextField = "ProductName";
                ddlItemName.DataBind();
                ddlItemName.Items.Insert(0, new ListItem("---Select---", "0"));
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //string type = RadioButtonList1.SelectedValue;
                //Hashtable ht = new Hashtable();
                //ht.Add("Source", "CENTRAL");
                //ht.Add("Type", RadioButtonList1.SelectedValue);
                //ht.Add("ProductGroupId", ddlItemGroup.SelectedValue);
                //ht.Add("ProductId", ddlItemName.SelectedValue);
                //ht.Add("QtyLessThen", txtQtyless.Text);
                //DataTable dt = new DataTable();
                //dt = rpt.GetStockReportData(ht);
                //BindReport(dt, type);
             
               List<productsDetails> Details = new List<productsDetails>();
                    if (rdbFullStock.Checked)
                    {
                        if (ddlStoreName.SelectedItem.Text != "---Select---" && txtFrom.Text == "" && txtTo.Text == "")   // store wise stock
                        {
                            Details = rpt.Rpt_GetStockBy_Store(ddlStoreName.SelectedValue.ToString());

                            if (Details.Count > 0)
                            {
                                ReportViewer1.LocalReport.DataSources.Clear();
                                ReportDataSource reportDataset = new ReportDataSource("AllStockReport_RPT_DS", Details);
                                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllCentralStockReportBy_Store.rdlc");
                                ReportViewer1.LocalReport.Refresh();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                                //ReportViewer1.LocalReport.DataSources.Clear();
                                ReportViewer1.Reset();
                                ReportViewer1.LocalReport.Refresh();
                            }
                        }
                        else if (ddlStoreName.SelectedItem.Text != "---Select---" && txtFrom.Text != "" && txtTo.Text != "")   // store & date wise stock
                        {
                            string OCode = (((SessionUser)Session["SessionUser"]).OCode);
                            Details = rpt.Rpt_GetFullStockDetailsByDate_WithStore(ddlStoreName.SelectedValue.ToString(), txtFrom.Text, txtTo.Text, OCode);

                            if (Details.Count > 0)
                            {
                                ReportViewer1.LocalReport.DataSources.Clear();
                                ReportDataSource reportDataset = new ReportDataSource("AllStockReport_RPT_DS", Details);
                                ReportViewer1.LocalReport.DataSources.Add(reportDataset);

                                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllCentralStockReportDateWise_WithStore.rdlc");
                                ReportViewer1.LocalReport.Refresh();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                                //ReportViewer1.LocalReport.DataSources.Clear();
                                ReportViewer1.Reset();
                                ReportViewer1.LocalReport.Refresh();
                            }
                        }
                        else
                        {
                            if (txtFrom.Text != "" && txtTo.Text != "" && ddlStoreName.SelectedItem.Text == "---Select---")  // date wise stock
                            {
                                string OCode = (((SessionUser)Session["SessionUser"]).OCode);
                                Details = rpt.Rpt_GetFullStockDetailsByDate(txtFrom.Text, txtTo.Text, OCode);
                                if (Details.Count > 0)
                                {
                                    ReportViewer1.LocalReport.DataSources.Clear();
                                    ReportDataSource reportDataset = new ReportDataSource("AllStockReport_RPT_DS", Details);
                                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllCentralStockReportDateWise.rdlc");
                                    ReportViewer1.LocalReport.Refresh();
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                                    //ReportViewer1.LocalReport.DataSources.Clear();
                                    ReportViewer1.Reset();
                                    ReportViewer1.LocalReport.Refresh();
                                }
                            }
                            else
                            {
                                Details = rpt.Rpt_GetFullStock();  // without date stock
                                if (Details.Count > 0)
                                {
                                    ReportViewer1.LocalReport.DataSources.Clear();
                                    ReportDataSource reportDataset = new ReportDataSource("AllStockReport_RPT_DS", Details);
                                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllCentralStockReport.rdlc");
                                    ReportViewer1.LocalReport.Refresh();
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                                    //ReportViewer1.LocalReport.DataSources.Clear();
                                    ReportViewer1.Reset();
                                    ReportViewer1.LocalReport.Refresh();
                                }
                            }
                        }
                    }

                    else if (rdbBySpecificItemGroup.Checked)
                    {
                        if (ddlStoreName.SelectedItem.Text != "---Select---" && ddlItemGroup.SelectedItem.Text != "---Select---" && ddlItemName.SelectedItem.Text == "---Select---" && txtFrom.Text == "" && txtTo.Text == "")
                        {
                            Details = rpt.Rpt_GetStockBy_Store_ProductGroup(ddlStoreName.SelectedValue.ToString(), ddlItemGroup.SelectedValue.ToString());

                            if (Details.Count > 0)
                            {
                                ReportViewer1.LocalReport.DataSources.Clear();
                                ReportDataSource reportDataset = new ReportDataSource("AllStockReport_RPT_DS", Details);
                                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllCentralStockReportBy_Store_ProductGroup.rdlc");
                                ReportViewer1.LocalReport.Refresh();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                                //ReportViewer1.LocalReport.DataSources.Clear();
                                ReportViewer1.Reset();
                                ReportViewer1.LocalReport.Refresh(); ;
                            }
                        }
                        else if (ddlStoreName.SelectedItem.Text != "---Select---" && ddlItemGroup.SelectedItem.Text != "---Select---" && ddlItemName.SelectedItem.Text == "---Select---" && txtFrom.Text != "" && txtTo.Text != "")
                        {
                            string OCode = (((SessionUser)Session["SessionUser"]).OCode);
                            Details = rpt.Rpt_GetFullStockDetailsByDate_Group_WithStore(ddlStoreName.SelectedValue.ToString(), txtFrom.Text, txtTo.Text, OCode, ddlItemGroup.SelectedValue.ToString());

                            if (Details.Count > 0)
                            {
                                ReportViewer1.LocalReport.DataSources.Clear();
                                ReportDataSource reportDataset = new ReportDataSource("AllStockReport_RPT_DS", Details);
                                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllCentralStockReportDateWise_Group_WithStore.rdlc");
                                ReportViewer1.LocalReport.Refresh();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                                //ReportViewer1.LocalReport.DataSources.Clear();
                                ReportViewer1.Reset();
                                ReportViewer1.LocalReport.Refresh(); ;
                            }
                        }
                        else if (ddlItemGroup.SelectedItem.Text != "---Select---" && ddlItemName.SelectedItem.Text == "---Select---" && txtFrom.Text != "" && txtTo.Text != "")
                        {
                            string OCode = (((SessionUser)Session["SessionUser"]).OCode);
                            Details = rpt.Rpt_GetFullStockDetailsByDate_Group(txtFrom.Text, txtTo.Text, OCode, ddlItemGroup.SelectedValue.ToString());

                            if (Details.Count > 0)
                            {
                                ReportViewer1.LocalReport.DataSources.Clear();
                                ReportDataSource reportDataset = new ReportDataSource("AllStockReport_RPT_DS", Details);
                                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllCentralStockReportDateWise_Group.rdlc");
                                ReportViewer1.LocalReport.Refresh();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                                //ReportViewer1.LocalReport.DataSources.Clear();
                                ReportViewer1.Reset();
                                ReportViewer1.LocalReport.Refresh(); ;
                            }
                        }
                    }

                    else if (rdbBySpecificItem.Checked)
                    {
                        if (ddlStoreName.SelectedItem.Text != "---Select---" && ddlItemGroup.SelectedItem.Text != "---Select---" && ddlItemName.SelectedItem.Text != "---Select---" && txtFrom.Text == "" && txtTo.Text == "")
                        {
                            Details = rpt.Rpt_GetStockBy_Store_Product(ddlStoreName.SelectedValue.ToString(), ddlItemGroup.SelectedValue.ToString(), ddlItemName.SelectedValue.ToString());

                            if (Details.Count > 0)
                            {
                                ReportViewer1.LocalReport.DataSources.Clear();
                                ReportDataSource reportDataset = new ReportDataSource("AllStockReport_RPT_DS", Details);
                                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllCentralStockReportBy_Store_Product.rdlc");
                                ReportViewer1.LocalReport.Refresh();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                                //ReportViewer1.LocalReport.DataSources.Clear();
                                ReportViewer1.Reset();
                                ReportViewer1.LocalReport.Refresh();
                            }
                        }
                        else if (ddlStoreName.SelectedItem.Text != "---Select---" && ddlItemGroup.SelectedItem.Text != "---Select---" && ddlItemName.SelectedItem.Text != "---Select---" && txtFrom.Text != "" && txtTo.Text != "")
                        {
                            string OCode = (((SessionUser)Session["SessionUser"]).OCode);
                            Details = rpt.Rpt_GetFullStockDetailsByDate_Product_WithStore(txtFrom.Text, txtTo.Text, OCode, ddlItemGroup.SelectedValue.ToString(), ddlItemName.SelectedValue.ToString(), ddlStoreName.SelectedValue.ToString());

                            if (Details.Count > 0)
                            {
                                ReportViewer1.LocalReport.DataSources.Clear();
                                ReportDataSource reportDataset = new ReportDataSource("AllStockReport_RPT_DS", Details);
                                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllCentralStockReportDateWise_Product_WithStore.rdlc");
                                ReportViewer1.LocalReport.Refresh();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                                //ReportViewer1.LocalReport.DataSources.Clear();
                                ReportViewer1.Reset();
                                ReportViewer1.LocalReport.Refresh();
                            }
                        }
                        else
                            if (ddlStoreName.SelectedItem.Text == "---Select---" && ddlItemGroup.SelectedItem.Text != "---Select---" && ddlItemName.SelectedItem.Text != "---Select---" && txtFrom.Text != "" && txtTo.Text != "")
                            {
                                string OCode = (((SessionUser)Session["SessionUser"]).OCode);
                                Details = rpt.Rpt_GetFullStockDetailsByDate_Product(txtFrom.Text, txtTo.Text, OCode, ddlItemGroup.SelectedValue.ToString(), ddlItemName.SelectedValue.ToString());

                                if (Details.Count > 0)
                                {
                                    ReportViewer1.LocalReport.DataSources.Clear();
                                    ReportDataSource reportDataset = new ReportDataSource("AllStockReport_RPT_DS", Details);
                                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllCentralStockReportDateWise_Product.rdlc");
                                    ReportViewer1.LocalReport.Refresh();
                                }
                                else
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                                    //ReportViewer1.LocalReport.DataSources.Clear();
                                    ReportViewer1.Reset();
                                    ReportViewer1.LocalReport.Refresh();
                                }
                            }

                    }


                    else if (rdbItemDetailByDate.Checked == true)
                    {
                        if (ddlStoreName.SelectedItem.Text != "---Select---" && ddlItemGroup.SelectedItem.Text != "---Select---" && ddlItemName.SelectedItem.Text != "---Select---" && txtFrom.Text != "" && txtTo.Text != "")
                        {
                            string OCode = (((SessionUser)Session["SessionUser"]).OCode);
                            Guid userId = (((SessionUser)Session["SessionUser"]).UserId);
                            Details = rpt.Rpt_GetFullStockDetailsByDate_Product_Store(txtFrom.Text, txtTo.Text, OCode, ddlItemGroup.SelectedValue.ToString(), ddlItemName.SelectedValue.ToString(), ddlStoreName.SelectedValue.ToString(), userId);

                            if (Details.Count > 0)
                            {
                                ReportViewer1.LocalReport.DataSources.Clear();
                                ReportDataSource reportDataset = new ReportDataSource("AllStockReport_RPT_DS", Details);
                                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllCentralStockReportDateWise_Product_Store.rdlc");
                                ReportViewer1.LocalReport.Refresh();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                                //ReportViewer1.LocalReport.DataSources.Clear();
                                ReportViewer1.Reset();
                                ReportViewer1.LocalReport.Refresh();
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select information for search!')", true);
                        }
                    }

                    else if (btnByQtyLessThan.Checked)
                    {
                        if (ddlStoreName.SelectedItem.Text != "---Select---" && txtQtyless.Text != "")
                        {
                            Details = rpt.Rpt_GetStockBy_Store_LessThanQty(ddlStoreName.SelectedValue.ToString(), Convert.ToInt32(txtQtyless.Text));

                            if (Details.Count > 0)
                            {
                                ReportViewer1.LocalReport.DataSources.Clear();
                                ReportDataSource reportDataset = new ReportDataSource("AllStockReport_RPT_DS", Details);
                                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllCentralStockReportBy_Store_LessThenQty.rdlc");
                                ReportViewer1.LocalReport.Refresh();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                                // ReportViewer1.LocalReport.DataSources.Clear();
                                ReportViewer1.Reset();
                                ReportViewer1.LocalReport.Refresh();
                            }

                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Search The Operation !')", true);

                        }

                    }
                    else if (btnLessThenReOrder.Checked)
                    {
                        if (ddlStoreName.SelectedItem.Text != "---Select---")
                        {
                            Details = rpt.Rpt_GetStockBy_Store_ReOrderQty(ddlStoreName.SelectedValue.ToString());

                            if (Details.Count > 0)
                            {
                                ReportViewer1.LocalReport.DataSources.Clear();
                                ReportDataSource reportDataset = new ReportDataSource("AllStockReport_RPT_DS", Details);
                                ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                                ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllCentralStockReportBy_Store_LessThenQty.rdlc");
                                ReportViewer1.LocalReport.Refresh();
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                                ReportViewer1.Reset();
                                ReportViewer1.LocalReport.Refresh();
                            }
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Search The Operation !')", true);

                        }
                    }


             
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void ddlItemGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillProductName();
            ddlItemName.Enabled = true;
        }
    }
}