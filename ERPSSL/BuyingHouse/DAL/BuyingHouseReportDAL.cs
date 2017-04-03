using ERPSSL.BuyingHouse.DAL.Repository;
using ERPSSL.LC.DAL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ERPSSL.BuyingHouse.DAL
{
    public class BuyingHouseReportDAL
    {
        internal List<BuyingHouseReport> GetSampledetailsReport(string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCode);
                    string SP_SQL = "LC_RPT_GetSampledetailsReport @OCODE";
                    return (_context.ExecuteStoreQuery<BuyingHouseReport>(SP_SQL, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<BuyingHouseReport> GetFactoryDetailsReport(string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCode);
                    string SP_SQL = "LC_RPT_GetFactoryDetailsReport @OCODE";
                    return (_context.ExecuteStoreQuery<BuyingHouseReport>(SP_SQL, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<BuyingHouseReport> GetBuyerDetailsReport(string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCode);
                    string SP_SQL = "LC_RPT_GetBuyerDetailsReport @OCODE";
                    return (_context.ExecuteStoreQuery<BuyingHouseReport>(SP_SQL, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<BuyingHouseReport> GetorderDetailsReport(DateTime FromDate, DateTime ToDate, string supplierNo, string OCode)
        {

            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var From = new SqlParameter("@fromDate", FromDate);
                    var To = new SqlParameter("@toDate", ToDate);

                    var _Supplier = new SqlParameter("@SupplierNo", supplierNo);
                    var _OCode = new SqlParameter("@OCODE", OCode);

                    string SP_SQL = "LC_RPT_GetOrderDetailsReport @fromDate,@toDate,@SupplierNo,@OCODE";
                    return (_context.ExecuteStoreQuery<BuyingHouseReport>(SP_SQL, From, To, _Supplier, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal List<BuyingHouseReport> GetCompleteShipmentReport(string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCode);
                    string SP_SQL = "LC_RPT_GetCompleteShipmentReport @OCODE";
                    return (_context.ExecuteStoreQuery<BuyingHouseReport>(SP_SQL, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LC_OrderEntry> GetAll_SupplierNo(string OCode)
        {
            try
            {
                using (var context = new ERPSSL_LCEntities())
                {

                    List<LC_OrderEntry> buyers = (from dept in context.LC_OrderEntry
                                                  where dept.OCODE == OCode
                                                  select dept).ToList();
                    return buyers;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<BuyingHouseReport> GetShipmentReport(string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCode);
                    string SP_SQL = "LC_RPT_GetShipmetScheduleReport @OCODE";
                    return (_context.ExecuteStoreQuery<BuyingHouseReport>(SP_SQL, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<BuyingHouseReport> GetProductionProcessDetailsReport(string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCode);
                    string SP_SQL = "LC_RPT_GetProductionProcessReport @OCODE";
                    return (_context.ExecuteStoreQuery<BuyingHouseReport>(SP_SQL, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<BuyingHouseReport> GetProductionStatusDetailsReport(string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCode);
                    string SP_SQL = "LC_RPT_GetProductionStatusReport @OCODE";
                    return (_context.ExecuteStoreQuery<BuyingHouseReport>(SP_SQL, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal List<BuyingHouseReport> GetTaskDetailsReport(string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCode);
                    string SP_SQL = "LC_RPT_GetTaskDetailsReport @OCODE";
                    return (_context.ExecuteStoreQuery<BuyingHouseReport>(SP_SQL, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal List<BuyingHouseReport> GetTaskDetailsByOrderReport(string order, string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var Order = new SqlParameter("@Order", order);
                    var _OCode = new SqlParameter("@OCODE", OCode);
                    string SP_SQL = "LC_RPT_GetTaskDetailsByOrder @Order,@OCODE";
                    return (_context.ExecuteStoreQuery<BuyingHouseReport>(SP_SQL, Order, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<BuyingHouseReport> GetProductionDetailsByOrderReport(string OrderNo, string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var Order = new SqlParameter("@Order", OrderNo);
                    var _OCode = new SqlParameter("@OCODE", OCode);
                    string SP_SQL = "LC_RPT_GetProductionProcessByOrder @Order,@OCODE";
                    return (_context.ExecuteStoreQuery<BuyingHouseReport>(SP_SQL, Order, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<BuyingHouseReport> GetCompleteShipmentByOrder(string OrderNo, string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var Order = new SqlParameter("@Order", OrderNo);
                    var _OCode = new SqlParameter("@OCODE", OCode);
                    string SP_SQL = "LC_RPT_GetCompleteShipmentByOrder @Order,@OCODE";
                    return (_context.ExecuteStoreQuery<BuyingHouseReport>(SP_SQL, Order, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<BuyingHouseReport> GetShipmentByOrder(string OrderNo, string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var Order = new SqlParameter("@Order", OrderNo);
                    var _OCode = new SqlParameter("@OCODE", OCode);
                    string SP_SQL = "LC_RPT_GetShipmetScheduleByOrder @Order,@OCODE";
                    return (_context.ExecuteStoreQuery<BuyingHouseReport>(SP_SQL, Order, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<BuyingHouseReport> GetOrderDetailsByOrder(string OrderNo, DateTime FromDate, DateTime ToDate, string supplierNo, string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var Order = new SqlParameter("@Order", OrderNo);

                    var From = new SqlParameter("@fromDate", FromDate);
                    var To = new SqlParameter("@toDate", ToDate);

                    var _Supplier = new SqlParameter("@SupplierNo", supplierNo);
                    var _OCode = new SqlParameter("@OCODE", OCode);

                    string SP_SQL = "LC_RPT_GetOrderDetailsByOrderNo @Order,@fromDate,@toDate,@SupplierNo,@OCODE";
                    return (_context.ExecuteStoreQuery<BuyingHouseReport>(SP_SQL, Order, From, To, _Supplier, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        internal List<BuyingHouseReport> GetAllorderDetailsReport(string OCode)
        {

            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var _OCode = new SqlParameter("@OCODE", OCode);

                    string SP_SQL = "LC_RPT_GetAllOrderDetailsReport @OCODE";
                    return (_context.ExecuteStoreQuery<BuyingHouseReport>(SP_SQL, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal List<BuyingHouseReport> OrderDetailsByOrderNo(string Order, string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var _ORDER = new SqlParameter("@OrderNo", Order);
                    var _OCode = new SqlParameter("@OCODE", OCode);

                    string SP_SQL = "LC_RPT_GetAllOrderDetailsByOrderNo @OrderNo,@OCODE";
                    return (_context.ExecuteStoreQuery<BuyingHouseReport>(SP_SQL, _ORDER, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<BuyingHouseReport> GetOrderDetailsByDate(DateTime FromDate, DateTime ToDate, string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var From = new SqlParameter("@fromDate", FromDate);
                    var To = new SqlParameter("@toDate", ToDate);

                    //var _Supplier = new SqlParameter("@SupplierNo", supplierNo);
                    var _OCode = new SqlParameter("@OCODE", OCode);

                    string SP_SQL = "LC_RPT_GetOrderDetailsByDate @fromDate,@toDate,@OCODE";
                    return (_context.ExecuteStoreQuery<BuyingHouseReport>(SP_SQL, From, To, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        internal List<BuyingHouseReport> OrderDetailsBySupplier(string supplierNo, string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    //var From = new SqlParameter("@fromDate", FromDate);
                    //var To = new SqlParameter("@toDate", ToDate);

                   var _Supplier = new SqlParameter("@SupplierNo", supplierNo);
                    var _OCode = new SqlParameter("@OCODE", OCode);

                    string SP_SQL = "LC_RPT_GetOrderDetailsBySupplier @SupplierNo,@OCODE";
                    return (_context.ExecuteStoreQuery<BuyingHouseReport>(SP_SQL, _Supplier, _OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<BuyingHouseReport> GetAllorderSummaryReport(string OCode)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    //var _Supplier = new SqlParameter("@SupplierNo", supplierNo);
                    var _OCode = new SqlParameter("@OCODE", OCode);

                    string SP_SQL = "LC_RPT_GetOrderSummary @OCODE";
                    return (_context.ExecuteStoreQuery<BuyingHouseReport>(SP_SQL,_OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<BuyingHouseReport> GetAllorderBuyerWiseReport(string OCode,DateTime FromDate,DateTime ToDate)
        {
            try
            {
                using (var _context = new ERPSSL_LCEntities())
                {
                    var From = new SqlParameter("@fromDate", FromDate);
                    var To = new SqlParameter("@toDate", ToDate);
                    //var _Supplier = new SqlParameter("@SupplierNo", supplierNo);
                    var _OCode = new SqlParameter("@OCODE", OCode);

                    string SP_SQL = "LC_RPT_GetOrderSummary_BuyerWise @fromDate,@toDate,@OCODE";
                    return (_context.ExecuteStoreQuery<BuyingHouseReport>(SP_SQL,From,To,_OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        
        }
    }
}