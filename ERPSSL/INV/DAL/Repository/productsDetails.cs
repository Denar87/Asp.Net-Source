using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.INV.DAL.Repository
{
    public class productsDetails
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyMobile { get; set; }
        public string Ocode { get; set; }
        public byte[] Logo { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public string CustomAssetName { get; set; }
        public string Brand { get; set; }
        public string StyleAndSize { get; set; }
        public string UnitName { get; set; }
        public string FloorName { get; set; }
        public double? ReOrderQty { get; set; }
        public double? ReOrderQuantity { get; set; }
        public decimal? Price { get; set; }
        public string GroupName { get; set; }
        public double? TotalPrice { get; set; }
        public decimal? CPU { get; set; }



        public string OfficeName { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }
        public string BarCode { get; set; }
        public string StyleSize { get; set; }
        public double? BalanceQuanity { get; set; }
        public double? PrqBalanceQuanity { get; set; }
        public string Project_Name { get; set; }

        public string StoreName { get; set; }
        public string Store_Unit_Name { get; set; }
        public double? ReceiveQuantity { get; set; }
        public double? DeliveryQty { get; set; }
        public double? ReturnQty { get; set; }
        public double? SupplierReturnQty { get; set; }
        public double? ERetQty { get; set; }
        public double? ClosingBalance { get; set; }
        public double? StartDate_Opening { get; set; }

        public double? OpeningBalance { get; set; }
        public double? NewDamageQty { get; set; }
        public DateTime StartDates { get; set; }
        public DateTime EndDates { get; set; }
        public DateTime? StockDate { get; set; }
        

        public int ProductId { get; set; }

        public int UserwiseProductGroup_Id { get; set; }

        public string AssetCode { get; set; }
        public string OwnershipType { get; set; }
        public decimal? ReschedualCost { get; set; }
        public string RegionCode { get; set; }
        public string OfficeCode { get; set; }
        public string DepartmentCode { get; set; }
        public string UserName { get; set; }
        public decimal? ACOBAccounting { get; set; }
        public decimal? ACOBTax { get; set; }
        public decimal? DPOBAccounting { get; set; }
        public decimal? DPOBTax { get; set; }
        public decimal? RROBAccounting { get; set; }


        public int? productGroup { get; set; }
        public int? CompanyId { get; set; }
        public string CompanyCode { get; set; }
        public DateTime? PurchaseDate { get; set; }
       
        public string SupplierName { get; set; }
        public string EID { get; set; }
        public string ChallanNo { get; set; }
        

        //public double? RROBTax { get; set; }
        //public double? DTOBAsset { get; set; }
        //public double? DTOBLiability { get; set; }

        public string SupplierCode { get; set; }

        public string RefNo_ChallanNo { get; set; }

        public int? OrderEId { get; set; }

        public int? SeasonID { get; set; }

        public int? Store_Id { get; set; }

        public string B2BLCNo { get; set; }

        public string MasterLCNo { get; set; }
    }
}