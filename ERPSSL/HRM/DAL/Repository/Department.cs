using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class Department
    {
        public int DPT_ID { set; get; }
        public int Office_ID { set; get; }
        public string OfficeName { set; get; }
        public string DPT_NAME { set; get; }
        public string DPT_CODE { set; get; }
        public string ResionName { set; get; }
    }
}