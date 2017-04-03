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
using ERPSSL.LC.DAL.Repository;
using ERPSSL.LC.BLL;
using ERPSSL.HRM.DAL;

namespace ERPSSL.INV
{
    public partial class RecieveGeneral_withoutBarcode : System.Web.UI.Page
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
        IChallanBLL iChallanBll = new IChallanBLL();
        OrderSheetBLL _orderSheetbll = new OrderSheetBLL();


        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        public static DataTable stCompany = new DataTable();
        public static int GroupId = 0;
        public static int SerialNo = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    txtDate.Text = DateTime.Today.ToShortDateString();
                    SetCompanyData();
                    FillSupplier();
                    GetAllGroup();
                    this.GetAllStore();
                    //FillSeason();
                    LoadOrderNumber();
                    FillOldChalan();
                    LoadOrderNumber();
                    lblTotal.Visible = false;
                    LoadCompanyTypeByID();

                    txtReceiveQty.Text = "0";
                    txtOrCPU.Text = "0";
                    txtCCRate.Text = "0";
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void LoadCompanyTypeByID()
        {
            try
            {
                List<Inv_Company> company = companyBll.GetcompanyTypeByCode().ToList();
                //txtCompanyName.Text = company.CompanyName;
                txtChallanNo.Text = string.Empty;
                ddlSupplier.Items.Clear();
                this.FillSupplier();
                if (company.Count > 0)
                {
                    hiddenCompanyType.Value = company.Select(x => x.CompanyType).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private void LoadOrderNumber()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                //int sesson = Convert.ToInt32(ddlSeason.SelectedValue);

                var row = _orderSheetbll.GetOrderBySeasonId(ocode);
                if (row != null)
                {
                    ddlOrder.DataSource = row.ToList();
                    ddlOrder.DataTextField = "OrderNo";
                    ddlOrder.DataValueField = "OrderEntryID";
                    ddlOrder.DataBind();
                    ddlOrder.AppendDataBoundItems = false;
                    ddlOrder.Items.Insert(0, new ListItem("--Select Order No.--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
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
                    ddlStore.DataValueField = "Store_Code";
                    ddlStore.DataBind();
                    ddlStore.AppendDataBoundItems = false;
                    ddlStore.Items.Insert(0, new ListItem("--Select Store & Company--", "0"));
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
                ddlChalanNo.Items.Insert(0, new ListItem("--Select Unspotted MRR--", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
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
                    ddlProductGroup.Items.Insert(0, new ListItem("--Select Item Group--", "0"));
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
                var row = supplierBll.GetSupplierEnlistedTrue(OCODE);
                if (row.Count > 0)
                {
                    ddlSupplier.DataSource = row.ToList();
                    ddlSupplier.DataValueField = "SupplierCode";
                    ddlSupplier.DataTextField = "SupplierName";
                    ddlSupplier.DataBind();
                    ddlSupplier.Items.Insert(0, new ListItem("---Select One---", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //private void FillSeason()
        //{
        //    try
        //    {
        //        string OCode = ((SessionUser)Session["SessionUser"]).OCode;
        //        var row = _orderSheetbll.GetSeasonId(OCode);
        //        if (row.Count > 0)
        //        {
        //            ddlSeason.DataSource = row.ToList();
        //            ddlSeason.DataTextField = "Season_Name";
        //            ddlSeason.DataValueField = "Season_Id";
        //            ddlSeason.DataBind();
        //            ddlSeason.AppendDataBoundItems = false;
        //            ddlSeason.Items.Insert(0, new ListItem("--Select Season--", "0"));
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCompanyTypeByID();
            //LoadStoreCode();
            //if (ddlStore.SelectedValue != null)
            //{
            //    List<Inv_Company> company = companyBll.GetcompanyByCode(ddlStore.SelectedValue).ToList();
            //    //txtCompanyName.Text = company.CompanyName;
            //    txtChallanNo.Text = string.Empty;
            //    ddlSupplier.Items.Clear();
            //    this.FillSupplier();
            //    if (company.Count > 0)
            //    {
            //        hiddenCompanyType.Value = company.Select(x => x.CompanyType).FirstOrDefault();
            //    }
            //}
        }

        //private void LoadStoreCode()
        //{
        //    try
        //    {
        //        int SId = Convert.ToInt32(ddlStore.SelectedValue.ToString());
        //        List<Inv_Store> Store = companyBll.GetStoreCodeByCode(SId).ToList();
        //        //txtCompanyName.Text = company.CompanyName;
        //        txtChallanNo.Text = string.Empty;
        //        ddlSupplier.Items.Clear();
        //        this.FillSupplier();
        //        if (Store.Count > 0)
        //        {
        //            hidStoreCode.Value = Store.Select(x => x.Store_Code).FirstOrDefault();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        public void FillProductName()
        {
            try
            {
                int gId = Convert.ToInt32(ddlProductGroup.SelectedValue);

                var _pName = productBll.GetProductNameByGroupId(gId);
                if (_pName.Count > 0)
                {

                    ddlProductName.DataSource = _pName;
                    ddlProductName.DataValueField = "ProductId";
                    ddlProductName.DataTextField = "ProdName";
                    ddlProductName.DataBind();
                    ddlProductName.Items.Insert(0, new ListItem("---Select Item---", "0"));
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
            try
            {
                FillProductName();
                lblMessage.Text = "";
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
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
                        string Ocode = ((SessionUser)Session["SessionUser"]).OCode;

                        GetBalanceQuanity();
                        //DataTable dt = iChallanBll.GetProductByBarCodeFromStore(ddlProductName.SelectedValue, Ocode, ddlStore.SelectedValue);
                        //if (dt.Rows.Count > 0)
                        //{
                        //    foreach (DataRow dr in dt.Rows)
                        //    {
                        //        txtBalanceQty.Text = dr["BalanceQuanity"].ToString();
                        //    }
                        //}
                        //else
                        //{
                        //    txtBalanceQty.Text = "0";
                        //}

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

        private void GetBalanceQuanity()
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                int PId = Convert.ToInt32(ddlProductName.SelectedValue);

                List<Inv_BuyCentral> _BalanceQty = iChallanBll.Get_ItemBalance_ById_Store(OCode, PId, ddlStore.SelectedValue).ToList();

                if (_BalanceQty.Count > 0)
                {
                    var BlQty = _BalanceQty.First();
                    txtBalanceQty.Text = BlQty.BalanceQuanity.ToString();
                }
                else
                {
                    txtBalanceQty.Text = "0";
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtRecQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //if (txtReceiveQty.Text != string.Empty && txtCPU.Text != string.Empty)
                //{
                //    double qty = Convert.ToDouble(txtReceiveQty.Text.Trim());
                //    decimal cpu = Convert.ToDecimal(txtCPU.Text.Trim());
                //    decimal total = (decimal)qty * cpu;
                //    txtTotalCost.Text = Convert.ToString(total);
                //}
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]

        public static List<string> SearchCurrentEmployee(string prefixText, int count)
        {

            using (var _context = new ERPSSLHBEntities())
            {
                var employees = from emp in _context.HRM_PersonalInformations
                                where ((emp.EMP_TERMIN_STATUS == false && emp.EMP_Retired_Status == false && emp.EMP_Resignation_Status == false && emp.EMP_Dismissal_Status == false && emp.EMP_Died_Status == false && emp.EMP_Dis_Continution_Status == false && emp.EMP_Other == false) && (emp.FirstName.Contains(prefixText) || emp.LastName.Contains(prefixText) || emp.EID.Contains(prefixText) || emp.Gender.Contains(prefixText) || emp.ContactNumber.Contains(prefixText) || emp.Email.Contains(prefixText)))
                                select emp;
                List<String> employeeList = new List<String>();

                foreach (var employee in employees)
                {
                    employeeList.Add(employee.EID + "-" + employee.FirstName + "-" + employee.LastName);
                }
                return employeeList;
            }
        }

        //protected void txtCPU_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        //if (txtReceiveQty.Text != string.Empty && txtCPU.Text != string.Empty)
        //        //{
        //        //    double qty = Convert.ToDouble(txtReceiveQty.Text.Trim());
        //        //    decimal cpu = Convert.ToDecimal(txtCPU.Text.Trim());
        //        //    decimal total = (decimal)qty * cpu;
        //        //    txtTotalCost.Text = Convert.ToString(total);
        //        //}
        //        //txtTotalCost.Text = (int.Parse(txtCPU.Text) * int.Parse(txtReceiveQty.Text)).ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        private string GetCompanyIdByCode(string code)
        {
            return companyBll.GetCompanyIdByCode(code);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                ////|| txtCPU.Text == string.Empty
                //if (txtReceiveQty.Text == string.Empty)
                //{
                //    return;
                //}
                //SerialNo = SerialNo + 1;
                Inv_RChallan_Temp purchase = new Inv_RChallan_Temp();
                //purchase.Id = SerialNo;

                foreach (DataRow dr in stCompany.Rows)
                {
                    purchase.CompanyId = int.Parse(dr["CompanyId"].ToString());
                    purchase.CompanyName = dr["CompanyName"].ToString();
                    purchase.CompanyCode = dr["CompanyCode"].ToString();
                }
                //purchase.CompanyName = GetCompanyNameByCode(purchase.CompanyCode);
                //purchase.CompanyId = int.Parse(GetCompanyIdByCode(purchase.CompanyCode));
                //purchase.Store_Id = Convert.ToInt32(ddlStore.SelectedValue.ToString());
                purchase.Store_Code = ddlStore.SelectedValue;
                purchase.SupplierCode = ddlSupplier.SelectedValue.ToString();
                purchase.RefNo_ChallanNo = txtRefNo.Text;
                //purchase.SeasonID = Convert.ToInt32(ddlSeason.SelectedValue.ToString());
                purchase.OrderEId = Convert.ToInt32(ddlOrder.SelectedValue.ToString());

                purchase.PurchaseDate = DateTime.Parse(txtDate.Text);


                purchase.ChallanNo = txtChallanNo.Text.Trim();
                purchase.MasterLCNo = txtMasterLCNo.Text;
                purchase.PI_No = txtPINo.Text;
                purchase.B2BLCNo = txtB2BLCNo.Text;

                purchase.ProductGroup = Convert.ToInt32(ddlProductGroup.SelectedValue.ToString());
                purchase.ProductId = int.Parse(ddlProductName.SelectedValue.ToString());//Convert.ToInt32(txtProductId.Text.Trim());
                //purchase.ProductGroup = int.Parse(ddlProductGroup.SelectedValue.ToString());

                //purchase.Barcode = buyCentralBll.GetBarcode(int.Parse(purchase.ProductId.ToString()));
                purchase.BarCode = Convert.ToInt16(purchase.ProductId).ToString();

                string pronductNameandBrand = ddlProductName.SelectedItem.ToString();
                string[] values = pronductNameandBrand.Split('+');
                purchase.ProductName = values[0].ToString();

                if (txtReceiveQty.Text == "")
                {
                    purchase.ReceiveQuantity = 0;
                }
                else
                {
                    purchase.ReceiveQuantity = Convert.ToDouble(txtReceiveQty.Text.Trim());
                }
                purchase.ActualQty = Convert.ToDouble(txtActualQty.Text.Trim());
                purchase.Free_Qty = Convert.ToDouble(txtFreeQty.Text.Trim());
                purchase.Actual_Amount = Convert.ToDecimal(HidActualAmount.Value);
                purchase.FreeQty_Amount = Convert.ToDecimal(HidFreeAmount.Value);
                purchase.UnitName = txtUnit.Text;
                purchase.Brand = hdnBrand.Value;

                purchase.FrmCurrency = ddlCurrency.SelectedValue;

                if (txtOrCPU.Text == "")
                {
                    purchase.CPU = 0;
                }
                else
                {
                    purchase.CPU = Convert.ToDecimal(txtOrCPU.Text);
                }
                purchase.TotalPrice = Convert.ToDecimal(txtorTotal.Text);
                purchase.ToCurrency = ddlConvertCurrency.SelectedValue;
                if (txtCCRate.Text == "")
                {
                    purchase.Rate = 0;
                }
                else
                {
                    purchase.Rate = Convert.ToDecimal(txtCCRate.Text);
                }
                purchase.TotalAppCost = Convert.ToDecimal(txtCCTotal.Text);

                purchase.ReceiverEID = hIdEid.Value;
                purchase.StyleSize = hdnStyle.Value;
                //purchase.FloorName = txtFloorName.Text;
                //purchase.StyleSize = txtStyleSize.Text;
                purchase.DamageQty = 0;
                purchase.DeliveryQty = 0;
                purchase.SupplierReturnQty = 0;
                //purchase.OrderNo = txtOrderNo.Text; // here use as remarks

                try
                {
                    purchase.PurchaseDate = DateTime.Parse(txtDate.Text);
                }
                catch
                {
                    purchase.PurchaseDate = DateTime.Today;
                }

                //if (chkBalanceStatus.Checked)
                //    purchase.BalanceStatus = "OpeningBalance";
                //else
                //    purchase.BalanceStatus = "MRR";
                //decimal CPU = Convert.ToDecimal(txtCPU.Text.Trim());
                //purchase.CPU = CPU;
                //if (txtRPU.Text == string.Empty)
                //{
                //    purchase.RPU = Convert.ToInt32(float.Parse(txtCPU.Text));
                //}
                //else
                //{
                //    purchase.RPU = Convert.ToInt32(float.Parse(txtRPU.Text));
                //}
                //purchase.BalanceQuanity = Convert.ToDouble(txtBalanceQty.Text);

                purchase.BalanceQuanity = Convert.ToDouble(txtBalanceQty.Text.Trim()) + purchase.ReceiveQuantity;

                //purchase.ChallanTotal = Convert.ToDecimal(txtTotalCost.Text);

                //purchase.SupplierCode = ddlSupplier.SelectedValue.ToString(); // identity of the supplier

                string OCode = ((SessionUser)Session["SessionUser"]).OCode;

                purchase.EditDate = DateTime.Now;
                purchase.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                purchase.OCode = OCode;
                //purchase.EditUser = Guid.Parse("a376708d-757f-4777-bd05-bfc89b6971ce");
                //purchase.Ocode = "8989";
                if (btnSubmit.Text == "Add")
                {
                    var RChalan = rChallanBll.GetDataByInv_RChallan_Temp(txtChallanNo.Text, ddlProductName.SelectedValue.ToString(), OCode).ToList();
                    if (RChalan.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Item Already Exist In The List')", true);
                        return;
                    }

                    rChallanBll.Insert(purchase);
                    BindPurchaseGrid(purchase.ChallanNo);
                    ClearProduct();
                    lblTotal.Visible = true;
                    //lblMessage.Text = "<font color='green'>Purchase information has been added temporarily. Please post.</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Purchase information has been added temporarily. Please post.')", true);
                }

                else
                {
                    //if (btnSubmit.Text == "Update")
                    //{
                    //double ReceiveQty = Convert.ToDouble(txtReceiveQty.Text);
                    //DateTime PDate = Convert.ToDateTime(txtDate.Text);
                    //double ActualQty = Convert.ToInt32(txtActualQty.Text);
                    //double freeQty = Convert.ToInt32(txtFreeQty.Text);
                    //decimal CPU = Convert.ToDecimal(txtCPU.Text.Trim());
                    //decimal total = Convert.ToDecimal(txtTotalCost.Text.Trim());
                    int id = Convert.ToInt32(hidId.Value);
                    var update = rChallanBll.UpdateInv_MRRRChallan_Temp(txtChallanNo.Text,id, purchase);

                    if (update == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                        BindPurchaseGrid(txtChallanNo.Text.Trim());
                        ClearProduct();
                        btnSubmit.Text = "Add";
                        lblTotal.Visible = true;
                        return;
                    }
                    else
                    {

                    }
                    //}
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
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                List<Inv_RChallan_Temp> groups = rChallanBll.GetPurchaseGrid(challanNo, OCode);
                if (groups.Count > 0)
                {
                    gvPurchase.DataSource = groups;
                    gvPurchase.DataBind();
                    lblTotal.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

            //gvPurchase.DataSource = rChallanBll.GetRChalanTemp(((SessionUser)Session["SessionUser"]).OCode, challanNo);
            ////gvPurchase.DataSource = rChallanBll.GetRChalanTemp(("8989"), challanNo);
            //gvPurchase.DataBind();
        }

        protected void ClearProduct()
        {
            txtBalanceQty.Text = string.Empty;
            txtOrCPU.Text = "";
            hdnBrand.Value = "";
            hdnStyle.Value = "";
            ddlCurrency.ClearSelection();
            ddlConvertCurrency.ClearSelection();
            txtOrCPU.Text = "";
            txtorTotal.Text = "";
            txtCCRate.Text = "";
            txtCCTotal.Text = "";
            txtActualQty.Text = "";
            txtFreeQty.Text = "";
            //txtStyleSize.Text = string.Empty;
            txtReOrderQty.Text = "";

            //txtFloorName.Text = string.Empty;
            //txtTotalCost.Text = string.Empty;
            txtReceiveQty.Text = "";
            txtUnit.Text = "";
            //txtbarcode.Text = string.Empty;
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
                    if (gvPurchase.Rows.Count > 0)
                    {
                        lblTotalCost.Text = "";
                    }

                    rChallanBll.DeleteTempChalanById(id);
                    BindPurchaseGrid(txtChallanNo.Text.Trim());
                }
                if (e.CommandName == "edt")
                {
                    foreach (Inv_RChallan_Temp temp in _context.Inv_RChallan_Temp.Where(x => x.Id == id).ToList())
                    {
                        ddlStore.SelectedValue = temp.Store_Code;
                        //hidStoreCode.Value = temp.Store_Code;
                        hidId.Value = temp.Id.ToString();

                        ddlSupplier.SelectedValue = temp.SupplierCode;
                        txtRefNo.Text = temp.RefNo_ChallanNo;
                        //ddlSeason.SelectedValue = temp.SeasonID.ToString();
                        LoadOrderNumber();
                        ddlOrder.SelectedValue = temp.OrderEId.ToString();
                        txtMasterLCNo.Text = temp.MasterLCNo;
                        txtPINo.Text = temp.PI_No;
                        txtB2BLCNo.Text = temp.B2BLCNo;
                        ddlProductGroup.SelectedValue = temp.ProductGroup.ToString();
                        FillProductName();
                        ddlProductName.SelectedValue = temp.BarCode.ToString();
                        txtReceiveQty.Text = temp.ReceiveQuantity.ToString();
                        txtActualQty.Text = temp.ActualQty.ToString();
                        txtFreeQty.Text = temp.Free_Qty.ToString();
                        HidActualAmount.Value = temp.Actual_Amount.ToString();
                        HidFreeAmount.Value = temp.FreeQty_Amount.ToString();
                        txtBalanceQty.Text = temp.BalanceQuanity.ToString();
                        txtDate.Text = temp.PurchaseDate.ToString();
                        txtOrCPU.Text = temp.CPU.ToString();
                        txtorTotal.Text = temp.TotalPrice.ToString();
                        txtCCRate.Text = temp.Rate.ToString();
                        txtCCTotal.Text = temp.TotalAppCost.ToString();

                        txtUnit.Text = temp.UnitName.ToString();
                        //txtTotalCost.Text = temp.ChallanTotal.ToString();
                        btnSubmit.Text = "Update";
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        decimal sumFooterValue = 0;
        decimal sumUSDTotal = 0;
        decimal sumActualValue = 0;
        decimal sumFreeValue = 0;
        protected void gvPurchase_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string totalAmount = e.Row.Cells[14].Text;
                    decimal grandTotal = Convert.ToDecimal(totalAmount);
                    sumFooterValue += grandTotal;
                }
                lblTotalCost.Text = sumFooterValue.ToString("#,0.00");

                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string totalAmount = e.Row.Cells[10].Text;
                    decimal grandTotal = Convert.ToDecimal(totalAmount);
                    sumUSDTotal += grandTotal;
                }
                lblTotalUSD.Text = sumUSDTotal.ToString();
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string ActualAmount = e.Row.Cells[11].Text;
                    decimal Actual = Convert.ToDecimal(ActualAmount);
                    sumActualValue += Actual;
                }
                lblActual.Text = sumActualValue.ToString();
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string FreeAmount = e.Row.Cells[12].Text;
                    decimal Free = Convert.ToDecimal(FreeAmount);
                    sumFreeValue += Free;
                }
                lblFree.Text = sumFreeValue.ToString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void FillFormForOldChallan()
        {
            try
            {
                string challanNo = ddlChalanNo.SelectedItem.Text;
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                List<Inv_RChallan_Temp> groups = rChallanBll.GetPurchaseGridLoad(challanNo, OCode);

                DataTable dt = new DataTable();
                dt = rChallanBll.OldChallan(challanNo, OCode);
                foreach (DataRow dr in dt.Rows)
                {
                    txtChallanNo.Text = dr["ChallanNo"].ToString();
                    GetAllStore();
                    ddlStore.SelectedValue = dr["Store_Code"].ToString();
                    //hidStoreCode.Value = dr["Store_Code"].ToString();
                    FillSupplier();
                    ddlSupplier.SelectedValue = dr["SupplierCode"].ToString();
                    txtRefNo.Text = dr["RefNo_ChallanNo"].ToString();
                    //FillSeason();
                    //ddlSeason.SelectedValue = dr["SeasonID"].ToString();
                    //LoadOrderNumber();
                    //ddlOrder.SelectedValue = dr["OrderEId"].ToString();

                    txtDate.Text = DateTime.Parse(dr["PurchaseDate"].ToString()).ToShortDateString();

                    //hiddenCompanyType.Value = dr["CompanyType"].ToString();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

            //DataTable dt = new DataTable();
            //string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
            ////string Ocode = "8989";
            //dt = rChallanBll.OldChallan(challanNo, Ocode);
            //foreach (DataRow dr in dt.Rows)
            //{
            //    //txtChallanNo.Text = dr["ChallanNo"].ToString();
            //    //ddlSupplier.SelectedValue = dr["SupplierCode"].ToString();
            //    //txtDate.Text = DateTime.Parse(dr["ChallanDate"].ToString()).ToShortDateString();
            //    //GetAllStore();
            //    //ddlStore.SelectedValue = dr["CompanyCode"].ToString();
            //    //ddlCompanyCode.SelectedValue = dr["CompanyId"].ToString();
            //    //txtCompanyName.Text = dr["CompanyName"].ToString();
            //    hiddenCompanyType.Value = dr["CompanyType"].ToString();
            //}
            //ddlProductGroup.SelectedValue = "0";
            //ddlProductName.SelectedValue = "0";
            //txtUnit.Text = string.Empty;
            ////txtTotalCost.Text = string.Empty;
            ////txtBrand.Text = string.Empty;
            //hdnBrand.Value = "";
            //hdnStyle.Value = "";
            ////txtStyleSize.Text = string.Empty;
            //txtReOrderQty.Text = string.Empty;
            ////txtFloorName.Text = string.Empty;
            //txtReceiveQty.Text = string.Empty;
            //txtBalanceQty.Text = string.Empty;
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
            c.ActualQty = t.ActualQty;
            c.Free_Qty = t.Free_Qty;
            c.Actual_Amount = t.Actual_Amount;
            c.FreeQty_Amount = t.FreeQty_Amount;
            c.RPU = t.RPU;
            c.ExpireDate = t.ExpireDate;
            c.StyleSize = t.StyleSize;
            c.FloorName = t.FloorName;
            c.SupplierCode = t.SupplierCode;
            c.SupplierReturnQty = t.SupplierReturnQty;
            c.Store_Id = t.Store_Id;
            c.Store_Code = t.Store_Code;




            c.B2BLCNo = t.B2BLCNo;
            c.FrmCurrency = t.FrmCurrency;
            c.ToCurrency = t.ToCurrency;
            c.Rate = t.Rate;
            c.OrderNo = t.OrderNo;
            c.SeasonID = t.SeasonID;
            c.OrderEId = t.OrderEId;
            c.MasterLCNo = t.MasterLCNo;
            c.PI_No = t.PI_No;
            c.TotalPrice = t.TotalPrice;
            c.ReceiverEID = t.ReceiverEID;



            c.UnitName = t.UnitName;
            c.OrderNo = t.OrderNo;

            // if needed
            //c.VailPerPack = t.VailPerPack;
            //c.TestPerVail = t.TestPerVail;
            //c.TotalVailQty = t.TotalVailQty;
            //c.BalanceStatus = t.BalanceStatus;
            return c;
        }

        protected void ClearForm()
        {
            BindPurchaseGrid(txtChallanNo.Text.Trim());
            //ddlStore.ClearSelection();

            //ddlCompanyCode.SelectedValue = "0";
            //txtCompanyName.Text = string.Empty;
            ddlSupplier.ClearSelection();

            //txtSupplierId.Text = string.Empty;
            txtChallanNo.Text = "";
            //txtDate.Text = "";
            //txtRefNo.Text = ;
            ClearProduct();
            SerialNo = 0;
            lblTotalCost.Text = "";
            lblTotalUSD.Text = "";
            lblActual.Text = "";
            lblFree.Text = "";
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
                txtChallanNo.Text = string.Empty;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtReceiverEID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string eidS = txtReceiverEID.Text;
                var search = supplierBll.getEmpNamebyEID(eidS);
                if (search.Count > 0)
                {
                    var objNewEmp = search.First();
                    txtReceiverName.Text = Convert.ToString(objNewEmp.FirstName + " " + objNewEmp.LastName);
                    hIdEid.Value = objNewEmp.EID.ToString();
                }
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
                BindPurchaseGrid(challanNo);
                FillFormForOldChallan();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtOrCPU_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double ReceivedQty = Convert.ToDouble(txtReceiveQty.Text);
                double ReceivedPrice = Convert.ToDouble(txtOrCPU.Text);
                double OrTotal = ReceivedQty * ReceivedPrice;
                txtorTotal.Text = OrTotal.ToString();

                double orTotal = Convert.ToDouble(txtorTotal.Text);
                if (txtCCRate.Text != "")
                {
                    double ccrate = Convert.ToDouble(txtCCRate.Text);
                    double appcost = orTotal * ccrate;
                    txtCCTotal.Text = appcost.ToString();
                }
                else
                {
                    double ccrate = 0;
                    double appcost = orTotal * ccrate;
                    txtCCTotal.Text = appcost.ToString();
                }

                double freeQty = Convert.ToDouble(txtFreeQty.Text);
                double ActualQty = Convert.ToDouble(txtActualQty.Text);
                HidActualAmount.Value = (ActualQty * ReceivedPrice).ToString();
                HidFreeAmount.Value = (freeQty * ReceivedPrice).ToString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                List<Inv_RChallan_Temp> staticPurchaseList = new List<Inv_RChallan_Temp>();

                string challanNo = txtChallanNo.Text.Trim();
                //string challanNo1 = ddlChalanNo.SelectedItem.Text;
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                staticPurchaseList = rChallanBll.GetTempRChalan(((SessionUser)Session["SessionUser"]).OCode, challanNo);
                //staticPurchaseList = rChallanBll.GetTempRChalan("8989", challanNo);

                if (hiddenCompanyType.Value.Trim() == "CENTRAL")
                {
                    foreach (Inv_RChallan_Temp rchallan in staticPurchaseList)
                    {
                        ERPSSL.INV.DAL.Inv_BuyCentral buyCentral = buyCentralBll.GetBuyCentralByBarcodeAndStoreCode(rchallan.BarCode, rchallan.Store_Code);


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
                            newBuyCentral.RefNo_ChallanNo = rchallan.RefNo_ChallanNo;
                            newBuyCentral.SupplierCode = rchallan.SupplierCode;

                            newBuyCentral.Brand = rchallan.Brand;
                            newBuyCentral.StyleSize = rchallan.StyleSize;
                            newBuyCentral.FloorName = rchallan.FloorName;
                            newBuyCentral.UnitName = rchallan.UnitName;
                            newBuyCentral.ReceiveQuantity = rchallan.ReceiveQuantity;
                            newBuyCentral.ActualQty = rchallan.ActualQty;
                            newBuyCentral.Free_Qty = rchallan.Free_Qty;
                            newBuyCentral.CPU = rchallan.CPU;
                            newBuyCentral.RPU = rchallan.RPU;
                            newBuyCentral.ExpireDate = rchallan.ExpireDate;
                            newBuyCentral.BalanceQuanity = rchallan.ReceiveQuantity;
                            newBuyCentral.PurchaseDate = rchallan.PurchaseDate;
                            newBuyCentral.B2BLCNo = rchallan.B2BLCNo;
                            newBuyCentral.FrmCurrency = rchallan.FrmCurrency;
                            newBuyCentral.ToCurrency = rchallan.ToCurrency;
                            newBuyCentral.Rate = rchallan.Rate;
                            newBuyCentral.OrderNo = rchallan.OrderNo;
                            newBuyCentral.SeasonID = rchallan.SeasonID;
                            newBuyCentral.OrderEId = rchallan.OrderEId;
                            newBuyCentral.MasterLCNo = rchallan.MasterLCNo;
                            newBuyCentral.PI_No = rchallan.PI_No;
                            newBuyCentral.ReceiverEID = rchallan.ReceiverEID;
                            newBuyCentral.TotalPrice = rchallan.TotalPrice;
                            newBuyCentral.TotalAppCost = rchallan.TotalAppCost;
                            newBuyCentral.Store_Id = rchallan.Store_Id;
                            newBuyCentral.Store_Code = rchallan.Store_Code;

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
                            buyCentral.ActualQty = rchallan.ActualQty;
                            buyCentral.Free_Qty = rchallan.Free_Qty;
                            //buyCentral.Id = Convert.ToInt16(hidId.Value);
                            buyCentralBll.Update(buyCentral, buyCentral.Id);
                        }

                        rChallanBll.Insert(ConvertTmpToRchallan(rchallan));
                        rChallanBll.DeleteTempChalanById(rchallan.Id);

                        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                        string Edit_User = ((SessionUser)Session["SessionUser"]).UserId.ToString();
                        string Company_Code = "CMP201507251";
                        string ModuleName = "Inventory";
                        string ModuleType = "MRR";
                        string VoucherType = "JOURNAL";

                        rChallanBll.Enter_VoucherDetails(OCODE, Company_Code, Edit_User, ModuleName, ModuleType, VoucherType, rchallan.ChallanNo, ConvertTmpToRchallan(rchallan));

                        //lblMessage.Text = "<font color='green'>Purchase information posted successfully</font>";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Purchase information posted successfully')", true);
                        gvPurchase.DataSource = null;
                        gvPurchase.DataBind();
                        ddlChalanNo.Items.Clear();
                        lblTotal.Visible = false;
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
                            invBuy.DeliveryQty = Convert.ToDouble(rchallan.DeliveryQty);
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
                            //int Id = Convert.ToInt16(hidId.Value);
                            buyBll.Update(buy, buy.Id);
                        }

                        rChallanBll.Insert(ConvertTmpToRchallan(rchallan));
                        rChallanBll.DeleteTempChalanById(rchallan.Id);
                        //  lblMessage.Text = "<font color='green'>Purchase information posted successfully</font>";

                        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                        string Edit_User = ((SessionUser)Session["SessionUser"]).UserId.ToString();
                        string Company_Code = "CMP201507251";
                        string ModuleName = "Inventory";
                        string ModuleType = "MRR";
                        string VoucherType = "JOURNAL";

                        rChallanBll.Enter_VoucherDetails(OCODE, Company_Code, Edit_User, ModuleName, ModuleType, VoucherType, rchallan.ChallanNo, ConvertTmpToRchallan(rchallan));

                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Purchase information posted successfully')", true);
                        ddlChalanNo.Items.Clear();
                        lblTotal.Visible = false;
                    }
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void txtCCRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double orTotal = Convert.ToDouble(txtorTotal.Text);
                double ccrate = Convert.ToDouble(txtCCRate.Text);
                double appcost = orTotal * ccrate;
                txtCCTotal.Text = appcost.ToString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        //protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    LoadOrderNumber();
        //}

        protected void txtReceiveQty_TextChanged(object sender, EventArgs e)
        {
            try
            {

                if (txtOrCPU.Text != "")
                {
                    double ReceivedQty = Convert.ToDouble(txtReceiveQty.Text);
                    double ReceivedPrice = Convert.ToDouble(txtOrCPU.Text);

                    double OrTotal = ReceivedQty * ReceivedPrice;
                    txtorTotal.Text = OrTotal.ToString();

                    double orTotal = Convert.ToDouble(txtorTotal.Text);
                    if (txtCCRate.Text != "")
                    {
                        double ccrate = Convert.ToDouble(txtCCRate.Text);
                        double appcost = orTotal * ccrate;
                        txtCCTotal.Text = appcost.ToString();
                    }
                    else
                    {
                        double ccrate = 0;
                        double appcost = orTotal * ccrate;
                        txtCCTotal.Text = appcost.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtorTotal_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double orTotal = Convert.ToDouble(txtorTotal.Text);
                double ccrate = Convert.ToDouble(txtCCRate.Text);
                double appcost = orTotal * ccrate;
                txtCCTotal.Text = appcost.ToString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtActualQty_TextChanged(object sender, EventArgs e)
        {
            double ReciveQty = Convert.ToDouble(txtReceiveQty.Text);
            double ActualQty = Convert.ToDouble(txtActualQty.Text);

            if (ActualQty <= ReciveQty)
            {
                if (txtOrCPU.Text != "")
                {
                    double ReceivedPrice = Convert.ToDouble(txtOrCPU.Text);
                    txtFreeQty.Text = (ReciveQty - ActualQty).ToString();
                    double freeQty = Convert.ToDouble(txtFreeQty.Text);
                    //double ActualQty = Convert.ToDouble(txtActualQty.Text);
                    HidActualAmount.Value = (ActualQty * ReceivedPrice).ToString();
                    HidFreeAmount.Value = (freeQty * ReceivedPrice).ToString();
                }
                else
                {
                    double ReceivedPrice = 0;
                    txtFreeQty.Text = (ReciveQty - ActualQty).ToString();
                    double freeQty = Convert.ToDouble(txtFreeQty.Text);
                    //double ActualQty = Convert.ToDouble(txtActualQty.Text);
                    HidActualAmount.Value = (ActualQty * ReceivedPrice).ToString();
                    HidFreeAmount.Value = (freeQty * ReceivedPrice).ToString();
                }


            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Input Actual Qty Less or Equal Recive Qty!!')", true);
            }
        }

        //protected void txtbarcode_TextChanged(object sender, EventArgs e)
        //{
        //    if (hiddenCompanyType.Value.Trim() == "CENTRAL")
        //    {
        //        Inv_BuyCentral buyCentral = buyCentralBll.GetBuyCentralByCompanyAndBarcode(txtbarcode.Text, Convert.ToInt32(ddlStore.SelectedValue));
        //        if (buyCentral != null)
        //        {
        //            txtBalanceQty.Text = Convert.ToString(buyCentral.BalanceQuanity);
        //        }
        //        else
        //        {
        //            txtBalanceQty.Text = "0";
        //        }
        //    }
        //    else
        //    {
        //        Inv_Buy invBuy = buyBll.GetBuyByCompanyAndBarcode(txtbarcode.Text, Convert.ToInt32(ddlStore.SelectedValue));
        //        if (invBuy != null)
        //        {
        //            txtBalanceQty.Text = Convert.ToString(invBuy.BalanceQuanity);
        //        }
        //        else
        //        {
        //            txtBalanceQty.Text = "0";
        //        }
        //    }

        //}
    }
}
