using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ERPSSL.Production.BLL;
using ERPSSL.Production.DAL.Repository;
using ERPSSL.BuyingHouse.DAL.Repository;
using ERPSSL.BuyingHouse.BLL;
using ERPSSL.LC.DAL;


namespace ERPSSL.BuyingHouse
{
    public partial class Report : System.Web.UI.Page
    {

        PlanningBLL _PlanningBLL = new PlanningBLL();
        ReportBLL _reportbll = new ReportBLL();


        BuyingHouseReportBLL _BHReportbll = new BuyingHouseReportBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if ((Session["UserID"] != null) && (Session["OCode"] != null))
            {
                if (!IsPostBack)
                {
                    GetSupplierNo();
                }
            }
            else
            {
                Response.Redirect("..\\AppGateway\\Login.aspx");
            }
        }

        private void GetSupplierNo()
        {
            string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
            var row = _BHReportbll.GetAll_SupplierNo(OCode);
            if (row.Count > 0)
            {
                ddlSupplier.DataSource = row.ToList();
                ddlSupplier.DataTextField = "Supplier_No";
                ddlSupplier.DataValueField = "OrderNo";
                ddlSupplier.DataBind();
                ddlSupplier.Items.Insert(0, new ListItem("---Select One---", "0"));
            }
        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            //if (rdDailyfactoryProduction.Checked)
            //{
            //    var result = _PlanningBLL.GetDailyProductionStatus();
            //    if (result.Count > 0)
            //    {
            //        Session["rptDs"] = "DataSet1";
            //        Session["rptDt"] = result;
            //        Session["rptFile"] = "/Production/Reports/RPT_Prod_DailyProductionReport.rdlc";
            //        Session["rptTitle"] = "RPT_Prod_DailyProductionReport";
            //        Response.Redirect("Report_Viewer.aspx");
            //    }
            //}
            //else if (rdbDailyProductionDetails.Checked)
            //{
            //    string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

            //    List<ReportR> _rptDPDetails = new List<ReportR>();
            //    _rptDPDetails = _reportbll.GetDailyProductionDetails(OCode);
            //    if (_rptDPDetails.Count > 0)
            //    {
            //        Session["rptDs"] = "DS_Rpt_Production";
            //        Session["rptDt"] = _rptDPDetails;
            //        Session["rptFile"] = "/Production/Reports/RPT_Prod_DailyProductionDetails.rdlc";
            //        Session["rptTitle"] = "Daily Production Details";
            //        Response.Redirect("Report_Viewer.aspx");
            //    }
            //}
            //else if (rdbTna.Checked)
            //{
            //    string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

            //    List<ProductionR> _rptTna = new List<ProductionR>();
            //    _rptTna = _reportbll.GetTnaReport(OCode);
            //    if (_rptTna.Count > 0)
            //    {
            //        Session["rptDs"] = "DS_Rpt_Production";
            //        Session["rptDt"] = _rptTna;
            //        Session["rptFile"] = "/Production/Reports/RPT_Prod_TNAReport.rdlc";
            //        Session["rptTitle"] = "Daily Production Details";
            //        Response.Redirect("Report_Viewer.aspx");
            //    }
            //}

            if (rdbSampledetails.Checked)
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                List<BuyingHouseReport> _rptSampledetails = new List<BuyingHouseReport>();
                _rptSampledetails = _BHReportbll.GetSampledetailsReport(OCode);
                if (_rptSampledetails.Count > 0)
                {
                    Session["rptDs"] = "BHouseDataSet";
                    Session["rptDt"] = _rptSampledetails;
                    Session["rptFile"] = "/BuyingHouse/Reports/BH_RPT_GetSampledetailsReport.rdlc";
                    Session["rptTitle"] = "Sample details Report";
                    Response.Redirect("Report_Viewer.aspx");
                }
            }
            else if (rdbFactoryDetails.Checked)
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                List<BuyingHouseReport> _rptFactoryDetails = new List<BuyingHouseReport>();
                _rptFactoryDetails = _BHReportbll.GetFactoryDetailsReport(OCode);
                if (_rptFactoryDetails.Count > 0)
                {
                    Session["rptDs"] = "BHouseDataSet";
                    Session["rptDt"] = _rptFactoryDetails;
                    Session["rptFile"] = "/BuyingHouse/Reports/BH_RPT_GetFactoryDetailsReport.rdlc";
                    Session["rptTitle"] = "Factory Details Report";
                    Response.Redirect("Report_Viewer.aspx");
                }
            }
            else if (rdbBuyerDetails.Checked)
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                List<BuyingHouseReport> _rptBuyerDetails = new List<BuyingHouseReport>();
                _rptBuyerDetails = _BHReportbll.GetBuyerDetailsReport(OCode);
                if (_rptBuyerDetails.Count > 0)
                {
                    Session["rptDs"] = "BHouseDataSet";
                    Session["rptDt"] = _rptBuyerDetails;
                    Session["rptFile"] = "/BuyingHouse/Reports/BH_RPT_GetPrincipalWiseBuyerDetailsReport.rdlc";
                    //Session["rptFile"] = "/BuyingHouse/Reports/BH_RPT_GetBuyerDetailsReport.rdlc";
                    Session["rptTitle"] = "Buyer Details Report";
                    Response.Redirect("Report_Viewer.aspx");
                }
            }

            else if (rdbProductionStatus.Checked)
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);

                List<BuyingHouseReport> _rptBuyerDetails = new List<BuyingHouseReport>();
                _rptBuyerDetails = _BHReportbll.GetProductionStatusDetailsReport(OCode);
                if (_rptBuyerDetails.Count > 0)
                {
                    Session["rptDs"] = "BHouseDataSet";
                    Session["rptDt"] = _rptBuyerDetails;
                    Session["rptFile"] = "/BuyingHouse/Reports/BH_RPT_GetProductionStatusReport.rdlc";
                    Session["rptTitle"] = "Production Process Details";
                    Response.Redirect("Report_Viewer.aspx");
                }
            }
            else if (rdbOrderdetails.Checked)
            {

                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<BuyingHouseReport> _rptBuyerDetails = new List<BuyingHouseReport>();
                if (txtOrder.Text != "" && ddlSupplier.SelectedItem.Text != "---Select One---" && txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    string supplierNo = ddlSupplier.SelectedItem.Text;
                    DateTime FromDate = Convert.ToDateTime(txtFromDate.Text);
                    DateTime ToDate = Convert.ToDateTime(txtToDate.Text);
                    string OrderNo = txtOrder.Text;
                    _rptBuyerDetails = _BHReportbll.GetOrderDetailsByOrder(OrderNo, FromDate, ToDate, supplierNo, OCode);
                    if (_rptBuyerDetails.Count > 0)
                    {
                        Session["rptDs"] = "BHouseDataSet";
                        Session["rptDt"] = _rptBuyerDetails;
                        Session["rptFile"] = "/BuyingHouse/Reports/BH_RPT_GetOrderrDetailsReport.rdlc";
                        Session["rptTitle"] = "Supplier Wise Order Details";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }
                else if (txtOrder.Text == "" && ddlSupplier.SelectedItem.Text == "---Select One---" && txtFromDate.Text != "" && txtToDate.Text != "")
                {

                    DateTime FromDate = Convert.ToDateTime(txtFromDate.Text);
                    DateTime ToDate = Convert.ToDateTime(txtToDate.Text);

                    _rptBuyerDetails = _BHReportbll.GetOrderDetailsByDate(FromDate, ToDate, OCode);
                    if (_rptBuyerDetails.Count > 0)
                    {
                        Session["rptDs"] = "BHouseDataSet";
                        Session["rptDt"] = _rptBuyerDetails;
                        Session["rptFile"] = "/BuyingHouse/Reports/BH_RPT_GetOrderrDetailsReport.rdlc";
                        Session["rptTitle"] = "Supplier Wise Order Details";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }
                else if (txtOrder.Text == "" && ddlSupplier.SelectedItem.Text != "---Select One---" && txtFromDate.Text == "" && txtToDate.Text == "")
                {
                    string supplierNo = ddlSupplier.SelectedItem.Text;
                    _rptBuyerDetails = _BHReportbll.OrderDetailsBySupplier(supplierNo, OCode);
                    if (_rptBuyerDetails.Count > 0)
                    {
                        Session["rptDs"] = "BHouseDataSet";
                        Session["rptDt"] = _rptBuyerDetails;
                        Session["rptFile"] = "/BuyingHouse/Reports/BH_RPT_GetOrderrDetailsReport.rdlc";
                        Session["rptTitle"] = "Supplier Wise Order Details";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }
                else if (txtOrder.Text != "" && ddlSupplier.SelectedItem.Text == "---Select One---" && txtFromDate.Text == "" && txtToDate.Text == "")
                {
                    string OrderNo = txtOrder.Text;
                    _rptBuyerDetails = _BHReportbll.OrderDetailsByOrderNo(OrderNo, OCode);
                    if (_rptBuyerDetails.Count > 0)
                    {
                        Session["rptDs"] = "BHouseDataSet";
                        Session["rptDt"] = _rptBuyerDetails;
                        Session["rptFile"] = "/BuyingHouse/Reports/BH_RPT_GetOrderrDetailsReport.rdlc";
                        Session["rptTitle"] = "Supplier Wise Order Details";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }
                else if (txtOrder.Text == "" && ddlSupplier.SelectedItem.Text != "---Select One---" && txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    string supplierNo = ddlSupplier.SelectedItem.Text;
                    DateTime FromDate = Convert.ToDateTime(txtFromDate.Text);
                    DateTime ToDate = Convert.ToDateTime(txtToDate.Text);
                    _rptBuyerDetails = _BHReportbll.GetOrderDetailsReport(FromDate, ToDate, supplierNo, OCode);
                    if (_rptBuyerDetails.Count > 0)
                    {
                        Session["rptDs"] = "BHouseDataSet";
                        Session["rptDt"] = _rptBuyerDetails;
                        Session["rptFile"] = "/BuyingHouse/Reports/BH_RPT_GetOrderrDetailsReport.rdlc";
                        Session["rptTitle"] = "Supplier Wise Order Details";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }
                else
                {
                    _rptBuyerDetails = _BHReportbll.GetAllorderDetailsReport(OCode);
                    if (_rptBuyerDetails.Count > 0)
                    {
                        Session["rptDs"] = "LC_BHouseDataSet";
                        Session["rptDt"] = _rptBuyerDetails;
                        Session["rptFile"] = "/BuyingHouse/Reports/BH_RPT_GetOrderrDetailsReport.rdlc";
                        Session["rptTitle"] = "Supplier Wise Order Details";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }

            }
            else if (rdbOrderSummary.Checked)
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<BuyingHouseReport> _rptBuyerDetails = new List<BuyingHouseReport>();
                _rptBuyerDetails = _BHReportbll.GetAllorderSummaryReport(OCode);
                if (_rptBuyerDetails.Count > 0)
                {
                    Session["rptDs"] = "LC_BHouseDataSet";
                    Session["rptDt"] = _rptBuyerDetails;
                    Session["rptFile"] = "/BuyingHouse/Reports/BH_RPT_GetOrderSummaryReport.rdlc";
                    Session["rptTitle"] = "Order Summary";
                    Response.Redirect("Report_Viewer.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                }
            }
            else if (rdbOrderBuyerwise.Checked)
            {
                if (txtFromDate.Text != "" && txtToDate.Text != "")
                {
                    string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                    DateTime FromDate = Convert.ToDateTime(txtFromDate.Text);
                    DateTime ToDate = Convert.ToDateTime(txtToDate.Text);
                    List<BuyingHouseReport> _rptBuyerDetails = new List<BuyingHouseReport>();
                    _rptBuyerDetails = _BHReportbll.GetAllorderBuyerWiseReport(OCode,FromDate,ToDate);
                    if (_rptBuyerDetails.Count > 0)
                    {
                        Session["rptDs"] = "LC_BHouseDataSet";
                        Session["rptDt"] = _rptBuyerDetails;
                        Session["rptFile"] = "/BuyingHouse/Reports/BH_RPT_GetOrderBuyerWise_RPT.rdlc";
                        Session["rptTitle"] = "Order Summary (Buyer Wise)";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Select Date!')", true);
                }
            }
            else if (rdbShipmentSchedule.Checked)
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<BuyingHouseReport> _rptBuyerDetails = new List<BuyingHouseReport>();
                if (txtOrder.Text != "")
                {
                    string OrderNo = txtOrder.Text;
                    _rptBuyerDetails = _BHReportbll.GetShipmentByOrder(OrderNo, OCode);
                    if (_rptBuyerDetails.Count > 0)
                    {
                        Session["rptDs"] = "BHouseDataSet";
                        Session["rptDt"] = _rptBuyerDetails;
                        Session["rptFile"] = "/BuyingHouse/Reports/BH_RPT_GetShipmetScheduleReport.rdlc";
                        Session["rptTitle"] = "Shipment Schedule Report";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }
                else
                {
                    _rptBuyerDetails = _BHReportbll.GetShipmentReport(OCode);
                    if (_rptBuyerDetails.Count > 0)
                    {
                        Session["rptDs"] = "BHouseDataSet";
                        Session["rptDt"] = _rptBuyerDetails;
                        Session["rptFile"] = "/BuyingHouse/Reports/BH_RPT_GetShipmetScheduleReport.rdlc";
                        Session["rptTitle"] = "Shipment Schedule Report";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }
            }
            else if (rdbCompleteShipment.Checked)
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<BuyingHouseReport> _rptBuyerDetails = new List<BuyingHouseReport>();
                if (txtOrder.Text != "")
                {
                    string OrderNo = txtOrder.Text;
                    _rptBuyerDetails = _BHReportbll.GetCompleteShipmentByOrder(OrderNo, OCode);
                    if (_rptBuyerDetails.Count > 0)
                    {
                        Session["rptDs"] = "BHouseDataSet";
                        Session["rptDt"] = _rptBuyerDetails;
                        Session["rptFile"] = "/BuyingHouse/Reports/BH_RPT_GetCompleteShipmentReport.rdlc";
                        Session["rptTitle"] = "Complete Shipment Report";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }
                else
                {
                    _rptBuyerDetails = _BHReportbll.GetCompleteShipmentReport(OCode);
                    if (_rptBuyerDetails.Count > 0)
                    {
                        Session["rptDs"] = "BHouseDataSet";
                        Session["rptDt"] = _rptBuyerDetails;
                        Session["rptFile"] = "/BuyingHouse/Reports/BH_RPT_GetCompleteShipmentReport.rdlc";
                        Session["rptTitle"] = "Complete Shipment Report";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }
            }
            else if (rdbProductionProcess.Checked)
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<BuyingHouseReport> _rptBuyerDetails = new List<BuyingHouseReport>();
                if (txtOrder.Text != "")
                {
                    string OrderNo = txtOrder.Text;
                    _rptBuyerDetails = _BHReportbll.GetProductionDetailsByOrderReport(OrderNo, OCode);
                    if (_rptBuyerDetails.Count > 0)
                    {
                        Session["rptDs"] = "BHouseDataSet";
                        Session["rptDt"] = _rptBuyerDetails;
                        Session["rptFile"] = "/BuyingHouse/Reports/BH_RPT_GetProductionProcessReport.rdlc";
                        Session["rptTitle"] = "Production Planning Details";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }
                else
                {
                    _rptBuyerDetails = _BHReportbll.GetProductionProcessDetailsReport(OCode);
                    if (_rptBuyerDetails.Count > 0)
                    {
                        Session["rptDs"] = "BHouseDataSet";
                        Session["rptDt"] = _rptBuyerDetails;
                        Session["rptFile"] = "/BuyingHouse/Reports/BH_RPT_GetProductionProcessReport.rdlc";
                        Session["rptTitle"] = "Production Planning Details";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }
            }
            else if (rdbTaskDetails.Checked)
            {
                string OCode = Convert.ToString(((SessionUser)Session["SessionUser"]).OCode);
                List<BuyingHouseReport> _rptBuyerDetails = new List<BuyingHouseReport>();
                if (txtOrder.Text != "")
                {
                    string OrderNo = txtOrder.Text;
                    _rptBuyerDetails = _BHReportbll.GetTaskDetailsByOrderReport(OrderNo, OCode);
                    if (_rptBuyerDetails.Count > 0)
                    {
                        Session["rptDs"] = "BHouseDataSet";
                        Session["rptDt"] = _rptBuyerDetails;
                        Session["rptFile"] = "/BuyingHouse/Reports/BH_RPT_GetTaskDetailsReport.rdlc";
                        Session["rptTitle"] = "Order Wise Task Details";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }
                else
                {
                    _rptBuyerDetails = _BHReportbll.GetTaskDetailsReport(OCode);
                    if (_rptBuyerDetails.Count > 0)
                    {
                        Session["rptDs"] = "BHouseDataSet";
                        Session["rptDt"] = _rptBuyerDetails;
                        Session["rptFile"] = "/BuyingHouse/Reports/BH_RPT_GetTaskDetailsReport.rdlc";
                        Session["rptTitle"] = "Order Wise Task Details";
                        Response.Redirect("Report_Viewer.aspx");
                    }
                    else
                    {
                        ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('No data found!')", true);
                    }
                }
            }

            else
            {
                ScriptManager.RegisterStartupScript(this.Page, Page.GetType(), "text", "func('Please Select Report Item')", true);
            }
        }

        protected void rdbOrderdetails_CheckedChanged(object sender, EventArgs e)
        {

            ddlSupplier.Visible = true;
            txtFromDate.Visible = true;
            txtToDate.Visible = true;
            lblSupplier.Visible = true;
            lblfrom.Visible = true;
            lblToDate.Visible = true;
            txtOrder.Visible = true;
            lblOrder.Visible = true;

        }

        protected void rdDailyfactoryProduction_CheckedChanged(object sender, EventArgs e)
        {

            ddlSupplier.Visible = false;
            txtFromDate.Visible = false;
            txtToDate.Visible = false;
            lblSupplier.Visible = false;
            lblfrom.Visible = false;
            lblToDate.Visible = false;
            txtOrder.Visible = false;
            lblOrder.Visible = false;
        }
        [System.Web.Script.Services.ScriptMethod()]
        [System.Web.Services.WebMethod]
        public static List<string> SearchLCNo(string prefixText, int count)
        {
            using (var _context = new ERPSSL_LCEntities())
            {
                var AllOrder = from lcN in _context.LC_OrderEntry
                               where ((lcN.OrderNo.Contains(prefixText)))
                               select lcN;
                List<String> OrderList = new List<String>();
                foreach (var Order_No in AllOrder)
                {
                    OrderList.Add(Order_No.OrderNo);
                }
                return OrderList;
            }
        }

        protected void rdbTaskDetails_CheckedChanged(object sender, EventArgs e)
        {
            ddlSupplier.Visible = false;
            txtFromDate.Visible = false;
            txtToDate.Visible = false;
            lblSupplier.Visible = false;
            lblfrom.Visible = false;
            lblToDate.Visible = false;
            txtOrder.Visible = true;
            lblOrder.Visible = true;
        }

    }
}

