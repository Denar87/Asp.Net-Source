using ERPSSL.Marketing.BLL;
using ERPSSL.Marketing.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Marketing
{
    public partial class WorkOrderSatus : System.Web.UI.Page
    {
        WorkOrderDetailsBLL aWorkOrderDetailsBLL = new WorkOrderDetailsBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if ((Session["UserID"] != null) && (Session["OCode"] != null))
                {
                    LoadWorkOrder();
                }
                else
                {
                    Response.Redirect("..\\AppGateway\\Login.aspx");
                }
            }
            
        }

        public void LoadWorkOrder()
        {
            List<MarketingWorkOrder> aMarketingWorkOrder = aWorkOrderDetailsBLL.GetWorkOrderStatus();
           
            grdorder.DataSource = aMarketingWorkOrder;
            grdorder.DataBind();

        }

        protected void imgbtnOrderSheetEdit_Click(object sender, ImageClickEventArgs e)
        {

            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
            string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

            Label lblID_WorkOrder = (Label)grdorder.Rows[row.RowIndex].FindControl("lblOrder_No");

            int workOrderId = Convert.ToInt16(lblID_WorkOrder.Text);


            Session["WorkOrderId"] = workOrderId;

            Response.Redirect("ViewWorkOrderStatus.aspx");
        }
    }
}