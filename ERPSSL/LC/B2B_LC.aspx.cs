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
    public partial class B2B_LC : System.Web.UI.Page
    {
        ERPSSL.LC.BLL.OrderSheetBLL _orderSheetbll = new ERPSSL.LC.BLL.OrderSheetBLL();
        GroupBLL groupBll = new GroupBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    FillSupplierName();
                    FillItemName();
                    FillSeason();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void FillSeason()
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_Season> row = _orderSheetbll.GetAllSeason(OCode);
                if (row != null)
                {
                    ddlSeason.DataSource = row.ToList();
                    ddlSeason.DataTextField = "Season_Name";
                    ddlSeason.DataValueField = "Season_Id";
                    ddlSeason.DataBind();
                    ddlSeason.Items.Insert(0, new ListItem("--Select Season--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillStyle(string article)
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = _orderSheetbll.GetOrderEntryByarticle(article);
                if (row.Count > 0)
                {
                    ddlStyle.DataSource = row.ToList();
                    //ddlStyle.DataTextField = "Style";
                    //ddlStyle.DataValueField = "Style";
                    ddlStyle.DataBind();
                    ddlStyle.AppendDataBoundItems = false;
                    ddlStyle.Items.Insert(0, new ListItem("--Select Item Category--", "0"));
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
                var row = _orderSheetbll.GetOrderEntryBySeason(season);
                if (row.Count > 0)
                {
                    ddlPoOrder.DataSource = row.ToList();
                    // ddlPoOrder.DataTextField = "OrderNo";
                    // ddlPoOrder.DataValueField = "OrderNo";
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

        private void FillArticle(string PoOrder)
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = _orderSheetbll.GetOrderEntryByPoOrder(PoOrder);
                if (row.Count > 0)
                {
                    ddlArticle.DataSource = row.ToList();
                    // ddlArticle.DataTextField = "Article";
                    // ddlArticle.DataValueField = "Article";
                    ddlArticle.DataBind();
                    ddlArticle.AppendDataBoundItems = false;
                    ddlArticle.Items.Insert(0, new ListItem("--Select Item Category--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillSupplierName()
        {
            try
            {
                var row = _orderSheetbll.GetSupplierList();
                if (row.Count > 0)
                {
                    ddlSupplier.DataSource = row.ToList();
                    ddlSupplier.DataTextField = "SupplierName";
                    ddlSupplier.DataValueField = "SupplierCode";
                    ddlSupplier.DataBind();
                    ddlSupplier.AppendDataBoundItems = false;
                    ddlSupplier.Items.Insert(0, new ListItem("--Select Supplier--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillItemName()
        {
            try
            {
                var row = groupBll.GetAllGroup();
                if (row.Count > 0)
                {
                    drpItemCategory.DataSource = row.ToList();
                    drpItemCategory.DataTextField = "GroupName";
                    drpItemCategory.DataValueField = "GroupId";
                    drpItemCategory.DataBind();
                    drpItemCategory.AppendDataBoundItems = false;
                    drpItemCategory.Items.Insert(0, new ListItem("--Select Item Category--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

       public void LoadGrid(string article)
        {
            var result = _orderSheetbll.GetLCOrderPlanning(article);
            if (result.Count > 0)
            {
                var mn = result.First();
                gridOrderPlanning.DataSource = result;
                gridOrderPlanning.DataBind();
                //txtStyle.Text = mn.Style;

            }
            else
            {
                gridOrderPlanning.DataSource = null;
                gridOrderPlanning.DataBind();
            }
        }
        protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerChkBox = ((CheckBox)grvOrderSheetEntry.HeaderRow.FindControl("headerLevelCheckBox"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grvOrderSheetEntry.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grvOrderSheetEntry.Rows)
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

        protected void drpItemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillProductName();
        }
        public void FillProductName()
        {
            if (Convert.ToInt32(drpItemCategory.SelectedValue) > 0)
            {
                List<ERPSSL.LC.DAL.Inv_BuyCentral> ItemList = _orderSheetbll.GetItemListInvBuyCentral(Convert.ToInt32(drpItemCategory.SelectedValue));
                if (ItemList.Count > 0)
                {
                    grvOrderSheetEntry.DataSource = ItemList;
                    grvOrderSheetEntry.DataBind();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found')", true);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                LC_BackToBack LcBack = new LC_BackToBack();
                List<LC_BackToBack_Temp> _LC_BackToBack = new List<LC_BackToBack_Temp>();
                if (txtPIDate.Text == "")
                { 
                 ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Input PI Date !')", true);
                 return;              
                
                }
                if (txtBBLCDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Input BBLC Date !')", true);
                    return;

                }


                foreach (GridViewRow gvRow in grvOrderSheetEntry.Rows)
                {
                    CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                    LC_BackToBack_Temp _orderPlanning = new LC_BackToBack_Temp();

                    if (rowChkBox.Checked == true)
                    {
                        Label lblProductId = ((Label)gvRow.FindControl("lblProductId"));
                        Label lblCpu = ((Label)gvRow.FindControl("lblCpu"));
                        Label lblBalanceQty = ((Label)gvRow.FindControl("lblBalanceQty"));
                        Label lblProductName = ((Label)gvRow.FindControl("lblProductName"));
                        Label lblUnitName = ((Label)gvRow.FindControl("lblUnitName"));
                        Label lblStyleSize = ((Label)gvRow.FindControl("lblStyleSize"));
                        Label lblBrand = ((Label)gvRow.FindControl("lblBrand"));
                        TextBox txtQty = ((TextBox)gvRow.FindControl("txtQty"));
                        TextBox txtUSDRate = ((TextBox)gvRow.FindControl("txtUSDRate"));
                       // TextBox txtBDTRate = ((TextBox)gvRow.FindControl("txtBDTRate"));
                        Label lblValue = ((Label)gvRow.FindControl("lblValue"));
                       // Label lblBDTValue = ((Label)gvRow.FindControl("lblBDTValue"));
                        if (txtUSDRate.Text == "")
                        {
                            _orderPlanning.USDRate = 0;
                        }
                        else
                        {
                            _orderPlanning.USDRate = Convert.ToDecimal(txtUSDRate.Text.ToString());
                            _orderPlanning.USDValue = Convert.ToDecimal(lblValue.Text.ToString());
                        }
                        //if (txtBDTRate.Text == "")
                        //{
                        //    _orderPlanning.BDTRate = 0;
                        //    _orderPlanning.BDTValue = 0;
                        //}
                        //else
                        //{
                        //    _orderPlanning.BDTRate = Convert.ToDecimal(txtBDTRate.Text.ToString());
                        //    _orderPlanning.BDTValue = Convert.ToDecimal(lblBDTValue.Text.ToString());
                        //}


                        if (txtQty.Text == "")
                        {
                            _orderPlanning.ReqQty = 0;
                        }
                        else
                        {
                            _orderPlanning.ReqQty = Convert.ToDouble(txtQty.Text.ToString());
                        }
                        if (lblCpu.Text == "")
                        {
                            _orderPlanning.CPU = 0;
                        }
                        else
                        {
                            _orderPlanning.CPU = Convert.ToDecimal(lblCpu.Text.ToString());
                        }
                        if (rdbForeign.Checked == true)
                        {
                            _orderPlanning.BayerType = rdbForeign.Text;
                        }
                        else
                        {
                            _orderPlanning.BayerType = rdbLocal.Text;
                        }
                        _orderPlanning.BBLCDate = Convert.ToDateTime(txtBBLCDate.Text);
                        _orderPlanning.ExpireDate = Convert.ToDateTime(txtExpireDate.Text);
                        _orderPlanning.BBLCAutoId = txtAutoChallanId.Text;
                        _orderPlanning.BBLCShipmentDate = Convert.ToDateTime(txtBBLCDate.Text);
                        _orderPlanning.SightDaysInterest = txtSigntDayInterest.Text;
                        _orderPlanning.ProductId = Convert.ToInt32(lblProductId.Text.ToString());
                        _orderPlanning.Barcode = lblProductId.Text.ToString();
                        _orderPlanning.ProductName = lblProductName.Text.ToString();
                        _orderPlanning.Brand = lblBrand.Text.ToString();
                        _orderPlanning.StyleSize = lblStyleSize.Text.ToString();
                        _orderPlanning.Unit = lblUnitName.Text.ToString();
                        _orderPlanning.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                        _orderPlanning.EditDate = DateTime.Now;
                        _orderPlanning.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                        _orderPlanning.Season = ddlSeason.SelectedItem.Text;
                        _orderPlanning.POOrderNo = ddlPoOrder.SelectedItem.Text;
                        _orderPlanning.Style = ddlStyle.SelectedItem.Text;
                        _orderPlanning.Article = ddlArticle.SelectedItem.Text;                        
                        _orderPlanning.MasterLC = txtMasterLC.Text;
                        _orderPlanning.B2BLCNo = txtB2BLCNo.Text;
                        _orderPlanning.PI = txtPI.Text;
                        _orderPlanning.PIDate = Convert.ToDateTime(txtPIDate.Text);
                        _orderPlanning.ProductGroupId = Convert.ToInt32(drpItemCategory.SelectedValue);
                        _orderPlanning.SupplierId = ddlSupplier.SelectedValue.ToString();
                        _LC_BackToBack.Add(_orderPlanning);
                    }
                }

                if (_LC_BackToBack.Count > 0)
                {
                   
                    int result = _orderSheetbll.InsertBackToBack(_LC_BackToBack);
                    if (result == 1)
                    {
                        Clear();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                        GridBackTobBackLoad();
                        
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Employee selected in the list!')", true);
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public void GridBackTobBackLoad()
        {
            var result = _orderSheetbll.GetBackToBack(ddlPoOrder.SelectedItem.Text.ToString());
            if (result.Count > 0)
            {
                GridBackToBack.DataSource = result;
                GridBackToBack.DataBind();

            }
            else
            {

                GridBackToBack.DataSource = null;
                GridBackToBack.DataBind();
            }

        }
        public void Clear()
        {
            drpItemCategory.ClearSelection();
            grvOrderSheetEntry.DataSource = null;          
            grvOrderSheetEntry.DataBind();
           
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

        protected void txtBDTRate_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
            TextBox textqty = (TextBox)gvRow.FindControl("txtQty");
            Label lblTotalRs = (Label)gvRow.FindControl("lblBDTValue");
            if (textqty.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Request Qty')", true);
                return;
            }
            try
            {
                lblTotalRs.Text = ((Convert.ToDecimal(txt.Text)) * (Convert.ToDecimal(textqty.Text))).ToString();
            }
            catch { lblTotalRs.Text = "0"; txt.Text = "0"; }
        }

        protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            string supplierid = ddlSupplier.SelectedValue.ToString();
            DateTime day = DateTime.Today;
            txtAutoChallanId.Text = _orderSheetbll.GetNewChalanNo("BBLC-", day, supplierid);

        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            int result = _orderSheetbll.TransferBackToBack(txtAutoChallanId.Text.ToString());
            if (result == 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Post Successfully !')", true);
                ClearFrom();
            }
        }
        public void ClearFrom()
        {

            ddlPoOrder.ClearSelection(); ;
            drpItemCategory.ClearSelection();
            GridBackToBack.DataSource = null;
            ddlSupplier.ClearSelection();
            GridBackToBack.DataBind();
            txtMasterLC.Text = "";
            txtPI.Text = "";
            ddlSeason.ClearSelection();
            txtB2BLCNo.Text = "";
            ddlArticle.ClearSelection();
            txtPIDate.Text = "";
           // ddlStyle.ClearSelection();
            txtSigntDayInterest.Text = "";
            txtAutoChallanId.Text = "";
            txtBBLCDate.Text = "";

        }
        protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime day = DateTime.Today;
           // txtAutoOrderId.Text = _orderSheetbll.GetNewChalanNo("OPLC-", day, ddlSeason.Text.ToString());
            FillPoOrder(ddlSeason.SelectedItem.Text);

            //var result = _orderSheetbll.GetOrderEntry_Season(ddlSeason.SelectedItem.Text);
            //if (result.Count > 0)
            //{
            //    grdRequisition.DataSource = result;
            //    grdRequisition.DataBind();
            //}
        }



        protected void ddlPoOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillArticle(ddlPoOrder.SelectedItem.Text);
        }

        protected void ddlArticle_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillStyle(ddlArticle.SelectedItem.Text);
            LoadGrid(ddlArticle.SelectedItem.Text);
        }

       
    }
}