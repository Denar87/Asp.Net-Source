using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.HRM
{
    public partial class PFContribution : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetPFContributionList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetPFContributionList()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;

            PFContributionBLL _pfcontributionbll = new PFContributionBLL();
            List<HRM_PFConfiguration> pfcontributones = _pfcontributionbll.GetPFContributionList(ocode);
            if (pfcontributones.Count > 0)
            {
                grdviewPFContribution.DataSource = pfcontributones;
                grdviewPFContribution.DataBind();
            }
        }

        protected void btnPFContributonSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                HRM_PFConfiguration _hrmPfcontrinbution = new HRM_PFConfiguration();
                PFContributionBLL _pfcontributionbll = new PFContributionBLL();
                _hrmPfcontrinbution.OwnerContribution = Convert.ToDouble(txtbcPfEmployeeContribution.Text);
                _hrmPfcontrinbution.PFEmployee = Convert.ToDouble(txtOwnerContribution.Text);
                _hrmPfcontrinbution.EDIT_USER = ((SessionUser)Session["SessionUser"]).UserId;
                _hrmPfcontrinbution.EDIT_DATE = DateTime.Now;
                _hrmPfcontrinbution.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                if (btnLeaveTypeSubmit.Text == "Submit")
                {
                    int result = _pfcontributionbll.SavePFContribution(_hrmPfcontrinbution);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                    }
                }
                else
                {
                    _hrmPfcontrinbution.PFContributionID = Convert.ToInt16(hidPFID.Value);
                    int result = _pfcontributionbll.UpdatePFContribution(_hrmPfcontrinbution);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Update Successfully')", true);
                    }

                }
                GetPFContributionList();
                ClearController();
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }

        private void ClearController()
        {
            txtOwnerContribution.Text = "";
            txtbcPfEmployeeContribution.Text = "";
            btnLeaveTypeSubmit.Text = "Submit";
        }
        protected void imgbtnPFContributionEdit_Click(object sender, EventArgs e)
        {
            PFContributionBLL _pfcontributionbll = new PFContributionBLL();
            HRM_PFConfiguration _txtPfConfiguration = new HRM_PFConfiguration();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string txtbcContributionID = "";
                Label lblTaxType = (Label)grdviewPFContribution.Rows[row.RowIndex].FindControl("lblPfContribution");
                if (lblTaxType != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    txtbcContributionID = lblTaxType.Text;
                    _txtPfConfiguration = _pfcontributionbll.getPFContributionByIDandocode(txtbcContributionID, OCODE);

                    if (_txtPfConfiguration != null)
                    {
                        txtbcPfEmployeeContribution.Text = _txtPfConfiguration.PFEmployee.ToString();
                        txtOwnerContribution.Text = _txtPfConfiguration.OwnerContribution.ToString();
                        hidPFID.Value = _txtPfConfiguration.PFContributionID.ToString();
                        btnLeaveTypeSubmit.Text = "Update";

                    }
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('" + ex.Message + "')", true);
            }
        }
    }
}