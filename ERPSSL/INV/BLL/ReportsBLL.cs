using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using ERPSSL.INV.DAL;
using System.Data;
using System.Collections;
using ERPSSL.INV.DAL.Repository;


namespace ERPSSL.INV.BLL
{
    public class ReportsBll
    {
        DataAccessEX ado = new DataAccessEX();
        
        string conn = ConfigurationManager.ConnectionStrings["ERPSSLADO"].ConnectionString;
        ReportDal OBJ = new ReportDal();

        internal DataTable GetPurchaseReportData(Hashtable ht)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataByProc(ht, "INV_AllPurchaseReports_RPT", conn);
            }
            catch { }
            return dt;
        }

        internal DataTable GetDeliveryReportData(Hashtable ht)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataByProc(ht, "INV_AllDeliveryReports_RPT", conn);
            }
            catch { }
            return dt;
        }

        internal DataTable GetStockReportData(Hashtable ht)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataByProc(ht, "INV_StockReports_RPT", conn);
            }
            catch { }
            return dt;
        }

        internal DataTable GetReturnFromSupplier_BySupplier(Hashtable ht)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataByProc(ht, "Inv_Rpt_ReturnFromSupplier_BySupplier", conn);
            }
            catch { }
            return dt;
        }

        internal DataTable GetReturnToSupplier_Store_ByDate(Hashtable ht)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataByProc(ht, "Inv_Rpt_ReturnFromSupplier_ByDate", conn);
            }
            catch { }
            return dt;
        }

        internal DataTable GetReturnFromDept_ByEmp(Hashtable ht)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataByProc(ht, "Inv_Rpt_ReturnFromDept_ByEmp", conn);
            }
            catch { }
            return dt;
        }

        public List<productsDetails> Rpt_GetStockBy_ReOrderQty()
        {
            return OBJ.Rpt_GetStockBy_ReOrderQty();
        }
        public List<productsDetails> GetAllProductByGroupId(int groupID, string OCODE)
        {
            return OBJ.GetAllProductByGroupId(groupID, OCODE);
        }

        internal List<productsDetails> Rpt_GetAllProducts()
        {
            return OBJ.Rpt_GetAllProducts();
        }

        public List<SuplierDetails> Rpt_GetAllSupplier()
        {
            return OBJ.Rpt_GetAllSupplier();
        }

        internal List<ProductLog> Rpt_GetAllProduct(string OCODE)
        {
            return OBJ.Rpt_GetAllProduct(OCODE);
        }

        public List<productsDetails> Rpt_GetStockBy_Store(string StoreCode)
        {
            return OBJ.Rpt_GetStockBy_Store(StoreCode);
        }

        public List<productsDetails> Rpt_GetFullStockDetailsByDate_WithStore(string StoreCode, string FromDate, string ToDate, string OCODE)
        {
            return OBJ.Rpt_GetFullStockDetailsByDate_WithStore(StoreCode, FromDate, ToDate, OCODE);
        }

        public List<productsDetails> Rpt_GetFullStockDetailsByDate(string FromDate, string ToDate, string OCODE)
        {
            return OBJ.Rpt_GetFullStockDetailsByDate(FromDate, ToDate, OCODE);
        }

        public List<productsDetails> Rpt_GetFullStock()
        {
            return OBJ.Rpt_GetFullStock();
        }
        public List<productsDetails> Rpt_GetStockBy_Store_ProductGroup(string StoreCode, string productGroupId)
        {
            return OBJ.Rpt_GetStockBy_Store_ProductGroup(StoreCode, productGroupId);
        }
        public List<productsDetails> Rpt_GetFullStockDetailsByDate_Group_WithStore(string StoreCode, string FromDate, string ToDate, string OCODE, string GroupId)
        {
            return OBJ.Rpt_GetFullStockDetailsByDate_Group_WithStore(StoreCode, FromDate, ToDate, OCODE, GroupId);
        }
        public List<productsDetails> Rpt_GetFullStockDetailsByDate_Group(string FromDate, string ToDate, string OCODE, string GroupId)
        {
            return OBJ.Rpt_GetFullStockDetailsByDate_Group(FromDate, ToDate, OCODE, GroupId);
        }
        public List<productsDetails> Rpt_GetStockBy_Store_Product(string StoreCode, string productGroupId, string ProductId)
        {
            return OBJ.Rpt_GetStockBy_Store_Product(StoreCode, productGroupId, ProductId);
        }
        public List<productsDetails> Rpt_GetFullStockDetailsByDate_Product_WithStore(string FromDate, string ToDate, string OCODE, string GroupId, string ProductId, string storeCode)
        {
            return OBJ.Rpt_GetFullStockDetailsByDate_Product_WithStore(FromDate, ToDate, OCODE, GroupId, ProductId, storeCode);
        }
        public List<productsDetails> Rpt_GetFullStockDetailsByDate_Product(string FromDate, string ToDate, string OCODE, string GroupId, string ProductId)
        {
            return OBJ.Rpt_GetFullStockDetailsByDate_Product(FromDate, ToDate, OCODE, GroupId, ProductId);
        }
        public List<productsDetails> Rpt_GetFullStockDetailsByDate_Product_Store(string FromDate, string ToDate, string OCODE, string GroupId, string ProductId, string storeCode, Guid userId)
        {
            return OBJ.Rpt_GetFullStockDetailsByDate_Product_Store(FromDate, ToDate, OCODE, GroupId, ProductId, storeCode, userId);
        }
        public List<productsDetails> Get_StockDetailsByDate_Product_Store(string FromDate, string ToDate, string OCODE, string GroupId, string ProductId, string storeCode, Guid userId)
        {
            return OBJ.Get_StockDetailsByDate_Product_Store(FromDate, ToDate, OCODE, GroupId, ProductId, storeCode, userId);
        }
        public List<productsDetails> Rpt_GetStockBy_Store_LessThanQty(string StoreCode, int Qty)
        {
            return OBJ.Rpt_GetStockBy_Store_LessThanQty(StoreCode, Qty);
        }
        public List<productsDetails> Rpt_GetStockBy_Store_ReOrderQty(string StoreCode)
        {
            return OBJ.Rpt_GetStockBy_Store_ReOrderQty(StoreCode);
        }

        internal List<Inv_BuyCentral> GetAllMAsterLC()
        {
            return OBJ.GetAllMAsterLC();
        }

        internal DataTable GetDamageReportData(Hashtable ht)
        {
             DataTable dt = new DataTable();
            try
            {
                dt = ado.GetDataByProc(ht, "INV_AllDamageReports_RPT", conn);
            }
            catch { }
            return dt;
           
        }
       
        internal List<Inv_BuyCentral> GetAllB2BLC()
        {
            return OBJ.GetAllB2BLC();
        }
        internal List<Inv_BuyCentral> GetAllPiNoLC()
        {
            return OBJ.GetAllPiNoLC();
        }

    }
}