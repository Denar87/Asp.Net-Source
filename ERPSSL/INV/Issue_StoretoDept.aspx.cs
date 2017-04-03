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
using ERPSSL.HRM.DAL;
using ERPSSL.LC.BLL;
using Microsoft.Reporting.WebForms;
using ERPSSL.INV.DAL.Repository;

namespace ERPSSL.INV
{
    public partial class Issue_StoretoDept : System.Web.UI.Page
    {

        ProductBLL productBll = new ProductBLL();
        public static DataTable stCompany = new DataTable();
        IChallanBLL iChallanBll = new IChallanBLL();
        public static int SerialNo = 0;
        BuyCentralBLL buyCentralBll = new BuyCentralBLL();
        OrderSheetBLL _orderSheetbll = new OrderSheetBLL();
        public static string CentralCode = "";
        SupplierBLL supplierBll = new SupplierBLL();
        CompanyBLL companyBll = new CompanyBLL();
        BuyBLL buyBll = new BuyBLL();
        ReportsBll rpt = new ReportsBll();

        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        public static int GroupId = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!Page.IsPostBack)
                {
                    FillProductGroup();
                    //FillDepartment();
                    txtDate.Text = DateTime.Today.ToShortDateString();
                    stCompany = companyBll.GetCentralCompany();
                    //GenarateGinNumber();
                    FillSeason();
                    BindPurchaseGrid();
                    foreach (DataRow dr in stCompany.Rows)
                    {
                        CentralCode = dr["CompanyCode"].ToString();
                    }
                    this.GetAllStore();
                    FillOldChalan();
                    LoadSubCompanyList();
                    //FillFormForOldChallan;
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void LoadSubCompanyList()
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = companyBll.GetSubCompanyList(OCode);
                if (row.Count > 0)
                {
                    ddlSubCompany.DataSource = row.ToList();
                    ddlSubCompany.DataTextField = "SubCompanyName";
                    ddlSubCompany.DataValueField = "SubCompany_Id";
                    ddlSubCompany.DataBind();
                    ddlSubCompany.AppendDataBoundItems = false;
                    ddlSubCompany.Items.Insert(0, new ListItem("--Select Sub company--", "0"));
                }
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

        private void FillSeason()
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = _orderSheetbll.GetSeasonById(OCode);
                if (row.Count > 0)
                {
                    ddlSeason.DataSource = row.ToList();
                    ddlSeason.DataTextField = "Season";
                    ddlSeason.DataValueField = "OrderEntryID";
                    ddlSeason.DataBind();
                    ddlSeason.AppendDataBoundItems = false;
                    ddlSeason.Items.Insert(0, new ListItem("--Select Season--", "0"));
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
                string sesson = ddlSeason.SelectedItem.Text;

                var row = _orderSheetbll.GetOrderById(ocode, sesson);
                if (row != null)
                {
                    ddlOrder.DataSource = row.ToList();
                    //ddlOrder.DataTextField = "OrderNo";
                    //ddlOrder.DataValueField = "OrderNo";
                    ddlOrder.DataBind();
                    ddlOrder.AppendDataBoundItems = false;
                    ddlOrder.Items.Insert(0, new ListItem("--Select Order No.--", "0"));
                }
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

        protected void GetAllStore()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
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

        //private void GetAllStore()
        //{
        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        //string OCODE = "8989";
        //        var row = companyBll.GetOtherStore(OCODE);
        //        if (row.Count > 0)
        //        {
        //            ddlStore.DataSource = row.ToList();
        //            ddlStore.DataTextField = "StoreName";
        //            ddlStore.DataValueField = "Store_Id";
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

        //public void FillDepartment()
        //{

        //    ddlDepartment.DataSource = iChallanBll.GetDepartmentList();
        //    ddlDepartment.DataValueField = "DPT_CODE";
        //    ddlDepartment.DataTextField = "DPT_NAME";
        //    ddlDepartment.DataBind();
        //    ddlDepartment.Items.Insert(0, new ListItem("Select One", "0"));

        //}

        public void FillProductGroup()
        {
            ddlItemGroup.DataSource = iChallanBll.GetListGroup();
            ddlItemGroup.DataValueField = "GroupId";
            ddlItemGroup.DataTextField = "GroupName";
            ddlItemGroup.DataBind();
            ddlItemGroup.Items.Insert(0, new ListItem("Select Item Group", "0"));
        }

        public void FillProductName()
        {
            try
            {
                int gId = Convert.ToInt32(ddlItemGroup.SelectedValue);

                var _pName = productBll.GetProductNameByGroupId(gId);
                if (_pName.Count > 0)
                {
                    ddlItemName.DataSource = _pName;
                    ddlItemName.DataValueField = "ProductId";
                    ddlItemName.DataTextField = "ProdName";
                    ddlItemName.DataBind();
                    ddlItemName.Items.Insert(0, new ListItem("---Select Item---", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

        }

        //private void FillProductName()
        //{
        //    try
        //    {
        //        if (Convert.ToInt32(ddlItemGroup.SelectedValue) > 0)
        //        {
        //            ddlItemName.DataSource = iChallanBll.GetProductListWithCodeByGroup((ddlItemGroup.SelectedValue));
        //            ddlItemName.DataValueField = "BarCode";
        //            ddlItemName.DataTextField = "ProductName";
        //            ddlItemName.DataBind();
        //            ddlItemName.Items.Insert(0, new ListItem("Select Item", "0"));
        //        }
        //        else
        //        {
        //            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Item is available of this group!')", true);
        //            return;
        //        }
        //    }
        //    catch (Exception ex)
        //    {                
        //        throw ex;
        //    }
        //}

        protected void ddlItemGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            ddlItemName.Enabled = true;
            FillProductName();
        }

        //private void LoadEmployeeList(string DeptCode)
        //{
        //    ddlReciver.DataSource = iChallanBll.GetEmployeeList(DeptCode);
        //    ddlReciver.DataValueField = "EID";
        //    ddlReciver.DataTextField = "EMP_NAME";
        //    ddlReciver.DataBind();
        //    ddlReciver.Items.Insert(0, new ListItem("Select One", "0"));
        //}

        private void GenarateGinNumber()
        {
            try
            {
                string eidL = ((SessionUser)Session["SessionUser"]).EID;
                //LoadEmployeeList(eidL);
                txtChalanNo.Text = iChallanBll.GetNewChalanNoForGeneralStoreToDpt(eidL);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlItemName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToInt32(ddlItemName.SelectedValue) > 0)
                {
                    lblMessage.Text = "";
                    var result = productBll.GetProductById(Convert.ToInt32(ddlItemName.SelectedValue));
                    if (result.Count > 0)
                    {
                        var objProduct = result.First();
                        txtUnit.Text = objProduct.UnitName;
                        //txtBrand.Text = objProduct.Brand;
                        hdnBrand.Value = objProduct.Brand;
                        //hdnStyle.Value = objProduct.StyleAndSize;
                        //txtStyleSize.Text = objProduct.StyleAndSize;
                        //txtReOrderQty.Text = objProduct.ReOrderQty.ToString();

                        GroupId = int.Parse(objProduct.GroupId.ToString());
                        string Ocode = ((SessionUser)Session["SessionUser"]).OCode;

                        GetBalanceQuanity();


                        //DataTable dt = iChallanBll.GetProductByBarCodeFromStore(ddlItemName.SelectedValue, Ocode, ddlStore.SelectedValue.ToString());
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
            #region Comments

            //try
            //{
            //    Inv_BuyCentral invBuy = iChallanBll.LoadByCentralData(ddlItemName.SelectedValue, ddlStore.SelectedValue);

            //    if (invBuy != null)
            //    {
            //        hdnProductID.Value = Convert.ToString(invBuy.ProductId);
            //        hdnBrand.Value = invBuy.Brand;
            //        hdnStyleSize.Value = invBuy.StyleSize;
            //        txtUnit.Text = invBuy.UnitName;
            //        txtBalanceQty.Text = Convert.ToString(invBuy.BalanceQuanity);
            //        txtCPU.Text = Convert.ToString(invBuy.CPU);
            //    }
            //    else
            //    {
            //        txtBalanceQty.Text = "0";
            //    }
            //}
            //catch (Exception exz)
            //{
            //    throw exz;
            //}
            #endregion
        }

        private void GetBalanceQuanity()
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                Guid userId = ((SessionUser)Session["SessionUser"]).UserId;
                int PId = Convert.ToInt32(ddlItemName.SelectedValue.ToString());

                //List<Inv_BuyCentral> _BalanceQty = iChallanBll.Get_ItemBalance_ById_Store(OCode, PId, ddlStore.SelectedValue).ToList();

                List<productsDetails> Details = new List<productsDetails>();
                Details = rpt.Get_StockDetailsByDate_Product_Store(txtDate.Text, txtDate.Text, OCode, ddlItemGroup.SelectedValue.ToString(), ddlItemName.SelectedValue.ToString(), ddlStore.SelectedValue.ToString(), userId);

                if (Details.Count > 0)
                {
                    var BlQty = Details.Last();
                    txtBalanceQty.Text = BlQty.ClosingBalance.ToString();
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

        //private void FillProductInfo()
        //{
        //    string barCode = ddlItemName.SelectedValue.ToString();
        //    if (Convert.ToInt32(ddlItemName.SelectedValue) > 0)
        //    {
        //        ddlProductInfo.DataSource = iChallanBll.GetProductInfoByBarcode((barCode));
        //        ddlProductInfo.DataValueField = "BarCode";
        //        ddlProductInfo.DataTextField = "ProductName";
        //        ddlProductInfo.DataBind();
        //        ddlProductInfo.Items.Insert(0, new ListItem("Select Code", "0"));
        //    }
        //}

        protected void txtIssueQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtTotalCost.Text = (decimal.Parse((txtIssueQty.Text)) * decimal.Parse(txtCPU.Text)).ToString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        //protected void txtEID_TextChanged(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        lblMessage.Text = "";
        //        if (txtEID.Text.Trim() != "")
        //        {
        //            DataTable dt = iChallanBll.FindEmployee(txtEID.Text.Trim());
        //            foreach (DataRow dr in dt.Rows)
        //            {
        //                ddlDepartment.SelectedValue = dr["DPT_CODE"].ToString();
        //                LoadEmployeeList(dr["DPT_CODE"].ToString());
        //                string DeptCode = ddlDepartment.SelectedValue.ToString();
        //                LoadEmployeeList(DeptCode);
        //                ddlReciver.SelectedValue = dr["EID"].ToString();
        //                txtEID.Text = dr["EID"].ToString();
        //            }
        //        }
        //    }
        //    catch { }
        //}

        private void ClearForm()
        {
            //ddlItemGroup.ClearSelection();
            ddlItemName.ClearSelection();
            //txtBrand.Text = string.Empty;
            hdnBrand.Value = "";
            hdnStyleSize.Value = "";
            hdnProductID.Value = "";
            txtUnit.Text = string.Empty;
            //txtStyleSize.Text = string.Empty;
            txtIssueQty.Text = string.Empty;
            txtBalanceQty.Text = string.Empty;
            //ddlProductInfo.ClearSelection();
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            //string pronductNameandBrand = ddlItemName.SelectedItem.ToString();
            //string[] values = pronductNameandBrand.Split(' ');

            Inv_IChallan_Temp _ObjIchalanT = new Inv_IChallan_Temp();
            //if (txtChalanNo.Text == "")
            //{
            //    GenarateGinNumber();
            //}
            try
            {
                string BarCode = ddlItemName.SelectedValue;
                Guid userId = ((SessionUser)Session["SessionUser"]).UserId;

                if (BtnAdd.Text == "Add")
                {
                    //string BarCode = hdnBarCode.Value.ToString();

                    //if (BarCode == string.Empty || txtBalanceQty.Text == string.Empty || txtIssueQty.Text == "0")
                    //{
                    //    //  lblMessage.Text = "<font color='red'>Sorry! Invalid data. Issue quantity cannot be zero or negative. Please enter correct data</font>";
                    //    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Sorry! Invalid data. Issue quantity cannot be zero or negative. Please enter correct data')", true);
                    //    return;
                    //}

                    if (ddlSubCompany.SelectedItem.Text == "--Select Sub company--")
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Sub Company!')", true);
                        return;
                    }

                    if (double.Parse(txtIssueQty.Text) > double.Parse(txtBalanceQty.Text))
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Sorry! There are not enough quantity of selected good to issue. Please issue with less quantity')", true);
                        return;
                    }

                    //var GetDataByIChallan_Tem = iChallanBll.GetDataByIChallan_Tem(txtChalanNo.Text, BarCode).ToList();
                    var GetDataByIChallan_Tem = iChallanBll.GetDataByIChallan_TemUserWise(userId, BarCode).ToList();

                    if (GetDataByIChallan_Tem.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Item Already Exist In The List')", true);
                        return;
                    }

                    try
                    {
                        _ObjIchalanT.OldCompanyCode = ddlStore.SelectedValue.ToString();
                        _ObjIchalanT.SeasonID = Convert.ToInt32(ddlSeason.SelectedValue.ToString());
                        _ObjIchalanT.OrderEId = Convert.ToInt32(ddlOrder.SelectedValue.ToString());
                        _ObjIchalanT.DeliveryDate = Convert.ToDateTime(txtDate.Text);
                        _ObjIchalanT.ChallanNo = txtChalanNo.Text;
                        _ObjIchalanT.Sub_Company = ddlSubCompany.SelectedItem.Text;
                        _ObjIchalanT.EID = hIdEid.Value;

                        _ObjIchalanT.ProductGroup = Convert.ToInt32(ddlItemGroup.SelectedValue.ToString());
                        _ObjIchalanT.ProductId = int.Parse(ddlItemName.SelectedValue.ToString());//Convert.ToInt32(txtProductId.Text.Trim());
                        //purchase.ProductGroup = int.Parse(ddlProductGroup.SelectedValue.ToString());

                        //purchase.Barcode = buyCentralBll.GetBarcode(int.Parse(purchase.ProductId.ToString()));
                        _ObjIchalanT.BarCode = Convert.ToInt16(_ObjIchalanT.ProductId).ToString();

                        string pronductNameandBrand = ddlItemName.SelectedItem.ToString();
                        string[] values = pronductNameandBrand.Split('+');
                        _ObjIchalanT.ProductName = values[0].ToString();

                        _ObjIchalanT.UnitName = txtUnit.Text;
                        _ObjIchalanT.BalanceQuanity = Convert.ToDouble(txtBalanceQty.Text);
                        _ObjIchalanT.DeliveryQty = Convert.ToDouble(txtIssueQty.Text);

                        string OCode = ((SessionUser)Session["SessionUser"]).OCode;

                        _ObjIchalanT.EditDate = DateTime.Now;
                        _ObjIchalanT.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                        _ObjIchalanT.OCode = OCode;

                        iChallanBll.Insert(_ObjIchalanT);

                        #region Comments All Old Code

                        //SerialNo = SerialNo + 1;
                        //purchase.Id = SerialNo;
                        //Hashtable ht = new Hashtable();

                        //ht.Add("Store_Id", ddlStore.SelectedValue);

                        //ht.Add("SeasonID", ddlSeason.SelectedValue);
                        //ht.Add("OrderEId", ddlOrder.SelectedValue);
                        ////ht.Add("PurchaseDate", txtDate.Text.ToString());
                        //ht.Add("ProductGroup", ddlItemGroup.SelectedValue);
                        //ht.Add("BarCode", BarCode);
                        //ht.Add("ProductId", ddlItemName.SelectedValue);

                        //ht.Add("ProductName", values[0].ToString());
                        //ht.Add("UnitName", txtUnit.Text);
                        //ht.Add("Brand", hdnBrand.Value);
                        //ht.Add("StyleSize", hdnStyleSize.Value);
                        //ht.Add("ChallanNo", txtChalanNo.Text);
                        //ht.Add("DeliveryQty", txtIssueQty.Text);
                        ////ht.Add("OrderNo", txtOrderNo.Text);
                        ////ht.Add("TransferDate", txtDate.Text);
                        ////ht.Add("DPT_CODE", ddlDepartment.SelectedValue.ToString());
                        //ht.Add("EID", hIdEid.Value);
                        //ht.Add("CPU", txtCPU.Text);
                        //ht.Add("ChallanTotal", txtTotalCost.Text);
                        //ht.Add("CurrentCompanyCode", "n/a");
                        //ht.Add("OldCompanyCode", ddlStore.SelectedValue);
                        //ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode.ToString());

                        ////ht.Add("OldCompanyCode", "8989");
                        ////ht.Add("OCode", "8989");
                        //DataTable dt = iChallanBll.DeliverProduct_Temp(ht);

                        #endregion
                        //grvIssue.DataSource = dt;
                        //grvIssue.DataBind();
                        BindPurchaseGrid();
                        ClearForm();

                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Issue information has been added temporarily. Please post.')", true);
                    }
                    catch (Exception ex)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                    }
                }
                else
                {
                    if (BtnAdd.Text == "Update")
                    {
                        double qty = Convert.ToDouble(txtIssueQty.Text);

                        var mn = iChallanBll.Update_IChalanTemp(userId, BarCode, qty);
                        if (mn == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                            BindPurchaseGrid();
                            ClearForm();
                            BtnAdd.Text = "Add";
                            return;
                        }
                        else
                        {

                        }
                    }
                }
                BindPurchaseGrid();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        public void BindPurchaseGrid()
        {
            Guid userId = ((SessionUser)Session["SessionUser"]).UserId;
            grvIssue.DataSource = iChallanBll.GetIChalanTempWithUser(((SessionUser)Session["SessionUser"]).OCode, userId);
            //grvIssue.DataSource = iChallanBll.GetIChalanTemp(("8989"), challanNo);
            grvIssue.DataBind();
        }

        private void ClearFullForm()
        {
            //txtEID.Text = string.Empty;
            //txtChalanNo.Text = string.Empty;
            //txtDate.Text = DateTime.Today.ToShortDateString();
            //ddlDepartment.ClearSelection();
            //ddlStore.ClearSelection();
            //ddlReciver.ClearSelection();
            txtUnit.Text = string.Empty;
            //txtOrderNo.Text = string.Empty;
            txtIssueQty.Text = string.Empty;
            grvIssue.DataSource = null;
            grvIssue.DataBind();
            lblTotalCost.Text = "";
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                GenarateGinNumber();
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                string ChallanNo = txtChalanNo.Text;

                #region Old Codes Comments Here

                //string BarCode = hdnBarCode.Value.ToString();
                Hashtable ht = new Hashtable();
                ht.Add("DeliveryType", "StoreToDepartment"); // Center to department/individual
                ht.Add("ChallanNo", txtChalanNo.Text);
                //ht.Add("BarCode", BarCode);
                //ht.Add("DeliveryQty", txtIssueQty.Text);
                ht.Add("TransferDate", Convert.ToDateTime(txtDate.Text));
                ht.Add("DPT_CODE", "n/a");
                ht.Add("EID", hIdEid.Value);
                ht.Add("CurrentCompanyCode", "n/a");
                ht.Add("OldCompanyCode", ddlStore.SelectedValue);
                ht.Add("OrderNo", ddlOrder.SelectedItem.Text);
                ht.Add("Sub_Company", ddlSubCompany.SelectedItem.Text);
                ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode.ToString());
                ht.Add("EditUser", ((SessionUser)Session["SessionUser"]).UserId.ToString());
                ht.Add("EditDate", DateTime.Now);
                // ht.Add("CPU", txtCPU.Text);
                // ht.Add("ChallanTotal", txtTotalCost.Text);
                //ht.Add("OCode", "8989");

                DataTable dt = iChallanBll.DeliverProduct(ht);

                #endregion

                //iChallanBll.TransferDataFromiChallanTempToiChallan(OCode, ChallanNo);

                if (dt.Rows.Count > 0)
                {
                    // print report here
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('GIN issued successfully')", true);
                    ClearFullForm();
                }
                else
                {
                    ClearFullForm();
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('GIN issued successfully')", true);
                }
                //txtBalQty.Text = txtRemainQty.Text;

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        //public void BindPurchaseGrid(string challanNo)
        //{
        //    try
        //    {
        //        string OCode = ((SessionUser)Session["SessionUser"]).OCode;
        //        List<Inv_IChallan_Temp> groups = iChallanBll.GetIssueeGrid(challanNo, OCode);
        //        if (groups.Count > 0)
        //        {
        //            grvIssue.DataSource = groups;
        //            grvIssue.DataBind();
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    //grvIssue.DataSource = iChallanBll.GetIChalanTemp(((SessionUser)Session["SessionUser"]).OCode, challanNo);
        //    //grvIssue.DataSource = iChallanBll.GetIChalanTemp(("8989"), challanNo);
        //    //grvIssue.DataBind();
        //}

        protected void grvIssue_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblMessage.Text = "";
            int id = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "dlt")
            {
                iChallanBll.DeleteTempChalanById(id);
                BindPurchaseGrid();
            }
            if (e.CommandName == "edt")
            {

                foreach (Inv_IChallan_Temp temp in _context.Inv_IChallan_Temp.Where(x => x.Id == id).ToList())
                {
                    ddlItemGroup.SelectedValue = temp.ProductGroup.ToString();
                    FillProductName();
                    txtBalanceQty.Text = temp.BalanceQuanity.ToString();
                    txtIssueQty.Text = temp.DeliveryQty.ToString();
                    ddlItemName.SelectedValue = temp.BarCode.ToString();
                    txtUnit.Text = temp.UnitName.ToString();
                    BtnAdd.Text = "Update";
                }
            }
            //BindPurchaseGrid();
        }

        decimal sumFooterValue = 0;

        //protected void grvIssue_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    try
        //    {
        //        if (e.Row.RowType == DataControlRowType.DataRow)
        //        {
        //            string totalAmount = e.Row.Cells[8].Text;

        //            decimal grandTotal = Convert.ToDecimal(totalAmount);
        //            sumFooterValue += grandTotal;
        //        }
        //        lblTotalCost.Text = sumFooterValue.ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
        //    }
        //}

        //protected void ddlReciver_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    //txtEID.Text = ddlReciver.SelectedValue.ToString();
        //}

        protected void ddlChalanNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string challanNo = ddlChalanNo.SelectedValue.ToString();
            FillFormForOldChallan(challanNo);
            //BindPurchaseGrid(challanNo);
        }
        private void FillOldChalan()
        {
            try
            {
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                //string Ocode = "8989";
                ddlChalanNo.DataSource = iChallanBll.GetOldUnPostedIChallanForStoreToDpt(Ocode);
                ddlChalanNo.DataValueField = "ChallanNo";
                ddlChalanNo.DataTextField = "ChallanNo";
                ddlChalanNo.DataBind();
                ddlChalanNo.Items.Insert(0, new ListItem("Select Unposted GIN", "0"));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillFormForOldChallan(string challanNo)
        {
            try
            {
                DataTable dt = new DataTable();
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                //string Ocode = "8989";
                dt = iChallanBll.OldChallan(challanNo, Ocode);
                foreach (DataRow dr in dt.Rows)
                {
                    txtChalanNo.Text = dr["ChallanNo"].ToString();
                    ddlStore.SelectedValue = dr["OldCompanyCode"].ToString();
                    FillSeason();
                    ddlSeason.SelectedValue = dr["SeasonID"].ToString();
                    LoadOrderNumber();
                    ddlOrder.SelectedValue = dr["OrderEId"].ToString();
                    txtDate.Text = dr["DeliveryDate"].ToString();
                    //ddlDepartment.SelectedValue = dr["DPT_CODE"].ToString();
                    //string DeptCode = ddlDepartment.SelectedValue.ToString();
                    //LoadEmployeeList(DeptCode);
                    //ddlReciver.SelectedValue = dr["EID"].ToString();
                    //txtEID.Text = ddlReciver.SelectedValue.ToString();
                    //txtOrderNo.Text = dr["OrderNo"].ToString();

                }
                ddlItemGroup.SelectedValue = "0";
                ddlItemName.SelectedValue = "0";
                txtUnit.Text = string.Empty;
                txtBalanceQty.Text = string.Empty;
                //txtBrand.Text = string.Empty;
                hdnBrand.Value = "";
                //hdnStyle.Value = "";
                //txtStyleSize.Text = string.Empty;
                txtIssueQty.Text = string.Empty;
                txtBalanceQty.Text = string.Empty;
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlOrder.Enabled = true;
            LoadOrderNumber();

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                string ChallanNo = txtChalanNo.Text;
                DataTable dataSource = iChallanBll.GetStoreToDepartmentReport(ChallanNo, OCode);

                ReportViewerDo.LocalReport.DataSources.Clear();
                ReportDataSource reportDataset = new ReportDataSource("PurchaseVoucher_DS", dataSource);
                ReportViewerDo.LocalReport.DataSources.Add(reportDataset);
                ReportViewerDo.LocalReport.ReportPath = Server.MapPath("Reports/RPT_StoreToDepartmentGIN.rdlc");
                ReportViewerDo.LocalReport.Refresh();
                txtChalanNo.Text = string.Empty;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        //protected void ddlProductInfo_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string barCode = ddlProductInfo.SelectedValue.ToString();
        //    string OCode = ((SessionUser)Session["SessionUser"]).OCode.ToString();
        //    //string OCode = "8989";
        //    DataTable dt = iChallanBll.GetProductInforByBarCode(barCode, OCode, 0);
        //    //hdnBarCode.Value = ddlItemName.SelectedValue.ToString();
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        txtBalanceQty.Text = dr["BalanceQuanity"].ToString();
        //    }
        //}

    }
}