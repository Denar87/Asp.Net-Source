using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class RJobAllocation
    {
        public string Employee { set; get; }
        public string Eid { set; get; }
        public string Contact { set; get; }
        public string DepartmentName { set; get; }
        public string Region { set; get; }
        public string Office { set; get; }
        public string JobAllocationCode { set; get; }
        public string ClientName { set; get; }
        public string Razion { set; get; }
        public string Remark { set; get; }
        public string RequestFrom { set; get; }
        public DateTime JobAllocationDate { set; get; }
       
    }
}