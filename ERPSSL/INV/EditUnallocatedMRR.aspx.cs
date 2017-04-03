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
    public partial class EditUnallocatedMRR : System.Web.UI.Page
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
                    GetUnallocatedMRR();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        public void GetUnallocatedMRR()
        {
            int id = Convert.ToInt32(Session["RchallanId"].ToString());
            var result = rChallanBll.GetInv_RChallanById(id);
            if (result.Count > 0)
            {
                var row = result.First();
                FillSupplier();
                ddlSupplier.SelectedValue = row.SupplierCode;
                this.GetAllStore();
                txtDate.Text = row.ChallanDate.ToString();
                txtChallanNo.Text = row.ChallanNo.ToString();
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
                var row = companyBll.GetCompnay(OCODE);
                if (row.Count > 0)
                {
                    ddlStore.DataSource = row.ToList();
                    ddlStore.DataTextField = "CompanyName";
                    ddlStore.DataValueField = "CompanyCode";
                    ddlStore.DataBind();
                    ddlStore.AppendDataBoundItems = false;
                    ddlStore.Items.Insert(0, new ListItem("Select One", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
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
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ddlStore.SelectedValue != null)
                {
                    List<Inv_Company> company = companyBll.GetcompanyByCode(ddlStore.SelectedValue).ToList();
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

        private string GetCompanyIdByCode(string code)
        {
            return companyBll.GetCompanyIdByCode(code);
        }

        private string GetCompanyNameByCode(string CompanyCode)
        {
            return companyBll.GetCompanyNameByCode(CompanyCode);
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

            return c;
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(Session["RchallanId"]);
                if (id != 0)
                {
                    int result = buyCentralBll.Update_buyCentral(id);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                        ddlStore.ClearSelection();
                        ddlSupplier.ClearSelection();
                        txtChallanNo.Text = "";
                        txtDate.Text = "";
                        txtRefNo.Text = "";
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
