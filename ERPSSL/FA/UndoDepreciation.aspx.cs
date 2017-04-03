using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.FA.BLL;

namespace ERPSSL.FA
{
    public partial class UndoDepreciation : System.Web.UI.Page
    {
        Depreciation_BLL objDepreciationBll = new Depreciation_BLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            btnErase.Visible = false;
            FillLastDepreciationDate();
            if (IsPostBack)
            {
                txtFromDate.Text = DateTime.Today.ToShortDateString();
                //FillLastDepreciationDate();
                //btnErase.Visible = false;
            }
        }

        private void FillLastDepreciationDate()
        {
            try
            {
                string oCode = ((SessionUser)base.Session["SessionUser"]).OCode.ToString();
                //string oCode = "8989";
                lblLastDepreciationDate.Text = objDepreciationBll.GetLastDepreciationDate(oCode);
            }
            catch
            {
            }
        }      
       

        protected void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDepreciationDataToDelete(DateTime.Parse(txtFromDate.Text));
            }
            catch
            {
            }
        }

        private void LoadDepreciationDataToDelete(DateTime FromDate)
        {
            grdDepreciationData.DataSource = objDepreciationBll.GetDepreciationDataToDelete(FromDate);
            grdDepreciationData.DataBind();
            btnErase.Visible = true;
        }

        protected void btnErase_Click(object sender, EventArgs e)
        {
            try
            {
                if (objDepreciationBll.EraseDepreciation(DateTime.Parse(txtFromDate.Text)))
                {
                    lblDepreciationStatus.Text = "<font color='green'>Depreciation data has been erased successfully</font>";
                }
                else
                {
                    lblDepreciationStatus.Text = "<font color='red'>Error in deleting depreciation data.</font>";
                }
            }
            catch
            {
            }
        }

        protected void grdUndoDepreciation_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {

                grdDepreciationData.PageIndex = e.NewPageIndex;
                //LoadUnits();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}