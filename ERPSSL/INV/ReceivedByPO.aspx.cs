using ERPSSL.INV.BLL;
using ERPSSL.INV.DAL;
using ERPSSL.INV.DAL.Repository;
using ERPSSL.Procurement.BLL;
//using ERPSSL.Procurement.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.LC.DAL;
using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL.Repository;
using ERPSSL.Procurement.BLL;
using ERPSSL.INV.BLL;
using ERPSSL.INV.DAL.Repository;

namespace ERPSSL.INV
{
    public partial class ReceivedByPO : System.Web.UI.Page
    {
        PurchaseOrderBll _purchaseOrderbll = new PurchaseOrderBll();
        RChallanBLL rChallanBll = new RChallanBLL();
        PurchaseOrderBll purchaseOrderBll = new PurchaseOrderBll();
        //Inv_StoreBLL companyBll = new Inv_StoreBLL();
        BuyCentralBLL buyCentralBll = new BuyCentralBLL();
        BuyBLL buyBll = new BuyBLL();
        //Inv_StoreBLL companyBll = new Inv_StoreBLL();

        MasterLCBLL aMasterLCBLL = new MasterLCBLL();
        LC_RequisitionBLL aLC_RequisitionBLL = new LC_RequisitionBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetApproveDistinctPO();
                    //FillCompany();
                    btnTransfer.Visible = false;
                    lblpro.Visible = false;
                    //  GetAllProject();
                    //  GetAllStore();
                    // GetAllStoreUnit();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        //private void GetAllStoreUnit()
        //{
        //    StoreUnitBLL aStoreUnitBLL = new StoreUnitBLL();
        //    try
        //    {
        //        var row = aStoreUnitBLL.GetAllStoreUnit(((SessionUser)Session["SessionUser"]).OCode);
        //        if (row.Count > 0)
        //        {
        //            ddlStoreUnit.DataSource = row.ToList();
        //            ddlStoreUnit.DataTextField = "Store_Unit_Name";
        //            ddlStoreUnit.DataValueField = "Store_Unit_Id";
        //            ddlStoreUnit.DataBind();
        //            ddlStoreUnit.Items.Insert(0, new ListItem("---Select One---", "0"));
        //        }

        //    }
        //    catch
        //    {

        //    }
        //}

        //private void GetAllStore()
        //{
        //    StoreBLL aStoreBll = new StoreBLL();
        //    try
        //    {
        //        var row = aStoreBll.GetAllStoreLocation(((SessionUser)Session["SessionUser"]).OCode);
        //        if (row.Count > 0)
        //        {
        //            ddlStoreName.DataSource = row.ToList();
        //            ddlStoreName.DataTextField = "StoreName";
        //            ddlStoreName.DataValueField = "Store_Code";
        //            ddlStoreName.DataBind();
        //            ddlStoreName.Items.Insert(0, new ListItem("---Select One---", "0"));
        //        }

        //    }
        //    catch
        //    {

        //    }
        //}
        //protected void GetAllProject()
        //{
        //    try
        //    {
        //        ProjectBLL projectBll = new ProjectBLL();
        //        var row = projectBll.GetAllProject();
        //        if (row.Count > 0)
        //        {
        //            ddlProject.DataSource = row.ToList();
        //            ddlProject.DataTextField = "Project_Name";
        //            ddlProject.DataValueField = "Project_Code";
        //            ddlProject.DataBind();
        //            ddlProject.Items.Insert(0, new ListItem("---Select One---", "0"));
        //        }

        //    }
        //    catch
        //    {

        //    }
        //}

        //public void FillCompany()
        //{
        //    DataTable dt = new DataTable();
        //    dt = companyBll.GetCentralCompany();

        //    ddlCompanyCode.DataSource = dt;
        //    ddlCompanyCode.DataValueField = "CompanyCode";
        //    ddlCompanyCode.DataTextField = "CompanyCode";
        //    ddlCompanyCode.DataBind();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        HiddenCompanyName.Value = dr["CompanyName"].ToString();
        //        HiddenCompanyCode.Value = dr["CompanyCode"].ToString();
        //    }
        //}

