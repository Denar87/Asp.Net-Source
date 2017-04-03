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
    public partial class PendingTask1 : System.Web.UI.Page
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
                   // txtStyle.Text = Convert.ToString(DateTime.Now);

                    OrderNumberDetails();
                    LoadGrid();
                    //LoadTask();
                    //orderEdit.Visible = false;
                   
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
                        FillSeason();
                        //ddlSeason.SelectedValue = order.Season.ToString();   
                        ddlSeason.SelectedItem.Text = order.Season_Name;
                        txtStyle.Text = order.Style.ToString();
                        // txtOrder.Text = order.OrderNo;
                        txtPrincpal.Text = order.Factory_Id.ToString();
                        txtTTOffice.Text = order.Office_Id.ToString();
                        txtMerchandiserDpt.Text = order.DepartmentName;
                        txtMerchandiserName.Text = order.FullName.ToString();
                        //txtMerchandiserDpt.Text = order.Merchandiser_Dept_Id.ToString();
                        //txtMerchandiserName.Text = order.Merchandiser_Id.ToString();
                        txtBuyerDepartment.Text = order.BuyerDepartmetn.ToString();
                        txtBuyer.Text = order.Buyer_Id.ToString();
                        txtStylType.Text = order.Gender_Id.ToString();
                        txtQuota.Text = order.Category_Id.ToString();
                        txtCustom.Text = order.Style_Description.ToString();
                        txtTrading.Text = order.Trading.ToString();
                        txtQuotationTerms.Text = order.Quotation_Terms.ToString();
                        txtFreight.Text = order.Freight.ToString();
                        txtShipmentMode.Text = order.Shipment_Mode.ToString();
                        txtPaymentTerms.Text = order.PaymentTerms.ToString();
                        txtCountryProduction.Text = order.CountryOf_Production.ToString();
                        txtGarmentMaker.Text = order.Garment_Maker.ToString();
                        txtBuyerPrice.Text = order.FobQty.ToString();
                        txtCurrency.Text = order.Currency.ToString();
                        txtContractQty.Text = order.OrderQuantity.ToString();
                        txtUnit.Text = order.Unit_Id.ToString();
                        txtTotalAmount.Text = order.TotalAmount.ToString();


                        //ddlStyle.SelectedItem.Text = order.Style.ToString();
                        //txtOrderQty.Text = order.OrderQuantity;
                        //txtFob.Text = Convert.ToString(order.FobQty);
                        //txtDate.Text = Convert.ToString(order.ShipmentDate);
                        // hidLcNo.Value = order.LCNo.ToString();
                        // txtValue.Text = Convert.ToString(order.TotalQty);
                        // txtsize.Text = order.Size;
                        //txtSupplierNo.Text = order.Supplier_No;
                        // txtStyle.Text =order.Style.ToString();
                        // txtBuyerDepartment.Text = order.Buyer_Department;
                        // txtDeliveryDate.Text = Convert.ToString(order.Delivery_Date);
                        //txtYarnFabrication.Text = order.Yarn_Fabrication;
                        //txtLCReceivedDate.Text = Convert.ToString(order.LC_Reveived_Date);
                        // ddlShipmentMode.SelectedItem.Text = order.Shipment_Mode;
                        // txtScheduleDate.Text = Convert.ToString(order.Schedule_Date);
                        //txtTTOffice.Text = order.Office_ID.ToString();
                        //txtFOBPort.Text = order.FOB_Port;
                        //orderEdit.Visible = true;
                        // LoadTask();

                        //hidRegionName.Value = txtbxRegionName.Text = region.RegionName;
                        //txtbxResgionCode.Text = region.RegionCode;
                        //if (btnSubmit.Text == "Add")
                        //{
                        //    btnSubmit.Text = "Update";
                        //}
                        InsertProductionProcess();

                        LoadTaskDetails();
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
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



        //protected void dtg_list_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    DropDownList ddl = null;
        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {
        //        ddl = e.Row.FindControl("ddlResponsiblePerson") as DropDownList;
        //    }
        //    if (ddl != null)
        //    {
        //        string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //        // Hashtable ht = new Hashtable();

        //        //ht.Add("Company_Code", CompanyCode);
        //        // ht.Add("OCode", OCODE);

        //        //DataTable dt = objGrp_BL.GetGroupheadList(ht);
        //        //List<REmployee> employees = employeeBll.GetEmployees(OCODE).ToList();
        //        List<REmployee> employees = masterBLL.GetResponsiblePerson(OCODE).ToList();
        //        if (employees.Count > 0)
        //        {
        //            ddl.DataSource = employees;
        //            ddl.DataValueField = "EID";
        //            ddl.DataTextField = "FirstName";
        //            ddl.DataBind();
        //        }
        //    }
        //}


        //private void LoadAllActive_EmployeeList()
        //{
        //    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //    List<REmployee> employees = employeeBll.GetEmployees(OCODE).ToList();

        //    ddlResponsiblePerson.DataSource = employees;
        //    //ddlEmployee.DataValueField = "EID";
        //    //ddlEmployee.DataTextField = "FullName";
        //    //ddlEmployee.DataBind();
        //    //ddlEmployee.Items.Insert(0, new ListItem("---Select One---", "0"));
        //}

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
            //string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            //var result = masterBLL.GetAllOrderByOcode(ocode);
            //if (result.Count > 0)
            //{
            //    grdorder.DataSource = result.ToList();
            //    grdorder.DataBind();

            //}
            //else
            //{
            //    grdorder.DataSource = null;
            //    grdorder.DataBind();
            //}

        }
        private void FillStyle()
        {
            try
            {
                string ocode = ((SessionUser)Session["SessionUser"]).OCode;
                List<LC_Style> row = _orderSheetbll.GetLC_Style(ocode);


                if (row != null)
                {
                    //ddlStyle.DataSource = row.ToList();
                    //ddlStyle.DataTextField = "StyleName";
                    //ddlStyle.DataValueField = "StyleId";
                    //ddlStyle.DataBind();
                    //ddlStyle.AppendDataBoundItems = false;
                    //ddlStyle.Items.Insert(0, new ListItem("--Select Style--", "0"));

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
                List<Rep_MasterLC> row = _orderSheetbll.GetOrderByDistrinct(ocode);

                if (row != null)
                {
                    ddlSeason.DataSource = row.ToList();
                    ddlSeason.DataTextField = "SeasonName";
                    ddlSeason.DataValueField = "MlcID";
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

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                LC_OrderEntry orderEntry = new LC_OrderEntry();

                string seasonname = ddlSeason.SelectedItem.ToString();
                string[] values = seasonname.Split('-');
               // orderEntry.OrderReceiveDate = txtStyle.Text;
                orderEntry.Season = values[0].ToString();
                orderEntry.Buyer_Department = txtBuyerDepartment.Text;
               // orderEntry.Supplier_No = txtSupplierNo.Text;
                orderEntry.OrderNo = txtOrder.Text;
                //orderEntry.LCNo = hidLcNo.Value;
               // orderEntry.Article = txtArticle.Text;
                //orderEntry.ColorSpecification = txtColor.Text;
               // orderEntry.OrderQuantity = txtOrderQty.Text;
                //orderEntry.FobQty = Convert.ToDouble(txtFob.Text);
                //orderEntry.Style = ddlStyle.SelectedItem.Text;


                //if (chkNewstyle.Checked == true)
                //{
                //    orderEntry.Style = txtStyle.Text;
                //}
                //else
                //{
                //  orderEntry.Style = ddlStyle.SelectedItem.Text;
                //}
               // orderEntry.Size = txtsize.Text;
                //orderEntry.Comments = txtComments.Text;
               // orderEntry.ShipmentDate = Convert.ToDateTime(txtDate.Text);
               // orderEntry.Delivery_Date = Convert.ToDateTime(txtDeliveryDate.Text);
               // orderEntry.Yarn_Fabrication = txtYarnFabrication.Text;
               // orderEntry.LC_Reveived_Date = Convert.ToDateTime(txtLCReceivedDate.Text);
               // orderEntry.Schedule_Date = Convert.ToDateTime(txtScheduleDate.Text);
               // orderEntry.ShipmentMode = txtShipmentMode.Text;
                orderEntry.Create_Date = DateTime.Today;
                orderEntry.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                orderEntry.OCODE = ((SessionUser)Session["SessionUser"]).OCode;
               // orderEntry.TotalQty = Convert.ToDouble(txtValue.Text);

                //if (btnSubmit.Text == "Add")
                //{
                //    var result = masterBLL.InsertOrderEntry(orderEntry);
                //    if (result == 1)
                //    {
                //        lblMessage.Text = "Data Saved Successfully";
                //        txtBuyerDepartment.Focus();
                //        //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Saved Successfully')", true);



                //    }
                //}

                //else
                //{
                int orderid = Convert.ToInt32(hidorderid.Value);
                var result = masterBLL.UpdateOrderEntry(orderEntry, orderid);
                if (result == 1)
                {
                   
                    //foreach (GridViewRow gvRow in GridTask.Rows)
                    //{

                    //    //CheckBox rowChkBox = ((CheckBox)gvRow.FindControl("rowTaskCheckBox"));

                    //    //if (rowChkBox.Checked == true)
                    //    //{
                    //        Label lblInput_Name = ((Label)gvRow.FindControl("lblInput_Name"));
                    //        TextBox ScheduleDate = ((TextBox)gvRow.FindControl("txtScheduleDate"));
                    //        DropDownList ddlStatus = ((DropDownList)gvRow.FindControl("ddlstatus"));
                    //        DropDownList ddlResponsiblePerson = ((DropDownList)gvRow.FindControl("ddlResponsiblePerson"));
                    //        TextBox txtComent = ((TextBox)gvRow.FindControl("txtComments"));

                    //        //Label lblWorkingDay = ((Label)gvRow.FindControl("lblWorkingDay"));

                    //        LC_Task_Details aLC_Task_Details = new LC_Task_Details();



                    //        aLC_Task_Details.Task = lblInput_Name.Text;
                    //        aLC_Task_Details.Order_No = txtOrder.Text;
                    //        aLC_Task_Details.Schedule_Date = Convert.ToDateTime(ScheduleDate.Text);
                    //        aLC_Task_Details.Responsible_Person = ddlResponsiblePerson.Text;
                    //        aLC_Task_Details.Status = ddlStatus.Text;

                    //        aLC_Task_Details.EditDate = DateTime.Today;
                    //        aLC_Task_Details.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
                    //        aLC_Task_Details.Create_Date = DateTime.Today;
                    //        aLC_Task_Details.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
                    //        aLC_Task_Details.OCode = ((SessionUser)Session["SessionUser"]).OCode;

                    //        int result1 = masterBLL.InsertTaskDetails(aLC_Task_Details); 

                    //    //}

                       
                    //}                  
                    

                    lblMessageUpdate.Text = "Data Update Successfully";
                    //ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Successfully')", true);

                }
                //}

                // LoadGrid(lblLCNo.Text.ToString());
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
           // ddlStyle.ClearSelection();
            //ddlSeason.ClearSelection();
          //  txtDate.Text = "";
           // txtColor.Text = "";
           // txtArticle.Text = "";
           // txtFob.Text = "0";
            txtOrder.Text = "";
           // txtOrderQty.Text = "0";
           // txtValue.Text = "";
            //txtStyle.Text = "";
           // txtsize.Text = "";
           // txtComments.Text = "";
            // txtSupplierNo.Text = "";
            // txtOrderReceivedDate.Text = "";
            //txtBuyerDepartment.Text = "";



        }



        protected void ddlSeason_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime day = DateTime.Today;
            //txtAutoOrderId.Text = _orderSheetbll.GetNewChalanNo("OPLC-", day, ddlSeason.Text.ToString());
            //FillStyle(ddlSeason.SelectedItem.Text);
            int id = Convert.ToInt32(ddlSeason.SelectedValue);

            List<Rep_MasterLC> result = _orderSheetbll.GetLC_MasterLC(id);
            if (result.Count > 0)
            {
                var mm = result.First();
                //lblBayername.Text = mm.BayerName.ToString();
                //lblLCNo.Text = mm.LCNo.ToString();
                //grdRequisition.DataSource = result;
                //grdRequisition.DataBind();

            }
            //LoadGrid(lblLCNo.Text.ToString());
        }

        protected void txtFob_TextChanged(object sender, EventArgs e)
        {
            //double qty = Convert.ToDouble(txtOrderQty.Text);
            //double fob = Convert.ToDouble(txtFob.Text);
            //double totalvalue = qty * fob;
            //txtValue.Text = totalvalue.ToString();
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

        }

        private void LoadTaskDetails()
        {
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            string orderNo = txtOrder.Text;
            //List<LC_Task_Details> aTask_Details = new List<LC_Task_Details>();

            //aTask_Details = masterBLL.GetTaskDetailsByOrderNoandOcode(orderNo, OCODE);



            List<ItemList> aItemList = new List<ItemList>();
            aItemList = masterBLL.GetTaskDetailsByOrderNo(orderNo,OCODE).ToList();


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
            // Label lblID = (Label)row.FindControl("Label1");
            int ID = Convert.ToInt32(lblID.Text);
            TextBox txtTergetQty = ((TextBox)row.FindControl("txtTergetQty"));
            TextBox txtSchedule_Date = ((TextBox)row.FindControl("txtSchedule_Date"));
            DropDownList ddlStatus = ((DropDownList)row.FindControl("ddlStatus"));
            DropDownList ddlResposiblePerson = ((DropDownList)row.FindControl("ddlResposiblePerson"));

            TextBox txtComments = ((TextBox)row.FindControl("txtComments"));



            LC_Task_Details aLC_Task_Details = new LC_Task_Details();



            aLC_Task_Details.Order_No = txtOrder.Text;

            DateTime? nullabledate = null;
            

            aLC_Task_Details.Schedule_Date = txtSchedule_Date.Text==""?nullabledate: Convert.ToDateTime(txtSchedule_Date.Text);
            aLC_Task_Details.Responsible_Person = ddlResposiblePerson.SelectedValue;
            aLC_Task_Details.Status = ddlStatus.SelectedValue;
            aLC_Task_Details.Comments = txtComments.Text;
            aLC_Task_Details.EditDate = DateTime.Today;
            aLC_Task_Details.EditUser = ((SessionUser)Session["SessionUser"]).UserId;
            aLC_Task_Details.OCode = ((SessionUser)Session["SessionUser"]).OCode;

            int result1 = masterBLL.UpdateTaskDetails(aLC_Task_Details, ID);

            if (result1 == 1)
            {           
             

                //GridTask.EditIndex = -1;
                //LoadTaskDetails();
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Updated Sucessfully')", true);

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
                //int DepartmentId = Convert.ToInt32(ddlResposiblePerson.SelectedValue);

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

                //var result = masterBLL.GetAllResposiblePerson();
                //ddlResposiblePerson.DataSource = result;
                //ddlResposiblePerson.DataTextField = "FirstName";
                //ddlResposiblePerson.DataValueField = "EID";
                //ddlResposiblePerson.DataBind();
                //ddlResposiblePerson.Items.Insert(0, new ListItem("Select One", "0"));

                ItemList dr = e.Row.DataItem as ItemList;

                ddlResposiblePerson.SelectedItem.Text = dr.Responsible_Person;

              //  Label lblResposiblePerson = ((Label)row.FindControl("lblResposiblePerson"));
                //DataRowView dr = e.Row.DataItem as DataRowView;
                //ddlResposiblePerson.SelectedValue = dr["lblResposiblePerson"].ToString();
            }

        }

    }
}