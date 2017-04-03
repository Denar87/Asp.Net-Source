using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class MaternityLeaveR
    {
        public Int64? MaternityLeaveId { set; get; }
        public string EID { set; get; }
        public string ReportingBossName { set; get; }
        public DateTime? AppliedDate { set; get; }
        public DateTime? LeaveDateFrom { set; get; }
        public DateTime? LeaveDateTo { set; get; }
        public int? TotalDay { set; get; }
        public string Description { set; get; }
        public string ApproveStatus { set; get; }
        public string DisApproveStatus { set; get; }
       

       

   
    }
}