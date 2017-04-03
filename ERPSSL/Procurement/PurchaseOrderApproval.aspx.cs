using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.Procurement.BLL;
using System.Data;

namespace ERPSSL.Procurement
{
    public partial class PurchaseOrderApproval : System.Web.UI.Page
    {
        private static DataTable stdtToApprove = new DataTable();
        private static DataTable stdtApproved = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillPurchaseOrder();
            }
        }


        private void FillPurchaseOrder()
        {
            DataTable dt = new DataTable();
            dt = PurchaseOrderBll.GetPurchaseOrderToApproveList();

            grdPendingPurchaseOrders.DataSource = dt;
            grdPendingPurchaseOrders.DataBind();

            ddlPurchaseOrder.DataSource = dt;
            ddlPurchaseOrder.DataValueField = "PrOrderNo";
            ddlPurchaseOrder.DataTextField = "PrOrderNo";
            ddlPurchaseOrder.DataBind();
            ddlPurchaseOrder.Items.Insert(0, new ListItem("Select One", "0"));

        }

        protected void ddlPurchaseOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadPendingOrdersToApprove();
        }

        private void LoadPendingOrdersToApprove()
        {
            stdtToApprove = PurchaseOrderBll.GetPurchaseOrderProducts(ddlPurchaseOrder.SelectedValue);
            grdPurchaseOrderToApprove.DataSource = stdtToApprove;
            grdPurchaseOrderToApprove.DataBind();
            stdtApproved = stdtToApprove.Clone();
        }

        protected void BtnApprove_Click(object sender, EventArgs e)
        {
            if (ddlPurchaseOrder.SelectedValue != "0")
            {
                List<string> Ids = new List<string>();
                foreach (DataRow dr in stdtApproved.Rows)
                {
                    Ids.Add(dr["Id"].ToString());
                }

                if (Ids.Count > 0)
                {
                    if (PurchaseOrderBll.ApprovePurchaseOrder(Ids))
                    {
                        lblMessage.Text = "<font color='green'>Purchase Requisition Order " + ddlPurchaseOrder.SelectedValue + " has been approved successfully!</font>";

                        PurchaseOrderBll.MailToAllEnlistedSupplier(Ids);
                        stdtApproved.Rows.Clear();
                        grdApproved.DataSource = stdtApproved;
                        grdApproved.DataBind();
                    }
                    else
                    {
                        lblMessage.Text = "<font color='red'>Error in approving purchase requisition order!</font";
                    }
                    //MailToAllEnlistedSupplier
                }
                else
                {
                    // please select ...
                }
            }
        }

        protected void grdPurchaseOrderToApprove_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = grdPurchaseOrderToApprove.Rows[grdPurchaseOrderToApprove.SelectedIndex];
                string Id = row.Cells[0].Text;
                foreach (DataRow dr in stdtToApprove.Rows)
                {
                    try
                    {
                        if (dr["Id"].ToString() == Id)
                        {
                            stdtApproved.ImportRow(dr);
                            dr.Delete();
                        }
                    }
                    catch { }

                }

                grdPurchaseOrderToApprove.DataSource = stdtToApprove;
                grdPurchaseOrderToApprove.DataBind();

                grdApproved.DataSource = stdtApproved;
                grdApproved.DataBind();

            }
            catch { }
        }

        protected void grdApproved_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = grdApproved.Rows[grdApproved.SelectedIndex];
                string Id = row.Cells[0].Text;
                foreach (DataRow dr in stdtApproved.Rows)
                {
                    try
                    {
                        if (dr["Id"].ToString() == Id)
                        {
                            stdtToApprove.ImportRow(dr);
                            dr.Delete();
                        }
                    }
                    catch { }

                }

                grdPurchaseOrderToApprove.DataSource = stdtToApprove;
                grdPurchaseOrderToApprove.DataBind();

                grdApproved.DataSource = stdtApproved;
                grdApproved.DataBind();

            }
            catch { }
        }

        protected void grdPendingPurchaseOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = grdPendingPurchaseOrders.Rows[grdPendingPurchaseOrders.SelectedIndex];
                ddlPurchaseOrder.SelectedValue = row.Cells[0].Text;
                LoadPendingOrdersToApprove();
            }
            catch { }
        }

    }
}