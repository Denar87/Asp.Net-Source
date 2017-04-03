using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Production.DAL.Repository
{
    public class ReportR
    {
        public string OfficeName { set; get; }
        public string ResionName { set; get; }
        public string DepartmentName { set; get; }
        public string CompanyName { set; get; }
        public string CompanyAddress { set; get; }
        public string CompanyWeb { set; get; }
        public string CompanyMail { set; get; }
        public string CompanyMobile { set; get; }
        public byte[] Logo { set; get; }

        public string Address { set; get; }
        public string Web { set; get; }
        public string Email { set; get; }
        public string Mobile { set; get; }


        public int ID { get; set; }

        public string OrderNo { get; set; }

        public int? CuttingID { get; set; }

        public double? OrderQty { get; set; }

        public string GoodsName { get; set; }

        public double? FGoodsQty { get; set; }

        //public string FGoodsUnit { get; set; }

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

        public DateTime? CuttingDate { get; set; }

        public double? CuttingReceivedQty { get; set; }

        //public string ReceivedUnit { get; set; }

        public int? TotalCompleteUnit { get; set; }

        public double? TotalCuttingCompleteQty { get; set; }

        public DateTime? CuttingCompleteDate { get; set; }

        public DateTime? CuttingReceivedDate { get; set; }

        public int? CuttingReceivedUnit { get; set; }

        //public string TotalCuttingCompleteUnit { get; set; }

        public string Buyer_Name { get; set; }

        public DateTime? SewingReceivedDate { get; set; }

        public double? TotalSewingReceivedQty { get; set; }

        public int? TotalSewingReceivedUnit { get; set; }

        public DateTime? SewingCompleteDate { get; set; }

        public int? TotalFinishingCompleteUnit { get; set; }

        public double? TotalFinishingCompleteQty { get; set; }

        public DateTime? TotalFinishingCompleteDate { get; set; }

        public int? TotalFinishingReceivedUnit { get; set; }

        public double? TotalFinishingReceivedQty { get; set; }

        public DateTime? TotalFinishingReceivedDate { get; set; }

        public int? WashingID { get; set; }

        public int? BuyerID { get; set; }

    }
}