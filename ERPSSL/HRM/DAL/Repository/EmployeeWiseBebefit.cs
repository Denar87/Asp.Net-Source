using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class EmployeeWiseBebefit
    {
       
        public Int64? employeeWiseBenefitId { set; get; }
        public string EmployeeName { set; get; }
        public string ResionName { set; get; }
        public string OfficeName { set; get; }
        public string DepartmentName { set; get; }
        public DateTime? EffectiveDate { set; get; }
        public decimal? Amount { set; get; }
        public string EID { set; get; }
        public string BenefitType { set; get; }
    }
}