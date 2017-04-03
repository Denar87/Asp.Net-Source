using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.INV.DAL.Repository
{
    public class DeleveryProductR
    {
        public int? ID { set; get; }
        public int? BarCode { set; get; }
        public string ReqNo { set; get; }
        public DateTime? DesiredRcvDate { set; get; }
        public string ProductName { set; get; }
        public string EmployeeName { set; get; }
        public string EID { set; get; }
        public string UnitName { set; get; }
        public DateTime? ReqDate { set; get; }
        public double? BalanceQuanity { set; get; }
        public double? HeadApproveQty { set; get; }
        public string DeliveryType { set; get; }
        public string ChallanNo { set; get; }
        public DateTime? TransferDate { set; get; }
        public string DPT_CODE { set; get; }
        public string CurrentCompanyCode { set; get; }
        public string OldCompanyCode { set; get; }
        public string OCode { set; get; }
        public string StyleAndSize { set; get; }
        public decimal? Price { set; get; }
        public int? UnitId { set; get; }
        public string Item_Type { get; set; }
        public string StoreCode { get; set; }
        public string Brand { set; get; }
        public double? ReturnQty { set; get; }

        public double? LastRecived { set; get; }
        public string JobNo { set; get; }
        public int StyleId { get; set; }
        public int ProgramId { get; set; }
        public string Program { get; set; }
        public string Remarks { get; set; }
       
    }
}