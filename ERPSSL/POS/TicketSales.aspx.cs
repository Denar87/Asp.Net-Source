using ERPSSL.HRM.BLL;
using ERPSSL.POS.BLL;
using ERPSSL.POS.DAL;
using ERPSSL.POS.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ERPSSL.POS
{
    public partial class TicketSales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //FillTicketType();
               // FoodSales();
            }

        }

        private void FoodSales()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = aTicketSalesBLL.GetAllTickName(OCODE).ToList();
                if (row.Count > 0)
                {
                    //ddlFoodType.DataSource = row.ToList();
                    //ddlFoodType.DataTextField = "FoodName";
                    //ddlFoodType.DataValueField = "Id";
                    //ddlFoodType.DataBind();
                    //ddlFoodType.Items.Insert(0, new ListItem("------Select One------", "0"));
                }
            }
            catch (Exception)
            { 
                throw;
            }
        }

        TicketSalesBLL aTicketSalesBLL = new TicketSalesBLL();

        private void FillTicketType()
        {
            try
            {
                string OCODE = ((SessionUser)Session["SessionUser"]).OCode;
                var row = aTicketSalesBLL.GetAllTicketName(OCODE).ToList();
                if (row.Count > 0)
                {
                    ddlTicketType.DataSource = row.ToList();
                    ddlTicketType.DataTextField = "TicketName";
                    ddlTicketType.DataValueField = "Id";
                    ddlTicketType.DataBind();
                    ddlTicketType.Items.Insert(0, new ListItem("------Select One------", "0"));
                }
            }
            catch (Exception)
            { 
                throw;
            }
        }

        protected void ddlTicketType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlFoodType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnProcess_Click(object sender, EventArgs e)
        {
            List<TicketSalesRepository> tblticket = new List<TicketSalesRepository>();
            string fromDate = txtbxFrom.Text;
            string toDate = txtbxTo.Text;
            string OCODE = ((SessionUser)Session["SessionUser"]).OCode;

            //for Ticket Wise 
            if (rdbTicketSale.Checked)
            {
                //int ResionId = Convert.ToInt32(ddlRegions.SelectedValue); 
                tblticket = aTicketSalesBLL.GetTicketSalesReport(fromDate, toDate).ToList();

                if (tblticket.Count > 0)
                {
                    Session["rptDs"] = "DataSet1";
                    Session["rptDt"] = tblticket;
                    Session["rptFile"] = "/POS/Reports/POS_Rpt_AllTicketSales_RPT.rdlc";
                    Session["rptTitle"] = "";
                    Response.Redirect("Report_Viewer.aspx");
                }

            }
            if (rdbFoodSale.Checked)
            {

                tblticket = aTicketSalesBLL.GetFoodSalesReport(fromDate, toDate).ToList();

                if (tblticket.Count > 0)
                {
                    Session["rptDs"] = "DataSet1";
                    Session["rptDt"] = tblticket;
                    Session["rptFile"] = "/POS/Reports/POS_Rpt_AllFoodSales_RPT.rdlc";
                    Session["rptTitle"] = "";
                    Response.Redirect("Report_Viewer.aspx");
                }

            }


            if (rdbItemWiseSummery.Checked)
            {
                tblticket = aTicketSalesBLL.GetTicketSalesReportSummery(fromDate, toDate).ToList();
                if (tblticket.Count > 0)
                {
                    Session["rptDs"] = "DataSet1";
                    Session["rptDt"] = tblticket;
                    Session["rptFile"] = "/POS/Reports/POS_Rpt_AllTicketSalesSummery_RPT.rdlc";
                    Session["rptTitle"] = "";
                    Response.Redirect("Report_Viewer.aspx");
                }
            }

            if (rdbFoodWiseSummery.Checked)
            {
                List<FoodSalesRepository> tblFood = new List<FoodSalesRepository>();
                tblFood = aTicketSalesBLL.GetFoodSalesReportSummery(fromDate, toDate).ToList();
                if (tblFood.Count > 0)
                {
                    Session["rptDs"] = "DataSet1";
                    Session["rptDt"] = tblFood;
                    Session["rptFile"] = "/POS/Reports/POS_Rpt_AllFoodSalesSummery_RPT.rdlc";
                    Session["rptTitle"] = "";
                    Response.Redirect("Report_Viewer.aspx");
                }
            }

            if (rdbUserwiseISSummery.Checked)
            {
                List<FoodSalesRepository> userwiseIncomeStatement = new List<FoodSalesRepository>();
                userwiseIncomeStatement = aTicketSalesBLL.GetUserWiseIncomeStatement(fromDate, toDate).ToList();
                if (userwiseIncomeStatement.Count > 0)
                {
                    Session["rptDs"] = "DataSet1";
                    Session["rptDt"] = userwiseIncomeStatement;
                    Session["rptFile"] = "/POS/Reports/POS_Rpt_UserWiseIncomeStatement_RPT.rdlc";
                    Session["rptTitle"] = "";
                    Response.Redirect("Report_Viewer.aspx");
                }

            }


            //if (rdbFoodSummery.Checked)
            //{
            //    List<FoodSalesRepository> tblFood = new List<FoodSalesRepository>();
            //    tblFood = aTicketSalesBLL.GetAllFoodSummary(OCODE).ToList();
            //    if (tblFood.Count > 0)
            //    {
            //        Session["rptDs"] = "DataSet1";
            //        Session["rptDt"] = tblFood;
            //        Session["rptFile"] = "/POS/Reports/POS_Rpt_AllFoodSummary_RPT.rdlc";
            //        Session["rptTitle"] = "";
            //        Response.Redirect("Report_Viewer.aspx");
            //    }

            //}

            if (rdballInvoicesaleforTicket.Checked)
            {
                List<TicketSalesRepository> allInvoiceSalesSummary = new List<TicketSalesRepository>();
                allInvoiceSalesSummary = aTicketSalesBLL.GetallInvoiceSalesSummary(fromDate, toDate).ToList();
                if (allInvoiceSalesSummary.Count > 0)
                {
                    Session["rptDs"] = "DataSet1";
                    Session["rptDt"] = allInvoiceSalesSummary;
                    Session["rptFile"] = "/POS/Reports/POS_Rpt_AllInvoiceSalesSummaryForTicket_RPT.rdlc";
                    Session["rptTitle"] = "";
                    Response.Redirect("Report_Viewer.aspx");
                }
            }
            if (rdballInvoicesaleforFood.Checked)
            {
                List<FoodSalesRepository> allInvoiceSalesSummary = new List<FoodSalesRepository>();
                allInvoiceSalesSummary = aTicketSalesBLL.GetallInvoiceFoodSalesSummary(fromDate, toDate).ToList();
                if (allInvoiceSalesSummary.Count > 0)
                {
                    Session["rptDs"] = "DataSet1";
                    Session["rptDt"] = allInvoiceSalesSummary;
                    Session["rptFile"] = "/POS/Reports/POS_Rpt_AllInvoiceSalesSummaryForFood_RPT.rdlc";
                    Session["rptTitle"] = "";
                    Response.Redirect("Report_Viewer.aspx");
                }
            }

            if (rdbcatagorywiseIncomeStatement.Checked)
            {
                List<FoodSalesRepository> allInvoiceSalesSummary = new List<FoodSalesRepository>();
                allInvoiceSalesSummary = aTicketSalesBLL.GetCategorywiseIncomeStatment(fromDate, toDate).ToList();
                if (allInvoiceSalesSummary.Count > 0)
                {
                    Session["rptDs"] = "DataSet1";
                    Session["rptDt"] = allInvoiceSalesSummary;
                    Session["rptFile"] = "/POS/Reports/POS_Rpt_CategorywiseIncomeStatment_RPT.rdlc";
                    Session["rptTitle"] = "";
                    Response.Redirect("Report_Viewer.aspx");
                }
            }
        }
    }
}