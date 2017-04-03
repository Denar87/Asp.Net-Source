using ERPSSL.BuyingHouse.BLL;
using ERPSSL.BuyingHouse.DAL.Repository;
using ERPSSL.HRM.BLL;
using ERPSSL.HRM.DAL.Repository;
using ERPSSL.INV.BLL;
using ERPSSL.LC.BLL;
using ERPSSL.LC.DAL;
using ERPSSL.LC.DAL.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.BuyingHouse
{
    public partial class OnGoingOrderUpdate : System.Web.UI.Page
    {
        OrderSheetBLL _orderSheetbll = new OrderSheetBLL();
        GroupBLL groupBll = new GroupBLL();
        ProductBLL productBll = new ProductBLL();
        MasterLCBLL masterBLL = new MasterLCBLL();
        InputTypeBLL inputTypeBll = new InputTypeBLL();
        EmployeeSetup_BLL employeeBll = new EmployeeSetup_BLL();
        SampleDetailsBLL _SampleDetailsBLL = new SampleDetailsBLL();

        private ERPSSL.LC.DAL.ERPSSL_LCEntities _Context = new ERPSSL.LC.DAL.ERPSSL_LCEntities();
        string orderNo = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    orderNo = Session["alblOrder_No"].ToString();
                    txtOrder.Text = orderNo;

                    FillSeason();
                    FillStyle();
                    OrderNumberDetails();
                    LoadGrid();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void OrderNumberDetails()
        {
            List<LC_OrderEntry> orders = new List<LC_OrderEntry>();

            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string orderNo = txtOrder.Text;

                List<OrderUpdateRepository> ObjectsList = masterBLL.GetOrderByOrderNoandOcode(orderNo, OCODE).ToList();

                if (ObjectsList.Count > 0)
                {
                    foreach (OrderUpdateRepository order in ObjectsList)
                    {
                        hidorderid.Value = order.OrderEntryID.ToString();
                        txtCustomerStyle.Text = order.Style_Description;
                        txtYarnFabrication.Text = order.Yarn_Fabrication;
                        txtTotalAmount.Text = order.Total_Amount.ToString();
                        LoadBuyingDepartmentList();
                        ddlBuyerDepartment.SelectedValue = order.Buyer_DepartmentId.ToString();
                        GetOffice();
                        ddlTTOffice.SelectedValue = order.Office_ID.ToString();
                        GetMerchandiserDept();
                        ddlMerchandiserDept.SelectedValue = order.Merch_Dept_Id.ToString();
                        GetMerchandiserName();
                        ddlMerchandiserName.SelectedValue = order.EID;
                        LoadPrincipalList();
                        ddlPrincipal.SelectedValue = order.Principal_Id.ToString();
                        LoadBuyerList();
                        ddlBuyer.SelectedValue = order.Buyer_Name;
                        FillSeason();
                        ddlSeason.SelectedValue = order.Season_Id.ToString();
                        GetFactory();
                        ddlFactory.SelectedValue = order.FactoryId.ToString();
                        GetGenderList();
                        ddlGender.SelectedValue = order.Gender_Id.ToString();
                        GetUnit();
                        ddlUnit.SelectedValue = order.UnitId.ToString();
                        ddlStyle.SelectedValue = order.StyleId.ToString();
                        GetQuotaOrCategory();
                        ddlCategory.SelectedValue = order.Style_Category_Id.ToString();
                        ddlCurrency.SelectedItem.Text = order.Currency;
                        txtFob.Text = Convert.ToString(order.FobQty);
                        txtOrderQty.Text = Convert.ToString(order.OrderQuantity);
                        txtFOBPort.Text = order.FOB_Port;
                        txtCommissionPer.Text = order.CommissionPersent.ToString();
                        txtTotalCommission.Text = order.TotalCommission.ToString();
                        ddlShipmentMode.SelectedItem.Text = order.Shipment_Mode;
                        InsertProductionProcess();

                        LoadTaskDetails();
                    }
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

        private void InsertProductionProcess()
        {
            try
            {
                bool isOrderExist = masterBLL.isTaskOrderExist(txtOrder.Text);
                if (isOrderExist != true)
                {
                    string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                    List<LC_InputType> InputType = inputTypeBll.GetALLTask(OCode);
                    if (InputType.Count > 0)
                    {

                        foreach (var item in InputType)
                        {

                            LC_Task_Details aLC_Task_Details = new LC_Task_Details();


                            aLC_Task_Details.Task = item.Input_Name;
                            aLC_Task_Details.Order_No = txtOrder.Text;
                            aLC_Task_Details.Schedule_Date = null;
                            aLC_Task_Details.Responsible_Person = null;
                            aLC_Task_Details.Status = "Pending";

                            aLC_Task_Details.EditDate = DateTime.Today;
                            aLC_Task_Details.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                            aLC_Task_Details.Create_Date = DateTime.Today;
                            aLC_Task_Details.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                            aLC_Task_Details.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                            int result1 = masterBLL.InsertTaskDetails(aLC_Task_Details);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadTask()
        {
            try
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<LC_InputType> InputType = inputTypeBll.GetALLTask(OCode);
                if (InputType.Count > 0)
                {
                    GridTask.DataSource = InputType;
                    GridTask.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void LoadGrid()
        {
            
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

        //private void FillSeason()
        //{
        //    try
        //    {
        //        string ocode = ((SessionUser)Session["SessionUser"]).OCode;
        //        List<Rep_MasterLC> row = _orderSheetbll.GetOrderByDistrinct(ocode);

        //        if (row != null)
        //        {
        //            ddlSeason.DataSource = row.ToList();
        //            ddlSeason.DataTextField = "SeasonName";
        //            ddlSeason.DataValueField = "MlcID";
        //            ddlSeason.DataBind();
        //            ddlSeason.AppendDataBoundItems = false;
        //            ddlSeason.Items.Insert(0, new ListItem("--Select Season--", "0"));

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                LC_OrderEntry orderEntry = new LC_OrderEntry();

                string seasonname = ddlSeason.SelectedItem.ToString();
                string[] values = seasonname.Split('-');
                orderEntry.Season = values[0].ToString();
                //orderEntry.Buyer_Department = txtBuyerDepartment.Text;
                orderEntry.OrderNo = txtOrder.Text;
              
                orderEntry.Create_Date = DateTime.Today;
                orderEntry.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                orderEntry.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                
                int orderid = Convert.ToInt32(hidorderid.Value);
                var result = masterBLL.UpdateOrderEntry(orderEntry, orderid);
                if (result == 1)
                {

                   
                    lblMessageUpdate.Text = "Data Update Successfully";
                   
                }
                GridTask.Visible = false;
                Clear();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public void Clear()
        {
            txtOrder.Text = "";
        }

        protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime day = DateTime.Today;
            int id = Convert.ToInt32(ddlSeason.SelectedValue);

            List<Rep_MasterLC> result = _orderSheetbll.GetLC_MasterLC(id);
            if (result.Count > 0)
            {
                var mm = result.First();
               
            }
        }

        protected void txtFob_TextChanged(object sender, EventArgs e)
        {
        }

        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchLCNo(string prefixText, int count)
        {
            using (var _context = new ERPSSL_LCEntities())
            {
                var AllOrder = from lcN in _context.LC_OrderEntry
                               where lcN.CompShipmentDate == null && ((lcN.OrderNo.Contains(prefixText)))
                               select lcN;
                List<String> OrderList = new List<String>();
                foreach (var Order_No in AllOrder)
                {
                    OrderList.Add(Order_No.OrderNo);
                }
                return OrderList;
            }
        }

        protected void txtOrder_TextChanged(object sender, EventArgs e)
        {
        //    List<LC_OrderEntry> orders = new List<LC_OrderEntry>();

        //    try
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        string orderNo = txtOrder.Text;

        //        List<OrderUpdateRepository> ObjectsList = masterBLL.GetOrderByOrderNoandOcode(orderNo, OCODE).ToList();

        //        if (ObjectsList.Count > 0)
        //        {
        //            foreach (OrderUpdateRepository order in ObjectsList)
        //            {
        //                hidorderid.Value = order.OrderEntryID.ToString();
        //                txtCustomerStyle.Text = order.Style_Description;
        //                txtYarnFabrication.Text = order.Yarn_Fabrication;
        //                txtTotalAmount.Text = order.Total_Amount.ToString();
        //                LoadBuyingDepartmentList();
        //                ddlBuyerDepartment.SelectedValue = order.Buyer_DepartmentId.ToString();
        //                GetOffice();
        //                ddlTTOffice.SelectedValue = order.Office_ID.ToString();
        //                GetMerchandiserDept();
        //                ddlMerchandiserDept.SelectedValue = order.Merch_Dept_Id.ToString();
        //                GetMerchandiserName();
        //                ddlMerchandiserName.SelectedValue = order.EID;
        //                LoadPrincipalList();
        //                ddlPrincipal.SelectedValue = order.Principal_Id.ToString();
        //                LoadBuyerList();
        //                ddlBuyer.SelectedValue = order.Buyer_Name;
        //                FillSeason();
        //                ddlSeason.SelectedValue = order.Season_Id.ToString();
        //                GetFactory();
        //                ddlFactory.SelectedValue = order.FactoryId.ToString();
        //                GetGenderList();
        //                ddlGender.SelectedValue = order.Gender_Id.ToString();
        //                GetUnit();
        //                ddlUnit.SelectedValue = order.UnitId.ToString();
        //                ddlStyle.SelectedValue = order.StyleId.ToString();
        //                GetQuotaOrCategory();
        //                ddlCategory.SelectedValue = order.Style_Category_Id.ToString();
        //                ddlCurrency.SelectedItem.Text = order.Currency;
        //                txtFob.Text = Convert.ToString(order.FobQty);
        //                txtOrderQty.Text = Convert.ToString(order.OrderQuantity);
        //                txtFOBPort.Text = order.FOB_Port;
        //                txtCommissionPer.Text = order.CommissionPersent.ToString();
        //                txtTotalCommission.Text = order.TotalCommission.ToString();
        //                ddlShipmentMode.SelectedItem.Text = order.Shipment_Mode;
        //                InsertProductionProcess();

        //                LoadTaskDetails();
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        }

        private void LoadTaskDetails()
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            string orderNo = txtOrder.Text;
            List<ItemList> aItemList = new List<ItemList>();
            aItemList = masterBLL.GetTaskDetailsByOrderNo(orderNo, OCODE).ToList();

            if (aItemList.Count > 0)
            {
                GridTask.DataSource = aItemList;
                GridTask.DataBind();
            }
        }

        protected void GridTask_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                GridTask.PageIndex = e.NewPageIndex;
                LoadTaskDetails();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridTask_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            try
            {
                GridTask.EditIndex = -1;
                LoadTaskDetails();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridTask_RowEditing(object sender, GridViewEditEventArgs e)
        {
            try
            {
                GridTask.EditIndex = e.NewEditIndex;
                LoadTaskDetails();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void GridTask_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = GridTask.Rows[e.RowIndex];


            Label lblID = (Label)row.FindControl("lblID");
            int ID = Convert.ToInt32(lblID.Text);
            TextBox txtTergetQty = ((TextBox)row.FindControl("txtTergetQty"));
            TextBox txtSchedule_Date = ((TextBox)row.FindControl("txtSchedule_Date"));
            DropDownList ddlStatus = ((DropDownList)row.FindControl("ddlStatus"));
            DropDownList ddlResposiblePerson = ((DropDownList)row.FindControl("ddlResposiblePerson"));

            TextBox txtComments = ((TextBox)row.FindControl("txtComments"));

            LC_Task_Details aLC_Task_Details = new LC_Task_Details();

            aLC_Task_Details.Order_No = txtOrder.Text;

            DateTime? nullabledate = null;

            aLC_Task_Details.Schedule_Date = txtSchedule_Date.Text == "" ? nullabledate : Convert.ToDateTime(txtSchedule_Date.Text);
            aLC_Task_Details.Responsible_Person = ddlResposiblePerson.SelectedValue;
            aLC_Task_Details.Status = ddlStatus.SelectedValue;
            aLC_Task_Details.Comments = txtComments.Text;
            aLC_Task_Details.EditDate = DateTime.Today;
            aLC_Task_Details.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
            aLC_Task_Details.OCode = ((SessionUser)Session["SessionUser"]).OCode;

            int result1 = masterBLL.UpdateTaskDetails(aLC_Task_Details, ID);

            if (result1 == 1)
            {


                GridTask.EditIndex = -1;
                LoadTaskDetails();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);

            }

        }

        protected void GridTask_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            DropDownList ddlStatus = null;
            DropDownList ddlResposiblePerson = null;

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                ddlStatus = e.Row.FindControl("ddlStatus") as DropDownList;
                ddlResposiblePerson = e.Row.FindControl("ddlResposiblePerson") as DropDownList;

            }
            if (ddlStatus != null)
            {
                ddlStatus.DataBind();
                ddlStatus.Items.Insert(0, new ListItem("Pending", "Pending"));
                ddlStatus.Items.Insert(1, new ListItem("Done", "Done"));
                ddlStatus.Items.Insert(2, new ListItem("On going", "On going"));

                ItemList dr = e.Row.DataItem as ItemList;

                ddlStatus.SelectedValue = dr.Status;

            }
            if (ddlResposiblePerson != null)
            {
                string OCode = ((SessionUser)Session["SessionUser"]).OCode;

                List<RFEmployee> row = new List<RFEmployee>();

                row = _SampleDetailsBLL.GetMerchandiserNameByName(OCode).ToList();
                if (row.Count > 0)
                {
                    ddlResposiblePerson.DataSource = row.ToList();
                    ddlResposiblePerson.DataTextField = "FullName";
                    ddlResposiblePerson.DataValueField = "EID";
                    ddlResposiblePerson.DataBind();
                    ddlResposiblePerson.Items.Insert(0, new ListItem("--Select--", "0"));
                }

                ItemList dr = e.Row.DataItem as ItemList;

                ddlResposiblePerson.SelectedItem.Text = dr.Responsible_Person;
            }
        }
    }
}