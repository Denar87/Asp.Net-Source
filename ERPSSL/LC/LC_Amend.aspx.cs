using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.LC
{
    public partial class LC_Amend : System.Web.UI.Page
    {
        MasterLCBLL _masterlcBLL = new MasterLCBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {                    
                    LoadOfficeList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchLCNo(string prefixText, int count)
        {
            using (var _context = new ERPSSL_LCEntities())
            {
                var AllLC = from lcN in _context.LC_MasterLC
                            where ((lcN.LCNo.Contains(prefixText)))
                            select lcN;
                List<String> LCList = new List<String>();
                foreach (var LC_No in AllLC)
                {
                    LCList.Add(LC_No.LCNo);
                }
                return LCList;
            }
        }

        private void LoadOfficeList()
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                // var row = _masterlcBLL.GetAllOffice(OCode).ToList();
                var row = _masterlcBLL.GetAllSubCompany(OCode).ToList();
                if (row.Count > 0)
                {
                    ddlSubCompany.DataSource = row.ToList();
                    ddlSubCompany.DataTextField = "SubCompanyName";
                    ddlSubCompany.DataValueField = "SubCompany_Id";
                    ddlSubCompany.DataBind();
                    ddlSubCompany.Items.Insert(0, new ListItem("---Select One---", "0"));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        //private void LoadOfficeList()
        //{
        //    try
        //    {
        //        string OCode = ((SessionUser)Session["SessionUser"]).OCode;
        //        var row = _masterlcBLL.GetAllOffice(OCode).ToList();
        //        if (row.Count > 0)
        //        {
        //            ddlOffice.DataSource = row.ToList();
        //            ddlOffice.DataTextField = "OfficeName";
        //            ddlOffice.DataValueField = "OfficeID";
        //            ddlOffice.DataBind();
        //            ddlOffice.Items.Insert(0, new ListItem("---Select One---", "0"));
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}

        private void FillLCNoandOEntry()
        {
            BuyerBLL _BuyerBll = new BuyerBLL();
            string BuyerType = ddlBuyerType.SelectedValue.ToString();
            List<Com_Buyer_Setup> _buyerlist = _BuyerBll.GetBuyerByType(BuyerType);

            if (_buyerlist.Count > 0)
            {
                ddlBuyerName.DataSource = _buyerlist.ToList();
                ddlBuyerName.DataTextField = "Buyer_Name";
                ddlBuyerName.DataValueField = "Buyer_ID";
                ddlBuyerName.DataBind();
                ddlBuyerName.Items.Insert(0, new ListItem("---Select One---"));
            }
        }

        protected void txtFillAotuLCNo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                ShowLCGrid();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ShowLCGrid()
        {
            try
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                string LcNo = txtFillAotuLCNo.Text.Trim();
                List<LC_MasterLC> lcload = _masterlcBLL.GetALLLCByLCNo(LcNo, OCode);
                if (lcload.Count > 0)
                {
                    grdMasterLC.DataSource = lcload;
                    grdMasterLC.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void imgButtonEidt_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

                Label lblID = (Label)grdMasterLC.Rows[row.RowIndex].FindControl("lblID");
                int LcId = Convert.ToInt16(lblID.Text);
                LC_MasterLC _MSLc = _masterlcBLL.GetLcLById(LcId);
                if (_MSLc != null)
                {
                    HidLcNo.Value = _MSLc.MlcID.ToString();
                    ddlSubCompany.SelectedValue = _MSLc.SubCompany_Id.ToString();
                    txtLcNo.Text = _MSLc.LCNo;
                    txtDateofIssue.Text = _MSLc.DateofIssue.ToString();
                    txtDateofExpiry.Text = _MSLc.DateofExpiry.ToString();
                    txtIssueBank.Text = _MSLc.LC_Issue_Bank;
                    ddlBuyerType.SelectedValue = _MSLc.BuyerType.ToString();
                    FillLCNoandOEntry();
                    ddlBuyerName.SelectedValue = _MSLc.Buyer_ID.ToString();
                    txtSeason.Text = _MSLc.Season;
                    txtQty.Text = _MSLc.Qty.ToString();
                    txtUSDV.Text = _MSLc.LC_USDValu.ToString();
                    txtBDTV.Text = _MSLc.LC_BDTValu.ToString();
                    txtTotalLCValueUSD.Text = _MSLc.TotalLC_ValueUSD.ToString();
                    txtTotalLCValueBDT.Text = _MSLc.TotalLC_ValueBDT.ToString();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void txtLCAmend_USDValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double USD_LCValue = Convert.ToDouble(txtTotalLCValueUSD.Text);
                double USD_AmendValue = Convert.ToDouble(txtLCAmend_USDValue.Text);

                double TotalAmendValueUS = USD_LCValue + USD_AmendValue;

                txtTotalAmend_USDValue.Text = TotalAmendValueUS.ToString();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void txtLCAmend_BDTValue_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double BDT_LCValue = Convert.ToDouble(txtTotalLCValueBDT.Text);
                double BDT_AmendValue = Convert.ToDouble(txtLCAmend_BDTValue.Text);

                double TotalAmendValueBD = BDT_LCValue + BDT_AmendValue;

                txtTotalAmend_BDTValue.Text = TotalAmendValueBD.ToString();
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                LC_MasterLC _objLCmaster = new LC_MasterLC();
                
                if (txtLCAmendDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Date')", true);
                    return;
                }
                _objLCmaster.LC_Amend_Date = Convert.ToDateTime(txtLCAmendDate.Text);
                _objLCmaster.DateofExpiry = Convert.ToDateTime(txtDateofExpiry.Text);
                _objLCmaster.TotalLC_ValueUSD = Convert.ToDecimal(txtTotalAmend_USDValue.Text);
                _objLCmaster.TotalLC_ValueBDT = Convert.ToDecimal(txtTotalAmend_BDTValue.Text);
                _objLCmaster.LC_Amend_USDValue = Convert.ToDouble(txtLCAmend_USDValue.Text);
                _objLCmaster.LC_Amend_BDTValue = Convert.ToDouble(txtLCAmend_BDTValue.Text);
                _objLCmaster.LC_Total_USDValue = Convert.ToDouble(txtTotalAmend_USDValue.Text);
                _objLCmaster.LC_Total_BDTValue = Convert.ToDouble(txtTotalAmend_BDTValue.Text);

                _objLCmaster.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                _objLCmaster.Edit_Date = DateTime.Now;

                SaveAmendLog();

                //int resultsLog = _masterlcBLL.SaveAmendLog(_LC_LCContract_Log);

                _objLCmaster.MlcID = Convert.ToInt16(HidLcNo.Value);
                int results = _masterlcBLL.UpdateMasterAmendLc(_objLCmaster);

                if (results == 1)
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
                }
                ClearUI();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void SaveAmendLog()
        {
            try
            {
                LC_LCContract_Log _LC_LCContract_Log = new LC_LCContract_Log();
                if (txtLCAmendDate.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Date')", true);
                    return;
                }

                _LC_LCContract_Log.LCNo =txtLcNo.Text;
                _LC_LCContract_Log.LC_Amend_Date = Convert.ToDateTime(txtLCAmendDate.Text);
                _LC_LCContract_Log.DateofExpiry = Convert.ToDateTime(txtDateofExpiry.Text);
                _LC_LCContract_Log.TotalLC_ValueUSD = Convert.ToDecimal(txtTotalAmend_USDValue.Text);
                _LC_LCContract_Log.TotalLC_ValueBDT = Convert.ToDecimal(txtTotalAmend_BDTValue.Text);
                _LC_LCContract_Log.LC_Amend_USDValue = Convert.ToDouble(txtLCAmend_USDValue.Text);
                _LC_LCContract_Log.LC_Amend_BDTValue = Convert.ToDouble(txtLCAmend_BDTValue.Text);
                _LC_LCContract_Log.LC_Total_USDValue = Convert.ToDouble(txtTotalAmend_USDValue.Text);
                _LC_LCContract_Log.LC_Total_BDTValue = Convert.ToDouble(txtTotalAmend_BDTValue.Text);

                _LC_LCContract_Log.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                _LC_LCContract_Log.Edit_Date = DateTime.Now;
                _LC_LCContract_Log.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                int resultsLog = _masterlcBLL.SaveAmendLog(_LC_LCContract_Log);
            }
            catch (Exception ex)
            {
                 throw ex;
            }
        }

        private void ClearUI()
        {
            txtLcNo.Text = "";
            txtDateofIssue.Text = "";
            txtDateofExpiry.Text = "";
            ddlSubCompany.ClearSelection();
            ddlBuyerType.ClearSelection();
            ddlBuyerName.ClearSelection();
            txtSeason.Text = "";
            txtIssueBank.Text = "";
            txtQty.Text = "";
            txtTotalAmend_BDTValue.Text = "";
            txtTotalAmend_USDValue.Text = "";
            txtLCAmendDate.Text = "";
            txtLCAmend_BDTValue.Text = "";
            txtLCAmend_USDValue.Text = "";
            txtUSDV.Text = "";
            txtBDTV.Text = "";
            txtTotalLCValueUSD.Text = "";
            txtTotalLCValueBDT.Text = "";
            
        }
    }
}