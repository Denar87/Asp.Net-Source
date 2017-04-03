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
    public partial class ReturnReports : System.Web.UI.Page
    {
        SupplierBLL supplierBll = new SupplierBLL();
        ReportsBll rpt = new ReportsBll();
        GroupBLL groupBll = new GroupBLL();
        ProductBLL productBll = new ProductBLL();
        Inv_StoreBLL companyBll = new Inv_StoreBLL();
        IChallanBLL iChallanBll = new IChallanBLL();
        StoreBLL aStoreBll = new StoreBLL();
        ReturnBLL aReturnBLL = new ReturnBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillSupplier();
                FillDepartment();
                FillProductGroup();
                //FillStore();
                // GetAllStore();
                ddlSupplier.Enabled = true;
                ddlItemGroup.Enabled = false;
                ddlItemName.Enabled = false;
                //ddlStoreName.Enabled = false;
            }
        }

        public void FillDepartment()
        {
            ddlDepartment.DataSource = iChallanBll.GetDepartmentList();
            ddlDepartment.DataValueField = "DPT_CODE";
            ddlDepartment.DataTextField = "DPT_NAME";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("Select One", "0"));
        }

        private void LoadEmployeeList(string DeptCode)
        {
            try
            {
                ddlReciver.DataSource = iChallanBll.GetEmployeeList(DeptCode);
                ddlReciver.DataValueField = "EID";
                ddlReciver.DataTextField = "EMP_NAME";
                ddlReciver.DataBind();
                ddlReciver.Items.Insert(0, new ListItem("Select One", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string DeptCode = ddlDepartment.SelectedValue.ToString();
                LoadEmployeeList(DeptCode);
                //txtChalanNo.Text = iChallanBll.GetNewChalanNoForGeneralStoreToDpt(DeptCode);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        //public void FillStore()
        //{
        //    try
        //    {
        //        //string projectCode = ddlProject.SelectedValue.ToString();
        //        var row = aStoreBll.GetStoreByProjectCodeByLocation(((SessionUser)Session["SessionUser"]).OCode);
        //        if (row.Count > 0)
        //        {
        //            ddlStoreName.DataSource = row.ToList();
        //            ddlStoreName.DataTextField = "StoreName";
        //            ddlStoreName.DataValueField = "Store_Code";
        //            ddlStoreName.DataBind();
        //            ddlStoreName.Items.Insert(0, new ListItem("---Select---", "0"));
        //        }
        //    }
        //    catch
        //    {
        //    }
        //}

        //protected void GetAllStore()
        //{
        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        //string OCODE = "8989";
        //        var row = companyBll.GetCompnay(OCODE);
        //        if (row.Count > 0)
        //        {
        //            ddlStore.DataSource = row.ToList();
        //            ddlStore.DataTextField = "CompanyName";
        //            ddlStore.DataValueField = "CompanyCode";
        //            ddlStore.DataBind();
        //            ddlStore.AppendDataBoundItems = false;
        //            ddlStore.Items.Insert(0, new ListItem("Select One", "0"));
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

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

        protected void RBLReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string reportType = RBLReport.SelectedValue;
                if (RBLReport.SelectedValue == "AllReturnFromSuppliers")
                {
                    //ddlStoreName.Enabled = false;
                    ddlSupplier.Enabled = true;
                    //txtMRRNo.Text = string.Empty;
                    //txtMRRNo.Enabled = false;
                    ddlItemGroup.Enabled = false;
                    ddlItemName.Enabled = false;
                    ddlDepartment.Enabled = false;
                    ddlReciver.Enabled = false;
                }

                else if (RBLReport.SelectedValue == "AllReturnFromDepartment")
                {
                    //ddlStoreName.Enabled = false;
                    ddlSupplier.Enabled = false;
                    //txtMRRNo.Text = string.Empty;
                    //txtMRRNo.Enabled = false;
                    ddlItemGroup.Enabled = false;
                    ddlItemName.Enabled = false;
                    ddlDepartment.Enabled = true;
                    ddlReciver.Enabled = true;
                    ddlSupplier.ClearSelection();
                }

                else if (RBLReport.SelectedValue == "ProductsBySpecificSupplier")
                {
                    ddlSupplier.Enabled = true;
                    //txtMRRNo.Text = string.Empty;
                    //txtMRRNo.Enabled = false;
                    ddlItemGroup.Enabled = false;
                    ddlItemName.Enabled = false;
                }

                else if (RBLReport.SelectedValue == "ProductsByGroup")
                {
                    ddlSupplier.Enabled = false;
                    //txtMRRNo.Text = string.Empty;
                    //txtMRRNo.Enabled = false;
                    ddlItemGroup.Enabled = true;
                    ddlItemName.Enabled = false;
                }
                else if (RBLReport.SelectedValue == "SpecificProduct")
                {
                    ddlSupplier.Enabled = false;
                    //txtMRRNo.Text = string.Empty;
                    //txtMRRNo.Enabled = false;
                    ddlItemGroup.Enabled = true;
                    ddlItemName.Enabled = true;
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

                if (typ == "AllReturnFromSuppliers" && txtFrom.Text != " " && txtTo.Text != "" && ddlSupplier.SelectedItem.Text == "Select One")
                {
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource reportDataset = new ReportDataSource("ReturnsReport_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_SupplierReturnReports.rdlc");
                }
                else if (typ == "AllReturnFromSuppliers" && txtFrom.Text != " " && txtTo.Text != "" && ddlSupplier.SelectedItem.Text != "Select One")
                {
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource reportDataset = new ReportDataSource("ReturnsReport_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_SupplierReturnReports_BySupplier.rdlc");
                }
                else if (typ == "AllReturnFromDepartment" && txtFrom.Text != " " && txtTo.Text != "" && ddlDepartment.SelectedItem.Text == "Select One")
                {
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource reportDataset = new ReportDataSource("ReturnsReport_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_DepartmentReturnReports.rdlc");
                }
                else if (typ == "AllReturnFromDepartment" && txtFrom.Text != " " && txtTo.Text != "" && ddlDepartment.SelectedItem.Text != "Select One")
                {
                    ReportViewer1.LocalReport.DataSources.Clear();
                    ReportDataSource reportDataset = new ReportDataSource("ReturnsReport_DS", dataSource);
                    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_DepartmentReturnReports_ByEmp.rdlc");
                }

                //else if (typ == "AllProductsReceived" && ddlStoreName.SelectedItem.Text == "---Select---")
                //{
                //    ReportViewer1.LocalReport.DataSources.Clear();
                //    ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
                //    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllMRRReports.rdlc");
                //}
                //else if (typ == "AllProductsReceived" && ddlStoreName.SelectedItem.Text != "---Select---")
                //{
                //    ReportViewer1.LocalReport.DataSources.Clear();
                //    ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
                //    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllMRRReports_Store.rdlc");
                //}
                //else if (typ == "AllProductsBySuppliers" && ddlStoreName.SelectedItem.Text == "---Select---")
                //{
                //    ReportViewer1.LocalReport.DataSources.Clear();
                //    ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
                //    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllProductsBySuppliersReports.rdlc");
                //}
                //else if (typ == "AllProductsBySuppliers" && ddlStoreName.SelectedItem.Text != "---Select---")
                //{
                //    ReportViewer1.LocalReport.DataSources.Clear();
                //    ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
                //    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllProductsBySuppliersReports_Store.rdlc");
                //}
                //else if (typ == "ProductsByChallanNumber" && ddlStoreName.SelectedItem.Text == "---Select---")
                //{
                //    ReportViewer1.LocalReport.DataSources.Clear();
                //    ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
                //    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_ProductsByChallanNumberReports.rdlc");
                //}
                //else if (typ == "ProductsByChallanNumber" && ddlStoreName.SelectedItem.Text != "---Select---")
                //{
                //    ReportViewer1.LocalReport.DataSources.Clear();
                //    ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
                //    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_ProductsByChallanNumberReports_Store.rdlc");
                //}
                //else if (typ == "ProductsBySpecificSupplier" && ddlStoreName.SelectedItem.Text == "---Select---")
                //{
                //    ReportViewer1.LocalReport.DataSources.Clear();
                //    ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
                //    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllProductsBySuppliersAllReports.rdlc");
                //}
                //else if (typ == "ProductsBySpecificSupplier" && ddlStoreName.SelectedItem.Text != "---Select---")
                //{
                //    ReportViewer1.LocalReport.DataSources.Clear();
                //    ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
                //    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllProductsBySuppliersAllReports_Store.rdlc");
                //}

                //else if (typ == "ProductsByGroup" && ddlStoreName.SelectedItem.Text == "---Select---")
                //{
                //    ReportViewer1.LocalReport.DataSources.Clear();
                //    ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
                //    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_ProductsByGroupReports.rdlc");
                //}
                //else if (typ == "ProductsByGroup" && ddlStoreName.SelectedItem.Text != "---Select---")
                //{
                //    ReportViewer1.LocalReport.DataSources.Clear();
                //    ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
                //    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_ProductsByGroupReports_Store.rdlc");
                //}
                //else if (typ == "SpecificProduct" && ddlStoreName.SelectedItem.Text == "---Select---")
                //{
                //    ReportViewer1.LocalReport.DataSources.Clear();
                //    ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
                //    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_ProductsByItemWise.rdlc");
                //}
                //else if (typ == "SpecificProduct" && ddlStoreName.SelectedItem.Text != "---Select---")
                //{
                //    ReportViewer1.LocalReport.DataSources.Clear();
                //    ReportDataSource reportDataset = new ReportDataSource("AllPurchaseReport_DS", dataSource);
                //    ReportViewer1.LocalReport.DataSources.Add(reportDataset);
                //    ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_ProductsByItemWise_Store.rdlc");
                //}

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
                //if (ddlStoreName.SelectedItem.Text != "---Select---")
                //{
                //    string type = RBLReport.SelectedValue;
                //    Hashtable ht = new Hashtable();
                //    ht.Add("Type", RBLReport.SelectedValue);
                //    ht.Add("DateFrom", txtFrom.Text);
                //    ht.Add("DateTo", txtTo.Text);
                //    ht.Add("SupplierCode", ddlSupplier.SelectedValue);
                //    ht.Add("ChallanNo", txtMRRNo.Text);
                //    ht.Add("ProductGroupId", ddlItemGroup.SelectedValue);
                //    ht.Add("ProductId", ddlItemName.SelectedValue);
                //    ht.Add("StoreCode", ddlStoreName.SelectedValue);
                //    DataTable dt = new DataTable();
                //    dt = rpt.GetPurchaseReportDataWithStore(ht);
                //    BindReport(dt, type);
                //}

                if (txtFrom.Text != " " && txtTo.Text != "" && ddlSupplier.SelectedItem.Text != "Select One")
                {
                    string type = RBLReport.SelectedValue;
                    Hashtable ht = new Hashtable();
                    ht.Add("Type", RBLReport.SelectedValue);
                    ht.Add("DateFrom", txtFrom.Text);
                    ht.Add("DateTo", txtTo.Text);
                    ht.Add("SupplierCode", ddlSupplier.SelectedValue);
                    DataTable dt = new DataTable();
                    dt = rpt.GetReturnFromSupplier_BySupplier(ht);

                    if (dt.Rows.Count > 0)
                    {
                        BindReport(dt, type);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                    }
                }

                else if (txtFrom.Text != " " && txtTo.Text != "" && ddlDepartment.SelectedItem.Text != "Select One")
                {
                    string type = RBLReport.SelectedValue;
                    Hashtable ht = new Hashtable();
                    ht.Add("Type", RBLReport.SelectedValue);
                    ht.Add("DateFrom", txtFrom.Text);
                    ht.Add("DateTo", txtTo.Text);
                    ht.Add("EID", ddlReciver.SelectedValue);
                    DataTable dt = new DataTable();
                    dt = rpt.GetReturnFromDept_ByEmp(ht);

                    if (dt.Rows.Count > 0)
                    {
                        BindReport(dt, type);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                    }
                }
                else
                {
                    string type = RBLReport.SelectedValue;
                    Hashtable ht = new Hashtable();
                    ht.Add("Type", RBLReport.SelectedValue);
                    ht.Add("DateFrom", txtFrom.Text);
                    ht.Add("DateTo", txtTo.Text);
                    DataTable dt = new DataTable();
                    dt = rpt.GetReturnToSupplier_Store_ByDate(ht);

                    if (dt.Rows.Count > 0)
                    {
                        BindReport(dt, type);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
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