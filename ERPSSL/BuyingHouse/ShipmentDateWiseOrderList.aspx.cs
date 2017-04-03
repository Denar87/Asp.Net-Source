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
    public partial class ShipmentDateWiseOrderList : System.Web.UI.Page
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
                  
                    LoadGrid();
                  
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
            List<RLc> result = masterBLL.GetAllOrderByShipmentDate(ocode).ToList();
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
           
        }


        private void FillSeason()
        {
            
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
           

        }
        public void Clear()
        {
           
            // txtSupplierNo.Text = "";
            // txtOrderReceivedDate.Text = "";
            //txtBuyerDepartment.Text = "";



        }



        protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        protected void txtFob_TextChanged(object sender, EventArgs e)
        {
           
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