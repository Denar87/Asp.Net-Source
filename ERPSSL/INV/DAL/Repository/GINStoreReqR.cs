using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.INV.DAL.Repository
{
    public class GINStoreReqR
    {
        public int Id { set; get; }
        public string DPT_CODE { set; get; }
        public string ReqNo { set; get; }
        public DateTime DesiredRcvDate { set; get; }
        public DateTime ReqDate { set; get; }
        public string EmployeeName { set; get; }
        public string DPT_NAME { set; get; }
        public string EID { set; get; }
        public string JobNo { set; get; }
        public string Program { set; get; }

       
    }
}