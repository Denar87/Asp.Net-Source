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
    public partial class OrderPlanning : System.Web.UI.Page
    {
        ERPSSL.LC.BLL.OrderSheetBLL _orderSheetbll = new ERPSSL.LC.BLL.OrderSheetBLL();
        GroupBLL groupBll = new GroupBLL();
        ProductBLL productBll = new ProductBLL();

        private ERPSSL.LC.DAL.ERPSSL_LCEntities _Context = new ERPSSL.LC.DAL.ERPSSL_LCEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    FillItemName();
                    //FillSeason();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        //string OCODE = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

        private void FillItemName()
        {
            try
            {
                var row = groupBll.GetAllGroup();
                if (row.Count > 0)
                {
                    ddlItemCategory.DataSource = row.ToList();
                    ddlItemCategory.DataTextField = "GroupName";
                    ddlItemCategory.DataValueField = "GroupId";
                    ddlItemCategory.DataBind();
                    ddlItemCategory.AppendDataBoundItems = false;
                    ddlItemCategory.Items.Insert(0, new ListItem("--Select Item Category--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //private void FillSeason()
        //{
        //    try
        //    {
        //        string ocode = ((SessionUser)Session["SessionUser"]).OCode;
        //        List<string> row = _orderSheetbll.GetOrderEntryByDistrinct(ocode);
        //        if (row != null)
        //        {
        //            ddlSeason.DataSource = row.ToList();
        //            //ddlSeason.DataTextField = "Season";
        //            // ddlSeason.DataValueField = "Season";
        //            ddlSeason.DataBind();
        //            ddlSeason.AppendDataBoundItems = false;
        //            ddlSeason.Items.Insert(0, new ListItem("--Select Item Category--", "0"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

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

        protected void ddlItemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillProductName();
        }
        public void FillProductName()
        {
            if (Convert.ToInt32(ddlItemCategory.SelectedValue) > 0)
            {
                List<ERPSSL.LC.DAL.Inv_BuyCentral> ItemList = _orderSheetbll.GetItemListInvBuyCentral(Convert.ToInt32(ddlItemCategory.SelectedValue));
                if (ItemList.Count > 0)
                {
                    grvOrderSheetEntry.DataSource = ItemList;
                    grvOrderSheetEntry.DataBind();
                }
            }
        }

        //protected void txtSeason_TextChanged(object sender, EventArgs e)
        //{
        //    var result = _orderSheetbll.GetOrderEntry(txtSeason.Text);
        //    if (result.Count > 0)
        //    {
        //        grdRequisition.DataSource = result;
        //        grdRequisition.DataBind();
        //    }

        //}


        //protected void grdRequisition_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        if (e.CommandName == "OrderNo")
        //        {

        //            string id = Convert.ToString(e.CommandArgument);
        //            //LinkButton imgbtn = (LinkButton)sender;
        //            //GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
        //            //Label orderNo = (Label)grdRequisition.Rows[row.RowIndex].FindControl("lblOrderNo");
        //           // txtPOOrder.Text = id.ToString();
        //            var result = _orderSheetbll.GetLCOrderPlanning(id);
        //            if (result.Count > 0)
        //            {
        //                var mn = result.First();
        //                GridStyle.DataSource = result;
        //                GridStyle.DataBind();


        //            }
        //            else
        //            {
        //                GridStyle.DataSource = null;
        //                GridStyle.DataBind();
        //            }


        //        }

        //    }
        //    catch { }
        //}

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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                LC_Order_Planning_Temp orderPlanning = new LC_Order_Planning_Temp();
                List<LC_Order_Planning_Temp> _LC_Order_Planning = new List<LC_Order_Planning_Temp>();
               
                foreach (GridViewRow gvRow in grvOrderSheetEntry.Rows)
                {
                    CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                    LC_Order_Planning_Temp _orderPlanning = new LC_Order_Planning_Temp();

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
                        //TextBox txtBDTRate = ((TextBox)gvRow.FindControl("txtBDTRate"));
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
                            _orderPlanning.Qty = 0;
                        }
                        else
                        {
                            _orderPlanning.Qty = Convert.ToDouble(txtQty.Text.ToString());
                        }
                        if (lblCpu.Text == "")
                        {
                            _orderPlanning.CPU = 0;
                        }
                        else
                        {
                            _orderPlanning.CPU = Convert.ToDecimal(lblCpu.Text.ToString());
                        }
                        if (lblCpu.Text != "" && txtQty.Text != "")
                        {
                            _orderPlanning.TotalQty = Convert.ToDecimal(txtQty.Text.ToString()) * Convert.ToDecimal(lblCpu.Text.ToString());
                        }
                        else
                        {
                            _orderPlanning.TotalQty = 0;
                        }
                        _orderPlanning.OrderPlanningAutoId = txtAutoOrderId.Text;
                        _orderPlanning.ProductId = Convert.ToInt32(lblProductId.Text.ToString());
                        _orderPlanning.BarCode = lblProductId.Text.ToString();
                        _orderPlanning.ProductName = lblProductName.Text.ToString();
                        _orderPlanning.Brand = lblBrand.Text.ToString();
                        _orderPlanning.StyleSize = lblStyleSize.Text.ToString();
                        _orderPlanning.UnitName = lblUnitName.Text.ToString();
                        _orderPlanning.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                        _orderPlanning.EditDate = DateTime.Now;
                        _orderPlanning.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                        _orderPlanning.Season = ddlSeason.SelectedItem.Text;
                        _orderPlanning.OrderNo = ddlPoOrder.SelectedItem.Text;
                        _orderPlanning.Style = ddlStyle.SelectedItem.Text;
                        _orderPlanning.Article = ddlArticle.SelectedItem.Text;

                        _LC_Order_Planning.Add(_orderPlanning);
                    }
                }

                if (_LC_Order_Planning.Count > 0)
                {
                    //string type = drpEntryType.SelectedValue.ToString();
                    int result = _orderSheetbll.UpdateLCOrderPlanning(_LC_Order_Planning);
                    if (result == 1)
                    {
                        Clear();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                        var result1 = _orderSheetbll.GetLCOrderPlanningTemp(ddlSeason.SelectedItem.Text.ToString());
                        if (result1.Count > 0)
                        {
                            gridOrderPlanning.DataSource = result1;
                            gridOrderPlanning.DataBind();

                        }
                        else
                        {
                            gridOrderPlanning.DataSource = null;
                            gridOrderPlanning.DataBind();
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Employee selected in the list!')", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void Clear()
        {

            // txtStyle.Text = "";
            ddlItemCategory.ClearSelection();
            grvOrderSheetEntry.DataSource = null;
            grvOrderSheetEntry.DataBind();



        }

        protected void gridOrderPlanning_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = gridOrderPlanning.Rows[e.RowIndex];
            Label lblOrderPlanningId = (Label)row.FindControl("lblOrderPlanningId");
            int id = Convert.ToInt16(lblOrderPlanningId.Text);
            _orderSheetbll.DeleteLOrderPlanningTempById(id);
            var result1 = _orderSheetbll.GetLCOrderPlanningTemp(ddlSeason.SelectedItem.Text.ToString());
            if (result1.Count > 0)
            {
                gridOrderPlanning.DataSource = result1;
                gridOrderPlanning.DataBind();

            }
            else
            {
                gridOrderPlanning.DataSource = null;
                gridOrderPlanning.DataBind();
            }
        }


        protected void btnPost_Click(object sender, EventArgs e)
        {
            int result = _orderSheetbll.TransferOrderplanning(txtAutoOrderId.Text.ToString());
            if (result == 1)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Post Successfully !')", true);
                ClearFrom();
            }
        }

        public void ClearFrom()
        {

            gridOrderPlanning.DataSource = null;
            gridOrderPlanning.DataBind();
            GridViewOrder.DataSource = null;
            GridViewOrder.DataBind();
            ddlArticle.ClearSelection();
            ddlSeason.ClearSelection();
            ddlStyle.ClearSelection();
            ddlPoOrder.ClearSelection();
            ddlItemCategory.ClearSelection();

        }

        //protected void GridStyle_RowCommand(object sender, GridViewCommandEventArgs e)
        //{
        //    try
        //    {
        //        if (e.CommandName == "Style")
        //        {

        //            string id = Convert.ToString(e.CommandArgument);
        //            //LinkButton imgbtn = (LinkButton)sender;
        //            //GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
        //            //Label orderNo = (Label)grdRequisition.Rows[row.RowIndex].FindControl("lblOrderNo");                  
        //            var result = _orderSheetbll.GetLCOrderPlanningStyleWise(id);
        //            if (result.Count > 0)
        //            {
        //                var mn = result.First();
        //                GridViewOrder.DataSource = result;
        //                GridViewOrder.DataBind();


        //            }
        //            else
        //            {
        //                GridViewOrder.DataSource = null;
        //                GridViewOrder.DataBind();
        //            }


        //        }

        //    }
        //    catch { }
        //}
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

        //protected void txtBDTRate_TextChanged(object sender, EventArgs e)
        //{
        //    TextBox txt = (TextBox)sender;
        //    GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
        //    TextBox textqty = (TextBox)gvRow.FindControl("txtQty");
        //    Label lblTotalRs = (Label)gvRow.FindControl("lblBDTValue");
        //    if (textqty.Text == "")
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Request Qty')", true);
        //        return;
        //    }
        //    try
        //    {
        //        lblTotalRs.Text = ((Convert.ToDecimal(txt.Text)) * (Convert.ToDecimal(textqty.Text))).ToString();
        //    }
        //    catch { lblTotalRs.Text = "0"; txt.Text = "0"; }
        //}

        protected void GridViewOrder_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridViewOrder.Rows[e.RowIndex];
            Label lblOrderPlanningId = (Label)row.FindControl("lblOrderPlanningId");
            int id = Convert.ToInt16(lblOrderPlanningId.Text);
            _orderSheetbll.DeleteLOrderPlanningById(id);
            var result1 = _orderSheetbll.GetLCOrderPlanningByStyle(ddlStyle.Text.ToString());
            if (result1.Count > 0)
            {
                GridViewOrder.DataSource = result1;
                GridViewOrder.DataBind();

            }
            else
            {
                GridViewOrder.DataSource = null;
                GridViewOrder.DataBind();
            }
        }

        protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime day = DateTime.Today;
            txtAutoOrderId.Text = _orderSheetbll.GetNewChalanNo("OPLC-", day, ddlSeason.Text.ToString());
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
        }


      
    }
}