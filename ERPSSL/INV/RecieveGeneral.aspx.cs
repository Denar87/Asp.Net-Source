using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.DAL;
using ERPSSL.INV.BLL;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace ERPSSL.INV
{
    public partial class RecieveGeneral : System.Web.UI.Page
    {
        ProductBLL productBll = new ProductBLL();
        BuyCentralBLL buyCentralBll = new BuyCentralBLL();
        RChallanBLL rChallanBll = new RChallanBLL();
        ProductDAL productDal = new ProductDAL();
        GroupBLL groupBll = new GroupBLL();
        CompanyBLL companyBll = new CompanyBLL();
        SupplierBLL supplierBll = new SupplierBLL();
        RecieveDAL recieveDAL = new RecieveDAL();
        BuyBLL buyBll = new BuyBLL();
        public static DataTable stCompany = new DataTable();
        public static int GroupId = 0;
        public static int SerialNo = 0;
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    txtDate.Text = DateTime.Today.ToShortDateString();
                    //SetCompanyData();
                    FillSupplier();
                    GetAllGroup();
                    this.GetAllStore();
                    FillOldChalan();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        public void SetCompanyData()
        {
            stCompany = companyBll.GetCentralCompany();
        }

        protected void GetAllStore()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //string OCODE = "8989";
                var row = companyBll.GetStore(OCODE);
                if (row.Count > 0)
                {
                    ddlStore.DataSource = row.ToList();
                    ddlStore.DataTextField = "StoreName";
                    ddlStore.DataValueField = "Store_Id";
                    ddlStore.DataBind();
                    ddlStore.AppendDataBoundItems = false;
                    ddlStore.Items.Insert(0, new ListItem("Select One", "0"));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillOldChalan()
        {
            try
            {
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                //string Ocode = "8989";
                ddlChalanNo.DataSource = rChallanBll.GetOldUnPostedChallan(Ocode);
                ddlChalanNo.DataValueField = "ChallanNo";
                ddlChalanNo.DataTextField = "ChallanNo";
                ddlChalanNo.DataBind();
                ddlChalanNo.Items.Insert(0, new ListItem("Select Unposted MRR", "0"));
            }
            catch { }
        }

        protected void GetAllGroup()
        {
            try
            {

                var row = groupBll.GetAllGroup();
                if (row.Count > 0)
                {
                    ddlProductGroup.DataSource = row.ToList();
                    ddlProductGroup.DataTextField = "GroupName";
                    ddlProductGroup.DataValueField = "GroupId";
                    ddlProductGroup.DataBind();
                    ddlProductGroup.AppendDataBoundItems = false;
                    ddlProductGroup.Items.Insert(0, new ListItem("Select Item Group", "0"));
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void FillSupplier()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //string OCODE = "8989";
                var row = supplierBll.GetSupplier(OCODE);
                if (row.Count > 0)
                {
                    ddlSupplier.DataSource = row.ToList();
                    ddlSupplier.DataValueField = "SupplierCode";
                    ddlSupplier.DataTextField = "SupplierName";
                    ddlSupplier.DataBind();
                    ddlSupplier.Items.Insert(0, new ListItem("Select One", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlStore.SelectedValue.ToString() != "")
                {
                    List<Inv_Company> company = companyBll.GetcompanyByCode(ddlStore.SelectedValue.ToString()).ToList();
                    //txtCompanyName.Text = company.CompanyName;

                    txtChallanNo.Text = string.Empty;
                    ddlSupplier.Items.Clear();
                    this.FillSupplier();
                    if (company.Count > 0)
                    {
                        hiddenCompanyType.Value = company.Select(x => x.CompanyType).FirstOrDefault();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        public void FillProductName()
        {
            try
            {
                if (Convert.ToInt32(ddlProductGroup.SelectedValue) > 0)
                {
                    ddlProductName.DataSource = productBll.GetProductListByGroup(Convert.ToInt32(ddlProductGroup.SelectedValue));
                    //ddlProductName.DataSource = productBll.GetProductByGroup(Convert.ToInt32(ddlProductGroup.SelectedValue));
                    ddlProductName.DataValueField = "ProductId";
                    ddlProductName.DataTextField = "ProductName";
                    ddlProductName.DataBind();
                    ddlProductName.Items.Insert(0, new ListItem("Select Item", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlSupplier_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlSupplier.SelectedValue != "0")
                {
                    lblMessage.Text = "";
                    string supCode = ddlSupplier.SelectedValue.ToString();
                    txtChallanNo.Text = rChallanBll.GetNewRChalanNo(supCode, DateTime.Parse(txtDate.Text));

                    //lblMessage.Text = "";
                    //string ChallanNo = "";
                    //DateTime dt = DateTime.Now;

                    //string supCode = ddlSupplier.SelectedValue;
                    //string date = txtDate.Text;
                    ////string companyName = "MRR";
                    //ChallanNo = supCode + dt.Year + dt.Month + dt.Day + recieveDAL.GetNewChalanId(supCode, date);
                    //txtDate.Text = DateTime.Today.ToShortDateString();

                    //txtChallanNo.Text = ChallanNo;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {

            FillProductName();
            lblMessage.Text = "";
        }

        protected void ddlProductName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(ddlProductName.SelectedValue) > 0)
                {
                    lblMessage.Text = "";
                    var result = productBll.GetProductById(Convert.ToInt32(ddlProductName.SelectedValue));
                    if (result.Count > 0)
                    {
                        var objProduct = result.First();
                        txtUnit.Text = objProduct.UnitName;
                        //txtBrand.Text = objProduct.Brand;
                        hdnBrand.Value = objProduct.Brand;
                        hdnStyle.Value = objProduct.StyleAndSize;
                        //txtStyleSize.Text = objProduct.StyleAndSize;
                        txtReOrderQty.Text = objProduct.ReOrderQty.ToString();
                        GroupId = int.Parse(objProduct.GroupId.ToString());

                        //var stock = productBll.GetProductStockById(Convert.ToInt32(ddlProductName.SelectedValue));

                        //if (stock.Count > 0)
                        //{
                        //    var objstock = stock.First();
                        //    txtBalanceQty.Text = Convert.ToString(objstock.BalanceQuanity);
                        //}
                        //else
                        //{
                        //    txtBalanceQty.Text = "0";
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtCPU_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtReceiveQty.Text != string.Empty && txtCPU.Text != string.Empty)
                {
                    int qty = Convert.ToInt32(txtReceiveQty.Text.Trim());
                    decimal cpu = Convert.ToDecimal(txtCPU.Text.Trim());
                    decimal total = qty * cpu;
                    txtTotalCost.Text = Convert.ToString(total);

                }
                //txtTotalCost.Text = (int.Parse(txtCPU.Text) * int.Parse(txtReceiveQty.Text)).ToString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private string GetCompanyIdByCode(string code)
        {
            return companyBll.GetCompanyIdByCode(code);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnSubmit.Text == "Add")
                {
                    if (txtReceiveQty.Text == string.Empty || txtCPU.Text == string.Empty)
                    {
                        return;
                    }
                    SerialNo = SerialNo + 1;
                    Inv_RChallan_Temp purchase = new Inv_RChallan_Temp();
                    purchase.Id = SerialNo;

                    //foreach (DataRow dr in stCompany.Rows)
                    //{
                    //    purchase.CompanyId = int.Parse(dr["CompanyId"].ToString());
                    //    purchase.CompanyName = dr["CompanyName"].ToString();
                    //    purchase.CompanyCode = dr["CompanyCode"].ToString();
                    //}
                    purchase.CompanyCode = ddlStore.SelectedValue.ToString();
                    purchase.CompanyName = GetCompanyNameByCode(purchase.CompanyCode);
                    purchase.CompanyId = int.Parse(GetCompanyIdByCode(ddlStore.SelectedValue.ToString()));

                    purchase.ChallanNo = txtChallanNo.Text.Trim();
                    purchase.ChallanDate = DateTime.Parse(txtDate.Text);
                    purchase.ProductId = int.Parse(ddlProductName.SelectedValue.ToString());//Convert.ToInt32(txtProductId.Text.Trim());
                    //purchase.Barcode = buyCentralBll.GetBarcode(int.Parse(purchase.ProductId.ToString()));
                    purchase.BarCode = txtbarcode.Text;
                    purchase.ProductGroup = int.Parse(ddlProductGroup.SelectedValue.ToString());

                    string pronductNameandBrand = ddlProductName.SelectedItem.ToString();
                    string[] values = pronductNameandBrand.Split('-');
                    purchase.ProductName = values[0].ToString();
                    purchase.UnitName = txtUnit.Text;
                    purchase.Brand = hdnBrand.Value;
                    purchase.StyleSize = hdnStyle.Value;
                    purchase.FloorName = txtFloorName.Text;
                    //purchase.StyleSize = txtStyleSize.Text;
                    purchase.DamageQty = 0;
                    purchase.DeliveryQty = 0;
                    purchase.SupplierReturnQty = 0;
                    purchase.OrderNo = txtOrderNo.Text;

                    try
                    {
                        purchase.PurchaseDate = DateTime.Parse(txtDate.Text);
                    }
                    catch
                    {
                        purchase.PurchaseDate = DateTime.Today;
                    }
                    purchase.ReceiveQuantity = Convert.ToInt32(txtReceiveQty.Text.Trim());


                    //if (chkBalanceStatus.Checked)
                    //    purchase.BalanceStatus = "OpeningBalance";
                    //else
                    //    purchase.BalanceStatus = "MRR";
                    decimal CPU = Convert.ToDecimal(txtCPU.Text.Trim());
                    purchase.CPU = CPU;
                    //if (txtRPU.Text == string.Empty)
                    //{
                    //    purchase.RPU = Convert.ToInt32(float.Parse(txtCPU.Text));
                    //}
                    //else
                    //{
                    //    purchase.RPU = Convert.ToInt32(float.Parse(txtRPU.Text));
                    //}
                    purchase.BalanceQuanity = Convert.ToInt32(txtBalanceQty.Text.Trim()) + purchase.ReceiveQuantity;

                    //purchase.SupplierId = 0; // obsolete; no longer used
                    purchase.SupplierCode = ddlSupplier.SelectedValue.ToString(); // identity of the supplier

                    purchase.EditDate = DateTime.Now;
                    purchase.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    purchase.OCode = OCODE;
                    //purchase.EditUser = Guid.Parse("a376708d-757f-4777-bd05-bfc89b6971ce");
                    //purchase.Ocode = "8989";

                    var RChalan = rChallanBll.GetDataByInv_RChallan_Temp(txtChallanNo.Text, txtbarcode.Text, OCODE).ToList();

                    double ReceiveQty = Convert.ToDouble(txtReceiveQty.Text);

                    if (RChalan.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Already in The List')", true);
                        return;
                        //var update = rChallanBll.UpdateInv_RChallan_Temp(txtChallanNo.Text, txtbarcode.Text, ReceiveQty, CPU);

                        //if (update == 1)
                        //{
                        //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                        //    BindPurchaseGrid(txtChallanNo.Text.Trim());
                        //    ClearProduct();
                        //    return;
                        //}
                        //else
                        //{
                        //}
                    }

                    rChallanBll.Insert(purchase);
                    BindPurchaseGrid(purchase.ChallanNo);
                    ClearProduct();
                    //lblMessage.Text = "<font color='green'>Purchase information has been added temporarily. Please post.</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Purchase information has been added temporarily. Please post.')", true);
                }
                else
                {
                    if (btnSubmit.Text == "Update")
                    {
                        double ReceiveQty = Convert.ToDouble(txtReceiveQty.Text);
                        decimal CPU = Convert.ToDecimal(txtCPU.Text.Trim());
                        decimal total = Convert.ToDecimal(txtTotalCost.Text.Trim());
                        var update = rChallanBll.UpdateInv_RChallan_Temp(txtChallanNo.Text, txtbarcode.Text, ReceiveQty);

                        if (update == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                            BindPurchaseGrid(txtChallanNo.Text.Trim());
                            ClearProduct();
                            //lblTotal.Visible = true;
                            btnSubmit.Text = "Add";
                            return;
                        }
                        else
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private string GetCompanyNameByCode(string CompanyCode)
        {
            return companyBll.GetCompanyNameByCode(CompanyCode);
        }

        public void BindPurchaseGrid(string challanNo)
        {
            gvPurchase.DataSource = rChallanBll.GetRChalanTemp(((SessionUser)Session["SessionUser"]).OCode, challanNo);
            //gvPurchase.DataSource = rChallanBll.GetRChalanTemp(("8989"), challanNo);
            gvPurchase.DataBind();
        }

        protected void ClearProduct()
        {
            txtBalanceQty.Text = string.Empty;
            txtCPU.Text = string.Empty;
            //txtBrand.Text = string.Empty;
            hdnBrand.Value = "";
            hdnStyle.Value = "";
            //txtStyleSize.Text = string.Empty;
            txtReOrderQty.Text = string.Empty;
            txtFloorName.Text = string.Empty;
            txtTotalCost.Text = string.Empty;
            txtReceiveQty.Text = string.Empty;
            txtUnit.Text = string.Empty;
            txtbarcode.Text = string.Empty;
            //txtExpDate.Text = string.Empty;
            //txtQtyVial.Text = string.Empty;
            //txtTextPerVail.Text = string.Empty;
            //txtTotalTest.Text = string.Empty;
            //txtVialPerPack.Text = string.Empty;

            ddlProductName.ClearSelection();
            ddlProductGroup.ClearSelection();
        }

        protected void gvPurchase_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(e.CommandArgument);

                if (e.CommandName == "dlt")
                {
                    rChallanBll.DeleteTempChalanById(id);
                    BindPurchaseGrid(txtChallanNo.Text.Trim());
                }
                if (e.CommandName == "edt")
                {

                    foreach (Inv_RChallan_Temp temp in _context.Inv_RChallan_Temp.Where(x => x.Id == id).ToList())
                    {

                        ddlProductGroup.SelectedValue = temp.ProductGroup.ToString();
                        FillProductName();
                        txtBalanceQty.Text = temp.BalanceQuanity.ToString();
                        txtCPU.Text = temp.CPU.ToString();
                        txtReceiveQty.Text = temp.ReceiveQuantity.ToString();
                        txtbarcode.Text = temp.BarCode.ToString();
                        txtUnit.Text = temp.UnitName.ToString();
                        txtTotalCost.Text = temp.ChallanTotal.ToString();
                        btnSubmit.Text = "Update";
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void FillFormForOldChallan(string challanNo)
        {
            try
            {
                DataTable dt = new DataTable();
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                //string Ocode = "8989";
                dt = rChallanBll.OldChallan(challanNo, Ocode);
                foreach (DataRow dr in dt.Rows)
                {
                    txtChallanNo.Text = dr["ChallanNo"].ToString();
                    ddlSupplier.SelectedValue = dr["SupplierCode"].ToString();
                    txtDate.Text = DateTime.Parse(dr["ChallanDate"].ToString()).ToShortDateString();
                    //ddlCompanyCode.SelectedValue = dr["CompanyId"].ToString();
                    //txtCompanyName.Text = dr["CompanyName"].ToString();
                    hiddenCompanyType.Value = dr["CompanyType"].ToString();
                }
                ddlProductGroup.SelectedValue = "0";
                ddlProductName.SelectedValue = "0";
                txtUnit.Text = string.Empty;
                txtTotalCost.Text = string.Empty;
                //txtBrand.Text = string.Empty;
                hdnBrand.Value = "";
                hdnStyle.Value = "";
                //txtStyleSize.Text = string.Empty;
                txtReOrderQty.Text = string.Empty;
                txtFloorName.Text = string.Empty;
                txtReceiveQty.Text = string.Empty;
                txtBalanceQty.Text = string.Empty;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlChalanNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string challanNo = ddlChalanNo.SelectedValue.ToString();
                FillFormForOldChallan(challanNo);
                BindPurchaseGrid(challanNo);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private Inv_RChallan ConvertTmpToRchallan(Inv_RChallan_Temp t)
        {
            Inv_RChallan c = new Inv_RChallan();
            c.BalanceQty = t.BalanceQuanity;
            c.Barcode = t.BarCode;
            c.Brand = t.Brand;
            c.ChallanDate = t.ChallanDate;
            c.ChallanNo = t.ChallanNo;
            c.ChallanTotal = t.ChallanTotal;
            c.CompanyCode = t.CompanyCode;
            c.CompanyId = t.CompanyId;
            c.CompanyName = t.CompanyName;
            c.CPU = t.CPU;
            c.DeliveryQty = t.DeliveryQty;
            c.EditDate = t.EditDate;
            c.EditUser = t.EditUser;
            c.FloorName = t.FloorName;
            c.Id = t.Id;
            c.PurchaseDate = t.PurchaseDate;
            c.Ocode = t.OCode;
            c.ProductGroup = t.ProductGroup;
            c.ProductId = t.ProductId;
            c.ProductName = t.ProductName;
            c.ReceiveQuantity = t.ReceiveQuantity;
            c.Remarks = t.Item_Remarks;
            c.RPU = t.RPU;
            c.ExpireDate = t.ExpireDate;
            c.StyleSize = t.StyleSize;
            c.FloorName = t.FloorName;
            c.SupplierCode = t.SupplierCode;
            c.SupplierId = t.SupplierId;
            c.SupplierReturnQty = t.SupplierReturnQty;
            c.UnitName = t.UnitName;
            c.OrderNo = t.OrderNo;

            // if neeeded
            //c.VailPerPack = t.VailPerPack;
            //c.TestPerVail = t.TestPerVail;
            //c.TotalVailQty = t.TotalVailQty;
            //c.BalanceStatus = t.BalanceStatus;
            return c;
        }

        protected void ClearForm()
        {
            BindPurchaseGrid(txtChallanNo.Text.Trim());
            //ddlCompanyCode.SelectedValue = "0";
            //txtCompanyName.Text = string.Empty;
            ddlSupplier.SelectedValue = "0";
            //txtSupplierId.Text = string.Empty;
            txtChallanNo.Text = string.Empty;
            txtRefNo.Text = string.Empty;
            ClearProduct();
            SerialNo = 0;

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<Inv_RChallan_Temp> staticPurchaseList = new List<Inv_RChallan_Temp>();
                string challanNo = txtChallanNo.Text.Trim();
                staticPurchaseList = rChallanBll.GetTempRChalan(((SessionUser)Session["SessionUser"]).OCode, challanNo);
                //staticPurchaseList = rChallanBll.GetTempRChalan("8989", challanNo);

                if (hiddenCompanyType.Value.Trim() == "CENTRAL")
                {
                    foreach (Inv_RChallan_Temp rchallan in staticPurchaseList)
                    {
                        Inv_BuyCentral buyCentral = buyCentralBll.GetBuyCentralByCompanyAndBarcode(rchallan.BarCode, rchallan.CompanyCode);
                        if (buyCentral == null)
                        {
                            // Insert New
                            Inv_BuyCentral newBuyCentral = new Inv_BuyCentral();
                            newBuyCentral.ChallanNo = rchallan.ChallanNo;
                            newBuyCentral.CompanyId = rchallan.CompanyId;
                            newBuyCentral.CompanyCode = rchallan.CompanyCode;
                            newBuyCentral.CompanyName = rchallan.CompanyName;
                            newBuyCentral.BarCode = rchallan.BarCode;
                            newBuyCentral.ProductId = Convert.ToInt32(rchallan.ProductId);
                            newBuyCentral.ProductGroup = rchallan.ProductGroup;
                            newBuyCentral.ProductName = rchallan.ProductName;
                            newBuyCentral.Brand = rchallan.Brand;
                            newBuyCentral.StyleSize = rchallan.StyleSize;
                            newBuyCentral.FloorName = rchallan.FloorName;
                            newBuyCentral.UnitName = rchallan.UnitName;
                            newBuyCentral.ReceiveQuantity = rchallan.ReceiveQuantity;
                            newBuyCentral.CPU = rchallan.CPU;
                            newBuyCentral.RPU = rchallan.RPU;
                            newBuyCentral.ExpireDate = rchallan.ExpireDate;
                            newBuyCentral.BalanceQuanity = rchallan.BalanceQuanity;
                            newBuyCentral.PurchaseDate = rchallan.PurchaseDate;
                            newBuyCentral.EditDate = rchallan.EditDate;
                            newBuyCentral.OCode = rchallan.OCode;
                            newBuyCentral.OrderNo = rchallan.OrderNo;
                            buyCentralBll.Insert(newBuyCentral);
                        }

                        else
                        {
                            buyCentral.BalanceQuanity = buyCentral.BalanceQuanity + rchallan.ReceiveQuantity;
                            buyCentral.CPU = rchallan.CPU;
                            buyCentral.RPU = rchallan.RPU;
                            buyCentral.ExpireDate = rchallan.ExpireDate;
                            buyCentral.ReceiveQuantity = buyCentral.ReceiveQuantity + rchallan.ReceiveQuantity;
                            //buyCentral.Id = Convert.ToInt16(hidId.Value);
                            buyCentralBll.Update(buyCentral, buyCentral.Id);
                        }

                        rChallanBll.Insert(ConvertTmpToRchallan(rchallan));
                        rChallanBll.DeleteTempChalanById(rchallan.Id);

                        //string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                        //string Edit_User = ((SessionUser)Session["SessionUser"]).UserId.ToString();
                        //string Company_Code = "CMP201506051";
                        //string ModuleType = "Inventory";
                        //string VoucherType = "PAYMENT";

                        //rChallanBll.Enter_VoucherDetails(OCODE, Company_Code,Edit_User, ModuleType, VoucherType, ConvertTmpToRchallan(rchallan));

                        //lblMessage.Text = "<font color='green'>Purchase information posted successfully</font>";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Purchase information posted successfully')", true);
                        gvPurchase.DataSource = null;
                        gvPurchase.DataBind();
                        ddlChalanNo.Items.Clear();
                    }
                    ClearForm();
                }

                else // hiddenCompanyType = General
                {

                    foreach (Inv_RChallan_Temp rchallan in staticPurchaseList)
                    {
                        Inv_Buy buy = buyBll.GetBuyByCompanyAndBarcode(rchallan.BarCode, rchallan.CompanyCode);

                        if (buy == null)
                        { // Insert New

                            Inv_Buy invBuy = new Inv_Buy();
                            invBuy.ChallanNo = rchallan.ChallanNo;
                            invBuy.CompanyId = rchallan.CompanyId;
                            invBuy.CompanyCode = rchallan.CompanyCode;
                            invBuy.CompanyName = rchallan.CompanyName;
                            invBuy.BarCode = rchallan.BarCode;
                            invBuy.ProductId = Convert.ToInt32(rchallan.ProductId);
                            invBuy.ProductGroup = rchallan.ProductGroup;
                            invBuy.ProductName = rchallan.ProductName;
                            invBuy.Brand = rchallan.Brand;
                            invBuy.StyleSize = rchallan.StyleSize;
                            invBuy.FloorName = rchallan.FloorName;
                            invBuy.UnitName = rchallan.UnitName;
                            invBuy.ReceiveQuantity = rchallan.ReceiveQuantity;
                            invBuy.CPU = rchallan.CPU;
                            invBuy.RPU = rchallan.RPU;
                            invBuy.ExpireDate = rchallan.ExpireDate;
                            invBuy.BalanceQuanity = rchallan.BalanceQuanity;
                            invBuy.PurchaseDate = rchallan.PurchaseDate;
                            invBuy.DeliveryQty = Convert.ToInt32(rchallan.DeliveryQty);
                            invBuy.EditDate = rchallan.EditDate;
                            invBuy.OCode = rchallan.OCode;
                            invBuy.OrderNo = rchallan.OrderNo;
                            buyBll.Insert(invBuy);

                        }
                        else
                        {

                            buy.BalanceQuanity = buy.BalanceQuanity + rchallan.ReceiveQuantity;
                            buy.CPU = rchallan.CPU;
                            buy.RPU = rchallan.RPU;
                            buy.ExpireDate = rchallan.ExpireDate;
                            buy.ReceiveQuantity = buy.ReceiveQuantity + rchallan.ReceiveQuantity;
                            int Id = Convert.ToInt16(hidId.Value);
                            buyBll.Update(buy, Id);
                        }

                        rChallanBll.Insert(ConvertTmpToRchallan(rchallan));
                        rChallanBll.DeleteTempChalanById(rchallan.Id);
                        //  lblMessage.Text = "<font color='green'>Purchase information posted successfully</font>";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Purchase information posted successfully')", true);
                        ddlChalanNo.Items.Clear();

                    }
                    ClearForm();
                }


                // End of IF CENTRAL OR GENERAL
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string challanNo = txtChallanNo.Text.Trim();
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                DataTable dataSource = rChallanBll.GetVoucherReport(challanNo, Ocode);
                ReportViewerPurchase.LocalReport.DataSources.Clear();
                ReportDataSource reportDataset = new ReportDataSource("PurchaseVoucher_DS", dataSource);
                ReportViewerPurchase.LocalReport.DataSources.Add(reportDataset);
                ReportViewerPurchase.LocalReport.ReportPath = Server.MapPath("Reports/PurchaseVoucher_RPT.rdlc");
                ReportViewerPurchase.LocalReport.Refresh();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtbarcode_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (hiddenCompanyType.Value.Trim() == "CENTRAL")
                {
                    Inv_BuyCentral buyCentral = buyCentralBll.GetBuyCentralByCompanyAndBarcode(txtbarcode.Text, ddlStore.SelectedValue.ToString());
                    if (buyCentral != null)
                    {
                        txtBalanceQty.Text = Convert.ToString(buyCentral.BalanceQuanity);
                    }
                    else
                    {
                        txtBalanceQty.Text = "0";
                    }
                }
                else
                {
                    Inv_Buy invBuy = buyBll.GetBuyByCompanyAndBarcode(txtbarcode.Text, ddlStore.SelectedValue.ToString());
                    if (invBuy != null)
                    {
                        txtBalanceQty.Text = Convert.ToString(invBuy.BalanceQuanity);
                    }
                    else
                    {
                        txtBalanceQty.Text = "0";
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
