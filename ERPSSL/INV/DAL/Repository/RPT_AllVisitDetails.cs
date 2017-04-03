using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.INV.DALRepository
{
    public class RPT_AllVisitDetails
    {
        public int PlanNo { get; set; }
        public DateTime Visit_Date { get; set; }
        public TimeSpan Visit_Time { get; set; }
        public string Client_Name { get; set; }
        public string Contact_Person { get; set; }
        public string CallType { get; set; }
        public string SheduleType { get; set; }
        public string PriorityName { get; set; }
        public string Visit_Task_Status { get; set; }
        public DateTime Next_Action_Date { get; set; }
        public string Next_Action_Plan { get; set; }
        public TimeSpan Next_Action_Time { get; set; }
        public string Next_Responsible_Person { get; set; }


    }
}