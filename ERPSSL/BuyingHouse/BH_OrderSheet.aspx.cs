using ERPSSL.BuyingHouse.BLL;
using ERPSSL.BuyingHouse.DAL.Repository;
using ERPSSL.INV.BLL;
using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL;
using ERPSSL.LC.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.BuyingHouse
{
    public partial class BH_OrderSheet : System.Web.UI.Page
    {
        OrderSheetBLL _orderSheetbll = new OrderSheetBLL();
        GroupBLL groupBll = new GroupBLL();
        ProductBLL productBll = new ProductBLL();
        MasterLCBLL masterBLL = new MasterLCBLL();
        BuyerBLL _Buyerbll = new BuyerBLL();
        SampleDetailsBLL _SampleDetailsBLL = new SampleDetailsBLL();

        private ERPSSL.LC.DAL.ERPSSL_LCEntities _Context = new ERPSSL.LC.DAL.ERPSSL_LCEntities();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    FillSeason();
                    FillStyle();
                    GetMerchandiserDept();
                    //GetBuyerList();
                    GetGenderList();
                    GetQuotaOrCategory();
                    GetMerchandiserName();
                    GetUnit();
                    GetOffice();
                    GetFactory();
                    LoadPrincipalList();
                    LoadOrderByStyle();
                    LoadBuyerList();
                    LoadBuyingDepartmentList();
                    LoadLCOrderGrid();
                    LoadOrderByBuyer();
                    LoadS_PrincipalList();
                    LoadS_FactoryList();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void LoadS_FactoryList()
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_Factory> row = _orderSheetbll.GetSFactory(OCode);

                if (row != null)
                {
                    ddlS_Factory.DataSource = row.ToList();
                    ddlS_Factory.DataTextField = "FactoryName";
                    ddlS_Factory.DataValueField = "FactoryId";
                    ddlS_Factory.DataBind();
                    ddlS_Factory.AppendDataBoundItems = false;
                    ddlS_Factory.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadS_PrincipalList()
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = _orderSheetbll.GetBuyerS_Name(OCode);
                if (row != null)
                {
                    ddlS_Principal.DataSource = row.ToList();
                    ddlS_Principal.DataTextField = "PrincipalName";
                    ddlS_Principal.DataValueField = "Buyer_ID";
                    ddlS_Principal.DataBind();
                    ddlS_Principal.AppendDataBoundItems = false;
                    ddlS_Principal.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadBuyingDepartmentList()
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = _orderSheetbll.GetBuyingDepartmentName(OCode);
                if (row != null)
                {
                    ddlBuyerDepartment.DataSource = row.ToList();
                    ddlBuyerDepartment.DataTextField = "BuyerDepartment_Name";
                    ddlBuyerDepartment.DataValueField = "BuyerDepartment_Id";
                    ddlBuyerDepartment.DataBind();
                    ddlBuyerDepartment.AppendDataBoundItems = false;
                    ddlBuyerDepartment.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadBuyerList()
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = _orderSheetbll.GetBuyerName(OCode);
                if (row != null)
                {
                    ddlBuyer.DataSource = row.ToList();
                    ddlBuyer.DataTextField = "Buyer_Name";
                    ddlBuyer.DataValueField = "Buyer_Name";
                    ddlBuyer.DataBind();
                    ddlBuyer.AppendDataBoundItems = false;
                    ddlBuyer.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadPrincipalList()
        {
            try
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;
                var row = _orderSheetbll.GetPrincipalName(OCode);
                if (row != null)
                {
                    ddlPrincipal.DataSource = row.ToList();
                    ddlPrincipal.DataTextField = "PrincipalName";
                    ddlPrincipal.DataValueField = "Buyer_ID";
                    ddlPrincipal.DataBind();
                    ddlPrincipal.AppendDataBoundItems = false;
                    ddlPrincipal.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadLCOrderGrid()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            var result = masterBLL.LoadLCOrderGrid(ocode);
            if (result.Count > 0)
            {
                grdorder.DataSource = result.ToList();
                grdorder.DataBind();
            }
            else
            {
                grdorder.DataSource = null;
                grdorder.DataBind();
            }
        }

        private void GetFactory()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_Factory> row = _SampleDetailsBLL.GetFactory(ocode);

                if (row != null)
                {
                    ddlFactory.DataSource = row.ToList();
                    ddlFactory.DataTextField = "FactoryName";
                    ddlFactory.DataValueField = "FactoryId";
                    ddlFactory.DataBind();
                    ddlFactory.AppendDataBoundItems = false;
                    ddlFactory.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetOffice()
        {
            try
            {
                List<HRM_Office> row = _SampleDetailsBLL.GetOffice();

                if (row != null)
                {
                    ddlTTOffice.DataSource = row.ToList();
                    ddlTTOffice.DataTextField = "OfficeName";
                    ddlTTOffice.DataValueField = "OfficeID";
                    ddlTTOffice.DataBind();
                    ddlTTOffice.AppendDataBoundItems = false;
                    ddlTTOffice.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetUnit()
        {
            try
            {
                List<Inv_Unit> row = _SampleDetailsBLL.GetUnit();

                if (row != null)
                {
                    ddlUnit.DataSource = row.ToList();
                    ddlUnit.DataTextField = "UnitName";
                    ddlUnit.DataValueField = "UnitId";
                    ddlUnit.DataBind();
                    ddlUnit.AppendDataBoundItems = false;
                    ddlUnit.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetQuotaOrCategory()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_StyleCategor> row = _SampleDetailsBLL.GetQuotaOrCategory(ocode);

                if (row != null)
                {
                    ddlCategory.DataSource = row.ToList();
                    ddlCategory.DataTextField = "Style_Category_Name";
                    ddlCategory.DataValueField = "Style_Category_Id";
                    ddlCategory.DataBind();
                    ddlCategory.AppendDataBoundItems = false;
                    ddlCategory.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetGenderList()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_Style_Gender> row = _SampleDetailsBLL.GetGenderList(ocode);

                if (row != null)
                {
                    ddlGender.DataSource = row.ToList();
                    ddlGender.DataTextField = "Gender_Name";
                    ddlGender.DataValueField = "Gender_Id";
                    ddlGender.DataBind();
                    ddlGender.AppendDataBoundItems = false;
                    ddlGender.Items.Insert(0, new ListItem("--Select--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetMerchandiserDept()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<HRM_DEPARTMENTS> row = _SampleDetailsBLL.GetGetMerchandiserDept(ocode);

                if (row != null)
                {
                    ddlMerchandiserDept.DataSource = row.ToList();
                    ddlMerchandiserDept.DataTextField = "DPT_NAME";
                    ddlMerchandiserDept.DataValueField = "DPT_ID";
                    ddlMerchandiserDept.DataBind();
                    ddlMerchandiserDept.AppendDataBoundItems = false;
                    ddlMerchandiserDept.Items.Insert(0, new ListItem("--Select--", "0"));

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void FillStyle()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_Style> row = _orderSheetbll.GetLC_Style(ocode);

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

        private void FillSeason()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_Season> row = _orderSheetbll.GetOrderByOcode(ocode);
                if (row != null)
                {
                    ddlSeason.DataSource = row.ToList();
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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                DateTime? NullDate = null;
                int StyleId = 0;
                int BuyDept = 0;
                int StyleCatId = 0;
                if (txtPOrder.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Enter Order No!')", true);
                    return;
                }
                if (ddlStyle.SelectedItem.Text == "--Select Style--" && txtStyle.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Style!')", true);
                    return;
                }
                if (ddlSeason.SelectedItem.Text == "--Select Season--" && txtSeason.Text == "")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Season!')", true);
                    return;
                }
                if (ddlBuyer.SelectedItem.Text == "--Select Buyer--")
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Buyer!')", true);
                    return;
                }

                if (chkNewstyle.Checked == true)
                {
                    LC_Style aLC_Style = new LC_Style();

                    aLC_Style.StyleName = txtStyle.Text;
                    aLC_Style.CreateDate = DateTime.Today;
                    aLC_Style.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                    aLC_Style.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                    var result = _Buyerbll.AddStyle(aLC_Style);
                    StyleId = result;
                }

                LC_Season aLC_Season = new LC_Season();

                if (ChkSeason.Checked == true)
                {
                    aLC_Season.Season_Name = txtSeason.Text;
                    aLC_Season.CreateDate = DateTime.Today;
                    aLC_Season.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                    aLC_Season.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                    var result = _orderSheetbll.AddSeason(aLC_Season);
                }
                LC_BuyerDepartment _LC_BuyerDepartment = new LC_BuyerDepartment();

                if (chkBuyerDepartment.Checked == true)
                {
                    int count = (from Bd in _Context.LC_BuyerDepartment
                                 where Bd.BuyerDepartment_Name == _LC_BuyerDepartment.BuyerDepartment_Name
                                 select Bd.BuyerDepartment_Name).Count();
                    if (count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Buyer Department already Exist')", true);
                        return;
                    }
                    _LC_BuyerDepartment.BuyerDepartment_Name = txtBuyerDepartment.Text;
                    _LC_BuyerDepartment.Create_Date = DateTime.Today;
                    _LC_BuyerDepartment.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                    _LC_BuyerDepartment.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                    int result = _orderSheetbll.AddBuyerDepartment(_LC_BuyerDepartment);
                    BuyDept = result;
                }

                LC_StyleCategor _LC_StyleCategor = new LC_StyleCategor();

                if (chkCategory.Checked == true)
                {
                    int count = (from Bd in _Context.LC_StyleCategor
                                 where Bd.Style_Category_Name == _LC_StyleCategor.Style_Category_Name
                                 select Bd.Style_Category_Name).Count();
                    if (count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Style Category already Exist')", true);
                        return;
                    }
                    _LC_StyleCategor.Style_Category_Name = txtCategory.Text;
                    _LC_StyleCategor.CreateDate = DateTime.Today;
                    _LC_StyleCategor.CreateUser = ((SessionUser)Session["SessionUser"]).UserId;
                    _LC_StyleCategor.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                    int result = _orderSheetbll.AddStyleCategor(_LC_StyleCategor);
                    StyleCatId = result;
                }

                LC_OrderEntry orderEntry = new LC_OrderEntry();

                if (txtOriginalContractDate.Text == "")
                {
                    orderEntry.OrderReceiveDate = NullDate;
                }
                else
                {
                    orderEntry.OrderReceiveDate = Convert.ToDateTime(txtOriginalContractDate.Text);
                }

                if (ChkSeason.Checked == true)
                {
                    orderEntry.SeasonId = aLC_Season.Season_Id;
                    hidSeasonID.Value = orderEntry.Season;
                }
                else
                {
                    orderEntry.SeasonId = Convert.ToInt32(ddlSeason.SelectedValue);
                    hidSeasonID.Value = orderEntry.Season;
                }
                if (chkBuyerDepartment.Checked == true)
                {
                    orderEntry.Buyer_DepartmentId = BuyDept;
                }
                else
                {
                    orderEntry.Buyer_DepartmentId = Convert.ToInt32(ddlBuyerDepartment.SelectedValue);
                }

                orderEntry.OrderQuantity = txtOrderQty.Text;
                //orderEntry.FobQty = Convert.ToDouble(txtFob.Text);
                orderEntry.UnitPrice = Convert.ToDecimal(txtFob.Text);
                if (chkNewstyle.Checked == true)
                {
                    orderEntry.StyleId = StyleId;
                }
                else
                {
                    orderEntry.StyleId = Convert.ToInt32(ddlStyle.SelectedValue);
                }
                orderEntry.OrderNo = txtPOrder.Text;
                orderEntry.Merch_Dept_Id = Convert.ToInt32(ddlMerchandiserDept.SelectedValue);
                orderEntry.FactoryId = Convert.ToInt32(ddlFactory.SelectedValue);
                orderEntry.Gender_Id = Convert.ToInt32(ddlGender.SelectedValue);
                orderEntry.Style_Description = txtCustomerStyle.Text;
                orderEntry.Yarn_Fabrication = txtYarnFabrication.Text;
                orderEntry.EID = ddlMerchandiserName.SelectedValue;
                orderEntry.Countryof_Production = ddlCountry.SelectedItem.Text;
                if (chkCategory.Checked == true)
                {
                    orderEntry.Style_Category_Id = StyleCatId;
                }
                else
                {
                    orderEntry.Style_Category_Id = Convert.ToInt32(ddlCategory.SelectedValue);
                }
                orderEntry.Currency = ddlCurrency.SelectedItem.Text;
                orderEntry.TimeOf_Delevery = txttimeOfDelivery.Text;
                orderEntry.PlaceOf_DisPatchFrom = txtFromPort.Text;
                orderEntry.PlaceOf_DisPatchTo = txtToPort.Text;
                orderEntry.Total_Amount = Convert.ToDouble(txtTotalAmount.Text);
                orderEntry.Principal_Id = Convert.ToInt32(ddlPrincipal.SelectedValue);
                orderEntry.Unit_Id = Convert.ToInt32(ddlUnit.SelectedValue);
                orderEntry.Office_ID = Convert.ToInt32(ddlTTOffice.SelectedValue);
                orderEntry.Buyer_Name = ddlBuyer.SelectedValue;
                orderEntry.ColorSpecification = txtStyleColor.Text;
                orderEntry.CommissionPersent = Convert.ToDecimal(txtCommissionPer.Text);
                orderEntry.TotalCommission = Convert.ToDecimal(txtTotalCommission.Text);

                orderEntry.FOB_Port = txtFOBPort.Text;
                if (txtShipmentDate.Text == "")
                {
                    orderEntry.ShipmentDate = NullDate;
                }
                else
                {
                    orderEntry.ShipmentDate = Convert.ToDateTime(txtShipmentDate.Text);
                }
                if (txtOrderConfirmationDate.Text == "")
                {
                    orderEntry.LC_Reveived_Date = NullDate;
                }
                else
                {
                    orderEntry.LC_Reveived_Date = Convert.ToDateTime(txtOrderConfirmationDate.Text);
                }
                orderEntry.Shipment_Mode = ddlShipmentMode.SelectedItem.Text;
                if (rdbShipmentHandling.Checked == true)
                {
                    orderEntry.ShipmentStatus = true;
                }
                else
                {
                    orderEntry.ShipmentStatus = false;
                }
                orderEntry.Create_Date = DateTime.Today;
                orderEntry.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                orderEntry.OCODE = ((SessionUser)Session["SessionUser"]).OCode;

                if (btnSubmit.Text == "Add")
                {
                    int count = (from orderentry in _Context.LC_OrderEntry
                                 where orderentry.OrderNo == orderEntry.OrderNo
                                 select orderentry.OrderNo).Count();
                    if (count > 0)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('PO Number already Exist')", true);
                    }
                    else
                    {
                        var result = masterBLL.InsertOrderEntry(orderEntry);
                        if (result == 1)
                        {
                            ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);
                        }
                    }
                }
                else
                {
                    int orderid = Convert.ToInt32(hidorderid.Value);
                    var result = masterBLL.UpdateOrderEntry(orderEntry, orderid);
                    if (result == 1)
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);
                    }
                }
                LoadLCOrderGrid();
                Clear();
                ShowDiv.Visible = false;
                ShowGrid.Visible = true;
                AddOrder.Visible = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Clear()
        {
            ddlStyle.ClearSelection();
            ddlSeason.ClearSelection();
            txtPOrder.Text = "";
            ddlMerchandiserDept.ClearSelection();
            ddlFactory.ClearSelection();
            txtFob.Text = "0";
            ddlMerchandiserName.ClearSelection();
            ddlTTOffice.ClearSelection();
            ddlBuyer.ClearSelection();
            ddlGender.ClearSelection();
            txtCustomerStyle.Text = "";
            txtOrderQty.Text = "0";
            txtYarnFabrication.Text = "";
            txtStyleColor.Text = "";
            ddlCountry.ClearSelection();
            ddlCurrency.ClearSelection();
            ddlUnit.ClearSelection();
            ddlCategory.ClearSelection();
            txttimeOfDelivery.Text = "";
            txtFromPort.Text = "";
            //txtFob.Text = "";
            txtToPort.Text = "";
            txtStyle.Text = "";
            txtTotalAmount.Text = "";

            txtFOBPort.Text = "";
            txtOrderConfirmationDate.Text = "";
            ddlShipmentMode.ClearSelection();
        }

        protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime day = DateTime.Today;
            int id = Convert.ToInt32(ddlSeason.SelectedValue);
            string lblLCNo = Convert.ToString(id);
        }

        protected void chkNewstyle_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNewstyle.Checked == true)
            {
                ddlStyle.Visible = false;
                txtStyle.Visible = true;
            }
            else
            {
                ddlStyle.Visible = true;
                txtStyle.Visible = false;
            }
        }

        protected void imgbtnOrderSheetEdit_Click(object sender, ImageClickEventArgs e)
        {
            List<LC_OrderEntry> orders = new List<LC_OrderEntry>();
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            try
            {
                string orderId = "";
                Label lblOrderEntryID = (Label)grdorder.Rows[row.RowIndex].FindControl("lblOrderEntryID");
                if (lblOrderEntryID != null)
                {
                    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                    orderId = lblOrderEntryID.Text;

                    orders = masterBLL.GetOrderByOrderIdandOcode(orderId, OCODE);

                    if (orders.Count > 0)
                    {
                        foreach (LC_OrderEntry order in orders)
                        {
                            hidorderid.Value = order.OrderEntryID.ToString();
                            txtPOrder.Text = order.OrderNo;

                            txtCustomerStyle.Text = order.Style_Description;
                            txtYarnFabrication.Text = order.Yarn_Fabrication;

                            txttimeOfDelivery.Text = order.TimeOf_Delevery;
                            txtFromPort.Text = order.PlaceOf_DisPatchFrom;
                            txtToPort.Text = order.PlaceOf_DisPatchTo;
                            txtTotalAmount.Text = Convert.ToString(order.Total_Amount);
                            txtStyleColor.Text = order.ColorSpecification;
                            LoadBuyingDepartmentList();
                            ddlBuyerDepartment.SelectedValue = order.Buyer_DepartmentId.ToString(); ;
                            GetOffice();
                            ddlTTOffice.SelectedValue = Convert.ToString(order.Office_ID);
                            GetMerchandiserDept();
                            ddlMerchandiserDept.SelectedValue = Convert.ToString(order.Merch_Dept_Id);
                            GetMerchandiserName();
                            ddlMerchandiserName.SelectedValue = order.EID;
                            LoadPrincipalList();
                            ddlPrincipal.SelectedValue = order.Principal_Id.ToString();
                            LoadBuyerList();
                            ddlBuyer.SelectedValue = order.Buyer_Name;
                            ddlSeason.SelectedValue = Convert.ToString(order.SeasonId);

                            ddlFactory.SelectedValue = Convert.ToString(order.FactoryId);
                            ddlGender.SelectedValue = Convert.ToString(order.Gender_Id);

                            ddlUnit.SelectedValue = Convert.ToString(order.Unit_Id);
                            ddlStyle.SelectedValue = Convert.ToString(order.StyleId);
                            ddlCategory.SelectedValue = Convert.ToString(order.Style_Category_Id);
                            ddlCurrency.SelectedItem.Text = order.Currency;
                            txtFob.Text = Convert.ToString(order.UnitPrice);
                            txtOrderQty.Text = Convert.ToString(order.OrderQuantity);
                            txtFOBPort.Text = order.FOB_Port;
                            txtShipmentDate.Text = ConvertDate(order.ShipmentDate.ToString());
                            txtCommissionPer.Text = order.CommissionPersent.ToString();
                            txtTotalCommission.Text = order.TotalCommission.ToString();
                            txtOriginalContractDate.Text = ConvertDate(order.OrderReceiveDate.ToString());
                            txtOrderConfirmationDate.Text = ConvertDate(order.LC_Reveived_Date.ToString());
                            ddlShipmentMode.SelectedItem.Text = order.Shipment_Mode;
                            if (btnSubmit.Text == "Add")
                            {
                                btnSubmit.Text = "Update";
                            }
                        }
                    }
                }
                ShowDiv.Visible = true;
                ShowGrid.Visible = true;
                AddOrder.Visible = false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void ChkSeason_CheckedChanged(object sender, EventArgs e)
        {
            if (ChkSeason.Checked)
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

        private void GetMerchandiserName()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            int DepartmentId = Convert.ToInt32(ddlMerchandiserDept.SelectedValue);

            List<RFEmployee> row = new List<RFEmployee>();

            row = _SampleDetailsBLL.GetMerchandiserNameByDept(ocode, DepartmentId).ToList();
            if (row.Count > 0)
            {
                ddlMerchandiserName.DataSource = row.ToList();
                ddlMerchandiserName.DataTextField = "FullName";
                ddlMerchandiserName.DataValueField = "EID";
                ddlMerchandiserName.DataBind();
                ddlMerchandiserName.Items.Insert(0, new ListItem("--Select--", "0"));
            }
        }

        private string ConvertDate(string DateTime)
        {
            string[] dattime = DateTime.Split(' ');
            return dattime[0];
        }

        protected void AddOrder_Click(object sender, EventArgs e)
        {
            ShowDiv.Visible = true;
            ShowGrid.Visible = false;
            AddOrder.Visible = false;
        }

        private void ShowLCOrderGridByONo()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            string Order_No = txtS_OrderNo.Text;
            var result = masterBLL.GetLCOrderGridByONo(ocode, Order_No);
            if (result.Count > 0)
            {
                grdorder.DataSource = result.ToList();
                grdorder.DataBind();
            }
            else
            {
                grdorder.DataSource = null;
                grdorder.DataBind();
            }
        }

        protected void txtS_OrderNo_TextChanged(object sender, EventArgs e)
        {
            ShowLCOrderGridByONo();
        }

        private void LoadOrderByStyle()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_Style> row = _orderSheetbll.GetLC_Style(ocode);

                if (row != null)
                {
                    ddlS_Style.DataSource = row.ToList();
                    ddlS_Style.DataTextField = "StyleName";
                    ddlS_Style.DataValueField = "StyleId";
                    ddlS_Style.DataBind();
                    ddlS_Style.AppendDataBoundItems = false;
                    ddlS_Style.Items.Insert(0, new ListItem("--Select Style--", "0"));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchOrderNo(string prefixText, int count)
        {
            using (var _context = new ERPSSL_LCEntities())
            {
                var AllOrder = from lcN in _context.LC_OrderEntry
                               where lcN.OrderNo.Contains(prefixText)
                               select lcN;
                List<String> OrderList = new List<String>();
                foreach (var Order_No in AllOrder)
                {
                    OrderList.Add(Order_No.OrderNo);
                }
                return OrderList;
            }
        }

        protected void ddlS_Style_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowLCOrderGridByStyle();
        }

        private void ShowLCOrderGridByStyle()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            int StyleId = Convert.ToInt32(ddlS_Style.SelectedValue);
            var result = masterBLL.GetLCOrderGridByStyle(ocode, StyleId);
            if (result.Count > 0)
            {
                grdorder.DataSource = result.ToList();
                grdorder.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found With This Style')", true);
            }
        }

        private void LoadOrderByBuyer()
        {
            try
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<Com_Buyer_Setup> BuyerList = _orderSheetbll.GetBuyerS_NameL(OCode);
                if (BuyerList.Count > 0)
                {
                    ddlS_Buyer.DataSource = BuyerList.ToList();
                    ddlS_Buyer.DataTextField = "Buyer_Name";
                    ddlS_Buyer.DataValueField = "Buyer_ID";
                    ddlS_Buyer.DataBind();
                    ddlS_Buyer.AppendDataBoundItems = false;
                    ddlS_Buyer.Items.Insert(0, new ListItem("--Select Buyer--", "0"));
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected void ddlS_Buyer_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowLCOrderGridByBuyer();
        }

        private void ShowLCOrderGridByBuyer()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            int BuyerId = Convert.ToInt32(ddlS_Buyer.SelectedValue);
            var result = masterBLL.GetLCOrderGridByBuyer(ocode, BuyerId);
            if (result.Count > 0)
            {
                grdorder.DataSource = result.ToList();
                grdorder.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found With This Buyer')", true);
            }
        }

        protected void txtTotalAmount_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtOrderQty_TextChanged(object sender, EventArgs e)
        {
            decimal TotalAmount = Convert.ToDecimal(txtFob.Text) * Convert.ToDecimal(txtOrderQty.Text);
            txtTotalAmount.Text = TotalAmount.ToString();
        }

        protected void ddlMerchandiserDept_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetMerchandiserName();
        }

        protected void txtCommissionPer_TextChanged(object sender, EventArgs e)
        {
            decimal TotalCommision = (Convert.ToDecimal(txtTotalAmount.Text) * Convert.ToDecimal(txtCommissionPer.Text)) / 100;
            txtTotalCommission.Text = TotalCommision.ToString();
        }

        protected void txtOriginalContractDate_TextChanged(object sender, EventArgs e)
        {
            txtOrderConfirmationDate.Text = txtOriginalContractDate.Text;
        }

        protected void ddlBuyerDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void chkBuyerDepartment_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBuyerDepartment.Checked)
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

        protected void ddlS_Principal_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowLCOrderGridByPrincipal();
        }

        private void ShowLCOrderGridByPrincipal()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            int PrincipalId = Convert.ToInt32(ddlS_Principal.SelectedValue);
            var result = masterBLL.GetLCOrderGridByPrincipal(ocode, PrincipalId);
            if (result.Count > 0)
            {
                grdorder.DataSource = result.ToList();
                grdorder.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found With This Style')", true);
            }
        }

        protected void ddlS_Factory_SelectedIndexChanged(object sender, EventArgs e)
        {
            ShowLCOrderGridByFactory();
        }

        private void ShowLCOrderGridByFactory()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            int FactoryId = Convert.ToInt32(ddlS_Factory.SelectedValue);
            var result = masterBLL.GetLCOrderGridByFactory(ocode, FactoryId);
            if (result.Count > 0)
            {
                grdorder.DataSource = result.ToList();
                grdorder.DataBind();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No Data Found With This Factory')", true);
            }
        }

        protected void chkCategory_CheckedChanged(object sender, EventArgs e)
        {
            if (chkCategory.Checked)
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

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}