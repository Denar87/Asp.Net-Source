using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class TaxLiabilityConfigV
    {
        public int taxLiabilityconfiID { set; get; }
        public string Type { set; get; }
        public decimal IncomeFrom { set; get; }
        public decimal IncomeTo { set; get; }
        public string OFtax { set; get; }
    }
}