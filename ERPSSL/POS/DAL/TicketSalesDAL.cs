using ERPSSL.POS.DAL;
using ERPSSL.POS.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.POS.DAL
{
    public class TicketSalesDAL
    {
        private POS_Entities _context = new POS_Entities();

        internal virtual List<Tbl_Ticket> GetAllTicketName(string OCODE)
        {
            try
            {
                var query = (from tms in _context.Tbl_Ticket
                             where tms.OCODE == OCODE
                             select tms);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<Tbl_Food> GetAllTickName(string OCODE)
        {
            try
            {
                var query = (from tms in _context.Tbl_Food
                             where tms.OCODE == OCODE
                             select tms);

                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<TicketSalesRepository> GetTicketSalesReport(string fromDate, string toDate)
        {
            try
            {
                using (var _context = new POS_Entities())
                {
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "POS_Rpt_AllTicketSales @startDate,@endDate";
                    return (_context.ExecuteStoreQuery<TicketSalesRepository>(SP_SQL, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<TicketSalesRepository> GetFoodSalesReport(string fromDate, string toDate)
        {
            try
            {
                using (var _context = new POS_Entities())
                {
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "POS_Rpt_AllFoodSales @startDate,@endDate";
                    return (_context.ExecuteStoreQuery<TicketSalesRepository>(SP_SQL, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            } 
        }

        internal List<TicketSalesRepository> GetTicketSalesReportSummery(string fromDate, string toDate)
        {
            try
            {
                using (var _context = new POS_Entities())
                {
                   var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "POS_Rpt_AllTicketSalesSummery @startDate,@endDate";
                    return (_context.ExecuteStoreQuery<TicketSalesRepository>(SP_SQL, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            } 
        }
        internal List<FoodSalesRepository> GetAllFoodSummary(string OCODE)
        {
            try
            {
                using (var _context = new POS_Entities())
                {
                    var O_OCODE = new SqlParameter("@ocode", OCODE);
                    string SP_SQL = "POS_RPT_AllFoodSummary @ocode";
                    return (_context.ExecuteStoreQuery<FoodSalesRepository>(SP_SQL, O_OCODE)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            } 
        }


        internal List<FoodSalesRepository> GetFoodSalesReportSummery(string fromDate, string toDate)
        {
            try
            {
                using (var _context = new POS_Entities())
                {
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "POS_Rpt_AllFoodSalesSummery @startDate,@endDate";
                    return (_context.ExecuteStoreQuery<FoodSalesRepository>(SP_SQL, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            } 
        }

        internal List<FoodSalesRepository> GetUserWiseIncomeStatement(string fromDate, string toDate)
        {
            try
            {
                using (var _context = new POS_Entities())
                {
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "POS_Rpt_UserWiseIncomeStatement @startDate,@endDate";
                    return (_context.ExecuteStoreQuery<FoodSalesRepository>(SP_SQL, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            } 
        }

        internal List<TicketSalesRepository> GetallInvoiceSalesSummary(string fromDate, string toDate)
        {
            try
            {
                using (var _context = new POS_Entities())
                {
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "POS_Rpt_AllInvoiceSalesSummary @startDate,@endDate";
                    return (_context.ExecuteStoreQuery<TicketSalesRepository>(SP_SQL, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            } 
        }

        internal List<FoodSalesRepository> GetallInvoiceFoodSalesSummary(string fromDate, string toDate)
        {
            try
            {
                using (var _context = new POS_Entities())
                {
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "POS_Rpt_AllInvoiceFoodSalesSummary @startDate,@endDate";
                    return (_context.ExecuteStoreQuery<FoodSalesRepository>(SP_SQL, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            } 
        }

        internal List<FoodSalesRepository> GetCategorywiseIncomeStatment(string fromDate, string toDate)
        {
            try
            {
                using (var _context = new POS_Entities())
                {
                    var FromDate = new SqlParameter("@startDate", fromDate);
                    var ToDate = new SqlParameter("@endDate", toDate);
                    string SP_SQL = "POS_Rpt_CategorywiseIncomeStatment @startDate,@endDate";
                    return (_context.ExecuteStoreQuery<FoodSalesRepository>(SP_SQL, FromDate, ToDate)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            } 
        }





        //internal List<TR_Tbl_FoodSales> GetAllInvoiceNo()
        //{
        //    try
        //    {
        //        var query = (from tms in _context.TR_Tbl_FoodSales
        //                     select tms.InvoiceNo.Count());
        //        return query.ToList();
        //    }

        //    catch (Exception ex)
        //    {
        //        throw new Exception(ex.Message.ToString());
        //    }
        //}

        internal decimal GetTicketSalesForToday(string OCODE)
        {
            try
            {
                DateTime today = DateTime.Now.Date;
                //return context.CRM_Complain.Count();

                var query = (from co in _context.TR_Tbl_TicketSales
                             select co).Where(x => x.EDIT_DATE > today).ToList();

                return query.Sum(s => s.ItemTotal);


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}