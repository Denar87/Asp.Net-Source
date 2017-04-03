using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.BLL;
using System.Data;
using System.Collections;
using ERPSSL.Procurement.BLL;

namespace ERPSSL.INV
{
    public partial class IssueByQuotation : System.Web.UI.Page
    {
        IChallanBLL aChallanBll = new IChallanBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadRequisitions("");
                FillRequisitionCombo();
                //FillDepartment();
                txtTransferDate.Text = DateTime.Today.ToShortDateString();
            }
        }

        public void LoadRequisitions(string ReqNo)
        {
            grdRequisition.DataSource = RequisionBll.GetAllAcceptedRequisitions(ReqNo);//.GetRequisitionToApprove(ReqNo, "Head");
            grdRequisition.DataBind();

        }

        protected void grdRequisition_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            GridViewRow row = grdRequisition.Rows[grdRequisition.SelectedIndex];
            string Id = row.Cells[1].Text;

            LoadForm(Id);
        }

        private void FillRequisitionCombo()
        {
            ddlRequisition.DataSource = RequisionBll.GetUniqueRequisitionsToDeliver();
            ddlRequisition.DataValueField = "ReqNo";
            ddlRequisition.DataTextField = "ReqNo";
            ddlRequisition.DataBind();
            ddlRequisition.Items.Insert(0, new ListItem("Select One", "0"));

        }

        private void LoadForm(string Id)
        {
            DataTable dt = new DataTable();
            try
            {

                dt = RequisionBll.GetSelectedProductToDeliver(Id);
                foreach (DataRow dr in dt.Rows)
                {
                    ddlRequisition.SelectedValue = dr["ReqNo"].ToString(); ;
                    txtDepartment.Text = dr["DPT_NAME"].ToString();
                    hdnEID.Value = dr["EID"].ToString();
                    txtBalQty.Text = dr["BalQty"].ToString();
                    txtDelQty.Text = dr["Qty"].ToString();
                    txtProductName.Text = dr["ProductName"].ToString();
                    txtUnit.Text = dr["UnitName"].ToString();
                    hdnBarCode.Value = dr["BarCode"].ToString();
                    txtChalanNo.Text = aChallanBll.GetNewChalanNo(dr["DPT_NAME"].ToString(), DateTime.Parse(txtTransferDate.Text), "DPT");
                }

            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        //public void FillDepartment()
        //{

        //    ddlDepartment.DataSource = ic.GetDepartmentList();
        //    ddlDepartment.DataValueField = "DPT_CODE";
        //    ddlDepartment.DataTextField = "DPT_NAME";
        //    ddlDepartment.DataBind();
        //    ddlDepartment.Items.Insert(0, new ListItem("Select One", "0"));

        //}
        protected void ddlRequisition_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadRequisitions(ddlRequisition.SelectedValue);

        }

        protected void txtTransferDate_TextChanged(object sender, EventArgs e)
        {
            if (txtTransferDate.Text != string.Empty && txtDepartment.Text != "0")
            {
                string DeptCode = txtDepartment.Text.ToString();
                DateTime day = DateTime.Parse(txtTransferDate.Text);
                txtChalanNo.Text = aChallanBll.GetNewChalanNo(DeptCode, day, "DPT");
            }
        }
        protected void btnTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                string BarCode = hdnBarCode.Value.ToString();
                if (BarCode == string.Empty || txtBalQty.Text == string.Empty || txtDepartment.Text == "0" || txtDelQty.Text == "0")
                {
                   // lblMessage.Text = "<font color='red'>Sorry! Invalid data. Issue quantity cannot be zero or negetive. Please enter correct data</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Sorry! Invalid data. Issue quantity cannot be zero or negetive. Please enter correct data')", true);
                    return;
                }
                if (int.Parse(txtDelQty.Text) > int.Parse(txtBalQty.Text))
                {
                  //  lblMessage.Text = "<font color='red'>Sorry! There are not enough quantity of selected good to issue. Please purchase or issue with less quantity</font>";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Sorry! There are not enough quantity of selected good to issue. Please purchase or issue with less quantity')", true);
                    return;
                }

                try
                {
                    Hashtable ht = new Hashtable();
                    ht.Add("DeliveryType", "CenterToDepartment"); // Any company/store to its department/individual
                    ht.Add("BarCode", BarCode);
                    ht.Add("ChallanNo", txtChalanNo.Text);
                    ht.Add("DeliveryQty", txtDelQty.Text);
                    ht.Add("TransferDate", txtTransferDate.Text);
                    ht.Add("DPT_CODE", txtDepartment.Text.ToString());
                    ht.Add("EID", hdnEID.Value);
                    ht.Add("CurrentCompanyCode", "0");
                    ht.Add("OldCompanyCode", ((SessionUser)Session["SessionUser"]).OCode.ToString());
                    ht.Add("OCode", ((SessionUser)Session["SessionUser"]).OCode.ToString());
                    DataTable dt = aChallanBll.DeliverProductByRequisition(ht);
                    aChallanBll.UpdateRequisition(ddlRequisition.SelectedValue, BarCode, int.Parse(txtDelQty.Text));
                    LoadRequisitions("");
                   // lblMessage.Text = "GIN issued successfully!";
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('GIN issued successfully!')", true);

                    // Bind grid
                    // grdTransfer.DataSource = dt;
                    // grdTransfer.DataBind();
                    ClearForm();
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
            txtProductName.Text = string.Empty;
            txtDelQty.Text = string.Empty;
            txtBalQty.Text = string.Empty;
            txtUnit.Text = string.Empty;
            //txtDepartment.Text = string.Empty;
            //txtChalanNo.Text = string.Empty;
        }

    }
}