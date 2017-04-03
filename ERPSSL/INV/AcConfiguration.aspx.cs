using ERPSSL.INV.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.INV
{
    public partial class AcConfiguration : System.Web.UI.Page
    {
        Configuration_BLL objCofg = new Configuration_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((SessionUser)Session["SessionUser"]).OCode != null)
            {
                if (!IsPostBack)
                    GetAc_Configuration();
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        private void GetAc_Configuration()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string ModuleType = "Inventory";
                string VoucherType = "PAYMENT";

                var row = objCofg.GetAc_Configuration(OCODE, ModuleType, VoucherType).ToList();
                if (row.Count > 0)
                {
                    dgGridList.DataSource = row;
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

                DropDownList cmbParticulars = (DropDownList)dgGridList.Rows[e.RowIndex].FindControl("cmbParticulars");
                string LedgerCode = Convert.ToString(cmbParticulars.SelectedValue);
                string LedgerName = Convert.ToString(cmbParticulars.SelectedItem.Text);

                Label ModuleId = (Label)dgGridList.Rows[e.RowIndex].FindControl("lblModuleId");
                string ModuleId_ = Convert.ToString(ModuleId.Text);

                Label ModuleName = (Label)dgGridList.Rows[e.RowIndex].FindControl("lblModuleName");
                string ModuleName_ = Convert.ToString(ModuleName.Text);

                DropDownList TransactionNature = (DropDownList)dgGridList.Rows[e.RowIndex].FindControl("cmbTransactionNature");
                string TransactionNature_ = Convert.ToString(TransactionNature.SelectedItem.Text);

                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                string Company_Code = "CMP201507251";

                int result = objCofg.GetAc_UpdateConfiguration(Id_,OCode, Company_Code, LedgerCode, LedgerName, ModuleId_, ModuleName_, TransactionNature_);

                dgGridList.EditIndex = -1;
                this.GetAc_Configuration();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void dgGridList_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {

                dgGridList.EditIndex = e.NewEditIndex;
                this.GetAc_Configuration();

                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string Company_Code = "CMP201507251";

                GridViewRow row = dgGridList.Rows[e.NewEditIndex];
                DropDownList ddl = ((DropDownList)(row.Cells[3].FindControl("cmbParticulars")));

                var dt = objCofg.GetAc_Configuration_Ledger(OCODE, Company_Code).ToList();
                ddl.DataSource = dt;
                ddl.DataValueField = "Ledger_Code";
                ddl.DataTextField = "Ledger_Name";
                ddl.DataBind();

                //HiddenField hdnId = new HiddenField();
                //hdnId = (HiddenField)dgGridList.Rows[dgGridList.EditIndex].FindControl("hdnId");
                //ddl.SelectedItem.Value = hdnId.Value;
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void dgGridList_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            dgGridList.EditIndex = -1;
            this.GetAc_Configuration();
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
    }
}