        private void GetApproveDistinctPO()
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            //List<POReceivedR> PoReceivedPOes = _purchaseOrderbll.GetApproveDistinctPO(OCODE);

            var result = aMasterLCBLL.Get_All_PO_EstimatedSummaryList(OCODE).Where(x => x.IsPO_Approved == true).ToList();

            if (result.Count > 0)
            {
                grdPOList.DataSource = result;
                grdPOList.DataBind();
            }
            else
            {
                grdPOList.DataSource = null;
                grdPOList.DataBind();
            }
        }

        private void ColorRestInGridview()
        {
            foreach (GridViewRow gvRow in grdPOList.Rows)
            {
                GridViewRow row = (GridViewRow)gvRow;
                row.BackColor = Color.White;
            }
        }

        protected void imgSelect_Click(object sender, EventArgs e)
        {
            try
            {
                ColorRestInGridview();
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
                Label lblProNo = (Label)grdPOList.Rows[row.RowIndex].FindControl("lblPONo");
                string PONo = lblProNo.Text;
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                //List<PO_View> ApprovepoItems = _purchaseOrderbll.GetApprovedPOItemByPONOforMRR(PONo);

                List<Rep_Estimate> lstRep_Estimate = new List<Rep_Estimate>();
                lstRep_Estimate = aLC_RequisitionBLL.Get_AllPODetails(PONo, OCODE);

                if (lstRep_Estimate.Count > 0)
                {
                    row.BackColor = Color.MistyRose;
                    grvPOItemList.DataSource = lstRep_Estimate;
                    grvPOItemList.DataBind();
                    btnTransfer.Visible = true;
                    lblpro.Visible = true;
                }
                else
                {
                    row.BackColor = Color.White;
                    btnTransfer.Visible = false;
                    btnTransfer.Visible = false;
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
                foreach (GridViewRow gvRow in grvPOItemList.Rows)
                {
                    CheckBox chk = (CheckBox)gvRow.FindControl("rowLevelCheckBox");

                    if (chk.Checked)
                    {
                        TextBox lblBalanceQuantity = ((TextBox)gvRow.FindControl("txtbxReceiveAmount"));
                        if (lblBalanceQuantity.Text != "")
                        {

                            double balancequantity = Convert.ToDouble(lblBalanceQuantity.Text);
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

        protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                CheckBox headerChkBox = ((CheckBox)grvPOItemList.HeaderRow.FindControl("headerLevelCheckBox"));
                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in grvPOItemList.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox     
                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in grvPOItemList.Rows)
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

        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                bool status = true;
                bool CheckStatus = false;

                foreach (GridViewRow gvRow in grvPOItemList.Rows)
                {
                    CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                    if (rowChkBox.Checked == true)
                    {
                        CheckStatus = true;
                    }
                }

                if (CheckStatus)
                {
                    foreach (GridViewRow gvRow in grvPOItemList.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                        if (rowChkBox.Checked == true)
                        {
                            TextBox txtbxReceive = (TextBox)gvRow.FindControl("txtbxReceiveAmount");
                            if (txtbxReceive.Text != "")
                            {
                                //Label lblLastRceceive = ((Label)gvRow.FindControl("lblLastReceive"));
                                //double lastReceive = Convert.ToDouble(lblLastRceceive.Text);

                                double ReceiveQty = Convert.ToDouble(txtbxReceive.Text);

                                Label lblOrderQty = ((Label)gvRow.FindControl("lblOrderQty"));
                                double Poqty = Convert.ToDouble(lblOrderQty.Text);

                                if (ReceiveQty == 0)
                                {
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Check Quantity!')", true);
                                    status = false;
                                    break;
                                }
                                //else if (ReceiveQty + lastReceive > Poqty)
                                //{
                                //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Check Quantity!')", true);
                                //    status = false;
                                //    break;
                                //}
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
                        foreach (GridViewRow gvRow in grvPOItemList.Rows)
                        {
                            CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                            if (rowChkBox.Checked == true)
                            {
                                Label lbl = ((Label)gvRow.FindControl("lblID"));

                                Label lblPO = ((Label)gvRow.FindControl("lblPONo"));

                                Label lblOrderQty = ((Label)gvRow.FindControl("lblOrderQty"));
                                Label lblStyleAndSize = ((Label)gvRow.FindControl("lblStyleAndSize"));


                                TextBox txtbxReceive = (TextBox)gvRow.FindControl("txtbxReceiveAmount");
                                double ReceiveQty = Convert.ToDouble(txtbxReceive.Text);

                                DropDownList ddlStoreName = (DropDownList)gvRow.FindControl("ddlStoreName");

                                //Label lblLastRceceive = ((Label)gvRow.FindControl("lblLastReceive"));
                                //double lastReceive = Convert.ToDouble(lblLastRceceive.Text);
                                TextBox txtRemarks = (TextBox)gvRow.FindControl("txtRemarks");
                                string ItemsRemark = txtRemarks.Text;

                                //for new product

                                int Id = Convert.ToInt16(lbl.Text);
                                //if (IsExist(Id))
                                //{
                                //    ProductBLL _productBll = new ProductBLL();
                                //    LC_PurchaseOrder purchaseorder = aLC_RequisitionBLL.GetPurchaseOrderById(Id);

                                //if (!IsExist(purchaseorder))
                                //{
                                //    Inv_Product _productObj = new Inv_Product();
                                //    _productObj.ProductName = purchaseorder.ProductName;
                                //    _productObj.StyleAndSize = purchaseorder.StyleAndSize;
                                //    _productObj.ReOrderQty = 0;
                                //    _productObj.Price = purchaseorder.Price;
                                //    _productObj.Brand = "HB";
                                //    _productObj.GroupId = purchaseorder.GroupId;
                                //    _productObj.UnitId = purchaseorder.UnitId;
                                //    _productObj.UnitName = purchaseorder.UnitName;
                                //    _productObj.EditDate = DateTime.Now;
                                //    _productObj.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                                //    _productObj.OCode = ((SessionUser)Session["SessionUser"]).OCode.ToString();
                                //    int productId = _productBll.InsertProductAndGetID(_productObj);
                                //    if (productId > 0)
                                //    {
                                //        _purchaseOrderbll.UpdatePurchaseOrder(Id, productId);

                                //    }
                                //}
                                //}

                                string CType = "CENTRAL";
                                if (CType == "CENTRAL")
                                {
                                    LC_PurchaseOrder purchaseorder = aLC_RequisitionBLL.GetPurchaseOrderById(Id);

                                    //if (purchaseorder.ItemType == "New Item")
                                    //{
                                    //    string productName = purchaseorder.ProductName.ToString();
                                    //    string StyleandSize = purchaseorder.StyleAndSize.ToString();
                                    //    Inv_Product _invProduct = _purchaseOrderbll.GetProductByProductNameandStyle(productName, StyleandSize);
                                    //    //   Inv_Product _invProduct = _purchaseOrderbll.GetProductByProductId(Convert.ToInt32(purchaseorder.BarCode));
                                    //    string id = Convert.ToString(Id);
                                    //    string ChalanNo = GetChalanNo(id);
                                    //    Inv_BuyCentral buyCentral = buyCentralBll.GetBuyCentralByCompanyAndBarcode(hdnBarCode.Value, ddlCompanyCode.SelectedValue);
                                    //    if (buyCentral == null)
                                    //    { // Insert New
                                    //        Inv_BuyCentral newBuyCentral = new Inv_BuyCentral();
                                    //        newBuyCentral.ChallanNo = ChalanNo;
                                    //        //newBuyCentral.CompanyId = Convert.ToInt32(ddlCompanyCode.SelectedValue);
                                    //        newBuyCentral.CompanyCode = HiddenCompanyCode.Value;
                                    //        newBuyCentral.CompanyName = HiddenCompanyName.Value;
                                    //        newBuyCentral.BarCode = _invProduct.ProductId.ToString();
                                    //        newBuyCentral.ProductId = _invProduct.ProductId;
                                    //        newBuyCentral.ProductGroup = _invProduct.GroupId;
                                    //        newBuyCentral.ProductName = _invProduct.ProductName;
                                    //        newBuyCentral.Brand = _invProduct.Brand;
                                    //        newBuyCentral.Item_Remarks = ItemsRemark;
                                    //        //-------------------------------------------------------------
                                    //        //if (ddlProject.SelectedValue != "0")
                                    //        //{
                                    //        //    newBuyCentral.Project_Code = ddlProject.SelectedValue;
                                    //        //}

                                    //        if (ddlStoreName.SelectedValue != "0")
                                    //        {
                                    //            newBuyCentral.Store_Code = ddlStoreName.SelectedValue.ToString();
                                    //        }

                                    //        //if (ddlStoreUnit.SelectedValue != "0")
                                    //        //{
                                    //        //    newBuyCentral.Store_Unit_Id = Convert.ToInt16(ddlStoreUnit.SelectedValue);
                                    //        //}

                                    //        //DropDownList drpumCheck = (DropDownList)gvRow.FindControl("drpumCkeck");
                                    //        //DropDownList drpRecieptCondition = (DropDownList)gvRow.FindControl("ddlRecieptCondition");

                                    //        newBuyCentral.StyleSize = _invProduct.StyleAndSize;
                                    //        //newBuyCentral.FloorName = rchallan.FloorName;
                                    //        newBuyCentral.UnitName = _invProduct.UnitName;
                                    //        newBuyCentral.ReceiveQuantity = ReceiveQty;// Convert.ToInt32(purchaseorder.OrderedQty);
                                    //        //newBuyCentral.CPU = rchallan.CPU;
                                    //        //newBuyCentral.RPU = rchallan.RPU;
                                    //        //newBuyCentral.ExpireDate = rchallan.ExpireDate;
                                    //        newBuyCentral.BalanceQuanity = ReceiveQty;//Convert.ToInt32(purchaseorder.OrderedQty);
                                    //        try
                                    //        {
                                    //            newBuyCentral.PurchaseDate = DateTime.Now;
                                    //        }
                                    //        catch
                                    //        {
                                    //            newBuyCentral.PurchaseDate = DateTime.Today;
                                    //        }

                                    //        newBuyCentral.EditDate = DateTime.Now;
                                    //        newBuyCentral.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                                    //        newBuyCentral.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                                    //        buyCentralBll.Insert(newBuyCentral);
                                    //    }

                                    //    else
                                    //    {
                                    //        buyCentral.BalanceQuanity = buyCentral.BalanceQuanity + ReceiveQty;// Convert.ToInt32(purchaseorder.OrderedQty);
                                    //        //buyCentral.CPU = rchallan.CPU;
                                    //        //buyCentral.RPU = rchallan.RPU;
                                    //        //buyCentral.ExpireDate = rchallan.ExpireDate;
                                    //        buyCentral.ReceiveQuantity = buyCentral.ReceiveQuantity + ReceiveQty;// Convert.ToInt32(purchaseorder.OrderedQty);
                                    //        buyCentralBll.Update(buyCentral, Convert.ToInt32(buyCentral.Id));
                                    //    }
                                    //    //}
                                    //    Inv_RChallan rchallan = new Inv_RChallan();
                                    //    rchallan.ChallanNo = ChalanNo;
                                    //    rchallan.PO_No = lblPO.Text;
                                    //    rchallan.ChallanDate = DateTime.Now;
                                    //    //   rchallan.CompanyId = Convert.ToInt32(ddlCompanyCode.SelectedValue);
                                    //    rchallan.CompanyCode = HiddenCompanyCode.Value;
                                    //    rchallan.CompanyName = HiddenCompanyName.Value;
                                    //    rchallan.Barcode = hdnBarCode.Value;
                                    //    rchallan.ProductId = _invProduct.ProductId;
                                    //    rchallan.ProductGroup = _invProduct.GroupId;
                                    //    rchallan.ProductName = _invProduct.ProductName;
                                    //    rchallan.Brand = _invProduct.Brand;
                                    //    rchallan.Remarks = ItemsRemark;

                                    //    //if (ddlProject.SelectedValue != "0")
                                    //    //{

                                    //    //    rchallan.Project_Code = ddlProject.SelectedValue;
                                    //    //}

                                    //    if (ddlStoreName.SelectedValue != "0")
                                    //    {
                                    //        rchallan.Store_Code = ddlStoreName.SelectedValue.ToString();
                                    //    }
                                    //    //if (ddlStoreUnit.SelectedValue != "0")
                                    //    //{
                                    //    //    rchallan.Store_Unit_Id = Convert.ToInt16(ddlStoreUnit.SelectedValue);
                                    //    //}

                                    //    //DropDownList drpumCheck1 = (DropDownList)gvRow.FindControl("drpumCkeck");
                                    //    //DropDownList drpRecieptConditio1n = (DropDownList)gvRow.FindControl("ddlRecieptCondition");

                                    //    //if (drpumCheck1.SelectedValue != "0")
                                    //    //{
                                    //    //    rchallan.Unit_Cheked = drpumCheck1.SelectedItem.Text;
                                    //    //}

                                    //    //if (drpRecieptConditio1n.SelectedValue != "0")
                                    //    //{
                                    //    //    rchallan.Reciept_Condition = drpRecieptConditio1n.SelectedItem.Text;
                                    //    //}

                                    //    //rchallan.StyleSize = rchallan.StyleSize;
                                    //    //rchallan.FloorName = rchallan.FloorName;
                                    //    rchallan.UnitName = _invProduct.UnitName;
                                    //    rchallan.ReceiveQuantity = ReceiveQty;// Convert.ToInt32(purchaseorder.OrderedQty);
                                    //    //rchallan.CPU = rchallan.CPU;
                                    //    //rchallan.RPU = rchallan.RPU;
                                    //    //rchallan.ExpireDate = rchallan.ExpireDate;
                                    //    rchallan.BalanceQty = ReceiveQty;// Convert.ToInt32(purchaseorder.OrderedQty);
                                    //    try
                                    //    {
                                    //        rchallan.PurchaseDate = DateTime.Today;
                                    //    }
                                    //    catch
                                    //    {
                                    //        rchallan.PurchaseDate = DateTime.Today;
                                    //    }

                                    //    rchallan.EditDate = DateTime.Now;
                                    //    rchallan.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                                    //    rchallan.Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                                    //    rChallanBll.Insert(rchallan);
                                    //    //  string Po = lblPO.Text;

                                    //    if (lastReceive == 0 && ReceiveQty == Convert.ToDouble(lblOrderQty.Text))
                                    //    {

                                    //        PurchaseOrderBll.PurchaseDone(id);
                                    //        // PurchaseOrderBll.UpdateLastQty(id, ReceiveQty);
                                    //    }
                                    //    else if ((Convert.ToInt16(lblOrderQty.Text) == ReceiveQty + Convert.ToInt16(lastReceive)))
                                    //    {

                                    //        PurchaseOrderBll.UpdateLastQty(id, ReceiveQty);
                                    //        PurchaseOrderBll.PurchaseDone(id);
                                    //        // PurchaseOrderBll.UpdateLastQty(id, ReceiveQty);
                                    //    }
                                    //    else
                                    //    {
                                    //        ReceiveQty = ReceiveQty + Convert.ToDouble(lastReceive);
                                    //        PurchaseOrderBll.UpdateLastQty(id, ReceiveQty);
                                    //    }

                                    //    // lblMessage.Text = "<font color='green'>Purchase information posted successfully</font>";
                                    //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Purchase information posted successfully')", true);
                                    //    SetGriview();
                                    //}
                                    //else
                                    //{

                                    int productId = Convert.ToInt32(purchaseorder.ProductId);
                                    ERPSSL.LC.DAL.Inv_Product _invProduct = aLC_RequisitionBLL.GetProductByProductID(productId);

                                    //   Inv_Product _invProduct = _purchaseOrderbll.GetProductByProductId(Convert.ToInt32(purchaseorder.BarCode));

                                    string id = Convert.ToString(Id);

                                    string ChalanNo = rChallanBll.GetNewRChalanNo(purchaseorder.SupplierCode, DateTime.Now);
                                    //string ChalanNo = GetChalanNo(id);

                                    //ERPSSL.INV.DAL.Inv_BuyCentral buyCentral = buyCentralBll.GetBuyCentralByCompanyAndBarcode(productId, ddlCompanyCode.SelectedValue);

                                    ERPSSL.INV.DAL.Inv_BuyCentral buyCentral = buyCentralBll.GetBuyCentralByCompanyAndBarcode(productId.ToString(), ddlCompanyCode.SelectedValue);

                                    if (buyCentral == null)
                                    { // Insert New

                                        ERPSSL.INV.DAL.Inv_BuyCentral newBuyCentral = new ERPSSL.INV.DAL.Inv_BuyCentral();
                                        newBuyCentral.ChallanNo = ChalanNo;
                                        //newBuyCentral.CompanyId = Convert.ToInt32(ddlCompanyCode.SelectedValue);
                                        newBuyCentral.CompanyCode = HiddenCompanyCode.Value;
                                        newBuyCentral.CompanyName = HiddenCompanyName.Value;
                                        newBuyCentral.BarCode = _invProduct.ProductId.ToString();
                                        newBuyCentral.ProductId = _invProduct.ProductId;
                                        newBuyCentral.ProductGroup = _invProduct.GroupId;
                                        newBuyCentral.ProductName = _invProduct.ProductName;
                                        newBuyCentral.Brand = _invProduct.Brand;
                                        newBuyCentral.Item_Remarks = ItemsRemark;

                                        //if (ddlProject.SelectedValue != "0")
                                        //{
                                        //    newBuyCentral.Project_Code = ddlProject.SelectedValue;
                                        //}

                                        if (ddlStoreName.SelectedValue != "0")
                                        {
                                            newBuyCentral.Store_Code = ddlStoreName.SelectedValue.ToString();
                                        }

                                        //if (ddlStoreUnit.SelectedValue != "0")
                                        //{
                                        //    newBuyCentral.Store_Unit_Id = Convert.ToInt16(ddlStoreUnit.SelectedValue);
                                        //}

                                        //DropDownList drpumCheck1 = (DropDownList)gvRow.FindControl("drpumCkeck");
                                        //DropDownList drpRecieptConditio1n = (DropDownList)gvRow.FindControl("ddlRecieptCondition");

                                        newBuyCentral.StyleSize = _invProduct.StyleAndSize;
                                        //newBuyCentral.FloorName = rchallan.FloorName;
                                        newBuyCentral.UnitName = _invProduct.UnitName;
                                        newBuyCentral.ReceiveQuantity = ReceiveQty;// Convert.ToInt32(purchaseorder.OrderedQty);
                                        //newBuyCentral.CPU = rchallan.CPU;
                                        //newBuyCentral.RPU = rchallan.RPU;
                                        //newBuyCentral.ExpireDate = rchallan.ExpireDate;
                                        newBuyCentral.BalanceQuanity = ReceiveQty;// Convert.ToInt32(purchaseorder.OrderedQty);
                                        try
                                        {
                                            newBuyCentral.PurchaseDate = DateTime.Now;
                                        }
                                        catch
                                        {
                                            newBuyCentral.PurchaseDate = DateTime.Today;
                                        }

                                        newBuyCentral.EditDate = DateTime.Now;
                                        newBuyCentral.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                                        newBuyCentral.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                                        buyCentralBll.Insert(newBuyCentral);
                                    }

                                    else
                                    {
                                        buyCentral.BalanceQuanity = buyCentral.BalanceQuanity + ReceiveQty;// Convert.ToInt32(purchaseorder.OrderedQty);
                                        //buyCentral.CPU = rchallan.CPU;
                                        //buyCentral.RPU = rchallan.RPU;
                                        //buyCentral.ExpireDate = rchallan.ExpireDate;
                                        buyCentral.ReceiveQuantity = buyCentral.ReceiveQuantity + ReceiveQty;// Convert.ToInt32(purchaseorder.OrderedQty);
                                        buyCentralBll.Update(buyCentral, Convert.ToInt32(buyCentral.Id));
                                    }
                                    //}
                                    Inv_RChallan rchallan = new Inv_RChallan();
                                    rchallan.ChallanNo = ChalanNo;
                                    rchallan.PO_No = lblPO.Text;
                                    rchallan.ChallanDate = DateTime.Now;
                                    //   rchallan.CompanyId = Convert.ToInt32(ddlCompanyCode.SelectedValue);
                                    rchallan.CompanyCode = HiddenCompanyCode.Value;
                                    rchallan.CompanyName = HiddenCompanyName.Value;
                                    rchallan.Barcode = hdnBarCode.Value;
                                    rchallan.ProductId = _invProduct.ProductId;
                                    rchallan.ProductGroup = _invProduct.GroupId;
                                    rchallan.ProductName = _invProduct.ProductName;
                                    rchallan.Brand = _invProduct.Brand;

                                    //if (ddlProject.SelectedValue != "0")
                                    //{

                                    //    rchallan.Project_Code = ddlProject.SelectedValue;
                                    //}

                                    if (ddlStoreName.SelectedValue != "0")
                                    {
                                        rchallan.Store_Code = ddlStoreName.SelectedValue.ToString();
                                    }
                                    //if (ddlStoreUnit.SelectedValue != "0")
                                    //{
                                    //    rchallan.Store_Unit_Id = Convert.ToInt16(ddlStoreUnit.SelectedValue);
                                    //}

                                    //DropDownList drpumCheck11 = (DropDownList)gvRow.FindControl("drpumCkeck");
                                    //DropDownList drpRecieptConditio11n = (DropDownList)gvRow.FindControl("ddlRecieptCondition");

                                    //if (drpumCheck11.SelectedValue != "0")
                                    //{
                                    //    rchallan.Unit_Cheked = drpumCheck11.SelectedItem.Text;
                                    //}

                                    //if (drpRecieptConditio11n.SelectedValue != "0")
                                    //{
                                    //    rchallan.Reciept_Condition = drpRecieptConditio11n.SelectedItem.Text;
                                    //}

                                    rchallan.Remarks = ItemsRemark;

                                    //rchallan.StyleSize = rchallan.StyleSize;
                                    //rchallan.FloorName = rchallan.FloorName;
                                    rchallan.UnitName = _invProduct.UnitName;
                                    rchallan.ReceiveQuantity = ReceiveQty;// Convert.ToInt32(purchaseorder.OrderedQty);
                                    //rchallan.CPU = rchallan.CPU;
                                    //rchallan.RPU = rchallan.RPU;
                                    //rchallan.ExpireDate = rchallan.ExpireDate;
                                    rchallan.BalanceQty = rchallan.BalanceQty;
                                    try
                                    {
                                        rchallan.PurchaseDate = DateTime.Today;
                                    }
                                    catch
                                    {
                                        rchallan.PurchaseDate = DateTime.Today;
                                    }

                                    rchallan.EditDate = DateTime.Now;
                                    rchallan.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                                    rchallan.Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                                    rChallanBll.Insert(rchallan);
                                    //  string Po = lblPO.Text;

                                    //   PurchaseOrderBll.PurchaseDone(id);
                                    //if (lastReceive == 0 && ReceiveQty == Convert.ToDouble(lblOrderQty.Text))
                                    //{
                                    //    PurchaseOrderBll.PurchaseDoneByPO(id);
                                    //    // PurchaseOrderBll.UpdateLastQty(id, ReceiveQty);
                                    //}
                                    //else if ((Convert.ToDouble(lblOrderQty.Text) == ReceiveQty + Convert.ToInt16(lastReceive)))
                                    //{
                                    //    PurchaseOrderBll.PurchaseDoneByPO(id);
                                    //    // PurchaseOrderBll.UpdateLastQty(id, ReceiveQty);
                                    //}
                                    //else
                                    //{
                                    //    ReceiveQty = ReceiveQty + Convert.ToDouble(lastReceive);
                                    //PurchaseOrderBll.UpdatePOLastQty(id, ReceiveQty);
                                    //}

                                    // lblMessage.Text = "<font color='green'>Purchase information posted successfully</font>";
                                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Purchase information posted successfully')", true);
                                    SetGriview();
                                    //}
                                }
                            }
                        }
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Items')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void SetGriview()
        {
            GetApproveDistinctPO();
            grvPOItemList.DataSource = null;
            grvPOItemList.DataBind();
            btnTransfer.Visible = false;
            lblpro.Visible = false;
            //ddlProject.ClearSelection();
            // ddlStoreName.ClearSelection();
            //ddlStoreUnit.ClearSelection();
            // txtRemark.Text = "";
            //ddlUMCheckedCondition.ClearSelection();
            //ddlRecieptCondition.ClearSelection();
        }

        private string GetChalanNo(string Id)
        {
            DataTable dt = new DataTable();
            string ChalanNO = "";

            dt = PurchaseOrderBll.GetProductsToReceive("ByQuotation", Id);

            foreach (DataRow dr in dt.Rows)
            {
                hdnBarCode.Value = dr["BarCode"].ToString();
                ChalanNO = rChallanBll.GetNewRChalanNo(dr["SupplierCode"].ToString(), DateTime.Now);
            }
            return ChalanNO;
        }

        private bool IsExist(LC_PurchaseOrder purchaseorder)
        {
            try
            {
                bool status = true;
                int productID = Convert.ToInt16(purchaseorder.ProductId);
                ERPSSL.LC.DAL.Inv_Product _invProduct = aLC_RequisitionBLL.GetProductByProductID(productID);

                if (_invProduct == null)
                {
                    status = false;
                }
                return status;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsExist(int Id)
        {
            try
            {
                bool status = true;
                LC_PurchaseOrder purchaseorder = aLC_RequisitionBLL.GetPurchaseOrderById(Id);
                if (purchaseorder == null)
                {
                    status = false;
                }
                return status;
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                IChallanBLL aChallanBll = new IChallanBLL();

                if (txtbxToDate.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input To Date')", true);

                }
                else if (txtbxFromDate.Text.Trim() == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Input From Date')", true);
                }
                else
                {
                    DateTime Todate = Convert.ToDateTime(txtbxToDate.Text);
                    DateTime Fromdate = Convert.ToDateTime(txtbxFromDate.Text);
                    LoadGrdview(Todate, Fromdate);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void LoadGrdview(DateTime Todate, DateTime Fromdate)
        {
            try
            {
                IChallanBLL aChallanBll = new IChallanBLL();
                List<POReceivedR> POReceivedRes = aChallanBll.ReceivebyPoSerchByDatetoDate(Todate, Fromdate);
                if (POReceivedRes.Count > 0)
                {
                    GrdviewAfterDeiveryProduct.DataSource = POReceivedRes;
                    GrdviewAfterDeiveryProduct.DataBind();
                }
                else
                {
                    GrdviewAfterDeiveryProduct.DataSource = null;
                    GrdviewAfterDeiveryProduct.DataBind();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found!')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void GrdviewAfterDeiveryProduct_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GrdviewAfterDeiveryProduct.PageIndex = e.NewPageIndex;
            DateTime Todate = Convert.ToDateTime(txtbxToDate.Text);
            DateTime Fromdate = Convert.ToDateTime(txtbxFromDate.Text);
            LoadGrdview(Todate, Fromdate);
        }

        protected void grvDeliverySchedule_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //UnitBLL unitBll = new UnitBLL();
            //StoreBLL aStoreBll = new StoreBLL();

            //if (e.Row.RowType == DataControlRowType.DataRow)
            //{
            //    var row = unitBll.GetAllUnit();
            //    //Find the DropDownList in the Row
            //    DropDownList drpumCkeck = (e.Row.FindControl("drpumCkeck") as DropDownList);
            //    drpumCkeck.DataSource = row;
            //    drpumCkeck.DataTextField = "UnitName";
            //    drpumCkeck.DataValueField = "UnitId";
            //    drpumCkeck.DataBind();
            //    drpumCkeck.Items.Insert(0, new ListItem("---Select---", "0"));

            //    try
            //    {
            //        var result = aStoreBll.GetAllStoreLocation(((SessionUser)Session["SessionUser"]).OCode);
            //        DropDownList ddlStoreName = (e.Row.FindControl("ddlStoreName") as DropDownList);
            //        if (result.Count > 0)
            //        {
            //            ddlStoreName.DataSource = result.ToList();
            //            ddlStoreName.DataTextField = "StoreName";
            //            ddlStoreName.DataValueField = "Store_Code";
            //            ddlStoreName.DataBind();
            //            ddlStoreName.Items.Insert(0, new ListItem("---Select---", "0"));
            //        }
            //    }
            //    catch
            //    {
            //    }
            //}
        }

    }
}