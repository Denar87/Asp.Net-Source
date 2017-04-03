using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.BLL;
using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL;
using ERPSSL.Commercial.BLL;
using System.Data;
using Microsoft.Reporting.WebForms;
using ERPSSL.Commercial.DAL.Repository;

namespace ERPSSL.Commercial
{
    public partial class CreateInvoice : System.Web.UI.Page
    {
        ERPSSL.LC.BLL.OrderSheetBLL _orderSheetbll = new ERPSSL.LC.BLL.OrderSheetBLL();
        GroupBLL groupBll = new GroupBLL();

        ERPSSL_LCEntities _Context = new ERPSSL_LCEntities();

        InvoiceDAL _InvoiceDAL = new InvoiceDAL();
        CreateInvoiceBLL _CreateInvoiceBLL = new CreateInvoiceBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    FillSeason();
                    FillLCNo();
                    Fillbuyer();
                    //LoadOrderList();
                    showDiv.Visible = false;
                    showOrderList.Visible = false;

                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchOrderNo(string prefixText, int count)
        {
            using (var _context = new ERPSSL_LCEntities())
            {
                var AllOrder = from O in _context.LC_OrderEntry
                               where ((O.OrderNo.Contains(prefixText)))
                               select O;
                List<String> O_List = new List<String>();
                foreach (var O_No in AllOrder)
                {
                    O_List.Add(O_No.OrderNo);
                }
                return O_List;
            }
        }


        //private void LoadOrderList()
        //{
        //    try
        //    {
        //        string OCode = ((SessionUser)Session["SessionUser"]).OCode;
        //        var row = _orderSheetbll.GetOrderEntryList(OCode);
        //        if (row.Count > 0)
        //        {
        //            ddlPoOrder.DataSource = row.ToList();
        //            ddlPoOrder.DataTextField = "OrderNo";
        //            ddlPoOrder.DataValueField = "OrderNo";
        //            ddlPoOrder.DataBind();
        //            ddlPoOrder.AppendDataBoundItems = false;
        //            ddlPoOrder.Items.Insert(0, new ListItem("--Select Order--", "0"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private void Fillbuyer()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            var result = _InvoiceDAL.GetBuyer(ocode);
            if (result.Count > 0)
            {
                ddlBayer.DataSource = result;
                ddlBayer.DataTextField = "Buyer_Name";
                ddlBayer.DataValueField = "Buyer_ID";
                ddlBayer.DataBind();
                ddlBayer.AppendDataBoundItems = false;
                ddlBayer.Items.Insert(0, new ListItem("--Select Buyer--", "0"));
            }
        }

