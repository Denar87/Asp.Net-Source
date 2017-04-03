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
    public partial class Sewing : System.Web.UI.Page
    {
        CuttingBLL _cuttingbll = new CuttingBLL();

        SewingBLL _sewingbll = new SewingBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    LoadCuttingDetails();
                    Fillunit();
                    LoadSewingDetails();
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
            try
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchAllOrderNoCutting(string prefixText, int count)
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

        private void LoadCuttingDetails()
        {
            if (txtFillOrderNo.Text == "")
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<CuttingDetailsR> result = _sewingbll.GetCuttingDetails(OCODE);
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
                string orderNo = txtFillOrderNo.Text;
                List<CuttingDetailsR> orders = _sewingbll.GetCuttingDetailsByOrderNo(orderNo, OCODE);
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

        private void Fillunit()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = _cuttingbll.GetUnitForMarchandising();
                if (row.Count > 0)
                {
                    ddlSewingUnit.DataSource = row.ToList();
                    ddlSewingUnit.DataTextField = "UnitName";
                    ddlSewingUnit.DataValueField = "UnitId";
                    ddlSewingUnit.DataBind();
                    ddlSewingUnit.AppendDataBoundItems = false;
                    ddlSewingUnit.Items.Insert(0, new ListItem("-Select Unit-", "0"));
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

        protected void imgbtnCuttingDetails_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

                Label lblId = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblId");
                
                Label lblBuyerID = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblBuyerID");
                Label lblOrderNo = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblOrderNo");
                //Label lblCuttingID = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblCuttingID");
                Label lblOrder_Qty = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblOrderQty");
                Label lblGoodsName = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblFinishedGoodsName");
                Label lblFGoodsQty = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblFGoodsQty");
                Label lblFGoodsUnit = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblFGoodsUnit");
                Label lblCuttingReceivedDate = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblCuttingReceivedDate");
                Label lblCuttingReceivedQty = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblCuttingReceivedQty");
                Label lblCuttingReceivedUnit = (Label)grdCuttingDetails.Rows[row.RowIndex].FindControl("lblCuttingReceivedUnit");


                Session["lblId"] = lblId.Text;
                txthidCuttingID.Value = lblId.Text;
                
                Session["Buyer_ID"] = lblBuyerID.Text;
                txthidBuyer.Value = lblBuyerID.Text;
                
                txtOrderNoFill.Text = lblOrderNo.Text;
                //Session["CuttingID"] = lblCuttingID.Text;
                //txthidCuttingID.Value = lblCuttingID.Text;
                txtOderQty.Text = lblOrder_Qty.Text;
                txtFinishGoods.Text = lblGoodsName.Text;
                txtFinishGoodsQty.Text = lblOrder_Qty.Text;
                txtFinishGoodsUnits.Text = lblFGoodsUnit.Text;
                txtReceivedQty.Text = lblCuttingReceivedQty.Text;
                txtReceivedUnit.Text = lblCuttingReceivedUnit.Text;

                //int cID = Convert.ToInt16(lblId.Text);
                //Prod_Cutting _ID = _cuttingbll.GetCuttingbyId(cID);
                //if (_ID != null)
                //{

                //txthidID.Value = _ID.ID.ToString();
                //txtOrderNoFill.Text = _ID.OrderNo.ToString();

                //txtOderQty.Text = _ID.OrderQty.ToString();
                //txtFinishGoods.Text = _ID.GoodsName.ToString();
                //txtFinishGoodsQty.Text = _ID.FGoodsQty.ToString();
                //txtUnits.Text = _ID.FGoodsUnit.ToString();
                //txtCuttingReceivedDate.Text = _ID.CuttingReceivedDate.ToString();
                //txtCuttingReceivedQty.Text = _ID.CuttingReceivedQty.ToString();
                //ddlUnit.Text = _ID.CuttingReceivedUnit.ToString();
                //txtCuttingCompleteDate.Text = _ID.CuttingCompleteDate.ToString();
                //txtCCompleteCuttingQty.Text = _ID.TotalCuttingCompleteQty.ToString();
                ////ddlTUnits.Text = _ID.TotalCuttingCompleteUnit.ToString();

                //btnSubmit.Text = "Update";
                //divCCDShow.Visible = true;
                //divCCQShow.Visible = true;
                //}
                //FillTotalunit();

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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                Prod_Sewing _objProdSewing = new Prod_Sewing();
                _objProdSewing.CuttingID = Convert.ToInt32(txthidCuttingID.Value);
                _objProdSewing.OrderNo = txtOrderNoFill.Text;
                _objProdSewing.BuyerID = Convert.ToInt32(txthidBuyer.Value);
                
                _objProdSewing.OrderQty = Convert.ToDouble(txtOderQty.Text);
                _objProdSewing.GoodsName = txtFinishGoods.Text;
                _objProdSewing.FGoodsQty = Convert.ToDouble(txtFinishGoodsQty.Text);
                _objProdSewing.FGoodsUnit = txtFinishGoodsUnits.Text;
                _objProdSewing.TotalCuttingCompleteQty = Convert.ToDouble(txtReceivedQty.Text);
                _objProdSewing.TotalCuttingCompleteUnit = txtReceivedUnit.Text;
                _objProdSewing.SewingReceivedDate = Convert.ToDateTime(txtSewingReceivedDate.Text);
                _objProdSewing.TotalSewingReceivedQty = Convert.ToDouble(txtSewingReceivedQty.Text);
                _objProdSewing.TotalSewingReceivedUnit = Convert.ToInt32(ddlSewingUnit.SelectedValue.ToString());

                if (divCCDShow.Visible == true)
                {
                    _objProdSewing.SewingCompleteDate = Convert.ToDateTime(txtSewingReceivedDate.Text);
                }
                if (divCCQShow.Visible == true)
                {
                    _objProdSewing.TotalSewingCompleteQty = Convert.ToDouble(txtCCompleteSewingQty.Text);
                    _objProdSewing.TotalSewingCompleteUnit = Convert.ToInt32(ddlTUnits.SelectedValue.ToString());
                }

                _objProdSewing.Create_Date = DateTime.Now;
                _objProdSewing.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                _objProdSewing.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                if (btnSubmit.Text == "Submit")
                {
                    int result = _sewingbll.InsertProdSewing(_objProdSewing);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                    }
                }
                else
                {
                    _objProdSewing.Edit_Date = DateTime.Now;
                    _objProdSewing.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                    _objProdSewing.ID = Convert.ToInt16(txthidID.Value);
                    int result = _sewingbll.UpdateProdCutting(_objProdSewing);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                        btnSubmit.Text = "Submit";
                    }
                }
                LoadCuttingDetails();
                LoadSewingDetails();
                ClearUi();
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
            txtSewingReceivedDate.Text = "";
            txtSewingReceivedQty.Text = "";
            txtReceivedUnit.Text = "";
            txtSewingCompleteDate.Text = "";
            txtSewingReceivedQty.Text = "";
            ddlTUnits.ClearSelection();
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

        protected void imgbtnSewingDetails_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

                Label lblId = (Label)grdSewingDetails.Rows[row.RowIndex].FindControl("lblId");
                
                int sID = Convert.ToInt16(lblId.Text);

                Prod_Sewing _ID = _sewingbll.GetCuttingbyId(sID);
                if (_ID != null)
                {

                    txthidID.Value = _ID.ID.ToString();
                    txthidCuttingID.Value = _ID.CuttingID.ToString();
                    txthidBuyer.Value = _ID.BuyerID.ToString();
                    txtOrderNoFill.Text = _ID.OrderNo.ToString();
                    txtOderQty.Text = _ID.OrderQty.ToString();
                    txtFinishGoods.Text = _ID.GoodsName.ToString();
                    txtFinishGoodsQty.Text = _ID.FGoodsQty.ToString();
                    txtFinishGoodsUnits.Text = _ID.FGoodsUnit.ToString();
                    txtReceivedQty.Text = _ID.TotalCuttingCompleteQty.ToString();
                    txtReceivedUnit.Text = _ID.TotalCuttingCompleteUnit.ToString();
                    txtSewingReceivedDate.Text = _ID.SewingReceivedDate.ToString();
                    txtSewingReceivedQty.Text = _ID.TotalSewingReceivedQty.ToString();
                    ddlSewingUnit.Text = _ID.TotalSewingReceivedUnit.ToString();
                    
                    txtSewingCompleteDate.Text = _ID.SewingCompleteDate.ToString();
                    txtCCompleteSewingQty.Text = _ID.TotalSewingCompleteQty.ToString();
                    //ddlTUnits.Text = _ID.TotalSewingCompleteUnit.ToString();

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
    }
}


