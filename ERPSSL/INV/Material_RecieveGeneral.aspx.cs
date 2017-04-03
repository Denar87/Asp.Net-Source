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
    public partial class Material_RecieveGeneral : System.Web.UI.Page
    {

        ProjectBLL projectBll = new ProjectBLL();
        StoreUnitBLL aStoreUnitBLL = new StoreUnitBLL();
        StoreBLL aStoreBll = new StoreBLL();
        UnitBLL unitBll = new UnitBLL();
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

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtDate.Text = DateTime.Today.ToShortDateString();
                SetCompanyData();
                FillSupplier();
                GetAllGroup();
                //this.GetAllStore();
                FillOldChalan();
                GetAllUnit();

                FillSeniorPacker();
                GetAllProject();
                //GetAllStore();
                GetAllStoreUnit();
            }
        }

        private void FillSeniorPacker()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                //var row = surveyBll.GetHeadPacker(OCODE).ToList();
                //if (row.Count > 0)
                //{
                //    ddlSrpacker.Items.Clear();
                //    ddlSrpacker.DataSource = row.ToList();
                //    ddlSrpacker.DataTextField = "FirstName";
                //    ddlSrpacker.DataValueField = "EID";
                //    ddlSrpacker.DataBind();
                //    ddlSrpacker.Items.Insert(0, new ListItem("---Select One ---", "0"));
                //}
            }
            catch (Exception)
            {
                // lblMessage.Text = "Unable to complete the operation...";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Unable to complete the operation...')", true);
            }
        }

        protected void GetAllUnit()
        {
            try
            {

                var row = unitBll.GetAllUnit();
                if (row.Count > 0)
                {
                    ddlUMCheckedCondition.DataSource = row.ToList();
                    ddlUMCheckedCondition.DataTextField = "UnitName";
                    ddlUMCheckedCondition.DataValueField = "UnitId";
                    ddlUMCheckedCondition.DataBind();
                    ddlUMCheckedCondition.AppendDataBoundItems = false;
                    ddlUMCheckedCondition.Items.Insert(0, new ListItem("---Select One---", "0"));
                }

            }
            catch
            {

            }
        }

        protected void GetAllProject()
        {
            try
            {
                var row = projectBll.GetAllProject();
                if (row.Count > 0)
                {
                    ddlProject.DataSource = row.ToList();
                    ddlProject.DataTextField = "Project_Name";
                    ddlProject.DataValueField = "Project_Id";
                    ddlProject.DataBind();
                    ddlProject.Items.Insert(0, new ListItem("---Select One---", "0"));
                }

            }
            catch
            {

            }
        }

        protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var row = aStoreBll.GetStoreByProjectID(ddlProject.SelectedItem.Text);
                if (row.Count > 0)
                {
                    ddlStoreName.DataSource = row.ToList();
                    ddlStoreName.DataTextField = "StoreName";
                    ddlStoreName.DataValueField = "Store_Id";
                    ddlStoreName.DataBind();
                    ddlStoreName.Items.Insert(0, new ListItem("---Select One---", "0"));
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void GetAllStore()
        {
            try
            {
                var row = aStoreBll.GetStore();
                if (row.Count > 0)
                {
                    ddlStoreName.DataSource = row.ToList();
                    ddlStoreName.DataTextField = "StoreName";
                    ddlStoreName.DataValueField = "Store_Id";
                    ddlStoreName.DataBind();
                    ddlStoreName.Items.Insert(0, new ListItem("---Select One---", "0"));
                }

            }
            catch
            {

            }
        }

        private void GetAllStoreUnit()
        {
            try
            {
                var row = aStoreUnitBLL.GetAllStoreUnit();
                if (row.Count > 0)
                {
                    ddlStoreUnit.DataSource = row.ToList();
                    ddlStoreUnit.DataTextField = "Store_Unit_Name";
                    ddlStoreUnit.DataValueField = "Store_Unit_Id";
                    ddlStoreUnit.DataBind();
                    ddlStoreUnit.Items.Insert(0, new ListItem("---Select One---", "0"));
                }

            }
            catch
            {

            }
        }

        public void SetCompanyData()
        {
            stCompany = companyBll.GetCentralCompany();
        }

        //protected void GetAllStore()
        //{
        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        //string OCODE = "8989";
        //        var row = companyBll.GetCompnay(OCODE);
        //        if (row.Count > 0)
        //        {
        //            ddlStore.DataSource = row.ToList();
        //            ddlStore.DataTextField = "CompanyName";
        //            ddlStore.DataValueField = "CompanyId";
        //            ddlStore.DataBind();
        //            ddlStore.AppendDataBoundItems = false;
        //            ddlStore.Items.Insert(0, new ListItem("Select One", "0"));
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

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

        //protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //    if (Convert.ToInt32(ddlStore.SelectedValue) > 0)
        //    {
        //        Inv_Company company = companyBll.GetcompanyById(Convert.ToInt32(ddlStore.SelectedValue));
        //        //txtCompanyName.Text = company.CompanyName;
        //        txtChallanNo.Text = string.Empty;
        //        ddlSupplier.Items.Clear();
        //        this.FillSupplier();
        //        hiddenCompanyType.Value = company.CompanyType;
        //    }

        //}

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

                    var result = supplierBll.GetSupplierInfo(((SessionUser)Session["SessionUser"]).OCode, ddlSupplier.SelectedValue).ToList();
                    if (result.Count > 0)
                    {
                        var objSupplerInfo = result.First();
                        txtSupplierInfo.Text = objSupplerInfo.Address;
                    }

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
                        //txtCPU.Text = objProduct.Price.ToString();

                        txtCPU.Text = String.Format("{0:0.00}", objProduct.Price);

                        //txtBrand.Text = objProduct.Brand;
                        hdnBrand.Value = objProduct.Brand;
                        hdnStyle.Value = objProduct.StyleAndSize;
                        //txtStyleSize.Text = objProduct.StyleAndSize;
                        //txtReOrderQty.Text = objProduct.ReOrderQty.ToString();
                        GroupId = int.Parse(objProduct.GroupId.ToString());

                        var stock = productBll.GetProductStockById_FromStoreUnit(Convert.ToInt32(ddlProductName.SelectedValue), ddlProject.SelectedValue, Convert.ToInt32(ddlStoreName.SelectedValue), Convert.ToInt32(ddlStoreUnit.SelectedValue));

                        if (stock.Count > 0)
                        {
                            var objstock = stock.First();
                            //txtBalanceQty.Text = "Stock-" + Convert.ToString(objstock.BalanceQuanity);
                            txtBalanceQty.Text = Convert.ToString(objstock.BalanceQuanity);
                        }
                        else
                        {
                            txtBalanceQty.Text = "0";
                        }

                        //if (hiddenCompanyType.Value == "CENTRAL")
                        //{
                        //    Inv_BuyCentral buyCentral = buyCentralBll.GetBuyCentralByCompanyAndBarcode(hiddenBarcode.Value, Convert.ToInt32(ddlCompanyCode.SelectedValue));
                        //    if (buyCentral != null)
                        //    {
                        //        txtBalanceQty.Text = Convert.ToString(buyCentral.BalanceQuanity);
                        //    }
                        //    else
                        //    {
                        //        txtBalanceQty.Text = "0";
                        //    }
                        //}
                        //else
                        //{
                        //    Inv_Buy invBuy = buyBll.GetBuyByCompanyAndBarcode(hiddenBarcode.Value, Convert.ToInt32(ddlCompanyCode.SelectedValue));
                        //    if (invBuy != null)
                        //    {
                        //        txtBalanceQty.Text = Convert.ToString(invBuy.BalanceQuanity);
                        //    }
                        //    else
                        //    {
                        //        txtBalanceQty.Text = "0";
                        //    }
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

        //private string GetCompanyCodeById(int Id)
        //{
        //    return companyBll.GetCompanyCodeById(Id);
        //}

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtReceiveQty.Text == string.Empty || txtCPU.Text == string.Empty)
                {
                    return;
                }
                SerialNo = SerialNo + 1;
                Inv_RChallan_Temp purchase = new Inv_RChallan_Temp();
                purchase.Id = SerialNo;

                foreach (DataRow dr in stCompany.Rows)
                {
                    purchase.CompanyId = int.Parse(dr["CompanyId"].ToString());
                    purchase.CompanyName = dr["CompanyName"].ToString();
                    purchase.CompanyCode = dr["CompanyCode"].ToString();
                }
                //purchase.CompanyId = Convert.ToInt32(ddlCompanyCode.SelectedValue);
                //purchase.CompanyName = txtCompanyName.Text.Trim();
                //purchase.CompanyCode = GetCompanyCodeById(int.Parse(purchase.CompanyId.ToString()));

                purchase.ChallanNo = txtChallanNo.Text.Trim();
                purchase.ChallanDate = DateTime.Parse(txtDate.Text);
                purchase.ProductId = int.Parse(ddlProductName.SelectedValue.ToString());//Convert.ToInt32(txtProductId.Text.Trim());
                //purchase.Barcode = buyCentralBll.GetBarcode(int.Parse(purchase.ProductId.ToString()));
                purchase.BarCode = purchase.ProductId.ToString();
                purchase.ProductGroup = int.Parse(ddlProductGroup.SelectedValue.ToString());

                string productNameandBrand = ddlProductName.SelectedItem.ToString();
                string[] values = productNameandBrand.Split(' ', '-');
                purchase.ProductName = values[0].ToString();

                purchase.UnitName = txtUnit.Text;
                purchase.Brand = hdnBrand.Value;
                purchase.StyleSize = hdnStyle.Value;
                purchase.DamageQty = 0;
                purchase.DeliveryQty = 0;
                purchase.SupplierReturnQty = 0;
                purchase.Item_Remarks = txtRemarks.Text;

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

                purchase.CPU = Convert.ToDecimal(txtCPU.Text.Trim());

                //if (txtRPU.Text == string.Empty)
                //{
                //    purchase.RPU = Convert.ToInt32(float.Parse(txtCPU.Text));
                //}
                //else
                //{
                //    purchase.RPU = Convert.ToInt32(float.Parse(txtRPU.Text));
                //}

                //decimal balanceQty = Convert.ToDecimal(txtBalanceQty.Text);
                //string[] value = balanceQty.ToString().Split('-');
                //decimal result = Convert.ToDecimal(value[0]);

                //purchase.BalanceQty = Convert.ToDecimal(result) + purchase.ReceiveQuantity;

                purchase.BalanceQuanity = Convert.ToDouble(txtBalanceQty.Text);
                purchase.SupplierId = 0; // obsolete; no longer used
                purchase.SupplierCode = ddlSupplier.SelectedValue.ToString(); // identity of the supplier


                purchase.EditDate = DateTime.Now;
                purchase.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                purchase.OCode = ((SessionUser)Session["SessionUser"]).OCode;
                //purchase.EditUser = Guid.Parse("a376708d-757f-4777-bd05-bfc89b6971ce");
                //purchase.Ocode = "8989";

                purchase.Item_Remarks = txtItemRemarks.Text;
                purchase.PO_No = txtPONo.Text;
                purchase.Mode_Of_Delivery = ddlModeofDelivery.SelectedItem.Text;
                purchase.Unit_Cheked = ddlUMCheckedCondition.SelectedItem.Text;
                purchase.Reciept_Condition = ddlRecieptCondition.SelectedItem.Text;
                purchase.Delivery_Type = ddlDelivery.SelectedItem.Text;
                purchase.Senior_Packer_EID = ddlSrpacker.SelectedValue;
                purchase.Move_Coordinator = txtMoveOrdinator.Text;
                purchase.Project_Code = ddlProject.SelectedValue;
                purchase.Store_Id = Convert.ToInt16(ddlStoreName.SelectedValue);
                purchase.Store_Unit_Id = Convert.ToInt16(ddlStoreUnit.SelectedValue);

                rChallanBll.Insert(purchase);
                BindPurchaseGrid(purchase.ChallanNo);
                ClearProduct();
                //lblMessage.Text = "<font color='green'>Purchase information has been added temporarily. Please post.</font>";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Purchase information has been added temporarily. Please post.')", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
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
            //txtReOrderQty.Text = string.Empty;
            //txtFloorName.Text = string.Empty;
            txtTotalCost.Text = string.Empty;
            txtReceiveQty.Text = string.Empty;
            txtUnit.Text = string.Empty;
            txtItemRemarks.Text = "";
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
            int id = Convert.ToInt32(e.CommandArgument);
            rChallanBll.DeleteTempChalanById(id);
            BindPurchaseGrid(txtChallanNo.Text.Trim());

        }

        private void FillFormForOldChallan(string challanNo)
        {
            try
            {
                DataTable dt = new DataTable();
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
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
                hdnBrand.Value = "";
                hdnStyle.Value = "";
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
            string challanNo = ddlChalanNo.SelectedValue.ToString();
            FillFormForOldChallan(challanNo);
            BindPurchaseGrid(challanNo);
        }

        private Inv_RChallan ConvertTmpToRchallan(Inv_RChallan_Temp t)
        {
            Inv_RChallan c = new Inv_RChallan();
            c.BalanceQty = t.BalanceQuanity;
            c.Barcode = t.BarCode;
            c.Brand = t.Brand;
            c.ChallanDate = t.PurchaseDate;
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
            c.RPU = t.RPU;
            c.ExpireDate = t.ExpireDate;
            c.StyleSize = t.StyleSize;
            c.SupplierCode = t.SupplierCode;
            c.SupplierReturnQty = t.SupplierReturnQty;
            c.UnitName = t.UnitName;

            // if neeeded
            //c.VailPerPack = t.VailPerPack;
            //c.TestPerVail = t.TestPerVail;
            //c.TotalVailQty = t.TotalVailQty;
            //c.BalanceStatus = t.BalanceStatus;

            c.Item_Remarks = t.Item_Remarks;
            c.PO_No = t.PO_No;
            c.Mode_Of_Delivery = t.Mode_Of_Delivery;
            c.Unit_Cheked = t.Unit_Cheked;
            c.Reciept_Condition = t.Reciept_Condition;
            c.Delivery_Type = t.Delivery_Type;
            c.Senior_Packer_EID = t.Senior_Packer_EID;
            c.Move_Coordinator = t.Move_Coordinator;
            c.Project_Code = t.Project_Code;
            c.Store_Id = t.Store_Id;
            c.Store_Unit_Id = t.Store_Unit_Id;

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

            txtPONo.Text = "";
            txtSupplierInfo.Text = "";
            txtRemarks.Text = "";
            ddlModeofDelivery.SelectedValue = "0";
            ddlUMCheckedCondition.SelectedValue = "0";
            ddlRecieptCondition.SelectedValue = "0";
            ddlDelivery.SelectedValue = "0";
            ddlSrpacker.SelectedValue = "0";
            ddlProject.SelectedValue = "0";
            ddlStoreName.SelectedValue = "0";
            ddlStoreUnit.SelectedValue = "0";
            txtMoveOrdinator.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<Inv_RChallan_Temp> staticPurchaseList = new List<Inv_RChallan_Temp>();
                string challanNo = txtChallanNo.Text.Trim();
                staticPurchaseList = rChallanBll.GetTempRChalan(((SessionUser)Session["SessionUser"]).OCode, challanNo);
                //staticPurchaseList = rChallanBll.GetTempRChalan("8989", challanNo);
                if (gvPurchase.Rows.Count == 0)
                {
                    //lblMessage.Text = "<font color='red'>Item list is empty!</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Item list is empty!')", true);
                    return;
                }
                //if (hiddenCompanyType.Value == "CENTRAL")
                //{
                foreach (Inv_RChallan_Temp rchallan in staticPurchaseList)
                {
                    Inv_BuyCentral buyCentral = buyCentralBll.GetBuyCentralByBarcode_Store(rchallan.BarCode, Convert.ToInt32(rchallan.CompanyId), rchallan.Project_Code, Convert.ToInt32(rchallan.Store_Id), Convert.ToInt32(rchallan.Store_Unit_Id));
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
                        newBuyCentral.Item_Remarks = rchallan.Item_Remarks;
                        newBuyCentral.Project_Code = rchallan.Project_Code;
                        newBuyCentral.Store_Id = rchallan.Store_Id;
                        newBuyCentral.Store_Unit_Id = rchallan.Store_Unit_Id;

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
                        buyCentralBll.UpdateBuyCentralByStore(buyCentral, Convert.ToInt32(buyCentral.Id), buyCentral.Project_Code, Convert.ToInt32(buyCentral.Store_Id), Convert.ToInt32(buyCentral.Store_Unit_Id));
                    }

                    rChallanBll.Insert(ConvertTmpToRchallan(rchallan));
                    rChallanBll.DeleteTempChalanById(rchallan.Id);
                    //lblMessage.Text = "<font color='green'>Purchase information posted successfully</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Purchase information posted successfully')", true);
                    gvPurchase.DataSource = null;
                    gvPurchase.DataBind();
                    ddlChalanNo.Items.Clear();
                }
                ClearForm();
                //}

                //else // hiddenCompanyType = General
                //{

                //    foreach (Inv_RChallan_Temp rchallan in staticPurchaseList)
                //    {
                //        Inv_Buy buy = buyBll.GetBuyByCompanyAndBarcode(rchallan.Barcode, Convert.ToInt32(rchallan.CompanyId));

                //        if (buy == null)
                //        { // Insert New

                //            Inv_Buy invBuy = new Inv_Buy();
                //            invBuy.ChallanNo = rchallan.ChallanNo;
                //            invBuy.CompanyId = rchallan.CompanyId;
                //            invBuy.CompanyCode = rchallan.CompanyCode;
                //            invBuy.CompanyName = rchallan.CompanyName;
                //            invBuy.BarCode = rchallan.Barcode;
                //            invBuy.ProductId = Convert.ToInt32(rchallan.ProductId);
                //            invBuy.ProductGroup = rchallan.ProductGroup;
                //            invBuy.ProductName = rchallan.ProductName;
                //            invBuy.Brand = rchallan.Brand;
                //            invBuy.StyleSize = rchallan.StyleSize;
                //            invBuy.FloorName = rchallan.FloorName;
                //            invBuy.UnitName = rchallan.UnitName;
                //            invBuy.ReceiveQuantity = rchallan.ReceiveQuantity;
                //            invBuy.CPU = rchallan.CPU;
                //            invBuy.RPU = rchallan.RPU;
                //            invBuy.ExpireDate = rchallan.ExpireDate;
                //            invBuy.BalanceQuanity = rchallan.BalanceQty;
                //            invBuy.PurchaseDate = rchallan.PurchaseDate;
                //            invBuy.DeliveryQty = Convert.ToInt32(rchallan.DeliveryQty);
                //            invBuy.EditDate = rchallan.EditDate;
                //            invBuy.OCode = rchallan.Ocode;
                //            buyBll.Insert(invBuy);

                //        }
                //        else
                //        {

                //            buy.BalanceQuanity = buy.BalanceQuanity + rchallan.ReceiveQuantity;
                //            buy.CPU = rchallan.CPU;
                //            buy.RPU = rchallan.RPU;
                //            buy.ExpireDate = rchallan.ExpireDate;
                //            buy.ReceiveQuantity = buy.ReceiveQuantity + rchallan.ReceiveQuantity;
                //            int Id = Convert.ToInt16(hidId.Value);
                //            buyBll.Update(buy, Id);
                //        }

                //        rChallanBll.Insert(ConvertTmpToRchallan(rchallan));
                //        rChallanBll.DeleteTempChalanById(rchallan.Id);
                //        lblMessage.Text = "<font color='green'>Purchase information posted successfully</font>";
                //        ddlChalanNo.Items.Clear();

                //    }
                //    ClearForm();
                //}// End of IF CENTRAL OR GENERAL
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtReceiveQty_TextChanged(object sender, EventArgs e)
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

        //protected void btnPrint_Click(object sender, EventArgs e)
        //{
        //    string challanNo = txtChallanNo.Text.Trim();
        //    string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
        //    DataTable dataSource = rChallanBll.GetVoucherReport(challanNo, Ocode);
        //    ReportViewerPurchase.LocalReport.DataSources.Clear();
        //    ReportDataSource reportDataset = new ReportDataSource("PurchaseVoucher_DS", dataSource);
        //    ReportViewerPurchase.LocalReport.DataSources.Add(reportDataset);
        //    ReportViewerPurchase.LocalReport.ReportPath = Server.MapPath("Reports/PurchaseVoucher_RPT.rdlc");
        //    ReportViewerPurchase.LocalReport.Refresh();
        //}
    }

}
