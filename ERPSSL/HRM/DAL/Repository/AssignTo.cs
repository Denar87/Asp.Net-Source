using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class AssignTo
    {
        public string DeginationName { set; get; }
        public string DepartmentName { set; get; }
        public string EID { set; get; }
        public int DesginationId { set; get; }
        public int OfficeID { set; get; }
        public int DepartmentId { set; get; }
        public string DPT_CODE { set; get; }
        public string RequisitionNo { get; set; }
    }
}