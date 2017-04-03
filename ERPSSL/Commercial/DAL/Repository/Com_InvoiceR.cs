using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Commercial.DAL.Repository
{
    public class Com_InvoiceR
    {

        public string DepartmentName { set; get; }
        public string CompanyName { set; get; }
        public string CompanyAddress { set; get; }
        public string CompanyMobile { set; get; }
        public string CompanyWeb { set; get; }
        public string CompanyMail { set; get; }
        public string ResionName { set; get; }
        public string OfficeName { set; get; }
        
        public double? NetWGT { get; set; }

        public double? GrossWGT { get; set; }

        public double? TotalCtns { get; set; }

        public double? CubicM3CBM { get; set; }

        public double? G_Total { get; set; }

        public double? PRC_Descount { get; set; }

        public double? Bonus_Discount { get; set; }

        public double? Total { get; set; }

        public double? Rate { get; set; }

        public string ColorSpecification { get; set; }

        public string Currency_Type { get; set; }

        public double? UnitPrice { get; set; }

        public double? OrderQty { get; set; }

        public int? OrderEntryID { get; set; }
        public string orderQuntity { get; set; }

        public string H_S_Code { get; set; }

        public string CAT_No { get; set; }

        public string Style { get; set; }

        public string Article { get; set; }

        public string OrderNo { get; set; }

        public string Season { get; set; }

        public string Remarks { get; set; }

        public string NoKindofPackages { get; set; }

        public string BuyingDept { get; set; }

        public string MarksNumbers { get; set; }

        public string ContainerNo { get; set; }

        public string Destination { get; set; }

        public string OriginatedCountry { get; set; }

        public string DeliveryAddress { get; set; }

        public string IssuingBank { get; set; }

        public DateTime? LCDate { get; set; }

        public string LCNo { get; set; }

        public string EXPNo { get; set; }

        public DateTime? EXPDate { get; set; }

        public string NotifyParty { get; set; }

        public string Consignee { get; set; }

        public int? BayerId { get; set; }

        public DateTime? InvoiceDate { get; set; }

        public string InvoiceNo { get; set; }

        public int InvoiceId { get; set; }

        public string UnitName { get; set; }

        public string Buyer_Name { get; set; }

        public string Address { get; set; }

        public string ERCNo { get; set; }

        public DateTime? ERCDate { get; set; }

        public string REGNo { get; set; }

        public DateTime? REGDate { get; set; }

        public string AreaCode { get; set; }

        public double? Bonus_TotalDis { get; set; }

        public double? PRC_TotalDis { get; set; }

        public string HS_Code { get; set; }

        public string Specification { get; set; }


        public int? Quntity { get; set; }

        public int? Qty { get; set; }

        public decimal? Price { get; set; }

        public decimal? TotalAmount { get; set; }

        public string Size { get; set; }

        public string Color { get; set; }

        public string ItemName { get; set; }

        public int SizeId { get; set; }

        public int colorId { get; set; }

        public int ItemId { get; set; }
    }
}