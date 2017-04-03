using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.FA.BLL;
using System.Data;

namespace ERPSSL.FA.Control
{
    public partial class ShortAssetInfo : System.Web.UI.UserControl
    {
        Revaluation_BLL RevaluationBll = new Revaluation_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void FillAssetInfo(string AssetCode)
        {
            DataTable dt = new DataTable();
            dt = RevaluationBll.GetAssetInforByAssetCode(AssetCode);
            if (dt.Rows.Count == 1)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lblAssetCode.Text = AssetCode;
                    lblAsset.Text = dr["CustomAssetName"].ToString();
                    lblGroup.Text = dr["GroupName"].ToString();
                    lblDepartment.Text = dr["DepartmentName"].ToString();
                    lblOffice.Text = dr["OfficeName"].ToString();
                    lblRegion.Text = dr["RegionName"].ToString();
                    lblUser.Text = dr["CustomUserName"].ToString();
                }

                // Int64 CurrentBalance = StockBll.GetCurrentBalanceByAssetCode(AssetCode);

                DataTable CurrentStatus = RevaluationBll.GetCurrentStatusByAssetCode(AssetCode);
                foreach (DataRow dr in CurrentStatus.Rows)
                {
                    lblACClosingBalance.Text = dr["XACClosingBalance"].ToString();
                    lblADClosingBalance.Text = dr["XADClosingBalance"].ToString();
                    lblRRClosingBalance.Text = dr["XRRClosingBalance"].ToString();
                    lblMethod.Text = dr["XACDepMethod"].ToString();

                    lblACClosingBalanceTax.Text = dr["TACClosingBalance"].ToString();
                    lblADClosingBalanceTax.Text = dr["TADClosingBalance"].ToString();
                    lblRRClosingBalanceTax.Text = dr["TRRClosingBalance"].ToString();
                    lblMethodTax.Text = dr["TACDepMethod"].ToString();

                }
                lblStatus.Text = "<font color='green'>Asset found</font>";
                lblStatus.CssClass = "ActionSuccess";
                if (RevaluationBll.IsDisposed(AssetCode))
                {
                    lblStatus.Text = "This asset has already been disposed.";
                    lblStatus.CssClass = "ActionError";

                }

            }
            else if (dt.Rows.Count == 0)
            {
                //ClearAssetInfo();
                lblStatus.Text = "Asset not found! Please try a valid Asset Code.";
                lblStatus.CssClass = "ActionError";
            }
        }

    }
}