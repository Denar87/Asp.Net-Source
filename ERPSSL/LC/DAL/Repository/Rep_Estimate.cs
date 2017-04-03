using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.LC.DAL.Repository
{
    public class Rep_Estimate
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

        public double? Total_Cost { get; set; }
        public string LC_ReqNo { get; set; }
        
        public string Buyer_Name { get; set; }
        public string Lc_Style { get; set; }
        public string Lc_Order { get; set; }
        public string Ref_No { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Merchandiser_Name { get; set; }
       // public string FinishGoods_Name { get; set; }
        public double? FinishedGoods_Qty { get; set; }
        public bool? Estimation_Approval { get; set; }
        public string Cost_Estimate_ID { get; set; }
        public string FinishGoods_Name { get; set; }

        public string ProductName { get; set; }
        public string UnitName { get; set; }
        public string GroupName { get; set; }
        public string SupplierName { get; set; }
        public double? Qty_PC { get; set; }
        public double? Qty_Dzn { get; set; }
        public double? UnitPrice { get; set; }
        public double? TotalUnitQty { get; set; }
        public double? Amount { get; set; }
        public double? BalanceQty { get; set; }

        public int? Buyer_ID { get; set; }
        public int? UnitId { get; set; }
        public int? ProductId { get; set; }
        public int? GroupId { get; set; }
        public string SupplierCode { get; set; }
        public string ReqNo { get; set; }
        public DateTime? LC_ReqDate { get; set; }
        public bool? IsReqApproved { get; set; }
        public double? Req_ApprovedQty { get; set; }
        public double? Req_Qty { get; set; }
        public double? LC_PO_Qty { get; set; }

        public string LC_PO_No { get; set; }
        public int? LC_PurchaseOrder_Id { get; set; }
        public string PO_Type { get; set; }
        public DateTime? LC_PO_Date { get; set; }
        public bool? IsPO_Approved { get; set; }

        public string PO_No { get; set; }
        public string Delivery { get; set; }
        public string S_Range { get; set; }
        public double? Unit_Price { get; set; }
        public double? Amount_LC { get; set; }
        public string LC_Terms { get; set; }
        public double? Target_Cost { get; set; }

        public double? TotalFabricCost { get; set; }
        public double? TotalAccessoriesCost { get; set; }
        public double? WashingCost { get; set; }
        public double? LabTest { get; set; }
        public double? PrintCost { get; set; }
        public double? CM { get; set; }
        public double? TotalPrice { get; set; }
        public double? Commission { get; set; }
        public double? FinalPrice { get; set; }
        public string CompanyEmail { set; get; }

        //---------------------------------------  For Report   ----------------------------------

        public string LCNo { get; set; }
        public string LCType { get; set; }
        public DateTime? DateofIssue { get; set; }
        public DateTime? DateofExpiry { get; set; }
        public string BuyerType { get; set; }
        public string Season { get; set; }
        public double? Qty { get; set; }
        public string ItemDescription { get; set; }
        public decimal? USDRate { get; set; }
        public decimal? BDTRate { get; set; }
        public string LC_Issue_Bank { get; set; }
        public string Contact_Person { get; set; }
        //public string Mobile { get; set; }
        public string Phone { get; set; }
        public string Counter { get; set; }
        //public string Address { get; set; }
        public string Type { get; set; }
        public string Consignee { get; set; }
        public string NotifyParty { get; set; }




        //public double? BalanceQty { get; set; }
    }
}