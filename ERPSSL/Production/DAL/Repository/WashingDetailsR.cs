using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Production.DAL.Repository
{
    public class WashingDetailsR
    {

        public int ID { get; set; }

        public string OrderNo { get; set; }

        public int? CuttingID { get; set; }

        public double? OrderQty { get; set; }

        public string GoodsName { get; set; }

        public double? FGoodsQty { get; set; }

        public string FGoodsUnit { get; set; }

        public double? TotalSewingCompleteQty { get; set; }

        public int? TotalSewingCompleteUnit { get; set; }

        public int Buyer_ID { get; set; }

        public string BuyerName { get; set; }

        public int UnitId { get; set; }

        public string UnitName { get; set; }

        public DateTime? TotalWashingReceivedDate { get; set; }

        public double? TotalWashingReceivedQty { get; set; }

        public int? TotalWashingReceivedUnit { get; set; }

        public DateTime? TotalWashingCompleteDate { get; set; }

        public double? TotalWashingCompleteQty { get; set; }

        public int? TotalWashingCompleteUnit { get; set; }

        public int? SewingID { get; set; }

        public int? BuyerID { get; set; }
    }
}