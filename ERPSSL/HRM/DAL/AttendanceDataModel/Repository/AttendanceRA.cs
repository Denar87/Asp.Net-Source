using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.AttendanceDataModel.Repository
{
    public class AttendanceRA
    {
        public string EmpId { set; get; }
        public string PunchShiftCode { set; get; }
        public string Sts { set; get; }
        public string PunchDate { set; get; }
        public string TimeIn { set; get; }
        public string TimeOut { set; get; }
        public int Status { set; get; }
    }
}