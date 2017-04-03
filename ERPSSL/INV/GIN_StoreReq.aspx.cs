using ERPSSL.INV.BLL;
using ERPSSL.INV.DAL.Repository;
using ERPSSL.INV.DAL;
using ERPSSL.Procurement.BLL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.INV
{
    public partial class GIN_StoreReq : System.Web.UI.Page
    {
        ERPSSL_INVEntities _context = new ERPSSL_INVEntities();
        IChallanBLL iChallanBll = new IChallanBLL();
        BuyBLL buyBll = new BuyBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    btnTransfer.Visible = false;
                    tGetAll_DistinctApprovedStoreReq();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        RequisionBll _requisionbll = new RequisionBll();
        private void tGetAll_DistinctApprovedStoreReq()
        {
            try
            {
                List<GINStoreReqR> ApprovedStoreReqes = _requisionbll.tGetAll_DistinctApprovedStoreReq();
                if (ApprovedStoreReqes.Count > 0)
                {
                    grdRequisition.DataSource = ApprovedStoreReqes;
                    grdRequisition.DataBind();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void imgSelect_Click(object sender, EventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
                Label lblReqNo = (Label)grdRequisition.Rows[row.RowIndex].FindControl("lblReqNo");
                Label lblDepartmentCode = (Label)grdRequisition.Rows[row.RowIndex].FindControl("lblDepartmentCode");
                Label lblEId = (Label)grdRequisition.Rows[row.RowIndex].FindControl("lblEID");

                string DepartmentCode = lblDepartmentCode.Text;
                hidGin.Value = GetGinID(DepartmentCode);
                hidEid.Value = lblEId.Text;
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode.ToString();
                string reqno = lblReqNo.Text;

                List<DeleveryProductR> ApprovedStoreReqes = _requisionbll.PRQ_GetSelectedProductToDeliverByReqNo(reqno, Ocode);
                if (ApprovedStoreReqes.Count > 0)
                {
                    grdstoreReqDelivery.DataSource = ApprovedStoreReqes;
                    grdstoreReqDelivery.DataBind();
                    btnTransfer.Visible = true;
                }
                else
                {
                    btnTransfer.Visible = false;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private string GetGinID(string DepartmentCode)
        {
            IChallanBLL aChallanBll = new IChallanBLL();
            DataTable dt = new DataTable();
            string Gin = "";
            Gin = aChallanBll.GetNewChalanNo(DepartmentCode, DateTime.Now, "DPT");
            return Gin;
        }

        protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerChkBox = ((CheckBox)grdstoreReqDelivery.HeaderRow.FindControl("headerLevelCheckBox"));

                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grdstoreReqDelivery.Rows)
                    {
                        Label lblBalance = ((Label)gvRow.FindControl("lblBalance"));

                        double balancequantity = Convert.ToDouble(lblBalance.Text);
                        if (balancequantity > 0)
                        {
                            CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                            rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox       
                        }
                        else
                        {
                            CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                            rowChkBox.Checked = false;//((CheckBox)sender).Checked;//for all row checkbox   
                        }
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grdstoreReqDelivery.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void rowLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                foreach (GridViewRow gvRow in grdstoreReqDelivery.Rows)
                {
                    CheckBox chk = (CheckBox)gvRow.FindControl("rowLevelCheckBox");

                    if (chk.Checked)
                    {
                        Label lblBalance = ((Label)gvRow.FindControl("lblBalance"));
                        if (lblBalance.Text != "")
                        {
                            double balancequantity = Convert.ToDouble(lblBalance.Text);
                            if (balancequantity <= 0)
                            {
                                CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                                rowChkBox.Checked = false;//((CheckBox)sender).Checked;//for all row checkbox       
                            }
                        }
                        else
                        {
                            CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                            rowChkBox.Checked = false;//((CheckBox)sender).Checked;//for all row checkbox    
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                IChallanBLL aChallanBll = new IChallanBLL();
                List<DeleveryProductR> deleveryProducts = new List<DeleveryProductR>();
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                bool status = true;
                bool CheckStatus = false;

                foreach (GridViewRow gvRow in grdstoreReqDelivery.Rows)
                {
                    CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                    if (rowChkBox.Checked == true)
                    {
                        CheckStatus = true;
                    }
                }

                if (CheckStatus)
                {
                    foreach (GridViewRow gvRow in grdstoreReqDelivery.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                        if (rowChkBox.Checked == true)
                        {
                            TextBox txtbxReceive = (TextBox)gvRow.FindControl("txtbxReceiveAmount");
                            if (txtbxReceive.Text != "")
                            {
                                Label lblLastRceceive = ((Label)gvRow.FindControl("lblLastReceive"));
                                double lastReceive = Convert.ToDouble(lblLastRceceive.Text);

                                double ReceiveQty = Convert.ToDouble(txtbxReceive.Text);

                                Label lblOrderQty = ((Label)gvRow.FindControl("lblHeadApproveQuanity"));
                                double Poqty = Convert.ToDouble(lblOrderQty.Text);

                                if (ReceiveQty == 0)
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Check Quantity!')", true);
                                    status = false;
                                    break;
                                }
                                else if (ReceiveQty + lastReceive > Poqty)
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Check Quantity!')", true);
                                    status = false;
                                    break;
                                }
                            }
                            else
                            {
                                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input Receive Qty!')", true);
                                status = false;
                                break;
                            }
                        }
                    }

                    if (status)
                    {
                        foreach (GridViewRow gvRow in grdstoreReqDelivery.Rows)
                        {
                            CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                            DeleveryProductR _aitem = new DeleveryProductR();

                            if (rowChkBox.Checked == true)
                            {
                                TextBox txtbxReceive = (TextBox)gvRow.FindControl("txtbxReceiveAmount");
                                TextBox txtRemarks = (TextBox)gvRow.FindControl("txtRemarks");

                                Label lblBarCode = ((Label)gvRow.FindControl("lblBarCode"));
                                Label lblDepartmentCOde = ((Label)gvRow.FindControl("lblDepartmentCode"));
                                Label lblReqNo = ((Label)gvRow.FindControl("lblDReqNo"));
                                Label lblID = ((Label)gvRow.FindControl("lblID"));

                                Label lblHeadApproveQuantity = ((Label)gvRow.FindControl("lblHeadApproveQuanity"));
                                double ApproveQty = Convert.ToDouble(lblHeadApproveQuantity.Text);

                                double ReceiveQty = Convert.ToDouble(txtbxReceive.Text);

                                Label lblLastRceceive = ((Label)gvRow.FindControl("lblLastReceive"));
                                double lastReceive = Convert.ToDouble(lblLastRceceive.Text);
                                Label lblProgramId = ((Label)gvRow.FindControl("lblProgramId"));
                                int ProgramId = Convert.ToInt32(lblProgramId.Text);

                                DropDownList ddlStoreList = (DropDownList)gvRow.FindControl("ddlStoreList");
                                DropDownList ddlStyle = (DropDownList)gvRow.FindControl("ddlStyle");
                                DropDownList ddlProgram = (DropDownList)gvRow.FindControl("ddlProgram");

                                if (ddlStoreList.SelectedValue != "0" && ddlStoreList.SelectedValue == "CNT")
                                {
                                    _aitem.StoreCode = ddlStoreList.SelectedValue.ToString();
                                    _aitem.HeadApproveQty = ReceiveQty;
                                    _aitem.BarCode = Convert.ToInt16(lblBarCode.Text);
                                    _aitem.ReqNo = lblReqNo.Text;
                                    _aitem.DeliveryType = "CentralToDepartment";
                                    _aitem.ChallanNo = aChallanBll.GetNewChalanNo(OCODE, DateTime.Now, "DPT");
                                    _aitem.TransferDate = DateTime.Now;
                                    _aitem.DPT_CODE = lblDepartmentCOde.Text;
                                    _aitem.EID = hidEid.Value;
                                    _aitem.ProgramId = ProgramId;
                                    _aitem.CurrentCompanyCode = "0";
                                    _aitem.ID = Convert.ToInt16(lblID.Text);
                                    _aitem.OldCompanyCode = ddlStoreList.SelectedValue.ToString(); //((SessionUser)Session["SessionUser"]).OCode.ToString();
                                    _aitem.OCode = ((SessionUser)Session["SessionUser"]).OCode.ToString();
                                    _aitem.StyleId = Convert.ToInt32(ddlStyle.SelectedValue);
                                    _aitem.Remarks = txtRemarks.Text;
                                }
                                else
                                {
                                    _aitem.StoreCode = ddlStoreList.SelectedValue.ToString();
                                    _aitem.HeadApproveQty = ReceiveQty;
                                    _aitem.BarCode = Convert.ToInt16(lblBarCode.Text);
                                    _aitem.ReqNo = lblReqNo.Text;
                                    _aitem.DeliveryType = "OthersToDepartment";
                                    _aitem.ChallanNo = hidGin.Value;
                                    _aitem.TransferDate = DateTime.Now;
                                    _aitem.DPT_CODE = lblDepartmentCOde.Text;
                                    _aitem.EID = hidEid.Value;
                                    _aitem.ProgramId = ProgramId;
                                    _aitem.CurrentCompanyCode = "0";
                                    _aitem.ID = Convert.ToInt16(lblID.Text);
                                    _aitem.OldCompanyCode = ddlStoreList.SelectedValue.ToString(); //((SessionUser)Session["SessionUser"]).OCode.ToString();
                                    _aitem.OCode = ((SessionUser)Session["SessionUser"]).OCode.ToString();
                                    _aitem.StyleId = Convert.ToInt32(ddlStyle.SelectedValue);
                                    _aitem.Remarks = txtRemarks.Text;
                                }

                                deleveryProducts.Add(_aitem);

                                if (lastReceive == 0 && ReceiveQty == Convert.ToDouble(lblHeadApproveQuantity.Text))
                                {
                                    string ReqNo = lblReqNo.Text;
                                    int Id = Convert.ToInt16(lblID.Text);
                                    aChallanBll.UpdateReqStatus(ReqNo, Id, ReceiveQty);
                                    // PurchaseOrderBll.PurchaseDone(aChallanBll);
                                    // PurchaseOrderBll.UpdateLastQty(id, ReceiveQty);
                                }
                                else if ((Convert.ToDouble(lblHeadApproveQuantity.Text) == ReceiveQty + Convert.ToDouble(lastReceive)))
                                {
                                    string ReqNo = lblReqNo.Text;
                                    int Id = Convert.ToInt16(lblID.Text);

                                    ReceiveQty = ReceiveQty + Convert.ToDouble(lastReceive);
                                    aChallanBll.UpdateReqStatus(ReqNo, Id, ReceiveQty);

                                    //PurchaseOrderBll.UpdateLastQty(id, ReceiveQty);
                                    // PurchaseOrderBll.PurchaseDone(id);
                                    // PurchaseOrderBll.UpdateLastQty(id, ReceiveQty);
                                }
                                else
                                {
                                    string ReqNo = lblReqNo.Text;
                                    int Id = Convert.ToInt16(lblID.Text);
                                    ReceiveQty = ReceiveQty + Convert.ToDouble(lastReceive);
                                    aChallanBll.UpdateReqStatusLastReceive(ReqNo, Id, ReceiveQty);
                                }
                            }
                        }
                        int result = aChallanBll.UpdateInvByCentral_FIFO(deleveryProducts);
                        // int result = aChallanBll.DeliverProductByRequisitionWithStore(deleveryProducts);
                        if (result == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('GIN Issued Successfully')", true);
                            tGetAll_DistinctApprovedStoreReq();
                            ResetgrdstoreReqDelivery();
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Item!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ResetgrdstoreReqDelivery()
        {
            grdstoreReqDelivery.DataSource = null;
            grdstoreReqDelivery.DataBind();
            btnTransfer.Visible = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtbxToDate.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input To Date!')", true);
                }
                else if (txtbxFromDate.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input From Date!')", true);
                }
                else
                {
                    IChallanBLL aChallanBll = new IChallanBLL();
                    DateTime Todate = Convert.ToDateTime(txtbxToDate.Text);
                    DateTime Fromdate = Convert.ToDateTime(txtbxFromDate.Text);
                    List<DeleveryProductR> DeleveryProductes = aChallanBll.GetDeleveryProductList(Todate, Fromdate);
                    if (DeleveryProductes.Count > 0)
                    {
                        GrdviewAfterDeiveryProduct.DataSource = DeleveryProductes;
                        GrdviewAfterDeiveryProduct.DataBind();
                    }
                    else
                    {
                        GrdviewAfterDeiveryProduct.DataSource = null;
                        GrdviewAfterDeiveryProduct.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void grdstoreReqDelivery_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                StoreBLL unitBll = new StoreBLL();

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    var row = unitBll.GetStorByOcode(((SessionUser)Session["SessionUser"]).OCode.ToString());
                    //Find the DropDownList in the Row
                    DropDownList ddlStoreList = (e.Row.FindControl("ddlStoreList") as DropDownList);
                    ddlStoreList.DataSource = row;
                    ddlStoreList.DataTextField = "StoreName";
                    ddlStoreList.DataValueField = "Store_Code";
                    ddlStoreList.DataBind();
                    ddlStoreList.Items.Insert(0, new ListItem("---Select---", "0"));

                    var result = iChallanBll.GetListProgram();
                    DropDownList ddlStyle = (e.Row.FindControl("ddlStyle") as DropDownList);
                    ddlStyle.DataSource = result;
                    ddlStyle.DataValueField = "ProgramID";
                    ddlStyle.DataTextField = "ProgramName";
                    ddlStyle.DataBind();
                    ddlStyle.Items.Insert(0, new ListItem("-Select Program-", "0"));
                }
            }
            catch (Exception)
            {

                throw;
            }

        }
        protected void ddlStyle_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList imgbtn = (DropDownList)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
                DropDownList ddlStyle = (DropDownList)grdstoreReqDelivery.Rows[row.RowIndex].FindControl("ddlStyle");
                int id = Convert.ToInt32(ddlStyle.SelectedValue);
                var result = iChallanBll.GetListProgram(id);
                DropDownList ddlProgram = (DropDownList)grdstoreReqDelivery.Rows[row.RowIndex].FindControl("ddlProgram");
                ddlProgram.DataSource = result;
                ddlProgram.DataValueField = "ScheduleID";
                ddlProgram.DataTextField = "BatchNo";
                ddlProgram.DataBind();
                ddlProgram.Items.Insert(0, new ListItem("Select Program", "0"));
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void ddlStoreList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DropDownList imgbtn = (DropDownList)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

                Label lblBarCode = (Label)grdstoreReqDelivery.Rows[row.RowIndex].FindControl("lblBarCode");
                string barcode = lblBarCode.Text;

                DropDownList ddlStoreList = (DropDownList)grdstoreReqDelivery.Rows[row.RowIndex].FindControl("ddlStoreList");
                //  DropDownList ddlProject = (DropDownList)row.FindControl("ddlProject");           
                string store = ddlStoreList.SelectedValue.ToString();
                if (ddlStoreList.SelectedValue == "CNT")
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    DataTable dt = iChallanBll.GetProductByBarCodeFromBy_Store(barcode, OCODE, store.ToString());
                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            Label lblBalance = (Label)row.FindControl("lblBalance");
                            lblBalance.Text = dr["BalanceQuanity"].ToString();
                        }
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Item Found!')", true);
                        Label lblBalance = (Label)row.FindControl("lblBalance");
                        lblBalance.Text = "0";
                    }
                }
                else
                {
                    var result = buyBll.GetProductBalance_InvBuy(barcode, ddlStoreList.SelectedValue.ToString());
                    if (result != null)
                    {
                        Label lblBalance = (Label)row.FindControl("lblBalance");
                        lblBalance.Text = (result.PrqBalanceQuanity).ToString();
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Item Found!')", true);
                        Label lblBalance = (Label)row.FindControl("lblBalance");
                        lblBalance.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
    }
}