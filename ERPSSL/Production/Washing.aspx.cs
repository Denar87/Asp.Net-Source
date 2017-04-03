using ERPSSL.LC.DAL;
using ERPSSL.Production.BLL;
using ERPSSL.Production.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Production
{
    public partial class Washing : System.Web.UI.Page
    {
        CuttingBLL _cuttingbll = new CuttingBLL();

        SewingBLL _sewingbll = new SewingBLL();

        WashingBLL _washingbll = new WashingBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    Fillunit();
                    LoadSewingDetails();
                    LoadWashingDetails();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchAllOrderNo(string prefixText, int count)
        {
            ERPSSL_LCEntities _context = new ERPSSL_LCEntities();
            var ONumbers = from ces in _context.Prod_Sewing
                           where ces.OrderNo.Contains(prefixText)
                           select ces;
            List<String> OrderList = new List<String>();

            foreach (var OrderN in ONumbers)
            {
                OrderList.Add(OrderN.OrderNo);
            }
            return OrderList;
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchAllOrderNoCutting(string prefixText, int count)
        {
            ERPSSL_LCEntities _context = new ERPSSL_LCEntities();
            var ONumbers = from ces in _context.Prod_Cutting
                           where ces.OrderNo.Contains(prefixText)
                           select ces;
            List<String> OrderList = new List<String>();

            foreach (var OrderN in ONumbers)
            {
                OrderList.Add(OrderN.OrderNo);
            }
            return OrderList;
        }

        private void LoadSewingDetails()
        {
            if (txtFillOrderNo.Text == "")
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<SewingDetailsR> result = _sewingbll.GetSewingDetails(OCODE);
                if (result.Count > 0)
                {
                    grdSewingDetails.DataSource = result.ToList();
                    grdSewingDetails.DataBind();
                }
                else
                {
                    var obj = new List<SewingDetailsR>();
                    obj.Add(new SewingDetailsR());

                    // Bind the DataTable which contain a blank row to the GridView
                    grdSewingDetails.DataSource = obj;
                    grdSewingDetails.DataBind();

                    int columnsCount = grdSewingDetails.Columns.Count;
                    grdSewingDetails.Rows[0].Cells.Clear();// clear all the cells in the row
                    grdSewingDetails.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    grdSewingDetails.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell
                    grdSewingDetails.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    grdSewingDetails.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    grdSewingDetails.Rows[0].Cells[0].Font.Bold = true;

                    //set No Results found to the new added cell
                    grdSewingDetails.Rows[0].Cells[0].Text = "NO RECORDS FOUND FOR TODAY!";
                }
            }
            else
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string orderNo = txtFillOrderNo.Text;
                List<SewingDetailsR> orders = _sewingbll.GetSewingDetailsByOrderNo(orderNo, OCODE);
                if (orders.Count > 0)
                {
                    grdSewingDetails.DataSource = orders.ToList();
                    grdSewingDetails.DataBind();
                }
                else
                {
                    var obj = new List<SewingDetailsR>();
                    obj.Add(new SewingDetailsR());
                    // Bind the DataTable which contain a blank row to the GridView
                    grdSewingDetails.DataSource = obj;
                    grdSewingDetails.DataBind();

                    int columnsCount = grdSewingDetails.Columns.Count;
                    grdSewingDetails.Rows[0].Cells.Clear();// clear all the cells in the row
                    grdSewingDetails.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    grdSewingDetails.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell
                    grdSewingDetails.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    grdSewingDetails.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    grdSewingDetails.Rows[0].Cells[0].Font.Bold = true;

                    //set No Results found to the new added cell
                    grdSewingDetails.Rows[0].Cells[0].Text = "NO RECORDS FOUND FOR !";
                }
            }
        }

        private void Fillunit()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = _cuttingbll.GetUnitForMarchandising();
                if (row.Count > 0)
                {
                    ddlWashingUnit.DataSource = row.ToList();
                    ddlWashingUnit.DataTextField = "UnitName";
                    ddlWashingUnit.DataValueField = "UnitId";
                    ddlWashingUnit.DataBind();
                    ddlWashingUnit.AppendDataBoundItems = false;
                    ddlWashingUnit.Items.Insert(0, new ListItem("-Select Unit-", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void txtFillOrderNo_TextChanged(object sender, EventArgs e)
        {
            LoadSewingDetails();
        }

        //protected void imgbtnCuttingDetails_Click(object sender, ImageClickEventArgs e)
        //{
        //    try
        //    {
        //        ImageButton imgbtn = (ImageButton)sender;
        //        GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

        //        Label lblId = (Label)grdSewingDetails.Rows[row.RowIndex].FindControl("lblId");
        //        Label lblOrderNo = (Label)grdSewingDetails.Rows[row.RowIndex].FindControl("lblOrderNo");
        //        Label lblBuyerID = (Label)grdSewingDetails.Rows[row.RowIndex].FindControl("lblBuyerID");
        //        Label lblOrder_Qty = (Label)grdSewingDetails.Rows[row.RowIndex].FindControl("lblOrderQty");
        //        Label lblGoodsName = (Label)grdSewingDetails.Rows[row.RowIndex].FindControl("lblFinishedGoodsName");
        //        Label lblFGoodsQty = (Label)grdSewingDetails.Rows[row.RowIndex].FindControl("lblFGoodsQty");
        //        Label lblFGoodsUnit = (Label)grdSewingDetails.Rows[row.RowIndex].FindControl("lblFGoodsUnit");
        //        Label lblCuttingReceivedDate = (Label)grdSewingDetails.Rows[row.RowIndex].FindControl("lblCuttingReceivedDate");
        //        Label lblCuttingReceivedQty = (Label)grdSewingDetails.Rows[row.RowIndex].FindControl("lblCuttingReceivedQty");
        //        Label lblCuttingReceivedUnit = (Label)grdSewingDetails.Rows[row.RowIndex].FindControl("lblCuttingReceivedUnit");


        //        txthidID.Value = lblId.ToString();
        //        Session["lblId"] = txthidID.Value;
        //        txtOrderNoFill.Text = lblOrderNo.Text;
        //        Session["Buyer_ID"] = lblBuyerID.Text;
        //        txthidBuyer.Value = lblBuyerID.Text;
        //        txtOderQty.Text = lblOrder_Qty.Text;
        //        txtFinishGoods.Text = lblGoodsName.Text;
        //        txtFinishGoodsQty.Text = lblOrder_Qty.Text;
        //        txtFinishGoodsUnits.Text = lblFGoodsUnit.Text;
        //        txtReceivedQty.Text = lblCuttingReceivedQty.Text;
        //        txtReceivedUnit.Text = lblCuttingReceivedUnit.Text;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private void FillTotalunit()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = _cuttingbll.GetUnitForMarchandising();
                if (row.Count > 0)
                {
                    ddlTUnits.DataSource = row.ToList();
                    ddlTUnits.DataTextField = "UnitName";
                    ddlTUnits.DataValueField = "UnitId";
                    ddlTUnits.DataBind();
                    ddlTUnits.AppendDataBoundItems = false;
                    ddlTUnits.Items.Insert(0, new ListItem("-Select Unit-", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void imgbtnSewingDetails_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

                Label lblId = (Label)grdSewingDetails.Rows[row.RowIndex].FindControl("lblId");
                Label lblOrderNo = (Label)grdSewingDetails.Rows[row.RowIndex].FindControl("lblOrderNo");
                Label lblBuyerID = (Label)grdSewingDetails.Rows[row.RowIndex].FindControl("lblBuyerID");
                Label lblCuttingID = (Label)grdSewingDetails.Rows[row.RowIndex].FindControl("lblCuttingID");
                Label lblOrder_Qty = (Label)grdSewingDetails.Rows[row.RowIndex].FindControl("lblOrderQty");
                Label lblGoodsName = (Label)grdSewingDetails.Rows[row.RowIndex].FindControl("lblFinishedGoodsName");
                Label lblFGoodsQty = (Label)grdSewingDetails.Rows[row.RowIndex].FindControl("lblFGoodsQty");
                Label lblFGoodsUnit = (Label)grdSewingDetails.Rows[row.RowIndex].FindControl("lblFGoodsUnit");
                Label lblTotalSewingCompleteQty = (Label)grdSewingDetails.Rows[row.RowIndex].FindControl("lblTotalSewingCompleteQty");
                Label lblTotalSewingCompleteUnit = (Label)grdSewingDetails.Rows[row.RowIndex].FindControl("lblTotalSewingCompleteUnit");

                Session["lblId"] = lblId.Text;
                txthidSewingID.Value = lblId.Text;

                txtOrderNoFill.Text = lblOrderNo.Text;

                Session["Buyer_ID"] = lblBuyerID.Text;
                txthidBuyer.Value = lblBuyerID.Text;

                Session["Cutting_ID"] = lblCuttingID.Text;
                txthidCuttingID.Value = lblCuttingID.Text;

                txtOderQty.Text = lblOrder_Qty.Text;
                txtFinishGoods.Text = lblGoodsName.Text;
                txtFinishGoodsQty.Text = lblOrder_Qty.Text;
                txtFinishGoodsUnits.Text = lblFGoodsUnit.Text;
                txtSewingCompleteQty.Text = lblTotalSewingCompleteQty.Text;
                txtSewingCompleteUnit.Text = lblTotalSewingCompleteUnit.Text;
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
                Prod_Washing _objProdWashing = new Prod_Washing();

                _objProdWashing.CuttingID = Convert.ToInt32(txthidCuttingID.Value);
                _objProdWashing.SewingID = Convert.ToInt32(txthidSewingID.Value);
                _objProdWashing.OrderNo = txtOrderNoFill.Text;
                _objProdWashing.BuyerID = Convert.ToInt32(txthidBuyer.Value);
                _objProdWashing.OrderQty = Convert.ToDouble(txtOderQty.Text);
                _objProdWashing.GoodsName = txtFinishGoods.Text;
                _objProdWashing.FGoodsQty = Convert.ToDouble(txtFinishGoodsQty.Text);
                _objProdWashing.FGoodsUnit = txtFinishGoodsUnits.Text;
                _objProdWashing.TotalSewingCompleteQty = Convert.ToDouble(txtSewingCompleteQty.Text);
                _objProdWashing.TotalSewingCompleteUnit = Convert.ToInt32(txtSewingCompleteUnit.Text);
                _objProdWashing.TotalWashingReceivedDate = Convert.ToDateTime(txtWashingReceivedDate.Text);
                _objProdWashing.TotalWashingReceivedQty = Convert.ToDouble(txtWashingReceivedQty.Text);
                _objProdWashing.TotalWashingReceivedUnit = Convert.ToInt32(ddlWashingUnit.SelectedValue.ToString());
                

                if (divCCDShow.Visible == true)
                {
                    _objProdWashing.TotalWashingCompleteDate = Convert.ToDateTime(txtWashingCompleteDate.Text);
                }
                if (divCCQShow.Visible == true)
                {
                    _objProdWashing.TotalWashingCompleteQty = Convert.ToDouble(txtCCompleteWashingQty.Text);
                    _objProdWashing.TotalWashingCompleteUnit = Convert.ToInt32(ddlTUnits.SelectedValue.ToString());
                }

                _objProdWashing.Create_Date = DateTime.Now;
                _objProdWashing.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                _objProdWashing.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                if (btnSubmit.Text == "Submit")
                {
                    int result = _washingbll.InsertProdWashing(_objProdWashing);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                    }
                }
                else
                {
                    _objProdWashing.Edit_Date = DateTime.Now;
                    _objProdWashing.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                    _objProdWashing.ID = Convert.ToInt16(txthidID.Value);
                    int result = _washingbll.UpdateProdWashing(_objProdWashing);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                        btnSubmit.Text = "Submit";
                    }
                }
                ClearUi();
                LoadWashingDetails();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearUi()
        {
            txtFillOrderNo.Text = "";
            txtOrderNoFill.Text = "";
            txtOderQty.Text = "";
            txtFinishGoods.Text = "";
            txtFinishGoodsQty.Text = "";
            txtFinishGoodsUnits.Text = "";
            txtSewingCompleteQty.Text = "";
            txtSewingCompleteUnit.Text = "";
            txtWashingReceivedDate.Text = "";
            txtWashingReceivedQty.Text = "";

            txtWashingCompleteDate.Text = "";
            txtCCompleteWashingQty.Text = "";
            ddlTUnits.ClearSelection();
        }

        private void LoadWashingDetails()
        {
            if (txtFillOrderNo.Text == "")
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<WashingDetailsR> result = _washingbll.GetWashingDetails(OCODE);
                if (result.Count > 0)
                {
                    grdWashingDetails.DataSource = result.ToList();
                    grdWashingDetails.DataBind();
                }
                else
                {
                    var obj = new List<WashingDetailsR>();
                    obj.Add(new WashingDetailsR());

                    // Bind the DataTable which contain a blank row to the GridView
                    grdWashingDetails.DataSource = obj;
                    grdWashingDetails.DataBind();

                    int columnsCount = grdWashingDetails.Columns.Count;
                    grdWashingDetails.Rows[0].Cells.Clear();// clear all the cells in the row
                    grdWashingDetails.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    grdWashingDetails.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell
                    grdWashingDetails.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    grdWashingDetails.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    grdWashingDetails.Rows[0].Cells[0].Font.Bold = true;

                    //set No Results found to the new added cell
                    grdWashingDetails.Rows[0].Cells[0].Text = "NO RECORDS FOUND FOR TODAY!";
                }
            }
            else
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string orderNo = txtFillOrderNo.Text;
                List<WashingDetailsR> orders = _washingbll.GetWashingDetailsByOrderNo(orderNo, OCODE);
                if (orders.Count > 0)
                {
                    grdWashingDetails.DataSource = orders.ToList();
                    grdWashingDetails.DataBind();
                }
                else
                {
                    var obj = new List<WashingDetailsR>();
                    obj.Add(new WashingDetailsR());
                    // Bind the DataTable which contain a blank row to the GridView
                    grdWashingDetails.DataSource = obj;
                    grdWashingDetails.DataBind();

                    int columnsCount = grdWashingDetails.Columns.Count;
                    grdWashingDetails.Rows[0].Cells.Clear();// clear all the cells in the row
                    grdWashingDetails.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    grdWashingDetails.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell
                    grdWashingDetails.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    grdWashingDetails.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    grdWashingDetails.Rows[0].Cells[0].Font.Bold = true;

                    //set No Results found to the new added cell
                    grdWashingDetails.Rows[0].Cells[0].Text = "NO RECORDS FOUND FOR !";
                }
            }
        }

        protected void imgbtnWashingDetails_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

                Label lblId = (Label)grdWashingDetails.Rows[row.RowIndex].FindControl("lblId");

                int wID = Convert.ToInt16(lblId.Text);

                Prod_Washing _ID = _washingbll.GetWashinggbyId(wID);
                if (_ID != null)
                {

                    txthidID.Value = _ID.ID.ToString();
                    txthidCuttingID.Value = _ID.CuttingID.ToString();
                    txthidSewingID.Value = _ID.SewingID.ToString();
                    txthidBuyer.Value = _ID.BuyerID.ToString();
                    txtOrderNoFill.Text = _ID.OrderNo.ToString();
                    txtOderQty.Text = _ID.OrderQty.ToString();
                    txtFinishGoods.Text = _ID.GoodsName.ToString();
                    txtFinishGoodsQty.Text = _ID.FGoodsQty.ToString();
                    txtFinishGoodsUnits.Text = _ID.FGoodsUnit.ToString();
                    txtSewingCompleteQty.Text = _ID.TotalSewingCompleteQty.ToString();
                    txtSewingCompleteUnit.Text = _ID.TotalSewingCompleteUnit.ToString();
                    txtWashingReceivedDate.Text = _ID.TotalWashingReceivedDate.ToString();
                    txtWashingReceivedQty.Text = _ID.TotalWashingReceivedQty.ToString();
                    ddlWashingUnit.Text = _ID.TotalWashingReceivedUnit.ToString();
                    txtWashingCompleteDate.Text = _ID.TotalWashingCompleteDate.ToString();
                    txtCCompleteWashingQty.Text = _ID.TotalWashingCompleteQty.ToString();
                    //ddlTUnits.Text = _ID.TotalWashingCompleteUnit.ToString();


                    btnSubmit.Text = "Update";
                    divCCDShow.Visible = true;
                    divCCQShow.Visible = true;
                    txtWashingReceivedDate.Enabled = false;
                    txtWashingReceivedQty.ReadOnly = true;
                    ddlWashingUnit.Enabled = false;
                }
                FillTotalunit();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


