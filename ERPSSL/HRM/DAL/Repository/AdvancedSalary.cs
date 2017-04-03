using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class AdvancedSalary
    { 
        public string ASCode { get; set; }
        public string EID { get; set; } 
        public decimal InstalmentAmount { get; set; } 
        public int NoOfInstalment { get; set; } 
        public decimal TotalAmount { get; set; } 
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }
        public string OfficeName { set; get; }
        public string ResionName { set; get; }
        public string DepartmentName { set; get; }
        public string CompanyName { set; get; }
        public string CompanyAddress { set; get; }
        public string CompanyWeb { set; get; }
        public string CompanyMail { set; get; }
        public string CompanyMobile { set; get; }
        public string FullName { set; get; }
        public string DesignationName { set; get; } 
    }
}