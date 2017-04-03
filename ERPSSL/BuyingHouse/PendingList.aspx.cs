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
    public partial class PendingList : System.Web.UI.Page
    {
        OrderSheetBLL _orderSheetbll = new OrderSheetBLL();
        GroupBLL groupBll = new GroupBLL();
        ProductBLL productBll = new ProductBLL();
        MasterLCBLL masterBLL = new MasterLCBLL();
        InputTypeBLL inputTypeBll = new InputTypeBLL();
        EmployeeSetup_BLL employeeBll = new EmployeeSetup_BLL();

        private ERPSSL.LC.DAL.ERPSSL_LCEntities _Context = new ERPSSL.LC.DAL.ERPSSL_LCEntities();

        

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    //orderNo = Session["alblOrder_No"].ToString();
                    LoadPendingList();             
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
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
        //       // Hashtable ht = new Hashtable();

        //        //ht.Add("Company_Code", CompanyCode);
        //       // ht.Add("OCode", OCODE);

        //        //DataTable dt = objGrp_BL.GetGroupheadList(ht);
        //        List<REmployee> employees = employeeBll.GetEmployees(OCODE).ToList();
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

      
        private void LoadPendingList()
        {
            string ocode = ((SessionUser)Session["SessionUser"]).OCode;
            var result = masterBLL.GetAllPendingTaskByOcode(ocode);
            if (result.Count > 0)
            {
                GridPendingList.DataSource = result.ToList();
                GridPendingList.DataBind();

            }
            else
            {
                GridPendingList.DataSource = null;
                GridPendingList.DataBind();
            }

        }
       


      

        private string ConvertDate(string DateTime)
        {
            string[] dattime = DateTime.Split(' ');
            return dattime[0];
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
          

        }
        public void Clear()
        {
           

        }



      

       

       

      

       

      

        protected void txtOrder_TextChanged(object sender, EventArgs e)
        {
            //List<LC_OrderEntry> orders = new List<LC_OrderEntry>();

            

            //try
            //{


            //    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
            //    string orderNo = txtOrder.Text;

            //    orders = masterBLL.GetOrderByOrderNoandOcode(orderNo, OCODE);

            //    if (orders.Count > 0)
            //    {
            //        foreach (LC_OrderEntry order in orders)
            //        {


            //            hidorderid.Value = order.OrderEntryID.ToString();
            //            FillSeason();
            //            //ddlSeason.SelectedValue = order.Season.ToString();   
            //            ddlSeason.SelectedItem.Text = order.Season;
            //           // txtOrder.Text = order.OrderNo;
            //            txtArticle.Text = order.Article;
            //            txtColor.Text = order.ColorSpecification;
            //            ddlStyle.SelectedItem.Text = order.Style;
            //            txtOrderQty.Text = order.OrderQuantity;
            //            txtFob.Text = Convert.ToString(order.FobQty);
            //            txtDate.Text = ConvertDate(order.ShipmentDate.ToString());//Convert.ToString(order.ShipmentDate);
            //            hidLcNo.Value = order.LCNo.ToString();
            //            txtValue.Text = Convert.ToString(order.TotalQty);
            //            txtsize.Text = order.Size;
            //            txtSupplierNo.Text = order.Supplier_No;
            //            txtOrderReceivedDate.Text = ConvertDate(order.OrderReceiveDate.ToString());//Convert.ToString(order.OrderReceiveDate);
            //            txtBuyerDepartment.Text = order.Buyer_Department;
            //            txtDeliveryDate.Text = Convert.ToString(order.Delivery_Date);
            //            txtYarnFabrication.Text = order.Yarn_Fabrication;
            //            txtLCReceivedDate.Text = ConvertDate(order.LC_Reveived_Date.ToString());//Convert.ToString(order.LC_Reveived_Date);
            //            ddlShipmentMode.SelectedItem.Text = order.Shipment_Mode;
            //            txtScheduleDate.Text = Convert.ToString(order.Schedule_Date);
            //            txtPreOrderNo.Text = order.Pre_OrderNo;
            //            txtFOBPort.Text = order.FOB_Port;
            //            //orderEdit.Visible = true;
            //            LoadTask();

            //            //hidRegionName.Value = txtbxRegionName.Text = region.RegionName;
            //            //txtbxResgionCode.Text = region.RegionCode;
            //            //if (btnSubmit.Text == "Add")
            //            //{
            //            //    btnSubmit.Text = "Update";
            //            //}
            //        }
            //    }
            //    //List<LC_Task_Details> aTask_Details = new List<LC_Task_Details>();

            //    //aTask_Details = masterBLL.GetTaskDetailsByOrderNoandOcode(orderNo, OCODE);
            //    //if (aTask_Details.Count > 0)
            //    //{
            //    //    GridTask.DataSource = aTask_Details;
            //    //    GridTask.DataBind();
            //    //}



            //}
            //catch (Exception ex)
            //{

            //    throw;
            //}
        }

        protected void imgbtnPendingOrderEdit_Click(object sender, ImageClickEventArgs e)
        {

            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            Label lblOrder_No = (Label)GridPendingList.Rows[row.RowIndex].FindControl("lblOrder_No");

            Session["alblOrder_No"]=lblOrder_No.Text;
            Response.Redirect("PendingTask.aspx");
        }

      

       

    }
}