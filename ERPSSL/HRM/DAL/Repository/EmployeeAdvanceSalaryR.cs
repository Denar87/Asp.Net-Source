using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class EmployeeAdvanceSalaryR
    {
        public Int64? AdvanceSalaryId { set; get; }
        public Int64? AdvanceSalaryDetailsId { set; get; } 
        public string EmployeeName { set; get; }
        public string EID { set; get; }
        public decimal? TotalAmount { set; get; }
        public int? NoOfInstalment { set; get; }
        public DateTime? StartDate { set; get; }
        public DateTime? EndDate { set; get; }
        public string ResionName { set; get; }
        public string OfficeName { set; get; }
        public string DepartmentName { set; get; }
        public string ASCode { set; get; }
        public string Month_Name { set; get; }
        public int Year { set; get; }
    }
}