using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class Section
    {

        public int SEC_ID { set; get; }
        public string SEC_NAME { set; get; }
        public string DepartmentName { set; get; }
        public string OfficeName { set; get; }
        public string RegionName { set; get; }
    }
}