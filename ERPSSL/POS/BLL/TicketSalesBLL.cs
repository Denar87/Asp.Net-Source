using ERPSSL.POS.DAL;
using ERPSSL.POS.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.POS.BLL
{
    public class TicketSalesBLL
    {
        TicketSalesDAL aTicketSalesDAL = new TicketSalesDAL();

        internal virtual List<ERPSSL.POS.DAL.Tbl_Ticket> GetAllTicketName(string OCODE)
        {
            return aTicketSalesDAL.GetAllTicketName(OCODE);
        }

        internal virtual List<ERPSSL.POS.DAL.Tbl_Food> GetAllTickName(string OCODE)
        {
            return aTicketSalesDAL.GetAllTickName(OCODE);
        }

        internal List<TicketSalesRepository> GetTicketSalesReport(string fromDate, string toDate)
        {
            return aTicketSalesDAL.GetTicketSalesReport(fromDate, toDate);
        }


        internal List<TicketSalesRepository> GetFoodSalesReport(string fromDate, string toDate)
        {
            return aTicketSalesDAL.GetFoodSalesReport(fromDate, toDate);
        }

        internal List<TicketSalesRepository> GetTicketSalesReportSummery(string fromDate,string  toDate)
        {
            return aTicketSalesDAL.GetTicketSalesReportSummery(fromDate, toDate);
        }

        internal List<FoodSalesRepository> GetAllFoodSummary(string OCODE)
        {
            return aTicketSalesDAL.GetAllFoodSummary(OCODE);
        }


        internal List<FoodSalesRepository> GetFoodSalesReportSummery(string fromDate, string toDate)
        {
            return aTicketSalesDAL.GetFoodSalesReportSummery(fromDate, toDate);
        }

        internal List<FoodSalesRepository> GetUserWiseIncomeStatement(string fromDate, string toDate)
        {
            return aTicketSalesDAL.GetUserWiseIncomeStatement(fromDate, toDate);
        }

        internal List<TicketSalesRepository> GetallInvoiceSalesSummary(string fromDate, string toDate)
        {
            return aTicketSalesDAL.GetallInvoiceSalesSummary(fromDate, toDate);
        }

        internal List<FoodSalesRepository> GetallInvoiceFoodSalesSummary(string fromDate, string toDate)
        {
            return aTicketSalesDAL.GetallInvoiceFoodSalesSummary(fromDate, toDate);
        }

        internal List<FoodSalesRepository> GetCategorywiseIncomeStatment(string fromDate, string toDate)
        {
            return aTicketSalesDAL.GetCategorywiseIncomeStatment(fromDate, toDate);
        }

        //internal List<TR_Tbl_FoodSales> GetAllInvoiceNo()
        //{
        //    return aTicketSalesDAL.GetAllInvoiceNo();
        //}
    }
}