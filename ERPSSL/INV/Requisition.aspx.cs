using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL;
using ERPSSL.INV.BLL;
using ERPSSL.Procurement.BLL;

namespace ERPSSL.INV
{
    public partial class Requisition : System.Web.UI.Page
    {
        IChallanBLL ic = new IChallanBLL();
        ProductBLL productBll = new ProductBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    FillProductGroup();
                    FillDepartment();
                    txtDate.Text = DateTime.Today.ToShortDateString();
                    //txtBalanceQty.Enabled = false;
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void FillDepartment()
        {

            ddlDepartment.DataSource = ic.GetDepartmentList();
            ddlDepartment.DataValueField = "DPT_CODE";
            ddlDepartment.DataTextField = "DPT_NAME";
            ddlDepartment.DataBind();
            ddlDepartment.Items.Insert(0, new ListItem("Select One", "0"));
        }

        private void FillProductGroup()
        {
            ddlProductGroup.DataSource = ic.GetListGroup();
            ddlProductGroup.DataValueField = "GroupId";
            ddlProductGroup.DataTextField = "GroupName";
            ddlProductGroup.DataBind();
            ddlProductGroup.Items.Insert(0, new ListItem("Select One", "0"));
        }


        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                string DeptCode = ddlDepartment.SelectedValue.ToString();
                LoadEmployeeList(DeptCode);
                BindRequisitionNo();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void BindRequisitionNo()
        {
            if (ddlDepartment.SelectedValue != "0" && txtDate.Text != "")
            {
                try
                {
                    DateTime date;
                    try
                    {
                        date = DateTime.Parse(txtDate.Text);
                    }
                    catch
                    {
                        date = DateTime.Today;
                    }

                    txtRequisitionNo.Text = ic.GetNewRequisitionNo("DPT", "", ddlDepartment.SelectedValue, ddlEmployee.SelectedValue, date);
                }
                catch (Exception ex)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
                }
            }
        }

        private void LoadEmployeeList(string DeptCode)
        {
            try
            {
                ddlEmployee.DataSource = ic.GetEmployeeList(DeptCode);
                ddlEmployee.DataValueField = "EID";
                ddlEmployee.DataTextField = "EMP_NAME";
                ddlEmployee.DataBind();
                ddlEmployee.Items.Insert(0, new ListItem("Select One", "0"));
            }
            catch (Exception)
            {

                throw;
            }

        }

        protected void txtDate_TextChanged(object sender, EventArgs e)
        {
            BindRequisitionNo();
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string BarCode = ddlProduct.SelectedValue;
                string Quantity = txtQuantity.Text;
                string ReqDate = txtDate.Text;
                if (BarCode == "" || Quantity == "" || ReqDate == "" || ddlDepartment.SelectedValue == "0" || ddlEmployee.SelectedValue == "0" || txtRequisitionNo.Text == "")
                {
                    return;
                }

                if (int.Parse(txtQuantity.Text) <= 0)
                {
                    // lblMessage.Text = "<font color='red'>Sorry! Invalid data. Requisition quantity cannot be zero or negetive. Please enter correct data</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Sorry! Invalid data. Requisition quantity cannot be zero or negetive. Please enter correct data')", true);
                    return;
                }

                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("ReqNo", txtRequisitionNo.Text);
                    ht.Add("ReqType", "FROM_DPT_EMP");
                    ht.Add("CompanyCode", "");
                    ht.Add("DPT_CODE", ddlDepartment.SelectedValue);
                    ht.Add("EID", ddlEmployee.SelectedValue);
                    ht.Add("BarCode", ddlProduct.SelectedValue);
                    ht.Add("Qty", txtQuantity.Text);
                    ht.Add("ReqDate", txtDate.Text);
                    ht.Add("DesiredRcvDate", txtExpectedDate.Text);
                    ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode);
                    if (RequisionBll.AddRequisition(ht))
                    {
                        //lblMessage.Text = "<font color='green'>Requisition for this product has been inserted successfully!</font>";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Requisition for this product has been inserted successfully!')", true);
                        LoadRequisitions(txtRequisitionNo.Text);
                        ClearForm();
                    }
                    else
                    {
                        // lblMessage.Text = "<font color='red'>Error in adding requisition! Please try again</font>";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Error in adding requisition! Please try again')", true);
                    }

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

        private void ClearForm()
        {
            ddlProductGroup.ClearSelection();
            ddlProduct.Items.Clear();
            txtExpectedDate.Text = string.Empty;
            txtQuantity.Text = string.Empty;
            txtBrand.Text = string.Empty;
            //txtRequisitionNo.Text = string.Empty;
        }

        private void LoadRequisitions(string ReqNo)
        {
            grdRequisition.DataSource = RequisionBll.GetRequisition(ReqNo, "DPT");
            grdRequisition.DataBind();
        }

        protected void ddlProductGroup_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                ddlProduct.Enabled = true;
                FillProductName();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void FillProductName()
        {
            try
            {
                if (Convert.ToInt32(ddlProductGroup.SelectedValue) > 0)
                {
                    ddlProduct.DataSource = productBll.GetProductListByGroup(Convert.ToInt32(ddlProductGroup.SelectedValue));
                    ddlProduct.DataValueField = "ProductId";
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

        protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string barCode = ddlProduct.SelectedValue.ToString();
                var result = productBll.GetProductById(Convert.ToInt32(ddlProduct.SelectedValue));
                if (result.Count > 0)
                {
                    var objProduct = result.First();
                    txtBrand.Text = objProduct.Brand;
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        //protected void ddlProduct_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    string barCode = ddlProduct.SelectedValue.ToString();
        //    DataTable dt = ic.GetProductInforByBarCode(barCode);
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        txtBrand.Text = dr["Brand"].ToString();
        //        //txtBalanceQty.Text = dr["BalanceQuanity"].ToString();
        //        //txtUnit.Text = dr["UnitName"].ToString();
        //    }
        //}

        protected void txtEID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtEID.Text.Trim() != "")
                {
                    DataTable dt = ic.FindEmployee(txtEID.Text.Trim());
                    foreach (DataRow dr in dt.Rows)
                    {
                        ddlDepartment.SelectedValue = dr["DPT_CODE"].ToString();
                        LoadEmployeeList(dr["DPT_CODE"].ToString());
                        ddlEmployee.SelectedValue = txtEID.Text.Trim();
                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        protected void grdRequisition_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "dlt")
                {
                    ic.DeleteRequisitionById(id);
                    LoadRequisitions(txtRequisitionNo.Text);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEID.Text = ddlEmployee.SelectedValue.ToString();
        }
    }
}