using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Dashboard.Repository
{
    public class InventoryDetailsR
    {
       
        public int TotalStock { get; set; }
        public int TotalPurchase { get; set; }
        public int TotalIssue { get; set; }
        public int TotalDamage { get; set; }
        public int TotalReturn { get; set; }


        public int TotalMRR { get; set; }
        public int TotalGIN { get; set; }
        public int TotalTodayDamage { get; set; }
        public int TotalTodayReturn { get; set; }


        public int TotalStoreReq { get; set; }
        public int ApproveStoreReq { get; set; }
        public int TotalPurchaseReq { get; set; }
        public int ApprovePurchaseReq { get; set; }

        public int LastMonthMRR { get; set; }
        public int LastMonthStoreReq { get; set; }
        public int LastMonthGIN { get; set; }
        public int LastMonthPurchaseReq { get; set; }
    }
}
