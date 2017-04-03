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
    public partial class Finishing : System.Web.UI.Page
    {
        CuttingBLL _cuttingbll = new CuttingBLL();

        WashingBLL _washingbll = new WashingBLL();

        FinishingBLL _finishingbll = new FinishingBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    Fillunit();
                    LoadWashingDetails();
                   // LoadFinishingDetails();
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
            var ONumbers = from ces in _context.Prod_Washing
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
            var ONumbers = from ces in _context.Prod_Finishing
                           where ces.OrderNo.Contains(prefixText)
                           select ces;
            List<String> OrderList = new List<String>();

            foreach (var OrderN in ONumbers)
            {
                OrderList.Add(OrderN.OrderNo);
            }
            return OrderList;
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

        private void Fillunit()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = _cuttingbll.GetUnitForMarchandising();
                if (row.Count > 0)
                {
                    ddlFFinishingUnit.DataSource = row.ToList();
                    ddlFFinishingUnit.DataTextField = "UnitName";
                    ddlFFinishingUnit.DataValueField = "UnitId";
                    ddlFFinishingUnit.DataBind();
                    ddlFFinishingUnit.AppendDataBoundItems = false;
                    ddlFFinishingUnit.Items.Insert(0, new ListItem("-Select Unit-", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void txtFillOrderNo_TextChanged(object sender, EventArgs e)
        {

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

        protected void imgbtnWashingDetails_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

                Label lblId = (Label)grdWashingDetails.Rows[row.RowIndex].FindControl("lblId");
                Label lblOrderNo = (Label)grdWashingDetails.Rows[row.RowIndex].FindControl("lblOrderNo");
                Label lblBuyerID = (Label)grdWashingDetails.Rows[row.RowIndex].FindControl("lblBuyerID");
                Label lblCuttingID = (Label)grdWashingDetails.Rows[row.RowIndex].FindControl("lblCuttingID");
                Label lblSewingID = (Label)grdWashingDetails.Rows[row.RowIndex].FindControl("lblSewingID");
                Label lblOrder_Qty = (Label)grdWashingDetails.Rows[row.RowIndex].FindControl("lblOrderQty");
                Label lblGoodsName = (Label)grdWashingDetails.Rows[row.RowIndex].FindControl("lblFinishedGoodsName");
                Label lblFGoodsQty = (Label)grdWashingDetails.Rows[row.RowIndex].FindControl("lblFGoodsQty");
                Label lblFGoodsUnit = (Label)grdWashingDetails.Rows[row.RowIndex].FindControl("lblFGoodsUnit");
                Label lblTotalWashingCompleteQty = (Label)grdWashingDetails.Rows[row.RowIndex].FindControl("lblTotalWashingCompleteQty");
                Label lblTotalWashingCompleteUnit = (Label)grdWashingDetails.Rows[row.RowIndex].FindControl("lblTotalWashingCompleteUnit");

                Session["lblId"] = lblId.Text;
                txthidWashingID.Value = lblId.Text;

                txtOrderNoFill.Text = lblOrderNo.Text;

                Session["BuyerID"] = lblBuyerID.Text;
                txthidBuyer.Value = lblBuyerID.Text;

                Session["CuttingID"] = lblCuttingID.Text;
                txthidCuttingID.Value = lblCuttingID.Text;

                Session["SewingID"] = lblSewingID.Text;
                txthidSewingID.Value = lblSewingID.Text;

                txtOderQty.Text = lblOrder_Qty.Text;
                txtFinishGoods.Text = lblGoodsName.Text;
                txtFinishGoodsQty.Text = lblOrder_Qty.Text;
                txtFinishGoodsUnits.Text = lblFGoodsUnit.Text;

                txtCCompleteWashingQty.Text = lblTotalWashingCompleteQty.Text;
                txtCCompleteWashingunit.Text = lblTotalWashingCompleteUnit.Text;
                
                LoadFinishingDetails();
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
                Prod_Finishing _objProdFinishing = new Prod_Finishing();

                _objProdFinishing.CuttingID = Convert.ToInt32(txthidCuttingID.Value);
                _objProdFinishing.SewingID = Convert.ToInt32(txthidSewingID.Value);
                _objProdFinishing.WashingID = Convert.ToInt32(txthidWashingID.Value);
                _objProdFinishing.OrderNo = txtOrderNoFill.Text;
                _objProdFinishing.BuyerID = Convert.ToInt32(txthidBuyer.Value);
                _objProdFinishing.OrderQty = Convert.ToDouble(txtOderQty.Text);
                _objProdFinishing.GoodsName = txtFinishGoods.Text;
                _objProdFinishing.FGoodsQty = Convert.ToDouble(txtFinishGoodsQty.Text);
                _objProdFinishing.FGoodsUnit = txtFinishGoodsUnits.Text;
                _objProdFinishing.TotalWashingCompleteQty = Convert.ToDouble(txtCCompleteWashingQty.Text);
                _objProdFinishing.TotalWashingCompleteUnit = Convert.ToInt32(txtCCompleteWashingunit.Text);
                _objProdFinishing.TotalFinishingReceivedDate = Convert.ToDateTime(txtFinishingReceivedDate.Text);
                _objProdFinishing.TotalFinishingReceivedQty = Convert.ToDouble(txtFinishingReceivedQty.Text);
                _objProdFinishing.TotalFinishingReceivedUnit = Convert.ToInt32(ddlFFinishingUnit.SelectedValue.ToString());

                if (divCCDShow.Visible == true)
                {
                    _objProdFinishing.TotalFinishingCompleteDate = Convert.ToDateTime(txtFinishingCompleteDate.Text);
                }
                if (divCCQShow.Visible == true)
                {
                    _objProdFinishing.TotalFinishingCompleteQty = Convert.ToDouble(txtCCompleteFinishingQty.Text);
                    _objProdFinishing.TotalFinishingCompleteUnit = Convert.ToInt32(ddlTUnits.SelectedValue.ToString());
                }

                _objProdFinishing.Create_Date = DateTime.Now;
                _objProdFinishing.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                _objProdFinishing.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                if (btnSubmit.Text == "Submit")
                {
                    int result = _finishingbll.InsertProdFinishing(_objProdFinishing);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                    }
                }
                else
                {
                    _objProdFinishing.Edit_Date = DateTime.Now;
                    _objProdFinishing.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                    _objProdFinishing.ID = Convert.ToInt16(txthidID.Value);
                    int result = _finishingbll.UpdateProdFinishing(_objProdFinishing);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                        btnSubmit.Text = "Submit";
                    }
                }
                ClearUi();
                LoadWashingDetails();
                LoadFinishingDetails();
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
            txtCCompleteWashingQty.Text = "";
            txtCCompleteWashingunit.Text = "";
            txtFinishingReceivedDate.Text = "";
            txtFinishingReceivedQty.Text = "";
            ddlFFinishingUnit.ClearSelection();
            txtFinishingCompleteDate.Text = "";
            txtCCompleteFinishingQty.Text = "";
            ddlTUnits.ClearSelection();
        }

        private void LoadFinishingDetails()
        {
            try
            {
                if (txtFillOrderNo.Text == "")
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    List<FinishingDetailsR> result = _finishingbll.GetFinishingDetails(OCODE);
                    if (result.Count > 0)
                    {
                        grdFinishingDetails.DataSource = result.ToList();
                        grdFinishingDetails.DataBind();
                    }
                    else
                    {
                        var obj = new List<FinishingDetailsR>();
                        obj.Add(new FinishingDetailsR());

                        // Bind the DataTable which contain a blank row to the GridView
                        grdFinishingDetails.DataSource = obj;
                        grdFinishingDetails.DataBind();

                        int columnsCount = grdFinishingDetails.Columns.Count;
                        grdFinishingDetails.Rows[0].Cells.Clear();// clear all the cells in the row
                        grdFinishingDetails.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                        grdFinishingDetails.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell
                        grdFinishingDetails.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                        grdFinishingDetails.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                        grdFinishingDetails.Rows[0].Cells[0].Font.Bold = true;

                        //set No Results found to the new added cell
                        grdFinishingDetails.Rows[0].Cells[0].Text = "NO RECORDS FOUND FOR TODAY!";
                    }
                }
                else
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    string orderNo = txtFillOrderNo.Text;
                    List<FinishingDetailsR> orders = _finishingbll.GetFinishingDetailsByOrderNo(orderNo, OCODE);
                    if (orders.Count > 0)
                    {
                        grdFinishingDetails.DataSource = orders.ToList();
                        grdFinishingDetails.DataBind();
                    }
                    else
                    {
                        var obj = new List<FinishingDetailsR>();
                        obj.Add(new FinishingDetailsR());
                        // Bind the DataTable which contain a blank row to the GridView
                        grdFinishingDetails.DataSource = obj;
                        grdFinishingDetails.DataBind();

                        int columnsCount = grdFinishingDetails.Columns.Count;
                        grdFinishingDetails.Rows[0].Cells.Clear();// clear all the cells in the row
                        grdFinishingDetails.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                        grdFinishingDetails.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell
                        grdFinishingDetails.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                        grdFinishingDetails.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                        grdFinishingDetails.Rows[0].Cells[0].Font.Bold = true;

                        //set No Results found to the new added cell
                        grdFinishingDetails.Rows[0].Cells[0].Text = "NO RECORDS FOUND FOR !";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void imgbtnFinishingDetails_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

                Label lblId = (Label)grdFinishingDetails.Rows[row.RowIndex].FindControl("lblId");

                int fID = Convert.ToInt16(lblId.Text);

                Prod_Finishing _ID = _finishingbll.GetFinishingbyId(fID);
                if (_ID != null)
                {

                    txthidID.Value = _ID.ID.ToString();
                    txthidCuttingID.Value = _ID.CuttingID.ToString();
                    txthidSewingID.Value = _ID.SewingID.ToString();
                    txthidBuyer.Value = _ID.BuyerID.ToString();
                    txthidWashingID.Value = _ID.WashingID.ToString();
                    txtOrderNoFill.Text = _ID.OrderNo.ToString();
                    txtOderQty.Text = _ID.OrderQty.ToString();
                    txtFinishGoods.Text = _ID.GoodsName.ToString();
                    txtFinishGoodsQty.Text = _ID.FGoodsQty.ToString();
                    txtFinishGoodsUnits.Text = _ID.FGoodsUnit.ToString();
                    txtCCompleteWashingQty.Text = _ID.TotalWashingCompleteQty.ToString();
                    txtCCompleteWashingunit.Text = _ID.TotalWashingCompleteUnit.ToString();
                    txtFinishingReceivedDate.Text = _ID.TotalFinishingReceivedDate.ToString();
                    txtFinishingReceivedQty.Text = _ID.TotalFinishingReceivedQty.ToString();
                    ddlFFinishingUnit.Text = _ID.TotalFinishingReceivedUnit.ToString();
                    if (divCCDShow.Visible == true)
                    {
                        txtFinishingCompleteDate.Text = _ID.TotalFinishingCompleteDate.ToString();
                    }
                    if(divCCQShow.Visible==true)
                    {
                        txtCCompleteFinishingQty.Text = _ID.TotalFinishingCompleteQty.ToString();
                        ddlTUnits.Text = _ID.TotalFinishingCompleteUnit.ToString();
                    }
                    //ddlTUnits.Text = _ID.TotalWashingCompleteUnit.ToString();
                    
                    btnSubmit.Text = "Update";
                    divCCDShow.Visible = true;
                    divCCQShow.Visible = true;
                    txtFinishingReceivedDate.Enabled = false;
                    txtFinishingReceivedQty.ReadOnly = true;
                    ddlFFinishingUnit.Enabled = false;
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


