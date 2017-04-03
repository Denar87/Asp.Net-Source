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

namespace ERPSSL.INV
{
    public partial class MaterialIssueGeneral : System.Web.UI.Page
    {
        ProductBLL productBll = new ProductBLL();
        public static DataTable stCompany = new DataTable();
        IChallanBLL iChallanBll = new IChallanBLL();
        public static int SerialNo = 0;
        BuyCentralBLL buyCentralBll = new BuyCentralBLL();
        public static string CentralCode = "";
        CompanyBLL companyBll = new CompanyBLL();
        ProjectBLL projectBll = new ProjectBLL();
        StoreUnitBLL aStoreUnitBLL = new StoreUnitBLL();
        StoreBLL aStoreBll = new StoreBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillProductGroup();
                FillDepartment();
                txtDate.Text = DateTime.Today.ToShortDateString();
                stCompany = companyBll.GetCentralCompany();
                foreach (DataRow dr in stCompany.Rows)
                {
                    CentralCode = dr["CompanyCode"].ToString();
                }
                GetAllProject();
                GetAllStore();
                GetAllStoreUnit();
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

        public void FillDepartment()
        {

            ddlDepartment.DataSource = iChallanBll.GetDepartmentList();
            ddlDepartment.DataValueField = "DPT_CODE";
            ddlDepartment.DataTextField = "DPT_NAME";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("Select One", "0"));

        }

        public void FillProductGroup()
        {

            ddlItemGroup.DataSource = iChallanBll.GetListGroup();
            ddlItemGroup.DataValueField = "GroupId";
            ddlItemGroup.DataTextField = "GroupName";
            ddlItemGroup.DataBind();
            ddlItemGroup.Items.Insert(0, new ListItem("Select One", "0"));

        }

