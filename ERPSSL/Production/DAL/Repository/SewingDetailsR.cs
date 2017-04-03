using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Production.DAL.Repository
{
    public class SewingDetailsR
    {

        public int UnitId { get; set; }

        public string UnitName { get; set; }

        public int ID { get; set; }

        public string GoodsName { get; set; }

        public double? OrderQty { get; set; }

        public DateTime? CuttingDate { get; set; }

        public double? CuttingReceivedQty { get; set; }

        public string ReceivedUnit { get; set; }

        public int? TotalCompleteUnit { get; set; }

        public double? TotalCuttingCompleteQty { get; set; }

        public DateTime? CuttingCompleteDate { get; set; }

        public string OrderNo { get; set; }

        public double? FGoodsQty { get; set; }

        public string FGoodsUnit { get; set; }

        public DateTime? CuttingReceivedDate { get; set; }

        public int? CuttingReceivedUnit { get; set; }

        public string TotalCuttingCompleteUnit { get; set; }

        public int? Buyer_ID { get; set; }

        public string BuyerName { get; set; }

        public int? BuyerID { get; set; }

        public string Buyer_Name { get; set; }

        public DateTime? SewingReceivedDate { get; set; }

        public double? TotalSewingReceivedQty { get; set; }

        public int? TotalSewingReceivedUnit { get; set; }

        public DateTime? SewingCompleteDate { get; set; }

        public double? TotalSewingCompleteQty { get; set; }

        public int? TotalSewingCompleteUnit { get; set; }

        public int? CuttingID { get; set; }
    }
}