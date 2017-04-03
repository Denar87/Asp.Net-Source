using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ERPSSL.LC.DAL.Repository;

namespace ERPSSL.LC.DAL
{
    public class ShipmentScheduleDAL
    {
        ERPSSL_LCEntities _Content = new ERPSSL_LCEntities();
        internal List<LC_OrderEntry> GetOrderList(string Ocode)
        {
            try
            {
                List<LC_OrderEntry> Orders = (from Order in _Content.LC_OrderEntry
                                              where Order.OCODE == Ocode && Order.CompShipmentDate != null
                                              select Order).OrderBy(x => x.OrderNo).ToList();
                return Orders;
            }
            catch (Exception)
            {
                throw;
            }
        }

        internal List<LC_OrderEntry> GetALLByOrderNo(string OrderNo, string OCode)
        {
            try
            {
                var query = (from Order in _Content.LC_OrderEntry
                             where Order.OCODE == OCode && Order.OrderNo == OrderNo && Order.CompShipmentDate == null
                             select Order).OrderBy(x => x.OrderNo);
                return query.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message.ToString());
            }
        }

        internal int UpdateOrder(String orderEntry, LC_OrderEntry orderObj)
        {
            try
            {
                LC_OrderEntry ObjLOrder = _Content.LC_OrderEntry.First(x => x.OrderNo == orderEntry);
                ObjLOrder.ExtendShipmentDate = orderObj.ExtendShipmentDate;
                ObjLOrder.Shipment_Mode = orderObj.Shipment_Mode;
                ObjLOrder.ShipmentCompStatus = orderObj.ShipmentCompStatus;
                ObjLOrder.CompShipmentDate = orderObj.CompShipmentDate;
                _Content.SaveChanges();
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }

        internal List<Rep_MasterLC> GetseasonName(string orderNo)
        {
            try
            {
                var ItemName = (from order in _Content.LC_OrderEntry
                                join master in _Content.LC_MasterLC on order.Season equals master.Season
                                join bye in _Content.Com_Buyer_Setup on master.Buyer_ID equals bye.Buyer_ID
                                where order.OrderNo == orderNo
                                select new Rep_MasterLC
                                {
                                    BayerName = bye.Buyer_Name
                                });
                return ItemName.ToList();
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
        }

        internal List<LC_OrderEntry> GetCompleteOrderByDate(String Ocode,DateTime fromDate, DateTime ToDate)
        {
            var result=(from order in _Content.LC_OrderEntry
                            where order.OCODE==Ocode && order.CompShipmentDate >= fromDate && order.CompShipmentDate <=ToDate
                            select order).ToList();
            return result;
        }
    }
}