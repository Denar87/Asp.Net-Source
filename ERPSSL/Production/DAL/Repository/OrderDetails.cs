using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Production.DAL.Repository
{
    public class OrderDetails
    {
        public int Id { get; set; }        
        public string Lc_Order { get; set; }
        public int? Buyer_ID { get; set; }
        public string BuyerName { get; set; }
        public int? FinishedGoods_ID { get; set; }
        public string FinishedGoodsName { get; set; }
        public double? FinishedGoods_Qty { get; set; }
        public DateTime? OrderDate { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public int? ProductUnit { get; set; }


    }
}