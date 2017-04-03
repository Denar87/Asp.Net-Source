using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.INV.DAL.Repository
{
    public class SupervisorR
    {
        public int ID { get; set; }
        public string EID { get; set; }
        public string EmployeeName { get; set; }
        public String Supervizors { get; set; }
        public int? SupervisorCount { get; set; }
        public int? SupervisorNo { get; set; }
        public string SupervisorsName { get; set; }
        public string fullName { get; set; }
        public string ReportingBossId { get; set; }
    }
}