using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class LeaveInfo
    {
        public Int32? LeaveId { set; get; }
        public string LeaveCode { set; get; }
        //public string DisApproveStatus { set; get; }
        public string Eid { set; get; }
        public string LeaveAppliedDate { set; get; }
        public string LeaveDates { set; get; }
        public int? LeaveTypeId { set; get; }
        public string LeaveType { set; get; }
        public int? TotalDay { set; get; }
        public string LeaveResion { set; get; }
        public string LeaveStatus { set; get; }
        public string LeaveStatusHRM { set; get; }
        public string FullName { set; get; }
        public string Designation { set; get; }
        public string Department { set; get; }

        

        public string ApproveOrDisApproveStatus { set; get; }

    }
}