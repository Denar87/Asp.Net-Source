using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class SubSection
    {
        public int SUB_SEC_ID { set; get; }
        public string SUB_SEC_NAME { set; get; }
        public string SectionName { set; get; }
        public string DepartmentName { set; get; }
        public string OfficeName { set; get; }
        public string RegionName { set; get; }
    }
}