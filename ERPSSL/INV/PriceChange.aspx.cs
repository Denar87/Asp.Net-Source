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
    public partial class PriceChange : System.Web.UI.Page
    {
        IChallanBLL ic = new IChallanBLL();
        PriceAndDamage price = new PriceAndDamage();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                FillCompany();
                txtDate.Text = DateTime.Today.ToShortDateString();
               
            }
        }

        public void FillCompany()
        {
            ddlStore.DataSource = ic.GetCompanyList();
            ddlStore.DataValueField = "CompanyCode";
            ddlStore.DataTextField = "CompanyName";
            ddlStore.DataBind();
            ddlStore.Items.Insert(0, new ListItem("Select One", "0"));
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

        protected void ddlStore_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            FillProductGroup();
        }

        private void FillProductName(string cmpCode)
        {
            try
            {
                if (Convert.ToInt32(ddlProductGroup.SelectedValue) > 0)
                {
                    ddlProduct.DataSource = ic.GetProductListByGroup(Convert.ToInt32(ddlProductGroup.SelectedValue), cmpCode);
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

        protected void ddlProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                ddlProduct.Enabled = true;
                string cmpCode = ddlStore.SelectedValue.ToString();
                if (cmpCode != "0")
                {
                    FillProductName(cmpCode);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

       

        private void ClearForm()
        {
            txtChangeCPU.Text = string.Empty;
            txtBalanceQty.Text = string.Empty;
            txtOldCPU.Text = string.Empty;
            ddlProduct.ClearSelection();
            ddlProductGroup.ClearSelection();
            ddlStore.ClearSelection();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            string BarCode = hdnBarCode.Value.ToString();
            if (BarCode == string.Empty || ddlStore.SelectedValue == "0" || txtChangeCPU.Text == string.Empty)
            {
                return;
            }
            try
            {
                DateTime date = DateTime.Today;
                try
                {
                    date = DateTime.Parse(txtDate.Text);
                }
                catch { }
                Hashtable ht = new Hashtable();
                ht.Add("BarCode", BarCode);
                ht.Add("CompanyCode", ddlStore.SelectedValue.ToString());
                ht.Add("ChangeDate", date);
                ht.Add("NewCPU", txtChangeCPU.Text);
                
                if (price.ChangePrice(ht))
                {
                   // lblMessage.Text = "<font color='green'>Price has been updated successfully!</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Price has been updated successfully!')", true);
                    ClearForm();
                }
                else
                {
                   // lblMessage.Text = "<font color='red'>Error in updating price!</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Error in updating price!')", true);
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
                string barCode = ddlProduct.SelectedValue.ToString();
                string cmpCode = ddlStore.SelectedValue.ToString();
                hdnBarCode.Value = ddlProduct.SelectedValue.ToString();
                DataTable dt = ic.GetProductInforByBarCode(barCode, cmpCode);
                foreach (DataRow dr in dt.Rows)
                {
                    txtBalanceQty.Text = dr["BalanceQuanity"].ToString();
                    txtOldCPU.Text = dr["CPU"].ToString();
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

    }
}