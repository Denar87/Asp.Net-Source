using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class SalaryIncrementRep
    {
        public string EID { set; get; }
        public string Name { set; get; }
        public string Designation { set; get; }
        public string Contact { set; get; }
        public string Department { set; get; }
        public decimal PreviousSalary { set; get; }
        public decimal CurrentSalary { set; get; }
        public decimal IncrementAcount { set; get; }
        public DateTime IncrementDate { set; get; }
    }
}