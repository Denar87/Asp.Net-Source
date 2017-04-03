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

namespace ERPSSL.INV
{
    public partial class ReturnTOCentralFromStore : System.Web.UI.Page
    {
        IChallanBLL ic = new IChallanBLL();
        StoreBLL aStoreBll = new StoreBLL();
        CompanyBLL _companyBll = new CompanyBLL();
        public static DataTable stCompany = new DataTable();
        public static string CentralCode = "";
        public static string CompanyType = "";
        Inv_StoreBLL companyBll = new Inv_StoreBLL();

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
                    GetAllStore();
                    FillDepartment();
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
                var result = _companyBll.GetStore(((SessionUser)Session["SessionUser"]).OCode);
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

        public void FillDepartment()
        {
            ddlDepartment.DataSource = ic.GetDepartmentList();
            ddlDepartment.DataValueField = "DPT_CODE";
            ddlDepartment.DataTextField = "DPT_NAME";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("Select One", "0"));

        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                string DeptCode = ddlDepartment.SelectedValue.ToString();
                LoadEmployeeList(DeptCode);
                DateTime date = DateTime.Today;
                date = DateTime.Parse(txtDate.Text);
                txtChalanNo.Text = ic.GetNewReturnChalanNo(DeptCode, date, "DPT");
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void LoadEmployeeList(string DeptCode)
        {
            ddlEmployee.DataSource = ic.GetEmployeeList(DeptCode);
            ddlEmployee.DataValueField = "EID";
            ddlEmployee.DataTextField = "EMP_NAME";
            ddlEmployee.DataBind();
            ddlEmployee.Items.Insert(0, new ListItem("Select One", "0"));
        }

        protected void ddlProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            ddlProduct.Enabled = true;
            //string cmpCode = ddlCompanyFrom.SelectedValue.ToString();
            string EID = ddlEmployee.SelectedValue.ToString();
            string deptCode = ddlDepartment.SelectedValue.ToString();
            if (deptCode != "0")
            {
                FillProductName(deptCode, EID);
            }
        }

        public void FillProductGroup()
        {

            ddlProductGroup.DataSource = ic.GetListGroup();
            ddlProductGroup.DataValueField = "GroupId";
            ddlProductGroup.DataTextField = "GroupName";
            ddlProductGroup.DataBind();
            ddlProductGroup.Items.Insert(0, new ListItem("Select One", "0"));

        }

        private void FillProductName(string deptCode, string EID)
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

        protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillProductGroup();
            txtReturnQty.Enabled = true;
        }

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            string barCode = ddlProduct.SelectedValue.ToString();
            //string cmpCode = ddlCompanyFrom.SelectedValue.ToString();
            hdnBarCode.Value = ddlProduct.SelectedValue.ToString();
            DataTable dt = ic.GetProductInforByBarCode(barCode, "CENTRAL", "CENTRAL");
            float employeeStock = ic.GetEmployeeStock(ddlEmployee.SelectedValue, barCode);
            foreach (DataRow dr in dt.Rows)
            {
                //txtSize.Text = dr["StyleSize"].ToString();
                if (employeeStock <= 0)
                {
                    txtReturnQty.Enabled = false;
                    txtBalanceQty.Text = "0";
                }
                else
                {
                    txtReturnQty.Enabled = true;
                    var formated = String.Format("{0:0.00}", employeeStock);
                    txtBalanceQty.Text = formated.ToString();
                }
                //txtCurrentLocation.Text = dr["Location"].ToString();
            }
        }

        protected void txtReturnQty_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtReturnQty.Text.Trim() != string.Empty)
                {
                    txtRemainingQty.Text = (double.Parse(txtBalanceQty.Text) - double.Parse(txtReturnQty.Text)).ToString();
                }
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
            txtReturnQty.Text = string.Empty;
            txtRemainingQty.Text = string.Empty;
            txtBalanceQty.Text = string.Empty;
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string BarCode = hdnBarCode.Value.ToString();
                if (BarCode == string.Empty || txtBalanceQty.Text == string.Empty || ddlEmployee.SelectedValue == "0" || ddlProduct.SelectedValue == "0" || txtReturnQty.Text == "0")
                {
                    //lblMessage.Text = "<font color='red'>Invalid data. Please be correct and try again!</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Invalid data. Please be correct and try again!')", true);
                    return;
                }
                if (double.Parse(txtReturnQty.Text) > double.Parse(txtBalanceQty.Text))
                {
                    //lblMessage.Text = "<font color='red'>Sorry! You cannot return more then you have. Please be correct and try again!</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Sorry! You cannot return more then you have. Please be correct and try again!')", true);
                    return;
                }
                else if (Convert.ToDateTime(txtDate.Text) > DateTime.Now)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Date can not be greater than current date!')", true);
                    return;
                }

                Hashtable ht = new Hashtable();
                ht.Add("ReturnType", "DepartmentToCenter"); // Center to department/individual
                ht.Add("BarCode", BarCode);
                ht.Add("ChallanNo", txtChalanNo.Text);
                ht.Add("ReturnQty", txtReturnQty.Text);
                ht.Add("ReturnDate", txtDate.Text);
                ht.Add("DPT_CODE", ddlDepartment.SelectedValue);
                ht.Add("EID", ddlEmployee.SelectedValue);
                ht.Add("SupplierCode", "NA");
                ht.Add("CenterCode", "NA");
                ht.Add("StoreCode", ddlStore.SelectedValue.ToString());
                ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode.ToString());
                ht.Add("CompanyCode", CentralCode.ToString());
                ht.Add("BalanceQuanity", txtRemainingQty.Text);
                ht.Add("EditUser", ((SessionUser)Session["SessionUser"]).UserId);
                //ht.Add("OCode", "8989");
                DataTable dt = ic.ReturnProductStoreWise(ht);
                // lblMessage.Text = "<font color='green'>Product has been returned successfully!</font>";
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Item Returned Successfully')", true);
                grdTransfer.DataSource = dt;
                grdTransfer.DataBind();
                //txtBalQty.Text = txtRemainQty.Text;
                ClearForm();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

    }
}