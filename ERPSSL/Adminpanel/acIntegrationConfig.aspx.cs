using ERPSSL.Adminpanel.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Adminpanel
{
    public partial class acIntegrationConfig : System.Web.UI.Page
    {
        Configuration_BLL objCofg = new Configuration_BLL();
        string ModuleType = string.Empty;
        string VoucherType = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetAc_Configuration(string ModuleType, string VoucherType)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objCofg.GetAc_Configuration(OCODE, ModuleType, VoucherType).ToList();
                if (row.Count > 0)
                {
                    dgGridList.DataSource = row;
                    dgGridList.DataBind();
                }
                else
                {
                    dgGridList.DataSource = null;
                    dgGridList.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void dgGridList_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                Label Id = (Label)dgGridList.Rows[e.RowIndex].FindControl("lblID");
                int Id_ = Convert.ToInt16(Id.Text);

                Label lblItem = (Label)dgGridList.Rows[e.RowIndex].FindControl("lblItemName");
                string ItemName = Convert.ToString(lblItem.Text);

                HiddenField hdnId = new HiddenField();
                hdnId = (HiddenField)dgGridList.Rows[e.RowIndex].FindControl("hdnId");
                string ItemCode = Convert.ToString(hdnId.Value);

                DropDownList cmbParticulars = (DropDownList)dgGridList.Rows[e.RowIndex].FindControl("cmbParticulars");
                string LedgerCode = Convert.ToString(cmbParticulars.SelectedValue);
                string LedgerName = Convert.ToString(cmbParticulars.SelectedItem.Text);

                Label ModuleId = (Label)dgGridList.Rows[e.RowIndex].FindControl("lblModuleId");
                string ModuleId_ = Convert.ToString(ModuleId.Text);

                Label ModuleName = (Label)dgGridList.Rows[e.RowIndex].FindControl("lblModuleName");
                string ModuleName_ = Convert.ToString(ModuleName.Text);

                Label TransactionNature = (Label)dgGridList.Rows[e.RowIndex].FindControl("lblTransactionNature");
                string TransactionNature_ = Convert.ToString(TransactionNature.Text);

                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                string Company_Code = "CMP201506071";
                string ModuleType = Session["ModuleType"].ToString();

                int result = objCofg.GetAc_UpdateConfiguration(Id_, OCode, Company_Code, ItemCode, ItemName, LedgerCode, LedgerName, ModuleId_, ModuleName_, TransactionNature_, ModuleType);

                dgGridList.EditIndex = -1;
                this.GetAc_Configuration(Session["ModuleType"].ToString(), Session["VoucherType"].ToString());
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void dgGridList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {

                dgGridList.EditIndex = e.NewEditIndex;
                this.GetAc_Configuration(Session["ModuleType"].ToString(), Session["VoucherType"].ToString());

                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string Company_Code = "CMP201506071";

                GridViewRow row = dgGridList.Rows[e.NewEditIndex];
                DropDownList ddl = ((DropDownList)(row.Cells[3].FindControl("cmbParticulars")));
                DropDownList ddl_1 = ((DropDownList)(row.Cells[3].FindControl("cmbItem")));

                var dt = objCofg.GetAc_Configuration_Ledger(OCODE, Company_Code).ToList();
                ddl.DataSource = dt;
                ddl.DataValueField = "Ledger_Code";
                ddl.DataTextField = "Ledger_Name";
                ddl.DataBind();


                //var dt_Item = objCofg.GetAc_Configuration_Item(OCODE, Session["ModuleType"].ToString(), Session["VoucherType"].ToString()).ToList();
                //ddl_1.DataSource = dt_Item;
                //ddl_1.DataValueField = "Item_Code";
                //ddl_1.DataTextField = "Item_Name";
                //ddl_1.DataBind();

                //HiddenField hdnId = new HiddenField();
                //hdnId = (HiddenField)dgGridList.Rows[dgGridList.EditIndex].FindControl("hdnId");
                //ddl.SelectedItem.Value = hdnId.Value;
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void dgGridList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgGridList.EditIndex = -1;
            this.GetAc_Configuration(Session["ModuleType"].ToString(), Session["VoucherType"].ToString());
        }

        protected void dgGridList_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void dgGridList_RowCommand(object sender, GridViewCommandEventArgs e)
        {

        }

        protected void dgGridList_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }

        protected void ddlModule_SelectedIndexChanged(object sender, EventArgs e)
        {
            ModuleType = ddlModule.SelectedItem.Text;

            Session["ModuleType"] = null;
            Session["ModuleType"] = ddlModule.SelectedItem.Text;

            if (ModuleType == "Sales")
            {
                VoucherType = "RECEIPT";
                Session["VoucherType"] = null;
                Session["VoucherType"] = "RECEIPT";
            }
            else
            {
                VoucherType = "PAYMENT";
                Session["VoucherType"] = null;
                Session["VoucherType"] = "PAYMENT";
            }

            GetAc_Configuration(ModuleType, VoucherType);

        }

        protected void dgGridList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgGridList.PageIndex = e.NewPageIndex;
            
            ModuleType = ddlModule.SelectedItem.Text;

            Session["ModuleType"] = null;
            Session["ModuleType"] = ddlModule.SelectedItem.Text;

            if (ModuleType == "Sales")
            {
                VoucherType = "RECEIPT";
                Session["VoucherType"] = null;
                Session["VoucherType"] = "RECEIPT";
            }
            else
            {
                VoucherType = "PAYMENT";
                Session["VoucherType"] = null;
                Session["VoucherType"] = "PAYMENT";
            }

            GetAc_Configuration(ModuleType, VoucherType);
        }


    }
}