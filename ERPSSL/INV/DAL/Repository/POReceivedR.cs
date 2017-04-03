using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.INV.DAL.Repository
{
    public class POReceivedR
    {
        public string PrOrderNo { set; get; }

        public DateTime? OrderDate{set;get;}

        public string SupplierName { set; get; }
        public string StyleAndSize { get; set; }
        public string ProductName { get; set; }
        public string Brand { get; set; }
        public double? ReceiveQuantity { get; set; }        
        public string ChallanNo { get; set; }
        public string UnitName { get; set; }
        public DateTime? ChallanDate { get; set; }
        
    }
}