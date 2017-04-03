using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL;

namespace ERPSSL.BuyingHouse
{
    public partial class ShipmentCompleteList : System.Web.UI.Page
    {
        ShipmentSheduleBLL shipmentBll = new ShipmentSheduleBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetOrderList();
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string Ocode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
            DateTime fromDate = Convert.ToDateTime(txtFromDate.Text);
            DateTime ToDate = Convert.ToDateTime(txtToDate.Text);

            var result = shipmentBll.GetCompleteOrderByDate(Ocode,fromDate, ToDate);
            if (result.Count > 0)
            {
                grdShipment.DataSource = result;
                grdShipment.DataBind();
            }
        }

        protected void grdShipment_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdShipment.PageIndex = e.NewPageIndex;
            GetOrderList();
        }
    }
}