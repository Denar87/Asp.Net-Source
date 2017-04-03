using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.DAL;
using ERPSSL.INV.BLL;
using System.Collections;
using System.Data;
using ERPSSL.INV.DAL.Repository;

namespace ERPSSL.INV
{
    public partial class ReturnTOCentral : System.Web.UI.Page
    {
        IChallanBLL ic = new IChallanBLL();
        StoreBLL aStoreBll = new StoreBLL();
        public static DataTable stCompany = new DataTable();
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();
        public static string CentralCode = "";
        public static string CompanyType = "";

        BuyBLL buyBll = new BuyBLL();
        BuyCentralBLL _BuyCentral = new BuyCentralBLL();
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
                    GetAllStore();
                    //FillDepartment();
                    FillAllSubCompanyList();
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
                var result = aStoreBll.GetStorByOcode(((SessionUser)Session["SessionUser"]).OCode);
                if (result.Count > 0)
                {
                    ddlStore.DataSource = result.ToList();
                    ddlStore.DataTextField = "StoreName";
                    ddlStore.DataValueField = "Store_Code";
                    ddlStore.DataBind();
                    ddlStore.Items.Insert(0, new ListItem("---Select Store---", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        //protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    if (ddlStore.SelectedValue.ToString() != "0")
        //    {
        //        FillSupplierToReturn(ddlStore.SelectedValue.ToString());
        //    }
        //}

        //private void FillSupplierToReturn(string cmpCode)
        //{
        //    ddlSupplierTo.DataSource = ic.GetSupplierListToReturnStoreWise(cmpCode);
        //    ddlSupplierTo.DataValueField = "SupplierCode";
        //    ddlSupplierTo.DataTextField = "SupplierName";
        //    ddlSupplierTo.DataBind();
        //    ddlSupplierTo.Items.Insert(0, new ListItem("Select One", "0"));
        //}

        public void FillAllSubCompanyList()
        {
            ddlReturnFrom.DataSource = ic.GetSubCompanyList();
            ddlReturnFrom.DataValueField = "Sub_Company";
            ddlReturnFrom.DataTextField = "Sub_Company";
            ddlReturnFrom.DataBind();
            ddlReturnFrom.Items.Insert(0, new ListItem("---Select Company Name---", "0"));
        }

        //public void FillDepartment()
        //{
        //    ddlDepartment.DataSource = ic.GetDepartmentList();
        //    ddlDepartment.DataValueField = "DPT_CODE";
        //    ddlDepartment.DataTextField = "DPT_NAME";
        //    ddlDepartment.DataBind();
        //    ddlDepartment.Items.Insert(0, new ListItem("Select One", "0"));
        //}

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                //string DeptCode = ddlDepartment.SelectedValue.ToString();
                string CompanyName = ddlReturnFrom.SelectedValue.ToString();
                LoadEmployeeList(CompanyName);
                DateTime date = DateTime.Today;
                date = DateTime.Parse(txtDate.Text);
                txtChalanNoReturn.Text = ic.GetNewReturnChalanNo(CompanyName, date, "DPT");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void LoadEmployeeList(string DeptCode)
        {
            try
            {
                //    ddlEmployee.DataSource = ic.GetEmployeeList(DeptCode);
                //    ddlEmployee.DataValueField = "EID";
                //    ddlEmployee.DataTextField = "EMP_NAME";
                //    ddlEmployee.DataBind();
                //    ddlEmployee.Items.Insert(0, new ListItem("Select One", "0"));
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
                //string cmpCode = ddlCompanyFrom.SelectedValue.ToString();
                //string EID = ddlEmployee.SelectedValue.ToString();
                string EID = "";
                //string deptCode = ddlDepartment.SelectedValue.ToString();
                string ConpanyName = ddlReturnFrom.SelectedValue.ToString();
                if (ConpanyName != "0")
                {
                    FillProductName(ConpanyName, EID);
                }
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

        private void FillProductName(string deptCode, string EID)
        {
            try
            {
                if (Convert.ToInt32(ddlProductGroup.SelectedValue) > 0)
                {
                    var productList = ic.GetProductListToReturnFromDept(Convert.ToInt32(ddlProductGroup.SelectedValue), deptCode, EID);

                    if (productList.Rows.Count > 0)
                    {
                        ddlProduct.DataSource = productList;
                        ddlProduct.DataValueField = "BarCode";
                        ddlProduct.DataTextField = "ProductName";
                        ddlProduct.DataBind();
                        ddlProduct.Items.Insert(0, new ListItem("Select One", "0"));
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No item found for return!')", true);
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillProductGroup();
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                string barCode = ddlProduct.SelectedValue.ToString();
                //string cmpCode = ddlCompanyFrom.SelectedValue.ToString();
                hdnBarCode.Value = ddlProduct.SelectedValue.ToString();
                //string EID = ddlEmployee.SelectedValue.ToString();
                string EID = "";
                DataTable dt = ic.GetProductInforByBarCode(barCode);
                //if (ddlStore.SelectedValue == "CNT")
                //{
                //    List<productsDetails> details = buyBll.GetAllProductBuyReturn(EID, barCode, ddlStore.SelectedValue.ToString()).ToList();
                //    if (details.Count > 0)
                //    {
                //        GridShow.DataSource = details;
                //        GridShow.DataBind();

                //    }
                //    else
                //    {
                //        GridShow.DataSource = null;
                //        GridShow.DataBind();
                //    }
                //}
                //else

                List<productsDetails> details = buyBll.GetAllProductBuyReturn(EID, barCode, ddlStore.SelectedValue.ToString()).ToList();
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


                //int employeeStock = ic.GetEmployeeStockStoreWise(ddlEmployee.SelectedValue, barCode,ddlStore.SelectedValue.ToString());
                //foreach (DataRow dr in dt.Rows)
                //{
                //    //txtSize.Text = dr["StyleSize"].ToString();
                //    if (employeeStock <= 0)
                //    {
                //        txtReturnQty.Enabled = false;
                //        txtBalanceQty.Text = "0";
                //    }
                //    else
                //    {
                //        txtReturnQty.Enabled = true;
                //        txtBalanceQty.Text = employeeStock.ToString();
                //    }
                //    //txtCurrentLocation.Text = dr["Location"].ToString();
                //}
                //List<productsDetails> details = buyBll.GetAllProductWithChallanNoAndDPTCode(barCode, ddlStore.SelectedValue.ToString(),ddlDepartment.SelectedValue.ToString()).ToList();
                //if (details.Count > 0)
                //{
                //    GridShow.DataSource = details;
                //    GridShow.DataBind();

                //}
                //else
                //{
                //    GridShow.DataSource = null;
                //    GridShow.DataBind();
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
                Guid user = (((SessionUser)Session["SessionUser"]).UserId);
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode.ToString();
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
                            Label lblDptCode = (Label)gvr.FindControl("lblDptCode");
                            Label lblEID = (Label)gvr.FindControl("lblEID");
                            Label lblBarCode = (Label)gvr.FindControl("lblBarCode");
                            Label lblUnitName = (Label)gvr.FindControl("lblUnitName");
                            TextBox txtReturnQty = (TextBox)gvr.FindControl("txtReturnQty");
                            TextBox txtRemarks = (TextBox)gvr.FindControl("txtRemarks");
                            int ReturnQty = int.Parse(txtReturnQty.Text);


                            returnTemp.ChallanNo = txtChalanNoReturn.Text;
                            returnTemp.ChallanNo_To = lblChallanNo.Text;
                            returnTemp.Remarks = txtRemarks.Text;
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
                            returnTemp.DPT_CODE = lblDptCode.Text;
                            returnTemp.EditDate = DateTime.Today;
                            // Guid user = (((SessionUser)Session["SessionUser"]).UserId);
                            returnTemp.EditUser = user;
                            returnTemp.EID = lblEID.Text;
                            returnTemp.OCode = "8989";
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
                            returnTemp.SupplierCode = "N/A";
                            returnTemp.SupplierReturnQty = 0;
                            returnTemp.ERetQty = ReturnQty;
                            returnTemp.UnitName = lblUnitName.Text;

                            _context.Inv_Return_Temp.AddObject(returnTemp);
                        }
                    }
                    _context.SaveChanges();

                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Return Process Temporary successfully')", true);
                    GridShow.DataSource = null;
                    GridShow.DataBind();
                    List<productsDetails> details = _BuyCentral.GetAllProduct_ReturnTemp_ChallanNo_DPT(user, Ocode).ToList(); if (details.Count > 0)
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
            //    if (txtChalanNo.Text == "")
            //    {
            //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Challan No!')", true);
            //        return;
            //    }
            //    string BarCode = hdnBarCode.Value.ToString();
            //    if (BarCode == string.Empty || ddlEmployee.SelectedValue == "0" || ddlProduct.SelectedValue == "0" )
            //    {
            //        //lblMessage.Text = "<font color='red'>Invalid data. Please be correct and try again!</font>";
            //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Invalid data. Please be correct and try again!')", true);
            //        return;
            //    }
            //    if (double.Parse(txtReturnQty.Text) > double.Parse(txtBalanceQty.Text))
            //    {
            //        //lblMessage.Text = "<font color='red'>Sorry! You cannot return more then you have. Please be correct and try again!</font>";
            //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Sorry! You cannot return more then you have. Please be correct and try again!')", true);
            //        return;
            //    }

            //    Hashtable ht = new Hashtable();
            //    ht.Add("ReturnType", "DepartmentToCenter"); // Center to department/individual
            //    ht.Add("BarCode", BarCode);
            //    ht.Add("ChallanNo", txtChalanNo.Text);
            //    ht.Add("ReturnChallanNo", txtChalanNoReturn.Text);
            //    ht.Add("ReturnQty", txtReturnQty.Text);
            //    ht.Add("ReturnDate", txtDate.Text);
            //    ht.Add("DPT_CODE", ddlDepartment.SelectedValue);
            //    ht.Add("EID", ddlEmployee.SelectedValue);
            //    ht.Add("SupplierCode", "NA");
            //    ht.Add("CenterCode", "NA");
            //    ht.Add("StoreCode", ddlStore.SelectedValue.ToString());
            //    ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode.ToString());
            //    ht.Add("CompanyCode", CentralCode.ToString());
            //    ht.Add("BalanceQuanity", txtRemainingQty.Text);
            //    ht.Add("EditUser", ((SessionUser)Session["SessionUser"]).UserId);
            //    //ht.Add("OCode", "8989");
            //DataTable dt = ic.ReturnProductStoreWise(ht);
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
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string Edit_User = ((SessionUser)Session["SessionUser"]).UserId.ToString();
                Guid User = ((SessionUser)Session["SessionUser"]).UserId;

                List<Inv_Return_Temp> ReturnList = new List<Inv_Return_Temp>();
                string challanNo = txtChalanNoReturn.Text.Trim();
                ReturnList = rChallanBll.GetTempReturn(((SessionUser)Session["SessionUser"]).OCode, User);

                foreach (Inv_Return_Temp rchallan in ReturnList)
                {
                    //if (ddlStore.SelectedValue == "CNT")
                    //{
                    Inv_BuyCentral buycentral = _BuyCentral.GetBuyForReturn(rchallan.BarCode, rchallan.Store_Code);
                    if (buycentral != null)
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
                        _return.RPU = rchallan.RPU;
                        _return.Remarks = rchallan.Remarks;
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
                        _return.ReturnType = "DepartmentToStore";
                        _return.EID = rchallan.EID;
                        _return.DPT_CODE = rchallan.DPT_CODE;

                        _BuyCentral.InsertReturn(_return);

                        buycentral.BalanceQuanity = buycentral.BalanceQuanity + rchallan.ERetQty;
                        //buyCentral.Id = Convert.ToInt16(hidId.Value);
                        _BuyCentral.Update_ForReturnBy_CentralToStore(buycentral.Id, buycentral.BarCode, buycentral.Store_Code, buycentral.ChallanNo, buycentral);
                        _BuyCentral.DeleteReturn_Temp(rchallan.Id);

                        //    }
                        //}

                        //else
                        //{

                        //    Inv_Buy buy = _BuyCentral.GetBuy_DPT_Return(rchallan.BarCode, rchallan.Store_Code, rchallan.ChallanNo_To);
                        //    if (buy != null)
                        //    {

                        //         Kamruzzaman...........
                        //        Inv_Return _return = new Inv_Return();
                        //        _return.ChallanNo = txtChalanNoReturn.Text;
                        //        _return.ChallanNo_To = rchallan.ChallanNo_To;
                        //        _return.BarCode = rchallan.BarCode;
                        //        _return.ProductId = Convert.ToInt32(rchallan.ProductId);
                        //        _return.ProductGroup = rchallan.ProductGroup;
                        //        _return.ProductName = rchallan.ProductName;
                        //        _return.Brand = rchallan.Brand;
                        //        _return.Remarks = rchallan.Remarks;
                        //        _return.StyleSize = rchallan.StyleSize;
                        //        _return.FloorName = rchallan.FloorName;
                        //        _return.UnitName = rchallan.UnitName;
                        //        _return.ReceiveQuantity = rchallan.ReceiveQuantity;
                        //        _return.CPU = rchallan.CPU;
                        //        _return.RPU = rchallan.RPU;
                        //        _return.ExpireDate = rchallan.ExpireDate;
                        //        _return.BalanceQuanity = rchallan.BalanceQuanity;
                        //        _return.PurchaseDate = rchallan.PurchaseDate;
                        //        _return.EditDate = rchallan.EditDate;
                        //        _return.OCode = rchallan.OCode;
                        //        _return.Store_Code = rchallan.Store_Code;
                        //        _return.SupplierReturnQty = rchallan.SupplierReturnQty;
                        //        _return.SupplierCode = rchallan.SupplierCode;
                        //        _return.CurrentCompanyCode = rchallan.CurrentCompanyCode;
                        //        _return.PurchaseDate = rchallan.PurchaseDate;
                        //        _return.EditDate = DateTime.Today;
                        //        _return.EditUser = rchallan.EditUser;
                        //        _return.OldCompanyCode = rchallan.OldCompanyCode;
                        //        _return.ReturnDate = DateTime.Today;
                        //        _return.ERetQty = rchallan.ERetQty;
                        //        _return.OldCompanyName = rchallan.OldCompanyName;
                        //        _return.OldCompanyId = rchallan.OldCompanyId;
                        //        _return.ReturnType = "DepartmentToStore";
                        //        _return.EID = rchallan.EID;
                        //        _return.DPT_CODE = rchallan.DPT_CODE;

                        //        _BuyCentral.InsertReturn(_return);

                        //        buy.BalanceQuanity = buy.BalanceQuanity + rchallan.ERetQty;
                        //        buyCentral.Id = Convert.ToInt16(hidId.Value);
                        //        _BuyCentral.Update_Return_DptWise(buy.Id, buy.BarCode, buy.Store_Code, buy.ChallanNo, buy);
                        //        _BuyCentral.DeleteReturn_Temp(rchallan.Id);
                        //    }

                        //    else
                        //    {

                        //    }
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

        protected void txtBalanceQty_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtReturnqty_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtRemainingqty_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ddlReturnFrom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}