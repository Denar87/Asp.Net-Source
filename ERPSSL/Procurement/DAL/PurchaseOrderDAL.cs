using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.INV.DAL;
using System.Data.SqlClient;

namespace ERPSSL.Procurement.DAL
{
    public class PurchaseOrderDAL
    {
        private ERPSSL_INVEntities _context = new ERPSSL_INVEntities();

        internal List<PRQ_PurchaseOrders> GetAllPurchaseOrder(string PurchaseType)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var type = new SqlParameter("@PurchaseType", PurchaseType);
                    string SP_SQL = "PRQ_GetDistinctWorkOrdersToRcvProduct @PurchaseType";
                    return (_context.ExecuteStoreQuery<PRQ_PurchaseOrders>(SP_SQL, type)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<PRQ_PurchaseOrders> GetAllPurchaseOrderByPONo(string PONo)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var PONO = new SqlParameter("@PONo", PONo);
                    string SP_SQL = "PRQ_GetWorkOrdersToRcvProduct_ByPONo @PONo";
                    return (_context.ExecuteStoreQuery<PRQ_PurchaseOrders>(SP_SQL, PONO)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}