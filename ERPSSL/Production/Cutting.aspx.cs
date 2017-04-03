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
    public partial class Cutting : System.Web.UI.Page
    {
        PlanningBLL _PlanningBLL = new PlanningBLL();

        CuttingBLL _cuttingbll = new CuttingBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    FillSeason();
                    LoadOrders();
                    Fillunit();
                    LoadCuttingDetails();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void FillSeason()
        {
            //try
            //{
            //    string OCode = ((SessionUser)Session["SessionUser"]).OCode;
            //    List<string> row = _cuttingbll.GetSeason(OCode);
            //    if (row != null)
            //    {
            //        ddlSeason.DataSource = row.ToList();
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

        private void FillStyle()
        {
            //try
            //{
            //    string season = ddlSeason.SelectedItem.Text;
            //    string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            //    var row = _cuttingbll.GetStyleBySeason(season);
            //    if (row.Count > 0)
            //    {
            //        ddlStyle.DataSource = row.ToList();
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

        private void Fillunit()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = _cuttingbll.GetUnitForMarchandising();
                if (row.Count > 0)
                {
                    ddlUnit.DataSource = row.ToList();
                    ddlUnit.DataTextField = "UnitName";
                    ddlUnit.DataValueField = "UnitId";
                    ddlUnit.DataBind();
                    ddlUnit.AppendDataBoundItems = false;
                    ddlUnit.Items.Insert(0, new ListItem("-Select Unit-", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void FillOrder(string style)
        {
            //try
            //{

            //    string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            //    var row = _cuttingbll.GetOrderByStyle(style);
            //    if (row.Count > 0)
            //    {
            //        ddlOrder.DataSource = row.ToList();
            //        ddlOrder.DataBind();
            //        ddlOrder.AppendDataBoundItems = false;
            //        ddlOrder.Items.Insert(0, new ListItem("--Select Order--", "0"));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillStyle();
        }

        //protected void ddlStyle_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //   FillOrder(ddlStyle.SelectedItem.Text);
        //}

        //protected void ddlOrder_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}
        //protected void grdCutting_RowDataBound(object sender, GridViewRowEventArgs e)
        //{

        //}

        protected void grdCutting_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void rowLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Prod_Cutting _objProdCutting = new Prod_Cutting();
                _objProdCutting.OrderNo = txtOrderNoFill.Text;
                _objProdCutting.BuyerID = Convert.ToInt32(txthidBuyer.Value);
                _objProdCutting.OrderQty = Convert.ToDouble(txtOderQty.Text);
                _objProdCutting.GoodsName = txtFinishGoods.Text;
                //_objProdCutting.OrderDate = Convert.ToDateTime(txtOrderDate.Text);
                _objProdCutting.FGoodsQty = Convert.ToDouble(txtFinishGoodsQty.Text);
                _objProdCutting.FGoodsUnit = txtUnits.Text;
                _objProdCutting.CuttingReceivedDate = Convert.ToDateTime(txtCuttingReceivedDate.Text);
                _objProdCutting.CuttingReceivedQty = Convert.ToDouble(txtCuttingReceivedQty.Text);
                _objProdCutting.CuttingReceivedUnit = Convert.ToInt32(ddlUnit.SelectedValue.ToString());

                if (divCCDShow.Visible == true)
                {
                    _objProdCutting.CuttingCompleteDate = Convert.ToDateTime(txtCuttingCompleteDate.Text);
                }
                if (divCCQShow.Visible == true)
                {
                    _objProdCutting.TotalCuttingCompleteQty = Convert.ToDouble(txtCCompleteCuttingQty.Text);
                    _objProdCutting.TotalCuttingCompleteUnit = Convert.ToInt32(ddlTUnits.SelectedValue.ToString());
                }

                _objProdCutting.Create_Date = DateTime.Now;
                _objProdCutting.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                _objProdCutting.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                if (btnSubmit.Text == "Submit")
                {
                    int result = _cuttingbll.InsertProdCutting(_objProdCutting);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                    }
                }
                else
                {
                    _objProdCutting.Edit_Date = DateTime.Now;
                    _objProdCutting.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                    _objProdCutting.ID = Convert.ToInt16(txthidID.Value);
                    int result = _cuttingbll.UpdateProdCutting(_objProdCutting);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                        btnSubmit.Text = "Submit";
                    }
                }
                LoadCuttingDetails();
                ClearUi();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ClearUi()
        {
            txtOrderNo.Text = "";
            txtOrderNoFill.Text = "";
            txtOderQty.Text = "";
            txtFinishGoods.Text = "";
            txtFinishGoodsQty.Text = "";
            txtUnits.Text = "";
            txtCuttingReceivedDate.Text = "";
            txtCuttingReceivedQty.Text = "";
            ddlUnit.ClearSelection();
            txtCuttingCompleteDate.Text = "";
            ddlTUnits.ClearSelection();
            //btnSubmit.Text = "Submit";
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchAllOrderNo(string prefixText, int count)
        {
            ERPSSL_LCEntities _context = new ERPSSL_LCEntities();
            var ONumbers = from ces in _context.LC_CostEstimateSummary
                           where ces.Lc_Order.Contains(prefixText)
                           select ces;
            List<String> OrderList = new List<String>();

            foreach (var OrderN in ONumbers)
            {
                OrderList.Add(OrderN.Lc_Order);
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

        protected void LoadOrders()
        {
            if (txtOrderNo.Text == "")
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<OrderDetails> result = _cuttingbll.GetOrdersDetails(OCODE);
                if (result.Count > 0)
                {
                    grdOrderDetails.DataSource = result.ToList();
                    grdOrderDetails.DataBind();
                }
                else
                {
                    var obj = new List<OrderDetails>();
                    obj.Add(new OrderDetails());

                    // Bind the DataTable which contain a blank row to the GridView
                    grdOrderDetails.DataSource = obj;
                    grdOrderDetails.DataBind();

                    int columnsCount = grdOrderDetails.Columns.Count;
                    grdOrderDetails.Rows[0].Cells.Clear();// clear all the cells in the row
                    grdOrderDetails.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    grdOrderDetails.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    grdOrderDetails.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    grdOrderDetails.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    grdOrderDetails.Rows[0].Cells[0].Font.Bold = true;

                    //set No Results found to the new added cell
                    grdOrderDetails.Rows[0].Cells[0].Text = "NO RECORDS FOUND FOR TODAY!";
                }
            }
            else
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string orderNo = txtOrderNo.Text;
                List<OrderDetails> orders = _cuttingbll.GetOrdersDetailsByOrderNo(orderNo, OCODE);
                if (orders.Count > 0)
                {
                    grdOrderDetails.DataSource = orders.ToList();
                    grdOrderDetails.DataBind();
                }
                else
                {
                    var obj = new List<OrderDetails>();
                    obj.Add(new OrderDetails());
                    // Bind the DataTable which contain a blank row to the GridView
                    grdOrderDetails.DataSource = obj;
                    grdOrderDetails.DataBind();

                    int columnsCount = grdOrderDetails.Columns.Count;
                    grdOrderDetails.Rows[0].Cells.Clear();// clear all the cells in the row
                    grdOrderDetails.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    grdOrderDetails.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    grdOrderDetails.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    grdOrderDetails.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    grdOrderDetails.Rows[0].Cells[0].Font.Bold = true;

                    //set No Results found to the new added cell
                    grdOrderDetails.Rows[0].Cells[0].Text = "NO RECORDS FOUND FOR !";
                }
            }
        }

        protected void txtOrderNo_TextChanged(object sender, EventArgs e)
        {
            LoadOrders();
        }

        protected void imgbtnOrderDetails_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            Label lblId = (Label)grdOrderDetails.Rows[row.RowIndex].FindControl("lblId");
            Label lblBuyerID = (Label)grdOrderDetails.Rows[row.RowIndex].FindControl("lblBuyerID");
            Label lblFinishedGoods_Qty = (Label)grdOrderDetails.Rows[row.RowIndex].FindControl("lblFinishedGoods_Qty");
            Label lblFinishedGoods_ID = (Label)grdOrderDetails.Rows[row.RowIndex].FindControl("lblFinishedGoods_ID");
            Label lblFinishedGoodsName = (Label)grdOrderDetails.Rows[row.RowIndex].FindControl("lblFinishedGoodsName");
            Label lblLc_Order = (Label)grdOrderDetails.Rows[row.RowIndex].FindControl("lblLc_Order");
            Label lblOrderDate = (Label)grdOrderDetails.Rows[row.RowIndex].FindControl("lblOrderDate");
            Label lblGoodsUnits = (Label)grdOrderDetails.Rows[row.RowIndex].FindControl("lblProductUnits");
            Session["Lc_Order"] = lblLc_Order.Text;
            txtOrderNoFill.Text = lblLc_Order.Text;
            Session["Buyer_ID"] = lblBuyerID.Text;
            txthidBuyer.Value = lblBuyerID.Text;
            txtFinishGoodsQty.Text = lblFinishedGoods_Qty.Text;
            txtOderQty.Text = lblFinishedGoods_Qty.Text;
            txtFinishGoods.Text = lblFinishedGoodsName.Text;
            txtUnits.Text = lblGoodsUnits.Text;


            //txtOrderNumber.Text = lblLc_Order.Text;
            //txtOrderDate.Text = lblOrderDate.Text;
        }

        //protected void txtCuttingAmount_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        double ResvQty = Convert.ToDouble(txtCuttingReceivedQty.Text);
        //        double ToDayFinish = Convert.ToDouble(txtCuttingAmount.Text);

        //        // double CompleteQty = 0;

        //        if (txtCompleteQty.Text == "")
        //        {
        //            double CompleteQty = ResvQty - ToDayFinish;
        //            txtCompleteQty.Text = CompleteQty.ToString();
        //        }
        //        else
        //        {
        //            double TotalFinish = Convert.ToDouble(txtCompleteQty.Text);
        //            double CompleteQty = TotalFinish - ToDayFinish;
        //            txtCompleteQty.Text = CompleteQty.ToString();
        //        }

        //        Session["ComQty"] = txtCompleteQty.Text;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        protected void TextOrderNo4Cutting_TextChanged(object sender, EventArgs e)
        {
            try
            {
                LoadCuttingDetails();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadCuttingDetails()
        {
            if (txtOrderNo.Text == "")
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<CuttingDetailsR> result = _cuttingbll.GetCuttingDetails(OCODE);
                if (result.Count > 0)
                {
                    grdCuttingDetails.DataSource = result.ToList();
                    grdCuttingDetails.DataBind();
                }
                else
                {
                    var obj = new List<CuttingDetailsR>();
                    obj.Add(new CuttingDetailsR());

                    // Bind the DataTable which contain a blank row to the GridView
                    grdCuttingDetails.DataSource = obj;
                    grdCuttingDetails.DataBind();

                    int columnsCount = grdCuttingDetails.Columns.Count;
                    grdCuttingDetails.Rows[0].Cells.Clear();// clear all the cells in the row
                    grdCuttingDetails.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    grdCuttingDetails.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell
                    grdCuttingDetails.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    grdCuttingDetails.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    grdCuttingDetails.Rows[0].Cells[0].Font.Bold = true;

                    //set No Results found to the new added cell
                    grdCuttingDetails.Rows[0].Cells[0].Text = "NO RECORDS FOUND FOR TODAY!";
                }
            }
            else
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string orderNo = txtOrderNo.Text;
                List<CuttingDetailsR> orders = _cuttingbll.GetCuttingDetailsByOrderNo(orderNo, OCODE);
                if (orders.Count > 0)
                {
                    grdCuttingDetails.DataSource = orders.ToList();
                    grdCuttingDetails.DataBind();
                }
                else
                {
                    var obj = new List<CuttingDetailsR>();
                    obj.Add(new CuttingDetailsR());
                    // Bind the DataTable which contain a blank row to the GridView
                    grdCuttingDetails.DataSource = obj;
                    grdCuttingDetails.DataBind();

                    int columnsCount = grdCuttingDetails.Columns.Count;
                    grdCuttingDetails.Rows[0].Cells.Clear();// clear all the cells in the row
                    grdCuttingDetails.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    grdCuttingDetails.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell
                    grdCuttingDetails.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    grdCuttingDetails.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    grdCuttingDetails.Rows[0].Cells[0].Font.Bold = true;

                    //set No Results found to the new added cell
                    grdCuttingDetails.Rows[0].Cells[0].Text = "NO RECORDS FOUND FOR !";
                }
            }
        }

        protected void imgbtnCuttingDetails_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

                Label lblId = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblId");
                //Label lblOrderNo = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblOrderNo");
                //Label lblOrder_Qty = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblOrderQty");
                //Label lblGoodsName = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblFinishedGoodsName");
                //Label lblFGoodsQty = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblFGoodsQty");
                //Label lblFGoodsUnit = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblFGoodsUnit");
                //Label lblCuttingReceivedDate = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblCuttingReceivedDate");
                //Label lblCuttingReceivedQty = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblCuttingReceivedQty");
                //Label lblCuttingReceivedUnit = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblCuttingReceivedUnit");
                //Label lblCuttingCompleteDate = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblCuttingCompleteDate");
                //Label lblTotalCuttingCompleteQty = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblTotalCuttingCompleteQty");
                // Label lblTotalCuttingCompleteUnit = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblTotalCuttingCompleteUnit");
                int cID = Convert.ToInt16(lblId.Text);

                Prod_Cutting _ID = _cuttingbll.GetCuttingbyId(cID);
                if (_ID != null)
                {

                    txthidID.Value = _ID.ID.ToString();
                    txtOrderNoFill.Text = _ID.OrderNo.ToString();
                    txthidBuyer.Value = _ID.BuyerID.ToString();
                    txtOderQty.Text = _ID.OrderQty.ToString();
                    txtFinishGoods.Text = _ID.GoodsName.ToString();
                    txtFinishGoodsQty.Text = _ID.FGoodsQty.ToString();
                    txtUnits.Text = _ID.FGoodsUnit.ToString();
                    txtCuttingReceivedDate.Text = _ID.CuttingReceivedDate.ToString();
                    txtCuttingReceivedQty.Text = _ID.CuttingReceivedQty.ToString();
                    ddlUnit.Text = _ID.CuttingReceivedUnit.ToString();
                    txtCuttingCompleteDate.Text = _ID.CuttingCompleteDate.ToString();
                    txtCCompleteCuttingQty.Text = _ID.TotalCuttingCompleteQty.ToString();
                    //ddlTUnits.Text = _ID.TotalCuttingCompleteUnit.ToString();


                    //txthidID.Value = lblId.ToString();
                    //Session["lblId"] = txthidID.Value;
                    //txtOrderNoFill.Text = lblOrderNo.Text;
                    //txtOderQty.Text = lblOrder_Qty.Text;
                    //txtFinishGoods.Text = lblGoodsName.Text;
                    //txtFinishGoodsQty.Text = lblOrder_Qty.Text;
                    //txtUnits.Text = lblFGoodsUnit.Text;
                    //txtCuttingReceivedDate.Text = lblCuttingReceivedDate.Text;
                    //txtCuttingReceivedQty.Text = lblCuttingReceivedQty.Text;
                    //ddlUnit.Text = lblCuttingReceivedUnit.Text;
                    //txtCuttingCompleteDate.Text = lblCuttingCompleteDate.Text;
                    //txtCCompleteCuttingQty.Text = lblTotalCuttingCompleteQty.Text;
                    //ddlTUnits.Text = lblTotalCuttingCompleteUnit.Text;

                    btnSubmit.Text = "Update";
                    divCCDShow.Visible = true;
                    divCCQShow.Visible = true;
                }
                FillTotalunit();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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
    }
}