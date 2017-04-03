using ERPSSL.INV.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using MoreLinq;
using System.Web;
using System.Data.SqlClient;

namespace ERPSSL.INV.DAL
{
    public class ReportDal
    {
        public List<productsDetails> Rpt_GetStockBy_ReOrderQty()
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    string SP_SQL = "INV_FullStockReportsBy_ReOrderQty_RPT";
                    return (_context.ExecuteStoreQuery<productsDetails>(SP_SQL)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<productsDetails> GetAllProductByGroupId(int groupID, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var groupid = new SqlParameter("@GroupID", groupID);
                    var oCode = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "INV_RPT_ProductListByGroupID @GroupID,@OCODE";
                    return (_context.ExecuteStoreQuery<productsDetails>(SP_SQL, groupid, oCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<productsDetails> Rpt_GetAllProducts()
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {

                    string SP_SQL = "INV_ProductReports_RPT ";
                    return (_context.ExecuteStoreQuery<productsDetails>(SP_SQL)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<SuplierDetails> Rpt_GetAllSupplier()
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {

                    string SP_SQL = "INV_SuplierReports_RPT ";
                    return (_context.ExecuteStoreQuery<SuplierDetails>(SP_SQL)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal List<ProductLog> Rpt_GetAllProduct(string OCODE)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {

                    var ocode = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "INV_Product_Update_Log @OCODE";
                    return (_context.ExecuteStoreQuery<ProductLog>(SP_SQL, ocode)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<productsDetails> Rpt_GetStockBy_Store(string StoreCode)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {

                    var store = new SqlParameter("@StoreCode", StoreCode);
                    string SP_SQL = "INV_FullStockReportsBy_Store_RPT @StoreCode";
                    return (_context.ExecuteStoreQuery<productsDetails>(SP_SQL, store)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<productsDetails> Rpt_GetFullStockDetailsByDate_WithStore(string StoreCode, string FromDate, string ToDate, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {

                    var DateForm = new SqlParameter("@FromDate", FromDate);
                    var DateTo = new SqlParameter("@ToDate", ToDate);
                    var OCode = new SqlParameter("@OCODE", OCODE);
                    var store = new SqlParameter("@StoreCode", StoreCode);
                    string SP_SQL = "Inv_Rpt_StockDetails_ByDate_WithStore @FromDate,@ToDate,@OCODE,@StoreCode";
                    return (_context.ExecuteStoreQuery<productsDetails>(SP_SQL, DateForm, DateTo, OCode, store)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<productsDetails> Rpt_GetFullStockDetailsByDate(string FromDate, string ToDate, string OCODE)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var DateForm = new SqlParameter("@FromDate", FromDate);
                    var DateTo = new SqlParameter("@ToDate", ToDate);
                    var OCode = new SqlParameter("@OCODE", OCODE);
                    string SP_SQL = "Inv_Rpt_StockDetails_ByDate @FromDate,@ToDate,@OCODE ";
                    return (_context.ExecuteStoreQuery<productsDetails>(SP_SQL, DateForm, DateTo, OCode)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<productsDetails> Rpt_GetFullStock()
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {

                    string SP_SQL = "INV_FullStockReports_RPT ";
                    return (_context.ExecuteStoreQuery<productsDetails>(SP_SQL)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<productsDetails> Rpt_GetStockBy_Store_ProductGroup(string StoreCode, string productGroupId)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var store = new SqlParameter("@StoreCode", StoreCode);
                    var group = new SqlParameter("@ProductGroupId", productGroupId);
                    string SP_SQL = "INV_FullStockReportsBy_Store_Group_RPT @StoreCode,@ProductGroupId";
                    return (_context.ExecuteStoreQuery<productsDetails>(SP_SQL, store, group)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<productsDetails> Rpt_GetFullStockDetailsByDate_Group_WithStore(string StoreCode, string FromDate, string ToDate, string OCODE, string GroupId)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var DateForm = new SqlParameter("@FromDate", FromDate);
                    var DateTo = new SqlParameter("@ToDate", ToDate);
                    var OCode = new SqlParameter("@OCODE", OCODE);
                    var groupId = new SqlParameter("@GroupId", GroupId);
                    var store = new SqlParameter("@StoreCode", StoreCode);
                    string SP_SQL = "Inv_Rpt_StockDetails_ByDate_Group_WithStore @FromDate,@ToDate,@OCODE,@GroupId,@StoreCode ";
                    return (_context.ExecuteStoreQuery<productsDetails>(SP_SQL, DateForm, DateTo, OCode, groupId, store)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<productsDetails> Rpt_GetFullStockDetailsByDate_Group(string FromDate, string ToDate, string OCODE, string GroupId)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var DateForm = new SqlParameter("@FromDate", FromDate);
                    var DateTo = new SqlParameter("@ToDate", ToDate);
                    var OCode = new SqlParameter("@OCODE", OCODE);
                    var groupId = new SqlParameter("@GroupId", GroupId);
                    string SP_SQL = "Inv_Rpt_StockDetails_ByDate_Group @FromDate,@ToDate,@OCODE,@GroupId ";
                    return (_context.ExecuteStoreQuery<productsDetails>(SP_SQL, DateForm, DateTo, OCode, groupId)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<productsDetails> Rpt_GetStockBy_Store_Product(string StoreCode, string productGroupId, string ProductId)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var store = new SqlParameter("@StoreCode", StoreCode);
                    var group = new SqlParameter("@ProductGroupId", productGroupId);
                    var product = new SqlParameter("@ProductId", ProductId);
                    string SP_SQL = "INV_FullStockReportsBy_Store_Product_RPT @StoreCode,@ProductGroupId,@ProductId";
                    return (_context.ExecuteStoreQuery<productsDetails>(SP_SQL, store, group, product)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<productsDetails> Rpt_GetFullStockDetailsByDate_Product_WithStore(string FromDate, string ToDate, string OCODE, string GroupId, string ProductId, string storeCode)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var DateForm = new SqlParameter("@FromDate", FromDate);
                    var DateTo = new SqlParameter("@ToDate", ToDate);
                    var OCode = new SqlParameter("@OCODE", OCODE);
                    var groupId = new SqlParameter("@GroupId", GroupId);
                    var productId = new SqlParameter("@ProductId", ProductId);
                    var Store = new SqlParameter("@StoreCode", storeCode);
                    string SP_SQL = "Inv_Rpt_StockDetails_ByDate_Product_WithStore @FromDate,@ToDate,@OCODE,@GroupId,@ProductId,@StoreCode ";
                    return (_context.ExecuteStoreQuery<productsDetails>(SP_SQL, DateForm, DateTo, OCode, groupId, productId, Store)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<productsDetails> Rpt_GetFullStockDetailsByDate_Product(string FromDate, string ToDate, string OCODE, string GroupId, string ProductId)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var DateForm = new SqlParameter("@FromDate", FromDate);
                    var DateTo = new SqlParameter("@ToDate", ToDate);
                    var OCode = new SqlParameter("@OCODE", OCODE);
                    var groupId = new SqlParameter("@GroupId", GroupId);
                    var productId = new SqlParameter("@ProductId", ProductId);
                    string SP_SQL = "Inv_Rpt_StockDetails_ByDate_Product @FromDate,@ToDate,@OCODE,@GroupId,@ProductId ";
                    return (_context.ExecuteStoreQuery<productsDetails>(SP_SQL, DateForm, DateTo, OCode, groupId, productId)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<productsDetails> Rpt_GetFullStockDetailsByDate_Product_Store(string FromDate, string ToDate, string OCODE, string GroupId, string ProductId, string storeCode, Guid UserId)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var DateForm = new SqlParameter("@FromDate", FromDate);
                    var DateTo = new SqlParameter("@ToDate", ToDate);
                    var OCode = new SqlParameter("@OCODE", OCODE);
                    var groupId = new SqlParameter("@GroupId", GroupId);
                    var productId = new SqlParameter("@ProductId", ProductId);
                    var Store = new SqlParameter("@StoreCode", storeCode);
                    var userId = new SqlParameter("@UserId", UserId);

                    string SP_SQL = "Inv_Rpt_StockDetails_ByDate_Product_Store @FromDate,@ToDate,@OCODE,@GroupId,@ProductId,@StoreCode,@UserId";
                    return (_context.ExecuteStoreQuery<productsDetails>(SP_SQL, DateForm, DateTo, OCode, groupId, productId, Store, userId)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<productsDetails> Get_StockDetailsByDate_Product_Store(string FromDate, string ToDate, string OCODE, string GroupId, string ProductId, string storeCode, Guid UserId)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var DateForm = new SqlParameter("@FromDate", FromDate);
                    var DateTo = new SqlParameter("@ToDate", ToDate);
                    var OCode = new SqlParameter("@OCODE", OCODE);
                    var groupId = new SqlParameter("@GroupId", GroupId);
                    var productId = new SqlParameter("@ProductId", ProductId);
                    var Store = new SqlParameter("@StoreCode", storeCode);
                    var userId = new SqlParameter("@UserId", UserId);

                    string SP_SQL = "Inv_Get_StockDetails_ByDate_Product_Store @FromDate,@ToDate,@OCODE,@GroupId,@ProductId,@StoreCode,@UserId";
                    return (_context.ExecuteStoreQuery<productsDetails>(SP_SQL, DateForm, DateTo, OCode, groupId, productId, Store, userId)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        public List<productsDetails> Rpt_GetStockBy_Store_LessThanQty(string StoreCode, int Qty)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var store = new SqlParameter("@StoreCode", StoreCode);
                    var qty = new SqlParameter("@QtyLessThen", Qty);
                    string SP_SQL = "INV_FullStockReportsBy_Store_Product_Qty_RPT @StoreCode,@QtyLessThen ";
                    return (_context.ExecuteStoreQuery<productsDetails>(SP_SQL, store, qty)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }
        public List<productsDetails> Rpt_GetStockBy_Store_ReOrderQty(string StoreCode)
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var store = new SqlParameter("@StoreCode", StoreCode);
                    string SP_SQL = "INV_FullStockReportsBy_Store_ReOrderQty_RPT @StoreCode";
                    return (_context.ExecuteStoreQuery<productsDetails>(SP_SQL, store)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }


        internal List<Inv_BuyCentral> GetAllMAsterLC()
        {
            try
            {

                using (var _context = new ERPSSL_INVEntities())
                {
                    var MasterLC = (from LC in _context.Inv_BuyCentral

                                    select LC).OrderBy(x => x.Id).DistinctBy(x=>x.MasterLCNo);
                    return MasterLC.ToList();
                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Inv_BuyCentral> GetAllB2BLC()
        {
           try
           {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var B2BC = (from LC in _context.Inv_BuyCentral
                                    select LC).OrderBy(x => x.Id).DistinctBy(x=>x.B2BLCNo);
                    return B2BC.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<Inv_BuyCentral> GetAllPiNoLC()
        {
            try
            {
                using (var _context = new ERPSSL_INVEntities())
                {
                    var PiNo = (from LC in _context.Inv_BuyCentral
                                select LC).OrderBy(x => x.Id).DistinctBy(x => x.PI_No);
                    return PiNo.ToList();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}