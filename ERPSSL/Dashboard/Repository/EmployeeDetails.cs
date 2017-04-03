using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Dashboard.Repository
{
    public class EmployeeDetailsR
    {
        public int TotalEmployee { get; set; }
        public int TotalInactive { get; set; }
        public int CurrentEmp { get; set; }
        public int TotalFemale { get; set; }
        public int TotalMale { get; set; }
        public int TotalNewJoin { get; set; }

        public int TotalSeperation { get; set; }
        public int TotalOverTime { get; set; }
        public int TotalOTTaka { get; set; }
        public int TotalGrossSalary { get; set; }
        public int LastMonthCurrentEmp { get; set; }
        public int LastaMonthTotalNewJoin { get; set; }

    }
}
