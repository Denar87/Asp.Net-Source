using ERPSSL.BuyingHouse.DAL;
using ERPSSL.BuyingHouse.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.LC.DAL;

namespace ERPSSL.BuyingHouse.BLL
{
    public class BuyingHouseReportBLL
    {
        BuyingHouseReportDAL _reportdal = new BuyingHouseReportDAL();

        internal List<BuyingHouseReport> GetSampledetailsReport(string OCode)
        {
            return _reportdal.GetSampledetailsReport(OCode);
        }

        internal List<BuyingHouseReport> GetFactoryDetailsReport(string OCode)
        {
            return _reportdal.GetFactoryDetailsReport(OCode);
        }

        internal List<BuyingHouseReport> GetBuyerDetailsReport(string OCode)
        {
            return _reportdal.GetBuyerDetailsReport(OCode);
        }
        internal List<BuyingHouseReport> GetOrderDetailsReport(DateTime FromDate,DateTime ToDate,string supplierNo, string OCode)
        {
            return _reportdal.GetorderDetailsReport(FromDate, ToDate,supplierNo, OCode);
        }

        internal List<BuyingHouseReport> GetCompleteShipmentReport(string OCode)
        {
            return _reportdal.GetCompleteShipmentReport(OCode);
        }

        internal List<LC_OrderEntry> GetAll_SupplierNo(string OCode)
        {
            return _reportdal.GetAll_SupplierNo(OCode);
        }

        internal List<BuyingHouseReport> GetShipmentReport(string OCode)
        {
            return _reportdal.GetShipmentReport(OCode);
        }

        internal List<BuyingHouseReport> GetProductionProcessDetailsReport(string OCode)
        {
            return _reportdal.GetProductionProcessDetailsReport(OCode);
        }

        internal List<BuyingHouseReport> GetProductionStatusDetailsReport(string OCode)
        {
            return _reportdal.GetProductionStatusDetailsReport(OCode);
        }
        internal List<BuyingHouseReport> GetTaskDetailsReport(string OCode)
        {
            return _reportdal.GetTaskDetailsReport(OCode);
        }
        internal List<BuyingHouseReport> GetTaskDetailsByOrderReport(string order, string OCode)
        {
            return _reportdal.GetTaskDetailsByOrderReport(order, OCode);
        }

        internal List<BuyingHouseReport> GetProductionDetailsByOrderReport(string OrderNo, string OCode)
        {
            return _reportdal.GetProductionDetailsByOrderReport(OrderNo, OCode);
        }

        internal List<BuyingHouseReport> GetCompleteShipmentByOrder(string OrderNo, string OCode)
        {
            return _reportdal.GetCompleteShipmentByOrder(OrderNo, OCode);
        }

        internal List<BuyingHouseReport> GetShipmentByOrder(string OrderNo, string OCode)
        {
            return _reportdal.GetShipmentByOrder(OrderNo, OCode);
        }

        internal List<BuyingHouseReport> GetOrderDetailsByOrder(string OrderNo, DateTime FromDate, DateTime ToDate, string supplierNo, string OCode)
        {
            return _reportdal.GetOrderDetailsByOrder(OrderNo, FromDate, ToDate, supplierNo, OCode);
        }

        internal List<BuyingHouseReport> GetAllorderDetailsReport(string OCode)
        {
            return _reportdal.GetAllorderDetailsReport(OCode);
        }
        internal List<BuyingHouseReport> OrderDetailsByOrderNo(string Order,string OCode)
        {
            return _reportdal.OrderDetailsByOrderNo(Order,OCode);
        }

        internal List<BuyingHouseReport> GetOrderDetailsByDate(DateTime FromDate, DateTime ToDate, string OCode)
        {
            return _reportdal.GetOrderDetailsByDate(FromDate, ToDate, OCode);
        }

        internal List<BuyingHouseReport> OrderDetailsBySupplier(string supplierNo, string OCode)
        {
            return _reportdal.OrderDetailsBySupplier(supplierNo, OCode);
        }

        internal List<BuyingHouseReport> GetAllorderSummaryReport(string OCode)
        {
            return _reportdal.GetAllorderSummaryReport(OCode);
        }

        internal List<BuyingHouseReport> GetAllorderBuyerWiseReport(string OCode,DateTime FromDate,DateTime ToDate)
        {
            return _reportdal.GetAllorderBuyerWiseReport(OCode,FromDate,ToDate);
        }
    }
}