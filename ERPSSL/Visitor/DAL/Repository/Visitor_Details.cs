using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERPSSL.Visitor.DAL.Repository
{
    public class Visitor_Details
    {
        public int? V_ID { set; get; }
        public DateTime? VDate { set; get; }
        public string VisitorName { set; get; }
        public string FromAddress { set; get; }
        public string Phone { set; get; }
        public string ToWhom { set; get; }
        public string Purpose { set; get; }
        public int CardNo { set; get; }
        public string InTime { set; get; }
        public string OutTime { set; get; }

        public string CompanyName { set; get; }
        public string CompanyAddress { set; get; }
        public string CompanyMobile { set; get; }
        public byte[] Logo { set; get; }
    }
}