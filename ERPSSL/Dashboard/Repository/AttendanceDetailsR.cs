using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Dashboard.Repository
{
    public class AttendanceDetailsR
    {
        public int TotalPresent { get; set; }
        public int TotalAbsent { get; set; }
        public int TotalLate { get; set; }
        public int TotalLeave { get; set; }
        public int TotalOT { get; set; }
        public int CurrentEmployee { get; set; }
    }
}