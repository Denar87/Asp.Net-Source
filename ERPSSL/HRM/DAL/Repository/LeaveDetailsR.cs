using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class LeaveDetailsR
    {
        public string ReprotingBoss1 { set; get; }
        public string ReprotingBoss2 { set; get; }
        public string ReportingBossHRM{set;get;}
        public int LeaveTypeID { set; get; }
        public string EID { set; get; }
        public string LeaveCode { set; get; }
        public DateTime LeaveAppliedDate { set; get; }
        public DateTime Todate { set; get; }
        public DateTime fromDate { set; get; }
        public  string LeaveType { set; get; }
        public string LeaveReson { set; get; }
       

    }
}