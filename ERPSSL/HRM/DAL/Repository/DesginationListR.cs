using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class DesginationListR
    {
        public int attendanceBounsId { set; get; }
        public string OfficeName { set; get; }
        public int? AttendanceDays1 { set; get; }
        public int? AttendanceDays2 { set; get; }
        public string Desgination { set; get; }
        public Decimal? Amount1 { set; get; }
        public Decimal? Amount2 { set; get; }
    }
}