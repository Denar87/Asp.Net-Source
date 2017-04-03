using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.PAYROLL.DAL.Repository
{
    public class Payroll
    {
        public decimal? TotalPayable { get; set; }
        public decimal? Net_Payable { get; set; }
        public decimal? TotalTax { get; set; }

        public decimal? AdvanceDeduction { get; set; }

        public decimal? Stamp { get; set; }
    }
}