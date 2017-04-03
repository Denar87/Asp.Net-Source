using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.BLL;
using ERPSSL.INV.DAL.Repository;
using Microsoft.Reporting.WebForms;

namespace ERPSSL.INV
{
    public partial class OthersReports_RPT : System.Web.UI.Page
    {

        ReportsBll aReportsBll = new ReportsBll();
        ProductBLL productBll = new ProductBLL();
        IChallanBLL ic = new IChallanBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    FillProductGroup();
                    //ddlItemGroup.Enabled = false;
                    //ddlItemName.Enabled = false;
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        public void FillProductGroup()
        {
            ddlItemGroup.DataSource = ic.GetListGroup();
            ddlItemGroup.DataValueField = "GroupId";
            ddlItemGroup.DataTextField = "GroupName";
            ddlItemGroup.DataBind();
            ddlItemGroup.Items.Insert(0, new ListItem("Select One", "0"));
        }

        //public void FillProductName()
        //{

        //    if (Convert.ToInt32(ddlItemGroup.SelectedValue) > 0)
        //    {
        //        ddlItemName.DataSource = productBll.GetProductListByGroup(Convert.ToInt32(ddlItemGroup.SelectedValue));
        //        ddlItemName.DataValueField = "ProductId";
        //        ddlItemName.DataTextField = "ProductName";
        //        ddlItemName.DataBind();
        //        ddlItemName.Items.Insert(0, new ListItem("Select One", "0"));
        //    }

        //}

        protected void btnViewReport_Click(object sender, EventArgs e)
        {
            try
            {
                ReportViewer1.LocalReport.DataSources.Clear();
                List<productsDetails> Product = new List<productsDetails>();

                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                if (RadioButtonList1.SelectedValue == "AllProduct")
                {
                    if (ddlItemGroup.SelectedItem.Text != "Select One")
                    {
                        Product = aReportsBll.GetAllProductByGroupId(Convert.ToInt32(ddlItemGroup.SelectedValue), ((SessionUser)Session["SessionUser"]).OCode).ToList();
                        if (Product.Count > 0)
                        {
                            ReportViewer1.LocalReport.DataSources.Clear();
                            ReportDataSource Datasource = new ReportDataSource("ALL_ProductsReports_DS", Product);
                            ReportViewer1.LocalReport.DataSources.Add(Datasource);
                            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_AllProductByGroupID.rdlc");
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
                        Product = aReportsBll.Rpt_GetAllProducts().ToList();
                        if (Product.Count > 0)
                        {
                            ReportViewer1.LocalReport.DataSources.Clear();
                            ReportDataSource Datasource = new ReportDataSource("ALL_ProductsReports_DS", Product);
                            ReportViewer1.LocalReport.DataSources.Add(Datasource);
                            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_ProductRepots.rdlc");
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                            ReportViewer1.Reset();
                            ReportViewer1.LocalReport.Refresh();
                        }
                    }

                }
                else if (RadioButtonList1.SelectedValue == "AllSupplier")
                {
                    List<SuplierDetails> Supplier = new List<SuplierDetails>();
                    Supplier = aReportsBll.Rpt_GetAllSupplier().ToList();
                    if (Supplier.Count > 0)
                    {
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportDataSource Datasource = new ReportDataSource("RPT_Supplier_Ds", Supplier);
                        ReportViewer1.LocalReport.DataSources.Add(Datasource);
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_SuplierRepots.rdlc");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        ReportViewer1.Reset();
                        ReportViewer1.LocalReport.Refresh();
                    }
                }
                else if (RadioButtonList1.SelectedValue == "ItemUpdateLog")
                {
                    List<ProductLog> product = new List<ProductLog>();
                    product = aReportsBll.Rpt_GetAllProduct(OCODE).ToList();
                    if (product.Count > 0)
                    {
                        ReportViewer1.LocalReport.DataSources.Clear();
                        ReportDataSource Datasource = new ReportDataSource("Item_Update_Log_ds", product);
                        ReportViewer1.LocalReport.DataSources.Add(Datasource);
                        ReportViewer1.LocalReport.ReportPath = Server.MapPath("Reports/RPT_ItemUpdateLog.rdlc");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                        ReportViewer1.Reset();
                        ReportViewer1.LocalReport.Refresh();
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
            //FillProductName();
            //ddlItemName.Enabled = true;
        }
    }
}