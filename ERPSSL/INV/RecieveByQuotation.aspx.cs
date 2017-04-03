using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.BLL;
using ERPSSL.Procurement.BLL;
using System.Collections;
using ERPSSL.INV.DAL;
using Microsoft.Reporting.WebForms;

namespace ERPSSL.INV
{
    public partial class RecieveByQuotation : System.Web.UI.Page
    {
        RChallanBLL rChallanBll = new RChallanBLL();
        PurchaseOrderBll purchaseOrderBll = new PurchaseOrderBll();
        CompanyBLL companyBll = new CompanyBLL();
        BuyCentralBLL buyCentralBll = new BuyCentralBLL();
        BuyBLL buyBll = new BuyBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.FillCompany();
                LoadPurchaseOrders();
                txtDate.Text = DateTime.Today.ToShortDateString();
            }
        }

        public void FillCompany()
        {
            DataTable dt = new DataTable();
            dt = companyBll.GetCentralCompany();

            ddlCompanyCode.DataSource = dt;
            ddlCompanyCode.DataValueField = "CompanyId";
            ddlCompanyCode.DataTextField = "CompanyCode";
            ddlCompanyCode.DataBind();
            foreach (DataRow dr in dt.Rows)
            {
                HiddenCompanyName.Value = dr["CompanyName"].ToString();
                HiddenCompanyCode.Value = dr["CompanyCode"].ToString();
            }
        }

        private void LoadPurchaseOrders()
        {
            gvPurchase.DataSource = purchaseOrderBll.GetWorkOrders("ByQuotation");
            gvPurchase.DataBind();
        }

        private void GenerateReport()
        {
            try
            {
                string challanNo = txtChalanNo.Text.Trim();
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                DataTable dataSource = rChallanBll.GetVoucherReport(challanNo, Ocode);
                ReportViewerPurchase.LocalReport.DataSources.Clear();
                ReportDataSource reportDataset = new ReportDataSource("PurchaseVoucher_DS", dataSource);
                ReportViewerPurchase.LocalReport.DataSources.Add(reportDataset);
                ReportViewerPurchase.LocalReport.ReportPath = Server.MapPath("Reports/PurchaseVoucher_RPT.rdlc");
                ReportViewerPurchase.LocalReport.Refresh();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string challanNo = txtChalanNo.Text.Trim();

                //string CType = hiddenCompanyType.Value;
                string CType = "CENTRAL";
                if (CType == "CENTRAL")
                {
                    Inv_BuyCentral buyCentral = buyCentralBll.GetBuyCentralByCompanyAndBarcode(hdnBarCode.Value, ddlCompanyCode.SelectedValue.ToString());
                    if (buyCentral == null)
                    { // Insert New

                        Inv_BuyCentral newBuyCentral = new Inv_BuyCentral();
                        newBuyCentral.ChallanNo = txtChalanNo.Text;
                        newBuyCentral.CompanyId = Convert.ToInt32(ddlCompanyCode.SelectedValue);
                        newBuyCentral.CompanyCode = HiddenCompanyCode.Value;
                        newBuyCentral.CompanyName = HiddenCompanyName.Value;
                        newBuyCentral.BarCode = hdnBarCode.Value;
                        newBuyCentral.ProductId = int.Parse(hdnBarCode.Value.ToString());
                        newBuyCentral.ProductGroup = int.Parse(HiddenProductGroup.Value.ToString());
                        newBuyCentral.ProductName = txtProduct.Text;
                        newBuyCentral.Brand = txtBrand.Text;

                        //newBuyCentral.StyleSize = rchallan.StyleSize;
                        //newBuyCentral.FloorName = rchallan.FloorName;
                        newBuyCentral.UnitName = txtUnit.Text;
                        newBuyCentral.ReceiveQuantity = Convert.ToInt32(txtRecQty.Text.Trim());
                        //newBuyCentral.CPU = rchallan.CPU;
                        //newBuyCentral.RPU = rchallan.RPU;
                        //newBuyCentral.ExpireDate = rchallan.ExpireDate;
                        //newBuyCentral.BalanceQuanity = rchallan.BalanceQty;
                        try
                        {
                            newBuyCentral.PurchaseDate = DateTime.Parse(txtDate.Text);
                        }
                        catch
                        {
                            newBuyCentral.PurchaseDate = DateTime.Today;
                        }

                        newBuyCentral.EditDate = DateTime.Now;
                        newBuyCentral.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                        newBuyCentral.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                        buyCentralBll.Insert(newBuyCentral);
                    }
                    else
                    {
                        buyCentral.BalanceQuanity = buyCentral.BalanceQuanity + Convert.ToInt32(txtRecQty.Text.Trim());
                        //buyCentral.CPU = rchallan.CPU;
                        //buyCentral.RPU = rchallan.RPU;
                        //buyCentral.ExpireDate = rchallan.ExpireDate;
                        buyCentral.ReceiveQuantity = buyCentral.ReceiveQuantity + Convert.ToInt32(txtRecQty.Text.Trim());
                        buyCentralBll.Update(buyCentral, Convert.ToInt32(buyCentral.Id));
                    }

                    Inv_RChallan rchallan = new Inv_RChallan();
                    rchallan.ChallanNo = txtChalanNo.Text;
                    rchallan.CompanyId = Convert.ToInt32(ddlCompanyCode.SelectedValue);
                    rchallan.CompanyCode = HiddenCompanyCode.Value;
                    rchallan.CompanyName = HiddenCompanyName.Value;
                    rchallan.Barcode = hdnBarCode.Value;
                    rchallan.ProductId = int.Parse(hdnBarCode.Value.ToString());
                    rchallan.ProductGroup = int.Parse(HiddenProductGroup.Value.ToString());
                    rchallan.ProductName = txtProduct.Text;
                    rchallan.Brand = txtBrand.Text;
                    //rchallan.StyleSize = rchallan.StyleSize;
                    //rchallan.FloorName = rchallan.FloorName;
                    rchallan.UnitName = txtUnit.Text;
                    rchallan.ReceiveQuantity = Convert.ToInt32(txtRecQty.Text.Trim());
                    //rchallan.CPU = rchallan.CPU;
                    //rchallan.RPU = rchallan.RPU;
                    //rchallan.ExpireDate = rchallan.ExpireDate;
                    //rchallan.BalanceQuanity = rchallan.BalanceQty;
                    try
                    {
                        rchallan.PurchaseDate = DateTime.Parse(txtDate.Text);
                    }
                    catch
                    {
                        rchallan.PurchaseDate = DateTime.Today;
                    }

                    rchallan.EditDate = DateTime.Now;
                    rchallan.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                    rchallan.Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                    rChallanBll.Insert(rchallan);
                    PurchaseOrderBll.PurchaseDone(txtPOrderNo.Text);
                    LoadPurchaseOrders();
                    // lblMessage.Text = "<font color='green'>Purchase information posted successfully</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Purchase information posted successfully')", true);
                    GenerateReport();
                    ClearForm();

                }
                else // obsolete // hiddenCompanyType = General
                {

                    Inv_Buy buy = buyBll.GetBuyByCompanyAndBarcode(hdnBarCode.Value, ddlCompanyCode.SelectedValue.ToString());

                    if (buy == null)
                    { // Insert New

                        Inv_Buy invBuy = new Inv_Buy();

                        invBuy.ChallanNo = txtChalanNo.Text;
                        invBuy.CompanyId = Convert.ToInt32(ddlCompanyCode.SelectedValue);
                        invBuy.CompanyCode = HiddenCompanyCode.Value;
                        invBuy.CompanyName = HiddenCompanyName.Value;
                        invBuy.BarCode = hdnBarCode.Value;
                        invBuy.ProductId = int.Parse(hdnBarCode.Value.ToString());
                        invBuy.ProductGroup = int.Parse(HiddenProductGroup.Value.ToString());
                        invBuy.ProductName = txtProduct.Text;
                        invBuy.Brand = txtBrand.Text;
                        //newBuyCentral.StyleSize = rchallan.StyleSize;
                        //newBuyCentral.FloorName = rchallan.FloorName;
                        invBuy.UnitName = txtUnit.Text;
                        invBuy.ReceiveQuantity = Convert.ToInt32(txtRecQty.Text.Trim());
                        //newBuyCentral.CPU = rchallan.CPU;
                        //newBuyCentral.RPU = rchallan.RPU;
                        //newBuyCentral.ExpireDate = rchallan.ExpireDate;
                        //newBuyCentral.BalanceQuanity = rchallan.BalanceQty;
                        try
                        {
                            invBuy.PurchaseDate = DateTime.Parse(txtDate.Text);
                        }
                        catch
                        {
                            invBuy.PurchaseDate = DateTime.Today;
                        }

                        invBuy.EditDate = DateTime.Now;
                        invBuy.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                        invBuy.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                        buyBll.Insert(invBuy);

                    }
                    else
                    {

                        buy.BalanceQuanity = buy.BalanceQuanity + Convert.ToInt32(txtRecQty.Text.Trim());
                        //buy.CPU = rchallan.CPU;
                        //buy.RPU = rchallan.RPU;
                        //buy.ExpireDate = rchallan.ExpireDate;
                        buy.ReceiveQuantity = buy.ReceiveQuantity + Convert.ToInt32(txtRecQty.Text.Trim());
                        buyBll.Update(buy, Convert.ToInt32(buy.Id));
                    }

                    Inv_RChallan rchallan = new Inv_RChallan();
                    rchallan.ChallanNo = txtChalanNo.Text;
                    rchallan.CompanyId = Convert.ToInt32(ddlCompanyCode.SelectedValue);
                    rchallan.CompanyCode = HiddenCompanyCode.Value;
                    rchallan.CompanyName = HiddenCompanyName.Value;
                    rchallan.Barcode = hdnBarCode.Value;
                    rchallan.ProductId = int.Parse(hdnBarCode.Value.ToString());
                    rchallan.ProductGroup = int.Parse(HiddenProductGroup.Value.ToString());
                    rchallan.ProductName = txtProduct.Text;
                    rchallan.Brand = txtBrand.Text;
                    //rchallan.StyleSize = rchallan.StyleSize;
                    //rchallan.FloorName = rchallan.FloorName;
                    rchallan.UnitName = txtUnit.Text;
                    rchallan.ReceiveQuantity = Convert.ToInt32(txtRecQty.Text.Trim());
                    //rchallan.CPU = rchallan.CPU;
                    //rchallan.RPU = rchallan.RPU;
                    //rchallan.ExpireDate = rchallan.ExpireDate;
                    //rchallan.BalanceQuanity = rchallan.BalanceQty;
                    try
                    {
                        rchallan.PurchaseDate = DateTime.Parse(txtDate.Text);
                    }
                    catch
                    {
                        rchallan.PurchaseDate = DateTime.Today;
                    }

                    rchallan.EditDate = DateTime.Now;
                    rchallan.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                    rchallan.Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                    rChallanBll.Insert(rchallan);
                    PurchaseOrderBll.PurchaseDone(txtPOrderNo.Text);
                    LoadPurchaseOrders();
                    //lblMessage.Text = "<font color='green'>Purchase information posted successfully</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Purchase information posted successfully')", true);


                }
                ClearForm();

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearForm()
        {
            txtProduct.Text = "";
            txtBrand.Text = "";
            txtUnit.Text = "";
            txtOrderQTY.Text =
            txtRecQty.Text = "";
            //txtBalQTY.Text = "";
        }

        private void LoadForm(string Id)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = PurchaseOrderBll.GetProductsToReceive("ByQuotation", Id);
                foreach (DataRow dr in dt.Rows)
                {
                    txtPOrderNo.Text = dr["PrOrderNo"].ToString();
                    hdnSupCode.Value = dr["SupplierCode"].ToString();
                    txtSupplier.Text = dr["SupplierName"].ToString();
                    HiddenProductGroup.Value = dr["GroupId"].ToString();
                    txtProduct.Text = dr["ProductName"].ToString();
                    txtUnit.Text = dr["UnitName"].ToString();
                    txtBrand.Text = dr["Brand"].ToString();
                    //txtBalQTY.Text = dr["BalQty"].ToString();
                    txtOrderQTY.Text = dr["OrderedQty"].ToString();
                    hdnBarCode.Value = dr["BarCode"].ToString();

                    txtChalanNo.Text = rChallanBll.GetNewRChalanNo(dr["SupplierCode"].ToString(), DateTime.Parse((txtDate.Text)));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }

        protected void gvPurchase_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            GridViewRow row = gvPurchase.Rows[gvPurchase.SelectedIndex];
            string Id = row.Cells[1].Text;
            LoadForm(Id);
            
        }

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            if (txtDate.Text != string.Empty && txtSupplier.Text != "0")
            {
                string DeptCode = txtSupplier.Text.ToString();
                DateTime day = DateTime.Parse(txtDate.Text);
                txtChalanNo.Text = rChallanBll.GetNewRChalanNo(DeptCode, day);
            }
        }    
    }
}