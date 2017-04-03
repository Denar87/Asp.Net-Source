using ERPSSL.Production.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.Production.DAL.Repository;
using ERPSSL.LC.DAL;

namespace ERPSSL.Production
{
    public partial class Inspection : System.Web.UI.Page
    {
        PlanningBLL _PlanningBLL = new PlanningBLL();

        InspectionBLL _inspectionbll = new InspectionBLL();

        FinishingBLL _finishingbll = new FinishingBLL();

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
                List<FinishingDetailsR> result = _finishingbll.GetFinishingDetails(OCODE);
                if (result.Count > 0)
                {
                    grdFinishingDetails.DataSource = result.ToList();
                    grdFinishingDetails.DataBind();
                }
                else
                {
                    var obj = new List<FinishingDetailsR>();
                    obj.Add(new FinishingDetailsR());

                    grdFinishingDetails.DataSource = obj;
                    grdFinishingDetails.DataBind();

                    int columnsCount = grdFinishingDetails.Columns.Count;
                    grdFinishingDetails.Rows[0].Cells.Clear();// clear all the cells in the row
                    grdFinishingDetails.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    grdFinishingDetails.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell
                    grdFinishingDetails.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    grdFinishingDetails.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    grdFinishingDetails.Rows[0].Cells[0].Font.Bold = true;

                    grdFinishingDetails.Rows[0].Cells[0].Text = "NO RECORDS FOUND FOR TODAY!";
                }
            }
            else
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                string orderNo = txtOrderNo.Text;
                List<FinishingDetailsR> orders = _finishingbll.GetFinishingDetailsByOrderNo(orderNo, OCODE);
                if (orders.Count > 0)
                {
                    grdFinishingDetails.DataSource = orders.ToList();
                    grdFinishingDetails.DataBind();
                }
                else
                {
                    var obj = new List<FinishingDetailsR>();
                    obj.Add(new FinishingDetailsR());

                    grdFinishingDetails.DataSource = obj;
                    grdFinishingDetails.DataBind();

                    int columnsCount = grdFinishingDetails.Columns.Count;
                    grdFinishingDetails.Rows[0].Cells.Clear();// clear all the cells in the row
                    grdFinishingDetails.Rows[0].Cells.Add(new TableCell()); //add a new blank cell
                    grdFinishingDetails.Rows[0].Cells[0].ColumnSpan = columnsCount; //set the column span to the new added cell

                    grdFinishingDetails.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
                    grdFinishingDetails.Rows[0].Cells[0].ForeColor = System.Drawing.Color.Red;
                    grdFinishingDetails.Rows[0].Cells[0].Font.Bold = true;

                    //set No Results found to the new added cell
                    grdFinishingDetails.Rows[0].Cells[0].Text = "NO RECORDS FOUND FOR !";
                }
            }
        }

        protected void txtOrderNo_OnTextChanged(object sender, EventArgs e)
        {
            LoadOrders();
        }
        protected void imgbtnFinishingDetails_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                ImageButton imgbtn = (ImageButton)sender;
                GridViewRow row = (GridViewRow)imgbtn.NamingContainer;

                Label lblId = (Label)grdFinishingDetails.Rows[row.RowIndex].FindControl("lblId");
                Label lblOrderNo = (Label)grdFinishingDetails.Rows[row.RowIndex].FindControl("lblOrderNo");
                Label lblBuyerID = (Label)grdFinishingDetails.Rows[row.RowIndex].FindControl("lblBuyerID");
                Label lblCuttingID = (Label)grdFinishingDetails.Rows[row.RowIndex].FindControl("lblCuttingID");
                Label lblSewingID = (Label)grdFinishingDetails.Rows[row.RowIndex].FindControl("lblSewingID");
                Label lblOrder_Qty = (Label)grdFinishingDetails.Rows[row.RowIndex].FindControl("lblOrderQty");
                Label lblGoodsName = (Label)grdFinishingDetails.Rows[row.RowIndex].FindControl("lblFinishedGoodsName");
                Label lblFGoodsQty = (Label)grdFinishingDetails.Rows[row.RowIndex].FindControl("lblFGoodsQty");
                Label lblFGoodsUnit = (Label)grdFinishingDetails.Rows[row.RowIndex].FindControl("lblFGoodsUnit");
                Label lblTotalFinishingCompleteDate = (Label)grdFinishingDetails.Rows[row.RowIndex].FindControl("lblTotalFinishingCompleteDate");
                Label lblTotalFinishingCompleteQty = (Label)grdFinishingDetails.Rows[row.RowIndex].FindControl("lblTotalFinishingCompleteQty");
                Label lblTotalFinishingCompleteUnit = (Label)grdFinishingDetails.Rows[row.RowIndex].FindControl("lblTotalFinishingCompleteUnit");

                Session["lblId"] = lblId.Text;
                txthidWashingID.Value = lblId.Text;

                txtOrderNoFill.Text = lblOrderNo.Text;

                Session["BuyerID"] = lblBuyerID.Text;
                txthidBuyer.Value = lblBuyerID.Text;

                Session["CuttingID"] = lblCuttingID.Text;
                txthidCuttingID.Value = lblCuttingID.Text;

                Session["SewingID"] = lblSewingID.Text;
                txthidSewingID.Value = lblSewingID.Text;

                txtOderQty.Text = lblOrder_Qty.Text;
                txtFinishGoods.Text = lblGoodsName.Text;
                txtFinishGoodsQty.Text = lblOrder_Qty.Text;
                txtFinishGoodsUnits.Text = lblFGoodsUnit.Text;

                txtFinishingCompleteDate.Text = lblTotalFinishingCompleteDate.Text;
                txtCCompleteFinishingQty.Text = lblTotalFinishingCompleteQty.Text;
                lblTotalFinishingCompleteUnit.Text = lblTotalFinishingCompleteUnit.Text;

            }
            catch (Exception ex)
            {
                throw;
            }
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
        public string AutoGenaratedPlanNo()
        {
            int ID = 0;
            string quoNo = null;
            ID = GetPlanNo();
            var day = DateTime.Now.Day;
            var year = DateTime.Now.Year;

            if (ID == 0)
            {
                quoNo = "Plan-" + 1;
            }
            {
                quoNo = "Plan-" + day + "-" + year + "-" + (ID + 1);
            }
            return quoNo;
        }
        public int GetPlanNo()
        {

            using (var _context = new ERPSSL_LCEntities())
            {

                var query = (from c in _context.Prod_Planning

                             select c.ID);
                var maxId = query.Count();


                return maxId;
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

        }
        //protected void clearUI()
        //{
        //    txtItemDescription.Text = "";
        //    txtOrderQuantity.Text = "";
        //    txtShipmentDate.Text = "";
        //    txtFromDate.Text = "";
        //    txtToDate.Text = "";
        //    txtTotalDays.Text = "";
        //    // txtTotalTarget.Text = "";
        //    txtDailyTarget.Text = "";
        //    txtDailyPerLineTarget.Text = "";
        //    txtTotalLine.Text = "";

        //}

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