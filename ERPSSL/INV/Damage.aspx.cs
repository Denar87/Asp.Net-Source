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
    public partial class Damage : System.Web.UI.Page
    {
        PriceAndDamage damage = new PriceAndDamage();
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
                    // FillCompany();
                    GetAllStore();
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
            catch
            {

            }

        }

        //public void FillCompany()
        //{
        //    ddlStore.DataSource = ic.GetCompanyList();
        //    ddlStore.DataValueField = "CompanyCode";
        //    ddlStore.DataTextField = "CompanyName";
        //    ddlStore.DataBind();
        //    ddlStore.Items.Insert(0, new ListItem("Select One", "0"));

        //}
        private void FillProductName(string cmpCode)
        {

            if (Convert.ToInt32(ddlProductGroup.SelectedValue) > 0)
            {
                ddlProduct.DataSource = ic.GetProductListByStore(Convert.ToInt32(ddlProductGroup.SelectedValue), cmpCode);
                ddlProduct.DataValueField = "BarCode";
                ddlProduct.DataTextField = "ProductName";
                ddlProduct.DataBind();
                ddlProduct.Items.Insert(0, new ListItem("Select One", "0"));
            }
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string barCode = ddlProduct.SelectedValue.ToString();
                string StoreCode = ddlStore.SelectedValue.ToString();
                hdnBarCode.Value = ddlProduct.SelectedValue.ToString();

                List<productsDetails> details = _BuyCentral.GetAllProduct_Bycentral_ChallanNo(barCode, StoreCode).ToList();
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




                //DataTable dt = ic.GetProductByBarCodeAndStore(barCode, cmpCode);
                //foreach (DataRow dr in dt.Rows)
                //{
                //    txtBalanceQty.Text = dr["BalanceQuanity"].ToString();
                //    //txtDamageQty.Text = dr["DamageQty"].ToString();
                //}
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private string GetNewChallanNo(string Code, DateTime day)
        {
            return damage.GetDamageChalanNo(Code, day);
        }

        protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            FillProductGroup();
            string StoreCode = ddlStore.SelectedValue.ToString();
            txtChalanNo.Text = GetNewChallanNo(StoreCode, DateTime.Parse(txtDate.Text));
        }

        public void FillProductGroup()
        {

            ddlProductGroup.DataSource = ic.GetListGroup();
            ddlProductGroup.DataValueField = "GroupId";
            ddlProductGroup.DataTextField = "GroupName";
            ddlProductGroup.DataBind();
            ddlProductGroup.Items.Insert(0, new ListItem("Select One", "0"));

        }

        protected void ddlProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlProduct.Enabled = true;
            string cmpCode = ddlStore.SelectedValue.ToString();
            if (cmpCode != "0")
            {
                FillProductName(cmpCode);
            }
        }



        protected void BtnSave_Click(object sender, EventArgs e)
        {

            try
            {
                List<Inv_Damage_Temp> _Inv_Damage_Temp = new List<Inv_Damage_Temp>();
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
                            Inv_Damage_Temp returnTemp = new Inv_Damage_Temp();
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
                            DropDownList ddlDamageCategory = (DropDownList)gvr.FindControl("ddlDamageCategory");
                            Label lblBarCode = (Label)gvr.FindControl("lblBarCode");
                            Label lblUnitName = (Label)gvr.FindControl("lblUnitName");
                            TextBox txtReturnQty = (TextBox)gvr.FindControl("txtReturnQty");
                            TextBox txtRemarks = (TextBox)gvr.FindControl("txtRemarks");
                            if (txtRemarks.Text == "")
                            {
                                returnTemp.Remarks = "N/A";
                            }
                            else
                            {
                                returnTemp.Remarks = txtRemarks.Text;
                            }
                            int ReturnQty = int.Parse(txtReturnQty.Text);


                            returnTemp.ChallanNo = txtChalanNo.Text;
                            returnTemp.Challan_No_To = lblChallanNo.Text;
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
                            returnTemp.CompanyCode = lblCompanyCode.Text;
                            if (lblDeliveryQty.Text == "")
                            {
                                returnTemp.DeliveryQty = 0;
                            }
                            else
                            {
                                returnTemp.DeliveryQty = Convert.ToDouble(lblDeliveryQty.Text);
                            }

                            returnTemp.EditDate = DateTime.Today;
                            Guid user = (((SessionUser)Session["SessionUser"]).UserId);
                            returnTemp.EditUser = user;
                            returnTemp.OCode = "8989";
                            returnTemp.CompanyCode = CentralCode.ToString();
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
                            returnTemp.DamageQty = ReturnQty;
                            returnTemp.UnitName = lblUnitName.Text;
                            returnTemp.DamageCategory = ddlDamageCategory.SelectedItem.Text;


                            _context.Inv_Damage_Temp.AddObject(returnTemp);
                        }
                    }
                    _context.SaveChanges();


                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Damage Process Temporary successfully')", true);
                    GridShow.DataSource = null;
                    GridShow.DataBind();
                    List<productsDetails> details = _BuyCentral.GetAllProduct_DamageTemp_ChallanNo(txtChalanNo.Text).ToList();
                    if (details.Count > 0)
                    {
                        grdDamage.DataSource = details;
                        grdDamage.DataBind();

                    }
                    else
                    {
                        grdDamage.DataSource = null;
                        grdDamage.DataBind();
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
            //string BarCode = hdnBarCode.Value.ToString();

            //if (BarCode == string.Empty || ddlStore.SelectedValue == "0" || txtDamageQty.Text == string.Empty)
            //{
            //    return;
            //}
            //try
            //{
            //    //DateTime date = DateTime.Today;
            //    //try
            //    //{
            //    //    date = DateTime.Parse(txtDate.Text);
            //    //}
            //    //catch { }

            //    Hashtable ht = new Hashtable();
            //    ht.Add("ChallanNo", txtChalanNo.Text);
            //    ht.Add("BarCode", BarCode);
            //    ht.Add("Store_Code", ddlStore.SelectedValue.ToString());
            //    ht.Add("DamageDate", txtDate.Text);
            //    ht.Add("DamageQty", txtDamageQty.Text);
            //    ht.Add("CompanyCode", CentralCode.ToString());
            //    DataTable dt = damage.DamageStoreWise(ht);

            //    //if ()
            //    //{
            //    //lblMessage.Text = "<font color='green'>Product damage information inserted successfully!</font>";
            //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Product damage information inserted successfully!')", true);
            //    grdDamage.DataSource = dt;
            //    grdDamage.DataBind();
            //    ClearForm();
            //    //}
            //    //else
            //    //{
            //    //    lblMessage.Text = "<font color='red'>Error in inserting product damage information!</font>";
            //    //}

            //}
            //catch { }
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

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string Edit_User = ((SessionUser)Session["SessionUser"]).UserId.ToString();

                List<Inv_Damage_Temp> damageList = new List<Inv_Damage_Temp>();
                string challanNo = txtChalanNo.Text.Trim();
                damageList = rChallanBll.GetTempDanmage(((SessionUser)Session["SessionUser"]).OCode, challanNo);

                foreach (Inv_Damage_Temp rchallan in damageList)
                {
                    Inv_BuyCentral buycentral = _BuyCentral.GetBuyForReturn(rchallan.BarCode, rchallan.Store_Code);
                    if (buycentral != null)
                    {

                        // Kamruzzaman...........
                        Inv_Damage _damage = new Inv_Damage();
                        _damage.ChallanNo = txtChalanNo.Text;
                        _damage.Challan_No_To = rchallan.Challan_No_To;
                        _damage.BarCode = rchallan.BarCode;
                        _damage.ProductId = Convert.ToInt32(rchallan.ProductId);
                        _damage.ProductGroup = rchallan.ProductGroup;
                        _damage.ProductName = rchallan.ProductName;
                        _damage.Brand = rchallan.Brand;
                        _damage.StyleSize = rchallan.StyleSize;
                        _damage.FloorName = rchallan.FloorName;
                        _damage.UnitName = rchallan.UnitName;
                        _damage.ReceiveQuantity = rchallan.ReceiveQuantity;
                        _damage.CPU = rchallan.CPU;
                        _damage.RPU = rchallan.RPU;
                        _damage.ExpireDate = rchallan.ExpireDate;
                        _damage.BalanceQuanity = rchallan.BalanceQuanity;
                        _damage.PurchaseDate = rchallan.PurchaseDate;
                        _damage.EditDate = rchallan.EditDate;
                        _damage.OCode = rchallan.OCode;
                        _damage.Store_Code = rchallan.Store_Code;
                        _damage.SupplierReturnQty = rchallan.SupplierReturnQty;
                        _damage.CompanyCode = rchallan.CompanyCode;
                        _damage.PurchaseDate = rchallan.PurchaseDate;
                        _damage.EditDate = DateTime.Today;
                        _damage.EditUser = rchallan.EditUser;
                        _damage.DamageDate = DateTime.Today;
                        _damage.CompanyName = rchallan.CompanyName;
                        _damage.CompanyId = rchallan.CompanyId;
                        _damage.DamageQty = rchallan.DamageQty;
                        _damage.DamageCategory = rchallan.DamageCategory;
                        _damage.Remarks = rchallan.Remarks;

                        _BuyCentral.InsertDamage(_damage);

                        buycentral.BalanceQuanity = buycentral.BalanceQuanity - rchallan.DamageQty;

                        buycentral.SupplierReturnQty = buycentral.DamageQty + rchallan.DamageQty;
                        //buyCentral.Id = Convert.ToInt16(hidId.Value);
                        _BuyCentral.Update_ForReturn(buycentral.Id, buycentral.BarCode, buycentral.Store_Code, buycentral.ChallanNo, buycentral);
                        _BuyCentral.DeleteDamage_Temp(rchallan.Id);
                    }

                    else
                    {

                    }
                }
                grdDamage.DataSource = null;
                grdDamage.DataBind();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Product damage information inserted successfully!')", true);
                Response.Redirect(Request.RawUrl);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearForm()
        {
            //txtDate.Text = string.Empty;
            //txtBalanceQty.Text = string.Empty;
            //txtDamageQty.Text = string.Empty;
            //txtRemainingQty.Text = string.Empty;
            //txtUnDamagedQty.Text = string.Empty;
            //txtOldDamageQty.Text = string.Empty;
            ddlProduct.ClearSelection();
            ddlProductGroup.ClearSelection();
            //ddlStore.ClearSelection();
        }

        protected void grdDamage_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdDamage.PageIndex = e.NewPageIndex;
            //GetCategoryes();
        }

    }
}