using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.BLL
{
    public class Calculations
    {
        public static TimeSpan timeDiff(TimeSpan in_time, TimeSpan out_time)
        {
            TimeSpan timespanDiff;
            timespanDiff = out_time - in_time;
            return timespanDiff;
        }
    }

}