        private void FillProductName()
        {
            try
            {
                if (Convert.ToInt32(ddlItemGroup.SelectedValue) > 0)
                {
                    ddlItemName.DataSource = iChallanBll.GetProductListByGroup_FromStore(ddlItemGroup.SelectedValue, ddlProject.SelectedValue, Convert.ToInt32(ddlStoreName.SelectedValue), Convert.ToInt32(ddlStoreUnit.SelectedValue));
                    ddlItemName.DataValueField = "BarCode";
                    ddlItemName.DataTextField = "ProductName";
                    ddlItemName.DataBind();
                    ddlItemName.Items.Insert(0, new ListItem("Select One", "0"));
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlItemGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            ddlItemName.Enabled = true;
            FillProductName();
        }

        private void LoadEmployeeList(string DeptCode)
        {
            try
            {
 ddlReciver.DataSource = iChallanBll.GetEmployeeList(DeptCode);
            ddlReciver.DataValueField = "EID";
            ddlReciver.DataTextField = "EMP_NAME";
            ddlReciver.DataBind();
            ddlReciver.Items.Insert(0, new ListItem("Select One", "0"));
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string DeptCode = ddlDepartment.SelectedValue.ToString();
                LoadEmployeeList(DeptCode);
                txtChalanNo.Text = iChallanBll.GetNewChalanNo(DeptCode, DateTime.Parse(txtDate.Text), "DPT");
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
 string barCode = ddlItemName.SelectedValue.ToString();
            string OCode = ((SessionUser)Session["SessionUser"]).OCode.ToString();
            //string OCode = "8989";
            DataTable dt = iChallanBll.GetProductInfor_FromStore(barCode, OCode, ddlProject.SelectedValue, Convert.ToInt32(ddlStoreName.SelectedValue), Convert.ToInt32(ddlStoreUnit.SelectedValue));
            hdnBarCode.Value = ddlItemName.SelectedValue.ToString();
            foreach (DataRow dr in dt.Rows)
            {
                // this is brand. No time to change the control name !
                txtUnit.Text = dr["UnitName"].ToString();
                hdnBrand.Value = dr["Brand"].ToString();
                hdnStyleSize.Value = dr["StyleSize"].ToString();
                txtStyleSize.Text = dr["StyleSize"].ToString();
                txtBalanceQty.Text = dr["BalanceQuanity"].ToString();
                //txtCurrentLocation.Text = dr["Location"].ToString();
            }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void txtIssueQty_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    txtBalanceQty.Text = (int.Parse((txtBalanceQty.Text)) - int.Parse(txtIssueQty.Text)).ToString();
            //}
            //catch
            //{

            //}

        }

        protected void txtEID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                if (txtEID.Text.Trim() != "")
                {
                    DataTable dt = iChallanBll.FindEmployee(txtEID.Text.Trim());
                    foreach (DataRow dr in dt.Rows)
                    {
                        ddlDepartment.SelectedValue = dr["DPT_CODE"].ToString();
                        LoadEmployeeList(dr["DPT_CODE"].ToString());
                        ddlReciver.SelectedValue = txtEID.Text.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearForm()
        {
            ddlItemGroup.ClearSelection();
            ddlItemName.ClearSelection();
            //txtBrand.Text = string.Empty;
            hdnBrand.Value = "";
            hdnStyleSize.Value = "";
            txtUnit.Text = string.Empty;
            txtStyleSize.Text = string.Empty;
            txtIssueQty.Text = string.Empty;
            txtBalanceQty.Text = string.Empty;

        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                string BarCode = hdnBarCode.Value.ToString();
                if (BarCode == string.Empty || txtBalanceQty.Text == string.Empty || ddlDepartment.SelectedValue == "0" || txtIssueQty.Text == "0")
                {
                    //  lblMessage.Text = "<font color='red'>Sorry! Invalid data. Issue quantity cannot be zero or negetive. Please enter correct data</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Sorry! Invalid data. Issue quantity cannot be zero or negetive. Please enter correct data')", true);
                    return;
                }
                if (int.Parse(txtIssueQty.Text) > int.Parse(txtBalanceQty.Text))
                {
                    // lblMessage.Text = "<font color='red'>Sorry! There are not enough quantity of selected good to issue. Please purchase or issue with less quantity</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Sorry! There are not enough quantity of selected good to issue. Please purchase or issue with less quantity')", true);

                    return;
                }

                try
                {
                    //SerialNo = SerialNo + 1;
                    //purchase.Id = SerialNo;
                    Hashtable ht = new Hashtable();
                    //ht.Add("DeliveryType", "CenterToDepartment"); // Any company/store to its department/individual
                    //ht.Add("DeliveryType", "CenterToCompany");
                    ht.Add("ProductGroup", ddlItemGroup.SelectedValue);
                    ht.Add("BarCode", BarCode);
                    ht.Add("ProductId", BarCode);

                    string pronductNameandBrand = ddlItemName.SelectedItem.ToString();
                    string[] values = pronductNameandBrand.Split(' ', '-');
                    ht.Add("ProductName", values[0].ToString());
                    ht.Add("UnitName", txtUnit.Text);
                    ht.Add("Brand", hdnBrand.Value);
                    ht.Add("StyleSize", hdnStyleSize.Value);
                    ht.Add("ChallanNo", txtChalanNo.Text);
                    ht.Add("DeliveryQty", txtIssueQty.Text);
                    //ht.Add("TransferDate", txtDate.Text);
                    ht.Add("DPT_CODE", ddlDepartment.SelectedValue.ToString());
                    //ht.Add("EID", ddlReciver.SelectedValue.ToString());
                    ht.Add("CurrentCompanyCode", CentralCode);
                    ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode.ToString());
                    ht.Add("ProjectCode", ddlProject.SelectedValue);
                    ht.Add("StoreID", ddlStoreName.SelectedValue);
                    ht.Add("StoreUnit_ID", ddlStoreUnit.SelectedValue);

                    DataTable dt = iChallanBll.DeliverProduct_Temp1(ht);
                    grvIssue.DataSource = dt;
                    grvIssue.DataBind();
                    ClearForm();
                    //  lblMessage.Text = "<font color='green'>Issue information added temporarily. Please post.</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Issue information added temporarily. Please post.')", true);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearFullForm()
        {
            txtEID.Text = string.Empty;
            txtChalanNo.Text = string.Empty;
            txtDate.Text = DateTime.Today.ToShortDateString();
            ddlDepartment.ClearSelection();
            ddlReciver.ClearSelection();
            txtUnit.Text = string.Empty;
            txtIssueQty.Text = string.Empty;
            grvIssue.DataSource = null;
            grvIssue.DataBind();
            ddlStoreUnit.ClearSelection();
            ddlStoreName.ClearSelection();
            ddlProject.ClearSelection();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //    string BarCode = hdnBarCode.Value.ToString();
                Hashtable ht = new Hashtable();
                ht.Add("DeliveryType", "CenterToDepartment"); // Center to department/individual
                ht.Add("ChallanNo", txtChalanNo.Text);
                //ht.Add("BarCode", BarCode);
                //ht.Add("DeliveryQty", txtIssueQty.Text);
                ht.Add("TransferDate", txtDate.Text);
                ht.Add("DPT_CODE", ddlDepartment.SelectedValue);
                ht.Add("EID", txtEID.Text);
                ht.Add("CurrentCompanyCode", CentralCode);
                //ht.Add("CurrentCo//mpanyCode", ddlCompanyTo.SelectedValue.ToString());
                ht.Add("OldCompanyCode", "n/a");
                ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode.ToString());
                ht.Add("ProjectCode", ddlProject.SelectedValue);
                ht.Add("StoreID", ddlStoreName.SelectedValue);
                ht.Add("StoreUnit_ID", ddlStoreUnit.SelectedValue);

                DataTable dt = iChallanBll.DeliverProduct_FromStoreUnit(ht);
                if (grvIssue.Rows.Count == 0)
                {
                    // lblMessage.Text = "<font color='red'>Item list is empty!</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Item list is empty!')", true);
                    return;
                }
                if (dt.Rows.Count > 0)
                {
                    // print report here

                    //
                    // lblMessage.Text = "<font color='green'>GIN Issued successfully!</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('GIN issued successfully!')", true);
                    ClearFullForm();
                    grvIssue.DataSource = null;
                    grvIssue.DataBind();
                }
                else
                {
                    //ClearFullForm();
                    //   lblMessage.Text = "<font color='red'>Error in GIN Issue. Please try again.</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Error in GIN Issue. Please try again.')", true);
                    //grvIssue.DataSource = null;
                    //grvIssue.DataBind();
                    //lblMessage.Text = "<font color='green'>GIN Issued successfully!</font>";
                }
                //txtBalQty.Text = txtRemainQty.Text;

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        public void BindPurchaseGrid(string challanNo)
        {
            grvIssue.DataSource = iChallanBll.GetIChalanTemp(((SessionUser)Session["SessionUser"]).OCode, challanNo);
            //grvIssue.DataSource = iChallanBll.GetIChalanTemp(("8989"), challanNo);
            grvIssue.DataBind();
        }

        protected void grvIssue_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblMessage.Text = "";
            int id = Convert.ToInt32(e.CommandArgument);
            iChallanBll.DeleteTempChalanById(id);
            BindPurchaseGrid(txtChalanNo.Text.Trim());
        }

        protected void ddlReciver_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEID.Text = ddlReciver.SelectedValue.ToString();
        }

    }
}