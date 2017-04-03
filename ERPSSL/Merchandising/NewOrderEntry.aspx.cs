using ERPSSL.LC.BLL;
using ERPSSL.Merchandising.BLL;
using ERPSSL.Merchandising.DAL;
using ERPSSL.Merchandising.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.Merchandising
{
    public partial class NewOrderEntry : System.Web.UI.Page
    {

        ERPSSL_MerchandisingEntities _Context = new ERPSSL_MerchandisingEntities();

        MasterLCBLL masterBLL = new MasterLCBLL();

        NewOrderEntryBLL aNewOrderEntryBLL = new NewOrderEntryBLL();

        DateTime orderReceivedDate;
        string orderNo;
        string countryOfBuyer;
        int styleId = 0;
        int seasonId = 0;
        int buyerId = 0;
        int buyerDepartmentId = 0;
        int categoryId = 0;
        int unitId = 0;
        int officeId = 0;
        string marchaendicherId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    //Load Styles
                    FillStyle();
                    FillStyle2();
                    FillSeason();
                    FillBuyer();
                    FillBuyingDepartment();
                    FillCategory();
                    FillOffice();
                    FillUnit();
                    FillMerchandiser();
                    FillStyleForSearch();
                    FillBuyerForSearch();

                    LoadLCOrderGrid();

                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        public void HideTextBox()
        {

        }


        //Load Data For Grid View-------------------------------------------------------------------------------------------------------
        private void LoadLCOrderGrid()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;

            var loadData = aNewOrderEntryBLL.LoadDataForGrid(ocode);

            if (loadData.Count > 0)
            {
                grdorder.DataSource = loadData.ToList();
                grdorder.DataBind();
            }
            else
            {
                grdorder.DataSource = null;
                grdorder.DataBind();
            }
        }

        //Load Order No Wise Data for Grid View-------------------------------------------------------------------------------------------
        private void LoadLCOrderWiseGrid(string orderNo)
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;

            var loadData = aNewOrderEntryBLL.LoadDataForGridOrderNoWise(ocode, orderNo);

            if (loadData.Count > 0)
            {
                grdorder.DataSource = loadData.ToList();
                grdorder.DataBind();
            }
            else
            {
                grdorder.DataSource = null;
                grdorder.DataBind();
            }
        }


        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchOrderNo(string prefixText, int count)
        {
            using (var _context = new ERPSSL_MerchandisingEntities())
            {
                var allOrder = from m in _context.LC_OrderEntry
                               where ((m.OrderNo.Contains(prefixText)))
                               select m;
                List<String> orderList = new List<String>();
                foreach (var orders in allOrder)
                {
                    orderList.Add(orders.OrderNo);
                }
                return orderList;
            }
        }

        //--------------------------------------------------------Submit Button Work-------------------------------------------------------------------------------



        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {

                //Check stylewise check box is checked or not--------------------------------------###################################----------------------


                if (chkStleWise.Checked == false)
                {


                    // If style wise is not checked--------------------------------------------------------

                    if (txtOrderReceivedDate.Text == "")
                    {
                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Input Order Received Date!')", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Insert Order Receive Date');", true);

                        return;
                    }
                    else if (txtPOrder.Text == "")
                    {
                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Enter Order No!')", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Insert Order No');", true);
                        return;
                    }

                    if (chkNewstyle.Checked == true || chkNewstyle.Checked == false)
                    {
                        if (chkNewstyle.Checked == false)
                        {
                            if (ddlStyle.SelectedItem.Text == "--Select Style--")
                            {
                                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Style!')", true);
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Select Style');", true);
                                return;
                            }
                            else
                            {
                                styleId = Convert.ToInt32(ddlStyle.SelectedValue.ToString());
                            }

                        }
                        else if (chkNewstyle.Checked == true)
                        {

                            if (txtStyle.Text == "")
                            {
                                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Style!')", true);
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Insert Style');", true);
                                return;
                            }
                            else
                            {
                                LC_Style aLC_Style = new LC_Style();

                                aLC_Style.StyleName = txtStyle.Text;
                                aLC_Style.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                                aLC_Style.CreateDate = DateTime.Now;
                                aLC_Style.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                                styleId = aNewOrderEntryBLL.SaveStyle(aLC_Style);
                            }
                        }
                    }

                    if (ChkSeason.Checked == true || ChkSeason.Checked == false)
                    {
                        //Save Season-----------------------------------------------------------------------------------------------------------

                        if (ChkSeason.Checked == false)
                        {

                            if (ddlSeason.SelectedItem.Text == "--Select Season--")
                            {
                                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Season!')", true);
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Select Season');", true);
                                return;
                            }
                            else
                            {
                                seasonId = Convert.ToInt32(ddlSeason.SelectedValue.ToString());
                            }


                        }
                        else if (ChkSeason.Checked == false)
                        {
                            if (txtSeason.Text == "--Select Season--")
                            {
                                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Season!')", true);
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Insert Season');", true);
                                return;
                            }
                            else
                            {
                                LC_Season aLC_Season = new LC_Season();

                                aLC_Season.Season_Name = txtSeason.Text;
                                aLC_Season.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                                aLC_Season.CreateDate = DateTime.Now;
                                aLC_Season.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                                seasonId = aNewOrderEntryBLL.SaveSeasion(aLC_Season);
                            }
                        }
                    }

                    if (ddlBuyer.SelectedItem.Text == "--Select Buyer--")
                    {
                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Buyer!')", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Select Buyer');", true);
                        return;
                    }
                    else if (chkBuyerDepartment.Checked == true || chkBuyerDepartment.Checked == false)
                    {
                        //Save Buyer Department-----------------------------------------------------------------------------------------------------------
                        if (chkBuyerDepartment.Checked == false)
                        {
                            if (ddlBuyerDepartment.SelectedItem.Text == "--Select Buyer Department--")
                            {
                                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "CommonRequiredFiledError('Please Select Buyer Department');", true);
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Select Buyer Department');", true);
                                return;
                            }
                            else
                            {
                                buyerDepartmentId = Convert.ToInt32(ddlBuyerDepartment.SelectedValue.ToString());
                            }
                        }
                        else if (chkBuyerDepartment.Checked == true)
                        {
                            if (txtBuyerDepartment.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Insert Buyer Department');", true);
                            }
                            else
                            {
                                LC_BuyerDepartment aLC_BuyerDepartment = new LC_BuyerDepartment();

                                aLC_BuyerDepartment.BuyerDepartment_Name = txtBuyerDepartment.Text;
                                aLC_BuyerDepartment.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                                aLC_BuyerDepartment.Create_Date = DateTime.Now;
                                aLC_BuyerDepartment.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                                buyerDepartmentId = aNewOrderEntryBLL.SaveBuyerDepartment(aLC_BuyerDepartment);
                            }
                        }
                    }

                    if (chkCategory.Checked == true || chkCategory.Checked == false)
                    {
                        //Save Category-----------------------------------------------------------------------------------------------------------
                        if (chkCategory.Checked == false)
                        {
                            if (ddlCategory.SelectedItem.Text == "--Select Category--")
                            {
                                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "CommonRequiredFiledError('Please Select Category');", true);
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Select Category');", true);
                                return;
                            }
                            else
                            {
                                categoryId = Convert.ToInt32(ddlCategory.SelectedValue.ToString());
                            }

                        }
                        else
                        {
                            if (txtCategory.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Insert Category');", true);
                            }
                            else
                            {
                                LC_StyleCategor aLC_StyleCategor = new LC_StyleCategor();

                                aLC_StyleCategor.Style_Category_Name = txtCategory.Text;
                                aLC_StyleCategor.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                                aLC_StyleCategor.CreateDate = DateTime.Now;
                                aLC_StyleCategor.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                                categoryId = aNewOrderEntryBLL.SaveCategory(aLC_StyleCategor);
                            }
                        }
                    }

                    orderReceivedDate = Convert.ToDateTime(txtOrderReceivedDate.Text);
                    orderNo = txtPOrder.Text;
                    buyerId = Convert.ToInt32(ddlBuyer.SelectedValue.ToString());
                    countryOfBuyer = countryTextBox.Text;
                    unitId = Convert.ToInt32(ddlUnit.SelectedValue.ToString());
                    marchaendicherId = ddlMerchandiserName.SelectedValue.ToString();
                    officeId = Convert.ToInt32(ddlTTOffice.SelectedValue.ToString());

                    LC_OrderEntry aLC_OrderEntry = new LC_OrderEntry();

                    aLC_OrderEntry.OrderReceiveDate = Convert.ToDateTime(txtOrderReceivedDate.Text);
                    aLC_OrderEntry.OrderNo = txtPOrder.Text;
                    aLC_OrderEntry.StyleId = styleId;
                    aLC_OrderEntry.SeasonId = seasonId;
                    aLC_OrderEntry.Buyer_ID = buyerId;
                    aLC_OrderEntry.Countryof_Production = countryTextBox.Text;
                    aLC_OrderEntry.Buyer_DepartmentId = buyerDepartmentId;
                    aLC_OrderEntry.Style_Category_Id = categoryId;
                    aLC_OrderEntry.Style_Description = txtItemDescription.Text;
                    aLC_OrderEntry.OrderQuantity = txtOrderQty.Text;
                    aLC_OrderEntry.Unit_Id = Convert.ToInt32(ddlUnit.SelectedValue.ToString());
                    aLC_OrderEntry.Currency = ddlCurrency.Text;
                    aLC_OrderEntry.FOB_Port = txtFOBPort.Text;
                    aLC_OrderEntry.Shipment_Mode = ddlShipmentMode.SelectedItem.Text;
                    aLC_OrderEntry.ShipmentDate = Convert.ToDateTime(txtShipmentDate.Text);
                    aLC_OrderEntry.EID = ddlMerchandiserName.SelectedValue.ToString();
                    aLC_OrderEntry.Office_ID = Convert.ToInt32(ddlTTOffice.SelectedValue.ToString());
                    aLC_OrderEntry.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                    aLC_OrderEntry.Create_Date = DateTime.Now;
                    aLC_OrderEntry.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    int result = aNewOrderEntryBLL.SaveOrderEntry(aLC_OrderEntry);

                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert('Data Save Successfully!!');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "notsuccessalert('Data Not Save!!');", true);
                    }



                }
                else if (chkStleWise.Checked == true)
                {
                    // If style wise is not checked--------------------------------------------------------

                    if (txtOrderReceivedDate1.Text == "")
                    {
                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Input Order Received Date!')", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Insert Order Receive Date');", true);

                        return;
                    }
                    else if (txtPOrder2.Text == "")
                    {
                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Enter Order No!')", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Insert Order No');", true);
                        return;
                    }
                    else if (chkNewstyle2.Checked == true || chkNewstyle2.Checked == false)
                    {
                        if (chkNewstyle2.Checked == false)
                        {
                            if (ddlStyle2.SelectedItem.Text == "--Select Style--")
                            {
                                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Style!')", true);
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Select Style');", true);
                                return;
                            }
                            else
                            {
                                styleId = Convert.ToInt32(ddlStyle2.SelectedValue.ToString());
                            }

                        }
                        else if (chkNewstyle2.Checked == true)
                        {

                            if (txtStyle2.Text == "")
                            {
                                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Style!')", true);
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Insert Style');", true);
                                return;
                            }
                            else
                            {
                                LC_Style aLC_Style = new LC_Style();

                                aLC_Style.StyleName = txtStyle2.Text;
                                aLC_Style.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                                aLC_Style.CreateDate = DateTime.Now;
                                aLC_Style.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                                styleId = aNewOrderEntryBLL.SaveStyle(aLC_Style);
                            }
                        }
                    }
                    else if (ChkSeason.Checked == true || ChkSeason.Checked == false)
                    {
                        //Save Season-----------------------------------------------------------------------------------------------------------

                        if (ChkSeason.Checked == false)
                        {

                            if (ddlSeason.SelectedItem.Text == "--Select Season--")
                            {
                                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Season!')", true);
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Select Season');", true);
                                return;
                            }
                            else
                            {
                                seasonId = Convert.ToInt32(ddlSeason.SelectedValue.ToString());
                            }


                        }
                        else if (ChkSeason.Checked == false)
                        {
                            if (txtSeason.Text == "--Select Season--")
                            {
                                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Season!')", true);
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Insert Season');", true);
                                return;
                            }
                            else
                            {
                                LC_Season aLC_Season = new LC_Season();

                                aLC_Season.Season_Name = txtSeason.Text;
                                aLC_Season.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                                aLC_Season.CreateDate = DateTime.Now;
                                aLC_Season.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                                seasonId = aNewOrderEntryBLL.SaveSeasion(aLC_Season);
                            }
                        }
                    }
                    else if (ddlBuyer.SelectedItem.Text == "--Select Buyer--")
                    {
                        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Buyer!')", true);
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Select Buyer');", true);
                        return;
                    }
                    else if (chkBuyerDepartment.Checked == true || chkBuyerDepartment.Checked == false)
                    {
                        //Save Buyer Department-----------------------------------------------------------------------------------------------------------
                        if (chkBuyerDepartment.Checked == false)
                        {
                            if (ddlBuyerDepartment.SelectedItem.Text == "--Select Buyer Department--")
                            {
                                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "CommonRequiredFiledError('Please Select Buyer Department');", true);
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Select Buyer Department');", true);
                                return;
                            }
                            else
                            {
                                buyerDepartmentId = Convert.ToInt32(ddlBuyerDepartment.SelectedValue.ToString());
                            }
                        }
                        else if (chkBuyerDepartment.Checked == true)
                        {
                            if (txtBuyerDepartment.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Insert Buyer Department');", true);
                            }
                            else
                            {
                                LC_BuyerDepartment aLC_BuyerDepartment = new LC_BuyerDepartment();

                                aLC_BuyerDepartment.BuyerDepartment_Name = txtBuyerDepartment.Text;
                                aLC_BuyerDepartment.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                                aLC_BuyerDepartment.Create_Date = DateTime.Now;
                                aLC_BuyerDepartment.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                                buyerDepartmentId = aNewOrderEntryBLL.SaveBuyerDepartment(aLC_BuyerDepartment);
                            }
                        }
                    }
                    else if (chkCategory.Checked == true || chkCategory.Checked == false)
                    {
                        //Save Category-----------------------------------------------------------------------------------------------------------
                        if (chkCategory.Checked == false)
                        {
                            if (ddlCategory.SelectedItem.Text == "--Select Category--")
                            {
                                //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "CommonRequiredFiledError('Please Select Category');", true);
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Select Category');", true);
                                return;
                            }
                            else
                            {
                                categoryId = Convert.ToInt32(ddlCategory.SelectedValue.ToString());
                            }

                        }
                        else
                        {
                            if (txtCategory.Text == "")
                            {
                                ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "CommonRequiredFiledError('Please Insert Category');", true);
                            }
                            else
                            {
                                LC_StyleCategor aLC_StyleCategor = new LC_StyleCategor();

                                aLC_StyleCategor.Style_Category_Name = txtCategory.Text;
                                aLC_StyleCategor.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                                aLC_StyleCategor.CreateDate = DateTime.Now;
                                aLC_StyleCategor.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                                categoryId = aNewOrderEntryBLL.SaveCategory(aLC_StyleCategor);
                            }
                        }
                    }



                    orderReceivedDate = Convert.ToDateTime(txtOrderReceivedDate1.Text);
                    orderNo = txtPOrder2.Text;
                    buyerId = Convert.ToInt32(ddlBuyer.SelectedValue.ToString());
                    countryOfBuyer = countryTextBox.Text;
                    unitId = Convert.ToInt32(ddlUnit.SelectedValue.ToString());
                    marchaendicherId = ddlMerchandiserName.SelectedValue.ToString();
                    officeId = Convert.ToInt32(ddlTTOffice.SelectedValue.ToString());

                    LC_OrderEntry aLC_OrderEntry = new LC_OrderEntry();

                    aLC_OrderEntry.OrderReceiveDate = Convert.ToDateTime(txtOrderReceivedDate.Text);
                    aLC_OrderEntry.OrderNo = txtPOrder.Text;
                    aLC_OrderEntry.StyleId = styleId;
                    aLC_OrderEntry.SeasonId = seasonId;
                    aLC_OrderEntry.Buyer_ID = buyerId;
                    aLC_OrderEntry.Countryof_Production = countryTextBox.Text;
                    aLC_OrderEntry.Buyer_DepartmentId = buyerDepartmentId;
                    aLC_OrderEntry.Style_Category_Id = categoryId;
                    aLC_OrderEntry.Style_Description = txtItemDescription.Text;
                    aLC_OrderEntry.OrderQuantity = txtOrderQty.Text;
                    aLC_OrderEntry.Unit_Id = Convert.ToInt32(ddlUnit.SelectedValue.ToString());
                    aLC_OrderEntry.Currency = ddlCurrency.Text;
                    aLC_OrderEntry.FOB_Port = txtFOBPort.Text;
                    aLC_OrderEntry.Shipment_Mode = ddlShipmentMode.SelectedItem.Text;
                    aLC_OrderEntry.ShipmentDate = Convert.ToDateTime(txtShipmentDate.Text);
                    aLC_OrderEntry.EID = ddlMerchandiserName.SelectedValue.ToString();
                    aLC_OrderEntry.Office_ID = Convert.ToInt32(ddlTTOffice.SelectedValue.ToString());
                    aLC_OrderEntry.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                    aLC_OrderEntry.Create_Date = DateTime.Now;
                    aLC_OrderEntry.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                    int result = aNewOrderEntryBLL.SaveOrderEntry(aLC_OrderEntry);

                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "successalert('Data Save Successfully!!');", true);
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "notsuccessalert('Data Not Save!!');", true);
                    }
                }


            }
            catch (Exception ex)
            {
                throw ex;
            }

            LoadLCOrderGrid();

        }

        public void Save()
        {

        }

        //All Checked Chnage State-------------------------------------------------------------------------------------------------------------------------------------


        //Select Stylewise or Order Wise
        protected void chkStleWise_CheckedChanged(object sender, EventArgs e)
        {
            if (chkStleWise.Checked == true)
            {
                OrderNo2.Visible = true;
                OrderNo1.Visible = false;
            }
            else
            {
                OrderNo2.Visible = false;
                OrderNo1.Visible = true;
            }
        }

        //Style Check
        protected void chkNewstyle_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNewstyle.Checked == true)
            {
                txtStyle.Visible = true;
                ddlStyle.Visible = false;
            }
            else
            {
                txtStyle.Visible = false;
                ddlStyle.Visible = true;
            }


        }

        //Style Check
        protected void chkNewstyle2_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNewstyle2.Checked == true)
            {
                ddlStyle2.Visible = false;
                txtStyle2.Visible = true;
            }
            else
            {
                ddlStyle2.Visible = true;
                txtStyle2.Visible = false;
            }


        }

        //Check Season
        protected void ChkSeason_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSeason.Checked == true)
            {
                ddlSeason.Visible = false;
                txtSeason.Visible = true;
            }
            else
            {
                ddlSeason.Visible = true;
                txtSeason.Visible = false;
            }
        }

        //Check Buyer Department
        protected void chkBuyerDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBuyerDepartment.Checked == true)
            {
                ddlBuyerDepartment.Visible = false;
                txtBuyerDepartment.Visible = true;
            }
            else
            {
                ddlBuyerDepartment.Visible = true;
                txtBuyerDepartment.Visible = false;
            }
        }

        //Check Category
        protected void chkCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCategory.Checked == true)
            {
                ddlCategory.Visible = false;
                txtCategory.Visible = true;
            }
            else
            {
                ddlCategory.Visible = true;
                txtCategory.Visible = false;
            }
        }



        // Fill All The DropDownBox-----------------------------------------------------------------------------------------------------------------------------------

        private void FillStyle()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_Style> row = aNewOrderEntryBLL.GetAllStyle(ocode);

                if (row != null)
                {
                    ddlStyle.DataSource = row.ToList();
                    ddlStyle.DataTextField = "StyleName";
                    ddlStyle.DataValueField = "StyleId";
                    ddlStyle.DataBind();
                    ddlStyle.AppendDataBoundItems = false;
                    ddlStyle.Items.Insert(0, new ListItem("--Select Style--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillStyle2()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_Style> row = aNewOrderEntryBLL.GetAllStyle(ocode);

                if (row != null)
                {
                    ddlStyle2.DataSource = row.ToList();
                    ddlStyle2.DataTextField = "StyleName";
                    ddlStyle2.DataValueField = "StyleId";
                    ddlStyle2.DataBind();
                    ddlStyle2.AppendDataBoundItems = false;
                    ddlStyle2.Items.Insert(0, new ListItem("--Select Style--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillSeason()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_Season> seasonList = aNewOrderEntryBLL.GetSeason(ocode);
                if (seasonList != null)
                {
                    ddlSeason.DataSource = seasonList.ToList();
                    ddlSeason.DataTextField = "Season_Name";
                    ddlSeason.DataValueField = "Season_Id";
                    ddlSeason.DataBind();
                    ddlSeason.AppendDataBoundItems = false;
                    ddlSeason.Items.Insert(0, new ListItem("--Select Season--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillBuyer()
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = aNewOrderEntryBLL.GetBuyerName(OCode);
                if (row != null)
                {
                    ddlBuyer.DataSource = row.ToList();
                    ddlBuyer.DataTextField = "Buyer_Name";
                    ddlBuyer.DataValueField = "Buyer_ID";
                    ddlBuyer.DataBind();
                    ddlBuyer.AppendDataBoundItems = false;
                    ddlBuyer.Items.Insert(0, new ListItem("--Select Buyer--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillBuyingDepartment()
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_BuyerDepartment> aBuyerDepartment = aNewOrderEntryBLL.GetBuyingDepartment(OCode);
                if (aBuyerDepartment != null)
                {
                    ddlBuyerDepartment.DataSource = aBuyerDepartment.ToList();
                    ddlBuyerDepartment.DataTextField = "BuyerDepartment_Name";
                    ddlBuyerDepartment.DataValueField = "BuyerDepartment_Id";
                    ddlBuyerDepartment.DataBind();
                    ddlBuyerDepartment.AppendDataBoundItems = false;
                    ddlBuyerDepartment.Items.Insert(0, new ListItem("--Select Buyer Department--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillCategory()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_StyleCategor> row = aNewOrderEntryBLL.GetAllCategory(ocode);

                if (row != null)
                {
                    ddlCategory.DataSource = row.ToList();
                    ddlCategory.DataTextField = "Style_Category_Name";
                    ddlCategory.DataValueField = "Style_Category_Id";
                    ddlCategory.DataBind();
                    ddlCategory.AppendDataBoundItems = false;
                    ddlCategory.Items.Insert(0, new ListItem("--Select Category--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillOffice()
        {
            try
            {
                List<HRM_Office> row = aNewOrderEntryBLL.GetOffice();

                if (row != null)
                {
                    ddlTTOffice.DataSource = row.ToList();
                    ddlTTOffice.DataTextField = "OfficeName";
                    ddlTTOffice.DataValueField = "OfficeID";
                    ddlTTOffice.DataBind();
                    ddlTTOffice.AppendDataBoundItems = false;
                    ddlTTOffice.Items.Insert(0, new ListItem("--Select Office--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillUnit()
        {
            try
            {
                List<Inv_Unit> row = aNewOrderEntryBLL.GetUnit();

                if (row != null)
                {
                    ddlUnit.DataSource = row.ToList();
                    ddlUnit.DataTextField = "UnitName";
                    ddlUnit.DataValueField = "UnitId";
                    ddlUnit.DataBind();
                    ddlUnit.AppendDataBoundItems = false;
                    ddlUnit.Items.Insert(0, new ListItem("--Select Unit--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillMerchandiser()
        {
            try
            {
                List<MerchandiserRepo> row = aNewOrderEntryBLL.GetMerchandiser();

                if (row != null)
                {
                    ddlMerchandiserName.DataSource = row.ToList();
                    ddlMerchandiserName.DataTextField = "FullName";
                    ddlMerchandiserName.DataValueField = "Id";
                    ddlMerchandiserName.DataBind();
                    ddlMerchandiserName.AppendDataBoundItems = false;
                    ddlMerchandiserName.Items.Insert(0, new ListItem("--Select Merchandiser--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillStyleForSearch()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_Style> row = aNewOrderEntryBLL.GetAllStyle(ocode);

                if (row != null)
                {
                    searchStyleddl.DataSource = row.ToList();
                    searchStyleddl.DataTextField = "StyleName";
                    searchStyleddl.DataValueField = "StyleId";
                    searchStyleddl.DataBind();
                    searchStyleddl.AppendDataBoundItems = false;
                    searchStyleddl.Items.Insert(0, new ListItem("--Select Style--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillBuyerForSearch()
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = aNewOrderEntryBLL.GetBuyerName(OCode);
                if (row != null)
                {
                    searchBuyerdllr.DataSource = row.ToList();
                    searchBuyerdllr.DataTextField = "Buyer_Name";
                    searchBuyerdllr.DataValueField = "Buyer_ID";
                    searchBuyerdllr.DataBind();
                    searchBuyerdllr.AppendDataBoundItems = false;
                    searchBuyerdllr.Items.Insert(0, new ListItem("--Select Buyer--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        //All Types of Selected Index Changes--------------------------------------------------------------------------------------------------------------------------------


        //Buyer Selected Index Chnage
        protected void ddlBuyer_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string buyerName = ddlBuyer.SelectedItem.Text;
                string buyerCountry = (from b in _Context.Com_Buyer_Setup
                                       where b.Buyer_Name == buyerName
                                       select b.Country).SingleOrDefault();

                countryTextBox.Text = Convert.ToString(buyerCountry);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void imgbtnAdd_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            Label lblOrderEntryID = (Label)grdorder.Rows[row.RowIndex].FindControl("lblOrderEntryID");
            Label lblOrderNo = (Label)grdorder.Rows[row.RowIndex].FindControl("lblOrderNo");
            Label lblStyleId = (Label)grdorder.Rows[row.RowIndex].FindControl("lblStyleId");
            Label lblStyle = (Label)grdorder.Rows[row.RowIndex].FindControl("lblStyle");
            Label lblBuyerId = (Label)grdorder.Rows[row.RowIndex].FindControl("lblBuyerId");
            Label lblBuyer = (Label)grdorder.Rows[row.RowIndex].FindControl("lblBuyer");
            Label lblQuantity = (Label)grdorder.Rows[row.RowIndex].FindControl("lblQuantity");

            Session["OederEntryId"] = lblOrderEntryID.Text;
            Session["OrderNo"] = lblOrderNo.Text;
            Session["StyleId"] = lblStyleId.Text;
            Session["Style"] = lblStyle.Text;
            Session["BuyerId"] = lblBuyerId.Text;
            Session["Buyer"] = lblBuyer.Text;
            Session["Quantity"] = lblQuantity.Text;

            Response.Redirect("OrderItems.aspx");

        }

        protected void imgbtnOrderSheetEdit_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            Label lblOrderEntryID = (Label)grdorder.Rows[row.RowIndex].FindControl("lblOrderEntryID");

            int orderEntryId = Convert.ToInt32(lblOrderEntryID.Text);

            List<OrderEntryViewRepo> orderEntryViewRepoList = aNewOrderEntryBLL.LoadSingalInfo(orderEntryId);

            

            if (orderEntryViewRepoList.Count > 0)
            {
                foreach (OrderEntryViewRepo aOrderEntryViewRepo in orderEntryViewRepoList)
                {
                    txtOrderReceivedDate.Text = aOrderEntryViewRepo.OrderReceivedDate.ToString("dd/MM/yyyy");
                    txtPOrder.Text = aOrderEntryViewRepo.OrderNo.ToString();
                    ddlStyle.SelectedValue = aOrderEntryViewRepo.StyleId.ToString();
                    ddlSeason.SelectedValue = aOrderEntryViewRepo.SeasonId.ToString();
                    ddlBuyer.SelectedValue = aOrderEntryViewRepo.BuyerId.ToString();
                    countryTextBox.Text = aOrderEntryViewRepo.Country.ToString();
                    ddlBuyerDepartment.SelectedValue = aOrderEntryViewRepo.BuyerDepartmentId.ToString();
                    ddlCategory.SelectedValue= aOrderEntryViewRepo.CategoryId.ToString();
                    txtItemDescription.Text = aOrderEntryViewRepo.ItemDescription;
                    txtOrderQty.Text = aOrderEntryViewRepo.Quantity.ToString();
                    ddlUnit.SelectedValue = aOrderEntryViewRepo.UnitId.ToString();
                    ddlCurrency.SelectedValue = aOrderEntryViewRepo.Currency;
                    txtFOBPort.Text = aOrderEntryViewRepo.FOBPort;
                    ddlShipmentMode.Text = aOrderEntryViewRepo.ShipmentMode;
                    txtShipmentDate.Text = aOrderEntryViewRepo.ShipmentDate.ToString("dd/MM/yyyy");
                    ddlMerchandiserName.SelectedValue = aOrderEntryViewRepo.MerchendiserId.ToString();
                    ddlTTOffice.SelectedValue = aOrderEntryViewRepo.OfficeId.ToString();

                }
            }


        }

       
      


    }
}