using ERPSSL.INV.BLL;
using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL;
using ERPSSL.LC.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.LC
{
    public partial class OrderSheet : System.Web.UI.Page
    {
        OrderSheetBLL _orderSheetbll = new OrderSheetBLL();
        GroupBLL groupBll = new GroupBLL();
        ProductBLL productBll = new ProductBLL();
        MasterLCBLL masterBLL = new MasterLCBLL();
        BuyerBLL _Buyerbll = new BuyerBLL();

        private ERPSSL.LC.DAL.ERPSSL_LCEntities _Context = new ERPSSL.LC.DAL.ERPSSL_LCEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    //FillSeason();
                    FillStyle();
                    txtOrderReceivedDate.Text = Convert.ToString(DateTime.Now);
                    //LoadGrid();
                    LoadSeason();
                    ShowInfo.Visible = false;
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void LoadGrid(string LCNo)
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            var result = masterBLL.GetAllOrder(ocode, LCNo);
            if (result.Count > 0)
            {
                grdorder.DataSource = result.ToList();
                grdorder.DataBind();
            }
            else
            {
                grdorder.DataSource = null;
                grdorder.DataBind();
            }
        }

        private void FillStyle()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_Style> row = _orderSheetbll.GetLC_Style(ocode);

                if (row != null)
                {
                    ddlStyle.DataSource = row.ToList();
                    ddlStyle.DataTextField = "StyleName";
                    ddlStyle.DataValueField = "StyleId";
                    ddlStyle.DataBind();
                    ddlStyle.AppendDataBoundItems = false;
                    ddlStyle.Items.Insert(0, new ListItem("--Select Style--", "0"));
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
        //        List<Rep_MasterLC> row = _orderSheetbll.GetOrderByDistrinct(ocode);

        //        if (row != null)
        //        {
        //            ddlSeason.DataSource = row.ToList();
        //            ddlSeason.DataTextField = "SeasonName";
        //            ddlSeason.DataValueField = "MlcID";
        //            ddlSeason.DataBind();
        //            ddlSeason.AppendDataBoundItems = false;
        //            ddlSeason.Items.Insert(0, new ListItem("--Select Season--", "0"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private void LoadSeason()
        {
            try
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<LC_Season> _Seasonlist = masterBLL.GetSeasonList(OCode);

                if (_Seasonlist.Count > 0)
                {
                    ddlSeason.DataSource = _Seasonlist.ToList();
                    ddlSeason.DataTextField = "Season_Name";
                    ddlSeason.DataValueField = "Season_Id";
                    ddlSeason.DataBind();
                    ddlSeason.Items.Insert(0, new ListItem("---Select One---"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                int StyleId = 0;
                if (ddlStyle.SelectedItem.Text == "--Select Style--" && txtStyle.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Style')", true);
                    return;
                }
                if (chkNewstyle.Checked == true)
                {

                    LC_Style aLC_Style = new LC_Style();

                    aLC_Style.StyleName = txtStyle.Text;
                    aLC_Style.CreateDate = DateTime.Today;
                    aLC_Style.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                    aLC_Style.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                    var result = _Buyerbll.AddStyle(aLC_Style);
                    StyleId = result;
                }

                int SesonId = 0;
                if (ddlSeason.SelectedItem.Text == "---Select One---" && txtSeason.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Season')", true);
                    return;
                }
                if (chkSeason.Checked == true)
                {
                    LC_Season _LC_Season = new LC_Season();
                    _LC_Season.Season_Name = txtSeason.Text;
                    _LC_Season.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                    _LC_Season.CreateDate = DateTime.Now;
                    _LC_Season.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                    int result = masterBLL.SaveLC_Season(_LC_Season);
                    SesonId = result;
                }

                LC_OrderEntry orderEntry = new LC_OrderEntry();

                //string seasonname = ddlSeason.SelectedItem.ToString();
                //string[] values = seasonname.Split('-');
                orderEntry.OrderReceiveDate = Convert.ToDateTime(txtOrderReceivedDate.Text);
                //orderEntry.Season = values[0].ToString();
                orderEntry.Buyer_Department = txtBuyerDepartment.Text;
                orderEntry.Supplier_No = txtSupplierNo.Text;
                orderEntry.OrderNo = txtOrder.Text;
                orderEntry.LCNo = lblLCNo.Text;
                orderEntry.Article = txtArticle.Text;
                orderEntry.ColorSpecification = txtColor.Text;
                orderEntry.OrderQuantity = txtOrderQty.Text;
                orderEntry.FobQty = Convert.ToDouble(txtFob.Text);

                if (chkNewstyle.Checked == true)
                {
                    orderEntry.StyleId = StyleId;
                }
                else
                {
                    orderEntry.StyleId = Convert.ToInt32(ddlStyle.SelectedValue);
                }

                if (chkSeason.Checked == true)
                {
                    orderEntry.SeasonId = SesonId;
                }
                else
                {
                    orderEntry.SeasonId = Convert.ToInt32(ddlSeason.SelectedValue);
                }

                orderEntry.Size = txtsize.Text;
                orderEntry.Shipment_Mode = ddlShipmentMode.SelectedValue;
                orderEntry.ShipmentDate = Convert.ToDateTime(txtDate.Text);

                orderEntry.FiberContent1 = txtFiberContent1.Text;
                orderEntry.FiberContent2 = txtFiberContent2.Text;

                orderEntry.Create_Date = DateTime.Today;
                orderEntry.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                orderEntry.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                orderEntry.TotalQty = Convert.ToDouble(txtValue.Text);

                if (btnSubmit.Text == "Add")
                {
                    var result = masterBLL.InsertOrderEntry(orderEntry);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                    }
                }

                else
                {
                    int orderid = Convert.ToInt32(hidorderid.Value);
                    var result = masterBLL.UpdateOrderEntry(orderEntry, orderid);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                    }
                }

                LoadGrid(lblLCNo.Text.ToString());
                Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Clear()
        {
            ddlStyle.ClearSelection();
            ddlSeason.ClearSelection();
            txtSeason.Text = "";
            txtDate.Text = "";
            txtColor.Text = "";
            txtArticle.Text = "";
            txtFob.Text = "0";
            ddlShipmentMode.ClearSelection();
            txtBuyerDepartment.Text = "";
            txtSupplierNo.Text = "";
            txtSpecification.Text = "";
            txtFiberContent1.Text = "";
            txtFiberContent2.Text = "";
            txtOrder.Text = "";
            txtOrderQty.Text = "0";
            txtValue.Text = "";
            txtStyle.Text = "";
            txtsize.Text = "";
            // txtSupplierNo.Text = "";
            // txtOrderReceivedDate.Text = "";
            //txtBuyerDepartment.Text = "";
        }

        protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DateTime day = DateTime.Today;
            //int id = Convert.ToInt32(ddlSeason.SelectedValue);

            //List<Rep_MasterLC> result = _orderSheetbll.GetLC_MasterLC(id);
            //if (result.Count > 0)
            //{
            //    ShowInfo.Visible = true;
            //    lblTotal.Visible = true;
            //    showDiv.Visible = true;
            //    var mm = result.First();
            //    lblBayername.Text = mm.BayerName.ToString();
            //    lblLCNo.Text = mm.LCNo.ToString();
            //    lblLCQty.Text = mm.Qty.ToString();
            //    lblUSDValue.Text = mm.LC_USDValu.ToString();
            //    lblBDTValue.Text = mm.LC_BDTValu.ToString();
            //}
            //LoadGrid(lblLCNo.Text.ToString());
        }

        protected void txtFob_TextChanged(object sender, EventArgs e)
        {
            double qty = Convert.ToDouble(txtOrderQty.Text);
            double fob = Convert.ToDouble(txtFob.Text);
            double totalvalue = qty * fob;
            txtValue.Text = totalvalue.ToString();
        }

        protected void chkNewstyle_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNewstyle.Checked == true)
            {
                ddlStyle.Visible = false;
                txtStyle.Visible = true;
            }
            else
            {
                ddlStyle.Visible = true;
                txtStyle.Visible = false;
            }
        }

        //protected void grdorder_PageIndexChanging(object sender, GridViewPageEventArgs e)
        //{
        //    grdorder.PageIndex = e.NewPageIndex;
        //    LoadGrid(lblLCNo.Text.ToString());
        //}

        protected void imgbtnOrderSheetEdit_Click(object sender, ImageClickEventArgs e)
        {
            List<LC_OrderEntry> orders = new List<LC_OrderEntry>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string orderId = "";
                Label lblOrderEntryID = (Label)grdorder.Rows[row.RowIndex].FindControl("lblOrderEntryID");
                if (lblOrderEntryID != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    orderId = lblOrderEntryID.Text;

                    orders = masterBLL.GetOrderByOrderIdandOcode(orderId, OCODE);

                    if (orders.Count > 0)
                    {
                        foreach (LC_OrderEntry order in orders)
                        {
                            hidorderid.Value = order.OrderEntryID.ToString();
                            //ddlSeason.SelectedValue = order.Season.ToString();                          
                            txtOrder.Text = order.OrderNo;
                            txtArticle.Text = order.Article;
                            txtColor.Text = order.ColorSpecification;
                            ddlStyle.SelectedItem.Text = order.Style;
                            txtOrderQty.Text = order.OrderQuantity;
                            txtFob.Text = Convert.ToString(order.FobQty);
                            txtDate.Text = Convert.ToString(order.ShipmentDate);
                            txtValue.Text = Convert.ToString(order.TotalQty);
                            LoadSeason();
                            ddlSeason.SelectedValue = order.SeasonId.ToString();
                            txtsize.Text = order.Size;
                            txtSupplierNo.Text = order.Supplier_No;
                            txtOrderReceivedDate.Text = Convert.ToString(order.OrderReceiveDate);
                            txtBuyerDepartment.Text = order.Buyer_Department;
                            //hidRegionName.Value = txtbxRegionName.Text = region.RegionName;
                            //txtbxResgionCode.Text = region.RegionCode;
                            if (btnSubmit.Text == "Add")
                            {
                                btnSubmit.Text = "Update";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        decimal sumFooterValue = 0;
        decimal sumFooterQty = 0;
        protected void grdorder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string totalAmount = e.Row.Cells[8].Text;
                    decimal grandTotal = Convert.ToDecimal(totalAmount);
                    sumFooterValue += grandTotal;
                }
                lblTotalCost.Text = sumFooterValue.ToString();
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string totalQty = e.Row.Cells[7].Text;
                    decimal grandTotal = Convert.ToDecimal(totalQty);
                    sumFooterQty += grandTotal;
                }
                lblQty.Text = sumFooterQty.ToString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void chkSeason_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeason.Checked == true)
            {
                txtSeason.Visible = true;
                ddlSeason.Visible = false;
            }
            else
            {
                txtSeason.Visible = false;
                ddlSeason.Visible = true;
            }
        }
    }
}