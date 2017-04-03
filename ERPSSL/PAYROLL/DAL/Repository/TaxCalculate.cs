using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.PAYROLL.DAL.Repository
{
    public class TaxCalculate
    {
        public string OfficeName { set; get; }
        public string ResionName { set; get; }
        public string DepartmentName { set; get; }
        public string CompanyName { set; get; }
        public string CompanyAddress { set; get; }
        public string CompanyMobile { set; get; }
        public string CompanyWeb { set; get; }
        public string CompanyMail { set; get; }
        public string DesignationName { get; set; }
        public byte[] Logo { get; set; }
        public string Pay_Allowance { set; get; }
        public decimal? ActualIncome { set; get; }
        public decimal? AmountOfExempted { get; set; }
        public decimal? TaxableIncome { get; set; }
        public string FullName { set; get; }
        public string EID { get; set; }

   

    }
}