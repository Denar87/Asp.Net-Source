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

namespace ERPSSL.BuyingHouse
{
    public partial class OrderList : System.Web.UI.Page
    {
        OrderSheetBLL _orderSheetbll = new OrderSheetBLL();
        GroupBLL groupBll = new GroupBLL();
        ProductBLL productBll = new ProductBLL();
        MasterLCBLL masterBLL = new MasterLCBLL();

        private ERPSSL.LC.DAL.ERPSSL_LCEntities _Context = new ERPSSL.LC.DAL.ERPSSL_LCEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {

                    FillSeason();
                    FillStyle();
                    //txtOrderReceivedDate.Text = Convert.ToString(DateTime.Now);
                    LoadGrid();
                   // orderEdit.Visible = false;
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        private void LoadGrid()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            //var result = masterBLL.GetAllOrderByOcode(ocode);
            var result = masterBLL.LoadLCOrderGrid(ocode);
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
            //try
            //{
            //    string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            //    List<LC_Style> row = _orderSheetbll.GetLC_Style(ocode);


            //    if (row != null)
            //    {
            //        ddlStyle.DataSource = row.ToList();
            //        ddlStyle.DataTextField = "StyleName";
            //        ddlStyle.DataValueField = "StyleId";
            //        ddlStyle.DataBind();
            //        ddlStyle.AppendDataBoundItems = false;
            //        ddlStyle.Items.Insert(0, new ListItem("--Select Style--", "0"));

            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }


        private void FillSeason()
        {
            //try
            //{
            //    string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            //    List<Rep_MasterLC> row = _orderSheetbll.GetOrderByDistrinct(ocode);

            //    if (row != null)
            //    {
            //        ddlSeason.DataSource = row.ToList();
            //        ddlSeason.DataTextField = "SeasonName";
            //        ddlSeason.DataValueField = "MlcID";
            //        ddlSeason.DataBind();
            //        ddlSeason.AppendDataBoundItems = false;
            //        ddlSeason.Items.Insert(0, new ListItem("--Select Season--", "0"));

            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                //LC_OrderEntry orderEntry = new LC_OrderEntry();

                //string seasonname = ddlSeason.SelectedItem.ToString();
                //string[] values = seasonname.Split('-');
                //orderEntry.OrderReceiveDate = Convert.ToDateTime(txtOrderReceivedDate.Text);
                //orderEntry.Season = values[0].ToString();
                //orderEntry.Buyer_Department = txtBuyerDepartment.Text;
                //orderEntry.Supplier_No = txtSupplierNo.Text;
                //orderEntry.OrderNo = txtOrder.Text;
                //orderEntry.LCNo = hidLcNo.Value;
                //orderEntry.Article = txtArticle.Text;
                //orderEntry.ColorSpecification = txtColor.Text;
                //orderEntry.OrderQuantity = txtOrderQty.Text;
                //orderEntry.FobQty = Convert.ToDouble(txtFob.Text);
                //orderEntry.Style = ddlStyle.SelectedItem.Text;

                //if (chkNewstyle.Checked == true)
                //{
                //    orderEntry.Style = txtStyle.Text;
                //}
                //else
                //{
                //  orderEntry.Style = ddlStyle.SelectedItem.Text;
                //}
                //orderEntry.Size = txtsize.Text;
                //orderEntry.Comments = txtComments.Text;
                //orderEntry.ShipmentDate = Convert.ToDateTime(txtDate.Text);
                //orderEntry.Create_Date = DateTime.Today;
                //orderEntry.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                //orderEntry.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //orderEntry.TotalQty = Convert.ToDouble(txtValue.Text);

                //if (btnSubmit.Text == "Add")
                //{
                //    var result = masterBLL.InsertOrderEntry(orderEntry);
                //    if (result == 1)
                //    {
                //        lblMessage.Text = "Data Saved Successfully";
                //        txtBuyerDepartment.Focus();
                //        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);



                //    }
                //}

                //else
                //{
                //int orderid = Convert.ToInt32(hidorderid.Value);
                //var result = masterBLL.UpdateOrderEntry(orderEntry, orderid);
                //if (result == 1)
                //{
                //    lblMessageUpdate.Text = "Data Update Successfully";
                //    //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);

                //}
                ////}

                //// LoadGrid(lblLCNo.Text.ToString());
                //orderEdit.Visible = false;
                //Clear();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void Clear()
        {
            //ddlStyle.ClearSelection();
            ////ddlSeason.ClearSelection();
            //txtDate.Text = "";
            //txtColor.Text = "";
            //txtArticle.Text = "";
            //txtFob.Text = "0";
            //txtOrder.Text = "";
            //txtOrderQty.Text = "0";
            //txtValue.Text = "";
            ////txtStyle.Text = "";
            //txtsize.Text = "";
            //txtComments.Text = "";
            // txtSupplierNo.Text = "";
            // txtOrderReceivedDate.Text = "";
            //txtBuyerDepartment.Text = "";



        }



        protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime day = DateTime.Today;
            //txtAutoOrderId.Text = _orderSheetbll.GetNewChalanNo("OPLC-", day, ddlSeason.Text.ToString());
            //FillStyle(ddlSeason.SelectedItem.Text);
            //int id = Convert.ToInt32(ddlSeason.SelectedValue);

            //List<Rep_MasterLC> result = _orderSheetbll.GetLC_MasterLC(id);
            //if (result.Count > 0)
            //{
                //var mm = result.First();
                //lblBayername.Text = mm.BayerName.ToString();
                //lblLCNo.Text = mm.LCNo.ToString();
                //grdRequisition.DataSource = result;
                //grdRequisition.DataBind();

            //}
            //LoadGrid(lblLCNo.Text.ToString());
        }

        protected void txtFob_TextChanged(object sender, EventArgs e)
        {
            //double qty = Convert.ToDouble(txtOrderQty.Text);
            //double fob = Convert.ToDouble(txtFob.Text);
            //double totalvalue = qty * fob;
            //txtValue.Text = totalvalue.ToString();
        }

        //protected void chkNewstyle_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (chkNewstyle.Checked == true)
        //    {
        //        ddlStyle.Visible = false;
        //        txtStyle.Visible = true;
        //    }
        //    else
        //    {
        //        ddlStyle.Visible = true;
        //        txtStyle.Visible = false;
        //    }
        //}

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


                Label lblOrder_No = (Label)grdorder.Rows[row.RowIndex].FindControl("lblOrder_No");

                Session["alblOrder_No"] = lblOrder_No.Text;
                Response.Redirect("OnGoingOrderUpdate.aspx");
            }
            catch (Exception ex)
            {

                throw;
            }
        }



    }
}