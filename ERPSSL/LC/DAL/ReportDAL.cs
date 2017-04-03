using ERPSSL.LC.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.LC.DAL
{
    public class ReportDAL
    {
        internal List<ReportLC> GetLCOpenReport(string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCode);
                    string SP_SQL = "LC_RPT_Get_ALL_LCOpen @OCODE";
                    return (_context.ExecuteStoreQuery<ReportLC>(SP_SQL, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<ReportLC> GetLCOrderDetailsReport(string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCode);
                    string SP_SQL = "LC_RPT_Get_ALL_OrderDetails @OCODE";
                    return (_context.ExecuteStoreQuery<ReportLC>(SP_SQL, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<ReportLC> GetLCOpenReportByDate(DateTime FromDate, DateTime Todate, string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var _FromDate = new SqlParameter("@FromDate",FromDate);
                    var _ToDate = new SqlParameter("@ToDate", Todate);
                    var _OCode = new SqlParameter("@OCODE", OCode);
                    string SP_SQL = "LC_RPT_Get_ALL_LCOpen @FromDate,@ToDate,@OCODE";
                    return (_context.ExecuteStoreQuery<ReportLC>(SP_SQL, _FromDate,_ToDate,_OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<ReportLC> GetContractReportByDate(DateTime FromDate, DateTime Todate, string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var _FromDate = new SqlParameter("@FromDate", FromDate);
                    var _ToDate = new SqlParameter("@ToDate", Todate);
                    var _OCode = new SqlParameter("@OCODE", OCode);
                    string SP_SQL = "LC_RPT_Get_ALL_ContractLCByDate @FromDate,@ToDate,@OCODE";
                    return (_context.ExecuteStoreQuery<ReportLC>(SP_SQL, _FromDate, _ToDate, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<ReportLC> GetLCAmendReportByDate(DateTime FromDate, DateTime Todate, string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var _FromDate = new SqlParameter("@FromDate", FromDate);
                    var _ToDate = new SqlParameter("@ToDate", Todate);
                    var _OCode = new SqlParameter("@OCODE", OCode);
                    string SP_SQL = "LC_RPT_Get_ALL_AmendLCByDate @FromDate,@ToDate,@OCODE";
                    return (_context.ExecuteStoreQuery<ReportLC>(SP_SQL, _FromDate, _ToDate, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<ReportLC> GetLCStyleReport(string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    //var _FromDate = new SqlParameter("@FromDate", FromDate);
                    //var _ToDate = new SqlParameter("@ToDate", Todate);
                    var _OCode = new SqlParameter("@OCODE", OCode);
                    string SP_SQL = "LC_RPT_Get_StyleDetails @OCODE";
                    return (_context.ExecuteStoreQuery<ReportLC>(SP_SQL,_OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}