using ERPSSL.POS.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.POS
{
    public partial class AcConfiguration : System.Web.UI.Page
    {
        Configuration_BLL objCofg = new Configuration_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (((SessionUser)Session["SessionUser"]).OCode != null)
            {
                if (!IsPostBack)
                {

                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void ddlSalestype_SelectedIndexChanged(object sender, EventArgs e)
        {
            string SaleType = ddlSalestype.SelectedItem.Text;
            GetAc_SalesSummary(SaleType);
        }

        private void GetAc_SalesSummary(string SaleType)
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                //string SaleType = "Food";

                var row = objCofg.GetAc_SalesSummary(OCODE, SaleType).ToList();
                if (row.Count > 0)
                {
                    dgListSales.DataSource = row;
                    dgListSales.DataBind();
                }
                else
                {
                    dgListSales.DataSource = null;
                    dgListSales.DataBind();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnSync_Click(object sender, EventArgs e)
        {
            int result = 0;

            foreach (GridViewRow grow in dgListSales.Rows)
            {
                CheckBox chkedRow = (CheckBox)grow.FindControl("chkbxEditItem_");
                if (chkedRow.Checked)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    string SaleType = ddlSalestype.SelectedItem.Text;
                    string VoucherDate = Convert.ToString(grow.Cells[0].Text);
                    string EditUser = Convert.ToString(grow.Cells[1].Text);
                    Double ItemTotal = Convert.ToDouble(grow.Cells[3].Text);
                    result = objCofg.Sync_SalesSummary(OCODE, SaleType, VoucherDate, EditUser, ItemTotal);
                }
            }
            if (result == 1)
            {
                lblMessage.Text = "Post Successfully";
                GetAc_SalesSummary(ddlSalestype.SelectedItem.Text);
            }
            else
            {
                lblMessage.Text = "Post UnSuccessfull!";
            }
        }


    }
}