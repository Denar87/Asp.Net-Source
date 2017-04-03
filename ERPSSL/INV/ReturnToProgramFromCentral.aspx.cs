using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.BLL;
using ERPSSL.INV.DAL;
using ERPSSL.INV.DAL.Repository;

namespace ERPSSL.INV
{
    public partial class ReturnToProgramFromCentral : System.Web.UI.Page
    {
        IChallanBLL ic = new IChallanBLL();
        StoreBLL aStoreBll = new StoreBLL();
        public static DataTable stCompany = new DataTable();
        public static string CentralCode = "";
        public static string CompanyType = "";
        Inv_StoreBLL companyBll = new Inv_StoreBLL();
        BuyBLL buyBll = new BuyBLL();
        BuyCentralBLL _BuyCentral = new BuyCentralBLL();
        RChallanBLL rChallanBll = new RChallanBLL();
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!Page.IsPostBack)
                {
                    stCompany = companyBll.GetCentralCompany();
                    foreach (DataRow dr in stCompany.Rows)
                    {
                        CentralCode = dr["CompanyCode"].ToString();
                        CompanyType = dr["CompanyType"].ToString();
                    }
                    hdfCompanyCode.Value = CentralCode.ToString();
                    GetAllStore();
                    FillStore();
                    // FillCentralCompanyFrom();
                    txtDate.Text = DateTime.Today.ToShortDateString();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        public void FillStore()
        {
            try
            {
                //string projectCode = ddlProject.SelectedValue.ToString();
                var row = aStoreBll.GetStorByOcode(((SessionUser)Session["SessionUser"]).OCode);
                if (row.Count > 0)
                {
                    ddlStoreName.DataSource = row.ToList();
                    ddlStoreName.DataTextField = "StoreName";
                    ddlStoreName.DataValueField = "Store_Code";
                    ddlStoreName.DataBind();

                }
            }
            catch
            {
            }
        }

        private void GetAllStore()
        {
            try
            {
                var result = aStoreBll.GetProgram(((SessionUser)Session["SessionUser"]).OCode);
                if (result.Count > 0)
                {
                    ddlProgram.DataSource = result.ToList();
                    ddlProgram.DataTextField = "programName";
                    ddlProgram.DataValueField = "ProgramId";
                    ddlProgram.DataBind();
                    ddlProgram.Items.Insert(0, new ListItem("---Select---", "0"));
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

                lblMessage.Text = "";
                //    FillProductGroup();
                //    string supCode = ddlSupplierTo.SelectedValue.ToString();



                if (ddlProgram.SelectedValue.ToString() != "0")
                {
                    int programCode = Convert.ToInt32(ddlProgram.SelectedValue.ToString());
                    string storeCode = ddlStoreName.SelectedValue.ToString();
                    List<productsDetails> details = buyBll.GetAllProductWithProgram2(programCode, storeCode).ToList();
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

                    //string programCode = ddlProgram.SelectedValue.ToString();
                    //txtChalanNoReturn.Text = GetNewChallanNo(programCode, DateTime.Parse(txtDate.Text), "Store");
                    //FillProductGroup();

                    //FillSupplierToReturn(ddlStore.SelectedValue.ToString());
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        //private void FillSupplierToReturn(string storeCode)
        //{
        //    var supplierList = ic.GetSupplierListToReturnStoreWise(storeCode);

        //    if (supplierList.Rows.Count > 0)
        //    {
        //        ddlSupplierTo.DataSource = supplierList;
        //        ddlSupplierTo.DataValueField = "SupplierCode";
        //        ddlSupplierTo.DataTextField = "SupplierName";
        //        ddlSupplierTo.DataBind();
        //        ddlSupplierTo.Items.Insert(0, new ListItem("Select One", "0"));
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No supplier found!')", true);
        //    }
        //}

        private void GetNewChallanNo(DateTime day)
        {
            txtChalanNoReturn.Text = ic.GetNewReturnChalanNo(((SessionUser)Session["SessionUser"]).OCode, day, "DPT");
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
        {
            try
            {
                lblMessage.Text = "";
                ddlProduct.Enabled = true;
                string programCode = ddlProgram.SelectedValue.ToString();
                //  string supTo = ddlSupplierTo.SelectedValue.ToString();
                if (programCode != "0")
                {
                    FillProductName(programCode);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void FillProductName(string programCode)
        {
            try
            {
                if (Convert.ToInt32(ddlProductGroup.SelectedValue) > 0)
                {
                    ddlProduct.DataSource = ic.GetProductListToProgramWise(Convert.ToInt32(ddlProductGroup.SelectedValue), programCode);
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
        {
            try
            {
                lblMessage.Text = "";
                string barCode = ddlProduct.SelectedValue.ToString();
                int programCode = Convert.ToInt32(ddlProgram.SelectedValue.ToString());
                hdnBarCode.Value = ddlProduct.SelectedValue.ToString();
                string storeCode = ddlStoreName.SelectedValue.ToString();

                List<productsDetails> details = buyBll.GetAllProductWithProgram(barCode, programCode, storeCode).ToList();
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
                    Guid user = (((SessionUser)Session["SessionUser"]).UserId);
                    string Ocode = ((SessionUser)Session["SessionUser"]).OCode.ToString();
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
                            // Label lblCompanyId = (Label)gvr.FindControl("lblCompanyId");
                            // Label lblCompanyName = (Label)gvr.FindControl("lblCompanyName");
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

                            returnTemp.EditUser = user;
                            returnTemp.EID = "N/A";
                            returnTemp.OCode = Ocode;
                            returnTemp.OldCompanyCode = CentralCode.ToString();
                            returnTemp.ProductGroup = lblproductGroup.Text;
                            returnTemp.ProductId = Convert.ToInt32(lblBarCode.Text);
                            returnTemp.ProductName = lblproductName.Text;

                            if (lblPurchaseDate.Text == "")
                            {
                                returnTemp.PurchaseDate = DateTime.Today;
                            }
                            else
                            {
                                returnTemp.PurchaseDate = Convert.ToDateTime(lblPurchaseDate.Text);
                            }
                            returnTemp.ProgramId = Convert.ToInt32(ddlProgram.SelectedValue);

                            if (lblReceiveQuantity.Text == "")
                            {
                                returnTemp.ReceiveQuantity = 0;
                            }
                            else
                            {
                                returnTemp.ReceiveQuantity = Convert.ToDouble(lblReceiveQuantity.Text);
                            }

                            //returnTemp.Store_Code = ddlStore.SelectedValue.ToString();
                            returnTemp.StyleSize = lblStyleAndSize.Text;
                            returnTemp.SupplierCode = "N/A";
                            returnTemp.SupplierReturnQty = 0;
                            returnTemp.ERetQty = ReturnQty;
                            returnTemp.UnitName = lblUnitName.Text;
                            returnTemp.Store_Code = ddlStoreName.SelectedValue;

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
        }

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

            try
            {
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
        {
            try
            {
                DateTime date = DateTime.Today;
                GetNewChallanNo(date);
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string Edit_User = ((SessionUser)Session["SessionUser"]).UserId.ToString();
                Guid UserId = ((SessionUser)Session["SessionUser"]).UserId;

                List<Inv_Return_Temp> ReturnList = new List<Inv_Return_Temp>();
                string challanNo = txtChalanNoReturn.Text.Trim();
                ReturnList = rChallanBll.GetTempReturn(((SessionUser)Session["SessionUser"]).OCode, UserId);

                foreach (Inv_Return_Temp rchallan in ReturnList)
                {

                    if (ddlStoreName.SelectedValue == "CNT")
                    {
                        Inv_BuyCentral buyCentral = _BuyCentral.GetBuyForReturn(rchallan.BarCode, rchallan.Store_Code);

                        if (buyCentral != null)
                        {

                            // Kamruzzaman...........
                            Inv_Return _return = new Inv_Return();
                            _return.ChallanNo = txtChalanNoReturn.Text;
                            _return.ChallanNo_To = rchallan.ChallanNo_To;
                            _return.BarCode = rchallan.BarCode;
                            _return.ProductId = Convert.ToInt32(rchallan.ProductId);
                            _return.ProductGroup = rchallan.ProductGroup;
                            _return.ProductName = rchallan.ProductName;
                            _return.Remarks = rchallan.Remarks;
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
                            _return.ERetQty = rchallan.ERetQty;
                            _return.OldCompanyName = rchallan.OldCompanyName;
                            _return.OldCompanyId = rchallan.OldCompanyId;
                            _return.ReturnType = "StoreToCentral";
                            _return.EID = rchallan.EID;
                            _return.DPT_CODE = rchallan.DPT_CODE;
                            _return.ProgramId = rchallan.ProgramId;

                            _BuyCentral.InsertReturn(_return);

                            // buy.BalanceQuanity = buy.BalanceQuanity - rchallan.ERetQty;
                            buyCentral.BalanceQuanity = buyCentral.BalanceQuanity + rchallan.ERetQty;
                            //buyCentral.Id = Convert.ToInt16(hidId.Value);
                            // _BuyCentral.Update_Return_DptWise(buy.Id, buy.BarCode, buy.Store_Code, buy.ChallanNo, buy);

                            _BuyCentral.Update_ForReturnBy_CentralToStore(buyCentral.Id, buyCentral.BarCode, buyCentral.Store_Code, buyCentral.ChallanNo, buyCentral);

                            _BuyCentral.DeleteReturn_Temp(rchallan.Id);
                        }

                        else
                        {

                        }
                    }
                    else
                    {
                        Inv_Buy buy = _BuyCentral.GetBuy_DPT_Return(rchallan.BarCode, rchallan.Store_Code, rchallan.ChallanNo_To);

                        if (buy != null)
                        {

                            // Kamruzzaman...........
                            Inv_Return _return = new Inv_Return();
                            _return.ChallanNo = txtChalanNoReturn.Text;
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
                            _return.Remarks = rchallan.Remarks;
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
                            _return.ERetQty = rchallan.ERetQty;
                            _return.OldCompanyName = rchallan.OldCompanyName;
                            _return.OldCompanyId = rchallan.OldCompanyId;
                            _return.ReturnType = "StoreToStore";
                            _return.EID = rchallan.EID;
                            _return.DPT_CODE = rchallan.DPT_CODE;
                            _return.ProgramId = rchallan.ProgramId;

                            _BuyCentral.InsertReturn(_return);

                            // buy.BalanceQuanity = buy.BalanceQuanity - rchallan.ERetQty;
                            buy.BalanceQuanity = buy.BalanceQuanity + rchallan.ERetQty;
                            //buyCentral.Id = Convert.ToInt16(hidId.Value);
                            _BuyCentral.Update_Return_DptWise(buy.Id, buy.BarCode, buy.Store_Code, buy.ChallanNo, buy);

                            // _BuyCentral.Update_ForReturnBy_CentralToStore(buyCentral.Id, buyCentral.BarCode, buyCentral.Store_Code, buyCentral.ChallanNo, buyCentral);

                            _BuyCentral.DeleteReturn_Temp(rchallan.Id);
                        }

                        else
                        {

                        }
                    }
                }

                grdTransfer.DataSource = null;
                grdTransfer.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Item Returned Successfully')", true);
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }


    }
}