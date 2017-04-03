using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class SalaryIncrementR
    {
        public string  Eid { get; set; }
        public Decimal Slary { get; set; }
        public int DesId { set; get; }
        public string Grade { set; get; }
        public string Ocode { set; get; }

        public Guid EDIT_USER { get; set; }

        public DateTime EDIT_DATE { get; set; }

        public DateTime? IncrementDate { get; set; }

        public DateTime? EffectiveDate { get; set; }

        public decimal? previousSalary { get; set; }

        public string SalaryIncrementStatus { get; set; }
    }
}