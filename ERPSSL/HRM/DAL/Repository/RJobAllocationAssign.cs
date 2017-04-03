using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class RJobAllocationAssign
    {
        public string JobAllocationCode { set; get; }
        public string ClientName { set; get; }
        public string Reasion { set; get; }
        public string Remark { set; get; }
        public string RequestFrom { set; get; }
        public DateTime JobAllocationDate { set; get; }
    }
}