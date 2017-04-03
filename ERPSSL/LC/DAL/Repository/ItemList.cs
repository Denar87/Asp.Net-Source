using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.LC.DAL.Repository
{
    public class ItemList
    {
        public string ProductName { get; set; }
        public double? BalanceQuanity { get; set; }
        public string UnitName { get; set; }
        public string B2BLCNo { get; set; }
        public string MasterLCNo { get; set; }
        public DateTime BBLCDate { get; set; }
        public string Season { get; set; }
        public string POOrderNo { get; set; }
        public string PI { get; set; }
        public DateTime ExpireDate { get; set; }
        public DateTime PIDate { get; set; }

        public int Measurement_Id { get; set; }
        public string FinishGoodsName { get; set; }
        public string MagermentName { get; set; }

        public int CurrentBuyer { get; set; }
        public int TotalOrder { get; set; }
        public int TotalOrderBefore7days { get; set; }
        public int TotalListedNooFactory { get; set; }
        public Double TotalExistingOrderAmountinUSD { get; set; }
        public int PendingTask { get; set; }
        public int ScheduleDate { get; set; }


        public string Order_No { get; set; }
        public int Task_Number { get; set; }

        public string Task { get; set; }
        public string Status { get; set; }
        public string Responsible_Person { get; set; }
        public DateTime? Schedule_Date { get; set; }
        public string Comments { get; set; }
        public int TaskDetails_Id { get; set; }



        public int ProductionProcces_Id { get; set; }
        public string ProductionProcess { get; set; }
        public decimal? TergetQty { get; set; }


        public double? DailyProduction { get; set; }

        public double? TergetLine { get; set; }

        public int ProductionStatus_Id { get; set; }

        public double? AchievementPercentage { get; set; }

        public double? DayInput { get; set; }

        public DateTime? InputDate { get; set; }
    }
}