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
    public partial class IssueGeneral : System.Web.UI.Page
    {
        ProductBLL productBll = new ProductBLL();
        public static DataTable stCompany = new DataTable();
        IChallanBLL iChallanBll = new IChallanBLL();
        public static int SerialNo = 0;
        BuyCentralBLL buyCentralBll = new BuyCentralBLL();
        public static string CentralCode = "";
        CompanyBLL companyBll = new CompanyBLL();
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
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
                    FillOldChalan();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        //private void GetAllStore()
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
            ddlItemGroup.Items.Insert(0, new ListItem("Select Item Group", "0"));

        }

        private void FillProductName()
        {
            try
            {
                if (Convert.ToInt32(ddlItemGroup.SelectedValue) > 0)
                {
                    ddlItemName.DataSource = iChallanBll.GetProductListWithCodeByGroup((ddlItemGroup.SelectedValue));
                    ddlItemName.DataValueField = "BarCode";
                    ddlItemName.DataTextField = "ProductName";
                    ddlItemName.DataBind();
                    ddlItemName.Items.Insert(0, new ListItem("Select Item", "0"));
                }
                else
                {
                    //lblMessage.Text = "<font color='red'>No Item is available of this group!</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Item is available of this group!')", true);
                    return;
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
        protected void ddlChalanNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string challanNo = ddlChalanNo.SelectedValue.ToString();
            FillFormForOldChallan(challanNo);
            BindPurchaseGrid(challanNo);
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
                    ddlDepartment.SelectedValue = dr["DPT_CODE"].ToString();
                    string DeptCode = ddlDepartment.SelectedValue.ToString();
                    LoadEmployeeList(DeptCode);
                    ddlReciver.SelectedValue = dr["EID"].ToString();
                    txtEID.Text = ddlReciver.SelectedValue.ToString();
                    //txtCPU.Text = dr["CPU"].ToString();
                    //txtTotalCost.Text =dr["ChallanTotal"].ToString();

                }
                ddlItemGroup.SelectedValue = "0";
                ddlItemName.SelectedValue = "0";
                txtUnit.Text = string.Empty;
                txtBalanceQty.Text = string.Empty;
                //txtBrand.Text = string.Empty;
                hdnBrand.Value = "";
                //hdnStyle.Value = "";
                //txtStyleSize.Text = string.Empty;
                txtCPU.Text = "";
                txtTotalCost.Text = "";
                txtIssueQty.Text = string.Empty;
                txtBalanceQty.Text = string.Empty;
            }
            catch (Exception)
            {

                throw;
            }

        }
        private void FillOldChalan()
        {
            try
            {
                string Ocode = ((SessionUser)Session["SessionUser"]).OCode;
                //string Ocode = "8989";
                ddlChalanNo.DataSource = iChallanBll.GetOldUnPostedIChallanForCentrelToDpt(Ocode);
                ddlChalanNo.DataValueField = "ChallanNo";
                ddlChalanNo.DataTextField = "ChallanNo";
                ddlChalanNo.DataBind();
                ddlChalanNo.Items.Insert(0, new ListItem("Select Unposted GIN", "0"));
            }
            catch { }
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
            catch (Exception)
            {

                throw;
            }

        }

        protected void ddlDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string DeptCode = ddlDepartment.SelectedValue.ToString();
                LoadEmployeeList(DeptCode);
                txtChalanNo.Text = iChallanBll.GetNewChalanNoForCenterToDpt(DeptCode);
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
                DataTable dt = iChallanBll.GetProductInforByBarCode(barCode, OCode, "CENTRAL");
                //hdnBarCode.Value = ddlItemName.SelectedValue.ToString();
                foreach (DataRow dr in dt.Rows)
                {
                    //FillProductInfo();
                    txtUnit.Text = dr["UnitName"].ToString();
                    hdnBrand.Value = dr["Brand"].ToString();
                    hdnStyleSize.Value = dr["StyleSize"].ToString();
                    hdnProductID.Value = dr["ProductId"].ToString();
                    //txtStyleSize.Text = dr["StyleSize"].ToString();
                    txtBalanceQty.Text = dr["BalanceQuanity"].ToString();
                    txtCPU.Text = dr["CPU"].ToString();
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
                txtTotalCost.Text = (decimal.Parse(txtIssueQty.Text) * decimal.Parse(txtCPU.Text)).ToString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }

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

        protected void txtCPU_TextChanged(object sender, EventArgs e)
        {
            //try
            //{
            //    if (txtIssueQty.Text != string.Empty && txtCPU.Text != string.Empty)
            //    {
            //        double qty = Convert.ToDouble(txtIssueQty.Text.Trim());
            //        decimal cpu = Convert.ToDecimal(txtCPU.Text.Trim());
            //        decimal total = (decimal)qty * cpu;
            //        txtTotalCost.Text = Convert.ToString(total);

            //    }
            //    //txtTotalCost.Text = (int.Parse(txtCPU.Text) * int.Parse(txtReceiveQty.Text)).ToString();
            //}
            //catch { }
        }


        private void ClearForm()
        {
            ddlItemGroup.ClearSelection();
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
            try
            {
                string BarCode = ddlItemName.SelectedValue;
                Guid userId = ((SessionUser)Session["SessionUser"]).UserId;
                if (BtnAdd.Text == "Add")
                {
                    //string BarCode = hdnBarCode.Value.ToString();

                    if (BarCode == string.Empty || txtBalanceQty.Text == string.Empty || ddlDepartment.SelectedValue == "0" || txtIssueQty.Text == "0")
                    {
                        //  lblMessage.Text = "<font color='red'>Sorry! Invalid data. Issue quantity cannot be zero or negetive. Please enter correct data</font>";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Sorry! Invalid data. Issue quantity cannot be zero or negetive. Please enter correct data')", true);
                        return;
                    }
                    if (double.Parse(txtIssueQty.Text) > double.Parse(txtBalanceQty.Text))
                    {
                        //lblMessage.Text = "<font color='red'>Sorry! There are not enough quantity of selected good to issue. Please purchase or issue with less quantity</font>";
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Sorry! There are not enough quantity of selected good to issue. Please issue with less quantity')", true);
                        return;
                    }

                    var GetDataByIChallan_Tem = iChallanBll.GetDataByIChallan_Tem(txtChalanNo.Text, BarCode).ToList();
                    if (GetDataByIChallan_Tem.Count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Item Already Exist In The List')", true);
                        return;
                    }


                    try
                    {
                        //SerialNo = SerialNo + 1;
                        //purchase.Id = SerialNo;
                        Hashtable ht = new Hashtable();

                        ht.Add("ProductGroup", ddlItemGroup.SelectedValue);
                        ht.Add("BarCode", BarCode);
                        ht.Add("ProductId", hdnProductID.Value);
                        string pronductNameandBrand = ddlItemName.SelectedItem.ToString();
                        string[] values = pronductNameandBrand.Split(' ');
                        ht.Add("ProductName", values[0].ToString());
                        ht.Add("UnitName", txtUnit.Text);
                        ht.Add("Brand", hdnBrand.Value);
                        ht.Add("StyleSize", hdnStyleSize.Value);
                        ht.Add("ChallanNo", txtChalanNo.Text);
                        ht.Add("DeliveryQty", txtIssueQty.Text);
                        ht.Add("OrderNo", txtOrderNo.Text);
                        //ht.Add("TransferDate", txtDate.Text);
                        ht.Add("DPT_CODE", ddlDepartment.SelectedValue.ToString());
                        ht.Add("EID", ddlReciver.SelectedValue.ToString());
                        ht.Add("CPU", txtCPU.Text);
                        ht.Add("ChallanTotal", txtTotalCost.Text.ToString());
                        ht.Add("CurrentCompanyCode", "n/a");
                        ht.Add("OldCompanyCode", CentralCode);
                        ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode.ToString());
                        //ht.Add("OldCompanyCode", "8989");
                        //ht.Add("OCode", "8989");
                        DataTable dt = iChallanBll.DeliverProduct_Temp(ht);
                        grvIssue.DataSource = dt;
                        grvIssue.DataBind();
                        ClearForm();
                        // lblMessage.Text = "<font color='green'>Issue information has been added temporarily. Please post.</font>";
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
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Succesfully')", true);
                            BindPurchaseGrid(txtChalanNo.Text.Trim());
                            ClearForm();
                            BtnAdd.Text = "Add";
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

        private void ClearFullForm()
        {
            txtEID.Text = string.Empty;
            txtChalanNo.Text = string.Empty;
            txtDate.Text = DateTime.Today.ToShortDateString();
            ddlDepartment.ClearSelection();
            ddlReciver.ClearSelection();
            txtUnit.Text = string.Empty;
            txtOrderNo.Text = string.Empty;
            txtIssueQty.Text = string.Empty;
            grvIssue.DataSource = null;
            grvIssue.DataBind();
            lblTotalCost.Text = "";

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                //string BarCode = hdnBarCode.Value.ToString();
                Hashtable ht = new Hashtable();
                ht.Add("DeliveryType", "CenterToDepartment"); // Center to department/individual
                ht.Add("ChallanNo", txtChalanNo.Text);
                //ht.Add("BarCode", BarCode);
                //ht.Add("DeliveryQty", txtIssueQty.Text);
                ht.Add("TransferDate", Convert.ToDateTime(txtDate.Text));
                ht.Add("DPT_CODE", ddlDepartment.SelectedValue.ToString());
                ht.Add("EID", txtEID.Text);
                ht.Add("CurrentCompanyCode", "n/a");
                ht.Add("OldCompanyCode", CentralCode);
                ht.Add("OrderNo", txtOrderNo.Text);
                ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode.ToString());
                ht.Add("EditUser", ((SessionUser)Session["SessionUser"]).UserId.ToString());
                ht.Add("EditDate", DateTime.Now);
                // ht.Add("CPU",txtCPU.Text.Trim());
                // ht.Add("ChallanTotal",txtTotalCost.Text.Trim());
                //ht.Add("OCode", "8989");

                DataTable dt = iChallanBll.DeliverProduct(ht);
                if (dt.Rows.Count > 0)
                {
                    // print report here

                    //
                    //lblMessage.Text = "<font color='green'>GIN Issued successfully!</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('GIN issued successfully')", true);
                    ClearFullForm();
                }
                else
                {
                    ClearFullForm();
                    //lblMessage.Text = "<font color='red'>Error in GIN Issue. Please try again.</font>";
                    // lblMessage.Text = "<font color='green'>GIN Issued successfully!</font>";
                    //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('GIN issued successfully')", true);
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('GIN issue error!')", true);
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
            try
            {
                lblMessage.Text = "";
                int id = Convert.ToInt32(e.CommandArgument);
                if (e.CommandName == "dlt")
                {

                    iChallanBll.DeleteTempChalanById(id);
                    BindPurchaseGrid(txtChalanNo.Text.Trim());
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
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
        decimal sumFooterValue = 0;
        protected void grvIssue_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    string totalAmount = e.Row.Cells[9].Text;

                    decimal grandTotal = Convert.ToDecimal(totalAmount);
                    sumFooterValue += grandTotal;
                }
                lblTotalCost.Text = sumFooterValue.ToString();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void ddlReciver_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtEID.Text = ddlReciver.SelectedValue.ToString();
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