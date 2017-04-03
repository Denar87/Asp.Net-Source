using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.BLL;
using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL;

namespace ERPSSL.LC
{
    public partial class CreateInvoice : System.Web.UI.Page
    {
        ERPSSL.LC.BLL.OrderSheetBLL _orderSheetbll = new ERPSSL.LC.BLL.OrderSheetBLL();
        GroupBLL groupBll = new GroupBLL();

        InvoiceDAL _InvoiceDAL = new InvoiceDAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    FillSeason();
                    FillLCNo();
                    Fillbuyer();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void Fillbuyer()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            var result = _InvoiceDAL.GetBuyer(ocode);
            if (result.Count > 0)
            {
                ddlBayer.DataSource = result;
                ddlBayer.DataTextField = "Buyer_Name";
                ddlBayer.DataValueField = "Buyer_Name";
                ddlBayer.DataBind();
                ddlBayer.AppendDataBoundItems = false;
                ddlBayer.Items.Insert(0, new ListItem("--Select Buyer--", "0"));
            }
        }

        private void FillSeason()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = _orderSheetbll.GetOrderEntryByDistrinct(ocode);
                if (row.Count > 0)
                {
                    ddlSeason.DataSource = row.ToList();
                    //ddlSeason.DataTextField = "Season";
                    //ddlSeason.DataValueField = "Season";
                    ddlSeason.DataBind();
                    ddlSeason.AppendDataBoundItems = false;
                    ddlSeason.Items.Insert(0, new ListItem("--Select Item Category--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //private void FillStyle(string season)
        //{
        //    try
        //    {
        //        string ocode = ((SessionUser)Session["SessionUser"]).OCode;
        //        var row = _orderSheetbll.GetOrderEntryBySeason(season);
        //        if (row.Count > 0)
        //        {
                                       
        //            ddlStyle.DataSource = row.ToList();                    
        //            ddlStyle.DataBind();
        //            ddlStyle.AppendDataBoundItems = false;
        //            ddlStyle.Items.Insert(0, new ListItem("--Select Item Category--", "0"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
        private void FillLCNo()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = _orderSheetbll.GetLCNo(ocode);
                if (row.Count > 0)
                {
                    ddlLCNo.DataSource = row.ToList();
                    ddlLCNo.DataTextField = "LCNo";
                    ddlLCNo.DataValueField = "LCNo";
                    ddlLCNo.DataBind();
                    ddlLCNo.AppendDataBoundItems = false;
                    ddlLCNo.Items.Insert(0, new ListItem("--Select Item Category--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillPoOrder(string season)
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = _orderSheetbll.GetOrderEntry_Season(season);
                if (row.Count > 0)
                {
                    ddlPoOrder.DataSource = row.ToList();
                    ddlPoOrder.DataTextField = "OrderNo";
                    ddlPoOrder.DataValueField = "OrderNo";
                    ddlPoOrder.DataBind();
                    ddlPoOrder.AppendDataBoundItems = false;
                    ddlPoOrder.Items.Insert(0, new ListItem("--Select Item Category--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //private void FillSeason(string PoOrder)
        //{
        //    try
        //    {
        //        string ocode = ((SessionUser)Session["SessionUser"]).OCode;
        //        var row = _orderSheetbll.GetOrderEntryByPoOrder(PoOrder);
        //        if (row.Count > 0)
        //        {
        //            ddlPoOrder.DataSource = row.ToList();
        //            ddlPoOrder.DataBind();
        //            ddlPoOrder.AppendDataBoundItems = false;
        //            ddlPoOrder.Items.Insert(0, new ListItem("--Select Item Category--", "0"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}
      
       

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                LC_Invoice_Create invoice = new LC_Invoice_Create();
                //invoice.BayerName = ddlBayer.SelectedValue.ToString();
                invoice.Consignee = txtConsignee.Text;
                invoice.NotifyParty = txtNotifyParty.Text;
               // invoice.ERCNo = txtERCNO.Text;
               // invoice.DT = Convert.ToDateTime(txtDt.Text);
               // invoice.VatReg = txtVatReg.Text;
                invoice.InvoiceNo = txtInvoiceNo.Text;
                invoice.InvoiceDate = Convert.ToDateTime(txtinvoiceDate.Text);
                invoice.EXPNo = txtExpNo.Text;
                invoice.EXPDate = Convert.ToDateTime(txtExpDate.Text);
                invoice.LCNo = ddlLCNo.Text;
                invoice.LCDate = Convert.ToDateTime( txtLCDate.Text);
                invoice.IssuingBank = txtIssueBank.Text;
                invoice.DeliveryAddress = txtDeliveryAddress.Text;
                invoice.OriginatedCountry = txtOriginatedCountry.Text;
                invoice.Destination = txtDestination.Text;
                invoice.Season = ddlSeason.SelectedItem.Text;
                invoice.OrderNo = ddlPoOrder.SelectedItem.Text;
                //invoice.Article = ddlArticle.SelectedItem.Text;
               // invoice.Style = ddlStyle.SelectedItem.Text;
               // invoice.Haldensleben = txtHealdensleben.Text;
               // invoice.CNo = txtCNo.Text;
                //invoice.TotalCTNS = Convert.ToDouble(txtTotalCTNS.Text);
               // invoice.GrossWGT =Convert.ToDouble( txtGROSSWGT.Text);
               // invoice.NetWGT =Convert.ToDouble( txtNETWGT.Text);
               // invoice.Cubic =Convert.ToDouble( txtCUBIC.Text);

                int result = _InvoiceDAL.Insert(invoice);
                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Clear()
        {        
        
        }

        protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DateTime day = DateTime.Today;
            //txtAutoOrderId.Text = _orderSheetbll.GetNewChalanNo("OPLC-", day, ddlSeason.Text.ToString());

            FillPoOrder(ddlSeason.SelectedItem.Text);
            //var result = _orderSheetbll.GetOrderEntryBySeason(ddlSeason.SelectedItem.Text);
            //if (result.Count > 0)
            //{
            //    grdRequisition.DataSource = result;
            //    grdRequisition.DataBind();
            //}
        }

        protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerChkBox = ((CheckBox)grvOrder.HeaderRow.FindControl("headerLevelCheckBox"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grvOrder.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grvOrder.Rows)
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

        protected void txtUSDRate_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
            TextBox textqty = (TextBox)gvRow.FindControl("txtQty");
            if (textqty.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Request Qty')", true);
                return;
            }
            Label lblTotalRs = (Label)gvRow.FindControl("lblValue");
            try
            {
                lblTotalRs.Text = ((Convert.ToDecimal(txt.Text)) * (Convert.ToDecimal(textqty.Text))).ToString();
            }
            catch { lblTotalRs.Text = "0"; txt.Text = "0"; }
        }

       

        protected void ddlPoOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
           // FillArticle(ddlPoOrder.SelectedItem.Text);

        }

        //protected void ddlArticle_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var result = _orderSheetbll.GetLCOrderPlanning(ddlArticle.SelectedItem.Text);
        //    if (result.Count > 0)
        //    {
        //        var mn = result.First();
        //        gridOrderPlanning.DataSource = result;
        //        gridOrderPlanning.DataBind();


        //    }
        //    else
        //    {
        //        gridOrderPlanning.DataSource = null;
        //        gridOrderPlanning.DataBind();
        //    }
        //}

        protected void ddlLCNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = _orderSheetbll.GetbankInfo(ddlLCNo.SelectedItem.Text);
            if (result.Count > 0)
            {
                var row = result.First();
                txtIssueBank.Text = row.LC_Issue_Bank;
                txtLCDate.Text = row.DateofIssue.ToString();
            }
        }

        protected void ddlBayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = _InvoiceDAL.GetDataBayerWise(ddlBayer.SelectedItem.Text);
            if (result.Count > 0)
            {
                var row = result.First();
                txtConsignee.Text = row.Consignee;
                txtNotifyParty.Text = row.NotifyParty;            
            }
        }
    }
}