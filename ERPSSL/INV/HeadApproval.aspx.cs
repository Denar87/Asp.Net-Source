using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.BLL;
using ERPSSL.Procurement.BLL;

namespace ERPSSL.INV
{
    public partial class HeadApproval : System.Web.UI.Page
    {
        IChallanBLL aChallanBll = new IChallanBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //FillRequisitionCombo();
                LoadRequisitions("");
            }
        }

        private void LoadRequisitions(string ReqNo)
        {
            grdRequisition.DataSource = RequisionBll.GetRequisitionToApprove(ReqNo, "Head");
            grdRequisition.DataBind();
        }

        protected void grdRequisition_SelectedIndexChanged(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                lblMessage.Text = "";
                DataTable dt = new DataTable();

                int Id = Convert.ToInt32(e.CommandArgument.ToString());
                if (e.CommandName == "select")
                {
                    dt = aChallanBll.GetRequisitionTSelecte(Id, "Head");
                    hdnId.Value = dt.Rows[0][1].ToString();
                    txtReqNo.Text = dt.Rows[0][3].ToString();
                    txtProduct.Text = dt.Rows[0][5].ToString();
                    txtBrand.Text = dt.Rows[0][6].ToString();
                    txtUnit.Text = dt.Rows[0][13].ToString();
                    txtRequestQTY.Text = dt.Rows[0][12].ToString();
                    txtApproveQty.Text = dt.Rows[0][12].ToString();
                    txtBalQTY.Text = dt.Rows[0][15].ToString();
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (int.Parse(txtApproveQty.Text) <= 0)
                {
                  //  lblMessage.Text = "<font color='red'>Sorry! Invalid data. Approve quantity cannot be zero or negetive. Please enter correct data</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Sorry! Invalid data. Approve quantity cannot be zero or negetive. Please enter correct data')", true);
                    return;
                }
                int Id = int.Parse(hdnId.Value);
                int ApproveQty = int.Parse(txtApproveQty.Text);
                if (RequisionBll.Approve(Id, ApproveQty, "Head"))
                {
                   // lblMessage.Text = "<font color='green'>" + txtProduct.Text + " with quantity " + txtApproveQty.Text + " has been approved!</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Product has been approved')", true);
                    txtReqNo.Text = "";
                    LoadRequisitions(txtReqNo.Text);
                    ClearForm();
                }
                else
                {
                    // not success
                    lblMessage.Text = "<font color='red'>Error in approval! Please try again</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Error in approval! Please try again')", true);
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearForm()
        {
            txtProduct.Text = "";
            txtBrand.Text =  "";
            txtUnit.Text =  "";
            txtRequestQTY.Text=
            txtApproveQty.Text= "";
            txtBalQTY.Text = "";
        }

    }
}