        private void FillSeason()
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_Season> row = _orderSheetbll.GetAllSeason(OCode);
                if (row != null)
                {
                    ddlSeason.DataSource = row.ToList();
                    ddlSeason.DataTextField = "Season_Name";
                    ddlSeason.DataValueField = "Season_Id";
                    ddlSeason.DataBind();
                    ddlSeason.Items.Insert(0, new ListItem("--Select Season--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //private void FillStyle(string season)
        //{
        //    try
        //    {
        //        string ocode = ((SessionUser)Session["SessionUser"]).OCode;
        //        var row = _orderSheetbll.GetOrderEntryBySeason(season);
        //        if (row.Count > 0)
        //        {

        //            ddlStyle.DataSource = row.ToList();                    
        //            ddlStyle.DataBind();
        //            ddlStyle.AppendDataBoundItems = false;
        //            ddlStyle.Items.Insert(0, new ListItem("--Select Item Category--", "0"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private void FillLCNo()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = _orderSheetbll.GetLCNo(ocode);
                if (row.Count > 0)
                {
                    ddlLCNo.DataSource = row.ToList();
                    ddlLCNo.DataTextField = "LCNo";
                    ddlLCNo.DataValueField = "LCNo";
                    ddlLCNo.DataBind();
                    ddlLCNo.AppendDataBoundItems = false;
                    ddlLCNo.Items.Insert(0, new ListItem("--Select Item Category--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillPoOrder(string season)
        {
            //try
            //{
            //    string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            //    var row = _orderSheetbll.GetOrderEntry_Season(season);
            //    if (row.Count > 0)
            //    {
            //        ddlPoOrder.DataSource = row.ToList();
            //        ddlPoOrder.DataTextField = "OrderNo";
            //        ddlPoOrder.DataValueField = "OrderNo";
            //        ddlPoOrder.DataBind();
            //        ddlPoOrder.AppendDataBoundItems = false;
            //        ddlPoOrder.Items.Insert(0, new ListItem("--Select Item Category--", "0"));
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}
        }

        //private void FillSeason(string PoOrder)
        //{
        //    try
        //    {
        //        string ocode = ((SessionUser)Session["SessionUser"]).OCode;
        //        var row = _orderSheetbll.GetOrderEntryByPoOrder(PoOrder);
        //        if (row.Count > 0)
        //        {
        //            ddlPoOrder.DataSource = row.ToList();
        //            ddlPoOrder.DataBind();
        //            ddlPoOrder.AppendDataBoundItems = false;
        //            ddlPoOrder.Items.Insert(0, new ListItem("--Select Item Category--", "0"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                #region Old Code Here
                //LC_Invoice_Create invoice = new LC_Invoice_Create();
                //invoice.BayerName = ddlBayer.SelectedValue.ToString();
                //invoice.Consignee = txtConsignee.Text;
                //invoice.NotifyParty = txtNotifyParty.Text;
                //invoice.ERCNo = txtERCNO.Text;
                //invoice.DT = Convert.ToDateTime(txtDt.Text);
                //invoice.VatReg = txtVatReg.Text;
                //invoice.InvoiceNo = txtInvoiceNo.Text;
                //invoice.InvoiceDate = Convert.ToDateTime(txtinvoiceDate.Text);
                //invoice.EXPNo = txtExpNo.Text;
                //invoice.EXPDate = Convert.ToDateTime(txtExpDate.Text);
                //invoice.LCNo = ddlLCNo.Text;
                //invoice.LCDate = Convert.ToDateTime(txtLCDate.Text);
                //invoice.IssuingBank = txtIssueBank.Text;
                //invoice.DeliveryAddress = txtDeliveryAddress.Text;
                //invoice.OriginatedCountry = txtOriginatedCountry.Text;
                //invoice.Destination = txtDestination.Text;
                //invoice.Season = ddlSeason.SelectedItem.Text;
                //invoice.OrderNo = ddlPoOrder.SelectedItem.Text;
                //invoice.Article = ddlArticle.SelectedItem.Text;
                //invoice.Style = ddlStyle.SelectedItem.Text;
                //invoice.Haldensleben = txtHealdensleben.Text;
                //invoice.CNo = txtCNo.Text;
                //invoice.TotalCTNS = Convert.ToDouble(txtTotalCTNS.Text);
                //invoice.GrossWGT = Convert.ToDouble(txtGROSSWGT.Text);
                //invoice.NetWGT = Convert.ToDouble(txtNETWGT.Text);
                //invoice.Cubic = Convert.ToDouble(txtCUBIC.Text);
                #endregion

                GenerateInvoiveCode();

                string InvoiceAutoCode = Convert.ToString(Session["InvoiceRefNo"]);

                string InvoiceNo = txtInvoiceNo.Text;
                double LessBonusP = Convert.ToDouble(txtLessBonus.Text);
                double LescPCRP = Convert.ToDouble(txtLessPRC.Text);
                double LessBonusT = Convert.ToDouble(lblLessBonus.Text);
                double LescPCRT = Convert.ToDouble(lblLessPRC.Text);
                double GrandTotal = Convert.ToDouble(lblGrandTotal.Text);
                double TotalCtns = Convert.ToDouble(txtTotalCtns.Text);
                double netWgt = Convert.ToDouble(txtNetWgt.Text);
                double grossWgt = Convert.ToDouble(txtGrssWgt.Text);
                double CubicCbm = Convert.ToDouble(txtCubicM.Text);

                int result = _CreateInvoiceBLL.Insert(InvoiceNo, LessBonusP, LescPCRP, LessBonusT, LescPCRT, GrandTotal, TotalCtns, netWgt, grossWgt, CubicCbm, InvoiceAutoCode);
                if (result == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                }
                btnPrint.Visible = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GenerateInvoiveCode()
        {
            try
            {
                string InvoiceRefNo = _CreateInvoiceBLL.GenerateNewInvoiveCodePerSecond();
                Session["InvoiceRefNo"] = InvoiceRefNo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Clear()
        {

        }

        protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DateTime day = DateTime.Today;
            //txtAutoOrderId.Text = _orderSheetbll.GetNewChalanNo("OPLC-", day, ddlSeason.Text.ToString());
            //FillArticle();
            //FillPoOrder(ddlSeason.SelectedItem.Text);
            //showOrderList.Visible = true;
            //var result = _orderSheetbll.GetOrderEntryBySeason(ddlSeason.SelectedItem.Text);
            //if (result.Count > 0)
            //{
            //    grdRequisition.DataSource = result;
            //    grdRequisition.DataBind();
            //}
        }
        //protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        CheckBox headerChkBox = ((CheckBox)grvOrder.HeaderRow.FindControl("headerLevelCheckBox"));

        //        if (headerChkBox.Checked == true)
        //        {
        //            foreach (GridViewRow gvRow in grvOrder.Rows)
        //            {
        //                CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
        //                rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
        //            }
        //        }
        //        else
        //        {
        //            foreach (GridViewRow gvRow in grvOrder.Rows)
        //            {
        //                CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
        //                rowChkBox.Checked = false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        protected void txtUSDRate_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = (TextBox)sender;
            GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
            TextBox textqty = (TextBox)gvRow.FindControl("txtQty");
            if (textqty.Text == "")
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Request Qty')", true);
                return;
            }
            Label lblTotalRs = (Label)gvRow.FindControl("lblValue");
            try
            {
                lblTotalRs.Text = ((Convert.ToDecimal(txt.Text)) * (Convert.ToDecimal(textqty.Text))).ToString();
            }
            catch { lblTotalRs.Text = "0"; txt.Text = "0"; }
        }

        //protected void ddlPoOrder_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    LoadStyle();
        //    //showOrderList.Visible = true;
        //    //FillArticle();
        //}

        private void LoadStyle()
        {
            try
            {
                string OrderNo = txtOrderNumber.Text;
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = _orderSheetbll.GetStyleList(OCode);
                if (row.Count > 0)
                {
                    ddlStyle.DataSource = row.ToList();
                    ddlStyle.DataTextField = "StyleName";
                    ddlStyle.DataValueField = "StyleId";
                    ddlStyle.DataBind();
                    ddlStyle.AppendDataBoundItems = false;
                    ddlStyle.Items.Insert(0, new ListItem("--Select Style--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillArticle()
        {
            try
            {
                int style_Id = Convert.ToInt32(ddlStyle.SelectedValue);
                string OrderNo = txtOrderNumber.Text;
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                TextBox txtbx = ((TextBox)grdorder.FindControl("txtHSCode"));
                List<Com_InvoiceR> result = _CreateInvoiceBLL.GetLCArticalByOrderNo(style_Id, OrderNo, OCode);

                if (result.Count > 0)
                {
                    var mn = result.First();
                    grdorder.DataSource = result;
                    grdorder.DataBind();
                }
                else
                {
                    grdorder.DataSource = null;
                    grdorder.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //protected void ddlArticle_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    var result = _orderSheetbll.GetLCOrderPlanning(ddlArticle.SelectedItem.Text);
        //    if (result.Count > 0)
        //    {
        //        var mn = result.First();
        //        gridOrderPlanning.DataSource = result;
        //        gridOrderPlanning.DataBind();


        //    }
        //    else
        //    {
        //        gridOrderPlanning.DataSource = null;
        //        gridOrderPlanning.DataBind();
        //    }
        //}

        protected void ddlLCNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = _orderSheetbll.GetbankInfo(ddlLCNo.SelectedItem.Text);
            if (result.Count > 0)
            {
                var row = result.First();
                txtIssueBank.Text = row.LC_Issue_Bank;
                txtLCDate.Text = row.DateofIssue.ToString();
            }
        }

        protected void ddlBayer_SelectedIndexChanged(object sender, EventArgs e)
        {
            var result = _InvoiceDAL.GetDataBayerWise(ddlBayer.SelectedItem.Text);
            if (result.Count > 0)
            {
                var row = result.First();
                txtConsignee.Text = row.Consignee;
                txtNotifyParty.Text = row.NotifyParty;
                txtDeliveryAddress.Text = row.Delivery_Address;
                txtDestination.Text = row.Destination_Address;
                txtOriginatedCountry.Text = row.Country;
                txtBuyingDept.Text = row.BuyerDepartment_Name;
            }
        }

        protected void grdorder_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void headerLevelCheckBox_CheckedChanged1(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerChkBox = ((CheckBox)grdorder.HeaderRow.FindControl("headerLevelCheckBox"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdorder.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdorder.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void grdorder_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    DropDownList ddlReqUnit = (e.Row.FindControl("ddlReqUnit") as DropDownList);
                    FillUnit(ddlReqUnit);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillUnit(DropDownList ddlReqUnit)
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                var result = _CreateInvoiceBLL.GetAllUnit(ddlReqUnit, OCode);
                if (result.Count > 0)
                {
                    ddlReqUnit.DataSource = result.ToList();
                    ddlReqUnit.DataTextField = "UnitName";
                    ddlReqUnit.DataValueField = "UnitId";
                    ddlReqUnit.DataBind();
                    ddlReqUnit.AppendDataBoundItems = false;
                    ddlReqUnit.Items.Insert(0, new ListItem("---Select One---", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                LC_Invoice_CreateTemp ObjCreateInvoice = new LC_Invoice_CreateTemp();
                List<LC_Invoice_CreateTemp> _LC_Invoice_CreateTemp = new List<LC_Invoice_CreateTemp>();

                //if (txtInvoiceNo.Text == "")
                //{
                //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Add Invoice Reference Number')", true);
                //    return;
                //}

                foreach (GridViewRow gvRow in grdorder.Rows)
                {
                    CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                    LC_Invoice_CreateTemp _InvoiceT = new LC_Invoice_CreateTemp();

                    if (rowChkBox.Checked == true)
                    {
                        Label lblOrderNo = ((Label)gvRow.FindControl("lblOrderNo"));
                        Label lblArticle = ((Label)gvRow.FindControl("lblArticle"));
                        Label lblColorSpecification = ((Label)gvRow.FindControl("lblColorSpecification"));
                        Label lblStyle = ((Label)gvRow.FindControl("lblStyle"));
                        Label lblOrderQuantity = ((Label)gvRow.FindControl("lblOrderQuantity"));

                        TextBox txtCAT = ((TextBox)gvRow.FindControl("txtCAT"));
                        TextBox txtHSCode = ((TextBox)gvRow.FindControl("txtHSCode"));

                        TextBox txtQty = ((TextBox)gvRow.FindControl("txtQty"));
                        DropDownList ddlReqUnit = ((DropDownList)gvRow.FindControl("ddlReqUnit"));

                        TextBox txtPrice = ((TextBox)gvRow.FindControl("txtPrice"));
                        DropDownList ddlCurrency = ((DropDownList)gvRow.FindControl("ddlCurrency"));

                        TextBox txtRate = ((TextBox)gvRow.FindControl("txtRate"));
                        Label lblAmount = ((Label)gvRow.FindControl("lblAmount"));

                        _InvoiceT.InvoiceNo = txtInvoiceNo.Text;
                        _InvoiceT.InvoiceDate = Convert.ToDateTime(txtinvoiceDate.Text);
                        _InvoiceT.BayerId = Convert.ToInt32(ddlBayer.SelectedValue.ToString());
                        _InvoiceT.Consignee = txtConsignee.Text;
                        _InvoiceT.NotifyParty = txtNotifyParty.Text;
                        _InvoiceT.EXPNo = txtExpNo.Text;
                        _InvoiceT.EXPDate = Convert.ToDateTime(txtExpDate.Text);
                        _InvoiceT.LCNo = ddlLCNo.SelectedItem.Text;
                        _InvoiceT.LCDate = Convert.ToDateTime(txtLCDate.Text);
                        _InvoiceT.IssuingBank = txtIssueBank.Text;
                        _InvoiceT.DeliveryAddress = txtDeliveryAddress.Text;
                        _InvoiceT.OriginatedCountry = txtOriginatedCountry.Text;
                        _InvoiceT.Destination = txtDestination.Text;
                        _InvoiceT.MarksNumbers = txtMarksNumbers.Text;
                        _InvoiceT.ContainerNo = ttxtContainerNo.Text;
                        _InvoiceT.BuyingDept = txtBuyingDept.Text;
                        _InvoiceT.NoKindofPackages = txtNoKindofPackages.Text;
                        _InvoiceT.Remarks = txtRemarks.Text;
                        _InvoiceT.Season = ddlSeason.SelectedItem.Text;
                        _InvoiceT.OrderNo = txtOrderNumber.Text;

                        _InvoiceT.OrderNo = lblOrderNo.Text;
                        _InvoiceT.Article = lblArticle.Text;
                        _InvoiceT.ColorSpecification = lblColorSpecification.Text;
                        _InvoiceT.Style = lblStyle.Text;
                        _InvoiceT.OrderQty = Convert.ToDouble(lblOrderQuantity.Text);
                        _InvoiceT.CAT_No = txtCAT.Text;
                        _InvoiceT.H_S_Code = txtHSCode.Text;
                        _InvoiceT.OrderQty = Convert.ToDouble(txtQty.Text);
                        _InvoiceT.UnitId = Convert.ToInt32(ddlReqUnit.SelectedValue);
                        _InvoiceT.UnitPrice = Convert.ToDouble(txtPrice.Text);
                        _InvoiceT.Currency_Type = ddlCurrency.SelectedValue;
                        _InvoiceT.Total = Convert.ToDouble(lblAmount.Text);

                        _InvoiceT.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                        _InvoiceT.EditDate = DateTime.Now;
                        _InvoiceT.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                        _InvoiceT.CreateDate = DateTime.Now;

                        int count = (from Bd in _Context.LC_OrderEntry
                                     where Bd.OrderNo == txtOrderNumber.Text
                                     select Bd.OrderNo).Count();
                        if (count > 0)
                        {
                            _LC_Invoice_CreateTemp.Add(_InvoiceT);
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Order No. Not Match')", true);
                            return;
                        }
                    }
                }

                if (_LC_Invoice_CreateTemp.Count > 0)
                {
                    //string type = drpEntryType.SelectedValue.ToString();
                    int result = _CreateInvoiceBLL.UpdateInvoiceTemp(_LC_Invoice_CreateTemp);
                    if (result == 1)
                    {
                        Clear();
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Added Successfully')", true);
                        string InvoiceNo = txtInvoiceNo.Text;
                        var result1 = _CreateInvoiceBLL.GetLCCreateInvoiceTemp(InvoiceNo);
                        if (result1.Count > 0)
                        {
                            var row = result1.First();
                            grdInvoice.DataSource = result1;
                            grdInvoice.DataBind();
                        }
                        else
                        {
                            grdInvoice.DataSource = null;
                            grdInvoice.DataBind();
                        }
                    }
                    showDiv.Visible = true;
                    Div1.Visible = true;
                    FillArticle();
                    btnSubmit.Visible = true;

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        decimal sumFooterValue = 0;
        protected void grdInvoice_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string totalAmount = e.Row.Cells[5].Text;
                    decimal grandTotal = Convert.ToDecimal(totalAmount);
                    sumFooterValue += grandTotal;
                }
                lblTotalCost.Text = sumFooterValue.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void txtLessBonus_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal totalAmount = Convert.ToDecimal(lblTotalCost.Text);
                decimal lessBonus = Convert.ToDecimal(txtLessBonus.Text);
                decimal TotalLessBouns = (totalAmount * lessBonus) / 100;
                lblLessBonus.Text = TotalLessBouns.ToString();
                Session["lessBonus"] = lblLessBonus.Text;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void txtLessPRC_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal totalAmount = Convert.ToDecimal(lblTotalCost.Text);
                decimal lessPRC = Convert.ToDecimal(txtLessPRC.Text);
                decimal TotalLessPRC = (totalAmount * lessPRC) / 100;
                lblLessPRC.Text = TotalLessPRC.ToString();

                decimal totalLess = Convert.ToDecimal(Session["lessBonus"]);

                decimal GramdTotal = totalAmount - (TotalLessPRC + totalLess);
                lblGrandTotal.Text = GramdTotal.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void txtPrice_TextChanged(object sender, EventArgs e)
        {
            try
            {
                TextBox txt = (TextBox)sender;
                GridViewRow gvRow = (GridViewRow)txt.Parent.Parent;
                TextBox textqty = (TextBox)gvRow.FindControl("txtQty");
                TextBox txtPrice = (TextBox)gvRow.FindControl("txtPrice");
                //TextBox txtRate = (TextBox)gvRow.FindControl("txtRate");

                if (textqty.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Request Qty')", true);
                    return;
                }
                Label lblAmount = (Label)gvRow.FindControl("lblAmount");
                lblAmount.Text = ((Convert.ToDecimal(textqty.Text)) * (Convert.ToDecimal(txtPrice.Text))).ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string InvoiceAutoCode = Convert.ToString(Session["InvoiceRefNo"]);
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;

                var _getRpt = _CreateInvoiceBLL.GetInvoiceReport(InvoiceAutoCode, OCode);
                if (_getRpt.Count > 0)
                {
                    ReportViewerInvoice.LocalReport.DataSources.Clear();
                    ReportDataSource reportDataset = new ReportDataSource("DS_Commercial", _getRpt);
                    ReportViewerInvoice.LocalReport.DataSources.Add(reportDataset);
                    ReportViewerInvoice.LocalReport.ReportPath = Server.MapPath("Report/Com_InvoiceReport.rdlc");
                    ReportViewerInvoice.LocalReport.Refresh();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void txtTotalCtns_TextChanged(object sender, EventArgs e)
        {
            lblTotalCtns.Text = txtTotalCtns.Text + " CTNs";
        }

        protected void txtGrssWgt_TextChanged(object sender, EventArgs e)
        {
            lblGrssWgt.Text = txtGrssWgt.Text + " KGs";
        }

        protected void txtNetWgt_TextChanged(object sender, EventArgs e)
        {
            lblNetWgt.Text = txtNetWgt.Text + " KGs";
        }

        protected void txtCubicM_TextChanged(object sender, EventArgs e)
        {
            lblCubic.Text = txtCubicM.Text + " CBM";
        }

        protected void ddlStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            showOrderList.Visible = true;
            FillArticle();
        }

        protected void txtOrderNumber_TextChanged(object sender, EventArgs e)
        {

            LoadStyle();
        }
    }
}