using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL;
using ERPSSL.LC.DAL.Repository;

namespace ERPSSL.BuyingHouse
{
    public partial class ShipmentSchedule : System.Web.UI.Page
    {
        ShipmentSheduleBLL shipmentBll = new ShipmentSheduleBLL();
        OrderSheetBLL _orderSheetbll = new OrderSheetBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    //GetOrderList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
           
        }
        private void GetOrderList()
        {
            try
            {
                string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<LC_OrderEntry> BuyerList = shipmentBll.GetOrderList(Ocode);
                if (BuyerList.Count > 0)
                {
                    grdShipment.DataSource = BuyerList;
                    grdShipment.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void txtOrder_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ShowShipmentGrid();
                GetSeasonByOrderNo();
                btnSubmit.Visible = true;

                //string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                //var row = shipmentBll.getShipmentMode(OCode);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        private void GetSeasonByOrderNo()
        {
            try
            {
                string orderNo = txtOrder.Text;
                List<Rep_MasterLC> _Season = new List<Rep_MasterLC>();
                _Season = shipmentBll.GetseasonName(orderNo);
                if (_Season.Count>0)
                {
                    var row = _Season.FirstOrDefault();
                    txtBuyer.Text = row.BayerName;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchLCNo(string prefixText, int count)
        {
            using (var _context = new ERPSSL_LCEntities())
            {
                var AllOrder = from lcN in _context.LC_OrderEntry
                               where lcN.CompShipmentDate == null && ((lcN.OrderNo.Contains(prefixText)))
                               select lcN;
                List<String> OrderList = new List<String>();
                foreach (var Order_No in AllOrder)
                {
                    OrderList.Add(Order_No.OrderNo);
                }
                return OrderList;
            }
        }
        private void ShowShipmentGrid()
        {
            try
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                string OrderNo = txtOrder.Text.Trim();
                List<LC_OrderEntry> lcload = shipmentBll.GetALLByOrderNo(OrderNo, OCode);
                
                if (lcload.Count > 0)
                {
                    grdShipment.DataSource = lcload;
                    grdShipment.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerChkBox = ((CheckBox)grdShipment.HeaderRow.FindControl("headerLevelCheckBox"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdShipment.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdShipment.Rows)
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

           LC_OrderEntry orderObj = new LC_OrderEntry();
           var orderEntry = txtOrder.Text;
            foreach (GridViewRow grvrow  in grdShipment.Rows)
            {
                CheckBox rowChkBox = ((CheckBox)grvrow.FindControl("rowLevelCheckBox"));
                DateTime? nullDate = null;
                if (rowChkBox.Checked == true)
                {
                    //DropDownList ddlShipmentMode = ((DropDownList)grvrow.FindControl("ddlShipmentMode"));
                    TextBox txtCompDate = ((TextBox)grvrow.FindControl("txtCompDate"));
                    Label lblID = ((Label)grvrow.FindControl("lblOrderNo"));
                    TextBox txtExtDate = ((TextBox)grvrow.FindControl("txtExtDate"));


                    //orderObj.Shipment_Mode = ddlShipmentMode.SelectedItem.Text;
                    orderObj.ExtendShipmentDate = Convert.ToDateTime(txtExtDate.Text);
                    if (txtCompDate.Text != "")
                    {
                        orderObj.CompShipmentDate = Convert.ToDateTime(txtCompDate.Text);
                        orderObj.ShipmentCompStatus = "Shipped";
                    }
                    else
                    {
                        orderObj.CompShipmentDate = nullDate;
                        orderObj.ShipmentCompStatus = "On hand";
                    }
                    
                    orderObj.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                    orderObj.Edit_Date=DateTime.Now;
                    int result = shipmentBll.UpdateOrder(orderEntry,orderObj);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Added Successfully')", true);
                    }
                    grdShipment.DataSource = null;
                    grdShipment.DataBind();
                    btnSubmit.Visible = false;
                    txtOrder.Text = "";
                    txtBuyer.Text = "";
                }
            }
           
        }

    }
}