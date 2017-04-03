using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.INV.DAL.Repository
{
    public class RReturn
    {
        public string ChallanNo { set; get; }
        public string GroupName { set; get; }
        public string ProductName { set; get; }
        public string Brand { set; get; }
        public string StyleSize { set; get; }
        public string FloorName { set; get; }
        public string UnitName { set; get; }

        public double ReceiveQuantity { set; get; }
        public double CPU { set; get; }
        public double RPU { set; get; }
        public double VAT { set; get; }
        public double BalanceQuanity { set; get; }
        public double DeliveryQty { set; get; }
        public double SupplierReturnQty { set; get; }
        public double ERetQty { set; get; }
        public DateTime? EditDate { set; get; }
        public string SupplierName { set; get; }
        public string ReturnType { set; get; }
        public DateTime? ReturnDate { set; get; }
        public DateTime? PurchaseDate { set; get; }
        public string Store_Code { set; get; }
    }
}