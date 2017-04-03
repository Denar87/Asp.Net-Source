using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.INV.DAL.Repository
{
    public class RDepartmentType
    {
        public int DepartmentTypeId { set; get; }
        public int Office_ID { set; get; }
        public string OfficeName { set; get; }
        public string DPT_NAME { set; get; }
        public string DPT_CODE { set; get; }
        public string ResionName { set; get; }
        public string DepartmentType { set; get; }
    }
}