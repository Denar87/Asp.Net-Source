using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.HRM.DAL.Repository
{
    public class HolidayTypeR
    {
        public string HolidayName { set; get; }
        public string HolidayCode { set; get; }
        public DateTime? HolidayToDate { set; get; }
        public DateTime? HolidayFromDate { set; get; }
        public string HolidayTypeName { set; get; }
        public int? HolidayTypeId { set; get; }

    }
}