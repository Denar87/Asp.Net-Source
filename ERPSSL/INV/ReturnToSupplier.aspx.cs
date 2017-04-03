using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.DAL;
using ERPSSL.INV.BLL;
using System.Data;
using System.Collections;
using ERPSSL.INV.DAL.Repository;

namespace ERPSSL.INV
{
    public partial class ReturnToSupplier : System.Web.UI.Page
    {
        IChallanBLL ic = new IChallanBLL();
        StoreBLL aStoreBll = new StoreBLL();
        public static DataTable stCompany = new DataTable();
        public static string CentralCode = "";
        public static string CompanyType = "";

        BuyCentralBLL _BuyCentral = new BuyCentralBLL();
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();
        RChallanBLL rChallanBll = new RChallanBLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!Page.IsPostBack)
                {
                    stCompany = aStoreBll.GetCentralCompany();
                    foreach (DataRow dr in stCompany.Rows)
                    {
                        CentralCode = dr["CompanyCode"].ToString();
                        CompanyType = dr["CompanyType"].ToString();
                    }
                    hdfCompanyCode.Value = CentralCode.ToString();
                    GetAllStore();
                    // FillCentralCompanyFrom();
                    txtDate.Text = DateTime.Today.ToShortDateString();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetAllStore()
        {
            try
            {
                var result = aStoreBll.GetStoreByProjectCodeByLocation(((SessionUser)Session["SessionUser"]).OCode);
                if (result.Count > 0)
                {
                    ddlStore.DataSource = result.ToList();
                    ddlStore.DataTextField = "StoreName";
                    ddlStore.DataValueField = "Store_Code";
                    ddlStore.DataBind();
                    ddlStore.Items.Insert(0, new ListItem("---Select---", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        //public void FillCentralCompanyFrom()
        //{
        //    ddlStore.DataSource = ic.GetCentralCompanyList();
        //    ddlStore.DataValueField = "CompanyCode";
        //    ddlStore.DataTextField = "CompanyName";
        //    ddlStore.DataBind();
        //    ddlStore.Items.Insert(0, new ListItem("Select One", "0"));
        //}

        protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlStore.SelectedValue.ToString() != "0")
                {
                    FillSupplierToReturn(ddlStore.SelectedValue.ToString());

                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }


            // txtChalanNoReturn.Text = GetNewChallanNo("BSL-01", DateTime.Parse(txtDate.Text), "SUP");
        }

        private void FillSupplierToReturn(string storeCode)
        {try{
            var supplierList = ic.GetSupplierListToReturnStoreWise(storeCode);

            if (supplierList.Rows.Count > 0)
            {
                ddlSupplierTo.DataSource = supplierList;
                ddlSupplierTo.DataValueField = "SupplierCode";
                ddlSupplierTo.DataTextField = "SupplierName";
                ddlSupplierTo.DataBind();
                ddlSupplierTo.Items.Insert(0, new ListItem("Select One", "0"));
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No supplier found!')", true);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
        }
        }

        private void GetNewChallanNo(DateTime day)
        {
            txtChalanNoReturn.Text = ic.GetNewReturnChalanNo(((SessionUser)Session["SessionUser"]).OCode, day, "DPT");
        }

        protected void ddlSupplierTo_SelectedIndexChanged(object sender, EventArgs e)
        {try{
            lblMessage.Text = "";
            FillProductGroup();
            string supCode = ddlSupplierTo.SelectedValue.ToString();
            //txtChalanNoReturn.Text = GetNewChallanNo(supCode, DateTime.Parse(txtDate.Text), "SUP");
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
        }
        }

        public void FillProductGroup()
        {
            try
            {
 ddlProductGroup.DataSource = ic.GetListGroup();
            ddlProductGroup.DataValueField = "GroupId";
            ddlProductGroup.DataTextField = "GroupName";
            ddlProductGroup.DataBind();
            ddlProductGroup.Items.Insert(0, new ListItem("Select One", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {try{
            lblMessage.Text = "";
            ddlProduct.Enabled = true;
            string cmpCode = ddlStore.SelectedValue.ToString();
            string supTo = ddlSupplierTo.SelectedValue.ToString();
            if (cmpCode != "0" && supTo != "0")
            {
                FillProductName(cmpCode, supTo);
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
        }
        }

        private void FillProductName(string cmpCode, string supTo)
        {try{
            if (Convert.ToInt32(ddlProductGroup.SelectedValue) > 0)
            {
                ddlProduct.DataSource = ic.GetProductListToReturnStoreWisr(Convert.ToInt32(ddlProductGroup.SelectedValue), cmpCode, supTo);
                ddlProduct.DataValueField = "BarCode";
                ddlProduct.DataTextField = "ProductName";
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("Select One", "0"));
            }
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
        }
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {try{
            lblMessage.Text = "";
            string barCode = ddlProduct.SelectedValue.ToString();
            string StoreCode = ddlStore.SelectedValue.ToString();
            string supplierCode = ddlSupplierTo.SelectedValue.ToString();
            hdnBarCode.Value = ddlProduct.SelectedValue.ToString();

            List<productsDetails> details = _BuyCentral.GetAllProduct_Bycentral_ChallanNoBySupplier(barCode, StoreCode, supplierCode).ToList();
            if (details.Count > 0)
            {
                GridShow.DataSource = details;
                GridShow.DataBind();

            }
            else
            {
                GridShow.DataSource = null;
                GridShow.DataBind();
            }



            //DataTable dt = ic.GetProductInforByBarCodeStoreWise(barCode, StoreCode, "CENTRAL");
            //foreach (DataRow dr in dt.Rows)
            //{
            //    //txtSize.Text = dr["StyleSize"].ToString();

            //    if (double.Parse(dr["BalanceQuanity"].ToString()) <= 0)
            //    {
            //        txtReturnQty.Enabled = false;
            //        txtBalanceQty.Text = "0";
            //    }
            //    else
            //    {
            //        txtReturnQty.Enabled = true;
            //        txtBalanceQty.Text = dr["BalanceQuanity"].ToString();
            //    }
            //}
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
        }
        }

        //protected void txtReturnQty_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        if (txtReturnQty.Text.Trim() != string.Empty)
        //        {
        //            txtRemainingQty.Text = (double.Parse(txtBalanceQty.Text) - double.Parse(txtReturnQty.Text)).ToString();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
        //    }
        //}

        private void ClearForm()
        {
            ddlProduct.ClearSelection();
            //txtSize.Text = string.Empty;
            //txtReturnQty.Text = string.Empty;
            //txtRemainingQty.Text = string.Empty;
            //txtBalanceQty.Text = string.Empty;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {

            try
            {
                List<Inv_Return_Temp> _Inv_Return_Temp = new List<Inv_Return_Temp>();
                Guid user = (((SessionUser)Session["SessionUser"]).UserId);
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode.ToString();
                //bool status = true;
                bool CheckStatus = false;

                foreach (GridViewRow gvRow in GridShow.Rows)
                {

                    CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));

                    if (rowChkBox.Checked == true)
                    {
                        CheckStatus = true;
                    }
                }

                if (CheckStatus)
                {

                    foreach (GridViewRow gvr in GridShow.Rows)
                    {
                        CheckBox rowChkBox = ((CheckBox)gvr.FindControl("rowLevelCheckBox"));


                        if (rowChkBox.Checked == true)
                        {
                            Inv_Return_Temp returnTemp = new Inv_Return_Temp();
                            Label lblproductName = (Label)gvr.FindControl("lblproductName");
                            Label lblBrand = (Label)gvr.FindControl("lblBrand");
                            Label lblStyleAndSize = (Label)gvr.FindControl("lblStyleAndSize");
                            Label lblSupplierReturnQty = (Label)gvr.FindControl("lblSupplierReturnQty");
                            Label lblCompanyId = (Label)gvr.FindControl("lblCompanyId");
                            Label lblCompanyName = (Label)gvr.FindControl("lblCompanyName");
                            Label lblproductGroup = (Label)gvr.FindControl("lblproductGroup");
                            Label lblReceiveQuantity = (Label)gvr.FindControl("lblReceiveQuantity");
                            Label lblCPU = (Label)gvr.FindControl("lblCPU");
                            Label lblDeliveryQty = (Label)gvr.FindControl("lblDeliveryQty");
                            Label lblOcode = (Label)gvr.FindControl("lblOcode");
                            Label lblCompanyCode = (Label)gvr.FindControl("lblCompanyCode");
                            Label lblPurchaseDate = (Label)gvr.FindControl("lblPurchaseDate");
                            Label lblBalanceQty = (Label)gvr.FindControl("lblBalanceQty");
                            Label lblChallanNo = (Label)gvr.FindControl("lblChallanNo");
                            Label lblBarCode = (Label)gvr.FindControl("lblBarCode");
                            Label lblUnitName = (Label)gvr.FindControl("lblUnitName");
                            TextBox txtReturnQty = (TextBox)gvr.FindControl("txtReturnQty");
                            TextBox txtRemarks = (TextBox)gvr.FindControl("txtRemarks");
                            int ReturnQty = int.Parse(txtReturnQty.Text);


                            returnTemp.ChallanNo = txtChalanNoReturn.Text;
                            returnTemp.Remarks = txtRemarks.Text;
                            returnTemp.ChallanNo_To = lblChallanNo.Text;
                            if (lblBalanceQty.Text == "")
                            {
                                returnTemp.BalanceQuanity = 0;
                            }
                            else
                            {
                                returnTemp.BalanceQuanity = Convert.ToInt32(lblBalanceQty.Text);
                            }

                            returnTemp.BarCode = lblBarCode.Text;
                            returnTemp.Brand = lblBrand.Text;
                            if (lblCPU.Text == "")
                            {
                                returnTemp.CPU = 0;
                            }
                            else
                            {
                                returnTemp.CPU = Convert.ToDecimal(lblCPU.Text);
                            }
                            returnTemp.CurrentCompanyCode = lblCompanyCode.Text;
                            if (lblDeliveryQty.Text == "")
                            {
                                returnTemp.DeliveryQty = 0;
                            }
                            else
                            {
                                returnTemp.DeliveryQty = Convert.ToDouble(lblDeliveryQty.Text);
                            }
                            returnTemp.DPT_CODE = "N/A";
                            returnTemp.EditDate = DateTime.Today;
                            // Guid user = (((SessionUser)Session["SessionUser"]).UserId);
                            returnTemp.EditUser = user;
                            returnTemp.EID = "N/A";
                            returnTemp.OCode = Ocode;
                            returnTemp.OldCompanyCode = CentralCode.ToString();
                            returnTemp.ProductGroup = lblproductGroup.Text;
                            returnTemp.ProductId = Convert.ToInt32(lblBarCode.Text);
                            returnTemp.ProductName = lblproductName.Text;
                            returnTemp.PurchaseDate = Convert.ToDateTime(lblPurchaseDate.Text);
                            if (lblReceiveQuantity.Text == "")
                            {
                                returnTemp.ReceiveQuantity = 0;
                            }
                            else
                            {
                                returnTemp.ReceiveQuantity = Convert.ToDouble(lblReceiveQuantity.Text);
                            }

                            returnTemp.Store_Code = ddlStore.SelectedValue.ToString();
                            returnTemp.StyleSize = lblStyleAndSize.Text;
                            returnTemp.SupplierCode = ddlSupplierTo.SelectedValue.ToString();
                            returnTemp.SupplierReturnQty = ReturnQty;
                            returnTemp.UnitName = lblUnitName.Text;
                            returnTemp.ProgramId = 0;

                            _context.Inv_Return_Temp.AddObject(returnTemp);
                        }
                    }
                    _context.SaveChanges();


                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Return Process Temporary successfully')", true);
                    GridShow.DataSource = null;
                    GridShow.DataBind();
                    List<productsDetails> details = _BuyCentral.GetAllProduct_ReturnTemp_ChallanNo_DPT(user, Ocode).ToList();
                    if (details.Count > 0)
                    {
                        grdTransfer.DataSource = details;
                        grdTransfer.DataBind();

                    }
                    else
                    {
                        grdTransfer.DataSource = null;
                        grdTransfer.DataBind();
                    }

                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Item Selected!')", true);

                }
            }
           catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
            //try
            //{

            //    string BarCode = hdnBarCode.Value.ToString();
            //    if (BarCode == string.Empty || txtBalanceQty.Text == string.Empty || ddlSupplierTo.SelectedValue == "0" || ddlStore.SelectedValue == "0" || txtReturnQty.Text == "0")
            //    {
            //        //lblMessage.Text = "<font color='red'>Invalid data. Please be correct and try again!</font>";
            //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Invalid data. Please be correct and try again!')", true);
            //        return;
            //    }
            //    if (double.Parse(txtReturnQty.Text) > double.Parse(txtBalanceQty.Text))
            //    {
            //        // lblMessage.Text = "<font color='red'>Sorry! You cannot return more then you have. Please be correct and try again!</font>";
            //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Sorry! You cannot return more then you have. Please be correct and try again!')", true);
            //        return;
            //    }

            //    Hashtable ht = new Hashtable();
            //    ht.Add("ReturnType", "SupplierReturn"); //SupplierReturn
            //    ht.Add("BarCode", BarCode);
            //    ht.Add("ChallanNo", txtChalanNo.Text);
            //    ht.Add("ReturnChallanNo", txtChalanNoReturn.Text);
            //    ht.Add("ReturnQty", txtReturnQty.Text);
            //    ht.Add("ReturnDate", txtDate.Text);
            //    ht.Add("DPT_CODE", "NA");
            //    ht.Add("EID", "NA");
            //    ht.Add("SupplierCode", ddlSupplierTo.SelectedValue.ToString());
            //    ht.Add("CenterCode", "NA");
            //    ht.Add("StoreCode", ddlStore.SelectedValue.ToString());
            //    ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode.ToString());
            //    ht.Add("CompanyCode", CentralCode.ToString());
            //    ht.Add("BalanceQuanity", txtRemainingQty.Text);
            //    ht.Add("EditUser", ((SessionUser)Session["SessionUser"]).UserId);

            //    //ht.Add("OCode", "8989");
            //    DataTable dt = ic.ReturnProductStoreWise(ht);
            //    // lblMessage.Text = "<font color='green'>Product has been returned successfully!</font>";
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Item Returned Successfully')", true);
            //    grdTransfer.DataSource = dt;
            //    grdTransfer.DataBind();
            //    //txtBalQty.Text = txtRemainQty.Text;
            //    ClearForm();
            //}
            //catch (Exception ex)
            //{
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            //}
        }

        //protected void ImgGroupEdit_Click(object sender, ImageClickEventArgs e)
        //{
        //    string barCode = ddlProduct.SelectedValue.ToString();
        //    string StoreCode = ddlStore.SelectedValue.ToString();
        //    hdnBarCode.Value = ddlProduct.SelectedValue.ToString();
        //    ImageButton imgbtn = (ImageButton)sender;
        //    GridViewRow row = (GridViewRow)imgbtn.NamingContainer;
        //    Label lblCompanyId = (Label)GridShow.Rows[row.RowIndex].FindControl("lblChallanNo");
        //    //var result = _BuyCentral.GetProductBalance_InvBuyCentral(barCode, StoreCode);
        //    //if (result != null)
        //    //{

        //    //    txtBalanceQty.Text = (result.PrqBalanceQuanity).ToString();
        //    //    txtReturnQty.Enabled = true;
        //    //}
        //    //else
        //    //{
        //    //    txtReturnQty.Enabled = false;
        //    //    txtBalanceQty.Text = "0";
        //    //}
        //}
        protected void headerLevelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                CheckBox headerChkBox = ((CheckBox)GridShow.HeaderRow.FindControl("headerLevelCheckBox"));
                if (headerChkBox.Checked == true)
                {
                    foreach (GridViewRow gvRow in GridShow.Rows)
                    {

                        CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                        rowChkBox.Checked = true;//((CheckBox)sender).Checked;//for all row checkbox     

                    }
                }
                else
                {
                    foreach (GridViewRow gvRow in GridShow.Rows)
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

            try{
            foreach (GridViewRow gvRow in GridShow.Rows)
            {
                CheckBox chk = (CheckBox)gvRow.FindControl("rowLevelCheckBox");

                if (chk.Checked)
                {
                    TextBox lblBalanceQuantity = ((TextBox)gvRow.FindControl("txtReturnQty"));
                    Label lblReqQuantity = ((Label)gvRow.FindControl("lblBalanceQty"));
                    if (lblBalanceQuantity.Text != "")
                    {

                        double balancequantity = Convert.ToDouble(lblBalanceQuantity.Text);
                        double lblQty = Convert.ToDouble(lblReqQuantity.Text);
                        if (balancequantity <= 0)
                        {
                            CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                            rowChkBox.Checked = false;//((CheckBox)sender).Checked;//for all row checkbox       
                        }
                        else
                        {
                            if (lblQty < balancequantity)
                            {
                                CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowLevelCheckBox"));
                                rowChkBox.Checked = false;//((CheckBox)sender).Checked;//for all row checkbox    
                            }

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

        protected void btnConfirm_Click(object sender, EventArgs e)
        {try{
            DateTime date = DateTime.Today;
            GetNewChallanNo(date);
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            string Edit_User = ((SessionUser)Session["SessionUser"]).UserId.ToString();
            Guid User = ((SessionUser)Session["SessionUser"]).UserId;

            List<Inv_Return_Temp> ReturnList = new List<Inv_Return_Temp>();
            string challanNo = txtChalanNoReturn.Text.Trim();
            ReturnList = rChallanBll.GetTempReturn(((SessionUser)Session["SessionUser"]).OCode, User);

            foreach (Inv_Return_Temp rchallan in ReturnList)
            {
                Inv_BuyCentral buycentral = _BuyCentral.GetBuyForReturn(rchallan.BarCode, rchallan.Store_Code);
                if (buycentral != null)
                {

                    // Kamruzzaman...........
                    Inv_Return _return = new Inv_Return();
                    _return.ChallanNo = txtChalanNoReturn.Text;
                    _return.Remarks = rchallan.Remarks;
                    _return.ChallanNo_To = rchallan.ChallanNo_To;
                    _return.BarCode = rchallan.BarCode;
                    _return.ProductId = Convert.ToInt32(rchallan.ProductId);
                    _return.ProductGroup = rchallan.ProductGroup;
                    _return.ProductName = rchallan.ProductName;
                    _return.Brand = rchallan.Brand;
                    _return.StyleSize = rchallan.StyleSize;
                    _return.FloorName = rchallan.FloorName;
                    _return.UnitName = rchallan.UnitName;
                    _return.ReceiveQuantity = rchallan.ReceiveQuantity;
                    _return.CPU = rchallan.CPU;
                    _return.RPU = rchallan.RPU;
                    _return.ExpireDate = rchallan.ExpireDate;
                    _return.BalanceQuanity = rchallan.BalanceQuanity;
                    _return.PurchaseDate = rchallan.PurchaseDate;
                    _return.EditDate = rchallan.EditDate;
                    _return.OCode = rchallan.OCode;
                    _return.Store_Code = rchallan.Store_Code;
                    _return.SupplierReturnQty = rchallan.SupplierReturnQty;
                    _return.SupplierCode = rchallan.SupplierCode;
                    _return.CurrentCompanyCode = rchallan.CurrentCompanyCode;
                    _return.PurchaseDate = rchallan.PurchaseDate;
                    _return.EditDate = DateTime.Today;
                    _return.EditUser = rchallan.EditUser;
                    _return.OldCompanyCode = rchallan.OldCompanyCode;
                    _return.ReturnDate = DateTime.Today;
                    _return.OldCompanyName = rchallan.OldCompanyName;
                    _return.OldCompanyId = rchallan.OldCompanyId;
                    _return.ReturnType = "ReturnToSupplier";
                    _return.ProgramId = rchallan.ProgramId;

                    _BuyCentral.InsertReturn(_return);

                    buycentral.BalanceQuanity = buycentral.BalanceQuanity - rchallan.SupplierReturnQty;

                    buycentral.SupplierReturnQty = buycentral.SupplierReturnQty + rchallan.SupplierReturnQty;
                    //buyCentral.Id = Convert.ToInt16(hidId.Value);
                    _BuyCentral.Update_ForReturn(buycentral.Id, buycentral.BarCode, buycentral.Store_Code, buycentral.ChallanNo, buycentral);
                    _BuyCentral.DeleteReturn_Temp(rchallan.Id);
                }

                else
                {

                }
            }

            grdTransfer.DataSource = null;
            grdTransfer.DataBind();
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Item Returned Successfully')", true);
            //Response.Redirect(Request.RawUrl);
        }
        catch (Exception ex)
        {
            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
        }
        }

    }
}