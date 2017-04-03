using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Production.DAL.Repository
{
    public class FinishingDetailsR
    {
        public int ID { get; set; }

        public int? CuttingID { get; set; }

        public string OrderNo { get; set; }

        public double? OrderQty { get; set; }

        public string GoodsName { get; set; }

        public double? FGoodsQty { get; set; }

        public string FGoodsUnit { get; set; }

        public int? SewingID { get; set; }

        public int? BuyerID { get; set; }

        public DateTime? TotalWashingCompleteDate { get; set; }

        public double? TotalWashingCompleteQty { get; set; }

        public int? TotalWashingCompleteUnit { get; set; }

        public int Buyer_ID { get; set; }

        public string BuyerName { get; set; }

        public int UnitId { get; set; }

        public string UnitName { get; set; }

        public int? TotalFinishingCompleteUnit { get; set; }

        public double? TotalFinishingCompleteQty { get; set; }

        public DateTime? TotalFinishingCompleteDate { get; set; }

        public int? TotalFinishingReceivedUnit { get; set; }

        public double? TotalFinishingReceivedQty { get; set; }

        public DateTime? TotalFinishingReceivedDate { get; set; }

        public int? WashingID { get; set; }
    }
}