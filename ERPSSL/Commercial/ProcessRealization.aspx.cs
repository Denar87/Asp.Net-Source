using ERPSSL.Production.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.Production.DAL.Repository;
using ERPSSL.LC.DAL;

namespace ERPSSL.Commercial
{
    public partial class ProcessRealization : System.Web.UI.Page
    {
        PlanningBLL _PlanningBLL = new PlanningBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    LoadOrders();
                    //LoadLine();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }
        protected void LoadOrders()
        {
            if (txtOrderNo.Text == "")
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                List<OrderDetails> result = _PlanningBLL.GetOrdersDetails(OCODE);
                if (result.Count > 0)
                {
                    grdOrderDetails.DataSource = result.ToList();
                    grdOrderDetails.DataBind();
                }
                else
                {
                    var obj = new List<OrderDetails>();
                    obj.Add(new OrderDetails());

                    // Bind the DataTable which contain a blank row to the GridView
                    grdOrderDetails.DataSource = obj;
                    grdOrderDetails.DataBind();

                    int columnsCount = grdOrderDetails.Columns.Count;
                    grdOrderDetails.Rows[0].Cells.Clear();// clear all the cells in the row
                    grdOrderDetails.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    grdOrderDetails.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell


                    grdOrderDetails.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    grdOrderDetails.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    grdOrderDetails.Rows[0].Cells[0].Font.Bold = true;

                    //set No Results found to the new added cell
                    grdOrderDetails.Rows[0].Cells[0].Text = "NO RECORDS FOUND FOR TODAY!";
                }
            }
            else
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string orderNo = txtOrderNo.Text;
                List<OrderDetails> orders = _PlanningBLL.GetOrdersDetailsByOrderNo(orderNo, OCODE);
                if (orders.Count > 0)
                {
                    grdOrderDetails.DataSource = orders.ToList();
                    grdOrderDetails.DataBind();
                }
                else
                {
                    var obj = new List<OrderDetails>();
                    obj.Add(new OrderDetails());

                    // Bind the DataTable which contain a blank row to the GridView
                    grdOrderDetails.DataSource = obj;
                    grdOrderDetails.DataBind();

                    int columnsCount = grdOrderDetails.Columns.Count;
                    grdOrderDetails.Rows[0].Cells.Clear();// clear all the cells in the row
                    grdOrderDetails.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    grdOrderDetails.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell


                    grdOrderDetails.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    grdOrderDetails.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    grdOrderDetails.Rows[0].Cells[0].Font.Bold = true;

                    //set No Results found to the new added cell
                    grdOrderDetails.Rows[0].Cells[0].Text = "NO RECORDS FOUND FOR !";
                }

            }


        }

        //protected void txtOrderNo_OnTextChanged(object sender, EventArgs e)
        //{
        //    LoadOrders();
        //}
        protected void imgbtnOrderDetails_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton imgbtn = (ImageButton)sender;
            GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

            Label lblId = (Label)grdOrderDetails.Rows[row.RowIndex].FindControl("lblId");
            Label lblBuyerID = (Label)grdOrderDetails.Rows[row.RowIndex].FindControl("lblBuyerID");
            Label lblFinishedGoods_Qty = (Label)grdOrderDetails.Rows[row.RowIndex].FindControl("lblFinishedGoods_Qty");
            Label lblFinishedGoods_ID = (Label)grdOrderDetails.Rows[row.RowIndex].FindControl("lblFinishedGoods_ID");
            Label lblFinishedGoodsName = (Label)grdOrderDetails.Rows[row.RowIndex].FindControl("lblFinishedGoodsName");
            Label lblLc_Order = (Label)grdOrderDetails.Rows[row.RowIndex].FindControl("lblLc_Order");
            Session["Lc_Order"] = lblLc_Order.Text;
            txtOrderQuantity.Text = lblFinishedGoods_Qty.Text;
            txtItemDescription.Text = lblFinishedGoodsName.Text;

        }

        //protected void btn_PlanningSave_OnClick(object sender, EventArgs e)
        //{

        //    Prod_Planning _Prod_Planning = new Prod_Planning();
        //    _Prod_Planning.PlanNo = AutoGenaratedPlanNo();
        //    Session["PlanNo"] = AutoGenaratedPlanNo();
        //    _Prod_Planning.ItemDescription = txtItemDescription.Text;
        //    _Prod_Planning.OrderQuantity = Convert.ToDouble(txtOrderQuantity.Text);
        //    _Prod_Planning.OrderNo = Session["Lc_Order"].ToString();
        //    _Prod_Planning.ShipmentDate = Convert.ToDateTime(txtShipmentDate.Text);
        //    _Prod_Planning.FromDate = Convert.ToDateTime(txtFromDate.Text);
        //    _Prod_Planning.ToDate = Convert.ToDateTime(txtToDate.Text);
        //    _Prod_Planning.TotalDays = Convert.ToDouble(txtTotalDays.Text);
        //    _Prod_Planning.DailyTarget = Convert.ToDouble(txtDailyTarget.Text);
        //    //_Prod_Planning.TotalTarget = Convert.ToDouble(txtTotalTarget.Text);
        //    _Prod_Planning.DailyPerLineTarget = Convert.ToDouble(txtDailyPerLineTarget.Text);
        //    _Prod_Planning.TotalLine = Convert.ToDouble(txtTotalLine.Text);
        //    _Prod_Planning.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
        //    _Prod_Planning.Create_Date = DateTime.Today;
        //    _Prod_Planning.OCode = ((SessionUser)Session["SessionUser"]).OCode;

        //    int result = _PlanningBLL.SavePlan(_Prod_Planning);
        //    if (result == 1)
        //    {
        //        clearUI();
        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);

        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Not Save')", true);

        //    }
        //}
        //public string AutoGenaratedPlanNo()
        //{
        //    int ID = 0;
        //    string quoNo = null;
        //    ID = GetPlanNo();
        //    var day = DateTime.Now.Day;
        //    var year = DateTime.Now.Year;

        //    if (ID == 0)
        //    {
        //        quoNo = "Plan-" + 1;
        //    }
        //    {
        //        quoNo = "Plan-" + day + "-" + year + "-" + (ID + 1);
        //    }
        //    return quoNo;
        //}
        //public int GetPlanNo()
        //{

        //    using (var _context = new ERPSSL_LCEntities())
        //    {

        //        var query = (from c in _context.Prod_Planning

        //                     select c.ID);
        //        var maxId = query.Count();


        //        return maxId;
        //    }

        //}
        protected void clearUI()
        {
            txtItemDescription.Text = "";
            txtOrderQuantity.Text = "";
            txtShipmentDate.Text = "";
            //txtFromDate.Text = "";
            //txtToDate.Text = "";
            //txtTotalDays.Text = "";
            // txtTotalTarget.Text = "";
            //txtDailyTarget.Text = "";
            //txtDailyPerLineTarget.Text = "";
            //txtTotalLine.Text = "";

        }

        //protected void LoadLine()
        //{
        //    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //    List<HRM_SUB_SECTIONS> result = _PlanningBLL.GetLine(OCODE);


        //    if (result != null)
        //    {
        //        ddlLineList.DataSource = result;
        //        ddlLineList.DataTextField = "SUB_SEC_NAME";
        //        ddlLineList.DataValueField = "SUB_SEC_ID";
        //        ddlLineList.DataBind();
        //        ddlLineList.AppendDataBoundItems = false;
        //        ddlLineList.Items.Insert(0, new ListItem("--Select Line--", "0"));
        //    }
        //}
        //protected void btnAdLine_OnClick(object sender, EventArgs e)
        //{
        //    Prod_LineAllocationTemp _LineAllocationTemp = new Prod_LineAllocationTemp();

        //    _LineAllocationTemp.LineName = ddlLineList.SelectedItem.Text;
        //    _LineAllocationTemp.LineId = Convert.ToInt32(ddlLineList.SelectedValue);
        //    _LineAllocationTemp.PlanNo = Session["PlanNo"].ToString();
        //    _LineAllocationTemp.TargetsAmount = Convert.ToDouble(txtTargetAmount.Text);
        //    _LineAllocationTemp.Create_User = ((SessionUser)Session["SessionUser"]).UserId;
        //    _LineAllocationTemp.Create_Date = DateTime.Today;
        //    _LineAllocationTemp.OCode = ((SessionUser)Session["SessionUser"]).OCode;

        //    int result = _PlanningBLL.AddLineAllocation(_LineAllocationTemp);
        //    if (result == 1)
        //    {
        //        LoadTempLine();
        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Save Successfully')", true);
        //    }
        //    else
        //    {
        //        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Data Not Save')", true);
        //    }
        //}

        //protected void LoadTempLine()
        //{
        //    string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
        //    string plan = Session["PlanNo"].ToString();
        //    List<Prod_LineAllocationTemp> result = _PlanningBLL.GetAllTempByPlanNo(plan, OCODE);
        //    if (result.Count != 0)
        //    {
        //        grdLineAllocation.DataSource = result;
        //        grdLineAllocation.DataBind();
        //    }
        //    else
        //    {
        //        var obj = new List<Prod_LineAllocationTemp>();
        //        obj.Add(new Prod_LineAllocationTemp());

        //        // Bind the DataTable which contain a blank row to the GridView
        //        grdLineAllocation.DataSource = obj;
        //        grdLineAllocation.DataBind();

        //        int columnsCount = grdLineAllocation.Columns.Count;
        //        grdLineAllocation.Rows[0].Cells.Clear();// clear all the cells in the row
        //        grdLineAllocation.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
        //        grdLineAllocation.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell


        //        grdLineAllocation.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
        //        grdLineAllocation.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
        //        grdLineAllocation.Rows[0].Cells[0].Font.Bold = true;

        //        //set No Results found to the new added cell
        //        grdLineAllocation.Rows[0].Cells[0].Text = "NO RECORDS FOUND  !";
        //    }
        //}


    }
}