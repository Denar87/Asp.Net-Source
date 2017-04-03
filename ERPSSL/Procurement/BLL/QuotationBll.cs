using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using ERPSSL.Procurement.DAL;

namespace ERPSSL.Procurement.BLL
{
    public class QuotationBll
    {



        internal static bool AddQuotation(Hashtable ht)
        {
            try
            {
                DataAccess.InsertData(ht, "PRQ_AddQuotation");
                return true;
            }
            catch
            {
                return false;
            }
        }


        internal static DataTable GetQuotationsByPrOrder(string PrOrderNo, string SupCode)
        {
            DataTable dt = new DataTable();
            Hashtable ht = new Hashtable();
            ht.Add("PrOrderNo", PrOrderNo);
            ht.Add("SupCode", SupCode);
            try
            {
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetQuotationsByPrOrder");
            }
            catch
            {

            }
            return
                dt;
        }

        internal static DataTable GetSupplierList(string PrOrderNo)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select SupplierCode, SupplierName from Inv_Supplier where Enlisted = 1");
            }
            catch { }
            return dt;
        }

        internal static DataTable QuotationReportReportData(Hashtable ht)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetQuotationsByPrOrder_RPT");
            }
            catch
            {

            }
            return
                dt;
        }

        internal static bool CompleteWorkOrder(string PrOrderNo, string SupCode, string BarCode, string Remarks)
        {
            try
            {

                DataAccess.AggRetrive("update PRQ_Quotations set IsSelected = 1 where PrOrderNo  = '" + PrOrderNo + "' and SupplierCode = '" + SupCode + "' and barCode = '" + BarCode + "'");
                DataAccess.AggRetrive("update PRQ_Quotations set Remarks = '" + Remarks + "' where PrOrderNo  = '" + PrOrderNo + "' and SupplierCode = '" + SupCode + "' and barCode = '" + BarCode + "'");
                DataAccess.AggRetrive("update PRQ_PurchaseOrders set IsWorkOrdered = 1 where PrOrderNo  = '" + PrOrderNo + "' and barCode = '" + BarCode + "'");
                return true;
            }
            catch
            {
                return false;
            }
        }

        internal static DataTable GetPurchaseOrder(Hashtable ht)
        {
            DataTable dt = new DataTable();
            try
            {

                dt = DataAccess.GetDataByProc(ht, "PRQ_WorkOrder_RPT");
            }
            catch
            {
            }
            return dt;
        }

        internal static DataSet GetQuotationMatrixData()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = DataAccess.GetDataSetByProc("PRQ_GetAllQuotationsForAllPruchaseOrder_RPT");
            }
            catch { }
            return ds;
        }

        internal static string GetCount(string PrOrderNo, string SupCode)
        {
            int count = 0;
            try
            {
                count = int.Parse(DataAccess.AggRetrive("select COUNT(*) from PRQ_Quotations where PrOrderNo = '" + PrOrderNo + "' and SupplierCode= '" + SupCode + "'").ToString());
            }
            catch { }
            return count++.ToString();
        }

        internal static object GetSupplierList()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select SupplierCode, SupplierName from Inv_Supplier");
            }
            catch { }
            return dt;
        }

        internal static DataTable GetBidders(string PrOrderNo, string BarCode)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = DataAccess.GetDataBySQLString("select Distinct Q.SupplierCode, S.SupplierName from Inv_Supplier S inner join PRQ_Quotations Q on Q.SupplierCode = S.SupplierCode where Q.PrOrderNo = '" + PrOrderNo + "' and Q.BarCode = '" + BarCode + "'");
            }
            catch { }
            return dt;
        }

        internal static DataTable GetQuotationsByBarCode(string PrOrderNo, string BarCode)
        {
            DataTable dt = new DataTable();
            Hashtable ht = new Hashtable();
            ht.Add("PrOrderNo", PrOrderNo);
            ht.Add("BarCode", BarCode);
            try
            {
                dt = DataAccess.GetDataByProc(ht, "PRQ_GetQuotationsByBarCode");
            }
            catch
            {

            }
            return dt;
        }
    }
}