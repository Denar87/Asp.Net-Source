using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.LC.DAL;
using ERPSSL.LC.DAL.Repository;

namespace ERPSSL.LC.BLL
{
    
    public class ShipmentSheduleBLL
    {
        ShipmentScheduleDAL shipmentBll = new ShipmentScheduleDAL();

        internal List<LC_OrderEntry> GetOrderList(string Ocode)
        {
            return shipmentBll.GetOrderList(Ocode);
        }

        internal List<LC_OrderEntry> GetALLByOrderNo(string OrderNo, string OCode)
        {
            return shipmentBll.GetALLByOrderNo(OrderNo, OCode);
        }



        internal int UpdateOrder(string orderEntry, LC_OrderEntry orderObj)
        {
            return shipmentBll.UpdateOrder(orderEntry,orderObj);
        }
        internal List<Rep_MasterLC> GetseasonName(string orderNo)
        {
            return shipmentBll.GetseasonName(orderNo);
        }

        internal List<LC_OrderEntry> GetCompleteOrderByDate(String Ocode,DateTime fromDate, DateTime ToDate)
        {
            return shipmentBll.GetCompleteOrderByDate(Ocode,fromDate,ToDate);
        }

        //internal int getShipmentMode(string OCode)
        //{
        //    return shipmentBll.getShipmentMode(OCode);
        //}
    }
}