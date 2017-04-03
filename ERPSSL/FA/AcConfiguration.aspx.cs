using ERPSSL.FA.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.FA
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
                    GetAc_SalesSummary();
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        private void GetAc_SalesSummary()
        {
            try
            {
                string SaleType = "";
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = objCofg.GetAc_AssetSummary(OCODE, SaleType).ToList();
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
                    string EditUser = ((SessionUser)Session["SessionUser"]).UserId.ToString();
                    string AssetCode = Convert.ToString(grow.Cells[0].Text);
                    Double ItemTotal = Convert.ToDouble(grow.Cells[1].Text);
                    result = objCofg.Sync_AssetSummary(OCODE, EditUser, AssetCode, ItemTotal);
                }
            }
            if (result == 1)
            {
                lblMessage.Text = "Post Successfully";
                GetAc_SalesSummary();
            }
            else
            {
                lblMessage.Text = "Post UnSuccessfull!";
            }
        }


    }
}
