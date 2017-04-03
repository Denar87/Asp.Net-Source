using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.INV.DAL;
using ERPSSL.INV.BLL;
using ERPSSL.LC.DAL.Repository;
using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL;

namespace ERPSSL.LC
{
    public partial class ContactLC : System.Web.UI.Page
    {
        MasterLCBLL _masterlcBLL = new MasterLCBLL();
        OrderSheetBLL _OrderSheetBLL = new OrderSheetBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    ClearAlTemp();
                    LoadOfficeList();
                    ShowMasterLC();
                    LoadSeason();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void ShowMasterLC()
        {
            try
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<LC_MasterLC> lcload = _masterlcBLL.GetALLLCByContact(OCode);
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

        private void LoadOfficeList()
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                //var row = _masterlcBLL.GetAllOffice(OCode).ToList();
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (txtLcNo.Text == "")
            {
                // ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Create LC No. first!')", true);
                //return;
            }
            try
            {

                int SesonId = 0;
                //if (chkSeason.Checked == true)
                //{
                //    LC_Season _LC_Season = new LC_Season();
                //    _LC_Season.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                //    _LC_Season.CreateDate = DateTime.Now;
                //    _LC_Season.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                //    int result = _masterlcBLL.SaveLC_Season(_LC_Season);
                //    SesonId = result;
                //}

                if (ddlSubCompany.SelectedItem.Text != "---Select One---")
                {
                    LC_MasterLC _objLCmaster = new LC_MasterLC();
                    _objLCmaster.SubCompany_Id = Convert.ToInt32(ddlSubCompany.SelectedValue);
                    _objLCmaster.SubCompanyName = ddlSubCompany.SelectedItem.Text;
                    _objLCmaster.LCNo = txtLcNo.Text;
                    Session["LCNo"] = txtLcNo.Text;
                    _objLCmaster.DateofIssue = Convert.ToDateTime(txtDateofIssue.Text);
                    _objLCmaster.DateofExpiry = Convert.ToDateTime(txtDateofExpiry.Text);
                    _objLCmaster.BuyerType = ddlBuyerType.SelectedValue.ToString();
                    _objLCmaster.Buyer_ID = Convert.ToInt16(ddlBuyerName.SelectedValue);
                    if (chkSeason.Checked == true)
                    {
                        _objLCmaster.SeasonId = SesonId;
                    }
                    else
                    {
                        _objLCmaster.SeasonId = 0;//Convert.ToInt32(ddlSeason.SelectedValue);
                    }
                    _objLCmaster.Qty = Convert.ToDouble(txtQty.Text);
                    //_objLCmaster.ItemDescription = txtItemDescription.Text;
                    _objLCmaster.USDRate = 0;//Convert.ToDecimal(txtUSD.Text);
                    _objLCmaster.BDTRate = 0;// Convert.ToDecimal(txtBDT.Text);
                    _objLCmaster.LC_USDValu = Convert.ToDouble(txtUSDV.Text);
                    _objLCmaster.Conv_Rate = Convert.ToDecimal(txtConvRate.Text);
                    _objLCmaster.LC_BDTValu = Convert.ToDouble(txtBDTV.Text);

                    _objLCmaster.TotalLC_ValueUSD = Convert.ToDecimal(txtUSDV.Text);
                    _objLCmaster.TotalLC_ValueBDT = Convert.ToDecimal(txtBDTV.Text);

                    _objLCmaster.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                    _objLCmaster.LC_Issue_Bank = txtIssueBank.Text;
                    _objLCmaster.Create_Date = DateTime.Now;
                    _objLCmaster.LCType = "Contact";

                    _objLCmaster.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    if (btnSubmit.Text == "Submit")
                    {
                        int result = _masterlcBLL.InsertLCmaster(_objLCmaster);

                        if (result == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                        }
                    }
                    else
                    {
                        _objLCmaster.Edit_User = ((SessionUser)Session["SessionUser"]).UserId;
                        _objLCmaster.Edit_Date = DateTime.Now;
                        int results = _masterlcBLL.UpdateMasterLc(txtLcNo.Text, _objLCmaster);

                        if (results == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                            btnSubmit.Text = "Submit";
                        }
                    }
                    ClearUI();
                    ShowMasterLC();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select SubCompany!')", true);
                }
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
            ddlSeason.ClearSelection();
            txtIssueBank.Text = "";
            txtSeason.Text = "";
            txtQty.Text = "";
            txtUSDV.Text = "";
            txtConvRate.Text = "";
            txtBDTV.Text = "";
        }

        private LC_OrderEntry ConvertToLC_OrderEntry(LC_OrderEntryTemp _OrderETemps)
        {
            LC_OrderEntry _objoen = new LC_OrderEntry();
            _objoen.LCNo = _OrderETemps.LCNo;
            _objoen.OrderNo = _OrderETemps.OrderNo;
            _objoen.OrderQuantity = _OrderETemps.OrderQuantity;
            _objoen.ShipmentDate = _OrderETemps.ShipmentDate;
            _objoen.Edit_User = _OrderETemps.Edit_User;
            _objoen.Edit_Date = _OrderETemps.Edit_Date;
            _objoen.Create_User = _OrderETemps.Create_User;
            _objoen.Create_Date = _OrderETemps.Create_Date;
            _objoen.OCODE = _OrderETemps.OCODE;
            //_objoen.Season = _OrderETemps.Season;

            _objoen.Article = _OrderETemps.Article;
            _objoen.ColorSpecification = _OrderETemps.ColorSpecification;
            _objoen.Style = _OrderETemps.Style;
            _objoen.FobQty = _OrderETemps.FobQty;
            _objoen.TotalQty = _OrderETemps.TotalQty;
            return _objoen;
        }
        private void ClearAlTemp()
        {
            _masterlcBLL.ClearAlTemp();
        }

        protected void ddlBuyerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillLCNoandOEntry();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

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

        protected void ddlBuyerName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlSubCompany_SelectedIndexChanged(object sender, EventArgs e)
        {

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
                    ddlSubCompany.SelectedItem.Text = _MSLc.SubCompanyName.ToString();
                    txtLcNo.Text = _MSLc.LCNo;
                    txtDateofIssue.Text = _MSLc.DateofIssue.ToString();
                    txtDateofExpiry.Text = _MSLc.DateofExpiry.ToString();
                    txtIssueBank.Text = _MSLc.LC_Issue_Bank;
                    ddlBuyerType.SelectedValue = _MSLc.BuyerType.ToString();
                    FillLCNoandOEntry();
                    ddlBuyerName.SelectedValue = _MSLc.Buyer_ID.ToString();
                    LoadSeason();
                    //ddlSeason.SelectedValue = _MSLc.SeasonId.ToString();
                    //txtSeason.Text = _MSLc.Season;
                    txtQty.Text = _MSLc.Qty.ToString();
                    txtUSDV.Text = _MSLc.LC_USDValu.ToString();
                    txtConvRate.Text = _MSLc.Conv_Rate.ToString();
                    txtBDTV.Text = _MSLc.LC_BDTValu.ToString();
                    btnSubmit.Text = "Update";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadSeason()
        {
            try
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<LC_Season> _Seasonlist = _masterlcBLL.GetSeasonList(OCode);

                if (_Seasonlist.Count > 0)
                {
                    ddlSeason.DataSource = _Seasonlist.ToList();
                    ddlSeason.DataTextField = "Season_Name";
                    ddlSeason.DataValueField = "Season_Id";
                    ddlSeason.DataBind();
                    ddlSeason.Items.Insert(0, new ListItem("---Select One---"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
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

        protected void txtConvRate_TextChanged(object sender, EventArgs e)
        {
            try
            {
                decimal USD_Value = Convert.ToDecimal(txtUSDV.Text);
                decimal Conv_Rate = Convert.ToDecimal(txtConvRate.Text);

                decimal TotalBDT = Convert.ToDecimal(USD_Value * Conv_Rate);
                txtBDTV.Text = TotalBDT.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void chkSeason_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSeason.Checked == true)
            {
                txtSeason.Visible = true;
                ddlSeason.Visible = false;
            }
            else
            {
                txtSeason.Visible = false;
                ddlSeason.Visible = true;
            }
        }
    }
}