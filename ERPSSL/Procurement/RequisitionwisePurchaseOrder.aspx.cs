using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.BLL;
using ERPSSL.Procurement.BLL;
using System.Data;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;

namespace ERPSSL.Procurement
{
    public partial class RequisitionwisePurchaseOrder : System.Web.UI.Page
    {
        public static DataTable staticDt = new DataTable();
        public static DataTable staticDtSelected = staticDt.Clone();
        IChallanBLL ic = new IChallanBLL();
        PurchaseOrderBll purchaseOrderBll = new PurchaseOrderBll();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                //loadDatagrid();
                FillProductsToPurchase("Consumable Product");
                //CleargrdProductToPurchaseSelected();
                // FillProductGroup();
                txtOrderDate.Text = DateTime.Today.ToShortDateString();
                txtOrderNo.Text = PurchaseOrderBll.GetNewPurchaseOrderNo(DateTime.Today);
            }
        }

        //private void CleargrdProductToPurchaseSelected()
        //{
        //    grdProductToPurchaseSelected.DataSource = null;
        //    grdProductToPurchaseSelected.DataBind();
        //}

        //private void loadDatagrid()
        //{
        //    String strConnString = ConfigurationManager.ConnectionStrings["ERPSSLADO"].ConnectionString;
        //    SqlConnection con = new SqlConnection(strConnString);
        //    SqlCommand cmd = new SqlCommand();
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.CommandText = "PRQ_GetRequisitionProducts";
        //    cmd.Parameters.Add("@AssetType", SqlDbType.VarChar).Value = ddlGoodsType.Text.Trim();
        //    cmd.Parameters.Add("@Type", SqlDbType.VarChar).Value = "Combined";
        //    cmd.Connection = con;

        //    SqlDataAdapter da = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);
        //    try
        //    {
        //        con.Open();

        //        //grdProductToPurchase.EmptyDataText = "No Records Found";
        //        grdProductToPurchase.DataSource = dt;
        //        grdProductToPurchase.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //        con.Dispose();
        //    }
        //}

        private void FillProductsToPurchase(string AssetType)
        {
            DataTable dt = PurchaseOrderBll.GetRequisitionProducts("Combined", AssetType);
            if (dt.Rows.Count > 0)
            {
                staticDt = dt;
                staticDtSelected = staticDt.Clone();
                grdProductToPurchase.DataSource = dt;
                grdProductToPurchase.DataBind();
            }
            else
            {
                //lblMessage.Text = "<font color='red'>No Record Found</font>";
            }
        }

        protected void txtOrderDate_TextChanged(object sender, EventArgs e)
        {
            DateTime date = DateTime.Today;
            try
            {
                date = DateTime.Parse(txtOrderDate.Text);
            }
            catch { }
            txtOrderNo.Text = PurchaseOrderBll.GetNewPurchaseOrderNo(date);
        }

        private void ClearForm()
        {
            // txtBalQty.Text = string.Empty;
            txtOrderNo.Text = string.Empty;
            txtPurchaseQty.Text = string.Empty;
            // txtReqQty.Text = string.Empty;
            //ddlProductName.Items.Clear();
        }

        private void ClearProduct()
        {
            //txtBalQty.Text = string.Empty;
            txtOrderNo.Text = string.Empty;
            txtPurchaseQty.Text = string.Empty;
            // txtReqQty.Text = string.Empty;
        }

        protected void grdProductToPurchase_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = grdProductToPurchase.Rows[grdProductToPurchase.SelectedIndex];
                //GridViewRow row = grdRequisition.Rows[e.NewSelectedIndex];
                string Id = row.Cells[1].Text;

                txtProduct.Text = row.Cells[3].Text;
                //txtPurchaseQty.Text = row.Cells[7].Text;
                txtPurchaseQty.Text = row.Cells[9].Text;
            }
            catch { }
        }

        //protected void BtnPurchaseByQuotation_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        // add
        //        // pmplement Direct purchase

        //        //
        //        GridViewRow row = grdProductToPurchase.Rows[grdProductToPurchase.SelectedIndex];
        //        string Id = row.Cells[1].Text;

        //        foreach (DataRow dr in staticDt.Rows)
        //        {
        //            try
        //            {
        //                if (dr["Id"].ToString() == Id)
        //                {
        //                    staticDtSelected.ImportRow(dr);
        //                    dr.Delete();
        //                }
        //            }
        //            catch { }

        //        }
        //        grdProductToPurchase.DataSource = staticDt;
        //        grdProductToPurchase.DataBind();

        //        //grdProductToPurchaseSelected.DataSource = staticDtSelected;
        //        //grdProductToPurchaseSelected.DataBind();

        //    }
        //    catch { }
        //}

        protected void ddlGoodsType_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillProductsToPurchase(ddlGoodsType.SelectedValue);
            //CleargrdProductToPurchaseSelected();
        }

        //protected void BtnRequestForTender_Click(object sender, EventArgs e)
        //{
        //    try
        //    {

        //        if (staticDtSelected.Rows.Count == 0)
        //        {
        //            return;
        //        }

        //        try
        //        {
        //            //System.Threading.Thread.Sleep(2000);
        //            foreach (DataRow dr in staticDtSelected.Rows)
        //            {
        //                Hashtable ht = new Hashtable();
        //                ht.Add("PrOrderNo", txtOrderNo.Text);
        //                ht.Add("OrderType", "Combined");
        //                ht.Add("CompanyCode", dr["CompanyCode"].ToString());
        //                ht.Add("ReqNo", "");
        //                ht.Add("ReqQty", dr["ReqQty"].ToString());
        //                ht.Add("OrderQty", dr["PurchaseQty"].ToString());
        //                ht.Add("OrderDate", txtOrderDate.Text);
        //                ht.Add("PurchaseType", "ByQuotation");
        //                //ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode);
        //                ht.Add("OCode", "8989");
        //                ht.Add("BarCode", dr["BarCode"].ToString());
        //                DataTable dt = new DataTable();
        //                dt = PurchaseOrderBll.AddNewPurchaseOrder(ht);
        //            }
        //            //CleargrdProductToPurchaseSelected();
        //            lblMessage.Text = "<font color='green'>Purchase order has been added successfully!</font";
        //        }
        //        catch
        //        {
        //            lblMessage.Text = "<font color='red'>Error in adding purchase order!</font";
        //        }
        //    }
        //    catch { }
        //}

        protected void BtnDirectPurchase_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = grdProductToPurchase.Rows[grdProductToPurchase.SelectedIndex];
                string Id = row.Cells[1].Text;

                foreach (DataRow dr in staticDt.Rows)
                {
                    try
                    {
                        if (dr["Id"].ToString() == Id)
                        {
                            //
                            Hashtable ht = new Hashtable();
                            ht.Add("PrOrderNo", txtOrderNo.Text);
                            ht.Add("OrderType", "Combined");
                            ht.Add("CompanyCode", dr["CompanyCode"].ToString());
                            ht.Add("ReqNo", "");
                            ht.Add("ReqQty", dr["ReqQty"].ToString());
                            ht.Add("OrderQty", dr["PurchaseQty"].ToString());
                            ht.Add("OrderDate", txtOrderDate.Text);
                            ht.Add("PurchaseType", "DirectPurchase");
                            ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode);
                            ht.Add("BarCode", dr["BarCode"].ToString());
                            DataTable dt = new DataTable();
                            dt = PurchaseOrderBll.AddNewPurchaseOrder(ht);
                            lblMessage.Text = "<font color='green'>Direct Purchase order has been added successfully!</font>";
                            //
                            dr.Delete();
                        }
                    }
                    catch
                    {
                        lblMessage.Text = "<font color='red'>Error in adding purchase order!</font>";
                    }

                }
                grdProductToPurchase.DataSource = staticDt;
                grdProductToPurchase.DataBind();
            }
            catch { }

        }

        protected void BtnPurchaseByQuotation_Click(object sender, EventArgs e)
        {
            try
            {
                GridViewRow row = grdProductToPurchase.Rows[grdProductToPurchase.SelectedIndex];
                string Id = row.Cells[1].Text;

                foreach (DataRow dr in staticDt.Rows)
                {
                    try
                    {
                        if (dr["Id"].ToString() == Id)
                        {
                            //
                            Hashtable ht = new Hashtable();
                            ht.Add("PrOrderNo", txtOrderNo.Text);
                            ht.Add("OrderType", "Combined");
                            ht.Add("CompanyCode", dr["CompanyCode"].ToString());
                            ht.Add("ReqNo", "");
                            ht.Add("ReqQty", dr["ReqQty"].ToString());
                            ht.Add("OrderQty", dr["PurchaseQty"].ToString());
                            ht.Add("OrderDate", txtOrderDate.Text);
                            ht.Add("PurchaseType", "ByQuotation");
                            ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode);
                            ht.Add("BarCode", dr["BarCode"].ToString());
                            DataTable dt = new DataTable();
                            dt = PurchaseOrderBll.AddNewPurchaseOrder(ht);
                            lblMessage.Text = "<font color='green'>Purchase order has been added successfully!</font>";
                            //
                            dr.Delete();
                        }
                    }
                    catch
                    {
                        lblMessage.Text = "<font color='red'>Error in adding purchase order!</font>";
                    }

                }
                grdProductToPurchase.DataSource = staticDt;
                grdProductToPurchase.DataBind();
            }
            catch { }
        }

    }
}