using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class Employee
    {
        public string EID { set; get; }
        public string E_date { set; get; }
        public string E_Time { set; get; }
        public Time Etimes { set; get; }
        public DateTime? GetTimeL { get; set; }
    }
}