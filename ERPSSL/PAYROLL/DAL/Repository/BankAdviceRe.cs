using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.PAYROLL.DAL.Repository
{
    public class BankAdviceRe
    {
        public string EID { get; set; }
        public string FullName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DEG_NAME { get; set; }
        public string BankName { get; set; }
        public string AccountNo { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public string Ocode { get; set; }
        public string OCODE { get; set; }
        public string CompanyName { get; set; }
        public string CompanyAddress { get; set; }
        public string CompanyMobile { get; set; }
        public string CompanyWeb { get; set; }
        public string CompanyMail { get; set; }
        public string Branch { get; set; }
        public int DepartmentId { get; set; }
        public string MobileBankName { get; set; }
        public string MobileNo { get; set; }
        public DateTime Salary_Month { get; set; }
        public string DPT_NAME { get; set; }

        public decimal Total_Gross_Sal { get; set; }
        public decimal? Net_Payable { get; set; }
    }
}